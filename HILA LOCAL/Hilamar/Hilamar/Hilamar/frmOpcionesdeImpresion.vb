Imports System.Data.SqlClient

Public Class frmOpcionesdeImpresion
    Public ImprimirFechaHoy As Boolean = False
    Public ImprimirPlanoDeMedidas As Boolean = False
    Public ImprimirPesosyTiempos As Boolean = False
    Public DejarVaciasMedidasIniciales As Boolean = False
    Public CambiarPartidaColorOP As Boolean = False
    Public NuevoColor As String
    Public NuevaPartida As String
    Public NuevaOp As String
    Public SeConfirmoOK As Boolean = False

    Public EsAccesorio As Boolean
    Public EsPrendaCompleta As Boolean


    Public Sub Cargar()
        If EsAccesorio Then
            lblTitulo.Text = "Elija las opciones deseadas para imprimir el accesorio"
            chkDejarEnBlancoMedidasIniciales.Visible = False
            chkImprimirTiemposyPesos.Visible = False
            chkCambiarPartColorOP.Visible = True
            chkImprimirFechaHoy.Visible = True
            lblColor.Visible = True
            txtColor.Visible = True
            lblPartida.Visible = True
            txtPartida.Visible = True
            lblOp.Visible = True
            txtOp.Visible = True
            chkCambiarPartColorOP.Checked = False
            chkImprimirFechaHoy.Checked = True
            If EsPrendaCompleta Then
                chkImprimirPlanoDeMedidas.Checked = True
                chkImprimirPlanoDeMedidas.Visible = True
            Else
                chkImprimirPlanoDeMedidas.Checked = False
                chkImprimirPlanoDeMedidas.Visible = False
            End If
        Else
            lblTitulo.Text = "Elija las opciones deseadas para imprimir la planilla"
            chkImprimirTiemposyPesos.Location = New Point(48, 65)
            chkDejarEnBlancoMedidasIniciales.Location = New Point(48, 106)
            chkDejarEnBlancoMedidasIniciales.Visible = True
            chkImprimirTiemposyPesos.Visible = True
            chkCambiarPartColorOP.Visible = False
            chkImprimirFechaHoy.Visible = False
            lblColor.Visible = False
            txtColor.Visible = False
            lblPartida.Visible = False
            txtPartida.Visible = False
            lblOp.Visible = False
            txtOp.Visible = False
            If EsPrendaCompleta Then
                chkImprimirPlanoDeMedidas.Checked = True
                chkImprimirPlanoDeMedidas.Visible = True
            Else
                chkImprimirPlanoDeMedidas.Checked = False
                chkImprimirPlanoDeMedidas.Visible = False
            End If
        End If
    End Sub

    Private Sub cmdImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImprimir.Click
        If chkImprimirTiemposyPesos.Checked Then ImprimirPesosyTiempos = True
        If chkDejarEnBlancoMedidasIniciales.Checked Then DejarVaciasMedidasIniciales = True
        If chkCambiarPartColorOP.Checked Then
            CambiarPartidaColorOP = True
            NuevoColor = txtColor.Text
            NuevaPartida = txtPartida.Text
            NuevaOp = txtOp.Text
        End If
        If chkImprimirFechaHoy.Checked Then
            ImprimirFechaHoy = True
        End If
        If chkImprimirPlanoDeMedidas.Checked Then
            ImprimirPlanoDeMedidas = True
        End If

        SeConfirmoOK = True
        Close()
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        SeConfirmoOK = False
        Close()
    End Sub

    Private Sub chkCambiarPartColorOP_CheckedChanged(sender As Object, e As EventArgs) Handles chkCambiarPartColorOP.CheckedChanged
        If chkCambiarPartColorOP.Checked Then
            txtPartida.Enabled = True
            txtColor.Enabled = True
            txtOp.Enabled = True
        Else
            txtPartida.Enabled = False
            txtColor.Enabled = False
            txtOp.Enabled = False
        End If
    End Sub

    Private Sub frmOpcionesdeImpresion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class