Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmCrearArticulo

    Private idArticulo As Integer

    Dim NombreDeArticulo As String
    Dim StockInicialHilamar As String
    Dim StockInicialTextilana As Integer = 0
    Dim Observaciones As String
    Dim PuntoDePedido As String
    Public frmCrearArticuloClosed As Boolean = False

    Sub New(ByVal pIdArticulo As Integer)
        InitializeComponent()

        idArticulo = pIdArticulo
    End Sub
    Private Sub CargarIndex()

        Dim Index As String = cmbIndex.Text


    End Sub

    Private Sub fmrCrearArticulo_Load(sender As Object, e As EventArgs) Handles Me.Load

        CargarCmbCategorias()
        CargarCmbUnidades()
        CargarCmbColorIndex()

        If idArticulo <> 0 Then

            CargarProveedores()
            CargarFormularioParaModificacion()
            CalcularStock()
            lblStockTotal.Visible = True
            lbltotal.Visible = True

        End If

    End Sub

    Private Sub LimpiarDGV(ByRef dgv As DataGridView)
        dgv.Rows.Clear()
        dgv.Columns.Clear()
    End Sub

    Private Sub ArmarDGV(ByRef dgv As DataGridView)
        LimpiarDGV(dgv)

        dgv.Columns.Add("PROVEEDOR/ES", "PROVEEDOR/ES")
        dgv.Columns("PROVEEDOR/ES").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgv.Columns("PROVEEDOR/ES").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        For Each colum As DataGridViewColumn In dgv.Columns

            colum.ReadOnly = True

        Next

    End Sub

    Private Sub CargarProveedores()
        Dim cmd As New SqlCommand
        Dim rd As SqlDataReader
        Dim sStr, Row() As String

        ArmarDGV(dgvProveedores)

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT NOMBRE " + _
               "FROM BASE10.dbo.CTACTES CC " + _
               "INNER JOIN HilamarArticulos_x_Proveedores as haxp on haxp.CODCTACTE = cc.CODCTACTE " + _
               "WHERE CUEPREFI='P' AND CC.CODCTACTE like '%%' AND ISNULL(SUSPENDIDOS,0)=0 AND idArticulo = '" + idArticulo.ToString + "' " + _
               "ORDER BY CC.NOMBRE "

        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        rd = cmd.ExecuteReader()

        Do While rd.HasRows
            Do While rd.Read()
                Row = {Trim(rd.Item("NOMBRE"))}
                dgvProveedores.Rows.Add(Row)
            Loop
            rd.NextResult()
        Loop
    End Sub

    Private Sub ModificarArticulo()
        Dim cmd As New SqlCommand
        Dim sStr, data() As String
        Dim rd As SqlDataReader

        Dim idCategoria As String = DirectCast(cmbCategoria.SelectedItem, KeyValuePair(Of String, String)).Key




        Dim nombre As String = tbNombreArticulo.Text
        Dim ptoPedido As String = tbPuntoPedido.Text
        Dim obs As String = tbObservación.Text
        Dim idCat As Integer = idCategoria

        'Validaciones
        If ptoPedido.Length < 1 Then
            MsgBox("Introduzca un punto de pedido para el artículo.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If IsNumeric(ptoPedido) = False Then
            MsgBox("El punto de pedido debe ser un número.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        'Fin de validaciones

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "UPDATE dbo.HilamarArticulos " + _
               "SET puntoPedido = '" + ptoPedido + "', observacion = '" + obs + "', categoria = '" + idCat.ToString + "', "

        If chkInactivo.Checked Then
            sStr += " Activo = 1 "
        End If
        If Not chkInactivo.Checked Then
            sStr += " Activo = 0 "
        End If

        sStr += "WHERE id = '" + idArticulo.ToString + "' "

        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        cmd.ExecuteNonQuery()



        sStr = "SELECT idColorIndex FROM HilamarArticulos_X_ColorIndex " + _
            "WHERE idArticulo = '" + idArticulo.ToString + "' "


        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        rd = cmd.ExecuteReader()


        Do While rd.HasRows
            Do While rd.Read()
                data = {rd.Item("idColorIndex")}
            Loop
            rd.NextResult()
        Loop


        If cmbCategoria.Text Like "COLORANTE*" And cmbIndex.Text.Length > 1 Then
            Dim idColorIndex As String = DirectCast(cmbIndex.SelectedItem, KeyValuePair(Of String, String)).Key


            If data Is Nothing Then
                sStr = "INSERT INTO dbo.hilamararticulos_x_colorindex " + _
               "VALUES ('" + idArticulo.ToString + "', '" + idColorIndex.ToString + "')"

                cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
                cmd.ExecuteNonQuery()

                MsgBox("El artículo " + nombre + " fue modificado con éxito!")

                Exit Sub
            End If

            sStr = "UPDATE dbo.HilamarArticulos_X_ColorIndex " + _
            "SET idColorIndex ='" + idColorIndex.ToString + "' " + _
            "WHERE idArticulo = '" + idArticulo.ToString + "' "

            cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
            cmd.ExecuteNonQuery()


        End If

        MsgBox("El artículo " + nombre + " fue modificado con éxito!")
        Me.Close()

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim cmd As New SqlCommand
        Dim rd As SqlDataReader
        Dim sStr As String

        If idArticulo <> 0 Then

            ModificarArticulo()
            Exit Sub

        End If

        Dim idUnidad As String = DirectCast(cmbTipoDeUnidad.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim idCategoria As String = DirectCast(cmbCategoria.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim idColorIndex As String = DirectCast(cmbIndex.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim sIdArticulo As String = ""


        NombreDeArticulo = tbNombreArticulo.Text
        StockInicialHilamar = tbStockInicialHilamar.Text
        Observaciones = tbObservación.Text
        PuntoDePedido = tbPuntoPedido.Text

        'Validaciones
        If NombreDeArticulo.Length < 1 Then
            MsgBox("Introduzca un nombre de artículo válido.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If StockInicialHilamar.Length < 1 Then
            MsgBox("Introduzca stock inicial para el artículo.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If Not IsNumeric(StockInicialHilamar) Then
            MsgBox("El stock inicial debe ser un número.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If PuntoDePedido.Length < 1 Then
            MsgBox("Introduzca un punto de pedido para el artículo.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If Not IsNumeric(PuntoDePedido) Then
            MsgBox("El punto de pedido debe ser un número.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        'Fin de validaciones

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "INSERT INTO dbo.HilamarArticulos " + _
               "VALUES ('" + NombreDeArticulo + "', " + idCategoria + ", " + idUnidad + ", '" + PuntoDePedido + "' , 0, '" + Observaciones + "', 1) "

        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        cmd.ExecuteNonQuery()

        sStr = "SELECT IDENT_CURRENT('dbo.hilamararticulos') AS 'idArticulo'"
        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        rd = cmd.ExecuteReader()

        Do While rd.HasRows
            Do While rd.Read()
                sIdArticulo = rd.Item("idArticulo")
            Loop
            rd.NextResult()
        Loop

        StockInicialHilamar = StockInicialHilamar.Replace(",", ".")

        sStr = "INSERT INTO HilamarArticulosStockDetalle " + _
               "VALUES ( '" + sIdArticulo.ToString + "' ,(SELECT TOP 1 id from HilamarArticulosStock WHERE numeroDeposito = 1 ORDER BY FECHA DESC), '" + StockInicialHilamar + "' )  " + _
               "INSERT INTO HilamarArticulosStockDetalle " + _
               "VALUES ( '" + sIdArticulo.ToString + "'  ,(SELECT TOP 1 id from HilamarArticulosStock WHERE numeroDeposito = 2 ORDER BY FECHA DESC), 0 ) " + _
               "INSERT INTO HilamarArticulosStockDetalle " + _
               "VALUES ( '" + sIdArticulo.ToString + "'  ,(SELECT TOP 1 id from HilamarArticulosStock WHERE numeroDeposito = 3 ORDER BY FECHA DESC), 0 ) "


        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        cmd.ExecuteNonQuery()

        If cmbCategoria.Text Like "COLORANTE*" And cmbIndex.Text.Length > 1 Then

            sStr = "INSERT INTO dbo.hilamararticulos_x_colorindex " + _
                "VALUES ('" + sIdArticulo.ToString + "', '" + idColorIndex.ToString + "')"

            cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
            cmd.ExecuteNonQuery()

        End If


        MsgBox("El artículo fue creado con éxito!")

    End Sub

    Private Sub CalcularStock()
        Dim cmd As New SqlCommand
        Dim rd As SqlDataReader
        Dim sStr As String

        Dim total As Decimal

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT A.id , nombreArt, nombreCategoria, nombreUnidad, A.observacion, puntoPedido, cantArticulo + SUM(cantidadArticulo * (CASE tipoMovimiento WHEN 'EG' THEN -1 WHEN 'IN' THEN 1 WHEN 'DI' THEN 1 END )) AS TOTAL " + _
               "FROM HilamarArticulos AS A " + _
               "INNER JOIN HilamarArticulosStockDetalle AS SD ON SD.idArticulo = A.id " + _
               "INNER JOIN HilamarArticulosCategorias as Cat ON A.categoria = cat.id " + _
               "INNER JOIN HilamarArticulosUnidadesMedidas as Umed ON A.unidadMedida = Umed.id " + _
               "INNER JOIN dbo.HilamarArticulosStock as SE ON SD.idEnc = SE.id " + _
               "LEFT JOIN HilamarArticulosMovimientosDetalle as MD ON A.id = MD.idArticulo " + _
               "LEFT JOIN HilamarArticulosMovimientos as M ON MD.idMovimiento = M.id " + _
               "WHERE M.fecha > SE.Fecha AND SE.fecha = (SELECT MAX(fecha) from dbo.HilamarArticulosStock) AND SE.numeroDeposito = 1 AND M.numeroDeposito = 1 AND A.eliminado = 0 AND A.id = '" + idArticulo.ToString + "' " + _
               "GROUP BY A.id, nombreArt, nombreCategoria, nombreUnidad, A.observacion, puntoPedido, cantArticulo " + _
               "UNION " + _
               "SELECT A.id , nombreArt, nombreCategoria, nombreUnidad, A.observacion, puntoPedido, cantArticulo AS TOTAL " + _
               "FROM HilamarArticulos AS A " + _
               "INNER JOIN HilamarArticulosStockDetalle AS SD ON SD.idArticulo = A.id " + _
               "INNER JOIN HilamarArticulosCategorias as Cat ON A.categoria = cat.id " + _
               "INNER JOIN HilamarArticulosUnidadesMedidas as Umed ON A.unidadMedida = Umed.id " + _
               "INNER JOIN dbo.HilamarArticulosStock as SE ON SD.idEnc = SE.id " + _
               "LEFT JOIN HilamarArticulosMovimientosDetalle as MD ON A.id = MD.idArticulo " + _
               "LEFT JOIN HilamarArticulosMovimientos as M ON MD.idMovimiento = M.id " + _
               "WHERE SE.fecha = (SELECT MAX(fecha) from dbo.HilamarArticulosStock) AND SE.numeroDeposito = 1 AND A.eliminado = 0 AND A.id = '" + idArticulo.ToString + "' " + _
               "GROUP BY A.id, nombreArt, nombreCategoria, nombreUnidad, A.observacion, puntoPedido, cantArticulo " + _
               "HAVING COUNT(MD.id) = 0 " + _
               "ORDER BY A.id ASC "

        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        rd = cmd.ExecuteReader()

        Do While rd.HasRows
            Do While rd.Read()

                total = Math.Round(Convert.ToDecimal(rd.Item("TOTAL")), 3)

            Loop
            rd.NextResult()
        Loop

        lblStockTotal.Text = total

    End Sub

    Private Sub CargarFormularioParaModificacion()
        Dim cmd As New SqlCommand
        Dim rd As SqlDataReader
        Dim sStr, nombre, uMed, obs, catNombre, nombreColor As String
        Dim ptoPedido, cat As Integer
        Dim activo As Int16
        Dim idColorIndex As Integer

        tbNombreArticulo.Enabled = False
        tbStockInicialHilamar.Enabled = False
        cmbTipoDeUnidad.Enabled = False
        chkInactivo.Visible = True

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT nombreArt, puntoPedido, nombreUnidad, nombreCategoria, categoria, observacion, NombreColor, Codigo , idColorIndex , Activo FROM dbo.HilamarArticulos " + _
               "INNER JOIN dbo.HilamarArticulosCategorias " + _
               "ON categoria = dbo.hilamarArticulosCategorias.id " + _
               "INNER JOIN dbo.HilamarArticulosUnidadesMedidas " + _
               "ON unidadMedida = dbo.HilamarArticulosUnidadesMedidas.id " + _
               "full outer join dbo.HilamarArticulos_X_ColorIndex XCI  on dbo.HilamarArticulos.id = xci.idArticulo " + _
               "full outer join dbo.HilamarArticulosColorIndex CI on XCI.idColorIndex = CI.id " + _
               "WHERE dbo.hilamararticulos.id = '" + idArticulo.ToString + "' "

        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        rd = cmd.ExecuteReader()

        Do While rd.HasRows
            Do While rd.Read()

                nombre = rd.Item("nombreArt")
                ptoPedido = rd.Item("puntoPedido")
                uMed = rd.Item("nombreUnidad")
                cat = rd.Item("categoria")
                catNombre = rd.Item("nombreCategoria")
                obs = rd.Item("observacion")
                activo = rd.Item("Activo")

                If rd.Item("idColorIndex").Equals(DBNull.Value) Then
                    idColorIndex = 1
                Else
                    idColorIndex = rd.Item("idColorIndex")
                End If

                If rd.Item("Codigo").Equals(DBNull.Value) Then

                Else
                    nombreColor = rd.Item("Codigo") + " - " + rd.Item("NombreColor")
                End If



            Loop
            rd.NextResult()
        Loop

        If activo = 1 Then
            chkInactivo.Checked = True
        End If



        tbPuntoPedido.Text = ptoPedido
        tbNombreArticulo.Text = nombre
        tbObservación.Text = obs
        cmbTipoDeUnidad.Text = uMed
        cmbCategoria.SelectedValue = cat
        cmbCategoria.Text = catNombre
        cmbIndex.SelectedValue = idColorIndex
        cmbIndex.Text = nombreColor



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
        cmbIndex.DataSource = New BindingSource(comboSource, Nothing)
        cmbIndex.DisplayMember = "Value"
        cmbIndex.ValueMember = "Key"
    End Sub


    Private Sub CargarCmbCategorias()
        Dim cmd As New SqlCommand
        Dim rd As SqlDataReader
        Dim sStr As String

        Dim comboSource As New Dictionary(Of String, String)()

        sStr = "SELECT id, nombreCategoria FROM dbo.HilamarArticulosCategorias"
        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        rd = cmd.ExecuteReader()

        Do While rd.HasRows
            Do While rd.Read()
                comboSource.Add(rd.Item("id"), rd.Item("nombreCategoria"))

            Loop
            rd.NextResult()
        Loop
        cmbCategoria.DataSource = New BindingSource(comboSource, Nothing)
        cmbCategoria.DisplayMember = "Value"
        cmbCategoria.ValueMember = "Key"
    End Sub

    Private Sub CargarCmbUnidades()
        Dim cmd As New SqlCommand
        Dim rd As SqlDataReader
        Dim sStr As String

        Dim comboSource As New Dictionary(Of String, String)()

        frmCrearArticuloClosed = True

        sStr = "SELECT id, nombreUnidad FROM dbo.HilamarArticulosUnidadesMedidas"
        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        rd = cmd.ExecuteReader()

        Do While rd.HasRows
            Do While rd.Read()
                comboSource.Add(rd.Item("id"), rd.Item("nombreUnidad"))
            Loop
            rd.NextResult()
        Loop

        cmbTipoDeUnidad.DataSource = New BindingSource(comboSource, Nothing)
        cmbTipoDeUnidad.DisplayMember = "Value"
        cmbTipoDeUnidad.ValueMember = "Key"
    End Sub

    Private Sub btnAgregarProveedor_Click(sender As Object, e As EventArgs) Handles btnModificarProveedores.Click
        Dim frmProveedores As New frmABMProveedores_Articulo(idArticulo)

        If FormAbierto(frmProveedores) Then
            Exit Sub
        End If

        frmProveedores.ShowDialog()

        CargarProveedores()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub chkInactivo_CheckedChanged(sender As Object, e As EventArgs) Handles chkInactivo.CheckedChanged
        If chkInactivo.Checked Then
            chkInactivo.BackColor = Color.GreenYellow
        Else
            chkInactivo.BackColor = Color.LightBlue
        End If
    End Sub

    Private Sub cmbCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoria.SelectedIndexChanged
        If cmbCategoria.Text Like "COLORANTE*" Then
            gbIndexColor.Visible = True
        Else
            gbIndexColor.Visible = False
            cmbIndex.Text = ""
        End If
    End Sub

End Class