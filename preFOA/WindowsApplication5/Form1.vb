Imports System.IO
Imports System

Public Class FUA
    Dim path_Imagen, update_id As String
    Dim FECHA_ACTUAL As String
    Dim state As Boolean



    Private Sub FUA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'FECHA_ACTUAL = Str(Date.Now.Year) + "-"
        'FECHA_ACTUAL = Str(Date.Now.Month) + "-"
        'FECHA_ACTUAL = Str(Date.Now.Year)

        'If state Then
        '    load_dgv_desde_archivo()
        '    existe_imagen()
        'End If
    End Sub

    Private Sub load_dgv_desde_archivo()

        Dim path As String
        Dim legajo, observacion As String

        path = "C:\Users\computos2\Desktop\"
        path = path + "FOA" + FECHA_ACTUAL + ".txt"
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



    End Sub


    Private Function existe_imagen() As Boolean
        Dim Path As String
        Path = "C:\Users\computos2\Desktop\FOA" + update_id + ".jpg"
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
            ImagenArchivo.ImageLocation = "C:\Users\computos2\Documents\RepositorioGit\preFOA\sin_archivo.jpg"
            ImagenArchivo.SizeMode = PictureBoxSizeMode.StretchImage
            ImagenArchivo.Load()
        End If

    End Sub

    Private Sub cargarObs()
        Obs.Show()
    End Sub

    Private Sub exec_script()
        state = Shell("python C:\Users\computos2\Documents\RepositorioGit\preFOA\request_html_bottelegram.py")
    End Sub

    Private Sub Ejecutar_Click(sender As Object, e As EventArgs) Handles Ejecutar.Click
        state = False
        exec_script()
        dgvFOA.Rows.Clear()
        If state = True Then
            FECHA_ACTUAL = Format(Now, "yyyy-MM-dd")


            If state Then
                load_dgv_desde_archivo()
                existe_imagen()
            Else
                MsgBox("No cargo los formularios correctamente")
            End If

        End If
        state = False
    End Sub
End Class
