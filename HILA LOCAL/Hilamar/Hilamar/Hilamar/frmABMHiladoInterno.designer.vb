<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmABMHiladoInterno
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmABMHiladoInterno))
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.gbCostoFijo = New System.Windows.Forms.GroupBox()
        Me.chkCostoFijo = New System.Windows.Forms.CheckBox()
        Me.gbMoneda = New System.Windows.Forms.GroupBox()
        Me.rbDolares = New System.Windows.Forms.RadioButton()
        Me.rbPesos = New System.Windows.Forms.RadioButton()
        Me.txtCostoPorKilo = New System.Windows.Forms.TextBox()
        Me.lblCostoPorKilo = New System.Windows.Forms.Label()
        Me.gbCostoFijo.SuspendLayout()
        Me.gbMoneda.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.Location = New System.Drawing.Point(269, 223)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(81, 27)
        Me.cmdCancelar.TabIndex = 9
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGuardar.Location = New System.Drawing.Point(163, 223)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(81, 27)
        Me.cmdGuardar.TabIndex = 8
        Me.cmdGuardar.Text = "Guardar"
        Me.cmdGuardar.UseVisualStyleBackColor = True
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(115, 57)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(374, 23)
        Me.txtDescripcion.TabIndex = 7
        '
        'lblDescripcion
        '
        Me.lblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.Location = New System.Drawing.Point(12, 57)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(99, 23)
        Me.lblDescripcion.TabIndex = 6
        Me.lblDescripcion.Text = "Descripción:"
        Me.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCodigo
        '
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(115, 25)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(127, 23)
        Me.txtCodigo.TabIndex = 11
        '
        'lblCodigo
        '
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.Location = New System.Drawing.Point(12, 25)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(99, 23)
        Me.lblCodigo.TabIndex = 10
        Me.lblCodigo.Text = "Código:"
        Me.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbCostoFijo
        '
        Me.gbCostoFijo.Controls.Add(Me.chkCostoFijo)
        Me.gbCostoFijo.Controls.Add(Me.gbMoneda)
        Me.gbCostoFijo.Controls.Add(Me.txtCostoPorKilo)
        Me.gbCostoFijo.Controls.Add(Me.lblCostoPorKilo)
        Me.gbCostoFijo.Location = New System.Drawing.Point(15, 100)
        Me.gbCostoFijo.Name = "gbCostoFijo"
        Me.gbCostoFijo.Size = New System.Drawing.Size(485, 72)
        Me.gbCostoFijo.TabIndex = 19
        Me.gbCostoFijo.TabStop = False
        '
        'chkCostoFijo
        '
        Me.chkCostoFijo.AutoSize = True
        Me.chkCostoFijo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCostoFijo.Location = New System.Drawing.Point(6, 11)
        Me.chkCostoFijo.Name = "chkCostoFijo"
        Me.chkCostoFijo.Size = New System.Drawing.Size(136, 21)
        Me.chkCostoFijo.TabIndex = 22
        Me.chkCostoFijo.Text = "Utilizar Costo Fijo"
        Me.chkCostoFijo.UseVisualStyleBackColor = True
        '
        'gbMoneda
        '
        Me.gbMoneda.Controls.Add(Me.rbDolares)
        Me.gbMoneda.Controls.Add(Me.rbPesos)
        Me.gbMoneda.Location = New System.Drawing.Point(73, 32)
        Me.gbMoneda.Name = "gbMoneda"
        Me.gbMoneda.Size = New System.Drawing.Size(156, 34)
        Me.gbMoneda.TabIndex = 21
        Me.gbMoneda.TabStop = False
        '
        'rbDolares
        '
        Me.rbDolares.AutoSize = True
        Me.rbDolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDolares.Location = New System.Drawing.Point(75, 11)
        Me.rbDolares.Name = "rbDolares"
        Me.rbDolares.Size = New System.Drawing.Size(68, 19)
        Me.rbDolares.TabIndex = 1
        Me.rbDolares.TabStop = True
        Me.rbDolares.Text = "Dolares"
        Me.rbDolares.UseVisualStyleBackColor = True
        '
        'rbPesos
        '
        Me.rbPesos.AutoSize = True
        Me.rbPesos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPesos.Location = New System.Drawing.Point(15, 11)
        Me.rbPesos.Name = "rbPesos"
        Me.rbPesos.Size = New System.Drawing.Size(59, 19)
        Me.rbPesos.TabIndex = 0
        Me.rbPesos.TabStop = True
        Me.rbPesos.Text = "Pesos"
        Me.rbPesos.UseVisualStyleBackColor = True
        '
        'txtCostoPorKilo
        '
        Me.txtCostoPorKilo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostoPorKilo.Location = New System.Drawing.Point(343, 43)
        Me.txtCostoPorKilo.Name = "txtCostoPorKilo"
        Me.txtCostoPorKilo.Size = New System.Drawing.Size(131, 23)
        Me.txtCostoPorKilo.TabIndex = 20
        '
        'lblCostoPorKilo
        '
        Me.lblCostoPorKilo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoPorKilo.Location = New System.Drawing.Point(226, 43)
        Me.lblCostoPorKilo.Name = "lblCostoPorKilo"
        Me.lblCostoPorKilo.Size = New System.Drawing.Size(111, 23)
        Me.lblCostoPorKilo.TabIndex = 19
        Me.lblCostoPorKilo.Text = "Costo por Kilo:"
        Me.lblCostoPorKilo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmABMHiladoInterno
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 265)
        Me.Controls.Add(Me.gbCostoFijo)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.lblCodigo)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdGuardar)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.lblDescripcion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmABMHiladoInterno"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM Hilado Interno"
        Me.gbCostoFijo.ResumeLayout(False)
        Me.gbCostoFijo.PerformLayout()
        Me.gbMoneda.ResumeLayout(False)
        Me.gbMoneda.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdGuardar As System.Windows.Forms.Button
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents gbCostoFijo As System.Windows.Forms.GroupBox
    Friend WithEvents chkCostoFijo As System.Windows.Forms.CheckBox
    Friend WithEvents gbMoneda As System.Windows.Forms.GroupBox
    Friend WithEvents rbDolares As System.Windows.Forms.RadioButton
    Friend WithEvents rbPesos As System.Windows.Forms.RadioButton
    Friend WithEvents txtCostoPorKilo As System.Windows.Forms.TextBox
    Friend WithEvents lblCostoPorKilo As System.Windows.Forms.Label
End Class
