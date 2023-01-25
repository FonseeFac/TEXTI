<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmABMOPs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmABMOPs))
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.txtXXL = New System.Windows.Forms.TextBox()
        Me.lblRXXL = New System.Windows.Forms.Label()
        Me.txtXL = New System.Windows.Forms.TextBox()
        Me.lblRXL = New System.Windows.Forms.Label()
        Me.txtL = New System.Windows.Forms.TextBox()
        Me.lblRL = New System.Windows.Forms.Label()
        Me.txtM = New System.Windows.Forms.TextBox()
        Me.lblRM = New System.Windows.Forms.Label()
        Me.txtS = New System.Windows.Forms.TextBox()
        Me.lblRS = New System.Windows.Forms.Label()
        Me.txtXS = New System.Windows.Forms.TextBox()
        Me.lblRXS = New System.Windows.Forms.Label()
        Me.txtXXS = New System.Windows.Forms.TextBox()
        Me.lblRXXS = New System.Windows.Forms.Label()
        Me.txtCodArticulo = New System.Windows.Forms.TextBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblCodArticulo = New System.Windows.Forms.Label()
        Me.txtOP = New System.Windows.Forms.TextBox()
        Me.lblOP = New System.Windows.Forms.Label()
        Me.cmdObtenerNroOP = New System.Windows.Forms.Button()
        Me.cmdBorrarOPsAntiguas = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Location = New System.Drawing.Point(148, 200)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(90, 29)
        Me.cmdAceptar.TabIndex = 3
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Location = New System.Drawing.Point(302, 200)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(90, 29)
        Me.cmdCancelar.TabIndex = 4
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'txtTotal
        '
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(134, 147)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(68, 26)
        Me.txtTotal.TabIndex = 86
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(15, 149)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(113, 23)
        Me.lblTotal.TabIndex = 85
        Me.lblTotal.Text = "Total:"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCantidad
        '
        Me.lblCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidad.Location = New System.Drawing.Point(38, 92)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(90, 23)
        Me.lblCantidad.TabIndex = 84
        Me.lblCantidad.Text = "Cantidad:"
        Me.lblCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtXXL
        '
        Me.txtXXL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtXXL.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtXXL.Location = New System.Drawing.Point(464, 115)
        Me.txtXXL.Name = "txtXXL"
        Me.txtXXL.Size = New System.Drawing.Size(49, 26)
        Me.txtXXL.TabIndex = 76
        '
        'lblRXXL
        '
        Me.lblRXXL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRXXL.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRXXL.Location = New System.Drawing.Point(464, 92)
        Me.lblRXXL.Name = "lblRXXL"
        Me.lblRXXL.Size = New System.Drawing.Size(49, 23)
        Me.lblRXXL.TabIndex = 83
        Me.lblRXXL.Text = "XXL"
        Me.lblRXXL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtXL
        '
        Me.txtXL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtXL.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtXL.Location = New System.Drawing.Point(409, 115)
        Me.txtXL.Name = "txtXL"
        Me.txtXL.Size = New System.Drawing.Size(49, 26)
        Me.txtXL.TabIndex = 75
        '
        'lblRXL
        '
        Me.lblRXL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRXL.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRXL.Location = New System.Drawing.Point(409, 92)
        Me.lblRXL.Name = "lblRXL"
        Me.lblRXL.Size = New System.Drawing.Size(49, 23)
        Me.lblRXL.TabIndex = 82
        Me.lblRXL.Text = "XL"
        Me.lblRXL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtL
        '
        Me.txtL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtL.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtL.Location = New System.Drawing.Point(354, 115)
        Me.txtL.Name = "txtL"
        Me.txtL.Size = New System.Drawing.Size(49, 26)
        Me.txtL.TabIndex = 74
        '
        'lblRL
        '
        Me.lblRL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRL.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRL.Location = New System.Drawing.Point(354, 92)
        Me.lblRL.Name = "lblRL"
        Me.lblRL.Size = New System.Drawing.Size(49, 23)
        Me.lblRL.TabIndex = 81
        Me.lblRL.Text = "L"
        Me.lblRL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtM
        '
        Me.txtM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtM.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtM.Location = New System.Drawing.Point(299, 115)
        Me.txtM.Name = "txtM"
        Me.txtM.Size = New System.Drawing.Size(49, 26)
        Me.txtM.TabIndex = 73
        '
        'lblRM
        '
        Me.lblRM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRM.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRM.Location = New System.Drawing.Point(299, 92)
        Me.lblRM.Name = "lblRM"
        Me.lblRM.Size = New System.Drawing.Size(49, 23)
        Me.lblRM.TabIndex = 80
        Me.lblRM.Text = "M"
        Me.lblRM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtS
        '
        Me.txtS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtS.Location = New System.Drawing.Point(244, 115)
        Me.txtS.Name = "txtS"
        Me.txtS.Size = New System.Drawing.Size(49, 26)
        Me.txtS.TabIndex = 72
        '
        'lblRS
        '
        Me.lblRS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRS.Location = New System.Drawing.Point(244, 92)
        Me.lblRS.Name = "lblRS"
        Me.lblRS.Size = New System.Drawing.Size(49, 23)
        Me.lblRS.TabIndex = 79
        Me.lblRS.Text = "S"
        Me.lblRS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtXS
        '
        Me.txtXS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtXS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtXS.Location = New System.Drawing.Point(189, 115)
        Me.txtXS.Name = "txtXS"
        Me.txtXS.Size = New System.Drawing.Size(49, 26)
        Me.txtXS.TabIndex = 71
        '
        'lblRXS
        '
        Me.lblRXS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRXS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRXS.Location = New System.Drawing.Point(189, 92)
        Me.lblRXS.Name = "lblRXS"
        Me.lblRXS.Size = New System.Drawing.Size(49, 23)
        Me.lblRXS.TabIndex = 78
        Me.lblRXS.Text = "XS"
        Me.lblRXS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtXXS
        '
        Me.txtXXS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtXXS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtXXS.Location = New System.Drawing.Point(134, 115)
        Me.txtXXS.Name = "txtXXS"
        Me.txtXXS.Size = New System.Drawing.Size(49, 26)
        Me.txtXXS.TabIndex = 70
        '
        'lblRXXS
        '
        Me.lblRXXS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRXXS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRXXS.Location = New System.Drawing.Point(134, 92)
        Me.lblRXXS.Name = "lblRXXS"
        Me.lblRXXS.Size = New System.Drawing.Size(49, 23)
        Me.lblRXXS.TabIndex = 77
        Me.lblRXXS.Text = "XXS"
        Me.lblRXXS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCodArticulo
        '
        Me.txtCodArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodArticulo.Location = New System.Drawing.Point(134, 60)
        Me.txtCodArticulo.Name = "txtCodArticulo"
        Me.txtCodArticulo.Size = New System.Drawing.Size(68, 26)
        Me.txtCodArticulo.TabIndex = 69
        '
        'lblFecha
        '
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(298, 62)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(84, 23)
        Me.lblFecha.TabIndex = 68
        Me.lblFecha.Text = "Fecha:"
        Me.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(387, 61)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(126, 22)
        Me.dtpFecha.TabIndex = 67
        '
        'lblCodArticulo
        '
        Me.lblCodArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodArticulo.Location = New System.Drawing.Point(15, 62)
        Me.lblCodArticulo.Name = "lblCodArticulo"
        Me.lblCodArticulo.Size = New System.Drawing.Size(113, 23)
        Me.lblCodArticulo.TabIndex = 66
        Me.lblCodArticulo.Text = "Cód. Artículo:"
        Me.lblCodArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOP
        '
        Me.txtOP.Enabled = False
        Me.txtOP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOP.Location = New System.Drawing.Point(134, 19)
        Me.txtOP.Name = "txtOP"
        Me.txtOP.Size = New System.Drawing.Size(68, 26)
        Me.txtOP.TabIndex = 65
        '
        'lblOP
        '
        Me.lblOP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOP.Location = New System.Drawing.Point(60, 21)
        Me.lblOP.Name = "lblOP"
        Me.lblOP.Size = New System.Drawing.Size(68, 23)
        Me.lblOP.TabIndex = 64
        Me.lblOP.Text = "OP:"
        Me.lblOP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdObtenerNroOP
        '
        Me.cmdObtenerNroOP.Location = New System.Drawing.Point(208, 19)
        Me.cmdObtenerNroOP.Name = "cmdObtenerNroOP"
        Me.cmdObtenerNroOP.Size = New System.Drawing.Size(60, 26)
        Me.cmdObtenerNroOP.TabIndex = 87
        Me.cmdObtenerNroOP.Text = "Obtener"
        Me.cmdObtenerNroOP.UseVisualStyleBackColor = True
        '
        'cmdBorrarOPsAntiguas
        '
        Me.cmdBorrarOPsAntiguas.Location = New System.Drawing.Point(369, 20)
        Me.cmdBorrarOPsAntiguas.Name = "cmdBorrarOPsAntiguas"
        Me.cmdBorrarOPsAntiguas.Size = New System.Drawing.Size(144, 26)
        Me.cmdBorrarOPsAntiguas.TabIndex = 88
        Me.cmdBorrarOPsAntiguas.Text = "Borrar OPs Antiguas"
        Me.cmdBorrarOPsAntiguas.UseVisualStyleBackColor = True
        '
        'frmABMOPs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(547, 244)
        Me.Controls.Add(Me.cmdBorrarOPsAntiguas)
        Me.Controls.Add(Me.cmdObtenerNroOP)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblCantidad)
        Me.Controls.Add(Me.txtXXL)
        Me.Controls.Add(Me.lblRXXL)
        Me.Controls.Add(Me.txtXL)
        Me.Controls.Add(Me.lblRXL)
        Me.Controls.Add(Me.txtL)
        Me.Controls.Add(Me.lblRL)
        Me.Controls.Add(Me.txtM)
        Me.Controls.Add(Me.lblRM)
        Me.Controls.Add(Me.txtS)
        Me.Controls.Add(Me.lblRS)
        Me.Controls.Add(Me.txtXS)
        Me.Controls.Add(Me.lblRXS)
        Me.Controls.Add(Me.txtXXS)
        Me.Controls.Add(Me.lblRXXS)
        Me.Controls.Add(Me.txtCodArticulo)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.lblCodArticulo)
        Me.Controls.Add(Me.txtOP)
        Me.Controls.Add(Me.lblOP)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmABMOPs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM Ordenes de Producción"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Friend WithEvents txtXXL As System.Windows.Forms.TextBox
    Friend WithEvents lblRXXL As System.Windows.Forms.Label
    Friend WithEvents txtXL As System.Windows.Forms.TextBox
    Friend WithEvents lblRXL As System.Windows.Forms.Label
    Friend WithEvents txtL As System.Windows.Forms.TextBox
    Friend WithEvents lblRL As System.Windows.Forms.Label
    Friend WithEvents txtM As System.Windows.Forms.TextBox
    Friend WithEvents lblRM As System.Windows.Forms.Label
    Friend WithEvents txtS As System.Windows.Forms.TextBox
    Friend WithEvents lblRS As System.Windows.Forms.Label
    Friend WithEvents txtXS As System.Windows.Forms.TextBox
    Friend WithEvents lblRXS As System.Windows.Forms.Label
    Friend WithEvents txtXXS As System.Windows.Forms.TextBox
    Friend WithEvents lblRXXS As System.Windows.Forms.Label
    Friend WithEvents txtCodArticulo As System.Windows.Forms.TextBox
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCodArticulo As System.Windows.Forms.Label
    Friend WithEvents txtOP As System.Windows.Forms.TextBox
    Friend WithEvents lblOP As System.Windows.Forms.Label
    Friend WithEvents cmdObtenerNroOP As System.Windows.Forms.Button
    Friend WithEvents cmdBorrarOPsAntiguas As System.Windows.Forms.Button
End Class
