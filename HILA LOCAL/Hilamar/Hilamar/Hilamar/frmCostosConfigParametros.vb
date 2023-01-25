Imports System.Data.SqlClient

Public Class frmCostosConfigParametros

    Dim Command As New SqlCommand
    Dim Reader As SqlDataReader
    Dim sStr As String

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVolver.Click
        Close()
    End Sub

    Private Sub frmCostosConfigParametros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDatosDeParametrosGrales()
    End Sub

    Private Sub CargarDatosDeParametrosGrales()

        txtTotalCamuzzi.Text = ""

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        sStr = "SELECT * FROM HilamarCostosParametrosGrales"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read Then
                txtTotalCamuzzi.Text = Reader.Item("TotalCamuzzi").ToString
                txtTotalEnergy.Text = Reader.Item("TotalEnergy").ToString
                txtM3GasConsumidos.Text = Reader.Item("M3GasConsumidos").ToString
                lblGasValorGlobalPorM3.Text = Format((CDbl(txtTotalCamuzzi.Text) + CDbl(txtTotalEnergy.Text)) / CDbl(txtM3GasConsumidos.Text), "0.00")

                txtTotalEdea.Text = Reader.Item("TotalEdea").ToString
                txtKWLuzConsumidos.Text = Reader.Item("KwConsumidos").ToString
                lblLuzValorGlobalPorKwH.Text = Format(CDbl(txtTotalEdea.Text) / CDbl(txtKWLuzConsumidos.Text), "0.00")

                txtTotalObrasSanitarias.Text = Reader.Item("TotalObrasSanitarias").ToString
                txtM3AguaConsumidos.Text = Reader.Item("M3AguaConsumidos").ToString
                lblAguaValorGlobalPorM3.Text = Format(CDbl(txtTotalObrasSanitarias.Text) / CDbl(txtM3AguaConsumidos.Text), "0.00")

                txtHoraHombreRecibo.Text = Reader.Item("CostoHoraHombre").ToString
                txtFactorMultiplicador.Text = Reader.Item("FactorMultiplicadordelValorHoraHombre").ToString
                lblHoraHombre.Text = Format(CDbl(txtHoraHombreRecibo.Text) * CDbl(txtFactorMultiplicador.Text), "0.00")

            End If
        End If

        txtTotalCamuzzi.Select()

    End Sub

    Private Sub cmdGuardarConsumoGas_Click(sender As Object, e As EventArgs) Handles cmdGuardarConsumoGas.Click
        If Not ValidarConsumoGas() Then Exit Sub

        sStr = "UPDATE HilamarCostosParametrosGrales SET "
        sStr = sStr + "TotalCamuzzi=" + txtTotalCamuzzi.Text.Replace(",", ".") + " "
        sStr = sStr + ",TotalEnergy=" + txtTotalEnergy.Text.Replace(",", ".") + " "
        sStr = sStr + ",M3GasConsumidos=" + txtM3GasConsumidos.Text.Replace(",", ".") + " "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        MensajeInfo("Se modificaron correctamente los datos de Consumo de Gas.")
    End Sub
    Private Function ValidarConsumoGas()
        On Error GoTo ErrValidar

        If txtTotalCamuzzi.Text = "" Then
            txtTotalCamuzzi.Text = "0"
        End If
        If Not IsNumeric(txtTotalCamuzzi.Text) Then
            ValidarConsumoGas = False
            MensajeAtencion("El Total Facturado de Camuzzi debe ser un número.")
            Exit Function
        End If

        If txtTotalEnergy.Text = "" Then
            txtTotalEnergy.Text = "0"
        End If
        If Not IsNumeric(txtTotalEnergy.Text) Then
            ValidarConsumoGas = False
            MensajeAtencion("El Total Facturado de Energy debe ser un número.")
            Exit Function
        End If

        If txtM3GasConsumidos.Text = "" Then
            ValidarConsumoGas = False
            MensajeAtencion("Los M3 consumidos de Gas no pueden quedar vacios.")
            Exit Function
        End If
        If Not IsNumeric(txtM3GasConsumidos.Text) Then
            ValidarConsumoGas = False
            MensajeAtencion("Los M3 consumidos de Gas debe ser un número.")
            Exit Function
        End If
        If CDbl(txtM3GasConsumidos.Text) <= 0 Then
            ValidarConsumoGas = False
            MensajeAtencion("Los M3 consumidos de Gas deben ser un número mayor que cero.")
            Exit Function
        End If


        ValidarConsumoGas = True

        Exit Function
