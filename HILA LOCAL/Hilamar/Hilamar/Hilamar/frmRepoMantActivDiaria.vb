Imports System.Data.SqlClient

Public Class frmRepoMantActivDiaria
    Dim EstoyIniciandoVentana As Boolean = True
    Dim ColSectores As New Collection

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Close()
    End Sub

    Private Sub frmRepoMantActivDiaria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EstoyIniciandoVentana = True
        dtpDesde.Value = Now
        dtpHasta.Value = Now
        CargarListadePlantas()
        CargarListadeSectores()
        EstoyIniciandoVentana = False
        CargarListado()
    End Sub

    Private Sub CargarListadePlantas()
        cmbPlantas.Items.Clear()
        cmbPlantas.Items.Add("TODAS")
        cmbPlantas.Items.Add("TEXTILANA")
        cmbPlantas.Items.Add("HILAMAR")
        cmbPlantas.SelectedIndex = 0
    End Sub

    Private Sub CargarListadeSectores()
        Dim sStr As String
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader

        cmbSectores.Items.Clear()
        ColSectores.Clear()

        cmbSectores.Items.Add("TODOS")
        ColSectores.Add("0", "TODOS")

        If cmbPlantas.Text = "TODAS" Then
            sStr = "SELECT * FROM HilaManteSectores WHERE Eliminado=0 order by Sector"
        Else
            sStr = "SELECT * FROM HilaManteSectores WHERE Eliminado=0 AND FABRICA='" + cmbPlantas.Text + "' order by Sector"
        End If
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                cmbSectores.Items.Add(Reader.Item("Sector").ToString + "-" + Strings.Left(Reader.Item("Fabrica").ToString, 3))
                ColSectores.Add(Reader.Item("Id").ToString, Reader.Item("Sector").ToString + "-" + Strings.Left(Reader.Item("Fabrica").ToString, 3))
            Loop
            Reader.NextResult()
        Loop

        cmbSectores.SelectedIndex = 0
    End Sub

    Private Sub cmbPlantas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPlantas.SelectedIndexChanged
        If Not EstoyIniciandoVentana Then CargarListadeSectores()
    End Sub

    Private Sub cmbSectores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSectores.SelectedIndexChanged
        If Not EstoyIniciandoVentana Then CargarListado()
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        CargarListado()
    End Sub

    Private Sub CargarListado()
        Dim sStr As String
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader

        Dim row As String()

        LimpiarDGV()
        ArmarDGV()

        sStr = "SELECT HIS.Fecha,TAR.NombreTarea,HIS.Estado,HIS.Legajo,HIS.Observaciones,MAQ.Nombre AS NOMBREMAQ,SEC.Sector ,SEC.Fabrica "
        sStr = sStr + " FROM HilaManteActiHistorial HIS INNER JOIN HilaManteListadoActividades ACT ON ACT.Id = HIS.IdActividad "
        sStr = sStr + " INNER JOIN HilaMantePlanMaquinasTareas PM ON ACT.IdMaqTarea = PM.Id "
        sStr = sStr + " INNER JOIN HilaManteMaquinas MAQ ON PM.IdMaquina = MAQ.ID"
        sStr = sStr + " INNER JOIN HilaManteTareas TAR ON PM.IdTarea = TAR.ID"
        sStr = sStr + " INNER JOIN HilaManteSectores SEC ON MAQ.IdSector = SEC.ID"
        sStr = sStr + " WHERE HIS.Eliminado = 0 AND HIS.Fecha >='" + Format(dtpDesde.Value, "yyyyMMdd") + "' AND HIS.Fecha <='" + Format(dtpHasta.Value, "yyyyMMdd") + " 23:59:59.000' AND HIS.ESTADO<>'ALTA' "
        If cmbPlantas.Text <> "TODAS" Then
            sStr = sStr + " AND SEC.Fabrica = '" + cmbPlantas.Text + "' "
        End If
        If cmbSectores.Text <> "TODOS" Then
            sStr = sStr + " AND MAQ.Idsector = " + ColSectores(cmbSectores.Text)
        End If
        sStr = sStr + " order by Fecha "

        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                row = {Format(Reader.Item("Fecha"), "dd/MM/yyyy"), Reader.Item("NombreTarea").ToString, Reader.Item("Estado").ToString, Reader.Item("LEGAJO").ToString, Reader.Item("Observaciones").ToString,
                        Reader.Item("NOMBREMAQ").ToString, Reader.Item("Sector").ToString, Reader.Item("Fabrica").ToString}
                dgvListado.Rows.Add(row)
            Loop
            Reader.NextResult()
        Loop
        dgvListado.Select()
    End Sub

    Private Sub LimpiarDGV()
        dgvListado.Rows.Clear()
        dgvListado.Columns.Clear()
    End Sub

    Private Sub ArmarDGV()
        dgvListado.Columns.Add("FECHA", "FECHA")
        dgvListado.Columns("FECHA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListado.Columns("FECHA").Width = 70
        dgvListado.Columns("FECHA").ReadOnly = True
        dgvListado.Columns.Add("TAREA", "TAREA")
        dgvListado.Columns("TAREA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListado.Columns("TAREA").Width = 190
        dgvListado.Columns("TAREA").ReadOnly = True
        dgvListado.Columns.Add("ESTADO", "ESTADO")
        dgvListado.Columns("ESTADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListado.Columns("ESTADO").Width = 70
        dgvListado.Columns("ESTADO").ReadOnly = True
        dgvListado.Columns.Add("LEGAJO", "LEGAJO")
        dgvListado.Columns("LEGAJO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvListado.Columns("LEGAJO").Width = 60
        dgvListado.Columns("LEGAJO").ReadOnly = True
        dgvListado.Columns.Add("OBSERVACIONES", "OBSERVACIONES")
        dgvListado.Columns("OBSERVACIONES").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListado.Columns("OBSERVACIONES").Width = 200
        dgvListado.Columns("OBSERVACIONES").DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvListado.Columns("OBSERVACIONES").ReadOnly = True
        dgvListado.Columns.Add("MAQUINA", "MAQUINA")
        dgvListado.Columns("MAQUINA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListado.Columns("MAQUINA").Width = 175
        dgvListado.Columns("MAQUINA").ReadOnly = True
        dgvListado.Columns.Add("SECTOR", "SECTOR")
        dgvListado.Columns("SECTOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListado.Columns("SECTOR").Width = 105
        dgvListado.Columns("SECTOR").ReadOnly = True
        dgvListado.Columns.Add("FABRICA", "FABRICA")
        dgvListado.Columns("FABRICA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListado.Columns("FABRICA").Width = 70
        dgvListado.Columns("FABRICA").ReadOnly = True

        dgvListado.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8)
        dgvListado.DefaultCellStyle.Font = New Font("Tahoma", 8)
        dgvListado.RowTemplate.Height = 30

    End Sub

End Class