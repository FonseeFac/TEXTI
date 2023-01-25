<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmABMTareas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmABMTareas))
        Me.dgvTareas = New System.Windows.Forms.DataGridView()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.gbAgregarTareas = New System.Windows.Forms.GroupBox()
        Me.btnCancelarAgregarTarea = New System.Windows.Forms.Button()
        Me.btnOkAgregarTarea = New System.Windows.Forms.Button()
        Me.lblAgregarTarea = New System.Windows.Forms.Label()
        Me.txtAgregarTarea = New System.Windows.Forms.TextBox()
        Me.gbModificarTarea = New System.Windows.Forms.GroupBox()
        Me.btnCancelarEditarTarea = New System.Windows.Forms.Button()
        Me.btnOkEditarTarea = New System.Windows.Forms.Button()
        Me.lblEditarTarea = New System.Windows.Forms.Label()
        Me.txtEditarTarea = New System.Windows.Forms.TextBox()
        Me.lblTitListaDePlanesDeMant = New System.Windows.Forms.Label()
        Me.dgvListaDeMaquinas = New System.Windows.Forms.DataGridView()
        CType(Me.dgvTareas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAgregarTareas.SuspendLayout()
        Me.gbModificarTarea.SuspendLayout()
        CType(Me.dgvListaDeMaquinas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvTareas
        '
        Me.dgvTareas.AllowUserToAddRows = False
        Me.dgvTareas.AllowUserToDeleteRows = False
        Me.dgvTareas.AllowUserToResizeColumns = False
        Me.dgvTareas.AllowUserToResizeRows = False
        Me.dgvTareas.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvTareas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTareas.Location = New System.Drawing.Point(8, 40)
        Me.dgvTareas.Name = "dgvTareas"
        Me.dgvTareas.ReadOnly = True
        Me.dgvTareas.RowHeadersWidth = 35
        Me.dgvTareas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTareas.Size = New System.Drawing.Size(494, 476)
        Me.dgvTareas.TabIndex = 22
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(508, 466)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(107, 32)
        Me.btnCerrar.TabIndex = 18
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Location = New System.Drawing.Point(508, 40)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(107, 32)
        Me.btnAgregar.TabIndex = 23
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Location = New System.Drawing.Point(508, 92)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(107, 32)
        Me.btnEditar.TabIndex = 24
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Location = New System.Drawing.Point(508, 148)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(107, 32)
        Me.btnEliminar.TabIndex = 25
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBuscar.Location = New System.Drawing.Point(-5, 11)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(88, 20)
        Me.lblBuscar.TabIndex = 28
        Me.lblBuscar.Text = "Tarea:"
        Me.lblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBuscar
        '
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(89, 10)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(346, 22)
        Me.txtBuscar.TabIndex = 27
        '
        'gbAgregarTareas
        '
        Me.gbAgregarTareas.Controls.Add(Me.btnCancelarAgregarTarea)
        Me.gbAgregarTareas.Controls.Add(Me.btnOkAgregarTarea)
        Me.gbAgregarTareas.Controls.Add(Me.lblAgregarTarea)
        Me.gbAgregarTareas.Controls.Add(Me.txtAgregarTarea)
        Me.gbAgregarTareas.Location = New System.Drawing.Point(631, 40)
        Me.gbAgregarTareas.Name = "gbAgregarTareas"
        Me.gbAgregarTareas.Size = New System.Drawing.Size(390, 178)
        Me.gbAgregarTareas.TabIndex = 29
        Me.gbAgregarTareas.TabStop = False
        Me.gbAgregarTareas.Text = "AGREGAR UNA NUEVA TAREA"
        '
        'btnCancelarAgregarTarea
        '
        Me.btnCancelarAgregarTarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarAgregarTarea.Location = New System.Drawing.Point(197, 134)
        Me.btnCancelarAgregarTarea.Name = "btnCancelarAgregarTarea"
        Me.btnCancelarAgregarTarea.Size = New System.Drawing.Size(100, 29)
        Me.btnCancelarAgregarTarea.TabIndex = 32
        Me.btnCancelarAgregarTarea.Text = "Cancelar"
        Me.btnCancelarAgregarTarea.UseVisualStyleBackColor = True
        '
        'btnOkAgregarTarea
        '
        Me.btnOkAgregarTarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOkAgregarTarea.Location = New System.Drawing.Point(52, 134)
        Me.btnOkAgregarTarea.Name = "btnOkAgregarTarea"
        Me.btnOkAgregarTarea.Size = New System.Drawing.Size(100, 29)
        Me.btnOkAgregarTarea.TabIndex = 31
        Me.btnOkAgregarTarea.Text = "Ok"
        Me.btnOkAgregarTarea.UseVisualStyleBackColor = True
        '
        'lblAgregarTarea
        '
        Me.lblAgregarTarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgregarTarea.Location = New System.Drawing.Point(6, 33)
        Me.lblAgregarTarea.Name = "lblAgregarTarea"
        Me.lblAgregarTarea.Size = New System.Drawing.Size(50, 20)
        Me.lblAgregarTarea.TabIndex = 30
        Me.lblAgregarTarea.Text = "Tarea:"
        Me.lblAgregarTarea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAgregarTarea
        '
        Me.txtAgregarTarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAgregarTarea.Location = New System.Drawing.Point(62, 33)
        Me.txtAgregarTarea.Name = "txtAgregarTarea"
        Me.txtAgregarTarea.Size = New System.Drawing.Size(310, 22)
        Me.txtAgregarTarea.TabIndex = 29
        '
        'gbModificarTarea
        '
        Me.gbModificarTarea.Controls.Add(Me.dgvListaDeMaquinas)
        Me.gbModificarTarea.Controls.Add(Me.lblTitListaDePlanesDeMant)
        Me.gbModificarTarea.Controls.Add(Me.btnCancelarEditarTarea)
        Me.gbModificarTarea.Controls.Add(Me.btnOkEditarTarea)
        Me.gbModificarTarea.Controls.Add(Me.lblEditarTarea)
        Me.gbModificarTarea.Controls.Add(Me.txtEditarTarea)
        Me.gbModificarTarea.Location = New System.Drawing.Point(631, 224)
        Me.gbModificarTarea.Name = "gbModificarTarea"
        Me.gbModificarTarea.Size = New System.Drawing.Size(390, 274)
        Me.gbModificarTarea.TabIndex = 30
        Me.gbModificarTarea.TabStop = False
        Me.gbModificarTarea.Text = "MODIFICAR UNA TAREA"
        '
        'btnCancelarEditarTarea
        '
        Me.btnCancelarEditarTarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarEditarTarea.Location = New System.Drawing.Point(197, 70)
        Me.btnCancelarEditarTarea.Name = "btnCancelarEditarTarea"
        Me.btnCancelarEditarTarea.Size = New System.Drawing.Size(100, 29)
        Me.btnCancelarEditarTarea.TabIndex = 32
        Me.btnCancelarEditarTarea.Text = "Cancelar"
        Me.btnCancelarEditarTarea.UseVisualStyleBackColor = True
        '
        'btnOkEditarTarea
        '
        Me.btnOkEditarTarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOkEditarTarea.Location = New System.Drawing.Point(52, 70)
        Me.btnOkEditarTarea.Name = "btnOkEditarTarea"
        Me.btnOkEditarTarea.Size = New System.Drawing.Size(100, 29)
        Me.btnOkEditarTarea.TabIndex = 31
        Me.btnOkEditarTarea.Text = "Ok"
        Me.btnOkEditarTarea.UseVisualStyleBackColor = True
        '
        'lblEditarTarea
        '
        Me.lblEditarTarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarTarea.Location = New System.Drawing.Point(6, 33)
        Me.lblEditarTarea.Name = "lblEditarTarea"
        Me.lblEditarTarea.Size = New System.Drawing.Size(50, 20)
        Me.lblEditarTarea.TabIndex = 30
        Me.lblEditarTarea.Text = "Tarea:"
        Me.lblEditarTarea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEditarTarea
        '
        Me.txtEditarTarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditarTarea.Location = New System.Drawing.Point(62, 33)
        Me.txtEditarTarea.Name = "txtEditarTarea"
        Me.txtEditarTarea.Size = New System.Drawing.Size(310, 22)
        Me.txtEditarTarea.TabIndex = 29
        '
        'lblTitListaDePlanesDeMant
        '
        Me.lblTitListaDePlanesDeMant.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitListaDePlanesDeMant.Location = New System.Drawing.Point(6, 109)
        Me.lblTitListaDePlanesDeMant.Name = "lblTitListaDePlanesDeMant"
        Me.lblTitListaDePlanesDeMant.Size = New System.Drawing.Size(378, 21)
        Me.lblTitListaDePlanesDeMant.TabIndex = 33
        Me.lblTitListaDePlanesDeMant.Text = "Figura para el mantenimiento de las siguientes máquinas:"
        Me.lblTitListaDePlanesDeMant.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvListaDeMaquinas
        '
        Me.dgvListaDeMaquinas.AllowUserToAddRows = False
        Me.dgvListaDeMaquinas.AllowUserToDeleteRows = False
        Me.dgvListaDeMaquinas.AllowUserToResizeColumns = False
        Me.dgvListaDeMaquinas.AllowUserToResizeRows = False
        Me.dgvListaDeMaquinas.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvListaDeMaquinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListaDeMaquinas.Location = New System.Drawing.Point(9, 133)
        Me.dgvListaDeMaquinas.Name = "dgvListaDeMaquinas"
        Me.dgvListaDeMaquinas.ReadOnly = True
        Me.dgvListaDeMaquinas.RowHeadersVisible = False
        Me.dgvListaDeMaquinas.RowHeadersWidth = 35
        Me.dgvListaDeMaquinas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListaDeMaquinas.Size = New System.Drawing.Size(363, 135)
        Me.dgvListaDeMaquinas.TabIndex = 31
        '
        'frmABMTareas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1035, 533)
        Me.Controls.Add(Me.gbModificarTarea)
        Me.Controls.Add(Me.gbAgregarTareas)
        Me.Controls.Add(Me.lblBuscar)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.dgvTareas)
        Me.Controls.Add(Me.btnCerrar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmABMTareas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM Tareas de Mantenimiento"
        CType(Me.dgvTareas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAgregarTareas.ResumeLayout(False)
        Me.gbAgregarTareas.PerformLayout()
        Me.gbModificarTarea.ResumeLayout(False)
        Me.gbModificarTarea.PerformLayout()
        CType(Me.dgvListaDeMaquinas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvTareas As System.Windows.Forms.DataGridView
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents gbAgregarTareas As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelarAgregarTarea As System.Windows.Forms.Button
    Friend WithEvents btnOkAgregarTarea As System.Windows.Forms.Button
    Friend WithEvents lblAgregarTarea As System.Windows.Forms.Label
    Friend WithEvents txtAgregarTarea As System.Windows.Forms.TextBox
    Friend WithEvents gbModificarTarea As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelarEditarTarea As System.Windows.Forms.Button
    Friend WithEvents btnOkEditarTarea As System.Windows.Forms.Button
    Friend WithEvents lblEditarTarea As System.Windows.Forms.Label
    Friend WithEvents txtEditarTarea As System.Windows.Forms.TextBox
    Friend WithEvents dgvListaDeMaquinas As System.Windows.Forms.DataGridView
    Friend WithEvents lblTitListaDePlanesDeMant As System.Windows.Forms.Label
End Class
