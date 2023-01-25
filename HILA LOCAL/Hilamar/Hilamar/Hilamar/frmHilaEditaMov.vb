Imports System.Data.SqlClient

Public Class frmHilaEditaMov
    Public NroRemito, TipoMov As String

    Public Sub Cargar()
        On Error GoTo ErrCargar
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String
        Dim row As String()

        If NroRemito <> "" And TipoMov <> "" Then

            LimpiarDGV()
            ArmarDGV()

            If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
            sStr = "SELECT * FROM HilamarHiladoStockEncMov WHERE NroRemito = '" + NroRemito + "' AND TipoMov='" + TipoMov + "'"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read() Then
                    dtpFecha.Value = Reader.Item("Fecha")
                    txtTipoMov.Text = TipoMov
                    txtNroRemito.Text = NroRemito
                    If TipoMov = "E" Then
                        txtNroRemito.Enabled = True
                    Else
                        txtNroRemito.Enabled = False
                    End If
                    txtObservacion.Text = Reader.Item("Observacion")
                End If
            End If

            sStr = "SELECT * "
            sStr = sStr + " FROM HilamarHiladoStockDetMov DET INNER JOIN "
            sStr = sStr + " (SELECT * FROM HilamarHiladoStock where FechaStockHasta is null) PAR ON DET.PARTIDA=PAR.PARTIDA "
            sStr = sStr + " WHERE NroRemito = '" + NroRemito + "' AND TipoMov='" + TipoMov + "'"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            Do While Reader.HasRows
                Do While Reader.Read()
                    row = {Reader.Item("PARTIDA").ToString, Reader.Item("CodTipoHilado").ToString, Reader.Item("COLOR").ToString,
                           Reader.Item("CONOS").ToString, Reader.Item("KILOS").ToString, Reader.Item("Observaciones").ToString}
                    dgvDetalleRemito.Rows.Add(row)
                Loop
                Reader.NextResult()
            Loop


            txtPartida.Select()
        Else
            MensajeCritico("El Número de Remito o el Tipo de Movimiento no se han cargado correctamente. No se puede editar el Movimiento.")
        End If

        Exit Sub
