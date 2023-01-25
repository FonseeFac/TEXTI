<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmABMTextiSobranteHilado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmABMTextiSobranteHilado))
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.txtKilos = New System.Windows.Forms.TextBox()
        Me.lblKilos = New System.Windows.Forms.Label()
        Me.txtPartida = New System.Windows.Forms.TextBox()
        Me.lblPartida = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.lblObservacion = New System.Windows.Forms.Label()
        Me.lblDatosPartida = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.Location = New System.Drawing.Point(268, 145)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(81, 27)
        Me.cmdCancelar.TabIndex = 9
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGuardar.Location = New System.Drawing.Point(162, 145)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(81, 27)
        Me.cmdGuardar.TabIndex = 8
        Me.cmdGuardar.Text = "Guardar"
        Me.cmdGuardar.UseVisualStyleBackColor = True
        '
        'txtKilos
        '
        Me.txtKilos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKilos.Location = New System.Drawing.Point(106, 62)
        Me.txtKilos.Name = "txtKilos"
        Me.txtKilos.Size = New System.Drawing.Size(111, 23)
        Me.txtKilos.TabIndex = 7
        '
        'lblKilos
        '
        Me.lblKilos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKilos.Location = New System.Drawing.Point(3, 62)
        Me.lblKilos.Name = "lblKilos"
        Me.lblKilos.Size = New System.Drawing.Size(99, 23)
        Me.lblKilos.TabIndex = 6
        Me.lblKilos.Text = "Kilos:"
        Me.lblKilos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPartida
        '
        Me.txtPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartida.Location = New System.Drawing.Point(106, 24)
        Me.txtPartida.Name = "txtPartida"
        Me.txtPartida.Size = New System.Drawing.Size(125, 23)
        Me.txtPartida.TabIndex = 11
        '
        'lblPartida
        '
        Me.lblPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartida.Location = New System.Drawing.Point(3, 24)
        Me.lblPartida.Name = "lblPartida"
        Me.lblPartida.Size = New System.Drawing.Size(99, 23)
        Me.lblPartida.TabIndex = 10
        Me.lblPartida.Text = "Partida:"
        Me.lblPartida.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtObservacion
        '
        Me.txtObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacion.Location = New System.Drawing.Point(106, 100)
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(409, 23)
        Me.txtObservacion.TabIndex = 13
        '
        'lblObservacion
        '
        Me.lblObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObservacion.Location = New System.Drawing.Point(3, 100)
        Me.lblObservacion.Name = "lblObservacion"
        Me.lblObservacion.Size = New System.Drawing.Size(99, 23)
        Me.lblObservacion.TabIndex = 12
        Me.lblObservacion.Text = "Observación:"
        Me.lblObservacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDatosPartida
        '
        Me.lblDatosPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatosPartida.Location = New System.Drawing.Point(237, 24)
        Me.lblDatosPartida.Name = "lblDatosPartida"
        Me.lblDatosPartida.Size = New System.Drawing.Size(278, 23)
        Me.lblDatosPartida.TabIndex = 14
        Me.lblDatosPartida.Text = "Datos de la partida"
        Me.lblDatosPartida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmABMTextiSobranteHilado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 193)
        Me.Controls.Add(Me.lblDatosPartida)
        Me.Controls.Add(Me.txtObservacion)
        Me.Controls.Add(Me.lblObservacion)
        Me.Controls.Add(Me.txtPartida)
        Me.Controls.Add(Me.lblPartida)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdGuardar)
        Me.Controls.Add(Me.txtKilos)
        Me.Controls.Add(Me.lblKilos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmABMTextiSobranteHilado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM Sobrantes de Hilado en Planta"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdGuardar As System.Windows.Forms.Button
    Friend WithEvents txtKilos As System.Windows.Forms.TextBox
    Friend WithEvents lblKilos As System.Windows.Forms.Label
    Friend WithEvents txtPartida As System.Windows.Forms.TextBox
    Friend WithEvents lblPartida As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents lblObservacion As System.Windows.Forms.Label
    Friend WithEvents lblDatosPartida As System.Windows.Forms.Label
End Class
