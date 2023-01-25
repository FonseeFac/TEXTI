Imports System.Data.SqlClient

Module Globales

    Public Function conectar_apptexti() As SqlConnection
        Dim myConn As SqlConnection

        myConn = New SqlConnection("Data Source = SERVERSQL ;Initial Catalog = AppTextilana; User Id= admin ; Password = admin")
        myConn.Open()

        Return myConn
    End Function

    Public Sub cerrar_conexiontexti(ByVal myConn As SqlConnection)
        myConn.Close()
    End Sub

End Module
