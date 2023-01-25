Imports System.Data.SqlClient

Public Class frmBorrarABMIngresodeHilados
    Public Alta As Boolean
    Public Id As String

    Dim Command As New SqlCommand
    Dim Reader As SqlDataReader
    Dim sStr As String

    Dim UltimoRemitoUsado As String

    Private Sub cmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        Guardar()
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Close()
    End Sub

    Private Sub Guardar()
        Dim IddePartida As String = "NULL"
        Dim IddeMovimiento As String = "0"
        Dim respuesta As Integer

        If Not Validar() Then Exit Sub

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        If Alta Then
            'por ahora los que son para costura no crean partida en el stock, solo dejo registro del movimiento pero no hago nada mas
            If chkParaCostura.Checked = False Then
                'primero debo agregar los kilos al stock de Hilados de Textilana, asi puedo tener el id de partida para que quede asociado el movimiento con ese id de partida
                sStr = "SELECT Id,isnull(FinDePartida,0) as FinDePartida,isnull(FechaFinPartida,'') as FechaFinPartida FROM HilamarHiladoTextiStock "
                sStr = sStr + " WHERE Eliminado=0 and Terminada=0 and Partida='" + txtPartida.Text + "' and CodTipoHilado='" + txtCodHilado.Text + "'"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Reader = Command.ExecuteReader()
                If Reader.HasRows Then
                    If Reader.Read Then
                        'antes de directamente updatear el stock de la partida debo ver si esta marcado el fin de partida porque si es asi, le voy a avisar con un cartel
                        'para que decida si quere sumar a la partida que se finalizo (porque quiza finalizó por error) o si hay que crear otra nueva 
                        If Reader.Item("FinDePartida").ToString = "1" Then
                            respuesta = MsgBox("La Partida " + txtPartida.Text + " con código de hilado " + txtCodHilado.Text + " figura como finalizada el día " + Format(Reader.Item("FechaFinPartida"), "dd/MM/yyyy") + _
                                                Chr(10) + "¿Desea agregar los kilos a esa partida de todas formas?", vbYesNoCancel, "Textilana S. A.")
                            If respuesta = vbCancel Then
                                MensajeInfo("Se cancela el ingreso del movimiento.")
                                Exit Sub
                            ElseIf respuesta = vbYes Then
                                IddePartida = Reader.Item("Id").ToString
                                sStr = "UPDATE HilamarHiladoTextiStock SET "
                                sStr = sStr + " Kilos=Kilos"
                                If rbIngreso.Checked Then
                                    sStr = sStr + "+" + txtKilos.Text.Replace(",", ".")
                                Else
                                    sStr = sStr + "-" + txtKilos.Text.Replace(",", ".")
                                End If
                                ' la termino el dia anterior para que no se pisen los finales
                                sStr = sStr + ", AuditoriaModif='" + Environment.MachineName + "|" + Now.AddDays(-1).ToString + "' "
                                sStr = sStr + " WHERE Eliminado=0 and Terminada=0 and Partida='" + txtPartida.Text + "' and CodTipoHilado='" + txtCodHilado.Text + "'"
                                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                                Command.ExecuteNonQuery()
                            Else
                                'si no quiere agregar los kilos a la partida que esta activa aun pero con marca de finalizada
                                'primero termino la partida poniendola como terminada
                                sStr = "UPDATE HilamarHiladoTextiStock SET "
                                sStr = sStr + " Terminada=1, FechaTerminada=getdate() "
                                sStr = sStr + " WHERE Eliminado=0 and Terminada=0 and Partida='" + txtPartida.Text + "' and CodTipoHilado='" + txtCodHilado.Text + "'"
                                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                                Command.ExecuteNonQuery()
                                'y despues agrego una nueva
                                sStr = "INSERT INTO HilamarHiladoTextiStock (Partida, CodTipoHilado, Kilos, Color, Eliminado, AuditoriaAlta, Terminada) VALUES ('" + txtPartida.Text
                                sStr = sStr + "', '" + txtCodHilado.Text + "'"
                                If rbIngreso.Checked Then
                                    sStr = sStr + ",+" + txtKilos.Text.Replace(",", ".")
                                Else
                                    sStr = sStr + ",-" + txtKilos.Text.Replace(",", ".")
                                End If
                                sStr = sStr + ", '" + lblDatosPartida.Text + "', 0, '" + Environment.MachineName + "|" + Now.ToString + "', 0)"
                                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                                Command.ExecuteNonQuery()
                                'y despues de insertarlo agarro el id de partida asi lo asigno al movimiento luego
                                sStr = "SELECT Id FROM HilamarHiladoTextiStock "
                                sStr = sStr + " WHERE Eliminado=0 and Terminada=0 and Partida='" + txtPartida.Text + "' and CodTipoHilado='" + txtCodHilado.Text + "'"
                                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                                Reader = Command.ExecuteReader()
                                Reader.Read()
                                IddePartida = Reader.Item("Id").ToString
                            End If
                        Else
                            IddePartida = Reader.Item("Id").ToString
                            'si no tiene fin de partida directamente updateo los kilos
                            sStr = "UPDATE HilamarHiladoTextiStock SET "
                            sStr = sStr + " Kilos=Kilos"
                            If rbIngreso.Checked Then
                                sStr = sStr + "+" + txtKilos.Text.Replace(",", ".")
                            Else
                                sStr = sStr + "-" + txtKilos.Text.Replace(",", ".")
                            End If
                            sStr = sStr + ", AuditoriaModif='" + Environment.MachineName + "|" + Now.ToString + "' "
                            sStr = sStr + " WHERE Eliminado=0 and Terminada=0 and Partida='" + txtPartida.Text + "' and CodTipoHilado='" + txtCodHilado.Text + "'"
                            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                            Command.ExecuteNonQuery()
                        End If

                    End If
                Else
                    'si no figura esa partida con ese codigo de hilado, entonces creo un nuevo registro
                    sStr = "INSERT INTO HilamarHiladoTextiStock (Partida, CodTipoHilado, Kilos, Color, Eliminado, AuditoriaAlta, Terminada) VALUES ('" + txtPartida.Text
                    sStr = sStr + "', '" + txtCodHilado.Text + "'"
                    If rbIngreso.Checked Then
                        sStr = sStr + ",+" + txtKilos.Text.Replace(",", ".")
                    Else
                        sStr = sStr + ",-" + txtKilos.Text.Replace(",", ".")
                    End If
                    sStr = sStr + ", '" + lblDatosPartida.Text + "', 0, '" + Environment.MachineName + "|" + Now.ToString + "', 0)"
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                    'y despues de insertarlo agarro el id de partida asi lo asigno al movimiento luego
                    sStr = "SELECT Id FROM HilamarHiladoTextiStock "
                    sStr = sStr + " WHERE Eliminado=0 and Terminada=0 and Partida='" + txtPartida.Text + "' and CodTipoHilado='" + txtCodHilado.Text + "'"
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Reader = Command.ExecuteReader()
                    Reader.Read()
                    IddePartida = Reader.Item("Id").ToString
                End If
            End If

            'inserto el nuevo movimiento sin importar si es de costura o no
            sStr = "INSERT INTO HilamarStockTextiMovimientos (Partida, Color, CodHilado, Hilado, Fecha, Kilos, NroRemito, NroGuia, TipoMov, IdPartida, Eliminado, ParaCostura, FinPartida) VALUES "
            sStr = sStr + "('" + txtPartida.Text
            sStr = sStr + "', '" + lblDatosPartida.Text + "', '" + txtCodHilado.Text + "', '" + lblDatosHilado.Text + "', '" + Format(dtpFechaIngreso.Value, "yyyyMMdd") + "'"
            sStr = sStr + ", " + txtKilos.Text.Replace(",", ".") + ", '" + txtNroRemito.Text + "', '" + txtNroGuia.Text + "'"
            If rbIngreso.Checked Then
                sStr = sStr + ",'I'"
            Else
                sStr = sStr + ",'D'"
            End If
            sStr = sStr + "," + IddePartida + ",0"
            If chkParaCostura.Checked Then
                sStr = sStr + ", 1"
            Else
                sStr = sStr + ", 0"
            End If
            If chkFindePartida.Checked Then
                sStr = sStr + ", 1"
            Else
                sStr = sStr + ", 0"
            End If
            sStr = sStr + ")"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()

            If chkParaCostura.Checked = False Then
                ' una vez que inserte y updatie todo veo si informo fin de partida, entonces pongo el tilde
                If chkFindePartida.Checked Then
                    'agarro el id del movimiento que ingrese
                    sStr = "SELECT max(Id) as id FROM HilamarStockTextiMovimientos "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Reader = Command.ExecuteReader()
                    Reader.Read()
                    IddeMovimiento = Reader.Item("Id").ToString

                    sStr = "UPDATE HilamarHiladoTextiStock SET "
                    sStr = sStr + " FinDePartida=1 "
                    sStr = sStr + ", FechaFinPartida='" + Format(Now, "yyyyMMdd HH:mm:ss") + "' "
                    sStr = sStr + ", IdMovFinPartida=" + IddeMovimiento + " "
                    sStr = sStr + " WHERE Id=" + IddePartida
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            End If

            If txtNroRemito.Text <> "" Then
                UltimoRemitoUsado = txtNroRemito.Text
            End If
            MensajeInfo("Ingreso registrado correctamente.")
            IniciarVentana()
        Else

            If chkParaCostura.Checked = False Then
                'le saco lo que tenga afectado el stock del movimiento asi cuando lo updateo, vuelvo a updatear tambien el stock con lo que halla quedado
                'asi no tengo que andar viendo que cambio y que no
                sStr = "UPDATE HilamarHiladoTextiStock"
                sStr = sStr + " SET Kilos = "
                sStr = sStr + " CASE (Select TipoMov from HilamarStockTextiMovimientos WHERE Id=" + Id.ToString + ") "
                sStr = sStr + " WHEN 'I' THEN Kilos - (Select Kilos from HilamarStockTextiMovimientos WHERE Id=" + Id.ToString + ") "
                sStr = sStr + " WHEN 'D' THEN Kilos + (Select Kilos from HilamarStockTextiMovimientos WHERE Id=" + Id.ToString + ") "
                sStr = sStr + " End"
                sStr = sStr + " WHERE id = (Select IdPartida from HilamarStockTextiMovimientos WHERE Id=" + Id.ToString + ")"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
            End If

            sStr = "UPDATE HilamarStockTextiMovimientos SET "
            sStr = sStr + " Fecha='" + Format(dtpFechaIngreso.Value, "yyyyMMdd") + "'"
            sStr = sStr + ", Kilos=" + txtKilos.Text.Replace(",", ".") + ""
            sStr = sStr + ", NroRemito='" + txtNroRemito.Text + "'"
            sStr = sStr + ", NroGuia='" + txtNroGuia.Text + "'"
            If rbIngreso.Checked Then
                sStr = sStr + ",TipoMov='I'"
            Else
                sStr = sStr + ",TipoMov='D'"
            End If
            If chkFindePartida.Checked Then
                sStr = sStr + ", FinPartida=1 "
            Else
                sStr = sStr + ", FinPartida=0 "
            End If
            sStr = sStr + " WHERE Id=" + Id.ToString
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()

            If chkParaCostura.Checked = False Then
                'y una vez que updateo el movimiento, vuelvo a afectar el stock de esa partida
                sStr = "UPDATE HilamarHiladoTextiStock"
                sStr = sStr + " SET Kilos = "
                sStr = sStr + " CASE (Select TipoMov from HilamarStockTextiMovimientos WHERE Id=" + Id.ToString + ") "
                sStr = sStr + " WHEN 'I' THEN Kilos + (Select Kilos from HilamarStockTextiMovimientos WHERE Id=" + Id.ToString + ") "
                sStr = sStr + " WHEN 'D' THEN Kilos - (Select Kilos from HilamarStockTextiMovimientos WHERE Id=" + Id.ToString + ") "
                sStr = sStr + " End"
                sStr = sStr + ", AuditoriaModif='" + Environment.MachineName + "|" + Now.ToString + "' "
                sStr = sStr + " WHERE id = (Select IdPartida from HilamarStockTextiMovimientos WHERE Id=" + Id.ToString + ")"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()

                ' una vez que updateo todo veo si informo fin de partida, entonces pongo el tilde o lo saco de acuerdo a lo que puso
                If chkFindePartida.Checked Then
                    sStr = "UPDATE HilamarHiladoTextiStock SET "
                    sStr = sStr + " FinDePartida=1 "
                    sStr = sStr + ", FechaFinPartida='" + Format(Now, "yyyyMMdd HH:mm:ss.fff") + "' "
                    sStr = sStr + ", IdMovFinPartida=" + Id.ToString + " "
                    sStr = sStr + " WHERE Id= (Select IdPartida from HilamarStockTextiMovimientos WHERE Id=" + Id.ToString + ")"
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                Else
                    sStr = "UPDATE HilamarHiladoTextiStock SET "
                    sStr = sStr + " FinDePartida=0 "
                    sStr = sStr + ", FechaFinPartida=NULL "
                    sStr = sStr + ", IdMovFinPartida=NULL "
                    sStr = sStr + " WHERE Id= (Select IdPartida from HilamarStockTextiMovimientos WHERE Id=" + Id.ToString + ")"
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            End If

            If txtNroRemito.Text <> "" Then
                UltimoRemitoUsado = txtNroRemito.Text
            End If
            MensajeInfo("Ingreso Modificado correctamente.")
            txtPartida.Select()
        End If

    End Sub

    Private Function Validar()
        On Error GoTo ErrValidar

        If txtCodHilado.Text = "" Then
            Validar = False
            MensajeAtencion("Debe ingresar un Código de Hilado.")
            Exit Function
        End If

        If txtPartida.Text = "" Then
            Validar = False
            MensajeAtencion("Debe ingresar una Partida.")
            Exit Function
        End If

        If Not IsNumeric(txtKilos.Text) Then
            Validar = False
            MensajeAtencion("Los Kilos ingresados deben ser un número.")
            Exit Function
        End If

        If CDbl(txtKilos.Text) < 0 Then
            Validar = False
            MensajeAtencion("Los Kilos ingresados no pueden ser números negativos.")
            Exit Function
        End If

        If lblDatosPartida.Text = "" Then
            Validar = False
            MensajeAtencion("La partida ingresada no figura en las diponibles en el stock de Hilamar.")
            Exit Function
        End If

        If lblDatosHilado.Text = "" Then
            Validar = False
            MensajeAtencion("El Hilado no figura en los diponibles en el stock de Hilamar.")
            Exit Function
        End If

        Validar = True

        Exit Function
