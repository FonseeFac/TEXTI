<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCostosReporte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCostosReporte))
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.cmdListar = New System.Windows.Forms.Button()
        Me.cmdImpPlanilla = New System.Windows.Forms.Button()
        Me.dgvCostos = New System.Windows.Forms.DataGridView()
        Me.pdoImpPlanilla = New System.Drawing.Printing.PrintDocument()
        Me.cmdExcel = New System.Windows.Forms.Button()
        Me.lblVer = New System.Windows.Forms.Label()
        Me.cmbFiltroHiladosconCosto = New System.Windows.Forms.ComboBox()
        CType(Me.dgvCostos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdSalir
        '
        Me.cmdSalir.Location = New System.Drawing.Point(867, 478)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(96, 24)
        Me.cmdSalir.TabIndex = 105
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'cmdListar
        '
        Me.cmdListar.Location = New System.Drawing.Point(749, 9)
        Me.cmdListar.Name = "cmdListar"
        Me.cmdListar.Size = New System.Drawing.Size(104, 23)
        Me.cmdListar.TabIndex = 104
        Me.cmdListar.Text = "Listar"
        Me.cmdListar.UseVisualStyleBackColor = True
        '
        'cmdImpPlanilla
        '
        Me.cmdImpPlanilla.Location = New System.Drawing.Point(32, 477)
        Me.cmdImpPlanilla.Name = "cmdImpPlanilla"
        Me.cmdImpPlanilla.Size = New System.Drawing.Size(116, 24)
        Me.cmdImpPlanilla.TabIndex = 101
        Me.cmdImpPlanilla.Text = "Imprimir Planilla"
        Me.cmdImpPlanilla.UseVisualStyleBackColor = True
        '
        'dgvCostos
        '
        Me.dgvCostos.AllowUserToAddRows = False
        Me.dgvCostos.AllowUserToDeleteRows = False
        Me.dgvCostos.AllowUserToResizeColumns = False
        Me.dgvCostos.AllowUserToResizeRows = False
        Me.dgvCostos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvCostos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCostos.Location = New System.Drawing.Point(12, 39)
        Me.dgvCostos.MultiSelect = False
        Me.dgvCostos.Name = "dgvCostos"
        Me.dgvCostos.RowHeadersWidth = 20
        Me.dgvCostos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCostos.Size = New System.Drawing.Size(960, 430)
        Me.dgvCostos.TabIndex = 100
        '
        'pdoImpPlanilla
        '
        '
        'cmdExcel
        '
        Me.cmdExcel.Location = New System.Drawing.Point(223, 477)
        Me.cmdExcel.Name = "cmdExcel"
        Me.cmdExcel.Size = New System.Drawing.Size(125, 24)
        Me.cmdExcel.TabIndex = 108
        Me.cmdExcel.Text = "Exportar a Excel"
        Me.cmdExcel.UseVisualStyleBackColor = True
        '
        'lblVer
        '
        Me.lblVer.Location = New System.Drawing.Point(20, 11)
        Me.lblVer.Name = "lblVer"
        Me.lblVer.Size = New System.Drawing.Size(36, 23)
        Me.lblVer.TabIndex = 109
        Me.lblVer.Text = "Ver:"
        Me.lblVer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbFiltroHiladosconCosto
        '
        Me.cmbFiltroHiladosconCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFiltroHiladosconCosto.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFiltroHiladosconCosto.FormattingEnabled = True
        Me.cmbFiltroHiladosconCosto.Location = New System.Drawing.Point(62, 13)
        Me.cmbFiltroHiladosconCosto.Name = "cmbFiltroHiladosconCosto"
        Me.cmbFiltroHiladosconCosto.Size = New System.Drawing.Size(169, 20)
        Me.cmbFiltroHiladosconCosto.TabIndex = 110
        '
        'frmCostosReporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(979, 511)
        Me.Controls.Add(Me.cmbFiltroHiladosconCosto)
        Me.Controls.Add(Me.lblVer)
        Me.Controls.Add(Me.cmdExcel)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.cmdListar)
        Me.Controls.Add(Me.cmdImpPlanilla)
        Me.Controls.Add(Me.dgvCostos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCostosReporte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Costos de Hilados"
        CType(Me.dgvCostos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents cmdListar As System.Windows.Forms.Button
    Friend WithEvents cmdImpPlanilla As System.Windows.Forms.Button
    Friend WithEvents dgvCostos As System.Windows.Forms.DataGridView
    Friend WithEvents pdoImpPlanilla As System.Drawing.Printing.PrintDocument
    Friend WithEvents cmdExcel As System.Windows.Forms.Button
    Friend WithEvents lblVer As System.Windows.Forms.Label
    Friend WithEvents cmbFiltroHiladosconCosto As System.Windows.Forms.ComboBox
End Class
