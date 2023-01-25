Imports System.Data.SqlClient

Public Class frmABMComposCostos

    Dim CotizacionDolar As Double = 0.0

    Dim ColListadoElementos As New Collection
    Dim ColListadoItems As New Collection

    Public Sub Cargar()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        CargarCombosTipos()

        ' ya traigo la cotizacion del dolar y la dejo lista
        sStr = "SELECT * FROM HilamarMonedas WHERE Nombre = 'Dolares'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                CotizacionDolar = Reader.Item("Cotizacion")
            End If
        End If

        LimpiarDGV()
        ArmarDGV()

        gbAgregarItem.Enabled = False

        cmbTipos.Select()
    End Sub

    Private Sub CargarCombosTipos()
        cmbTipos.Items.Clear()
        cmbTipos.Items.Add("HILADO")
        cmbTipos.Items.Add("HILADO INTERNO")
        cmbTipos.Items.Add("PROCESO")
        cmbTipos.SelectedIndex = 2

        cmbTipoItem.Items.Clear()
        cmbTipoItem.Items.Add("IN-Hilado Interno")
        cmbTipoItem.Items.Add("MP-Materia Prima")
        cmbTipoItem.Items.Add("HI-Hilado")
        cmbTipoItem.Items.Add("PG-Parámetro Gral.")
        cmbTipoItem.Items.Add("PR-Proceso")
        cmbTipoItem.SelectedIndex = -1
    End Sub

    Private Sub CargarComboElementos()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        'dependiendo de lo que tenga combotipos cargo los hilados o los procesos
        cmbElementos.Items.Clear()
        ColListadoElementos.Clear()

        If cmbTipos.Text = "HILADO" Then
            sStr = "SELECT * FROM HilamarHilados WHERE Eliminado = 0 Order by Descripcion"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            Do While Reader.HasRows
                Do While Reader.Read
                    cmbElementos.Items.Add(Reader.Item("Codigo").ToString + " - " + Reader.Item("Descripcion").ToString)
                    ColListadoElementos.Add(Reader.Item("id").ToString, Reader.Item("Codigo").ToString + " - " + Reader.Item("Descripcion").ToString)
                Loop
                Reader.NextResult()
            Loop
        ElseIf cmbTipos.Text = "HILADO INTERNO" Then
            sStr = "SELECT * FROM HilamarHiladosInternos WHERE Eliminado = 0 Order by Descripcion"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            Do While Reader.HasRows
                Do While Reader.Read
                    cmbElementos.Items.Add(Reader.Item("Codigo").ToString + " - " + Reader.Item("Descripcion").ToString)
                    ColListadoElementos.Add(Reader.Item("id").ToString, Reader.Item("Codigo").ToString + " - " + Reader.Item("Descripcion").ToString)
                Loop
                Reader.NextResult()
            Loop
        ElseIf cmbTipos.Text = "PROCESO" Then
            sStr = "SELECT * FROM HilamarProcesos WHERE Eliminado = 0 Order by Descripcion"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            Do While Reader.HasRows
                Do While Reader.Read
                    cmbElementos.Items.Add(Reader.Item("Descripcion").ToString)
                    ColListadoElementos.Add(Reader.Item("id").ToString, Reader.Item("Descripcion").ToString)
                Loop
                Reader.NextResult()
            Loop
        End If

    End Sub

    Private Sub LimpiarDGV()
        dgvCompoCostos.Rows.Clear()
        dgvCompoCostos.Columns.Clear()
    End Sub

    Private Sub ArmarDGV()
        dgvCompoCostos.Columns.Add("Id", "Id")
        dgvCompoCostos.Columns("Id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvCompoCostos.Columns("Id").Visible = False
        dgvCompoCostos.Columns.Add("Tipo", "Tipo")
        dgvCompoCostos.Columns("Tipo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        'dgvCompoCostos.Columns("Tipo").Visible = False
        dgvCompoCostos.Columns("Tipo").Width = 40
        dgvCompoCostos.Columns.Add("Idcomp", "Idcomp")
        dgvCompoCostos.Columns("Idcomp").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvCompoCostos.Columns("Idcomp").Visible = False
        dgvCompoCostos.Columns.Add("Descripción", "Descripción")
        dgvCompoCostos.Columns("Descripción").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvCompoCostos.Columns("Descripción").Width = 270
        dgvCompoCostos.Columns.Add("Factor", "Factor")
        dgvCompoCostos.Columns("Factor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCompoCostos.Columns("Factor").Width = 65
        dgvCompoCostos.Columns.Add("Precio", "Precio")
        dgvCompoCostos.Columns("Precio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCompoCostos.Columns("Precio").Width = 65
        dgvCompoCostos.Columns.Add("Costo", "Costo $/kg")
        dgvCompoCostos.Columns("Costo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvCompoCostos.Columns("Costo").Width = 85
        dgvCompoCostos.DefaultCellStyle.Font = New Font("Arial", 8)
        dgvCompoCostos.RowTemplate.Height = 18
    End Sub

    Private Sub cmdVolver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVolver.Click
        Close()
    End Sub

    Private Sub cmbTipos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipos.SelectedIndexChanged
        dgvCompoCostos.Rows.Clear()
        CargarComboElementos()
    End Sub

    Private Sub cmbElementos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbElementos.SelectedIndexChanged
        If cmbElementos.Text = "" Then Exit Sub

        lblCostoTotal.Text = Format(ObtenerComposiciondeCostos(cmbTipos.Text, ColListadoElementos.Item(cmbElementos.Text.ToString), True), "0.00")

    End Sub
    Private Sub rbColor_CheckedChanged(sender As Object, e As EventArgs)
        lblCostoTotal.Text = Format(ObtenerComposiciondeCostos(cmbTipos.Text, ColListadoElementos.Item(cmbElementos.Text.ToString), True), "0.00")
    End Sub

    Private Sub rbCrudo_CheckedChanged(sender As Object, e As EventArgs)
        lblCostoTotal.Text = Format(ObtenerComposiciondeCostos(cmbTipos.Text, ColListadoElementos.Item(cmbElementos.Text.ToString), True), "0.00")
    End Sub

    Private Function ObtenerComposiciondeCostos(ByVal TipoElemento As String, ByVal IdElemento As String, ByVal Mostrar As Boolean) As Double
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        Dim Descripcion As String = ""
        Dim Precio, Costo, CostoTotal As Double
        Dim row As String()

        If Mostrar Then dgvCompoCostos.Rows.Clear()

        CostoTotal = 0.0

        'Si es Hilado Interno debo ver si lleva composicion de costos o es costo fijo y de acuerdo a eso hago o no el bucle
        If TipoElemento = "HILADO INTERNO" Then
            sStr = "select * from HilamarHiladosInternos where Id = " + IdElemento
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read Then
                    If Not IsDBNull(Reader.Item("Moneda")) Or Not IsDBNull(Reader.Item("CostoPorKilo")) Then

                        If Mostrar Then
                            Descripcion = Reader.Item("Descripcion").ToString
                        End If

                        If Reader.Item("Moneda").ToString = "Dolares" Then
                            Precio = CotizacionDolar * Reader.Item("CostoPorKilo")
                        Else
                            Precio = Reader.Item("CostoPorKilo")
                        End If

                        Costo = 1 * Precio

                        If Mostrar Then
                            row = {Reader.Item("Id").ToString, "IN", Reader.Item("Id").ToString, Descripcion, _
                                   Format(1, "0.0000"), Format(Precio, "0.000"), Format(Costo, "0.00")}
                            dgvCompoCostos.Rows.Add(row)
                            dgvCompoCostos.Rows(dgvCompoCostos.RowCount - 1).ReadOnly = True
                        End If

                        CostoTotal = CostoTotal + Costo

                    End If
                End If
            End If

        End If

        If TipoElemento = "HILADO" Then
            sStr = "select * from HilamarCompCostosHilados where IdHil = " + IdElemento + " AND isnull(EsInterno,0)=0"
        ElseIf TipoElemento = "HILADO INTERNO" Then
            sStr = "select * from HilamarCompCostosHilados where IdHil = " + IdElemento + " AND isnull(EsInterno,0)=1"
        Else
            sStr = "select * from HilamarCompCostosProcesos where IdProc = " + IdElemento
        End If
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                If Mostrar Then
                    If IsNothing(Reader.Item("DescAdic")) Then
                        Descripcion = ObtengoDescripcionDelElemento(Reader.Item("Tipo").ToString, Reader.Item("IdComp").ToString)
                    ElseIf Reader.Item("DescAdic").ToString = "" Then
                        Descripcion = ObtengoDescripcionDelElemento(Reader.Item("Tipo").ToString, Reader.Item("IdComp").ToString)
                    Else
                        Descripcion = Reader.Item("DescAdic").ToString
                    End If
                End If

                Precio = ObtengoCostoDelElemento(Reader.Item("Tipo").ToString, Reader.Item("IdComp").ToString)
                Costo = Reader.Item("Factor") * Precio

                If Reader.Item("IdComp").ToString = "OS" Then
                    Costo = Costo / 1000
                End If

                If Mostrar Then
                    row = {Reader.Item("Id").ToString, Reader.Item("Tipo").ToString, Reader.Item("IdComp").ToString, Descripcion, _
                           Format(Reader.Item("Factor"), "0.0000"), Format(Precio, "0.000"), Format(Costo, "0.00")}
                    dgvCompoCostos.Rows.Add(row)
                    dgvCompoCostos.Rows(dgvCompoCostos.RowCount - 1).ReadOnly = True
                End If

                CostoTotal = CostoTotal + Costo
            Loop
            Reader.NextResult()
        Loop

        ObtenerComposiciondeCostos = CostoTotal

    End Function

    Private Function ObtengoDescripcionDelElemento(ByVal Tipo As String, ByVal IdComp As String) As String
        Dim CommandAux As New SqlCommand
        Dim ReaderAux As SqlDataReader
        Dim sStrAux As String

        Dim Retorno As String = ""
        If Tipo = "MP" Then
            sStrAux = "SELECT * FROM HilamarMateriasPrimas WHERE Id = " + IdComp + ""
            CommandAux = New SqlCommand(sStrAux, cConexionApp.SQLConn)
            ReaderAux = CommandAux.ExecuteReader()
            If ReaderAux.HasRows Then
                If ReaderAux.Read Then
                    Retorno = ReaderAux.Item("Descripcion")
                End If
            End If
        ElseIf Tipo = "PG" Then
            If IdComp = "HH" Then
                Retorno = "Horas Hombre"
            ElseIf IdComp = "GAS" Then
                Retorno = "GAS"
            ElseIf IdComp = "LUZ" Then
                Retorno = "LUZ"
            ElseIf IdComp = "OS" Then
                Retorno = "OBRAS SANITARIAS"
            End If
        ElseIf Tipo = "PR" Then
            sStrAux = "SELECT * FROM HilamarProcesos WHERE Id = " + IdComp + ""
            CommandAux = New SqlCommand(sStrAux, cConexionApp.SQLConn)
            ReaderAux = CommandAux.ExecuteReader()
            If ReaderAux.HasRows Then
                If ReaderAux.Read Then
                    Retorno = ReaderAux.Item("Descripcion")
                End If
            End If
        ElseIf Tipo = "HI" Then
            sStrAux = "SELECT * FROM HilamarHilados WHERE Id = " + IdComp + ""
            CommandAux = New SqlCommand(sStrAux, cConexionApp.SQLConn)
            ReaderAux = CommandAux.ExecuteReader()
            If ReaderAux.HasRows Then
                If ReaderAux.Read Then
                    Retorno = ReaderAux.Item("Descripcion")
                End If
            End If
        ElseIf Tipo = "IN" Then
            sStrAux = "SELECT * FROM HilamarHiladosInternos WHERE Id = " + IdComp + ""
            CommandAux = New SqlCommand(sStrAux, cConexionApp.SQLConn)
            ReaderAux = CommandAux.ExecuteReader()
            If ReaderAux.HasRows Then
                If ReaderAux.Read Then
                    Retorno = ReaderAux.Item("Descripcion")
                End If
            End If
        End If
        ObtengoDescripcionDelElemento = Retorno
    End Function

    Private Function ObtengoCostoDelElemento(ByVal Tipo As String, ByVal IdComp As String) As Double
        Dim CommandAux As New SqlCommand
        Dim ReaderAux As SqlDataReader
        Dim sStrAux As String

        Dim Retorno As Double = 0.0

        If Tipo = "MP" Then
            sStrAux = "SELECT * FROM HilamarMateriasPrimas WHERE Id = " + IdComp + ""
            CommandAux = New SqlCommand(sStrAux, cConexionApp.SQLConn)
            ReaderAux = CommandAux.ExecuteReader()
            If ReaderAux.HasRows Then
                If ReaderAux.Read Then
                    If ReaderAux.Item("Moneda").ToString = "Dolares" Then
                        Retorno = CotizacionDolar * ReaderAux.Item("CostoPorKilo")
                    Else
                        Retorno = ReaderAux.Item("CostoPorKilo")
                    End If
                End If
            End If
        ElseIf Tipo = "PG" Then
            If IdComp = "HH" Then
                sStrAux = "SELECT * FROM HilamarCostosParametrosGrales "
                CommandAux = New SqlCommand(sStrAux, cConexionApp.SQLConn)
                ReaderAux = CommandAux.ExecuteReader()
                If ReaderAux.HasRows Then
                    If ReaderAux.Read Then
                        Retorno = ReaderAux.Item("CostoHoraHombre") * ReaderAux.Item("FactorMultiplicadordelValorHoraHombre")
                    End If
                End If
            ElseIf IdComp = "GAS" Then
                sStrAux = "SELECT * FROM HilamarCostosParametrosGrales "
                CommandAux = New SqlCommand(sStrAux, cConexionApp.SQLConn)
                ReaderAux = CommandAux.ExecuteReader()
                If ReaderAux.HasRows Then
                    If ReaderAux.Read Then
                        Retorno = (ReaderAux.Item("TotalCamuzzi") + ReaderAux.Item("TotalEnergy")) / ReaderAux.Item("M3GasConsumidos")
                    End If
                End If
            ElseIf IdComp = "LUZ" Then
                sStrAux = "SELECT * FROM HilamarCostosParametrosGrales "
                CommandAux = New SqlCommand(sStrAux, cConexionApp.SQLConn)
                ReaderAux = CommandAux.ExecuteReader()
                If ReaderAux.HasRows Then
                    If ReaderAux.Read Then
                        Retorno = ReaderAux.Item("TotalEdea") / ReaderAux.Item("KWConsumidos")
                    End If
                End If
            ElseIf IdComp = "OS" Then
                sStrAux = "SELECT * FROM HilamarCostosParametrosGrales "
                CommandAux = New SqlCommand(sStrAux, cConexionApp.SQLConn)
                ReaderAux = CommandAux.ExecuteReader()
                If ReaderAux.HasRows Then
                    If ReaderAux.Read Then
                        Retorno = ReaderAux.Item("TotalObrasSanitarias") / ReaderAux.Item("M3AguaConsumidos")
                    End If
                End If
            End If
        ElseIf Tipo = "PR" Then

            Retorno = ObtenerComposiciondeCostos("PROCESO", IdComp, False)

        ElseIf Tipo = "HI" Then

            Retorno = ObtenerComposiciondeCostos("HILADO", IdComp, False)

        ElseIf Tipo = "IN" Then

            Retorno = ObtenerComposiciondeCostos("HILADO INTERNO", IdComp, False)

        End If
        ObtengoCostoDelElemento = Retorno
    End Function

    Private Sub cmdAgregar_Click(sender As Object, e As EventArgs) Handles cmdAgregar.Click
        'si no hay bada seleciconado y mostrando composicion de stock entonces no puede agregar, porque a donde lo agregaria?
        If cmbElementos.Text = "" Then Exit Sub

        gbAgregarItem.Enabled = True
    End Sub

    Private Sub cmbTipoItem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoItem.SelectedIndexChanged
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        'dependiendo de lo que tenga cmbTipoItem cargo los items
        cmbItems.Items.Clear()
        ColListadoItems.Clear()

        If Strings.Left(cmbTipoItem.Text, 2) = "MP" Then
            sStr = "SELECT * FROM HilamarMateriasPrimas WHERE Eliminado = 0 Order by Descripcion"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            Do While Reader.HasRows
                Do While Reader.Read
                    cmbItems.Items.Add(Reader.Item("Descripcion").ToString)
                    ColListadoItems.Add(Reader.Item("id").ToString, Reader.Item("Descripcion").ToString)
                Loop
                Reader.NextResult()
            Loop
        ElseIf Strings.Left(cmbTipoItem.Text, 2) = "HI" Then
            sStr = "SELECT * FROM HilamarHilados WHERE Eliminado = 0 Order by Descripcion"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            Do While Reader.HasRows
                Do While Reader.Read
                    cmbItems.Items.Add(Reader.Item("Codigo").ToString + " - " + Reader.Item("Descripcion").ToString)
                    ColListadoItems.Add(Reader.Item("id").ToString, Reader.Item("Codigo").ToString + " - " + Reader.Item("Descripcion").ToString)
                Loop
                Reader.NextResult()
            Loop
        ElseIf Strings.Left(cmbTipoItem.Text, 2) = "IN" Then
            sStr = "SELECT * FROM HilamarHiladosInternos WHERE Eliminado = 0 Order by Descripcion"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            Do While Reader.HasRows
                Do While Reader.Read
                    cmbItems.Items.Add(Reader.Item("Codigo").ToString + " - " + Reader.Item("Descripcion").ToString)
                    ColListadoItems.Add(Reader.Item("id").ToString, Reader.Item("Codigo").ToString + " - " + Reader.Item("Descripcion").ToString)
                Loop
                Reader.NextResult()
            Loop
        ElseIf Strings.Left(cmbTipoItem.Text, 2) = "PR" Then
            sStr = "SELECT * FROM HilamarProcesos WHERE Eliminado = 0 Order by Descripcion"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            Do While Reader.HasRows
                Do While Reader.Read
                    cmbItems.Items.Add(Reader.Item("Descripcion").ToString)
                    ColListadoItems.Add(Reader.Item("id").ToString, Reader.Item("Descripcion").ToString)
                Loop
                Reader.NextResult()
            Loop
        ElseIf Strings.Left(cmbTipoItem.Text, 2) = "PG" Then

            cmbItems.Items.Add("m3 AGUA")
            cmbItems.Items.Add("m3 GAS")
            cmbItems.Items.Add("Kw/h LUZ")
            cmbItems.Items.Add("Hora Hombre")

        End If

    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Cancelar()
    End Sub
    Private Sub Cancelar()
        txtDescAdic.Text = ""
        txtFactorMulti.Text = ""
        cmbItems.Items.Clear()
        cmbTipoItem.SelectedIndex = -1
        gbAgregarItem.Enabled = False
    End Sub

    Private Sub cmdGuardar_Click(sender As Object, e As EventArgs) Handles cmdGuardar.Click
        Guardar(cmbTipos.Text, ColListadoElementos.Item(cmbElementos.Text.ToString))
    End Sub
    Private Sub Guardar(ByVal TipoElemento As String, ByVal IdElemento As String)
        Dim Command As New SqlCommand
        Dim sStr As String

        Dim idComp As String = ""

        If Not Validar() Then Exit Sub

        If Strings.Left(cmbTipoItem.Text, 2) = "PG" Then
            If cmbItems.Text = "m3 AGUA" Then
                idComp = "OS"
            ElseIf cmbItems.Text = "m3 GAS" Then
                idComp = "GAS"
            ElseIf cmbItems.Text = "Kw/h LUZ" Then
                idComp = "LUZ"
            ElseIf cmbItems.Text = "Hora Hombre" Then
                idComp = "HH"
            End If
        Else
            idComp = ColListadoItems.Item(cmbItems.Text.ToString)
        End If

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        If TipoElemento = "HILADO" Then

            sStr = "INSERT INTO HilamarCompCostosHilados (IdHil, EsInterno, Tipo, IdComp, DescAdic, Factor) VALUES (" + IdElemento + ", " + "0"
            sStr = sStr + ", '" + Strings.Left(cmbTipoItem.Text, 2) + "', '" + idComp + "', '" + txtDescAdic.Text + "', " + txtFactorMulti.Text.Replace(",", ".") + ")"

        ElseIf TipoElemento = "HILADO INTERNO" Then

            sStr = "INSERT INTO HilamarCompCostosHilados (IdHil, EsInterno, Tipo, IdComp, DescAdic, Factor) VALUES (" + IdElemento + ", " + "1"
            sStr = sStr + ", '" + Strings.Left(cmbTipoItem.Text, 2) + "', '" + idComp + "', '" + txtDescAdic.Text + "', " + txtFactorMulti.Text.Replace(",", ".") + ")"

        Else

            sStr = "INSERT INTO HilamarCompCostosProcesos (IdProc, Tipo, IdComp, DescAdic, Factor) VALUES (" + IdElemento
            sStr = sStr + ", '" + Strings.Left(cmbTipoItem.Text, 2) + "', '" + idComp + "', '" + txtDescAdic.Text + "', " + txtFactorMulti.Text.Replace(",", ".") + ")"

        End If

        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        MensajeAtencion("Componente de Stock agregado correctamente.")
        'luego de guardar llamo al procedimiento cancelar para que se limpie la ventanita de carga
        Cancelar()
        'y luego vuelvo a cargar la composicion de costo de stock del elemento para que se vea el nuevo item agregado
        lblCostoTotal.Text = Format(ObtenerComposiciondeCostos(cmbTipos.Text, ColListadoElementos.Item(cmbElementos.Text.ToString), True), "0.00")

    End Sub

    Private Function Validar()
        On Error GoTo ErrValidar

        If cmbTipoItem.SelectedIndex < 0 Then
            Validar = False
            MensajeAtencion("Debe seleccionar un tipo de Item.")
            Exit Function
        End If

        If cmbItems.SelectedIndex < 0 Then
            Validar = False
            MensajeAtencion("Debe ingresar un Item.")
            Exit Function
        End If

        If txtFactorMulti.Text = "" Then
            txtFactorMulti.Text = "0"
        End If

        If Not IsNumeric(txtFactorMulti.Text) Then
            Validar = False
            MensajeAtencion("El Factor Multiplicador debe ser un número.")
            Exit Function
        End If

        Validar = True

        Exit Function
ErrValidar:
        Validar = False
        MensajeAtencion("Error al validar.")
    End Function

    Private Sub cmdEliminar_Click(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        Dim Command As New SqlCommand
        Dim sStr As String

        If dgvCompoCostos.RowCount <= 0 Then Exit Sub

        If dgvCompoCostos.CurrentRow.Index < 0 Then Exit Sub

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        If cmbTipos.Text = "HILADO" Then
            sStr = "DELETE FROM HilamarCompCostosHilados WHERE Id=" + dgvCompoCostos.Rows(dgvCompoCostos.CurrentRow.Index).Cells("Id").Value
        Else
            sStr = "DELETE FROM HilamarCompCostosProcesos WHERE Id=" + dgvCompoCostos.Rows(dgvCompoCostos.CurrentRow.Index).Cells("Id").Value
        End If
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        MensajeAtencion("Componente de Stock eliminado correctamente.")

        'y luego vuelvo a cargar la composicion de costo de stock del elemento para que se vea el nuevo item agregado
        lblCostoTotal.Text = Format(ObtenerComposiciondeCostos(cmbTipos.Text, ColListadoElementos.Item(cmbElementos.Text.ToString), True), "0.00")

    End Sub

End Class