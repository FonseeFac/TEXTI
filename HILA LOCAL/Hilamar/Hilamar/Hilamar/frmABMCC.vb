Imports System.Data.SqlClient

Public Class frmABMCC
    Public Alta, Ver As Boolean
    Public id As Integer
    Private Command As New SqlCommand
    Private Reader As SqlDataReader
    Dim sStr, Auditoria, EstadoOriginal, NuevoEstado As String

    Public Sub Cargar()

        CargarCombos()

        If Not Alta Then
            If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
            sStr = "SELECT * FROM TejeControlDeCalidad WHERE id = " + id.ToString
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read() Then
                    dtpFecha.Value = Reader.Item("Fecha").ToString
                    dtpFecha.Enabled = False
                    txtOP.Text = NumeroOP(Reader.Item("idOP")).ToString
                    txtOP.Enabled = False
                    txtCodArticulo.Text = ArticuloPoridOP(Reader.Item("idOP")).ToString
                    cmbTalle.Text = NombreTalle(Reader.Item("Talle")).ToString
                    cmbTalle.Enabled = False
                    cmbDestino.Text = Reader.Item("Destino").ToString
                    cmbOrigen.Text = Reader.Item("Origen").ToString
                    cmbOrigen.Enabled = False
                    txtObservaciones.Text = Reader.Item("Observaciones").ToString
                    txtObservaciones.Enabled = False
                    If Not IsDBNull(Reader.Item("ObservacionesTejeduria")) Then txtObservacionesTejeduria.Text = Reader.Item("ObservacionesTejeduria").ToString
                    txtObservacionesTejeduria.Enabled = False
                    If Not IsDBNull(Reader.Item("ObservacionesProgramacion")) Then txtObservacionesProgramacion.Text = Reader.Item("ObservacionesProgramacion").ToString
                    cmbEstado.Visible = True
                    lblEstado.Visible = True
                    cmbEstado.Text = EstadoCC(Reader.Item("Estado")).ToString
                    EstadoOriginal = cmbEstado.Text
                    If Not IsDBNull(Reader.Item("idCelda")) Then cmbNroCelda.Text = NroCeldaPorID(Reader.Item("idCelda")).ToString
                    If Not IsDBNull(Reader.Item("Es2daEtapa")) Then If Reader.Item("Es2daEtapa") = "1" Then chkEs2daEtapa.Checked = True
                End If
            End If
        End If

        'If Ver Then
        '    txtObservacionesProgramacion.Enabled = False
        '    cmbEstado.Enabled = False
        '    cmdGuardar.Enabled = False
        'End If
        If Ver Then
            txtObservacionesTejeduria.Enabled = False
            cmbDestino.Enabled = False
            txtOP.Enabled = False
            cmbTalle.Enabled = False
            txtObservacionesProgramacion.Enabled = True
            lblObservacionesProgramacion.Visible = True
            txtObservacionesProgramacion.Visible = True
            If cmbEstado.Text = "PENDIENTE" Then
                cmdGuardar.Enabled = True
            Else
                cmdGuardar.Enabled = False
            End If
            cmbEstado.Enabled = False
            cmbNroCelda.Enabled = False
            chkEs2daEtapa.Enabled = False
        End If

        Me.Height = cmdCancelar.Top + cmdCancelar.Height + 50
    End Sub

    Private Sub CargarCombos()

        cmbOrigen.Items.Clear()
        cmbOrigen.Items.Add("")
        cmbOrigen.Items.Add("CONTROL DE CALIDAD")
        cmbOrigen.Items.Add("TEJEDURIA")
        cmbOrigen.Items.Add("PROGRAMACION")
        cmbOrigen.Items.Add("DISEÑO")
        cmbOrigen.Text = ""
        cmbOrigen.Enabled = False

        cmbDestino.Items.Clear()
        cmbDestino.Items.Add("")
        cmbDestino.Items.Add("CONTROL DE CALIDAD")
        cmbDestino.Items.Add("TEJEDURIA")
        cmbDestino.Items.Add("PROGRAMACION")
        cmbDestino.Items.Add("DISEÑO")
        cmbDestino.Text = ""
        cmbOrigen.Enabled = False

        cmbTalle.Items.Clear()
        cmbTalle.Items.Add("")
        cmbTalle.Items.Add("XS")
        cmbTalle.Items.Add("S")
        cmbTalle.Items.Add("M")
        cmbTalle.Items.Add("L")
        cmbTalle.Items.Add("XL")
        cmbTalle.Items.Add("XXL")
        cmbTalle.Items.Add("XXXL")
        cmbTalle.Items.Add("U")
        cmbTalle.Text = ""


        cmbEstado.Items.Clear()
        cmbEstado.Items.Add("")
        cmbEstado.Items.Add("PENDIENTE")
        cmbEstado.Items.Add("REVISADO")
        cmbEstado.Items.Add("FINALIZADO")
        cmbEstado.Items.Add("CANCELADO")
        cmbEstado.Text = ""

        With cmbNroCelda.Items
            .Clear()
            .Add("")
            If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
            sStr = "SELECT * FROM ProdCeldas WHERE Eliminado = 0 ORDER BY NroCelda"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            Do While Reader.HasRows
                Do While Reader.Read()
                    .Add(Reader.Item("NroCelda").ToString)
                Loop
                Reader.NextResult()
            Loop
        End With
        cmbNroCelda.Text = cmbNroCelda.Items(0).ToString
    End Sub


    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs)
        Guardar()
    End Sub

    Private Function Validar() As Boolean
        On Error GoTo ErrValidar

        If cmbDestino.Text = "" Then
            Validar = False
            MensajeAtencion("Debe ingresar el sector de destino.")
            Exit Function
        End If

        If cmbOrigen.Text = "" Then
            Validar = False
            MensajeAtencion("Debe ingresar el sector de origen.")
            Exit Function
        End If

        If cmbTalle.Text = "" Then
            Validar = False
            MensajeAtencion("Debe ingresar el talle.")
            Exit Function
        End If

        If txtObservacionesTejeduria.Text = "" Then
            Validar = False
            MensajeAtencion("Debe ingresar la observación de tejeduría.")
            Exit Function
        End If

        'If txtOP.Text = "" Then
        '    Validar = False
        '    MensajeAtencion("Debe ingresar la OP.")
        '    Exit Function
        'Else
        '    If Not IsNumeric(txtOP.Text) Then
        '        Validar = False
        '        MensajeAtencion("La OP debe ser numérica.")
        '        Exit Function
        '    End If
        'End If

        'If txtCodArticulo.Text = "" Then
        '    Validar = False
        '    MensajeAtencion("Debe ingresar una OP correcta.")
        '    Exit Function
        'End If

        Validar = True
        Exit Function
