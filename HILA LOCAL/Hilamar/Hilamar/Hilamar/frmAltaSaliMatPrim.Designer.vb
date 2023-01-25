<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAltaSaliMatPrim
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAltaSaliMatPrim))
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.lblDescCodigo = New System.Windows.Forms.Label()
        Me.cmbCodigos = New System.Windows.Forms.ComboBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.cmbTipos = New System.Windows.Forms.ComboBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.gbSalidaMat = New System.Windows.Forms.GroupBox()
        Me.lblEgMatCajas = New System.Windows.Forms.Label()
        Me.lblEgMatOrdFab = New System.Windows.Forms.Label()
        Me.lblEgMatFardos = New System.Windows.Forms.Label()
        Me.txtEgMatCajas = New System.Windows.Forms.TextBox()
        Me.txtEgMatOrdFabricacion = New System.Windows.Forms.TextBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.lblEgMatFecha = New System.Windows.Forms.Label()
        Me.txtEgMatFardos = New System.Windows.Forms.TextBox()
        Me.txtEgMatConos = New System.Windows.Forms.TextBox()
        Me.txtEgMatKilos = New System.Windows.Forms.TextBox()
        Me.lblEgMatConos = New System.Windows.Forms.Label()
        Me.lblEgMatKilos = New System.Windows.Forms.Label()
        Me.btnMatCancelar = New System.Windows.Forms.Button()
        Me.cmdEgMatGuardar = New System.Windows.Forms.Button()
        Me.gbSalidaProceso1 = New System.Windows.Forms.GroupBox()
        Me.lblEg1KilosEgresados = New System.Windows.Forms.Label()
        Me.txtEg1KilosEgresados = New System.Windows.Forms.TextBox()
        Me.lblEg1OrdFab = New System.Windows.Forms.Label()
        Me.txtEg1OrdFab = New System.Windows.Forms.TextBox()
        Me.lblEg1TopEgresados = New System.Windows.Forms.Label()
        Me.txtEg1TopEgresados = New System.Windows.Forms.TextBox()
        Me.txtEg1NroOrden = New System.Windows.Forms.TextBox()
        Me.lblEg1NroOrden = New System.Windows.Forms.Label()
        Me.btnSal1Cancelar = New System.Windows.Forms.Button()
        Me.cmdEg1Guardar = New System.Windows.Forms.Button()
        Me.gbSalidaProceso2 = New System.Windows.Forms.GroupBox()
        Me.lblEg2OrdFab = New System.Windows.Forms.Label()
        Me.txtEg2OrdFabricacion = New System.Windows.Forms.TextBox()
        Me.lblEg2CantKilos = New System.Windows.Forms.Label()
        Me.lblEg2CantEgresada = New System.Windows.Forms.Label()
        Me.txtEg2CantKilos = New System.Windows.Forms.TextBox()
        Me.txtEg2CantEgresada = New System.Windows.Forms.TextBox()
        Me.txtEg2OrdTeñido = New System.Windows.Forms.TextBox()
        Me.lblEg2OrdenTeñido = New System.Windows.Forms.Label()
        Me.btnSal2Cancelar = New System.Windows.Forms.Button()
        Me.cmdEg2Guardar = New System.Windows.Forms.Button()
        Me.gbDatos.SuspendLayout()
        Me.gbSalidaMat.SuspendLayout()
        Me.gbSalidaProceso1.SuspendLayout()
        Me.gbSalidaProceso2.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.lblTitulo)
        Me.gbDatos.Controls.Add(Me.btnCerrar)
        Me.gbDatos.Controls.Add(Me.btnProcesar)
        Me.gbDatos.Controls.Add(Me.lblDescCodigo)
        Me.gbDatos.Controls.Add(Me.cmbCodigos)
        Me.gbDatos.Controls.Add(Me.lblCodigo)
        Me.gbDatos.Controls.Add(Me.cmbTipos)
        Me.gbDatos.Controls.Add(Me.lblTipo)
        Me.gbDatos.Location = New System.Drawing.Point(14, 14)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(595, 118)
        Me.gbDatos.TabIndex = 1
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Datos"
        '
        'lblTitulo
        '
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(7, 18)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(581, 27)
        Me.lblTitulo.TabIndex = 8
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(500, 82)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(87, 27)
        Me.btnCerrar.TabIndex = 7
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(500, 48)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(87, 27)
        Me.btnProcesar.TabIndex = 6
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'lblDescCodigo
        '
        Me.lblDescCodigo.Location = New System.Drawing.Point(236, 77)
        Me.lblDescCodigo.Name = "lblDescCodigo"
        Me.lblDescCodigo.Size = New System.Drawing.Size(241, 27)
        Me.lblDescCodigo.TabIndex = 4
        Me.lblDescCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCodigos
        '
        Me.cmbCodigos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCodigos.FormattingEnabled = True
        Me.cmbCodigos.Location = New System.Drawing.Point(82, 80)
        Me.cmbCodigos.Name = "cmbCodigos"
        Me.cmbCodigos.Size = New System.Drawing.Size(146, 23)
        Me.cmbCodigos.TabIndex = 3
        '
        'lblCodigo
        '
        Me.lblCodigo.Location = New System.Drawing.Point(7, 77)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(68, 27)
        Me.lblCodigo.TabIndex = 2
        Me.lblCodigo.Text = "Código:"
        Me.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbTipos
        '
        Me.cmbTipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipos.FormattingEnabled = True
        Me.cmbTipos.Location = New System.Drawing.Point(82, 48)
        Me.cmbTipos.Name = "cmbTipos"
        Me.cmbTipos.Size = New System.Drawing.Size(146, 23)
        Me.cmbTipos.TabIndex = 1
        '
        'lblTipo
        '
        Me.lblTipo.Location = New System.Drawing.Point(23, 46)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(51, 27)
        Me.lblTipo.TabIndex = 0
        Me.lblTipo.Text = "Tipo:"
        Me.lblTipo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbSalidaMat
        '
        Me.gbSalidaMat.AutoSize = True
        Me.gbSalidaMat.Controls.Add(Me.lblEgMatCajas)
        Me.gbSalidaMat.Controls.Add(Me.lblEgMatOrdFab)
        Me.gbSalidaMat.Controls.Add(Me.lblEgMatFardos)
        Me.gbSalidaMat.Controls.Add(Me.txtEgMatCajas)
        Me.gbSalidaMat.Controls.Add(Me.txtEgMatOrdFabricacion)
        Me.gbSalidaMat.Controls.Add(Me.DateTimePicker1)
        Me.gbSalidaMat.Controls.Add(Me.lblEgMatFecha)
        Me.gbSalidaMat.Controls.Add(Me.txtEgMatFardos)
        Me.gbSalidaMat.Controls.Add(Me.txtEgMatConos)
        Me.gbSalidaMat.Controls.Add(Me.txtEgMatKilos)
        Me.gbSalidaMat.Controls.Add(Me.lblEgMatConos)
        Me.gbSalidaMat.Controls.Add(Me.lblEgMatKilos)
        Me.gbSalidaMat.Controls.Add(Me.btnMatCancelar)
        Me.gbSalidaMat.Controls.Add(Me.cmdEgMatGuardar)
        Me.gbSalidaMat.Location = New System.Drawing.Point(14, 138)
        Me.gbSalidaMat.Name = "gbSalidaMat"
        Me.gbSalidaMat.Size = New System.Drawing.Size(595, 193)
        Me.gbSalidaMat.TabIndex = 34
        Me.gbSalidaMat.TabStop = False
        Me.gbSalidaMat.Text = "Salida"
        Me.gbSalidaMat.Visible = False
        '
        'lblEgMatCajas
        '
        Me.lblEgMatCajas.AutoSize = True
        Me.lblEgMatCajas.Location = New System.Drawing.Point(131, 117)
        Me.lblEgMatCajas.Name = "lblEgMatCajas"
        Me.lblEgMatCajas.Size = New System.Drawing.Size(41, 15)
        Me.lblEgMatCajas.TabIndex = 22
        Me.lblEgMatCajas.Text = "Cajas:"
        Me.lblEgMatCajas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEgMatOrdFab
        '
        Me.lblEgMatOrdFab.AutoSize = True
        Me.lblEgMatOrdFab.Location = New System.Drawing.Point(300, 63)
        Me.lblEgMatOrdFab.Name = "lblEgMatOrdFab"
        Me.lblEgMatOrdFab.Size = New System.Drawing.Size(111, 15)
        Me.lblEgMatOrdFab.TabIndex = 20
        Me.lblEgMatOrdFab.Text = "Orden Fabricación:"
        Me.lblEgMatOrdFab.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEgMatFardos
        '
        Me.lblEgMatFardos.AutoSize = True
        Me.lblEgMatFardos.Location = New System.Drawing.Point(363, 36)
        Me.lblEgMatFardos.Name = "lblEgMatFardos"
        Me.lblEgMatFardos.Size = New System.Drawing.Size(48, 15)
        Me.lblEgMatFardos.TabIndex = 19
        Me.lblEgMatFardos.Text = "Fardos:"
        Me.lblEgMatFardos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEgMatCajas
        '
        Me.txtEgMatCajas.Location = New System.Drawing.Point(178, 114)
        Me.txtEgMatCajas.Name = "txtEgMatCajas"
        Me.txtEgMatCajas.Size = New System.Drawing.Size(116, 21)
        Me.txtEgMatCajas.TabIndex = 18
        '
        'txtEgMatOrdFabricacion
        '
        Me.txtEgMatOrdFabricacion.Location = New System.Drawing.Point(417, 60)
        Me.txtEgMatOrdFabricacion.Name = "txtEgMatOrdFabricacion"
        Me.txtEgMatOrdFabricacion.Size = New System.Drawing.Size(116, 21)
        Me.txtEgMatOrdFabricacion.TabIndex = 16
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(178, 33)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(116, 21)
        Me.DateTimePicker1.TabIndex = 15
        '
        'lblEgMatFecha
        '
        Me.lblEgMatFecha.AutoSize = True
        Me.lblEgMatFecha.Location = New System.Drawing.Point(128, 36)
        Me.lblEgMatFecha.Name = "lblEgMatFecha"
        Me.lblEgMatFecha.Size = New System.Drawing.Size(44, 15)
        Me.lblEgMatFecha.TabIndex = 14
        Me.lblEgMatFecha.Text = "Fecha:"
        Me.lblEgMatFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEgMatFardos
        '
        Me.txtEgMatFardos.Location = New System.Drawing.Point(417, 33)
        Me.txtEgMatFardos.Name = "txtEgMatFardos"
        Me.txtEgMatFardos.Size = New System.Drawing.Size(116, 21)
        Me.txtEgMatFardos.TabIndex = 13
        '
        'txtEgMatConos
        '
        Me.txtEgMatConos.Location = New System.Drawing.Point(178, 87)
        Me.txtEgMatConos.Name = "txtEgMatConos"
        Me.txtEgMatConos.Size = New System.Drawing.Size(116, 21)
        Me.txtEgMatConos.TabIndex = 12
        '
        'txtEgMatKilos
        '
        Me.txtEgMatKilos.Location = New System.Drawing.Point(178, 60)
        Me.txtEgMatKilos.Name = "txtEgMatKilos"
        Me.txtEgMatKilos.Size = New System.Drawing.Size(116, 21)
        Me.txtEgMatKilos.TabIndex = 11
        '
        'lblEgMatConos
        '
        Me.lblEgMatConos.AutoSize = True
        Me.lblEgMatConos.Location = New System.Drawing.Point(127, 90)
        Me.lblEgMatConos.Name = "lblEgMatConos"
        Me.lblEgMatConos.Size = New System.Drawing.Size(45, 15)
        Me.lblEgMatConos.TabIndex = 10
        Me.lblEgMatConos.Text = "Conos:"
        Me.lblEgMatConos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEgMatKilos
        '
        Me.lblEgMatKilos.AutoSize = True
        Me.lblEgMatKilos.Location = New System.Drawing.Point(73, 63)
        Me.lblEgMatKilos.Name = "lblEgMatKilos"
        Me.lblEgMatKilos.Size = New System.Drawing.Size(99, 15)
        Me.lblEgMatKilos.TabIndex = 9
        Me.lblEgMatKilos.Text = "Kilos Egresados:"
        Me.lblEgMatKilos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnMatCancelar
        '
        Me.btnMatCancelar.Location = New System.Drawing.Point(300, 146)
        Me.btnMatCancelar.Name = "btnMatCancelar"
        Me.btnMatCancelar.Size = New System.Drawing.Size(87, 27)
        Me.btnMatCancelar.TabIndex = 8
        Me.btnMatCancelar.Text = "Cancelar"
        Me.btnMatCancelar.UseVisualStyleBackColor = True
        '
        'cmdEgMatGuardar
        '
        Me.cmdEgMatGuardar.Location = New System.Drawing.Point(207, 146)
        Me.cmdEgMatGuardar.Name = "cmdEgMatGuardar"
        Me.cmdEgMatGuardar.Size = New System.Drawing.Size(87, 27)
        Me.cmdEgMatGuardar.TabIndex = 7
        Me.cmdEgMatGuardar.Text = "Guardar"
        Me.cmdEgMatGuardar.UseVisualStyleBackColor = True
        '
        'gbSalidaProceso1
        '
        Me.gbSalidaProceso1.AutoSize = True
        Me.gbSalidaProceso1.Controls.Add(Me.lblEg1KilosEgresados)
        Me.gbSalidaProceso1.Controls.Add(Me.txtEg1KilosEgresados)
        Me.gbSalidaProceso1.Controls.Add(Me.lblEg1OrdFab)
        Me.gbSalidaProceso1.Controls.Add(Me.txtEg1OrdFab)
        Me.gbSalidaProceso1.Controls.Add(Me.lblEg1TopEgresados)
        Me.gbSalidaProceso1.Controls.Add(Me.txtEg1TopEgresados)
        Me.gbSalidaProceso1.Controls.Add(Me.txtEg1NroOrden)
        Me.gbSalidaProceso1.Controls.Add(Me.lblEg1NroOrden)
        Me.gbSalidaProceso1.Controls.Add(Me.btnSal1Cancelar)
        Me.gbSalidaProceso1.Controls.Add(Me.cmdEg1Guardar)
        Me.gbSalidaProceso1.Location = New System.Drawing.Point(616, 14)
        Me.gbSalidaProceso1.Name = "gbSalidaProceso1"
        Me.gbSalidaProceso1.Size = New System.Drawing.Size(595, 139)
        Me.gbSalidaProceso1.TabIndex = 33
        Me.gbSalidaProceso1.TabStop = False
        Me.gbSalidaProceso1.Text = "Salida"
        Me.gbSalidaProceso1.Visible = False
        '
        'lblEg1KilosEgresados
        '
        Me.lblEg1KilosEgresados.AutoSize = True
        Me.lblEg1KilosEgresados.Location = New System.Drawing.Point(374, 63)
        Me.lblEg1KilosEgresados.Name = "lblEg1KilosEgresados"
        Me.lblEg1KilosEgresados.Size = New System.Drawing.Size(37, 15)
        Me.lblEg1KilosEgresados.TabIndex = 28
        Me.lblEg1KilosEgresados.Text = "Kilos:"
        Me.lblEg1KilosEgresados.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEg1KilosEgresados
        '
        Me.txtEg1KilosEgresados.Location = New System.Drawing.Point(417, 60)
        Me.txtEg1KilosEgresados.Name = "txtEg1KilosEgresados"
        Me.txtEg1KilosEgresados.Size = New System.Drawing.Size(116, 21)
        Me.txtEg1KilosEgresados.TabIndex = 27
        '
        'lblEg1OrdFab
        '
        Me.lblEg1OrdFab.AutoSize = True
        Me.lblEg1OrdFab.Location = New System.Drawing.Point(300, 36)
        Me.lblEg1OrdFab.Name = "lblEg1OrdFab"
        Me.lblEg1OrdFab.Size = New System.Drawing.Size(111, 15)
        Me.lblEg1OrdFab.TabIndex = 26
        Me.lblEg1OrdFab.Text = "Orden Fabricación:"
        Me.lblEg1OrdFab.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEg1OrdFab
        '
        Me.txtEg1OrdFab.Location = New System.Drawing.Point(417, 33)
        Me.txtEg1OrdFab.Name = "txtEg1OrdFab"
        Me.txtEg1OrdFab.Size = New System.Drawing.Size(116, 21)
        Me.txtEg1OrdFab.TabIndex = 25
        '
        'lblEg1TopEgresados
        '
        Me.lblEg1TopEgresados.AutoSize = True
        Me.lblEg1TopEgresados.Location = New System.Drawing.Point(70, 63)
        Me.lblEg1TopEgresados.Name = "lblEg1TopEgresados"
        Me.lblEg1TopEgresados.Size = New System.Drawing.Size(102, 15)
        Me.lblEg1TopEgresados.TabIndex = 24
        Me.lblEg1TopEgresados.Text = "TOPs Egresados:"
        Me.lblEg1TopEgresados.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEg1TopEgresados
        '
        Me.txtEg1TopEgresados.Location = New System.Drawing.Point(178, 60)
        Me.txtEg1TopEgresados.Name = "txtEg1TopEgresados"
        Me.txtEg1TopEgresados.Size = New System.Drawing.Size(116, 21)
        Me.txtEg1TopEgresados.TabIndex = 23
        '
        'txtEg1NroOrden
        '
        Me.txtEg1NroOrden.Location = New System.Drawing.Point(178, 33)
        Me.txtEg1NroOrden.Name = "txtEg1NroOrden"
        Me.txtEg1NroOrden.Size = New System.Drawing.Size(116, 21)
        Me.txtEg1NroOrden.TabIndex = 11
        '
        'lblEg1NroOrden
        '
        Me.lblEg1NroOrden.AutoSize = True
        Me.lblEg1NroOrden.Location = New System.Drawing.Point(63, 36)
        Me.lblEg1NroOrden.Name = "lblEg1NroOrden"
        Me.lblEg1NroOrden.Size = New System.Drawing.Size(109, 15)
        Me.lblEg1NroOrden.TabIndex = 9
        Me.lblEg1NroOrden.Text = "Número de Orden:"
        Me.lblEg1NroOrden.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSal1Cancelar
        '
        Me.btnSal1Cancelar.Location = New System.Drawing.Point(300, 92)
        Me.btnSal1Cancelar.Name = "btnSal1Cancelar"
        Me.btnSal1Cancelar.Size = New System.Drawing.Size(87, 27)
        Me.btnSal1Cancelar.TabIndex = 8
        Me.btnSal1Cancelar.Text = "Cancelar"
        Me.btnSal1Cancelar.UseVisualStyleBackColor = True
        '
        'cmdEg1Guardar
        '
        Me.cmdEg1Guardar.Location = New System.Drawing.Point(207, 92)
        Me.cmdEg1Guardar.Name = "cmdEg1Guardar"
        Me.cmdEg1Guardar.Size = New System.Drawing.Size(87, 27)
        Me.cmdEg1Guardar.TabIndex = 7
        Me.cmdEg1Guardar.Text = "Guardar"
        Me.cmdEg1Guardar.UseVisualStyleBackColor = True
        '
        'gbSalidaProceso2
        '
        Me.gbSalidaProceso2.Controls.Add(Me.lblEg2OrdFab)
        Me.gbSalidaProceso2.Controls.Add(Me.txtEg2OrdFabricacion)
        Me.gbSalidaProceso2.Controls.Add(Me.lblEg2CantKilos)
        Me.gbSalidaProceso2.Controls.Add(Me.lblEg2CantEgresada)
        Me.gbSalidaProceso2.Controls.Add(Me.txtEg2CantKilos)
        Me.gbSalidaProceso2.Controls.Add(Me.txtEg2CantEgresada)
        Me.gbSalidaProceso2.Controls.Add(Me.txtEg2OrdTeñido)
        Me.gbSalidaProceso2.Controls.Add(Me.lblEg2OrdenTeñido)
        Me.gbSalidaProceso2.Controls.Add(Me.btnSal2Cancelar)
        Me.gbSalidaProceso2.Controls.Add(Me.cmdEg2Guardar)
        Me.gbSalidaProceso2.Location = New System.Drawing.Point(616, 159)
        Me.gbSalidaProceso2.Name = "gbSalidaProceso2"
        Me.gbSalidaProceso2.Size = New System.Drawing.Size(595, 139)
        Me.gbSalidaProceso2.TabIndex = 32
        Me.gbSalidaProceso2.TabStop = False
        Me.gbSalidaProceso2.Text = "Salida"
        Me.gbSalidaProceso2.Visible = False
        '
        'lblEg2OrdFab
        '
        Me.lblEg2OrdFab.AutoSize = True
        Me.lblEg2OrdFab.Location = New System.Drawing.Point(300, 63)
        Me.lblEg2OrdFab.Name = "lblEg2OrdFab"
        Me.lblEg2OrdFab.Size = New System.Drawing.Size(111, 15)
        Me.lblEg2OrdFab.TabIndex = 30
        Me.lblEg2OrdFab.Text = "Orden Fabricación:"
        Me.lblEg2OrdFab.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEg2OrdFabricacion
        '
        Me.txtEg2OrdFabricacion.Location = New System.Drawing.Point(417, 60)
        Me.txtEg2OrdFabricacion.Name = "txtEg2OrdFabricacion"
        Me.txtEg2OrdFabricacion.Size = New System.Drawing.Size(116, 21)
        Me.txtEg2OrdFabricacion.TabIndex = 29
        '
        'lblEg2CantKilos
        '
        Me.lblEg2CantKilos.AutoSize = True
        Me.lblEg2CantKilos.Location = New System.Drawing.Point(322, 36)
        Me.lblEg2CantKilos.Name = "lblEg2CantKilos"
        Me.lblEg2CantKilos.Size = New System.Drawing.Size(89, 15)
        Me.lblEg2CantKilos.TabIndex = 28
        Me.lblEg2CantKilos.Text = "Cantidad Kilos:"
        Me.lblEg2CantKilos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEg2CantEgresada
        '
        Me.lblEg2CantEgresada.AutoSize = True
        Me.lblEg2CantEgresada.Location = New System.Drawing.Point(57, 63)
        Me.lblEg2CantEgresada.Name = "lblEg2CantEgresada"
        Me.lblEg2CantEgresada.Size = New System.Drawing.Size(115, 15)
        Me.lblEg2CantEgresada.TabIndex = 27
        Me.lblEg2CantEgresada.Text = "Cantidad Egresada:"
        Me.lblEg2CantEgresada.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEg2CantKilos
        '
        Me.txtEg2CantKilos.Location = New System.Drawing.Point(417, 33)
        Me.txtEg2CantKilos.Name = "txtEg2CantKilos"
        Me.txtEg2CantKilos.Size = New System.Drawing.Size(116, 21)
        Me.txtEg2CantKilos.TabIndex = 26
        '
        'txtEg2CantEgresada
        '
        Me.txtEg2CantEgresada.Location = New System.Drawing.Point(178, 60)
        Me.txtEg2CantEgresada.Name = "txtEg2CantEgresada"
        Me.txtEg2CantEgresada.Size = New System.Drawing.Size(116, 21)
        Me.txtEg2CantEgresada.TabIndex = 25
        '
        'txtEg2OrdTeñido
        '
        Me.txtEg2OrdTeñido.Location = New System.Drawing.Point(178, 33)
        Me.txtEg2OrdTeñido.Name = "txtEg2OrdTeñido"
        Me.txtEg2OrdTeñido.Size = New System.Drawing.Size(116, 21)
        Me.txtEg2OrdTeñido.TabIndex = 11
        '
        'lblEg2OrdenTeñido
        '
        Me.lblEg2OrdenTeñido.AutoSize = True
        Me.lblEg2OrdenTeñido.Location = New System.Drawing.Point(87, 36)
        Me.lblEg2OrdenTeñido.Name = "lblEg2OrdenTeñido"
        Me.lblEg2OrdenTeñido.Size = New System.Drawing.Size(85, 15)
        Me.lblEg2OrdenTeñido.TabIndex = 9
        Me.lblEg2OrdenTeñido.Text = "Orden Teñido:"
        Me.lblEg2OrdenTeñido.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSal2Cancelar
        '
        Me.btnSal2Cancelar.Location = New System.Drawing.Point(300, 92)
        Me.btnSal2Cancelar.Name = "btnSal2Cancelar"
        Me.btnSal2Cancelar.Size = New System.Drawing.Size(87, 27)
        Me.btnSal2Cancelar.TabIndex = 8
        Me.btnSal2Cancelar.Text = "Cancelar"
        Me.btnSal2Cancelar.UseVisualStyleBackColor = True
        '
        'cmdEg2Guardar
        '
        Me.cmdEg2Guardar.Location = New System.Drawing.Point(207, 92)
        Me.cmdEg2Guardar.Name = "cmdEg2Guardar"
        Me.cmdEg2Guardar.Size = New System.Drawing.Size(87, 27)
        Me.cmdEg2Guardar.TabIndex = 7
        Me.cmdEg2Guardar.Text = "Guardar"
        Me.cmdEg2Guardar.UseVisualStyleBackColor = True
        '
        'frmAltaSaliMatPrim
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1225, 356)
        Me.Controls.Add(Me.gbSalidaMat)
        Me.Controls.Add(Me.gbSalidaProceso1)
        Me.Controls.Add(Me.gbSalidaProceso2)
        Me.Controls.Add(Me.gbDatos)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "frmAltaSaliMatPrim"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Salida de Materia Prima"
        Me.gbDatos.ResumeLayout(False)
        Me.gbSalidaMat.ResumeLayout(False)
        Me.gbSalidaMat.PerformLayout()
        Me.gbSalidaProceso1.ResumeLayout(False)
        Me.gbSalidaProceso1.PerformLayout()
        Me.gbSalidaProceso2.ResumeLayout(False)
        Me.gbSalidaProceso2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents lblDescCodigo As System.Windows.Forms.Label
    Friend WithEvents cmbCodigos As System.Windows.Forms.ComboBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents cmbTipos As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents gbSalidaMat As System.Windows.Forms.GroupBox
    Friend WithEvents lblEgMatCajas As System.Windows.Forms.Label
    Friend WithEvents lblEgMatOrdFab As System.Windows.Forms.Label
    Friend WithEvents lblEgMatFardos As System.Windows.Forms.Label
    Friend WithEvents txtEgMatCajas As System.Windows.Forms.TextBox
    Friend WithEvents txtEgMatOrdFabricacion As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEgMatFecha As System.Windows.Forms.Label
    Friend WithEvents txtEgMatFardos As System.Windows.Forms.TextBox
    Friend WithEvents txtEgMatConos As System.Windows.Forms.TextBox
    Friend WithEvents txtEgMatKilos As System.Windows.Forms.TextBox
    Friend WithEvents lblEgMatConos As System.Windows.Forms.Label
    Friend WithEvents lblEgMatKilos As System.Windows.Forms.Label
    Friend WithEvents btnMatCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdEgMatGuardar As System.Windows.Forms.Button
    Friend WithEvents gbSalidaProceso1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblEg1KilosEgresados As System.Windows.Forms.Label
    Friend WithEvents txtEg1KilosEgresados As System.Windows.Forms.TextBox
    Friend WithEvents lblEg1OrdFab As System.Windows.Forms.Label
    Friend WithEvents txtEg1OrdFab As System.Windows.Forms.TextBox
    Friend WithEvents lblEg1TopEgresados As System.Windows.Forms.Label
    Friend WithEvents txtEg1TopEgresados As System.Windows.Forms.TextBox
    Friend WithEvents txtEg1NroOrden As System.Windows.Forms.TextBox
    Friend WithEvents lblEg1NroOrden As System.Windows.Forms.Label
    Friend WithEvents btnSal1Cancelar As System.Windows.Forms.Button
    Friend WithEvents cmdEg1Guardar As System.Windows.Forms.Button
    Friend WithEvents gbSalidaProceso2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblEg2OrdFab As System.Windows.Forms.Label
    Friend WithEvents txtEg2OrdFabricacion As System.Windows.Forms.TextBox
    Friend WithEvents lblEg2CantKilos As System.Windows.Forms.Label
    Friend WithEvents lblEg2CantEgresada As System.Windows.Forms.Label
    Friend WithEvents txtEg2CantKilos As System.Windows.Forms.TextBox
    Friend WithEvents txtEg2CantEgresada As System.Windows.Forms.TextBox
    Friend WithEvents txtEg2OrdTeñido As System.Windows.Forms.TextBox
    Friend WithEvents lblEg2OrdenTeñido As System.Windows.Forms.Label
    Friend WithEvents btnSal2Cancelar As System.Windows.Forms.Button
    Friend WithEvents cmdEg2Guardar As System.Windows.Forms.Button
End Class
