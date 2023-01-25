Imports System.Data.SqlClient

Public Class frmABMMaquinas
    Private Command As New SqlCommand
    Private Reader As SqlDataReader
    Dim sStr As String

    Dim IdMaquina As String
    Dim NombreMaquina As String ' creo una global para resguardar el nombre de la maquina y saber si cuando entra a modificar lo cambia o no para validarlo

    Dim ColSectoresAgregar, ColSectoresEditar As New Collection

    Private Sub CargarListadoDeMaquinas()
        Dim row() As String

        LimpiarDGV()
        ArmarDGV()

        sStr = "SELECT M.Id as IdMaq,* FROM HilaManteMaquinas M INNER JOIN HilaManteSectores S ON M.IdSector = S.Id WHERE M.Eliminado=0 "
        sStr = sStr + " and M.Nombre like '%" + txtBuscar.Text + "%' and S.Sector like '%" + txtSector.Text + "%' "
        If rbOrdenMaquina.Checked Then
            sStr = sStr + " order by Nombre,S.Fabrica,S.Sector"
        Else
            sStr = sStr + " order by S.Fabrica,S.Sector,Nombre"
        End If
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                row = {Reader.Item("IdMaq"), Strings.Left(Reader.Item("Fabrica"), 3) + "-" + Reader.Item("Sector"), Reader.Item("Nombre"), Reader.Item("IdSector"), Reader.Item("Observaciones")}
                dgvMaquinas.Rows.Add(row)
            Loop
            Reader.NextResult()
        Loop

        'cuando cargo o recargo el listado limpio el IdMaquina para que no quede con valores viejos
        IdMaquina = ""
        NombreMaquina = ""
    End Sub

    Private Sub CargarListadeSectores()
        cmbSectoresAgregar.Items.Clear()
        ColSectoresAgregar.Clear()
        cmbSectoresEditar.Items.Clear()
        ColSectoresEditar.Clear()

        sStr = "SELECT * FROM HilaManteSectores WHERE Eliminado=0 order by Sector"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                cmbSectoresAgregar.Items.Add(Reader.Item("Sector").ToString + "-" + Strings.Left(Reader.Item("Fabrica").ToString, 3))
                ColSectoresAgregar.Add(Reader.Item("Id").ToString, Reader.Item("Sector").ToString + "-" + Strings.Left(Reader.Item("Fabrica").ToString, 3))
                cmbSectoresEditar.Items.Add(Reader.Item("Sector").ToString + "-" + Strings.Left(Reader.Item("Fabrica").ToString, 3))
                ColSectoresEditar.Add(Reader.Item("Id").ToString, Reader.Item("Sector").ToString + "-" + Strings.Left(Reader.Item("Fabrica").ToString, 3))
            Loop
            Reader.NextResult()
        Loop

    End Sub

    Private Sub LimpiarDGV()
        dgvMaquinas.Rows.Clear()
        dgvMaquinas.Columns.Clear()
    End Sub

    Private Sub ArmarDGV()
        dgvMaquinas.Columns.Add("ID", "ID")
        dgvMaquinas.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvMaquinas.Columns("ID").Visible = False
        dgvMaquinas.Columns.Add("SECTOR", "SECTOR")
        dgvMaquinas.Columns("SECTOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvMaquinas.Columns("SECTOR").Width = 140
        dgvMaquinas.Columns.Add("MAQUINA", "MAQUINA")
        dgvMaquinas.Columns("MAQUINA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvMaquinas.Columns("MAQUINA").Width = 310
        dgvMaquinas.Columns.Add("IDSECTOR", "IDSECTOR")
        dgvMaquinas.Columns("IDSECTOR").Visible = False
        dgvMaquinas.Columns.Add("OBSERVACIONES", "OBSERVACIONES")
        dgvMaquinas.Columns("OBSERVACIONES").Visible = False

        dgvMaquinas.Font = New Font("Arial", 10)

    End Sub

    Private Function Validar(ByVal NombMaquina As String, ByVal CodSector As String, ByVal TipoMov As String) As Boolean
        On Error GoTo ErrValidar

        If NombMaquina = "" Then
            MensajeCritico("El nombre de la Máquina no puede estar vacío")
            Validar = False
            Exit Function
        End If

        If TipoMov = "ALTA" Then
            If cmbSectoresAgregar.Text = "" Then
                MensajeCritico("La Máquina debe tener un sector asignado.")
                Validar = False
                Exit Function
            End If
            sStr = "SELECT count(*) as Cantidad FROM HilaManteMaquinas WHERE Nombre = '" + NombMaquina + "' and IdSector=" + CodSector + " and Eliminado=0 "
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read() Then
                    If Reader.Item("Cantidad") > 0 Then
                        MensajeCritico("El nombre de la Màquina ya existe en ese Sector, verifique.")
                        Validar = False
                        Exit Function
                    End If
                End If
            End If
        ElseIf TipoMov = "MODIFICA" Then
            If cmbSectoresEditar.Text = "" Then
                MensajeCritico("La Máquina debe tener un sector asignado.")
                Validar = False
                Exit Function
            End If
            If NombreMaquina <> NombMaquina Then
                sStr = "SELECT count(*) as Cantidad FROM HilaManteMaquinas WHERE Nombre = '" + NombMaquina + "' and IdSector=" + CodSector + " and Eliminado=0 "
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Reader = Command.ExecuteReader()
                If Reader.HasRows Then
                    If Reader.Read() Then
                        If Reader.Item("Cantidad") > 0 Then
                            MensajeCritico("El nombre de la Màquina ya existe en ese Sector, verifique.")
                            Validar = False
                            Exit Function
                        End If
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

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub frmABMRubros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gbAgregarMaquina.Top = 29
        gbAgregarMaquina.Left = 654
        gbModificarMaquina.Top = 29
        gbModificarMaquina.Left = 654
        CargarListadoDeMaquinas()
        CargarListadeSectores()
        HabilitoListado()
    End Sub

    Private Sub Deshabilitolistado()
        txtBuscar.Enabled = False
        dgvMaquinas.Enabled = False
        gbOrden.Enabled = False
        btnAgregar.Enabled = False
        btnEditar.Enabled = False
        btnEliminar.Enabled = False
        Me.Width = 1148
        Me.CenterToScreen()
    End Sub
    Private Sub HabilitoListado()
        Me.Width = 670
        Me.CenterToScreen()
        txtBuscar.Enabled = True
        dgvMaquinas.Enabled = True
        gbOrden.Enabled = True
        btnAgregar.Enabled = True
        btnEditar.Enabled = True
        btnEliminar.Enabled = True
        gbAgregarMaquina.Visible = False
        gbModificarMaquina.Visible = False
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            CargarListadoDeMaquinas()
        End If
    End Sub

    Private Sub txtSector_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSector.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            CargarListadoDeMaquinas()
        End If
    End Sub

    '*************agregar una maquina****************************************
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        DeshabilitoListado()
        gbAgregarMaquina.Visible = True
        txtAgregarMaquina.Select()
    End Sub

    Private Sub btnOkAgregarMaquina_Click(sender As Object, e As EventArgs) Handles btnOkAgregarMaquina.Click
        If Not Validar(txtAgregarMaquina.Text, ColSectoresAgregar.Item(cmbSectoresAgregar.Text), "ALTA") Then Exit Sub

        sStr = "INSERT INTO HilaManteMaquinas (Nombre,Observaciones,IdSector,Eliminado) VALUES ('" + txtAgregarMaquina.Text + "','" + txtAgregarObservacion.Text + "'," + ColSectoresAgregar.Item(cmbSectoresAgregar.Text) + ",0)"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        MensajeInfo("Máquina Agregada Correctamente.")
        txtAgregarMaquina.Text = ""
        txtAgregarObservacion.Text = ""
        HabilitoListado()
        CargarListadoDeMaquinas()
    End Sub

    Private Sub btnCancelarAgregarMaquina_Click(sender As Object, e As EventArgs) Handles btnCancelarAgregarMaquina.Click
        txtAgregarMaquina.Text = ""
        HabilitoListado()
    End Sub

    '*****************editar una maquina**************************
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim Spli As String()
        If dgvMaquinas.SelectedRows.Count <> 1 Then
            MensajeAtencion("Debe seleccionar una Máquina para modificarla")
            Exit Sub
        End If
        IdMaquina = dgvMaquinas.Rows(dgvMaquinas.CurrentRow.Index).Cells("ID").Value.ToString
        NombreMaquina = dgvMaquinas.Rows(dgvMaquinas.CurrentRow.Index).Cells("MAQUINA").Value.ToString
        txtEditarMaquina.Text = dgvMaquinas.Rows(dgvMaquinas.CurrentRow.Index).Cells("MAQUINA").Value.ToString
        Spli = dgvMaquinas.Rows(dgvMaquinas.CurrentRow.Index).Cells("SECTOR").Value.ToString.Split("-")
        cmbSectoresEditar.Text = Spli(1) + "-" + Spli(0)
        txtEditarObservacion.Text = dgvMaquinas.Rows(dgvMaquinas.CurrentRow.Index).Cells("OBSERVACIONES").Value.ToString
        Deshabilitolistado()
        gbModificarMaquina.Visible = True
        txtEditarMaquina.Select()
    End Sub

    Private Sub btnCancelarEditarMaquina_Click(sender As Object, e As EventArgs) Handles btnCancelarEditarMaquina.Click
        txtEditarMaquina.Text = ""
        HabilitoListado()
    End Sub

    Private Sub btnOkEditarMaquina_Click(sender As Object, e As EventArgs) Handles btnOkEditarMaquina.Click
        If Not Validar(txtEditarMaquina.Text, ColSectoresEditar.Item(cmbSectoresEditar.Text), "MODIFICA") Then Exit Sub

        sStr = "UPDATE HilaManteMaquinas SET Nombre ='" + txtEditarMaquina.Text + "' "
        sStr = sStr + " ,Observaciones='" + txtEditarObservacion.Text + "' "
        sStr = sStr + " ,IdSector= " + ColSectoresEditar.Item(cmbSectoresEditar.Text) + " "
        sStr = sStr + "WHERE Id = " + IdMaquina
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        MensajeInfo("Máquina Modificada Correctamente.")
        txtEditarMaquina.Text = ""
        txtEditarObservacion.Text = ""
        CargarListadoDeMaquinas()
        HabilitoListado()
    End Sub

    '*****************Eliminar una maquina**************************
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dgvMaquinas.SelectedRows.Count <> 1 Then
            MensajeAtencion("Debe seleccionar una máquina para Eliminarla")
            Exit Sub
        End If
        Dim respuesta As Integer
        respuesta = MsgBox("Al eliminar la máquina se la quita de todas las ordenes de reparación a las que fue asignado y esas ordenes deberán ser reasignadas." + _
                           Chr(10) + Chr(10) + "Confirma la eliminación de la máquina:" + dgvMaquinas.Rows(dgvMaquinas.CurrentRow.Index).Cells("MAQUINA").Value.ToString + " ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Confirmar borrado.")
        If respuesta = vbNo Then Exit Sub

        'sStr = "UPDATE MantOrdenCompraEnc SET CodRubro=NULL WHERE CodRubro=" + dgvMaquinas.Rows(dgvMaquinas.CurrentRow.Index).Cells("ID").Value.ToString
        'Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        'Command.ExecuteNonQuery()

        sStr = "UPDATE HilaManteMaquinas SET Eliminado=1 WHERE Id=" + dgvMaquinas.Rows(dgvMaquinas.CurrentRow.Index).Cells("ID").Value.ToString
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        IdMaquina = ""
        NombreMaquina = ""

        MensajeInfo("Máquina Eliminada Correctamente")
        CargarListadoDeMaquinas()

    End Sub

    Private Sub rbOrdenMaquina_CheckedChanged(sender As Object, e As EventArgs) Handles rbOrdenMaquina.CheckedChanged
        CargarListadoDeMaquinas()
    End Sub

    Private Sub rbOrdenSector_CheckedChanged(sender As Object, e As EventArgs) Handles rbOrdenSector.CheckedChanged
        CargarListadoDeMaquinas()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged

    End Sub


    Private Sub txtSector_TextChanged(sender As Object, e As EventArgs) Handles txtSector.TextChanged

    End Sub
End Class