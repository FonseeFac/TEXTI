<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgreso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProgreso))
        Me.pgbProgreso = New System.Windows.Forms.ProgressBar()
        Me.lblTarea = New System.Windows.Forms.Label()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'pgbProgreso
        '
        Me.pgbProgreso.Location = New System.Drawing.Point(12, 41)
        Me.pgbProgreso.Name = "pgbProgreso"
        Me.pgbProgreso.Size = New System.Drawing.Size(336, 23)
        Me.pgbProgreso.TabIndex = 0
        '
        'lblTarea
        '
        Me.lblTarea.Location = New System.Drawing.Point(9, 9)
        Me.lblTarea.Name = "lblTarea"
        Me.lblTarea.Size = New System.Drawing.Size(336, 23)
        Me.lblTarea.TabIndex = 1
        Me.lblTarea.Text = "Label1"
        Me.lblTarea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEstado
        '
        Me.lblEstado.Location = New System.Drawing.Point(9, 82)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(339, 23)
        Me.lblEstado.TabIndex = 2
        Me.lblEstado.Text = "Label1"
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmProgreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(360, 121)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.lblTarea)
        Me.Controls.Add(Me.pgbProgreso)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProgreso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Textilana S. A."
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pgbProgreso As System.Windows.Forms.ProgressBar
    Friend WithEvents lblTarea As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label
End Class
