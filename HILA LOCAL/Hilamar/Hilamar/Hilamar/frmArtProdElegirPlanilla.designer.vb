<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArtProdElegirPlanilla
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArtProdElegirPlanilla))
        Me.dgvColorPartida = New System.Windows.Forms.DataGridView()
        Me.dgvArticulos = New System.Windows.Forms.DataGridView()
        Me.txtArticulo = New System.Windows.Forms.TextBox()
        Me.lblBuscarDesc = New System.Windows.Forms.Label()
        Me.cmbCategoria = New System.Windows.Forms.ComboBox()
        Me.lblCateg = New System.Windows.Forms.Label()
        Me.cmdVolver = New System.Windows.Forms.Button()
        Me.cmdSeleccionarPlanilla = New System.Windows.Forms.Button()
        CType(Me.dgvColorPartida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvColorPartida
        '
        Me.dgvColorPartida.AllowUserToAddRows = False
        Me.dgvColorPartida.AllowUserToDeleteRows = False
        Me.dgvColorPartida.AllowUserToResizeColumns = False
        Me.dgvColorPartida.AllowUserToResizeRows = False
        Me.dgvColorPartida.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvColorPartida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvColorPartida.Location = New System.Drawing.Point(264, 78)
        Me.dgvColorPartida.Name = "dgvColorPartida"
        Me.dgvColorPartida.ReadOnly = True
        Me.dgvColorPartida.RowHeadersVisible = False
        Me.dgvColorPartida.RowHeadersWidth = 31
        Me.dgvColorPartida.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvColorPartida.Size = New System.Drawing.Size(380, 366)
        Me.dgvColorPartida.TabIndex = 265
        '
        'dgvArticulos
        '
        Me.dgvArticulos.AllowUserToAddRows = False
        Me.dgvArticulos.AllowUserToDeleteRows = False
        Me.dgvArticulos.AllowUserToResizeColumns = False
        Me.dgvArticulos.AllowUserToResizeRows = False
        Me.dgvArticulos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArticulos.Location = New System.Drawing.Point(16, 78)
        Me.dgvArticulos.Name = "dgvArticulos"
        Me.dgvArticulos.ReadOnly = True
        Me.dgvArticulos.RowHeadersVisible = False
        Me.dgvArticulos.RowHeadersWidth = 31
        Me.dgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvArticulos.Size = New System.Drawing.Size(242, 366)
        Me.dgvArticulos.TabIndex = 264
        '
        'txtArticulo
        '
        Me.txtArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArticulo.Location = New System.Drawing.Point(87, 51)
        Me.txtArticulo.Name = "txtArticulo"
        Me.txtArticulo.Size = New System.Drawing.Size(99, 21)
        Me.txtArticulo.TabIndex = 261
        '
        'lblBuscarDesc
        '
        Me.lblBuscarDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBuscarDesc.Location = New System.Drawing.Point(11, 51)
        Me.lblBuscarDesc.Name = "lblBuscarDesc"
        Me.lblBuscarDesc.Size = New System.Drawing.Size(70, 23)
        Me.lblBuscarDesc.TabIndex = 260
        Me.lblBuscarDesc.Text = "Artículo:"
        Me.lblBuscarDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbCategoria
        '
        Me.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCategoria.FormattingEnabled = True
        Me.cmbCategoria.Location = New System.Drawing.Point(87, 12)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(225, 21)
        Me.cmbCategoria.TabIndex = 259
        '
        'lblCateg
        '
        Me.lblCateg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCateg.Location = New System.Drawing.Point(10, 13)
        Me.lblCateg.Name = "lblCateg"
        Me.lblCateg.Size = New System.Drawing.Size(76, 20)
        Me.lblCateg.TabIndex = 258
        Me.lblCateg.Text = "Categoria:"
        Me.lblCateg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdVolver
        '
        Me.cmdVolver.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdVolver.Location = New System.Drawing.Point(506, 463)
        Me.cmdVolver.Name = "cmdVolver"
        Me.cmdVolver.Size = New System.Drawing.Size(115, 34)
        Me.cmdVolver.TabIndex = 266
        Me.cmdVolver.Text = "Volver"
        Me.cmdVolver.UseVisualStyleBackColor = True
        '
        'cmdSeleccionarPlanilla
        '
        Me.cmdSeleccionarPlanilla.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSeleccionarPlanilla.Location = New System.Drawing.Point(457, 27)
        Me.cmdSeleccionarPlanilla.Name = "cmdSeleccionarPlanilla"
        Me.cmdSeleccionarPlanilla.Size = New System.Drawing.Size(164, 34)
        Me.cmdSeleccionarPlanilla.TabIndex = 267
        Me.cmdSeleccionarPlanilla.Text = "Seleccionar Planilla"
        Me.cmdSeleccionarPlanilla.UseVisualStyleBackColor = True
        '
        'frmArtProdElegirPlanilla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 515)
        Me.Controls.Add(Me.cmdSeleccionarPlanilla)
        Me.Controls.Add(Me.cmdVolver)
        Me.Controls.Add(Me.dgvColorPartida)
        Me.Controls.Add(Me.dgvArticulos)
        Me.Controls.Add(Me.txtArticulo)
        Me.Controls.Add(Me.lblBuscarDesc)
        Me.Controls.Add(Me.cmbCategoria)
        Me.Controls.Add(Me.lblCateg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmArtProdElegirPlanilla"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccionar Planilla para copiar el Accesorio"
        CType(Me.dgvColorPartida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvColorPartida As System.Windows.Forms.DataGridView
    Friend WithEvents dgvArticulos As System.Windows.Forms.DataGridView
    Friend WithEvents txtArticulo As System.Windows.Forms.TextBox
    Friend WithEvents lblBuscarDesc As System.Windows.Forms.Label
    Friend WithEvents cmbCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents lblCateg As System.Windows.Forms.Label
    Friend WithEvents cmdVolver As System.Windows.Forms.Button
    Friend WithEvents cmdSeleccionarPlanilla As System.Windows.Forms.Button
End Class
