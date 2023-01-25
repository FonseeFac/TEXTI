Imports System.Data.SqlClient

Public Class frmRepoMovimientos
    Dim Command As New SqlCommand
    Dim Reader As SqlDataReader
    Dim sStr As String

    Public Sub Cargar()

        CargarCombo()

    End Sub

    Private Sub CargarCombo()
        cmbTipoMov.Items.Clear()
        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        sStr = "SELECT * FROM HilamarTipoMovimientos"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read
                cmbTipoMov.Items.Add(Reader.Item("Descripcion").ToString)
            Loop
            Reader.NextResult()
        Loop
        If cmbTipoMov.Items.Count > 0 Then cmbTipoMov.Text = cmbTipoMov.Items(0).ToString

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class