<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FUA
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
        Me.ImagenArchivo = New System.Windows.Forms.PictureBox()
        Me.dgvFOA = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Observaciones = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.ImagenArchivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFOA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImagenArchivo
        '
        Me.ImagenArchivo.Location = New System.Drawing.Point(698, 12)
        Me.ImagenArchivo.Name = "ImagenArchivo"
        Me.ImagenArchivo.Size = New System.Drawing.Size(430, 638)
        Me.ImagenArchivo.TabIndex = 0
        Me.ImagenArchivo.TabStop = False
        '
        'dgvFOA
        '
        Me.dgvFOA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFOA.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Column1, Me.Observaciones, Me.Estado})
        Me.dgvFOA.Location = New System.Drawing.Point(12, 12)
        Me.dgvFOA.Name = "dgvFOA"
        Me.dgvFOA.RowHeadersVisible = False
        Me.dgvFOA.Size = New System.Drawing.Size(680, 638)
        Me.dgvFOA.TabIndex = 1
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "Usuario"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Observaciones
        '
        Me.Observaciones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Observaciones.HeaderText = "Observaciones"
        Me.Observaciones.Name = "Observaciones"
        '
        'Estado
        '
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.Width = 90
        '
        'FUA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1140, 662)
        Me.Controls.Add(Me.dgvFOA)
        Me.Controls.Add(Me.ImagenArchivo)
        Me.Name = "FUA"
        Me.Text = "Form1"
        CType(Me.ImagenArchivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFOA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImagenArchivo As System.Windows.Forms.PictureBox
    Friend WithEvents dgvFOA As System.Windows.Forms.DataGridView
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Observaciones As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
