Imports System.Data.SqlClient

Public Class frmArtProdAccABM

    Public Alta As Boolean
    Public ID As Integer
    Dim Command As New SqlCommand
    Dim Reader As SqlDataReader
    Dim sStr As String

    'Dim ColCategoria As New Collection
    'Dim ColCategoriaIdsClaves As New Collection

    Dim CambiarPartidaColorOP As Boolean
    Dim ImprimirFechaHoy As Boolean
    Public NuevoColor As String
    Public NuevaPartida As String
    Public NuevaOp As String

    Dim EsArtOriginal As Integer = 0

    Dim LegajoLogueado As String 'legajo de quien va a trabajar
    Dim IdPlanilla As String ' Id de la planilla a la que pertenece el accesorio
    Dim TipoPlanilla As String ' tipo de la planilla a la que pertenece el accesorio

    Sub New(ByVal parametro1 As String, ByVal parametro2 As String, ByVal parametro3 As String)

        InitializeComponent() 'es necesario que lleve esta linea

        LegajoLogueado = parametro1
        IdPlanilla = parametro2
        TipoPlanilla = parametro3

    End Sub

    Public Sub Cargar()
        ''primero que nada cargo las categorias
        ''si las categorias ya estan cargadas es que estoy entrando porque llame al procedimiento cargar desde otro lado, pero no estoy cargando la primer vez
        ''solo cargo las categorias la primer vez, que entra al formulario, despues no, asi cuando cambia la seleccion del combo por ejemplo no borro nada
        'If ColCategoria.Count <= 0 Then
        '    sStr = "SELECT * FROM PrendasArtProdCategorias WHERE Eliminado = 0 Order by Descripcion"
        '    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        '    Reader = Command.ExecuteReader()
        '    Do While Reader.HasRows
        '        Do While Reader.Read
        '            ColCategoria.Add(Reader.Item("id").ToString, Reader.Item("Descripcion").ToString)
        '            ColCategoriaIdsClaves.Add(Reader.Item("Descripcion").ToString, Reader.Item("id").ToString)
        '        Loop
        '        Reader.NextResult()
        '    Loop
        'End If


        'primero cargo los datos de la planilla a la que pertenece, sea alta o no, estos datos son siempre los mismos, proque el accesorio es de una planilla
        sStr = "SELECT * FROM PrendasArtProdPlanillas WHERE id = " + IdPlanilla.ToString
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                If Not IsDBNull(Reader.Item("EsOriginal")) Then EsArtOriginal = Reader.Item("EsOriginal")
                If Not IsDBNull(Reader.Item("Fecha")) Then dtpFecha.Value = Reader.Item("Fecha")
                txtArticulo.Text = Reader.Item("Articulo").ToString
                txtOp.Text = Reader.Item("OP").ToString
                txtColor.Text = Reader.Item("Color").ToString
                txtPartida.Text = Reader.Item("Partida").ToString
                txtPatron.Text = Reader.Item("Diseño").ToString
            End If
        End If

        If Not Alta Then
            cmdCopiarEnOtra.Enabled = True
            If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
            'luego cargo los datos del accesorio propiamente dicho
            sStr = "SELECT * FROM PrendasArtProdPlanillasAccesorios WHERE id = " + ID.ToString
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read Then
                    If Not IsDBNull(Reader.Item("Fecha")) Then dtpFecha.Value = Reader.Item("Fecha")
                    txtPatron.Text = Reader.Item("Patron").ToString
                    txtMedFinal.Text = Reader.Item("MedidaFinal").ToString
                    txtTitulo.Text = Reader.Item("DescAccesorio").ToString
                    txtCuadro1.Text = Reader.Item("Cuadro1").ToString
                    txtCuadro2.Text = Reader.Item("Cuadro2").ToString
                    txtCuadro3.Text = Reader.Item("Cuadro3").ToString
                    txtCuadro4.Text = Reader.Item("Cuadro4").ToString
                    txtCuadro5.Text = Reader.Item("Cuadro5").ToString
                    txtCuadro6.Text = Reader.Item("Cuadro6").ToString
                    txtCuadro7.Text = Reader.Item("Cuadro7").ToString
                    txtCuadro8.Text = Reader.Item("Cuadro8").ToString
                End If
            End If
            CargarGraduaciones()
            CargarPicos()
        Else
            cmdCopiarEnOtra.Enabled = False
            CargarGraduaciones()
            CargarPicos()
        End If

        'estos datos no se pueden editar nunca segun lo que me dijeron
        txtArticulo.Enabled = False
        txtOp.Enabled = False
        txtPartida.Enabled = False
        txtColor.Enabled = False
        'el patron si se puede editar
        'txtPatron.Enabled = False

        If Alta Then
            cmdCopiar.Enabled = False
            cmdImprimir.Enabled = False
        Else
            cmdCopiar.Enabled = True
            cmdImprimir.Enabled = True
        End If

        txtTitulo.Select()

    End Sub

    Private Sub CargarGraduaciones()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr, strDesc2 As String
        Dim row As String()

        LimpiarDGV_Graduaciones()
        ArmarDGV_Graduaciones()

        strDesc2 = ""

        Dim i As Integer = 0
        sStr = "SELECT * FROM PrendasArtProdPlanillasAcces_Graduaciones WHERE IdAccesorio = " + ID.ToString + " order by id "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read
                If TipoPlanilla = "STOLL" Then
                    row = {Reader.Item("Letra"), Reader.Item("Cuadro1"), Reader.Item("Cuadro2"), Reader.Item("Descripcion1"), ""}
                    dgvGraduaciones.Rows.Add(row)
                Else
                    If Not IsDBNull(Reader.Item("Descripcion2")) Then
                        strDesc2 = Reader.Item("Descripcion2").ToString
                    Else
                        strDesc2 = ""
                    End If
                    row = {Reader.Item("Letra"), Reader.Item("Cuadro1"), Reader.Item("Cuadro2"), Reader.Item("Descripcion1"), strDesc2.ToString}
                    dgvGraduaciones.Rows.Add(row)
                End If
                i += 1
            Loop
            Reader.NextResult()
        Loop

        Do While i < 20
            If TipoPlanilla = "STOLL" Then
                row = {"", "", "", "", ""}
                dgvGraduaciones.Rows.Add(row)
            Else
                row = {"", "", "", "", ""}
                dgvGraduaciones.Rows.Add(row)
            End If
            i += 1
        Loop

    End Sub

    Private Sub LimpiarDGV_Graduaciones()
        dgvGraduaciones.Rows.Clear()
        dgvGraduaciones.Columns.Clear()
    End Sub

    Private Sub ArmarDGV_Graduaciones()

        dgvGraduaciones.Columns.Add("LETRA", "LETRA")
        dgvGraduaciones.Columns("LETRA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGraduaciones.Columns("LETRA").Width = 100
        dgvGraduaciones.Columns.Add("C1", "C1")
        dgvGraduaciones.Columns("C1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGraduaciones.Columns("C1").Width = 99
        dgvGraduaciones.Columns.Add("C2", "C2")
        dgvGraduaciones.Columns("C2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvGraduaciones.Columns("C2").Width = 99
        If TipoPlanilla = "STOLL" Then
            dgvGraduaciones.Columns.Add("DESC1", "DESC1")
            dgvGraduaciones.Columns("DESC1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvGraduaciones.Columns("DESC1").Width = 292
            dgvGraduaciones.Columns.Add("DESC2", "DESC2")
            dgvGraduaciones.Columns("DESC2").Visible = False
        Else
            dgvGraduaciones.Columns.Add("DESC1", "DESC1")
            dgvGraduaciones.Columns("DESC1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvGraduaciones.Columns("DESC1").Width = 146
            dgvGraduaciones.Columns.Add("DESC2", "DESC2")
            dgvGraduaciones.Columns("DESC2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvGraduaciones.Columns("DESC2").Width = 146
        End If

        dgvGraduaciones.ColumnHeadersVisible = False
        dgvGraduaciones.RowHeadersVisible = False
        dgvGraduaciones.DefaultCellStyle.Font = New Font("Tahoma", 9)
        dgvGraduaciones.RowTemplate.Height = 19

    End Sub

    Private Sub CargarPicos()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String
        Dim row As String()

        LimpiarDGV_Picos()
        ArmarDGV_Picos()

        Dim i As Integer = 0

        'primero pongo todo vacio
        For i = 0 To 3
            row = {"", "", "", "", "", "", "", ""}
            dgvPicos.Rows.Add(row)
        Next

        'luego lleno las celdas con lo que tenga valor
        sStr = "SELECT Pico,ISNULL(Derecha1,'') as Derecha1,ISNULL(Derecha2,'') as derecha2,ISNULL(Izquierda1,'') as Izquierda1,ISNULL(Izquierda2,'') as Izquierda2 "
        sStr = sStr + " FROM PrendasArtProdPlanillasAcces_Picos WHERE IdAccesorio = " + ID.ToString + " order by Pico "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read
                dgvPicos.Rows(0).Cells("PICO" & Reader.Item("Pico").ToString).Value = Reader.Item("Derecha1").ToString
                dgvPicos.Rows(1).Cells("PICO" & Reader.Item("Pico").ToString).Value = Reader.Item("Derecha2").ToString
                dgvPicos.Rows(2).Cells("PICO" & Reader.Item("Pico").ToString).Value = Reader.Item("Izquierda1").ToString
                dgvPicos.Rows(3).Cells("PICO" & Reader.Item("Pico").ToString).Value = Reader.Item("Izquierda2").ToString
            Loop
            Reader.NextResult()
        Loop
    End Sub

    Private Sub LimpiarDGV_Picos()
        dgvPicos.Rows.Clear()
        dgvPicos.Columns.Clear()
    End Sub

    Private Sub ArmarDGV_Picos()

        dgvPicos.Columns.Add("PICO1", "PICO1")
        dgvPicos.Columns("PICO1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPicos.Columns("PICO1").Width = 99
        dgvPicos.Columns.Add("PICO2", "PICO2")
        dgvPicos.Columns("PICO2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPicos.Columns("PICO2").Width = 100
        dgvPicos.Columns.Add("PICO3", "PICO3")
        dgvPicos.Columns("PICO3").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPicos.Columns("PICO3").Width = 100
        dgvPicos.Columns.Add("PICO4", "PICO4")
        dgvPicos.Columns("PICO4").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPicos.Columns("PICO4").Width = 100
        dgvPicos.Columns.Add("PICO5", "PICO5")
        dgvPicos.Columns("PICO5").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPicos.Columns("PICO5").Width = 100
        dgvPicos.Columns.Add("PICO6", "PICO6")
        dgvPicos.Columns("PICO6").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPicos.Columns("PICO6").Width = 100
        dgvPicos.Columns.Add("PICO7", "PICO7")
        dgvPicos.Columns("PICO7").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPicos.Columns("PICO7").Width = 100
        dgvPicos.Columns.Add("PICO8", "PICO8")
        dgvPicos.Columns("PICO8").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvPicos.Columns("PICO8").Width = 108

        dgvPicos.ColumnHeadersVisible = False
        dgvPicos.RowHeadersVisible = False
        dgvPicos.DefaultCellStyle.Font = New Font("Tahoma", 9)
        dgvPicos.RowTemplate.Height = 19

    End Sub

    Private Sub cmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        Guardar()
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Close()
    End Sub

    Private Sub Guardar()
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        If Not Validar() Then Exit Sub
        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        If Alta Then

            sStr = "INSERT INTO PrendasArtProdPlanillasAccesorios (IdPlanilla,DescAccesorio,Fecha,Articulo,OP,Patron,Color,Partida,MedidaFinal,Cuadro1,Cuadro2,Cuadro3"
            sStr = sStr + ",Cuadro4,Cuadro5,Cuadro6,Cuadro7,Cuadro8) VALUES (" + IdPlanilla + ",'" + txtTitulo.Text + "'"
            sStr = sStr + ",'" + Format(dtpFecha.Value, "yyyyMMdd") + "','" + txtArticulo.Text + "','" + txtOp.Text + "','" + txtPatron.Text + "'"
            sStr = sStr + ",'" + txtColor.Text + "','" + txtPartida.Text + "','" + txtMedFinal.Text + "','" + txtCuadro1.Text + "'"
            sStr = sStr + ",'" + txtCuadro2.Text + "','" + txtCuadro3.Text + "','" + txtCuadro4.Text + "','" + txtCuadro5.Text + "'"
            sStr = sStr + ",'" + txtCuadro6.Text + "','" + txtCuadro7.Text + "','" + txtCuadro8.Text + "')"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()

            'una vez que inserto traigo el id asi inserto las demas cosas
            sStr = "SELECT max(id) as Id FROM PrendasArtProdPlanillasAccesorios WHERE IdPlanilla=" + IdPlanilla
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read Then
                    ID = Reader.Item("Id").ToString
                End If
            End If

            'las graduaciones
            For i = 0 To 19
                If TipoPlanilla = "STOLL" Then
                    If Not IsNothing(dgvGraduaciones.Rows(i).Cells("LETRA").Value) Or Not IsNothing(dgvGraduaciones.Rows(i).Cells("C1").Value) _
                        Or Not IsNothing(dgvGraduaciones.Rows(i).Cells("C2").Value) Or Not IsNothing(dgvGraduaciones.Rows(i).Cells("DESC1").Value) Then
                        sStr = "INSERT INTO PrendasArtProdPlanillasAcces_Graduaciones (IdAccesorio,Letra,Cuadro1,Cuadro2,Descripcion1,Descripcion2) VALUES ("
                        sStr = sStr + ID.ToString + ", '" + dgvGraduaciones.Rows(i).Cells("LETRA").Value + "', '" + dgvGraduaciones.Rows(i).Cells("C1").Value + "', '"
                        sStr = sStr + dgvGraduaciones.Rows(i).Cells("C2").Value + "', '" + dgvGraduaciones.Rows(i).Cells("DESC1").Value + "', NULL)"
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Else
                    If dgvGraduaciones.Rows(i).Cells("LETRA").Value.ToString <> "" Or dgvGraduaciones.Rows(i).Cells("C1").Value.ToString <> "" _
                        Or dgvGraduaciones.Rows(i).Cells("C2").Value.ToString <> "" Or dgvGraduaciones.Rows(i).Cells("DESC1").Value.ToString <> "" _
                        Or dgvGraduaciones.Rows(i).Cells("DESC2").Value.ToString <> "" Then
                        sStr = "INSERT INTO PrendasArtProdPlanillasAcces_Graduaciones (IdAccesorio,Letra,Cuadro1,Cuadro2,Descripcion1,Descripcion2) VALUES ("
                        sStr = sStr + ID.ToString + ", '" + dgvGraduaciones.Rows(i).Cells("LETRA").Value + "', '" + dgvGraduaciones.Rows(i).Cells("C1").Value + "', '"
                        sStr = sStr + dgvGraduaciones.Rows(i).Cells("C2").Value + "', '" + dgvGraduaciones.Rows(i).Cells("DESC1").Value + "', '"
                        sStr = sStr + dgvGraduaciones.Rows(i).Cells("DESC2").Value + "')"
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                End If
            Next

            'los picos
            For i = 0 To 7
                If Not IsNothing(dgvPicos.Rows(0).Cells(i).Value) Or Not IsNothing(dgvPicos.Rows(1).Cells(i).Value) _
                        Or Not IsNothing(dgvPicos.Rows(2).Cells(i).Value) Or Not IsNothing(dgvPicos.Rows(3).Cells(i).Value) Then
                    sStr = "INSERT INTO PrendasArtProdPlanillasAcces_Picos (IdAccesorio,Pico,Derecha1,Derecha2,Izquierda1,Izquierda2) VALUES ("
                    sStr = sStr + ID.ToString + ", " + (i + 1).ToString + ",'" + dgvPicos.Rows(0).Cells(i).Value + "', '" + dgvPicos.Rows(1).Cells(i).Value + "', '"
                    sStr = sStr + dgvPicos.Rows(2).Cells(i).Value + "', '" + dgvPicos.Rows(3).Cells(i).Value + "')"
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Next

            RegistroEnHistorial("A", ID.ToString, "AltaAccesorio", LegajoLogueado)

            MensajeInfo("Accesorio agregado correctamente.")
            Alta = False
            Close()

        Else

            sStr = "INSERT INTO PrendasArtProdPlanillasAccesorios (IdPlanilla,DescAccesorio,Fecha,Articulo,OP,Patron,Color,Partida,MedidaFinal,Cuadro1,Cuadro2,Cuadro3"
            sStr = sStr + ",Cuadro4,Cuadro5,Cuadro6,Cuadro7,Cuadro8) VALUES (" + IdPlanilla + ",'" + txtTitulo.Text + "'"
            sStr = sStr + ",'" + Format(dtpFecha.Value, "yyyyMMdd") + "','" + txtArticulo.Text + "','" + txtOp.Text + "','" + txtPatron.Text + "'"
            sStr = sStr + ",'" + txtColor.Text + "','" + txtPartida.Text + "','" + txtMedFinal.Text + "','" + txtCuadro1.Text + "'"
            sStr = sStr + ",'" + txtCuadro2.Text + "','" + txtCuadro3.Text + "','" + txtCuadro4.Text + "','" + txtCuadro5.Text + "'"
            sStr = sStr + ",'" + txtCuadro6.Text + "','" + txtCuadro7.Text + "','" + txtCuadro8.Text + "')"

            sStr = "UPDATE PrendasArtProdPlanillasAccesorios SET IdPlanilla=" + IdPlanilla + ",DescAccesorio='" + txtTitulo.Text + "',Fecha='" + Format(dtpFecha.Value, "yyyyMMdd")
            sStr = sStr + "',Articulo='" + txtArticulo.Text + "',OP='" + txtOp.Text + "',Patron='" + txtPatron.Text + "',Color='" + txtColor.Text + "'"
            sStr = sStr + ",Partida='" + txtPartida.Text + "',MedidaFinal='" + txtMedFinal.Text + "',Cuadro1='" + txtCuadro1.Text + "',Cuadro2='" + txtCuadro2.Text + "'"
            sStr = sStr + ",Cuadro3='" + txtCuadro3.Text + "',Cuadro4='" + txtCuadro4.Text + "',Cuadro5='" + txtCuadro5.Text + "',Cuadro6='" + txtCuadro6.Text + "'"
            sStr = sStr + ",Cuadro7='" + txtCuadro7.Text + "',Cuadro8='" + txtCuadro8.Text + "'"
            sStr = sStr + " WHERE id = " + ID.ToString
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()

            'las graduaciones
            sStr = "DELETE FROM PrendasArtProdPlanillasAcces_Graduaciones WHERE IdAccesorio=" + ID.ToString
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()
            For i = 0 To 19
                If TipoPlanilla = "STOLL" Then
                    If dgvGraduaciones.Rows(i).Cells("LETRA").Value.ToString <> "" Or dgvGraduaciones.Rows(i).Cells("C1").Value.ToString <> "" _
                        Or dgvGraduaciones.Rows(i).Cells("C2").Value.ToString <> "" Or dgvGraduaciones.Rows(i).Cells("DESC1").Value.ToString <> "" Then
                        sStr = "INSERT INTO PrendasArtProdPlanillasAcces_Graduaciones (IdAccesorio,Letra,Cuadro1,Cuadro2,Descripcion1,Descripcion2) VALUES ("
                        sStr = sStr + ID.ToString + ", '" + dgvGraduaciones.Rows(i).Cells("LETRA").Value + "', '" + dgvGraduaciones.Rows(i).Cells("C1").Value + "', '"
                        sStr = sStr + dgvGraduaciones.Rows(i).Cells("C2").Value + "', '" + dgvGraduaciones.Rows(i).Cells("DESC1").Value + "', NULL)"
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                Else
                    If dgvGraduaciones.Rows(i).Cells("LETRA").Value.ToString <> "" Or dgvGraduaciones.Rows(i).Cells("C1").Value.ToString <> "" _
                        Or dgvGraduaciones.Rows(i).Cells("C2").Value.ToString <> "" Or dgvGraduaciones.Rows(i).Cells("DESC1").Value.ToString <> "" _
                        Or dgvGraduaciones.Rows(i).Cells("DESC2").Value.ToString <> "" Then
                        sStr = "INSERT INTO PrendasArtProdPlanillasAcces_Graduaciones (IdAccesorio,Letra,Cuadro1,Cuadro2,Descripcion1,Descripcion2) VALUES ("
                        sStr = sStr + ID.ToString + ", '" + dgvGraduaciones.Rows(i).Cells("LETRA").Value + "', '" + dgvGraduaciones.Rows(i).Cells("C1").Value + "', '"
                        sStr = sStr + dgvGraduaciones.Rows(i).Cells("C2").Value + "', '" + dgvGraduaciones.Rows(i).Cells("DESC1").Value + "', '"
                        sStr = sStr + dgvGraduaciones.Rows(i).Cells("DESC2").Value + "')"
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                    End If
                End If
            Next

            'los picos
            sStr = "DELETE FROM PrendasArtProdPlanillasAcces_Picos WHERE IdAccesorio=" + ID.ToString
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()
            For i = 0 To 7
                If Not IsNothing(dgvPicos.Rows(0).Cells(i).Value) Or Not IsNothing(dgvPicos.Rows(1).Cells(i).Value) _
                        Or Not IsNothing(dgvPicos.Rows(2).Cells(i).Value) Or Not IsNothing(dgvPicos.Rows(3).Cells(i).Value) Then
                    sStr = "INSERT INTO PrendasArtProdPlanillasAcces_Picos (IdAccesorio,Pico,Derecha1,Derecha2,Izquierda1,Izquierda2) VALUES ("
                    sStr = sStr + ID.ToString + ", " + (i + 1).ToString + ",'" + dgvPicos.Rows(0).Cells(i).Value + "', '" + dgvPicos.Rows(1).Cells(i).Value + "', '"
                    sStr = sStr + dgvPicos.Rows(2).Cells(i).Value + "', '" + dgvPicos.Rows(3).Cells(i).Value + "')"
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Next

            RegistroEnHistorial("A", ID.ToString, "ModifAccesorio", LegajoLogueado)

            MensajeInfo("Accesorio modificado correctamente.")

        End If

    End Sub

    Private Function Validar()
        On Error GoTo ErrValidar

        If Not Alta And EsArtOriginal Then
            Validar = False
            MensajeAtencion("El artículo está marcado como ORIGINAL. Los accesorios no pueden ser editados.")
            Exit Function
        End If

        If txtTitulo.Text = "" Then
            Validar = False
            MensajeAtencion("Debe ingresar un Título para el accesorio.")
            Exit Function
        End If

        If Alta Then
            If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
            sStr = "SELECT * FROM PrendasArtProdPlanillasAccesorios WHERE IdPlanilla = " + IdPlanilla + " and DescAccesorio='" + txtTitulo.Text + "'"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read Then
                    Validar = False
                    MensajeAtencion("Ya existe un Accesorio con igual Título.")
                    Exit Function
                End If
            End If
        End If

        Validar = True

        Exit Function
ErrValidar:
        Validar = False
        MensajeAtencion("Error al validar.")
    End Function

    Private Sub RegistroEnHistorial(ByVal TipoElem As String, ByVal IdElem As String, ByVal TipoModif As String, ByVal Legajo As String, Optional ByVal Fecha As String = "", Optional ByVal Correccion As String = "")
        Dim Command As New SqlCommand
        Dim sStr As String

        If TipoElem = "C" Then
            sStr = "INSERT INTO PrendasArtProdPlanillasHistorial (TipoElem,IdElem,TipoModif,FechaModif,Legajo,Fecha,Correccion) VALUES ('"
            sStr = sStr + TipoElem + "', '" + IdElem + "', '" + TipoModif + "',getdate(),'" + Legajo + "'," + Fecha + "," + Correccion + ")"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()
        Else
            sStr = "INSERT INTO PrendasArtProdPlanillasHistorial (TipoElem,IdElem,TipoModif,FechaModif,Legajo,Fecha,Correccion) VALUES ('"
            sStr = sStr + TipoElem + "', '" + IdElem + "', '" + TipoModif + "',getdate(),'" + Legajo + "',NULL,NULL)"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()
        End If
    End Sub

    Private Sub cmdCopiar_Click(sender As Object, e As EventArgs) Handles cmdCopiar.Click
        Alta = True
        ID = 0
        'cmbCategoria.SelectedIndex = -1
        dtpFecha.Value = Now
        txtTitulo.Text = ""
        txtTitulo.Select()
    End Sub

    '##########################################################################################################################################################
    '##########################################################################################################################################################
    '##########################################################################################################################################################
    '##########################################################################################################################################################

    Private Sub cmdImprimir_Click(sender As Object, e As EventArgs) Handles cmdImprimir.Click
        If ID <= 0 Then
            'SOLO SE PUEDEN IMPRIMIR LAS PLANILLAS QUE YA ESTAN DADAS DE ALTA
            Exit Sub
        End If

        Dim formOpcionesdeImpresion As New frmOpcionesdeImpresion()
        formOpcionesdeImpresion.EsAccesorio = True
        formOpcionesdeImpresion.Cargar()
        formOpcionesdeImpresion.ShowDialog(Me)
        If formOpcionesdeImpresion.CambiarPartidaColorOP Then
            CambiarPartidaColorOP = True
            NuevoColor = formOpcionesdeImpresion.NuevoColor
            NuevaPartida = formOpcionesdeImpresion.NuevaPartida
            NuevaOp = formOpcionesdeImpresion.NuevaOp
        Else
            CambiarPartidaColorOP = False
        End If
        If formOpcionesdeImpresion.ImprimirFechaHoy Then
            ImprimirFechaHoy = True
        Else
            ImprimirFechaHoy = False
        End If
        If formOpcionesdeImpresion.SeConfirmoOK Then
            formOpcionesdeImpresion.Close()

            pdoImpAccesorio.DefaultPageSettings.Landscape = False
            pdoImpAccesorio.DefaultPageSettings.Margins.Left = 20
            pdoImpAccesorio.DefaultPageSettings.Margins.Right = 20
            pdoImpAccesorio.DefaultPageSettings.Margins.Top = 20
            pdoImpAccesorio.DefaultPageSettings.Margins.Bottom = 20
            pdoImpAccesorio.OriginAtMargins = True ' takes margins into account 

            Dim dlgPrintPreview As New EnhancedPrintPreviewDialog
            dlgPrintPreview.ClientSize = New System.Drawing.Size(600, 600)
            dlgPrintPreview.Document = pdoImpAccesorio ' Previews print
            dlgPrintPreview.ShowDialog()

            'pdoImpPlanilla.Print()
        Else
            formOpcionesdeImpresion.Close()
        End If
    End Sub

    Private Sub pdoImpAccesorio_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdoImpAccesorio.PrintPage
        On Error Resume Next

        Dim format_izquierda As New StringFormat(StringFormatFlags.NoClip)
        format_izquierda.LineAlignment = StringAlignment.Center
        format_izquierda.Alignment = StringAlignment.Near
        Dim format_centrado As New StringFormat(StringFormatFlags.NoClip)
        format_centrado.LineAlignment = StringAlignment.Center
        format_centrado.Alignment = StringAlignment.Center

        Dim FuenteLineas16 As Font = New Drawing.Font("Arial", 16, FontStyle.Regular)
        Dim FuenteLineas14 As Font = New Drawing.Font("Arial", 14, FontStyle.Regular)
        Dim FuenteLineas14N As Font = New Drawing.Font("Arial", 14, FontStyle.Bold)
        Dim FuenteLineas As Font = New Drawing.Font("Arial", 10, FontStyle.Regular)
        Dim FuenteLineasN As Font = New Drawing.Font("Arial", 10, FontStyle.Bold)
        Dim FuenteLineas9 As Font = New Drawing.Font("Arial", 9, FontStyle.Regular)
        Dim FuenteLineas9N As Font = New Drawing.Font("Arial", 9, FontStyle.Bold)
        Dim FuenteLineas8 As Font = New Drawing.Font("Arial", 8, FontStyle.Regular)
        Dim FuenteLineas7 As Font = New Drawing.Font("Arial", 7, FontStyle.Regular)

        Dim nTopGraduaciones, nRowPos As Integer
        Dim nTop As Int16 = e.MarginBounds.Top
        Dim AltoRenglon As Integer = 16


        ' Draw Header
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 750, AltoRenglon * 3)
        e.Graphics.DrawString(lblTitulo.Text, FuenteLineas14N, Brushes.Black, New RectangleF(20, nTop, 380, AltoRenglon * 3), format_centrado)
        e.Graphics.DrawString(txtTitulo.Text, FuenteLineas14, Brushes.Black, New RectangleF(400, nTop, 370, AltoRenglon * 3), format_centrado)
        nTop = nTop + AltoRenglon * 3

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle(20, nTop, 80, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 80, AltoRenglon)
        e.Graphics.DrawString("FECHA", FuenteLineas, Brushes.Black, New RectangleF(20, nTop, 80, AltoRenglon), format_centrado)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle(100, nTop, 80, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 80, AltoRenglon)
        e.Graphics.DrawString("PATRON", FuenteLineas, Brushes.Black, New RectangleF(100, nTop, 80, AltoRenglon), format_centrado)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle(180, nTop, 160, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 180, nTop, 160, AltoRenglon)
        e.Graphics.DrawString("COLOR", FuenteLineas, Brushes.Black, New RectangleF(180, nTop, 160, AltoRenglon), format_centrado)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle(340, nTop, 120, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 340, nTop, 120, AltoRenglon)
        e.Graphics.DrawString("PARTIDA", FuenteLineas, Brushes.Black, New RectangleF(340, nTop, 120, AltoRenglon), format_centrado)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle(460, nTop, 130, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 460, nTop, 130, AltoRenglon)
        e.Graphics.DrawString("M/FINAL", FuenteLineas, Brushes.Black, New RectangleF(460, nTop, 130, AltoRenglon), format_centrado)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle(590, nTop, 90, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 590, nTop, 90, AltoRenglon)
        e.Graphics.DrawString("OP", FuenteLineas, Brushes.Black, New RectangleF(590, nTop, 90, AltoRenglon), format_centrado)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle(680, nTop, 90, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 680, nTop, 90, AltoRenglon)
        e.Graphics.DrawString("ARTÍCULO", FuenteLineas, Brushes.Black, New RectangleF(680, nTop, 90, AltoRenglon), format_centrado)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 80, AltoRenglon)
        If ImprimirFechaHoy Then
            e.Graphics.DrawString(Format(Now, "dd/MM/yyyy"), FuenteLineas, Brushes.Black, New RectangleF(20, nTop, 80, AltoRenglon), format_centrado)
        Else
            e.Graphics.DrawString(Format(dtpFecha.Value, "dd/MM/yyyy"), FuenteLineas, Brushes.Black, New RectangleF(20, nTop, 80, AltoRenglon), format_centrado)
        End If

        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 80, AltoRenglon)
        e.Graphics.DrawString(txtPatron.Text, FuenteLineas, Brushes.Black, New RectangleF(100, nTop, 80, AltoRenglon), format_centrado)

        e.Graphics.DrawRectangle(Pens.Black, 180, nTop, 160, AltoRenglon)
        If CambiarPartidaColorOP Then
            e.Graphics.DrawString(NuevoColor, FuenteLineas, Brushes.Black, New RectangleF(180, nTop, 160, AltoRenglon), format_centrado)
        Else
            e.Graphics.DrawString(txtColor.Text, FuenteLineas, Brushes.Black, New RectangleF(180, nTop, 160, AltoRenglon), format_centrado)
        End If
        e.Graphics.DrawRectangle(Pens.Black, 340, nTop, 120, AltoRenglon)
        If CambiarPartidaColorOP Then
            e.Graphics.DrawString(NuevaPartida, FuenteLineas, Brushes.Black, New RectangleF(340, nTop, 120, AltoRenglon), format_centrado)
        Else
            e.Graphics.DrawString(txtPartida.Text, FuenteLineas, Brushes.Black, New RectangleF(340, nTop, 120, AltoRenglon), format_centrado)
        End If

        e.Graphics.DrawRectangle(Pens.Black, 460, nTop, 130, AltoRenglon)
        e.Graphics.DrawString(txtMedFinal.Text, FuenteLineas, Brushes.Black, New RectangleF(460, nTop, 130, AltoRenglon), format_centrado)

        e.Graphics.DrawRectangle(Pens.Black, 590, nTop, 90, AltoRenglon)
        If CambiarPartidaColorOP Then
            e.Graphics.DrawString(NuevaOp, FuenteLineas, Brushes.Black, New RectangleF(590, nTop, 90, AltoRenglon), format_centrado)
        Else
            e.Graphics.DrawString(txtOp.Text, FuenteLineas, Brushes.Black, New RectangleF(590, nTop, 90, AltoRenglon), format_centrado)
        End If

        e.Graphics.DrawRectangle(Pens.Black, 680, nTop, 90, AltoRenglon)
        e.Graphics.DrawString(txtArticulo.Text, FuenteLineas, Brushes.Black, New RectangleF(680, nTop, 90, AltoRenglon), format_centrado)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 320, AltoRenglon)
        e.Graphics.DrawRectangle(Pens.Black, 340, nTop, 200, AltoRenglon)
        e.Graphics.DrawString("GRADUACIONES", FuenteLineasN, Brushes.Black, New RectangleF(340, nTop, 200, AltoRenglon), format_centrado)
        e.Graphics.DrawRectangle(Pens.Black, 540, nTop, 230, AltoRenglon)
        e.Graphics.DrawString("DETALLE", FuenteLineasN, Brushes.Black, New RectangleF(540, nTop, 230, AltoRenglon), format_centrado)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 320, AltoRenglon * 15)
        e.Graphics.DrawString(txtCuadro1.Text, FuenteLineas16, Brushes.Black, New RectangleF(20, nTop, 320, AltoRenglon * 15), format_centrado)

        nTop = nTop + AltoRenglon * 15

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 320, AltoRenglon)
        e.Graphics.DrawString(txtCuadro2.Text, FuenteLineas9, Brushes.Black, New RectangleF(20, nTop, 100, AltoRenglon), format_centrado)
        e.Graphics.DrawString(txtCuadro3.Text, FuenteLineas9, Brushes.Black, New RectangleF(120, nTop, 100, AltoRenglon), format_centrado)
        e.Graphics.DrawString(txtCuadro4.Text, FuenteLineas9, Brushes.Black, New RectangleF(220, nTop, 100, AltoRenglon), format_centrado)

        nTop = nTop + AltoRenglon
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 320, AltoRenglon)
        e.Graphics.DrawString(txtCuadro5.Text, FuenteLineas9, Brushes.Black, New RectangleF(20, nTop, 320, AltoRenglon), format_centrado)
        nTop = nTop + AltoRenglon
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 320, AltoRenglon)
        e.Graphics.DrawString(txtCuadro6.Text, FuenteLineas9, Brushes.Black, New RectangleF(20, nTop, 320, AltoRenglon), format_centrado)
        nTop = nTop + AltoRenglon
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 320, AltoRenglon)
        e.Graphics.DrawString(txtCuadro7.Text, FuenteLineas9, Brushes.Black, New RectangleF(20, nTop, 320, AltoRenglon), format_centrado)
        nTop = nTop + AltoRenglon
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 320, AltoRenglon)
        e.Graphics.DrawString(txtCuadro8.Text, FuenteLineas9, Brushes.Black, New RectangleF(20, nTop, 320, AltoRenglon), format_centrado)

        ' LAS GRADUACIONES

        nTopGraduaciones = 6 * AltoRenglon + e.MarginBounds.Top

        For nRowPos = 0 To dgvGraduaciones.RowCount - 1

            e.Graphics.DrawRectangle(Pens.Black, 340, nTopGraduaciones, 70, AltoRenglon)
            e.Graphics.DrawString(dgvGraduaciones.Rows(nRowPos).Cells("LETRA").Value, FuenteLineas9, Brushes.Black, New RectangleF(340, nTopGraduaciones, 70, AltoRenglon), format_centrado)
            e.Graphics.DrawRectangle(Pens.Black, 410, nTopGraduaciones, 65, AltoRenglon)
            e.Graphics.DrawString(dgvGraduaciones.Rows(nRowPos).Cells("C1").Value, FuenteLineas9, Brushes.Black, New RectangleF(410, nTopGraduaciones, 65, AltoRenglon), format_centrado)
            e.Graphics.DrawRectangle(Pens.Black, 475, nTopGraduaciones, 65, AltoRenglon)
            e.Graphics.DrawString(dgvGraduaciones.Rows(nRowPos).Cells("C2").Value, FuenteLineas9, Brushes.Black, New RectangleF(475, nTopGraduaciones, 65, AltoRenglon), format_centrado)
            If TipoPlanilla = "STOLL" Then
                e.Graphics.DrawRectangle(Pens.Black, 540, nTopGraduaciones, 230, AltoRenglon)
                e.Graphics.DrawString(dgvGraduaciones.Rows(nRowPos).Cells("DESC1").Value, FuenteLineas9, Brushes.Black, 545, nTopGraduaciones)
            Else
                e.Graphics.DrawRectangle(Pens.Black, 540, nTopGraduaciones, 115, AltoRenglon)
                e.Graphics.DrawString(dgvGraduaciones.Rows(nRowPos).Cells("DESC1").Value, FuenteLineas9, Brushes.Black, 545, nTopGraduaciones)
                e.Graphics.DrawRectangle(Pens.Black, 655, nTopGraduaciones, 115, AltoRenglon)
                e.Graphics.DrawString(dgvGraduaciones.Rows(nRowPos).Cells("DESC2").Value, FuenteLineas9, Brushes.Black, 660, nTopGraduaciones)

            End If
            nTopGraduaciones = nTopGraduaciones + AltoRenglon

        Next



        ' LOS PICOS

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 75, AltoRenglon)
        e.Graphics.DrawString("PICOS", FuenteLineas9, Brushes.Black, New RectangleF(20, nTop, 75, AltoRenglon), format_centrado)
        e.Graphics.DrawRectangle(Pens.Black, 95, nTop, 82, AltoRenglon)
        e.Graphics.DrawString("1", FuenteLineas9, Brushes.Black, New RectangleF(95, nTop, 82, AltoRenglon), format_centrado)
        e.Graphics.DrawRectangle(Pens.Black, 177, nTop, 83, AltoRenglon)
        e.Graphics.DrawString("2", FuenteLineas9, Brushes.Black, New RectangleF(177, nTop, 83, AltoRenglon), format_centrado)
        e.Graphics.DrawRectangle(Pens.Black, 260, nTop, 85, AltoRenglon)
        e.Graphics.DrawString("3", FuenteLineas9, Brushes.Black, New RectangleF(260, nTop, 85, AltoRenglon), format_centrado)
        e.Graphics.DrawRectangle(Pens.Black, 345, nTop, 85, AltoRenglon)
        e.Graphics.DrawString("4", FuenteLineas9, Brushes.Black, New RectangleF(345, nTop, 85, AltoRenglon), format_centrado)
        e.Graphics.DrawRectangle(Pens.Black, 430, nTop, 85, AltoRenglon)
        e.Graphics.DrawString("5", FuenteLineas9, Brushes.Black, New RectangleF(430, nTop, 85, AltoRenglon), format_centrado)
        e.Graphics.DrawRectangle(Pens.Black, 515, nTop, 85, AltoRenglon)
        e.Graphics.DrawString("6", FuenteLineas9, Brushes.Black, New RectangleF(515, nTop, 85, AltoRenglon), format_centrado)
        e.Graphics.DrawRectangle(Pens.Black, 600, nTop, 85, AltoRenglon)
        e.Graphics.DrawString("7", FuenteLineas9, Brushes.Black, New RectangleF(600, nTop, 85, AltoRenglon), format_centrado)
        e.Graphics.DrawRectangle(Pens.Black, 685, nTop, 85, AltoRenglon)
        e.Graphics.DrawString("8", FuenteLineas9, Brushes.Black, New RectangleF(685, nTop, 85, AltoRenglon), format_centrado)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 75, AltoRenglon * 2)
        e.Graphics.DrawString("DERECHA", FuenteLineas9, Brushes.Black, New RectangleF(20, nTop, 75, AltoRenglon * 2), format_centrado)

        e.Graphics.DrawRectangle(Pens.Black, 95, nTop, 82, AltoRenglon * 2)
        e.Graphics.DrawString(dgvPicos.Rows(0).Cells("PICO1").Value, FuenteLineas9, Brushes.Black, New RectangleF(95, nTop, 82, AltoRenglon), format_centrado)
        e.Graphics.DrawRectangle(Pens.Black, 177, nTop, 83, AltoRenglon * 2)
        e.Graphics.DrawString(dgvPicos.Rows(0).Cells("PICO2").Value, FuenteLineas9, Brushes.Black, New RectangleF(177, nTop, 83, AltoRenglon), format_centrado)
        e.Graphics.DrawRectangle(Pens.Black, 260, nTop, 85, AltoRenglon * 2)
        e.Graphics.DrawString(dgvPicos.Rows(0).Cells("PICO3").Value, FuenteLineas9, Brushes.Black, New RectangleF(260, nTop, 85, AltoRenglon), format_centrado)
        e.Graphics.DrawRectangle(Pens.Black, 345, nTop, 85, AltoRenglon * 2)
        e.Graphics.DrawString(dgvPicos.Rows(0).Cells("PICO4").Value, FuenteLineas9, Brushes.Black, New RectangleF(345, nTop, 85, AltoRenglon), format_centrado)
        e.Graphics.DrawRectangle(Pens.Black, 430, nTop, 85, AltoRenglon * 2)
        e.Graphics.DrawString(dgvPicos.Rows(0).Cells("PICO5").Value, FuenteLineas9, Brushes.Black, New RectangleF(430, nTop, 85, AltoRenglon), format_centrado)
        e.Graphics.DrawRectangle(Pens.Black, 515, nTop, 85, AltoRenglon * 2)
        e.Graphics.DrawString(dgvPicos.Rows(0).Cells("PICO6").Value, FuenteLineas9, Brushes.Black, New RectangleF(515, nTop, 85, AltoRenglon), format_centrado)
        e.Graphics.DrawRectangle(Pens.Black, 600, nTop, 85, AltoRenglon * 2)
        e.Graphics.DrawString(dgvPicos.Rows(0).Cells("PICO7").Value, FuenteLineas9, Brushes.Black, New RectangleF(600, nTop, 85, AltoRenglon), format_centrado)
        e.Graphics.DrawRectangle(Pens.Black, 685, nTop, 85, AltoRenglon * 2)
        e.Graphics.DrawString(dgvPicos.Rows(0).Cells("PICO8").Value, FuenteLineas9, Brushes.Black, New RectangleF(685, nTop, 85, AltoRenglon), format_centrado)
        nTop = nTop + AltoRenglon
        e.Graphics.DrawString(dgvPicos.Rows(1).Cells("PICO1").Value, FuenteLineas9, Brushes.Black, New RectangleF(95, nTop, 82, AltoRenglon), format_centrado)
        e.Graphics.DrawString(dgvPicos.Rows(1).Cells("PICO2").Value, FuenteLineas9, Brushes.Black, New RectangleF(177, nTop, 83, AltoRenglon), format_centrado)
        e.Graphics.DrawString(dgvPicos.Rows(1).Cells("PICO3").Value, FuenteLineas9, Brushes.Black, New RectangleF(260, nTop, 85, AltoRenglon), format_centrado)
        e.Graphics.DrawString(dgvPicos.Rows(1).Cells("PICO4").Value, FuenteLineas9, Brushes.Black, New RectangleF(345, nTop, 85, AltoRenglon), format_centrado)
        e.Graphics.DrawString(dgvPicos.Rows(1).Cells("PICO5").Value, FuenteLineas9, Brushes.Black, New RectangleF(430, nTop, 85, AltoRenglon), format_centrado)
        e.Graphics.DrawString(dgvPicos.Rows(1).Cells("PICO6").Value, FuenteLineas9, Brushes.Black, New RectangleF(515, nTop, 85, AltoRenglon), format_centrado)
        e.Graphics.DrawString(dgvPicos.Rows(1).Cells("PICO7").Value, FuenteLineas9, Brushes.Black, New RectangleF(600, nTop, 85, AltoRenglon), format_centrado)
        e.Graphics.DrawString(dgvPicos.Rows(1).Cells("PICO8").Value, FuenteLineas9, Brushes.Black, New RectangleF(685, nTop, 85, AltoRenglon), format_centrado)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 75, AltoRenglon * 2)
        e.Graphics.DrawString("IZQUIERDA", FuenteLineas9, Brushes.Black, New RectangleF(20, nTop, 75, AltoRenglon * 2), format_centrado)

        e.Graphics.DrawRectangle(Pens.Black, 95, nTop, 82, AltoRenglon * 2)
        e.Graphics.DrawString(dgvPicos.Rows(2).Cells("PICO1").Value, FuenteLineas9, Brushes.Black, New RectangleF(95, nTop, 82, AltoRenglon), format_centrado)
        e.Graphics.DrawRectangle(Pens.Black, 177, nTop, 83, AltoRenglon * 2)
        e.Graphics.DrawString(dgvPicos.Rows(2).Cells("PICO2").Value, FuenteLineas9, Brushes.Black, New RectangleF(177, nTop, 83, AltoRenglon), format_centrado)
        e.Graphics.DrawRectangle(Pens.Black, 260, nTop, 85, AltoRenglon * 2)
        e.Graphics.DrawString(dgvPicos.Rows(2).Cells("PICO3").Value, FuenteLineas9, Brushes.Black, New RectangleF(260, nTop, 85, AltoRenglon), format_centrado)
        e.Graphics.DrawRectangle(Pens.Black, 345, nTop, 85, AltoRenglon * 2)
        e.Graphics.DrawString(dgvPicos.Rows(2).Cells("PICO4").Value, FuenteLineas9, Brushes.Black, New RectangleF(345, nTop, 85, AltoRenglon), format_centrado)
        e.Graphics.DrawRectangle(Pens.Black, 430, nTop, 85, AltoRenglon * 2)
        e.Graphics.DrawString(dgvPicos.Rows(2).Cells("PICO5").Value, FuenteLineas9, Brushes.Black, New RectangleF(430, nTop, 85, AltoRenglon), format_centrado)
        e.Graphics.DrawRectangle(Pens.Black, 515, nTop, 85, AltoRenglon * 2)
        e.Graphics.DrawString(dgvPicos.Rows(2).Cells("PICO6").Value, FuenteLineas9, Brushes.Black, New RectangleF(515, nTop, 85, AltoRenglon), format_centrado)
        e.Graphics.DrawRectangle(Pens.Black, 600, nTop, 85, AltoRenglon * 2)
        e.Graphics.DrawString(dgvPicos.Rows(2).Cells("PICO7").Value, FuenteLineas9, Brushes.Black, New RectangleF(600, nTop, 85, AltoRenglon), format_centrado)
        e.Graphics.DrawRectangle(Pens.Black, 685, nTop, 85, AltoRenglon * 2)
        e.Graphics.DrawString(dgvPicos.Rows(2).Cells("PICO8").Value, FuenteLineas9, Brushes.Black, New RectangleF(685, nTop, 85, AltoRenglon), format_centrado)
        nTop = nTop + AltoRenglon
        e.Graphics.DrawString(dgvPicos.Rows(3).Cells("PICO1").Value, FuenteLineas9, Brushes.Black, New RectangleF(95, nTop, 82, AltoRenglon), format_centrado)
        e.Graphics.DrawString(dgvPicos.Rows(3).Cells("PICO2").Value, FuenteLineas9, Brushes.Black, New RectangleF(177, nTop, 83, AltoRenglon), format_centrado)
        e.Graphics.DrawString(dgvPicos.Rows(3).Cells("PICO3").Value, FuenteLineas9, Brushes.Black, New RectangleF(260, nTop, 85, AltoRenglon), format_centrado)
        e.Graphics.DrawString(dgvPicos.Rows(3).Cells("PICO4").Value, FuenteLineas9, Brushes.Black, New RectangleF(345, nTop, 85, AltoRenglon), format_centrado)
        e.Graphics.DrawString(dgvPicos.Rows(3).Cells("PICO5").Value, FuenteLineas9, Brushes.Black, New RectangleF(430, nTop, 85, AltoRenglon), format_centrado)
        e.Graphics.DrawString(dgvPicos.Rows(3).Cells("PICO6").Value, FuenteLineas9, Brushes.Black, New RectangleF(515, nTop, 85, AltoRenglon), format_centrado)
        e.Graphics.DrawString(dgvPicos.Rows(3).Cells("PICO7").Value, FuenteLineas9, Brushes.Black, New RectangleF(600, nTop, 85, AltoRenglon), format_centrado)
        e.Graphics.DrawString(dgvPicos.Rows(3).Cells("PICO8").Value, FuenteLineas9, Brushes.Black, New RectangleF(685, nTop, 85, AltoRenglon), format_centrado)


        '######################################################################################################################################################
        '#########################################################    SEGUNDA PARTE DE LA HOJA      ###########################################################
        '######################################################################################################################################################

        nTop = nTop + AltoRenglon * 2

        Dim dashValues As Single() = {3, 1, 3, 1}
        Dim blackPen As New Pen(Color.Black, 3)
        Dim blackPen1 As New Pen(Color.Black, 2)
        blackPen.DashPattern = dashValues
        e.Graphics.DrawLine(blackPen, New Point(20, nTop), New Point(770, nTop))

        nTop = nTop + AltoRenglon

        ' Draw Header
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 750, AltoRenglon * 3)
        e.Graphics.DrawString(lblTitulo.Text, FuenteLineas14N, Brushes.Black, New RectangleF(20, nTop, 380, AltoRenglon * 3), format_centrado)
        e.Graphics.DrawString(txtTitulo.Text, FuenteLineas14, Brushes.Black, New RectangleF(400, nTop, 370, AltoRenglon * 3), format_centrado)
        nTop = nTop + AltoRenglon * 3

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle(20, nTop, 80, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 80, AltoRenglon)
        e.Graphics.DrawString("FECHA", FuenteLineas, Brushes.Black, New RectangleF(20, nTop, 80, AltoRenglon), format_centrado)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle(100, nTop, 80, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 80, AltoRenglon)
        e.Graphics.DrawString("PATRON", FuenteLineas, Brushes.Black, New RectangleF(100, nTop, 80, AltoRenglon), format_centrado)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle(180, nTop, 160, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 180, nTop, 160, AltoRenglon)
        e.Graphics.DrawString("COLOR", FuenteLineas, Brushes.Black, New RectangleF(180, nTop, 160, AltoRenglon), format_centrado)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle(340, nTop, 120, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 340, nTop, 120, AltoRenglon)
        e.Graphics.DrawString("PARTIDA", FuenteLineas, Brushes.Black, New RectangleF(340, nTop, 120, AltoRenglon), format_centrado)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle(460, nTop, 130, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 460, nTop, 130, AltoRenglon)
        e.Graphics.DrawString("M/FINAL", FuenteLineas, Brushes.Black, New RectangleF(460, nTop, 130, AltoRenglon), format_centrado)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle(590, nTop, 90, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 590, nTop, 90, AltoRenglon)
        e.Graphics.DrawString("OP", FuenteLineas, Brushes.Black, New RectangleF(590, nTop, 90, AltoRenglon), format_centrado)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle(680, nTop, 90, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 680, nTop, 90, AltoRenglon)
        e.Graphics.DrawString("ARTÍCULO", FuenteLineas, Brushes.Black, New RectangleF(680, nTop, 90, AltoRenglon), format_centrado)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 80, AltoRenglon)
        e.Graphics.DrawString(Format(dtpFecha.Value, "dd/MM/yyyy"), FuenteLineas, Brushes.Black, New RectangleF(20, nTop, 80, AltoRenglon), format_centrado)

        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 80, AltoRenglon)
        e.Graphics.DrawString(txtPatron.Text, FuenteLineas, Brushes.Black, New RectangleF(100, nTop, 80, AltoRenglon), format_centrado)

        e.Graphics.DrawRectangle(Pens.Black, 180, nTop, 160, AltoRenglon)
        If CambiarPartidaColorOP Then
            e.Graphics.DrawString(NuevoColor, FuenteLineas, Brushes.Black, New RectangleF(180, nTop, 160, AltoRenglon), format_centrado)
        Else
            e.Graphics.DrawString(txtColor.Text, FuenteLineas, Brushes.Black, New RectangleF(180, nTop, 160, AltoRenglon), format_centrado)
        End If

        e.Graphics.DrawRectangle(Pens.Black, 340, nTop, 120, AltoRenglon)
        If CambiarPartidaColorOP Then
            e.Graphics.DrawString(NuevaPartida, FuenteLineas, Brushes.Black, New RectangleF(340, nTop, 120, AltoRenglon), format_centrado)
        Else
            e.Graphics.DrawString(txtPartida.Text, FuenteLineas, Brushes.Black, New RectangleF(340, nTop, 120, AltoRenglon), format_centrado)
        End If

        e.Graphics.DrawRectangle(Pens.Black, 460, nTop, 130, AltoRenglon)
        e.Graphics.DrawString(txtMedFinal.Text, FuenteLineas, Brushes.Black, New RectangleF(460, nTop, 130, AltoRenglon), format_centrado)

        e.Graphics.DrawRectangle(Pens.Black, 590, nTop, 90, AltoRenglon)
        If CambiarPartidaColorOP Then
            e.Graphics.DrawString(NuevaOp, FuenteLineas, Brushes.Black, New RectangleF(590, nTop, 90, AltoRenglon), format_centrado)
        Else
            e.Graphics.DrawString(txtOp.Text, FuenteLineas, Brushes.Black, New RectangleF(590, nTop, 90, AltoRenglon), format_centrado)
        End If

        e.Graphics.DrawRectangle(Pens.Black, 680, nTop, 90, AltoRenglon)
        e.Graphics.DrawString(txtArticulo.Text, FuenteLineas, Brushes.Black, New RectangleF(680, nTop, 90, AltoRenglon), format_centrado)

        'el cuadro grande

        nTop = nTop + AltoRenglon
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 320, AltoRenglon)
        nTop = nTop + AltoRenglon
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 320, AltoRenglon * 12)
        e.Graphics.DrawString(txtCuadro1.Text, FuenteLineas16, Brushes.Black, New RectangleF(20, nTop, 320, AltoRenglon * 12), format_centrado)

        nTop = nTop + AltoRenglon * 12

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 320, AltoRenglon)
        e.Graphics.DrawString("CONDICIÓN DE TEJIDO=", FuenteLineas9, Brushes.Black, New RectangleF(20, nTop, 320, AltoRenglon), format_centrado)

        'el detalle del costado

        'vuelvo ntop para arriba asi empieza al costado del cuadro grande

        nTop = nTop - AltoRenglon * 13

        e.Graphics.DrawRectangle(Pens.Black, 340, nTop, 430, AltoRenglon * 14)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawString("MEDIDAS DE COSTURA:", FuenteLineas9, Brushes.Black, New RectangleF(350, nTop, 420, AltoRenglon), format_izquierda)
        e.Graphics.DrawLine(blackPen1, 590, nTop + AltoRenglon, 770, nTop + AltoRenglon)
        e.Graphics.DrawLine(blackPen1, 680, nTop, 680, nTop + AltoRenglon)

        nTop = nTop + AltoRenglon * 2

        e.Graphics.DrawString("OPERARIA:", FuenteLineas9, Brushes.Black, New RectangleF(350, nTop, 420, AltoRenglon), format_izquierda)
        e.Graphics.DrawLine(blackPen1, 590, nTop + AltoRenglon, 770, nTop + AltoRenglon)
        e.Graphics.DrawLine(blackPen1, 680, nTop, 680, nTop + AltoRenglon)

        nTop = nTop + AltoRenglon * 2

        e.Graphics.DrawString("ENCARGADA:", FuenteLineas9, Brushes.Black, New RectangleF(350, nTop, 420, AltoRenglon), format_izquierda)
        e.Graphics.DrawLine(blackPen1, 590, nTop + AltoRenglon, 770, nTop + AltoRenglon)
        e.Graphics.DrawLine(blackPen1, 680, nTop, 680, nTop + AltoRenglon)

        nTop = nTop + AltoRenglon * 2

        e.Graphics.DrawString("OBSERVACIONES:", FuenteLineas9, Brushes.Black, New RectangleF(350, nTop, 420, AltoRenglon), format_izquierda)
        e.Graphics.DrawLine(blackPen1, 590, nTop + AltoRenglon, 770, nTop + AltoRenglon)
        e.Graphics.DrawLine(blackPen1, 680, nTop, 680, nTop + AltoRenglon)

        nTop = nTop + AltoRenglon * 2

        e.Graphics.DrawString("APROBADO:", FuenteLineas9, Brushes.Black, New RectangleF(350, nTop, 420, AltoRenglon), format_izquierda)
        e.Graphics.DrawLine(blackPen1, 590, nTop + AltoRenglon, 770, nTop + AltoRenglon)

        nTop = nTop + AltoRenglon * 5

        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 590, AltoRenglon)
        e.Graphics.DrawString("MUESTRA EN PRODUCCION", FuenteLineas, Brushes.Black, New RectangleF(100, nTop, 590, AltoRenglon), format_centrado)

        nTop = nTop + AltoRenglon * 2

        e.Graphics.DrawLine(blackPen, New Point(20, nTop), New Point(770, nTop))


    End Sub

    Private Sub cmdCopiarEnOtra_Click(sender As Object, e As EventArgs) Handles cmdCopiarEnOtra.Click
        IdAccesorioCopiado = ID.ToString
        IdPlanillaCopiarAccesorio = ""
        Dim formArtProdElegirPlanilla As New frmArtProdElegirPlanilla(LegajoLogueado, IdPlanilla)
        If FormAbierto(formArtProdElegirPlanilla) Then Exit Sub
        formArtProdElegirPlanilla.ShowDialog(Me)
        If IdPlanillaCopiarAccesorio = "" Then
            MensajeCritico("No se ha seleccionado una planilla para copiar el accesorio." + Chr(10) + "No se realiza la copia, vuelva a intentar.")
            Exit Sub
        Else
            RealizarCopiaDelAccesorio()
        End If

    End Sub

    Private Sub RealizarCopiaDelAccesorio()
        Dim NuevoId As String = ""
        Dim TipoPlanillaCopiar As String
        Dim CodArtParaActualizarElNuevoAcc As String = ""
        Dim ColorParaActualizarElNuevoAcc As String = ""
        Dim PartidaParaActualizarElNuevoAcc As String = ""
        'primero que nada veo que tipo de planilla es a la que le quiere copiar el accesorio
        TipoPlanillaCopiar = ArtProdDatosDePlanilla(IdPlanillaCopiarAccesorio, CodArtParaActualizarElNuevoAcc, ColorParaActualizarElNuevoAcc)

        'primero hago la copia del nuevo accesorio
        sStr = "insert into PrendasArtProdPlanillasAccesorios "
        sStr = sStr + "select '" + IdPlanillaCopiarAccesorio + "',DescAccesorio,Fecha ,Articulo ,OP , Patron ,Color ,Partida,MedidaFinal,Cuadro1,Cuadro2,Cuadro3,Cuadro4,Cuadro5,Cuadro6,"
        sStr = sStr + "Cuadro7, Cuadro8, Eliminado "
        sStr = sStr + "from PrendasArtProdPlanillasAccesorios where Id=" + IdAccesorioCopiado
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        'una vez que inserto traigo el id asi inserto las demas cosas
        sStr = "SELECT max(id) as Id FROM PrendasArtProdPlanillasAccesorios WHERE IdPlanilla=" + IdPlanillaCopiarAccesorio
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                NuevoId = Reader.Item("Id").ToString
            End If
        End If

        'primero que nada le actualizo los datos del accesorio a los que tiene la planilla en la que quiero copiar, si no queda con los datos de la que copié
        sStr = "update PrendasArtProdPlanillasAccesorios "
        sStr = sStr + "set Articulo= '" + CodArtParaActualizarElNuevoAcc + "',Color ='" + ColorParaActualizarElNuevoAcc + "',Partida ='" + PartidaParaActualizarElNuevoAcc + "' "
        sStr = sStr + "where Id=" + NuevoId
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        'las graduaciones
        For i = 0 To 19
            If TipoPlanillaCopiar = "STOLL" Then
                If Not IsNothing(dgvGraduaciones.Rows(i).Cells("LETRA").Value) Or Not IsNothing(dgvGraduaciones.Rows(i).Cells("C1").Value) _
                    Or Not IsNothing(dgvGraduaciones.Rows(i).Cells("C2").Value) Or Not IsNothing(dgvGraduaciones.Rows(i).Cells("DESC1").Value) Then
                    sStr = "INSERT INTO PrendasArtProdPlanillasAcces_Graduaciones (IdAccesorio,Letra,Cuadro1,Cuadro2,Descripcion1,Descripcion2) VALUES ("
                    sStr = sStr + NuevoId.ToString + ", '" + dgvGraduaciones.Rows(i).Cells("LETRA").Value + "', '" + dgvGraduaciones.Rows(i).Cells("C1").Value + "', '"
                    sStr = sStr + dgvGraduaciones.Rows(i).Cells("C2").Value + "', '" + dgvGraduaciones.Rows(i).Cells("DESC1").Value + "', NULL)"
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            Else
                If dgvGraduaciones.Rows(i).Cells("LETRA").Value.ToString <> "" Or dgvGraduaciones.Rows(i).Cells("C1").Value.ToString <> "" _
                    Or dgvGraduaciones.Rows(i).Cells("C2").Value.ToString <> "" Or dgvGraduaciones.Rows(i).Cells("DESC1").Value.ToString <> "" _
                    Or dgvGraduaciones.Rows(i).Cells("DESC2").Value.ToString <> "" Then
                    sStr = "INSERT INTO PrendasArtProdPlanillasAcces_Graduaciones (IdAccesorio,Letra,Cuadro1,Cuadro2,Descripcion1,Descripcion2) VALUES ("
                    sStr = sStr + NuevoId.ToString + ", '" + dgvGraduaciones.Rows(i).Cells("LETRA").Value + "', '" + dgvGraduaciones.Rows(i).Cells("C1").Value + "', '"
                    sStr = sStr + dgvGraduaciones.Rows(i).Cells("C2").Value + "', '" + dgvGraduaciones.Rows(i).Cells("DESC1").Value + "', '"
                    sStr = sStr + dgvGraduaciones.Rows(i).Cells("DESC2").Value + "')"
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                End If
            End If
        Next

        'los picos
        For i = 0 To 7
            If Not IsNothing(dgvPicos.Rows(0).Cells(i).Value) Or Not IsNothing(dgvPicos.Rows(1).Cells(i).Value) _
                    Or Not IsNothing(dgvPicos.Rows(2).Cells(i).Value) Or Not IsNothing(dgvPicos.Rows(3).Cells(i).Value) Then
                sStr = "INSERT INTO PrendasArtProdPlanillasAcces_Picos (IdAccesorio,Pico,Derecha1,Derecha2,Izquierda1,Izquierda2) VALUES ("
                sStr = sStr + NuevoId.ToString + ", " + (i + 1).ToString + ",'" + dgvPicos.Rows(0).Cells(i).Value + "', '" + dgvPicos.Rows(1).Cells(i).Value + "', '"
                sStr = sStr + dgvPicos.Rows(2).Cells(i).Value + "', '" + dgvPicos.Rows(3).Cells(i).Value + "')"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
            End If
        Next

        RegistroEnHistorial("A", NuevoId.ToString, "AltaAccesorio", LegajoLogueado)

        MensajeInfo("Accesorio Copiado correctamente.")

    End Sub

End Class