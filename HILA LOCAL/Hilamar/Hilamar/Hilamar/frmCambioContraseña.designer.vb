<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCambioContraseña
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCambioContraseña))
        Me.txtNuevaPassword = New System.Windows.Forms.TextBox()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.lblTitEmpleado = New System.Windows.Forms.Label()
        Me.txtViejaPassword = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtConfNuevaPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtNuevaPassword
        '
        Me.txtNuevaPassword.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNuevaPassword.Location = New System.Drawing.Point(153, 78)
        Me.txtNuevaPassword.Name = "txtNuevaPassword"
        Me.txtNuevaPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNuevaPassword.Size = New System.Drawing.Size(221, 22)
        Me.txtNuevaPassword.TabIndex = 13
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.Location = New System.Drawing.Point(150, 9)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(101, 16)
        Me.lblUsuario.TabIndex = 11
        Me.lblUsuario.Text = "Nombre Usuario"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.Location = New System.Drawing.Point(30, 81)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(117, 16)
        Me.lblPassword.TabIndex = 10
        Me.lblPassword.Text = "Nueva Contraseña:"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.Location = New System.Drawing.Point(222, 158)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(100, 26)
        Me.cmdCancelar.TabIndex = 8
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOk.Location = New System.Drawing.Point(91, 158)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(100, 26)
        Me.cmdOk.TabIndex = 7
        Me.cmdOk.Text = "Aceptar"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'lblTitEmpleado
        '
        Me.lblTitEmpleado.AutoSize = True
        Me.lblTitEmpleado.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitEmpleado.Location = New System.Drawing.Point(88, 9)
        Me.lblTitEmpleado.Name = "lblTitEmpleado"
        Me.lblTitEmpleado.Size = New System.Drawing.Size(56, 16)
        Me.lblTitEmpleado.TabIndex = 14
        Me.lblTitEmpleado.Text = "Usuario:"
        '
        'txtViejaPassword
        '
        Me.txtViejaPassword.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtViejaPassword.Location = New System.Drawing.Point(153, 42)
        Me.txtViejaPassword.Name = "txtViejaPassword"
        Me.txtViejaPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtViejaPassword.Size = New System.Drawing.Size(221, 22)
        Me.txtViejaPassword.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 16)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Contraseña Anterior:"
        '
        'txtConfNuevaPassword
        '
        Me.txtConfNuevaPassword.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfNuevaPassword.Location = New System.Drawing.Point(153, 115)
        Me.txtConfNuevaPassword.Name = "txtConfNuevaPassword"
        Me.txtConfNuevaPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfNuevaPassword.Size = New System.Drawing.Size(221, 22)
        Me.txtConfNuevaPassword.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 16)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Confirmar Contraseña:"
        '
        'frmCambioContraseña
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 205)
        Me.Controls.Add(Me.txtConfNuevaPassword)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtViejaPassword)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTitEmpleado)
        Me.Controls.Add(Me.txtNuevaPassword)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCambioContraseña"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Hilamar - Cambiar Contraseña"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNuevaPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents lblTitEmpleado As System.Windows.Forms.Label
    Friend WithEvents txtViejaPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtConfNuevaPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
