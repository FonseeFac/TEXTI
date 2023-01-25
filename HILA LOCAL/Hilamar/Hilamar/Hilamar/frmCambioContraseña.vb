Imports System.Data.SqlClient

Public Class frmCambioContraseña

    Dim Command As New SqlCommand
    Dim Reader As SqlDataReader
    Dim sStr As String

    Dim ViejaContraseña As String = vbNull

    Dim LegajoLogueado As String 'legajo de quien va a trabajar
    Sub New(ByVal parametro1 As String)
        InitializeComponent() 'es necesario que lleve esta linea
        LegajoLogueado = parametro1
    End Sub


    Public Sub Cargar()
        lblUsuario.Text = ""

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "select * from HilamarUsuarios where Legajo='" + LegajoLogueado + "'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                ViejaContraseña = Reader.Item("Clave").ToString()
                lblUsuario.Text = LegajoLogueado + "-" + DescripcionLegajo(LegajoLogueado)
            End If
        End If

        If lblUsuario.Text = "" Then
            MensajeCritico("No se han podido obtener los datos del usuario, por favor reintente.")
            Close()
        End If

        txtViejaPassword.Select()
    End Sub

    Private Sub Guardar()
        If Not Validar() Then Exit Sub
        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        sStr = "UPDATE HilamarUsuarios SET Clave = '" + txtNuevaPassword.Text + "' WHERE Legajo='" + LegajoLogueado + "'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        MensajeAtencion("Contraseña modificada correctamente.")
        Close()
    End Sub

    Private Function Validar()
        On Error GoTo ErrValidar

        If txtViejaPassword.Text <> ViejaContraseña Then
            Validar = False
            MensajeAtencion("La antigua contraseña ingresada es incorrecta. Verifique.")
            Exit Function
        End If

        If txtNuevaPassword.Text <> txtConfNuevaPassword.Text Then
            Validar = False
            MensajeAtencion("La nueva contraseña ingresada no coincide con la Confirmación. Verifique.")
            Exit Function
        End If

        Validar = True

        Exit Function
ErrValidar:
        Validar = False
        MensajeAtencion("Error al validar.")
    End Function

    Private Sub txtViejaPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtViejaPassword.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtNuevaPassword.Select()
        End If
        If e.KeyChar = Convert.ToChar(Keys.Escape) Then Close()
    End Sub
    Private Sub txtNuevaPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNuevaPassword.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtConfNuevaPassword.Select()
        End If
        If e.KeyChar = Convert.ToChar(Keys.Escape) Then Close()
    End Sub
    Private Sub txtConfNuevaPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtConfNuevaPassword.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            cmdOk.Select()
        End If
        If e.KeyChar = Convert.ToChar(Keys.Escape) Then Close()
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        Guardar()
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Close()
    End Sub
End Class