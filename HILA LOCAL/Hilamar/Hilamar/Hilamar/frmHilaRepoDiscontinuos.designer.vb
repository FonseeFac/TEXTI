<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHilaRepoDiscontinuos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHilaRepoDiscontinuos))
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.dgvPartidas = New System.Windows.Forms.DataGridView()
        Me.txtPartida = New System.Windows.Forms.TextBox()
        Me.lblPartida = New System.Windows.Forms.Label()
        Me.cmdListar = New System.Windows.Forms.Button()
        Me.dgvTotales = New System.Windows.Forms.DataGridView()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.pdoImpReporte = New System.Drawing.Printing.PrintDocument()
        CType(Me.dgvPartidas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTotales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.Location = New System.Drawing.Point(962, 14)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 25)
        Me.cmdCancelar.TabIndex = 4
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'dgvPartidas
        '
        Me.dgvPartidas.AllowUserToAddRows = False
        Me.dgvPartidas.AllowUserToDeleteRows = False
        Me.dgvPartidas.AllowUserToResizeColumns = False
        Me.dgvPartidas.AllowUserToResizeRows = False
        Me.dgvPartidas.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvPartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPartidas.Location = New System.Drawing.Point(12, 53)
        Me.dgvPartidas.MultiSelect = False
        Me.dgvPartidas.Name = "dgvPartidas"
        Me.dgvPartidas.RowHeadersWidth = 20
        Me.dgvPartidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPartidas.Size = New System.Drawing.Size(1117, 412)
        Me.dgvPartidas.TabIndex = 32
        '
        'txtPartida
        '
        Me.txtPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartida.Location = New System.Drawing.Point(91, 14)
        Me.txtPartida.Name = "txtPartida"
        Me.txtPartida.Size = New System.Drawing.Size(108, 21)
        Me.txtPartida.TabIndex = 106
        '
        'lblPartida
        '
        Me.lblPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartida.Location = New System.Drawing.Point(21, 12)
        Me.lblPartida.Name = "lblPartida"
        Me.lblPartida.Size = New System.Drawing.Size(64, 23)
        Me.lblPartida.TabIndex = 105
        Me.lblPartida.Text = "Partida:"
        Me.lblPartida.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdListar
        '
        Me.cmdListar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdListar.Location = New System.Drawing.Point(205, 12)
        Me.cmdListar.Name = "cmdListar"
        Me.cmdListar.Size = New System.Drawing.Size(78, 25)
        Me.cmdListar.TabIndex = 104
        Me.cmdListar.Text = "Listar"
        Me.cmdListar.UseVisualStyleBackColor = True
        '
        'dgvTotales
        '
        Me.dgvTotales.AllowUserToAddRows = False
        Me.dgvTotales.AllowUserToDeleteRows = False
        Me.dgvTotales.AllowUserToResizeColumns = False
        Me.dgvTotales.AllowUserToResizeRows = False
        Me.dgvTotales.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvTotales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTotales.ColumnHeadersVisible = False
        Me.dgvTotales.Location = New System.Drawing.Point(12, 465)
        Me.dgvTotales.MultiSelect = False
        Me.dgvTotales.Name = "dgvTotales"
        Me.dgvTotales.RowHeadersWidth = 20
        Me.dgvTotales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvTotales.Size = New System.Drawing.Size(1117, 25)
        Me.dgvTotales.TabIndex = 107
        '
        'btnImprimir
        '
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.Location = New System.Drawing.Point(391, 12)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 25)
        Me.btnImprimir.TabIndex = 108
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'pdoImpReporte
        '
        '
        'frmHilaRepoDiscontinuos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1141, 509)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.dgvTotales)
        Me.Controls.Add(Me.txtPartida)
        Me.Controls.Add(Me.lblPartida)
        Me.Controls.Add(Me.cmdListar)
        Me.Controls.Add(Me.dgvPartidas)
        Me.Controls.Add(Me.cmdCancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmHilaRepoDiscontinuos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Hilados Discontinuos"
        CType(Me.dgvPartidas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTotales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents dgvPartidas As System.Windows.Forms.DataGridView
    Friend WithEvents txtPartida As System.Windows.Forms.TextBox
    Friend WithEvents lblPartida As System.Windows.Forms.Label
    Friend WithEvents cmdListar As System.Windows.Forms.Button
    Friend WithEvents dgvTotales As System.Windows.Forms.DataGridView
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents pdoImpReporte As System.Drawing.Printing.PrintDocument
End Class
