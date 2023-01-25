Imports System.Data.SqlClient

Public Class frmArtProdListado

    Dim Command As New SqlCommand
    Dim Reader As SqlDataReader
    Dim sStr As String

    Dim ColCategoria As New Collection

    Dim LegajoLogueado As String 'legajo de quien va a trabajar
    Dim TipoUsuario As String ' Tipo de usuario que va a trabajar, lo voy a usar para saber que le habilito a usar y que no

    Sub New(ByVal parametro1 As String, ByVal parametro2 As String)

        InitializeComponent() 'es necesario que lleve esta linea

        LegajoLogueado = parametro1
        TipoUsuario = parametro2

    End Sub

    Public Sub Cargar()
        CargarCategorias()
        txtArticulo.Select()
    End Sub

    Private Sub CargarCategorias()
        cmbCategoria.Items.Clear()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        cmbCategoria.Items.Clear()
        ColCategoria.Clear()

        cmbCategoria.Items.Add("TODAS")

        sStr = "SELECT * FROM PrendasArtProdCategorias WHERE Eliminado = 0 Order by Descripcion"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read
                cmbCategoria.Items.Add(Reader.Item("Descripcion").ToString)
                ColCategoria.Add(Reader.Item("id").ToString, Reader.Item("Descripcion").ToString)
            Loop
            Reader.NextResult()
        Loop

        cmbCategoria.SelectedIndex = 0
    End Sub

    Private Sub cmdVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVolver.Click
        Close()
    End Sub
    Private Sub frmArtProdListado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar()
    End Sub

    Private Sub cmbCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoria.SelectedIndexChanged
        CargarListadoArticulos()
    End Sub
    Private Sub txtArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtArticulo.KeyDown
        If e.KeyCode = Keys.Enter Then CargarListadoArticulos()
    End Sub

    Private Sub CargarListadoArticulos()
        On Error GoTo ErrorCargarListadoArticulos
        If cmbCategoria.Text = "" Then Exit Sub

        Dim row As String()

        If cmbCategoria.Text = "" Then Exit Sub

        Dim resguardoFila, resguadroPrimerFilaMostrada As Integer
        resguardoFila = 0
        resguadroPrimerFilaMostrada = -1
        If dgvArticulos.RowCount > 0 Then
            resguardoFila = dgvArticulos.CurrentCell.RowIndex
            If dgvArticulos.FirstDisplayedScrollingRowIndex > 0 Then
                resguadroPrimerFilaMostrada = dgvArticulos.FirstDisplayedScrollingRowIndex
            End If
        End If


        LimpiarDGV_Articulos()
        ArmarDGV_Articulos()

        'tambien limpio los colores y partidas porque si no quedaban los viejos
        LimpiarDGV_ColorPartida()
        ArmarDGV_ColorPartida()

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        If cmbCategoria.Text = "TODAS" Then
            sStr = "SELECT distinct(Articulo) as ARTICULO,C.Descripcion as CATEGORIA, P.IdCategoria AS IDCATEGORIA "
            sStr = sStr + "FROM PrendasArtProdPlanillas P INNER JOIN PrendasArtProdCategorias C ON P.IdCategoria = C.id "
            If txtArticulo.Text <> "" Then
                sStr = sStr + "WHERE Articulo like '%" + txtArticulo.Text + "%'"
            End If
            sStr = sStr + " order by Articulo"
        Else
            sStr = "SELECT distinct(Articulo) as ARTICULO,C.Descripcion as CATEGORIA,P.IdCategoria AS IDCATEGORIA "
            sStr = sStr + "FROM PrendasArtProdPlanillas P INNER JOIN PrendasArtProdCategorias C ON P.IdCategoria = C.id "
            sStr = sStr + " WHERE IdCategoria=" + ColCategoria.Item(cmbCategoria.Text)
            If txtArticulo.Text <> "" Then
                sStr = sStr + "AND Articulo like '%" + txtArticulo.Text + "%'"
            End If
            sStr = sStr + " order by Articulo"
        End If
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read
                row = {Reader.Item("ARTICULO").ToString, Reader.Item("CATEGORIA").ToString, Reader.Item("IDCATEGORIA").ToString}
                dgvArticulos.Rows.Add(row)
            Loop
            Reader.NextResult()
        Loop

        If resguadroPrimerFilaMostrada >= 0 Then
            dgvArticulos.FirstDisplayedScrollingRowIndex = resguadroPrimerFilaMostrada
        End If

        If dgvArticulos.RowCount > 0 Then
            dgvArticulos.Rows(0).Selected = False
            dgvArticulos.Rows(resguardoFila).Selected = True
            dgvArticulos.CurrentCell = dgvArticulos.Rows(resguardoFila).Cells(0)
        End If
        CargarListadoColorPartida()

        Exit Sub
