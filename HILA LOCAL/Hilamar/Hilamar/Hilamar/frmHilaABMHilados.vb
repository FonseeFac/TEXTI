Imports System.Data.SqlClient

Public Class frmHilaABMHilados
    Dim IdHilado As String
    Dim CodigoHilado, NombreHilado As String ' creo una global para resguardar el codigo y nombre del hilado y saber si cuando entra a modificar lo cambia o no para validarlo

    Private Sub CargarListadoDeHilados()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        Dim row() As String

        LimpiarDGV()
        ArmarDGV()

        sStr = "SELECT * FROM HilamarTipoHiladoPartidas WHERE Eliminado=0 and Descripcion like '%" + txtBuscar.Text + "%' order by Codigo"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                row = {Reader.Item("Id"), Reader.Item("Codigo"), Reader.Item("Descripcion")}
                dgvHilados.Rows.Add(row)
            Loop
            Reader.NextResult()
        Loop

        'cuando cargo o recargo el listado limpio el IdHilado para que no quede con valores viejos
        IdHilado = ""
        CodigoHilado = ""
        NombreHilado = ""
    End Sub

    Private Sub LimpiarDGV()
        dgvHilados.Rows.Clear()
        dgvHilados.Columns.Clear()
    End Sub

    Private Sub ArmarDGV()
        dgvHilados.Columns.Add("ID", "ID")
        dgvHilados.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvHilados.Columns("ID").Visible = False
        dgvHilados.Columns.Add("CODIGO", "CODIGO")
        dgvHilados.Columns("CODIGO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvHilados.Columns("CODIGO").Width = 70
        dgvHilados.Columns.Add("HILADO", "HILADO")
        dgvHilados.Columns("HILADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvHilados.Columns("HILADO").Width = 202

        dgvHilados.Font = New Font("Arial", 10)

    End Sub

    Private Function Validar(ByVal CodHilado As String, ByVal DescHilado As String, ByVal TipoMov As String) As Boolean
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        On Error GoTo ErrValidar

        If CodHilado = "" Then
            MensajeCritico("El código del hilado no puede estar vacío")
            Validar = False
            Exit Function
        End If
        If DescHilado = "" Then
            MensajeCritico("La descripción del hilado no puede estar vacía")
            Validar = False
            Exit Function
        End If

        If TipoMov = "BAJA" Then
            'debo controlar que no quede ninguna partida de ese hilado que aun tenga stock, porque si no no se puede dar de baja
            If HilamarObtengoStockTotalHilado(CodHilado, Now) > 0 Then
                MensajeCritico("El Hilado aún tiene Stock. No es posible Eliminarlo hasta que no esté agotado. Verifique.")
                Validar = False
                Exit Function
            End If
        ElseIf TipoMov = "ALTA" Then
            sStr = "SELECT count(*) as Cantidad FROM HilamarTipoHiladoPartidas WHERE Codigo = '" + CodHilado + "' and Eliminado=0 "
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read() Then
                    If Reader.Item("Cantidad") > 0 Then
                        MensajeCritico("El Código del Hilado ya existe, verifique.")
                        Validar = False
                        Exit Function
                    End If
                End If
            End If
            sStr = "SELECT count(*) as Cantidad FROM HilamarTipoHiladoPartidas WHERE Descripcion = '" + DescHilado + "' and Eliminado=0 "
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read() Then
                    If Reader.Item("Cantidad") > 0 Then
                        MensajeCritico("El nombre del Hilado ya existe, verifique.")
                        Validar = False
                        Exit Function
                    End If
                End If
            End If
        ElseIf TipoMov = "MODIFICA" Then

            If NombreHilado <> DescHilado Then
                sStr = "SELECT count(*) as Cantidad FROM HilamarTipoHiladoPartidas WHERE Descripcion = '" + DescHilado + "' and Eliminado=0 "
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Reader = Command.ExecuteReader()
                If Reader.HasRows Then
                    If Reader.Read() Then
                        If Reader.Item("Cantidad") > 0 Then
                            MensajeCritico("El nombre del Hilado ya existe, verifique.")
                            Validar = False
                            Exit Function
                        End If
                    End If
                End If
            End If

        End If


        Validar = True
        Exit Function
ErrValidar:
        Validar = False
        MensajeAtencion("Error al validar." + Chr(10) + Err.Description)
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub frmHilaABMHilados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gbAgregarHilado.Top = 29
        gbAgregarHilado.Left = 488
        gbModificarHilado.Top = 29
        gbModificarHilado.Left = 488
        CargarListadoDeHilados()
        HabilitoListado()
    End Sub

    Private Sub Deshabilitolistado()
        txtBuscar.Enabled = False
        dgvHilados.Enabled = False
        btnAgregar.Enabled = False
        btnEditar.Enabled = False
        btnEliminar.Enabled = False
        Me.Width = 850
        Me.CenterToScreen()
    End Sub
    Private Sub HabilitoListado()
        Me.Width = 500
        Me.CenterToScreen()
        txtBuscar.Enabled = True
        dgvHilados.Enabled = True
        btnAgregar.Enabled = True
        btnEditar.Enabled = True
        btnEliminar.Enabled = True
        gbAgregarHilado.Visible = False
        gbModificarHilado.Visible = False
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            CargarListadoDeHilados()
        End If
    End Sub

    '*************agregar un hilado****************************************
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        DeshabilitoListado()
        gbAgregarHilado.Visible = True
        txtAgregarCodigo.Select()
    End Sub

    Private Sub btnOkAgregarHilado_Click(sender As Object, e As EventArgs) Handles btnOkAgregarHilado.Click
        Dim Command As New SqlCommand
        Dim sStr As String

        If Not Validar(txtAgregarCodigo.Text, txtAgregarDescripcion.Text, "ALTA") Then Exit Sub

        sStr = "INSERT INTO HilamarTipoHiladoPartidas (Codigo,Descripcion,Eliminado,Auditoria,Proveedor) VALUES ('" + txtAgregarCodigo.Text + "','" + txtAgregarDescripcion.Text + "',0,'"
        sStr = sStr + "ALTA |" + Format(Now, "dd/MM/yyyy HH:mm:ss") + "','TEXTILANA S.A.')"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        MensajeInfo("Hilado Agregado Correctamente")
        txtAgregarCodigo.Text = ""
        txtAgregarDescripcion.Text = ""
        CargarListadoDeHilados()
        HabilitoListado()
    End Sub

    Private Sub btnCancelarAgregarHilado_Click(sender As Object, e As EventArgs) Handles btnCancelarAgregarHilado.Click
        txtAgregarCodigo.Text = ""
        txtAgregarDescripcion.Text = ""
        HabilitoListado()
    End Sub

    '*****************editar un hilado**************************
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If dgvHilados.SelectedRows.Count <> 1 Then
            MensajeAtencion("Debe seleccionar un Hilado para modificarlo")
            Exit Sub
        End If
        IdHilado = dgvHilados.Rows(dgvHilados.CurrentRow.Index).Cells("ID").Value.ToString
        CodigoHilado = dgvHilados.Rows(dgvHilados.CurrentRow.Index).Cells("CODIGO").Value.ToString
        NombreHilado = dgvHilados.Rows(dgvHilados.CurrentRow.Index).Cells("HILADO").Value.ToString
        txtEditarCodigo.Text = dgvHilados.Rows(dgvHilados.CurrentRow.Index).Cells("CODIGO").Value.ToString
        txtEditarDescripcion.Text = dgvHilados.Rows(dgvHilados.CurrentRow.Index).Cells("HILADO").Value.ToString
        Deshabilitolistado()
        gbModificarHilado.Visible = True
        txtEditarDescripcion.Select()
    End Sub

    Private Sub btnCancelarEditarHilado_Click(sender As Object, e As EventArgs) Handles btnCancelarEditarHilado.Click
        txtEditarCodigo.Text = ""
        txtEditarDescripcion.Text = ""
        HabilitoListado()
    End Sub

    Private Sub btnOkEditarHilado_Click(sender As Object, e As EventArgs) Handles btnOkEditarHilado.Click
        Dim Command As New SqlCommand
        Dim sStr As String
        If Not Validar(txtEditarCodigo.Text, txtEditarDescripcion.Text, "MODIFICA") Then Exit Sub

        sStr = "UPDATE HilamarTipoHiladoPartidas SET Codigo ='" + txtEditarCodigo.Text + "' "
        sStr = sStr + ",Descripcion = '" + txtEditarDescripcion.Text + "' "
        sStr = sStr + ",Auditoria = 'MODIF|" + Format(Now, "dd/MM/yyyy HH:mm:ss") + "' "
        sStr = sStr + "WHERE Id = " + IdHilado
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        MensajeInfo("Hilado Modificado Correctamente")
        CargarListadoDeHilados()
        HabilitoListado()
    End Sub

    '*****************Eliminar un hilado**************************
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim Command As New SqlCommand
        Dim sStr As String

        Dim respuesta As Integer
        respuesta = MsgBox("Al eliminar un Hilado también se eliminan todas las partidas que pertenezcan a el." + _
                           Chr(10) + Chr(10) + "Confirma la eliminación del Hilado:" + dgvHilados.Rows(dgvHilados.CurrentRow.Index).Cells("CODIGO").Value.ToString + " ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Confirmar borrado.")
        If respuesta = vbNo Then Exit Sub

        If dgvHilados.SelectedRows.Count <> 1 Then
            MensajeAtencion("Debe seleccionar un Hilado para Eliminarlo")
            Exit Sub
        End If

        If Not Validar(dgvHilados.Rows(dgvHilados.CurrentRow.Index).Cells("CODIGO").Value.ToString, dgvHilados.Rows(dgvHilados.CurrentRow.Index).Cells("HILADO").Value.ToString, "BAJA") Then Exit Sub

        sStr = "UPDATE HilamarTipoHiladoPartidas SET Eliminado=1 WHERE Id=" + dgvHilados.Rows(dgvHilados.CurrentRow.Index).Cells("ID").Value.ToString
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        sStr = "UPDATE HilamarHiladoStock SET Eliminado=1 WHERE CodTipoHilado='" + dgvHilados.Rows(dgvHilados.CurrentRow.Index).Cells("CODIGO").Value.ToString + "'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        IdHilado = ""
        CodigoHilado = ""
        NombreHilado = ""

        MensajeInfo("Hilado Eliminado Correctamente")
        CargarListadoDeHilados()
        txtBuscar.Select()

    End Sub

End Class