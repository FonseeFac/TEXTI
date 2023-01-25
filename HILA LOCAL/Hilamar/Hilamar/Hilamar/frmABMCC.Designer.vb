<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmABMCC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmABMCC))
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.txtObservacionesProgramacion = New System.Windows.Forms.TextBox()
        Me.lblObservacionesProgramacion = New System.Windows.Forms.Label()
        Me.txtObservacionesTejeduria = New System.Windows.Forms.TextBox()
        Me.lblObservacionesTejeduria = New System.Windows.Forms.Label()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.lblTalle = New System.Windows.Forms.Label()
        Me.cmbTalle = New System.Windows.Forms.ComboBox()
        Me.lblDestino = New System.Windows.Forms.Label()
        Me.cmbDestino = New System.Windows.Forms.ComboBox()
        Me.txtOP = New System.Windows.Forms.TextBox()
        Me.lblOP = New System.Windows.Forms.Label()
        Me.lblOrigen = New System.Windows.Forms.Label()
        Me.txtCodArticulo = New System.Windows.Forms.TextBox()
        Me.cmbOrigen = New System.Windows.Forms.ComboBox()
        Me.lblCodArticulo = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.chkEs2daEtapa = New System.Windows.Forms.CheckBox()
        Me.lblNroCelda = New System.Windows.Forms.Label()
        Me.cmbNroCelda = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'lblEstado
        '
        Me.lblEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.Location = New System.Drawing.Point(426, 41)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(264, 30)
        Me.lblEstado.TabIndex = 111
        Me.lblEstado.Text = "ESTADO"
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(426, 71)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(265, 33)
        Me.cmbEstado.TabIndex = 110
        '
        'txtObservacionesProgramacion
        '
        Me.txtObservacionesProgramacion.Location = New System.Drawing.Point(139, 430)
        Me.txtObservacionesProgramacion.Multiline = True
        Me.txtObservacionesProgramacion.Name = "txtObservacionesProgramacion"
        Me.txtObservacionesProgramacion.Size = New System.Drawing.Size(552, 86)
        Me.txtObservacionesProgramacion.TabIndex = 109
        '
        'lblObservacionesProgramacion
        '
        Me.lblObservacionesProgramacion.Location = New System.Drawing.Point(4, 430)
        Me.lblObservacionesProgramacion.Name = "lblObservacionesProgramacion"
        Me.lblObservacionesProgramacion.Size = New System.Drawing.Size(129, 54)
        Me.lblObservacionesProgramacion.TabIndex = 108
        Me.lblObservacionesProgramacion.Text = "Observaciones Programación:"
        Me.lblObservacionesProgramacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtObservacionesTejeduria
        '
        Me.txtObservacionesTejeduria.Location = New System.Drawing.Point(139, 338)
        Me.txtObservacionesTejeduria.Multiline = True
        Me.txtObservacionesTejeduria.Name = "txtObservacionesTejeduria"
        Me.txtObservacionesTejeduria.Size = New System.Drawing.Size(552, 86)
        Me.txtObservacionesTejeduria.TabIndex = 107
        '
        'lblObservacionesTejeduria
        '
        Me.lblObservacionesTejeduria.Location = New System.Drawing.Point(4, 338)
        Me.lblObservacionesTejeduria.Name = "lblObservacionesTejeduria"
        Me.lblObservacionesTejeduria.Size = New System.Drawing.Size(129, 54)
        Me.lblObservacionesTejeduria.TabIndex = 106
        Me.lblObservacionesTejeduria.Text = "Observaciones Tejeduría:"
        Me.lblObservacionesTejeduria.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.Location = New System.Drawing.Point(103, 528)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(133, 36)
        Me.cmdCancelar.TabIndex = 105
        Me.cmdCancelar.Text = "CANCELAR"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGuardar.Location = New System.Drawing.Point(462, 530)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(128, 36)
        Me.cmdGuardar.TabIndex = 104
        Me.cmdGuardar.Text = "GUARDAR"
        Me.cmdGuardar.UseVisualStyleBackColor = True
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(139, 246)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(552, 86)
        Me.txtObservaciones.TabIndex = 103
        '
        'lblObservaciones
        '
        Me.lblObservaciones.Location = New System.Drawing.Point(4, 246)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(129, 54)
        Me.lblObservaciones.TabIndex = 102
        Me.lblObservaciones.Text = "Observaciones Control de Calidad:"
        Me.lblObservaciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTalle
        '
        Me.lblTalle.Location = New System.Drawing.Point(71, 100)
        Me.lblTalle.Name = "lblTalle"
        Me.lblTalle.Size = New System.Drawing.Size(62, 23)
        Me.lblTalle.TabIndex = 101
        Me.lblTalle.Text = "Talle:"
        Me.lblTalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbTalle
        '
        Me.cmbTalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTalle.FormattingEnabled = True
        Me.cmbTalle.Location = New System.Drawing.Point(139, 99)
        Me.cmbTalle.Name = "cmbTalle"
        Me.cmbTalle.Size = New System.Drawing.Size(84, 24)
        Me.cmbTalle.TabIndex = 100
        '
        'lblDestino
        '
        Me.lblDestino.Location = New System.Drawing.Point(62, 157)
        Me.lblDestino.Name = "lblDestino"
        Me.lblDestino.Size = New System.Drawing.Size(71, 23)
        Me.lblDestino.TabIndex = 99
        Me.lblDestino.Text = "Destino:"
        Me.lblDestino.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbDestino
        '
        Me.cmbDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDestino.FormattingEnabled = True
        Me.cmbDestino.Location = New System.Drawing.Point(139, 159)
        Me.cmbDestino.Name = "cmbDestino"
        Me.cmbDestino.Size = New System.Drawing.Size(210, 24)
        Me.cmbDestino.TabIndex = 98
        '
        'txtOP
        '
        Me.txtOP.Location = New System.Drawing.Point(139, 41)
        Me.txtOP.Name = "txtOP"
        Me.txtOP.Size = New System.Drawing.Size(84, 23)
        Me.txtOP.TabIndex = 97
        '
        'lblOP
        '
        Me.lblOP.Location = New System.Drawing.Point(36, 40)
        Me.lblOP.Name = "lblOP"
        Me.lblOP.Size = New System.Drawing.Size(97, 23)
        Me.lblOP.TabIndex = 96
        Me.lblOP.Text = "OP:"
        Me.lblOP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOrigen
        '
        Me.lblOrigen.Location = New System.Drawing.Point(59, 127)
        Me.lblOrigen.Name = "lblOrigen"
        Me.lblOrigen.Size = New System.Drawing.Size(74, 23)
        Me.lblOrigen.TabIndex = 95
        Me.lblOrigen.Text = "Origen:"
        Me.lblOrigen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCodArticulo
        '
        Me.txtCodArticulo.Enabled = False
        Me.txtCodArticulo.Location = New System.Drawing.Point(139, 70)
        Me.txtCodArticulo.Name = "txtCodArticulo"
        Me.txtCodArticulo.Size = New System.Drawing.Size(84, 23)
        Me.txtCodArticulo.TabIndex = 94
        '
        'cmbOrigen
        '
        Me.cmbOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrigen.FormattingEnabled = True
        Me.cmbOrigen.Location = New System.Drawing.Point(139, 129)
        Me.cmbOrigen.Name = "cmbOrigen"
        Me.cmbOrigen.Size = New System.Drawing.Size(210, 24)
        Me.cmbOrigen.TabIndex = 93
        '
        'lblCodArticulo
        '
        Me.lblCodArticulo.Location = New System.Drawing.Point(36, 69)
        Me.lblCodArticulo.Name = "lblCodArticulo"
        Me.lblCodArticulo.Size = New System.Drawing.Size(97, 23)
        Me.lblCodArticulo.TabIndex = 92
        Me.lblCodArticulo.Text = "Cód. Artículo:"
        Me.lblCodArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFecha
        '
        Me.dtpFecha.Enabled = False
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(139, 12)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(102, 23)
        Me.dtpFecha.TabIndex = 91
        '
        'lblFecha
        '
        Me.lblFecha.Location = New System.Drawing.Point(25, 12)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(108, 23)
        Me.lblFecha.TabIndex = 90
        Me.lblFecha.Text = "Fecha:"
        Me.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkEs2daEtapa
        '
        Me.chkEs2daEtapa.AutoSize = True
        Me.chkEs2daEtapa.Location = New System.Drawing.Point(139, 219)
        Me.chkEs2daEtapa.Name = "chkEs2daEtapa"
        Me.chkEs2daEtapa.Size = New System.Drawing.Size(112, 21)
        Me.chkEs2daEtapa.TabIndex = 114
        Me.chkEs2daEtapa.Text = "Es 2da Etapa"
        Me.chkEs2daEtapa.UseVisualStyleBackColor = True
        '
        'lblNroCelda
        '
        Me.lblNroCelda.Location = New System.Drawing.Point(12, 187)
        Me.lblNroCelda.Name = "lblNroCelda"
        Me.lblNroCelda.Size = New System.Drawing.Size(121, 23)
        Me.lblNroCelda.TabIndex = 113
        Me.lblNroCelda.Text = "Nro. Celda:"
        Me.lblNroCelda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbNroCelda
        '
        Me.cmbNroCelda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNroCelda.FormattingEnabled = True
        Me.cmbNroCelda.Location = New System.Drawing.Point(139, 189)
        Me.cmbNroCelda.Name = "cmbNroCelda"
        Me.cmbNroCelda.Size = New System.Drawing.Size(84, 24)
        Me.cmbNroCelda.TabIndex = 112
        '
        'frmABMCC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 581)
        Me.Controls.Add(Me.chkEs2daEtapa)
        Me.Controls.Add(Me.lblNroCelda)
        Me.Controls.Add(Me.cmbNroCelda)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.cmbEstado)
        Me.Controls.Add(Me.txtObservacionesProgramacion)
        Me.Controls.Add(Me.lblObservacionesProgramacion)
        Me.Controls.Add(Me.txtObservacionesTejeduria)
        Me.Controls.Add(Me.lblObservacionesTejeduria)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdGuardar)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.lblObservaciones)
        Me.Controls.Add(Me.lblTalle)
        Me.Controls.Add(Me.cmbTalle)
        Me.Controls.Add(Me.lblDestino)
        Me.Controls.Add(Me.cmbDestino)
        Me.Controls.Add(Me.txtOP)
        Me.Controls.Add(Me.lblOP)
        Me.Controls.Add(Me.lblOrigen)
        Me.Controls.Add(Me.txtCodArticulo)
        Me.Controls.Add(Me.cmbOrigen)
        Me.Controls.Add(Me.lblCodArticulo)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.lblFecha)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "frmABMCC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM Control de Calidad"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents txtObservacionesProgramacion As System.Windows.Forms.TextBox
    Friend WithEvents lblObservacionesProgramacion As System.Windows.Forms.Label
    Friend WithEvents txtObservacionesTejeduria As System.Windows.Forms.TextBox
    Friend WithEvents lblObservacionesTejeduria As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdGuardar As System.Windows.Forms.Button
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents lblTalle As System.Windows.Forms.Label
    Friend WithEvents cmbTalle As System.Windows.Forms.ComboBox
    Friend WithEvents lblDestino As System.Windows.Forms.Label
    Friend WithEvents cmbDestino As System.Windows.Forms.ComboBox
    Friend WithEvents txtOP As System.Windows.Forms.TextBox
    Friend WithEvents lblOP As System.Windows.Forms.Label
    Friend WithEvents lblOrigen As System.Windows.Forms.Label
    Friend WithEvents txtCodArticulo As System.Windows.Forms.TextBox
    Friend WithEvents cmbOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents lblCodArticulo As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents chkEs2daEtapa As System.Windows.Forms.CheckBox
    Friend WithEvents lblNroCelda As System.Windows.Forms.Label
    Friend WithEvents cmbNroCelda As System.Windows.Forms.ComboBox
End Class
