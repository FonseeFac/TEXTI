Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmABMProveedores_Articulo

    Private idArticulo As Integer
    Private bConfirmarProveedores As Boolean = False

    Sub New(ByVal pIdArticulo As Integer)
        InitializeComponent()

        idArticulo = pIdArticulo
    End Sub

    Private Sub frmABMProveedores_Articulos_Load(sender As Object, e As EventArgs) Handles Me.Load

        lblArticulo.Text = "Proveedores de " & CategoriaYNombreArticuloPorID(idArticulo) & ":"

        PintarDGVExistentes()

        PintarDGVArticulo()

        txtBuscador.Focus()
    End Sub

    Private Sub ArmarDGV(ByVal dgv As DataGridView)
        LimpiarDGV(dgv)

        dgv.Columns.Add("CODCTACTE", "CODCTACTE")
        dgv.Columns("CODCTACTE").Visible = False
        dgv.Columns.Add("NombreProveedor", "Nombre Proveedor/es")
        dgv.Columns("NombreProveedor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgv.Columns("NombreProveedor").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        For Each colum As DataGridViewColumn In dgv.Columns
            colum.ReadOnly = True
        Next

    End Sub

    Private Sub LimpiarDGV(ByVal dgv As DataGridView)
        dgv.Rows.Clear()
        dgv.Columns.Clear()
    End Sub

    Private Sub PintarDGVExistentes()
        Dim cmd As New SqlCommand
        Dim rd As SqlDataReader
        Dim sStr, FiltroBuscador, row() As String

        FiltroBuscador = ""

        If txtBuscador.Text <> "" Then
            FiltroBuscador = "AND (NOMBRE LIKE '%" + txtBuscador.Text + "%' OR CODCTACTE LIKE '%" + txtBuscador.Text + "%') "
        End If

        ArmarDGV(dgvProveedoresExistentes)

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT CODCTACTE, NOMBRE " + _
               "FROM BASE10.dbo.CTACTES CC " + _
               "WHERE CUEPREFI = 'P' AND CC.CODCTACTE LIKE '%%' AND ISNULL(SUSPENDIDOS,0) = 0 " + _
               FiltroBuscador + _
               "ORDER BY CC.NOMBRE "

        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        rd = cmd.ExecuteReader()

        Do While rd.HasRows
            Do While rd.Read()
                row = {rd.Item("CODCTACTE"), Trim(rd.Item("NOMBRE"))}
                dgvProveedoresExistentes.Rows.Add(row)
            Loop
            rd.NextResult()
        Loop
    End Sub

    Private Sub PintarDGVArticulo()
        Dim cmd As New SqlCommand
        Dim rd As SqlDataReader
        Dim sStr, row() As String

        ArmarDGV(dgvProveedoresArticulo)

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT CC.CODCTACTE, NOMBRE " + _
               "FROM BASE10.dbo.CTACTES CC " + _
               "INNER JOIN HilamarArticulos_x_Proveedores as haxp on haxp.CODCTACTE = cc.CODCTACTE " + _
               "WHERE CUEPREFI='P' AND CC.CODCTACTE like '%%' AND ISNULL(SUSPENDIDOS,0) = 0 AND idArticulo = '" + idArticulo.ToString + "' " + _
               "ORDER BY CC.NOMBRE "

        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
        rd = cmd.ExecuteReader()

        Do While rd.HasRows
            Do While rd.Read()
                row = {rd.Item("CODCTACTE"), Trim(rd.Item("NOMBRE"))}
                dgvProveedoresArticulo.Rows.Add(row)
            Loop
            rd.NextResult()
        Loop
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If dgvProveedoresExistentes.SelectedRows.Count = 0 Then Exit Sub

        Dim bSaltarSeleccionado As Boolean

        For Each ExistenteSeleccionado As DataGridViewRow In dgvProveedoresExistentes.SelectedRows
            bSaltarSeleccionado = False
            For Each Agregado As DataGridViewRow In dgvProveedoresArticulo.Rows
                If ExistenteSeleccionado.Cells("CODCTACTE").Value.ToString = Agregado.Cells("CODCTACTE").Value.ToString Then
                    bSaltarSeleccionado = True
                End If
            Next

            If bSaltarSeleccionado Then Continue For

            dgvProveedoresArticulo.Rows.Add({ExistenteSeleccionado.Cells("CODCTACTE").Value, ExistenteSeleccionado.Cells("NombreProveedor").Value})
        Next

        dgvProveedoresExistentes.ClearSelection()
    End Sub

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        For Each AgregadoSeleccionado As DataGridViewRow In dgvProveedoresArticulo.SelectedRows
            dgvProveedoresArticulo.Rows.Remove(AgregadoSeleccionado)
        Next

        dgvProveedoresArticulo.ClearSelection()
    End Sub

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        bConfirmarProveedores = True

        GuardarProveedores()

        Me.Close()
    End Sub

    Private Sub GuardarProveedores()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String
        Dim ColCodsProveedoresAntes, ColCodsProveedoresDespues As New Collection
        Dim bError As Boolean = False

        ColCodsProveedoresAntes.Clear()
        ColCodsProveedoresDespues.Clear()

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT CODCTACTE FROM HilamarArticulos_x_Proveedores " + _
               "WHERE idArticulo = " + idArticulo.ToString

        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()

        Do While Reader.HasRows
            Do While Reader.Read()
                ColCodsProveedoresAntes.Add(Reader.Item("CODCTACTE"), Reader.Item("CODCTACTE"))
            Loop
            Reader.NextResult()
        Loop

        For Each Row As DataGridViewRow In dgvProveedoresArticulo.Rows
            ColCodsProveedoresDespues.Add(Row.Cells("CODCTACTE").Value, Row.Cells("CODCTACTE").Value)
        Next

        For Each Item In ColCodsProveedoresAntes
            If Not ColCodsProveedoresDespues.Contains(Item) Then
                sStr = "DELETE FROM HilamarArticulos_x_Proveedores " + _
                       "WHERE idArticulo = " + idArticulo.ToString + " " + _
                       "AND CODCTACTE = '" + Item.ToString + "' "

                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                If Command.ExecuteNonQuery() = 0 Then
                    bError = True
                End If
            End If
        Next

        For Each Item In ColCodsProveedoresDespues
            If Not ColCodsProveedoresAntes.Contains(Item) Then
                sStr = "INSERT INTO HilamarArticulos_x_Proveedores " + _
                       "VALUES (" + idArticulo.ToString + ", '" + Item.ToString + "')"

                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                If Command.ExecuteNonQuery() = 0 Then
                    bError = True
                End If
            End If
        Next

        If bError Then
            MensajeCritico("No se pudo guardar los proveedores correctamente." + vbNewLine + "Por favor, verifique.")
        Else
            MensajeInfo("Se han guardado los proveedores correctamente.")
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub frmABMProveedores_Articulo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not bConfirmarProveedores Then
            If MsgBox("¿Está seguro que desea salir sin confirmar?" + vbNewLine + _
                      "Los datos ingresados hasta el momento se perderán definitivamente.", vbYesNo, "Hilamar") = MsgBoxResult.Yes Then
                Exit Sub
            Else
                e.Cancel = True
                dgvProveedoresExistentes.ClearSelection()
                dgvProveedoresArticulo.ClearSelection()
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtBuscador_TextChanged(sender As Object, e As EventArgs) Handles txtBuscador.TextChanged
        PintarDGVExistentes()
    End Sub
End Class