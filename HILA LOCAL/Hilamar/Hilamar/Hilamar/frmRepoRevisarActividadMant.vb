Imports System.Data.SqlClient

Public Class frmRepoRevisarActividadMant
    Dim ColSectores, ColMaquinas As New Collection

    Dim ColumnaAPartirDeOrdenAscendente As Boolean = False, ColumnaUltimaVezOrdenAscendente As Boolean = False

    Dim EstoyIniciandoVentana As Boolean = True

    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Close()
    End Sub

    Private Sub frmRepoPlanMantenimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ArmarDgvHistorial()
        AjustarPropiedadesGrid()

        EstoyIniciandoVentana = True
        dtpAPartirDe.Value = DateAdd(DateInterval.Month, -1, Now)
        CargarListadePlantas()
        CargarListadeSectores()
        CargarListadeMaquinas()
        CargarListadeEstados()
        EstoyIniciandoVentana = False

        'cmbPlantas.SelectedIndex = 2
        'cmbSectores.SelectedIndex = 1
        'cmbMaquina.SelectedIndex = 2

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
    Private Sub CargarListadeMaquinas()
        Dim sStr As String
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader

        cmbMaquina.Items.Clear()
        ColMaquinas.Clear()

        cmbMaquina.Items.Add("TODAS")
        ColMaquinas.Add("0", "TODAS")

        If cmbSectores.Text = "TODOS" Then
            If cmbPlantas.Text = "TODAS" Then
                sStr = "SELECT * FROM HilaManteMaquinas MAQ INNER JOIN HilaManteSectores SEC ON MAQ.IdSector = SEC.Id WHERE MAQ.Eliminado=0 order by Nombre"
            Else
                sStr = "SELECT * FROM HilaManteMaquinas MAQ INNER JOIN HilaManteSectores SEC ON MAQ.IdSector = SEC.Id WHERE MAQ.Eliminado=0 "
                sStr = sStr + " AND IdSector in (SELECT ID FROM HilaManteSectores WHERE Fabrica='" + cmbPlantas.Text + "') order by Nombre"
            End If
        Else
            sStr = "SELECT * FROM HilaManteMaquinas MAQ INNER JOIN HilaManteSectores SEC ON MAQ.IdSector = SEC.Id WHERE MAQ.Eliminado=0 AND IdSector=" + ColSectores(cmbSectores.Text) + " order by Nombre"
        End If
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                cmbMaquina.Items.Add(Reader.Item("Nombre").ToString + " (" + Strings.Left(Reader.Item("Sector").ToString, 3) + ")")
                ColMaquinas.Add(Reader.Item("Id").ToString, Reader.Item("Nombre").ToString + " (" + Strings.Left(Reader.Item("Sector").ToString, 3) + ")")
            Loop
            Reader.NextResult()
        Loop

        cmbMaquina.SelectedIndex = 0
    End Sub

    Private Sub CargarListadeEstados()
        cmbEstados.Items.Clear()

        cmbEstados.Items.Add("TODAS")
        cmbEstados.Items.Add("PENDIENTES")
        cmbEstados.Items.Add("POSPUESTAS")
        cmbEstados.Items.Add("TERMINADAS")

        cmbEstados.SelectedIndex = 0
    End Sub

    Private Sub CargarListado()
        Dim sStr As String
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader

        Dim row As String()

        LimpiarDGV()
        ArmarDGV()

        sStr = "select PLA.Id as IDMAQTAREA"
        sStr = sStr + ",(select isnull( CONVERT(VARCHAR(10), max(hist.Fecha), 103),'19000101')  "
        sStr = sStr + "from HilaManteListadoActividades ACT INNER JOIN HilaManteActiHistorial HIST ON ACT.Id = HIST.IdActividad  "
        sStr = sStr + "where IdMaqTarea = PLA.ID and ACT.Eliminado = 0 and HIST.Estado ='CUMPLIDA') as FechaUlt "
        sStr = sStr + ", * from HilaMantePlanMaquinasTareas PLA "
        sStr = sStr + "INNER JOIN HilaManteMaquinas MAQ ON PLA.IdMaquina =MAQ.Id INNER JOIN HilaManteSectores SEC ON MAQ.IdSector = SEC.Id "
        sStr = sStr + "INNER JOIN HilaManteTareas TAR ON PLA.IdTarea = TAR.Id "
        sStr = sStr + "WHERE PLA.Eliminado = 0 "
        If cmbPlantas.Text <> "TODAS" Then
            sStr = sStr + " AND SEC.Fabrica = '" + cmbPlantas.Text + "' "
        End If
        If cmbSectores.Text <> "TODOS" Then
            sStr = sStr + " AND MAQ.Idsector = " + ColSectores(cmbSectores.Text) + " "
        End If
        If cmbMaquina.Text <> "TODAS" Then
            sStr = sStr + " AND MAQ.Id = " + ColMaquinas(cmbMaquina.Text) + " "
        End If

        sStr = sStr + " order by Fabrica, Sector, Nombre, NombreTarea "

        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                If Reader.Item("FechaUlt").ToString = "19000101" Then
                    row = {Reader.Item("IDMAQTAREA").ToString, Strings.Left(Reader.Item("Fabrica").ToString, 3), Reader.Item("Sector").ToString, Reader.Item("Nombre").ToString, Reader.Item("NombreTarea").ToString,
                           Format(Reader.Item("APARTIRDE"), "dd/MM/yyyy"), Reader.Item("FRECUENCIATAREA").ToString, "", Format(Reader.Item("APARTIRDE"), "yyyyMMdd"), Reader.Item("FechaUlt").ToString}
                Else
                    row = {Reader.Item("IDMAQTAREA").ToString, Strings.Left(Reader.Item("Fabrica").ToString, 3), Reader.Item("Sector").ToString, Reader.Item("Nombre").ToString, Reader.Item("NombreTarea").ToString,
                           Format(Reader.Item("APARTIRDE"), "dd/MM/yyyy"), Reader.Item("FRECUENCIATAREA").ToString, Reader.Item("FechaUlt"), Format(Reader.Item("APARTIRDE"), "yyyyMMdd"), Format(CDate(Reader.Item("FechaUlt")), "yyyyMMdd")}
                End If
                dgvListado.Rows.Add(row)
            Loop
            Reader.NextResult()
        Loop
        dgvListado.Select()
        If Not EstoyIniciandoVentana And dgvListado.RowCount > 0 Then
            If dgvListado.CurrentRow.Index >= 0 Then CargarHistorialDeLaMaquinaTarea(dgvListado.Rows(dgvListado.CurrentRow.Index).Cells("IDMAQTAREA").Value)
        End If
    End Sub

    Private Sub LimpiarDGV()
        dgvListado.Rows.Clear()
        dgvListado.Columns.Clear()
    End Sub

    Private Sub ArmarDGV()
        dgvListado.Columns.Add("IDMAQTAREA", "IDMAQTAREA")
        dgvListado.Columns("IDMAQTAREA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListado.Columns("IDMAQTAREA").Visible = False
        dgvListado.Columns.Add("FABRICA", "PLA")
        dgvListado.Columns("FABRICA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListado.Columns("FABRICA").Width = 30
        dgvListado.Columns("FABRICA").ReadOnly = True
        dgvListado.Columns.Add("SECTOR", "SECTOR")
        dgvListado.Columns("SECTOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListado.Columns("SECTOR").Width = 82
        dgvListado.Columns("SECTOR").ReadOnly = True
        dgvListado.Columns.Add("MAQUINA", "MAQUINA")
        dgvListado.Columns("MAQUINA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListado.Columns("MAQUINA").Width = 150
        dgvListado.Columns("MAQUINA").ReadOnly = True
        dgvListado.Columns.Add("TAREA", "TAREA")
        dgvListado.Columns("TAREA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListado.Columns("TAREA").Width = 200
        dgvListado.Columns("TAREA").ReadOnly = True
        dgvListado.Columns.Add("APARTIRDE", "DESDE")
        dgvListado.Columns("APARTIRDE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListado.Columns("APARTIRDE").Width = 55
        dgvListado.Columns("APARTIRDE").ReadOnly = True
        dgvListado.Columns.Add("FRECUENCIATAREA", "FREC")
        dgvListado.Columns("FRECUENCIATAREA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListado.Columns("FRECUENCIATAREA").Width = 65
        dgvListado.Columns("FRECUENCIATAREA").ReadOnly = True
        dgvListado.Columns.Add("ULTIMAVEZ", "ULTIMA VEZ")
        dgvListado.Columns("ULTIMAVEZ").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListado.Columns("ULTIMAVEZ").Width = 55
        dgvListado.Columns("ULTIMAVEZ").ReadOnly = True
        dgvListado.Columns.Add("APARTIRDEFECHA", "APARTIRDE")
        dgvListado.Columns("APARTIRDEFECHA").Visible = False
        dgvListado.Columns.Add("ULTIMAVEZFECHA", "ULTIMAVEZFECHA")
        dgvListado.Columns("ULTIMAVEZFECHA").Visible = False

        dgvListado.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 7)
        dgvListado.DefaultCellStyle.Font = New Font("Tahoma", 7)
        dgvListado.RowTemplate.Height = 20
    End Sub

    Private Sub CargarHistorialDeLaMaquinaTarea(ByVal IdMaquinaTarea As String)
        dgvHistorial.Rows.Clear()

        Dim sStr As String
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader

        Dim row As String()
        Dim IdCorteControl As String = ""

        sStr = "select ACT.ID,ACT.FECHA,ACT.ESTADO,HIST.Fecha as HISTFecha,HIST.Estado as HISTEstado, HIST.Legajo as HISTLegajo, HIST.Observaciones as HISTObservaciones "
        sStr = sStr + " from HilaManteListadoActividades ACT "
        sStr = sStr + " INNER JOIN HilaManteActiHistorial HIST ON ACT.Id = HIST.IdActividad "
        sStr = sStr + " WHERE ACT.Eliminado = 0 AND HIST.Eliminado = 0 AND HIST.Fecha >='" + Format(dtpAPartirDe.Value, "yyyyMMdd") + "' "

        If cmbEstados.Text <> "TODAS" Then
            If cmbEstados.Text = "PENDIENTES" Then
                sStr = sStr + " AND ACT.Estado = 'ALTA'"
            ElseIf cmbEstados.Text = "POSPUESTAS" Then
                sStr = sStr + " AND ACT.Estado = 'ALTA' AND HIST.Estado = 'POSPONER' "
            ElseIf cmbEstados.Text = "TERMINADAS" Then
                sStr = sStr + " AND ACT.Estado = 'CUMPLIDA'"
            End If
        End If

        sStr = sStr + " AND ACT.IdmaqTarea= " + IdMaquinaTarea + " "

        sStr = sStr + " order by ACT.Fecha, HIST.Fecha "

        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                If IdCorteControl <> Reader.Item("ID").ToString Then
                    row = {Format(Reader.Item("FECHA"), "dd/MM/yyyy"), Reader.Item("ESTADO").ToString,
                            Reader.Item("HISTFecha").ToString, Reader.Item("HISTEstado").ToString, Reader.Item("HISTLegajo").ToString, Reader.Item("HISTObservaciones").ToString}
                    dgvHistorial.Rows.Add(row)
                    IdCorteControl = Reader.Item("ID").ToString
                Else
                    row = {"", "", Reader.Item("HISTFecha").ToString, Reader.Item("HISTEstado").ToString, Reader.Item("HISTLegajo").ToString, Reader.Item("HISTObservaciones").ToString}
                    dgvHistorial.Rows.Add(row)
                End If

            Loop
            Reader.NextResult()
        Loop

    End Sub


    Private Sub ArmarDgvHistorial()
        dgvHistorial.Rows.Clear()
        dgvHistorial.Columns.Clear()

        dgvHistorial.Columns.Add("FECHA", "FECHA")
        dgvHistorial.Columns("FECHA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvHistorial.Columns("FECHA").Width = 55
        dgvHistorial.Columns("FECHA").ReadOnly = True
        dgvHistorial.Columns.Add("ESTADO", "ESTADO")
        dgvHistorial.Columns("ESTADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvHistorial.Columns("ESTADO").Width = 60
        dgvHistorial.Columns("ESTADO").ReadOnly = True
        dgvHistorial.Columns.Add("HISTFECHA", "FECHA")
        dgvHistorial.Columns("HISTFECHA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvHistorial.Columns("HISTFECHA").Width = 95
        dgvHistorial.Columns("HISTFECHA").ReadOnly = True
        dgvHistorial.Columns.Add("HISTESTADO", "ESTADO")
        dgvHistorial.Columns("HISTESTADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvHistorial.Columns("HISTESTADO").Width = 60
        dgvHistorial.Columns("HISTESTADO").ReadOnly = True
        dgvHistorial.Columns.Add("HISTLEGAJO", "LEGAJO")
        dgvHistorial.Columns("HISTLEGAJO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvHistorial.Columns("HISTLEGAJO").Width = 50
        dgvHistorial.Columns("HISTLEGAJO").ReadOnly = True
        dgvHistorial.Columns.Add("HISTOBSERVACIONES", "OBSERVACIONES")
        dgvHistorial.Columns("HISTOBSERVACIONES").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvHistorial.Columns("HISTOBSERVACIONES").Width = 150
        dgvHistorial.Columns("HISTOBSERVACIONES").ReadOnly = True

        dgvHistorial.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 7)
        dgvHistorial.DefaultCellStyle.Font = New Font("Tahoma", 7)
        dgvHistorial.RowTemplate.Height = 20

    End Sub

    Private Sub AjustarPropiedadesGrid()
        dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        'Alto de los headers, se coloca el doble del alto para poder adicionar los nuevos headers
        dgvHistorial.ColumnHeadersHeight = dgvHistorial.ColumnHeadersHeight * 2
        dgvHistorial.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
    End Sub

    Private Sub dgvHistorial_Paint(sender As Object, e As PaintEventArgs) Handles dgvHistorial.Paint
        If Not EstoyIniciandoVentana Then

            Dim formatoTexto As New StringFormat()
            formatoTexto.Alignment = StringAlignment.Center
            formatoTexto.LineAlignment = StringAlignment.Center
            Dim alto As Integer

            Dim encabezadoTAREA As Rectangle = dgvHistorial.GetCellDisplayRectangle(0, -1, True)
            'Es el mismo para todos los encabezados
            alto = encabezadoTAREA.Height / 2 - 2
            encabezadoTAREA.Width = dgvHistorial.GetCellDisplayRectangle(0, -1, True).Width + dgvHistorial.GetCellDisplayRectangle(1, -1, True).Width - 2
            encabezadoTAREA.Height = alto
            encabezadoTAREA.X += 1
            encabezadoTAREA.Y += 0
            e.Graphics.FillRectangle(New SolidBrush(Color.LightSteelBlue), encabezadoTAREA)
            e.Graphics.DrawString("TAREA", dgvHistorial.ColumnHeadersDefaultCellStyle.Font, New SolidBrush(Color.Black), encabezadoTAREA, formatoTexto)

            Dim encabezadoHISTORIAL As Rectangle = dgvHistorial.GetCellDisplayRectangle(2, -1, True)
            encabezadoHISTORIAL.Width = dgvHistorial.GetCellDisplayRectangle(2, -1, True).Width + dgvHistorial.GetCellDisplayRectangle(3, -1, True).Width + dgvHistorial.GetCellDisplayRectangle(4, -1, True).Width + dgvHistorial.GetCellDisplayRectangle(5, -1, True).Width - 2
            encabezadoHISTORIAL.Height = alto
            encabezadoHISTORIAL.X += 1
            encabezadoHISTORIAL.Y += 0
            e.Graphics.FillRectangle(New SolidBrush(Color.LightSteelBlue), encabezadoHISTORIAL)
            e.Graphics.DrawString("HISTORIAL", dgvHistorial.ColumnHeadersDefaultCellStyle.Font, New SolidBrush(Color.Black), encabezadoHISTORIAL, formatoTexto)

        End If

    End Sub

    Private Sub dgvHistorial_ColumnWidthChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles dgvHistorial.ColumnWidthChanged
        Dim rectanguloAreaControl As Rectangle = dgvHistorial.DisplayRectangle
        rectanguloAreaControl.Height = dgvHistorial.ColumnHeadersHeight / 2
        Me.dgvHistorial.Invalidate(rectanguloAreaControl)
    End Sub

    Private Sub dgvHistorial_Scroll(sender As Object, e As ScrollEventArgs) Handles dgvHistorial.Scroll
        Dim rectanguloAreaControl As Rectangle = dgvHistorial.DisplayRectangle
        rectanguloAreaControl.Height = dgvHistorial.ColumnHeadersHeight / 2
        Me.dgvHistorial.Invalidate(rectanguloAreaControl)
    End Sub


    Private Sub dgvListado_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvListado.ColumnHeaderMouseClick
        If dgvListado.Columns(e.ColumnIndex).Name = "APARTIRDE" Then
            If ColumnaAPartirDeOrdenAscendente Then
                dgvListado.Sort(dgvListado.Columns("APARTIRDEFECHA"), System.ComponentModel.ListSortDirection.Descending)
                ColumnaAPartirDeOrdenAscendente = False
            Else
                dgvListado.Sort(dgvListado.Columns("APARTIRDEFECHA"), System.ComponentModel.ListSortDirection.Ascending)
                ColumnaAPartirDeOrdenAscendente = True
            End If
        Else
            ColumnaAPartirDeOrdenAscendente = False
        End If

        If dgvListado.Columns(e.ColumnIndex).Name = "ULTIMAVEZ" Then
            If ColumnaUltimaVezOrdenAscendente Then
                dgvListado.Sort(dgvListado.Columns("ULTIMAVEZFECHA"), System.ComponentModel.ListSortDirection.Descending)
                ColumnaUltimaVezOrdenAscendente = False
            Else
                dgvListado.Sort(dgvListado.Columns("ULTIMAVEZFECHA"), System.ComponentModel.ListSortDirection.Ascending)
                ColumnaUltimaVezOrdenAscendente = True
            End If
        Else
            ColumnaUltimaVezOrdenAscendente = False
        End If
    End Sub



    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        If Not EstoyIniciandoVentana Then CargarListado()
    End Sub

    Private Sub cmbSectores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSectores.SelectedIndexChanged
        If Not EstoyIniciandoVentana Then CargarListadeMaquinas()
    End Sub

    Private Sub cmbPlantas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPlantas.SelectedIndexChanged
        If Not EstoyIniciandoVentana Then CargarListadeSectores()
    End Sub

    Private Sub cmbMaquina_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMaquina.SelectedIndexChanged
        If Not EstoyIniciandoVentana Then CargarListado()
    End Sub

    Private Sub dgvListado_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListado.CellClick
        If Not EstoyIniciandoVentana And dgvListado.RowCount > 0 Then
            If dgvListado.CurrentRow.Index >= 0 Then CargarHistorialDeLaMaquinaTarea(dgvListado.Rows(dgvListado.CurrentRow.Index).Cells("IDMAQTAREA").Value)
        End If
    End Sub

    Private Sub dtpAPartirDe_ValueChanged(sender As Object, e As EventArgs) Handles dtpAPartirDe.ValueChanged
        If Not EstoyIniciandoVentana And dgvListado.RowCount > 0 Then
            If dgvListado.CurrentRow.Index >= 0 Then CargarHistorialDeLaMaquinaTarea(dgvListado.Rows(dgvListado.CurrentRow.Index).Cells("IDMAQTAREA").Value)
        End If
    End Sub

    Private Sub cmbEstados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstados.SelectedIndexChanged
        If Not EstoyIniciandoVentana And dgvListado.RowCount > 0 Then
            If dgvListado.CurrentRow.Index >= 0 Then CargarHistorialDeLaMaquinaTarea(dgvListado.Rows(dgvListado.CurrentRow.Index).Cells("IDMAQTAREA").Value)
        End If
    End Sub

    Private Sub dgvListado_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListado.CellContentClick

    End Sub
End Class