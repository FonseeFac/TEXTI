Imports System.IO
Imports System

Public Class FUA
    Dim path_Imagen, update_id As String



    Private Sub FUA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_dgv_desde_archivo()
        existe_imagen()
    End Sub

    Private Sub load_dgv_desde_archivo()

        Dim path As String
        Dim legajo, observacion As String

        path = "C:\Users\computos2\Desktop\"

        Dim leer As New StreamReader(path + "FOA2022-09-29.txt")
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
        End If
    End Sub
End Class
