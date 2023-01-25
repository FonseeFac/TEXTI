Imports System.Data.SqlClient
Imports System.IO
Imports System.IO.Compression
'Imports Shell32
Imports System.Data.OleDb
'Imports Microsoft.Office.Interop
'Imports Ionic.Zip

Module Globales
    Public cConexion, cConexionApp, cConexionBAS, cConexionN08, cConexionRW, cConexionPRUEBABAS, cConexionLAB As New cConexionSQL
    Public NoActualiza, Mensajes, Alta, ArtGuardar, ScannerAbierto As Boolean
    Public BaseLaboro, BaseApp, BaseReiWin, BaseBAS, BasePRUEBABAS, BaseNueva08, Tabla, Local, CodArticulo, ArtTalle, ArtColor, ArtCantidad, ArtCodArticulo, ArtDesArticulo, ArtPrecio, ItemSeleccionado As String
    Private Preguntar As Boolean
    Private CodigoPos, NombrePC As String

    Public IdAccesorioCopiado, IdPlanillaCopiarAccesorio As String

    Public Function ReConectar(ByVal Base) As Boolean
        On Error GoTo ErrReConectar
        ReConectar = False
        If Base = "AppTextilana" Then
            cConexionApp.Desconectar()
            cConexionApp.Conectar(BaseApp)
        ElseIf Base = "Laboro" Then
            cConexionLAB.Desconectar()
            cConexionLAB.Conectar(BaseLaboro)
        ElseIf Base = "ReiWin" Then
            cConexionRW.Desconectar()
            cConexionRW.Conectar(BaseReiWin)
        ElseIf Base = "Nueva08" Then
            cConexionN08.Desconectar()
            cConexionN08.Conectar(BaseNueva08)
        ElseIf Base = "BAS" Then
            cConexionBAS.Desconectar()
            cConexionBAS.Conectar(BaseBAS)
        ElseIf Base = "PRUEBABAS" Then
            cConexionPRUEBABAS.Desconectar()
            cConexionPRUEBABAS.Conectar(BasePRUEBABAS)
        End If
        ReConectar = True
        Exit Function
