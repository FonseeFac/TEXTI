Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class frmABMColorIndex
    Dim idColor As Integer

    Sub New(ByVal pIdColor As Integer)
        InitializeComponent()

        idColor = pIdColor
    End Sub

    Private Sub frmABMColorIndex_Load(sender As Object, e As EventArgs) Handles Me.Load

        If idColor <> 0 And Not IsNothing(idColor) Then
            CargarColor()
        End If

    End Sub
    Private Sub CargarColor()
        Dim cmd As New SqlCommand
        Dim rd As SqlDataReader
        Dim sStr As String


        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")


        sStr = "SELECT NombreColor, Codigo FROM dbo.HilamarArticulosColorIndex " + _
               "WHERE id = '" + idColor.ToString + "' "

        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        rd = cmd.ExecuteReader()

        Do While rd.HasRows
            Do While rd.Read()
                txtNombre.Text = rd.Item("NombreColor").ToString
                txtCodigo.Text = rd.Item("Codigo").ToString
            Loop
            rd.NextResult()
        Loop

    End Sub
    Private Sub ModificarColor()

        Dim cmd As New SqlCommand
        Dim sStr As String


        Dim rta As Integer = MsgBox("¿Esta seguro que desea modificar el color a " + txtNombre.Text + " - " + txtCodigo.Text + " ?", vbYesNo)

        If rta = 7 Then
            Exit Sub
        End If

        sStr = "UPDATE dbo.HilamarArticulosColorIndex " + _
        "SET  NombreColor= '" + txtNombre.Text.ToString + "', Codigo = '" + txtCodigo.Text.ToString + "' " + _
       "WHERE id = '" + idColor.ToString + "' "

        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        cmd.ExecuteNonQuery()

    End Sub

    Private Sub CrearColor()

        Dim cmd As New SqlCommand
        Dim sStr As String


        Dim rta As Integer = MsgBox("¿Esta seguro que desea crear el color  " + txtNombre.Text + " - " + txtCodigo.Text + " ?", vbYesNo)

        If rta = 7 Then
            Exit Sub
        End If

        sStr = "INSERT INTO HilamarArticulosColorIndex " + _
                "VALUES ('" + txtCodigo.Text + "','" + txtNombre.Text + "', 0)"

        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        cmd.ExecuteNonQuery()


    End Sub


    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click

        If idColor <> 0 And Not IsNothing(idColor) Then
            ModificarColor()
        Else
            CrearColor()
        End If


    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Me.Close()

    End Sub
End Class