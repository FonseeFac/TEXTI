Imports System.Data.SqlClient

Public Class frmABMTareas
    Private Command As New SqlCommand
    Private Reader As SqlDataReader
    Dim sStr As String

    Dim IdTarea As String
    Dim NombreTarea As String ' creo una global para resguardar el nombre de la tarea y saber si cuando entra a modificar lo cambia o no para validarlo

    Private Sub CargarListadoDeTareas()
        Dim row() As String

        LimpiarDGV()
        ArmarDGV()

        sStr = "SELECT * FROM HilaManteTareas WHERE Eliminado=0 and NombreTarea like '%" + txtBuscar.Text + "%' order by NombreTarea"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                row = {Reader.Item("Id"), Reader.Item("NombreTarea")}
                dgvTareas.Rows.Add(row)
            Loop
            Reader.NextResult()
        Loop

        'cuando cargo o recargo el listado limpio el IdTarea para que no quede con valores viejos
        IdTarea = ""
        NombreTarea = ""
    End Sub

    Private Sub LimpiarDGV()
        dgvTareas.Rows.Clear()
        dgvTareas.Columns.Clear()
    End Sub

    Private Sub ArmarDGV()
        dgvTareas.Columns.Add("ID", "ID")
        dgvTareas.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvTareas.Columns("ID").Visible = False
        dgvTareas.Columns.Add("TAREA", "TAREA")
        dgvTareas.Columns("TAREA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvTareas.Columns("TAREA").Width = 430

        dgvTareas.Font = New Font("Arial", 10)

    End Sub

    Private Function Validar(ByVal NombTarea As String) As Boolean
        On Error GoTo ErrValidar

        If NombTarea = "" Then
            MensajeCritico("El nombre de la Tarea no puede estar vacío")
            Validar = False
            Exit Function
        End If

        If NombreTarea <> NombTarea Then
            sStr = "SELECT count(*) as Cantidad FROM HilaManteTareas WHERE NombreTarea = '" + NombTarea + "' and Eliminado=0 "
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read() Then
                    If Reader.Item("Cantidad") > 0 Then
                        MensajeCritico("El nombre de la Tarea ya existe, verifique.")
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

    Private Sub frmABMTareas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gbAgregarTareas.Top = 29
        gbAgregarTareas.Left = 631
        gbModificarTarea.Top = 29
        gbModificarTarea.Left = 631
        CargarListadoDeTareas()
        HabilitoListado()
    End Sub

    Private Sub Deshabilitolistado()
        txtBuscar.Enabled = False
        dgvTareas.Enabled = False
        btnAgregar.Enabled = False
        btnEditar.Enabled = False
        btnEliminar.Enabled = False
        Me.Width = 1049
        Me.CenterToScreen()
    End Sub
    Private Sub HabilitoListado()
        Me.Width = 640
        Me.CenterToScreen()
        txtBuscar.Enabled = True
        dgvTareas.Enabled = True
        btnAgregar.Enabled = True
        btnEditar.Enabled = True
        btnEliminar.Enabled = True
        gbAgregarTareas.Visible = False
        gbModificarTarea.Visible = False
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            CargarListadoDeTareas()
        End If
    End Sub

    '*************agregar una tarea****************************************
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        DeshabilitoListado()
        gbAgregarTareas.Visible = True
        txtAgregarTarea.Select()
    End Sub

    Private Sub btnOkAgregarTarea_Click(sender As Object, e As EventArgs) Handles btnOkAgregarTarea.Click
        If Not Validar(txtAgregarTarea.Text) Then Exit Sub

        sStr = "INSERT INTO HilaManteTareas (NombreTarea,Eliminado) VALUES ('" + txtAgregarTarea.Text + "',0)"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        MensajeInfo("Tarea Agregado Correctamente")
        txtAgregarTarea.Text = ""
        CargarListadoDeTareas()
        HabilitoListado()
    End Sub

    Private Sub btnCancelarAgregarTarea_Click(sender As Object, e As EventArgs) Handles btnCancelarAgregarTarea.Click
        txtAgregarTarea.Text = ""
        HabilitoListado()
    End Sub

    '*****************editar una tarea**************************
    Private Sub CargoListaDePlanesDeMantenimientoDeLaTarea()
        Dim row() As String

        dgvListaDeMaquinas.Rows.Clear()
        dgvListaDeMaquinas.Columns.Clear()
        dgvListaDeMaquinas.Columns.Add("MAQUINA", "MAQUINA")
        dgvListaDeMaquinas.Columns("MAQUINA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListaDeMaquinas.Columns("MAQUINA").Width = 335
        dgvListaDeMaquinas.Font = New Font("Arial", 10)

        sStr = "select * from HilaMantePlanMaquinasTareas PLA INNER JOIN HilaManteMaquinas MAQ ON PLA.IdMaquina =MAQ.Id "
        sStr = sStr + " WHERE PLA.Eliminado = 0 And IdTarea = " + dgvTareas.Rows(dgvTareas.CurrentRow.Index).Cells("ID").Value.ToString + " ORDER BY Nombre"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                row = {Reader.Item("Nombre")}
                dgvListaDeMaquinas.Rows.Add(row)
            Loop
            Reader.NextResult()
        Loop
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If dgvTareas.SelectedRows.Count <> 1 Then
            MensajeAtencion("Debe seleccionar un rubro para modificarlo")
            Exit Sub
        End If
        IdTarea = dgvTareas.Rows(dgvTareas.CurrentRow.Index).Cells("ID").Value.ToString
        NombreTarea = dgvTareas.Rows(dgvTareas.CurrentRow.Index).Cells("TAREA").Value.ToString
        txtEditarTarea.Text = dgvTareas.Rows(dgvTareas.CurrentRow.Index).Cells("TAREA").Value.ToString
        CargoListaDePlanesDeMantenimientoDeLaTarea()
        Deshabilitolistado()
        gbModificarTarea.Visible = True
        txtEditarTarea.Select()
    End Sub

    Private Sub btnCancelarEditarTarea_Click(sender As Object, e As EventArgs) Handles btnCancelarEditarTarea.Click
        txtEditarTarea.Text = ""
        HabilitoListado()
    End Sub

    Private Sub btnOkEditarTarea_Click(sender As Object, e As EventArgs) Handles btnOkEditarTarea.Click
        If Not Validar(txtEditarTarea.Text) Then Exit Sub

        sStr = "UPDATE HilaManteTareas SET NombreTarea ='" + txtEditarTarea.Text + "' "
        sStr = sStr + "WHERE Id = " + IdTarea
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        MensajeInfo("Tarea Modificada Correctamente")
        CargarListadoDeTareas()
        HabilitoListado()
    End Sub

    '*****************Eliminar una tarea**************************
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dgvTareas.SelectedRows.Count <> 1 Then
            MensajeAtencion("Debe seleccionar una Tarea para Eliminarla")
            Exit Sub
        End If
        Dim respuesta As Integer
        respuesta = MsgBox("Al eliminar la Tarea se la quita de todos los planes de mantenimiento a las que fue asignada y esos planes deberán ser nuevamente diseñados." + _
                           Chr(10) + Chr(10) + "Confirma la eliminación de la tarea:" + dgvTareas.Rows(dgvTareas.CurrentRow.Index).Cells("TAREA").Value.ToString + " ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Confirmar borrado.")
        If respuesta = vbNo Then Exit Sub

        sStr = "UPDATE HilaMantePlanMaquinasTareas SET Eliminado=1, AuditoriaElim='BAJA TAREA " + dgvTareas.Rows(dgvTareas.CurrentRow.Index).Cells("ID").Value.ToString + " '+ CONVERT(VARCHAR(21),GETDATE(),120) "
        sStr = sStr + " WHERE IdTarea=" + dgvTareas.Rows(dgvTareas.CurrentRow.Index).Cells("ID").Value.ToString
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        sStr = "UPDATE HilaManteTareas SET Eliminado=1, AuditoriaElim='" + Environment.MachineName + " '+ CONVERT(VARCHAR(21),GETDATE(),120) WHERE Id=" + dgvTareas.Rows(dgvTareas.CurrentRow.Index).Cells("ID").Value.ToString
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        IdTarea = ""
        NombreTarea = ""

        MensajeInfo("Tarea Eliminado Correctamente")
        CargarListadoDeTareas()

    End Sub


End Class