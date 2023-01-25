Imports System.Data.SqlClient

Public Class frmABMSimple
    Public Alta As Boolean
    Public id As Integer
    Public Pantalla As String
    Dim Command As New SqlCommand
    Dim Reader As SqlDataReader
    Dim sStr As String

    Public Sub Cargar()

        If Not Alta Then
            If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
            txtCodigo.Enabled = False
            If Pantalla = "Hilado" Then
                sStr = "SELECT * FROM HilamarHilados WHERE id = " + id.ToString
            ElseIf Pantalla = "HiladoInterno" Then
                sStr = "SELECT * FROM HilamarHiladosInternos WHERE id = " + id.ToString
            ElseIf Pantalla = "MateriasPrimas" Then
                sStr = "SELECT * FROM HilamarMateriasPrimas WHERE id = " + id.ToString
            ElseIf Pantalla = "Procesos" Then
                sStr = "SELECT * FROM HilamarProcesos WHERE id = " + id.ToString
            ElseIf Pantalla = "TipoMovimientos" Then
                sStr = "SELECT * FROM HilamarTipoMovimientos WHERE id = " + id.ToString
            End If
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read Then
                    If Pantalla = "MateriasPrimas" Or Pantalla = "Procesos" Then
                        txtCodigo.Text = Reader.Item("Id").ToString
                        txtDescripcion.Text = Reader.Item("Descripcion").ToString
                    Else
                        txtCodigo.Text = Reader.Item("Codigo").ToString
                        txtDescripcion.Text = Reader.Item("Descripcion").ToString
                    End If
                End If
            End If

        Else
            txtCodigo.Select()
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Guardar()
    End Sub

    Private Function Validar()
        On Error GoTo ErrValidar

        If txtCodigo.Text = "" Then
            Validar = False
            MensajeAtencion("Debe ingresar un código.")
            Exit Function
        End If

        If txtDescripcion.Text = "" Then
            Validar = False
            MensajeAtencion("Debe ingresar una descripción.")
            Exit Function
        End If

        If Alta Then
            If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
            If Pantalla = "Hilado" Then
                sStr = "SELECT count(*) as cant FROM HilamarHilados WHERE Codigo = '" + txtCodigo.Text + "'"
            ElseIf Pantalla = "HiladoInterno" Then
                sStr = "SELECT count(*) as cant FROM HilamarHiladosInternos WHERE Codigo = '" + txtCodigo.Text + "'"
            ElseIf Pantalla = "MateriasPrimas" Then
                sStr = "SELECT count(*) as cant FROM HilamarMateriasPrimas WHERE Descripción = '" + txtDescripcion.Text + "'"
            ElseIf Pantalla = "Procesos" Then
                sStr = "SELECT count(*) as cant FROM HilamarProcesos WHERE Descripcion = '" + txtDescripcion.Text + "'"
            ElseIf Pantalla = "TipoMovimientos" Then
                sStr = "SELECT count(*) as cant FROM HilamarTipoMovimientos WHERE Codigo = " + txtCodigo.Text
            End If
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read Then
                    If Reader.Item("cant") > 0 Then
                        Validar = False
                        If Pantalla = "Hilado" Or Pantalla = "HiladoInterno" Then
                            MensajeAtencion("Código de Hilado Repetido. Verifique.")
                        ElseIf Pantalla = "MateriasPrimas" Then
                            MensajeAtencion("Nombre de Materia Prima Repetido. Verifique.")
                        ElseIf Pantalla = "Procesos" Then
                            MensajeAtencion("Nombre de Proceso Repetido. Verifique.")
                        ElseIf Pantalla = "TipoMovimientos" Then
                            MensajeAtencion("Código de Movimiento Repetido. Verifique.")
                        End If
                        Exit Function
                    End If
                End If
            End If
        End If



        Validar = True
        Exit Function
