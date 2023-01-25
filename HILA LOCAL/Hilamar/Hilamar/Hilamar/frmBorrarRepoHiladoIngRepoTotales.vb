Imports System.Data.SqlClient


Public Class frmBorrarRepoHiladoIngRepoTotales
    Private Command As New SqlCommand
    Private Reader As SqlDataReader
    Dim sStr As String


    Public Sub Cargar()
        cargarComboMeses()

        rbDiario.Checked = True
    End Sub

    Private Sub cargarComboMeses()
        cmbMeses.Items.Clear()
        cmbMeses.Items.Add("ENERO")
        cmbMeses.Items.Add("FEBRERO")
        cmbMeses.Items.Add("MARZO")
        cmbMeses.Items.Add("ABRIL")
        cmbMeses.Items.Add("MAYO")
        cmbMeses.Items.Add("JUNIO")
        cmbMeses.Items.Add("JULIO")
        cmbMeses.Items.Add("AGOSTO")
        cmbMeses.Items.Add("SEPTIEMBRE")
        cmbMeses.Items.Add("OCTUBRE")
        cmbMeses.Items.Add("NOVIEMBRE")
        cmbMeses.Items.Add("DICIEMBRE")
        cmbMeses.Text = MonthName(Now.Month, False)
    End Sub

    Private Sub CargarListadoDiario()
        Dim i As Integer
        Dim Columna As String

        Dim row As String()

        dgvMovimientos.Rows.Clear()
        dgvMovimientos.Columns.Clear()
        dgvMovimientos.Columns.Add("FECHA", "DIA")
        dgvMovimientos.Columns("FECHA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvMovimientos.Columns("FECHA").Width = 75
        dgvMovimientos.Columns("FECHA").ReadOnly = True
        dgvMovimientos.Columns.Add("HILADO", "HILADO")
        dgvMovimientos.Columns("HILADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMovimientos.Columns("HILADO").Width = 75
        dgvMovimientos.Columns("HILADO").ReadOnly = True
        dgvMovimientos.Columns.Add("COSTURA", "COSTURA")
        dgvMovimientos.Columns("COSTURA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMovimientos.Columns("COSTURA").Width = 80
        dgvMovimientos.Columns("COSTURA").ReadOnly = True
        dgvMovimientos.Columns.Add("TOTAL", "TOTAL")
        dgvMovimientos.Columns("TOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMovimientos.Columns("TOTAL").Width = 95
        dgvMovimientos.Columns("TOTAL").ReadOnly = True

        'primero lleno los dias
        For i = 1 To 31
            row = {i, "0", "0"}
            dgvMovimientos.Rows.Add(row)
        Next i

        'despues lleno las celdas que tienen datos
        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "select day(Fecha) as Dia ,ISNULL(paracostura,0) as ParaCostura, SUM(Kilos) as Kilos "
        sStr = sStr + " from HilamarStockTextiMovimientos"
        sStr = sStr + " WHERE Eliminado=0 and month(Fecha)=" + NumeroMes(cmbMeses.Text)
        sStr = sStr + " group by DAY(fecha),ISNULL(paracostura,0)"
        sStr = sStr + " order by DAY(fecha)"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()



        Do While Reader.HasRows
            Do While Reader.Read
                If Reader.Item("ParaCostura").ToString() = "0" Then
                    Columna = "HILADO"
                Else
                    Columna = "COSTURA"
                End If
                dgvMovimientos.Rows(Reader.Item("Dia") - 1).Cells(Columna).Value() = Reader.Item("Kilos")
            Loop
            Reader.NextResult()
        Loop

        ' luego saco la cuenta de los totales
        For i = 0 To dgvMovimientos.RowCount - 1
            dgvMovimientos.Rows(i).Cells("TOTAL").Value() = CInt(dgvMovimientos.Rows(i).Cells("HILADO").Value()) + CInt(dgvMovimientos.Rows(i).Cells("COSTURA").Value())
        Next

    End Sub

    Private Sub CargarListadoMensual()
        Dim i As Integer
        Dim Columna As String

        Dim row As String()

        dgvMovimientos.Rows.Clear()
        dgvMovimientos.Columns.Clear()
        dgvMovimientos.Columns.Add("FECHA", "MES")
        dgvMovimientos.Columns("FECHA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvMovimientos.Columns("FECHA").Width = 80
        dgvMovimientos.Columns("FECHA").ReadOnly = True
        dgvMovimientos.Columns.Add("HILADO", "HILADO")
        dgvMovimientos.Columns("HILADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMovimientos.Columns("HILADO").Width = 75
        dgvMovimientos.Columns("HILADO").ReadOnly = True
        dgvMovimientos.Columns.Add("COSTURA", "COSTURA")
        dgvMovimientos.Columns("COSTURA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMovimientos.Columns("COSTURA").Width = 80
        dgvMovimientos.Columns("COSTURA").ReadOnly = True
        dgvMovimientos.Columns.Add("TOTAL", "TOTAL")
        dgvMovimientos.Columns("TOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMovimientos.Columns("TOTAL").Width = 95
        dgvMovimientos.Columns("TOTAL").ReadOnly = True

        'primero lleno los meses
        For i = 1 To 12
            row = {NombreMes(i, True), "0", "0"}
            dgvMovimientos.Rows.Add(row)
        Next i

        'despues lleno las celdas que tienen datos
        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "select month(Fecha) as Mes ,ISNULL(paracostura,0) as ParaCostura, SUM(Kilos) as Kilos "
        sStr = sStr + " from HilamarStockTextiMovimientos"
        sStr = sStr + " group by month(fecha),ISNULL(paracostura,0)"
        sStr = sStr + " order by month(fecha)"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()



        Do While Reader.HasRows
            Do While Reader.Read
                If Reader.Item("ParaCostura").ToString() = "0" Then
                    Columna = "HILADO"
                Else
                    Columna = "COSTURA"
                End If
                dgvMovimientos.Rows(Reader.Item("Mes") - 1).Cells(Columna).Value() = Reader.Item("Kilos")
            Loop
            Reader.NextResult()
        Loop

        ' luego saco la cuenta de los totales
        For i = 0 To dgvMovimientos.RowCount - 1
            dgvMovimientos.Rows(i).Cells("TOTAL").Value() = CInt(dgvMovimientos.Rows(i).Cells("HILADO").Value()) + CInt(dgvMovimientos.Rows(i).Cells("COSTURA").Value())
        Next


    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub rbDiario_CheckedChanged(sender As Object, e As EventArgs) Handles rbDiario.CheckedChanged
        CargarListadoDiario()
        If rbDiario.Checked = True Then
            cmbMeses.Enabled = True
        Else
            cmbMeses.Enabled = False
        End If
    End Sub

    Private Sub rbMensual_CheckedChanged(sender As Object, e As EventArgs) Handles rbMensual.CheckedChanged
        CargarListadoMensual()
    End Sub

    Private Sub cmbMeses_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMeses.SelectedIndexChanged
        CargarListadoDiario()
    End Sub
End Class