ErrValidar:
        Validar = False
        MensajeAtencion("Error al validar.")
    End Function

    Private Sub Guardar()
        On Error GoTo ErrGuardar
        Dim CodEstado As Integer

        If Not Validar() Then Exit Sub

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        If Alta Then
            Auditoria = "ALTA CC | " + Environment.MachineName.ToString + " | " + NowServer.ToString
            sStr = "INSERT INTO TejeControlDeCalidad (Fecha, idOP, Talle, Origen, Destino, Eliminado, Estado, Auditoria, ObservacionesProgramacion) VALUES ('" + FechaWin10(dtpFecha.Value).ToString + "', " + idOPExistente(txtOP.Text).ToString + ", " + CodigoTalle(cmbTalle.Text).ToString + ", '"
            sStr = sStr + cmbOrigen.Text + "', '" + cmbDestino.Text + "', 0, 0, '" + Auditoria.ToString + "', '" + txtObservacionesProgramacion.Text + "')"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()
            MensajeAtencion("Observación agregada correctamente.")
        Else
            Auditoria = "MODIFICACION CC | " + Environment.MachineName.ToString + " | " + NowServer.ToString
            sStr = "UPDATE TejeControlDeCalidad SET Fecha = '" + FechaWin10(dtpFecha.Value).ToString + "', idOP = " + idOPExistente(txtOP.Text).ToString + ", Talle = " + CodigoTalle(cmbTalle.Text).ToString + ", Origen = '" + cmbOrigen.Text + "', Destino = '" + cmbDestino.Text + "', ObservacionesProgramacion = '" + txtObservacionesProgramacion.Text + "', Auditoria = '" + Auditoria.ToString + "' WHERE id = " + id.ToString
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()
            MensajeAtencion("Observación modificada correctamente.")
        End If

        If cmbEstado.Text = "PENDIENTE" Then
            Auditoria = "Cambio de Estado | " + Environment.MachineName.ToString + " | " + NowServer.ToString
            CodEstado = 1
            sStr = "UPDATE TejeControlDeCalidad SET Estado = " + CodEstado.ToString + ", AuditoriaCambioEstado = '" + Auditoria.ToString + "' WHERE id = " + id.ToString
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()
        End If

        Me.Close()

        Exit Sub
ErrGuardar:
        MensajeAtencion("Error al guardar.")
    End Sub

    Private Sub txtOP_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOP.KeyDown
        Dim idOP As Integer
        If e.KeyCode = Keys.Enter Then
            If txtOP.Text = "" Then Exit Sub
            idOP = idOPExistente(txtOP.Text)
            txtCodArticulo.Text = ArticuloPoridOP(idOP).ToString
        End If
    End Sub

    Private Sub txtOP_LostFocus(sender As Object, e As EventArgs) Handles txtOP.LostFocus
        Dim idOP As Integer
        If txtOP.Text = "" Then Exit Sub
        idOP = idOPExistente(txtOP.Text)
        txtCodArticulo.Text = ArticuloPoridOP(idOP).ToString
    End Sub

    Private Sub cmdCancelar_Click_1(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

    Private Sub cmdGuardar_Click_1(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Guardar()
    End Sub


End Class