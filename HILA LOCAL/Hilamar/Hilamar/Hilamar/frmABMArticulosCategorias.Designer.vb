<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmABMArticulosCategorias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmABMArticulosCategorias))
        Me.tcCategorías = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnSalirAgregar = New System.Windows.Forms.Button()
        Me.btnAgregarCategoria = New System.Windows.Forms.Button()
        Me.lbNuevaCategoria = New System.Windows.Forms.Label()
        Me.tbNuevaCategoria = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnSalirModificar = New System.Windows.Forms.Button()
        Me.lblCategoriaActual = New System.Windows.Forms.Label()
        Me.cmbCategoriaActual = New System.Windows.Forms.ComboBox()
        Me.btnModificarCategoria = New System.Windows.Forms.Button()
        Me.lblNuevoNombre = New System.Windows.Forms.Label()
        Me.tbNuevoNombre = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnSalirEliminar = New System.Windows.Forms.Button()
        Me.btnEliminarCategoria = New System.Windows.Forms.Button()
        Me.lblCategoriaEliminar = New System.Windows.Forms.Label()
        Me.cmbCategoriaAEliminar = New System.Windows.Forms.ComboBox()
        Me.tcCategorías.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcCategorías
        '
        Me.tcCategorías.Controls.Add(Me.TabPage1)
        Me.tcCategorías.Controls.Add(Me.TabPage2)
        Me.tcCategorías.Controls.Add(Me.TabPage3)
        Me.tcCategorías.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcCategorías.Location = New System.Drawing.Point(13, 13)
        Me.tcCategorías.Margin = New System.Windows.Forms.Padding(4)
        Me.tcCategorías.Name = "tcCategorías"
        Me.tcCategorías.SelectedIndex = 0
        Me.tcCategorías.Size = New System.Drawing.Size(458, 235)
        Me.tcCategorías.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.Controls.Add(Me.btnSalirAgregar)
        Me.TabPage1.Controls.Add(Me.btnAgregarCategoria)
        Me.TabPage1.Controls.Add(Me.lbNuevaCategoria)
        Me.TabPage1.Controls.Add(Me.tbNuevaCategoria)
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
        'btnAgregarCategoria
        '
        Me.btnAgregarCategoria.Location = New System.Drawing.Point(308, 34)
        Me.btnAgregarCategoria.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAgregarCategoria.Name = "btnAgregarCategoria"
        Me.btnAgregarCategoria.Size = New System.Drawing.Size(108, 48)
        Me.btnAgregarCategoria.TabIndex = 2
        Me.btnAgregarCategoria.Text = "Crear"
        Me.btnAgregarCategoria.UseVisualStyleBackColor = True
        '
        'lbNuevaCategoria
        '
        Me.lbNuevaCategoria.AutoSize = True
        Me.lbNuevaCategoria.Location = New System.Drawing.Point(27, 34)
        Me.lbNuevaCategoria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbNuevaCategoria.Name = "lbNuevaCategoria"
        Me.lbNuevaCategoria.Size = New System.Drawing.Size(117, 16)
        Me.lbNuevaCategoria.TabIndex = 1
        Me.lbNuevaCategoria.Text = "Nombre categoría"
        '
        'tbNuevaCategoria
        '
        Me.tbNuevaCategoria.Location = New System.Drawing.Point(27, 58)
        Me.tbNuevaCategoria.Margin = New System.Windows.Forms.Padding(4)
        Me.tbNuevaCategoria.Name = "tbNuevaCategoria"
        Me.tbNuevaCategoria.Size = New System.Drawing.Size(215, 22)
        Me.tbNuevaCategoria.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.Controls.Add(Me.btnSalirModificar)
        Me.TabPage2.Controls.Add(Me.lblCategoriaActual)
        Me.TabPage2.Controls.Add(Me.cmbCategoriaActual)
        Me.TabPage2.Controls.Add(Me.btnModificarCategoria)
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
        'lblCategoriaActual
        '
        Me.lblCategoriaActual.AutoSize = True
        Me.lblCategoriaActual.Location = New System.Drawing.Point(25, 34)
        Me.lblCategoriaActual.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCategoriaActual.Name = "lblCategoriaActual"
        Me.lblCategoriaActual.Size = New System.Drawing.Size(99, 16)
        Me.lblCategoriaActual.TabIndex = 7
        Me.lblCategoriaActual.Text = "Nombre actual:"
        '
        'cmbCategoriaActual
        '
        Me.cmbCategoriaActual.FormattingEnabled = True
        Me.cmbCategoriaActual.Location = New System.Drawing.Point(25, 58)
        Me.cmbCategoriaActual.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCategoriaActual.Name = "cmbCategoriaActual"
        Me.cmbCategoriaActual.Size = New System.Drawing.Size(215, 24)
        Me.cmbCategoriaActual.TabIndex = 6
        Me.cmbCategoriaActual.Text = "Seleccione categoría"
        '
        'btnModificarCategoria
        '
        Me.btnModificarCategoria.Location = New System.Drawing.Point(308, 34)
        Me.btnModificarCategoria.Margin = New System.Windows.Forms.Padding(4)
        Me.btnModificarCategoria.Name = "btnModificarCategoria"
        Me.btnModificarCategoria.Size = New System.Drawing.Size(108, 48)
        Me.btnModificarCategoria.TabIndex = 5
        Me.btnModificarCategoria.Text = "Modificar"
        Me.btnModificarCategoria.UseVisualStyleBackColor = True
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
        Me.TabPage3.Controls.Add(Me.btnEliminarCategoria)
        Me.TabPage3.Controls.Add(Me.lblCategoriaEliminar)
        Me.TabPage3.Controls.Add(Me.cmbCategoriaAEliminar)
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
        'btnEliminarCategoria
        '
        Me.btnEliminarCategoria.Location = New System.Drawing.Point(308, 34)
        Me.btnEliminarCategoria.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEliminarCategoria.Name = "btnEliminarCategoria"
        Me.btnEliminarCategoria.Size = New System.Drawing.Size(108, 48)
        Me.btnEliminarCategoria.TabIndex = 10
        Me.btnEliminarCategoria.Text = "Eliminar"
        Me.btnEliminarCategoria.UseVisualStyleBackColor = True
        '
        'lblCategoriaEliminar
        '
        Me.lblCategoriaEliminar.AutoSize = True
        Me.lblCategoriaEliminar.Location = New System.Drawing.Point(27, 34)
        Me.lblCategoriaEliminar.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCategoriaEliminar.Name = "lblCategoriaEliminar"
        Me.lblCategoriaEliminar.Size = New System.Drawing.Size(131, 16)
        Me.lblCategoriaEliminar.TabIndex = 9
        Me.lblCategoriaEliminar.Text = "Categoria a eliminar:"
        '
        'cmbCategoriaAEliminar
        '
        Me.cmbCategoriaAEliminar.FormattingEnabled = True
        Me.cmbCategoriaAEliminar.Location = New System.Drawing.Point(27, 58)
        Me.cmbCategoriaAEliminar.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCategoriaAEliminar.Name = "cmbCategoriaAEliminar"
        Me.cmbCategoriaAEliminar.Size = New System.Drawing.Size(215, 24)
        Me.cmbCategoriaAEliminar.TabIndex = 8
        Me.cmbCategoriaAEliminar.Text = "Seleccione categoría"
        '
        'frmABMArticulosCategorias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 261)
        Me.Controls.Add(Me.tcCategorías)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmABMArticulosCategorias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM Categorías"
        Me.tcCategorías.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcCategorías As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents btnAgregarCategoria As System.Windows.Forms.Button
    Friend WithEvents lbNuevaCategoria As System.Windows.Forms.Label
    Friend WithEvents tbNuevaCategoria As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents lblCategoriaActual As System.Windows.Forms.Label
    Friend WithEvents cmbCategoriaActual As System.Windows.Forms.ComboBox
    Friend WithEvents btnModificarCategoria As System.Windows.Forms.Button
    Friend WithEvents lblNuevoNombre As System.Windows.Forms.Label
    Friend WithEvents tbNuevoNombre As System.Windows.Forms.TextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents lblCategoriaEliminar As System.Windows.Forms.Label
    Friend WithEvents cmbCategoriaAEliminar As System.Windows.Forms.ComboBox
    Friend WithEvents btnEliminarCategoria As System.Windows.Forms.Button
    Friend WithEvents btnSalirAgregar As System.Windows.Forms.Button
    Friend WithEvents btnSalirModificar As System.Windows.Forms.Button
    Friend WithEvents btnSalirEliminar As System.Windows.Forms.Button
End Class
