Imports System.Data.SqlClient

Public Class frmPosponerActividades
    Public SeConfirmoOK As Boolean = False
    Public FechaPosponerOK As Date = Now
    Public ObservacionesPosponer As String = ""
    '*****************************
    'Dim FechaCompra As Date
    'Sub New(ByVal parametro1 As Date)
    '    InitializeComponent() 'es necesario que lleve esta linea
    '    FechaCompra = parametro1
    'End Sub
    Private Sub frmSolicitudGeneraOC_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpFechaPospo.Value = DateAdd(DateInterval.Day, 1, Now)
        dtpFechaPospo.Select()
    End Sub

    Private Sub dtpFechaCompra_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaPospo.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtObservaciones.Select()
        End If
    End Sub

    Private Sub dtpFechaPospo_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaPospo.ValueChanged
        txtObservaciones.Select()
    End Sub

    Private Sub cmdCancelar_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancelar.Click
        SeConfirmoOK = False
        Close()
    End Sub

    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        SeConfirmoOK = True
        FechaPosponerOK = dtpFechaPospo.Value
        ObservacionesPosponer = txtObservaciones.Text
        Close()
    End Sub

    Private Sub txtObservaciones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtObservaciones.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            cmdOK.Select()
        End If
    End Sub

End Class