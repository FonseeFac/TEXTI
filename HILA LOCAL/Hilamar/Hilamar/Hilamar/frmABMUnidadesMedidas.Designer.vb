<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmABMUnidadesMedidas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmABMUnidadesMedidas))
        Me.tcUnidades = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnSalirAgregar = New System.Windows.Forms.Button()
        Me.btnAgregarUnidad = New System.Windows.Forms.Button()
        Me.lbNuevaUnidad = New System.Windows.Forms.Label()
        Me.tbNuevaUnidad = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnSalirModificar = New System.Windows.Forms.Button()
        Me.lblUnidadActualModif = New System.Windows.Forms.Label()
        Me.cmbUnidadActualModif = New System.Windows.Forms.ComboBox()
        Me.btnModificarUnidad = New System.Windows.Forms.Button()
        Me.lblNuevoNombre = New System.Windows.Forms.Label()
        Me.tbNuevoNombre = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnSalirEliminar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.lblUnidadAEliminar = New System.Windows.Forms.Label()
        Me.cmbUnidadAEliminar = New System.Windows.Forms.ComboBox()
        Me.tcUnidades.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcUnidades
        '
        Me.tcUnidades.Controls.Add(Me.TabPage1)
        Me.tcUnidades.Controls.Add(Me.TabPage2)
        Me.tcUnidades.Controls.Add(Me.TabPage3)
        Me.tcUnidades.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcUnidades.Location = New System.Drawing.Point(13, 13)
        Me.tcUnidades.Margin = New System.Windows.Forms.Padding(4)
        Me.tcUnidades.Name = "tcUnidades"
        Me.tcUnidades.SelectedIndex = 0
        Me.tcUnidades.Size = New System.Drawing.Size(458, 235)
        Me.tcUnidades.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.btnSalirAgregar)
        Me.TabPage1.Controls.Add(Me.btnAgregarUnidad)
        Me.TabPage1.Controls.Add(Me.lbNuevaUnidad)
        Me.TabPage1.Controls.Add(Me.tbNuevaUnidad)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage1.Size = New System.Drawing.Size(450, 206)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Agregar"
        '
        'btnSalirAgregar
        '
        Me.btnSalirAgregar.Location = New System.Drawing.Point(308, 126)
        Me.btnSalirAgregar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSalirAgregar.Name = "btnSalirAgregar"
        Me.btnSalirAgregar.Size = New System.Drawing.Size(108, 48)
        Me.btnSalirAgregar.TabIndex = 3
        Me.btnSalirAgregar.Text = "Salir"
        Me.btnSalirAgregar.UseVisualStyleBackColor = True
        '
        'btnAgregarUnidad
        '
        Me.btnAgregarUnidad.Location = New System.Drawing.Point(308, 34)
        Me.btnAgregarUnidad.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAgregarUnidad.Name = "btnAgregarUnidad"
        Me.btnAgregarUnidad.Size = New System.Drawing.Size(108, 48)
        Me.btnAgregarUnidad.TabIndex = 2
        Me.btnAgregarUnidad.Text = "Crear"
        Me.btnAgregarUnidad.UseVisualStyleBackColor = True
        '
        'lbNuevaUnidad
        '
        Me.lbNuevaUnidad.AutoSize = True
        Me.lbNuevaUnidad.Location = New System.Drawing.Point(27, 34)
        Me.lbNuevaUnidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbNuevaUnidad.Name = "lbNuevaUnidad"
        Me.lbNuevaUnidad.Size = New System.Drawing.Size(107, 16)
        Me.lbNuevaUnidad.TabIndex = 1
        Me.lbNuevaUnidad.Text = "Nombre Unidad:"
        '
        'tbNuevaUnidad
        '
        Me.tbNuevaUnidad.Location = New System.Drawing.Point(27, 58)
        Me.tbNuevaUnidad.Margin = New System.Windows.Forms.Padding(4)
        Me.tbNuevaUnidad.Name = "tbNuevaUnidad"
        Me.tbNuevaUnidad.Size = New System.Drawing.Size(215, 22)
        Me.tbNuevaUnidad.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.btnSalirModificar)
        Me.TabPage2.Controls.Add(Me.lblUnidadActualModif)
        Me.TabPage2.Controls.Add(Me.cmbUnidadActualModif)
        Me.TabPage2.Controls.Add(Me.btnModificarUnidad)
        Me.TabPage2.Controls.Add(Me.lblNuevoNombre)
        Me.TabPage2.Controls.Add(Me.tbNuevoNombre)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage2.Size = New System.Drawing.Size(450, 206)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Modificar"
        '
        'btnSalirModificar
        '
        Me.btnSalirModificar.Location = New System.Drawing.Point(308, 126)
        Me.btnSalirModificar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSalirModificar.Name = "btnSalirModificar"
        Me.btnSalirModificar.Size = New System.Drawing.Size(108, 48)
        Me.btnSalirModificar.TabIndex = 8
        Me.btnSalirModificar.Text = "Salir"
        Me.btnSalirModificar.UseVisualStyleBackColor = True
        '
        'lblUnidadActualModif
        '
        Me.lblUnidadActualModif.AutoSize = True
        Me.lblUnidadActualModif.Location = New System.Drawing.Point(25, 34)
        Me.lblUnidadActualModif.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUnidadActualModif.Name = "lblUnidadActualModif"
        Me.lblUnidadActualModif.Size = New System.Drawing.Size(99, 16)
        Me.lblUnidadActualModif.TabIndex = 7
        Me.lblUnidadActualModif.Text = "Nombre actual:"
        '
        'cmbUnidadActualModif
        '
        Me.cmbUnidadActualModif.FormattingEnabled = True
        Me.cmbUnidadActualModif.Location = New System.Drawing.Point(25, 58)
        Me.cmbUnidadActualModif.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbUnidadActualModif.Name = "cmbUnidadActualModif"
        Me.cmbUnidadActualModif.Size = New System.Drawing.Size(215, 24)
        Me.cmbUnidadActualModif.TabIndex = 6
        Me.cmbUnidadActualModif.Text = "Seleccione Unidad"
        '
        'btnModificarUnidad
        '
        Me.btnModificarUnidad.Location = New System.Drawing.Point(308, 34)
        Me.btnModificarUnidad.Margin = New System.Windows.Forms.Padding(4)
        Me.btnModificarUnidad.Name = "btnModificarUnidad"
        Me.btnModificarUnidad.Size = New System.Drawing.Size(108, 48)
        Me.btnModificarUnidad.TabIndex = 5
        Me.btnModificarUnidad.Text = "Modificar"
        Me.btnModificarUnidad.UseVisualStyleBackColor = True
        '
        'lblNuevoNombre
        '
        Me.lblNuevoNombre.AutoSize = True
        Me.lblNuevoNombre.Location = New System.Drawing.Point(25, 100)
        Me.lblNuevoNombre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNuevoNombre.Name = "lblNuevoNombre"
        Me.lblNuevoNombre.Size = New System.Drawing.Size(100, 16)
        Me.lblNuevoNombre.TabIndex = 4
        Me.lblNuevoNombre.Text = "Nuevo nombre:"
        '
        'tbNuevoNombre
        '
        Me.tbNuevoNombre.Location = New System.Drawing.Point(25, 123)
        Me.tbNuevoNombre.Margin = New System.Windows.Forms.Padding(4)
        Me.tbNuevoNombre.Name = "tbNuevoNombre"
        Me.tbNuevoNombre.Size = New System.Drawing.Size(215, 22)
        Me.tbNuevoNombre.TabIndex = 3
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage3.Controls.Add(Me.btnSalirEliminar)
        Me.TabPage3.Controls.Add(Me.btnEliminar)
        Me.TabPage3.Controls.Add(Me.lblUnidadAEliminar)
        Me.TabPage3.Controls.Add(Me.cmbUnidadAEliminar)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(450, 206)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Eliminar"
        '
        'btnSalirEliminar
        '
        Me.btnSalirEliminar.Location = New System.Drawing.Point(308, 126)
        Me.btnSalirEliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSalirEliminar.Name = "btnSalirEliminar"
        Me.btnSalirEliminar.Size = New System.Drawing.Size(108, 48)
        Me.btnSalirEliminar.TabIndex = 11
        Me.btnSalirEliminar.Text = "Salir"
        Me.btnSalirEliminar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(308, 34)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(108, 48)
        Me.btnEliminar.TabIndex = 10
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'lblUnidadAEliminar
        '
        Me.lblUnidadAEliminar.AutoSize = True
        Me.lblUnidadAEliminar.Location = New System.Drawing.Point(27, 34)
        Me.lblUnidadAEliminar.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUnidadAEliminar.Name = "lblUnidadAEliminar"
        Me.lblUnidadAEliminar.Size = New System.Drawing.Size(116, 16)
        Me.lblUnidadAEliminar.TabIndex = 9
        Me.lblUnidadAEliminar.Text = "Unidad a eliminar:"
        '
        'cmbUnidadAEliminar
        '
        Me.cmbUnidadAEliminar.FormattingEnabled = True
        Me.cmbUnidadAEliminar.Location = New System.Drawing.Point(27, 58)
        Me.cmbUnidadAEliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbUnidadAEliminar.Name = "cmbUnidadAEliminar"
        Me.cmbUnidadAEliminar.Size = New System.Drawing.Size(215, 24)
        Me.cmbUnidadAEliminar.TabIndex = 8
        Me.cmbUnidadAEliminar.Text = "Seleccione Unidad"
        '
        'frmABMUnidadesMedidas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 261)
        Me.Controls.Add(Me.tcUnidades)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmABMUnidadesMedidas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM Unidades"
        Me.tcUnidades.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcUnidades As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents btnSalirAgregar As System.Windows.Forms.Button
    Friend WithEvents btnAgregarUnidad As System.Windows.Forms.Button
    Friend WithEvents lbNuevaUnidad As System.Windows.Forms.Label
    Friend WithEvents tbNuevaUnidad As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnSalirModificar As System.Windows.Forms.Button
    Friend WithEvents lblUnidadActualModif As System.Windows.Forms.Label
    Friend WithEvents cmbUnidadActualModif As System.Windows.Forms.ComboBox
    Friend WithEvents btnModificarUnidad As System.Windows.Forms.Button
    Friend WithEvents lblNuevoNombre As System.Windows.Forms.Label
    Friend WithEvents tbNuevoNombre As System.Windows.Forms.TextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents btnSalirEliminar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents lblUnidadAEliminar As System.Windows.Forms.Label
    Friend WithEvents cmbUnidadAEliminar As System.Windows.Forms.ComboBox
End Class
