Imports System.Data.SqlClient

Public Class frmAltaEntrMatPrim

    Dim Command As New SqlCommand
    Dim Reader As SqlDataReader
    Dim sStr As String

    Private Sub frmAltaEntrMatPrim_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarComboTipos()
        AjustarDimensionesForm()
    End Sub

    Private Sub CargarComboTipos()
        cmbTipos.Items.Clear()
        cmbTipos.Items.Add("MATERIAS PRIMAS")
        cmbTipos.Items.Add("PROCESOS")
        If cmbTipos.Items.Count > 0 Then cmbTipos.Text = cmbTipos.Items(0).ToString
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

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub cmdProcesar_Click(sender As Object, e As EventArgs) Handles cmdProcesar.Click
        Procesar()
    End Sub

    Private Sub Procesar()
        gbEntradaProceso1.Visible = False
        gbEntradaProceso2.Visible = False
        gbEntradaMat.Visible = False

        gbEntradaProceso1.Location = gbEntradaMat.Location
        gbEntradaProceso2.Location = gbEntradaMat.Location

        If cmbTipos.Text = "PROCESOS" Then
            If cmbCodigos.Text <> "BOTE" Then
                gbEntradaProceso1.Visible = True
            Else 'BOTE
                gbEntradaProceso2.Visible = True
            End If
        Else 'MATERIAS PRIMAS
            gbEntradaMat.Visible = True
        End If

        AjustarDimensionesForm()
        gbDatos.Enabled = False

        Application.DoEvents()
    End Sub

    Private Sub AjustarDimensionesForm()
        Dim iAlto As Integer = gbDatos.Location.Y + gbDatos.Height + 52
        Dim iAncho As Integer = gbDatos.Location.X + gbDatos.Width + 30
        If gbEntradaProceso1.Visible Then
            iAlto = gbEntradaProceso1.Location.Y + gbEntradaProceso1.Height + 52
        ElseIf gbEntradaProceso2.Visible Then
            iAlto = gbEntradaProceso2.Location.Y + gbEntradaProceso2.Height + 52
        ElseIf gbEntradaMat.Visible Then
            iAlto = gbEntradaMat.Location.Y + gbEntradaMat.Height + 52
        End If
        Me.Height = iAlto
        Me.Width = iAncho
    End Sub

    Private Sub cmbTipos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipos.SelectedIndexChanged
        lblTitulo.Text = "ENTRADA DE " + cmbTipos.Text
        CargarComboCodigos()
    End Sub

    Private Sub cmbCodigos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCodigos.SelectedIndexChanged
        Dim Tipo As String
        Tipo = ""
        lblDescCodigo.Text = DescripcionCodigo(cmbCodigos.Text, Tipo).ToString
    End Sub

    Private Sub Limpiar(GroupBox As String)

        If GroupBox = "EntrProc1" Then
            txtIng1Cantidad.Text = ""
            txtIng1Detalle.Text = ""
            txtIng1Kilos.Text = ""
            txtIng1Lote1.Text = ""
            txtIng1Lote2.Text = ""
            txtIng1NroOrden.Text = ""
        ElseIf GroupBox = "EntrProc2" Then
            txtIng2Cantidad.Text = ""
            txtIng2Color.Text = ""
            txtIng2Kilos.Text = ""
            txtIng2NroColor.Text = ""
            txtIng2OrdPeinado1.Text = ""
            txtIng2OrdPeinado2.Text = ""
            txtIng2OrdTeñido.Text = ""
        ElseIf GroupBox = "EntrMat" Then
            txtIngMatBultos.Text = ""
            txtIngMatCajas.Text = ""
            txtIngMatCaracteristicas.Text = ""
            txtIngMatColor.Text = ""
            txtIngMatConos.Text = ""
            txtIngMatDenier.Text = ""
            txtIngMatFardos.Text = ""
            txtIngMatNroColor.Text = ""
            txtIngMatNroLote.Text = ""
            txtIngMatObservaciones.Text = ""
            txtIngMatOrdenBarraca.Text = ""
            txtIngMatProveedor.Text = ""
            txtIngMatRemito.Text = ""
            txtIngMatKilos.Text = ""
            txtIngMatTipo.Text = ""
        End If

    End Sub

    Private Sub cmdIng1Cancelar_Click(sender As Object, e As EventArgs) Handles cmdIng1Cancelar.Click
        Limpiar("EntrProc1")
        gbEntradaProceso1.Visible = False
        gbDatos.Enabled = True
        cmbTipos.Select()
        AjustarDimensionesForm()
    End Sub

    Private Sub cmdIng2Cancelar_Click(sender As Object, e As EventArgs) Handles cmdIng2Cancelar.Click
        Limpiar("EntrProc2")
        gbEntradaProceso2.Visible = False
        gbDatos.Enabled = True
        cmbTipos.Select()
        AjustarDimensionesForm()
    End Sub

    Private Sub cmdIngMatCancelar_Click(sender As Object, e As EventArgs) Handles cmdIngMatCancelar.Click
        Limpiar("EntrMat")
        gbEntradaMat.Visible = False
        gbDatos.Enabled = True
        cmbTipos.Select()
        AjustarDimensionesForm()
    End Sub

    Private Sub cmdIngMatGuardar_Click(sender As Object, e As EventArgs) Handles cmdIngMatGuardar.Click

    End Sub

End Class