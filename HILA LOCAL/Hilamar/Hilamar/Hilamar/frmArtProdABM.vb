Imports System.Data.SqlClient
Imports System.IO

Public Class frmArtProdABM

    Public Alta As Boolean
    Public EstoyCopiando As Boolean
    Dim EstoyCargando As Boolean
    Public ID As Integer
    Dim TipoPlanilla As String
    Dim EsPlanillaPrendaCompleta As Boolean
    Dim ResguardoRutaImagen As String
    Dim CodArtOriginal, ColorOriginal, PartidaOriginal As String
    Dim ImprimirPesosyTiempos, DejarVaciasMedidasIniciales, ImprimirPlanoDeMedidas As Boolean

    Dim ElArticuloEsOriginal As Integer = 0
    Dim ElArticuloTieneProgramaTerminado As Integer = 0

    Dim ColCategoria As New Collection
    Dim ColCategoriaIdsClaves As New Collection

    Dim LegajoLogueado As String 'legajo de quien va a trabajar
    Dim TipoUsuario As String ' Tipo de usuario que va a trabajar, lo voy a usar para saber que le habilito a usar y que no

    Sub New(ByVal parametro1 As String, ByVal parametro2 As String)

        InitializeComponent() 'es necesario que lleve esta linea

        LegajoLogueado = parametro1
        TipoUsuario = parametro2

    End Sub

    Public Sub Cargar()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String
        Dim i As Integer

        CargarCategorias()

        picFoto.Height = Panel2.Height
        picFoto.Width = Panel2.Width

        lblRutaImagen.Enabled = False
        txtRutaImagen.Enabled = False
        btnAbrirRutaImagen.Enabled = False
        Panel2.Visible = False

        chkArtConProgramaTerminado.Enabled = False
        If TipoUsuario = "Administrador" Or (TipoUsuario = "Programacion" And (LegajoLogueado = "S00976" Or LegajoLogueado = "S00977")) Then ' En principio los únicos programadores que pueden checkear el terminado son Nicolás y Flavio Then
            chkArtConProgramaTerminado.Enabled = True
        End If

        If dgvGC_STOLL.RowCount <= 0 Then
            CrearArraysDeGraduaciondeCuerposSTOLL()
            CrearArraysDeGraduaciondeMangasSTOLL()
            CrearArraysDeTirajedeCuerposSTOLL()
            CrearArraysDeTirajedeMangasSTOLL()

            CrearArraysDeGraduaciondeCuerposSHIMA()
            CrearArraysDeGraduaciondeMangasSHIMA()
            CrearArraysDeTirajedeCuerposSHIMA()
            CrearArraysDeTirajedeMangasSHIMA()
        End If

        CodArtOriginal = ""
        ColorOriginal = ""
        PartidaOriginal = ""
        If Not Alta Then
            If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
            sStr = "SELECT * FROM PrendasArtProdPlanillas WHERE id = " + ID.ToString
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read Then

                    If Not IsDBNull(Reader.Item("Fecha")) Then dtpFecha.Value = Reader.Item("Fecha")
                    txtNroPrograma.Text = Reader.Item("NroPrograma").ToString
                    cmbCategoria.Text = ColCategoriaIdsClaves.Item(Reader.Item("IdCategoria").ToString)
                    txtArticulo.Text = Reader.Item("Articulo").ToString
                    CodArtOriginal = Reader.Item("Articulo").ToString
                    txtOp.Text = Reader.Item("OP").ToString
                    txtDiseño.Text = Reader.Item("Diseño").ToString
                    txtColor.Text = Reader.Item("Color").ToString
                    ColorOriginal = Reader.Item("Color").ToString
                    txtPartida.Text = Reader.Item("Partida").ToString
                    PartidaOriginal = Reader.Item("Partida").ToString
                    txtVentDel.Text = Reader.Item("Ventana").ToString
                    txtVentEsp.Text = Reader.Item("VentanaEspalda").ToString
                    txtVentMan.Text = Reader.Item("VentanaManga").ToString
                    txtVentCap.Text = Reader.Item("VentanaCapucha").ToString
                    txtMedidaElastico.Text = Reader.Item("MedidaElastico").ToString
                    txtCondicionCuerpos.Text = Reader.Item("CondicionCuerpos").ToString
                    txtVelocidadCuerpos.Text = Reader.Item("VelocidadCuerpos").ToString
                    txtMedidaPuño.Text = Reader.Item("MedidaPuño").ToString
                    txtCondicionMangas.Text = Reader.Item("CondicionMangas").ToString
                    txtVelocidadMangas.Text = Reader.Item("VelocidadMangas").ToString

                    txtTalleXXL_D.Text = Reader.Item("TalleXXL_D").ToString
                    txtTalleXXL_E.Text = Reader.Item("TalleXXL_E").ToString
                    txtTalleXXLBretel.Text = Reader.Item("TalleXXL_Bretel").ToString
                    txtTalleXXLEsc.Text = Reader.Item("TalleXXL_Esc").ToString
                    txtTalleXXLBolsillo.Text = Reader.Item("TalleXXL_Bolsillo").ToString
                    txtTalleXXLAncho.Text = Reader.Item("TalleXXL_Ancho").ToString
                    txtTalleXXLLargo.Text = Reader.Item("TalleXXL_Largo").ToString
                    txtTalleXXL_CuerParamInicio.Text = Reader.Item("TalleXXL_CueParamInicio").ToString
                    txtTalleXXL_CuerCantAgujas.Text = Reader.Item("TalleXXL_CueCantAgujas").ToString
                    txtTalleXXL_Manga.Text = Reader.Item("TalleXXL_Manga").ToString
                    txtTalleXXL_MangaParamInicio.Text = Reader.Item("TalleXXL_MangaParamInicio").ToString
                    txtTalleXXL_MangaCantAgujas.Text = Reader.Item("TalleXXL_MangaCantAgujas").ToString
                    txtTalleXXL_D_MedInicial.Text = Reader.Item("TalleXXL_MedInicial_D").ToString
                    txtTalleXXL_E_MedInicial.Text = Reader.Item("TalleXXL_MedInicial_E").ToString
                    txtTalleXXL_M_MedInicial.Text = Reader.Item("TalleXXL_MedInicial_M").ToString
                    txtTalleXXLBretel_Tit.Text = Reader.Item("TalleXXL_Bretel_Tit").ToString
                    txtTalleXXLEsc_Tit.Text = Reader.Item("TalleXXL_Esc_Tit").ToString
                    txtTalleXXLBolsillo_Tit.Text = Reader.Item("TalleXXL_Bolsillo_Tit").ToString
                    txtTalleXXLAncho_Tit.Text = Reader.Item("TalleXXL_Ancho_Tit").ToString
                    txtTalleXXLLargo_Tit.Text = Reader.Item("TalleXXL_Largo_Tit").ToString

                    txtTalleXL_D.Text = Reader.Item("TalleXL_D").ToString
                    txtTalleXL_E.Text = Reader.Item("TalleXL_E").ToString
                    txtTalleXLBretel.Text = Reader.Item("TalleXL_Bretel").ToString
                    txtTalleXLEsc.Text = Reader.Item("TalleXL_Esc").ToString
                    txtTalleXLBolsillo.Text = Reader.Item("TalleXL_Bolsillo").ToString
                    txtTalleXLAncho.Text = Reader.Item("TalleXL_Ancho").ToString
                    txtTalleXLLargo.Text = Reader.Item("TalleXL_Largo").ToString
                    txtTalleXL_CuerParamInicio.Text = Reader.Item("TalleXL_CueParamInicio").ToString
                    txtTalleXL_CuerCantAgujas.Text = Reader.Item("TalleXL_CueCantAgujas").ToString
                    txtTalleXL_Manga.Text = Reader.Item("TalleXL_Manga").ToString
                    txtTalleXL_MangaParamInicio.Text = Reader.Item("TalleXL_MangaParamInicio").ToString
                    txtTalleXL_MangaCantAgujas.Text = Reader.Item("TalleXL_MangaCantAgujas").ToString
                    txtTalleXL_D_MedInicial.Text = Reader.Item("TalleXL_MedInicial_D").ToString
                    txtTalleXL_E_MedInicial.Text = Reader.Item("TalleXL_MedInicial_E").ToString
                    txtTalleXL_M_MedInicial.Text = Reader.Item("TalleXL_MedInicial_M").ToString
                    txtTalleXLBretel_Tit.Text = Reader.Item("TalleXL_Bretel_Tit").ToString
                    txtTalleXLEsc_Tit.Text = Reader.Item("TalleXL_Esc_Tit").ToString
                    txtTalleXLBolsillo_Tit.Text = Reader.Item("TalleXL_Bolsillo_Tit").ToString
                    txtTalleXLAncho_Tit.Text = Reader.Item("TalleXL_Ancho_Tit").ToString
                    txtTalleXLLargo_Tit.Text = Reader.Item("TalleXL_Largo_Tit").ToString

                    txtTalleL_D.Text = Reader.Item("TalleL_D").ToString
                    txtTalleL_E.Text = Reader.Item("TalleL_E").ToString
                    txtTalleLBretel.Text = Reader.Item("TalleL_Bretel").ToString
                    txtTalleLEsc.Text = Reader.Item("TalleL_Esc").ToString
                    txtTalleLBolsillo.Text = Reader.Item("TalleL_Bolsillo").ToString
                    txtTalleLAncho.Text = Reader.Item("TalleL_Ancho").ToString
                    txtTalleLLargo.Text = Reader.Item("TalleL_Largo").ToString
                    txtTalleL_CuerParamInicio.Text = Reader.Item("TalleL_CueParamInicio").ToString
                    txtTalleL_CuerCantAgujas.Text = Reader.Item("TalleL_CueCantAgujas").ToString
                    txtTalleL_Manga.Text = Reader.Item("TalleL_Manga").ToString
                    txtTalleL_MangaParamInicio.Text = Reader.Item("TalleL_MangaParamInicio").ToString
                    txtTalleL_MangaCantAgujas.Text = Reader.Item("TalleL_MangaCantAgujas").ToString
                    txtTalleL_D_MedInicial.Text = Reader.Item("TalleL_MedInicial_D").ToString
                    txtTalleL_E_MedInicial.Text = Reader.Item("TalleL_MedInicial_E").ToString
                    txtTalleL_M_MedInicial.Text = Reader.Item("TalleL_MedInicial_M").ToString
                    txtTalleLBretel_Tit.Text = Reader.Item("TalleL_Bretel_Tit").ToString
                    txtTalleLEsc_Tit.Text = Reader.Item("TalleL_Esc_Tit").ToString
                    txtTalleLBolsillo_Tit.Text = Reader.Item("TalleL_Bolsillo_Tit").ToString
                    txtTalleLAncho_Tit.Text = Reader.Item("TalleL_Ancho_Tit").ToString
                    txtTalleLLargo_Tit.Text = Reader.Item("TalleL_Largo_Tit").ToString

                    txtTalleM_D.Text = Reader.Item("TalleM_D").ToString
                    txtTalleM_E.Text = Reader.Item("TalleM_E").ToString
                    txtTalleMBretel.Text = Reader.Item("TalleM_Bretel").ToString
                    txtTalleMEsc.Text = Reader.Item("TalleM_Esc").ToString
                    txtTalleMBolsillo.Text = Reader.Item("TalleM_Bolsillo").ToString
                    txtTalleMAncho.Text = Reader.Item("TalleM_Ancho").ToString
                    txtTalleMLargo.Text = Reader.Item("TalleM_Largo").ToString
                    txtTalleM_CuerParamInicio.Text = Reader.Item("TalleM_CueParamInicio").ToString
                    txtTalleM_CuerCantAgujas.Text = Reader.Item("TalleM_CueCantAgujas").ToString
                    txtTalleM_Manga.Text = Reader.Item("TalleM_Manga").ToString
                    txtTalleM_MangaParamInicio.Text = Reader.Item("TalleM_MangaParamInicio").ToString
                    txtTalleM_MangaCantAgujas.Text = Reader.Item("TalleM_MangaCantAgujas").ToString
                    txtTalleM_D_MedInicial.Text = Reader.Item("TalleM_MedInicial_D").ToString
                    txtTalleM_E_MedInicial.Text = Reader.Item("TalleM_MedInicial_E").ToString
                    txtTalleM_M_MedInicial.Text = Reader.Item("TalleM_MedInicial_M").ToString
                    txtTalleMBretel_Tit.Text = Reader.Item("TalleM_Bretel_Tit").ToString
                    txtTalleMEsc_Tit.Text = Reader.Item("TalleM_Esc_Tit").ToString
                    txtTalleMBolsillo_Tit.Text = Reader.Item("TalleM_Bolsillo_Tit").ToString
                    txtTalleMAncho_Tit.Text = Reader.Item("TalleM_Ancho_Tit").ToString
                    txtTalleMLargo_Tit.Text = Reader.Item("TalleM_Largo_Tit").ToString

                    txtTalleS_D.Text = Reader.Item("TalleS_D").ToString
                    txtTalleS_E.Text = Reader.Item("TalleS_E").ToString
                    txtTalleSBretel.Text = Reader.Item("TalleS_Bretel").ToString
                    txtTalleSEsc.Text = Reader.Item("TalleS_Esc").ToString
                    txtTalleSBolsillo.Text = Reader.Item("TalleS_Bolsillo").ToString
                    txtTalleSAncho.Text = Reader.Item("TalleS_Ancho").ToString
                    txtTalleSLargo.Text = Reader.Item("TalleS_Largo").ToString
                    txtTalleS_CuerParamInicio.Text = Reader.Item("TalleS_CueParamInicio").ToString
                    txtTalleS_CuerCantAgujas.Text = Reader.Item("TalleS_CueCantAgujas").ToString
                    txtTalleS_Manga.Text = Reader.Item("TalleS_Manga").ToString
                    txtTalleS_MangaParamInicio.Text = Reader.Item("TalleS_MangaParamInicio").ToString
                    txtTalleS_MangaCantAgujas.Text = Reader.Item("TalleS_MangaCantAgujas").ToString
                    txtTalleS_D_MedInicial.Text = Reader.Item("TalleS_MedInicial_D").ToString
                    txtTalleS_E_MedInicial.Text = Reader.Item("TalleS_MedInicial_E").ToString
                    txtTalleS_M_MedInicial.Text = Reader.Item("TalleS_MedInicial_M").ToString
                    txtTalleSBretel_Tit.Text = Reader.Item("TalleS_Bretel_Tit").ToString
                    txtTalleSEsc_Tit.Text = Reader.Item("TalleS_Esc_Tit").ToString
                    txtTalleSBolsillo_Tit.Text = Reader.Item("TalleS_Bolsillo_Tit").ToString
                    txtTalleSAncho_Tit.Text = Reader.Item("TalleS_Ancho_Tit").ToString
                    txtTalleSLargo_Tit.Text = Reader.Item("TalleS_Largo_Tit").ToString

                    txtTalleXS_D.Text = Reader.Item("TalleXS_D").ToString
                    txtTalleXS_E.Text = Reader.Item("TalleXS_E").ToString
                    txtTalleXSBretel.Text = Reader.Item("TalleXS_Bretel").ToString
                    txtTalleXSEsc.Text = Reader.Item("TalleXS_Esc").ToString
                    txtTalleXSBolsillo.Text = Reader.Item("TalleXS_Bolsillo").ToString
                    txtTalleXSAncho.Text = Reader.Item("TalleXS_Ancho").ToString
                    txtTalleXSLargo.Text = Reader.Item("TalleXS_Largo").ToString
                    txtTalleXS_CuerParamInicio.Text = Reader.Item("TalleXS_CueParamInicio").ToString
                    txtTalleXS_CuerCantAgujas.Text = Reader.Item("TalleXS_CueCantAgujas").ToString
                    txtTalleXS_Manga.Text = Reader.Item("TalleXS_Manga").ToString
                    txtTalleXS_MangaParamInicio.Text = Reader.Item("TalleXS_MangaParamInicio").ToString
                    txtTalleXS_MangaCantAgujas.Text = Reader.Item("TalleXS_MangaCantAgujas").ToString
                    txtTalleXS_D_MedInicial.Text = Reader.Item("TalleXS_MedInicial_D").ToString
                    txtTalleXS_E_MedInicial.Text = Reader.Item("TalleXS_MedInicial_E").ToString
                    txtTalleXS_M_MedInicial.Text = Reader.Item("TalleXS_MedInicial_M").ToString
                    txtTalleXSBretel_Tit.Text = Reader.Item("TalleXS_Bretel_Tit").ToString
                    txtTalleXSEsc_Tit.Text = Reader.Item("TalleXS_Esc_Tit").ToString
                    txtTalleXSBolsillo_Tit.Text = Reader.Item("TalleXS_Bolsillo_Tit").ToString
                    txtTalleXSAncho_Tit.Text = Reader.Item("TalleXS_Ancho_Tit").ToString
                    txtTalleXSLargo_Tit.Text = Reader.Item("TalleXS_Largo_Tit").ToString

                    If Not IsDBNull(Reader.Item("RutaImagen")) Then
                        txtRutaImagen.Text = Reader.Item("RutaImagen")
                        ResguardoRutaImagen = Reader.Item("RutaImagen")
                        'dejamos cargada la imagen
                        CargarFoto(txtRutaImagen.Text)
                    End If

                    If IsDBNull(Reader.Item("TitTalleXXL")) Then
                        txtTitTalleXXL.Text = "XXL"
                    Else
                        txtTitTalleXXL.Text = Reader.Item("TitTalleXXL").ToString
                    End If
                    If IsDBNull(Reader.Item("TitTalleXL")) Then
                        txtTitTalleXL.Text = "XL"
                    Else
                        txtTitTalleXL.Text = Reader.Item("TitTalleXL").ToString
                    End If
                    If IsDBNull(Reader.Item("TitTalleL")) Then
                        txtTitTalleL.Text = "L"
                    Else
                        txtTitTalleL.Text = Reader.Item("TitTalleL").ToString
                    End If
                    If IsDBNull(Reader.Item("TitTalleM")) Then
                        txtTitTalleM.Text = "M"
                    Else
                        txtTitTalleM.Text = Reader.Item("TitTalleM").ToString
                    End If
                    If IsDBNull(Reader.Item("TitTalleS")) Then
                        txtTitTalleS.Text = "S"
                    Else
                        txtTitTalleS.Text = Reader.Item("TitTalleS").ToString
                    End If
                    If IsDBNull(Reader.Item("TitTalleXS")) Then
                        txtTitTalleXS.Text = "XS"
                    Else
                        txtTitTalleXS.Text = Reader.Item("TitTalleXS").ToString
                    End If

                    'tambien reviso si es articulo original o no y de acuerdo al usuario si puede setearlo
                    chkMarcarComoOriginal.Visible = False
                    btnPonerOriginal.Visible = True
                    lblArtOriginal.Visible = True

                    If IsDBNull(Reader.Item("EsOriginal")) Then
                        ElArticuloEsOriginal = 0
                        lblArtOriginal.Text = "EL ARTICULO NO ES ORIGINAL"
                        lblArtOriginal.ForeColor = Color.Red
                    Else
                        ElArticuloEsOriginal = Reader.Item("EsOriginal")
                        If ElArticuloEsOriginal = 1 Then
                            lblArtOriginal.Text = "ARTICULO ORIGINAL"
                            lblArtOriginal.ForeColor = Color.Green
                        Else
                            lblArtOriginal.Text = "EL ARTICULO NO ES ORIGINAL"
                            lblArtOriginal.ForeColor = Color.Red
                        End If
                    End If
                    btnPonerOriginal.Enabled = False
                    If ElArticuloEsOriginal = 0 And (TipoUsuario = "Administrador" Or TipoUsuario = "Programacion") Then
                        btnPonerOriginal.Enabled = True
                    End If

                    EstoyCargando = True
                    If IsDBNull(Reader.Item("TieneProgramaTerminado")) Then
                        ElArticuloTieneProgramaTerminado = 0
                        chkArtConProgramaTerminado.Checked = False
                    Else
                        ElArticuloTieneProgramaTerminado = Reader.Item("TieneProgramaTerminado")
                        chkArtConProgramaTerminado.Checked = ElArticuloTieneProgramaTerminado
                    End If
                    EstoyCargando = False

                    If Not IsDBNull(Reader.Item("NroPrograma")) Then
                        If TipoUsuario = "Programación" Or TipoUsuario = "Administrador" Then

                            txtNroPrograma.Text = Reader.Item("NroPrograma")
                        End If
                    End If

                    If TipoPlanilla = "STOLL" Then
                        AcomodarTitulosyCuadrosSTOLL()

                        CargarPicos()
                    Else
                        AcomodarTitulosyCuadrosSHIMA()

                        CargarMallaVariable()
                    End If

                    i = 0
                    sStr = "SELECT *,isnull(Sombreado,0) as Sombra FROM PrendasArtProdPlanillas_GC WHERE IdPlanilla = " + ID.ToString
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Reader = Command.ExecuteReader()
                    Do While Reader.HasRows
                        Do While Reader.Read
                            If i < 20 Then
                                If TipoPlanilla = "STOLL" Then
                                    If Reader.Item("Sombra") = 1 Then
                                        dgvGC_STOLL.Rows(i).Cells("chk_1").Value = True
                                    Else
                                        dgvGC_STOLL.Rows(i).Cells("chk_1").Value = False
                                    End If
                                    dgvGC_STOLL.Rows(i).Cells("LETRA_1").Value = Reader.Item("Letra").ToString
                                    dgvGC_STOLL.Rows(i).Cells("C1_1").Value = Reader.Item("Cuadro1").ToString
                                    dgvGC_STOLL.Rows(i).Cells("C2_1").Value = Reader.Item("Cuadro2").ToString
                                    dgvGC_STOLL.Rows(i).Cells("DESC_1").Value = Reader.Item("Descripcion").ToString
                                Else
                                    If Reader.Item("Sombra") = 1 Then
                                        dgvGC_SHIMA.Rows(i).Cells("chk_1").Value = True
                                    Else
                                        dgvGC_SHIMA.Rows(i).Cells("chk_1").Value = False
                                    End If
                                    dgvGC_SHIMA.Rows(i).Cells("LETRA_1").Value = Reader.Item("Letra").ToString
                                    dgvGC_SHIMA.Rows(i).Cells("C1_1").Value = Reader.Item("Cuadro1").ToString
                                    dgvGC_SHIMA.Rows(i).Cells("C2_1").Value = Reader.Item("Cuadro2").ToString
                                    dgvGC_SHIMA.Rows(i).Cells("DESC_1").Value = Reader.Item("Descripcion").ToString
                                End If
                            Else
                                If TipoPlanilla = "STOLL" Then
                                    If Reader.Item("Sombra") = 1 Then
                                        dgvGC_STOLL.Rows(i - 20).Cells("chk_2").Value = True
                                    Else
                                        dgvGC_STOLL.Rows(i - 20).Cells("chk_2").Value = False
                                    End If
                                    dgvGC_STOLL.Rows(i - 20).Cells("LETRA_2").Value = Reader.Item("Letra").ToString
                                    dgvGC_STOLL.Rows(i - 20).Cells("C1_2").Value = Reader.Item("Cuadro1").ToString
                                    dgvGC_STOLL.Rows(i - 20).Cells("C2_2").Value = Reader.Item("Cuadro2").ToString
                                    dgvGC_STOLL.Rows(i - 20).Cells("DESC_2").Value = Reader.Item("Descripcion").ToString
                                Else
                                    If Reader.Item("Sombra") = 1 Then
                                        dgvGC_SHIMA.Rows(i - 20).Cells("chk_2").Value = True
                                    Else
                                        dgvGC_SHIMA.Rows(i - 20).Cells("chk_2").Value = False
                                    End If
                                    dgvGC_SHIMA.Rows(i - 20).Cells("LETRA_2").Value = Reader.Item("Letra").ToString
                                    dgvGC_SHIMA.Rows(i - 20).Cells("C1_2").Value = Reader.Item("Cuadro1").ToString
                                    dgvGC_SHIMA.Rows(i - 20).Cells("C2_2").Value = Reader.Item("Cuadro2").ToString
                                    dgvGC_SHIMA.Rows(i - 20).Cells("DESC_2").Value = Reader.Item("Descripcion").ToString
                                End If
                            End If
                            i += 1
                        Loop
                        Reader.NextResult()
                    Loop

                    i = 0
                    sStr = "SELECT *,isnull(Sombreado,0) as Sombra FROM PrendasArtProdPlanillas_GM WHERE IdPlanilla = " + ID.ToString
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Reader = Command.ExecuteReader()
                    Do While Reader.HasRows
                        Do While Reader.Read
                            If TipoPlanilla = "STOLL" Then
                                If Reader.Item("Sombra") = 1 Then
                                    dgvGM_STOLL.Rows(i).Cells("chk").Value = True
                                Else
                                    dgvGM_STOLL.Rows(i).Cells("chk").Value = False
                                End If
                                dgvGM_STOLL.Rows(i).Cells("LETRA").Value = Reader.Item("Letra").ToString
                                dgvGM_STOLL.Rows(i).Cells("C1").Value = Reader.Item("Cuadro1").ToString
                                dgvGM_STOLL.Rows(i).Cells("C2").Value = Reader.Item("Cuadro2").ToString
                                dgvGM_STOLL.Rows(i).Cells("DESC").Value = Reader.Item("Descripcion").ToString
                            Else
                                If Reader.Item("Sombra") = 1 Then
                                    dgvGM_SHIMA.Rows(i).Cells("chk").Value = True
                                Else
                                    dgvGM_SHIMA.Rows(i).Cells("chk").Value = False
                                End If
                                dgvGM_SHIMA.Rows(i).Cells("LETRA").Value = Reader.Item("Letra").ToString
                                dgvGM_SHIMA.Rows(i).Cells("C1").Value = Reader.Item("Cuadro1").ToString
                                dgvGM_SHIMA.Rows(i).Cells("C2").Value = Reader.Item("Cuadro2").ToString
                                dgvGM_SHIMA.Rows(i).Cells("DESC").Value = Reader.Item("Descripcion").ToString
                            End If
                            i += 1
                        Loop
                        Reader.NextResult()
                    Loop

                    i = 0
                    sStr = "SELECT * FROM PrendasArtProdPlanillas_TC WHERE IdPlanilla = " + ID.ToString
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Reader = Command.ExecuteReader()
                    Do While Reader.HasRows
                        Do While Reader.Read

                            If i < 10 Then
                                If TipoPlanilla = "STOLL" Then
                                    dgvTC_STOLL.Rows(i).Cells("LETRA_1").Value = Reader.Item("Letra").ToString
                                    dgvTC_STOLL.Rows(i).Cells("C1_1").Value = Reader.Item("Cuadro1").ToString
                                    dgvTC_STOLL.Rows(i).Cells("C2_1").Value = Reader.Item("Cuadro2").ToString
                                    dgvTC_STOLL.Rows(i).Cells("C3_1").Value = Reader.Item("Cuadro3").ToString
                                    dgvTC_STOLL.Rows(i).Cells("C4_1").Value = Reader.Item("Cuadro4").ToString
                                    dgvTC_STOLL.Rows(i).Cells("DESC_1").Value = Reader.Item("Descripcion").ToString
                                Else
                                    dgvTC_SHIMA.Rows(i).Cells("LETRA_1").Value = Reader.Item("Letra").ToString
                                    dgvTC_SHIMA.Rows(i).Cells("C1_1").Value = Reader.Item("Cuadro1").ToString
                                    dgvTC_SHIMA.Rows(i).Cells("C2_1").Value = Reader.Item("Cuadro2").ToString
                                    dgvTC_SHIMA.Rows(i).Cells("C3_1").Value = Reader.Item("Cuadro3").ToString
                                    dgvTC_SHIMA.Rows(i).Cells("C4_1").Value = Reader.Item("Cuadro4").ToString
                                    dgvTC_SHIMA.Rows(i).Cells("DESC_1").Value = Reader.Item("Descripcion").ToString
                                End If
                            Else
                                If TipoPlanilla = "STOLL" Then
                                    dgvTC_STOLL.Rows(i - 10).Cells("LETRA_2").Value = Reader.Item("Letra").ToString
                                    dgvTC_STOLL.Rows(i - 10).Cells("C1_2").Value = Reader.Item("Cuadro1").ToString
                                    dgvTC_STOLL.Rows(i - 10).Cells("C2_2").Value = Reader.Item("Cuadro2").ToString
                                    dgvTC_STOLL.Rows(i - 10).Cells("C3_2").Value = Reader.Item("Cuadro3").ToString
                                    dgvTC_STOLL.Rows(i - 10).Cells("C4_2").Value = Reader.Item("Cuadro4").ToString
                                    dgvTC_STOLL.Rows(i - 10).Cells("DESC_2").Value = Reader.Item("Descripcion").ToString
                                Else
                                    dgvTC_SHIMA.Rows(i - 10).Cells("LETRA_2").Value = Reader.Item("Letra").ToString
                                    dgvTC_SHIMA.Rows(i - 10).Cells("C1_2").Value = Reader.Item("Cuadro1").ToString
                                    dgvTC_SHIMA.Rows(i - 10).Cells("C2_2").Value = Reader.Item("Cuadro2").ToString
                                    dgvTC_SHIMA.Rows(i - 10).Cells("C3_2").Value = Reader.Item("Cuadro3").ToString
                                    dgvTC_SHIMA.Rows(i - 10).Cells("C4_2").Value = Reader.Item("Cuadro4").ToString
                                    dgvTC_SHIMA.Rows(i - 10).Cells("DESC_2").Value = Reader.Item("Descripcion").ToString
                                End If
                            End If

                            i += 1
                        Loop
                        Reader.NextResult()
                    Loop

                    i = 0
                    sStr = "SELECT * FROM PrendasArtProdPlanillas_TM WHERE IdPlanilla = " + ID.ToString
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Reader = Command.ExecuteReader()
                    Do While Reader.HasRows
                        Do While Reader.Read
                            If TipoPlanilla = "STOLL" Then
                                dgvTM_STOLL.Rows(i).Cells("LETRA").Value = Reader.Item("Letra").ToString
                                dgvTM_STOLL.Rows(i).Cells("C1").Value = Reader.Item("Cuadro1").ToString
                                dgvTM_STOLL.Rows(i).Cells("C2").Value = Reader.Item("Cuadro2").ToString
                                dgvTM_STOLL.Rows(i).Cells("C3").Value = Reader.Item("Cuadro3").ToString
                                dgvTM_STOLL.Rows(i).Cells("C4").Value = Reader.Item("Cuadro4").ToString
                                dgvTM_STOLL.Rows(i).Cells("DESC").Value = Reader.Item("Descripcion").ToString
                            Else
                                dgvTM_SHIMA.Rows(i).Cells("LETRA").Value = Reader.Item("Letra").ToString
                                dgvTM_SHIMA.Rows(i).Cells("C1").Value = Reader.Item("Cuadro1").ToString
                                dgvTM_SHIMA.Rows(i).Cells("C2").Value = Reader.Item("Cuadro2").ToString
                                dgvTM_SHIMA.Rows(i).Cells("C3").Value = Reader.Item("Cuadro3").ToString
                                dgvTM_SHIMA.Rows(i).Cells("C4").Value = Reader.Item("Cuadro4").ToString
                                dgvTM_SHIMA.Rows(i).Cells("DESC").Value = Reader.Item("Descripcion").ToString
                            End If
                            i += 1
                        Loop
                        Reader.NextResult()
                    Loop

                    CargarCorrecciones()

                End If
            End If
        Else
            If TipoUsuario = "Programacion" Or TipoUsuario = "Administrador" Then
                If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
                sStr = "select NroPrograma from PrendasArtProdPlanillas where Id = (select max(id) from PrendasArtProdPlanillas where NroPrograma is not null)"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Reader = Command.ExecuteReader()
                If Reader.HasRows Then
                    If Reader.Read Then
                        txtNroPrograma.Text = CInt(Reader.Item("NroPrograma")) + 1
                    End If
                End If
            End If
            txtTalleXXLBretel_Tit.Text = "Capucha"
            txtTalleXXLEsc_Tit.Text = "Escote"
            txtTalleXXLBolsillo_Tit.Text = "Bolsillo"
            txtTalleXXLAncho_Tit.Text = "Ancho"
            txtTalleXXLLargo_Tit.Text = "Largo"
            txtTalleXLBretel_Tit.Text = "Capucha"
            txtTalleXLEsc_Tit.Text = "Escote"
            txtTalleXLBolsillo_Tit.Text = "Bolsillo"
            txtTalleXLAncho_Tit.Text = "Ancho"
            txtTalleXLLargo_Tit.Text = "Largo"
            txtTalleLBretel_Tit.Text = "Capucha"
            txtTalleLEsc_Tit.Text = "Escote"
            txtTalleLBolsillo_Tit.Text = "Bolsillo"
            txtTalleLAncho_Tit.Text = "Ancho"
            txtTalleLLargo_Tit.Text = "Largo"
            txtTalleMBretel_Tit.Text = "Capucha"
            txtTalleMEsc_Tit.Text = "Escote"
            txtTalleMBolsillo_Tit.Text = "Bolsillo"
            txtTalleMAncho_Tit.Text = "Ancho"
            txtTalleMLargo_Tit.Text = "Largo"
            txtTalleSBretel_Tit.Text = "Capucha"
            txtTalleSEsc_Tit.Text = "Escote"
            txtTalleSBolsillo_Tit.Text = "Bolsillo"
            txtTalleSAncho_Tit.Text = "Ancho"
            txtTalleSLargo_Tit.Text = "Largo"
            txtTalleXSBretel_Tit.Text = "Capucha"
            txtTalleXSEsc_Tit.Text = "Escote"
            txtTalleXSBolsillo_Tit.Text = "Bolsillo"
            txtTalleXSAncho_Tit.Text = "Ancho"
            txtTalleXSLargo_Tit.Text = "Largo"

            txtTitTalleXXL.Text = "XXL"
            txtTitTalleXL.Text = "XL"
            txtTitTalleL.Text = "L"
            txtTitTalleM.Text = "M"
            txtTitTalleS.Text = "S"
            txtTitTalleXS.Text = "XS"
            If TipoPlanilla = "STOLL" Then
                AcomodarTitulosyCuadrosSTOLL()
                CargarPicos()
            Else
                AcomodarTitulosyCuadrosSHIMA()
                CargarMallaVariable()
            End If

            chkMarcarComoOriginal.Visible = True
            btnPonerOriginal.Visible = False
            lblArtOriginal.Visible = False

        End If

        AcomodarTituloyDgvPesosyTiempos()

        CargarListadoAccesorios()

        If Alta Then
            Panel_Accesorios.Enabled = False
        Else
            Panel_Accesorios.Enabled = True
        End If

        RevisarPermisosUsuario()

        txtDiseño.Select()
    End Sub

    Private Sub RevisarPermisosUsuario()
        If TipoUsuario = "Administrador" Or TipoUsuario = "Programacion" Then
            txtTalleXXL_D_MedInicial.Enabled = True
            txtTalleXXL_E_MedInicial.Enabled = True
            txtTalleXXL_M_MedInicial.Enabled = True
            txtTalleXL_D_MedInicial.Enabled = True
            txtTalleXL_E_MedInicial.Enabled = True
            txtTalleXL_M_MedInicial.Enabled = True
            txtTalleL_D_MedInicial.Enabled = True
            txtTalleL_E_MedInicial.Enabled = True
            txtTalleL_M_MedInicial.Enabled = True
            txtTalleM_D_MedInicial.Enabled = True
            txtTalleM_E_MedInicial.Enabled = True
            txtTalleM_M_MedInicial.Enabled = True
            txtTalleS_D_MedInicial.Enabled = True
            txtTalleS_E_MedInicial.Enabled = True
            txtTalleS_M_MedInicial.Enabled = True
            txtTalleXS_D_MedInicial.Enabled = True
            txtTalleXS_E_MedInicial.Enabled = True
            txtTalleXS_M_MedInicial.Enabled = True
        Else
            txtTalleXXL_D_MedInicial.Enabled = False
            txtTalleXXL_E_MedInicial.Enabled = False
            txtTalleXXL_M_MedInicial.Enabled = False
            txtTalleXL_D_MedInicial.Enabled = False
            txtTalleXL_E_MedInicial.Enabled = False
            txtTalleXL_M_MedInicial.Enabled = False
            txtTalleL_D_MedInicial.Enabled = False
            txtTalleL_E_MedInicial.Enabled = False
            txtTalleL_M_MedInicial.Enabled = False
            txtTalleM_D_MedInicial.Enabled = False
            txtTalleM_E_MedInicial.Enabled = False
            txtTalleM_M_MedInicial.Enabled = False
            txtTalleS_D_MedInicial.Enabled = False
            txtTalleS_E_MedInicial.Enabled = False
            txtTalleS_M_MedInicial.Enabled = False
            txtTalleXS_D_MedInicial.Enabled = False
            txtTalleXS_E_MedInicial.Enabled = False
            txtTalleXS_M_MedInicial.Enabled = False
        End If
    End Sub

    Private Sub CargarCorrecciones()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String
        Dim row As String()
        Dim fechaaux, corraux As String

        LimpiarDGV()
        ArmarDGV()

        Dim i As Integer = 0
        sStr = "SELECT * FROM PrendasArtProdPlanillasCorrecciones WHERE IdPlanilla = " + ID.ToString + " order by id "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read
                fechaaux = ""
                If Not IsDBNull(Reader.Item("Fecha")) Then
                    fechaaux = Reader.Item("Fecha").ToString
                End If
                corraux = ""
                If Not IsDBNull(Reader.Item("Correccion")) Then
                    corraux = Reader.Item("Correccion").ToString
                End If

                row = {Reader.Item("Id"), fechaaux, corraux}
                dgvCorrecciones.Rows.Add(row)
                i += 1
            Loop
            Reader.NextResult()
        Loop

        Do While i < 35
            row = {"", "", ""}
            dgvCorrecciones.Rows.Add(row)
            i += 1
        Loop

    End Sub

    Private Sub LimpiarDGV()
        dgvCorrecciones.Rows.Clear()
        dgvCorrecciones.Columns.Clear()
    End Sub

    Private Sub ArmarDGV()

        dgvCorrecciones.Columns.Add("IDCORRECCION", "IDCORRECCION")
        dgvCorrecciones.Columns("IDCORRECCION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvCorrecciones.Columns("IDCORRECCION").Visible = False
        dgvCorrecciones.Columns.Add("FECHA", "FECHA")
        dgvCorrecciones.Columns("FECHA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvCorrecciones.Columns("FECHA").Width = 96
        dgvCorrecciones.Columns.Add("CORRECCION", "CORRECCION")
        dgvCorrecciones.Columns("CORRECCION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvCorrecciones.Columns("CORRECCION").Width = 202

        dgvCorrecciones.RowHeadersVisible = False
        dgvCorrecciones.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 10)
        dgvCorrecciones.DefaultCellStyle.Font = New Font("Tahoma", 10)
        dgvCorrecciones.RowTemplate.Height = 22

    End Sub

    Private Sub CargarMallaVariable()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String
        Dim row As String()

        LimpiarDGV_MallaVariable()
        ArmarDGV_MallaVariable()

        Dim i As Integer = 0
        sStr = "SELECT * FROM PrendasArtProdPlanillas_MallasVariables WHERE IdPlanilla = " + ID.ToString + " order by id "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read
                row = {Reader.Item("Id"), Reader.Item("MallaVariable"), Reader.Item("Malla_D"), Reader.Item("Malla_T"), Reader.Item("Malla_Desc")}
                dgvMallaVariable.Rows.Add(row)
                i += 1
            Loop
            Reader.NextResult()
        Loop

        Do While i < 14
            row = {"", "", "", "", "", "", "", ""}
            dgvMallaVariable.Rows.Add(row)
            i += 1
        Loop

    End Sub

    Private Sub LimpiarDGV_MallaVariable()
        dgvMallaVariable.Rows.Clear()
        dgvMallaVariable.Columns.Clear()
    End Sub

    Private Sub ArmarDGV_MallaVariable()

        dgvMallaVariable.Columns.Add("IDMALLA", "IDMALLA")
        dgvMallaVariable.Columns("IDMALLA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvMallaVariable.Columns("IDMALLA").Visible = False
        dgvMallaVariable.Columns.Add("MALLA", "MALLA")
        dgvMallaVariable.Columns("MALLA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvMallaVariable.Columns("MALLA").Width = 119
        dgvMallaVariable.Columns.Add("MALLA_D", "MALLA_D")
        dgvMallaVariable.Columns("MALLA_D").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvMallaVariable.Columns("MALLA_D").Width = 38
        dgvMallaVariable.Columns.Add("MALLA_T", "MALLA_T")
        dgvMallaVariable.Columns("MALLA_T").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvMallaVariable.Columns("MALLA_T").Width = 38
        dgvMallaVariable.Columns.Add("MALLA_DESC", "MALLA_DESC")
        dgvMallaVariable.Columns("MALLA_DESC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvMallaVariable.Columns("MALLA_DESC").Width = 121

        dgvMallaVariable.ColumnHeadersVisible = False
        dgvMallaVariable.RowHeadersVisible = False
        dgvMallaVariable.DefaultCellStyle.Font = New Font("Tahoma", 9)
        dgvMallaVariable.RowTemplate.Height = 19

    End Sub

    Private Sub CargarPicos()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String
        Dim row As String()

        LimpiarDGV_Picos()
        ArmarDGV_Picos()

        Dim i As Integer = 0
        sStr = "SELECT * FROM PrendasArtProdPlanillas_Picos WHERE IdPlanilla = " + ID.ToString + " order by id "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read
                row = {Reader.Item("Id"), Reader.Item("Pico"), Reader.Item("Cuerpo_C1"), Reader.Item("Cuerpo_C2"), Reader.Item("Cuerpo_C3"), Reader.Item("Manga_C1") _
                      , Reader.Item("Manga_C2"), Reader.Item("Manga_C3")}
                dgvPicos.Rows.Add(row)
                i += 1
            Loop
            Reader.NextResult()
        Loop

        Do While i < 8
            row = {"", "", "", "", "", "", "", ""}
            dgvPicos.Rows.Add(row)
            i += 1
        Loop
    End Sub

    Private Sub LimpiarDGV_Picos()
        dgvPicos.Rows.Clear()
        dgvPicos.Columns.Clear()
    End Sub

    Private Sub ArmarDGV_Picos()

        dgvPicos.Columns.Add("IDPICO", "IDPICO")
        dgvPicos.Columns("IDPICO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPicos.Columns("IDPICO").Visible = False
        dgvPicos.Columns.Add("PICO", "PICO")
        dgvPicos.Columns("PICO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPicos.Columns("PICO").Width = 99
        dgvPicos.Columns.Add("CUERPO_C1", "CUERPO_C1")
        dgvPicos.Columns("CUERPO_C1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPicos.Columns("CUERPO_C1").Width = 36
        dgvPicos.Columns.Add("CUERPO_C2", "CUERPO_C2")
        dgvPicos.Columns("CUERPO_C2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPicos.Columns("CUERPO_C2").Width = 36
        dgvPicos.Columns.Add("CUERPO_C3", "CUERPO_C3")
        dgvPicos.Columns("CUERPO_C3").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPicos.Columns("CUERPO_C3").Width = 37
        dgvPicos.Columns.Add("MANGA_C1", "MANGA_C1")
        dgvPicos.Columns("MANGA_C1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPicos.Columns("MANGA_C1").Width = 36
        dgvPicos.Columns.Add("MANGA_C2", "MANGA_C2")
        dgvPicos.Columns("MANGA_C2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPicos.Columns("MANGA_C2").Width = 36
        dgvPicos.Columns.Add("MANGA_C3", "MANGA_C3")
        dgvPicos.Columns("MANGA_C3").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPicos.Columns("MANGA_C3").Width = 36

        dgvPicos.ColumnHeadersVisible = False
        dgvPicos.RowHeadersVisible = False
        dgvPicos.DefaultCellStyle.Font = New Font("Tahoma", 9)
        dgvPicos.RowTemplate.Height = 19

    End Sub

    Private Sub CargarCategorias()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        'si las categorias ya estan cargadas es que estoy entrando porque llame al procedimiento cargar desde otro lado, pero no estoy cargando la primer vez
        'solo cargo las categorias la primer vez, que entra al formulario, despues no, asi cuando cambia la seleccion del combo por ejemplo no borro nada

        If cmbCategoria.Items.Count > 0 Then Exit Sub

        cmbCategoria.Items.Clear()
        ColCategoriaIdsClaves.Clear()
        ColCategoria.Clear()

        sStr = "SELECT * FROM PrendasArtProdCategorias WHERE Eliminado = 0 Order by Descripcion"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read
                cmbCategoria.Items.Add(Reader.Item("Descripcion").ToString)
                ColCategoria.Add(Reader.Item("id").ToString, Reader.Item("Descripcion").ToString)
                ColCategoriaIdsClaves.Add(Reader.Item("Descripcion").ToString, Reader.Item("id").ToString)
            Loop
            Reader.NextResult()
        Loop

    End Sub

    Private Sub cmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click

            Guardar()
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        If EstoyCopiando Then
            If MsgBox("Aun no ha guardado el artículo que se ha copiado." + Chr(10) + "Si sale ahora se perderán los datos." + _
                      Chr(10) + "¿Está seguro de salir?", vbYesNo, "Textilana S. A.") = vbNo Then Exit Sub
            EliminarPlanillaCopiada(ID)
        End If

        Close()
    End Sub

    Private Sub frmArtProdABM_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If EstoyCopiando Then
            If MsgBox("Aun no ha guardado el artículo que se ha copiado." + Chr(10) + "Si sale ahora se perderán los datos." + _
                      Chr(10) + "¿Está seguro de salir?", vbYesNo, "Textilana S. A.") = vbNo Then
                e.Cancel = True
            Else
                EliminarPlanillaCopiada(ID)
            End If
        End If
    End Sub

    Private Sub Guardar()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        Dim EsArtOriginal As String
        Dim auxRutaImagen As String
        Dim Sombreado As String = ""

        Dim i As Integer

        If Not Validar() Then Exit Sub

        If txtRutaImagen.Text <> "" Then
            auxRutaImagen = "'" + txtRutaImagen.Text + "'"
        Else
            auxRutaImagen = "NULL"
        End If

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        If Alta Then
            If chkMarcarComoOriginal.Checked Then
                EsArtOriginal = "1"
            Else
                EsArtOriginal = "0"
            End If
            'Antes de insertar si en un alta el nro de programa ya existe entonces hay que buscar el nuevo ultimo nro de programa
            If TipoUsuario = "Programacion" Or TipoUsuario = "Administrador" Then
                If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
                sStr = "select NroPrograma from PrendasArtProdPlanillas where Id = (select max(id) from PrendasArtProdPlanillas)"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Reader = Command.ExecuteReader()
                If Reader.HasRows Then
                    If Reader.Read Then
                        If CInt(txtNroPrograma.Text) < CInt(Reader.Item("NroPrograma")) Then

                            txtNroPrograma.Text = Reader.Item("NroPrograma")
                            MsgBox("El número de programa fue modificado a: " + txtNroPrograma.Text, MsgBoxStyle.OkOnly, "Aviso")
                        End If
                    End If
                End If
            End If
            
            sStr = "INSERT INTO PrendasArtProdPlanillas (NroPrograma, IdCategoria,Fecha,Articulo,OP,Diseño,Color,Partida,Ventana,VentanaEspalda,VentanaManga,VentanaCapucha,MedidaElastico,CondicionCuerpos,VelocidadCuerpos"
            sStr = sStr + ",MedidaPuño,CondicionMangas,VelocidadMangas,TalleXXL_D,TalleXXL_E,TalleXXL_Bretel,TalleXXL_Esc,TalleXXL_Bolsillo,TalleXXL_Ancho,TalleXXL_Largo"
            sStr = sStr + ",TalleXXL_CueParamInicio,TalleXXL_CueCantAgujas,TalleXXL_Manga,TalleXXL_MangaParamInicio,TalleXXL_MangaCantAgujas,TalleXXL_MedInicial_D"
            sStr = sStr + ",TalleXXL_MedInicial_E,TalleXXL_MedInicial_M,TalleXL_D,TalleXL_E,TalleXL_Bretel,TalleXL_Esc,TalleXL_Bolsillo,TalleXL_Ancho,TalleXL_Largo"
            sStr = sStr + ",TalleXL_CueParamInicio,TalleXL_CueCantAgujas,TalleXL_Manga,TalleXL_MangaParamInicio,TalleXL_MangaCantAgujas,TalleXL_MedInicial_D"
            sStr = sStr + ",TalleXL_MedInicial_E,TalleXL_MedInicial_M,TalleL_D,TalleL_E,TalleL_Bretel,TalleL_Esc,TalleL_Bolsillo,TalleL_Ancho,TalleL_Largo"
            sStr = sStr + ",TalleL_CueParamInicio,TalleL_CueCantAgujas,TalleL_Manga,TalleL_MangaParamInicio,TalleL_MangaCantAgujas,TalleL_MedInicial_D,TalleL_MedInicial_E"
            sStr = sStr + ",TalleL_MedInicial_M,TalleM_D,TalleM_E,TalleM_Bretel,TalleM_Esc,TalleM_Bolsillo,TalleM_Ancho,TalleM_Largo,TalleM_CueParamInicio"
            sStr = sStr + ",TalleM_CueCantAgujas,TalleM_Manga,TalleM_MangaParamInicio,TalleM_MangaCantAgujas,TalleM_MedInicial_D,TalleM_MedInicial_E,TalleM_MedInicial_M"
            sStr = sStr + ",TalleS_D,TalleS_E,TalleS_Bretel,TalleS_Esc,TalleS_Bolsillo,TalleS_Ancho,TalleS_Largo,TalleS_CueParamInicio,TalleS_CueCantAgujas"
            sStr = sStr + ",TalleS_Manga,TalleS_MangaParamInicio,TalleS_MangaCantAgujas,TalleS_MedInicial_D,TalleS_MedInicial_E,TalleS_MedInicial_M,TalleXS_D"
            sStr = sStr + ",TalleXS_E,TalleXS_Bretel,TalleXS_Esc,TalleXS_Bolsillo,TalleXS_Ancho,TalleXS_Largo,TalleXS_CueParamInicio,TalleXS_CueCantAgujas,TalleXS_Manga"
            sStr = sStr + ",TalleXS_MangaParamInicio,TalleXS_MangaCantAgujas,TalleXS_MedInicial_D,TalleXS_MedInicial_E,TalleXS_MedInicial_M,EsOriginal"
            sStr = sStr + ",TitTalleXXL,TitTalleXL,TitTalleL,TitTalleM,TitTalleS,TitTalleXS,[TalleXXL_Bretel_Tit],[TalleXXL_Esc_Tit],[TalleXXL_Bolsillo_Tit],[TalleXXL_Ancho_Tit]"
            sStr = sStr + ",[TalleXXL_Largo_Tit],[TalleXL_Bretel_Tit],[TalleXL_Esc_Tit],[TalleXL_Bolsillo_Tit],[TalleXL_Ancho_Tit],[TalleXL_Largo_Tit],[TalleL_Bretel_Tit],[TalleL_Esc_Tit]"
            sStr = sStr + ",[TalleL_Bolsillo_Tit],[TalleL_Ancho_Tit],[TalleL_Largo_Tit],[TalleM_Bretel_Tit],[TalleM_Esc_Tit],[TalleM_Bolsillo_Tit],[TalleM_Ancho_Tit],[TalleM_Largo_Tit]"
            sStr = sStr + ",[TalleS_Bretel_Tit],[TalleS_Esc_Tit],[TalleS_Bolsillo_Tit],[TalleS_Ancho_Tit],[TalleS_Largo_Tit],[TalleXS_Bretel_Tit],[TalleXS_Esc_Tit],[TalleXS_Bolsillo_Tit]"
            sStr = sStr + ",[TalleXS_Ancho_Tit],[TalleXS_Largo_Tit],RutaImagen,TieneProgramaTerminado) VALUES ("
            sStr = sStr + "" + txtNroPrograma.Text + ", " + ColCategoria.Item(cmbCategoria.Text) + ",'" + Format(dtpFecha.Value, "yyyyMMdd") + "','" + txtArticulo.Text + "','" + txtOp.Text + "','" + txtDiseño.Text + "'"
            sStr = sStr + ",'" + txtColor.Text + "','" + txtPartida.Text + "','" + txtVentDel.Text + "','" + txtVentEsp.Text + "','" + txtVentMan.Text + "','" + txtVentCap.Text + "'"
            sStr = sStr + ",'" + txtMedidaElastico.Text + "','" + txtCondicionCuerpos.Text + "','" + txtVelocidadCuerpos.Text + "','" + txtMedidaPuño.Text + "','" + txtCondicionMangas.Text + "'"
            sStr = sStr + ",'" + txtVelocidadMangas.Text + "','" + txtTalleXXL_D.Text + "','" + txtTalleXXL_E.Text + "','" + txtTalleXXLBretel.Text + "','" + txtTalleXXLEsc.Text + "'"
            sStr = sStr + ",'" + txtTalleXXLBolsillo.Text + "','" + txtTalleXXLAncho.Text + "','" + txtTalleXXLLargo.Text + "','" + txtTalleXXL_CuerParamInicio.Text + "'"
            sStr = sStr + ",'" + txtTalleXXL_CuerCantAgujas.Text + "','" + txtTalleXXL_Manga.Text + "','" + txtTalleXXL_MangaParamInicio.Text + "','" + txtTalleXXL_MangaCantAgujas.Text + "'"
            sStr = sStr + ",'" + txtTalleXXL_D_MedInicial.Text + "','" + txtTalleXXL_E_MedInicial.Text + "','" + txtTalleXXL_M_MedInicial.Text + "'"
            sStr = sStr + ",'" + txtTalleXL_D.Text + "','" + txtTalleXL_E.Text + "','" + txtTalleXLBretel.Text + "','" + txtTalleXLEsc.Text + "'"
            sStr = sStr + ",'" + txtTalleXLBolsillo.Text + "','" + txtTalleXLAncho.Text + "','" + txtTalleXLLargo.Text + "','" + txtTalleXL_CuerParamInicio.Text + "'"
            sStr = sStr + ",'" + txtTalleXL_CuerCantAgujas.Text + "','" + txtTalleXL_Manga.Text + "','" + txtTalleXL_MangaParamInicio.Text + "','" + txtTalleXL_MangaCantAgujas.Text + "'"
            sStr = sStr + ",'" + txtTalleXL_D_MedInicial.Text + "','" + txtTalleXL_E_MedInicial.Text + "','" + txtTalleXL_M_MedInicial.Text + "'"
            sStr = sStr + ",'" + txtTalleL_D.Text + "','" + txtTalleL_E.Text + "','" + txtTalleLBretel.Text + "','" + txtTalleLEsc.Text + "'"
            sStr = sStr + ",'" + txtTalleLBolsillo.Text + "','" + txtTalleLAncho.Text + "','" + txtTalleLLargo.Text + "','" + txtTalleL_CuerParamInicio.Text + "'"
            sStr = sStr + ",'" + txtTalleL_CuerCantAgujas.Text + "','" + txtTalleL_Manga.Text + "','" + txtTalleL_MangaParamInicio.Text + "','" + txtTalleL_MangaCantAgujas.Text + "'"
            sStr = sStr + ",'" + txtTalleL_D_MedInicial.Text + "','" + txtTalleL_E_MedInicial.Text + "','" + txtTalleL_M_MedInicial.Text + "'"
            sStr = sStr + ",'" + txtTalleM_D.Text + "','" + txtTalleM_E.Text + "','" + txtTalleMBretel.Text + "','" + txtTalleMEsc.Text + "'"
            sStr = sStr + ",'" + txtTalleMBolsillo.Text + "','" + txtTalleMAncho.Text + "','" + txtTalleMLargo.Text + "','" + txtTalleM_CuerParamInicio.Text + "'"
            sStr = sStr + ",'" + txtTalleM_CuerCantAgujas.Text + "','" + txtTalleM_Manga.Text + "','" + txtTalleM_MangaParamInicio.Text + "','" + txtTalleM_MangaCantAgujas.Text + "'"
            sStr = sStr + ",'" + txtTalleM_D_MedInicial.Text + "','" + txtTalleM_E_MedInicial.Text + "','" + txtTalleM_M_MedInicial.Text + "'"
            sStr = sStr + ",'" + txtTalleS_D.Text + "','" + txtTalleS_E.Text + "','" + txtTalleSBretel.Text + "','" + txtTalleSEsc.Text + "'"
            sStr = sStr + ",'" + txtTalleSBolsillo.Text + "','" + txtTalleSAncho.Text + "','" + txtTalleSLargo.Text + "','" + txtTalleS_CuerParamInicio.Text + "'"
            sStr = sStr + ",'" + txtTalleS_CuerCantAgujas.Text + "','" + txtTalleS_Manga.Text + "','" + txtTalleS_MangaParamInicio.Text + "','" + txtTalleS_MangaCantAgujas.Text + "'"
            sStr = sStr + ",'" + txtTalleS_D_MedInicial.Text + "','" + txtTalleS_E_MedInicial.Text + "','" + txtTalleS_M_MedInicial.Text + "'"
            sStr = sStr + ",'" + txtTalleXS_D.Text + "','" + txtTalleXS_E.Text + "','" + txtTalleXSBretel.Text + "','" + txtTalleXSEsc.Text + "'"
            sStr = sStr + ",'" + txtTalleXSBolsillo.Text + "','" + txtTalleXSAncho.Text + "','" + txtTalleXSLargo.Text + "','" + txtTalleXS_CuerParamInicio.Text + "'"
            sStr = sStr + ",'" + txtTalleXS_CuerCantAgujas.Text + "','" + txtTalleXS_Manga.Text + "','" + txtTalleXS_MangaParamInicio.Text + "','" + txtTalleXS_MangaCantAgujas.Text + "'"
            sStr = sStr + ",'" + txtTalleXS_D_MedInicial.Text + "','" + txtTalleXS_E_MedInicial.Text + "','" + txtTalleXS_M_MedInicial.Text + "'," + EsArtOriginal
            sStr = sStr + ",'" + txtTitTalleXXL.Text + "','" + txtTitTalleXL.Text + "','" + txtTitTalleL.Text + "','" + txtTitTalleM.Text + "','" + txtTitTalleS.Text + "','" + txtTitTalleXS.Text + "'"
            sStr = sStr + ",'" + txtTalleXXLBretel_Tit.Text + "','" + txtTalleXXLEsc_Tit.Text + "','" + txtTalleXXLBolsillo_Tit.Text + "','" + txtTalleXXLAncho_Tit.Text + "','" + txtTalleXXLLargo_Tit.Text + "'"
            sStr = sStr + ",'" + txtTalleXLBretel_Tit.Text + "','" + txtTalleXLEsc_Tit.Text + "','" + txtTalleXLBolsillo_Tit.Text + "','" + txtTalleXLAncho_Tit.Text + "','" + txtTalleXLLargo_Tit.Text + "'"
            sStr = sStr + ",'" + txtTalleLBretel_Tit.Text + "','" + txtTalleLEsc_Tit.Text + "','" + txtTalleLBolsillo_Tit.Text + "','" + txtTalleLAncho_Tit.Text + "','" + txtTalleLLargo_Tit.Text + "'"
            sStr = sStr + ",'" + txtTalleMBretel_Tit.Text + "','" + txtTalleMEsc_Tit.Text + "','" + txtTalleMBolsillo_Tit.Text + "','" + txtTalleMAncho_Tit.Text + "','" + txtTalleMLargo_Tit.Text + "'"
            sStr = sStr + ",'" + txtTalleSBretel_Tit.Text + "','" + txtTalleSEsc_Tit.Text + "','" + txtTalleSBolsillo_Tit.Text + "','" + txtTalleSAncho_Tit.Text + "','" + txtTalleSLargo_Tit.Text + "'"
            sStr = sStr + ",'" + txtTalleXSBretel_Tit.Text + "','" + txtTalleXSEsc_Tit.Text + "','" + txtTalleXSBolsillo_Tit.Text + "','" + txtTalleXSAncho_Tit.Text + "','" + txtTalleXSLargo_Tit.Text + "'"
            sStr = sStr + ", " + auxRutaImagen + "," + ElArticuloTieneProgramaTerminado.ToString + ")"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()

            'una vez que inserto traigo el id asi inserto las demas cosas
            sStr = "SELECT max(id) as Id FROM PrendasArtProdPlanillas "
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read Then
                    ID = Reader.Item("Id").ToString
                End If
            End If

            'ya dejo guardadas las medidas de tiempo y peso
            sStr = "INSERT INTO PrendasArtProdPlanillas_TP (IdPlanilla,T_XXS,T_XS,T_S,T_M,T_L,T_XL,T_XXL,T_U,P_XXS,P_XS,P_S,P_M,P_L,P_XL,P_XXL,P_U,T_XXXL,P_XXXL) VALUES ("
            sStr = sStr + ID.ToString + ", '" + dgvTiempoyPeso.Rows(0).Cells("XXS").Value.ToString.Replace("'", "´") + "', '" + dgvTiempoyPeso.Rows(0).Cells("XS").Value.ToString + "', '"
            sStr = sStr + dgvTiempoyPeso.Rows(0).Cells("S").Value.ToString.Replace("'", "´") + "', '" + dgvTiempoyPeso.Rows(0).Cells("M").Value.ToString + "', '"
            sStr = sStr + dgvTiempoyPeso.Rows(0).Cells("L").Value.ToString.Replace("'", "´") + "', '" + dgvTiempoyPeso.Rows(0).Cells("XL").Value.ToString + "', '"
            sStr = sStr + dgvTiempoyPeso.Rows(0).Cells("XXL").Value.ToString.Replace("'", "´") + "', '" + dgvTiempoyPeso.Rows(0).Cells("U").Value.ToString + "', '"
            sStr = sStr + dgvTiempoyPeso.Rows(1).Cells("XXS").Value.ToString.Replace("'", "´") + "', '" + dgvTiempoyPeso.Rows(1).Cells("XS").Value.ToString + "', '"
            sStr = sStr + dgvTiempoyPeso.Rows(1).Cells("S").Value.ToString.Replace("'", "´") + "', '" + dgvTiempoyPeso.Rows(1).Cells("M").Value.ToString + "', '"
            sStr = sStr + dgvTiempoyPeso.Rows(1).Cells("L").Value.ToString.Replace("'", "´") + "', '" + dgvTiempoyPeso.Rows(1).Cells("XL").Value.ToString + "', '"
            sStr = sStr + dgvTiempoyPeso.Rows(1).Cells("XXL").Value.ToString.Replace("'", "´") + "', '" + dgvTiempoyPeso.Rows(1).Cells("U").Value.ToString + "', '"
            sStr = sStr + dgvTiempoyPeso.Rows(0).Cells("XXXL").Value.ToString.Replace("'", "´") + "', '" + dgvTiempoyPeso.Rows(1).Cells("XXXL").Value.ToString + "')"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()

            If TipoPlanilla = "STOLL" Then

                'primero los picos
                For i = 0 To 7
                    sStr = "INSERT INTO PrendasArtProdPlanillas_Picos (IdPlanilla,Pico,Cuerpo_C1,Cuerpo_C2,Cuerpo_C3,Manga_C1,Manga_C2,Manga_C3) VALUES ("
                    sStr = sStr + ID.ToString + ", '" + dgvPicos.Rows(i).Cells("Pico").Value + "', '" + dgvPicos.Rows(i).Cells("Cuerpo_C1").Value + "', '"
                    sStr = sStr + dgvPicos.Rows(i).Cells("Cuerpo_C2").Value + "', '" + dgvPicos.Rows(i).Cells("Cuerpo_C3").Value + "', '"
                    sStr = sStr + dgvPicos.Rows(i).Cells("Manga_C1").Value + "', '" + dgvPicos.Rows(i).Cells("Manga_C2").Value + "', '"
                    sStr = sStr + dgvPicos.Rows(i).Cells("Manga_C3").Value + "')"
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                Next
                For i = 0 To 19
                    If dgvGC_STOLL.Rows(i).Cells("DESC_1").Value.ToString <> "*************" Then
                        If dgvGC_STOLL.Rows(i).Cells("chk_1").Value = True Then
                            Sombreado = "1"
                        Else
                            Sombreado = "0"
                        End If
                        sStr = "INSERT INTO PrendasArtProdPlanillas_GC (IdPlanilla,Letra,Cuadro1,Cuadro2,Descripcion,Sombreado) VALUES (" + ID.ToString
                        sStr = sStr + ",'" + dgvGC_STOLL.Rows(i).Cells("LETRA_1").Value.ToString + "','" + dgvGC_STOLL.Rows(i).Cells("C1_1").Value.ToString + "','" + dgvGC_STOLL.Rows(i).Cells("C2_1").Value.ToString + "','" + dgvGC_STOLL.Rows(i).Cells("DESC_1").Value.ToString + "'," + Sombreado + ") "
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Next
                For i = 0 To 19
                    If dgvGC_STOLL.Rows(i).Cells("DESC_2").Value.ToString <> "*************" Then
                        If dgvGC_STOLL.Rows(i).Cells("chk_2").Value = True Then
                            Sombreado = "1"
                        Else
                            Sombreado = "0"
                        End If
                        sStr = "INSERT INTO PrendasArtProdPlanillas_GC (IdPlanilla,Letra,Cuadro1,Cuadro2,Descripcion,Sombreado) VALUES (" + ID.ToString
                        sStr = sStr + ",'" + dgvGC_STOLL.Rows(i).Cells("LETRA_2").Value.ToString + "','" + dgvGC_STOLL.Rows(i).Cells("C1_2").Value.ToString + "','" + dgvGC_STOLL.Rows(i).Cells("C2_2").Value.ToString + "','" + dgvGC_STOLL.Rows(i).Cells("DESC_2").Value.ToString + "'," + Sombreado + ") "
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Next
                For i = 0 To 19
                    If dgvGM_STOLL.Rows(i).Cells("DESC").Value.ToString <> "*************" Then
                        If dgvGM_STOLL.Rows(i).Cells("chk").Value = True Then
                            Sombreado = "1"
                        Else
                            Sombreado = "0"
                        End If
                        sStr = "INSERT INTO PrendasArtProdPlanillas_GM (IdPlanilla,Letra,Cuadro1,Cuadro2,Descripcion,Sombreado) VALUES (" + ID.ToString
                        sStr = sStr + ",'" + dgvGM_STOLL.Rows(i).Cells("LETRA").Value.ToString + "','" + dgvGM_STOLL.Rows(i).Cells("C1").Value.ToString + "','" + dgvGM_STOLL.Rows(i).Cells("C2").Value.ToString + "','" + dgvGM_STOLL.Rows(i).Cells("DESC").Value.ToString + "'," + Sombreado + ") "
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Next
                For i = 0 To 9
                    If dgvTC_STOLL.Rows(i).Cells("DESC_1").Value.ToString <> "*************" Then
                        sStr = "INSERT INTO PrendasArtProdPlanillas_TC (IdPlanilla,Letra,Cuadro1,Cuadro2,Cuadro3,Cuadro4,Descripcion) VALUES (" + ID.ToString
                        sStr = sStr + ",'" + dgvTC_STOLL.Rows(i).Cells("LETRA_1").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C1_1").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C2_1").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C3_1").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C4_1").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("DESC_1").Value.ToString + "') "
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Next
                For i = 0 To 9
                    If dgvTC_STOLL.Rows(i).Cells("DESC_2").Value.ToString <> "*************" Then
                        sStr = "INSERT INTO PrendasArtProdPlanillas_TC (IdPlanilla,Letra,Cuadro1,Cuadro2,Cuadro3,Cuadro4,Descripcion) VALUES (" + ID.ToString
                        sStr = sStr + ",'" + dgvTC_STOLL.Rows(i).Cells("LETRA_2").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C1_2").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C2_2").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C3_2").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C4_2").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("DESC_2").Value.ToString + "') "
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Next
                For i = 0 To 9
                    If dgvTM_STOLL.Rows(i).Cells("DESC").Value.ToString <> "*************" Then
                        sStr = "INSERT INTO PrendasArtProdPlanillas_TM (IdPlanilla,Letra,Cuadro1,Cuadro2,Cuadro3,Cuadro4,Descripcion) VALUES (" + ID.ToString
                        sStr = sStr + ",'" + dgvTM_STOLL.Rows(i).Cells("LETRA").Value.ToString + "','" + dgvTM_STOLL.Rows(i).Cells("C1").Value.ToString + "','" + dgvTM_STOLL.Rows(i).Cells("C2").Value.ToString + "','" + dgvTM_STOLL.Rows(i).Cells("C3").Value.ToString + "','" + dgvTM_STOLL.Rows(i).Cells("C4").Value.ToString + "','" + dgvTM_STOLL.Rows(i).Cells("DESC").Value.ToString + "') "
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Next
            Else
                'primero las mallas variables
                For i = 0 To 13
                    sStr = "INSERT INTO PrendasArtProdPlanillas_MallasVariables (IdPlanilla,MallaVariable,Malla_D,Malla_T,Malla_Desc) VALUES ("
                    sStr = sStr + ID.ToString + ", '" + dgvMallaVariable.Rows(i).Cells("MALLA").Value + "', '" + dgvMallaVariable.Rows(i).Cells("MALLA_D").Value + "', '"
                    sStr = sStr + dgvMallaVariable.Rows(i).Cells("MALLA_T").Value + "', '" + dgvMallaVariable.Rows(i).Cells("MALLA_DESC").Value + "')"
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                Next
                For i = 0 To 19
                    If dgvGC_SHIMA.Rows(i).Cells("DESC_1").Value.ToString <> "*************" Then
                        If dgvGC_SHIMA.Rows(i).Cells("chk_1").Value = True Then
                            Sombreado = "1"
                        Else
                            Sombreado = "0"
                        End If
                        sStr = "INSERT INTO PrendasArtProdPlanillas_GC (IdPlanilla,Letra,Cuadro1,Cuadro2,Descripcion,Sombreado) VALUES (" + ID.ToString
                        sStr = sStr + ",'" + dgvGC_SHIMA.Rows(i).Cells("LETRA_1").Value.ToString + "','" + dgvGC_SHIMA.Rows(i).Cells("C1_1").Value.ToString + "','" + dgvGC_SHIMA.Rows(i).Cells("C2_1").Value.ToString + "','" + dgvGC_SHIMA.Rows(i).Cells("DESC_1").Value.ToString + "'," + Sombreado + ") "
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Next
                For i = 0 To 19
                    If dgvGC_SHIMA.Rows(i).Cells("DESC_2").Value.ToString <> "*************" Then
                        If dgvGC_SHIMA.Rows(i).Cells("chk_2").Value = True Then
                            Sombreado = "1"
                        Else
                            Sombreado = "0"
                        End If
                        sStr = "INSERT INTO PrendasArtProdPlanillas_GC (IdPlanilla,Letra,Cuadro1,Cuadro2,Descripcion,Sombreado) VALUES (" + ID.ToString
                        sStr = sStr + ",'" + dgvGC_SHIMA.Rows(i).Cells("LETRA_2").Value.ToString + "','" + dgvGC_SHIMA.Rows(i).Cells("C1_2").Value.ToString + "','" + dgvGC_SHIMA.Rows(i).Cells("C2_2").Value.ToString + "','" + dgvGC_SHIMA.Rows(i).Cells("DESC_2").Value.ToString + "'," + Sombreado + ") "
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Next
                For i = 0 To 19
                    If dgvGM_SHIMA.Rows(i).Cells("DESC").Value.ToString <> "*************" Then
                        If dgvGM_SHIMA.Rows(i).Cells("chk").Value = True Then
                            Sombreado = "1"
                        Else
                            Sombreado = "0"
                        End If
                        sStr = "INSERT INTO PrendasArtProdPlanillas_GM (IdPlanilla,Letra,Cuadro1,Cuadro2,Descripcion,Sombreado) VALUES (" + ID.ToString
                        sStr = sStr + ",'" + dgvGM_SHIMA.Rows(i).Cells("LETRA").Value.ToString + "','" + dgvGM_SHIMA.Rows(i).Cells("C1").Value.ToString + "','" + dgvGM_SHIMA.Rows(i).Cells("C2").Value.ToString + "','" + dgvGM_SHIMA.Rows(i).Cells("DESC").Value.ToString + "'," + Sombreado + ") "
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Next
                For i = 0 To 9
                    If dgvTC_SHIMA.Rows(i).Cells("DESC_1").Value.ToString <> "*************" Then
                        sStr = "INSERT INTO PrendasArtProdPlanillas_TC (IdPlanilla,Letra,Cuadro1,Cuadro2,Cuadro3,Cuadro4,Descripcion) VALUES (" + ID.ToString
                        sStr = sStr + ",'" + dgvTC_SHIMA.Rows(i).Cells("LETRA_1").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("C1_1").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("C2_1").Value.ToString + "'"
                        sStr = sStr + ",'" + dgvTC_SHIMA.Rows(i).Cells("C3_1").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("C4_1").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("DESC_1").Value.ToString + "') "
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Next
                For i = 0 To 9
                    If dgvTC_SHIMA.Rows(i).Cells("DESC_2").Value.ToString <> "*************" Then
                        sStr = "INSERT INTO PrendasArtProdPlanillas_TC (IdPlanilla,Letra,Cuadro1,Cuadro2,Cuadro3,Cuadro4,Descripcion) VALUES (" + ID.ToString
                        sStr = sStr + ",'" + dgvTC_SHIMA.Rows(i).Cells("LETRA_2").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("C1_2").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("C2_2").Value.ToString + "'"
                        sStr = sStr + ",'" + dgvTC_SHIMA.Rows(i).Cells("C3_2").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("C4_2").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("DESC_2").Value.ToString + "') "
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Next
                For i = 0 To 9
                    If dgvTM_SHIMA.Rows(i).Cells("DESC").Value.ToString <> "*************" Then
                        sStr = "INSERT INTO PrendasArtProdPlanillas_TM (IdPlanilla,Letra,Cuadro1,Cuadro2,Cuadro3,Cuadro4,Descripcion) VALUES (" + ID.ToString
                        sStr = sStr + ",'" + dgvTM_SHIMA.Rows(i).Cells("LETRA").Value.ToString + "','" + dgvTM_SHIMA.Rows(i).Cells("C1").Value.ToString + "','" + dgvTM_SHIMA.Rows(i).Cells("C2").Value.ToString + "'"
                        sStr = sStr + ",'" + dgvTM_SHIMA.Rows(i).Cells("C3").Value.ToString + "','" + dgvTM_SHIMA.Rows(i).Cells("C4").Value.ToString + "','" + dgvTM_SHIMA.Rows(i).Cells("DESC").Value.ToString + "') "
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Next
            End If

            RegistroEnHistorial("P", ID.ToString, "AltaPlanilla", LegajoLogueado)

            MensajeAtencion("Planilla agregada correctamente.")
            Alta = False
            Close()
        Else 'Modificación

            sStr = "UPDATE PrendasArtProdPlanillas SET IdCategoria=" + ColCategoria.Item(cmbCategoria.Text) + ",Fecha='" + Format(dtpFecha.Value, "yyyyMMdd") + "',Articulo='" + txtArticulo.Text + "',OP='" + txtOp.Text + "'"
            sStr = sStr + ",Diseño='" + txtDiseño.Text + "',Color='" + txtColor.Text + "',Partida='" + txtPartida.Text + "',Ventana='" + txtVentDel.Text + "',VentanaEspalda='" + txtVentEsp.Text + "',VentanaManga='" + txtVentMan.Text + "'"
            sStr = sStr + ",VentanaCapucha='" + txtVentCap.Text + "',MedidaElastico='" + txtMedidaElastico.Text + "',CondicionCuerpos='" + txtCondicionCuerpos.Text + "',VelocidadCuerpos='" + txtVelocidadCuerpos.Text + "'"
            sStr = sStr + ",MedidaPuño='" + txtMedidaPuño.Text + "',CondicionMangas='" + txtCondicionMangas.Text + "',VelocidadMangas='" + txtVelocidadMangas.Text + "'"
            sStr = sStr + ",TalleXXL_D='" + txtTalleXXL_D.Text + "',TalleXXL_E='" + txtTalleXXL_E.Text + "',TalleXXL_Bretel='" + txtTalleXXLBretel.Text + "'"
            sStr = sStr + ",TalleXXL_Esc='" + txtTalleXXLEsc.Text + "',TalleXXL_Bolsillo='" + txtTalleXXLBolsillo.Text + "',TalleXXL_Ancho='" + txtTalleXXLAncho.Text + "'"
            sStr = sStr + ",TalleXXL_Largo='" + txtTalleXXLLargo.Text + "',TalleXXL_CueParamInicio='" + txtTalleXXL_CuerParamInicio.Text + "',TalleXXL_CueCantAgujas='" + txtTalleXXL_CuerCantAgujas.Text + "'"
            sStr = sStr + ",TalleXXL_Manga='" + txtTalleXXL_Manga.Text + "',TalleXXL_MangaParamInicio='" + txtTalleXXL_MangaParamInicio.Text + "',TalleXXL_MangaCantAgujas='" + txtTalleXXL_MangaCantAgujas.Text + "'"
            sStr = sStr + ",TalleXXL_MedInicial_D='" + txtTalleXXL_D_MedInicial.Text + "',TalleXXL_MedInicial_E='" + txtTalleXXL_E_MedInicial.Text + "'"
            sStr = sStr + ",TalleXXL_MedInicial_M='" + txtTalleXXL_M_MedInicial.Text + "',TalleXL_D='" + txtTalleXL_D.Text + "',TalleXL_E='" + txtTalleXL_E.Text + "'"
            sStr = sStr + ",TalleXL_Bretel='" + txtTalleXLBretel.Text + "',TalleXL_Esc='" + txtTalleXLEsc.Text + "',TalleXL_Bolsillo='" + txtTalleXLBolsillo.Text + "'"
            sStr = sStr + ",TalleXL_Ancho='" + txtTalleXLAncho.Text + "',TalleXL_Largo='" + txtTalleXLLargo.Text + "',TalleXL_CueParamInicio='" + txtTalleXL_CuerParamInicio.Text + "'"
            sStr = sStr + ",TalleXL_CueCantAgujas='" + txtTalleXL_CuerCantAgujas.Text + "',TalleXL_Manga='" + txtTalleXL_Manga.Text + "'"
            sStr = sStr + ",TalleXL_MangaParamInicio='" + txtTalleXL_MangaParamInicio.Text + "',TalleXL_MangaCantAgujas='" + txtTalleXL_MangaCantAgujas.Text + "'"
            sStr = sStr + ",TalleXL_MedInicial_D='" + txtTalleXL_D_MedInicial.Text + "',TalleXL_MedInicial_E='" + txtTalleXL_E_MedInicial.Text + "'"
            sStr = sStr + ",TalleXL_MedInicial_M='" + txtTalleXL_M_MedInicial.Text + "',TalleL_D='" + txtTalleL_D.Text + "',TalleL_E='" + txtTalleL_E.Text + "'"
            sStr = sStr + ",TalleL_Bretel='" + txtTalleLBretel.Text + "',TalleL_Esc='" + txtTalleLEsc.Text + "',TalleL_Bolsillo='" + txtTalleLBolsillo.Text + "'"
            sStr = sStr + ",TalleL_Ancho='" + txtTalleLAncho.Text + "',TalleL_Largo='" + txtTalleLLargo.Text + "',TalleL_CueParamInicio='" + txtTalleL_CuerParamInicio.Text + "'"
            sStr = sStr + ",TalleL_CueCantAgujas='" + txtTalleL_CuerCantAgujas.Text + "',TalleL_Manga='" + txtTalleL_Manga.Text + "',TalleL_MangaParamInicio='" + txtTalleL_MangaParamInicio.Text + "'"
            sStr = sStr + ",TalleL_MangaCantAgujas='" + txtTalleL_MangaCantAgujas.Text + "',TalleL_MedInicial_D='" + txtTalleL_D_MedInicial.Text + "'"
            sStr = sStr + ",TalleL_MedInicial_E='" + txtTalleL_E_MedInicial.Text + "',TalleL_MedInicial_M='" + txtTalleL_M_MedInicial.Text + "'"
            sStr = sStr + ",TalleM_D='" + txtTalleM_D.Text + "',TalleM_E='" + txtTalleM_E.Text + "',TalleM_Bretel='" + txtTalleMBretel.Text + "',TalleM_Esc='" + txtTalleMEsc.Text + "'"
            sStr = sStr + ",TalleM_Bolsillo='" + txtTalleMBolsillo.Text + "',TalleM_Ancho='" + txtTalleMAncho.Text + "',TalleM_Largo='" + txtTalleMLargo.Text + "'"
            sStr = sStr + ",TalleM_CueParamInicio='" + txtTalleM_CuerParamInicio.Text + "',TalleM_CueCantAgujas='" + txtTalleM_CuerCantAgujas.Text + "'"
            sStr = sStr + ",TalleM_Manga='" + txtTalleM_Manga.Text + "',TalleM_MangaParamInicio='" + txtTalleM_MangaParamInicio.Text + "',TalleM_MangaCantAgujas='" + txtTalleM_MangaCantAgujas.Text + "'"
            sStr = sStr + ",TalleM_MedInicial_D='" + txtTalleM_D_MedInicial.Text + "',TalleM_MedInicial_E='" + txtTalleM_E_MedInicial.Text + "',TalleM_MedInicial_M='" + txtTalleM_M_MedInicial.Text + "'"
            sStr = sStr + ",TalleS_D='" + txtTalleS_D.Text + "',TalleS_E='" + txtTalleS_E.Text + "',TalleS_Bretel='" + txtTalleSBretel.Text + "',TalleS_Esc='" + txtTalleSEsc.Text + "'"
            sStr = sStr + ",TalleS_Bolsillo='" + txtTalleSBolsillo.Text + "',TalleS_Ancho='" + txtTalleSAncho.Text + "',TalleS_Largo='" + txtTalleSLargo.Text + "'"
            sStr = sStr + ",TalleS_CueParamInicio='" + txtTalleS_CuerParamInicio.Text + "',TalleS_CueCantAgujas='" + txtTalleS_CuerCantAgujas.Text + "'"
            sStr = sStr + ",TalleS_Manga='" + txtTalleS_Manga.Text + "',TalleS_MangaParamInicio='" + txtTalleS_MangaParamInicio.Text + "',TalleS_MangaCantAgujas='" + txtTalleS_MangaCantAgujas.Text + "'"
            sStr = sStr + ",TalleS_MedInicial_D='" + txtTalleS_D_MedInicial.Text + "',TalleS_MedInicial_E='" + txtTalleS_E_MedInicial.Text + "',TalleS_MedInicial_M='" + txtTalleS_M_MedInicial.Text + "'"
            sStr = sStr + ",TalleXS_D='" + txtTalleXS_D.Text + "',TalleXS_E='" + txtTalleXS_E.Text + "',TalleXS_Bretel='" + txtTalleXSBretel.Text + "'"
            sStr = sStr + ",TalleXS_Esc='" + txtTalleXSEsc.Text + "',TalleXS_Bolsillo='" + txtTalleXSBolsillo.Text + "',TalleXS_Ancho='" + txtTalleXSAncho.Text + "'"
            sStr = sStr + ",TalleXS_Largo='" + txtTalleXSLargo.Text + "',TalleXS_CueParamInicio='" + txtTalleXS_CuerParamInicio.Text + "',TalleXS_CueCantAgujas='" + txtTalleXS_CuerCantAgujas.Text + "'"
            sStr = sStr + ",TalleXS_Manga='" + txtTalleXS_Manga.Text + "',TalleXS_MangaParamInicio='" + txtTalleXS_MangaParamInicio.Text + "',TalleXS_MangaCantAgujas='" + txtTalleXS_MangaCantAgujas.Text + "'"
            sStr = sStr + ",TalleXS_MedInicial_D='" + txtTalleXS_D_MedInicial.Text + "',TalleXS_MedInicial_E='" + txtTalleXS_E_MedInicial.Text + "',TalleXS_MedInicial_M='" + txtTalleXS_M_MedInicial.Text + "'"
            sStr = sStr + ",TitTalleXXL='" + txtTitTalleXXL.Text.ToString + "',TitTalleXL='" + txtTitTalleXL.Text.ToString + "',TitTalleL='" + txtTitTalleL.Text.ToString + "'"
            sStr = sStr + ",TitTalleM='" + txtTitTalleM.Text.ToString + "',TitTalleS='" + txtTitTalleS.Text.ToString + "',TitTalleXS='" + txtTitTalleXS.Text.ToString + "'"
            sStr = sStr + ",[TalleXXL_Bretel_Tit]='" + txtTalleXXLBretel_Tit.Text + "',[TalleXXL_Esc_Tit]='" + txtTalleXXLEsc_Tit.Text + "',[TalleXXL_Bolsillo_Tit]='" + txtTalleXXLBolsillo_Tit.Text + "'"
            sStr = sStr + ",[TalleXXL_Ancho_Tit]='" + txtTalleXXLAncho_Tit.Text + "',[TalleXXL_Largo_Tit]='" + txtTalleXXLLargo_Tit.Text + "',[TalleXL_Bretel_Tit]='" + txtTalleXLBretel_Tit.Text + "'"
            sStr = sStr + ",[TalleXL_Esc_Tit]='" + txtTalleXLEsc_Tit.Text + "',[TalleXL_Bolsillo_Tit]='" + txtTalleXLBolsillo_Tit.Text + "',[TalleXL_Ancho_Tit]='" + txtTalleXLAncho_Tit.Text + "'"
            sStr = sStr + ",[TalleXL_Largo_Tit]='" + txtTalleXLLargo_Tit.Text + "',[TalleL_Bretel_Tit]='" + txtTalleLBretel_Tit.Text + "',[TalleL_Esc_Tit]='" + txtTalleLEsc_Tit.Text + "'"
            sStr = sStr + ",[TalleL_Bolsillo_Tit]='" + txtTalleLBolsillo_Tit.Text + "',[TalleL_Ancho_Tit]='" + txtTalleLAncho_Tit.Text + "',[TalleL_Largo_Tit]='" + txtTalleLLargo_Tit.Text + "'"
            sStr = sStr + ",[TalleM_Bretel_Tit]='" + txtTalleMBretel_Tit.Text + "',[TalleM_Esc_Tit]='" + txtTalleMEsc_Tit.Text + "',[TalleM_Bolsillo_Tit]='" + txtTalleMBolsillo_Tit.Text + "'"
            sStr = sStr + ",[TalleM_Ancho_Tit]='" + txtTalleMAncho_Tit.Text + "',[TalleM_Largo_Tit]='" + txtTalleMLargo_Tit.Text + "',[TalleS_Bretel_Tit]='" + txtTalleSBretel_Tit.Text + "'"
            sStr = sStr + ",[TalleS_Esc_Tit]='" + txtTalleSEsc_Tit.Text + "',[TalleS_Bolsillo_Tit]='" + txtTalleSBolsillo_Tit.Text + "',[TalleS_Ancho_Tit]='" + txtTalleSAncho_Tit.Text + "'"
            sStr = sStr + ",[TalleS_Largo_Tit]='" + txtTalleSLargo_Tit.Text + "',[TalleXS_Bretel_Tit]='" + txtTalleXSBretel_Tit.Text + "',[TalleXS_Esc_Tit]='" + txtTalleXSEsc_Tit.Text + "'"
            sStr = sStr + ",[TalleXS_Bolsillo_Tit]='" + txtTalleXSBolsillo_Tit.Text + "',[TalleXS_Ancho_Tit]='" + txtTalleXSAncho_Tit.Text + "',[TalleXS_Largo_Tit]='" + txtTalleXSLargo_Tit.Text + "'"
            sStr = sStr + ",RutaImagen= " + auxRutaImagen
            sStr = sStr + " WHERE id = " + ID.ToString
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()

            'ya dejo actualizadas las medidas de tiempo y peso, primero verifico que tenga alguna cargada por los articulos viejos, si no la doy de alta directo
            sStr = "SELECT isnull(count(*),0) as cant FROM PrendasArtProdPlanillas_TP WHERE IdPlanilla=" + ID.ToString
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read Then
                    If Reader.Item("cant") > 0 Then
                        sStr = "UPDATE PrendasArtProdPlanillas_TP SET T_XXS='" + dgvTiempoyPeso.Rows(0).Cells("XXS").Value.ToString + "', "
                        sStr = sStr + " T_XS='" + dgvTiempoyPeso.Rows(0).Cells("XS").Value.ToString + "', "
                        sStr = sStr + " T_S='" + dgvTiempoyPeso.Rows(0).Cells("S").Value.ToString + "', "
                        sStr = sStr + " T_M='" + dgvTiempoyPeso.Rows(0).Cells("M").Value.ToString + "', "
                        sStr = sStr + " T_L='" + dgvTiempoyPeso.Rows(0).Cells("L").Value.ToString + "', "
                        sStr = sStr + " T_XL='" + dgvTiempoyPeso.Rows(0).Cells("XL").Value.ToString + "', "
                        sStr = sStr + " T_XXL='" + dgvTiempoyPeso.Rows(0).Cells("XXL").Value.ToString + "', "
                        sStr = sStr + " T_U='" + dgvTiempoyPeso.Rows(0).Cells("U").Value.ToString + "', "
                        sStr = sStr + " P_XXS='" + dgvTiempoyPeso.Rows(1).Cells("XXS").Value.ToString + "', "
                        sStr = sStr + " P_XS='" + dgvTiempoyPeso.Rows(1).Cells("XS").Value.ToString + "', "
                        sStr = sStr + " P_S='" + dgvTiempoyPeso.Rows(1).Cells("S").Value.ToString + "', "
                        sStr = sStr + " P_M='" + dgvTiempoyPeso.Rows(1).Cells("M").Value.ToString + "', "
                        sStr = sStr + " P_L='" + dgvTiempoyPeso.Rows(1).Cells("L").Value.ToString + "', "
                        sStr = sStr + " P_XL='" + dgvTiempoyPeso.Rows(1).Cells("XL").Value.ToString + "', "
                        sStr = sStr + " P_XXL='" + dgvTiempoyPeso.Rows(1).Cells("XXL").Value.ToString + "', "
                        sStr = sStr + " P_U='" + dgvTiempoyPeso.Rows(1).Cells("U").Value.ToString + "', "
                        sStr = sStr + " T_XXXL='" + dgvTiempoyPeso.Rows(0).Cells("XXXL").Value.ToString + "', "
                        sStr = sStr + " P_XXXL='" + dgvTiempoyPeso.Rows(1).Cells("XXXL").Value.ToString + "' "
                        sStr = sStr + " WHERE IdPlanilla=" + ID.ToString
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    Else
                        sStr = "INSERT INTO PrendasArtProdPlanillas_TP (IdPlanilla,T_XXS,T_XS,T_S,T_M,T_L,T_XL,T_XXL,T_U,P_XXS,P_XS,P_S,P_M,P_L,P_XL,P_XXL,P_U,T_XXXL,P_XXXL) VALUES ("
                        sStr = sStr + ID.ToString + ", '" + dgvTiempoyPeso.Rows(0).Cells("XXS").Value.ToString + "', '" + dgvTiempoyPeso.Rows(0).Cells("XS").Value.ToString + "', '"
                        sStr = sStr + dgvTiempoyPeso.Rows(0).Cells("S").Value.ToString + "', '" + dgvTiempoyPeso.Rows(0).Cells("M").Value.ToString + "', '"
                        sStr = sStr + dgvTiempoyPeso.Rows(0).Cells("L").Value.ToString + "', '" + dgvTiempoyPeso.Rows(0).Cells("XL").Value.ToString + "', '"
                        sStr = sStr + dgvTiempoyPeso.Rows(0).Cells("XXL").Value.ToString + "', '" + dgvTiempoyPeso.Rows(0).Cells("U").Value.ToString + "', '"
                        sStr = sStr + dgvTiempoyPeso.Rows(1).Cells("XXS").Value.ToString + "', '" + dgvTiempoyPeso.Rows(1).Cells("XS").Value.ToString + "', '"
                        sStr = sStr + dgvTiempoyPeso.Rows(1).Cells("S").Value.ToString + "', '" + dgvTiempoyPeso.Rows(1).Cells("M").Value.ToString + "', '"
                        sStr = sStr + dgvTiempoyPeso.Rows(1).Cells("L").Value.ToString + "', '" + dgvTiempoyPeso.Rows(1).Cells("XL").Value.ToString + "', '"
                        sStr = sStr + dgvTiempoyPeso.Rows(1).Cells("XXL").Value.ToString + "', '" + dgvTiempoyPeso.Rows(1).Cells("U").Value.ToString + "', '"
                        sStr = sStr + dgvTiempoyPeso.Rows(0).Cells("XXXL").Value.ToString + "', '" + dgvTiempoyPeso.Rows(1).Cells("XXXL").Value.ToString + "')"
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                End If
            End If

            'borro las graduaciones y los tirajes y los vuelvo a cargar 

            If TipoPlanilla = "STOLL" Then
                'si guardo como STOLL borro por si habia cargados MALLAS VARIABLES anteriores, porque era una SHIMA que cambio de categoria
                sStr = "DELETE FROM PrendasArtProdPlanillas_MallasVariables WHERE IdPlanilla=" + ID.ToString
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()

                'primero los picos
                sStr = "DELETE FROM PrendasArtProdPlanillas_Picos WHERE IdPlanilla=" + ID.ToString
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
                For i = 0 To 7
                    sStr = "INSERT INTO PrendasArtProdPlanillas_Picos (IdPlanilla,Pico,Cuerpo_C1,Cuerpo_C2,Cuerpo_C3,Manga_C1,Manga_C2,Manga_C3) VALUES ("
                    sStr = sStr + ID.ToString + ", '" + dgvPicos.Rows(i).Cells("Pico").Value + "', '" + dgvPicos.Rows(i).Cells("Cuerpo_C1").Value + "', '"
                    sStr = sStr + dgvPicos.Rows(i).Cells("Cuerpo_C2").Value + "', '" + dgvPicos.Rows(i).Cells("Cuerpo_C3").Value + "', '"
                    sStr = sStr + dgvPicos.Rows(i).Cells("Manga_C1").Value + "', '" + dgvPicos.Rows(i).Cells("Manga_C2").Value + "', '"
                    sStr = sStr + dgvPicos.Rows(i).Cells("Manga_C3").Value + "')"
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                Next
                sStr = "DELETE FROM PrendasArtProdPlanillas_GC WHERE IdPlanilla=" + ID.ToString
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
                For i = 0 To 19
                    If dgvGC_STOLL.Rows(i).Cells("DESC_1").Value.ToString <> "*************" Then
                        If dgvGC_STOLL.Rows(i).Cells("chk_1").Value = True Then
                            Sombreado = "1"
                        Else
                            Sombreado = "0"
                        End If
                        sStr = "INSERT INTO PrendasArtProdPlanillas_GC (IdPlanilla,Letra,Cuadro1,Cuadro2,Descripcion,Sombreado) VALUES (" + ID.ToString
                        sStr = sStr + ",'" + dgvGC_STOLL.Rows(i).Cells("LETRA_1").Value.ToString + "','" + dgvGC_STOLL.Rows(i).Cells("C1_1").Value.ToString + "','" + dgvGC_STOLL.Rows(i).Cells("C2_1").Value.ToString + "','" + dgvGC_STOLL.Rows(i).Cells("DESC_1").Value.ToString + "'," + Sombreado + ") "
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Next
                For i = 0 To 19
                    If dgvGC_STOLL.Rows(i).Cells("DESC_2").Value.ToString <> "*************" Then
                        If dgvGC_STOLL.Rows(i).Cells("chk_2").Value = True Then
                            Sombreado = "1"
                        Else
                            Sombreado = "0"
                        End If
                        sStr = "INSERT INTO PrendasArtProdPlanillas_GC (IdPlanilla,Letra,Cuadro1,Cuadro2,Descripcion,Sombreado) VALUES (" + ID.ToString
                        sStr = sStr + ",'" + dgvGC_STOLL.Rows(i).Cells("LETRA_2").Value.ToString + "','" + dgvGC_STOLL.Rows(i).Cells("C1_2").Value.ToString + "','" + dgvGC_STOLL.Rows(i).Cells("C2_2").Value.ToString + "','" + dgvGC_STOLL.Rows(i).Cells("DESC_2").Value.ToString + "'," + Sombreado + ") "
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Next
                sStr = "DELETE FROM PrendasArtProdPlanillas_GM WHERE IdPlanilla=" + ID.ToString
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
                For i = 0 To 19
                    If dgvGM_STOLL.Rows(i).Cells("DESC").Value.ToString <> "*************" Then
                        If dgvGM_STOLL.Rows(i).Cells("chk").Value = True Then
                            Sombreado = "1"
                        Else
                            Sombreado = "0"
                        End If
                        sStr = "INSERT INTO PrendasArtProdPlanillas_GM (IdPlanilla,Letra,Cuadro1,Cuadro2,Descripcion,Sombreado) VALUES (" + ID.ToString
                        sStr = sStr + ",'" + dgvGM_STOLL.Rows(i).Cells("LETRA").Value.ToString + "','" + dgvGM_STOLL.Rows(i).Cells("C1").Value.ToString + "','" + dgvGM_STOLL.Rows(i).Cells("C2").Value.ToString + "','" + dgvGM_STOLL.Rows(i).Cells("DESC").Value.ToString + "'," + Sombreado + ") "
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Next
                sStr = "DELETE FROM PrendasArtProdPlanillas_TC WHERE IdPlanilla=" + ID.ToString
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
                For i = 0 To 9
                    If dgvTC_STOLL.Rows(i).Cells("DESC_1").Value.ToString <> "*************" Then
                        If IsNothing(dgvTC_STOLL.Rows(i).Cells("C1_1").Value) Then dgvTC_STOLL.Rows(i).Cells("C1_1").Value = ""
                        If IsNothing(dgvTC_STOLL.Rows(i).Cells("C2_1").Value) Then dgvTC_STOLL.Rows(i).Cells("C2_1").Value = ""
                        If IsNothing(dgvTC_STOLL.Rows(i).Cells("C3_1").Value) Then dgvTC_STOLL.Rows(i).Cells("C3_1").Value = ""
                        If IsNothing(dgvTC_STOLL.Rows(i).Cells("C4_1").Value) Then dgvTC_STOLL.Rows(i).Cells("C4_1").Value = ""
                        sStr = "INSERT INTO PrendasArtProdPlanillas_TC (IdPlanilla,Letra,Cuadro1,Cuadro2,Cuadro3,Cuadro4,Descripcion) VALUES (" + ID.ToString
                        sStr = sStr + ",'" + dgvTC_STOLL.Rows(i).Cells("LETRA_1").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C1_1").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C2_1").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C3_1").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C4_1").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("DESC_1").Value.ToString + "') "
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Next
                For i = 0 To 9
                    If dgvTC_STOLL.Rows(i).Cells("DESC_2").Value.ToString <> "*************" Then
                        If IsNothing(dgvTC_STOLL.Rows(i).Cells("C1_2").Value) Then dgvTC_STOLL.Rows(i).Cells("C1_2").Value = ""
                        If IsNothing(dgvTC_STOLL.Rows(i).Cells("C2_2").Value) Then dgvTC_STOLL.Rows(i).Cells("C2_2").Value = ""
                        If IsNothing(dgvTC_STOLL.Rows(i).Cells("C3_2").Value) Then dgvTC_STOLL.Rows(i).Cells("C3_2").Value = ""
                        If IsNothing(dgvTC_STOLL.Rows(i).Cells("C4_2").Value) Then dgvTC_STOLL.Rows(i).Cells("C4_2").Value = ""
                        sStr = "INSERT INTO PrendasArtProdPlanillas_TC (IdPlanilla,Letra,Cuadro1,Cuadro2,Cuadro3,Cuadro4,Descripcion) VALUES (" + ID.ToString
                        sStr = sStr + ",'" + dgvTC_STOLL.Rows(i).Cells("LETRA_2").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C1_2").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C2_2").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C3_2").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C4_2").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("DESC_2").Value.ToString + "') "
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Next
                sStr = "DELETE FROM PrendasArtProdPlanillas_TM WHERE IdPlanilla=" + ID.ToString
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
                For i = 0 To 9
                    If dgvTM_STOLL.Rows(i).Cells("DESC").Value.ToString <> "*************" Then
                        If IsNothing(dgvTM_STOLL.Rows(i).Cells("C1").Value) Then dgvTM_STOLL.Rows(i).Cells("C1").Value = ""
                        If IsNothing(dgvTM_STOLL.Rows(i).Cells("C2").Value) Then dgvTM_STOLL.Rows(i).Cells("C2").Value = ""
                        If IsNothing(dgvTM_STOLL.Rows(i).Cells("C3").Value) Then dgvTM_STOLL.Rows(i).Cells("C3").Value = ""
                        If IsNothing(dgvTM_STOLL.Rows(i).Cells("C4").Value) Then dgvTM_STOLL.Rows(i).Cells("C4").Value = ""
                        sStr = "INSERT INTO PrendasArtProdPlanillas_TM (IdPlanilla,Letra,Cuadro1,Cuadro2,Cuadro3,Cuadro4,Descripcion) VALUES (" + ID.ToString
                        sStr = sStr + ",'" + dgvTM_STOLL.Rows(i).Cells("LETRA").Value.ToString + "','" + dgvTM_STOLL.Rows(i).Cells("C1").Value.ToString + "','" + dgvTM_STOLL.Rows(i).Cells("C2").Value.ToString + "','" + dgvTM_STOLL.Rows(i).Cells("C3").Value.ToString + "','" + dgvTM_STOLL.Rows(i).Cells("C4").Value.ToString + "','" + dgvTM_STOLL.Rows(i).Cells("DESC").Value.ToString + "') "
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Next
            Else
                'si guardo como SHIMA borro por si habia cargados picos anteriores, porque era una STOLL que cambio de categoria
                sStr = "DELETE FROM PrendasArtProdPlanillas_Picos WHERE IdPlanilla=" + ID.ToString
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()

                'las mallas variables
                sStr = "DELETE FROM PrendasArtProdPlanillas_MallasVariables WHERE IdPlanilla=" + ID.ToString
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
                For i = 0 To 13
                    sStr = "INSERT INTO PrendasArtProdPlanillas_MallasVariables (IdPlanilla,MallaVariable,Malla_D,Malla_T,Malla_Desc) VALUES ("
                    sStr = sStr + ID.ToString + ", '" + dgvMallaVariable.Rows(i).Cells("MALLA").Value + "', '" + dgvMallaVariable.Rows(i).Cells("MALLA_D").Value + "', '"
                    sStr = sStr + dgvMallaVariable.Rows(i).Cells("MALLA_T").Value + "', '" + dgvMallaVariable.Rows(i).Cells("MALLA_DESC").Value + "')"
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                Next

                sStr = "DELETE FROM PrendasArtProdPlanillas_GC WHERE IdPlanilla=" + ID.ToString
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
                For i = 0 To 19
                    If dgvGC_SHIMA.Rows(i).Cells("DESC_1").Value.ToString <> "*************" Then
                        If dgvGC_SHIMA.Rows(i).Cells("chk_1").Value = True Then
                            Sombreado = "1"
                        Else
                            Sombreado = "0"
                        End If
                        sStr = "INSERT INTO PrendasArtProdPlanillas_GC (IdPlanilla,Letra,Cuadro1,Cuadro2,Descripcion,Sombreado) VALUES (" + ID.ToString
                        sStr = sStr + ",'" + dgvGC_SHIMA.Rows(i).Cells("LETRA_1").Value.ToString + "','" + dgvGC_SHIMA.Rows(i).Cells("C1_1").Value.ToString + "','" + dgvGC_SHIMA.Rows(i).Cells("C2_1").Value.ToString + "','" + dgvGC_SHIMA.Rows(i).Cells("DESC_1").Value.ToString + "'," + Sombreado + ") "
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Next
                For i = 0 To 19
                    If dgvGC_SHIMA.Rows(i).Cells("DESC_2").Value.ToString <> "*************" Then
                        If dgvGC_SHIMA.Rows(i).Cells("chk_2").Value = True Then
                            Sombreado = "1"
                        Else
                            Sombreado = "0"
                        End If
                        sStr = "INSERT INTO PrendasArtProdPlanillas_GC (IdPlanilla,Letra,Cuadro1,Cuadro2,Descripcion,Sombreado) VALUES (" + ID.ToString
                        sStr = sStr + ",'" + dgvGC_SHIMA.Rows(i).Cells("LETRA_2").Value.ToString + "','" + dgvGC_SHIMA.Rows(i).Cells("C1_2").Value.ToString + "','" + dgvGC_SHIMA.Rows(i).Cells("C2_2").Value.ToString + "','" + dgvGC_SHIMA.Rows(i).Cells("DESC_2").Value.ToString + "'," + Sombreado + ") "
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Next
                sStr = "DELETE FROM PrendasArtProdPlanillas_GM WHERE IdPlanilla=" + ID.ToString
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
                For i = 0 To 19
                    If dgvGM_SHIMA.Rows(i).Cells("DESC").Value.ToString <> "*************" Then
                        If dgvGM_SHIMA.Rows(i).Cells("chk").Value = True Then
                            Sombreado = "1"
                        Else
                            Sombreado = "0"
                        End If
                        sStr = "INSERT INTO PrendasArtProdPlanillas_GM (IdPlanilla,Letra,Cuadro1,Cuadro2,Descripcion,Sombreado) VALUES (" + ID.ToString
                        sStr = sStr + ",'" + dgvGM_SHIMA.Rows(i).Cells("LETRA").Value.ToString + "','" + dgvGM_SHIMA.Rows(i).Cells("C1").Value.ToString + "','" + dgvGM_SHIMA.Rows(i).Cells("C2").Value.ToString + "','" + dgvGM_SHIMA.Rows(i).Cells("DESC").Value.ToString + "'," + Sombreado + ") "
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Next
                sStr = "DELETE FROM PrendasArtProdPlanillas_TC WHERE IdPlanilla=" + ID.ToString
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
                For i = 0 To 9
                    If dgvTC_SHIMA.Rows(i).Cells("DESC_1").Value.ToString <> "*************" Then
                        sStr = "INSERT INTO PrendasArtProdPlanillas_TC (IdPlanilla,Letra,Cuadro1,Cuadro2,Cuadro3,Cuadro4,Descripcion) VALUES (" + ID.ToString
                        sStr = sStr + ",'" + dgvTC_SHIMA.Rows(i).Cells("LETRA_1").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("C1_1").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("C2_1").Value.ToString + "'"
                        sStr = sStr + ",'" + dgvTC_SHIMA.Rows(i).Cells("C3_1").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("C4_1").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("DESC_1").Value.ToString + "') "
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Next
                For i = 0 To 9
                    If dgvTC_SHIMA.Rows(i).Cells("DESC_2").Value.ToString <> "*************" Then
                        sStr = "INSERT INTO PrendasArtProdPlanillas_TC (IdPlanilla,Letra,Cuadro1,Cuadro2,Cuadro3,Cuadro4,Descripcion) VALUES (" + ID.ToString
                        sStr = sStr + ",'" + dgvTC_SHIMA.Rows(i).Cells("LETRA_2").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("C1_2").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("C2_2").Value.ToString + "'"
                        sStr = sStr + ",'" + dgvTC_SHIMA.Rows(i).Cells("C3_2").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("C4_2").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("DESC_2").Value.ToString + "') "
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Next
                sStr = "DELETE FROM PrendasArtProdPlanillas_TM WHERE IdPlanilla=" + ID.ToString
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
                For i = 0 To 9
                    If dgvTM_SHIMA.Rows(i).Cells("DESC").Value.ToString <> "*************" Then
                        sStr = "INSERT INTO PrendasArtProdPlanillas_TM (IdPlanilla,Letra,Cuadro1,Cuadro2,Cuadro3,Cuadro4,Descripcion) VALUES (" + ID.ToString
                        sStr = sStr + ",'" + dgvTM_SHIMA.Rows(i).Cells("LETRA").Value.ToString + "','" + dgvTM_SHIMA.Rows(i).Cells("C1").Value.ToString + "','" + dgvTM_SHIMA.Rows(i).Cells("C2").Value.ToString + "'"
                        sStr = sStr + ",'" + dgvTM_SHIMA.Rows(i).Cells("C3").Value.ToString + "','" + dgvTM_SHIMA.Rows(i).Cells("C4").Value.ToString + "','" + dgvTM_SHIMA.Rows(i).Cells("DESC").Value.ToString + "') "
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Next
            End If

            RegistroEnHistorial("P", ID.ToString, "ModifPlanilla", LegajoLogueado)

            MensajeAtencion("Planilla modificada correctamente.")

            'una vez que actualizó si estaba la marca de que staba copiando la saco
            If EstoyCopiando Then EstoyCopiando = False

        End If


        If txtRutaImagen.Text <> "" Then
            CargarFoto(txtRutaImagen.Text)
        End If


    End Sub

    Private Sub CopiarSinAccesorios()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        Dim Sombreado As String = ""

        Dim i As Integer

        EstoyCopiando = True
        Alta = False

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "INSERT INTO PrendasArtProdPlanillas SELECT IdCategoria,Articulo,OP,Diseño,Color,Partida,Ventana,MedidaElastico,CondicionCuerpos,VelocidadCuerpos,MedidaPuño"
        sStr = sStr + ",CondicionMangas,VelocidadMangas,TalleXXL_D,TalleXXL_E,TalleXXL_Bretel,TalleXXL_Esc,TalleXXL_Bolsillo,TalleXXL_Ancho,TalleXXL_Largo"
        sStr = sStr + ",TalleXXL_CueParamInicio,TalleXXL_CueCantAgujas,TalleXXL_Manga,TalleXXL_MangaParamInicio,TalleXXL_MangaCantAgujas,TalleXXL_MedInicial_D"
        sStr = sStr + ",TalleXXL_MedInicial_E,TalleXXL_MedInicial_M,TalleXL_D,TalleXL_E,TalleXL_Bretel,TalleXL_Esc,TalleXL_Bolsillo,TalleXL_Ancho,TalleXL_Largo"
        sStr = sStr + ",TalleXL_CueParamInicio,TalleXL_CueCantAgujas,TalleXL_Manga,TalleXL_MangaParamInicio,TalleXL_MangaCantAgujas,TalleXL_MedInicial_D"
        sStr = sStr + ",TalleXL_MedInicial_E,TalleXL_MedInicial_M,TalleL_D,TalleL_E,TalleL_Bretel,TalleL_Esc,TalleL_Bolsillo,TalleL_Ancho,TalleL_Largo"
        sStr = sStr + ",TalleL_CueParamInicio,TalleL_CueCantAgujas,TalleL_Manga,TalleL_MangaParamInicio,TalleL_MangaCantAgujas,TalleL_MedInicial_D,TalleL_MedInicial_E"
        sStr = sStr + ",TalleL_MedInicial_M,TalleM_D,TalleM_E,TalleM_Bretel,TalleM_Esc,TalleM_Bolsillo,TalleM_Ancho,TalleM_Largo,TalleM_CueParamInicio"
        sStr = sStr + ",TalleM_CueCantAgujas,TalleM_Manga,TalleM_MangaParamInicio,TalleM_MangaCantAgujas,TalleM_MedInicial_D,TalleM_MedInicial_E,TalleM_MedInicial_M"
        sStr = sStr + ",TalleS_D,TalleS_E,TalleS_Bretel,TalleS_Esc,TalleS_Bolsillo,TalleS_Ancho,TalleS_Largo,TalleS_CueParamInicio,TalleS_CueCantAgujas"
        sStr = sStr + ",TalleS_Manga,TalleS_MangaParamInicio,TalleS_MangaCantAgujas,TalleS_MedInicial_D,TalleS_MedInicial_E,TalleS_MedInicial_M,TalleXS_D"
        sStr = sStr + ",TalleXS_E,TalleXS_Bretel,TalleXS_Esc,TalleXS_Bolsillo,TalleXS_Ancho,TalleXS_Largo,TalleXS_CueParamInicio,TalleXS_CueCantAgujas,TalleXS_Manga"
        sStr = sStr + ",TalleXS_MangaParamInicio,TalleXS_MangaCantAgujas,TalleXS_MedInicial_D,TalleXS_MedInicial_E,TalleXS_MedInicial_M,Fecha,0,0,VentanaEspalda,VentanaManga,VentanaCapucha "
        sStr = sStr + ",TitTalleXXL,TitTalleXL,TitTalleL,TitTalleM,TitTalleS,TitTalleXS,[TalleXXL_Bretel_Tit],[TalleXXL_Esc_Tit],[TalleXXL_Bolsillo_Tit],[TalleXXL_Ancho_Tit]"
        sStr = sStr + ",[TalleXXL_Largo_Tit],[TalleXL_Bretel_Tit],[TalleXL_Esc_Tit],[TalleXL_Bolsillo_Tit],[TalleXL_Ancho_Tit],[TalleXL_Largo_Tit],[TalleL_Bretel_Tit],[TalleL_Esc_Tit]"
        sStr = sStr + ",[TalleL_Bolsillo_Tit],[TalleL_Ancho_Tit],[TalleL_Largo_Tit],[TalleM_Bretel_Tit],[TalleM_Esc_Tit],[TalleM_Bolsillo_Tit],[TalleM_Ancho_Tit],[TalleM_Largo_Tit]"
        sStr = sStr + ",[TalleS_Bretel_Tit],[TalleS_Esc_Tit],[TalleS_Bolsillo_Tit],[TalleS_Ancho_Tit],[TalleS_Largo_Tit],[TalleXS_Bretel_Tit],[TalleXS_Esc_Tit],[TalleXS_Bolsillo_Tit]"
        sStr = sStr + ",[TalleXS_Ancho_Tit],[TalleXS_Largo_Tit],RutaImagen, 0 , NroPrograma"
        sStr = sStr + " FROM PrendasArtProdPlanillas WHERE Id=" + ID.ToString
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        'una vez que inserto traigo el id asi inserto las demas cosas
        sStr = "SELECT max(id) as Id FROM PrendasArtProdPlanillas "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                ID = Reader.Item("Id").ToString
            End If
        End If

        If TipoUsuario = "Programacion" Or TipoUsuario = "Administrador" Then

            Dim nroPrograma As Integer
            If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
            sStr = "select NroPrograma from PrendasArtProdPlanillas where Id = (select max(id) from PrendasArtProdPlanillas)"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read Then
                    nroPrograma = CInt(Reader.Item("NroPrograma")) + 1
                End If
            End If

            sStr = "update PrendasArtProdPlanillas set NroPrograma = " + txtNroPrograma.Text + " where Id = " + ID.ToString
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()
        Else
            If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
            sStr = "update PrendasArtProdPlanillas set NroPrograma = null where Id = " + ID.ToString
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()
        End If

        'despues de que inserte la copia, le borro los datos que debe cargar si o si
        sStr = "UPDATE PrendasArtProdPlanillas SET Fecha=getdate(),Articulo='',OP='',Color='',Partida='' WHERE Id=" + ID.ToString
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        'ya dejo guardadas las medidas de tiempo y peso
        sStr = "INSERT INTO PrendasArtProdPlanillas_TP (IdPlanilla,T_XXS,T_XS,T_S,T_M,T_L,T_XL,T_XXL,T_U,P_XXS,P_XS,P_S,P_M,P_L,P_XL,P_XXL,P_U,T_XXXL,P_XXXL) VALUES ("
        sStr = sStr + ID.ToString + ", '" + dgvTiempoyPeso.Rows(0).Cells("XXS").Value.ToString + "', '" + dgvTiempoyPeso.Rows(0).Cells("XS").Value.ToString + "', '"
        sStr = sStr + dgvTiempoyPeso.Rows(0).Cells("S").Value.ToString + "', '" + dgvTiempoyPeso.Rows(0).Cells("M").Value.ToString + "', '"
        sStr = sStr + dgvTiempoyPeso.Rows(0).Cells("L").Value.ToString + "', '" + dgvTiempoyPeso.Rows(0).Cells("XL").Value.ToString + "', '"
        sStr = sStr + dgvTiempoyPeso.Rows(0).Cells("XXL").Value.ToString + "', '" + dgvTiempoyPeso.Rows(0).Cells("U").Value.ToString + "', '"
        sStr = sStr + dgvTiempoyPeso.Rows(1).Cells("XXS").Value.ToString + "', '" + dgvTiempoyPeso.Rows(1).Cells("XS").Value.ToString + "', '"
        sStr = sStr + dgvTiempoyPeso.Rows(1).Cells("S").Value.ToString + "', '" + dgvTiempoyPeso.Rows(1).Cells("M").Value.ToString + "', '"
        sStr = sStr + dgvTiempoyPeso.Rows(1).Cells("L").Value.ToString + "', '" + dgvTiempoyPeso.Rows(1).Cells("XL").Value.ToString + "', '"
        sStr = sStr + dgvTiempoyPeso.Rows(1).Cells("XXL").Value.ToString + "', '" + dgvTiempoyPeso.Rows(1).Cells("U").Value.ToString + "', '"
        sStr = sStr + dgvTiempoyPeso.Rows(0).Cells("XXXL").Value.ToString + "', '" + dgvTiempoyPeso.Rows(1).Cells("XXXL").Value.ToString + "')"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        If TipoPlanilla = "STOLL" Then

            'primero los picos
            For i = 0 To 7
                sStr = "INSERT INTO PrendasArtProdPlanillas_Picos (IdPlanilla,Pico,Cuerpo_C1,Cuerpo_C2,Cuerpo_C3,Manga_C1,Manga_C2,Manga_C3) VALUES ("
                sStr = sStr + ID.ToString + ", '" + dgvPicos.Rows(i).Cells("Pico").Value + "', '" + dgvPicos.Rows(i).Cells("Cuerpo_C1").Value + "', '"
                sStr = sStr + dgvPicos.Rows(i).Cells("Cuerpo_C2").Value + "', '" + dgvPicos.Rows(i).Cells("Cuerpo_C3").Value + "', '"
                sStr = sStr + dgvPicos.Rows(i).Cells("Manga_C1").Value + "', '" + dgvPicos.Rows(i).Cells("Manga_C2").Value + "', '"
                sStr = sStr + dgvPicos.Rows(i).Cells("Manga_C3").Value + "')"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
            Next
            For i = 0 To 19
                If dgvGC_STOLL.Rows(i).Cells("DESC_1").Value.ToString <> "*************" Then
                    If dgvGC_STOLL.Rows(i).Cells("chk_1").Value = True Then
                        Sombreado = "1"
                    Else
                        Sombreado = "0"
                    End If
                    sStr = "INSERT INTO PrendasArtProdPlanillas_GC (IdPlanilla,Letra,Cuadro1,Cuadro2,Descripcion,Sombreado) VALUES (" + ID.ToString
                    sStr = sStr + ",'" + dgvGC_STOLL.Rows(i).Cells("LETRA_1").Value.ToString + "','" + dgvGC_STOLL.Rows(i).Cells("C1_1").Value.ToString + "','" + dgvGC_STOLL.Rows(i).Cells("C2_1").Value.ToString + "','" + dgvGC_STOLL.Rows(i).Cells("DESC_1").Value.ToString + "'," + Sombreado + ") "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Next
            For i = 0 To 19
                If dgvGC_STOLL.Rows(i).Cells("DESC_2").Value.ToString <> "*************" Then
                    If dgvGC_STOLL.Rows(i).Cells("chk_2").Value = True Then
                        Sombreado = "1"
                    Else
                        Sombreado = "0"
                    End If
                    sStr = "INSERT INTO PrendasArtProdPlanillas_GC (IdPlanilla,Letra,Cuadro1,Cuadro2,Descripcion,Sombreado) VALUES (" + ID.ToString
                    sStr = sStr + ",'" + dgvGC_STOLL.Rows(i).Cells("LETRA_2").Value.ToString + "','" + dgvGC_STOLL.Rows(i).Cells("C1_2").Value.ToString + "','" + dgvGC_STOLL.Rows(i).Cells("C2_2").Value.ToString + "','" + dgvGC_STOLL.Rows(i).Cells("DESC_2").Value.ToString + "'," + Sombreado + ") "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Next
            For i = 0 To 19
                If dgvGM_STOLL.Rows(i).Cells("DESC").Value.ToString <> "*************" Then
                    If dgvGM_STOLL.Rows(i).Cells("chk").Value = True Then
                        Sombreado = "1"
                    Else
                        Sombreado = "0"
                    End If
                    sStr = "INSERT INTO PrendasArtProdPlanillas_GM (IdPlanilla,Letra,Cuadro1,Cuadro2,Descripcion,Sombreado) VALUES (" + ID.ToString
                    sStr = sStr + ",'" + dgvGM_STOLL.Rows(i).Cells("LETRA").Value.ToString + "','" + dgvGM_STOLL.Rows(i).Cells("C1").Value.ToString + "','" + dgvGM_STOLL.Rows(i).Cells("C2").Value.ToString + "','" + dgvGM_STOLL.Rows(i).Cells("DESC").Value.ToString + "'," + Sombreado + ") "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Next
            For i = 0 To 9
                If dgvTC_STOLL.Rows(i).Cells("DESC_1").Value.ToString <> "*************" Then
                    sStr = "INSERT INTO PrendasArtProdPlanillas_TC (IdPlanilla,Letra,Cuadro1,Cuadro2,Cuadro3,Cuadro4,Descripcion) VALUES (" + ID.ToString
                    sStr = sStr + ",'" + dgvTC_STOLL.Rows(i).Cells("LETRA_1").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C1_1").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C2_1").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C3_1").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C4_1").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("DESC_1").Value.ToString + "') "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Next
            For i = 0 To 9
                If dgvTC_STOLL.Rows(i).Cells("DESC_2").Value.ToString <> "*************" Then
                    sStr = "INSERT INTO PrendasArtProdPlanillas_TC (IdPlanilla,Letra,Cuadro1,Cuadro2,Cuadro3,Cuadro4,Descripcion) VALUES (" + ID.ToString
                    sStr = sStr + ",'" + dgvTC_STOLL.Rows(i).Cells("LETRA_2").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C1_2").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C2_2").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C3_2").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C4_2").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("DESC_2").Value.ToString + "') "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Next
            For i = 0 To 9
                If dgvTM_STOLL.Rows(i).Cells("DESC").Value.ToString <> "*************" Then
                    sStr = "INSERT INTO PrendasArtProdPlanillas_TM (IdPlanilla,Letra,Cuadro1,Cuadro2,Cuadro3,Cuadro4,Descripcion) VALUES (" + ID.ToString
                    sStr = sStr + ",'" + dgvTM_STOLL.Rows(i).Cells("LETRA").Value.ToString + "','" + dgvTM_STOLL.Rows(i).Cells("C1").Value.ToString + "','" + dgvTM_STOLL.Rows(i).Cells("C2").Value.ToString + "','" + dgvTM_STOLL.Rows(i).Cells("C3").Value.ToString + "','" + dgvTM_STOLL.Rows(i).Cells("C4").Value.ToString + "','" + dgvTM_STOLL.Rows(i).Cells("DESC").Value.ToString + "') "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Next
        Else
            'primero las mallas variables
            For i = 0 To 13
                sStr = "INSERT INTO PrendasArtProdPlanillas_MallasVariables (IdPlanilla,MallaVariable,Malla_D,Malla_T,Malla_Desc) VALUES ("
                sStr = sStr + ID.ToString + ", '" + dgvMallaVariable.Rows(i).Cells("MALLA").Value + "', '" + dgvMallaVariable.Rows(i).Cells("MALLA_D").Value + "', '"
                sStr = sStr + dgvMallaVariable.Rows(i).Cells("MALLA_T").Value + "', '" + dgvMallaVariable.Rows(i).Cells("MALLA_DESC").Value + "')"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
            Next
            For i = 0 To 19
                If dgvGC_SHIMA.Rows(i).Cells("DESC_1").Value.ToString <> "*************" Then
                    If dgvGC_SHIMA.Rows(i).Cells("chk_1").Value = True Then
                        Sombreado = "1"
                    Else
                        Sombreado = "0"
                    End If
                    sStr = "INSERT INTO PrendasArtProdPlanillas_GC (IdPlanilla,Letra,Cuadro1,Cuadro2,Descripcion,Sombreado) VALUES (" + ID.ToString
                    sStr = sStr + ",'" + dgvGC_SHIMA.Rows(i).Cells("LETRA_1").Value.ToString + "','" + dgvGC_SHIMA.Rows(i).Cells("C1_1").Value.ToString + "','" + dgvGC_SHIMA.Rows(i).Cells("C2_1").Value.ToString + "','" + dgvGC_SHIMA.Rows(i).Cells("DESC_1").Value.ToString + "'," + Sombreado + ") "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Next
            For i = 0 To 19
                If dgvGC_SHIMA.Rows(i).Cells("DESC_2").Value.ToString <> "*************" Then
                    If dgvGC_SHIMA.Rows(i).Cells("chk_2").Value = True Then
                        Sombreado = "1"
                    Else
                        Sombreado = "0"
                    End If
                    sStr = "INSERT INTO PrendasArtProdPlanillas_GC (IdPlanilla,Letra,Cuadro1,Cuadro2,Descripcion,Sombreado) VALUES (" + ID.ToString
                    sStr = sStr + ",'" + dgvGC_SHIMA.Rows(i).Cells("LETRA_2").Value.ToString + "','" + dgvGC_SHIMA.Rows(i).Cells("C1_2").Value.ToString + "','" + dgvGC_SHIMA.Rows(i).Cells("C2_2").Value.ToString + "','" + dgvGC_SHIMA.Rows(i).Cells("DESC_2").Value.ToString + "'," + Sombreado + ") "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Next
            For i = 0 To 19
                If dgvGM_SHIMA.Rows(i).Cells("DESC").Value.ToString <> "*************" Then
                    If dgvGM_SHIMA.Rows(i).Cells("chk").Value = True Then
                        Sombreado = "1"
                    Else
                        Sombreado = "0"
                    End If
                    sStr = "INSERT INTO PrendasArtProdPlanillas_GM (IdPlanilla,Letra,Cuadro1,Cuadro2,Descripcion,Sombreado) VALUES (" + ID.ToString
                    sStr = sStr + ",'" + dgvGM_SHIMA.Rows(i).Cells("LETRA").Value.ToString + "','" + dgvGM_SHIMA.Rows(i).Cells("C1").Value.ToString + "','" + dgvGM_SHIMA.Rows(i).Cells("C2").Value.ToString + "','" + dgvGM_SHIMA.Rows(i).Cells("DESC").Value.ToString + "'," + Sombreado + ") "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Next
            For i = 0 To 9
                If dgvTC_SHIMA.Rows(i).Cells("DESC_1").Value.ToString <> "*************" Then
                    sStr = "INSERT INTO PrendasArtProdPlanillas_TC (IdPlanilla,Letra,Cuadro1,Cuadro2,Cuadro3,Cuadro4,Descripcion) VALUES (" + ID.ToString
                    sStr = sStr + ",'" + dgvTC_SHIMA.Rows(i).Cells("LETRA_1").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("C1_1").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("C2_1").Value.ToString + "'"
                    sStr = sStr + ",'" + dgvTC_SHIMA.Rows(i).Cells("C3_1").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("C4_1").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("DESC_1").Value.ToString + "') "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Next
            For i = 0 To 9
                If dgvTC_SHIMA.Rows(i).Cells("DESC_2").Value.ToString <> "*************" Then
                    sStr = "INSERT INTO PrendasArtProdPlanillas_TC (IdPlanilla,Letra,Cuadro1,Cuadro2,Cuadro3,Cuadro4,Descripcion) VALUES (" + ID.ToString
                    sStr = sStr + ",'" + dgvTC_SHIMA.Rows(i).Cells("LETRA_2").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("C1_2").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("C2_2").Value.ToString + "'"
                    sStr = sStr + ",'" + dgvTC_SHIMA.Rows(i).Cells("C3_2").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("C4_2").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("DESC_2").Value.ToString + "') "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Next
            For i = 0 To 9
                If dgvTM_SHIMA.Rows(i).Cells("DESC").Value.ToString <> "*************" Then
                    sStr = "INSERT INTO PrendasArtProdPlanillas_TM (IdPlanilla,Letra,Cuadro1,Cuadro2,Cuadro3,Cuadro4,Descripcion) VALUES (" + ID.ToString
                    sStr = sStr + ",'" + dgvTM_SHIMA.Rows(i).Cells("LETRA").Value.ToString + "','" + dgvTM_SHIMA.Rows(i).Cells("C1").Value.ToString + "','" + dgvTM_SHIMA.Rows(i).Cells("C2").Value.ToString + "'"
                    sStr = sStr + ",'" + dgvTM_SHIMA.Rows(i).Cells("C3").Value.ToString + "','" + dgvTM_SHIMA.Rows(i).Cells("C4").Value.ToString + "','" + dgvTM_SHIMA.Rows(i).Cells("DESC").Value.ToString + "') "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Next
        End If

        RegistroEnHistorial("P", ID.ToString, "AltaPlanilla", LegajoLogueado)

        'una vez que copie todo 
        Cargar()

        MensajeAtencion("Planilla Copiada correctamente. Actualice el artículo, color, partida y demás datos necesarios")


    End Sub

    Private Sub CopiarConAccesorios()
        Dim IdPlanillaViejo, IdAccesorio As String
        Dim Command, CommandAux As New SqlCommand
        Dim Reader, ReaderAux As SqlDataReader
        Dim sStr, sStrAux As String

        Dim Sombreado As String = ""

        Dim i As Integer

        EstoyCopiando = True
        Alta = False

        IdPlanillaViejo = ID.ToString

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "INSERT INTO PrendasArtProdPlanillas SELECT IdCategoria,Articulo,OP,Diseño,Color,Partida,Ventana,MedidaElastico,CondicionCuerpos,VelocidadCuerpos,MedidaPuño"
        sStr = sStr + ",CondicionMangas,VelocidadMangas,TalleXXL_D,TalleXXL_E,TalleXXL_Bretel,TalleXXL_Esc,TalleXXL_Bolsillo,TalleXXL_Ancho,TalleXXL_Largo"
        sStr = sStr + ",TalleXXL_CueParamInicio,TalleXXL_CueCantAgujas,TalleXXL_Manga,TalleXXL_MangaParamInicio,TalleXXL_MangaCantAgujas,TalleXXL_MedInicial_D"
        sStr = sStr + ",TalleXXL_MedInicial_E,TalleXXL_MedInicial_M,TalleXL_D,TalleXL_E,TalleXL_Bretel,TalleXL_Esc,TalleXL_Bolsillo,TalleXL_Ancho,TalleXL_Largo"
        sStr = sStr + ",TalleXL_CueParamInicio,TalleXL_CueCantAgujas,TalleXL_Manga,TalleXL_MangaParamInicio,TalleXL_MangaCantAgujas,TalleXL_MedInicial_D"
        sStr = sStr + ",TalleXL_MedInicial_E,TalleXL_MedInicial_M,TalleL_D,TalleL_E,TalleL_Bretel,TalleL_Esc,TalleL_Bolsillo,TalleL_Ancho,TalleL_Largo"
        sStr = sStr + ",TalleL_CueParamInicio,TalleL_CueCantAgujas,TalleL_Manga,TalleL_MangaParamInicio,TalleL_MangaCantAgujas,TalleL_MedInicial_D,TalleL_MedInicial_E"
        sStr = sStr + ",TalleL_MedInicial_M,TalleM_D,TalleM_E,TalleM_Bretel,TalleM_Esc,TalleM_Bolsillo,TalleM_Ancho,TalleM_Largo,TalleM_CueParamInicio"
        sStr = sStr + ",TalleM_CueCantAgujas,TalleM_Manga,TalleM_MangaParamInicio,TalleM_MangaCantAgujas,TalleM_MedInicial_D,TalleM_MedInicial_E,TalleM_MedInicial_M"
        sStr = sStr + ",TalleS_D,TalleS_E,TalleS_Bretel,TalleS_Esc,TalleS_Bolsillo,TalleS_Ancho,TalleS_Largo,TalleS_CueParamInicio,TalleS_CueCantAgujas"
        sStr = sStr + ",TalleS_Manga,TalleS_MangaParamInicio,TalleS_MangaCantAgujas,TalleS_MedInicial_D,TalleS_MedInicial_E,TalleS_MedInicial_M,TalleXS_D"
        sStr = sStr + ",TalleXS_E,TalleXS_Bretel,TalleXS_Esc,TalleXS_Bolsillo,TalleXS_Ancho,TalleXS_Largo,TalleXS_CueParamInicio,TalleXS_CueCantAgujas,TalleXS_Manga"
        sStr = sStr + ",TalleXS_MangaParamInicio,TalleXS_MangaCantAgujas,TalleXS_MedInicial_D,TalleXS_MedInicial_E,TalleXS_MedInicial_M,Fecha,0,0,VentanaEspalda,VentanaManga,VentanaCapucha"
        sStr = sStr + ",TitTalleXXL,TitTalleXL,TitTalleL,TitTalleM,TitTalleS,TitTalleXS,[TalleXXL_Bretel_Tit],[TalleXXL_Esc_Tit],[TalleXXL_Bolsillo_Tit],[TalleXXL_Ancho_Tit]"
        sStr = sStr + ",[TalleXXL_Largo_Tit],[TalleXL_Bretel_Tit],[TalleXL_Esc_Tit],[TalleXL_Bolsillo_Tit],[TalleXL_Ancho_Tit],[TalleXL_Largo_Tit],[TalleL_Bretel_Tit],[TalleL_Esc_Tit]"
        sStr = sStr + ",[TalleL_Bolsillo_Tit],[TalleL_Ancho_Tit],[TalleL_Largo_Tit],[TalleM_Bretel_Tit],[TalleM_Esc_Tit],[TalleM_Bolsillo_Tit],[TalleM_Ancho_Tit],[TalleM_Largo_Tit]"
        sStr = sStr + ",[TalleS_Bretel_Tit],[TalleS_Esc_Tit],[TalleS_Bolsillo_Tit],[TalleS_Ancho_Tit],[TalleS_Largo_Tit],[TalleXS_Bretel_Tit],[TalleXS_Esc_Tit],[TalleXS_Bolsillo_Tit]"
        sStr = sStr + ",[TalleXS_Ancho_Tit],[TalleXS_Largo_Tit],RutaImagen, 0 , NroPrograma"
        sStr = sStr + " FROM PrendasArtProdPlanillas WHERE Id=" + ID.ToString
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        'una vez que inserto traigo el id asi inserto las demas cosas
        sStr = "SELECT max(id) as Id FROM PrendasArtProdPlanillas "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                ID = Reader.Item("Id").ToString
            End If
        End If

        If TipoUsuario = "Programacion" Or TipoUsuario = "Administrador" Then

            Dim nroPrograma As Integer
            If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
            sStr = "select NroPrograma from PrendasArtProdPlanillas where Id = (select max(id) from PrendasArtProdPlanillas)"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read Then
                    nroPrograma = CInt(Reader.Item("NroPrograma")) + 1
                End If
            End If

            sStr = "update PrendasArtProdPlanillas set NroPrograma = " + txtNroPrograma.Text + " where Id = " + ID.ToString
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()
        End If

        'despues de que inserte la copia, le borro los datos que debe cargar si o si
        sStr = "UPDATE PrendasArtProdPlanillas SET Fecha=getdate(),Articulo='',OP='',Color='',Partida='' WHERE Id=" + ID.ToString
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        'ya dejo guardadas las medidas de tiempo y peso
        sStr = "INSERT INTO PrendasArtProdPlanillas_TP (IdPlanilla,T_XXS,T_XS,T_S,T_M,T_L,T_XL,T_XXL,T_U,P_XXS,P_XS,P_S,P_M,P_L,P_XL,P_XXL,P_U,T_XXXL,P_XXXL) VALUES ("
        sStr = sStr + ID.ToString + ", '" + dgvTiempoyPeso.Rows(0).Cells("XXS").Value.ToString + "', '" + dgvTiempoyPeso.Rows(0).Cells("XS").Value.ToString + "', '"
        sStr = sStr + dgvTiempoyPeso.Rows(0).Cells("S").Value.ToString + "', '" + dgvTiempoyPeso.Rows(0).Cells("M").Value.ToString + "', '"
        sStr = sStr + dgvTiempoyPeso.Rows(0).Cells("L").Value.ToString + "', '" + dgvTiempoyPeso.Rows(0).Cells("XL").Value.ToString + "', '"
        sStr = sStr + dgvTiempoyPeso.Rows(0).Cells("XXL").Value.ToString + "', '" + dgvTiempoyPeso.Rows(0).Cells("U").Value.ToString + "', '"
        sStr = sStr + dgvTiempoyPeso.Rows(1).Cells("XXS").Value.ToString + "', '" + dgvTiempoyPeso.Rows(1).Cells("XS").Value.ToString + "', '"
        sStr = sStr + dgvTiempoyPeso.Rows(1).Cells("S").Value.ToString + "', '" + dgvTiempoyPeso.Rows(1).Cells("M").Value.ToString + "', '"
        sStr = sStr + dgvTiempoyPeso.Rows(1).Cells("L").Value.ToString + "', '" + dgvTiempoyPeso.Rows(1).Cells("XL").Value.ToString + "', '"
        sStr = sStr + dgvTiempoyPeso.Rows(1).Cells("XXL").Value.ToString + "', '" + dgvTiempoyPeso.Rows(1).Cells("U").Value.ToString + "', '"
        sStr = sStr + dgvTiempoyPeso.Rows(0).Cells("XXXL").Value.ToString + "', '" + dgvTiempoyPeso.Rows(1).Cells("XXXL").Value.ToString + "')"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        If TipoPlanilla = "STOLL" Then

            'primero los picos
            For i = 0 To 7
                sStr = "INSERT INTO PrendasArtProdPlanillas_Picos (IdPlanilla,Pico,Cuerpo_C1,Cuerpo_C2,Cuerpo_C3,Manga_C1,Manga_C2,Manga_C3) VALUES ("
                sStr = sStr + ID.ToString + ", '" + dgvPicos.Rows(i).Cells("Pico").Value + "', '" + dgvPicos.Rows(i).Cells("Cuerpo_C1").Value + "', '"
                sStr = sStr + dgvPicos.Rows(i).Cells("Cuerpo_C2").Value + "', '" + dgvPicos.Rows(i).Cells("Cuerpo_C3").Value + "', '"
                sStr = sStr + dgvPicos.Rows(i).Cells("Manga_C1").Value + "', '" + dgvPicos.Rows(i).Cells("Manga_C2").Value + "', '"
                sStr = sStr + dgvPicos.Rows(i).Cells("Manga_C3").Value + "')"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
            Next
            For i = 0 To 19
                If dgvGC_STOLL.Rows(i).Cells("DESC_1").Value.ToString <> "*************" Then
                    If dgvGC_STOLL.Rows(i).Cells("chk_1").Value = True Then
                        Sombreado = "1"
                    Else
                        Sombreado = "0"
                    End If
                    sStr = "INSERT INTO PrendasArtProdPlanillas_GC (IdPlanilla,Letra,Cuadro1,Cuadro2,Descripcion,Sombreado) VALUES (" + ID.ToString
                    sStr = sStr + ",'" + dgvGC_STOLL.Rows(i).Cells("LETRA_1").Value.ToString + "','" + dgvGC_STOLL.Rows(i).Cells("C1_1").Value.ToString + "','" + dgvGC_STOLL.Rows(i).Cells("C2_1").Value.ToString + "','" + dgvGC_STOLL.Rows(i).Cells("DESC_1").Value.ToString + "'," + Sombreado + ") "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Next
            For i = 0 To 19
                If dgvGC_STOLL.Rows(i).Cells("DESC_2").Value.ToString <> "*************" Then
                    If dgvGC_STOLL.Rows(i).Cells("chk_2").Value = True Then
                        Sombreado = "1"
                    Else
                        Sombreado = "0"
                    End If
                    sStr = "INSERT INTO PrendasArtProdPlanillas_GC (IdPlanilla,Letra,Cuadro1,Cuadro2,Descripcion,Sombreado) VALUES (" + ID.ToString
                    sStr = sStr + ",'" + dgvGC_STOLL.Rows(i).Cells("LETRA_2").Value.ToString + "','" + dgvGC_STOLL.Rows(i).Cells("C1_2").Value.ToString + "','" + dgvGC_STOLL.Rows(i).Cells("C2_2").Value.ToString + "','" + dgvGC_STOLL.Rows(i).Cells("DESC_2").Value.ToString + "'," + Sombreado + ") "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Next
            For i = 0 To 19
                If dgvGM_STOLL.Rows(i).Cells("DESC").Value.ToString <> "*************" Then
                    If dgvGM_STOLL.Rows(i).Cells("chk").Value = True Then
                        Sombreado = "1"
                    Else
                        Sombreado = "0"
                    End If
                    sStr = "INSERT INTO PrendasArtProdPlanillas_GM (IdPlanilla,Letra,Cuadro1,Cuadro2,Descripcion,Sombreado) VALUES (" + ID.ToString
                    sStr = sStr + ",'" + dgvGM_STOLL.Rows(i).Cells("LETRA").Value.ToString + "','" + dgvGM_STOLL.Rows(i).Cells("C1").Value.ToString + "','" + dgvGM_STOLL.Rows(i).Cells("C2").Value.ToString + "','" + dgvGM_STOLL.Rows(i).Cells("DESC").Value.ToString + "'," + Sombreado + ") "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Next
            For i = 0 To 9
                If dgvTC_STOLL.Rows(i).Cells("DESC_1").Value.ToString <> "*************" Then
                    sStr = "INSERT INTO PrendasArtProdPlanillas_TC (IdPlanilla,Letra,Cuadro1,Cuadro2,Cuadro3,Cuadro4,Descripcion) VALUES (" + ID.ToString
                    sStr = sStr + ",'" + dgvTC_STOLL.Rows(i).Cells("LETRA_1").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C1_1").Value.ToString
                    sStr = sStr + "','" + dgvTC_STOLL.Rows(i).Cells("C2_1").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C3_1").Value.ToString
                    sStr = sStr + "','" + dgvTC_STOLL.Rows(i).Cells("C4_1").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("DESC_1").Value.ToString + "') "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Next
            For i = 0 To 9
                If dgvTC_STOLL.Rows(i).Cells("DESC_2").Value.ToString <> "*************" Then
                    sStr = "INSERT INTO PrendasArtProdPlanillas_TC (IdPlanilla,Letra,Cuadro1,Cuadro2,Cuadro3,Cuadro4,Descripcion) VALUES (" + ID.ToString
                    sStr = sStr + ",'" + dgvTC_STOLL.Rows(i).Cells("LETRA_2").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C1_2").Value.ToString
                    sStr = sStr + "','" + dgvTC_STOLL.Rows(i).Cells("C2_2").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("C3_2").Value.ToString
                    sStr = sStr + "','" + dgvTC_STOLL.Rows(i).Cells("C4_2").Value.ToString + "','" + dgvTC_STOLL.Rows(i).Cells("DESC_2").Value.ToString + "') "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Next
            For i = 0 To 9
                If dgvTM_STOLL.Rows(i).Cells("DESC").Value.ToString <> "*************" Then
                    sStr = "INSERT INTO PrendasArtProdPlanillas_TM (IdPlanilla,Letra,Cuadro1,Cuadro2,Cuadro3,Cuadro4,Descripcion) VALUES (" + ID.ToString
                    sStr = sStr + ",'" + dgvTM_STOLL.Rows(i).Cells("LETRA").Value.ToString + "','" + dgvTM_STOLL.Rows(i).Cells("C1").Value.ToString
                    sStr = sStr + "','" + dgvTM_STOLL.Rows(i).Cells("C2").Value.ToString + "','" + dgvTM_STOLL.Rows(i).Cells("C3").Value.ToString
                    sStr = sStr + "','" + dgvTM_STOLL.Rows(i).Cells("C4").Value.ToString + "','" + dgvTM_STOLL.Rows(i).Cells("DESC").Value.ToString + "') "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Next
        Else
            'primero las mallas variables
            For i = 0 To 13
                sStr = "INSERT INTO PrendasArtProdPlanillas_MallasVariables (IdPlanilla,MallaVariable,Malla_D,Malla_T,Malla_Desc) VALUES ("
                sStr = sStr + ID.ToString + ", '" + dgvMallaVariable.Rows(i).Cells("MALLA").Value + "', '" + dgvMallaVariable.Rows(i).Cells("MALLA_D").Value + "', '"
                sStr = sStr + dgvMallaVariable.Rows(i).Cells("MALLA_T").Value + "', '" + dgvMallaVariable.Rows(i).Cells("MALLA_DESC").Value + "')"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
            Next
            For i = 0 To 19
                If dgvGC_SHIMA.Rows(i).Cells("DESC_1").Value.ToString <> "*************" Then
                    If dgvGC_SHIMA.Rows(i).Cells("chk_1").Value = True Then
                        Sombreado = "1"
                    Else
                        Sombreado = "0"
                    End If
                    sStr = "INSERT INTO PrendasArtProdPlanillas_GC (IdPlanilla,Letra,Cuadro1,Cuadro2,Descripcion,Sombreado) VALUES (" + ID.ToString
                    sStr = sStr + ",'" + dgvGC_SHIMA.Rows(i).Cells("LETRA_1").Value.ToString + "','" + dgvGC_SHIMA.Rows(i).Cells("C1_1").Value.ToString + "','" + dgvGC_SHIMA.Rows(i).Cells("C2_1").Value.ToString + "','" + dgvGC_SHIMA.Rows(i).Cells("DESC_1").Value.ToString + "'," + Sombreado + ") "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Next
            For i = 0 To 19
                If dgvGC_SHIMA.Rows(i).Cells("DESC_2").Value.ToString <> "*************" Then
                    If dgvGC_SHIMA.Rows(i).Cells("chk_2").Value = True Then
                        Sombreado = "1"
                    Else
                        Sombreado = "0"
                    End If
                    sStr = "INSERT INTO PrendasArtProdPlanillas_GC (IdPlanilla,Letra,Cuadro1,Cuadro2,Descripcion,Sombreado) VALUES (" + ID.ToString
                    sStr = sStr + ",'" + dgvGC_SHIMA.Rows(i).Cells("LETRA_2").Value.ToString + "','" + dgvGC_SHIMA.Rows(i).Cells("C1_2").Value.ToString + "','" + dgvGC_SHIMA.Rows(i).Cells("C2_2").Value.ToString + "','" + dgvGC_SHIMA.Rows(i).Cells("DESC_2").Value.ToString + "'," + Sombreado + ") "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Next
            For i = 0 To 19
                If dgvGM_SHIMA.Rows(i).Cells("DESC").Value.ToString <> "*************" Then
                    If dgvGM_SHIMA.Rows(i).Cells("chk").Value = True Then
                        Sombreado = "1"
                    Else
                        Sombreado = "0"
                    End If
                    sStr = "INSERT INTO PrendasArtProdPlanillas_GM (IdPlanilla,Letra,Cuadro1,Cuadro2,Descripcion,Sombreado) VALUES (" + ID.ToString
                    sStr = sStr + ",'" + dgvGM_SHIMA.Rows(i).Cells("LETRA").Value.ToString + "','" + dgvGM_SHIMA.Rows(i).Cells("C1").Value.ToString + "','" + dgvGM_SHIMA.Rows(i).Cells("C2").Value.ToString + "','" + dgvGM_SHIMA.Rows(i).Cells("DESC").Value.ToString + "'," + Sombreado + ") "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Next
            For i = 0 To 9
                If dgvTC_SHIMA.Rows(i).Cells("DESC_1").Value.ToString <> "*************" Then
                    sStr = "INSERT INTO PrendasArtProdPlanillas_TC (IdPlanilla,Letra,Cuadro1,Cuadro2,Cuadro3,Cuadro4,Descripcion) VALUES (" + ID.ToString
                    sStr = sStr + ",'" + dgvTC_SHIMA.Rows(i).Cells("LETRA_1").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("C1_1").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("C2_1").Value.ToString + "'"
                    sStr = sStr + ",'" + dgvTC_SHIMA.Rows(i).Cells("C3_1").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("C4_1").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("DESC_1").Value.ToString + "') "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Next
            For i = 0 To 9
                If dgvTC_SHIMA.Rows(i).Cells("DESC_2").Value.ToString <> "*************" Then
                    sStr = "INSERT INTO PrendasArtProdPlanillas_TC (IdPlanilla,Letra,Cuadro1,Cuadro2,Cuadro3,Cuadro4,Descripcion) VALUES (" + ID.ToString
                    sStr = sStr + ",'" + dgvTC_SHIMA.Rows(i).Cells("LETRA_2").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("C1_2").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("C2_2").Value.ToString + "'"
                    sStr = sStr + ",'" + dgvTC_SHIMA.Rows(i).Cells("C3_2").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("C4_2").Value.ToString + "','" + dgvTC_SHIMA.Rows(i).Cells("DESC_2").Value.ToString + "') "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Next
            For i = 0 To 9
                If dgvTM_SHIMA.Rows(i).Cells("DESC").Value.ToString <> "*************" Then
                    sStr = "INSERT INTO PrendasArtProdPlanillas_TM (IdPlanilla,Letra,Cuadro1,Cuadro2,Cuadro3,Cuadro4,Descripcion) VALUES (" + ID.ToString
                    sStr = sStr + ",'" + dgvTM_SHIMA.Rows(i).Cells("LETRA").Value.ToString + "','" + dgvTM_SHIMA.Rows(i).Cells("C1").Value.ToString + "','" + dgvTM_SHIMA.Rows(i).Cells("C2").Value.ToString + "'"
                    sStr = sStr + ",'" + dgvTM_SHIMA.Rows(i).Cells("C3").Value.ToString + "','" + dgvTM_SHIMA.Rows(i).Cells("C4").Value.ToString + "','" + dgvTM_SHIMA.Rows(i).Cells("DESC").Value.ToString + "') "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Next
        End If

        IdAccesorio = ""
        'me traigo la lista de accesorios y uno a uno voy insertandolos junto con sus graduaciones y sus picos
        sStr = "SELECT * FROM PrendasArtProdPlanillasAccesorios WHERE IdPlanilla =" + IdPlanillaViejo
        sStr = sStr & " AND isnull(Eliminado,0)=0 ORDER BY Id"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()

                sStr = "INSERT INTO PrendasArtProdPlanillasAccesorios Select " + ID.ToString + ",DescAccesorio,Fecha,Articulo,OP,Patron,Color,Partida,MedidaFinal,Cuadro1,Cuadro2,Cuadro3"
                sStr = sStr + ",Cuadro4,Cuadro5,Cuadro6,Cuadro7,Cuadro8,Eliminado FROM PrendasArtProdPlanillasAccesorios where ID= " + Reader.Item("Id").ToString
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()

                'una vez que inserto traigo el id asi inserto las demas cosas
                sStrAux = "SELECT max(id) as Id FROM PrendasArtProdPlanillasAccesorios WHERE IdPlanilla=" + ID.ToString
                CommandAux = New SqlCommand(sStrAux, cConexionApp.SQLConn)
                ReaderAux = CommandAux.ExecuteReader()
                If ReaderAux.HasRows Then
                    If ReaderAux.Read Then
                        IdAccesorio = ReaderAux.Item("Id").ToString

                        'las graduaciones
                        sStr = "INSERT INTO PrendasArtProdPlanillasAcces_Graduaciones "
                        sStr = sStr + " SELECT " + IdAccesorio + ",Letra,Cuadro1,Cuadro2,Descripcion1,Descripcion2 FROM PrendasArtProdPlanillasAcces_Graduaciones "
                        sStr = sStr + " WHERE IdAccesorio=" + Reader.Item("Id").ToString
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()

                        'los picos

                        sStr = "INSERT INTO PrendasArtProdPlanillasAcces_Picos "
                        sStr = sStr + " SELECT " + IdAccesorio + ",Pico,Derecha1,Derecha2,Izquierda1,Izquierda2 FROM PrendasArtProdPlanillasAcces_Picos "
                        sStr = sStr + " WHERE IdAccesorio=" + Reader.Item("Id").ToString
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                End If

                RegistroEnHistorial("A", IdAccesorio.ToString, "AltaAccesorio", LegajoLogueado)

            Loop
            Reader.NextResult()
        Loop


        RegistroEnHistorial("P", ID.ToString, "AltaPlanilla", LegajoLogueado)

        'una vez que copie todo 
        Cargar()

        MensajeAtencion("Planilla Copiada correctamente. Actualice el artículo, color, partida y demás datos necesarios")


    End Sub

    Private Sub EliminarPlanillaCopiada(ByVal IdPlani As String)
        Dim IdAccesorio As String
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        'borro la planilla 
        sStr = "DELETE FROM PrendasArtProdPlanillas WHERE Id=" + IdPlani
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        'borro las medidas de tiempo y peso
        sStr = "DELETE FROM PrendasArtProdPlanillas_TP WHERE IdPlanilla=" + IdPlani
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()
        'borro los picos
        sStr = "DELETE FROM PrendasArtProdPlanillas_Picos WHERE IdPlanilla=" + IdPlani
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()
        'borro las graduaciones de cuerpos
        sStr = "DELETE FROM PrendasArtProdPlanillas_GC WHERE IdPlanilla=" + IdPlani
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()
        'borro las graduaciones de mangas
        sStr = "DELETE FROM PrendasArtProdPlanillas_GM WHERE IdPlanilla=" + IdPlani
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()
        'borro los tirajes de cuerpos
        sStr = "DELETE FROM PrendasArtProdPlanillas_TC WHERE IdPlanilla=" + IdPlani
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()
        'borro los tirajes de mangas
        sStr = "DELETE FROM PrendasArtProdPlanillas_TM WHERE IdPlanilla=" + IdPlani
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()
        'borro las mallas variables
        sStr = "DELETE FROM PrendasArtProdPlanillas_MallasVariables WHERE IdPlanilla=" + IdPlani
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        IdAccesorio = ""
        'me traigo la lista de accesorios y uno a uno voy borrando sus graduaciones y sus picos
        sStr = "SELECT * FROM PrendasArtProdPlanillasAccesorios WHERE IdPlanilla =" + IdPlani
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                IdAccesorio = Reader.Item("Id").ToString
                'las graduaciones
                sStr = "DELETE FROM PrendasArtProdPlanillasAcces_Graduaciones WHERE IdAccesorio=" + IdAccesorio
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
                'los picos
                sStr = "DELETE FROM PrendasArtProdPlanillasAcces_Picos WHERE IdAccesorio=" + IdAccesorio
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
                'el historial del accesorio
                sStr = "DELETE FROM PrendasArtProdPlanillasHistorial WHERE TipoElem='A' and IdElem=" + IdAccesorio + ""
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
            Loop
            Reader.NextResult()
        Loop
        'luego borro los accesorios
        sStr = "DELETE FROM PrendasArtProdPlanillasAccesorios WHERE IdPlanilla=" + IdPlani
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        'y el historial de la planilla
        sStr = "DELETE FROM PrendasArtProdPlanillasHistorial WHERE TipoElem='P' and IdElem=" + IdPlani + ""
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

    End Sub

    Private Function Validar() As Boolean
        On Error GoTo ErrValidar
        Dim i, j As Integer
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        If Not Alta And ElArticuloEsOriginal Then
            Validar = False
            MensajeAtencion("El artículo está marcado como ORIGINAL. No puede ser editado.")
            Exit Function
        End If

        If cmbCategoria.Text = "" Then
            Validar = False
            MensajeAtencion("Debe Seleccionar una categoría para el artículo.")
            Exit Function
        End If

        If txtArticulo.Text = "" Then
            Validar = False
            MensajeAtencion("Debe ingresar un Artículo.")
            Exit Function
        End If

        'If Not IsNumeric(txtArticulo.Text) Then
        '    Validar = False
        '    MensajeAtencion("El artículo debe ser un número.")
        '    Exit Function
        'End If

        If Strings.InStr(txtColor.Text, "-") > 0 Then
            Validar = False
            MensajeAtencion("El color tiene un guión (""-""). No puede utilizar guiones en el color.")
            Exit Function
        End If

        If Alta Or (Not Alta And (txtArticulo.Text <> CodArtOriginal Or txtColor.Text <> ColorOriginal Or txtPartida.Text <> PartidaOriginal)) Then
            If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
            sStr = "SELECT * FROM PrendasArtProdPlanillas WHERE Articulo = '" + txtArticulo.Text + "' and Color='" + txtColor.Text + "' and Partida='" + txtPartida.Text + "'"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read Then
                    Validar = False
                    MensajeAtencion("Ya existe una Planilla con igual Artículo, Color y Partida.")
                    Exit Function
                End If
            End If
        End If

        'controlo que el dgv de tiempos y pesos no tenga texto mas largo que el permitido
        For i = 0 To dgvTiempoyPeso.RowCount - 1
            For j = 0 To dgvTiempoyPeso.ColumnCount - 1
                If Not IsNothing(dgvTiempoyPeso.Rows(i).Cells(j).Value) Then
                    If dgvTiempoyPeso.Rows(i).Cells(j).Value.ToString.Length > 20 Then
                        Validar = False
                        MensajeAtencion("El texto escrito es demasiado largo. " + Chr(10) + "Dato: " + dgvTiempoyPeso.Rows(i).Cells(0).Value.ToString + Chr(10) + _
                                        "Talle: " + dgvTiempoyPeso.Columns(j).HeaderText + Chr(10) + "Verifique.")
                        Exit Function
                    End If
                Else
                    dgvTiempoyPeso.Rows(i).Cells(j).Value = ""
                End If
            Next j
        Next i

        Validar = True

        Exit Function
ErrValidar:
        Validar = False
        MensajeAtencion("Error al validar.")
    End Function

    Private Sub txtDiseño_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDiseño.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtColor.Select()
        End If
        If e.KeyChar = Convert.ToChar(Keys.Escape) Then Close()
    End Sub
    Private Sub txtColor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtColor.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtPartida.Select()
        End If
    End Sub
    Private Sub txtPartida_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPartida.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtVentDel.Select()
        End If
    End Sub
    Private Sub txtVentDel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVentDel.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtVentEsp.Select()
        End If
    End Sub
    Private Sub txtVentesp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVentEsp.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtVentMan.Select()
        End If
    End Sub
    Private Sub txtVentMan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVentMan.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtVentCap.Select()
        End If
    End Sub
    Private Sub txtVentCap_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVentCap.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtOp.Select()
        End If
    End Sub
    Private Sub txtOp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOp.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtArticulo.Select()
        End If
    End Sub
    Private Sub txtArticulo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtArticulo.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            cmdGuardar.Select()
        End If
    End Sub

    Private Sub dgvCorrecciones_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCorrecciones.CellValueChanged
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        'si entro porque modifque la columna 0 no tiene que dejar registro porque esa columna es mia interna
        If e.ColumnIndex = 0 Then Exit Sub

        Dim FechaAux, CorrAux As String

        Dim IdNuevaCorreccion As String

        If IsNothing(dgvCorrecciones.Rows(e.RowIndex).Cells(1).Value) Then
            FechaAux = "NULL"
        Else
            FechaAux = "'" + dgvCorrecciones.Rows(e.RowIndex).Cells(1).Value.ToString + "'"
        End If

        If IsNothing(dgvCorrecciones.Rows(e.RowIndex).Cells(2).Value) Then
            CorrAux = "NULL"
        Else
            CorrAux = "'" + dgvCorrecciones.Rows(e.RowIndex).Cells(2).Value.ToString + "'"
        End If

        If dgvCorrecciones.Rows(e.RowIndex).Cells(0).Value.ToString = "" Then

            sStr = "INSERT INTO PrendasArtProdPlanillasCorrecciones (IdPlanilla,Fecha,Correccion) VALUES ("
            sStr = sStr + ID.ToString + ", " + FechaAux
            sStr = sStr + "," + CorrAux + ")"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()

            'y despues de insertarlo agarro el id de la correccion asi lo puedo cargar en el historial
            sStr = "SELECT max(Id) as Id FROM PrendasArtProdPlanillasCorrecciones "
            sStr = sStr + " WHERE IdPlanilla=" + ID.ToString + " and Fecha=" + FechaAux + " "
            sStr = sStr + " and Correccion=" + CorrAux + ""
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read() Then
                    IdNuevaCorreccion = Reader.Item("Id").ToString
                    dgvCorrecciones.Rows(e.RowIndex).Cells(0).Value = IdNuevaCorreccion
                    RegistroEnHistorial("C", IdNuevaCorreccion, "AltaCorreccion", LegajoLogueado, FechaAux, CorrAux)
                End If
            End If

        Else

            sStr = "UPDATE PrendasArtProdPlanillasCorrecciones SET "
            sStr = sStr + "Fecha= " + FechaAux + ""
            sStr = sStr + ",Correccion=" + CorrAux + " "
            sStr = sStr + " WHERE Id=" + dgvCorrecciones.Rows(e.RowIndex).Cells(0).Value.ToString
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()

            RegistroEnHistorial("C", dgvCorrecciones.Rows(e.RowIndex).Cells(0).Value.ToString, "ModifCorreccion", LegajoLogueado, FechaAux, CorrAux)

        End If

    End Sub

    'Private Sub dgvPicos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPicos.CellEndEdit
    '    Dim Command As New SqlCommand
    '    Dim Reader As SqlDataReader
    '    Dim sStr As String

    '    Dim Pico, Cuerpo_C1, Cuerpo_C2, Cuerpo_C3, Manga_C1, Manga_C2, Manga_C3 As String

    '    Dim IdNuevoPico As String

    '    If IsNothing(dgvPicos.Rows(e.RowIndex).Cells("Pico").Value) Then
    '        Pico = "''"
    '    Else
    '        Pico = "'" + dgvPicos.Rows(e.RowIndex).Cells("Pico").Value.ToString + "'"
    '    End If
    '    If IsNothing(dgvPicos.Rows(e.RowIndex).Cells("Cuerpo_C1").Value) Then
    '        Cuerpo_C1 = "''"
    '    Else
    '        Cuerpo_C1 = "'" + dgvPicos.Rows(e.RowIndex).Cells("Cuerpo_C1").Value.ToString + "'"
    '    End If
    '    If IsNothing(dgvPicos.Rows(e.RowIndex).Cells("Cuerpo_C2").Value) Then
    '        Cuerpo_C2 = "''"
    '    Else
    '        Cuerpo_C2 = "'" + dgvPicos.Rows(e.RowIndex).Cells("Cuerpo_C2").Value.ToString + "'"
    '    End If
    '    If IsNothing(dgvPicos.Rows(e.RowIndex).Cells("Cuerpo_C3").Value) Then
    '        Cuerpo_C3 = "''"
    '    Else
    '        Cuerpo_C3 = "'" + dgvPicos.Rows(e.RowIndex).Cells("Cuerpo_C3").Value.ToString + "'"
    '    End If
    '    If IsNothing(dgvPicos.Rows(e.RowIndex).Cells("Manga_C1").Value) Then
    '        Manga_C1 = "''"
    '    Else
    '        Manga_C1 = "'" + dgvPicos.Rows(e.RowIndex).Cells("Manga_C1").Value.ToString + "'"
    '    End If
    '    If IsNothing(dgvPicos.Rows(e.RowIndex).Cells("Manga_C2").Value) Then
    '        Manga_C2 = "''"
    '    Else
    '        Manga_C2 = "'" + dgvPicos.Rows(e.RowIndex).Cells("Manga_C2").Value.ToString + "'"
    '    End If
    '    If IsNothing(dgvPicos.Rows(e.RowIndex).Cells("Manga_C3").Value) Then
    '        Manga_C3 = "''"
    '    Else
    '        Manga_C3 = "'" + dgvPicos.Rows(e.RowIndex).Cells("Manga_C3").Value.ToString + "'"
    '    End If

    '    If dgvPicos.Rows(e.RowIndex).Cells("IDPICO").Value.ToString = "" Then

    '        sStr = "INSERT INTO PrendasArtProdPlanillas_Picos (IdPlanilla,Pico,Cuerpo_C1,Cuerpo_C2,Cuerpo_C3,Manga_C1,Manga_C2,Manga_C3) VALUES ("
    '        sStr = sStr + ID.ToString + ", " + Pico + ", " + Cuerpo_C1 + ", " + Cuerpo_C2 + ", " + Cuerpo_C3 + ", " + Manga_C1 + ", " + Manga_C2 + ", " + Manga_C3
    '        sStr = sStr + ")"
    '        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
    '        Command.ExecuteNonQuery()

    '        'y despues de insertarlo agarro el id de la correccion asi lo puedo cargar en el historial
    '        sStr = "SELECT max(Id) as Id FROM PrendasArtProdPlanillas_Picos "
    '        sStr = sStr + " WHERE IdPlanilla=" + ID.ToString + " and Pico=" + Pico + " and Cuerpo_C1=" + Cuerpo_C1 + " and Cuerpo_C2=" + Cuerpo_C2
    '        sStr = sStr + " and Cuerpo_C3=" + Cuerpo_C3 + " and Manga_C1=" + Manga_C1 + " and Manga_C2=" + Manga_C2 + " and Manga_C3=" + Manga_C3
    '        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
    '        Reader = Command.ExecuteReader()
    '        If Reader.HasRows Then
    '            If Reader.Read() Then
    '                IdNuevoPico = Reader.Item("Id").ToString
    '                dgvPicos.Rows(e.RowIndex).Cells(0).Value = IdNuevoPico
    '                RegistroEnHistorial("P", ID.ToString, "ModifPlanilla", LegajoLogueado)
    '            End If
    '        End If

    '    Else

    '        sStr = "UPDATE PrendasArtProdPlanillas_Picos SET "
    '        sStr = sStr + "Pico= " + Pico + " ,Cuerpo_C1=" + Cuerpo_C1 + " ,Cuerpo_C2=" + Cuerpo_C2 + " ,Cuerpo_C3=" + Cuerpo_C3
    '        sStr = sStr + " ,Manga_C1=" + Manga_C1 + " ,Manga_C2=" + Manga_C2 + " ,Manga_C3=" + Manga_C3
    '        sStr = sStr + " WHERE Id=" + dgvPicos.Rows(e.RowIndex).Cells("IDPICO").Value.ToString
    '        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
    '        Command.ExecuteNonQuery()

    '        RegistroEnHistorial("P", ID.ToString, "ModifPlanilla", LegajoLogueado)

    '    End If


    'End Sub

    Private Sub RegistroEnHistorial(ByVal TipoElem As String, ByVal IdElem As String, ByVal TipoModif As String, ByVal Legajo As String, Optional ByVal Fecha As String = "", Optional ByVal Correccion As String = "")
        Dim Command As New SqlCommand
        Dim sStr As String

        If TipoElem = "C" Then
            sStr = "INSERT INTO PrendasArtProdPlanillasHistorial (TipoElem,IdElem,TipoModif,FechaModif,Legajo,Fecha,Correccion) VALUES ('"
            sStr = sStr + TipoElem + "', '" + IdElem + "', '" + TipoModif + "',getdate(),'" + Legajo + "'," + Fecha + "," + Correccion + ")"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()
        Else
            sStr = "INSERT INTO PrendasArtProdPlanillasHistorial (TipoElem,IdElem,TipoModif,FechaModif,Legajo,Fecha,Correccion) VALUES ('"
            sStr = sStr + TipoElem + "', '" + IdElem + "', '" + TipoModif + "',getdate(),'" + Legajo + "',NULL,NULL)"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()
        End If
    End Sub

    '##########################################################################################################################################################
    '##########################################################################################################################################################
    '##########################################################################################################################################################
    '##########################################################################################################################################################
    Private Sub CrearArraysDeGraduaciondeCuerposSTOLL()
        Dim row As String()

        dgvGC_STOLL.Rows.Clear()
        dgvGC_STOLL.Columns.Clear()

        Dim chk_1, chk_2 As New DataGridViewCheckBoxColumn()
        chk_1.HeaderText = "S"
        chk_1.Name = "chk_1"
        chk_2.HeaderText = "S"
        chk_2.Name = "chk_2"

        dgvGC_STOLL.Columns.Add(chk_1)
        dgvGC_STOLL.Columns("chk_1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGC_STOLL.Columns("chk_1").Width = 20
        dgvGC_STOLL.Columns.Add("LETRA_1", "LETRA_1")
        dgvGC_STOLL.Columns("LETRA_1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvGC_STOLL.Columns("LETRA_1").Width = 31
        dgvGC_STOLL.Columns.Add("C1_1", "C1_1")
        dgvGC_STOLL.Columns("C1_1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGC_STOLL.Columns("C1_1").Width = 45
        dgvGC_STOLL.Columns.Add("C2_1", "C2_1")
        dgvGC_STOLL.Columns("C2_1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGC_STOLL.Columns("C2_1").Width = 45
        dgvGC_STOLL.Columns.Add("DESC_1", "DESC_1")
        dgvGC_STOLL.Columns("DESC_1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGC_STOLL.Columns("DESC_1").Width = 162
        dgvGC_STOLL.Columns.Add(chk_2)
        dgvGC_STOLL.Columns("chk_2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGC_STOLL.Columns("chk_2").Width = 20
        dgvGC_STOLL.Columns.Add("LETRA_2", "LETRA_2")
        dgvGC_STOLL.Columns("LETRA_2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvGC_STOLL.Columns("LETRA_2").Width = 31
        dgvGC_STOLL.Columns.Add("C1_2", "C1_2")
        dgvGC_STOLL.Columns("C1_2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGC_STOLL.Columns("C1_2").Width = 45
        dgvGC_STOLL.Columns.Add("C2_2", "C2_2")
        dgvGC_STOLL.Columns("C2_2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGC_STOLL.Columns("C2_2").Width = 45
        dgvGC_STOLL.Columns.Add("DESC_2", "DESC_2")
        dgvGC_STOLL.Columns("DESC_2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGC_STOLL.Columns("DESC_2").Width = 162

        dgvGC_STOLL.ColumnHeadersVisible = False
        dgvGC_STOLL.RowHeadersVisible = False
        dgvGC_STOLL.DefaultCellStyle.Font = New Font("Tahoma", 9)
        dgvGC_STOLL.RowTemplate.Height = 20
        'dgvGC_STOLL.DefaultCellStyle.SelectionBackColor = Color.White
        'dgvGC_STOLL.DefaultCellStyle.SelectionForeColor = Color.Black

        dgvGC_STOLL.Top = lblTitGraduacionCuerpos.Top + lblTitGraduacionCuerpos.Height
        dgvGC_STOLL.Left = 0
        dgvGC_STOLL.Width = 609
        dgvGC_STOLL.Height = 403

        For i As Integer = 0 To 19
            row = {False, "NP", "0", "0", "*************", False, "NP", "0", "0", "*************"}
            dgvGC_STOLL.Rows.Add(row)
        Next

    End Sub

    Private Sub CrearArraysDeGraduaciondeMangasSTOLL()
        Dim row As String()

        dgvGM_STOLL.Rows.Clear()
        dgvGM_STOLL.Columns.Clear()

        Dim chk As New DataGridViewCheckBoxColumn()
        chk.HeaderText = "S"
        chk.Name = "chk"

        dgvGM_STOLL.Columns.Add(chk)
        dgvGM_STOLL.Columns("chk").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGM_STOLL.Columns("chk").Width = 20
        dgvGM_STOLL.Columns.Add("LETRA", "LETRA")
        dgvGM_STOLL.Columns("LETRA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvGM_STOLL.Columns("LETRA").Width = 31
        dgvGM_STOLL.Columns.Add("C1", "C1")
        dgvGM_STOLL.Columns("C1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGM_STOLL.Columns("C1").Width = 45
        dgvGM_STOLL.Columns.Add("C2", "C2")
        dgvGM_STOLL.Columns("C2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGM_STOLL.Columns("C2").Width = 45
        dgvGM_STOLL.Columns.Add("DESC", "DESC")
        dgvGM_STOLL.Columns("DESC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGM_STOLL.Columns("DESC").Width = 166

        dgvGM_STOLL.ColumnHeadersVisible = False
        dgvGM_STOLL.RowHeadersVisible = False
        dgvGM_STOLL.DefaultCellStyle.Font = New Font("Tahoma", 9)
        dgvGM_STOLL.RowTemplate.Height = 20

        dgvGM_STOLL.Top = lblTitGraduacionCuerpos.Top + lblTitGraduacionCuerpos.Height
        dgvGM_STOLL.Left = 609
        dgvGM_STOLL.Width = 310
        dgvGM_STOLL.Height = 403

        For i As Integer = 0 To 19
            row = {False, "NP", "0", "0", "*************"}
            dgvGM_STOLL.Rows.Add(row)
        Next

    End Sub
    Private Sub CrearArraysDeTirajedeCuerposSTOLL()
        Dim row As String()

        dgvTC_STOLL.Rows.Clear()
        dgvTC_STOLL.Columns.Clear()


        dgvTC_STOLL.Columns.Add("LETRA_1", "LETRA_1")
        dgvTC_STOLL.Columns("LETRA_1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvTC_STOLL.Columns("LETRA_1").Width = 35
        dgvTC_STOLL.Columns.Add("C1_1", "C1_1")
        dgvTC_STOLL.Columns("C1_1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTC_STOLL.Columns("C1_1").Width = 30
        dgvTC_STOLL.Columns.Add("C2_1", "C2_1")
        dgvTC_STOLL.Columns("C2_1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTC_STOLL.Columns("C2_1").Width = 30
        dgvTC_STOLL.Columns.Add("C3_1", "C3_1")
        dgvTC_STOLL.Columns("C3_1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTC_STOLL.Columns("C3_1").Width = 30
        dgvTC_STOLL.Columns.Add("C4_1", "C4_1")
        dgvTC_STOLL.Columns("C4_1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTC_STOLL.Columns("C4_1").Width = 30
        dgvTC_STOLL.Columns.Add("DESC_1", "DESC_1")
        dgvTC_STOLL.Columns("DESC_1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTC_STOLL.Columns("DESC_1").Width = 148
        dgvTC_STOLL.Columns.Add("LETRA_2", "LETRA_2")
        dgvTC_STOLL.Columns("LETRA_2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvTC_STOLL.Columns("LETRA_2").Width = 35
        dgvTC_STOLL.Columns.Add("C1_2", "C1_2")
        dgvTC_STOLL.Columns("C1_2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTC_STOLL.Columns("C1_2").Width = 30
        dgvTC_STOLL.Columns.Add("C2_2", "C2_2")
        dgvTC_STOLL.Columns("C2_2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTC_STOLL.Columns("C2_2").Width = 30
        dgvTC_STOLL.Columns.Add("C3_2", "C3_2")
        dgvTC_STOLL.Columns("C3_2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTC_STOLL.Columns("C3_2").Width = 30
        dgvTC_STOLL.Columns.Add("C4_2", "C4_2")
        dgvTC_STOLL.Columns("C4_2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTC_STOLL.Columns("C4_2").Width = 30
        dgvTC_STOLL.Columns.Add("DESC_2", "DESC_2")
        dgvTC_STOLL.Columns("DESC_2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTC_STOLL.Columns("DESC_2").Width = 148

        dgvTC_STOLL.ColumnHeadersVisible = False
        dgvTC_STOLL.RowHeadersVisible = False
        dgvTC_STOLL.DefaultCellStyle.Font = New Font("Tahoma", 8)
        dgvTC_STOLL.RowTemplate.Height = 20

        dgvTC_STOLL.Top = lblTitTirajeCuerpos.Top + lblTitTirajeCuerpos.Height
        dgvTC_STOLL.Left = 0
        dgvTC_STOLL.Width = 610
        dgvTC_STOLL.Height = 205

        For i As Integer = 0 To 9
            row = {"WMF", "0", "0", "0", "0", "*************", "WMF", "0", "0", "0", "0", "*************"}
            dgvTC_STOLL.Rows.Add(row)
        Next

    End Sub
    Private Sub CrearArraysDeTirajedeMangasSTOLL()
        Dim row As String()

        dgvTM_STOLL.Rows.Clear()
        dgvTM_STOLL.Columns.Clear()


        dgvTM_STOLL.Columns.Add("LETRA", "LETRA")
        dgvTM_STOLL.Columns("LETRA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvTM_STOLL.Columns("LETRA").Width = 35
        dgvTM_STOLL.Columns.Add("C1", "C1")
        dgvTM_STOLL.Columns("C1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTM_STOLL.Columns("C1").Width = 35
        dgvTM_STOLL.Columns.Add("C2", "C2")
        dgvTM_STOLL.Columns("C2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTM_STOLL.Columns("C2").Width = 35
        dgvTM_STOLL.Columns.Add("C3", "C3")
        dgvTM_STOLL.Columns("C3").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTM_STOLL.Columns("C3").Width = 35
        dgvTM_STOLL.Columns.Add("C4", "C4")
        dgvTM_STOLL.Columns("C4").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTM_STOLL.Columns("C4").Width = 35
        dgvTM_STOLL.Columns.Add("DESC", "DESC")
        dgvTM_STOLL.Columns("DESC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTM_STOLL.Columns("DESC").Width = 131

        dgvTM_STOLL.ColumnHeadersVisible = False
        dgvTM_STOLL.RowHeadersVisible = False
        dgvTM_STOLL.DefaultCellStyle.Font = New Font("Tahoma", 8)
        dgvTM_STOLL.RowTemplate.Height = 20

        dgvTM_STOLL.Top = lblTitTirajeMangas.Top + lblTitTirajeMangas.Height
        dgvTM_STOLL.Left = 610
        dgvTM_STOLL.Width = 309
        dgvTM_STOLL.Height = 205

        For i As Integer = 0 To 9
            row = {"WMF", "0", "0", "0", "0", "*************"}
            dgvTM_STOLL.Rows.Add(row)
        Next

    End Sub
    Private Sub CrearArraysDeGraduaciondeCuerposSHIMA()
        Dim row As String()

        dgvGC_SHIMA.Rows.Clear()
        dgvGC_SHIMA.Columns.Clear()

        Dim chk_1, chk_2 As New DataGridViewCheckBoxColumn()
        chk_1.HeaderText = "S"
        chk_1.Name = "chk_1"
        chk_2.HeaderText = "S"
        chk_2.Name = "chk_2"

        dgvGC_SHIMA.Columns.Add(chk_1)
        dgvGC_SHIMA.Columns("chk_1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGC_SHIMA.Columns("chk_1").Width = 20
        dgvGC_SHIMA.Columns.Add("LETRA_1", "LETRA_1")
        dgvGC_SHIMA.Columns("LETRA_1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvGC_SHIMA.Columns("LETRA_1").Width = 32
        dgvGC_SHIMA.Columns.Add("C1_1", "C1_1")
        dgvGC_SHIMA.Columns("C1_1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGC_SHIMA.Columns("C1_1").Width = 45
        dgvGC_SHIMA.Columns.Add("C2_1", "C2_1")
        dgvGC_SHIMA.Columns("C2_1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGC_SHIMA.Columns("C2_1").Width = 45
        dgvGC_SHIMA.Columns.Add("DESC_1", "DESC_1")
        dgvGC_SHIMA.Columns("DESC_1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGC_SHIMA.Columns("DESC_1").Width = 161
        dgvGC_SHIMA.Columns.Add(chk_2)
        dgvGC_SHIMA.Columns("chk_2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGC_SHIMA.Columns("chk_2").Width = 20
        dgvGC_SHIMA.Columns.Add("LETRA_2", "LETRA_2")
        dgvGC_SHIMA.Columns("LETRA_2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvGC_SHIMA.Columns("LETRA_2").Width = 32
        dgvGC_SHIMA.Columns.Add("C1_2", "C1_2")
        dgvGC_SHIMA.Columns("C1_2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGC_SHIMA.Columns("C1_2").Width = 45
        dgvGC_SHIMA.Columns.Add("C2_2", "C2_2")
        dgvGC_SHIMA.Columns("C2_2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGC_SHIMA.Columns("C2_2").Width = 45
        dgvGC_SHIMA.Columns.Add("DESC_2", "DESC_2")
        dgvGC_SHIMA.Columns("DESC_2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGC_SHIMA.Columns("DESC_2").Width = 161

        dgvGC_SHIMA.ColumnHeadersVisible = False
        dgvGC_SHIMA.RowHeadersVisible = False
        dgvGC_SHIMA.DefaultCellStyle.Font = New Font("Tahoma", 9)
        dgvGC_SHIMA.RowTemplate.Height = 20

        dgvGC_SHIMA.Top = lblTitGraduacionCuerpos.Top + lblTitGraduacionCuerpos.Height
        dgvGC_SHIMA.Left = 0
        dgvGC_SHIMA.Width = 609
        dgvGC_SHIMA.Height = 403

        For i As Integer = 0 To 19
            row = {False, "M", "0", "0", "*************", False, "M", "0", "0", "*************"}
            dgvGC_SHIMA.Rows.Add(row)
        Next

    End Sub
    Private Sub CrearArraysDeGraduaciondeMangasSHIMA()
        Dim row As String()

        dgvGM_SHIMA.Rows.Clear()
        dgvGM_SHIMA.Columns.Clear()

        Dim chk As New DataGridViewCheckBoxColumn()
        chk.HeaderText = "S"
        chk.Name = "chk"

        dgvGM_SHIMA.Columns.Add(chk)
        dgvGM_SHIMA.Columns("chk").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGM_SHIMA.Columns("chk").Width = 20
        dgvGM_SHIMA.Columns.Add("LETRA", "LETRA")
        dgvGM_SHIMA.Columns("LETRA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvGM_SHIMA.Columns("LETRA").Width = 32
        dgvGM_SHIMA.Columns.Add("C1", "C1")
        dgvGM_SHIMA.Columns("C1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGM_SHIMA.Columns("C1").Width = 45
        dgvGM_SHIMA.Columns.Add("C2", "C2")
        dgvGM_SHIMA.Columns("C2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGM_SHIMA.Columns("C2").Width = 45
        dgvGM_SHIMA.Columns.Add("DESC", "DESC")
        dgvGM_SHIMA.Columns("DESC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGM_SHIMA.Columns("DESC").Width = 165

        dgvGM_SHIMA.ColumnHeadersVisible = False
        dgvGM_SHIMA.RowHeadersVisible = False
        dgvGM_SHIMA.DefaultCellStyle.Font = New Font("Tahoma", 9)
        dgvGM_SHIMA.RowTemplate.Height = 20

        dgvGM_SHIMA.Top = lblTitGraduacionCuerpos.Top + lblTitGraduacionCuerpos.Height
        dgvGM_SHIMA.Left = 609
        dgvGM_SHIMA.Width = 310
        dgvGM_SHIMA.Height = 403

        For i As Integer = 0 To 19
            row = {False, "M", "0", "0", "*************"}
            dgvGM_SHIMA.Rows.Add(row)
        Next

    End Sub

    Private Sub CrearArraysDeTirajedeCuerposSHIMA()
        Dim row As String()

        dgvTC_SHIMA.Rows.Clear()
        dgvTC_SHIMA.Columns.Clear()


        dgvTC_SHIMA.Columns.Add("DESC_1", "DESC_1")
        dgvTC_SHIMA.Columns("DESC_1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTC_SHIMA.Columns("DESC_1").Width = 154
        dgvTC_SHIMA.Columns.Add("LETRA_1", "LETRA_1")
        dgvTC_SHIMA.Columns("LETRA_1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvTC_SHIMA.Columns("LETRA_1").Width = 29
        dgvTC_SHIMA.Columns.Add("C1_1", "C1_1")
        dgvTC_SHIMA.Columns("C1_1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTC_SHIMA.Columns("C1_1").Width = 30
        dgvTC_SHIMA.Columns.Add("C2_1", "C2_1")
        dgvTC_SHIMA.Columns("C2_1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTC_SHIMA.Columns("C2_1").Width = 30
        dgvTC_SHIMA.Columns.Add("C3_1", "C3_1")
        dgvTC_SHIMA.Columns("C3_1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTC_SHIMA.Columns("C3_1").Width = 30
        dgvTC_SHIMA.Columns.Add("C4_1", "C4_1")
        dgvTC_SHIMA.Columns("C4_1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTC_SHIMA.Columns("C4_1").Width = 30
        dgvTC_SHIMA.Columns.Add("DESC_2", "DESC_2")
        dgvTC_SHIMA.Columns("DESC_2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTC_SHIMA.Columns("DESC_2").Width = 155
        dgvTC_SHIMA.Columns.Add("LETRA_2", "LETRA_2")
        dgvTC_SHIMA.Columns("LETRA_2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvTC_SHIMA.Columns("LETRA_2").Width = 30
        dgvTC_SHIMA.Columns.Add("C1_2", "C1_2")
        dgvTC_SHIMA.Columns("C1_2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTC_SHIMA.Columns("C1_2").Width = 30
        dgvTC_SHIMA.Columns.Add("C2_2", "C2_2")
        dgvTC_SHIMA.Columns("C2_2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTC_SHIMA.Columns("C2_2").Width = 30
        dgvTC_SHIMA.Columns.Add("C3_2", "C3_2")
        dgvTC_SHIMA.Columns("C3_2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTC_SHIMA.Columns("C3_2").Width = 30
        dgvTC_SHIMA.Columns.Add("C4_2", "C4_2")
        dgvTC_SHIMA.Columns("C4_2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTC_SHIMA.Columns("C4_2").Width = 29

        dgvTC_SHIMA.ColumnHeadersVisible = False
        dgvTC_SHIMA.RowHeadersVisible = False
        dgvTC_SHIMA.DefaultCellStyle.Font = New Font("Tahoma", 8)
        dgvTC_SHIMA.RowTemplate.Height = 20

        dgvTC_SHIMA.Top = lblTitTC1_Desc.Top + lblTitTC1_Desc.Height
        dgvTC_SHIMA.Left = 0
        dgvTC_SHIMA.Width = 610
        dgvTC_SHIMA.Height = 204

        For i As Integer = 0 To 9
            row = {"*************", "T", "0", "0", "0", "0", "*************", "T", "0", "0", "0", "0"}
            dgvTC_SHIMA.Rows.Add(row)
        Next

    End Sub
    Private Sub CrearArraysDeTirajedeMangasSHIMA()
        Dim row As String()

        dgvTM_SHIMA.Rows.Clear()
        dgvTM_SHIMA.Columns.Clear()

        dgvTM_SHIMA.Columns.Add("DESC", "DESC")
        dgvTM_SHIMA.Columns("DESC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTM_SHIMA.Columns("DESC").Width = 158
        dgvTM_SHIMA.Columns.Add("LETRA", "LETRA")
        dgvTM_SHIMA.Columns("LETRA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvTM_SHIMA.Columns("LETRA").Width = 30
        dgvTM_SHIMA.Columns.Add("C1", "C1")
        dgvTM_SHIMA.Columns("C1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTM_SHIMA.Columns("C1").Width = 30
        dgvTM_SHIMA.Columns.Add("C2", "C2")
        dgvTM_SHIMA.Columns("C2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTM_SHIMA.Columns("C2").Width = 30
        dgvTM_SHIMA.Columns.Add("C3", "C3")
        dgvTM_SHIMA.Columns("C3").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTM_SHIMA.Columns("C3").Width = 30
        dgvTM_SHIMA.Columns.Add("C4", "C4")
        dgvTM_SHIMA.Columns("C4").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTM_SHIMA.Columns("C4").Width = 28

        dgvTM_SHIMA.ColumnHeadersVisible = False
        dgvTM_SHIMA.RowHeadersVisible = False
        dgvTM_SHIMA.DefaultCellStyle.Font = New Font("Tahoma", 8)
        dgvTM_SHIMA.RowTemplate.Height = 20

        dgvTM_SHIMA.Top = lblTitTC1_Desc.Top + lblTitTC1_Desc.Height
        dgvTM_SHIMA.Left = 610
        dgvTM_SHIMA.Width = 309
        dgvTM_SHIMA.Height = 204

        For i As Integer = 0 To 9
            row = {"*************", "T", "0", "0", "0", "0"}
            dgvTM_SHIMA.Rows.Add(row)
        Next

    End Sub

    Private Sub AcomodarTitulosyCuadrosSTOLL()
        'los paneles de los picos
        lblTitulo.Text = "PLANILLA DE MEDIDAS Y MUESTRAS MAQUINA STOLL"
        'que se vean los picos
        lblPicos.Visible = True
        lblPicosCuerpo.Visible = True
        lblPicosManga.Visible = True
        dgvPicos.Visible = True
        'que se oculten las mallas variables
        lblMallaVariable.Visible = False
        lblMallaVariableMalla.Visible = False
        lblMallaVariableD.Visible = False
        lblMallaVariableT.Visible = False
        lblMallaVariableDesc.Visible = False
        dgvMallaVariable.Visible = False
        'tamaño del dgv de correcciones
        dgvCorrecciones.Height = 221

        lblTitTirajeCuerpos.Width = 610
        lblTitTirajeMangas.Left = 610
        lblTitTirajeMangas.Width = 309
        lblTitTC1_Desc.Visible = False
        lblTitTC1_Letra.Visible = False
        lblTitTC1_Cuadro1.Visible = False
        lblTitTC1_Cuadro2.Visible = False
        lblTitTC1_Cuadro3.Visible = False
        lblTitTC1_Cuadro4.Visible = False
        lblTitTC2_Desc.Visible = False
        lblTitTC2_Letra.Visible = False
        lblTitTC2_Cuadro1.Visible = False
        lblTitTC2_Cuadro2.Visible = False
        lblTitTC2_Cuadro3.Visible = False
        lblTitTC2_Cuadro4.Visible = False
        lblTitTM1_Desc.Visible = False
        lblTitTM1_Letra.Visible = False
        lblTitTM1_Cuadro1.Visible = False
        lblTitTM1_Cuadro2.Visible = False
        lblTitTM1_Cuadro3.Visible = False
        lblTitTM1_Cuadro4.Visible = False

        dgvGC_STOLL.Visible = True
        dgvGM_STOLL.Visible = True
        dgvTC_STOLL.Visible = True
        dgvTM_STOLL.Visible = True

        dgvGC_SHIMA.Visible = False
        dgvGM_SHIMA.Visible = False
        dgvTC_SHIMA.Visible = False
        dgvTM_SHIMA.Visible = False

    End Sub

    Private Sub AcomodarTitulosyCuadrosSHIMA()
        lblTitulo.Text = "PLANILLA DE MEDIDAS Y MUESTRAS MAQUINA SHIMA"
        'que no se vean los picos
        lblPicos.Visible = False
        lblPicosCuerpo.Visible = False
        lblPicosManga.Visible = False
        dgvPicos.Visible = False
        'que se vean las mallas variables
        lblMallaVariable.Visible = True
        lblMallaVariableMalla.Visible = True
        lblMallaVariableD.Visible = True
        lblMallaVariableT.Visible = True
        lblMallaVariableDesc.Visible = True
        dgvMallaVariable.Visible = True
        'tamaño del dgv de correcciones
        dgvCorrecciones.Height = 95

        lblTitTirajeCuerpos.Left = 0
        lblTitTirajeCuerpos.Width = 610
        lblTitTirajeMangas.Left = 610
        lblTitTirajeMangas.Width = 309
        lblTitTC1_Desc.Visible = True
        lblTitTC1_Letra.Visible = True
        lblTitTC1_Cuadro1.Visible = True
        lblTitTC1_Cuadro2.Visible = True
        lblTitTC1_Cuadro3.Visible = True
        lblTitTC1_Cuadro4.Visible = True
        lblTitTC2_Desc.Visible = True
        lblTitTC2_Letra.Visible = True
        lblTitTC2_Cuadro1.Visible = True
        lblTitTC2_Cuadro2.Visible = True
        lblTitTC2_Cuadro3.Visible = True
        lblTitTC2_Cuadro4.Visible = True
        lblTitTM1_Desc.Visible = True
        lblTitTM1_Letra.Visible = True
        lblTitTM1_Cuadro1.Visible = True
        lblTitTM1_Cuadro2.Visible = True
        lblTitTM1_Cuadro3.Visible = True
        lblTitTM1_Cuadro4.Visible = True
        lblTitTC1_Desc.Left = 0
        lblTitTC1_Desc.Width = 155
        lblTitTC1_Letra.Left = 155
        lblTitTC1_Letra.Width = 30
        lblTitTC1_Cuadro1.Left = 185
        lblTitTC1_Cuadro1.Width = 30
        lblTitTC1_Cuadro2.Left = 215
        lblTitTC1_Cuadro2.Width = 30
        lblTitTC1_Cuadro3.Left = 245
        lblTitTC1_Cuadro3.Width = 30
        lblTitTC1_Cuadro4.Left = 275
        lblTitTC1_Cuadro4.Width = 30
        lblTitTC2_Desc.Left = 305
        lblTitTC2_Desc.Width = 155
        lblTitTC2_Letra.Left = 460
        lblTitTC2_Letra.Width = 30
        lblTitTC2_Cuadro1.Left = 490
        lblTitTC2_Cuadro1.Width = 30
        lblTitTC2_Cuadro2.Left = 520
        lblTitTC2_Cuadro2.Width = 30
        lblTitTC2_Cuadro3.Left = 550
        lblTitTC2_Cuadro3.Width = 30
        lblTitTC2_Cuadro4.Left = 580
        lblTitTC2_Cuadro4.Width = 30
        lblTitTM1_Desc.Left = 610
        lblTitTM1_Desc.Width = 159
        lblTitTM1_Letra.Left = 769
        lblTitTM1_Letra.Width = 30
        lblTitTM1_Cuadro1.Left = 799
        lblTitTM1_Cuadro1.Width = 30
        lblTitTM1_Cuadro2.Left = 829
        lblTitTM1_Cuadro2.Width = 30
        lblTitTM1_Cuadro3.Left = 859
        lblTitTM1_Cuadro3.Width = 30
        lblTitTM1_Cuadro4.Left = 889
        lblTitTM1_Cuadro4.Width = 30



        dgvGC_STOLL.Visible = False
        dgvGM_STOLL.Visible = False
        dgvTC_STOLL.Visible = False
        dgvTM_STOLL.Visible = False

        dgvGC_SHIMA.Visible = True
        dgvGM_SHIMA.Visible = True
        dgvTC_SHIMA.Visible = True
        dgvTM_SHIMA.Visible = True

    End Sub

    Private Sub AcomodarTituloyDgvPesosyTiempos()
        lblTitPesoyTiempo.Left = 0
        lblTitPesoyTiempo.Top = dgvTC_SHIMA.Top + dgvTC_SHIMA.Height
        lblTitPesoyTiempo.Width = 920

        dgvTiempoyPeso.Top = lblTitPesoyTiempo.Top + lblTitPesoyTiempo.Height
        dgvTiempoyPeso.Left = 0
        dgvTiempoyPeso.Width = 920
        dgvTiempoyPeso.Height = 70

        lblTitPesoyTiempo.Visible = True
        dgvTiempoyPeso.Visible = True

        CargarTiemposyPesosdelaPlanilla()

    End Sub

    Private Sub cmbCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoria.SelectedIndexChanged
        If Strings.InStr(cmbCategoria.Text, "PRENDA COMPLETA", CompareMethod.Text) > 0 Then
            lblRutaImagen.Enabled = True
            txtRutaImagen.Enabled = True
            btnAbrirRutaImagen.Enabled = True
            Panel2.Visible = True
            txtRutaImagen.Text = ResguardoRutaImagen
            If txtRutaImagen.Text <> "" Then
                CargarFoto(txtRutaImagen.Text)
            End If
        Else
            txtRutaImagen.Text = ""
            lblRutaImagen.Enabled = False
            txtRutaImagen.Enabled = False
            btnAbrirRutaImagen.Enabled = False
            Panel2.Visible = False
        End If

        If Strings.InStr(cmbCategoria.Text, "STOLL", CompareMethod.Text) > 0 Then
            If TipoPlanilla <> "STOLL" Then
                TipoPlanilla = "STOLL"
                'ante de acomodar subo el jpanel asi se ve todo bien
                Panel1.VerticalScroll.Value = 0
                AcomodarTitulosyCuadrosSTOLL()
                CargarPicos()
                PasarDatosdeSHIMAaSTOLL()
            End If
        Else
            If TipoPlanilla <> "SHIMA" Then
                TipoPlanilla = "SHIMA"
                'ante de acomodar subo el jpanel asi se ve todo bien
                Panel1.VerticalScroll.Value = 0
                AcomodarTitulosyCuadrosSHIMA()
                CargarMallaVariable()
                PasarDatosdeSTOLLaSHIMA()
            End If
        End If

        txtDiseño.Select()
    End Sub

    Private Sub PasarDatosdeSHIMAaSTOLL()
        Dim i As Integer
        For i = 0 To 19
            If dgvGC_SHIMA.Rows(i).Cells("DESC_1").Value.ToString <> "*************" Then
                dgvGC_STOLL.Rows(i).Cells("chk_1").Value = dgvGC_SHIMA.Rows(i).Cells("chk_1").Value
                dgvGC_STOLL.Rows(i).Cells("LETRA_1").Value = dgvGC_SHIMA.Rows(i).Cells("LETRA_1").Value
                dgvGC_STOLL.Rows(i).Cells("C1_1").Value = dgvGC_SHIMA.Rows(i).Cells("C1_1").Value
                dgvGC_STOLL.Rows(i).Cells("C2_1").Value = dgvGC_SHIMA.Rows(i).Cells("C2_1").Value
                dgvGC_STOLL.Rows(i).Cells("DESC_1").Value = dgvGC_SHIMA.Rows(i).Cells("DESC_1").Value
            End If
            If dgvGC_SHIMA.Rows(i).Cells("DESC_2").Value.ToString <> "*************" Then
                dgvGC_STOLL.Rows(i).Cells("chk_2").Value = dgvGC_SHIMA.Rows(i).Cells("chk_2").Value
                dgvGC_STOLL.Rows(i).Cells("LETRA_2").Value = dgvGC_SHIMA.Rows(i).Cells("LETRA_2").Value
                dgvGC_STOLL.Rows(i).Cells("C1_2").Value = dgvGC_SHIMA.Rows(i).Cells("C1_2").Value
                dgvGC_STOLL.Rows(i).Cells("C2_2").Value = dgvGC_SHIMA.Rows(i).Cells("C2_2").Value
                dgvGC_STOLL.Rows(i).Cells("DESC_2").Value = dgvGC_SHIMA.Rows(i).Cells("DESC_2").Value
            End If

            If dgvGM_SHIMA.Rows(i).Cells("DESC").Value.ToString <> "*************" Then
                dgvGM_STOLL.Rows(i).Cells("chk").Value = dgvGM_SHIMA.Rows(i).Cells("chk").Value
                dgvGM_STOLL.Rows(i).Cells("LETRA").Value = dgvGM_SHIMA.Rows(i).Cells("LETRA").Value
                dgvGM_STOLL.Rows(i).Cells("C1").Value = dgvGM_SHIMA.Rows(i).Cells("C1").Value
                dgvGM_STOLL.Rows(i).Cells("C2").Value = dgvGM_SHIMA.Rows(i).Cells("C2").Value
                dgvGM_STOLL.Rows(i).Cells("DESC").Value = dgvGM_SHIMA.Rows(i).Cells("DESC").Value
            End If

        Next
        For i = 0 To 9
            If dgvTC_SHIMA.Rows(i).Cells("DESC_1").Value.ToString <> "*************" Then
                dgvTC_STOLL.Rows(i).Cells("LETRA_1").Value = dgvTC_SHIMA.Rows(i).Cells("LETRA_1").Value
                dgvTC_STOLL.Rows(i).Cells("C1_1").Value = dgvTC_SHIMA.Rows(i).Cells("C1_1").Value
                dgvTC_STOLL.Rows(i).Cells("C2_1").Value = dgvTC_SHIMA.Rows(i).Cells("C2_1").Value
                dgvTC_STOLL.Rows(i).Cells("C3_1").Value = dgvTC_SHIMA.Rows(i).Cells("C3_1").Value
                dgvTC_STOLL.Rows(i).Cells("C4_1").Value = dgvTC_SHIMA.Rows(i).Cells("C4_1").Value
                dgvTC_STOLL.Rows(i).Cells("DESC_1").Value = dgvTC_SHIMA.Rows(i).Cells("DESC_1").Value
            End If
            If dgvTC_SHIMA.Rows(i).Cells("DESC_2").Value.ToString <> "*************" Then
                dgvTC_STOLL.Rows(i).Cells("LETRA_2").Value = dgvTC_SHIMA.Rows(i).Cells("LETRA_2").Value
                dgvTC_STOLL.Rows(i).Cells("C1_2").Value = dgvTC_SHIMA.Rows(i).Cells("C1_2").Value
                dgvTC_STOLL.Rows(i).Cells("C2_2").Value = dgvTC_SHIMA.Rows(i).Cells("C2_2").Value
                dgvTC_STOLL.Rows(i).Cells("C3_2").Value = dgvTC_SHIMA.Rows(i).Cells("C3_2").Value
                dgvTC_STOLL.Rows(i).Cells("C4_2").Value = dgvTC_SHIMA.Rows(i).Cells("C4_2").Value
                dgvTC_STOLL.Rows(i).Cells("DESC_2").Value = dgvTC_SHIMA.Rows(i).Cells("DESC_2").Value
            End If

            If dgvTM_SHIMA.Rows(i).Cells("DESC").Value.ToString <> "*************" Then
                dgvTM_STOLL.Rows(i).Cells("LETRA").Value = dgvTM_SHIMA.Rows(i).Cells("LETRA").Value
                dgvTM_STOLL.Rows(i).Cells("C1").Value = dgvTM_SHIMA.Rows(i).Cells("C1").Value
                dgvTM_STOLL.Rows(i).Cells("C2").Value = dgvTM_SHIMA.Rows(i).Cells("C2").Value
                dgvTM_STOLL.Rows(i).Cells("C3").Value = dgvTM_SHIMA.Rows(i).Cells("C3").Value
                dgvTM_STOLL.Rows(i).Cells("C4").Value = dgvTM_SHIMA.Rows(i).Cells("C4").Value
                dgvTM_STOLL.Rows(i).Cells("DESC").Value = dgvTM_SHIMA.Rows(i).Cells("DESC").Value
            End If
        Next
    End Sub
    Private Sub PasarDatosdeSTOLLaSHIMA()
        Dim i As Integer
        For i = 0 To 19
            If dgvGC_STOLL.Rows(i).Cells("DESC_1").Value.ToString <> "*************" Then
                dgvGC_SHIMA.Rows(i).Cells("chk_1").Value = dgvGC_STOLL.Rows(i).Cells("chk_1").Value
                dgvGC_SHIMA.Rows(i).Cells("LETRA_1").Value = dgvGC_STOLL.Rows(i).Cells("LETRA_1").Value
                dgvGC_SHIMA.Rows(i).Cells("C1_1").Value = dgvGC_STOLL.Rows(i).Cells("C1_1").Value
                dgvGC_SHIMA.Rows(i).Cells("C2_1").Value = dgvGC_STOLL.Rows(i).Cells("C2_1").Value
                dgvGC_SHIMA.Rows(i).Cells("DESC_1").Value = dgvGC_STOLL.Rows(i).Cells("DESC_1").Value
            End If
            If dgvGC_STOLL.Rows(i).Cells("DESC_2").Value.ToString <> "*************" Then
                dgvGC_SHIMA.Rows(i).Cells("chk_2").Value = dgvGC_STOLL.Rows(i).Cells("chk_2").Value
                dgvGC_SHIMA.Rows(i).Cells("LETRA_2").Value = dgvGC_STOLL.Rows(i).Cells("LETRA_2").Value
                dgvGC_SHIMA.Rows(i).Cells("C1_2").Value = dgvGC_STOLL.Rows(i).Cells("C1_2").Value
                dgvGC_SHIMA.Rows(i).Cells("C2_2").Value = dgvGC_STOLL.Rows(i).Cells("C2_2").Value
                dgvGC_SHIMA.Rows(i).Cells("DESC_2").Value = dgvGC_STOLL.Rows(i).Cells("DESC_2").Value
            End If

            If dgvGM_STOLL.Rows(i).Cells("DESC").Value.ToString <> "*************" Then
                dgvGM_SHIMA.Rows(i).Cells("chk").Value = dgvGM_STOLL.Rows(i).Cells("chk").Value
                dgvGM_SHIMA.Rows(i).Cells("LETRA").Value = dgvGM_STOLL.Rows(i).Cells("LETRA").Value
                dgvGM_SHIMA.Rows(i).Cells("C1").Value = dgvGM_STOLL.Rows(i).Cells("C1").Value
                dgvGM_SHIMA.Rows(i).Cells("C2").Value = dgvGM_STOLL.Rows(i).Cells("C2").Value
                dgvGM_SHIMA.Rows(i).Cells("DESC").Value = dgvGM_STOLL.Rows(i).Cells("DESC").Value
            End If
        Next
        For i = 0 To 9
            If dgvTC_STOLL.Rows(i).Cells("DESC_1").Value.ToString <> "*************" Then
                dgvTC_SHIMA.Rows(i).Cells("LETRA_1").Value = dgvTC_STOLL.Rows(i).Cells("LETRA_1").Value
                dgvTC_SHIMA.Rows(i).Cells("C1_1").Value = dgvTC_STOLL.Rows(i).Cells("C1_1").Value
                dgvTC_SHIMA.Rows(i).Cells("C2_1").Value = dgvTC_STOLL.Rows(i).Cells("C2_1").Value
                dgvTC_SHIMA.Rows(i).Cells("C3_1").Value = dgvTC_STOLL.Rows(i).Cells("C3_1").Value
                dgvTC_SHIMA.Rows(i).Cells("C4_1").Value = dgvTC_STOLL.Rows(i).Cells("C4_1").Value
                dgvTC_SHIMA.Rows(i).Cells("DESC_1").Value = dgvTC_STOLL.Rows(i).Cells("DESC_1").Value
            End If
            If dgvTC_STOLL.Rows(i).Cells("DESC_2").Value.ToString <> "*************" Then
                dgvTC_SHIMA.Rows(i).Cells("LETRA_2").Value = dgvTC_STOLL.Rows(i).Cells("LETRA_2").Value
                dgvTC_SHIMA.Rows(i).Cells("C1_2").Value = dgvTC_STOLL.Rows(i).Cells("C1_2").Value
                dgvTC_SHIMA.Rows(i).Cells("C2_2").Value = dgvTC_STOLL.Rows(i).Cells("C2_2").Value
                dgvTC_SHIMA.Rows(i).Cells("C3_2").Value = dgvTC_STOLL.Rows(i).Cells("C3_2").Value
                dgvTC_SHIMA.Rows(i).Cells("C4_2").Value = dgvTC_STOLL.Rows(i).Cells("C4_2").Value
                dgvTC_SHIMA.Rows(i).Cells("DESC_2").Value = dgvTC_STOLL.Rows(i).Cells("DESC_2").Value
            End If

            If dgvTM_STOLL.Rows(i).Cells("DESC").Value.ToString <> "*************" Then
                dgvTM_SHIMA.Rows(i).Cells("LETRA").Value = dgvTM_STOLL.Rows(i).Cells("LETRA").Value
                dgvTM_SHIMA.Rows(i).Cells("C1").Value = dgvTM_STOLL.Rows(i).Cells("C1").Value
                dgvTM_SHIMA.Rows(i).Cells("C2").Value = dgvTM_STOLL.Rows(i).Cells("C2").Value
                dgvTM_SHIMA.Rows(i).Cells("C3").Value = dgvTM_STOLL.Rows(i).Cells("C3").Value
                dgvTM_SHIMA.Rows(i).Cells("C4").Value = dgvTM_STOLL.Rows(i).Cells("C4").Value
                dgvTM_SHIMA.Rows(i).Cells("DESC").Value = dgvTM_STOLL.Rows(i).Cells("DESC").Value
            End If
        Next
    End Sub

    Private Sub cmdCopiarPlanilla_Click(sender As Object, e As EventArgs) Handles cmdCopiarPlanilla.Click
        CopiarSinAccesorios()
        txtDiseño.Select()
    End Sub

    Private Sub cmdCopiarPlanAcces_Click(sender As Object, e As EventArgs) Handles cmdCopiarPlanAcces.Click
        CopiarConAccesorios()
        txtDiseño.Select()
    End Sub

    Private Sub cmdVerHistorial_Click(sender As Object, e As EventArgs) Handles cmdVerHistorial.Click
        Dim formArtProdHistorial As New frmArtProdHistorial()
        formArtProdHistorial.ID = ID
        formArtProdHistorial.CargarListado()
        formArtProdHistorial.ShowDialog(Me)
    End Sub

    '##########################################################################################################################################################
    '##########################################################################################################################################################
    '##########################################################################################################################################################
    '##########################################################################################################################################################

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
        If ID <= 0 Then
            'SOLO SE PUEDEN IMPRIMIR LAS PLANILLAS QUE YA ESTAN DADAS DE ALTA
            Exit Sub
        End If

        Dim formOpcionesdeImpresion As New frmOpcionesdeImpresion()
        formOpcionesdeImpresion.EsAccesorio = False
        If Strings.InStr(cmbCategoria.Text, "PRENDA COMPLETA", CompareMethod.Text) > 0 Then
            formOpcionesdeImpresion.EsPrendaCompleta = True
        Else
            formOpcionesdeImpresion.EsPrendaCompleta = False
        End If

        formOpcionesdeImpresion.Cargar()
        formOpcionesdeImpresion.ShowDialog(Me)
        If formOpcionesdeImpresion.ImprimirPesosyTiempos Then ImprimirPesosyTiempos = True Else ImprimirPesosyTiempos = False
        If formOpcionesdeImpresion.DejarVaciasMedidasIniciales Then DejarVaciasMedidasIniciales = True Else DejarVaciasMedidasIniciales = False
        If formOpcionesdeImpresion.ImprimirPlanoDeMedidas Then ImprimirPlanoDeMedidas = True Else ImprimirPlanoDeMedidas = False

        If formOpcionesdeImpresion.SeConfirmoOK Then
            formOpcionesdeImpresion.Close()
            'If MsgBox("Desea imprimir los Pesos y Tiempos del artículo?", vbYesNo, "Textilana S. A.") = vbYes Then ImprimirPesosyTiempos = True Else ImprimirPesosyTiempos = False

            pdoImpPlanilla.DefaultPageSettings.Landscape = False
            pdoImpPlanilla.DefaultPageSettings.Margins.Left = 20
            pdoImpPlanilla.DefaultPageSettings.Margins.Right = 20
            pdoImpPlanilla.DefaultPageSettings.Margins.Top = 20
            pdoImpPlanilla.DefaultPageSettings.Margins.Bottom = 20
            pdoImpPlanilla.OriginAtMargins = True ' takes margins into account 

            'Dim dlgPrintPreview As New EnhancedPrintPreviewDialog
            'dlgPrintPreview.ClientSize = New System.Drawing.Size(600, 600)
            'dlgPrintPreview.Document = pdoImpPlanilla ' Previews print
            'dlgPrintPreview.ShowDialog()

            pdoImpPlanilla.Print()

            If ImprimirPlanoDeMedidas Then

                pdoImprimirPlanoMedidas.DefaultPageSettings.Landscape = False
                pdoImprimirPlanoMedidas.DefaultPageSettings.Margins.Left = 20
                pdoImprimirPlanoMedidas.DefaultPageSettings.Margins.Right = 20
                pdoImprimirPlanoMedidas.DefaultPageSettings.Margins.Top = 20
                pdoImprimirPlanoMedidas.DefaultPageSettings.Margins.Bottom = 20
                pdoImprimirPlanoMedidas.OriginAtMargins = True ' takes margins into account 

                'Dim dlgPrintPreview As New EnhancedPrintPreviewDialog
                'dlgPrintPreview.ClientSize = New System.Drawing.Size(600, 600)
                'dlgPrintPreview.Document = pdoImprimirPlanoMedidas ' Previews print
                'dlgPrintPreview.ShowDialog()

                pdoImprimirPlanoMedidas.Print()

            End If

        Else
            formOpcionesdeImpresion.Close()
        End If

    End Sub

    Private Sub pdoImpPlanilla_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdoImpPlanilla.PrintPage
        On Error Resume Next

        Dim LapizMarcador As New Pen(Brushes.Black)

        Dim FuenteLineas As Font = New Drawing.Font("Arial", 10, FontStyle.Regular)
        Dim FuenteLineasN As Font = New Drawing.Font("Arial", 10, FontStyle.Bold)
        Dim FuenteLineas9 As Font = New Drawing.Font("Arial", 9, FontStyle.Regular)
        Dim FuenteLineas9N As Font = New Drawing.Font("Arial", 9, FontStyle.Bold)
        Dim FuenteLineas8 As Font = New Drawing.Font("Arial", 8, FontStyle.Regular)
        Dim FuenteLineas8N As Font = New Drawing.Font("Arial", 7, FontStyle.Bold)
        Dim FuenteLineas7 As Font = New Drawing.Font("Arial", 7, FontStyle.Regular)
        Dim FuenteLineas7N As Font = New Drawing.Font("Arial", 7, FontStyle.Bold)

        Dim LineasdeCorreciones, nTopPicos, nTopMallas, nTopCorr, nRowPos, UltimaFiladeCorreccionConDato As Integer
        Dim nTop As Int16 = e.MarginBounds.Top
        Dim AltoRenglon As Integer = 16

        If TipoPlanilla = "STOLL" Then

        Else

        End If

        ' Draw Header
        e.Graphics.DrawString(lblTitulo.Text, FuenteLineas, Brushes.Black, 100, nTop)
        e.Graphics.DrawString(cmbCategoria.Text, FuenteLineas, Brushes.Black, 520, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 750, AltoRenglon)
        nTop = nTop + AltoRenglon

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(20, nTop, 80, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 80, AltoRenglon)
        e.Graphics.DrawString("FECHA", FuenteLineas, Brushes.Black, 35, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(100, nTop, 70, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 70, AltoRenglon)
        e.Graphics.DrawString("DISEÑO", FuenteLineas, Brushes.Black, 105, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(170, nTop, 150, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 170, nTop, 150, AltoRenglon)
        e.Graphics.DrawString("COLOR", FuenteLineas, Brushes.Black, 210, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(320, nTop, 70, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 320, nTop, 70, AltoRenglon)
        e.Graphics.DrawString("PARTIDA", FuenteLineas, Brushes.Black, 325, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(390, nTop, 50, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 390, nTop, 50, AltoRenglon)
        e.Graphics.DrawString("V DEL", FuenteLineas, Brushes.Black, 395, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(440, nTop, 50, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 440, nTop, 50, AltoRenglon)
        e.Graphics.DrawString("V ESP", FuenteLineas, Brushes.Black, 445, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(490, nTop, 50, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 490, nTop, 50, AltoRenglon)
        e.Graphics.DrawString("V MAN", FuenteLineas, Brushes.Black, 492, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(540, nTop, 60, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 540, nTop, 60, AltoRenglon)
        e.Graphics.DrawString("V CAP", FuenteLineas, Brushes.Black, 545, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(600, nTop, 70, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 600, nTop, 70, AltoRenglon)
        e.Graphics.DrawString("OP", FuenteLineas, Brushes.Black, 615, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(670, nTop, 100, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 670, nTop, 100, AltoRenglon)
        e.Graphics.DrawString("ARTÍCULO", FuenteLineas, Brushes.Black, 680, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 80, AltoRenglon)
        e.Graphics.DrawString(Format(dtpFecha.Value, "dd/MM/yyyy"), FuenteLineas, Brushes.Black, 25, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 70, AltoRenglon)
        e.Graphics.DrawString(txtDiseño.Text, FuenteLineas, Brushes.Black, 105, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 170, nTop, 150, AltoRenglon)
        e.Graphics.DrawString(txtColor.Text, FuenteLineas, Brushes.Black, 173, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 320, nTop, 70, AltoRenglon)
        e.Graphics.DrawString(txtPartida.Text, FuenteLineas, Brushes.Black, 325, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 390, nTop, 50, AltoRenglon)
        e.Graphics.DrawString(txtVentDel.Text, FuenteLineas, Brushes.Black, 395, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 440, nTop, 50, AltoRenglon)
        e.Graphics.DrawString(txtVentEsp.Text, FuenteLineas, Brushes.Black, 445, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 490, nTop, 50, AltoRenglon)
        e.Graphics.DrawString(txtVentMan.Text, FuenteLineas, Brushes.Black, 495, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 540, nTop, 60, AltoRenglon)
        e.Graphics.DrawString(txtVentCap.Text, FuenteLineas, Brushes.Black, 545, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 600, nTop, 70, AltoRenglon)
        e.Graphics.DrawString(txtOp.Text, FuenteLineas, Brushes.Black, 600, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 670, nTop, 100, AltoRenglon)
        e.Graphics.DrawString(txtArticulo.Text, FuenteLineasN, Brushes.Black, 680, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 80, 144)
        e.Graphics.DrawString("Talle " + txtTitTalleXXL.Text, FuenteLineas9, Brushes.Black, 25, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 80, 144)
        e.Graphics.DrawString("Talle " + txtTitTalleXL.Text, FuenteLineas9, Brushes.Black, 105, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 180, nTop, 80, 144)
        e.Graphics.DrawString("Talle " + txtTitTalleL.Text, FuenteLineas9, Brushes.Black, 185, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 260, nTop, 80, 144)
        e.Graphics.DrawString("Talle " + txtTitTalleM.Text, FuenteLineas9, Brushes.Black, 265, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 340, nTop, 80, 144)
        e.Graphics.DrawString("Talle " + txtTitTalleS.Text, FuenteLineas9, Brushes.Black, 345, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 420, nTop, 80, 144)
        e.Graphics.DrawString("Talle " + txtTitTalleXS.Text, FuenteLineas9, Brushes.Black, 425, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 25, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(40, nTop, 30, AltoRenglon))
        e.Graphics.DrawString(txtTalleXXL_D.Text, FuenteLineas9N, Brushes.Black, 45, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 70, nTop)

        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 105, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(120, nTop, 30, AltoRenglon))
        e.Graphics.DrawString(txtTalleXL_D.Text, FuenteLineas9N, Brushes.Black, 125, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 150, nTop)

        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 185, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(200, nTop, 30, AltoRenglon))
        e.Graphics.DrawString(txtTalleL_D.Text, FuenteLineas9N, Brushes.Black, 205, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 230, nTop)

        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 265, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(280, nTop, 30, AltoRenglon))
        e.Graphics.DrawString(txtTalleM_D.Text, FuenteLineas9N, Brushes.Black, 285, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 310, nTop)

        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 345, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(360, nTop, 30, AltoRenglon))
        e.Graphics.DrawString(txtTalleS_D.Text, FuenteLineas9N, Brushes.Black, 365, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 390, nTop)

        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 425, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(440, nTop, 30, AltoRenglon))
        e.Graphics.DrawString(txtTalleXS_D.Text, FuenteLineas9N, Brushes.Black, 445, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 470, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 25, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(40, nTop, 30, AltoRenglon))
        e.Graphics.DrawString(txtTalleXXL_E.Text, FuenteLineas9N, Brushes.Black, 45, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 70, nTop)

        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 105, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(120, nTop, 30, AltoRenglon))
        e.Graphics.DrawString(txtTalleXL_E.Text, FuenteLineas9N, Brushes.Black, 125, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 150, nTop)

        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 185, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(200, nTop, 30, AltoRenglon))
        e.Graphics.DrawString(txtTalleL_E.Text, FuenteLineas9N, Brushes.Black, 205, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 230, nTop)

        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 265, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(280, nTop, 30, AltoRenglon))
        e.Graphics.DrawString(txtTalleM_E.Text, FuenteLineas9N, Brushes.Black, 285, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 310, nTop)

        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 345, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(360, nTop, 30, AltoRenglon))
        e.Graphics.DrawString(txtTalleS_E.Text, FuenteLineas9N, Brushes.Black, 365, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 390, nTop)

        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 425, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(440, nTop, 30, AltoRenglon))
        e.Graphics.DrawString(txtTalleXS_E.Text, FuenteLineas9N, Brushes.Black, 445, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 470, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawString(txtTalleXXLBretel_Tit.Text, FuenteLineas8, Brushes.Black, 25, nTop)
        e.Graphics.DrawString(txtTalleXXLBretel.Text, FuenteLineas9, Brushes.Black, 75, nTop)

        e.Graphics.DrawString(txtTalleXLBretel_Tit.Text, FuenteLineas8, Brushes.Black, 105, nTop)
        e.Graphics.DrawString(txtTalleXLBretel.Text, FuenteLineas9, Brushes.Black, 155, nTop)

        e.Graphics.DrawString(txtTalleLBretel_Tit.Text, FuenteLineas8, Brushes.Black, 185, nTop)
        e.Graphics.DrawString(txtTalleLBretel.Text, FuenteLineas9, Brushes.Black, 235, nTop)

        e.Graphics.DrawString(txtTalleMBretel_Tit.Text, FuenteLineas8, Brushes.Black, 265, nTop)
        e.Graphics.DrawString(txtTalleMBretel.Text, FuenteLineas9, Brushes.Black, 315, nTop)

        e.Graphics.DrawString(txtTalleSBretel_Tit.Text, FuenteLineas8, Brushes.Black, 345, nTop)
        e.Graphics.DrawString(txtTalleSBretel.Text, FuenteLineas9, Brushes.Black, 395, nTop)

        e.Graphics.DrawString(txtTalleXSBretel_Tit.Text, FuenteLineas8, Brushes.Black, 425, nTop)
        e.Graphics.DrawString(txtTalleXSBretel.Text, FuenteLineas9, Brushes.Black, 475, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawString(txtTalleXXLEsc_Tit.Text, FuenteLineas9, Brushes.Black, 25, nTop)
        e.Graphics.DrawString(txtTalleXXLEsc.Text, FuenteLineas9, Brushes.Black, 75, nTop)

        e.Graphics.DrawString(txtTalleXLEsc_Tit.Text, FuenteLineas9, Brushes.Black, 105, nTop)
        e.Graphics.DrawString(txtTalleXLEsc.Text, FuenteLineas9, Brushes.Black, 155, nTop)

        e.Graphics.DrawString(txtTalleLEsc_Tit.Text, FuenteLineas9, Brushes.Black, 185, nTop)
        e.Graphics.DrawString(txtTalleLEsc.Text, FuenteLineas9, Brushes.Black, 235, nTop)

        e.Graphics.DrawString(txtTalleMEsc_Tit.Text, FuenteLineas9, Brushes.Black, 265, nTop)
        e.Graphics.DrawString(txtTalleMEsc.Text, FuenteLineas9, Brushes.Black, 315, nTop)

        e.Graphics.DrawString(txtTalleSEsc_Tit.Text, FuenteLineas9, Brushes.Black, 345, nTop)
        e.Graphics.DrawString(txtTalleSEsc.Text, FuenteLineas9, Brushes.Black, 395, nTop)

        e.Graphics.DrawString(txtTalleXSEsc_Tit.Text, FuenteLineas9, Brushes.Black, 425, nTop)
        e.Graphics.DrawString(txtTalleXSEsc.Text, FuenteLineas9, Brushes.Black, 475, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawString(txtTalleXXLBolsillo_Tit.Text, FuenteLineas9, Brushes.Black, 25, nTop)
        e.Graphics.DrawString(txtTalleXXLBolsillo.Text, FuenteLineas9, Brushes.Black, 75, nTop)

        e.Graphics.DrawString(txtTalleXLBolsillo_Tit.Text, FuenteLineas9, Brushes.Black, 105, nTop)
        e.Graphics.DrawString(txtTalleXLBolsillo.Text, FuenteLineas9, Brushes.Black, 155, nTop)

        e.Graphics.DrawString(txtTalleLBolsillo_Tit.Text, FuenteLineas9, Brushes.Black, 185, nTop)
        e.Graphics.DrawString(txtTalleLBolsillo.Text, FuenteLineas9, Brushes.Black, 235, nTop)

        e.Graphics.DrawString(txtTalleMBolsillo_Tit.Text, FuenteLineas9, Brushes.Black, 265, nTop)
        e.Graphics.DrawString(txtTalleMBolsillo.Text, FuenteLineas9, Brushes.Black, 315, nTop)

        e.Graphics.DrawString(txtTalleSBolsillo_Tit.Text, FuenteLineas9, Brushes.Black, 345, nTop)
        e.Graphics.DrawString(txtTalleSBolsillo.Text, FuenteLineas9, Brushes.Black, 395, nTop)

        e.Graphics.DrawString(txtTalleXSBolsillo_Tit.Text, FuenteLineas9, Brushes.Black, 425, nTop)
        e.Graphics.DrawString(txtTalleXSBolsillo.Text, FuenteLineas9, Brushes.Black, 475, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawString(txtTalleXXLAncho_Tit.Text, FuenteLineas9, Brushes.Black, 25, nTop)
        e.Graphics.DrawString(txtTalleXXLAncho.Text, FuenteLineas9, Brushes.Black, 75, nTop)

        e.Graphics.DrawString(txtTalleXLAncho_Tit.Text, FuenteLineas9, Brushes.Black, 105, nTop)
        e.Graphics.DrawString(txtTalleXLAncho.Text, FuenteLineas9, Brushes.Black, 155, nTop)

        e.Graphics.DrawString(txtTalleLAncho_Tit.Text, FuenteLineas9, Brushes.Black, 185, nTop)
        e.Graphics.DrawString(txtTalleLAncho.Text, FuenteLineas9, Brushes.Black, 235, nTop)

        e.Graphics.DrawString(txtTalleMAncho_Tit.Text, FuenteLineas9, Brushes.Black, 265, nTop)
        e.Graphics.DrawString(txtTalleMAncho.Text, FuenteLineas9, Brushes.Black, 315, nTop)

        e.Graphics.DrawString(txtTalleSAncho_Tit.Text, FuenteLineas9, Brushes.Black, 345, nTop)
        e.Graphics.DrawString(txtTalleSAncho.Text, FuenteLineas9, Brushes.Black, 395, nTop)

        e.Graphics.DrawString(txtTalleXSAncho_Tit.Text, FuenteLineas9, Brushes.Black, 425, nTop)
        e.Graphics.DrawString(txtTalleXSAncho.Text, FuenteLineas9, Brushes.Black, 475, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawString(txtTalleXXLLargo_Tit.Text, FuenteLineas9, Brushes.Black, 25, nTop)
        e.Graphics.DrawString(txtTalleXXLLargo.Text, FuenteLineas9, Brushes.Black, 75, nTop)

        e.Graphics.DrawString(txtTalleXLLargo_Tit.Text, FuenteLineas9, Brushes.Black, 105, nTop)
        e.Graphics.DrawString(txtTalleXLLargo.Text, FuenteLineas9, Brushes.Black, 155, nTop)

        e.Graphics.DrawString(txtTalleLLargo_Tit.Text, FuenteLineas9, Brushes.Black, 185, nTop)
        e.Graphics.DrawString(txtTalleLLargo.Text, FuenteLineas9, Brushes.Black, 235, nTop)

        e.Graphics.DrawString(txtTalleMLargo_Tit.Text, FuenteLineas9, Brushes.Black, 265, nTop)
        e.Graphics.DrawString(txtTalleMLargo.Text, FuenteLineas9, Brushes.Black, 315, nTop)

        e.Graphics.DrawString(txtTalleSLargo_Tit.Text, FuenteLineas9, Brushes.Black, 345, nTop)
        e.Graphics.DrawString(txtTalleSLargo.Text, FuenteLineas9, Brushes.Black, 395, nTop)

        e.Graphics.DrawString(txtTalleXSLargo_Tit.Text, FuenteLineas9, Brushes.Black, 425, nTop)
        e.Graphics.DrawString(txtTalleXSLargo.Text, FuenteLineas9, Brushes.Black, 475, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawString(txtTalleXXL_CuerParamInicio.Text, FuenteLineasN, Brushes.Black, 25, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 50, nTop, 2, AltoRenglon)
        e.Graphics.DrawString(txtTalleXXL_CuerCantAgujas.Text, FuenteLineasN, Brushes.Black, 60, nTop)

        e.Graphics.DrawString(txtTalleXL_CuerParamInicio.Text, FuenteLineasN, Brushes.Black, 105, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 130, nTop, 2, AltoRenglon)
        e.Graphics.DrawString(txtTalleXL_CuerCantAgujas.Text, FuenteLineasN, Brushes.Black, 140, nTop)

        e.Graphics.DrawString(txtTalleL_CuerParamInicio.Text, FuenteLineasN, Brushes.Black, 185, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 210, nTop, 2, AltoRenglon)
        e.Graphics.DrawString(txtTalleL_CuerCantAgujas.Text, FuenteLineasN, Brushes.Black, 220, nTop)

        e.Graphics.DrawString(txtTalleM_CuerParamInicio.Text, FuenteLineasN, Brushes.Black, 265, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 290, nTop, 2, AltoRenglon)
        e.Graphics.DrawString(txtTalleM_CuerCantAgujas.Text, FuenteLineasN, Brushes.Black, 300, nTop)

        e.Graphics.DrawString(txtTalleS_CuerParamInicio.Text, FuenteLineasN, Brushes.Black, 345, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 370, nTop, 2, AltoRenglon)
        e.Graphics.DrawString(txtTalleS_CuerCantAgujas.Text, FuenteLineasN, Brushes.Black, 380, nTop)

        e.Graphics.DrawString(txtTalleXS_CuerParamInicio.Text, FuenteLineasN, Brushes.Black, 425, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 450, nTop, 2, AltoRenglon)
        e.Graphics.DrawString(txtTalleXS_CuerCantAgujas.Text, FuenteLineasN, Brushes.Black, 460, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 480, AltoRenglon)
        e.Graphics.DrawString("MEDIDA ELÁSTICO=", FuenteLineas9, Brushes.Black, 25, nTop)
        e.Graphics.DrawString(txtMedidaElastico.Text, FuenteLineas9, Brushes.Black, 160, nTop)
        e.Graphics.DrawString("CONDICIÓN CUERPOS=", FuenteLineas9, Brushes.Black, 250, nTop)
        e.Graphics.DrawString(txtCondicionCuerpos.Text, FuenteLineas9, Brushes.Black, 400, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 480, AltoRenglon)
        e.Graphics.DrawString("VELOCIDAD CUERPOS=", FuenteLineas9, Brushes.Black, 25, nTop)
        e.Graphics.DrawString(txtVelocidadCuerpos.Text, FuenteLineas9, Brushes.Black, 180, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 80, 48)
        e.Graphics.DrawString("MANGA", FuenteLineas9, Brushes.Black, 35, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 80, 48)
        e.Graphics.DrawString("MANGA", FuenteLineas9, Brushes.Black, 115, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 180, nTop, 80, 48)
        e.Graphics.DrawString("MANGA", FuenteLineas9, Brushes.Black, 195, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 260, nTop, 80, 48)
        e.Graphics.DrawString("MANGA", FuenteLineas9, Brushes.Black, 275, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 340, nTop, 80, 48)
        e.Graphics.DrawString("MANGA", FuenteLineas9, Brushes.Black, 355, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 420, nTop, 80, 48)
        e.Graphics.DrawString("MANGA", FuenteLineas9, Brushes.Black, 435, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(25, nTop, 45, AltoRenglon))
        e.Graphics.DrawString(txtTalleXXL_Manga.Text, FuenteLineas9N, Brushes.Black, 40, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 70, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(105, nTop, 45, AltoRenglon))
        e.Graphics.DrawString(txtTalleXL_Manga.Text, FuenteLineas9N, Brushes.Black, 120, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 150, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(185, nTop, 45, AltoRenglon))
        e.Graphics.DrawString(txtTalleL_Manga.Text, FuenteLineas9N, Brushes.Black, 200, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 230, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(265, nTop, 45, AltoRenglon))
        e.Graphics.DrawString(txtTalleM_Manga.Text, FuenteLineas9N, Brushes.Black, 280, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 310, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(345, nTop, 45, AltoRenglon))
        e.Graphics.DrawString(txtTalleS_Manga.Text, FuenteLineas9N, Brushes.Black, 360, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 390, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(425, nTop, 45, AltoRenglon))
        e.Graphics.DrawString(txtTalleXS_Manga.Text, FuenteLineas9N, Brushes.Black, 440, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 470, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawString(txtTalleXXL_MangaParamInicio.Text, FuenteLineasN, Brushes.Black, 25, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 50, nTop, 2, AltoRenglon)
        e.Graphics.DrawString(txtTalleXXL_MangaCantAgujas.Text, FuenteLineasN, Brushes.Black, 60, nTop)

        e.Graphics.DrawString(txtTalleXL_MangaParamInicio.Text, FuenteLineasN, Brushes.Black, 105, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 130, nTop, 2, AltoRenglon)
        e.Graphics.DrawString(txtTalleXL_MangaCantAgujas.Text, FuenteLineasN, Brushes.Black, 140, nTop)

        e.Graphics.DrawString(txtTalleL_MangaParamInicio.Text, FuenteLineasN, Brushes.Black, 185, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 210, nTop, 2, AltoRenglon)
        e.Graphics.DrawString(txtTalleL_MangaCantAgujas.Text, FuenteLineasN, Brushes.Black, 220, nTop)

        e.Graphics.DrawString(txtTalleM_MangaParamInicio.Text, FuenteLineasN, Brushes.Black, 265, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 290, nTop, 2, AltoRenglon)
        e.Graphics.DrawString(txtTalleM_MangaCantAgujas.Text, FuenteLineasN, Brushes.Black, 300, nTop)

        e.Graphics.DrawString(txtTalleS_MangaParamInicio.Text, FuenteLineasN, Brushes.Black, 345, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 370, nTop, 2, AltoRenglon)
        e.Graphics.DrawString(txtTalleS_MangaCantAgujas.Text, FuenteLineasN, Brushes.Black, 380, nTop)

        e.Graphics.DrawString(txtTalleXS_MangaParamInicio.Text, FuenteLineasN, Brushes.Black, 425, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 450, nTop, 2, AltoRenglon)
        e.Graphics.DrawString(txtTalleXS_MangaCantAgujas.Text, FuenteLineasN, Brushes.Black, 460, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 480, AltoRenglon)
        e.Graphics.DrawString("MEDIDA PUÑO=", FuenteLineas9, Brushes.Black, 25, nTop)
        e.Graphics.DrawString(txtMedidaPuño.Text, FuenteLineas9, Brushes.Black, 150, nTop)
        e.Graphics.DrawString("CONDICIÓN MANGAS=", FuenteLineas9, Brushes.Black, 250, nTop)
        e.Graphics.DrawString(txtCondicionMangas.Text, FuenteLineas9, Brushes.Black, 400, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 480, AltoRenglon)
        e.Graphics.DrawString("VELOCIDAD MANGAS=", FuenteLineas9, Brushes.Black, 25, nTop)
        e.Graphics.DrawString(txtVelocidadMangas.Text, FuenteLineas9, Brushes.Black, 180, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 480, AltoRenglon)
        e.Graphics.DrawString("MEDIDAS INICIALES", FuenteLineas9, Brushes.Black, 200, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 23, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 40, nTop, 30, AltoRenglon)
        If Not DejarVaciasMedidasIniciales Then e.Graphics.DrawString(txtTalleXXL_D_MedInicial.Text, FuenteLineas9, Brushes.Black, 45, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 70, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 72, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 103, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 120, nTop, 30, AltoRenglon)
        If Not DejarVaciasMedidasIniciales Then e.Graphics.DrawString(txtTalleXL_D_MedInicial.Text, FuenteLineas9, Brushes.Black, 125, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 150, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 152, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 180, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 183, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 200, nTop, 30, AltoRenglon)
        If Not DejarVaciasMedidasIniciales Then e.Graphics.DrawString(txtTalleL_D_MedInicial.Text, FuenteLineas9, Brushes.Black, 205, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 230, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 232, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 260, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 263, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 280, nTop, 30, AltoRenglon)
        If Not DejarVaciasMedidasIniciales Then e.Graphics.DrawString(txtTalleM_D_MedInicial.Text, FuenteLineas9, Brushes.Black, 285, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 310, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 312, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 340, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 343, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 360, nTop, 30, AltoRenglon)
        If Not DejarVaciasMedidasIniciales Then e.Graphics.DrawString(txtTalleS_D_MedInicial.Text, FuenteLineas9, Brushes.Black, 365, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 390, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 392, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 420, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 423, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 440, nTop, 30, AltoRenglon)
        If Not DejarVaciasMedidasIniciales Then e.Graphics.DrawString(txtTalleXS_D_MedInicial.Text, FuenteLineas9, Brushes.Black, 445, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 470, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 472, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 23, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 40, nTop, 30, AltoRenglon)
        If Not DejarVaciasMedidasIniciales Then e.Graphics.DrawString(txtTalleXXL_E_MedInicial.Text, FuenteLineas9, Brushes.Black, 45, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 70, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 72, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 103, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 120, nTop, 30, AltoRenglon)
        If Not DejarVaciasMedidasIniciales Then e.Graphics.DrawString(txtTalleXL_E_MedInicial.Text, FuenteLineas9, Brushes.Black, 125, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 150, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 152, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 180, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 183, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 200, nTop, 30, AltoRenglon)
        If Not DejarVaciasMedidasIniciales Then e.Graphics.DrawString(txtTalleL_E_MedInicial.Text, FuenteLineas9, Brushes.Black, 205, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 230, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 232, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 260, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 263, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 280, nTop, 30, AltoRenglon)
        If Not DejarVaciasMedidasIniciales Then e.Graphics.DrawString(txtTalleM_E_MedInicial.Text, FuenteLineas9, Brushes.Black, 285, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 310, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 312, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 340, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 343, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 360, nTop, 30, AltoRenglon)
        If Not DejarVaciasMedidasIniciales Then e.Graphics.DrawString(txtTalleS_E_MedInicial.Text, FuenteLineas9, Brushes.Black, 365, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 390, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 392, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 420, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 423, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 440, nTop, 30, AltoRenglon)
        If Not DejarVaciasMedidasIniciales Then e.Graphics.DrawString(txtTalleXS_E_MedInicial.Text, FuenteLineas9, Brushes.Black, 445, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 470, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 472, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("M", FuenteLineas9, Brushes.Black, 23, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 40, nTop, 30, AltoRenglon)
        If Not DejarVaciasMedidasIniciales Then e.Graphics.DrawString(txtTalleXXL_M_MedInicial.Text, FuenteLineas9, Brushes.Black, 45, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 70, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 72, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("M", FuenteLineas9, Brushes.Black, 103, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 120, nTop, 30, AltoRenglon)
        If Not DejarVaciasMedidasIniciales Then e.Graphics.DrawString(txtTalleXL_M_MedInicial.Text, FuenteLineas9, Brushes.Black, 125, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 150, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 152, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 180, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("M", FuenteLineas9, Brushes.Black, 183, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 200, nTop, 30, AltoRenglon)
        If Not DejarVaciasMedidasIniciales Then e.Graphics.DrawString(txtTalleL_M_MedInicial.Text, FuenteLineas9, Brushes.Black, 205, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 230, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 232, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 260, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("M", FuenteLineas9, Brushes.Black, 263, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 280, nTop, 30, AltoRenglon)
        If Not DejarVaciasMedidasIniciales Then e.Graphics.DrawString(txtTalleM_M_MedInicial.Text, FuenteLineas9, Brushes.Black, 285, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 310, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 312, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 340, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("M", FuenteLineas9, Brushes.Black, 343, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 360, nTop, 30, AltoRenglon)
        If Not DejarVaciasMedidasIniciales Then e.Graphics.DrawString(txtTalleS_M_MedInicial.Text, FuenteLineas9, Brushes.Black, 365, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 390, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 392, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 420, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("M", FuenteLineas9, Brushes.Black, 423, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 440, nTop, 30, AltoRenglon)
        If Not DejarVaciasMedidasIniciales Then e.Graphics.DrawString(txtTalleXS_M_MedInicial.Text, FuenteLineas9, Brushes.Black, 445, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 470, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 472, nTop)


        If TipoPlanilla = "STOLL" Then
            nTopPicos = 12 * AltoRenglon + e.MarginBounds.Top

            e.Graphics.DrawRectangle(Pens.Black, 500, nTopPicos, 90, AltoRenglon)
            e.Graphics.DrawString("PICOS", FuenteLineas9, Brushes.Black, 510, nTopPicos)
            e.Graphics.DrawRectangle(Pens.Black, 590, nTopPicos, 90, AltoRenglon)
            e.Graphics.DrawString("CUERPO", FuenteLineas9, Brushes.Black, 600, nTopPicos)
            e.Graphics.DrawRectangle(Pens.Black, 680, nTopPicos, 90, AltoRenglon)
            e.Graphics.DrawString("MANGA", FuenteLineas9, Brushes.Black, 690, nTopPicos)

            For nRowPos = 0 To 7
                nTopPicos = nTopPicos + AltoRenglon
                e.Graphics.DrawRectangle(Pens.Black, 500, nTopPicos, 90, AltoRenglon)
                e.Graphics.DrawString(dgvPicos.Rows(nRowPos).Cells("PICO").Value, FuenteLineas9, Brushes.Black, 510, nTopPicos)
                e.Graphics.DrawRectangle(Pens.Black, 590, nTopPicos, 30, AltoRenglon)
                e.Graphics.DrawString(dgvPicos.Rows(nRowPos).Cells("CUERPO_C1").Value, FuenteLineas9, Brushes.Black, 595, nTopPicos)
                e.Graphics.DrawRectangle(Pens.Black, 620, nTopPicos, 30, AltoRenglon)
                e.Graphics.DrawString(dgvPicos.Rows(nRowPos).Cells("CUERPO_C2").Value, FuenteLineas9, Brushes.Black, 625, nTopPicos)
                e.Graphics.DrawRectangle(Pens.Black, 650, nTopPicos, 30, AltoRenglon)
                e.Graphics.DrawString(dgvPicos.Rows(nRowPos).Cells("CUERPO_C3").Value, FuenteLineas9, Brushes.Black, 655, nTopPicos)
                e.Graphics.DrawRectangle(Pens.Black, 680, nTopPicos, 30, AltoRenglon)
                e.Graphics.DrawString(dgvPicos.Rows(nRowPos).Cells("MANGA_C1").Value, FuenteLineas9, Brushes.Black, 685, nTopPicos)
                e.Graphics.DrawRectangle(Pens.Black, 710, nTopPicos, 30, AltoRenglon)
                e.Graphics.DrawString(dgvPicos.Rows(nRowPos).Cells("MANGA_C2").Value, FuenteLineas9, Brushes.Black, 715, nTopPicos)
                e.Graphics.DrawRectangle(Pens.Black, 740, nTopPicos, 30, AltoRenglon)
                e.Graphics.DrawString(dgvPicos.Rows(nRowPos).Cells("MANGA_C3").Value, FuenteLineas9, Brushes.Black, 745, nTopPicos)

            Next
        Else
            nTopMallas = 7 * AltoRenglon + e.MarginBounds.Top

            e.Graphics.DrawRectangle(Pens.Black, 500, nTopMallas, 270, AltoRenglon)
            e.Graphics.DrawString("MALLA VARIABLE", FuenteLineas9, Brushes.Black, 580, nTopMallas)

            nTopMallas = nTopMallas + AltoRenglon

            e.Graphics.DrawRectangle(Pens.Black, 500, nTopMallas, 80, AltoRenglon)
            e.Graphics.DrawRectangle(Pens.Black, 580, nTopMallas, 35, AltoRenglon)
            e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 585, nTopMallas)
            e.Graphics.DrawRectangle(Pens.Black, 615, nTopMallas, 35, AltoRenglon)
            e.Graphics.DrawString("T", FuenteLineas9, Brushes.Black, 620, nTopMallas)
            e.Graphics.DrawRectangle(Pens.Black, 650, nTopMallas, 120, AltoRenglon)

            For nRowPos = 0 To 13
                nTopMallas = nTopMallas + AltoRenglon
                e.Graphics.DrawRectangle(Pens.Black, 500, nTopMallas, 80, AltoRenglon)
                e.Graphics.DrawString(dgvMallaVariable.Rows(nRowPos).Cells("MALLA").Value, FuenteLineas9, Brushes.Black, 510, nTopMallas)
                e.Graphics.DrawRectangle(Pens.Black, 580, nTopMallas, 35, AltoRenglon)
                e.Graphics.DrawString(dgvMallaVariable.Rows(nRowPos).Cells("MALLA_D").Value, FuenteLineas9, Brushes.Black, 590, nTopMallas)
                e.Graphics.DrawRectangle(Pens.Black, 615, nTopMallas, 35, AltoRenglon)
                e.Graphics.DrawString(dgvMallaVariable.Rows(nRowPos).Cells("MALLA_T").Value, FuenteLineas9, Brushes.Black, 625, nTopMallas)
                e.Graphics.DrawRectangle(Pens.Black, 650, nTopMallas, 120, AltoRenglon)
                e.Graphics.DrawString(dgvMallaVariable.Rows(nRowPos).Cells("MALLA_DESC").Value, FuenteLineas9, Brushes.Black, 655, nTopMallas)
            Next

        End If

        If TipoPlanilla = "STOLL" Then
            nTopCorr = 3 * AltoRenglon + e.MarginBounds.Top

            e.Graphics.DrawRectangle(Pens.Black, 500, nTopCorr, 90, AltoRenglon)
            e.Graphics.DrawString("FECHA", FuenteLineas9, Brushes.Black, 510, nTopCorr)
            e.Graphics.DrawRectangle(Pens.Black, 590, nTopCorr, 180, AltoRenglon)
            e.Graphics.DrawString("CORRECCION", FuenteLineas9, Brushes.Black, 600, nTopCorr)

            e.Graphics.DrawRectangle(Pens.Black, 500, nTopCorr, 90, 9 * AltoRenglon)
            e.Graphics.DrawRectangle(Pens.Black, 590, nTopCorr, 180, 9 * AltoRenglon)

            'busco la ultima fila que tiene datos y desde ahi imprimo las ultimas 10
            UltimaFiladeCorreccionConDato = 0
            For nRowPos = 0 To dgvCorrecciones.RowCount - 1
                If dgvCorrecciones.Rows(nRowPos).Cells("FECHA").Value.ToString <> "" Or dgvCorrecciones.Rows(nRowPos).Cells("CORRECCION").Value.ToString <> "" Then
                    UltimaFiladeCorreccionConDato = UltimaFiladeCorreccionConDato + 1
                End If
                If dgvCorrecciones.Rows(nRowPos).Cells("FECHA").Value.ToString = "" And dgvCorrecciones.Rows(nRowPos).Cells("CORRECCION").Value.ToString = "" Then
                    Exit For
                End If
            Next

            If UltimaFiladeCorreccionConDato > 7 Then
                For nRowPos = UltimaFiladeCorreccionConDato - 8 To UltimaFiladeCorreccionConDato
                    nTopCorr = nTopCorr + AltoRenglon
                    e.Graphics.DrawString(dgvCorrecciones.Rows(nRowPos).Cells("FECHA").Value, FuenteLineas9, Brushes.Black, 510, nTopCorr)
                    e.Graphics.DrawString(dgvCorrecciones.Rows(nRowPos).Cells("CORRECCION").Value, FuenteLineas9, Brushes.Black, 595, nTopCorr)
                Next
            Else
                For nRowPos = 0 To 8
                    nTopCorr = nTopCorr + AltoRenglon
                    e.Graphics.DrawString(dgvCorrecciones.Rows(nRowPos).Cells("FECHA").Value, FuenteLineas9, Brushes.Black, 510, nTopCorr)
                    e.Graphics.DrawString(dgvCorrecciones.Rows(nRowPos).Cells("CORRECCION").Value, FuenteLineas9, Brushes.Black, 595, nTopCorr)
                Next
            End If
        Else

            nTopCorr = 3 * AltoRenglon + e.MarginBounds.Top

            e.Graphics.DrawRectangle(Pens.Black, 500, nTopCorr, 90, AltoRenglon)
            e.Graphics.DrawString("FECHA", FuenteLineas9, Brushes.Black, 510, nTopCorr)
            e.Graphics.DrawRectangle(Pens.Black, 590, nTopCorr, 180, AltoRenglon)
            e.Graphics.DrawString("CORRECCION", FuenteLineas9, Brushes.Black, 600, nTopCorr)

            e.Graphics.DrawRectangle(Pens.Black, 500, nTopCorr, 90, 4 * AltoRenglon)
            e.Graphics.DrawRectangle(Pens.Black, 590, nTopCorr, 180, 4 * AltoRenglon)

            'busco la ultima fila que tiene datos y desde ahi imprimo las ultimas 10
            UltimaFiladeCorreccionConDato = 0
            For nRowPos = 0 To dgvCorrecciones.RowCount - 1
                If dgvCorrecciones.Rows(nRowPos).Cells("FECHA").Value.ToString <> "" Or dgvCorrecciones.Rows(nRowPos).Cells("CORRECCION").Value.ToString <> "" Then
                    UltimaFiladeCorreccionConDato = UltimaFiladeCorreccionConDato + 1
                End If
                If dgvCorrecciones.Rows(nRowPos).Cells("FECHA").Value.ToString = "" And dgvCorrecciones.Rows(nRowPos).Cells("CORRECCION").Value.ToString = "" Then
                    Exit For
                End If
            Next

            If UltimaFiladeCorreccionConDato > 2 Then
                For nRowPos = UltimaFiladeCorreccionConDato - 3 To UltimaFiladeCorreccionConDato
                    nTopCorr = nTopCorr + AltoRenglon
                    e.Graphics.DrawString(dgvCorrecciones.Rows(nRowPos).Cells("FECHA").Value, FuenteLineas9, Brushes.Black, 510, nTopCorr)
                    e.Graphics.DrawString(dgvCorrecciones.Rows(nRowPos).Cells("CORRECCION").Value, FuenteLineas9, Brushes.Black, 595, nTopCorr)
                Next
            Else
                For nRowPos = 0 To 3
                    nTopCorr = nTopCorr + AltoRenglon
                    e.Graphics.DrawString(dgvCorrecciones.Rows(nRowPos).Cells("FECHA").Value, FuenteLineas9, Brushes.Black, 510, nTopCorr)
                    e.Graphics.DrawString(dgvCorrecciones.Rows(nRowPos).Cells("CORRECCION").Value, FuenteLineas9, Brushes.Black, 595, nTopCorr)
                Next
            End If

        End If

        nTop = nTop + AltoRenglon

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(20, nTop, 480, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 480, AltoRenglon)
        e.Graphics.DrawString("GRADUACIÓN CUERPOS", FuenteLineas9, Brushes.Black, 200, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(500, nTop, 270, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 500, nTop, 270, AltoRenglon)
        e.Graphics.DrawString("GRADUACIÓN MANGAS", FuenteLineas9, Brushes.Black, 550, nTop)

        LapizMarcador.Width = 2.0F

        If TipoPlanilla = "STOLL" Then
            For nRowPos = 0 To 19
                nTop = nTop + AltoRenglon
                If dgvGC_STOLL.Rows(nRowPos).Cells("chk_1").Value = True Then
                    e.Graphics.DrawArc(LapizMarcador, New Rectangle(20, nTop, 30, AltoRenglon), 0, 360)
                End If
                e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 30, AltoRenglon)
                e.Graphics.DrawString(dgvGC_STOLL.Rows(nRowPos).Cells("LETRA_1").Value, FuenteLineas8N, Brushes.Black, 25, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 50, nTop, 30, AltoRenglon)
                e.Graphics.DrawString(dgvGC_STOLL.Rows(nRowPos).Cells("C1_1").Value, FuenteLineas8N, Brushes.Black, 51, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 80, nTop, 30, AltoRenglon)
                e.Graphics.DrawString(dgvGC_STOLL.Rows(nRowPos).Cells("C2_1").Value, FuenteLineas8N, Brushes.Black, 81, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 110, nTop, 150, AltoRenglon)
                e.Graphics.DrawString(dgvGC_STOLL.Rows(nRowPos).Cells("DESC_1").Value, FuenteLineas7N, Brushes.Black, 111, nTop + 1)
                If dgvGC_STOLL.Rows(nRowPos).Cells("chk_2").Value = True Then
                    e.Graphics.DrawArc(LapizMarcador, New Rectangle(260, nTop, 30, AltoRenglon), 0, 360)
                End If
                e.Graphics.DrawRectangle(Pens.Black, 260, nTop, 30, AltoRenglon)
                e.Graphics.DrawString(dgvGC_STOLL.Rows(nRowPos).Cells("LETRA_2").Value, FuenteLineas8N, Brushes.Black, 265, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 290, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvGC_STOLL.Rows(nRowPos).Cells("C1_2").Value, FuenteLineas8N, Brushes.Black, 295, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 315, nTop, 30, AltoRenglon)
                e.Graphics.DrawString(dgvGC_STOLL.Rows(nRowPos).Cells("C2_2").Value, FuenteLineas8N, Brushes.Black, 317, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 345, nTop, 155, AltoRenglon)
                e.Graphics.DrawString(dgvGC_STOLL.Rows(nRowPos).Cells("DESC_2").Value, FuenteLineas7N, Brushes.Black, 347, nTop + 1)

                If dgvGM_STOLL.Rows(nRowPos).Cells("chk").Value = True Then
                    e.Graphics.DrawArc(LapizMarcador, New Rectangle(500, nTop, 30, AltoRenglon), 0, 360)
                End If
                e.Graphics.DrawRectangle(Pens.Black, 500, nTop, 30, AltoRenglon)
                e.Graphics.DrawString(dgvGM_STOLL.Rows(nRowPos).Cells("LETRA").Value, FuenteLineas8N, Brushes.Black, 505, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 530, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvGM_STOLL.Rows(nRowPos).Cells("C1").Value, FuenteLineas8N, Brushes.Black, 535, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 555, nTop, 30, AltoRenglon)
                e.Graphics.DrawString(dgvGM_STOLL.Rows(nRowPos).Cells("C2").Value, FuenteLineas8N, Brushes.Black, 557, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 585, nTop, 185, AltoRenglon)
                e.Graphics.DrawString(dgvGM_STOLL.Rows(nRowPos).Cells("DESC").Value, FuenteLineas7N, Brushes.Black, 587, nTop + 1)
            Next

        Else

            For nRowPos = 0 To 19
                nTop = nTop + AltoRenglon
                If dgvGC_SHIMA.Rows(nRowPos).Cells("chk_1").Value = True Then
                    e.Graphics.DrawArc(LapizMarcador, New Rectangle(20, nTop, 30, AltoRenglon), 0, 360)
                End If
                e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 30, AltoRenglon)
                e.Graphics.DrawString(dgvGC_SHIMA.Rows(nRowPos).Cells("LETRA_1").Value, FuenteLineas8N, Brushes.Black, 25, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 50, nTop, 30, AltoRenglon)
                e.Graphics.DrawString(dgvGC_SHIMA.Rows(nRowPos).Cells("C1_1").Value, FuenteLineas8N, Brushes.Black, 51, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 80, nTop, 30, AltoRenglon)
                e.Graphics.DrawString(dgvGC_SHIMA.Rows(nRowPos).Cells("C2_1").Value, FuenteLineas8N, Brushes.Black, 81, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 110, nTop, 150, AltoRenglon)
                e.Graphics.DrawString(dgvGC_SHIMA.Rows(nRowPos).Cells("DESC_1").Value, FuenteLineas8N, Brushes.Black, 112, nTop)
                If dgvGC_SHIMA.Rows(nRowPos).Cells("chk_2").Value = True Then
                    e.Graphics.DrawArc(LapizMarcador, New Rectangle(260, nTop, 30, AltoRenglon), 0, 360)
                End If
                e.Graphics.DrawRectangle(Pens.Black, 260, nTop, 30, AltoRenglon)
                e.Graphics.DrawString(dgvGC_SHIMA.Rows(nRowPos).Cells("LETRA_2").Value, FuenteLineas8N, Brushes.Black, 265, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 290, nTop, 30, AltoRenglon)
                e.Graphics.DrawString(dgvGC_SHIMA.Rows(nRowPos).Cells("C1_2").Value, FuenteLineas8N, Brushes.Black, 291, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 320, nTop, 30, AltoRenglon)
                e.Graphics.DrawString(dgvGC_SHIMA.Rows(nRowPos).Cells("C2_2").Value, FuenteLineas8N, Brushes.Black, 321, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 350, nTop, 150, AltoRenglon)
                e.Graphics.DrawString(dgvGC_SHIMA.Rows(nRowPos).Cells("DESC_2").Value, FuenteLineas8N, Brushes.Black, 351, nTop)

                If dgvGM_SHIMA.Rows(nRowPos).Cells("chk").Value = True Then
                    e.Graphics.DrawArc(LapizMarcador, New Rectangle(500, nTop, 30, AltoRenglon), 0, 360)
                End If
                e.Graphics.DrawRectangle(Pens.Black, 500, nTop, 30, AltoRenglon)
                e.Graphics.DrawString(dgvGM_SHIMA.Rows(nRowPos).Cells("LETRA").Value, FuenteLineas8N, Brushes.Black, 505, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 530, nTop, 30, AltoRenglon)
                e.Graphics.DrawString(dgvGM_SHIMA.Rows(nRowPos).Cells("C1").Value, FuenteLineas8N, Brushes.Black, 531, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 560, nTop, 30, AltoRenglon)
                e.Graphics.DrawString(dgvGM_SHIMA.Rows(nRowPos).Cells("C2").Value, FuenteLineas8N, Brushes.Black, 561, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 590, nTop, 180, AltoRenglon)
                e.Graphics.DrawString(dgvGM_SHIMA.Rows(nRowPos).Cells("DESC").Value, FuenteLineas8N, Brushes.Black, 591, nTop)
            Next

        End If

        nTop = nTop + AltoRenglon

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(20, nTop, 490, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 490, AltoRenglon)
        e.Graphics.DrawString("TIRAJE CUERPOS", FuenteLineas9, Brushes.Black, 200, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(510, nTop, 260, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 510, nTop, 260, AltoRenglon)
        e.Graphics.DrawString("TIRAJE MANGAS", FuenteLineas9, Brushes.Black, 570, nTop)

        If TipoPlanilla = "STOLL" Then
            For nRowPos = 0 To 9
                nTop = nTop + AltoRenglon
                e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 35, AltoRenglon)
                e.Graphics.DrawString(dgvTC_STOLL.Rows(nRowPos).Cells("LETRA_1").Value, FuenteLineas8N, Brushes.Black, 21, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 55, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvTC_STOLL.Rows(nRowPos).Cells("C1_1").Value, FuenteLineas8N, Brushes.Black, 57, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 80, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvTC_STOLL.Rows(nRowPos).Cells("C2_1").Value, FuenteLineas8N, Brushes.Black, 82, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 105, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvTC_STOLL.Rows(nRowPos).Cells("C3_1").Value, FuenteLineas8N, Brushes.Black, 107, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 130, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvTC_STOLL.Rows(nRowPos).Cells("C4_1").Value, FuenteLineas8N, Brushes.Black, 132, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 155, nTop, 110, AltoRenglon)
                e.Graphics.DrawString(dgvTC_STOLL.Rows(nRowPos).Cells("DESC_1").Value, FuenteLineas7N, Brushes.Black, 156, nTop + 1)
                e.Graphics.DrawRectangle(Pens.Black, 265, nTop, 35, AltoRenglon)
                e.Graphics.DrawString(dgvTC_STOLL.Rows(nRowPos).Cells("LETRA_2").Value, FuenteLineas8N, Brushes.Black, 266, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 300, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvTC_STOLL.Rows(nRowPos).Cells("C1_2").Value, FuenteLineas8N, Brushes.Black, 302, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 325, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvTC_STOLL.Rows(nRowPos).Cells("C2_2").Value, FuenteLineas8N, Brushes.Black, 327, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 350, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvTC_STOLL.Rows(nRowPos).Cells("C3_2").Value, FuenteLineas8N, Brushes.Black, 352, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 375, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvTC_STOLL.Rows(nRowPos).Cells("C4_2").Value, FuenteLineas8N, Brushes.Black, 377, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 400, nTop, 110, AltoRenglon)
                e.Graphics.DrawString(dgvTC_STOLL.Rows(nRowPos).Cells("DESC_2").Value, FuenteLineas7N, Brushes.Black, 402, nTop + 1)

                e.Graphics.DrawRectangle(Pens.Black, 510, nTop, 35, AltoRenglon)
                e.Graphics.DrawString(dgvTM_STOLL.Rows(nRowPos).Cells("LETRA").Value, FuenteLineas8N, Brushes.Black, 511, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 545, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvTM_STOLL.Rows(nRowPos).Cells("C1").Value, FuenteLineas8N, Brushes.Black, 550, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 570, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvTM_STOLL.Rows(nRowPos).Cells("C2").Value, FuenteLineas8N, Brushes.Black, 572, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 595, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvTM_STOLL.Rows(nRowPos).Cells("C3").Value, FuenteLineas8N, Brushes.Black, 597, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 620, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvTM_STOLL.Rows(nRowPos).Cells("C4").Value, FuenteLineas8N, Brushes.Black, 622, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 645, nTop, 125, AltoRenglon)
                e.Graphics.DrawString(dgvTM_STOLL.Rows(nRowPos).Cells("DESC").Value, FuenteLineas7N, Brushes.Black, 647, nTop + 1)
            Next

        Else

            For nRowPos = 0 To 9
                nTop = nTop + AltoRenglon
                e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 120, AltoRenglon)
                e.Graphics.DrawString(dgvTC_SHIMA.Rows(nRowPos).Cells("DESC_1").Value, FuenteLineas8N, Brushes.Black, 25, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 140, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvTC_SHIMA.Rows(nRowPos).Cells("LETRA_1").Value, FuenteLineas8N, Brushes.Black, 145, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 165, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvTC_SHIMA.Rows(nRowPos).Cells("C1_1").Value, FuenteLineas8N, Brushes.Black, 170, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 190, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvTC_SHIMA.Rows(nRowPos).Cells("C2_1").Value, FuenteLineas8N, Brushes.Black, 195, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 215, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvTC_SHIMA.Rows(nRowPos).Cells("C3_1").Value, FuenteLineas8N, Brushes.Black, 220, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 240, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvTC_SHIMA.Rows(nRowPos).Cells("C4_1").Value, FuenteLineas8N, Brushes.Black, 245, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 265, nTop, 120, AltoRenglon)
                e.Graphics.DrawString(dgvTC_SHIMA.Rows(nRowPos).Cells("DESC_2").Value, FuenteLineas8N, Brushes.Black, 270, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 385, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvTC_SHIMA.Rows(nRowPos).Cells("LETRA_2").Value, FuenteLineas8N, Brushes.Black, 390, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 410, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvTC_SHIMA.Rows(nRowPos).Cells("C1_2").Value, FuenteLineas8N, Brushes.Black, 415, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 435, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvTC_SHIMA.Rows(nRowPos).Cells("C2_2").Value, FuenteLineas8N, Brushes.Black, 440, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 460, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvTC_SHIMA.Rows(nRowPos).Cells("C3_2").Value, FuenteLineas8N, Brushes.Black, 465, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 485, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvTC_SHIMA.Rows(nRowPos).Cells("C4_2").Value, FuenteLineas8N, Brushes.Black, 490, nTop)

                e.Graphics.DrawRectangle(Pens.Black, 510, nTop, 130, AltoRenglon)
                e.Graphics.DrawString(dgvTM_SHIMA.Rows(nRowPos).Cells("DESC").Value, FuenteLineas8N, Brushes.Black, 515, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 640, nTop, 30, AltoRenglon)
                e.Graphics.DrawString(dgvTM_SHIMA.Rows(nRowPos).Cells("LETRA").Value, FuenteLineas8N, Brushes.Black, 645, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 670, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvTM_SHIMA.Rows(nRowPos).Cells("C1").Value, FuenteLineas8N, Brushes.Black, 675, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 695, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvTM_SHIMA.Rows(nRowPos).Cells("C2").Value, FuenteLineas8N, Brushes.Black, 700, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 720, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvTM_SHIMA.Rows(nRowPos).Cells("C3").Value, FuenteLineas8N, Brushes.Black, 725, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 745, nTop, 25, AltoRenglon)
                e.Graphics.DrawString(dgvTM_SHIMA.Rows(nRowPos).Cells("C4").Value, FuenteLineas8N, Brushes.Black, 750, nTop)
            Next

        End If

        'el lugar para las observaciones
        nTop = nTop + AltoRenglon
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 80, AltoRenglon)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(100, nTop, 590, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 590, AltoRenglon)
        e.Graphics.DrawString("OBSERVACIONES M.C.C.", FuenteLineas, Brushes.Black, 300, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 690, nTop, 80, AltoRenglon)

        nTop = nTop + AltoRenglon
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 750, AltoRenglon)
        nTop = nTop + AltoRenglon
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 750, AltoRenglon)
        nTop = nTop + AltoRenglon
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 750, AltoRenglon)
        nTop = nTop + AltoRenglon
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 750, AltoRenglon)
        nTop = nTop + AltoRenglon
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 750, AltoRenglon)
        nTop = nTop + AltoRenglon
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 750, AltoRenglon)
        nTop = nTop + AltoRenglon
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 750, AltoRenglon)
        nTop = nTop + AltoRenglon
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 750, AltoRenglon)

        'AHORA LOS PESOS Y TIEMPOS
        If ImprimirPesosyTiempos Then
            nTop = nTop + AltoRenglon
            e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(20, nTop, 750, AltoRenglon))
            e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 750, AltoRenglon)
            e.Graphics.DrawString("PESOS Y TIEMPOS", FuenteLineas, Brushes.Black, 330, nTop)
            nTop = nTop + AltoRenglon
            e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(20, nTop, 750, AltoRenglon))
            e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 100, AltoRenglon)
            e.Graphics.DrawString("DATO", FuenteLineas, Brushes.Black, 30, nTop)
            e.Graphics.DrawRectangle(Pens.Black, 120, nTop, 80, AltoRenglon)
            e.Graphics.DrawString("XXS", FuenteLineas, Brushes.Black, 130, nTop)
            e.Graphics.DrawRectangle(Pens.Black, 200, nTop, 80, AltoRenglon)
            e.Graphics.DrawString("XS", FuenteLineas, Brushes.Black, 210, nTop)
            e.Graphics.DrawRectangle(Pens.Black, 280, nTop, 80, AltoRenglon)
            e.Graphics.DrawString("S", FuenteLineas, Brushes.Black, 290, nTop)
            e.Graphics.DrawRectangle(Pens.Black, 360, nTop, 80, AltoRenglon)
            e.Graphics.DrawString("M", FuenteLineas, Brushes.Black, 370, nTop)
            e.Graphics.DrawRectangle(Pens.Black, 440, nTop, 80, AltoRenglon)
            e.Graphics.DrawString("L", FuenteLineas, Brushes.Black, 450, nTop)
            e.Graphics.DrawRectangle(Pens.Black, 520, nTop, 80, AltoRenglon)
            e.Graphics.DrawString("XL", FuenteLineas, Brushes.Black, 530, nTop)
            e.Graphics.DrawRectangle(Pens.Black, 600, nTop, 80, AltoRenglon)
            e.Graphics.DrawString("XXL", FuenteLineas, Brushes.Black, 610, nTop)
            e.Graphics.DrawRectangle(Pens.Black, 680, nTop, 90, AltoRenglon)
            e.Graphics.DrawString("U", FuenteLineas, Brushes.Black, 690, nTop)

            For nRowPos = 0 To 1
                nTop = nTop + AltoRenglon
                e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 100, AltoRenglon)
                e.Graphics.DrawString(dgvTiempoyPeso.Rows(nRowPos).Cells("DATO").Value, FuenteLineas8N, Brushes.Black, 30, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 120, nTop, 80, AltoRenglon)
                e.Graphics.DrawString(dgvTiempoyPeso.Rows(nRowPos).Cells("XXS").Value, FuenteLineas8N, Brushes.Black, 130, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 200, nTop, 80, AltoRenglon)
                e.Graphics.DrawString(dgvTiempoyPeso.Rows(nRowPos).Cells("XS").Value, FuenteLineas8N, Brushes.Black, 210, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 280, nTop, 80, AltoRenglon)
                e.Graphics.DrawString(dgvTiempoyPeso.Rows(nRowPos).Cells("S").Value, FuenteLineas8N, Brushes.Black, 290, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 360, nTop, 80, AltoRenglon)
                e.Graphics.DrawString(dgvTiempoyPeso.Rows(nRowPos).Cells("M").Value, FuenteLineas8N, Brushes.Black, 370, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 440, nTop, 80, AltoRenglon)
                e.Graphics.DrawString(dgvTiempoyPeso.Rows(nRowPos).Cells("L").Value, FuenteLineas8N, Brushes.Black, 450, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 520, nTop, 80, AltoRenglon)
                e.Graphics.DrawString(dgvTiempoyPeso.Rows(nRowPos).Cells("XL").Value, FuenteLineas8N, Brushes.Black, 530, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 600, nTop, 80, AltoRenglon)
                e.Graphics.DrawString(dgvTiempoyPeso.Rows(nRowPos).Cells("XXL").Value, FuenteLineas8N, Brushes.Black, 610, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 680, nTop, 90, AltoRenglon)
                e.Graphics.DrawString(dgvTiempoyPeso.Rows(nRowPos).Cells("U").Value, FuenteLineas8N, Brushes.Black, 690, nTop)
            Next
        End If

        'LUEGO EL PIE DE PAGINA
        DrawFooter(e)

    End Sub

    Public Sub DrawFooter(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim FuenteLineas8 As Font = New Drawing.Font("Arial", 8, FontStyle.Regular)

        e.Graphics.DrawLine(Pens.Black, 20, e.MarginBounds.Height - 17, 790, e.MarginBounds.Height - 17)

        ' Right Align - User Name
        e.Graphics.DrawString("Impreso Por: " + DescripcionLegajo(LegajoLogueado), FuenteLineas8, Brushes.Black, 790 - e.Graphics.MeasureString("Impreso Por: " + DescripcionLegajo(LegajoLogueado), FuenteLineas8, e.MarginBounds.Width).Width, e.MarginBounds.Height - 15)

        ' Center - Page No. Info
        e.Graphics.DrawString(Format(Now, "dd/MM/yyyy HH:mm:ss"), FuenteLineas8, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(Format(Now, "dd/MM/yyyy HH:mm:ss"), FuenteLineas8, e.MarginBounds.Width).Width) / 2, e.MarginBounds.Height - 15)

        e.Graphics.DrawLine(Pens.Black, 20, e.MarginBounds.Height, 790, e.MarginBounds.Height)

    End Sub

    Private Sub cmdSombrear_GC_Click(sender As Object, e As EventArgs)
        If TipoPlanilla = "STOLL" Then
            If dgvGC_STOLL.CurrentRow.Index > 0 Then
                If dgvGC_STOLL.Rows(dgvGC_STOLL.CurrentRow.Index).Cells(0).Style.BackColor = Color.DarkGray Then
                    dgvGC_STOLL.Rows(dgvGC_STOLL.CurrentRow.Index).Cells(0).Style.BackColor = Color.White
                Else
                    dgvGC_STOLL.Rows(dgvGC_STOLL.CurrentRow.Index).Cells(0).Style.BackColor = Color.DarkGray
                End If

            End If
        Else

        End If

    End Sub

    Dim ColAccesorios As New Collection

    Private Sub cmdNuevoAccesorio_Click(sender As Object, e As EventArgs) Handles cmdNuevoAccesorio.Click
        Dim formArtProdAccABM As New frmArtProdAccABM(LegajoLogueado, ID, TipoPlanilla)
        formArtProdAccABM.Alta = True
        formArtProdAccABM.Cargar()
        formArtProdAccABM.ShowDialog()
        CargarListadoAccesorios()

    End Sub

    Private Sub cmdEliminarAccesorio_Click(sender As Object, e As EventArgs) Handles cmdEliminarAccesorio.Click
        Dim Command As New SqlCommand
        Dim sStr As String

        If lsbListaAccesorios.Text.ToString = "" Then
            MensajeAtencion("Debe seleccionar un acesorio primero")
            Exit Sub
        End If

        If MsgBox("¿Está seguro de eliminar el accesorio seleccionado?", vbYesNo, "Textilana S. A.") = vbNo Then Exit Sub

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "UPDATE PrendasArtProdPlanillasAccesorios SET Eliminado = 1 WHERE id = " + ColAccesorios.Item(lsbListaAccesorios.Text.ToString)
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        RegistroEnHistorial("A", ColAccesorios.Item(lsbListaAccesorios.Text.ToString), "BajaAccesorio", LegajoLogueado)

        MensajeAtencion("Accesorio eliminado correctamente.")

        CargarListadoAccesorios()

    End Sub

    Private Sub lsbListaAccesorios_DoubleClick(sender As Object, e As EventArgs) Handles lsbListaAccesorios.DoubleClick

        If lsbListaAccesorios.Text.ToString = "" Then Exit Sub

        Dim formArtProdAccABM As New frmArtProdAccABM(LegajoLogueado, ID, TipoPlanilla)
        formArtProdAccABM.Alta = False
        formArtProdAccABM.ID = ColAccesorios.Item(lsbListaAccesorios.Text.ToString)
        formArtProdAccABM.Cargar()
        formArtProdAccABM.ShowDialog()
        CargarListadoAccesorios()
    End Sub
    Private Sub CargarListadoAccesorios()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        lsbListaAccesorios.Items.Clear()
        ColAccesorios.Clear()
        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT * FROM PrendasArtProdPlanillasAccesorios WHERE IdPlanilla =" + ID.ToString
        sStr = sStr & " AND isnull(Eliminado,0)=0 "
        sStr = sStr & " ORDER BY Id"

        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                lsbListaAccesorios.Items.Add(Trim(Reader.Item("DescAccesorio").ToString) + " - " + Trim(Reader.Item("Color")) + "")
                ColAccesorios.Add(Trim(Reader.Item("Id").ToString), Trim(Reader.Item("DescAccesorio").ToString) + " - " + Trim(Reader.Item("Color")) + "")
            Loop
            Reader.NextResult()
        Loop

    End Sub

    Dim DataGridBotonDerecho As New DataGridView
    Dim BotonDerechoFila As Integer = -1
    Dim BotonDerechoColumna As Integer = -1

    Private Sub dgvGC_SHIMA_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvGC_SHIMA.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            DataGridBotonDerecho = dgvGC_SHIMA
            BotonDerechoFila = dgvGC_SHIMA.HitTest(e.Location.X, e.Location.Y).RowIndex
            BotonDerechoColumna = dgvGC_SHIMA.HitTest(e.Location.X, e.Location.Y).ColumnIndex
        End If
    End Sub
    Private Sub dgvGC_STOLL_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvGC_STOLL.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            DataGridBotonDerecho = dgvGC_STOLL
            BotonDerechoFila = dgvGC_STOLL.HitTest(e.Location.X, e.Location.Y).RowIndex
            BotonDerechoColumna = dgvGC_STOLL.HitTest(e.Location.X, e.Location.Y).ColumnIndex
        End If
    End Sub
    Private Sub dgvGM_SHIMA_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvGM_SHIMA.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            DataGridBotonDerecho = dgvGM_SHIMA
            BotonDerechoFila = dgvGM_SHIMA.HitTest(e.Location.X, e.Location.Y).RowIndex
            BotonDerechoColumna = dgvGM_SHIMA.HitTest(e.Location.X, e.Location.Y).ColumnIndex
        End If
    End Sub
    Private Sub dgvGM_STOLL_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvGM_STOLL.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            DataGridBotonDerecho = dgvGM_STOLL
            BotonDerechoFila = dgvGM_STOLL.HitTest(e.Location.X, e.Location.Y).RowIndex
            BotonDerechoColumna = dgvGM_STOLL.HitTest(e.Location.X, e.Location.Y).ColumnIndex
        End If
    End Sub
    Private Sub dgvTC_SHIMA_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvTC_SHIMA.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            DataGridBotonDerecho = dgvTC_SHIMA
            BotonDerechoFila = dgvTC_SHIMA.HitTest(e.Location.X, e.Location.Y).RowIndex
            BotonDerechoColumna = dgvTC_SHIMA.HitTest(e.Location.X, e.Location.Y).ColumnIndex
        End If
    End Sub

    Private Sub dgvTC_STOLL_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvTC_STOLL.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            DataGridBotonDerecho = dgvTC_STOLL
            BotonDerechoFila = dgvTC_STOLL.HitTest(e.Location.X, e.Location.Y).RowIndex
            BotonDerechoColumna = dgvTC_STOLL.HitTest(e.Location.X, e.Location.Y).ColumnIndex
        End If
    End Sub
    Private Sub dgvTM_SHIMA_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvTM_SHIMA.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            DataGridBotonDerecho = dgvTM_SHIMA
            BotonDerechoFila = dgvTM_SHIMA.HitTest(e.Location.X, e.Location.Y).RowIndex
            BotonDerechoColumna = dgvTM_SHIMA.HitTest(e.Location.X, e.Location.Y).ColumnIndex
        End If
    End Sub
    Private Sub dgvTM_STOLL_MouseDown(sender As Object, e As MouseEventArgs) Handles dgvTM_STOLL.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            DataGridBotonDerecho = dgvTM_STOLL
            BotonDerechoFila = dgvTM_STOLL.HitTest(e.Location.X, e.Location.Y).RowIndex
            BotonDerechoColumna = dgvTM_STOLL.HitTest(e.Location.X, e.Location.Y).ColumnIndex
        End If
    End Sub

    Private Sub InsertarFilaMenuItem_Click(sender As Object, e As EventArgs) Handles InsertarFilaMenuItem.Click
        If BotonDerechoFila >= 0 Then
            If DataGridBotonDerecho.Name = "dgvGC_STOLL" Or DataGridBotonDerecho.Name = "dgvGC_SHIMA" Then
                If BotonDerechoColumna < 5 Then
                    If DataGridBotonDerecho.Rows(BotonDerechoFila).Cells("DESC_1").Value.ToString = "*************" Then
                        Exit Sub
                    End If
                Else
                    If DataGridBotonDerecho.Rows(BotonDerechoFila).Cells("DESC_2").Value.ToString = "*************" Then
                        Exit Sub
                    End If
                End If
            ElseIf DataGridBotonDerecho.Name = "dgvGM_STOLL" Or DataGridBotonDerecho.Name = "dgvGM_SHIMA" Then
                If DataGridBotonDerecho.Rows(BotonDerechoFila).Cells("DESC").Value.ToString = "*************" Then
                    Exit Sub
                End If
            ElseIf DataGridBotonDerecho.Name = "dgvTC_STOLL" Or DataGridBotonDerecho.Name = "dgvTC_SHIMA" Then
                If BotonDerechoColumna < 6 Then
                    If DataGridBotonDerecho.Rows(BotonDerechoFila).Cells("DESC_1").Value.ToString = "*************" Then
                        Exit Sub
                    End If
                Else
                    If DataGridBotonDerecho.Rows(BotonDerechoFila).Cells("DESC_2").Value.ToString = "*************" Then
                        Exit Sub
                    End If
                End If
            ElseIf DataGridBotonDerecho.Name = "dgvTM_STOLL" Or DataGridBotonDerecho.Name = "dgvTM_SHIMA" Then
                If DataGridBotonDerecho.Rows(BotonDerechoFila).Cells("DESC").Value.ToString = "*************" Then
                    Exit Sub
                End If
            End If

            If CorrerFilasParaAbajo(BotonDerechoFila, BotonDerechoColumna) = True Then

            Else
                MensajeAtencion("No se pueden insertar más filas.")
            End If
        Else
            MensajeAtencion("Debe seleccionar una Fila.")
        End If
    End Sub

    Private Function CorrerFilasParaAbajo(ByVal FilaALiberar As Integer, ByVal ColumnaClick As Integer) As Boolean
        Dim i As Integer
        Dim Retorno As Boolean = False

        If DataGridBotonDerecho.Name = "dgvGC_STOLL" Or DataGridBotonDerecho.Name = "dgvGC_SHIMA" Then

            If DataGridBotonDerecho.Rows(19).Cells("DESC_2").Value.ToString = "*************" Then
                If ColumnaClick < 5 Then
                    For i = 19 To 1 Step -1
                        DataGridBotonDerecho.Rows(i).Cells(5).Value = DataGridBotonDerecho.Rows(i - 1).Cells(5).Value
                        DataGridBotonDerecho.Rows(i).Cells(6).Value = DataGridBotonDerecho.Rows(i - 1).Cells(6).Value
                        DataGridBotonDerecho.Rows(i).Cells(7).Value = DataGridBotonDerecho.Rows(i - 1).Cells(7).Value
                        DataGridBotonDerecho.Rows(i).Cells(8).Value = DataGridBotonDerecho.Rows(i - 1).Cells(8).Value
                        DataGridBotonDerecho.Rows(i).Cells(9).Value = DataGridBotonDerecho.Rows(i - 1).Cells(9).Value
                    Next i
                    DataGridBotonDerecho.Rows(0).Cells(5).Value = DataGridBotonDerecho.Rows(19).Cells(0).Value
                    DataGridBotonDerecho.Rows(0).Cells(6).Value = DataGridBotonDerecho.Rows(19).Cells(1).Value
                    DataGridBotonDerecho.Rows(0).Cells(7).Value = DataGridBotonDerecho.Rows(19).Cells(2).Value
                    DataGridBotonDerecho.Rows(0).Cells(8).Value = DataGridBotonDerecho.Rows(19).Cells(3).Value
                    DataGridBotonDerecho.Rows(0).Cells(9).Value = DataGridBotonDerecho.Rows(19).Cells(4).Value
                    For i = 19 To FilaALiberar Step -1
                        If i = 0 Then Exit For
                        DataGridBotonDerecho.Rows(i).Cells(0).Value = DataGridBotonDerecho.Rows(i - 1).Cells(0).Value
                        DataGridBotonDerecho.Rows(i).Cells(1).Value = DataGridBotonDerecho.Rows(i - 1).Cells(1).Value
                        DataGridBotonDerecho.Rows(i).Cells(2).Value = DataGridBotonDerecho.Rows(i - 1).Cells(2).Value
                        DataGridBotonDerecho.Rows(i).Cells(3).Value = DataGridBotonDerecho.Rows(i - 1).Cells(3).Value
                        DataGridBotonDerecho.Rows(i).Cells(4).Value = DataGridBotonDerecho.Rows(i - 1).Cells(4).Value
                    Next i
                    DataGridBotonDerecho.Rows(FilaALiberar).Cells(0).Value = False
                    If DataGridBotonDerecho.Name = "dgvGC_STOLL" Then
                        DataGridBotonDerecho.Rows(FilaALiberar).Cells(1).Value = "NP"
                    Else
                        DataGridBotonDerecho.Rows(FilaALiberar).Cells(1).Value = "M"
                    End If
                    DataGridBotonDerecho.Rows(FilaALiberar).Cells(2).Value = ""
                    DataGridBotonDerecho.Rows(FilaALiberar).Cells(3).Value = ""
                    DataGridBotonDerecho.Rows(FilaALiberar).Cells(4).Value = ""

                Else
                    For i = 19 To FilaALiberar Step -1
                        If i = 0 Then Exit For
                        DataGridBotonDerecho.Rows(i).Cells(5).Value = DataGridBotonDerecho.Rows(i - 1).Cells(5).Value
                        DataGridBotonDerecho.Rows(i).Cells(6).Value = DataGridBotonDerecho.Rows(i - 1).Cells(6).Value
                        DataGridBotonDerecho.Rows(i).Cells(7).Value = DataGridBotonDerecho.Rows(i - 1).Cells(7).Value
                        DataGridBotonDerecho.Rows(i).Cells(8).Value = DataGridBotonDerecho.Rows(i - 1).Cells(8).Value
                        DataGridBotonDerecho.Rows(i).Cells(9).Value = DataGridBotonDerecho.Rows(i - 1).Cells(9).Value
                    Next i
                    DataGridBotonDerecho.Rows(FilaALiberar).Cells(5).Value = False
                    If DataGridBotonDerecho.Name = "dgvGC_STOLL" Then
                        DataGridBotonDerecho.Rows(FilaALiberar).Cells(6).Value = "NP"
                    Else
                        DataGridBotonDerecho.Rows(FilaALiberar).Cells(6).Value = "M"
                    End If
                    DataGridBotonDerecho.Rows(FilaALiberar).Cells(7).Value = ""
                    DataGridBotonDerecho.Rows(FilaALiberar).Cells(8).Value = ""
                    DataGridBotonDerecho.Rows(FilaALiberar).Cells(9).Value = ""

                End If

                Retorno = True
            End If

        ElseIf DataGridBotonDerecho.Name = "dgvGM_STOLL" Or DataGridBotonDerecho.Name = "dgvGM_SHIMA" Then

            If DataGridBotonDerecho.Rows(19).Cells("DESC").Value.ToString = "*************" Then
                For i = 19 To FilaALiberar Step -1
                    If i = 0 Then Exit For
                    DataGridBotonDerecho.Rows(i).Cells(0).Value = DataGridBotonDerecho.Rows(i - 1).Cells(0).Value
                    DataGridBotonDerecho.Rows(i).Cells(1).Value = DataGridBotonDerecho.Rows(i - 1).Cells(1).Value
                    DataGridBotonDerecho.Rows(i).Cells(2).Value = DataGridBotonDerecho.Rows(i - 1).Cells(2).Value
                    DataGridBotonDerecho.Rows(i).Cells(3).Value = DataGridBotonDerecho.Rows(i - 1).Cells(3).Value
                    DataGridBotonDerecho.Rows(i).Cells(4).Value = DataGridBotonDerecho.Rows(i - 1).Cells(4).Value
                Next i
                DataGridBotonDerecho.Rows(FilaALiberar).Cells(0).Value = False
                If DataGridBotonDerecho.Name = "dgvGM_STOLL" Then
                    DataGridBotonDerecho.Rows(FilaALiberar).Cells(1).Value = "NP"
                Else
                    DataGridBotonDerecho.Rows(FilaALiberar).Cells(1).Value = "M"
                End If
                DataGridBotonDerecho.Rows(FilaALiberar).Cells(2).Value = ""
                DataGridBotonDerecho.Rows(FilaALiberar).Cells(3).Value = ""
                DataGridBotonDerecho.Rows(FilaALiberar).Cells(4).Value = ""

                Retorno = True
            End If

        ElseIf DataGridBotonDerecho.Name = "dgvTC_STOLL" Or DataGridBotonDerecho.Name = "dgvTC_SHIMA" Then

            If DataGridBotonDerecho.Rows(9).Cells("DESC_2").Value.ToString = "*************" Then
                If ColumnaClick < 6 Then
                    For i = 9 To 1 Step -1
                        DataGridBotonDerecho.Rows(i).Cells(6).Value = DataGridBotonDerecho.Rows(i - 1).Cells(6).Value
                        DataGridBotonDerecho.Rows(i).Cells(7).Value = DataGridBotonDerecho.Rows(i - 1).Cells(7).Value
                        DataGridBotonDerecho.Rows(i).Cells(8).Value = DataGridBotonDerecho.Rows(i - 1).Cells(8).Value
                        DataGridBotonDerecho.Rows(i).Cells(9).Value = DataGridBotonDerecho.Rows(i - 1).Cells(9).Value
                        DataGridBotonDerecho.Rows(i).Cells(10).Value = DataGridBotonDerecho.Rows(i - 1).Cells(10).Value
                        DataGridBotonDerecho.Rows(i).Cells(11).Value = DataGridBotonDerecho.Rows(i - 1).Cells(11).Value
                    Next i
                    DataGridBotonDerecho.Rows(0).Cells(6).Value = DataGridBotonDerecho.Rows(9).Cells(0).Value
                    DataGridBotonDerecho.Rows(0).Cells(7).Value = DataGridBotonDerecho.Rows(9).Cells(1).Value
                    DataGridBotonDerecho.Rows(0).Cells(8).Value = DataGridBotonDerecho.Rows(9).Cells(2).Value
                    DataGridBotonDerecho.Rows(0).Cells(9).Value = DataGridBotonDerecho.Rows(9).Cells(3).Value
                    DataGridBotonDerecho.Rows(0).Cells(10).Value = DataGridBotonDerecho.Rows(9).Cells(4).Value
                    DataGridBotonDerecho.Rows(0).Cells(11).Value = DataGridBotonDerecho.Rows(9).Cells(5).Value
                    For i = 9 To FilaALiberar Step -1
                        If i = 0 Then Exit For
                        DataGridBotonDerecho.Rows(i).Cells(0).Value = DataGridBotonDerecho.Rows(i - 1).Cells(0).Value
                        DataGridBotonDerecho.Rows(i).Cells(1).Value = DataGridBotonDerecho.Rows(i - 1).Cells(1).Value
                        DataGridBotonDerecho.Rows(i).Cells(2).Value = DataGridBotonDerecho.Rows(i - 1).Cells(2).Value
                        DataGridBotonDerecho.Rows(i).Cells(3).Value = DataGridBotonDerecho.Rows(i - 1).Cells(3).Value
                        DataGridBotonDerecho.Rows(i).Cells(4).Value = DataGridBotonDerecho.Rows(i - 1).Cells(4).Value
                        DataGridBotonDerecho.Rows(i).Cells(5).Value = DataGridBotonDerecho.Rows(i - 1).Cells(5).Value
                    Next i
                    DataGridBotonDerecho.Rows(FilaALiberar).Cells("DESC_1").Value = ""
                    If DataGridBotonDerecho.Name = "dgvTC_STOLL" Then
                        DataGridBotonDerecho.Rows(FilaALiberar).Cells("LETRA_1").Value = "WMF"
                    Else
                        DataGridBotonDerecho.Rows(FilaALiberar).Cells("LETRA_1").Value = "T"
                    End If
                    DataGridBotonDerecho.Rows(FilaALiberar).Cells("C1_1").Value = ""
                    DataGridBotonDerecho.Rows(FilaALiberar).Cells("C2_1").Value = ""
                    DataGridBotonDerecho.Rows(FilaALiberar).Cells("C3_1").Value = ""
                    DataGridBotonDerecho.Rows(FilaALiberar).Cells("C4_1").Value = ""

                Else
                    For i = 9 To FilaALiberar Step -1
                        If i = 0 Then Exit For
                        DataGridBotonDerecho.Rows(i).Cells(6).Value = DataGridBotonDerecho.Rows(i - 1).Cells(6).Value
                        DataGridBotonDerecho.Rows(i).Cells(7).Value = DataGridBotonDerecho.Rows(i - 1).Cells(7).Value
                        DataGridBotonDerecho.Rows(i).Cells(8).Value = DataGridBotonDerecho.Rows(i - 1).Cells(8).Value
                        DataGridBotonDerecho.Rows(i).Cells(9).Value = DataGridBotonDerecho.Rows(i - 1).Cells(9).Value
                        DataGridBotonDerecho.Rows(i).Cells(10).Value = DataGridBotonDerecho.Rows(i - 1).Cells(10).Value
                        DataGridBotonDerecho.Rows(i).Cells(11).Value = DataGridBotonDerecho.Rows(i - 1).Cells(11).Value
                    Next i
                    DataGridBotonDerecho.Rows(FilaALiberar).Cells("DESC_2").Value = ""
                    If DataGridBotonDerecho.Name = "dgvTC_STOLL" Then
                        DataGridBotonDerecho.Rows(FilaALiberar).Cells("LETRA_2").Value = "WMF"
                    Else
                        DataGridBotonDerecho.Rows(FilaALiberar).Cells("LETRA_2").Value = "T"
                    End If
                    DataGridBotonDerecho.Rows(FilaALiberar).Cells("C1_2").Value = ""
                    DataGridBotonDerecho.Rows(FilaALiberar).Cells("C2_2").Value = ""
                    DataGridBotonDerecho.Rows(FilaALiberar).Cells("C3_2").Value = ""
                    DataGridBotonDerecho.Rows(FilaALiberar).Cells("C4_2").Value = ""

                End If

                Retorno = True
            End If

        ElseIf DataGridBotonDerecho.Name = "dgvTM_STOLL" Or DataGridBotonDerecho.Name = "dgvTM_SHIMA" Then

            If DataGridBotonDerecho.Rows(9).Cells("DESC").Value.ToString = "*************" Then
                For i = 9 To FilaALiberar Step -1
                    If i = 0 Then Exit For
                    DataGridBotonDerecho.Rows(i).Cells(0).Value = DataGridBotonDerecho.Rows(i - 1).Cells(0).Value
                    DataGridBotonDerecho.Rows(i).Cells(1).Value = DataGridBotonDerecho.Rows(i - 1).Cells(1).Value
                    DataGridBotonDerecho.Rows(i).Cells(2).Value = DataGridBotonDerecho.Rows(i - 1).Cells(2).Value
                    DataGridBotonDerecho.Rows(i).Cells(3).Value = DataGridBotonDerecho.Rows(i - 1).Cells(3).Value
                    DataGridBotonDerecho.Rows(i).Cells(4).Value = DataGridBotonDerecho.Rows(i - 1).Cells(4).Value
                    DataGridBotonDerecho.Rows(i).Cells(5).Value = DataGridBotonDerecho.Rows(i - 1).Cells(5).Value
                Next i
                DataGridBotonDerecho.Rows(FilaALiberar).Cells("DESC").Value = ""
                If DataGridBotonDerecho.Name = "dgvTM_STOLL" Then
                    DataGridBotonDerecho.Rows(FilaALiberar).Cells("LETRA").Value = "WMF"
                Else
                    DataGridBotonDerecho.Rows(FilaALiberar).Cells("LETRA").Value = "T"
                End If
                DataGridBotonDerecho.Rows(FilaALiberar).Cells("C1").Value = ""
                DataGridBotonDerecho.Rows(FilaALiberar).Cells("C2").Value = ""
                DataGridBotonDerecho.Rows(FilaALiberar).Cells("C3").Value = ""
                DataGridBotonDerecho.Rows(FilaALiberar).Cells("C4").Value = ""

                Retorno = True
            End If

        End If

        Return Retorno
    End Function

    Private Sub EliminarFilaMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarFilaMenuItem.Click
        If BotonDerechoFila >= 0 Then
            If EliminarFila(BotonDerechoFila, BotonDerechoColumna) = True Then

            Else
                MensajeAtencion("No se pudo eliminar la fila.")
            End If
        Else
            MensajeAtencion("Debe seleccionar una Fila.")
        End If
    End Sub

    Private Function EliminarFila(ByVal FilaAEliminar As Integer, ByVal ColumnaClick As Integer) As Boolean
        Dim i As Integer
        Dim Retorno As Boolean = False

        If DataGridBotonDerecho.Name = "dgvGC_STOLL" Or DataGridBotonDerecho.Name = "dgvGC_SHIMA" Then

            If ColumnaClick < 5 Then
                For i = FilaAEliminar To 18
                    DataGridBotonDerecho.Rows(i).Cells(0).Value = DataGridBotonDerecho.Rows(i + 1).Cells(0).Value
                    DataGridBotonDerecho.Rows(i).Cells(1).Value = DataGridBotonDerecho.Rows(i + 1).Cells(1).Value
                    DataGridBotonDerecho.Rows(i).Cells(2).Value = DataGridBotonDerecho.Rows(i + 1).Cells(2).Value
                    DataGridBotonDerecho.Rows(i).Cells(3).Value = DataGridBotonDerecho.Rows(i + 1).Cells(3).Value
                    DataGridBotonDerecho.Rows(i).Cells(4).Value = DataGridBotonDerecho.Rows(i + 1).Cells(4).Value
                Next i
                DataGridBotonDerecho.Rows(19).Cells(0).Value = DataGridBotonDerecho.Rows(0).Cells(5).Value
                DataGridBotonDerecho.Rows(19).Cells(1).Value = DataGridBotonDerecho.Rows(0).Cells(6).Value
                DataGridBotonDerecho.Rows(19).Cells(2).Value = DataGridBotonDerecho.Rows(0).Cells(7).Value
                DataGridBotonDerecho.Rows(19).Cells(3).Value = DataGridBotonDerecho.Rows(0).Cells(8).Value
                DataGridBotonDerecho.Rows(19).Cells(4).Value = DataGridBotonDerecho.Rows(0).Cells(9).Value
                For i = 0 To 18
                    DataGridBotonDerecho.Rows(i).Cells(5).Value = DataGridBotonDerecho.Rows(i + 1).Cells(5).Value
                    DataGridBotonDerecho.Rows(i).Cells(6).Value = DataGridBotonDerecho.Rows(i + 1).Cells(6).Value
                    DataGridBotonDerecho.Rows(i).Cells(7).Value = DataGridBotonDerecho.Rows(i + 1).Cells(7).Value
                    DataGridBotonDerecho.Rows(i).Cells(8).Value = DataGridBotonDerecho.Rows(i + 1).Cells(8).Value
                    DataGridBotonDerecho.Rows(i).Cells(9).Value = DataGridBotonDerecho.Rows(i + 1).Cells(9).Value
                Next i

                DataGridBotonDerecho.Rows(19).Cells(5).Value = False
                If DataGridBotonDerecho.Name = "dgvGC_STOLL" Then
                    DataGridBotonDerecho.Rows(19).Cells("LETRA_2").Value = "NP"
                Else
                    DataGridBotonDerecho.Rows(19).Cells("LETRA_2").Value = "M"
                End If
                DataGridBotonDerecho.Rows(19).Cells("DESC_2").Value = "*************"
                DataGridBotonDerecho.Rows(19).Cells("C1_2").Value = "0"
                DataGridBotonDerecho.Rows(19).Cells("C2_2").Value = "0"

            Else
                For i = FilaAEliminar To 18
                    DataGridBotonDerecho.Rows(i).Cells(5).Value = DataGridBotonDerecho.Rows(i + 1).Cells(5).Value
                    DataGridBotonDerecho.Rows(i).Cells(6).Value = DataGridBotonDerecho.Rows(i + 1).Cells(6).Value
                    DataGridBotonDerecho.Rows(i).Cells(7).Value = DataGridBotonDerecho.Rows(i + 1).Cells(7).Value
                    DataGridBotonDerecho.Rows(i).Cells(8).Value = DataGridBotonDerecho.Rows(i + 1).Cells(8).Value
                    DataGridBotonDerecho.Rows(i).Cells(9).Value = DataGridBotonDerecho.Rows(i + 1).Cells(9).Value
                Next i
                DataGridBotonDerecho.Rows(19).Cells(5).Value = False
                If DataGridBotonDerecho.Name = "dgvGC_STOLL" Then
                    DataGridBotonDerecho.Rows(19).Cells("LETRA_2").Value = "NP"
                Else
                    DataGridBotonDerecho.Rows(19).Cells("LETRA_2").Value = "M"
                End If
                DataGridBotonDerecho.Rows(19).Cells("DESC_2").Value = "*************"
                DataGridBotonDerecho.Rows(19).Cells("C1_2").Value = "0"
                DataGridBotonDerecho.Rows(19).Cells("C2_2").Value = "0"
            End If
            Retorno = True

        ElseIf DataGridBotonDerecho.Name = "dgvGM_STOLL" Or DataGridBotonDerecho.Name = "dgvGM_SHIMA" Then

            For i = FilaAEliminar To 18
                DataGridBotonDerecho.Rows(i).Cells(0).Value = DataGridBotonDerecho.Rows(i + 1).Cells(0).Value
                DataGridBotonDerecho.Rows(i).Cells(1).Value = DataGridBotonDerecho.Rows(i + 1).Cells(1).Value
                DataGridBotonDerecho.Rows(i).Cells(2).Value = DataGridBotonDerecho.Rows(i + 1).Cells(2).Value
                DataGridBotonDerecho.Rows(i).Cells(3).Value = DataGridBotonDerecho.Rows(i + 1).Cells(3).Value
                DataGridBotonDerecho.Rows(i).Cells(4).Value = DataGridBotonDerecho.Rows(i + 1).Cells(4).Value
            Next i
            DataGridBotonDerecho.Rows(19).Cells(0).Value = False
            If DataGridBotonDerecho.Name = "dgvGM_STOLL" Then
                DataGridBotonDerecho.Rows(19).Cells(1).Value = "NP"
            Else
                DataGridBotonDerecho.Rows(19).Cells(1).Value = "M"
            End If
            DataGridBotonDerecho.Rows(19).Cells("DESC").Value = "*************"
            DataGridBotonDerecho.Rows(19).Cells("C1").Value = "0"
            DataGridBotonDerecho.Rows(19).Cells("C2").Value = "0"

            Retorno = True

        ElseIf DataGridBotonDerecho.Name = "dgvTC_STOLL" Or DataGridBotonDerecho.Name = "dgvTC_SHIMA" Then

            If ColumnaClick < 6 Then
                For i = FilaAEliminar To 8
                    DataGridBotonDerecho.Rows(i).Cells(0).Value = DataGridBotonDerecho.Rows(i + 1).Cells(0).Value
                    DataGridBotonDerecho.Rows(i).Cells(1).Value = DataGridBotonDerecho.Rows(i + 1).Cells(1).Value
                    DataGridBotonDerecho.Rows(i).Cells(2).Value = DataGridBotonDerecho.Rows(i + 1).Cells(2).Value
                    DataGridBotonDerecho.Rows(i).Cells(3).Value = DataGridBotonDerecho.Rows(i + 1).Cells(3).Value
                    DataGridBotonDerecho.Rows(i).Cells(4).Value = DataGridBotonDerecho.Rows(i + 1).Cells(4).Value
                    DataGridBotonDerecho.Rows(i).Cells(5).Value = DataGridBotonDerecho.Rows(i + 1).Cells(5).Value
                Next i
                DataGridBotonDerecho.Rows(9).Cells(0).Value = DataGridBotonDerecho.Rows(0).Cells(6).Value
                DataGridBotonDerecho.Rows(9).Cells(1).Value = DataGridBotonDerecho.Rows(0).Cells(7).Value
                DataGridBotonDerecho.Rows(9).Cells(2).Value = DataGridBotonDerecho.Rows(0).Cells(8).Value
                DataGridBotonDerecho.Rows(9).Cells(3).Value = DataGridBotonDerecho.Rows(0).Cells(9).Value
                DataGridBotonDerecho.Rows(9).Cells(4).Value = DataGridBotonDerecho.Rows(0).Cells(10).Value
                DataGridBotonDerecho.Rows(9).Cells(5).Value = DataGridBotonDerecho.Rows(0).Cells(11).Value
                For i = 0 To 8
                    DataGridBotonDerecho.Rows(i).Cells(6).Value = DataGridBotonDerecho.Rows(i + 1).Cells(6).Value
                    DataGridBotonDerecho.Rows(i).Cells(7).Value = DataGridBotonDerecho.Rows(i + 1).Cells(7).Value
                    DataGridBotonDerecho.Rows(i).Cells(8).Value = DataGridBotonDerecho.Rows(i + 1).Cells(8).Value
                    DataGridBotonDerecho.Rows(i).Cells(9).Value = DataGridBotonDerecho.Rows(i + 1).Cells(9).Value
                    DataGridBotonDerecho.Rows(i).Cells(10).Value = DataGridBotonDerecho.Rows(i + 1).Cells(10).Value
                    DataGridBotonDerecho.Rows(i).Cells(11).Value = DataGridBotonDerecho.Rows(i + 1).Cells(11).Value
                Next i
                DataGridBotonDerecho.Rows(9).Cells("DESC_2").Value = "*************"
                If DataGridBotonDerecho.Name = "dgvTC_STOLL" Then
                    DataGridBotonDerecho.Rows(9).Cells("LETRA_2").Value = "WMF"
                Else
                    DataGridBotonDerecho.Rows(9).Cells("LETRA_2").Value = "T"
                End If
                DataGridBotonDerecho.Rows(9).Cells("C1_2").Value = "0"
                DataGridBotonDerecho.Rows(9).Cells("C2_2").Value = "0"
                DataGridBotonDerecho.Rows(9).Cells("C3_2").Value = "0"
                DataGridBotonDerecho.Rows(9).Cells("C4_2").Value = "0"

            Else
                For i = FilaAEliminar To 8
                    DataGridBotonDerecho.Rows(i).Cells(6).Value = DataGridBotonDerecho.Rows(i + 1).Cells(6).Value
                    DataGridBotonDerecho.Rows(i).Cells(7).Value = DataGridBotonDerecho.Rows(i + 1).Cells(7).Value
                    DataGridBotonDerecho.Rows(i).Cells(8).Value = DataGridBotonDerecho.Rows(i + 1).Cells(8).Value
                    DataGridBotonDerecho.Rows(i).Cells(9).Value = DataGridBotonDerecho.Rows(i + 1).Cells(9).Value
                    DataGridBotonDerecho.Rows(i).Cells(10).Value = DataGridBotonDerecho.Rows(i + 1).Cells(10).Value
                    DataGridBotonDerecho.Rows(i).Cells(11).Value = DataGridBotonDerecho.Rows(i + 1).Cells(11).Value
                Next i
                DataGridBotonDerecho.Rows(9).Cells("DESC_2").Value = "*************"
                If DataGridBotonDerecho.Name = "dgvTC_STOLL" Then
                    DataGridBotonDerecho.Rows(9).Cells("LETRA_2").Value = "WMF"
                Else
                    DataGridBotonDerecho.Rows(9).Cells("LETRA_2").Value = "T"
                End If
                DataGridBotonDerecho.Rows(9).Cells("C1_2").Value = "0"
                DataGridBotonDerecho.Rows(9).Cells("C2_2").Value = "0"
                DataGridBotonDerecho.Rows(9).Cells("C3_2").Value = "0"
                DataGridBotonDerecho.Rows(9).Cells("C4_2").Value = "0"

            End If

            Retorno = True

        ElseIf DataGridBotonDerecho.Name = "dgvTM_STOLL" Or DataGridBotonDerecho.Name = "dgvTM_SHIMA" Then

            For i = FilaAEliminar To 8
                DataGridBotonDerecho.Rows(i).Cells(0).Value = DataGridBotonDerecho.Rows(i + 1).Cells(0).Value
                DataGridBotonDerecho.Rows(i).Cells(1).Value = DataGridBotonDerecho.Rows(i + 1).Cells(1).Value
                DataGridBotonDerecho.Rows(i).Cells(2).Value = DataGridBotonDerecho.Rows(i + 1).Cells(2).Value
                DataGridBotonDerecho.Rows(i).Cells(3).Value = DataGridBotonDerecho.Rows(i + 1).Cells(3).Value
                DataGridBotonDerecho.Rows(i).Cells(4).Value = DataGridBotonDerecho.Rows(i + 1).Cells(4).Value
                DataGridBotonDerecho.Rows(i).Cells(5).Value = DataGridBotonDerecho.Rows(i + 1).Cells(5).Value
            Next i
            DataGridBotonDerecho.Rows(9).Cells("DESC").Value = "*************"
            If DataGridBotonDerecho.Name = "dgvTM_STOLL" Then
                DataGridBotonDerecho.Rows(9).Cells("LETRA").Value = "WMF"
            Else
                DataGridBotonDerecho.Rows(9).Cells("LETRA").Value = "T"
            End If
            DataGridBotonDerecho.Rows(9).Cells("C1").Value = "0"
            DataGridBotonDerecho.Rows(9).Cells("C2").Value = "0"
            DataGridBotonDerecho.Rows(9).Cells("C3").Value = "0"
            DataGridBotonDerecho.Rows(9).Cells("C4").Value = "0"

            Retorno = True

        End If

        Return Retorno
    End Function

    Private Sub CargarTiemposyPesosdelaPlanilla()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        CrearDgvdeTiemposyPesos()

        If Not Alta Then
            If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
            sStr = "SELECT * FROM PrendasArtProdPlanillas_TP WHERE IdPlanilla = " + ID.ToString
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read Then

                    If Not IsDBNull(Reader.Item("T_XXS")) Then dgvTiempoyPeso.Rows(0).Cells("XXS").Value = Reader.Item("T_XXS")
                    If Not IsDBNull(Reader.Item("T_XS")) Then dgvTiempoyPeso.Rows(0).Cells("XS").Value = Reader.Item("T_XS")
                    If Not IsDBNull(Reader.Item("T_S")) Then dgvTiempoyPeso.Rows(0).Cells("S").Value = Reader.Item("T_S")
                    If Not IsDBNull(Reader.Item("T_M")) Then dgvTiempoyPeso.Rows(0).Cells("M").Value = Reader.Item("T_M")
                    If Not IsDBNull(Reader.Item("T_L")) Then dgvTiempoyPeso.Rows(0).Cells("L").Value = Reader.Item("T_L")
                    If Not IsDBNull(Reader.Item("T_XL")) Then dgvTiempoyPeso.Rows(0).Cells("XL").Value = Reader.Item("T_XL")
                    If Not IsDBNull(Reader.Item("T_XXL")) Then dgvTiempoyPeso.Rows(0).Cells("XXL").Value = Reader.Item("T_XXL")
                    If Not IsDBNull(Reader.Item("T_XXXL")) Then dgvTiempoyPeso.Rows(0).Cells("XXXL").Value = Reader.Item("T_XXXL")
                    If Not IsDBNull(Reader.Item("T_U")) Then dgvTiempoyPeso.Rows(0).Cells("U").Value = Reader.Item("T_U")

                    If Not IsDBNull(Reader.Item("P_XXS")) Then dgvTiempoyPeso.Rows(1).Cells("XXS").Value = Reader.Item("P_XXS")
                    If Not IsDBNull(Reader.Item("P_XS")) Then dgvTiempoyPeso.Rows(1).Cells("XS").Value = Reader.Item("P_XS")
                    If Not IsDBNull(Reader.Item("P_S")) Then dgvTiempoyPeso.Rows(1).Cells("S").Value = Reader.Item("P_S")
                    If Not IsDBNull(Reader.Item("P_M")) Then dgvTiempoyPeso.Rows(1).Cells("M").Value = Reader.Item("P_M")
                    If Not IsDBNull(Reader.Item("P_L")) Then dgvTiempoyPeso.Rows(1).Cells("L").Value = Reader.Item("P_L")
                    If Not IsDBNull(Reader.Item("P_XL")) Then dgvTiempoyPeso.Rows(1).Cells("XL").Value = Reader.Item("P_XL")
                    If Not IsDBNull(Reader.Item("P_XXL")) Then dgvTiempoyPeso.Rows(1).Cells("XXL").Value = Reader.Item("P_XXL")
                    If Not IsDBNull(Reader.Item("P_XXXL")) Then dgvTiempoyPeso.Rows(1).Cells("XXXL").Value = Reader.Item("P_XXXL")
                    If Not IsDBNull(Reader.Item("P_U")) Then dgvTiempoyPeso.Rows(1).Cells("U").Value = Reader.Item("P_U")

                End If
            End If
        End If

    End Sub
    Private Sub CrearDgvdeTiemposyPesos()
        Dim row As String()

        dgvTiempoyPeso.Rows.Clear()
        dgvTiempoyPeso.Columns.Clear()

        dgvTiempoyPeso.Columns.Add("DATO", "DATO")
        dgvTiempoyPeso.Columns("DATO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvTiempoyPeso.Columns("DATO").Width = 100
        dgvTiempoyPeso.Columns("DATO").ReadOnly = True
        dgvTiempoyPeso.Columns.Add("XXS", "XXS")
        dgvTiempoyPeso.Columns("XXS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTiempoyPeso.Columns("XXS").Width = 90
        dgvTiempoyPeso.Columns.Add("XS", "XS")
        dgvTiempoyPeso.Columns("XS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTiempoyPeso.Columns("XS").Width = 90
        dgvTiempoyPeso.Columns.Add("S", "S")
        dgvTiempoyPeso.Columns("S").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTiempoyPeso.Columns("S").Width = 90
        dgvTiempoyPeso.Columns.Add("M", "M")
        dgvTiempoyPeso.Columns("M").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTiempoyPeso.Columns("M").Width = 90
        dgvTiempoyPeso.Columns.Add("L", "L")
        dgvTiempoyPeso.Columns("L").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTiempoyPeso.Columns("L").Width = 90
        dgvTiempoyPeso.Columns.Add("XL", "XL")
        dgvTiempoyPeso.Columns("XL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTiempoyPeso.Columns("XL").Width = 90
        dgvTiempoyPeso.Columns.Add("XXL", "XXL")
        dgvTiempoyPeso.Columns("XXL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTiempoyPeso.Columns("XXL").Width = 90
        dgvTiempoyPeso.Columns.Add("XXXL", "XXXL")
        dgvTiempoyPeso.Columns("XXXL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTiempoyPeso.Columns("XXXL").Width = 95
        dgvTiempoyPeso.Columns.Add("U", "U")
        dgvTiempoyPeso.Columns("U").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvTiempoyPeso.Columns("U").Width = 90

        dgvTiempoyPeso.ColumnHeadersVisible = True
        dgvTiempoyPeso.RowHeadersVisible = False
        dgvTiempoyPeso.DefaultCellStyle.Font = New Font("Tahoma", 9)
        dgvTiempoyPeso.RowTemplate.Height = 23

        row = {"TIEMPO", "", "", "", "", "", "", "", "", ""}
        dgvTiempoyPeso.Rows.Add(row)
        row = {"PESO", "", "", "", "", "", "", "", "", ""}
        dgvTiempoyPeso.Rows.Add(row)

    End Sub

    '****************el maxlenght de los datagrid*************************************************************
    Private Sub dgvTC_STOLL_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvTC_STOLL.EditingControlShowing
        If dgvTC_STOLL.CurrentCell.EditType IsNot Nothing Then
            If dgvTC_STOLL.CurrentCell.EditType Is GetType(DataGridViewTextBoxEditingControl) Then
                If dgvTC_STOLL.CurrentCell.ColumnIndex = dgvTC_STOLL.Columns("LETRA_1").Index Or dgvTC_STOLL.CurrentCell.ColumnIndex = dgvTC_STOLL.Columns("LETRA_2").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 3
                ElseIf dgvTC_STOLL.CurrentCell.ColumnIndex = dgvTC_STOLL.Columns("C1_1").Index Or dgvTC_STOLL.CurrentCell.ColumnIndex = dgvTC_STOLL.Columns("C1_2").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 5
                ElseIf dgvTC_STOLL.CurrentCell.ColumnIndex = dgvTC_STOLL.Columns("C2_1").Index Or dgvTC_STOLL.CurrentCell.ColumnIndex = dgvTC_STOLL.Columns("C2_2").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 5
                ElseIf dgvTC_STOLL.CurrentCell.ColumnIndex = dgvTC_STOLL.Columns("C3_1").Index Or dgvTC_STOLL.CurrentCell.ColumnIndex = dgvTC_STOLL.Columns("C3_2").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 5
                ElseIf dgvTC_STOLL.CurrentCell.ColumnIndex = dgvTC_STOLL.Columns("C4_1").Index Or dgvTC_STOLL.CurrentCell.ColumnIndex = dgvTC_STOLL.Columns("C4_2").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 5
                ElseIf dgvTC_STOLL.CurrentCell.ColumnIndex = dgvTC_STOLL.Columns("DESC_1").Index Or dgvTC_STOLL.CurrentCell.ColumnIndex = dgvTC_STOLL.Columns("DESC_2").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 17
                End If
            End If
        End If
    End Sub

    Private Sub dgvTM_STOLL_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvTM_STOLL.EditingControlShowing
        If dgvTM_STOLL.CurrentCell.EditType IsNot Nothing Then
            If dgvTM_STOLL.CurrentCell.EditType Is GetType(DataGridViewTextBoxEditingControl) Then
                If dgvTM_STOLL.CurrentCell.ColumnIndex = dgvTM_STOLL.Columns("LETRA").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 3
                ElseIf dgvTM_STOLL.CurrentCell.ColumnIndex = dgvTM_STOLL.Columns("C1").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 5
                ElseIf dgvTM_STOLL.CurrentCell.ColumnIndex = dgvTM_STOLL.Columns("C2").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 5
                ElseIf dgvTM_STOLL.CurrentCell.ColumnIndex = dgvTM_STOLL.Columns("C3").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 5
                ElseIf dgvTM_STOLL.CurrentCell.ColumnIndex = dgvTM_STOLL.Columns("C4").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 5
                ElseIf dgvTM_STOLL.CurrentCell.ColumnIndex = dgvTM_STOLL.Columns("DESC").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 17
                End If
            End If
        End If
    End Sub

    Private Sub dgvTC_SHIMA_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvTC_SHIMA.EditingControlShowing
        If dgvTC_SHIMA.CurrentCell.EditType IsNot Nothing Then
            If dgvTC_SHIMA.CurrentCell.EditType Is GetType(DataGridViewTextBoxEditingControl) Then
                If dgvTC_SHIMA.CurrentCell.ColumnIndex = dgvTC_SHIMA.Columns("LETRA_1").Index Or dgvTC_SHIMA.CurrentCell.ColumnIndex = dgvTC_SHIMA.Columns("LETRA_2").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 3
                ElseIf dgvTC_SHIMA.CurrentCell.ColumnIndex = dgvTC_SHIMA.Columns("C1_1").Index Or dgvTC_SHIMA.CurrentCell.ColumnIndex = dgvTC_SHIMA.Columns("C1_2").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 5
                ElseIf dgvTC_SHIMA.CurrentCell.ColumnIndex = dgvTC_SHIMA.Columns("C2_1").Index Or dgvTC_SHIMA.CurrentCell.ColumnIndex = dgvTC_SHIMA.Columns("C2_2").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 5
                ElseIf dgvTC_SHIMA.CurrentCell.ColumnIndex = dgvTC_SHIMA.Columns("C3_1").Index Or dgvTC_SHIMA.CurrentCell.ColumnIndex = dgvTC_SHIMA.Columns("C3_2").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 5
                ElseIf dgvTC_SHIMA.CurrentCell.ColumnIndex = dgvTC_SHIMA.Columns("C4_1").Index Or dgvTC_SHIMA.CurrentCell.ColumnIndex = dgvTC_SHIMA.Columns("C4_2").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 5
                ElseIf dgvTC_SHIMA.CurrentCell.ColumnIndex = dgvTC_SHIMA.Columns("DESC_1").Index Or dgvTC_SHIMA.CurrentCell.ColumnIndex = dgvTC_SHIMA.Columns("DESC_2").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 17
                End If
            End If
        End If
    End Sub

    Private Sub dgvTM_SHIMA_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvTM_SHIMA.EditingControlShowing
        If dgvTM_SHIMA.CurrentCell.EditType IsNot Nothing Then
            If dgvTM_SHIMA.CurrentCell.EditType Is GetType(DataGridViewTextBoxEditingControl) Then
                If dgvTM_SHIMA.CurrentCell.ColumnIndex = dgvTM_SHIMA.Columns("LETRA").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 3
                ElseIf dgvTM_SHIMA.CurrentCell.ColumnIndex = dgvTM_SHIMA.Columns("C1").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 5
                ElseIf dgvTM_SHIMA.CurrentCell.ColumnIndex = dgvTM_SHIMA.Columns("C2").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 5
                ElseIf dgvTM_SHIMA.CurrentCell.ColumnIndex = dgvTM_SHIMA.Columns("C3").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 5
                ElseIf dgvTM_SHIMA.CurrentCell.ColumnIndex = dgvTM_SHIMA.Columns("C4").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 5
                ElseIf dgvTM_SHIMA.CurrentCell.ColumnIndex = dgvTM_SHIMA.Columns("DESC").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 17
                End If
            End If
        End If
    End Sub

    Private Sub dgvGC_STOLL_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvGC_STOLL.EditingControlShowing
        If dgvGC_STOLL.CurrentCell.EditType IsNot Nothing Then
            If dgvGC_STOLL.CurrentCell.EditType Is GetType(DataGridViewTextBoxEditingControl) Then
                If dgvGC_STOLL.CurrentCell.ColumnIndex = dgvGC_STOLL.Columns("LETRA_1").Index Or dgvGC_STOLL.CurrentCell.ColumnIndex = dgvGC_STOLL.Columns("LETRA_2").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 3
                ElseIf dgvGC_STOLL.CurrentCell.ColumnIndex = dgvGC_STOLL.Columns("C1_1").Index Or dgvGC_STOLL.CurrentCell.ColumnIndex = dgvGC_STOLL.Columns("C1_2").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 5
                ElseIf dgvGC_STOLL.CurrentCell.ColumnIndex = dgvGC_STOLL.Columns("C2_1").Index Or dgvGC_STOLL.CurrentCell.ColumnIndex = dgvGC_STOLL.Columns("C2_2").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 5
                ElseIf dgvGC_STOLL.CurrentCell.ColumnIndex = dgvGC_STOLL.Columns("DESC_1").Index Or dgvGC_STOLL.CurrentCell.ColumnIndex = dgvGC_STOLL.Columns("DESC_2").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 22
                End If
            End If
        End If
    End Sub

    Private Sub dgvGM_STOLL_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvGM_STOLL.EditingControlShowing
        If dgvGM_STOLL.CurrentCell.EditType IsNot Nothing Then
            If dgvGM_STOLL.CurrentCell.EditType Is GetType(DataGridViewTextBoxEditingControl) Then
                If dgvGM_STOLL.CurrentCell.ColumnIndex = dgvGM_STOLL.Columns("LETRA").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 3
                ElseIf dgvGM_STOLL.CurrentCell.ColumnIndex = dgvGM_STOLL.Columns("C1").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 5
                ElseIf dgvGM_STOLL.CurrentCell.ColumnIndex = dgvGM_STOLL.Columns("C2").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 5
                ElseIf dgvGM_STOLL.CurrentCell.ColumnIndex = dgvGM_STOLL.Columns("DESC").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 22
                End If
            End If
        End If
    End Sub

    Private Sub dgvGC_SHIMA_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvGC_SHIMA.EditingControlShowing
        If dgvGC_SHIMA.CurrentCell.EditType IsNot Nothing Then
            If dgvGC_SHIMA.CurrentCell.EditType Is GetType(DataGridViewTextBoxEditingControl) Then
                If dgvGC_SHIMA.CurrentCell.ColumnIndex = dgvGC_SHIMA.Columns("LETRA_1").Index Or dgvGC_SHIMA.CurrentCell.ColumnIndex = dgvGC_SHIMA.Columns("LETRA_2").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 3
                ElseIf dgvGC_SHIMA.CurrentCell.ColumnIndex = dgvGC_SHIMA.Columns("C1_1").Index Or dgvGC_SHIMA.CurrentCell.ColumnIndex = dgvGC_SHIMA.Columns("C1_2").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 5
                ElseIf dgvGC_SHIMA.CurrentCell.ColumnIndex = dgvGC_SHIMA.Columns("C2_1").Index Or dgvGC_SHIMA.CurrentCell.ColumnIndex = dgvGC_SHIMA.Columns("C2_2").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 5
                ElseIf dgvGC_SHIMA.CurrentCell.ColumnIndex = dgvGC_SHIMA.Columns("DESC_1").Index Or dgvGC_SHIMA.CurrentCell.ColumnIndex = dgvGC_SHIMA.Columns("DESC_2").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 22
                End If
            End If
        End If
    End Sub

    Private Sub dgvGM_SHIMA_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvGM_SHIMA.EditingControlShowing
        If dgvGM_SHIMA.CurrentCell.EditType IsNot Nothing Then
            If dgvGM_SHIMA.CurrentCell.EditType Is GetType(DataGridViewTextBoxEditingControl) Then
                If dgvGM_SHIMA.CurrentCell.ColumnIndex = dgvGM_SHIMA.Columns("LETRA").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 3
                ElseIf dgvGM_SHIMA.CurrentCell.ColumnIndex = dgvGM_SHIMA.Columns("C1").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 5
                ElseIf dgvGM_SHIMA.CurrentCell.ColumnIndex = dgvGM_SHIMA.Columns("C2").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 5
                ElseIf dgvGM_SHIMA.CurrentCell.ColumnIndex = dgvGM_SHIMA.Columns("DESC").Index Then
                    Dim tb As TextBox = CType(e.Control, TextBox)
                    tb.MaxLength = 22
                End If
            End If
        End If
    End Sub

    Private Sub dgvTiempoyPeso_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvTiempoyPeso.EditingControlShowing
        If dgvTiempoyPeso.CurrentCell.EditType IsNot Nothing Then
            If dgvTiempoyPeso.CurrentCell.EditType Is GetType(DataGridViewTextBoxEditingControl) Then
                Dim tb As TextBox = CType(e.Control, TextBox)
                tb.MaxLength = 15
            End If
        End If
    End Sub

    Private Sub btnPonerOriginal_Click(sender As Object, e As EventArgs) Handles btnPonerOriginal.Click
        Dim Command As New SqlCommand
        Dim sStr As String

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "UPDATE PrendasArtProdPlanillas SET EsOriginal = 1 WHERE id = " + ID.ToString
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        ElArticuloEsOriginal = 1

        RegistroEnHistorial("P", ID.ToString, "Declara Art. Original", LegajoLogueado)

        lblArtOriginal.Text = "ARTICULO ORIGINAL"
        lblArtOriginal.ForeColor = Color.Green
        btnPonerOriginal.Enabled = False
    End Sub

    Private Sub chkArtConProgramaTerminado_CheckedChanged(sender As Object, e As EventArgs) Handles chkArtConProgramaTerminado.CheckedChanged
        Dim Command As New SqlCommand
        Dim sStr As String
        If Not EstoyCargando Then

            If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

            If chkArtConProgramaTerminado.Checked Then
                ElArticuloTieneProgramaTerminado = 1
                sStr = "UPDATE PrendasArtProdPlanillas SET TieneProgramaTerminado = 1 WHERE id = " + ID.ToString
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()

                RegistroEnHistorial("P", ID.ToString, "Declara Programa Terminado", LegajoLogueado)
            Else
                ElArticuloTieneProgramaTerminado = 0
                sStr = "UPDATE PrendasArtProdPlanillas SET TieneProgramaTerminado = 0 WHERE id = " + ID.ToString
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()

                RegistroEnHistorial("P", ID.ToString, "Declara Programa NO terminado", LegajoLogueado)
            End If

        End If
    End Sub

    Private Sub btnCuerpoMasUno_Click(sender As Object, e As EventArgs) Handles btnCuerpoMasUno.Click
        If IsNumeric(txtTalleXXL_D.Text) Then txtTalleXXL_D.Text = CInt(txtTalleXXL_D.Text) + 1
        If IsNumeric(txtTalleXL_D.Text) Then txtTalleXL_D.Text = CInt(txtTalleXL_D.Text) + 1
        If IsNumeric(txtTalleL_D.Text) Then txtTalleL_D.Text = CInt(txtTalleL_D.Text) + 1
        If IsNumeric(txtTalleM_D.Text) Then txtTalleM_D.Text = CInt(txtTalleM_D.Text) + 1
        If IsNumeric(txtTalleS_D.Text) Then txtTalleS_D.Text = CInt(txtTalleS_D.Text) + 1
        If IsNumeric(txtTalleXS_D.Text) Then txtTalleXS_D.Text = CInt(txtTalleXS_D.Text) + 1
        If IsNumeric(txtTalleXXL_E.Text) Then txtTalleXXL_E.Text = CInt(txtTalleXXL_E.Text) + 1
        If IsNumeric(txtTalleXL_E.Text) Then txtTalleXL_E.Text = CInt(txtTalleXL_E.Text) + 1
        If IsNumeric(txtTalleL_E.Text) Then txtTalleL_E.Text = CInt(txtTalleL_E.Text) + 1
        If IsNumeric(txtTalleM_E.Text) Then txtTalleM_E.Text = CInt(txtTalleM_E.Text) + 1
        If IsNumeric(txtTalleS_E.Text) Then txtTalleS_E.Text = CInt(txtTalleS_E.Text) + 1
        If IsNumeric(txtTalleXS_E.Text) Then txtTalleXS_E.Text = CInt(txtTalleXS_E.Text) + 1
    End Sub

    Private Sub btnCuerpoMenosUno_Click(sender As Object, e As EventArgs) Handles btnCuerpoMenosUno.Click
        If IsNumeric(txtTalleXXL_D.Text) Then txtTalleXXL_D.Text = CInt(txtTalleXXL_D.Text) - 1
        If IsNumeric(txtTalleXL_D.Text) Then txtTalleXL_D.Text = CInt(txtTalleXL_D.Text) - 1
        If IsNumeric(txtTalleL_D.Text) Then txtTalleL_D.Text = CInt(txtTalleL_D.Text) - 1
        If IsNumeric(txtTalleM_D.Text) Then txtTalleM_D.Text = CInt(txtTalleM_D.Text) - 1
        If IsNumeric(txtTalleS_D.Text) Then txtTalleS_D.Text = CInt(txtTalleS_D.Text) - 1
        If IsNumeric(txtTalleXS_D.Text) Then txtTalleXS_D.Text = CInt(txtTalleXS_D.Text) - 1
        If IsNumeric(txtTalleXXL_E.Text) Then txtTalleXXL_E.Text = CInt(txtTalleXXL_E.Text) - 1
        If IsNumeric(txtTalleXL_E.Text) Then txtTalleXL_E.Text = CInt(txtTalleXL_E.Text) - 1
        If IsNumeric(txtTalleL_E.Text) Then txtTalleL_E.Text = CInt(txtTalleL_E.Text) - 1
        If IsNumeric(txtTalleM_E.Text) Then txtTalleM_E.Text = CInt(txtTalleM_E.Text) - 1
        If IsNumeric(txtTalleS_E.Text) Then txtTalleS_E.Text = CInt(txtTalleS_E.Text) - 1
        If IsNumeric(txtTalleXS_E.Text) Then txtTalleXS_E.Text = CInt(txtTalleXS_E.Text) - 1
    End Sub

    Private Sub btnMangaMasUno_Click(sender As Object, e As EventArgs) Handles btnMangaMasUno.Click
        If IsNumeric(txtTalleXXL_Manga.Text) Then txtTalleXXL_Manga.Text = CInt(txtTalleXXL_Manga.Text) + 1
        If IsNumeric(txtTalleXL_Manga.Text) Then txtTalleXL_Manga.Text = CInt(txtTalleXL_Manga.Text) + 1
        If IsNumeric(txtTalleL_Manga.Text) Then txtTalleL_Manga.Text = CInt(txtTalleL_Manga.Text) + 1
        If IsNumeric(txtTalleM_Manga.Text) Then txtTalleM_Manga.Text = CInt(txtTalleM_Manga.Text) + 1
        If IsNumeric(txtTalleS_Manga.Text) Then txtTalleS_Manga.Text = CInt(txtTalleS_Manga.Text) + 1
        If IsNumeric(txtTalleXS_Manga.Text) Then txtTalleXS_Manga.Text = CInt(txtTalleXS_Manga.Text) + 1
    End Sub

    Private Sub btnMangaMenosUno_Click(sender As Object, e As EventArgs) Handles btnMangaMenosUno.Click
        If IsNumeric(txtTalleXXL_Manga.Text) Then txtTalleXXL_Manga.Text = CInt(txtTalleXXL_Manga.Text) - 1
        If IsNumeric(txtTalleXL_Manga.Text) Then txtTalleXL_Manga.Text = CInt(txtTalleXL_Manga.Text) - 1
        If IsNumeric(txtTalleL_Manga.Text) Then txtTalleL_Manga.Text = CInt(txtTalleL_Manga.Text) - 1
        If IsNumeric(txtTalleM_Manga.Text) Then txtTalleM_Manga.Text = CInt(txtTalleM_Manga.Text) - 1
        If IsNumeric(txtTalleS_Manga.Text) Then txtTalleS_Manga.Text = CInt(txtTalleS_Manga.Text) - 1
        If IsNumeric(txtTalleXS_Manga.Text) Then txtTalleXS_Manga.Text = CInt(txtTalleXS_Manga.Text) - 1
    End Sub

    '##########################################################################################################################################################
    '##########################################################################################################################################################
    '##########################################################################################################################################################
    '##########################################################################################################################################################

    Private Sub cmdImprimirPlanObserv_Click(sender As Object, e As EventArgs) Handles cmdImprimirPlanObserv.Click
        If ID <= 0 Then
            'SOLO SE PUEDEN IMPRIMIR LAS PLANILLAS QUE YA ESTAN DADAS DE ALTA
            Exit Sub
        End If


        pdoImpPlanillaObserv.DefaultPageSettings.Landscape = False
        pdoImpPlanillaObserv.DefaultPageSettings.Margins.Left = 20
        pdoImpPlanillaObserv.DefaultPageSettings.Margins.Right = 20
        pdoImpPlanillaObserv.DefaultPageSettings.Margins.Top = 20
        pdoImpPlanillaObserv.DefaultPageSettings.Margins.Bottom = 20
        pdoImpPlanillaObserv.OriginAtMargins = True ' takes margins into account 

        'Dim dlgPrintPreview As New EnhancedPrintPreviewDialog
        'dlgPrintPreview.ClientSize = New System.Drawing.Size(600, 600)
        'dlgPrintPreview.Document = pdoImpPlanillaObserv ' Previews print
        'dlgPrintPreview.ShowDialog()

        pdoImpPlanillaObserv.Print()

    End Sub

    Private Sub pdoImpPlanillaObserv_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdoImpPlanillaObserv.PrintPage
        On Error Resume Next

        Dim LapizMarcador As New Pen(Brushes.Black)

        Dim FuenteLineas As Font = New Drawing.Font("Arial", 10, FontStyle.Regular)
        Dim FuenteLineasN As Font = New Drawing.Font("Arial", 10, FontStyle.Bold)
        Dim FuenteLineas9 As Font = New Drawing.Font("Arial", 9, FontStyle.Regular)
        Dim FuenteLineas9N As Font = New Drawing.Font("Arial", 9, FontStyle.Bold)
        Dim FuenteLineas8 As Font = New Drawing.Font("Arial", 8, FontStyle.Regular)
        Dim FuenteLineas8N As Font = New Drawing.Font("Arial", 8, FontStyle.Bold)
        Dim FuenteLineas7 As Font = New Drawing.Font("Arial", 7, FontStyle.Regular)
        Dim FuenteLineas7N As Font = New Drawing.Font("Arial", 7, FontStyle.Bold)

        Dim LineasdeCorreciones, nTopPicos, nTopMallas, nTopCorr, nRowPos, UltimaFiladeCorreccionConDato As Integer
        Dim nTop As Int16 = e.MarginBounds.Top
        Dim AltoRenglon As Integer = 16

        If TipoPlanilla = "STOLL" Then

        Else

        End If

        ' Draw Header
        e.Graphics.DrawString(lblTitulo.Text, FuenteLineas, Brushes.Black, 150, nTop)
        e.Graphics.DrawString(cmbCategoria.Text, FuenteLineas, Brushes.Black, 600, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 750, AltoRenglon)
        nTop = nTop + AltoRenglon

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(20, nTop, 80, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 80, AltoRenglon)
        e.Graphics.DrawString("FECHA", FuenteLineas, Brushes.Black, 35, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(100, nTop, 70, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 70, AltoRenglon)
        e.Graphics.DrawString("DISEÑO", FuenteLineas, Brushes.Black, 105, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(170, nTop, 150, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 170, nTop, 150, AltoRenglon)
        e.Graphics.DrawString("COLOR", FuenteLineas, Brushes.Black, 210, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(320, nTop, 70, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 320, nTop, 70, AltoRenglon)
        e.Graphics.DrawString("PARTIDA", FuenteLineas, Brushes.Black, 325, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(390, nTop, 50, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 390, nTop, 50, AltoRenglon)
        e.Graphics.DrawString("V DEL", FuenteLineas, Brushes.Black, 395, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(440, nTop, 50, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 440, nTop, 50, AltoRenglon)
        e.Graphics.DrawString("V ESP", FuenteLineas, Brushes.Black, 445, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(490, nTop, 50, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 490, nTop, 50, AltoRenglon)
        e.Graphics.DrawString("V MAN", FuenteLineas, Brushes.Black, 492, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(540, nTop, 60, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 540, nTop, 60, AltoRenglon)
        e.Graphics.DrawString("V CAP", FuenteLineas, Brushes.Black, 545, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(600, nTop, 70, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 600, nTop, 70, AltoRenglon)
        e.Graphics.DrawString("OP", FuenteLineas, Brushes.Black, 615, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(670, nTop, 100, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 670, nTop, 100, AltoRenglon)
        e.Graphics.DrawString("ARTÍCULO", FuenteLineas, Brushes.Black, 680, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 80, AltoRenglon)
        e.Graphics.DrawString(Format(dtpFecha.Value, "dd/MM/yyyy"), FuenteLineas, Brushes.Black, 25, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 70, AltoRenglon)
        e.Graphics.DrawString(txtDiseño.Text, FuenteLineas, Brushes.Black, 105, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 170, nTop, 150, AltoRenglon)
        e.Graphics.DrawString(txtColor.Text, FuenteLineas, Brushes.Black, 173, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 320, nTop, 70, AltoRenglon)
        e.Graphics.DrawString(txtPartida.Text, FuenteLineas, Brushes.Black, 325, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 390, nTop, 50, AltoRenglon)
        e.Graphics.DrawString(txtVentDel.Text, FuenteLineas, Brushes.Black, 395, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 440, nTop, 50, AltoRenglon)
        e.Graphics.DrawString(txtVentEsp.Text, FuenteLineas, Brushes.Black, 445, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 490, nTop, 50, AltoRenglon)
        e.Graphics.DrawString(txtVentMan.Text, FuenteLineas, Brushes.Black, 495, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 540, nTop, 60, AltoRenglon)
        e.Graphics.DrawString(txtVentCap.Text, FuenteLineas, Brushes.Black, 545, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 600, nTop, 70, AltoRenglon)
        e.Graphics.DrawString(txtOp.Text, FuenteLineas, Brushes.Black, 600, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 670, nTop, 100, AltoRenglon)
        e.Graphics.DrawString(txtArticulo.Text, FuenteLineasN, Brushes.Black, 680, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 80, 144)
        e.Graphics.DrawString("Talle XXL", FuenteLineas9, Brushes.Black, 25, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 80, 144)
        e.Graphics.DrawString("Talle XL", FuenteLineas9, Brushes.Black, 105, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 180, nTop, 80, 144)
        e.Graphics.DrawString("Talle L", FuenteLineas9, Brushes.Black, 185, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 260, nTop, 80, 144)
        e.Graphics.DrawString("Talle M", FuenteLineas9, Brushes.Black, 265, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 340, nTop, 80, 144)
        e.Graphics.DrawString("Talle S", FuenteLineas9, Brushes.Black, 345, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 420, nTop, 80, 144)
        e.Graphics.DrawString("Talle XS", FuenteLineas9, Brushes.Black, 425, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 25, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(40, nTop, 30, AltoRenglon))
        e.Graphics.DrawString(txtTalleXXL_D.Text, FuenteLineas9N, Brushes.Black, 45, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 70, nTop)

        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 105, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(120, nTop, 30, AltoRenglon))
        e.Graphics.DrawString(txtTalleXL_D.Text, FuenteLineas9N, Brushes.Black, 125, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 150, nTop)

        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 185, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(200, nTop, 30, AltoRenglon))
        e.Graphics.DrawString(txtTalleL_D.Text, FuenteLineas9N, Brushes.Black, 205, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 230, nTop)

        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 265, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(280, nTop, 30, AltoRenglon))
        e.Graphics.DrawString(txtTalleM_D.Text, FuenteLineas9N, Brushes.Black, 285, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 310, nTop)

        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 345, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(360, nTop, 30, AltoRenglon))
        e.Graphics.DrawString(txtTalleS_D.Text, FuenteLineas9N, Brushes.Black, 365, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 390, nTop)

        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 425, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(440, nTop, 30, AltoRenglon))
        e.Graphics.DrawString(txtTalleXS_D.Text, FuenteLineas9N, Brushes.Black, 445, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 470, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 25, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(40, nTop, 30, AltoRenglon))
        e.Graphics.DrawString(txtTalleXXL_E.Text, FuenteLineas9N, Brushes.Black, 45, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 70, nTop)

        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 105, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(120, nTop, 30, AltoRenglon))
        e.Graphics.DrawString(txtTalleXL_E.Text, FuenteLineas9N, Brushes.Black, 125, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 150, nTop)

        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 185, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(200, nTop, 30, AltoRenglon))
        e.Graphics.DrawString(txtTalleL_E.Text, FuenteLineas9N, Brushes.Black, 205, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 230, nTop)

        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 265, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(280, nTop, 30, AltoRenglon))
        e.Graphics.DrawString(txtTalleM_E.Text, FuenteLineas9N, Brushes.Black, 285, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 310, nTop)

        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 345, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(360, nTop, 30, AltoRenglon))
        e.Graphics.DrawString(txtTalleS_E.Text, FuenteLineas9N, Brushes.Black, 365, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 390, nTop)

        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 425, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(440, nTop, 30, AltoRenglon))
        e.Graphics.DrawString(txtTalleXS_E.Text, FuenteLineas9N, Brushes.Black, 445, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 470, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawString(txtTalleXXLBretel_Tit.Text, FuenteLineas8, Brushes.Black, 25, nTop)
        e.Graphics.DrawString(txtTalleXXLBretel.Text, FuenteLineas9, Brushes.Black, 75, nTop)

        e.Graphics.DrawString(txtTalleXLBretel_Tit.Text, FuenteLineas8, Brushes.Black, 105, nTop)
        e.Graphics.DrawString(txtTalleXLBretel.Text, FuenteLineas9, Brushes.Black, 155, nTop)

        e.Graphics.DrawString(txtTalleLBretel_Tit.Text, FuenteLineas8, Brushes.Black, 185, nTop)
        e.Graphics.DrawString(txtTalleLBretel.Text, FuenteLineas9, Brushes.Black, 235, nTop)

        e.Graphics.DrawString(txtTalleMBretel_Tit.Text, FuenteLineas8, Brushes.Black, 265, nTop)
        e.Graphics.DrawString(txtTalleMBretel.Text, FuenteLineas9, Brushes.Black, 315, nTop)

        e.Graphics.DrawString(txtTalleSBretel_Tit.Text, FuenteLineas8, Brushes.Black, 345, nTop)
        e.Graphics.DrawString(txtTalleSBretel.Text, FuenteLineas9, Brushes.Black, 395, nTop)

        e.Graphics.DrawString(txtTalleXSBretel_Tit.Text, FuenteLineas8, Brushes.Black, 425, nTop)
        e.Graphics.DrawString(txtTalleXSBretel.Text, FuenteLineas9, Brushes.Black, 475, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawString(txtTalleXXLEsc_Tit.Text, FuenteLineas9, Brushes.Black, 25, nTop)
        e.Graphics.DrawString(txtTalleXXLEsc.Text, FuenteLineas9, Brushes.Black, 75, nTop)

        e.Graphics.DrawString(txtTalleXLEsc_Tit.Text, FuenteLineas9, Brushes.Black, 105, nTop)
        e.Graphics.DrawString(txtTalleXLEsc.Text, FuenteLineas9, Brushes.Black, 155, nTop)

        e.Graphics.DrawString(txtTalleLEsc_Tit.Text, FuenteLineas9, Brushes.Black, 185, nTop)
        e.Graphics.DrawString(txtTalleLEsc.Text, FuenteLineas9, Brushes.Black, 235, nTop)

        e.Graphics.DrawString(txtTalleMEsc_Tit.Text, FuenteLineas9, Brushes.Black, 265, nTop)
        e.Graphics.DrawString(txtTalleMEsc.Text, FuenteLineas9, Brushes.Black, 315, nTop)

        e.Graphics.DrawString(txtTalleSEsc_Tit.Text, FuenteLineas9, Brushes.Black, 345, nTop)
        e.Graphics.DrawString(txtTalleSEsc.Text, FuenteLineas9, Brushes.Black, 395, nTop)

        e.Graphics.DrawString(txtTalleXSEsc_Tit.Text, FuenteLineas9, Brushes.Black, 425, nTop)
        e.Graphics.DrawString(txtTalleXSEsc.Text, FuenteLineas9, Brushes.Black, 475, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawString(txtTalleXXLBolsillo_Tit.Text, FuenteLineas9, Brushes.Black, 25, nTop)
        e.Graphics.DrawString(txtTalleXXLBolsillo.Text, FuenteLineas9, Brushes.Black, 75, nTop)

        e.Graphics.DrawString(txtTalleXLBolsillo_Tit.Text, FuenteLineas9, Brushes.Black, 105, nTop)
        e.Graphics.DrawString(txtTalleXLBolsillo.Text, FuenteLineas9, Brushes.Black, 155, nTop)

        e.Graphics.DrawString(txtTalleLBolsillo_Tit.Text, FuenteLineas9, Brushes.Black, 185, nTop)
        e.Graphics.DrawString(txtTalleLBolsillo.Text, FuenteLineas9, Brushes.Black, 235, nTop)

        e.Graphics.DrawString(txtTalleMBolsillo_Tit.Text, FuenteLineas9, Brushes.Black, 265, nTop)
        e.Graphics.DrawString(txtTalleMBolsillo.Text, FuenteLineas9, Brushes.Black, 315, nTop)

        e.Graphics.DrawString(txtTalleSBolsillo_Tit.Text, FuenteLineas9, Brushes.Black, 345, nTop)
        e.Graphics.DrawString(txtTalleSBolsillo.Text, FuenteLineas9, Brushes.Black, 395, nTop)

        e.Graphics.DrawString(txtTalleXSBolsillo_Tit.Text, FuenteLineas9, Brushes.Black, 425, nTop)
        e.Graphics.DrawString(txtTalleXSBolsillo.Text, FuenteLineas9, Brushes.Black, 475, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawString(txtTalleXXLAncho_Tit.Text, FuenteLineas9, Brushes.Black, 25, nTop)
        e.Graphics.DrawString(txtTalleXXLAncho.Text, FuenteLineas9, Brushes.Black, 75, nTop)

        e.Graphics.DrawString(txtTalleXLAncho_Tit.Text, FuenteLineas9, Brushes.Black, 105, nTop)
        e.Graphics.DrawString(txtTalleXLAncho.Text, FuenteLineas9, Brushes.Black, 155, nTop)

        e.Graphics.DrawString(txtTalleLAncho_Tit.Text, FuenteLineas9, Brushes.Black, 185, nTop)
        e.Graphics.DrawString(txtTalleLAncho.Text, FuenteLineas9, Brushes.Black, 235, nTop)

        e.Graphics.DrawString(txtTalleMAncho_Tit.Text, FuenteLineas9, Brushes.Black, 265, nTop)
        e.Graphics.DrawString(txtTalleMAncho.Text, FuenteLineas9, Brushes.Black, 315, nTop)

        e.Graphics.DrawString(txtTalleSAncho_Tit.Text, FuenteLineas9, Brushes.Black, 345, nTop)
        e.Graphics.DrawString(txtTalleSAncho.Text, FuenteLineas9, Brushes.Black, 395, nTop)

        e.Graphics.DrawString(txtTalleXSAncho_Tit.Text, FuenteLineas9, Brushes.Black, 425, nTop)
        e.Graphics.DrawString(txtTalleXSAncho.Text, FuenteLineas9, Brushes.Black, 475, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawString(txtTalleXXLLargo_Tit.Text, FuenteLineas9, Brushes.Black, 25, nTop)
        e.Graphics.DrawString(txtTalleXXLLargo.Text, FuenteLineas9, Brushes.Black, 75, nTop)

        e.Graphics.DrawString(txtTalleXLLargo_Tit.Text, FuenteLineas9, Brushes.Black, 105, nTop)
        e.Graphics.DrawString(txtTalleXLLargo.Text, FuenteLineas9, Brushes.Black, 155, nTop)

        e.Graphics.DrawString(txtTalleLLargo_Tit.Text, FuenteLineas9, Brushes.Black, 185, nTop)
        e.Graphics.DrawString(txtTalleLLargo.Text, FuenteLineas9, Brushes.Black, 235, nTop)

        e.Graphics.DrawString(txtTalleMLargo_Tit.Text, FuenteLineas9, Brushes.Black, 265, nTop)
        e.Graphics.DrawString(txtTalleMLargo.Text, FuenteLineas9, Brushes.Black, 315, nTop)

        e.Graphics.DrawString(txtTalleSLargo_Tit.Text, FuenteLineas9, Brushes.Black, 345, nTop)
        e.Graphics.DrawString(txtTalleSLargo.Text, FuenteLineas9, Brushes.Black, 395, nTop)

        e.Graphics.DrawString(txtTalleXSLargo_Tit.Text, FuenteLineas9, Brushes.Black, 425, nTop)
        e.Graphics.DrawString(txtTalleXSLargo.Text, FuenteLineas9, Brushes.Black, 475, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawString(txtTalleXXL_CuerParamInicio.Text, FuenteLineasN, Brushes.Black, 25, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 50, nTop, 2, AltoRenglon)
        e.Graphics.DrawString(txtTalleXXL_CuerCantAgujas.Text, FuenteLineasN, Brushes.Black, 60, nTop)

        e.Graphics.DrawString(txtTalleXL_CuerParamInicio.Text, FuenteLineasN, Brushes.Black, 105, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 130, nTop, 2, AltoRenglon)
        e.Graphics.DrawString(txtTalleXL_CuerCantAgujas.Text, FuenteLineasN, Brushes.Black, 140, nTop)

        e.Graphics.DrawString(txtTalleL_CuerParamInicio.Text, FuenteLineasN, Brushes.Black, 185, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 210, nTop, 2, AltoRenglon)
        e.Graphics.DrawString(txtTalleL_CuerCantAgujas.Text, FuenteLineasN, Brushes.Black, 220, nTop)

        e.Graphics.DrawString(txtTalleM_CuerParamInicio.Text, FuenteLineasN, Brushes.Black, 265, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 290, nTop, 2, AltoRenglon)
        e.Graphics.DrawString(txtTalleM_CuerCantAgujas.Text, FuenteLineasN, Brushes.Black, 300, nTop)

        e.Graphics.DrawString(txtTalleS_CuerParamInicio.Text, FuenteLineasN, Brushes.Black, 345, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 370, nTop, 2, AltoRenglon)
        e.Graphics.DrawString(txtTalleS_CuerCantAgujas.Text, FuenteLineasN, Brushes.Black, 380, nTop)

        e.Graphics.DrawString(txtTalleXS_CuerParamInicio.Text, FuenteLineasN, Brushes.Black, 425, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 450, nTop, 2, AltoRenglon)
        e.Graphics.DrawString(txtTalleXS_CuerCantAgujas.Text, FuenteLineasN, Brushes.Black, 460, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 480, AltoRenglon)
        e.Graphics.DrawString("MEDIDA ELÁSTICO=", FuenteLineas9, Brushes.Black, 25, nTop)
        e.Graphics.DrawString(txtMedidaElastico.Text, FuenteLineas9, Brushes.Black, 160, nTop)
        e.Graphics.DrawString("CONDICIÓN CUERPOS=", FuenteLineas9, Brushes.Black, 250, nTop)
        e.Graphics.DrawString(txtCondicionCuerpos.Text, FuenteLineas9, Brushes.Black, 400, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 480, AltoRenglon)
        e.Graphics.DrawString("VELOCIDAD CUERPOS=", FuenteLineas9, Brushes.Black, 25, nTop)
        e.Graphics.DrawString(txtVelocidadCuerpos.Text, FuenteLineas9, Brushes.Black, 180, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 80, 48)
        e.Graphics.DrawString("MANGA", FuenteLineas9, Brushes.Black, 35, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 80, 48)
        e.Graphics.DrawString("MANGA", FuenteLineas9, Brushes.Black, 115, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 180, nTop, 80, 48)
        e.Graphics.DrawString("MANGA", FuenteLineas9, Brushes.Black, 195, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 260, nTop, 80, 48)
        e.Graphics.DrawString("MANGA", FuenteLineas9, Brushes.Black, 275, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 340, nTop, 80, 48)
        e.Graphics.DrawString("MANGA", FuenteLineas9, Brushes.Black, 355, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 420, nTop, 80, 48)
        e.Graphics.DrawString("MANGA", FuenteLineas9, Brushes.Black, 435, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(25, nTop, 45, AltoRenglon))
        e.Graphics.DrawString(txtTalleXXL_Manga.Text, FuenteLineas9N, Brushes.Black, 40, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 70, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(105, nTop, 45, AltoRenglon))
        e.Graphics.DrawString(txtTalleXL_Manga.Text, FuenteLineas9N, Brushes.Black, 120, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 150, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(185, nTop, 45, AltoRenglon))
        e.Graphics.DrawString(txtTalleL_Manga.Text, FuenteLineas9N, Brushes.Black, 200, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 230, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(265, nTop, 45, AltoRenglon))
        e.Graphics.DrawString(txtTalleM_Manga.Text, FuenteLineas9N, Brushes.Black, 280, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 310, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(345, nTop, 45, AltoRenglon))
        e.Graphics.DrawString(txtTalleS_Manga.Text, FuenteLineas9N, Brushes.Black, 360, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 390, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(425, nTop, 45, AltoRenglon))
        e.Graphics.DrawString(txtTalleXS_Manga.Text, FuenteLineas9N, Brushes.Black, 440, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 470, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawString(txtTalleXXL_MangaParamInicio.Text, FuenteLineasN, Brushes.Black, 25, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 50, nTop, 2, AltoRenglon)
        e.Graphics.DrawString(txtTalleXXL_MangaCantAgujas.Text, FuenteLineasN, Brushes.Black, 60, nTop)

        e.Graphics.DrawString(txtTalleXL_MangaParamInicio.Text, FuenteLineasN, Brushes.Black, 105, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 130, nTop, 2, AltoRenglon)
        e.Graphics.DrawString(txtTalleXL_MangaCantAgujas.Text, FuenteLineasN, Brushes.Black, 140, nTop)

        e.Graphics.DrawString(txtTalleL_MangaParamInicio.Text, FuenteLineasN, Brushes.Black, 185, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 210, nTop, 2, AltoRenglon)
        e.Graphics.DrawString(txtTalleL_MangaCantAgujas.Text, FuenteLineasN, Brushes.Black, 220, nTop)

        e.Graphics.DrawString(txtTalleM_MangaParamInicio.Text, FuenteLineasN, Brushes.Black, 265, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 290, nTop, 2, AltoRenglon)
        e.Graphics.DrawString(txtTalleM_MangaCantAgujas.Text, FuenteLineasN, Brushes.Black, 300, nTop)

        e.Graphics.DrawString(txtTalleS_MangaParamInicio.Text, FuenteLineasN, Brushes.Black, 345, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 370, nTop, 2, AltoRenglon)
        e.Graphics.DrawString(txtTalleS_MangaCantAgujas.Text, FuenteLineasN, Brushes.Black, 380, nTop)

        e.Graphics.DrawString(txtTalleXS_MangaParamInicio.Text, FuenteLineasN, Brushes.Black, 425, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 450, nTop, 2, AltoRenglon)
        e.Graphics.DrawString(txtTalleXS_MangaCantAgujas.Text, FuenteLineasN, Brushes.Black, 460, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 480, AltoRenglon)
        e.Graphics.DrawString("MEDIDA PUÑO=", FuenteLineas9, Brushes.Black, 25, nTop)
        e.Graphics.DrawString(txtMedidaPuño.Text, FuenteLineas9, Brushes.Black, 150, nTop)
        e.Graphics.DrawString("CONDICIÓN MANGAS=", FuenteLineas9, Brushes.Black, 250, nTop)
        e.Graphics.DrawString(txtCondicionMangas.Text, FuenteLineas9, Brushes.Black, 400, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 480, AltoRenglon)
        e.Graphics.DrawString("VELOCIDAD MANGAS=", FuenteLineas9, Brushes.Black, 25, nTop)
        e.Graphics.DrawString(txtVelocidadMangas.Text, FuenteLineas9, Brushes.Black, 180, nTop)


        'el lugar para las observaciones
        nTop = nTop + AltoRenglon
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(20, nTop, 750, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 750, AltoRenglon)
        e.Graphics.DrawString("OBSERVACIONES", FuenteLineas, Brushes.Black, 330, nTop)

        For i = 0 To 45
            nTop = nTop + AltoRenglon
            e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 750, AltoRenglon)
        Next

        'LUEGO EL PIE DE PAGINA
        DrawFooterPlanObs(e)

    End Sub

    Public Sub DrawFooterPlanObs(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim FuenteLineas8 As Font = New Drawing.Font("Arial", 8, FontStyle.Regular)

        e.Graphics.DrawLine(Pens.Black, 20, e.MarginBounds.Height - 17, 790, e.MarginBounds.Height - 17)

        ' Right Align - User Name
        e.Graphics.DrawString("Impreso Por: " + DescripcionLegajo(LegajoLogueado), FuenteLineas8, Brushes.Black, 790 - e.Graphics.MeasureString("Impreso Por: " + DescripcionLegajo(LegajoLogueado), FuenteLineas8, e.MarginBounds.Width).Width, e.MarginBounds.Height - 15)

        ' Center - Page No. Info
        e.Graphics.DrawString(Format(Now, "dd/MM/yyyy HH:mm:ss"), FuenteLineas8, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(Format(Now, "dd/MM/yyyy HH:mm:ss"), FuenteLineas8, e.MarginBounds.Width).Width) / 2, e.MarginBounds.Height - 15)

        e.Graphics.DrawLine(Pens.Black, 20, e.MarginBounds.Height, 790, e.MarginBounds.Height)

    End Sub

    Private Sub btnAbrirArch_Click(sender As Object, e As EventArgs) Handles btnAbrirRutaImagen.Click
        'Dim Direcci, Observa As String
        'RecuperarDatosWebPedido("MAYORISTA", "500740", Direcci, Observa)
        'MensajeAtencion(Direcci)
        AbrirArchivoNombreFan()
    End Sub

    Private Sub AbrirArchivoNombreFan()
        ofdArchivo.Multiselect = False
        ofdArchivo.Filter = "Archivos jpg|*.jpg|Todos los Archivos|*.*"
        If Directory.Exists("\\server01\E\Diseño\ARTICULOS Y MATRICES\PLANO DE MEDIDAS") Then
            ofdArchivo.InitialDirectory = "\\server01\E\Diseño\ARTICULOS Y MATRICES\PLANO DE MEDIDAS"
        End If
        'ofdArchivo.Filter = "Todos los archivo (*.*) |*.*"
        ofdArchivo.FileName = "*.jpg"
        ofdArchivo.Title = "Seleccione el archivo"
        If ofdArchivo.ShowDialog() = DialogResult.OK Then
            txtRutaImagen.Text = ofdArchivo.FileName.ToString
        Else
            Exit Sub
        End If
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If btn_izqder.Text = "<<" Then
            Panel2.Left = Panel2.Left - 55
            If Panel2.Left < 300 Then
                btn_izqder.Text = ">>"
                Timer1.Enabled = False
            End If
        Else
            Panel2.Left = Panel2.Left + 55
            If Panel2.Left > 1000 Then
                btn_izqder.Text = "<<"
                Timer1.Enabled = False
            End If
        End If
    End Sub

    Private Sub btn_izqder_Click(sender As Object, e As EventArgs) Handles btn_izqder.Click
        Timer1.Enabled = True
    End Sub

    Private Sub CargarFoto(ByVal RutaImg As String)

        If File.Exists(RutaImg) Then
            picFoto.Load(RutaImg)
        Else
            picFoto.Image = Nothing
        End If
        picFoto.Refresh()

    End Sub

    Private Sub pdoImprimirPlanoMedidas_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdoImprimirPlanoMedidas.PrintPage
        On Error Resume Next

        Dim LapizMarcador As New Pen(Brushes.Black)

        Dim FuenteLineas As Font = New Drawing.Font("Arial", 10, FontStyle.Regular)
        Dim FuenteLineasN As Font = New Drawing.Font("Arial", 10, FontStyle.Bold)
        Dim FuenteLineas9 As Font = New Drawing.Font("Arial", 9, FontStyle.Regular)
        Dim FuenteLineas9N As Font = New Drawing.Font("Arial", 9, FontStyle.Bold)
        Dim FuenteLineas8 As Font = New Drawing.Font("Arial", 8, FontStyle.Regular)
        Dim FuenteLineas8N As Font = New Drawing.Font("Arial", 8, FontStyle.Bold)
        Dim FuenteLineas7 As Font = New Drawing.Font("Arial", 7, FontStyle.Regular)
        Dim FuenteLineas7N As Font = New Drawing.Font("Arial", 7, FontStyle.Bold)

        Dim LineasdeCorreciones, nTopPicos, nTopMallas, nTopCorr, nRowPos, UltimaFiladeCorreccionConDato As Integer
        Dim nTop As Int16 = e.MarginBounds.Top
        Dim AltoRenglon As Integer = 16

        ' Draw Header
        e.Graphics.DrawString(lblTitulo.Text, FuenteLineas, Brushes.Black, 100, nTop)
        e.Graphics.DrawString(cmbCategoria.Text, FuenteLineas, Brushes.Black, 520, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 750, AltoRenglon)
        nTop = nTop + AltoRenglon

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(20, nTop, 80, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 80, AltoRenglon)
        e.Graphics.DrawString("FECHA", FuenteLineas, Brushes.Black, 35, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(100, nTop, 70, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 70, AltoRenglon)
        e.Graphics.DrawString("DISEÑO", FuenteLineas, Brushes.Black, 105, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(170, nTop, 150, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 170, nTop, 150, AltoRenglon)
        e.Graphics.DrawString("COLOR", FuenteLineas, Brushes.Black, 210, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(320, nTop, 70, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 320, nTop, 70, AltoRenglon)
        e.Graphics.DrawString("PARTIDA", FuenteLineas, Brushes.Black, 325, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(390, nTop, 50, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 390, nTop, 50, AltoRenglon)
        e.Graphics.DrawString("V DEL", FuenteLineas, Brushes.Black, 395, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(440, nTop, 50, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 440, nTop, 50, AltoRenglon)
        e.Graphics.DrawString("V ESP", FuenteLineas, Brushes.Black, 445, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(490, nTop, 50, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 490, nTop, 50, AltoRenglon)
        e.Graphics.DrawString("V MAN", FuenteLineas, Brushes.Black, 492, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(540, nTop, 60, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 540, nTop, 60, AltoRenglon)
        e.Graphics.DrawString("V CAP", FuenteLineas, Brushes.Black, 545, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(600, nTop, 70, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 600, nTop, 70, AltoRenglon)
        e.Graphics.DrawString("OP", FuenteLineas, Brushes.Black, 615, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(670, nTop, 100, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 670, nTop, 100, AltoRenglon)
        e.Graphics.DrawString("ARTÍCULO", FuenteLineas, Brushes.Black, 680, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 80, AltoRenglon)
        e.Graphics.DrawString(Format(dtpFecha.Value, "dd/MM/yyyy"), FuenteLineas, Brushes.Black, 25, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 70, AltoRenglon)
        e.Graphics.DrawString(txtDiseño.Text, FuenteLineas, Brushes.Black, 105, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 170, nTop, 150, AltoRenglon)
        e.Graphics.DrawString(txtColor.Text, FuenteLineas, Brushes.Black, 173, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 320, nTop, 70, AltoRenglon)
        e.Graphics.DrawString(txtPartida.Text, FuenteLineas, Brushes.Black, 325, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 390, nTop, 50, AltoRenglon)
        e.Graphics.DrawString(txtVentDel.Text, FuenteLineas, Brushes.Black, 395, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 440, nTop, 50, AltoRenglon)
        e.Graphics.DrawString(txtVentEsp.Text, FuenteLineas, Brushes.Black, 445, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 490, nTop, 50, AltoRenglon)
        e.Graphics.DrawString(txtVentMan.Text, FuenteLineas, Brushes.Black, 495, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 540, nTop, 60, AltoRenglon)
        e.Graphics.DrawString(txtVentCap.Text, FuenteLineas, Brushes.Black, 545, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 600, nTop, 70, AltoRenglon)
        e.Graphics.DrawString(txtOp.Text, FuenteLineas, Brushes.Black, 600, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 670, nTop, 100, AltoRenglon)
        e.Graphics.DrawString(txtArticulo.Text, FuenteLineasN, Brushes.Black, 680, nTop)

        nTop = nTop + AltoRenglon



        'el lugar para las observaciones
        nTop = nTop + AltoRenglon

        e.Graphics.DrawImage(picFoto.Image, 5, nTop, 790, 600)


        'LUEGO EL PIE DE PAGINA
        DrawFooterPlanoMedidas(e)

    End Sub

    Public Sub DrawFooterPlanoMedidas(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim FuenteLineas8 As Font = New Drawing.Font("Arial", 8, FontStyle.Regular)

        e.Graphics.DrawLine(Pens.Black, 20, e.MarginBounds.Height - 17, 790, e.MarginBounds.Height - 17)

        ' Right Align - User Name
        e.Graphics.DrawString("Impreso Por: " + DescripcionLegajo(LegajoLogueado), FuenteLineas8, Brushes.Black, 790 - e.Graphics.MeasureString("Impreso Por: " + DescripcionLegajo(LegajoLogueado), FuenteLineas8, e.MarginBounds.Width).Width, e.MarginBounds.Height - 15)

        ' Center - Page No. Info
        e.Graphics.DrawString(Format(Now, "dd/MM/yyyy HH:mm:ss"), FuenteLineas8, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(Format(Now, "dd/MM/yyyy HH:mm:ss"), FuenteLineas8, e.MarginBounds.Width).Width) / 2, e.MarginBounds.Height - 15)

        e.Graphics.DrawLine(Pens.Black, 20, e.MarginBounds.Height, 790, e.MarginBounds.Height)

    End Sub

    Private Sub frmArtProdABM_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub
End Class