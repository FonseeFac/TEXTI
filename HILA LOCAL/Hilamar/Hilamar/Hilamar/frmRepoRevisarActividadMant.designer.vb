<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepoRevisarActividadMant
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepoRevisarActividadMant))
        Me.dtpAPartirDe = New System.Windows.Forms.DateTimePicker()
        Me.cmbEstados = New System.Windows.Forms.ComboBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.cmbSectores = New System.Windows.Forms.ComboBox()
        Me.lblSector = New System.Windows.Forms.Label()
        Me.dgvListado = New System.Windows.Forms.DataGridView()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.lblTitAPartirDe = New System.Windows.Forms.Label()
        Me.cmbPlantas = New System.Windows.Forms.ComboBox()
        Me.lblPlanta = New System.Windows.Forms.Label()
        Me.cmbMaquina = New System.Windows.Forms.ComboBox()
        Me.lblMaquina = New System.Windows.Forms.Label()
        Me.dgvHistorial = New System.Windows.Forms.DataGridView()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvHistorial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpAPartirDe
        '
        Me.dtpAPartirDe.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpAPartirDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpAPartirDe.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAPartirDe.Location = New System.Drawing.Point(841, 42)
        Me.dtpAPartirDe.Name = "dtpAPartirDe"
        Me.dtpAPartirDe.Size = New System.Drawing.Size(104, 22)
        Me.dtpAPartirDe.TabIndex = 108
        '
        'cmbEstados
        '
        Me.cmbEstados.FormattingEnabled = True
        Me.cmbEstados.Location = New System.Drawing.Point(1014, 42)
        Me.cmbEstados.Name = "cmbEstados"
        Me.cmbEstados.Size = New System.Drawing.Size(130, 21)
        Me.cmbEstados.TabIndex = 103
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.Location = New System.Drawing.Point(951, 43)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(70, 20)
        Me.lblEstado.TabIndex = 102
        Me.lblEstado.Text = "Estado:"
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Location = New System.Drawing.Point(528, 13)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(94, 40)
        Me.btnFiltrar.TabIndex = 101
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'cmbSectores
        '
        Me.cmbSectores.FormattingEnabled = True
        Me.cmbSectores.Location = New System.Drawing.Point(264, 13)
        Me.cmbSectores.Name = "cmbSectores"
        Me.cmbSectores.Size = New System.Drawing.Size(227, 21)
        Me.cmbSectores.TabIndex = 100
        '
        'lblSector
        '
        Me.lblSector.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSector.Location = New System.Drawing.Point(201, 15)
        Me.lblSector.Name = "lblSector"
        Me.lblSector.Size = New System.Drawing.Size(55, 20)
        Me.lblSector.TabIndex = 99
        Me.lblSector.Text = "Sector:"
        Me.lblSector.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvListado
        '
        Me.dgvListado.AllowUserToAddRows = False
        Me.dgvListado.AllowUserToDeleteRows = False
        Me.dgvListado.AllowUserToResizeColumns = False
        Me.dgvListado.AllowUserToResizeRows = False
        Me.dgvListado.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListado.Location = New System.Drawing.Point(10, 78)
        Me.dgvListado.MultiSelect = False
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.RowHeadersWidth = 25
        Me.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListado.Size = New System.Drawing.Size(694, 387)
        Me.dgvListado.TabIndex = 98
        '
        'cmdSalir
        '
        Me.cmdSalir.Location = New System.Drawing.Point(973, 478)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(110, 27)
        Me.cmdSalir.TabIndex = 97
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'lblTitAPartirDe
        '
        Me.lblTitAPartirDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitAPartirDe.Location = New System.Drawing.Point(760, 43)
        Me.lblTitAPartirDe.Name = "lblTitAPartirDe"
        Me.lblTitAPartirDe.Size = New System.Drawing.Size(85, 20)
        Me.lblTitAPartirDe.TabIndex = 109
        Me.lblTitAPartirDe.Text = "A partir del:"
        Me.lblTitAPartirDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbPlantas
        '
        Me.cmbPlantas.FormattingEnabled = True
        Me.cmbPlantas.Location = New System.Drawing.Point(91, 13)
        Me.cmbPlantas.Name = "cmbPlantas"
        Me.cmbPlantas.Size = New System.Drawing.Size(105, 21)
        Me.cmbPlantas.TabIndex = 111
        '
        'lblPlanta
        '
        Me.lblPlanta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlanta.Location = New System.Drawing.Point(10, 15)
        Me.lblPlanta.Name = "lblPlanta"
        Me.lblPlanta.Size = New System.Drawing.Size(85, 20)
        Me.lblPlanta.TabIndex = 110
        Me.lblPlanta.Text = "Planta:"
        Me.lblPlanta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbMaquina
        '
        Me.cmbMaquina.FormattingEnabled = True
        Me.cmbMaquina.Location = New System.Drawing.Point(91, 40)
        Me.cmbMaquina.Name = "cmbMaquina"
        Me.cmbMaquina.Size = New System.Drawing.Size(349, 21)
        Me.cmbMaquina.TabIndex = 113
        '
        'lblMaquina
        '
        Me.lblMaquina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaquina.Location = New System.Drawing.Point(10, 41)
        Me.lblMaquina.Name = "lblMaquina"
        Me.lblMaquina.Size = New System.Drawing.Size(85, 20)
        Me.lblMaquina.TabIndex = 112
        Me.lblMaquina.Text = "Máquina:"
        Me.lblMaquina.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvHistorial
        '
        Me.dgvHistorial.AllowUserToAddRows = False
        Me.dgvHistorial.AllowUserToDeleteRows = False
        Me.dgvHistorial.AllowUserToResizeColumns = False
        Me.dgvHistorial.AllowUserToResizeRows = False
        Me.dgvHistorial.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHistorial.Location = New System.Drawing.Point(710, 78)
        Me.dgvHistorial.MultiSelect = False
        Me.dgvHistorial.Name = "dgvHistorial"
        Me.dgvHistorial.RowHeadersWidth = 25
        Me.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvHistorial.Size = New System.Drawing.Size(503, 387)
        Me.dgvHistorial.TabIndex = 114
        '
        'frmRepoRevisarActividadMant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1225, 517)
        Me.Controls.Add(Me.dgvHistorial)
        Me.Controls.Add(Me.cmbMaquina)
        Me.Controls.Add(Me.lblMaquina)
        Me.Controls.Add(Me.cmbPlantas)
        Me.Controls.Add(Me.lblPlanta)
        Me.Controls.Add(Me.dtpAPartirDe)
        Me.Controls.Add(Me.cmbEstados)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.btnFiltrar)
        Me.Controls.Add(Me.cmbSectores)
        Me.Controls.Add(Me.lblSector)
        Me.Controls.Add(Me.dgvListado)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.lblTitAPartirDe)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmRepoRevisarActividadMant"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Actividades de Mantenimiento"
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvHistorial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtpAPartirDe As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbEstados As System.Windows.Forms.ComboBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents btnFiltrar As System.Windows.Forms.Button
    Friend WithEvents cmbSectores As System.Windows.Forms.ComboBox
    Friend WithEvents lblSector As System.Windows.Forms.Label
    Friend WithEvents dgvListado As System.Windows.Forms.DataGridView
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents lblTitAPartirDe As System.Windows.Forms.Label
    Friend WithEvents cmbPlantas As System.Windows.Forms.ComboBox
    Friend WithEvents lblPlanta As System.Windows.Forms.Label
    Friend WithEvents cmbMaquina As System.Windows.Forms.ComboBox
    Friend WithEvents lblMaquina As System.Windows.Forms.Label
    Friend WithEvents dgvHistorial As System.Windows.Forms.DataGridView
End Class
