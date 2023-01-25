Imports System.Windows.Forms
Imports System.Threading
Imports System.Net.Sockets
Imports System.IO
Imports System.Text

Module Telnet

    Dim clientSocket As New TcpClient()
    Dim serverStream As NetworkStream
    Dim readData As String
    Dim infiniteCounter As Integer

    Public Conectado As Boolean

    '***Telnet Options***
    Private Const OPT_BIN As Integer = 0 ' Binary Transmission
    Private Const OPT_ECHO As Integer = 1 ' Echo
    Private Const OPT_RECN As Integer = 2 ' Reconnection
    Private Const OPT_SUPP As Integer = 3 ' Suppress Go Ahead
    Private Const OPT_APRX As Integer = 4 ' Approx Message Size Negotiation
    Private Const OPT_STAT As Integer = 5 ' Status
    Private Const OPT_TIM As Integer = 6 ' Timing Mark
    Private Const OPT_REM As Integer = 7 ' Remote Controlled Trans and Echo
    Private Const OPT_OLW As Integer = 8 ' Output Line Width
    Private Const OPT_OPS As Integer = 9 ' Output Page Size
    Private Const OPT_OCRD As Integer = 10 ' Output Carriage-Return Disposition
    Private Const OPT_OHT As Integer = 11 ' Output Horizontal Tabstops
    Private Const OPT_OHTD As Integer = 12 ' Output Horizontal Tab Disposition
    Private Const OPT_OFD As Integer = 13 ' Output Formfeed Disposition
    Private Const OPT_OVT As Integer = 14 ' Output Vertical Tabstops
    Private Const OPT_OVTD As Integer = 15 ' Output Vertical Tab Disposition
    Private Const OPT_OLD As Integer = 16 ' Output Linefeed Disposition
    Private Const OPT_EXT As Integer = 17 ' Extended ASCII
    Private Const OPT_LOGO As Integer = 18 ' Logout
    Private Const OPT_BYTE As Integer = 19 ' Byte Macro
    Private Const OPT_DATA As Integer = 20 ' Data Entry Terminal
    Private Const OPT_SUP As Integer = 21 ' SUPDUP
    Private Const OPT_SUPO As Integer = 22 ' SUPDUP Output
    Private Const OPT_SNDL As Integer = 23 ' Send Location
    Private Const OPT_TERM As Integer = 24 ' Terminal Type
    Private Const OPT_EOR As Integer = 25 ' End of Record
    Private Const OPT_TACACS As Integer = 26 ' TACACS User Identification
    Private Const OPT_OM As Integer = 27 ' Output Marking
    Private Const OPT_TLN As Integer = 28 ' Terminal Location Number
    Private Const OPT_3270 As Integer = 29 ' Telnet 3270 Regime
    Private Const OPT_X3 As Integer = 30 ' X.3 PAD
    Private Const OPT_NAWS As Integer = 31 ' Negotiate About Window Size
    Private Const OPT_TS As Integer = 32 ' Terminal Speed
    Private Const OPT_RFC As Integer = 33 ' Remote Flow Control
    Private Const OPT_LINE As Integer = 34 ' Linemode
    Private Const OPT_XDL As Integer = 35 ' X Display Location
    Private Const OPT_ENVIR As Integer = 36 ' Telnet Environment Option
    Private Const OPT_AUTH As Integer = 37 ' Telnet Authentication Option
    Private Const OPT_NENVIR As Integer = 39 ' Telnet Environment Option
    '***End of Telnet Options***


    '***Telnet Command: 240~255***
    Private Const CMD_SE As Integer = 240 'end sub negotiation
    Private Const CMD_NOP As Integer = 241 'nop
    Private Const CMD_DM As Integer = 242 'data mark--for connect. cleaning
    Private Const CMD_BRK As Integer = 243 'break
    Private Const CMD_IP As Integer = 244 'interrupt process--permanently
    Private Const CMD_AO As Integer = 245 'abort output--but let prog finish
    Private Const CMD_AYT As Integer = 246 'are you there
    Private Const CMD_EC As Integer = 247 'erase the current character
    Private Const CMD_EL As Integer = 248 'erase the current line
    Private Const CMD_GA As Integer = 249 'you may reverse the line
    Private Const CMD_SB As Integer = 250 'interpret as subnegotiation
    Private Const CMD_WILL As Integer = 251 'I will use option
    Private Const CMD_WONT As Integer = 252 'I won't use option
    Private Const CMD_DO As Integer = 253 'please, you use option
    Private Const CMD_DONT As Integer = 254 'you are not to use option
    Private Const CMD_IAC As Integer = 255 'Interpret Aa Command:
    '***End of Telnet Command***

    Private Const MOD_INIT As Integer = 0
    Private Const MOD_IAC_START As Integer = 1
    Private Const MOD_DONT As Integer = 2
    Private Const MOD_DO As Integer = 3
    Private Const MOD_WONT As Integer = 4
    Private Const MOD_WILL As Integer = 5
    Private Const MOD_SB As Integer = 6
    Private Const MOD_WAITFOR_SE As Integer = 7

    Private DispBuf() As Byte
    Private DispData As String

    'display the server echo info to the client richtextbox
    Private Sub ShowText()
        'If Me.InvokeRequired Then
        '    Me.Invoke(New MethodInvoker(AddressOf ShowText))
        'Else
        '    txtDisplay.Text = String.Concat(txtDisplay.Text, readData) ' txtDisplay.Text + Environment.NewLine + readData
        '    txtDisplay.SelectionStart = txtDisplay.TextLength
        '    txtDisplay.ScrollToCaret()
        'End If
    End Sub

    'connect to the remote Linux/Unix server
    'Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
    Public Sub Conectar()
        Try
            clientSocket.Connect("192.168.0.12", 23)
            serverStream = clientSocket.GetStream()
            Dim telnetThread As Thread = New Thread(AddressOf RunClient)
            telnetThread.Start()
            Conectado = True
        Catch ex As Exception
            MessageBox.Show("Cerrado aplicación cliente.")
        End Try
    End Sub

    'deal with client socket stream data
    Public Sub RunClient()
        On Error Resume Next
        Do While (clientSocket.Connected)
            serverStream = clientSocket.GetStream()
            Dim inStream(10240) As Byte
            If Not clientSocket.Connected Then Exit Sub
            serverStream.Read(inStream, 0, clientSocket.ReceiveBufferSize)
            GetDispData(inStream)
            readData = DispData
            DispData = ""
            ShowText()
        Loop
    End Sub

    Public Function GetDispData(ByRef RecvData() As Byte) As Long
        Dim i As Long
        Dim j As Long
        Dim SB_Option As Byte
        Dim CurMod As Integer
        Dim ReplyBuf As String = ""
        Dim strReplyCmd As String = ""
        Dim byteReplyCmd() As Byte
        Dim sep As String
        Dim B As Byte
        Dim u As Long


        'On Error GoTo ErrHandLer

        'IAC --> WILL/DO/WONT/DONT --> OptionID
        'IAC --> SB --> options data --> SE

        CurMod = MOD_INIT
        u = UBound(RecvData)
        ReDim DispBuf(u)
        j = 0 'Index of DispBuf
        For i = 0 To u 'one byte by byte
            B = RecvData(i)
            If B = 0 Then
                'discard NULL value
                'do nothing
            Else
                Select Case CurMod
                    Case MOD_INIT
                        If B = CMD_IAC Then '255
                            CurMod = MOD_IAC_START
                        Else
                            DispBuf(j) = RecvData(i)
                            j = j + 1
                        End If
                    Case MOD_IAC_START
                        Select Case B
                            Case CMD_DONT
                                CurMod = MOD_DONT
                            Case CMD_DO
                                CurMod = MOD_DO
                            Case CMD_WONT
                                CurMod = MOD_WONT
                            Case CMD_WILL
                                CurMod = MOD_WILL
                            Case CMD_SB 'wait for a SE to end
                                CurMod = MOD_SB
                        End Select
                    Case MOD_DO
                        'Server Request for option
                        Select Case RecvData(i)
                            Case OPT_BIN '0 Binary Transmission
                                ReplyBuf = CMD_IAC & "," & CMD_WILL & "," & RecvData(i)
                            Case OPT_SUPP '3 Suppress Go Ahead
                                ReplyBuf = CMD_IAC & "," & CMD_WILL & "," & RecvData(i)
                            Case OPT_TERM '24 Terminal Type
                                ReplyBuf = CMD_IAC & "," & CMD_WILL & "," & RecvData(i)
                            Case OPT_NAWS '31 Negotiate About Window Size (132 columns, 0 rows will receive all data in one time)
                                ReplyBuf = CMD_IAC & "," & CMD_WILL & "," & RecvData(i) & "," & _
                                    CMD_IAC & "," & CMD_SB & "," & OPT_NAWS & "," & 0 & "," & 132 & "," & 0 & "," & 0 & "," & CMD_IAC & "," & CMD_SE
                            Case Else
                                ReplyBuf = CMD_IAC & "," & CMD_WONT & "," & RecvData(i)
                        End Select
                        CurMod = MOD_INIT
                    Case MOD_WILL
                        Select Case RecvData(i)
                            Case OPT_BIN
                                ReplyBuf = CMD_IAC & "," & CMD_DO & "," & RecvData(i)
                            Case OPT_ECHO
                                'If Not bInEchoRx Then
                                '    bInEchoRx = True
                                ReplyBuf = CMD_IAC & "," & CMD_DO & "," & RecvData(i)
                                'End If
                            Case OPT_SUPP '3 Suppress Go Ahead
                                ReplyBuf = CMD_IAC & "," & CMD_DO & "," & RecvData(i)
                            Case Else
                                ReplyBuf = CMD_IAC & "," & CMD_DONT & "," & RecvData(i)
                        End Select
                        CurMod = MOD_INIT
                    Case MOD_WONT
                        Select Case RecvData(i)
                            Case OPT_ECHO '1
                                'If bInEchoRx Then
                                '    bInEchoRx = False
                                ReplyBuf = CMD_IAC & "," & CMD_DONT & "," & RecvData(i)
                                'End If
                            Case OPT_SUPP
                                ReplyBuf = CMD_IAC & "," & CMD_DONT & "," & RecvData(i)
                        End Select

                        CurMod = MOD_INIT
                    Case MOD_DONT
                        Select Case RecvData(i)
                            Case OPT_ECHO
                                ReplyBuf = CMD_IAC & "," & CMD_WONT & "," & RecvData(i)
                            Case OPT_NAWS
                                ReplyBuf = CMD_IAC & "," & CMD_WONT & "," & RecvData(i)
                        End Select
                        CurMod = MOD_INIT
                    Case MOD_SB 'Indicates that what follows is subnegotiation of the indicated option.
                        Select Case RecvData(i)
                            Case OPT_TERM
                                SB_Option = OPT_TERM
                                CurMod = MOD_WAITFOR_SE
                            Case OPT_NENVIR
                                SB_Option = OPT_NENVIR
                                CurMod = MOD_WAITFOR_SE
                            Case Else
                                CurMod = MOD_INIT
                        End Select
                    Case MOD_WAITFOR_SE
                        If RecvData(i) = CMD_SE Then
                            If SB_Option = OPT_TERM Then
                                'IAC SB TERMINAL-TYPE IS ... IAC SE (ex:IAC SB Terminal-Type IS ANSI IAC SE)
                                'The code for IS is 0
                                ReplyBuf = CMD_IAC & "," & CMD_SB & "," & OPT_TERM & "," & 0 & "," & _
                                    Asc("V") & "," & Asc("T") & "," & Asc("1") & "," & Asc("0") & "," & Asc("0") & _
                                    "," & CMD_IAC & "," & CMD_SE
                            End If
                            CurMod = MOD_INIT
                        End If
                End Select

                If ReplyBuf <> "" Then
                    If strReplyCmd = "" Then
                        sep = ""
                    Else
                        sep = ","
                    End If
                    strReplyCmd = strReplyCmd & sep & ReplyBuf
                    ReplyBuf = ""
                End If

            End If
        Next

        If j > 0 Then 'there is data
            ReDim Preserve DispBuf(j - 1)
            'DispData = StrConv(DispBuf, vbUnicode)

            Dim char1 As Byte

            For Each char1 In DispBuf
                DispData = String.Concat(DispData, Chr(char1))
            Next

            'strText = BitConverter.ToString(DispBuf) 'byte to string
            'DispData = BitConverter.ToString(Encoding.Convert(Encoding.Unicode, Encoding.ASCII, Encoding.Unicode.GetBytes(strText)))

            'Unix to Dos
            Dim dosbuf As String
            dosbuf = Replace(DispData, vbCrLf, Chr(10))
            dosbuf = Replace(dosbuf, Chr(13), "")
            dosbuf = Replace(dosbuf, Chr(10), vbCrLf)
            DispData = dosbuf
        Else
            DispData = ""
        End If
        GetDispData = j 'lenght of data
        'convert it to byte()
        Dim buf As Object
        If strReplyCmd <> "" Then
            buf = Split(strReplyCmd, ",")
            ReDim byteReplyCmd(UBound(buf)) 'As Byte
            For i = 0 To UBound(buf)
                byteReplyCmd(i) = Val(buf(i))
            Next
            'SockRlogin.SendData(byteReplyCmd) 'auto respond TELNET CMD
            serverStream.Write(byteReplyCmd, 0, byteReplyCmd.Length)
        End If


    End Function

    'command console to send the info to the server
    Public Sub EnviarComando(ByVal Comando As String)
        If Conectado Then
            Dim outStream As Byte()
            outStream = Encoding.ASCII.GetBytes(Comando.ToString & vbCr)
            serverStream.Write(outStream, 0, outStream.Length)
        End If
    End Sub

    Public Sub Desconectar()
        clientSocket.Close()
        Conectado = False
    End Sub


End Module
