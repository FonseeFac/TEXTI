Imports System.Data.SqlClient
Imports System.IO
Imports System.Text

Public Class frmLogueo
    'Private Sub txtLegajo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtLegajo.KeyDown
    '    If e.KeyCode = Keys.Return Then
    '        txtPassword.Select()
    '    End If
    'End Sub
    Private Sub txtLegajo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtLegajo.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtPassword.Select()
        End If
    End Sub

    Private Sub cmdCancelar_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancelar.Click
        End
    End Sub

    Private Sub frmLogueo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CargarVariables(False)
        NuevaVersionDisponible()
    End Sub
    Private Sub frmLogueo_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        If ObtengoConfigInicial() = "Sin Red" Then
            frmImpresorEtiquetas.Show()
            Me.Hide()
        ElseIf UCase(Environment.MachineName) = "PCTODISCO" Or UCase(Environment.MachineName) = "PCROSANA" Then
            Dim FormPrincipal As New frmPrincipal("S00000", "DUEÑOS", Me)
            FormPrincipal.Show()
            Me.Hide()
        Else
            lblNombreEmpleado.Text = ""
            txtLegajo.Select()
            revisoDatosInicio()
        End If
    End Sub

    Private Function ObtengoConfigInicial() As String
        Dim retorno As String = ""

        If File.Exists(Application.StartupPath + "\Config_Inicio.txt") Then
            Dim objReader As New StreamReader(Application.StartupPath + "\Config_Inicio.txt", Encoding.Default)
            Dim sLine As String = ""
            sLine = objReader.ReadLine()
            retorno = sLine
            objReader.Close()
        Else
            retorno = ""
        End If
        Return retorno
    End Function

    Private Sub revisoDatosInicio()
        If Not My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Hilamar", "LegajoInicio", Nothing) Is Nothing Then
            txtLegajo.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Hilamar", "LegajoInicio", Nothing).ToString
            muestroDatosDelEmpleado()
            txtPassword.Select()
        End If
    End Sub
    Private Sub guardarDatosInicio()
        'Si no esta, lo creo
        If Not My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Hilamar", "LegajoInicio", Nothing) Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("HKEY_CURRENT_USER\Software\Hilamar")
        End If
        ' guardo el nuevo valor
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Hilamar", "LegajoInicio", txtLegajo.Text)

    End Sub

    Private Sub txtLegajo_LostFocus(sender As Object, e As System.EventArgs) Handles txtLegajo.LostFocus
        muestroDatosDelEmpleado()
    End Sub

    Private Sub muestroDatosDelEmpleado()

        txtLegajo.Text = AcomodarLegajo(txtLegajo.Text, "S")
        lblNombreEmpleado.Text = DescripcionLegajo(txtLegajo.Text)

    End Sub

    'Private Sub txtPassword_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
    '    If e.KeyCode = Keys.Return Then
    '        e.Handled = True
    '        VerificarAcceso()
    '    End If
    'End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
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
                    Dim FormPrincipal As New frmPrincipal(txtLegajo.Text, Reader.Item("Categoria").ToString, Me)
                    FormPrincipal.Show()
                    Me.Hide()
                Else
                    MensajeCritico("Clave incorrecta. Verifique.")
                    txtPassword.Select()
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

End Class