<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepoPlanMantenimiento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepoPlanMantenimiento))
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.dgvListado = New System.Windows.Forms.DataGridView()
        Me.cmbSectores = New System.Windows.Forms.ComboBox()
        Me.lblSector = New System.Windows.Forms.Label()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.cmbEstados = New System.Windows.Forms.ComboBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.chkTodos = New System.Windows.Forms.CheckBox()
        Me.btnPonerTerminada = New System.Windows.Forms.Button()
        Me.btnPosponer = New System.Windows.Forms.Button()
        Me.btnIprimir = New System.Windows.Forms.Button()
        Me.pdoImpReporte = New System.Drawing.Printing.PrintDocument()
        Me.lblTitAPartirDe = New System.Windows.Forms.Label()
        Me.dtpAPartirDe = New System.Windows.Forms.DateTimePicker()
        Me.cmbPlantas = New System.Windows.Forms.ComboBox()
        Me.lblPlanta = New System.Windows.Forms.Label()
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdSalir
        '
        Me.cmdSalir.Location = New System.Drawing.Point(888, 525)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(110, 27)
        Me.cmdSalir.TabIndex = 4
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'dgvListado
        '
        Me.dgvListado.AllowUserToAddRows = False
        Me.dgvListado.AllowUserToDeleteRows = False
        Me.dgvListado.AllowUserToResizeColumns = False
        Me.dgvListado.AllowUserToResizeRows = False
        Me.dgvListado.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListado.Location = New System.Drawing.Point(5, 112)
        Me.dgvListado.MultiSelect = False
        Me.dgvListado.Name = "dgvListado"
        Me.dgvListado.RowHeadersWidth = 25
        Me.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListado.Size = New System.Drawing.Size(991, 407)
        Me.dgvListado.TabIndex = 9
        '
        'cmbSectores
        '
        Me.cmbSectores.FormattingEnabled = True
        Me.cmbSectores.Location = New System.Drawing.Point(255, 45)
        Me.cmbSectores.Name = "cmbSectores"
        Me.cmbSectores.Size = New System.Drawing.Size(227, 23)
        Me.cmbSectores.TabIndex = 36
        '
        'lblSector
        '
        Me.lblSector.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSector.Location = New System.Drawing.Point(194, 49)
        Me.lblSector.Name = "lblSector"
        Me.lblSector.Size = New System.Drawing.Size(55, 20)
        Me.lblSector.TabIndex = 35
        Me.lblSector.Text = "Sector:"
        Me.lblSector.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Location = New System.Drawing.Point(728, 42)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(87, 27)
        Me.btnFiltrar.TabIndex = 37
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'cmbEstados
        '
        Me.cmbEstados.FormattingEnabled = True
        Me.cmbEstados.Location = New System.Drawing.Point(563, 45)
        Me.cmbEstados.Name = "cmbEstados"
        Me.cmbEstados.Size = New System.Drawing.Size(147, 23)
        Me.cmbEstados.TabIndex = 39
        '
        'lblEstado
        '
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.Location = New System.Drawing.Point(504, 49)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(70, 20)
        Me.lblEstado.TabIndex = 38
        Me.lblEstado.Text = "Estado:"
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkTodos
        '
        Me.chkTodos.AutoSize = True
        Me.chkTodos.Location = New System.Drawing.Point(22, 87)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(60, 19)
        Me.chkTodos.TabIndex = 48
        Me.chkTodos.Text = "Todas"
        Me.chkTodos.UseVisualStyleBackColor = True
        '
        'btnPonerTerminada
        '
        Me.btnPonerTerminada.Location = New System.Drawing.Point(1002, 198)
        Me.btnPonerTerminada.Name = "btnPonerTerminada"
        Me.btnPonerTerminada.Size = New System.Drawing.Size(76, 45)
        Me.btnPonerTerminada.TabIndex = 49
        Me.btnPonerTerminada.Text = "Poner Terminada"
        Me.btnPonerTerminada.UseVisualStyleBackColor = True
        '
        'btnPosponer
        '
        Me.btnPosponer.Location = New System.Drawing.Point(1002, 122)
        Me.btnPosponer.Name = "btnPosponer"
        Me.btnPosponer.Size = New System.Drawing.Size(76, 45)
        Me.btnPosponer.TabIndex = 50
        Me.btnPosponer.Text = "Posponer"
        Me.btnPosponer.UseVisualStyleBackColor = True
        '
        'btnIprimir
        '
        Me.btnIprimir.Location = New System.Drawing.Point(836, 42)
        Me.btnIprimir.Name = "btnIprimir"
        Me.btnIprimir.Size = New System.Drawing.Size(130, 27)
        Me.btnIprimir.TabIndex = 51
        Me.btnIprimir.Text = "Imprimir"
        Me.btnIprimir.UseVisualStyleBackColor = True
        '
        'pdoImpReporte
        '
        '
        'lblTitAPartirDe
        '
        Me.lblTitAPartirDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitAPartirDe.Location = New System.Drawing.Point(12, 48)
        Me.lblTitAPartirDe.Name = "lblTitAPartirDe"
        Me.lblTitAPartirDe.Size = New System.Drawing.Size(84, 20)
        Me.lblTitAPartirDe.TabIndex = 96
        Me.lblTitAPartirDe.Text = "A partir del:"
        Me.lblTitAPartirDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpAPartirDe
        '
        Me.dtpAPartirDe.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpAPartirDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpAPartirDe.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAPartirDe.Location = New System.Drawing.Point(92, 47)
        Me.dtpAPartirDe.Name = "dtpAPartirDe"
        Me.dtpAPartirDe.Size = New System.Drawing.Size(95, 22)
        Me.dtpAPartirDe.TabIndex = 95
        '
        'cmbPlantas
        '
        Me.cmbPlantas.FormattingEnabled = True
        Me.cmbPlantas.Location = New System.Drawing.Point(92, 12)
        Me.cmbPlantas.Name = "cmbPlantas"
        Me.cmbPlantas.Size = New System.Drawing.Size(157, 23)
        Me.cmbPlantas.TabIndex = 113
        '
        'lblPlanta
        '
        Me.lblPlanta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlanta.Location = New System.Drawing.Point(11, 14)
        Me.lblPlanta.Name = "lblPlanta"
        Me.lblPlanta.Size = New System.Drawing.Size(85, 20)
        Me.lblPlanta.TabIndex = 112
        Me.lblPlanta.Text = "Planta:"
        Me.lblPlanta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmRepoPlanMantenimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1087, 564)
        Me.Controls.Add(Me.cmbPlantas)
        Me.Controls.Add(Me.lblPlanta)
        Me.Controls.Add(Me.dtpAPartirDe)
        Me.Controls.Add(Me.btnIprimir)
        Me.Controls.Add(Me.btnPosponer)
        Me.Controls.Add(Me.btnPonerTerminada)
        Me.Controls.Add(Me.chkTodos)
        Me.Controls.Add(Me.cmbEstados)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.btnFiltrar)
        Me.Controls.Add(Me.cmbSectores)
        Me.Controls.Add(Me.lblSector)
        Me.Controls.Add(Me.dgvListado)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.lblTitAPartirDe)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmRepoPlanMantenimiento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado de Tareas del Plan de Mantenimiento"
        CType(Me.dgvListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents dgvListado As System.Windows.Forms.DataGridView
    Friend WithEvents cmbSectores As System.Windows.Forms.ComboBox
    Friend WithEvents lblSector As System.Windows.Forms.Label
    Friend WithEvents btnFiltrar As System.Windows.Forms.Button
    Friend WithEvents cmbEstados As System.Windows.Forms.ComboBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents chkTodos As System.Windows.Forms.CheckBox
    Friend WithEvents btnPonerTerminada As System.Windows.Forms.Button
    Friend WithEvents btnPosponer As System.Windows.Forms.Button
    Friend WithEvents btnIprimir As System.Windows.Forms.Button
    Friend WithEvents pdoImpReporte As System.Drawing.Printing.PrintDocument
    Friend WithEvents lblTitAPartirDe As System.Windows.Forms.Label
    Friend WithEvents dtpAPartirDe As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbPlantas As System.Windows.Forms.ComboBox
    Friend WithEvents lblPlanta As System.Windows.Forms.Label
End Class
