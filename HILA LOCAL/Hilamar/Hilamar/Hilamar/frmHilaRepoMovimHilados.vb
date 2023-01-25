Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.IO

Public Class frmHilaRepoMovimHilados

    Private Sub CargarListado()
        Dim sStr As String
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader

        Dim row As String()

        LimpiarDGV()
        ArmarDGV()

        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            MensajeAtencion("La Fecha Desde no puede ser mayor que la Fecha Hasta. Verifique.")
        End If

        sStr = "SELECT isnull(Conos,'') as Conos, * FROM HilamarHiladoStockEncMov E INNER JOIN HilamarHiladoStockDetMov D ON E.TipoMov=D.TipoMov AND E.NroRemito=D.NroRemito "
        sStr = sStr + " INNER JOIN HilamarHiladoStock HIL ON D.Partida = HIL.Partida AND HIL.Eliminado =0 and HIL.FechaStockDesde <=E.Fecha and isnull(HIL.FechaStockHasta,getdate()) >=E.Fecha "
        sStr = sStr + "WHERE Isnull(E.Eliminado,0)=0 AND Isnull(D.Eliminado,0)=0 AND Fecha BETWEEN '" + Format(dtpFechaDesde.Value, "yyyyMMdd") + "' AND '" + Format(dtpFechaHasta.Value, "yyyyMMdd") + "' "
        If txtFiltroPartida.Text <> "" Then
            sStr = sStr + " AND D.Partida like '%" + txtFiltroPartida.Text + "%' "
        End If
        If txtFiltroHilado.Text <> "" Then
            sStr = sStr + " AND D.Partida IN (SELECT PARTIDA FROM HilamarHiladoStock WHERE CodTipoHilado LIKE '%" + txtFiltroHilado.Text + "%' ) "
        End If

        If rbFiltroMovE.Checked Then
            sStr = sStr + " AND E.TipoMov = 'E'"
        End If
        If rbFiltroMovI.Checked Then
            sStr = sStr + " AND E.TipoMov = 'I'"
        End If
        If rbFiltroMovDI.Checked Then
            sStr = sStr + " AND E.TipoMov = 'DI'"
        End If
        If rbFiltroMovC.Checked Then
            sStr = sStr + " AND E.TipoMov = 'C'"
        End If

        sStr = sStr + "order by Fecha,E.TipoMov,cast(E.NroRemito as float),D.Partida "

        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                row = {Format(Reader.Item("Fecha"), "dd/MM/yyyy"), Reader.Item("TipoMov").ToString, Reader.Item("NroRemito").ToString, Reader.Item("Observacion").ToString,
                       Reader.Item("Partida").ToString, Reader.Item("CodTipoHilado").ToString + "-" + Reader.Item("Color").ToString, Reader.Item("Conos").ToString, Reader.Item("Kilos").ToString,
                       Reader.Item("Observaciones").ToString}
                dgvMovimientos.Rows.Add(row)
            Loop
            Reader.NextResult()
        Loop
    End Sub

    Private Sub LimpiarDGV()
        dgvMovimientos.Rows.Clear()
        dgvMovimientos.Columns.Clear()
    End Sub

    Private Sub ArmarDGV()
        dgvMovimientos.Columns.Add("FECHA", "FECHA")
        dgvMovimientos.Columns("FECHA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvMovimientos.Columns("FECHA").Width = 75
        dgvMovimientos.Columns("FECHA").ReadOnly = True
        dgvMovimientos.Columns.Add("MOV", "MOV")
        dgvMovimientos.Columns("MOV").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvMovimientos.Columns("MOV").Width = 35
        dgvMovimientos.Columns("MOV").ReadOnly = True
        dgvMovimientos.Columns.Add("REMITO", "REMITO")
        dgvMovimientos.Columns("REMITO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMovimientos.Columns("REMITO").Width = 60
        dgvMovimientos.Columns("REMITO").ReadOnly = True
        dgvMovimientos.Columns.Add("ENCOBS", "OBS")
        dgvMovimientos.Columns("ENCOBS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvMovimientos.Columns("ENCOBS").Width = 160
        dgvMovimientos.Columns("ENCOBS").ReadOnly = True
        dgvMovimientos.Columns.Add("PARTIDA", "PARTIDA")
        dgvMovimientos.Columns("PARTIDA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvMovimientos.Columns("PARTIDA").Width = 75
        dgvMovimientos.Columns("PARTIDA").DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvMovimientos.Columns("PARTIDA").ReadOnly = True
        dgvMovimientos.Columns.Add("HILADO", "HILADO")
        dgvMovimientos.Columns("HILADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvMovimientos.Columns("HILADO").Width = 150
        dgvMovimientos.Columns("HILADO").DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvMovimientos.Columns("HILADO").ReadOnly = True
        dgvMovimientos.Columns.Add("CONOS", "CONOS")
        dgvMovimientos.Columns("CONOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMovimientos.Columns("CONOS").Width = 50
        dgvMovimientos.Columns("CONOS").ReadOnly = True
        dgvMovimientos.Columns.Add("KILOS", "KILOS")
        dgvMovimientos.Columns("KILOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMovimientos.Columns("KILOS").Width = 60
        dgvMovimientos.Columns("KILOS").ReadOnly = True
        dgvMovimientos.Columns.Add("DETOBS", "OBS")
        dgvMovimientos.Columns("DETOBS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvMovimientos.Columns("DETOBS").Width = 140
        dgvMovimientos.Columns("DETOBS").ReadOnly = True

        dgvMovimientos.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8)
        dgvMovimientos.DefaultCellStyle.Font = New Font("Tahoma", 8)
        dgvMovimientos.RowTemplate.Height = 25

    End Sub

    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Close()
    End Sub

    Private Sub rbFiltroMovS_CheckedChanged(sender As Object, e As EventArgs) Handles rbFiltroMovI.CheckedChanged
        If rbFiltroMovI.Checked Then CargarListado()
    End Sub
    Private Sub rbFiltroMovTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rbFiltroMovTodos.CheckedChanged
        If rbFiltroMovTodos.Checked Then CargarListado()
    End Sub
    Private Sub rbFiltroMovE_CheckedChanged(sender As Object, e As EventArgs) Handles rbFiltroMovE.CheckedChanged
        If rbFiltroMovE.Checked Then CargarListado()
    End Sub
    Private Sub rbFiltroMovDI_CheckedChanged(sender As Object, e As EventArgs) Handles rbFiltroMovDI.CheckedChanged
        If rbFiltroMovDI.Checked Then CargarListado()
    End Sub
    Private Sub rbFiltroMovC_CheckedChanged(sender As Object, e As EventArgs) Handles rbFiltroMovC.CheckedChanged
        If rbFiltroMovC.Checked Then CargarListado()
    End Sub

    Private Sub cmdListar_Click(sender As Object, e As EventArgs) Handles cmdListar.Click
        CargarListado()
    End Sub

    Private Sub frmHilaRepoMovimHilados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFechaDesde.Value = DateAdd(DateInterval.Month, -1, Now)
        dtpFechaHasta.Value = Now
        CargarListado()
        txtFiltroHilado.Select()
    End Sub

    Private Sub txtFiltroHilado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroHilado.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            CargarListado()
        End If
    End Sub
    Private Sub txtFiltroPartida_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFiltroPartida.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            CargarListado()
        End If
    End Sub

    Private Sub btnEditarMovimiento_Click(sender As Object, e As EventArgs) Handles btnEditarMovimiento.Click
        If dgvMovimientos.SelectedRows.Count <> 1 Then
            MensajeAtencion("Debe seleccionar un Remito para Editarlo")
            Exit Sub
        End If

        If dgvMovimientos.Rows(dgvMovimientos.CurrentRow.Index).Cells("MOV").Value.ToString = "E" Or
            dgvMovimientos.Rows(dgvMovimientos.CurrentRow.Index).Cells("MOV").Value.ToString = "I" Then
            EditarMovimientoSeleccionado()
        Else
            MensajeAtencion("No se pueden editar los Consumos y las Diferencias de Stock.")
        End If

    End Sub

    Private Sub dgvMovimientos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMovimientos.CellDoubleClick
        EditarMovimientoSeleccionado()
    End Sub

    Private Sub EditarMovimientoSeleccionado()
        Dim formHilaEditaMov As New frmHilaEditaMov()
        If FormAbierto(formHilaEditaMov) Then Exit Sub
        formHilaEditaMov.NroRemito = dgvMovimientos.Rows(dgvMovimientos.CurrentRow.Index).Cells("REMITO").Value.ToString
        formHilaEditaMov.TipoMov = dgvMovimientos.Rows(dgvMovimientos.CurrentRow.Index).Cells("MOV").Value.ToString
        formHilaEditaMov.Cargar()
        formHilaEditaMov.ShowDialog()
        CargarListado()
    End Sub

    Private Sub btnEliminarMovimiento_Click(sender As Object, e As EventArgs) Handles btnEliminarMovimiento.Click
        If dgvMovimientos.SelectedRows.Count <> 1 Then
            MensajeAtencion("Debe seleccionar un Remito para Eliminarlo")
            Exit Sub
        End If

        Dim respuesta As Integer
        respuesta = MsgBox("Se eliminará el " + dgvMovimientos.Rows(dgvMovimientos.CurrentRow.Index).Cells("MOV").Value.ToString + " " + dgvMovimientos.Rows(dgvMovimientos.CurrentRow.Index).Cells("REMITO").Value.ToString + ". " + _
        Chr(10) + "¿Confirma el borrado?", vbYesNoCancel, "Textilana S.A.")
        If respuesta = vbYes Then
            EliminarMovimientoSeleccionado()
        End If

    End Sub

    Private Sub EliminarMovimientoSeleccionado()
        Dim sStr As String
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader

        Dim NroRemito As String = dgvMovimientos.Rows(dgvMovimientos.CurrentRow.Index).Cells("REMITO").Value.ToString
        Dim TipoMov As String = dgvMovimientos.Rows(dgvMovimientos.CurrentRow.Index).Cells("MOV").Value.ToString

        If TipoMov = "E" Then
            'primero que nada debo eliminar los ajustes por Di asociados al remito, ya que como voy a recargar el detalle, los hare de nuevo de ser necesarios
            ' para saber si hay o no asociados algun remito de ajuste busco solo por el remitoasociado
            sStr = "SELECT * FROM HilamarHiladoStockEncMov WHERE ISNULL(Eliminado,0)=0 AND TipoMov='DI' AND RemAsociado = " + NroRemito
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            Do While Reader.HasRows
                Do While Reader.Read()
                    'marco el detalle como eliminado
                    sStr = "UPDATE HilamarHiladoStockDetMov SET Eliminado=1 WHERE NroRemito = " + Reader.Item("NroRemito").ToString + " AND TipoMov='" + Reader.Item("TipoMov").ToString + "'"
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                    'marco el encabezado como eliminado
                    sStr = "UPDATE HilamarHiladoStockEncMov SET Eliminado=1 WHERE NroRemito = " + Reader.Item("NroRemito").ToString + " AND TipoMov='" + Reader.Item("TipoMov").ToString + "'"
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                Loop
                Reader.NextResult()
            Loop
        End If

        'elimino el movimiento en cuestion
        'marco el detalle como eliminado
        sStr = "UPDATE HilamarHiladoStockDetMov SET Eliminado=1 WHERE NroRemito = " + NroRemito + " AND TipoMov='" + TipoMov + "'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()
        'marco el encabezado como eliminado
        sStr = "UPDATE HilamarHiladoStockEncMov SET Eliminado=1 WHERE NroRemito = " + NroRemito + " AND TipoMov='" + TipoMov + "'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        MensajeInfo("Movimiento Eliminado correctamente.")
        CargarListado()

    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        If dgvMovimientos.RowCount > 0 Then
            ExportaraExcel()
        End If
    End Sub

    Private Sub ExportaraExcel()
        On Error GoTo ErrGenerarExcelHilados
        Dim sepDec As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Dim sepMil As String = Application.CurrentCulture.NumberFormat.NumberGroupSeparator

        Dim NombreArchivoExcel As String
        Dim oExcel As New Excel.Application()
        Dim oSheet As Excel.Worksheet
        Dim XLProc As Process
        Dim xlHWND As Integer = oExcel.Hwnd
        Dim ProcIDXL As Integer = 0

        Dim nRowPos As Integer

        Dim i As Integer
        Dim Fila, Columna As Integer
        Dim AuxFila As Integer

        'get the process ID
        GetWindowThreadProcessId(xlHWND, ProcIDXL)
        XLProc = Process.GetProcessById(ProcIDXL)

        oExcel.Workbooks.Add()
        oSheet = oExcel.ActiveSheet
        Fila = 1
        Columna = 1
        oSheet.Cells(Fila, Columna).value = "LISTADO DE MOVIMIENTOS"

        Fila = 3
        oSheet.Cells(Fila, Columna).value = "FECHA"
        oSheet.Cells(Fila, Columna).ColumnWidth = 12
        oSheet.Columns(Columna).NumberFormat = "dd/mm/yyyy;@"
        Columna = 2
        oSheet.Cells(Fila, Columna).value = "MOV"
        oSheet.Cells(Fila, Columna).ColumnWidth = 6
        Columna = 3
        oSheet.Cells(Fila, Columna).value = "REMITO"
        oSheet.Cells(Fila, Columna).ColumnWidth = 10
        Columna = 4
        oSheet.Cells(Fila, Columna).value = "OBS."
        oSheet.Cells(Fila, Columna).ColumnWidth = 22
        Columna = 5
        oSheet.Cells(Fila, Columna).value = "PARTIDA"
        oSheet.Cells(Fila, Columna).ColumnWidth = 12
        oSheet.Columns(Columna).NumberFormat = "@"
        Columna = 6
        oSheet.Cells(Fila, Columna).value = "HILADO"
        oSheet.Cells(Fila, Columna).ColumnWidth = 20
        Columna = 7
        oSheet.Cells(Fila, Columna).value = "CONOS"
        oSheet.Cells(Fila, Columna).ColumnWidth = 12
        oSheet.Columns(Columna).NumberFormat = "0"
        Columna = 8
        oSheet.Cells(Fila, Columna).value = "KILOS"
        oSheet.Cells(Fila, Columna).ColumnWidth = 12
        oSheet.Columns(Columna).NumberFormat = "0"
        Columna = 9
        oSheet.Cells(Fila, Columna).value = "OBS."
        oSheet.Cells(Fila, Columna).ColumnWidth = 22

        'le pongo colorcito al los titulos, pero en vez de hacerlo columna por columna, lo hago con el rango
        oSheet.Range("A3", "I3").Interior.ColorIndex = 19

        nRowPos = 0
        Do While nRowPos < dgvMovimientos.RowCount


            Fila = Fila + 1
            oSheet.Cells(Fila, 1).value = dgvMovimientos.Rows(nRowPos).Cells(0).Value
            oSheet.Cells(Fila, 2).value = dgvMovimientos.Rows(nRowPos).Cells(1).Value
            oSheet.Cells(Fila, 3).value = dgvMovimientos.Rows(nRowPos).Cells(2).Value
            oSheet.Cells(Fila, 4).value = dgvMovimientos.Rows(nRowPos).Cells(3).Value
            oSheet.Cells(Fila, 5).value = dgvMovimientos.Rows(nRowPos).Cells(4).Value
            oSheet.Cells(Fila, 6).value = dgvMovimientos.Rows(nRowPos).Cells(5).Value
            oSheet.Cells(Fila, 7).value = dgvMovimientos.Rows(nRowPos).Cells(6).Value
            oSheet.Cells(Fila, 8).value = dgvMovimientos.Rows(nRowPos).Cells(7).Value
            oSheet.Cells(Fila, 9).value = dgvMovimientos.Rows(nRowPos).Cells(8).Value

            nRowPos += 1
        Loop

        'al final cuando ya estan llenas las columnas con datos le arreglo la alineacion, si lo hacia antes solo alineaba los encabezados
        'que eran lo que estaba cargados hasta que cargaba los datos
        oSheet.Range("E:E").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight


        'Si no existe el directorio, lo creo
        If Not Directory.Exists(Application.StartupPath + "\Excel") Then Directory.CreateDirectory(Application.StartupPath + "\Excel")
        'Guardo el archivo 
        NombreArchivoExcel = Application.StartupPath + "\Excel\" + "Lista-Movimientos_" + Format(Now, "dd-MM-yyyy HH-mm-ss") + ".xls"
        oSheet.SaveAs(NombreArchivoExcel, Excel.XlFileFormat.xlExcel7)
        oExcel.Application.Quit() 'Cierro el proceso!
        NAR(XLProc) 'Release
        oSheet = Nothing
        oExcel = Nothing

        Dim respuesta As Integer
        respuesta = MsgBox("Exportado a Excel Correctamente." + Chr(10) + _
                           NombreArchivoExcel _
                           + Chr(10) + Chr(10) + " Desea abrir el archivo?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Exportar a Excel.")
        If respuesta = vbYes Then
            'si dijo si, abro el excel para que lo vea
            System.Diagnostics.Process.Start(NombreArchivoExcel)
        End If

        Exit Sub
ErrGenerarExcelHilados:
        MensajeAtencion("Error al crear el Excel de Stock de Hilados")
        NAR(XLProc) 'Release

    End Sub

End Class