Imports System.Data.SqlClient

Public Class frmRepoCompStock
    Dim ColTipoHilado, ColTipoGalga As New Collection

    Private Sub cmdListar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListar.Click
        CargarListado()
    End Sub


    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Close()
    End Sub

    Private Sub CargarListado()
        Dim CommandList As New SqlCommand
        Dim ReaderList As SqlDataReader
        Dim sStrList As String
        Dim row As String()
        Dim Mes As Integer
        Dim AcumStockMes2017, AcumStockMes2018, AcumVentaMes2017, AcumVentaMes2018, AcumCrudoMes2017, AcumCrudoMes2018 As Long

        Dim ArtStockMes2017, ArtStockMes2018, ArtVentaMes2017, ArtVentaMes2018, ArtCrudoMes2017, ArtCrudoMes2018 As Long



        Dim CantXXS, CantXS, CantS, CantM, CantL, CantXL, CantXXL, CantU As Long
        Dim CodArt As String = ""

        Dim FechaInicio2017, FechaFin2017, FechaInicio2018, FechaFin2018 As Date

        Dim TotalArticulos As Integer = 0

        LimpiarDGV()
        ArmarDGV()

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")


        sStrList = "SELECT count(*) as CANT FROM Articulos "
        sStrList = sStrList + " WHERE HABILITADO = 1 "
        If cmbGalgas.Text <> "TODOS" Then sStrList = sStrList + " AND CodTipoGalga = " + ColTipoGalga(cmbGalgas.Text).ToString + " "
        If cmbHilados.Text <> "TODOS" Then sStrList = sStrList + " AND CodTipoHilado = " + ColTipoHilado(cmbHilados.Text).ToString + " "
        If txtCodArticulo.Text <> "" Then sStrList = sStrList + " AND CodArticulo= '" + txtCodArticulo.Text + "' "
        If txtFechaPagina.Text <> "" Then sStrList = sStrList + "AND Letra = '" + txtFechaPagina.Text + "' "

        CommandList = New SqlCommand(sStrList, cConexionApp.SQLConn)
        ReaderList = CommandList.ExecuteReader()
        If ReaderList.HasRows Then
            If ReaderList.Read Then
                TotalArticulos = ReaderList.Item("CANT")
            End If
        End If

        Dim FormProgre As New frmProgreso
        FormProgre.CantMax = (TotalArticulos * 5) + 1
        FormProgre.lblTarea.Text = "Procesando Reporte."
        FormProgre.lblEstado.Text = "Verificando conexión ..."
        FormProgre.Cargar()
        FormProgre.Show()
        FormProgre.CantProg = 1
        FormProgre.Actualizar()


        For Mes = 8 To 8
            AcumStockMes2017 = 0
            AcumStockMes2018 = 0
            AcumVentaMes2017 = 0
            AcumVentaMes2018 = 0
            AcumCrudoMes2017 = 0
            AcumCrudoMes2018 = 0

            FechaInicio2017 = CDate("01/" + Mes.ToString + "/2017")
            FechaFin2017 = FechaInicio2017.AddMonths(1).AddDays(-1)
            FechaInicio2018 = CDate("01/" + Mes.ToString + "/2018")
            FechaFin2018 = FechaInicio2018.AddMonths(1).AddDays(-1)

            sStrList = "SELECT * FROM Articulos "
            sStrList = sStrList + " WHERE HABILITADO = 1 "

            'sStrList = sStrList + " AND (CodArticulo>330 and CodArticulo<352) "

            If cmbGalgas.Text <> "TODOS" Then sStrList = sStrList + " AND CodTipoGalga = " + ColTipoGalga(cmbGalgas.Text).ToString + " "
            If cmbHilados.Text <> "TODOS" Then sStrList = sStrList + " AND CodTipoHilado = " + ColTipoHilado(cmbHilados.Text).ToString + " "
            If txtCodArticulo.Text <> "" Then sStrList = sStrList + " AND CodArticulo= '" + txtCodArticulo.Text + "' "
            If txtFechaPagina.Text <> "" Then sStrList = sStrList + "AND FechaPagina = '" + txtFechaPagina.Text + "' "
            sStrList = sStrList + " ORDER BY CodArticulo "

            CommandList = New SqlCommand(sStrList, cConexionApp.SQLConn)
            ReaderList = CommandList.ExecuteReader()
            Do While ReaderList.HasRows
                Do While ReaderList.Read()

                    ArtStockMes2017 = 0
                    ArtStockMes2018 = 0
                    ArtVentaMes2017 = 0
                    ArtVentaMes2018 = 0
                    ArtCrudoMes2017 = 0
                    ArtCrudoMes2018 = 0

                    FormProgre.lblEstado.Text = "Calculando Mes " + Mes.ToString + " Artículo: " + ReaderList.Item("CodArticulo").ToString + " ..."
                    FormProgre.CantProg = FormProgre.CantProg + 1
                    FormProgre.Actualizar()

                    CodArt = ReaderList.Item("CodArticulo")

                    ArtStockMes2017 = StockArticulo(CodArt, 1, FechaFin2017)
                    AcumStockMes2017 = AcumStockMes2017 + ArtStockMes2017

                    ArtVentaMes2017 = VentaArticuloDetalladoGeneral(CodArt, 1, FechaInicio2017, FechaFin2017)
                    AcumVentaMes2017 = AcumVentaMes2017 + ArtVentaMes2017

                    If FechaFin2017 <= "22/11/2017" Then


                        'AcumCrudoMes2017 = ArticuloStockInicialViejo(CodArt.ToString, FechaFin2017, "") + MovsArticuloViejo(CodArt.ToString, FechaFin2017, "")
                        'AcumCrudoMes2017 = AcumCrudoMes2017 + (ArticuloStockInicialViejo(CodArt.ToString, FechaFin2017, "GRIS") + MovsArticuloViejo(CodArt.ToString, FechaFin2017, "GRIS"))

                        CantXXS = ArticuloStockInicialViejo(CodArt.ToString, CodigoTalle("XXS"), "", FechaFin2017) + MovsArticuloViejo(CodArt.ToString, CodigoTalle("XXS"), "", FechaFin2017)
                        CantXS = ArticuloStockInicialViejo(CodArt.ToString, CodigoTalle("XS"), "", FechaFin2017) + MovsArticuloViejo(CodArt.ToString, CodigoTalle("XS"), "", FechaFin2017)
                        CantS = ArticuloStockInicialViejo(CodArt.ToString, CodigoTalle("S"), "", FechaFin2017) + MovsArticuloViejo(CodArt.ToString, CodigoTalle("S"), "", FechaFin2017)
                        CantM = ArticuloStockInicialViejo(CodArt.ToString, CodigoTalle("M"), "", FechaFin2017) + MovsArticuloViejo(CodArt.ToString, CodigoTalle("M"), "", FechaFin2017)
                        CantL = ArticuloStockInicialViejo(CodArt.ToString, CodigoTalle("L"), "", FechaFin2017) + MovsArticuloViejo(CodArt.ToString, CodigoTalle("L"), "", FechaFin2017)
                        CantXL = ArticuloStockInicialViejo(CodArt.ToString, CodigoTalle("XL"), "", FechaFin2017) + MovsArticuloViejo(CodArt.ToString, CodigoTalle("XL"), "", FechaFin2017)
                        CantXXL = ArticuloStockInicialViejo(CodArt.ToString, CodigoTalle("XXL"), "", FechaFin2017) + MovsArticuloViejo(CodArt.ToString, CodigoTalle("XXL"), "", FechaFin2017)
                        CantU = ArticuloStockInicialViejo(CodArt.ToString, CodigoTalle("U"), "", FechaFin2017) + MovsArticuloViejo(CodArt.ToString, CodigoTalle("U"), "", FechaFin2017)

                        ArtCrudoMes2017 = ArtCrudoMes2017 + CantXXS + CantXS + CantS + CantM + CantL + CantXL + CantXXL + CantU

                        If CodArt = "928" Or CodArt = "964" Then
                            CantXXS = ArticuloStockInicialViejo(CodArt.ToString, CodigoTalle("XXS"), "CRUDO BUENO", FechaFin2017) + MovsArticuloViejo(CodArt.ToString, CodigoTalle("XXS"), "CRUDO BUENO", FechaFin2017)
                            CantXS = ArticuloStockInicialViejo(CodArt.ToString, CodigoTalle("XS"), "CRUDO BUENO", FechaFin2017) + MovsArticuloViejo(CodArt.ToString, CodigoTalle("XS"), "CRUDO BUENO", FechaFin2017)
                            CantS = ArticuloStockInicialViejo(CodArt.ToString, CodigoTalle("S"), "CRUDO BUENO", FechaFin2017) + MovsArticuloViejo(CodArt.ToString, CodigoTalle("S"), "CRUDO BUENO", FechaFin2017)
                            CantM = ArticuloStockInicialViejo(CodArt.ToString, CodigoTalle("M"), "CRUDO BUENO", FechaFin2017) + MovsArticuloViejo(CodArt.ToString, CodigoTalle("M"), "CRUDO BUENO", FechaFin2017)
                            CantL = ArticuloStockInicialViejo(CodArt.ToString, CodigoTalle("L"), "CRUDO BUENO", FechaFin2017) + MovsArticuloViejo(CodArt.ToString, CodigoTalle("L"), "CRUDO BUENO", FechaFin2017)
                            CantXL = ArticuloStockInicialViejo(CodArt.ToString, CodigoTalle("XL"), "CRUDO BUENO", FechaFin2017) + MovsArticuloViejo(CodArt.ToString, CodigoTalle("XL"), "CRUDO BUENO", FechaFin2017)
                            CantXXL = ArticuloStockInicialViejo(CodArt.ToString, CodigoTalle("XXL"), "CRUDO BUENO", FechaFin2017) + MovsArticuloViejo(CodArt.ToString, CodigoTalle("XXL"), "CRUDO BUENO", FechaFin2017)
                            CantU = ArticuloStockInicialViejo(CodArt.ToString, CodigoTalle("U"), "CRUDO BUENO", FechaFin2017) + MovsArticuloViejo(CodArt.ToString, CodigoTalle("U"), "CRUDO BUENO", FechaFin2017)

                            ArtCrudoMes2017 = ArtCrudoMes2017 + CantXXS + CantXS + CantS + CantM + CantL + CantXL + CantXXL + CantU
                        End If

                        CantXXS = ArticuloStockInicialViejo(CodArt.ToString, CodigoTalle("XXS"), "GRIS", FechaFin2017) + MovsArticuloViejo(CodArt.ToString, CodigoTalle("XXS"), "GRIS", FechaFin2017)
                        CantXS = ArticuloStockInicialViejo(CodArt.ToString, CodigoTalle("XS"), "GRIS", FechaFin2017) + MovsArticuloViejo(CodArt.ToString, CodigoTalle("XS"), "GRIS", FechaFin2017)
                        CantS = ArticuloStockInicialViejo(CodArt.ToString, CodigoTalle("S"), "GRIS", FechaFin2017) + MovsArticuloViejo(CodArt.ToString, CodigoTalle("S"), "GRIS", FechaFin2017)
                        CantM = ArticuloStockInicialViejo(CodArt.ToString, CodigoTalle("M"), "GRIS", FechaFin2017) + MovsArticuloViejo(CodArt.ToString, CodigoTalle("M"), "GRIS", FechaFin2017)
                        CantL = ArticuloStockInicialViejo(CodArt.ToString, CodigoTalle("L"), "GRIS", FechaFin2017) + MovsArticuloViejo(CodArt.ToString, CodigoTalle("L"), "GRIS", FechaFin2017)
                        CantXL = ArticuloStockInicialViejo(CodArt.ToString, CodigoTalle("XL"), "GRIS", FechaFin2017) + MovsArticuloViejo(CodArt.ToString, CodigoTalle("XL"), "GRIS", FechaFin2017)
                        CantXXL = ArticuloStockInicialViejo(CodArt.ToString, CodigoTalle("XXL"), "GRIS", FechaFin2017) + MovsArticuloViejo(CodArt.ToString, CodigoTalle("XXL"), "GRIS", FechaFin2017)
                        CantU = ArticuloStockInicialViejo(CodArt.ToString, CodigoTalle("U"), "GRIS", FechaFin2017) + MovsArticuloViejo(CodArt.ToString, CodigoTalle("U"), "GRIS", FechaFin2017)

                        ArtCrudoMes2017 = ArtCrudoMes2017 + CantXXS + CantXS + CantS + CantM + CantL + CantXL + CantXXL + CantU

                        If ArtCrudoMes2017 > 0 Then
                            AcumCrudoMes2017 = AcumCrudoMes2017 + ArtCrudoMes2017
                        End If
                    Else
                        ArtCrudoMes2017 = ArticuloStockCrudo(CodArt, FechaFin2017)
                        AcumCrudoMes2017 = AcumCrudoMes2017 + ArtCrudoMes2017

                        'CantXXS = ArticuloStockInicial(CodArt.ToString, CodigoTalle("XXS"), Reader.Item("Color")) + MovsArticulo(CodArt.ToString, CodigoTalle("XXS"), Reader.Item("Color"))
                        'CantXS = ArticuloStockInicial(CodArt.ToString, CodigoTalle("XS"), Reader.Item("Color")) + MovsArticulo(CodArt.ToString, CodigoTalle("XS"), Reader.Item("Color"))
                        'CantS = ArticuloStockInicial(CodArt.ToString, CodigoTalle("S"), Reader.Item("Color")) + MovsArticulo(CodArt.ToString, CodigoTalle("S"), Reader.Item("Color"))
                        'CantM = ArticuloStockInicial(CodArt.ToString, CodigoTalle("M"), Reader.Item("Color")) + MovsArticulo(CodArt.ToString, CodigoTalle("M"), Reader.Item("Color"))
                        'CantL = ArticuloStockInicial(CodArt.ToString, CodigoTalle("L"), Reader.Item("Color")) + MovsArticulo(CodArt.ToString, CodigoTalle("L"), Reader.Item("Color"))
                        'CantXL = ArticuloStockInicial(CodArt.ToString, CodigoTalle("XL"), Reader.Item("Color")) + MovsArticulo(CodArt.ToString, CodigoTalle("XL"), Reader.Item("Color"))
                        'CantXXL = ArticuloStockInicial(CodArt.ToString, CodigoTalle("XXL"), Reader.Item("Color")) + MovsArticulo(CodArt.ToString, CodigoTalle("XXL"), Reader.Item("Color"))
                    End If

                    If FechaInicio2018 < Now Then
                        ArtStockMes2018 = StockArticulo(CodArt, 1, FechaFin2018)
                        AcumStockMes2018 = AcumStockMes2018 + ArtStockMes2018
                        If CodArt = "370" And Format(FechaFin2018, "yyyyMMdd") = "20180831" Then
                            ArtCrudoMes2018 = ArticuloStockCrudo(CodArt, DateAdd(DateInterval.Day, -1, FechaFin2018))
                        Else
                            ArtCrudoMes2018 = ArticuloStockCrudo(CodArt, FechaFin2018)
                        End If
                        If ArtCrudoMes2018 > 0 Then
                            AcumCrudoMes2018 = AcumCrudoMes2018 + ArtCrudoMes2018
                        End If
                        ArtVentaMes2018 = VentaArticuloDetalladoGeneral(CodArt, 1, FechaInicio2018, FechaFin2018)
                        AcumVentaMes2018 = AcumVentaMes2018 + ArtVentaMes2018
                    End If


                    row = {CodArt.ToString, ArtStockMes2017, ArtCrudoMes2017, ArtVentaMes2017, ArtStockMes2018, ArtCrudoMes2018, ArtVentaMes2018}
                    dgvDatos.Rows.Add(row)

                Loop
                ReaderList.NextResult()
            Loop


            row = {Mes.ToString, AcumStockMes2017, AcumCrudoMes2017, AcumVentaMes2017, AcumStockMes2018, AcumCrudoMes2018, AcumVentaMes2018}
            dgvDatos.Rows.Add(row)

        Next Mes

        FormProgre.Close()

    End Sub

    Private Sub LimpiarDGV()
        dgvDatos.Rows.Clear()
        dgvDatos.Columns.Clear()
    End Sub

    Private Sub ArmarDGV()
        dgvDatos.Columns.Add("MES", "MES")
        dgvDatos.Columns("MES").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvDatos.Columns("MES").Width = 90
        dgvDatos.Columns("MES").ReadOnly = True
        dgvDatos.Columns.Add("STOCK2017", "STOCK 2017")
        dgvDatos.Columns("STOCK2017").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDatos.Columns("STOCK2017").Width = 110
        dgvDatos.Columns("STOCK2017").ReadOnly = True
        dgvDatos.Columns.Add("CRUDO2017", "CRUDO 2017")
        dgvDatos.Columns("CRUDO2017").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDatos.Columns("CRUDO2017").Width = 110
        dgvDatos.Columns("CRUDO2017").ReadOnly = True
        dgvDatos.Columns.Add("VENTA2017", "VENTA 2017")
        dgvDatos.Columns("VENTA2017").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDatos.Columns("VENTA2017").Width = 110
        dgvDatos.Columns("VENTA2017").ReadOnly = True
        dgvDatos.Columns.Add("STOCK2018", "STOCK 2018")
        dgvDatos.Columns("STOCK2018").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDatos.Columns("STOCK2018").Width = 110
        dgvDatos.Columns("STOCK2018").ReadOnly = True
        dgvDatos.Columns.Add("CRUDO2018", "CRUDO 2018")
        dgvDatos.Columns("CRUDO2018").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDatos.Columns("CRUDO2018").Width = 110
        dgvDatos.Columns("CRUDO2018").ReadOnly = True
        dgvDatos.Columns.Add("VENTA2018", "VENTA 2018")
        dgvDatos.Columns("VENTA2018").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDatos.Columns("VENTA2018").Width = 110
        dgvDatos.Columns("VENTA2018").ReadOnly = True

        dgvDatos.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 9)
        dgvDatos.DefaultCellStyle.Font = New Font("Tahoma", 9)
        dgvDatos.RowTemplate.Height = 25

    End Sub

    Private Sub frmRepoCompStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'dtpDesde.Value = DateAdd(DateInterval.Month, -12, Now)
        dtpDesde.Value = CDate("01/07/2017")
        dtpHasta.Value = Now
        cargarCombos()
    End Sub
    Private Sub CargarCombos()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        ColTipoHilado.Clear()
        ColTipoHilado.Add("0", "TODOS")
        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        With cmbHilados.Items
            .Clear()
            .Add("TODOS")
            sStr = "SELECT * FROM StockTipoHilados WHERE Eliminado = 0 ORDER BY Descripcion"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            Do While Reader.HasRows
                Do While Reader.Read
                    .Add(Reader.Item("Descripcion").ToString)
                    ColTipoHilado.Add(Reader.Item("id").ToString, Reader.Item("Descripcion").ToString)
                Loop
                Reader.NextResult()
            Loop
        End With
        cmbHilados.Text = cmbHilados.Items(0).ToString

        ColTipoGalga.Clear()
        ColTipoGalga.Add("0", "TODOS")
        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        With cmbGalgas.Items
            .Clear()
            .Add("TODOS")
            sStr = "SELECT * FROM ProdTipoGalgas WHERE Eliminado = 0 AND Descripcion <> '' ORDER BY Descripcion"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            Do While Reader.HasRows
                Do While Reader.Read
                    .Add(Reader.Item("Descripcion").ToString)
                    ColTipoGalga.Add(Reader.Item("id").ToString, Reader.Item("Descripcion").ToString)
                Loop
                Reader.NextResult()
            Loop
        End With
        cmbGalgas.Text = cmbGalgas.Items(0).ToString
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        If dgvDatos.RowCount <= 0 Then Exit Sub

        pdoImpReporte.DefaultPageSettings.Landscape = False
        pdoImpReporte.DefaultPageSettings.Margins.Left = 10
        pdoImpReporte.DefaultPageSettings.Margins.Right = 10
        pdoImpReporte.DefaultPageSettings.Margins.Top = 20
        pdoImpReporte.DefaultPageSettings.Margins.Bottom = 20
        pdoImpReporte.OriginAtMargins = True ' takes margins into account 

        Dim dlgPrintPreview As New EnhancedPrintPreviewDialog
        dlgPrintPreview.ClientSize = New System.Drawing.Size(600, 600)
        dlgPrintPreview.Document = pdoImpReporte ' Previews print
        dlgPrintPreview.ShowDialog()

        'pdoImpReporte.Print()

    End Sub

    Private nRowPos As Int16
    Private NewPage As Boolean
    Private nPageNo As Int16
    Private lPageNo As String = ""

    Private Sub pdoImpReporte_BeginPrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles pdoImpReporte.BeginPrint
        nRowPos = 0
        NewPage = True
        nPageNo = 1
    End Sub

    Private Sub pdoImpReporte_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdoImpReporte.PrintPage
        On Error Resume Next

        Dim AuxTotal As String
        Dim Col As Integer

        Dim FuenteLineas As Font = New Drawing.Font("Arial", 9, FontStyle.Regular)
        Dim FuenteLineas7 As Font = New Drawing.Font("Arial", 7, FontStyle.Regular)
        Dim FuenteLineas8 As Font = New Drawing.Font("Arial", 8, FontStyle.Regular)
        Dim FuenteTituloEnc As Font = New Drawing.Font("Arial", 11, FontStyle.Bold)

        Dim nTop As Int16 = e.MarginBounds.Top
        Dim nRowsPerPage As Int16

        Do While nRowPos < dgvDatos.RowCount

            If nTop > e.MarginBounds.Height - e.MarginBounds.Top - 30 Then

                'LUEGO EL PIE DE PAGINA
                DrawFooter(e, nRowsPerPage)

                nPageNo += 1
                NewPage = True
                e.HasMorePages = True
                Exit Sub

            Else

                If NewPage Then

                    ' Draw Header
                    e.Graphics.DrawString("REPORTE COMPARATIVO VENTAS, STOCK TERMINADO Y CRUDO ", FuenteTituloEnc, Brushes.Black, 50, nTop + 3)
                    e.Graphics.DrawRectangle(Pens.Black, 30, nTop + 1, 640, 20)
                    nTop = nTop + 55

                    'LOS ENCABEZADOS DE LA TABLA
                    e.Graphics.DrawLine(Pens.Black, 20, nTop, 1100, nTop)
                    nTop = nTop + 2
                    Col = 21

                    e.Graphics.DrawString("MES", FuenteLineas8, Brushes.Black, Col, nTop)
                    Col = Col + 50
                    e.Graphics.DrawString("STOCK 2017", FuenteLineas8, Brushes.Black, Col + 110 - e.Graphics.MeasureString("STOCK 2017", FuenteLineas8).Width, nTop)
                    Col = Col + 110
                    e.Graphics.DrawString("CRUDO 2017", FuenteLineas8, Brushes.Black, Col + 110 - e.Graphics.MeasureString("CRUDO 2017", FuenteLineas8).Width, nTop)
                    Col = Col + 110
                    e.Graphics.DrawString("VENTA 2017", FuenteLineas8, Brushes.Black, Col + 110 - e.Graphics.MeasureString("VENTA 2017", FuenteLineas8).Width, nTop)
                    Col = Col + 110
                    e.Graphics.DrawString("STOCK 2018", FuenteLineas8, Brushes.Black, Col + 110 - e.Graphics.MeasureString("STOCK 2018", FuenteLineas8).Width, nTop)
                    Col = Col + 110
                    e.Graphics.DrawString("CRUDO 2018", FuenteLineas8, Brushes.Black, Col + 110 - e.Graphics.MeasureString("CRUDO 2018", FuenteLineas8).Width, nTop)
                    Col = Col + 110
                    e.Graphics.DrawString("VENTA 2018", FuenteLineas8, Brushes.Black, Col + 110 - e.Graphics.MeasureString("VENTA 2018", FuenteLineas8).Width, nTop)
                    Col = Col + 110

                    e.Graphics.DrawLine(Pens.Black, 20, nTop + 16, 1100, nTop + 16)

                    nTop = nTop + 20

                    NewPage = False

                End If

                Col = 21

                e.Graphics.DrawString(dgvDatos.Rows(nRowPos).Cells(0).Value, FuenteLineas8, Brushes.Black, New RectangleF(Col, nTop, 50, 23))
                Col = Col + 50

                For i = 1 To 6
                    AuxTotal = dgvDatos.Rows(nRowPos).Cells(i).Value
                    e.Graphics.DrawString(AuxTotal, FuenteLineas8, Brushes.Black, Col + 110 - e.Graphics.MeasureString(AuxTotal, FuenteLineas8).Width, nTop)
                    Col = Col + 110
                Next i

                nTop = nTop + 22

            End If

            nRowPos += 1
            nRowsPerPage += 1
        Loop

        'LUEGO EL PIE DE PAGINA
        DrawFooter(e, nRowsPerPage)

    End Sub

    Public Sub DrawFooter(ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal RowsPerPage As Int32)
        Dim FuenteLineas8 As Font = New Drawing.Font("Arial", 8, FontStyle.Regular)

        Dim sPageNo As String = nPageNo.ToString + " de "

        If nPageNo = "1" Then
            lPageNo = Math.Ceiling((dgvDatos.Rows.Count - 1) / RowsPerPage).ToString()
            sPageNo = nPageNo.ToString + " de " + lPageNo
        Else
            sPageNo = nPageNo.ToString + " de " + lPageNo
        End If

        e.Graphics.DrawLine(Pens.Black, 20, e.MarginBounds.Height - 17, 1100, e.MarginBounds.Height - 17)

        ' Right Align - User Name
        e.Graphics.DrawString(Format(Now, "dd/MM/yyyy HH:mm:ss"), FuenteLineas8, Brushes.Black, 990, e.MarginBounds.Height - 15)

        ' Center - Page No. Info
        e.Graphics.DrawString(sPageNo, FuenteLineas8, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(sPageNo, FuenteLineas8, e.MarginBounds.Width).Width) / 2, e.MarginBounds.Height - 15)

        e.Graphics.DrawLine(Pens.Black, 20, e.MarginBounds.Height, 1100, e.MarginBounds.Height)

    End Sub

End Class