<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBorrarABMIngresodeHilados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBorrarABMIngresodeHilados))
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.txtCodHilado = New System.Windows.Forms.TextBox()
        Me.lblCodHilado = New System.Windows.Forms.Label()
        Me.txtPartida = New System.Windows.Forms.TextBox()
        Me.lblPartida = New System.Windows.Forms.Label()
        Me.lblFechaIngreso = New System.Windows.Forms.Label()
        Me.txtKilos = New System.Windows.Forms.TextBox()
        Me.lblKilos = New System.Windows.Forms.Label()
        Me.txtNroGuia = New System.Windows.Forms.TextBox()
        Me.lblNroGuia = New System.Windows.Forms.Label()
        Me.txtNroRemito = New System.Windows.Forms.TextBox()
        Me.lblNroRemito = New System.Windows.Forms.Label()
        Me.lblTipoMov = New System.Windows.Forms.Label()
        Me.dtpFechaIngreso = New System.Windows.Forms.DateTimePicker()
        Me.lblDatosPartida = New System.Windows.Forms.Label()
        Me.lblDatosHilado = New System.Windows.Forms.Label()
        Me.rbIngreso = New System.Windows.Forms.RadioButton()
        Me.rbDevolucion = New System.Windows.Forms.RadioButton()
        Me.chkFindePartida = New System.Windows.Forms.CheckBox()
        Me.lblFondoCheckFinPartida = New System.Windows.Forms.Label()
        Me.chkParaCostura = New System.Windows.Forms.CheckBox()
        Me.lblFondoCheckParaCostura = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.Location = New System.Drawing.Point(276, 333)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(81, 27)
        Me.cmdCancelar.TabIndex = 9
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGuardar.Location = New System.Drawing.Point(106, 333)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(81, 27)
        Me.cmdGuardar.TabIndex = 8
        Me.cmdGuardar.Text = "Guardar"
        Me.cmdGuardar.UseVisualStyleBackColor = True
        '
        'txtCodHilado
        '
        Me.txtCodHilado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodHilado.Location = New System.Drawing.Point(126, 57)
        Me.txtCodHilado.Name = "txtCodHilado"
        Me.txtCodHilado.Size = New System.Drawing.Size(103, 23)
        Me.txtCodHilado.TabIndex = 7
        '
        'lblCodHilado
        '
        Me.lblCodHilado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodHilado.Location = New System.Drawing.Point(1, 57)
        Me.lblCodHilado.Name = "lblCodHilado"
        Me.lblCodHilado.Size = New System.Drawing.Size(119, 23)
        Me.lblCodHilado.TabIndex = 6
        Me.lblCodHilado.Text = "Cod.Hilado:"
        Me.lblCodHilado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPartida
        '
        Me.txtPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartida.Location = New System.Drawing.Point(126, 25)
        Me.txtPartida.MaxLength = 9
        Me.txtPartida.Name = "txtPartida"
        Me.txtPartida.Size = New System.Drawing.Size(103, 23)
        Me.txtPartida.TabIndex = 11
        '
        'lblPartida
        '
        Me.lblPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartida.Location = New System.Drawing.Point(1, 25)
        Me.lblPartida.Name = "lblPartida"
        Me.lblPartida.Size = New System.Drawing.Size(119, 23)
        Me.lblPartida.TabIndex = 10
        Me.lblPartida.Text = "Partida:"
        Me.lblPartida.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFechaIngreso
        '
        Me.lblFechaIngreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaIngreso.Location = New System.Drawing.Point(1, 90)
        Me.lblFechaIngreso.Name = "lblFechaIngreso"
        Me.lblFechaIngreso.Size = New System.Drawing.Size(119, 23)
        Me.lblFechaIngreso.TabIndex = 12
        Me.lblFechaIngreso.Text = "Fecha Ingreso:"
        Me.lblFechaIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtKilos
        '
        Me.txtKilos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKilos.Location = New System.Drawing.Point(126, 125)
        Me.txtKilos.Name = "txtKilos"
        Me.txtKilos.Size = New System.Drawing.Size(103, 23)
        Me.txtKilos.TabIndex = 15
        '
        'lblKilos
        '
        Me.lblKilos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKilos.Location = New System.Drawing.Point(1, 125)
        Me.lblKilos.Name = "lblKilos"
        Me.lblKilos.Size = New System.Drawing.Size(119, 23)
        Me.lblKilos.TabIndex = 14
        Me.lblKilos.Text = "Kilos:"
        Me.lblKilos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNroGuia
        '
        Me.txtNroGuia.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroGuia.Location = New System.Drawing.Point(126, 191)
        Me.txtNroGuia.Name = "txtNroGuia"
        Me.txtNroGuia.Size = New System.Drawing.Size(215, 23)
        Me.txtNroGuia.TabIndex = 17
        '
        'lblNroGuia
        '
        Me.lblNroGuia.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNroGuia.Location = New System.Drawing.Point(1, 191)
        Me.lblNroGuia.Name = "lblNroGuia"
        Me.lblNroGuia.Size = New System.Drawing.Size(119, 23)
        Me.lblNroGuia.TabIndex = 16
        Me.lblNroGuia.Text = "Nro.Guía:"
        Me.lblNroGuia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNroRemito
        '
        Me.txtNroRemito.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroRemito.Location = New System.Drawing.Point(126, 159)
        Me.txtNroRemito.Name = "txtNroRemito"
        Me.txtNroRemito.Size = New System.Drawing.Size(215, 23)
        Me.txtNroRemito.TabIndex = 19
        '
        'lblNroRemito
        '
        Me.lblNroRemito.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNroRemito.Location = New System.Drawing.Point(1, 159)
        Me.lblNroRemito.Name = "lblNroRemito"
        Me.lblNroRemito.Size = New System.Drawing.Size(119, 23)
        Me.lblNroRemito.TabIndex = 18
        Me.lblNroRemito.Text = "Nro.Remito:"
        Me.lblNroRemito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTipoMov
        '
        Me.lblTipoMov.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoMov.Location = New System.Drawing.Point(1, 225)
        Me.lblTipoMov.Name = "lblTipoMov"
        Me.lblTipoMov.Size = New System.Drawing.Size(119, 23)
        Me.lblTipoMov.TabIndex = 20
        Me.lblTipoMov.Text = "Tipo Mov.:"
        Me.lblTipoMov.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFechaIngreso
        '
        Me.dtpFechaIngreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaIngreso.Location = New System.Drawing.Point(126, 91)
        Me.dtpFechaIngreso.Name = "dtpFechaIngreso"
        Me.dtpFechaIngreso.Size = New System.Drawing.Size(103, 22)
        Me.dtpFechaIngreso.TabIndex = 22
        '
        'lblDatosPartida
        '
        Me.lblDatosPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatosPartida.Location = New System.Drawing.Point(235, 25)
        Me.lblDatosPartida.Name = "lblDatosPartida"
        Me.lblDatosPartida.Size = New System.Drawing.Size(245, 23)
        Me.lblDatosPartida.TabIndex = 23
        Me.lblDatosPartida.Text = "Datos de la Partida"
        Me.lblDatosPartida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDatosHilado
        '
        Me.lblDatosHilado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatosHilado.Location = New System.Drawing.Point(235, 57)
        Me.lblDatosHilado.Name = "lblDatosHilado"
        Me.lblDatosHilado.Size = New System.Drawing.Size(245, 23)
        Me.lblDatosHilado.TabIndex = 24
        Me.lblDatosHilado.Text = "Datos del Hilado"
        Me.lblDatosHilado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rbIngreso
        '
        Me.rbIngreso.AutoSize = True
        Me.rbIngreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbIngreso.Location = New System.Drawing.Point(126, 226)
        Me.rbIngreso.Name = "rbIngreso"
        Me.rbIngreso.Size = New System.Drawing.Size(80, 19)
        Me.rbIngreso.TabIndex = 25
        Me.rbIngreso.TabStop = True
        Me.rbIngreso.Text = "INGRESO"
        Me.rbIngreso.UseVisualStyleBackColor = True
        '
        'rbDevolucion
        '
        Me.rbDevolucion.AutoSize = True
        Me.rbDevolucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDevolucion.Location = New System.Drawing.Point(238, 226)
        Me.rbDevolucion.Name = "rbDevolucion"
        Me.rbDevolucion.Size = New System.Drawing.Size(103, 19)
        Me.rbDevolucion.TabIndex = 26
        Me.rbDevolucion.TabStop = True
        Me.rbDevolucion.Text = "DEVOLUCION"
        Me.rbDevolucion.UseVisualStyleBackColor = True
        '
        'chkFindePartida
        '
        Me.chkFindePartida.AutoSize = True
        Me.chkFindePartida.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.chkFindePartida.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFindePartida.Location = New System.Drawing.Point(245, 268)
        Me.chkFindePartida.Name = "chkFindePartida"
        Me.chkFindePartida.Size = New System.Drawing.Size(96, 38)
        Me.chkFindePartida.TabIndex = 27
        Me.chkFindePartida.Text = "Fin de Partida"
        Me.chkFindePartida.UseVisualStyleBackColor = True
        '
        'lblFondoCheckFinPartida
        '
        Me.lblFondoCheckFinPartida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFondoCheckFinPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFondoCheckFinPartida.Location = New System.Drawing.Point(244, 267)
        Me.lblFondoCheckFinPartida.Name = "lblFondoCheckFinPartida"
        Me.lblFondoCheckFinPartida.Size = New System.Drawing.Size(98, 40)
        Me.lblFondoCheckFinPartida.TabIndex = 28
        Me.lblFondoCheckFinPartida.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblFondoCheckFinPartida.Visible = False
        '
        'chkParaCostura
        '
        Me.chkParaCostura.AutoSize = True
        Me.chkParaCostura.CheckAlign = System.Drawing.ContentAlignment.TopCenter
        Me.chkParaCostura.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkParaCostura.Location = New System.Drawing.Point(126, 268)
        Me.chkParaCostura.Name = "chkParaCostura"
        Me.chkParaCostura.Size = New System.Drawing.Size(89, 38)
        Me.chkParaCostura.TabIndex = 29
        Me.chkParaCostura.Text = "Para Costura"
        Me.chkParaCostura.UseVisualStyleBackColor = True
        '
        'lblFondoCheckParaCostura
        '
        Me.lblFondoCheckParaCostura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFondoCheckParaCostura.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFondoCheckParaCostura.Location = New System.Drawing.Point(125, 267)
        Me.lblFondoCheckParaCostura.Name = "lblFondoCheckParaCostura"
        Me.lblFondoCheckParaCostura.Size = New System.Drawing.Size(92, 40)
        Me.lblFondoCheckParaCostura.TabIndex = 30
        Me.lblFondoCheckParaCostura.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblFondoCheckParaCostura.Visible = False
        '
        'frmABMIngresodeHilados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 381)
        Me.Controls.Add(Me.chkParaCostura)
        Me.Controls.Add(Me.lblFondoCheckParaCostura)
        Me.Controls.Add(Me.chkFindePartida)
        Me.Controls.Add(Me.rbDevolucion)
        Me.Controls.Add(Me.rbIngreso)
        Me.Controls.Add(Me.lblDatosHilado)
        Me.Controls.Add(Me.lblDatosPartida)
        Me.Controls.Add(Me.dtpFechaIngreso)
        Me.Controls.Add(Me.lblTipoMov)
        Me.Controls.Add(Me.txtNroRemito)
        Me.Controls.Add(Me.lblNroRemito)
        Me.Controls.Add(Me.txtNroGuia)
        Me.Controls.Add(Me.lblNroGuia)
        Me.Controls.Add(Me.txtKilos)
        Me.Controls.Add(Me.lblKilos)
        Me.Controls.Add(Me.lblFechaIngreso)
        Me.Controls.Add(Me.txtPartida)
        Me.Controls.Add(Me.lblPartida)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdGuardar)
        Me.Controls.Add(Me.txtCodHilado)
        Me.Controls.Add(Me.lblCodHilado)
        Me.Controls.Add(Me.lblFondoCheckFinPartida)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmABMIngresodeHilados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Textilana - Ing. y Dev. de Hilados provenientes de Hilamar"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdGuardar As System.Windows.Forms.Button
    Friend WithEvents txtCodHilado As System.Windows.Forms.TextBox
    Friend WithEvents lblCodHilado As System.Windows.Forms.Label
    Friend WithEvents txtPartida As System.Windows.Forms.TextBox
    Friend WithEvents lblPartida As System.Windows.Forms.Label
    Friend WithEvents lblFechaIngreso As System.Windows.Forms.Label
    Friend WithEvents txtKilos As System.Windows.Forms.TextBox
    Friend WithEvents lblKilos As System.Windows.Forms.Label
    Friend WithEvents txtNroGuia As System.Windows.Forms.TextBox
    Friend WithEvents lblNroGuia As System.Windows.Forms.Label
    Friend WithEvents txtNroRemito As System.Windows.Forms.TextBox
    Friend WithEvents lblNroRemito As System.Windows.Forms.Label
    Friend WithEvents lblTipoMov As System.Windows.Forms.Label
    Friend WithEvents dtpFechaIngreso As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDatosPartida As System.Windows.Forms.Label
    Friend WithEvents lblDatosHilado As System.Windows.Forms.Label
    Friend WithEvents rbIngreso As System.Windows.Forms.RadioButton
    Friend WithEvents rbDevolucion As System.Windows.Forms.RadioButton
    Friend WithEvents chkFindePartida As System.Windows.Forms.CheckBox
    Friend WithEvents lblFondoCheckFinPartida As System.Windows.Forms.Label
    Friend WithEvents chkParaCostura As System.Windows.Forms.CheckBox
    Friend WithEvents lblFondoCheckParaCostura As System.Windows.Forms.Label
End Class
