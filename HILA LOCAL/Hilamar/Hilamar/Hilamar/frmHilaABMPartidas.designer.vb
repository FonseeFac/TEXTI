<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHilaABMPartidas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHilaABMPartidas))
        Me.gbModificarPartida = New System.Windows.Forms.GroupBox()
        Me.lblNoTieneFecha = New System.Windows.Forms.Label()
        Me.dtpModFechaAlta = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEditarPartidaObservacion = New System.Windows.Forms.TextBox()
        Me.lblEditarPartidaObservacion = New System.Windows.Forms.Label()
        Me.txtEditarNuevoStockActual = New System.Windows.Forms.TextBox()
        Me.lblEditarNuevoStock = New System.Windows.Forms.Label()
        Me.txtEditarKilosFechaFinal = New System.Windows.Forms.TextBox()
        Me.lblEditarKilosFechaFinal = New System.Windows.Forms.Label()
        Me.txtEditarStockActual = New System.Windows.Forms.TextBox()
        Me.lblEditarStockActual = New System.Windows.Forms.Label()
        Me.txtEditarKilosFechaInicial = New System.Windows.Forms.TextBox()
        Me.lblEditarKilosFechaInicial = New System.Windows.Forms.Label()
        Me.txtEditarKilos = New System.Windows.Forms.TextBox()
        Me.lblEditarKilos = New System.Windows.Forms.Label()
        Me.txtEditarPartidaOrigen = New System.Windows.Forms.TextBox()
        Me.lblEditarPartidaOrigen = New System.Windows.Forms.Label()
        Me.cmbEditarHilado = New System.Windows.Forms.ComboBox()
        Me.lblEditarHilado = New System.Windows.Forms.Label()
        Me.txtEditarColorCono = New System.Windows.Forms.TextBox()
        Me.lblEditarColorCono = New System.Windows.Forms.Label()
        Me.txtEditarColor = New System.Windows.Forms.TextBox()
        Me.lblEditarColor = New System.Windows.Forms.Label()
        Me.btnCancelarEditarPartida = New System.Windows.Forms.Button()
        Me.btnOkEditarPartida = New System.Windows.Forms.Button()
        Me.lblEditarPartida = New System.Windows.Forms.Label()
        Me.txtEditarPartida = New System.Windows.Forms.TextBox()
        Me.chkEsDiscontinuada = New System.Windows.Forms.CheckBox()
        Me.gbAgregarPartida = New System.Windows.Forms.GroupBox()
        Me.detFechaAltaPartida = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAgregarObservacion = New System.Windows.Forms.TextBox()
        Me.lblAgregarObservacion = New System.Windows.Forms.Label()
        Me.txtAgregarKilos = New System.Windows.Forms.TextBox()
        Me.lblAgregarKilos = New System.Windows.Forms.Label()
        Me.txtAgregarPartidaOrigen = New System.Windows.Forms.TextBox()
        Me.lblAgregarPartidaOrigen = New System.Windows.Forms.Label()
        Me.cmbAgregarHilado = New System.Windows.Forms.ComboBox()
        Me.lblAgregarHilado = New System.Windows.Forms.Label()
        Me.txtAgregarColorCono = New System.Windows.Forms.TextBox()
        Me.lblAgregarColorCono = New System.Windows.Forms.Label()
        Me.txtAgregarColor = New System.Windows.Forms.TextBox()
        Me.lblAgregarColor = New System.Windows.Forms.Label()
        Me.btnCancelarAgregarPartida = New System.Windows.Forms.Button()
        Me.btnOkAgregarPartida = New System.Windows.Forms.Button()
        Me.lblAgregarPartida = New System.Windows.Forms.Label()
        Me.txtAgregarPartida = New System.Windows.Forms.TextBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.dgvPartidas = New System.Windows.Forms.DataGridView()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.gbFiltroStock = New System.Windows.Forms.GroupBox()
        Me.rbFiltroStockConStock = New System.Windows.Forms.RadioButton()
        Me.rbFiltroStockSinStock = New System.Windows.Forms.RadioButton()
        Me.rbFiltroStockTodas = New System.Windows.Forms.RadioButton()
        Me.btnListar = New System.Windows.Forms.Button()
        Me.txtFiltroPartida = New System.Windows.Forms.TextBox()
        Me.lblFiltroPartida = New System.Windows.Forms.Label()
        Me.lblFiltroHilado = New System.Windows.Forms.Label()
        Me.txtFiltroHilado = New System.Windows.Forms.TextBox()
        Me.gbModificarPartida.SuspendLayout()
        Me.gbAgregarPartida.SuspendLayout()
        CType(Me.dgvPartidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFiltroStock.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbModificarPartida
        '
        Me.gbModificarPartida.Controls.Add(Me.lblNoTieneFecha)
        Me.gbModificarPartida.Controls.Add(Me.dtpModFechaAlta)
        Me.gbModificarPartida.Controls.Add(Me.Label2)
        Me.gbModificarPartida.Controls.Add(Me.txtEditarPartidaObservacion)
        Me.gbModificarPartida.Controls.Add(Me.lblEditarPartidaObservacion)
        Me.gbModificarPartida.Controls.Add(Me.txtEditarNuevoStockActual)
        Me.gbModificarPartida.Controls.Add(Me.lblEditarNuevoStock)
        Me.gbModificarPartida.Controls.Add(Me.txtEditarKilosFechaFinal)
        Me.gbModificarPartida.Controls.Add(Me.lblEditarKilosFechaFinal)
        Me.gbModificarPartida.Controls.Add(Me.txtEditarStockActual)
        Me.gbModificarPartida.Controls.Add(Me.lblEditarStockActual)
        Me.gbModificarPartida.Controls.Add(Me.txtEditarKilosFechaInicial)
        Me.gbModificarPartida.Controls.Add(Me.lblEditarKilosFechaInicial)
        Me.gbModificarPartida.Controls.Add(Me.txtEditarKilos)
        Me.gbModificarPartida.Controls.Add(Me.lblEditarKilos)
        Me.gbModificarPartida.Controls.Add(Me.txtEditarPartidaOrigen)
        Me.gbModificarPartida.Controls.Add(Me.lblEditarPartidaOrigen)
        Me.gbModificarPartida.Controls.Add(Me.cmbEditarHilado)
        Me.gbModificarPartida.Controls.Add(Me.lblEditarHilado)
        Me.gbModificarPartida.Controls.Add(Me.txtEditarColorCono)
        Me.gbModificarPartida.Controls.Add(Me.lblEditarColorCono)
        Me.gbModificarPartida.Controls.Add(Me.txtEditarColor)
        Me.gbModificarPartida.Controls.Add(Me.lblEditarColor)
        Me.gbModificarPartida.Controls.Add(Me.btnCancelarEditarPartida)
        Me.gbModificarPartida.Controls.Add(Me.btnOkEditarPartida)
        Me.gbModificarPartida.Controls.Add(Me.lblEditarPartida)
        Me.gbModificarPartida.Controls.Add(Me.txtEditarPartida)
        Me.gbModificarPartida.Controls.Add(Me.chkEsDiscontinuada)
        Me.gbModificarPartida.Location = New System.Drawing.Point(987, 12)
        Me.gbModificarPartida.Name = "gbModificarPartida"
        Me.gbModificarPartida.Size = New System.Drawing.Size(354, 540)
        Me.gbModificarPartida.TabIndex = 48
        Me.gbModificarPartida.TabStop = False
        Me.gbModificarPartida.Text = "MODIFICAR UNA PARTIDA"
        '
        'lblNoTieneFecha
        '
        Me.lblNoTieneFecha.BackColor = System.Drawing.Color.DarkOrange
        Me.lblNoTieneFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoTieneFecha.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNoTieneFecha.Location = New System.Drawing.Point(151, 32)
        Me.lblNoTieneFecha.Name = "lblNoTieneFecha"
        Me.lblNoTieneFecha.Size = New System.Drawing.Size(200, 20)
        Me.lblNoTieneFecha.TabIndex = 64
        Me.lblNoTieneFecha.Text = "La partida no tiene fecha de alta"
        Me.lblNoTieneFecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblNoTieneFecha.Visible = False
        '
        'dtpModFechaAlta
        '
        Me.dtpModFechaAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpModFechaAlta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpModFechaAlta.Location = New System.Drawing.Point(206, 66)
        Me.dtpModFechaAlta.Name = "dtpModFechaAlta"
        Me.dtpModFechaAlta.Size = New System.Drawing.Size(86, 22)
        Me.dtpModFechaAlta.TabIndex = 49
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(175, 20)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Fecha de Alta de la Partida:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEditarPartidaObservacion
        '
        Me.txtEditarPartidaObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditarPartidaObservacion.Location = New System.Drawing.Point(99, 266)
        Me.txtEditarPartidaObservacion.Name = "txtEditarPartidaObservacion"
        Me.txtEditarPartidaObservacion.Size = New System.Drawing.Size(249, 22)
        Me.txtEditarPartidaObservacion.TabIndex = 63
        '
        'lblEditarPartidaObservacion
        '
        Me.lblEditarPartidaObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarPartidaObservacion.Location = New System.Drawing.Point(10, 266)
        Me.lblEditarPartidaObservacion.Name = "lblEditarPartidaObservacion"
        Me.lblEditarPartidaObservacion.Size = New System.Drawing.Size(91, 20)
        Me.lblEditarPartidaObservacion.TabIndex = 62
        Me.lblEditarPartidaObservacion.Text = "Observación:"
        Me.lblEditarPartidaObservacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEditarNuevoStockActual
        '
        Me.txtEditarNuevoStockActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditarNuevoStockActual.Location = New System.Drawing.Point(143, 421)
        Me.txtEditarNuevoStockActual.Name = "txtEditarNuevoStockActual"
        Me.txtEditarNuevoStockActual.Size = New System.Drawing.Size(194, 22)
        Me.txtEditarNuevoStockActual.TabIndex = 60
        '
        'lblEditarNuevoStock
        '
        Me.lblEditarNuevoStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarNuevoStock.Location = New System.Drawing.Point(10, 421)
        Me.lblEditarNuevoStock.Name = "lblEditarNuevoStock"
        Me.lblEditarNuevoStock.Size = New System.Drawing.Size(129, 20)
        Me.lblEditarNuevoStock.TabIndex = 59
        Me.lblEditarNuevoStock.Text = "Nuevo Stock Actual:"
        Me.lblEditarNuevoStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEditarKilosFechaFinal
        '
        Me.txtEditarKilosFechaFinal.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txtEditarKilosFechaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditarKilosFechaFinal.Location = New System.Drawing.Point(144, 359)
        Me.txtEditarKilosFechaFinal.Name = "txtEditarKilosFechaFinal"
        Me.txtEditarKilosFechaFinal.Size = New System.Drawing.Size(202, 22)
        Me.txtEditarKilosFechaFinal.TabIndex = 58
        Me.txtEditarKilosFechaFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblEditarKilosFechaFinal
        '
        Me.lblEditarKilosFechaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarKilosFechaFinal.Location = New System.Drawing.Point(10, 361)
        Me.lblEditarKilosFechaFinal.Name = "lblEditarKilosFechaFinal"
        Me.lblEditarKilosFechaFinal.Size = New System.Drawing.Size(129, 20)
        Me.lblEditarKilosFechaFinal.TabIndex = 57
        Me.lblEditarKilosFechaFinal.Text = "Fecha Kilos Final:"
        Me.lblEditarKilosFechaFinal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEditarStockActual
        '
        Me.txtEditarStockActual.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txtEditarStockActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditarStockActual.Location = New System.Drawing.Point(143, 390)
        Me.txtEditarStockActual.Name = "txtEditarStockActual"
        Me.txtEditarStockActual.Size = New System.Drawing.Size(202, 22)
        Me.txtEditarStockActual.TabIndex = 56
        Me.txtEditarStockActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblEditarStockActual
        '
        Me.lblEditarStockActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarStockActual.Location = New System.Drawing.Point(10, 390)
        Me.lblEditarStockActual.Name = "lblEditarStockActual"
        Me.lblEditarStockActual.Size = New System.Drawing.Size(129, 20)
        Me.lblEditarStockActual.TabIndex = 55
        Me.lblEditarStockActual.Text = "Stock Actual:"
        Me.lblEditarStockActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEditarKilosFechaInicial
        '
        Me.txtEditarKilosFechaInicial.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txtEditarKilosFechaInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditarKilosFechaInicial.Location = New System.Drawing.Point(143, 330)
        Me.txtEditarKilosFechaInicial.Name = "txtEditarKilosFechaInicial"
        Me.txtEditarKilosFechaInicial.Size = New System.Drawing.Size(202, 22)
        Me.txtEditarKilosFechaInicial.TabIndex = 54
        Me.txtEditarKilosFechaInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblEditarKilosFechaInicial
        '
        Me.lblEditarKilosFechaInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarKilosFechaInicial.Location = New System.Drawing.Point(10, 330)
        Me.lblEditarKilosFechaInicial.Name = "lblEditarKilosFechaInicial"
        Me.lblEditarKilosFechaInicial.Size = New System.Drawing.Size(129, 20)
        Me.lblEditarKilosFechaInicial.TabIndex = 53
        Me.lblEditarKilosFechaInicial.Text = "Fecha Kilos Inicial:"
        Me.lblEditarKilosFechaInicial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEditarKilos
        '
        Me.txtEditarKilos.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txtEditarKilos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditarKilos.Location = New System.Drawing.Point(99, 296)
        Me.txtEditarKilos.Name = "txtEditarKilos"
        Me.txtEditarKilos.Size = New System.Drawing.Size(249, 22)
        Me.txtEditarKilos.TabIndex = 52
        Me.txtEditarKilos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblEditarKilos
        '
        Me.lblEditarKilos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarKilos.Location = New System.Drawing.Point(10, 296)
        Me.lblEditarKilos.Name = "lblEditarKilos"
        Me.lblEditarKilos.Size = New System.Drawing.Size(102, 20)
        Me.lblEditarKilos.TabIndex = 51
        Me.lblEditarKilos.Text = "Kilos Inicial:"
        Me.lblEditarKilos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEditarPartidaOrigen
        '
        Me.txtEditarPartidaOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditarPartidaOrigen.Location = New System.Drawing.Point(99, 229)
        Me.txtEditarPartidaOrigen.Name = "txtEditarPartidaOrigen"
        Me.txtEditarPartidaOrigen.Size = New System.Drawing.Size(249, 22)
        Me.txtEditarPartidaOrigen.TabIndex = 50
        '
        'lblEditarPartidaOrigen
        '
        Me.lblEditarPartidaOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarPartidaOrigen.Location = New System.Drawing.Point(10, 231)
        Me.lblEditarPartidaOrigen.Name = "lblEditarPartidaOrigen"
        Me.lblEditarPartidaOrigen.Size = New System.Drawing.Size(69, 20)
        Me.lblEditarPartidaOrigen.TabIndex = 49
        Me.lblEditarPartidaOrigen.Text = "P. Origen:"
        Me.lblEditarPartidaOrigen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbEditarHilado
        '
        Me.cmbEditarHilado.FormattingEnabled = True
        Me.cmbEditarHilado.Location = New System.Drawing.Point(99, 165)
        Me.cmbEditarHilado.Name = "cmbEditarHilado"
        Me.cmbEditarHilado.Size = New System.Drawing.Size(249, 21)
        Me.cmbEditarHilado.TabIndex = 48
        '
        'lblEditarHilado
        '
        Me.lblEditarHilado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarHilado.Location = New System.Drawing.Point(10, 165)
        Me.lblEditarHilado.Name = "lblEditarHilado"
        Me.lblEditarHilado.Size = New System.Drawing.Size(69, 20)
        Me.lblEditarHilado.TabIndex = 47
        Me.lblEditarHilado.Text = "Hilado:"
        Me.lblEditarHilado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEditarColorCono
        '
        Me.txtEditarColorCono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditarColorCono.Location = New System.Drawing.Point(99, 197)
        Me.txtEditarColorCono.Name = "txtEditarColorCono"
        Me.txtEditarColorCono.Size = New System.Drawing.Size(249, 22)
        Me.txtEditarColorCono.TabIndex = 46
        '
        'lblEditarColorCono
        '
        Me.lblEditarColorCono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarColorCono.Location = New System.Drawing.Point(10, 197)
        Me.lblEditarColorCono.Name = "lblEditarColorCono"
        Me.lblEditarColorCono.Size = New System.Drawing.Size(82, 20)
        Me.lblEditarColorCono.TabIndex = 45
        Me.lblEditarColorCono.Text = "Color Cono:"
        Me.lblEditarColorCono.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEditarColor
        '
        Me.txtEditarColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditarColor.Location = New System.Drawing.Point(99, 131)
        Me.txtEditarColor.Name = "txtEditarColor"
        Me.txtEditarColor.Size = New System.Drawing.Size(246, 22)
        Me.txtEditarColor.TabIndex = 38
        '
        'lblEditarColor
        '
        Me.lblEditarColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarColor.Location = New System.Drawing.Point(10, 131)
        Me.lblEditarColor.Name = "lblEditarColor"
        Me.lblEditarColor.Size = New System.Drawing.Size(74, 20)
        Me.lblEditarColor.TabIndex = 37
        Me.lblEditarColor.Text = "Color:"
        Me.lblEditarColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancelarEditarPartida
        '
        Me.btnCancelarEditarPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarEditarPartida.Location = New System.Drawing.Point(206, 495)
        Me.btnCancelarEditarPartida.Name = "btnCancelarEditarPartida"
        Me.btnCancelarEditarPartida.Size = New System.Drawing.Size(100, 29)
        Me.btnCancelarEditarPartida.TabIndex = 32
        Me.btnCancelarEditarPartida.Text = "Cancelar"
        Me.btnCancelarEditarPartida.UseVisualStyleBackColor = True
        '
        'btnOkEditarPartida
        '
        Me.btnOkEditarPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOkEditarPartida.Location = New System.Drawing.Point(59, 495)
        Me.btnOkEditarPartida.Name = "btnOkEditarPartida"
        Me.btnOkEditarPartida.Size = New System.Drawing.Size(100, 29)
        Me.btnOkEditarPartida.TabIndex = 31
        Me.btnOkEditarPartida.Text = "Ok"
        Me.btnOkEditarPartida.UseVisualStyleBackColor = True
        '
        'lblEditarPartida
        '
        Me.lblEditarPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarPartida.Location = New System.Drawing.Point(10, 99)
        Me.lblEditarPartida.Name = "lblEditarPartida"
        Me.lblEditarPartida.Size = New System.Drawing.Size(69, 20)
        Me.lblEditarPartida.TabIndex = 30
        Me.lblEditarPartida.Text = "Partida:"
        Me.lblEditarPartida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEditarPartida
        '
        Me.txtEditarPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditarPartida.Location = New System.Drawing.Point(99, 99)
        Me.txtEditarPartida.Name = "txtEditarPartida"
        Me.txtEditarPartida.Size = New System.Drawing.Size(246, 22)
        Me.txtEditarPartida.TabIndex = 29
        '
        'chkEsDiscontinuada
        '
        Me.chkEsDiscontinuada.AutoSize = True
        Me.chkEsDiscontinuada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEsDiscontinuada.Location = New System.Drawing.Point(13, 33)
        Me.chkEsDiscontinuada.Name = "chkEsDiscontinuada"
        Me.chkEsDiscontinuada.Size = New System.Drawing.Size(132, 20)
        Me.chkEsDiscontinuada.TabIndex = 61
        Me.chkEsDiscontinuada.Text = "Es Discontinuada"
        Me.chkEsDiscontinuada.UseVisualStyleBackColor = True
        '
        'gbAgregarPartida
        '
        Me.gbAgregarPartida.Controls.Add(Me.detFechaAltaPartida)
        Me.gbAgregarPartida.Controls.Add(Me.Label1)
        Me.gbAgregarPartida.Controls.Add(Me.txtAgregarObservacion)
        Me.gbAgregarPartida.Controls.Add(Me.lblAgregarObservacion)
        Me.gbAgregarPartida.Controls.Add(Me.txtAgregarKilos)
        Me.gbAgregarPartida.Controls.Add(Me.lblAgregarKilos)
        Me.gbAgregarPartida.Controls.Add(Me.txtAgregarPartidaOrigen)
        Me.gbAgregarPartida.Controls.Add(Me.lblAgregarPartidaOrigen)
        Me.gbAgregarPartida.Controls.Add(Me.cmbAgregarHilado)
        Me.gbAgregarPartida.Controls.Add(Me.lblAgregarHilado)
        Me.gbAgregarPartida.Controls.Add(Me.txtAgregarColorCono)
        Me.gbAgregarPartida.Controls.Add(Me.lblAgregarColorCono)
        Me.gbAgregarPartida.Controls.Add(Me.txtAgregarColor)
        Me.gbAgregarPartida.Controls.Add(Me.lblAgregarColor)
        Me.gbAgregarPartida.Controls.Add(Me.btnCancelarAgregarPartida)
        Me.gbAgregarPartida.Controls.Add(Me.btnOkAgregarPartida)
        Me.gbAgregarPartida.Controls.Add(Me.lblAgregarPartida)
        Me.gbAgregarPartida.Controls.Add(Me.txtAgregarPartida)
        Me.gbAgregarPartida.Location = New System.Drawing.Point(629, 12)
        Me.gbAgregarPartida.Name = "gbAgregarPartida"
        Me.gbAgregarPartida.Size = New System.Drawing.Size(352, 419)
        Me.gbAgregarPartida.TabIndex = 47
        Me.gbAgregarPartida.TabStop = False
        Me.gbAgregarPartida.Text = "AGREGAR UNA NUEVA PARTIDA"
        '
        'detFechaAltaPartida
        '
        Me.detFechaAltaPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.detFechaAltaPartida.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.detFechaAltaPartida.Location = New System.Drawing.Point(187, 29)
        Me.detFechaAltaPartida.Name = "detFechaAltaPartida"
        Me.detFechaAltaPartida.Size = New System.Drawing.Size(86, 22)
        Me.detFechaAltaPartida.TabIndex = 48
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(175, 20)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Fecha de Alta de la Partida:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAgregarObservacion
        '
        Me.txtAgregarObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAgregarObservacion.Location = New System.Drawing.Point(90, 294)
        Me.txtAgregarObservacion.MaxLength = 99
        Me.txtAgregarObservacion.Name = "txtAgregarObservacion"
        Me.txtAgregarObservacion.Size = New System.Drawing.Size(247, 22)
        Me.txtAgregarObservacion.TabIndex = 46
        '
        'lblAgregarObservacion
        '
        Me.lblAgregarObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgregarObservacion.Location = New System.Drawing.Point(6, 294)
        Me.lblAgregarObservacion.Name = "lblAgregarObservacion"
        Me.lblAgregarObservacion.Size = New System.Drawing.Size(102, 20)
        Me.lblAgregarObservacion.TabIndex = 45
        Me.lblAgregarObservacion.Text = "Observación:"
        Me.lblAgregarObservacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAgregarKilos
        '
        Me.txtAgregarKilos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAgregarKilos.Location = New System.Drawing.Point(90, 254)
        Me.txtAgregarKilos.Name = "txtAgregarKilos"
        Me.txtAgregarKilos.Size = New System.Drawing.Size(247, 22)
        Me.txtAgregarKilos.TabIndex = 44
        '
        'lblAgregarKilos
        '
        Me.lblAgregarKilos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgregarKilos.Location = New System.Drawing.Point(6, 254)
        Me.lblAgregarKilos.Name = "lblAgregarKilos"
        Me.lblAgregarKilos.Size = New System.Drawing.Size(102, 20)
        Me.lblAgregarKilos.TabIndex = 43
        Me.lblAgregarKilos.Text = "Kilos Inicial:"
        Me.lblAgregarKilos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAgregarPartidaOrigen
        '
        Me.txtAgregarPartidaOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAgregarPartidaOrigen.Location = New System.Drawing.Point(90, 215)
        Me.txtAgregarPartidaOrigen.Name = "txtAgregarPartidaOrigen"
        Me.txtAgregarPartidaOrigen.Size = New System.Drawing.Size(247, 22)
        Me.txtAgregarPartidaOrigen.TabIndex = 42
        '
        'lblAgregarPartidaOrigen
        '
        Me.lblAgregarPartidaOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgregarPartidaOrigen.Location = New System.Drawing.Point(6, 215)
        Me.lblAgregarPartidaOrigen.Name = "lblAgregarPartidaOrigen"
        Me.lblAgregarPartidaOrigen.Size = New System.Drawing.Size(69, 20)
        Me.lblAgregarPartidaOrigen.TabIndex = 41
        Me.lblAgregarPartidaOrigen.Text = "P. Origen:"
        Me.lblAgregarPartidaOrigen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbAgregarHilado
        '
        Me.cmbAgregarHilado.FormattingEnabled = True
        Me.cmbAgregarHilado.Location = New System.Drawing.Point(90, 141)
        Me.cmbAgregarHilado.Name = "cmbAgregarHilado"
        Me.cmbAgregarHilado.Size = New System.Drawing.Size(247, 21)
        Me.cmbAgregarHilado.TabIndex = 40
        '
        'lblAgregarHilado
        '
        Me.lblAgregarHilado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgregarHilado.Location = New System.Drawing.Point(6, 140)
        Me.lblAgregarHilado.Name = "lblAgregarHilado"
        Me.lblAgregarHilado.Size = New System.Drawing.Size(69, 20)
        Me.lblAgregarHilado.TabIndex = 39
        Me.lblAgregarHilado.Text = "Hilado:"
        Me.lblAgregarHilado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAgregarColorCono
        '
        Me.txtAgregarColorCono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAgregarColorCono.Location = New System.Drawing.Point(90, 178)
        Me.txtAgregarColorCono.Name = "txtAgregarColorCono"
        Me.txtAgregarColorCono.Size = New System.Drawing.Size(247, 22)
        Me.txtAgregarColorCono.TabIndex = 38
        '
        'lblAgregarColorCono
        '
        Me.lblAgregarColorCono.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgregarColorCono.Location = New System.Drawing.Point(6, 178)
        Me.lblAgregarColorCono.Name = "lblAgregarColorCono"
        Me.lblAgregarColorCono.Size = New System.Drawing.Size(85, 20)
        Me.lblAgregarColorCono.TabIndex = 37
        Me.lblAgregarColorCono.Text = "Color Cono:"
        Me.lblAgregarColorCono.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAgregarColor
        '
        Me.txtAgregarColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAgregarColor.Location = New System.Drawing.Point(90, 103)
        Me.txtAgregarColor.Name = "txtAgregarColor"
        Me.txtAgregarColor.Size = New System.Drawing.Size(247, 22)
        Me.txtAgregarColor.TabIndex = 36
        '
        'lblAgregarColor
        '
        Me.lblAgregarColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgregarColor.Location = New System.Drawing.Point(6, 103)
        Me.lblAgregarColor.Name = "lblAgregarColor"
        Me.lblAgregarColor.Size = New System.Drawing.Size(51, 20)
        Me.lblAgregarColor.TabIndex = 35
        Me.lblAgregarColor.Text = "Color:"
        Me.lblAgregarColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancelarAgregarPartida
        '
        Me.btnCancelarAgregarPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarAgregarPartida.Location = New System.Drawing.Point(200, 370)
        Me.btnCancelarAgregarPartida.Name = "btnCancelarAgregarPartida"
        Me.btnCancelarAgregarPartida.Size = New System.Drawing.Size(100, 29)
        Me.btnCancelarAgregarPartida.TabIndex = 32
        Me.btnCancelarAgregarPartida.Text = "Cancelar"
        Me.btnCancelarAgregarPartida.UseVisualStyleBackColor = True
        '
        'btnOkAgregarPartida
        '
        Me.btnOkAgregarPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOkAgregarPartida.Location = New System.Drawing.Point(60, 370)
        Me.btnOkAgregarPartida.Name = "btnOkAgregarPartida"
        Me.btnOkAgregarPartida.Size = New System.Drawing.Size(100, 29)
        Me.btnOkAgregarPartida.TabIndex = 31
        Me.btnOkAgregarPartida.Text = "Ok"
        Me.btnOkAgregarPartida.UseVisualStyleBackColor = True
        '
        'lblAgregarPartida
        '
        Me.lblAgregarPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgregarPartida.Location = New System.Drawing.Point(6, 66)
        Me.lblAgregarPartida.Name = "lblAgregarPartida"
        Me.lblAgregarPartida.Size = New System.Drawing.Size(57, 20)
        Me.lblAgregarPartida.TabIndex = 30
        Me.lblAgregarPartida.Text = "Partida:"
        Me.lblAgregarPartida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAgregarPartida
        '
        Me.txtAgregarPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAgregarPartida.Location = New System.Drawing.Point(90, 66)
        Me.txtAgregarPartida.Name = "txtAgregarPartida"
        Me.txtAgregarPartida.Size = New System.Drawing.Size(247, 22)
        Me.txtAgregarPartida.TabIndex = 29
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Location = New System.Drawing.Point(502, 209)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(107, 32)
        Me.btnEliminar.TabIndex = 44
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Location = New System.Drawing.Point(502, 153)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(107, 32)
        Me.btnEditar.TabIndex = 43
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Location = New System.Drawing.Point(502, 101)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(107, 32)
        Me.btnAgregar.TabIndex = 42
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'dgvPartidas
        '
        Me.dgvPartidas.AllowUserToAddRows = False
        Me.dgvPartidas.AllowUserToDeleteRows = False
        Me.dgvPartidas.AllowUserToResizeColumns = False
        Me.dgvPartidas.AllowUserToResizeRows = False
        Me.dgvPartidas.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvPartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPartidas.Location = New System.Drawing.Point(6, 83)
        Me.dgvPartidas.Name = "dgvPartidas"
        Me.dgvPartidas.ReadOnly = True
        Me.dgvPartidas.RowHeadersWidth = 39
        Me.dgvPartidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPartidas.Size = New System.Drawing.Size(478, 469)
        Me.dgvPartidas.TabIndex = 41
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(502, 492)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(107, 32)
        Me.btnCerrar.TabIndex = 40
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'gbFiltroStock
        '
        Me.gbFiltroStock.Controls.Add(Me.rbFiltroStockConStock)
        Me.gbFiltroStock.Controls.Add(Me.rbFiltroStockSinStock)
        Me.gbFiltroStock.Controls.Add(Me.rbFiltroStockTodas)
        Me.gbFiltroStock.Location = New System.Drawing.Point(53, 37)
        Me.gbFiltroStock.Name = "gbFiltroStock"
        Me.gbFiltroStock.Size = New System.Drawing.Size(291, 37)
        Me.gbFiltroStock.TabIndex = 52
        Me.gbFiltroStock.TabStop = False
        '
        'rbFiltroStockConStock
        '
        Me.rbFiltroStockConStock.AutoSize = True
        Me.rbFiltroStockConStock.Checked = True
        Me.rbFiltroStockConStock.Location = New System.Drawing.Point(190, 13)
        Me.rbFiltroStockConStock.Name = "rbFiltroStockConStock"
        Me.rbFiltroStockConStock.Size = New System.Drawing.Size(75, 17)
        Me.rbFiltroStockConStock.TabIndex = 2
        Me.rbFiltroStockConStock.TabStop = True
        Me.rbFiltroStockConStock.Text = "Con Stock"
        Me.rbFiltroStockConStock.UseVisualStyleBackColor = True
        '
        'rbFiltroStockSinStock
        '
        Me.rbFiltroStockSinStock.AutoSize = True
        Me.rbFiltroStockSinStock.Location = New System.Drawing.Point(97, 13)
        Me.rbFiltroStockSinStock.Name = "rbFiltroStockSinStock"
        Me.rbFiltroStockSinStock.Size = New System.Drawing.Size(71, 17)
        Me.rbFiltroStockSinStock.TabIndex = 1
        Me.rbFiltroStockSinStock.Text = "Sin Stock"
        Me.rbFiltroStockSinStock.UseVisualStyleBackColor = True
        '
        'rbFiltroStockTodas
        '
        Me.rbFiltroStockTodas.AutoSize = True
        Me.rbFiltroStockTodas.Location = New System.Drawing.Point(15, 13)
        Me.rbFiltroStockTodas.Name = "rbFiltroStockTodas"
        Me.rbFiltroStockTodas.Size = New System.Drawing.Size(55, 17)
        Me.rbFiltroStockTodas.TabIndex = 0
        Me.rbFiltroStockTodas.Text = "Todos"
        Me.rbFiltroStockTodas.UseVisualStyleBackColor = True
        '
        'btnListar
        '
        Me.btnListar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnListar.Location = New System.Drawing.Point(390, 24)
        Me.btnListar.Name = "btnListar"
        Me.btnListar.Size = New System.Drawing.Size(94, 32)
        Me.btnListar.TabIndex = 53
        Me.btnListar.Text = "Listar"
        Me.btnListar.UseVisualStyleBackColor = True
        '
        'txtFiltroPartida
        '
        Me.txtFiltroPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFiltroPartida.Location = New System.Drawing.Point(259, 9)
        Me.txtFiltroPartida.Name = "txtFiltroPartida"
        Me.txtFiltroPartida.Size = New System.Drawing.Size(110, 22)
        Me.txtFiltroPartida.TabIndex = 45
        '
        'lblFiltroPartida
        '
        Me.lblFiltroPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFiltroPartida.Location = New System.Drawing.Point(198, 11)
        Me.lblFiltroPartida.Name = "lblFiltroPartida"
        Me.lblFiltroPartida.Size = New System.Drawing.Size(55, 20)
        Me.lblFiltroPartida.TabIndex = 46
        Me.lblFiltroPartida.Text = "Partida:"
        Me.lblFiltroPartida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFiltroHilado
        '
        Me.lblFiltroHilado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFiltroHilado.Location = New System.Drawing.Point(19, 11)
        Me.lblFiltroHilado.Name = "lblFiltroHilado"
        Me.lblFiltroHilado.Size = New System.Drawing.Size(55, 20)
        Me.lblFiltroHilado.TabIndex = 55
        Me.lblFiltroHilado.Text = "Hilado:"
        Me.lblFiltroHilado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFiltroHilado
        '
        Me.txtFiltroHilado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFiltroHilado.Location = New System.Drawing.Point(80, 9)
        Me.txtFiltroHilado.Name = "txtFiltroHilado"
        Me.txtFiltroHilado.Size = New System.Drawing.Size(110, 22)
        Me.txtFiltroHilado.TabIndex = 54
        '
        'frmHilaABMPartidas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1353, 564)
        Me.Controls.Add(Me.lblFiltroHilado)
        Me.Controls.Add(Me.txtFiltroHilado)
        Me.Controls.Add(Me.btnListar)
        Me.Controls.Add(Me.gbFiltroStock)
        Me.Controls.Add(Me.gbModificarPartida)
        Me.Controls.Add(Me.gbAgregarPartida)
        Me.Controls.Add(Me.lblFiltroPartida)
        Me.Controls.Add(Me.txtFiltroPartida)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.dgvPartidas)
        Me.Controls.Add(Me.btnCerrar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmHilaABMPartidas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM Partidas"
        Me.gbModificarPartida.ResumeLayout(False)
        Me.gbModificarPartida.PerformLayout()
        Me.gbAgregarPartida.ResumeLayout(False)
        Me.gbAgregarPartida.PerformLayout()
        CType(Me.dgvPartidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFiltroStock.ResumeLayout(False)
        Me.gbFiltroStock.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbModificarPartida As System.Windows.Forms.GroupBox
    Friend WithEvents txtEditarColor As System.Windows.Forms.TextBox
    Friend WithEvents lblEditarColor As System.Windows.Forms.Label
    Friend WithEvents btnCancelarEditarPartida As System.Windows.Forms.Button
    Friend WithEvents btnOkEditarPartida As System.Windows.Forms.Button
    Friend WithEvents lblEditarPartida As System.Windows.Forms.Label
    Friend WithEvents txtEditarPartida As System.Windows.Forms.TextBox
    Friend WithEvents gbAgregarPartida As System.Windows.Forms.GroupBox
    Friend WithEvents txtAgregarColor As System.Windows.Forms.TextBox
    Friend WithEvents lblAgregarColor As System.Windows.Forms.Label
    Friend WithEvents btnCancelarAgregarPartida As System.Windows.Forms.Button
    Friend WithEvents btnOkAgregarPartida As System.Windows.Forms.Button
    Friend WithEvents lblAgregarPartida As System.Windows.Forms.Label
    Friend WithEvents txtAgregarPartida As System.Windows.Forms.TextBox
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents dgvPartidas As System.Windows.Forms.DataGridView
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblAgregarHilado As System.Windows.Forms.Label
    Friend WithEvents txtAgregarColorCono As System.Windows.Forms.TextBox
    Friend WithEvents lblAgregarColorCono As System.Windows.Forms.Label
    Friend WithEvents cmbAgregarHilado As System.Windows.Forms.ComboBox
    Friend WithEvents txtAgregarPartidaOrigen As System.Windows.Forms.TextBox
    Friend WithEvents lblAgregarPartidaOrigen As System.Windows.Forms.Label
    Friend WithEvents txtAgregarKilos As System.Windows.Forms.TextBox
    Friend WithEvents lblAgregarKilos As System.Windows.Forms.Label
    Friend WithEvents txtEditarKilos As System.Windows.Forms.TextBox
    Friend WithEvents lblEditarKilos As System.Windows.Forms.Label
    Friend WithEvents txtEditarPartidaOrigen As System.Windows.Forms.TextBox
    Friend WithEvents lblEditarPartidaOrigen As System.Windows.Forms.Label
    Friend WithEvents cmbEditarHilado As System.Windows.Forms.ComboBox
    Friend WithEvents lblEditarHilado As System.Windows.Forms.Label
    Friend WithEvents txtEditarColorCono As System.Windows.Forms.TextBox
    Friend WithEvents lblEditarColorCono As System.Windows.Forms.Label
    Friend WithEvents gbFiltroStock As System.Windows.Forms.GroupBox
    Friend WithEvents rbFiltroStockConStock As System.Windows.Forms.RadioButton
    Friend WithEvents rbFiltroStockSinStock As System.Windows.Forms.RadioButton
    Friend WithEvents rbFiltroStockTodas As System.Windows.Forms.RadioButton
    Friend WithEvents txtEditarStockActual As System.Windows.Forms.TextBox
    Friend WithEvents lblEditarStockActual As System.Windows.Forms.Label
    Friend WithEvents txtEditarKilosFechaInicial As System.Windows.Forms.TextBox
    Friend WithEvents lblEditarKilosFechaInicial As System.Windows.Forms.Label
    Friend WithEvents txtEditarKilosFechaFinal As System.Windows.Forms.TextBox
    Friend WithEvents lblEditarKilosFechaFinal As System.Windows.Forms.Label
    Friend WithEvents btnListar As System.Windows.Forms.Button
    Friend WithEvents txtFiltroPartida As System.Windows.Forms.TextBox
    Friend WithEvents lblFiltroPartida As System.Windows.Forms.Label
    Friend WithEvents lblFiltroHilado As System.Windows.Forms.Label
    Friend WithEvents txtFiltroHilado As System.Windows.Forms.TextBox
    Friend WithEvents txtEditarNuevoStockActual As System.Windows.Forms.TextBox
    Friend WithEvents lblEditarNuevoStock As System.Windows.Forms.Label
    Friend WithEvents chkEsDiscontinuada As System.Windows.Forms.CheckBox
    Friend WithEvents txtAgregarObservacion As System.Windows.Forms.TextBox
    Friend WithEvents lblAgregarObservacion As System.Windows.Forms.Label
    Friend WithEvents txtEditarPartidaObservacion As System.Windows.Forms.TextBox
    Friend WithEvents lblEditarPartidaObservacion As System.Windows.Forms.Label
    Friend WithEvents detFechaAltaPartida As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpModFechaAlta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblNoTieneFecha As System.Windows.Forms.Label
End Class
