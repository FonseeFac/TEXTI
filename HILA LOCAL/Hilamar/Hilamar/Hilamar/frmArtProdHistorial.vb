Imports System.Data.SqlClient

Public Class frmArtProdHistorial

    Public ID As Integer
    Dim Command As New SqlCommand
    Dim Reader As SqlDataReader
    Dim sStr As String

    Public Sub CargarListado()
        Dim row As String()
        Dim FechaAux, CorrAux As String

        limpiaryarmardgvHistorial()

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        sStr = "select * "
        sStr = sStr + " FROM PrendasArtProdPlanillasHistorial WHERE TipoElem='P' and IdElem=" + ID.ToString
        sStr = sStr + " UNION "
        sStr = sStr + " SELECT * "
        sStr = sStr + " FROM PrendasArtProdPlanillasHistorial WHERE TipoElem='C' and IdElem IN "
        sStr = sStr + " (SELECT ID FROM PrendasArtProdPlanillasCorrecciones where idplanilla =" + ID.ToString + " )"
        sStr = sStr + " UNION "
        sStr = sStr + " SELECT * "
        sStr = sStr + " FROM PrendasArtProdPlanillasHistorial WHERE TipoElem='A' and IdElem IN "
        sStr = sStr + " (SELECT ID FROM PrendasArtProdPlanillasAccesorios where idplanilla =" + ID.ToString + " )"
        sStr = sStr + " order by fechamodif "

        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read

                If IsDBNull(Reader.Item("Fecha")) Then
                    FechaAux = ""
                Else
                    FechaAux = Reader.Item("Fecha").ToString
                End If

                If IsDBNull(Reader.Item("Correccion")) Then
                    CorrAux = ""
                Else
                    CorrAux = Reader.Item("Correccion").ToString
                End If


                row = {Format(Reader.Item("FechaModif"), "dd/MM/yyyy HH:mm:ss"), Reader.Item("TipoModif").ToString, Reader.Item("Legajo").ToString + "-" + DescripcionLegajo(Reader.Item("Legajo").ToString), FechaAux, CorrAux}
                dgvHistorial.Rows.Add(row)

            Loop
            Reader.NextResult()
        Loop

    End Sub

    Private Sub limpiaryarmardgvHistorial()
        dgvHistorial.Rows.Clear()
        dgvHistorial.Columns.Clear()
        dgvHistorial.Columns.Add("FECHA", "FECHA")
        dgvHistorial.Columns("FECHA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvHistorial.Columns("FECHA").Width = 120
        dgvHistorial.Columns("FECHA").ReadOnly = True
        dgvHistorial.Columns.Add("EVENTO", "EVENTO")
        dgvHistorial.Columns("EVENTO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvHistorial.Columns("EVENTO").Width = 100
        dgvHistorial.Columns("EVENTO").ReadOnly = True
        dgvHistorial.Columns.Add("RESPONSABLE", "RESPONSABLE")
        dgvHistorial.Columns("RESPONSABLE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvHistorial.Columns("RESPONSABLE").Width = 235
        dgvHistorial.Columns("RESPONSABLE").ReadOnly = True
        dgvHistorial.Columns.Add("FECH", "FECHA")
        dgvHistorial.Columns("FECH").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvHistorial.Columns("FECH").Width = 100
        dgvHistorial.Columns("FECH").ReadOnly = True
        dgvHistorial.Columns.Add("CORR", "CORRECCION")
        dgvHistorial.Columns("CORR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvHistorial.Columns("CORR").Width = 200
        dgvHistorial.Columns("CORR").ReadOnly = True
    End Sub

    Private Sub cmdVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVolver.Click
        Close()
    End Sub

End Class