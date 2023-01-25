<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmABMProveedores_Articulo
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmABMProveedores_Articulo))
        Me.dgvProveedoresExistentes = New System.Windows.Forms.DataGridView()
        Me.txtBuscador = New System.Windows.Forms.TextBox()
        Me.dgvProveedoresArticulo = New System.Windows.Forms.DataGridView()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.btnConfirmar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblArticulo = New System.Windows.Forms.Label()
        Me.btnSalir = New System.Windows.Forms.Button()
        CType(Me.dgvProveedoresExistentes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvProveedoresArticulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvProveedoresExistentes
        '
        Me.dgvProveedoresExistentes.AllowUserToAddRows = False
        Me.dgvProveedoresExistentes.AllowUserToDeleteRows = False
        Me.dgvProveedoresExistentes.AllowUserToResizeColumns = False
        Me.dgvProveedoresExistentes.AllowUserToResizeRows = False
        Me.dgvProveedoresExistentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProveedoresExistentes.ColumnHeadersVisible = False
        Me.dgvProveedoresExistentes.Location = New System.Drawing.Point(13, 67)
        Me.dgvProveedoresExistentes.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvProveedoresExistentes.Name = "dgvProveedoresExistentes"
        Me.dgvProveedoresExistentes.RowHeadersVisible = False
        Me.dgvProveedoresExistentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProveedoresExistentes.Size = New System.Drawing.Size(420, 399)
        Me.dgvProveedoresExistentes.TabIndex = 0
        '
        'txtBuscador
        '
        Me.txtBuscador.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscador.Location = New System.Drawing.Point(13, 29)
        Me.txtBuscador.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBuscador.Name = "txtBuscador"
        Me.txtBuscador.Size = New System.Drawing.Size(300, 26)
        Me.txtBuscador.TabIndex = 1
        '
        'dgvProveedoresArticulo
        '
        Me.dgvProveedoresArticulo.AllowUserToAddRows = False
        Me.dgvProveedoresArticulo.AllowUserToDeleteRows = False
        Me.dgvProveedoresArticulo.AllowUserToResizeColumns = False
        Me.dgvProveedoresArticulo.AllowUserToResizeRows = False
        Me.dgvProveedoresArticulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProveedoresArticulo.ColumnHeadersVisible = False
        Me.dgvProveedoresArticulo.Location = New System.Drawing.Point(545, 67)
        Me.dgvProveedoresArticulo.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvProveedoresArticulo.Name = "dgvProveedoresArticulo"
        Me.dgvProveedoresArticulo.RowHeadersVisible = False
        Me.dgvProveedoresArticulo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProveedoresArticulo.Size = New System.Drawing.Size(420, 399)
        Me.dgvProveedoresArticulo.TabIndex = 3
        '
        'btnAgregar
        '
        Me.btnAgregar.AutoSize = True
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft YaHei", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnAgregar.Location = New System.Drawing.Point(441, 185)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(70, 49)
        Me.btnAgregar.TabIndex = 4
        Me.btnAgregar.Text = "→"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnQuitar
        '
        Me.btnQuitar.AutoSize = True
        Me.btnQuitar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnQuitar.Font = New System.Drawing.Font("Microsoft YaHei", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuitar.ForeColor = System.Drawing.Color.DarkRed
        Me.btnQuitar.Location = New System.Drawing.Point(467, 288)
        Me.btnQuitar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(70, 49)
        Me.btnQuitar.TabIndex = 5
        Me.btnQuitar.Text = "←"
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'btnConfirmar
        '
        Me.btnConfirmar.AutoSize = True
        Me.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConfirmar.Font = New System.Drawing.Font("Microsoft Tai Le", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmar.Location = New System.Drawing.Point(851, 474)
        Me.btnConfirmar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(114, 31)
        Me.btnConfirmar.TabIndex = 6
        Me.btnConfirmar.Text = "CONFIRMAR"
        Me.btnConfirmar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(13, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Nombre Proveedor:"
        '
        'lblArticulo
        '
        Me.lblArticulo.Font = New System.Drawing.Font("Microsoft Tai Le", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArticulo.Location = New System.Drawing.Point(542, 47)
        Me.lblArticulo.Name = "lblArticulo"
        Me.lblArticulo.Size = New System.Drawing.Size(423, 16)
        Me.lblArticulo.TabIndex = 13
        Me.lblArticulo.Text = "Proveedores de ..."
        '
        'btnSalir
        '
        Me.btnSalir.AutoSize = True
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Tai Le", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Location = New System.Drawing.Point(13, 474)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(63, 31)
        Me.btnSalir.TabIndex = 14
        Me.btnSalir.Text = "SALIR"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmABMProveedores_Articulo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(978, 518)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.lblArticulo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnConfirmar)
        Me.Controls.Add(Me.btnQuitar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.dgvProveedoresArticulo)
        Me.Controls.Add(Me.txtBuscador)
        Me.Controls.Add(Me.dgvProveedoresExistentes)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmABMProveedores_Articulo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmABMProveedores_Articulos"
        CType(Me.dgvProveedoresExistentes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvProveedoresArticulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvProveedoresExistentes As System.Windows.Forms.DataGridView
    Friend WithEvents txtBuscador As System.Windows.Forms.TextBox
    Friend WithEvents dgvProveedoresArticulo As System.Windows.Forms.DataGridView
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnQuitar As System.Windows.Forms.Button
    Friend WithEvents btnConfirmar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblArticulo As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
End Class
