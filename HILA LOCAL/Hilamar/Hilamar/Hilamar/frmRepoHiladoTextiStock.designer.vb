<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepoHiladoTextiStock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepoHiladoTextiStock))
        Me.ttAyudasCortas = New System.Windows.Forms.ToolTip(Me.components)
        Me.dgvPartidas = New System.Windows.Forms.DataGridView()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.cmdListar = New System.Windows.Forms.Button()
        Me.txtPartida = New System.Windows.Forms.TextBox()
        Me.lblPartida = New System.Windows.Forms.Label()
        Me.dgvIngresos = New System.Windows.Forms.DataGridView()
        Me.lblTotalIngresos = New System.Windows.Forms.Label()
        Me.dgvPedidos = New System.Windows.Forms.DataGridView()
        Me.lblTotalPedidos = New System.Windows.Forms.Label()
        Me.lblVerPedidos = New System.Windows.Forms.Label()
        Me.cmbFiltroPedidos = New System.Windows.Forms.ComboBox()
        Me.chkVerTerminadas = New System.Windows.Forms.CheckBox()
        Me.btnTerminar = New System.Windows.Forms.Button()
        Me.lblFechaUltimoMovimiento = New System.Windows.Forms.Label()
        CType(Me.dgvPartidas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvPartidas
        '
        Me.dgvPartidas.AllowUserToAddRows = False
        Me.dgvPartidas.AllowUserToDeleteRows = False
        Me.dgvPartidas.AllowUserToResizeColumns = False
        Me.dgvPartidas.AllowUserToResizeRows = False
        Me.dgvPartidas.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvPartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPartidas.Location = New System.Drawing.Point(4, 43)
        Me.dgvPartidas.MultiSelect = False
        Me.dgvPartidas.Name = "dgvPartidas"
        Me.dgvPartidas.RowHeadersWidth = 20
        Me.dgvPartidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPartidas.Size = New System.Drawing.Size(592, 502)
        Me.dgvPartidas.TabIndex = 31
        '
        'cmdSalir
        '
        Me.cmdSalir.Location = New System.Drawing.Point(907, 521)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(96, 24)
        Me.cmdSalir.TabIndex = 100
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'cmdListar
        '
        Me.cmdListar.Location = New System.Drawing.Point(176, 9)
        Me.cmdListar.Name = "cmdListar"
        Me.cmdListar.Size = New System.Drawing.Size(78, 23)
        Me.cmdListar.TabIndex = 101
        Me.cmdListar.Text = "Listar"
        Me.cmdListar.UseVisualStyleBackColor = True
        '
        'txtPartida
        '
        Me.txtPartida.Location = New System.Drawing.Point(62, 11)
        Me.txtPartida.Name = "txtPartida"
        Me.txtPartida.Size = New System.Drawing.Size(108, 20)
        Me.txtPartida.TabIndex = 103
        '
        'lblPartida
        '
        Me.lblPartida.Location = New System.Drawing.Point(12, 9)
        Me.lblPartida.Name = "lblPartida"
        Me.lblPartida.Size = New System.Drawing.Size(44, 23)
        Me.lblPartida.TabIndex = 102
        Me.lblPartida.Text = "Partida:"
        Me.lblPartida.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvIngresos
        '
        Me.dgvIngresos.AllowUserToAddRows = False
        Me.dgvIngresos.AllowUserToDeleteRows = False
        Me.dgvIngresos.AllowUserToResizeColumns = False
        Me.dgvIngresos.AllowUserToResizeRows = False
        Me.dgvIngresos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIngresos.Location = New System.Drawing.Point(602, 43)
        Me.dgvIngresos.MultiSelect = False
        Me.dgvIngresos.Name = "dgvIngresos"
        Me.dgvIngresos.RowHeadersWidth = 20
        Me.dgvIngresos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIngresos.Size = New System.Drawing.Size(410, 179)
        Me.dgvIngresos.TabIndex = 104
        '
        'lblTotalIngresos
        '
        Me.lblTotalIngresos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalIngresos.Location = New System.Drawing.Point(625, 225)
        Me.lblTotalIngresos.Name = "lblTotalIngresos"
        Me.lblTotalIngresos.Size = New System.Drawing.Size(387, 27)
        Me.lblTotalIngresos.TabIndex = 105
        Me.lblTotalIngresos.Text = "TOTAL DE INGRESOS Y DEVOLUCIONES:  0 KGR."
        Me.lblTotalIngresos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvPedidos
        '
        Me.dgvPedidos.AllowUserToAddRows = False
        Me.dgvPedidos.AllowUserToDeleteRows = False
        Me.dgvPedidos.AllowUserToResizeColumns = False
        Me.dgvPedidos.AllowUserToResizeRows = False
        Me.dgvPedidos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPedidos.Location = New System.Drawing.Point(602, 295)
        Me.dgvPedidos.MultiSelect = False
        Me.dgvPedidos.Name = "dgvPedidos"
        Me.dgvPedidos.RowHeadersWidth = 20
        Me.dgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPedidos.Size = New System.Drawing.Size(410, 181)
        Me.dgvPedidos.TabIndex = 106
        '
        'lblTotalPedidos
        '
        Me.lblTotalPedidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPedidos.Location = New System.Drawing.Point(622, 479)
        Me.lblTotalPedidos.Name = "lblTotalPedidos"
        Me.lblTotalPedidos.Size = New System.Drawing.Size(390, 27)
        Me.lblTotalPedidos.TabIndex = 107
        Me.lblTotalPedidos.Text = "TOTAL DE PEDIDOS:  0 KGR."
        Me.lblTotalPedidos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVerPedidos
        '
        Me.lblVerPedidos.Location = New System.Drawing.Point(823, 269)
        Me.lblVerPedidos.Name = "lblVerPedidos"
        Me.lblVerPedidos.Size = New System.Drawing.Size(50, 23)
        Me.lblVerPedidos.TabIndex = 108
        Me.lblVerPedidos.Text = "VER:"
        Me.lblVerPedidos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbFiltroPedidos
        '
        Me.cmbFiltroPedidos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFiltroPedidos.FormattingEnabled = True
        Me.cmbFiltroPedidos.Location = New System.Drawing.Point(879, 268)
        Me.cmbFiltroPedidos.Name = "cmbFiltroPedidos"
        Me.cmbFiltroPedidos.Size = New System.Drawing.Size(125, 21)
        Me.cmbFiltroPedidos.TabIndex = 109
        '
        'chkVerTerminadas
        '
        Me.chkVerTerminadas.AutoSize = True
        Me.chkVerTerminadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVerTerminadas.Location = New System.Drawing.Point(290, 11)
        Me.chkVerTerminadas.Name = "chkVerTerminadas"
        Me.chkVerTerminadas.Size = New System.Drawing.Size(124, 20)
        Me.chkVerTerminadas.TabIndex = 110
        Me.chkVerTerminadas.Text = "Ver Terminadas"
        Me.chkVerTerminadas.UseVisualStyleBackColor = True
        '
        'btnTerminar
        '
        Me.btnTerminar.Location = New System.Drawing.Point(453, 9)
        Me.btnTerminar.Name = "btnTerminar"
        Me.btnTerminar.Size = New System.Drawing.Size(143, 23)
        Me.btnTerminar.TabIndex = 111
        Me.btnTerminar.Text = "Terminar Partida"
        Me.btnTerminar.UseVisualStyleBackColor = True
        '
        'lblFechaUltimoMovimiento
        '
        Me.lblFechaUltimoMovimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFechaUltimoMovimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaUltimoMovimiento.Location = New System.Drawing.Point(661, 9)
        Me.lblFechaUltimoMovimiento.Name = "lblFechaUltimoMovimiento"
        Me.lblFechaUltimoMovimiento.Size = New System.Drawing.Size(296, 23)
        Me.lblFechaUltimoMovimiento.TabIndex = 112
        Me.lblFechaUltimoMovimiento.Text = "Último movimiento cargado el día"
        Me.lblFechaUltimoMovimiento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmRepoHiladoTextiStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1017, 559)
        Me.Controls.Add(Me.lblFechaUltimoMovimiento)
        Me.Controls.Add(Me.btnTerminar)
        Me.Controls.Add(Me.chkVerTerminadas)
        Me.Controls.Add(Me.cmbFiltroPedidos)
        Me.Controls.Add(Me.lblVerPedidos)
        Me.Controls.Add(Me.lblTotalPedidos)
        Me.Controls.Add(Me.dgvPedidos)
        Me.Controls.Add(Me.lblTotalIngresos)
        Me.Controls.Add(Me.dgvIngresos)
        Me.Controls.Add(Me.txtPartida)
        Me.Controls.Add(Me.lblPartida)
        Me.Controls.Add(Me.cmdListar)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.dgvPartidas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmRepoHiladoTextiStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Stock de Hilados en Textilana"
        CType(Me.dgvPartidas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvIngresos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ttAyudasCortas As System.Windows.Forms.ToolTip
    Friend WithEvents dgvPartidas As System.Windows.Forms.DataGridView
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents cmdListar As System.Windows.Forms.Button
    Friend WithEvents txtPartida As System.Windows.Forms.TextBox
    Friend WithEvents lblPartida As System.Windows.Forms.Label
    Friend WithEvents dgvIngresos As System.Windows.Forms.DataGridView
    Friend WithEvents lblTotalIngresos As System.Windows.Forms.Label
    Friend WithEvents dgvPedidos As System.Windows.Forms.DataGridView
    Friend WithEvents lblTotalPedidos As System.Windows.Forms.Label
    Friend WithEvents lblVerPedidos As System.Windows.Forms.Label
    Friend WithEvents cmbFiltroPedidos As System.Windows.Forms.ComboBox
    Friend WithEvents chkVerTerminadas As System.Windows.Forms.CheckBox
    Friend WithEvents btnTerminar As System.Windows.Forms.Button
    Friend WithEvents lblFechaUltimoMovimiento As System.Windows.Forms.Label
End Class