ErrReConectar:
        ReConectar = False
        MensajeCritico("Error al reconectar la base " + Base.ToString)
    End Function

    Public Function DescripcionLegajo(ByVal NroLegajo As String) As String
        On Error GoTo ErrDescripcionLegajo

        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        DescripcionLegajo = ""

        If cConexionLAB.SQLConn.State <> ConnectionState.Open Then ReConectar("Laboro")

        sStr = "SELECT Nombre FROM BL_PERSONAS WHERE Codigo = '" + NroLegajo.ToString + "'"
        Command = New SqlCommand(sStr, cConexionLAB.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                DescripcionLegajo = Reader.Item("Nombre").ToString
            End If
        End If
        Exit Function
ErrDescripcionLegajo:
        DescripcionLegajo = ""
        MensajeCritico("Error al recuperar la Descripción del Legajo.")
    End Function

    Public Function DescripcionPuestoLaboro(ByVal CodPuesto As String) As String
        On Error GoTo ErrDescripcionPuestoLaboro

        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        DescripcionPuestoLaboro = ""

        If cConexionLAB.SQLConn.State <> ConnectionState.Open Then ReConectar("Laboro")

        sStr = "SELECT Descripcion FROM ATRIBUTOSVAL WHERE CodAtr = 'CAT' AND CodAtrVal = '" + CodPuesto.ToString + "'"
        Command = New SqlCommand(sStr, cConexionLAB.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                DescripcionPuestoLaboro = Trim(Reader.Item("Descripcion").ToString)
            End If
        End If
        Exit Function
ErrDescripcionPuestoLaboro:
        DescripcionPuestoLaboro = ""
        MensajeCritico("Error al recuperar la Descripción del Puesto.")
    End Function

    Public Function FechaWin10(Fecha As String) As String
        On Error GoTo ErrFechaServer
        Dim Dia, Mes, Año, FechaUtil As String
        Dim sp As String()

        FechaWin10 = ""

        FechaUtil = Fecha.ToString
        sp = Split(FechaUtil, "/")
        Dia = CompletarCaracteresIzquierda(sp(0), 2, "0").ToString
        Mes = CompletarCaracteresIzquierda(sp(1), 2, "0").ToString
        Año = Strings.Left(sp(2), 4).ToString
        FechaWin10 = Dia.ToString + "/" + Mes.ToString + "/" + Año.ToString

        Exit Function
ErrFechaServer:
        MensajeAtencion("Error al recuperar la fecha de Win10.")
    End Function

    Public Sub CargarVariables(ByVal ConBasesDePrueba As Boolean)
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        ScannerAbierto = False
        'Es la única conexión que se carga a mano, para cargar las otras
        cConexionApp.Conectar("AppTextilana")
        sStr = "SELECT Tipo, Base FROM ConfigBasesDeDatos WHERE Habilitado = 1"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                Select Case Reader.Item("Tipo")
                    Case Is = "AppTextilana"
                        BaseApp = Reader.Item("Base").ToString
                    Case Is = "BAS Laboro"
                        BaseLaboro = Reader.Item("Base").ToString
                        cConexionLAB.Conectar(BaseLaboro)
                    Case Is = "ReiWin"
                        BaseReiWin = Reader.Item("Base").ToString
                        cConexionRW.Conectar(BaseReiWin)
                    Case Is = "BAS"
                        BaseBAS = Reader.Item("Base").ToString
                        cConexionBAS.Conectar(BaseBAS)
                    Case Is = "PRUEBABAS"
                        BasePRUEBABAS = Reader.Item("Base").ToString
                        If ConBasesDePrueba Then
                            cConexionPRUEBABAS.Conectar(BasePRUEBABAS)
                        End If
                    Case Is = "Nueva08"
                        BaseNueva08 = Reader.Item("Base").ToString
                        cConexionN08.Conectar(BaseNueva08)
                End Select
            Loop
            Reader.NextResult()
        Loop
    End Sub

    Public Function FechaLunesAnterior(ByVal Fecha As Date) As Date
        On Error GoTo ErrFechaLunesAnterior
        Do While Fecha.DayOfWeek <> DayOfWeek.Monday
            Fecha = Fecha.Date.AddDays(-1)
        Loop
        FechaLunesAnterior = Fecha
        Exit Function
ErrFechaLunesAnterior:
        MensajeCritico("Error al calcular la fecha del lunes anterior.")
        FechaLunesAnterior = Fecha
    End Function

    Public Function FechaDomingoPosterior(ByVal Fecha As Date) As Date
        On Error GoTo ErrFechaDomingoPosterior
        Do While Fecha.DayOfWeek <> DayOfWeek.Sunday
            Fecha = Fecha.Date.AddDays(1)
        Loop
        FechaDomingoPosterior = Fecha
        Exit Function
ErrFechaDomingoPosterior:
        MensajeCritico("Error al calcular la fecha del domingo posterior.")
        FechaDomingoPosterior = Fecha
    End Function

    Public Function FechaUltimoMes(ByVal Fecha As Date) As Date
        On Error GoTo ErrFechaUltimoMes
        Dim Año, Mes As Integer

        Año = Year(Fecha).ToString
        Mes = Month(Fecha).ToString

        'If Mes = 1 Then
        '    Mes = 12
        '    Año = Año - 1
        'End If

        FechaUltimoMes = DateSerial(Año, Mes, 0)

        Exit Function
ErrFechaUltimoMes:
        MensajeCritico("Error al calcular la fecha del último día del mes anterior.")
        FechaUltimoMes = Fecha
    End Function

    Public Function Auditoria(ByVal sMov As String) As String
        On Error GoTo ErrAuditoria
        Auditoria = " " & Now & " - " & sMov 'Auditar el nombre de la PC, ip, etc
        Exit Function
ErrAuditoria:
        MensajeCritico("Error al calcular la Auditoria.")
    End Function

    Public Function ValidarNumerico(ByVal xDesc As String, ByVal xValor As String) As Boolean
        On Error GoTo ErrValidarNumerico
        If IsNumeric(xValor) Then
            ValidarNumerico = True
        Else
            ValidarNumerico = False
            MensajeAtencion(xDesc & ": Debe ser un valor numérico.")
        End If
        Exit Function
ErrValidarNumerico:
        ValidarNumerico = False
        MensajeCritico("Error al calcular la validación numérica.")
    End Function

    Public Function NuevaVersionDisponible() As Boolean
        On Error GoTo ErrNuevaVersionDisponible
        Dim ProgramasActualizados As String
        Dim Actualizado As Boolean
        Actualizado = False
        NuevaVersionDisponible = False
        ProgramasActualizados = "Programas actualizados: " + vbCrLf
        ExisteActualizador()
        If ComprobarYActualizar("Update") Then
            Actualizado = True
            ProgramasActualizados = ProgramasActualizados + "- Update" + vbCrLf
        End If
        If ComprobarYActualizar("Hilamar") Then
            Actualizado = True
            ProgramasActualizados = ProgramasActualizados + "- Hilamar" + vbCrLf
        End If
        If Actualizado Then
            MensajeInfo(ProgramasActualizados)
        End If
        NuevaVersionDisponible = True
        Exit Function
ErrNuevaVersionDisponible:
        NuevaVersionDisponible = False
        MensajeCritico("Error al verificar una nueva versión del programa.")
    End Function

    Public Sub ExisteActualizador()
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT * FROM Programa WHERE Programa = 'Update'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                If Not File.Exists(Reader.Item("RutaApp").ToString) Then
                    ActualizarEnDisco("Update")
                End If
            End If
        End If
    End Sub

    Public Function EliminarArchivo(ByVal Archivo As String) As Boolean
        On Error GoTo ErrEliminarArchivo
        EliminarArchivo = False
        Kill(Archivo)
        EliminarArchivo = True
        Exit Function
ErrEliminarArchivo:
        EliminarArchivo = False
    End Function

    Public Function ActualizarEnDisco(ByVal Programa As String) As Boolean
        On Error GoTo ActualizarEnDiscoErr
        Dim Command As New SqlCommand("Select * From Programa WHERE Programa = '" + Programa.ToString + "'", cConexionApp.SQLConn)

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        Using dr As SqlDataReader = Command.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.Read() Then
                Dim oFI As New FileInfo(dr.Item("RutaApp").ToString)
                If oFI.Exists Then oFI.Delete()
                Dim fs As IO.FileStream = New IO.FileStream(dr.Item("RutaApp").ToString, IO.FileMode.Create)
                Dim b() As Byte = dr.Item("Codigo")
                fs.Write(b, 0, b.Length)
                fs.Close()
            End If
        End Using
        ActualizarEnDisco = True
        Exit Function
ActualizarEnDiscoErr:
        ActualizarEnDisco = False
    End Function

    Public Function ComprobarYActualizar(ByVal Programa As String) As Boolean
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        ComprobarYActualizar = False

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT * FROM Programa WHERE Programa = '" + Programa.ToString + "'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                If File.Exists(Reader.Item("RutaApp").ToString) Then
                    If FileDateTime(Reader.Item("RutaApp").ToString) < Reader.Item("Fecha") Then
                        ComprobarYActualizar = True
                        'Aca disparar el exe para el cambio del programa
                        If Programa = "Update" Then
                            ActualizarEnDisco("Update")
                        Else
                            'EjecutarYEsperar("C:\Textilana\Actualizador.exe")
                            Process.Start("C:\Hilamar\Update.exe")
                            End
                            Application.ExitThread()
                            Application.Exit()
                        End If
                    End If
                End If
            Else
                ActualizarEnDisco("Update")
            End If
        End If
    End Function

    Public Sub EjecutarYEsperar(ByVal Ejecutable As String)
        Dim pInfo As New ProcessStartInfo()
        pInfo.FileName = Ejecutable.ToString
        Dim p As Process = Process.Start(pInfo)
        p.WaitForExit()
    End Sub

    Public Sub Auditar(ByVal xOperacion As String, ByVal xCodigo As String)
        On Error GoTo ErrAuditar
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "INSERT INTO  Auditoria (CodUsuario, Operacion, Codigo) VALUES ('" & NombrePC & "', '" & xOperacion & "', '" & xCodigo & "')"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()
        Exit Sub
ErrAuditar:
        MensajeCritico("Error al auditar el movimiento.")
    End Sub

    'Mensajes Públicos, sólo se envía el texto
    Public Sub MensajeInfo(ByVal xMensaje As String)
        MsgBox(xMensaje, vbInformation + vbOKOnly, "Textilana")
    End Sub

    Public Sub MensajeAtencion(ByVal xMensaje As String)
        MsgBox(xMensaje, vbExclamation + vbOKOnly, "Textilana")
    End Sub

    Public Sub MensajeCritico(ByVal xMensaje As String)
        MsgBox(xMensaje, vbCritical + vbOKOnly, "Textilana")
    End Sub

    Public Function ByteToImage(ByVal blob() As Byte) As Bitmap
        Dim mStream As New MemoryStream
        Dim pData() As Byte = DirectCast(blob, Byte())
        mStream.Write(pData, 0, Convert.ToInt32(pData.Length))
        Dim bm As Bitmap = New Bitmap(mStream, False)
        mStream.Dispose()
        Return bm
    End Function

    Public Function FormatearNumero(ByVal Numero As Double, ByVal CantDec As Integer, Optional ByVal SeparadorDeMil As Boolean = True) As String
        On Error Resume Next
        Dim spNum As Integer
        Dim R1, R2 As Double
        Dim L1, L2, L3, L4, L5, RightN, NumStr As String

        FormatearNumero = "0"
        'Puntos en separadores de miles, doble dígito en los decimales
        RightN = ""
        L1 = ""
        L2 = ""
        L3 = ""
        L4 = ""
        L5 = ""
        NumStr = Numero.ToString
        spNum = InStr(NumStr, ",")
        If spNum = 0 Then
            'FormatearNumero = LeftN
            RightN = CompletarCaracteres(RightN, CantDec, "0")
        Else
            RightN = Strings.Right(NumStr, Len(NumStr) - spNum)
            NumStr = Strings.Left(NumStr, spNum - 1)
        End If

        If Len(NumStr) > 3 Then
            L1 = Strings.Right(NumStr, 3)
            NumStr = Strings.Left(NumStr, Len(NumStr) - 3)
            If Len(NumStr) > 3 Then
                L2 = Strings.Right(NumStr, 3)
                NumStr = Strings.Left(NumStr, Len(NumStr) - 3)
                If Len(NumStr) > 3 Then
                    L3 = Strings.Right(NumStr, 3)
                    NumStr = Strings.Left(NumStr, Len(NumStr) - 3)
                    If Len(NumStr) > 3 Then
                        L4 = Strings.Right(NumStr, 3)
                        NumStr = Strings.Left(NumStr, Len(NumStr) - 3)
                        If Len(NumStr) > 3 Then
                            L5 = Strings.Right(NumStr, 3)
                        Else
                            L5 = NumStr
                        End If
                    Else
                        L4 = NumStr
                    End If
                Else
                    L3 = NumStr
                End If
            Else
                L2 = NumStr
            End If
        Else
            L1 = NumStr
        End If
        If L1 <> "" Then FormatearNumero = L1.ToString
        If SeparadorDeMil Then
            If L2 <> "" Then FormatearNumero = L2.ToString + "." + L1.ToString
        Else
            If L2 <> "" Then FormatearNumero = L2.ToString + L1.ToString
        End If
        If SeparadorDeMil Then
            If L3 <> "" Then FormatearNumero = L3.ToString + "." + L2.ToString + "." + L1.ToString
        Else
            If L3 <> "" Then FormatearNumero = L3.ToString + L2.ToString + L1.ToString
        End If
        If SeparadorDeMil Then
            If L4 <> "" Then FormatearNumero = L4.ToString + "." + L3.ToString + "." + L2.ToString + "." + L1.ToString
        Else
            If L4 <> "" Then FormatearNumero = L4.ToString + L3.ToString + L2.ToString + L1.ToString
        End If
        If SeparadorDeMil Then
            If L5 <> "" Then FormatearNumero = L5.ToString + "." + L4.ToString + "." + L3.ToString + "." + L2.ToString + "." + L1.ToString
        Else
            If L5 <> "" Then FormatearNumero = L5.ToString + L4.ToString + L3.ToString + L2.ToString + L1.ToString
        End If
        If Len(RightN) > CantDec Then 'Si es mayor, redondear
            R1 = Strings.Left(RightN, CantDec).ToString()
            R2 = Strings.Mid(RightN, CantDec + 1, 2)
            If R2 > 50 Then R1 = R1 + 1
            RightN = R1.ToString
        End If
        If Len(RightN) < CantDec Then
            RightN = CompletarCaracteres(RightN, CantDec, "0")
        End If

        If CantDec > 0 Then FormatearNumero = FormatearNumero + "," + RightN.ToString

    End Function

    Public Function CompletarCaracteres(ByVal Texto As String, ByVal Cant As Integer, ByVal Character As String) As String
        On Error GoTo ErrCompletaChar
        CompletarCaracteres = ""
        If Len(Texto) <= Cant Then
            CompletarCaracteres = Texto + StrDup(Cant - Len(Texto), Character)
        End If
        Exit Function
ErrCompletaChar:
        CompletarCaracteres = False
    End Function

    Public Function CompletarCaracteresIzquierda(ByVal Texto As String, ByVal Cant As Integer, ByVal Character As String) As String
        On Error GoTo ErrCompletaChar
        CompletarCaracteresIzquierda = ""
        If Len(Texto) > Cant Then
            Texto = Strings.Right(Texto, 2)
        End If
        CompletarCaracteresIzquierda = StrDup(Cant - Len(Texto), Character) + Texto
        Exit Function
ErrCompletaChar:
        CompletarCaracteresIzquierda = False
    End Function

    Public Function MailCliente(ByVal NroPedido As Integer) As String
        On Error GoTo ErrMailCliente
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr, Prefijo As String

        MailCliente = ""

        If NroPedido >= 100000 Then
            Prefijo = "8000"
        Else
            Prefijo = "7000"
        End If

        If cConexionBAS.SQLConn.State <> ConnectionState.Open Then ReConectar("BAS")

        sStr = "SELECT C.EMAIL "
        sStr = sStr + "FROM TRANSAC T INNER JOIN CTACTESCONT C ON T.CODCTACTE = C.CODCTACTE "
        sStr = sStr + "WHERE T.NUMERO = " + NroPedido.ToString + " AND T.PREFIJO = " + Prefijo.ToString
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                MailCliente = Reader.Item("EMAIL").ToString
            End If
        End If
        Exit Function
ErrMailCliente:
        MailCliente = ""
    End Function

    Public Function CrearTablaTemporal(ByVal NombreTabla As String, ByVal NombreCampos As String) As Boolean
        On Error GoTo ErrCrearTablaTemporal
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr, sItem As String
        Dim Salir, Existe As Boolean
        Dim Pos, TipoItem As Integer

        Existe = False

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[" + NombreTabla + "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                Existe = True
            End If
        End If

        If Existe Then
            sStr = "DROP TABLE " + NombreTabla
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()
        End If

        sStr = "CREATE TABLE " + NombreTabla + "("
        Do While Not Salir
            Pos = InStr(NombreCampos, ",", CompareMethod.Text)
            If Pos > 0 Then
                sItem = Strings.Left(NombreCampos, Pos - 1)
                NombreCampos = Strings.Right(NombreCampos, Len(NombreCampos) - Pos)
            Else
                sItem = Strings.Left(NombreCampos, Len(NombreCampos))
            End If
            If Pos = 0 Then Salir = True
            TipoItem = Strings.Right(sItem, 1)
            sItem = Strings.Left(sItem, Len(sItem) - 1)
            If TipoItem = 1 Then
                sStr = sStr + sItem.ToString + " VARCHAR(100), "
            ElseIf TipoItem = 2 Then
                sStr = sStr + sItem.ToString + " NUMERIC, "
            ElseIf TipoItem = 3 Then
                sStr = sStr + sItem.ToString + " FLOAT, "
            ElseIf TipoItem = 4 Then
                sStr = sStr + sItem.ToString + " DATE, "
            End If
        Loop
        sStr = Strings.Left(sStr, Len(sStr) - 2)
        sStr = sStr + ")"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()
        CrearTablaTemporal = True
        Exit Function
ErrCrearTablaTemporal:
        CrearTablaTemporal = False
        sStr = "DROP TABLE " + NombreTabla
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()
        MensajeCritico("Error al crear la tabla temporal.")

    End Function

    Public Function NombreTablaTemp(ByVal NombreTabla As String) As String
        On Error GoTo ErrNombreTablaTemp
        NombreTablaTemp = ""
        NombreTablaTemp = NombreTabla + CInt(Int((9999 * Rnd()) + 1)).ToString
        Exit Function
ErrNombreTablaTemp:
        MensajeCritico("Erro al generar el nombre de la tabla temporal.")
    End Function

    Private Function FormPrecio(ByVal Precio As String, Optional ByVal PrecioOri As Boolean = False) As String
        FormPrecio = ""
        If Not PrecioOri Then
            FormPrecio = Strings.Left(Precio, Len(Precio) - 3)
        Else
            FormPrecio = Precio
        End If
        FormPrecio = CompletarCaracteresIzquierda(FormPrecio, 7, "0")
        FormPrecio = Replace(FormPrecio, ",", ".")
    End Function

    Public Function FormPrecio2Dec(ByVal Precio As String) As String
        FormPrecio2Dec = Strings.Left(Precio, Len(Precio) - 3)
        FormPrecio2Dec = Replace(FormPrecio2Dec, ",", ".")
    End Function

    Public Sub CerrarProceso(ByVal Nombre As String)
        Dim proc As System.Diagnostics.Process
        For Each proc In System.Diagnostics.Process.GetProcessesByName(Nombre)
            proc.Kill()
        Next
    End Sub
    Public Sub CerrarProcesoId(ByVal Id As Integer)
        Dim proc As System.Diagnostics.Process
        proc = System.Diagnostics.Process.GetProcessById(Id)
        proc.Kill()

    End Sub

    Private Function FormColor(ByVal Numero As String) As String
        FormColor = ""
        If Len(Numero) = 1 Then
            FormColor = "00" + Numero
        ElseIf Len(Numero) = 2 Then
            FormColor = "0" + Numero
        ElseIf Len(Numero) = 3 Then
            FormColor = Numero
        End If
    End Function

    Private Function PosNro(ByVal Pos As Integer) As Integer
        PosNro = Mid(CodigoPos, Pos, 1)
    End Function

    Public Sub GenerarTXT(ByVal Archivo As String)
        On Error GoTo ErrGenerarTXT
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        Dim file As System.IO.FileStream
        Dim Linea, ArchivoTXT, Horas As String
        ArchivoTXT = ""
        'Formato del archivo Liqui1.TXT
        '         1         2         3         4         5         6         7         8         9       100         1         2
        '123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789013245678901234567890
        '*A00001                                              1                                 80.00    901   1  1213 
        If Archivo = "Liqui1" Then
            sStr = "SELECT * FROM TmpLiqui1"
            ArchivoTXT = Application.StartupPath + "\Liqui1.txt"
        End If
        file = System.IO.File.Create(ArchivoTXT)
        file.Close()
        Dim addInfo As New System.IO.StreamWriter(ArchivoTXT)

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        If Archivo = "Liqui1" Then
            sStr = "SELECT * FROM TmpLiqui1"
        End If
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                Horas = CompletarCaracteresIzquierda(FormatNumber(Reader.Item("Horas"), 2), 6, " ")
                Linea = "*" + Reader.Item("Legajo") + Space(44) + CompletarCaracteresIzquierda(CInt(Reader.Item("CONCE")), 3, " ") + Space(32) + Replace(Horas, ",", ".")
                Linea = Linea + Space(4) + Reader.Item("CC") + Space(3) + Reader.Item("LVTOS") + Space(2) + Reader.Item("MVTOS")
                addInfo.WriteLine(Linea)
            Loop
            Reader.NextResult()
        Loop
        Reader.Close()
        addInfo.Close()
        Exit Sub
ErrGenerarTXT:
        MensajeCritico("Error al Generar el archivo TXT.")
    End Sub

    Public Function MasDeUnParentesis(ByVal Datos As String) As Boolean
        Dim PosIn As Integer
        MasDeUnParentesis = False
        PosIn = InStr(Datos, "(", CompareMethod.Text)
        Datos = Strings.Right(Datos, Len(Datos) - PosIn)
        PosIn = InStr(Datos, "(", CompareMethod.Text)
        If PosIn > 0 Then
            MasDeUnParentesis = True
        End If
    End Function

    Public Function RemoverEspacios(ByVal Cadena As String) As String
        Dim PosI, PosF As Integer
        Dim Control, Compara As String
        PosI = 0
        PosF = 0
        RemoverEspacios = ""
        Control = ""
        Compara = ""

        For i = 1 To Len(Cadena)
            Control = Strings.Left(Cadena, i)
            Compara = CompletarCaracteresIzquierda("", i, " ")
            If Control = vbLf Or Control = Compara Then
                PosI = i
            End If
        Next
        RemoverEspacios = Microsoft.VisualBasic.Strings.Right(Cadena, Len(Cadena) - PosI)
    End Function

    Public Function NombreMes(ByVal NroMes As Integer, Optional ByVal Mayusculas As Boolean = False) As String
        NombreMes = ""
        If NroMes = 1 Then
            NombreMes = "Enero"
        ElseIf NroMes = 2 Then
            NombreMes = "Febrero"
        ElseIf NroMes = 3 Then
            NombreMes = "Marzo"
        ElseIf NroMes = 4 Then
            NombreMes = "Abril"
        ElseIf NroMes = 5 Then
            NombreMes = "Mayo"
        ElseIf NroMes = 6 Then
            NombreMes = "Junio"
        ElseIf NroMes = 7 Then
            NombreMes = "Julio"
        ElseIf NroMes = 8 Then
            NombreMes = "Agosto"
        ElseIf NroMes = 9 Then
            NombreMes = "Septiembre"
        ElseIf NroMes = 10 Then
            NombreMes = "Octubre"
        ElseIf NroMes = 11 Then
            NombreMes = "Noviembre"
        ElseIf NroMes = 12 Then
            NombreMes = "Diciembre"
        End If
        If Mayusculas Then
            NombreMes = UCase(NombreMes.ToString)
        End If
    End Function

    Public Function NombreDia(ByVal Fecha As Date, Optional ByVal Completo As Boolean = False) As String
        NombreDia = ""
        NombreDia = Fecha.DayOfWeek.ToString
        If NombreDia = "Monday" Then
            NombreDia = "L"
            If Completo Then NombreDia = "LUNES"
        ElseIf NombreDia = "Tuesday" Then
            NombreDia = "M"
            If Completo Then NombreDia = "MARTES"
        ElseIf NombreDia = "Wednesday" Then
            NombreDia = "M"
            If Completo Then NombreDia = "MIERCOLES"
        ElseIf NombreDia = "Thursday" Then
            NombreDia = "J"
            If Completo Then NombreDia = "JUEVES"
        ElseIf NombreDia = "Friday" Then
            NombreDia = "V"
            If Completo Then NombreDia = "VIERNES"
        ElseIf NombreDia = "Saturday" Then
            NombreDia = "S"
            If Completo Then NombreDia = "SABADO"
        ElseIf NombreDia = "Sunday" Then
            NombreDia = "D"
            If Completo Then NombreDia = "DOMINGO"
        End If
    End Function

  
    <System.Runtime.InteropServices.DllImport("user32.dll", SetLastError:=True)> _
    Public Function GetWindowThreadProcessId(ByVal hWnd As IntPtr, _
    ByRef lpdwProcessId As Integer) As Integer
    End Function

    Public Sub NAR(ByVal o As Object)
        'http://support.microsoft.com/kb/317109
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0)

            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Public Function SQLStr(ByVal Str As String) As String
        SQLStr = ""
        If Len(Str) > 0 Then SQLStr = Replace(Str, "'", "''")
    End Function

    Public Function FormAbierto(ByVal Form As Form) As Boolean
        On Error GoTo ErrFormAbierto
        Dim objForm As Form
        FormAbierto = False
        For Each objForm In My.Application.OpenForms
            If (Trim(objForm.Name) = Trim(Form.Name)) Then
                objForm.BringToFront()
                FormAbierto = True
            End If
        Next
        Exit Function
ErrFormAbierto:
        FormAbierto = False
        MensajeCritico("Error al comprobar si los formularios están abiertos.")
    End Function

    Public Function DiasEnElMes(ByVal Fecha As Date) As Integer
        On Error GoTo ErrDiasEnElMes
        Dim Mes As Integer

        DiasEnElMes = 0

        Fecha = "01/" + Month(Fecha).ToString + "/" + Year(Fecha).ToString
        Fecha = Fecha.AddMonths(1)
        Fecha = Fecha.AddDays(-1)
        DiasEnElMes = Fecha.Day.ToString

        Exit Function
ErrDiasEnElMes:
        DiasEnElMes = 0
        MensajeAtencion("Error al devolver los días que hay en el mes.")
    End Function

    Public Function DescripcionCodigo(Codigo As String, ByRef Tipo As String) As String
        On Error GoTo ErrDescripcionCodigo
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        DescripcionCodigo = ""
        Tipo = ""

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT Codigo, Descripcion, 'Hilados' AS TIPO FROM HilamarHilados WHERE Codigo = '" + Codigo.ToString + "' UNION "
        sStr = sStr + "SELECT Codigo, Descripcion, 'MateriasPrimas' AS TIPO FROM HilamarMateriasPrimas WHERE Codigo = '" + Codigo.ToString + "' UNION "
        sStr = sStr + "SELECT Codigo, Descripcion, 'Procesos' AS TIPO FROM HilamarProcesos WHERE Codigo = '" + Codigo.ToString + "'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                Codigo = Reader.Item("Descripcion").ToString
                Tipo = Reader.Item("TIPO").ToString
                DescripcionCodigo = Codigo.ToString
            End If
        End If

        Exit Function
ErrDescripcionCodigo:
        DescripcionCodigo = ""
        Tipo = ""
    End Function

    Public Function AcomodarLegajo(ByVal Legajo As String, ByVal PrimerLetra As String) As String
        On Error GoTo ErrAcomodarLegajo

        Dim auxLegajo As String = UCase(Legajo)
        If IsNumeric(auxLegajo) Then
            auxLegajo = PrimerLetra + CompletarCaracteresIzquierda(auxLegajo, 5, "0").ToString
        Else
            If Strings.Left(auxLegajo, 1) = "A" Or Strings.Left(auxLegajo, 1) = "S" Then
                If Strings.Left(auxLegajo, 2) = "SH" Then
                    auxLegajo = Strings.Left(auxLegajo, 2) + CompletarCaracteresIzquierda(Strings.Right(auxLegajo, auxLegajo.Length - 2), 4, "0")
                Else
                    auxLegajo = Strings.Left(auxLegajo, 1) + CompletarCaracteresIzquierda(Strings.Right(auxLegajo, auxLegajo.Length - 1), 5, "0")
                End If
            Else
                'no hago nada porque no es una A o una S o una SH
            End If
        End If
        AcomodarLegajo = auxLegajo

        Exit Function
ErrAcomodarLegajo:
        AcomodarLegajo = UCase(Legajo)
    End Function

    '    Public Function CopiarPartidasUnix() As Boolean
    '        Dim UltimaModifLocal, UltimaModifServer As Date

    '        On Error GoTo ErrCopiarPartidasUnix
    '        Dim Archivo, ArchivoVB, Comando As String

    '        Archivo = ""
    '        ArchivoVB = ""
    '        If Not Telnet.Conectado Then Telnet.Conectar()
    '        Threading.Thread.Sleep(1000)
    '        Telnet.EnviarComando("hugo")
    '        Threading.Thread.Sleep(1000)
    '        Telnet.EnviarComando("walter")
    '        Threading.Thread.Sleep(1000)
    '        Telnet.EnviarComando("cd /u/hilamar/sto")
    '        Telnet.EnviarComando("cp hilstock.dbf hilstockvb.dbf")
    '        Telnet.EnviarComando("cp tipohila.dbf tipohilavb.dbf")

    '        If Not File.Exists(Application.StartupPath + "\bases\hilstock.dbf") Then
    '            File.Copy("\\192.168.0.12\u\hilamar\sto\hilstockvb.dbf", Application.StartupPath + "\bases\hilstock.dbf", True)
    '        Else
    '            UltimaModifLocal = My.Computer.FileSystem.GetFileInfo(Application.StartupPath + "\bases\hilstock.dbf").LastWriteTime
    '            UltimaModifServer = My.Computer.FileSystem.GetFileInfo("\\192.168.0.12\u\hilamar\sto\hilstock.dbf").LastWriteTime
    '            If UltimaModifLocal < UltimaModifServer Then
    '                My.Computer.FileSystem.DeleteFile(Application.StartupPath + "\bases\hilstock.dbf")
    '                File.Copy("\\192.168.0.12\u\hilamar\sto\hilstockvb.dbf", Application.StartupPath + "\bases\hilstock.dbf", True)
    '            End If
    '        End If
    '        Threading.Thread.Sleep(1000)
    '        'Telnet.Desconectar() 'Por qué estaba comentado????

    '        If Not File.Exists(Application.StartupPath + "\bases\tipohila.dbf") Then
    '            File.Copy("\\192.168.0.12\u\hilamar\sto\tipohilavb.dbf", Application.StartupPath + "\bases\tipohila.dbf", True)
    '        Else
    '            UltimaModifLocal = My.Computer.FileSystem.GetFileInfo(Application.StartupPath + "\bases\tipohila.dbf").LastWriteTime
    '            UltimaModifServer = My.Computer.FileSystem.GetFileInfo("\\192.168.0.12\u\hilamar\sto\tipohila.dbf").LastWriteTime
    '            If UltimaModifLocal < UltimaModifServer Then
    '                My.Computer.FileSystem.DeleteFile(Application.StartupPath + "\bases\tipohila.dbf")
    '                File.Copy("\\192.168.0.12\u\hilamar\sto\tipohilavb.dbf", Application.StartupPath + "\bases\tipohila.dbf")
    '            End If
    '        End If
    '        Threading.Thread.Sleep(1000)

    '        CopiarPartidasUnix = True
    '        Exit Function
    'ErrCopiarPartidasUnix:
    '        CopiarPartidasUnix = False
    '    End Function

    Public Function NumeroMes(ByVal NombreMes As String) As String
        Dim NroMes As String = ""
        If NombreMes = "ENERO" Then
            NroMes = 1
        ElseIf NombreMes = "FEBRERO" Then
            NroMes = 2
        ElseIf NombreMes = "MARZO" Then
            NroMes = 3
        ElseIf NombreMes = "ABRIL" Then
            NroMes = 4
        ElseIf NombreMes = "MAYO" Then
            NroMes = 5
        ElseIf NombreMes = "JUNIO" Then
            NroMes = 6
        ElseIf NombreMes = "JULIO" Then
            NroMes = 7
        ElseIf NombreMes = "AGOSTO" Then
            NroMes = 8
        ElseIf NombreMes = "SEPTIEMBRE" Then
            NroMes = 9
        ElseIf NombreMes = "OCTUBRE" Then
            NroMes = 10
        ElseIf NombreMes = "NOVIEMBRE" Then
            NroMes = 11
        ElseIf NombreMes = "DICIEMBRE" Then
            NroMes = 12
        End If
        NumeroMes = NroMes
    End Function

    Public Function NombreCTACTE(ByVal CodCliente As String) As String
        On Error GoTo ErrNombreCTACTE
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        NombreCTACTE = ""

        If cConexionBAS.SQLConn.State <> ConnectionState.Open Then ReConectar("BAS")

        sStr = "SELECT NOMBRE FROM CTACTES WHERE CODCTACTE = '" + CodCliente.ToString + "'"
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                NombreCTACTE = Trim(Reader.Item("Nombre")).ToString
            End If
        End If
        Exit Function
ErrNombreCTACTE:
        NombreCTACTE = ""
    End Function

    Public Sub CantidadPrendasPedidoBAS(ByVal NroTrans As Integer, ByRef CantPrendas As Integer, ByRef CantAcc As Integer)
        On Error GoTo ErrCantidadPrendasPedidoBAS
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        If cConexionBAS.SQLConn.State <> ConnectionState.Open Then ReConectar("BAS")

        sStr = "SELECT SUM(CANTIDAD) AS CANT FROM MVSITEMS WHERE NROTRANS = " + NroTrans.ToString + " AND LEFT(CODITM,1) <> 'A'"
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                If IsDBNull(Reader.Item("CANT").ToString) Then
                    CantPrendas = 0
                Else
                    If Reader.Item("CANT").ToString = "" Then
                        CantPrendas = 0
                    Else
                        CantPrendas = Reader.Item("CANT").ToString
                    End If
                End If
            End If
        End If

        sStr = "SELECT SUM(CANTIDAD) AS CANT FROM MVSITEMS WHERE NROTRANS = " + NroTrans.ToString + " AND LEFT(CODITM,1) = 'A' AND CODITM <> 'AJU'"
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                If IsDBNull(Reader.Item("CANT").ToString) Then
                    CantAcc = 0
                Else
                    If Reader.Item("CANT").ToString = "" Then
                        CantAcc = 0
                    Else
                        CantAcc = Reader.Item("CANT").ToString
                    End If
                End If

            End If
        End If

        Exit Sub
ErrCantidadPrendasPedidoBAS:
        MensajeAtencion("Error al recuperar la cantidad de prendas del pedido.")
    End Sub

    Public Function NowServer() As String
        On Error GoTo ErrNowServer
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        NowServer = ""

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT GETDATE() AS NowServer"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                NowServer = Reader.Item("NowServer").ToString
            End If
        End If

        Exit Function
ErrNowServer:
        MensajeAtencion("Error al recuperar el Now() del servidor.")
    End Function

    Public Function NumeroDeTalle(Talle As String) As Integer
        On Error GoTo ErrNumeroDeTalle

        NumeroDeTalle = 0

        If Talle = "XXS" Then
            NumeroDeTalle = 7
        ElseIf Talle = "XS" Then
            NumeroDeTalle = 6
        ElseIf Talle = "S" Then
            NumeroDeTalle = 1
        ElseIf Talle = "M" Then
            NumeroDeTalle = 2
        ElseIf Talle = "L" Then
            NumeroDeTalle = 3
        ElseIf Talle = "XL" Then
            NumeroDeTalle = 4
        ElseIf Talle = "XXL" Then
            NumeroDeTalle = 5
        ElseIf Talle = "U" Then
            NumeroDeTalle = 8
        End If

        Exit Function
ErrNumeroDeTalle:
        NumeroDeTalle = 0
        MensajeAtencion("Error al recuperar el número de talle a partir de un texto.")
    End Function

    Public Function LetraTalle(Talle As Integer) As String
        On Error GoTo ErrLetraTalle

        LetraTalle = ""

        If Talle = 7 Then
            LetraTalle = "XXS"
        ElseIf Talle = 6 Then
            LetraTalle = "XS"
        ElseIf Talle = 1 Then
            LetraTalle = "S"
        ElseIf Talle = 2 Then
            LetraTalle = "M"
        ElseIf Talle = 3 Then
            LetraTalle = "L"
        ElseIf Talle = 4 Then
            LetraTalle = "XL"
        ElseIf Talle = 5 Then
            LetraTalle = "XXL"
        ElseIf Talle = 8 Then
            LetraTalle = "U"
        End If

        Exit Function
ErrLetraTalle:
        LetraTalle = ""
        MensajeAtencion("Error al recuperar el talle a partir de un texto.")
    End Function

    Public Function CopiarDatosMateriaPrimaUnix() As Boolean
        Dim UltimaModifLocal, UltimaModifServer As Date

        On Error GoTo ErrCopiarPartidasUnix
        Dim Archivo, ArchivoVB, Comando As String


        Dim FormProgre As New frmProgreso
        FormProgre.CantMax = 15
        FormProgre.lblTarea.Text = "Copiando Archivos de Existencias de Materias Primas "
        FormProgre.lblEstado.Text = "Preparando archivos ..."
        FormProgre.Cargar()
        FormProgre.Show()
        FormProgre.CantProg = 1
        FormProgre.Actualizar()

        Archivo = ""
        ArchivoVB = ""
        If Not Telnet.Conectado Then Telnet.Conectar()
        Threading.Thread.Sleep(1000)
        Telnet.EnviarComando("hugo")
        Threading.Thread.Sleep(1000)
        Telnet.EnviarComando("walter")
        Threading.Thread.Sleep(1000)
        Telnet.EnviarComando("cd /u/hilamar/sto")
        Telnet.EnviarComando("cp barlav.dbf barlavvb.dbf")
        Telnet.EnviarComando("cp thilan.dbf thilanvb.dbf")
        Telnet.EnviarComando("cp ttinto.dbf ttintovb.dbf")
        Telnet.EnviarComando("cp topcar.dbf topcarvb.dbf")
        Telnet.EnviarComando("cp topcar1.dbf topcar1vb.dbf")
        Telnet.EnviarComando("cp tbteni.dbf tbtenivb.dbf")
        Telnet.EnviarComando("cp acrilico.dbf acrilicovb.dbf")
        Telnet.EnviarComando("cp algodon.dbf algodonvb.dbf")
        Telnet.EnviarComando("cp viscosa.dbf viscosavb.dbf")
        Telnet.EnviarComando("cp angora.dbf angoravb.dbf")
        Telnet.EnviarComando("cp flandez.dbf flandezvb.dbf")
        Telnet.EnviarComando("cp nylon.dbf nylonvb.dbf")
        Telnet.EnviarComando("cp polia.dbf poliavb.dbf")
        Telnet.EnviarComando("cp poly.dbf polyvb.dbf")

        FormProgre.lblEstado.Text = "Copiando Lana Sucia ..."
        FormProgre.CantProg = FormProgre.CantProg + 1
        FormProgre.Actualizar()

        If Not File.Exists(Application.StartupPath + "\bases\barlav.dbf") Then
            File.Copy("\\192.168.0.12\u\hilamar\sto\barlavvb.dbf", Application.StartupPath + "\bases\barlav.dbf", True)
        Else
            UltimaModifLocal = My.Computer.FileSystem.GetFileInfo(Application.StartupPath + "\bases\barlav.dbf").LastWriteTime
            UltimaModifServer = My.Computer.FileSystem.GetFileInfo("\\192.168.0.12\u\hilamar\sto\barlav.dbf").LastWriteTime
            If UltimaModifLocal < UltimaModifServer Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath + "\bases\barlav.dbf")
                File.Copy("\\192.168.0.12\u\hilamar\sto\barlavvb.dbf", Application.StartupPath + "\bases\barlav.dbf", True)
            End If
        End If
        Threading.Thread.Sleep(1000)

        FormProgre.lblEstado.Text = "Copiando Tops Hilanderia ..."
        FormProgre.CantProg = FormProgre.CantProg + 1
        FormProgre.Actualizar()

        If Not File.Exists(Application.StartupPath + "\bases\thilan.dbf") Then
            File.Copy("\\192.168.0.12\u\hilamar\sto\thilanvb.dbf", Application.StartupPath + "\bases\thilan.dbf", True)
        Else
            UltimaModifLocal = My.Computer.FileSystem.GetFileInfo(Application.StartupPath + "\bases\thilan.dbf").LastWriteTime
            UltimaModifServer = My.Computer.FileSystem.GetFileInfo("\\192.168.0.12\u\hilamar\sto\thilan.dbf").LastWriteTime
            If UltimaModifLocal < UltimaModifServer Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath + "\bases\thilan.dbf")
                File.Copy("\\192.168.0.12\u\hilamar\sto\thilanvb.dbf", Application.StartupPath + "\bases\thilan.dbf")
            End If
        End If
        Threading.Thread.Sleep(1000)

        FormProgre.lblEstado.Text = "Copiando Tops Tintorería ..."
        FormProgre.CantProg = FormProgre.CantProg + 1
        FormProgre.Actualizar()

        If Not File.Exists(Application.StartupPath + "\bases\ttinto.dbf") Then
            File.Copy("\\192.168.0.12\u\hilamar\sto\ttintovb.dbf", Application.StartupPath + "\bases\ttinto.dbf", True)
        Else
            UltimaModifLocal = My.Computer.FileSystem.GetFileInfo(Application.StartupPath + "\bases\ttinto.dbf").LastWriteTime
            UltimaModifServer = My.Computer.FileSystem.GetFileInfo("\\192.168.0.12\u\hilamar\sto\ttinto.dbf").LastWriteTime
            If UltimaModifLocal < UltimaModifServer Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath + "\bases\ttinto.dbf")
                File.Copy("\\192.168.0.12\u\hilamar\sto\ttintovb.dbf", Application.StartupPath + "\bases\ttinto.dbf")
            End If
        End If
        Threading.Thread.Sleep(1000)

        FormProgre.lblEstado.Text = "Copiando Merino Hilandería ..."
        FormProgre.CantProg = FormProgre.CantProg + 1
        FormProgre.Actualizar()

        If Not File.Exists(Application.StartupPath + "\bases\topcar.dbf") Then
            File.Copy("\\192.168.0.12\u\hilamar\sto\topcarvb.dbf", Application.StartupPath + "\bases\topcar.dbf", True)
        Else
            UltimaModifLocal = My.Computer.FileSystem.GetFileInfo(Application.StartupPath + "\bases\topcar.dbf").LastWriteTime
            UltimaModifServer = My.Computer.FileSystem.GetFileInfo("\\192.168.0.12\u\hilamar\sto\topcar.dbf").LastWriteTime
            If UltimaModifLocal < UltimaModifServer Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath + "\bases\topcar.dbf")
                File.Copy("\\192.168.0.12\u\hilamar\sto\topcarvb.dbf", Application.StartupPath + "\bases\topcar.dbf")
            End If
        End If
        Threading.Thread.Sleep(1000)

        FormProgre.lblEstado.Text = "Copiando Merino Tintorería ..."
        FormProgre.CantProg = FormProgre.CantProg + 1
        FormProgre.Actualizar()

        If Not File.Exists(Application.StartupPath + "\bases\topcar1.dbf") Then
            File.Copy("\\192.168.0.12\u\hilamar\sto\topcar1vb.dbf", Application.StartupPath + "\bases\topcar1.dbf", True)
        Else
            UltimaModifLocal = My.Computer.FileSystem.GetFileInfo(Application.StartupPath + "\bases\topcar1.dbf").LastWriteTime
            UltimaModifServer = My.Computer.FileSystem.GetFileInfo("\\192.168.0.12\u\hilamar\sto\topcar1.dbf").LastWriteTime
            If UltimaModifLocal < UltimaModifServer Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath + "\bases\topcar1.dbf")
                File.Copy("\\192.168.0.12\u\hilamar\sto\topcar1vb.dbf", Application.StartupPath + "\bases\topcar1.dbf")
            End If
        End If
        Threading.Thread.Sleep(1000)

        FormProgre.lblEstado.Text = "Copiando Bobinas Teñidos ..."
        FormProgre.CantProg = FormProgre.CantProg + 1
        FormProgre.Actualizar()

        If Not File.Exists(Application.StartupPath + "\bases\tbteni.dbf") Then
            File.Copy("\\192.168.0.12\u\hilamar\sto\tbtenivb.dbf", Application.StartupPath + "\bases\tbteni.dbf", True)
        Else
            UltimaModifLocal = My.Computer.FileSystem.GetFileInfo(Application.StartupPath + "\bases\tbteni.dbf").LastWriteTime
            UltimaModifServer = My.Computer.FileSystem.GetFileInfo("\\192.168.0.12\u\hilamar\sto\tbteni.dbf").LastWriteTime
            If UltimaModifLocal < UltimaModifServer Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath + "\bases\tbteni.dbf")
                File.Copy("\\192.168.0.12\u\hilamar\sto\tbtenivb.dbf", Application.StartupPath + "\bases\tbteni.dbf")
            End If
        End If
        Threading.Thread.Sleep(1000)

        FormProgre.lblEstado.Text = "Copiando Acrílico ..."
        FormProgre.CantProg = FormProgre.CantProg + 1
        FormProgre.Actualizar()

        If Not File.Exists(Application.StartupPath + "\bases\acrilico.dbf") Then
            File.Copy("\\192.168.0.12\u\hilamar\sto\acrilicovb.dbf", Application.StartupPath + "\bases\acrilico.dbf", True)
        Else
            UltimaModifLocal = My.Computer.FileSystem.GetFileInfo(Application.StartupPath + "\bases\acrilico.dbf").LastWriteTime
            UltimaModifServer = My.Computer.FileSystem.GetFileInfo("\\192.168.0.12\u\hilamar\sto\acrilico.dbf").LastWriteTime
            If UltimaModifLocal < UltimaModifServer Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath + "\bases\acrilico.dbf")
                File.Copy("\\192.168.0.12\u\hilamar\sto\acrilicovb.dbf", Application.StartupPath + "\bases\acrilico.dbf")
            End If
        End If
        Threading.Thread.Sleep(1000)

        FormProgre.lblEstado.Text = "Copiando Algodón ..."
        FormProgre.CantProg = FormProgre.CantProg + 1
        FormProgre.Actualizar()

        If Not File.Exists(Application.StartupPath + "\bases\algodon.dbf") Then
            File.Copy("\\192.168.0.12\u\hilamar\sto\algodonvb.dbf", Application.StartupPath + "\bases\algodon.dbf", True)
        Else
            UltimaModifLocal = My.Computer.FileSystem.GetFileInfo(Application.StartupPath + "\bases\algodon.dbf").LastWriteTime
            UltimaModifServer = My.Computer.FileSystem.GetFileInfo("\\192.168.0.12\u\hilamar\sto\algodon.dbf").LastWriteTime
            If UltimaModifLocal < UltimaModifServer Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath + "\bases\algodon.dbf")
                File.Copy("\\192.168.0.12\u\hilamar\sto\algodonvb.dbf", Application.StartupPath + "\bases\algodon.dbf")
            End If
        End If
        Threading.Thread.Sleep(1000)

        FormProgre.lblEstado.Text = "Copiando Viscosa ..."
        FormProgre.CantProg = FormProgre.CantProg + 1
        FormProgre.Actualizar()

        If Not File.Exists(Application.StartupPath + "\bases\viscosa.dbf") Then
            File.Copy("\\192.168.0.12\u\hilamar\sto\viscosavb.dbf", Application.StartupPath + "\bases\viscosa.dbf", True)
        Else
            UltimaModifLocal = My.Computer.FileSystem.GetFileInfo(Application.StartupPath + "\bases\viscosa.dbf").LastWriteTime
            UltimaModifServer = My.Computer.FileSystem.GetFileInfo("\\192.168.0.12\u\hilamar\sto\viscosa.dbf").LastWriteTime
            If UltimaModifLocal < UltimaModifServer Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath + "\bases\viscosa.dbf")
                File.Copy("\\192.168.0.12\u\hilamar\sto\viscosavb.dbf", Application.StartupPath + "\bases\viscosa.dbf")
            End If
        End If
        Threading.Thread.Sleep(1000)

        FormProgre.lblEstado.Text = "Copiando Angora ..."
        FormProgre.CantProg = FormProgre.CantProg + 1
        FormProgre.Actualizar()

        If Not File.Exists(Application.StartupPath + "\bases\angora.dbf") Then
            File.Copy("\\192.168.0.12\u\hilamar\sto\angoravb.dbf", Application.StartupPath + "\bases\angora.dbf", True)
        Else
            UltimaModifLocal = My.Computer.FileSystem.GetFileInfo(Application.StartupPath + "\bases\angora.dbf").LastWriteTime
            UltimaModifServer = My.Computer.FileSystem.GetFileInfo("\\192.168.0.12\u\hilamar\sto\angora.dbf").LastWriteTime
            If UltimaModifLocal < UltimaModifServer Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath + "\bases\angora.dbf")
                File.Copy("\\192.168.0.12\u\hilamar\sto\angoravb.dbf", Application.StartupPath + "\bases\angora.dbf")
            End If
        End If
        Threading.Thread.Sleep(1000)

        FormProgre.lblEstado.Text = "Copiando Flanez ..."
        FormProgre.CantProg = FormProgre.CantProg + 1
        FormProgre.Actualizar()

        If Not File.Exists(Application.StartupPath + "\bases\flandez.dbf") Then
            File.Copy("\\192.168.0.12\u\hilamar\sto\flandezvb.dbf", Application.StartupPath + "\bases\flandez.dbf", True)
        Else
            UltimaModifLocal = My.Computer.FileSystem.GetFileInfo(Application.StartupPath + "\bases\flandez.dbf").LastWriteTime
            UltimaModifServer = My.Computer.FileSystem.GetFileInfo("\\192.168.0.12\u\hilamar\sto\flandez.dbf").LastWriteTime
            If UltimaModifLocal < UltimaModifServer Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath + "\bases\flandez.dbf")
                File.Copy("\\192.168.0.12\u\hilamar\sto\flandezvb.dbf", Application.StartupPath + "\bases\flandez.dbf")
            End If
        End If
        Threading.Thread.Sleep(1000)

        FormProgre.lblEstado.Text = "Copiando Nylon ..."
        FormProgre.CantProg = FormProgre.CantProg + 1
        FormProgre.Actualizar()

        If Not File.Exists(Application.StartupPath + "\bases\nylon.dbf") Then
            File.Copy("\\192.168.0.12\u\hilamar\sto\nylonvb.dbf", Application.StartupPath + "\bases\nylon.dbf", True)
        Else
            UltimaModifLocal = My.Computer.FileSystem.GetFileInfo(Application.StartupPath + "\bases\nylon.dbf").LastWriteTime
            UltimaModifServer = My.Computer.FileSystem.GetFileInfo("\\192.168.0.12\u\hilamar\sto\nylon.dbf").LastWriteTime
            If UltimaModifLocal < UltimaModifServer Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath + "\bases\nylon.dbf")
                File.Copy("\\192.168.0.12\u\hilamar\sto\nylonvb.dbf", Application.StartupPath + "\bases\nylon.dbf")
            End If
        End If
        Threading.Thread.Sleep(1000)

        FormProgre.lblEstado.Text = "Copiando Poliamida ..."
        FormProgre.CantProg = FormProgre.CantProg + 1
        FormProgre.Actualizar()

        If Not File.Exists(Application.StartupPath + "\bases\polia.dbf") Then
            File.Copy("\\192.168.0.12\u\hilamar\sto\poliavb.dbf", Application.StartupPath + "\bases\polia.dbf", True)
        Else
            UltimaModifLocal = My.Computer.FileSystem.GetFileInfo(Application.StartupPath + "\bases\polia.dbf").LastWriteTime
            UltimaModifServer = My.Computer.FileSystem.GetFileInfo("\\192.168.0.12\u\hilamar\sto\polia.dbf").LastWriteTime
            If UltimaModifLocal < UltimaModifServer Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath + "\bases\polia.dbf")
                File.Copy("\\192.168.0.12\u\hilamar\sto\poliavb.dbf", Application.StartupPath + "\bases\polia.dbf")
            End If
        End If
        Threading.Thread.Sleep(1000)

        FormProgre.lblEstado.Text = "Copiando Polyester ..."
        FormProgre.CantProg = FormProgre.CantProg + 1
        FormProgre.Actualizar()

        If Not File.Exists(Application.StartupPath + "\bases\poly.dbf") Then
            File.Copy("\\192.168.0.12\u\hilamar\sto\polyvb.dbf", Application.StartupPath + "\bases\poly.dbf", True)
        Else
            UltimaModifLocal = My.Computer.FileSystem.GetFileInfo(Application.StartupPath + "\bases\poly.dbf").LastWriteTime
            UltimaModifServer = My.Computer.FileSystem.GetFileInfo("\\192.168.0.12\u\hilamar\sto\poly.dbf").LastWriteTime
            If UltimaModifLocal < UltimaModifServer Then
                My.Computer.FileSystem.DeleteFile(Application.StartupPath + "\bases\poly.dbf")
                File.Copy("\\192.168.0.12\u\hilamar\sto\polyvb.dbf", Application.StartupPath + "\bases\poly.dbf")
            End If
        End If
        Threading.Thread.Sleep(1000)

        FormProgre.Close()

        CopiarDatosMateriaPrimaUnix = True
        Exit Function
