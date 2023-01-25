<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListado))
        Me.lsbListado = New System.Windows.Forms.ListBox()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.lblBuscarDesc = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnSeleccionar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lsbListado
        '
        Me.lsbListado.FormattingEnabled = True
        Me.lsbListado.Location = New System.Drawing.Point(12, 38)
        Me.lsbListado.Name = "lsbListado"
        Me.lsbListado.Size = New System.Drawing.Size(310, 355)
        Me.lsbListado.TabIndex = 0
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(88, 11)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(234, 20)
        Me.txtBuscar.TabIndex = 4
        '
        'lblBuscarDesc
        '
        Me.lblBuscarDesc.Location = New System.Drawing.Point(12, 9)
        Me.lblBuscarDesc.Name = "lblBuscarDesc"
        Me.lblBuscarDesc.Size = New System.Drawing.Size(70, 23)
        Me.lblBuscarDesc.TabIndex = 3
        Me.lblBuscarDesc.Text = "Descripción:"
        Me.lblBuscarDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(336, 9)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(336, 38)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.TabIndex = 6
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(336, 67)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(75, 23)
        Me.btnModificar.TabIndex = 7
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(336, 96)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminar.TabIndex = 8
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(336, 370)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 9
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnSeleccionar
        '
        Me.btnSeleccionar.Location = New System.Drawing.Point(336, 137)
        Me.btnSeleccionar.Name = "btnSeleccionar"
        Me.btnSeleccionar.Size = New System.Drawing.Size(75, 23)
        Me.btnSeleccionar.TabIndex = 10
        Me.btnSeleccionar.Text = "Seleccionar"
        Me.btnSeleccionar.UseVisualStyleBackColor = True
        '
        'frmListado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 409)
        Me.Controls.Add(Me.btnSeleccionar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.lblBuscarDesc)
        Me.Controls.Add(Me.lsbListado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmListado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lsbListado As System.Windows.Forms.ListBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents lblBuscarDesc As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnSeleccionar As System.Windows.Forms.Button
End Class
