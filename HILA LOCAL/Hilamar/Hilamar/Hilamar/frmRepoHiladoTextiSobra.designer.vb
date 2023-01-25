<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepoHiladoTextiSobra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepoHiladoTextiSobra))
        Me.cmdVolver = New System.Windows.Forms.Button()
        Me.dgvSobrantes = New System.Windows.Forms.DataGridView()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnTerminar = New System.Windows.Forms.Button()
        Me.chkVerTerminados = New System.Windows.Forms.CheckBox()
        Me.gbObservaciones = New System.Windows.Forms.GroupBox()
        Me.rbSinObservaciones = New System.Windows.Forms.RadioButton()
        Me.rbConObservaciones = New System.Windows.Forms.RadioButton()
        Me.rbTodos = New System.Windows.Forms.RadioButton()
        Me.txtPartida = New System.Windows.Forms.TextBox()
        Me.lblPartida = New System.Windows.Forms.Label()
        Me.btnListar = New System.Windows.Forms.Button()
        CType(Me.dgvSobrantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbObservaciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdVolver
        '
        Me.cmdVolver.Location = New System.Drawing.Point(835, 437)
        Me.cmdVolver.Name = "cmdVolver"
        Me.cmdVolver.Size = New System.Drawing.Size(75, 23)
        Me.cmdVolver.TabIndex = 6
        Me.cmdVolver.Text = "Volver"
        Me.cmdVolver.UseVisualStyleBackColor = True
        '
        'dgvSobrantes
        '
        Me.dgvSobrantes.AllowUserToAddRows = False
        Me.dgvSobrantes.AllowUserToDeleteRows = False
        Me.dgvSobrantes.AllowUserToResizeColumns = False
        Me.dgvSobrantes.AllowUserToResizeRows = False
        Me.dgvSobrantes.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvSobrantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSobrantes.Location = New System.Drawing.Point(6, 46)
        Me.dgvSobrantes.MultiSelect = False
        Me.dgvSobrantes.Name = "dgvSobrantes"
        Me.dgvSobrantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSobrantes.Size = New System.Drawing.Size(823, 414)
        Me.dgvSobrantes.TabIndex = 8
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(835, 104)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminar.TabIndex = 11
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(835, 75)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(75, 23)
        Me.btnModificar.TabIndex = 10
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(835, 46)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 9
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnTerminar
        '
        Me.btnTerminar.Location = New System.Drawing.Point(835, 164)
        Me.btnTerminar.Name = "btnTerminar"
        Me.btnTerminar.Size = New System.Drawing.Size(75, 23)
        Me.btnTerminar.TabIndex = 12
        Me.btnTerminar.Text = "Terminar"
        Me.btnTerminar.UseVisualStyleBackColor = True
        '
        'chkVerTerminados
        '
        Me.chkVerTerminados.AutoSize = True
        Me.chkVerTerminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVerTerminados.Location = New System.Drawing.Point(697, 16)
        Me.chkVerTerminados.Name = "chkVerTerminados"
        Me.chkVerTerminados.Size = New System.Drawing.Size(124, 20)
        Me.chkVerTerminados.TabIndex = 13
        Me.chkVerTerminados.Text = "Ver Terminados"
        Me.chkVerTerminados.UseVisualStyleBackColor = True
        '
        'gbObservaciones
        '
        Me.gbObservaciones.Controls.Add(Me.rbSinObservaciones)
        Me.gbObservaciones.Controls.Add(Me.rbConObservaciones)
        Me.gbObservaciones.Controls.Add(Me.rbTodos)
        Me.gbObservaciones.Location = New System.Drawing.Point(321, 6)
        Me.gbObservaciones.Name = "gbObservaciones"
        Me.gbObservaciones.Size = New System.Drawing.Size(345, 34)
        Me.gbObservaciones.TabIndex = 14
        Me.gbObservaciones.TabStop = False
        '
        'rbSinObservaciones
        '
        Me.rbSinObservaciones.AutoSize = True
        Me.rbSinObservaciones.Location = New System.Drawing.Point(215, 11)
        Me.rbSinObservaciones.Name = "rbSinObservaciones"
        Me.rbSinObservaciones.Size = New System.Drawing.Size(114, 17)
        Me.rbSinObservaciones.TabIndex = 2
        Me.rbSinObservaciones.TabStop = True
        Me.rbSinObservaciones.Text = "Sin Observaciones"
        Me.rbSinObservaciones.UseVisualStyleBackColor = True
        '
        'rbConObservaciones
        '
        Me.rbConObservaciones.AutoSize = True
        Me.rbConObservaciones.Location = New System.Drawing.Point(88, 11)
        Me.rbConObservaciones.Name = "rbConObservaciones"
        Me.rbConObservaciones.Size = New System.Drawing.Size(118, 17)
        Me.rbConObservaciones.TabIndex = 1
        Me.rbConObservaciones.TabStop = True
        Me.rbConObservaciones.Text = "Con Observaciones"
        Me.rbConObservaciones.UseVisualStyleBackColor = True
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.Location = New System.Drawing.Point(17, 11)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(55, 17)
        Me.rbTodos.TabIndex = 0
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "Todos"
        Me.rbTodos.UseVisualStyleBackColor = True
        '
        'txtPartida
        '
        Me.txtPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartida.Location = New System.Drawing.Point(82, 15)
        Me.txtPartida.Name = "txtPartida"
        Me.txtPartida.Size = New System.Drawing.Size(139, 21)
        Me.txtPartida.TabIndex = 105
        '
        'lblPartida
        '
        Me.lblPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartida.Location = New System.Drawing.Point(12, 14)
        Me.lblPartida.Name = "lblPartida"
        Me.lblPartida.Size = New System.Drawing.Size(64, 23)
        Me.lblPartida.TabIndex = 104
        Me.lblPartida.Text = "Partida:"
        Me.lblPartida.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnListar
        '
        Me.btnListar.Location = New System.Drawing.Point(227, 14)
        Me.btnListar.Name = "btnListar"
        Me.btnListar.Size = New System.Drawing.Size(75, 23)
        Me.btnListar.TabIndex = 106
        Me.btnListar.Text = "Listar"
        Me.btnListar.UseVisualStyleBackColor = True
        '
        'frmRepoHiladoTextiSobra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 466)
        Me.Controls.Add(Me.btnListar)
        Me.Controls.Add(Me.txtPartida)
        Me.Controls.Add(Me.lblPartida)
        Me.Controls.Add(Me.gbObservaciones)
        Me.Controls.Add(Me.chkVerTerminados)
        Me.Controls.Add(Me.btnTerminar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.dgvSobrantes)
        Me.Controls.Add(Me.cmdVolver)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmRepoHiladoTextiSobra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Partidas con Sobrantes en Planta"
        CType(Me.dgvSobrantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbObservaciones.ResumeLayout(False)
        Me.gbObservaciones.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdVolver As System.Windows.Forms.Button
    Friend WithEvents dgvSobrantes As System.Windows.Forms.DataGridView
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnTerminar As System.Windows.Forms.Button
    Friend WithEvents chkVerTerminados As System.Windows.Forms.CheckBox
    Friend WithEvents gbObservaciones As System.Windows.Forms.GroupBox
    Friend WithEvents rbSinObservaciones As System.Windows.Forms.RadioButton
    Friend WithEvents rbConObservaciones As System.Windows.Forms.RadioButton
    Friend WithEvents rbTodos As System.Windows.Forms.RadioButton
    Friend WithEvents txtPartida As System.Windows.Forms.TextBox
    Friend WithEvents lblPartida As System.Windows.Forms.Label
    Friend WithEvents btnListar As System.Windows.Forms.Button
End Class