ErrCopiarPartidasUnix:
        CopiarDatosMateriaPrimaUnix = False
    End Function

    Public Function ArtProdDatosDePlanilla(IdPlanilla As String, Optional ByRef CodArticulo As String = "", Optional ByRef Color As String = "", Optional ByRef Partida As String = "") As String
        On Error GoTo ErrDescripcionCodigo
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr, Tipo As String

        Tipo = ""

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT C.Descripcion,P.Articulo,P.Color,P.Partida FROM PrendasArtProdPlanillas P inner join PrendasArtProdCategorias C on P.IdCategoria=C.Id WHERE P.Id= " + IdPlanilla
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                If Strings.InStr(Reader.Item("Descripcion").ToString, "STOLL", CompareMethod.Text) > 0 Then
                    Tipo = "STOLL"
                Else
                    Tipo = "SHIMA"
                End If
                CodArticulo = Reader.Item("Articulo").ToString
                Color = Reader.Item("Color").ToString
                Partida = Reader.Item("Partida").ToString
            End If
        End If

        ArtProdDatosDePlanilla = Tipo

        Exit Function
ErrDescripcionCodigo:
        ArtProdDatosDePlanilla = ""
    End Function


    '***********************************************************************************************************************************************************
    '**************************************GLOBALES TEXTILANA***************************************************************************************************
    '***********************************************************************************************************************************************************

    Public Function NroMaxRemitoBas(Optional ByVal NroRemitoDesde As Integer = 0, Optional ByVal NroRemitoHasta As Integer = 0) As Integer
        On Error GoTo ErrNroMaxRemitoBas
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        NroMaxRemitoBas = 0

        If cConexionBAS.SQLConn.State <> ConnectionState.Open Then ReConectar("BAS")
        'Por qué 205.000? Porque hay remitos con el número 209000...

        If NroRemitoDesde = 0 Or NroRemitoHasta = 0 Then
            sStr = "SELECT MAX(NUMERO) AS MAXIMO FROM TRANSAC WHERE TALONARIO = 9726 AND CODCMP = 'EE' AND NUMERO < 500000 and NROTRANSELIM is null"
            Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows() Then
                If Reader.Read() Then
                    If Not IsDBNull(Reader.Item("MAXIMO")) Then
                        NroMaxRemitoBas = Reader.Item("MAXIMO").ToString
                    End If
                End If
            End If
        Else
            sStr = "SELECT NUMERO FROM TRANSAC WHERE TALONARIO = 9726 AND CODCMP = 'EE' AND NUMERO < 500000 and NROTRANSELIM is null "
            sStr = sStr + "AND (NUMERO >= " + NroRemitoDesde.ToString + " AND NUMERO <= " + NroRemitoHasta.ToString + ") ORDER BY NUMERO"
            Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
            Reader = Command.ExecuteReader()
            Do While Reader.HasRows()
                Do While Reader.Read()
                    If Not IsDBNull(Reader.Item("NUMERO")) Then
                        NroMaxRemitoBas = Reader.Item("NUMERO").ToString
                    End If
                Loop
                Reader.NextResult()
            Loop
            If NroMaxRemitoBas = 0 Then NroMaxRemitoBas = NroRemitoDesde.ToString
        End If

        Exit Function
ErrNroMaxRemitoBas:
        NroMaxRemitoBas = 0
    End Function

    Public Function NroTransaccionFacturaBAS(ByVal Letra As String, ByVal Prefijo As Integer, ByVal Numero As Integer) As Integer
        On Error GoTo ErrNroTransaccionFacturaBAS
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr, Comp As String
        NroTransaccionFacturaBAS = 0

        Comp = "F" + Letra.ToString

        If cConexionBAS.SQLConn.State <> ConnectionState.Open Then ReConectar("BAS")

        sStr = "SELECT NROTRANS FROM TRANSAC WHERE PREFIJO = " + Prefijo.ToString + " AND NUMERO = " + Numero.ToString + " AND CODCMP = '" + Comp.ToString + "' AND NROTRANSELIM IS NULL"
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                NroTransaccionFacturaBAS = Reader.Item("NROTRANS").ToString
            End If
        End If

        Exit Function
