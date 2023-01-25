Imports System.Drawing.Printing

Module DataGridViewPrinter

    Public DataGridViewToPrint As New DataGridView

    Public DefaultPageSettings As PageSettings = New PageSettings()

    Public WithEvents DocToPrint As New PrintDocument

    Private lPageNo As String = ""
    Private sPageNo As String = ""
    Private oStringFormat As StringFormat
    Private oStringFormatComboBox As StringFormat
    Private oButton As Button
    Private oCheckbox As CheckBox
    Private oComboBox As ComboBox
    Private nTotalWidth As Int16
    Private nRowPos As Int16
    Private NewPage As Boolean
    Private nPageNo As Int16
    Private Header As String
    Private FooterComment As String = ""
    Private ImprimirPiedePagina As Boolean

    Public Sub StartPrint(ByVal GridToPrint As DataGridView, ByVal PrintAsLandscape As Boolean, ByVal ShowPrintPreview As Boolean, ByVal HeaderToPrint As String, ByVal CommentToPrint As String, Optional ByVal PiedePagina As Boolean = True)

        DataGridViewToPrint = GridToPrint
        Header = HeaderToPrint
        FooterComment = CommentToPrint
        ImprimirPiedePagina = PiedePagina

        'DataGridViewToPrint.Columns(2).Visible = False ' Use to hide a col. (index no.)

        ' Set up Default Page Settings
        DocToPrint.DefaultPageSettings.Landscape = PrintAsLandscape

        DocToPrint.DefaultPageSettings.Margins.Left = 25
        DocToPrint.DefaultPageSettings.Margins.Right = 75
        DocToPrint.DefaultPageSettings.Margins.Top = 25
        DocToPrint.DefaultPageSettings.Margins.Bottom = 75

        DocToPrint.OriginAtMargins = True ' takes margins into account 

        If ShowPrintPreview = True Then
            'ACA ISRA OJO ERROR QUE?
            'Dim dlgPrintPreview As New EnhancedPrintPreviewDialog
            Dim dlgPrintPreview As New PrintPreviewDialog

            dlgPrintPreview.ClientSize = New System.Drawing.Size(600, 600)
            dlgPrintPreview.Document = DocToPrint ' Previews print
            dlgPrintPreview.ShowDialog()

        Else

            '  Allow the user to choose a printer and specify other settings.
            Dim dlgPrint As New PrintDialog

            With dlgPrint
                .AllowSelection = False
                .ShowNetwork = False
                .AllowCurrentPage = True
                .AllowSomePages = True
                .Document = DocToPrint
            End With

            '  If the user clicked OK, print the document.
            If dlgPrint.ShowDialog = Windows.Forms.DialogResult.OK Then
                DocToPrint.Print()
            End If

        End If

    End Sub

    Public Sub DocToPrint_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles DocToPrint.BeginPrint

        oStringFormat = New StringFormat
        oStringFormat.Alignment = StringAlignment.Near
        oStringFormat.LineAlignment = StringAlignment.Center
        oStringFormat.Trimming = StringTrimming.EllipsisCharacter

        oStringFormatComboBox = New StringFormat
        oStringFormatComboBox.LineAlignment = StringAlignment.Center
        oStringFormatComboBox.FormatFlags = StringFormatFlags.NoWrap
        oStringFormatComboBox.Trimming = StringTrimming.EllipsisCharacter

        oButton = New Button
        oCheckbox = New CheckBox
        oComboBox = New ComboBox

        nTotalWidth = 0

        For Each oColumn As DataGridViewColumn In DataGridViewToPrint.Columns
            If oColumn.Visible = True Then ' Prints only Visible columns
                nTotalWidth += oColumn.Width
            End If
        Next

        nPageNo = 1
        NewPage = True
        nRowPos = 0

    End Sub

    Public Sub DocToPrint_EndPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles DocToPrint.EndPrint
        'Not currently used
    End Sub

    Public Sub DocToPrint_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles DocToPrint.PrintPage
        Static oColumnLefts As New ArrayList
        Static oColumnWidths As New ArrayList
        Static oColumnTypes As New ArrayList
        Static nHeight As Int16
        Dim FuenteCuadro As Font = New Drawing.Font("Verdana", 12)

        Dim nWidth, i, nRowsPerPage As Int16
        Dim nTop As Int16 = e.MarginBounds.Top
        Dim nLeft As Int16 = e.MarginBounds.Left

        If nPageNo = 1 Then

            oColumnLefts.Clear()
            oColumnWidths.Clear()
            oColumnTypes.Clear()

            For Each oColumn As DataGridViewColumn In DataGridViewToPrint.Columns
                If oColumn.Visible = True Then
                    nWidth = CType(Math.Floor(oColumn.Width / nTotalWidth * nTotalWidth * (e.MarginBounds.Width / nTotalWidth)), Int16)

                    nHeight = e.Graphics.MeasureString(oColumn.HeaderText, oColumn.InheritedStyle.Font, nWidth).Height + 11

                    oColumnLefts.Add(nLeft)
                    oColumnWidths.Add(nWidth)
                    oColumnTypes.Add(oColumn.GetType)
                    nLeft += nWidth
                End If
            Next

        End If

        Do While nRowPos < DataGridViewToPrint.Rows.Count

            Dim oRow As DataGridViewRow = DataGridViewToPrint.Rows(nRowPos)

            If nTop + nHeight >= e.MarginBounds.Height + e.MarginBounds.Top Then

                If ImprimirPiedePagina Then
                    DrawFooter(e, nRowsPerPage)
                End If

                NewPage = True
                nPageNo += 1
                e.HasMorePages = True
                Exit Sub

            Else

                If NewPage Then

                    ' Draw Header
                    If DataGridViewToPrint.Name = "dgvTYC" Then
                        e.Graphics.DrawString(Header, New Font(DataGridViewToPrint.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top - e.Graphics.MeasureString(Header, New Font(DataGridViewToPrint.Font, FontStyle.Bold), e.MarginBounds.Width).Height)
                    Else
                        e.Graphics.DrawString(Header, New Font(DataGridViewToPrint.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top - e.Graphics.MeasureString(Header, New Font(DataGridViewToPrint.Font, FontStyle.Bold), e.MarginBounds.Width).Height - 13)
                    End If

                    ' Draw Columns
                    nTop = e.MarginBounds.Top
                    i = 0
                    For Each oColumn As DataGridViewColumn In DataGridViewToPrint.Columns
                        If oColumn.Visible = True Then
                            e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight))
                            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight))
                            e.Graphics.DrawString(oColumn.HeaderText, oColumn.InheritedStyle.Font, New SolidBrush(oColumn.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i), nTop, oColumnWidths(i), nHeight), oStringFormat)
                            i += 1
                        End If

                    Next
                    NewPage = False

                End If

                nTop += nHeight


                i = 0

                For Each oCell As DataGridViewCell In oRow.Cells
                    If oCell.Visible = True Then
                        If oColumnTypes(i) Is GetType(DataGridViewTextBoxColumn) OrElse oColumnTypes(i) Is GetType(DataGridViewLinkColumn) Then
                            If DataGridViewToPrint.Name = "dgvTYC" Then
                                If (oCell.ColumnIndex = 0 Or oCell.ColumnIndex = 9 Or oCell.ColumnIndex = 18) Or oCell.RowIndex = 20 Then
                                    e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight))
                                    e.Graphics.DrawRectangle(Pens.Black, New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight))
                                End If
                                If oCell.ColumnIndex = 0 Then
                                    oStringFormat.Alignment = StringAlignment.Near
                                Else
                                    oStringFormat.Alignment = StringAlignment.Far
                                End If
                            End If

                            If DataGridViewToPrint.Name = "dgvComisiones" Then
                                If oCell.ColumnIndex > 1 And oCell.ColumnIndex <> 8 Then
                                    oStringFormat.Alignment = StringAlignment.Far
                                Else
                                    oStringFormat.Alignment = StringAlignment.Near
                                End If
                            End If

                            If DataGridViewToPrint.Name = "dgvVD" Then
                                If oCell.ColumnIndex = 2 Then
                                    oStringFormat.Alignment = StringAlignment.Far
                                Else
                                    oStringFormat.Alignment = StringAlignment.Near
                                End If
                            End If

                            If DataGridViewToPrint.Name = "dgvRanking" Then
                                oStringFormat.Alignment = StringAlignment.Far
                            End If

                            If DataGridViewToPrint.Name = "dgvReporte" Then 'Reporte de Pedidos (Depósito)
                                If oCell.ColumnIndex < 2 Then
                                    oStringFormat.Alignment = StringAlignment.Near
                                Else
                                    oStringFormat.Alignment = StringAlignment.Far
                                End If
                            End If

                            If DataGridViewToPrint.Name = "dgvReporte" Then 'Reporte de Pedidos (Depósito)
                                If oCell.Value <> "" Then e.Graphics.DrawString(oCell.Value.ToString, FuenteCuadro, New SolidBrush(oCell.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i), nTop, oColumnWidths(i), nHeight), oStringFormat)
                            Else
                                If IsNumeric(oCell.Value) Then
                                    e.Graphics.DrawString(oCell.Value.ToString, oCell.InheritedStyle.Font, New SolidBrush(oCell.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i), nTop, oColumnWidths(i), nHeight), oStringFormat)
                                Else
                                    If oCell.Value <> "" Then e.Graphics.DrawString(oCell.Value.ToString, oCell.InheritedStyle.Font, New SolidBrush(oCell.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i), nTop, oColumnWidths(i), nHeight), oStringFormat)
                                End If

                            End If
                        ElseIf oColumnTypes(i) Is GetType(DataGridViewButtonColumn) Then

                            oButton.Text = oCell.Value.ToString
                            oButton.Size = New Size(oColumnWidths(i), nHeight)
                            Dim oBitmap As New Bitmap(oButton.Width, oButton.Height)
                            oButton.DrawToBitmap(oBitmap, New Rectangle(0, 0, oBitmap.Width, oBitmap.Height))
                            e.Graphics.DrawImage(oBitmap, New Point(oColumnLefts(i), nTop))

                        ElseIf oColumnTypes(i) Is GetType(DataGridViewCheckBoxColumn) Then

                            oCheckbox.Size = New Size(14, 14)
                            oCheckbox.Checked = CType(oCell.Value, Boolean)
                            Dim oBitmap As New Bitmap(oColumnWidths(i), nHeight)
                            Dim oTempGraphics As Graphics = Graphics.FromImage(oBitmap)
                            oTempGraphics.FillRectangle(Brushes.White, New Rectangle(0, 0, oBitmap.Width, oBitmap.Height))
                            oCheckbox.DrawToBitmap(oBitmap, New Rectangle(CType((oBitmap.Width - oCheckbox.Width) / 2, Int32), CType((oBitmap.Height - oCheckbox.Height) / 2, Int32), oCheckbox.Width, oCheckbox.Height))
                            e.Graphics.DrawImage(oBitmap, New Point(oColumnLefts(i), nTop))

                        ElseIf oColumnTypes(i) Is GetType(DataGridViewComboBoxColumn) Then

                            oComboBox.Size = New Size(oColumnWidths(i), nHeight)
                            Dim oBitmap As New Bitmap(oComboBox.Width, oComboBox.Height)
                            oComboBox.DrawToBitmap(oBitmap, New Rectangle(0, 0, oBitmap.Width, oBitmap.Height))
                            e.Graphics.DrawImage(oBitmap, New Point(oColumnLefts(i), nTop))
                            e.Graphics.DrawString(oCell.Value.ToString, oCell.InheritedStyle.Font, New SolidBrush(oCell.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i) + 1, nTop, oColumnWidths(i) - 16, nHeight), oStringFormatComboBox)

                        ElseIf oColumnTypes(i) Is GetType(DataGridViewImageColumn) Then

                            Dim oCellSize As Rectangle = New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight)
                            Dim oImageSize As Size = CType(oCell.Value, Image).Size
                            e.Graphics.DrawImage(oCell.Value, New Rectangle(oColumnLefts(i) + CType(((oCellSize.Width - oImageSize.Width) / 2), Int32), nTop + CType(((oCellSize.Height - oImageSize.Height) / 2), Int32), CType(oCell.Value, Image).Width, CType(oCell.Value, Image).Height))

                        End If

                            e.Graphics.DrawRectangle(Pens.Black, New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight))

                            i += 1
                        End If
                Next

            End If

            nRowPos += 1
            nRowsPerPage += 1

        Loop

        If ImprimirPiedePagina Then
            DrawFooter(e, nRowsPerPage)
        End If

        e.HasMorePages = False

    End Sub

    Public Sub DrawFooter(ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal RowsPerPage As Int32)

        Dim sPageNo As String = nPageNo.ToString + " de "

        If nPageNo = "1" Then
            lPageNo = Math.Ceiling((DataGridViewToPrint.Rows.Count - 1) / RowsPerPage).ToString()
            sPageNo = nPageNo.ToString + " de " + lPageNo
        Else
            sPageNo = nPageNo.ToString + " de " + lPageNo
        End If

        ' Right Align - User Name
        e.Graphics.DrawString(FooterComment, DataGridViewToPrint.Font, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(FooterComment, DataGridViewToPrint.Font, e.MarginBounds.Width).Width), e.MarginBounds.Top + e.MarginBounds.Height + 7)

        ' Left Align - Date/Time
        e.Graphics.DrawString(Now.ToLongDateString + " " + Now.ToShortTimeString, DataGridViewToPrint.Font, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top + e.MarginBounds.Height + 7)

        ' Center - Page No. Info
        e.Graphics.DrawString(sPageNo, DataGridViewToPrint.Font, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(sPageNo, DataGridViewToPrint.Font, e.MarginBounds.Width).Width) / 2, e.MarginBounds.Top + e.MarginBounds.Height + 7)

    End Sub

End Module
