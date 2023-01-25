<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIngresoStock
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIngresoStock))
        Me.tbBuscar = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.dgvListadoDeArticulos = New System.Windows.Forms.DataGridView()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnIngresarStockInicial = New System.Windows.Forms.Button()
        CType(Me.dgvListadoDeArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbBuscar
        '
        Me.tbBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbBuscar.Location = New System.Drawing.Point(35, 42)
        Me.tbBuscar.Name = "tbBuscar"
        Me.tbBuscar.Size = New System.Drawing.Size(161, 26)
        Me.tbBuscar.TabIndex = 0
        '
        'btnBuscar
        '
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Location = New System.Drawing.Point(224, 40)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 28)
        Me.btnBuscar.TabIndex = 1
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'dgvListadoDeArticulos
        '
        Me.dgvListadoDeArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListadoDeArticulos.Location = New System.Drawing.Point(35, 84)
        Me.dgvListadoDeArticulos.Name = "dgvListadoDeArticulos"
        Me.dgvListadoDeArticulos.Size = New System.Drawing.Size(264, 150)
        Me.dgvListadoDeArticulos.TabIndex = 2
        '
        'btnIngresarStockInicial
        '
        Me.btnIngresarStockInicial.Location = New System.Drawing.Point(347, 84)
        Me.btnIngresarStockInicial.Name = "btnIngresarStockInicial"
        Me.btnIngresarStockInicial.Size = New System.Drawing.Size(76, 46)
        Me.btnIngresarStockInicial.TabIndex = 3
        Me.btnIngresarStockInicial.Text = "Declarar Stock Inicial"
        Me.btnIngresarStockInicial.UseVisualStyleBackColor = True
        '
        'frmIngresoStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 281)
        Me.Controls.Add(Me.btnIngresarStockInicial)
        Me.Controls.Add(Me.dgvListadoDeArticulos)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.tbBuscar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmIngresoStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingresar Stock Inicial"
        CType(Me.dgvListadoDeArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbBuscar As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents dgvListadoDeArticulos As System.Windows.Forms.DataGridView
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents btnIngresarStockInicial As System.Windows.Forms.Button
End Class
