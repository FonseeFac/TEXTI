Imports System.Data.SqlClient

Public Class frmABMMateriaPrima

    Public Alta As Boolean
    Public Pantalla As String
    Public ID As Integer
    Dim Command As New SqlCommand
    Dim Reader As SqlDataReader
    Dim sStr, Tabla As String

    Public Sub Cargar()
        rbPesos.Checked = True
        If Not Alta Then
            If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
            sStr = "SELECT * FROM HilamarMateriasPrimas WHERE id = " + ID.ToString
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read Then
                    txtDescripcion.Text = Reader.Item("Descripcion").ToString
                    If Reader.Item("Moneda").ToString = "Pesos" Then
                        rbPesos.Checked = True
                    Else
                        rbDolares.Checked = True
                    End If
                    txtCostoPorKilo.Text = Reader.Item("CostoPorKilo").ToString
                End If
            End If
        End If
        txtDescripcion.Select()
    End Sub

    Private Sub cmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        Guardar()
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Close()
    End Sub

    Private Sub Guardar()
        Dim moneda As String = ""
        If Not Validar() Then Exit Sub
        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        If rbPesos.Checked Then
            moneda = "Pesos"
        Else
            moneda = "Dolares"
        End If
        If Alta Then
            sStr = "INSERT INTO HilamarMateriasPrimas (Descripcion, Moneda, CostoPorkilo, ELiminado, Auditoria) VALUES ('" + txtDescripcion.Text
            sStr = sStr + "', '" + moneda + "', " + txtCostoPorKilo.Text.Replace(",", ".") + ", 0, 'Alta:" + Environment.MachineName + "|" + Now.ToString + "')"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()
            MensajeAtencion("Materia Prima agregada correctamente.")
            Alta = False
            Close()
        Else 'Modificación
            sStr = "UPDATE HilamarMateriasPrimas SET Descripcion = '" + txtDescripcion.Text + "'"
            sStr = sStr + " , Moneda = '" + moneda + "', CostoPorkilo = " + txtCostoPorKilo.Text.Replace(",", ".")
            sStr = sStr + " , Auditoria = 'Modif:" + Environment.MachineName + "|" + Now.ToString + "' "
            sStr = sStr + " WHERE id = " + ID.ToString
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()

            MensajeAtencion("Materia Prima modificada correctamente.")
        End If

    End Sub

    Private Function Validar()
        On Error GoTo ErrValidar

        If txtDescripcion.Text = "" Then
            Validar = False
            MensajeAtencion("Debe ingresar una descripción.")
            Exit Function
        End If

        If txtCostoPorKilo.Text = "" Then
            txtCostoPorKilo.Text = "0"
        End If

        If Not IsNumeric(txtCostoPorKilo.Text) Then
            Validar = False
            MensajeAtencion("El Costo por Kilo por debe ser un número.")
            Exit Function
        End If

        If Alta Then
            If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
            sStr = "SELECT * FROM HilamarMateriasPrimas WHERE Descripcion = '" + txtDescripcion.Text + "'"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read Then
                    Validar = False
                    MensajeAtencion("Ya existe una Materia Prima con esa descripción.")
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

    Private Sub txtDescripcion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown
        If e.KeyCode = Keys.Enter Then txtCostoPorKilo.Select()
        If e.KeyCode = Keys.Escape Then Close()
    End Sub
    Private Sub txtMarca_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCostoPorKilo.KeyDown
        If e.KeyCode = Keys.Enter Then cmdGuardar.Select()
    End Sub

End Class