ErrNroTransaccionFacturaBAS:
        NroTransaccionFacturaBAS = 0
    End Function

    Public Sub DatosCliente(ByVal NroProforma As String, ByVal Prefijo As String, ByRef Nombre As String, Optional ByRef Direccion As String = "", Optional ByRef CUIT As String = "", Optional ByRef Localidad As String = "", Optional ByRef Provincia As String = "", Optional ByRef CodPos As String = "", Optional ByRef Telefono As String = "", Optional ByRef Obs As String = "")
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr, CodCliente As String

        Nombre = ""
        Direccion = ""
        CUIT = ""
        CodCliente = ""

        If cConexionBAS.SQLConn.State <> ConnectionState.Open Then ReConectar("BAS")

        sStr = "SELECT TOP 1 T.CODCTACTE AS CODCLIENTE FROM TRANSAC T LEFT JOIN MVSITEMS M ON T.NROTRANS = M.NROTRANS LEFT JOIN dbo.VistaEntregaTexPrincipal V ON T.CODCTACTE = V.CODCTACTE "
        sStr = sStr + "WHERE T.CODCMP='PV' AND T.PREFIJO=" + Prefijo.ToString + " AND "
        sStr = sStr + "T.NUMERO = " + NroProforma.ToString + " And T.NROTRANSELIM Is Null"
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                CodCliente = Reader.Item("CODCLIENTE").ToString
            End If
        End If

        If CodCliente = "" Then 'No está en BAS, entonces lo busco en AdminPedidos (página)
            If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
            sStr = "SELECT DNI FROM AdminPedidos WHERE NroPedido = " + NroProforma.ToString
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read() Then
                    CodCliente = Reader.Item("DNI").ToString
                End If
            End If
            If CodCliente = "" Then
                MensajeAtencion("No se encontró el Cliente de la Proforma " + NroProforma.ToString + " en la base de datos.")
                Exit Sub
            End If
        End If

        'Primero levanto la dirección del DC
        'Los clientes que tienen domicilio cargado usan esto
        If cConexionBAS.SQLConn.State <> ConnectionState.Open Then ReConectar("BAS")

        sStr = "SELECT NOMBRE, ENTREGA, TELEFONO, NRODOC1, XXXCODPRV FROM CTACTES C INNER JOIN CTACTESDOMICILIOS CT ON C.CODCTACTE = CT.CODCTACTE "
        sStr = sStr + "INNER JOIN DOMICILIOS D ON CT.IDDOMICILIO = D.IDDOMICILIO "
        sStr = sStr + "WHERE CT.HABILITADO =1 AND C.CODCTACTE = '" + CodCliente.ToString + "'"
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                Nombre = Reader.Item("NOMBRE").ToString
                DatosEntrega(Reader.Item("ENTREGA").ToString, Direccion, CodPos, Localidad, Obs)
                CUIT = Reader.Item("NRODOC1").ToString
                Telefono = Reader.Item("TELEFONO").ToString
                If Not IsDBNull(Reader.Item("XXXCODPRV")) Then Provincia = NombreProvincia(Reader.Item("XXXCODPRV")).ToString
            End If
        End If

        If Direccion = "" Or Localidad = "" Or CodPos = "" Then
            'Los clientes que tienen domicilio cargado usan esto
            If cConexionBAS.SQLConn.State <> ConnectionState.Open Then ReConectar("BAS")
            sStr = "SELECT NOMBRE, XXXDOMICILIO, XXXLOCALIDAD, XXXCODPOS, DESCRIPCION, NRODOC1, XXXTELEFONO FROM CTACTES C INNER JOIN PROVINCIAS P ON XXXCODPRV = P.CODPRV "
            sStr = sStr + "WHERE CODCTACTE = '" + CodCliente.ToString + "'"
            Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read() Then
                    Nombre = Reader.Item("Nombre").ToString
                    Direccion = Reader.Item("XXXDOMICILIO").ToString
                    Localidad = Reader.Item("XXXLOCALIDAD").ToString
                    CodPos = Reader.Item("XXXCODPOS").ToString
                    CUIT = Reader.Item("NRODOC1").ToString
                    Provincia = Reader.Item("DESCRIPCION").ToString
                    Telefono = Reader.Item("XXXTELEFONO").ToString
                End If
            End If
        End If

        If Nombre = "" Then
            'Los clientes que NO tienen el domicilio cargado usan esto
            sStr = "SELECT TOP 1 DOMICILIO, LOCALIDAD, CODPOS, P.DESCRIPCION, NOMBRE, OBSERVACION "
            sStr = sStr + "FROM TRANSAC T LEFT JOIN MVSITEMS M ON T.NROTRANS = M.NROTRANS LEFT JOIN dbo.VistaEntregaTexPrincipal V ON T.CODCTACTE = V.CODCTACTE "
            sStr = sStr + "INNER JOIN PROVINCIAS P ON T.CODPRV = P.CODPRV "
            sStr = sStr + "WHERE T.CODCMP='PV' AND T.PREFIJO=" + Prefijo.ToString + " AND T.NUMERO = " + NroProforma.ToString + " And T.NROTRANSELIM Is Null"
            Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read() Then
                    Nombre = Reader.Item("Nombre").ToString
                    Direccion = Reader.Item("DOMICILIO").ToString
                    Localidad = Reader.Item("LOCALIDAD").ToString
                    CodPos = Reader.Item("CODPOS").ToString
                    CUIT = Reader.Item("OBSERVACION").ToString
                    Provincia = Reader.Item("DESCRIPCION").ToString
                End If
            End If
        End If


    End Sub

    Public Sub DatosEntrega(ByVal Datos As String, ByRef Domicilio As String, ByRef CodPos As String, ByRef Localidad As String, ByRef Obs As String)
        Dim PosIn, PosFi As Integer
        Dim Temp As String
        Temp = Datos
        If Strings.Left(Datos, 20) = "Bº 200 VIV. MZA 27, " Then
            Domicilio = "CALLE MARTINIANO GOMEZ S/Nº  KIOSCO MARISA"
            Obs = "Bº 200 VIV. MZA 27, PARC. 12, CALLE MARTINIANO GOMEZ S/Nº  KIOSCO MARISA"
            Localidad = "PUERTO TIROL"
            CodPos = "3505"
            Exit Sub
        ElseIf Strings.Left(Datos, 37) = "SAN VICENTE DE PAUL 831 CASI AYACUCHO" Then
            Domicilio = "SAN VICENTE DE PAUL 831 CASI AYACUCHO"
            Obs = "RECIBE NENITO MENA 0298 422591  TE 0223 447961 / 494371"
            Localidad = "CLORINDA"
            CodPos = "3610"
            Exit Sub
        ElseIf Strings.Left(Datos, 47) = "JOSE L. TERRA N.2526  11800-MONTEVIDEO  URUGUAY" Then
            Domicilio = "JOSE L. TERRA N.2526"
            Obs = "URUGUAY"
            Localidad = "MONTEVIDEO"
            CodPos = "11800"
            Exit Sub
        End If
        PosIn = InStr(Datos, Environment.NewLine, CompareMethod.Text)
        If PosIn > 0 Then
            Domicilio = Strings.Left(Datos, PosIn)
            Datos = Strings.Right(Datos, Len(Datos) - PosIn)
            PosIn = InStr(Datos, Environment.NewLine, CompareMethod.Text)
            If PosIn > 0 Then
                Localidad = Strings.Left(Datos, PosIn)
                Datos = Trim(Strings.Right(Datos, Len(Datos) - PosIn))
                PosIn = InStr(Localidad, "(", CompareMethod.Text)
                PosFi = InStr(Localidad, ")", CompareMethod.Text)
                If PosIn > 0 And PosFi > 0 Then
                    Temp = Strings.Mid(Localidad, PosIn + 1, PosFi - PosIn - 1)
                    If IsNumeric(Temp) Then
                        CodPos = Temp
                        Datos = Trim(Datos)
                        PosIn = InStr(Datos, Environment.NewLine, CompareMethod.Text)
                        If PosIn > 0 Then
                            Localidad = Trim(Localidad)
                            PosFi = InStr(Localidad, ")", CompareMethod.Text)
                            If PosFi > 0 Then
                                If PosFi >= Len(Localidad) - 2 Then
                                    Localidad = Strings.Left(Localidad, PosIn)
                                Else
                                    Localidad = Strings.Right(Localidad, Len(Localidad) - PosFi)
                                End If

                            Else
                                Localidad = Strings.Left(Datos, PosIn)
                            End If

                            Datos = Strings.Right(Datos, Len(Datos) - PosIn)
                            Obs = Trim(Datos)
                        Else
                            If Localidad <> "" Then
                                PosFi = InStr(Localidad, ")", CompareMethod.Text)
                                PosIn = InStr(Localidad, "(", CompareMethod.Text)
                                If PosIn > 12 Then
                                    Localidad = Strings.Left(Localidad, PosIn)
                                    Obs = Trim(Datos)
                                ElseIf PosFi > 0 Then
                                    Localidad = Strings.Right(Localidad, Len(Localidad) - PosFi)
                                    Obs = Trim(Datos)
                                End If
                            Else
                                Localidad = Trim(Datos)
                            End If
                        End If
                    Else
                        Domicilio = Domicilio + " " + Localidad
                        Localidad = Strings.Left(Datos, PosFi)
                        PosIn = InStr(Datos, "(", CompareMethod.Text)
                        PosFi = InStr(Datos, ")", CompareMethod.Text)
                        If PosIn > 0 And PosFi > 0 Then
                            CodPos = Strings.Mid(Datos, PosIn + 1, PosFi - PosIn - 1)
                        End If
                        Datos = Strings.Right(Datos, Len(Datos) - PosFi)
                        Localidad = Datos
                    End If
                End If
            Else
                If (Localidad = "" And CodPos = "") Or Not IsNumeric(CodPos) Then
                    Datos = Temp
                    If MasDeUnParentesis(Datos) Then
                        PosIn = InStr(Datos, Environment.NewLine, CompareMethod.Text)
                        Domicilio = Strings.Left(Datos, PosIn)
                        Datos = Strings.Right(Datos, Len(Datos) - PosIn)
                        PosIn = InStr(Datos, "(", CompareMethod.Text)
                        PosFi = InStr(Datos, ")", CompareMethod.Text)
                        If PosIn > 0 And PosFi > 0 Then
                            CodPos = Strings.Mid(Datos, PosIn + 1, PosFi - PosIn - 1)
                            Localidad = Strings.Right(Datos, Len(Datos) - PosFi)
                        End If
                    Else
                        If Len(Trim(Datos)) > 2 Then
                            PosIn = InStr(Datos, "(", CompareMethod.Text)
                            PosFi = InStr(Datos, ")", CompareMethod.Text)
                            Domicilio = Strings.Left(Datos, PosIn)
                            If PosIn > 0 And PosFi > 0 Then
                                CodPos = Strings.Mid(Datos, PosIn + 1, PosFi - PosIn - 1)
                                Localidad = Strings.Right(Datos, Len(Datos) - PosFi)
                            End If
                        End If
                    End If
                End If
            End If
            If CodPos = "" Or Not IsNumeric(CodPos) Then
                If InStr(Localidad, "(", CompareMethod.Text) > 0 Then
                    If Localidad <> "" Then
                        Localidad = Trim(Localidad)
                        Localidad = RemoverEspacios(Localidad)
                        If InStr(Localidad, "-", CompareMethod.Text) > 0 Then
                            CodPos = Strings.Left(Localidad, 4)
                        Else
                            CodPos = Strings.Left(Localidad, 5)
                        End If

                        If IsNumeric(CodPos) Then
                            Localidad = Strings.Right(Localidad, Len(Localidad) - 5)
                            If Strings.Left(Localidad, 1) = "-" Then
                                Localidad = Strings.Right(Localidad, Len(Localidad) - 1)
                            End If
                        Else
                            CodPos = ""
                        End If

                    End If
                Else
                    PosIn = InStr(Datos, "(", CompareMethod.Text)
                    PosFi = InStr(Datos, ")", CompareMethod.Text)
                    If PosIn > 0 And PosFi > 0 Then
                        CodPos = Strings.Mid(Datos, PosIn + 1, PosFi - PosIn - 1)
                        Localidad = Strings.Right(Datos, Len(Datos) - PosFi)
                    End If
                    If CodPos = "" Then
                        PosIn = InStr(Domicilio, "(", CompareMethod.Text)
                        PosFi = InStr(Domicilio, ")", CompareMethod.Text)
                        If PosIn > 0 And PosFi > 0 Then
                            CodPos = Strings.Mid(Domicilio, PosIn + 1, PosFi - PosIn - 1)
                            If Not IsNumeric(CodPos) Then
                                Obs = CodPos
                                CodPos = ""
                                Datos = Strings.Trim(Strings.Right(Domicilio, Len(Domicilio) - PosFi))
                                Domicilio = Strings.Left(Domicilio, PosIn - 1)
                            End If
                        End If
                    End If
                    If CodPos = "" And InStr(Datos, "(", CompareMethod.Text) > 0 Then
                        PosIn = InStr(Datos, "(", CompareMethod.Text)
                        PosFi = InStr(Datos, ")", CompareMethod.Text)
                        CodPos = Strings.Mid(Datos, PosIn + 1, PosFi - PosIn - 1)
                        Localidad = Strings.Right(Datos, Len(Datos) - PosFi)
                    End If
                    If CodPos = "" Then 'No está entre paréntesis el CP
                        Localidad = Trim(Localidad)
                        CodPos = Strings.Trim(Strings.Left(Localidad, 5))
                    End If
                End If
            Else

            End If
        Else
            If Domicilio = "" Or CodPos = "" Or Localidad = "" Then
                DatosEntregaViejo(Datos, Domicilio, CodPos, Localidad, Obs)
            End If
        End If

    End Sub

    Public Sub DatosEntregaViejo(ByVal Datos, ByRef Domicilio, ByRef CodPos, ByRef Localidad, ByRef Obs)
        Dim PosIn, PosFi As Integer
        Dim Temp As String

        If MasDeUnParentesis(Datos) Then
            If InStr(Datos, "        ", CompareMethod.Text) > 0 Then
                PosIn = InStr(Datos, "        ", CompareMethod.Text)
                Domicilio = Strings.Left(Datos, PosIn - 1)
                Datos = Strings.Right(Datos, Len(Datos) - PosIn)
                PosIn = InStr(Datos, "(", CompareMethod.Text)
                PosFi = InStr(Datos, ")", CompareMethod.Text)
                Temp = Strings.Mid(Datos, PosIn + 1, PosFi - PosIn - 1)
                If IsNumeric(Temp) Then
                    CodPos = Temp
                    Localidad = Trim(Strings.Left(Datos, PosIn))
                Else
                    Localidad = Strings.Left(Datos, PosFi)
                    Datos = Strings.Right(Datos, Len(Datos) - PosFi)
                    PosIn = InStr(Datos, "(", CompareMethod.Text)
                    PosFi = InStr(Datos, ")", CompareMethod.Text)
                    If PosIn > 0 And PosFi > 0 Then
                        CodPos = Strings.Mid(Datos, PosIn + 1, PosFi - PosIn - 1)
                    End If
                End If
            End If
        Else
            PosIn = InStr(Datos, "(", CompareMethod.Text)
            PosFi = InStr(Datos, ")", CompareMethod.Text)
            If PosIn > 0 And PosFi > 0 Then
                Domicilio = Strings.Left(Datos, PosIn - 1)
                CodPos = Strings.Mid(Datos, PosIn + 1, PosFi - PosIn - 1)
                Localidad = Strings.Right(Datos, Len(Datos) - PosFi)
                If InStr(Domicilio, "        ", CompareMethod.Text) > 0 Then
                    Temp = Domicilio
                    PosIn = InStr(Domicilio, "        ", CompareMethod.Text)
                    Domicilio = Trim(Strings.Left(Domicilio, PosIn))
                    Localidad = Trim(Strings.Right(Temp, Len(Temp) - PosIn))
                    If Len(Localidad) < 4 Then
                        Localidad = Trim(Strings.Right(Datos, Len(Datos) - PosFi))
                    End If
                ElseIf InStr(Localidad, "        ", CompareMethod.Text) > 0 Then
                    Temp = RTrim(Localidad)
                    PosIn = InStr(Temp, Environment.NewLine, CompareMethod.Text)
                    Localidad = Strings.Left(Localidad, PosIn)
                End If
                Domicilio = Trim(Strings.Left(Domicilio, 40))
                Localidad = Trim(Strings.Left(Localidad, 40))
            End If
        End If

    End Sub

    Public Function NombreProvincia(ByVal CodPrv As String) As String
        On Error GoTo ErrNombreProvincia
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        NombreProvincia = ""

        If cConexionBAS.SQLConn.State <> ConnectionState.Open Then ReConectar("BAS")

        sStr = "SELECT Descripcion "
        sStr = sStr & "FROM PROVINCIAS WHERE CodPrv = '" + CodPrv.ToString + "'"
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                NombreProvincia = Reader.Item("Descripcion")
            End If
        End If
        Exit Function
ErrNombreProvincia:
        NombreProvincia = ""
        MensajeCritico("Error al recuperar el nombre de la provincia.")
    End Function

    Public Function CodigoProvincia(ByVal NombrePrv As String) As String
        On Error GoTo ErrCodigoProvincia
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        CodigoProvincia = ""

        If cConexionBAS.SQLConn.State <> ConnectionState.Open Then ReConectar("BAS")

        sStr = "SELECT CodPrv FROM PROVINCIAS WHERE Descripcion like '%" + NombrePrv.ToString + "%'"
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                CodigoProvincia = Reader.Item("CodPrv").ToString
            End If
        End If
        Exit Function
ErrCodigoProvincia:
        CodigoProvincia = ""
        MensajeCritico("Error al recuperar el código de la provincia.")
    End Function

    Public Function CodClientePedido(ByVal NroProforma As Integer, Optional ByVal Prefijo As Integer = 0) As String
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        CodClientePedido = ""

        If cConexionBAS.SQLConn.State <> ConnectionState.Open Then ReConectar("BAS")

        'Los clientes que NO tienen el domicilio cargado usan esto
        sStr = "SELECT TOP 1 T.CODCTACTE AS TCODCTACTE "
        sStr = sStr + "FROM TRANSAC T LEFT JOIN MVSITEMS M ON T.NROTRANS = M.NROTRANS LEFT JOIN dbo.VistaEntregaTexPrincipal V ON T.CODCTACTE = V.CODCTACTE "
        sStr = sStr + "INNER JOIN PROVINCIAS P ON T.CODPRV = P.CODPRV "
        sStr = sStr + "WHERE T.CODCMP='PV' AND T.NUMERO = " + NroProforma.ToString + " "
        If Prefijo <> 0 Then sStr = sStr + " AND T.Prefijo = " + Prefijo.ToString + " "
        sStr = sStr + "And T.NROTRANSELIM Is Null"
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                CodClientePedido = Reader.Item("TCODCTACTE").ToString
            End If
        End If

    End Function

    Public Function DireccionEntregaClienteBAS(ByVal CodCliente As String) As String
        On Error GoTo ErrDireccionEntregaClienteBAS
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        DireccionEntregaClienteBAS = ""

        If cConexionBAS.SQLConn.State <> ConnectionState.Open Then ReConectar("BAS")

        sStr = "SELECT ENTREGA FROM CTACTES C INNER JOIN CTACTESDOMICILIOS CT ON C.CODCTACTE = CT.CODCTACTE INNER JOIN DOMICILIOS D ON CT.IDDOMICILIO = D.IDDOMICILIO "
        sStr = sStr + "WHERE CT.HABILITADO =1 AND C.CODCTACTE = '" + CodCliente.ToString + "'"
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                DireccionEntregaClienteBAS = Reader.Item("ENTREGA").ToString
            End If
        End If

        Exit Function
ErrDireccionEntregaClienteBAS:
        DireccionEntregaClienteBAS = ""
    End Function

    Public Function CondicionIVACliente(ByVal CodCli As String, ByRef CondIva As String, ByRef DescCondIVA As String, Optional ByRef CUIT As String = "") As Boolean
        On Error GoTo ErrCondicionIVACliente
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        If cConexionBAS.SQLConn.State <> ConnectionState.Open Then ReConectar("BAS")
        CondicionIVACliente = False
        sStr = "SELECT C.CodTrat AS CODIVA, T.DESCRIPCION DESCIVA, C.NRODOC1 AS CUIT FROM CTACTES C INNER JOIN TRATIMP T ON C.CodTrat = T.CODTRAT WHERE C.CodCtaCte = '" + CodCli.ToString + "'"
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                CondIva = Reader.Item("CODIVA").ToString
                DescCondIVA = Reader.Item("DESCIVA").ToString
                CUIT = Reader.Item("CUIT").ToString
            End If
        End If
        CondicionIVACliente = True
        Exit Function
ErrCondicionIVACliente:
        CondicionIVACliente = False
        MensajeCritico("Error al recuperar el nombre del cliente.")
    End Function

    Public Function TransporteFactura(ByVal NroTrans As String) As String
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        TransporteFactura = ""

        If cConexionBAS.SQLConn.State <> ConnectionState.Open Then ReConectar("BAS")

        sStr = "SELECT * FROM TRANSAC T INNER JOIN MVSITEMS M ON T.NROTRANS = M.NROTRANS WHERE T.NROTRANS = " + NroTrans.ToString + " AND T.NROTRANSELIM IS NULL AND LEFT(M.CODITM,6) = 'DESP02'"
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                TransporteFactura = "FL01"
            End If
        End If

        sStr = "SELECT * FROM TRANSAC T INNER JOIN MVSITEMS M ON T.NROTRANS = M.NROTRANS WHERE T.NROTRANS = " + NroTrans.ToString + " AND T.NROTRANSELIM IS NULL AND LEFT(M.CODITM,6) = 'DESP03'"
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                TransporteFactura = "FL07"
            End If
        End If

        sStr = "SELECT * FROM TRANSAC T INNER JOIN MVSITEMS M ON T.NROTRANS = M.NROTRANS WHERE T.NROTRANS = " + NroTrans.ToString + " AND T.NROTRANSELIM IS NULL AND LEFT(M.CODITM,6) = 'DESP05'"
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                TransporteFactura = "FL58"
            End If
        End If

    End Function

    Public Function ExisteEtiquetaDelPedido(ByVal NroPedido As Long) As Boolean
        On Error GoTo ErrExisteEtiquetaDelPedido
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        ExisteEtiquetaDelPedido = False

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT * FROM Etiquetas WHERE NroPedido = " + NroPedido.ToString + " And Eliminado=0"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                ExisteEtiquetaDelPedido = True
            End If
        End If
        Exit Function
ErrExisteEtiquetaDelPedido:
        ExisteEtiquetaDelPedido = False
        MensajeCritico("Error al comprobar la Etiqueta del Pedido.")
    End Function

    Public Function ExisteFacturaBAS(ByVal Prefijo As Integer, ByVal Numero As Integer) As Boolean
        On Error GoTo ErrNroMaxRemitoBas
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        ExisteFacturaBAS = False

        If cConexionBAS.SQLConn.State <> ConnectionState.Open Then ReConectar("BAS")

        'Por qué 205.000? Porque hay remitos con el número 209000...
        sStr = "SELECT * FROM TRANSAC WHERE PREFIJO = " + Prefijo.ToString + " AND NUMERO = " + Numero.ToString
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                ExisteFacturaBAS = True
            End If
        End If

        Exit Function
ErrNroMaxRemitoBas:
        ExisteFacturaBAS = False
    End Function

    Public Function TieneRemitoRelacionadoBAS(ByVal Letra As String, ByVal Prefijo As String, ByVal NroFactura As String) As Boolean
        On Error GoTo ErrTieneRemitoRelacionadoBAS
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        TieneRemitoRelacionadoBAS = False

        If cConexionBAS.SQLConn.State <> ConnectionState.Open Then ReConectar("BAS")

        sStr = "SELECT DISTINCT T.NROTRANS, T.PREFIJO TPREFIJO, T.NUMERO TNUMERO, M.NROTRANS AS MNROTRANS FROM MVSITEMS M JOIN TRANSAC T ON M.REFTRANS = T.NROTRANS "
        sStr = sStr + "WHERE T.PREFIJO = " + Prefijo.ToString + " AND T.NUMERO = " + NroFactura.ToString + " AND T.CODCMP = 'F" + Letra.ToString + "' AND T.NROTRANSELIM IS NULL"
        'sStr = "SELECT NROTRANS, PREFIJO TPREFIJO, NUMERO TNUMERO FROM TRANSAC WHERE NROTRANS IN (SELECT REFTRANS FROM MVSITEMS WHERE REFTRANS = " + NroFactura.ToString + ") "
        'sStr = sStr + "AND PREFIJO = " + Letra.ToString + " AND NUMERO = " + NroFactura.ToString + " AND CODCMP = 'F" + Letra.ToString + "' AND NROTRANSELIM IS NULL"
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                If CodigoComprobanteNroTrans(Reader.Item("MNROTRANS")) = "EE" Then TieneRemitoRelacionadoBAS = True
            End If
        End If

        Exit Function
ErrTieneRemitoRelacionadoBAS:
        TieneRemitoRelacionadoBAS = False
    End Function

    Public Function CodigoComprobanteNroTrans(ByVal NroTrans As Integer) As String
        On Error GoTo ErrCodigoComprobanteNroTrans
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr, Comp As String

        CodigoComprobanteNroTrans = ""

        If cConexionBAS.SQLConn.State <> ConnectionState.Open Then ReConectar("BAS")

        sStr = "SELECT CODCMP FROM TRANSAC WHERE NROTRANS = " + NroTrans.ToString + " AND NROTRANSELIM IS NULL"
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                CodigoComprobanteNroTrans = Reader.Item("CODCMP").ToString
            End If
        End If

        Exit Function
