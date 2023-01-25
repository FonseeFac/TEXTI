Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.IO

Public Class frmCostosReporte

    Dim CotizacionDolar As Double = 0.0

    Dim estoyCargandoFormulario As Boolean

    Dim ColListaDeHilados As New Collection

    Private Sub CargarListadodeCostosdeHilados()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        Dim Col As Integer

        Dim Precio, Costo, CostoTotal As Double

        limpiaryarmardgvDetalleCostos()

        For Col = 3 To dgvCostos.ColumnCount - 1
            CostoTotal = 0.0
            sStr = "select * from HilamarCompCostosHilados where IdHil = " + ColListaDeHilados.Item(dgvCostos.Columns(Col).HeaderText) + " AND isnull(EsInterno,0)=0"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            Do While Reader.HasRows
                Do While Reader.Read()

                    Precio = ObtengoCostoDelElemento(Reader.Item("Tipo").ToString, Reader.Item("IdComp").ToString)
                    Costo = Reader.Item("Factor") * Precio

                    If Reader.Item("IdComp").ToString = "OS" Then
                        Costo = Costo / 1000
                    End If

                    CostoTotal = CostoTotal + Costo
                    dgvCostos.Rows(FilaSiMeDanDatosdelComponente(Reader.Item("Tipo").ToString, Reader.Item("IdComp").ToString, Reader.Item("DescAdic").ToString)).Cells(Col).Value = Format(Costo, "0.00")
                    dgvCostos.Rows(FilaSiMeDanDatosdelComponente(Reader.Item("Tipo").ToString, Reader.Item("IdComp").ToString, Reader.Item("DescAdic").ToString)).Cells(Col).Style.ForeColor = Color.Black
                Loop
                Reader.NextResult()
            Loop
            'al final pongo el costo total del hilado
            dgvCostos.Rows(FilaSiMeDanDatosdelComponente("COSTOTOTAL", "COSTOTOTAL", "COSTO TOTAL POR KILOGRAMO")).Cells(Col).Value = Format(CostoTotal, "0.00")
            dgvCostos.Rows(FilaSiMeDanDatosdelComponente("COSTOTOTAL", "COSTOTOTAL", "COSTO TOTAL POR KILOGRAMO")).Cells(Col).Style.BackColor = Color.LightGray
        Next

        dgvCostos.Select()

    End Sub
    Private Function FilaSiMeDanDatosdelComponente(ByVal Tipo As String, ByVal IdComp As String, ByVal DescAdic As String) As Integer
        Dim i As Integer = -1

        If DescAdic <> "" Then
            For i = 0 To dgvCostos.RowCount - 1
                If dgvCostos.Rows(i).Cells("TIPO").Value.ToString = Tipo And dgvCostos.Rows(i).Cells("IDCOMP").Value.ToString = IdComp _
                    And dgvCostos.Rows(i).Cells("COMPONENTE").Value.ToString = DescAdic Then
                    FilaSiMeDanDatosdelComponente = i
                    Exit Function
                End If
            Next i
        Else
            For i = 0 To dgvCostos.RowCount - 1
                If dgvCostos.Rows(i).Cells("TIPO").Value.ToString = Tipo And dgvCostos.Rows(i).Cells("IDCOMP").Value.ToString = IdComp Then
                    FilaSiMeDanDatosdelComponente = i
                    Exit Function
                End If
            Next i
        End If

        FilaSiMeDanDatosdelComponente = i
    End Function

    Private Sub limpiaryarmardgvDetalleCostos()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        Dim row, LineaCompleta As String()
        Dim Descripcion As String

        Dim Fila, Columna As Integer

        dgvCostos.RowTemplate.Height = 25

        dgvCostos.Rows.Clear()
        dgvCostos.Columns.Clear()

        'primero las columnas de tipo y id de cada fila
        dgvCostos.Columns.Add("TIPO", "TIPO")
        dgvCostos.Columns("TIPO").Visible = False
        dgvCostos.Columns.Add("IDCOMP", "IDCOMP")
        dgvCostos.Columns("IDCOMP").Visible = False
        'ahora la columna de titulo de los componetes
        dgvCostos.Columns.Add("COMPONENTE", "COMPONENTE")
        dgvCostos.Columns("COMPONENTE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvCostos.Columns("COMPONENTE").Width = 180
        dgvCostos.Columns("COMPONENTE").ReadOnly = True

        ColListaDeHilados.Clear()
        'DESPUES LAS COLUMNAS CON LOS DISTINTOS HILADOS
        sStr = "select Id,Descripcion from HilamarHilados "
        If cmbFiltroHiladosconCosto.Text = "CON COSTO" Then
            sStr = sStr + " WHERE Id in (SELECT DISTINCT(IDHIL) FROM HilamarcompcostosHilados WHERE EsInterno = 0) "
        End If
        sStr = sStr + " order by Descripcion"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                dgvCostos.Columns.Add(Reader.Item("Descripcion").ToString, Reader.Item("Descripcion").ToString)
                dgvCostos.Columns(Reader.Item("Descripcion").ToString).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvCostos.Columns(Reader.Item("Descripcion").ToString).Width = 100
                dgvCostos.Columns(Reader.Item("Descripcion").ToString).SortMode = DataGridViewColumnSortMode.NotSortable
                dgvCostos.Columns(Reader.Item("Descripcion").ToString).ReadOnly = True

                ColListaDeHilados.Add(Reader.Item("id").ToString, Reader.Item("Descripcion").ToString)
            Loop
            Reader.NextResult()
        Loop


        sStr = "select distinct(Tipo+'-'+idcomp+'-'+descadic) as LineaCompleta from HilamarcompcostosHilados "
        sStr = sStr + " where EsInterno = 0 "
        sStr = sStr + " order by Tipo+'-'+idcomp+'-'+descadic"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                LineaCompleta = Reader.Item("LineaCompleta").ToString.Split("-")
                If LineaCompleta(2) = "" Then
                    Descripcion = ObtengoDescripcionDelElemento(LineaCompleta(0), LineaCompleta(1))
                Else
                    Descripcion = LineaCompleta(2)
                End If
                row = {LineaCompleta(0), LineaCompleta(1), Descripcion}
                dgvCostos.Rows.Add(row)
                dgvCostos.Rows(dgvCostos.RowCount - 1).Cells("COMPONENTE").Style.BackColor = Color.LightGray
            Loop
            Reader.NextResult()
        Loop

        'por defecto arrancan todas las celdas con un "NO" asi luego solo tengoque llenar las que tengas costo

        For Columna = 3 To dgvCostos.ColumnCount - 1
            For Fila = 0 To dgvCostos.RowCount - 1
                dgvCostos.Rows(Fila).Cells(Columna).Value = "NO"
                dgvCostos.Rows(Fila).Cells(Columna).Style.ForeColor = Color.Gray
            Next
        Next

        'al final la linea de los totales
        row = {"COSTOTOTAL", "COSTOTOTAL", "COSTO TOTAL POR KILOGRAMO"}
        dgvCostos.Rows.Add(row)
        dgvCostos.Rows(dgvCostos.RowCount - 1).Cells("COMPONENTE").Style.BackColor = Color.LightGray


    End Sub

    Private Sub frmCostosReporte_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        ' ya traigo la cotizacion del dolar y la dejo lista
        sStr = "SELECT * FROM HilamarMonedas WHERE Nombre = 'Dolares'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                CotizacionDolar = Reader.Item("Cotizacion")
            End If
        End If

        estoyCargandoFormulario = True
        CargarComboFiltroHiladosConCosto()
        estoyCargandoFormulario = False
        'POR AHORA LO DESHABILITO, LUEGO VEMOS
        cmbFiltroHiladosconCosto.Enabled = False

        ' no cargo el listado de repuestos porque en el selection del procedimiento de cargar el combo dispara el evento SelectedIndexChanged del combo que ya hace la carga
        ' si no lo hacia dos veces
        'PERO AHORA PUSE UNA VARIABLE PARA QUE CUANDO ESTE CARGANDO NO HAGA EL LISTADO AL DISPARAR EL EVENTO DEL COMBO ASI SE PUEDE CARGAR BIEN TODO EL FORMULARIO
        'Y LUEGO SI SE EJECUTA CARGARLISTADO
        CargarListadodeCostosdeHilados()
    End Sub
    Private Sub CargarComboFiltroHiladosConCosto()
        cmbFiltroHiladosconCosto.Items.Clear()
        cmbFiltroHiladosconCosto.Items.Add("TODOS")
        cmbFiltroHiladosconCosto.Items.Add("CON COSTO")
        cmbFiltroHiladosconCosto.SelectedIndex = 1
    End Sub

    Private Sub cmdListar_Click(sender As System.Object, e As System.EventArgs) Handles cmdListar.Click
        CargarListadodeCostosdeHilados()
    End Sub
    Private Sub cmdSalir_Click(sender As System.Object, e As System.EventArgs) Handles cmdSalir.Click
        Close()
    End Sub

    Private Sub cmdImpPlanilla_Click(sender As System.Object, e As System.EventArgs) Handles cmdImpPlanilla.Click
        If dgvCostos.RowCount <= 0 Then Exit Sub

        pdoImpPlanilla.DefaultPageSettings.Landscape = False
        pdoImpPlanilla.DefaultPageSettings.Margins.Left = 20
        pdoImpPlanilla.DefaultPageSettings.Margins.Right = 20
        pdoImpPlanilla.DefaultPageSettings.Margins.Top = 20
        pdoImpPlanilla.DefaultPageSettings.Margins.Bottom = 20
        pdoImpPlanilla.OriginAtMargins = True ' takes margins into account 

        Dim dlgPrintPreview As New EnhancedPrintPreviewDialog
        dlgPrintPreview.ClientSize = New System.Drawing.Size(600, 600)
        dlgPrintPreview.Document = pdoImpPlanilla ' Previews print
        dlgPrintPreview.ShowDialog()

        'pdoImpPlanilla.Print()

    End Sub

    Private nRowPos As Int16
    Private NewPage As Boolean
    Private nPageNo As Int16
    Private lPageNo As String = ""

    Private ColumnaInicialdelEncabezado, ColumnaFinaldelEncabezado As Integer
    Private quedanColumnasporImprimir As Boolean

    Private Sub pdoImpPlanilla_BeginPrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles pdoImpPlanilla.BeginPrint
        nRowPos = 0
        NewPage = True
        nPageNo = 1
        ColumnaInicialdelEncabezado = 3
        ColumnaFinaldelEncabezado = 3
        quedanColumnasporImprimir = True
    End Sub

    Private Sub pdoImpPlanilla_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdoImpPlanilla.PrintPage
        On Error Resume Next

        Dim ColDgv, Columna, AnchoTabla As Integer

        Dim FuenteLineas As Font = New Drawing.Font("Arial", 10, FontStyle.Regular)
        Dim FuenteLineas7 As Font = New Drawing.Font("Arial", 7, FontStyle.Regular)
        Dim FuenteLineas8 As Font = New Drawing.Font("Arial", 8, FontStyle.Regular)
        Dim FuenteTituloEnc As Font = New Drawing.Font("Arial", 11, FontStyle.Bold)

        Dim nTop As Int16 = e.MarginBounds.Top

        'primero determino hasta que columna puedo imprimir ahora
        Columna = 21
        'sumo la primer columna de titulos de cada fila
        Columna = Columna + 150
        For ColDgv = ColumnaInicialdelEncabezado To dgvCostos.ColumnCount - 1
            Columna = Columna + 100
            If Columna > 700 Then
                ColumnaFinaldelEncabezado = ColDgv
                Exit For
            End If
        Next
        'cuando termino el for veo si salio porque no quedan mas columnas o porque lo corte porque no hay mas lugar en la hoja
        If ColDgv = dgvCostos.ColumnCount Then
            ColumnaFinaldelEncabezado = dgvCostos.ColumnCount - 1
            quedanColumnasporImprimir = False
        End If

        'primero debo saber el ancho que tendra la tabla asi puedo ir armando las lineas 
        Columna = 21
        'sumo la columna de los componentes
        Columna = Columna + 150
        nTop = nTop + 2
        For ColDgv = ColumnaInicialdelEncabezado To ColumnaFinaldelEncabezado
            Columna = Columna + 100
        Next
        AnchoTabla = Columna


        Do While nRowPos < dgvCostos.RowCount

            If nTop > e.MarginBounds.Height - e.MarginBounds.Top - 50 Then
                'EL PIE DE PAGINA
                DrawFooter(e)

                nPageNo += 1
                If quedanColumnasporImprimir Then
                    NewPage = True
                    e.HasMorePages = True
                    ColumnaInicialdelEncabezado = ColumnaFinaldelEncabezado + 1
                Else
                    NewPage = False
                    e.HasMorePages = False
                End If
                Exit Sub

            Else

                If NewPage Then

                    ' Draw Header
                    e.Graphics.DrawString("TEXTILANA DIVISION HILADOS / CALCULO DE COSTO POR HILADO", FuenteTituloEnc, Brushes.Black, 70, nTop + 3)
                    e.Graphics.DrawRectangle(Pens.Black, 40, nTop + 1, 580, 20)
                    nTop = nTop + 35

                    'LOS ENCABEZADOS DE LA TABLA
                    Columna = 21
                    e.Graphics.DrawLine(Pens.Black, 20, nTop, AnchoTabla, nTop)
                    nTop = nTop + 2
                    'la columna de los componentes
                    e.Graphics.DrawString(dgvCostos.Columns(2).HeaderText, FuenteLineas, Brushes.Black, New RectangleF(Columna, nTop, 150, 55))
                    Columna = Columna + 150
                    'el resto de las columnas
                    For ColDgv = ColumnaInicialdelEncabezado To ColumnaFinaldelEncabezado
                        e.Graphics.DrawString(dgvCostos.Columns(ColDgv).HeaderText, FuenteLineas, Brushes.Black, New RectangleF(Columna, nTop, 100, 55))
                        Columna = Columna + 100
                        'e.Graphics.DrawString("COMPRAR", FuenteLineas, Brushes.Black, 770 - e.Graphics.MeasureString("COMPRAR", FuenteLineas).Width, nTop + 3)
                    Next
                    nTop = nTop + 55
                    e.Graphics.DrawLine(Pens.Black, 20, nTop, AnchoTabla, nTop)
                    nTop = nTop + 2

                    NewPage = False


                End If

                Columna = 21
                e.Graphics.DrawString(dgvCostos.Rows(nRowPos).Cells(2).Value, FuenteLineas, Brushes.Black, New RectangleF(Columna, nTop, 150, 35))
                Columna = Columna + 150
                For ColDgv = ColumnaInicialdelEncabezado To ColumnaFinaldelEncabezado
                    'e.Graphics.DrawString(dgvCostos.Rows(nRowPos).Cells(ColDgv).Value, FuenteLineas, Brushes.Black, New RectangleF(Columna, nTop, 100, 35))
                    e.Graphics.DrawString(dgvCostos.Rows(nRowPos).Cells(ColDgv).Value, FuenteLineas, Brushes.Black, Columna + 95 - e.Graphics.MeasureString(dgvCostos.Rows(nRowPos).Cells(ColDgv).Value, FuenteLineas).Width, nTop + 10)
                    Columna = Columna + 100
                Next
                nTop = nTop + 35
                e.Graphics.DrawLine(Pens.Black, 20, nTop, AnchoTabla, nTop)
                nTop = nTop + 2

                'e.Graphics.DrawString(dgvCostos.Rows(nRowPos).Cells(1).Value, FuenteLineas8, Brushes.Black, New RectangleF(25, nTop, 219, 23))
                'e.Graphics.DrawString(dgvCostos.Rows(nRowPos).Cells(2).Value, FuenteLineas8, Brushes.Black, New RectangleF(120, nTop + 1, 260, 23))
                'e.Graphics.DrawString(dgvCostos.Rows(nRowPos).Cells(3).Value, FuenteLineas8, Brushes.Black, New RectangleF(380, nTop + 1, 120, 23))
                'e.Graphics.DrawString(dgvCostos.Rows(nRowPos).Cells(4).Value, FuenteLineas8, Brushes.Black, 590 - e.Graphics.MeasureString(dgvCostos.Rows(nRowPos).Cells(4).Value, FuenteLineas8).Width, nTop)
                'e.Graphics.DrawString(dgvCostos.Rows(nRowPos).Cells(5).Value, FuenteLineas8, Brushes.Black, 680 - e.Graphics.MeasureString(dgvCostos.Rows(nRowPos).Cells(5).Value, FuenteLineas8).Width, nTop)
                'e.Graphics.DrawString(dgvCostos.Rows(nRowPos).Cells("COMPRAR").Value, FuenteLineas8, Brushes.Black, 770 - e.Graphics.MeasureString(dgvCostos.Rows(nRowPos).Cells("COMPRAR").Value, FuenteLineas8).Width, nTop)

            End If


            nRowPos += 1
        Loop

        'cuando termino el encabezado y el detalle y el pie de pagina, ya se el largo que tendra, entonces puedo hacer las lineas verticales, para que queden hasta el fin de los datos justito
        Columna = 20
        e.Graphics.DrawLine(Pens.Black, Columna, 57, Columna, nTop - 2)
        Columna = Columna + 150
        For ColDgv = ColumnaInicialdelEncabezado To ColumnaFinaldelEncabezado
            e.Graphics.DrawLine(Pens.Black, Columna, 57, Columna, nTop - 2)
            Columna = Columna + 100
        Next
        'al final la linea que cierra la tabla
        e.Graphics.DrawLine(Pens.Black, Columna + 1, 57, Columna + 1, nTop - 2)

        'LUEGO EL PIE DE PAGINA
        DrawFooter(e)


        If quedanColumnasporImprimir Then
            nPageNo += 1
            NewPage = True
            e.HasMorePages = True
            ColumnaInicialdelEncabezado = ColumnaFinaldelEncabezado + 1
            nRowPos = 0
        End If


    End Sub

    Public Sub DrawFooter(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim FuenteLineas8 As Font = New Drawing.Font("Arial", 8, FontStyle.Regular)

        Dim sPageNo As String = nPageNo.ToString + " de "

        If nPageNo = "1" Then
            lPageNo = CalculoCantidaddeHojas().ToString
            sPageNo = nPageNo.ToString + " de " + lPageNo
        Else
            sPageNo = nPageNo.ToString + " de " + lPageNo
        End If

        e.Graphics.DrawLine(Pens.Black, 20, e.MarginBounds.Height - 17, 790, e.MarginBounds.Height - 17)

        ' Right Align - User Name
        e.Graphics.DrawString(Format(Now, "dd/MM/yyyy HH:mm:ss"), FuenteLineas8, Brushes.Black, 660, e.MarginBounds.Height - 15)

        ' Center - Page No. Info
        e.Graphics.DrawString(sPageNo, FuenteLineas8, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(sPageNo, FuenteLineas8, e.MarginBounds.Width).Width) / 2, e.MarginBounds.Height - 15)

        e.Graphics.DrawLine(Pens.Black, 20, e.MarginBounds.Height, 790, e.MarginBounds.Height)

    End Sub

    Private Function CalculoCantidaddeHojas() As Int16
        Dim NroPag As Int16
        Dim FilaPos As Int16 = 0
        Dim OtraPagina As Boolean = True

        Dim nTop As Int16 = 20

        'primero calculo cuantas hojas necesito para imprimir todos los hilados hacia el costado
        'primero determino hasta que columna puedo imprimir ahora
        Dim Columna, CantPagPorLinea As Integer
        Dim ColPos As Int16 = 0
        CantPagPorLinea = 1

        Columna = 21
        Columna = Columna + 150
        For ColPos = 3 To dgvCostos.ColumnCount - 1
            Columna = Columna + 100
            If Columna > 700 Then
                CantPagPorLinea += 1
                Columna = 21
                Columna = Columna + 150
            End If
        Next
        'cuando termino el for en CantPagPorLinea me va a quedar el numero de paginas por cada fila, asi uqe cuando hago el bucle de abajo
        'no debo ir sumando de a una pagina sino de a CantPagPorLinea

        NroPag = CantPagPorLinea
        Do While FilaPos < dgvCostos.RowCount

            If nTop > 1050 Then
                nTop = 20
                NroPag += CantPagPorLinea
                OtraPagina = True
            Else

                If OtraPagina Then

                    nTop = nTop + 35

                    'LOS ENCABEZADOS DE LA TABLA
                    nTop = nTop + 2
                    nTop = nTop + 55
                    nTop = nTop + 2

                    OtraPagina = False

                End If

                'las filas del dgv
                nTop = nTop + 35
                nTop = nTop + 2

            End If

            FilaPos += 1
        Loop

        Return NroPag
    End Function

    Private Sub cmdExcel_Click(sender As System.Object, e As System.EventArgs) Handles cmdExcel.Click
        If dgvCostos.RowCount > 0 Then
            ExportaraExcel()
        End If
    End Sub
    Private Sub ExportaraExcel()
        On Error GoTo ErrExportaraExcel
        Dim NombreArchivoExcel As String
        Dim oExcel As New Excel.Application()
        Dim oSheet As Excel.Worksheet
        Dim XLProc As Process
        Dim xlHWND As Integer = oExcel.Hwnd
        Dim ProcIDXL As Integer = 0

        Dim i As Integer
        Dim Fila, Columna As Integer

        'get the process ID
        GetWindowThreadProcessId(xlHWND, ProcIDXL)
        XLProc = Process.GetProcessById(ProcIDXL)

        oExcel.Workbooks.Add()
        oSheet = oExcel.ActiveSheet
        Fila = 1
        Columna = 1
        oSheet.Cells(Fila, Columna).value = "TEXTILANA DIVISION HILADOS / CALCULO DE COSTO POR HILADO"

        Fila = 3
        Columna = 1
        For ColDgv = 2 To dgvCostos.ColumnCount - 1
            oSheet.Cells(Fila, Columna).value = dgvCostos.Columns(ColDgv).HeaderText
            If ColDgv = 2 Then
                oSheet.Cells(Fila, Columna).ColumnWidth = 33
            Else
                oSheet.Cells(Fila, Columna).ColumnWidth = 23
                oSheet.Columns(Columna).NumberFormat = "@"
            End If
            oSheet.Cells(Fila, Columna).Interior.ColorIndex = 6
            Columna = Columna + 1
        Next

        'le pongo colorcito al los titulos, pero en vez de hacerlo columna por columna, lo hago con el rango
        'oSheet.Range("A5", "H5").Interior.ColorIndex = 6

        For i = 0 To dgvCostos.RowCount - 1
            Columna = 1
            Fila = Fila + 1
            For ColDgv = 2 To dgvCostos.ColumnCount - 1
                If ColDgv = 2 Then
                    oSheet.Cells(Fila, Columna).value = dgvCostos.Rows(i).Cells(ColDgv).Value.ToString
                    oSheet.Cells(Fila, Columna).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                Else
                    If dgvCostos.Rows(i).Cells(ColDgv).Value.ToString = "NO" Then
                        oSheet.Cells(Fila, Columna).value = dgvCostos.Rows(i).Cells(ColDgv).Value.ToString
                        oSheet.Cells(Fila, Columna).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                    Else
                        oSheet.Cells(Fila, Columna).value = CDbl(dgvCostos.Rows(i).Cells(ColDgv).Value)
                        oSheet.Cells(Fila, Columna).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                    End If
                End If
                Columna = Columna + 1
            Next
        Next i

        'Columna = 2
        'For ColDgv = 3 To dgvCostos.ColumnCount - 1
        '    oSheet.Columns(Columna).NumberFormat = "@"
        '    Columna = Columna + 1
        'Next


        'al final cuando ya estan llenas las columnas con datos le arreglo la alineacion, si lo hacia antes solo alineaba los encabezados
        'que eran lo que estaba cargados hasta que cargaba los datos
        'oSheet.Range("D:D").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
        'oSheet.Range("E:E").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
        'oSheet.Range("F:F").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
        'oSheet.Range("G:G").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight


        'Si no existe el directorio, lo creo
        If Not Directory.Exists(Application.StartupPath + "\Excel") Then Directory.CreateDirectory(Application.StartupPath + "\Excel")
        'Guardo el archivo 
        NombreArchivoExcel = Application.StartupPath + "\Excel\" + "HiladosCostos_" + Format(Now, "dd-MM-yyyy HH-mm-ss") + ".xls"
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
ErrExportaraExcel:
        MensajeAtencion("Error al generar a Excel de Costos")
        NAR(XLProc) 'Release

    End Sub

    Private Sub cmbFiltroOrdenActiva_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFiltroHiladosconCosto.SelectedIndexChanged
        If Not estoyCargandoFormulario Then
            CargarListadodeCostosdeHilados()
        End If
    End Sub


    '##################################### FUNCIONES #######################################################################
    '#######################################################################################################################
    Private Function ObtengoDescripcionDelElemento(ByVal Tipo As String, ByVal IdComp As String) As String
        Dim CommandAux As New SqlCommand
        Dim ReaderAux As SqlDataReader
        Dim sStrAux As String

        Dim Retorno As String = ""
        If Tipo = "MP" Then
            sStrAux = "SELECT * FROM HilamarMateriasPrimas WHERE Id = " + IdComp + ""
            CommandAux = New SqlCommand(sStrAux, cConexionApp.SQLConn)
            ReaderAux = CommandAux.ExecuteReader()
            If ReaderAux.HasRows Then
                If ReaderAux.Read Then
                    Retorno = ReaderAux.Item("Descripcion")
                End If
            End If
        ElseIf Tipo = "PG" Then
            If IdComp = "HH" Then
                Retorno = "Horas Hombre"
            ElseIf IdComp = "GAS" Then
                Retorno = "GAS"
            ElseIf IdComp = "LUZ" Then
                Retorno = "LUZ"
            ElseIf IdComp = "OS" Then
                Retorno = "OBRAS SANITARIAS"
            End If
        ElseIf Tipo = "PR" Then
            sStrAux = "SELECT * FROM HilamarProcesos WHERE Id = " + IdComp + ""
            CommandAux = New SqlCommand(sStrAux, cConexionApp.SQLConn)
            ReaderAux = CommandAux.ExecuteReader()
            If ReaderAux.HasRows Then
                If ReaderAux.Read Then
                    Retorno = ReaderAux.Item("Descripcion")
                End If
            End If
        ElseIf Tipo = "HI" Then
            sStrAux = "SELECT * FROM HilamarHilados WHERE Id = " + IdComp + ""
            CommandAux = New SqlCommand(sStrAux, cConexionApp.SQLConn)
            ReaderAux = CommandAux.ExecuteReader()
            If ReaderAux.HasRows Then
                If ReaderAux.Read Then
                    Retorno = ReaderAux.Item("Descripcion")
                End If
            End If
        ElseIf Tipo = "IN" Then
            sStrAux = "SELECT * FROM HilamarHiladosInternos WHERE Id = " + IdComp + ""
            CommandAux = New SqlCommand(sStrAux, cConexionApp.SQLConn)
            ReaderAux = CommandAux.ExecuteReader()
            If ReaderAux.HasRows Then
                If ReaderAux.Read Then
                    Retorno = ReaderAux.Item("Descripcion")
                End If
            End If
        End If
        ObtengoDescripcionDelElemento = Retorno
    End Function

    Private Function ObtenerComposiciondeCostos(ByVal TipoElemento As String, ByVal IdElemento As String) As Double
        Dim CommandCos As New SqlCommand
        Dim ReaderCos As SqlDataReader
        Dim sStrCos As String

        Dim Descripcion As String = ""
        Dim Precio, Costo, CostoTotal As Double

        CostoTotal = 0.0

        'Si es Hilado Interno debo ver si lleva composicion de costos o es costo fijo y de acuerdo a eso hago o no el bucle
        If TipoElemento = "HILADO INTERNO" Then
            sStrCos = "select * from HilamarHiladosInternos where Id = " + IdElemento
            CommandCos = New SqlCommand(sStrCos, cConexionApp.SQLConn)
            ReaderCos = CommandCos.ExecuteReader()
            If ReaderCos.HasRows Then
                If ReaderCos.Read Then
                    If Not IsDBNull(ReaderCos.Item("Moneda")) Or Not IsDBNull(ReaderCos.Item("CostoPorKilo")) Then

                        If ReaderCos.Item("Moneda").ToString = "Dolares" Then
                            Precio = CotizacionDolar * ReaderCos.Item("CostoPorKilo")
                        Else
                            Precio = ReaderCos.Item("CostoPorKilo")
                        End If

                        Costo = 1 * Precio

                        CostoTotal = CostoTotal + Costo

                    End If
                End If
            End If

        End If

        If TipoElemento = "HILADO" Then
            sStrCos = "select * from HilamarCompCostosHilados where IdHil = " + IdElemento + " AND isnull(EsInterno,0)=0"
        ElseIf TipoElemento = "HILADO INTERNO" Then
            sStrCos = "select * from HilamarCompCostosHilados where IdHil = " + IdElemento + " AND isnull(EsInterno,0)=1"
        Else
            sStrCos = "select * from HilamarCompCostosProcesos where IdProc = " + IdElemento
        End If
        CommandCos = New SqlCommand(sStrCos, cConexionApp.SQLConn)
        ReaderCos = CommandCos.ExecuteReader()
        Do While ReaderCos.HasRows
            Do While ReaderCos.Read()

                Precio = ObtengoCostoDelElemento(ReaderCos.Item("Tipo").ToString, ReaderCos.Item("IdComp").ToString)
                Costo = ReaderCos.Item("Factor") * Precio

                If ReaderCos.Item("IdComp").ToString = "OS" Then
                    Costo = Costo / 1000
                End If

                CostoTotal = CostoTotal + Costo
            Loop
            ReaderCos.NextResult()
        Loop

        ObtenerComposiciondeCostos = CostoTotal

    End Function

    Private Function ObtengoCostoDelElemento(ByVal Tipo As String, ByVal IdComp As String) As Double
        Dim CommandAux As New SqlCommand
        Dim ReaderAux As SqlDataReader
        Dim sStrAux As String

        Dim Retorno As Double = 0.0

        If Tipo = "MP" Then
            sStrAux = "SELECT * FROM HilamarMateriasPrimas WHERE Id = " + IdComp + ""
            CommandAux = New SqlCommand(sStrAux, cConexionApp.SQLConn)
            ReaderAux = CommandAux.ExecuteReader()
            If ReaderAux.HasRows Then
                If ReaderAux.Read Then
                    If ReaderAux.Item("Moneda").ToString = "Dolares" Then
                        Retorno = CotizacionDolar * ReaderAux.Item("CostoPorKilo")
                    Else
                        Retorno = ReaderAux.Item("CostoPorKilo")
                    End If
                End If
            End If
        ElseIf Tipo = "PG" Then
            If IdComp = "HH" Then
                sStrAux = "SELECT * FROM HilamarCostosParametrosGrales "
                CommandAux = New SqlCommand(sStrAux, cConexionApp.SQLConn)
                ReaderAux = CommandAux.ExecuteReader()
                If ReaderAux.HasRows Then
                    If ReaderAux.Read Then
                        Retorno = ReaderAux.Item("CostoHoraHombre") * ReaderAux.Item("FactorMultiplicadordelValorHoraHombre")
                    End If
                End If
            ElseIf IdComp = "GAS" Then
                sStrAux = "SELECT * FROM HilamarCostosParametrosGrales "
                CommandAux = New SqlCommand(sStrAux, cConexionApp.SQLConn)
                ReaderAux = CommandAux.ExecuteReader()
                If ReaderAux.HasRows Then
                    If ReaderAux.Read Then
                        Retorno = (ReaderAux.Item("TotalCamuzzi") + ReaderAux.Item("TotalEnergy")) / ReaderAux.Item("M3GasConsumidos")
                    End If
                End If
            ElseIf IdComp = "LUZ" Then
                sStrAux = "SELECT * FROM HilamarCostosParametrosGrales "
                CommandAux = New SqlCommand(sStrAux, cConexionApp.SQLConn)
                ReaderAux = CommandAux.ExecuteReader()
                If ReaderAux.HasRows Then
                    If ReaderAux.Read Then
                        Retorno = ReaderAux.Item("TotalEdea") / ReaderAux.Item("KWConsumidos")
                    End If
                End If
            ElseIf IdComp = "OS" Then
                sStrAux = "SELECT * FROM HilamarCostosParametrosGrales "
                CommandAux = New SqlCommand(sStrAux, cConexionApp.SQLConn)
                ReaderAux = CommandAux.ExecuteReader()
                If ReaderAux.HasRows Then
                    If ReaderAux.Read Then
                        Retorno = ReaderAux.Item("TotalObrasSanitarias") / ReaderAux.Item("M3AguaConsumidos")
                    End If
                End If
            End If
        ElseIf Tipo = "PR" Then

            Retorno = ObtenerComposiciondeCostos("PROCESO", IdComp)

        ElseIf Tipo = "HI" Then

            Retorno = ObtenerComposiciondeCostos("HILADO", IdComp)

        ElseIf Tipo = "IN" Then

            Retorno = ObtenerComposiciondeCostos("HILADO INTERNO", IdComp)

        End If
        ObtengoCostoDelElemento = Retorno
    End Function

End Class