Imports System.Data.SqlClient

Public Class frmHilaPartidasYCommodities

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        armarDgvHilados()
        cargarDgvHilados()
    End Sub

    Private Sub armarDgvHilados()
        dgvHilados.Rows.Clear()
        dgvHilados.Columns.Clear()

        dgvHilados.Columns.Add("HILADO", "HILADO")
        dgvHilados.Columns("HILADO").Width = 250

        dgvHilados.Columns.Add("KILOS", "KILOS")
        dgvHilados.Columns("KILOS").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill


    End Sub

    Private Sub cargarDgvHilados()
        Dim Command As SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String


        sStr = "SELECT Prueba.Hilado,SUM(Prueba.Kilos + Prueba.KilosInicial) AS Kilos FROM (SELECT  ISNULL((SELECT Descripcion FROM HilamarTipoHiladoPartidas WHERE Codigo = S.CodTipoHilado ),'SIN DEFINIR') AS Hilado,SUM(ISNULL(D.Kilos* (CASE D.TipoMov WHEN 'DI' THEN 1 WHEN 'I' THEN 1 WHEN 'C' THEN -1 WHEN 'E' THEN -1 END),0))  AS Kilos, S.Kilos AS KilosInicial FROM HilamarHiladoStock S INNER JOIN HilamarHiladoStockDetMov D ON S.Partida = D.Partida WHERE  (S.Eliminado=0 OR S.Eliminado is NULL) AND (D.Eliminado = 0 OR D.Eliminado is NULL)  GROUP BY S.CodTipoHilado,S.Kilos) AS Prueba WHERE Kilos > 0 Group BY Prueba.Hilado "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader

        While Reader.Read
            dgvHilados.Rows.Add(Reader.Item("Hilado").ToString, Reader.Item("Kilos").ToString)
        End While

    End Sub

    Private Sub armarDgvPartidas()
        dgvPartidas.Rows.Clear()
        dgvPartidas.Columns.Clear()


        dgvPartidas.Columns.Add("PARTIDA", "PARTIDA")
        dgvPartidas.Columns("PARTIDA").Width = 150

        dgvPartidas.Columns.Add("COLOR", "COLOR")
        dgvPartidas.Columns("COLOR").Width = 300

        dgvPartidas.Columns.Add("KILOS", "KILOS")
        dgvPartidas.Columns("KILOS").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub cargarDgvPartidas(ByVal Hilado As String)
        Dim Reader As SqlDataReader
        Dim Command As SqlCommand
        Dim sStr As String

        sStr = "SELECT Prueba.Hilado,Partida,Prueba.Color,SUM(Prueba.Kilos + Prueba.KilosInicial) AS Kilos FROM (SELECT  ISNULL((SELECT Descripcion FROM HilamarTipoHiladoPartidas WHERE Codigo = S.CodTipoHilado ),'SIN DEFINIR') AS Hilado,S.Partida,SUM(ISNULL(D.Kilos* (CASE D.TipoMov WHEN 'DI' THEN 1 WHEN 'I' THEN 1 WHEN 'C' THEN -1 WHEN 'E' THEN -1 END),0))  AS Kilos,Color , S.Kilos AS KilosInicial FROM HilamarHiladoStock S INNER JOIN HilamarHiladoStockDetMov D ON S.Partida = D.Partida WHERE (S.Eliminado=0 OR S.Eliminado is NULL) AND (D.Eliminado = 0 OR D.Eliminado is NULL)  GROUP BY S.Partida,S.CodTipoHilado,S.Color,S.Kilos) AS Prueba WHERE Hilado = '" + Hilado.ToString + "' AND Kilos > 0 Group BY Partida,Prueba.Hilado,Prueba.Color Order By Partida ASC"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader

        While Reader.Read
            dgvPartidas.Rows.Add(Reader.Item("Partida").ToString, Reader.Item("Color"), Reader.Item("Kilos").ToString)
        End While
    End Sub

    Private Sub dgvHilados_Click(sender As Object, e As EventArgs) Handles dgvHilados.Click
        armarDgvPartidas()
        cargarDgvPartidas(dgvHilados.SelectedRows(0).Cells("HILADO").Value.ToString)
    End Sub


End Class