Imports System.Data.SqlClient

Public Class frmBorrarRepoHiladoIngMovimientos

    Dim Command As New SqlCommand
    Dim Reader As SqlDataReader
    Dim sStr As String

    Public Sub CargarListado()
        Dim row As String()
        Dim ParaCostura, FinPartida As String

        limpiaryarmardgvMovimientos()

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        sStr = "SELECT *,isnull((SELECT top 1 id FROM HilamarHiladoTextiStock WHERE Eliminado=0 and IdMovFinPartida=M.id),0) as IdFin "
        sStr = sStr + " FROM HilamarStockTextiMovimientos as M WHERE isnull(Eliminado,0) = 0 "
        If txtPartida.Text <> "" Then
            sStr = sStr + " AND Partida like '%" + txtPartida.Text + "%'"
        End If
        If txtRemito.Text <> "" Then
            sStr = sStr + " AND NroRemito like '%" + txtRemito.Text + "%'"
        End If
        If chkVerPCostura.Checked = False Then
            sStr = sStr + " AND isnull(ParaCostura,0) = 0 "
        End If
        sStr = sStr + " order by Fecha Desc, NroRemito Desc"

        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read
                If IsNothing(Reader.Item("ParaCostura")) Then
                    ParaCostura = ""
                Else
                    If Reader.Item("ParaCostura").ToString = "1" Then
                        ParaCostura = "SI"
                    Else
                        ParaCostura = ""
                    End If
                End If
                If Reader.Item("IdFin").ToString <> "0" Then
                    FinPartida = "SI"
                Else
                    FinPartida = ""
                End If

                row = {Reader.Item("Id").ToString, Format(Reader.Item("Fecha"), "dd/MM/yyyy"), Reader.Item("NroRemito").ToString, Reader.Item("Partida").ToString, _
                       Reader.Item("Hilado").ToString, Reader.Item("Kilos").ToString, Reader.Item("TipoMov").ToString, FinPartida, ParaCostura}
                dgvMovimientos.Rows.Add(row)

            Loop
            Reader.NextResult()
        Loop

    End Sub

    Private Sub limpiaryarmardgvMovimientos()
        dgvMovimientos.Rows.Clear()
        dgvMovimientos.Columns.Clear()
        dgvMovimientos.Columns.Add("ID", "ID")
        dgvMovimientos.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvMovimientos.Columns("ID").Visible = False
        dgvMovimientos.Columns.Add("FECHA", "FECHA")
        dgvMovimientos.Columns("FECHA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvMovimientos.Columns("FECHA").Width = 75
        dgvMovimientos.Columns("FECHA").ReadOnly = True
        dgvMovimientos.Columns.Add("REMITO", "REMITO")
        dgvMovimientos.Columns("REMITO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvMovimientos.Columns("REMITO").Width = 75
        dgvMovimientos.Columns("REMITO").ReadOnly = True
        dgvMovimientos.Columns.Add("PARTIDA", "PARTIDA")
        dgvMovimientos.Columns("PARTIDA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvMovimientos.Columns("PARTIDA").Width = 80
        dgvMovimientos.Columns("PARTIDA").ReadOnly = True
        dgvMovimientos.Columns.Add("HILADO", "HILADO")
        dgvMovimientos.Columns("HILADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvMovimientos.Columns("HILADO").Width = 95
        dgvMovimientos.Columns("HILADO").ReadOnly = True
        dgvMovimientos.Columns.Add("KILOS", "KILOS")
        dgvMovimientos.Columns("KILOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMovimientos.Columns("KILOS").Width = 75
        dgvMovimientos.Columns("KILOS").ReadOnly = True
        dgvMovimientos.Columns.Add("MOV", "MOV")
        dgvMovimientos.Columns("MOV").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvMovimientos.Columns("MOV").Width = 40
        dgvMovimientos.Columns("MOV").ReadOnly = True
        dgvMovimientos.Columns.Add("FIN", "FIN")
        dgvMovimientos.Columns("FIN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvMovimientos.Columns("FIN").Width = 40
        dgvMovimientos.Columns("FIN").ReadOnly = True
        dgvMovimientos.Columns.Add("COS", "COS")
        dgvMovimientos.Columns("COS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvMovimientos.Columns("COS").Width = 40
        dgvMovimientos.Columns("COS").ReadOnly = True

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        CargarListado()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Agregar()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Modificar()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Eliminar()
    End Sub

    Private Sub Agregar()
        Dim formIngresodeHilados As New frmBorrarABMIngresodeHilados()
        If FormAbierto(formIngresodeHilados) Then Exit Sub
        formIngresodeHilados.Alta = True
        formIngresodeHilados.Cargar()
        formIngresodeHilados.Show()
        CargarListado()
    End Sub

    Private Sub Modificar()
        Dim resguardoIndex, resguardoPrimerFila As Integer

        If dgvMovimientos.CurrentRow.Index < 0 Then Exit Sub

        'If dgvMovimientos.Rows(dgvMovimientos.CurrentRow.Index).Cells("COS").Value.ToString = "SI" Then
        '    MensajeAtencion("No pueden modificarse los movimientos ingresados P/COSTURA." + Chr(10) + "Deberá eliminar el movimiento y reingresarlo correctamente.")
        '    Exit Sub
        'End If

        resguardoIndex = dgvMovimientos.CurrentRow.Index
        resguardoPrimerFila = dgvMovimientos.FirstDisplayedCell.RowIndex

        Dim formIngresodeHilados As New frmBorrarABMIngresodeHilados()
        If FormAbierto(formIngresodeHilados) Then Exit Sub
        formIngresodeHilados.Alta = False
        formIngresodeHilados.Id = dgvMovimientos.Rows(dgvMovimientos.CurrentRow.Index).Cells(0).Value.ToString
        formIngresodeHilados.Cargar()
        formIngresodeHilados.ShowDialog()
        CargarListado()

        'luego de cargar el listado vuelvo a seleccionar la fila que tenia al pedir la modificacion
        dgvMovimientos.Rows(resguardoIndex).Selected = True
        dgvMovimientos.FirstDisplayedScrollingRowIndex = resguardoPrimerFila
    End Sub

    Private Sub Eliminar()
        Dim idMovimiento As String

        If dgvMovimientos.CurrentRow.Index < 0 Then Exit Sub

        If MsgBox("¿Está seguro de eliminar el registro seleccionado?", vbYesNo, "Textilana S. A.") = vbNo Then Exit Sub

        idMovimiento = dgvMovimientos.Rows(dgvMovimientos.CurrentRow.Index).Cells(0).Value.ToString()

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        'solo voy a quitar del stock de hilados los movimientos que no sean de costura, los decostura nunca afectan el stoc kde hilados
        If dgvMovimientos.Rows(dgvMovimientos.CurrentRow.Index).Cells("COS").Value.ToString <> "SI" Then
            'debo sacar los kilos del total de stock de la partida
            sStr = "UPDATE HilamarHiladoTextiStock"
            sStr = sStr + " SET Kilos = "
            sStr = sStr + " CASE (Select TipoMov from HilamarStockTextiMovimientos WHERE Id=" + idMovimiento + ") "
            sStr = sStr + " WHEN 'I' THEN Kilos - (Select Kilos from HilamarStockTextiMovimientos WHERE Id=" + idMovimiento + ") "
            sStr = sStr + " WHEN 'D' THEN Kilos + (Select Kilos from HilamarStockTextiMovimientos WHERE Id=" + idMovimiento + ") "
            sStr = sStr + " End"
            sStr = sStr + " WHERE id = (Select IdPartida from HilamarStockTextiMovimientos WHERE Id=" + idMovimiento + ")"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()
        End If
        'luego si marco como eliminado el movimiento, sea de costura o no
        sStr = "UPDATE HilamarStockTextiMovimientos SET Eliminado = 1 WHERE id = " + idMovimiento
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        MensajeAtencion("Registro eliminado correctamente.")

        CargarListado()

    End Sub

    Private Sub dgvMovimientos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMovimientos.CellDoubleClick
        Modificar()
    End Sub

    Private Sub chkVerTerminados_CheckedChanged(sender As Object, e As EventArgs) Handles chkVerPCostura.CheckedChanged
        CargarListado()
    End Sub

    Private Sub txtRemito_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRemito.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            CargarListado()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            Close()
        End If
    End Sub
    Private Sub txtPartida_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPartida.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            CargarListado()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            Close()
        End If
    End Sub

End Class