Imports System.Data.SqlClient

Module Globales

    Public Function conectar_apptexti()
        Dim myConn As SqlConnection

        myConn = New SqlConnection("server = serversql,database = AppTextilana,Integrated Security= True")
        myConn.Open()

        Return myConn
    End Function

    Public Sub cerrar_conexiontexti(ByVal myConn As SqlConnection)
        myConn.Close()
    End Sub
End Module
