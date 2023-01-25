<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmABMMaquinas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmABMMaquinas))
        Me.dgvMaquinas = New System.Windows.Forms.DataGridView()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.lblMaquina = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.gbAgregarMaquina = New System.Windows.Forms.GroupBox()
        Me.lblAgregarObservacion = New System.Windows.Forms.Label()
        Me.txtAgregarObservacion = New System.Windows.Forms.TextBox()
        Me.cmbSectoresAgregar = New System.Windows.Forms.ComboBox()
        Me.lblSectorAgregar = New System.Windows.Forms.Label()
        Me.btnCancelarAgregarMaquina = New System.Windows.Forms.Button()
        Me.btnOkAgregarMaquina = New System.Windows.Forms.Button()
        Me.lblAgregarMaquina = New System.Windows.Forms.Label()
        Me.txtAgregarMaquina = New System.Windows.Forms.TextBox()
        Me.gbModificarMaquina = New System.Windows.Forms.GroupBox()
        Me.lblEditarObservacion = New System.Windows.Forms.Label()
        Me.txtEditarObservacion = New System.Windows.Forms.TextBox()
        Me.cmbSectoresEditar = New System.Windows.Forms.ComboBox()
        Me.lblEditarSector = New System.Windows.Forms.Label()
        Me.btnCancelarEditarMaquina = New System.Windows.Forms.Button()
        Me.btnOkEditarMaquina = New System.Windows.Forms.Button()
        Me.lblEditarMaquina = New System.Windows.Forms.Label()
        Me.txtEditarMaquina = New System.Windows.Forms.TextBox()
        Me.gbOrden = New System.Windows.Forms.GroupBox()
        Me.rbOrdenSector = New System.Windows.Forms.RadioButton()
        Me.rbOrdenMaquina = New System.Windows.Forms.RadioButton()
        Me.lblSector = New System.Windows.Forms.Label()
        Me.txtSector = New System.Windows.Forms.TextBox()
        CType(Me.dgvMaquinas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAgregarMaquina.SuspendLayout()
        Me.gbModificarMaquina.SuspendLayout()
        Me.gbOrden.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvMaquinas
        '
        Me.dgvMaquinas.AllowUserToAddRows = False
        Me.dgvMaquinas.AllowUserToDeleteRows = False
        Me.dgvMaquinas.AllowUserToResizeColumns = False
        Me.dgvMaquinas.AllowUserToResizeRows = False
        Me.dgvMaquinas.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvMaquinas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMaquinas.Location = New System.Drawing.Point(12, 40)
        Me.dgvMaquinas.Name = "dgvMaquinas"
        Me.dgvMaquinas.ReadOnly = True
        Me.dgvMaquinas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMaquinas.Size = New System.Drawing.Size(523, 476)
        Me.dgvMaquinas.TabIndex = 22
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Location = New System.Drawing.Point(541, 466)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(107, 32)
        Me.btnCerrar.TabIndex = 18
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Location = New System.Drawing.Point(541, 124)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(107, 32)
        Me.btnAgregar.TabIndex = 23
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnEditar
        '
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Location = New System.Drawing.Point(541, 176)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(107, 32)
        Me.btnEditar.TabIndex = 24
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Location = New System.Drawing.Point(541, 232)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(107, 32)
        Me.btnEliminar.TabIndex = 25
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'lblMaquina
        '
        Me.lblMaquina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaquina.Location = New System.Drawing.Point(2, 11)
        Me.lblMaquina.Name = "lblMaquina"
        Me.lblMaquina.Size = New System.Drawing.Size(66, 20)
        Me.lblMaquina.TabIndex = 28
        Me.lblMaquina.Text = "Máquina:"
        Me.lblMaquina.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBuscar
        '
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(74, 12)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(194, 22)
        Me.txtBuscar.TabIndex = 27
        '
        'gbAgregarMaquina
        '
        Me.gbAgregarMaquina.Controls.Add(Me.lblAgregarObservacion)
        Me.gbAgregarMaquina.Controls.Add(Me.txtAgregarObservacion)
        Me.gbAgregarMaquina.Controls.Add(Me.cmbSectoresAgregar)
        Me.gbAgregarMaquina.Controls.Add(Me.lblSectorAgregar)
        Me.gbAgregarMaquina.Controls.Add(Me.btnCancelarAgregarMaquina)
        Me.gbAgregarMaquina.Controls.Add(Me.btnOkAgregarMaquina)
        Me.gbAgregarMaquina.Controls.Add(Me.lblAgregarMaquina)
        Me.gbAgregarMaquina.Controls.Add(Me.txtAgregarMaquina)
        Me.gbAgregarMaquina.Location = New System.Drawing.Point(654, 40)
        Me.gbAgregarMaquina.Name = "gbAgregarMaquina"
        Me.gbAgregarMaquina.Size = New System.Drawing.Size(466, 207)
        Me.gbAgregarMaquina.TabIndex = 29
        Me.gbAgregarMaquina.TabStop = False
        Me.gbAgregarMaquina.Text = "AGREGAR UNA NUEVA MÁQUINA"
        '
        'lblAgregarObservacion
        '
        Me.lblAgregarObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgregarObservacion.Location = New System.Drawing.Point(6, 108)
        Me.lblAgregarObservacion.Name = "lblAgregarObservacion"
        Me.lblAgregarObservacion.Size = New System.Drawing.Size(91, 20)
        Me.lblAgregarObservacion.TabIndex = 36
        Me.lblAgregarObservacion.Text = "Observación:"
        Me.lblAgregarObservacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAgregarObservacion
        '
        Me.txtAgregarObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAgregarObservacion.Location = New System.Drawing.Point(98, 107)
        Me.txtAgregarObservacion.Name = "txtAgregarObservacion"
        Me.txtAgregarObservacion.Size = New System.Drawing.Size(362, 22)
        Me.txtAgregarObservacion.TabIndex = 35
        '
        'cmbSectoresAgregar
        '
        Me.cmbSectoresAgregar.FormattingEnabled = True
        Me.cmbSectoresAgregar.Location = New System.Drawing.Point(139, 70)
        Me.cmbSectoresAgregar.Name = "cmbSectoresAgregar"
        Me.cmbSectoresAgregar.Size = New System.Drawing.Size(321, 21)
        Me.cmbSectoresAgregar.TabIndex = 34
        '
        'lblSectorAgregar
        '
        Me.lblSectorAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSectorAgregar.Location = New System.Drawing.Point(6, 70)
        Me.lblSectorAgregar.Name = "lblSectorAgregar"
        Me.lblSectorAgregar.Size = New System.Drawing.Size(69, 20)
        Me.lblSectorAgregar.TabIndex = 33
        Me.lblSectorAgregar.Text = "Sector:"
        Me.lblSectorAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancelarAgregarMaquina
        '
        Me.btnCancelarAgregarMaquina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarAgregarMaquina.Location = New System.Drawing.Point(254, 156)
        Me.btnCancelarAgregarMaquina.Name = "btnCancelarAgregarMaquina"
        Me.btnCancelarAgregarMaquina.Size = New System.Drawing.Size(100, 29)
        Me.btnCancelarAgregarMaquina.TabIndex = 32
        Me.btnCancelarAgregarMaquina.Text = "Cancelar"
        Me.btnCancelarAgregarMaquina.UseVisualStyleBackColor = True
        '
        'btnOkAgregarMaquina
        '
        Me.btnOkAgregarMaquina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOkAgregarMaquina.Location = New System.Drawing.Point(109, 156)
        Me.btnOkAgregarMaquina.Name = "btnOkAgregarMaquina"
        Me.btnOkAgregarMaquina.Size = New System.Drawing.Size(100, 29)
        Me.btnOkAgregarMaquina.TabIndex = 31
        Me.btnOkAgregarMaquina.Text = "Ok"
        Me.btnOkAgregarMaquina.UseVisualStyleBackColor = True
        '
        'lblAgregarMaquina
        '
        Me.lblAgregarMaquina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgregarMaquina.Location = New System.Drawing.Point(6, 33)
        Me.lblAgregarMaquina.Name = "lblAgregarMaquina"
        Me.lblAgregarMaquina.Size = New System.Drawing.Size(69, 20)
        Me.lblAgregarMaquina.TabIndex = 30
        Me.lblAgregarMaquina.Text = "Máquina:"
        Me.lblAgregarMaquina.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAgregarMaquina
        '
        Me.txtAgregarMaquina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAgregarMaquina.Location = New System.Drawing.Point(98, 33)
        Me.txtAgregarMaquina.Name = "txtAgregarMaquina"
        Me.txtAgregarMaquina.Size = New System.Drawing.Size(362, 22)
        Me.txtAgregarMaquina.TabIndex = 29
        '
        'gbModificarMaquina
        '
        Me.gbModificarMaquina.Controls.Add(Me.lblEditarObservacion)
        Me.gbModificarMaquina.Controls.Add(Me.txtEditarObservacion)
        Me.gbModificarMaquina.Controls.Add(Me.cmbSectoresEditar)
        Me.gbModificarMaquina.Controls.Add(Me.lblEditarSector)
        Me.gbModificarMaquina.Controls.Add(Me.btnCancelarEditarMaquina)
        Me.gbModificarMaquina.Controls.Add(Me.btnOkEditarMaquina)
        Me.gbModificarMaquina.Controls.Add(Me.lblEditarMaquina)
        Me.gbModificarMaquina.Controls.Add(Me.txtEditarMaquina)
        Me.gbModificarMaquina.Location = New System.Drawing.Point(654, 268)
        Me.gbModificarMaquina.Name = "gbModificarMaquina"
        Me.gbModificarMaquina.Size = New System.Drawing.Size(466, 203)
        Me.gbModificarMaquina.TabIndex = 30
        Me.gbModificarMaquina.TabStop = False
        Me.gbModificarMaquina.Text = "MODIFICAR UNA MÁQUINA"
        '
        'lblEditarObservacion
        '
        Me.lblEditarObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarObservacion.Location = New System.Drawing.Point(6, 113)
        Me.lblEditarObservacion.Name = "lblEditarObservacion"
        Me.lblEditarObservacion.Size = New System.Drawing.Size(91, 20)
        Me.lblEditarObservacion.TabIndex = 38
        Me.lblEditarObservacion.Text = "Observación:"
        Me.lblEditarObservacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEditarObservacion
        '
        Me.txtEditarObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditarObservacion.Location = New System.Drawing.Point(98, 112)
        Me.txtEditarObservacion.Name = "txtEditarObservacion"
        Me.txtEditarObservacion.Size = New System.Drawing.Size(362, 22)
        Me.txtEditarObservacion.TabIndex = 37
        '
        'cmbSectoresEditar
        '
        Me.cmbSectoresEditar.FormattingEnabled = True
        Me.cmbSectoresEditar.Location = New System.Drawing.Point(128, 70)
        Me.cmbSectoresEditar.Name = "cmbSectoresEditar"
        Me.cmbSectoresEditar.Size = New System.Drawing.Size(332, 21)
        Me.cmbSectoresEditar.TabIndex = 36
        '
        'lblEditarSector
        '
        Me.lblEditarSector.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarSector.Location = New System.Drawing.Point(6, 71)
        Me.lblEditarSector.Name = "lblEditarSector"
        Me.lblEditarSector.Size = New System.Drawing.Size(72, 20)
        Me.lblEditarSector.TabIndex = 35
        Me.lblEditarSector.Text = "Sector:"
        Me.lblEditarSector.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancelarEditarMaquina
        '
        Me.btnCancelarEditarMaquina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarEditarMaquina.Location = New System.Drawing.Point(263, 166)
        Me.btnCancelarEditarMaquina.Name = "btnCancelarEditarMaquina"
        Me.btnCancelarEditarMaquina.Size = New System.Drawing.Size(100, 29)
        Me.btnCancelarEditarMaquina.TabIndex = 32
        Me.btnCancelarEditarMaquina.Text = "Cancelar"
        Me.btnCancelarEditarMaquina.UseVisualStyleBackColor = True
        '
        'btnOkEditarMaquina
        '
        Me.btnOkEditarMaquina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOkEditarMaquina.Location = New System.Drawing.Point(118, 166)
        Me.btnOkEditarMaquina.Name = "btnOkEditarMaquina"
        Me.btnOkEditarMaquina.Size = New System.Drawing.Size(100, 29)
        Me.btnOkEditarMaquina.TabIndex = 31
        Me.btnOkEditarMaquina.Text = "Ok"
        Me.btnOkEditarMaquina.UseVisualStyleBackColor = True
        '
        'lblEditarMaquina
        '
        Me.lblEditarMaquina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditarMaquina.Location = New System.Drawing.Point(6, 33)
        Me.lblEditarMaquina.Name = "lblEditarMaquina"
        Me.lblEditarMaquina.Size = New System.Drawing.Size(68, 20)
        Me.lblEditarMaquina.TabIndex = 30
        Me.lblEditarMaquina.Text = "Maquina:"
        Me.lblEditarMaquina.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEditarMaquina
        '
        Me.txtEditarMaquina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEditarMaquina.Location = New System.Drawing.Point(98, 33)
        Me.txtEditarMaquina.Name = "txtEditarMaquina"
        Me.txtEditarMaquina.Size = New System.Drawing.Size(362, 22)
        Me.txtEditarMaquina.TabIndex = 29
        '
        'gbOrden
        '
        Me.gbOrden.Controls.Add(Me.rbOrdenSector)
        Me.gbOrden.Controls.Add(Me.rbOrdenMaquina)
        Me.gbOrden.Location = New System.Drawing.Point(544, 40)
        Me.gbOrden.Name = "gbOrden"
        Me.gbOrden.Size = New System.Drawing.Size(103, 68)
        Me.gbOrden.TabIndex = 31
        Me.gbOrden.TabStop = False
        Me.gbOrden.Text = "Ordenado por"
        '
        'rbOrdenSector
        '
        Me.rbOrdenSector.AutoSize = True
        Me.rbOrdenSector.Location = New System.Drawing.Point(16, 42)
        Me.rbOrdenSector.Name = "rbOrdenSector"
        Me.rbOrdenSector.Size = New System.Drawing.Size(56, 17)
        Me.rbOrdenSector.TabIndex = 1
        Me.rbOrdenSector.Text = "Sector"
        Me.rbOrdenSector.UseVisualStyleBackColor = True
        '
        'rbOrdenMaquina
        '
        Me.rbOrdenMaquina.AutoSize = True
        Me.rbOrdenMaquina.Checked = True
        Me.rbOrdenMaquina.Location = New System.Drawing.Point(16, 19)
        Me.rbOrdenMaquina.Name = "rbOrdenMaquina"
        Me.rbOrdenMaquina.Size = New System.Drawing.Size(66, 17)
        Me.rbOrdenMaquina.TabIndex = 0
        Me.rbOrdenMaquina.TabStop = True
        Me.rbOrdenMaquina.Text = "Máquina"
        Me.rbOrdenMaquina.UseVisualStyleBackColor = True
        '
        'lblSector
        '
        Me.lblSector.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSector.Location = New System.Drawing.Point(287, 11)
        Me.lblSector.Name = "lblSector"
        Me.lblSector.Size = New System.Drawing.Size(66, 20)
        Me.lblSector.TabIndex = 33
        Me.lblSector.Text = "Sector:"
        Me.lblSector.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSector
        '
        Me.txtSector.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSector.Location = New System.Drawing.Point(359, 12)
        Me.txtSector.Name = "txtSector"
        Me.txtSector.Size = New System.Drawing.Size(176, 22)
        Me.txtSector.TabIndex = 32
        '
        'frmABMMaquinas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1127, 533)
        Me.Controls.Add(Me.lblSector)
        Me.Controls.Add(Me.txtSector)
        Me.Controls.Add(Me.gbOrden)
        Me.Controls.Add(Me.gbModificarMaquina)
        Me.Controls.Add(Me.gbAgregarMaquina)
        Me.Controls.Add(Me.lblMaquina)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnEditar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.dgvMaquinas)
        Me.Controls.Add(Me.btnCerrar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmABMMaquinas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM de Máquinas"
        CType(Me.dgvMaquinas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAgregarMaquina.ResumeLayout(False)
        Me.gbAgregarMaquina.PerformLayout()
        Me.gbModificarMaquina.ResumeLayout(False)
        Me.gbModificarMaquina.PerformLayout()
        Me.gbOrden.ResumeLayout(False)
        Me.gbOrden.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvMaquinas As System.Windows.Forms.DataGridView
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents lblMaquina As System.Windows.Forms.Label
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents gbAgregarMaquina As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelarAgregarMaquina As System.Windows.Forms.Button
    Friend WithEvents btnOkAgregarMaquina As System.Windows.Forms.Button
    Friend WithEvents lblAgregarMaquina As System.Windows.Forms.Label
    Friend WithEvents txtAgregarMaquina As System.Windows.Forms.TextBox
    Friend WithEvents gbModificarMaquina As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelarEditarMaquina As System.Windows.Forms.Button
    Friend WithEvents btnOkEditarMaquina As System.Windows.Forms.Button
    Friend WithEvents lblEditarMaquina As System.Windows.Forms.Label
    Friend WithEvents txtEditarMaquina As System.Windows.Forms.TextBox
    Friend WithEvents cmbSectoresAgregar As System.Windows.Forms.ComboBox
    Friend WithEvents lblSectorAgregar As System.Windows.Forms.Label
    Friend WithEvents cmbSectoresEditar As System.Windows.Forms.ComboBox
    Friend WithEvents lblEditarSector As System.Windows.Forms.Label
    Friend WithEvents lblAgregarObservacion As System.Windows.Forms.Label
    Friend WithEvents txtAgregarObservacion As System.Windows.Forms.TextBox
    Friend WithEvents lblEditarObservacion As System.Windows.Forms.Label
    Friend WithEvents txtEditarObservacion As System.Windows.Forms.TextBox
    Friend WithEvents gbOrden As System.Windows.Forms.GroupBox
    Friend WithEvents rbOrdenSector As System.Windows.Forms.RadioButton
    Friend WithEvents rbOrdenMaquina As System.Windows.Forms.RadioButton
    Friend WithEvents lblSector As System.Windows.Forms.Label
    Friend WithEvents txtSector As System.Windows.Forms.TextBox
End Class
