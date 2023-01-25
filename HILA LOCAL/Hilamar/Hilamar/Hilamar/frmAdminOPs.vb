Imports System.Data.SqlClient


Public Class frmAdminOPs
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
        txtNroOP.Select()
        CargarListado()
    End Sub

    Private Sub CargarListado()
        Dim row As String()

        dgvOPs.Rows.Clear()
        dgvOPs.Columns.Clear()
        dgvOPs.Columns.Add("ID", "ID")
        dgvOPs.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvOPs.Columns("ID").Visible = False
        dgvOPs.Columns.Add("NROOP", "NRO.OP")
        dgvOPs.Columns("NROOP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvOPs.Columns("NROOP").Width = 55
        dgvOPs.Columns("NROOP").ReadOnly = True
        dgvOPs.Columns.Add("ARTICULO", "ARTICULO")
        dgvOPs.Columns("ARTICULO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvOPs.Columns("ARTICULO").Width = 70
        dgvOPs.Columns("ARTICULO").ReadOnly = True
        dgvOPs.Columns("ARTICULO").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvOPs.Columns.Add("XXS", "XXS")
        dgvOPs.Columns("XXS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvOPs.Columns("XXS").Width = 45
        dgvOPs.Columns("XXS").ReadOnly = True
        dgvOPs.Columns("XXS").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvOPs.Columns.Add("XS", "XS")
        dgvOPs.Columns("XS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvOPs.Columns("XS").Width = 45
        dgvOPs.Columns("XS").ReadOnly = True
        dgvOPs.Columns("XS").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvOPs.Columns.Add("S", "S")
        dgvOPs.Columns("S").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvOPs.Columns("S").Width = 45
        dgvOPs.Columns("S").ReadOnly = True
        dgvOPs.Columns("S").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvOPs.Columns.Add("M", "M")
        dgvOPs.Columns("M").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvOPs.Columns("M").Width = 45
        dgvOPs.Columns("M").ReadOnly = True
        dgvOPs.Columns("M").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvOPs.Columns.Add("L", "L")
        dgvOPs.Columns("L").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvOPs.Columns("L").Width = 45
        dgvOPs.Columns("L").ReadOnly = True
        dgvOPs.Columns("L").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvOPs.Columns.Add("XL", "XL")
        dgvOPs.Columns("XL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvOPs.Columns("XL").Width = 45
        dgvOPs.Columns("XL").ReadOnly = True
        dgvOPs.Columns("XL").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvOPs.Columns.Add("XXL", "XXL")
        dgvOPs.Columns("XXL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvOPs.Columns("XXL").Width = 45
        dgvOPs.Columns("XXL").ReadOnly = True
        dgvOPs.Columns("XXL").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvOPs.Columns.Add("TOTAL", "TOTAL")
        dgvOPs.Columns("TOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvOPs.Columns("TOTAL").Width = 70
        dgvOPs.Columns("TOTAL").ReadOnly = True
        dgvOPs.Columns("TOTAL").SortMode = DataGridViewColumnSortMode.NotSortable
        dgvOPs.Columns.Add("FECHA", "FECHA")
        dgvOPs.Columns("FECHA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvOPs.Columns("FECHA").Width = 90
        dgvOPs.Columns("FECHA").ReadOnly = True
        dgvOPs.Columns("FECHA").SortMode = DataGridViewColumnSortMode.NotSortable

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT * FROM ProdArticulosOP where Eliminado=0 "
        If txtNroOP.Text <> "" Then sStr = sStr & "AND OP LIKE '" & txtNroOP.Text & "%' "
        sStr = sStr & " ORDER BY FECHA,OP"

        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                row = {Reader.Item("Id"), Format(Reader.Item("OP"), "000"), Reader.Item("CodArticulo").ToString, Reader.Item("XXS"), Reader.Item("XS"), Reader.Item("S"), Reader.Item("M"), Reader.Item("L"), Reader.Item("XL"), Reader.Item("XXL"), Format(Reader.Item("TOTAL"), "0"), Format(Reader.Item("FECHA"), "dd/MM/yyyy")}
                dgvOPs.Rows.Add(row)
            Loop
            Reader.NextResult()
        Loop

    End Sub

    Private Sub cmdVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVolver.Click
        Close()
    End Sub

    Private Sub cmdBuscar_Click_1(sender As Object, e As EventArgs) Handles cmdBuscar.Click
        CargarListado()
    End Sub

    Private Sub frmAdminOPs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarListado()
    End Sub

    Private Sub cmdAgregar_Click(sender As Object, e As EventArgs) Handles cmdAgregar.Click
        Dim formABMOPs As New frmABMOPs()
        If FormAbierto(formABMOPs) Then Exit Sub
        formABMOPs.Alta = True
        formABMOPs.Show()
    End Sub

    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        If dgvOPs.CurrentRow.Index < 0 Then
            MensajeAtencion("Debe seleccionar una OP primero")
            Exit Sub
        End If
        Dim formABMOPs As New frmABMOPs()
        If FormAbierto(formABMOPs) Then Exit Sub
        formABMOPs.Alta = False
        formABMOPs.Id = dgvOPs.Rows(dgvOPs.CurrentRow.Index).Cells(0).Value.ToString
        formABMOPs.Cargar()
        formABMOPs.Show()
    End Sub
End Class