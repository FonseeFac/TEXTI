Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmHilaRepoHiladosStock

    Private nRowPos As Int16
    Private nRowPosRes As Int16
    Private YaVoyPorLosReservados As Boolean
    Private NewPage As Boolean
    Private nPageNo As Int16
    Private lPageNo As String = ""
    Private CORTE As String

    Dim LegajoLogueado As String 'legajo de quien va a trabajar
    Dim TipoUsuario As String ' Tipo de usuario que va a trabajar, lo voy a usar para saber que le habilito a usar y que no

    Dim TotalKilosGral As Double

    Sub New(ByVal parametro1 As String, ByVal parametro2 As String)

        InitializeComponent() 'es necesario que lleve esta linea

        LegajoLogueado = parametro1
        TipoUsuario = parametro2

    End Sub

    Private Sub CargarReporteHilados()
        'On Error GoTo ErrCargarReporteHilados
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr, FechaPartida As String

        Dim StockHilado As Double
        Dim TotalCommodities As Double
        Dim TotalCommoditiesReservado As Double
        Dim ultimoCodigoLeido As String = ""
        Dim row As String()
        Dim TotalHilado, TotalGral As Double
        Dim TotalReservado As Double
        Dim Observacion As String
        Dim CORTE, Prove, Tipo, Auxguardatxt, ArtIni, ArtFin As String


        CORTE = ""
        Prove = ""
        Tipo = ""

        If Not Validar() Then Exit Sub

        If txtCodArtDesde.Text <> "" Then txtCodArtDesde.Text = CInt(txtCodArtDesde.Text)
        If txtCodArtHasta.Text <> "" Then txtCodArtHasta.Text = CInt(txtCodArtHasta.Text)

        If txtCodArtDesde.Text <> "" And txtCodArtHasta.Text <> "" Then
            If CInt(txtCodArtDesde.Text) > CInt(txtCodArtHasta.Text) Then
                Auxguardatxt = txtCodArtDesde.Text
                txtCodArtDesde.Text = txtCodArtHasta.Text
                txtCodArtHasta.Text = Auxguardatxt
            End If
        End If

        If txtCodArtDesde.Text <> "" Then
            ArtIni = txtCodArtDesde.Text
        Else
            ArtIni = "0"
        End If

        If txtCodArtHasta.Text <> "" Then
            ArtFin = txtCodArtHasta.Text
        Else
            ArtFin = "999999"
        End If

        limpiaryarmarlosdgv()

        TotalCommoditiesReservado = 0
        TotalCommodities = 0
        TotalHilado = 0
        TotalGral = 0
        TotalReservado = 0
        TotalKilosGral = 0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        'sStr = "SELECT ("
        'sStr = sStr + " SELECT ISNULL(SUM(KILOS * (CASE E.TipoMov WHEN 'I' THEN 1 WHEN 'E' THEN -1 WHEN 'DI' THEN 1 WHEN 'C' THEN -1 END )),0) AS STOCKMOV "
        'sStr = sStr + " FROM HilamarHiladoStockEncMov E INNER JOIN HilamarHiladoStockDetMov D ON E.NroRemito = D.NroRemito AND E.TipoMov = D.TipoMov "
        'sStr = sStr + " WHERE ISNULL(E.Eliminado,0)=0 AND Isnull(D.Eliminado,0)=0 AND E.Fecha >=ISNULL(H.FechaStockDesde,'19000101') AND E.Fecha <= ISNULL(H.FechaStockHasta,GETDATE())"
        'sStr = sStr + " AND D.PARTIDA= H.Partida "
        'sStr = sStr + " ) as MOVIMIENTOS"
        'sStr = sStr + " ,H.id AS IDPARTIDA ,*"
        'sStr = sStr + " FROM HilamarTipoHiladoPartidas T INNER JOIN HilamarHiladoStock H ON H.Codtipohilado=T.Codigo"
        'sStr = sStr + " WHERE FECHASTOCKHASTA Is NULL"
        'sStr = sStr + " ORDER BY CodTipoHilado asc, EsDiscontinuada desc, Color asc "


        sStr = "SELECT ("
        sStr = sStr + " SELECT ISNULL(SUM(KILOS * (CASE E.TipoMov WHEN 'I' THEN 1 WHEN 'E' THEN -1 WHEN 'DI' THEN 1 WHEN 'C' THEN -1 END )),0) AS STOCKMOV "
        sStr = sStr + " FROM HilamarHiladoStockEncMov E INNER JOIN HilamarHiladoStockDetMov D ON E.NroRemito = D.NroRemito AND E.TipoMov = D.TipoMov "
        sStr = sStr + " WHERE ISNULL(E.Eliminado,0)=0 AND Isnull(D.Eliminado,0)=0 AND E.Fecha >=ISNULL(H.FechaStockDesde,'19000101') AND E.Fecha <= '" + Format(dtpALaFecha.Value, "yyyyMMdd") + "' "
        sStr = sStr + " AND D.PARTIDA= H.Partida "
        sStr = sStr + " ) as MOVIMIENTOS"
        sStr = sStr + " ,H.id AS IDPARTIDA ,Codigo,Kilos,CodTipoHilado,Proveedor,Descripcion,Observacion,FechaAltaPartida,EsDiscontinuada,Partida,ColorCono,Color,PCardado "
        sStr = sStr + " FROM HilamarTipoHiladoPartidas T INNER JOIN HilamarHiladoStock H ON H.Codtipohilado=T.Codigo"
        sStr = sStr + " WHERE (ISNULL(FECHASTOCKDESDE,'19000101') <='" + Format(dtpALaFecha.Value, "yyyyMMdd") + "' AND ISNULL(FechaStockHasta,GETDATE())>='" + Format(dtpALaFecha.Value, "yyyyMMdd") + "') "
        sStr = sStr + " AND ISNULL(H.Eliminado,0) =0 "
        sStr = sStr + " ORDER BY CodTipoHilado asc, EsDiscontinuada desc, Color asc "

      

        'sStr = "SELECT * FROM HilamarHiladoStock H INNER JOIN HilamarTipoHiladoPartidas T ON H.Codtipohilado=T.Codigo "
        'sStr = sStr + " WHERE KILOS > 0 order by CodTipoHilado,Color"

        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read

                If Reader.Item("Codigo").ToString = "496" Then
                    Dim asd As Integer
                    asd = 12
                End If


                StockHilado = CDbl(Reader.Item("Kilos")) + CDbl(Reader.Item("MOVIMIENTOS"))
                If StockHilado > 0 Then
                    If CORTE <> Reader.Item("Codtipohilado").ToString Then
                        If CORTE = "" Then
                            CORTE = Reader.Item("Codtipohilado").ToString
                            Prove = Reader.Item("Proveedor").ToString
                            Tipo = Reader.Item("Descripcion").ToString
                            TotalHilado = 0
                        Else
                            If CInt(CORTE) >= CInt(ArtIni) And CInt(CORTE) <= CInt(ArtFin) Then
                                'row = {CORTE, Prove, Tipo, Format(TotalHilado, "0.000")}
                                row = {CORTE, Prove, Tipo, TotalHilado}
                                dgvHilados.Rows.Add(row)
                            End If
                            CORTE = Reader.Item("Codtipohilado").ToString
                            Prove = Reader.Item("Proveedor").ToString
                            Tipo = Reader.Item("Descripcion").ToString
                            TotalHilado = 0
                        End If
                    End If
                    If IsDBNull(Reader.Item("Observacion")) Then
                        Observacion = ""
                    Else
                        Observacion = Reader.Item("Observacion")
                    End If

                    If IsDBNull(Reader.Item("FECHAALTAPARTIDA")) Then
                        FechaPartida = "SIN FECHA"
                    Else
                        FechaPartida = Format(Reader.Item("FECHAALTAPARTIDA"), "dd/MM/yyyy")
                    End If
                    If IsDBNull(Reader.Item("ColorCono")) Then

                        'row = {Reader.Item("Codtipohilado").ToString, Reader.Item("Partida").ToString, Reader.Item("CodColor").ToString, Reader.Item("Color").ToString, Format(StockHilado, "0.000"), Reader.Item("PCardado"), Observacion, Reader.Item("EsDiscontinuada").ToString, Reader.Item("IDPARTIDA").ToString, FechaPartida}
                        row = {Reader.Item("Codtipohilado").ToString, Reader.Item("Partida").ToString, Reader.Item("CodColor").ToString, Reader.Item("Color").ToString, StockHilado, Reader.Item("PCardado"), Observacion, Reader.Item("EsDiscontinuada").ToString, Reader.Item("IDPARTIDA").ToString, FechaPartida, Reader.Item("Descripcion").ToString}
                    Else
                        'row = {Reader.Item("Codtipohilado").ToString, Reader.Item("Partida").ToString, Reader.Item("ColorCono").ToString, Reader.Item("Color").ToString, Format(StockHilado, "0.000"), Reader.Item("PCardado"), Observacion, Reader.Item("EsDiscontinuada").ToString, Reader.Item("IDPARTIDA").ToString, FechaPartida}
                        row = {Reader.Item("Codtipohilado").ToString, Reader.Item("Partida").ToString, Reader.Item("ColorCono").ToString, Reader.Item("Color").ToString, StockHilado, Reader.Item("PCardado"), Observacion, Reader.Item("EsDiscontinuada").ToString, Reader.Item("IDPARTIDA").ToString, FechaPartida, Reader.Item("Descripcion").ToString}
                    End If
                    dgvPartidas.Rows.Add(row)
                    If Reader.Item("EsDiscontinuada").ToString = "1" Then
                        dgvPartidas.Rows(dgvPartidas.RowCount - 1).DefaultCellStyle.BackColor = Color.FromArgb(253, 253, 150)
                    End If
                    TotalGral = TotalGral + StockHilado
                    If InStr(Reader.Item("Partida").ToString, "/C") > 0 And InStr(Reader.Item("Partida").ToString, "H") > 0 Then
                        TotalCommodities = TotalCommodities + StockHilado
                    ElseIf InStr(Reader.Item("Partida").ToString, "/C") > 0 And InStr(Reader.Item("Partida").ToString, "G") > 0 Then
                        TotalCommoditiesReservado = TotalCommoditiesReservado + StockHilado
                    ElseIf InStr(Reader.Item("Partida").ToString, "G") > 0 And InStr(Reader.Item("Partida").ToString, "/C") <= 0 Then
                        TotalReservado = TotalReservado + StockHilado
                    Else
                        TotalHilado = TotalHilado + StockHilado
                    End If
                ultimoCodigoLeido = Reader.Item("Codtipohilado").ToString
                End If
            Loop
            Reader.NextResult()
        Loop

        'al final muestro el ultimo corte 
        If CInt(CORTE) >= CInt(ArtIni) And CInt(CORTE) <= CInt(ArtFin) Then
            'row = {CORTE, Prove, Tipo, Format(TotalHilado, "0.000")}
            row = {CORTE, Prove, Tipo, TotalHilado}
            dgvHilados.Rows.Add(row)
        End If

        ' al final agrego una nueva linea con el resumen hilados reservados
        'row = {"RESERVADO", "RESERVADO", "RESERVADO", Format(TotalReservado, "0.000")}
        row = {"RESERVADO", "RESERVADO", "RESERVADO", TotalReservado}
        dgvHilados.Rows.Add(row)

        ' ''Agrego linea de commodities
        row = {"COMMODITIES", "COMMODITIES", "COMMODITIES", TotalCommodities}
        dgvHilados.Rows.Add(row)

        ' ''Agrego linea Commodities reservados 
        row = {"COMMODITIES RES", "COMMODITIES RES", "COMMODITIES RESERVADOS", TotalCommoditiesReservado}
        dgvHilados.Rows.Add(row)

        TotalKilosGral = TotalGral
        'lblTotalGral.Text = "TOTAL GENERAL EN EXISTENCIA :  " + Format(TotalGral, "0.000") + " KGR."
        lblTotalGral.Text = "TOTAL GENERAL EN EXISTENCIA :  " + TotalGral.ToString + " KGR."



        'cuando termino simulo un click en la primer fila asi quedan filtradas las partidas del primer hilado
        If dgvHilados.RowCount > 0 Then
            dgvHilados.Rows(0).Selected = True
            FiltrarDGVPartidas(dgvHilados.Rows(0).Cells(0).Value.ToString)
        End If

        Exit Sub
