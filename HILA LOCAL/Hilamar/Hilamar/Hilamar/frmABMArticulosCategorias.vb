Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmABMArticulosCategorias

    Private Sub fmrABMArticulosCategorias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarCombos()
    End Sub

    Private Sub CargarCombos()
        Dim cmd As New SqlCommand
        Dim rd As SqlDataReader
        Dim sStr As String

        cmbCategoriaActual.Items.Clear()
        cmbCategoriaAEliminar.Items.Clear()

        sStr = "SELECT nombreCategoria FROM dbo.Hilamararticuloscategorias "
        sStr += "WHERE eliminado = 0"
        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        rd = cmd.ExecuteReader()

        Do While rd.HasRows
            Do While rd.Read()
                cmbCategoriaActual.Items.Add(rd.Item("nombreCategoria"))
                cmbCategoriaAEliminar.Items.Add(rd.Item("nombreCategoria"))
            Loop
            rd.NextResult()
        Loop
    End Sub

    Private Sub tcCategorías_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tcCategorías.SelectedIndexChanged
        CargarCombos()
    End Sub

    Private Sub btnAgregarCategoria_Click(sender As Object, e As EventArgs) Handles btnAgregarCategoria.Click
        Dim cmd As New SqlCommand
        Dim sStr, nuevaCategoria As String

        nuevaCategoria = tbNuevaCategoria.Text
        If nuevaCategoria.Length < 1 Then
            MsgBox("Ingrese un nombre de cateogría válido.")
            Exit Sub
        End If
        sStr = "INSERT INTO dbo.hilamararticuloscategorias (nombreCategoria, eliminado) "
        sStr += "VALUES ('" + nuevaCategoria + "', 0) "
        sStr += "select * from dbo.hilamararticuloscategorias"
        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        cmd.ExecuteNonQuery()

        MsgBox("Categoría creada con éxito")
        tbNuevaCategoria.Text = ""

        CargarCombos()

        tbNuevaCategoria.Text = ""
    End Sub

    Private Sub btnModificarCategoria_Click(sender As Object, e As EventArgs) Handles btnModificarCategoria.Click
        Dim cmd As New SqlCommand
        Dim sStr, nuevaCategoria As String
        Dim rta As Integer

        nuevaCategoria = tbNuevoNombre.Text
        If cmbCategoriaActual.Text = "Seleccione categoría" Then
            MsgBox("Seleccione una categoría de la lista.")
            Exit Sub
        End If
        If nuevaCategoria.Length < 1 Then
            MsgBox("Ingrese un nombre de cateogría válido.")
            Exit Sub
        End If

        rta = MsgBox("¿Está seguro que desea modificar " + cmbCategoriaActual.Text + " para cambiarlo por " + nuevaCategoria + " ?", MsgBoxStyle.YesNo)

        If rta = 7 Then
            Exit Sub
        End If

        sStr = "INSERT INTO dbo.hilamararticuloscategorias (nombreCategoria, eliminado) "
        sStr += "VALUES ('" + nuevaCategoria + "', 0) "
        sStr += "UPDATE dbo.hilamararticuloscategorias "
        sStr += "SET eliminado = 1 "
        sStr += "WHERE nombreCategoria = '" + cmbCategoriaActual.Text + "' "
        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        cmd.ExecuteNonQuery()

        MsgBox("Modificación realizada con éxito!")

        CargarCombos()

        tbNuevoNombre.Text = ""
    End Sub

    Private Sub btnEliminarCategoria_Click(sender As Object, e As EventArgs) Handles btnEliminarCategoria.Click
        Dim cmd As New SqlCommand
        Dim sStr As String
        Dim rta As Integer

        If cmbCategoriaAEliminar.Text = "Seleccione categoría" Then
            MsgBox("Seleccione una categoría de la lista.")
            Exit Sub
        End If

        rta = MsgBox("¿Está seguro que desea eliminar " + cmbCategoriaAEliminar.Text + " ?", MsgBoxStyle.YesNo)

        If rta = 7 Then
            Exit Sub
        End If

        sStr = "UPDATE dbo.hilamararticuloscategorias  "
        sStr += "SET eliminado = 1  "
        sStr += "WHERE nombreCategoria = '" + cmbCategoriaAEliminar.Text + "'"
        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        cmd.ExecuteNonQuery()

        MsgBox(cmbCategoriaAEliminar.Text + " fue eliminado con éxito!")

        CargarCombos()
    End Sub

    Private Sub btnSalirAgregar_Click(sender As Object, e As EventArgs) Handles btnSalirAgregar.Click
        Me.Close()
    End Sub

    Private Sub btnSalirModificar_Click(sender As Object, e As EventArgs) Handles btnSalirModificar.Click
        Me.Close()
    End Sub

    Private Sub btnSalirEliminar_Click(sender As Object, e As EventArgs) Handles btnSalirEliminar.Click
        Me.Close()
    End Sub

End Class