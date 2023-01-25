<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpcionesdeImpresion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOpcionesdeImpresion))
        Me.cmdImprimir = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.chkImprimirTiemposyPesos = New System.Windows.Forms.CheckBox()
        Me.chkDejarEnBlancoMedidasIniciales = New System.Windows.Forms.CheckBox()
        Me.chkCambiarPartColorOP = New System.Windows.Forms.CheckBox()
        Me.lblOp = New System.Windows.Forms.Label()
        Me.txtOp = New System.Windows.Forms.TextBox()
        Me.lblPartida = New System.Windows.Forms.Label()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.txtPartida = New System.Windows.Forms.TextBox()
        Me.txtColor = New System.Windows.Forms.TextBox()
        Me.chkImprimirFechaHoy = New System.Windows.Forms.CheckBox()
        Me.chkImprimirPlanoDeMedidas = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'cmdImprimir
        '
        Me.cmdImprimir.Location = New System.Drawing.Point(288, 248)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(98, 32)
        Me.cmdImprimir.TabIndex = 3
        Me.cmdImprimir.Text = "IMPRIMIR"
        Me.cmdImprimir.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(98, 248)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(98, 32)
        Me.cmdCancelar.TabIndex = 4
        Me.cmdCancelar.Text = "CANCELAR"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'lblTitulo
        '
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(45, 9)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(374, 20)
        Me.lblTitulo.TabIndex = 246
        Me.lblTitulo.Text = "Elija las opciones deseadas para imprimir la planilla"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkImprimirTiemposyPesos
        '
        Me.chkImprimirTiemposyPesos.AutoSize = True
        Me.chkImprimirTiemposyPesos.Checked = True
        Me.chkImprimirTiemposyPesos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkImprimirTiemposyPesos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkImprimirTiemposyPesos.Location = New System.Drawing.Point(201, 40)
        Me.chkImprimirTiemposyPesos.Name = "chkImprimirTiemposyPesos"
        Me.chkImprimirTiemposyPesos.Size = New System.Drawing.Size(272, 20)
        Me.chkImprimirTiemposyPesos.TabIndex = 247
        Me.chkImprimirTiemposyPesos.Text = "Imprimir los Tiempos y Pesos del artículo"
        Me.chkImprimirTiemposyPesos.UseVisualStyleBackColor = True
        '
        'chkDejarEnBlancoMedidasIniciales
        '
        Me.chkDejarEnBlancoMedidasIniciales.AutoSize = True
        Me.chkDejarEnBlancoMedidasIniciales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDejarEnBlancoMedidasIniciales.Location = New System.Drawing.Point(222, 66)
        Me.chkDejarEnBlancoMedidasIniciales.Name = "chkDejarEnBlancoMedidasIniciales"
        Me.chkDejarEnBlancoMedidasIniciales.Size = New System.Drawing.Size(251, 20)
        Me.chkDejarEnBlancoMedidasIniciales.TabIndex = 248
        Me.chkDejarEnBlancoMedidasIniciales.Text = "Dejar en blanco las medidas iniciales"
        Me.chkDejarEnBlancoMedidasIniciales.UseVisualStyleBackColor = True
        '
        'chkCambiarPartColorOP
        '
        Me.chkCambiarPartColorOP.AutoSize = True
        Me.chkCambiarPartColorOP.Checked = True
        Me.chkCambiarPartColorOP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCambiarPartColorOP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCambiarPartColorOP.Location = New System.Drawing.Point(48, 40)
        Me.chkCambiarPartColorOP.Name = "chkCambiarPartColorOP"
        Me.chkCambiarPartColorOP.Size = New System.Drawing.Size(194, 20)
        Me.chkCambiarPartColorOP.TabIndex = 249
        Me.chkCambiarPartColorOP.Text = "Cambiar Partida, Color y OP"
        Me.chkCambiarPartColorOP.UseVisualStyleBackColor = True
        '
        'lblOp
        '
        Me.lblOp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOp.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOp.Location = New System.Drawing.Point(56, 128)
        Me.lblOp.Name = "lblOp"
        Me.lblOp.Size = New System.Drawing.Size(110, 20)
        Me.lblOp.TabIndex = 255
        Me.lblOp.Text = "OP"
        Me.lblOp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtOp
        '
        Me.txtOp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOp.Location = New System.Drawing.Point(172, 128)
        Me.txtOp.Name = "txtOp"
        Me.txtOp.Size = New System.Drawing.Size(113, 20)
        Me.txtOp.TabIndex = 254
        Me.txtOp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblPartida
        '
        Me.lblPartida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartida.Location = New System.Drawing.Point(56, 104)
        Me.lblPartida.Name = "lblPartida"
        Me.lblPartida.Size = New System.Drawing.Size(110, 20)
        Me.lblPartida.TabIndex = 253
        Me.lblPartida.Text = "PARTIDA"
        Me.lblPartida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblColor
        '
        Me.lblColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColor.Location = New System.Drawing.Point(56, 81)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(110, 20)
        Me.lblColor.TabIndex = 252
        Me.lblColor.Text = "COLOR"
        Me.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPartida
        '
        Me.txtPartida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartida.Location = New System.Drawing.Point(172, 104)
        Me.txtPartida.Name = "txtPartida"
        Me.txtPartida.Size = New System.Drawing.Size(113, 20)
        Me.txtPartida.TabIndex = 251
        Me.txtPartida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtColor
        '
        Me.txtColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColor.Location = New System.Drawing.Point(172, 81)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Size = New System.Drawing.Size(271, 20)
        Me.txtColor.TabIndex = 250
        Me.txtColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkImprimirFechaHoy
        '
        Me.chkImprimirFechaHoy.AutoSize = True
        Me.chkImprimirFechaHoy.Checked = True
        Me.chkImprimirFechaHoy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkImprimirFechaHoy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkImprimirFechaHoy.Location = New System.Drawing.Point(48, 164)
        Me.chkImprimirFechaHoy.Name = "chkImprimirFechaHoy"
        Me.chkImprimirFechaHoy.Size = New System.Drawing.Size(176, 20)
        Me.chkImprimirFechaHoy.TabIndex = 256
        Me.chkImprimirFechaHoy.Text = "Imprimir la Fecha de Hoy"
        Me.chkImprimirFechaHoy.UseVisualStyleBackColor = True
        '
        'chkImprimirPlanoDeMedidas
        '
        Me.chkImprimirPlanoDeMedidas.AutoSize = True
        Me.chkImprimirPlanoDeMedidas.Checked = True
        Me.chkImprimirPlanoDeMedidas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkImprimirPlanoDeMedidas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkImprimirPlanoDeMedidas.Location = New System.Drawing.Point(48, 202)
        Me.chkImprimirPlanoDeMedidas.Name = "chkImprimirPlanoDeMedidas"
        Me.chkImprimirPlanoDeMedidas.Size = New System.Drawing.Size(201, 20)
        Me.chkImprimirPlanoDeMedidas.TabIndex = 257
        Me.chkImprimirPlanoDeMedidas.Text = "Imprimir el Plano de Medidas"
        Me.chkImprimirPlanoDeMedidas.UseVisualStyleBackColor = True
        '
        'frmOpcionesdeImpresion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 292)
        Me.Controls.Add(Me.chkImprimirPlanoDeMedidas)
        Me.Controls.Add(Me.chkImprimirFechaHoy)
        Me.Controls.Add(Me.lblOp)
        Me.Controls.Add(Me.txtOp)
        Me.Controls.Add(Me.lblPartida)
        Me.Controls.Add(Me.lblColor)
        Me.Controls.Add(Me.txtPartida)
        Me.Controls.Add(Me.txtColor)
        Me.Controls.Add(Me.chkCambiarPartColorOP)
        Me.Controls.Add(Me.chkDejarEnBlancoMedidasIniciales)
        Me.Controls.Add(Me.chkImprimirTiemposyPesos)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdImprimir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOpcionesdeImpresion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Opciones de Impresión"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdImprimir As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents chkImprimirTiemposyPesos As System.Windows.Forms.CheckBox
    Friend WithEvents chkDejarEnBlancoMedidasIniciales As System.Windows.Forms.CheckBox
    Friend WithEvents chkCambiarPartColorOP As System.Windows.Forms.CheckBox
    Friend WithEvents lblOp As System.Windows.Forms.Label
    Friend WithEvents txtOp As System.Windows.Forms.TextBox
    Friend WithEvents lblPartida As System.Windows.Forms.Label
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents txtPartida As System.Windows.Forms.TextBox
    Friend WithEvents txtColor As System.Windows.Forms.TextBox
    Friend WithEvents chkImprimirFechaHoy As System.Windows.Forms.CheckBox
    Friend WithEvents chkImprimirPlanoDeMedidas As System.Windows.Forms.CheckBox
End Class
