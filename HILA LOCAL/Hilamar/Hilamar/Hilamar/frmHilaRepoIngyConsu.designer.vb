<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHilaRepoIngyConsu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHilaRepoIngyConsu))
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaHasta = New System.Windows.Forms.Label()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaDesde = New System.Windows.Forms.Label()
        Me.lblFiltroHilado = New System.Windows.Forms.Label()
        Me.txtFiltroHilado = New System.Windows.Forms.TextBox()
        Me.lblFiltroPartida = New System.Windows.Forms.Label()
        Me.txtFiltroPartida = New System.Windows.Forms.TextBox()
        Me.cmdListar = New System.Windows.Forms.Button()
        Me.dgvMovimientos = New System.Windows.Forms.DataGridView()
        Me.cmdSalir = New System.Windows.Forms.Button()
        CType(Me.dgvMovimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(313, 9)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(102, 21)
        Me.dtpFechaHasta.TabIndex = 119
        '
        'lblFechaHasta
        '
        Me.lblFechaHasta.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaHasta.Location = New System.Drawing.Point(216, 9)
        Me.lblFechaHasta.Name = "lblFechaHasta"
        Me.lblFechaHasta.Size = New System.Drawing.Size(91, 21)
        Me.lblFechaHasta.TabIndex = 118
        Me.lblFechaHasta.Text = "Fecha Hasta:"
        Me.lblFechaHasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(108, 9)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(102, 21)
        Me.dtpFechaDesde.TabIndex = 117
        '
        'lblFechaDesde
        '
        Me.lblFechaDesde.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaDesde.Location = New System.Drawing.Point(11, 9)
        Me.lblFechaDesde.Name = "lblFechaDesde"
        Me.lblFechaDesde.Size = New System.Drawing.Size(91, 21)
        Me.lblFechaDesde.TabIndex = 116
        Me.lblFechaDesde.Text = "Fecha Desde:"
        Me.lblFechaDesde.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFiltroHilado
        '
        Me.lblFiltroHilado.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFiltroHilado.Location = New System.Drawing.Point(428, 9)
        Me.lblFiltroHilado.Name = "lblFiltroHilado"
        Me.lblFiltroHilado.Size = New System.Drawing.Size(73, 20)
        Me.lblFiltroHilado.TabIndex = 115
        Me.lblFiltroHilado.Text = "Cod Hilado:"
        Me.lblFiltroHilado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFiltroHilado
        '
        Me.txtFiltroHilado.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFiltroHilado.Location = New System.Drawing.Point(507, 7)
        Me.txtFiltroHilado.Name = "txtFiltroHilado"
        Me.txtFiltroHilado.Size = New System.Drawing.Size(110, 21)
        Me.txtFiltroHilado.TabIndex = 114
        '
        'lblFiltroPartida
        '
        Me.lblFiltroPartida.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFiltroPartida.Location = New System.Drawing.Point(644, 9)
        Me.lblFiltroPartida.Name = "lblFiltroPartida"
        Me.lblFiltroPartida.Size = New System.Drawing.Size(55, 20)
        Me.lblFiltroPartida.TabIndex = 113
        Me.lblFiltroPartida.Text = "Partida:"
        Me.lblFiltroPartida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFiltroPartida
        '
        Me.txtFiltroPartida.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFiltroPartida.Location = New System.Drawing.Point(705, 7)
        Me.txtFiltroPartida.Name = "txtFiltroPartida"
        Me.txtFiltroPartida.Size = New System.Drawing.Size(110, 21)
        Me.txtFiltroPartida.TabIndex = 112
        '
        'cmdListar
        '
        Me.cmdListar.Location = New System.Drawing.Point(837, 23)
        Me.cmdListar.Name = "cmdListar"
        Me.cmdListar.Size = New System.Drawing.Size(81, 33)
        Me.cmdListar.TabIndex = 111
        Me.cmdListar.Text = "LISTAR"
        Me.cmdListar.UseVisualStyleBackColor = True
        '
        'dgvMovimientos
        '
        Me.dgvMovimientos.AllowUserToAddRows = False
        Me.dgvMovimientos.AllowUserToDeleteRows = False
        Me.dgvMovimientos.AllowUserToResizeColumns = False
        Me.dgvMovimientos.AllowUserToResizeRows = False
        Me.dgvMovimientos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMovimientos.Location = New System.Drawing.Point(14, 48)
        Me.dgvMovimientos.MultiSelect = False
        Me.dgvMovimientos.Name = "dgvMovimientos"
        Me.dgvMovimientos.RowHeadersWidth = 20
        Me.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMovimientos.Size = New System.Drawing.Size(802, 380)
        Me.dgvMovimientos.TabIndex = 110
        '
        'cmdSalir
        '
        Me.cmdSalir.Location = New System.Drawing.Point(837, 387)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(81, 29)
        Me.cmdSalir.TabIndex = 109
        Me.cmdSalir.Text = "SALIR"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'frmHilaRepoIngyConsu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(926, 443)
        Me.Controls.Add(Me.dtpFechaHasta)
        Me.Controls.Add(Me.lblFechaHasta)
        Me.Controls.Add(Me.dtpFechaDesde)
        Me.Controls.Add(Me.lblFechaDesde)
        Me.Controls.Add(Me.lblFiltroHilado)
        Me.Controls.Add(Me.txtFiltroHilado)
        Me.Controls.Add(Me.lblFiltroPartida)
        Me.Controls.Add(Me.txtFiltroPartida)
        Me.Controls.Add(Me.cmdListar)
        Me.Controls.Add(Me.dgvMovimientos)
        Me.Controls.Add(Me.cmdSalir)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmHilaRepoIngyConsu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Ingresos de Hilados"
        CType(Me.dgvMovimientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaHasta As System.Windows.Forms.Label
    Friend WithEvents dtpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaDesde As System.Windows.Forms.Label
    Friend WithEvents lblFiltroHilado As System.Windows.Forms.Label
    Friend WithEvents txtFiltroHilado As System.Windows.Forms.TextBox
    Friend WithEvents lblFiltroPartida As System.Windows.Forms.Label
    Friend WithEvents txtFiltroPartida As System.Windows.Forms.TextBox
    Friend WithEvents cmdListar As System.Windows.Forms.Button
    Friend WithEvents dgvMovimientos As System.Windows.Forms.DataGridView
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
End Class
