<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfigHilamar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfigHilamar))
        Me.cmdVolver = New System.Windows.Forms.Button()
        Me.gbCotizaciones = New System.Windows.Forms.GroupBox()
        Me.cmdGuardarCotizacionDolar = New System.Windows.Forms.Button()
        Me.txtCotizacionDolar = New System.Windows.Forms.TextBox()
        Me.lblCotizacionDolar = New System.Windows.Forms.Label()
        Me.gbCotizaciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdVolver
        '
        Me.cmdVolver.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdVolver.Location = New System.Drawing.Point(496, 110)
        Me.cmdVolver.Name = "cmdVolver"
        Me.cmdVolver.Size = New System.Drawing.Size(81, 27)
        Me.cmdVolver.TabIndex = 9
        Me.cmdVolver.Text = "Volver"
        Me.cmdVolver.UseVisualStyleBackColor = True
        '
        'gbCotizaciones
        '
        Me.gbCotizaciones.Controls.Add(Me.cmdGuardarCotizacionDolar)
        Me.gbCotizaciones.Controls.Add(Me.txtCotizacionDolar)
        Me.gbCotizaciones.Controls.Add(Me.lblCotizacionDolar)
        Me.gbCotizaciones.Location = New System.Drawing.Point(12, 12)
        Me.gbCotizaciones.Name = "gbCotizaciones"
        Me.gbCotizaciones.Size = New System.Drawing.Size(383, 50)
        Me.gbCotizaciones.TabIndex = 123
        Me.gbCotizaciones.TabStop = False
        '
        'cmdGuardarCotizacionDolar
        '
        Me.cmdGuardarCotizacionDolar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGuardarCotizacionDolar.Location = New System.Drawing.Point(241, 13)
        Me.cmdGuardarCotizacionDolar.Name = "cmdGuardarCotizacionDolar"
        Me.cmdGuardarCotizacionDolar.Size = New System.Drawing.Size(81, 27)
        Me.cmdGuardarCotizacionDolar.TabIndex = 129
        Me.cmdGuardarCotizacionDolar.Text = "Guardar"
        Me.cmdGuardarCotizacionDolar.UseVisualStyleBackColor = True
        '
        'txtCotizacionDolar
        '
        Me.txtCotizacionDolar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCotizacionDolar.Location = New System.Drawing.Point(153, 16)
        Me.txtCotizacionDolar.Name = "txtCotizacionDolar"
        Me.txtCotizacionDolar.Size = New System.Drawing.Size(72, 22)
        Me.txtCotizacionDolar.TabIndex = 126
        '
        'lblCotizacionDolar
        '
        Me.lblCotizacionDolar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCotizacionDolar.Location = New System.Drawing.Point(23, 16)
        Me.lblCotizacionDolar.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCotizacionDolar.Name = "lblCotizacionDolar"
        Me.lblCotizacionDolar.Size = New System.Drawing.Size(131, 22)
        Me.lblCotizacionDolar.TabIndex = 125
        Me.lblCotizacionDolar.Text = "Cotización Dolar:"
        Me.lblCotizacionDolar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmConfigHilamar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 161)
        Me.Controls.Add(Me.gbCotizaciones)
        Me.Controls.Add(Me.cmdVolver)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfigHilamar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Hilamar. Configuración de parámetros"
        Me.gbCotizaciones.ResumeLayout(False)
        Me.gbCotizaciones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdVolver As System.Windows.Forms.Button
    Friend WithEvents gbCotizaciones As System.Windows.Forms.GroupBox
    Friend WithEvents txtCotizacionDolar As System.Windows.Forms.TextBox
    Friend WithEvents lblCotizacionDolar As System.Windows.Forms.Label
    Friend WithEvents cmdGuardarCotizacionDolar As System.Windows.Forms.Button
End Class
