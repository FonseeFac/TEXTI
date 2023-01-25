<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAltaReserva
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAltaReserva))
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.btnPrueba = New System.Windows.Forms.Button()
        Me.cbTipoComprobante = New System.Windows.Forms.ComboBox()
        Me.txtNroComprobante = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.dtpFechaIngreso = New System.Windows.Forms.DateTimePicker()
        Me.lblDescCodigo = New System.Windows.Forms.Label()
        Me.gbMovimiento = New System.Windows.Forms.GroupBox()
        Me.lblStockActual = New System.Windows.Forms.Label()
        Me.lblUnidadDeMedida = New System.Windows.Forms.Label()
        Me.txtCantidadIngresada = New System.Windows.Forms.TextBox()
        Me.btnCancelarDetalle = New System.Windows.Forms.Button()
        Me.btnGuardarDetalle = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbCategoria = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbArticulo = New System.Windows.Forms.ComboBox()
        Me.gbDetalleMovimiento = New System.Windows.Forms.GroupBox()
        Me.btnEliminarFilaDetalle = New System.Windows.Forms.Button()
        Me.btnConfirmarMovimiento = New System.Windows.Forms.Button()
        Me.dgvDetalleMovimiento = New System.Windows.Forms.DataGridView()
        Me.gbDatos.SuspendLayout()
        Me.gbMovimiento.SuspendLayout()
        Me.gbDetalleMovimiento.SuspendLayout()
        CType(Me.dgvDetalleMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbDatos
        '
        Me.gbDatos.Controls.Add(Me.btnPrueba)
        Me.gbDatos.Controls.Add(Me.cbTipoComprobante)
        Me.gbDatos.Controls.Add(Me.txtNroComprobante)
        Me.gbDatos.Controls.Add(Me.Label5)
        Me.gbDatos.Controls.Add(Me.Label4)
        Me.gbDatos.Controls.Add(Me.Label7)
        Me.gbDatos.Controls.Add(Me.Label6)
        Me.gbDatos.Controls.Add(Me.txtObservaciones)
        Me.gbDatos.Controls.Add(Me.dtpFechaIngreso)
        Me.gbDatos.Location = New System.Drawing.Point(13, 13)
        Me.gbDatos.Margin = New System.Windows.Forms.Padding(4)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Padding = New System.Windows.Forms.Padding(4)
        Me.gbDatos.Size = New System.Drawing.Size(606, 153)
        Me.gbDatos.TabIndex = 0
        Me.gbDatos.TabStop = False
        Me.gbDatos.Text = "Datos"
        '
        'btnPrueba
        '
        Me.btnPrueba.Location = New System.Drawing.Point(524, -1)
        Me.btnPrueba.Name = "btnPrueba"
        Me.btnPrueba.Size = New System.Drawing.Size(75, 23)
        Me.btnPrueba.TabIndex = 3
        Me.btnPrueba.Text = "PRUEBA"
        Me.btnPrueba.UseVisualStyleBackColor = True
        '
        'cbTipoComprobante
        '
        Me.cbTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipoComprobante.FormattingEnabled = True
        Me.cbTipoComprobante.Location = New System.Drawing.Point(159, 51)
        Me.cbTipoComprobante.Margin = New System.Windows.Forms.Padding(4)
        Me.cbTipoComprobante.Name = "cbTipoComprobante"
        Me.cbTipoComprobante.Size = New System.Drawing.Size(100, 24)
        Me.cbTipoComprobante.TabIndex = 1
        '
        'txtNroComprobante
        '
        Me.txtNroComprobante.Location = New System.Drawing.Point(386, 51)
        Me.txtNroComprobante.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNroComprobante.Name = "txtNroComprobante"
        Me.txtNroComprobante.Size = New System.Drawing.Size(100, 22)
        Me.txtNroComprobante.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(267, 54)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 16)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "N° Comprobante:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 27)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 16)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Fecha:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 54)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(143, 16)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Tipo de Comprobante:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 86)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 16)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Observaciones:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(119, 83)
        Me.txtObservaciones.Margin = New System.Windows.Forms.Padding(4)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(479, 62)
        Me.txtObservaciones.TabIndex = 3
        '
        'dtpFechaIngreso
        '
        Me.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaIngreso.Location = New System.Drawing.Point(64, 22)
        Me.dtpFechaIngreso.Name = "dtpFechaIngreso"
        Me.dtpFechaIngreso.Size = New System.Drawing.Size(85, 22)
        Me.dtpFechaIngreso.TabIndex = 0
        '
        'lblDescCodigo
        '
        Me.lblDescCodigo.AutoSize = True
        Me.lblDescCodigo.Location = New System.Drawing.Point(345, 51)
        Me.lblDescCodigo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDescCodigo.MaximumSize = New System.Drawing.Size(238, 0)
        Me.lblDescCodigo.Name = "lblDescCodigo"
        Me.lblDescCodigo.Size = New System.Drawing.Size(12, 16)
        Me.lblDescCodigo.TabIndex = 4
        Me.lblDescCodigo.Text = "-"
        Me.lblDescCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbMovimiento
        '
        Me.gbMovimiento.Controls.Add(Me.lblStockActual)
        Me.gbMovimiento.Controls.Add(Me.lblUnidadDeMedida)
        Me.gbMovimiento.Controls.Add(Me.txtCantidadIngresada)
        Me.gbMovimiento.Controls.Add(Me.btnCancelarDetalle)
        Me.gbMovimiento.Controls.Add(Me.btnGuardarDetalle)
        Me.gbMovimiento.Controls.Add(Me.Label2)
        Me.gbMovimiento.Controls.Add(Me.lblDescCodigo)
        Me.gbMovimiento.Controls.Add(Me.cbCategoria)
        Me.gbMovimiento.Controls.Add(Me.Label3)
        Me.gbMovimiento.Controls.Add(Me.cbArticulo)
        Me.gbMovimiento.Location = New System.Drawing.Point(13, 174)
        Me.gbMovimiento.Margin = New System.Windows.Forms.Padding(4)
        Me.gbMovimiento.Name = "gbMovimiento"
        Me.gbMovimiento.Padding = New System.Windows.Forms.Padding(4)
        Me.gbMovimiento.Size = New System.Drawing.Size(606, 135)
        Me.gbMovimiento.TabIndex = 1
        Me.gbMovimiento.TabStop = False
        Me.gbMovimiento.Text = "Artículo"
        '
        'lblStockActual
        '
        Me.lblStockActual.AutoSize = True
        Me.lblStockActual.Location = New System.Drawing.Point(387, 74)
        Me.lblStockActual.Name = "lblStockActual"
        Me.lblStockActual.Size = New System.Drawing.Size(12, 16)
        Me.lblStockActual.TabIndex = 29
        Me.lblStockActual.Text = "-"
        '
        'lblUnidadDeMedida
        '
        Me.lblUnidadDeMedida.Location = New System.Drawing.Point(8, 71)
        Me.lblUnidadDeMedida.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUnidadDeMedida.Name = "lblUnidadDeMedida"
        Me.lblUnidadDeMedida.Size = New System.Drawing.Size(294, 22)
        Me.lblUnidadDeMedida.TabIndex = 28
        Me.lblUnidadDeMedida.Text = "[ ]:"
        Me.lblUnidadDeMedida.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCantidadIngresada
        '
        Me.txtCantidadIngresada.Location = New System.Drawing.Point(310, 71)
        Me.txtCantidadIngresada.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCantidadIngresada.Name = "txtCantidadIngresada"
        Me.txtCantidadIngresada.Size = New System.Drawing.Size(70, 22)
        Me.txtCantidadIngresada.TabIndex = 2
        '
        'btnCancelarDetalle
        '
        Me.btnCancelarDetalle.AutoSize = True
        Me.btnCancelarDetalle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancelarDetalle.Font = New System.Drawing.Font("Microsoft Tai Le", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarDetalle.Location = New System.Drawing.Point(8, 101)
        Me.btnCancelarDetalle.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancelarDetalle.Name = "btnCancelarDetalle"
        Me.btnCancelarDetalle.Size = New System.Drawing.Size(84, 26)
        Me.btnCancelarDetalle.TabIndex = 4
        Me.btnCancelarDetalle.Text = "CANCELAR"
        Me.btnCancelarDetalle.UseVisualStyleBackColor = True
        '
        'btnGuardarDetalle
        '
        Me.btnGuardarDetalle.AutoSize = True
        Me.btnGuardarDetalle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGuardarDetalle.Font = New System.Drawing.Font("Microsoft Tai Le", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarDetalle.Location = New System.Drawing.Point(280, 101)
        Me.btnGuardarDetalle.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGuardarDetalle.Name = "btnGuardarDetalle"
        Me.btnGuardarDetalle.Size = New System.Drawing.Size(77, 26)
        Me.btnGuardarDetalle.TabIndex = 3
        Me.btnGuardarDetalle.Text = "AGREGAR"
        Me.btnGuardarDetalle.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 26)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Categoría:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbCategoria
        '
        Me.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCategoria.FormattingEnabled = True
        Me.cbCategoria.Location = New System.Drawing.Point(86, 23)
        Me.cbCategoria.Margin = New System.Windows.Forms.Padding(4)
        Me.cbCategoria.Name = "cbCategoria"
        Me.cbCategoria.Size = New System.Drawing.Size(191, 24)
        Me.cbCategoria.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(285, 26)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Artículo:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbArticulo
        '
        Me.cbArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbArticulo.FormattingEnabled = True
        Me.cbArticulo.Location = New System.Drawing.Point(348, 23)
        Me.cbArticulo.Margin = New System.Windows.Forms.Padding(4)
        Me.cbArticulo.Name = "cbArticulo"
        Me.cbArticulo.Size = New System.Drawing.Size(250, 24)
        Me.cbArticulo.TabIndex = 1
        '
        'gbDetalleMovimiento
        '
        Me.gbDetalleMovimiento.Controls.Add(Me.btnEliminarFilaDetalle)
        Me.gbDetalleMovimiento.Controls.Add(Me.btnConfirmarMovimiento)
        Me.gbDetalleMovimiento.Controls.Add(Me.dgvDetalleMovimiento)
        Me.gbDetalleMovimiento.Location = New System.Drawing.Point(12, 318)
        Me.gbDetalleMovimiento.Name = "gbDetalleMovimiento"
        Me.gbDetalleMovimiento.Size = New System.Drawing.Size(608, 293)
        Me.gbDetalleMovimiento.TabIndex = 2
        Me.gbDetalleMovimiento.TabStop = False
        Me.gbDetalleMovimiento.Text = "Detalle"
        '
        'btnEliminarFilaDetalle
        '
        Me.btnEliminarFilaDetalle.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEliminarFilaDetalle.Font = New System.Drawing.Font("Microsoft Tai Le", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminarFilaDetalle.Location = New System.Drawing.Point(7, 246)
        Me.btnEliminarFilaDetalle.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEliminarFilaDetalle.Name = "btnEliminarFilaDetalle"
        Me.btnEliminarFilaDetalle.Size = New System.Drawing.Size(77, 40)
        Me.btnEliminarFilaDetalle.TabIndex = 1
        Me.btnEliminarFilaDetalle.Text = "ELIMINAR FILA"
        Me.btnEliminarFilaDetalle.UseVisualStyleBackColor = True
        '
        'btnConfirmarMovimiento
        '
        Me.btnConfirmarMovimiento.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConfirmarMovimiento.Font = New System.Drawing.Font("Microsoft Tai Le", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmarMovimiento.Location = New System.Drawing.Point(509, 246)
        Me.btnConfirmarMovimiento.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConfirmarMovimiento.Name = "btnConfirmarMovimiento"
        Me.btnConfirmarMovimiento.Size = New System.Drawing.Size(92, 40)
        Me.btnConfirmarMovimiento.TabIndex = 2
        Me.btnConfirmarMovimiento.Text = "CONFIRMAR MOV"
        Me.btnConfirmarMovimiento.UseVisualStyleBackColor = True
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
        Me.dgvDetalleMovimiento.Size = New System.Drawing.Size(596, 218)
        Me.dgvDetalleMovimiento.TabIndex = 0
        '
        'frmAltaReserva
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 632)
        Me.Controls.Add(Me.gbDetalleMovimiento)
        Me.Controls.Add(Me.gbMovimiento)
        Me.Controls.Add(Me.gbDatos)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "frmAltaReserva"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alta Reserva"
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        Me.gbMovimiento.ResumeLayout(False)
        Me.gbMovimiento.PerformLayout()
        Me.gbDetalleMovimiento.ResumeLayout(False)
        CType(Me.dgvDetalleMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents lblDescCodigo As System.Windows.Forms.Label
    Friend WithEvents gbMovimiento As System.Windows.Forms.GroupBox
    Friend WithEvents lblUnidadDeMedida As System.Windows.Forms.Label
    Friend WithEvents txtCantidadIngresada As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnCancelarDetalle As System.Windows.Forms.Button
    Friend WithEvents btnGuardarDetalle As System.Windows.Forms.Button
    Friend WithEvents dtpFechaIngreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNroComprobante As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbTipoComprobante As System.Windows.Forms.ComboBox
    Friend WithEvents gbDetalleMovimiento As System.Windows.Forms.GroupBox
    Friend WithEvents dgvDetalleMovimiento As System.Windows.Forms.DataGridView
    Friend WithEvents btnConfirmarMovimiento As System.Windows.Forms.Button
    Friend WithEvents btnEliminarFilaDetalle As System.Windows.Forms.Button
    Friend WithEvents btnPrueba As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents lblStockActual As System.Windows.Forms.Label
End Class
