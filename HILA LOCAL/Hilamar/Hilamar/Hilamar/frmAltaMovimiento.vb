Imports System.Data.SqlClient

Public Class frmAltaMovimiento

    Private LegajoLogueado, TipoMovimiento, NumeroDeposito, idStock As String
    Private bMovimientoConfirmado As Boolean = False

    Sub New(ByVal pLegLog As String, ByVal pNumDepo As Integer, ByVal pTipMov As String)
        InitializeComponent()
        TipoMovimiento = pTipMov

        LegajoLogueado = pLegLog
        NumeroDeposito = pNumDepo
    End Sub

    Private Sub frmABMMovimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If System.Environment.MachineName.ToUpper <> "COMPUTOS-LINUX" Then
            btnPrueba.Visible = False
        End If

        Select Case TipoMovimiento
            Case "IN"
                btnConfirmarMovimiento.Text = "CONFIRMAR INGRESO"
                btnConfirmarMovimiento.ForeColor = Color.FromArgb(6, 65, 20)
                Me.Text = "Alta de Ingreso"
            Case "EG"
                btnConfirmarMovimiento.Text = "CONFIRMAR EGRESO"
                btnConfirmarMovimiento.ForeColor = Color.FromArgb(177, 47, 37)
                Me.Text = "Alta de Egreso"
            Case "DI"
                btnConfirmarMovimiento.Text = "CONFIRMAR DIF. INV."
                btnConfirmarMovimiento.ForeColor = Color.FromArgb(125, 50, 0)
                Me.Text = "Alta de Diferencia de Inventario"
        End Select

        CargarCombos()

        gbDetalleMovimiento.Visible = False

        DelimitarFecha()

        ArmarDGV(dgvDetalleMovimiento)

        AjustarDimensionesForm()

        Me.CenterToScreen()
    End Sub

    Private Sub DelimitarFecha()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String
        Dim Ahora As Date = NowServer()

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT MAX(fecha) as Fecha FROM HilamarArticulosStock " + _
               "WHERE numeroDeposito = " + NumeroDeposito
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                If Date.Parse(Reader.Item("Fecha")).AddDays(1) < Ahora.AddDays(-7) Then
                    dtpFechaIngreso.MinDate = Ahora.AddDays(-7)
                Else
                    dtpFechaIngreso.MinDate = Date.Parse(Reader.Item("Fecha")).AddDays(1)
                End If
            End If
        End If

        dtpFechaIngreso.MaxDate = Ahora
    End Sub

    Private Sub ArmarDGV(ByRef dgv As DataGridView)
        LimpiarDGV(dgv)
        If dgv.Name = "dgvDetalleMovimiento" Then
            dgv.Columns.Add("idArticulo", "idArticulo")
            dgv.Columns("idArticulo").Visible = False

            dgv.Columns.Add("Categoria", "Categoría")
            dgv.Columns("Categoria").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgv.Columns("Categoria").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            dgv.Columns.Add("Articulo", "Artículo")
            dgv.Columns("Articulo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgv.Columns("Articulo").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            dgv.Columns.Add("sCantidad", "Cantidad")
            dgv.Columns("sCantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgv.Columns("sCantidad").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            dgv.Columns.Add("dCantidad", "dCantidad")
            dgv.Columns("dCantidad").Visible = False

            dgv.Columns.Add("sNuevoStock", "Nuevo Stock")
            dgv.Columns("sNuevoStock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgv.Columns("sNuevoStock").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            dgv.Columns.Add("dNuevoStock", "dNuevoStock")
            dgv.Columns("dNuevoStock").Visible = False
        End If
    End Sub

    Private Sub LimpiarDGV(ByRef dgv As DataGridView)
        dgv.Rows.Clear()
        dgv.Columns.Clear()
    End Sub

    Private Sub dtpFechaIngreso_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaIngreso.ValueChanged
        CargarCombos()
    End Sub

    Private Sub CargarCombos()
        CargarComboCategoria()
        CargarComboArticulo()
        CargarComboTipoComprobante()
    End Sub

    Private Sub CargarComboCategoria()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr, Seleccionado As String

        If cbCategoria.Items.Count > 0 Then
            Seleccionado = cbCategoria.Text
        Else
            Seleccionado = ""
        End If

        cbCategoria.Items.Clear()
        cbCategoria.Items.Add("")

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT DISTINCT nombreCategoria FROM HilamarArticulosCategorias C " + _
               "INNER JOIN HilamarArticulos A ON A.categoria = C.id " + _
               "INNER JOIN HilamarArticulosStockDetalle SD ON SD.idArticulo = A.ID " + _
               "INNER JOIN HilamarArticulosStock S ON S.ID = SD.idEnc " + _
               "WHERE C.eliminado = 0 " + _
               "AND S.fecha = (SELECT MAX(fecha) as Fecha FROM HilamarArticulosStock) " + _
               "AND S.numeroDeposito = " + NumeroDeposito + _
               "ORDER BY nombreCategoria ASC "
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

    Private Sub cbCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCategoria.SelectedIndexChanged
        CargarComboArticulo()
    End Sub

    Private Sub CargarComboArticulo()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr, FiltroCategoria, Seleccionado As String

        If cbArticulo.Items.Count > 0 Then
            Seleccionado = cbArticulo.Text
        Else
            Seleccionado = ""
        End If

        cbArticulo.Items.Clear()
        cbArticulo.Items.Add("")

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        If cbCategoria.SelectedIndex = 0 Then
            FiltroCategoria = ""
        Else
            FiltroCategoria = "AND C.nombreCategoria = '" + cbCategoria.Text + "' "
        End If

        sStr = "SELECT nombreArt FROM HilamarArticulos A " + _
               "INNER JOIN HilamarArticulosCategorias C ON A.categoria = C.id " + _
               "INNER JOIN HilamarArticulosStockDetalle SD ON SD.idArticulo = A.ID " + _
               "INNER JOIN HilamarArticulosStock S ON S.ID = SD.idEnc " + _
               "WHERE A.eliminado = 0 " + _
               "AND S.fecha = (SELECT MAX(fecha) as Fecha FROM HilamarArticulosStock) " + _
               "AND S.numeroDeposito = " + NumeroDeposito + _
               FiltroCategoria + _
               "ORDER BY nombreArt ASC "
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

    Private Sub CargarComboTipoComprobante()
        cbTipoComprobante.Items.Clear()
        cbTipoComprobante.Items.Add("")
        cbTipoComprobante.Items.Add("FACTURA")
        cbTipoComprobante.Items.Add("REMITO")
        cbTipoComprobante.SelectedIndex = 0
    End Sub

    Private Sub AjustarDimensionesForm()
        Dim iAlto = gbDatos.Location.Y + gbDatos.Height + 52
        Dim iAncho = gbDatos.Location.X + gbDatos.Width + 30

        Dim AlturaDGVComponentes = dgvDetalleMovimiento.ColumnHeadersHeight + dgvDetalleMovimiento.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + 2

        dgvDetalleMovimiento.Height = AlturaDGVComponentes

        If dgvDetalleMovimiento.RowCount > 0 Then
            Dim altoFila = dgvDetalleMovimiento.Rows(0).Height
            Dim maxAltoDgvDetalle = dgvDetalleMovimiento.ColumnHeadersHeight + altoFila * 8 + 2
            If dgvDetalleMovimiento.Height > maxAltoDgvDetalle Then
                dgvDetalleMovimiento.Height = maxAltoDgvDetalle
            End If

            btnConfirmarMovimiento.Location = New Point(btnConfirmarMovimiento.Location.X, dgvDetalleMovimiento.Location.Y + dgvDetalleMovimiento.Height + 7)
            btnEliminarFilaDetalle.Location = New Point(btnEliminarFilaDetalle.Location.X, dgvDetalleMovimiento.Location.Y + dgvDetalleMovimiento.Height + 7)
            gbDetalleMovimiento.Height = btnConfirmarMovimiento.Location.Y + btnConfirmarMovimiento.Height + 7
        End If

        Select Case True
            Case gbMovimiento.Visible
                iAlto = gbMovimiento.Location.Y + gbMovimiento.Height + 52
        End Select

        If gbDetalleMovimiento.Visible Then
            iAlto = gbDetalleMovimiento.Location.Y + gbDetalleMovimiento.Height + 52
        End If
        Me.Height = iAlto
        Me.Width = iAncho
    End Sub

    Private Sub cbArticulo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbArticulo.SelectedIndexChanged
        ObtenerDatosArticulo(cbArticulo.Text)
    End Sub

    Private Sub ObtenerDatosArticulo(ByVal NombreArt As String)
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        lblDescCodigo.Text = "-"
        lblUnidadDeMedida.Text = ""
        lblStockActual.Text = ""

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT A.id, nombreUnidad, A.observacion, puntoPedido, cantArticulo + SUM(cantidadArticulo * (CASE tipoMovimiento WHEN 'EG' THEN -1 WHEN 'IN' THEN 1 WHEN 'DI' THEN 1 END )) AS Stock  " + _
               "FROM HilamarArticulos AS A " + _
               "INNER JOIN HilamarArticulosUnidadesMedidas as UM ON A.unidadMedida = UM.id  " + _
               "INNER JOIN HilamarArticulosStockDetalle AS SD ON SD.idArticulo = A.id  " + _
               "INNER JOIN dbo.HilamarArticulosStock as SE ON SD.idEnc = SE.id  " + _
               "LEFT JOIN HilamarArticulosMovimientosDetalle as MD ON A.id = MD.idArticulo  " + _
               "LEFT JOIN HilamarArticulosMovimientos as M ON MD.idMovimiento = M.id  " + _
               "WHERE M.fecha > SE.Fecha AND SE.fecha = (SELECT MAX(fecha) from dbo.HilamarArticulosStock) AND A.eliminado = 0  " + _
               "AND SE.numeroDeposito = " + NumeroDeposito + _
               "AND M.numeroDeposito = " + NumeroDeposito + _
               "GROUP BY A.id, A.NombreArt, nombreUnidad, A.observacion, puntoPedido, cantArticulo  " + _
               "HAVING NombreArt = '" + cbArticulo.Text + "' " + _
               "UNION " + _
               "SELECT A.id, nombreUnidad, A.observacion, puntoPedido, cantArticulo AS Stock " + _
               "FROM HilamarArticulos AS A " + _
               "INNER JOIN HilamarArticulosUnidadesMedidas as UM ON A.unidadMedida = UM.id  " + _
               "INNER JOIN HilamarArticulosStockDetalle AS SD ON SD.idArticulo = A.id  " + _
               "INNER JOIN dbo.HilamarArticulosStock as S ON SD.idEnc = S.id  " + _
               "LEFT JOIN HilamarArticulosMovimientosDetalle as MD ON A.id = MD.idArticulo  " + _
               "LEFT JOIN HilamarArticulosMovimientos as M ON MD.idMovimiento = M.id  " + _
               "WHERE S.fecha = (SELECT MAX(fecha) from dbo.HilamarArticulosStock) AND A.eliminado = 0 " + _
               "AND S.numeroDeposito = " + NumeroDeposito + _
               "GROUP BY A.id, A.NombreArt, nombreUnidad, A.observacion, puntoPedido, cantArticulo  " + _
               "HAVING COUNT(MD.id) = 0 AND NombreArt = '" + cbArticulo.Text + "' " + _
               "ORDER BY A.id ASC "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                lblDescCodigo.Text = Reader.Item("observacion").ToString
                lblUnidadDeMedida.Text = Reader.Item("nombreUnidad").ToString + ":"

                If Reader.Item("Stock") < 0 Then
                    lblStockActual.ForeColor = Color.Red
                End If

                If Reader.Item("Stock") > Reader.Item("puntoPedido") Then
                    lblStockActual.ForeColor = Color.Green
                End If

                lblStockActual.Text = "Stock: " + Math.Round(Reader.Item("Stock"), 3).ToString + " " + Reader.Item("nombreUnidad").ToString
            End If
        End If
    End Sub

    ''' <summary>
    ''' Devuelve el stock actual del artículo pasado por parámetro.
    ''' </summary>
    ''' <param name="NombreArt"></param>
    ''' <returns>stock. -9999 si falla la búsqueda.</returns>
    ''' <remarks></remarks>
    Private Function ObtenerStockArticulo(ByVal NombreArt As String) As Double
        Dim Stock As Double = -9999
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT A.id, cantArticulo + SUM(cantidadArticulo * (CASE tipoMovimiento WHEN 'EG' THEN -1 WHEN 'IN' THEN 1 WHEN 'DI' THEN 1 END )) AS Stock  " + _
               "FROM HilamarArticulos AS A " + _
               "INNER JOIN HilamarArticulosStockDetalle AS SD ON SD.idArticulo = A.id  " + _
               "INNER JOIN dbo.HilamarArticulosStock as SE ON SD.idEnc = SE.id  " + _
               "LEFT JOIN HilamarArticulosMovimientosDetalle as MD ON A.id = MD.idArticulo  " + _
               "LEFT JOIN HilamarArticulosMovimientos as M ON MD.idMovimiento = M.id  " + _
               "WHERE M.fecha > SE.Fecha AND SE.fecha = (SELECT MAX(fecha) from dbo.HilamarArticulosStock) AND A.eliminado = 0  " + _
               "AND SE.numeroDeposito = " + NumeroDeposito + _
               "AND M.numeroDeposito = " + NumeroDeposito + _
               "GROUP BY A.id, A.NombreArt, A.observacion, puntoPedido, cantArticulo  " + _
               "HAVING NombreArt = '" + cbArticulo.Text + "' " + _
               "UNION " + _
               "SELECT A.id, cantArticulo AS Stock " + _
               "FROM HilamarArticulos AS A " + _
               "INNER JOIN HilamarArticulosStockDetalle AS SD ON SD.idArticulo = A.id  " + _
               "INNER JOIN dbo.HilamarArticulosStock as S ON SD.idEnc = S.id  " + _
               "LEFT JOIN HilamarArticulosMovimientosDetalle as MD ON A.id = MD.idArticulo  " + _
               "LEFT JOIN HilamarArticulosMovimientos as M ON MD.idMovimiento = M.id  " + _
               "WHERE S.fecha = (SELECT MAX(fecha) from dbo.HilamarArticulosStock) AND A.eliminado = 0 " + _
               "AND S.numeroDeposito = " + NumeroDeposito + _
               "GROUP BY A.id, A.NombreArt, A.observacion, puntoPedido, cantArticulo  " + _
               "HAVING COUNT(MD.id) = 0 AND NombreArt = '" + cbArticulo.Text + "' " + _
               "ORDER BY A.id ASC "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                Stock = Reader.Item("Stock")
            End If
        End If
        Return Stock
    End Function

    Private Sub btnCancelarDetalle_Click(sender As Object, e As EventArgs) Handles btnCancelarDetalle.Click
        LimpiarGBCargaDetalle()
        gbDatos.Enabled = True
        AjustarDimensionesForm()
    End Sub

    Private Sub LimpiarGBCargaDetalle()
        cbCategoria.SelectedIndex = 0
        cbArticulo.SelectedIndex = 0
        txtCantidadIngresada.Text = ""
    End Sub

    Private Sub cbTipoComprobante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTipoComprobante.SelectedIndexChanged
        txtNroComprobante.Enabled = Not (cbTipoComprobante.SelectedIndex = 0)
    End Sub

    Private Sub txtCantidadIngresada_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidadIngresada.KeyDown
        If e.KeyCode = Keys.Enter Then
            If ValidarDetalle() Then
                GuardarDetalle()
                txtCantidadIngresada.Text = ""
            End If
        End If
    End Sub

    Private Sub btnGuardarDetalle_Click(sender As Object, e As EventArgs) Handles btnGuardarDetalle.Click
        If ValidarDetalle() Then
            GuardarDetalle()
            txtCantidadIngresada.Text = ""
        End If
    End Sub

    Private Function ValidarDetalle() As Boolean
        If cbArticulo.SelectedIndex = 0 Then
            MensajeAtencion("Por favor, seleccione el artículo a mover.")
            cbArticulo.Focus()
            Return False
        End If

        For Each Row In dgvDetalleMovimiento.Rows
            If Row.Cells("Articulo").Value = cbArticulo.Text Then
                MensajeAtencion(cbArticulo.Text + " ya figura en la lista de articulos a mover." + vbNewLine + "En caso de ser necesario, elimine la linea y vuelva a cargar la cantidad correcta.")
                dgvDetalleMovimiento.ClearSelection()
                Row.Selected = True
                Return False
            End If
        Next

        If txtCantidadIngresada.Text = "" Then
            MensajeAtencion("Ingrese la cantidad de " + lblUnidadDeMedida.Text.Replace(":", "").ToLower + " de " + cbArticulo.Text + " a mover.")
            txtCantidadIngresada.Focus()
            Return False
        Else
            If Not IsNumeric(txtCantidadIngresada.Text.Replace(".", ",")) Then
                MensajeAtencion("La cantidad de " + lblUnidadDeMedida.Text.Replace(":", "") + " ingresada debe ser numérica." + vbNewLine + "Por favor, verifique.")
                txtCantidadIngresada.Focus()
                txtCantidadIngresada.SelectAll()
                Return False
            End If

            If TipoMovimiento <> "DI" And txtCantidadIngresada.Text.Contains("-") Then
                MensajeAtencion("La cantidad de " + lblUnidadDeMedida.Text.Replace(":", "") + " ingresada no puede ser negativa." + vbNewLine + "Sólo se especifica negativo en caso de 'Diferencia de Inventario'." + vbNewLine + "Por favor, verifique.")
                txtCantidadIngresada.Focus()
                txtCantidadIngresada.SelectAll()
                Return False
            End If

            'Recargo el stock nuevamente por si hubo algún movimiento entre la selección del articulo y la confirmación de movimiento.

            Dim dStock = ObtenerStockArticulo(cbArticulo.Text)

            If Not lblStockActual.Text.Contains(dStock.ToString) Then
                ObtenerDatosArticulo(cbArticulo.Text)
            End If

            Select Case TipoMovimiento
                Case "EG"
                    If Double.Parse(txtCantidadIngresada.Text.Replace(".", ",")) > dStock Then
                        MensajeAtencion("La cantidad de " + lblUnidadDeMedida.Text.Replace(":", "") + " ingresada no puede dejar un stock negativo." + vbNewLine + "Por favor, verifique.")
                        txtCantidadIngresada.Focus()
                        txtCantidadIngresada.SelectAll()
                        Return False
                    End If
                Case "DI"
                    If Double.Parse(txtCantidadIngresada.Text.Replace(".", ",")) + dStock < 0 Then
                        MensajeAtencion("La cantidad de " + lblUnidadDeMedida.Text.Replace(":", "") + " ingresada no puede dejar un stock negativo." + vbNewLine + "Por favor, verifique.")
                        txtCantidadIngresada.Focus()
                        txtCantidadIngresada.SelectAll()
                        Return False
                    End If
            End Select
        End If
        Return True
    End Function

    Private Sub GuardarDetalle()
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr, Row() As String

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT A.id, C.NombreCategoria FROM HilamarArticulos A " + _
               "INNER JOIN HilamarArticulosCategorias C ON A.Categoria = C.id " + _
               "WHERE A.eliminado = 0 AND nombreArt = '" + cbArticulo.Text + "' "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                Dim sCantidad = txtCantidadIngresada.Text + " " + lblUnidadDeMedida.Text.ToLower.Replace(":", "")
                Dim dCantidad = Double.Parse(txtCantidadIngresada.Text.Replace(".", ","))
                Dim dStock, dNuevoStock As Double

                dStock = Double.Parse(lblStockActual.Text.Replace("Stock: ", "").Replace(" " + lblUnidadDeMedida.Text.Replace(":", ""), ""))

                Select Case TipoMovimiento
                    Case "IN"
                        dNuevoStock = Math.Round(dStock + dCantidad, 3)
                    Case "EG"
                        dNuevoStock = Math.Round(dStock - dCantidad, 3)
                    Case "DI"
                        dNuevoStock = Math.Round(dStock + dCantidad, 3)
                End Select

                Dim sNuevoStock = dNuevoStock.ToString + " " + lblUnidadDeMedida.Text.ToLower.Replace(":", "")
                Row = {Reader.Item("id"), Reader.Item("NombreCategoria"), cbArticulo.Text, sCantidad, dCantidad, sNuevoStock, dNuevoStock}
                dgvDetalleMovimiento.Rows.Add(Row)
            End If
        Else
            MensajeAtencion("El artículo ha sido eliminado recientemente." + vbNewLine + "Por favor, verifique.")
            CargarComboArticulo()
        End If

        AjustarDimensionesForm()

        dgvDetalleMovimiento.ClearSelection()
        cbArticulo.Focus()
    End Sub

    Private Sub dgvDetalleMovimiento_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDetalleMovimiento.SelectionChanged
        btnEliminarFilaDetalle.Enabled = (dgvDetalleMovimiento.SelectedRows.Count = 1)
    End Sub

    Private Sub btnEliminarFilaDetalle_Click(sender As Object, e As EventArgs) Handles btnEliminarFilaDetalle.Click
        If dgvDetalleMovimiento.RowCount = 0 Or dgvDetalleMovimiento.SelectedRows.Count <> 1 Then Exit Sub

        dgvDetalleMovimiento.Rows.Remove(dgvDetalleMovimiento.CurrentRow)

        AjustarDimensionesForm()
        dgvDetalleMovimiento.ClearSelection()
    End Sub

    Private Sub dgvDetalleMovimiento_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvDetalleMovimiento.RowsAdded
        gbDetalleMovimiento.Visible = True
        AjustarDimensionesForm()
    End Sub

    Private Sub dgvDetalleMovimiento_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgvDetalleMovimiento.RowsRemoved
        If dgvDetalleMovimiento.RowCount = 0 Then
            gbDetalleMovimiento.Visible = False
            AjustarDimensionesForm()
        End If
    End Sub

    Private Sub btnConfirmarMovimiento_Click(sender As Object, e As EventArgs) Handles btnConfirmarMovimiento.Click
        If ValidarMovimiento() AndAlso dgvDetalleMovimiento.RowCount > 0 Then ' Se supone que si el detalle no tiene filas, el botón estaría oculto.
            If GuardarMovimiento() Then
                MensajeInfo("Movimiento cargado correctamente.")
                bMovimientoConfirmado = True
                Me.Close()
            Else
                MensajeCritico("No se pudo guardar correctamente el movimiento.")
            End If
        End If
    End Sub

    Private Function ValidarMovimiento() As Boolean
        If cbTipoComprobante.SelectedIndex <> 0 And txtNroComprobante.Text = "" Then
            MensajeAtencion("Ingrese el número de comprobante." + vbNewLine + "En caso de no corresponder, seleccione el campo vacío en 'Tipo de Comprobante'")
            txtNroComprobante.Focus()
            Return False
        End If
        If txtNroComprobante.Text <> "" AndAlso cbTipoComprobante.SelectedIndex = 0 Then
            MensajeAtencion("Se ingresó un numero de comprobante pero no se especificó el tipo." + vbNewLine + "Por favor, verifique.")
            Return False
        End If

        For Each Row As DataGridViewRow In dgvDetalleMovimiento.Rows
            Dim dStock = ObtenerStockArticulo(Row.Cells("Articulo").Value)

            Select Case TipoMovimiento
                Case "EG"
                    If dStock - Row.Cells("dCantidad").Value < 0 Then
                        MensajeAtencion("La cantidad de " + lblUnidadDeMedida.Text.Replace(":", "") + " ingresada no puede dejar un stock negativo." + vbNewLine + "Por favor, verifique.")
                        txtCantidadIngresada.Focus()
                        txtCantidadIngresada.SelectAll()
                        Return False
                    End If
                Case "DI"
                    If dStock + Row.Cells("dCantidad").Value < 0 Then
                        MensajeAtencion("La cantidad de " + lblUnidadDeMedida.Text.Replace(":", "") + " ingresada no puede dejar un stock negativo." + vbNewLine + "Por favor, verifique.")
                        txtCantidadIngresada.Focus()
                        txtCantidadIngresada.SelectAll()
                        Return False
                    End If
            End Select
        Next

        Return True
    End Function

    Private Function GuardarMovimiento()
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr, CodTipoComprobante, idMovimiento As String
        Dim bErrorDetalle As Boolean = False

        idMovimiento = ""

        Select Case cbTipoComprobante.Text
            Case "FACTURA"
                CodTipoComprobante = "FA"
            Case "REMITO"
                CodTipoComprobante = "RE"
            Case Else
                CodTipoComprobante = ""
        End Select

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "INSERT INTO HilamarArticulosMovimientos " + _
               "(fecha, movidoPor, tipoMovimiento, eliminado, nroComprobante, tipoComprobante, observaciones, numeroDeposito, fechaAuditAlta) VALUES (" + _
               "'" + dtpFechaIngreso.Value.ToString + "', " + _
               "'" + LegajoLogueado.ToString.ToUpper + " - " + Environment.MachineName.ToUpper + "', " + _
               "'" + TipoMovimiento + "', " + _
               "0, " + _
               "'" + txtNroComprobante.Text + "', " + _
               "'" + CodTipoComprobante + "', " + _
               "'" + txtObservaciones.Text + "', " + _
               "" + NumeroDeposito + ", " + _
               "GETDATE())"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        If Command.ExecuteNonQuery() = 0 Then
            Return False
        End If

        sStr = "SELECT SCOPE_IDENTITY() AS id "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                idMovimiento = Reader.Item("id")
            End If
        End If

        If idMovimiento = "" Then Return False ' No debería pasar

        For Each Row In dgvDetalleMovimiento.Rows
            Dim idArticulo = Row.Cells("idArticulo").Value.ToString
            Dim Cantidad = Row.Cells("dCantidad").Value.ToString.Replace(",", ".")
            sStr = "INSERT INTO HilamarArticulosMovimientosDetalle " + _
                   "(idMovimiento, idArticulo, cantidadArticulo) VALUES (" + _
                   idMovimiento + ", " + _
                   idArticulo + ", " + _
                   Cantidad.ToString + ")"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            If Command.ExecuteNonQuery() = 0 Then
                bErrorDetalle = True
            End If
        Next

        If bErrorDetalle Then
            MensajeCritico("No se pudo guardar correctamente el detalle del movimiento." + vbNewLine + "Por favor, verifique.")
        End If
        Return True
    End Function

    Private Sub btnPrueba_Click(sender As Object, e As EventArgs) Handles btnPrueba.Click

    End Sub

    Private Sub CorregirStocksNegativos() 'Solo para los movimientos de prueba
        Dim Command, Command2 As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr, idArticulo, idMovimiento As String

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "INSERT INTO HilamarArticulosMovimientos " + _
               "(fecha, movidoPor, tipoMovimiento, eliminado, nroComprobante, tipoComprobante, observaciones, numeroDeposito, fechaAuditAlta) VALUES (" + _
               "'20221221', " + _
               "'" + LegajoLogueado.ToString.ToUpper + " - " + Environment.MachineName.ToUpper + "', " + _
               "'DI', " + _
               "0, " + _
               "'', " + _
               "'', " + _
               "'Corrección Stocks Negativos', " + _
               "1, " + _
               "GETDATE())"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        sStr = "SELECT SCOPE_IDENTITY() AS id "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                idMovimiento = Reader.Item("id")
            End If
        End If

        sStr = "SELECT A.id, cantArticulo + SUM(cantidadArticulo * (CASE tipoMovimiento WHEN 'EG' THEN -1 WHEN 'IN' THEN 1 WHEN 'DI' THEN 1 END )) AS Stock " + _
               "FROM HilamarArticulos AS A " + _
               "INNER JOIN HilamarArticulosStockDetalle AS SD ON SD.idArticulo = A.id  " + _
               "INNER JOIN dbo.HilamarArticulosStock as SE ON SD.idEnc = SE.id  " + _
               "LEFT JOIN HilamarArticulosMovimientosDetalle as MD ON A.id = MD.idArticulo  " + _
               "LEFT JOIN HilamarArticulosMovimientos as M ON MD.idMovimiento = M.id  " + _
               "WHERE M.fecha > SE.Fecha AND SE.fecha = (SELECT MAX(fecha) from dbo.HilamarArticulosStock) AND A.eliminado = 0  " + _
               "AND SE.numeroDeposito = 1  " + _
               "AND M.numeroDeposito = 1 " + _
               "GROUP BY A.id, A.NombreArt, A.observacion, puntoPedido, cantArticulo  " + _
               "UNION " + _
               "SELECT A.id, cantArticulo AS Stock " + _
               "FROM HilamarArticulos AS A " + _
               "INNER JOIN HilamarArticulosStockDetalle AS SD ON SD.idArticulo = A.id  " + _
               "INNER JOIN dbo.HilamarArticulosStock as S ON SD.idEnc = S.id  " + _
               "LEFT JOIN HilamarArticulosMovimientosDetalle as MD ON A.id = MD.idArticulo  " + _
               "LEFT JOIN HilamarArticulosMovimientos as M ON MD.idMovimiento = M.id  " + _
               "WHERE S.fecha = (SELECT MAX(fecha) from dbo.HilamarArticulosStock) AND A.eliminado = 0 " + _
               "AND S.numeroDeposito = 1 " + _
               "GROUP BY A.id, A.NombreArt, A.observacion, puntoPedido, cantArticulo " + _
               "HAVING COUNT(MD.id) = 0 " + _
               "ORDER BY A.id ASC"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows()
            Do While Reader.Read()
                If Reader.Item("Stock") <= 0 Then
                    Dim Cant As String = (Double.Parse(Reader.Item("Stock")) * (-1) + 1000).ToString
                    idArticulo = Reader.Item("id")


                    sStr = "INSERT INTO HilamarArticulosMovimientosDetalle " + _
                           "(idMovimiento, idArticulo, cantidadArticulo) VALUES (" + _
                           idMovimiento + ", " + idArticulo + ", " + Cant.Replace(",", ".") + ")"
                    Command2 = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command2.ExecuteNonQuery()
                End If
            Loop
            Reader.NextResult()
        Loop

        MensajeAtencion("Proceso terminado.")
    End Sub

    Private Sub frmAltaMovimiento_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If (Not bMovimientoConfirmado) And dgvDetalleMovimiento.RowCount > 0 Then
            If MsgBox("¿Está seguro que desea salir sin confirmar el movimiento?" + vbNewLine + _
                      "Los datos ingresados hasta el momento se perderán definitivamente.", vbYesNo, "Hilamar") = MsgBoxResult.Yes Then
                Exit Sub
            Else
                e.Cancel = True
                cbArticulo.Select()
            End If
        End If
    End Sub
End Class