''' <summary>
''' Busco el EXCEL abierto en "servidor" con el Path "file" y fuerzo el cierre. Devuelve 1 si el archivo se puede cerrar, 0 si NO
''' </summary>
''' <param name="servidor">PC donde buscar el file abierto</param>
''' <param name="file">Path del archivo</param>
''' <param name="modo">Modo, 0 por defecto, pregunta antes de cerrar,1 cierra automaticamente</param>
''' <remarks></remarks>
Private Function cerrar_excel(ByVal servidor As String, ByVal file As String, Optional ByVal modo As Integer = 0) As Boolean

    Dim diag As New Process
    Dim proceso As New Process
    Dim consulta As String
    Dim eleccion As Integer
    Dim Host As String()

    diag.StartInfo.FileName = "powershell.exe"
    consulta = "-command $sessn = New-CIMSession -Computername " + Chr(34) + servidor.ToString + Chr(34) + ";$lista = Get-SMBOpenFile -CIMSession $sessn | WHERE-OBJECT  -Property Path -like '*\" + file.ToString + "'; if(($lista | Measure-Object).Count -gt 0){Return (Resolve-DnsName $lista.ClientComputerName).NameHost}else{Return 0}"
    diag.StartInfo.Arguments = consulta
    diag.StartInfo.RedirectStandardOutput = True
    diag.StartInfo.UseShellExecute = False
    diag.Start()

    Dim str As StreamReader = diag.StandardOutput
    Dim sStr = str.ReadToEnd
    Host = sStr.Split(".")
    Select Case modo
        Case 0
            If Host(0) Like "0*" Then
                MsgBox("El archivo no se encuentra abierto en ninguna PC")
                Shell("powershell -command " + Chr(34) + "$sessn = New-CIMSession -Computername " + servidor.ToString + "" + Chr(34) + ";" + Chr(34) + "Get-SMBOpenFile -CIMSession $sessn | where {$_.Path  -Like \" + Chr(34) + file.ToString + "\" + Chr(34) + "} | select FileId|Close-SMBOpenFile -CIMSession $sessn -Force" + Chr(34), AppWinStyle.Hide)
                Return True
            Else
                eleccion = MsgBox("Archivo abierto en el PC " + Host(0) + " .Cerrar?", vbYesNo)
                If eleccion = 6 Then
                    Shell("powershell -command " + Chr(34) + "$sessn = New-CIMSession -Computername " + servidor.ToString + "" + Chr(34) + ";" + Chr(34) + "Get-SMBOpenFile -CIMSession $sessn | where {$_.Path  -Like \" + Chr(34) + file.ToString + "\" + Chr(34) + "} | select FileId|Close-SMBOpenFile -CIMSession $sessn -Force" + Chr(34), AppWinStyle.Hide)
                    Return True
                Else
                    MsgBox("Informele a " + Host(0) + " que guarde y cierre el archivo")
                    Return False
                End If
            End If
        Case 1
            Shell("powershell -command " + Chr(34) + "$sessn = New-CIMSession -Computername " + servidor.ToString + "" + Chr(34) + ";" + Chr(34) + "Get-SMBOpenFile -CIMSession $sessn | where {$_.Path  -Like \" + Chr(34) + file.ToString + "\" + Chr(34) + "} | select FileId|Close-SMBOpenFile -CIMSession $sessn -Force" + Chr(34), AppWinStyle.Hide)
            Return True
        Case Else
            Return False
    End Select

End Function