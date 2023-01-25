Imports System.Data.SqlClient

Public Class frmAltaSaliMatPrim
    
    Dim Command As New SqlCommand
    Dim Reader As SqlDataReader
    Dim sStr As String

    Private Sub frmAltaSaliMatPrim_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'lblTipoMov.Text = TipoMov.ToString
        CargarComboTipos()
    End Sub

    Private Sub CargarComboTipos()
        cmbTipos.Items.Clear()
        cmbTipos.Items.Add("MATERIAS PRIMAS")
        cmbTipos.Items.Add("PROCESOS")
        If cmbTipos.Items.Count > 0 Then cmbTipos.Text = cmbTipos.Items(0).ToString
        Me.Width = 638
        Me.Height = 186
    End Sub

    Private Sub CargarComboCodigos()
        If cmbTipos.Text = "" Then Exit Sub
        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        If cmbTipos.Text = "MATERIAS PRIMAS" Then
            sStr = "SELECT * FROM HilamarMateriasPrimas ORDER BY Id"
        ElseIf cmbTipos.Text = "PROCESOS" Then
            sStr = "SELECT * FROM HilamarProcesos ORDER BY Id"
        End If
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        cmbCodigos.Items.Clear()
        Do While Reader.HasRows()
            Do While Reader.Read()
                cmbCodigos.Items.Add(Reader.Item("Descripcion").ToString)
            Loop
            Reader.NextResult()
        Loop
        If cmbCodigos.Items.Count > 0 Then cmbCodigos.Text = cmbCodigos.Items(0).ToString
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        Procesar()
    End Sub

    Private Sub Procesar()
        gbSalidaProceso1.Visible = False
        gbSalidaProceso2.Visible = False
        gbSalidaMat.Visible = False

        gbSalidaProceso1.Left = 14
        gbSalidaProceso1.Top = 138
        gbSalidaProceso2.Left = 14
        gbSalidaProceso2.Top = 138
        gbSalidaMat.Left = 14
        gbSalidaMat.Top = 138

        If cmbTipos.Text = "PROCESOS" Then
            If cmbCodigos.Text <> "BOTE" Then
                gbSalidaProceso1.Visible = True
            Else 'BOTE
                gbSalidaProceso2.Visible = True
            End If
        Else 'MATERIAS PRIMAS
            gbSalidaMat.Visible = True
        End If

        AjustarAltoForm()
        gbDatos.Enabled = False

        Application.DoEvents()
    End Sub

    Private Sub AjustarAltoForm()
        Dim alturaI As Integer = 186
        If gbSalidaProceso1.Visible Then
            alturaI = alturaI + gbSalidaProceso1.Height + 5
        ElseIf gbSalidaProceso2.Visible Then
            alturaI = alturaI + gbSalidaProceso2.Height + 5
        ElseIf gbSalidaMat.Visible Then
            alturaI = alturaI + gbSalidaMat.Height + 5
        End If
        Me.Height = alturaI
    End Sub

    Private Sub cmbTipos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipos.SelectedIndexChanged
        lblTitulo.Text = "SALIDA DE " + cmbTipos.Text
        CargarComboCodigos()
    End Sub

    Private Sub cmbCodigos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCodigos.SelectedIndexChanged
        Dim Tipo As String
        Tipo = ""
        lblDescCodigo.Text = DescripcionCodigo(cmbCodigos.Text, Tipo).ToString
    End Sub

    Private Sub Limpiar(GPB As String)

        If GPB = "Eg1" Then
            txtEg1KilosEgresados.Text = ""
            txtEg1NroOrden.Text = ""
            txtEg1OrdFab.Text = ""
            txtEg1TopEgresados.Text = ""
        ElseIf GPB = "Eg2" Then
            txtEg2CantEgresada.Text = ""
            txtEg2CantKilos.Text = ""
            txtEg2OrdFabricacion.Text = ""
            txtEg2OrdTeñido.Text = ""
        ElseIf GPB = "EgMat" Then
            txtEgMatCajas.Text = ""
            txtEgMatConos.Text = ""
            txtEgMatFardos.Text = ""
            txtEgMatKilos.Text = ""
            txtEgMatOrdFabricacion.Text = ""
        End If

    End Sub

    Private Sub btnSal2Cancelar_Click(sender As Object, e As EventArgs) Handles btnSal2Cancelar.Click
        Limpiar("Eg2")
        gbSalidaProceso2.Visible = False
        gbDatos.Enabled = True
        cmbTipos.Select()
        AjustarAltoForm()
    End Sub

    Private Sub btnSal1Cancelar_Click1(sender As Object, e As EventArgs) Handles btnSal1Cancelar.Click
        Limpiar("Eg1")
        gbSalidaProceso1.Visible = False
        gbDatos.Enabled = True
        cmbTipos.Select()
        AjustarAltoForm()
    End Sub

    Private Sub btnMatCancelar_Click(sender As Object, e As EventArgs) Handles btnMatCancelar.Click
        Limpiar("EgMat")
        gbSalidaMat.Visible = False
        gbDatos.Enabled = True
        cmbTipos.Select()
        AjustarAltoForm()
    End Sub
End Class