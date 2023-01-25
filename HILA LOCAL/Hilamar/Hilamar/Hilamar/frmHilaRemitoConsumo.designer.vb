<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHilaRemitoConsumo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHilaRemitoConsumo))
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.lblObservacion = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtColor = New System.Windows.Forms.TextBox()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.txtKilos = New System.Windows.Forms.TextBox()
        Me.lblKilos = New System.Windows.Forms.Label()
        Me.txtHilado = New System.Windows.Forms.TextBox()
        Me.lblHilado = New System.Windows.Forms.Label()
        Me.txtPartida = New System.Windows.Forms.TextBox()
        Me.lblPartida = New System.Windows.Forms.Label()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.gbTipoDeConsumo = New System.Windows.Forms.GroupBox()
        Me.rbConsumoConvertirC = New System.Windows.Forms.RadioButton()
        Me.rbConsumoConvertirG = New System.Windows.Forms.RadioButton()
        Me.rbConsumoConvertirR = New System.Windows.Forms.RadioButton()
        Me.rbConsumoSolo = New System.Windows.Forms.RadioButton()
        Me.gbTipoDeConsumo.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitulo
        '
        Me.lblTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.lblTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(537, 0)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(186, 38)
        Me.lblTitulo.TabIndex = 45
        Me.lblTitulo.Text = "CONSUMOS"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(94, 53)
        Me.txtObservacion.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtObservacion.MaxLength = 200
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(541, 20)
        Me.txtObservacion.TabIndex = 49
        '
        'lblObservacion
        '
        Me.lblObservacion.Location = New System.Drawing.Point(11, 51)
        Me.lblObservacion.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(79, 25)
        Me.lblObservacion.TabIndex = 48
        Me.lblObservacion.Text = "Observación:"
        Me.lblObservacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(94, 27)
        Me.dtpFecha.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(102, 20)
        Me.dtpFecha.TabIndex = 47
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(45, 27)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 25)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Fecha:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtColor
        '
        Me.txtColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txtColor.Location = New System.Drawing.Point(326, 117)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Size = New System.Drawing.Size(229, 20)
        Me.txtColor.TabIndex = 56
        '
        'lblColor
        '
        Me.lblColor.Location = New System.Drawing.Point(326, 89)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(226, 25)
        Me.lblColor.TabIndex = 57
        Me.lblColor.Text = "COLOR"
        Me.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtKilos
        '
        Me.txtKilos.Location = New System.Drawing.Point(556, 117)
        Me.txtKilos.Name = "txtKilos"
        Me.txtKilos.Size = New System.Drawing.Size(67, 20)
        Me.txtKilos.TabIndex = 55
        '
        'lblKilos
        '
        Me.lblKilos.Location = New System.Drawing.Point(559, 89)
        Me.lblKilos.Name = "lblKilos"
        Me.lblKilos.Size = New System.Drawing.Size(60, 25)
        Me.lblKilos.TabIndex = 54
        Me.lblKilos.Text = "KILOS"
        Me.lblKilos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtHilado
        '
        Me.txtHilado.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txtHilado.Location = New System.Drawing.Point(138, 117)
        Me.txtHilado.Name = "txtHilado"
        Me.txtHilado.Size = New System.Drawing.Size(188, 20)
        Me.txtHilado.TabIndex = 52
        '
        'lblHilado
        '
        Me.lblHilado.Location = New System.Drawing.Point(138, 89)
        Me.lblHilado.Name = "lblHilado"
        Me.lblHilado.Size = New System.Drawing.Size(185, 25)
        Me.lblHilado.TabIndex = 53
        Me.lblHilado.Text = "HILADO"
        Me.lblHilado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPartida
        '
        Me.txtPartida.Location = New System.Drawing.Point(26, 117)
        Me.txtPartida.Name = "txtPartida"
        Me.txtPartida.Size = New System.Drawing.Size(112, 20)
        Me.txtPartida.TabIndex = 50
        '
        'lblPartida
        '
        Me.lblPartida.Location = New System.Drawing.Point(26, 89)
        Me.lblPartida.Name = "lblPartida"
        Me.lblPartida.Size = New System.Drawing.Size(112, 25)
        Me.lblPartida.TabIndex = 51
        Me.lblPartida.Text = "PARTIDA"
        Me.lblPartida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(578, 251)
        Me.cmdCancelar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(107, 32)
        Me.cmdCancelar.TabIndex = 59
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(224, 251)
        Me.cmdAceptar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(190, 32)
        Me.cmdAceptar.TabIndex = 58
        Me.cmdAceptar.Text = "Confirmar Consumo"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'gbTipoDeConsumo
        '
        Me.gbTipoDeConsumo.Controls.Add(Me.rbConsumoConvertirC)
        Me.gbTipoDeConsumo.Controls.Add(Me.rbConsumoConvertirG)
        Me.gbTipoDeConsumo.Controls.Add(Me.rbConsumoConvertirR)
        Me.gbTipoDeConsumo.Controls.Add(Me.rbConsumoSolo)
        Me.gbTipoDeConsumo.Location = New System.Drawing.Point(12, 154)
        Me.gbTipoDeConsumo.Name = "gbTipoDeConsumo"
        Me.gbTipoDeConsumo.Size = New System.Drawing.Size(700, 91)
        Me.gbTipoDeConsumo.TabIndex = 60
        Me.gbTipoDeConsumo.TabStop = False
        '
        'rbConsumoConvertirC
        '
        Me.rbConsumoConvertirC.AutoSize = True
        Me.rbConsumoConvertirC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbConsumoConvertirC.Location = New System.Drawing.Point(17, 56)
        Me.rbConsumoConvertirC.Name = "rbConsumoConvertirC"
        Me.rbConsumoConvertirC.Size = New System.Drawing.Size(266, 20)
        Me.rbConsumoConvertirC.TabIndex = 3
        Me.rbConsumoConvertirC.Text = "El Hilado se convertira en Commoditi (C)"
        Me.rbConsumoConvertirC.UseVisualStyleBackColor = True
        '
        'rbConsumoConvertirG
        '
        Me.rbConsumoConvertirG.AutoSize = True
        Me.rbConsumoConvertirG.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbConsumoConvertirG.Location = New System.Drawing.Point(498, 19)
        Me.rbConsumoConvertirG.Name = "rbConsumoConvertirG"
        Me.rbConsumoConvertirG.Size = New System.Drawing.Size(187, 20)
        Me.rbConsumoConvertirG.TabIndex = 2
        Me.rbConsumoConvertirG.Text = "El Hilado se Reservará (G)"
        Me.rbConsumoConvertirG.UseVisualStyleBackColor = True
        '
        'rbConsumoConvertirR
        '
        Me.rbConsumoConvertirR.AutoSize = True
        Me.rbConsumoConvertirR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbConsumoConvertirR.Location = New System.Drawing.Point(203, 18)
        Me.rbConsumoConvertirR.Name = "rbConsumoConvertirR"
        Me.rbConsumoConvertirR.Size = New System.Drawing.Size(270, 20)
        Me.rbConsumoConvertirR.TabIndex = 1
        Me.rbConsumoConvertirR.Text = "El Hilado se Convertirá en R (Repasado)"
        Me.rbConsumoConvertirR.UseVisualStyleBackColor = True
        '
        'rbConsumoSolo
        '
        Me.rbConsumoSolo.AutoSize = True
        Me.rbConsumoSolo.Checked = True
        Me.rbConsumoSolo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbConsumoSolo.Location = New System.Drawing.Point(17, 18)
        Me.rbConsumoSolo.Name = "rbConsumoSolo"
        Me.rbConsumoSolo.Size = New System.Drawing.Size(170, 20)
        Me.rbConsumoSolo.TabIndex = 0
        Me.rbConsumoSolo.TabStop = True
        Me.rbConsumoSolo.Text = "Solo Consumir el Hilado"
        Me.rbConsumoSolo.UseVisualStyleBackColor = True
        '
        'frmHilaRemitoConsumo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 309)
        Me.Controls.Add(Me.gbTipoDeConsumo)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.txtColor)
        Me.Controls.Add(Me.lblColor)
        Me.Controls.Add(Me.txtKilos)
        Me.Controls.Add(Me.lblKilos)
        Me.Controls.Add(Me.txtHilado)
        Me.Controls.Add(Me.lblHilado)
        Me.Controls.Add(Me.txtPartida)
        Me.Controls.Add(Me.lblPartida)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.lblObservacion)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTitulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmHilaRemitoConsumo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Consumo de Hilados"
        Me.gbTipoDeConsumo.ResumeLayout(False)
        Me.gbTipoDeConsumo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents lblObservacion As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtColor As System.Windows.Forms.TextBox
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents txtKilos As System.Windows.Forms.TextBox
    Friend WithEvents lblKilos As System.Windows.Forms.Label
    Friend WithEvents txtHilado As System.Windows.Forms.TextBox
    Friend WithEvents lblHilado As System.Windows.Forms.Label
    Friend WithEvents txtPartida As System.Windows.Forms.TextBox
    Friend WithEvents lblPartida As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents gbTipoDeConsumo As System.Windows.Forms.GroupBox
    Friend WithEvents rbConsumoConvertirR As System.Windows.Forms.RadioButton
    Friend WithEvents rbConsumoSolo As System.Windows.Forms.RadioButton
    Friend WithEvents rbConsumoConvertirG As System.Windows.Forms.RadioButton
    Friend WithEvents rbConsumoConvertirC As System.Windows.Forms.RadioButton
End Class
