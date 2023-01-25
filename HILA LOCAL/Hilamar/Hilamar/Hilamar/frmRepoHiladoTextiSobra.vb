Imports System.Data.SqlClient


Public Class frmRepoHiladoTextiSobra
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

    Private Sub LimpiarDGV()
        dgvSobrantes.Rows.Clear()
        dgvSobrantes.Columns.Clear()
    End Sub

    Private Sub ArmarDGV()
        dgvSobrantes.Columns.Add("IDSOBRANTE", "IDSOBRANTE")
        dgvSobrantes.Columns("IDSOBRANTE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvSobrantes.Columns("IDSOBRANTE").Visible = False
        dgvSobrantes.Columns.Add("PARTIDA", "PARTIDA")
        dgvSobrantes.Columns("PARTIDA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvSobrantes.Columns("PARTIDA").Width = 130
        dgvSobrantes.Columns("PARTIDA").ReadOnly = True
        dgvSobrantes.Columns.Add("KILOS", "KILOS")
        dgvSobrantes.Columns("KILOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvSobrantes.Columns("KILOS").Width = 110
        dgvSobrantes.Columns("KILOS").ReadOnly = True
        dgvSobrantes.Columns.Add("OBSERVACIONES", "OBSERVACIONES")
        dgvSobrantes.Columns("OBSERVACIONES").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvSobrantes.Columns("OBSERVACIONES").Width = 380
        dgvSobrantes.Columns.Add("TERMINADO", "TERM")
        dgvSobrantes.Columns("TERMINADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvSobrantes.Columns("TERMINADO").Width = 60
        dgvSobrantes.Columns("TERMINADO").ReadOnly = True
        dgvSobrantes.Columns.Add("H.ASOCIADO", "HIL.ASO")
        dgvSobrantes.Columns("H.ASOCIADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvSobrantes.Columns("H.ASOCIADO").Width = 80
        dgvSobrantes.Columns("H.ASOCIADO").ReadOnly = True
        dgvSobrantes.Columns.Add("IDHILADOTEXTISTOCK", "IDHILADOTEXTISTOCK")
        dgvSobrantes.Columns("IDHILADOTEXTISTOCK").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvSobrantes.Columns("IDHILADOTEXTISTOCK").Visible = False

        dgvSobrantes.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 12)
        dgvSobrantes.DefaultCellStyle.Font = New Font("Tahoma", 12)
        dgvSobrantes.RowTemplate.Height = 28

    End Sub

    Private Sub CargarListado()
        Dim row As String()
        Dim IdHiladoTextiStock, HiladoAsociado, Terminado As String

        LimpiarDGV()
        ArmarDGV()

        sStr = "Select * from HilamarHiladoTextiStockSobrante "
        sStr = sStr + "WHERE Eliminado = 0 "
        If chkVerTerminados.Checked = False Then sStr = sStr + " AND Terminado=0 "
        If rbConObservaciones.Checked = True Then sStr = sStr + " AND Observaciones <> '' "
        If rbSinObservaciones.Checked = True Then sStr = sStr + " AND Observaciones = '' "
        If txtPartida.Text <> "" Then sStr = sStr + " AND Partida like '%" + txtPartida.Text + "%' "
        sStr = sStr + "order by Partida "

        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                If Reader.Item("Terminado").ToString = "0" Then
                    Terminado = "NO"
                Else
                    Terminado = "SI"
                End If
                If Not IsDBNull(Reader.Item("IdHiladoTextiStock")) Then
                    HiladoAsociado = "TIENE"
                    IdHiladoTextiStock = Reader.Item("IdHiladoTextiStock").ToString
                Else
                    HiladoAsociado = "NO"
                    IdHiladoTextiStock = ""
                End If
                row = {Reader.Item("Id").ToString, Reader.Item("Partida").ToString, Reader.Item("KilosSobran").ToString, Reader.Item("Observaciones").ToString, Terminado, HiladoAsociado, IdHiladoTextiStock}
                dgvSobrantes.Rows.Add(row)
                If Terminado = "SI" Then
                    dgvSobrantes.Rows(dgvSobrantes.RowCount - 1).ReadOnly = True
                End If

            Loop
            Reader.NextResult()
        Loop
    End Sub

    Private Sub cmdVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVolver.Click
        Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Agregar()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Modificar()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Eliminar()
    End Sub

    Private Sub Agregar()
        Dim formABMTextiSobranteHilado As New frmABMTextiSobranteHilado(LegajoLogueado, TipoUsuario)
        If FormAbierto(formABMTextiSobranteHilado) Then Exit Sub
        formABMTextiSobranteHilado.Alta = True
        formABMTextiSobranteHilado.Cargar()
        formABMTextiSobranteHilado.ShowDialog()
        CargarListado()
    End Sub

    Private Sub Modificar()
        If dgvSobrantes.CurrentRow.Index < 0 Then Exit Sub

        Dim formABMTextiSobranteHilado As New frmABMTextiSobranteHilado(LegajoLogueado, TipoUsuario)
        If FormAbierto(formABMTextiSobranteHilado) Then Exit Sub
        formABMTextiSobranteHilado.Alta = False
        formABMTextiSobranteHilado.ID = dgvSobrantes.Rows(dgvSobrantes.CurrentRow.Index).Cells(0).Value.ToString
        formABMTextiSobranteHilado.Cargar()
        formABMTextiSobranteHilado.ShowDialog()
        CargarListado()
    End Sub

    Private Sub Eliminar()
        If dgvSobrantes.CurrentRow.Index < 0 Then Exit Sub

        If dgvSobrantes.Rows(dgvSobrantes.CurrentRow.Index).Cells("TERMINADO").Value.ToString = "SI" Then
            MensajeAtencion("El Sobrante de Hilado ya está terminado, no es posible eliminarlo.")
            Exit Sub
        End If

        If MsgBox("¿Está seguro de eliminar el sobrante seleccionado?", vbYesNo, "Textilana S. A.") = vbNo Then Exit Sub

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "UPDATE HilamarHiladoTextiStockSobrante"
        sStr = sStr + " SET Eliminado = 1, AuditoriaModif='" + Environment.MachineName + "|" + Now.ToString + "'"
        sStr = sStr + " WHERE id = " + dgvSobrantes.Rows(dgvSobrantes.CurrentRow.Index).Cells(0).Value.ToString + ""
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        MensajeInfo("Sobrante de Hilado eliminado correctamente.")

        CargarListado()

    End Sub

    Private Sub frmRepoHiladoTextiSobra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If TipoUsuario = "TextiAdmin" Then
            btnEliminar.Enabled = True
            btnTerminar.Enabled = True
            dgvSobrantes.ReadOnly = False
        Else
            btnEliminar.Enabled = False
            btnTerminar.Enabled = False
            dgvSobrantes.ReadOnly = True
        End If

        rbTodos.Checked = True
        CargarListado()
        txtPartida.Select()
    End Sub

    Private Sub btnTerminar_Click(sender As Object, e As EventArgs) Handles btnTerminar.Click
        Terminar()
    End Sub
    Private Sub Terminar()
        If dgvSobrantes.CurrentRow.Index < 0 Then Exit Sub

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "UPDATE HilamarHiladoTextiStockSobrante"
        sStr = sStr + " SET Terminado = 1, AuditoriaModif='" + Environment.MachineName + "|" + Now.ToString + "'"
        sStr = sStr + " WHERE id = " + dgvSobrantes.Rows(dgvSobrantes.CurrentRow.Index).Cells(0).Value.ToString + ""
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        If dgvSobrantes.Rows(dgvSobrantes.CurrentRow.Index).Cells("IDHILADOTEXTISTOCK").Value.ToString <> "" Then
            sStr = "UPDATE HilamarHiladoTextiStock"
            sStr = sStr + " SET Terminada = 1, FechaTerminada=getdate() "
            sStr = sStr + " WHERE id = " + dgvSobrantes.Rows(dgvSobrantes.CurrentRow.Index).Cells("IDHILADOTEXTISTOCK").Value.ToString + ""
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()
        End If

        MensajeAtencion("Se dió por terminado el Sobrante de Hilado.")

        CargarListado()

    End Sub

    Private Sub chkVerTerminados_CheckedChanged(sender As Object, e As EventArgs) Handles chkVerTerminados.CheckedChanged
        CargarListado()
    End Sub

    Private Sub rbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles rbTodos.CheckedChanged
        CargarListado()
    End Sub

    Private Sub rbConObservaciones_CheckedChanged(sender As Object, e As EventArgs) Handles rbConObservaciones.CheckedChanged
        CargarListado()
    End Sub

    Private Sub rbSinObservaciones_CheckedChanged(sender As Object, e As EventArgs) Handles rbSinObservaciones.CheckedChanged
        CargarListado()
    End Sub

    Private Sub btnListar_Click(sender As Object, e As EventArgs) Handles btnListar.Click
        CargarListado()
    End Sub

    Private Sub txtPartida_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPartida.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            CargarListado()
        ElseIf e.KeyChar = Convert.ToChar(Keys.Escape) Then
            Close()
        End If
    End Sub

    'Private Sub dgvSobrantes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSobrantes.CellDoubleClick
    '    Modificar()
    'End Sub

    Private Sub dgvSobrantes_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSobrantes.CellEndEdit
        Dim Observaciones As String = ""

        If Not IsNothing(dgvSobrantes.Rows(dgvSobrantes.CurrentRow.Index).Cells("OBSERVACIONES").Value) Then
            Observaciones = dgvSobrantes.Rows(dgvSobrantes.CurrentRow.Index).Cells("OBSERVACIONES").Value.ToString
        End If

        sStr = "UPDATE HilamarHiladoTextiStockSobrante"
        sStr = sStr + " SET Observaciones = '" + Observaciones + "' "
        sStr = sStr + " WHERE id = " + dgvSobrantes.Rows(dgvSobrantes.CurrentRow.Index).Cells(0).Value.ToString + ""
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

    End Sub

    Private Sub txtPartida_TextChanged(sender As Object, e As EventArgs) Handles txtPartida.TextChanged

    End Sub
End Class