ErrCodigoComprobanteNroTrans:
        CodigoComprobanteNroTrans = 0
    End Function

    Public Function ExistePedido(ByVal NroPedido As Long, Optional ByVal SinPrefijo As Boolean = False, Optional ByVal Prefijo As String = "", Optional ByRef DatoPrefijo As String = "") As Boolean
        On Error GoTo ErrExistePedido
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        ExistePedido = False

        If cConexionBAS.SQLConn.State <> ConnectionState.Open Then ReConectar("BAS")

        sStr = "SELECT T.PREFIJO AS TPREFIJO FROM TRANSAC T LEFT JOIN MVSITEMS M ON T.NROTRANS = M.NROTRANS LEFT JOIN dbo.VistaEntregaTexPrincipal V ON T.CODCTACTE = V.CODCTACTE "
        sStr = sStr + "WHERE T.CODCMP='PV' AND "
        If Not SinPrefijo Then
            sStr = sStr + "(T.PREFIJO=8000 OR T.PREFIJO=7000) AND "
        Else
            sStr = sStr + "T.PREFIJO = " + Prefijo.ToString + " AND "
        End If
        sStr = sStr + " T.NUMERO= " + NroPedido.ToString + " AND T.NROTRANSELIM Is Null "
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                DatoPrefijo = Reader.Item("TPREFIJO").ToString
                ExistePedido = True
            End If
        End If
        Exit Function
ErrExistePedido:
        ExistePedido = False
        MensajeCritico("Error al comprobar la existencia del Pedido.")
    End Function

    Public Function ExisteRemitoBAS(ByVal Prefijo As Integer, ByVal Numero As Integer) As Boolean
        On Error GoTo ErrExisteRemitoBAS
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        ExisteRemitoBAS = False

        If cConexionBAS.SQLConn.State <> ConnectionState.Open Then ReConectar("BAS")

        sStr = "SELECT * FROM TRANSAC WHERE PREFIJO = " + Prefijo.ToString + " AND NUMERO = " + Numero.ToString + " AND CODCMP = 'EE' AND NROTRANSELIM IS NULL"
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                ExisteRemitoBAS = True
            End If
        End If

        Exit Function
ErrExisteRemitoBAS:
        ExisteRemitoBAS = False
    End Function

    Public Function CodPrvCliente(ByVal CodCli As String) As String
        On Error GoTo ErrCodPrvCliente
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        CodPrvCliente = ""

        If cConexionBAS.SQLConn.State <> ConnectionState.Open Then ReConectar("BAS")

        sStr = "SELECT CodPrv FROM CTACTES C inner join CTACTESDOMICILIOS CD ON C.CODCTACTE = CD.CODCTACTE INNER JOIN DOMICILIOS D ON CD.IDDOMICILIO = D.IDDOMICILIO "
        sStr = sStr + "WHERE C.CodCtaCte = '" + CodCli.ToString + "'"
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                CodPrvCliente = Reader.Item("CodPrv")
            End If
        End If
        Exit Function
ErrCodPrvCliente:
        CodPrvCliente = ""
        MensajeCritico("Error al recuperar el código de la provincia del cliente.")
    End Function

    Public Function IDDomicilioBAS(ByVal CodCliente As String) As Integer
        On Error GoTo ErrIDDomicilioBAS
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        IDDomicilioBAS = 0

        If cConexionBAS.SQLConn.State <> ConnectionState.Open Then ReConectar("BAS")

        sStr = "SELECT IDDOMICILIO FROM CTACTES C INNER JOIN CTACTESDOMICILIOS CD ON C.CODCTACTE = CD.CODCTACTE WHERE C.CODCTACTE = '" + CodCliente.ToString + "'"
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                IDDomicilioBAS = Reader.Item("IDDOMICILIO").ToString
            End If
        End If

        Exit Function
ErrIDDomicilioBAS:
        IDDomicilioBAS = 0
    End Function

    Public Function MAXNroTransBAS_para_Remitir(ByVal Usuario As String) As Integer
        On Error GoTo ErrMAXNroTransBAS
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        MAXNroTransBAS_para_Remitir = 0

        If cConexionBAS.SQLConn.State <> ConnectionState.Open Then ReConectar("BAS")

        sStr = "SELECT MAX(NROTRANS) AS MAXIMO FROM TRANSACREG WHERE USERNAME='" + Usuario + "'"
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                MAXNroTransBAS_para_Remitir = Reader.Item("MAXIMO").ToString
            End If
        End If

        Exit Function
ErrMAXNroTransBAS:
        MAXNroTransBAS_para_Remitir = 0
    End Function

    Public Function NroTransaccionRemitoBAS(ByVal Prefijo As Integer, ByVal Numero As Integer, Optional ByVal VerEliminado As Boolean = True) As Integer
        On Error GoTo ErrNroTransaccionRemitoBAS
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        NroTransaccionRemitoBAS = 0

        If cConexionBAS.SQLConn.State <> ConnectionState.Open Then ReConectar("BAS")

        sStr = "SELECT NROTRANS FROM TRANSAC WHERE PREFIJO = " + Prefijo.ToString + " AND NUMERO = " + Numero.ToString + " AND CODCMP = 'EE' AND NROTRANSELIM IS NULL"
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                NroTransaccionRemitoBAS = Reader.Item("NROTRANS").ToString
            End If
        End If

        Exit Function
ErrNroTransaccionRemitoBAS:
        NroTransaccionRemitoBAS = 0
    End Function

    Public Function CentroDistribucionAndreani(CodPos As Integer) As Integer
        On Error GoTo ErrCentroDistribucionAndreani
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        CentroDistribucionAndreani = 0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT Distrib FROM AndreaniPoblaciones WHERE CodPos = " + CodPos.ToString
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                CentroDistribucionAndreani = Reader.Item("Distrib").ToString
            End If
        End If

        Exit Function
ErrCentroDistribucionAndreani:
        CentroDistribucionAndreani = 0
        MensajeAtencion("Error al verificar si el Centro de Distribución de Andreani.")
    End Function

    Public Function NombreCliente(ByVal CodCli As String, Optional ByRef Telefono As String = "") As String
        On Error GoTo ErrNombreCliente
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        NombreCliente = ""

        If cConexionBAS.SQLConn.State <> ConnectionState.Open Then ReConectar("BAS")

        sStr = "SELECT NOMBRE, TELEFONO FROM CTACTES C INNER JOIN CTACTESDOMICILIOS CT ON C.CODCTACTE = CT.CODCTACTE "
        sStr = sStr + "INNER JOIN DOMICILIOS D ON CT.IDDOMICILIO = D.IDDOMICILIO "
        sStr = sStr + "WHERE C.CODCTACTE = '" + CodCli.ToString + "'"
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                NombreCliente = Trim(Reader.Item("Nombre")).ToString
                Telefono = Reader.Item("TELEFONO").ToString
            End If
        End If

        If NombreCliente = "" Then
            sStr = "SELECT NOMBRE, XXXTELEFONO FROM CTACTES WHERE CODCTACTE = '" + CodCli.ToString + "'"
            Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read() Then
                    NombreCliente = Reader.Item("NOMBRE")
                    Telefono = Reader.Item("XXXTELEFONO").ToString
                End If
            End If
        End If

        Exit Function
ErrNombreCliente:
        NombreCliente = ""
        MensajeCritico("Error al recuperar el nombre del cliente.")
    End Function

    Public Sub NroTransaccionProformaBAS(ByVal NroTransFactura As Integer, ByRef Prefijo As String, ByRef NroPedido As String)
        On Error GoTo ErrNroTransaccionProformaBAS
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        Prefijo = ""
        NroPedido = ""

        If cConexionBAS.SQLConn.State <> ConnectionState.Open Then ReConectar("BAS")

        sStr = "SELECT DISTINCT T.NROTRANS, T.PREFIJO TPREFIJO, T.NUMERO TNUMERO FROM MVSITEMS M JOIN TRANSAC T ON M.REFTRANS = T.NROTRANS "
        sStr = sStr + "WHERE M.NROTRANS = " + NroTransFactura.ToString + " AND T.NROTRANSELIM IS NULL"
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                Prefijo = Reader.Item("TPREFIJO").ToString
                NroPedido = Reader.Item("TNUMERO").ToString
            End If
        End If

        Exit Sub
ErrNroTransaccionProformaBAS:
        Prefijo = ""
        NroPedido = ""
    End Sub

    Public Function NroEnvioAlereti(ByVal NroPedido As Integer, ByRef CodPla As String, ByRef CodZona As String) As String
        On Error GoTo ErrNroEnvioAlereti
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        NroEnvioAlereti = "0"

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT * FROM Etiquetas WHERE NroPedido = " + NroPedido.ToString + " ORDER BY NroEnvio DESC"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                NroEnvioAlereti = Reader.Item("NroEnvio").ToString
            End If
        End If

        sStr = "SELECT Distrib, CodPla, Poblacion, ZonRep, AP.CodPos AS APCodPos FROM AndreaniPoblaciones AP INNER JOIN AndreaniPedidos AN ON AP.DelNom = AN.Poblacion AND AP.CodPos = AN.CodPos "
        sStr = sStr + "WHERE NroPedido = " + NroPedido.ToString
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                CodPla = CompletarCaracteresIzquierda(Reader.Item("CodPla"), 3, "0").ToString
                CodZona = CompletarCaracteresIzquierda(Reader.Item("ZonRep"), 3, "0").ToString
            End If
        End If

        Exit Function
ErrNroEnvioAlereti:
        NroEnvioAlereti = "0"
        MensajeCritico("Error al recuperar el número de envío del sistema Alereti.")
    End Function

    Public Function NroEnvioNOANDREANI(ByVal NroPedido As Integer) As String
        On Error GoTo ErrNroEnvioNOANDREANI
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        NroEnvioNOANDREANI = "0"

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "select top 1 LEFT(codigo,len(codigo)-3) as codigo FROM DetEtiquetas WHERE NroPedido = " + NroPedido.ToString + " ORDER BY codigo DESC"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                NroEnvioNOANDREANI = Reader.Item("codigo").ToString
            End If
        End If

        Exit Function
ErrNroEnvioNOANDREANI:
        NroEnvioNOANDREANI = "0"
        MensajeCritico("Error al recuperar el código de barras para el remito.")
    End Function

    Public Function NumerodeCarro(ByVal Nroenvio As Double, ByVal esProforma As Boolean) As String
        ' le pongo el argumento de si es proforma, porque cuando lo usemos para saber el carro con los envios que no son de andreani
        ' le pasaremos el valor en true asi busco por numero de pedido en vez de buscar por numero de envio
        On Error GoTo ErrNumerodeCarro
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        NumerodeCarro = ""

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        If esProforma Then
            sStr = "SELECT top 1 NroCarro FROM DepoCarrosDetalle WHERE NroProforma = " + Nroenvio.ToString + " "
            sStr = sStr + "order by Auditoria desc,SecuenciaCarro desc"
        Else
            sStr = "SELECT top 1 NroCarro FROM DepoCarrosDetalle WHERE Nroenvio = '" + Nroenvio.ToString + "' "
            sStr = sStr + "order by Auditoria desc,SecuenciaCarro desc"
        End If
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                NumerodeCarro = CompletarCaracteresIzquierda(Reader.Item("NroCarro").ToString, 3, "0")
            End If
        End If

        Exit Function
