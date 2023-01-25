Imports System.Data.SqlClient

Public Class frmConfigHilamar

    Dim Command As New SqlCommand
    Dim Reader As SqlDataReader
    Dim sStr As String

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVolver.Click
        Close()
    End Sub

    Private Sub frmConfigHilamar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarMoneda()
    End Sub

    Private Sub CargarMoneda()

        txtCotizacionDolar.Text = ""

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        sStr = "SELECT * FROM HilamarMonedas where Nombre='Dolares'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                txtCotizacionDolar.Text = Reader.Item("Cotizacion").ToString
            End If
        End If

        txtCotizacionDolar.Select()

    End Sub

    Private Sub cmdGuardarCotizacionDolar_Click(sender As Object, e As EventArgs) Handles cmdGuardarCotizacionDolar.Click
        If txtCotizacionDolar.Text = "" Then
            MensajeAtencion("Debe ingresar una Cotización de Dolar.")
            Exit Sub
        End If

        If Not IsNumeric(txtCotizacionDolar.Text) Then
            MensajeAtencion("La Cotización del Dolar debe ser un número.")
            Exit Sub
        End If

        sStr = "UPDATE HilamarMonedas SET Cotizacion=" + txtCotizacionDolar.Text.Replace(",", ".") + " where Nombre='Dolares'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        MensajeInfo("La Cotización del Dolar fue modificada correctamente.")
    End Sub

End Class