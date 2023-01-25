<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHilaRemitoEgreso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHilaRemitoEgreso))
        Me.lblPartida = New System.Windows.Forms.Label()
        Me.txtPartida = New System.Windows.Forms.TextBox()
        Me.txtHilado = New System.Windows.Forms.TextBox()
        Me.lblHilado = New System.Windows.Forms.Label()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblKilos = New System.Windows.Forms.Label()
        Me.txtKilos = New System.Windows.Forms.TextBox()
        Me.dgvDetalleRemito = New System.Windows.Forms.DataGridView()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lblNroRemito = New System.Windows.Forms.Label()
        Me.txtNroRemito = New System.Windows.Forms.TextBox()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.lblObservacion = New System.Windows.Forms.Label()
        Me.btnQuitarLinea = New System.Windows.Forms.Button()
        Me.txtColor = New System.Windows.Forms.TextBox()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.txtConos = New System.Windows.Forms.TextBox()
        Me.lblConos = New System.Windows.Forms.Label()
        Me.txtDetObservacion = New System.Windows.Forms.TextBox()
        Me.lblDetObservacion = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.txtStockActualPartida = New System.Windows.Forms.TextBox()
        Me.lblStockActualPartida = New System.Windows.Forms.Label()
        CType(Me.dgvDetalleRemito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPartida
        '
        Me.lblPartida.Location = New System.Drawing.Point(18, 84)
        Me.lblPartida.Name = "lblPartida"
        Me.lblPartida.Size = New System.Drawing.Size(112, 25)
        Me.lblPartida.TabIndex = 0
        Me.lblPartida.Text = "PARTIDA"
        Me.lblPartida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPartida
        '
        Me.txtPartida.Location = New System.Drawing.Point(18, 112)
        Me.txtPartida.Name = "txtPartida"
        Me.txtPartida.Size = New System.Drawing.Size(112, 20)
        Me.txtPartida.TabIndex = 0
        '
        'txtHilado
        '
        Me.txtHilado.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txtHilado.Location = New System.Drawing.Point(130, 112)
        Me.txtHilado.Name = "txtHilado"
        Me.txtHilado.Size = New System.Drawing.Size(188, 20)
        Me.txtHilado.TabIndex = 1
        '
        'lblHilado
        '
        Me.lblHilado.Location = New System.Drawing.Point(130, 84)
        Me.lblHilado.Name = "lblHilado"
        Me.lblHilado.Size = New System.Drawing.Size(185, 25)
        Me.lblHilado.TabIndex = 2
        Me.lblHilado.Text = "HILADO"
        Me.lblHilado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(367, 404)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(113, 29)
        Me.cmdAceptar.TabIndex = 3
        Me.cmdAceptar.Text = "Confirmar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(757, 404)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(92, 29)
        Me.cmdCancelar.TabIndex = 4
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(9, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 25)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Fecha:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(82, 11)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(102, 20)
        Me.dtpFecha.TabIndex = 6
        '
        'lblKilos
        '
        Me.lblKilos.Location = New System.Drawing.Point(607, 84)
        Me.lblKilos.Name = "lblKilos"
        Me.lblKilos.Size = New System.Drawing.Size(60, 25)
        Me.lblKilos.TabIndex = 10
        Me.lblKilos.Text = "KILOS"
        Me.lblKilos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtKilos
        '
        Me.txtKilos.Location = New System.Drawing.Point(604, 112)
        Me.txtKilos.Name = "txtKilos"
        Me.txtKilos.Size = New System.Drawing.Size(67, 20)
        Me.txtKilos.TabIndex = 11
        '
        'dgvDetalleRemito
        '
        Me.dgvDetalleRemito.AllowUserToAddRows = False
        Me.dgvDetalleRemito.AllowUserToDeleteRows = False
        Me.dgvDetalleRemito.AllowUserToResizeColumns = False
        Me.dgvDetalleRemito.AllowUserToResizeRows = False
        Me.dgvDetalleRemito.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvDetalleRemito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleRemito.Location = New System.Drawing.Point(12, 187)
        Me.dgvDetalleRemito.MultiSelect = False
        Me.dgvDetalleRemito.Name = "dgvDetalleRemito"
        Me.dgvDetalleRemito.ReadOnly = True
        Me.dgvDetalleRemito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalleRemito.Size = New System.Drawing.Size(858, 196)
        Me.dgvDetalleRemito.TabIndex = 12
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(865, 112)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(55, 25)
        Me.btnOK.TabIndex = 13
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lblNroRemito
        '
        Me.lblNroRemito.Location = New System.Drawing.Point(238, 10)
        Me.lblNroRemito.Name = "lblNroRemito"
        Me.lblNroRemito.Size = New System.Drawing.Size(79, 25)
        Me.lblNroRemito.TabIndex = 16
        Me.lblNroRemito.Text = "Nro Remito:"
        Me.lblNroRemito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNroRemito
        '
        Me.txtNroRemito.Location = New System.Drawing.Point(321, 12)
        Me.txtNroRemito.Name = "txtNroRemito"
        Me.txtNroRemito.Size = New System.Drawing.Size(159, 20)
        Me.txtNroRemito.TabIndex = 17
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(82, 38)
        Me.txtObservacion.MaxLength = 150
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(589, 20)
        Me.txtObservacion.TabIndex = 22
        '
        'lblObservacion
        '
        Me.lblObservacion.Location = New System.Drawing.Point(-1, 36)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(79, 25)
        Me.lblObservacion.TabIndex = 21
        Me.lblObservacion.Text = "Observación:"
        Me.lblObservacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnQuitarLinea
        '
        Me.btnQuitarLinea.Location = New System.Drawing.Point(876, 197)
        Me.btnQuitarLinea.Name = "btnQuitarLinea"
        Me.btnQuitarLinea.Size = New System.Drawing.Size(44, 37)
        Me.btnQuitarLinea.TabIndex = 23
        Me.btnQuitarLinea.Text = "Quitar Linea"
        Me.btnQuitarLinea.UseVisualStyleBackColor = True
        '
        'txtColor
        '
        Me.txtColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txtColor.Location = New System.Drawing.Point(318, 112)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Size = New System.Drawing.Size(229, 20)
        Me.txtColor.TabIndex = 24
        '
        'lblColor
        '
        Me.lblColor.Location = New System.Drawing.Point(318, 84)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(226, 25)
        Me.lblColor.TabIndex = 25
        Me.lblColor.Text = "COLOR"
        Me.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtConos
        '
        Me.txtConos.Location = New System.Drawing.Point(549, 112)
        Me.txtConos.Name = "txtConos"
        Me.txtConos.Size = New System.Drawing.Size(54, 20)
        Me.txtConos.TabIndex = 27
        '
        'lblConos
        '
        Me.lblConos.Location = New System.Drawing.Point(552, 84)
        Me.lblConos.Name = "lblConos"
        Me.lblConos.Size = New System.Drawing.Size(47, 25)
        Me.lblConos.TabIndex = 26
        Me.lblConos.Text = "CONOS"
        Me.lblConos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDetObservacion
        '
        Me.txtDetObservacion.Location = New System.Drawing.Point(672, 112)
        Me.txtDetObservacion.MaxLength = 100
        Me.txtDetObservacion.Name = "txtDetObservacion"
        Me.txtDetObservacion.Size = New System.Drawing.Size(181, 20)
        Me.txtDetObservacion.TabIndex = 29
        '
        'lblDetObservacion
        '
        Me.lblDetObservacion.Location = New System.Drawing.Point(675, 84)
        Me.lblDetObservacion.Name = "lblDetObservacion"
        Me.lblDetObservacion.Size = New System.Drawing.Size(174, 25)
        Me.lblDetObservacion.TabIndex = 28
        Me.lblDetObservacion.Text = "OBSERVACIÓN"
        Me.lblDetObservacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTitulo
        '
        Me.lblTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(151, Byte), Integer))
        Me.lblTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(742, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(186, 38)
        Me.lblTitulo.TabIndex = 30
        Me.lblTitulo.Text = "EGRESOS"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtStockActualPartida
        '
        Me.txtStockActualPartida.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txtStockActualPartida.Location = New System.Drawing.Point(460, 132)
        Me.txtStockActualPartida.Name = "txtStockActualPartida"
        Me.txtStockActualPartida.Size = New System.Drawing.Size(87, 20)
        Me.txtStockActualPartida.TabIndex = 31
        Me.txtStockActualPartida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblStockActualPartida
        '
        Me.lblStockActualPartida.Location = New System.Drawing.Point(284, 137)
        Me.lblStockActualPartida.Name = "lblStockActualPartida"
        Me.lblStockActualPartida.Size = New System.Drawing.Size(185, 14)
        Me.lblStockActualPartida.TabIndex = 32
        Me.lblStockActualPartida.Text = "STOCK ACTUAL DE LA PARTIDA:"
        Me.lblStockActualPartida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmHilaRemitoEgreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(928, 445)
        Me.Controls.Add(Me.txtStockActualPartida)
        Me.Controls.Add(Me.lblStockActualPartida)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.txtDetObservacion)
        Me.Controls.Add(Me.lblDetObservacion)
        Me.Controls.Add(Me.txtConos)
        Me.Controls.Add(Me.lblConos)
        Me.Controls.Add(Me.txtColor)
        Me.Controls.Add(Me.lblColor)
        Me.Controls.Add(Me.btnQuitarLinea)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.lblObservacion)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtNroRemito)
        Me.Controls.Add(Me.lblNroRemito)
        Me.Controls.Add(Me.dgvDetalleRemito)
        Me.Controls.Add(Me.txtKilos)
        Me.Controls.Add(Me.lblKilos)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.txtHilado)
        Me.Controls.Add(Me.lblHilado)
        Me.Controls.Add(Me.txtPartida)
        Me.Controls.Add(Me.lblPartida)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmHilaRemitoEgreso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Egresos de Hilados"
        CType(Me.dgvDetalleRemito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPartida As System.Windows.Forms.Label
    Friend WithEvents txtPartida As System.Windows.Forms.TextBox
    Friend WithEvents txtHilado As System.Windows.Forms.TextBox
    Friend WithEvents lblHilado As System.Windows.Forms.Label
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblKilos As System.Windows.Forms.Label
    Friend WithEvents txtKilos As System.Windows.Forms.TextBox
    Friend WithEvents dgvDetalleRemito As System.Windows.Forms.DataGridView
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblNroRemito As System.Windows.Forms.Label
    Friend WithEvents txtNroRemito As System.Windows.Forms.TextBox
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents lblObservacion As System.Windows.Forms.Label
    Friend WithEvents btnQuitarLinea As System.Windows.Forms.Button
    Friend WithEvents txtColor As System.Windows.Forms.TextBox
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents txtConos As System.Windows.Forms.TextBox
    Friend WithEvents lblConos As System.Windows.Forms.Label
    Friend WithEvents txtDetObservacion As System.Windows.Forms.TextBox
    Friend WithEvents lblDetObservacion As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents txtStockActualPartida As System.Windows.Forms.TextBox
    Friend WithEvents lblStockActualPartida As System.Windows.Forms.Label
End Class
