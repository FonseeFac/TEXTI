<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBorrarRepoHiladoIngRepoTotales
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBorrarRepoHiladoIngRepoTotales))
        Me.ttAyudasCortas = New System.Windows.Forms.ToolTip(Me.components)
        Me.dgvMovimientos = New System.Windows.Forms.DataGridView()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.gbTipoReporte = New System.Windows.Forms.GroupBox()
        Me.cmbMeses = New System.Windows.Forms.ComboBox()
        Me.rbDiario = New System.Windows.Forms.RadioButton()
        Me.lblMes = New System.Windows.Forms.Label()
        Me.rbMensual = New System.Windows.Forms.RadioButton()
        CType(Me.dgvMovimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTipoReporte.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvMovimientos
        '
        Me.dgvMovimientos.AllowUserToAddRows = False
        Me.dgvMovimientos.AllowUserToDeleteRows = False
        Me.dgvMovimientos.AllowUserToResizeColumns = False
        Me.dgvMovimientos.AllowUserToResizeRows = False
        Me.dgvMovimientos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMovimientos.Location = New System.Drawing.Point(11, 94)
        Me.dgvMovimientos.MultiSelect = False
        Me.dgvMovimientos.Name = "dgvMovimientos"
        Me.dgvMovimientos.RowHeadersWidth = 20
        Me.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMovimientos.Size = New System.Drawing.Size(434, 430)
        Me.dgvMovimientos.TabIndex = 34
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(371, 30)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 33
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'gbTipoReporte
        '
        Me.gbTipoReporte.Controls.Add(Me.cmbMeses)
        Me.gbTipoReporte.Controls.Add(Me.rbDiario)
        Me.gbTipoReporte.Controls.Add(Me.lblMes)
        Me.gbTipoReporte.Controls.Add(Me.rbMensual)
        Me.gbTipoReporte.Location = New System.Drawing.Point(13, 13)
        Me.gbTipoReporte.Name = "gbTipoReporte"
        Me.gbTipoReporte.Size = New System.Drawing.Size(325, 72)
        Me.gbTipoReporte.TabIndex = 35
        Me.gbTipoReporte.TabStop = False
        Me.gbTipoReporte.Text = "Tipo de Reporte"
        '
        'cmbMeses
        '
        Me.cmbMeses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMeses.FormattingEnabled = True
        Me.cmbMeses.Location = New System.Drawing.Point(161, 16)
        Me.cmbMeses.Name = "cmbMeses"
        Me.cmbMeses.Size = New System.Drawing.Size(126, 21)
        Me.cmbMeses.TabIndex = 3
        '
        'rbDiario
        '
        Me.rbDiario.AutoSize = True
        Me.rbDiario.Location = New System.Drawing.Point(32, 20)
        Me.rbDiario.Name = "rbDiario"
        Me.rbDiario.Size = New System.Drawing.Size(62, 17)
        Me.rbDiario.TabIndex = 1
        Me.rbDiario.TabStop = True
        Me.rbDiario.Text = "DIARIO"
        Me.rbDiario.UseVisualStyleBackColor = True
        '
        'lblMes
        '
        Me.lblMes.Location = New System.Drawing.Point(111, 17)
        Me.lblMes.Name = "lblMes"
        Me.lblMes.Size = New System.Drawing.Size(44, 23)
        Me.lblMes.TabIndex = 2
        Me.lblMes.Text = "Mes:"
        Me.lblMes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rbMensual
        '
        Me.rbMensual.AutoSize = True
        Me.rbMensual.Location = New System.Drawing.Point(32, 49)
        Me.rbMensual.Name = "rbMensual"
        Me.rbMensual.Size = New System.Drawing.Size(77, 17)
        Me.rbMensual.TabIndex = 0
        Me.rbMensual.TabStop = True
        Me.rbMensual.Text = "MENSUAL"
        Me.rbMensual.UseVisualStyleBackColor = True
        '
        'frmRepoHiladoIngRepoTotales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(462, 536)
        Me.Controls.Add(Me.gbTipoReporte)
        Me.Controls.Add(Me.dgvMovimientos)
        Me.Controls.Add(Me.btnSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmRepoHiladoIngRepoTotales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Textilana - Reporte de Ingresos Totales de Hilado"
        CType(Me.dgvMovimientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbTipoReporte.ResumeLayout(False)
        Me.gbTipoReporte.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ttAyudasCortas As System.Windows.Forms.ToolTip
    Friend WithEvents dgvMovimientos As System.Windows.Forms.DataGridView
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents gbTipoReporte As System.Windows.Forms.GroupBox
    Friend WithEvents rbDiario As System.Windows.Forms.RadioButton
    Friend WithEvents rbMensual As System.Windows.Forms.RadioButton
    Friend WithEvents cmbMeses As System.Windows.Forms.ComboBox
    Friend WithEvents lblMes As System.Windows.Forms.Label
End Class
