Imports System.Data.SqlClient

Public Class frmABMHiladoInterno

    Public Alta As Boolean
    Public Pantalla As String
    Public ID As Integer
    Dim CodOriginal, DesOriginal As String
    Dim Command As New SqlCommand
    Dim Reader As SqlDataReader
    Dim sStr, Tabla As String

    Public Sub Cargar()
        CodOriginal = ""
        DesOriginal = ""
        If Not Alta Then
            If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
            sStr = "SELECT * FROM HilamarHiladosInternos WHERE id = " + ID.ToString
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read Then
                    txtCodigo.Text = Reader.Item("Codigo").ToString
                    CodOriginal = Reader.Item("Codigo").ToString
                    txtDescripcion.Text = Reader.Item("Descripcion").ToString
                    DesOriginal = Reader.Item("Descripcion").ToString
                    If IsDBNull(Reader.Item("Moneda")) Or IsDBNull(Reader.Item("CostoPorKilo")) Then
                        chkCostoFijo.Checked = False
                        gbMoneda.Enabled = False
                        rbPesos.Checked = False
                        rbDolares.Checked = False
                        lblCostoPorKilo.Enabled = False
                        txtCostoPorKilo.Enabled = False
                        txtCostoPorKilo.Text = ""
                    Else
                        chkCostoFijo.Checked = True
                        gbMoneda.Enabled = True
                        rbPesos.Checked = True
                        lblCostoPorKilo.Enabled = True
                        txtCostoPorKilo.Enabled = True
                        If Reader.Item("Moneda").ToString = "Dolares" Then
                            rbDolares.Checked = True
                        Else
                            rbPesos.Checked = True
                        End If
                        txtCostoPorKilo.Text = Reader.Item("CostoPorKilo").ToString
                    End If
                End If
            End If
        Else
            chkCostoFijo.Checked = False
            gbMoneda.Enabled = False
            rbPesos.Checked = False
            rbDolares.Checked = False
            lblCostoPorKilo.Enabled = False
            txtCostoPorKilo.Enabled = False
            txtCostoPorKilo.Text = ""
        End If
        txtCodigo.Select()
    End Sub

    Private Sub cmdGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
        Guardar()
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Close()
    End Sub

    Private Sub Guardar()
        Dim Moneda As String

        If Not Validar() Then Exit Sub
        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        If Alta Then
            If chkCostoFijo.Checked = True Then
                If rbPesos.Checked Then
                    Moneda = "Pesos"
                Else
                    Moneda = "Dolares"
                End If

                sStr = "INSERT INTO HilamarHiladosInternos (Codigo, Descripcion, Eliminado, Auditoria, Moneda, CostoPorKilo) VALUES ('"
                sStr = sStr + txtCodigo.Text + "', '" + txtDescripcion.Text.ToString + "', 0, '" + Environment.MachineName.ToString + " - Alta | " + Now.ToString + "'"
                sStr = sStr + ",'" + Moneda + "'," + txtCostoPorKilo.Text.Replace(",", ".") + ")"

            Else
                sStr = "INSERT INTO HilamarHiladosInternos (Codigo, Descripcion, Eliminado, Auditoria) VALUES ('"
                sStr = sStr + txtCodigo.Text + "', '" + txtDescripcion.Text.ToString + "', 0, '" + Environment.MachineName.ToString + " - Alta | " + Now.ToString + "')"
            End If

            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()
            MensajeAtencion("Hilado Interno agregado correctamente.")
            Alta = False
            Close()
        Else 'Modificación

            If chkCostoFijo.Checked = True Then
                If rbPesos.Checked Then
                    Moneda = "Pesos"
                Else
                    Moneda = "Dolares"
                End If

                sStr = "UPDATE HilamarHiladosInternos SET "
                sStr = sStr + " Codigo='" + txtCodigo.Text + "'"
                sStr = sStr + ", Descripcion='" + txtDescripcion.Text + "'"
                sStr = sStr + ", Auditoria='" + Environment.MachineName.ToString + " - Modif | " + Now.ToString + "'"
                sStr = sStr + ", Moneda='" + Moneda + "'"
                sStr = sStr + ", CostoPorKilo=" + txtCostoPorKilo.Text.Replace(",", ".") + ""
                sStr = sStr + " WHERE id = " + ID.ToString

            Else

                sStr = "UPDATE HilamarHiladosInternos SET "
                sStr = sStr + " Codigo='" + txtCodigo.Text + "'"
                sStr = sStr + ", Descripcion='" + txtDescripcion.Text + "'"
                sStr = sStr + ", Auditoria='" + Environment.MachineName.ToString + " - Modif | " + Now.ToString + "'"
                sStr = sStr + ", Moneda=NULL"
                sStr = sStr + ", CostoPorKilo=NULL"
                sStr = sStr + " WHERE id = " + ID.ToString

            End If

            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()
            MensajeAtencion("Hilado Interno modificado correctamente.")
        End If

    End Sub

    Private Function Validar()
        On Error GoTo ErrValidar

        If txtDescripcion.Text = "" Then
            Validar = False
            MensajeAtencion("Debe ingresar una descripción.")
            Exit Function
        End If

        If txtCodigo.Text = "" Then
            Validar = False
            MensajeAtencion("Debe ingresar un código.")
            Exit Function
        End If

        If chkCostoFijo.Checked = True Then
            If txtCostoPorKilo.Text = "" Then
                txtCostoPorKilo.Text = "0"
            End If

            If Not IsNumeric(txtCostoPorKilo.Text) Then
                Validar = False
                MensajeAtencion("El Costo por Kilo debe ser un número.")
                Exit Function
            End If
        End If

        If Alta Then
            If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
            sStr = "SELECT * FROM HilamarHiladosInternos WHERE Codigo = '" + txtCodigo.Text + "'"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read Then
                    Validar = False
                    MensajeAtencion("Ya existe un Hilado Interno con ese código.")
                    Exit Function
                End If
            End If
            sStr = "SELECT * FROM HilamarHiladosInternos WHERE Descripcion = '" + txtDescripcion.Text + "'"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read Then
                    Validar = False
                    MensajeAtencion("Ya existe un Hilado Interno con esa Descripción.")
                    Exit Function
                End If
            End If
        End If

        If Not Alta And CodOriginal <> txtCodigo.Text Then
            'si cambio el codigo del hilado debo controlar que no puso uno que ya esta usado
            If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
            sStr = "SELECT * FROM HilamarHiladosInternos WHERE Codigo = '" + txtCodigo.Text + "'"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read Then
                    Validar = False
                    MensajeAtencion("Ya existe un Hilado Interno con ese código.")
                    Exit Function
                End If
            End If
        End If
        If Not Alta And DesOriginal <> txtDescripcion.Text Then
            'si cambio la descripcion del hilado debo controlar que no puso uno que ya esta usado
            If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
            sStr = "SELECT * FROM HilamarHiladosInternos WHERE Descripcion = '" + txtDescripcion.Text + "'"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read Then
                    Validar = False
                    MensajeAtencion("Ya existe un Hilado Interno con esa Descripción.")
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

    Private Sub txtCodigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then txtDescripcion.Select()
        If e.KeyCode = Keys.Escape Then Close()
    End Sub
    Private Sub txtDescripcion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDescripcion.KeyDown
        If e.KeyCode = Keys.Enter Then chkCostoFijo.Select()
    End Sub
    Private Sub txtCostoPorKilo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCostoPorKilo.KeyDown
        If e.KeyCode = Keys.Enter Then cmdGuardar.Select()
    End Sub

    Private Sub chkCostoFijo_CheckedChanged(sender As Object, e As EventArgs) Handles chkCostoFijo.CheckedChanged
        If chkCostoFijo.Checked = True Then
            gbMoneda.Enabled = True
            rbPesos.Checked = True
            lblCostoPorKilo.Enabled = True
            txtCostoPorKilo.Enabled = True
        Else
            gbMoneda.Enabled = False
            rbPesos.Checked = False
            rbDolares.Checked = False
            lblCostoPorKilo.Enabled = False
            txtCostoPorKilo.Enabled = False
            txtCostoPorKilo.Text = ""
        End If
    End Sub
End Class