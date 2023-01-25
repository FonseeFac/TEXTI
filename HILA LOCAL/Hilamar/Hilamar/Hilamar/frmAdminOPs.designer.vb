<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminOPs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdminOPs))
        Me.cmdVolver = New System.Windows.Forms.Button()
        Me.dgvOPs = New System.Windows.Forms.DataGridView()
        Me.cmdBuscar = New System.Windows.Forms.Button()
        Me.txtNroOP = New System.Windows.Forms.TextBox()
        Me.lblNroOrden = New System.Windows.Forms.Label()
        Me.cmdAgregar = New System.Windows.Forms.Button()
        Me.cmdModificar = New System.Windows.Forms.Button()
        CType(Me.dgvOPs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdVolver
        '
        Me.cmdVolver.Location = New System.Drawing.Point(719, 416)
        Me.cmdVolver.Name = "cmdVolver"
        Me.cmdVolver.Size = New System.Drawing.Size(86, 26)
        Me.cmdVolver.TabIndex = 6
        Me.cmdVolver.Text = "Volver"
        Me.cmdVolver.UseVisualStyleBackColor = True
        '
        'dgvOPs
        '
        Me.dgvOPs.AllowUserToAddRows = False
        Me.dgvOPs.AllowUserToDeleteRows = False
        Me.dgvOPs.AllowUserToResizeColumns = False
        Me.dgvOPs.AllowUserToResizeRows = False
        Me.dgvOPs.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvOPs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOPs.Location = New System.Drawing.Point(7, 49)
        Me.dgvOPs.MultiSelect = False
        Me.dgvOPs.Name = "dgvOPs"
        Me.dgvOPs.RowHeadersWidth = 20
        Me.dgvOPs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOPs.Size = New System.Drawing.Size(691, 405)
        Me.dgvOPs.TabIndex = 35
        '
        'cmdBuscar
        '
        Me.cmdBuscar.Location = New System.Drawing.Point(239, 9)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(75, 23)
        Me.cmdBuscar.TabIndex = 34
        Me.cmdBuscar.Text = "Buscar"
        Me.cmdBuscar.UseVisualStyleBackColor = True
        '
        'txtNroOP
        '
        Me.txtNroOP.Location = New System.Drawing.Point(72, 11)
        Me.txtNroOP.Name = "txtNroOP"
        Me.txtNroOP.Size = New System.Drawing.Size(146, 20)
        Me.txtNroOP.TabIndex = 33
        '
        'lblNroOrden
        '
        Me.lblNroOrden.Location = New System.Drawing.Point(12, 9)
        Me.lblNroOrden.Name = "lblNroOrden"
        Me.lblNroOrden.Size = New System.Drawing.Size(54, 23)
        Me.lblNroOrden.TabIndex = 32
        Me.lblNroOrden.Text = "Número:"
        Me.lblNroOrden.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdAgregar
        '
        Me.cmdAgregar.Location = New System.Drawing.Point(719, 78)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(86, 26)
        Me.cmdAgregar.TabIndex = 36
        Me.cmdAgregar.Text = "Nueva OP"
        Me.cmdAgregar.UseVisualStyleBackColor = True
        '
        'cmdModificar
        '
        Me.cmdModificar.Location = New System.Drawing.Point(719, 130)
        Me.cmdModificar.Name = "cmdModificar"
        Me.cmdModificar.Size = New System.Drawing.Size(86, 26)
        Me.cmdModificar.TabIndex = 37
        Me.cmdModificar.Text = "Modificar"
        Me.cmdModificar.UseVisualStyleBackColor = True
        '
        'frmAdminOPs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(815, 466)
        Me.Controls.Add(Me.cmdModificar)
        Me.Controls.Add(Me.cmdAgregar)
        Me.Controls.Add(Me.dgvOPs)
        Me.Controls.Add(Me.cmdBuscar)
        Me.Controls.Add(Me.txtNroOP)
        Me.Controls.Add(Me.lblNroOrden)
        Me.Controls.Add(Me.cmdVolver)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmAdminOPs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administrar Ordenes de Producción"
        CType(Me.dgvOPs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdVolver As System.Windows.Forms.Button
    Friend WithEvents dgvOPs As System.Windows.Forms.DataGridView
    Friend WithEvents cmdBuscar As System.Windows.Forms.Button
    Friend WithEvents txtNroOP As System.Windows.Forms.TextBox
    Friend WithEvents lblNroOrden As System.Windows.Forms.Label
    Friend WithEvents cmdAgregar As System.Windows.Forms.Button
    Friend WithEvents cmdModificar As System.Windows.Forms.Button
End Class
