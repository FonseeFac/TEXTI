<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmABMMateriaPrima
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmABMMateriaPrima))
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.txtCostoPorKilo = New System.Windows.Forms.TextBox()
        Me.lblCostoPorKilo = New System.Windows.Forms.Label()
        Me.gbMoneda = New System.Windows.Forms.GroupBox()
        Me.rbPesos = New System.Windows.Forms.RadioButton()
        Me.rbDolares = New System.Windows.Forms.RadioButton()
        Me.gbMoneda.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.Location = New System.Drawing.Point(259, 122)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(81, 27)
        Me.cmdCancelar.TabIndex = 9
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGuardar.Location = New System.Drawing.Point(153, 122)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(81, 27)
        Me.cmdGuardar.TabIndex = 8
        Me.cmdGuardar.Text = "Guardar"
        Me.cmdGuardar.UseVisualStyleBackColor = True
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(120, 23)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(374, 23)
        Me.txtDescripcion.TabIndex = 7
        '
        'lblDescripcion
        '
        Me.lblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.Location = New System.Drawing.Point(17, 23)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(99, 23)
        Me.lblDescripcion.TabIndex = 6
        Me.lblDescripcion.Text = "Descripción:"
        Me.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCostoPorKilo
        '
        Me.txtCostoPorKilo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostoPorKilo.Location = New System.Drawing.Point(344, 69)
        Me.txtCostoPorKilo.Name = "txtCostoPorKilo"
        Me.txtCostoPorKilo.Size = New System.Drawing.Size(107, 23)
        Me.txtCostoPorKilo.TabIndex = 13
        '
        'lblCostoPorKilo
        '
        Me.lblCostoPorKilo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoPorKilo.Location = New System.Drawing.Point(229, 69)
        Me.lblCostoPorKilo.Name = "lblCostoPorKilo"
        Me.lblCostoPorKilo.Size = New System.Drawing.Size(111, 23)
        Me.lblCostoPorKilo.TabIndex = 12
        Me.lblCostoPorKilo.Text = "Costo por Kilo:"
        Me.lblCostoPorKilo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbMoneda
        '
        Me.gbMoneda.Controls.Add(Me.rbDolares)
        Me.gbMoneda.Controls.Add(Me.rbPesos)
        Me.gbMoneda.Location = New System.Drawing.Point(46, 61)
        Me.gbMoneda.Name = "gbMoneda"
        Me.gbMoneda.Size = New System.Drawing.Size(177, 34)
        Me.gbMoneda.TabIndex = 14
        Me.gbMoneda.TabStop = False
        '
        'rbPesos
        '
        Me.rbPesos.AutoSize = True
        Me.rbPesos.Location = New System.Drawing.Point(15, 11)
        Me.rbPesos.Name = "rbPesos"
        Me.rbPesos.Size = New System.Drawing.Size(54, 17)
        Me.rbPesos.TabIndex = 0
        Me.rbPesos.TabStop = True
        Me.rbPesos.Text = "Pesos"
        Me.rbPesos.UseVisualStyleBackColor = True
        '
        'rbDolares
        '
        Me.rbDolares.AutoSize = True
        Me.rbDolares.Location = New System.Drawing.Point(89, 11)
        Me.rbDolares.Name = "rbDolares"
        Me.rbDolares.Size = New System.Drawing.Size(61, 17)
        Me.rbDolares.TabIndex = 1
        Me.rbDolares.TabStop = True
        Me.rbDolares.Text = "Dolares"
        Me.rbDolares.UseVisualStyleBackColor = True
        '
        'frmABMMateriaPrima
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 177)
        Me.Controls.Add(Me.gbMoneda)
        Me.Controls.Add(Me.txtCostoPorKilo)
        Me.Controls.Add(Me.lblCostoPorKilo)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdGuardar)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.lblDescripcion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmABMMateriaPrima"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM Materia Prima"
        Me.gbMoneda.ResumeLayout(False)
        Me.gbMoneda.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdGuardar As System.Windows.Forms.Button
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents txtCostoPorKilo As System.Windows.Forms.TextBox
    Friend WithEvents lblCostoPorKilo As System.Windows.Forms.Label
    Friend WithEvents gbMoneda As System.Windows.Forms.GroupBox
    Friend WithEvents rbDolares As System.Windows.Forms.RadioButton
    Friend WithEvents rbPesos As System.Windows.Forms.RadioButton
End Class
