Imports System.Data.SqlClient


Public Class frmRepoHiladoTextiStock
    Private Command As New SqlCommand
    Private Reader As SqlDataReader
    Dim sStr As String

    Dim LegajoLogueado As String 'legajo de quien va a trabajar
    Dim TipoUsuario As String ' Tipo de usuario que va a trabajar, lo voy a usar para saber que le habilito a usar y que no

    Sub New(ByVal parametro1 As String, ByVal parametro2 As String)

        InitializeComponent() 'es necesario que lleve esta linea

        LegajoLogueado = parametro1
        TipoUsuario = parametro2

    End Sub

    Public Sub Cargar()
        CargarComboFiltroPedidos()
        CargarListado()

        If TipoUsuario = "TextiAdmin" Then
            btnTerminar.Enabled = True
        Else
            btnTerminar.Enabled = False
        End If

        'tambien muestro cual es la fecha del ultimo movimiento cargado como ingreso
        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        sStr = "SELECT max(fecha) as fecha FROM HilamarStockTextiMovimientos "
        sStr = sStr + " WHERE isnull(Eliminado,0)=0 "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                lblFechaUltimoMovimiento.Text = "Último movimiento cargado el día " + Format(Reader.Item("fecha"), "dd/MM/yyyy")
            End If
        End If

    End Sub

    Private Sub CargarComboFiltroPedidos()
        cmbFiltroPedidos.Items.Clear()
        cmbFiltroPedidos.Items.Add("TODAS")
        cmbFiltroPedidos.Items.Add("INGRESADA")
        cmbFiltroPedidos.Items.Add("FINALIZADA")
        If cmbFiltroPedidos.Items.Count > 0 Then cmbFiltroPedidos.SelectedIndex = 0
    End Sub

    Private Sub CargarListado()
        Dim Command2 As New SqlCommand
        Dim Reader2 As SqlDataReader
        Dim sStr2 As String

        Dim FechaDesde, FechaHasta As String

        Dim FechaUltMov As String = ""
        Dim TotalConsumo As String = ""
        Dim FinPartida As String = ""
        Dim Terminada As String = ""
        Dim FechaTerm As String = ""

        Dim row As String()

        limpiaryarmardgvPartidas()

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        sStr = "SELECT count(*) as canti FROM HilamarHiladoTextiStock "
        sStr = sStr + " WHERE Eliminado = 0 "
        If chkVerTerminadas.Checked = False Then sStr = sStr + " AND Terminada=0 "
        If txtPartida.Text <> "" Then sStr = sStr & " AND PARTIDA LIKE '%" & txtPartida.Text & "%' "

        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Reader.Read()
        If Reader.Item("canti") > 0 Then
            sStr = "SELECT * FROM HilamarHiladoTextiStock "
            sStr = sStr + " WHERE Eliminado=0"
            If chkVerTerminadas.Checked = False Then sStr = sStr + " AND Terminada=0 "
            If txtPartida.Text <> "" Then sStr = sStr & " AND PARTIDA LIKE '%" & txtPartida.Text & "%' "

            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            Do While Reader.HasRows
                Do While Reader.Read
                    If Reader.Item("FinDePartida").ToString = "1" Then
                        FinPartida = "SI"
                    Else
                        FinPartida = ""
                    End If
                    If Reader.Item("Terminada").ToString = "1" Then
                        Terminada = "SI"
                        FechaTerm = Format(Reader.Item("FechaTerminada"), "yyyyMMdd")
                    Else
                        Terminada = ""
                        FechaTerm = ""
                    End If

                    'primero tengo que definir las fechas desde y hasta entre las que buscare las Ops correspondientes
                    FechaDesde = "19000101"
                    sStr2 = "select isnull(FechaTerminada,'19000101') as FechaDesde from HilamarHiladoTextiStock where Eliminado=0 and Id<" + Reader.Item("Id").ToString
                    sStr2 = sStr2 & " and Partida ='" + Reader.Item("Partida").ToString + "' order by id desc"
                    Command2 = New SqlCommand(sStr2, cConexionApp.SQLConn)
                    Reader2 = Command2.ExecuteReader()
                    If Reader2.HasRows Then
                        If Reader2.Read Then
                            FechaDesde = Format(Reader2.Item("FechaDesde"), "yyyyMMdd")
                        End If
                    End If

                    FechaHasta = "21000101"
                    If Terminada = "SI" Then
                        FechaHasta = FechaTerm
                    End If

                    TotalConsumo = ""
                    sStr2 = "select isnull(SUM(kilos),0) as TotalConsumo from PrendasOPPartidas P inner join PrendasOPs O on O.id = P.idOP "
                    sStr2 = sStr2 + "where P.Eliminado=0 and Partida like '%" + Reader.Item("Partida").ToString.Replace("H", "0") + "%'"
                    sStr2 = sStr2 & " AND Fecha between '" + FechaDesde + "'And '" + FechaHasta + "'"
                    Command2 = New SqlCommand(sStr2, cConexionApp.SQLConn)
                    Reader2 = Command2.ExecuteReader()
                    If Reader2.HasRows Then
                        If Reader2.Read() Then
                            TotalConsumo = Reader2.Item("TotalConsumo").ToString
                        End If
                    End If

                    FechaUltMov = ""
                    sStr2 = "select isnull(Max(Fecha),'') as Fecha from HilamarStockTextiMovimientos "
                    sStr2 = sStr2 + "where isnull(Eliminado,0)=0 and IdPartida =" + Reader.Item("Id").ToString + ""
                    Command2 = New SqlCommand(sStr2, cConexionApp.SQLConn)
                    Reader2 = Command2.ExecuteReader()
                    If Reader2.HasRows Then
                        If Reader2.Read() Then
                            FechaUltMov = Format(Reader2.Item("Fecha"), "dd/MM/yyyy")
                        End If
                    End If

                    row = {Reader.Item("Id").ToString, Reader.Item("Partida").ToString, Reader.Item("Color").ToString, Format(Reader.Item("Kilos"), "0.000"), Format(CDbl(TotalConsumo), "0.000"), Format(CDbl(Reader.Item("Kilos")) - CDbl(TotalConsumo), "0.000"), FechaUltMov, FinPartida, Terminada, FechaTerm}
                    dgvPartidas.Rows.Add(row)

                Loop
                Reader.NextResult()
            Loop

        End If

        'cuando termino de cargar el listado hago como un click en la primer fila asi muestra los ingresos y pedidos de la primer fila
        If dgvPartidas.RowCount > 0 Then
            'no hace falta ir a la primer fila porque al recargar el datagrid solito se posiciona en la primer fila
            MostrarMovimientosdelaPartida(dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells(0).Value.ToString, dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells(1).Value.ToString, dgvPartidas.CurrentRow.Index)
        End If
    End Sub

    Private Sub limpiaryarmardgvPartidas()
        dgvPartidas.Rows.Clear()
        dgvPartidas.Columns.Clear()
        dgvPartidas.Columns.Add("ID", "ID")
        dgvPartidas.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPartidas.Columns("ID").Visible = False
        dgvPartidas.Columns.Add("PARTIDA", "PARTIDA")
        dgvPartidas.Columns("PARTIDA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPartidas.Columns("PARTIDA").Width = 65
        dgvPartidas.Columns("PARTIDA").ReadOnly = True
        dgvPartidas.Columns.Add("COLOR", "COLOR")
        dgvPartidas.Columns("COLOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPartidas.Columns("COLOR").Width = 130
        dgvPartidas.Columns("COLOR").ReadOnly = True
        dgvPartidas.Columns.Add("INGRESOS", "INGRESOS")
        dgvPartidas.Columns("INGRESOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvPartidas.Columns("INGRESOS").Width = 70
        dgvPartidas.Columns("INGRESOS").ReadOnly = True
        dgvPartidas.Columns.Add("PEDIDOS", "PEDIDOS")
        dgvPartidas.Columns("PEDIDOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvPartidas.Columns("PEDIDOS").Width = 70
        dgvPartidas.Columns("PEDIDOS").ReadOnly = True
        dgvPartidas.Columns.Add("STOCK", "STOCK")
        dgvPartidas.Columns("STOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvPartidas.Columns("STOCK").Width = 70
        dgvPartidas.Columns("STOCK").ReadOnly = True
        dgvPartidas.Columns.Add("FECHAULTMOV", "ULTMOV")
        dgvPartidas.Columns("FECHAULTMOV").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPartidas.Columns("FECHAULTMOV").Width = 70
        dgvPartidas.Columns("FECHAULTMOV").ReadOnly = True
        dgvPartidas.Columns.Add("FINPARTIDA", "FIN")
        dgvPartidas.Columns("FINPARTIDA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPartidas.Columns("FINPARTIDA").Width = 30
        dgvPartidas.Columns("FINPARTIDA").ReadOnly = True
        dgvPartidas.Columns.Add("TERMINADA", "TERM")
        dgvPartidas.Columns("TERMINADA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPartidas.Columns("TERMINADA").Width = 42
        dgvPartidas.Columns("TERMINADA").ReadOnly = True
        dgvPartidas.Columns.Add("FECHATERM", "FECHATERM")
        dgvPartidas.Columns("FECHATERM").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPartidas.Columns("FECHATERM").Visible = False
    End Sub

    Private Sub cmdListar_Click(sender As Object, e As EventArgs) Handles cmdListar.Click
        CargarListado()
    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Close()
    End Sub

    Private Sub dgvPartidas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPartidas.CellClick
        MostrarMovimientosdelaPartida(dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells(0).Value.ToString, dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells(1).Value.ToString, dgvPartidas.CurrentRow.Index)
    End Sub

    Private Sub MostrarMovimientosdelaPartida(ByVal IdPartida As String, ByVal Partida As String, ByVal FilaDGV As Integer)
        Dim row As String()
        Dim TipoMov As String = ""
        Dim Acces As String = ""
        Dim Estado As String = ""
        Dim TotalIngDev, TotalPedidos As Double
        Dim FechaDesde, FechaHasta As String

        dgvIngresos.Rows.Clear()
        dgvIngresos.Columns.Clear()
        dgvIngresos.Columns.Add("FECHA", "FECHA")
        dgvIngresos.Columns("FECHA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvIngresos.Columns("FECHA").Width = 80
        dgvIngresos.Columns("FECHA").ReadOnly = True
        dgvIngresos.Columns.Add("TIPO", "TIPO")
        dgvIngresos.Columns("TIPO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvIngresos.Columns("TIPO").Width = 80
        dgvIngresos.Columns("TIPO").ReadOnly = True
        dgvIngresos.Columns.Add("KILOS", "KILOS")
        dgvIngresos.Columns("KILOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvIngresos.Columns("KILOS").Width = 70
        dgvIngresos.Columns("KILOS").ReadOnly = True
        dgvIngresos.Columns.Add("NROREMITO", "REMITO")
        dgvIngresos.Columns("NROREMITO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvIngresos.Columns("NROREMITO").Width = 75
        dgvIngresos.Columns("NROREMITO").ReadOnly = True
        dgvIngresos.Columns.Add("NROGUIA", "GUIA")
        dgvIngresos.Columns("NROGUIA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvIngresos.Columns("NROGUIA").Width = 65
        dgvIngresos.Columns("NROGUIA").ReadOnly = True

        TotalIngDev = 0
        sStr = "SELECT * FROM HilamarStockTextiMovimientos WHERE isnull(Eliminado,0)=0 and IdPartida=" + IdPartida
        sStr = sStr & " Order by Fecha "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read
                If Reader.Item("TipoMov").ToString = "I" Then
                    TipoMov = "INGRESO"
                Else
                    TipoMov = "DEVOLUCION"
                End If
                row = {Format(Reader.Item("Fecha"), "dd/MM/yyyy"), TipoMov, Format(Reader.Item("Kilos"), "0.000"), Reader.Item("NroRemito").ToString, Reader.Item("NroGuia").ToString}
                dgvIngresos.Rows.Add(row)
                TotalIngDev = TotalIngDev + CDbl(Reader.Item("Kilos"))
            Loop
            Reader.NextResult()
        Loop

        lblTotalIngresos.Text = "TOTAL DE INGRESOS Y DEVOLUCIONES: " + Format(TotalIngDev, "0.000") + " KGR."


        dgvPedidos.Rows.Clear()
        dgvPedidos.Columns.Clear()
        dgvPedidos.Columns.Add("OP", "OP")
        dgvPedidos.Columns("OP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPedidos.Columns("OP").Width = 70
        dgvPedidos.Columns("OP").ReadOnly = True
        dgvPedidos.Columns.Add("ARTICULO", "ARTICULO")
        dgvPedidos.Columns("ARTICULO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPedidos.Columns("ARTICULO").Width = 80
        dgvPedidos.Columns("ARTICULO").ReadOnly = True
        dgvPedidos.Columns.Add("ACC", "ACC")
        dgvPedidos.Columns("ACC").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvPedidos.Columns("ACC").Width = 50
        dgvPedidos.Columns("ACC").ReadOnly = True
        dgvPedidos.Columns.Add("KILOS", "KILOS")
        dgvPedidos.Columns("KILOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvPedidos.Columns("KILOS").Width = 70
        dgvPedidos.Columns("KILOS").ReadOnly = True
        dgvPedidos.Columns.Add("ESTADO", "ESTADO")
        dgvPedidos.Columns("ESTADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvPedidos.Columns("ESTADO").Width = 100
        dgvPedidos.Columns("ESTADO").ReadOnly = True

        'primero tengo que definir las fechas desde y hasta entre las que buscare las Ops correspondientes
        FechaDesde = "19000101"
        sStr = "select isnull(FechaTerminada,'19000101') as FechaDesde from HilamarHiladoTextiStock where Eliminado=0 and Id<" + IdPartida
        sStr = sStr & " and Partida ='" + Partida + "' order by id desc"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                FechaDesde = Format(Reader.Item("FechaDesde"), "yyyyMMdd")
            End If
        End If

        FechaHasta = "21000101"
        If dgvPartidas.Rows(FilaDGV).Cells("TERMINADA").Value.ToString = "SI" Then
            FechaHasta = dgvPartidas.Rows(FilaDGV).Cells("FECHATERM").Value.ToString
        End If

        TotalPedidos = 0
        sStr = "select isnull((select top 1 isnull(EstadoOP,0) from TejePlanificacion where idOP = P.idOP and EsOPA = P.Accesorio ),0) as ESTADO "
        sStr = sStr + ", * from PrendasOPPartidas P inner join PrendasOPs O on O.id = P.idOP "
        sStr = sStr + " where P.Eliminado=0 and Partida like '%" + Partida.Replace("H", "0") + "%'"
        sStr = sStr & " AND Fecha between '" + FechaDesde + "'And '" + FechaHasta + "'"
        sStr = sStr & " Order by OP,CodArticulo "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read
                If Reader.Item("Accesorio").ToString = "1" Then
                    Acces = "SI"
                Else
                    Acces = ""
                End If
                If Reader.Item("Estado").ToString = "0" Then
                    Estado = "INGRESADA"
                ElseIf Reader.Item("Estado").ToString = "1" Then
                    Estado = "PROGRAMADA"
                ElseIf Reader.Item("Estado").ToString = "2" Then
                    Estado = "FINALIZADA"
                Else
                    Estado = ""
                End If
                row = {Reader.Item("OP").ToString, Reader.Item("CodArticulo").ToString, Acces, Format(Reader.Item("Kilos"), "0.000"), Estado}
                dgvPedidos.Rows.Add(row)
                TotalPedidos = TotalPedidos + CDbl(Reader.Item("Kilos"))
            Loop
            Reader.NextResult()
        Loop

        lblTotalPedidos.Text = "TOTAL DE PEDIDOS: " + Format(TotalPedidos, "0.000") + " KGR."

        'cuando termino de mostrar los movimientos de la partida aplico el filtro en los pedidos de acuerdo a lo que puso en el combo
        FiltrarPedidosSegunCombo()

    End Sub

    Private Sub FiltrarPedidosSegunCombo()
        Dim i As Integer
        Dim TotalPedidos As Double

        If cmbFiltroPedidos.Text = "TODAS" Then
            For i = 0 To dgvPedidos.RowCount - 1
                dgvPedidos.Rows(i).Visible = True
            Next
        Else
            For i = 0 To dgvPedidos.RowCount - 1
                If dgvPedidos.Rows(i).Cells(4).Value.ToString = cmbFiltroPedidos.Text Then
                    dgvPedidos.Rows(i).Visible = True
                Else
                    dgvPedidos.Rows(i).Visible = False
                End If
            Next
        End If

        'cuando termino de filtrar muestro el total solo de los filtrados
        TotalPedidos = 0
        For i = 0 To dgvPedidos.RowCount - 1
            If dgvPedidos.Rows(i).Visible = True Then
                TotalPedidos = TotalPedidos + CDbl(dgvPedidos.Rows(i).Cells(3).Value.ToString)
            End If
        Next
        lblTotalPedidos.Text = "TOTAL DE PEDIDOS: " + Format(TotalPedidos, "0.000") + " KGR."

    End Sub

    Private Sub frmRepoHiladoTextiStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar()
    End Sub

    Private Sub cmbFiltroPedidos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFiltroPedidos.SelectedIndexChanged
        FiltrarPedidosSegunCombo()
    End Sub

    Private Sub chkVerTerminadas_CheckedChanged(sender As Object, e As EventArgs) Handles chkVerTerminadas.CheckedChanged
        CargarListado()
    End Sub

    Private Sub btnTerminar_Click(sender As Object, e As EventArgs) Handles btnTerminar.Click
        Terminar()
    End Sub
    Private Sub Terminar()
        If dgvPartidas.CurrentRow.Index < 0 Then Exit Sub

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        If dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("ID").Value.ToString <> "" Then
            sStr = "UPDATE HilamarHiladoTextiStock"
            sStr = sStr + " SET Terminada = 1, FechaTerminada=getdate() "
            sStr = sStr + " WHERE id = " + dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("ID").Value.ToString + ""
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()
            'ademas de terminar la partida, debo terminar el sobrante de hilado declarado si es que hay alguno
            sStr = "UPDATE HilamarHiladoTextiStockSobrante"
            sStr = sStr + " SET Terminado = 1, AuditoriaModif='" + Environment.MachineName + "|" + Now.ToString + "'"
            sStr = sStr + " WHERE idHiladoTextiStock = " + dgvPartidas.Rows(dgvPartidas.CurrentRow.Index).Cells("ID").Value.ToString + ""
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()
        End If

        MensajeAtencion("Se dió por terminada la Partida.")

        CargarListado()

    End Sub
End Class