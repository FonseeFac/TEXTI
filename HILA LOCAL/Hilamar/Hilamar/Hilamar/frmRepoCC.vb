Imports System.Data.SqlClient

Public Class frmRepoCC
    Public Alerta As Boolean
    Dim Command As New SqlCommand
    Dim Reader As SqlDataReader
    Dim sStr, row() As String

    Public Sub Cargar()
        Dim Fecha As Date

        CargarCombo()
        Fecha = NowServer()
        dtpFechaHasta.Value = Fecha
        Fecha = Fecha.AddDays(-7)
        dtpFechaDesde.Value = Fecha

        If Alerta Then
            cmbDestino.Text = "PROGRAMACION"
            cmbOrigen.Text = "TODOS"
            cmbDestino.Enabled = False
            cmbOrigen.Enabled = False
        End If

        CargarListado()

    End Sub

    Private Sub CargarCombo()

        cmbOrigen.Items.Clear()
        cmbOrigen.Items.Add("TODOS")
        cmbOrigen.Items.Add("CONTROL DE CALIDAD")
        cmbOrigen.Items.Add("TEJEDURIA")
        cmbOrigen.Items.Add("PROGRAMACION")
        cmbOrigen.Items.Add("DISEÑO")
        cmbOrigen.Text = "TODOS"
        cmbOrigen.Enabled = False

        cmbDestino.Items.Clear()
        cmbDestino.Items.Add("TODOS")
        cmbDestino.Items.Add("CONTROL DE CALIDAD")
        cmbDestino.Items.Add("TEJEDURIA")
        cmbDestino.Items.Add("PROGRAMACION")
        cmbDestino.Items.Add("DISEÑO")
        cmbDestino.Text = "TODOS"

        cmbEstado.Items.Clear()
        cmbEstado.Items.Add("TODOS")
        cmbEstado.Items.Add("PENDIENTE")
        cmbEstado.Items.Add("REVISADO")
        cmbEstado.Items.Add("FINALIZADO")
        cmbEstado.Items.Add("CANCELADO")
        cmbEstado.Text = "TODOS"

        cmbTalle.Items.Clear()
        cmbTalle.Items.Add("TODOS")
        cmbTalle.Items.Add("XS")
        cmbTalle.Items.Add("S")
        cmbTalle.Items.Add("M")
        cmbTalle.Items.Add("L")
        cmbTalle.Items.Add("XL")
        cmbTalle.Items.Add("XXL")
        cmbTalle.Items.Add("XXXL")
        cmbTalle.Items.Add("U")
        cmbTalle.Text = "TODOS"

    End Sub

    Private Sub LimpiarDGV()
        dgvReporte.Rows.Clear()
        dgvReporte.Columns.Clear()
    End Sub

    Private Sub ArmarDGV()

        dgvReporte.Columns.Add("ESTADO", "ESTADO")
        dgvReporte.Columns("ESTADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvReporte.Columns("ESTADO").ReadOnly = True
        dgvReporte.Columns("ESTADO").Width = 120

        dgvReporte.Columns.Add("OP", "OP")
        dgvReporte.Columns("OP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvReporte.Columns("OP").ReadOnly = True
        dgvReporte.Columns("OP").Width = 60

        dgvReporte.Columns.Add("COD ART", "COD ART")
        dgvReporte.Columns("COD ART").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvReporte.Columns("COD ART").Width = 80
        dgvReporte.Columns("COD ART").ReadOnly = True

        dgvReporte.Columns.Add("TALLE", "TALLE")
        dgvReporte.Columns("TALLE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvReporte.Columns("TALLE").ReadOnly = True
        dgvReporte.Columns("TALLE").Width = 60

        dgvReporte.Columns.Add("ORIGEN", "ORIGEN")
        dgvReporte.Columns("ORIGEN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvReporte.Columns("ORIGEN").ReadOnly = True
        dgvReporte.Columns("ORIGEN").Width = 150

        dgvReporte.Columns.Add("DESTINO", "DESTINO")
        dgvReporte.Columns("DESTINO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvReporte.Columns("DESTINO").ReadOnly = True
        dgvReporte.Columns("DESTINO").Width = 150

        dgvReporte.Columns.Add("OBSERVACIONES", "OBSERVACIONES")
        dgvReporte.Columns("OBSERVACIONES").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvReporte.Columns("OBSERVACIONES").ReadOnly = True
        dgvReporte.Columns("OBSERVACIONES").Width = 380

        dgvReporte.Columns.Add("id", "id")
        dgvReporte.Columns("id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvReporte.Columns("id").ReadOnly = True
        dgvReporte.Columns("id").Width = 100
        dgvReporte.Columns("id").Visible = False
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        CargarListado()
    End Sub

    Private Sub CargarListado()
        On Error GoTo ErrCargarListado
        Dim Estado, CodArt, Obs As String

        LimpiarDGV()
        ArmarDGV()

        gpbProcesando.Visible = True
        Application.DoEvents()

        Estado = ""
        CodArt = ""
        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        sStr = "SELECT * FROM TejeControlDeCalidad CC INNER JOIN PrendasOPS OPS ON CC.idOP = OPS.id WHERE CC.Eliminado = 0 AND OPS.Eliminado = 0 "
        sStr = sStr + "AND (Origen = 'PROGRAMACION' OR Destino = 'PROGRAMACION') "
        If cmbTalle.Text <> "TODOS" Then sStr = sStr + "AND Talle = " + CodigoTalle(cmbTalle.Text).ToString + " "
        If cmbOrigen.Text <> "TODOS" Then sStr = sStr + "AND Origen = '" + cmbOrigen.Text + "' "
        If cmbDestino.Text <> "TODOS" Then sStr = sStr + "AND Destino = '" + cmbDestino.Text + "' "
        If txtOP.Text <> "" Then sStr = sStr + "AND idOP = " + idOPExistente(txtOP.Text).ToString + " "
        If cmbEstado.Text <> "TODOS" Then
            If cmbEstado.Text = "PENDIENTE" Then
                sStr = sStr + "AND Estado = 0 "
            ElseIf cmbEstado.Text = "REVISADO" Then
                sStr = sStr + "AND Estado = 1 "
            ElseIf cmbEstado.Text = "FINALIZADO" Then
                sStr = sStr + "AND Estado = 2 "
            ElseIf cmbEstado.Text = "CANCELADO" Then
                sStr = sStr + "AND Estado = 3 "
            End If
        End If
        If txtCodArticulo.Text <> "" Then sStr = sStr + "AND CodArticulo = '" + txtCodArticulo.Text + "' "
        sStr = sStr + "ORDER BY CC.id"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                Obs = ""
                Estado = EstadoCC(Reader.Item("Estado")).ToString
                CodArt = ArticuloPoridOP(Reader.Item("idOP")).ToString
                If Reader.Item("Origen") = "CONTROL DE CALIDAD" Then
                    Obs = Reader.Item("Observaciones").ToString
                ElseIf Reader.Item("Origen") = "TEJEDURIA" Then
                    Obs = Reader.Item("ObservacionesTejeduria").ToString
                ElseIf Reader.Item("Origen") = "PROGRAMACION" Then
                    Obs = Reader.Item("ObservacionesProgramacion").ToString
                ElseIf Reader.Item("Origen") = "DISEÑO" Then
                    Obs = Reader.Item("ObservacionesDiseño").ToString
                End If
                row = {Estado.ToString, NumeroOP(Reader.Item("idOP")).ToString, CodArt.ToString, NombreTalle(Reader.Item("Talle")).ToString, Reader.Item("Origen").ToString, Reader.Item("Destino").ToString, Obs.ToString, Reader.Item("id").ToString}
                dgvReporte.Rows.Add(row)
                If Estado = "FINALIZADO" Then
                    dgvReporte.Rows(dgvReporte.RowCount - 1).DefaultCellStyle.BackColor = Color.DarkGreen
                ElseIf Estado = "CANCELADO" Then
                    dgvReporte.Rows(dgvReporte.RowCount - 1).DefaultCellStyle.BackColor = Color.IndianRed
                ElseIf Estado = "REVISADO" Then
                    dgvReporte.Rows(dgvReporte.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                End If
            Loop
            Reader.NextResult()
        Loop

        EstadoFila()

        gpbProcesando.Visible = False
        Application.DoEvents()

        Exit Sub
ErrCargarListado:
        MensajeAtencion("Error al cargar el listado.")
    End Sub

    Private Sub EstadoFila()

        If dgvReporte.SelectedRows.Count <> 1 Then
            If dgvReporte.RowCount > 0 Then
                btnModificar.Enabled = dgvReporte.Rows(0).Cells("Estado").Value = "PENDIENTE" And dgvReporte.Rows(0).Cells("Origen").Value = "PROGRAMACION"
                btnEliminar.Enabled = dgvReporte.Rows(0).Cells("Estado").Value = "PENDIENTE" And dgvReporte.Rows(0).Cells("Origen").Value = "PROGRAMACION"
                btnVer.Enabled = dgvReporte.Rows(0).Cells("Origen").Value = "PROGRAMACION" Or dgvReporte.Rows(0).Cells("Destino").Value = "PROGRAMACION"
            End If
            Exit Sub
        End If
        btnModificar.Enabled = dgvReporte.CurrentRow.Cells("Estado").Value = "PENDIENTE" And dgvReporte.CurrentRow.Cells("Origen").Value = "PROGRAMACION"
        btnEliminar.Enabled = dgvReporte.CurrentRow.Cells("Estado").Value = "PENDIENTE" And dgvReporte.CurrentRow.Cells("Origen").Value = "PROGRAMACION"
        btnVer.Enabled = dgvReporte.CurrentRow.Cells("Origen").Value = "PROGRAMACION" Or dgvReporte.CurrentRow.Cells("Destino").Value = "PROGRAMACION"
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Agregar()
    End Sub

    Private Sub Agregar()
        Dim FormABM As New frmABMCC
        FormABM.Alta = True
        FormABM.Cargar()
        FormABM.ShowDialog()
        CargarListado()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Modificar()
    End Sub

    Private Sub Modificar()

        If dgvReporte.SelectedRows.Count <> 1 Then Exit Sub

        Dim FormABM As New frmABMCC
        FormABM.Alta = False
        FormABM.id = dgvReporte.CurrentRow.Cells("id").Value.ToString
        FormABM.Cargar()
        FormABM.ShowDialog()
        CargarListado()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Eliminar()
    End Sub

    Private Sub Eliminar()
        Dim Auditoria As String

        If dgvReporte.SelectedRows.Count <> 1 Then Exit Sub

        If MsgBox("¿Está seguro de eliminar el registro seleccionado?", vbYesNo, "Textilana S. A.") = vbNo Then Exit Sub

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        Auditoria = "ELIMINACION CC | " + Environment.MachineName.ToString + " | " + NowServer.ToString
        sStr = "UPDATE TejeControlDeCalidad SET Eliminado = 1, Auditoria = '" + Auditoria.ToString + "' WHERE id = " + dgvReporte.CurrentRow.Cells("id").Value.ToString()
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        MensajeAtencion("Observación eliminada correctamente.")

        CargarListado()
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Imprimir()
    End Sub

    Private Sub Imprimir()
        Dim Titulo As String

        Titulo = ""
        If dgvReporte.RowCount > 0 Then
            Titulo = "Reporte de Control de Calidad"
            DataGridViewPrinter.StartPrint(dgvReporte, True, False, Titulo.ToString, "Textilana S.A.")
        End If
    End Sub

    Private Sub btnVer_Click(sender As Object, e As EventArgs) Handles btnVer.Click
        VerCC()
    End Sub

    Private Sub VerCC()
        If dgvReporte.SelectedRows.Count <> 1 Then Exit Sub

        Dim FormABM As New frmABMCC
        FormABM.Alta = False
        FormABM.Ver = True
        FormABM.id = dgvReporte.CurrentRow.Cells("id").Value.ToString
        FormABM.Cargar()
        FormABM.ShowDialog()
    End Sub

    Private Sub dgvReporte_Click(sender As Object, e As EventArgs) Handles dgvReporte.Click
        EstadoFila()
    End Sub
End Class