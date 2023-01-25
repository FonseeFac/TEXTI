<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepoMantActivDiaria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepoMantActivDiaria))
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.cmbSectores = New System.Windows.Forms.ComboBox()
        Me.lblSector = New System.Windows.Forms.Label()
        Me.dgvListado = New System.Windows.Forms.DataGridView()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.lblDesde = New System.Windows.Forms.Label()
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.lblHasta = New System.Windows.Forms.Label()
        Me.cmbPlantas = New System.Windows.Forms.ComboBox()
        Me.lblPlanta = New System.Windows.Forms.Label()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpDesde
        '
        Me.dtpDesde.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(613, 12)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(84, 22)
        Me.dtpDesde.TabIndex = 108
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Location = New System.Drawing.Point(921, 14)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(87, 27)
        Me.btnFiltrar.TabIndex = 101
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'cmbSectores
        '
        Me.cmbSectores.FormattingEnabled = True
        Me.cmbSectores.Location = New System.Drawing.Point(302, 13)
        Me.cmbSectores.Name = "cmbSectores"
        Me.cmbSectores.Size = New System.Drawing.Size(227, 21)
        Me.cmbSectores.TabIndex = 100
        '
        'lblSector
        '
        Me.lblSector.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSector.Location = New System.Drawing.Point(241, 13)
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
        Me.dgvListado.Location = New System.Drawing.Point(17, 58)
        Me.dgvListado.MultiSelect = False
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.RowHeadersWidth = 25
        Me.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListado.Size = New System.Drawing.Size(991, 442)
        Me.dgvListado.TabIndex = 98
        '
        'cmdSalir
        '
        Me.cmdSalir.Location = New System.Drawing.Point(871, 506)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(110, 27)
        Me.cmdSalir.TabIndex = 97
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'lblDesde
        '
        Me.lblDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesde.Location = New System.Drawing.Point(562, 13)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(55, 20)
        Me.lblDesde.TabIndex = 109
        Me.lblDesde.Text = "Desde:"
        Me.lblDesde.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpHasta
        '
        Me.dtpHasta.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(753, 12)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(84, 22)
        Me.dtpHasta.TabIndex = 110
        '
        'lblHasta
        '
        Me.lblHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHasta.Location = New System.Drawing.Point(702, 13)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(55, 20)
        Me.lblHasta.TabIndex = 111
        Me.lblHasta.Text = "Hasta:"
        Me.lblHasta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbPlantas
        '
        Me.cmbPlantas.FormattingEnabled = True
        Me.cmbPlantas.Location = New System.Drawing.Point(104, 12)
        Me.cmbPlantas.Name = "cmbPlantas"
        Me.cmbPlantas.Size = New System.Drawing.Size(105, 21)
        Me.cmbPlantas.TabIndex = 113
        '
        'lblPlanta
        '
        Me.lblPlanta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlanta.Location = New System.Drawing.Point(23, 14)
        Me.lblPlanta.Name = "lblPlanta"
        Me.lblPlanta.Size = New System.Drawing.Size(85, 20)
        Me.lblPlanta.TabIndex = 112
        Me.lblPlanta.Text = "Planta:"
        Me.lblPlanta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmRepoMantActivDiaria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1023, 546)
        Me.Controls.Add(Me.cmbPlantas)
        Me.Controls.Add(Me.lblPlanta)
        Me.Controls.Add(Me.dtpHasta)
        Me.Controls.Add(Me.lblHasta)
        Me.Controls.Add(Me.dtpDesde)
        Me.Controls.Add(Me.btnFiltrar)
        Me.Controls.Add(Me.cmbSectores)
        Me.Controls.Add(Me.lblSector)
        Me.Controls.Add(Me.dgvListado)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.lblDesde)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmRepoMantActivDiaria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento - Reporte de actividad diaria"
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnFiltrar As System.Windows.Forms.Button
    Friend WithEvents cmbSectores As System.Windows.Forms.ComboBox
    Friend WithEvents lblSector As System.Windows.Forms.Label
    Friend WithEvents dgvListado As System.Windows.Forms.DataGridView
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents lblDesde As System.Windows.Forms.Label
    Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblHasta As System.Windows.Forms.Label
    Friend WithEvents cmbPlantas As System.Windows.Forms.ComboBox
    Friend WithEvents lblPlanta As System.Windows.Forms.Label
End Class
