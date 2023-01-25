Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmABMArticulos

    Private LegajoLogueado, NumeroDeposito, idStock As String

    Sub New(ByVal pLegLog As String, ByVal pNumDepo As Integer)
        InitializeComponent()
        LegajoLogueado = pLegLog
        NumeroDeposito = pNumDepo

    End Sub

    Private bCargar As Boolean = False

    Private Sub fmrABMArticulos_Load(sender As Object, e As EventArgs) Handles Me.Load
        If System.Environment.MachineName.ToUpper = "COMPUTOS-LINUX" Or System.Environment.MachineName.ToUpper = "PCIGNACIO" Then
            lblContCargas.Visible = True
        Else
            lblContCargas.Visible = False
        End If
        rbActivos.Checked = True

        If NumeroDeposito = 3 Then
            btnCrearArticulo.Enabled = False
            btnEliminarArticulo.Enabled = False
            btnModificarArticulo.Enabled = False
        End If

        bCargar = True

        CargarCmbCategorias()
        CargarCmbColorIndex()

        CargarArticulos()

        ColorearPuntoPedido()


    End Sub

    Private Sub CargarCmbCategorias()
        Dim cmd As New SqlCommand
        Dim rd As SqlDataReader
        Dim sStr As String

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT nombreCategoria from dbo.HilamarArticulosCategorias C " + _
               "INNER JOIN HilamarArticulos A ON A.Categoria = C.id " + _
               "GROUP BY C.id, nombreCategoria " + _
               "ORDER BY C.id ASC"
        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        rd = cmd.ExecuteReader()

        Do While rd.HasRows
            Do While rd.Read()
                cmbFiltroCategorias.Items.Add(rd.Item("nombreCategoria"))
            Loop
            rd.NextResult()
        Loop

    End Sub


    Private Sub CargarArticulos()
        If Not bCargar Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Dim cmd As New SqlCommand
        Dim rd As SqlDataReader
        Dim sStr, FiltroCategoria, FitroActivo, FiltroBuscador, FiltroColorIndex, Row() As String

        Dim idColorIndex As String = DirectCast(cmbColorIndex.SelectedItem, KeyValuePair(Of String, String)).Key

        FiltroCategoria = ""
        FitroActivo = ""
        FiltroBuscador = ""
        FiltroColorIndex = ""

        LimpiarDGV()
        ArmarDGV()

        If cmbFiltroCategorias.Text <> "Todas" Then
            FiltroCategoria = " AND nombreCategoria = '" + cmbFiltroCategorias.Text + "' "
        End If

        If rbInactivos.Checked Then
            FitroActivo = " AND A.Activo = 0 "
        ElseIf rbActivos.Checked Then
            FitroActivo = " AND A.Activo = 1 "
        End If

        If tbBuscar.Text <> "" Then
            FiltroBuscador = "AND (nombreArt LIKE '%" + tbBuscar.Text + "%' OR observacion LIKE '%" + tbBuscar.Text + "%' OR nombreCategoria LIKE '%" + tbBuscar.Text + "%') "
        End If

        If Not cmbColorIndex.Text = "  - Sin Asociar" Then
            FiltroColorIndex = " AND XCI.idColorIndex = '" + idColorIndex + "' "
        End If

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        'sStr = "SELECT A.id, nombreArt, nombreCategoria, Activo , nombreUnidad, A.observacion, puntoPedido, ROUND(cantArticulo + SUM(cantidadArticulo * (CASE tipoMovimiento WHEN 'EG' THEN -1 WHEN 'IN' THEN 1 WHEN 'DI' THEN 1 END )), 3) AS TOTAL " + _
        '       "FROM HilamarArticulos AS A " + _
        '       "INNER JOIN HilamarArticulosStockDetalle AS SD ON SD.idArticulo = A.id " + _
        '       "INNER JOIN HilamarArticulosCategorias as Cat ON A.categoria = cat.id " + _
        '       "INNER JOIN HilamarArticulosUnidadesMedidas as Umed ON A.unidadMedida = Umed.id " + _
        '       "INNER JOIN dbo.HilamarArticulosStock as SE ON SD.idEnc = SE.id " + _
        '       "LEFT JOIN HilamarArticulosMovimientosDetalle as MD ON A.id = MD.idArticulo " + _
        '       "LEFT JOIN HilamarArticulosMovimientos as M ON MD.idMovimiento = M.id " + _
        '       "LEFT JOIN HilamarArticulos_X_ColorIndex XCI ON A.id = XCI.idArticulo " + _
        '       "WHERE M.fecha > SE.Fecha AND SE.fecha = (SELECT MAX(fecha) from dbo.HilamarArticulosStock) AND SE.numeroDeposito = " + NumeroDeposito + " AND M.numeroDeposito = " + NumeroDeposito + " AND A.eliminado = 0 " + _
        '       FiltroCategoria + _
        '       FitroActivo + _
        '       FiltroBuscador + _
        '       FiltroColorIndex + _
        '       "GROUP BY A.id, nombreArt, nombreCategoria, Activo, nombreUnidad, A.observacion, puntoPedido, cantArticulo " + _
        '       "union " + _
        '       "SELECT A.id, nombreArt, nombreCategoria, Activo, nombreUnidad, A.observacion, puntoPedido, cantArticulo AS TOTAL " + _
        '       "FROM HilamarArticulos AS A " + _
        '       "INNER JOIN HilamarArticulosStockDetalle AS SD ON SD.idArticulo = A.id " + _
        '       "INNER JOIN HilamarArticulosCategorias as Cat ON A.categoria = cat.id " + _
        '       "INNER JOIN HilamarArticulosUnidadesMedidas as Umed ON A.unidadMedida = Umed.id " + _
        '       "INNER JOIN dbo.HilamarArticulosStock as SE ON SD.idEnc = SE.id " + _
        '       "LEFT JOIN HilamarArticulosMovimientosDetalle as MD ON A.id = MD.idArticulo " + _
        '       "LEFT JOIN HilamarArticulosMovimientos as M ON MD.idMovimiento = M.id " + _
        '       "LEFT JOIN HilamarArticulos_X_ColorIndex XCI ON A.id = XCI.idArticulo " + _
        '       "WHERE SE.fecha = (SELECT MAX(fecha) from dbo.HilamarArticulosStock) AND SE.numeroDeposito = " + NumeroDeposito + " AND A.eliminado = 0 " + _
        '       FiltroCategoria + _
        '       FitroActivo + _
        '       FiltroBuscador + _
        '       FiltroColorIndex + _
        '       "GROUP BY A.id, nombreArt, nombreCategoria, Activo, nombreUnidad, A.observacion, puntoPedido, cantArticulo " + _
        '       "HAVING COUNT(MD.id) = 0 " + _
        '       "ORDER BY nombreCategoria ASC, nombreArt ASC"


        'sStr = "SELECT id, nombreCategoria, nombreart,  Activo , nombreUnidad, A.observacion, puntoPedido, sum(stockhilamar) as StockHilamar, sum(stockreservado) AS StockReservado, sum (StockFisico)/2 as StockFisico from ( " + _
        '        "SELECT  A.id, nombreCategoria, nombreArt,  Activo , nombreUnidad, A.observacion, puntoPedido, " + _
        '        "CASE SE.numeroDeposito WHEN 1 THEN cantArticulo + SUM(cantidadArticulo * (CASE tipoMovimiento WHEN 'EG' THEN -1 WHEN 'IN' THEN 1 WHEN 'DI' THEN 1 END ) * (CASE m.numeroDeposito WHEN 1 THEN 1 else 0 END )) end AS StockHilamar, " + _
        '        "CASE SE.numeroDeposito WHEN 3 THEN cantArticulo + SUM(cantidadArticulo * (CASE tipoMovimiento WHEN 'EG' THEN -1 WHEN 'IN' THEN 1 WHEN 'DI' THEN 1 END ) * (CASE m.numeroDeposito WHEN 3 THEN 1 else 0 END )) end AS StockReservado, " + _
        '        "cantArticulo + SUM(cantidadArticulo * (CASE tipoMovimiento WHEN 'EG' THEN -1 WHEN 'IN' THEN 1 WHEN 'DI' THEN 1 END )) AS StockFisico " + _
        '        "FROM HilamarArticulos AS A " + _
        '        "INNER JOIN HilamarArticulosCategorias as Cat ON A.categoria = cat.id " + _
        '        "INNER JOIN HilamarArticulosUnidadesMedidas as Umed ON A.unidadMedida = Umed.id " + _
        '        "INNER JOIN HilamarArticulosStockDetalle AS SD ON SD.idArticulo = A.id " + _
        '        "INNER JOIN dbo.HilamarArticulosStock as SE ON SD.idEnc = SE.id  " + _
        '        "LEFT JOIN HilamarArticulosMovimientosDetalle as MD ON A.id = MD.idArticulo " + _
        '        "LEFT JOIN HilamarArticulosMovimientos as M ON MD.idMovimiento = M.id " + _
        '        "LEFT JOIN HilamarArticulos_X_ColorIndex XCI ON A.id = XCI.idArticulo " + _
        '        "WHERE M.fecha > SE.Fecha AND SE.fecha = (SELECT MAX(fecha) from dbo.HilamarArticulosStock) AND A.eliminado = 0 " + _
        '        FiltroCategoria + _
        '        FitroActivo + _
        '        FiltroBuscador + _
        '        FiltroColorIndex + _
        '        "AND SE.numeroDeposito in (1, 3) " + _
        '        "AND M.numeroDeposito in (1, 3) " + _
        '        "GROUP BY A.id, A.NombreArt, nombreCategoria, Activo , nombreUnidad, A.observacion, puntoPedido, se.numeroDeposito, CantArticulo " + _
        '        "UNION " + _
        '        "SELECT A.id, nombreCategoria, NombreArt,  Activo , nombreUnidad, A.observacion, puntoPedido, " + _
        '        "CASE S.numerodeposito WHEN 1 THEN cantArticulo * (CASE m.numeroDeposito WHEN 1 THEN 1 else 0 END ) END AS StockHilamar, " + _
        '        "CASE S.numerodeposito WHEN 3 THEN cantArticulo * (CASE m.numeroDeposito WHEN 3 THEN 1 else 0 END )END AS StockReservado, " + _
        '        "0  AS StockFisico " + _
        '        "FROM HilamarArticulos AS A " + _
        '        "INNER JOIN HilamarArticulosCategorias as Cat ON A.categoria = cat.id " + _
        '        "INNER JOIN HilamarArticulosUnidadesMedidas as Umed ON A.unidadMedida = Umed.id " + _
        '        "INNER JOIN HilamarArticulosStockDetalle AS SD ON SD.idArticulo = A.id  " + _
        '        "INNER JOIN dbo.HilamarArticulosStock as S ON SD.idEnc = S.id  " + _
        '        "LEFT JOIN HilamarArticulosMovimientosDetalle as MD ON A.id = MD.idArticulo " + _
        '        "LEFT JOIN HilamarArticulosMovimientos as M ON MD.idMovimiento = M.id  " + _
        '        "LEFT JOIN HilamarArticulos_X_ColorIndex XCI ON A.id = XCI.idArticulo " + _
        '        "WHERE S.fecha = (SELECT MAX(fecha) from dbo.HilamarArticulosStock) AND A.eliminado = 0 " + _
        '         FiltroCategoria + _
        '         FitroActivo + _
        '         FiltroBuscador + _
        '         FiltroColorIndex + _
        '        "AND S.numeroDeposito in (1, 3) " + _
        '        "GROUP BY A.id, A.NombreArt, nombreCategoria, Activo , nombreUnidad, A.observacion, puntoPedido, cantArticulo, s.numeroDeposito, CantArticulo, m.numeroDeposito " + _
        '        "HAVING COUNT(MD.id) = 0 " + _
        '        ") A " + _
        '        "group by id, nombreart, nombreCategoria,  Activo , nombreUnidad, A.observacion, puntoPedido " + _
        '        "ORDER BY A.id ASC "


        sStr = "SELECT id, nombreCategoria, nombreart,  Activo , nombreUnidad, A.observacion, puntoPedido, sum(stockhilamar) as StockHilamar, sum(stockreservado) AS StockReservado, sum (StockFisico) as StockFisico from ( " + _
                "SELECT  A.id, nombreCategoria, nombreArt,  Activo , nombreUnidad, A.observacion, puntoPedido, " + _
                "CASE SE.numeroDeposito WHEN 1 THEN cantArticulo + SUM(cantidadArticulo * (CASE tipoMovimiento WHEN 'EG' THEN -1 WHEN 'IN' THEN 1 WHEN 'DI' THEN 1 END ) * (CASE m.numeroDeposito WHEN 1 THEN 1 else 0 END ))else 0 end AS StockHilamar, " + _
                "CASE SE.numeroDeposito WHEN 3 THEN cantArticulo + SUM(cantidadArticulo * (CASE tipoMovimiento WHEN 'EG' THEN -1 WHEN 'IN' THEN 1 WHEN 'DI' THEN 1 END ) * (CASE m.numeroDeposito WHEN 3 THEN 1 else 0 END ))else 0 end AS StockReservado, " + _
                "CASE SE.numeroDeposito WHEN 1 THEN cantArticulo + SUM(cantidadArticulo * (CASE tipoMovimiento WHEN 'EG' THEN -1 WHEN 'IN' THEN 1 WHEN 'DI' THEN 1 END ) * (CASE m.numeroDeposito WHEN 1 THEN 1 else 0 END ))else 0 end + " + _
                "CASE SE.numeroDeposito WHEN 3 THEN cantArticulo + SUM(cantidadArticulo * (CASE tipoMovimiento WHEN 'EG' THEN -1 WHEN 'IN' THEN 1 WHEN 'DI' THEN 1 END ) * (CASE m.numeroDeposito WHEN 3 THEN 1 else 0 END ))else 0 end " + _
                "AS StockFisico " + _
                "FROM HilamarArticulos AS A " + _
                "INNER JOIN HilamarArticulosCategorias as Cat ON A.categoria = cat.id " + _
                "INNER JOIN HilamarArticulosUnidadesMedidas as Umed ON A.unidadMedida = Umed.id " + _
                "INNER JOIN HilamarArticulosStockDetalle AS SD ON SD.idArticulo = A.id  " + _
                "INNER JOIN dbo.HilamarArticulosStock as SE ON SD.idEnc = SE.id  " + _
                "LEFT JOIN HilamarArticulosMovimientosDetalle as MD ON A.id = MD.idArticulo " + _
                "LEFT JOIN HilamarArticulosMovimientos as M ON MD.idMovimiento = M.id " + _
                "LEFT JOIN HilamarArticulos_X_ColorIndex XCI ON A.id = XCI.idArticulo " + _
                "WHERE M.fecha > SE.Fecha AND SE.fecha = (SELECT MAX(fecha) from dbo.HilamarArticulosStock) AND A.eliminado = 0 " + _
                FiltroCategoria + _
                FitroActivo + _
                FiltroBuscador + _
                FiltroColorIndex + _
                "AND SE.numeroDeposito in (1, 3) " + _
                "AND M.numeroDeposito in (1, 3) " + _
                "GROUP BY A.id, A.NombreArt, nombreCategoria, Activo , nombreUnidad, A.observacion, puntoPedido, se.numeroDeposito, CantArticulo " + _
                "UNION " + _
                "SELECT A.id, nombreCategoria, NombreArt,  Activo , nombreUnidad, A.observacion, puntoPedido, " + _
                "CASE S.numerodeposito WHEN 1 THEN cantArticulo * (CASE s.numeroDeposito WHEN 1 THEN 1 else 0 END )else 0 END AS StockHilamar, " + _
                "CASE S.numerodeposito WHEN 3 THEN cantArticulo * (CASE s.numeroDeposito WHEN 3 THEN 1 else 0 END )else 0 END AS StockReservado, " + _
                "CASE S.numerodeposito WHEN 1 THEN cantArticulo * (CASE s.numeroDeposito WHEN 1 THEN 1 else 0 END )else 0 END + " + _
                "CASE S.numerodeposito WHEN 3 THEN cantArticulo * (CASE s.numeroDeposito WHEN 3 THEN 1 else 0 END )else 0 END  " + _
                " AS StockFisico " + _
                "FROM HilamarArticulos AS A  " + _
                "INNER JOIN HilamarArticulosCategorias as Cat ON A.categoria = cat.id  " + _
                "INNER JOIN HilamarArticulosUnidadesMedidas as Umed ON A.unidadMedida = Umed.id  " + _
                "INNER JOIN HilamarArticulosStockDetalle AS SD ON SD.idArticulo = A.id   " + _
                "INNER JOIN dbo.HilamarArticulosStock as S ON SD.idEnc = S.id   " + _
                "LEFT JOIN HilamarArticulosMovimientosDetalle as MD ON A.id = MD.idArticulo   " + _
                "LEFT JOIN HilamarArticulosMovimientos as M ON MD.idMovimiento = M.id   " + _
                "LEFT JOIN HilamarArticulos_X_ColorIndex XCI ON A.id = XCI.idArticulo " + _
                "WHERE S.fecha = (SELECT MAX(fecha) from dbo.HilamarArticulosStock) AND A.eliminado = 0  " + _
                 FiltroCategoria + _
                 FitroActivo + _
                 FiltroBuscador + _
                 FiltroColorIndex + _
                "AND S.numeroDeposito in (1, 3)  " + _
                "GROUP BY A.id, A.NombreArt, nombreCategoria, Activo , nombreUnidad, A.observacion, puntoPedido, cantArticulo, s.numeroDeposito, CantArticulo, m.numeroDeposito " + _
                "HAVING COUNT(MD.id) = 0 " + _
                ")A " + _
                "group by id, nombreart, nombreCategoria,  Activo , nombreUnidad, A.observacion, puntoPedido " + _
                "ORDER BY A.id ASC "


                            cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
                            rd = cmd.ExecuteReader()

                            Do While rd.HasRows
                                Do While rd.Read()
                                    Row = {rd.Item("id"), rd.Item("nombreCategoria"), rd.Item("nombreArt"), rd.Item("observacion"), rd.Item("puntoPedido"), Math.Round(Convert.ToDecimal(rd.Item("StockHilamar")), 3), Math.Round(Convert.ToDecimal(rd.Item("StockReservado")), 3), Math.Round(Convert.ToDecimal(rd.Item("StockFisico")), 3), rd.Item("nombreUnidad")}
                                    dgvListadoDeArticulos.Rows.Add(Row)
                                Loop
                                rd.NextResult()
                            Loop

                            Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LimpiarDGV()
        dgvListadoDeArticulos.Rows.Clear()
        dgvListadoDeArticulos.Columns.Clear()
    End Sub

    Private Sub CargarCmbColorIndex()
        Dim cmd As New SqlCommand
        Dim rd As SqlDataReader
        Dim sStr As String

        Dim comboSource As New Dictionary(Of String, String)()

        sStr = "SELECT id, Codigo, NombreColor FROM dbo.HilamarArticulosColorIndex " + _
            "WHERE Eliminado = 0"
        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        rd = cmd.ExecuteReader()

        Do While rd.HasRows
            Do While rd.Read()
                comboSource.Add(rd.Item("id"), (rd.Item("Codigo").ToString + " - " + rd.Item("NombreColor").ToString))

            Loop
            rd.NextResult()
        Loop
        cmbColorIndex.DataSource = New BindingSource(comboSource, Nothing)
        cmbColorIndex.DisplayMember = "Value"
        cmbColorIndex.ValueMember = "Key"

    End Sub

    Private Sub ArmarDGV()

        If lblContCargas.Text = "" Then
            lblContCargas.Text = "0"
        End If
        lblContCargas.Text = Integer.Parse(lblContCargas.Text) + 1

        dgvListadoDeArticulos.Columns.Add("ID", "id")
        dgvListadoDeArticulos.Columns("ID").Visible = False

        dgvListadoDeArticulos.Columns.Add("Categoría", "Categoría")
        dgvListadoDeArticulos.Columns("Categoría").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvListadoDeArticulos.Columns("Categoría").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        dgvListadoDeArticulos.Columns.Add("Artículo", "Artículo")
        dgvListadoDeArticulos.Columns("Artículo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListadoDeArticulos.Columns("Artículo").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        dgvListadoDeArticulos.Columns.Add("Observación", "Observación")
        dgvListadoDeArticulos.Columns("Observación").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListadoDeArticulos.Columns("Observación").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        dgvListadoDeArticulos.Columns.Add("P. Pedido", "P. Pedido")
        dgvListadoDeArticulos.Columns("P. Pedido").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListadoDeArticulos.Columns("P. Pedido").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        dgvListadoDeArticulos.Columns.Add("Dispo.", "Dispo.")
        dgvListadoDeArticulos.Columns("Dispo.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListadoDeArticulos.Columns("Dispo.").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        dgvListadoDeArticulos.Columns.Add("Res.", "Res.")
        dgvListadoDeArticulos.Columns("Res.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListadoDeArticulos.Columns("Res.").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        dgvListadoDeArticulos.Columns.Add("Físico", "Físico")
        dgvListadoDeArticulos.Columns("Físico").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListadoDeArticulos.Columns("Físico").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        dgvListadoDeArticulos.Columns.Add("Unidad", "Unidad")
        dgvListadoDeArticulos.Columns("Unidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvListadoDeArticulos.Columns("Unidad").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvListadoDeArticulos.Columns("Unidad").SortMode = DataGridViewColumnSortMode.NotSortable

        For Each colum As DataGridViewColumn In dgvListadoDeArticulos.Columns
            colum.ReadOnly = True
        Next

        dgvListadoDeArticulos.Font = New Font("Arial", 10)

    End Sub

    Private Sub cmbFiltroCategorias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFiltroCategorias.SelectedIndexChanged
        CargarArticulos()

        FiltroPuntoPedido()
        ColorearPuntoPedido()

    End Sub

    Public Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        CargarArticulos()

        FiltroPuntoPedido()
        ColorearPuntoPedido()

    End Sub

    Private Sub rbActivos_CheckedChanged(sender As Object, e As EventArgs) Handles rbActivos.CheckedChanged, rbInactivos.CheckedChanged
        If sender.Checked Then
            CargarArticulos()

            FiltroPuntoPedido()
            ColorearPuntoPedido()
        End If

    End Sub

    Private Sub btnCrearArticulo_Click(sender As Object, e As EventArgs) Handles btnCrearArticulo.Click
        Dim fmrCrearArticulo As New frmCrearArticulo(0)
        fmrCrearArticulo.Show()

    End Sub

    Private Sub tbBuscar_TextChanged(sender As Object, e As EventArgs) Handles tbBuscar.TextChanged
        If tbBuscar.Text.ToLower = "a" Then
            Exit Sub
        End If

        If tbBuscar.Text.ToLower = "b" Then
            Exit Sub
        End If

        If tbBuscar.Text.ToLower = "c" Then
            Exit Sub
        End If

        CargarArticulos()
        FiltroPuntoPedido()
        ColorearPuntoPedido()

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()

    End Sub

    Private Sub btnEliminarArticulo_Click(sender As Object, e As EventArgs) Handles btnEliminarArticulo.Click
        If dgvListadoDeArticulos.SelectedRows.Count <> 1 Then Exit Sub

        Dim cmd As New SqlCommand
        Dim sStr As String

        Dim ArticuloAEliminar As String

        ArticuloAEliminar = dgvListadoDeArticulos.CurrentRow.Cells.Item("ID").Value

        Dim rta As Integer = MsgBox("¿Esta seguro que desea eliminar " + dgvListadoDeArticulos.CurrentCell.Value + "?", vbYesNo)

        If rta = 7 Then
            Exit Sub
        End If

        sStr = "UPDATE dbo.HilamarArticulos "
        sStr += "SET eliminado = 1 "
        sStr += "WHERE id = '" + ArticuloAEliminar + "' "

        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        cmd.ExecuteNonQuery()

        CargarArticulos()
        FiltroPuntoPedido()
        ColorearPuntoPedido()

    End Sub

    Private Sub btnModificarArticulo_Click(sender As Object, e As EventArgs) Handles btnModificarArticulo.Click
        If dgvListadoDeArticulos.SelectedRows.Count <> 1 Then Exit Sub
        Dim fmrCrearModificar As New frmCrearArticulo(dgvListadoDeArticulos.CurrentRow.Cells.Item("ID").Value)

        fmrCrearModificar.ShowDialog()
        CargarArticulos()
        FiltroPuntoPedido()
        ColorearPuntoPedido()

    End Sub

    Private Sub dgvListadoDeArticulos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListadoDeArticulos.CellDoubleClick
        Dim fmrCrearModificar As New frmCrearArticulo(dgvListadoDeArticulos.CurrentRow.Cells.Item("ID").Value)

        fmrCrearModificar.ShowDialog()
        CargarArticulos()
        FiltroPuntoPedido()
        ColorearPuntoPedido()

    End Sub

    Private Sub chkPuntoPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chkPuntoPedido.CheckedChanged
        FiltroPuntoPedido()

    End Sub

    Private Sub FiltroPuntoPedido()
        Me.Cursor = Cursors.WaitCursor
        If chkPuntoPedido.Checked Then
            For Each row As DataGridViewRow In dgvListadoDeArticulos.Rows
                If Convert.ToDouble(row.Cells("Dispo.").Value) > Convert.ToDouble(row.Cells("P. Pedido").Value) Then
                    row.Visible = False
                End If
            Next
        Else
            For Each row As DataGridViewRow In dgvListadoDeArticulos.Rows
                row.Visible = True
            Next
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ColorearPuntoPedido()

        If NumeroDeposito = 3 Then Exit Sub
        'Si ingresa en deposito de reserva no la corro.
        Me.Cursor = Cursors.WaitCursor
        For Each row As DataGridViewRow In dgvListadoDeArticulos.Rows
            If Convert.ToDouble(row.Cells("Dispo.").Value) <= Convert.ToDouble(row.Cells("P. Pedido").Value) Then
                row.DefaultCellStyle.BackColor = Color.LightCoral

                If row.Cells("P. Pedido").Value = "" Then
                    dgvListadoDeArticulos.Rows(row.Index).DefaultCellStyle.BackColor = Color.White
                End If
            End If
        Next
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvListadoDeArticulos_SelectionChanged(sender As Object, e As EventArgs) Handles dgvListadoDeArticulos.SelectionChanged

        If NumeroDeposito = 3 Then Exit Sub



            If dgvListadoDeArticulos.SelectedRows.Count = 1 Then
                btnModificarArticulo.Enabled = True
                btnEliminarArticulo.Enabled = True
            Else
                btnModificarArticulo.Enabled = False
                btnEliminarArticulo.Enabled = False
            End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbColorIndex.SelectedIndexChanged
        CargarArticulos()
        FiltroPuntoPedido()
        ColorearPuntoPedido()
    End Sub
End Class