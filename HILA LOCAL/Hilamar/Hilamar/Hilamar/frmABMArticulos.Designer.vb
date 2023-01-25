<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmABMArticulos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmABMArticulos))
        Me.dgvListadoDeArticulos = New System.Windows.Forms.DataGridView()
        Me.tbBuscar = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnCrearArticulo = New System.Windows.Forms.Button()
        Me.btnModificarArticulo = New System.Windows.Forms.Button()
        Me.btnEliminarArticulo = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.cmbFiltroCategorias = New System.Windows.Forms.ComboBox()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.lblContCargas = New System.Windows.Forms.Label()
        Me.chkPuntoPedido = New System.Windows.Forms.CheckBox()
        Me.gbActividad = New System.Windows.Forms.GroupBox()
        Me.rbActivos = New System.Windows.Forms.RadioButton()
        Me.rbInactivos = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbColorIndex = New System.Windows.Forms.ComboBox()
        CType(Me.dgvListadoDeArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbActividad.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvListadoDeArticulos
        '
        Me.dgvListadoDeArticulos.AllowUserToResizeColumns = False
        Me.dgvListadoDeArticulos.AllowUserToResizeRows = False
        Me.dgvListadoDeArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListadoDeArticulos.Location = New System.Drawing.Point(13, 81)
        Me.dgvListadoDeArticulos.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvListadoDeArticulos.Name = "dgvListadoDeArticulos"
        Me.dgvListadoDeArticulos.RowHeadersVisible = False
        Me.dgvListadoDeArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListadoDeArticulos.Size = New System.Drawing.Size(1041, 510)
        Me.dgvListadoDeArticulos.TabIndex = 9
        '
        'tbBuscar
        '
        Me.tbBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBuscar.Location = New System.Drawing.Point(13, 29)
        Me.tbBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.tbBuscar.Name = "tbBuscar"
        Me.tbBuscar.Size = New System.Drawing.Size(250, 24)
        Me.tbBuscar.TabIndex = 0
        '
        'btnBuscar
        '
        Me.btnBuscar.AutoSize = True
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Tai Le", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Location = New System.Drawing.Point(1024, 14)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(150, 60)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "BUSCAR"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnCrearArticulo
        '
        Me.btnCrearArticulo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCrearArticulo.Font = New System.Drawing.Font("Microsoft Tai Le", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCrearArticulo.Location = New System.Drawing.Point(1062, 197)
        Me.btnCrearArticulo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCrearArticulo.Name = "btnCrearArticulo"
        Me.btnCrearArticulo.Size = New System.Drawing.Size(117, 62)
        Me.btnCrearArticulo.TabIndex = 5
        Me.btnCrearArticulo.Text = "CREAR"
        Me.btnCrearArticulo.UseVisualStyleBackColor = True
        '
        'btnModificarArticulo
        '
        Me.btnModificarArticulo.AutoSize = True
        Me.btnModificarArticulo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnModificarArticulo.Font = New System.Drawing.Font("Microsoft Tai Le", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModificarArticulo.Location = New System.Drawing.Point(1062, 267)
        Me.btnModificarArticulo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnModificarArticulo.Name = "btnModificarArticulo"
        Me.btnModificarArticulo.Size = New System.Drawing.Size(117, 62)
        Me.btnModificarArticulo.TabIndex = 6
        Me.btnModificarArticulo.Text = "MODIFICAR"
        Me.btnModificarArticulo.UseVisualStyleBackColor = True
        '
        'btnEliminarArticulo
        '
        Me.btnEliminarArticulo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminarArticulo.Font = New System.Drawing.Font("Microsoft Tai Le", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminarArticulo.Location = New System.Drawing.Point(1062, 337)
        Me.btnEliminarArticulo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEliminarArticulo.Name = "btnEliminarArticulo"
        Me.btnEliminarArticulo.Size = New System.Drawing.Size(117, 62)
        Me.btnEliminarArticulo.TabIndex = 7
        Me.btnEliminarArticulo.Text = "ELIMINAR"
        Me.btnEliminarArticulo.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Tai Le", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(1062, 530)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(117, 62)
        Me.btnSalir.TabIndex = 8
        Me.btnSalir.Text = "SALIR"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'cmbFiltroCategorias
        '
        Me.cmbFiltroCategorias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFiltroCategorias.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbFiltroCategorias.FormattingEnabled = True
        Me.cmbFiltroCategorias.Items.AddRange(New Object() {"Todas"})
        Me.cmbFiltroCategorias.Location = New System.Drawing.Point(271, 29)
        Me.cmbFiltroCategorias.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbFiltroCategorias.Name = "cmbFiltroCategorias"
        Me.cmbFiltroCategorias.Size = New System.Drawing.Size(250, 24)
        Me.cmbFiltroCategorias.TabIndex = 1
        Me.cmbFiltroCategorias.Text = "Todas"
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoria.ForeColor = System.Drawing.Color.DimGray
        Me.lblCategoria.Location = New System.Drawing.Point(268, 9)
        Me.lblCategoria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(67, 16)
        Me.lblCategoria.TabIndex = 1
        Me.lblCategoria.Text = "Categoría"
        '
        'lblContCargas
        '
        Me.lblContCargas.AutoSize = True
        Me.lblContCargas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContCargas.Location = New System.Drawing.Point(1036, 81)
        Me.lblContCargas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblContCargas.Name = "lblContCargas"
        Me.lblContCargas.Size = New System.Drawing.Size(18, 20)
        Me.lblContCargas.TabIndex = 7
        Me.lblContCargas.Text = "0"
        '
        'chkPuntoPedido
        '
        Me.chkPuntoPedido.AutoSize = True
        Me.chkPuntoPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPuntoPedido.Location = New System.Drawing.Point(781, 13)
        Me.chkPuntoPedido.Margin = New System.Windows.Forms.Padding(4)
        Me.chkPuntoPedido.Name = "chkPuntoPedido"
        Me.chkPuntoPedido.Size = New System.Drawing.Size(137, 20)
        Me.chkPuntoPedido.TabIndex = 3
        Me.chkPuntoPedido.Text = "< Punto de Pedido"
        Me.chkPuntoPedido.UseVisualStyleBackColor = True
        '
        'gbActividad
        '
        Me.gbActividad.Controls.Add(Me.rbActivos)
        Me.gbActividad.Controls.Add(Me.rbInactivos)
        Me.gbActividad.Location = New System.Drawing.Point(555, 13)
        Me.gbActividad.Margin = New System.Windows.Forms.Padding(4)
        Me.gbActividad.Name = "gbActividad"
        Me.gbActividad.Padding = New System.Windows.Forms.Padding(4)
        Me.gbActividad.Size = New System.Drawing.Size(173, 51)
        Me.gbActividad.TabIndex = 2
        Me.gbActividad.TabStop = False
        Me.gbActividad.Text = "Articulos"
        '
        'rbActivos
        '
        Me.rbActivos.AutoSize = True
        Me.rbActivos.Location = New System.Drawing.Point(8, 23)
        Me.rbActivos.Margin = New System.Windows.Forms.Padding(4)
        Me.rbActivos.Name = "rbActivos"
        Me.rbActivos.Size = New System.Drawing.Size(70, 20)
        Me.rbActivos.TabIndex = 0
        Me.rbActivos.TabStop = True
        Me.rbActivos.Text = "Activos"
        Me.rbActivos.UseVisualStyleBackColor = True
        '
        'rbInactivos
        '
        Me.rbInactivos.AutoSize = True
        Me.rbInactivos.Location = New System.Drawing.Point(86, 23)
        Me.rbInactivos.Margin = New System.Windows.Forms.Padding(4)
        Me.rbInactivos.Name = "rbInactivos"
        Me.rbInactivos.Size = New System.Drawing.Size(79, 20)
        Me.rbInactivos.TabIndex = 1
        Me.rbInactivos.TabStop = True
        Me.rbInactivos.Text = "Inactivos"
        Me.rbInactivos.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(13, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Buscar"
        '
        'cmbColorIndex
        '
        Me.cmbColorIndex.FormattingEnabled = True
        Me.cmbColorIndex.Location = New System.Drawing.Point(781, 42)
        Me.cmbColorIndex.Name = "cmbColorIndex"
        Me.cmbColorIndex.Size = New System.Drawing.Size(137, 24)
        Me.cmbColorIndex.TabIndex = 12
        Me.cmbColorIndex.Text = "Color Index"
        '
        'frmABMArticulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1187, 604)
        Me.Controls.Add(Me.cmbColorIndex)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gbActividad)
        Me.Controls.Add(Me.chkPuntoPedido)
        Me.Controls.Add(Me.lblContCargas)
        Me.Controls.Add(Me.lblCategoria)
        Me.Controls.Add(Me.cmbFiltroCategorias)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnEliminarArticulo)
        Me.Controls.Add(Me.btnModificarArticulo)
        Me.Controls.Add(Me.btnCrearArticulo)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.tbBuscar)
        Me.Controls.Add(Me.dgvListadoDeArticulos)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmABMArticulos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM Artículos"
        CType(Me.dgvListadoDeArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbActividad.ResumeLayout(False)
        Me.gbActividad.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvListadoDeArticulos As System.Windows.Forms.DataGridView
    Friend WithEvents tbBuscar As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnCrearArticulo As System.Windows.Forms.Button
    Friend WithEvents btnModificarArticulo As System.Windows.Forms.Button
    Friend WithEvents btnEliminarArticulo As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents lblCategoria As System.Windows.Forms.Label
    Friend WithEvents cmbFiltroCategorias As System.Windows.Forms.ComboBox
    Friend WithEvents lblContCargas As System.Windows.Forms.Label
    Friend WithEvents chkPuntoPedido As System.Windows.Forms.CheckBox
    Friend WithEvents gbActividad As System.Windows.Forms.GroupBox
    Friend WithEvents rbInactivos As System.Windows.Forms.RadioButton
    Friend WithEvents rbActivos As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbColorIndex As System.Windows.Forms.ComboBox
End Class
