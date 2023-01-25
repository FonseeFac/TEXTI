Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.IO

Public Class frmRepoCostoArticulos_3
    Private Command, Command2, Command3 As New SqlCommand
    Private Reader, Reader2, Reader3 As SqlDataReader
    Dim sStr, sStr2, sStr3 As String

    Dim ValorHoraMO, PorPresentismo, PorCargasSociales, PorSAC, CantMaquinasPorTejedor As String
    Dim ParamCantPrendasTejidasMensual, ParamCantPrendasCortadasMensual As Long
    Dim CotizacionDolar As Double = 0.0

    Dim ColTipoHilado As New Collection

    Private Sub LimpiarDGV()
        dgvArticulos.Rows.Clear()
        dgvArticulos.Columns.Clear()

        dgvTareasArt.Rows.Clear()
        dgvTareasArt.Columns.Clear()

        dgvCostosRubros.Rows.Clear()
        dgvCostosRubros.Columns.Clear()
    End Sub

    Private Sub ArmarDGV()
        dgvArticulos.Columns.Add("TIPOARTICULO", "TIPOARTICULO")
        dgvArticulos.Columns("TIPOARTICULO").Visible = False
        dgvArticulos.Columns.Add("CODTIPOHILADO", "CODTIPOHILADO")
        dgvArticulos.Columns("CODTIPOHILADO").Visible = False
        dgvArticulos.Columns.Add("ARTHABILITADO", "ARTHABILITADO")
        dgvArticulos.Columns("ARTHABILITADO").Visible = False
        dgvArticulos.Columns.Add("DISEÑO", "DISEÑO")
        dgvArticulos.Columns("DISEÑO").Visible = False
        dgvArticulos.Columns.Add("CODTIPOGALGA", "CODTIPOGALGA")
        dgvArticulos.Columns("CODTIPOGALGA").Visible = False
        dgvArticulos.Columns.Add("ARTICULO", "ARTICULO")
        dgvArticulos.Columns("ARTICULO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvArticulos.Columns("ARTICULO").Width = 90
        dgvArticulos.Columns("ARTICULO").ReadOnly = True
        dgvArticulos.Columns.Add("PESO", "PESO Kg/P")
        dgvArticulos.Columns("PESO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvArticulos.Columns("PESO").Width = 80
        dgvArticulos.Columns("PESO").ReadOnly = True
        dgvArticulos.Columns.Add("COSTOARMADO", "COSTO ARMADO ($/P)")
        dgvArticulos.Columns("COSTOARMADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvArticulos.Columns("COSTOARMADO").Width = 80
        dgvArticulos.Columns("COSTOARMADO").Visible = False
        dgvArticulos.Columns.Add("COSTOARMADOMASCARGASSOCIALES", "Costo Armado + Cs Sociales")
        dgvArticulos.Columns("COSTOARMADOMASCARGASSOCIALES").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvArticulos.Columns("COSTOARMADOMASCARGASSOCIALES").Width = 80
        dgvArticulos.Columns("COSTOARMADOMASCARGASSOCIALES").ReadOnly = True
        dgvArticulos.Columns.Add("COSTOMO", "Costo MO ($/P)")
        dgvArticulos.Columns("COSTOMO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvArticulos.Columns("COSTOMO").Width = 80
        dgvArticulos.Columns("COSTOMO").ReadOnly = True
        dgvArticulos.Columns("COSTOMO").Visible = False
        dgvArticulos.Columns.Add("COSTOMOMASCARGASSOCIALES", "Costo MO + Cs Sociales")
        dgvArticulos.Columns("COSTOMOMASCARGASSOCIALES").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvArticulos.Columns("COSTOMOMASCARGASSOCIALES").Width = 90
        dgvArticulos.Columns("COSTOMOMASCARGASSOCIALES").ReadOnly = True
        dgvArticulos.Columns.Add("COSTOHILADO", "Costo Hilado ($/P)")
        dgvArticulos.Columns("COSTOHILADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvArticulos.Columns("COSTOHILADO").Width = 80
        dgvArticulos.Columns("COSTOHILADO").ReadOnly = True
        dgvArticulos.Columns.Add("COSTOTEÑIDO", "Costo Teñido ($/P)")
        dgvArticulos.Columns("COSTOTEÑIDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvArticulos.Columns("COSTOTEÑIDO").Width = 80
        dgvArticulos.Columns("COSTOTEÑIDO").ReadOnly = True
        dgvArticulos.Columns.Add("MATERIALES", "Materiales")
        dgvArticulos.Columns("MATERIALES").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvArticulos.Columns("MATERIALES").Width = 80
        dgvArticulos.Columns("MATERIALES").ReadOnly = True
        dgvArticulos.Columns.Add("COSTOSINDIRECTOS", "Costos Indirectos")
        dgvArticulos.Columns("COSTOSINDIRECTOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvArticulos.Columns("COSTOSINDIRECTOS").Width = 80
        dgvArticulos.Columns("COSTOSINDIRECTOS").ReadOnly = True
        dgvArticulos.Columns.Add("COSTOTOTAL", "Costo Total ($/P)")
        dgvArticulos.Columns("COSTOTOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvArticulos.Columns("COSTOTOTAL").Width = 80
        dgvArticulos.Columns("COSTOTOTAL").ReadOnly = True
        dgvArticulos.Columns.Add("PRECIOVENTA", "Precio Venta ($)")
        dgvArticulos.Columns("PRECIOVENTA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvArticulos.Columns("PRECIOVENTA").Width = 85
        dgvArticulos.Columns("PRECIOVENTA").ReadOnly = True
        'columnas auxiliares para mostrar en la ventanita del calculo
        dgvArticulos.Columns.Add("CANTMAQPORTEJEDOR", "CANTMAQPORTEJEDOR")
        dgvArticulos.Columns("CANTMAQPORTEJEDOR").Visible = False
        dgvArticulos.Columns.Add("CANTROLLOSPORMAQ", "CANTROLLOSPORMAQ")
        dgvArticulos.Columns("CANTROLLOSPORMAQ").Visible = False
        dgvArticulos.Columns.Add("KILOSPORROLLO", "KILOSPORROLLO")
        dgvArticulos.Columns("KILOSPORROLLO").Visible = False
        dgvArticulos.Columns.Add("COSTOKILODEHILADO", "COSTOKILODEHILADO")
        dgvArticulos.Columns("COSTOKILODEHILADO").Visible = False
        dgvArticulos.Columns.Add("NROCELDA", "NROCELDA")
        dgvArticulos.Columns("NROCELDA").Visible = False
        dgvArticulos.Columns.Add("FECHAHASTACELDA", "FECHAHASTACELDA")
        dgvArticulos.Columns("FECHAHASTACELDA").Visible = False
        dgvArticulos.Columns.Add("CANTPERSCELDA", "CANTPERSCELDA")
        dgvArticulos.Columns("CANTPERSCELDA").Visible = False
        dgvArticulos.Columns.Add("COSTOTOTALCELDA", "COSTOTOTALCELDA")
        dgvArticulos.Columns("COSTOTOTALCELDA").Visible = False
        dgvArticulos.Columns.Add("MESCALCULOSTEJEDURIA", "MESCALCULOSTEJEDURIA")
        dgvArticulos.Columns("MESCALCULOSTEJEDURIA").Visible = False
        dgvArticulos.Columns.Add("SEMANASCONFIGTEJEDURIA", "SEMANASCONFIGTEJEDURIA")
        dgvArticulos.Columns("SEMANASCONFIGTEJEDURIA").Visible = False
        dgvArticulos.Columns.Add("MINUTOSDELARTICULO", "MINUTOSDELARTICULO")
        dgvArticulos.Columns("MINUTOSDELARTICULO").Visible = False
        dgvArticulos.Columns.Add("CANTMAQUINASTEJEDURIA", "CANTMAQUINASTEJEDURIA")
        dgvArticulos.Columns("CANTMAQUINASTEJEDURIA").Visible = False
        dgvArticulos.Columns.Add("CANTIDADPERSONASTEJEDURIA", "CANTIDADPERSONASTEJEDURIA")
        dgvArticulos.Columns("CANTIDADPERSONASTEJEDURIA").Visible = False
        dgvArticulos.Columns.Add("TOTALSUELDOSTEJEDURIA", "TOTALSUELDOSTEJEDURIA")
        dgvArticulos.Columns("TOTALSUELDOSTEJEDURIA").Visible = False
        dgvArticulos.Columns.Add("CANTIDADHORASDELMES", "CANTIDADHORASDELMES")
        dgvArticulos.Columns("CANTIDADHORASDELMES").Visible = False
        dgvArticulos.Columns.Add("CANTIDADBOTONES", "CANTIDADBOTONES")
        dgvArticulos.Columns("CANTIDADBOTONES").Visible = False
        dgvArticulos.Columns.Add("COSTO1BOTON", "COSTO1BOTON")
        dgvArticulos.Columns("COSTO1BOTON").Visible = False
        dgvArticulos.Columns.Add("CANTIDADCIERRES", "CANTIDADCIERRES")
        dgvArticulos.Columns("CANTIDADCIERRES").Visible = False
        dgvArticulos.Columns.Add("COSTO1CIERRE", "COSTO1CIERRE")
        dgvArticulos.Columns("COSTO1CIERRE").Visible = False

        dgvArticulos.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 10)
        dgvArticulos.DefaultCellStyle.Font = New Font("Tahoma", 10)
        dgvArticulos.RowTemplate.Height = 25

        dgvTareasArt.Columns.Add("ARTICULO", "ARTICULO")
        dgvTareasArt.Columns("ARTICULO").Visible = False
        dgvTareasArt.Columns.Add("TAREA", "TAREA")
        dgvTareasArt.Columns("TAREA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvTareasArt.Columns("TAREA").Width = 60
        dgvTareasArt.Columns("TAREA").ReadOnly = True
        dgvTareasArt.Columns.Add("SECTOR", "SECTOR")
        dgvTareasArt.Columns("SECTOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvTareasArt.Columns("SECTOR").Width = 60
        dgvTareasArt.Columns("SECTOR").ReadOnly = True
        dgvTareasArt.Columns.Add("PRECIO", "PRECIO")
        dgvTareasArt.Columns("PRECIO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvTareasArt.Columns("PRECIO").Width = 60
        dgvTareasArt.Columns("PRECIO").ReadOnly = True

        dgvCostosRubros.Columns.Add("AÑO", "AÑO")
        dgvCostosRubros.Columns("AÑO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvCostosRubros.Columns("AÑO").Width = 45
        dgvCostosRubros.Columns("AÑO").ReadOnly = True
        dgvCostosRubros.Columns.Add("MES", "MES")
        dgvCostosRubros.Columns("MES").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvCostosRubros.Columns("MES").Width = 45
        dgvCostosRubros.Columns("MES").ReadOnly = True
        dgvCostosRubros.Columns.Add("TOTAL", "TOTAL")
        dgvCostosRubros.Columns("TOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCostosRubros.Columns("TOTAL").Width = 85
        dgvCostosRubros.Columns("TOTAL").ReadOnly = True

    End Sub

    Private Sub AplicarFiltro()
        Dim CodArtDesde, CodArtHasta As Integer
        Dim i As Integer

        Dim FiltroArt, FiltroInhabilitado, FiltroTipoHilado, FiltroTipoGalga, FiltroDiseño As Boolean

        If txtCodArtDesde.Text <> "" Then
            CodArtDesde = CInt(txtCodArtDesde.Text)
        Else
            CodArtDesde = 0
        End If

        If txtCodArtHasta.Text <> "" Then
            CodArtHasta = CInt(txtCodArtHasta.Text)
        Else
            CodArtHasta = 999
        End If

        For i = 0 To dgvArticulos.RowCount - 1
            If CInt(dgvArticulos.Rows(i).Cells("ARTICULO").Value) >= CodArtDesde And CInt(dgvArticulos.Rows(i).Cells("ARTICULO").Value) <= CodArtHasta Then
                FiltroArt = True
            Else
                FiltroArt = False
            End If

            If chkVerInhabilitados.Checked = False Then
                If dgvArticulos.Rows(i).Cells("ARTHABILITADO").Value.ToString = "1" Then
                    FiltroInhabilitado = True
                Else
                    FiltroInhabilitado = False
                End If
            Else
                FiltroInhabilitado = True
            End If

            If cmbHilados.Text <> "TODOS" Then
                If dgvArticulos.Rows(i).Cells("CODTIPOHILADO").Value.ToString = ColTipoHilado(cmbHilados.Text).ToString() Then
                    FiltroTipoHilado = True
                Else
                    FiltroTipoHilado = False
                End If
            Else
                FiltroTipoHilado = True
            End If

            If cmbPROD.Text <> "TODOS" Then
                If cmbPROD.Text = "CORTE" Then
                    If cmbTipoLisoSublimado.Text = "TODOS" Then
                        FiltroDiseño = True
                        If dgvArticulos.Rows(i).Cells("CODTIPOGALGA").Value.ToString <> "C24" Then
                            FiltroTipoGalga = True
                        Else
                            FiltroTipoGalga = False
                        End If
                    ElseIf cmbTipoLisoSublimado.Text = "LISO" Then
                        If dgvArticulos.Rows(i).Cells("DISEÑO").Value.ToString = "----" And dgvArticulos.Rows(i).Cells("CODTIPOGALGA").Value.ToString = "C24" Then
                            FiltroTipoGalga = True
                            FiltroDiseño = True
                        Else
                            FiltroTipoGalga = False
                            FiltroDiseño = False
                        End If
                    ElseIf cmbTipoLisoSublimado.Text = "SUBLIMADO" Then
                        If dgvArticulos.Rows(i).Cells("DISEÑO").Value.ToString <> "----" And dgvArticulos.Rows(i).Cells("CODTIPOGALGA").Value.ToString = "C24" Then
                            FiltroTipoGalga = True
                            FiltroDiseño = True
                        Else
                            FiltroTipoGalga = False
                            FiltroDiseño = False
                        End If
                    End If
                Else
                    If dgvArticulos.Rows(i).Cells("DISEÑO").Value.ToString <> "----" Or dgvArticulos.Rows(i).Cells("CODTIPOGALGA").Value.ToString <> "C24" Then
                        FiltroTipoGalga = True
                        FiltroDiseño = True
                    Else
                        FiltroTipoGalga = False
                        FiltroDiseño = False
                    End If
                End If
            Else
                FiltroTipoGalga = True
                FiltroDiseño = True
            End If

            If FiltroArt And FiltroInhabilitado And FiltroTipoHilado And FiltroTipoGalga And FiltroDiseño Then
                dgvArticulos.Rows(i).Visible = True
            Else
                dgvArticulos.Rows(i).Visible = False
            End If

        Next

        'al final del filtro dejo preseleccionada la primer fila visible para que funcionen los botones de ver calculo y demases
        dgvArticulos.Select()
    End Sub

    Private Sub CalcularCostosyCargarListado(ByVal CargaInicial As Boolean)
        Dim CommandCel As New SqlCommand
        Dim ReaderCel As SqlDataReader
        Dim sStrCel As String

        Dim row As String()
        Dim TIPOARTICULO As String
        Dim ACUMPRECIO, COSTOARMADOMASCARGASSOCIALES, COSTOMO, COSTOMOMASCARGASSOCIALES, COSTOHILADO, MATERIALES, TEÑIDO, COSTOSINDIRECTOSPRENDATEJE, COSTOSINDIRECTOSPRENDACORTE, COSTOTOTAL As Double
        Dim CodTipoHilado, CantMaquinasPorTejedor, CantRollosPorMaquina, KilosPorRollo, CostoHiladoPorKilo As String
        Dim UltimoOrden, EsCosto As String
        Dim PrecioAux As Double
        Dim AuxCodArtParaBusqueda As String

        Dim MateCosto1Boton, MateCosto1Cierre As Double
        Dim MateCantidadBotones, MateCantidadCierres As Integer

        Dim CANTMAQUINASTEJEDURIA As Double = 119
        Dim TOTALSUELDOSTEJEDURIA As Double
        Dim CANTPERSONASTEJEDURIA As Double
        Dim CANTHORASMESTEJEDURIA As Double = 119

        Dim MAXIDTEJEDURIASEMANAS As String = "0"
        Dim FechaDesdeUltimaSemana, FechaHastaUltimaSemana As Date

        Dim FechaHastaCel As Date
        Dim NroCelda, CantPersonasCel, CostoTotalCel As String

        Dim FechaDesdeCosto, FechaHastaCosto As Date
        FechaDesdeCosto = CDate("01/09/2018")
        FechaHastaCosto = CDate("30/09/2018")



        Dim FormProgre As New frmProgreso
        FormProgre.CantMax = 1020
        FormProgre.lblTarea.Text = "Calculando Costos de los artículos."
        FormProgre.lblEstado.Text = "Obteniendo parámetros generales ..."
        FormProgre.Cargar()
        FormProgre.Show()
        FormProgre.CantProg = 1
        FormProgre.Actualizar()


        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        'primero me traigo los datos de configuracion y parametros para los calculos de costo
        CantMaquinasPorTejedor = "2"
        ValorHoraMO = "100"
        PorPresentismo = "20"
        PorCargasSociales = "23"
        PorSAC = "8,33"
        ParamCantPrendasTejidasMensual = 90000
        ParamCantPrendasCortadasMensual = 50000
        sStr = "SELECT isnull(CantMaqPorTejedor,2) as CantMaqPorTejedor,* FROM CostosConfigSistema"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                CantMaquinasPorTejedor = Reader.Item("CantMaqPorTejedor").ToString
                ValorHoraMO = Reader.Item("ValorHoraMO").ToString
                PorPresentismo = Reader.Item("PorcentajePresentismo").ToString
                PorCargasSociales = Reader.Item("PorcentajeCargasSociales").ToString
                PorSAC = Reader.Item("PorcentajeSAC").ToString
                ParamCantPrendasTejidasMensual = Reader.Item("CI_CantPrendasTejidasMensual")
                ParamCantPrendasCortadasMensual = Reader.Item("CI_CantPrendasCortadasMensual")
            End If
        End If

        FormProgre.lblEstado.Text = "Obteniendo Costos Indirectos ..."
        FormProgre.CantProg = FormProgre.CantProg + 1
        FormProgre.Actualizar()

        LimpiarDGV()
        ArmarDGV()

        CANTHORASMESTEJEDURIA = 384

        'OBTENGO LOS COSTOS INDIRECTOS

        MATERIALES = 0.0
        If CargaInicial Then
            txtParamCantPrendasTejidas.Text = ParamCantPrendasTejidasMensual
            txtParamCantPrendasCortadas.Text = ParamCantPrendasCortadasMensual
        End If
        ObtengoLosCostosIndirectos(60, 40, 57, 43, COSTOSINDIRECTOSPRENDATEJE, COSTOSINDIRECTOSPRENDACORTE)

        FormProgre.lblEstado.Text = "Obteniendo parámetros de tejeduría ..."
        FormProgre.CantProg = FormProgre.CantProg + 1
        FormProgre.Actualizar()

        'TAMBIEN ME TRAIGO LOS PARAMETROS PARA CALCULAR EL COSTO DE TEJEDURIA DE LO QUE NO ES DE CORTE
        'agarro el ultimo id de configuracion de semanas
        sStr3 = "select MAX(id) AS ID from TejeSemanas"
        Command3 = New SqlCommand(sStr3, cConexionApp.SQLConn)
        Reader3 = Command3.ExecuteReader()
        If Reader3.HasRows Then
            If Reader3.Read Then
                MAXIDTEJEDURIASEMANAS = Reader3.Item("ID")
            End If
        End If
        'con el ultimo id me traigo los datos de la semana para mostrarlos
        sStr3 = "select * from TejeSemanas where id=" + MAXIDTEJEDURIASEMANAS
        Command3 = New SqlCommand(sStr3, cConexionApp.SQLConn)
        Reader3 = Command3.ExecuteReader()
        If Reader3.HasRows Then
            If Reader3.Read Then
                FechaDesdeUltimaSemana = Reader3.Item("FechaDesde")
                FechaHastaUltimaSemana = Reader3.Item("FechaHasta")
            End If
        End If

        'con el ultimo id me traigo la lista de tejedores y ayudantes que estan en la semana para ir buscando el sueldo bruto de cada uno e ir acumulandolos
        CargarSueldosTejeduria()

        TOTALSUELDOSTEJEDURIA = 0
        CANTPERSONASTEJEDURIA = 0
        sStr3 = "select * from DetTejeSemanasPersonal where idGrupoSemana in (select Id from DetTejeSemanas where idSemana = " + MAXIDTEJEDURIASEMANAS + ")"
        sStr3 = sStr3 + " and rol in ('Ayudante','Tejedor') and Eliminado =0"
        Command3 = New SqlCommand(sStr3, cConexionApp.SQLConn)
        Reader3 = Command3.ExecuteReader()
        Do While Reader3.HasRows
            Do While Reader3.Read
                CANTPERSONASTEJEDURIA = CANTPERSONASTEJEDURIA + 1
                TOTALSUELDOSTEJEDURIA = TOTALSUELDOSTEJEDURIA + CDbl(ObtengoSueldoLegajo(Reader3.Item("NroLegajo").ToString))
            Loop
            Reader3.NextResult()
        Loop



        ' luego si ya empiezo con el listado

        sStr = "Select * "
        sStr = sStr + " from Articulos A INNER JOIN ProdTipoGalgas G ON A.CodTipoGalga = G.id "
        sStr = sStr + " inner join "
        sStr = sStr + "("
        sStr = sStr + "select * from StockArticulosPrecios "
        sStr = sStr + "where Eliminado=0 and Tipo='WEB' and FechaHasta is null"
        sStr = sStr + ") P on A.CodArticulo = P.CodArticulo "
        'sStr = sStr + " AND A.Diseño='----' AND G.Codigo = 'C24' "
        sStr = sStr + " AND A.CodArticulo IN (094,330,370,958,662,527,990) "
        sStr = sStr + " order by A.CodArticulo "

        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()

                FormProgre.lblEstado.Text = "Procesando artículo " + Reader.Item("CodArticulo").ToString + " ..."
                FormProgre.CantProg = FormProgre.CantProg + 1
                FormProgre.Actualizar()

                'por cada articulo voy acumulando los precios de las tareas para sacar el precio total
                TEÑIDO = 0.0
                ACUMPRECIO = 0.0
                UltimoOrden = ""
                EsCosto = "0"

                'en los de corte, en los demoas hay que ver que onda:
                'si el articulo tiene articulo madre debo traer las tareas del articulo madre, si no no encuentra tareas para ese articulo
                If Reader.Item("Codigo").ToString = "C24" Then
                    TIPOARTICULO = "CORTE"
                Else
                    TIPOARTICULO = "RESTO"
                End If
                If Reader.Item("Codigo").ToString = "C24" Then
                    If Reader.Item("Diseño").ToString <> "----" And Reader.Item("Diseño").ToString <> "" Then
                        AuxCodArtParaBusqueda = Reader.Item("Diseño").ToString
                    Else
                        AuxCodArtParaBusqueda = Reader.Item("CodArticulo").ToString
                    End If
                Else
                    AuxCodArtParaBusqueda = Reader.Item("CodArticulo").ToString
                End If

                sStr2 = "SELECT * FROM PrendasTareasArticulo WHERE CodArticulo = '" + AuxCodArtParaBusqueda + "' AND FechaFin IS NULL "
                sStr2 = sStr2 + " and Costo=1 "
                sStr2 = sStr2 + " order by orden, Costo desc"
                Command2 = New SqlCommand(sStr2, cConexionApp.SQLConn)
                Reader2 = Command2.ExecuteReader()
                Do While Reader2.HasRows
                    Do While Reader2.Read()

                        'pongo el filtro hasta que quede en orden la asignacion de tareas y orden, asi que hasta que eso ande bien hice una rutina abajo que filtra a mano
                        'las tareas excluidas y las muestras y demas.
                        'cuando quede andando eso bien, entonces se puede comentar el if
                        'If Not FiltrarTareaDelArticulo(Reader.Item("CodArticulo").ToString, Reader2.Item("CodTarea").ToString) Then Continue Do

                        If Reader2.Item("Orden").ToString <> UltimoOrden Then
                            PrecioAux = 0.0
                            'traigo el precio de la tarea
                            sStr3 = "select isnull(precio,0) as precio from ProdTareasPrecios where fechafin is null and CodTarea = " + Reader2.Item("CodTarea").ToString + " "
                            sStr3 = sStr3 + " and CodSector = " + Reader2.Item("CodSector").ToString + " "
                            Command3 = New SqlCommand(sStr3, cConexionApp.SQLConn)
                            Reader3 = Command3.ExecuteReader()
                            If Reader3.HasRows Then
                                If Reader3.Read() Then
                                    PrecioAux = Reader3.Item("precio")
                                End If
                            End If

                            ACUMPRECIO = ACUMPRECIO + PrecioAux
                            UltimoOrden = Reader2.Item("Orden").ToString
                            EsCosto = Reader2.Item("Costo").ToString

                            row = {Reader.Item("CodArticulo").ToString, Reader2.Item("CodTarea").ToString, Reader2.Item("CodSector").ToString, Format(PrecioAux, "0.000")}
                            dgvTareasArt.Rows.Add(row)

                        Else
                            If EsCosto = "0" Then
                                'traigo el precio de la tarea
                                PrecioAux = 0.0
                                sStr3 = "select isnull(precio,0) as precio from ProdTareasPrecios where fechafin is null and CodTarea = " + Reader2.Item("CodTarea").ToString + " "
                                sStr3 = sStr3 + " and CodSector = " + Reader2.Item("CodSector").ToString + " "
                                Command3 = New SqlCommand(sStr3, cConexionApp.SQLConn)
                                Reader3 = Command3.ExecuteReader()
                                If Reader3.HasRows Then
                                    If Reader3.Read() Then
                                        PrecioAux = Reader3.Item("precio")
                                    End If
                                End If

                                ACUMPRECIO = ACUMPRECIO + PrecioAux
                                UltimoOrden = Reader2.Item("Orden").ToString
                                EsCosto = Reader2.Item("Costo").ToString

                                row = {Reader.Item("CodArticulo").ToString, Reader2.Item("CodTarea").ToString, Reader2.Item("CodSector").ToString, Format(PrecioAux, "0.000")}
                                dgvTareasArt.Rows.Add(row)

                            Else
                                'si ya sume una tarea de costo en el mismo orden que lei entonces no sumo el de la que sigue
                            End If
                        End If

                    Loop
                    Reader2.NextResult()
                Loop

                NroCelda = ""
                CantPersonasCel = ""
                'una vez que sume las tareas de la modalidad vieja que suman al costo debo agregar el costo de la produccion por celdas
                sStrCel = "SELECT top 1 NroCelda, isnull(FechaHasta,getdate()) as FechaHasta "
                sStrCel = sStrCel + " FROM DetProdCeldas PC inner join ProdCeldas C on PC.idCelda = C.id WHERE PC.Eliminado = 0 "
                sStrCel = sStrCel + " And CodArticulo = " + Reader.Item("CodArticulo").ToString
                sStrCel = sStrCel + " ORDER BY isnull(FechaHasta,getdate()) DESC "
                CommandCel = New SqlCommand(sStrCel, cConexionApp.SQLConn)
                ReaderCel = CommandCel.ExecuteReader()
                If ReaderCel.HasRows Then
                    If ReaderCel.Read Then
                        FechaHastaCel = ReaderCel.Item("FechaHasta")
                        NroCelda = ReaderCel.Item("NroCelda")
                    End If
                End If
                CostoTotalCel = 0
                sStrCel = "SELECT count(*) as CANTPERS, isnull(SUM(ValorEtapa1),0) as COSTO "
                sStrCel = sStrCel + " FROM DetProdCeldas PC WHERE PC.Eliminado = 0 "
                sStrCel = sStrCel + " AND CodArticulo = " + Reader.Item("CodArticulo").ToString
                sStrCel = sStrCel + " AND isnull(FechaHasta,getdate()) = '" + Format(FechaHastaCel, "yyyyMMdd") + "'"
                CommandCel = New SqlCommand(sStrCel, cConexionApp.SQLConn)
                ReaderCel = CommandCel.ExecuteReader()
                If ReaderCel.HasRows Then
                    If ReaderCel.Read Then
                        CantPersonasCel = ReaderCel.Item("CANTPERS")
                        CostoTotalCel = ReaderCel.Item("COSTO")
                    End If
                End If


                ACUMPRECIO = ACUMPRECIO + CostoTotalCel

                lblNroCelda.Text = NroCelda
                lblFechaHasta.Text = Format(FechaHastaCel, "dd/MM/yyyy")
                lblCantPersonas.Text = CantPersonasCel
                lblCostoTotalCelda.Text = CostoTotalCel

                COSTOARMADOMASCARGASSOCIALES = ACUMPRECIO * ((CDbl(PorPresentismo) + 100) / 100) * ((CDbl(PorCargasSociales) + 100) / 100) * ((CDbl(PorSAC) + 100) / 100)

                If Reader.Item("Codigo").ToString = "C24" Then

                    CodTipoHilado = Reader.Item("CodTipoHilado").ToString

                    CantRollosPorMaquina = "7"
                    KilosPorRollo = "18,8"
                    CostoHiladoPorKilo = "84,7"
                    sStr3 = "SELECT * FROM CostosHiladosParametros WHERE IdHilado=" + CodTipoHilado.ToString
                    Command3 = New SqlCommand(sStr3, cConexionApp.SQLConn)
                    Reader3 = Command3.ExecuteReader()
                    If Reader3.HasRows Then
                        If Reader3.Read Then
                            CantRollosPorMaquina = Reader3.Item("CantRollosPorMaqPorTurno").ToString
                            KilosPorRollo = Reader3.Item("KilosRollo").ToString
                            CostoHiladoPorKilo = Reader3.Item("CostoPorKilo").ToString
                        End If
                    End If

                    If IsDBNull(Reader.Item("Peso")) Then
                        COSTOMO = 0.0
                        COSTOMOMASCARGASSOCIALES = 0.0
                        COSTOHILADO = 0.0
                    Else
                        COSTOMO = (Reader.Item("Peso") / 1000) * (CDbl(ValorHoraMO) / (CDbl(KilosPorRollo) * ((CInt(CantRollosPorMaquina) * CInt(CantMaquinasPorTejedor)) / 8)))
                        COSTOMOMASCARGASSOCIALES = COSTOMO * ((CDbl(PorPresentismo) + 100) / 100) * ((CDbl(PorCargasSociales) + 100) / 100) * ((CDbl(PorSAC) + 100) / 100)
                        COSTOHILADO = (Reader.Item("Peso") / 1000) * CDbl(CostoHiladoPorKilo)
                    End If

                Else

                    CodTipoHilado = Reader.Item("CodTipoHilado").ToString

                    CantRollosPorMaquina = "0"
                    KilosPorRollo = "0"
                    CostoHiladoPorKilo = "0"
                    COSTOMO = 0.0
                    COSTOMOMASCARGASSOCIALES = 0.0

                    If Not IsDBNull(Reader.Item("Tiempo")) Then
                        COSTOMO = Reader.Item("Tiempo") * (CDbl(ValorHoraMO) / 60 / 5)
                        COSTOMOMASCARGASSOCIALES = COSTOMO * ((CDbl(PorPresentismo) + 100) / 100) * ((CDbl(PorCargasSociales) + 100) / 100) * ((CDbl(PorSAC) + 100) / 100)
                    End If

                    sStr3 = "SELECT * FROM StockTipoHilados WHERE Id=" + CodTipoHilado.ToString
                    Command3 = New SqlCommand(sStr3, cConexionApp.SQLConn)
                    Reader3 = Command3.ExecuteReader()
                    If Reader3.HasRows Then
                        If Reader3.Read Then
                            If Not IsDBNull(Reader.Item("Peso")) Then
                                CostoHiladoPorKilo = CalcularCostodeHilado(Reader3.Item("Descripcion").ToString).ToString
                                COSTOHILADO = (Reader.Item("Peso") / 1000) * CalcularCostodeHilado(Reader3.Item("Descripcion").ToString)
                            End If
                        End If
                    End If

                End If

                'el costo del TEÑIDO por hilado
                'primero controlo que el articulo tenga teñido, sino el teñido es cero
                sStr3 = "SELECT isnull(count(*),0) as CANT FROM detPrendasPartesTeñido where Eliminado =0 and CodArticulo ='" + Reader.Item("CodArticulo").ToString + "' "
                Command3 = New SqlCommand(sStr3, cConexionApp.SQLConn)
                Reader3 = Command3.ExecuteReader()
                If Reader3.HasRows Then
                    If Reader3.Read Then
                        If Reader3.Item("CANT") > 0 Then
                            sStr3 = "SELECT top 1 * FROM CostosArticulosTeñido WHERE Eliminado=0 AND CodTipoHilado=" + CodTipoHilado.ToString + " order by Fecha DESC "
                            Command3 = New SqlCommand(sStr3, cConexionApp.SQLConn)
                            Reader3 = Command3.ExecuteReader()
                            If Reader3.HasRows Then
                                If Reader3.Read Then
                                    If Not IsDBNull(Reader3.Item("Precio")) Then
                                        TEÑIDO = Reader3.Item("Precio")
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

                ' los MATERIALES

                MATERIALES = ObtenerMateriales(Reader.Item("CodArticulo").ToString, MateCosto1Boton, MateCosto1Cierre, MateCantidadBotones, MateCantidadCierres)

                If TIPOARTICULO = "CORTE" Then

                    COSTOTOTAL = COSTOARMADOMASCARGASSOCIALES + COSTOMOMASCARGASSOCIALES + COSTOHILADO + MATERIALES + TEÑIDO + COSTOSINDIRECTOSPRENDACORTE


                    row = {TIPOARTICULO, Reader.Item("CodTipoHilado").ToString, Reader.Item("Habilitado").ToString, Reader.Item("Diseño").ToString, Reader.Item("Codigo").ToString, _
                           Reader.Item("CodArticulo").ToString, Format(Reader.Item("Peso") / 1000, "0.00"), Format(ACUMPRECIO, "0.000"), _
                           Format(COSTOARMADOMASCARGASSOCIALES, "0.00"), Format(COSTOMO, "0.00"), Format(COSTOMOMASCARGASSOCIALES, "0.00"), _
                           Format(COSTOHILADO, "0.00"), Format(TEÑIDO, "0.00"), Format(MATERIALES, "0.00"), Format(COSTOSINDIRECTOSPRENDACORTE, "0.00"), Format(COSTOTOTAL, "0.00"), Reader.Item("Precio").ToString, _
                           CantMaquinasPorTejedor, CantRollosPorMaquina, KilosPorRollo, CostoHiladoPorKilo, NroCelda, FechaHastaCel, CantPersonasCel, CostoTotalCel, _
                           Format(FechaHastaCosto, "MM/yyyy"), Format(FechaDesdeUltimaSemana, "dd/MM") + " AL " + Format(FechaHastaUltimaSemana, "dd/MM"), _
                           Reader.Item("Tiempo").ToString, CANTMAQUINASTEJEDURIA, CANTPERSONASTEJEDURIA, TOTALSUELDOSTEJEDURIA, CANTHORASMESTEJEDURIA, _
                           MateCantidadBotones, MateCosto1Boton, MateCantidadCierres, MateCosto1Cierre}

                Else

                    COSTOTOTAL = COSTOARMADOMASCARGASSOCIALES + COSTOMOMASCARGASSOCIALES + COSTOHILADO + MATERIALES + TEÑIDO + COSTOSINDIRECTOSPRENDATEJE


                    row = {TIPOARTICULO, Reader.Item("CodTipoHilado").ToString, Reader.Item("Habilitado").ToString, Reader.Item("Diseño").ToString, Reader.Item("Codigo").ToString, _
                           Reader.Item("CodArticulo").ToString, Format(Reader.Item("Peso") / 1000, "0.00"), Format(ACUMPRECIO, "0.000"), _
                           Format(COSTOARMADOMASCARGASSOCIALES, "0.00"), Format(COSTOMO, "0.00"), Format(COSTOMOMASCARGASSOCIALES, "0.00"), _
                           Format(COSTOHILADO, "0.00"), Format(TEÑIDO, "0.00"), Format(MATERIALES, "0.00"), Format(COSTOSINDIRECTOSPRENDATEJE, "0.00"), Format(COSTOTOTAL, "0.00"), Reader.Item("Precio").ToString, _
                           CantMaquinasPorTejedor, CantRollosPorMaquina, KilosPorRollo, CostoHiladoPorKilo, NroCelda, FechaHastaCel, CantPersonasCel, CostoTotalCel, _
                           Format(FechaHastaCosto, "MM/yyyy"), Format(FechaDesdeUltimaSemana, "dd/MM") + " AL " + Format(FechaHastaUltimaSemana, "dd/MM"), _
                           Reader.Item("Tiempo").ToString, CANTMAQUINASTEJEDURIA, CANTPERSONASTEJEDURIA, TOTALSUELDOSTEJEDURIA, CANTHORASMESTEJEDURIA, _
                           MateCantidadBotones, MateCosto1Boton, MateCantidadCierres, MateCosto1Cierre}

                End If

                dgvArticulos.Rows.Add(row)

            Loop
            Reader.NextResult()
        Loop

        FormProgre.Close()

        'siempre al final le aplico el filtro asi la pantalla se ve com esten elegidas las opciones de los combos

        AplicarFiltro()
    End Sub

    Private Sub frmRepoHiladoTextiSobra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Strings.Left(System.Environment.MachineName.ToString, 8) = "COMPUTOS" Then
            btnRecuperarExcelCargasSociales.Enabled = True
        Else
            btnRecuperarExcelCargasSociales.Enabled = False
        End If
        'txtCodArtDesde.Text = "956"
        dgvSueldosTejeduria.Visible = False
        dgvArticulos.Width = 1170
        CargarCombos()
        gbArmadoArticulo.Visible = False
        gbCalculo.Visible = False
        gbCalculo.Top = dgvArticulos.Top - 5
        gbCalculo.Left = 1200 - 400
        gbCalculo.Width = 395
        gbCostosIndirectos.Visible = False
        gbCostosIndirectos.Top = dgvArticulos.Top - 5
        gbCostosIndirectos.Left = 1200 - 400
        gbCostosIndirectos.Width = 395
        gbCalculoCostoRubros.Visible = False
        gbCalculoCostoRubros.Top = dgvArticulos.Top - 5
        gbCalculoCostoRubros.Left = 1200 - 260
        gbCalculoCostoRubros.Width = 260
        gbMaterialesArticulo.Visible = False
        gbMaterialesArticulo.Top = dgvArticulos.Top - 5
        gbMaterialesArticulo.Left = 1200 - 260
        gbMaterialesArticulo.Width = 260
        gbArmadoArticulo.Top = dgvArticulos.Top
        CargaInicial()
        CotizacionDolar = ObtenerCotizacionDolar()
        txtCodArtDesde.Select()
    End Sub

    Private Sub CargarCombos()
        cmbHilados.Items.Clear()
        cmbHilados.Items.Add("TODOS")
        ColTipoHilado.Clear()
        ColTipoHilado.Add("0", "TODOS")
        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        sStr = "SELECT * FROM StockTipoHilados WHERE Eliminado = 0 ORDER BY Descripcion"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read
                cmbHilados.Items.Add(Reader.Item("Descripcion").ToString)
                ColTipoHilado.Add(Reader.Item("id").ToString, Reader.Item("Descripcion").ToString)
            Loop
            Reader.NextResult()
        Loop
        cmbHilados.SelectedIndex = 0

        cmbTipoLisoSublimado.Items.Clear()
        cmbTipoLisoSublimado.Items.Add("TODOS")
        cmbTipoLisoSublimado.Items.Add("LISO")
        cmbTipoLisoSublimado.Items.Add("SUBLIMADO")
        cmbTipoLisoSublimado.SelectedIndex = 0

        cmbPROD.Items.Clear()
        cmbPROD.Items.Add("TODOS")
        cmbPROD.Items.Add("CORTE")
        cmbPROD.Items.Add("RECTILINEA")
        cmbPROD.SelectedIndex = 0


    End Sub
    Private Sub CargaInicial()

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        'primero me traigo los datos de configuracion y parametros para los calculos de costo
        CantMaquinasPorTejedor = "2"
        ValorHoraMO = "80,42"
        PorPresentismo = "20"
        PorCargasSociales = "23"
        PorSAC = "8,33"
        sStr = "SELECT isnull(CantMaqPorTejedor,2) as CantMaqPorTejedor,* FROM CostosConfigSistema"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                CantMaquinasPorTejedor = Reader.Item("CantMaqPorTejedor").ToString
                ValorHoraMO = Reader.Item("ValorHoraMO").ToString
                PorPresentismo = Reader.Item("PorcentajePresentismo").ToString
                PorCargasSociales = Reader.Item("PorcentajeCargasSociales").ToString
                PorSAC = Reader.Item("PorcentajeSAC").ToString
            End If
        End If

        ' tambien busco la ultima fecha de recupero del excel de cargas sociales para mostrarla en el label
        lblUltimoRecuperoExcelCargasSociales.Text = "Último Recupero Excel Cargas Sociales: N/A"
        sStr = "SELECT isnull(max(AnioMes),'') as AnioMes FROM CostosExcelCargasSocialesEnc"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                If Reader.Item("AnioMes").ToString <> "" Then
                    lblUltimoRecuperoExcelCargasSociales.Text = "Último Recupero Excel Cargas Sociales: " + Strings.Right(Reader.Item("AnioMes").ToString, 2) + "/" + Strings.Left(Reader.Item("AnioMes").ToString, 4)
                End If
            End If
        End If

        CalcularCostosyCargarListado(True)

        AplicarFiltro()

    End Sub

    Private Sub ObtengoLosCostosIndirectos(ByVal PorcTeje As Integer, ByVal PorcCorte As Integer, ByVal PorcConfTeje As Integer, ByVal PorcConfCorte As Integer, ByRef CIPRENDATEJIDA As Double, ByRef CIPRENDACORTE As Double)
        Dim CommandCI As New SqlCommand
        Dim ReaderCI As SqlDataReader
        Dim sStrCI As String

        Dim row As String()

        Dim TotalRubros As Double = 0.0
        Dim CotizacionDolarHoy As Double = 0.0

        Dim CostosOperativos, CostosSueldos, CostosRubros As Double
        Dim CantPrendasTejidas, CantPrendasCortadas As Integer
        Dim TotalTeje, TotalCorte As Double

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        CostosOperativos = CDbl(lblTotalCostosOperativos.Text.Replace(".", ","))
        CostosSueldos = CDbl(lblTotalSueldosOperativosMasCargas.Text.Replace(".", ","))

        sStrCI = "select ANIO,MES,SUM(TOTALDOLARES) AS TOTALDOLARES "
        sStrCI = sStrCI + " from ("
        sStrCI = sStrCI + " SELECT ANIO,MES,SUM(TOTALDOLARES) AS TOTALDOLARES"
        sStrCI = sStrCI + " FROM"
        sStrCI = sStrCI + " ("
        sStrCI = sStrCI + " select YEAR(FECHA) AS ANIO,MONTH(Fecha) AS MES "
        sStrCI = sStrCI + " ,(Total * Mon.Cotizacion) / (SELECT Cotizacion from CostosCotizacionMonedas WHERE Moneda='Dolares' AND FechaDesde <=E.Fecha AND FechaHasta >=E.Fecha ) AS TOTALDOLARES"
        sStrCI = sStrCI + " from MantOrdenCompraEnc E left join MantComprasRubros Rub on E.CodRubro=Rub.id  "
        sStrCI = sStrCI + " left join CostosCotizacionMonedas Mon on Mon.Moneda=E.Moneda and E.Fecha BETWEEN Mon.FechaDesde And Mon.FechaHasta"
        sStrCI = sStrCI + " WHERE Cast(E.Fecha As Date) >= '20171001' AND Cast(E.Fecha As Date) <='20180930'  "
        sStrCI = sStrCI + " and Rub.costoarticulo = 1"
        sStrCI = sStrCI + " ) P1"
        sStrCI = sStrCI + " GROUP BY ANIO,MES  "
        sStrCI = sStrCI + " UNION"
        sStrCI = sStrCI + " SELECT ANIO,MES,SUM(TOTALDOLARES) AS TOTALDOLARES"
        sStrCI = sStrCI + " FROM"
        sStrCI = sStrCI + " ("
        sStrCI = sStrCI + " select YEAR(E.FECHA) AS ANIO,MONTH(E.Fecha) AS MES"
        sStrCI = sStrCI + " ,(Total * Mon.Cotizacion) / (SELECT Cotizacion from CostosCotizacionMonedas WHERE Moneda='Dolares' AND FechaDesde <=E.Fecha AND FechaHasta >=E.Fecha ) AS TOTALDOLARES"
        sStrCI = sStrCI + " from (select * from MantInfFinaPagos where Eliminado=0) E "
        sStrCI = sStrCI + " left join MantOrdenCompraEnc OC on E.NroComp=OC.NroOrden   left join MantComprasRubros Rub on OC.CodRubro=Rub.id  "
        sStrCI = sStrCI + " left join CostosCotizacionMonedas Mon on Mon.Moneda=E.Moneda and E.Fecha BETWEEN Mon.FechaDesde And Mon.FechaHasta"
        sStrCI = sStrCI + " WHERE e.NombreGastoDerivado <>''  AND Cast(E.Fecha As Date) >= '20171001' AND Cast(E.Fecha As Date) <='20180930' "
        sStrCI = sStrCI + " and (MONTH(E.Fecha)=MONTH(OC.Fecha) AND YEAR(E.Fecha)=YEAR(OC.Fecha))  "
        sStrCI = sStrCI + " and Rub.costoarticulo = 1"
        sStrCI = sStrCI + " )P2"
        sStrCI = sStrCI + " GROUP BY ANIO,MES"
        sStrCI = sStrCI + " ) A"
        sStrCI = sStrCI + " GROUP BY ANIO,MES"
        sStrCI = sStrCI + " ORDER BY ANIO,MES"
        CommandCI = New SqlCommand(sStrCI, cConexionApp.SQLConn)
        ReaderCI = CommandCI.ExecuteReader()
        Do While ReaderCI.HasRows
            Do While ReaderCI.Read
                TotalRubros = TotalRubros + ReaderCI.Item("TOTALDOLARES")

                row = {ReaderCI.Item("ANIO"), ReaderCI.Item("MES"), Format(ReaderCI.Item("TOTALDOLARES"), "0.00")}
                dgvCostosRubros.Rows.Add(row)
            Loop
            ReaderCI.NextResult()
        Loop

        sStrCI = "SELECT Cotizacion FROM CostosCotizacionMonedas WHERE Moneda = 'Dolares' AND FechaDesde <= '" + Format(Now, "yyyyMMdd") + "' AND FechaHasta >= '" + Format(Now, "yyyyMMdd") + "' "
        CommandCI = New SqlCommand(sStrCI, cConexionApp.SQLConn)
        ReaderCI = CommandCI.ExecuteReader()
        If ReaderCI.HasRows Then
            If ReaderCI.Read Then
                CotizacionDolarHoy = ReaderCI.Item("Cotizacion")
            End If
        End If
        lblCostoRubroCotizDolar.Text = Format(CotizacionDolarHoy, "fixed")

        CostosRubros = (TotalRubros / 12) * CotizacionDolarHoy

        lblCostoRubroTotalDolares.Text = Format(TotalRubros, "0.00")
        lblCostoRubroMensualEnPesos.Text = Format(CostosRubros, "0.00")
        lblTotalCostosRubros.Text = Format(CostosRubros, "0.00")

        lblTotalGastosIndirectos.Text = Format((CostosOperativos + CostosSueldos + CostosRubros), "0.00")

        CantPrendasTejidas = CDbl(txtParamCantPrendasTejidas.Text)
        CantPrendasCortadas = CDbl(txtParamCantPrendasCortadas.Text)
        lblTotalPrendasTejidas.Text = CantPrendasTejidas
        lblTotalPrendasCortadas.Text = CantPrendasCortadas
        lblTotalPrendasProducidas.Text = CantPrendasTejidas + CantPrendasCortadas


        lblTitPorcentajeTejeduria.Text = "PORCENTAJE SECTOR TEJEDURIA (" + PorcTeje.ToString + "%):"
        lblTitPorcentajeRestoPlanta.Text = "PORCENTAJE RESTO DE LA PLANTA (" + PorcCorte.ToString + "%):"
        lblTitPorcentajeConfTejeduriayEtapa2.Text = "CONF. TEJED + ETAPA 2 (" + PorcConfTeje.ToString + "%):"
        lblTitPorcentajeConfRestoPlantayEtapa2.Text = "CONF. RESTO + ETAPA 2 (" + PorcConfCorte.ToString + "%):"
        lblPorcionTejeduria.Text = Format((CostosOperativos + CostosSueldos + CostosRubros) * PorcTeje / 100, "0.00")
        lblPorcionRestoPlanta.Text = Format((CostosOperativos + CostosSueldos + CostosRubros) * PorcCorte / 100, "0.00")
        lblPorcionConfTejeduriayEtapa2.Text = Format((CostosOperativos + CostosSueldos + CostosRubros) * (PorcCorte / 100) * (PorcConfTeje / 100), "0.00")
        lblPorcionConfRestoPlantayEtapa2.Text = Format((CostosOperativos + CostosSueldos + CostosRubros) * (PorcCorte / 100) * (PorcConfCorte / 100), "0.00")
        TotalTeje = ((CostosOperativos + CostosSueldos + CostosRubros) * PorcTeje / 100) + ((CostosOperativos + CostosSueldos + CostosRubros) * (PorcCorte / 100) * (PorcConfTeje / 100))
        TotalCorte = ((CostosOperativos + CostosSueldos + CostosRubros) * (PorcCorte / 100) * (PorcConfCorte / 100))

        lblCalculoCIPrendaTejida.Text = "CALCULO CI PRENDA TEJIDA: (" + lblPorcionTejeduria.Text + "+" + lblPorcionConfTejeduriayEtapa2.Text + ") / " + lblTotalPrendasTejidas.Text

        lblCalculoCIPrendaCortada.Text = "CALCULO CI PRENDA CORTE: (" + lblPorcionConfRestoPlantayEtapa2.Text + ") / " + lblTotalPrendasCortadas.Text

        CIPRENDATEJIDA = TotalTeje / CantPrendasTejidas
        CIPRENDACORTE = TotalCorte / CantPrendasCortadas

        lblCostoGastoIndirectoPorPrendaTejida.Text = "COSTO INDIRECTO POR PRENDA TEJIDA: $" + Format(CIPRENDATEJIDA, "0.00")
        lblCostoGastoIndirectoPorPrendaCorte.Text = "COSTO INDIRECTO POR PRENDA CORTE: $" + Format(CIPRENDACORTE, "0.00")

    End Sub

    Private Function ObtenerMateriales(ByVal CodArt As String, ByRef MateCosto1Boton As Double, ByRef MateCosto1Cierre As Double, ByRef MateCantidadBotones As Integer, ByRef MateCantidadCierres As Integer) As Double
        Dim CommandMat As New SqlCommand
        Dim ReaderMat As SqlDataReader
        Dim sStrMat As String

        Dim Retorno As Double = 0.0

        MateCosto1Boton = 0.00035
        MateCosto1Cierre = 4.0
        MateCantidadBotones = 0
        MateCantidadCierres = 0

        Dim TotalMateriales As Double = 0.0

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStrMat = "select ISNULL(SUM(CANTIDAD),0) AS CANTIDAD from ArticulosBotones  where CodArticulo ='" + CodArt + "'"
        CommandMat = New SqlCommand(sStrMat, cConexionApp.SQLConn)
        ReaderMat = CommandMat.ExecuteReader()
        If ReaderMat.HasRows Then
            If ReaderMat.Read Then
                MateCantidadBotones = ReaderMat.Item("CANTIDAD")
            End If
        End If

        sStrMat = "select isnull(COUNT(*),0) AS CANTIDAD from ArticulosCierres  where CodArticulo ='" + CodArt + "'"
        CommandMat = New SqlCommand(sStrMat, cConexionApp.SQLConn)
        ReaderMat = CommandMat.ExecuteReader()
        If ReaderMat.HasRows Then
            If ReaderMat.Read Then
                MateCantidadCierres = ReaderMat.Item("CANTIDAD")
            End If
        End If

        TotalMateriales = MateCosto1Boton * MateCantidadBotones + MateCosto1Cierre * MateCantidadCierres

        Retorno = TotalMateriales

        Return Retorno
    End Function

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        AplicarFiltro()
    End Sub

    Private Sub txtCodArtDesde_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodArtDesde.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtCodArtHasta.Select()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            Close()
        End If
    End Sub

    Private Sub txtCodArtHasta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodArtHasta.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            AplicarFiltro()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            Close()
        End If
    End Sub

    Private Sub chkVerInhabilitados_CheckedChanged(sender As Object, e As EventArgs) Handles chkVerInhabilitados.CheckedChanged
        AplicarFiltro()
    End Sub

    Private Sub cmdImprimir_Click(sender As System.Object, e As System.EventArgs) Handles cmdImprimir.Click

        pdoImpresion.DefaultPageSettings.Landscape = False
        pdoImpresion.DefaultPageSettings.Margins.Left = 20
        pdoImpresion.DefaultPageSettings.Margins.Right = 20
        pdoImpresion.DefaultPageSettings.Margins.Top = 35
        pdoImpresion.DefaultPageSettings.Margins.Bottom = 35
        pdoImpresion.OriginAtMargins = True ' takes margins into account 

        Dim dlgPrintPreview As New EnhancedPrintPreviewDialog
        dlgPrintPreview.ClientSize = New System.Drawing.Size(600, 600)
        dlgPrintPreview.Document = pdoImpresion ' Previews print
        dlgPrintPreview.ShowDialog()

        'pdoImpresion.Print()
    End Sub

    Private Sub pdoImpresion_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdoImpresion.PrintPage
        On Error Resume Next
        Dim sStr As String
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader

        Dim nTop As Int16 = e.MarginBounds.Top
        Dim nLeft As Int16 = e.MarginBounds.Left
        Dim FuenteTitulo As Font = New Drawing.Font("Arial Narrow", 12, FontStyle.Bold)
        Dim FuenteTitulo1 As Font = New Drawing.Font("Arial", 14, FontStyle.Bold)
        Dim FuenteCuadro7 As Font = New Drawing.Font("Arial Narrow", 7)
        Dim FuenteCuadro10 As Font = New Drawing.Font("Arial Narrow", 10)
        Dim FuenteCuadro11 As Font = New Drawing.Font("Arial", 11)
        Dim FuenteCuadro12 As Font = New Drawing.Font("Arial", 12, FontStyle.Bold)
        Dim Asunto, DesProv, DirProv, Observaciones, EstadoServicio As String
        Dim ObsEncabezado As String

        nTop = e.MarginBounds.Top
        Observaciones = ""
        EstadoServicio = ""

        e.Graphics.DrawLine(Pens.Black, 1, nTop, 785, nTop)
        nTop = nTop + 2

        e.Graphics.DrawString("LISTADO DE COSTO DE ARTICULOS POAL", FuenteTitulo, Brushes.Black, 85, nTop)
        nTop = nTop + 25

        'los titulos del detalle
        e.Graphics.DrawLine(Pens.Black, 1, nTop, 785, nTop)
        nTop = nTop + 5
        e.Graphics.DrawString("ART.", FuenteCuadro10, Brushes.Black, New RectangleF(25, nTop, 40, 50))
        e.Graphics.DrawString("PESO Kg/P", FuenteCuadro10, Brushes.Black, New RectangleF(70, nTop, 65, 50))
        e.Graphics.DrawString("COSTO ARMADO ($/P)", FuenteCuadro10, Brushes.Black, New RectangleF(140, nTop, 80, 50))
        e.Graphics.DrawString("Costo Armado + Cs Sociales", FuenteCuadro10, Brushes.Black, New RectangleF(220, nTop, 80, 50))
        e.Graphics.DrawString("Costo MO ($/P)", FuenteCuadro10, Brushes.Black, New RectangleF(300, nTop, 80, 50))
        e.Graphics.DrawString("Costo MO + Cs Sociales", FuenteCuadro10, Brushes.Black, New RectangleF(380, nTop, 80, 50))
        e.Graphics.DrawString("Costo Hilado ($/P)", FuenteCuadro10, Brushes.Black, New RectangleF(460, nTop, 80, 50))
        e.Graphics.DrawString("Materiales (Estimado)", FuenteCuadro10, Brushes.Black, New RectangleF(540, nTop, 80, 50))
        e.Graphics.DrawString("Costos Indirectos", FuenteCuadro10, Brushes.Black, New RectangleF(620, nTop, 80, 50))
        e.Graphics.DrawString("Costo Total ($/P)", FuenteCuadro10, Brushes.Black, New RectangleF(700, nTop, 80, 50))
        nTop = nTop + 50
        e.Graphics.DrawLine(Pens.Black, 1, nTop, 785, nTop)
        nTop = nTop + 5
        'fin titulos del detalle arranco con el detalle
        ' los voy a sacar directamente del datagridview en vez de buscar lo que hay en la base de datos
        For i = 0 To dgvArticulos.RowCount - 1

            e.Graphics.DrawString(dgvArticulos.Rows(i).Cells(0).Value, FuenteCuadro10, Brushes.Black, 30, nTop)
            e.Graphics.DrawString(dgvArticulos.Rows(i).Cells(1).Value, FuenteCuadro10, Brushes.Black, 110 - e.Graphics.MeasureString(dgvArticulos.Rows(i).Cells(1).Value, FuenteCuadro10).Width, nTop)
            e.Graphics.DrawString(dgvArticulos.Rows(i).Cells(2).Value, FuenteCuadro10, Brushes.Black, 190 - e.Graphics.MeasureString(dgvArticulos.Rows(i).Cells(2).Value, FuenteCuadro10).Width, nTop)
            e.Graphics.DrawString(dgvArticulos.Rows(i).Cells(3).Value, FuenteCuadro10, Brushes.Black, 270 - e.Graphics.MeasureString(dgvArticulos.Rows(i).Cells(3).Value, FuenteCuadro10).Width, nTop)
            e.Graphics.DrawString(dgvArticulos.Rows(i).Cells(4).Value, FuenteCuadro10, Brushes.Black, 350 - e.Graphics.MeasureString(dgvArticulos.Rows(i).Cells(4).Value, FuenteCuadro10).Width, nTop)
            e.Graphics.DrawString(dgvArticulos.Rows(i).Cells(5).Value, FuenteCuadro10, Brushes.Black, 430 - e.Graphics.MeasureString(dgvArticulos.Rows(i).Cells(5).Value, FuenteCuadro10).Width, nTop)
            e.Graphics.DrawString(dgvArticulos.Rows(i).Cells(6).Value, FuenteCuadro10, Brushes.Black, 510 - e.Graphics.MeasureString(dgvArticulos.Rows(i).Cells(6).Value, FuenteCuadro10).Width, nTop)
            e.Graphics.DrawString(dgvArticulos.Rows(i).Cells(7).Value, FuenteCuadro10, Brushes.Black, 590 - e.Graphics.MeasureString(dgvArticulos.Rows(i).Cells(7).Value, FuenteCuadro10).Width, nTop)
            e.Graphics.DrawString(dgvArticulos.Rows(i).Cells(8).Value, FuenteCuadro10, Brushes.Black, 670 - e.Graphics.MeasureString(dgvArticulos.Rows(i).Cells(8).Value, FuenteCuadro10).Width, nTop)
            e.Graphics.DrawString(dgvArticulos.Rows(i).Cells(9).Value, FuenteCuadro10, Brushes.Black, 750 - e.Graphics.MeasureString(dgvArticulos.Rows(i).Cells(9).Value, FuenteCuadro10).Width, nTop)
            nTop = nTop + 23

        Next


        'cuando termino el encabezado y el detalle y el pie de pagina, ya se el largo que tendra, entonces puedo hacer las lineas verticales, para que queden hasta el fin de los datos justito
        e.Graphics.DrawLine(Pens.Black, 1, e.MarginBounds.Top, 1, nTop)
        e.Graphics.DrawLine(Pens.Black, 785, e.MarginBounds.Top, 785, nTop)
        'y la linea de abajo
        e.Graphics.DrawLine(Pens.Black, 1, nTop, 785, nTop)


        Exit Sub
ErrPrintPage:
        MensajeAtencion("Error al generar la impresión.")

    End Sub

    Private Sub dgvArticulos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArticulos.CellClick
        If gbArmadoArticulo.Visible = True Then
            FiltrarListaDeTareas(dgvArticulos.Rows(dgvArticulos.CurrentRow.Index).Cells("ARTICULO").Value, dgvArticulos.CurrentRow.Index)
        End If
        If gbCalculo.Visible = True Then
            FiltrarCalculo(dgvArticulos.CurrentRow.Index)
        End If
    End Sub

    Private Sub FiltrarListaDeTareas(ByVal CodArti As String, ByVal FilaDGV As Integer)
        Dim i As Integer
        Dim CostoTotalTareas As Double = 0.0
        gbArmadoArticulo.Text = "Listado de Tareas del Artículo " + CodArti
        For i = 0 To dgvTareasArt.RowCount - 1
            If dgvTareasArt.Rows(i).Cells("ARTICULO").Value.ToString = CodArti Then
                dgvTareasArt.Rows(i).Visible = True
                CostoTotalTareas = CostoTotalTareas + dgvTareasArt.Rows(i).Cells("PRECIO").Value
            Else
                dgvTareasArt.Rows(i).Visible = False
            End If
        Next
        lblCostoTotalTareas.Text = Format(CostoTotalTareas, "0.00")

        If dgvArticulos.Rows(FilaDGV).Cells("NROCELDA").Value <> "" Then
            lblNroCelda.Text = dgvArticulos.Rows(FilaDGV).Cells("NROCELDA").Value
            lblFechaHasta.Text = Format(CDate(dgvArticulos.Rows(FilaDGV).Cells("FECHAHASTACELDA").Value), "dd/MM/yyyy")
            lblCantPersonas.Text = Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("CANTPERSCELDA").Value), "0")
            lblCostoTotalCelda.Text = Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("COSTOTOTALCELDA").Value), "0.00")
        Else
            lblNroCelda.Text = ""
            lblFechaHasta.Text = ""
            lblCantPersonas.Text = ""
            lblCostoTotalCelda.Text = ""
        End If

    End Sub
    Private Sub FiltrarListaDeMateriales(ByVal CodArti As String, ByVal FilaDGV As Integer)
        gbMaterialesArticulo.Text = "Materiales del Artículo " + CodArti

        lblCosto1Boton.Text = Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("COSTO1BOTON").Value.ToString.Replace(".", ",")), "0.0000")
        lblCantidadDeBotones.Text = Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("CANTIDADBOTONES").Value.ToString.Replace(".", ",")), "0")
        lblCostoBotones.Text = Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("COSTO1BOTON").Value.ToString.Replace(".", ",")) * CDbl(dgvArticulos.Rows(FilaDGV).Cells("CANTIDADBOTONES").Value.ToString.Replace(".", ",")), "0.000")
        lblCosto1Cierre.Text = Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("COSTO1CIERRE").Value.ToString.Replace(".", ",")), "0.000")
        lblCantidadDeCierres.Text = Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("CANTIDADCIERRES").Value.ToString.Replace(".", ",")), "0")
        lblCostoCierres.Text = Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("COSTO1CIERRE").Value.ToString.Replace(".", ",")) * CDbl(dgvArticulos.Rows(FilaDGV).Cells("CANTIDADCIERRES").Value.ToString.Replace(".", ",")), "0.000")

        lblTotalMateriales.Text = Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("MATERIALES").Value.ToString.Replace(".", ",")), "0.000")

    End Sub
    Private Sub FiltrarCalculo(ByVal FilaDGV As Integer)
        Dim CantRollosPorHora, KilosPorHora As Double
        PanelCostoTejeduriaCORTE.Top = 137
        PanelCostoTejeduriaCORTE.Left = 7
        PanelCostoTejeduriaCORTE.Height = 248
        PanelCostoTejeduriaCORTE.Width = 370
        PanelCostoTejeduriaRESTO.Top = 137
        PanelCostoTejeduriaRESTO.Left = 7
        PanelCostoTejeduriaRESTO.Height = 248
        PanelCostoTejeduriaRESTO.Width = 370

        If dgvArticulos.Rows(FilaDGV).Cells("TIPOARTICULO").Value.ToString = "CORTE" Then
            PanelCostoTejeduriaCORTE.Visible = True
            PanelCostoTejeduriaRESTO.Visible = False

            gbCalculo.Text = "Cálculo del Costo del Artículo " + dgvArticulos.Rows(FilaDGV).Cells("ARTICULO").Value

            lblValorHoraMO.Text = "Valor Hora MO: " + Format(CDbl(ValorHoraMO), "0.00") + "$"
            lblPresentismo.Text = "Presentismo: " + Format(CDbl(PorPresentismo), "0.00") + "%"
            lblCargasSociales.Text = "C.Sociales: " + Format(CDbl(PorCargasSociales), "0.00") + "%"
            lblSAC.Text = "SAC: " + Format(CDbl(PorSAC), "0.00") + "%"

            lblCostoArmado.Text = "COSTO ARMADO: " + Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("COSTOARMADO").Value), "0.00")
            lblCostoArmadoConCargasSociales.Text = "COSTO ARMADO + CS: " + Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("COSTOARMADOMASCARGASSOCIALES").Value), "0.00")

            lblCantMaqPorTejedor.Text = "Máq. por Tejedor: " + Format(CInt(dgvArticulos.Rows(FilaDGV).Cells("CANTMAQPORTEJEDOR").Value), "0")
            lblRollosMaqTurno.Text = "Rollos por Maq. / Turno: " + Format(CInt(dgvArticulos.Rows(FilaDGV).Cells("CANTROLLOSPORMAQ").Value), "0.00")
            CantRollosPorHora = (CDbl(dgvArticulos.Rows(FilaDGV).Cells("CANTROLLOSPORMAQ").Value) * CDbl(dgvArticulos.Rows(FilaDGV).Cells("CANTMAQPORTEJEDOR").Value)) / 8
            lblRollosPorHora.Text = "Rollos por Hora: " + Format(CantRollosPorHora, " 0.00")
            lblAuxRollosPorHora.Text = "(" + Format(CInt(dgvArticulos.Rows(FilaDGV).Cells("CANTMAQPORTEJEDOR").Value), "0") + " maq * " + _
                        Format(CInt(dgvArticulos.Rows(FilaDGV).Cells("CANTROLLOSPORMAQ").Value), "0.00") + " m/t) / 8 hs"

            lblPesoRolloHilado.Text = "Peso Rollo Hilado: " + Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("KILOSPORROLLO").Value.ToString), "0.00")
            KilosPorHora = CDbl(dgvArticulos.Rows(FilaDGV).Cells("KILOSPORROLLO").Value.ToString) * CantRollosPorHora
            lblKilosPorHora.Text = "Kilos por Hora: " + Format(KilosPorHora, "0.00")
            lblAuxKilosPorHora.Text = "(" + Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("KILOSPORROLLO").Value.ToString), "0.00") + " kg/rollo * " + _
                        Format(CantRollosPorHora, "0.00") + " r/h)"

            lblPesosPorKiloMO.Text = "$ por Kilo (MO): " + Format(CDbl(ValorHoraMO) / KilosPorHora, " 0.00")
            lblAuxPesosPorKiloMO.Text = "(" + Format(CDbl(ValorHoraMO), "0.00") + " $/h / " + Format(KilosPorHora, "0.00") + " K/h)"

            lblCostoManoObra.Text = "COSTO MO: " + Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("COSTOMO").Value), "0.00")
            lblAuxCostoMO.Text = "(" + Format(CDbl(ValorHoraMO) / KilosPorHora, "0.00") + " $/Kg * " + Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("PESO").Value), "0.00") + " Kg)"
            lblCostoManoObraConCargasSociales.Text = "COSTO MO + CS: " + Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("COSTOMOMASCARGASSOCIALES").Value), "0.00")

            lblCostoKiloHilado.Text = "$ por Kilo HILADO: " + Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("COSTOKILODEHILADO").Value), "0.00")
            lblCostoHilado.Text = "COSTO HILADO: " + Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("COSTOHILADO").Value), "0.00")

            lblCostoMateriales.Text = "COSTO MATERIALES: " + Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("MATERIALES").Value), "0.00")

            lblCostosIndirectos.Text = "COSTOS INDIRECTOS DE FABRICACIÓN: " + Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("COSTOSINDIRECTOS").Value), "0.00")

            lblCostoTeñido.Text = "COSTO TEÑIDO: " + Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("COSTOTEÑIDO").Value), "0.00")

            lblCostoTotal.Text = "TOTAL: " + Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("COSTOTOTAL").Value), "0.00")
        Else
            PanelCostoTejeduriaCORTE.Visible = False
            PanelCostoTejeduriaRESTO.Visible = True

            gbCalculo.Text = "Cálculo del Costo del Artículo " + dgvArticulos.Rows(FilaDGV).Cells("ARTICULO").Value

            lblSemanasConfTejeduria.Text = dgvArticulos.Rows(FilaDGV).Cells("SEMANASCONFIGTEJEDURIA").Value.ToString

            lblCantMaquinasTejeduria.Text = Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("CANTMAQUINASTEJEDURIA").Value), "0")

            lblCantPersonasTejeduria.Text = Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("CANTIDADPERSONASTEJEDURIA").Value), "0")

            lblTotalSueldosTejeduria.Text = Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("TOTALSUELDOSTEJEDURIA").Value), "0.00")

            lblCantMinutosArticulo.Text = Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("MINUTOSDELARTICULO").Value), "0")

            lblCantHorasDelMes.Text = Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("CANTIDADHORASDELMES").Value), "0")

            lblTitCostoPorMinutoTejeduria.Text = "$ por minuto de Tejeduría (" + Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("TOTALSUELDOSTEJEDURIA").Value), "0.00") + "/" + Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("CANTIDADHORASDELMES").Value), "0") + "/60)"
            lblCostoPorMinutoTejeduria.Text = Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("TOTALSUELDOSTEJEDURIA").Value) / CDbl(dgvArticulos.Rows(FilaDGV).Cells("CANTIDADHORASDELMES").Value) / 60, "0.00")

            lblTitCostoPorMinutoPorPrenda.Text = "$ por minuto de 1 Prenda (" + Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("TOTALSUELDOSTEJEDURIA").Value) / CDbl(dgvArticulos.Rows(FilaDGV).Cells("CANTIDADHORASDELMES").Value) / 60, "0.00") + "/" + Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("CANTMAQUINASTEJEDURIA").Value), "0") + ")"
            lblCostoPorMinutoPorPrenda.Text = Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("TOTALSUELDOSTEJEDURIA").Value) / CDbl(dgvArticulos.Rows(FilaDGV).Cells("CANTIDADHORASDELMES").Value) / 60 / CDbl(dgvArticulos.Rows(FilaDGV).Cells("CANTMAQUINASTEJEDURIA").Value), "0.00")

            lblCostoMOdelArticulo.Text = Format((CDbl(dgvArticulos.Rows(FilaDGV).Cells("TOTALSUELDOSTEJEDURIA").Value) / CDbl(dgvArticulos.Rows(FilaDGV).Cells("CANTIDADHORASDELMES").Value) / 60 / CDbl(dgvArticulos.Rows(FilaDGV).Cells("CANTMAQUINASTEJEDURIA").Value)) * CDbl(dgvArticulos.Rows(FilaDGV).Cells("MINUTOSDELARTICULO").Value), "0.00")

            lblCostoManoObraConCargasSociales.Text = "COSTO MO + CS: " + Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("COSTOMOMASCARGASSOCIALES").Value), "0.00")

            lblCostoKiloHilado.Text = "$ por Kilo HILADO: " + Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("COSTOKILODEHILADO").Value), "0.00")
            lblCostoHilado.Text = "COSTO HILADO: " + Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("COSTOHILADO").Value), "0.00")

            lblCostoMateriales.Text = "COSTO MATERIALES: " + Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("MATERIALES").Value), "0.00")

            lblCostosIndirectos.Text = "COSTOS INDIRECTOS DE FABRICACIÓN: " + Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("COSTOSINDIRECTOS").Value), "0.00")

            lblCostoTeñido.Text = "COSTO TEÑIDO: " + Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("COSTOTEÑIDO").Value), "0.00")

            lblCostoTotal.Text = "TOTAL: " + Format(CDbl(dgvArticulos.Rows(FilaDGV).Cells("COSTOTOTAL").Value), "0.00")
        End If


    End Sub

    Private Sub btnVerTareas_Click(sender As Object, e As EventArgs) Handles btnVerArmado.Click
        If gbArmadoArticulo.Visible Then
            gbArmadoArticulo.Visible = False
            btnVerArmado.Text = "Ver Tareas Armado"
            If gbCalculo.Visible = False Then
                dgvArticulos.Width = 1170
            Else
                dgvArticulos.Width = 770
            End If
        Else
            If IsNothing(dgvArticulos.CurrentRow.Index) Then
                MensajeAtencion("Debe seleccionar un Artículo.")
            Else
                FiltrarListaDeTareas(dgvArticulos.Rows(dgvArticulos.CurrentRow.Index).Cells("ARTICULO").Value, dgvArticulos.CurrentRow.Index)
                btnVerArmado.Text = "Ocultar Tareas"
                gbArmadoArticulo.Visible = True
                gbCalculo.Visible = False
                btnVerCalculo.Text = "Ver Cálculo"
                gbCostosIndirectos.Visible = False
                btnVerCostosIndirectos.Text = "Ver Costos Indirectos"
                gbCalculoCostoRubros.Visible = False
                btnVerCostosRubros.Text = "Ver Costos Rubros"
                gbMaterialesArticulo.Visible = False
                btnVerMateriales.Text = "Ver Materiales"
                dgvArticulos.Width = 900
            End If
        End If
    End Sub

    Private Sub btnVerCalculo_Click(sender As Object, e As EventArgs) Handles btnVerCalculo.Click
        If gbCalculo.Visible Then
            gbCalculo.Visible = False
            btnVerCalculo.Text = "Ver Cálculo"
            If gbArmadoArticulo.Visible = False Then
                dgvArticulos.Width = 1170
            Else
                dgvArticulos.Width = 770
            End If
        Else
            If IsNothing(dgvArticulos.CurrentRow.Index) Then
                MensajeAtencion("Debe seleccionar un Artículo.")
            Else
                FiltrarCalculo(dgvArticulos.CurrentRow.Index)
                btnVerCalculo.Text = "Ocultar Cálculo"
                gbCalculo.Visible = True
                gbArmadoArticulo.Visible = False
                btnVerArmado.Text = "Ver Tareas Armado"
                gbCostosIndirectos.Visible = False
                btnVerCostosIndirectos.Text = "Ver Costos Indirectos"
                gbCalculoCostoRubros.Visible = False
                btnVerCostosRubros.Text = "Ver Costos Rubros"
                gbMaterialesArticulo.Visible = False
                btnVerMateriales.Text = "Ver Materiales"
                dgvArticulos.Width = 770
            End If
        End If
    End Sub

    Private Sub btnVerCostosIndirectos_Click(sender As Object, e As EventArgs) Handles btnVerCostosIndirectos.Click
        If gbCostosIndirectos.Visible Then
            gbCostosIndirectos.Visible = False
            btnVerCostosIndirectos.Text = "Ver Costos Indirectos"
            dgvArticulos.Width = 1170
        Else
            btnVerCostosIndirectos.Text = "Ocultar Costos Indirectos"
            gbCostosIndirectos.Visible = True
            gbArmadoArticulo.Visible = False
            btnVerArmado.Text = "Ver Tareas Armado"
            gbCalculo.Visible = False
            btnVerCalculo.Text = "Ver Cálculo"
            gbCalculoCostoRubros.Visible = False
            btnVerCostosRubros.Text = "Ver Costos Rubros"
            gbMaterialesArticulo.Visible = False
            btnVerMateriales.Text = "Ver Materiales"
            dgvArticulos.Width = 770
        End If
    End Sub

    Private Sub btnVerCostosRubros_Click(sender As Object, e As EventArgs) Handles btnVerCostosRubros.Click
        If gbCalculoCostoRubros.Visible Then
            gbCalculoCostoRubros.Visible = False
            btnVerCostosRubros.Text = "Ver Costos Rubros"
            dgvArticulos.Width = 1170
        Else
            btnVerCostosRubros.Text = "Ocultar Costos Rubros"
            gbCalculoCostoRubros.Visible = True
            gbArmadoArticulo.Visible = False
            btnVerArmado.Text = "Ver Tareas Armado"
            gbCalculo.Visible = False
            btnVerCalculo.Text = "Ver Cálculo"
            gbCostosIndirectos.Visible = False
            btnVerCostosIndirectos.Text = "Ver Costos Indirectos"
            gbMaterialesArticulo.Visible = False
            btnVerMateriales.Text = "Ver Materiales"
            dgvArticulos.Width = 900
        End If
    End Sub

    Private Sub btnVerMateriales_Click(sender As Object, e As EventArgs) Handles btnVerMateriales.Click
        If gbMaterialesArticulo.Visible Then
            gbMaterialesArticulo.Visible = False
            btnVerMateriales.Text = "Ver Materiales"
            dgvArticulos.Width = 1170
        Else
            If IsNothing(dgvArticulos.CurrentRow.Index) Then
                MensajeAtencion("Debe seleccionar un Artículo.")
            Else
                FiltrarListaDeMateriales(dgvArticulos.Rows(dgvArticulos.CurrentRow.Index).Cells("ARTICULO").Value, dgvArticulos.CurrentRow.Index)
                btnVerMateriales.Text = "Ocultar Materiales"
                gbMaterialesArticulo.Visible = True
                gbArmadoArticulo.Visible = False
                btnVerArmado.Text = "Ver Tareas Armado"
                gbCalculo.Visible = False
                btnVerCalculo.Text = "Ver Cálculo"
                gbCostosIndirectos.Visible = False
                btnVerCostosIndirectos.Text = "Ver Costos Indirectos"
                gbCalculoCostoRubros.Visible = False
                btnVerCostosRubros.Text = "Ver Costos Rubros"
                dgvArticulos.Width = 900
            End If
        End If
    End Sub

    Private Function FiltrarTareaDelArticulo(ByVal CodArti As String, ByVal CodTarea As String)
        Dim retorno As Boolean
        retorno = True
        If CodArti = "960" Then
            If CodTarea = "918" Then
                retorno = False
            End If
        ElseIf CodArti = "961" Then
            If CodTarea = "918" Then
                retorno = False
            End If
        ElseIf CodArti = "962" Or CodArti = "963" Or CodArti = "964" Then
            If CodTarea = "918" Then
                retorno = False
            End If
        ElseIf CodArti = "967" Or CodArti = "968" Or CodArti = "969" Then
            If CodTarea = "918" Then
                retorno = False
            End If
        ElseIf CodArti = "970" Or CodArti = "971" Or CodArti = "972" Then
            If CodTarea = "918" Then
                retorno = False
            End If
        ElseIf CodArti = "973" Then
            If CodTarea = "918" Or CodTarea = "821" Or CodTarea = "850" Then
                retorno = False
            End If
        ElseIf CodArti = "974" Then
            If CodTarea = "918" Or CodTarea = "821" Or CodTarea = "850" Then
                retorno = False
            End If
        ElseIf CodArti = "974" Then
            If CodTarea = "918" Or CodTarea = "821" Or CodTarea = "850" Then
                retorno = False
            End If
        ElseIf CodArti = "975" Or CodArti = "976" Or CodArti = "977" Or CodArti = "978" Or CodArti = "979" Or CodArti = "980" Then
            If CodTarea = "918" Then
                retorno = False
            End If
        ElseIf CodArti = "981" Or CodArti = "982" Then
            If CodTarea = "918" Then
                retorno = False
            End If
        ElseIf CodArti = "983" Or CodArti = "984" Or CodArti = "985" Or CodArti = "986" Then
            If CodTarea = "918" Or CodTarea = "821" Or CodTarea = "850" Then
                retorno = False
            End If
        ElseIf CodArti = "987" Then
            If CodTarea = "505" Or CodTarea = "820" Or CodTarea = "932" Then
                retorno = False
            End If
        ElseIf CodArti = "988" Or CodArti = "989" Then
            If CodTarea = "918" Or CodTarea = "821" Or CodTarea = "850" Then
                retorno = False
            End If
        ElseIf CodArti = "990" Then
            If CodTarea = "918" Then
                retorno = False
            End If
        ElseIf CodArti = "991" Or CodArti = "992" Or CodArti = "993" Or CodArti = "994" Or CodArti = "995" Then
            If CodTarea = "918" Then
                retorno = False
            End If
        End If

        FiltrarTareaDelArticulo = retorno
    End Function

    Private Sub cmbPROD_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPROD.SelectedIndexChanged
        If cmbPROD.Text <> "CORTE" Then
            cmbTipoLisoSublimado.SelectedIndex = 0
            cmbTipoLisoSublimado.Enabled = False
        Else
            cmbTipoLisoSublimado.SelectedIndex = 1
            cmbTipoLisoSublimado.Enabled = True
        End If
    End Sub

    '##################################### FUNCIONES #######################################################################
    '#######################################################################################################################

    Private Function ObtenerCotizacionDolar() As Double
        Dim CotizDolar As Double = 0.0
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String
        sStr = "SELECT * FROM HilamarMonedas WHERE Nombre = 'Dolares'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                CotizDolar = Reader.Item("Cotizacion")
            End If
        End If
        Return CotizDolar
    End Function

    Private Function ObtengoDescripcionDelElemento(ByVal Tipo As String, ByVal IdComp As String) As String
        Dim CommandAux As New SqlCommand
        Dim ReaderAux As SqlDataReader
        Dim sStrAux As String

        Dim Retorno As String = ""
        If Tipo = "MP" Then
            sStrAux = "SELECT * FROM HilamarMateriasPrimas WHERE Id = " + IdComp + ""
            CommandAux = New SqlCommand(sStrAux, cConexionApp.SQLConn)
            ReaderAux = CommandAux.ExecuteReader()
            If ReaderAux.HasRows Then
                If ReaderAux.Read Then
                    Retorno = ReaderAux.Item("Descripcion")
                End If
            End If
        ElseIf Tipo = "PG" Then
            If IdComp = "HH" Then
                Retorno = "Horas Hombre"
            ElseIf IdComp = "GAS" Then
                Retorno = "GAS"
            ElseIf IdComp = "LUZ" Then
                Retorno = "LUZ"
            ElseIf IdComp = "OS" Then
                Retorno = "OBRAS SANITARIAS"
            End If
        ElseIf Tipo = "PR" Then
            sStrAux = "SELECT * FROM HilamarProcesos WHERE Id = " + IdComp + ""
            CommandAux = New SqlCommand(sStrAux, cConexionApp.SQLConn)
            ReaderAux = CommandAux.ExecuteReader()
            If ReaderAux.HasRows Then
                If ReaderAux.Read Then
                    Retorno = ReaderAux.Item("Descripcion")
                End If
            End If
        ElseIf Tipo = "HI" Then
            sStrAux = "SELECT * FROM HilamarHilados WHERE Id = " + IdComp + ""
            CommandAux = New SqlCommand(sStrAux, cConexionApp.SQLConn)
            ReaderAux = CommandAux.ExecuteReader()
            If ReaderAux.HasRows Then
                If ReaderAux.Read Then
                    Retorno = ReaderAux.Item("Descripcion")
                End If
            End If
        ElseIf Tipo = "IN" Then
            sStrAux = "SELECT * FROM HilamarHiladosInternos WHERE Id = " + IdComp + ""
            CommandAux = New SqlCommand(sStrAux, cConexionApp.SQLConn)
            ReaderAux = CommandAux.ExecuteReader()
            If ReaderAux.HasRows Then
                If ReaderAux.Read Then
                    Retorno = ReaderAux.Item("Descripcion")
                End If
            End If
        End If
        ObtengoDescripcionDelElemento = Retorno
    End Function


    Public Sub CargarSueldosTejeduria()
        Dim IdEncabezado As String = ""
        Dim row As String()

        dgvSueldosTejeduria.Rows.Clear()
        dgvSueldosTejeduria.Columns.Clear()

        dgvSueldosTejeduria.Columns.Add("LEGAJO", "LEGAJO")
        dgvSueldosTejeduria.Columns("LEGAJO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvSueldosTejeduria.Columns("LEGAJO").Width = 80
        dgvSueldosTejeduria.Columns("LEGAJO").ReadOnly = True
        dgvSueldosTejeduria.Columns.Add("SUELDO", "SUELDO")
        dgvSueldosTejeduria.Columns("SUELDO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvSueldosTejeduria.Columns("SUELDO").Width = 80
        dgvSueldosTejeduria.Columns("SUELDO").ReadOnly = True


        sStr = "SELECT max(id) as ID FROM CostosExcelCargasSocialesEnc"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                IdEncabezado = Reader.Item("ID")
            End If
        End If

        sStr = "SELECT * FROM CostosExcelCargasSocialesDet where IdEncabezado=" + IdEncabezado
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read
                row = {Reader.Item("NroLegajo").ToString, Reader.Item("SueldoBruto").ToString}
                dgvSueldosTejeduria.Rows.Add(row)
            Loop
            Reader.NextResult()
        Loop

    End Sub

    Private Function ObtengoSueldoLegajo(ByVal NroLegajo As String) As String
        Dim ValorDevuelto As String = ""
        Dim i As Integer

        For i = 0 To dgvSueldosTejeduria.RowCount - 1
            If dgvSueldosTejeduria.Rows(i).Cells("LEGAJO").Value.ToString = NroLegajo Then
                ValorDevuelto = dgvSueldosTejeduria.Rows(i).Cells("SUELDO").Value.ToString
                Exit For
            End If
        Next

        Return ValorDevuelto
    End Function

    Private Sub btnRecuperarExcelCargasSociales_Click(sender As Object, e As EventArgs) Handles btnRecuperarExcelCargasSociales.Click
        RecuperarExcelCargasSocialesDelMesAnterior()
    End Sub

    Private Sub RecuperarExcelCargasSocialesDelMesAnterior()
        Dim totalfilas As Integer
        Dim IdEncabezado As String = ""

        'primero me traigo el excel de la carpeta de julia
        Dim ArchivoExcelJulia As String = "\\Pcjulia\c_julia\Documentos\PERSONAL\Cargas Sociales\TEXTILANA\2018\cargas sociales " + Format(DateSerial(Now.Year, Now.Month, 0), "yyyy-MM") + ".xls"
        Dim ArchivoExcelStock As String = "C:\Stock.Net\Excel\cargas sociales " + Format(DateSerial(Now.Year, Now.Month, 0), "yyyy-MM") + ".xls"

        If Not Directory.Exists(Application.StartupPath + "\Excel") Then Directory.CreateDirectory(Application.StartupPath + "\Excel")

        If Not File.Exists(ArchivoExcelStock) Then
            File.Copy(ArchivoExcelJulia, ArchivoExcelStock, True)
        End If

        sStr = "INSERT INTO CostosExcelCargasSocialesEnc (AnioMes, FechaRecupero) VALUES ('" + Format(DateSerial(Now.Year, Now.Month, 0), "yyyyMM") + "', getdate())"
        Command = New SqlCommand(sStr, cConexion.SQLConn)
        Command.ExecuteNonQuery()
        sStr = "SELECT max(id) as ID FROM CostosExcelCargasSocialesEnc"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                IdEncabezado = Reader.Item("ID")
            End If
        End If

        If IdEncabezado = "" Then
            MensajeAtencion("No se pudo grabar el detalle del Excel de Cargas Sociales. Verifique.")
            Exit Sub
        End If

        '~~> Define your Excel Objects
        Dim xlApp As New Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As New Excel.Worksheet
        '~~> Opens Source Workbook. Change path and filename as applicable
        xlWorkBook = xlApp.Workbooks.Open(ArchivoExcelStock, False, , , "1980")
        '~~> Do some work
        xlWorkSheet = xlWorkBook.Worksheets("AOT")

        Dim xlHWND As Integer = xlApp.Hwnd
        Dim ProcIDXL As Integer = 0
        'get the process ID
        GetWindowThreadProcessId(xlHWND, ProcIDXL)

        ' primero que nada tengo que saber cuantas filas son asi se hasta donde hacer el for y de paso se el tamaño de la barra de progreso
        totalfilas = 2
        Do While Not IsNothing(xlWorkSheet.Cells(totalfilas, 5).Value())
            totalfilas = totalfilas + 1

            If Not IsNothing(xlWorkSheet.Cells(totalfilas, 5).Value()) Then
                If xlWorkSheet.Cells(totalfilas, 5).Value().ToString = "901" Then

                    sStr = "INSERT INTO CostosExcelCargasSocialesDet (IdEncabezado, NroLegajo, NombreEmpleado, SueldoBruto) VALUES (" + IdEncabezado
                    sStr = sStr + ", '" + xlWorkSheet.Cells(totalfilas, 2).Value().ToString + "','" + xlWorkSheet.Cells(totalfilas, 3).Value().ToString
                    sStr = sStr + "'," + xlWorkSheet.Cells(totalfilas, 11).Value().ToString.Replace(",", ".") + ")"
                    Command = New SqlCommand(sStr, cConexion.SQLConn)
                    Command.ExecuteNonQuery()

                End If
            End If

        Loop

        'poner un filtro
        'Dim objRango As Excel.Range = xlWorkSheet.Range("A1:AS" & (totalfilas - 1).ToString)
        'objRango.Select()
        'objRango.AutoFilter(1, , VisibleDropDown:=True)
        'quitar un filtro
        'xlWorkSheet.AutoFilterMode = False

        CerrarProcesoId(ProcIDXL)

        MensajeAtencion("Se Importó exitosamente el Excel de Cargas Sociales del mes " + Format(DateSerial(Now.Year, Now.Month, 0), "MM/yyyy"))

    End Sub

    Private Sub btnRecalcularCostos_Click(sender As Object, e As EventArgs) Handles btnRecalcularCostos.Click
        ReConectar("AppTextilana")
        CalcularCostosyCargarListado(False)
    End Sub

    Private Sub btnVerColSinCS_Click(sender As Object, e As EventArgs) Handles btnVerColSinCS.Click
        If btnVerColSinCS.Text = "Ver Col Sin C/S" Then
            dgvArticulos.Columns("COSTOARMADO").Visible = True
            dgvArticulos.Columns("COSTOMO").Visible = True
            btnVerColSinCS.Text = "Ocultar Col Sin C/S"
        Else
            dgvArticulos.Columns("COSTOARMADO").Visible = False
            dgvArticulos.Columns("COSTOMO").Visible = False
            btnVerColSinCS.Text = "Ver Col Sin C/S"
        End If
    End Sub

End Class