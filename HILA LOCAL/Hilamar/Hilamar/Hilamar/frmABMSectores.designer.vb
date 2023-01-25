<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmABMSectores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmABMSectores))
        Me.dgvSectores = New System.Windows.Forms.DataGridView()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.gbAgregarSector = New System.Windows.Forms.GroupBox()
        Me.btnCancelarAgregarSector = New System.Windows.Forms.Button()
        Me.btnOkAgregarSector = New System.Windows.Forms.Button()
        Me.lblAgregarSector = New System.Windows.Forms.Label()
        Me.txtAgregarSector = New System.Windows.Forms.TextBox()
        Me.gbModificarSector = New System.Windows.Forms.GroupBox()
        Me.btnCancelarEditarSector = New System.Windows.Forms.Button()
        Me.btnOkEditarSector = New System.Windows.Forms.Button()
        Me.lblEditarSector = New System.Windows.Forms.Label()
        Me.txtEditarSector = New System.Windows.Forms.TextBox()
        Me.cmbAgregarFabrica = New System.Windows.Forms.ComboBox()
        Me.lblAgregarFabrica = New System.Windows.Forms.Label()
        Me.cmbEditarFabrica = New System.Windows.Forms.ComboBox()
        Me.lblEditarFabrica = New System.Windows.Forms.Label()
        CType(Me.dgvSectores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAgregarSector.SuspendLayout()
        Me.gbModificarSector.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvSectores
        '
        Me.dgvSectores.AllowUserToAddRows = False
        Me.dgvSectores.AllowUserToDeleteRows = False
        Me.dgvSectores.AllowUserToResizeColumns = False
        Me.dgvSectores.AllowUserToResizeRows = False
        Me.dgvSectores.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvSectores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSectores.Location = New System.Drawing.Point(12, 40)
        Me.dgvSectores.Name = "dgvSectores"
        Me.dgvSectores.ReadOnly = True
        Me.dgvSectores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSectores.Size = New System.Drawing.Size(333, 476)
        Me.dgvSectores.TabIndex = 22
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(361, 466)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(107, 32)
        Me.btnCerrar.TabIndex = 18
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Location = New System.Drawing.Point(361, 40)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(107, 32)
        Me.btnAgregar.TabIndex = 23
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Location = New System.Drawing.Point(361, 92)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(107, 32)
        Me.btnEditar.TabIndex = 24
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Location = New System.Drawing.Point(361, 148)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(107, 32)
        Me.btnEliminar.TabIndex = 25
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBuscar.Location = New System.Drawing.Point(25, 11)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(55, 20)
        Me.lblBuscar.TabIndex = 28
        Me.lblBuscar.Text = "Sector:"
        Me.lblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBuscar
        '
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(86, 9)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(226, 22)
        Me.txtBuscar.TabIndex = 27
        '
        'gbAgregarSector
        '
        Me.gbAgregarSector.Controls.Add(Me.cmbAgregarFabrica)
        Me.gbAgregarSector.Controls.Add(Me.lblAgregarFabrica)
        Me.gbAgregarSector.Controls.Add(Me.btnCancelarAgregarSector)
        Me.gbAgregarSector.Controls.Add(Me.btnOkAgregarSector)
        Me.gbAgregarSector.Controls.Add(Me.lblAgregarSector)
        Me.gbAgregarSector.Controls.Add(Me.txtAgregarSector)
        Me.gbAgregarSector.Location = New System.Drawing.Point(488, 29)
        Me.gbAgregarSector.Name = "gbAgregarSector"
        Me.gbAgregarSector.Size = New System.Drawing.Size(352, 177)
        Me.gbAgregarSector.TabIndex = 29
        Me.gbAgregarSector.TabStop = False
        Me.gbAgregarSector.Text = "AGREGAR UN NUEVO SECTOR"
        '
        'btnCancelarAgregarSector
        '
        Me.btnCancelarAgregarSector.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarAgregarSector.Location = New System.Drawing.Point(197, 119)
        Me.btnCancelarAgregarSector.Name = "btnCancelarAgregarSector"
        Me.btnCancelarAgregarSector.Size = New System.Drawing.Size(100, 29)
        Me.btnCancelarAgregarSector.TabIndex = 32
        Me.btnCancelarAgregarSector.Text = "Cancelar"
        Me.btnCancelarAgregarSector.UseVisualStyleBackColor = True
        '
        'btnOkAgregarSector
        '
        Me.btnOkAgregarSector.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOkAgregarSector.Location = New System.Drawing.Point(52, 119)
        Me.btnOkAgregarSector.Name = "btnOkAgregarSector"
        Me.btnOkAgregarSector.Size = New System.Drawing.Size(100, 29)
        Me.btnOkAgregarSector.TabIndex = 31
        Me.btnOkAgregarSector.Text = "Ok"
        Me.btnOkAgregarSector.UseVisualStyleBackColor = True
        '
        'lblAgregarSector
        '
        Me.lblAgregarSector.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgregarSector.Location = New System.Drawing.Point(6, 33)
        Me.lblAgregarSector.Name = "lblAgregarSector"
        Me.lblAgregarSector.Size = New System.Drawing.Size(50, 20)
        Me.lblAgregarSector.TabIndex = 30
        Me.lblAgregarSector.Text = "Sector:"
        Me.lblAgregarSector.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAgregarSector
        '
        Me.txtAgregarSector.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAgregarSector.Location = New System.Drawing.Point(62, 33)
        Me.txtAgregarSector.Name = "txtAgregarSector"
        Me.txtAgregarSector.Size = New System.Drawing.Size(273, 22)
        Me.txtAgregarSector.TabIndex = 29
        '
        'gbModificarSector
        '
        Me.gbModificarSector.Controls.Add(Me.cmbEditarFabrica)
        Me.gbModificarSector.Controls.Add(Me.lblEditarFabrica)
        Me.gbModificarSector.Controls.Add(Me.btnCancelarEditarSector)
        Me.gbModificarSector.Controls.Add(Me.btnOkEditarSector)
        Me.gbModificarSector.Controls.Add(Me.lblEditarSector)
        Me.gbModificarSector.Controls.Add(Me.txtEditarSector)
        Me.gbModificarSector.Location = New System.Drawing.Point(488, 247)
        Me.gbModificarSector.Name = "gbModificarSector"
        Me.gbModificarSector.Size = New System.Drawing.Size(352, 189)
        Me.gbModificarSector.TabIndex = 30
        Me.gbModificarSector.TabStop = False
        Me.gbModificarSector.Text = "MODIFICAR UN SECTOR"
        '
        'btnCancelarEditarSector
        '
        Me.btnCancelarEditarSector.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarEditarSector.Location = New System.Drawing.Point(197, 128)
        Me.btnCancelarEditarSector.Name = "btnCancelarEditarSector"
        Me.btnCancelarEditarSector.Size = New System.Drawing.Size(100, 29)
        Me.btnCancelarEditarSector.TabIndex = 32
        Me.btnCancelarEditarSector.Text = "Cancelar"
        Me.btnCancelarEditarSector.UseVisualStyleBackColor = True
        '
        'btnOkEditarSector
        '
        Me.btnOkEditarSector.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOkEditarSector.Location = New System.Drawing.Point(52, 128)
        Me.btnOkEditarSector.Name = "btnOkEditarSector"
        Me.btnOkEditarSector.Size = New System.Drawing.Size(100, 29)
        Me.btnOkEditarSector.TabIndex = 31
        Me.btnOkEditarSector.Text = "Ok"
        Me.btnOkEditarSector.UseVisualStyleBackColor = True
        '
        'lblEditarSector
        '
        Me.lblEditarSector.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarSector.Location = New System.Drawing.Point(6, 41)
        Me.lblEditarSector.Name = "lblEditarSector"
        Me.lblEditarSector.Size = New System.Drawing.Size(50, 20)
        Me.lblEditarSector.TabIndex = 30
        Me.lblEditarSector.Text = "Sector:"
        Me.lblEditarSector.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEditarSector
        '
        Me.txtEditarSector.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditarSector.Location = New System.Drawing.Point(62, 41)
        Me.txtEditarSector.Name = "txtEditarSector"
        Me.txtEditarSector.Size = New System.Drawing.Size(273, 22)
        Me.txtEditarSector.TabIndex = 29
        '
        'cmbAgregarFabrica
        '
        Me.cmbAgregarFabrica.FormattingEnabled = True
        Me.cmbAgregarFabrica.Items.AddRange(New Object() {"HILAMAR", "TEXTILANA"})
        Me.cmbAgregarFabrica.Location = New System.Drawing.Point(90, 75)
        Me.cmbAgregarFabrica.Name = "cmbAgregarFabrica"
        Me.cmbAgregarFabrica.Size = New System.Drawing.Size(245, 21)
        Me.cmbAgregarFabrica.TabIndex = 36
        '
        'lblAgregarFabrica
        '
        Me.lblAgregarFabrica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgregarFabrica.Location = New System.Drawing.Point(6, 74)
        Me.lblAgregarFabrica.Name = "lblAgregarFabrica"
        Me.lblAgregarFabrica.Size = New System.Drawing.Size(69, 20)
        Me.lblAgregarFabrica.TabIndex = 35
        Me.lblAgregarFabrica.Text = "Fábrica:"
        Me.lblAgregarFabrica.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbEditarFabrica
        '
        Me.cmbEditarFabrica.FormattingEnabled = True
        Me.cmbEditarFabrica.Items.AddRange(New Object() {"HILAMAR", "TEXTILANA"})
        Me.cmbEditarFabrica.Location = New System.Drawing.Point(90, 86)
        Me.cmbEditarFabrica.Name = "cmbEditarFabrica"
        Me.cmbEditarFabrica.Size = New System.Drawing.Size(245, 21)
        Me.cmbEditarFabrica.TabIndex = 38
        '
        'lblEditarFabrica
        '
        Me.lblEditarFabrica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarFabrica.Location = New System.Drawing.Point(6, 85)
        Me.lblEditarFabrica.Name = "lblEditarFabrica"
        Me.lblEditarFabrica.Size = New System.Drawing.Size(69, 20)
        Me.lblEditarFabrica.TabIndex = 37
        Me.lblEditarFabrica.Text = "Fábrica:"
        Me.lblEditarFabrica.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmABMSectores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(867, 533)
        Me.Controls.Add(Me.gbModificarSector)
        Me.Controls.Add(Me.gbAgregarSector)
        Me.Controls.Add(Me.lblBuscar)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.dgvSectores)
        Me.Controls.Add(Me.btnCerrar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmABMSectores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM Sectores"
        CType(Me.dgvSectores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAgregarSector.ResumeLayout(False)
        Me.gbAgregarSector.PerformLayout()
        Me.gbModificarSector.ResumeLayout(False)
        Me.gbModificarSector.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvSectores As System.Windows.Forms.DataGridView
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents gbAgregarSector As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelarAgregarSector As System.Windows.Forms.Button
    Friend WithEvents btnOkAgregarSector As System.Windows.Forms.Button
    Friend WithEvents lblAgregarSector As System.Windows.Forms.Label
    Friend WithEvents txtAgregarSector As System.Windows.Forms.TextBox
    Friend WithEvents gbModificarSector As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelarEditarSector As System.Windows.Forms.Button
    Friend WithEvents btnOkEditarSector As System.Windows.Forms.Button
    Friend WithEvents lblEditarSector As System.Windows.Forms.Label
    Friend WithEvents txtEditarSector As System.Windows.Forms.TextBox
    Friend WithEvents cmbAgregarFabrica As System.Windows.Forms.ComboBox
    Friend WithEvents lblAgregarFabrica As System.Windows.Forms.Label
    Friend WithEvents cmbEditarFabrica As System.Windows.Forms.ComboBox
    Friend WithEvents lblEditarFabrica As System.Windows.Forms.Label
End Class