ErrValidar:
        ValidarConsumoGas = False
        MensajeAtencion("Error al validar el Consumo de Gas.")
    End Function

    Private Sub cmdGuardarConsumoLuz_Click(sender As Object, e As EventArgs) Handles cmdGuardarConsumoLuz.Click
        If Not ValidarConsumoLuz() Then Exit Sub

        sStr = "UPDATE HilamarCostosParametrosGrales SET "
        sStr = sStr + "TotalEdea=" + txtTotalEdea.Text.Replace(",", ".") + " "
        sStr = sStr + ",KwConsumidos=" + txtKWLuzConsumidos.Text.Replace(",", ".") + " "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        MensajeInfo("Se modificaron correctamente los datos de Consumo de Gas.")
    End Sub
    Private Function ValidarConsumoLuz()
        On Error GoTo ErrValidar

        If txtTotalEdea.Text = "" Then
            txtTotalEdea.Text = "0"
        End If
        If Not IsNumeric(txtTotalEdea.Text) Then
            ValidarConsumoLuz = False
            MensajeAtencion("El Total Facturado de Edea debe ser un número.")
            Exit Function
        End If

        If txtKWLuzConsumidos.Text = "" Then
            ValidarConsumoLuz = False
            MensajeAtencion("Los Kw consumidos de Luz no pueden quedar vacios.")
            Exit Function
        End If
        If Not IsNumeric(txtKWLuzConsumidos.Text) Then
            ValidarConsumoLuz = False
            MensajeAtencion("Los Kw de Luz consumidos deben ser un número.")
            Exit Function
        End If
        If CDbl(txtKWLuzConsumidos.Text) <= 0 Then
            ValidarConsumoLuz = False
            MensajeAtencion("Los Kw consumidos de Luz deben ser un número mayor que cero.")
            Exit Function
        End If

        ValidarConsumoLuz = True

        Exit Function
ErrValidar:
        ValidarConsumoLuz = False
        MensajeAtencion("Error al validar el consumo de Luz.")
    End Function

    Private Sub cmdGuardarConsumoAgua_Click(sender As Object, e As EventArgs) Handles cmdGuardarConsumoAgua.Click
        If Not ValidarConsumoAgua() Then Exit Sub

        sStr = "UPDATE HilamarCostosParametrosGrales SET "
        sStr = sStr + "TotalObrasSanitarias=" + txtTotalObrasSanitarias.Text.Replace(",", ".") + " "
        sStr = sStr + ",M3AguaConsumidos=" + txtM3AguaConsumidos.Text.Replace(",", ".") + " "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        MensajeInfo("Se modificaron correctamente los datos de Consumo de Obras Sanitarias.")
    End Sub
    Private Function ValidarConsumoAgua()
        On Error GoTo ErrValidar

        If txtTotalObrasSanitarias.Text = "" Then
            txtTotalObrasSanitarias.Text = "0"
        End If
        If Not IsNumeric(txtTotalObrasSanitarias.Text) Then
            ValidarConsumoAgua = False
            MensajeAtencion("El Total Facturado de obras Sanitarias debe ser un número.")
            Exit Function
        End If

        If txtM3AguaConsumidos.Text = "" Then
            ValidarConsumoAgua = False
            MensajeAtencion("Los M3 consumidos de Obras Sanitarias no pueden quedar vacios.")
            Exit Function
        End If
        If Not IsNumeric(txtM3AguaConsumidos.Text) Then
            ValidarConsumoAgua = False
            MensajeAtencion("Los M3 consumidos de Obras Sanitarias deben ser un número.")
            Exit Function
        End If
        If CDbl(txtM3AguaConsumidos.Text) <= 0 Then
            ValidarConsumoAgua = False
            MensajeAtencion("Los M3 consumidos de Obras Sanitarias deben ser un número mayor que cero.")
            Exit Function
        End If

        ValidarConsumoAgua = True

        Exit Function
ErrValidar:
        ValidarConsumoAgua = False
        MensajeAtencion("Error al validar el consumo de Obras Sanitarias.")
    End Function

    Private Sub cmdGuardarHorasHombre_Click(sender As Object, e As EventArgs) Handles cmdGuardarHorasHombre.Click
        If Not ValidarHorasHombre() Then Exit Sub

        sStr = "UPDATE HilamarCostosParametrosGrales SET "
        sStr = sStr + "CostoHoraHombre=" + txtHoraHombreRecibo.Text.Replace(",", ".") + " "
        sStr = sStr + ",FactorMultiplicadordelValorHoraHombre=" + txtFactorMultiplicador.Text.Replace(",", ".") + " "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        MensajeInfo("Se modificaron correctamente los datos de Costo de Horas Hombre.")
    End Sub
    Private Function ValidarHorasHombre()
        On Error GoTo ErrValidar

        If txtHoraHombreRecibo.Text = "" Then
            txtHoraHombreRecibo.Text = "0"
        End If
        If Not IsNumeric(txtHoraHombreRecibo.Text) Then
            ValidarHorasHombre = False
            MensajeAtencion("El costo de las Horas Hombre por Recibo debe ser un número.")
            Exit Function
        End If

        If txtFactorMultiplicador.Text = "" Then
            txtFactorMultiplicador.Text = "1"
        End If
        If Not IsNumeric(txtFactorMultiplicador.Text) Then
            ValidarHorasHombre = False
            MensajeAtencion("El Factor Multiplicador debe ser un número.")
            Exit Function
        End If

        ValidarHorasHombre = True

        Exit Function
ErrValidar:
        ValidarHorasHombre = False
        MensajeAtencion("Error al validar las Horas Hombre.")
    End Function

End Class