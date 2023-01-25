<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArtProdListado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArtProdListado))
        Me.cmdVolver = New System.Windows.Forms.Button()
        Me.cmbCategoria = New System.Windows.Forms.ComboBox()
        Me.lblCateg = New System.Windows.Forms.Label()
        Me.txtArticulo = New System.Windows.Forms.TextBox()
        Me.lblBuscarDesc = New System.Windows.Forms.Label()
        Me.txtColor = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdVerPlanilla = New System.Windows.Forms.Button()
        Me.dgvArticulos = New System.Windows.Forms.DataGridView()
        Me.dgvColorPartida = New System.Windows.Forms.DataGridView()
        Me.dgvAccesorios = New System.Windows.Forms.DataGridView()
        Me.cmdVerAccesorio = New System.Windows.Forms.Button()
        CType(Me.dgvArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvColorPartida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAccesorios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdVolver
        '
        Me.cmdVolver.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdVolver.Location = New System.Drawing.Point(852, 460)
        Me.cmdVolver.Name = "cmdVolver"
        Me.cmdVolver.Size = New System.Drawing.Size(115, 34)
        Me.cmdVolver.TabIndex = 9
        Me.cmdVolver.Text = "Volver"
        Me.cmdVolver.UseVisualStyleBackColor = True
        '
        'cmbCategoria
        '
        Me.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCategoria.FormattingEnabled = True
        Me.cmbCategoria.Location = New System.Drawing.Point(83, 12)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(225, 21)
        Me.cmbCategoria.TabIndex = 248
        '
        'lblCateg
        '
        Me.lblCateg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCateg.Location = New System.Drawing.Point(6, 13)
        Me.lblCateg.Name = "lblCateg"
        Me.lblCateg.Size = New System.Drawing.Size(76, 20)
        Me.lblCateg.TabIndex = 247
        Me.lblCateg.Text = "Categoria:"
        Me.lblCateg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtArticulo
        '
        Me.txtArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArticulo.Location = New System.Drawing.Point(83, 51)
        Me.txtArticulo.Name = "txtArticulo"
        Me.txtArticulo.Size = New System.Drawing.Size(99, 21)
        Me.txtArticulo.TabIndex = 251
        '
        'lblBuscarDesc
        '
        Me.lblBuscarDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBuscarDesc.Location = New System.Drawing.Point(7, 51)
        Me.lblBuscarDesc.Name = "lblBuscarDesc"
        Me.lblBuscarDesc.Size = New System.Drawing.Size(70, 23)
        Me.lblBuscarDesc.TabIndex = 250
        Me.lblBuscarDesc.Text = "Artículo:"
        Me.lblBuscarDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtColor
        '
        Me.txtColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColor.Location = New System.Drawing.Point(321, 51)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Size = New System.Drawing.Size(159, 21)
        Me.txtColor.TabIndex = 254
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(259, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 23)
        Me.Label1.TabIndex = 253
        Me.Label1.Text = "Color:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdVerPlanilla
        '
        Me.cmdVerPlanilla.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdVerPlanilla.Location = New System.Drawing.Point(516, 38)
        Me.cmdVerPlanilla.Name = "cmdVerPlanilla"
        Me.cmdVerPlanilla.Size = New System.Drawing.Size(115, 34)
        Me.cmdVerPlanilla.TabIndex = 255
        Me.cmdVerPlanilla.Text = "Ver Planilla"
        Me.cmdVerPlanilla.UseVisualStyleBackColor = True
        '
        'dgvArticulos
        '
        Me.dgvArticulos.AllowUserToAddRows = False
        Me.dgvArticulos.AllowUserToDeleteRows = False
        Me.dgvArticulos.AllowUserToResizeColumns = False
        Me.dgvArticulos.AllowUserToResizeRows = False
        Me.dgvArticulos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArticulos.Location = New System.Drawing.Point(12, 78)
        Me.dgvArticulos.Name = "dgvArticulos"
        Me.dgvArticulos.ReadOnly = True
        Me.dgvArticulos.RowHeadersVisible = False
        Me.dgvArticulos.RowHeadersWidth = 31
        Me.dgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvArticulos.Size = New System.Drawing.Size(242, 366)
        Me.dgvArticulos.TabIndex = 256
        '
        'dgvColorPartida
        '
        Me.dgvColorPartida.AllowUserToAddRows = False
        Me.dgvColorPartida.AllowUserToDeleteRows = False
        Me.dgvColorPartida.AllowUserToResizeColumns = False
        Me.dgvColorPartida.AllowUserToResizeRows = False
        Me.dgvColorPartida.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvColorPartida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvColorPartida.Location = New System.Drawing.Point(260, 78)
        Me.dgvColorPartida.Name = "dgvColorPartida"
        Me.dgvColorPartida.ReadOnly = True
        Me.dgvColorPartida.RowHeadersVisible = False
        Me.dgvColorPartida.RowHeadersWidth = 31
        Me.dgvColorPartida.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvColorPartida.Size = New System.Drawing.Size(380, 366)
        Me.dgvColorPartida.TabIndex = 257
        '
        'dgvAccesorios
        '
        Me.dgvAccesorios.AllowUserToAddRows = False
        Me.dgvAccesorios.AllowUserToDeleteRows = False
        Me.dgvAccesorios.AllowUserToResizeColumns = False
        Me.dgvAccesorios.AllowUserToResizeRows = False
        Me.dgvAccesorios.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvAccesorios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAccesorios.Location = New System.Drawing.Point(646, 78)
        Me.dgvAccesorios.Name = "dgvAccesorios"
        Me.dgvAccesorios.ReadOnly = True
        Me.dgvAccesorios.RowHeadersVisible = False
        Me.dgvAccesorios.RowHeadersWidth = 31
        Me.dgvAccesorios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAccesorios.Size = New System.Drawing.Size(342, 366)
        Me.dgvAccesorios.TabIndex = 258
        '
        'cmdVerAccesorio
        '
        Me.cmdVerAccesorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdVerAccesorio.Location = New System.Drawing.Point(852, 38)
        Me.cmdVerAccesorio.Name = "cmdVerAccesorio"
        Me.cmdVerAccesorio.Size = New System.Drawing.Size(115, 34)
        Me.cmdVerAccesorio.TabIndex = 259
        Me.cmdVerAccesorio.Text = "Ver Accesorio"
        Me.cmdVerAccesorio.UseVisualStyleBackColor = True
        '
        'frmArtProdListado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 506)
        Me.Controls.Add(Me.cmdVerAccesorio)
        Me.Controls.Add(Me.dgvAccesorios)
        Me.Controls.Add(Me.dgvColorPartida)
        Me.Controls.Add(Me.dgvArticulos)
        Me.Controls.Add(Me.cmdVerPlanilla)
        Me.Controls.Add(Me.txtColor)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtArticulo)
        Me.Controls.Add(Me.lblBuscarDesc)
        Me.Controls.Add(Me.cmbCategoria)
        Me.Controls.Add(Me.lblCateg)
        Me.Controls.Add(Me.cmdVolver)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmArtProdListado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado de Artículos en Producción"
        CType(Me.dgvArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvColorPartida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAccesorios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdVolver As System.Windows.Forms.Button
    Friend WithEvents cmbCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents lblCateg As System.Windows.Forms.Label
    Friend WithEvents txtArticulo As System.Windows.Forms.TextBox
    Friend WithEvents lblBuscarDesc As System.Windows.Forms.Label
    Friend WithEvents txtColor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdVerPlanilla As System.Windows.Forms.Button
    Friend WithEvents dgvArticulos As System.Windows.Forms.DataGridView
    Friend WithEvents dgvColorPartida As System.Windows.Forms.DataGridView
    Friend WithEvents dgvAccesorios As System.Windows.Forms.DataGridView
    Friend WithEvents cmdVerAccesorio As System.Windows.Forms.Button
End Class
