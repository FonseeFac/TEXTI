<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepoCC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepoCC))
        Me.gpbReporte = New System.Windows.Forms.GroupBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.gpbProcesando = New System.Windows.Forms.GroupBox()
        Me.lblProcesando = New System.Windows.Forms.Label()
        Me.dgvReporte = New System.Windows.Forms.DataGridView()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.gpbDatos = New System.Windows.Forms.GroupBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.lblTalle = New System.Windows.Forms.Label()
        Me.cmbTalle = New System.Windows.Forms.ComboBox()
        Me.lblDestino = New System.Windows.Forms.Label()
        Me.cmbDestino = New System.Windows.Forms.ComboBox()
        Me.txtOP = New System.Windows.Forms.TextBox()
        Me.lblOP = New System.Windows.Forms.Label()
        Me.lblOrigen = New System.Windows.Forms.Label()
        Me.txtCodArticulo = New System.Windows.Forms.TextBox()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaHasta = New System.Windows.Forms.Label()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.cmbOrigen = New System.Windows.Forms.ComboBox()
        Me.lblCodArticulo = New System.Windows.Forms.Label()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaDesde = New System.Windows.Forms.Label()
        Me.btnVer = New System.Windows.Forms.Button()
        Me.gpbReporte.SuspendLayout()
        Me.gpbProcesando.SuspendLayout()
        CType(Me.dgvReporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpbReporte
        '
        Me.gpbReporte.Controls.Add(Me.btnVer)
        Me.gpbReporte.Controls.Add(Me.btnEliminar)
        Me.gpbReporte.Controls.Add(Me.btnModificar)
        Me.gpbReporte.Controls.Add(Me.btnAgregar)
        Me.gpbReporte.Controls.Add(Me.gpbProcesando)
        Me.gpbReporte.Controls.Add(Me.dgvReporte)
        Me.gpbReporte.Controls.Add(Me.btnImprimir)
        Me.gpbReporte.Location = New System.Drawing.Point(12, 120)
        Me.gpbReporte.Name = "gpbReporte"
        Me.gpbReporte.Size = New System.Drawing.Size(1186, 648)
        Me.gpbReporte.TabIndex = 11
        Me.gpbReporte.TabStop = False
        Me.gpbReporte.Text = "Registros"
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Location = New System.Drawing.Point(1069, 124)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(111, 34)
        Me.btnEliminar.TabIndex = 19
        Me.btnEliminar.Text = "ELIMINAR"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModificar.Location = New System.Drawing.Point(1068, 72)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(111, 34)
        Me.btnModificar.TabIndex = 18
        Me.btnModificar.Text = "MODIFICAR"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Enabled = False
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Location = New System.Drawing.Point(1069, 19)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(111, 34)
        Me.btnAgregar.TabIndex = 17
        Me.btnAgregar.Text = "AGREGAR"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'gpbProcesando
        '
        Me.gpbProcesando.Controls.Add(Me.lblProcesando)
        Me.gpbProcesando.Location = New System.Drawing.Point(282, 252)
        Me.gpbProcesando.Name = "gpbProcesando"
        Me.gpbProcesando.Size = New System.Drawing.Size(491, 191)
        Me.gpbProcesando.TabIndex = 16
        Me.gpbProcesando.TabStop = False
        Me.gpbProcesando.Visible = False
        '
        'lblProcesando
        '
        Me.lblProcesando.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcesando.Location = New System.Drawing.Point(6, 81)
        Me.lblProcesando.Name = "lblProcesando"
        Me.lblProcesando.Size = New System.Drawing.Size(479, 48)
        Me.lblProcesando.TabIndex = 14
        Me.lblProcesando.Text = "PROCESANDO..."
        Me.lblProcesando.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvReporte
        '
        Me.dgvReporte.AllowUserToAddRows = False
        Me.dgvReporte.AllowUserToDeleteRows = False
        Me.dgvReporte.AllowUserToResizeColumns = False
        Me.dgvReporte.AllowUserToResizeRows = False
        Me.dgvReporte.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReporte.Location = New System.Drawing.Point(10, 19)
        Me.dgvReporte.Name = "dgvReporte"
        Me.dgvReporte.ReadOnly = True
        Me.dgvReporte.RowHeadersVisible = False
        Me.dgvReporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReporte.Size = New System.Drawing.Size(1053, 623)
        Me.dgvReporte.TabIndex = 4
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Location = New System.Drawing.Point(1068, 365)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(111, 34)
        Me.btnImprimir.TabIndex = 5
        Me.btnImprimir.Text = "IMPRIMIR"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'gpbDatos
        '
        Me.gpbDatos.Controls.Add(Me.lblEstado)
        Me.gpbDatos.Controls.Add(Me.cmbEstado)
        Me.gpbDatos.Controls.Add(Me.lblTalle)
        Me.gpbDatos.Controls.Add(Me.cmbTalle)
        Me.gpbDatos.Controls.Add(Me.lblDestino)
        Me.gpbDatos.Controls.Add(Me.cmbDestino)
        Me.gpbDatos.Controls.Add(Me.txtOP)
        Me.gpbDatos.Controls.Add(Me.lblOP)
        Me.gpbDatos.Controls.Add(Me.lblOrigen)
        Me.gpbDatos.Controls.Add(Me.txtCodArticulo)
        Me.gpbDatos.Controls.Add(Me.dtpFechaHasta)
        Me.gpbDatos.Controls.Add(Me.lblFechaHasta)
        Me.gpbDatos.Controls.Add(Me.btnProcesar)
        Me.gpbDatos.Controls.Add(Me.btnCerrar)
        Me.gpbDatos.Controls.Add(Me.cmbOrigen)
        Me.gpbDatos.Controls.Add(Me.lblCodArticulo)
        Me.gpbDatos.Controls.Add(Me.dtpFechaDesde)
        Me.gpbDatos.Controls.Add(Me.lblFechaDesde)
        Me.gpbDatos.Location = New System.Drawing.Point(12, 12)
        Me.gpbDatos.Name = "gpbDatos"
        Me.gpbDatos.Size = New System.Drawing.Size(1186, 102)
        Me.gpbDatos.TabIndex = 10
        Me.gpbDatos.TabStop = False
        Me.gpbDatos.Text = "Datos"
        '
        'lblEstado
        '
        Me.lblEstado.Location = New System.Drawing.Point(450, 51)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(62, 23)
        Me.lblEstado.TabIndex = 24
        Me.lblEstado.Text = "Estado:"
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(518, 51)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(179, 24)
        Me.cmbEstado.TabIndex = 23
        '
        'lblTalle
        '
        Me.lblTalle.Location = New System.Drawing.Point(450, 22)
        Me.lblTalle.Name = "lblTalle"
        Me.lblTalle.Size = New System.Drawing.Size(62, 23)
        Me.lblTalle.TabIndex = 22
        Me.lblTalle.Text = "Talle:"
        Me.lblTalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbTalle
        '
        Me.cmbTalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTalle.FormattingEnabled = True
        Me.cmbTalle.Location = New System.Drawing.Point(518, 21)
        Me.cmbTalle.Name = "cmbTalle"
        Me.cmbTalle.Size = New System.Drawing.Size(99, 24)
        Me.cmbTalle.TabIndex = 21
        '
        'lblDestino
        '
        Me.lblDestino.Location = New System.Drawing.Point(703, 49)
        Me.lblDestino.Name = "lblDestino"
        Me.lblDestino.Size = New System.Drawing.Size(71, 23)
        Me.lblDestino.TabIndex = 20
        Me.lblDestino.Text = "Destino:"
        Me.lblDestino.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbDestino
        '
        Me.cmbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDestino.FormattingEnabled = True
        Me.cmbDestino.Location = New System.Drawing.Point(780, 51)
        Me.cmbDestino.Name = "cmbDestino"
        Me.cmbDestino.Size = New System.Drawing.Size(210, 24)
        Me.cmbDestino.TabIndex = 19
        '
        'txtOP
        '
        Me.txtOP.Location = New System.Drawing.Point(345, 52)
        Me.txtOP.Name = "txtOP"
        Me.txtOP.Size = New System.Drawing.Size(84, 23)
        Me.txtOP.TabIndex = 18
        '
        'lblOP
        '
        Me.lblOP.Location = New System.Drawing.Point(242, 51)
        Me.lblOP.Name = "lblOP"
        Me.lblOP.Size = New System.Drawing.Size(97, 23)
        Me.lblOP.TabIndex = 17
        Me.lblOP.Text = "OP:"
        Me.lblOP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOrigen
        '
        Me.lblOrigen.Location = New System.Drawing.Point(700, 19)
        Me.lblOrigen.Name = "lblOrigen"
        Me.lblOrigen.Size = New System.Drawing.Size(74, 23)
        Me.lblOrigen.TabIndex = 16
        Me.lblOrigen.Text = "Origen:"
        Me.lblOrigen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCodArticulo
        '
        Me.txtCodArticulo.Location = New System.Drawing.Point(345, 23)
        Me.txtCodArticulo.Name = "txtCodArticulo"
        Me.txtCodArticulo.Size = New System.Drawing.Size(84, 23)
        Me.txtCodArticulo.TabIndex = 15
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(134, 49)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(102, 23)
        Me.dtpFechaHasta.TabIndex = 14
        '
        'lblFechaHasta
        '
        Me.lblFechaHasta.Location = New System.Drawing.Point(20, 49)
        Me.lblFechaHasta.Name = "lblFechaHasta"
        Me.lblFechaHasta.Size = New System.Drawing.Size(108, 23)
        Me.lblFechaHasta.TabIndex = 13
        Me.lblFechaHasta.Text = "Fecha hasta:"
        Me.lblFechaHasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnProcesar
        '
        Me.btnProcesar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcesar.Location = New System.Drawing.Point(1069, 22)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(111, 34)
        Me.btnProcesar.TabIndex = 12
        Me.btnProcesar.Text = "PROCESAR"
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(1068, 62)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(111, 34)
        Me.btnCerrar.TabIndex = 6
        Me.btnCerrar.Text = "CERRAR"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'cmbOrigen
        '
        Me.cmbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrigen.FormattingEnabled = True
        Me.cmbOrigen.Location = New System.Drawing.Point(780, 21)
        Me.cmbOrigen.Name = "cmbOrigen"
        Me.cmbOrigen.Size = New System.Drawing.Size(210, 24)
        Me.cmbOrigen.TabIndex = 3
        '
        'lblCodArticulo
        '
        Me.lblCodArticulo.Location = New System.Drawing.Point(242, 22)
        Me.lblCodArticulo.Name = "lblCodArticulo"
        Me.lblCodArticulo.Size = New System.Drawing.Size(97, 23)
        Me.lblCodArticulo.TabIndex = 2
        Me.lblCodArticulo.Text = "Cód. Artículo:"
        Me.lblCodArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(134, 20)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(102, 23)
        Me.dtpFechaDesde.TabIndex = 1
        '
        'lblFechaDesde
        '
        Me.lblFechaDesde.Location = New System.Drawing.Point(20, 20)
        Me.lblFechaDesde.Name = "lblFechaDesde"
        Me.lblFechaDesde.Size = New System.Drawing.Size(108, 23)
        Me.lblFechaDesde.TabIndex = 0
        Me.lblFechaDesde.Text = "Fecha desde:"
        Me.lblFechaDesde.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnVer
        '
        Me.btnVer.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVer.Location = New System.Drawing.Point(1068, 232)
        Me.btnVer.Name = "btnVer"
        Me.btnVer.Size = New System.Drawing.Size(111, 34)
        Me.btnVer.TabIndex = 20
        Me.btnVer.Text = "VER"
        Me.btnVer.UseVisualStyleBackColor = True
        '
        'frmRepoCC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1207, 773)
        Me.Controls.Add(Me.gpbReporte)
        Me.Controls.Add(Me.gpbDatos)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "frmRepoCC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Control de Calidad"
        Me.gpbReporte.ResumeLayout(False)
        Me.gpbProcesando.ResumeLayout(False)
        CType(Me.dgvReporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbDatos.ResumeLayout(False)
        Me.gpbDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpbReporte As System.Windows.Forms.GroupBox
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents gpbProcesando As System.Windows.Forms.GroupBox
    Friend WithEvents lblProcesando As System.Windows.Forms.Label
    Friend WithEvents dgvReporte As System.Windows.Forms.DataGridView
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents gpbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents lblTalle As System.Windows.Forms.Label
    Friend WithEvents cmbTalle As System.Windows.Forms.ComboBox
    Friend WithEvents lblDestino As System.Windows.Forms.Label
    Friend WithEvents cmbDestino As System.Windows.Forms.ComboBox
    Friend WithEvents txtOP As System.Windows.Forms.TextBox
    Friend WithEvents lblOP As System.Windows.Forms.Label
    Friend WithEvents lblOrigen As System.Windows.Forms.Label
    Friend WithEvents txtCodArticulo As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaHasta As System.Windows.Forms.Label
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents cmbOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents lblCodArticulo As System.Windows.Forms.Label
    Friend WithEvents dtpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaDesde As System.Windows.Forms.Label
    Friend WithEvents btnVer As System.Windows.Forms.Button
End Class
