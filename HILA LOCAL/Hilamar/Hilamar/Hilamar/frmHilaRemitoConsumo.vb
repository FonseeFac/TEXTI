Imports System.Data.SqlClient

Public Class frmHilaRemitoConsumo
    Dim LegajoLogueado As String 'legajo de quien va a trabajar
    Dim TipoUsuario As String ' Tipo de usuario que va a trabajar, lo voy a usar para saber que le habilito a usar y que no

    Sub New(ByVal parametro1 As String, ByVal parametro2 As String)

        InitializeComponent() 'es necesario que lleve esta linea

        LegajoLogueado = parametro1
        TipoUsuario = parametro2

    End Sub

    Private Sub frmHilaRemitoConsumo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar()
    End Sub

    Public Sub Cargar()
        dtpFecha.Value = Now
        dtpFecha.Select()
    End Sub

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Guardar()
    End Sub

    Private Sub Guardar()
        On Error GoTo ErrGuardar
        Dim Reader As SqlDataReader
        Dim Command As New SqlCommand
        Dim sStr As String

        Dim UltimoRemitoConsumo As String = ""

        If Not Validar() Then Exit Sub

        'el encabezado
        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        'primero agarro el numero de remito automatico de entrada
        sStr = "select isnull(MAX(cast(nroremito as float)),0)+1 as UltimoRemito from HilamarHiladoStockEncMov where Isnull(Eliminado,0)=0 AND TipoMov ='C'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                UltimoRemitoConsumo = Reader.Item("UltimoRemito").ToString
            End If
        End If

        If UltimoRemitoConsumo = "" Then
            MensajeAtencion("No se pudo obtener el último nro de Remito de Consumos. No se grabará el Movimiento. Verifique.")
            Exit Sub
        End If

        sStr = "INSERT INTO HilamarHiladoStockEncMov "
        sStr = sStr + "(NroRemito, Fecha, TipoMov, AuditAlta, Observacion) "
        sStr = sStr + "VALUES "
        sStr = sStr + "('" + UltimoRemitoConsumo + "','" + Format(dtpFecha.Value, "yyyyMMdd") + "','C',getdate(),'" + txtObservacion.Text + "')"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()
        'el detalle
        sStr = "INSERT INTO HilamarHiladoStockDetMov "
        sStr = sStr + "(TipoMov, NroRemito, Partida, Conos, Kilos, Observaciones) "
        sStr = sStr + "VALUES "
        sStr = sStr + "('C', '" + UltimoRemitoConsumo + "','" + txtPartida.Text + "'," + "NULL" + "," + txtKilos.Text + ",'')"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        'si pide que convierta los kilos consumidos en hilado R además debo entonces ingresar el movimiento de ingreso del nuevo hilado
        If rbConsumoConvertirR.Checked Then

            Dim UltimoRemitoIngreso As String = ""

            'el encabezado
            'primero agarro el numero de remito automatico de entrada
            sStr = "select isnull(MAX(cast(nroremito as float)),0)+1 as UltimoRemito from HilamarHiladoStockEncMov where Isnull(Eliminado,0)=0 AND TipoMov ='I'"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read() Then
                    UltimoRemitoIngreso = Reader.Item("UltimoRemito").ToString
                End If
            End If

            If UltimoRemitoIngreso = "" Then
                MensajeAtencion("No se pudo obtener el último nro de Remito de Ingreso. No se grabará el Movimiento de Ingreso. Verifique.")
            Else
                sStr = "INSERT INTO HilamarHiladoStockEncMov "
                sStr = sStr + "(NroRemito, Fecha, TipoMov, AuditAlta, Observacion) "
                sStr = sStr + "VALUES "
                sStr = sStr + "('" + UltimoRemitoIngreso + "','" + Format(dtpFecha.Value, "yyyyMMdd") + "','I',getdate(),'" + "Por Consumo " + UltimoRemitoConsumo + "')"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
                'el detalle
                sStr = "INSERT INTO HilamarHiladoStockDetMov "
                sStr = sStr + "(TipoMov, NroRemito, Partida, Conos, Kilos, Observaciones) "
                sStr = sStr + "VALUES "
                sStr = sStr + "('I', '" + UltimoRemitoIngreso + "','" + txtPartida.Text.Replace("H", "R") + "'," + "NULL" + "," + txtKilos.Text + ",'')"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()

                End If
                'si pide que convierta los kilos consumidos en hilado G además debo entonces ingresar el movimiento de ingreso del nuevo hilado
        ElseIf rbConsumoConvertirG.Checked Then
            Dim UltimoRemitoIngreso As String = ""

            'Controlo que haya Kilos Disponibles en la partida de origen
            Dim kilosDisponibles As Integer
            Dim CommandInt As SqlCommand
            Dim ReaderInt As SqlDataReader
            Dim sStrInt As String
            sStrInt = "SELECT Totales.Partida AS Partida,ISNULL(CONVERT(INT,Totales.KilosDetalle + Totales.KilosInicial),0) AS Kilos FROM (SELECT S.Partida,S.FechaStockDesde,S.FechaStockHasta,ISNULL(SUM(Detalle.KilosDet),0) AS KilosDetalle,S.Kilos AS KilosInicial FROM HilamarHiladoStock S "
            sStrInt += "LEFT JOIN (SELECT D.Partida,(D.Kilos * (CASE D.TipoMov WHEN 'C' THEN -1 WHEN 'I' THEN 1 WHEN 'DI' THEN 1 WHEN 'E' THEN -1 END)) AS KilosDet,E.Fecha AS Fecha FROM HilamarHiladoStockEncMov E INNER JOIN HilamarHiladoStockDetMov D ON E.TipoMov = D.TipoMov AND D.NroRemito = E.NroRemito "
            sStrInt += "WHERE ISNULL(D.Eliminado,0)=0 AND ISNULL(E.Eliminado,0)=0) AS Detalle ON S.Partida = Detalle.Partida WHERE ISNULL(Detalle.Fecha,GETDATE()) > ISNULL(FechaStockHasta,'19000101') AND ISNULL(Detalle.Fecha,GETDATE()) >= ISNULL(FechaStockDesde,'19000101') AND ISNULL(S.Eliminado,0)=0  "
            sStrInt += "GROUP BY S.Partida,S.Kilos,FechaStockDesde,FechaStockHasta) AS Totales WHERE (TOTALES.KilosDetalle+Totales.KilosInicial) > 0 AND Partida = '" + txtPartida.Text + "'  GROUP BY Partida,Totales.KilosDetalle,Totales.KilosInicial"

            CommandInt = New SqlCommand(sStrInt, cConexionApp.SQLConn)
            ReaderInt = CommandInt.ExecuteReader

            If ReaderInt.HasRows Then
                ReaderInt.Read()
                If CInt(Reader.Item("Kilos")) < CInt(txtKilos.Text) Then
                    MsgBox("La partida solo tiene " + Reader.Item("Kilos").ToString + " disponibles. No se puede llevar a cabo la operacion.")
                    Exit Sub
                End If
            Else
                MsgBox("La partida no tiene Kilos disponibles")
                Exit Sub
            End If



            'el encabezado
            'primero agarro el numero de remito automatico de entrada
            sStr = "select isnull(MAX(cast(nroremito as float)),0)+1 as UltimoRemito from HilamarHiladoStockEncMov where Isnull(Eliminado,0)=0 AND TipoMov ='I'"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read() Then
                    UltimoRemitoIngreso = Reader.Item("UltimoRemito").ToString
                End If
            End If

            If UltimoRemitoIngreso = "" Then
                MensajeAtencion("No se pudo obtener el último nro de Remito de Ingreso. No se grabará el Movimiento de Ingreso. Verifique.")
                Exit Sub

            Else
                If txtPartida.Text.Contains("/C") Then
                    Dim nroPartidaCommoditieReservado As String = txtPartida.Text.Replace("H", "G")

                    'Controlo si la partida existe
                    sStr = "SELECT COUNT(*) AS Cantidad FROM HilamarHiladoStock WHERE Partida = '" + nroPartidaCommoditieReservado + "' AND ISNULL(Eliminado,0)=0 AND FechaStockHasta is NULL"
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Reader = Command.ExecuteReader
                    Reader.Read()

                    If CInt(Reader.Item("Cantidad")) > 0 Then
                        'Agrego la encabezado de ingreso
                        sStr = "INSERT INTO HilamarHiladoStockEncMov(NroRemito,Fecha,TipoMov,AuditAlta,Observacion,Eliminado) VALUES('" + UltimoRemitoIngreso.ToString + "','" + dtpFecha.Value.ToString + "','I',GETDATE(),'Ingreso Commoditie Reservado',0)"
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                        'Agrego detalle de ingreso
                        sStr = "INSERT INTO HilamarHiladoStockDetMov(TipoMov,NroRemito,Partida,Kilos,Observaciones,Eliminado) VALUES('I','" + UltimoRemitoIngreso.ToString + "','" + nroPartidaCommoditieReservado.ToString + "'," + txtKilos.Text + ",'Ingreso Commoditie Reservado',0)"
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()

                    Else
                        'Doy de Alta la partida inexistente
                        sStr = "INSERT INTO HilamarHiladoStock(Partida,CodTipoHilado,Kilos,Color,Eliminado,Auditoria,CodColor,PCardado,FechaStockDesde,ColorCono,PartidaOrigen,EsDiscontinuada,Observacion,FechaAltaPartida,Condicion) SELECT '" + nroPartidaCommoditieReservado.ToString + "',"
                        sStr += "CodTipoHilado,0,Color,0,'ALTA |" + Format(Now, "dd/MM/yyyy HH:mm:ss") + "',CodColor,PCardado,'" + dtpFecha.Value.ToString + "',ColorCono,Partida,EsDiscontinuada,'Commoditie Reservado',GETDATE(),2 FROM HilamarHiladoStock WHERE Partida = '" + txtPartida.Text + "' AND ISNULL(Eliminado,0)=0 AND FechaStockHasta IS NULL"
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()

                        'Agrego la encabezado de ingreso
                        sStr = "INSERT INTO HilamarHiladoStockEncMov(NroRemito,Fecha,TipoMov,AuditAlta,Observacion,Eliminado) VALUES('" + UltimoRemitoIngreso.ToString + "','" + dtpFecha.Value.ToString + "','I',GETDATE(),'Ingreso Commoditie Reservado',0)"
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()
                        'Agrego detalle de ingreso
                        sStr = "INSERT INTO HilamarHiladoStockDetMov(TipoMov,NroRemito,Partida,Kilos,Observaciones,Eliminado) VALUES('I','" + UltimoRemitoIngreso.ToString + "','" + nroPartidaCommoditieReservado.ToString + "'," + txtKilos.Text + ",'Ingreso Commoditie Reservado',0)"
                        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                        Command.ExecuteNonQuery()

                    End If
                Else
                    'primero que nada antes de dar de alta el ingreso debo controlar si ya existe la partida con la G, si no la doy de alta automaticamente
                    sStr = "SELECT count(*) as Cantidad FROM HilamarHiladoStock WHERE Partida = '" + txtPartida.Text.Replace("H", "G") + "' and Eliminado=0 "
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Reader = Command.ExecuteReader()
                    If Reader.HasRows Then
                        If Reader.Read() Then
                            If Reader.Item("Cantidad") <= 0 Then
                                sStr = "INSERT INTO HilamarHiladoStock (Partida,CodTipoHilado,Kilos,Color,Eliminado,Auditoria,CodColor,PCardado,FechaStockDesde,ColorCono,PartidaOrigen,FechaStockHasta,EsDiscontinuada,Observacion)"
                                sStr = sStr + " select '" + txtPartida.Text.Replace("H", "G") + "',CodTipoHilado,Kilos,Color,Eliminado,'ALTA |" + Format(Now, "dd/MM/yyyy HH:mm:ss") + "',CodColor,PCardado,'" + Format(Now, "yyyyMM01") + "',ColorCono"
                                sStr = sStr + ",'',NULL,0,'RESERVADO' from HilamarHiladoStock where Partida ='" + txtPartida.Text + "'"
                                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                                Command.ExecuteNonQuery()
                            End If
                        End If
                    End If

                    sStr = "INSERT INTO HilamarHiladoStockEncMov "
                    sStr = sStr + "(NroRemito, Fecha, TipoMov, AuditAlta, Observacion) "
                    sStr = sStr + "VALUES "
                    sStr = sStr + "('" + UltimoRemitoIngreso + "','" + Format(dtpFecha.Value, "yyyyMMdd") + "','I',getdate(),'" + "Reserva Por Consumo " + UltimoRemitoConsumo + "')"
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()
                    'el detalle
                    sStr = "INSERT INTO HilamarHiladoStockDetMov "
                    sStr = sStr + "(TipoMov, NroRemito, Partida, Conos, Kilos, Observaciones) "
                    sStr = sStr + "VALUES "
                    sStr = sStr + "('I', '" + UltimoRemitoIngreso + "','" + txtPartida.Text.Replace("H", "G") + "'," + "NULL" + "," + txtKilos.Text + ",'')"
                    Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                    Command.ExecuteNonQuery()

                End If
            End If


        ElseIf rbConsumoConvertirC.Checked Then
            'Me fijo si existe la partida commoditie, sino , la creo
            Dim nroPartCommoditie As String = txtPartida.Text.Trim + "/C"
            Dim nroRemito As Integer


            'Controlo que haya Kilos Disponibles en la partida de origen
            Dim kilosDisponibles As Integer
            Dim CommandInt As SqlCommand
            Dim ReaderInt As SqlDataReader
            Dim sStrInt As String
            sStrInt = "SELECT Totales.Partida AS Partida,ISNULL(CONVERT(INT,Totales.KilosDetalle + Totales.KilosInicial),0) AS Kilos FROM (SELECT S.Partida,S.FechaStockDesde,S.FechaStockHasta,ISNULL(SUM(Detalle.KilosDet),0) AS KilosDetalle,S.Kilos AS KilosInicial FROM HilamarHiladoStock S "
            sStrInt += "LEFT JOIN (SELECT D.Partida,(D.Kilos * (CASE D.TipoMov WHEN 'C' THEN -1 WHEN 'I' THEN 1 WHEN 'DI' THEN 1 WHEN 'E' THEN -1 END)) AS KilosDet,E.Fecha AS Fecha FROM HilamarHiladoStockEncMov E INNER JOIN HilamarHiladoStockDetMov D ON E.TipoMov = D.TipoMov AND D.NroRemito = E.NroRemito "
            sStrInt += "WHERE ISNULL(D.Eliminado,0)=0 AND ISNULL(E.Eliminado,0)=0) AS Detalle ON S.Partida = Detalle.Partida WHERE ISNULL(Detalle.Fecha,GETDATE()) > ISNULL(FechaStockHasta,'19000101') AND ISNULL(Detalle.Fecha,GETDATE()) >= ISNULL(FechaStockDesde,'19000101') AND ISNULL(S.Eliminado,0)=0  "
            sStrInt += "GROUP BY S.Partida,S.Kilos,FechaStockDesde,FechaStockHasta) AS Totales WHERE (TOTALES.KilosDetalle+Totales.KilosInicial) > 0 AND Partida = '" + txtPartida.Text + "'  GROUP BY Partida,Totales.KilosDetalle,Totales.KilosInicial"

            CommandInt = New SqlCommand(sStrInt, cConexionApp.SQLConn)
            ReaderInt = CommandInt.ExecuteReader

            If ReaderInt.HasRows Then
                ReaderInt.Read()
                If CInt(Reader.Item("Kilos")) < CInt(txtKilos.Text) Then
                    MsgBox("La partida solo tiene " + Reader.Item("Kilos").ToString + " disponibles. No se puede llevar a cabo la operacion.")
                    Exit Sub
                End If
            Else
                MsgBox("La partida no tiene Kilos disponibles")
                Exit Sub
            End If

            sStr = "SELECT count(*) as Cantidad FROM HilamarHiladoStock WHERE Partida = '" + nroPartCommoditie + "' and Eliminado=0 AND FechaStockHasta is NULL"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            Reader.Read()
            If CInt(Reader.Item("Cantidad")) > 0 Then
                sStr = "SELECT max(CONVERT(INT,NroRemito))+1 AS NroRemito FROM HilamarHiladoStockEncMov WHERE TipoMov = 'I' AND ISNULL(Eliminado,0) = 0"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Reader = Command.ExecuteReader
                If Reader.Read Then
                    nroRemito = Reader.Item("NroRemito")
                Else
                    MsgBox("No se pudo recuperar el Nro de Remito")
                    Exit Sub
                End If

                'Agrego el encabezado con el nroRemito
                sStr = "INSERT INTO HilamarHiladoStockEncMov(NroRemito,Fecha,TipoMov,AuditAlta,Observacion,Eliminado) VALUES('" + nroRemito.ToString + "','" + dtpFecha.Value.ToString + "','I',GETDATE(),'Ingreso Commoditie',0)"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()

                'Agrego el detalle del remito
                sStr = "INSERT INTO HilamarHiladoStockDetMov(TipoMov,NroRemito,Partida,Kilos,Observaciones,Eliminado) VALUES('I','" + nroRemito.ToString + "','" + nroPartCommoditie.ToString + "'," + txtKilos.Text + ",'Ingreso Commoditie',0)"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()

            Else
                'Agrego la partida
                sStr = "INSERT INTO HilamarHiladoStock(Partida,CodTipoHilado,Kilos,Color,Eliminado,Auditoria,CodColor,FechaStockDesde,PartidaOrigen,EsDiscontinuada,Observacion,FechaAltaPartida,Condicion,PCardado) SELECT '" + nroPartCommoditie.ToString + "',CodTipoHilado,0,Color,0,'ALTA |" + Format(Now, "dd/MM/yyyy HH:mm:ss") + "',"
                sStr += "CodColor,'" + dtpFecha.Value.ToString + "',Partida,EsDiscontinuada,'Commoditie',GETDATE(),1,PCardado FROM HilamarHiladoStock WHERE ISNULL(Eliminado,0)=0 AND Partida = '" + txtPartida.Text + "' AND FechaStockHasta is NULL"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()

                sStr = "SELECT max(CONVERT(INT,NroRemito))+1 AS NroRemito FROM HilamarHiladoStockEncMov WHERE TipoMov = 'I' AND ISNULL(Eliminado,0) = 0"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Reader = Command.ExecuteReader
                If Reader.Read Then
                    nroRemito = Reader.Item("NroRemito")
                Else
                    MsgBox("No se pudo recuperar el Nro de Remito")
                    Exit Sub
                End If

                'Agrego el encabezado con el nroRemito
                sStr = "INSERT INTO HilamarHiladoStockEncMov(NroRemito,Fecha,TipoMov,AuditAlta,Observacion,Eliminado) VALUES('" + nroRemito.ToString + "','" + dtpFecha.Value.ToString + "','I',GETDATE(),'Ingreso Commoditie',0)"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()

                'Agrego el detalle del remito
                sStr = "INSERT INTO HilamarHiladoStockDetMov(TipoMov,NroRemito,Partida,Kilos,Observaciones,Eliminado) VALUES('I','" + nroRemito.ToString + "','" + nroPartCommoditie.ToString + "'," + txtKilos.Text + ",'Ingreso Commoditie',0)"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()

            End If

        End If


        MensajeInfo("Se ha registrado correctamente el Consumo del Hilado.")

        'limpio la ventana
        txtObservacion.Text = ""
        txtPartida.Text = ""
        txtHilado.Text = ""
        txtColor.Text = ""
        txtKilos.Text = ""

        Cargar()

        Exit Sub

