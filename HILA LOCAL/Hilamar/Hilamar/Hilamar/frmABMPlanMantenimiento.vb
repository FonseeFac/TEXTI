Imports System.Data.SqlClient

Public Class frmABMPlanMantenimiento
    Dim QueEstoyHaciendoConLaTarea As String = ""
    Dim PrimerFilaActivaTareas As Integer = 0

    Dim LegajoLogueado As String 'legajo de quien va a trabajar
    Dim TipoUsuario As String ' Tipo de usuario que va a trabajar, lo voy a usar para saber que le habilito a usar y que no

    Sub New(ByVal parametro1 As String, ByVal parametro2 As String)

        InitializeComponent() 'es necesario que lleve esta linea

        LegajoLogueado = parametro1
        TipoUsuario = parametro2

    End Sub

    Private Sub CargarListadoDeMaquinas()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String
        Dim FiltroPlanta As String = ""

        Dim row() As String

        LimpiarDGV_Maquinas()
        ArmarDGV_Maquinas()

        If cmbPlantas.Text <> "TODAS" Then
            FiltroPlanta = " AND S.Fabrica='" + cmbPlantas.Text + "' "
        End If

        sStr = "SELECT M.Id as IdMaq,* FROM HilaManteMaquinas M INNER JOIN HilaManteSectores S ON M.IdSector = S.Id WHERE M.Eliminado=0 and M.Nombre like '%" + txtBuscar.Text + "%' "
        sStr = sStr + FiltroPlanta
        If rbOrdenMaquina.Checked Then
            sStr = sStr + " order by Nombre,S.Fabrica,S.Sector"
        Else
            sStr = sStr + " order by S.Fabrica,S.Sector,Nombre"
        End If
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                row = {Reader.Item("IdMaq"), Strings.Left(Reader.Item("Fabrica"), 3) + "-" + Reader.Item("Sector"), Reader.Item("Nombre"), Reader.Item("IdSector"), Reader.Item("Observaciones")}
                dgvMaquinas.Rows.Add(row)
            Loop
            Reader.NextResult()
        Loop

    End Sub

    Private Sub CargarListaDeTareasDeLaMaquina(ByVal IdMaquina As String)
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        Dim row() As String

        LimpiarDGV_TareasDeLaMaquina()
        ArmarDGV_TareasDeLaMaquina()

        sStr = "SELECT * FROM HilaMantePlanMaquinasTareas PM INNER JOIN HilaManteTareas T ON PM.IdMaquina = " + IdMaquina + " AND PM.IdTarea=T.Id "
        sStr = sStr + " WHERE PM.Eliminado=0 "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                row = {Reader.Item("Id"), Reader.Item("IdMaquina"), Reader.Item("IdTarea"), Reader.Item("NombreTarea"), Reader.Item("DuracionTarea"), Reader.Item("FrecuenciaTarea"),
                       Reader.Item("APartirDe"), ObtenerListaDeRecursosDeLaTareaParaUnaMaquina(Reader.Item("Id").ToString), Reader.Item("Observaciones"),
                       Reader.Item("LUNES"), Reader.Item("MARTES"), Reader.Item("MIERCOLES"), Reader.Item("JUEVES"), Reader.Item("VIERNES"),
                       Reader.Item("SABADO"), Reader.Item("DOMINGO")}
                dgvListaTareasAsignadas.Rows.Add(row)
            Loop
            Reader.NextResult()
        Loop

    End Sub

    Private Sub dgvListaTareasAsignadas_Paint(sender As Object, e As PaintEventArgs) Handles dgvListaTareasAsignadas.Paint
        dgvListaTareasAsignadas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
    End Sub

    Private Sub LimpiarDGV_Maquinas()
        dgvMaquinas.Rows.Clear()
        dgvMaquinas.Columns.Clear()
    End Sub

    Private Sub ArmarDGV_Maquinas()
        dgvMaquinas.Columns.Add("ID", "ID")
        dgvMaquinas.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMaquinas.Columns("ID").Visible = False
        dgvMaquinas.Columns.Add("SECTOR", "SECTOR")
        dgvMaquinas.Columns("SECTOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvMaquinas.Columns("SECTOR").Width = 170
        dgvMaquinas.Columns.Add("MAQUINA", "MAQUINA")
        dgvMaquinas.Columns("MAQUINA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvMaquinas.Columns("MAQUINA").Width = 330
        dgvMaquinas.Columns.Add("IDSECTOR", "IDSECTOR")
        dgvMaquinas.Columns("IDSECTOR").Visible = False
        dgvMaquinas.Columns.Add("OBSERVACIONES", "OBSERVACIONES")
        dgvMaquinas.Columns("OBSERVACIONES").Visible = False

        dgvMaquinas.Font = New Font("Arial", 10)
    End Sub

    Private Sub LimpiarDGV_TareasDeLaMaquina()
        dgvListaTareasAsignadas.Rows.Clear()
        dgvListaTareasAsignadas.Columns.Clear()
    End Sub
    Private Sub ArmarDGV_TareasDeLaMaquina()
        dgvListaTareasAsignadas.Columns.Add("ID", "ID")
        dgvListaTareasAsignadas.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvListaTareasAsignadas.Columns("ID").Visible = False
        dgvListaTareasAsignadas.Columns.Add("IDMAQUINA", "IDMAQUINA")
        dgvListaTareasAsignadas.Columns("IDMAQUINA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvListaTareasAsignadas.Columns("IDMAQUINA").Visible = False
        dgvListaTareasAsignadas.Columns.Add("IDTAREA", "IDTAREA")
        dgvListaTareasAsignadas.Columns("IDTAREA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvListaTareasAsignadas.Columns("IDTAREA").Visible = False
        dgvListaTareasAsignadas.Columns.Add("TAREA", "TAREA")
        dgvListaTareasAsignadas.Columns("TAREA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListaTareasAsignadas.Columns("TAREA").Width = 200
        dgvListaTareasAsignadas.Columns.Add("DURACION", "DURACION")
        dgvListaTareasAsignadas.Columns("DURACION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListaTareasAsignadas.Columns("DURACION").Width = 110
        dgvListaTareasAsignadas.Columns.Add("FRECUENCIA", "FRECUENCIA")
        dgvListaTareasAsignadas.Columns("FRECUENCIA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListaTareasAsignadas.Columns("FRECUENCIA").Width = 110
        dgvListaTareasAsignadas.Columns.Add("FECHADESDE", "A PARTIR DE")
        dgvListaTareasAsignadas.Columns("FECHADESDE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListaTareasAsignadas.Columns("FECHADESDE").Width = 110
        dgvListaTareasAsignadas.Columns.Add("RECURSOS", "RECURSOS")
        dgvListaTareasAsignadas.Columns("RECURSOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListaTareasAsignadas.Columns("RECURSOS").Width = 200
        dgvListaTareasAsignadas.Columns("RECURSOS").DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvListaTareasAsignadas.Columns.Add("OBSERVACIONES", "OBSERVACIONES")
        dgvListaTareasAsignadas.Columns("OBSERVACIONES").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListaTareasAsignadas.Columns("OBSERVACIONES").Width = 205
        dgvListaTareasAsignadas.Columns.Add("LUNES", "LUNES")
        dgvListaTareasAsignadas.Columns("LUNES").Visible = False
        dgvListaTareasAsignadas.Columns.Add("MARTES", "MARTES")
        dgvListaTareasAsignadas.Columns("MARTES").Visible = False
        dgvListaTareasAsignadas.Columns.Add("MIERCOLES", "MIERCOLES")
        dgvListaTareasAsignadas.Columns("MIERCOLES").Visible = False
        dgvListaTareasAsignadas.Columns.Add("JUEVES", "JUEVES")
        dgvListaTareasAsignadas.Columns("JUEVES").Visible = False
        dgvListaTareasAsignadas.Columns.Add("VIERNES", "VIERNES")
        dgvListaTareasAsignadas.Columns("VIERNES").Visible = False
        dgvListaTareasAsignadas.Columns.Add("SABADO", "SABADO")
        dgvListaTareasAsignadas.Columns("SABADO").Visible = False
        dgvListaTareasAsignadas.Columns.Add("DOMINGO", "DOMINGO")
        dgvListaTareasAsignadas.Columns("DOMINGO").Visible = False

        dgvListaTareasAsignadas.Font = New Font("Arial", 9)
        dgvListaTareasAsignadas.RowTemplate.Height = 55

    End Sub

    Private Sub frmABMPlanMantenimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gbPlanMantenimiento.Top = 174
        gbPlanMantenimiento.Left = 7
        gbPlanMantenimiento.Height = 527
        gbPlanMantenimiento.Width = 1015
        CargarListadePlantas()
        cargarFrecuencias()
        HabilitoListadoTareas()
    End Sub

    Private Sub CargarListadePlantas()
        cmbPlantas.Items.Clear()
        cmbPlantas.Items.Add("TODAS")
        cmbPlantas.Items.Add("TEXTILANA")
        cmbPlantas.Items.Add("HILAMAR")
        cmbPlantas.SelectedIndex = 0
    End Sub

    Private Sub HabilitoListadoTareas()
        lblTitListaTareas.Visible = True
        dgvListaTareasAsignadas.Visible = True
        gbBotonera.Visible = True
        dgvListaTareasAsignadas.Left = 10
        dgvListaTareasAsignadas.Top = 82
        dgvListaTareasAsignadas.Height = 397
        dgvListaTareasAsignadas.Width = 1000
        gbBotonera.Top = 480
        gbBotonera.Left = 153
        gbAgregarTarea.Left = 10
        gbAgregarTarea.Top = 58
        gbAgregarTarea.Visible = False
        gbCopiarPlan.Left = 10
        gbCopiarPlan.Top = 58
        gbCopiarPlan.Visible = False
    End Sub

    Private Sub DeshabilitoListadoTareas()
        lblTitListaTareas.Visible = False
        dgvListaTareasAsignadas.Visible = False
        gbBotonera.Visible = False
    End Sub

    Private Sub cmbPlantas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPlantas.SelectedIndexChanged
        CargarListadoDeMaquinas()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        CargarListadoDeMaquinas()
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            CargarListadoDeMaquinas()
            dgvMaquinas.Select()
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub rbOrdenMaquina_CheckedChanged(sender As Object, e As EventArgs) Handles rbOrdenMaquina.CheckedChanged
        CargarListadoDeMaquinas()
    End Sub

    Private Sub rbOrdenSector_CheckedChanged(sender As Object, e As EventArgs) Handles rbOrdenSector.CheckedChanged
        CargarListadoDeMaquinas()
    End Sub

    Private Sub cargarFrecuencias()
        cmbFrecuencia.Items.Clear()

        cmbFrecuencia.Items.Add("Diaria")
        cmbFrecuencia.Items.Add("Semanal")
        cmbFrecuencia.Items.Add("Mensual")
        cmbFrecuencia.Items.Add("Bimestral")
        cmbFrecuencia.Items.Add("Trimestral")
        cmbFrecuencia.Items.Add("Cuatrimestral")
        cmbFrecuencia.Items.Add("Semestral")
        cmbFrecuencia.Items.Add("Anual")
        cmbFrecuencia.Items.Add("Cada 2 años")
        cmbFrecuencia.Items.Add("Cada 3 años")
        cmbFrecuencia.Items.Add("Cada 4 años")
        cmbFrecuencia.Items.Add("Cada 5 años")

        cmbFrecuencia.Text = "Semanal"
    End Sub

    Private Sub dgvMaquinas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMaquinas.CellClick
        If dgvMaquinas.CurrentRow.Index >= 0 Then
            lblPlanMaquina.Text = dgvMaquinas.Rows(dgvMaquinas.CurrentRow.Index).Cells("MAQUINA").Value.ToString
            lblAuxIdMaquina.Text = dgvMaquinas.Rows(dgvMaquinas.CurrentRow.Index).Cells("ID").Value.ToString
            CargarListaDeTareasDeLaMaquina(dgvMaquinas.Rows(dgvMaquinas.CurrentRow.Index).Cells("ID").Value.ToString)
        End If
    End Sub

    Private Sub btnAgregarTarea_Click(sender As Object, e As EventArgs) Handles btnAgregarTarea.Click
        DeshabilitoListadoTareas()
        gbAgregarTarea.Visible = True
        gbCopiarPlan.Visible = False
        QueEstoyHaciendoConLaTarea = "AGREGAR"
        PrepararVentanaParaAgregar(lblAuxIdMaquina.Text, True)
    End Sub

    Private Sub btnEditarTarea_Click(sender As Object, e As EventArgs) Handles btnEditarTarea.Click
        If dgvListaTareasAsignadas.SelectedRows.Count <> 1 Then
            MensajeAtencion("Debe seleccionar una Tarea para Editarla")
            Exit Sub
        End If

        QueEstoyHaciendoConLaTarea = "EDITAR"
        DeshabilitoListadoTareas()
        gbCopiarPlan.Visible = False
        gbAgregarTarea.Visible = True

        PrepararVentanaParaEditar(lblAuxIdMaquina.Text, dgvListaTareasAsignadas.Rows(dgvListaTareasAsignadas.CurrentRow.Index).Cells("IDTAREA").Value.ToString,
                                  dgvListaTareasAsignadas.CurrentRow.Index, dgvListaTareasAsignadas.Rows(dgvListaTareasAsignadas.CurrentRow.Index).Cells("ID").Value.ToString)
    End Sub

    Private Sub btnEliminarTarea_Click(sender As Object, e As EventArgs) Handles btnEliminarTarea.Click
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        If dgvListaTareasAsignadas.SelectedRows.Count <> 1 Then
            MensajeAtencion("Debe seleccionar una Tarea para Eliminarla")
            Exit Sub
        End If

        Dim respuesta As Integer
        respuesta = MsgBox("Confirma la eliminación de la Tarea: " + dgvListaTareasAsignadas.Rows(dgvListaTareasAsignadas.CurrentRow.Index).Cells("TAREA").Value.ToString + " ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Confirmar borrado.")
        If respuesta = vbNo Then Exit Sub

        QueEstoyHaciendoConLaTarea = "ELIMINAR"

        lblAuxIdMaqTarea.Text = dgvListaTareasAsignadas.Rows(dgvListaTareasAsignadas.CurrentRow.Index).Cells("ID").Value.ToString

        'tengo que quitar los recursos primero
        sStr = "DELETE FROM HilaMantePlanTareasRecursos WHERE IdMaqTarea=" + lblAuxIdMaqTarea.Text
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()
        'luego borro la tarea de la maquina
        sStr = "UPDATE HilaMantePlanMaquinasTareas SET Eliminado = 1 WHERE Id=" + lblAuxIdMaqTarea.Text + " "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()
        'tambien borro las actividades de esa tarea de la maquina

        sStr = "SELECT * FROM HilaManteListadoActividades WHERE Eliminado=0 AND IdMaqTarea=" + lblAuxIdMaqTarea.Text
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()

                ' ademas agrego el borrado de la actividad al historial
                sStr = "INSERT INTO HilaManteActiHistorial (IdActividad,Fecha,Estado,Legajo,Observaciones,Eliminado) "
                sStr = sStr + "VALUES "
                sStr = sStr + "(" + Reader.Item("Id").ToString + ",GETDATE(),'ELIMINADO','" + LegajoLogueado + "','',0)"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
                ' y la marco como borrada
                sStr = "UPDATE HilaManteListadoActividades SET Eliminado = 1 WHERE Id=" + Reader.Item("Id").ToString + ""
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
            Loop
            Reader.NextResult()
        Loop


        MensajeInfo("Tarea Eliminada Exitosamente.")

        'limpio el id para que no quede viejo
        lblAuxIdMaqTarea.Text = ""

        If lblAuxIdMaquina.Text <> "" Then
            CargarListaDeTareasDeLaMaquina(lblAuxIdMaquina.Text)
        End If

    End Sub

    Private Sub btnCopiarPlan_Click(sender As Object, e As EventArgs) Handles btnCopiarPlan.Click
        If lblAuxIdMaquina.Text = "ID" Then
            Exit Sub
        End If
        DeshabilitoListadoTareas()
        gbAgregarTarea.Visible = False
        gbCopiarPlan.Visible = True
        PrepararVentanaParaCopiarPlan(dgvMaquinas.Rows(dgvMaquinas.CurrentRow.Index).Cells("ID").Value.ToString)
        txtCopiarBuscaMaq.Select()
    End Sub

    Private Sub PrepararVentanaParaAgregar(ByVal IdMaquina As String, ByVal PrimerPasada As Boolean)
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        lblTitElegirTarea.Text = "Seleccione la Tarea que se va a agregar"
        gbAgregarTarea.Text = "AGREGAR TAREA"
        dgvTareasElegir.ReadOnly = False

        Dim row() As String

        Dim chkElegirT, chkElegirR As New DataGridViewCheckBoxColumn()
        chkElegirT.HeaderText = "CHK"
        chkElegirT.Name = "ELEGIR"
        chkElegirR.HeaderText = "CHK"
        chkElegirR.Name = "ELEGIR"

        dgvTareasElegir.Rows.Clear()
        dgvTareasElegir.Columns.Clear()
        dgvTareasElegir.Columns.Add("ID", "ID")
        dgvTareasElegir.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvTareasElegir.Columns("ID").Visible = False
        dgvTareasElegir.Columns.Add(chkElegirT)
        dgvTareasElegir.Columns("ELEGIR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTareasElegir.Columns("ELEGIR").Width = 40
        dgvTareasElegir.Columns("ELEGIR").ReadOnly = False
        dgvTareasElegir.Columns.Add("TAREA", "TAREA")
        dgvTareasElegir.Columns("TAREA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvTareasElegir.Columns("TAREA").Width = 500
        dgvTareasElegir.Columns("TAREA").ReadOnly = True

        dgvTareasElegir.Font = New Font("Arial", 9)

        sStr = "SELECT * FROM HilaManteTareas WHERE Id NOT IN (SELECT DISTINCT(IdTarea) FROM HilaMantePlanMaquinasTareas WHERE Eliminado=0 AND IdMaquina=" + IdMaquina + ") ORDER BY NombreTarea"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                row = {Reader.Item("Id"), False, Reader.Item("NombreTarea")}
                dgvTareasElegir.Rows.Add(row)
            Loop
            Reader.NextResult()
        Loop

        dgvRecursosElegir.Rows.Clear()
        dgvRecursosElegir.Columns.Clear()
        dgvRecursosElegir.Columns.Add("ID", "ID")
        dgvRecursosElegir.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvRecursosElegir.Columns("ID").Visible = False
        dgvRecursosElegir.Columns.Add(chkElegirR)
        dgvRecursosElegir.Columns("ELEGIR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvRecursosElegir.Columns("ELEGIR").Width = 40
        dgvRecursosElegir.Columns.Add("RECURSO", "RECURSO")
        dgvRecursosElegir.Columns("RECURSO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvRecursosElegir.Columns("RECURSO").Width = 300
        dgvRecursosElegir.Columns("RECURSO").ReadOnly = True

        dgvRecursosElegir.Font = New Font("Arial", 9)

        sStr = "SELECT * FROM HilaManteRecursos WHERE Eliminado=0 ORDER BY NombreRecurso "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                row = {Reader.Item("Id"), False, Reader.Item("NombreRecurso")}
                dgvRecursosElegir.Rows.Add(row)
            Loop
            Reader.NextResult()
        Loop

        txtObservaciones.Text = ""
        txtDuracionTarea.Text = ""
        cmbFrecuencia.SelectedIndex = -1
        If PrimerPasada Then
            dtpAPartirDe.Value = Now
        End If
        If PrimerFilaActivaTareas <= dgvTareasElegir.RowCount Then
            dgvTareasElegir.FirstDisplayedScrollingRowIndex = PrimerFilaActivaTareas
        End If
        chkLunes.Checked = True
        chkMartes.Checked = True
        chkMiercoles.Checked = True
        chkJueves.Checked = True
        chkViernes.Checked = True
        chkSabado.Checked = True
        chkDomingo.Checked = False
    End Sub

    Private Sub PrepararVentanaParaEditar(ByVal IdMaquina As String, ByVal IdTarea As String, ByVal FilaTarea As Integer, ByVal IdMaqTarea As String)
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        lblAuxIdMaqTarea.Text = IdMaqTarea
        lblTitElegirTarea.Text = "Tarea que se está editando:"
        gbAgregarTarea.Text = "EDITAR TAREA"
        dgvTareasElegir.ReadOnly = True

        Dim AuxFilaPosicionTarea As Integer = 0
        Dim row() As String

        Dim chkElegirT, chkElegirR As New DataGridViewCheckBoxColumn()
        chkElegirT.HeaderText = "CHK"
        chkElegirT.Name = "ELEGIR"
        chkElegirR.HeaderText = "CHK"
        chkElegirR.Name = "ELEGIR"

        dgvTareasElegir.Rows.Clear()
        dgvTareasElegir.Columns.Clear()
        dgvTareasElegir.Columns.Add("ID", "ID")
        dgvTareasElegir.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvTareasElegir.Columns("ID").Visible = False
        dgvTareasElegir.Columns.Add(chkElegirT)
        dgvTareasElegir.Columns("ELEGIR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTareasElegir.Columns("ELEGIR").Width = 40
        dgvTareasElegir.Columns("ELEGIR").ReadOnly = True
        dgvTareasElegir.Columns.Add("TAREA", "TAREA")
        dgvTareasElegir.Columns("TAREA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvTareasElegir.Columns("TAREA").Width = 500
        dgvTareasElegir.Columns("TAREA").ReadOnly = True

        dgvTareasElegir.Font = New Font("Arial", 9)

        sStr = "SELECT * FROM HilaManteTareas WHERE Id NOT IN (SELECT DISTINCT(IdTarea) FROM HilaMantePlanMaquinasTareas WHERE Eliminado=0 AND IdMaquina=" + IdMaquina + ") "
        sStr = sStr + " UNION SELECT * FROM HilaManteTareas WHERE Id=" + IdTarea + " "
        sStr = sStr + " ORDER BY NombreTarea"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                If Reader.Item("Id") = IdTarea Then
                    AuxFilaPosicionTarea = dgvTareasElegir.RowCount
                    row = {Reader.Item("Id"), True, Reader.Item("NombreTarea")}
                Else
                    row = {Reader.Item("Id"), False, Reader.Item("NombreTarea")}
                End If
                dgvTareasElegir.Rows.Add(row)
            Loop
            Reader.NextResult()
        Loop
        'al final dejo seleccionada la fila donde esta la tarea y deshabilito el dgv
        dgvTareasElegir.Rows(AuxFilaPosicionTarea).Selected = True
        dgvTareasElegir.CurrentCell = dgvTareasElegir.Rows(AuxFilaPosicionTarea).Cells("ELEGIR")
        dgvTareasElegir.FirstDisplayedCell = dgvTareasElegir.Rows(AuxFilaPosicionTarea).Cells("ELEGIR")

        dgvRecursosElegir.Rows.Clear()
        dgvRecursosElegir.Columns.Clear()
        dgvRecursosElegir.Columns.Add("ID", "ID")
        dgvRecursosElegir.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvRecursosElegir.Columns("ID").Visible = False
        dgvRecursosElegir.Columns.Add(chkElegirR)
        dgvRecursosElegir.Columns("ELEGIR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvRecursosElegir.Columns("ELEGIR").Width = 40
        dgvRecursosElegir.Columns.Add("RECURSO", "RECURSO")
        dgvRecursosElegir.Columns("RECURSO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvRecursosElegir.Columns("RECURSO").Width = 300
        dgvRecursosElegir.Columns("RECURSO").ReadOnly = True

        dgvRecursosElegir.Font = New Font("Arial", 9)

        sStr = "select * from"
        sStr = sStr + "("
        sStr = sStr + "SELECT *,0 as Elegido FROM HilaManteRecursos "
        sStr = sStr + "WHERE Eliminado = 0 "
        sStr = sStr + "and ID not in (select IdRecurso from HilaMantePlanTareasRecursos where IdMaqTarea = " + IdMaqTarea + ")"
        sStr = sStr + " UNION "
        sStr = sStr + "SELECT *,1 as Elegido FROM HilaManteRecursos "
        sStr = sStr + "WHERE Eliminado = 0 "
        sStr = sStr + " and ID in (select IdRecurso from HilaMantePlanTareasRecursos where IdMaqTarea = " + IdMaqTarea + ") "
        sStr = sStr + ") a "
        sStr = sStr + "ORDER BY NombreRecurso"

        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                If Reader.Item("Elegido") = 1 Then
                    row = {Reader.Item("Id"), True, Reader.Item("NombreRecurso")}
                Else
                    row = {Reader.Item("Id"), False, Reader.Item("NombreRecurso")}
                End If
                dgvRecursosElegir.Rows.Add(row)
            Loop
            Reader.NextResult()
        Loop

        txtObservaciones.Text = dgvListaTareasAsignadas.Rows(FilaTarea).Cells("OBSERVACIONES").Value.ToString()
        txtDuracionTarea.Text = dgvListaTareasAsignadas.Rows(FilaTarea).Cells("DURACION").Value.ToString()
        cmbFrecuencia.Text = dgvListaTareasAsignadas.Rows(FilaTarea).Cells("FRECUENCIA").Value.ToString()
        dtpAPartirDe.Value = dgvListaTareasAsignadas.Rows(FilaTarea).Cells("FECHADESDE").Value.ToString()
        If dgvListaTareasAsignadas.Rows(FilaTarea).Cells("LUNES").Value.ToString() = "1" Then
            chkLunes.Checked = True
        Else
            chkLunes.Checked = False
        End If
        If dgvListaTareasAsignadas.Rows(FilaTarea).Cells("MARTES").Value.ToString() = "1" Then
            chkMartes.Checked = True
        Else
            chkMartes.Checked = False
        End If
        If dgvListaTareasAsignadas.Rows(FilaTarea).Cells("MIERCOLES").Value.ToString() = "1" Then
            chkMiercoles.Checked = True
        Else
            chkMiercoles.Checked = False
        End If
        If dgvListaTareasAsignadas.Rows(FilaTarea).Cells("JUEVES").Value.ToString() = "1" Then
            chkJueves.Checked = True
        Else
            chkJueves.Checked = False
        End If
        If dgvListaTareasAsignadas.Rows(FilaTarea).Cells("VIERNES").Value.ToString() = "1" Then
            chkViernes.Checked = True
        Else
            chkViernes.Checked = False
        End If
        If dgvListaTareasAsignadas.Rows(FilaTarea).Cells("SABADO").Value.ToString() = "1" Then
            chkSabado.Checked = True
        Else
            chkSabado.Checked = False
        End If
        If dgvListaTareasAsignadas.Rows(FilaTarea).Cells("DOMINGO").Value.ToString() = "1" Then
            chkDomingo.Checked = True
        Else
            chkDomingo.Checked = False
        End If

    End Sub

    'Private Sub dgvTareasElegir_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTareasElegir.CellValueChanged

    '    'solo si se modifico la celda para tildar
    '    If e.ColumnIndex = 1 Then
    '        If dgvTareasElegir.Rows(e.RowIndex).Cells(1).Value = True Then

    '            'Si tildo una debo destildar el resto
    '            For i = 0 To dgvTareasElegir.RowCount - 1
    '                If i <> e.RowIndex Then
    '                    dgvTareasElegir.Rows(e.RowIndex).Cells(1).Value = False
    '                End If
    '            Next

    '        End If
    '    End If

    'End Sub
    Private Sub txtDuracionTarea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDuracionTarea.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        'recargo por si estuvo agregando varias tareas con la misma ventana, para qu se refresque el listado de tareas
        CargarListaDeTareasDeLaMaquina(lblAuxIdMaquina.Text)
        QueEstoyHaciendoConLaTarea = ""
        lblAuxIdMaqTarea.Text = ""
        HabilitoListadoTareas()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If QueEstoyHaciendoConLaTarea = "AGREGAR" Then
            AgregarNuevaTareaAlPlan()
        Else
            EditarTareaDelPlan()
        End If
    End Sub

    Private Function ValidarAgregar() As Boolean
        Dim canttildados As Integer = 0

        If lblAuxIdMaquina.Text = "" Then
            MensajeCritico("Debe haber seleccionado una máquina primero para poder agregar tareas.")
            ValidarAgregar = False
            Exit Function
        End If

        'PRIMERO CONTROLO QUE SOLO TENGA TILDADA UNA TAREA
        'For i = 0 To dgvTareasElegir.RowCount - 1
        '    If dgvTareasElegir.Rows(i).Cells("ELEGIR").Value = True Then
        '        canttildados = canttildados + 1
        '    End If
        'Next
        'If canttildados <> 1 Then
        '    MensajeCritico("Debe elegir solo Una Tarea para agregar.")
        '    ValidarAgregar = False
        '    Exit Function
        'End If

        If txtDuracionTarea.Text <> "" Then
            If Not IsNumeric(txtDuracionTarea.Text) Then
                MensajeCritico("La duración de la tarea debe ser un número.")
                ValidarAgregar = False
                Exit Function
            End If
        End If

        ValidarAgregar = True
    End Function

    Private Sub AgregarNuevaTareaAlPlan()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        Dim CantTildes As Integer = 0

        Dim lunes, martes, miercoles, jueves, viernes, sabado, domingo As String
        Dim i, j As Integer
        Dim IdTareaGrabar As String = ""
        Dim IdMaqTareaParaGrabar As String = ""
        Dim HayQueCrearListaActividades As Boolean = False

        'valido primero
        If Not ValidarAgregar() Then Exit Sub

        'controlo si la fecha desde es anterior a hoy, entonces debo crear la lista de actividades que deberian haberse hecho y no se hicieron
        If Format(dtpAPartirDe.Value, "yyyyMMdd") <= Format(Now, "yyyyMMdd") Then
            Dim respuesta As Integer
            respuesta = MsgBox("La Fecha del comienzo de la frecuencia de la Tarea es anterior al día de hoy." + Chr(10) + "Desea crear la lista de actividades anteriores a hoy ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Confirmar creación de actividades.")
            If respuesta = vbYes Then
                HayQueCrearListaActividades = True
            End If
        End If

        If chkLunes.Checked Then
            lunes = "1"
        Else
            lunes = "0"
        End If
        If chkMartes.Checked Then
            martes = "1"
        Else
            martes = "0"
        End If
        If chkMiercoles.Checked Then
            miercoles = "1"
        Else
            miercoles = "0"
        End If
        If chkJueves.Checked Then
            jueves = "1"
        Else
            jueves = "0"
        End If
        If chkViernes.Checked Then
            viernes = "1"
        Else
            viernes = "0"
        End If
        If chkSabado.Checked Then
            sabado = "1"
        Else
            sabado = "0"
        End If
        If chkDomingo.Checked Then
            domingo = "1"
        Else
            domingo = "0"
        End If

        'PRIMERO CUENTO CUANTOS TILDES SON PARA TENER EL TAMAÑO DE LA BARRA DE PROGRESO
        For i = 0 To dgvTareasElegir.RowCount - 1
            If dgvTareasElegir.Rows(i).Cells("ELEGIR").Value = True Then
                CantTildes = CantTildes + 1
            End If
        Next

        Dim FormProgre As New frmProgreso
        FormProgre.CantMax = CantTildes + 1
        FormProgre.lblTarea.Text = "Agregando las Tareas seleccionadas al Plan de Mantenimiento"
        FormProgre.lblEstado.Text = "Aguarde unos instantes..."
        FormProgre.Cargar()
        FormProgre.Show()
        FormProgre.CantProg = 0
        FormProgre.Actualizar()

        'primero me traigo el id de la tarea que quiere agregar
        For i = 0 To dgvTareasElegir.RowCount - 1
            If dgvTareasElegir.Rows(i).Cells("ELEGIR").Value = True Then
                IdTareaGrabar = dgvTareasElegir.Rows(i).Cells("ID").Value

                'grabo la tarea 
                If txtDuracionTarea.Text = "" Then
                    txtDuracionTarea.Text = "0"
                End If
                sStr = "INSERT INTO HilaMantePlanMaquinasTareas (IdMaquina,IdTarea,DuracionTarea,FrecuenciaTarea,APartirDe,Observaciones,Eliminado,lunes,martes,miercoles,jueves,viernes,sabado,domingo) "
                sStr = sStr + " VALUES (" + lblAuxIdMaquina.Text + "," + IdTareaGrabar + "," + txtDuracionTarea.Text + ",'" + cmbFrecuencia.Text + "','" + Format(dtpAPartirDe.Value, "yyyyMMdd") + "','"
                sStr = sStr + txtObservaciones.Text + "',0," + lunes + "," + martes + "," + miercoles + "," + jueves + "," + viernes + "," + sabado + "," + domingo + ")"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()

                'agarro el id para insertarlo en los recursos
                sStr = "SELECT max(Id) as Id FROM HilaMantePlanMaquinasTareas WHERE Eliminado=0 AND IdMaquina=" + lblAuxIdMaquina.Text + " AND IdTarea=" + IdTareaGrabar + ""
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Reader = Command.ExecuteReader()
                If Reader.HasRows Then
                    If Reader.Read() Then
                        IdMaqTareaParaGrabar = Reader.Item("Id").ToString
                    End If
                End If

                'AHORA LOS RECURSOS 
                For j = 0 To dgvRecursosElegir.RowCount - 1
                    If dgvRecursosElegir.Rows(j).Cells("ELEGIR").Value = True Then
                        sStr = "INSERT INTO HilaMantePlanTareasRecursos (IdMaqTarea,IdRecurso) VALUES (" + IdMaqTareaParaGrabar + "," + dgvRecursosElegir.Rows(j).Cells("ID").Value.ToString + ")"
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Next

                'controlo si la fecha desde es anterior a hoy, entonces debo crear la lista de actividades que deberian haberse hecho y no se hicieron
                If HayQueCrearListaActividades Then
                    CrearListadeActividadesTareaPlanMantenimiento(IdMaqTareaParaGrabar, dtpAPartirDe.Value, cmbFrecuencia.Text)
                End If

                FormProgre.CantProg = FormProgre.CantProg + 1
                FormProgre.Actualizar()
            End If
        Next

        FormProgre.Close()

        MensajeInfo("Tareas Agregadas Exitosamente.")

        PrimerFilaActivaTareas = dgvTareasElegir.FirstDisplayedScrollingRowIndex

        PrepararVentanaParaAgregar(lblAuxIdMaquina.Text, False)

        'HabilitoListadoTareas()
        'If lblAuxIdMaquina.Text <> "" Then
        '    CargarListaDeTareasDeLaMaquina(lblAuxIdMaquina.Text)
        'End If
    End Sub

    Private Function ValidarEditar() As Boolean
        Dim canttildados As Integer = 0

        If lblAuxIdMaquina.Text = "" Then
            MensajeCritico("No hay seleccionada una MÁQUINA. Por favor verifique.")
            ValidarEditar = False
            Exit Function
        End If

        If lblAuxIdMaqTarea.Text = "" Then
            MensajeCritico("No hay seleccionada una TAREA. Por favor verifique.")
            ValidarEditar = False
            Exit Function
        End If

        If txtDuracionTarea.Text <> "" Then
            If Not IsNumeric(txtDuracionTarea.Text) Then
                MensajeCritico("La duración de la tarea debe ser un número.")
                ValidarEditar = False
                Exit Function
            End If
        End If

        ValidarEditar = True
    End Function

    Private Sub EditarTareaDelPlan()
        Dim Command As New SqlCommand
        Dim sStr As String

        Dim i As Integer
        Dim lunes, martes, miercoles, jueves, viernes, sabado, domingo As String

        'valido primero
        If Not ValidarEditar() Then Exit Sub

        If chkLunes.Checked Then
            lunes = "1"
        Else
            lunes = "0"
        End If
        If chkMartes.Checked Then
            martes = "1"
        Else
            martes = "0"
        End If
        If chkMiercoles.Checked Then
            miercoles = "1"
        Else
            miercoles = "0"
        End If
        If chkJueves.Checked Then
            jueves = "1"
        Else
            jueves = "0"
        End If
        If chkViernes.Checked Then
            viernes = "1"
        Else
            viernes = "0"
        End If
        If chkSabado.Checked Then
            sabado = "1"
        Else
            sabado = "0"
        End If
        If chkDomingo.Checked Then
            domingo = "1"
        Else
            domingo = "0"
        End If

        'grabo la tarea 
        If txtDuracionTarea.Text = "" Then
            txtDuracionTarea.Text = "0"
        End If
        sStr = "UPDATE HilaMantePlanMaquinasTareas SET"
        sStr = sStr + " DuracionTarea = " + txtDuracionTarea.Text
        sStr = sStr + ", FrecuenciaTarea='" + cmbFrecuencia.Text + "'"
        sStr = sStr + ", APartirDe='" + Format(dtpAPartirDe.Value, "yyyyMMdd") + "'"
        sStr = sStr + ", Observaciones='" + txtObservaciones.Text + "'"
        sStr = sStr + ", lunes=" + lunes + " "
        sStr = sStr + ", martes=" + martes + " "
        sStr = sStr + ", miercoles=" + miercoles + " "
        sStr = sStr + ", jueves=" + jueves + " "
        sStr = sStr + ", viernes=" + viernes + " "
        sStr = sStr + ", sabado=" + sabado + " "
        sStr = sStr + ", domingo=" + domingo + " "
        sStr = sStr + " WHERE Id=" + lblAuxIdMaqTarea.Text
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        'AHORA LOS RECURSOS, PRIMERO BORRO TODOS Y LUEGO RECARGO LOS QUE ESTAN TILDADOS OTRA VEZ
        sStr = "DELETE FROM HilaMantePlanTareasRecursos WHERE IdMaqTarea=" + lblAuxIdMaqTarea.Text
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()
        For i = 0 To dgvRecursosElegir.RowCount - 1
            If dgvRecursosElegir.Rows(i).Cells("ELEGIR").Value = True Then
                sStr = "INSERT INTO HilaMantePlanTareasRecursos (IdMaqTarea,IdRecurso) VALUES (" + lblAuxIdMaqTarea.Text + "," + dgvRecursosElegir.Rows(i).Cells("ID").Value.ToString + ")"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
            End If
        Next

        'controlo si la fecha desde es anterior a hoy, entonces debo crear la lista de actividades que deberian haberse hecho y no se hicieron
        If Format(dtpAPartirDe.Value, "yyyyMMdd") < Format(Now, "yyyyMMdd") Then
            Dim respuesta As Integer
            respuesta = MsgBox("La Fecha del comienzo de la frecuencia de la Tarea es anterior al día de hoy." + Chr(10) + "Desea crear la lista de actividades anteriores a hoy ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Confirmar creación de actividades.")
            If respuesta = vbYes Then
                CrearListadeActividadesTareaPlanMantenimiento(lblAuxIdMaqTarea.Text, dtpAPartirDe.Value, cmbFrecuencia.Text)
            End If
        End If

        MensajeInfo("Tarea Editada Exitosamente.")

        HabilitoListadoTareas()

        'limpio el id para que no quede viejo
        lblAuxIdMaqTarea.Text = ""

        If lblAuxIdMaquina.Text <> "" Then
            CargarListaDeTareasDeLaMaquina(lblAuxIdMaquina.Text)
        End If

    End Sub

    Private Sub CrearListadeActividadesTareaPlanMantenimiento(ByVal IdMaquinaTarea As String, ByVal FechaDesde As Date, ByVal Frecuencia As String)
        Dim sStrAux As String
        Dim CommandAux As New SqlCommand
        Dim ReaderAux As SqlDataReader

        Dim IntervalType As DateInterval
        Dim cantIntervalType As Integer
        Dim FechaAux As Date

        'AGARRO LA FECHA DE HOY
        Dim FechaHoy As Date = Format(ObtenerFechaServer(), "dd/MM/yyyy")

        If Frecuencia = "Semanal" Then
            IntervalType = DateInterval.Day
            cantIntervalType = 7
        ElseIf Frecuencia = "Diaria" Then
            IntervalType = DateInterval.Day
            cantIntervalType = 1
        ElseIf Frecuencia = "Mensual" Then
            IntervalType = DateInterval.Month
            cantIntervalType = 1
        ElseIf Frecuencia = "Bimestral" Then
            IntervalType = DateInterval.Month
            cantIntervalType = 2
        ElseIf Frecuencia = "Trimestral" Then
            IntervalType = DateInterval.Month
            cantIntervalType = 3
        ElseIf Frecuencia = "Cuatrimestral" Then
            IntervalType = DateInterval.Month
            cantIntervalType = 4
        ElseIf Frecuencia = "Semestral" Then
            IntervalType = DateInterval.Month
            cantIntervalType = 6
        ElseIf Frecuencia = "Anual" Then
            IntervalType = DateInterval.Year
            cantIntervalType = 1
        ElseIf Frecuencia = "Cada 2 años" Then
            IntervalType = DateInterval.Year
            cantIntervalType = 2
        ElseIf Frecuencia = "Cada 3 años" Then
            IntervalType = DateInterval.Year
            cantIntervalType = 3
        ElseIf Frecuencia = "Cada 4 años" Then
            IntervalType = DateInterval.Year
            cantIntervalType = 4
        ElseIf Frecuencia = "Cada 5 años" Then
            IntervalType = DateInterval.Year
            cantIntervalType = 5
        End If

        'agarro la ultima fecha de actividad que tiene cargada la tarea
        sStrAux = "select isnull(max(Fecha),'19000101') as Fecha from HilaManteListadoActividades where IdMaqTarea=" + IdMaquinaTarea + " AND Eliminado = 0 "
        CommandAux = New SqlCommand(sStrAux, cConexionApp.SQLConn)
        ReaderAux = CommandAux.ExecuteReader()
        ReaderAux.Read()
        If Format(ReaderAux.Item("Fecha"), "yyyyMMdd") = "19000101" Then
            FechaAux = FechaDesde
        Else
            FechaAux = ReaderAux.Item("Fecha")
        End If

        'y mientras que la ultima fecha sea menor a hoy corro el proceso para ir armando los vencimientos que no se corrieron
        Do While FechaAux <= FechaHoy
            RevisarAvisosVencimientos(IdMaquinaTarea, FechaAux)
            FechaAux = DateAdd(IntervalType, cantIntervalType, FechaAux)
        Loop

    End Sub
    Public Sub RevisarAvisosVencimientos(ByVal IdMaquinaTarea As String, ByVal Fecha As Date)
        Dim sStr As String
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim IdActividadParaGrabar As String = ""

        'primero que nada si ya ESTA CARGADO
        sStr = "select count(*) as canti from HilaManteListadoActividades where IdMaqTarea=" + IdMaquinaTarea + " "
        sStr = sStr + " and Eliminado = 0 AND FECHA='" + Format(Fecha, "yyyyMMdd") + "'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Reader.Read()
        If CInt(Reader.Item("canti").ToString) <= 0 Then
            ' si no existe, lo creo 
            sStr = "INSERT INTO HilaManteListadoActividades "
            sStr = sStr + "(IdMaqTarea,Fecha,Estado,Eliminado,Observaciones) "
            sStr = sStr + "VALUES "
            sStr = sStr + "(" + IdMaquinaTarea + ",'" + Fecha + "','ALTA',0,'')"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()
            'agarro el id para insertarlo en el historial
            sStr = "SELECT max(Id) as Id FROM HilaManteListadoActividades WHERE Eliminado=0 AND IdMaqTarea=" + IdMaquinaTarea + " "
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read() Then
                    IdActividadParaGrabar = Reader.Item("Id").ToString
                End If
            End If
            ' ademas agrego el inicio del historial
            sStr = "INSERT INTO HilaManteActiHistorial "
            sStr = sStr + "(IdActividad,Fecha,Estado,Legajo,Observaciones,Eliminado) "
            sStr = sStr + "VALUES "
            sStr = sStr + "(" + IdActividadParaGrabar + ",GETDATE(),'ALTA','" + LegajoLogueado + "','',0)"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()

        End If
    End Sub

    '**************************************************************************** COPIAR PLAN ******************************************************************************************************
    Private Sub PrepararVentanaParaCopiarPlan(ByVal IdMaquina As String)
        CargarListadoDeMaquinasParaCopiar()
    End Sub

    Private Sub btnBuscarCopiarPlan_Click(sender As Object, e As EventArgs) Handles btnBuscarCopiarPlan.Click
        CargarListadoDeMaquinasParaCopiar()
    End Sub

    Private Sub txtCopiarBuscaMaq_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCopiarBuscaMaq.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            CargarListadoDeMaquinasParaCopiar()
        End If
    End Sub

    Private Sub CargarListadoDeMaquinasParaCopiar()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        Dim row() As String

        dgvMaqCopiar.Rows.Clear()
        dgvMaqCopiar.Columns.Clear()
        dgvMaqCopiar.Columns.Add("ID", "ID")
        dgvMaqCopiar.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMaqCopiar.Columns("ID").Visible = False
        dgvMaqCopiar.Columns.Add("SECTOR", "SECTOR")
        dgvMaqCopiar.Columns("SECTOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvMaqCopiar.Columns("SECTOR").Width = 170
        dgvMaqCopiar.Columns.Add("MAQUINA", "MAQUINA")
        dgvMaqCopiar.Columns("MAQUINA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvMaqCopiar.Columns("MAQUINA").Width = 330
        dgvMaqCopiar.Columns.Add("IDSECTOR", "IDSECTOR")
        dgvMaqCopiar.Columns("IDSECTOR").Visible = False
        dgvMaqCopiar.Columns.Add("OBSERVACIONES", "OBSERVACIONES")
        dgvMaqCopiar.Columns("OBSERVACIONES").Visible = False
        dgvMaqCopiar.Font = New Font("Arial", 10)

        sStr = "SELECT M.Id as IdMaq,* FROM HilaManteMaquinas M INNER JOIN HilaManteSectores S ON M.IdSector = S.Id WHERE M.Eliminado=0 and M.Nombre like '%" + txtCopiarBuscaMaq.Text + "%' "
        sStr = sStr + " AND M.Id <>" + lblAuxIdMaquina.Text
        sStr = sStr + " order by Nombre,S.Fabrica,S.Sector"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                row = {Reader.Item("IdMaq"), Strings.Left(Reader.Item("Fabrica"), 3) + "-" + Reader.Item("Sector"), Reader.Item("Nombre"), Reader.Item("IdSector"), Reader.Item("Observaciones")}
                dgvMaqCopiar.Rows.Add(row)
            Loop
            Reader.NextResult()
        Loop

    End Sub

    Private Sub btnCopiarPlanCancelar_Click(sender As Object, e As EventArgs) Handles btnCopiarPlanCancelar.Click
        CargarListaDeTareasDeLaMaquina(lblAuxIdMaquina.Text)
        QueEstoyHaciendoConLaTarea = ""
        lblAuxIdMaqTarea.Text = ""
        HabilitoListadoTareas()
    End Sub

    Private Sub btnCopiarPlanOk_Click(sender As Object, e As EventArgs) Handles btnCopiarPlanOk.Click
        Dim Command, CommandTarea, CommandRecurso, CommandGrabar As New SqlCommand
        Dim Reader, ReaderTarea, ReaderRecurso As SqlDataReader
        Dim sStr, sStrTarea, sStrRecurso, sStrGrabar As String
        Dim IdMaqQueCopia As String, IdMaqTareaParaGrabar As String = ""

        If dgvMaqCopiar.SelectedRows.Count <> 1 Then
            MensajeAtencion("Debe seleccionar la Maquina de la que se copiará el Plan")
            Exit Sub
        End If

        Dim respuesta As Integer
        respuesta = MsgBox("Se Dispone a AGREGAR al Plan de tareas de la máquina: " + lblPlanMaquina.Text + Chr(10) + _
                           "las tareas de la máquina: " + dgvMaqCopiar.Rows(dgvMaqCopiar.CurrentRow.Index).Cells("MAQUINA").Value.ToString + Chr(10) + _
                           "Confirma?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Confirmar Copia.")
        If respuesta = vbNo Then Exit Sub

        IdMaqQueCopia = dgvMaqCopiar.Rows(dgvMaqCopiar.CurrentRow.Index).Cells("ID").Value.ToString

        sStr = "select * from HilaMantePlanMaquinasTareas where IdMaquina = " + IdMaqQueCopia + " and Eliminado=0 "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()

                sStrGrabar = "INSERT INTO HilaMantePlanMaquinasTareas (IdMaquina,IdTarea,DuracionTarea,FrecuenciaTarea,APartirDe,Observaciones,Eliminado,lunes,martes,miercoles,jueves,viernes,sabado,domingo) VALUES (" + lblAuxIdMaquina.Text + "," + Reader.Item("IdTarea").ToString
                'sStrGrabar = sStrGrabar + "," + Reader.Item("DuracionTarea").ToString + ",'" + Reader.Item("FrecuenciaTarea").ToString + "','" + Format(Reader.Item("APartirDe"), "yyyyMMdd") + "','" + Reader.Item("Observaciones").ToString + "',0)"
                sStrGrabar = sStrGrabar + "," + Reader.Item("DuracionTarea").ToString + ",'" + Reader.Item("FrecuenciaTarea").ToString + "','" + Reader.Item("APartirDe") + "','" + Reader.Item("Observaciones").ToString + "',0"
                sStrGrabar = sStrGrabar + "," + Reader.Item("lunes").ToString + "," + Reader.Item("martes").ToString + "," + Reader.Item("miercoles").ToString + "," + Reader.Item("jueves").ToString
                sStrGrabar = sStrGrabar + "," + Reader.Item("viernes").ToString + "," + Reader.Item("sabado").ToString + "," + Reader.Item("domingo").ToString + ")"
                CommandGrabar = New SqlCommand(sStrGrabar, cConexionApp.SQLConn)
                CommandGrabar.ExecuteNonQuery()

                'agarro el id para insertarlo en los recursos
                sStrTarea = "SELECT max(Id) as Id FROM HilaMantePlanMaquinasTareas WHERE Eliminado=0 AND IdMaquina=" + lblAuxIdMaquina.Text + " AND IdTarea=" + Reader.Item("IdTarea").ToString + ""
                CommandTarea = New SqlCommand(sStrTarea, cConexionApp.SQLConn)
                ReaderTarea = CommandTarea.ExecuteReader()
                If ReaderTarea.HasRows Then
                    If ReaderTarea.Read() Then
                        IdMaqTareaParaGrabar = ReaderTarea.Item("Id").ToString
                    End If
                End If

                'AHORA LOS RECURSOS 
                If IdMaqTareaParaGrabar <> "" Then
                    sStrRecurso = "select * from HilaMantePlanTareasRecursos where IdMaqTarea = " + Reader.Item("Id").ToString
                    CommandRecurso = New SqlCommand(sStrRecurso, cConexionApp.SQLConn)
                    ReaderRecurso = CommandRecurso.ExecuteReader()
                    Do While ReaderRecurso.HasRows
                        Do While ReaderRecurso.Read()
                            sStrGrabar = "INSERT INTO HilaMantePlanTareasRecursos (IdMaqTarea,IdRecurso) VALUES (" + IdMaqTareaParaGrabar + "," + ReaderRecurso.Item("IdRecurso").ToString + ")"
                            CommandGrabar = New SqlCommand(sStrGrabar, cConexionApp.SQLConn)
                            CommandGrabar.ExecuteNonQuery()
                        Loop
                        ReaderRecurso.NextResult()
                    Loop
                End If

            Loop
            Reader.NextResult()
        Loop

        MensajeAtencion("Se ha copiado exitosamente el Plan.")
        CargarListaDeTareasDeLaMaquina(lblAuxIdMaquina.Text)
        QueEstoyHaciendoConLaTarea = ""
        lblAuxIdMaqTarea.Text = ""
        HabilitoListadoTareas()

    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged

    End Sub

End Class