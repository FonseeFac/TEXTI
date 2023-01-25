<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepoMovimientos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepoMovimientos))
        Me.gpbDatos = New System.Windows.Forms.GroupBox()
        Me.gpbMovimientos = New System.Windows.Forms.GroupBox()
        Me.cmbTipoMov = New System.Windows.Forms.ComboBox()
        Me.lblTipoMov = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.dgvMovimientos = New System.Windows.Forms.DataGridView()
        Me.lblNroOrden = New System.Windows.Forms.Label()
        Me.txtNroOrden = New System.Windows.Forms.TextBox()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.gpbDatos.SuspendLayout()
        Me.gpbMovimientos.SuspendLayout()
        CType(Me.dgvMovimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpbDatos
        '
        Me.gpbDatos.Controls.Add(Me.btnCerrar)
        Me.gpbDatos.Controls.Add(Me.btnProcesar)
        Me.gpbDatos.Controls.Add(Me.txtNroOrden)
        Me.gpbDatos.Controls.Add(Me.lblNroOrden)
        Me.gpbDatos.Controls.Add(Me.dtpFecha)
        Me.gpbDatos.Controls.Add(Me.lblFecha)
        Me.gpbDatos.Controls.Add(Me.cmbTipoMov)
        Me.gpbDatos.Controls.Add(Me.lblTipoMov)
        Me.gpbDatos.Location = New System.Drawing.Point(12, 12)
        Me.gpbDatos.Name = "gpbDatos"
        Me.gpbDatos.Size = New System.Drawing.Size(594, 100)
        Me.gpbDatos.TabIndex = 0
        Me.gpbDatos.TabStop = False
        Me.gpbDatos.Text = "Datos"
        '
        'gpbMovimientos
        '
        Me.gpbMovimientos.Controls.Add(Me.btnImprimir)
        Me.gpbMovimientos.Controls.Add(Me.dgvMovimientos)
        Me.gpbMovimientos.Location = New System.Drawing.Point(12, 118)
        Me.gpbMovimientos.Name = "gpbMovimientos"
        Me.gpbMovimientos.Size = New System.Drawing.Size(594, 305)
        Me.gpbMovimientos.TabIndex = 1
        Me.gpbMovimientos.TabStop = False
        Me.gpbMovimientos.Text = "Movimientos"
        '
        'cmbTipoMov
        '
        Me.cmbTipoMov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoMov.FormattingEnabled = True
        Me.cmbTipoMov.Location = New System.Drawing.Point(108, 19)
        Me.cmbTipoMov.Name = "cmbTipoMov"
        Me.cmbTipoMov.Size = New System.Drawing.Size(101, 21)
        Me.cmbTipoMov.TabIndex = 3
        '
        'lblTipoMov
        '
        Me.lblTipoMov.Location = New System.Drawing.Point(10, 17)
        Me.lblTipoMov.Name = "lblTipoMov"
        Me.lblTipoMov.Size = New System.Drawing.Size(92, 23)
        Me.lblTipoMov.TabIndex = 2
        Me.lblTipoMov.Text = "Tipo Movimiento:"
        Me.lblTipoMov.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFecha
        '
        Me.lblFecha.Location = New System.Drawing.Point(40, 43)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(62, 23)
        Me.lblFecha.TabIndex = 4
        Me.lblFecha.Text = "Fecha:"
        Me.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(108, 46)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(101, 20)
        Me.dtpFecha.TabIndex = 5
        '
        'dgvMovimientos
        '
        Me.dgvMovimientos.AllowUserToAddRows = False
        Me.dgvMovimientos.AllowUserToDeleteRows = False
        Me.dgvMovimientos.AllowUserToResizeColumns = False
        Me.dgvMovimientos.AllowUserToResizeRows = False
        Me.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMovimientos.Location = New System.Drawing.Point(6, 19)
        Me.dgvMovimientos.Name = "dgvMovimientos"
        Me.dgvMovimientos.ReadOnly = True
        Me.dgvMovimientos.RowHeadersVisible = False
        Me.dgvMovimientos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMovimientos.Size = New System.Drawing.Size(489, 280)
        Me.dgvMovimientos.TabIndex = 5
        '
        'lblNroOrden
        '
        Me.lblNroOrden.Location = New System.Drawing.Point(40, 70)
        Me.lblNroOrden.Name = "lblNroOrden"
        Me.lblNroOrden.Size = New System.Drawing.Size(62, 23)
        Me.lblNroOrden.TabIndex = 6
        Me.lblNroOrden.Text = "Nro. Orden:"
        Me.lblNroOrden.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNroOrden
        '
        Me.txtNroOrden.Location = New System.Drawing.Point(108, 72)
        Me.txtNroOrden.Name = "txtNroOrden"
        Me.txtNroOrden.Size = New System.Drawing.Size(101, 20)
        Me.txtNroOrden.TabIndex = 7
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(513, 17)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(75, 23)
        Me.btnProcesar.TabIndex = 8
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(513, 19)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimir.TabIndex = 9
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(513, 47)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 9
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'frmRepoMovimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(618, 435)
        Me.Controls.Add(Me.gpbMovimientos)
        Me.Controls.Add(Me.gpbDatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmRepoMovimientos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de Movimientos"
        Me.gpbDatos.ResumeLayout(False)
        Me.gpbDatos.PerformLayout()
        Me.gpbMovimientos.ResumeLayout(False)
        CType(Me.dgvMovimientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents gpbMovimientos As System.Windows.Forms.GroupBox
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnProcesar As System.Windows.Forms.Button
    Friend WithEvents txtNroOrden As System.Windows.Forms.TextBox
    Friend WithEvents lblNroOrden As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents cmbTipoMov As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoMov As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents dgvMovimientos As System.Windows.Forms.DataGridView
End Class
