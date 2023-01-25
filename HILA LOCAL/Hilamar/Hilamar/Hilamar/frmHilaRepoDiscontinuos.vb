Imports System.Data.SqlClient

Public Class frmHilaRepoDiscontinuos

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Close()
    End Sub

    Private Sub CargarListado()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        Dim fil, col, Contador As Integer
        Dim AuxFecha As Date

        Dim row As String()

        Dim FormProgre As New frmProgreso
        FormProgre.CantMax = 60
        FormProgre.lblTarea.Text = "Calculando el stock de Hilados discontinuados"
        FormProgre.lblEstado.Text = "Por favor aguarde unos instantes ..."
        FormProgre.Cargar()
        FormProgre.Show()
        FormProgre.CantProg = 1
        FormProgre.Actualizar()

        limpiaryarmardgvPartidas()

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT * "
        sStr = sStr + " FROM HilamarHiladoStock H INNER JOIN HilamarTipoHiladoPartidas T ON H.Codtipohilado=T.Codigo "
        sStr = sStr + " WHERE H.Eliminado=0 and H.Codtipohilado like '%%' and FechaStockHasta is null AND ESDISCONTINUADA=1 "
        If txtPartida.Text <> "" Then sStr = sStr & " AND H.PARTIDA LIKE '%" & txtPartida.Text & "%' "
        sStr = sStr + " ORDER BY CodTipoHilado, Color "

        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read
                If IsDBNull(Reader.Item("ColorCono")) Then
                    row = {Reader.Item("Codtipohilado").ToString + "-" + Reader.Item("Descripcion").ToString, Reader.Item("Partida").ToString, Reader.Item("CodColor").ToString, Reader.Item("Color").ToString}
                Else
                    row = {Reader.Item("Codtipohilado").ToString + "-" + Reader.Item("Descripcion").ToString, Reader.Item("Partida").ToString, Reader.Item("ColorCono").ToString, Reader.Item("Color").ToString}
                End If
                dgvPartidas.Rows.Add(row)
            Loop
            Reader.NextResult()
        Loop

        FormProgre.CantMax = dgvPartidas.RowCount + 2

        FormProgre.CantProg = FormProgre.CantProg + 1
        FormProgre.Actualizar()

        ' luego por cada partida voy sacando el stock a cada dia de cada columna
        For fil = 0 To dgvPartidas.RowCount - 1
            For col = 4 To dgvPartidas.ColumnCount - 1
                AuxFecha = CDate(Strings.Right(dgvPartidas.Columns(col).Name, 2) + "/" + Strings.Mid(dgvPartidas.Columns(col).Name, 5, 2) + "/" + Strings.Left(dgvPartidas.Columns(col).Name, 4))
                dgvPartidas.Rows(fil).Cells(col).Value = HilamarObtengoStockActualPartida(dgvPartidas.Rows(fil).Cells("Partida").Value.ToString, AuxFecha)
            Next col

            FormProgre.CantProg = FormProgre.CantProg + 1
            FormProgre.Actualizar()
        Next fil

        dgvTotales.Rows.Clear()
        row = {"", "", "", " TOTALES "}
        dgvTotales.Rows.Add(row)
        For col = 4 To dgvPartidas.ColumnCount - 1
            Contador = 0
            For fil = 0 To dgvPartidas.RowCount - 1
                Contador = Contador + dgvPartidas.Rows(fil).Cells(col).Value
            Next fil
            dgvTotales.Rows(0).Cells(col).Value = Contador
        Next col

        FormProgre.Close()

        ' cuando termino si la cantida de columnas excede el ancho de los dgv debo agrandar el dgv de totales porque si no, no se ve nada
        If dgvPartidas.ColumnCount > 15 Then
            dgvTotales.Height = 42
            dgvTotales.Width = dgvPartidas.Width - 16
        Else
            dgvTotales.Height = 25
        End If

        'una vez que termino todo ordeno el dgv por la columna de stock, a pedido de Jorge 08/05/2019
        'como no se cual de todas las de stock ordenar, supongo que será por la ultima columna
        dgvPartidas.Sort(dgvPartidas.Columns(dgvPartidas.ColumnCount - 1), System.ComponentModel.ListSortDirection.Ascending)

        dgvPartidas.Select()

    End Sub

    Private Sub limpiaryarmardgvPartidas()
        Dim FechaInicio As Date = "21/10/2019"

        dgvPartidas.Rows.Clear()
        dgvPartidas.Columns.Clear()
        dgvPartidas.Columns.Add("HILADO", "HILADO")
        dgvPartidas.Columns("HILADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPartidas.Columns("HILADO").Width = 160
        dgvPartidas.Columns("HILADO").ReadOnly = True
        dgvPartidas.Columns.Add("PARTIDA", "PARTIDA")
        dgvPartidas.Columns("PARTIDA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPartidas.Columns("PARTIDA").Width = 70
        dgvPartidas.Columns("PARTIDA").ReadOnly = True
        dgvPartidas.Columns.Add("CONO", "CONO")
        dgvPartidas.Columns("CONO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPartidas.Columns("CONO").Width = 70
        dgvPartidas.Columns("CONO").ReadOnly = True
        dgvPartidas.Columns.Add("COLOR", "COLOR")
        dgvPartidas.Columns("COLOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPartidas.Columns("COLOR").Width = 150
        dgvPartidas.Columns("COLOR").ReadOnly = True

        dgvTotales.Rows.Clear()
        dgvTotales.Columns.Clear()
        dgvTotales.Columns.Add("HILADO", "HILADO")
        dgvTotales.Columns("HILADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvTotales.Columns("HILADO").Width = 160
        dgvTotales.Columns("HILADO").ReadOnly = True
        dgvTotales.Columns.Add("PARTIDA", "PARTIDA")
        dgvTotales.Columns("PARTIDA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvTotales.Columns("PARTIDA").Width = 70
        dgvTotales.Columns("PARTIDA").ReadOnly = True
        dgvTotales.Columns.Add("CONO", "CONO")
        dgvTotales.Columns("CONO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvTotales.Columns("CONO").Width = 70
        dgvTotales.Columns("CONO").ReadOnly = True
        dgvTotales.Columns.Add("COLOR", "COLOR")
        dgvTotales.Columns("COLOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvTotales.Columns("COLOR").Width = 150
        dgvTotales.Columns("COLOR").ReadOnly = True

        ' ARRANCO EL 18/03 Y VOY MOSTRANDO EL STOCK TODOS LOS LUNES
        Do While Format(FechaInicio, "yyyyMMdd") <= Format(Now, "yyyyMMdd") 'And Format(FechaInicio, "yyyyMMdd") < "20190731"
            dgvPartidas.Columns.Add(Format(FechaInicio, "yyyyMMdd"), Format(FechaInicio, "dd/MM"))
            dgvPartidas.Columns(Format(FechaInicio, "yyyyMMdd")).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvPartidas.Columns(Format(FechaInicio, "yyyyMMdd")).Width = 55
            dgvPartidas.Columns(Format(FechaInicio, "yyyyMMdd")).ReadOnly = True

            dgvTotales.Columns.Add(Format(FechaInicio, "yyyyMMdd"), Format(FechaInicio, "dd/MM"))
            dgvTotales.Columns(Format(FechaInicio, "yyyyMMdd")).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvTotales.Columns(Format(FechaInicio, "yyyyMMdd")).Width = 55
            dgvTotales.Columns(Format(FechaInicio, "yyyyMMdd")).ReadOnly = True

            FechaInicio = DateAdd(DateInterval.Day, 7, FechaInicio)
        Loop

    End Sub

    Private Sub cmdListar_Click(sender As Object, e As EventArgs) Handles cmdListar.Click
        CargarListado()
    End Sub

    Private Sub frmHilaRepoDiscontinuos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarListado()
    End Sub

    '##########################################################################################################################################################################

    Private nRowPos As Int16
    Private NewPage As Boolean
    Private nPageNo As Int16
    Private lPageNo As String = ""

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If dgvPartidas.RowCount <= 0 Then Exit Sub

        pdoImpReporte.DefaultPageSettings.Landscape = True
        pdoImpReporte.DefaultPageSettings.Margins.Left = 20
        pdoImpReporte.DefaultPageSettings.Margins.Right = 20
        pdoImpReporte.DefaultPageSettings.Margins.Top = 20
        pdoImpReporte.DefaultPageSettings.Margins.Bottom = 20
        pdoImpReporte.OriginAtMargins = True ' takes margins into account 

        'Dim dlgPrintPreview As New EnhancedPrintPreviewDialog
        'dlgPrintPreview.ClientSize = New System.Drawing.Size(600, 600)
        'dlgPrintPreview.Document = pdoImpReporte ' Previews print
        'dlgPrintPreview.ShowDialog()

        pdoImpReporte.Print()

    End Sub

    Private Sub pdoImpExistencias_BeginPrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles pdoImpReporte.BeginPrint
        nRowPos = 0
        NewPage = True
        nPageNo = 1
    End Sub

    Private Sub pdoImpPlanilla_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdoImpReporte.PrintPage
        On Error Resume Next

        Dim AuxColumna, Col As Integer

        Dim FuenteLineas As Font = New Drawing.Font("Arial", 10, FontStyle.Regular)
        Dim Fuente8 As Font = New Drawing.Font("Arial", 8, FontStyle.Regular)
        Dim Fuente8Neg As Font = New Drawing.Font("Arial", 8, FontStyle.Bold)
        Dim Fuente9 As Font = New Drawing.Font("Arial", 9, FontStyle.Regular)
        Dim FuenteTituloEnc As Font = New Drawing.Font("Arial", 12, FontStyle.Regular)

        Dim nTop As Int16 = e.MarginBounds.Top


        Do While nRowPos < dgvPartidas.RowCount

            'If nTop > e.MarginBounds.Height - e.MarginBounds.Top - 30 Then
            If nTop > 750 Then
                'LUEGO EL PIE DE PAGINA
                DrawFooter(e)

                nPageNo += 1
                NewPage = True
                e.HasMorePages = True
                Exit Sub

            Else

                If NewPage Then

                    ' Draw Header
                    e.Graphics.DrawString("TEXTILANA S.A. (División Hilados) ", FuenteTituloEnc, Brushes.Black, 100, nTop - 5)
                    e.Graphics.DrawString("Evolución de Hilados Discontinuos.", FuenteTituloEnc, Brushes.Black, 800, nTop - 5)
                    nTop = nTop + 14
                    e.Graphics.DrawLine(Pens.Black, 100, nTop, 362, nTop)
                    nTop = nTop + 8

                    e.Graphics.DrawString("HILADO", Fuente9, Brushes.Black, 20, nTop)
                    e.Graphics.DrawString("PARTIDA", Fuente9, Brushes.Black, 140, nTop)
                    e.Graphics.DrawString("CONO", Fuente9, Brushes.Black, 220, nTop)
                    e.Graphics.DrawString("COLOR", Fuente9, Brushes.Black, 300, nTop)
                    Col = 440
                    For AuxColumna = 4 To dgvPartidas.ColumnCount - 1
                        e.Graphics.DrawString(dgvPartidas.Columns(AuxColumna).HeaderText, Fuente9, Brushes.Black, Col, nTop)
                        Col = Col + 40
                    Next

                    nTop = nTop + 17
                    e.Graphics.DrawLine(Pens.Black, 20, nTop, 1080, nTop)
                    nTop = nTop + 2

                    NewPage = False

                End If

            End If


            e.Graphics.DrawString(dgvPartidas.Rows(nRowPos).Cells("HILADO").Value, Fuente8, Brushes.Black, New RectangleF(20, nTop, 120, 15))
            e.Graphics.DrawString(dgvPartidas.Rows(nRowPos).Cells("PARTIDA").Value, Fuente8, Brushes.Black, New RectangleF(140, nTop, 80, 15))
            e.Graphics.DrawString(dgvPartidas.Rows(nRowPos).Cells("CONO").Value, Fuente8, Brushes.Black, New RectangleF(220, nTop, 80, 15))
            e.Graphics.DrawString(dgvPartidas.Rows(nRowPos).Cells("COLOR").Value, Fuente8, Brushes.Black, New RectangleF(300, nTop, 140, 15))
            Col = 440
            For AuxColumna = 4 To dgvPartidas.ColumnCount - 1
                e.Graphics.DrawString(dgvPartidas.Rows(nRowPos).Cells(AuxColumna).Value, Fuente8, Brushes.Black, (Col + 39) - e.Graphics.MeasureString(dgvPartidas.Rows(nRowPos).Cells(AuxColumna).Value.ToString, Fuente8).Width, nTop)
                Col = Col + 40
            Next
            'e.Graphics.DrawString(dgvListado.Rows(nRowPos).Cells("RECURSO").Value, Fuente8, Brushes.Black, New RectangleF(500, nTop, 240, 20))
            'e.Graphics.DrawString(dgvListado.Rows(nRowPos).Cells("MINUTOS").Value, Fuente8, Brushes.Black, 780 - e.Graphics.MeasureString(dgvListado.Rows(nRowPos).Cells("MINUTOS").Value.ToString, Fuente8).Width, nTop)
            nTop = nTop + 18

            nRowPos += 1

        Loop

        'La linea con los totales

        nTop = nTop + 5
        e.Graphics.DrawLine(Pens.Black, 20, nTop, 1080, nTop)
        nTop = nTop + 2
        e.Graphics.DrawString("TOTALES", Fuente8, Brushes.Black, New RectangleF(20, nTop, 120, 24))
        Col = 440
        For AuxColumna = 4 To dgvTotales.ColumnCount - 1
            e.Graphics.DrawString(dgvTotales.Rows(0).Cells(AuxColumna).Value, Fuente8, Brushes.Black, (Col + 39) - e.Graphics.MeasureString(dgvTotales.Rows(0).Cells(AuxColumna).Value.ToString, Fuente8).Width, nTop)
            Col = Col + 40
        Next
        nTop = nTop + 18
        e.Graphics.DrawLine(Pens.Black, 20, nTop, 1080, nTop)



        'LUEGO EL PIE DE PAGINA
        DrawFooter(e)

    End Sub

    Public Sub DrawFooter(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim FuenteLineas8 As Font = New Drawing.Font("Arial", 8, FontStyle.Regular)

        Dim sPageNo As String = "Pag. " + nPageNo.ToString

        e.Graphics.DrawLine(Pens.Black, 20, e.MarginBounds.Height - 17, 1090, e.MarginBounds.Height - 17)

        ' Right Align - User Name
        e.Graphics.DrawString("Impreso: " + Format(Now, "dd/MM/yyyy HH:mm:ss"), FuenteLineas8, Brushes.Black, 920, e.MarginBounds.Height - 15)

        ' Center - Page No. Info
        e.Graphics.DrawString(sPageNo, FuenteLineas8, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(sPageNo, FuenteLineas8, e.MarginBounds.Width).Width) / 2, e.MarginBounds.Height - 15)

        e.Graphics.DrawLine(Pens.Black, 20, e.MarginBounds.Height, 1090, e.MarginBounds.Height)

    End Sub

    Private Sub dgvPartidas_Scroll(sender As Object, e As ScrollEventArgs) Handles dgvPartidas.Scroll
        dgvTotales.HorizontalScrollingOffset = e.NewValue
    End Sub
    Private Sub dgvTotales_Scroll(sender As Object, e As ScrollEventArgs) Handles dgvTotales.Scroll
        dgvPartidas.HorizontalScrollingOffset = e.NewValue
    End Sub
End Class