ErrNumerodeCarro:
        NumerodeCarro = ""
        MensajeAtencion("Error al recuperar el número de carro del pedido.")
    End Function

    Public Sub DatosEntregaParaCOT(ByVal Datos As String, ByRef Domicilio As String, ByRef CodPos As String, ByRef Localidad As String, ByRef Provincia As String, ByRef Obs As String)
        Dim PosIn, PosFi As Integer
        Dim Temp As String
        Temp = Datos
        If Strings.Left(Datos, 20) = "Bº 200 VIV. MZA 27, " Then
            Domicilio = "CALLE MARTINIANO GOMEZ S/Nº  KIOSCO MARISA"
            Obs = "Bº 200 VIV. MZA 27, PARC. 12, CALLE MARTINIANO GOMEZ S/Nº  KIOSCO MARISA"
            Localidad = "PUERTO TIROL"
            CodPos = "3505"
            Exit Sub
        ElseIf Strings.Left(Datos, 37) = "SAN VICENTE DE PAUL 831 CASI AYACUCHO" Then
            Domicilio = "SAN VICENTE DE PAUL 831 CASI AYACUCHO"
            Obs = "RECIBE NENITO MENA 0298 422591  TE 0223 447961 / 494371"
            Localidad = "CLORINDA"
            Provincia = "FORMOSA"
            CodPos = "3610"
            Exit Sub
        ElseIf Strings.Left(Datos, 20) = "JOSE L. TERRA N.2526" Then
            Domicilio = "JOSE L. TERRA N.2526"
            Obs = "URUGUAY"
            Localidad = "MONTEVIDEO"
            CodPos = "11800"
            Exit Sub
        End If
        PosIn = InStr(Datos, Environment.NewLine, CompareMethod.Text)
        If PosIn > 0 Then
            Domicilio = Strings.Left(Datos, PosIn)
            Datos = Strings.Right(Datos, Len(Datos) - PosIn)
            PosIn = InStr(Datos, Environment.NewLine, CompareMethod.Text)
            If PosIn > 0 Then
                Localidad = Strings.Left(Datos, PosIn)
                Datos = Trim(Strings.Right(Datos, Len(Datos) - PosIn))
                PosIn = InStr(Localidad, "(", CompareMethod.Text)
                PosFi = InStr(Localidad, ")", CompareMethod.Text)
                If PosIn > 0 And PosFi > 0 Then
                    Temp = Strings.Mid(Localidad, PosIn + 1, PosFi - PosIn - 1)
                    If IsNumeric(Temp) Then
                        CodPos = Temp
                        Datos = Trim(Datos)
                        PosIn = InStr(Datos, Environment.NewLine, CompareMethod.Text)
                        If PosIn > 0 Then
                            Localidad = Trim(Localidad)
                            PosFi = InStr(Localidad, ")", CompareMethod.Text)
                            If PosFi > 0 Then
                                If PosFi >= Len(Localidad) - 2 Then
                                    Localidad = Strings.Left(Localidad, PosIn)
                                Else
                                    Localidad = Strings.Right(Localidad, Len(Localidad) - PosFi)
                                End If

                            Else
                                Localidad = Strings.Left(Datos, PosIn)
                            End If

                            Datos = Strings.Right(Datos, Len(Datos) - PosIn)
                            Obs = Trim(Datos)
                        Else
                            If Localidad <> "" Then
                                PosFi = InStr(Localidad, ")", CompareMethod.Text)
                                PosIn = InStr(Localidad, "(", CompareMethod.Text)
                                If PosIn > 12 Then
                                    Localidad = Strings.Left(Localidad, PosIn)
                                    Obs = Trim(Datos)
                                ElseIf PosFi > 0 Then
                                    Localidad = Strings.Right(Localidad, Len(Localidad) - PosFi)
                                    Provincia = Trim(limpiarCadenaNombreFichero(Datos, ""))
                                    'Obs = Trim(Datos)
                                End If
                            Else
                                Localidad = Trim(Datos)
                            End If
                        End If
                    Else
                        Domicilio = Domicilio + " " + Localidad
                        Localidad = Strings.Left(Datos, PosFi)
                        PosIn = InStr(Datos, "(", CompareMethod.Text)
                        PosFi = InStr(Datos, ")", CompareMethod.Text)
                        If PosIn > 0 And PosFi > 0 Then
                            CodPos = Strings.Mid(Datos, PosIn + 1, PosFi - PosIn - 1)
                        End If
                        Datos = Strings.Right(Datos, Len(Datos) - PosFi)
                        Localidad = Datos
                        If InStr(Datos, "CORRIENTES", CompareMethod.Text) > 0 Then
                            Provincia = "CORRIENTES"
                        ElseIf InStr(Datos, "SANTA FE", CompareMethod.Text) > 0 Then
                            Provincia = "SANTA FE"
                        ElseIf InStr(Datos, "CORDOBA", CompareMethod.Text) > 0 Then
                            Provincia = "CORDOBA"
                        ElseIf InStr(Datos, "BUENOS AIRES", CompareMethod.Text) > 0 Then
                            Provincia = "BUENOS AIRES"
                        ElseIf InStr(Datos, "LA PAMPA", CompareMethod.Text) > 0 Then
                            Provincia = "LA PAMPA"
                        ElseIf InStr(Datos, "RIO NEGRO", CompareMethod.Text) > 0 Then
                            Provincia = "RIO NEGRO"
                        ElseIf InStr(Datos, "ENTRE RIOS", CompareMethod.Text) > 0 Then
                            Provincia = "ENTRE RIOS"
                        ElseIf InStr(Datos, "CATAMARCA", CompareMethod.Text) > 0 Then
                            Provincia = "CATAMARCA"
                        ElseIf InStr(Datos, "SALTA", CompareMethod.Text) > 0 Then
                            Provincia = "SALTA"
                        ElseIf InStr(Datos, "JUJUY", CompareMethod.Text) > 0 Then
                            Provincia = "JUJUY"
                        ElseIf InStr(Datos, "MISIONES", CompareMethod.Text) > 0 Then
                            Provincia = "MISIONES"
                        ElseIf InStr(Datos, "MENDOZA", CompareMethod.Text) > 0 Then
                            Provincia = "MENDOZA"
                        ElseIf InStr(Datos, "TIERRA DEL FUEGO", CompareMethod.Text) > 0 Then
                            Provincia = "TIERRA DEL FUEGO"
                        ElseIf InStr(Datos, "CHUBUT", CompareMethod.Text) > 0 Then
                            Provincia = "CHUBUT"
                        ElseIf InStr(Datos, "CHACO", CompareMethod.Text) > 0 Then
                            Provincia = "CHACO"
                        ElseIf InStr(Datos, "FORMOSA", CompareMethod.Text) > 0 Then
                            Provincia = "FORMOSA"
                        ElseIf InStr(Datos, "LA RIOJA", CompareMethod.Text) > 0 Then
                            Provincia = "LA RIOJA"
                        ElseIf InStr(Datos, "NEUQUEN", CompareMethod.Text) > 0 Then
                            Provincia = "NEUQUEN"
                        ElseIf InStr(Datos, "SAN LUIS", CompareMethod.Text) > 0 Then
                            Provincia = "SAN LUIS"
                        ElseIf InStr(Datos, "SAN JUAN", CompareMethod.Text) > 0 Then
                            Provincia = "SAN JUAN"
                        ElseIf InStr(Datos, "SANTA CRUZ", CompareMethod.Text) > 0 Then
                            Provincia = "SANTA CRUZ"
                        ElseIf InStr(Datos, "SANTIAGO DEL ESTERO", CompareMethod.Text) > 0 Then
                            Provincia = "SANTIAGO DEL ESTERO"
                        ElseIf InStr(Datos, "TUCUMAN", CompareMethod.Text) > 0 Then
                            Provincia = "TUCUMAN"
                        ElseIf InStr(Datos, "CIUDAD AUTONOMA DE BUENOS AIRES", CompareMethod.Text) > 0 Then
                            Provincia = "CIUDAD AUTONOMA DE BUENOS AIRES"
                        End If
                    End If
                End If
            Else
                If (Localidad = "" And CodPos = "") Or Not IsNumeric(CodPos) Then
                    Datos = Temp
                    If MasDeUnParentesis(Datos) Then
                        PosIn = InStr(Datos, Environment.NewLine, CompareMethod.Text)
                        Domicilio = Strings.Left(Datos, PosIn)
                        Datos = Strings.Right(Datos, Len(Datos) - PosIn)
                        PosIn = InStr(Datos, "(", CompareMethod.Text)
                        PosFi = InStr(Datos, ")", CompareMethod.Text)
                        If PosIn > 0 And PosFi > 0 Then
                            CodPos = Strings.Mid(Datos, PosIn + 1, PosFi - PosIn - 1)
                            Localidad = Strings.Right(Datos, Len(Datos) - PosFi)
                        End If
                    Else
                        If Len(Trim(Datos)) > 2 Then
                            PosIn = InStr(Datos, "(", CompareMethod.Text)
                            PosFi = InStr(Datos, ")", CompareMethod.Text)
                            Domicilio = Strings.Left(Datos, PosIn)
                            If PosIn > 0 And PosFi > 0 Then
                                CodPos = Strings.Mid(Datos, PosIn + 1, PosFi - PosIn - 1)
                                Localidad = Strings.Right(Datos, Len(Datos) - PosFi)
                            End If
                        End If
                    End If
                End If
            End If
            If CodPos = "" Or Not IsNumeric(CodPos) Then
                If InStr(Localidad, "(", CompareMethod.Text) > 0 Then
                    If Localidad <> "" Then
                        Localidad = Trim(Localidad)
                        Localidad = RemoverEspacios(Localidad)
                        If InStr(Localidad, "-", CompareMethod.Text) > 0 Then
                            CodPos = Strings.Left(Localidad, 4)
                        Else
                            CodPos = Strings.Left(Localidad, 5)
                        End If

                        If IsNumeric(CodPos) Then
                            Localidad = Strings.Right(Localidad, Len(Localidad) - 5)
                            If Strings.Left(Localidad, 1) = "-" Then
                                Localidad = Strings.Right(Localidad, Len(Localidad) - 1)
                            End If
                        Else
                            CodPos = ""
                        End If

                    End If
                Else
                    PosIn = InStr(Datos, "(", CompareMethod.Text)
                    PosFi = InStr(Datos, ")", CompareMethod.Text)
                    If PosIn > 0 And PosFi > 0 Then
                        CodPos = Strings.Mid(Datos, PosIn + 1, PosFi - PosIn - 1)
                        Localidad = Strings.Right(Datos, Len(Datos) - PosFi)
                    End If
                    If CodPos = "" Then
                        PosIn = InStr(Domicilio, "(", CompareMethod.Text)
                        PosFi = InStr(Domicilio, ")", CompareMethod.Text)
                        If PosIn > 0 And PosFi > 0 Then
                            CodPos = Strings.Mid(Domicilio, PosIn + 1, PosFi - PosIn - 1)
                            If Not IsNumeric(CodPos) Then
                                Obs = CodPos
                                CodPos = ""
                                Datos = Strings.Trim(Strings.Right(Domicilio, Len(Domicilio) - PosFi))
                                Domicilio = Strings.Left(Domicilio, PosIn - 1)
                            End If
                        End If
                    End If
                    If CodPos = "" And InStr(Datos, "(", CompareMethod.Text) > 0 Then
                        PosIn = InStr(Datos, "(", CompareMethod.Text)
                        PosFi = InStr(Datos, ")", CompareMethod.Text)
                        CodPos = Strings.Mid(Datos, PosIn + 1, PosFi - PosIn - 1)
                        Localidad = Strings.Right(Datos, Len(Datos) - PosFi)
                    End If
                    If CodPos = "" Then 'No está entre paréntesis el CP
                        Localidad = Trim(Localidad)
                        CodPos = Strings.Trim(Strings.Left(Localidad, 5))
                    End If
                End If
            Else

            End If
        Else
            If Domicilio = "" Or CodPos = "" Or Localidad = "" Or Provincia = "" Then
                DatosEntrega(Datos, Domicilio, CodPos, Localidad, Obs)
            End If
        End If

    End Sub

    Function limpiarCadenaNombreFichero(cadenaTexto As String, sustituirPor As String) As String
        Dim tamanoCadena, i As Integer
        Dim caracteresValidos As String, cadenaResultado As String = ""
        Dim caracterActual As String

        tamanoCadena = Len(cadenaTexto)
        If tamanoCadena > 0 Then
            caracteresValidos = _
                " 0123456789abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ-_."
            For i = 1 To tamanoCadena
                caracterActual = Mid(cadenaTexto, i, 1)
                If InStr(caracteresValidos, caracterActual) Then
                    cadenaResultado = cadenaResultado & caracterActual
                Else
                    cadenaResultado = cadenaResultado & sustituirPor
                End If
            Next
        End If

        limpiarCadenaNombreFichero = cadenaResultado
    End Function

    Public Function ObtengoCodigoCOTProvincia(ByVal NombreProvincia As String) As String
        Dim Retorno As String = "B"

        If UCase(NombreProvincia) = "SALTA" Then
            Retorno = "A"
        ElseIf UCase(NombreProvincia) = "BUENOS AIRES" Then
            Retorno = "B"
        ElseIf UCase(NombreProvincia) = "CAPITAL FEDERAL" Or UCase(NombreProvincia) = "CABA" Or UCase(NombreProvincia) = "CIUDAD AUTONOMA DE BUENOS AIRES" Then
            Retorno = "C"
        ElseIf UCase(NombreProvincia) = "SAN LUIS" Then
            Retorno = "D"
        ElseIf UCase(NombreProvincia) = "ENTRE RIOS" Then
            Retorno = "E"
        ElseIf UCase(NombreProvincia) = "LA RIOJA" Then
            Retorno = "F"
        ElseIf UCase(NombreProvincia) = "SANTIAGO DEL ESTERO" Then
            Retorno = "G"
        ElseIf UCase(NombreProvincia) = "CHACO" Then
            Retorno = "H"
        ElseIf UCase(NombreProvincia) = "SAN JUAN" Then
            Retorno = "J"
        ElseIf UCase(NombreProvincia) = "CATAMARCA" Then
            Retorno = "K"
        ElseIf UCase(NombreProvincia) = "LA PAMPA" Then
            Retorno = "L"
        ElseIf UCase(NombreProvincia) = "MENDOZA" Then
            Retorno = "M"
        ElseIf UCase(NombreProvincia) = "MISIONES" Then
            Retorno = "N"
        ElseIf UCase(NombreProvincia) = "FORMOSA" Then
            Retorno = "P"
        ElseIf UCase(NombreProvincia) = "NEUQUEN" Then
            Retorno = "Q"
        ElseIf UCase(NombreProvincia) = "RIO NEGRO" Then
            Retorno = "R"
        ElseIf UCase(NombreProvincia) = "SANTA FE" Then
            Retorno = "S"
        ElseIf UCase(NombreProvincia) = "TUCUMAN" Or UCase(NombreProvincia) = "TUCUMÁN" Then
            Retorno = "T"
        ElseIf UCase(NombreProvincia) = "CHUBUT" Then
            Retorno = "U"
        ElseIf UCase(NombreProvincia) = "TIERRA DEL FUEGO" Then
            Retorno = "V"
        ElseIf UCase(NombreProvincia) = "CORRIENTES" Then
            Retorno = "W"
        ElseIf UCase(NombreProvincia) = "CORDOBA" Or UCase(NombreProvincia) = "CÓRDOBA" Then
            Retorno = "X"
        ElseIf UCase(NombreProvincia) = "JUJUY" Then
            Retorno = "Y"
        ElseIf UCase(NombreProvincia) = "SANTA CRUZ" Then
            Retorno = "Z"
        End If

        Return Retorno
    End Function

    Public Function NroFacturaPedidoBAS(ByVal Prefijo As Integer, ByVal Numero As Integer) As String
        On Error GoTo ErrNroFacturaPedidoBAS
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        NroFacturaPedidoBAS = ""

        If cConexionBAS.SQLConn.State <> ConnectionState.Open Then ReConectar("BAS")

        sStr = "select top 1 * from transac "
        sStr = sStr + "where LEFT(codcmp,1)='F' and NROTRANSELIM IS NULL "
        sStr = sStr + "and NROTRANS = "
        sStr = sStr + "(SELECT top 1 M.NROTRANS FROM MVSITEMS M JOIN TRANSAC T ON M.REFTRANS = T.NROTRANS "
        sStr = sStr + "WHERE T.NUMERO = " + Numero.ToString + " AND T.PREFIJO = " + Prefijo.ToString + " AND T.CODCMP='PV' AND T.NROTRANSELIM IS NULL)"
        Command = New SqlCommand(sStr, cConexionBAS.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                NroFacturaPedidoBAS = Strings.Right(Reader.Item("CODCMP").ToString, 1) + "-" + CompletarCaracteresIzquierda(Reader.Item("PREFIJO").ToString, 4, "0") + "-" + CompletarCaracteresIzquierda(Reader.Item("NUMERO").ToString, 8, "0")
            End If
        End If

        Exit Function
ErrNroFacturaPedidoBAS:
        NroFacturaPedidoBAS = ""
    End Function

    Public Function ComprobarAlertasCC() As String
        On Error GoTo ErrComprobarAlertasCC
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        ComprobarAlertasCC = ""

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT * FROM TejeControlDeCalidad WHERE Eliminado = 0 AND Estado = 0 AND Destino = 'PROGRAMACION'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                ComprobarAlertasCC = ComprobarAlertasCC + "OBS CC OP: " + NumeroOP(Reader.Item("idOP")).ToString + " | Cód. Art: " + CodArticuloPorOP(Reader.Item("idOP")).ToString + " | Talle: " + NombreTalle(Reader.Item("Talle")).ToString + vbCrLf
            Loop
            Reader.NextResult()
        Loop

        If ComprobarAlertasCC = "" Then ComprobarAlertasCC = "NO HAY ALERTAS"

        Exit Function
ErrComprobarAlertasCC:
        ComprobarAlertasCC = ""
    End Function

    Public Function NumeroOP(id As Integer) As Integer
        On Error GoTo ErrNumeroOP
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        NumeroOP = 0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT * FROM PrendasOPs WHERE id = " + id.ToString
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                NumeroOP = Reader.Item("OP").ToString
            End If
        End If

        Exit Function
ErrNumeroOP:
        NumeroOP = 0
        MensajeAtencion("Error al recuperar el número de OP (por id).")
    End Function

    Public Function CodArticuloPorOP(idOP As Integer) As String
        On Error GoTo ErrCodArticuloPorOP
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        CodArticuloPorOP = ""

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT * FROM PrendasOPs WHERE id = " + idOP.ToString
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                CodArticuloPorOP = Reader.Item("CodArticulo").ToString
            End If
        End If

        Exit Function
ErrCodArticuloPorOP:
        CodArticuloPorOP = ""
        MensajeAtencion("Error al recuperar el código de artículo por el número de OP (por id).")
    End Function

    Public Function NombreTalle(codTalle As Integer) As String
        On Error GoTo ErrNombreTalle

        NombreTalle = ""

        If codTalle = 1 Then
            NombreTalle = "S"
        ElseIf codTalle = 2 Then
            NombreTalle = "M"
        ElseIf codTalle = 3 Then
            NombreTalle = "L"
        ElseIf codTalle = 4 Then
            NombreTalle = "XL"
        ElseIf codTalle = 5 Then
            NombreTalle = "XXL"
        ElseIf codTalle = 6 Then
            NombreTalle = "XS"
        ElseIf codTalle = 7 Then
            NombreTalle = "XXS"
        ElseIf codTalle = 8 Then
            NombreTalle = "U"
        End If

        Exit Function
ErrNombreTalle:
        NombreTalle = ""
        MensajeAtencion("Error al recuperar el nombre del talle.")
    End Function

    Public Function CodigoTalle(NombreTalle As String) As Integer
        On Error GoTo ErrCodigoTalle

        CodigoTalle = 0

        If NombreTalle = "S" Then
            CodigoTalle = 1
        ElseIf NombreTalle = "M" Then
            CodigoTalle = 2
        ElseIf NombreTalle = "L" Then
            CodigoTalle = 3
        ElseIf NombreTalle = "XL" Then
            CodigoTalle = 4
        ElseIf NombreTalle = "XXL" Then
            CodigoTalle = 5
        ElseIf NombreTalle = "XS" Then
            CodigoTalle = 6
        ElseIf NombreTalle = "XXS" Then
            CodigoTalle = 7
        ElseIf NombreTalle = "U" Then
            CodigoTalle = 8
        End If

        Exit Function
ErrCodigoTalle:
        CodigoTalle = 0
        MensajeAtencion("Error al recuperar el código del talle.")
    End Function

    Public Function idOPExistente(NroOP As Integer, Optional EsOPA As Boolean = False, Optional EsGranel As Boolean = False) As Integer
        On Error GoTo ErridOPExistente
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        idOPExistente = 0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        If EsOPA Then
            sStr = "SELECT TOP 1 P.id AS idEx FROM TejeOPAs T INNER JOIN PrendasOPs P ON T.idOP = P.id WHERE T.Eliminado = 0 AND P.Anticipada <> 1 AND P.Eliminado = 0 AND P.OP = " + NroOP.ToString + " ORDER BY P.id DESC"
        ElseIf EsGranel Then
            sStr = "SELECT TOP 1 id AS idEx FROM PrendasOPAs WHERE Eliminado = 0 AND OPA = " + NroOP.ToString + " ORDER BY id DESC"
        Else
            sStr = "SELECT TOP 1 id AS idEx FROM PrendasOPs WHERE Eliminado = 0 AND OP = " + NroOP.ToString + " AND Anticipada <> 1 ORDER BY id DESC"
        End If
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                idOPExistente = Reader.Item("idEx").ToString
            End If
        End If

        Exit Function
ErridOPExistente:
        idOPExistente = 0
        MensajeAtencion("Error al recuperar el id de OP existente (por número).")
    End Function

    Public Function EstadoCC(Codigo As Integer) As String
        On Error GoTo ErrEstadoCC
        EstadoCC = ""
        If Codigo = 0 Then
            EstadoCC = "PENDIENTE"
        ElseIf Codigo = 1 Then
            EstadoCC = "FINALIZADO"
        ElseIf Codigo = 2 Then
            EstadoCC = "CANCELADO"
        End If
        Exit Function
ErrEstadoCC:
        EstadoCC = ""
        MensajeAtencion("Error al recuperar la descripción del estado de CC.")
    End Function

    Public Function ArticuloPoridOP(idOP As Integer) As String
        On Error GoTo ErrArticuloPoridOP
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        ArticuloPoridOP = ""

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT * FROM PrendasOPs WHERE id = " + idOP.ToString
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                ArticuloPoridOP = Reader.Item("CodArticulo").ToString
            End If
        End If

        Exit Function
ErrArticuloPoridOP:
        ArticuloPoridOP = ""
        MensajeAtencion("Error al recuperar el artículo por el id de OP.")
    End Function

    Public Function ObtenerFechaServer() As Date
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String
        Dim FechaRetorno As Date = "01/01/1900 00:00:00.000"

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT GETDATE() as FechaServer "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                FechaRetorno = Reader.Item("FechaServer")
            End If
        End If
        ObtenerFechaServer = FechaRetorno
    End Function

    Public Function ObtenerListaDeRecursosDeLaTareaParaUnaMaquina(ByVal IdMaqTarea As String) As String

        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        Dim ListaRecursos As String = ""

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT * FROM HilaMantePlanTareasRecursos PR INNER JOIN HilaManteRecursos R ON PR.IdRecurso =R.Id "
        sStr = sStr + " WHERE IdMaqTarea= " + IdMaqTarea + " "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            'If ListaRecursos <> "" Then
            '    ListaRecursos = ListaRecursos + Chr(13)
            'End If
            Do While Reader.Read()
                ListaRecursos = ListaRecursos + Reader.Item("NombreRecurso") + Chr(13)
            Loop
            Reader.NextResult()
        Loop

        'Al final saco el ultimo enter
        If ListaRecursos <> "" Then
            ListaRecursos = Strings.Left(ListaRecursos, ListaRecursos.Length - 1)
        End If

        Return ListaRecursos

    End Function

    Public Function HilamarObtengoStockTotalHilado(ByVal Codhilado As String, ByVal ALaFecha As Date) As Double
        Dim Command, CommandMov As New SqlCommand
        Dim Reader, ReaderMov As SqlDataReader
        Dim sStr, sStrMov As String

        Dim StockTotalPartida As Double = 0.0
        Dim FechaInicialStockPartida As String
        Dim StockTotalhilado As Double = 0.0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        'debo en realidad arreglar el procedimiento para que busque desde la fecha de stock sumando y restando los movimientos de E y S para cada una de las partidas
        sStr = "SELECT ("
        sStr = sStr + " SELECT ISNULL(SUM(KILOS * (CASE E.TipoMov WHEN 'I' THEN 1 WHEN 'E' THEN -1 WHEN 'DI' THEN 1 WHEN 'C' THEN -1 END )),0) AS STOCKMOV "
        sStr = sStr + " FROM HilamarHiladoStockEncMov E INNER JOIN HilamarHiladoStockDetMov D ON E.NroRemito = D.NroRemito AND E.TipoMov = D.TipoMov "
        sStr = sStr + " WHERE ISNULL(E.Eliminado,0)=0 AND Isnull(D.Eliminado,0)=0 AND E.Fecha >=ISNULL(H.FechaStockDesde,'19000101') AND E.Fecha <= '" + Format(ALaFecha, "yyyyMMdd") + "' "
        sStr = sStr + " AND D.PARTIDA= H.Partida "
        sStr = sStr + " ) as MOVIMIENTOS"
        sStr = sStr + " ,H.id AS IDPARTIDA ,*"
        sStr = sStr + " FROM HilamarTipoHiladoPartidas T INNER JOIN HilamarHiladoStock H ON H.Codtipohilado=T.Codigo"
        sStr = sStr + " WHERE CodTipoHilado = " + Codhilado + " AND (ISNULL(FECHASTOCKDESDE,'19000101') <='" + Format(ALaFecha, "yyyyMMdd") + "' AND ISNULL(FechaStockHasta,GETDATE())>='" + Format(ALaFecha, "yyyyMMdd") + "') "
        sStr = sStr + " ORDER BY CodTipoHilado asc, EsDiscontinuada desc, Color asc "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                StockTotalPartida = CDbl(Reader.Item("Kilos")) + CDbl(Reader.Item("MOVIMIENTOS"))

                StockTotalhilado = StockTotalhilado + StockTotalPartida
            Loop
            Reader.NextResult()
        Loop

        Return StockTotalhilado

    End Function

    Public Function HilamarObtengoStockActualPartida(ByVal CodPartida As String, ByVal ALaFecha As Date) As Double
        Dim Command, CommandMov As New SqlCommand
        Dim Reader, ReaderMov As SqlDataReader
        Dim sStr, sStrMov As String

        Dim StockTotalPartida As Double = 0.0
        Dim FechaInicialStockPartida As String = "19000101"
        Dim FechaFinalStockPartida As String = "19000101"

        'debo en realidad arreglar el procedimiento para que busque desde la fecha de stock sumando y restando los movimientos de E y S para cada una de las partidas

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        'Me traigo el stock inicial de la partida 
        sStr = "SELECT PARTIDA,KILOS,ISNULL(FechaStockDesde,'19000101') as FECHAINICIAL,ISNULL(FechaStockHasta,getdate()) as FECHAFINAL "
        sStr = sStr + " FROM HilamarHiladoStock WHERE Partida = '" + CodPartida + "' and Eliminado=0 "
        sStr = sStr + " and isnull(FechaStockDesde,'19000101') <= '" + Format(ALaFecha, "yyyyMMdd") + "' and isnull(FechaStockHasta,getdate()) >= '" + Format(ALaFecha, "yyyyMMdd") + "'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                'stock inicial de la partida
                StockTotalPartida = CDbl(Reader.Item("Kilos"))
                FechaInicialStockPartida = Format(Reader.Item("FECHAINICIAL"), "yyyyMMdd")
                FechaFinalStockPartida = Format(Reader.Item("FECHAFINAL"), "yyyyMMdd")
            End If
        End If

        'PARA LA partida me traigo la suma y resta de movimientos desde la fecha de stock
        sStrMov = "SELECT ISNULL(SUM(KILOS * (CASE E.TipoMov WHEN 'I' THEN 1 WHEN 'E' THEN -1 WHEN 'DI' THEN 1 WHEN 'C' THEN -1 END )),0) AS STOCKMOV "
        sStrMov = sStrMov + " FROM HilamarHiladoStockEncMov E INNER JOIN HilamarHiladoStockDetMov D ON E.NroRemito = D.NroRemito AND E.TipoMov=D.TipoMov "
        sStrMov = sStrMov + " WHERE Isnull(E.Eliminado,0)=0 AND Isnull(D.Eliminado,0)=0 "
        sStrMov = sStrMov + " AND E.Fecha >='" + FechaInicialStockPartida + "' AND E.Fecha <='" + FechaFinalStockPartida + "' AND E.Fecha <='" + Format(ALaFecha, "yyyyMMdd") + "' "
        sStrMov = sStrMov + " AND D.PARTIDA='" + CodPartida + "'"
        CommandMov = New SqlCommand(sStrMov, cConexionApp.SQLConn)
        ReaderMov = CommandMov.ExecuteReader()
        If ReaderMov.HasRows Then
            If ReaderMov.Read() Then
                StockTotalPartida = StockTotalPartida + CDbl(ReaderMov.Item("STOCKMOV"))
            End If
        End If

        Return StockTotalPartida

    End Function

    'Public Sub ActualizarPartidasUNIX()
    '    Dim Kilos, Color, CodColor, PCardado As String

    '    'COPIO LAS PARTIDAS
    '    If Not CopiarPartidasUnix() Then
    '        MensajeAtencion("No se pudo recuperar la información de UNIX (Partidas).")
    '        Exit Sub
    '    End If

    '    If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
    '    sStr = "DELETE HilamarHiladoStock"
    '    Command2 = New SqlCommand(sStr, cConexionApp.SQLConn)
    '    Command2.ExecuteNonQuery()

    '    'creo conexion para leer dbf
    '    Dim ConnStringH As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\bases" + " ;Extended Properties=dBASE IV;User ID=Admin;Password="
    '    Dim DBFConnH As New OleDbConnection(ConnStringH)
    '    DBFConnH.Open()

    '    sStr = "SELECT * FROM HILSTOCK ORDER BY PARTIS"
    '    Dim DBFCommandH As OleDbCommand = New OleDbCommand(sStr, DBFConnH)
    '    Dim DBFDataReaderH As OleDbDataReader = DBFCommandH.ExecuteReader(CommandBehavior.Default)
    '    Do While DBFDataReaderH.Read
    '        'CodParti = CompletarCaracteresIzquierda(DBFDataReaderH("PARTIS").ToString, 8, "0").ToString
    '        Kilos = DBFDataReaderH("KILOS").ToString
    '        Kilos = Replace(Kilos, ",", ".").ToString
    '        Color = DBFDataReaderH("COLORS").ToString
    '        If Color <> "" Then Color = Replace(Color, "'", " ").ToString
    '        CodColor = DBFDataReaderH("NUMCOS").ToString
    '        If CodColor <> "" Then CodColor = Replace(CodColor, "'", " ").ToString
    '        PCardado = DBFDataReaderH("KILPRO").ToString
    '        If PCardado <> "" Then PCardado = Replace(PCardado, "'", " ").ToString
    '        sStr = "INSERT INTO HilamarHiladoStock (Partida, CodTipoHilado, Kilos, Color, Eliminado, Auditoria, CodColor, PCardado) VALUES ('"
    '        sStr = sStr + DBFDataReaderH("PARTIS").ToString.ToString + "', '" + DBFDataReaderH("CODIS").ToString + "', " + Kilos.ToString + ", '" + Color.ToString
    '        sStr = sStr + "', 0, 'ALTA | " + Now.ToString + "','" + CodColor + "','" + PCardado + "')"
    '        Command2 = New SqlCommand(sStr, cConexionApp.SQLConn)
    '        Command2.ExecuteNonQuery()
    '    Loop

    '    'actualizo los tipos de hilados

    '    sStr = "DELETE HilamarTipoHiladoPartidas"
    '    Command2 = New SqlCommand(sStr, cConexionApp.SQLConn)
    '    Command2.ExecuteNonQuery()

    '    sStr = "SELECT * FROM TIPOHILA ORDER BY CODI"
    '    DBFCommandH = New OleDbCommand(sStr, DBFConnH)
    '    DBFDataReaderH = DBFCommandH.ExecuteReader(CommandBehavior.Default)
    '    Do While DBFDataReaderH.Read
    '        sStr = "INSERT INTO HilamarTipoHiladoPartidas (Codigo, Descripcion, Eliminado, Auditoria, Proveedor) VALUES ('"
    '        sStr = sStr + DBFDataReaderH("CODI").ToString.ToString + "', '" + DBFDataReaderH("TIPO").ToString + "'"
    '        sStr = sStr + ", 0, 'ALTA | " + Now.ToString + "','" + DBFDataReaderH("PROVE").ToString + "')"
    '        Command2 = New SqlCommand(sStr, cConexionApp.SQLConn)
    '        Command2.ExecuteNonQuery()
    '    Loop

    '    'cuando termino todo actualizo las fechas de ultima modificacion de los archivos del unix en la base de datos
    '    Dim UltFechaUnixHilStockServer, UltFechaUnixTipoHilaServer As Date

    '    UltFechaUnixHilStockServer = My.Computer.FileSystem.GetFileInfo("\\192.168.0.12\u\hilamar\sto\hilstock.dbf").LastWriteTime
    '    UltFechaUnixTipoHilaServer = My.Computer.FileSystem.GetFileInfo("\\192.168.0.12\u\hilamar\sto\tipohila.dbf").LastWriteTime
    '    sStr = "UPDATE HilamarConfigSistema set UltFechaUnixHilStock = '" + Format(UltFechaUnixHilStockServer, "yyyyMMdd HH:mm:ss.fff") + "'"
    '    Command2 = New SqlCommand(sStr, cConexionApp.SQLConn)
    '    Command2.ExecuteNonQuery()
    '    sStr = "UPDATE HilamarConfigSistema set UltFechaUnixTipoHila = '" + Format(UltFechaUnixTipoHilaServer, "yyyyMMdd HH:mm:ss.fff") + "'"
    '    Command2 = New SqlCommand(sStr, cConexionApp.SQLConn)
    '    Command2.ExecuteNonQuery()


    '    DBFConnH.Close()
    'End Sub

    Public Function ArticuloStockCrudo(CodArt As String, Fecha As Date) As Integer
        On Error GoTo ErrArticuloStockCrudo
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String
        Dim FechaStock As Date
        Dim idStockDetalle As Integer

        ArticuloStockCrudo = 0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        'Inicio de Fecha de movimientos del Stock
        sStr = "SELECT TOP 1 * FROM CrudoStockDetallado WHERE CodArticulo = '" + CodArt.ToString + "' AND Eliminado = 0 AND Fecha <= '" + FechaWin10(Fecha).ToString + "' ORDER BY Fecha DESC"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                idStockDetalle = Reader.Item("id").ToString
                FechaStock = Reader.Item("Fecha").ToString
            End If
        End If

        If idStockDetalle = 0 Then Exit Function

        sStr = "SELECT SUM(Cantidad) AS CANT FROM DetCrudoStockDetallado WHERE idStockDetalle = " + idStockDetalle.ToString + " AND Eliminado = 0 " 'AND Color = '" + Color.ToString + "'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                ArticuloStockCrudo = Reader.Item("CANT").ToString
            End If
        End If

        If FechaStock = "#12:00:00 AM#" Then Exit Function

        'Sumo los paquetes ingresados
        sStr = "SELECT SUM(P.Cantidad) AS CANT FROM CrudoMovimientos M INNER JOIN CrudoPaquetes P ON M.idPaquete = P.id WHERE M.Fecha >= '" + FechaWin10(FechaStock).ToString + "' AND M.Fecha <= '" + FechaWin10(Fecha).ToString + "' AND P.CodArticulo = '" + CodArt.ToString + "' AND P.Eliminado = 0 AND M.Eliminado = 0 AND CodTipoMov = 1 AND P.Eliminado = 0 " 'AND P.Color = '" + Color.ToString + "' 
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                If Not IsDBNull(Reader.Item("CANT")) Then ArticuloStockCrudo = ArticuloStockCrudo + Reader.Item("CANT")
            End If
        End If

        'Resto los paquetes egresados
        sStr = "SELECT SUM(P.Cantidad) AS CANT FROM CrudoMovimientos M INNER JOIN CrudoPaquetes P ON M.idPaquete = P.id WHERE M.Fecha >= '" + FechaWin10(FechaStock).ToString + "' AND M.Fecha <= '" + FechaWin10(Fecha).ToString + "' AND P.CodArticulo = '" + CodArt.ToString + "' AND M.Eliminado = 0 AND P.Eliminado = 0 AND CodTipoMov = 2 "
        'If Color = "CRUDO" Then
        '    sStr = sStr + "AND P.Color IN ('','CRUDO') "
        'Else
        '    sStr = sStr + "AND P.Color = '" + Color.ToString + "' "
        'End If
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                If Not IsDBNull(Reader.Item("CANT")) Then ArticuloStockCrudo = ArticuloStockCrudo - Reader.Item("CANT")
            End If
        End If

        'Tomo en cuenta los ajustes
        sStr = "SELECT SUM(Cantidad) AS CANT FROM CrudoMovimientos "
        sStr = sStr + "WHERE Fecha >= '" + FechaWin10(FechaStock).ToString + "' AND Fecha <= '" + FechaWin10(Fecha).ToString + "' AND CodArticulo = '" + CodArt.ToString + "' AND Eliminado = 0 AND CodTipoMov = 4 " 'AND Color = '" + Color.ToString + "' 
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                If Not IsDBNull(Reader.Item("CANT")) Then ArticuloStockCrudo = ArticuloStockCrudo + Reader.Item("CANT")
            End If
        End If

        Exit Function
