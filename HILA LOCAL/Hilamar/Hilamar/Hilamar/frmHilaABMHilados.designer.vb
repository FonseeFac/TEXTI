<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHilaABMHilados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHilaABMHilados))
        Me.gbModificarHilado = New System.Windows.Forms.GroupBox()
        Me.txtEditarDescripcion = New System.Windows.Forms.TextBox()
        Me.lblEditarDescripcion = New System.Windows.Forms.Label()
        Me.btnCancelarEditarHilado = New System.Windows.Forms.Button()
        Me.btnOkEditarHilado = New System.Windows.Forms.Button()
        Me.lblEditarCodigo = New System.Windows.Forms.Label()
        Me.txtEditarCodigo = New System.Windows.Forms.TextBox()
        Me.gbAgregarHilado = New System.Windows.Forms.GroupBox()
        Me.txtAgregarDescripcion = New System.Windows.Forms.TextBox()
        Me.lblAgregarDescripcion = New System.Windows.Forms.Label()
        Me.btnCancelarAgregarHilado = New System.Windows.Forms.Button()
        Me.btnOkAgregarHilado = New System.Windows.Forms.Button()
        Me.lblAgregarCodigo = New System.Windows.Forms.Label()
        Me.txtAgregarCodigo = New System.Windows.Forms.TextBox()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.dgvHilados = New System.Windows.Forms.DataGridView()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.gbModificarHilado.SuspendLayout()
        Me.gbAgregarHilado.SuspendLayout()
        CType(Me.dgvHilados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbModificarHilado
        '
        Me.gbModificarHilado.Controls.Add(Me.txtEditarDescripcion)
        Me.gbModificarHilado.Controls.Add(Me.lblEditarDescripcion)
        Me.gbModificarHilado.Controls.Add(Me.btnCancelarEditarHilado)
        Me.gbModificarHilado.Controls.Add(Me.btnOkEditarHilado)
        Me.gbModificarHilado.Controls.Add(Me.lblEditarCodigo)
        Me.gbModificarHilado.Controls.Add(Me.txtEditarCodigo)
        Me.gbModificarHilado.Location = New System.Drawing.Point(483, 282)
        Me.gbModificarHilado.Name = "gbModificarHilado"
        Me.gbModificarHilado.Size = New System.Drawing.Size(352, 189)
        Me.gbModificarHilado.TabIndex = 39
        Me.gbModificarHilado.TabStop = False
        Me.gbModificarHilado.Text = "MODIFICAR UN HILADO"
        '
        'txtEditarDescripcion
        '
        Me.txtEditarDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditarDescripcion.Location = New System.Drawing.Point(90, 83)
        Me.txtEditarDescripcion.Name = "txtEditarDescripcion"
        Me.txtEditarDescripcion.Size = New System.Drawing.Size(245, 22)
        Me.txtEditarDescripcion.TabIndex = 38
        '
        'lblEditarDescripcion
        '
        Me.lblEditarDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarDescripcion.Location = New System.Drawing.Point(6, 85)
        Me.lblEditarDescripcion.Name = "lblEditarDescripcion"
        Me.lblEditarDescripcion.Size = New System.Drawing.Size(86, 20)
        Me.lblEditarDescripcion.TabIndex = 37
        Me.lblEditarDescripcion.Text = "Descripción:"
        Me.lblEditarDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancelarEditarHilado
        '
        Me.btnCancelarEditarHilado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarEditarHilado.Location = New System.Drawing.Point(197, 136)
        Me.btnCancelarEditarHilado.Name = "btnCancelarEditarHilado"
        Me.btnCancelarEditarHilado.Size = New System.Drawing.Size(100, 29)
        Me.btnCancelarEditarHilado.TabIndex = 32
        Me.btnCancelarEditarHilado.Text = "Cancelar"
        Me.btnCancelarEditarHilado.UseVisualStyleBackColor = True
        '
        'btnOkEditarHilado
        '
        Me.btnOkEditarHilado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOkEditarHilado.Location = New System.Drawing.Point(52, 136)
        Me.btnOkEditarHilado.Name = "btnOkEditarHilado"
        Me.btnOkEditarHilado.Size = New System.Drawing.Size(100, 29)
        Me.btnOkEditarHilado.TabIndex = 31
        Me.btnOkEditarHilado.Text = "Ok"
        Me.btnOkEditarHilado.UseVisualStyleBackColor = True
        '
        'lblEditarCodigo
        '
        Me.lblEditarCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarCodigo.Location = New System.Drawing.Point(6, 41)
        Me.lblEditarCodigo.Name = "lblEditarCodigo"
        Me.lblEditarCodigo.Size = New System.Drawing.Size(69, 20)
        Me.lblEditarCodigo.TabIndex = 30
        Me.lblEditarCodigo.Text = "Código:"
        Me.lblEditarCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEditarCodigo
        '
        Me.txtEditarCodigo.Enabled = False
        Me.txtEditarCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditarCodigo.Location = New System.Drawing.Point(90, 41)
        Me.txtEditarCodigo.Name = "txtEditarCodigo"
        Me.txtEditarCodigo.Size = New System.Drawing.Size(133, 22)
        Me.txtEditarCodigo.TabIndex = 29
        '
        'gbAgregarHilado
        '
        Me.gbAgregarHilado.Controls.Add(Me.txtAgregarDescripcion)
        Me.gbAgregarHilado.Controls.Add(Me.lblAgregarDescripcion)
        Me.gbAgregarHilado.Controls.Add(Me.btnCancelarAgregarHilado)
        Me.gbAgregarHilado.Controls.Add(Me.btnOkAgregarHilado)
        Me.gbAgregarHilado.Controls.Add(Me.lblAgregarCodigo)
        Me.gbAgregarHilado.Controls.Add(Me.txtAgregarCodigo)
        Me.gbAgregarHilado.Location = New System.Drawing.Point(483, 49)
        Me.gbAgregarHilado.Name = "gbAgregarHilado"
        Me.gbAgregarHilado.Size = New System.Drawing.Size(352, 204)
        Me.gbAgregarHilado.TabIndex = 38
        Me.gbAgregarHilado.TabStop = False
        Me.gbAgregarHilado.Text = "AGREGAR UN NUEVO HILADO"
        '
        'txtAgregarDescripcion
        '
        Me.txtAgregarDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAgregarDescripcion.Location = New System.Drawing.Point(90, 74)
        Me.txtAgregarDescripcion.Name = "txtAgregarDescripcion"
        Me.txtAgregarDescripcion.Size = New System.Drawing.Size(245, 22)
        Me.txtAgregarDescripcion.TabIndex = 36
        '
        'lblAgregarDescripcion
        '
        Me.lblAgregarDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgregarDescripcion.Location = New System.Drawing.Point(6, 74)
        Me.lblAgregarDescripcion.Name = "lblAgregarDescripcion"
        Me.lblAgregarDescripcion.Size = New System.Drawing.Size(86, 20)
        Me.lblAgregarDescripcion.TabIndex = 35
        Me.lblAgregarDescripcion.Text = "Descripción:"
        Me.lblAgregarDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancelarAgregarHilado
        '
        Me.btnCancelarAgregarHilado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarAgregarHilado.Location = New System.Drawing.Point(197, 141)
        Me.btnCancelarAgregarHilado.Name = "btnCancelarAgregarHilado"
        Me.btnCancelarAgregarHilado.Size = New System.Drawing.Size(100, 29)
        Me.btnCancelarAgregarHilado.TabIndex = 32
        Me.btnCancelarAgregarHilado.Text = "Cancelar"
        Me.btnCancelarAgregarHilado.UseVisualStyleBackColor = True
        '
        'btnOkAgregarHilado
        '
        Me.btnOkAgregarHilado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOkAgregarHilado.Location = New System.Drawing.Point(52, 141)
        Me.btnOkAgregarHilado.Name = "btnOkAgregarHilado"
        Me.btnOkAgregarHilado.Size = New System.Drawing.Size(100, 29)
        Me.btnOkAgregarHilado.TabIndex = 31
        Me.btnOkAgregarHilado.Text = "Ok"
        Me.btnOkAgregarHilado.UseVisualStyleBackColor = True
        '
        'lblAgregarCodigo
        '
        Me.lblAgregarCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgregarCodigo.Location = New System.Drawing.Point(6, 33)
        Me.lblAgregarCodigo.Name = "lblAgregarCodigo"
        Me.lblAgregarCodigo.Size = New System.Drawing.Size(78, 20)
        Me.lblAgregarCodigo.TabIndex = 30
        Me.lblAgregarCodigo.Text = "Código:"
        Me.lblAgregarCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAgregarCodigo
        '
        Me.txtAgregarCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAgregarCodigo.Location = New System.Drawing.Point(90, 33)
        Me.txtAgregarCodigo.Name = "txtAgregarCodigo"
        Me.txtAgregarCodigo.Size = New System.Drawing.Size(133, 22)
        Me.txtAgregarCodigo.TabIndex = 29
        '
        'lblBuscar
        '
        Me.lblBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBuscar.Location = New System.Drawing.Point(20, 31)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(55, 20)
        Me.lblBuscar.TabIndex = 37
        Me.lblBuscar.Text = "Hilado:"
        Me.lblBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBuscar
        '
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(81, 29)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(226, 22)
        Me.txtBuscar.TabIndex = 36
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Location = New System.Drawing.Point(356, 168)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(107, 32)
        Me.btnEliminar.TabIndex = 35
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Location = New System.Drawing.Point(356, 112)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(107, 32)
        Me.btnEditar.TabIndex = 34
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Location = New System.Drawing.Point(356, 60)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(107, 32)
        Me.btnAgregar.TabIndex = 33
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'dgvHilados
        '
        Me.dgvHilados.AllowUserToAddRows = False
        Me.dgvHilados.AllowUserToDeleteRows = False
        Me.dgvHilados.AllowUserToResizeColumns = False
        Me.dgvHilados.AllowUserToResizeRows = False
        Me.dgvHilados.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvHilados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHilados.Location = New System.Drawing.Point(7, 60)
        Me.dgvHilados.Name = "dgvHilados"
        Me.dgvHilados.ReadOnly = True
        Me.dgvHilados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvHilados.Size = New System.Drawing.Size(333, 476)
        Me.dgvHilados.TabIndex = 32
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(356, 486)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(107, 32)
        Me.btnCerrar.TabIndex = 31
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'frmHilaABMHilados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 551)
        Me.Controls.Add(Me.gbModificarHilado)
        Me.Controls.Add(Me.gbAgregarHilado)
        Me.Controls.Add(Me.lblBuscar)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.dgvHilados)
        Me.Controls.Add(Me.btnCerrar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmHilaABMHilados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM Hilados"
        Me.gbModificarHilado.ResumeLayout(False)
        Me.gbModificarHilado.PerformLayout()
        Me.gbAgregarHilado.ResumeLayout(False)
        Me.gbAgregarHilado.PerformLayout()
        CType(Me.dgvHilados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbModificarHilado As System.Windows.Forms.GroupBox
    Friend WithEvents lblEditarDescripcion As System.Windows.Forms.Label
    Friend WithEvents btnCancelarEditarHilado As System.Windows.Forms.Button
    Friend WithEvents btnOkEditarHilado As System.Windows.Forms.Button
    Friend WithEvents lblEditarCodigo As System.Windows.Forms.Label
    Friend WithEvents txtEditarCodigo As System.Windows.Forms.TextBox
    Friend WithEvents gbAgregarHilado As System.Windows.Forms.GroupBox
    Friend WithEvents lblAgregarDescripcion As System.Windows.Forms.Label
    Friend WithEvents btnCancelarAgregarHilado As System.Windows.Forms.Button
    Friend WithEvents btnOkAgregarHilado As System.Windows.Forms.Button
    Friend WithEvents lblAgregarCodigo As System.Windows.Forms.Label
    Friend WithEvents txtAgregarCodigo As System.Windows.Forms.TextBox
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents dgvHilados As System.Windows.Forms.DataGridView
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents txtAgregarDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtEditarDescripcion As System.Windows.Forms.TextBox
End Class
