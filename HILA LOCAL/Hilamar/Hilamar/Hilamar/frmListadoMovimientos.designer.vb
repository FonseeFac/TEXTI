<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListadoMovimientos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListadoMovimientos))
        Me.gbFiltros = New System.Windows.Forms.GroupBox()
        Me.gbBuscador = New System.Windows.Forms.GroupBox()
        Me.txtBuscador = New System.Windows.Forms.TextBox()
        Me.gbProveedor = New System.Windows.Forms.GroupBox()
        Me.cbProveedor = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gbFiltroArticulo = New System.Windows.Forms.GroupBox()
        Me.cbCategoria = New System.Windows.Forms.ComboBox()
        Me.cbArticulo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbTipoMovimiento = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbFiltroFechas = New System.Windows.Forms.GroupBox()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.btnPrueba = New System.Windows.Forms.Button()
        Me.gbMovimientos = New System.Windows.Forms.GroupBox()
        Me.dgvMovimientos = New System.Windows.Forms.DataGridView()
        Me.gbDetalleMovimiento = New System.Windows.Forms.GroupBox()
        Me.dgvDetalleMovimiento = New System.Windows.Forms.DataGridView()
        Me.gbFiltros.SuspendLayout()
        Me.gbBuscador.SuspendLayout()
        Me.gbProveedor.SuspendLayout()
        Me.gbFiltroArticulo.SuspendLayout()
        Me.gbFiltroFechas.SuspendLayout()
        Me.gbMovimientos.SuspendLayout()
        CType(Me.dgvMovimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDetalleMovimiento.SuspendLayout()
        CType(Me.dgvDetalleMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbFiltros
        '
        Me.gbFiltros.Controls.Add(Me.gbBuscador)
        Me.gbFiltros.Controls.Add(Me.gbProveedor)
        Me.gbFiltros.Controls.Add(Me.gbFiltroArticulo)
        Me.gbFiltros.Controls.Add(Me.cbTipoMovimiento)
        Me.gbFiltros.Controls.Add(Me.Label2)
        Me.gbFiltros.Controls.Add(Me.gbFiltroFechas)
        Me.gbFiltros.Location = New System.Drawing.Point(13, 13)
        Me.gbFiltros.Margin = New System.Windows.Forms.Padding(4)
        Me.gbFiltros.Name = "gbFiltros"
        Me.gbFiltros.Padding = New System.Windows.Forms.Padding(4)
        Me.gbFiltros.Size = New System.Drawing.Size(1110, 117)
        Me.gbFiltros.TabIndex = 0
        Me.gbFiltros.TabStop = False
        Me.gbFiltros.Text = "Filtros"
        '
        'gbBuscador
        '
        Me.gbBuscador.Controls.Add(Me.txtBuscador)
        Me.gbBuscador.Location = New System.Drawing.Point(903, 22)
        Me.gbBuscador.Name = "gbBuscador"
        Me.gbBuscador.Size = New System.Drawing.Size(200, 58)
        Me.gbBuscador.TabIndex = 40
        Me.gbBuscador.TabStop = False
        Me.gbBuscador.Text = "Buscador"
        '
        'txtBuscador
        '
        Me.txtBuscador.Location = New System.Drawing.Point(7, 22)
        Me.txtBuscador.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBuscador.Name = "txtBuscador"
        Me.txtBuscador.Size = New System.Drawing.Size(186, 22)
        Me.txtBuscador.TabIndex = 3
        '
        'gbProveedor
        '
        Me.gbProveedor.Controls.Add(Me.cbProveedor)
        Me.gbProveedor.Controls.Add(Me.Label7)
        Me.gbProveedor.Location = New System.Drawing.Point(170, 54)
        Me.gbProveedor.Name = "gbProveedor"
        Me.gbProveedor.Size = New System.Drawing.Size(260, 53)
        Me.gbProveedor.TabIndex = 39
        Me.gbProveedor.TabStop = False
        Me.gbProveedor.Text = "Proveedor"
        '
        'cbProveedor
        '
        Me.cbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbProveedor.FormattingEnabled = True
        Me.cbProveedor.Location = New System.Drawing.Point(75, 22)
        Me.cbProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.cbProveedor.Name = "cbProveedor"
        Me.cbProveedor.Size = New System.Drawing.Size(178, 24)
        Me.cbProveedor.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 25)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 16)
        Me.Label7.TabIndex = 38
        Me.Label7.Text = "Nombre:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbFiltroArticulo
        '
        Me.gbFiltroArticulo.Controls.Add(Me.cbCategoria)
        Me.gbFiltroArticulo.Controls.Add(Me.cbArticulo)
        Me.gbFiltroArticulo.Controls.Add(Me.Label3)
        Me.gbFiltroArticulo.Controls.Add(Me.Label6)
        Me.gbFiltroArticulo.Location = New System.Drawing.Point(447, 22)
        Me.gbFiltroArticulo.Name = "gbFiltroArticulo"
        Me.gbFiltroArticulo.Size = New System.Drawing.Size(300, 88)
        Me.gbFiltroArticulo.TabIndex = 37
        Me.gbFiltroArticulo.TabStop = False
        Me.gbFiltroArticulo.Text = "Artículo"
        '
        'cbCategoria
        '
        Me.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCategoria.FormattingEnabled = True
        Me.cbCategoria.Location = New System.Drawing.Point(85, 22)
        Me.cbCategoria.Margin = New System.Windows.Forms.Padding(4)
        Me.cbCategoria.Name = "cbCategoria"
        Me.cbCategoria.Size = New System.Drawing.Size(175, 24)
        Me.cbCategoria.TabIndex = 0
        '
        'cbArticulo
        '
        Me.cbArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbArticulo.FormattingEnabled = True
        Me.cbArticulo.Location = New System.Drawing.Point(85, 54)
        Me.cbArticulo.Margin = New System.Windows.Forms.Padding(4)
        Me.cbArticulo.Name = "cbArticulo"
        Me.cbArticulo.Size = New System.Drawing.Size(208, 24)
        Me.cbArticulo.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 57)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Artículo:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 25)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Categoría:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbTipoMovimiento
        '
        Me.cbTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoMovimiento.FormattingEnabled = True
        Me.cbTipoMovimiento.Location = New System.Drawing.Point(309, 23)
        Me.cbTipoMovimiento.Margin = New System.Windows.Forms.Padding(4)
        Me.cbTipoMovimiento.Name = "cbTipoMovimiento"
        Me.cbTipoMovimiento.Size = New System.Drawing.Size(131, 24)
        Me.cbTipoMovimiento.TabIndex = 35
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(171, 26)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 16)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Tipo de Movimiento:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbFiltroFechas
        '
        Me.gbFiltroFechas.Controls.Add(Me.dtpFechaDesde)
        Me.gbFiltroFechas.Controls.Add(Me.Label1)
        Me.gbFiltroFechas.Controls.Add(Me.Label4)
        Me.gbFiltroFechas.Controls.Add(Me.dtpFechaHasta)
        Me.gbFiltroFechas.Location = New System.Drawing.Point(7, 22)
        Me.gbFiltroFechas.Name = "gbFiltroFechas"
        Me.gbFiltroFechas.Size = New System.Drawing.Size(157, 77)
        Me.gbFiltroFechas.TabIndex = 34
        Me.gbFiltroFechas.TabStop = False
        Me.gbFiltroFechas.Text = "Fechas"
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(66, 21)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(85, 22)
        Me.dtpFechaDesde.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 54)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 16)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Hasta:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 26)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 16)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Desde:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(66, 49)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(85, 22)
        Me.dtpFechaHasta.TabIndex = 32
        '
        'btnPrueba
        '
        Me.btnPrueba.AutoSize = True
        Me.btnPrueba.Location = New System.Drawing.Point(1050, 450)
        Me.btnPrueba.Name = "btnPrueba"
        Me.btnPrueba.Size = New System.Drawing.Size(74, 26)
        Me.btnPrueba.TabIndex = 3
        Me.btnPrueba.Text = "PRUEBA"
        Me.btnPrueba.UseVisualStyleBackColor = True
        '
        'gbMovimientos
        '
        Me.gbMovimientos.Controls.Add(Me.dgvMovimientos)
        Me.gbMovimientos.Location = New System.Drawing.Point(12, 137)
        Me.gbMovimientos.Name = "gbMovimientos"
        Me.gbMovimientos.Size = New System.Drawing.Size(555, 339)
        Me.gbMovimientos.TabIndex = 2
        Me.gbMovimientos.TabStop = False
        Me.gbMovimientos.Text = "Movimientos"
        '
        'dgvMovimientos
        '
        Me.dgvMovimientos.AllowUserToAddRows = False
        Me.dgvMovimientos.AllowUserToDeleteRows = False
        Me.dgvMovimientos.AllowUserToResizeColumns = False
        Me.dgvMovimientos.AllowUserToResizeRows = False
        Me.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMovimientos.Location = New System.Drawing.Point(6, 21)
        Me.dgvMovimientos.MultiSelect = False
        Me.dgvMovimientos.Name = "dgvMovimientos"
        Me.dgvMovimientos.ReadOnly = True
        Me.dgvMovimientos.RowHeadersVisible = False
        Me.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMovimientos.Size = New System.Drawing.Size(543, 312)
        Me.dgvMovimientos.TabIndex = 0
        '
        'gbDetalleMovimiento
        '
        Me.gbDetalleMovimiento.Controls.Add(Me.dgvDetalleMovimiento)
        Me.gbDetalleMovimiento.Location = New System.Drawing.Point(573, 137)
        Me.gbDetalleMovimiento.Name = "gbDetalleMovimiento"
        Me.gbDetalleMovimiento.Size = New System.Drawing.Size(551, 287)
        Me.gbDetalleMovimiento.TabIndex = 3
        Me.gbDetalleMovimiento.TabStop = False
        Me.gbDetalleMovimiento.Text = "Detalle"
        '
        'dgvDetalleMovimiento
        '
        Me.dgvDetalleMovimiento.AllowUserToAddRows = False
        Me.dgvDetalleMovimiento.AllowUserToDeleteRows = False
        Me.dgvDetalleMovimiento.AllowUserToResizeColumns = False
        Me.dgvDetalleMovimiento.AllowUserToResizeRows = False
        Me.dgvDetalleMovimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleMovimiento.Location = New System.Drawing.Point(6, 21)
        Me.dgvDetalleMovimiento.MultiSelect = False
        Me.dgvDetalleMovimiento.Name = "dgvDetalleMovimiento"
        Me.dgvDetalleMovimiento.ReadOnly = True
        Me.dgvDetalleMovimiento.RowHeadersVisible = False
        Me.dgvDetalleMovimiento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalleMovimiento.Size = New System.Drawing.Size(539, 260)
        Me.dgvDetalleMovimiento.TabIndex = 0
        '
        'frmListadoMovimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1136, 489)
        Me.Controls.Add(Me.gbDetalleMovimiento)
        Me.Controls.Add(Me.gbMovimientos)
        Me.Controls.Add(Me.gbFiltros)
        Me.Controls.Add(Me.btnPrueba)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "frmListadoMovimientos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado Movimientos"
        Me.gbFiltros.ResumeLayout(False)
        Me.gbFiltros.PerformLayout()
        Me.gbBuscador.ResumeLayout(False)
        Me.gbBuscador.PerformLayout()
        Me.gbProveedor.ResumeLayout(False)
        Me.gbProveedor.PerformLayout()
        Me.gbFiltroArticulo.ResumeLayout(False)
        Me.gbFiltroArticulo.PerformLayout()
        Me.gbFiltroFechas.ResumeLayout(False)
        Me.gbFiltroFechas.PerformLayout()
        Me.gbMovimientos.ResumeLayout(False)
        CType(Me.dgvMovimientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDetalleMovimiento.ResumeLayout(False)
        CType(Me.dgvDetalleMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gbMovimientos As System.Windows.Forms.GroupBox
    Friend WithEvents dgvMovimientos As System.Windows.Forms.DataGridView
    Friend WithEvents btnPrueba As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents gbDetalleMovimiento As System.Windows.Forms.GroupBox
    Friend WithEvents dgvDetalleMovimiento As System.Windows.Forms.DataGridView
    Friend WithEvents gbFiltroArticulo As System.Windows.Forms.GroupBox
    Friend WithEvents cbTipoMovimiento As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gbFiltroFechas As System.Windows.Forms.GroupBox
    Friend WithEvents cbCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents cbArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents gbProveedor As System.Windows.Forms.GroupBox
    Friend WithEvents gbBuscador As System.Windows.Forms.GroupBox
    Friend WithEvents txtBuscador As System.Windows.Forms.TextBox
End Class