ErrValidar:
        Validar = False
        MensajeAtencion("Error al validar.")

    End Function

    Private Sub Guardar()
        Dim Auditoria, Mensaje, Descripcion As String

        If Not Validar() Then Exit Sub

        Mensaje = ""
        Descripcion = ""

        Descripcion = SQLStr(txtDescripcion.Text).ToString

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
        If Pantalla = "Hilado" Then
            If Alta Then
                Mensaje = "Tipo de Hilado agregado"
                Auditoria = Environment.MachineName.ToString + " - Alta de Tipo de Hilado | " + Now.ToString
                sStr = "INSERT INTO HilamarHilados (Codigo, Descripcion, Eliminado, Auditoria) VALUES ('" + txtCodigo.Text + "', '" + Descripcion.ToString + "', 0, '" + Auditoria.ToString + "')"
            Else
                Mensaje = "Tipo de Hilado modificado"
                Auditoria = Environment.MachineName.ToString + " - Modificación de Tipo de Hilado | " + Now.ToString
                sStr = "UPDATE HilamarHilados SET Descripcion = '" + Descripcion.ToString + "', Auditoria = '" + Auditoria.ToString + "' WHERE id = " + id.ToString
            End If
        ElseIf Pantalla = "HiladoInterno" Then
            If Alta Then
                Mensaje = "Hilado Interno agregado"
                Auditoria = Environment.MachineName.ToString + " - Alta | " + Now.ToString
                sStr = "INSERT INTO HilamarHiladosInternos (Codigo, Descripcion, Eliminado, Auditoria) VALUES ('" + txtCodigo.Text + "', '" + Descripcion.ToString + "', 0, '" + Auditoria.ToString + "')"
            Else
                Mensaje = "Hilado Interno modificado"
                Auditoria = Environment.MachineName.ToString + " - Modificación | " + Now.ToString
                sStr = "UPDATE HilamarHiladosInternos SET Descripcion = '" + Descripcion.ToString + "', Auditoria = '" + Auditoria.ToString + "' WHERE id = " + id.ToString
            End If
        ElseIf Pantalla = "MateriasPrimas" Then
            If Alta Then
                Mensaje = "Materia prima agregada"
                Auditoria = Environment.MachineName.ToString + " - Alta de Materia Prima | " + Now.ToString
                sStr = "INSERT INTO HilamarMateriasPrimas (Descripcion, Eliminado, Auditoria) VALUES ('" + Descripcion.ToString + "', 0, '" + Auditoria.ToString + "')"
            Else
                Mensaje = "Materia prima modificada"
                Auditoria = Environment.MachineName.ToString + " - Modificación de Materia Prima | " + Now.ToString
                sStr = "UPDATE HilamarMateriasPrimas SET Descripcion = '" + Descripcion.ToString + "', Auditoria = '" + Auditoria.ToString + "' WHERE id = " + id.ToString
            End If
        ElseIf Pantalla = "Procesos" Then
            If Alta Then
                Mensaje = "Proceso agregado"
                Auditoria = Environment.MachineName.ToString + " - Alta de Proceso | " + Now.ToString
                sStr = "INSERT INTO HilamarProcesos (Descripcion, Eliminado, Auditoria) VALUES ('" + Descripcion.ToString + "', 0, '" + Auditoria.ToString + "')"
            Else
                Mensaje = "Proceso modificado"
                Auditoria = Environment.MachineName.ToString + " - Modificación de Proceso | " + Now.ToString
                sStr = "UPDATE HilamarProcesos SET Descripcion = '" + Descripcion.ToString + "', Auditoria = '" + Auditoria.ToString + "' WHERE id = " + id.ToString
            End If
        ElseIf Pantalla = "TipoMovimientos" Then
            If Alta Then
                Mensaje = "Tipo de movimiento agregado"
                Auditoria = Environment.MachineName.ToString + " - Alta de Tipo de Movimiento | " + Now.ToString
                sStr = "INSERT INTO HilamarTipoMovimientos (Codigo, Descripcion, Eliminado, Auditoria) VALUES ('" + txtCodigo.Text + "', '" + Descripcion.ToString + "', 0, '" + Auditoria.ToString + "')"
            Else
                Mensaje = "Tipo de movimiento modificado"
                Auditoria = Environment.MachineName.ToString + " - Modificación de Tipo de Movimientos | " + Now.ToString
                sStr = "UPDATE HilamarTipoMovimientos SET Descripcion = '" + Descripcion.ToString + "', Auditoria = '" + Auditoria.ToString + "' WHERE id = " + id.ToString
            End If

        End If
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        Mensaje = Mensaje + " correctamente."
        MensajeAtencion(Mensaje)

        Me.Close()
    End Sub

    Private Sub txtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then txtDescripcion.Select()
    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescripcion.KeyDown
        If e.KeyCode = Keys.Enter Then btnAceptar.Select()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class