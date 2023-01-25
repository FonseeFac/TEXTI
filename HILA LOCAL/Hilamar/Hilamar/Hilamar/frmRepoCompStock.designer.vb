<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepoCompStock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepoCompStock))
        Me.cmdListar = New System.Windows.Forms.Button()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaHasta = New System.Windows.Forms.Label()
        Me.lblFechaDesde = New System.Windows.Forms.Label()
        Me.cmbHilados = New System.Windows.Forms.ComboBox()
        Me.lblTipoHilado = New System.Windows.Forms.Label()
        Me.txtFechaPagina = New System.Windows.Forms.TextBox()
        Me.lblFechaPagina = New System.Windows.Forms.Label()
        Me.txtCodArticulo = New System.Windows.Forms.TextBox()
        Me.lblCodArticulo = New System.Windows.Forms.Label()
        Me.cmbGalgas = New System.Windows.Forms.ComboBox()
        Me.lblCodGalga = New System.Windows.Forms.Label()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.pdoImpReporte = New System.Drawing.Printing.PrintDocument()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdListar
        '
        Me.cmdListar.Location = New System.Drawing.Point(850, 39)
        Me.cmdListar.Name = "cmdListar"
        Me.cmdListar.Size = New System.Drawing.Size(94, 31)
        Me.cmdListar.TabIndex = 3
        Me.cmdListar.Text = "Listar"
        Me.cmdListar.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.Location = New System.Drawing.Point(856, 504)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(94, 28)
        Me.cmdSalir.TabIndex = 4
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowUserToAddRows = False
        Me.dgvDatos.AllowUserToDeleteRows = False
        Me.dgvDatos.AllowUserToResizeColumns = False
        Me.dgvDatos.AllowUserToResizeRows = False
        Me.dgvDatos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDatos.Location = New System.Drawing.Point(12, 134)
        Me.dgvDatos.MultiSelect = False
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.ReadOnly = True
        Me.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDatos.Size = New System.Drawing.Size(834, 410)
        Me.dgvDatos.TabIndex = 11
        '
        'dtpHasta
        '
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(106, 44)
        Me.dtpHasta.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(132, 20)
        Me.dtpHasta.TabIndex = 90
        '
        'dtpDesde
        '
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(106, 12)
        Me.dtpDesde.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(132, 20)
        Me.dtpDesde.TabIndex = 89
        '
        'lblFechaHasta
        '
        Me.lblFechaHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaHasta.Location = New System.Drawing.Point(33, 41)
        Me.lblFechaHasta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFechaHasta.Name = "lblFechaHasta"
        Me.lblFechaHasta.Size = New System.Drawing.Size(65, 23)
        Me.lblFechaHasta.TabIndex = 88
        Me.lblFechaHasta.Text = "Hasta:"
        Me.lblFechaHasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFechaDesde
        '
        Me.lblFechaDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaDesde.Location = New System.Drawing.Point(33, 9)
        Me.lblFechaDesde.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFechaDesde.Name = "lblFechaDesde"
        Me.lblFechaDesde.Size = New System.Drawing.Size(65, 23)
        Me.lblFechaDesde.TabIndex = 87
        Me.lblFechaDesde.Text = "Desde:"
        Me.lblFechaDesde.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbHilados
        '
        Me.cmbHilados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHilados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbHilados.FormattingEnabled = True
        Me.cmbHilados.Location = New System.Drawing.Point(391, 11)
        Me.cmbHilados.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbHilados.Name = "cmbHilados"
        Me.cmbHilados.Size = New System.Drawing.Size(217, 21)
        Me.cmbHilados.TabIndex = 92
        '
        'lblTipoHilado
        '
        Me.lblTipoHilado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoHilado.Location = New System.Drawing.Point(290, 11)
        Me.lblTipoHilado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTipoHilado.Name = "lblTipoHilado"
        Me.lblTipoHilado.Size = New System.Drawing.Size(93, 22)
        Me.lblTipoHilado.TabIndex = 91
        Me.lblTipoHilado.Text = "Tipo Hilado:"
        Me.lblTipoHilado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFechaPagina
        '
        Me.txtFechaPagina.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaPagina.Location = New System.Drawing.Point(407, 92)
        Me.txtFechaPagina.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFechaPagina.Name = "txtFechaPagina"
        Me.txtFechaPagina.Size = New System.Drawing.Size(43, 20)
        Me.txtFechaPagina.TabIndex = 100
        Me.txtFechaPagina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFechaPagina
        '
        Me.lblFechaPagina.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaPagina.Location = New System.Drawing.Point(288, 92)
        Me.lblFechaPagina.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFechaPagina.Name = "lblFechaPagina"
        Me.lblFechaPagina.Size = New System.Drawing.Size(112, 23)
        Me.lblFechaPagina.TabIndex = 99
        Me.lblFechaPagina.Text = "Fecha Página:"
        Me.lblFechaPagina.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCodArticulo
        '
        Me.txtCodArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodArticulo.Location = New System.Drawing.Point(187, 92)
        Me.txtCodArticulo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCodArticulo.Name = "txtCodArticulo"
        Me.txtCodArticulo.Size = New System.Drawing.Size(43, 20)
        Me.txtCodArticulo.TabIndex = 102
        Me.txtCodArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCodArticulo
        '
        Me.lblCodArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodArticulo.Location = New System.Drawing.Point(75, 92)
        Me.lblCodArticulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodArticulo.Name = "lblCodArticulo"
        Me.lblCodArticulo.Size = New System.Drawing.Size(104, 23)
        Me.lblCodArticulo.TabIndex = 101
        Me.lblCodArticulo.Text = "Cód. Artículo:"
        Me.lblCodArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbGalgas
        '
        Me.cmbGalgas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGalgas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGalgas.FormattingEnabled = True
        Me.cmbGalgas.Location = New System.Drawing.Point(391, 43)
        Me.cmbGalgas.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbGalgas.Name = "cmbGalgas"
        Me.cmbGalgas.Size = New System.Drawing.Size(217, 21)
        Me.cmbGalgas.TabIndex = 104
        '
        'lblCodGalga
        '
        Me.lblCodGalga.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodGalga.Location = New System.Drawing.Point(294, 43)
        Me.lblCodGalga.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCodGalga.Name = "lblCodGalga"
        Me.lblCodGalga.Size = New System.Drawing.Size(89, 23)
        Me.lblCodGalga.TabIndex = 103
        Me.lblCodGalga.Text = "Tipo Galga:"
        Me.lblCodGalga.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(856, 162)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(94, 31)
        Me.btnImprimir.TabIndex = 105
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'pdoImpReporte
        '
        '
        'frmRepoCompStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(960, 558)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.cmbGalgas)
        Me.Controls.Add(Me.lblCodGalga)
        Me.Controls.Add(Me.txtCodArticulo)
        Me.Controls.Add(Me.lblCodArticulo)
        Me.Controls.Add(Me.txtFechaPagina)
        Me.Controls.Add(Me.lblFechaPagina)
        Me.Controls.Add(Me.cmbHilados)
        Me.Controls.Add(Me.lblTipoHilado)
        Me.Controls.Add(Me.dtpHasta)
        Me.Controls.Add(Me.dtpDesde)
        Me.Controls.Add(Me.lblFechaHasta)
        Me.Controls.Add(Me.lblFechaDesde)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.cmdListar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmRepoCompStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Comparativo anual de Venta, Stock Terminado y Crudo"
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdListar As System.Windows.Forms.Button
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaHasta As System.Windows.Forms.Label
    Friend WithEvents lblFechaDesde As System.Windows.Forms.Label
    Friend WithEvents cmbHilados As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoHilado As System.Windows.Forms.Label
    Friend WithEvents txtFechaPagina As System.Windows.Forms.TextBox
    Friend WithEvents lblFechaPagina As System.Windows.Forms.Label
    Friend WithEvents txtCodArticulo As System.Windows.Forms.TextBox
    Friend WithEvents lblCodArticulo As System.Windows.Forms.Label
    Friend WithEvents cmbGalgas As System.Windows.Forms.ComboBox
    Friend WithEvents lblCodGalga As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents pdoImpReporte As System.Drawing.Printing.PrintDocument
End Class
