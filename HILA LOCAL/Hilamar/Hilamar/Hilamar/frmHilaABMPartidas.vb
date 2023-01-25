Imports System.Data.SqlClient

Public Class frmHilaABMPartidas
    Dim IdPartida, CodPartida As String

    Dim ColHiladosAgregar, ColHiladosEditar As New Collection

    Private Sub CargarListadoDePartidas()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        Dim AuxStock As Double
        Dim Observacion, NoTieneAlta As String
        Dim FechaAlta As Date
        Dim esCommoditie As Integer

        Dim row() As String

        LimpiarDGV()
        ArmarDGV()

        sStr = "SELECT ISNULL(FECHASTOCKDESDE,'') AS FECHASTOCKDESDE,ISNULL(FECHASTOCKHASTA,getdate()) AS FECHASTOCKHASTA, ISNULL(COLORCONO,'') AS COLORCONO, ISNULL(PARTIDAORIGEN,'') AS PARTIDAORIGEN"
        sStr = sStr + ", ("
        sStr = sStr + "SELECT ISNULL(SUM(KILOS * (CASE E.TipoMov WHEN 'I' THEN 1 WHEN 'E' THEN -1 WHEN 'DI' THEN 1 WHEN 'C' THEN -1 END )),0) AS STOCKMOV "
        sStr = sStr + "FROM HilamarHiladoStockEncMov E INNER JOIN HilamarHiladoStockDetMov D ON E.NroRemito = D.NroRemito AND E.TipoMov = D.TipoMov "
        sStr = sStr + "WHERE Isnull(E.Eliminado,0) = 0 AND Isnull(D.Eliminado,0) = 0 AND E.Fecha > = ISNULL(H.FechaStockDesde,'19000101') AND E.Fecha < = ISNULL(H.FechaStockHasta,GETDATE())"
        sStr = sStr + "AND D.PARTIDA = H.Partida "
        sStr = sStr + ") as MOVIMIENTOS "
        sStr = sStr + ",* "
        sStr = sStr + " FROM HilamarHiladoStock H INNER JOIN HilamarTipoHiladoPartidas T ON H.Codtipohilado = T.Codigo "
        sStr = sStr + " WHERE H.Eliminado = 0 and FechaStockHasta is null "
        If txtFiltroPartida.Text <> "" Then
            sStr = sStr + " and H.Partida like '%" + txtFiltroPartida.Text + "%' "
        End If
        If txtFiltroHilado.Text <> "" Then
            sStr = sStr + " and H.Codtipohilado like '%" + txtFiltroHilado.Text + "%' "
        End If
        sStr = sStr + "order by Codtipohilado,Partida"

        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                AuxStock = Reader.Item("KILOS") + Reader.Item("MOVIMIENTOS")
                If IsDBNull(Reader.Item("Observacion")) Then
                    Observacion = ""
                Else
                    Observacion = Reader.Item("Observacion").ToString
                End If

                If IsDBNull(Reader.Item("FECHAALTAPARTIDA")) Then
                    NoTieneAlta = "SIN FECHA"
                    row = {Reader.Item("Id"), Reader.Item("PARTIDA"), Reader.Item("CODTIPOHILADO"), Reader.Item("COLOR"), AuxStock, Reader.Item("KILOS"), Reader.Item("COLORCONO"), _
                       Reader.Item("PARTIDAORIGEN"), Reader.Item("DESCRIPCION"), Reader.Item("FECHASTOCKDESDE"), Reader.Item("FECHASTOCKHASTA"), Reader.Item("ESDISCONTINUADA"), Observacion, NoTieneAlta}
                Else
                    FechaAlta = Reader.Item("FECHAALTAPARTIDA")
                    row = {Reader.Item("Id"), Reader.Item("PARTIDA"), Reader.Item("CODTIPOHILADO"), Reader.Item("COLOR"), AuxStock, Reader.Item("KILOS"), Reader.Item("COLORCONO"), _
                       Reader.Item("PARTIDAORIGEN"), Reader.Item("DESCRIPCION"), Reader.Item("FECHASTOCKDESDE"), Reader.Item("FECHASTOCKHASTA"), Reader.Item("ESDISCONTINUADA"), Observacion, Reader.Item("FECHAALTAPARTIDA")}
                End If
                If rbFiltroStockConStock.Checked Then
                    If (AuxStock) > 0 Then
                        dgvPartidas.Rows.Add(row)
                    End If
                ElseIf rbFiltroStockSinStock.Checked Then
                    If (AuxStock) <= 0 Then
                        dgvPartidas.Rows.Add(row)
                    End If
                Else
                    dgvPartidas.Rows.Add(row)
                End If

            Loop
            Reader.NextResult()
        Loop

        'cuando cargo o recargo el listado limpio el IdPartida para que no quede con valores viejos
        IdPartida = ""
        CodPartida = ""
    End Sub

    Private Sub LimpiarDGV()
        dgvPartidas.Rows.Clear()
        dgvPartidas.Columns.Clear()
    End Sub

    Private Sub ArmarDGV()
        dgvPartidas.Columns.Add("ID", "ID")
        dgvPartidas.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvPartidas.Columns("ID").Visible = False
        dgvPartidas.Columns.Add("PARTIDA", "PARTIDA")
        dgvPartidas.Columns("PARTIDA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPartidas.Columns("PARTIDA").Width = 95
        dgvPartidas.Columns.Add("CODHILADO", "CODHILADO")
        dgvPartidas.Columns("CODHILADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPartidas.Columns("CODHILADO").Width = 100
        dgvPartidas.Columns.Add("COLOR", "COLOR")
        dgvPartidas.Columns("COLOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPartidas.Columns("COLOR").Width = 140
        dgvPartidas.Columns.Add("STOCK", "STOCK")
        dgvPartidas.Columns("STOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvPartidas.Columns("STOCK").Width = 85
        dgvPartidas.Columns.Add("KILOS", "KILOS")
        dgvPartidas.Columns("KILOS").Visible = False
        dgvPartidas.Columns.Add("COLORCONO", "COLORCONO")
        dgvPartidas.Columns("COLORCONO").Visible = False
        dgvPartidas.Columns.Add("PARTIDAORIGEN", "PARTIDAORIGEN")
        dgvPartidas.Columns("PARTIDAORIGEN").Visible = False
        dgvPartidas.Columns.Add("NOMBREHILADO", "NOMBREHILADO")
        dgvPartidas.Columns("NOMBREHILADO").Visible = False
        dgvPartidas.Columns.Add("FECHASTOCKDESDE", "FECHASTOCKDESDE")
        dgvPartidas.Columns("FECHASTOCKDESDE").Visible = False
        dgvPartidas.Columns.Add("FECHASTOCKHASTA", "FECHASTOCKHASTA")
        dgvPartidas.Columns("FECHASTOCKHASTA").Visible = False
        dgvPartidas.Columns.Add("ESDISCONTINUADA", "ESDISCONTINUADA")
        dgvPartidas.Columns("ESDISCONTINUADA").Visible = False
        dgvPartidas.Columns.Add("OBSERVACION", "OBSERVACION")
        dgvPartidas.Columns("OBSERVACION").Visible = False
        dgvPartidas.Columns.Add("FECHAALTAPARTIDA", "FECHAALTAPARTIDA")
        dgvPartidas.Columns("FECHAALTAPARTIDA").Visible = False
        

        dgvPartidas.Font = New Font("Arial", 10)

    End Sub

    Private Function ValidarAlta() As Boolean
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        On Error GoTo ErrValidar

        If txtAgregarPartida.Text = "" Then
            MensajeCritico("El código de Partida no puede estar vacío.")
            ValidarAlta = False
            Exit Function
        End If
        If txtAgregarColor.Text = "" Then
            MensajeCritico("El color no puede estar vacío.")
            ValidarAlta = False
            Exit Function
        End If

        If cmbAgregarHilado.SelectedIndex < 0 Then
            MensajeCritico("Debe seleccionar un Hilado.")
            ValidarAlta = False
            Exit Function
        End If


        sStr = "SELECT count(*) as Cantidad FROM HilamarHiladoStock WHERE Partida = '" + txtAgregarPartida.Text + "' and Eliminado = 0 "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                If Reader.Item("Cantidad") > 0 Then

                    'controlo que aun no tenga stock, porque si tiene stock, primero debe agotarla, para luego si poder cerrarla
                    If HilamarObtengoStockActualPartida(txtAgregarPartida.Text, Now) > 0 Then
                        MensajeCritico("El código de Partida ya existe y tiene stock. Primero debe agotar la Partida existente, para luego poder reutilizar el código.")
                        ValidarAlta = False
                        Exit Function
                    End If

                    Dim respuesta As Integer
                    respuesta = MsgBox("La Partida " + txtAgregarPartida.Text + " ya existe. " + _
                    Chr(10) + "¿Desea dar por cerrada la partida actual y comenzar con una nueva partida?", vbYesNoCancel, "Textilana S. A.")
                    If respuesta = vbYes Then
                        'si es si, sigo adelante con la validacion porque entonces si quiere dar de alta cerrando la partida actual
                        'asi que updateo la fechahasta de la partida que existe para que la nueva tenga fechadesde a partir de hoy

                        sStr = "UPDATE HilamarHiladoStock SET FechaStockHasta = getdate()-1 WHERE Partida = '" + txtAgregarPartida.Text + "' and Eliminado = 0 and FechaStockHasta is null"
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()

                    Else
                        'si es no o cancela, no hago el alta
                        ValidarAlta = False
                        Exit Function
                    End If
                End If
            End If
        End If

        ValidarAlta = True
        Exit Function
ErrValidar:
        ValidarAlta = False
        MensajeAtencion("Error al validar el Alta." + Chr(10) + Err.Description)
    End Function

    Private Function ValidarModifica() As Boolean
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        On Error GoTo ErrValidar

        If txtEditarPartida.Text = "" Then
            MensajeCritico("El código de Partida no puede estar vacío.")
            ValidarModifica = False
            Exit Function
        End If
        If txtEditarColor.Text = "" Then
            MensajeCritico("El color no puede estar vacío.")
            ValidarModifica = False
            Exit Function
        End If

        If cmbEditarHilado.SelectedIndex < 0 Then
            MensajeCritico("Debe seleccionar un Hilado.")
            ValidarModifica = False
            Exit Function
        End If

        If CodPartida <> txtEditarPartida.Text Then
            sStr = "SELECT count(*) as Cantidad FROM HilamarHiladoStock WHERE Partida = '" + txtEditarPartida.Text + "' and Eliminado = 0 "
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read() Then
                    If Reader.Item("Cantidad") > 0 Then
                        MensajeCritico("La Partida ya existe, verifique.")
                        ValidarModifica = False
                        Exit Function
                    End If
                End If
            End If
        End If

        ValidarModifica = True
        Exit Function
ErrValidar:
        ValidarModifica = False
        MensajeAtencion("Error al validar la Modificación de la Partida." + Chr(10) + Err.Description)
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub CargarListadeHilados()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        cmbAgregarHilado.Items.Clear()
        ColHiladosAgregar.Clear()
        cmbEditarHilado.Items.Clear()
        ColHiladosEditar.Clear()

        sStr = "SELECT * FROM HilamarTipoHiladoPartidas WHERE Eliminado = 0 order by Descripcion"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                cmbAgregarHilado.Items.Add(Reader.Item("Codigo").ToString + "-" + Reader.Item("Descripcion").ToString)
                ColHiladosAgregar.Add(Reader.Item("Codigo").ToString, Reader.Item("Codigo").ToString + "-" + Reader.Item("Descripcion").ToString)
                cmbEditarHilado.Items.Add(Reader.Item("Codigo").ToString + "-" + Reader.Item("Descripcion").ToString)
                ColHiladosEditar.Add(Reader.Item("Codigo").ToString, Reader.Item("Codigo").ToString + "-" + Reader.Item("Descripcion").ToString)
            Loop
            Reader.NextResult()
        Loop

    End Sub

    Private Sub frmHilaABMPartidas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gbAgregarPartida.Top = 39
        gbAgregarPartida.Left = 629
        gbModificarPartida.Top = 39
        gbModificarPartida.Left = 629
        CargarListadeHilados()
        HabilitoListado()
        CargarListadoDePartidas()
    End Sub

    Private Sub Deshabilitolistado()
        txtFiltroHilado.Enabled = False
        txtFiltroPartida.Enabled = False
        dgvPartidas.Enabled = False
        btnAgregar.Enabled = False
        btnEditar.Enabled = False
        btnEliminar.Enabled = False
        Me.Width = 1000
        Me.CenterToScreen()
    End Sub
    Private Sub HabilitoListado()
        Me.Width = 640
        Me.CenterToScreen()
        txtFiltroHilado.Enabled = True
        txtFiltroPartida.Enabled = True
        dgvPartidas.Enabled = True
        btnAgregar.Enabled = True
        btnEditar.Enabled = True
        btnEliminar.Enabled = True
        gbAgregarPartida.Visible = False
        gbModificarPartida.Visible = False
    End Sub

    Private Sub txtFiltroPartida_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroPartida.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            CargarListadoDePartidas()
        End If
    End Sub

    Private Sub txtFiltroHilado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroHilado.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            CargarListadoDePartidas()
        End If
    End Sub

    Private Sub rbFiltroStockTodas_CheckedChanged(sender As Object, e As EventArgs) Handles rbFiltroStockTodas.CheckedChanged
        If rbFiltroStockTodas.Checked Then CargarListadoDePartidas()
    End Sub
    Private Sub rbFiltroStockSinStock_CheckedChanged(sender As Object, e As EventArgs) Handles rbFiltroStockSinStock.CheckedChanged
        If rbFiltroStockSinStock.Checked Then CargarListadoDePartidas()
    End Sub
    Private Sub rbFiltroStockConStock_CheckedChanged(sender As Object, e As EventArgs) Handles rbFiltroStockConStock.CheckedChanged
        If rbFiltroStockConStock.Checked Then CargarListadoDePartidas()
    End Sub

    '*************agregar una partida****************************************
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        DeshabilitoListado()
        gbAgregarPartida.Visible = True
        txtAgregarPartida.Select()
    End Sub

    Private Sub btnOkAgregarPartida_Click(sender As Object, e As EventArgs) Handles btnOkAgregarPartida.Click
        On Error GoTo ErrorAlta
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String
        Dim esCommoditie As Integer

        Dim FechaDesdeStock As Date = Now

        If Not ValidarAlta() Then Exit Sub

        'primero busco cual va a ser la fechastockdesde, porque no puede ser la fecha del dia, si lo hago asi y despues agregan movimientos con fechas pasadas, no los toma el stock.
        'entonces voy a buscar 
        'si ya esta: le pongo como fechadesde un dia mas de la fechahasta de la que ya esta
        'si no esta y es la primer vez, le pongo fechadesde el primer dia del mes asi toma todos los movimientos que carguen desde ese mes al menos
        sStr = "SELECT count(*) as Cantidad FROM HilamarHiladoStock WHERE Partida = '" + txtAgregarPartida.Text + "' and Eliminado = 0 "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                If Reader.Item("Cantidad") > 0 Then
                    sStr = "SELECT max(FechaStockHasta) as FechaStockHasta FROM HilamarHiladoStock WHERE Partida = '" + txtAgregarPartida.Text + "' and Eliminado = 0 "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Reader = Command.ExecuteReader()
                    If Reader.HasRows Then
                        If Reader.Read() Then
                            FechaDesdeStock = DateAdd(DateInterval.Day, 1, Reader.Item("FechaStockHasta"))
                        End If
                    End If
                Else
                    FechaDesdeStock = DateSerial(Year(Now), Month(Now), 1)
                End If
            End If
        End If

        sStr = "INSERT INTO HilamarHiladoStock (Partida, Color, CodTipoHilado, Kilos, Eliminado, Auditoria, CodColor, PCardado, FechaStockDesde, ColorCono, PartidaOrigen, EsDiscontinuada, Observacion, FechaAltaPartida) VALUES ('"
        sStr = sStr + txtAgregarPartida.Text + "','" + txtAgregarColor.Text + "'," + ColHiladosAgregar.Item(cmbAgregarHilado.Text) + "," + txtAgregarKilos.Text + ",0,'"
        sStr = sStr + "ALTA |" + Format(Now, "dd/MM/yyyy HH:mm:ss") + "','','','" + Format(FechaDesdeStock, "yyyyMMdd") + "','" + txtAgregarColorCono.Text + "','" + txtAgregarPartidaOrigen.Text + "',0"
        sStr = sStr + ",'" + txtAgregarObservacion.Text + "', '" + Format(detFechaAltaPartida.Value, "yyyyMMdd") + "')"


        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()


        


        MensajeInfo("Partida Agregada Correctamente")
        txtAgregarPartida.Text = ""
        txtAgregarColor.Text = ""
        cmbAgregarHilado.SelectedIndex = -1
        txtAgregarColorCono.Text = ""
        txtAgregarPartidaOrigen.Text = ""
        txtAgregarKilos.Text = ""
        txtAgregarObservacion.Text = ""
        CargarListadoDePartidas()
        HabilitoListado()

        Exit Sub
ErrorAlta:
        MensajeCritico("Error al ingresar la nueva partida. Verifique." + Chr(10) + Err.Description)
    End Sub

    Private Sub btnCancelarAgregarPartida_Click(sender As Object, e As EventArgs) Handles btnCancelarAgregarPartida.Click
        txtAgregarPartida.Text = ""
        txtAgregarColor.Text = ""
        cmbAgregarHilado.SelectedIndex = -1
        txtAgregarColorCono.Text = ""
        txtAgregarPartidaOrigen.Text = ""
        txtAgregarKilos.Text = ""
        txtAgregarObservacion.Text = ""
        HabilitoListado()
    End Sub

    '*****************editar una partida**************************
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If dgvPartidas.SelectedRows.Count <> 1 Then
            MensajeAtencion("Debe seleccionar una Partida para modificarla")
            Exit Sub
        End If
        IdPartida = dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("ID").Value.ToString
        CodPartida = dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("PARTIDA").Value.ToString
        txtEditarPartida.Text = dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("PARTIDA").Value.ToString
        txtEditarColor.Text = dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("COLOR").Value.ToString
        cmbEditarHilado.Text = dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("CODHILADO").Value.ToString + "-" + dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("NOMBREHILADO").Value.ToString
        txtEditarColorCono.Text = dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("COLORCONO").Value.ToString
        txtEditarPartidaOrigen.Text = dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("PARTIDAORIGEN").Value.ToString
        txtEditarPartidaObservacion.Text = dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("OBSERVACION").Value.ToString
        txtEditarKilos.Text = dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("KILOS").Value.ToString
        txtEditarKilosFechaInicial.Text = dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("FECHASTOCKDESDE").Value.ToString
        txtEditarKilosFechaFinal.Text = dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("FECHASTOCKHASTA").Value.ToString
        txtEditarStockActual.Text = HilamarObtengoStockActualPartida(CodPartida, dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("FECHASTOCKHASTA").Value)
        If dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("ESDISCONTINUADA").Value.ToString = "0" Then
            chkEsDiscontinuada.Checked = False
        Else
            chkEsDiscontinuada.Checked = True
        End If

        If dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("FECHAALTAPARTIDA").Value.ToString = "SIN FECHA" Then
            lblNoTieneFecha.Visible = True
            dtpModFechaAlta.Value = Now
        Else
            lblNoTieneFecha.Visible = False
            dtpModFechaAlta.Value = dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("FECHAALTAPARTIDA").Value
        End If

        Deshabilitolistado()
        gbModificarPartida.Visible = True
        txtEditarPartida.Select()
    End Sub

    Private Sub btnCancelarEditarPartida_Click(sender As Object, e As EventArgs) Handles btnCancelarEditarPartida.Click
        txtEditarPartida.Text = ""
        txtEditarColor.Text = ""
        cmbEditarHilado.SelectedIndex = -1
        txtEditarColorCono.Text = ""
        txtEditarPartidaOrigen.Text = ""
        txtEditarPartidaObservacion.Text = ""
        txtEditarKilos.Text = ""
        txtEditarKilosFechaInicial.Text = ""
        txtEditarStockActual.Text = ""
        HabilitoListado()
    End Sub

    Private Sub btnOkEditarPartida_Click(sender As Object, e As EventArgs) Handles btnOkEditarPartida.Click
        Dim Command As New SqlCommand
        Dim sStr As String
        If Not ValidarModifica() Then Exit Sub

        sStr = "UPDATE HilamarHiladoStock SET Partida = '" + txtEditarPartida.Text + "' "
        sStr = sStr + ",Color = '" + txtEditarColor.Text + "' "
        sStr = sStr + ",CodTipoHilado = " + ColHiladosEditar.Item(cmbEditarHilado.Text) + " "
        sStr = sStr + ",ColorCono = '" + txtEditarColorCono.Text + "' "
        sStr = sStr + ",PartidaOrigen = '" + txtEditarPartidaOrigen.Text + "' "
        sStr = sStr + ",Observacion = '" + txtEditarPartidaObservacion.Text + "' "
        sStr = sStr + ",Auditoria = 'MODIF|" + Format(Now, "dd/MM/yyyy HH:mm:ss") + "' "
        If Format(dtpModFechaAlta.Value, "yyyyMMdd") <> Format(Now, "yyyyMMdd") Then
            sStr = sStr + ",FechaAltaPartida = '" + Format(dtpModFechaAlta.Value, "yyyyMMdd") + "' "
        End If
        If chkEsDiscontinuada.Checked Then
            sStr = sStr + ",Esdiscontinuada = 1 "
        Else
            sStr = sStr + ",Esdiscontinuada = 0 "
        End If

        'If InStr(txtEditarPartida.Text, "C") >= 0 Or InStr(txtEditarPartida.Text, "CG") >= 0 Then
        '    sStr = sStr + ",esCommoditie = 1 "
        'Else
        '    sStr = sStr + ",esCommoditie = 0 "
        'End If
        sStr = sStr + "WHERE Id = " + IdPartida
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        If txtEditarNuevoStockActual.Text <> "" Then
            If IsNumeric(txtEditarNuevoStockActual.Text) Then
                If CLng(txtEditarNuevoStockActual.Text) >= 0 Then

                    Dim StockActual, StockParaLaDI As Double
                    StockActual = HilamarObtengoStockActualPartida(txtEditarPartida.Text, Now)

                    'si quiere que tenga mas stock del actual debo ingresar la DI sumando lo que falta parra llegar al total
                    'si quiere que tenga menos que el actual entonces la DI debe restar
                    StockParaLaDI = CDbl(txtEditarNuevoStockActual.Text.Replace(".", ",")) - CDbl(StockActual)

                    sStr = "INSERT INTO HilamarHiladoStockEncMov "
                    sStr = sStr + "(NroRemito, Fecha, TipoMov, AuditAlta, Observacion,RemAsociado) "
                    sStr = sStr + "VALUES "
                    sStr = sStr + "(" + "(select isnull(MAX(cast(nroremito as float)),0)+1 from HilamarHiladoStockEncMov where Isnull(Eliminado,0) = 0 AND TipoMov = 'DI')"
                    sStr = sStr + ",getdate(),'DI',getdate(),'Ajuste por DI en ABM de Partida',NULL)"
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                    'como al insertar el encabezado le sumo 1 al ultimo el detalle debe quedar referenciado al ultimo que inserte por eso no le sumo 1
                    sStr = "INSERT INTO HilamarHiladoStockDetMov "
                    sStr = sStr + "(TipoMov, NroRemito, Partida, Conos, Kilos, Observaciones) "
                    sStr = sStr + "VALUES "
                    sStr = sStr + "('DI', " + "(select isnull(MAX(cast(nroremito as float)),0) from HilamarHiladoStockEncMov where Isnull(Eliminado,0) = 0 AND TipoMov = 'DI')" + ",'"
                    sStr = sStr + txtEditarPartida.Text + "', 0," + CStr(StockParaLaDI).Replace(",", ".") + ",'')"
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()


                Else
                    MensajeCritico("El nuevo Stock no puede ser negativo. Verifique.")
                End If
            Else
                MensajeCritico("El nuevo Stock debe ser numérico. Verifique.")
            End If
        End If

        MensajeInfo("Partida Modificada Correctamente")
        CargarListadoDePartidas()
        HabilitoListado()
    End Sub

    Private Sub btnListar_Click(sender As Object, e As EventArgs) Handles btnListar.Click
        CargarListadoDePartidas()
    End Sub

    Private Sub txtAgregarPartida_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAgregarPartida.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtAgregarColor.Select()
        End If
    End Sub
    Private Sub txtAgregarColor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAgregarColor.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            cmbAgregarHilado.Select()
        End If
    End Sub
    Private Sub cmbAgregarHilado_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbAgregarHilado.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtAgregarColorCono.Select()
        End If
    End Sub
    Private Sub txtAgregarColorCono_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAgregarColorCono.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtAgregarPartidaOrigen.Select()
        End If
    End Sub
    Private Sub txtAgregarPartidaOrigen_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAgregarPartidaOrigen.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtAgregarKilos.Select()
        End If
    End Sub

    Private Sub txtAgregarPartida_LostFocus(sender As Object, e As EventArgs) Handles txtAgregarPartida.LostFocus
        txtAgregarPartida.Text = CompletarCaracteresIzquierda(txtAgregarPartida.Text, 9, "0")
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dgvPartidas.SelectedRows.Count <> 1 Then
            MensajeAtencion("Por favor, seleccione una partida a eliminar.")
            Exit Sub
        End If

        If MsgBox("¿Está seguro que desea eliminar la partida " + dgvPartidas.CurrentRow.Cells("PARTIDA").Value.ToString + "?", vbYesNoCancel, "Textilana S. A.") = MsgBoxResult.Yes Then
            IdPartida = dgvPartidas.CurrentRow.Cells("ID").Value.ToString
            EliminarPartida()
        End If
    End Sub

    Private Sub EliminarPartida()
        Dim Command As New SqlCommand
        Dim sStr As String

        sStr = "UPDATE HilamarHiladoStock SET Eliminado = 1 WHERE Id = " + IdPartida
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()
        IdPartida = ""
    End Sub

    Private Sub txtEditarPartida_Leave(sender As Object, e As EventArgs) Handles txtEditarPartida.Leave
        If txtEditarPartida.Text <> "" Then
            txtEditarPartida.Text = CompletarCaracteresIzquierda(txtEditarPartida.Text, 9, "0")
        End If
    End Sub

    
End Class