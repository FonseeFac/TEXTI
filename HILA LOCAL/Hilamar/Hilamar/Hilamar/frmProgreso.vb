Public Class frmProgreso
    Public CantProg As Long
    Public CantMax As Long

    'Configure the progressbar
    Public Sub Cargar()
        pgbProgreso.Minimum = 1
        pgbProgreso.Maximum = CantMax
        pgbProgreso.Value = 1
        pgbProgreso.Step = 1
    End Sub


    Public Sub Actualizar()
        On Error Resume Next
        'Perform 1 step. One step is specified above as 1/10 increase of the ProgressBar
        'In most cases you'd place the performstep command in a loop (that copies files, to use the example above)
        If CantProg > pgbProgreso.Maximum Then
            pgbProgreso.Maximum = CantProg
        End If
        pgbProgreso.Value = CantProg
        pgbProgreso.PerformStep()
        Application.DoEvents()

    End Sub

End Class