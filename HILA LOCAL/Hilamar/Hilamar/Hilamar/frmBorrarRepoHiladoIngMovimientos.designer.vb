<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBorrarRepoHiladoIngMovimientos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBorrarRepoHiladoIngMovimientos))
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtPartida = New System.Windows.Forms.TextBox()
        Me.lblPartida = New System.Windows.Forms.Label()
        Me.dgvMovimientos = New System.Windows.Forms.DataGridView()
        Me.txtRemito = New System.Windows.Forms.TextBox()
        Me.lblRemito = New System.Windows.Forms.Label()
        Me.chkVerPCostura = New System.Windows.Forms.CheckBox()
        CType(Me.dgvMovimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(587, 487)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 17
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(587, 113)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminar.TabIndex = 16
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(587, 84)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(75, 23)
        Me.btnModificar.TabIndex = 15
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(587, 55)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 14
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(587, 10)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 13
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtPartida
        '
        Me.txtPartida.Location = New System.Drawing.Point(86, 24)
        Me.txtPartida.Name = "txtPartida"
        Me.txtPartida.Size = New System.Drawing.Size(105, 20)
        Me.txtPartida.TabIndex = 12
        '
        'lblPartida
        '
        Me.lblPartida.Location = New System.Drawing.Point(28, 22)
        Me.lblPartida.Name = "lblPartida"
        Me.lblPartida.Size = New System.Drawing.Size(52, 23)
        Me.lblPartida.TabIndex = 11
        Me.lblPartida.Text = "Partida:"
        Me.lblPartida.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvMovimientos
        '
        Me.dgvMovimientos.AllowUserToAddRows = False
        Me.dgvMovimientos.AllowUserToDeleteRows = False
        Me.dgvMovimientos.AllowUserToResizeColumns = False
        Me.dgvMovimientos.AllowUserToResizeRows = False
        Me.dgvMovimientos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMovimientos.Location = New System.Drawing.Point(12, 54)
        Me.dgvMovimientos.MultiSelect = False
        Me.dgvMovimientos.Name = "dgvMovimientos"
        Me.dgvMovimientos.RowHeadersWidth = 20
        Me.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMovimientos.Size = New System.Drawing.Size(569, 465)
        Me.dgvMovimientos.TabIndex = 32
        '
        'txtRemito
        '
        Me.txtRemito.Location = New System.Drawing.Point(268, 24)
        Me.txtRemito.Name = "txtRemito"
        Me.txtRemito.Size = New System.Drawing.Size(105, 20)
        Me.txtRemito.TabIndex = 34
        '
        'lblRemito
        '
        Me.lblRemito.Location = New System.Drawing.Point(210, 22)
        Me.lblRemito.Name = "lblRemito"
        Me.lblRemito.Size = New System.Drawing.Size(52, 23)
        Me.lblRemito.TabIndex = 33
        Me.lblRemito.Text = "Remito:"
        Me.lblRemito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkVerPCostura
        '
        Me.chkVerPCostura.AutoSize = True
        Me.chkVerPCostura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVerPCostura.Location = New System.Drawing.Point(457, 28)
        Me.chkVerPCostura.Name = "chkVerPCostura"
        Me.chkVerPCostura.Size = New System.Drawing.Size(93, 17)
        Me.chkVerPCostura.TabIndex = 35
        Me.chkVerPCostura.Text = "Ver P/Costura"
        Me.chkVerPCostura.UseVisualStyleBackColor = True
        '
        'frmRepoHiladoIngMovimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(674, 531)
        Me.Controls.Add(Me.chkVerPCostura)
        Me.Controls.Add(Me.txtRemito)
        Me.Controls.Add(Me.lblRemito)
        Me.Controls.Add(Me.dgvMovimientos)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.txtPartida)
        Me.Controls.Add(Me.lblPartida)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmRepoHiladoIngMovimientos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Textilana. Listado de Ingresos y Devoluciones de Hilado a Planta."
        CType(Me.dgvMovimientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtPartida As System.Windows.Forms.TextBox
    Friend WithEvents lblPartida As System.Windows.Forms.Label
    Friend WithEvents dgvMovimientos As System.Windows.Forms.DataGridView
    Friend WithEvents txtRemito As System.Windows.Forms.TextBox
    Friend WithEvents lblRemito As System.Windows.Forms.Label
    Friend WithEvents chkVerPCostura As System.Windows.Forms.CheckBox
End Class