ErrorCargarListadoArticulos:
        MensajeInfo("Error:" + Err.Description)

    End Sub
    Private Sub LimpiarDGV_Articulos()
        dgvArticulos.Rows.Clear()
        dgvArticulos.Columns.Clear()
    End Sub

    Private Sub ArmarDGV_Articulos()
        dgvArticulos.Columns.Add("ARTICULO", "ARTICULO")
        dgvArticulos.Columns("ARTICULO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvArticulos.Columns("ARTICULO").Width = 70
        dgvArticulos.Columns.Add("CATEGORIA", "CATEGORIA")
        dgvArticulos.Columns("CATEGORIA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvArticulos.Columns("CATEGORIA").Width = 150
        dgvArticulos.Columns.Add("IDCATEGORIA", "IDCATEGORIA")
        dgvArticulos.Columns("IDCATEGORIA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvArticulos.Columns("IDCATEGORIA").Visible = False

        dgvArticulos.Font = New Font("Arial", 8)
    End Sub

    Private Sub dgvArticulos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArticulos.CellClick
        LimpiarDGV_Accesorios()
        ArmarDGV_Accesorios()
        CargarListadoColorPartida()
    End Sub

    Private Sub LimpiarDGV_ColorPartida()
        dgvColorPartida.Rows.Clear()
        dgvColorPartida.Columns.Clear()
    End Sub

    Private Sub ArmarDGV_ColorPartida()
        dgvColorPartida.Columns.Add("FECHA", "FECHA")
        dgvColorPartida.Columns("FECHA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvColorPartida.Columns("FECHA").Width = 75
        dgvColorPartida.Columns.Add("TIPO", "TIPO")
        dgvColorPartida.Columns("TIPO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvColorPartida.Columns("TIPO").Width = 35
        dgvColorPartida.Columns.Add("COLOR", "COLOR")
        dgvColorPartida.Columns("COLOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvColorPartida.Columns("COLOR").Width = 170
        dgvColorPartida.Columns.Add("PARTIDA", "PARTIDA")
        dgvColorPartida.Columns("PARTIDA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvColorPartida.Columns("PARTIDA").Width = 80
        dgvColorPartida.Columns.Add("IDPLANILLA", "IDPLANILLA")
        dgvColorPartida.Columns("IDPLANILLA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvColorPartida.Columns("IDPLANILLA").Visible = False

        dgvColorPartida.Font = New Font("Arial", 8)
    End Sub

    Private Sub CargarListadoColorPartida()
        Dim row As String()

        LimpiarDGV_ColorPartida()
        ArmarDGV_ColorPartida()

        If dgvArticulos.RowCount <= 0 Then Exit Sub
        If dgvArticulos.CurrentRow.Index < 0 Then Exit Sub

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        sStr = "SELECT Fecha,Color,Partida,ISNULL(EsOriginal,0) AS EsOriginal,Id FROM PrendasArtProdPlanillas "
        sStr = sStr + " WHERE Articulo='" + dgvArticulos.Rows(dgvArticulos.CurrentRow.Index).Cells("ARTICULO").Value.ToString + "'"
        sStr = sStr + " AND IdCategoria=" + dgvArticulos.Rows(dgvArticulos.CurrentRow.Index).Cells("IDCATEGORIA").Value.ToString + " "
        If txtColor.Text <> "" Then
            sStr = sStr + "AND Color like '%" + txtColor.Text + "%'"
        End If
        sStr = sStr + " order by Fecha,Color,Partida"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read
                If Reader.Item("EsOriginal").ToString = "1" Then
                    row = {Format(Reader.Item("Fecha"), "dd/MM/yyyy"), "ORIG", Reader.Item("Color").ToString, Reader.Item("Partida").ToString, Reader.Item("Id").ToString}
                Else
                    row = {Format(Reader.Item("Fecha"), "dd/MM/yyyy"), "", Reader.Item("Color").ToString, Reader.Item("Partida").ToString, Reader.Item("Id").ToString}
                End If
                dgvColorPartida.Rows.Add(row)
            Loop
            Reader.NextResult()
        Loop

        If dgvColorPartida.RowCount > 0 Then
            dgvColorPartida.Rows(0).Selected = True
        End If

    End Sub

    Private Sub cmdVerPlanilla_Click(sender As Object, e As EventArgs) Handles cmdVerPlanilla.Click
        If dgvArticulos.CurrentRow.Index >= 0 And dgvColorPartida.CurrentRow.Index >= 0 Then
            Dim formArtProdABM As New frmArtProdABM(LegajoLogueado, TipoUsuario)
            formArtProdABM.Alta = False
            formArtProdABM.ID = dgvColorPartida.Rows(dgvColorPartida.CurrentRow.Index).Cells("IDPLANILLA").Value.ToString
            formArtProdABM.Cargar()
            formArtProdABM.Show(Me)
            CargarListadoArticulos()
        End If
    End Sub

    Private Sub dgvColorPartida_DoubleClick(sender As Object, e As EventArgs) Handles dgvColorPartida.DoubleClick
        If dgvArticulos.CurrentRow.Index >= 0 And dgvColorPartida.CurrentRow.Index >= 0 Then
            Dim formArtProdABM As New frmArtProdABM(LegajoLogueado, TipoUsuario)
            formArtProdABM.Alta = False
            formArtProdABM.ID = dgvColorPartida.Rows(dgvColorPartida.CurrentRow.Index).Cells("IDPLANILLA").Value.ToString
            formArtProdABM.Cargar()
            formArtProdABM.Show(Me)
            CargarListadoArticulos()
        End If
    End Sub

    Private Sub dgvColorPartida_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvColorPartida.CellClick
        If dgvColorPartida.CurrentRow.Index >= 0 Then
            CargarListadodeAccesorios(dgvColorPartida.Rows(dgvColorPartida.CurrentRow.Index).Cells("IDPLANILLA").Value.ToString)
        End If
    End Sub

    Private Sub LimpiarDGV_Accesorios()
        dgvAccesorios.Rows.Clear()
        dgvAccesorios.Columns.Clear()
    End Sub

    Private Sub ArmarDGV_Accesorios()
        dgvAccesorios.Columns.Add("DESCRIPCION", "DESCRIPCION")
        dgvAccesorios.Columns("DESCRIPCION").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvAccesorios.Columns("DESCRIPCION").Width = 100
        dgvAccesorios.Columns.Add("OP", "OP")
        dgvAccesorios.Columns("OP").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvAccesorios.Columns("OP").Width = 35
        dgvAccesorios.Columns.Add("COLOR", "COLOR")
        dgvAccesorios.Columns("COLOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvAccesorios.Columns("COLOR").Width = 130
        dgvAccesorios.Columns.Add("PARTIDA", "PARTIDA")
        dgvAccesorios.Columns("PARTIDA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvAccesorios.Columns("PARTIDA").Width = 55
        dgvAccesorios.Columns.Add("IDACCESORIO", "IDACCESORIO")
        dgvAccesorios.Columns("IDACCESORIO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvAccesorios.Columns("IDACCESORIO").Visible = False

        dgvAccesorios.Font = New Font("Arial", 8)
    End Sub

    Private Sub CargarListadodeAccesorios(ByVal IdPlanilla As String)
        Dim row As String()

        LimpiarDGV_Accesorios()
        ArmarDGV_Accesorios()


        sStr = "SELECT * FROM PrendasArtProdPlanillasAccesorios WHERE IdPlanilla =" + IdPlanilla.ToString
        sStr = sStr & " AND isnull(Eliminado,0)=0 "
        sStr = sStr & " ORDER BY Id"

        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                row = {Reader.Item("DescAccesorio").ToString, Reader.Item("OP").ToString, Reader.Item("Color").ToString, Reader.Item("Partida").ToString, Reader.Item("Id").ToString}
                dgvAccesorios.Rows.Add(row)
            Loop
            Reader.NextResult()
        Loop

        If dgvAccesorios.RowCount > 0 Then dgvAccesorios.Rows(0).Selected = True

    End Sub

    Private Sub cmdVerAccesorio_Click(sender As Object, e As EventArgs) Handles cmdVerAccesorio.Click
        Dim TipoPlanilla As String = ""
        If Strings.InStr(dgvArticulos.Rows(dgvArticulos.CurrentRow.Index).Cells("CATEGORIA").Value.ToString, "STOLL", CompareMethod.Text) > 0 Then
            TipoPlanilla = "STOLL"
        Else
            TipoPlanilla = "SHIMA"
        End If

        If dgvArticulos.CurrentRow.Index >= 0 And dgvColorPartida.CurrentRow.Index >= 0 And dgvAccesorios.CurrentRow.Index >= 0 Then

            Dim formArtProdAccABM As New frmArtProdAccABM(LegajoLogueado, dgvColorPartida.Rows(dgvColorPartida.CurrentRow.Index).Cells("IDPLANILLA").Value.ToString, TipoPlanilla)
            formArtProdAccABM.Alta = False
            formArtProdAccABM.ID = dgvAccesorios.Rows(dgvAccesorios.CurrentRow.Index).Cells("IDACCESORIO").Value.ToString
            formArtProdAccABM.Cargar()
            formArtProdAccABM.Show(Me)
            CargarListadodeAccesorios(dgvColorPartida.Rows(dgvColorPartida.CurrentRow.Index).Cells("IDPLANILLA").Value.ToString)

        End If
    End Sub

    Private Sub dgvAccesorios_DoubleClick(sender As Object, e As EventArgs) Handles dgvAccesorios.DoubleClick
        Dim TipoPlanilla As String = ""
        If Strings.InStr(dgvArticulos.Rows(dgvArticulos.CurrentRow.Index).Cells("CATEGORIA").Value.ToString, "STOLL", CompareMethod.Text) > 0 Then
            TipoPlanilla = "STOLL"
        Else
            TipoPlanilla = "SHIMA"
        End If

        If dgvArticulos.CurrentRow.Index >= 0 And dgvColorPartida.CurrentRow.Index >= 0 And dgvAccesorios.CurrentRow.Index >= 0 Then

            Dim formArtProdAccABM As New frmArtProdAccABM(LegajoLogueado, dgvColorPartida.Rows(dgvColorPartida.CurrentRow.Index).Cells("IDPLANILLA").Value.ToString, TipoPlanilla)
            formArtProdAccABM.Alta = False
            formArtProdAccABM.ID = dgvAccesorios.Rows(dgvAccesorios.CurrentRow.Index).Cells("IDACCESORIO").Value.ToString
            formArtProdAccABM.Cargar()
            formArtProdAccABM.Show(Me)
            CargarListadodeAccesorios(dgvColorPartida.Rows(dgvColorPartida.CurrentRow.Index).Cells("IDPLANILLA").Value.ToString)

        End If
    End Sub

    Private Sub dgvArticulos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArticulos.CellContentClick

    End Sub

    Private Sub dgvColorPartida_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvColorPartida.CellContentClick

    End Sub

    Private Sub dgvAccesorios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAccesorios.CellContentClick

    End Sub

End Class