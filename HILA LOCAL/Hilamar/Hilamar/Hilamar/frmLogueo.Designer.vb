<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogueo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogueo))
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.lblLegajo = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblNombreEmpleado = New System.Windows.Forms.Label()
        Me.txtLegajo = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.Location = New System.Drawing.Point(49, 91)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(100, 32)
        Me.cmdOk.TabIndex = 0
        Me.cmdOk.Text = "Aceptar"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.Location = New System.Drawing.Point(176, 91)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(100, 32)
        Me.cmdCancelar.TabIndex = 1
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'lblLegajo
        '
        Me.lblLegajo.AutoSize = True
        Me.lblLegajo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLegajo.Location = New System.Drawing.Point(26, 19)
        Me.lblLegajo.Name = "lblLegajo"
        Me.lblLegajo.Size = New System.Drawing.Size(50, 16)
        Me.lblLegajo.TabIndex = 2
        Me.lblLegajo.Text = "Legajo:"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.Location = New System.Drawing.Point(26, 62)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(43, 16)
        Me.lblPassword.TabIndex = 3
        Me.lblPassword.Text = "Clave:"
        '
        'lblNombreEmpleado
        '
        Me.lblNombreEmpleado.AutoSize = True
        Me.lblNombreEmpleado.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreEmpleado.Location = New System.Drawing.Point(85, 40)
        Me.lblNombreEmpleado.Name = "lblNombreEmpleado"
        Me.lblNombreEmpleado.Size = New System.Drawing.Size(113, 16)
        Me.lblNombreEmpleado.TabIndex = 4
        Me.lblNombreEmpleado.Text = "Nombre empleado"
        '
        'txtLegajo
        '
        Me.txtLegajo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLegajo.Location = New System.Drawing.Point(81, 15)
        Me.txtLegajo.Name = "txtLegajo"
        Me.txtLegajo.Size = New System.Drawing.Size(125, 22)
        Me.txtLegajo.TabIndex = 5
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(80, 60)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(221, 22)
        Me.txtPassword.TabIndex = 6
        '
        'frmLogueo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(333, 135)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtLegajo)
        Me.Controls.Add(Me.lblNombreEmpleado)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblLegajo)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmLogueo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Hilamar - Inicio de Sesión"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents lblLegajo As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblNombreEmpleado As System.Windows.Forms.Label
    Friend WithEvents txtLegajo As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
End Class