ErrArticuloStockCrudo:
        ArticuloStockCrudo = 0
        MensajeAtencion("Error al cargar el stock de crudo (nuevo).")

    End Function

    Public Function VentaArticulo(CodArt As String, Local As Integer, FechaInicio As Date, FechaFin As Date, Optional ParaListado As Boolean = False) As Integer
        On Error GoTo ErrVentaArticulo
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        VentaArticulo = 0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT SUM(Cantidad) AS CANT FROM StockMovimientos WHERE Eliminado = 0 AND CodArticulo = '" + CodArt.ToString + "' AND Origen = " + Local.ToString + " AND Fecha >= '" + FechaWin10(FechaInicio).ToString + "' AND Fecha <= '" + FechaWin10(FechaFin).ToString
        If ParaListado Then
            sStr = sStr + "' AND CodTipoMov IN (4, 5)"
        Else
            sStr = sStr + "' AND CodTipoMov IN (4, 5, 8)"
        End If
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                If Not IsDBNull(Reader.Item("CANT")) Then
                    VentaArticulo = Reader.Item("CANT").ToString
                Else
                    VentaArticulo = 0
                End If
            End If
        End If

        Exit Function
ErrVentaArticulo:
        VentaArticulo = 0
        MensajeAtencion("Error al recuperar la venta del artículo.")
    End Function


    Public Function UltimoDiaMes(ByVal Fecha As Date) As Date
        On Error GoTo ErrUltimoDiaMes
        Dim StrFecha, UltDia As String

        UltDia = Date.DaysInMonth(Year(Fecha).ToString, Month(Fecha).ToString).ToString
        StrFecha = UltDia.ToString + "/" + Month(Fecha).ToString + "/" + Year(Fecha).ToString

        UltimoDiaMes = FechaWin10(StrFecha).ToString

        Exit Function
ErrUltimoDiaMes:
        MensajeCritico("Error al calcular la fecha del último día del mes anterior.")
        UltimoDiaMes = Fecha
    End Function

    Public Function StockArticulo(ByVal CodArticulo As String, ByVal Local As Integer, Optional FechaHasta As String = "") As Integer
        On Error GoTo ErrStockArticulo
        Dim Inicio, Ventas, Entalle, Remitos, RemitosResta, Total, Vales, Ajuste, StockMes, Fallas, Cambios, Devoluciones As Integer
        Dim FechaInicio, FechaStock, FechaTmp, FechaFin As Date

        If FechaHasta <> "" Then
            FechaTmp = FechaHasta.ToString
            FechaInicio = "01/" + CompletarCaracteresIzquierda(FechaTmp.Month, 2, "0").ToString + "/" + FechaTmp.Year.ToString
            FechaFin = UltimoDiaMes(FechaInicio)
        Else
            FechaInicio = "01/" + CompletarCaracteresIzquierda(Now.Month, 2, "0").ToString + "/" + Now.Year.ToString
            FechaFin = NowServer.ToString
        End If
        FechaStock = FechaInicio

        Inicio = 0
        Ventas = 0
        Entalle = 0
        Remitos = 0
        RemitosResta = 0
        Vales = 0
        Ajuste = 0
        Cambios = 0
        Devoluciones = 0

        If TieneStockDetallado(CodArticulo, Local) Then
            Inicio = StockInicioArticuloDetalladoGeneral(CodArticulo, Local, FechaFin, FechaInicio)
            Entalle = EntalleArticuloDetalladoGeneral(CodArticulo, FechaInicio, FechaFin)
            Ventas = VentaArticuloDetalladoGeneral(CodArticulo, Local, FechaInicio, FechaFin)
        Else
            Inicio = StockInicioArticulo(CodArticulo, Local, FechaStock, FechaInicio)
            If Local = 1 Then
                If FechaHasta = "" Then
                    Entalle = EntalleArticulo(CodArticulo, FechaInicio, FechaFin)
                Else
                    Entalle = EntalleArticuloRango(CodArticulo, FechaInicio, FechaFin)
                End If
            Else
                Entalle = 0
            End If
            Ventas = VentaArticulo(CodArticulo, Local, FechaInicio, FechaFin)
        End If


        Ajuste = AjusteArticulo(CodArticulo, Local, FechaInicio, FechaFin)
        Vales = ValesArticulo(CodArticulo, Local, FechaInicio, FechaFin)
        Fallas = FallasArticulo(CodArticulo, Local, FechaInicio, FechaFin)
        Remitos = RemitosSumaArticulo(CodArticulo, Local, FechaInicio, FechaFin)
        RemitosResta = RemitosRestaArticulo(CodArticulo, Local, FechaInicio, FechaFin)
        Cambios = CambiosArticulo(CodArticulo, Local, FechaInicio, FechaFin)
        Devoluciones = DevolucionesArticulo(CodArticulo, Local, FechaInicio, FechaFin)
        Total = Inicio + Entalle - Ventas - Vales + Remitos + Ajuste - Fallas - RemitosResta - Cambios + Devoluciones

        StockArticulo = Total.ToString

        Exit Function
ErrStockArticulo:
        StockArticulo = 0
        MensajeAtencion("Error al calcular el stock del artículo.")

    End Function

    Public Function TieneStockDetallado(CodArt As String, Local As Integer) As Boolean
        On Error GoTo ErrTieneStockDetallado
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        TieneStockDetallado = False

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT * FROM StockArticulosDetallado WHERE CodArticulo = '" + CodArt.ToString + "' AND Local = " + Local.ToString + " AND Eliminado = 0"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                TieneStockDetallado = True
            End If
        End If

        Exit Function
ErrTieneStockDetallado:
        TieneStockDetallado = False
        MensajeAtencion("Error al recuperar si el artículo tiene stock detallado.")
    End Function

    'Stock detallado - General
    Public Function StockInicioArticuloDetalladoGeneral(CodArt As String, Local As Integer, Fecha As Date, ByRef FechaInicio As Date) As Integer
        On Error GoTo ErrStockInicioArticuloDetalladoGeneral
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String
        Dim idStock As Integer

        StockInicioArticuloDetalladoGeneral = 0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT TOP 1 * FROM StockArticulosDetallado WHERE Eliminado = 0 AND CodArticulo = '" + CodArt.ToString + "' AND Local = " + Local.ToString + " AND Fecha <= '" + FechaWin10(Fecha).ToString + "' ORDER BY Fecha DESC"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                If Not IsDBNull(Reader.Item("Fecha")) Then
                    idStock = Reader.Item("id").ToString
                    FechaInicio = Reader.Item("Fecha").ToString
                Else
                    idStock = 0
                End If
            End If
        End If

        If idStock <> 0 Then
            sStr = "SELECT SUM(Cantidad) AS CANT FROM DetStockArticulosDetallado WHERE Eliminado = 0 AND idStockDetalle = " + idStock.ToString
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows() Then
                If Reader.Read() Then
                    If Not IsDBNull(Reader.Item("CANT")) Then
                        StockInicioArticuloDetalladoGeneral = Reader.Item("CANT").ToString
                    Else
                        StockInicioArticuloDetalladoGeneral = 0
                    End If
                End If
            End If
        End If

        Exit Function
ErrStockInicioArticuloDetalladoGeneral:
        StockInicioArticuloDetalladoGeneral = 0
        MensajeAtencion("Error al recuperar el stock inicial detallado general del artículo.")
    End Function

    Public Function EntalleArticuloDetalladoGeneral(CodArt As String, Fecha As Date, FechaFin As Date) As Integer
        On Error GoTo ErrEntalleArticuloDetalladoGeneral
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        EntalleArticuloDetalladoGeneral = 0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT SUM(Cantidad) AS CANT FROM Entalle WHERE Eliminado = 0 AND CodArticulo = '" + CodArt.ToString + "' AND Fecha >= '" + FechaWin10(Fecha).ToString + "' AND Fecha <= '" + FechaWin10(FechaFin).ToString + "'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                If Not IsDBNull(Reader.Item("CANT")) Then
                    EntalleArticuloDetalladoGeneral = Reader.Item("CANT").ToString
                Else
                    EntalleArticuloDetalladoGeneral = 0
                End If
            End If
        End If

        Exit Function
ErrEntalleArticuloDetalladoGeneral:
        EntalleArticuloDetalladoGeneral = 0
        MensajeAtencion("Error al recuperar el entalle detallado general del artículo.")
    End Function

    Public Function VentaArticuloDetalladoGeneral(CodArt As String, Local As Integer, FechaInicio As Date, FechaFin As Date) As Integer
        On Error GoTo ErrVentaArticuloDetalladoGeneral
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        VentaArticuloDetalladoGeneral = 0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT SUM(DET.Cantidad) AS CANT FROM PedidosProformas P INNER JOIN DetPedidosProformas DET ON P.NroPedido = DET.NroPedido WHERE CodArticulo = '" + CodArt.ToString + "' AND Fecha >= '" + FechaWin10(FechaInicio).ToString + "' AND Fecha <= '" + FechaWin10(FechaFin).ToString + "'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                If Not IsDBNull(Reader.Item("CANT")) Then
                    VentaArticuloDetalladoGeneral = Reader.Item("CANT").ToString
                Else
                    VentaArticuloDetalladoGeneral = 0
                End If
            End If
        End If

        Exit Function
ErrVentaArticuloDetalladoGeneral:
        VentaArticuloDetalladoGeneral = 0
        MensajeAtencion("Error al recuperar la venta detallada del artículo.")
    End Function

    Public Function StockInicioArticulo(CodArt As String, Local As Integer, Fecha As Date, ByRef FechaInicio As Date) As Integer
        On Error GoTo ErrStockInicioArticulo
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        StockInicioArticulo = 0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT TOP 1 * FROM StockArticulos WHERE Eliminado = 0 AND CodArticulo = '" + CodArt.ToString + "' AND Local = " + Local.ToString + " AND Fecha <= '" + FechaWin10(Fecha).ToString + "' ORDER BY Fecha DESC"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                If Not IsDBNull(Reader.Item("Cantidad")) Then
                    StockInicioArticulo = Reader.Item("Cantidad").ToString
                    FechaInicio = Reader.Item("Fecha").ToString
                Else
                    StockInicioArticulo = 0
                    FechaInicio = Fecha.ToString
                End If
            End If
        End If

        Exit Function
ErrStockInicioArticulo:
        StockInicioArticulo = 0
        MensajeAtencion("Error al recuperar el stock inicial del artículo.")
    End Function

    Public Function EntalleArticulo(CodArt As String, Fecha As Date, FechaHasta As Date) As Integer
        On Error GoTo ErrEntalleArticulo
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        EntalleArticulo = 0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT SUM(Cantidad) AS CANT FROM StockMovimientos WHERE Eliminado = 0 AND CodArticulo = '" + CodArt.ToString + "' AND Fecha > '" + FechaWin10(Fecha).ToString + "' AND Fecha <= '" + FechaWin10(FechaHasta).ToString + "' AND Origen = 0 AND Destino = 1 AND CodTipoMov = 1"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                If Not IsDBNull(Reader.Item("CANT")) Then
                    EntalleArticulo = Reader.Item("CANT").ToString
                Else
                    EntalleArticulo = 0
                End If
            End If
        End If

        Exit Function
ErrEntalleArticulo:
        EntalleArticulo = 0
        MensajeAtencion("Error al recuperar el entalle del artículo.")
    End Function

    Public Function EntalleArticuloRango(CodArt As String, FechaInicio As Date, FechaFin As Date) As Integer
        On Error GoTo ErrEntalleArticuloRango
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        EntalleArticuloRango = 0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT SUM(Cantidad) AS CANT FROM StockMovimientos WHERE Eliminado = 0 AND CodArticulo = '" + CodArt.ToString + "' AND Fecha >= '" + FechaWin10(FechaInicio).ToString + "' AND Fecha <= '" + FechaWin10(FechaFin).ToString + "' AND Origen = 0 AND Destino = 1 AND CodTipoMov = 1"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                If Not IsDBNull(Reader.Item("CANT")) Then
                    EntalleArticuloRango = Reader.Item("CANT").ToString
                Else
                    EntalleArticuloRango = 0
                End If
            End If
        End If

        Exit Function
ErrEntalleArticuloRango:
        EntalleArticuloRango = 0
        MensajeAtencion("Error al recuperar el entalle del artículo por rango.")
    End Function

    Public Function VentaArticulo(CodArt As String, Local As Integer, FechaInicio As Date, FechaFin As Date) As Integer
        On Error GoTo ErrVentaArticulo
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        VentaArticulo = 0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT SUM(Cantidad) AS CANT FROM StockMovimientos WHERE Eliminado = 0 AND CodArticulo = '" + CodArt.ToString + "' AND Origen = " + Local.ToString + " AND Fecha >= '" + FechaWin10(FechaInicio).ToString + "' AND Fecha <= '" + FechaWin10(FechaFin).ToString + "' AND CodTipoMov IN (4, 5, 8)"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                If Not IsDBNull(Reader.Item("CANT")) Then
                    VentaArticulo = Reader.Item("CANT").ToString
                Else
                    VentaArticulo = 0
                End If
            End If
        End If

        Exit Function
ErrVentaArticulo:
        VentaArticulo = 0
        MensajeAtencion("Error al recuperar la venta del artículo.")
    End Function

    Public Function ValesArticulo(CodArt As String, Local As Integer, FechaInicio As Date, FechaFin As Date) As Integer
        On Error GoTo ErrValesArticulo
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        ValesArticulo = 0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT SUM(Cantidad) AS CANT FROM StockMovimientos WHERE Eliminado = 0 AND CodArticulo = '" + CodArt.ToString + "' AND Origen = " + Local.ToString + " AND Fecha >= '" + FechaWin10(FechaInicio).ToString + "' AND Fecha <= '" + FechaWin10(FechaFin).ToString + "' AND CodTipoMov = 6"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                If Not IsDBNull(Reader.Item("CANT")) Then
                    ValesArticulo = Reader.Item("CANT").ToString
                Else
                    ValesArticulo = 0
                End If
            End If
        End If

        Exit Function
ErrValesArticulo:
        ValesArticulo = 0
        MensajeAtencion("Error al recuperar los vales del artículo.")
    End Function

    Public Function AjusteArticulo(CodArt As String, Local As Integer, FechaInicio As Date, FechaFin As Date) As Integer
        On Error GoTo ErrAjusteArticulo
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        AjusteArticulo = 0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT SUM(Cantidad) AS CANT FROM StockMovimientos WHERE Eliminado = 0 AND CodArticulo = '" + CodArt.ToString + "' AND Origen = " + Local.ToString + " AND Fecha >= '" + FechaWin10(FechaInicio).ToString + "' AND Fecha <= '" + FechaWin10(FechaFin).ToString + "' AND CodTipoMov = 7"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                If Not IsDBNull(Reader.Item("CANT")) Then
                    AjusteArticulo = Reader.Item("CANT").ToString
                Else
                    AjusteArticulo = 0
                End If
            End If
        End If

        Exit Function
ErrAjusteArticulo:
        AjusteArticulo = 0
        MensajeAtencion("Error al recuperar los ajustes del artículo.")
    End Function

    Public Function FallasArticulo(CodArt As String, Local As Integer, FechaInicio As Date, FechaFin As Date) As Integer
        On Error GoTo ErrFallasArticulo
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        FallasArticulo = 0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT SUM(Cantidad) AS CANT FROM StockMovimientos WHERE Eliminado = 0 AND CodArticulo = '" + CodArt.ToString + "' AND Origen = " + Local.ToString + " AND Fecha >= '" + FechaWin10(FechaInicio).ToString + "' AND Fecha <= '" + FechaWin10(FechaFin).ToString + "' AND CodTipoMov = 3"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                If Not IsDBNull(Reader.Item("CANT")) Then
                    FallasArticulo = Reader.Item("CANT").ToString
                Else
                    FallasArticulo = 0
                End If
            End If
        End If

        Exit Function
