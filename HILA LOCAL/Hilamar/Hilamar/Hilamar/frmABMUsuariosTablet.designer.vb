<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmABMUsuariosTablet
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmABMUsuariosTablet))
        Me.gbEditarUsuario = New System.Windows.Forms.GroupBox()
        Me.txtEditarContraseña = New System.Windows.Forms.TextBox()
        Me.lblEditarContraseña = New System.Windows.Forms.Label()
        Me.lblEditarNombre = New System.Windows.Forms.Label()
        Me.txtEditarNombre = New System.Windows.Forms.TextBox()
        Me.lblEditarSector = New System.Windows.Forms.Label()
        Me.btnCancelarEditarUsuario = New System.Windows.Forms.Button()
        Me.btnOkEditarUsuario = New System.Windows.Forms.Button()
        Me.lblEditarLegajo = New System.Windows.Forms.Label()
        Me.txtEditarLegajo = New System.Windows.Forms.TextBox()
        Me.gbAgregarUsuario = New System.Windows.Forms.GroupBox()
        Me.txtAgregarContraseña = New System.Windows.Forms.TextBox()
        Me.lblAgregarContraseña = New System.Windows.Forms.Label()
        Me.lblAgregarNombre = New System.Windows.Forms.Label()
        Me.txtAgregarNombre = New System.Windows.Forms.TextBox()
        Me.lblAgregarSector = New System.Windows.Forms.Label()
        Me.btnCancelarAgregarUsuario = New System.Windows.Forms.Button()
        Me.btnOkAgregarUsuario = New System.Windows.Forms.Button()
        Me.lblAgregarLegajo = New System.Windows.Forms.Label()
        Me.txtAgregarLegajo = New System.Windows.Forms.TextBox()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.dgvUsuarios = New System.Windows.Forms.DataGridView()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lsbAgregarSectores = New System.Windows.Forms.CheckedListBox()
        Me.lsbEditarSectores = New System.Windows.Forms.CheckedListBox()
        Me.gbEditarUsuario.SuspendLayout()
        Me.gbAgregarUsuario.SuspendLayout()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbEditarUsuario
        '
        Me.gbEditarUsuario.Controls.Add(Me.lsbEditarSectores)
        Me.gbEditarUsuario.Controls.Add(Me.txtEditarContraseña)
        Me.gbEditarUsuario.Controls.Add(Me.lblEditarContraseña)
        Me.gbEditarUsuario.Controls.Add(Me.lblEditarNombre)
        Me.gbEditarUsuario.Controls.Add(Me.txtEditarNombre)
        Me.gbEditarUsuario.Controls.Add(Me.lblEditarSector)
        Me.gbEditarUsuario.Controls.Add(Me.btnCancelarEditarUsuario)
        Me.gbEditarUsuario.Controls.Add(Me.btnOkEditarUsuario)
        Me.gbEditarUsuario.Controls.Add(Me.lblEditarLegajo)
        Me.gbEditarUsuario.Controls.Add(Me.txtEditarLegajo)
        Me.gbEditarUsuario.Location = New System.Drawing.Point(598, 226)
        Me.gbEditarUsuario.Name = "gbEditarUsuario"
        Me.gbEditarUsuario.Size = New System.Drawing.Size(352, 407)
        Me.gbEditarUsuario.TabIndex = 39
        Me.gbEditarUsuario.TabStop = False
        Me.gbEditarUsuario.Text = "MODIFICAR UN USUARIO"
        '
        'txtEditarContraseña
        '
        Me.txtEditarContraseña.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditarContraseña.Location = New System.Drawing.Point(90, 99)
        Me.txtEditarContraseña.Name = "txtEditarContraseña"
        Me.txtEditarContraseña.Size = New System.Drawing.Size(245, 22)
        Me.txtEditarContraseña.TabIndex = 43
        '
        'lblEditarContraseña
        '
        Me.lblEditarContraseña.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarContraseña.Location = New System.Drawing.Point(6, 98)
        Me.lblEditarContraseña.Name = "lblEditarContraseña"
        Me.lblEditarContraseña.Size = New System.Drawing.Size(87, 20)
        Me.lblEditarContraseña.TabIndex = 44
        Me.lblEditarContraseña.Text = "Contraseña:"
        Me.lblEditarContraseña.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEditarNombre
        '
        Me.lblEditarNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarNombre.Location = New System.Drawing.Point(6, 65)
        Me.lblEditarNombre.Name = "lblEditarNombre"
        Me.lblEditarNombre.Size = New System.Drawing.Size(62, 20)
        Me.lblEditarNombre.TabIndex = 42
        Me.lblEditarNombre.Text = "Nombre:"
        Me.lblEditarNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEditarNombre
        '
        Me.txtEditarNombre.Enabled = False
        Me.txtEditarNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditarNombre.Location = New System.Drawing.Point(90, 64)
        Me.txtEditarNombre.Name = "txtEditarNombre"
        Me.txtEditarNombre.Size = New System.Drawing.Size(245, 22)
        Me.txtEditarNombre.TabIndex = 41
        '
        'lblEditarSector
        '
        Me.lblEditarSector.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarSector.Location = New System.Drawing.Point(6, 134)
        Me.lblEditarSector.Name = "lblEditarSector"
        Me.lblEditarSector.Size = New System.Drawing.Size(69, 20)
        Me.lblEditarSector.TabIndex = 37
        Me.lblEditarSector.Text = "Sector:"
        Me.lblEditarSector.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancelarEditarUsuario
        '
        Me.btnCancelarEditarUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarEditarUsuario.Location = New System.Drawing.Point(199, 365)
        Me.btnCancelarEditarUsuario.Name = "btnCancelarEditarUsuario"
        Me.btnCancelarEditarUsuario.Size = New System.Drawing.Size(100, 29)
        Me.btnCancelarEditarUsuario.TabIndex = 32
        Me.btnCancelarEditarUsuario.Text = "Cancelar"
        Me.btnCancelarEditarUsuario.UseVisualStyleBackColor = True
        '
        'btnOkEditarUsuario
        '
        Me.btnOkEditarUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOkEditarUsuario.Location = New System.Drawing.Point(54, 365)
        Me.btnOkEditarUsuario.Name = "btnOkEditarUsuario"
        Me.btnOkEditarUsuario.Size = New System.Drawing.Size(100, 29)
        Me.btnOkEditarUsuario.TabIndex = 31
        Me.btnOkEditarUsuario.Text = "Ok"
        Me.btnOkEditarUsuario.UseVisualStyleBackColor = True
        '
        'lblEditarLegajo
        '
        Me.lblEditarLegajo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarLegajo.Location = New System.Drawing.Point(6, 29)
        Me.lblEditarLegajo.Name = "lblEditarLegajo"
        Me.lblEditarLegajo.Size = New System.Drawing.Size(62, 20)
        Me.lblEditarLegajo.TabIndex = 30
        Me.lblEditarLegajo.Text = "Legajo:"
        Me.lblEditarLegajo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEditarLegajo
        '
        Me.txtEditarLegajo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditarLegajo.Location = New System.Drawing.Point(90, 29)
        Me.txtEditarLegajo.Name = "txtEditarLegajo"
        Me.txtEditarLegajo.Size = New System.Drawing.Size(113, 22)
        Me.txtEditarLegajo.TabIndex = 29
        '
        'gbAgregarUsuario
        '
        Me.gbAgregarUsuario.Controls.Add(Me.lsbAgregarSectores)
        Me.gbAgregarUsuario.Controls.Add(Me.txtAgregarContraseña)
        Me.gbAgregarUsuario.Controls.Add(Me.lblAgregarContraseña)
        Me.gbAgregarUsuario.Controls.Add(Me.lblAgregarNombre)
        Me.gbAgregarUsuario.Controls.Add(Me.txtAgregarNombre)
        Me.gbAgregarUsuario.Controls.Add(Me.lblAgregarSector)
        Me.gbAgregarUsuario.Controls.Add(Me.btnCancelarAgregarUsuario)
        Me.gbAgregarUsuario.Controls.Add(Me.btnOkAgregarUsuario)
        Me.gbAgregarUsuario.Controls.Add(Me.lblAgregarLegajo)
        Me.gbAgregarUsuario.Controls.Add(Me.txtAgregarLegajo)
        Me.gbAgregarUsuario.Location = New System.Drawing.Point(661, 43)
        Me.gbAgregarUsuario.Name = "gbAgregarUsuario"
        Me.gbAgregarUsuario.Size = New System.Drawing.Size(352, 407)
        Me.gbAgregarUsuario.TabIndex = 38
        Me.gbAgregarUsuario.TabStop = False
        Me.gbAgregarUsuario.Text = "AGREGAR UN NUEVO USUARIO"
        '
        'txtAgregarContraseña
        '
        Me.txtAgregarContraseña.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAgregarContraseña.Location = New System.Drawing.Point(90, 101)
        Me.txtAgregarContraseña.Name = "txtAgregarContraseña"
        Me.txtAgregarContraseña.Size = New System.Drawing.Size(245, 22)
        Me.txtAgregarContraseña.TabIndex = 39
        '
        'lblAgregarContraseña
        '
        Me.lblAgregarContraseña.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgregarContraseña.Location = New System.Drawing.Point(6, 100)
        Me.lblAgregarContraseña.Name = "lblAgregarContraseña"
        Me.lblAgregarContraseña.Size = New System.Drawing.Size(87, 20)
        Me.lblAgregarContraseña.TabIndex = 40
        Me.lblAgregarContraseña.Text = "Contraseña:"
        Me.lblAgregarContraseña.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAgregarNombre
        '
        Me.lblAgregarNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgregarNombre.Location = New System.Drawing.Point(6, 67)
        Me.lblAgregarNombre.Name = "lblAgregarNombre"
        Me.lblAgregarNombre.Size = New System.Drawing.Size(62, 20)
        Me.lblAgregarNombre.TabIndex = 38
        Me.lblAgregarNombre.Text = "Nombre:"
        Me.lblAgregarNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAgregarNombre
        '
        Me.txtAgregarNombre.Enabled = False
        Me.txtAgregarNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAgregarNombre.Location = New System.Drawing.Point(90, 66)
        Me.txtAgregarNombre.Name = "txtAgregarNombre"
        Me.txtAgregarNombre.Size = New System.Drawing.Size(245, 22)
        Me.txtAgregarNombre.TabIndex = 37
        '
        'lblAgregarSector
        '
        Me.lblAgregarSector.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgregarSector.Location = New System.Drawing.Point(6, 134)
        Me.lblAgregarSector.Name = "lblAgregarSector"
        Me.lblAgregarSector.Size = New System.Drawing.Size(69, 20)
        Me.lblAgregarSector.TabIndex = 35
        Me.lblAgregarSector.Text = "Sector:"
        Me.lblAgregarSector.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancelarAgregarUsuario
        '
        Me.btnCancelarAgregarUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarAgregarUsuario.Location = New System.Drawing.Point(200, 365)
        Me.btnCancelarAgregarUsuario.Name = "btnCancelarAgregarUsuario"
        Me.btnCancelarAgregarUsuario.Size = New System.Drawing.Size(100, 29)
        Me.btnCancelarAgregarUsuario.TabIndex = 32
        Me.btnCancelarAgregarUsuario.Text = "Cancelar"
        Me.btnCancelarAgregarUsuario.UseVisualStyleBackColor = True
        '
        'btnOkAgregarUsuario
        '
        Me.btnOkAgregarUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOkAgregarUsuario.Location = New System.Drawing.Point(55, 365)
        Me.btnOkAgregarUsuario.Name = "btnOkAgregarUsuario"
        Me.btnOkAgregarUsuario.Size = New System.Drawing.Size(100, 29)
        Me.btnOkAgregarUsuario.TabIndex = 31
        Me.btnOkAgregarUsuario.Text = "Ok"
        Me.btnOkAgregarUsuario.UseVisualStyleBackColor = True
        '
        'lblAgregarLegajo
        '
        Me.lblAgregarLegajo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgregarLegajo.Location = New System.Drawing.Point(6, 33)
        Me.lblAgregarLegajo.Name = "lblAgregarLegajo"
        Me.lblAgregarLegajo.Size = New System.Drawing.Size(62, 20)
        Me.lblAgregarLegajo.TabIndex = 30
        Me.lblAgregarLegajo.Text = "Legajo:"
        Me.lblAgregarLegajo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAgregarLegajo
        '
        Me.txtAgregarLegajo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAgregarLegajo.Location = New System.Drawing.Point(90, 33)
        Me.txtAgregarLegajo.Name = "txtAgregarLegajo"
        Me.txtAgregarLegajo.Size = New System.Drawing.Size(113, 22)
        Me.txtAgregarLegajo.TabIndex = 29
        '
        'lblBuscar
        '
        Me.lblBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBuscar.Location = New System.Drawing.Point(22, 14)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(88, 20)
        Me.lblBuscar.TabIndex = 37
        Me.lblBuscar.Text = "Empleado:"
        Me.lblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBuscar
        '
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(100, 13)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(319, 22)
        Me.txtBuscar.TabIndex = 36
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Location = New System.Drawing.Point(548, 162)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(107, 32)
        Me.btnEliminar.TabIndex = 35
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Location = New System.Drawing.Point(548, 106)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(107, 32)
        Me.btnEditar.TabIndex = 34
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Location = New System.Drawing.Point(548, 54)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(107, 32)
        Me.btnAgregar.TabIndex = 33
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'dgvUsuarios
        '
        Me.dgvUsuarios.AllowUserToAddRows = False
        Me.dgvUsuarios.AllowUserToDeleteRows = False
        Me.dgvUsuarios.AllowUserToResizeColumns = False
        Me.dgvUsuarios.AllowUserToResizeRows = False
        Me.dgvUsuarios.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsuarios.Location = New System.Drawing.Point(9, 43)
        Me.dgvUsuarios.Name = "dgvUsuarios"
        Me.dgvUsuarios.ReadOnly = True
        Me.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUsuarios.Size = New System.Drawing.Size(533, 407)
        Me.dgvUsuarios.TabIndex = 32
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(548, 408)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(107, 32)
        Me.btnCerrar.TabIndex = 31
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'lsbAgregarSectores
        '
        Me.lsbAgregarSectores.CheckOnClick = True
        Me.lsbAgregarSectores.ColumnWidth = 380
        Me.lsbAgregarSectores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsbAgregarSectores.FormattingEnabled = True
        Me.lsbAgregarSectores.Location = New System.Drawing.Point(90, 135)
        Me.lsbAgregarSectores.MultiColumn = True
        Me.lsbAgregarSectores.Name = "lsbAgregarSectores"
        Me.lsbAgregarSectores.Size = New System.Drawing.Size(245, 213)
        Me.lsbAgregarSectores.TabIndex = 41
        Me.lsbAgregarSectores.ThreeDCheckBoxes = True
        '
        'lsbEditarSectores
        '
        Me.lsbEditarSectores.CheckOnClick = True
        Me.lsbEditarSectores.ColumnWidth = 380
        Me.lsbEditarSectores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsbEditarSectores.FormattingEnabled = True
        Me.lsbEditarSectores.Location = New System.Drawing.Point(90, 135)
        Me.lsbEditarSectores.MultiColumn = True
        Me.lsbEditarSectores.Name = "lsbEditarSectores"
        Me.lsbEditarSectores.Size = New System.Drawing.Size(245, 213)
        Me.lsbEditarSectores.TabIndex = 45
        Me.lsbEditarSectores.ThreeDCheckBoxes = True
        '
        'frmABMUsuariosTablet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 464)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.gbEditarUsuario)
        Me.Controls.Add(Me.gbAgregarUsuario)
        Me.Controls.Add(Me.lblBuscar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.dgvUsuarios)
        Me.Controls.Add(Me.btnCerrar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmABMUsuariosTablet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento - ABM Usuarios Tablet"
        Me.gbEditarUsuario.ResumeLayout(False)
        Me.gbEditarUsuario.PerformLayout()
        Me.gbAgregarUsuario.ResumeLayout(False)
        Me.gbAgregarUsuario.PerformLayout()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbEditarUsuario As System.Windows.Forms.GroupBox
    Friend WithEvents lblEditarSector As System.Windows.Forms.Label
    Friend WithEvents btnCancelarEditarUsuario As System.Windows.Forms.Button
    Friend WithEvents btnOkEditarUsuario As System.Windows.Forms.Button
    Friend WithEvents lblEditarLegajo As System.Windows.Forms.Label
    Friend WithEvents txtEditarLegajo As System.Windows.Forms.TextBox
    Friend WithEvents gbAgregarUsuario As System.Windows.Forms.GroupBox
    Friend WithEvents lblAgregarSector As System.Windows.Forms.Label
    Friend WithEvents btnCancelarAgregarUsuario As System.Windows.Forms.Button
    Friend WithEvents btnOkAgregarUsuario As System.Windows.Forms.Button
    Friend WithEvents lblAgregarLegajo As System.Windows.Forms.Label
    Friend WithEvents txtAgregarLegajo As System.Windows.Forms.TextBox
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents dgvUsuarios As System.Windows.Forms.DataGridView
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents lblAgregarNombre As System.Windows.Forms.Label
    Friend WithEvents txtAgregarNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtAgregarContraseña As System.Windows.Forms.TextBox
    Friend WithEvents lblAgregarContraseña As System.Windows.Forms.Label
    Friend WithEvents txtEditarContraseña As System.Windows.Forms.TextBox
    Friend WithEvents lblEditarContraseña As System.Windows.Forms.Label
    Friend WithEvents lblEditarNombre As System.Windows.Forms.Label
    Friend WithEvents txtEditarNombre As System.Windows.Forms.TextBox
    Friend WithEvents lsbAgregarSectores As System.Windows.Forms.CheckedListBox
    Friend WithEvents lsbEditarSectores As System.Windows.Forms.CheckedListBox
End Class
