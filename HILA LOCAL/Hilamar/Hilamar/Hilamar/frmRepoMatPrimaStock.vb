Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Data.OleDb

Public Class frmRepoMatPrimaStock

    Dim LegajoLogueado As String 'legajo de quien va a trabajar
    Dim TipoUsuario As String ' Tipo de usuario que va a trabajar, lo voy a usar para saber que le habilito a usar y que no

    Sub New(ByVal parametro1 As String, ByVal parametro2 As String)

        InitializeComponent() 'es necesario que lleve esta linea

        LegajoLogueado = parametro1
        TipoUsuario = parametro2

    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVolver.Click
        Close()
    End Sub

    Private Sub cmdExcel_Click(sender As Object, e As EventArgs) Handles cmdExcel.Click
        'If CopiarDatosMateriaPrimaUnix() Then
        '    ExportaraExcel()
        'End If
        ExportaraExcel()
    End Sub

    Private Sub ExportaraExcel()
        'On Error GoTo ErrGenerarExcelHilados
        Dim NombreArchivoExcel As String
        Dim oExcel As New Excel.Application()
        Dim oSheet As Excel.Worksheet
        Dim XLProc As Process
        Dim xlHWND As Integer = oExcel.Hwnd
        Dim ProcIDXL As Integer = 0

        Dim sstr As String
        Dim DBFCommandH As OleDbCommand
        Dim DBFDataReaderH As OleDbDataReader

        Dim Fila, Columna As Integer
        Dim Acum1, Acum2, Acum3 As Double


        'get the process ID
        GetWindowThreadProcessId(xlHWND, ProcIDXL)
        XLProc = Process.GetProcessById(ProcIDXL)

        oExcel.Workbooks.Add()
        oSheet = oExcel.ActiveSheet
        Fila = 1
        Columna = 1
        oSheet.Cells(Fila, Columna).value = "TEXTILANA S. A."
        Fila = 2
        oSheet.Cells(Fila, Columna).value = "EXISTENCIAS DE MATERIA PRIMA AL " + Format(Now, "dd/MM/yyyy")
        'DEJO UN RENGLON
        Fila = Fila + 1

        'creo conexion para leer dbf
        Dim ConnStringH As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\bases" + " ;Extended Properties=dBASE IV;User ID=Admin;Password="
        Dim DBFConnH As New OleDbConnection(ConnStringH)
        DBFConnH.Open()

        '*******************************LANA SUCIA***************************************
        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "LANA SUCIA"
        oSheet.Range("A" + CStr(Fila), "B" + CStr(Fila)).Interior.ColorIndex = 20

        Fila = Fila + 1
        Columna = 1
        oSheet.Cells(Fila, Columna).value = "NºORD.FABRICACION"
        oSheet.Cells(Fila, Columna).ColumnWidth = 15
        Columna = 2
        oSheet.Cells(Fila, Columna).value = "LIENZOS"
        oSheet.Cells(Fila, Columna).ColumnWidth = 13
        Columna = 3
        oSheet.Cells(Fila, Columna).value = "FAC"
        oSheet.Cells(Fila, Columna).ColumnWidth = 15
        Columna = 4
        oSheet.Cells(Fila, Columna).value = "KILOS"
        oSheet.Cells(Fila, Columna).ColumnWidth = 16

        oSheet.Range("A" + CStr(Fila), "H" + CStr(Fila)).Interior.ColorIndex = 20

        Acum1 = 0
        sstr = "SELECT * FROM BARLAV"
        DBFCommandH = New OleDbCommand(sstr, DBFConnH)
        DBFDataReaderH = DBFCommandH.ExecuteReader(CommandBehavior.Default)
        Do While DBFDataReaderH.Read
            If DBFDataReaderH("THCAN").ToString <> "0" Then
                Fila = Fila + 1

                oSheet.Cells(Fila, 1).value = DBFDataReaderH("THORD").ToString
                oSheet.Cells(Fila, 2).value = DBFDataReaderH("THCAN").ToString
                oSheet.Cells(Fila, 3).value = DBFDataReaderH("thkil") / DBFDataReaderH("thcan")
                oSheet.Cells(Fila, 4).value = DBFDataReaderH("thkil").ToString
                Acum1 = Acum1 + CDbl(DBFDataReaderH("THCAN").ToString)
            End If
        Loop

        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "***TOTAL DE LIENZOS EN STOCK "
        oSheet.Cells(Fila, 3).value = Acum1
        '*******************************TOPS HILANDERIA***************************************
        Fila = Fila + 1
        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "TOPS HILANDERIA"
        oSheet.Range("A" + CStr(Fila), "B" + CStr(Fila)).Interior.ColorIndex = 20

        Fila = Fila + 1
        Columna = 1
        oSheet.Cells(Fila, Columna).value = "NºORD.PEINADURIA"
        oSheet.Cells(Fila, Columna).ColumnWidth = 18
        Columna = 2
        oSheet.Cells(Fila, Columna).value = "TOPS"
        oSheet.Cells(Fila, Columna).ColumnWidth = 13
        Columna = 3
        oSheet.Cells(Fila, Columna).value = "COLOR"
        oSheet.Cells(Fila, Columna).ColumnWidth = 20
        Columna = 4
        oSheet.Cells(Fila, Columna).value = "KILOS"
        oSheet.Cells(Fila, Columna).ColumnWidth = 16

        oSheet.Range("A" + CStr(Fila), "H" + CStr(Fila)).Interior.ColorIndex = 20

        Acum1 = 0
        Acum2 = 0
        sstr = "SELECT * FROM THILAN ORDER BY THORD"
        DBFCommandH = New OleDbCommand(sstr, DBFConnH)
        DBFDataReaderH = DBFCommandH.ExecuteReader(CommandBehavior.Default)
        Do While DBFDataReaderH.Read
            If DBFDataReaderH("THCAN").ToString <> "0" Then
                Fila = Fila + 1

                oSheet.Cells(Fila, 1).value = DBFDataReaderH("THORD").ToString
                oSheet.Cells(Fila, 2).value = DBFDataReaderH("THCAN").ToString
                oSheet.Cells(Fila, 3).value = DBFDataReaderH("THOR3").ToString
                oSheet.Cells(Fila, 4).value = DBFDataReaderH("THKIL").ToString
                Acum1 = Acum1 + CDbl(DBFDataReaderH("THCAN").ToString)
                Acum2 = Acum2 + CDbl(DBFDataReaderH("THKIL").ToString)
            End If
        Loop

        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "***TOTAL DE TOPS PARA HILANDERIA EN STOCK"
        oSheet.Cells(Fila, 4).value = Acum1
        oSheet.Cells(Fila, 5).value = Acum2
        '*******************************TOPS PARA TINTORERIA***************************************
        Fila = Fila + 1
        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "TOPS PARA TINTORERIA"
        oSheet.Range("A" + CStr(Fila), "B" + CStr(Fila)).Interior.ColorIndex = 20

        Fila = Fila + 1
        Columna = 1
        oSheet.Cells(Fila, Columna).value = "NºORD.PEINADURIA"
        oSheet.Cells(Fila, Columna).ColumnWidth = 18
        Columna = 2
        oSheet.Cells(Fila, Columna).value = "TOPS"
        oSheet.Cells(Fila, Columna).ColumnWidth = 13
        Columna = 3
        oSheet.Cells(Fila, Columna).value = "COLOR"
        oSheet.Cells(Fila, Columna).ColumnWidth = 20
        Columna = 4
        oSheet.Cells(Fila, Columna).value = "KILOS"
        oSheet.Cells(Fila, Columna).ColumnWidth = 16

        oSheet.Range("A" + CStr(Fila), "H" + CStr(Fila)).Interior.ColorIndex = 20

        Acum1 = 0
        Acum2 = 0
        sstr = "SELECT * FROM TTINTO ORDER BY TTORD"
        DBFCommandH = New OleDbCommand(sstr, DBFConnH)
        DBFDataReaderH = DBFCommandH.ExecuteReader(CommandBehavior.Default)
        Do While DBFDataReaderH.Read
            If DBFDataReaderH("TTCAN").ToString <> "0" Then
                Fila = Fila + 1

                oSheet.Cells(Fila, 1).value = DBFDataReaderH("TTORD").ToString
                oSheet.Cells(Fila, 2).value = DBFDataReaderH("TTCAN").ToString
                oSheet.Cells(Fila, 3).value = DBFDataReaderH("TTOR3").ToString
                oSheet.Cells(Fila, 4).value = DBFDataReaderH("TTKIL").ToString
                Acum1 = Acum1 + CDbl(DBFDataReaderH("TTCAN").ToString)
                Acum2 = Acum2 + CDbl(DBFDataReaderH("TTKIL").ToString)
            End If
        Loop

        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "***TOTAL DE TOPS PARA TINTORERIA EN STOCK"
        oSheet.Cells(Fila, 4).value = Acum1
        oSheet.Cells(Fila, 5).value = Acum2
        '*******************************TOPS MERINO HILANDERIA***************************************
        Fila = Fila + 1
        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "TOPS MERINO HILANDERIA"
        oSheet.Range("A" + CStr(Fila), "B" + CStr(Fila)).Interior.ColorIndex = 20

        Fila = Fila + 1
        Columna = 1
        oSheet.Cells(Fila, Columna).value = "NºORD.PEINADURIA"
        oSheet.Cells(Fila, Columna).ColumnWidth = 18
        Columna = 2
        oSheet.Cells(Fila, Columna).value = "TOPS"
        oSheet.Cells(Fila, Columna).ColumnWidth = 13
        Columna = 3
        oSheet.Cells(Fila, Columna).value = "COLOR"
        oSheet.Cells(Fila, Columna).ColumnWidth = 20
        Columna = 4
        oSheet.Cells(Fila, Columna).value = "KILOS"
        oSheet.Cells(Fila, Columna).ColumnWidth = 16

        oSheet.Range("A" + CStr(Fila), "H" + CStr(Fila)).Interior.ColorIndex = 20

        Acum1 = 0
        Acum2 = 0
        sstr = "SELECT * FROM TOPCAR ORDER BY THORD"
        DBFCommandH = New OleDbCommand(sstr, DBFConnH)
        DBFDataReaderH = DBFCommandH.ExecuteReader(CommandBehavior.Default)
        Do While DBFDataReaderH.Read
            If DBFDataReaderH("THCAN").ToString <> "0" Then
                Fila = Fila + 1

                oSheet.Cells(Fila, 1).value = DBFDataReaderH("THORD").ToString
                oSheet.Cells(Fila, 2).value = DBFDataReaderH("THCAN").ToString
                oSheet.Cells(Fila, 3).value = DBFDataReaderH("THOR3").ToString
                oSheet.Cells(Fila, 4).value = DBFDataReaderH("THKIL").ToString
                Acum1 = Acum1 + CDbl(DBFDataReaderH("THCAN").ToString)
                Acum2 = Acum2 + CDbl(DBFDataReaderH("THKIL").ToString)
            End If
        Loop

        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "***TOTAL DE TOPS MERINO HILANDERIA EN STOCK"
        oSheet.Cells(Fila, 4).value = Acum1
        oSheet.Cells(Fila, 5).value = Acum2
        '*******************************TOPS MERINO TINTORERIA***************************************
        Fila = Fila + 1
        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "TOPS MERINO TINTORERIA"
        oSheet.Range("A" + CStr(Fila), "B" + CStr(Fila)).Interior.ColorIndex = 20

        Fila = Fila + 1
        Columna = 1
        oSheet.Cells(Fila, Columna).value = "NºORD.PEINADURIA"
        oSheet.Cells(Fila, Columna).ColumnWidth = 18
        Columna = 2
        oSheet.Cells(Fila, Columna).value = "TOPS"
        oSheet.Cells(Fila, Columna).ColumnWidth = 13
        Columna = 3
        oSheet.Cells(Fila, Columna).value = "COLOR"
        oSheet.Cells(Fila, Columna).ColumnWidth = 20
        Columna = 4
        oSheet.Cells(Fila, Columna).value = "KILOS"
        oSheet.Cells(Fila, Columna).ColumnWidth = 16

        oSheet.Range("A" + CStr(Fila), "H" + CStr(Fila)).Interior.ColorIndex = 20

        Acum1 = 0
        Acum2 = 0
        sstr = "SELECT * FROM TOPCAR1 ORDER BY THORD"
        DBFCommandH = New OleDbCommand(sstr, DBFConnH)
        DBFDataReaderH = DBFCommandH.ExecuteReader(CommandBehavior.Default)
        Do While DBFDataReaderH.Read
            If DBFDataReaderH("THCAN").ToString <> "0" Then
                Fila = Fila + 1

                oSheet.Cells(Fila, 1).value = DBFDataReaderH("THORD").ToString
                oSheet.Cells(Fila, 2).value = DBFDataReaderH("THCAN").ToString
                oSheet.Cells(Fila, 3).value = DBFDataReaderH("THOR3").ToString
                oSheet.Cells(Fila, 4).value = DBFDataReaderH("THKIL").ToString
                Acum1 = Acum1 + CDbl(DBFDataReaderH("THCAN").ToString)
                Acum2 = Acum2 + CDbl(DBFDataReaderH("THKIL").ToString)
            End If
        Loop

        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "***TOTAL DE TOPS MERINO TINTORERIA EN STOCK"
        oSheet.Cells(Fila, 4).value = Acum1
        oSheet.Cells(Fila, 5).value = Acum2
        '*******************************TOPS / BOBINAS TEÑIDOS***************************************
        Fila = Fila + 1
        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "TOPS/BOBINAS TEÑIDOS"
        oSheet.Range("A" + CStr(Fila), "B" + CStr(Fila)).Interior.ColorIndex = 20

        Fila = Fila + 1
        Columna = 1
        oSheet.Cells(Fila, Columna).value = "O.TINT."
        oSheet.Cells(Fila, Columna).ColumnWidth = 18
        Columna = 2
        oSheet.Cells(Fila, Columna).value = "NºCOL."
        oSheet.Cells(Fila, Columna).ColumnWidth = 13
        Columna = 3
        oSheet.Cells(Fila, Columna).value = "COLOR"
        oSheet.Cells(Fila, Columna).ColumnWidth = 15
        Columna = 4
        oSheet.Cells(Fila, Columna).value = "TOPS"
        oSheet.Cells(Fila, Columna).ColumnWidth = 15
        Columna = 5
        oSheet.Cells(Fila, Columna).value = "FECHA"
        oSheet.Cells(Fila, Columna).ColumnWidth = 16
        Columna = 6
        oSheet.Cells(Fila, Columna).value = "KILOS"
        oSheet.Cells(Fila, Columna).ColumnWidth = 18

        oSheet.Range("A" + CStr(Fila), "H" + CStr(Fila)).Interior.ColorIndex = 20

        Acum1 = 0
        Acum2 = 0
        sstr = "SELECT * FROM TBTENI ORDER BY TBORD"
        DBFCommandH = New OleDbCommand(sstr, DBFConnH)
        DBFDataReaderH = DBFCommandH.ExecuteReader(CommandBehavior.Default)
        Do While DBFDataReaderH.Read
            If DBFDataReaderH("TBKIL").ToString <> "0" Then
                Fila = Fila + 1

                oSheet.Cells(Fila, 1).value = DBFDataReaderH("TBORD").ToString
                oSheet.Cells(Fila, 2).value = DBFDataReaderH("TBNRO").ToString
                oSheet.Cells(Fila, 3).value = DBFDataReaderH("TBCOL").ToString
                oSheet.Cells(Fila, 4).value = DBFDataReaderH("TBCAN").ToString
                oSheet.Cells(Fila, 5).value = DBFDataReaderH("TBFEC").ToString
                oSheet.Cells(Fila, 6).value = Format(CDbl(DBFDataReaderH("TBKIL")), "#,##0.000")
                Acum1 = Acum1 + CDbl(DBFDataReaderH("TBCAN").ToString)
                Acum2 = Acum2 + CDbl(DBFDataReaderH("TBKIL").ToString)
            End If
        Loop

        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "***TOTAL DE TOPS/BOBINAS EN STOCK"
        oSheet.Cells(Fila, 4).value = Format(CDbl(Acum1), "#,##0.000")
        oSheet.Cells(Fila, 5).value = Format(CDbl(Acum2), "#,##0.000")
        '************************************ACRILICO*********************************************
        Fila = Fila + 1
        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "ACRILICO"
        oSheet.Range("A" + CStr(Fila), "B" + CStr(Fila)).Interior.ColorIndex = 20

        Fila = Fila + 1
        Columna = 1
        oSheet.Cells(Fila, Columna).value = "NºLOTE"
        oSheet.Cells(Fila, Columna).ColumnWidth = 18
        Columna = 2
        oSheet.Cells(Fila, Columna).value = "NºCOL."
        oSheet.Cells(Fila, Columna).ColumnWidth = 13
        Columna = 3
        oSheet.Cells(Fila, Columna).value = "COLOR"
        oSheet.Cells(Fila, Columna).ColumnWidth = 15
        Columna = 4
        oSheet.Cells(Fila, Columna).value = "TIPO"
        oSheet.Cells(Fila, Columna).ColumnWidth = 15
        Columna = 5
        oSheet.Cells(Fila, Columna).value = "DENIER"
        oSheet.Cells(Fila, Columna).ColumnWidth = 16
        Columna = 6
        oSheet.Cells(Fila, Columna).value = "KILOS"
        oSheet.Cells(Fila, Columna).ColumnWidth = 18
        Columna = 7
        oSheet.Cells(Fila, Columna).value = "FARDO"
        oSheet.Cells(Fila, Columna).ColumnWidth = 15
        Columna = 8
        oSheet.Cells(Fila, Columna).value = "PROVEEDOR"
        oSheet.Cells(Fila, Columna).ColumnWidth = 18

        oSheet.Range("A" + CStr(Fila), "H" + CStr(Fila)).Interior.ColorIndex = 20

        Acum1 = 0
        sstr = "SELECT * FROM ACRILICO ORDER BY ALOTE"
        DBFCommandH = New OleDbCommand(sstr, DBFConnH)
        DBFDataReaderH = DBFCommandH.ExecuteReader(CommandBehavior.Default)
        Do While DBFDataReaderH.Read
            If DBFDataReaderH("AKILOS").ToString <> "0" Then
                Fila = Fila + 1

                oSheet.Cells(Fila, 1).value = CompletarCaracteresIzquierda(DBFDataReaderH("ALOTE").ToString, 6, "0")
                oSheet.Cells(Fila, 2).value = DBFDataReaderH("ANROCOL").ToString
                oSheet.Cells(Fila, 3).value = DBFDataReaderH("ACOLOR").ToString
                oSheet.Cells(Fila, 4).value = DBFDataReaderH("ATIPO").ToString
                oSheet.Cells(Fila, 5).value = DBFDataReaderH("ADENIER").ToString
                oSheet.Cells(Fila, 6).value = Format(CDbl(DBFDataReaderH("AKILOS")), "#,##0.000")
                oSheet.Cells(Fila, 7).value = DBFDataReaderH("AFARDO").ToString
                oSheet.Cells(Fila, 8).value = DBFDataReaderH("APROVE").ToString
                Acum1 = Acum1 + CDbl(DBFDataReaderH("AKILOS").ToString)
            End If
        Loop

        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "***TOTAL DE KILOS DE ACRILICO EN STOCK"
        oSheet.Cells(Fila, 4).value = Format(CDbl(Acum1), "#,##0.000")
        '************************************ALGODON 24/1*********************************************
        Fila = Fila + 1
        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "ALGODON 24/1"
        oSheet.Range("A" + CStr(Fila), "B" + CStr(Fila)).Interior.ColorIndex = 20

        Fila = Fila + 1
        Columna = 1
        oSheet.Cells(Fila, Columna).value = "NºLOTE"
        oSheet.Cells(Fila, Columna).ColumnWidth = 18
        Columna = 2
        oSheet.Cells(Fila, Columna).value = "COLOR"
        oSheet.Cells(Fila, Columna).ColumnWidth = 13
        Columna = 3
        oSheet.Cells(Fila, Columna).value = "KILOS"
        oSheet.Cells(Fila, Columna).ColumnWidth = 15
        Columna = 4
        oSheet.Cells(Fila, Columna).value = "CAJAS"
        oSheet.Cells(Fila, Columna).ColumnWidth = 15
        Columna = 5
        oSheet.Cells(Fila, Columna).value = "CONOS"
        oSheet.Cells(Fila, Columna).ColumnWidth = 16
        Columna = 6
        oSheet.Cells(Fila, Columna).value = "PROVEEDOR"
        oSheet.Cells(Fila, Columna).ColumnWidth = 18

        oSheet.Range("A" + CStr(Fila), "H" + CStr(Fila)).Interior.ColorIndex = 20

        Acum1 = 0
        Acum2 = 0
        Acum3 = 0
        sstr = "SELECT * FROM ALGODON ORDER BY ALLOTE"
        DBFCommandH = New OleDbCommand(sstr, DBFConnH)
        DBFDataReaderH = DBFCommandH.ExecuteReader(CommandBehavior.Default)
        Do While DBFDataReaderH.Read
            If DBFDataReaderH("ALKILO").ToString <> "0" Then
                Fila = Fila + 1

                oSheet.Cells(Fila, 1).value = DBFDataReaderH("ALLOTE").ToString
                oSheet.Cells(Fila, 2).value = DBFDataReaderH("ALCOLO").ToString
                oSheet.Cells(Fila, 3).value = Format(CDbl(DBFDataReaderH("ALKILO")), "#,##0.000")
                oSheet.Cells(Fila, 4).value = Format(CDbl(DBFDataReaderH("ALCAJA")), "#,##0")
                oSheet.Cells(Fila, 5).value = Format(CDbl(DBFDataReaderH("ALCONO")), "#,##0")
                oSheet.Cells(Fila, 6).value = DBFDataReaderH("ALPROV").ToString
                Acum1 = Acum1 + CDbl(DBFDataReaderH("ALKILO").ToString)
                Acum2 = Acum2 + CDbl(DBFDataReaderH("ALCAJA").ToString)
                Acum3 = Acum3 + CDbl(DBFDataReaderH("ALCONO").ToString)
            End If
        Loop

        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "***TOTAL KILOS DE ALGODON 24/1"
        oSheet.Cells(Fila, 3).value = Format(CDbl(Acum1), "#,##0.000")
        oSheet.Cells(Fila, 4).value = Format(CDbl(Acum2), "#,##0")
        oSheet.Cells(Fila, 5).value = Format(CDbl(Acum3), "#,##0")
        '************************************VISCOSA/SEDA*********************************************
        Fila = Fila + 1
        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "VISCOSA/SEDA"
        oSheet.Range("A" + CStr(Fila), "B" + CStr(Fila)).Interior.ColorIndex = 20

        Fila = Fila + 1
        Columna = 1
        oSheet.Cells(Fila, Columna).value = "NºLOTE"
        oSheet.Cells(Fila, Columna).ColumnWidth = 18
        Columna = 2
        oSheet.Cells(Fila, Columna).value = "COLOR"
        oSheet.Cells(Fila, Columna).ColumnWidth = 13
        Columna = 3
        oSheet.Cells(Fila, Columna).value = "KILOS"
        oSheet.Cells(Fila, Columna).ColumnWidth = 15
        Columna = 4
        oSheet.Cells(Fila, Columna).value = "CAJAS"
        oSheet.Cells(Fila, Columna).ColumnWidth = 15
        Columna = 5
        oSheet.Cells(Fila, Columna).value = "CONOS"
        oSheet.Cells(Fila, Columna).ColumnWidth = 16
        Columna = 6
        oSheet.Cells(Fila, Columna).value = "PROVEEDOR"
        oSheet.Cells(Fila, Columna).ColumnWidth = 18

        oSheet.Range("A" + CStr(Fila), "H" + CStr(Fila)).Interior.ColorIndex = 20

        Acum1 = 0
        Acum2 = 0
        Acum3 = 0
        sstr = "SELECT * FROM VISCOSA ORDER BY ALLOTE"
        DBFCommandH = New OleDbCommand(sstr, DBFConnH)
        DBFDataReaderH = DBFCommandH.ExecuteReader(CommandBehavior.Default)
        Do While DBFDataReaderH.Read
            If DBFDataReaderH("ALKILO").ToString <> "0" Then
                Fila = Fila + 1

                oSheet.Cells(Fila, 1).value = DBFDataReaderH("ALLOTE").ToString
                oSheet.Cells(Fila, 2).value = DBFDataReaderH("ALCOLO").ToString
                oSheet.Cells(Fila, 3).value = Format(CDbl(DBFDataReaderH("ALKILO")), "#,##0.000")
                oSheet.Cells(Fila, 4).value = Format(CDbl(DBFDataReaderH("ALCAJA")), "#,##0")
                oSheet.Cells(Fila, 5).value = Format(CDbl(DBFDataReaderH("ALCONO")), "#,##0")
                oSheet.Cells(Fila, 6).value = DBFDataReaderH("ALPROV").ToString
                Acum1 = Acum1 + CDbl(DBFDataReaderH("ALKILO").ToString)
                Acum2 = Acum2 + CDbl(DBFDataReaderH("ALCAJA").ToString)
                Acum3 = Acum3 + CDbl(DBFDataReaderH("ALCONO").ToString)
            End If
        Loop

        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "***TOTAL KILOS DE VISCOSA/SEDA"
        oSheet.Cells(Fila, 3).value = Format(CDbl(Acum1), "#,##0.000")
        oSheet.Cells(Fila, 4).value = Format(CDbl(Acum2), "#,##0")
        oSheet.Cells(Fila, 5).value = Format(CDbl(Acum3), "#,##0")
        '************************************ANGORA*********************************************
        Fila = Fila + 1
        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "ANGORA"
        oSheet.Range("A" + CStr(Fila), "B" + CStr(Fila)).Interior.ColorIndex = 20

        Fila = Fila + 1
        Columna = 1
        oSheet.Cells(Fila, Columna).value = "NºLOTE"
        oSheet.Cells(Fila, Columna).ColumnWidth = 18
        Columna = 2
        oSheet.Cells(Fila, Columna).value = "SELEC."
        oSheet.Cells(Fila, Columna).ColumnWidth = 13
        Columna = 3
        oSheet.Cells(Fila, Columna).value = "COLOR"
        oSheet.Cells(Fila, Columna).ColumnWidth = 15
        Columna = 4
        oSheet.Cells(Fila, Columna).value = "KILOS"
        oSheet.Cells(Fila, Columna).ColumnWidth = 15
        Columna = 5
        oSheet.Cells(Fila, Columna).value = "PROVEEDOR"
        oSheet.Cells(Fila, Columna).ColumnWidth = 18

        oSheet.Range("A" + CStr(Fila), "H" + CStr(Fila)).Interior.ColorIndex = 20

        Acum1 = 0
        sstr = "SELECT * FROM ANGORA ORDER BY ALLOTE"
        DBFCommandH = New OleDbCommand(sstr, DBFConnH)
        DBFDataReaderH = DBFCommandH.ExecuteReader(CommandBehavior.Default)
        Do While DBFDataReaderH.Read
            If DBFDataReaderH("ALKILO").ToString <> "0" Then
                Fila = Fila + 1

                oSheet.Cells(Fila, 1).value = CompletarCaracteresIzquierda(DBFDataReaderH("ALLOTE").ToString, 6, "0")
                oSheet.Cells(Fila, 2).value = DBFDataReaderH("ALNROC").ToString
                oSheet.Cells(Fila, 3).value = DBFDataReaderH("ALCOLO").ToString
                oSheet.Cells(Fila, 4).value = Format(CDbl(DBFDataReaderH("ALKILO")), "#,##0.000")
                oSheet.Cells(Fila, 5).value = DBFDataReaderH("ALPROV").ToString
                Acum1 = Acum1 + CDbl(DBFDataReaderH("ALKILO").ToString)
            End If
        Loop

        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "***TOTAL KILOS DE ANGORA EN STOCK"
        oSheet.Cells(Fila, 4).value = Format(CDbl(Acum1), "#,##0.000")
        '************************************FLANDEZ*********************************************
        Fila = Fila + 1
        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "FLANDEZ"
        oSheet.Range("A" + CStr(Fila), "B" + CStr(Fila)).Interior.ColorIndex = 20

        Fila = Fila + 1
        Columna = 1
        oSheet.Cells(Fila, Columna).value = "NºLOTE"
        oSheet.Cells(Fila, Columna).ColumnWidth = 18
        Columna = 2
        oSheet.Cells(Fila, Columna).value = "NºCOL."
        oSheet.Cells(Fila, Columna).ColumnWidth = 13
        Columna = 3
        oSheet.Cells(Fila, Columna).value = "COLOR"
        oSheet.Cells(Fila, Columna).ColumnWidth = 15
        Columna = 4
        oSheet.Cells(Fila, Columna).value = "KILOS"
        oSheet.Cells(Fila, Columna).ColumnWidth = 15
        Columna = 5
        oSheet.Cells(Fila, Columna).value = "PROVEEDOR"
        oSheet.Cells(Fila, Columna).ColumnWidth = 18

        oSheet.Range("A" + CStr(Fila), "H" + CStr(Fila)).Interior.ColorIndex = 20

        Acum1 = 0
        sstr = "SELECT * FROM FLANDEZ ORDER BY ALLOTE"
        DBFCommandH = New OleDbCommand(sstr, DBFConnH)
        DBFDataReaderH = DBFCommandH.ExecuteReader(CommandBehavior.Default)
        Do While DBFDataReaderH.Read
            If DBFDataReaderH("ALKILO").ToString <> "0" Then
                Fila = Fila + 1

                oSheet.Cells(Fila, 1).value = CompletarCaracteresIzquierda(DBFDataReaderH("ALLOTE").ToString, 6, "0")
                oSheet.Cells(Fila, 2).value = DBFDataReaderH("ALNROC").ToString
                oSheet.Cells(Fila, 3).value = DBFDataReaderH("ALCOLO").ToString
                oSheet.Cells(Fila, 4).value = Format(CDbl(DBFDataReaderH("ALKILO")), "#,##0.000")
                oSheet.Cells(Fila, 5).value = DBFDataReaderH("ALPROV").ToString
                Acum1 = Acum1 + CDbl(DBFDataReaderH("ALKILO").ToString)
            End If
        Loop

        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "***TOTAL KILOS DE FLANDEZ EN STOCK"
        oSheet.Cells(Fila, 4).value = Format(CDbl(Acum1), "#,##0.000")
        '************************************NYLON*********************************************
        Fila = Fila + 1
        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "NYLON"
        oSheet.Range("A" + CStr(Fila), "B" + CStr(Fila)).Interior.ColorIndex = 20

        Fila = Fila + 1
        Columna = 1
        oSheet.Cells(Fila, Columna).value = "NºLOTE"
        oSheet.Cells(Fila, Columna).ColumnWidth = 18
        Columna = 2
        oSheet.Cells(Fila, Columna).value = "NºCOL."
        oSheet.Cells(Fila, Columna).ColumnWidth = 13
        Columna = 3
        oSheet.Cells(Fila, Columna).value = "COLOR"
        oSheet.Cells(Fila, Columna).ColumnWidth = 15
        Columna = 4
        oSheet.Cells(Fila, Columna).value = "KILOS"
        oSheet.Cells(Fila, Columna).ColumnWidth = 15
        Columna = 5
        oSheet.Cells(Fila, Columna).value = "PROVEEDOR"
        oSheet.Cells(Fila, Columna).ColumnWidth = 18

        oSheet.Range("A" + CStr(Fila), "H" + CStr(Fila)).Interior.ColorIndex = 20

        Acum1 = 0
        sstr = "SELECT * FROM NYLON ORDER BY ALLOTE"
        DBFCommandH = New OleDbCommand(sstr, DBFConnH)
        DBFDataReaderH = DBFCommandH.ExecuteReader(CommandBehavior.Default)
        Do While DBFDataReaderH.Read
            If DBFDataReaderH("ALKILO").ToString <> "0" Then
                Fila = Fila + 1

                oSheet.Cells(Fila, 1).value = CompletarCaracteresIzquierda(DBFDataReaderH("ALLOTE").ToString, 6, "0")
                oSheet.Cells(Fila, 2).value = DBFDataReaderH("ALNROC").ToString
                oSheet.Cells(Fila, 3).value = DBFDataReaderH("ALCOLO").ToString
                oSheet.Cells(Fila, 4).value = Format(CDbl(DBFDataReaderH("ALKILO")), "#,##0.000")
                oSheet.Cells(Fila, 5).value = DBFDataReaderH("ALPROV").ToString
                Acum1 = Acum1 + CDbl(DBFDataReaderH("ALKILO").ToString)
            End If
        Loop

        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "***TOTAL KILOS DE NYLON EN STOCK"
        oSheet.Cells(Fila, 4).value = Format(CDbl(Acum1), "#,##0.000")
        '************************************POLIAMIDA CARDADO*********************************************
        Fila = Fila + 1
        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "POLIAMIDA CARDADO"
        oSheet.Range("A" + CStr(Fila), "B" + CStr(Fila)).Interior.ColorIndex = 20

        Fila = Fila + 1
        Columna = 1
        oSheet.Cells(Fila, Columna).value = "NºLOTE"
        oSheet.Cells(Fila, Columna).ColumnWidth = 18
        Columna = 2
        oSheet.Cells(Fila, Columna).value = "NºCOL."
        oSheet.Cells(Fila, Columna).ColumnWidth = 13
        Columna = 3
        oSheet.Cells(Fila, Columna).value = "COLOR"
        oSheet.Cells(Fila, Columna).ColumnWidth = 15
        Columna = 4
        oSheet.Cells(Fila, Columna).value = "KILOS"
        oSheet.Cells(Fila, Columna).ColumnWidth = 15
        Columna = 5
        oSheet.Cells(Fila, Columna).value = "PROVEEDOR"
        oSheet.Cells(Fila, Columna).ColumnWidth = 18

        oSheet.Range("A" + CStr(Fila), "H" + CStr(Fila)).Interior.ColorIndex = 20

        Acum1 = 0
        sstr = "SELECT * FROM POLIA ORDER BY ALLOTE"
        DBFCommandH = New OleDbCommand(sstr, DBFConnH)
        DBFDataReaderH = DBFCommandH.ExecuteReader(CommandBehavior.Default)
        Do While DBFDataReaderH.Read
            If DBFDataReaderH("ALKILO").ToString <> "0" Then
                Fila = Fila + 1

                oSheet.Cells(Fila, 1).value = CompletarCaracteresIzquierda(DBFDataReaderH("ALLOTE").ToString, 6, "0")
                oSheet.Cells(Fila, 2).value = DBFDataReaderH("ALNROC").ToString
                oSheet.Cells(Fila, 3).value = DBFDataReaderH("ALCOLO").ToString
                oSheet.Cells(Fila, 4).value = Format(CDbl(DBFDataReaderH("ALKILO")), "#,##0.000")
                oSheet.Cells(Fila, 5).value = DBFDataReaderH("ALPROV").ToString
                Acum1 = Acum1 + CDbl(DBFDataReaderH("ALKILO").ToString)
            End If
        Loop

        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "***TOTAL KILOS DE POLIAMIDA CARDADO EN STOCK"
        oSheet.Cells(Fila, 4).value = Format(CDbl(Acum1), "#,##0.000")
        '************************************POLYESTER*********************************************
        Fila = Fila + 1
        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "POLYESTER"
        oSheet.Range("A" + CStr(Fila), "B" + CStr(Fila)).Interior.ColorIndex = 20

        Fila = Fila + 1
        Columna = 1
        oSheet.Cells(Fila, Columna).value = "NºLOTE"
        oSheet.Cells(Fila, Columna).ColumnWidth = 18
        Columna = 2
        oSheet.Cells(Fila, Columna).value = "NºCOL."
        oSheet.Cells(Fila, Columna).ColumnWidth = 13
        Columna = 3
        oSheet.Cells(Fila, Columna).value = "COLOR"
        oSheet.Cells(Fila, Columna).ColumnWidth = 15
        Columna = 4
        oSheet.Cells(Fila, Columna).value = "KILOS"
        oSheet.Cells(Fila, Columna).ColumnWidth = 15
        Columna = 5
        oSheet.Cells(Fila, Columna).value = "PROVEEDOR"
        oSheet.Cells(Fila, Columna).ColumnWidth = 18

        oSheet.Range("A" + CStr(Fila), "H" + CStr(Fila)).Interior.ColorIndex = 20

        Acum1 = 0
        sstr = "SELECT * FROM POLY ORDER BY ALLOTE"
        DBFCommandH = New OleDbCommand(sstr, DBFConnH)
        DBFDataReaderH = DBFCommandH.ExecuteReader(CommandBehavior.Default)
        Do While DBFDataReaderH.Read
            If DBFDataReaderH("ALKILO").ToString <> "0" Then
                Fila = Fila + 1

                oSheet.Cells(Fila, 1).value = CompletarCaracteresIzquierda(DBFDataReaderH("ALLOTE").ToString, 6, "0")
                oSheet.Cells(Fila, 2).value = DBFDataReaderH("ALNROC").ToString
                oSheet.Cells(Fila, 3).value = DBFDataReaderH("ALCOLO").ToString
                oSheet.Cells(Fila, 4).value = Format(CDbl(DBFDataReaderH("ALKILO")), "#,##0.000")
                oSheet.Cells(Fila, 5).value = DBFDataReaderH("ALPROV").ToString
                Acum1 = Acum1 + CDbl(DBFDataReaderH("ALKILO").ToString)
            End If
        Loop

        Fila = Fila + 1
        oSheet.Cells(Fila, 1).value = "***TOTAL KILOS DE POLYESTER EN STOCK"
        oSheet.Cells(Fila, 4).value = Format(CDbl(Acum1), "#,##0.000")





        'CIERRO LA CONEXION PARA LEER DBF
        DBFConnH.Close()



        'Si no existe el directorio, lo creo
        If Not Directory.Exists(Application.StartupPath + "\Excel") Then Directory.CreateDirectory(Application.StartupPath + "\Excel")
        'Guardo el archivo 
        NombreArchivoExcel = Application.StartupPath + "\Excel\" + "Existencia_Mat-Prima_" + Format(Now, "dd-MM-yyyy HH-mm-ss") + ".xls"
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