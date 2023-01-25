Imports System.Data.SqlClient

Public Class frmCambioUsuario
    Public UsuarioOK As Boolean = False
    Public LegajoLogueado As String = ""
    Public TipoUsuario As String = ""


    Private Sub txtLegajo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLegajo.KeyDown
        If e.KeyCode = Keys.Return Then
            e.Handled = True
            txtPassword.Select()
        End If
    End Sub

    Private Sub cmdCancelar_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancelar.Click
        UsuarioOK = False
        Close()
    End Sub

    Private Sub frmCambioUsuario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtLegajo.Select()
    End Sub

    Private Sub txtLegajo_LostFocus(sender As Object, e As System.EventArgs) Handles txtLegajo.LostFocus
        txtLegajo.Text = AcomodarLegajo(txtLegajo.Text, "S")
        lblNombreEmpleado.Text = DescripcionLegajo(txtLegajo.Text)
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Return Then
            e.Handled = True
            VerificarAcceso()
        End If
    End Sub

    Private Sub VerificarAcceso()
        Dim sStr As String
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader

        sStr = "select * from HilamarUsuarios where Legajo='" + txtLegajo.Text + "'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then

                If txtPassword.Text = Reader.Item("Clave").ToString Then
                    'antes de cargar el principal dejo registro del legajo para proximos inicios
                    guardarDatosInicio()
                    UsuarioOK = True
                    LegajoLogueado = txtLegajo.Text
                    TipoUsuario = Reader.Item("Categoria").ToString
                    Me.Hide()
                Else
                    MensajeCritico("Clave incorrecta. Verifique.")
                End If
            Else
                MensajeCritico("Usuario incorrecto. Verifique.")
            End If
        Else
            MensajeCritico("Usuario incorrecto. Verifique.")
        End If

    End Sub

    Private Sub cmdOk_Click(sender As System.Object, e As System.EventArgs) Handles cmdOk.Click
        VerificarAcceso()
    End Sub

    Private Sub guardarDatosInicio()
        'Si no esta, lo creo
        If Not My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Hilamar", "LegajoInicio", Nothing) Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("HKEY_CURRENT_USER\Software\Hilamar")
        End If
        ' guardo el nuevo valor
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Hilamar", "LegajoInicio", txtLegajo.Text)

    End Sub

End Class