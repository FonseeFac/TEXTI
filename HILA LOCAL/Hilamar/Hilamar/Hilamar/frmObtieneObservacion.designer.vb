<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmObtieneObservacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmObtieneObservacion))
        Me.lblCartel = New System.Windows.Forms.Label()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.lblNroLegajo = New System.Windows.Forms.Label()
        Me.txtNroLegajo = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lblCartel
        '
        Me.lblCartel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCartel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCartel.Location = New System.Drawing.Point(12, 9)
        Me.lblCartel.Name = "lblCartel"
        Me.lblCartel.Size = New System.Drawing.Size(383, 23)
        Me.lblCartel.TabIndex = 20
        Me.lblCartel.Text = "-----"
        Me.lblCartel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Location = New System.Drawing.Point(76, 116)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(105, 41)
        Me.cmdOK.TabIndex = 44
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.Location = New System.Drawing.Point(209, 116)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(104, 41)
        Me.cmdCancelar.TabIndex = 45
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'lblNroLegajo
        '
        Me.lblNroLegajo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNroLegajo.Location = New System.Drawing.Point(12, 63)
        Me.lblNroLegajo.Name = "lblNroLegajo"
        Me.lblNroLegajo.Size = New System.Drawing.Size(129, 23)
        Me.lblNroLegajo.TabIndex = 46
        Me.lblNroLegajo.Text = "---"
        Me.lblNroLegajo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNroLegajo
        '
        Me.txtNroLegajo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroLegajo.Location = New System.Drawing.Point(147, 58)
        Me.txtNroLegajo.MaxLength = 6
        Me.txtNroLegajo.Name = "txtNroLegajo"
        Me.txtNroLegajo.Size = New System.Drawing.Size(183, 29)
        Me.txtNroLegajo.TabIndex = 0
        Me.txtNroLegajo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmObtieneObservacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(407, 169)
        Me.Controls.Add(Me.txtNroLegajo)
        Me.Controls.Add(Me.lblNroLegajo)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lblCartel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmObtieneObservacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "---"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCartel As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents lblNroLegajo As System.Windows.Forms.Label
    Friend WithEvents txtNroLegajo As System.Windows.Forms.TextBox
End Class
