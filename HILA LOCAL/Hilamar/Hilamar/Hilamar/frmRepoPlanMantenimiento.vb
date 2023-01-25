Imports System.Data.SqlClient

Public Class frmRepoPlanMantenimiento
    Dim ColSectores As New Collection

    Dim EstoyIniciandoVentana As Boolean = True

    Dim LegajoLogueado As String 'legajo de quien va a trabajar
    Sub New(ByVal parametro1 As String)
        InitializeComponent() 'es necesario que lleve esta linea
        LegajoLogueado = parametro1
    End Sub

    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Close()
    End Sub

    Private Sub frmRepoPlanMantenimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EstoyIniciandoVentana = True
        dtpAPartirDe.Value = DateAdd(DateInterval.Month, -1, Now)
        CargarListaDePlantas()
        CargarListadeSectores()
        CargarListadeEstados()
        EstoyIniciandoVentana = False
        CargarListado()
    End Sub

    Private Sub CargarListadeSectores()
        Dim sStr As String
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader

        cmbSectores.Items.Clear()
        ColSectores.Clear()

        cmbSectores.Items.Add("TODOS")
        ColSectores.Add("0", "TODOS")

        sStr = "SELECT * FROM HilaManteSectores WHERE Eliminado=0 order by Sector"
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

    Private Sub CargarListadeEstados()
        cmbEstados.Items.Clear()

        cmbEstados.Items.Add("TODAS")
        cmbEstados.Items.Add("PENDIENTES")
        cmbEstados.Items.Add("POSPUESTAS")
        cmbEstados.Items.Add("TERMINADAS")

        cmbEstados.SelectedIndex = 1
    End Sub

    Private Sub CargarListaDePlantas()
        cmbPlantas.Items.Clear()

        cmbPlantas.Items.Add("TODAS")
        cmbPlantas.Items.Add("HILAMAR")
        cmbPlantas.Items.Add("TEXTILANA")

        cmbPlantas.SelectedIndex = 0
    End Sub

    Private Sub CargarListado()
        Dim sStr As String
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader

        Dim row As String()

        LimpiarDGV()
        ArmarDGV()

        sStr = "SELECT * FROM ( "
        sStr = sStr + "select ACT.Id as IDACTIV, (select top 1 Estado from HilaManteActiHistorial where IdActividad = ACT.Id and Eliminado=0 order by Id desc) as UltEstado "
        sStr = sStr + ", ACT.Fecha AS FECHA , ACT.Estado AS ESTADO, ACT.Eliminado AS ELIMINADO, SEC.Fabrica AS FABRICA, SEC.Sector AS SECTOR,MAQ.Nombre AS NOMBRE, TAR.NombreTarea AS NOMBRETAREA "
        sStr = sStr + ", ACT.IdMaqTarea AS IDMAQTAREA, PLA.DuracionTarea AS DURACIONTAREA "
        sStr = sStr + " from HilaManteListadoActividades ACT INNER JOIN HilaMantePlanMaquinasTareas PLA ON ACT.IdMaqTarea = PLA.Id "
        sStr = sStr + "INNER JOIN HilaManteMaquinas MAQ ON PLA.IdMaquina =MAQ.Id INNER JOIN HilaManteSectores SEC ON MAQ.IdSector = SEC.Id "
        sStr = sStr + "INNER JOIN HilaManteTareas TAR ON PLA.IdTarea = TAR.Id "
        sStr = sStr + "WHERE ACT.Eliminado = 0 AND ACT.Fecha >='" + Format(dtpAPartirDe.Value, "yyyyMMdd") + "' "
        If cmbSectores.Text <> "TODOS" Then
            sStr = sStr + " AND MAQ.Idsector = " + ColSectores(cmbSectores.Text)
        End If
        If cmbPlantas.Text <> "TODAS" Then
            sStr = sStr + " AND SEC.Fabrica ='" + cmbPlantas.Text + "' "
        End If
        sStr = sStr + ") A "
        If cmbEstados.Text <> "TODAS" Then
            If cmbEstados.Text = "PENDIENTES" Then
                sStr = sStr + " WHERE Estado = 'ALTA'"
            ElseIf cmbEstados.Text = "POSPUESTAS" Then
                sStr = sStr + " WHERE ULTEstado = 'POSPONER'"
            ElseIf cmbEstados.Text = "TERMINADAS" Then
                sStr = sStr + " WHERE Estado = 'CUMPLIDA'"
            End If
        End If
        sStr = sStr + " order by Fecha "

        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                row = {Reader.Item("IDACTIV").ToString, False, Format(Reader.Item("Fecha"), "dd/MM/yyyy"), Reader.Item("Fabrica").ToString, Reader.Item("Sector").ToString, Reader.Item("Nombre").ToString, Reader.Item("NombreTarea").ToString,
                       ObtenerListaDeRecursosDeLaTareaParaUnaMaquina(Reader.Item("IdMaqTarea").ToString), Reader.Item("DuracionTarea").ToString, Reader.Item("ULTEstado").ToString}
                dgvListado.Rows.Add(row)
                If dgvListado.Rows(dgvListado.RowCount - 1).Cells("ESTADO").Value = "CUMPLIDA" Then
                    dgvListado.Rows(dgvListado.RowCount - 1).DefaultCellStyle.BackColor = Color.FromArgb(160, 250, 160)
                Else
                    If Format(CDate(dgvListado.Rows(dgvListado.RowCount - 1).Cells("FECHA").Value), "yyyyMMdd") < Format(Now, "yyyyMMdd") Then
                        dgvListado.Rows(dgvListado.RowCount - 1).DefaultCellStyle.BackColor = Color.FromArgb(253, 150, 150)
                    ElseIf dgvListado.Rows(dgvListado.RowCount - 1).Cells("ESTADO").Value.ToString = "POSPONER" Then
                        dgvListado.Rows(dgvListado.RowCount - 1).DefaultCellStyle.BackColor = Color.FromArgb(253, 253, 150)
                    End If
                End If
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
        Dim chk As New DataGridViewCheckBoxColumn()
        chk.HeaderText = "Sel"
        chk.Name = "Chk"

        dgvListado.Columns.Add("IDACTIV", "IDACTIV")
        dgvListado.Columns("IDACTIV").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListado.Columns("IDACTIV").Visible = False

        dgvListado.Columns.Add(chk)
        dgvListado.Columns("Chk").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvListado.Columns("Chk").Width = 30

        dgvListado.Columns.Add("FECHA", "FECHA")
        dgvListado.Columns("FECHA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListado.Columns("FECHA").Width = 70
        dgvListado.Columns("FECHA").ReadOnly = True
        dgvListado.Columns.Add("FABRICA", "FABRICA")
        dgvListado.Columns("FABRICA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListado.Columns("FABRICA").Width = 70
        dgvListado.Columns("FABRICA").ReadOnly = True
        dgvListado.Columns.Add("SECTOR", "SECTOR")
        dgvListado.Columns("SECTOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListado.Columns("SECTOR").Width = 105
        dgvListado.Columns("SECTOR").ReadOnly = True
        dgvListado.Columns.Add("MAQUINA", "MAQUINA")
        dgvListado.Columns("MAQUINA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListado.Columns("MAQUINA").Width = 175
        dgvListado.Columns("MAQUINA").ReadOnly = True
        dgvListado.Columns.Add("TAREA", "TAREA")
        dgvListado.Columns("TAREA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListado.Columns("TAREA").Width = 190
        dgvListado.Columns("TAREA").ReadOnly = True
        dgvListado.Columns.Add("RECURSO", "RECURSO")
        dgvListado.Columns("RECURSO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListado.Columns("RECURSO").Width = 200
        dgvListado.Columns("RECURSO").DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgvListado.Columns("RECURSO").ReadOnly = True
        dgvListado.Columns.Add("MINUTOS", "MIN")
        dgvListado.Columns("MINUTOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvListado.Columns("MINUTOS").Width = 35
        dgvListado.Columns("MINUTOS").ReadOnly = True
        dgvListado.Columns.Add("ESTADO", "ESTADO")
        dgvListado.Columns("ESTADO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvListado.Columns("ESTADO").Width = 70
        dgvListado.Columns("ESTADO").ReadOnly = True

        dgvListado.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8)
        dgvListado.DefaultCellStyle.Font = New Font("Tahoma", 8)
        dgvListado.RowTemplate.Height = 30

    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        If Not EstoyIniciandoVentana Then CargarListado()
    End Sub

    Private Sub cmbEstados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstados.SelectedIndexChanged
        If Not EstoyIniciandoVentana Then CargarListado()
    End Sub

    Private Sub cmbSectores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSectores.SelectedIndexChanged
        If Not EstoyIniciandoVentana Then CargarListado()
    End Sub

    Private Sub cmbPlantas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPlantas.SelectedIndexChanged
        If Not EstoyIniciandoVentana Then CargarListado()
    End Sub

    Private Sub chkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged
        Dim i As Integer
        If chkTodos.Checked Then
            For i = 0 To dgvListado.RowCount - 1
                dgvListado.Rows(i).Cells("Chk").Value = True
            Next
        Else
            For i = 0 To dgvListado.RowCount - 1
                dgvListado.Rows(i).Cells("Chk").Value = False
            Next
        End If
    End Sub

    Private Sub btnPonerTerminada_Click(sender As Object, e As EventArgs) Handles btnPonerTerminada.Click
        Dim sStr As String
        Dim Command As New SqlCommand

        Dim Respuesta As String
        Dim i As Integer
        Dim HayAlgunoTildado As Boolean = False

        For i = 0 To dgvListado.RowCount - 1
            If dgvListado.Rows(i).Cells("Chk").Value = True Then
                HayAlgunoTildado = True
                Exit For
            End If
        Next

        If HayAlgunoTildado Then
            Respuesta = InputBox("Ingrese un comentario para dejar constancia del por qué se dan por terminadas las tareas seleccionadas.", "Ingreso de Observaciones")
            For i = 0 To dgvListado.RowCount - 1
                If dgvListado.Rows(i).Cells("Chk").Value = True Then
                    If dgvListado.Rows(i).Cells("ESTADO").Value.ToString <> "CUMPLIDA" Then
                        ' updateo el estado a CUMPLIDA
                        sStr = "UPDATE HilaManteListadoActividades "
                        sStr = sStr + " SET Estado='CUMPLIDA' "
                        sStr = sStr + " WHERE Id=" + dgvListado.Rows(i).Cells("IDACTIV").Value.ToString + ""
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                        ' ademas agrego la linea en el historial
                        sStr = "INSERT INTO HilaManteActiHistorial "
                        sStr = sStr + "(IdActividad,Fecha,Estado,Legajo,Observaciones,Eliminado) "
                        sStr = sStr + "VALUES "
                        sStr = sStr + "(" + dgvListado.Rows(i).Cells("IDACTIV").Value.ToString + ",GETDATE(),'CUMPLIDA','" + LegajoLogueado + "','" + Respuesta + "',0)"
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                End If
            Next
            MensajeAtencion("Se dieron por terminadas Exitosamente las tareas seleccionadas.")
            CargarListado()
        Else
            MensajeAtencion("No hay ninguna actividad seleccionada. Verifique.")
        End If
    End Sub

    Private Sub btnPosponer_Click(sender As Object, e As EventArgs) Handles btnPosponer.Click
        Dim FechaPosponer As Date
        Dim Observaciones As String

        Dim i As Integer
        Dim HayAlgunoTildado As Boolean = False

        For i = 0 To dgvListado.RowCount - 1
            If dgvListado.Rows(i).Cells("Chk").Value = True Then
                HayAlgunoTildado = True
                Exit For
            End If
        Next
        If Not HayAlgunoTildado Then
            MensajeAtencion("No hay ninguna actividad seleccionada. Verifique.")
            Exit Sub
        End If

        Dim formPosponerActividades As New frmPosponerActividades()
        formPosponerActividades.ShowDialog(Me)
        If formPosponerActividades.SeConfirmoOK Then
            FechaPosponer = formPosponerActividades.FechaPosponerOK
            Observaciones = formPosponerActividades.ObservacionesPosponer
            formPosponerActividades.Dispose()
            PosponerActividades(FechaPosponer, Observaciones)

            MensajeAtencion("Se han pospuesto Exitosamente las tareas seleccionadas.")
            CargarListado()
        Else
            formPosponerActividades.Dispose()
        End If
    End Sub

    Private Sub PosponerActividades(ByVal FechaPosponer As Date, ByVal Observaciones As String)
        Dim sStr As String
        Dim Command As New SqlCommand

        Dim i As Integer

        'primero reviso que la fecha para posponer no retrase ninguna actividad a una fecha anterior a su fecha de realizacion
        For i = 0 To dgvListado.RowCount - 1
            If dgvListado.Rows(i).Cells("Chk").Value = True Then
                If dgvListado.Rows(i).Cells("ESTADO").Value.ToString <> "CUMPLIDA" Then
                    If dgvListado.Rows(i).Cells("FECHA").Value > FechaPosponer Then
                        MensajeCritico("La fecha ingresada para posponer es menor que la fecha de alguna de las actividades seleccionadas. No es una fecha válida.")
                        Exit Sub
                    End If
                End If
            End If
        Next

        'si llego hasta aca la fecha posponer es correcta, entonces pospongo
        For i = 0 To dgvListado.RowCount - 1
            If dgvListado.Rows(i).Cells("Chk").Value = True Then
                If dgvListado.Rows(i).Cells("ESTADO").Value.ToString <> "CUMPLIDA" Then

                    ' updateo el estado a CUMPLIDA
                    sStr = "UPDATE HilaManteListadoActividades "
                    sStr = sStr + " SET Fecha='" + Format(FechaPosponer, "yyyyMMdd") + "' "
                    sStr = sStr + " WHERE Id=" + dgvListado.Rows(i).Cells("IDACTIV").Value.ToString + ""
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                    ' ademas agrego la linea en el historial
                    sStr = "INSERT INTO HilaManteActiHistorial "
                    sStr = sStr + "(IdActividad,Fecha,Estado,Legajo,Observaciones,Eliminado,FechaQueSePospuso) "
                    sStr = sStr + "VALUES "
                    sStr = sStr + "(" + dgvListado.Rows(i).Cells("IDACTIV").Value.ToString + ",GETDATE(),'POSPONER','" + LegajoLogueado + "','" + Observaciones + "',0,'" + Format(CDate(dgvListado.Rows(i).Cells("FECHA").Value), "yyyyMMdd") + "')"
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()

                End If
            End If
        Next



    End Sub

    Private nRowPos As Int16
    Private NewPage As Boolean
    Private nPageNo As Int16
    Private lPageNo As String = ""
    Private CORTEFECHA, CORTESECTOR, CORTEMAQUINA As String

    Private Sub btnIprimir_Click(sender As Object, e As EventArgs) Handles btnIprimir.Click
        If dgvListado.RowCount <= 0 Then Exit Sub

        pdoImpReporte.DefaultPageSettings.Landscape = False
        pdoImpReporte.DefaultPageSettings.Margins.Left = 20
        pdoImpReporte.DefaultPageSettings.Margins.Right = 20
        pdoImpReporte.DefaultPageSettings.Margins.Top = 20
        pdoImpReporte.DefaultPageSettings.Margins.Bottom = 20
        pdoImpReporte.OriginAtMargins = True ' takes margins into account 

        Dim dlgPrintPreview As New EnhancedPrintPreviewDialog
        dlgPrintPreview.ClientSize = New System.Drawing.Size(600, 600)
        dlgPrintPreview.Document = pdoImpReporte ' Previews print
        dlgPrintPreview.ShowDialog()

        'pdoImpPlanilla.Print()

    End Sub

    Private Sub pdoImpExistencias_BeginPrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles pdoImpReporte.BeginPrint
        nRowPos = 0
        NewPage = True
        nPageNo = 1
        CORTEFECHA = dgvListado.Rows(nRowPos).Cells("FECHA").Value.ToString
        CORTESECTOR = dgvListado.Rows(nRowPos).Cells("SECTOR").Value.ToString
        CORTEMAQUINA = dgvListado.Rows(nRowPos).Cells("MAQUINA").Value.ToString
    End Sub

    Private Sub pdoImpPlanilla_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdoImpReporte.PrintPage
        On Error Resume Next

        Dim ArtIni, ArtFin As String
        Dim AuxFila As Integer

        Dim FuenteLineas As Font = New Drawing.Font("Arial", 10, FontStyle.Regular)
        Dim Fuente8 As Font = New Drawing.Font("Arial", 8, FontStyle.Regular)
        Dim Fuente8Neg As Font = New Drawing.Font("Arial", 8, FontStyle.Bold)
        Dim Fuente9 As Font = New Drawing.Font("Arial", 9, FontStyle.Regular)
        Dim FuenteTituloEnc As Font = New Drawing.Font("Arial", 12, FontStyle.Regular)

        Dim nTop As Int16 = e.MarginBounds.Top


        Do While nRowPos < dgvListado.RowCount

            'If nTop > e.MarginBounds.Height - e.MarginBounds.Top - 30 Then
            If nTop > 1050 Then
                'LUEGO EL PIE DE PAGINA
                DrawFooter(e)

                nPageNo += 1
                NewPage = True
                e.HasMorePages = True
                Exit Sub

            Else

                If NewPage Then

                    ' Draw Header
                    e.Graphics.DrawString("TEXTILANA S.A. (División Hilados) ", FuenteTituloEnc, Brushes.Black, 300, nTop)
                    nTop = nTop + 19
                    e.Graphics.DrawLine(Pens.Black, 300, nTop, 560, nTop)
                    nTop = nTop + 2

                    e.Graphics.DrawString("Mantenimiento Preventivo", FuenteTituloEnc, Brushes.Black, 50, nTop)
                    e.Graphics.DrawString("Formulario 6.1", FuenteTituloEnc, Brushes.Black, 650, nTop)
                    nTop = nTop + 21

                    If CORTEFECHA <> dgvListado.Rows(nRowPos).Cells("FECHA").Value.ToString Or nRowPos = 0 Then
                        CORTEFECHA = dgvListado.Rows(nRowPos).Cells("FECHA").Value.ToString
                        e.Graphics.DrawString("Fecha:" + CORTEFECHA, Fuente9, Brushes.Black, 650, nTop)

                        CORTESECTOR = dgvListado.Rows(nRowPos).Cells("SECTOR").Value.ToString
                        e.Graphics.DrawString("Sector: " + CORTESECTOR, FuenteTituloEnc, Brushes.Black, 350, nTop)
                        nTop = nTop + 17
                        e.Graphics.DrawLine(Pens.Black, 20, nTop, 780, nTop)
                        nTop = nTop + 2
                        CORTEMAQUINA = ""
                    Else
                        If CORTESECTOR <> dgvListado.Rows(nRowPos).Cells("SECTOR").Value.ToString Or nRowPos = 0 Then
                            CORTESECTOR = dgvListado.Rows(nRowPos).Cells("SECTOR").Value.ToString
                            e.Graphics.DrawString("Sector: " + CORTESECTOR, FuenteTituloEnc, Brushes.Black, 350, nTop)
                            nTop = nTop + 17
                            e.Graphics.DrawLine(Pens.Black, 20, nTop, 780, nTop)
                            nTop = nTop + 2
                            CORTEMAQUINA = ""
                        End If
                    End If

                    NewPage = False

            End If

            End If

            If CORTEMAQUINA <> dgvListado.Rows(nRowPos).Cells("MAQUINA").Value.ToString Or nRowPos = 0 Then

                CORTEMAQUINA = dgvListado.Rows(nRowPos).Cells("MAQUINA").Value.ToString

                e.Graphics.DrawString(CORTEMAQUINA, FuenteLineas, Brushes.Black, 25, nTop)
                nTop = nTop + 15
                e.Graphics.DrawLine(Pens.Black, 25, nTop, 270, nTop)
                nTop = nTop + 2
                e.Graphics.DrawString("Tarea:", Fuente8Neg, Brushes.Black, 25, nTop)
                e.Graphics.DrawString("Recurso", Fuente8Neg, Brushes.Black, 500, nTop)
                e.Graphics.DrawString("min.", Fuente8Neg, Brushes.Black, 750, nTop)
                nTop = nTop + 15
                e.Graphics.DrawLine(Pens.Black, 25, nTop, 780, nTop)
                nTop = nTop + 2

            End If

            e.Graphics.DrawString(dgvListado.Rows(nRowPos).Cells("TAREA").Value, Fuente8, Brushes.Black, New RectangleF(25, nTop, 475, 20))
            e.Graphics.DrawString(dgvListado.Rows(nRowPos).Cells("RECURSO").Value, Fuente8, Brushes.Black, New RectangleF(500, nTop, 240, 20))
            e.Graphics.DrawString(dgvListado.Rows(nRowPos).Cells("MINUTOS").Value, Fuente8, Brushes.Black, 780 - e.Graphics.MeasureString(dgvListado.Rows(nRowPos).Cells("MINUTOS").Value.ToString, Fuente8).Width, nTop)
            nTop = nTop + 20

            nRowPos += 1

            If nRowPos < dgvListado.RowCount Then
                If CORTEFECHA <> dgvListado.Rows(nRowPos).Cells("FECHA").Value.ToString Or CORTESECTOR <> dgvListado.Rows(nRowPos).Cells("SECTOR").Value.ToString Then
                    'LUEGO EL PIE DE PAGINA
                    DrawFooter(e)

                    nPageNo += 1
                    NewPage = True
                    e.HasMorePages = True
                    Exit Sub
                End If
            End If

        Loop

        'LUEGO EL PIE DE PAGINA
        DrawFooter(e)

    End Sub

    Public Sub DrawFooter(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim FuenteLineas8 As Font = New Drawing.Font("Arial", 8, FontStyle.Regular)

        Dim sPageNo As String = "Pag. " + nPageNo.ToString

        e.Graphics.DrawLine(Pens.Black, 20, e.MarginBounds.Height - 17, 790, e.MarginBounds.Height - 17)

        ' Right Align - User Name
        e.Graphics.DrawString("Impreso: " + Format(Now, "dd/MM/yyyy HH:mm:ss"), FuenteLineas8, Brushes.Black, 620, e.MarginBounds.Height - 15)

        ' Center - Page No. Info
        e.Graphics.DrawString(sPageNo, FuenteLineas8, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(sPageNo, FuenteLineas8, e.MarginBounds.Width).Width) / 2, e.MarginBounds.Height - 15)

        e.Graphics.DrawLine(Pens.Black, 20, e.MarginBounds.Height, 790, e.MarginBounds.Height)

    End Sub

End Class