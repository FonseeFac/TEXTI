Imports System.Data.SqlClient

Public Class frmListado
    Public Pantalla As String
    Dim Command As New SqlCommand
    Dim Reader As SqlDataReader
    Dim sStr As String
    Dim ColListado As New Collection

    Public Sub Cargar()
        If Pantalla = "Hilado" Then
            Me.Text = "Listado de Hilados"
        ElseIf Pantalla = "HiladoInterno" Then
            Me.Text = "Listado de Hilados Internos"
        ElseIf Pantalla = "MateriaPrima" Then
            Me.Text = "Listado de Materias Primas"
        ElseIf Pantalla = "Procesos" Then
            Me.Text = "Listado de Procesos"
        ElseIf Pantalla = "TipoMovimientos" Then
            Me.Text = "Listado de Tipo de Movimientos"

        ElseIf Pantalla = "BuscaPartida" Then
            Me.Text = "Listado de Partidas"

        End If

        If Pantalla = "BuscaPartida" Then
            btnAgregar.Enabled = False
            btnModificar.Enabled = False
            btnEliminar.Enabled = False
            btnSeleccionar.Visible = True
        Else
            btnAgregar.Enabled = True
            btnModificar.Enabled = True
            btnEliminar.Enabled = True
            btnSeleccionar.Visible = False
        End If

        CargarListado()

    End Sub

    Public Sub CargarListado()

        lsbListado.Items.Clear()
        ColListado.Clear()

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        If Pantalla = "Hilado" Then
            sStr = "SELECT * FROM HilamarHilados WHERE Eliminado = 0 "
            If txtBuscar.Text <> "" Then
                sStr = sStr + "AND Descripcion like '%" + txtBuscar.Text + "%'"
            End If
        ElseIf Pantalla = "HiladoInterno" Then
            sStr = "SELECT * FROM HilamarHiladosInternos WHERE Eliminado = 0 "
            If txtBuscar.Text <> "" Then
                sStr = sStr + "AND Descripcion like '%" + txtBuscar.Text + "%'"
            End If
        ElseIf Pantalla = "MateriasPrimas" Then
            sStr = "SELECT * FROM HilamarMateriasPrimas WHERE Eliminado = 0 "
            If txtBuscar.Text <> "" Then
                sStr = sStr + "AND Descripcion like '%" + txtBuscar.Text + "%'"
            End If
        ElseIf Pantalla = "Procesos" Then
            sStr = "SELECT * FROM HilamarProcesos WHERE Eliminado = 0 "
            If txtBuscar.Text <> "" Then
                sStr = sStr + "AND Descripcion like '%" + txtBuscar.Text + "%'"
            End If
        ElseIf Pantalla = "TipoMovimientos" Then
            sStr = "SELECT * FROM HilamarTipoMovimientos WHERE Eliminado = 0 "
            If txtBuscar.Text <> "" Then
                sStr = sStr + "AND Descripcion like '%" + txtBuscar.Text + "%'"
            End If

        ElseIf Pantalla = "BuscaPartida" Then
            sStr = "SELECT * FROM HilamarHiladoStock H INNER JOIN HilamarTipoHiladoPartidas T ON H.Codtipohilado=T.Codigo  WHERE H.Eliminado=0 "
            sStr = sStr + " AND isnull(FechaStockDesde,'19000101')<=getdate() AND FechaStockHasta IS NULL "
            If txtBuscar.Text <> "" Then
                sStr = sStr + "AND H.Partida like '%" + txtBuscar.Text + "%'"
            End If

        Else

        End If
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read
                If Pantalla = "MateriasPrimas" Or Pantalla = "Procesos" Then
                    lsbListado.Items.Add(Reader.Item("id").ToString + " - " + Reader.Item("Descripcion").ToString)
                    ColListado.Add(Reader.Item("id").ToString, Reader.Item("id").ToString + " - " + Reader.Item("Descripcion").ToString)
                ElseIf Pantalla = "BuscaPartida" Then
                    lsbListado.Items.Add(Reader.Item("Partida").ToString + " - " + Reader.Item("CodTipoHilado").ToString + "(" + Reader.Item("Descripcion").ToString + ")")
                    ColListado.Add(Reader.Item("Partida").ToString, Reader.Item("Partida").ToString + " - " + Reader.Item("CodTipoHilado").ToString + "(" + Reader.Item("Descripcion").ToString + ")")
                Else
                    lsbListado.Items.Add(Reader.Item("Codigo").ToString + " - " + Reader.Item("Descripcion").ToString)
                    ColListado.Add(Reader.Item("id").ToString, Reader.Item("Codigo").ToString + " - " + Reader.Item("Descripcion").ToString)
                End If
            Loop
            Reader.NextResult()
        Loop

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        CargarListado()
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
        If Pantalla = "MateriasPrimas" Then
            If FormAbierto(frmABMMateriaPrima) Then Exit Sub

            Dim formABMMateriaPrima As New frmABMMateriaPrima
            formABMMateriaPrima.Pantalla = Pantalla.ToString
            formABMMateriaPrima.Alta = True
            formABMMateriaPrima.Cargar()
            formABMMateriaPrima.ShowDialog()
            CargarListado()
        ElseIf Pantalla = "HiladoInterno" Then
            If FormAbierto(frmABMHiladoInterno) Then Exit Sub

            Dim formABMHiladoInterno As New frmABMHiladoInterno
            formABMHiladoInterno.Pantalla = Pantalla.ToString
            formABMHiladoInterno.Alta = True
            formABMHiladoInterno.Cargar()
            formABMHiladoInterno.ShowDialog()
            CargarListado()
        Else
            If FormAbierto(frmABMSimple) Then Exit Sub

            Dim FormHilado As New frmABMSimple
            FormHilado.Pantalla = Pantalla.ToString
            FormHilado.Alta = True
            FormHilado.Cargar()
            FormHilado.ShowDialog()
            CargarListado()
        End If
    End Sub

    Private Sub Modificar()
        If lsbListado.Text = "" Then Exit Sub

        If Pantalla = "MateriasPrimas" Then
            If FormAbierto(frmABMMateriaPrima) Then Exit Sub

            Dim formABMMateriaPrima As New frmABMMateriaPrima
            formABMMateriaPrima.Pantalla = Pantalla.ToString
            formABMMateriaPrima.Alta = False
            formABMMateriaPrima.ID = ColListado.Item(lsbListado.Text)
            formABMMateriaPrima.Cargar()
            formABMMateriaPrima.ShowDialog()
            CargarListado()
        ElseIf Pantalla = "HiladoInterno" Then
            If FormAbierto(frmABMHiladoInterno) Then Exit Sub

            Dim formABMHiladoInterno As New frmABMHiladoInterno
            formABMHiladoInterno.Pantalla = Pantalla.ToString
            formABMHiladoInterno.Alta = False
            formABMHiladoInterno.ID = ColListado.Item(lsbListado.Text)
            formABMHiladoInterno.Cargar()
            formABMHiladoInterno.ShowDialog()
            CargarListado()
        Else
            If FormAbierto(frmABMSimple) Then Exit Sub

            Dim FormHilado As New frmABMSimple
            FormHilado.Pantalla = Pantalla.ToString
            FormHilado.Alta = False
            FormHilado.id = ColListado.Item(lsbListado.Text)
            FormHilado.Cargar()
            FormHilado.ShowDialog()
            CargarListado()
        End If
    End Sub

    Private Sub Eliminar()

        If lsbListado.Text <> "" Then
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", vbYesNo, "Textilana S. A.") = vbNo Then Exit Sub

            If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
            If Pantalla = "Hilado" Then
                sStr = "UPDATE HilamarHilados SET Eliminado = 1 WHERE id = " + ColListado(lsbListado.Text).ToString
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
            ElseIf Pantalla = "HiladoInterno" Then
                sStr = "UPDATE HilamarHiladosInternos SET Eliminado = 1 WHERE id = " + ColListado(lsbListado.Text).ToString
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
            ElseIf Pantalla = "MateriasPrimas" Then
                sStr = "UPDATE HilamarMateriasPrimas SET Eliminado = 1 WHERE id = " + ColListado(lsbListado.Text).ToString
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
            ElseIf Pantalla = "Procesos" Then
                sStr = "UPDATE HilamarProcesos SET Eliminado = 1 WHERE id = " + ColListado(lsbListado.Text).ToString
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
            ElseIf Pantalla = "TipoMovimientos" Then
                sStr = "UPDATE HilamarTipoMovimientos SET Eliminado = 1 WHERE id = " + ColListado(lsbListado.Text).ToString
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
            End If

            MensajeAtencion("Registro eliminado correctamente.")

            CargarListado()

        End If
    End Sub

    Private Sub lsbListado_DoubleClick(sender As Object, e As EventArgs) Handles lsbListado.DoubleClick
        If Pantalla = "BuscaPartida" Then
            Seleccionar()
        Else
            Modificar()
        End If
    End Sub

    Private Sub Seleccionar()
        ItemSeleccionado = ColListado(lsbListado.Text).ToString
        Close()
    End Sub

    Private Sub lsbListado_KeyDown(sender As Object, e As KeyEventArgs) Handles lsbListado.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Pantalla = "BuscaPartida" Then
                If lsbListado.SelectedIndex >= 0 Then
                    Seleccionar()
                End If
            End If
        End If
    End Sub

End Class