ErrGuardar:
        MensajeCritico("Error al grabar el Ingreso de Hilado. Verifique." + Chr(10) + Err.Description)
    End Sub

    Private Function Validar() As Boolean
        On Error GoTo ErrValidar
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr, Item As String
        Validar = False
        Item = ""
        sStr = ""

        If txtPartida.Text = "" Then
            MensajeAtencion("Debe ingresar una partida.")
            Validar = False
            Exit Function
        End If

        If txtHilado.Text = "" Then
            MensajeAtencion("Debe ingresar una partida válida.")
            Validar = False
            Exit Function
        End If

        If txtKilos.Text = "" Then
            MensajeAtencion("Debe ingresar los kilos que se van a consumir.")
            Validar = False
            Exit Function
        End If

        If Not IsNumeric(txtKilos.Text) Then
            MensajeAtencion("Los kilos que se van a consumir deben ser un número.")
            Validar = False
            Exit Function
        End If

        'controlo que si puso que queria convertir el hilado no tenga una R porque seria un bucle infinito, consumiria hilado R para convertirlo en el mismo R
        If rbConsumoConvertirR.Checked And InStr(txtPartida.Text, "R") Then
            MensajeAtencion("Está indicando que desea convertir una partida de hilado Repasado en otra de igual caracteristica." + Chr(10) + "No se hará el movimiento. Verifique.")
            Validar = False
            Exit Function
        End If


        Validar = True
        Exit Function
