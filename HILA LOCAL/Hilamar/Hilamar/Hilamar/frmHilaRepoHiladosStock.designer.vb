<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHilaRepoHiladosStock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHilaRepoHiladosStock))
        Me.dgvHilados = New System.Windows.Forms.DataGridView()
        Me.cmdImpPlanilla = New System.Windows.Forms.Button()
        Me.pdoImpExistencias = New System.Drawing.Printing.PrintDocument()
        Me.txtCodArtDesde = New System.Windows.Forms.TextBox()
        Me.lblCodArtDesde = New System.Windows.Forms.Label()
        Me.cmdListar = New System.Windows.Forms.Button()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.txtCodArtHasta = New System.Windows.Forms.TextBox()
        Me.lblCodArtHasta = New System.Windows.Forms.Label()
        Me.lblTotalGral = New System.Windows.Forms.Label()
        Me.dgvPartidas = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DiscontinuarPartidaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.NoDiscontinuarPartidaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditarObservaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblTotalHilado = New System.Windows.Forms.Label()
        Me.cmdExcel = New System.Windows.Forms.Button()
        Me.btnProcesoDiario = New System.Windows.Forms.Button()
        Me.lblALaFecha = New System.Windows.Forms.Label()
        Me.dtpALaFecha = New System.Windows.Forms.DateTimePicker()
        CType(Me.dgvHilados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPartidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvHilados
        '
        Me.dgvHilados.AllowUserToAddRows = False
        Me.dgvHilados.AllowUserToDeleteRows = False
        Me.dgvHilados.AllowUserToResizeColumns = False
        Me.dgvHilados.AllowUserToResizeRows = False
        Me.dgvHilados.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvHilados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHilados.Location = New System.Drawing.Point(5, 45)
        Me.dgvHilados.MultiSelect = False
        Me.dgvHilados.Name = "dgvHilados"
        Me.dgvHilados.RowHeadersWidth = 20
        Me.dgvHilados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvHilados.Size = New System.Drawing.Size(429, 426)
        Me.dgvHilados.TabIndex = 30
        '
        'cmdImpPlanilla
        '
        Me.cmdImpPlanilla.Location = New System.Drawing.Point(639, 9)
        Me.cmdImpPlanilla.Name = "cmdImpPlanilla"
        Me.cmdImpPlanilla.Size = New System.Drawing.Size(59, 24)
        Me.cmdImpPlanilla.TabIndex = 31
        Me.cmdImpPlanilla.Text = "Imprimir"
        Me.cmdImpPlanilla.UseVisualStyleBackColor = True
        '
        'pdoImpExistencias
        '
        '
        'txtCodArtDesde
        '
        Me.txtCodArtDesde.Location = New System.Drawing.Point(99, 11)
        Me.txtCodArtDesde.Name = "txtCodArtDesde"
        Me.txtCodArtDesde.Size = New System.Drawing.Size(74, 20)
        Me.txtCodArtDesde.TabIndex = 97
        '
        'lblCodArtDesde
        '
        Me.lblCodArtDesde.Location = New System.Drawing.Point(12, 9)
        Me.lblCodArtDesde.Name = "lblCodArtDesde"
        Me.lblCodArtDesde.Size = New System.Drawing.Size(81, 23)
        Me.lblCodArtDesde.TabIndex = 96
        Me.lblCodArtDesde.Text = "CodArt Desde:"
        Me.lblCodArtDesde.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdListar
        '
        Me.cmdListar.Location = New System.Drawing.Point(542, 9)
        Me.cmdListar.Name = "cmdListar"
        Me.cmdListar.Size = New System.Drawing.Size(69, 23)
        Me.cmdListar.TabIndex = 98
        Me.cmdListar.Text = "Listar"
        Me.cmdListar.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.Location = New System.Drawing.Point(993, 12)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(96, 24)
        Me.cmdSalir.TabIndex = 99
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'txtCodArtHasta
        '
        Me.txtCodArtHasta.Location = New System.Drawing.Point(266, 11)
        Me.txtCodArtHasta.Name = "txtCodArtHasta"
        Me.txtCodArtHasta.Size = New System.Drawing.Size(74, 20)
        Me.txtCodArtHasta.TabIndex = 101
        '
        'lblCodArtHasta
        '
        Me.lblCodArtHasta.Location = New System.Drawing.Point(179, 9)
        Me.lblCodArtHasta.Name = "lblCodArtHasta"
        Me.lblCodArtHasta.Size = New System.Drawing.Size(81, 23)
        Me.lblCodArtHasta.TabIndex = 100
        Me.lblCodArtHasta.Text = "CodArt Hasta:"
        Me.lblCodArtHasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalGral
        '
        Me.lblTotalGral.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalGral.Location = New System.Drawing.Point(12, 474)
        Me.lblTotalGral.Name = "lblTotalGral"
        Me.lblTotalGral.Size = New System.Drawing.Size(429, 38)
        Me.lblTotalGral.TabIndex = 102
        Me.lblTotalGral.Text = "TOTAL GENERAL EN EXISTENCIA :  0 KGR."
        Me.lblTotalGral.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvPartidas
        '
        Me.dgvPartidas.AllowUserToAddRows = False
        Me.dgvPartidas.AllowUserToDeleteRows = False
        Me.dgvPartidas.AllowUserToResizeColumns = False
        Me.dgvPartidas.AllowUserToResizeRows = False
        Me.dgvPartidas.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvPartidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPartidas.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgvPartidas.Location = New System.Drawing.Point(440, 45)
        Me.dgvPartidas.MultiSelect = False
        Me.dgvPartidas.Name = "dgvPartidas"
        Me.dgvPartidas.RowHeadersWidth = 20
        Me.dgvPartidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPartidas.Size = New System.Drawing.Size(765, 426)
        Me.dgvPartidas.TabIndex = 103
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DiscontinuarPartidaToolStripMenuItem, Me.ToolStripSeparator1, Me.NoDiscontinuarPartidaToolStripMenuItem, Me.ToolStripSeparator2, Me.EditarObservaciónToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(188, 82)
        '
        'DiscontinuarPartidaToolStripMenuItem
        '
        Me.DiscontinuarPartidaToolStripMenuItem.Name = "DiscontinuarPartidaToolStripMenuItem"
        Me.DiscontinuarPartidaToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.DiscontinuarPartidaToolStripMenuItem.Text = "Discontinuar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(184, 6)
        '
        'NoDiscontinuarPartidaToolStripMenuItem
        '
        Me.NoDiscontinuarPartidaToolStripMenuItem.Name = "NoDiscontinuarPartidaToolStripMenuItem"
        Me.NoDiscontinuarPartidaToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.NoDiscontinuarPartidaToolStripMenuItem.Text = "Quitar Discontinuado"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(184, 6)
        '
        'EditarObservaciónToolStripMenuItem
        '
        Me.EditarObservaciónToolStripMenuItem.Name = "EditarObservaciónToolStripMenuItem"
        Me.EditarObservaciónToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.EditarObservaciónToolStripMenuItem.Text = "Editar Observación"
        '
        'lblTotalHilado
        '
        Me.lblTotalHilado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalHilado.Location = New System.Drawing.Point(539, 480)
        Me.lblTotalHilado.Name = "lblTotalHilado"
        Me.lblTotalHilado.Size = New System.Drawing.Size(550, 27)
        Me.lblTotalHilado.TabIndex = 104
        Me.lblTotalHilado.Text = "TOTAL DEL HILADO EN EXISTENCIA :  0 KGR."
        Me.lblTotalHilado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdExcel
        '
        Me.cmdExcel.Location = New System.Drawing.Point(708, 9)
        Me.cmdExcel.Name = "cmdExcel"
        Me.cmdExcel.Size = New System.Drawing.Size(62, 24)
        Me.cmdExcel.TabIndex = 114
        Me.cmdExcel.Text = "Excel"
        Me.cmdExcel.UseVisualStyleBackColor = True
        '
        'btnProcesoDiario
        '
        Me.btnProcesoDiario.Location = New System.Drawing.Point(823, 9)
        Me.btnProcesoDiario.Name = "btnProcesoDiario"
        Me.btnProcesoDiario.Size = New System.Drawing.Size(131, 24)
        Me.btnProcesoDiario.TabIndex = 115
        Me.btnProcesoDiario.Text = "ProcesoDiario"
        Me.btnProcesoDiario.UseVisualStyleBackColor = True
        '
        'lblALaFecha
        '
        Me.lblALaFecha.Location = New System.Drawing.Point(349, 9)
        Me.lblALaFecha.Name = "lblALaFecha"
        Me.lblALaFecha.Size = New System.Drawing.Size(81, 23)
        Me.lblALaFecha.TabIndex = 116
        Me.lblALaFecha.Text = "A LA FECHA:"
        Me.lblALaFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpALaFecha
        '
        Me.dtpALaFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpALaFecha.Location = New System.Drawing.Point(436, 11)
        Me.dtpALaFecha.Name = "dtpALaFecha"
        Me.dtpALaFecha.Size = New System.Drawing.Size(81, 20)
        Me.dtpALaFecha.TabIndex = 117
        '
        'frmHilaRepoHiladosStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1215, 696)
        Me.Controls.Add(Me.dtpALaFecha)
        Me.Controls.Add(Me.lblALaFecha)
        Me.Controls.Add(Me.btnProcesoDiario)
        Me.Controls.Add(Me.cmdExcel)
        Me.Controls.Add(Me.lblTotalHilado)
        Me.Controls.Add(Me.dgvPartidas)
        Me.Controls.Add(Me.lblTotalGral)
        Me.Controls.Add(Me.txtCodArtHasta)
        Me.Controls.Add(Me.lblCodArtHasta)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.cmdListar)
        Me.Controls.Add(Me.txtCodArtDesde)
        Me.Controls.Add(Me.lblCodArtDesde)
        Me.Controls.Add(Me.cmdImpPlanilla)
        Me.Controls.Add(Me.dgvHilados)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmHilaRepoHiladosStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Existencias de Hilados en HILAMAR"
        CType(Me.dgvHilados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPartidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvHilados As System.Windows.Forms.DataGridView
    Friend WithEvents cmdImpPlanilla As System.Windows.Forms.Button
    Friend WithEvents pdoImpExistencias As System.Drawing.Printing.PrintDocument
    Friend WithEvents txtCodArtDesde As System.Windows.Forms.TextBox
    Friend WithEvents lblCodArtDesde As System.Windows.Forms.Label
    Friend WithEvents cmdListar As System.Windows.Forms.Button
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents txtCodArtHasta As System.Windows.Forms.TextBox
    Friend WithEvents lblCodArtHasta As System.Windows.Forms.Label
    Friend WithEvents lblTotalGral As System.Windows.Forms.Label
    Friend WithEvents dgvPartidas As System.Windows.Forms.DataGridView
    Friend WithEvents lblTotalHilado As System.Windows.Forms.Label
    Friend WithEvents cmdExcel As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DiscontinuarPartidaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NoDiscontinuarPartidaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnProcesoDiario As System.Windows.Forms.Button
    Friend WithEvents lblALaFecha As System.Windows.Forms.Label
    Friend WithEvents dtpALaFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditarObservaciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
