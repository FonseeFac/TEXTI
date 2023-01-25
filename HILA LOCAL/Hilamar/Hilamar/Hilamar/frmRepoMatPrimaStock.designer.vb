<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepoMatPrimaStock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepoMatPrimaStock))
        Me.cmdVolver = New System.Windows.Forms.Button()
        Me.cmdExcel = New System.Windows.Forms.Button()
        Me.cmdImpPlanilla = New System.Windows.Forms.Button()
        Me.pdoImpExistencia = New System.Drawing.Printing.PrintDocument()
        Me.SuspendLayout()
        '
        'cmdVolver
        '
        Me.cmdVolver.Location = New System.Drawing.Point(535, 327)
        Me.cmdVolver.Name = "cmdVolver"
        Me.cmdVolver.Size = New System.Drawing.Size(75, 29)
        Me.cmdVolver.TabIndex = 4
        Me.cmdVolver.Text = "Volver"
        Me.cmdVolver.UseVisualStyleBackColor = True
        '
        'cmdExcel
        '
        Me.cmdExcel.Location = New System.Drawing.Point(535, 50)
        Me.cmdExcel.Name = "cmdExcel"
        Me.cmdExcel.Size = New System.Drawing.Size(75, 30)
        Me.cmdExcel.TabIndex = 117
        Me.cmdExcel.Text = "Excel"
        Me.cmdExcel.UseVisualStyleBackColor = True
        '
        'cmdImpPlanilla
        '
        Me.cmdImpPlanilla.Location = New System.Drawing.Point(535, 143)
        Me.cmdImpPlanilla.Name = "cmdImpPlanilla"
        Me.cmdImpPlanilla.Size = New System.Drawing.Size(75, 30)
        Me.cmdImpPlanilla.TabIndex = 115
        Me.cmdImpPlanilla.Text = "Imprimir"
        Me.cmdImpPlanilla.UseVisualStyleBackColor = True
        '
        'frmRepoMatPrimaStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(649, 387)
        Me.Controls.Add(Me.cmdExcel)
        Me.Controls.Add(Me.cmdImpPlanilla)
        Me.Controls.Add(Me.cmdVolver)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmRepoMatPrimaStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Existencia de Materia Prima"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdVolver As System.Windows.Forms.Button
    Friend WithEvents cmdExcel As System.Windows.Forms.Button
    Friend WithEvents cmdImpPlanilla As System.Windows.Forms.Button
    Friend WithEvents pdoImpExistencia As System.Drawing.Printing.PrintDocument
End Class