ErrValidar:
        Validar = False
        MensajeCritico("Error al validar.")
    End Function

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Close()
    End Sub

    Private Sub dtpFecha_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dtpFecha.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            txtObservacion.Select()
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtPartida.Select()
        End If
    End Sub

    Private Sub txtPartida_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPartida.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim dato As String()
            dato = CodHiladoyHiladoyColordeUnaPartida(txtPartida.Text, dtpFecha.Value)
            txtHilado.Text = dato(0) + "-" + dato(1)
            txtColor.Text = dato(2)
            If txtHilado.Text <> "" Then txtKilos.Select()
        ElseIf e.KeyCode = Keys.F3 Then
            ItemSeleccionado = ""
            Dim FormListado As New frmListado()
            FormListado.Pantalla = "BuscaPartida"
            FormListado.txtBuscar.Text = txtPartida.Text
            FormListado.Cargar()
            FormListado.CargarListado()
            FormListado.ShowDialog()
            If ItemSeleccionado.ToString <> "" Then
                Dim dato As String()
                dato = CodHiladoyHiladoyColordeUnaPartida(ItemSeleccionado, dtpFecha.Value)
                txtPartida.Text = ItemSeleccionado
                txtHilado.Text = dato(0) + "-" + dato(1)
                txtColor.Text = dato(2)
                If txtHilado.Text <> "" Then txtKilos.Select()
            End If
        End If
    End Sub

    Private Sub txtPartida_TextChanged(sender As Object, e As EventArgs) Handles txtPartida.TextChanged
        '
    End Sub

    Private Sub txtPartida_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPartida.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            BuscarPartida()
        End If
    End Sub
    Private Sub BuscarPartida()
        Dim sStr As String
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "Select count(*) as  canti "
        sStr = sStr + "FROM HilamarHiladoStock "
        sStr = sStr + "WHERE Partida like '" + txtPartida.Text + "' "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Reader.Read()
        If CInt(Reader.Item("canti").ToString) = 1 Then
            Dim dato As String()
            dato = CodHiladoyHiladoyColordeUnaPartida(txtPartida.Text, dtpFecha.Value)
            txtHilado.Text = dato(0) + "-" + dato(1)
            txtColor.Text = dato(2)
            txtKilos.Select()

        Else
            ItemSeleccionado = ""
            Dim FormListado As New frmListado()
            FormListado.Pantalla = "BuscaPartida"
            FormListado.txtBuscar.Text = txtPartida.Text
            FormListado.Cargar()
            FormListado.CargarListado()
            FormListado.ShowDialog()
            If ItemSeleccionado.ToString <> "" Then
                Dim dato As String()
                dato = CodHiladoyHiladoyColordeUnaPartida(ItemSeleccionado, dtpFecha.Value)
                txtPartida.Text = ItemSeleccionado
                txtHilado.Text = dato(0) + "-" + dato(1)
                txtColor.Text = dato(2)
                If txtHilado.Text <> "" Then txtKilos.Select()
            End If

        End If
    End Sub

    Private Sub txtKilos_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtKilos.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            rbConsumoSolo.Select()
        End If
    End Sub

    Private Sub rbConsumoSolo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rbConsumoSolo.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            rbConsumoConvertirR.Select()
        End If
    End Sub

    Private Sub rbConsumoConvertirR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles rbConsumoConvertirR.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            cmdAceptar.Select()
        End If
    End Sub

    Public Function CodHiladoyHiladoyColordeUnaPartida(ByVal Partida As String, ByVal Fecha As Date) As String()
        On Error GoTo ErrCodHiladoyHiladoyColordeUnaPartida
        Dim sStr As String
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        CodHiladoyHiladoyColordeUnaPartida = {"", "", ""}

        sStr = "SELECT ISNULL(FECHASTOCKDESDE,'') AS FECHASTOCKDESDE,ISNULL(FECHASTOCKHASTA,getdate()) AS FECHASTOCKHASTA, ISNULL(COLORCONO,'') AS COLORCONO, ISNULL(PARTIDAORIGEN,'') AS PARTIDAORIGEN"
        sStr = sStr + ",* "
        sStr = sStr + " FROM HilamarHiladoStock H INNER JOIN HilamarTipoHiladoPartidas T ON H.Codtipohilado=T.Codigo "
        sStr = sStr + " WHERE H.Eliminado=0 and H.Partida like '" + Partida + "' and ISNULL(FECHASTOCKHASTA,getdate())>='" + Format(Fecha, "yyyyMMdd") + "'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                CodHiladoyHiladoyColordeUnaPartida = {Reader.Item("CODTIPOHILADO").ToString, Reader.Item("DESCRIPCION").ToString, Reader.Item("COLOR").ToString}
            End If
        End If

        Exit Function
ErrCodHiladoyHiladoyColordeUnaPartida:
        CodHiladoyHiladoyColordeUnaPartida = {"", "", ""}
        MensajeCritico("Error al recuperar Hilado y Color de una Partida.")
    End Function

End Class