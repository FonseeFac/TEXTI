<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepoCostoArticulos_3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepoCostoArticulos_3))
        Me.dgvArticulos = New System.Windows.Forms.DataGridView()
        Me.txtCodArtDesde = New System.Windows.Forms.TextBox()
        Me.lblCodArtDesde = New System.Windows.Forms.Label()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.txtCodArtHasta = New System.Windows.Forms.TextBox()
        Me.lblCodArtHasta = New System.Windows.Forms.Label()
        Me.lblCodArtTitulo = New System.Windows.Forms.Label()
        Me.chkVerInhabilitados = New System.Windows.Forms.CheckBox()
        Me.cmdImprimir = New System.Windows.Forms.Button()
        Me.pdoImpresion = New System.Drawing.Printing.PrintDocument()
        Me.gbArmadoArticulo = New System.Windows.Forms.GroupBox()
        Me.lblCostoTotalTareas = New System.Windows.Forms.Label()
        Me.lblTitCostoTareas = New System.Windows.Forms.Label()
        Me.lblCostoTotalCelda = New System.Windows.Forms.Label()
        Me.lblTitCostoCelda = New System.Windows.Forms.Label()
        Me.lblCantPersonas = New System.Windows.Forms.Label()
        Me.lblTitCantPersonas = New System.Windows.Forms.Label()
        Me.lblFechaHasta = New System.Windows.Forms.Label()
        Me.lblTitFechaHasta = New System.Windows.Forms.Label()
        Me.lblNroCelda = New System.Windows.Forms.Label()
        Me.lblTitNroCelda = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvTareasArt = New System.Windows.Forms.DataGridView()
        Me.btnVerArmado = New System.Windows.Forms.Button()
        Me.cmbHilados = New System.Windows.Forms.ComboBox()
        Me.lblTipoHilado = New System.Windows.Forms.Label()
        Me.btnVerCalculo = New System.Windows.Forms.Button()
        Me.gbCalculo = New System.Windows.Forms.GroupBox()
        Me.PanelCostoTejeduriaRESTO = New System.Windows.Forms.Panel()
        Me.lblCostoMOdelArticulo = New System.Windows.Forms.Label()
        Me.lblTitCostoMOdelArticulo = New System.Windows.Forms.Label()
        Me.lblCostoPorMinutoPorPrenda = New System.Windows.Forms.Label()
        Me.lblTitCostoPorMinutoPorPrenda = New System.Windows.Forms.Label()
        Me.lblCostoPorMinutoTejeduria = New System.Windows.Forms.Label()
        Me.lblTitCostoPorMinutoTejeduria = New System.Windows.Forms.Label()
        Me.lblCantHorasDelMes = New System.Windows.Forms.Label()
        Me.lblTitCantHorasDelMes = New System.Windows.Forms.Label()
        Me.lblCantMaquinasTejeduria = New System.Windows.Forms.Label()
        Me.lblTitCantMaquinasTejeduria = New System.Windows.Forms.Label()
        Me.lblTotalSueldosTejeduria = New System.Windows.Forms.Label()
        Me.lblTitTotalSueldosTejeduria = New System.Windows.Forms.Label()
        Me.lblCantPersonasTejeduria = New System.Windows.Forms.Label()
        Me.lblTitCantPersonasTejeduria = New System.Windows.Forms.Label()
        Me.lblSemanasConfTejeduria = New System.Windows.Forms.Label()
        Me.lblTitSemanasConfTejeduria = New System.Windows.Forms.Label()
        Me.lblCantMinutosArticulo = New System.Windows.Forms.Label()
        Me.lblTitCantMinutosArticulo = New System.Windows.Forms.Label()
        Me.PanelCostoTejeduriaCORTE = New System.Windows.Forms.Panel()
        Me.lblCantMaqPorTejedor = New System.Windows.Forms.Label()
        Me.lblPesoRolloHilado = New System.Windows.Forms.Label()
        Me.lblRollosMaqTurno = New System.Windows.Forms.Label()
        Me.lblRollosPorHora = New System.Windows.Forms.Label()
        Me.lblKilosPorHora = New System.Windows.Forms.Label()
        Me.lblAuxRollosPorHora = New System.Windows.Forms.Label()
        Me.lblAuxKilosPorHora = New System.Windows.Forms.Label()
        Me.lblAuxCostoMO = New System.Windows.Forms.Label()
        Me.lblPesosPorKiloMO = New System.Windows.Forms.Label()
        Me.lblAuxPesosPorKiloMO = New System.Windows.Forms.Label()
        Me.lblCostoManoObra = New System.Windows.Forms.Label()
        Me.lblCostoTeñido = New System.Windows.Forms.Label()
        Me.lblCostoTotal = New System.Windows.Forms.Label()
        Me.lblCostosIndirectos = New System.Windows.Forms.Label()
        Me.lblCostoMateriales = New System.Windows.Forms.Label()
        Me.lblCostoHilado = New System.Windows.Forms.Label()
        Me.lblCostoKiloHilado = New System.Windows.Forms.Label()
        Me.lblSAC = New System.Windows.Forms.Label()
        Me.lblCargasSociales = New System.Windows.Forms.Label()
        Me.lblPresentismo = New System.Windows.Forms.Label()
        Me.lblValorHoraMO = New System.Windows.Forms.Label()
        Me.lblCostoManoObraConCargasSociales = New System.Windows.Forms.Label()
        Me.lblCostoArmadoConCargasSociales = New System.Windows.Forms.Label()
        Me.lblCostoArmado = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbPROD = New System.Windows.Forms.ComboBox()
        Me.lblPROD = New System.Windows.Forms.Label()
        Me.cmbTipoLisoSublimado = New System.Windows.Forms.ComboBox()
        Me.lblTipoLisoSublimado = New System.Windows.Forms.Label()
        Me.dgvSueldosTejeduria = New System.Windows.Forms.DataGridView()
        Me.btnVerCostosIndirectos = New System.Windows.Forms.Button()
        Me.gbCostosIndirectos = New System.Windows.Forms.GroupBox()
        Me.lblPorcionRestoPlanta = New System.Windows.Forms.Label()
        Me.lblTitPorcentajeRestoPlanta = New System.Windows.Forms.Label()
        Me.lblPorcionTejeduria = New System.Windows.Forms.Label()
        Me.lblTitPorcentajeTejeduria = New System.Windows.Forms.Label()
        Me.lblTotalPrendasProducidas = New System.Windows.Forms.Label()
        Me.lblTitTotalPrendasProducidas = New System.Windows.Forms.Label()
        Me.lblTotalPrendasCortadas = New System.Windows.Forms.Label()
        Me.lblTitTotalPrendasCortadas = New System.Windows.Forms.Label()
        Me.lblTotalPrendasTejidas = New System.Windows.Forms.Label()
        Me.lblTitTotalPrendasTejidas = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTotalGastosIndirectos = New System.Windows.Forms.Label()
        Me.lblTitTotalGastosIndirectos = New System.Windows.Forms.Label()
        Me.lblTotalCostosRubros = New System.Windows.Forms.Label()
        Me.lblTitTotalCastosRubros = New System.Windows.Forms.Label()
        Me.lblTotalSueldosOperativosMasCargas = New System.Windows.Forms.Label()
        Me.lblTitTotalSueldosOperativosConCargas = New System.Windows.Forms.Label()
        Me.lblTotalSueldosOperativos = New System.Windows.Forms.Label()
        Me.lblTitTotalSueldosOperativos = New System.Windows.Forms.Label()
        Me.lblGastoSueldosDptoMantLavEncAyud = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblGastoSueldosSupGerDiseProg = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblTotalCostosOperativos = New System.Windows.Forms.Label()
        Me.lblGastoSeguridadVigilancia = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblGastoAtencionMedica = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblGastoEfluentesIndustriales = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblGastoTasaServSanitarios = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblGastoImpYTasasVarios = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblGastoTasaAlumbrado = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblGastoGas = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblGastoLuz = New System.Windows.Forms.Label()
        Me.lblCostoGastoIndirectoPorPrendaTejida = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.lblTitTotalCostosOperativos = New System.Windows.Forms.Label()
        Me.gbRecuperoSueldosTeje = New System.Windows.Forms.GroupBox()
        Me.btnRecuperarExcelCargasSociales = New System.Windows.Forms.Button()
        Me.lblUltimoRecuperoExcelCargasSociales = New System.Windows.Forms.Label()
        Me.gbParametrosCosto = New System.Windows.Forms.GroupBox()
        Me.txtParamCantPrendasCortadas = New System.Windows.Forms.TextBox()
        Me.lblParamCantPrendasCortadas = New System.Windows.Forms.Label()
        Me.btnRecalcularCostos = New System.Windows.Forms.Button()
        Me.txtParamCantPrendasTejidas = New System.Windows.Forms.TextBox()
        Me.lblParamCantPrendastejidas = New System.Windows.Forms.Label()
        Me.btnVerColSinCS = New System.Windows.Forms.Button()
        Me.gbCalculoCostoRubros = New System.Windows.Forms.GroupBox()
        Me.lblCostoRubroMensualEnPesos = New System.Windows.Forms.Label()
        Me.lblTitCostoRubroMensualEnPesos = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblCostoRubroCotizDolar = New System.Windows.Forms.Label()
        Me.lblTitCostoRubroCotizDolar = New System.Windows.Forms.Label()
        Me.lblCostoRubroTotalDolares = New System.Windows.Forms.Label()
        Me.lblTitCostoRubroTotalDolares = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dgvCostosRubros = New System.Windows.Forms.DataGridView()
        Me.btnVerCostosRubros = New System.Windows.Forms.Button()
        Me.gbMaterialesArticulo = New System.Windows.Forms.GroupBox()
        Me.lblCostoCierres = New System.Windows.Forms.Label()
        Me.lblTitCostoCierres = New System.Windows.Forms.Label()
        Me.lblCostoBotones = New System.Windows.Forms.Label()
        Me.lblTitCostoBotones = New System.Windows.Forms.Label()
        Me.lblTotalMateriales = New System.Windows.Forms.Label()
        Me.lblTitTotalMateriales = New System.Windows.Forms.Label()
        Me.lblCantidadDeCierres = New System.Windows.Forms.Label()
        Me.lblTitCantidadDeCierres = New System.Windows.Forms.Label()
        Me.lblCosto1Cierre = New System.Windows.Forms.Label()
        Me.lblTitCosto1Cierre = New System.Windows.Forms.Label()
        Me.lblCantidadDeBotones = New System.Windows.Forms.Label()
        Me.lblTitCantidadDeBotones = New System.Windows.Forms.Label()
        Me.lblCosto1Boton = New System.Windows.Forms.Label()
        Me.lblTitCosto1Boton = New System.Windows.Forms.Label()
        Me.btnVerMateriales = New System.Windows.Forms.Button()
        Me.lblPorcionConfRestoPlantayEtapa2 = New System.Windows.Forms.Label()
        Me.lblTitPorcentajeConfRestoPlantayEtapa2 = New System.Windows.Forms.Label()
        Me.lblPorcionConfTejeduriayEtapa2 = New System.Windows.Forms.Label()
        Me.lblTitPorcentajeConfTejeduriayEtapa2 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblCostoGastoIndirectoPorPrendaCorte = New System.Windows.Forms.Label()
        Me.lblCalculoCIPrendaCortada = New System.Windows.Forms.Label()
        Me.lblCalculoCIPrendaTejida = New System.Windows.Forms.Label()
        CType(Me.dgvArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbArmadoArticulo.SuspendLayout()
        CType(Me.dgvTareasArt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCalculo.SuspendLayout()
        Me.PanelCostoTejeduriaRESTO.SuspendLayout()
        Me.PanelCostoTejeduriaCORTE.SuspendLayout()
        CType(Me.dgvSueldosTejeduria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbCostosIndirectos.SuspendLayout()
        Me.gbRecuperoSueldosTeje.SuspendLayout()
        Me.gbParametrosCosto.SuspendLayout()
        Me.gbCalculoCostoRubros.SuspendLayout()
        CType(Me.dgvCostosRubros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMaterialesArticulo.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvArticulos
        '
        Me.dgvArticulos.AllowUserToAddRows = False
        Me.dgvArticulos.AllowUserToDeleteRows = False
        Me.dgvArticulos.AllowUserToResizeColumns = False
        Me.dgvArticulos.AllowUserToResizeRows = False
        Me.dgvArticulos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArticulos.Location = New System.Drawing.Point(6, 197)
        Me.dgvArticulos.Name = "dgvArticulos"
        Me.dgvArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvArticulos.Size = New System.Drawing.Size(181, 621)
        Me.dgvArticulos.TabIndex = 8
        '
        'txtCodArtDesde
        '
        Me.txtCodArtDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodArtDesde.Location = New System.Drawing.Point(146, 114)
        Me.txtCodArtDesde.Name = "txtCodArtDesde"
        Me.txtCodArtDesde.Size = New System.Drawing.Size(72, 22)
        Me.txtCodArtDesde.TabIndex = 105
        '
        'lblCodArtDesde
        '
        Me.lblCodArtDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodArtDesde.Location = New System.Drawing.Point(86, 114)
        Me.lblCodArtDesde.Name = "lblCodArtDesde"
        Me.lblCodArtDesde.Size = New System.Drawing.Size(54, 23)
        Me.lblCodArtDesde.TabIndex = 104
        Me.lblCodArtDesde.Text = "Desde:"
        Me.lblCodArtDesde.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFiltrar.Location = New System.Drawing.Point(427, 43)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(75, 40)
        Me.btnFiltrar.TabIndex = 106
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'txtCodArtHasta
        '
        Me.txtCodArtHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodArtHasta.Location = New System.Drawing.Point(295, 114)
        Me.txtCodArtHasta.Name = "txtCodArtHasta"
        Me.txtCodArtHasta.Size = New System.Drawing.Size(72, 22)
        Me.txtCodArtHasta.TabIndex = 108
        '
        'lblCodArtHasta
        '
        Me.lblCodArtHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodArtHasta.Location = New System.Drawing.Point(240, 114)
        Me.lblCodArtHasta.Name = "lblCodArtHasta"
        Me.lblCodArtHasta.Size = New System.Drawing.Size(49, 23)
        Me.lblCodArtHasta.TabIndex = 107
        Me.lblCodArtHasta.Text = "Hasta:"
        Me.lblCodArtHasta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCodArtTitulo
        '
        Me.lblCodArtTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCodArtTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodArtTitulo.Location = New System.Drawing.Point(18, 108)
        Me.lblCodArtTitulo.Name = "lblCodArtTitulo"
        Me.lblCodArtTitulo.Size = New System.Drawing.Size(368, 33)
        Me.lblCodArtTitulo.TabIndex = 109
        Me.lblCodArtTitulo.Text = " Artículo:"
        Me.lblCodArtTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkVerInhabilitados
        '
        Me.chkVerInhabilitados.AutoSize = True
        Me.chkVerInhabilitados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkVerInhabilitados.Location = New System.Drawing.Point(21, 80)
        Me.chkVerInhabilitados.Name = "chkVerInhabilitados"
        Me.chkVerInhabilitados.Size = New System.Drawing.Size(127, 20)
        Me.chkVerInhabilitados.TabIndex = 110
        Me.chkVerInhabilitados.Text = "Ver Inhabilitados"
        Me.chkVerInhabilitados.UseVisualStyleBackColor = True
        '
        'cmdImprimir
        '
        Me.cmdImprimir.Enabled = False
        Me.cmdImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdImprimir.Location = New System.Drawing.Point(427, 100)
        Me.cmdImprimir.Name = "cmdImprimir"
        Me.cmdImprimir.Size = New System.Drawing.Size(76, 41)
        Me.cmdImprimir.TabIndex = 111
        Me.cmdImprimir.Text = "Imprimir"
        Me.cmdImprimir.UseVisualStyleBackColor = True
        '
        'pdoImpresion
        '
        '
        'gbArmadoArticulo
        '
        Me.gbArmadoArticulo.Controls.Add(Me.lblCostoTotalTareas)
        Me.gbArmadoArticulo.Controls.Add(Me.lblTitCostoTareas)
        Me.gbArmadoArticulo.Controls.Add(Me.lblCostoTotalCelda)
        Me.gbArmadoArticulo.Controls.Add(Me.lblTitCostoCelda)
        Me.gbArmadoArticulo.Controls.Add(Me.lblCantPersonas)
        Me.gbArmadoArticulo.Controls.Add(Me.lblTitCantPersonas)
        Me.gbArmadoArticulo.Controls.Add(Me.lblFechaHasta)
        Me.gbArmadoArticulo.Controls.Add(Me.lblTitFechaHasta)
        Me.gbArmadoArticulo.Controls.Add(Me.lblNroCelda)
        Me.gbArmadoArticulo.Controls.Add(Me.lblTitNroCelda)
        Me.gbArmadoArticulo.Controls.Add(Me.Label3)
        Me.gbArmadoArticulo.Controls.Add(Me.Label2)
        Me.gbArmadoArticulo.Controls.Add(Me.dgvTareasArt)
        Me.gbArmadoArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbArmadoArticulo.Location = New System.Drawing.Point(921, 187)
        Me.gbArmadoArticulo.Name = "gbArmadoArticulo"
        Me.gbArmadoArticulo.Size = New System.Drawing.Size(260, 502)
        Me.gbArmadoArticulo.TabIndex = 112
        Me.gbArmadoArticulo.TabStop = False
        Me.gbArmadoArticulo.Text = "Armado del Artículo"
        '
        'lblCostoTotalTareas
        '
        Me.lblCostoTotalTareas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoTotalTareas.Location = New System.Drawing.Point(124, 296)
        Me.lblCostoTotalTareas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCostoTotalTareas.Name = "lblCostoTotalTareas"
        Me.lblCostoTotalTareas.Size = New System.Drawing.Size(108, 22)
        Me.lblCostoTotalTareas.TabIndex = 138
        Me.lblCostoTotalTareas.Text = "0.00"
        Me.lblCostoTotalTareas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitCostoTareas
        '
        Me.lblTitCostoTareas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitCostoTareas.Location = New System.Drawing.Point(9, 296)
        Me.lblTitCostoTareas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitCostoTareas.Name = "lblTitCostoTareas"
        Me.lblTitCostoTareas.Size = New System.Drawing.Size(117, 22)
        Me.lblTitCostoTareas.TabIndex = 137
        Me.lblTitCostoTareas.Text = "Costo Total Tareas:"
        Me.lblTitCostoTareas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCostoTotalCelda
        '
        Me.lblCostoTotalCelda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoTotalCelda.Location = New System.Drawing.Point(123, 457)
        Me.lblCostoTotalCelda.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCostoTotalCelda.Name = "lblCostoTotalCelda"
        Me.lblCostoTotalCelda.Size = New System.Drawing.Size(108, 22)
        Me.lblCostoTotalCelda.TabIndex = 136
        Me.lblCostoTotalCelda.Text = "0.00"
        Me.lblCostoTotalCelda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitCostoCelda
        '
        Me.lblTitCostoCelda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitCostoCelda.Location = New System.Drawing.Point(8, 457)
        Me.lblTitCostoCelda.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitCostoCelda.Name = "lblTitCostoCelda"
        Me.lblTitCostoCelda.Size = New System.Drawing.Size(108, 22)
        Me.lblTitCostoCelda.TabIndex = 135
        Me.lblTitCostoCelda.Text = "Costo Total Celda:"
        Me.lblTitCostoCelda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCantPersonas
        '
        Me.lblCantPersonas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantPersonas.Location = New System.Drawing.Point(124, 422)
        Me.lblCantPersonas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCantPersonas.Name = "lblCantPersonas"
        Me.lblCantPersonas.Size = New System.Drawing.Size(86, 22)
        Me.lblCantPersonas.TabIndex = 134
        Me.lblCantPersonas.Text = "0"
        Me.lblCantPersonas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitCantPersonas
        '
        Me.lblTitCantPersonas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitCantPersonas.Location = New System.Drawing.Point(8, 422)
        Me.lblTitCantPersonas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitCantPersonas.Name = "lblTitCantPersonas"
        Me.lblTitCantPersonas.Size = New System.Drawing.Size(108, 22)
        Me.lblTitCantPersonas.TabIndex = 133
        Me.lblTitCantPersonas.Text = "Cant Personas:"
        Me.lblTitCantPersonas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFechaHasta
        '
        Me.lblFechaHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaHasta.Location = New System.Drawing.Point(123, 387)
        Me.lblFechaHasta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFechaHasta.Name = "lblFechaHasta"
        Me.lblFechaHasta.Size = New System.Drawing.Size(86, 22)
        Me.lblFechaHasta.TabIndex = 132
        Me.lblFechaHasta.Text = "dd/mm/yyyy"
        Me.lblFechaHasta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitFechaHasta
        '
        Me.lblTitFechaHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitFechaHasta.Location = New System.Drawing.Point(7, 387)
        Me.lblTitFechaHasta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitFechaHasta.Name = "lblTitFechaHasta"
        Me.lblTitFechaHasta.Size = New System.Drawing.Size(108, 22)
        Me.lblTitFechaHasta.TabIndex = 131
        Me.lblTitFechaHasta.Text = "Fecha Hasta:"
        Me.lblTitFechaHasta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNroCelda
        '
        Me.lblNroCelda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNroCelda.Location = New System.Drawing.Point(123, 354)
        Me.lblNroCelda.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNroCelda.Name = "lblNroCelda"
        Me.lblNroCelda.Size = New System.Drawing.Size(39, 22)
        Me.lblNroCelda.TabIndex = 130
        Me.lblNroCelda.Text = "00"
        Me.lblNroCelda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitNroCelda
        '
        Me.lblTitNroCelda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitNroCelda.Location = New System.Drawing.Point(7, 354)
        Me.lblTitNroCelda.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitNroCelda.Name = "lblTitNroCelda"
        Me.lblTitNroCelda.Size = New System.Drawing.Size(108, 22)
        Me.lblTitNroCelda.TabIndex = 129
        Me.lblTitNroCelda.Text = "Número Celda:"
        Me.lblTitNroCelda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 329)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(246, 22)
        Me.Label3.TabIndex = 128
        Me.Label3.Text = "CELDA"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 26)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(246, 22)
        Me.Label2.TabIndex = 127
        Me.Label2.Text = "TAREAS PRODUCCIÓN"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvTareasArt
        '
        Me.dgvTareasArt.AllowUserToAddRows = False
        Me.dgvTareasArt.AllowUserToDeleteRows = False
        Me.dgvTareasArt.AllowUserToResizeColumns = False
        Me.dgvTareasArt.AllowUserToResizeRows = False
        Me.dgvTareasArt.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvTareasArt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTareasArt.Location = New System.Drawing.Point(6, 51)
        Me.dgvTareasArt.Name = "dgvTareasArt"
        Me.dgvTareasArt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTareasArt.Size = New System.Drawing.Size(247, 242)
        Me.dgvTareasArt.TabIndex = 9
        '
        'btnVerArmado
        '
        Me.btnVerArmado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerArmado.Location = New System.Drawing.Point(694, 112)
        Me.btnVerArmado.Name = "btnVerArmado"
        Me.btnVerArmado.Size = New System.Drawing.Size(142, 29)
        Me.btnVerArmado.TabIndex = 113
        Me.btnVerArmado.Text = "Ver Tareas Armado"
        Me.btnVerArmado.UseVisualStyleBackColor = True
        '
        'cmbHilados
        '
        Me.cmbHilados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHilados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbHilados.FormattingEnabled = True
        Me.cmbHilados.Location = New System.Drawing.Point(109, 46)
        Me.cmbHilados.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbHilados.Name = "cmbHilados"
        Me.cmbHilados.Size = New System.Drawing.Size(217, 21)
        Me.cmbHilados.TabIndex = 115
        '
        'lblTipoHilado
        '
        Me.lblTipoHilado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoHilado.Location = New System.Drawing.Point(8, 46)
        Me.lblTipoHilado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTipoHilado.Name = "lblTipoHilado"
        Me.lblTipoHilado.Size = New System.Drawing.Size(93, 22)
        Me.lblTipoHilado.TabIndex = 114
        Me.lblTipoHilado.Text = "Tipo Hilado:"
        Me.lblTipoHilado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnVerCalculo
        '
        Me.btnVerCalculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerCalculo.Location = New System.Drawing.Point(547, 147)
        Me.btnVerCalculo.Name = "btnVerCalculo"
        Me.btnVerCalculo.Size = New System.Drawing.Size(131, 29)
        Me.btnVerCalculo.TabIndex = 116
        Me.btnVerCalculo.Text = "Ver Cálculo Costo"
        Me.btnVerCalculo.UseVisualStyleBackColor = True
        '
        'gbCalculo
        '
        Me.gbCalculo.Controls.Add(Me.PanelCostoTejeduriaRESTO)
        Me.gbCalculo.Controls.Add(Me.PanelCostoTejeduriaCORTE)
        Me.gbCalculo.Controls.Add(Me.lblCostoTeñido)
        Me.gbCalculo.Controls.Add(Me.lblCostoTotal)
        Me.gbCalculo.Controls.Add(Me.lblCostosIndirectos)
        Me.gbCalculo.Controls.Add(Me.lblCostoMateriales)
        Me.gbCalculo.Controls.Add(Me.lblCostoHilado)
        Me.gbCalculo.Controls.Add(Me.lblCostoKiloHilado)
        Me.gbCalculo.Controls.Add(Me.lblSAC)
        Me.gbCalculo.Controls.Add(Me.lblCargasSociales)
        Me.gbCalculo.Controls.Add(Me.lblPresentismo)
        Me.gbCalculo.Controls.Add(Me.lblValorHoraMO)
        Me.gbCalculo.Controls.Add(Me.lblCostoManoObraConCargasSociales)
        Me.gbCalculo.Controls.Add(Me.lblCostoArmadoConCargasSociales)
        Me.gbCalculo.Controls.Add(Me.lblCostoArmado)
        Me.gbCalculo.Controls.Add(Me.Label1)
        Me.gbCalculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCalculo.Location = New System.Drawing.Point(193, 187)
        Me.gbCalculo.Name = "gbCalculo"
        Me.gbCalculo.Size = New System.Drawing.Size(384, 624)
        Me.gbCalculo.TabIndex = 117
        Me.gbCalculo.TabStop = False
        Me.gbCalculo.Text = "Cálculo del Costo del Artículo"
        '
        'PanelCostoTejeduriaRESTO
        '
        Me.PanelCostoTejeduriaRESTO.Controls.Add(Me.lblCostoMOdelArticulo)
        Me.PanelCostoTejeduriaRESTO.Controls.Add(Me.lblTitCostoMOdelArticulo)
        Me.PanelCostoTejeduriaRESTO.Controls.Add(Me.lblCostoPorMinutoPorPrenda)
        Me.PanelCostoTejeduriaRESTO.Controls.Add(Me.lblTitCostoPorMinutoPorPrenda)
        Me.PanelCostoTejeduriaRESTO.Controls.Add(Me.lblCostoPorMinutoTejeduria)
        Me.PanelCostoTejeduriaRESTO.Controls.Add(Me.lblTitCostoPorMinutoTejeduria)
        Me.PanelCostoTejeduriaRESTO.Controls.Add(Me.lblCantHorasDelMes)
        Me.PanelCostoTejeduriaRESTO.Controls.Add(Me.lblTitCantHorasDelMes)
        Me.PanelCostoTejeduriaRESTO.Controls.Add(Me.lblCantMaquinasTejeduria)
        Me.PanelCostoTejeduriaRESTO.Controls.Add(Me.lblTitCantMaquinasTejeduria)
        Me.PanelCostoTejeduriaRESTO.Controls.Add(Me.lblTotalSueldosTejeduria)
        Me.PanelCostoTejeduriaRESTO.Controls.Add(Me.lblTitTotalSueldosTejeduria)
        Me.PanelCostoTejeduriaRESTO.Controls.Add(Me.lblCantPersonasTejeduria)
        Me.PanelCostoTejeduriaRESTO.Controls.Add(Me.lblTitCantPersonasTejeduria)
        Me.PanelCostoTejeduriaRESTO.Controls.Add(Me.lblSemanasConfTejeduria)
        Me.PanelCostoTejeduriaRESTO.Controls.Add(Me.lblTitSemanasConfTejeduria)
        Me.PanelCostoTejeduriaRESTO.Controls.Add(Me.lblCantMinutosArticulo)
        Me.PanelCostoTejeduriaRESTO.Controls.Add(Me.lblTitCantMinutosArticulo)
        Me.PanelCostoTejeduriaRESTO.Location = New System.Drawing.Point(7, 137)
        Me.PanelCostoTejeduriaRESTO.Name = "PanelCostoTejeduriaRESTO"
        Me.PanelCostoTejeduriaRESTO.Size = New System.Drawing.Size(370, 248)
        Me.PanelCostoTejeduriaRESTO.TabIndex = 141
        '
        'lblCostoMOdelArticulo
        '
        Me.lblCostoMOdelArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoMOdelArticulo.Location = New System.Drawing.Point(256, 204)
        Me.lblCostoMOdelArticulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCostoMOdelArticulo.Name = "lblCostoMOdelArticulo"
        Me.lblCostoMOdelArticulo.Size = New System.Drawing.Size(99, 22)
        Me.lblCostoMOdelArticulo.TabIndex = 140
        Me.lblCostoMOdelArticulo.Text = "0"
        Me.lblCostoMOdelArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitCostoMOdelArticulo
        '
        Me.lblTitCostoMOdelArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitCostoMOdelArticulo.Location = New System.Drawing.Point(3, 204)
        Me.lblTitCostoMOdelArticulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitCostoMOdelArticulo.Name = "lblTitCostoMOdelArticulo"
        Me.lblTitCostoMOdelArticulo.Size = New System.Drawing.Size(248, 22)
        Me.lblTitCostoMOdelArticulo.TabIndex = 139
        Me.lblTitCostoMOdelArticulo.Text = "Costo MO del Artículo:"
        Me.lblTitCostoMOdelArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCostoPorMinutoPorPrenda
        '
        Me.lblCostoPorMinutoPorPrenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoPorMinutoPorPrenda.Location = New System.Drawing.Point(256, 152)
        Me.lblCostoPorMinutoPorPrenda.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCostoPorMinutoPorPrenda.Name = "lblCostoPorMinutoPorPrenda"
        Me.lblCostoPorMinutoPorPrenda.Size = New System.Drawing.Size(99, 22)
        Me.lblCostoPorMinutoPorPrenda.TabIndex = 138
        Me.lblCostoPorMinutoPorPrenda.Text = "0"
        Me.lblCostoPorMinutoPorPrenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitCostoPorMinutoPorPrenda
        '
        Me.lblTitCostoPorMinutoPorPrenda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitCostoPorMinutoPorPrenda.Location = New System.Drawing.Point(3, 152)
        Me.lblTitCostoPorMinutoPorPrenda.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitCostoPorMinutoPorPrenda.Name = "lblTitCostoPorMinutoPorPrenda"
        Me.lblTitCostoPorMinutoPorPrenda.Size = New System.Drawing.Size(248, 22)
        Me.lblTitCostoPorMinutoPorPrenda.TabIndex = 137
        Me.lblTitCostoPorMinutoPorPrenda.Text = "Costo por minuto por prenda:"
        Me.lblTitCostoPorMinutoPorPrenda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCostoPorMinutoTejeduria
        '
        Me.lblCostoPorMinutoTejeduria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoPorMinutoTejeduria.Location = New System.Drawing.Point(259, 123)
        Me.lblCostoPorMinutoTejeduria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCostoPorMinutoTejeduria.Name = "lblCostoPorMinutoTejeduria"
        Me.lblCostoPorMinutoTejeduria.Size = New System.Drawing.Size(96, 22)
        Me.lblCostoPorMinutoTejeduria.TabIndex = 136
        Me.lblCostoPorMinutoTejeduria.Text = "0"
        Me.lblCostoPorMinutoTejeduria.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitCostoPorMinutoTejeduria
        '
        Me.lblTitCostoPorMinutoTejeduria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitCostoPorMinutoTejeduria.Location = New System.Drawing.Point(3, 123)
        Me.lblTitCostoPorMinutoTejeduria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitCostoPorMinutoTejeduria.Name = "lblTitCostoPorMinutoTejeduria"
        Me.lblTitCostoPorMinutoTejeduria.Size = New System.Drawing.Size(248, 22)
        Me.lblTitCostoPorMinutoTejeduria.TabIndex = 135
        Me.lblTitCostoPorMinutoTejeduria.Text = "$ por minuto de Tejeduría"
        Me.lblTitCostoPorMinutoTejeduria.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCantHorasDelMes
        '
        Me.lblCantHorasDelMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantHorasDelMes.Location = New System.Drawing.Point(256, 99)
        Me.lblCantHorasDelMes.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCantHorasDelMes.Name = "lblCantHorasDelMes"
        Me.lblCantHorasDelMes.Size = New System.Drawing.Size(99, 22)
        Me.lblCantHorasDelMes.TabIndex = 134
        Me.lblCantHorasDelMes.Text = "0"
        Me.lblCantHorasDelMes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitCantHorasDelMes
        '
        Me.lblTitCantHorasDelMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitCantHorasDelMes.Location = New System.Drawing.Point(3, 99)
        Me.lblTitCantHorasDelMes.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitCantHorasDelMes.Name = "lblTitCantHorasDelMes"
        Me.lblTitCantHorasDelMes.Size = New System.Drawing.Size(248, 22)
        Me.lblTitCantHorasDelMes.TabIndex = 133
        Me.lblTitCantHorasDelMes.Text = "Cantidad Horas del mes:"
        Me.lblTitCantHorasDelMes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCantMaquinasTejeduria
        '
        Me.lblCantMaquinasTejeduria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantMaquinasTejeduria.Location = New System.Drawing.Point(256, 76)
        Me.lblCantMaquinasTejeduria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCantMaquinasTejeduria.Name = "lblCantMaquinasTejeduria"
        Me.lblCantMaquinasTejeduria.Size = New System.Drawing.Size(99, 22)
        Me.lblCantMaquinasTejeduria.TabIndex = 132
        Me.lblCantMaquinasTejeduria.Text = "0"
        Me.lblCantMaquinasTejeduria.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitCantMaquinasTejeduria
        '
        Me.lblTitCantMaquinasTejeduria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitCantMaquinasTejeduria.Location = New System.Drawing.Point(3, 76)
        Me.lblTitCantMaquinasTejeduria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitCantMaquinasTejeduria.Name = "lblTitCantMaquinasTejeduria"
        Me.lblTitCantMaquinasTejeduria.Size = New System.Drawing.Size(248, 22)
        Me.lblTitCantMaquinasTejeduria.TabIndex = 131
        Me.lblTitCantMaquinasTejeduria.Text = "Cantidad Máquinas Tejeduría:"
        Me.lblTitCantMaquinasTejeduria.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalSueldosTejeduria
        '
        Me.lblTotalSueldosTejeduria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSueldosTejeduria.Location = New System.Drawing.Point(256, 51)
        Me.lblTotalSueldosTejeduria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalSueldosTejeduria.Name = "lblTotalSueldosTejeduria"
        Me.lblTotalSueldosTejeduria.Size = New System.Drawing.Size(99, 22)
        Me.lblTotalSueldosTejeduria.TabIndex = 130
        Me.lblTotalSueldosTejeduria.Text = "0"
        Me.lblTotalSueldosTejeduria.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitTotalSueldosTejeduria
        '
        Me.lblTitTotalSueldosTejeduria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitTotalSueldosTejeduria.Location = New System.Drawing.Point(3, 51)
        Me.lblTitTotalSueldosTejeduria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitTotalSueldosTejeduria.Name = "lblTitTotalSueldosTejeduria"
        Me.lblTitTotalSueldosTejeduria.Size = New System.Drawing.Size(248, 22)
        Me.lblTitTotalSueldosTejeduria.TabIndex = 129
        Me.lblTitTotalSueldosTejeduria.Text = "Total Sueldos Tejeduria:"
        Me.lblTitTotalSueldosTejeduria.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCantPersonasTejeduria
        '
        Me.lblCantPersonasTejeduria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantPersonasTejeduria.Location = New System.Drawing.Point(256, 27)
        Me.lblCantPersonasTejeduria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCantPersonasTejeduria.Name = "lblCantPersonasTejeduria"
        Me.lblCantPersonasTejeduria.Size = New System.Drawing.Size(99, 22)
        Me.lblCantPersonasTejeduria.TabIndex = 128
        Me.lblCantPersonasTejeduria.Text = "0"
        Me.lblCantPersonasTejeduria.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitCantPersonasTejeduria
        '
        Me.lblTitCantPersonasTejeduria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitCantPersonasTejeduria.Location = New System.Drawing.Point(4, 27)
        Me.lblTitCantPersonasTejeduria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitCantPersonasTejeduria.Name = "lblTitCantPersonasTejeduria"
        Me.lblTitCantPersonasTejeduria.Size = New System.Drawing.Size(247, 22)
        Me.lblTitCantPersonasTejeduria.TabIndex = 127
        Me.lblTitCantPersonasTejeduria.Text = "Cantidad de Personas Tejeduria:"
        Me.lblTitCantPersonasTejeduria.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSemanasConfTejeduria
        '
        Me.lblSemanasConfTejeduria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSemanasConfTejeduria.Location = New System.Drawing.Point(253, 5)
        Me.lblSemanasConfTejeduria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSemanasConfTejeduria.Name = "lblSemanasConfTejeduria"
        Me.lblSemanasConfTejeduria.Size = New System.Drawing.Size(102, 22)
        Me.lblSemanasConfTejeduria.TabIndex = 126
        Me.lblSemanasConfTejeduria.Text = "Sem Conf Tej:"
        Me.lblSemanasConfTejeduria.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitSemanasConfTejeduria
        '
        Me.lblTitSemanasConfTejeduria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitSemanasConfTejeduria.Location = New System.Drawing.Point(4, 5)
        Me.lblTitSemanasConfTejeduria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitSemanasConfTejeduria.Name = "lblTitSemanasConfTejeduria"
        Me.lblTitSemanasConfTejeduria.Size = New System.Drawing.Size(247, 22)
        Me.lblTitSemanasConfTejeduria.TabIndex = 125
        Me.lblTitSemanasConfTejeduria.Text = "Semanas Config Tejeduría:"
        Me.lblTitSemanasConfTejeduria.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCantMinutosArticulo
        '
        Me.lblCantMinutosArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantMinutosArticulo.Location = New System.Drawing.Point(256, 178)
        Me.lblCantMinutosArticulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCantMinutosArticulo.Name = "lblCantMinutosArticulo"
        Me.lblCantMinutosArticulo.Size = New System.Drawing.Size(99, 22)
        Me.lblCantMinutosArticulo.TabIndex = 124
        Me.lblCantMinutosArticulo.Text = "0"
        Me.lblCantMinutosArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitCantMinutosArticulo
        '
        Me.lblTitCantMinutosArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitCantMinutosArticulo.Location = New System.Drawing.Point(3, 178)
        Me.lblTitCantMinutosArticulo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitCantMinutosArticulo.Name = "lblTitCantMinutosArticulo"
        Me.lblTitCantMinutosArticulo.Size = New System.Drawing.Size(248, 22)
        Me.lblTitCantMinutosArticulo.TabIndex = 123
        Me.lblTitCantMinutosArticulo.Text = "Minutos del Artículo:"
        Me.lblTitCantMinutosArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PanelCostoTejeduriaCORTE
        '
        Me.PanelCostoTejeduriaCORTE.Controls.Add(Me.lblCantMaqPorTejedor)
        Me.PanelCostoTejeduriaCORTE.Controls.Add(Me.lblPesoRolloHilado)
        Me.PanelCostoTejeduriaCORTE.Controls.Add(Me.lblRollosMaqTurno)
        Me.PanelCostoTejeduriaCORTE.Controls.Add(Me.lblRollosPorHora)
        Me.PanelCostoTejeduriaCORTE.Controls.Add(Me.lblKilosPorHora)
        Me.PanelCostoTejeduriaCORTE.Controls.Add(Me.lblAuxRollosPorHora)
        Me.PanelCostoTejeduriaCORTE.Controls.Add(Me.lblAuxKilosPorHora)
        Me.PanelCostoTejeduriaCORTE.Controls.Add(Me.lblAuxCostoMO)
        Me.PanelCostoTejeduriaCORTE.Controls.Add(Me.lblPesosPorKiloMO)
        Me.PanelCostoTejeduriaCORTE.Controls.Add(Me.lblAuxPesosPorKiloMO)
        Me.PanelCostoTejeduriaCORTE.Controls.Add(Me.lblCostoManoObra)
        Me.PanelCostoTejeduriaCORTE.Location = New System.Drawing.Point(353, 80)
        Me.PanelCostoTejeduriaCORTE.Name = "PanelCostoTejeduriaCORTE"
        Me.PanelCostoTejeduriaCORTE.Size = New System.Drawing.Size(370, 178)
        Me.PanelCostoTejeduriaCORTE.TabIndex = 140
        '
        'lblCantMaqPorTejedor
        '
        Me.lblCantMaqPorTejedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantMaqPorTejedor.Location = New System.Drawing.Point(12, 10)
        Me.lblCantMaqPorTejedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCantMaqPorTejedor.Name = "lblCantMaqPorTejedor"
        Me.lblCantMaqPorTejedor.Size = New System.Drawing.Size(164, 22)
        Me.lblCantMaqPorTejedor.TabIndex = 115
        Me.lblCantMaqPorTejedor.Text = "Maq. por Tejedor:"
        Me.lblCantMaqPorTejedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPesoRolloHilado
        '
        Me.lblPesoRolloHilado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPesoRolloHilado.Location = New System.Drawing.Point(12, 77)
        Me.lblPesoRolloHilado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPesoRolloHilado.Name = "lblPesoRolloHilado"
        Me.lblPesoRolloHilado.Size = New System.Drawing.Size(164, 22)
        Me.lblPesoRolloHilado.TabIndex = 118
        Me.lblPesoRolloHilado.Text = "Peso Rollo Hilado:"
        Me.lblPesoRolloHilado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRollosMaqTurno
        '
        Me.lblRollosMaqTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRollosMaqTurno.Location = New System.Drawing.Point(12, 32)
        Me.lblRollosMaqTurno.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRollosMaqTurno.Name = "lblRollosMaqTurno"
        Me.lblRollosMaqTurno.Size = New System.Drawing.Size(164, 22)
        Me.lblRollosMaqTurno.TabIndex = 119
        Me.lblRollosMaqTurno.Text = "Rollos por Maq. / Turno:"
        Me.lblRollosMaqTurno.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRollosPorHora
        '
        Me.lblRollosPorHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRollosPorHora.Location = New System.Drawing.Point(12, 55)
        Me.lblRollosPorHora.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRollosPorHora.Name = "lblRollosPorHora"
        Me.lblRollosPorHora.Size = New System.Drawing.Size(164, 22)
        Me.lblRollosPorHora.TabIndex = 120
        Me.lblRollosPorHora.Text = "Rollos por Hora:"
        Me.lblRollosPorHora.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblKilosPorHora
        '
        Me.lblKilosPorHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKilosPorHora.Location = New System.Drawing.Point(12, 99)
        Me.lblKilosPorHora.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblKilosPorHora.Name = "lblKilosPorHora"
        Me.lblKilosPorHora.Size = New System.Drawing.Size(164, 22)
        Me.lblKilosPorHora.TabIndex = 121
        Me.lblKilosPorHora.Text = "Kilos por Hora:"
        Me.lblKilosPorHora.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAuxRollosPorHora
        '
        Me.lblAuxRollosPorHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAuxRollosPorHora.Location = New System.Drawing.Point(184, 60)
        Me.lblAuxRollosPorHora.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAuxRollosPorHora.Name = "lblAuxRollosPorHora"
        Me.lblAuxRollosPorHora.Size = New System.Drawing.Size(135, 15)
        Me.lblAuxRollosPorHora.TabIndex = 122
        Me.lblAuxRollosPorHora.Text = "()"
        Me.lblAuxRollosPorHora.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAuxKilosPorHora
        '
        Me.lblAuxKilosPorHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAuxKilosPorHora.Location = New System.Drawing.Point(184, 104)
        Me.lblAuxKilosPorHora.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAuxKilosPorHora.Name = "lblAuxKilosPorHora"
        Me.lblAuxKilosPorHora.Size = New System.Drawing.Size(134, 15)
        Me.lblAuxKilosPorHora.TabIndex = 123
        Me.lblAuxKilosPorHora.Text = "()"
        Me.lblAuxKilosPorHora.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAuxCostoMO
        '
        Me.lblAuxCostoMO.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAuxCostoMO.Location = New System.Drawing.Point(184, 157)
        Me.lblAuxCostoMO.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAuxCostoMO.Name = "lblAuxCostoMO"
        Me.lblAuxCostoMO.Size = New System.Drawing.Size(134, 15)
        Me.lblAuxCostoMO.TabIndex = 133
        Me.lblAuxCostoMO.Text = "()"
        Me.lblAuxCostoMO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPesosPorKiloMO
        '
        Me.lblPesosPorKiloMO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPesosPorKiloMO.Location = New System.Drawing.Point(12, 121)
        Me.lblPesosPorKiloMO.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPesosPorKiloMO.Name = "lblPesosPorKiloMO"
        Me.lblPesosPorKiloMO.Size = New System.Drawing.Size(164, 22)
        Me.lblPesosPorKiloMO.TabIndex = 124
        Me.lblPesosPorKiloMO.Text = "$ por Kilo (MO):"
        Me.lblPesosPorKiloMO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAuxPesosPorKiloMO
        '
        Me.lblAuxPesosPorKiloMO.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAuxPesosPorKiloMO.Location = New System.Drawing.Point(184, 126)
        Me.lblAuxPesosPorKiloMO.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAuxPesosPorKiloMO.Name = "lblAuxPesosPorKiloMO"
        Me.lblAuxPesosPorKiloMO.Size = New System.Drawing.Size(134, 15)
        Me.lblAuxPesosPorKiloMO.TabIndex = 125
        Me.lblAuxPesosPorKiloMO.Text = "()"
        Me.lblAuxPesosPorKiloMO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCostoManoObra
        '
        Me.lblCostoManoObra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoManoObra.Location = New System.Drawing.Point(15, 152)
        Me.lblCostoManoObra.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCostoManoObra.Name = "lblCostoManoObra"
        Me.lblCostoManoObra.Size = New System.Drawing.Size(161, 22)
        Me.lblCostoManoObra.TabIndex = 126
        Me.lblCostoManoObra.Text = "COSTO MO:"
        Me.lblCostoManoObra.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCostoTeñido
        '
        Me.lblCostoTeñido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCostoTeñido.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoTeñido.Location = New System.Drawing.Point(7, 482)
        Me.lblCostoTeñido.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCostoTeñido.Name = "lblCostoTeñido"
        Me.lblCostoTeñido.Size = New System.Drawing.Size(370, 22)
        Me.lblCostoTeñido.TabIndex = 139
        Me.lblCostoTeñido.Text = "COSTO TEÑIDO:"
        Me.lblCostoTeñido.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCostoTotal
        '
        Me.lblCostoTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCostoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoTotal.Location = New System.Drawing.Point(7, 594)
        Me.lblCostoTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCostoTotal.Name = "lblCostoTotal"
        Me.lblCostoTotal.Size = New System.Drawing.Size(370, 22)
        Me.lblCostoTotal.TabIndex = 138
        Me.lblCostoTotal.Text = "TOTAL:"
        Me.lblCostoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCostosIndirectos
        '
        Me.lblCostosIndirectos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCostosIndirectos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostosIndirectos.Location = New System.Drawing.Point(7, 560)
        Me.lblCostosIndirectos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCostosIndirectos.Name = "lblCostosIndirectos"
        Me.lblCostosIndirectos.Size = New System.Drawing.Size(370, 22)
        Me.lblCostosIndirectos.TabIndex = 137
        Me.lblCostosIndirectos.Text = "COSTOS INDIRECTOS DE FABRICACIÓN:"
        Me.lblCostosIndirectos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCostoMateriales
        '
        Me.lblCostoMateriales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCostoMateriales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoMateriales.Location = New System.Drawing.Point(7, 521)
        Me.lblCostoMateriales.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCostoMateriales.Name = "lblCostoMateriales"
        Me.lblCostoMateriales.Size = New System.Drawing.Size(370, 22)
        Me.lblCostoMateriales.TabIndex = 136
        Me.lblCostoMateriales.Text = "COSTO MATERIALES:"
        Me.lblCostoMateriales.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCostoHilado
        '
        Me.lblCostoHilado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCostoHilado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoHilado.Location = New System.Drawing.Point(7, 442)
        Me.lblCostoHilado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCostoHilado.Name = "lblCostoHilado"
        Me.lblCostoHilado.Size = New System.Drawing.Size(370, 22)
        Me.lblCostoHilado.TabIndex = 135
        Me.lblCostoHilado.Text = "COSTO HILADO:"
        Me.lblCostoHilado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCostoKiloHilado
        '
        Me.lblCostoKiloHilado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoKiloHilado.Location = New System.Drawing.Point(8, 420)
        Me.lblCostoKiloHilado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCostoKiloHilado.Name = "lblCostoKiloHilado"
        Me.lblCostoKiloHilado.Size = New System.Drawing.Size(164, 22)
        Me.lblCostoKiloHilado.TabIndex = 134
        Me.lblCostoKiloHilado.Text = "$ por Kilo HILADO:"
        Me.lblCostoKiloHilado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSAC
        '
        Me.lblSAC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSAC.Location = New System.Drawing.Point(260, 47)
        Me.lblSAC.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSAC.Name = "lblSAC"
        Me.lblSAC.Size = New System.Drawing.Size(75, 22)
        Me.lblSAC.TabIndex = 131
        Me.lblSAC.Text = "SAC:"
        Me.lblSAC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCargasSociales
        '
        Me.lblCargasSociales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCargasSociales.Location = New System.Drawing.Point(142, 47)
        Me.lblCargasSociales.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCargasSociales.Name = "lblCargasSociales"
        Me.lblCargasSociales.Size = New System.Drawing.Size(110, 22)
        Me.lblCargasSociales.TabIndex = 130
        Me.lblCargasSociales.Text = "C.Sociales:"
        Me.lblCargasSociales.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPresentismo
        '
        Me.lblPresentismo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPresentismo.Location = New System.Drawing.Point(21, 47)
        Me.lblPresentismo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPresentismo.Name = "lblPresentismo"
        Me.lblPresentismo.Size = New System.Drawing.Size(121, 22)
        Me.lblPresentismo.TabIndex = 129
        Me.lblPresentismo.Text = "Presentismo:"
        Me.lblPresentismo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblValorHoraMO
        '
        Me.lblValorHoraMO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValorHoraMO.Location = New System.Drawing.Point(18, 24)
        Me.lblValorHoraMO.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblValorHoraMO.Name = "lblValorHoraMO"
        Me.lblValorHoraMO.Size = New System.Drawing.Size(124, 22)
        Me.lblValorHoraMO.TabIndex = 128
        Me.lblValorHoraMO.Text = "Valor Hora MO:"
        Me.lblValorHoraMO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCostoManoObraConCargasSociales
        '
        Me.lblCostoManoObraConCargasSociales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCostoManoObraConCargasSociales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoManoObraConCargasSociales.Location = New System.Drawing.Point(7, 388)
        Me.lblCostoManoObraConCargasSociales.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCostoManoObraConCargasSociales.Name = "lblCostoManoObraConCargasSociales"
        Me.lblCostoManoObraConCargasSociales.Size = New System.Drawing.Size(370, 22)
        Me.lblCostoManoObraConCargasSociales.TabIndex = 127
        Me.lblCostoManoObraConCargasSociales.Text = "COSTO MO + CS:"
        Me.lblCostoManoObraConCargasSociales.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCostoArmadoConCargasSociales
        '
        Me.lblCostoArmadoConCargasSociales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCostoArmadoConCargasSociales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoArmadoConCargasSociales.Location = New System.Drawing.Point(7, 112)
        Me.lblCostoArmadoConCargasSociales.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCostoArmadoConCargasSociales.Name = "lblCostoArmadoConCargasSociales"
        Me.lblCostoArmadoConCargasSociales.Size = New System.Drawing.Size(370, 22)
        Me.lblCostoArmadoConCargasSociales.TabIndex = 117
        Me.lblCostoArmadoConCargasSociales.Text = "COSTO ARMADO + CS:"
        Me.lblCostoArmadoConCargasSociales.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCostoArmado
        '
        Me.lblCostoArmado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoArmado.Location = New System.Drawing.Point(11, 90)
        Me.lblCostoArmado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCostoArmado.Name = "lblCostoArmado"
        Me.lblCostoArmado.Size = New System.Drawing.Size(161, 22)
        Me.lblCostoArmado.TabIndex = 116
        Me.lblCostoArmado.Text = "COSTO ARMADO:"
        Me.lblCostoArmado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 72)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(366, 4)
        Me.Label1.TabIndex = 132
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbPROD
        '
        Me.cmbPROD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPROD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPROD.FormattingEnabled = True
        Me.cmbPROD.Location = New System.Drawing.Point(79, 14)
        Me.cmbPROD.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPROD.Name = "cmbPROD"
        Me.cmbPROD.Size = New System.Drawing.Size(108, 21)
        Me.cmbPROD.TabIndex = 119
        '
        'lblPROD
        '
        Me.lblPROD.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPROD.Location = New System.Drawing.Point(13, 14)
        Me.lblPROD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPROD.Name = "lblPROD"
        Me.lblPROD.Size = New System.Drawing.Size(58, 22)
        Me.lblPROD.TabIndex = 118
        Me.lblPROD.Text = "PROD:"
        Me.lblPROD.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbTipoLisoSublimado
        '
        Me.cmbTipoLisoSublimado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoLisoSublimado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoLisoSublimado.FormattingEnabled = True
        Me.cmbTipoLisoSublimado.Location = New System.Drawing.Point(288, 14)
        Me.cmbTipoLisoSublimado.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbTipoLisoSublimado.Name = "cmbTipoLisoSublimado"
        Me.cmbTipoLisoSublimado.Size = New System.Drawing.Size(132, 21)
        Me.cmbTipoLisoSublimado.TabIndex = 121
        '
        'lblTipoLisoSublimado
        '
        Me.lblTipoLisoSublimado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoLisoSublimado.Location = New System.Drawing.Point(219, 13)
        Me.lblTipoLisoSublimado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTipoLisoSublimado.Name = "lblTipoLisoSublimado"
        Me.lblTipoLisoSublimado.Size = New System.Drawing.Size(61, 22)
        Me.lblTipoLisoSublimado.TabIndex = 120
        Me.lblTipoLisoSublimado.Text = "Tipo:"
        Me.lblTipoLisoSublimado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvSueldosTejeduria
        '
        Me.dgvSueldosTejeduria.AllowUserToAddRows = False
        Me.dgvSueldosTejeduria.AllowUserToDeleteRows = False
        Me.dgvSueldosTejeduria.AllowUserToResizeColumns = False
        Me.dgvSueldosTejeduria.AllowUserToResizeRows = False
        Me.dgvSueldosTejeduria.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvSueldosTejeduria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSueldosTejeduria.Location = New System.Drawing.Point(899, 95)
        Me.dgvSueldosTejeduria.Name = "dgvSueldosTejeduria"
        Me.dgvSueldosTejeduria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSueldosTejeduria.Size = New System.Drawing.Size(236, 62)
        Me.dgvSueldosTejeduria.TabIndex = 122
        '
        'btnVerCostosIndirectos
        '
        Me.btnVerCostosIndirectos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerCostosIndirectos.Location = New System.Drawing.Point(694, 147)
        Me.btnVerCostosIndirectos.Name = "btnVerCostosIndirectos"
        Me.btnVerCostosIndirectos.Size = New System.Drawing.Size(156, 29)
        Me.btnVerCostosIndirectos.TabIndex = 123
        Me.btnVerCostosIndirectos.Text = "Ver Costos Indirectos"
        Me.btnVerCostosIndirectos.UseVisualStyleBackColor = True
        '
        'gbCostosIndirectos
        '
        Me.gbCostosIndirectos.Controls.Add(Me.lblCalculoCIPrendaCortada)
        Me.gbCostosIndirectos.Controls.Add(Me.lblCalculoCIPrendaTejida)
        Me.gbCostosIndirectos.Controls.Add(Me.lblCostoGastoIndirectoPorPrendaCorte)
        Me.gbCostosIndirectos.Controls.Add(Me.Label17)
        Me.gbCostosIndirectos.Controls.Add(Me.lblPorcionConfRestoPlantayEtapa2)
        Me.gbCostosIndirectos.Controls.Add(Me.lblTitPorcentajeConfRestoPlantayEtapa2)
        Me.gbCostosIndirectos.Controls.Add(Me.lblPorcionConfTejeduriayEtapa2)
        Me.gbCostosIndirectos.Controls.Add(Me.lblTitPorcentajeConfTejeduriayEtapa2)
        Me.gbCostosIndirectos.Controls.Add(Me.lblPorcionRestoPlanta)
        Me.gbCostosIndirectos.Controls.Add(Me.lblTitPorcentajeRestoPlanta)
        Me.gbCostosIndirectos.Controls.Add(Me.lblPorcionTejeduria)
        Me.gbCostosIndirectos.Controls.Add(Me.lblTitPorcentajeTejeduria)
        Me.gbCostosIndirectos.Controls.Add(Me.lblTotalPrendasProducidas)
        Me.gbCostosIndirectos.Controls.Add(Me.lblTitTotalPrendasProducidas)
        Me.gbCostosIndirectos.Controls.Add(Me.lblTotalPrendasCortadas)
        Me.gbCostosIndirectos.Controls.Add(Me.lblTitTotalPrendasCortadas)
        Me.gbCostosIndirectos.Controls.Add(Me.lblTotalPrendasTejidas)
        Me.gbCostosIndirectos.Controls.Add(Me.lblTitTotalPrendasTejidas)
        Me.gbCostosIndirectos.Controls.Add(Me.Label4)
        Me.gbCostosIndirectos.Controls.Add(Me.lblTotalGastosIndirectos)
        Me.gbCostosIndirectos.Controls.Add(Me.lblTitTotalGastosIndirectos)
        Me.gbCostosIndirectos.Controls.Add(Me.lblTotalCostosRubros)
        Me.gbCostosIndirectos.Controls.Add(Me.lblTitTotalCastosRubros)
        Me.gbCostosIndirectos.Controls.Add(Me.lblTotalSueldosOperativosMasCargas)
        Me.gbCostosIndirectos.Controls.Add(Me.lblTitTotalSueldosOperativosConCargas)
        Me.gbCostosIndirectos.Controls.Add(Me.lblTotalSueldosOperativos)
        Me.gbCostosIndirectos.Controls.Add(Me.lblTitTotalSueldosOperativos)
        Me.gbCostosIndirectos.Controls.Add(Me.lblGastoSueldosDptoMantLavEncAyud)
        Me.gbCostosIndirectos.Controls.Add(Me.Label13)
        Me.gbCostosIndirectos.Controls.Add(Me.lblGastoSueldosSupGerDiseProg)
        Me.gbCostosIndirectos.Controls.Add(Me.Label12)
        Me.gbCostosIndirectos.Controls.Add(Me.lblTotalCostosOperativos)
        Me.gbCostosIndirectos.Controls.Add(Me.lblGastoSeguridadVigilancia)
        Me.gbCostosIndirectos.Controls.Add(Me.Label11)
        Me.gbCostosIndirectos.Controls.Add(Me.lblGastoAtencionMedica)
        Me.gbCostosIndirectos.Controls.Add(Me.Label10)
        Me.gbCostosIndirectos.Controls.Add(Me.lblGastoEfluentesIndustriales)
        Me.gbCostosIndirectos.Controls.Add(Me.Label9)
        Me.gbCostosIndirectos.Controls.Add(Me.lblGastoTasaServSanitarios)
        Me.gbCostosIndirectos.Controls.Add(Me.Label8)
        Me.gbCostosIndirectos.Controls.Add(Me.lblGastoImpYTasasVarios)
        Me.gbCostosIndirectos.Controls.Add(Me.Label7)
        Me.gbCostosIndirectos.Controls.Add(Me.lblGastoTasaAlumbrado)
        Me.gbCostosIndirectos.Controls.Add(Me.Label6)
        Me.gbCostosIndirectos.Controls.Add(Me.lblGastoGas)
        Me.gbCostosIndirectos.Controls.Add(Me.Label5)
        Me.gbCostosIndirectos.Controls.Add(Me.lblGastoLuz)
        Me.gbCostosIndirectos.Controls.Add(Me.lblCostoGastoIndirectoPorPrendaTejida)
        Me.gbCostosIndirectos.Controls.Add(Me.Label38)
        Me.gbCostosIndirectos.Controls.Add(Me.lblTitTotalCostosOperativos)
        Me.gbCostosIndirectos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCostosIndirectos.Location = New System.Drawing.Point(79, 179)
        Me.gbCostosIndirectos.Name = "gbCostosIndirectos"
        Me.gbCostosIndirectos.Size = New System.Drawing.Size(389, 624)
        Me.gbCostosIndirectos.TabIndex = 124
        Me.gbCostosIndirectos.TabStop = False
        Me.gbCostosIndirectos.Text = "Cálculo del Costo Indirectos de Fabricación"
        '
        'lblPorcionRestoPlanta
        '
        Me.lblPorcionRestoPlanta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorcionRestoPlanta.Location = New System.Drawing.Point(256, 369)
        Me.lblPorcionRestoPlanta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPorcionRestoPlanta.Name = "lblPorcionRestoPlanta"
        Me.lblPorcionRestoPlanta.Size = New System.Drawing.Size(88, 22)
        Me.lblPorcionRestoPlanta.TabIndex = 178
        Me.lblPorcionRestoPlanta.Text = "2812377.84"
        Me.lblPorcionRestoPlanta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitPorcentajeRestoPlanta
        '
        Me.lblTitPorcentajeRestoPlanta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitPorcentajeRestoPlanta.Location = New System.Drawing.Point(7, 369)
        Me.lblTitPorcentajeRestoPlanta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitPorcentajeRestoPlanta.Name = "lblTitPorcentajeRestoPlanta"
        Me.lblTitPorcentajeRestoPlanta.Size = New System.Drawing.Size(237, 22)
        Me.lblTitPorcentajeRestoPlanta.TabIndex = 177
        Me.lblTitPorcentajeRestoPlanta.Text = "PORCENTAJE RESTO DE LA PLANTA (40%):"
        Me.lblTitPorcentajeRestoPlanta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPorcionTejeduria
        '
        Me.lblPorcionTejeduria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorcionTejeduria.Location = New System.Drawing.Point(256, 348)
        Me.lblPorcionTejeduria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPorcionTejeduria.Name = "lblPorcionTejeduria"
        Me.lblPorcionTejeduria.Size = New System.Drawing.Size(88, 22)
        Me.lblPorcionTejeduria.TabIndex = 176
        Me.lblPorcionTejeduria.Text = "751261.60"
        Me.lblPorcionTejeduria.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitPorcentajeTejeduria
        '
        Me.lblTitPorcentajeTejeduria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitPorcentajeTejeduria.Location = New System.Drawing.Point(8, 348)
        Me.lblTitPorcentajeTejeduria.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitPorcentajeTejeduria.Name = "lblTitPorcentajeTejeduria"
        Me.lblTitPorcentajeTejeduria.Size = New System.Drawing.Size(237, 22)
        Me.lblTitPorcentajeTejeduria.TabIndex = 175
        Me.lblTitPorcentajeTejeduria.Text = "PORCENTAJE SECTOR TEJEDURIA (60%):"
        Me.lblTitPorcentajeTejeduria.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalPrendasProducidas
        '
        Me.lblTotalPrendasProducidas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalPrendasProducidas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPrendasProducidas.Location = New System.Drawing.Point(255, 468)
        Me.lblTotalPrendasProducidas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalPrendasProducidas.Name = "lblTotalPrendasProducidas"
        Me.lblTotalPrendasProducidas.Size = New System.Drawing.Size(88, 22)
        Me.lblTotalPrendasProducidas.TabIndex = 174
        Me.lblTotalPrendasProducidas.Text = "98400"
        Me.lblTotalPrendasProducidas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitTotalPrendasProducidas
        '
        Me.lblTitTotalPrendasProducidas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitTotalPrendasProducidas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitTotalPrendasProducidas.Location = New System.Drawing.Point(7, 468)
        Me.lblTitTotalPrendasProducidas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitTotalPrendasProducidas.Name = "lblTitTotalPrendasProducidas"
        Me.lblTitTotalPrendasProducidas.Size = New System.Drawing.Size(237, 22)
        Me.lblTitTotalPrendasProducidas.TabIndex = 173
        Me.lblTitTotalPrendasProducidas.Text = "TOTAL PRENDAS PRODUCIDAS:"
        Me.lblTitTotalPrendasProducidas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalPrendasCortadas
        '
        Me.lblTotalPrendasCortadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPrendasCortadas.Location = New System.Drawing.Point(252, 447)
        Me.lblTotalPrendasCortadas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalPrendasCortadas.Name = "lblTotalPrendasCortadas"
        Me.lblTotalPrendasCortadas.Size = New System.Drawing.Size(91, 22)
        Me.lblTotalPrendasCortadas.TabIndex = 172
        Me.lblTotalPrendasCortadas.Text = "40000"
        Me.lblTotalPrendasCortadas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitTotalPrendasCortadas
        '
        Me.lblTitTotalPrendasCortadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitTotalPrendasCortadas.Location = New System.Drawing.Point(7, 447)
        Me.lblTitTotalPrendasCortadas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitTotalPrendasCortadas.Name = "lblTitTotalPrendasCortadas"
        Me.lblTitTotalPrendasCortadas.Size = New System.Drawing.Size(237, 22)
        Me.lblTitTotalPrendasCortadas.TabIndex = 171
        Me.lblTitTotalPrendasCortadas.Text = "TOTAL PRENDAS CORTADAS:"
        Me.lblTitTotalPrendasCortadas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalPrendasTejidas
        '
        Me.lblTotalPrendasTejidas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPrendasTejidas.Location = New System.Drawing.Point(255, 428)
        Me.lblTotalPrendasTejidas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalPrendasTejidas.Name = "lblTotalPrendasTejidas"
        Me.lblTotalPrendasTejidas.Size = New System.Drawing.Size(88, 22)
        Me.lblTotalPrendasTejidas.TabIndex = 170
        Me.lblTotalPrendasTejidas.Text = "58400"
        Me.lblTotalPrendasTejidas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitTotalPrendasTejidas
        '
        Me.lblTitTotalPrendasTejidas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitTotalPrendasTejidas.Location = New System.Drawing.Point(7, 428)
        Me.lblTitTotalPrendasTejidas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitTotalPrendasTejidas.Name = "lblTitTotalPrendasTejidas"
        Me.lblTitTotalPrendasTejidas.Size = New System.Drawing.Size(237, 22)
        Me.lblTitTotalPrendasTejidas.TabIndex = 169
        Me.lblTitTotalPrendasTejidas.Text = "TOTAL PRENDAS TEJIDAS:"
        Me.lblTitTotalPrendasTejidas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 315)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(350, 4)
        Me.Label4.TabIndex = 168
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalGastosIndirectos
        '
        Me.lblTotalGastosIndirectos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalGastosIndirectos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalGastosIndirectos.Location = New System.Drawing.Point(255, 325)
        Me.lblTotalGastosIndirectos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalGastosIndirectos.Name = "lblTotalGastosIndirectos"
        Me.lblTotalGastosIndirectos.Size = New System.Drawing.Size(88, 22)
        Me.lblTotalGastosIndirectos.TabIndex = 167
        Me.lblTotalGastosIndirectos.Text = "0.00"
        Me.lblTotalGastosIndirectos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitTotalGastosIndirectos
        '
        Me.lblTitTotalGastosIndirectos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitTotalGastosIndirectos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitTotalGastosIndirectos.Location = New System.Drawing.Point(7, 325)
        Me.lblTitTotalGastosIndirectos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitTotalGastosIndirectos.Name = "lblTitTotalGastosIndirectos"
        Me.lblTitTotalGastosIndirectos.Size = New System.Drawing.Size(237, 22)
        Me.lblTitTotalGastosIndirectos.TabIndex = 166
        Me.lblTitTotalGastosIndirectos.Text = "TOTAL GASTOS:"
        Me.lblTitTotalGastosIndirectos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalCostosRubros
        '
        Me.lblTotalCostosRubros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalCostosRubros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCostosRubros.Location = New System.Drawing.Point(255, 286)
        Me.lblTotalCostosRubros.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalCostosRubros.Name = "lblTotalCostosRubros"
        Me.lblTotalCostosRubros.Size = New System.Drawing.Size(88, 22)
        Me.lblTotalCostosRubros.TabIndex = 165
        Me.lblTotalCostosRubros.Text = "0.00"
        Me.lblTotalCostosRubros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitTotalCastosRubros
        '
        Me.lblTitTotalCastosRubros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitTotalCastosRubros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitTotalCastosRubros.Location = New System.Drawing.Point(7, 286)
        Me.lblTitTotalCastosRubros.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitTotalCastosRubros.Name = "lblTitTotalCastosRubros"
        Me.lblTitTotalCastosRubros.Size = New System.Drawing.Size(237, 22)
        Me.lblTitTotalCastosRubros.TabIndex = 164
        Me.lblTitTotalCastosRubros.Text = "TOTAL GASTOS RUBROS:"
        Me.lblTitTotalCastosRubros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalSueldosOperativosMasCargas
        '
        Me.lblTotalSueldosOperativosMasCargas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalSueldosOperativosMasCargas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSueldosOperativosMasCargas.Location = New System.Drawing.Point(255, 258)
        Me.lblTotalSueldosOperativosMasCargas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalSueldosOperativosMasCargas.Name = "lblTotalSueldosOperativosMasCargas"
        Me.lblTotalSueldosOperativosMasCargas.Size = New System.Drawing.Size(88, 22)
        Me.lblTotalSueldosOperativosMasCargas.TabIndex = 163
        Me.lblTotalSueldosOperativosMasCargas.Text = "5793251.62"
        Me.lblTotalSueldosOperativosMasCargas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitTotalSueldosOperativosConCargas
        '
        Me.lblTitTotalSueldosOperativosConCargas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitTotalSueldosOperativosConCargas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitTotalSueldosOperativosConCargas.Location = New System.Drawing.Point(7, 258)
        Me.lblTitTotalSueldosOperativosConCargas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitTotalSueldosOperativosConCargas.Name = "lblTitTotalSueldosOperativosConCargas"
        Me.lblTitTotalSueldosOperativosConCargas.Size = New System.Drawing.Size(237, 22)
        Me.lblTitTotalSueldosOperativosConCargas.TabIndex = 162
        Me.lblTitTotalSueldosOperativosConCargas.Text = "TOTAL SUELDOS + CS:"
        Me.lblTitTotalSueldosOperativosConCargas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalSueldosOperativos
        '
        Me.lblTotalSueldosOperativos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalSueldosOperativos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalSueldosOperativos.Location = New System.Drawing.Point(255, 234)
        Me.lblTotalSueldosOperativos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalSueldosOperativos.Name = "lblTotalSueldosOperativos"
        Me.lblTotalSueldosOperativos.Size = New System.Drawing.Size(88, 22)
        Me.lblTotalSueldosOperativos.TabIndex = 161
        Me.lblTotalSueldosOperativos.Text = "3623158.15"
        Me.lblTotalSueldosOperativos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitTotalSueldosOperativos
        '
        Me.lblTitTotalSueldosOperativos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitTotalSueldosOperativos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitTotalSueldosOperativos.Location = New System.Drawing.Point(7, 234)
        Me.lblTitTotalSueldosOperativos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitTotalSueldosOperativos.Name = "lblTitTotalSueldosOperativos"
        Me.lblTitTotalSueldosOperativos.Size = New System.Drawing.Size(237, 22)
        Me.lblTitTotalSueldosOperativos.TabIndex = 160
        Me.lblTitTotalSueldosOperativos.Text = "TOTAL SUELDOS:"
        Me.lblTitTotalSueldosOperativos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGastoSueldosDptoMantLavEncAyud
        '
        Me.lblGastoSueldosDptoMantLavEncAyud.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGastoSueldosDptoMantLavEncAyud.Location = New System.Drawing.Point(252, 213)
        Me.lblGastoSueldosDptoMantLavEncAyud.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGastoSueldosDptoMantLavEncAyud.Name = "lblGastoSueldosDptoMantLavEncAyud"
        Me.lblGastoSueldosDptoMantLavEncAyud.Size = New System.Drawing.Size(91, 22)
        Me.lblGastoSueldosDptoMantLavEncAyud.TabIndex = 159
        Me.lblGastoSueldosDptoMantLavEncAyud.Text = "2812377.84"
        Me.lblGastoSueldosDptoMantLavEncAyud.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(7, 213)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(237, 22)
        Me.Label13.TabIndex = 158
        Me.Label13.Text = "SUELDOS MANT/DPTO/LAV/AYUD/ENC:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGastoSueldosSupGerDiseProg
        '
        Me.lblGastoSueldosSupGerDiseProg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGastoSueldosSupGerDiseProg.Location = New System.Drawing.Point(255, 195)
        Me.lblGastoSueldosSupGerDiseProg.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGastoSueldosSupGerDiseProg.Name = "lblGastoSueldosSupGerDiseProg"
        Me.lblGastoSueldosSupGerDiseProg.Size = New System.Drawing.Size(88, 22)
        Me.lblGastoSueldosSupGerDiseProg.TabIndex = 157
        Me.lblGastoSueldosSupGerDiseProg.Text = "751261.60"
        Me.lblGastoSueldosSupGerDiseProg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(7, 195)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(237, 22)
        Me.Label12.TabIndex = 156
        Me.Label12.Text = "SUELDOS GER/SUP/DISEÑO/PROG:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalCostosOperativos
        '
        Me.lblTotalCostosOperativos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalCostosOperativos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCostosOperativos.Location = New System.Drawing.Point(255, 170)
        Me.lblTotalCostosOperativos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalCostosOperativos.Name = "lblTotalCostosOperativos"
        Me.lblTotalCostosOperativos.Size = New System.Drawing.Size(88, 22)
        Me.lblTotalCostosOperativos.TabIndex = 155
        Me.lblTotalCostosOperativos.Text = "913808.32"
        Me.lblTotalCostosOperativos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGastoSeguridadVigilancia
        '
        Me.lblGastoSeguridadVigilancia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGastoSeguridadVigilancia.Location = New System.Drawing.Point(255, 146)
        Me.lblGastoSeguridadVigilancia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGastoSeguridadVigilancia.Name = "lblGastoSeguridadVigilancia"
        Me.lblGastoSeguridadVigilancia.Size = New System.Drawing.Size(88, 22)
        Me.lblGastoSeguridadVigilancia.TabIndex = 154
        Me.lblGastoSeguridadVigilancia.Text = "92640.00"
        Me.lblGastoSeguridadVigilancia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(7, 146)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(237, 22)
        Me.Label11.TabIndex = 153
        Me.Label11.Text = "70040 - SEGURIDAD Y VIGILANCIA:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGastoAtencionMedica
        '
        Me.lblGastoAtencionMedica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGastoAtencionMedica.Location = New System.Drawing.Point(255, 128)
        Me.lblGastoAtencionMedica.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGastoAtencionMedica.Name = "lblGastoAtencionMedica"
        Me.lblGastoAtencionMedica.Size = New System.Drawing.Size(88, 22)
        Me.lblGastoAtencionMedica.TabIndex = 152
        Me.lblGastoAtencionMedica.Text = "23542.94"
        Me.lblGastoAtencionMedica.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 128)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(237, 22)
        Me.Label10.TabIndex = 151
        Me.Label10.Text = "80104 - ATENCIÓN MÉDICA:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGastoEfluentesIndustriales
        '
        Me.lblGastoEfluentesIndustriales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGastoEfluentesIndustriales.Location = New System.Drawing.Point(255, 110)
        Me.lblGastoEfluentesIndustriales.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGastoEfluentesIndustriales.Name = "lblGastoEfluentesIndustriales"
        Me.lblGastoEfluentesIndustriales.Size = New System.Drawing.Size(88, 22)
        Me.lblGastoEfluentesIndustriales.TabIndex = 150
        Me.lblGastoEfluentesIndustriales.Text = "3626.04"
        Me.lblGastoEfluentesIndustriales.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 110)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(237, 22)
        Me.Label9.TabIndex = 149
        Me.Label9.Text = "70034 - TASA EFLUENTES INDUSTR:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGastoTasaServSanitarios
        '
        Me.lblGastoTasaServSanitarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGastoTasaServSanitarios.Location = New System.Drawing.Point(255, 92)
        Me.lblGastoTasaServSanitarios.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGastoTasaServSanitarios.Name = "lblGastoTasaServSanitarios"
        Me.lblGastoTasaServSanitarios.Size = New System.Drawing.Size(88, 22)
        Me.lblGastoTasaServSanitarios.TabIndex = 148
        Me.lblGastoTasaServSanitarios.Text = "145825.02"
        Me.lblGastoTasaServSanitarios.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 92)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(237, 22)
        Me.Label8.TabIndex = 147
        Me.Label8.Text = "70033 - TASA SERV. SANITARIOS:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGastoImpYTasasVarios
        '
        Me.lblGastoImpYTasasVarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGastoImpYTasasVarios.Location = New System.Drawing.Point(255, 74)
        Me.lblGastoImpYTasasVarios.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGastoImpYTasasVarios.Name = "lblGastoImpYTasasVarios"
        Me.lblGastoImpYTasasVarios.Size = New System.Drawing.Size(88, 22)
        Me.lblGastoImpYTasasVarios.TabIndex = 146
        Me.lblGastoImpYTasasVarios.Text = "127.00"
        Me.lblGastoImpYTasasVarios.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 74)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(237, 22)
        Me.Label7.TabIndex = 145
        Me.Label7.Text = "70038 - IMP. Y TASAS VARIOS:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGastoTasaAlumbrado
        '
        Me.lblGastoTasaAlumbrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGastoTasaAlumbrado.Location = New System.Drawing.Point(255, 56)
        Me.lblGastoTasaAlumbrado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGastoTasaAlumbrado.Name = "lblGastoTasaAlumbrado"
        Me.lblGastoTasaAlumbrado.Size = New System.Drawing.Size(88, 22)
        Me.lblGastoTasaAlumbrado.TabIndex = 144
        Me.lblGastoTasaAlumbrado.Text = "10075.06"
        Me.lblGastoTasaAlumbrado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 56)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(237, 22)
        Me.Label6.TabIndex = 143
        Me.Label6.Text = "70032 - TASA ALUMB. BARRIDO:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGastoGas
        '
        Me.lblGastoGas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGastoGas.Location = New System.Drawing.Point(255, 38)
        Me.lblGastoGas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGastoGas.Name = "lblGastoGas"
        Me.lblGastoGas.Size = New System.Drawing.Size(88, 22)
        Me.lblGastoGas.TabIndex = 142
        Me.lblGastoGas.Text = "327595.11"
        Me.lblGastoGas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 38)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(237, 22)
        Me.Label5.TabIndex = 141
        Me.Label5.Text = "70011 - GAS:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGastoLuz
        '
        Me.lblGastoLuz.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGastoLuz.Location = New System.Drawing.Point(255, 20)
        Me.lblGastoLuz.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGastoLuz.Name = "lblGastoLuz"
        Me.lblGastoLuz.Size = New System.Drawing.Size(88, 22)
        Me.lblGastoLuz.TabIndex = 140
        Me.lblGastoLuz.Text = "310377.15"
        Me.lblGastoLuz.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCostoGastoIndirectoPorPrendaTejida
        '
        Me.lblCostoGastoIndirectoPorPrendaTejida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCostoGastoIndirectoPorPrendaTejida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoGastoIndirectoPorPrendaTejida.Location = New System.Drawing.Point(7, 519)
        Me.lblCostoGastoIndirectoPorPrendaTejida.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCostoGastoIndirectoPorPrendaTejida.Name = "lblCostoGastoIndirectoPorPrendaTejida"
        Me.lblCostoGastoIndirectoPorPrendaTejida.Size = New System.Drawing.Size(339, 22)
        Me.lblCostoGastoIndirectoPorPrendaTejida.TabIndex = 138
        Me.lblCostoGastoIndirectoPorPrendaTejida.Text = "COSTO INDIRECTO POR PRENDA TEJIDA:"
        Me.lblCostoGastoIndirectoPorPrendaTejida.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label38
        '
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(7, 20)
        Me.Label38.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(237, 22)
        Me.Label38.TabIndex = 134
        Me.Label38.Text = "70010 - LUZ:"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitTotalCostosOperativos
        '
        Me.lblTitTotalCostosOperativos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitTotalCostosOperativos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitTotalCostosOperativos.Location = New System.Drawing.Point(7, 170)
        Me.lblTitTotalCostosOperativos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitTotalCostosOperativos.Name = "lblTitTotalCostosOperativos"
        Me.lblTitTotalCostosOperativos.Size = New System.Drawing.Size(237, 22)
        Me.lblTitTotalCostosOperativos.TabIndex = 117
        Me.lblTitTotalCostosOperativos.Text = "TOTAL COSTOS OPERATIVOS:"
        Me.lblTitTotalCostosOperativos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbRecuperoSueldosTeje
        '
        Me.gbRecuperoSueldosTeje.Controls.Add(Me.btnRecuperarExcelCargasSociales)
        Me.gbRecuperoSueldosTeje.Controls.Add(Me.lblUltimoRecuperoExcelCargasSociales)
        Me.gbRecuperoSueldosTeje.Location = New System.Drawing.Point(529, -4)
        Me.gbRecuperoSueldosTeje.Name = "gbRecuperoSueldosTeje"
        Me.gbRecuperoSueldosTeje.Size = New System.Drawing.Size(394, 40)
        Me.gbRecuperoSueldosTeje.TabIndex = 125
        Me.gbRecuperoSueldosTeje.TabStop = False
        '
        'btnRecuperarExcelCargasSociales
        '
        Me.btnRecuperarExcelCargasSociales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecuperarExcelCargasSociales.Location = New System.Drawing.Point(261, 10)
        Me.btnRecuperarExcelCargasSociales.Name = "btnRecuperarExcelCargasSociales"
        Me.btnRecuperarExcelCargasSociales.Size = New System.Drawing.Size(116, 26)
        Me.btnRecuperarExcelCargasSociales.TabIndex = 145
        Me.btnRecuperarExcelCargasSociales.Text = "Recuperar"
        Me.btnRecuperarExcelCargasSociales.UseVisualStyleBackColor = True
        '
        'lblUltimoRecuperoExcelCargasSociales
        '
        Me.lblUltimoRecuperoExcelCargasSociales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltimoRecuperoExcelCargasSociales.Location = New System.Drawing.Point(8, 11)
        Me.lblUltimoRecuperoExcelCargasSociales.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUltimoRecuperoExcelCargasSociales.Name = "lblUltimoRecuperoExcelCargasSociales"
        Me.lblUltimoRecuperoExcelCargasSociales.Size = New System.Drawing.Size(253, 22)
        Me.lblUltimoRecuperoExcelCargasSociales.TabIndex = 144
        Me.lblUltimoRecuperoExcelCargasSociales.Text = "Último Recupero Excel Cargas Sociales:"
        Me.lblUltimoRecuperoExcelCargasSociales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbParametrosCosto
        '
        Me.gbParametrosCosto.Controls.Add(Me.txtParamCantPrendasCortadas)
        Me.gbParametrosCosto.Controls.Add(Me.lblParamCantPrendasCortadas)
        Me.gbParametrosCosto.Controls.Add(Me.btnRecalcularCostos)
        Me.gbParametrosCosto.Controls.Add(Me.txtParamCantPrendasTejidas)
        Me.gbParametrosCosto.Controls.Add(Me.lblParamCantPrendastejidas)
        Me.gbParametrosCosto.Location = New System.Drawing.Point(529, 49)
        Me.gbParametrosCosto.Name = "gbParametrosCosto"
        Me.gbParametrosCosto.Size = New System.Drawing.Size(606, 46)
        Me.gbParametrosCosto.TabIndex = 126
        Me.gbParametrosCosto.TabStop = False
        Me.gbParametrosCosto.Text = "Parámetros para el cálculo del Costo"
        '
        'txtParamCantPrendasCortadas
        '
        Me.txtParamCantPrendasCortadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParamCantPrendasCortadas.Location = New System.Drawing.Point(321, 20)
        Me.txtParamCantPrendasCortadas.Name = "txtParamCantPrendasCortadas"
        Me.txtParamCantPrendasCortadas.Size = New System.Drawing.Size(72, 22)
        Me.txtParamCantPrendasCortadas.TabIndex = 149
        Me.txtParamCantPrendasCortadas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblParamCantPrendasCortadas
        '
        Me.lblParamCantPrendasCortadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParamCantPrendasCortadas.Location = New System.Drawing.Point(203, 21)
        Me.lblParamCantPrendasCortadas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblParamCantPrendasCortadas.Name = "lblParamCantPrendasCortadas"
        Me.lblParamCantPrendasCortadas.Size = New System.Drawing.Size(122, 22)
        Me.lblParamCantPrendasCortadas.TabIndex = 148
        Me.lblParamCantPrendasCortadas.Text = "Cant Prendas Cortadas:"
        Me.lblParamCantPrendasCortadas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnRecalcularCostos
        '
        Me.btnRecalcularCostos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRecalcularCostos.Location = New System.Drawing.Point(436, 14)
        Me.btnRecalcularCostos.Name = "btnRecalcularCostos"
        Me.btnRecalcularCostos.Size = New System.Drawing.Size(142, 26)
        Me.btnRecalcularCostos.TabIndex = 147
        Me.btnRecalcularCostos.Text = "Recalcular Costos"
        Me.btnRecalcularCostos.UseVisualStyleBackColor = True
        '
        'txtParamCantPrendasTejidas
        '
        Me.txtParamCantPrendasTejidas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParamCantPrendasTejidas.Location = New System.Drawing.Point(122, 20)
        Me.txtParamCantPrendasTejidas.Name = "txtParamCantPrendasTejidas"
        Me.txtParamCantPrendasTejidas.Size = New System.Drawing.Size(72, 22)
        Me.txtParamCantPrendasTejidas.TabIndex = 146
        Me.txtParamCantPrendasTejidas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblParamCantPrendastejidas
        '
        Me.lblParamCantPrendastejidas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParamCantPrendastejidas.Location = New System.Drawing.Point(7, 21)
        Me.lblParamCantPrendastejidas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblParamCantPrendastejidas.Name = "lblParamCantPrendastejidas"
        Me.lblParamCantPrendastejidas.Size = New System.Drawing.Size(122, 22)
        Me.lblParamCantPrendastejidas.TabIndex = 145
        Me.lblParamCantPrendastejidas.Text = "Cant Prendas Tejidas:"
        Me.lblParamCantPrendastejidas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnVerColSinCS
        '
        Me.btnVerColSinCS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerColSinCS.Location = New System.Drawing.Point(547, 112)
        Me.btnVerColSinCS.Name = "btnVerColSinCS"
        Me.btnVerColSinCS.Size = New System.Drawing.Size(131, 29)
        Me.btnVerColSinCS.TabIndex = 127
        Me.btnVerColSinCS.Text = "Ver Col Sin C/S"
        Me.btnVerColSinCS.UseVisualStyleBackColor = True
        '
        'gbCalculoCostoRubros
        '
        Me.gbCalculoCostoRubros.Controls.Add(Me.lblCostoRubroMensualEnPesos)
        Me.gbCalculoCostoRubros.Controls.Add(Me.lblTitCostoRubroMensualEnPesos)
        Me.gbCalculoCostoRubros.Controls.Add(Me.Label15)
        Me.gbCalculoCostoRubros.Controls.Add(Me.Label16)
        Me.gbCalculoCostoRubros.Controls.Add(Me.lblCostoRubroCotizDolar)
        Me.gbCalculoCostoRubros.Controls.Add(Me.lblTitCostoRubroCotizDolar)
        Me.gbCalculoCostoRubros.Controls.Add(Me.lblCostoRubroTotalDolares)
        Me.gbCalculoCostoRubros.Controls.Add(Me.lblTitCostoRubroTotalDolares)
        Me.gbCalculoCostoRubros.Controls.Add(Me.Label14)
        Me.gbCalculoCostoRubros.Controls.Add(Me.dgvCostosRubros)
        Me.gbCalculoCostoRubros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCalculoCostoRubros.Location = New System.Drawing.Point(317, 160)
        Me.gbCalculoCostoRubros.Name = "gbCalculoCostoRubros"
        Me.gbCalculoCostoRubros.Size = New System.Drawing.Size(260, 623)
        Me.gbCalculoCostoRubros.TabIndex = 128
        Me.gbCalculoCostoRubros.TabStop = False
        Me.gbCalculoCostoRubros.Text = "Cálculo de Gastos por Rubros"
        '
        'lblCostoRubroMensualEnPesos
        '
        Me.lblCostoRubroMensualEnPesos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCostoRubroMensualEnPesos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoRubroMensualEnPesos.Location = New System.Drawing.Point(149, 503)
        Me.lblCostoRubroMensualEnPesos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCostoRubroMensualEnPesos.Name = "lblCostoRubroMensualEnPesos"
        Me.lblCostoRubroMensualEnPesos.Size = New System.Drawing.Size(88, 32)
        Me.lblCostoRubroMensualEnPesos.TabIndex = 169
        Me.lblCostoRubroMensualEnPesos.Text = "0.0"
        Me.lblCostoRubroMensualEnPesos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitCostoRubroMensualEnPesos
        '
        Me.lblTitCostoRubroMensualEnPesos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitCostoRubroMensualEnPesos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitCostoRubroMensualEnPesos.Location = New System.Drawing.Point(8, 503)
        Me.lblTitCostoRubroMensualEnPesos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitCostoRubroMensualEnPesos.Name = "lblTitCostoRubroMensualEnPesos"
        Me.lblTitCostoRubroMensualEnPesos.Size = New System.Drawing.Size(127, 32)
        Me.lblTitCostoRubroMensualEnPesos.TabIndex = 168
        Me.lblTitCostoRubroMensualEnPesos.Text = "COSTO MENSUAL EN $:"
        Me.lblTitCostoRubroMensualEnPesos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(143, 462)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 22)
        Me.Label15.TabIndex = 167
        Me.Label15.Text = "12"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(27, 462)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(108, 22)
        Me.Label16.TabIndex = 166
        Me.Label16.Text = "Meses:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCostoRubroCotizDolar
        '
        Me.lblCostoRubroCotizDolar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoRubroCotizDolar.Location = New System.Drawing.Point(143, 439)
        Me.lblCostoRubroCotizDolar.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCostoRubroCotizDolar.Name = "lblCostoRubroCotizDolar"
        Me.lblCostoRubroCotizDolar.Size = New System.Drawing.Size(39, 22)
        Me.lblCostoRubroCotizDolar.TabIndex = 165
        Me.lblCostoRubroCotizDolar.Text = "00"
        Me.lblCostoRubroCotizDolar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitCostoRubroCotizDolar
        '
        Me.lblTitCostoRubroCotizDolar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitCostoRubroCotizDolar.Location = New System.Drawing.Point(27, 439)
        Me.lblTitCostoRubroCotizDolar.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitCostoRubroCotizDolar.Name = "lblTitCostoRubroCotizDolar"
        Me.lblTitCostoRubroCotizDolar.Size = New System.Drawing.Size(108, 22)
        Me.lblTitCostoRubroCotizDolar.TabIndex = 164
        Me.lblTitCostoRubroCotizDolar.Text = "Cotización dolar:"
        Me.lblTitCostoRubroCotizDolar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCostoRubroTotalDolares
        '
        Me.lblCostoRubroTotalDolares.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCostoRubroTotalDolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoRubroTotalDolares.Location = New System.Drawing.Point(149, 402)
        Me.lblCostoRubroTotalDolares.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCostoRubroTotalDolares.Name = "lblCostoRubroTotalDolares"
        Me.lblCostoRubroTotalDolares.Size = New System.Drawing.Size(88, 22)
        Me.lblCostoRubroTotalDolares.TabIndex = 163
        Me.lblCostoRubroTotalDolares.Text = "0.0"
        Me.lblCostoRubroTotalDolares.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitCostoRubroTotalDolares
        '
        Me.lblTitCostoRubroTotalDolares.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitCostoRubroTotalDolares.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitCostoRubroTotalDolares.Location = New System.Drawing.Point(8, 402)
        Me.lblTitCostoRubroTotalDolares.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitCostoRubroTotalDolares.Name = "lblTitCostoRubroTotalDolares"
        Me.lblTitCostoRubroTotalDolares.Size = New System.Drawing.Size(127, 22)
        Me.lblTitCostoRubroTotalDolares.TabIndex = 162
        Me.lblTitCostoRubroTotalDolares.Text = "TOTAL U$S:"
        Me.lblTitCostoRubroTotalDolares.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(7, 30)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(246, 50)
        Me.Label14.TabIndex = 129
        Me.Label14.Text = "GASTOS MENSUALES DEL ÚLTIMO AÑO EN DOLARES"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvCostosRubros
        '
        Me.dgvCostosRubros.AllowUserToAddRows = False
        Me.dgvCostosRubros.AllowUserToDeleteRows = False
        Me.dgvCostosRubros.AllowUserToResizeColumns = False
        Me.dgvCostosRubros.AllowUserToResizeRows = False
        Me.dgvCostosRubros.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvCostosRubros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCostosRubros.Location = New System.Drawing.Point(6, 91)
        Me.dgvCostosRubros.Name = "dgvCostosRubros"
        Me.dgvCostosRubros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCostosRubros.Size = New System.Drawing.Size(247, 293)
        Me.dgvCostosRubros.TabIndex = 128
        '
        'btnVerCostosRubros
        '
        Me.btnVerCostosRubros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerCostosRubros.Location = New System.Drawing.Point(867, 147)
        Me.btnVerCostosRubros.Name = "btnVerCostosRubros"
        Me.btnVerCostosRubros.Size = New System.Drawing.Size(142, 29)
        Me.btnVerCostosRubros.TabIndex = 129
        Me.btnVerCostosRubros.Text = "Ver Costos Rubros"
        Me.btnVerCostosRubros.UseVisualStyleBackColor = True
        '
        'gbMaterialesArticulo
        '
        Me.gbMaterialesArticulo.Controls.Add(Me.lblCostoCierres)
        Me.gbMaterialesArticulo.Controls.Add(Me.lblTitCostoCierres)
        Me.gbMaterialesArticulo.Controls.Add(Me.lblCostoBotones)
        Me.gbMaterialesArticulo.Controls.Add(Me.lblTitCostoBotones)
        Me.gbMaterialesArticulo.Controls.Add(Me.lblTotalMateriales)
        Me.gbMaterialesArticulo.Controls.Add(Me.lblTitTotalMateriales)
        Me.gbMaterialesArticulo.Controls.Add(Me.lblCantidadDeCierres)
        Me.gbMaterialesArticulo.Controls.Add(Me.lblTitCantidadDeCierres)
        Me.gbMaterialesArticulo.Controls.Add(Me.lblCosto1Cierre)
        Me.gbMaterialesArticulo.Controls.Add(Me.lblTitCosto1Cierre)
        Me.gbMaterialesArticulo.Controls.Add(Me.lblCantidadDeBotones)
        Me.gbMaterialesArticulo.Controls.Add(Me.lblTitCantidadDeBotones)
        Me.gbMaterialesArticulo.Controls.Add(Me.lblCosto1Boton)
        Me.gbMaterialesArticulo.Controls.Add(Me.lblTitCosto1Boton)
        Me.gbMaterialesArticulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMaterialesArticulo.Location = New System.Drawing.Point(615, 189)
        Me.gbMaterialesArticulo.Name = "gbMaterialesArticulo"
        Me.gbMaterialesArticulo.Size = New System.Drawing.Size(260, 502)
        Me.gbMaterialesArticulo.TabIndex = 130
        Me.gbMaterialesArticulo.TabStop = False
        Me.gbMaterialesArticulo.Text = "Materiales del Artículo"
        '
        'lblCostoCierres
        '
        Me.lblCostoCierres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCostoCierres.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoCierres.Location = New System.Drawing.Point(175, 212)
        Me.lblCostoCierres.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCostoCierres.Name = "lblCostoCierres"
        Me.lblCostoCierres.Size = New System.Drawing.Size(65, 22)
        Me.lblCostoCierres.TabIndex = 175
        Me.lblCostoCierres.Text = "0.00"
        Me.lblCostoCierres.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitCostoCierres
        '
        Me.lblTitCostoCierres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitCostoCierres.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitCostoCierres.Location = New System.Drawing.Point(11, 212)
        Me.lblTitCostoCierres.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitCostoCierres.Name = "lblTitCostoCierres"
        Me.lblTitCostoCierres.Size = New System.Drawing.Size(155, 22)
        Me.lblTitCostoCierres.TabIndex = 174
        Me.lblTitCostoCierres.Text = "COSTO CIERRES:"
        Me.lblTitCostoCierres.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCostoBotones
        '
        Me.lblCostoBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCostoBotones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoBotones.Location = New System.Drawing.Point(174, 94)
        Me.lblCostoBotones.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCostoBotones.Name = "lblCostoBotones"
        Me.lblCostoBotones.Size = New System.Drawing.Size(65, 22)
        Me.lblCostoBotones.TabIndex = 173
        Me.lblCostoBotones.Text = "0.00"
        Me.lblCostoBotones.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitCostoBotones
        '
        Me.lblTitCostoBotones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitCostoBotones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitCostoBotones.Location = New System.Drawing.Point(10, 94)
        Me.lblTitCostoBotones.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitCostoBotones.Name = "lblTitCostoBotones"
        Me.lblTitCostoBotones.Size = New System.Drawing.Size(155, 22)
        Me.lblTitCostoBotones.TabIndex = 172
        Me.lblTitCostoBotones.Text = "COSTO BOTONES:"
        Me.lblTitCostoBotones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalMateriales
        '
        Me.lblTotalMateriales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalMateriales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalMateriales.Location = New System.Drawing.Point(174, 445)
        Me.lblTotalMateriales.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalMateriales.Name = "lblTotalMateriales"
        Me.lblTotalMateriales.Size = New System.Drawing.Size(75, 32)
        Me.lblTotalMateriales.TabIndex = 171
        Me.lblTotalMateriales.Text = "0.0"
        Me.lblTotalMateriales.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitTotalMateriales
        '
        Me.lblTitTotalMateriales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitTotalMateriales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitTotalMateriales.Location = New System.Drawing.Point(10, 445)
        Me.lblTitTotalMateriales.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitTotalMateriales.Name = "lblTitTotalMateriales"
        Me.lblTitTotalMateriales.Size = New System.Drawing.Size(156, 32)
        Me.lblTitTotalMateriales.TabIndex = 170
        Me.lblTitTotalMateriales.Text = "COSTO MATERIALES $:"
        Me.lblTitTotalMateriales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCantidadDeCierres
        '
        Me.lblCantidadDeCierres.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadDeCierres.Location = New System.Drawing.Point(167, 181)
        Me.lblCantidadDeCierres.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCantidadDeCierres.Name = "lblCantidadDeCierres"
        Me.lblCantidadDeCierres.Size = New System.Drawing.Size(68, 22)
        Me.lblCantidadDeCierres.TabIndex = 136
        Me.lblCantidadDeCierres.Text = "0"
        Me.lblCantidadDeCierres.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitCantidadDeCierres
        '
        Me.lblTitCantidadDeCierres.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitCantidadDeCierres.Location = New System.Drawing.Point(12, 181)
        Me.lblTitCantidadDeCierres.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitCantidadDeCierres.Name = "lblTitCantidadDeCierres"
        Me.lblTitCantidadDeCierres.Size = New System.Drawing.Size(154, 22)
        Me.lblTitCantidadDeCierres.TabIndex = 135
        Me.lblTitCantidadDeCierres.Text = "Cantidad de Cierres:"
        Me.lblTitCantidadDeCierres.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCosto1Cierre
        '
        Me.lblCosto1Cierre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCosto1Cierre.Location = New System.Drawing.Point(176, 153)
        Me.lblCosto1Cierre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCosto1Cierre.Name = "lblCosto1Cierre"
        Me.lblCosto1Cierre.Size = New System.Drawing.Size(60, 22)
        Me.lblCosto1Cierre.TabIndex = 134
        Me.lblCosto1Cierre.Text = "0.00"
        Me.lblCosto1Cierre.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitCosto1Cierre
        '
        Me.lblTitCosto1Cierre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitCosto1Cierre.Location = New System.Drawing.Point(12, 153)
        Me.lblTitCosto1Cierre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitCosto1Cierre.Name = "lblTitCosto1Cierre"
        Me.lblTitCosto1Cierre.Size = New System.Drawing.Size(154, 22)
        Me.lblTitCosto1Cierre.TabIndex = 133
        Me.lblTitCosto1Cierre.Text = "Costo de 1 Cierre:"
        Me.lblTitCosto1Cierre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCantidadDeBotones
        '
        Me.lblCantidadDeBotones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadDeBotones.Location = New System.Drawing.Point(178, 63)
        Me.lblCantidadDeBotones.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCantidadDeBotones.Name = "lblCantidadDeBotones"
        Me.lblCantidadDeBotones.Size = New System.Drawing.Size(60, 22)
        Me.lblCantidadDeBotones.TabIndex = 132
        Me.lblCantidadDeBotones.Text = "0"
        Me.lblCantidadDeBotones.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitCantidadDeBotones
        '
        Me.lblTitCantidadDeBotones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitCantidadDeBotones.Location = New System.Drawing.Point(11, 63)
        Me.lblTitCantidadDeBotones.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitCantidadDeBotones.Name = "lblTitCantidadDeBotones"
        Me.lblTitCantidadDeBotones.Size = New System.Drawing.Size(154, 22)
        Me.lblTitCantidadDeBotones.TabIndex = 131
        Me.lblTitCantidadDeBotones.Text = "Cantidad de Botones:"
        Me.lblTitCantidadDeBotones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCosto1Boton
        '
        Me.lblCosto1Boton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCosto1Boton.Location = New System.Drawing.Point(178, 36)
        Me.lblCosto1Boton.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCosto1Boton.Name = "lblCosto1Boton"
        Me.lblCosto1Boton.Size = New System.Drawing.Size(61, 22)
        Me.lblCosto1Boton.TabIndex = 130
        Me.lblCosto1Boton.Text = "0.00"
        Me.lblCosto1Boton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitCosto1Boton
        '
        Me.lblTitCosto1Boton.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitCosto1Boton.Location = New System.Drawing.Point(11, 36)
        Me.lblTitCosto1Boton.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitCosto1Boton.Name = "lblTitCosto1Boton"
        Me.lblTitCosto1Boton.Size = New System.Drawing.Size(154, 22)
        Me.lblTitCosto1Boton.TabIndex = 129
        Me.lblTitCosto1Boton.Text = "Costo de 1 Botón:"
        Me.lblTitCosto1Boton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnVerMateriales
        '
        Me.btnVerMateriales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerMateriales.Location = New System.Drawing.Point(850, 112)
        Me.btnVerMateriales.Name = "btnVerMateriales"
        Me.btnVerMateriales.Size = New System.Drawing.Size(142, 29)
        Me.btnVerMateriales.TabIndex = 131
        Me.btnVerMateriales.Text = "Ver Materiales"
        Me.btnVerMateriales.UseVisualStyleBackColor = True
        '
        'lblPorcionConfRestoPlantayEtapa2
        '
        Me.lblPorcionConfRestoPlantayEtapa2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorcionConfRestoPlantayEtapa2.Location = New System.Drawing.Point(256, 404)
        Me.lblPorcionConfRestoPlantayEtapa2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPorcionConfRestoPlantayEtapa2.Name = "lblPorcionConfRestoPlantayEtapa2"
        Me.lblPorcionConfRestoPlantayEtapa2.Size = New System.Drawing.Size(88, 22)
        Me.lblPorcionConfRestoPlantayEtapa2.TabIndex = 182
        Me.lblPorcionConfRestoPlantayEtapa2.Text = "2812377.84"
        Me.lblPorcionConfRestoPlantayEtapa2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitPorcentajeConfRestoPlantayEtapa2
        '
        Me.lblTitPorcentajeConfRestoPlantayEtapa2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitPorcentajeConfRestoPlantayEtapa2.Location = New System.Drawing.Point(7, 404)
        Me.lblTitPorcentajeConfRestoPlantayEtapa2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitPorcentajeConfRestoPlantayEtapa2.Name = "lblTitPorcentajeConfRestoPlantayEtapa2"
        Me.lblTitPorcentajeConfRestoPlantayEtapa2.Size = New System.Drawing.Size(237, 22)
        Me.lblTitPorcentajeConfRestoPlantayEtapa2.TabIndex = 181
        Me.lblTitPorcentajeConfRestoPlantayEtapa2.Text = "CONF. RESTO + ETAPA 2 (43%):"
        Me.lblTitPorcentajeConfRestoPlantayEtapa2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPorcionConfTejeduriayEtapa2
        '
        Me.lblPorcionConfTejeduriayEtapa2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorcionConfTejeduriayEtapa2.Location = New System.Drawing.Point(256, 387)
        Me.lblPorcionConfTejeduriayEtapa2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPorcionConfTejeduriayEtapa2.Name = "lblPorcionConfTejeduriayEtapa2"
        Me.lblPorcionConfTejeduriayEtapa2.Size = New System.Drawing.Size(88, 22)
        Me.lblPorcionConfTejeduriayEtapa2.TabIndex = 180
        Me.lblPorcionConfTejeduriayEtapa2.Text = "751261.60"
        Me.lblPorcionConfTejeduriayEtapa2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitPorcentajeConfTejeduriayEtapa2
        '
        Me.lblTitPorcentajeConfTejeduriayEtapa2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitPorcentajeConfTejeduriayEtapa2.Location = New System.Drawing.Point(8, 387)
        Me.lblTitPorcentajeConfTejeduriayEtapa2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitPorcentajeConfTejeduriayEtapa2.Name = "lblTitPorcentajeConfTejeduriayEtapa2"
        Me.lblTitPorcentajeConfTejeduriayEtapa2.Size = New System.Drawing.Size(237, 22)
        Me.lblTitPorcentajeConfTejeduriayEtapa2.TabIndex = 179
        Me.lblTitPorcentajeConfTejeduriayEtapa2.Text = "CONF. TEJED + ETAPA 2 (57%):"
        Me.lblTitPorcentajeConfTejeduriayEtapa2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(4, 426)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(350, 4)
        Me.Label17.TabIndex = 183
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCostoGastoIndirectoPorPrendaCorte
        '
        Me.lblCostoGastoIndirectoPorPrendaCorte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCostoGastoIndirectoPorPrendaCorte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoGastoIndirectoPorPrendaCorte.Location = New System.Drawing.Point(7, 573)
        Me.lblCostoGastoIndirectoPorPrendaCorte.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCostoGastoIndirectoPorPrendaCorte.Name = "lblCostoGastoIndirectoPorPrendaCorte"
        Me.lblCostoGastoIndirectoPorPrendaCorte.Size = New System.Drawing.Size(339, 22)
        Me.lblCostoGastoIndirectoPorPrendaCorte.TabIndex = 184
        Me.lblCostoGastoIndirectoPorPrendaCorte.Text = "COSTO INDIRECTO POR PRENDA CORTADA:"
        Me.lblCostoGastoIndirectoPorPrendaCorte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCalculoCIPrendaCortada
        '
        Me.lblCalculoCIPrendaCortada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCalculoCIPrendaCortada.Location = New System.Drawing.Point(7, 551)
        Me.lblCalculoCIPrendaCortada.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCalculoCIPrendaCortada.Name = "lblCalculoCIPrendaCortada"
        Me.lblCalculoCIPrendaCortada.Size = New System.Drawing.Size(337, 22)
        Me.lblCalculoCIPrendaCortada.TabIndex = 186
        Me.lblCalculoCIPrendaCortada.Text = "Calculo costo indirecto prenda cortada"
        Me.lblCalculoCIPrendaCortada.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCalculoCIPrendaTejida
        '
        Me.lblCalculoCIPrendaTejida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCalculoCIPrendaTejida.Location = New System.Drawing.Point(7, 497)
        Me.lblCalculoCIPrendaTejida.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCalculoCIPrendaTejida.Name = "lblCalculoCIPrendaTejida"
        Me.lblCalculoCIPrendaTejida.Size = New System.Drawing.Size(336, 22)
        Me.lblCalculoCIPrendaTejida.TabIndex = 185
        Me.lblCalculoCIPrendaTejida.Text = "Calculo costo indirecto prenda tejida"
        Me.lblCalculoCIPrendaTejida.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmRepoCostoArticulos_3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1237, 827)
        Me.Controls.Add(Me.gbCostosIndirectos)
        Me.Controls.Add(Me.btnVerMateriales)
        Me.Controls.Add(Me.gbMaterialesArticulo)
        Me.Controls.Add(Me.btnVerCostosRubros)
        Me.Controls.Add(Me.gbCalculoCostoRubros)
        Me.Controls.Add(Me.btnVerColSinCS)
        Me.Controls.Add(Me.gbParametrosCosto)
        Me.Controls.Add(Me.gbRecuperoSueldosTeje)
        Me.Controls.Add(Me.btnVerCostosIndirectos)
        Me.Controls.Add(Me.dgvSueldosTejeduria)
        Me.Controls.Add(Me.cmbTipoLisoSublimado)
        Me.Controls.Add(Me.lblTipoLisoSublimado)
        Me.Controls.Add(Me.cmbPROD)
        Me.Controls.Add(Me.lblPROD)
        Me.Controls.Add(Me.gbCalculo)
        Me.Controls.Add(Me.btnVerCalculo)
        Me.Controls.Add(Me.cmbHilados)
        Me.Controls.Add(Me.lblTipoHilado)
        Me.Controls.Add(Me.btnVerArmado)
        Me.Controls.Add(Me.gbArmadoArticulo)
        Me.Controls.Add(Me.cmdImprimir)
        Me.Controls.Add(Me.chkVerInhabilitados)
        Me.Controls.Add(Me.txtCodArtHasta)
        Me.Controls.Add(Me.lblCodArtHasta)
        Me.Controls.Add(Me.btnFiltrar)
        Me.Controls.Add(Me.txtCodArtDesde)
        Me.Controls.Add(Me.lblCodArtDesde)
        Me.Controls.Add(Me.dgvArticulos)
        Me.Controls.Add(Me.lblCodArtTitulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmRepoCostoArticulos_3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Costos de Artículos"
        CType(Me.dgvArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbArmadoArticulo.ResumeLayout(False)
        CType(Me.dgvTareasArt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCalculo.ResumeLayout(False)
        Me.PanelCostoTejeduriaRESTO.ResumeLayout(False)
        Me.PanelCostoTejeduriaCORTE.ResumeLayout(False)
        CType(Me.dgvSueldosTejeduria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbCostosIndirectos.ResumeLayout(False)
        Me.gbRecuperoSueldosTeje.ResumeLayout(False)
        Me.gbParametrosCosto.ResumeLayout(False)
        Me.gbParametrosCosto.PerformLayout()
        Me.gbCalculoCostoRubros.ResumeLayout(False)
        CType(Me.dgvCostosRubros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMaterialesArticulo.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvArticulos As System.Windows.Forms.DataGridView
    Friend WithEvents txtCodArtDesde As System.Windows.Forms.TextBox
    Friend WithEvents lblCodArtDesde As System.Windows.Forms.Label
    Friend WithEvents btnFiltrar As System.Windows.Forms.Button
    Friend WithEvents txtCodArtHasta As System.Windows.Forms.TextBox
    Friend WithEvents lblCodArtHasta As System.Windows.Forms.Label
    Friend WithEvents lblCodArtTitulo As System.Windows.Forms.Label
    Friend WithEvents chkVerInhabilitados As System.Windows.Forms.CheckBox
    Friend WithEvents cmdImprimir As System.Windows.Forms.Button
    Friend WithEvents pdoImpresion As System.Drawing.Printing.PrintDocument
    Friend WithEvents gbArmadoArticulo As System.Windows.Forms.GroupBox
    Friend WithEvents dgvTareasArt As System.Windows.Forms.DataGridView
    Friend WithEvents btnVerArmado As System.Windows.Forms.Button
    Friend WithEvents cmbHilados As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoHilado As System.Windows.Forms.Label
    Friend WithEvents btnVerCalculo As System.Windows.Forms.Button
    Friend WithEvents gbCalculo As System.Windows.Forms.GroupBox
    Friend WithEvents lblCostoArmado As System.Windows.Forms.Label
    Friend WithEvents lblCantMaqPorTejedor As System.Windows.Forms.Label
    Friend WithEvents lblCostoArmadoConCargasSociales As System.Windows.Forms.Label
    Friend WithEvents lblPesoRolloHilado As System.Windows.Forms.Label
    Friend WithEvents lblRollosMaqTurno As System.Windows.Forms.Label
    Friend WithEvents lblRollosPorHora As System.Windows.Forms.Label
    Friend WithEvents lblKilosPorHora As System.Windows.Forms.Label
    Friend WithEvents lblAuxRollosPorHora As System.Windows.Forms.Label
    Friend WithEvents lblAuxKilosPorHora As System.Windows.Forms.Label
    Friend WithEvents lblAuxPesosPorKiloMO As System.Windows.Forms.Label
    Friend WithEvents lblPesosPorKiloMO As System.Windows.Forms.Label
    Friend WithEvents lblCostoManoObra As System.Windows.Forms.Label
    Friend WithEvents lblCostoManoObraConCargasSociales As System.Windows.Forms.Label
    Friend WithEvents lblValorHoraMO As System.Windows.Forms.Label
    Friend WithEvents lblPresentismo As System.Windows.Forms.Label
    Friend WithEvents lblCargasSociales As System.Windows.Forms.Label
    Friend WithEvents lblSAC As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblAuxCostoMO As System.Windows.Forms.Label
    Friend WithEvents lblCostoKiloHilado As System.Windows.Forms.Label
    Friend WithEvents lblCostoHilado As System.Windows.Forms.Label
    Friend WithEvents lblCostosIndirectos As System.Windows.Forms.Label
    Friend WithEvents lblCostoMateriales As System.Windows.Forms.Label
    Friend WithEvents lblCostoTotal As System.Windows.Forms.Label
    Friend WithEvents cmbPROD As System.Windows.Forms.ComboBox
    Friend WithEvents lblPROD As System.Windows.Forms.Label
    Friend WithEvents cmbTipoLisoSublimado As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoLisoSublimado As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblNroCelda As System.Windows.Forms.Label
    Friend WithEvents lblTitNroCelda As System.Windows.Forms.Label
    Friend WithEvents lblFechaHasta As System.Windows.Forms.Label
    Friend WithEvents lblTitFechaHasta As System.Windows.Forms.Label
    Friend WithEvents lblCostoTotalCelda As System.Windows.Forms.Label
    Friend WithEvents lblTitCostoCelda As System.Windows.Forms.Label
    Friend WithEvents lblCantPersonas As System.Windows.Forms.Label
    Friend WithEvents lblTitCantPersonas As System.Windows.Forms.Label
    Friend WithEvents lblCostoTotalTareas As System.Windows.Forms.Label
    Friend WithEvents lblTitCostoTareas As System.Windows.Forms.Label
    Friend WithEvents lblCostoTeñido As System.Windows.Forms.Label
    Friend WithEvents PanelCostoTejeduriaCORTE As System.Windows.Forms.Panel
    Friend WithEvents PanelCostoTejeduriaRESTO As System.Windows.Forms.Panel
    Friend WithEvents lblCantMinutosArticulo As System.Windows.Forms.Label
    Friend WithEvents lblTitCantMinutosArticulo As System.Windows.Forms.Label
    Friend WithEvents lblSemanasConfTejeduria As System.Windows.Forms.Label
    Friend WithEvents lblTitSemanasConfTejeduria As System.Windows.Forms.Label
    Friend WithEvents lblCantPersonasTejeduria As System.Windows.Forms.Label
    Friend WithEvents lblTitCantPersonasTejeduria As System.Windows.Forms.Label
    Friend WithEvents lblTotalSueldosTejeduria As System.Windows.Forms.Label
    Friend WithEvents lblTitTotalSueldosTejeduria As System.Windows.Forms.Label
    Friend WithEvents dgvSueldosTejeduria As System.Windows.Forms.DataGridView
    Friend WithEvents lblCantMaquinasTejeduria As System.Windows.Forms.Label
    Friend WithEvents lblTitCantMaquinasTejeduria As System.Windows.Forms.Label
    Friend WithEvents lblCantHorasDelMes As System.Windows.Forms.Label
    Friend WithEvents lblTitCantHorasDelMes As System.Windows.Forms.Label
    Friend WithEvents lblCostoPorMinutoTejeduria As System.Windows.Forms.Label
    Friend WithEvents lblTitCostoPorMinutoTejeduria As System.Windows.Forms.Label
    Friend WithEvents lblCostoPorMinutoPorPrenda As System.Windows.Forms.Label
    Friend WithEvents lblTitCostoPorMinutoPorPrenda As System.Windows.Forms.Label
    Friend WithEvents lblCostoMOdelArticulo As System.Windows.Forms.Label
    Friend WithEvents lblTitCostoMOdelArticulo As System.Windows.Forms.Label
    Friend WithEvents btnVerCostosIndirectos As System.Windows.Forms.Button
    Friend WithEvents gbCostosIndirectos As System.Windows.Forms.GroupBox
    Friend WithEvents lblCostoGastoIndirectoPorPrendaTejida As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents lblTitTotalCostosOperativos As System.Windows.Forms.Label
    Friend WithEvents lblGastoSeguridadVigilancia As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblGastoAtencionMedica As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblGastoEfluentesIndustriales As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblGastoTasaServSanitarios As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblGastoImpYTasasVarios As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblGastoTasaAlumbrado As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblGastoGas As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblGastoLuz As System.Windows.Forms.Label
    Friend WithEvents lblTotalCostosOperativos As System.Windows.Forms.Label
    Friend WithEvents lblGastoSueldosDptoMantLavEncAyud As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblGastoSueldosSupGerDiseProg As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblTotalSueldosOperativos As System.Windows.Forms.Label
    Friend WithEvents lblTitTotalSueldosOperativos As System.Windows.Forms.Label
    Friend WithEvents lblTotalSueldosOperativosMasCargas As System.Windows.Forms.Label
    Friend WithEvents lblTitTotalSueldosOperativosConCargas As System.Windows.Forms.Label
    Friend WithEvents lblTotalPrendasProducidas As System.Windows.Forms.Label
    Friend WithEvents lblTitTotalPrendasProducidas As System.Windows.Forms.Label
    Friend WithEvents lblTotalPrendasCortadas As System.Windows.Forms.Label
    Friend WithEvents lblTitTotalPrendasCortadas As System.Windows.Forms.Label
    Friend WithEvents lblTotalPrendasTejidas As System.Windows.Forms.Label
    Friend WithEvents lblTitTotalPrendasTejidas As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTotalGastosIndirectos As System.Windows.Forms.Label
    Friend WithEvents lblTitTotalGastosIndirectos As System.Windows.Forms.Label
    Friend WithEvents lblTotalCostosRubros As System.Windows.Forms.Label
    Friend WithEvents lblTitTotalCastosRubros As System.Windows.Forms.Label
    Friend WithEvents gbRecuperoSueldosTeje As System.Windows.Forms.GroupBox
    Friend WithEvents lblUltimoRecuperoExcelCargasSociales As System.Windows.Forms.Label
    Friend WithEvents btnRecuperarExcelCargasSociales As System.Windows.Forms.Button
    Friend WithEvents gbParametrosCosto As System.Windows.Forms.GroupBox
    Friend WithEvents txtParamCantPrendasTejidas As System.Windows.Forms.TextBox
    Friend WithEvents lblParamCantPrendastejidas As System.Windows.Forms.Label
    Friend WithEvents btnRecalcularCostos As System.Windows.Forms.Button
    Friend WithEvents txtParamCantPrendasCortadas As System.Windows.Forms.TextBox
    Friend WithEvents lblParamCantPrendasCortadas As System.Windows.Forms.Label
    Friend WithEvents btnVerColSinCS As System.Windows.Forms.Button
    Friend WithEvents gbCalculoCostoRubros As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dgvCostosRubros As System.Windows.Forms.DataGridView
    Friend WithEvents btnVerCostosRubros As System.Windows.Forms.Button
    Friend WithEvents lblCostoRubroMensualEnPesos As System.Windows.Forms.Label
    Friend WithEvents lblTitCostoRubroMensualEnPesos As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblCostoRubroCotizDolar As System.Windows.Forms.Label
    Friend WithEvents lblTitCostoRubroCotizDolar As System.Windows.Forms.Label
    Friend WithEvents lblCostoRubroTotalDolares As System.Windows.Forms.Label
    Friend WithEvents lblTitCostoRubroTotalDolares As System.Windows.Forms.Label
    Friend WithEvents gbMaterialesArticulo As System.Windows.Forms.GroupBox
    Friend WithEvents lblCostoBotones As System.Windows.Forms.Label
    Friend WithEvents lblTitCostoBotones As System.Windows.Forms.Label
    Friend WithEvents lblTotalMateriales As System.Windows.Forms.Label
    Friend WithEvents lblTitTotalMateriales As System.Windows.Forms.Label
    Friend WithEvents lblCantidadDeCierres As System.Windows.Forms.Label
    Friend WithEvents lblTitCantidadDeCierres As System.Windows.Forms.Label
    Friend WithEvents lblCosto1Cierre As System.Windows.Forms.Label
    Friend WithEvents lblTitCosto1Cierre As System.Windows.Forms.Label
    Friend WithEvents lblCantidadDeBotones As System.Windows.Forms.Label
    Friend WithEvents lblTitCantidadDeBotones As System.Windows.Forms.Label
    Friend WithEvents lblCosto1Boton As System.Windows.Forms.Label
    Friend WithEvents lblTitCosto1Boton As System.Windows.Forms.Label
    Friend WithEvents lblCostoCierres As System.Windows.Forms.Label
    Friend WithEvents lblTitCostoCierres As System.Windows.Forms.Label
    Friend WithEvents btnVerMateriales As System.Windows.Forms.Button
    Friend WithEvents lblPorcionRestoPlanta As System.Windows.Forms.Label
    Friend WithEvents lblTitPorcentajeRestoPlanta As System.Windows.Forms.Label
    Friend WithEvents lblPorcionTejeduria As System.Windows.Forms.Label
    Friend WithEvents lblTitPorcentajeTejeduria As System.Windows.Forms.Label
    Friend WithEvents lblPorcionConfRestoPlantayEtapa2 As System.Windows.Forms.Label
    Friend WithEvents lblTitPorcentajeConfRestoPlantayEtapa2 As System.Windows.Forms.Label
    Friend WithEvents lblPorcionConfTejeduriayEtapa2 As System.Windows.Forms.Label
    Friend WithEvents lblTitPorcentajeConfTejeduriayEtapa2 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblCostoGastoIndirectoPorPrendaCorte As System.Windows.Forms.Label
    Friend WithEvents lblCalculoCIPrendaCortada As System.Windows.Forms.Label
    Friend WithEvents lblCalculoCIPrendaTejida As System.Windows.Forms.Label
End Class
