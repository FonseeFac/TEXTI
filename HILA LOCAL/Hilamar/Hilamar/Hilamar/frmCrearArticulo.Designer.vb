<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCrearArticulo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCrearArticulo))
        Me.tbNombreArticulo = New System.Windows.Forms.TextBox()
        Me.tbStockInicialHilamar = New System.Windows.Forms.TextBox()
        Me.cmbCategoria = New System.Windows.Forms.ComboBox()
        Me.cmbTipoDeUnidad = New System.Windows.Forms.ComboBox()
        Me.tbPuntoPedido = New System.Windows.Forms.TextBox()
        Me.tbObservación = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblInicialHila = New System.Windows.Forms.Label()
        Me.lblPuntoPedido = New System.Windows.Forms.Label()
        Me.lblCategorias = New System.Windows.Forms.Label()
        Me.lblUnidadMedida = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lbltotal = New System.Windows.Forms.Label()
        Me.lblStockTotal = New System.Windows.Forms.Label()
        Me.chkInactivo = New System.Windows.Forms.CheckBox()
        Me.btnModificarProveedores = New System.Windows.Forms.Button()
        Me.dgvProveedores = New System.Windows.Forms.DataGridView()
        Me.gbProveedores = New System.Windows.Forms.GroupBox()
        Me.gbObservaciones = New System.Windows.Forms.GroupBox()
        Me.gbIndexColor = New System.Windows.Forms.GroupBox()
        Me.cmbIndex = New System.Windows.Forms.ComboBox()
        CType(Me.dgvProveedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProveedores.SuspendLayout()
        Me.gbObservaciones.SuspendLayout()
        Me.gbIndexColor.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbNombreArticulo
        '
        Me.tbNombreArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNombreArticulo.Location = New System.Drawing.Point(13, 29)
        Me.tbNombreArticulo.Margin = New System.Windows.Forms.Padding(4)
        Me.tbNombreArticulo.Name = "tbNombreArticulo"
        Me.tbNombreArticulo.Size = New System.Drawing.Size(300, 22)
        Me.tbNombreArticulo.TabIndex = 0
        '
        'tbStockInicialHilamar
        '
        Me.tbStockInicialHilamar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStockInicialHilamar.Location = New System.Drawing.Point(153, 87)
        Me.tbStockInicialHilamar.Margin = New System.Windows.Forms.Padding(4)
        Me.tbStockInicialHilamar.Name = "tbStockInicialHilamar"
        Me.tbStockInicialHilamar.Size = New System.Drawing.Size(77, 22)
        Me.tbStockInicialHilamar.TabIndex = 1
        '
        'cmbCategoria
        '
        Me.cmbCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCategoria.FormattingEnabled = True
        Me.cmbCategoria.Location = New System.Drawing.Point(321, 29)
        Me.cmbCategoria.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(300, 24)
        Me.cmbCategoria.TabIndex = 3
        Me.cmbCategoria.Text = " Seleccione una categoría"
        '
        'cmbTipoDeUnidad
        '
        Me.cmbTipoDeUnidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoDeUnidad.FormattingEnabled = True
        Me.cmbTipoDeUnidad.Location = New System.Drawing.Point(321, 87)
        Me.cmbTipoDeUnidad.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbTipoDeUnidad.Name = "cmbTipoDeUnidad"
        Me.cmbTipoDeUnidad.Size = New System.Drawing.Size(300, 24)
        Me.cmbTipoDeUnidad.TabIndex = 4
        Me.cmbTipoDeUnidad.Text = " Seleccione una Unidad"
        '
        'tbPuntoPedido
        '
        Me.tbPuntoPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPuntoPedido.Location = New System.Drawing.Point(153, 122)
        Me.tbPuntoPedido.Margin = New System.Windows.Forms.Padding(4)
        Me.tbPuntoPedido.Name = "tbPuntoPedido"
        Me.tbPuntoPedido.Size = New System.Drawing.Size(77, 22)
        Me.tbPuntoPedido.TabIndex = 5
        '
        'tbObservación
        '
        Me.tbObservación.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbObservación.Location = New System.Drawing.Point(7, 22)
        Me.tbObservación.Margin = New System.Windows.Forms.Padding(4)
        Me.tbObservación.MaxLength = 250
        Me.tbObservación.Multiline = True
        Me.tbObservación.Name = "tbObservación"
        Me.tbObservación.Size = New System.Drawing.Size(287, 147)
        Me.tbObservación.TabIndex = 6
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(13, 9)
        Me.lblNombre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(149, 16)
        Me.lblNombre.TabIndex = 7
        Me.lblNombre.Text = "Nombre del Artículo:"
        '
        'lblInicialHila
        '
        Me.lblInicialHila.AutoSize = True
        Me.lblInicialHila.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInicialHila.Location = New System.Drawing.Point(13, 90)
        Me.lblInicialHila.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInicialHila.Name = "lblInicialHila"
        Me.lblInicialHila.Size = New System.Drawing.Size(132, 16)
        Me.lblInicialHila.TabIndex = 8
        Me.lblInicialHila.Text = "Stock Inicial Hilamar:"
        '
        'lblPuntoPedido
        '
        Me.lblPuntoPedido.AutoSize = True
        Me.lblPuntoPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPuntoPedido.Location = New System.Drawing.Point(35, 125)
        Me.lblPuntoPedido.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPuntoPedido.Name = "lblPuntoPedido"
        Me.lblPuntoPedido.Size = New System.Drawing.Size(110, 16)
        Me.lblPuntoPedido.TabIndex = 10
        Me.lblPuntoPedido.Text = "Punto de pedido:"
        '
        'lblCategorias
        '
        Me.lblCategorias.AutoSize = True
        Me.lblCategorias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategorias.Location = New System.Drawing.Point(318, 9)
        Me.lblCategorias.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCategorias.Name = "lblCategorias"
        Me.lblCategorias.Size = New System.Drawing.Size(70, 16)
        Me.lblCategorias.TabIndex = 11
        Me.lblCategorias.Text = "Categoría:"
        '
        'lblUnidadMedida
        '
        Me.lblUnidadMedida.AutoSize = True
        Me.lblUnidadMedida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnidadMedida.Location = New System.Drawing.Point(318, 67)
        Me.lblUnidadMedida.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUnidadMedida.Name = "lblUnidadMedida"
        Me.lblUnidadMedida.Size = New System.Drawing.Size(123, 16)
        Me.lblUnidadMedida.TabIndex = 12
        Me.lblUnidadMedida.Text = "Unidad de Medida:"
        '
        'btnGuardar
        '
        Me.btnGuardar.AutoSize = True
        Me.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Tai Le", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Location = New System.Drawing.Point(250, 358)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(150, 50)
        Me.btnGuardar.TabIndex = 14
        Me.btnGuardar.Text = "GUARDAR"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.AutoSize = True
        Me.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Tai Le", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(521, 358)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(100, 50)
        Me.btnSalir.TabIndex = 15
        Me.btnSalir.Text = "SALIR"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'lbltotal
        '
        Me.lbltotal.AutoSize = True
        Me.lbltotal.Font = New System.Drawing.Font("Microsoft Tai Le", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotal.Location = New System.Drawing.Point(13, 373)
        Me.lbltotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(56, 21)
        Me.lbltotal.TabIndex = 16
        Me.lbltotal.Text = "Stock:"
        Me.lbltotal.Visible = False
        '
        'lblStockTotal
        '
        Me.lblStockTotal.AutoSize = True
        Me.lblStockTotal.Font = New System.Drawing.Font("Microsoft Tai Le", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockTotal.Location = New System.Drawing.Point(77, 371)
        Me.lblStockTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStockTotal.Name = "lblStockTotal"
        Me.lblStockTotal.Size = New System.Drawing.Size(21, 23)
        Me.lblStockTotal.TabIndex = 17
        Me.lblStockTotal.Text = "0"
        Me.lblStockTotal.Visible = False
        '
        'chkInactivo
        '
        Me.chkInactivo.AutoSize = True
        Me.chkInactivo.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.chkInactivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkInactivo.Location = New System.Drawing.Point(551, 122)
        Me.chkInactivo.Margin = New System.Windows.Forms.Padding(4)
        Me.chkInactivo.Name = "chkInactivo"
        Me.chkInactivo.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkInactivo.Size = New System.Drawing.Size(70, 24)
        Me.chkInactivo.TabIndex = 18
        Me.chkInactivo.Text = "Activo"
        Me.chkInactivo.UseVisualStyleBackColor = False
        Me.chkInactivo.Visible = False
        '
        'btnModificarProveedores
        '
        Me.btnModificarProveedores.AutoSize = True
        Me.btnModificarProveedores.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnModificarProveedores.Font = New System.Drawing.Font("Microsoft Tai Le", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModificarProveedores.Location = New System.Drawing.Point(105, 143)
        Me.btnModificarProveedores.Margin = New System.Windows.Forms.Padding(4)
        Me.btnModificarProveedores.Name = "btnModificarProveedores"
        Me.btnModificarProveedores.Size = New System.Drawing.Size(90, 26)
        Me.btnModificarProveedores.TabIndex = 21
        Me.btnModificarProveedores.Text = "MODIFICAR"
        Me.btnModificarProveedores.UseVisualStyleBackColor = True
        '
        'dgvProveedores
        '
        Me.dgvProveedores.AllowUserToAddRows = False
        Me.dgvProveedores.AllowUserToDeleteRows = False
        Me.dgvProveedores.AllowUserToResizeColumns = False
        Me.dgvProveedores.AllowUserToResizeRows = False
        Me.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProveedores.ColumnHeadersVisible = False
        Me.dgvProveedores.Location = New System.Drawing.Point(7, 22)
        Me.dgvProveedores.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvProveedores.Name = "dgvProveedores"
        Me.dgvProveedores.RowHeadersVisible = False
        Me.dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProveedores.Size = New System.Drawing.Size(287, 113)
        Me.dgvProveedores.TabIndex = 22
        '
        'gbProveedores
        '
        Me.gbProveedores.Controls.Add(Me.dgvProveedores)
        Me.gbProveedores.Controls.Add(Me.btnModificarProveedores)
        Me.gbProveedores.Location = New System.Drawing.Point(13, 175)
        Me.gbProveedores.Name = "gbProveedores"
        Me.gbProveedores.Size = New System.Drawing.Size(301, 176)
        Me.gbProveedores.TabIndex = 23
        Me.gbProveedores.TabStop = False
        Me.gbProveedores.Text = "Proveedores"
        '
        'gbObservaciones
        '
        Me.gbObservaciones.Controls.Add(Me.tbObservación)
        Me.gbObservaciones.Location = New System.Drawing.Point(320, 175)
        Me.gbObservaciones.Name = "gbObservaciones"
        Me.gbObservaciones.Size = New System.Drawing.Size(301, 176)
        Me.gbObservaciones.TabIndex = 24
        Me.gbObservaciones.TabStop = False
        Me.gbObservaciones.Text = "Observaciones"
        '
        'gbIndexColor
        '
        Me.gbIndexColor.Controls.Add(Me.cmbIndex)
        Me.gbIndexColor.Location = New System.Drawing.Point(321, 118)
        Me.gbIndexColor.Name = "gbIndexColor"
        Me.gbIndexColor.Size = New System.Drawing.Size(212, 56)
        Me.gbIndexColor.TabIndex = 27
        Me.gbIndexColor.TabStop = False
        Me.gbIndexColor.Text = "INDEX"
        '
        'cmbIndex
        '
        Me.cmbIndex.FormattingEnabled = True
        Me.cmbIndex.Location = New System.Drawing.Point(7, 22)
        Me.cmbIndex.Name = "cmbIndex"
        Me.cmbIndex.Size = New System.Drawing.Size(199, 24)
        Me.cmbIndex.TabIndex = 0
        '
        'frmCrearArticulo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 421)
        Me.Controls.Add(Me.gbIndexColor)
        Me.Controls.Add(Me.gbObservaciones)
        Me.Controls.Add(Me.gbProveedores)
        Me.Controls.Add(Me.chkInactivo)
        Me.Controls.Add(Me.lblStockTotal)
        Me.Controls.Add(Me.lbltotal)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.lblUnidadMedida)
        Me.Controls.Add(Me.lblCategorias)
        Me.Controls.Add(Me.lblPuntoPedido)
        Me.Controls.Add(Me.lblInicialHila)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.tbPuntoPedido)
        Me.Controls.Add(Me.cmbTipoDeUnidad)
        Me.Controls.Add(Me.cmbCategoria)
        Me.Controls.Add(Me.tbStockInicialHilamar)
        Me.Controls.Add(Me.tbNombreArticulo)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmCrearArticulo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crear Articulo"
        CType(Me.dgvProveedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProveedores.ResumeLayout(False)
        Me.gbProveedores.PerformLayout()
        Me.gbObservaciones.ResumeLayout(False)
        Me.gbObservaciones.PerformLayout()
        Me.gbIndexColor.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbNombreArticulo As System.Windows.Forms.TextBox
    Friend WithEvents tbStockInicialHilamar As System.Windows.Forms.TextBox
    Friend WithEvents cmbCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTipoDeUnidad As System.Windows.Forms.ComboBox
    Friend WithEvents tbPuntoPedido As System.Windows.Forms.TextBox
    Friend WithEvents tbObservación As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblInicialHila As System.Windows.Forms.Label
    Friend WithEvents lblPuntoPedido As System.Windows.Forms.Label
    Friend WithEvents lblCategorias As System.Windows.Forms.Label
    Friend WithEvents lblUnidadMedida As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents lbltotal As System.Windows.Forms.Label
    Friend WithEvents lblStockTotal As System.Windows.Forms.Label
    Friend WithEvents chkInactivo As System.Windows.Forms.CheckBox
    Friend WithEvents btnModificarProveedores As System.Windows.Forms.Button
    Friend WithEvents dgvProveedores As System.Windows.Forms.DataGridView
    Friend WithEvents gbProveedores As System.Windows.Forms.GroupBox
    Friend WithEvents gbObservaciones As System.Windows.Forms.GroupBox
    Friend WithEvents gbIndexColor As System.Windows.Forms.GroupBox
    Friend WithEvents cmbIndex As System.Windows.Forms.ComboBox
End Class
