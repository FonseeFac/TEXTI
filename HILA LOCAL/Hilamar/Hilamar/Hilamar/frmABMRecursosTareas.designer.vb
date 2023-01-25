<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmABMRecursosTareas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmABMRecursosTareas))
        Me.dgvRecursos = New System.Windows.Forms.DataGridView()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.gbAgregarRecurso = New System.Windows.Forms.GroupBox()
        Me.btnCancelarAgregarRecurso = New System.Windows.Forms.Button()
        Me.btnOkAgregarRecurso = New System.Windows.Forms.Button()
        Me.lblAgregarRecurso = New System.Windows.Forms.Label()
        Me.txtAgregarRecurso = New System.Windows.Forms.TextBox()
        Me.gbModificarRecurso = New System.Windows.Forms.GroupBox()
        Me.btnCancelarEditarRecurso = New System.Windows.Forms.Button()
        Me.btnOkEditarRecurso = New System.Windows.Forms.Button()
        Me.lblEditarRecurso = New System.Windows.Forms.Label()
        Me.txtEditarRecurso = New System.Windows.Forms.TextBox()
        CType(Me.dgvRecursos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAgregarRecurso.SuspendLayout()
        Me.gbModificarRecurso.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvRecursos
        '
        Me.dgvRecursos.AllowUserToAddRows = False
        Me.dgvRecursos.AllowUserToDeleteRows = False
        Me.dgvRecursos.AllowUserToResizeColumns = False
        Me.dgvRecursos.AllowUserToResizeRows = False
        Me.dgvRecursos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvRecursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecursos.Location = New System.Drawing.Point(12, 40)
        Me.dgvRecursos.Name = "dgvRecursos"
        Me.dgvRecursos.ReadOnly = True
        Me.dgvRecursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRecursos.Size = New System.Drawing.Size(333, 476)
        Me.dgvRecursos.TabIndex = 22
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
        Me.lblBuscar.Location = New System.Drawing.Point(9, 12)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(90, 20)
        Me.lblBuscar.TabIndex = 28
        Me.lblBuscar.Text = "Recurso:"
        Me.lblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBuscar
        '
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(104, 12)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(241, 22)
        Me.txtBuscar.TabIndex = 27
        '
        'gbAgregarRecurso
        '
        Me.gbAgregarRecurso.Controls.Add(Me.txtAgregarRecurso)
        Me.gbAgregarRecurso.Controls.Add(Me.btnCancelarAgregarRecurso)
        Me.gbAgregarRecurso.Controls.Add(Me.btnOkAgregarRecurso)
        Me.gbAgregarRecurso.Controls.Add(Me.lblAgregarRecurso)
        Me.gbAgregarRecurso.Location = New System.Drawing.Point(488, 29)
        Me.gbAgregarRecurso.Name = "gbAgregarRecurso"
        Me.gbAgregarRecurso.Size = New System.Drawing.Size(352, 178)
        Me.gbAgregarRecurso.TabIndex = 29
        Me.gbAgregarRecurso.TabStop = False
        Me.gbAgregarRecurso.Text = "AGREGAR UN NUEVO RECURSO"
        '
        'btnCancelarAgregarRecurso
        '
        Me.btnCancelarAgregarRecurso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarAgregarRecurso.Location = New System.Drawing.Point(197, 134)
        Me.btnCancelarAgregarRecurso.Name = "btnCancelarAgregarRecurso"
        Me.btnCancelarAgregarRecurso.Size = New System.Drawing.Size(100, 29)
        Me.btnCancelarAgregarRecurso.TabIndex = 32
        Me.btnCancelarAgregarRecurso.Text = "Cancelar"
        Me.btnCancelarAgregarRecurso.UseVisualStyleBackColor = True
        '
        'btnOkAgregarRecurso
        '
        Me.btnOkAgregarRecurso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOkAgregarRecurso.Location = New System.Drawing.Point(52, 134)
        Me.btnOkAgregarRecurso.Name = "btnOkAgregarRecurso"
        Me.btnOkAgregarRecurso.Size = New System.Drawing.Size(100, 29)
        Me.btnOkAgregarRecurso.TabIndex = 31
        Me.btnOkAgregarRecurso.Text = "Ok"
        Me.btnOkAgregarRecurso.UseVisualStyleBackColor = True
        '
        'lblAgregarRecurso
        '
        Me.lblAgregarRecurso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgregarRecurso.Location = New System.Drawing.Point(6, 51)
        Me.lblAgregarRecurso.Name = "lblAgregarRecurso"
        Me.lblAgregarRecurso.Size = New System.Drawing.Size(71, 20)
        Me.lblAgregarRecurso.TabIndex = 30
        Me.lblAgregarRecurso.Text = "Recurso:"
        Me.lblAgregarRecurso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAgregarRecurso
        '
        Me.txtAgregarRecurso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAgregarRecurso.Location = New System.Drawing.Point(69, 51)
        Me.txtAgregarRecurso.Name = "txtAgregarRecurso"
        Me.txtAgregarRecurso.Size = New System.Drawing.Size(277, 22)
        Me.txtAgregarRecurso.TabIndex = 29
        '
        'gbModificarRecurso
        '
        Me.gbModificarRecurso.Controls.Add(Me.txtEditarRecurso)
        Me.gbModificarRecurso.Controls.Add(Me.btnCancelarEditarRecurso)
        Me.gbModificarRecurso.Controls.Add(Me.btnOkEditarRecurso)
        Me.gbModificarRecurso.Controls.Add(Me.lblEditarRecurso)
        Me.gbModificarRecurso.Location = New System.Drawing.Point(464, 287)
        Me.gbModificarRecurso.Name = "gbModificarRecurso"
        Me.gbModificarRecurso.Size = New System.Drawing.Size(352, 193)
        Me.gbModificarRecurso.TabIndex = 30
        Me.gbModificarRecurso.TabStop = False
        Me.gbModificarRecurso.Text = "MODIFICAR UN RECURSO"
        '
        'btnCancelarEditarRecurso
        '
        Me.btnCancelarEditarRecurso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarEditarRecurso.Location = New System.Drawing.Point(197, 143)
        Me.btnCancelarEditarRecurso.Name = "btnCancelarEditarRecurso"
        Me.btnCancelarEditarRecurso.Size = New System.Drawing.Size(100, 29)
        Me.btnCancelarEditarRecurso.TabIndex = 32
        Me.btnCancelarEditarRecurso.Text = "Cancelar"
        Me.btnCancelarEditarRecurso.UseVisualStyleBackColor = True
        '
        'btnOkEditarRecurso
        '
        Me.btnOkEditarRecurso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOkEditarRecurso.Location = New System.Drawing.Point(52, 143)
        Me.btnOkEditarRecurso.Name = "btnOkEditarRecurso"
        Me.btnOkEditarRecurso.Size = New System.Drawing.Size(100, 29)
        Me.btnOkEditarRecurso.TabIndex = 31
        Me.btnOkEditarRecurso.Text = "Ok"
        Me.btnOkEditarRecurso.UseVisualStyleBackColor = True
        '
        'lblEditarRecurso
        '
        Me.lblEditarRecurso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarRecurso.Location = New System.Drawing.Point(6, 54)
        Me.lblEditarRecurso.Name = "lblEditarRecurso"
        Me.lblEditarRecurso.Size = New System.Drawing.Size(64, 20)
        Me.lblEditarRecurso.TabIndex = 30
        Me.lblEditarRecurso.Text = "Recurso:"
        Me.lblEditarRecurso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEditarRecurso
        '
        Me.txtEditarRecurso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditarRecurso.Location = New System.Drawing.Point(70, 54)
        Me.txtEditarRecurso.Name = "txtEditarRecurso"
        Me.txtEditarRecurso.Size = New System.Drawing.Size(273, 22)
        Me.txtEditarRecurso.TabIndex = 29
        '
        'frmABMRecursosTareas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(867, 533)
        Me.Controls.Add(Me.gbModificarRecurso)
        Me.Controls.Add(Me.gbAgregarRecurso)
        Me.Controls.Add(Me.lblBuscar)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.dgvRecursos)
        Me.Controls.Add(Me.btnCerrar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmABMRecursosTareas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM Recursos  para Tareas de Mantenimiento"
        CType(Me.dgvRecursos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAgregarRecurso.ResumeLayout(False)
        Me.gbAgregarRecurso.PerformLayout()
        Me.gbModificarRecurso.ResumeLayout(False)
        Me.gbModificarRecurso.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvRecursos As System.Windows.Forms.DataGridView
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents gbAgregarRecurso As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelarAgregarRecurso As System.Windows.Forms.Button
    Friend WithEvents btnOkAgregarRecurso As System.Windows.Forms.Button
    Friend WithEvents lblAgregarRecurso As System.Windows.Forms.Label
    Friend WithEvents txtAgregarRecurso As System.Windows.Forms.TextBox
    Friend WithEvents gbModificarRecurso As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelarEditarRecurso As System.Windows.Forms.Button
    Friend WithEvents btnOkEditarRecurso As System.Windows.Forms.Button
    Friend WithEvents lblEditarRecurso As System.Windows.Forms.Label
    Friend WithEvents txtEditarRecurso As System.Windows.Forms.TextBox
End Class
