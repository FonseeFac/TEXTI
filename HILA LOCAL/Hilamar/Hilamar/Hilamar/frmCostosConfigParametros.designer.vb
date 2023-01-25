<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCostosConfigParametros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCostosConfigParametros))
        Me.cmdVolver = New System.Windows.Forms.Button()
        Me.gbConsumoGas = New System.Windows.Forms.GroupBox()
        Me.lblGasValorGlobalPorM3 = New System.Windows.Forms.Label()
        Me.lblGasValorGlobalPorM3Tit = New System.Windows.Forms.Label()
        Me.txtM3GasConsumidos = New System.Windows.Forms.TextBox()
        Me.lblM3GasConsumidos = New System.Windows.Forms.Label()
        Me.txtTotalEnergy = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdGuardarConsumoGas = New System.Windows.Forms.Button()
        Me.txtTotalCamuzzi = New System.Windows.Forms.TextBox()
        Me.lblTotalCamuzzi = New System.Windows.Forms.Label()
        Me.lblKWLuzConsumidos = New System.Windows.Forms.Label()
        Me.txtKWLuzConsumidos = New System.Windows.Forms.TextBox()
        Me.cmdGuardarConsumoLuz = New System.Windows.Forms.Button()
        Me.lblTotalEDEA = New System.Windows.Forms.Label()
        Me.txtTotalEdea = New System.Windows.Forms.TextBox()
        Me.gbConsumoLuz = New System.Windows.Forms.GroupBox()
        Me.lblLuzValorGlobalPorKwH = New System.Windows.Forms.Label()
        Me.lblLuzValorGlobalPorKwHTit = New System.Windows.Forms.Label()
        Me.gbConsumoAgua = New System.Windows.Forms.GroupBox()
        Me.lblAguaValorGlobalPorM3 = New System.Windows.Forms.Label()
        Me.lblAguaValorGlobalPorM3Tit = New System.Windows.Forms.Label()
        Me.txtTotalObrasSanitarias = New System.Windows.Forms.TextBox()
        Me.lblTotalObrasSanitarias = New System.Windows.Forms.Label()
        Me.cmdGuardarConsumoAgua = New System.Windows.Forms.Button()
        Me.txtM3AguaConsumidos = New System.Windows.Forms.TextBox()
        Me.lblM3AguaConsumidos = New System.Windows.Forms.Label()
        Me.gbHoraHombre = New System.Windows.Forms.GroupBox()
        Me.lblHoraHombre = New System.Windows.Forms.Label()
        Me.lblHoraHombreTit = New System.Windows.Forms.Label()
        Me.txtHoraHombreRecibo = New System.Windows.Forms.TextBox()
        Me.lblHoraHombreRecibo = New System.Windows.Forms.Label()
        Me.cmdGuardarHorasHombre = New System.Windows.Forms.Button()
        Me.txtFactorMultiplicador = New System.Windows.Forms.TextBox()
        Me.lblFactorMultiplicador = New System.Windows.Forms.Label()
        Me.gbConsumoGas.SuspendLayout()
        Me.gbConsumoLuz.SuspendLayout()
        Me.gbConsumoAgua.SuspendLayout()
        Me.gbHoraHombre.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdVolver
        '
        Me.cmdVolver.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdVolver.Location = New System.Drawing.Point(410, 500)
        Me.cmdVolver.Name = "cmdVolver"
        Me.cmdVolver.Size = New System.Drawing.Size(81, 27)
        Me.cmdVolver.TabIndex = 9
        Me.cmdVolver.Text = "Volver"
        Me.cmdVolver.UseVisualStyleBackColor = True
        '
        'gbConsumoGas
        '
        Me.gbConsumoGas.Controls.Add(Me.lblGasValorGlobalPorM3)
        Me.gbConsumoGas.Controls.Add(Me.lblGasValorGlobalPorM3Tit)
        Me.gbConsumoGas.Controls.Add(Me.txtM3GasConsumidos)
        Me.gbConsumoGas.Controls.Add(Me.lblM3GasConsumidos)
        Me.gbConsumoGas.Controls.Add(Me.txtTotalEnergy)
        Me.gbConsumoGas.Controls.Add(Me.Label1)
        Me.gbConsumoGas.Controls.Add(Me.cmdGuardarConsumoGas)
        Me.gbConsumoGas.Controls.Add(Me.txtTotalCamuzzi)
        Me.gbConsumoGas.Controls.Add(Me.lblTotalCamuzzi)
        Me.gbConsumoGas.Location = New System.Drawing.Point(12, 12)
        Me.gbConsumoGas.Name = "gbConsumoGas"
        Me.gbConsumoGas.Size = New System.Drawing.Size(371, 145)
        Me.gbConsumoGas.TabIndex = 123
        Me.gbConsumoGas.TabStop = False
        '
        'lblGasValorGlobalPorM3
        '
        Me.lblGasValorGlobalPorM3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGasValorGlobalPorM3.Location = New System.Drawing.Point(163, 106)
        Me.lblGasValorGlobalPorM3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGasValorGlobalPorM3.Name = "lblGasValorGlobalPorM3"
        Me.lblGasValorGlobalPorM3.Size = New System.Drawing.Size(95, 22)
        Me.lblGasValorGlobalPorM3.TabIndex = 135
        Me.lblGasValorGlobalPorM3.Text = "0.0"
        Me.lblGasValorGlobalPorM3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGasValorGlobalPorM3Tit
        '
        Me.lblGasValorGlobalPorM3Tit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGasValorGlobalPorM3Tit.Location = New System.Drawing.Point(7, 106)
        Me.lblGasValorGlobalPorM3Tit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGasValorGlobalPorM3Tit.Name = "lblGasValorGlobalPorM3Tit"
        Me.lblGasValorGlobalPorM3Tit.Size = New System.Drawing.Size(152, 22)
        Me.lblGasValorGlobalPorM3Tit.TabIndex = 134
        Me.lblGasValorGlobalPorM3Tit.Text = "Valor Global por M3:"
        Me.lblGasValorGlobalPorM3Tit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtM3GasConsumidos
        '
        Me.txtM3GasConsumidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtM3GasConsumidos.Location = New System.Drawing.Point(166, 72)
        Me.txtM3GasConsumidos.Name = "txtM3GasConsumidos"
        Me.txtM3GasConsumidos.Size = New System.Drawing.Size(92, 22)
        Me.txtM3GasConsumidos.TabIndex = 133
        Me.txtM3GasConsumidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblM3GasConsumidos
        '
        Me.lblM3GasConsumidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblM3GasConsumidos.Location = New System.Drawing.Point(7, 72)
        Me.lblM3GasConsumidos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblM3GasConsumidos.Name = "lblM3GasConsumidos"
        Me.lblM3GasConsumidos.Size = New System.Drawing.Size(152, 22)
        Me.lblM3GasConsumidos.TabIndex = 132
        Me.lblM3GasConsumidos.Text = "Total M3 Consumidos:"
        Me.lblM3GasConsumidos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotalEnergy
        '
        Me.txtTotalEnergy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalEnergy.Location = New System.Drawing.Point(166, 44)
        Me.txtTotalEnergy.Name = "txtTotalEnergy"
        Me.txtTotalEnergy.Size = New System.Drawing.Size(92, 22)
        Me.txtTotalEnergy.TabIndex = 131
        Me.txtTotalEnergy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 44)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 22)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "Factura Energy:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdGuardarConsumoGas
        '
        Me.cmdGuardarConsumoGas.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGuardarConsumoGas.Location = New System.Drawing.Point(277, 101)
        Me.cmdGuardarConsumoGas.Name = "cmdGuardarConsumoGas"
        Me.cmdGuardarConsumoGas.Size = New System.Drawing.Size(81, 27)
        Me.cmdGuardarConsumoGas.TabIndex = 129
        Me.cmdGuardarConsumoGas.Text = "Guardar"
        Me.cmdGuardarConsumoGas.UseVisualStyleBackColor = True
        '
        'txtTotalCamuzzi
        '
        Me.txtTotalCamuzzi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCamuzzi.Location = New System.Drawing.Point(166, 16)
        Me.txtTotalCamuzzi.Name = "txtTotalCamuzzi"
        Me.txtTotalCamuzzi.Size = New System.Drawing.Size(92, 22)
        Me.txtTotalCamuzzi.TabIndex = 126
        Me.txtTotalCamuzzi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalCamuzzi
        '
        Me.lblTotalCamuzzi.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCamuzzi.Location = New System.Drawing.Point(29, 16)
        Me.lblTotalCamuzzi.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalCamuzzi.Name = "lblTotalCamuzzi"
        Me.lblTotalCamuzzi.Size = New System.Drawing.Size(130, 22)
        Me.lblTotalCamuzzi.TabIndex = 125
        Me.lblTotalCamuzzi.Text = "Factura Camuzzi:"
        Me.lblTotalCamuzzi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblKWLuzConsumidos
        '
        Me.lblKWLuzConsumidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKWLuzConsumidos.Location = New System.Drawing.Point(23, 44)
        Me.lblKWLuzConsumidos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblKWLuzConsumidos.Name = "lblKWLuzConsumidos"
        Me.lblKWLuzConsumidos.Size = New System.Drawing.Size(136, 22)
        Me.lblKWLuzConsumidos.TabIndex = 124
        Me.lblKWLuzConsumidos.Text = "KW consumidos:"
        Me.lblKWLuzConsumidos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtKWLuzConsumidos
        '
        Me.txtKWLuzConsumidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKWLuzConsumidos.Location = New System.Drawing.Point(166, 44)
        Me.txtKWLuzConsumidos.Name = "txtKWLuzConsumidos"
        Me.txtKWLuzConsumidos.Size = New System.Drawing.Size(92, 22)
        Me.txtKWLuzConsumidos.TabIndex = 125
        Me.txtKWLuzConsumidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdGuardarConsumoLuz
        '
        Me.cmdGuardarConsumoLuz.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGuardarConsumoLuz.Location = New System.Drawing.Point(277, 74)
        Me.cmdGuardarConsumoLuz.Name = "cmdGuardarConsumoLuz"
        Me.cmdGuardarConsumoLuz.Size = New System.Drawing.Size(81, 27)
        Me.cmdGuardarConsumoLuz.TabIndex = 128
        Me.cmdGuardarConsumoLuz.Text = "Guardar"
        Me.cmdGuardarConsumoLuz.UseVisualStyleBackColor = True
        '
        'lblTotalEDEA
        '
        Me.lblTotalEDEA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalEDEA.Location = New System.Drawing.Point(17, 16)
        Me.lblTotalEDEA.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalEDEA.Name = "lblTotalEDEA"
        Me.lblTotalEDEA.Size = New System.Drawing.Size(142, 22)
        Me.lblTotalEDEA.TabIndex = 131
        Me.lblTotalEDEA.Text = "Factura EDEA:"
        Me.lblTotalEDEA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotalEdea
        '
        Me.txtTotalEdea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalEdea.Location = New System.Drawing.Point(166, 16)
        Me.txtTotalEdea.Name = "txtTotalEdea"
        Me.txtTotalEdea.Size = New System.Drawing.Size(92, 22)
        Me.txtTotalEdea.TabIndex = 132
        Me.txtTotalEdea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gbConsumoLuz
        '
        Me.gbConsumoLuz.Controls.Add(Me.lblLuzValorGlobalPorKwH)
        Me.gbConsumoLuz.Controls.Add(Me.lblLuzValorGlobalPorKwHTit)
        Me.gbConsumoLuz.Controls.Add(Me.txtTotalEdea)
        Me.gbConsumoLuz.Controls.Add(Me.lblTotalEDEA)
        Me.gbConsumoLuz.Controls.Add(Me.cmdGuardarConsumoLuz)
        Me.gbConsumoLuz.Controls.Add(Me.txtKWLuzConsumidos)
        Me.gbConsumoLuz.Controls.Add(Me.lblKWLuzConsumidos)
        Me.gbConsumoLuz.Location = New System.Drawing.Point(12, 163)
        Me.gbConsumoLuz.Name = "gbConsumoLuz"
        Me.gbConsumoLuz.Size = New System.Drawing.Size(371, 116)
        Me.gbConsumoLuz.TabIndex = 124
        Me.gbConsumoLuz.TabStop = False
        '
        'lblLuzValorGlobalPorKwH
        '
        Me.lblLuzValorGlobalPorKwH.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLuzValorGlobalPorKwH.Location = New System.Drawing.Point(163, 79)
        Me.lblLuzValorGlobalPorKwH.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLuzValorGlobalPorKwH.Name = "lblLuzValorGlobalPorKwH"
        Me.lblLuzValorGlobalPorKwH.Size = New System.Drawing.Size(95, 22)
        Me.lblLuzValorGlobalPorKwH.TabIndex = 137
        Me.lblLuzValorGlobalPorKwH.Text = "0.0"
        Me.lblLuzValorGlobalPorKwH.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLuzValorGlobalPorKwHTit
        '
        Me.lblLuzValorGlobalPorKwHTit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLuzValorGlobalPorKwHTit.Location = New System.Drawing.Point(7, 79)
        Me.lblLuzValorGlobalPorKwHTit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLuzValorGlobalPorKwHTit.Name = "lblLuzValorGlobalPorKwHTit"
        Me.lblLuzValorGlobalPorKwHTit.Size = New System.Drawing.Size(152, 22)
        Me.lblLuzValorGlobalPorKwHTit.TabIndex = 136
        Me.lblLuzValorGlobalPorKwHTit.Text = "Valor Global por KwH:"
        Me.lblLuzValorGlobalPorKwHTit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbConsumoAgua
        '
        Me.gbConsumoAgua.Controls.Add(Me.lblAguaValorGlobalPorM3)
        Me.gbConsumoAgua.Controls.Add(Me.lblAguaValorGlobalPorM3Tit)
        Me.gbConsumoAgua.Controls.Add(Me.txtTotalObrasSanitarias)
        Me.gbConsumoAgua.Controls.Add(Me.lblTotalObrasSanitarias)
        Me.gbConsumoAgua.Controls.Add(Me.cmdGuardarConsumoAgua)
        Me.gbConsumoAgua.Controls.Add(Me.txtM3AguaConsumidos)
        Me.gbConsumoAgua.Controls.Add(Me.lblM3AguaConsumidos)
        Me.gbConsumoAgua.Location = New System.Drawing.Point(12, 295)
        Me.gbConsumoAgua.Name = "gbConsumoAgua"
        Me.gbConsumoAgua.Size = New System.Drawing.Size(371, 116)
        Me.gbConsumoAgua.TabIndex = 125
        Me.gbConsumoAgua.TabStop = False
        '
        'lblAguaValorGlobalPorM3
        '
        Me.lblAguaValorGlobalPorM3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAguaValorGlobalPorM3.Location = New System.Drawing.Point(163, 79)
        Me.lblAguaValorGlobalPorM3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAguaValorGlobalPorM3.Name = "lblAguaValorGlobalPorM3"
        Me.lblAguaValorGlobalPorM3.Size = New System.Drawing.Size(95, 22)
        Me.lblAguaValorGlobalPorM3.TabIndex = 137
        Me.lblAguaValorGlobalPorM3.Text = "0.0"
        Me.lblAguaValorGlobalPorM3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAguaValorGlobalPorM3Tit
        '
        Me.lblAguaValorGlobalPorM3Tit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAguaValorGlobalPorM3Tit.Location = New System.Drawing.Point(7, 79)
        Me.lblAguaValorGlobalPorM3Tit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAguaValorGlobalPorM3Tit.Name = "lblAguaValorGlobalPorM3Tit"
        Me.lblAguaValorGlobalPorM3Tit.Size = New System.Drawing.Size(152, 22)
        Me.lblAguaValorGlobalPorM3Tit.TabIndex = 136
        Me.lblAguaValorGlobalPorM3Tit.Text = "Valor Global por M3:"
        Me.lblAguaValorGlobalPorM3Tit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTotalObrasSanitarias
        '
        Me.txtTotalObrasSanitarias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalObrasSanitarias.Location = New System.Drawing.Point(166, 16)
        Me.txtTotalObrasSanitarias.Name = "txtTotalObrasSanitarias"
        Me.txtTotalObrasSanitarias.Size = New System.Drawing.Size(92, 22)
        Me.txtTotalObrasSanitarias.TabIndex = 132
        Me.txtTotalObrasSanitarias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalObrasSanitarias
        '
        Me.lblTotalObrasSanitarias.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalObrasSanitarias.Location = New System.Drawing.Point(17, 16)
        Me.lblTotalObrasSanitarias.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalObrasSanitarias.Name = "lblTotalObrasSanitarias"
        Me.lblTotalObrasSanitarias.Size = New System.Drawing.Size(142, 22)
        Me.lblTotalObrasSanitarias.TabIndex = 131
        Me.lblTotalObrasSanitarias.Text = "Factura Obras Sanit:"
        Me.lblTotalObrasSanitarias.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdGuardarConsumoAgua
        '
        Me.cmdGuardarConsumoAgua.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGuardarConsumoAgua.Location = New System.Drawing.Point(277, 74)
        Me.cmdGuardarConsumoAgua.Name = "cmdGuardarConsumoAgua"
        Me.cmdGuardarConsumoAgua.Size = New System.Drawing.Size(81, 27)
        Me.cmdGuardarConsumoAgua.TabIndex = 128
        Me.cmdGuardarConsumoAgua.Text = "Guardar"
        Me.cmdGuardarConsumoAgua.UseVisualStyleBackColor = True
        '
        'txtM3AguaConsumidos
        '
        Me.txtM3AguaConsumidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtM3AguaConsumidos.Location = New System.Drawing.Point(166, 44)
        Me.txtM3AguaConsumidos.Name = "txtM3AguaConsumidos"
        Me.txtM3AguaConsumidos.Size = New System.Drawing.Size(92, 22)
        Me.txtM3AguaConsumidos.TabIndex = 125
        Me.txtM3AguaConsumidos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblM3AguaConsumidos
        '
        Me.lblM3AguaConsumidos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblM3AguaConsumidos.Location = New System.Drawing.Point(23, 44)
        Me.lblM3AguaConsumidos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblM3AguaConsumidos.Name = "lblM3AguaConsumidos"
        Me.lblM3AguaConsumidos.Size = New System.Drawing.Size(136, 22)
        Me.lblM3AguaConsumidos.TabIndex = 124
        Me.lblM3AguaConsumidos.Text = "M3 Consumidos"
        Me.lblM3AguaConsumidos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbHoraHombre
        '
        Me.gbHoraHombre.Controls.Add(Me.lblHoraHombre)
        Me.gbHoraHombre.Controls.Add(Me.lblHoraHombreTit)
        Me.gbHoraHombre.Controls.Add(Me.txtHoraHombreRecibo)
        Me.gbHoraHombre.Controls.Add(Me.lblHoraHombreRecibo)
        Me.gbHoraHombre.Controls.Add(Me.cmdGuardarHorasHombre)
        Me.gbHoraHombre.Controls.Add(Me.txtFactorMultiplicador)
        Me.gbHoraHombre.Controls.Add(Me.lblFactorMultiplicador)
        Me.gbHoraHombre.Location = New System.Drawing.Point(12, 426)
        Me.gbHoraHombre.Name = "gbHoraHombre"
        Me.gbHoraHombre.Size = New System.Drawing.Size(371, 116)
        Me.gbHoraHombre.TabIndex = 126
        Me.gbHoraHombre.TabStop = False
        '
        'lblHoraHombre
        '
        Me.lblHoraHombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoraHombre.Location = New System.Drawing.Point(163, 79)
        Me.lblHoraHombre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHoraHombre.Name = "lblHoraHombre"
        Me.lblHoraHombre.Size = New System.Drawing.Size(95, 22)
        Me.lblHoraHombre.TabIndex = 137
        Me.lblHoraHombre.Text = "0.0"
        Me.lblHoraHombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblHoraHombreTit
        '
        Me.lblHoraHombreTit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoraHombreTit.Location = New System.Drawing.Point(7, 79)
        Me.lblHoraHombreTit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHoraHombreTit.Name = "lblHoraHombreTit"
        Me.lblHoraHombreTit.Size = New System.Drawing.Size(152, 22)
        Me.lblHoraHombreTit.TabIndex = 136
        Me.lblHoraHombreTit.Text = "Hora Hombre:"
        Me.lblHoraHombreTit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtHoraHombreRecibo
        '
        Me.txtHoraHombreRecibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraHombreRecibo.Location = New System.Drawing.Point(192, 16)
        Me.txtHoraHombreRecibo.Name = "txtHoraHombreRecibo"
        Me.txtHoraHombreRecibo.Size = New System.Drawing.Size(66, 22)
        Me.txtHoraHombreRecibo.TabIndex = 132
        Me.txtHoraHombreRecibo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblHoraHombreRecibo
        '
        Me.lblHoraHombreRecibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoraHombreRecibo.Location = New System.Drawing.Point(7, 16)
        Me.lblHoraHombreRecibo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHoraHombreRecibo.Name = "lblHoraHombreRecibo"
        Me.lblHoraHombreRecibo.Size = New System.Drawing.Size(178, 22)
        Me.lblHoraHombreRecibo.TabIndex = 131
        Me.lblHoraHombreRecibo.Text = "Hora Hombre por Recibo:"
        Me.lblHoraHombreRecibo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdGuardarHorasHombre
        '
        Me.cmdGuardarHorasHombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGuardarHorasHombre.Location = New System.Drawing.Point(277, 74)
        Me.cmdGuardarHorasHombre.Name = "cmdGuardarHorasHombre"
        Me.cmdGuardarHorasHombre.Size = New System.Drawing.Size(81, 27)
        Me.cmdGuardarHorasHombre.TabIndex = 128
        Me.cmdGuardarHorasHombre.Text = "Guardar"
        Me.cmdGuardarHorasHombre.UseVisualStyleBackColor = True
        '
        'txtFactorMultiplicador
        '
        Me.txtFactorMultiplicador.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFactorMultiplicador.Location = New System.Drawing.Point(192, 44)
        Me.txtFactorMultiplicador.Name = "txtFactorMultiplicador"
        Me.txtFactorMultiplicador.Size = New System.Drawing.Size(66, 22)
        Me.txtFactorMultiplicador.TabIndex = 125
        Me.txtFactorMultiplicador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFactorMultiplicador
        '
        Me.lblFactorMultiplicador.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFactorMultiplicador.Location = New System.Drawing.Point(23, 44)
        Me.lblFactorMultiplicador.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFactorMultiplicador.Name = "lblFactorMultiplicador"
        Me.lblFactorMultiplicador.Size = New System.Drawing.Size(162, 22)
        Me.lblFactorMultiplicador.TabIndex = 124
        Me.lblFactorMultiplicador.Text = "Factor Multiplicador:"
        Me.lblFactorMultiplicador.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCostosConfigParametros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 560)
        Me.Controls.Add(Me.gbHoraHombre)
        Me.Controls.Add(Me.gbConsumoAgua)
        Me.Controls.Add(Me.gbConsumoLuz)
        Me.Controls.Add(Me.gbConsumoGas)
        Me.Controls.Add(Me.cmdVolver)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCostosConfigParametros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración de parámetros para los cálculos de Costos"
        Me.gbConsumoGas.ResumeLayout(False)
        Me.gbConsumoGas.PerformLayout()
        Me.gbConsumoLuz.ResumeLayout(False)
        Me.gbConsumoLuz.PerformLayout()
        Me.gbConsumoAgua.ResumeLayout(False)
        Me.gbConsumoAgua.PerformLayout()
        Me.gbHoraHombre.ResumeLayout(False)
        Me.gbHoraHombre.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdVolver As System.Windows.Forms.Button
    Friend WithEvents gbConsumoGas As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotalCamuzzi As System.Windows.Forms.TextBox
    Friend WithEvents cmdGuardarConsumoGas As System.Windows.Forms.Button
    Friend WithEvents lblGasValorGlobalPorM3 As System.Windows.Forms.Label
    Friend WithEvents lblGasValorGlobalPorM3Tit As System.Windows.Forms.Label
    Friend WithEvents txtM3GasConsumidos As System.Windows.Forms.TextBox
    Friend WithEvents lblM3GasConsumidos As System.Windows.Forms.Label
    Friend WithEvents txtTotalEnergy As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTotalCamuzzi As System.Windows.Forms.Label
    Friend WithEvents lblKWLuzConsumidos As System.Windows.Forms.Label
    Friend WithEvents txtKWLuzConsumidos As System.Windows.Forms.TextBox
    Friend WithEvents cmdGuardarConsumoLuz As System.Windows.Forms.Button
    Friend WithEvents lblTotalEDEA As System.Windows.Forms.Label
    Friend WithEvents txtTotalEdea As System.Windows.Forms.TextBox
    Friend WithEvents gbConsumoLuz As System.Windows.Forms.GroupBox
    Friend WithEvents lblLuzValorGlobalPorKwH As System.Windows.Forms.Label
    Friend WithEvents lblLuzValorGlobalPorKwHTit As System.Windows.Forms.Label
    Friend WithEvents gbConsumoAgua As System.Windows.Forms.GroupBox
    Friend WithEvents lblAguaValorGlobalPorM3 As System.Windows.Forms.Label
    Friend WithEvents lblAguaValorGlobalPorM3Tit As System.Windows.Forms.Label
    Friend WithEvents txtTotalObrasSanitarias As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalObrasSanitarias As System.Windows.Forms.Label
    Friend WithEvents cmdGuardarConsumoAgua As System.Windows.Forms.Button
    Friend WithEvents txtM3AguaConsumidos As System.Windows.Forms.TextBox
    Friend WithEvents lblM3AguaConsumidos As System.Windows.Forms.Label
    Friend WithEvents gbHoraHombre As System.Windows.Forms.GroupBox
    Friend WithEvents lblHoraHombre As System.Windows.Forms.Label
    Friend WithEvents lblHoraHombreTit As System.Windows.Forms.Label
    Friend WithEvents txtHoraHombreRecibo As System.Windows.Forms.TextBox
    Friend WithEvents lblHoraHombreRecibo As System.Windows.Forms.Label
    Friend WithEvents cmdGuardarHorasHombre As System.Windows.Forms.Button
    Friend WithEvents txtFactorMultiplicador As System.Windows.Forms.TextBox
    Friend WithEvents lblFactorMultiplicador As System.Windows.Forms.Label
End Class
