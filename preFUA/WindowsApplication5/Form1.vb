Imports System.IO
Imports System
Imports System.Data.SqlClient


Public Class FUA
    Dim path_Imagen, update_id As String
    Dim FECHA_ACTUAL As String
    Dim state As Boolean



    Private Sub FUA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FECHA_ACTUAL = Str(Date.Now.Year) + "-"
        FECHA_ACTUAL = Str(Date.Now.Month) + "-"
        FECHA_ACTUAL = Str(Date.Now.Year)
        Me.Text = "FUA"

        Dim frl_list As New DataGridViewComboBoxColumn
        frl_list.Name = "lista"
        frl_list.HeaderText = "Estado"
        frl_list.Items.Add("Aprobado")
        frl_list.Items.Add("Rechazado")

        dgvFOA.Columns.Add(frl_list)


        If state Then
            load_dgv_desde_archivo()
            existe_imagen()
            
        End If
    End Sub

    Private Sub load_dgv_desde_archivo()

        Dim path As String
        Dim legajo, observacion As String
        Try
            If Not My.Computer.FileSystem.FileExists("FOA.txt") Then
                File.Create("./FOA.txt").Dispose()
            End If


            path = ".\"
            path = path + "FOA.txt"
            Dim leer As New StreamReader(path)
            Dim rownumb As Integer = 0

            While leer.Peek() <> -1
                legajo = leer.ReadLine()
                update_id = leer.ReadLine()
                observacion = leer.ReadLine()
                dgvFOA.Rows.Add(update_id, legajo, observacion)
                leer.ReadLine()
            End While

            leer.Close()
        Catch ex As Exception
            MsgBox("No se encuentra la ruta", 0, "FUA ERROR")

        End Try

    End Sub


    Private Function existe_imagen() As Boolean
        Dim Path As String
        Path = ".\FOA" + update_id + ".jpg"
        If File.Exists(Path) Then
            path_Imagen = Path
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub dgvFOA_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFOA.CellClick

        Dim id As String

        id = dgvFOA.Rows(e.RowIndex).Cells("ID").Value
        update_id = id

        If existe_imagen() Then
            ImagenArchivo.ImageLocation = path_Imagen
            ImagenArchivo.SizeMode = PictureBoxSizeMode.StretchImage
            ImagenArchivo.Load()
        Else
            ImagenArchivo.ImageLocation = ".\sin_archivo.jpg"
            ImagenArchivo.SizeMode = PictureBoxSizeMode.StretchImage
            ImagenArchivo.Load()
        End If
        
    End Sub

    Private Sub cargarObs()
        Obs.Show()
    End Sub

    Private Sub exec_script()
        state = Shell("python .\request_html_bottelegram.py")
    End Sub

    Private Sub Ejecutar_Click(sender As Object, e As EventArgs) Handles Ejecutar.Click
        dgvFOA.Rows.Clear()

        state = False
        exec_script()
        If state = True Then
            FECHA_ACTUAL = Format(Now, "yyyy-MM-dd")
            If state Then
                load_dgv_desde_archivo()
                existe_imagen()

                dgvFOA.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None

            Else
                MsgBox("No cargo los formularios correctamente")
            End If

        End If
        state = False
    End Sub

    Private Sub dgvfoa_keydown(sender As Object, e As KeyEventArgs) Handles dgvFOA.KeyDown, dgvFOA.KeyUp
        Dim id As String

        id = dgvfoa.currentrow.cells("id").value
        update_id = id

        If existe_imagen() Then
            imagenarchivo.imagelocation = path_imagen
            imagenarchivo.sizemode = pictureboxsizemode.stretchimage
            imagenarchivo.load()
        Else
            imagenarchivo.imagelocation = ".\sin_archivo.jpg"
            imagenarchivo.sizemode = pictureboxsizemode.stretchimage
            imagenarchivo.load()
        End If
    End Sub

    
    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim contador As Integer
        Dim Reader As SqlDataReader
        Dim Command As SqlCommand
        Dim sStr As String
        Dim conexion As SqlConnection

        Dim ctrl As Integer

        sStr = "SELECT * FROM FUARegistros WHERE id = 1614"
        conexion = conectar_apptexti()
        Command = New SqlCommand(sStr, conexion)
        Reader = Command.ExecuteReader
        If Reader.Read Then
            If Reader.HasRows Then
                contador = Reader.Item("Eliminado")
            End If
        End If
        cerrar_conexiontexti(conexion)
        ctrl = MsgBox("Exportar FUA?", 1, "FUA")
        If ctrl = 1 Then
            MsgBox("Elegiste no")
        Else
            MsgBox("Elegiste si")
        End If
        While contador < dgvFOA.Rows.Count
            sStr = "INSERT INTO FUARegistros(id,Fecha,NCSector,NCLegajo,NCTexto,AnalisisLegajo,DisposicionTexto,AccionTexto,Eliminado,Auditoria,LegajoUsuario,NCSectorLaboro,AltaLegajo,AltaAuditoria,AltaSectorLaboro)"
            sStr += " VALUES(" + +",'" + +"','" + +"','" + "','" + +"','" + +"','" + +"','" + +"','" + +"','" + + _
                    "','" + +"','" + +"','" + +"','" + +"','" + "')"



        End While
    End Sub
End Class
