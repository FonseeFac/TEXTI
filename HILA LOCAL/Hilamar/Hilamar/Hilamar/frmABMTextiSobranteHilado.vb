Imports System.Data.SqlClient

Public Class frmABMTextiSobranteHilado

    Public Alta As Boolean
    Public ID As Integer
    Dim Command As New SqlCommand
    Dim Reader As SqlDataReader
    Dim sStr As String
    Dim IdPartida As String
    Dim estaTerminado As Boolean

    Dim LegajoLogueado As String 'legajo de quien va a trabajar
    Dim TipoUsuario As String ' Tipo de usuario que va a trabajar, lo voy a usar para saber que le habilito a usar y que no

    Sub New(ByVal parametro1 As String, ByVal parametro2 As String)

        InitializeComponent() 'es necesario que lleve esta linea

        LegajoLogueado = parametro1
        TipoUsuario = parametro2

    End Sub

    Public Sub Cargar()
        ' lo dejo en blanco asi cuando ingresa o carga un numero de partida se llena con el color,
        ' Y de paso me puede servir para validar porque si quere confirmar y esta vacio entonces no puede porque la partida aun no ingreso a planta o no existe 
        ' por ahora no lo voy a usar y si luego quieren que haga el control lo agrego
        estaTerminado = False
        lblDatosPartida.Text = ""
        If Not Alta Then
            If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
            sStr = "SELECT * FROM HilamarHiladoTextiStockSobrante WHERE id = " + ID.ToString
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read Then
                    txtPartida.Text = Reader.Item("Partida").ToString
                    txtKilos.Text = Reader.Item("KilosSobran").ToString
                    txtObservacion.Text = Reader.Item("Observaciones").ToString
                    If Reader.Item("Terminado").ToString = "0" Then
                        estaTerminado = False
                    Else
                        estaTerminado = True
                    End If
                    cargarDatosdelaPartida()
                End If
            End If

            ' si ya tiene observaciones cargadas por veronica, entonces la unica que las puede modificar es ella, para el resto se transforma en una ventana de consulta
            If txtObservacion.Text <> "" Then
                If TipoUsuario = "Administrador" Or TipoUsuario = "TextiAdmin" Then
                    txtPartida.Enabled = True
                    txtKilos.Enabled = True
                    txtObservacion.Enabled = True
                    cmdGuardar.Enabled = True
                Else
                    txtPartida.Enabled = False
                    txtKilos.Enabled = False
                    txtObservacion.Enabled = False
                    cmdGuardar.Enabled = False
                End If
            Else
                txtPartida.Enabled = True
                txtKilos.Enabled = True
                txtObservacion.Enabled = True
                cmdGuardar.Enabled = True
            End If
        End If

        If estaTerminado Then
            txtPartida.Enabled = False
            txtKilos.Enabled = False
            txtObservacion.Enabled = False
            cmdGuardar.Enabled = False
        End If

        txtPartida.Select()
    End Sub

    Private Sub cmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        Guardar()
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Close()
    End Sub

    Private Sub Guardar()
        If Not Validar() Then Exit Sub

        ' si no tengo idpartida lo pongo nulo para que la misma variable me sirva para grabar
        If IdPartida = "" Then IdPartida = "NULL"

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        If Alta Then
            sStr = "INSERT INTO HilamarHiladoTextiStockSobrante (Partida, KilosSobran, Observaciones, Eliminado, Terminado, AuditoriaAlta,IdHiladoTextiStock) VALUES ("
            sStr = sStr + "'" + txtPartida.Text + "', " + txtKilos.Text.Replace(",", ".") + ", '" + txtObservacion.Text + "', 0, 0"
            sStr = sStr + ", '" + Environment.MachineName + "|" + Now.ToString + "', " + IdPartida.ToString + ")"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()
            MensajeInfo("Sobrante de Hilado agregado correctamente.")
            Alta = False
            Close()
        Else 'Modificación
            sStr = "UPDATE HilamarHiladoTextiStockSobrante SET Partida = '" + txtPartida.Text + "', KilosSobran = " + txtKilos.Text.Replace(",", ".") + ""
            sStr = sStr + " , Observaciones = '" + txtObservacion.Text + "', AuditoriaModif = '" + Environment.MachineName + "|" + Now.ToString + "' "
            sStr = sStr + " , IdHiladoTextiStock = " + IdPartida.ToString
            sStr = sStr + " WHERE id = " + ID.ToString
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()

            MensajeInfo("Sobrante de Hilado modificado correctamente.")
        End If

    End Sub

    Private Function Validar()
        On Error GoTo ErrValidar

        If IdPartida = "" Then
            If MsgBox("La Partida ingresada no figura activa en Planta." + Chr(10) + _
                      "Confirma el ingreso de todas formas?", vbYesNo, "Textilana S.A.") = vbNo Then
                Validar = False
                Exit Function
            End If
        End If

        If txtKilos.Text = "" Then
            Validar = False
            MensajeAtencion("Debe ingresar una cantidad de kilos.")
            Exit Function
        End If

        If txtPartida.Text = "" Then
            Validar = False
            MensajeAtencion("Debe ingresar una partida.")
            Exit Function
        End If

        If Not IsNumeric(txtKilos.Text) Then
            Validar = False
            MensajeAtencion("Los kilos debe ser un número.")
            Exit Function
        End If

        If Alta Then
            If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
            sStr = "SELECT * FROM HilamarHiladoTextiStockSobrante WHERE Partida = '" + txtPartida.Text + "' and Eliminado=0 and Terminado=0 "
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read Then
                    Validar = False
                    MensajeAtencion("Ya existe un sobrante de hilado ingresado para esa Partida." + Chr(10) + "Modifique el existente.")
                    Exit Function
                End If
            End If
        End If

        Validar = True

        Exit Function
ErrValidar:
        Validar = False
        MensajeAtencion("Error al validar.")
    End Function

    Private Sub txtPartida_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPartida.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            AcomodoTextoPartida()
            txtKilos.Select()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            Close()
        End If
    End Sub
    Private Sub txtKilos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKilos.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtObservacion.Select()
        End If
    End Sub
    Private Sub txtObservacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            cmdGuardar.Select()
        End If
    End Sub

    Private Sub AcomodoTextoPartida()
        If txtPartida.Text.Length = 4 Then
            txtPartida.Text = "H" + txtPartida.Text
        End If
        If txtPartida.Text.Length <> 9 Then
            txtPartida.Text = CompletarCaracteresIzquierda(txtPartida.Text, 9, "0")
        End If
    End Sub

    Private Sub txtPartida_LostFocus(sender As Object, e As EventArgs) Handles txtPartida.LostFocus
        cargarDatosdelaPartida()
    End Sub
    Private Sub cargarDatosdelaPartida()
        lblDatosPartida.Text = ""
        IdPartida = ""

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        sStr = "SELECT * FROM HilamarHiladoTextiStock WHERE Eliminado=0 and Terminada=0 "
        sStr = sStr + " AND Partida='" + txtPartida.Text + "'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                IdPartida = Reader.Item("Id").ToString
                lblDatosPartida.Text = Reader.Item("Color").ToString
            End If
        End If
    End Sub

    Private Sub txtPartida_TextChanged(sender As Object, e As EventArgs) Handles txtPartida.TextChanged

    End Sub
End Class