ErrCargarReporteHilados:
        If Err.Number = 57 Then
            MensajeCritico("Archivo de existencias de hilados en uso. Intente nuevamente en otro momento.")
        Else
            MensajeCritico("Error al recuperar las existencias de hilado.")
        End If

    End Sub

    Private Sub limpiaryarmarlosdgv()
        dgvHilados.Rows.Clear()
        dgvHilados.Columns.Clear()
        dgvHilados.Columns.Add("CODIGO", "CODIGO")
        dgvHilados.Columns("CODIGO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvHilados.Columns("CODIGO").Width = 60
        dgvHilados.Columns("CODIGO").ReadOnly = True
        dgvHilados.Columns.Add("PROVE", "PROVE")
        dgvHilados.Columns("PROVE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvHilados.Columns("PROVE").Width = 90
        dgvHilados.Columns("PROVE").ReadOnly = True
        dgvHilados.Columns("PROVE").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvHilados.Columns.Add("TIPO", "TIPO")
        dgvHilados.Columns("TIPO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvHilados.Columns("TIPO").Width = 160
        dgvHilados.Columns("TIPO").ReadOnly = True
        dgvHilados.Columns("TIPO").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvHilados.Columns.Add("KILOS", "KILOS")
        dgvHilados.Columns("KILOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvHilados.Columns("KILOS").DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Regular)
        dgvHilados.Columns("KILOS").Width = 80
        dgvHilados.Columns("KILOS").ReadOnly = True
        dgvHilados.Columns("KILOS").SortMode = DataGridViewColumnSortMode.NotSortable

        dgvPartidas.Rows.Clear()
        dgvPartidas.Columns.Clear()
        dgvPartidas.Columns.Add("CODIS", "CODIS")
        dgvPartidas.Columns("CODIS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPartidas.Columns("CODIS").Visible = False
        dgvPartidas.Columns.Add("PARTIDA", "PARTIDA")
        dgvPartidas.Columns("PARTIDA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPartidas.Columns("PARTIDA").Width = 85
        dgvPartidas.Columns("PARTIDA").ReadOnly = True
        dgvPartidas.Columns.Add("NROCOLOR", "NRO.COLOR")
        dgvPartidas.Columns("NROCOLOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPartidas.Columns("NROCOLOR").Width = 90
        dgvPartidas.Columns("NROCOLOR").ReadOnly = True
        dgvPartidas.Columns("NROCOLOR").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvPartidas.Columns.Add("COLOR", "COLOR")
        dgvPartidas.Columns("COLOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPartidas.Columns("COLOR").Width = 140
        dgvPartidas.Columns("COLOR").ReadOnly = True
        dgvPartidas.Columns("COLOR").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvPartidas.Columns.Add("STOCKACTUAL", "STOCK")
        dgvPartidas.Columns("STOCKACTUAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvPartidas.Columns("STOCKACTUAL").DefaultCellStyle.Font = New Font("Arial", 9, FontStyle.Regular)
        dgvPartidas.Columns("STOCKACTUAL").Width = 90
        dgvPartidas.Columns("STOCKACTUAL").ReadOnly = True
        dgvPartidas.Columns.Add("PCARDADO", "P.CARDADO")
        dgvPartidas.Columns("PCARDADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvPartidas.Columns("PCARDADO").Width = 100
        dgvPartidas.Columns("PCARDADO").ReadOnly = True
        dgvPartidas.Columns.Add("OBSERVACION", "OBSERVACION")
        dgvPartidas.Columns("OBSERVACION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPartidas.Columns("OBSERVACION").Width = 115
        dgvPartidas.Columns("OBSERVACION").ReadOnly = True
        dgvPartidas.Columns.Add("ESDISCONTINUADA", "ESDISCONTINUADA")
        dgvPartidas.Columns("ESDISCONTINUADA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvPartidas.Columns("ESDISCONTINUADA").Visible = False
        dgvPartidas.Columns.Add("IDPARTIDA", "IDPARTIDA")
        dgvPartidas.Columns("IDPARTIDA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvPartidas.Columns("IDPARTIDA").Visible = False
        dgvPartidas.Columns.Add("FECHAALTAPARTIDA", "FECHA ALTA")
        dgvPartidas.Columns("FECHAALTAPARTIDA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvPartidas.Columns("FECHAALTAPARTIDA").Visible = True
        dgvPartidas.Columns.Add("HILADO", "HILADO")
        dgvPartidas.Columns("HILADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPartidas.Columns("HILADO").Visible = False


        dgvPartidas.RowTemplate.Height = 19
    End Sub

    Private Sub cmdImpPlanilla_Click(sender As System.Object, e As System.EventArgs) Handles cmdImpPlanilla.Click
        If dgvHilados.RowCount <= 0 Then Exit Sub

        CalculoCantidaddeHojas()

        pdoImpExistencias.DefaultPageSettings.Landscape = True
        pdoImpExistencias.DefaultPageSettings.Margins.Left = 20
        pdoImpExistencias.DefaultPageSettings.Margins.Right = 20
        pdoImpExistencias.DefaultPageSettings.Margins.Top = 20
        pdoImpExistencias.DefaultPageSettings.Margins.Bottom = 20
        pdoImpExistencias.OriginAtMargins = True ' takes margins into account 

        Dim dlgPrintPreview As New EnhancedPrintPreviewDialog
        dlgPrintPreview.ClientSize = New System.Drawing.Size(600, 600)
        dlgPrintPreview.Document = pdoImpExistencias ' Previews print
        dlgPrintPreview.ShowDialog()

        'pdoImpExistencias.Print()

    End Sub

    Private Sub pdoImpExistencias_BeginPrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles pdoImpExistencias.BeginPrint
        nRowPos = 0
        nRowPosRes = 0
        YaVoyPorLosReservados = False
        NewPage = True
        nPageNo = 1
        CORTE = ""
    End Sub

    Private Sub pdoImpExistencias_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdoImpExistencias.PrintPage
        On Error Resume Next

        Dim ArtIni, ArtFin As String
        Dim AuxFila As Integer

        Dim FuenteLineas As Font = New Drawing.Font("Arial", 10, FontStyle.Regular)
        Dim FuenteLineas8 As Font = New Drawing.Font("Arial", 8, FontStyle.Regular)
        Dim FuenteLineas8Neg As Font = New Drawing.Font("Arial", 8, FontStyle.Bold)
        Dim FuenteTituloEnc As Font = New Drawing.Font("Arial", 12, FontStyle.Regular)
        Dim FuenteTituloEnc11 As Font = New Drawing.Font("Arial", 11, FontStyle.Bold)

        Dim nTop As Int16 = e.MarginBounds.Top

        If txtCodArtDesde.Text <> "" Then
            ArtIni = txtCodArtDesde.Text
        Else
            ArtIni = "0"
        End If
        If txtCodArtHasta.Text <> "" Then
            ArtFin = txtCodArtHasta.Text
        Else
            ArtFin = "999999"
        End If


        Do While nRowPos < dgvPartidas.RowCount

            'If nTop > e.MarginBounds.Height - e.MarginBounds.Top - 30 Then
            If nTop > 750 Then
                ' las lineas verticales
                e.Graphics.DrawLine(Pens.Black, 5, 44, 5, nTop)
                e.Graphics.DrawLine(Pens.Black, 205, 44, 205, nTop)
                e.Graphics.DrawLine(Pens.Black, 285, 44, 285, nTop)
                e.Graphics.DrawLine(Pens.Black, 455, 44, 455, nTop)
                e.Graphics.DrawLine(Pens.Black, 545, 44, 545, nTop)
                e.Graphics.DrawLine(Pens.Black, 635, 44, 635, nTop)
                e.Graphics.DrawLine(Pens.Black, 735, 44, 735, nTop)
                e.Graphics.DrawLine(Pens.Black, 908, 44, 908, nTop)
                e.Graphics.DrawLine(Pens.Black, 1150, 44, 1150, nTop)

                'LUEGO EL PIE DE PAGINA
                DrawFooter(e)

                nPageNo += 1
                NewPage = True
                e.HasMorePages = True
                Exit Sub

            Else

                If NewPage Then

                    ' Draw Header
                    e.Graphics.DrawString("TEXTILANA S.A.", FuenteTituloEnc11, Brushes.Black, 500, nTop - 16)
                    e.Graphics.DrawString("EXISTENCIAS DE HILADO AL " + Format(dtpALaFecha.Value, "dd/MM/yyyy"), FuenteTituloEnc, Brushes.Black, 100, nTop)
                    e.Graphics.DrawString("TOTAL KG:", FuenteTituloEnc, Brushes.Black, 895, nTop)
                    e.Graphics.DrawString(TotalKilosGral, FuenteTituloEnc, Brushes.Black, 1060 - e.Graphics.MeasureString(TotalKilosGral.ToString, FuenteTituloEnc).Width, nTop)
                    nTop = nTop + 24

                    'LOS ENCABEZADOS DE LA TABLA
                    e.Graphics.DrawLine(Pens.Black, 5, nTop, 1150, nTop)
                    nTop = nTop + 2
                    e.Graphics.DrawString("ARTICULO", FuenteLineas, Brushes.Black, 10, nTop) '200
                    e.Graphics.DrawString("PARTIDA", FuenteLineas, Brushes.Black, 210, nTop) '80
                    e.Graphics.DrawString("COLOR", FuenteLineas, Brushes.Black, 290, nTop) '170
                    e.Graphics.DrawString("STOCK", FuenteLineas, Brushes.Black, 460, nTop) '90
                    e.Graphics.DrawString("TOTAL", FuenteLineas, Brushes.Black, 550, nTop) '90
                    e.Graphics.DrawString("FECHA ALTA", FuenteLineas, Brushes.Black, 640 - 2, nTop) '100 ' le resto 2 para que el texto no pegue con la linea vertical de la izquierda
                    e.Graphics.DrawString("CONO", FuenteLineas, Brushes.Black, 740, nTop) '170
                    e.Graphics.DrawString("OBSERVACIÓN", FuenteLineas, Brushes.Black, 910, nTop)
                    nTop = nTop + 20
                    e.Graphics.DrawLine(Pens.Black, 5, nTop, 1150, nTop)
                    nTop = nTop + 2

                    NewPage = False

                End If



                If InStr(dgvPartidas.Rows(nRowPos).Cells("PARTIDA").Value.ToString, "G") <= 0 And CInt(dgvPartidas.Rows(nRowPos).Cells("COMMODITIE").Value) = 0 Then

                    If CORTE <> dgvPartidas.Rows(nRowPos).Cells("CODIS").Value.ToString Then
                        If CORTE = "" Then
                            CORTE = dgvPartidas.Rows(nRowPos).Cells("CODIS").Value.ToString
                        Else
                            If CInt(CORTE) >= CInt(ArtIni) And CInt(CORTE) <= CInt(ArtFin) Then
                                'LOS KG TOTALDEL HILADO
                                AuxFila = ObtenerFiladelHiladoconelCodigo(CORTE)
                                e.Graphics.DrawString(dgvHilados.Rows(AuxFila).Cells("KILOS").Value.ToString, FuenteLineas8Neg, Brushes.Black, 585 - e.Graphics.MeasureString(dgvHilados.Rows(AuxFila).Cells("KILOS").Value.ToString, FuenteLineas8Neg).Width, nTop - 18)
                                'UNA LINEA PARA QUE EL TOTAL QUEDE CON UNA LINEA DOBLE ABAJO
                                e.Graphics.DrawLine(Pens.Black, 5, nTop - 2, 1150, nTop - 2)
                                'Y EL CIERRE DE LA LINEA
                                e.Graphics.DrawLine(Pens.Black, 5, nTop, 210, nTop)
                                'DEJO UN POCO DE LUGAR HASTA EL PROXIMO
                                e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.Gray), New Rectangle(5, nTop, 1145, 12))
                                nTop += 15
                            End If
                            CORTE = dgvPartidas.Rows(nRowPos).Cells("CODIS").Value.ToString
                        End If

                        'EL CODIGO Y LA DESCRIPCION DEL HILADO
                        AuxFila = ObtenerFiladelHiladoconelCodigo(CORTE)
                        e.Graphics.DrawString(dgvHilados.Rows(AuxFila).Cells("CODIGO").Value + "-" + dgvHilados.Rows(AuxFila).Cells("TIPO").Value, FuenteLineas8Neg, Brushes.Black, New RectangleF(10, nTop, 200, 18))

                    End If

                    If CInt(CORTE) >= CInt(ArtIni) And CInt(CORTE) <= CInt(ArtFin) Then

                        If dgvPartidas.Rows(nRowPos).Cells("ESDISCONTINUADA").Value.ToString = "1" Then
                            e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(206, nTop, 1140, 17))
                        End If

                        'e.Graphics.DrawString(dgvPartidas.Rows(nRowPos).Cells("PARTIDA").Value, FuenteLineas8, Brushes.Black, New RectangleF(210, nTop, 80, 18))
                        e.Graphics.DrawString(SacoCerosIzquierdaDePartida(dgvPartidas.Rows(nRowPos).Cells("PARTIDA").Value), FuenteLineas8, Brushes.Black, New RectangleF(210, nTop, 80, 18))
                        e.Graphics.DrawString(dgvPartidas.Rows(nRowPos).Cells("COLOR").Value, FuenteLineas8, Brushes.Black, New RectangleF(290, nTop, 170, 18))
                        e.Graphics.DrawString(dgvPartidas.Rows(nRowPos).Cells("STOCKACTUAL").Value, FuenteLineas8, Brushes.Black, 490 - e.Graphics.MeasureString(dgvPartidas.Rows(nRowPos).Cells(4).Value.ToString, FuenteLineas8).Width, nTop)
                        e.Graphics.DrawString(dgvPartidas.Rows(nRowPos).Cells("FECHAALTAPARTIDA").Value, FuenteLineas8, Brushes.Black, 640, nTop)
                        e.Graphics.DrawString(dgvPartidas.Rows(nRowPos).Cells("NROCOLOR").Value, FuenteLineas8, Brushes.Black, New RectangleF(740, nTop, 170, 18))
                        e.Graphics.DrawString(Strings.Left(dgvPartidas.Rows(nRowPos).Cells("OBSERVACION").Value, 40), FuenteLineas8, Brushes.Black, 910, nTop)
                        nTop = nTop + 18
                        e.Graphics.DrawLine(Pens.Black, 205, nTop, 1150, nTop)

                    End If

                End If

            End If
            nRowPos += 1
        Loop

        If Not YaVoyPorLosReservados Then
            'al final imprimo el ultimo corte
            If CInt(CORTE) >= CInt(ArtIni) And CInt(CORTE) <= CInt(ArtFin) Then
                AuxFila = ObtenerFiladelHiladoconelCodigo(CORTE)
                'EL CODIGO Y LA DESCRIPCION DEL HILADO
                'e.Graphics.DrawString(dgvHilados.Rows(AuxFila).Cells("CODIGO").Value + "-" + dgvHilados.Rows(AuxFila).Cells("TIPO").Value, FuenteLineas8Neg, Brushes.Black, New RectangleF(10, nTopParaEncabezado, 200, 18))
                'LOS KG TOTALDEL HILADO
                e.Graphics.DrawString(dgvHilados.Rows(AuxFila).Cells("KILOS").Value.ToString, FuenteLineas8Neg, Brushes.Black, 585 - e.Graphics.MeasureString(dgvHilados.Rows(AuxFila).Cells("KILOS").Value.ToString, FuenteLineas8Neg).Width, nTop - 18)
                'UNA LI´NEA PARA QUE EL TOTAL QUEDE CON UNA LINEA DOBLE ABAJO
                e.Graphics.DrawLine(Pens.Black, 5, nTop - 2, 1150, nTop - 2)
                'Y EL CIERRE DE LA LINEA
                e.Graphics.DrawLine(Pens.Black, 5, nTop, 210, nTop)
                'DEJO UN POCO DE LUGAR HASTA EL PROXIMO
                e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.Gray), New Rectangle(5, nTop, 1145, 12))
                nTop += 15
            End If
        End If

        ''''''''''' al final imprimo el detalle de los RESERVADOS

        YaVoyPorLosReservados = True
        AuxFila = -1


        Do While nRowPosRes < dgvPartidas.RowCount

            'If nTop > e.MarginBounds.Height - e.MarginBounds.Top - 30 Then
            If nTop > 750 Then
                ' las lineas verticales
                e.Graphics.DrawLine(Pens.Black, 5, 44, 5, nTop)
                e.Graphics.DrawLine(Pens.Black, 205, 44, 205, nTop)
                e.Graphics.DrawLine(Pens.Black, 285, 44, 285, nTop)
                e.Graphics.DrawLine(Pens.Black, 455, 44, 455, nTop)
                e.Graphics.DrawLine(Pens.Black, 545, 44, 545, nTop)
                e.Graphics.DrawLine(Pens.Black, 635, 44, 635, nTop)
                e.Graphics.DrawLine(Pens.Black, 735, 44, 735, nTop)
                e.Graphics.DrawLine(Pens.Black, 908, 44, 908, nTop)
                e.Graphics.DrawLine(Pens.Black, 1150, 44, 1150, nTop)

                'LUEGO EL PIE DE PAGINA
                DrawFooter(e)

                nPageNo += 1
                NewPage = True
                e.HasMorePages = True
                Exit Sub

            Else

                If NewPage Then

                    ' Draw Header
                    e.Graphics.DrawString("TEXTILANA S.A.", FuenteTituloEnc11, Brushes.Black, 500, nTop - 16)
                    e.Graphics.DrawString("EXISTENCIAS DE HILADO AL " + Format(dtpALaFecha.Value, "dd/MM/yyyy"), FuenteTituloEnc, Brushes.Black, 100, nTop)
                    e.Graphics.DrawString("TOTAL KG:", FuenteTituloEnc, Brushes.Black, 895, nTop)
                    e.Graphics.DrawString(TotalKilosGral, FuenteTituloEnc, Brushes.Black, 1060 - e.Graphics.MeasureString(TotalKilosGral.ToString, FuenteTituloEnc).Width, nTop)
                    nTop = nTop + 24

                    'LOS ENCABEZADOS DE LA TABLA
                    e.Graphics.DrawLine(Pens.Black, 5, nTop, 1150, nTop)
                    nTop = nTop + 2
                    e.Graphics.DrawString("ARTICULO", FuenteLineas, Brushes.Black, 10, nTop) '200
                    e.Graphics.DrawString("PARTIDA", FuenteLineas, Brushes.Black, 210, nTop) '80
                    e.Graphics.DrawString("COLOR", FuenteLineas, Brushes.Black, 290, nTop) '170
                    e.Graphics.DrawString("STOCK", FuenteLineas, Brushes.Black, 460, nTop) '90
                    e.Graphics.DrawString("TOTAL", FuenteLineas, Brushes.Black, 550, nTop) '90
                    e.Graphics.DrawString("FECHA ALTA", FuenteLineas, Brushes.Black, 640 - 2, nTop) '100 ' le resto 2 para que el texto no pegue con la linea vertical de la izquierda
                    e.Graphics.DrawString("CONO", FuenteLineas, Brushes.Black, 740, nTop) '170
                    e.Graphics.DrawString("OBSERVACIÓN", FuenteLineas, Brushes.Black, 910, nTop)
                    nTop = nTop + 20
                    e.Graphics.DrawLine(Pens.Black, 5, nTop, 1150, nTop)
                    nTop = nTop + 2

                    NewPage = False

                End If

                If InStr(dgvPartidas.Rows(nRowPosRes).Cells("PARTIDA").Value.ToString, "G") > 0 And CInt(dgvPartidas.Rows(nRowPosRes).Cells("COMMODITIE").Value) = 0 Then

                    If dgvPartidas.Rows(nRowPosRes).Cells("ESDISCONTINUADA").Value.ToString = "1" Then
                        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(206, nTop, 1140, 17))
                    End If

                    If AuxFila < 0 Then
                        AuxFila = ObtenerFiladelHiladoconelCodigo("RESERVADO")
                        'EL CODIGO Y LA DESCRIPCION DEL HILADO
                        e.Graphics.DrawString(dgvHilados.Rows(AuxFila).Cells("CODIGO").Value + "-" + dgvHilados.Rows(AuxFila).Cells("TIPO").Value, FuenteLineas8Neg, Brushes.Black, New RectangleF(10, nTop, 200, 18))
                    End If

                    'e.Graphics.DrawString(dgvPartidas.Rows(nRowPosRes).Cells("PARTIDA").Value, FuenteLineas8, Brushes.Black, New RectangleF(210, nTop, 80, 18))
                    e.Graphics.DrawString(SacoCerosIzquierdaDePartida(dgvPartidas.Rows(nRowPosRes).Cells("PARTIDA").Value), FuenteLineas8, Brushes.Black, New RectangleF(210, nTop, 80, 18))
                    e.Graphics.DrawString(dgvPartidas.Rows(nRowPosRes).Cells("COLOR").Value, FuenteLineas8, Brushes.Black, New RectangleF(290, nTop, 170, 18))
                    e.Graphics.DrawString(dgvPartidas.Rows(nRowPosRes).Cells("STOCKACTUAL").Value, FuenteLineas8, Brushes.Black, 490 - e.Graphics.MeasureString(dgvPartidas.Rows(nRowPosRes).Cells(4).Value.ToString, FuenteLineas8).Width, nTop)
                    e.Graphics.DrawString(dgvPartidas.Rows(nRowPosRes).Cells("FECHAALTAPARTIDA").Value, FuenteLineas8, Brushes.Black, 640, nTop)
                    e.Graphics.DrawString(dgvPartidas.Rows(nRowPosRes).Cells("NROCOLOR").Value, FuenteLineas8, Brushes.Black, New RectangleF(740, nTop, 170, 18))
                    e.Graphics.DrawString(Strings.Left(dgvPartidas.Rows(nRowPosRes).Cells("OBSERVACION").Value, 40), FuenteLineas8, Brushes.Black, 910, nTop)

                    nTop = nTop + 18
                    e.Graphics.DrawLine(Pens.Black, 205, nTop, 1150, nTop)

                End If

            End If
            nRowPosRes += 1
        Loop

        'al final imprimo el ultimo corte
        AuxFila = ObtenerFiladelHiladoconelCodigo("RESERVADO")
        'EL CODIGO Y LA DESCRIPCION DEL HILADO
        'e.Graphics.DrawString(dgvHilados.Rows(AuxFila).Cells("CODIGO").Value + "-" + dgvHilados.Rows(AuxFila).Cells("TIPO").Value, FuenteLineas8Neg, Brushes.Black, New RectangleF(10, nTopParaEncabezado, 200, 18))
        'LOS KG TOTALDEL HILADO
        e.Graphics.DrawString(dgvHilados.Rows(AuxFila).Cells("KILOS").Value.ToString, FuenteLineas8Neg, Brushes.Black, 585 - e.Graphics.MeasureString(dgvHilados.Rows(AuxFila).Cells("KILOS").Value.ToString, FuenteLineas8Neg).Width, nTop - 18)
        'UNA LINEA PARA QUE EL TOTAL QUEDE CON UNA LINEA DOBLE ABAJO
        e.Graphics.DrawLine(Pens.Black, 5, nTop - 2, 1150, nTop - 2)
        'Y EL CIERRE DE LA LINEA
        e.Graphics.DrawLine(Pens.Black, 5, nTop, 210, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.Gray), New Rectangle(5, nTop, 1145, 12))
        nTop += 15




        ''Imprimo los Commodities
        nRowPosRes = 0
        AuxFila = -1

        Do While nRowPosRes < dgvPartidas.RowCount

            'If nTop > e.MarginBounds.Height - e.MarginBounds.Top - 30 Then
            If nTop > 750 Then
                ' las lineas verticales
                e.Graphics.DrawLine(Pens.Black, 5, 44, 5, nTop)
                e.Graphics.DrawLine(Pens.Black, 205, 44, 205, nTop)
                e.Graphics.DrawLine(Pens.Black, 285, 44, 285, nTop)
                e.Graphics.DrawLine(Pens.Black, 455, 44, 455, nTop)
                e.Graphics.DrawLine(Pens.Black, 545, 44, 545, nTop)
                e.Graphics.DrawLine(Pens.Black, 635, 44, 635, nTop)
                e.Graphics.DrawLine(Pens.Black, 735, 44, 735, nTop)
                e.Graphics.DrawLine(Pens.Black, 908, 44, 908, nTop)
                e.Graphics.DrawLine(Pens.Black, 1150, 44, 1150, nTop)

                'LUEGO EL PIE DE PAGINA
                DrawFooter(e)

                nPageNo += 1
                NewPage = True
                e.HasMorePages = True
                Exit Sub

            Else

                If NewPage Then

                    ' Draw Header
                    e.Graphics.DrawString("TEXTILANA S.A.", FuenteTituloEnc11, Brushes.Black, 500, nTop - 16)
                    e.Graphics.DrawString("EXISTENCIAS DE HILADO AL " + Format(dtpALaFecha.Value, "dd/MM/yyyy"), FuenteTituloEnc, Brushes.Black, 100, nTop)
                    e.Graphics.DrawString("TOTAL KG:", FuenteTituloEnc, Brushes.Black, 895, nTop)
                    e.Graphics.DrawString(TotalKilosGral, FuenteTituloEnc, Brushes.Black, 1060 - e.Graphics.MeasureString(TotalKilosGral.ToString, FuenteTituloEnc).Width, nTop)
                    nTop = nTop + 24

                    'LOS ENCABEZADOS DE LA TABLA
                    e.Graphics.DrawLine(Pens.Black, 5, nTop, 1150, nTop)
                    nTop = nTop + 2
                    e.Graphics.DrawString("ARTICULO", FuenteLineas, Brushes.Black, 10, nTop) '200
                    e.Graphics.DrawString("PARTIDA", FuenteLineas, Brushes.Black, 210, nTop) '80
                    e.Graphics.DrawString("COLOR", FuenteLineas, Brushes.Black, 290, nTop) '170
                    e.Graphics.DrawString("STOCK", FuenteLineas, Brushes.Black, 460, nTop) '90
                    e.Graphics.DrawString("TOTAL", FuenteLineas, Brushes.Black, 550, nTop) '90
                    e.Graphics.DrawString("FECHA ALTA", FuenteLineas, Brushes.Black, 640 - 2, nTop) '100 ' le resto 2 para que el texto no pegue con la linea vertical de la izquierda
                    e.Graphics.DrawString("CONO", FuenteLineas, Brushes.Black, 740, nTop) '170
                    e.Graphics.DrawString("OBSERVACIÓN", FuenteLineas, Brushes.Black, 910, nTop)
                    nTop = nTop + 20
                    e.Graphics.DrawLine(Pens.Black, 5, nTop, 1150, nTop)
                    nTop = nTop + 2

                    NewPage = False

                End If

                If InStr(dgvPartidas.Rows(nRowPosRes).Cells("PARTIDA").Value.ToString, "H") > 0 And CInt(dgvPartidas.Rows(nRowPosRes).Cells("COMMODITIE").Value) = 1 Then

                    If dgvPartidas.Rows(nRowPosRes).Cells("ESDISCONTINUADA").Value.ToString = "1" Then
                        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(206, nTop, 1140, 17))
                    End If

                    If AuxFila < 0 Then
                        AuxFila = ObtenerFiladelHiladoconelCodigo("COMMODITIES")
                        'EL CODIGO Y LA DESCRIPCION DEL HILADO
                        e.Graphics.DrawString(dgvHilados.Rows(AuxFila).Cells("CODIGO").Value + "-" + dgvHilados.Rows(AuxFila).Cells("TIPO").Value, FuenteLineas8Neg, Brushes.Black, New RectangleF(10, nTop, 200, 18))
                    End If

                    'e.Graphics.DrawString(dgvPartidas.Rows(nRowPosRes).Cells("PARTIDA").Value, FuenteLineas8, Brushes.Black, New RectangleF(210, nTop, 80, 18))
                    e.Graphics.DrawString(SacoCerosIzquierdaDePartida(dgvPartidas.Rows(nRowPosRes).Cells("PARTIDA").Value), FuenteLineas8, Brushes.Black, New RectangleF(210, nTop, 80, 18))
                    e.Graphics.DrawString(dgvPartidas.Rows(nRowPosRes).Cells("COLOR").Value, FuenteLineas8, Brushes.Black, New RectangleF(290, nTop, 170, 18))
                    e.Graphics.DrawString(dgvPartidas.Rows(nRowPosRes).Cells("STOCKACTUAL").Value, FuenteLineas8, Brushes.Black, 490 - e.Graphics.MeasureString(dgvPartidas.Rows(nRowPosRes).Cells(4).Value.ToString, FuenteLineas8).Width, nTop)
                    e.Graphics.DrawString(dgvPartidas.Rows(nRowPosRes).Cells("FECHAALTAPARTIDA").Value, FuenteLineas8, Brushes.Black, 640, nTop)
                    e.Graphics.DrawString(dgvPartidas.Rows(nRowPosRes).Cells("NROCOLOR").Value, FuenteLineas8, Brushes.Black, New RectangleF(740, nTop, 170, 18))
                    e.Graphics.DrawString(Strings.Left(dgvPartidas.Rows(nRowPosRes).Cells("OBSERVACION").Value, 40), FuenteLineas8, Brushes.Black, 910, nTop)

                    nTop = nTop + 18
                    e.Graphics.DrawLine(Pens.Black, 205, nTop, 1150, nTop)

                End If

            End If
            nRowPosRes += 1
        Loop

        'al final imprimo el ultimo corte
        AuxFila = ObtenerFiladelHiladoconelCodigo("COMMODITIES")
        'EL CODIGO Y LA DESCRIPCION DEL HILADO
        'e.Graphics.DrawString(dgvHilados.Rows(AuxFila).Cells("CODIGO").Value + "-" + dgvHilados.Rows(AuxFila).Cells("TIPO").Value, FuenteLineas8Neg, Brushes.Black, New RectangleF(10, nTopParaEncabezado, 200, 18))
        'LOS KG TOTALDEL HILADO
        e.Graphics.DrawString(dgvHilados.Rows(AuxFila).Cells("KILOS").Value.ToString, FuenteLineas8Neg, Brushes.Black, 585 - e.Graphics.MeasureString(dgvHilados.Rows(AuxFila).Cells("KILOS").Value.ToString, FuenteLineas8Neg).Width, nTop - 18)
        'UNA LINEA PARA QUE EL TOTAL QUEDE CON UNA LINEA DOBLE ABAJO
        e.Graphics.DrawLine(Pens.Black, 5, nTop - 2, 1150, nTop - 2)
        'Y EL CIERRE DE LA LINEA
        e.Graphics.DrawLine(Pens.Black, 5, nTop, 210, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.Gray), New Rectangle(5, nTop, 1145, 12))
        nTop += 15

        ''Imprimo los Commodities
        nRowPosRes = 0
        AuxFila = -1

        Do While nRowPosRes < dgvPartidas.RowCount

            'If nTop > e.MarginBounds.Height - e.MarginBounds.Top - 30 Then
            If nTop > 750 Then
                ' las lineas verticales
                e.Graphics.DrawLine(Pens.Black, 5, 44, 5, nTop)
                e.Graphics.DrawLine(Pens.Black, 205, 44, 205, nTop)
                e.Graphics.DrawLine(Pens.Black, 285, 44, 285, nTop)
                e.Graphics.DrawLine(Pens.Black, 455, 44, 455, nTop)
                e.Graphics.DrawLine(Pens.Black, 545, 44, 545, nTop)
                e.Graphics.DrawLine(Pens.Black, 635, 44, 635, nTop)
                e.Graphics.DrawLine(Pens.Black, 735, 44, 735, nTop)
                e.Graphics.DrawLine(Pens.Black, 908, 44, 908, nTop)
                e.Graphics.DrawLine(Pens.Black, 1150, 44, 1150, nTop)

                'LUEGO EL PIE DE PAGINA
                DrawFooter(e)

                nPageNo += 1
                NewPage = True
                e.HasMorePages = True
                Exit Sub

            Else

                If NewPage Then

                    ' Draw Header
                    e.Graphics.DrawString("TEXTILANA S.A.", FuenteTituloEnc11, Brushes.Black, 500, nTop - 16)
                    e.Graphics.DrawString("EXISTENCIAS DE HILADO AL " + Format(dtpALaFecha.Value, "dd/MM/yyyy"), FuenteTituloEnc, Brushes.Black, 100, nTop)
                    e.Graphics.DrawString("TOTAL KG:", FuenteTituloEnc, Brushes.Black, 895, nTop)
                    e.Graphics.DrawString(TotalKilosGral, FuenteTituloEnc, Brushes.Black, 1060 - e.Graphics.MeasureString(TotalKilosGral.ToString, FuenteTituloEnc).Width, nTop)
                    nTop = nTop + 24

                    'LOS ENCABEZADOS DE LA TABLA
                    e.Graphics.DrawLine(Pens.Black, 5, nTop, 1150, nTop)
                    nTop = nTop + 2
                    e.Graphics.DrawString("ARTICULO", FuenteLineas, Brushes.Black, 10, nTop) '200
                    e.Graphics.DrawString("PARTIDA", FuenteLineas, Brushes.Black, 210, nTop) '80
                    e.Graphics.DrawString("COLOR", FuenteLineas, Brushes.Black, 290, nTop) '170
                    e.Graphics.DrawString("STOCK", FuenteLineas, Brushes.Black, 460, nTop) '90
                    e.Graphics.DrawString("TOTAL", FuenteLineas, Brushes.Black, 550, nTop) '90
                    e.Graphics.DrawString("FECHA ALTA", FuenteLineas, Brushes.Black, 640 - 2, nTop) '100 ' le resto 2 para que el texto no pegue con la linea vertical de la izquierda
                    e.Graphics.DrawString("CONO", FuenteLineas, Brushes.Black, 740, nTop) '170
                    e.Graphics.DrawString("OBSERVACIÓN", FuenteLineas, Brushes.Black, 910, nTop)
                    nTop = nTop + 20
                    e.Graphics.DrawLine(Pens.Black, 5, nTop, 1150, nTop)
                    nTop = nTop + 2

                    NewPage = False

                End If

                If InStr(dgvPartidas.Rows(nRowPosRes).Cells("PARTIDA").Value.ToString, "G") > 0 And CInt(dgvPartidas.Rows(nRowPosRes).Cells("COMMODITIE").Value) = 1 Then

                    If dgvPartidas.Rows(nRowPosRes).Cells("ESDISCONTINUADA").Value.ToString = "1" Then
                        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(206, nTop, 1140, 17))
                    End If

                    If AuxFila < 0 Then
                        AuxFila = ObtenerFiladelHiladoconelCodigo("COMMODITIES RES")
                        'EL CODIGO Y LA DESCRIPCION DEL HILADO
                        e.Graphics.DrawString(dgvHilados.Rows(AuxFila).Cells("CODIGO").Value + "-" + dgvHilados.Rows(AuxFila).Cells("TIPO").Value, FuenteLineas8Neg, Brushes.Black, New RectangleF(10, nTop, 200, 18))
                    End If

                    'e.Graphics.DrawString(dgvPartidas.Rows(nRowPosRes).Cells("PARTIDA").Value, FuenteLineas8, Brushes.Black, New RectangleF(210, nTop, 80, 18))
                    e.Graphics.DrawString(SacoCerosIzquierdaDePartida(dgvPartidas.Rows(nRowPosRes).Cells("PARTIDA").Value), FuenteLineas8, Brushes.Black, New RectangleF(210, nTop, 80, 18))
                    e.Graphics.DrawString(dgvPartidas.Rows(nRowPosRes).Cells("COLOR").Value, FuenteLineas8, Brushes.Black, New RectangleF(290, nTop, 170, 18))
                    e.Graphics.DrawString(dgvPartidas.Rows(nRowPosRes).Cells("STOCKACTUAL").Value, FuenteLineas8, Brushes.Black, 490 - e.Graphics.MeasureString(dgvPartidas.Rows(nRowPosRes).Cells(4).Value.ToString, FuenteLineas8).Width, nTop)
                    e.Graphics.DrawString(dgvPartidas.Rows(nRowPosRes).Cells("FECHAALTAPARTIDA").Value, FuenteLineas8, Brushes.Black, 640, nTop)
                    e.Graphics.DrawString(dgvPartidas.Rows(nRowPosRes).Cells("NROCOLOR").Value, FuenteLineas8, Brushes.Black, New RectangleF(740, nTop, 170, 18))
                    e.Graphics.DrawString(Strings.Left(dgvPartidas.Rows(nRowPosRes).Cells("OBSERVACION").Value, 40), FuenteLineas8, Brushes.Black, 910, nTop)

                    nTop = nTop + 18
                    e.Graphics.DrawLine(Pens.Black, 205, nTop, 1150, nTop)

                End If

            End If
            nRowPosRes += 1
        Loop

        'al final imprimo el ultimo corte
        AuxFila = ObtenerFiladelHiladoconelCodigo("COMMODITIES RES")
        'EL CODIGO Y LA DESCRIPCION DEL HILADO
        'e.Graphics.DrawString(dgvHilados.Rows(AuxFila).Cells("CODIGO").Value + "-" + dgvHilados.Rows(AuxFila).Cells("TIPO").Value, FuenteLineas8Neg, Brushes.Black, New RectangleF(10, nTopParaEncabezado, 200, 18))
        'LOS KG TOTALDEL HILADO
        e.Graphics.DrawString(dgvHilados.Rows(AuxFila).Cells("KILOS").Value.ToString, FuenteLineas8Neg, Brushes.Black, 585 - e.Graphics.MeasureString(dgvHilados.Rows(AuxFila).Cells("KILOS").Value.ToString, FuenteLineas8Neg).Width, nTop - 18)
        'UNA LINEA PARA QUE EL TOTAL QUEDE CON UNA LINEA DOBLE ABAJO
        e.Graphics.DrawLine(Pens.Black, 5, nTop - 2, 1150, nTop - 2)
        'Y EL CIERRE DE LA LINEA
        e.Graphics.DrawLine(Pens.Black, 5, nTop, 210, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.Gray), New Rectangle(5, nTop, 1145, 12))
        nTop += 15


        ' las lineas verticales
        e.Graphics.DrawLine(Pens.Black, 5, 44, 5, nTop)
        e.Graphics.DrawLine(Pens.Black, 205, 44, 205, nTop)
        e.Graphics.DrawLine(Pens.Black, 285, 44, 285, nTop)
        e.Graphics.DrawLine(Pens.Black, 455, 44, 455, nTop)
        e.Graphics.DrawLine(Pens.Black, 545, 44, 545, nTop)
        e.Graphics.DrawLine(Pens.Black, 635, 44, 635, nTop)
        e.Graphics.DrawLine(Pens.Black, 735, 44, 735, nTop)
        e.Graphics.DrawLine(Pens.Black, 908, 44, 908, nTop)
        e.Graphics.DrawLine(Pens.Black, 1150, 44, 1150, nTop)

        'LUEGO EL PIE DE PAGINA
        DrawFooter(e)

    End Sub

    Public Function SacoCerosIzquierdaDePartida(ByVal NroPartida As String) As String
        Dim i, total As Integer
        Dim retorno As String = ""
        total = NroPartida.Length
        For i = 1 To total
            If Strings.Left(NroPartida, 1) = "0" Then
                NroPartida = Strings.Right(NroPartida, NroPartida.Length - 1)
            Else
                Exit For
            End If
        Next
        retorno = NroPartida
        Return retorno
    End Function

    Public Sub DrawFooter(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim FuenteLineas8 As Font = New Drawing.Font("Arial", 8, FontStyle.Regular)

        Dim sPageNo As String = nPageNo.ToString + " de "

        If nPageNo = "1" Then
            lPageNo = CalculoCantidaddeHojas().ToString
            sPageNo = nPageNo.ToString + " de " + lPageNo
        Else
            sPageNo = nPageNo.ToString + " de " + lPageNo
        End If

        e.Graphics.DrawLine(Pens.Black, 2, e.MarginBounds.Height - 17, 1160, e.MarginBounds.Height - 17)

        ' Right Align - User Name
        e.Graphics.DrawString(Format(Now, "dd/MM/yyyy HH:mm:ss"), FuenteLineas8, Brushes.Black, 1000, e.MarginBounds.Height - 15)

        ' Center - Page No. Info
        e.Graphics.DrawString(sPageNo, FuenteLineas8, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(sPageNo, FuenteLineas8, e.MarginBounds.Width).Width) / 2, e.MarginBounds.Height - 15)

        e.Graphics.DrawLine(Pens.Black, 2, e.MarginBounds.Height, 1160, e.MarginBounds.Height)

    End Sub

    Private Function CalculoCantidaddeHojas() As Int16
        Dim NroPag As Int16 = 1
        Dim FilaPos As Int16 = 0
        Dim CORTE, ArtIni, ArtFin As String
        Dim OtraPagina As Boolean = True

        Dim nTop As Int16 = 20

        CORTE = ""
        If txtCodArtDesde.Text <> "" Then
            ArtIni = txtCodArtDesde.Text
        Else
            ArtIni = "0"
        End If
        If txtCodArtHasta.Text <> "" Then
            ArtFin = txtCodArtHasta.Text
        Else
            ArtFin = "999999"
        End If


        nTop = nTop + 60 ' para que tenga en cuenta el total de los reservados

        Do While FilaPos < dgvPartidas.RowCount

            If nTop > 750 Then
                nTop = 20
                NroPag += 1
                OtraPagina = True
            Else

                If OtraPagina Then
                    ' Draw Header
                    nTop = nTop + 24
                    'LOS ENCABEZADOS DE LA TABLA
                    nTop = nTop + 2
                    nTop = nTop + 20
                    nTop = nTop + 2
                    nTop = nTop + 2
                    OtraPagina = False
                End If

                If CORTE <> dgvPartidas.Rows(FilaPos).Cells(0).Value.ToString Then
                    If CORTE = "" Then
                        CORTE = dgvPartidas.Rows(FilaPos).Cells(0).Value.ToString
                    Else
                        If CInt(CORTE) >= CInt(ArtIni) And CInt(CORTE) <= CInt(ArtFin) Then

                        End If
                        CORTE = dgvPartidas.Rows(FilaPos).Cells(0).Value.ToString
                    End If
                End If

                If CInt(CORTE) >= CInt(ArtIni) And CInt(CORTE) <= CInt(ArtFin) Then

                    nTop = nTop + 18

                End If

            End If

            FilaPos += 1
        Loop

        'al final imprimo el ultimo corte
        If CInt(CORTE) >= CInt(ArtIni) And CInt(CORTE) <= CInt(ArtFin) Then
            nTop = nTop + 5
            nTop = nTop + 16
            nTop = nTop + 20
            nTop = nTop + 2
        End If

        Return NroPag
    End Function



    'Private Sub pdoImpExistencias_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdoImpExistencias.PrintPage
    '    On Error Resume Next

    '    Dim ArtIni, ArtFin As String
    '    Dim AuxFila As Integer

    '    Dim FuenteLineas As Font = New Drawing.Font("Arial", 10, FontStyle.Regular)
    '    Dim FuenteLineas8 As Font = New Drawing.Font("Arial", 8, FontStyle.Regular)
    '    Dim FuenteTituloEnc As Font = New Drawing.Font("Arial", 12, FontStyle.Regular)

    '    Dim nTop As Int16 = e.MarginBounds.Top


    '    If txtCodArtDesde.Text <> "" Then
    '        ArtIni = txtCodArtDesde.Text
    '    Else
    '        ArtIni = "0"
    '    End If
    '    If txtCodArtHasta.Text <> "" Then
    '        ArtFin = txtCodArtHasta.Text
    '    Else
    '        ArtFin = "999999"
    '    End If


    '    Do While nRowPos < dgvPartidas.RowCount

    '        'If nTop > e.MarginBounds.Height - e.MarginBounds.Top - 30 Then
    '        If nTop > 1050 Then
    '            'LUEGO EL PIE DE PAGINA
    '            DrawFooter(e)

    '            nPageNo += 1
    '            NewPage = True
    '            e.HasMorePages = True
    '            Exit Sub

    '        Else

    '            If NewPage Then

    '                ' Draw Header
    '                e.Graphics.DrawString("EXISTENCIAS DE HILADO AL " + Format(dtpALaFecha.Value, "dd/MM/yyyy"), FuenteTituloEnc, Brushes.Black, 200, nTop)
    '                nTop = nTop + 24

    '                'LOS ENCABEZADOS DE LA TABLA
    '                e.Graphics.DrawLine(Pens.Black, 20, nTop, 790, nTop)
    '                nTop = nTop + 2
    '                e.Graphics.DrawLine(Pens.Black, 20, nTop, 790, nTop)
    '                nTop = nTop + 2
    '                e.Graphics.DrawString("PARTIDA", FuenteLineas, Brushes.Black, 25, nTop)
    '                e.Graphics.DrawString("Nro.COLOR", FuenteLineas, Brushes.Black, 105, nTop)
    '                e.Graphics.DrawString("COLOR", FuenteLineas, Brushes.Black, 190, nTop)
    '                e.Graphics.DrawString("STOCK ACTUAL", FuenteLineas, Brushes.Black, 560 - e.Graphics.MeasureString("STOCK ACTUAL", FuenteLineas).Width, nTop)
    '                e.Graphics.DrawString("P.CARD", FuenteLineas, Brushes.Black, 630 - e.Graphics.MeasureString("P.CARD", FuenteLineas).Width, nTop)
    '                e.Graphics.DrawString("OBSERVACIÓN", FuenteLineas, Brushes.Black, 780 - e.Graphics.MeasureString("OBSERVACIÓN", FuenteLineas).Width, nTop)
    '                nTop = nTop + 20
    '                e.Graphics.DrawLine(Pens.Black, 20, nTop, 790, nTop)
    '                nTop = nTop + 2
    '                e.Graphics.DrawLine(Pens.Black, 20, nTop, 790, nTop)
    '                nTop = nTop + 2

    '                NewPage = False

    '            End If

    '            If InStr(dgvPartidas.Rows(nRowPos).Cells("PARTIDA").Value.ToString, "G") <= 0 Then


    '                If CORTE <> dgvPartidas.Rows(nRowPos).Cells(0).Value.ToString Then
    '                    If CORTE = "" Then
    '                        CORTE = dgvPartidas.Rows(nRowPos).Cells(0).Value.ToString
    '                    Else
    '                        If CInt(CORTE) >= CInt(ArtIni) And CInt(CORTE) <= CInt(ArtFin) Then
    '                            AuxFila = ObtenerFiladelHiladoconelCodigo(CORTE)
    '                            nTop = nTop + 5
    '                            e.Graphics.DrawString(dgvHilados.Rows(AuxFila).Cells(0).Value, FuenteLineas8, Brushes.Black, New RectangleF(25, nTop, 200, 20))
    '                            nTop = nTop + 16
    '                            e.Graphics.DrawString(dgvHilados.Rows(AuxFila).Cells(1).Value, FuenteLineas8, Brushes.Black, New RectangleF(25, nTop, 175, 20))
    '                            e.Graphics.DrawString(dgvHilados.Rows(AuxFila).Cells(2).Value, FuenteLineas8, Brushes.Black, New RectangleF(250, nTop, 200, 20))
    '                            e.Graphics.DrawString("KGR: " + dgvHilados.Rows(AuxFila).Cells(3).Value.ToString, FuenteLineas8, Brushes.Black, 625 - e.Graphics.MeasureString("KGR: " + dgvHilados.Rows(AuxFila).Cells(3).Value.ToString, FuenteLineas8).Width, nTop)
    '                            nTop = nTop + 20
    '                            e.Graphics.DrawLine(Pens.Black, 20, nTop, 790, nTop)
    '                            nTop = nTop + 2

    '                        End If
    '                        CORTE = dgvPartidas.Rows(nRowPos).Cells(0).Value.ToString
    '                    End If
    '                End If

    '                If CInt(CORTE) >= CInt(ArtIni) And CInt(CORTE) <= CInt(ArtFin) Then

    '                    If dgvPartidas.Rows(nRowPos).Cells("ESDISCONTINUADA").Value.ToString = "1" Then
    '                        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(20, nTop, 780, 17))
    '                    End If

    '                    e.Graphics.DrawString(dgvPartidas.Rows(nRowPos).Cells(1).Value, FuenteLineas8, Brushes.Black, New RectangleF(25, nTop, 100, 20))
    '                    e.Graphics.DrawString(dgvPartidas.Rows(nRowPos).Cells(2).Value, FuenteLineas8, Brushes.Black, New RectangleF(105, nTop, 85, 20))
    '                    e.Graphics.DrawString(dgvPartidas.Rows(nRowPos).Cells(3).Value, FuenteLineas8, Brushes.Black, New RectangleF(190, nTop, 200, 20))
    '                    e.Graphics.DrawString(dgvPartidas.Rows(nRowPos).Cells(4).Value, FuenteLineas8, Brushes.Black, 550 - e.Graphics.MeasureString(dgvPartidas.Rows(nRowPos).Cells(4).Value.ToString, FuenteLineas8).Width, nTop)
    '                    e.Graphics.DrawString(dgvPartidas.Rows(nRowPos).Cells(5).Value, FuenteLineas8, Brushes.Black, 630 - e.Graphics.MeasureString(dgvPartidas.Rows(nRowPos).Cells(5).Value.ToString, FuenteLineas8).Width, nTop)
    '                    e.Graphics.DrawString(Strings.Left(dgvPartidas.Rows(nRowPos).Cells(6).Value, 25), FuenteLineas8, Brushes.Black, 780 - e.Graphics.MeasureString(Strings.Left(dgvPartidas.Rows(nRowPos).Cells(6).Value, 25), FuenteLineas8).Width, nTop)
    '                    nTop = nTop + 20

    '                End If

    '            End If

    '        End If
    '        nRowPos += 1
    '    Loop

    '    If Not YaVoyPorLosReservados Then
    '        'al final imprimo el ultimo corte
    '        If CInt(CORTE) >= CInt(ArtIni) And CInt(CORTE) <= CInt(ArtFin) Then
    '            AuxFila = ObtenerFiladelHiladoconelCodigo(CORTE)
    '            nTop = nTop + 5
    '            e.Graphics.DrawString(dgvHilados.Rows(AuxFila).Cells(0).Value, FuenteLineas8, Brushes.Black, New RectangleF(25, nTop, 200, 20))
    '            nTop = nTop + 16
    '            e.Graphics.DrawString(dgvHilados.Rows(AuxFila).Cells(1).Value, FuenteLineas8, Brushes.Black, New RectangleF(25, nTop, 175, 20))
    '            e.Graphics.DrawString(dgvHilados.Rows(AuxFila).Cells(2).Value, FuenteLineas8, Brushes.Black, New RectangleF(200, nTop, 200, 20))
    '            e.Graphics.DrawString("KGR: " + dgvHilados.Rows(AuxFila).Cells(3).Value.ToString, FuenteLineas8, Brushes.Black, 625 - e.Graphics.MeasureString("KGR: " + dgvHilados.Rows(AuxFila).Cells(3).Value.ToString, FuenteLineas8).Width, nTop)
    '            nTop = nTop + 20
    '            e.Graphics.DrawLine(Pens.Black, 20, nTop, 790, nTop)
    '            nTop = nTop + 2
    '        End If
    '    End If
    '    ''''''''''' al final imprimo el detalle de los RESERVADOS


    '    YaVoyPorLosReservados = True

    '    Do While nRowPosRes < dgvPartidas.RowCount

    '        'If nTop > e.MarginBounds.Height - e.MarginBounds.Top - 30 Then
    '        If nTop > 1050 Then
    '            'LUEGO EL PIE DE PAGINA
    '            DrawFooter(e)

    '            nPageNo += 1
    '            NewPage = True
    '            e.HasMorePages = True
    '            Exit Sub

    '        Else

    '            If NewPage Then

    '                ' Draw Header
    '                e.Graphics.DrawString("EXISTENCIAS DE HILADO AL " + Format(dtpALaFecha.Value, "dd/MM/yyyy"), FuenteTituloEnc, Brushes.Black, 200, nTop)
    '                nTop = nTop + 24

    '                'LOS ENCABEZADOS DE LA TABLA
    '                e.Graphics.DrawLine(Pens.Black, 20, nTop, 790, nTop)
    '                nTop = nTop + 2
    '                e.Graphics.DrawLine(Pens.Black, 20, nTop, 790, nTop)
    '                nTop = nTop + 2
    '                e.Graphics.DrawString("PARTIDA", FuenteLineas, Brushes.Black, 25, nTop)
    '                e.Graphics.DrawString("Nro.COLOR", FuenteLineas, Brushes.Black, 105, nTop)
    '                e.Graphics.DrawString("COLOR", FuenteLineas, Brushes.Black, 190, nTop)
    '                e.Graphics.DrawString("STOCK ACTUAL", FuenteLineas, Brushes.Black, 560 - e.Graphics.MeasureString("STOCK ACTUAL", FuenteLineas).Width, nTop)
    '                e.Graphics.DrawString("P.CARD", FuenteLineas, Brushes.Black, 630 - e.Graphics.MeasureString("P.CARD", FuenteLineas).Width, nTop)
    '                e.Graphics.DrawString("OBSERVACIÓN", FuenteLineas, Brushes.Black, 780 - e.Graphics.MeasureString("OBSERVACIÓN", FuenteLineas).Width, nTop)
    '                nTop = nTop + 20
    '                e.Graphics.DrawLine(Pens.Black, 20, nTop, 790, nTop)
    '                nTop = nTop + 2
    '                e.Graphics.DrawLine(Pens.Black, 20, nTop, 790, nTop)
    '                nTop = nTop + 2

    '                NewPage = False

    '            End If

    '            If InStr(dgvPartidas.Rows(nRowPosRes).Cells("PARTIDA").Value.ToString, "G") > 0 Then


    '                If dgvPartidas.Rows(nRowPosRes).Cells("ESDISCONTINUADA").Value.ToString = "1" Then
    '                    e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(20, nTop, 780, 17))
    '                End If

    '                e.Graphics.DrawString(dgvPartidas.Rows(nRowPosRes).Cells(1).Value, FuenteLineas8, Brushes.Black, New RectangleF(25, nTop, 100, 20))
    '                e.Graphics.DrawString(dgvPartidas.Rows(nRowPosRes).Cells(2).Value, FuenteLineas8, Brushes.Black, New RectangleF(105, nTop, 85, 20))
    '                e.Graphics.DrawString(dgvPartidas.Rows(nRowPosRes).Cells(3).Value, FuenteLineas8, Brushes.Black, New RectangleF(190, nTop, 200, 20))
    '                e.Graphics.DrawString(dgvPartidas.Rows(nRowPosRes).Cells(4).Value, FuenteLineas8, Brushes.Black, 550 - e.Graphics.MeasureString(dgvPartidas.Rows(nRowPosRes).Cells(4).Value.ToString, FuenteLineas8).Width, nTop)
    '                e.Graphics.DrawString(dgvPartidas.Rows(nRowPosRes).Cells(5).Value, FuenteLineas8, Brushes.Black, 630 - e.Graphics.MeasureString(dgvPartidas.Rows(nRowPosRes).Cells(5).Value.ToString, FuenteLineas8).Width, nTop)
    '                e.Graphics.DrawString(Strings.Left(dgvPartidas.Rows(nRowPosRes).Cells(6).Value, 25), FuenteLineas8, Brushes.Black, 780 - e.Graphics.MeasureString(Strings.Left(dgvPartidas.Rows(nRowPosRes).Cells(6).Value, 25), FuenteLineas8).Width, nTop)
    '                nTop = nTop + 20

    '            End If

    '        End If
    '        nRowPosRes += 1
    '    Loop

    '    'al final imprimo el ultimo corte
    '    AuxFila = ObtenerFiladelHiladoconelCodigo("RESERVADO")
    '    nTop = nTop + 5
    '    e.Graphics.DrawString(dgvHilados.Rows(AuxFila).Cells(0).Value, FuenteLineas8, Brushes.Black, New RectangleF(25, nTop, 200, 20))
    '    nTop = nTop + 16
    '    e.Graphics.DrawString(dgvHilados.Rows(AuxFila).Cells(1).Value, FuenteLineas8, Brushes.Black, New RectangleF(25, nTop, 175, 20))
    '    e.Graphics.DrawString(dgvHilados.Rows(AuxFila).Cells(2).Value, FuenteLineas8, Brushes.Black, New RectangleF(200, nTop, 200, 20))
    '    e.Graphics.DrawString("KGR: " + dgvHilados.Rows(AuxFila).Cells(3).Value.ToString, FuenteLineas8, Brushes.Black, 625 - e.Graphics.MeasureString("KGR: " + dgvHilados.Rows(AuxFila).Cells(3).Value.ToString, FuenteLineas8).Width, nTop)
    '    nTop = nTop + 20
    '    e.Graphics.DrawLine(Pens.Black, 20, nTop, 790, nTop)
    '    nTop = nTop + 2



    '    'el  total de existencias
    '    nTop = nTop + 5
    '    e.Graphics.DrawString(lblTotalGral.Text, FuenteLineas, Brushes.Black, 625 - e.Graphics.MeasureString(lblTotalGral.Text, FuenteLineas).Width, nTop)

    '    'LUEGO EL PIE DE PAGINA
    '    DrawFooter(e)

    'End Sub

    'Public Sub DrawFooter(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
    '    Dim FuenteLineas8 As Font = New Drawing.Font("Arial", 8, FontStyle.Regular)

    '    Dim sPageNo As String = nPageNo.ToString + " de "

    '    If nPageNo = "1" Then
    '        lPageNo = CalculoCantidaddeHojas().ToString
    '        sPageNo = nPageNo.ToString + " de " + lPageNo
    '    Else
    '        sPageNo = nPageNo.ToString + " de " + lPageNo
    '    End If

    '    e.Graphics.DrawLine(Pens.Black, 20, e.MarginBounds.Height - 17, 790, e.MarginBounds.Height - 17)

    '    ' Right Align - User Name
    '    e.Graphics.DrawString(Format(Now, "dd/MM/yyyy HH:mm:ss"), FuenteLineas8, Brushes.Black, 660, e.MarginBounds.Height - 15)

    '    ' Center - Page No. Info
    '    e.Graphics.DrawString(sPageNo, FuenteLineas8, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(sPageNo, FuenteLineas8, e.MarginBounds.Width).Width) / 2, e.MarginBounds.Height - 15)

    '    e.Graphics.DrawLine(Pens.Black, 20, e.MarginBounds.Height, 790, e.MarginBounds.Height)

    'End Sub

    'Private Function CalculoCantidaddeHojas() As Int16
    '    Dim NroPag As Int16 = 1
    '    Dim FilaPos As Int16 = 0
    '    Dim CORTE, ArtIni, ArtFin As String
    '    Dim OtraPagina As Boolean = True

    '    Dim nTop As Int16 = 20

    '    CORTE = ""
    '    If txtCodArtDesde.Text <> "" Then
    '        ArtIni = txtCodArtDesde.Text
    '    Else
    '        ArtIni = "0"
    '    End If
    '    If txtCodArtHasta.Text <> "" Then
    '        ArtFin = txtCodArtHasta.Text
    '    Else
    '        ArtFin = "999999"
    '    End If


    '    nTop = nTop + 60 ' para que tenga en cuenta el total de los reservados

    '    Do While FilaPos < dgvPartidas.RowCount

    '        If nTop > 1050 Then
    '            nTop = 20
    '            NroPag += 1
    '            OtraPagina = True
    '        Else

    '            If OtraPagina Then
    '                ' Draw Header
    '                nTop = nTop + 24
    '                'LOS ENCABEZADOS DE LA TABLA
    '                nTop = nTop + 2
    '                nTop = nTop + 2
    '                nTop = nTop + 20
    '                nTop = nTop + 2
    '                nTop = nTop + 2
    '                OtraPagina = False
    '            End If

    '            If CORTE <> dgvPartidas.Rows(FilaPos).Cells(0).Value.ToString Then
    '                If CORTE = "" Then
    '                    CORTE = dgvPartidas.Rows(FilaPos).Cells(0).Value.ToString
    '                Else
    '                    If CInt(CORTE) >= CInt(ArtIni) And CInt(CORTE) <= CInt(ArtFin) Then
    '                        nTop = nTop + 5
    '                        nTop = nTop + 16
    '                        nTop = nTop + 20
    '                        nTop = nTop + 2
    '                    End If
    '                    CORTE = dgvPartidas.Rows(FilaPos).Cells(0).Value.ToString
    '                End If
    '            End If

    '            If CInt(CORTE) >= CInt(ArtIni) And CInt(CORTE) <= CInt(ArtFin) Then

    '                nTop = nTop + 20

    '            End If

    '        End If

    '        FilaPos += 1
    '    Loop

    '    'al final imprimo el ultimo corte
    '    If CInt(CORTE) >= CInt(ArtIni) And CInt(CORTE) <= CInt(ArtFin) Then
    '        nTop = nTop + 5
    '        nTop = nTop + 16
    '        nTop = nTop + 20
    '        nTop = nTop + 2
    '    End If

    '    'al final tomo en cuenta el total de los reservados
    '    nTop = nTop + 5
    '    nTop = nTop + 16
    '    nTop = nTop + 20
    '    nTop = nTop + 2

    '    'el  total de existencias
    '    nTop = nTop + 5
    '    nTop = nTop + 20 ' sumo estos ultimos 20 para que representen lo que ocupa la fila del total de existencias

    '    Return NroPag
    'End Function


    Private Sub cmdListar_Click(sender As System.Object, e As System.EventArgs) Handles cmdListar.Click
        CargarReporteHilados()
    End Sub

    Private Sub cmdSalir_Click(sender As System.Object, e As System.EventArgs) Handles cmdSalir.Click
        Close()
    End Sub

    Private Sub dgvHilados_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHilados.CellClick
        Dim pos As Integer
        If dgvHilados.CurrentRow.Cells("TIPO").Value.ToString = "RESERVADO" Or dgvHilados.CurrentRow.Cells("TIPO").Value.ToString = "COMMODITIES" Or dgvHilados.CurrentRow.Cells("TIPO").Value.ToString = "COMMODITIES RESERVADOS" Then

            dgvPartidas.Columns("HILADO").DisplayIndex = 2
            dgvPartidas.Columns("NROCOLOR").DisplayIndex = 8
            dgvPartidas.Columns("NROCOLOR").Visible = False
            dgvPartidas.Columns("HILADO").Visible = True
        Else
            dgvPartidas.Columns("HILADO").DisplayIndex = 8
            dgvPartidas.Columns("NROCOLOR").DisplayIndex = 2
            dgvPartidas.Columns("NROCOLOR").Visible = True
            dgvPartidas.Columns("HILADO").Visible = False
        End If
        FiltrarDGVPartidas(dgvHilados.Rows(dgvHilados.CurrentRow.Index).Cells(0).Value.ToString)
        'lblTotalHilado.Text = "TOTAL DEL HILADO EN EXISTENCIA :  " + Format(CDbl(dgvHilados.Rows(dgvHilados.CurrentRow.Index).Cells(3).Value), "0.000") + " KGR."
        lblTotalHilado.Text = "TOTAL DEL HILADO EN EXISTENCIA :  " + dgvHilados.Rows(dgvHilados.CurrentRow.Index).Cells(3).Value.ToString + " KGR."
    End Sub

    Private Sub FiltrarDGVPartidas(ByVal Codis As String)
        Dim i As Integer
        If Codis = "RESERVADO" Then
            For i = 0 To dgvPartidas.RowCount - 1
                If InStr(dgvPartidas.Rows(i).Cells("PARTIDA").Value.ToString, "G", Microsoft.VisualBasic.CompareMethod.Text) > 0 And InStr(dgvPartidas.Rows(i).Cells("PARTIDA").Value.ToString, "/C") <= 0 Then
                    Console.WriteLine(dgvPartidas.Rows(i).Cells("PARTIDA").Value.ToString)
                    dgvPartidas.Rows(i).Visible = True
                Else
                    dgvPartidas.Rows(i).Visible = False
                End If
            Next
        ElseIf Codis = "COMMODITIES RES" Then
            For i = 0 To dgvPartidas.RowCount - 1
                If InStr(dgvPartidas.Rows(i).Cells("PARTIDA").Value.ToString, "G", Microsoft.VisualBasic.CompareMethod.Text) > 0 And InStr(dgvPartidas.Rows(i).Cells("PARTIDA").Value.ToString, "/C", Microsoft.VisualBasic.CompareMethod.Text) > 0 Then
                    dgvPartidas.Rows(i).Visible = True
                Else
                    dgvPartidas.Rows(i).Visible = False
                End If
            Next
        ElseIf Codis = "COMMODITIES" Then
            For i = 0 To dgvPartidas.RowCount - 1
                If InStr(dgvPartidas.Rows(i).Cells("PARTIDA").Value.ToString, "/C", Microsoft.VisualBasic.CompareMethod.Text) > 0 And InStr(dgvPartidas.Rows(i).Cells("PARTIDA").Value.ToString, "H", Microsoft.VisualBasic.CompareMethod.Text) > 0 Then
                    dgvPartidas.Rows(i).Visible = True
                Else
                    dgvPartidas.Rows(i).Visible = False
                End If
            Next
        Else
            For i = 0 To dgvPartidas.RowCount - 1
                If dgvPartidas.Rows(i).Cells(0).Value.ToString = Codis And InStr(dgvPartidas.Rows(i).Cells("PARTIDA").Value.ToString, "G") <= 0 And InStr(dgvPartidas.Rows(i).Cells("PARTIDA").Value.ToString, "C", Microsoft.VisualBasic.CompareMethod.Text) <= 0 Then
                    dgvPartidas.Rows(i).Visible = True
                Else
                    dgvPartidas.Rows(i).Visible = False
                End If
            Next
        End If
    End Sub

    Private Function ObtenerFiladelHiladoconelCodigo(ByVal Codis As String) As Integer
        Dim i As Integer
        For i = 0 To dgvHilados.RowCount - 1
            If dgvHilados.Rows(i).Cells(0).Value.ToString = Codis Then
                ObtenerFiladelHiladoconelCodigo = i
                Exit Function
            End If
        Next
        ObtenerFiladelHiladoconelCodigo = -1
    End Function

    Private Function Validar() As Boolean
        If txtCodArtDesde.Text <> "" Then
            If Not IsNumeric(txtCodArtDesde.Text) Then
                MensajeCritico("El Cod Art Desde debe ser numérico. Verifique.")
                Validar = False
                Exit Function
            End If
        End If

        If txtCodArtHasta.Text <> "" Then
            If Not IsNumeric(txtCodArtHasta.Text) Then
                MensajeCritico("El Cod Art Hasta debe ser numérico. Verifique.")
                Validar = False
                Exit Function
            End If
        End If

        Validar = True
    End Function

    Private Sub txtCodArtDesde_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodArtDesde.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtCodArtHasta.Select()
        End If
    End Sub

    Private Sub txtCodArtHasta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodArtHasta.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            cmdListar.Select()
        End If
    End Sub

    Private Sub frmRepoHiladosStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim UltimaModifServer As Date

        'txtCodArtDesde.Text = "52"
        'txtCodArtHasta.Text = "599"

        'UltimaModifServer = My.Computer.FileSystem.GetFileInfo("\\192.168.0.12\u\hilamar\sto\hilstock.dbf").LastWriteTime
        'lblFechaUltimoMovimiento.Text = "Último movimiento cargado el día " + Format(UltimaModifServer, "dd/MM/yyyy")

        If Environment.MachineName = "COMPUTOS1" Then
            btnProcesoDiario.Visible = True
        Else
            btnProcesoDiario.Visible = False
        End If

        CargarReporteHilados()

        GraficarHistoricoStockHilados()

        txtCodArtDesde.Select()
    End Sub

    Private Sub cmdExcel_Click(sender As Object, e As EventArgs) Handles cmdExcel.Click
        If dgvHilados.RowCount > 0 Then
            ExportaraExcel()
        End If
    End Sub

    Private Sub ExportaraExcel()
        'On Error GoTo ErrGenerarExcelHilados
        Dim NombreArchivoExcel As String
        Dim oExcel As New Excel.Application()
        Dim oSheet As Excel.Worksheet
        Dim XLProc As Process
        Dim xlHWND As Integer = oExcel.Hwnd
        Dim ProcIDXL As Integer = 0

        Dim i As Integer
        Dim Fila, Columna As Integer
        Dim AuxFila As Integer

        Dim ArtIni, ArtFin As String
        If txtCodArtDesde.Text <> "" Then
            ArtIni = txtCodArtDesde.Text
        Else
            ArtIni = "0"
        End If
        If txtCodArtHasta.Text <> "" Then
            ArtFin = txtCodArtHasta.Text
        Else
            ArtFin = "999999"
        End If


        'get the process ID
        GetWindowThreadProcessId(xlHWND, ProcIDXL)
        XLProc = Process.GetProcessById(ProcIDXL)

        oExcel.Workbooks.Add()
        oSheet = oExcel.ActiveSheet
        Fila = 1
        Columna = 1
        oSheet.Cells(Fila, Columna).value = "TEXTILANA S. A."
        Fila = 3
        oSheet.Cells(Fila, Columna).value = "EXISTENCIAS DE HILADO AL " + Format(dtpALaFecha.Value, "dd/MM/yyyy")

        Fila = 5
        oSheet.Cells(Fila, Columna).value = "PARTIDA"
        oSheet.Cells(Fila, Columna).ColumnWidth = 13
        oSheet.Columns(Columna).NumberFormat = "@"
        Columna = 2
        oSheet.Cells(Fila, Columna).value = "Nro.COLOR"
        oSheet.Cells(Fila, Columna).ColumnWidth = 13
        Columna = 3
        oSheet.Cells(Fila, Columna).value = "COLOR"
        oSheet.Cells(Fila, Columna).ColumnWidth = 30
        Columna = 4
        oSheet.Cells(Fila, Columna).value = "STOCK ACTUAL"
        oSheet.Cells(Fila, Columna).ColumnWidth = 16
        Columna = 5
        oSheet.Cells(Fila, Columna).value = "P.CARDADO"
        oSheet.Cells(Fila, Columna).ColumnWidth = 13
        oSheet.Columns(Columna).NumberFormat = "@"
        Columna = 6
        oSheet.Cells(Fila, Columna).value = "OBSERVACION"
        oSheet.Cells(Fila, Columna).ColumnWidth = 18
        Columna = 7
        oSheet.Cells(Fila, Columna).value = "FECHA ALTA"
        oSheet.Cells(Fila, Columna).ColumnWidth = 12

        'le pongo colorcito al los titulos, pero en vez de hacerlo columna por columna, lo hago con el rango
        oSheet.Range("A5", "G5").Interior.ColorIndex = 19

        nRowPos = 0
        CORTE = ""
        Do While nRowPos < dgvPartidas.RowCount

            If InStr(dgvPartidas.Rows(nRowPos).Cells("PARTIDA").Value.ToString, "G") <= 0 And CInt(dgvPartidas.Rows(nRowPos).Cells("COMMODITIE").Value) = 0 Then

                If CORTE <> dgvPartidas.Rows(nRowPos).Cells(0).Value.ToString Then
                    If CORTE = "" Then
                        CORTE = dgvPartidas.Rows(nRowPos).Cells(0).Value.ToString
                    Else
                        If CInt(CORTE) >= CInt(ArtIni) And CInt(CORTE) <= CInt(ArtFin) Then
                            AuxFila = ObtenerFiladelHiladoconelCodigo(CORTE)
                            Fila = Fila + 1
                            oSheet.Cells(Fila, 1).value = dgvHilados.Rows(AuxFila).Cells(0).Value
                            oSheet.Cells(Fila, 3).value = dgvHilados.Rows(AuxFila).Cells(2).Value
                            oSheet.Cells(Fila, 4).value = dgvHilados.Rows(AuxFila).Cells(3).Value.ToString
                            oSheet.Range("A" + CStr(Fila), "G" + CStr(Fila)).Interior.ColorIndex = 15

                        End If
                        CORTE = dgvPartidas.Rows(nRowPos).Cells(0).Value.ToString
                    End If
                End If

                If CInt(CORTE) >= CInt(ArtIni) And CInt(CORTE) <= CInt(ArtFin) Then

                    Fila = Fila + 1
                    oSheet.Cells(Fila, 1).value = dgvPartidas.Rows(nRowPos).Cells(1).Value
                    oSheet.Cells(Fila, 2).value = dgvPartidas.Rows(nRowPos).Cells(2).Value
                    oSheet.Cells(Fila, 3).value = dgvPartidas.Rows(nRowPos).Cells(3).Value
                    oSheet.Cells(Fila, 4).value = dgvPartidas.Rows(nRowPos).Cells(4).Value
                    oSheet.Cells(Fila, 5).value = dgvPartidas.Rows(nRowPos).Cells(5).Value
                    oSheet.Cells(Fila, 6).value = dgvPartidas.Rows(nRowPos).Cells(6).Value
                    oSheet.Cells(Fila, 7).value = dgvPartidas.Rows(nRowPos).Cells(9).Value

                    If dgvPartidas.Rows(nRowPos).Cells("ESDISCONTINUADA").Value.ToString = "1" Then
                        oSheet.Range("A" + CStr(Fila), "G" + CStr(Fila)).Interior.ColorIndex = 20
                    End If
                End If

            End If
            nRowPos += 1
        Loop

        'al final imprimo el ultimo corte
        If CInt(CORTE) >= CInt(ArtIni) And CInt(CORTE) <= CInt(ArtFin) Then
            AuxFila = ObtenerFiladelHiladoconelCodigo(CORTE)
            Fila = Fila + 1
            oSheet.Cells(Fila, 1).value = dgvHilados.Rows(AuxFila).Cells(0).Value
            oSheet.Cells(Fila, 3).value = dgvHilados.Rows(AuxFila).Cells(2).Value
            oSheet.Cells(Fila, 4).value = dgvHilados.Rows(AuxFila).Cells(3).Value.ToString
            oSheet.Range("A" + CStr(Fila), "G" + CStr(Fila)).Interior.ColorIndex = 15
        End If



        '''' Y AHORA HAGO UN NUEVO RECORRIDO PARA CARGAR AL FINAL TODAS LAS PARTIDAS RESERVADAS


        nRowPos = 0
        Do While nRowPos < dgvPartidas.RowCount

            If InStr(dgvPartidas.Rows(nRowPos).Cells("PARTIDA").Value.ToString, "G") > 0 And CInt(dgvPartidas.Rows(nRowPos).Cells("COMMODITIE").Value) = 0 Then

                If CInt(CORTE) >= CInt(ArtIni) And CInt(CORTE) <= CInt(ArtFin) Then

                    Fila = Fila + 1
                    oSheet.Cells(Fila, 1).value = dgvPartidas.Rows(nRowPos).Cells(1).Value
                    oSheet.Cells(Fila, 2).value = dgvPartidas.Rows(nRowPos).Cells(2).Value
                    oSheet.Cells(Fila, 3).value = dgvPartidas.Rows(nRowPos).Cells(3).Value
                    oSheet.Cells(Fila, 4).value = dgvPartidas.Rows(nRowPos).Cells(4).Value
                    oSheet.Cells(Fila, 5).value = dgvPartidas.Rows(nRowPos).Cells(5).Value
                    oSheet.Cells(Fila, 6).value = dgvPartidas.Rows(nRowPos).Cells(6).Value
                    oSheet.Cells(Fila, 7).value = dgvPartidas.Rows(nRowPos).Cells(9).Value

                    If dgvPartidas.Rows(nRowPos).Cells("ESDISCONTINUADA").Value.ToString = "1" Then
                        oSheet.Range("A" + CStr(Fila), "G" + CStr(Fila)).Interior.ColorIndex = 20
                    End If
                End If

            End If
            nRowPos += 1
        Loop

        'al final imprimo el ultimo corte
        AuxFila = ObtenerFiladelHiladoconelCodigo("RESERVADO")
        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = dgvHilados.Rows(AuxFila).Cells(0).Value
        oSheet.Cells(Fila, 3).value = dgvHilados.Rows(AuxFila).Cells(2).Value
        oSheet.Cells(Fila, 4).value = dgvHilados.Rows(AuxFila).Cells(3).Value.ToString
        oSheet.Range("A" + CStr(Fila), "G" + CStr(Fila)).Interior.ColorIndex = 15



        '''Imprimo los Commodities
        nRowPos = 0
        Do While nRowPos < dgvPartidas.RowCount

            If InStr(dgvPartidas.Rows(nRowPos).Cells("PARTIDA").Value.ToString, "H") > 0 And CInt(dgvPartidas.Rows(nRowPos).Cells("COMMODITIE").Value) = 1 Then

                If CInt(CORTE) >= CInt(ArtIni) And CInt(CORTE) <= CInt(ArtFin) Then

                    Fila = Fila + 1
                    oSheet.Cells(Fila, 1).value = dgvPartidas.Rows(nRowPos).Cells(1).Value
                    oSheet.Cells(Fila, 2).value = dgvPartidas.Rows(nRowPos).Cells(2).Value
                    oSheet.Cells(Fila, 3).value = dgvPartidas.Rows(nRowPos).Cells(3).Value
                    oSheet.Cells(Fila, 4).value = dgvPartidas.Rows(nRowPos).Cells(4).Value
                    oSheet.Cells(Fila, 5).value = dgvPartidas.Rows(nRowPos).Cells(5).Value
                    oSheet.Cells(Fila, 6).value = dgvPartidas.Rows(nRowPos).Cells(6).Value
                    oSheet.Cells(Fila, 7).value = dgvPartidas.Rows(nRowPos).Cells(9).Value

                    If dgvPartidas.Rows(nRowPos).Cells("ESDISCONTINUADA").Value.ToString = "1" Then
                        oSheet.Range("A" + CStr(Fila), "G" + CStr(Fila)).Interior.ColorIndex = 20
                    End If
                End If

            End If
            nRowPos += 1
        Loop

        'al final imprimo el ultimo corte
        AuxFila = ObtenerFiladelHiladoconelCodigo("COMMODITIES")
        If AuxFila >= 0 Then
            Fila = Fila + 1
            oSheet.Cells(Fila, 1).value = dgvHilados.Rows(AuxFila).Cells(0).Value
            oSheet.Cells(Fila, 3).value = dgvHilados.Rows(AuxFila).Cells(2).Value
            oSheet.Cells(Fila, 4).value = dgvHilados.Rows(AuxFila).Cells(3).Value.ToString
            oSheet.Range("A" + CStr(Fila), "G" + CStr(Fila)).Interior.ColorIndex = 15

            '''Imprimo los Commodities reservados

            nRowPos = 0
            Do While nRowPos < dgvPartidas.RowCount

                If InStr(dgvPartidas.Rows(nRowPos).Cells("PARTIDA").Value.ToString, "G") > 0 And CInt(dgvPartidas.Rows(nRowPos).Cells("COMMODITIE").Value) = 1 Then

                    If CInt(CORTE) >= CInt(ArtIni) And CInt(CORTE) <= CInt(ArtFin) Then

                        Fila = Fila + 1
                        oSheet.Cells(Fila, 1).value = dgvPartidas.Rows(nRowPos).Cells(1).Value
                        oSheet.Cells(Fila, 2).value = dgvPartidas.Rows(nRowPos).Cells(2).Value
                        oSheet.Cells(Fila, 3).value = dgvPartidas.Rows(nRowPos).Cells(3).Value
                        oSheet.Cells(Fila, 4).value = dgvPartidas.Rows(nRowPos).Cells(4).Value
                        oSheet.Cells(Fila, 5).value = dgvPartidas.Rows(nRowPos).Cells(5).Value
                        oSheet.Cells(Fila, 6).value = dgvPartidas.Rows(nRowPos).Cells(6).Value
                        oSheet.Cells(Fila, 7).value = dgvPartidas.Rows(nRowPos).Cells(9).Value

                        If dgvPartidas.Rows(nRowPos).Cells("ESDISCONTINUADA").Value.ToString = "1" Then
                            oSheet.Range("A" + CStr(Fila), "G" + CStr(Fila)).Interior.ColorIndex = 20
                        End If
                    End If

                End If
                nRowPos += 1
            Loop
        End If

        'al final imprimo el ultimo corte
        AuxFila = ObtenerFiladelHiladoconelCodigo("COMMODITIES RES")
        If AuxFila >= 0 Then

            Fila = Fila + 1
            oSheet.Cells(Fila, 1).value = dgvHilados.Rows(AuxFila).Cells(0).Value
            oSheet.Cells(Fila, 3).value = dgvHilados.Rows(AuxFila).Cells(2).Value
            oSheet.Cells(Fila, 4).value = dgvHilados.Rows(AuxFila).Cells(3).Value.ToString
            oSheet.Range("A" + CStr(Fila), "G" + CStr(Fila)).Interior.ColorIndex = 15


            'al final cuando ya estan llenas las columnas con datos le arreglo la alineacion, si lo hacia antes solo alineaba los encabezados
            'que eran lo que estaba cargados hasta que cargaba los datos
            oSheet.Range("E:E").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight

        End If


        'Si no existe el directorio, lo creo
        If Not Directory.Exists(Application.StartupPath + "\Excel") Then Directory.CreateDirectory(Application.StartupPath + "\Excel")
        'Guardo el archivo 
        NombreArchivoExcel = Application.StartupPath + "\Excel\" + "Existencias_Hilados_" + Format(Now, "dd-MM-yyyy HH-mm-ss") + ".xls"
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

    Private Sub dgvPartidas_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvPartidas.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim EsDiscontinuada As String
            dgvPartidas.Rows(dgvPartidas.HitTest(e.Location.X, e.Location.Y).RowIndex).Selected = True
            dgvPartidas.CurrentCell = dgvPartidas.Rows(dgvPartidas.HitTest(e.Location.X, e.Location.Y).RowIndex).Cells(2)

            'acomodo el menu contextual de acuerdo al estado que tenga la solicitud
            EsDiscontinuada = dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("EsDiscontinuada").Value.ToString()
            If EsDiscontinuada = "1" Then
                DiscontinuarPartidaToolStripMenuItem.Enabled = False
                NoDiscontinuarPartidaToolStripMenuItem.Enabled = True
            Else
                DiscontinuarPartidaToolStripMenuItem.Enabled = True
                NoDiscontinuarPartidaToolStripMenuItem.Enabled = False
            End If
        End If

    End Sub

    Private Sub DiscontinuarPartidaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DiscontinuarPartidaToolStripMenuItem.Click
        If dgvPartidas.CurrentRow.Index >= 0 Then
            DiscontinuarPartida_SINO(dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("IDPARTIDA").Value.ToString, dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("PARTIDA").Value.ToString, True, True, True)
        Else
            MensajeAtencion("Debe seleccionar una Fila de la lista.")
        End If
    End Sub
    Private Sub NoDiscontinuarPartidaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NoDiscontinuarPartidaToolStripMenuItem.Click
        If dgvPartidas.CurrentRow.Index >= 0 Then
            DiscontinuarPartida_SINO(dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("IDPARTIDA").Value.ToString, dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("PARTIDA").Value.ToString, False, True, True)
        Else
            MensajeAtencion("Debe seleccionar una Fila de la lista.")
        End If
    End Sub
    Private Sub EditarObservaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarObservaciónToolStripMenuItem.Click
        If dgvPartidas.CurrentRow.Index >= 0 Then
            EditarObservacionPartida(dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("IDPARTIDA").Value.ToString, dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("PARTIDA").Value.ToString, dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("OBSERVACION").Value.ToString, True, True)
        End If
    End Sub
    Private Sub EditarObservacionPartida(ByRef IdPartida As String, ByRef NumeroPartida As String, ByVal ObservacionPartida As String, ByVal mostrarCartelOK As Boolean, ByVal refrescarVentana As Boolean)
        'On Error GoTo ErrEditObservacion
        Dim Reader As SqlDataReader
        Dim Command As New SqlCommand
        Dim sStr As String
        Dim frmObtieneObservacion As New frmObtieneObservacion(False, "EDICIÓN DE OBSERVACIÓN", "INGRESE NUEVA OBSERVACIÓN", "OBSERVACIÓN: ")
        frmObtieneObservacion.ShowDialog()

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        If frmObtieneObservacion.SeConfirmoOK Then
            If frmObtieneObservacion.NrolegajoIngresado.ToString <> ObservacionPartida Then

                sStr = "UPDATE HilamarHiladoStock SET OBSERVACION = '" + frmObtieneObservacion.NrolegajoIngresado.ToString + "', AUDITORIA = 'MODIF|" + Format(Now, "dd/MM/yyyy HH:mm:ss") + "' WHERE ID= " + IdPartida
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()

                If mostrarCartelOK Then
                    MensajeInfo("Observación de partida " + NumeroPartida + " editada correctamente")
                End If

                If refrescarVentana Then
                    CargarReporteHilados()
                End If
            End If
        End If

        'ErrEditObservacion:
        'MensajeCritico("Error al intentar editar la observación de la partida" + Err.Description + Err.Number.ToString)

    End Sub
    Private Sub DiscontinuarPartida_SINO(ByVal IdPartidaParaDiscontinuar As String, ByVal NumeroPartida As String, ByVal Discontinuar As Boolean, ByVal mostrarCartelOK As Boolean, ByVal refrescarVentana As Boolean)
        On Error GoTo ErrDiscontinuar
        Dim Reader As SqlDataReader
        Dim Command As New SqlCommand
        Dim sStr As String

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "UPDATE HilamarHiladoStock "
        sStr = sStr + "SET "
        If Discontinuar Then
            sStr = sStr + " Esdiscontinuada = 1 "
        Else
            sStr = sStr + " Esdiscontinuada = 0 "
        End If
        sStr = sStr + ",Auditoria = 'MODIF|" + Format(Now, "dd/MM/yyyy HH:mm:ss") + "' "
        sStr = sStr + "WHERE ID=" + IdPartidaParaDiscontinuar
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        If mostrarCartelOK Then
            If Discontinuar Then
                MensajeInfo("Partida " + NumeroPartida + " Discontinuada correctamente.")
            Else
                MensajeInfo("Partida " + NumeroPartida + " Reactivada correctamente.")
            End If
        End If
        If refrescarVentana Then
            CargarReporteHilados()
        End If

        Exit Sub
ErrDiscontinuar:
        If Discontinuar Then
            MensajeCritico("Error al intentar Discontinuar la Partida.")
        Else
            MensajeCritico("Error al intentar Quitar el Discontinuado de la Partida.")
        End If
    End Sub

    Private Sub btnProcesoDiario_Click(sender As Object, e As EventArgs) Handles btnProcesoDiario.Click
        Dim Command, Command1 As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr, sStr1 As String
        Dim AuxStock As Integer


        Dim FormProgre As New frmProgreso
        FormProgre.CantMax = 4600
        FormProgre.lblTarea.Text = "Calculando el stock de Hilados "
        FormProgre.lblEstado.Text = "Por favor aguarde unos instantes ..."
        FormProgre.Cargar()
        FormProgre.Show()
        FormProgre.CantProg = 1
        FormProgre.Actualizar()


        Dim FechaInicio As Date = "13/01/2020"

        'Do While Format(FechaInicio, "yyyyMMdd") <= "20191021"
        '    'Do While Format(FechaInicio, "yyyyMMdd") <= Format(Now, "yyyyMMdd")

        '    FechaInicio = DateAdd(DateInterval.Day, 7, FechaInicio)
        'Loop

        FormProgre.CantProg = FormProgre.CantProg + 1
        FormProgre.Actualizar()

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT H.id as IDPARTIDA,* "
        sStr = sStr + " FROM HilamarHiladoStock H INNER JOIN HilamarTipoHiladoPartidas T ON H.Codtipohilado=T.Codigo "
        sStr = sStr + " WHERE H.Eliminado=0 and H.Codtipohilado like '%%' and FechaStockHasta is null " '+ " AND ESDISCONTINUADA=1 "
        sStr = sStr + " ORDER BY CodTipoHilado, Color "

        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read
                'por las dudas borro el datode stock de la partida para la fecha, directamente no pregunto si existe sino que hago el borrado y si existe lo hara y si no , no hara nada
                sStr1 = "UPDATE HilamarStockPartHistorico SET Eliminado=1 WHERE IdPartida=" + Reader.Item("IDPARTIDA").ToString + " and Fecha = '" + Format(FechaInicio, "yyyyMMdd") + "'"
                Command1 = New SqlCommand(sStr1, cConexionApp.SQLConn)
                Command1.ExecuteNonQuery()

                AuxStock = HilamarObtengoStockActualPartida(Reader.Item("PARTIDA").ToString, FechaInicio)
                If AuxStock > 0 Then
                    sStr1 = "INSERT INTO HilamarStockPartHistorico (IdPartida,Fecha,Stock,Eliminado) VALUES (" + Reader.Item("IDPARTIDA").ToString + ",'" + Format(FechaInicio, "yyyyMMdd") + "'," + AuxStock.ToString + ",0)"
                    Command1 = New SqlCommand(sStr1, cConexionApp.SQLConn)
                    Command1.ExecuteNonQuery()
                End If

                FormProgre.CantProg = FormProgre.CantProg + 1
                FormProgre.Actualizar()

            Loop
            Reader.NextResult()
        Loop

        FormProgre.Close()

        MensajeInfo("El proceso a terminado corretamente")

    End Sub

    Private Sub GraficarHistoricoStockHilados()
        Dim sqlProducts As String
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        'Elimino el control si ya existe!
        For Each C As Control In Me.Controls
            If TypeOf C Is Chart Then
                Me.Controls.Remove(C)
            End If
        Next

        Dim Chart1 = New Chart()
        Me.Controls.Add(Chart1)

        Chart1.Size = New System.Drawing.Size(1098, 165)
        Chart1.Location = New System.Drawing.Point(5, 525)
        Chart1.Name = "Chart1"

        Dim titulo As Title = New Title("EVOLUCIÓN DEL STOCK DE HILADOS")
        Chart1.Titles.Add(titulo)

        Dim ChartArea As ChartArea = New ChartArea
        Dim Series1 As Series = New Series()
        Dim Series2 As Series = New Series()

        sqlProducts = "select * from ( SELECT TOP 9 LEFT(CONVERT(VARCHAR(10), A.FECHA, 103),5) as FECHA,DICONTINUADA,TOTAL,A.FECHA AS FECHADATE FROM "
        sqlProducts = sqlProducts + "("
        sqlProducts = sqlProducts + "select FECHA,SUM(STOCK) as DICONTINUADA from HilamarStockPartHistorico SH INNER JOIN HilamarHiladoStock H ON SH.IDPARTIDA=H.ID "
        sqlProducts = sqlProducts + "where SH.eliminado = 0 And EsDiscontinuada = 1 "
        sqlProducts = sqlProducts + "GROUP BY Fecha) A "
        sqlProducts = sqlProducts + " INNER JOIN "
        sqlProducts = sqlProducts + "(select FECHA ,SUM(STOCK) AS TOTAL from HilamarStockPartHistorico SH INNER JOIN HilamarHiladoStock H ON SH.IDPARTIDA=H.ID "
        sqlProducts = sqlProducts + "where SH.eliminado = 0 "
        sqlProducts = sqlProducts + "GROUP BY Fecha) B "
        sqlProducts = sqlProducts + " ON A.FECHA=B.FECHA "
        sqlProducts = sqlProducts + "order by A.fecha DESC"
        sqlProducts = sqlProducts + ") A order by FECHADATE ASC"
        Command = New SqlCommand(sqlProducts, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()

        Chart1.DataSource = Reader

        ChartArea.Name = "ChartArea1"
        Chart1.ChartAreas.Add(ChartArea)

        'para ocultar las cuadriculas
        Chart1.ChartAreas(0).AxisX.MajorGrid.LineWidth = 0
        'Chart1.ChartAreas(0).AxisX.Title = "Version"
        Chart1.ChartAreas(0).AxisY.MajorGrid.LineWidth = 0

        Series1.Legend = "uno"
        Series1.Name = "TOTAL"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = SeriesChartType.Line

        Series2.Legend = "dos"
        Series2.Name = "DISCONTINUO"
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = SeriesChartType.Line

        Chart1.Series.Add(Series1)
        Chart1.Series.Add(Series2)

        Dim legend1 As Legend = New Legend("uno")
        Dim legend2 As Legend = New Legend("dos")

        Chart1.Legends.Add(legend1)
        Chart1.Legends.Add(legend2)

        Chart1.Legends(0).Position.Auto = False
        Chart1.Legends(0).Position = New ElementPosition(90, 1, 10, 10)
        Chart1.Legends(1).Position.Auto = False
        Chart1.Legends(1).Position = New ElementPosition(90, 11, 10, 10)

        Chart1.Series("DISCONTINUO").XValueMember = "Fecha"
        Chart1.Series("DISCONTINUO").YValueMembers = "DICONTINUADA"
        Chart1.Series("DISCONTINUO").Color = Color.Blue
        Chart1.Series("DISCONTINUO").SmartLabelStyle.Enabled = True
        Chart1.Series("DISCONTINUO").Label = "#VALY"

        Chart1.Series("TOTAL").XValueMember = "Fecha"
        Chart1.Series("TOTAL").YValueMembers = "TOTAL"
        Chart1.Series("TOTAL").Color = Color.Red
        Chart1.Series("TOTAL").SmartLabelStyle.Enabled = True
        Chart1.Series("TOTAL").Label = "#VALY"
    End Sub

   
End Class