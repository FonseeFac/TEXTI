<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHilaRepoMovimHilados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHilaRepoMovimHilados))
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.dgvMovimientos = New System.Windows.Forms.DataGridView()
        Me.cmdListar = New System.Windows.Forms.Button()
        Me.lblFiltroHilado = New System.Windows.Forms.Label()
        Me.txtFiltroHilado = New System.Windows.Forms.TextBox()
        Me.lblFiltroPartida = New System.Windows.Forms.Label()
        Me.txtFiltroPartida = New System.Windows.Forms.TextBox()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaDesde = New System.Windows.Forms.Label()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaHasta = New System.Windows.Forms.Label()
        Me.gbFiltroMov = New System.Windows.Forms.GroupBox()
        Me.rbFiltroMovC = New System.Windows.Forms.RadioButton()
        Me.rbFiltroMovDI = New System.Windows.Forms.RadioButton()
        Me.rbFiltroMovI = New System.Windows.Forms.RadioButton()
        Me.rbFiltroMovE = New System.Windows.Forms.RadioButton()
        Me.rbFiltroMovTodos = New System.Windows.Forms.RadioButton()
        Me.btnEditarMovimiento = New System.Windows.Forms.Button()
        Me.btnEliminarMovimiento = New System.Windows.Forms.Button()
        Me.btnExportarExcel = New System.Windows.Forms.Button()
        CType(Me.dgvMovimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFiltroMov.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSalir
        '
        Me.cmdSalir.Location = New System.Drawing.Point(758, 465)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(89, 29)
        Me.cmdSalir.TabIndex = 4
        Me.cmdSalir.Text = "SALIR"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'dgvMovimientos
        '
        Me.dgvMovimientos.AllowUserToAddRows = False
        Me.dgvMovimientos.AllowUserToDeleteRows = False
        Me.dgvMovimientos.AllowUserToResizeColumns = False
        Me.dgvMovimientos.AllowUserToResizeRows = False
        Me.dgvMovimientos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMovimientos.Location = New System.Drawing.Point(12, 78)
        Me.dgvMovimientos.MultiSelect = False
        Me.dgvMovimientos.Name = "dgvMovimientos"
        Me.dgvMovimientos.RowHeadersWidth = 20
        Me.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMovimientos.Size = New System.Drawing.Size(852, 380)
        Me.dgvMovimientos.TabIndex = 31
        '
        'cmdListar
        '
        Me.cmdListar.Location = New System.Drawing.Point(766, 23)
        Me.cmdListar.Name = "cmdListar"
        Me.cmdListar.Size = New System.Drawing.Size(81, 33)
        Me.cmdListar.TabIndex = 99
        Me.cmdListar.Text = "LISTAR"
        Me.cmdListar.UseVisualStyleBackColor = True
        '
        'lblFiltroHilado
        '
        Me.lblFiltroHilado.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFiltroHilado.Location = New System.Drawing.Point(27, 42)
        Me.lblFiltroHilado.Name = "lblFiltroHilado"
        Me.lblFiltroHilado.Size = New System.Drawing.Size(73, 20)
        Me.lblFiltroHilado.TabIndex = 103
        Me.lblFiltroHilado.Text = "Cod Hilado:"
        Me.lblFiltroHilado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFiltroHilado
        '
        Me.txtFiltroHilado.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFiltroHilado.Location = New System.Drawing.Point(106, 40)
        Me.txtFiltroHilado.Name = "txtFiltroHilado"
        Me.txtFiltroHilado.Size = New System.Drawing.Size(110, 21)
        Me.txtFiltroHilado.TabIndex = 102
        '
        'lblFiltroPartida
        '
        Me.lblFiltroPartida.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFiltroPartida.Location = New System.Drawing.Point(243, 42)
        Me.lblFiltroPartida.Name = "lblFiltroPartida"
        Me.lblFiltroPartida.Size = New System.Drawing.Size(55, 20)
        Me.lblFiltroPartida.TabIndex = 101
        Me.lblFiltroPartida.Text = "Partida:"
        Me.lblFiltroPartida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFiltroPartida
        '
        Me.txtFiltroPartida.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFiltroPartida.Location = New System.Drawing.Point(304, 40)
        Me.txtFiltroPartida.Name = "txtFiltroPartida"
        Me.txtFiltroPartida.Size = New System.Drawing.Size(110, 21)
        Me.txtFiltroPartida.TabIndex = 100
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(107, 13)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(102, 21)
        Me.dtpFechaDesde.TabIndex = 105
        '
        'lblFechaDesde
        '
        Me.lblFechaDesde.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaDesde.Location = New System.Drawing.Point(10, 13)
        Me.lblFechaDesde.Name = "lblFechaDesde"
        Me.lblFechaDesde.Size = New System.Drawing.Size(91, 21)
        Me.lblFechaDesde.TabIndex = 104
        Me.lblFechaDesde.Text = "Fecha Desde:"
        Me.lblFechaDesde.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(312, 13)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(102, 21)
        Me.dtpFechaHasta.TabIndex = 107
        '
        'lblFechaHasta
        '
        Me.lblFechaHasta.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaHasta.Location = New System.Drawing.Point(215, 13)
        Me.lblFechaHasta.Name = "lblFechaHasta"
        Me.lblFechaHasta.Size = New System.Drawing.Size(91, 21)
        Me.lblFechaHasta.TabIndex = 106
        Me.lblFechaHasta.Text = "Fecha Hasta:"
        Me.lblFechaHasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbFiltroMov
        '
        Me.gbFiltroMov.Controls.Add(Me.rbFiltroMovC)
        Me.gbFiltroMov.Controls.Add(Me.rbFiltroMovDI)
        Me.gbFiltroMov.Controls.Add(Me.rbFiltroMovI)
        Me.gbFiltroMov.Controls.Add(Me.rbFiltroMovE)
        Me.gbFiltroMov.Controls.Add(Me.rbFiltroMovTodos)
        Me.gbFiltroMov.Location = New System.Drawing.Point(431, 5)
        Me.gbFiltroMov.Name = "gbFiltroMov"
        Me.gbFiltroMov.Size = New System.Drawing.Size(310, 30)
        Me.gbFiltroMov.TabIndex = 108
        Me.gbFiltroMov.TabStop = False
        '
        'rbFiltroMovC
        '
        Me.rbFiltroMovC.AutoSize = True
        Me.rbFiltroMovC.Location = New System.Drawing.Point(257, 9)
        Me.rbFiltroMovC.Name = "rbFiltroMovC"
        Me.rbFiltroMovC.Size = New System.Drawing.Size(32, 18)
        Me.rbFiltroMovC.TabIndex = 4
        Me.rbFiltroMovC.Text = "C"
        Me.rbFiltroMovC.UseVisualStyleBackColor = True
        '
        'rbFiltroMovDI
        '
        Me.rbFiltroMovDI.AutoSize = True
        Me.rbFiltroMovDI.Location = New System.Drawing.Point(202, 9)
        Me.rbFiltroMovDI.Name = "rbFiltroMovDI"
        Me.rbFiltroMovDI.Size = New System.Drawing.Size(34, 18)
        Me.rbFiltroMovDI.TabIndex = 3
        Me.rbFiltroMovDI.Text = "DI"
        Me.rbFiltroMovDI.UseVisualStyleBackColor = True
        '
        'rbFiltroMovI
        '
        Me.rbFiltroMovI.AutoSize = True
        Me.rbFiltroMovI.Location = New System.Drawing.Point(149, 9)
        Me.rbFiltroMovI.Name = "rbFiltroMovI"
        Me.rbFiltroMovI.Size = New System.Drawing.Size(27, 18)
        Me.rbFiltroMovI.TabIndex = 2
        Me.rbFiltroMovI.Text = "I"
        Me.rbFiltroMovI.UseVisualStyleBackColor = True
        '
        'rbFiltroMovE
        '
        Me.rbFiltroMovE.AutoSize = True
        Me.rbFiltroMovE.Location = New System.Drawing.Point(94, 9)
        Me.rbFiltroMovE.Name = "rbFiltroMovE"
        Me.rbFiltroMovE.Size = New System.Drawing.Size(31, 18)
        Me.rbFiltroMovE.TabIndex = 1
        Me.rbFiltroMovE.Text = "E"
        Me.rbFiltroMovE.UseVisualStyleBackColor = True
        '
        'rbFiltroMovTodos
        '
        Me.rbFiltroMovTodos.AutoSize = True
        Me.rbFiltroMovTodos.Checked = True
        Me.rbFiltroMovTodos.Location = New System.Drawing.Point(15, 9)
        Me.rbFiltroMovTodos.Name = "rbFiltroMovTodos"
        Me.rbFiltroMovTodos.Size = New System.Drawing.Size(54, 18)
        Me.rbFiltroMovTodos.TabIndex = 0
        Me.rbFiltroMovTodos.TabStop = True
        Me.rbFiltroMovTodos.Text = "Todos"
        Me.rbFiltroMovTodos.UseVisualStyleBackColor = True
        '
        'btnEditarMovimiento
        '
        Me.btnEditarMovimiento.Location = New System.Drawing.Point(870, 100)
        Me.btnEditarMovimiento.Name = "btnEditarMovimiento"
        Me.btnEditarMovimiento.Size = New System.Drawing.Size(64, 47)
        Me.btnEditarMovimiento.TabIndex = 109
        Me.btnEditarMovimiento.Text = "EDITAR MOVIM"
        Me.btnEditarMovimiento.UseVisualStyleBackColor = True
        '
        'btnEliminarMovimiento
        '
        Me.btnEliminarMovimiento.Location = New System.Drawing.Point(870, 192)
        Me.btnEliminarMovimiento.Name = "btnEliminarMovimiento"
        Me.btnEliminarMovimiento.Size = New System.Drawing.Size(64, 47)
        Me.btnEliminarMovimiento.TabIndex = 110
        Me.btnEliminarMovimiento.Text = "ELIMINAR"
        Me.btnEliminarMovimiento.UseVisualStyleBackColor = True
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.Location = New System.Drawing.Point(864, 357)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(76, 59)
        Me.btnExportarExcel.TabIndex = 111
        Me.btnExportarExcel.Text = "EXPORTAR A EXCEL"
        Me.btnExportarExcel.UseVisualStyleBackColor = True
        '
        'frmHilaRepoMovimHilados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(940, 501)
        Me.Controls.Add(Me.btnExportarExcel)
        Me.Controls.Add(Me.btnEliminarMovimiento)
        Me.Controls.Add(Me.btnEditarMovimiento)
        Me.Controls.Add(Me.gbFiltroMov)
        Me.Controls.Add(Me.dtpFechaHasta)
        Me.Controls.Add(Me.lblFechaHasta)
        Me.Controls.Add(Me.dtpFechaDesde)
        Me.Controls.Add(Me.lblFechaDesde)
        Me.Controls.Add(Me.lblFiltroHilado)
        Me.Controls.Add(Me.txtFiltroHilado)
        Me.Controls.Add(Me.lblFiltroPartida)
        Me.Controls.Add(Me.txtFiltroPartida)
        Me.Controls.Add(Me.cmdListar)
        Me.Controls.Add(Me.dgvMovimientos)
        Me.Controls.Add(Me.cmdSalir)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmHilaRepoMovimHilados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Movimientos de Hilados"
        CType(Me.dgvMovimientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFiltroMov.ResumeLayout(False)
        Me.gbFiltroMov.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents dgvMovimientos As System.Windows.Forms.DataGridView
    Friend WithEvents cmdListar As System.Windows.Forms.Button
    Friend WithEvents lblFiltroHilado As System.Windows.Forms.Label
    Friend WithEvents txtFiltroHilado As System.Windows.Forms.TextBox
    Friend WithEvents lblFiltroPartida As System.Windows.Forms.Label
    Friend WithEvents txtFiltroPartida As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaDesde As System.Windows.Forms.Label
    Friend WithEvents dtpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaHasta As System.Windows.Forms.Label
    Friend WithEvents gbFiltroMov As System.Windows.Forms.GroupBox
    Friend WithEvents rbFiltroMovDI As System.Windows.Forms.RadioButton
    Friend WithEvents rbFiltroMovI As System.Windows.Forms.RadioButton
    Friend WithEvents rbFiltroMovE As System.Windows.Forms.RadioButton
    Friend WithEvents rbFiltroMovTodos As System.Windows.Forms.RadioButton
    Friend WithEvents btnEditarMovimiento As System.Windows.Forms.Button
    Friend WithEvents btnEliminarMovimiento As System.Windows.Forms.Button
    Friend WithEvents rbFiltroMovC As System.Windows.Forms.RadioButton
    Friend WithEvents btnExportarExcel As System.Windows.Forms.Button
End Class
