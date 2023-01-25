Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmListadoColoresIndex
    Dim cmd As New SqlCommand
    Dim rd As SqlDataReader
    Dim sStr, Row() As String

    Private Sub frmABMColores_Load(sender As Object, e As EventArgs) Handles Me.Load

        CargarColores()

    End Sub

    Private Sub ArmarDGV()

        dgvColores.Columns.Add("ID", "id")
        dgvColores.Columns("ID").Visible = False
        dgvColores.Columns.Add("Código", "Código")
        dgvColores.Columns("Código").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvColores.Columns("Código").Width = 198
        dgvColores.Columns.Add("Color", "Color")
        dgvColores.Columns("Color").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvColores.Columns("Color").Width = 198


        For Each colum As DataGridViewColumn In dgvColores.Columns
            colum.ReadOnly = True
        Next

        dgvColores.Font = New Font("Arial", 12)

    End Sub
    Private Sub LimpiarDGV()

        dgvColores.Rows.Clear()
        dgvColores.Columns.Clear()

    End Sub
    Private Sub CargarColores()

        Me.Cursor = Cursors.WaitCursor
       

        LimpiarDGV()
        ArmarDGV()




        sStr = "SELECT id, Codigo, NombreColor from dbo.HilamarArticulosColorIndex " + _
               "WHERE eliminado = 0 "

        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        rd = cmd.ExecuteReader()

        Do While rd.HasRows
            Do While rd.Read()
                Row = {rd.Item("id"), rd.Item("Codigo"), rd.Item("NombreColor")}
                dgvColores.Rows.Add(Row)
            Loop
            rd.NextResult()
        Loop

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click



        Dim rta As Integer = MsgBox("¿Esta seguro que desea eliminar " + dgvColores.CurrentRow.Cells.Item("Color").Value.ToString + " - " + dgvColores.CurrentRow.Cells.Item("Código").Value.ToString + "?", vbYesNo)

        If rta = 7 Then
            Exit Sub
        End If

        sStr = "UPDATE HilamarArticulosColorIndex "
        sStr += "SET eliminado = 1 "
        sStr += "WHERE id = '" + dgvColores.CurrentRow.Cells.Item("ID").Value.ToString + "' "

        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        cmd.ExecuteNonQuery()

        CargarColores()

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If dgvColores.SelectedRows.Count > 1 Then Exit Sub

        Dim frmABMcolorindex As New frmABMColorIndex(dgvColores.CurrentRow.Cells.Item("ID").Value)

        frmABMcolorindex.ShowDialog()
        CargarColores()
    End Sub


    Private Sub dgvColores_SelectionChanged(sender As Object, e As EventArgs) Handles dgvColores.SelectionChanged
        If dgvColores.SelectedCells.Count = 1 Then
            btnEditar.Enabled = True
            btnEliminar.Enabled = True
        Else
            btnEditar.Enabled = False
            btnEliminar.Enabled = False
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Dim frmABMcolorindex As New frmABMColorIndex(0)
        frmABMcolorindex.ShowDialog()
        CargarColores()

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class