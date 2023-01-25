<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImpresorEtiquetas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImpresorEtiquetas))
        Me.lblHilado = New System.Windows.Forms.Label()
        Me.txtHilado = New System.Windows.Forms.TextBox()
        Me.txtColor1 = New System.Windows.Forms.TextBox()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmbHilados = New System.Windows.Forms.ComboBox()
        Me.txtColor2 = New System.Windows.Forms.TextBox()
        Me.txtColor3 = New System.Windows.Forms.TextBox()
        Me.lblPar = New System.Windows.Forms.Label()
        Me.txtPar = New System.Windows.Forms.TextBox()
        Me.lblFechaTurno = New System.Windows.Forms.Label()
        Me.lblNro = New System.Windows.Forms.Label()
        Me.lblNroBarra = New System.Windows.Forms.Label()
        Me.txtNro1 = New System.Windows.Forms.TextBox()
        Me.txtNro2 = New System.Windows.Forms.TextBox()
        Me.cmbImpresora = New System.Windows.Forms.ComboBox()
        Me.lblImpresora = New System.Windows.Forms.Label()
        Me.lblTitDimensionEtiqueta = New System.Windows.Forms.Label()
        Me.lblAnchoEtiqueta = New System.Windows.Forms.Label()
        Me.txtAnchoEtiqueta = New System.Windows.Forms.TextBox()
        Me.txtAltoEtiqueta = New System.Windows.Forms.TextBox()
        Me.lblAltoEtiqueta = New System.Windows.Forms.Label()
        Me.pdoImpReporte = New System.Drawing.Printing.PrintDocument()
        Me.txtCantEtiquetas = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMargenIzq = New System.Windows.Forms.TextBox()
        Me.lblMargenIzq = New System.Windows.Forms.Label()
        Me.txtMargenSup = New System.Windows.Forms.TextBox()
        Me.lblMargenSuperior = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageHilado = New System.Windows.Forms.TabPage()
        Me.TabPageTexto = New System.Windows.Forms.TabPage()
        Me.txtTextoLibre5 = New System.Windows.Forms.TextBox()
        Me.txtTextoLibre4 = New System.Windows.Forms.TextBox()
        Me.txtTextoLibre3 = New System.Windows.Forms.TextBox()
        Me.txtTextoLibre2 = New System.Windows.Forms.TextBox()
        Me.lblTitTextoLibre = New System.Windows.Forms.Label()
        Me.txtTextoLibre1 = New System.Windows.Forms.TextBox()
        Me.txtTextoTamañoFuente = New System.Windows.Forms.TextBox()
        Me.lblTextoTamañoFuente = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPageHilado.SuspendLayout()
        Me.TabPageTexto.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHilado
        '
        Me.lblHilado.Location = New System.Drawing.Point(27, 14)
        Me.lblHilado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHilado.Name = "lblHilado"
        Me.lblHilado.Size = New System.Drawing.Size(89, 25)
        Me.lblHilado.TabIndex = 0
        Me.lblHilado.Text = "HILADO:"
        Me.lblHilado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtHilado
        '
        Me.txtHilado.Location = New System.Drawing.Point(125, 16)
        Me.txtHilado.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtHilado.Name = "txtHilado"
        Me.txtHilado.Size = New System.Drawing.Size(230, 22)
        Me.txtHilado.TabIndex = 0
        '
        'txtColor1
        '
        Me.txtColor1.Location = New System.Drawing.Point(124, 49)
        Me.txtColor1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtColor1.Name = "txtColor1"
        Me.txtColor1.Size = New System.Drawing.Size(230, 22)
        Me.txtColor1.TabIndex = 1
        '
        'lblColor
        '
        Me.lblColor.Location = New System.Drawing.Point(16, 46)
        Me.lblColor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(99, 25)
        Me.lblColor.TabIndex = 2
        Me.lblColor.Text = "COLOR:"
        Me.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAceptar.Location = New System.Drawing.Point(317, 259)
        Me.cmdAceptar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(149, 35)
        Me.cmdAceptar.TabIndex = 3
        Me.cmdAceptar.Text = "ACEPTAR"
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.Location = New System.Drawing.Point(516, 259)
        Me.cmdCancelar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(149, 35)
        Me.cmdCancelar.TabIndex = 4
        Me.cmdCancelar.Text = "SALIR"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmbHilados
        '
        Me.cmbHilados.FormattingEnabled = True
        Me.cmbHilados.Location = New System.Drawing.Point(381, 16)
        Me.cmbHilados.Name = "cmbHilados"
        Me.cmbHilados.Size = New System.Drawing.Size(273, 22)
        Me.cmbHilados.TabIndex = 5
        '
        'txtColor2
        '
        Me.txtColor2.Location = New System.Drawing.Point(124, 77)
        Me.txtColor2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtColor2.Name = "txtColor2"
        Me.txtColor2.Size = New System.Drawing.Size(230, 22)
        Me.txtColor2.TabIndex = 6
        '
        'txtColor3
        '
        Me.txtColor3.Location = New System.Drawing.Point(124, 105)
        Me.txtColor3.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtColor3.Name = "txtColor3"
        Me.txtColor3.Size = New System.Drawing.Size(230, 22)
        Me.txtColor3.TabIndex = 7
        '
        'lblPar
        '
        Me.lblPar.Location = New System.Drawing.Point(15, 135)
        Me.lblPar.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPar.Name = "lblPar"
        Me.lblPar.Size = New System.Drawing.Size(99, 25)
        Me.lblPar.TabIndex = 8
        Me.lblPar.Text = "PAR:"
        Me.lblPar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPar
        '
        Me.txtPar.Location = New System.Drawing.Point(123, 137)
        Me.txtPar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtPar.MaxLength = 7
        Me.txtPar.Name = "txtPar"
        Me.txtPar.Size = New System.Drawing.Size(110, 22)
        Me.txtPar.TabIndex = 9
        '
        'lblFechaTurno
        '
        Me.lblFechaTurno.Location = New System.Drawing.Point(241, 135)
        Me.lblFechaTurno.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFechaTurno.Name = "lblFechaTurno"
        Me.lblFechaTurno.Size = New System.Drawing.Size(201, 25)
        Me.lblFechaTurno.TabIndex = 10
        Me.lblFechaTurno.Text = "dd/mm/yyyy T.T."
        Me.lblFechaTurno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNro
        '
        Me.lblNro.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNro.Location = New System.Drawing.Point(44, 179)
        Me.lblNro.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNro.Name = "lblNro"
        Me.lblNro.Size = New System.Drawing.Size(70, 25)
        Me.lblNro.TabIndex = 11
        Me.lblNro.Text = "NRO:"
        Me.lblNro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNroBarra
        '
        Me.lblNroBarra.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNroBarra.Location = New System.Drawing.Point(218, 179)
        Me.lblNroBarra.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNroBarra.Name = "lblNroBarra"
        Me.lblNroBarra.Size = New System.Drawing.Size(23, 25)
        Me.lblNroBarra.TabIndex = 12
        Me.lblNroBarra.Text = "/"
        Me.lblNroBarra.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNro1
        '
        Me.txtNro1.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNro1.Location = New System.Drawing.Point(124, 179)
        Me.txtNro1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtNro1.MaxLength = 4
        Me.txtNro1.Name = "txtNro1"
        Me.txtNro1.Size = New System.Drawing.Size(94, 26)
        Me.txtNro1.TabIndex = 13
        '
        'txtNro2
        '
        Me.txtNro2.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNro2.Location = New System.Drawing.Point(244, 179)
        Me.txtNro2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtNro2.MaxLength = 3
        Me.txtNro2.Name = "txtNro2"
        Me.txtNro2.Size = New System.Drawing.Size(65, 26)
        Me.txtNro2.TabIndex = 14
        '
        'cmbImpresora
        '
        Me.cmbImpresora.FormattingEnabled = True
        Me.cmbImpresora.Location = New System.Drawing.Point(213, 317)
        Me.cmbImpresora.Name = "cmbImpresora"
        Me.cmbImpresora.Size = New System.Drawing.Size(274, 22)
        Me.cmbImpresora.TabIndex = 96
        '
        'lblImpresora
        '
        Me.lblImpresora.Location = New System.Drawing.Point(1, 317)
        Me.lblImpresora.Name = "lblImpresora"
        Me.lblImpresora.Size = New System.Drawing.Size(195, 25)
        Me.lblImpresora.TabIndex = 95
        Me.lblImpresora.Text = "Impresora para la Impresión:"
        Me.lblImpresora.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitDimensionEtiqueta
        '
        Me.lblTitDimensionEtiqueta.Location = New System.Drawing.Point(1, 342)
        Me.lblTitDimensionEtiqueta.Name = "lblTitDimensionEtiqueta"
        Me.lblTitDimensionEtiqueta.Size = New System.Drawing.Size(195, 25)
        Me.lblTitDimensionEtiqueta.TabIndex = 97
        Me.lblTitDimensionEtiqueta.Text = "Dimensión Etiqueta:"
        Me.lblTitDimensionEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAnchoEtiqueta
        '
        Me.lblAnchoEtiqueta.Location = New System.Drawing.Point(210, 342)
        Me.lblAnchoEtiqueta.Name = "lblAnchoEtiqueta"
        Me.lblAnchoEtiqueta.Size = New System.Drawing.Size(55, 25)
        Me.lblAnchoEtiqueta.TabIndex = 98
        Me.lblAnchoEtiqueta.Text = "Ancho:"
        Me.lblAnchoEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAnchoEtiqueta
        '
        Me.txtAnchoEtiqueta.Location = New System.Drawing.Point(262, 344)
        Me.txtAnchoEtiqueta.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtAnchoEtiqueta.MaxLength = 3
        Me.txtAnchoEtiqueta.Name = "txtAnchoEtiqueta"
        Me.txtAnchoEtiqueta.Size = New System.Drawing.Size(65, 22)
        Me.txtAnchoEtiqueta.TabIndex = 99
        Me.txtAnchoEtiqueta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAltoEtiqueta
        '
        Me.txtAltoEtiqueta.Location = New System.Drawing.Point(431, 344)
        Me.txtAltoEtiqueta.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtAltoEtiqueta.MaxLength = 3
        Me.txtAltoEtiqueta.Name = "txtAltoEtiqueta"
        Me.txtAltoEtiqueta.Size = New System.Drawing.Size(56, 22)
        Me.txtAltoEtiqueta.TabIndex = 101
        Me.txtAltoEtiqueta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblAltoEtiqueta
        '
        Me.lblAltoEtiqueta.Location = New System.Drawing.Point(390, 342)
        Me.lblAltoEtiqueta.Name = "lblAltoEtiqueta"
        Me.lblAltoEtiqueta.Size = New System.Drawing.Size(46, 25)
        Me.lblAltoEtiqueta.TabIndex = 100
        Me.lblAltoEtiqueta.Text = "Alto:"
        Me.lblAltoEtiqueta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pdoImpReporte
        '
        '
        'txtCantEtiquetas
        '
        Me.txtCantEtiquetas.Location = New System.Drawing.Point(213, 266)
        Me.txtCantEtiquetas.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtCantEtiquetas.MaxLength = 4
        Me.txtCantEtiquetas.Name = "txtCantEtiquetas"
        Me.txtCantEtiquetas.Size = New System.Drawing.Size(76, 22)
        Me.txtCantEtiquetas.TabIndex = 103
        Me.txtCantEtiquetas.Text = "2"
        Me.txtCantEtiquetas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(27, 264)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(178, 25)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "CANTIDAD DE ETIQUETAS:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMargenIzq
        '
        Me.txtMargenIzq.Location = New System.Drawing.Point(262, 372)
        Me.txtMargenIzq.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtMargenIzq.MaxLength = 3
        Me.txtMargenIzq.Name = "txtMargenIzq"
        Me.txtMargenIzq.Size = New System.Drawing.Size(65, 22)
        Me.txtMargenIzq.TabIndex = 105
        Me.txtMargenIzq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblMargenIzq
        '
        Me.lblMargenIzq.Location = New System.Drawing.Point(175, 372)
        Me.lblMargenIzq.Name = "lblMargenIzq"
        Me.lblMargenIzq.Size = New System.Drawing.Size(93, 25)
        Me.lblMargenIzq.TabIndex = 104
        Me.lblMargenIzq.Text = "Margen Izq:"
        Me.lblMargenIzq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMargenSup
        '
        Me.txtMargenSup.Location = New System.Drawing.Point(431, 372)
        Me.txtMargenSup.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtMargenSup.MaxLength = 3
        Me.txtMargenSup.Name = "txtMargenSup"
        Me.txtMargenSup.Size = New System.Drawing.Size(56, 22)
        Me.txtMargenSup.TabIndex = 107
        Me.txtMargenSup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblMargenSuperior
        '
        Me.lblMargenSuperior.Location = New System.Drawing.Point(344, 372)
        Me.lblMargenSuperior.Name = "lblMargenSuperior"
        Me.lblMargenSuperior.Size = New System.Drawing.Size(93, 25)
        Me.lblMargenSuperior.TabIndex = 106
        Me.lblMargenSuperior.Text = "Margen Sup:"
        Me.lblMargenSuperior.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPageHilado)
        Me.TabControl1.Controls.Add(Me.TabPageTexto)
        Me.TabControl1.Location = New System.Drawing.Point(12, 7)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(668, 246)
        Me.TabControl1.TabIndex = 108
        '
        'TabPageHilado
        '
        Me.TabPageHilado.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageHilado.Controls.Add(Me.cmbHilados)
        Me.TabPageHilado.Controls.Add(Me.lblHilado)
        Me.TabPageHilado.Controls.Add(Me.txtHilado)
        Me.TabPageHilado.Controls.Add(Me.lblColor)
        Me.TabPageHilado.Controls.Add(Me.txtColor1)
        Me.TabPageHilado.Controls.Add(Me.txtColor2)
        Me.TabPageHilado.Controls.Add(Me.txtColor3)
        Me.TabPageHilado.Controls.Add(Me.lblPar)
        Me.TabPageHilado.Controls.Add(Me.txtPar)
        Me.TabPageHilado.Controls.Add(Me.lblFechaTurno)
        Me.TabPageHilado.Controls.Add(Me.lblNro)
        Me.TabPageHilado.Controls.Add(Me.lblNroBarra)
        Me.TabPageHilado.Controls.Add(Me.txtNro1)
        Me.TabPageHilado.Controls.Add(Me.txtNro2)
        Me.TabPageHilado.Location = New System.Drawing.Point(4, 23)
        Me.TabPageHilado.Name = "TabPageHilado"
        Me.TabPageHilado.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageHilado.Size = New System.Drawing.Size(660, 219)
        Me.TabPageHilado.TabIndex = 0
        Me.TabPageHilado.Text = "ETIQUETA HILADO"
        '
        'TabPageTexto
        '
        Me.TabPageTexto.BackColor = System.Drawing.SystemColors.Control
        Me.TabPageTexto.Controls.Add(Me.txtTextoTamañoFuente)
        Me.TabPageTexto.Controls.Add(Me.lblTextoTamañoFuente)
        Me.TabPageTexto.Controls.Add(Me.txtTextoLibre5)
        Me.TabPageTexto.Controls.Add(Me.txtTextoLibre4)
        Me.TabPageTexto.Controls.Add(Me.txtTextoLibre3)
        Me.TabPageTexto.Controls.Add(Me.txtTextoLibre2)
        Me.TabPageTexto.Controls.Add(Me.lblTitTextoLibre)
        Me.TabPageTexto.Controls.Add(Me.txtTextoLibre1)
        Me.TabPageTexto.Location = New System.Drawing.Point(4, 23)
        Me.TabPageTexto.Name = "TabPageTexto"
        Me.TabPageTexto.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageTexto.Size = New System.Drawing.Size(660, 219)
        Me.TabPageTexto.TabIndex = 1
        Me.TabPageTexto.Text = "TEXTO LIBRE"
        '
        'txtTextoLibre5
        '
        Me.txtTextoLibre5.Location = New System.Drawing.Point(173, 147)
        Me.txtTextoLibre5.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtTextoLibre5.MaxLength = 20
        Me.txtTextoLibre5.Name = "txtTextoLibre5"
        Me.txtTextoLibre5.Size = New System.Drawing.Size(298, 22)
        Me.txtTextoLibre5.TabIndex = 8
        '
        'txtTextoLibre4
        '
        Me.txtTextoLibre4.Location = New System.Drawing.Point(173, 119)
        Me.txtTextoLibre4.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtTextoLibre4.MaxLength = 20
        Me.txtTextoLibre4.Name = "txtTextoLibre4"
        Me.txtTextoLibre4.Size = New System.Drawing.Size(298, 22)
        Me.txtTextoLibre4.TabIndex = 7
        '
        'txtTextoLibre3
        '
        Me.txtTextoLibre3.Location = New System.Drawing.Point(173, 91)
        Me.txtTextoLibre3.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtTextoLibre3.MaxLength = 20
        Me.txtTextoLibre3.Name = "txtTextoLibre3"
        Me.txtTextoLibre3.Size = New System.Drawing.Size(298, 22)
        Me.txtTextoLibre3.TabIndex = 6
        '
        'txtTextoLibre2
        '
        Me.txtTextoLibre2.Location = New System.Drawing.Point(173, 63)
        Me.txtTextoLibre2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtTextoLibre2.MaxLength = 20
        Me.txtTextoLibre2.Name = "txtTextoLibre2"
        Me.txtTextoLibre2.Size = New System.Drawing.Size(298, 22)
        Me.txtTextoLibre2.TabIndex = 5
        '
        'lblTitTextoLibre
        '
        Me.lblTitTextoLibre.Location = New System.Drawing.Point(65, 32)
        Me.lblTitTextoLibre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitTextoLibre.Name = "lblTitTextoLibre"
        Me.lblTitTextoLibre.Size = New System.Drawing.Size(99, 25)
        Me.lblTitTextoLibre.TabIndex = 4
        Me.lblTitTextoLibre.Text = "TEXTO:"
        Me.lblTitTextoLibre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTextoLibre1
        '
        Me.txtTextoLibre1.Location = New System.Drawing.Point(173, 35)
        Me.txtTextoLibre1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtTextoLibre1.MaxLength = 20
        Me.txtTextoLibre1.Name = "txtTextoLibre1"
        Me.txtTextoLibre1.Size = New System.Drawing.Size(298, 22)
        Me.txtTextoLibre1.TabIndex = 3
        '
        'txtTextoTamañoFuente
        '
        Me.txtTextoTamañoFuente.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTextoTamañoFuente.Location = New System.Drawing.Point(608, 32)
        Me.txtTextoTamañoFuente.Name = "txtTextoTamañoFuente"
        Me.txtTextoTamañoFuente.Size = New System.Drawing.Size(31, 22)
        Me.txtTextoTamañoFuente.TabIndex = 28
        '
        'lblTextoTamañoFuente
        '
        Me.lblTextoTamañoFuente.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTextoTamañoFuente.Location = New System.Drawing.Point(525, 32)
        Me.lblTextoTamañoFuente.Name = "lblTextoTamañoFuente"
        Me.lblTextoTamañoFuente.Size = New System.Drawing.Size(82, 22)
        Me.lblTextoTamañoFuente.TabIndex = 27
        Me.lblTextoTamañoFuente.Text = "Tamaño Fuente"
        Me.lblTextoTamañoFuente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmImpresorEtiquetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(689, 413)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.txtMargenSup)
        Me.Controls.Add(Me.lblMargenSuperior)
        Me.Controls.Add(Me.txtMargenIzq)
        Me.Controls.Add(Me.lblMargenIzq)
        Me.Controls.Add(Me.txtCantEtiquetas)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAltoEtiqueta)
        Me.Controls.Add(Me.lblAltoEtiqueta)
        Me.Controls.Add(Me.txtAnchoEtiqueta)
        Me.Controls.Add(Me.lblAnchoEtiqueta)
        Me.Controls.Add(Me.lblTitDimensionEtiqueta)
        Me.Controls.Add(Me.cmbImpresora)
        Me.Controls.Add(Me.lblImpresora)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.Name = "frmImpresorEtiquetas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impresor de Etiquetas"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageHilado.ResumeLayout(False)
        Me.TabPageHilado.PerformLayout()
        Me.TabPageTexto.ResumeLayout(False)
        Me.TabPageTexto.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblHilado As System.Windows.Forms.Label
    Friend WithEvents txtHilado As System.Windows.Forms.TextBox
    Friend WithEvents txtColor1 As System.Windows.Forms.TextBox
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmbHilados As System.Windows.Forms.ComboBox
    Friend WithEvents txtColor2 As System.Windows.Forms.TextBox
    Friend WithEvents txtColor3 As System.Windows.Forms.TextBox
    Friend WithEvents lblPar As System.Windows.Forms.Label
    Friend WithEvents txtPar As System.Windows.Forms.TextBox
    Friend WithEvents lblFechaTurno As System.Windows.Forms.Label
    Friend WithEvents lblNro As System.Windows.Forms.Label
    Friend WithEvents lblNroBarra As System.Windows.Forms.Label
    Friend WithEvents txtNro1 As System.Windows.Forms.TextBox
    Friend WithEvents txtNro2 As System.Windows.Forms.TextBox
    Friend WithEvents cmbImpresora As System.Windows.Forms.ComboBox
    Friend WithEvents lblImpresora As System.Windows.Forms.Label
    Friend WithEvents lblTitDimensionEtiqueta As System.Windows.Forms.Label
    Friend WithEvents lblAnchoEtiqueta As System.Windows.Forms.Label
    Friend WithEvents txtAnchoEtiqueta As System.Windows.Forms.TextBox
    Friend WithEvents txtAltoEtiqueta As System.Windows.Forms.TextBox
    Friend WithEvents lblAltoEtiqueta As System.Windows.Forms.Label
    Friend WithEvents pdoImpReporte As System.Drawing.Printing.PrintDocument
    Friend WithEvents txtCantEtiquetas As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMargenIzq As System.Windows.Forms.TextBox
    Friend WithEvents lblMargenIzq As System.Windows.Forms.Label
    Friend WithEvents txtMargenSup As System.Windows.Forms.TextBox
    Friend WithEvents lblMargenSuperior As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPageHilado As System.Windows.Forms.TabPage
    Friend WithEvents TabPageTexto As System.Windows.Forms.TabPage
    Friend WithEvents txtTextoLibre5 As System.Windows.Forms.TextBox
    Friend WithEvents txtTextoLibre4 As System.Windows.Forms.TextBox
    Friend WithEvents txtTextoLibre3 As System.Windows.Forms.TextBox
    Friend WithEvents txtTextoLibre2 As System.Windows.Forms.TextBox
    Friend WithEvents lblTitTextoLibre As System.Windows.Forms.Label
    Friend WithEvents txtTextoLibre1 As System.Windows.Forms.TextBox
    Friend WithEvents txtTextoTamañoFuente As System.Windows.Forms.TextBox
    Friend WithEvents lblTextoTamañoFuente As System.Windows.Forms.Label
End Class
