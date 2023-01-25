<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPosponerActividades
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPosponerActividades))
        Me.lblFechaCompra = New System.Windows.Forms.Label()
        Me.dtpFechaPospo = New System.Windows.Forms.DateTimePicker()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lblFechaCompra
        '
        Me.lblFechaCompra.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaCompra.Location = New System.Drawing.Point(12, 20)
        Me.lblFechaCompra.Name = "lblFechaCompra"
        Me.lblFechaCompra.Size = New System.Drawing.Size(176, 23)
        Me.lblFechaCompra.TabIndex = 20
        Me.lblFechaCompra.Text = "POSPONER PARA EL DÍA:"
        Me.lblFechaCompra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFechaPospo
        '
        Me.dtpFechaPospo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaPospo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaPospo.Location = New System.Drawing.Point(184, 15)
        Me.dtpFechaPospo.Name = "dtpFechaPospo"
        Me.dtpFechaPospo.Size = New System.Drawing.Size(114, 26)
        Me.dtpFechaPospo.TabIndex = 42
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Location = New System.Drawing.Point(117, 163)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(91, 30)
        Me.cmdOK.TabIndex = 44
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.Location = New System.Drawing.Point(253, 163)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(91, 30)
        Me.cmdCancelar.TabIndex = 45
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'lblObservaciones
        '
        Me.lblObservaciones.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObservaciones.Location = New System.Drawing.Point(12, 58)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(127, 23)
        Me.lblObservaciones.TabIndex = 46
        Me.lblObservaciones.Text = "OBSERVACIONES:"
        Me.lblObservaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservaciones.Location = New System.Drawing.Point(145, 58)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(310, 89)
        Me.txtObservaciones.TabIndex = 252
        '
        'frmPosponerActividades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(467, 205)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.lblObservaciones)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.dtpFechaPospo)
        Me.Controls.Add(Me.lblFechaCompra)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmPosponerActividades"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Posponer Actividades"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblFechaCompra As System.Windows.Forms.Label
    Friend WithEvents dtpFechaPospo As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
End Class
