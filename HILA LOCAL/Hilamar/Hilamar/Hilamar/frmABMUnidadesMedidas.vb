Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmABMUnidadesMedidas

    Private Sub fmrABMUnidadesMedidas_Load(sender As Object, e As EventArgs) Handles Me.Load
        CargarCombos()
    End Sub

    Private Sub CargarCombos()
        Dim cmd As New SqlCommand
        Dim rd As SqlDataReader
        Dim sStr As String

        cmbUnidadActualModif.Items.Clear()
        cmbUnidadAEliminar.Items.Clear()

        sStr = "SELECT nombreUnidad FROM dbo.HilamarArticulosUnidadesMedidas " + _
               "WHERE eliminado = 0"
        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        rd = cmd.ExecuteReader()


        Do While rd.HasRows
            Do While rd.Read()
                cmbUnidadActualModif.Items.Add(rd.Item("nombreUnidad"))
                cmbUnidadAEliminar.Items.Add(rd.Item("nombreUnidad"))
            Loop
            rd.NextResult()
        Loop
    End Sub

    Private Sub tcUnidades_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tcUnidades.SelectedIndexChanged
        CargarCombos()
    End Sub

    Private Sub btnAgregarUnidad_Click(sender As Object, e As EventArgs) Handles btnAgregarUnidad.Click
        Dim cmd As New SqlCommand
        Dim sStr As String

        Dim nuevaUnidad As String
        nuevaUnidad = tbNuevaUnidad.Text
        If nuevaUnidad.Length < 1 Then
            MsgBox("Ingrese un nombre de unidad válido.")
            Exit Sub
        End If
        sStr = "INSERT INTO dbo.HilamarArticulosUnidadesMedidas (nombreUnidad, eliminado) "
        sStr += "VALUES ('" + nuevaUnidad + "', 0) "
        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        cmd.ExecuteNonQuery()

        MsgBox("Unidad creada con éxito")
        tbNuevaUnidad.Text = ""

        CargarCombos()

        tbNuevaUnidad.Text = ""
    End Sub

    Private Sub btnModificarUnidad_Click(sender As Object, e As EventArgs) Handles btnModificarUnidad.Click
        Dim cmd As New SqlCommand
        Dim sStr, nuevaUnidad As String
        Dim rta As Integer

        nuevaUnidad = tbNuevoNombre.Text
        If cmbUnidadActualModif.Text = "Seleccione Unidad" Then
            MsgBox("Seleccione una unidad de la lista.")
            Exit Sub
        End If
        If nuevaUnidad.Length < 1 Then
            MsgBox("Ingrese un nombre de unidad válido.")
            Exit Sub
        End If

        rta = MsgBox("¿Está seguro que desea modificar " + cmbUnidadActualModif.Text + " para cambiarlo por " + nuevaUnidad + " ?", MsgBoxStyle.YesNo)

        If rta = 7 Then
            Exit Sub
        End If

        sStr = "INSERT INTO dbo.HilamarArticulosUnidadesMedidas (nombreUnidad, eliminado) "
        sStr += "VALUES ('" + nuevaUnidad + "', 0) "
        sStr += "UPDATE dbo.HilamarArticulosUnidadesMedidas "
        sStr += "SET eliminado = 1 "
        sStr += "WHERE nombreUnidad = '" + cmbUnidadActualModif.Text + "' "
        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        cmd.ExecuteNonQuery()

        MsgBox("Modificación realizada con éxito!")

        CargarCombos()

        tbNuevoNombre.Text = ""
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim cmd As New SqlCommand
        Dim sStr As String
        Dim rta As Integer

        If cmbUnidadAEliminar.Text = "Seleccione Unidad" Then
            MsgBox("Seleccione una Unidad de la lista.")
            Exit Sub
        End If

        rta = MsgBox("¿Está seguro que desea eliminar la unidad " + cmbUnidadAEliminar.Text + " ?", MsgBoxStyle.YesNo)

        If rta = 7 Then
            Exit Sub
        End If

        sStr = "UPDATE dbo.HilamarArticulosUnidadesMedidas  "
        sStr += "SET eliminado = 1  "
        sStr += "WHERE nombreUnidad = '" + cmbUnidadAEliminar.Text + "'"
        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        cmd.ExecuteNonQuery()

        MsgBox(cmbUnidadAEliminar.Text + " fue eliminado con éxito!")

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