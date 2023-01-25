Imports System.Data.SqlClient

Public Class frmABMRecursosTareas
    Private Command As New SqlCommand
    Private Reader As SqlDataReader
    Dim sStr As String

    Dim IdRecurso As String
    Dim NombreRecurso As String ' creo una global para resguardar el nombre del recurso y saber si cuando entra a modificar lo cambia o no para validarlo

    Private Sub CargarListadoDeRecursos()
        Dim row() As String

        LimpiarDGV()
        ArmarDGV()

        sStr = "SELECT * FROM HilaManteRecursos WHERE Eliminado=0 and NombreRecurso like '%" + txtBuscar.Text + "%' order by NombreRecurso"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                row = {Reader.Item("Id"), Reader.Item("NombreRecurso")}
                dgvRecursos.Rows.Add(row)
            Loop
            Reader.NextResult()
        Loop

        'cuando cargo o recargo el listado limpio el IdRubro para que no quede con valores viejos
        IdRecurso = ""
        NombreRecurso = ""
    End Sub

    Private Sub LimpiarDGV()
        dgvRecursos.Rows.Clear()
        dgvRecursos.Columns.Clear()
    End Sub

    Private Sub ArmarDGV()
        dgvRecursos.Columns.Add("ID", "ID")
        dgvRecursos.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvRecursos.Columns("ID").Visible = False
        dgvRecursos.Columns.Add("RECURSO", "RECURSO")
        dgvRecursos.Columns("RECURSO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvRecursos.Columns("RECURSO").Width = 270

        dgvRecursos.Font = New Font("Arial", 10)

    End Sub

    Private Function Validar(ByVal NombRecurso As String) As Boolean
        On Error GoTo ErrValidar

        If NombRecurso = "" Then
            MensajeCritico("El nombre del Recurso no puede estar vacío")
            Validar = False
            Exit Function
        End If

        If InStr(NombRecurso, "'") > 0 Then
            MensajeCritico("El nombre del Recurso contiene un caracter no válido. Verifique.")
            Validar = False
            Exit Function
        End If

        If NombreRecurso <> NombRecurso Then
            sStr = "SELECT count(*) as Cantidad FROM HilaManteRecursos WHERE NombreRecurso = '" + NombRecurso + "' and Eliminado=0 "
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read() Then
                    If Reader.Item("Cantidad") > 0 Then
                        MensajeCritico("El nombre del Recurso ya existe, verifique.")
                        Validar = False
                        Exit Function
                    End If
                End If
            End If
        End If

        Validar = True
        Exit Function
ErrValidar:
        Validar = False
        MensajeAtencion("Error al validar.")
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub frmABMRecursosTareas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gbAgregarRecurso.Top = 29
        gbAgregarRecurso.Left = 488
        gbModificarRecurso.Top = 29
        gbModificarRecurso.Left = 488
        CargarListadoDeRecursos()
        HabilitoListado()
    End Sub

    Private Sub Deshabilitolistado()
        txtBuscar.Enabled = False
        dgvRecursos.Enabled = False
        btnAgregar.Enabled = False
        btnEditar.Enabled = False
        btnEliminar.Enabled = False
        Me.Width = 870
        Me.CenterToScreen()
    End Sub
    Private Sub HabilitoListado()
        Me.Width = 500
        Me.CenterToScreen()
        txtBuscar.Enabled = True
        dgvRecursos.Enabled = True
        btnAgregar.Enabled = True
        btnEditar.Enabled = True
        btnEliminar.Enabled = True
        gbAgregarRecurso.Visible = False
        gbModificarRecurso.Visible = False
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            CargarListadoDeRecursos()
        End If
    End Sub

    '*************agregar un Recurso****************************************
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        DeshabilitoListado()
        gbAgregarRecurso.Visible = True
        txtAgregarRecurso.Select()
    End Sub

    Private Sub btnOkAgregarRecurso_Click(sender As Object, e As EventArgs) Handles btnOkAgregarRecurso.Click
        If Not Validar(txtAgregarRecurso.Text) Then Exit Sub

        sStr = "INSERT INTO HilaManteRecursos (NombreRecurso,Eliminado) VALUES ('" + txtAgregarRecurso.Text + "',0)"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        MensajeInfo("Recurso Agregado Correctamente")
        CargarListadoDeRecursos()
        HabilitoListado()
    End Sub

    Private Sub btnCancelarAgregarRecurso_Click(sender As Object, e As EventArgs) Handles btnCancelarAgregarRecurso.Click
        txtAgregarRecurso.Text = ""
        HabilitoListado()
    End Sub

    '*****************editar un Recurso**************************
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If dgvRecursos.SelectedRows.Count <> 1 Then
            MensajeAtencion("Debe seleccionar un Recurso para modificarlo")
            Exit Sub
        End If
        IdRecurso = dgvRecursos.Rows(dgvRecursos.CurrentRow.Index).Cells("ID").Value.ToString
        NombreRecurso = dgvRecursos.Rows(dgvRecursos.CurrentRow.Index).Cells("RECURSO").Value.ToString
        txtEditarRecurso.Text = dgvRecursos.Rows(dgvRecursos.CurrentRow.Index).Cells("RECURSO").Value.ToString
        Deshabilitolistado()
        gbModificarRecurso.Visible = True
        txtEditarRecurso.Select()
    End Sub

    Private Sub btnCancelarEditarRubro_Click(sender As Object, e As EventArgs) Handles btnCancelarEditarRecurso.Click
        txtEditarRecurso.Text = ""
        HabilitoListado()
    End Sub

    Private Sub btnOkEditarRubro_Click(sender As Object, e As EventArgs) Handles btnOkEditarRecurso.Click
        If Not Validar(txtEditarRecurso.Text) Then Exit Sub

        sStr = "UPDATE HilaManteRecursos SET NombreRecurso ='" + txtEditarRecurso.Text + "' "
        sStr = sStr + "WHERE Id = " + IdRecurso
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        MensajeInfo("Recurso Modificado Correctamente")
        CargarListadoDeRecursos()
        HabilitoListado()
    End Sub

    '*****************Eliminar un Recurso**************************
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dgvRecursos.SelectedRows.Count <> 1 Then
            MensajeAtencion("Debe seleccionar un Recurso para Eliminarlo")
            Exit Sub
        End If
        Dim respuesta As Integer
        respuesta = MsgBox("Al eliminar el Recurso se lo quita de todas las tareas a las que fue asignado." + _
                           Chr(10) + Chr(10) + "Confirma la eliminación del Recurso:" + dgvRecursos.Rows(dgvRecursos.CurrentRow.Index).Cells("RECURSO").Value.ToString + " ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Confirmar borrado.")
        If respuesta = vbNo Then Exit Sub

        'sStr = "DELELE FROM HilaManteTareasRecursos WHERE IdRecurso=" + dgvRecursos.Rows(dgvRecursos.CurrentRow.Index).Cells("ID").Value.ToString
        'Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        'Command.ExecuteNonQuery()

        sStr = "UPDATE HilaManteRecursos SET Eliminado=1 WHERE Id=" + dgvRecursos.Rows(dgvRecursos.CurrentRow.Index).Cells("ID").Value.ToString
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        IdRecurso = ""
        NombreRecurso = ""

        MensajeInfo("Recurso Eliminado Correctamente")
        CargarListadoDeRecursos()

    End Sub

End Class