ErrFallasArticulo:
        FallasArticulo = 0
        MensajeAtencion("Error al recuperar las fallas del artículo.")
    End Function

    Public Function RemitosSumaArticulo(CodArt As String, Local As Integer, FechaInicio As Date, FechaFin As Date) As Integer
        On Error GoTo ErrRemitosSumaArticulo
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        RemitosSumaArticulo = 0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT SUM(Cantidad) AS CANT FROM StockMovimientos WHERE Eliminado = 0 AND CodArticulo = '" + CodArt.ToString + "' AND Fecha >= '" + FechaWin10(FechaInicio).ToString + "' AND Fecha <= '" + FechaWin10(FechaFin).ToString + "' AND CodTipoMov = 1 "
        If Local = 1 Then
            sStr = sStr + "AND Origen = 72 AND Destino = 1 "
        ElseIf Local = 72 Then
            sStr = sStr + "AND Origen = 1 AND Destino = 72 "
        End If
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                If Not IsDBNull(Reader.Item("CANT")) Then
                    RemitosSumaArticulo = Reader.Item("CANT").ToString
                Else
                    RemitosSumaArticulo = 0
                End If
            End If
        End If

        Exit Function
ErrRemitosSumaArticulo:
        RemitosSumaArticulo = 0
        MensajeAtencion("Error al recuperar los remitos SUMA del artículo.")
    End Function

    Public Function RemitosRestaArticulo(CodArt As String, Local As Integer, FechaInicio As Date, FechaFin As Date) As Integer
        On Error GoTo ErrRemitosRestaArticulo
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        RemitosRestaArticulo = 0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT SUM(Cantidad) AS CANT FROM StockMovimientos WHERE Eliminado = 0 AND CodArticulo = '" + CodArt.ToString + "' AND Fecha >= '" + FechaWin10(FechaInicio).ToString + "' AND Fecha <= '" + FechaWin10(FechaFin).ToString + "' AND CodTipoMov = 1 "
        If Local = 1 Then
            sStr = sStr + "AND Origen = 1 AND Destino = 72 "
        ElseIf Local = 72 Then
            sStr = sStr + "AND Origen = 72 AND Destino = 1 "
        End If
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                If Not IsDBNull(Reader.Item("CANT")) Then
                    RemitosRestaArticulo = Reader.Item("CANT").ToString
                Else
                    RemitosRestaArticulo = 0
                End If
            End If
        End If

        Exit Function
ErrRemitosRestaArticulo:
        RemitosRestaArticulo = 0
        MensajeAtencion("Error al recuperar los remitos RESTA del artículo.")
    End Function

    Public Function CambiosArticulo(CodArt As String, Local As Integer, FechaInicio As Date, FechaFin As Date) As Integer
        On Error GoTo ErrCambiosArticulo
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        CambiosArticulo = 0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT SUM(Cantidad) AS CANT FROM StockMovimientos WHERE Eliminado = 0 AND CodArticulo = '" + CodArt.ToString + "' AND Origen = " + Local.ToString + " AND Fecha >= '" + FechaWin10(FechaInicio).ToString + "' AND Fecha <= '" + FechaWin10(FechaFin).ToString + "' AND CodTipoMov = 10"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                If Not IsDBNull(Reader.Item("CANT")) Then
                    CambiosArticulo = Reader.Item("CANT").ToString
                Else
                    CambiosArticulo = 0
                End If
            End If
        End If

        Exit Function
ErrCambiosArticulo:
        CambiosArticulo = 0
        MensajeAtencion("Error al recuperar los cambios del artículo.")
    End Function

    Public Function DevolucionesArticulo(CodArt As String, Local As Integer, FechaInicio As Date, FechaFin As Date) As Integer
        On Error GoTo ErrDevolucionesArticulo
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        DevolucionesArticulo = 0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT SUM(Cantidad) AS CANT FROM StockMovimientos WHERE Eliminado = 0 AND CodArticulo = '" + CodArt.ToString + "' AND Origen = " + Local.ToString + " AND Fecha >= '" + FechaWin10(FechaInicio).ToString + "' AND Fecha <= '" + FechaWin10(FechaFin).ToString + "' AND CodTipoMov = 9"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows() Then
            If Reader.Read() Then
                If Not IsDBNull(Reader.Item("CANT")) Then
                    DevolucionesArticulo = Reader.Item("CANT").ToString
                Else
                    DevolucionesArticulo = 0
                End If
            End If
        End If

        Exit Function
ErrDevolucionesArticulo:
        DevolucionesArticulo = 0
        MensajeAtencion("Error al recuperar las devoluciones del artículo.")
    End Function

    Public Function ArticuloStockInicialViejo(CodArt As String, Fecha As Date, Color As String) As Integer
        On Error GoTo ErrArticuloStockInicialViejo
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String
        Dim FechaStock As Date

        ArticuloStockInicialViejo = 0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        'primero agarro la ultima fecha de stock incial
        sStr = "SELECT TOP 1 Fecha FROM PrendasStockTeñido WHERE CodArticulo = '" + CodArt.ToString + "' AND Fecha <= '" + FechaWin10(Fecha).ToString + "'"
        sStr = sStr + " AND COLOR='" + Color + "' ORDER BY Fecha DESC"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                FechaStock = Reader.Item("Fecha").ToString
            End If
        End If

        If FechaStock = "#12:00:00#" Or FechaStock = "12:00:00 a.m." Then Exit Function

        'Inicio de Fecha de movimientos del Stock
        sStr = "SELECT isnull(sum(Cantidad),0) as Cantidad FROM PrendasStockTeñido WHERE CodArticulo = '" + CodArt.ToString + "' "
        sStr = sStr + " AND COLOR='" + Color + "' AND Eliminado = 0 AND Fecha = '" + FechaWin10(FechaStock).ToString + "' "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                ArticuloStockInicialViejo = Reader.Item("Cantidad").ToString
            End If
        End If

        Exit Function
ErrArticuloStockInicialViejo:
        ArticuloStockInicialViejo = 0
        MensajeAtencion("Error al cargar el stock inicial (Viejo).")

    End Function

    Public Function ArticuloStockInicialViejo(CodArt As String, Talle As Integer, Color As String, Fecha As Date) As Integer
        On Error GoTo ErrArticuloStockInicialViejo
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String
        Dim FechaStock As Date

        ArticuloStockInicialViejo = 0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        If Color = "" Then
            Color = "IN ('', 'CRUDO') "
        Else
            Color = "= '" + Color.ToString + "'"
        End If
        'Inicio de Fecha de movimientos del Stock
        sStr = "SELECT TOP 1 Cantidad FROM PrendasStockTeñido WHERE CodArticulo = '" + CodArt.ToString + "' AND Talle = " + Talle.ToString + " AND Color " + Color.ToString + " AND Eliminado = 0 AND Fecha <= '" + Format(Fecha, "yyyyMMdd") + "' ORDER BY Fecha DESC"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                ArticuloStockInicialViejo = Reader.Item("Cantidad").ToString
            End If
        End If

        Exit Function
ErrArticuloStockInicialViejo:
        ArticuloStockInicialViejo = 0
        MensajeAtencion("Error al cargar el stock inicial (Viejo). Art:" + CodArt)

    End Function

    Public Function MovsArticuloViejo(CodArt As String, Talle As Integer, Color As String, Fecha As Date) As Integer
        On Error GoTo ErrMovsArticuloViejo
        Dim Command As SqlCommand
        Dim Reader, ReaderMovs As SqlDataReader
        Dim sStr As String

        Dim FechaStock, FechaInicio, FechaFin As Date
        MovsArticuloViejo = 0

        FechaInicio = "01/" + CompletarCaracteresIzquierda(Fecha.Month, 2, "0").ToString + "/" + Fecha.Year.ToString
        FechaFin = FechaInicio.AddMonths(1)
        FechaFin = FechaFin.AddDays(-1)

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        'Inicio de Fecha de movimientos del Stock
        sStr = "SELECT TOP 1 Fecha FROM PrendasStockTeñido WHERE CodArticulo = '" + CodArt.ToString + "' AND Talle = " + Talle.ToString + " AND Color = '" + Color.ToString + "' AND Fecha <= '" + Format(Fecha, "yyyyMMdd") + "' ORDER BY Fecha DESC"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        ReaderMovs = Command.ExecuteReader()
        If ReaderMovs.HasRows Then
            If ReaderMovs.Read Then
                FechaStock = ReaderMovs.Item("Fecha").ToString
            End If
        End If

        'Sumo los partes de terminación
        sStr = "SELECT CodArticulo, Color, Talle, SUM(Cantidad) AS CANT FROM PrendasPartesTerminacion P INNER JOIN DetPrendasPartesTerminacion D ON P.id = D.idParteTerminacion "
        sStr = sStr + "WHERE Fecha >= '" + Format(FechaStock, "yyyyMMdd").ToString + "' AND Fecha <= '" + Format(FechaFin, "yyyyMMdd").ToString + "'  AND CodArticulo = '" + CodArt.ToString + "' AND Talle = " + Talle.ToString + " AND Color = '" + Color.ToString + "' AND D.Eliminado = 0 AND P.Eliminado = 0 "
        sStr = sStr + "GROUP BY CodArticulo, Talle, Color"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        ReaderMovs = Command.ExecuteReader()
        If ReaderMovs.HasRows Then
            If ReaderMovs.Read Then
                If Not IsDBNull(ReaderMovs.Item("CANT")) Then MovsArticuloViejo = MovsArticuloViejo + ReaderMovs.Item("CANT")
            End If
        End If

        'Resto los partes de teñido
        sStr = "SELECT CodArticulo, Color, SUM(" + NombreTalle(Talle).ToString + ") AS CANT FROM PrendasPartesTeñido P INNER JOIN DetPrendasPartesTeñido D ON P.id = D.idParteTeñido "
        sStr = sStr + "WHERE Fecha >= '" + Format(FechaStock, "yyyyMMdd").ToString + "' AND Fecha <= '" + Format(FechaFin, "yyyyMMdd").ToString + "' AND CodArticulo = '" + CodArt.ToString + "' AND Color = '" + Color.ToString + "' AND D.Eliminado = 0 AND P.Eliminado = 0 "
        sStr = sStr + "GROUP BY CodArticulo, Color"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        ReaderMovs = Command.ExecuteReader()
        If ReaderMovs.HasRows Then
            If ReaderMovs.Read Then
                If Not IsDBNull(ReaderMovs.Item("CANT")) Then MovsArticuloViejo = MovsArticuloViejo - ReaderMovs.Item("CANT")
            End If
        End If

        'Tomo en cuenta los ajustes
        sStr = "SELECT CodArticulo, Color, Talle, SUM(Cantidad) AS CANT FROM PrendasTeñidoAjusteStock "
        sStr = sStr + "WHERE Fecha >= '" + Format(FechaStock, "yyyyMMdd").ToString + "' AND Fecha <= '" + Format(FechaFin, "yyyyMMdd").ToString + "' AND CodArticulo = '" + CodArt.ToString + "' AND Talle = " + Talle.ToString + " AND Color = '" + Color.ToString + "' AND Eliminado = 0 "
        sStr = sStr + "GROUP BY CodArticulo, Talle, Color"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        ReaderMovs = Command.ExecuteReader()
        If ReaderMovs.HasRows Then
            If ReaderMovs.Read Then
                MovsArticuloViejo = MovsArticuloViejo + ReaderMovs.Item("CANT")
            End If
        End If

        Exit Function
ErrMovsArticuloViejo:
        MovsArticuloViejo = 0
        MensajeAtencion("Error al calcular los movimientos del artículo (Viejo). Art:" + CodArt.ToString)

    End Function

    Public Function MovsArticuloViejo(CodArt As String, Fecha As Date, Color As String) As Integer
        On Error GoTo ErrMovsArticuloViejo
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String
        Dim FechaStock, FechaInicio, FechaFin As Date

        MovsArticuloViejo = 0

        FechaInicio = "01/" + CompletarCaracteresIzquierda(Fecha.Month, 2, "0").ToString + "/" + Fecha.Year.ToString
        FechaFin = FechaInicio.AddMonths(1)
        FechaFin = FechaFin.AddDays(-1)

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        'Inicio de Fecha de movimientos del Stock
        sStr = "SELECT TOP 1 Fecha FROM PrendasStockTeñido WHERE CodArticulo = '" + CodArt.ToString + "' AND Fecha <= '" + FechaWin10(Fecha).ToString + "'"
        sStr = sStr + " AND COLOR='" + Color + "' ORDER BY Fecha DESC"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                FechaStock = Reader.Item("Fecha").ToString
            End If
        End If

        If FechaStock = "#12:00:00#" Or FechaStock = "12:00:00 a.m." Then Exit Function

        'Sumo los partes de terminación
        sStr = "SELECT CodArticulo, SUM(Cantidad) AS CANT FROM PrendasPartesTerminacion P INNER JOIN DetPrendasPartesTerminacion D ON P.id = D.idParteTerminacion "
        sStr = sStr + "WHERE Fecha >= '" + FechaWin10(FechaStock).ToString + "' AND Fecha <= '" + FechaWin10(FechaFin).ToString + "' "
        sStr = sStr + " AND COLOR='" + Color + "' AND CodArticulo = '" + CodArt.ToString + "' AND D.Eliminado = 0 AND P.Eliminado = 0 "
        sStr = sStr + "GROUP BY CodArticulo"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                If Not IsDBNull(Reader.Item("CANT")) Then MovsArticuloViejo = MovsArticuloViejo + Reader.Item("CANT")
            End If
        End If

        'Resto los partes de teñido
        sStr = "SELECT CodArticulo, SUM(XXS+XS+S+M+L+XL+XXL) AS CANT FROM PrendasPartesTeñido P INNER JOIN DetPrendasPartesTeñido D ON P.id = D.idParteTeñido "
        sStr = sStr + "WHERE Fecha >= '" + FechaWin10(FechaStock).ToString + "' AND Fecha <= '" + FechaWin10(FechaFin).ToString + "' "
        sStr = sStr + " AND CodArticulo = '" + CodArt.ToString + "' AND D.Eliminado = 0 AND P.Eliminado = 0 AND COLOR='" + Color + "' GROUP BY CodArticulo"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                If Not IsDBNull(Reader.Item("CANT")) Then MovsArticuloViejo = MovsArticuloViejo - Reader.Item("CANT")
            End If
        End If

        'Tomo en cuenta los ajustes
        sStr = "SELECT CodArticulo, SUM(Cantidad) AS CANT FROM PrendasTeñidoAjusteStock "
        sStr = sStr + "WHERE Fecha >= '" + FechaWin10(FechaStock).ToString + "' AND Fecha <= '" + FechaWin10(FechaFin).ToString + "' "
        sStr = sStr + " AND COLOR='" + Color + "' AND CodArticulo = '" + CodArt.ToString + "' AND Eliminado = 0 "
        sStr = sStr + "GROUP BY CodArticulo"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                MovsArticuloViejo = MovsArticuloViejo + Reader.Item("CANT")
            End If
        End If

        Exit Function
ErrMovsArticuloViejo:
        MovsArticuloViejo = 0
        MensajeAtencion("Error al calcular los movimientos del artículo (Viejo).")

    End Function

    Public Function CalcularCostodeHilado(ByVal NombreHilado As String) As Double
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String
        Dim CostoHilado, Precio, Costo, CostoTotal As Double

        CostoHilado = 0.0

        If NombreHilado = "MOLINE CARDADO" Then
            NombreHilado = "MOLINE DE CARDADO"
        End If

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "select Id from HilamarHilados WHERE Id in (SELECT DISTINCT(IDHIL) FROM HilamarcompcostosHilados WHERE EsInterno = 0) "
        sStr = sStr + " AND Descripcion like '%" + NombreHilado + "%'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then

                sStr = "select * from HilamarCompCostosHilados where IdHil = " + Reader.Item("Id").ToString + " AND isnull(EsInterno,0)=0"
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
                    Loop
                    Reader.NextResult()
                Loop

                CostoHilado = CostoTotal

            End If
        End If

        Return CostoHilado
    End Function

    Public Function ObtengoCostoDelElemento(ByVal Tipo As String, ByVal IdComp As String) As Double
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String
        Dim Retorno As Double

        Retorno = 0.0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        If Tipo = "MP" Then
            sStr = "SELECT * FROM HilamarMateriasPrimas WHERE Id = " + IdComp + ""
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read Then
                    If Reader.Item("Moneda").ToString = "Dolares" Then
                        Retorno = ObtenerCotizacionDolarHilamar() * Reader.Item("CostoPorKilo")
                    Else
                        Retorno = Reader.Item("CostoPorKilo")
                    End If
                End If
            End If
        ElseIf Tipo = "PG" Then
            If IdComp = "HH" Then
                sStr = "SELECT * FROM HilamarCostosParametrosGrales "
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Reader = Command.ExecuteReader()
                If Reader.HasRows Then
                    If Reader.Read Then
                        Retorno = Reader.Item("CostoHoraHombre") * Reader.Item("FactorMultiplicadordelValorHoraHombre")
                    End If
                End If
            ElseIf IdComp = "GAS" Then
                sStr = "SELECT * FROM HilamarCostosParametrosGrales "
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Reader = Command.ExecuteReader()
                If Reader.HasRows Then
                    If Reader.Read Then
                        Retorno = (Reader.Item("TotalCamuzzi") + Reader.Item("TotalEnergy")) / Reader.Item("M3GasConsumidos")
                    End If
                End If
            ElseIf IdComp = "LUZ" Then
                sStr = "SELECT * FROM HilamarCostosParametrosGrales "
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Reader = Command.ExecuteReader()
                If Reader.HasRows Then
                    If Reader.Read Then
                        Retorno = Reader.Item("TotalEdea") / Reader.Item("KWConsumidos")
                    End If
                End If
            ElseIf IdComp = "OS" Then
                sStr = "SELECT * FROM HilamarCostosParametrosGrales "
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Reader = Command.ExecuteReader()
                If Reader.HasRows Then
                    If Reader.Read Then
                        Retorno = Reader.Item("TotalObrasSanitarias") / Reader.Item("M3AguaConsumidos")
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

    Public Function ObtenerComposiciondeCostos(ByVal TipoElemento As String, ByVal IdElemento As String) As Double
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr, Descripcion As String
        Dim Precio, Costo, CostoTotal As Double

        Descripcion = ""
        CostoTotal = 0.0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        'Si es Hilado Interno debo ver si lleva composicion de costos o es costo fijo y de acuerdo a eso hago o no el bucle
        If TipoElemento = "HILADO INTERNO" Then
            sStr = "SELECT * FROM HilamarHiladosInternos WHERE Id = " + IdElemento
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read Then
                    If Not IsDBNull(Reader.Item("Moneda")) Or Not IsDBNull(Reader.Item("CostoPorKilo")) Then

                        If Reader.Item("Moneda").ToString = "Dolares" Then
                            Precio = ObtenerCotizacionDolarHilamar() * Reader.Item("CostoPorKilo")
                        Else
                            Precio = Reader.Item("CostoPorKilo")
                        End If

                        Costo = 1 * Precio

                        CostoTotal = CostoTotal + Costo

                    End If
                End If
            End If

        End If

        If TipoElemento = "HILADO" Then
            sStr = "SELECT * FROM HilamarCompCostosHilados WHERE IdHil = " + IdElemento + " AND ISNULL(EsInterno, 0) = 0"
        ElseIf TipoElemento = "HILADO INTERNO" Then
            sStr = "SELECT * FROM HilamarCompCostosHilados WHERE IdHil = " + IdElemento + " AND ISNULL(EsInterno, 0) = 1"
        Else
            sStr = "SELECT * FROM HilamarCompCostosProcesos WHERE IdProc = " + IdElemento
        End If
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
            Loop
            Reader.NextResult()
        Loop

        ObtenerComposiciondeCostos = CostoTotal

    End Function

    Private Function ObtenerCotizacionDolarHilamar() As Double
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String
        Dim CotizDolar As Double

        CotizDolar = 0.0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT * FROM HilamarMonedas WHERE Nombre = 'Dolares'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                CotizDolar = Reader.Item("Cotizacion")
            End If
        End If
        Return CotizDolar
    End Function

    Public Function NroCeldaPorID(id As Integer) As Integer
        On Error GoTo ErrNroCeldaPorID
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        NroCeldaPorID = 0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT * FROM ProdCeldas WHERE id = " + id.ToString
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                NroCeldaPorID = Reader.Item("NroCelda").ToString
            End If
        End If

        Exit Function
ErrNroCeldaPorID:
        NroCeldaPorID = 0
        MensajeAtencion("Error al recuperar el número de celda por id.")
    End Function

    Public Function CategoriaYNombreArticuloPorID(ByVal id As Integer) As String
        On Error GoTo ErrCategoriaNombreArticuloPorID
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        CategoriaYNombreArticuloPorID = ""

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT C.nombreCategoria, A.NombreArt FROM HilamarArticulos A " + _
                "INNER JOIN HilamarArticulosCategorias C on A.Categoria = C.id " + _
                "WHERE A.id = " + id.ToString
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                CategoriaYNombreArticuloPorID = "(" & Trim(Reader.Item("nombreCategoria").ToString) & ") " & Trim(Reader.Item("NombreArt").ToString)
            End If
        End If

        Exit Function
ErrCategoriaNombreArticuloPorID:
        CategoriaYNombreArticuloPorID = ""
        MensajeAtencion("Error al recuperar el nombre del Artículo.")
    End Function

End Module