Imports System.Data.SqlClient

Public Class frmHilaRepoIngyConsu
    Dim TipoListado As String 'Tipo de ventana que trabajará

    Sub New(ByVal parametro1 As String)
        InitializeComponent() 'es necesario que lleve esta linea
        TipoListado = parametro1
    End Sub

    Public Sub Cargarlistado()
        On Error GoTo ErrCargarlistado
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String
        Dim row As String()

        Dim CodHiladoCorte, DescHiladoCorte As String
        Dim TotalHilado As Long = 0
        Dim PrimerPasada As Boolean = True
        CodHiladoCorte = ""
        DescHiladoCorte = ""

        LimpiarDGV()
        ArmarDGV()

        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            MensajeAtencion("La Fecha Desde no puede ser mayor que la Fecha Hasta. Verifique.")
        End If

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        sStr = "SELECT CodTipoHilado,HI.Descripcion,E.Fecha,D.Partida,Color,D.Kilos,E.NroRemito "
        sStr = sStr + "FROM HilamarHiladoStockEncMov E INNER JOIN HilamarHiladoStockDetMov D ON E.TipoMov=D.TipoMov AND E.NroRemito=D.NroRemito "
        sStr = sStr + "inner join (SELECT * FROM HilamarHiladoStock where FechaStockHasta IS NULL) H on D.Partida = H.Partida "
        sStr = sStr + " INNER JOIN HilamarTipoHiladoPartidas HI ON HI.Codigo = H.CodTipoHilado "
        sStr = sStr + "WHERE Isnull(E.Eliminado,0)=0 AND Isnull(D.Eliminado,0)=0 AND Fecha BETWEEN '" + Format(dtpFechaDesde.Value, "yyyyMMdd") + "' AND '" + Format(dtpFechaHasta.Value, "yyyyMMdd") + "' "

        If txtFiltroPartida.Text <> "" Then
            sStr = sStr + " AND D.Partida like '%" + txtFiltroPartida.Text + "%' "
        End If
        If txtFiltroHilado.Text <> "" Then
            sStr = sStr + " AND D.Partida IN (SELECT PARTIDA FROM HilamarHiladoStock WHERE CodTipoHilado LIKE '%" + txtFiltroHilado.Text + "%' ) "
        End If

        If TipoListado = "ingresos" Then
            sStr = sStr + " AND E.TipoMov = 'I'"
        ElseIf TipoListado = "consumos" Then
            sStr = sStr + " AND E.TipoMov in ('C','E') "
        End If

        sStr = sStr + "order by H.CodTipoHilado,E.Fecha,E.TipoMov,cast(E.NroRemito as float),D.Partida "

        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                If PrimerPasada Then
                    CodHiladoCorte = Reader.Item("CodTipoHilado").ToString
                    DescHiladoCorte = Reader.Item("Descripcion").ToString
                    TotalHilado = 0
                    PrimerPasada = False
                End If
                If CodHiladoCorte <> Reader.Item("CodTipoHilado").ToString Then
                    row = {"", "HILADO: " + CodHiladoCorte, DescHiladoCorte, "", TotalHilado}
                    dgvMovimientos.Rows.Add(row)
                    dgvMovimientos.Rows(dgvMovimientos.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGray
                    CodHiladoCorte = Reader.Item("CodTipoHilado").ToString
                    DescHiladoCorte = Reader.Item("Descripcion").ToString
                    TotalHilado = 0
                End If
                row = {Format(Reader.Item("Fecha"), "dd/MM/yyyy"), Reader.Item("Partida").ToString, Reader.Item("CoLOR").ToString, Reader.Item("NroRemito").ToString, Reader.Item("Kilos").ToString}
                dgvMovimientos.Rows.Add(row)
                TotalHilado = TotalHilado + Reader.Item("Kilos")
            Loop
            Reader.NextResult()
        Loop
        If CodHiladoCorte <> "" Then
            row = {"", "HILADO: " + CodHiladoCorte, DescHiladoCorte, "", TotalHilado}
            dgvMovimientos.Rows.Add(row)
            dgvMovimientos.Rows(dgvMovimientos.RowCount - 1).DefaultCellStyle.BackColor = Color.LightGray
        End If

        Exit Sub
ErrCargarlistado:
        MensajeCritico("Error al cargar el listado." + Chr(10) + Err.Description)
    End Sub

    Private Sub LimpiarDGV()
        dgvMovimientos.Rows.Clear()
        dgvMovimientos.Columns.Clear()
    End Sub

    Private Sub ArmarDGV()
        dgvMovimientos.Columns.Add("FECHA", "FECHA")
        dgvMovimientos.Columns("FECHA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvMovimientos.Columns("FECHA").Width = 80
        dgvMovimientos.Columns("FECHA").ReadOnly = True
        dgvMovimientos.Columns.Add("PARTIDA", "PARTIDA")
        dgvMovimientos.Columns("PARTIDA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvMovimientos.Columns("PARTIDA").Width = 100
        dgvMovimientos.Columns("PARTIDA").DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvMovimientos.Columns("PARTIDA").ReadOnly = True
        dgvMovimientos.Columns.Add("COLOR", "COLOR")
        dgvMovimientos.Columns("COLOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvMovimientos.Columns("COLOR").Width = 220
        dgvMovimientos.Columns("COLOR").ReadOnly = True
        dgvMovimientos.Columns.Add("REMITO", "REMITO")
        dgvMovimientos.Columns("REMITO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMovimientos.Columns("REMITO").Width = 85
        dgvMovimientos.Columns("REMITO").ReadOnly = True
        dgvMovimientos.Columns.Add("KILOS", "KILOS")
        dgvMovimientos.Columns("KILOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMovimientos.Columns("KILOS").Width = 90
        dgvMovimientos.Columns("KILOS").ReadOnly = True

        dgvMovimientos.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8)
        dgvMovimientos.DefaultCellStyle.Font = New Font("Tahoma", 8)
        dgvMovimientos.RowTemplate.Height = 25

    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Close()
    End Sub

    Private Sub cmdListar_Click(sender As Object, e As EventArgs) Handles cmdListar.Click
        Cargarlistado()
    End Sub

    Private Sub frmHilaRepoIngyConsu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFechaDesde.Value = Now
        dtpFechaHasta.Value = Now
        If TipoListado = "ingresos" Then
            Me.Text = "Reporte de Ingresos de Hilados"
        ElseIf TipoListado = "consumos" Then
            Me.Text = "Reporte de Egresos y Consumos de Hilados"
        End If
    End Sub
End Class