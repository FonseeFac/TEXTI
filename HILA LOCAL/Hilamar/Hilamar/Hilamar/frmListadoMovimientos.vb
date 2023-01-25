Imports System.Data.SqlClient

Public Class frmListadoMovimientos

    Private LegajoLogueado As String
    Private NumeroDeposito As String
    Private bCargar As Boolean = False

    Sub New(ByVal pLegLog As String, ByVal pNumDepo As Integer)
        InitializeComponent()

        LegajoLogueado = pLegLog
        NumeroDeposito = pNumDepo
    End Sub

    Private Sub frmABMMovimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor
        If System.Environment.MachineName.ToUpper <> "COMPUTOS-LINUX" Then
            btnPrueba.Visible = False
        End If

        DelimitarFechas()
        dtpFechaDesde.Value = dtpFechaDesde.MinDate

        Me.CenterToScreen()
        AjustarDimensionesForm()

        CargarCombos()
        bCargar = True

        CargarMovimientos()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub DelimitarFechas()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT Min(fecha) AS Fecha " + _
               "        FROM HilamarArticulosStock " + _
               "WHERE numerodeposito = " + NumeroDeposito
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                dtpFechaDesde.MinDate = Reader.Item("Fecha")
                dtpFechaHasta.MinDate = Reader.Item("Fecha")
            End If
        End If

        dtpFechaDesde.MaxDate = NowServer()
        dtpFechaHasta.MaxDate = NowServer()

    End Sub

    Private Sub dtpFechaIngreso_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaDesde.ValueChanged
        If Not bCargar Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        CargarCombos()
        Me.Cursor = Cursors.Arrow
        dtpFechaHasta.MinDate = dtpFechaDesde.Value
    End Sub

    Private Sub dtpFechaHasta_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaHasta.ValueChanged
        If Not bCargar Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        CargarCombos()
        Me.Cursor = Cursors.Arrow
        dtpFechaDesde.MaxDate = dtpFechaHasta.Value
    End Sub

    Private Sub ArmarDGV(ByRef dgv As DataGridView)
        LimpiarDGV(dgv)
        If dgv.Name = "dgvMovimientos" Then
            dgv.Columns.Add("idMovimiento", "idMovimiento")
            dgv.Columns("idMovimiento").Visible = False
            dgv.Columns.Add("Fecha", "Fecha")
            dgv.Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgv.Columns("Fecha").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgv.Columns.Add("Tipo", "Tipo")
            dgv.Columns("Tipo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgv.Columns("Tipo").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgv.Columns.Add("Observaciones", "Observaciones")
            dgv.Columns("Observaciones").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgv.Columns("Observaciones").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgv.Columns.Add("MovidoPor", "Movido Por")
            'dgv.Columns("MovidoPor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'dgv.Columns("MovidoPor").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgv.Columns("MovidoPor").Visible = False
        ElseIf dgv.Name = "dgvDetalleMovimiento" Then
            dgv.Columns.Add("Categoria", "Categoría")
            dgv.Columns("Categoria").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgv.Columns("Categoria").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            dgv.Columns.Add("Articulo", "Artículo")
            dgv.Columns("Articulo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgv.Columns("Articulo").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgv.Columns.Add("Cantidad", "Cantidad")
            dgv.Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgv.Columns("Cantidad").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        End If
    End Sub

    Private Sub LimpiarDGV(ByRef dgv As DataGridView)
        dgv.Rows.Clear()
        dgv.Columns.Clear()
    End Sub

    Private Sub CargarCombos()
        CargarComboTipoMovimiento()
        CargarComboCategoria()
        CargarComboArticulo()
        CargarComboProveedor()
    End Sub

    Private Sub CargarComboTipoMovimiento()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr, Seleccionado As String

        If cbTipoMovimiento.Items.Count > 0 Then
            Seleccionado = cbTipoMovimiento.Text
        Else
            Seleccionado = ""
        End If

        cbTipoMovimiento.Items.Clear()
        cbTipoMovimiento.Items.Add("")

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT tipoMovimiento, COUNT(id) AS Cant " + _
               "FROM HilamarArticulosMovimientos " + _
               "GROUP BY tipoMovimiento " + _
               "ORDER BY Cant DESC"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows()
            Do While Reader.Read()
                Select Case Reader.Item("tipoMovimiento")
                    Case "IN"
                        cbTipoMovimiento.Items.Add("Ingreso")
                    Case "EG"
                        cbTipoMovimiento.Items.Add("Egreso")
                    Case "DI"
                        cbTipoMovimiento.Items.Add("Dif. de Inventario")
                End Select
            Loop
            Reader.NextResult()
        Loop

        If cbTipoMovimiento.Items.Contains(Seleccionado) Then
            cbTipoMovimiento.SelectedItem = Seleccionado
        End If
    End Sub

    Private Sub CargarComboCategoria()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr, FiltroProveedor, Seleccionado As String

        If cbCategoria.Items.Count > 0 Then
            Seleccionado = cbCategoria.Text
        Else
            Seleccionado = ""
        End If

        cbCategoria.Items.Clear()
        cbCategoria.Items.Add("")

        If cbProveedor.Items.Count > 0 AndAlso cbProveedor.SelectedIndex <> 0 Then
            FiltroProveedor = "AND CC.NOMBRE = '" + cbProveedor.Text + "' "
        End If

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT DISTINCT nombrecategoria " + _
               "FROM hilamararticuloscategorias C " + _
               "INNER JOIN hilamararticulos A ON A.categoria = C.id " + _
               "INNER JOIN HilamarArticulosMovimientosDetalle MD ON MD.idArticulo = A.id " + _
               "INNER JOIN HilamarArticulosMovimientos M ON M.id = MD.idMovimiento " + _
               "LEFT JOIN BASE10.dbo.CTACTES CC ON CC.CODCTACTE = M.CodProveedor " + _
               "WHERE M.fecha BETWEEN '" + dtpFechaDesde.Value + "' AND '" + dtpFechaHasta.Value + "' " + _
               "AND M.numerodeposito = " + NumeroDeposito + _
               "ORDER BY nombrecategoria ASC  "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows()
            Do While Reader.Read()
                cbCategoria.Items.Add(Reader.Item("nombreCategoria").ToString)
            Loop
            Reader.NextResult()
        Loop

        If cbCategoria.Items.Contains(Seleccionado) Then
            cbCategoria.SelectedItem = Seleccionado
        End If
    End Sub

    Private Sub CargarComboArticulo()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr, FiltroCategoria, FiltroProveedor, Seleccionado As String

        FiltroCategoria = ""
        FiltroProveedor = ""

        If cbArticulo.Items.Count > 0 Then
            Seleccionado = cbArticulo.Text
        Else
            Seleccionado = ""
        End If

        cbArticulo.Items.Clear()
        cbArticulo.Items.Add("")

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        If cbCategoria.Items.Count > 0 AndAlso cbCategoria.SelectedIndex <> 0 Then
            FiltroCategoria = "AND C.nombreCategoria = '" + cbCategoria.Text + "' "
        End If

        If cbProveedor.Items.Count > 0 AndAlso cbProveedor.SelectedIndex <> 0 Then
            FiltroProveedor = "AND CC.NOMBRE = '" + cbProveedor.Text + "' "
        End If

        sStr = "SELECT DISTINCT nombreart " + _
               "FROM hilamararticulos A " + _
               "INNER JOIN hilamararticuloscategorias C ON A.categoria = C.id " + _
               "INNER JOIN HilamarArticulosMovimientosDetalle MD ON MD.idArticulo = A.id " + _
               "INNER JOIN HilamarArticulosMovimientos M ON M.id = MD.idMovimiento " + _
               "LEFT JOIN BASE10.dbo.CTACTES CC ON CC.CODCTACTE = M.CodProveedor " + _
               "WHERE M.fecha BETWEEN '" + dtpFechaDesde.Value + "' AND '" + dtpFechaHasta.Value + "' " + _
               "AND M.numerodeposito = " + NumeroDeposito + _
               FiltroCategoria + _
               FiltroProveedor + _
               "ORDER BY nombreart ASC"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows()
            Do While Reader.Read()
                cbArticulo.Items.Add(Reader.Item("nombreArt").ToString)
            Loop
            Reader.NextResult()
        Loop

        If cbArticulo.Items.Contains(Seleccionado) Then
            cbArticulo.SelectedItem = Seleccionado
        End If
    End Sub

    Private Sub CargarComboProveedor()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr, FiltroCategoria, Seleccionado As String

        If cbProveedor.Items.Count > 0 Then
            Seleccionado = cbProveedor.Text
        Else
            Seleccionado = ""
        End If

        cbProveedor.Items.Clear()
        cbProveedor.Items.Add("")

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        If cbCategoria.SelectedIndex = 0 Then
            FiltroCategoria = ""
        Else
            FiltroCategoria = "AND C.nombreCategoria = '" + cbCategoria.Text + "' "
        End If

        sStr = "SELECT DISTINCT CC.NOMBRE " + _
               "FROM BASE10.dbo.CTACTES CC " + _
               "INNER JOIN HilamarArticulosMovimientos as M ON M.CodProveedor = CC.CODCTACTE " + _
               "INNER JOIN HilamarArticulosMovimientosDetalle as MD ON MD.idMovimiento = M.id " + _
               "INNER JOIN HilamarArticulos A ON MD.idArticulo = A.id " + _
               "INNER JOIN HilamarArticulosCategorias C ON A.Categoria = C.id " + _
               "WHERE CUEPREFI='P' AND CC.CODCTACTE like '%%' AND ISNULL(SUSPENDIDOS,0) = 0  " + _
               "AND M.fecha BETWEEN '" + dtpFechaDesde.Value + "' AND '" + dtpFechaHasta.Value + "' " + _
               "AND M.numerodeposito = " + NumeroDeposito + _
               FiltroCategoria + _
               "ORDER BY CC.NOMBRE "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows()
            Do While Reader.Read()
                cbProveedor.Items.Add(Reader.Item("NOMBRE"))
            Loop
            Reader.NextResult()
        Loop

        If cbProveedor.Items.Contains(Seleccionado) Then
            cbProveedor.SelectedItem = Seleccionado
        End If
    End Sub

    Private Sub cbTipoMovimiento_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbTipoMovimiento.SelectionChangeCommitted
        If Not bCargar Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        CargarCombos()
        CargarMovimientos()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cbTipoMovimiento_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbTipoMovimiento.SelectedValueChanged
        If cbTipoMovimiento.Text = "Egreso" Or cbTipoMovimiento.Text = "Dif. de Inventario" Then
            cbProveedor.SelectedIndex = 0
            gbProveedor.Enabled = False
        Else
            gbProveedor.Enabled = True
        End If
    End Sub

    Private Sub cbCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCategoria.SelectionChangeCommitted
        If Not bCargar Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        CargarCombos()
        CargarMovimientos()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cbArticulo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbArticulo.SelectionChangeCommitted
        If Not bCargar Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        CargarCombos()
        CargarMovimientos()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cbProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProveedor.SelectionChangeCommitted
        If Not bCargar Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        CargarCombos()
        CargarMovimientos()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtNroComprobante_TextChanged(sender As Object, e As EventArgs)
        If Not bCargar Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        'Los combos solo se cruzan entre ellos, no los recargo
        CargarMovimientos()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtBuscador_TextChanged(sender As Object, e As EventArgs) Handles txtBuscador.TextChanged
        If Not bCargar Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        'Los combos solo se cruzan entre ellos, no los recargo
        CargarMovimientos()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub CargarMovimientos()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr, FiltroTipoMovimiento, FiltroCategoriaArticulo, FiltroArticulo, FiltroProveedor, FiltroBuscador, Row() As String

        FiltroTipoMovimiento = ""
        FiltroCategoriaArticulo = ""
        FiltroArticulo = ""
        FiltroProveedor = ""
        FiltroBuscador = ""

        If cbTipoMovimiento.SelectedIndex <> 0 Then
            Select Case cbTipoMovimiento.Text
                Case "Ingreso"
                    FiltroTipoMovimiento = "AND M.tipoMovimiento = 'IN' "
                Case "Egreso"
                    FiltroTipoMovimiento = "AND M.tipoMovimiento = 'EG' "
                Case "Dif. de Inventario"
                    FiltroTipoMovimiento = "AND M.tipoMovimiento = 'DI' "
            End Select
        End If

        If cbCategoria.SelectedIndex <> 0 Then
            FiltroCategoriaArticulo = "AND AC.nombreCategoria = '" + cbCategoria.Text + "' "
        End If

        If cbArticulo.SelectedIndex <> 0 Then
            FiltroArticulo = "AND A.nombreArt = '" + cbArticulo.Text + "' "
        End If

        If cbProveedor.SelectedIndex <> 0 Then
            FiltroProveedor = "AND CC.NOMBRE = '" + cbProveedor.Text + "' "
        End If

        If txtBuscador.Text <> "" Then
            FiltroBuscador = "AND (" + _
                             "CONVERT(varchar(50), M.NroComprobante) LIKE '%" + txtBuscador.Text + "%' " + _
                             "OR AC.nombreCategoria LIKE '%" + txtBuscador.Text + "%'" + _
                             "OR A.nombreArt LIKE '%" + txtBuscador.Text + "%'" + _
                             "OR CC.NOMBRE LIKE '%" + txtBuscador.Text + "%'" + _
                             ") "
        End If

        ArmarDGV(dgvMovimientos)

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT M.id, M.fecha, M.tipoMovimiento, M.observaciones, M.movidoPor FROM HilamarArticulosMovimientos M " + _
               "INNER JOIN HilamarArticulosMovimientosDetalle MD ON M.id = MD.idMovimiento " + _
               "INNER JOIN HilamarArticulos	A ON A.id = MD.idArticulo " + _
               "INNER JOIN HilamarArticulosCategorias AC ON AC.id = A.categoria " + _
               "LEFT JOIN BASE10.dbo.CTACTES CC ON CC.CODCTACTE = M.CodProveedor " + _
               "WHERE M.eliminado = 0 " + _
               "AND M.numeroDeposito = " + NumeroDeposito + " " + _
               "AND M.fecha BETWEEN '" + dtpFechaDesde.Value + "' AND '" + dtpFechaHasta.Value + "' " + _
               FiltroCategoriaArticulo + _
               FiltroArticulo + _
               FiltroTipoMovimiento + _
               FiltroProveedor + _
               FiltroBuscador + _
               "GROUP BY M.id, M.fecha, M.tipoMovimiento, M.observaciones, M.movidoPor " + _
               "ORDER BY M.id DESC"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows()
            Do While Reader.Read()
                Dim TipoMovimiento As String = ""
                Select Case Reader.Item("tipoMovimiento")
                    Case "IN"
                        TipoMovimiento = "Ingreso"
                    Case "EG"
                        TipoMovimiento = "Egreso"
                    Case "DI"
                        TipoMovimiento = "Dif. de Inventario"
                End Select
                Row = {Reader.Item("id"), Date.Parse(Reader.Item("fecha")).Date, TipoMovimiento, Reader.Item("observaciones"), Reader.Item("movidoPor")}

                dgvMovimientos.Rows.Add(Row)
            Loop
            Reader.NextResult()
        Loop
        dgvMovimientos.ClearSelection()
        LimpiarDGV(dgvDetalleMovimiento)
        If dgvMovimientos.RowCount = 1 Then
            dgvMovimientos.Rows(0).Selected = True
        End If
    End Sub

    Private Sub AjustarDimensionesForm()
        Dim iAlto = gbMovimientos.Location.Y + gbMovimientos.Height + 52
        Dim iAncho = gbFiltros.Location.X + gbFiltros.Width + 30

        Dim AlturaDGVDetalle As Integer = dgvDetalleMovimiento.ColumnHeadersHeight

        For Each row In dgvDetalleMovimiento.Rows
            AlturaDGVDetalle += row.Height
        Next

        AlturaDGVDetalle += 2

        dgvDetalleMovimiento.Height = AlturaDGVDetalle
        If dgvDetalleMovimiento.Height > 290 Then
            dgvDetalleMovimiento.Height = 290
        End If

        gbDetalleMovimiento.Height = dgvDetalleMovimiento.Location.Y + dgvDetalleMovimiento.Height + 7

        If gbMovimientos.Location.Y + gbMovimientos.Height > gbDetalleMovimiento.Location.Y + gbDetalleMovimiento.Height Then
            iAlto = gbMovimientos.Location.Y + gbMovimientos.Height + 52
        Else
            iAlto = gbDetalleMovimiento.Location.Y + gbDetalleMovimiento.Height + 52
        End If

        Me.Height = iAlto
        Me.Width = iAncho
    End Sub

    Private Sub dgvMovimientos_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMovimientos.SelectionChanged
        If Not bCargar Then Exit Sub
        If dgvMovimientos.SelectedRows.Count = 1 Then
            CargarDetalleMovimiento()
        End If
    End Sub

    Private Sub CargarDetalleMovimiento()
        If Not bCargar Then Exit Sub
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr, Row() As String

        ArmarDGV(dgvDetalleMovimiento)

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT C.NombreCategoria, A.nombreArt, MD.cantidadArticulo, AU.nombreUnidad FROM HilamarArticulosMovimientosDetalle MD " + _
               "INNER JOIN HilamarArticulos A ON A.id = MD.idArticulo " + _
               "INNER JOIN HilamarArticulosUnidadesMedidas AU ON A.unidadMedida = AU.ID " + _
               "INNER JOIN hilamararticuloscategorias C ON A.categoria = C.id " + _
               "WHERE idMovimiento = " + dgvMovimientos.CurrentRow.Cells("idMovimiento").Value.ToString
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows()
            Do While Reader.Read()
                Row = {Reader.Item("NombreCategoria"), Reader.Item("nombreArt"), Reader.Item("cantidadArticulo").ToString + " " + Reader.Item("nombreUnidad")}
                dgvDetalleMovimiento.Rows.Add(Row)
            Loop
            Reader.NextResult()
        Loop

        AjustarDimensionesForm()
    End Sub

    Private Sub dgv_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgvMovimientos.RowsRemoved, dgvDetalleMovimiento.RowsRemoved
        If dgvMovimientos.RowCount = 0 Or dgvDetalleMovimiento.RowCount = 0 Then
            AjustarDimensionesForm()
        End If
    End Sub

    Private Sub btnPrueba_Click(sender As Object, e As EventArgs) Handles btnPrueba.Click
        'CargaAutomaticaArticulos()
        'CargaAutomaticaMovimientos()
    End Sub

    Private Sub CargaAutomaticaArticulos()
        Dim Command, Command2 As SqlCommand
        Dim Reader, Reader2 As SqlDataReader
        Dim sStr, idArticulo, idCategoria, sReemplazar As String

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT MSPA.Id, DescArt, Movimientos, DescArtAdic, UnidadMedida, PuntoDePedido FROM MantStoPerArticulos MSPA " + _
               "LEFT JOIN (SELECT IdArt, isnull(COUNT(Id), 0) AS Movimientos FROM MantStoPerStock WHERE Fecha > (SELECT DATEADD(MONTH, -24, GETDATE()) ) GROUP BY IdArt) MSPS " + _
               "ON MSPA.Id = MSPS.IdArt " + _
               "WHERE Movimientos IS NOT NULL " + _
               "ORDER BY Movimientos DESC"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows()
            Do While Reader.Read()

                Dim PuntoPedido, idUnidad As String

                If IsDBNull(Reader.Item("PuntoDePedido")) Then
                    PuntoPedido = "0"
                Else
                    PuntoPedido = "'" + Reader.Item("PuntoDePedido").ToString + "'"
                End If

                Select Case Reader.Item("UnidadMedida").ToString.ToUpper
                    Case "KILOGRAMOS"
                        idUnidad = "1"
                    Case "BOLSAS"
                        idUnidad = "2"
                    Case "ROLLOS"
                        idUnidad = "3"
                    Case "LITROS"
                        idUnidad = "4"
                    Case "CAJAS"
                        idUnidad = "5"
                    Case "UNIDADES"
                        idUnidad = "6"
                    Case "CONOS"
                        idUnidad = "7"
                    Case Else
                        idUnidad = "0"
                End Select

                Select Case True
                    Case Reader.Item("DescArt").ToString.StartsWith("AUXILIAR ")
                        idCategoria = "2"
                        sReemplazar = "AUXILIAR "
                    Case Reader.Item("DescArt").ToString.StartsWith("QUIMICOS ")
                        idCategoria = "4"
                        sReemplazar = "QUIMICOS "
                    Case Reader.Item("DescArt").ToString.StartsWith("COLORANTE ACRILICO ")
                        idCategoria = "5"
                        sReemplazar = "COLORANTE ACRILICO "
                    Case Reader.Item("DescArt").ToString.StartsWith("COLORANTE ALGODON ")
                        idCategoria = "6"
                        sReemplazar = "COLORANTE ALGODON "
                    Case Reader.Item("DescArt").ToString.StartsWith("COLORANTE LANA ")
                        idCategoria = "7"
                        sReemplazar = "COLORANTE LANA "
                    Case Reader.Item("DescArt").ToString.StartsWith("COLORANTE POLIESTER ")
                        idCategoria = "8"
                        sReemplazar = "COLORANTE POLIESTER "
                    Case Else
                        idCategoria = "9" 'Otros
                        sReemplazar = ""
                End Select

                Dim NombreArticulo As String

                If sReemplazar = "" Then
                    NombreArticulo = Trim(Reader.Item("DescArt").ToString)
                Else
                    NombreArticulo = Trim(Reader.Item("DescArt").ToString.Replace(sReemplazar, ""))
                End If

                sStr = "INSERT INTO dbo.HilamarArticulos " + _
                       "VALUES ('" + NombreArticulo + "', " + idCategoria + ", " + idUnidad + ", " + PuntoPedido + " , 0, '" + Trim(Reader.Item("DescArtAdic").ToString) + "', 1) "
                Command2 = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command2.ExecuteNonQuery()

                sStr = "SELECT SCOPE_IDENTITY() AS id"
                Command2 = New SqlCommand(sStr, cConexionApp.SQLConn)
                Reader2 = Command2.ExecuteReader()
                If Reader2.HasRows() Then
                    If Reader2.Read() Then
                        idArticulo = Reader2.Item("id")
                    End If
                End If

                sStr = "INSERT INTO dbo.HilamarArticulosStockDetalle " + _
                       "(idArticulo, idEnc, CantArticulo) " + _
                       "VALUES (" + idArticulo + ", 1, 0) " + _
                       "INSERT INTO dbo.HilamarArticulosStockDetalle " + _
                       "(idArticulo, idEnc, CantArticulo) " + _
                       "VALUES (" + idArticulo + ", 2, 0) "
                Command2 = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command2.ExecuteNonQuery()
            Loop
            Reader.NextResult()

            MensajeAtencion("Proceso terminado.")
        Loop
    End Sub

    Private Sub CargaAutomaticaMovimientos()
        Dim Command, Command2 As SqlCommand
        Dim Reader, Reader2 As SqlDataReader
        Dim sStr, idMovimiento, TipoMovimiento As String

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        For i = 0 To GetRandomInt(50, 100)
            Select Case GetRandomInt(1, 12)
                Case 1
                    TipoMovimiento = "DI"
                Case 2
                    TipoMovimiento = "EG"
                Case 3
                    TipoMovimiento = "DI"
                Case 4
                    TipoMovimiento = "EG"
                Case Else
                    TipoMovimiento = "IN"
            End Select

            sStr = "INSERT INTO HilamarArticulosMovimientos " + _
                   "(fecha, movidoPor, tipoMovimiento, eliminado, nroComprobante, tipoComprobante, observaciones, numeroDeposito, fechaAuditAlta) VALUES (" + _
                   "'20221215', " + _
                   "'" + LegajoLogueado.ToString.ToUpper + " - " + Environment.MachineName.ToUpper + "', " + _
                   "'" + TipoMovimiento + "', " + _
                   "0, " + _
                   "'', " + _
                   "'', " + _
                   "'', " + _
                   "1, " + _
                   "GETDATE())"
            Command2 = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command2.ExecuteNonQuery()

            sStr = "SELECT SCOPE_IDENTITY() AS id "
            Command2 = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader2 = Command2.ExecuteReader()
            If Reader2.HasRows() Then
                If Reader2.Read() Then
                    idMovimiento = Reader2.Item("id")
                End If
            End If

            sStr = "SELECT TOP " + GetRandomInt(1, 3).ToString + " id FROM HilamarArticulos " + _
                   "WHERE eliminado = 0 " + _
                   "ORDER BY NEWID() "
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            Do While Reader.HasRows()
                Do While Reader.Read()
                    Dim Cant As Double
                    Select Case TipoMovimiento
                        Case "IN"
                            Cant = Math.Round(GetRandomDouble(300, 900), 3)
                        Case "EG"
                            Cant = Math.Round(GetRandomDouble(50, 300), 3)
                        Case "DI"
                            Cant = Math.Round(GetRandomDouble(-50, 50), 3)
                    End Select

                    sStr = "INSERT INTO HilamarArticulosMovimientosDetalle " + _
                           "(idMovimiento, idArticulo, cantidadArticulo) VALUES (" + _
                           idMovimiento.ToString + ", " + Reader.Item("id").ToString + ", " + Cant.ToString.Replace(",", ".") + ")"
                    Command2 = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command2.ExecuteNonQuery()
                Loop
                Reader.NextResult()
            Loop
        Next

        MensajeAtencion("Proceso terminado.")
    End Sub

    Public Function GetRandomInt(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function

    Public Function GetRandomDouble(ByVal Min As Double, ByVal Max As Double) As Double
        Static Generator As System.Random = New System.Random()
        Return Generator.NextDouble() * (Max - Min) + Min
    End Function

End Class