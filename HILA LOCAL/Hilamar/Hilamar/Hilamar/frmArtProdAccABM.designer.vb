<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmArtProdAccABM
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArtProdAccABM))
        Me.lblArticulo = New System.Windows.Forms.Label()
        Me.lblOp = New System.Windows.Forms.Label()
        Me.txtOp = New System.Windows.Forms.TextBox()
        Me.lblPartida = New System.Windows.Forms.Label()
        Me.txtArticulo = New System.Windows.Forms.TextBox()
        Me.lblMedFinal = New System.Windows.Forms.Label()
        Me.txtMedFinal = New System.Windows.Forms.TextBox()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.txtPartida = New System.Windows.Forms.TextBox()
        Me.lblPatron = New System.Windows.Forms.Label()
        Me.txtPatron = New System.Windows.Forms.TextBox()
        Me.txtColor = New System.Windows.Forms.TextBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.txtCuadro1 = New System.Windows.Forms.TextBox()
        Me.lblDetalle = New System.Windows.Forms.Label()
        Me.lblGraduaciones = New System.Windows.Forms.Label()
        Me.dgvGraduaciones = New System.Windows.Forms.DataGridView()
        Me.txtCuadro2 = New System.Windows.Forms.TextBox()
        Me.txtCuadro3 = New System.Windows.Forms.TextBox()
        Me.txtCuadro4 = New System.Windows.Forms.TextBox()
        Me.txtCuadro5 = New System.Windows.Forms.TextBox()
        Me.txtCuadro8 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dgvPicos = New System.Windows.Forms.DataGridView()
        Me.Panel_Botonera = New System.Windows.Forms.Panel()
        Me.cmdImprimir = New System.Windows.Forms.Button()
        Me.cmdCopiar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.txtTitulo = New System.Windows.Forms.TextBox()
        Me.txtCuadro6 = New System.Windows.Forms.TextBox()
        Me.txtCuadro7 = New System.Windows.Forms.TextBox()
        Me.pdoImpAccesorio = New System.Drawing.Printing.PrintDocument()
        Me.cmdCopiarEnOtra = New System.Windows.Forms.Button()
        CType(Me.dgvGraduaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPicos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_Botonera.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblArticulo
        '
        Me.lblArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArticulo.Location = New System.Drawing.Point(822, 83)
        Me.lblArticulo.Name = "lblArticulo"
        Me.lblArticulo.Size = New System.Drawing.Size(98, 20)
        Me.lblArticulo.TabIndex = 50
        Me.lblArticulo.Text = "ARTICULO"
        Me.lblArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOp
        '
        Me.lblOp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOp.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOp.Location = New System.Drawing.Point(718, 83)
        Me.lblOp.Name = "lblOp"
        Me.lblOp.Size = New System.Drawing.Size(104, 20)
        Me.lblOp.TabIndex = 49
        Me.lblOp.Text = "OP"
        Me.lblOp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtOp
        '
        Me.txtOp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOp.Location = New System.Drawing.Point(718, 103)
        Me.txtOp.Name = "txtOp"
        Me.txtOp.Size = New System.Drawing.Size(104, 20)
        Me.txtOp.TabIndex = 48
        Me.txtOp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblPartida
        '
        Me.lblPartida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartida.Location = New System.Drawing.Point(468, 83)
        Me.lblPartida.Name = "lblPartida"
        Me.lblPartida.Size = New System.Drawing.Size(111, 20)
        Me.lblPartida.TabIndex = 47
        Me.lblPartida.Text = "PARTIDA"
        Me.lblPartida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtArticulo
        '
        Me.txtArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArticulo.Location = New System.Drawing.Point(822, 103)
        Me.txtArticulo.Name = "txtArticulo"
        Me.txtArticulo.Size = New System.Drawing.Size(98, 20)
        Me.txtArticulo.TabIndex = 46
        Me.txtArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblMedFinal
        '
        Me.lblMedFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMedFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMedFinal.Location = New System.Drawing.Point(579, 83)
        Me.lblMedFinal.Name = "lblMedFinal"
        Me.lblMedFinal.Size = New System.Drawing.Size(139, 20)
        Me.lblMedFinal.TabIndex = 45
        Me.lblMedFinal.Text = "MED.FINAL"
        Me.lblMedFinal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtMedFinal
        '
        Me.txtMedFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMedFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMedFinal.Location = New System.Drawing.Point(579, 103)
        Me.txtMedFinal.Name = "txtMedFinal"
        Me.txtMedFinal.Size = New System.Drawing.Size(139, 20)
        Me.txtMedFinal.TabIndex = 44
        Me.txtMedFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblColor
        '
        Me.lblColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColor.Location = New System.Drawing.Point(198, 83)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(270, 20)
        Me.lblColor.TabIndex = 43
        Me.lblColor.Text = "COLOR"
        Me.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPartida
        '
        Me.txtPartida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPartida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartida.Location = New System.Drawing.Point(468, 103)
        Me.txtPartida.Name = "txtPartida"
        Me.txtPartida.Size = New System.Drawing.Size(111, 20)
        Me.txtPartida.TabIndex = 42
        Me.txtPartida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblPatron
        '
        Me.lblPatron.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPatron.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPatron.Location = New System.Drawing.Point(99, 83)
        Me.lblPatron.Name = "lblPatron"
        Me.lblPatron.Size = New System.Drawing.Size(99, 20)
        Me.lblPatron.TabIndex = 41
        Me.lblPatron.Text = "PATRON"
        Me.lblPatron.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPatron
        '
        Me.txtPatron.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPatron.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPatron.Location = New System.Drawing.Point(99, 103)
        Me.txtPatron.Name = "txtPatron"
        Me.txtPatron.Size = New System.Drawing.Size(99, 20)
        Me.txtPatron.TabIndex = 40
        Me.txtPatron.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtColor
        '
        Me.txtColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtColor.Location = New System.Drawing.Point(198, 103)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Size = New System.Drawing.Size(270, 20)
        Me.txtColor.TabIndex = 39
        Me.txtColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblFecha
        '
        Me.lblFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(0, 83)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(99, 20)
        Me.lblFecha.TabIndex = 38
        Me.lblFecha.Text = "FECHA"
        Me.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(0, 103)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(99, 20)
        Me.dtpFecha.TabIndex = 51
        '
        'lblTitulo
        '
        Me.lblTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(0, 52)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(469, 31)
        Me.lblTitulo.TabIndex = 52
        Me.lblTitulo.Text = "TEXTILANA"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCuadro1
        '
        Me.txtCuadro1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuadro1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuadro1.Location = New System.Drawing.Point(0, 134)
        Me.txtCuadro1.Multiline = True
        Me.txtCuadro1.Name = "txtCuadro1"
        Me.txtCuadro1.Size = New System.Drawing.Size(324, 191)
        Me.txtCuadro1.TabIndex = 53
        Me.txtCuadro1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblDetalle
        '
        Me.lblDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDetalle.Location = New System.Drawing.Point(627, 123)
        Me.lblDetalle.Name = "lblDetalle"
        Me.lblDetalle.Size = New System.Drawing.Size(293, 20)
        Me.lblDetalle.TabIndex = 55
        Me.lblDetalle.Text = "DETALLE"
        Me.lblDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblGraduaciones
        '
        Me.lblGraduaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGraduaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGraduaciones.Location = New System.Drawing.Point(327, 123)
        Me.lblGraduaciones.Name = "lblGraduaciones"
        Me.lblGraduaciones.Size = New System.Drawing.Size(300, 20)
        Me.lblGraduaciones.TabIndex = 54
        Me.lblGraduaciones.Text = "GRADUACIONES"
        Me.lblGraduaciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvGraduaciones
        '
        Me.dgvGraduaciones.AllowUserToAddRows = False
        Me.dgvGraduaciones.AllowUserToDeleteRows = False
        Me.dgvGraduaciones.AllowUserToResizeColumns = False
        Me.dgvGraduaciones.AllowUserToResizeRows = False
        Me.dgvGraduaciones.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGraduaciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvGraduaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvGraduaciones.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvGraduaciones.Location = New System.Drawing.Point(327, 143)
        Me.dgvGraduaciones.MultiSelect = False
        Me.dgvGraduaciones.Name = "dgvGraduaciones"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGraduaciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvGraduaciones.RowHeadersWidth = 20
        Me.dgvGraduaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvGraduaciones.Size = New System.Drawing.Size(593, 383)
        Me.dgvGraduaciones.TabIndex = 461
        '
        'txtCuadro2
        '
        Me.txtCuadro2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuadro2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuadro2.Location = New System.Drawing.Point(1, 331)
        Me.txtCuadro2.Name = "txtCuadro2"
        Me.txtCuadro2.Size = New System.Drawing.Size(99, 20)
        Me.txtCuadro2.TabIndex = 462
        Me.txtCuadro2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCuadro3
        '
        Me.txtCuadro3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuadro3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuadro3.Location = New System.Drawing.Point(100, 331)
        Me.txtCuadro3.Name = "txtCuadro3"
        Me.txtCuadro3.Size = New System.Drawing.Size(125, 20)
        Me.txtCuadro3.TabIndex = 463
        Me.txtCuadro3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCuadro4
        '
        Me.txtCuadro4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuadro4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuadro4.Location = New System.Drawing.Point(225, 331)
        Me.txtCuadro4.Name = "txtCuadro4"
        Me.txtCuadro4.Size = New System.Drawing.Size(99, 20)
        Me.txtCuadro4.TabIndex = 464
        Me.txtCuadro4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCuadro5
        '
        Me.txtCuadro5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuadro5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuadro5.Location = New System.Drawing.Point(1, 351)
        Me.txtCuadro5.Name = "txtCuadro5"
        Me.txtCuadro5.Size = New System.Drawing.Size(323, 20)
        Me.txtCuadro5.TabIndex = 465
        Me.txtCuadro5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCuadro8
        '
        Me.txtCuadro8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuadro8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuadro8.Location = New System.Drawing.Point(1, 411)
        Me.txtCuadro8.Name = "txtCuadro8"
        Me.txtCuadro8.Size = New System.Drawing.Size(323, 20)
        Me.txtCuadro8.TabIndex = 467
        Me.txtCuadro8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(-2, 526)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 20)
        Me.Label1.TabIndex = 469
        Me.Label1.Text = "PICOS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(110, 526)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 470
        Me.Label2.Text = "1"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(210, 526)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 471
        Me.Label3.Text = "2"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(310, 526)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 472
        Me.Label4.Text = "3"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(410, 526)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 473
        Me.Label5.Text = "4"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(510, 526)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 474
        Me.Label6.Text = "5"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(810, 526)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 20)
        Me.Label7.TabIndex = 475
        Me.Label7.Text = "8"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(710, 526)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 20)
        Me.Label8.TabIndex = 476
        Me.Label8.Text = "7"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(610, 526)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 20)
        Me.Label9.TabIndex = 477
        Me.Label9.Text = "6"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(-2, 546)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 40)
        Me.Label10.TabIndex = 478
        Me.Label10.Text = "DERECHA"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(-2, 586)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 40)
        Me.Label11.TabIndex = 479
        Me.Label11.Text = "IZQUIERDA"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvPicos
        '
        Me.dgvPicos.AllowUserToAddRows = False
        Me.dgvPicos.AllowUserToDeleteRows = False
        Me.dgvPicos.AllowUserToResizeColumns = False
        Me.dgvPicos.AllowUserToResizeRows = False
        Me.dgvPicos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPicos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvPicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPicos.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvPicos.Location = New System.Drawing.Point(110, 546)
        Me.dgvPicos.MultiSelect = False
        Me.dgvPicos.Name = "dgvPicos"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPicos.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvPicos.RowHeadersWidth = 20
        Me.dgvPicos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvPicos.Size = New System.Drawing.Size(810, 80)
        Me.dgvPicos.TabIndex = 480
        '
        'Panel_Botonera
        '
        Me.Panel_Botonera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_Botonera.Controls.Add(Me.cmdCopiarEnOtra)
        Me.Panel_Botonera.Controls.Add(Me.cmdImprimir)
        Me.Panel_Botonera.Controls.Add(Me.cmdCopiar)
        Me.Panel_Botonera.Controls.Add(Me.cmdCancelar)
        Me.Panel_Botonera.Controls.Add(Me.cmdGuardar)
        Me.Panel_Botonera.Location = New System.Drawing.Point(0, 0)
        Me.Panel_Botonera.Name = "Panel_Botonera"
        Me.Panel_Botonera.Size = New System.Drawing.Size(641, 31)
        Me.Panel_Botonera.TabIndex = 481
        '
        'cmdImprimir
        '
        Me.cmdImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdImprimir.Image = CType(resources.GetObject("cmdImprimir.Image"), System.Drawing.Image)
        Me.cmdImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdImprimir.Location = New System.Drawing.Point(192, 2)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(91, 25)
        Me.cmdImprimir.TabIndex = 282
        Me.cmdImprimir.Text = "Imprimir"
        Me.cmdImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdImprimir.UseVisualStyleBackColor = True
        '
        'cmdCopiar
        '
        Me.cmdCopiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopiar.Image = CType(resources.GetObject("cmdCopiar.Image"), System.Drawing.Image)
        Me.cmdCopiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCopiar.Location = New System.Drawing.Point(109, 2)
        Me.cmdCopiar.Name = "cmdCopiar"
        Me.cmdCopiar.Size = New System.Drawing.Size(82, 25)
        Me.cmdCopiar.TabIndex = 280
        Me.cmdCopiar.Text = "Copiar"
        Me.cmdCopiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCopiar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(518, 1)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(91, 25)
        Me.cmdCancelar.TabIndex = 279
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdGuardar
        '
        Me.cmdGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmdGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGuardar.Image = CType(resources.GetObject("cmdGuardar.Image"), System.Drawing.Image)
        Me.cmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGuardar.Location = New System.Drawing.Point(17, 2)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(91, 25)
        Me.cmdGuardar.TabIndex = 278
        Me.cmdGuardar.Text = "Guardar"
        Me.cmdGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGuardar.UseVisualStyleBackColor = True
        '
        'txtTitulo
        '
        Me.txtTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTitulo.Location = New System.Drawing.Point(468, 52)
        Me.txtTitulo.Margin = New System.Windows.Forms.Padding(0)
        Me.txtTitulo.MaxLength = 50
        Me.txtTitulo.Name = "txtTitulo"
        Me.txtTitulo.Size = New System.Drawing.Size(452, 31)
        Me.txtTitulo.TabIndex = 482
        Me.txtTitulo.Text = "ACCESORIOS"
        Me.txtTitulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCuadro6
        '
        Me.txtCuadro6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuadro6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuadro6.Location = New System.Drawing.Point(1, 371)
        Me.txtCuadro6.Name = "txtCuadro6"
        Me.txtCuadro6.Size = New System.Drawing.Size(323, 20)
        Me.txtCuadro6.TabIndex = 483
        Me.txtCuadro6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCuadro7
        '
        Me.txtCuadro7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCuadro7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuadro7.Location = New System.Drawing.Point(1, 391)
        Me.txtCuadro7.Name = "txtCuadro7"
        Me.txtCuadro7.Size = New System.Drawing.Size(323, 20)
        Me.txtCuadro7.TabIndex = 484
        Me.txtCuadro7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pdoImpAccesorio
        '
        '
        'cmdCopiarEnOtra
        '
        Me.cmdCopiarEnOtra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCopiarEnOtra.Image = CType(resources.GetObject("cmdCopiarEnOtra.Image"), System.Drawing.Image)
        Me.cmdCopiarEnOtra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCopiarEnOtra.Location = New System.Drawing.Point(309, 1)
        Me.cmdCopiarEnOtra.Name = "cmdCopiarEnOtra"
        Me.cmdCopiarEnOtra.Size = New System.Drawing.Size(179, 25)
        Me.cmdCopiarEnOtra.TabIndex = 283
        Me.cmdCopiarEnOtra.Text = "Copiar en Otra Planilla"
        Me.cmdCopiarEnOtra.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCopiarEnOtra.UseVisualStyleBackColor = True
        '
        'frmArtProdAccABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(982, 629)
        Me.Controls.Add(Me.txtCuadro7)
        Me.Controls.Add(Me.txtCuadro6)
        Me.Controls.Add(Me.txtTitulo)
        Me.Controls.Add(Me.Panel_Botonera)
        Me.Controls.Add(Me.dgvPicos)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCuadro8)
        Me.Controls.Add(Me.txtCuadro5)
        Me.Controls.Add(Me.txtCuadro4)
        Me.Controls.Add(Me.txtCuadro3)
        Me.Controls.Add(Me.txtCuadro2)
        Me.Controls.Add(Me.dgvGraduaciones)
        Me.Controls.Add(Me.lblDetalle)
        Me.Controls.Add(Me.lblGraduaciones)
        Me.Controls.Add(Me.txtCuadro1)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.lblArticulo)
        Me.Controls.Add(Me.lblOp)
        Me.Controls.Add(Me.txtOp)
        Me.Controls.Add(Me.lblPartida)
        Me.Controls.Add(Me.txtArticulo)
        Me.Controls.Add(Me.lblMedFinal)
        Me.Controls.Add(Me.txtMedFinal)
        Me.Controls.Add(Me.lblColor)
        Me.Controls.Add(Me.txtPartida)
        Me.Controls.Add(Me.lblPatron)
        Me.Controls.Add(Me.txtPatron)
        Me.Controls.Add(Me.txtColor)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.dtpFecha)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmArtProdAccABM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM Accesorios"
        CType(Me.dgvGraduaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPicos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_Botonera.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblArticulo As System.Windows.Forms.Label
    Friend WithEvents lblOp As System.Windows.Forms.Label
    Friend WithEvents txtOp As System.Windows.Forms.TextBox
    Friend WithEvents lblPartida As System.Windows.Forms.Label
    Friend WithEvents txtArticulo As System.Windows.Forms.TextBox
    Friend WithEvents lblMedFinal As System.Windows.Forms.Label
    Friend WithEvents txtMedFinal As System.Windows.Forms.TextBox
    Friend WithEvents lblColor As System.Windows.Forms.Label
    Friend WithEvents txtPartida As System.Windows.Forms.TextBox
    Friend WithEvents lblPatron As System.Windows.Forms.Label
    Friend WithEvents txtPatron As System.Windows.Forms.TextBox
    Friend WithEvents txtColor As System.Windows.Forms.TextBox
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents txtCuadro1 As System.Windows.Forms.TextBox
    Friend WithEvents lblDetalle As System.Windows.Forms.Label
    Friend WithEvents lblGraduaciones As System.Windows.Forms.Label
    Friend WithEvents dgvGraduaciones As System.Windows.Forms.DataGridView
    Friend WithEvents txtCuadro2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCuadro3 As System.Windows.Forms.TextBox
    Friend WithEvents txtCuadro4 As System.Windows.Forms.TextBox
    Friend WithEvents txtCuadro5 As System.Windows.Forms.TextBox
    Friend WithEvents txtCuadro8 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dgvPicos As System.Windows.Forms.DataGridView
    Friend WithEvents Panel_Botonera As System.Windows.Forms.Panel
    Friend WithEvents cmdImprimir As System.Windows.Forms.Button
    Friend WithEvents cmdCopiar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdGuardar As System.Windows.Forms.Button
    Friend WithEvents txtTitulo As System.Windows.Forms.TextBox
    Friend WithEvents txtCuadro6 As System.Windows.Forms.TextBox
    Friend WithEvents txtCuadro7 As System.Windows.Forms.TextBox
    Friend WithEvents pdoImpAccesorio As System.Drawing.Printing.PrintDocument
    Friend WithEvents cmdCopiarEnOtra As System.Windows.Forms.Button
End Class