ErrValidar:
        Validar = False
        MensajeAtencion("Error al validar.")
    End Function

    Public Sub Cargar()
        If Alta Then
            IniciarVentana()
            txtPartida.Enabled = True
            txtCodHilado.Enabled = True
        Else
            CargarDatosdelIngreso()
            ' en la modificacion no permito que se cambie ni la partida ni el codigo de hilado, si quiere cambiar algo de eso entonces que elimine
            'el movimiento y lo vuelva a ingresar
            txtPartida.Enabled = False
            txtCodHilado.Enabled = False
            'tampoco permito cambiar si es o no para costura asi no me arma lio con los stock de hilados, directamente no se peude modificar eso,
            'Si quieren cambiar el movimiento de costura o no que eliminen el movimiento y lo vuelva a ingresar
            chkParaCostura.Enabled = False
        End If
    End Sub
    Private Sub IniciarVentana()
        txtPartida.Text = ""
        txtCodHilado.Text = ""
        txtKilos.Text = ""
        dtpFechaIngreso.Value = Now
        If UltimoRemitoUsado <> "" Then
            txtNroRemito.Text = UltimoRemitoUsado
        Else
            txtNroRemito.Text = ""
        End If
        txtNroGuia.Text = ""
        lblDatosPartida.Text = ""
        lblDatosHilado.Text = ""
        rbIngreso.Checked = True
        chkFindePartida.Checked = False
        chkParaCostura.Checked = False
        txtPartida.Select()
    End Sub

    Private Sub txtPartida_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPartida.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If txtPartida.Text.Length = 4 Then
                txtPartida.Text = "H" + txtPartida.Text
            End If
            If txtPartida.Text.Length <> 9 Then
                txtPartida.Text = CompletarCaracteresIzquierda(txtPartida.Text, 9, "0")
            End If
            txtCodHilado.Select()
        End If
        If e.KeyChar = Convert.ToChar(Keys.Escape) Then Close()
    End Sub
    Private Sub txtCodHilado_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodHilado.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            dtpFechaIngreso.Select()
        End If
    End Sub
    Private Sub dtpFechaIngreso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpFechaIngreso.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtKilos.Select()
        End If
    End Sub
    Private Sub txtKilos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKilos.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtNroRemito.Select()
        End If
    End Sub

    Private Sub txtNroRemito_GotFocus(sender As Object, e As EventArgs) Handles txtNroRemito.GotFocus
        txtNroRemito.SelectionStart = 0
        txtNroRemito.SelectionLength = txtNroRemito.Text.Length
    End Sub
    Private Sub txtNroRemito_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNroRemito.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtNroGuia.Select()
        End If
    End Sub
    Private Sub txtNroGuia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNroGuia.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            rbIngreso.Select()
        End If
    End Sub
    Private Sub rbIngreso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rbIngreso.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            chkParaCostura.Select()
        End If
    End Sub
    Private Sub rbDevolucion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rbDevolucion.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            chkParaCostura.Select()
        End If
    End Sub

    Private Sub chkParaCostura_GotFocus(sender As Object, e As EventArgs) Handles chkParaCostura.GotFocus
        lblFondoCheckParaCostura.Visible = True
    End Sub
    Private Sub chkParaCostura_KeyPress(sender As Object, e As KeyPressEventArgs) Handles chkParaCostura.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            chkFindePartida.Select()
        End If
    End Sub
    Private Sub chkParaCostura_LostFocus(sender As Object, e As EventArgs) Handles chkParaCostura.LostFocus
        lblFondoCheckParaCostura.Visible = False
    End Sub

    Private Sub chkFindePartida_GotFocus(sender As Object, e As EventArgs) Handles chkFindePartida.GotFocus
        lblFondoCheckFinPartida.Visible = True
    End Sub
    Private Sub chkFindePartida_KeyPress(sender As Object, e As KeyPressEventArgs) Handles chkFindePartida.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            cmdGuardar.Select()
        End If
    End Sub
    Private Sub chkFindePartida_LostFocus(sender As Object, e As EventArgs) Handles chkFindePartida.LostFocus
        lblFondoCheckFinPartida.Visible = False
    End Sub

    Private Sub txtPartida_LostFocus(sender As Object, e As EventArgs) Handles txtPartida.LostFocus
        cargarDatosdelaPartida()
    End Sub
    Private Sub cargarDatosdelaPartida()
        lblDatosPartida.Text = ""
        txtCodHilado.Text = ""
        lblDatosHilado.Text = ""

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        sStr = "SELECT * FROM HilamarHiladoStock H INNER JOIN HilamarTipoHiladoPartidas T ON H.Codtipohilado=T.Codigo "
        sStr = sStr + " WHERE Partida='" + txtPartida.Text + "'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                lblDatosPartida.Text = Reader.Item("Color").ToString
                txtCodHilado.Text = Reader.Item("CodTipoHilado").ToString
                lblDatosHilado.Text = Reader.Item("Descripcion").ToString
            End If
        End If
    End Sub
    Private Sub CargarDatosdelIngreso()
        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        sStr = "SELECT * FROM HilamarStockTextiMovimientos "
        sStr = sStr + " WHERE Id=" + Id.ToString + ""
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                txtPartida.Text = Reader.Item("Partida").ToString
                lblDatosPartida.Text = Reader.Item("Color").ToString
                txtCodHilado.Text = Reader.Item("CodHilado").ToString
                lblDatosHilado.Text = Reader.Item("Hilado").ToString
                dtpFechaIngreso.Value = Reader.Item("Fecha").ToString
                txtKilos.Text = Reader.Item("Kilos").ToString
                txtNroRemito.Text = Reader.Item("NroRemito").ToString
                txtNroGuia.Text = Reader.Item("NroGuia").ToString
                If Reader.Item("TipoMov") = "I" Then
                    rbIngreso.Checked = True
                Else
                    rbDevolucion.Checked = True
                End If
                If IsNothing(Reader.Item("ParaCostura")) Then
                    chkParaCostura.Checked = False
                Else
                    If Reader.Item("ParaCostura").ToString = "1" Then
                        chkParaCostura.Checked = True
                    Else
                        chkParaCostura.Checked = False
                    End If
                End If
            End If
        End If
        'tambien cargo si marcaron que era fin de partida
        chkFindePartida.Checked = False ' lo hago arrancar en falso y si tiene marca lo pongo en true
        sStr = "SELECT * FROM HilamarHiladoTextiStock "
        sStr = sStr + " WHERE Eliminado=0 and IdMovFinPartida=" + Id.ToString + ""
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                chkFindePartida.Checked = True
            End If
        End If

        txtPartida.Select()
    End Sub

    Private Sub txtNroRemito_TextChanged(sender As Object, e As EventArgs) Handles txtNroRemito.TextChanged

    End Sub
End Class