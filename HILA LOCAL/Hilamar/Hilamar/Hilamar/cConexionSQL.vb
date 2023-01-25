Imports System.Data.SqlClient

Public Class cConexionSQL
    Public SQLConn As SqlConnection = New SqlConnection()
    Public Resultado As String


    Public Sub Conectar(ByVal Tipo As String)
        On Error GoTo ErrConexion
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String
        Dim Servidor, Base, Usuario, Contraseña As String
        Servidor = ""
        Base = ""
        Usuario = ""
        Contraseña = ""
        If SQLConn.State = ConnectionState.Open Then
            Exit Sub
        End If
        Base = "AppTextilana"
        Servidor = "SERVERSQL"
        Usuario = "admin"
        Contraseña = "admin"
        SQLConn.ConnectionString = "Data Source=" & Servidor & ";Initial Catalog=" & Base & ";User Id=" & Usuario & ";Password=" & Contraseña & ";MultipleActiveResultSets=True;Persist Security Info=False;Connection Timeout=0"
        SQLConn.Open()
        If Tipo <> "AppTextilana" And SQLConn.State = ConnectionState.Open Then
            sStr = "SELECT * FROM ConfigBasesDeDatos WHERE Base = '" + Tipo + "'"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read Then
                    Servidor = Reader.Item("Servidor").ToString
                    Base = Reader.Item("Base").ToString
                    Usuario = Reader.Item("Usuario").ToString
                    Contraseña = Reader.Item("Contraseña").ToString
                End If
            End If
            Desconectar()
            Base = Tipo
            SQLConn.ConnectionString = "Data Source=" & Servidor & ";Initial Catalog=" & Base & ";User Id=" & Usuario & ";Password=" & Contraseña & ";MultipleActiveResultSets=True;Persist Security Info=False" ';Connection Timeout=0
            SQLConn.Open()
        ElseIf Tipo = "AppTextilana" And SQLConn.State = ConnectionState.Closed Then
            SQLConn.ConnectionString = "Data Source=" & Servidor & ";Initial Catalog=" & Base & ";User Id=" & Usuario & ";Password=" & Contraseña & ";MultipleActiveResultSets=True;Persist Security Info=False;Connection Timeout=0"
            SQLConn.Open()
        End If
        If ConnectionState.Open Then
            Resultado = "Conexión correcta!"
        Else
            Resultado = "No se puede conectar!"
        End If
        Exit Sub
ErrConexion:
        Resultado = Err.Description
    End Sub

    '    Public Sub Conectar()
    '        On Error GoTo ErrConexion
    '        If SQLConn.State = ConnectionState.Open Then
    '            Exit Sub
    '        End If
    '        Base = "BASE10"
    '        Servidor = "192.168.0.10"
    '        SQLConn.ConnectionString = "Data Source=" & Servidor & ";Initial Catalog=" & Base & ";User Id=" & Usuario & ";Password=" & Contraseña & ";MultipleActiveResultSets=True;Persist Security Info=False"
    '        SQLConn.Open()
    '        If ConnectionState.Open Then
    '            Resultado = "Conexión correcta!"
    '        End If
    '        Exit Sub
    'ErrConexion:
    '        Resultado = Err.Description
    '    End Sub

    '    Public Sub ConectarApp()
    '        On Error GoTo ErrConexionAct
    '        If SQLConn.State = ConnectionState.Open Then
    '            Exit Sub
    '        End If
    '        Base = "AppTextilana"
    '        Servidor = "192.168.0.10"
    '        SQLConn.ConnectionString = "Data Source=" & Servidor & ";Initial Catalog=" & Base & ";User Id=" & Usuario & ";Password=" & Contraseña & ";MultipleActiveResultSets=True;Persist Security Info=False"
    '        SQLConn.Open()
    '        If ConnectionState.Open Then
    '            Resultado = "Conexión correcta!"
    '        End If
    '        Exit Sub
    'ErrConexionAct:
    '        Resultado = Err.Description
    '    End Sub

    '    Public Sub ConectarLaboro()
    '        On Error GoTo ErrConexionAct
    '        Dim BaseLab, ServidorLab, UsuLab, PassLab As String
    '        If SQLConn.State = ConnectionState.Open Then
    '            Desconectar()
    '        End If
    '        BaseLab = "LABORO01"
    '        ServidorLab = "ServerSQL\MSSQL54"
    '        UsuLab = "JULIA"
    '        PassLab = "JULIA"
    '        SQLConn.ConnectionString = "Data Source=" & ServidorLab & ";Initial Catalog=" & BaseLab & ";User Id=" & UsuLab & ";Password=" & PassLab & ";MultipleActiveResultSets=True;Persist Security Info=False"
    '        SQLConn.Open()
    '        If ConnectionState.Open Then
    '            Resultado = "Conexión correcta!"
    '        End If
    '        Exit Sub
    'ErrConexionAct:
    '        Resultado = Err.Description
    '    End Sub

    '    Public Sub ConectarReiWin()
    '        On Error GoTo ErrConexionAct
    '        If SQLConn.State = ConnectionState.Open Then
    '            Exit Sub
    '        End If
    '        Base = "Principal"
    '        Servidor = "192.168.0.10"
    '        SQLConn.ConnectionString = "Data Source=" & Servidor & ";Initial Catalog=" & Base & ";User Id=" & Usuario & ";Password=" & Contraseña & ";MultipleActiveResultSets=True;Persist Security Info=False"
    '        SQLConn.Open()
    '        If ConnectionState.Open Then
    '            Resultado = "Conexión correcta!"
    '        End If
    '        Exit Sub
    'ErrConexionAct:
    '        Resultado = Err.Description
    '    End Sub

    Public Sub Desconectar()
        If SQLConn.State <> ConnectionState.Closed Then
            SQLConn.Close()
        End If
    End Sub
End Class
