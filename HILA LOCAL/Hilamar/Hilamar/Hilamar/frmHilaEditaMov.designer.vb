<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHilaEditaMov
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHilaEditaMov))
        Me.txtDetObservacion = New System.Windows.Forms.TextBox()
        Me.lblDetObservacion = New System.Windows.Forms.Label()
        Me.txtConos = New System.Windows.Forms.TextBox()
        Me.lblConos = New System.Windows.Forms.Label()
        Me.txtColor = New System.Windows.Forms.TextBox()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.btnQuitarLinea = New System.Windows.Forms.Button()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.lblObservacion = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.txtNroRemito = New System.Windows.Forms.TextBox()
        Me.lblNroRemito = New System.Windows.Forms.Label()
        Me.dgvDetalleRemito = New System.Windows.Forms.DataGridView()
        Me.txtKilos = New System.Windows.Forms.TextBox()
        Me.lblKilos = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.txtHilado = New System.Windows.Forms.TextBox()
        Me.lblHilado = New System.Windows.Forms.Label()
        Me.txtPartida = New System.Windows.Forms.TextBox()
        Me.lblPartida = New System.Windows.Forms.Label()
        Me.txtTipoMov = New System.Windows.Forms.TextBox()
        Me.lblTipoMov = New System.Windows.Forms.Label()
        CType(Me.dgvDetalleRemito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtDetObservacion
        '
        Me.txtDetObservacion.Location = New System.Drawing.Point(681, 113)
        Me.txtDetObservacion.MaxLength = 100
        Me.txtDetObservacion.Name = "txtDetObservacion"
        Me.txtDetObservacion.Size = New System.Drawing.Size(181, 20)
        Me.txtDetObservacion.TabIndex = 52
        '
        'lblDetObservacion
        '
        Me.lblDetObservacion.Location = New System.Drawing.Point(684, 85)
        Me.lblDetObservacion.Name = "lblDetObservacion"
        Me.lblDetObservacion.Size = New System.Drawing.Size(174, 25)
        Me.lblDetObservacion.TabIndex = 51
        Me.lblDetObservacion.Text = "OBSERVACIÓN"
        Me.lblDetObservacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtConos
        '
        Me.txtConos.Location = New System.Drawing.Point(558, 113)
        Me.txtConos.Name = "txtConos"
        Me.txtConos.Size = New System.Drawing.Size(54, 20)
        Me.txtConos.TabIndex = 50
        '
        'lblConos
        '
        Me.lblConos.Location = New System.Drawing.Point(561, 85)
        Me.lblConos.Name = "lblConos"
        Me.lblConos.Size = New System.Drawing.Size(47, 25)
        Me.lblConos.TabIndex = 49
        Me.lblConos.Text = "CONOS"
        Me.lblConos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtColor
        '
        Me.txtColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txtColor.Location = New System.Drawing.Point(327, 113)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Size = New System.Drawing.Size(229, 20)
        Me.txtColor.TabIndex = 47
        '
        'lblColor
        '
        Me.lblColor.Location = New System.Drawing.Point(327, 85)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(226, 25)
        Me.lblColor.TabIndex = 48
        Me.lblColor.Text = "COLOR"
        Me.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnQuitarLinea
        '
        Me.btnQuitarLinea.Location = New System.Drawing.Point(885, 198)
        Me.btnQuitarLinea.Name = "btnQuitarLinea"
        Me.btnQuitarLinea.Size = New System.Drawing.Size(44, 37)
        Me.btnQuitarLinea.TabIndex = 46
        Me.btnQuitarLinea.Text = "Quitar Linea"
        Me.btnQuitarLinea.UseVisualStyleBackColor = True
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(91, 39)
        Me.txtObservacion.MaxLength = 150
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(589, 20)
        Me.txtObservacion.TabIndex = 45
        '
        'lblObservacion
        '
        Me.lblObservacion.Location = New System.Drawing.Point(8, 37)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(79, 25)
        Me.lblObservacion.TabIndex = 44
        Me.lblObservacion.Text = "Observación:"
        Me.lblObservacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(874, 113)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(55, 25)
        Me.btnOK.TabIndex = 41
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'txtNroRemito
        '
        Me.txtNroRemito.Location = New System.Drawing.Point(521, 12)
        Me.txtNroRemito.Name = "txtNroRemito"
        Me.txtNroRemito.Size = New System.Drawing.Size(159, 20)
        Me.txtNroRemito.TabIndex = 43
        '
        'lblNroRemito
        '
        Me.lblNroRemito.Location = New System.Drawing.Point(438, 10)
        Me.lblNroRemito.Name = "lblNroRemito"
        Me.lblNroRemito.Size = New System.Drawing.Size(79, 25)
        Me.lblNroRemito.TabIndex = 42
        Me.lblNroRemito.Text = "Nro Remito:"
        Me.lblNroRemito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvDetalleRemito
        '
        Me.dgvDetalleRemito.AllowUserToAddRows = False
        Me.dgvDetalleRemito.AllowUserToDeleteRows = False
        Me.dgvDetalleRemito.AllowUserToResizeColumns = False
        Me.dgvDetalleRemito.AllowUserToResizeRows = False
        Me.dgvDetalleRemito.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvDetalleRemito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleRemito.Location = New System.Drawing.Point(21, 188)
        Me.dgvDetalleRemito.MultiSelect = False
        Me.dgvDetalleRemito.Name = "dgvDetalleRemito"
        Me.dgvDetalleRemito.ReadOnly = True
        Me.dgvDetalleRemito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalleRemito.Size = New System.Drawing.Size(858, 196)
        Me.dgvDetalleRemito.TabIndex = 40
        '
        'txtKilos
        '
        Me.txtKilos.Location = New System.Drawing.Point(613, 113)
        Me.txtKilos.Name = "txtKilos"
        Me.txtKilos.Size = New System.Drawing.Size(67, 20)
        Me.txtKilos.TabIndex = 39
        '
        'lblKilos
        '
        Me.lblKilos.Location = New System.Drawing.Point(616, 85)
        Me.lblKilos.Name = "lblKilos"
        Me.lblKilos.Size = New System.Drawing.Size(60, 25)
        Me.lblKilos.TabIndex = 38
        Me.lblKilos.Text = "KILOS"
        Me.lblKilos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(91, 12)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(102, 20)
        Me.dtpFecha.TabIndex = 37
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(18, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 25)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Fecha:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(766, 405)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(92, 29)
        Me.cmdCancelar.TabIndex = 35
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(376, 405)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(113, 29)
        Me.cmdAceptar.TabIndex = 34
        Me.cmdAceptar.Text = "Confirmar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'txtHilado
        '
        Me.txtHilado.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txtHilado.Location = New System.Drawing.Point(139, 113)
        Me.txtHilado.Name = "txtHilado"
        Me.txtHilado.Size = New System.Drawing.Size(188, 20)
        Me.txtHilado.TabIndex = 32
        '
        'lblHilado
        '
        Me.lblHilado.Location = New System.Drawing.Point(139, 85)
        Me.lblHilado.Name = "lblHilado"
        Me.lblHilado.Size = New System.Drawing.Size(185, 25)
        Me.lblHilado.TabIndex = 33
        Me.lblHilado.Text = "HILADO"
        Me.lblHilado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPartida
        '
        Me.txtPartida.Location = New System.Drawing.Point(27, 113)
        Me.txtPartida.Name = "txtPartida"
        Me.txtPartida.Size = New System.Drawing.Size(112, 20)
        Me.txtPartida.TabIndex = 31
        '
        'lblPartida
        '
        Me.lblPartida.Location = New System.Drawing.Point(27, 85)
        Me.lblPartida.Name = "lblPartida"
        Me.lblPartida.Size = New System.Drawing.Size(112, 25)
        Me.lblPartida.TabIndex = 30
        Me.lblPartida.Text = "PARTIDA"
        Me.lblPartida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTipoMov
        '
        Me.txtTipoMov.Enabled = False
        Me.txtTipoMov.Location = New System.Drawing.Point(327, 12)
        Me.txtTipoMov.Name = "txtTipoMov"
        Me.txtTipoMov.Size = New System.Drawing.Size(35, 20)
        Me.txtTipoMov.TabIndex = 54
        '
        'lblTipoMov
        '
        Me.lblTipoMov.Location = New System.Drawing.Point(244, 10)
        Me.lblTipoMov.Name = "lblTipoMov"
        Me.lblTipoMov.Size = New System.Drawing.Size(79, 25)
        Me.lblTipoMov.TabIndex = 53
        Me.lblTipoMov.Text = "Tipo Mov:"
        Me.lblTipoMov.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmHilaEditaMov
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(947, 454)
        Me.Controls.Add(Me.txtTipoMov)
        Me.Controls.Add(Me.lblTipoMov)
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmHilaEditaMov"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar Movimiento de I - E de Hilado"
        CType(Me.dgvDetalleRemito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDetObservacion As System.Windows.Forms.TextBox
    Friend WithEvents lblDetObservacion As System.Windows.Forms.Label
    Friend WithEvents txtConos As System.Windows.Forms.TextBox
    Friend WithEvents lblConos As System.Windows.Forms.Label
    Friend WithEvents txtColor As System.Windows.Forms.TextBox
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents btnQuitarLinea As System.Windows.Forms.Button
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents lblObservacion As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtNroRemito As System.Windows.Forms.TextBox
    Friend WithEvents lblNroRemito As System.Windows.Forms.Label
    Friend WithEvents dgvDetalleRemito As System.Windows.Forms.DataGridView
    Friend WithEvents txtKilos As System.Windows.Forms.TextBox
    Friend WithEvents lblKilos As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents txtHilado As System.Windows.Forms.TextBox
    Friend WithEvents lblHilado As System.Windows.Forms.Label
    Friend WithEvents txtPartida As System.Windows.Forms.TextBox
    Friend WithEvents lblPartida As System.Windows.Forms.Label
    Friend WithEvents txtTipoMov As System.Windows.Forms.TextBox
    Friend WithEvents lblTipoMov As System.Windows.Forms.Label
End Class
