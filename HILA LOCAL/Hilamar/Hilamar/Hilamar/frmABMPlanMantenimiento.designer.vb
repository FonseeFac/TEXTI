<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmABMPlanMantenimiento
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmABMPlanMantenimiento))
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.dgvMaquinas = New System.Windows.Forms.DataGridView()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.gbOrden = New System.Windows.Forms.GroupBox()
        Me.rbOrdenSector = New System.Windows.Forms.RadioButton()
        Me.rbOrdenMaquina = New System.Windows.Forms.RadioButton()
        Me.gbPlanMantenimiento = New System.Windows.Forms.GroupBox()
        Me.gbAgregarTarea = New System.Windows.Forms.GroupBox()
        Me.chkDomingo = New System.Windows.Forms.CheckBox()
        Me.chkSabado = New System.Windows.Forms.CheckBox()
        Me.chkViernes = New System.Windows.Forms.CheckBox()
        Me.chkJueves = New System.Windows.Forms.CheckBox()
        Me.chkMiercoles = New System.Windows.Forms.CheckBox()
        Me.chkMartes = New System.Windows.Forms.CheckBox()
        Me.chkLunes = New System.Windows.Forms.CheckBox()
        Me.lblTit2DuracionTarea = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.lblTitObservaciones = New System.Windows.Forms.Label()
        Me.lblTitAPartirDe = New System.Windows.Forms.Label()
        Me.dtpAPartirDe = New System.Windows.Forms.DateTimePicker()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.cmbFrecuencia = New System.Windows.Forms.ComboBox()
        Me.lblTitFrecuenciaTarea = New System.Windows.Forms.Label()
        Me.lblTitDuracion = New System.Windows.Forms.Label()
        Me.txtDuracionTarea = New System.Windows.Forms.TextBox()
        Me.lblTitElegirRecursos = New System.Windows.Forms.Label()
        Me.dgvRecursosElegir = New System.Windows.Forms.DataGridView()
        Me.lblTitElegirTarea = New System.Windows.Forms.Label()
        Me.dgvTareasElegir = New System.Windows.Forms.DataGridView()
        Me.gbCopiarPlan = New System.Windows.Forms.GroupBox()
        Me.btnCopiarPlanCancelar = New System.Windows.Forms.Button()
        Me.btnCopiarPlanOk = New System.Windows.Forms.Button()
        Me.dgvMaqCopiar = New System.Windows.Forms.DataGridView()
        Me.btnBuscarCopiarPlan = New System.Windows.Forms.Button()
        Me.lblTitMaqCopiar = New System.Windows.Forms.Label()
        Me.txtCopiarBuscaMaq = New System.Windows.Forms.TextBox()
        Me.lblTitCopiarPlan = New System.Windows.Forms.Label()
        Me.gbBotonera = New System.Windows.Forms.GroupBox()
        Me.btnCopiarPlan = New System.Windows.Forms.Button()
        Me.btnEliminarTarea = New System.Windows.Forms.Button()
        Me.btnEditarTarea = New System.Windows.Forms.Button()
        Me.btnAgregarTarea = New System.Windows.Forms.Button()
        Me.lblAuxIdMaqTarea = New System.Windows.Forms.Label()
        Me.lblAuxIdMaquina = New System.Windows.Forms.Label()
        Me.lblTitListaTareas = New System.Windows.Forms.Label()
        Me.dgvListaTareasAsignadas = New System.Windows.Forms.DataGridView()
        Me.lblPlanMaquina = New System.Windows.Forms.Label()
        Me.lblTitPlanMaquina = New System.Windows.Forms.Label()
        Me.cmbPlantas = New System.Windows.Forms.ComboBox()
        Me.lblPlanta = New System.Windows.Forms.Label()
        CType(Me.dgvMaquinas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbOrden.SuspendLayout()
        Me.gbPlanMantenimiento.SuspendLayout()
        Me.gbAgregarTarea.SuspendLayout()
        CType(Me.dgvRecursosElegir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTareasElegir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCopiarPlan.SuspendLayout()
        CType(Me.dgvMaqCopiar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbBotonera.SuspendLayout()
        CType(Me.dgvListaTareasAsignadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblBuscar
        '
        Me.lblBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBuscar.Location = New System.Drawing.Point(26, 48)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(66, 20)
        Me.lblBuscar.TabIndex = 39
        Me.lblBuscar.Text = "Máquina:"
        Me.lblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBuscar
        '
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(25, 71)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(231, 22)
        Me.txtBuscar.TabIndex = 0
        '
        'dgvMaquinas
        '
        Me.dgvMaquinas.AllowUserToAddRows = False
        Me.dgvMaquinas.AllowUserToDeleteRows = False
        Me.dgvMaquinas.AllowUserToResizeColumns = False
        Me.dgvMaquinas.AllowUserToResizeRows = False
        Me.dgvMaquinas.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvMaquinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMaquinas.Location = New System.Drawing.Point(331, 11)
        Me.dgvMaquinas.Name = "dgvMaquinas"
        Me.dgvMaquinas.ReadOnly = True
        Me.dgvMaquinas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMaquinas.Size = New System.Drawing.Size(565, 144)
        Me.dgvMaquinas.TabIndex = 33
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(910, 123)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(107, 32)
        Me.btnCerrar.TabIndex = 32
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.BackgroundImage = CType(resources.GetObject("btnBuscar.BackgroundImage"), System.Drawing.Image)
        Me.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Location = New System.Drawing.Point(262, 67)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(30, 28)
        Me.btnBuscar.TabIndex = 48
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'gbOrden
        '
        Me.gbOrden.Controls.Add(Me.rbOrdenSector)
        Me.gbOrden.Controls.Add(Me.rbOrdenMaquina)
        Me.gbOrden.Location = New System.Drawing.Point(25, 109)
        Me.gbOrden.Name = "gbOrden"
        Me.gbOrden.Size = New System.Drawing.Size(267, 32)
        Me.gbOrden.TabIndex = 49
        Me.gbOrden.TabStop = False
        Me.gbOrden.Text = "Ordenado por"
        '
        'rbOrdenSector
        '
        Me.rbOrdenSector.AutoSize = True
        Me.rbOrdenSector.Location = New System.Drawing.Point(175, 10)
        Me.rbOrdenSector.Name = "rbOrdenSector"
        Me.rbOrdenSector.Size = New System.Drawing.Size(56, 17)
        Me.rbOrdenSector.TabIndex = 1
        Me.rbOrdenSector.Text = "Sector"
        Me.rbOrdenSector.UseVisualStyleBackColor = True
        '
        'rbOrdenMaquina
        '
        Me.rbOrdenMaquina.AutoSize = True
        Me.rbOrdenMaquina.Checked = True
        Me.rbOrdenMaquina.Location = New System.Drawing.Point(87, 10)
        Me.rbOrdenMaquina.Name = "rbOrdenMaquina"
        Me.rbOrdenMaquina.Size = New System.Drawing.Size(66, 17)
        Me.rbOrdenMaquina.TabIndex = 0
        Me.rbOrdenMaquina.TabStop = True
        Me.rbOrdenMaquina.Text = "Máquina"
        Me.rbOrdenMaquina.UseVisualStyleBackColor = True
        '
        'gbPlanMantenimiento
        '
        Me.gbPlanMantenimiento.Controls.Add(Me.gbCopiarPlan)
        Me.gbPlanMantenimiento.Controls.Add(Me.gbAgregarTarea)
        Me.gbPlanMantenimiento.Controls.Add(Me.gbBotonera)
        Me.gbPlanMantenimiento.Controls.Add(Me.lblAuxIdMaqTarea)
        Me.gbPlanMantenimiento.Controls.Add(Me.lblAuxIdMaquina)
        Me.gbPlanMantenimiento.Controls.Add(Me.lblTitListaTareas)
        Me.gbPlanMantenimiento.Controls.Add(Me.dgvListaTareasAsignadas)
        Me.gbPlanMantenimiento.Controls.Add(Me.lblPlanMaquina)
        Me.gbPlanMantenimiento.Controls.Add(Me.lblTitPlanMaquina)
        Me.gbPlanMantenimiento.Location = New System.Drawing.Point(7, 161)
        Me.gbPlanMantenimiento.Name = "gbPlanMantenimiento"
        Me.gbPlanMantenimiento.Size = New System.Drawing.Size(976, 537)
        Me.gbPlanMantenimiento.TabIndex = 50
        Me.gbPlanMantenimiento.TabStop = False
        Me.gbPlanMantenimiento.Text = "PLAN DE MANTENIMIENTO"
        '
        'gbAgregarTarea
        '
        Me.gbAgregarTarea.Controls.Add(Me.chkDomingo)
        Me.gbAgregarTarea.Controls.Add(Me.chkSabado)
        Me.gbAgregarTarea.Controls.Add(Me.chkViernes)
        Me.gbAgregarTarea.Controls.Add(Me.chkJueves)
        Me.gbAgregarTarea.Controls.Add(Me.chkMiercoles)
        Me.gbAgregarTarea.Controls.Add(Me.chkMartes)
        Me.gbAgregarTarea.Controls.Add(Me.chkLunes)
        Me.gbAgregarTarea.Controls.Add(Me.lblTit2DuracionTarea)
        Me.gbAgregarTarea.Controls.Add(Me.txtObservaciones)
        Me.gbAgregarTarea.Controls.Add(Me.lblTitObservaciones)
        Me.gbAgregarTarea.Controls.Add(Me.lblTitAPartirDe)
        Me.gbAgregarTarea.Controls.Add(Me.dtpAPartirDe)
        Me.gbAgregarTarea.Controls.Add(Me.btnCancelar)
        Me.gbAgregarTarea.Controls.Add(Me.btnOk)
        Me.gbAgregarTarea.Controls.Add(Me.cmbFrecuencia)
        Me.gbAgregarTarea.Controls.Add(Me.lblTitFrecuenciaTarea)
        Me.gbAgregarTarea.Controls.Add(Me.lblTitDuracion)
        Me.gbAgregarTarea.Controls.Add(Me.txtDuracionTarea)
        Me.gbAgregarTarea.Controls.Add(Me.lblTitElegirRecursos)
        Me.gbAgregarTarea.Controls.Add(Me.dgvRecursosElegir)
        Me.gbAgregarTarea.Controls.Add(Me.lblTitElegirTarea)
        Me.gbAgregarTarea.Controls.Add(Me.dgvTareasElegir)
        Me.gbAgregarTarea.Location = New System.Drawing.Point(105, 82)
        Me.gbAgregarTarea.Name = "gbAgregarTarea"
        Me.gbAgregarTarea.Size = New System.Drawing.Size(994, 456)
        Me.gbAgregarTarea.TabIndex = 51
        Me.gbAgregarTarea.TabStop = False
        Me.gbAgregarTarea.Text = "AGREGAR TAREA"
        '
        'chkDomingo
        '
        Me.chkDomingo.AutoSize = True
        Me.chkDomingo.Location = New System.Drawing.Point(648, 352)
        Me.chkDomingo.Name = "chkDomingo"
        Me.chkDomingo.Size = New System.Drawing.Size(78, 17)
        Me.chkDomingo.TabIndex = 104
        Me.chkDomingo.Text = "DOMINGO"
        Me.chkDomingo.UseVisualStyleBackColor = True
        '
        'chkSabado
        '
        Me.chkSabado.AutoSize = True
        Me.chkSabado.Checked = True
        Me.chkSabado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSabado.Location = New System.Drawing.Point(554, 352)
        Me.chkSabado.Name = "chkSabado"
        Me.chkSabado.Size = New System.Drawing.Size(70, 17)
        Me.chkSabado.TabIndex = 103
        Me.chkSabado.Text = "SÁBADO"
        Me.chkSabado.UseVisualStyleBackColor = True
        '
        'chkViernes
        '
        Me.chkViernes.AutoSize = True
        Me.chkViernes.Checked = True
        Me.chkViernes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkViernes.Location = New System.Drawing.Point(460, 352)
        Me.chkViernes.Name = "chkViernes"
        Me.chkViernes.Size = New System.Drawing.Size(73, 17)
        Me.chkViernes.TabIndex = 102
        Me.chkViernes.Text = "VIERNES"
        Me.chkViernes.UseVisualStyleBackColor = True
        '
        'chkJueves
        '
        Me.chkJueves.AutoSize = True
        Me.chkJueves.Checked = True
        Me.chkJueves.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkJueves.Location = New System.Drawing.Point(711, 329)
        Me.chkJueves.Name = "chkJueves"
        Me.chkJueves.Size = New System.Drawing.Size(67, 17)
        Me.chkJueves.TabIndex = 101
        Me.chkJueves.Text = "JUEVES"
        Me.chkJueves.UseVisualStyleBackColor = True
        '
        'chkMiercoles
        '
        Me.chkMiercoles.AutoSize = True
        Me.chkMiercoles.Checked = True
        Me.chkMiercoles.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMiercoles.Location = New System.Drawing.Point(617, 329)
        Me.chkMiercoles.Name = "chkMiercoles"
        Me.chkMiercoles.Size = New System.Drawing.Size(88, 17)
        Me.chkMiercoles.TabIndex = 100
        Me.chkMiercoles.Text = "MIERCOLES"
        Me.chkMiercoles.UseVisualStyleBackColor = True
        '
        'chkMartes
        '
        Me.chkMartes.AutoSize = True
        Me.chkMartes.Checked = True
        Me.chkMartes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMartes.Location = New System.Drawing.Point(539, 329)
        Me.chkMartes.Name = "chkMartes"
        Me.chkMartes.Size = New System.Drawing.Size(71, 17)
        Me.chkMartes.TabIndex = 99
        Me.chkMartes.Text = "MARTES"
        Me.chkMartes.UseVisualStyleBackColor = True
        '
        'chkLunes
        '
        Me.chkLunes.AutoSize = True
        Me.chkLunes.Checked = True
        Me.chkLunes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLunes.Location = New System.Drawing.Point(460, 329)
        Me.chkLunes.Name = "chkLunes"
        Me.chkLunes.Size = New System.Drawing.Size(62, 17)
        Me.chkLunes.TabIndex = 98
        Me.chkLunes.Text = "LUNES"
        Me.chkLunes.UseVisualStyleBackColor = True
        '
        'lblTit2DuracionTarea
        '
        Me.lblTit2DuracionTarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTit2DuracionTarea.Location = New System.Drawing.Point(310, 324)
        Me.lblTit2DuracionTarea.Name = "lblTit2DuracionTarea"
        Me.lblTit2DuracionTarea.Size = New System.Drawing.Size(56, 20)
        Me.lblTit2DuracionTarea.TabIndex = 97
        Me.lblTit2DuracionTarea.Text = "minutos"
        Me.lblTit2DuracionTarea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservaciones.Location = New System.Drawing.Point(197, 284)
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(461, 22)
        Me.txtObservaciones.TabIndex = 96
        '
        'lblTitObservaciones
        '
        Me.lblTitObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitObservaciones.Location = New System.Drawing.Point(30, 284)
        Me.lblTitObservaciones.Name = "lblTitObservaciones"
        Me.lblTitObservaciones.Size = New System.Drawing.Size(141, 20)
        Me.lblTitObservaciones.TabIndex = 95
        Me.lblTitObservaciones.Text = "Observaciones:"
        Me.lblTitObservaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitAPartirDe
        '
        Me.lblTitAPartirDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitAPartirDe.Location = New System.Drawing.Point(30, 410)
        Me.lblTitAPartirDe.Name = "lblTitAPartirDe"
        Me.lblTitAPartirDe.Size = New System.Drawing.Size(141, 20)
        Me.lblTitAPartirDe.TabIndex = 94
        Me.lblTitAPartirDe.Text = "A partir de la fecha:"
        Me.lblTitAPartirDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpAPartirDe
        '
        Me.dtpAPartirDe.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpAPartirDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpAPartirDe.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAPartirDe.Location = New System.Drawing.Point(197, 410)
        Me.dtpAPartirDe.Name = "dtpAPartirDe"
        Me.dtpAPartirDe.Size = New System.Drawing.Size(95, 22)
        Me.dtpAPartirDe.TabIndex = 93
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(811, 410)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(107, 32)
        Me.btnCancelar.TabIndex = 91
        Me.btnCancelar.Text = "CANCELAR"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Location = New System.Drawing.Point(637, 410)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(107, 32)
        Me.btnOk.TabIndex = 90
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'cmbFrecuencia
        '
        Me.cmbFrecuencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFrecuencia.FormattingEnabled = True
        Me.cmbFrecuencia.Location = New System.Drawing.Point(197, 366)
        Me.cmbFrecuencia.Name = "cmbFrecuencia"
        Me.cmbFrecuencia.Size = New System.Drawing.Size(169, 24)
        Me.cmbFrecuencia.TabIndex = 89
        '
        'lblTitFrecuenciaTarea
        '
        Me.lblTitFrecuenciaTarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitFrecuenciaTarea.Location = New System.Drawing.Point(30, 367)
        Me.lblTitFrecuenciaTarea.Name = "lblTitFrecuenciaTarea"
        Me.lblTitFrecuenciaTarea.Size = New System.Drawing.Size(161, 20)
        Me.lblTitFrecuenciaTarea.TabIndex = 46
        Me.lblTitFrecuenciaTarea.Text = "Frecuencia de la Tarea:"
        Me.lblTitFrecuenciaTarea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitDuracion
        '
        Me.lblTitDuracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitDuracion.Location = New System.Drawing.Point(30, 324)
        Me.lblTitDuracion.Name = "lblTitDuracion"
        Me.lblTitDuracion.Size = New System.Drawing.Size(144, 20)
        Me.lblTitDuracion.TabIndex = 44
        Me.lblTitDuracion.Text = "Duración de la Tarea:"
        Me.lblTitDuracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDuracionTarea
        '
        Me.txtDuracionTarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDuracionTarea.Location = New System.Drawing.Point(197, 324)
        Me.txtDuracionTarea.Name = "txtDuracionTarea"
        Me.txtDuracionTarea.Size = New System.Drawing.Size(95, 22)
        Me.txtDuracionTarea.TabIndex = 43
        Me.txtDuracionTarea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTitElegirRecursos
        '
        Me.lblTitElegirRecursos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitElegirRecursos.Location = New System.Drawing.Point(614, 20)
        Me.lblTitElegirRecursos.Name = "lblTitElegirRecursos"
        Me.lblTitElegirRecursos.Size = New System.Drawing.Size(291, 20)
        Me.lblTitElegirRecursos.TabIndex = 42
        Me.lblTitElegirRecursos.Text = "Seleccione los Recursos que se necesitan"
        Me.lblTitElegirRecursos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvRecursosElegir
        '
        Me.dgvRecursosElegir.AllowUserToAddRows = False
        Me.dgvRecursosElegir.AllowUserToDeleteRows = False
        Me.dgvRecursosElegir.AllowUserToResizeColumns = False
        Me.dgvRecursosElegir.AllowUserToResizeRows = False
        Me.dgvRecursosElegir.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvRecursosElegir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecursosElegir.Location = New System.Drawing.Point(609, 43)
        Me.dgvRecursosElegir.Name = "dgvRecursosElegir"
        Me.dgvRecursosElegir.RowHeadersVisible = False
        Me.dgvRecursosElegir.RowHeadersWidth = 20
        Me.dgvRecursosElegir.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRecursosElegir.Size = New System.Drawing.Size(374, 207)
        Me.dgvRecursosElegir.TabIndex = 41
        '
        'lblTitElegirTarea
        '
        Me.lblTitElegirTarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitElegirTarea.Location = New System.Drawing.Point(9, 20)
        Me.lblTitElegirTarea.Name = "lblTitElegirTarea"
        Me.lblTitElegirTarea.Size = New System.Drawing.Size(291, 20)
        Me.lblTitElegirTarea.TabIndex = 40
        Me.lblTitElegirTarea.Text = "Seleccione la Tarea que se va a agregar"
        Me.lblTitElegirTarea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvTareasElegir
        '
        Me.dgvTareasElegir.AllowUserToAddRows = False
        Me.dgvTareasElegir.AllowUserToDeleteRows = False
        Me.dgvTareasElegir.AllowUserToResizeColumns = False
        Me.dgvTareasElegir.AllowUserToResizeRows = False
        Me.dgvTareasElegir.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvTareasElegir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTareasElegir.Location = New System.Drawing.Point(9, 43)
        Me.dgvTareasElegir.Name = "dgvTareasElegir"
        Me.dgvTareasElegir.RowHeadersVisible = False
        Me.dgvTareasElegir.RowHeadersWidth = 20
        Me.dgvTareasElegir.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTareasElegir.Size = New System.Drawing.Size(573, 207)
        Me.dgvTareasElegir.TabIndex = 34
        '
        'gbCopiarPlan
        '
        Me.gbCopiarPlan.Controls.Add(Me.btnCopiarPlanCancelar)
        Me.gbCopiarPlan.Controls.Add(Me.btnCopiarPlanOk)
        Me.gbCopiarPlan.Controls.Add(Me.dgvMaqCopiar)
        Me.gbCopiarPlan.Controls.Add(Me.btnBuscarCopiarPlan)
        Me.gbCopiarPlan.Controls.Add(Me.lblTitMaqCopiar)
        Me.gbCopiarPlan.Controls.Add(Me.txtCopiarBuscaMaq)
        Me.gbCopiarPlan.Controls.Add(Me.lblTitCopiarPlan)
        Me.gbCopiarPlan.Location = New System.Drawing.Point(18, 102)
        Me.gbCopiarPlan.Name = "gbCopiarPlan"
        Me.gbCopiarPlan.Size = New System.Drawing.Size(641, 326)
        Me.gbCopiarPlan.TabIndex = 51
        Me.gbCopiarPlan.TabStop = False
        Me.gbCopiarPlan.Text = "COPIAR DESDE UN PLAN YA EXISTENTE"
        '
        'btnCopiarPlanCancelar
        '
        Me.btnCopiarPlanCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopiarPlanCancelar.Location = New System.Drawing.Point(335, 279)
        Me.btnCopiarPlanCancelar.Name = "btnCopiarPlanCancelar"
        Me.btnCopiarPlanCancelar.Size = New System.Drawing.Size(139, 32)
        Me.btnCopiarPlanCancelar.TabIndex = 93
        Me.btnCopiarPlanCancelar.Text = "CANCELAR"
        Me.btnCopiarPlanCancelar.UseVisualStyleBackColor = True
        '
        'btnCopiarPlanOk
        '
        Me.btnCopiarPlanOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopiarPlanOk.Location = New System.Drawing.Point(120, 279)
        Me.btnCopiarPlanOk.Name = "btnCopiarPlanOk"
        Me.btnCopiarPlanOk.Size = New System.Drawing.Size(148, 32)
        Me.btnCopiarPlanOk.TabIndex = 92
        Me.btnCopiarPlanOk.Text = "COPIAR PLAN"
        Me.btnCopiarPlanOk.UseVisualStyleBackColor = True
        '
        'dgvMaqCopiar
        '
        Me.dgvMaqCopiar.AllowUserToAddRows = False
        Me.dgvMaqCopiar.AllowUserToDeleteRows = False
        Me.dgvMaqCopiar.AllowUserToResizeColumns = False
        Me.dgvMaqCopiar.AllowUserToResizeRows = False
        Me.dgvMaqCopiar.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvMaqCopiar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMaqCopiar.Location = New System.Drawing.Point(18, 77)
        Me.dgvMaqCopiar.Name = "dgvMaqCopiar"
        Me.dgvMaqCopiar.ReadOnly = True
        Me.dgvMaqCopiar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMaqCopiar.Size = New System.Drawing.Size(578, 184)
        Me.dgvMaqCopiar.TabIndex = 52
        '
        'btnBuscarCopiarPlan
        '
        Me.btnBuscarCopiarPlan.BackgroundImage = CType(resources.GetObject("btnBuscarCopiarPlan.BackgroundImage"), System.Drawing.Image)
        Me.btnBuscarCopiarPlan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarCopiarPlan.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarCopiarPlan.Location = New System.Drawing.Point(412, 43)
        Me.btnBuscarCopiarPlan.Name = "btnBuscarCopiarPlan"
        Me.btnBuscarCopiarPlan.Size = New System.Drawing.Size(30, 28)
        Me.btnBuscarCopiarPlan.TabIndex = 51
        Me.btnBuscarCopiarPlan.UseVisualStyleBackColor = True
        '
        'lblTitMaqCopiar
        '
        Me.lblTitMaqCopiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitMaqCopiar.Location = New System.Drawing.Point(20, 48)
        Me.lblTitMaqCopiar.Name = "lblTitMaqCopiar"
        Me.lblTitMaqCopiar.Size = New System.Drawing.Size(66, 20)
        Me.lblTitMaqCopiar.TabIndex = 50
        Me.lblTitMaqCopiar.Text = "Máquina:"
        Me.lblTitMaqCopiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCopiarBuscaMaq
        '
        Me.txtCopiarBuscaMaq.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCopiarBuscaMaq.Location = New System.Drawing.Point(92, 47)
        Me.txtCopiarBuscaMaq.Name = "txtCopiarBuscaMaq"
        Me.txtCopiarBuscaMaq.Size = New System.Drawing.Size(314, 22)
        Me.txtCopiarBuscaMaq.TabIndex = 49
        '
        'lblTitCopiarPlan
        '
        Me.lblTitCopiarPlan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitCopiarPlan.Location = New System.Drawing.Point(20, 18)
        Me.lblTitCopiarPlan.Name = "lblTitCopiarPlan"
        Me.lblTitCopiarPlan.Size = New System.Drawing.Size(597, 20)
        Me.lblTitCopiarPlan.TabIndex = 41
        Me.lblTitCopiarPlan.Text = "Seleccione la máquina de la que va a copiar el plan de tareas"
        Me.lblTitCopiarPlan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbBotonera
        '
        Me.gbBotonera.Controls.Add(Me.btnCopiarPlan)
        Me.gbBotonera.Controls.Add(Me.btnEliminarTarea)
        Me.gbBotonera.Controls.Add(Me.btnEditarTarea)
        Me.gbBotonera.Controls.Add(Me.btnAgregarTarea)
        Me.gbBotonera.Location = New System.Drawing.Point(6, 216)
        Me.gbBotonera.Name = "gbBotonera"
        Me.gbBotonera.Size = New System.Drawing.Size(757, 42)
        Me.gbBotonera.TabIndex = 50
        Me.gbBotonera.TabStop = False
        '
        'btnCopiarPlan
        '
        Me.btnCopiarPlan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopiarPlan.Location = New System.Drawing.Point(559, 12)
        Me.btnCopiarPlan.Name = "btnCopiarPlan"
        Me.btnCopiarPlan.Size = New System.Drawing.Size(153, 24)
        Me.btnCopiarPlan.TabIndex = 47
        Me.btnCopiarPlan.Text = "Copiar Plan"
        Me.btnCopiarPlan.UseVisualStyleBackColor = True
        '
        'btnEliminarTarea
        '
        Me.btnEliminarTarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminarTarea.Location = New System.Drawing.Point(382, 12)
        Me.btnEliminarTarea.Name = "btnEliminarTarea"
        Me.btnEliminarTarea.Size = New System.Drawing.Size(153, 24)
        Me.btnEliminarTarea.TabIndex = 46
        Me.btnEliminarTarea.Text = "Eliminar Tarea"
        Me.btnEliminarTarea.UseVisualStyleBackColor = True
        '
        'btnEditarTarea
        '
        Me.btnEditarTarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditarTarea.Location = New System.Drawing.Point(209, 12)
        Me.btnEditarTarea.Name = "btnEditarTarea"
        Me.btnEditarTarea.Size = New System.Drawing.Size(152, 24)
        Me.btnEditarTarea.TabIndex = 45
        Me.btnEditarTarea.Text = "Editar Tarea"
        Me.btnEditarTarea.UseVisualStyleBackColor = True
        '
        'btnAgregarTarea
        '
        Me.btnAgregarTarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarTarea.Location = New System.Drawing.Point(35, 12)
        Me.btnAgregarTarea.Name = "btnAgregarTarea"
        Me.btnAgregarTarea.Size = New System.Drawing.Size(156, 24)
        Me.btnAgregarTarea.TabIndex = 44
        Me.btnAgregarTarea.Text = "Agregar Tarea"
        Me.btnAgregarTarea.UseVisualStyleBackColor = True
        '
        'lblAuxIdMaqTarea
        '
        Me.lblAuxIdMaqTarea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAuxIdMaqTarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAuxIdMaqTarea.Location = New System.Drawing.Point(397, 16)
        Me.lblAuxIdMaqTarea.Name = "lblAuxIdMaqTarea"
        Me.lblAuxIdMaqTarea.Size = New System.Drawing.Size(27, 20)
        Me.lblAuxIdMaqTarea.TabIndex = 53
        Me.lblAuxIdMaqTarea.Text = "ID"
        Me.lblAuxIdMaqTarea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAuxIdMaqTarea.Visible = False
        '
        'lblAuxIdMaquina
        '
        Me.lblAuxIdMaquina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAuxIdMaquina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAuxIdMaquina.Location = New System.Drawing.Point(430, 16)
        Me.lblAuxIdMaquina.Name = "lblAuxIdMaquina"
        Me.lblAuxIdMaquina.Size = New System.Drawing.Size(27, 20)
        Me.lblAuxIdMaquina.TabIndex = 52
        Me.lblAuxIdMaquina.Text = "ID"
        Me.lblAuxIdMaquina.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblAuxIdMaquina.Visible = False
        '
        'lblTitListaTareas
        '
        Me.lblTitListaTareas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitListaTareas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitListaTareas.Location = New System.Drawing.Point(10, 59)
        Me.lblTitListaTareas.Name = "lblTitListaTareas"
        Me.lblTitListaTareas.Size = New System.Drawing.Size(109, 20)
        Me.lblTitListaTareas.TabIndex = 43
        Me.lblTitListaTareas.Text = "Lista de Tareas"
        Me.lblTitListaTareas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvListaTareasAsignadas
        '
        Me.dgvListaTareasAsignadas.AllowUserToAddRows = False
        Me.dgvListaTareasAsignadas.AllowUserToDeleteRows = False
        Me.dgvListaTareasAsignadas.AllowUserToResizeColumns = False
        Me.dgvListaTareasAsignadas.AllowUserToResizeRows = False
        Me.dgvListaTareasAsignadas.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvListaTareasAsignadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListaTareasAsignadas.Location = New System.Drawing.Point(6, 141)
        Me.dgvListaTareasAsignadas.Name = "dgvListaTareasAsignadas"
        Me.dgvListaTareasAsignadas.ReadOnly = True
        Me.dgvListaTareasAsignadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListaTareasAsignadas.Size = New System.Drawing.Size(270, 69)
        Me.dgvListaTareasAsignadas.TabIndex = 42
        '
        'lblPlanMaquina
        '
        Me.lblPlanMaquina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPlanMaquina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlanMaquina.Location = New System.Drawing.Point(75, 26)
        Me.lblPlanMaquina.Name = "lblPlanMaquina"
        Me.lblPlanMaquina.Size = New System.Drawing.Size(304, 20)
        Me.lblPlanMaquina.TabIndex = 41
        Me.lblPlanMaquina.Text = "Nombre Maquina"
        Me.lblPlanMaquina.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitPlanMaquina
        '
        Me.lblTitPlanMaquina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitPlanMaquina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitPlanMaquina.Location = New System.Drawing.Point(10, 26)
        Me.lblTitPlanMaquina.Name = "lblTitPlanMaquina"
        Me.lblTitPlanMaquina.Size = New System.Drawing.Size(66, 20)
        Me.lblTitPlanMaquina.TabIndex = 40
        Me.lblTitPlanMaquina.Text = "Máquina:"
        Me.lblTitPlanMaquina.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbPlantas
        '
        Me.cmbPlantas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPlantas.FormattingEnabled = True
        Me.cmbPlantas.Location = New System.Drawing.Point(82, 14)
        Me.cmbPlantas.Name = "cmbPlantas"
        Me.cmbPlantas.Size = New System.Drawing.Size(174, 23)
        Me.cmbPlantas.TabIndex = 113
        '
        'lblPlanta
        '
        Me.lblPlanta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlanta.Location = New System.Drawing.Point(26, 15)
        Me.lblPlanta.Name = "lblPlanta"
        Me.lblPlanta.Size = New System.Drawing.Size(66, 20)
        Me.lblPlanta.TabIndex = 112
        Me.lblPlanta.Text = "Planta:"
        Me.lblPlanta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmABMPlanMantenimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1027, 704)
        Me.Controls.Add(Me.cmbPlantas)
        Me.Controls.Add(Me.lblPlanta)
        Me.Controls.Add(Me.gbPlanMantenimiento)
        Me.Controls.Add(Me.gbOrden)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.lblBuscar)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.dgvMaquinas)
        Me.Controls.Add(Me.btnCerrar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmABMPlanMantenimiento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM Plan de Mantenimiento"
        CType(Me.dgvMaquinas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbOrden.ResumeLayout(False)
        Me.gbOrden.PerformLayout()
        Me.gbPlanMantenimiento.ResumeLayout(False)
        Me.gbAgregarTarea.ResumeLayout(False)
        Me.gbAgregarTarea.PerformLayout()
        CType(Me.dgvRecursosElegir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTareasElegir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCopiarPlan.ResumeLayout(False)
        Me.gbCopiarPlan.PerformLayout()
        CType(Me.dgvMaqCopiar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbBotonera.ResumeLayout(False)
        CType(Me.dgvListaTareasAsignadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents dgvMaquinas As System.Windows.Forms.DataGridView
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents gbOrden As System.Windows.Forms.GroupBox
    Friend WithEvents rbOrdenSector As System.Windows.Forms.RadioButton
    Friend WithEvents rbOrdenMaquina As System.Windows.Forms.RadioButton
    Friend WithEvents gbPlanMantenimiento As System.Windows.Forms.GroupBox
    Friend WithEvents lblTitListaTareas As System.Windows.Forms.Label
    Friend WithEvents dgvListaTareasAsignadas As System.Windows.Forms.DataGridView
    Friend WithEvents lblPlanMaquina As System.Windows.Forms.Label
    Friend WithEvents lblTitPlanMaquina As System.Windows.Forms.Label
    Friend WithEvents gbBotonera As System.Windows.Forms.GroupBox
    Friend WithEvents btnEliminarTarea As System.Windows.Forms.Button
    Friend WithEvents btnEditarTarea As System.Windows.Forms.Button
    Friend WithEvents btnAgregarTarea As System.Windows.Forms.Button
    Friend WithEvents gbAgregarTarea As System.Windows.Forms.GroupBox
    Friend WithEvents cmbFrecuencia As System.Windows.Forms.ComboBox
    Friend WithEvents lblTitFrecuenciaTarea As System.Windows.Forms.Label
    Friend WithEvents lblTitDuracion As System.Windows.Forms.Label
    Friend WithEvents txtDuracionTarea As System.Windows.Forms.TextBox
    Friend WithEvents lblTitElegirRecursos As System.Windows.Forms.Label
    Friend WithEvents dgvRecursosElegir As System.Windows.Forms.DataGridView
    Friend WithEvents lblTitElegirTarea As System.Windows.Forms.Label
    Friend WithEvents dgvTareasElegir As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents lblTitAPartirDe As System.Windows.Forms.Label
    Friend WithEvents dtpAPartirDe As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblAuxIdMaquina As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents lblTitObservaciones As System.Windows.Forms.Label
    Friend WithEvents lblTit2DuracionTarea As System.Windows.Forms.Label
    Friend WithEvents lblAuxIdMaqTarea As System.Windows.Forms.Label
    Friend WithEvents btnCopiarPlan As System.Windows.Forms.Button
    Friend WithEvents gbCopiarPlan As System.Windows.Forms.GroupBox
    Friend WithEvents dgvMaqCopiar As System.Windows.Forms.DataGridView
    Friend WithEvents btnBuscarCopiarPlan As System.Windows.Forms.Button
    Friend WithEvents lblTitMaqCopiar As System.Windows.Forms.Label
    Friend WithEvents txtCopiarBuscaMaq As System.Windows.Forms.TextBox
    Friend WithEvents lblTitCopiarPlan As System.Windows.Forms.Label
    Friend WithEvents btnCopiarPlanCancelar As System.Windows.Forms.Button
    Friend WithEvents btnCopiarPlanOk As System.Windows.Forms.Button
    Friend WithEvents cmbPlantas As System.Windows.Forms.ComboBox
    Friend WithEvents lblPlanta As System.Windows.Forms.Label
    Friend WithEvents chkLunes As System.Windows.Forms.CheckBox
    Friend WithEvents chkMiercoles As System.Windows.Forms.CheckBox
    Friend WithEvents chkMartes As System.Windows.Forms.CheckBox
    Friend WithEvents chkDomingo As System.Windows.Forms.CheckBox
    Friend WithEvents chkSabado As System.Windows.Forms.CheckBox
    Friend WithEvents chkViernes As System.Windows.Forms.CheckBox
    Friend WithEvents chkJueves As System.Windows.Forms.CheckBox
End Class