ErrCargar:
        MensajeCritico("Error al cargar el movimiento.")
    End Sub

    Private Sub LimpiarDGV()
        dgvDetalleRemito.Rows.Clear()
        dgvDetalleRemito.Columns.Clear()
    End Sub

    Private Sub ArmarDGV()
        dgvDetalleRemito.Columns.Add("PARTIDA", "PARTIDA")
        dgvDetalleRemito.Columns("PARTIDA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvDetalleRemito.Columns("PARTIDA").Width = 85
        dgvDetalleRemito.Columns.Add("HILADO", "HILADO")
        dgvDetalleRemito.Columns("HILADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvDetalleRemito.Columns("HILADO").Width = 160
        dgvDetalleRemito.Columns.Add("COLOR", "COLOR")
        dgvDetalleRemito.Columns("COLOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvDetalleRemito.Columns("COLOR").Width = 160
        dgvDetalleRemito.Columns.Add("CONOS", "CONOS")
        dgvDetalleRemito.Columns("CONOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDetalleRemito.Columns("CONOS").Width = 80
        dgvDetalleRemito.Columns.Add("KILOS", "KILOS")
        dgvDetalleRemito.Columns("KILOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDetalleRemito.Columns("KILOS").Width = 80
        dgvDetalleRemito.Columns.Add("OBSERVACION", "OBSERVACION")
        dgvDetalleRemito.Columns("OBSERVACION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvDetalleRemito.Columns("OBSERVACION").Width = 250
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Close()
    End Sub

    Private Sub dtpFecha_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            If TipoMov = "E" Then
                txtNroRemito.Select()
            Else
                txtObservacion.Select()
            End If
        End If
    End Sub

    Private Sub txtNroRemito_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroRemito.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtObservacion.Select()
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtPartida.Select()
        End If
    End Sub

    Private Sub txtPartida_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPartida.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim dato As String()
            dato = CodHiladoyHiladoyColordeUnaPartida(txtPartida.Text)
            txtHilado.Text = dato(0) + "-" + dato(1)
            txtColor.Text = dato(2)
            If txtHilado.Text <> "" Then txtConos.Select()
        ElseIf e.KeyCode = Keys.F3 Then
            ItemSeleccionado = ""
            Dim FormListado As New frmListado()
            FormListado.Pantalla = "BuscaPartida"
            FormListado.txtBuscar.Text = txtPartida.Text
            FormListado.Cargar()
            FormListado.CargarListado()
            FormListado.ShowDialog()
            If ItemSeleccionado.ToString <> "" Then
                Dim dato As String()
                dato = CodHiladoyHiladoyColordeUnaPartida(ItemSeleccionado)
                txtPartida.Text = ItemSeleccionado
                txtHilado.Text = dato(0) + "-" + dato(1)
                txtColor.Text = dato(2)
                If txtHilado.Text <> "" Then txtConos.Select()
            End If
        End If
    End Sub

    Private Sub txtPartida_TextChanged(sender As Object, e As EventArgs) Handles txtPartida.TextChanged
        '
    End Sub

    Private Sub txtPartida_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPartida.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            BuscarPartida()
        End If
    End Sub
    Private Sub BuscarPartida()
        Dim sStr As String
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "Select count(*) as  canti "
        sStr = sStr + "FROM HilamarHiladoStock "
        sStr = sStr + "WHERE Partida like '" + txtPartida.Text + "' "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Reader.Read()
        If CInt(Reader.Item("canti").ToString) = 1 Then
            Dim dato As String()
            dato = CodHiladoyHiladoyColordeUnaPartida(txtPartida.Text)
            txtHilado.Text = dato(0) + "-" + dato(1)
            txtColor.Text = dato(2)
            txtConos.Select()

        Else
            ItemSeleccionado = ""
            Dim FormListado As New frmListado()
            FormListado.Pantalla = "BuscaPartida"
            FormListado.txtBuscar.Text = txtPartida.Text
            FormListado.Cargar()
            FormListado.CargarListado()
            FormListado.ShowDialog()
            If ItemSeleccionado.ToString <> "" Then
                Dim dato As String()
                dato = CodHiladoyHiladoyColordeUnaPartida(ItemSeleccionado)
                txtPartida.Text = ItemSeleccionado
                txtHilado.Text = dato(0) + "-" + dato(1)
                txtColor.Text = dato(2)
                If txtHilado.Text <> "" Then txtConos.Select()
            End If

        End If
    End Sub

    Private Sub txtConos_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtConos.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtKilos.Select()
        End If
    End Sub

    Private Sub txtKilos_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtKilos.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtDetObservacion.Select()
        End If
    End Sub

    Private Sub txtDetObservacion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDetObservacion.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            btnOK.Select()
        End If
    End Sub

    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        agregar_linea_al_detalle()
    End Sub

    Private Sub agregar_linea_al_detalle()
        Dim row As String()
        Dim i As Integer
        Dim ya_esta As Boolean

        If txtPartida.Text = "" Or txtKilos.Text = "" Then
            MensajeAtencion("Falta ingresar algun dato. Verifique.")
            Exit Sub
        End If
        If Not IsNumeric(txtKilos.Text) Then
            MensajeAtencion("Los Kilos deben ser un número. Verifique.")
            Exit Sub
        End If
        If txtKilos.Text <> "" Then
            If IsNumeric(txtKilos.Text) Then
                ya_esta = False
                For i = 0 To dgvDetalleRemito.RowCount - 1
                    If dgvDetalleRemito.Rows(i).Cells("PARTIDA").Value.ToString = txtPartida.Text Then
                        ya_esta = True
                        Exit For
                    End If
                Next i
                If ya_esta Then
                    dgvDetalleRemito.Rows(i).Cells("KILOS").Value = CDbl(dgvDetalleRemito.Rows(i).Cells("KILOS").Value) + CDbl(txtKilos.Text)
                Else
                    row = {txtPartida.Text, txtHilado.Text, txtColor.Text, txtConos.Text, txtKilos.Text, txtDetObservacion.Text}
                    dgvDetalleRemito.Rows.Add(row)
                End If
                txtColor.Text = ""
                txtConos.Text = ""
                txtKilos.Text = ""
                txtHilado.Text = ""
                txtPartida.Text = ""
                txtDetObservacion.Text = ""
                txtPartida.Select()
            End If
        End If
    End Sub

    Private Sub dgvDetalleMovimientos_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalleRemito.KeyDown
        If e.KeyCode = Keys.Delete Then
            If dgvDetalleRemito.CurrentRow.Index >= 0 Then dgvDetalleRemito.Rows.RemoveAt(dgvDetalleRemito.CurrentRow.Index)
        End If
    End Sub
    Private Sub btnQuitarLinea_Click(sender As Object, e As EventArgs) Handles btnQuitarLinea.Click
        If dgvDetalleRemito.CurrentRow.Index >= 0 Then dgvDetalleRemito.Rows.RemoveAt(dgvDetalleRemito.CurrentRow.Index)
    End Sub

    Public Function CodHiladoyHiladoyColordeUnaPartida(ByVal Partida As String) As String()
        On Error GoTo ErrCodHiladoyHiladoyColordeUnaPartida
        Dim sStr As String
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        CodHiladoyHiladoyColordeUnaPartida = {"", "", ""}

        sStr = "SELECT ISNULL(FECHASTOCKDESDE,'') AS FECHASTOCKDESDE,ISNULL(FECHASTOCKHASTA,getdate()) AS FECHASTOCKHASTA, ISNULL(COLORCONO,'') AS COLORCONO, ISNULL(PARTIDAORIGEN,'') AS PARTIDAORIGEN"
        sStr = sStr + ",* "
        sStr = sStr + " FROM HilamarHiladoStock H INNER JOIN HilamarTipoHiladoPartidas T ON H.Codtipohilado=T.Codigo "
        sStr = sStr + " WHERE H.Eliminado=0 and H.Partida like '" + Partida + "' "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                CodHiladoyHiladoyColordeUnaPartida = {Reader.Item("CODTIPOHILADO").ToString, Reader.Item("DESCRIPCION").ToString, Reader.Item("COLOR").ToString}
            End If
        End If

        Exit Function
ErrCodHiladoyHiladoyColordeUnaPartida:
        CodHiladoyHiladoyColordeUnaPartida = {"", "", ""}
        MensajeCritico("Error al recuperar Hilado y Color de una Partida.")
    End Function


    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        If TipoMov = "E" Then
            GuardarE()
        Else
            GuardarI()
        End If
    End Sub

    '********************************************************************** GUARDAR EGRESO**********************************************************************************
    Private Sub GuardarE()
        On Error GoTo ErrGuardar
        Dim Reader As SqlDataReader
        Dim Command As New SqlCommand
        Dim sStr As String

        Dim StockActual As Double

        If Not ValidarE() Then Exit Sub

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        'primero que nada debo eliminar los ajustes por Di asociados al remito, ya que como voy a recargar el detalle, los hare de nuevo de ser necesarios
        ' para saber si hay o no asociados algun remito de ajuste busco solo por el remitoasociado
        sStr = "SELECT * FROM HilamarHiladoStockEncMov WHERE ISNULL(Eliminado,0)=0 AND TipoMov='DI' AND RemAsociado = " + NroRemito
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                'marco el detalle como eliminado
                sStr = "UPDATE HilamarHiladoStockDetMov SET Eliminado=1 WHERE NroRemito = '" + Reader.Item("NroRemito").ToString + "' AND TipoMov='" + Reader.Item("TipoMov").ToString + "'"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
                'marco el encabezado como eliminado
                sStr = "UPDATE HilamarHiladoStockEncMov SET Eliminado=1 WHERE NroRemito = '" + Reader.Item("NroRemito").ToString + "' AND TipoMov='" + Reader.Item("TipoMov").ToString + "'"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
            Loop
            Reader.NextResult()
        Loop

        'el encabezado
        sStr = "UPDATE HilamarHiladoStockEncMov "
        sStr = sStr + "SET NroRemito='" + txtNroRemito.Text + "', Fecha='" + Format(dtpFecha.Value, "yyyyMMdd") + "', Observacion='" + txtObservacion.Text + "' "
        sStr = sStr + " WHERE NroRemito = '" + NroRemito + "' AND TipoMov='" + TipoMov + "'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        'BORRO EL DETALLE Y LO RECARGO
        sStr = "DELETE HilamarHiladoStockDetMov WHERE NroRemito = '" + NroRemito + "' AND TipoMov='" + TipoMov + "'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()
        'el detalle
        For i = 0 To dgvDetalleRemito.RowCount - 1
            If dgvDetalleRemito.Rows(i).Cells("Kilos").Value > 0 Then
                'primero me traigo el stock de la partida para ver si hay suficiente para descontar
                StockActual = HilamarObtengoStockActualPartida(dgvDetalleRemito.Rows(i).Cells("PARTIDA").Value, Now)

                If dgvDetalleRemito.Rows(i).Cells("KILOS").Value > StockActual Then
                    Dim respuesta As Integer
                    respuesta = MsgBox("Los Kilos del Remito de la partida " + dgvDetalleRemito.Rows(i).Cells("PARTIDA").Value.ToString + " superan el stock actual. " + _
                    Chr(10) + "¿Desea que se realice el ajuste automático del stock necesario para poder descontar los kilos ingresados?", vbYesNoCancel, "Textilana S.A.")
                    If respuesta = vbYes Then
                        'si es si, agrego el movimiento de ajuste por la diferencia de stock para que se puedan restar esos kilos
                        sStr = "INSERT INTO HilamarHiladoStockEncMov "
                        sStr = sStr + "(NroRemito, Fecha, TipoMov, AuditAlta, Observacion,RemAsociado,Eliminado) "
                        sStr = sStr + "VALUES "
                        sStr = sStr + "(" + "(select isnull(MAX(cast(nroremito as float)),0)+1 from HilamarHiladoStockEncMov where Isnull(Eliminado,0)=0 AND TipoMov ='DI')"
                        sStr = sStr + ",'" + Format(dtpFecha.Value, "yyyyMMdd") + "','DI',getdate(),'Ajuste por DI','" + txtNroRemito.Text + "',0)"
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                        'como al insertar el encabezado le sumo 1 al ultimo el detalle debe quedar referenciado al ultimo que inserte por eso no le sumo 1
                        sStr = "INSERT INTO HilamarHiladoStockDetMov "
                        sStr = sStr + "(TipoMov, NroRemito, Partida, Conos, Kilos, Observaciones,Eliminado) "
                        sStr = sStr + "VALUES "
                        sStr = sStr + "('DI', " + "(select isnull(MAX(cast(nroremito as float)),0) from HilamarHiladoStockEncMov where Isnull(Eliminado,0)=0 AND TipoMov ='DI')" + ",'"
                        sStr = sStr + dgvDetalleRemito.Rows(i).Cells("PARTIDA").Value.ToString + "', 0,"
                        sStr = sStr + CStr(CDbl(dgvDetalleRemito.Rows(i).Cells("KILOS").Value.ToString.Replace(".", ",")) - StockActual).Replace(",", ".") + ",'',0)"
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()

                    Else
                        'si es no o cancela, no hago el ajuste y el stock quedará en negativo
                    End If
                End If

                If dgvDetalleRemito.Rows(i).Cells("CONOS").Value.ToString = "" Then dgvDetalleRemito.Rows(i).Cells("CONOS").Value = 0
                sStr = "INSERT INTO HilamarHiladoStockDetMov "
                sStr = sStr + "(TipoMov, NroRemito, Partida, Conos, Kilos, Observaciones, Eliminado) "
                sStr = sStr + "VALUES "
                sStr = sStr + "('E', '" + txtNroRemito.Text + "','"
                sStr = sStr + dgvDetalleRemito.Rows(i).Cells("PARTIDA").Value.ToString + "'," + dgvDetalleRemito.Rows(i).Cells("CONOS").Value.ToString + ","
                sStr = sStr + dgvDetalleRemito.Rows(i).Cells("KILOS").Value.ToString.Replace(",", ".") + ",'" + dgvDetalleRemito.Rows(i).Cells("OBSERVACION").Value.ToString + "', 0)"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()

            End If
        Next i

        MensajeInfo("Se ha modificado correctamente el remito de Egreso de Hilados.")
        Cargar()

        Exit Sub
ErrGuardar:
        MensajeCritico("Error al modificar el Egreso de Hilado. Verifique." + Chr(10) + Err.Description)
    End Sub

    Private Function ValidarE() As Boolean
        On Error GoTo ErrValidar
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String
        ValidarE = False
        sStr = ""

        If dgvDetalleRemito.RowCount <= 0 Then
            MensajeAtencion("Debe ingresar al menos un movimiento.")
            ValidarE = False
            Exit Function
        End If

        If txtNroRemito.Text = "" Then
            MensajeAtencion("Debe ingresar el Número de Remito.")
            ValidarE = False
            Exit Function
        End If

        'si cambio el numero de remito, controlo que el numero de remito no este ya utilizado
        If NroRemito <> txtNroRemito.Text Then
            sStr = "SELECT count(*) as CANT FROM HilamarHiladoStockEncMov WHERE Isnull(Eliminado,0)=0 AND TipoMov='E' AND NroRemito = '" + txtNroRemito.Text + "' "
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read() Then
                    If Reader.Item("CANT") > 0 Then
                        MensajeAtencion("El número de Remito ya está utilizado. Verifique.")
                        ValidarE = False
                        Exit Function
                    End If
                End If
            End If
        End If

        ValidarE = True
        Exit Function
ErrValidar:
        ValidarE = False
        MensajeCritico("Error al validar.")
    End Function

    '**********************************************************************FIN GUARDAR EGRESO**********************************************************************************

    '**********************************************************************GUARDAR INGRESO**********************************************************************************
    Private Sub GuardarI()
        On Error GoTo ErrGuardar
        Dim Reader As SqlDataReader
        Dim Command As New SqlCommand
        Dim sStr As String

        If Not ValidarI() Then Exit Sub

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        'el encabezado
        sStr = "UPDATE HilamarHiladoStockEncMov "
        sStr = sStr + "SET Fecha='" + Format(dtpFecha.Value, "yyyyMMdd") + "', Observacion='" + txtObservacion.Text + "' "
        sStr = sStr + " WHERE NroRemito = '" + NroRemito + "' AND TipoMov='" + TipoMov + "'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        'BORRO EL DETALLE Y LO RECARGO
        sStr = "DELETE HilamarHiladoStockDetMov WHERE NroRemito = '" + NroRemito + "' AND TipoMov='" + TipoMov + "'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()
        'el detalle
        For i = 0 To dgvDetalleRemito.RowCount - 1
            If dgvDetalleRemito.Rows(i).Cells("Kilos").Value > 0 Then

                sStr = "INSERT INTO HilamarHiladoStockDetMov "
                sStr = sStr + "(TipoMov, NroRemito, Partida, Conos, Kilos, Observaciones, Eliminado) "
                sStr = sStr + "VALUES "
                sStr = sStr + "('I', '" + NroRemito + "','"
                sStr = sStr + dgvDetalleRemito.Rows(i).Cells("PARTIDA").Value.ToString + "'," + "NULL" + ","
                sStr = sStr + dgvDetalleRemito.Rows(i).Cells("KILOS").Value.ToString + ",'" + dgvDetalleRemito.Rows(i).Cells("OBSERVACION").Value.ToString + "', 0)"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()

            End If
        Next i

        MensajeInfo("Se ha modificado correctamente el remito de Ingreso de Hilados.")
        Cargar()

        Exit Sub
ErrGuardar:
        MensajeCritico("Error al modificar el Ingreso de Hilado. Verifique." + Chr(10) + Err.Description)
    End Sub

    Private Function ValidarI() As Boolean
        On Error GoTo ErrValidar
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr, Item As String
        ValidarI = False
        Item = ""
        sStr = ""

        If dgvDetalleRemito.RowCount <= 0 Then
            MensajeAtencion("Debe ingresar al menos un movimiento.")
            ValidarI = False
            Exit Function
        End If

        ValidarI = True
        Exit Function
ErrValidar:
        ValidarI = False
        MensajeCritico("Error al validar.")
    End Function
    '**********************************************************************FIN GUARDAR INGRESO**********************************************************************************

End Class