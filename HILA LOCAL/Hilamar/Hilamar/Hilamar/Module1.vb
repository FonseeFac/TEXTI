Imports System.IO
Imports System.Net
Imports System.Net.Security
Imports System
Imports System.Web
Imports System.Security.Cryptography.X509Certificates
Imports System.Text

Module Module1

    Public Enum typeParam
        param_string = 0
        param_file = 1
    End Enum
    Public Structure tParam
        Dim name As String
        Dim value As String
        Dim type As typeParam
    End Structure



    Public Function requestHTTP(ByVal strURL As String, ByVal params() As tParam, Optional ByVal USERNAME As String = "", _
                                 Optional ByVal PSSWD As String = "", _
                                 Optional ByVal Domain As String = "") As HttpWebResponse

        '****************************************************************
        'Genarar datos del POST en el stream tmpStream
        '****************************************************************

        'Generar limite 
        Dim limite As String = "----------" & DateTime.Now.Ticks.ToString("x")

        'Generar contenido del post
        Dim sb As StringBuilder = New StringBuilder()
        Dim paramHeader As String
        Dim paramHeaderBytes As Byte()
        Dim tmpStream As Stream = New MemoryStream()
        Dim buffer As Byte() = {}
        Dim bytesRead As Integer = 0
        Dim i As Integer
        'Recorre cada parametro generando el arreglo de bytes y esribiendolos en el buffer de salida
        For i = 0 To UBound(params)
            sb = New StringBuilder()
            If params(i).type = typeParam.param_string Then
                'Si es una cadena
                sb.Append("--")
                sb.Append(limite)
                sb.Append(vbNewLine)
                sb.Append("Content-Disposition: form-data; name=""")
                sb.Append(params(i).name) 'Nombre del parametro
                sb.Append("""")
                sb.Append(vbNewLine)
                sb.Append(vbNewLine)
                sb.Append(params(i).value) 'Valor del parametro
                sb.Append(vbNewLine)
                'Escribir la cabecera del parametro en el tmpStream
                paramHeader = sb.ToString()
                paramHeaderBytes = Encoding.UTF8.GetBytes(paramHeader)
                tmpStream.Write(paramHeaderBytes, 0, paramHeaderBytes.Length)
            Else
                'Si es un archivo
                sb.Append("--")
                sb.Append(limite)
                sb.Append(vbNewLine)
                sb.Append("Content-Disposition: form-data; name=""")
                sb.Append(params(i).name) 'Nombre del parametro
                sb.Append("""; filename=""")
                sb.Append(Path.GetFileName(params(i).value)) 'Nombre del archivo
                sb.Append("""")
                sb.Append(vbNewLine)
                sb.Append("Content-Type: ")
                sb.Append("application/octet-stream")
                sb.Append(vbNewLine)
                sb.Append(vbNewLine)

                'Escribir la cabecera del parametro en el tmpStream
                paramHeader = sb.ToString()
                paramHeaderBytes = Encoding.UTF8.GetBytes(paramHeader)
                tmpStream.Write(paramHeaderBytes, 0, paramHeaderBytes.Length)

                Dim fileStream As FileStream = New FileStream(params(i).value, FileMode.Open, FileAccess.Read)

                'Escribir el contenido del archivo
                ReDim buffer(fileStream.Length - 1)
                bytesRead = fileStream.Read(buffer, 0, buffer.Length)
                While bytesRead <> 0
                    tmpStream.Write(buffer, 0, bytesRead)
                    bytesRead = fileStream.Read(buffer, 0, buffer.Length)
                End While

            End If
        Next

        'Crear el string de límite final como matriz de bytes
        Dim limiteBytes As Byte() = Encoding.UTF8.GetBytes(vbNewLine & "--" + limite + vbNewLine)

        'Escriba el límite final
        tmpStream.Write(limiteBytes, 0, limiteBytes.Length)


        '********************************************************************
        'Enviar el request
        '********************************************************************

        'Cuando utiliza protocolo HTTPS necesita una función de validación de certificado
        'Para este caso la función devuelve siempre true
        'Si no es HTTPS no utiliza esta funcion
        ServicePointManager.ServerCertificateValidationCallback = New RemoteCertificateValidationCallback(AddressOf ValidateCertificate)

        'Crear el objeto HttpWebRequest con la url de la pagina destino
        Dim HttpWRequest As HttpWebRequest = HttpWebRequest.Create(strURL)


        Dim myCred As New NetworkCredential(USERNAME, PSSWD)
        Dim myCache As New CredentialCache()
        myCache.Add(New Uri(strURL), "Basic", myCred)

        'Dim wr As WebRequest = WebRequest.Create("www.contoso.com")
        'wr.Credentials = myCache

        'Si se le pasaron credenciales las asigna, sino utilizar las credenciales actuales
        If (USERNAME <> "") Then
            Dim creds As New Net.NetworkCredential(USERNAME, PSSWD)
            'HttpWRequest.Credentials = creds
            HttpWRequest.Credentials = myCache
        Else
            HttpWRequest.Credentials = CredentialCache.DefaultCredentials
        End If




        'Habilitar el buffer, no se envían los datos hasta la sentencia GetResponse()
        HttpWRequest.AllowWriteStreamBuffering = True

        HttpWRequest.Method = "POST"

        'Asignar el contentType con el limite
        HttpWRequest.ContentType = "multipart/form-data; boundary=" & limite


        tmpStream.Seek(0, SeekOrigin.Begin)
        'asignar el largo del stream
        HttpWRequest.ContentLength = tmpStream.Length
        Dim stream As Stream = HttpWRequest.GetRequestStream()

        ReDim buffer(tmpStream.Length - 1)
        bytesRead = tmpStream.Read(buffer, 0, buffer.Length)
        While bytesRead <> 0
            stream.Write(buffer, 0, bytesRead)
            bytesRead = tmpStream.Read(buffer, 0, buffer.Length)
        End While

        Dim Response As HttpWebResponse = Nothing
        Try
            Response = HttpWRequest.GetResponse()
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        Return Response
    End Function




    Private Function ValidateCertificate(ByVal sender As Object, ByVal certificate As X509Certificate, ByVal chain As X509Chain, ByVal sslPolicyErrors As SslPolicyErrors) As Boolean
        Dim validationResult As Boolean
        validationResult = True
        '
        ' policy code here ...
        '
        Return validationResult
    End Function

    Function readFileHTTP(ByVal strURL As String) As Byte()
        Dim res() As Byte = {}
        Try
            Dim fr As System.Net.HttpWebRequest
            Dim targetURI As New Uri(strURL)
            fr = DirectCast(System.Net.HttpWebRequest.Create(targetURI), System.Net.HttpWebRequest)
            If (fr.GetResponse().ContentLength > 0) Then
                Dim str As New System.IO.StreamReader(fr.GetResponse().GetResponseStream())
                res = System.Text.ASCIIEncoding.ASCII.GetBytes(str.ReadToEnd())
                str.Close()
            End If
        Catch ex As System.Net.WebException
        End Try

        Return res
    End Function



    '<FORM enctype="multipart/form-data" method="POST"
    'action="https://dfe.arba.gov.ar/DomicilioElectronico/SeguridadCliente/dfeServicioConsulta.do">
    '<TABLE>
    '<TR><TD>Usuario: </TD><TD align="left"><INPUT TYPE="text" NAME="user" VALUE=""></TD></TR>
    '<TR><TD>Password: </TD><TD align="left"><INPUT TYPE="text" NAME="password" VALUE=""></TD></TR>
    '<TR><TD>Archivo: </TD><TD align="left"><INPUT TYPE="file" NAME="file"></TD></TR>
    '<TR><TD colspan="2"><INPUT TYPE=submit value="Enviar"></TD></TR>
    '</TABLE>
    '</FORM>


    'Attribute VB_Name = "Module1"
    '' Ejemplo de Uso de Interface COM para presentar
    '' REMITO ELECTRONICO ARBA
    '' 2011 (C) Mariano Reingart <reingart@gmail.com>
    '' Licencia: GPLv3

    'Sub Main()
    '    Dim COT As Object, ok As Object

    '    ' Crear la interfaz COM
    '    COT = CreateObject("COT")

    '    Debug.Print COT.Version
    '    Debug.Print COT.InstallDir

    '    ' Establecer Datos de acceso (ARBA)
    '    COT.Usuario = "20267565393"
    '    COT.Password = "23456"

    '    ' Archivo a enviar (ruta absoluta):
    '    filename = "C:\TB_20111111112_000000_20080124_000001.txt"
    '    ' Respuesta de prueba (dejar en blanco si se tiene acceso para respuesta real):
    '    testing = "" ' "C:\cot_response_2_errores.xml"

    '    ' Conectar al servidor (pruebas)
    '    URL = "https://cot.test.arba.gov.ar/TransporteBienes/SeguridadCliente/presentarRemitos.do"
    '    ok = COT.Conectar(URL)

    '    ' Enviar el archivo y procesar la respuesta:
    '    ok = COT.PresentarRemito(filename, testing)

    '    ' Hubo error interno?
    '    If COT.Excepcion <> "" Then
    '        Debug.Print(COT.Excepcion, COT.Traceback)
    '        MsgBox(COT.Traceback, vbCritical, "Excepcion:" & COT.Excepcion)
    '    Else
    '        Debug.Print COT.XmlResponse
    '        Debug.Print("Error General:", COT.TipoError, "|", COT.CodigoError, "|", COT.MensajeError)

    '        ' Hubo error general de ARBA?
    '        If COT.CodigoError <> "" Then
    '            MsgBox(COT.MensajeError, vbExclamation, "Error " & COT.TipoError & ":" & COT.CodigoError)
    '        End If

    '        ' Datos de la respuesta:
    '        Debug.Print("CUIT Empresa:", COT.CuitEmpresa)
    '        Debug.Print("Numero Comprobante:", COT.NumeroComprobante)
    '        Debug.Print("Nombre Archivo:", COT.NombreArchivo)
    '        Debug.Print("Codigo Integridad:", COT.CodigoIntegridad)
    '        Debug.Print("Numero Unico:", COT.NumeroUnico)
    '        Debug.Print("Procesado:", COT.Procesado)

    '        MsgBox("CUIT Empresa: " & COT.CuitEmpresa & vbCrLf & _
    '                "Numero Comprobante: " & COT.NumeroComprobante & vbCrLf & _
    '                "Nombre Archivo: " & COT.NombreArchivo & vbCrLf & _
    '                "Codigo Integridad: " & COT.CodigoIntegridad & vbCrLf & _
    '                "Numero Unico: " & COT.NumeroUnico & vbCrLf & _
    '                "Procesado: " & COT.Procesado, _
    '                vbInformation, "Resultado")

    '        While COT.LeerErrorValidacion()
    '            Debug.Print("Error Validacion:", COT.TipoError, "|", COT.CodigoError, "|", COT.MensajeError)
    '            MsgBox(COT.MensajeError, vbExclamation, "Error Validacion:" & COT.CodigoError)
    '        End While
    '    End If
    'End Sub


End Module
