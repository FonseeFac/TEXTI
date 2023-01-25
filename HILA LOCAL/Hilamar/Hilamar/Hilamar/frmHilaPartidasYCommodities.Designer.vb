<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHilaPartidasYCommodities
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
        Me.dgvHilados = New System.Windows.Forms.DataGridView()
        Me.dgvPartidas = New System.Windows.Forms.DataGridView()
        Me.grpHilados = New System.Windows.Forms.GroupBox()
        Me.grpPartidas = New System.Windows.Forms.GroupBox()
        CType(Me.dgvHilados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPartidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpHilados.SuspendLayout()
        Me.grpPartidas.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvHilados
        '
        Me.dgvHilados.AllowUserToAddRows = False
        Me.dgvHilados.AllowUserToDeleteRows = False
        Me.dgvHilados.AllowUserToResizeColumns = False
        Me.dgvHilados.AllowUserToResizeRows = False
        Me.dgvHilados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHilados.Location = New System.Drawing.Point(6, 19)
        Me.dgvHilados.MultiSelect = False
        Me.dgvHilados.Name = "dgvHilados"
        Me.dgvHilados.ReadOnly = True
        Me.dgvHilados.RowHeadersVisible = False
        Me.dgvHilados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvHilados.Size = New System.Drawing.Size(603, 558)
        Me.dgvHilados.TabIndex = 0
        '
        'dgvPartidas
        '
        Me.dgvPartidas.AllowUserToAddRows = False
        Me.dgvPartidas.AllowUserToDeleteRows = False
        Me.dgvPartidas.AllowUserToResizeColumns = False
        Me.dgvPartidas.AllowUserToResizeRows = False
        Me.dgvPartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPartidas.Location = New System.Drawing.Point(6, 19)
        Me.dgvPartidas.MultiSelect = False
        Me.dgvPartidas.Name = "dgvPartidas"
        Me.dgvPartidas.ReadOnly = True
        Me.dgvPartidas.RowHeadersVisible = False
        Me.dgvPartidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPartidas.Size = New System.Drawing.Size(603, 558)
        Me.dgvPartidas.TabIndex = 1
        '
        'grpHilados
        '
        Me.grpHilados.Controls.Add(Me.dgvHilados)
        Me.grpHilados.Location = New System.Drawing.Point(12, 109)
        Me.grpHilados.Name = "grpHilados"
        Me.grpHilados.Size = New System.Drawing.Size(615, 583)
        Me.grpHilados.TabIndex = 2
        Me.grpHilados.TabStop = False
        Me.grpHilados.Text = "Hilados"
        '
        'grpPartidas
        '
        Me.grpPartidas.Controls.Add(Me.dgvPartidas)
        Me.grpPartidas.Location = New System.Drawing.Point(633, 109)
        Me.grpPartidas.Name = "grpPartidas"
        Me.grpPartidas.Size = New System.Drawing.Size(615, 583)
        Me.grpPartidas.TabIndex = 3
        Me.grpPartidas.TabStop = False
        Me.grpPartidas.Text = "Partidas"
        '
        'frmHilaPartidasYCommodities
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1432, 704)
        Me.Controls.Add(Me.grpPartidas)
        Me.Controls.Add(Me.grpHilados)
        Me.Name = "frmHilaPartidasYCommodities"
        Me.Text = "frmHilaPartidasYCommodities"
        CType(Me.dgvHilados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPartidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpHilados.ResumeLayout(False)
        Me.grpPartidas.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvHilados As System.Windows.Forms.DataGridView
    Friend WithEvents dgvPartidas As System.Windows.Forms.DataGridView
    Friend WithEvents grpHilados As System.Windows.Forms.GroupBox
    Friend WithEvents grpPartidas As System.Windows.Forms.GroupBox
End Class
