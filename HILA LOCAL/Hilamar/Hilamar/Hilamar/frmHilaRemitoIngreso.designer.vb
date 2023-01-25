<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHilaRemitoIngreso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHilaRemitoIngreso))
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.dgvDetalleRemito = New System.Windows.Forms.DataGridView()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.lblObservacion = New System.Windows.Forms.Label()
        Me.txtDetObservacion = New System.Windows.Forms.TextBox()
        Me.lblDetObservacion = New System.Windows.Forms.Label()
        Me.txtColor = New System.Windows.Forms.TextBox()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.txtKilos = New System.Windows.Forms.TextBox()
        Me.lblKilos = New System.Windows.Forms.Label()
        Me.txtHilado = New System.Windows.Forms.TextBox()
        Me.lblHilado = New System.Windows.Forms.Label()
        Me.txtPartida = New System.Windows.Forms.TextBox()
        Me.lblPartida = New System.Windows.Forms.Label()
        Me.btnQuitarLinea = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        CType(Me.dgvDetalleRemito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(474, 347)
        Me.cmdAceptar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(95, 32)
        Me.cmdAceptar.TabIndex = 3
        Me.cmdAceptar.Text = "Confirmar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(710, 347)
        Me.cmdCancelar.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(95, 32)
        Me.cmdCancelar.TabIndex = 4
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(55, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 25)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Fecha:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(104, 9)
        Me.dtpFecha.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(102, 20)
        Me.dtpFecha.TabIndex = 6
        '
        'dgvDetalleRemito
        '
        Me.dgvDetalleRemito.AllowUserToAddRows = False
        Me.dgvDetalleRemito.AllowUserToDeleteRows = False
        Me.dgvDetalleRemito.AllowUserToResizeColumns = False
        Me.dgvDetalleRemito.AllowUserToResizeRows = False
        Me.dgvDetalleRemito.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvDetalleRemito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleRemito.Location = New System.Drawing.Point(12, 136)
        Me.dgvDetalleRemito.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.dgvDetalleRemito.MultiSelect = False
        Me.dgvDetalleRemito.Name = "dgvDetalleRemito"
        Me.dgvDetalleRemito.ReadOnly = True
        Me.dgvDetalleRemito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalleRemito.Size = New System.Drawing.Size(793, 196)
        Me.dgvDetalleRemito.TabIndex = 12
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(104, 35)
        Me.txtObservacion.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.txtObservacion.MaxLength = 200
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(492, 20)
        Me.txtObservacion.TabIndex = 24
        '
        'lblObservacion
        '
        Me.lblObservacion.Location = New System.Drawing.Point(21, 33)
        Me.lblObservacion.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(79, 25)
        Me.lblObservacion.TabIndex = 23
        Me.lblObservacion.Text = "Observación:"
        Me.lblObservacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDetObservacion
        '
        Me.txtDetObservacion.Location = New System.Drawing.Point(607, 95)
        Me.txtDetObservacion.MaxLength = 100
        Me.txtDetObservacion.Name = "txtDetObservacion"
        Me.txtDetObservacion.Size = New System.Drawing.Size(181, 20)
        Me.txtDetObservacion.TabIndex = 42
        '
        'lblDetObservacion
        '
        Me.lblDetObservacion.Location = New System.Drawing.Point(610, 67)
        Me.lblDetObservacion.Name = "lblDetObservacion"
        Me.lblDetObservacion.Size = New System.Drawing.Size(174, 25)
        Me.lblDetObservacion.TabIndex = 41
        Me.lblDetObservacion.Text = "OBSERVACIÓN"
        Me.lblDetObservacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtColor
        '
        Me.txtColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txtColor.Location = New System.Drawing.Point(309, 95)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Size = New System.Drawing.Size(229, 20)
        Me.txtColor.TabIndex = 37
        '
        'lblColor
        '
        Me.lblColor.Location = New System.Drawing.Point(309, 67)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(226, 25)
        Me.lblColor.TabIndex = 38
        Me.lblColor.Text = "COLOR"
        Me.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(794, 93)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(55, 25)
        Me.btnOK.TabIndex = 36
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'txtKilos
        '
        Me.txtKilos.Location = New System.Drawing.Point(539, 95)
        Me.txtKilos.Name = "txtKilos"
        Me.txtKilos.Size = New System.Drawing.Size(67, 20)
        Me.txtKilos.TabIndex = 35
        '
        'lblKilos
        '
        Me.lblKilos.Location = New System.Drawing.Point(542, 67)
        Me.lblKilos.Name = "lblKilos"
        Me.lblKilos.Size = New System.Drawing.Size(60, 25)
        Me.lblKilos.TabIndex = 34
        Me.lblKilos.Text = "KILOS"
        Me.lblKilos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtHilado
        '
        Me.txtHilado.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txtHilado.Location = New System.Drawing.Point(121, 95)
        Me.txtHilado.Name = "txtHilado"
        Me.txtHilado.Size = New System.Drawing.Size(188, 20)
        Me.txtHilado.TabIndex = 32
        '
        'lblHilado
        '
        Me.lblHilado.Location = New System.Drawing.Point(121, 67)
        Me.lblHilado.Name = "lblHilado"
        Me.lblHilado.Size = New System.Drawing.Size(185, 25)
        Me.lblHilado.TabIndex = 33
        Me.lblHilado.Text = "HILADO"
        Me.lblHilado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPartida
        '
        Me.txtPartida.Location = New System.Drawing.Point(9, 95)
        Me.txtPartida.Name = "txtPartida"
        Me.txtPartida.Size = New System.Drawing.Size(112, 20)
        Me.txtPartida.TabIndex = 30
        '
        'lblPartida
        '
        Me.lblPartida.Location = New System.Drawing.Point(9, 67)
        Me.lblPartida.Name = "lblPartida"
        Me.lblPartida.Size = New System.Drawing.Size(112, 25)
        Me.lblPartida.TabIndex = 31
        Me.lblPartida.Text = "PARTIDA"
        Me.lblPartida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnQuitarLinea
        '
        Me.btnQuitarLinea.Location = New System.Drawing.Point(810, 148)
        Me.btnQuitarLinea.Name = "btnQuitarLinea"
        Me.btnQuitarLinea.Size = New System.Drawing.Size(44, 37)
        Me.btnQuitarLinea.TabIndex = 43
        Me.btnQuitarLinea.Text = "Quitar Linea"
        Me.btnQuitarLinea.UseVisualStyleBackColor = True
        '
        'lblTitulo
        '
        Me.lblTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(182, Byte), Integer))
        Me.lblTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(673, 1)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(186, 38)
        Me.lblTitulo.TabIndex = 44
        Me.lblTitulo.Text = "INGRESOS"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmHilaRemitoIngreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 401)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.btnQuitarLinea)
        Me.Controls.Add(Me.txtDetObservacion)
        Me.Controls.Add(Me.lblDetObservacion)
        Me.Controls.Add(Me.txtColor)
        Me.Controls.Add(Me.lblColor)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtKilos)
        Me.Controls.Add(Me.lblKilos)
        Me.Controls.Add(Me.txtHilado)
        Me.Controls.Add(Me.lblHilado)
        Me.Controls.Add(Me.txtPartida)
        Me.Controls.Add(Me.lblPartida)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.lblObservacion)
        Me.Controls.Add(Me.dgvDetalleRemito)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.Name = "frmHilaRemitoIngreso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Ingreso de Hilados"
        CType(Me.dgvDetalleRemito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvDetalleRemito As System.Windows.Forms.DataGridView
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents lblObservacion As System.Windows.Forms.Label
    Friend WithEvents txtDetObservacion As System.Windows.Forms.TextBox
    Friend WithEvents lblDetObservacion As System.Windows.Forms.Label
    Friend WithEvents txtColor As System.Windows.Forms.TextBox
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtKilos As System.Windows.Forms.TextBox
    Friend WithEvents lblKilos As System.Windows.Forms.Label
    Friend WithEvents txtHilado As System.Windows.Forms.TextBox
    Friend WithEvents lblHilado As System.Windows.Forms.Label
    Friend WithEvents txtPartida As System.Windows.Forms.TextBox
    Friend WithEvents lblPartida As System.Windows.Forms.Label
    Friend WithEvents btnQuitarLinea As System.Windows.Forms.Button
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
End Class
