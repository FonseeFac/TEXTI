Imports System.Data.SqlClient

Public Class frmABMSectores
    Private Command As New SqlCommand
    Private Reader As SqlDataReader
    Dim sStr As String

    Dim IdSector As String
    Dim NombreSector As String ' creo una global para resguardar el nombre del sector y saber si cuando entra a modificar lo cambia o no para validarlo

    Private Sub CargarListadoDeSectores()
        Dim row() As String

        LimpiarDGV()
        ArmarDGV()

        sStr = "SELECT * FROM HilaManteSectores WHERE Eliminado=0 and Sector like '%" + txtBuscar.Text + "%' order by Sector"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                row = {Reader.Item("Id"), Reader.Item("Sector"), Reader.Item("Fabrica")}
                dgvSectores.Rows.Add(row)
            Loop
            Reader.NextResult()
        Loop

        'cuando cargo o recargo el listado limpio el IdSector para que no quede con valores viejos
        IdSector = ""
        NombreSector = ""
    End Sub

    Private Sub LimpiarDGV()
        dgvSectores.Rows.Clear()
        dgvSectores.Columns.Clear()
    End Sub

    Private Sub ArmarDGV()
        dgvSectores.Columns.Add("ID", "ID")
        dgvSectores.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvSectores.Columns("ID").Visible = False
        dgvSectores.Columns.Add("SECTOR", "SECTOR")
        dgvSectores.Columns("SECTOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvSectores.Columns("SECTOR").Width = 180
        dgvSectores.Columns.Add("FABRICA", "FABRICA")
        dgvSectores.Columns("FABRICA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvSectores.Columns("FABRICA").Width = 90

        dgvSectores.Font = New Font("Arial", 10)

    End Sub

    Private Function Validar(ByVal NombSector As String, ByVal FabSector As String, ByVal TipoMov As String) As Boolean
        On Error GoTo ErrValidar

        If NombSector = "" Then
            MensajeCritico("El nombre del Sector no puede estar vacío")
            Validar = False
            Exit Function
        End If

        If TipoMov = "BAJA" Then
            'en el control de validacion del borrado uso la variable donde va el nombre para que me pasen el id del sector
            sStr = "SELECT count(*) as Cantidad FROM HilaManteMaquinas WHERE IdSector = " + NombSector + " and Eliminado=0 "
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read() Then
                    If Reader.Item("Cantidad") > 0 Then
                        MensajeCritico("El Sector tiene asignadas máquinas, para poder eliminar el Sector primero debe reasignar las máquinas a otro sector. Verifique.")
                        Validar = False
                        Exit Function
                    End If
                End If
            End If
        Else
            If FabSector = "" Then
                MensajeCritico("El Sector debe tener una fábrica asignada.")
                Validar = False
                Exit Function
            End If
        End If

        If NombreSector <> NombSector Then
            sStr = "SELECT count(*) as Cantidad FROM HilaManteSectores WHERE Sector = '" + NombSector + "' and Fabrica = '" + FabSector + "' and Eliminado=0 "
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read() Then
                    If Reader.Item("Cantidad") > 0 Then
                        MensajeCritico("El nombre del Sector ya existe, verifique.")
                        Validar = False
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

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub frmABMSectores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gbAgregarSector.Top = 29
        gbAgregarSector.Left = 488
        gbModificarSector.Top = 29
        gbModificarSector.Left = 488
        CargarListadoDeSectores()
        HabilitoListado()
    End Sub

    Private Sub Deshabilitolistado()
        txtBuscar.Enabled = False
        dgvSectores.Enabled = False
        btnAgregar.Enabled = False
        btnEditar.Enabled = False
        btnEliminar.Enabled = False
        Me.Width = 850
        Me.CenterToScreen()
    End Sub
    Private Sub HabilitoListado()
        Me.Width = 500
        Me.CenterToScreen()
        txtBuscar.Enabled = True
        dgvSectores.Enabled = True
        btnAgregar.Enabled = True
        btnEditar.Enabled = True
        btnEliminar.Enabled = True
        gbAgregarSector.Visible = False
        gbModificarSector.Visible = False
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            CargarListadoDeSectores()
        End If
    End Sub

    '*************agregar un sector****************************************
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        DeshabilitoListado()
        gbAgregarSector.Visible = True
        txtAgregarSector.Select()
    End Sub

    Private Sub btnOkAgregarRubro_Click(sender As Object, e As EventArgs) Handles btnOkAgregarSector.Click
        If Not Validar(txtAgregarSector.Text, cmbAgregarFabrica.Text, "ALTA") Then Exit Sub

        sStr = "INSERT INTO HilaManteSectores (Sector,Eliminado,Fabrica) VALUES ('" + txtAgregarSector.Text + "',0,'" + cmbAgregarFabrica.Text + "')"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        MensajeInfo("Sector Agregado Correctamente")
        txtAgregarSector.Text = ""
        CargarListadoDeSectores()
        HabilitoListado()
    End Sub

    Private Sub btnCancelarAgregarRubro_Click(sender As Object, e As EventArgs) Handles btnCancelarAgregarSector.Click
        txtAgregarSector.Text = ""
        HabilitoListado()
    End Sub

    '*****************editar un sector**************************
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If dgvSectores.SelectedRows.Count <> 1 Then
            MensajeAtencion("Debe seleccionar un rubro para modificarlo")
            Exit Sub
        End If
        IdSector = dgvSectores.Rows(dgvSectores.CurrentRow.Index).Cells("ID").Value.ToString
        NombreSector = dgvSectores.Rows(dgvSectores.CurrentRow.Index).Cells("SECTOR").Value.ToString
        txtEditarSector.Text = dgvSectores.Rows(dgvSectores.CurrentRow.Index).Cells("SECTOR").Value.ToString
        cmbEditarFabrica.Text = dgvSectores.Rows(dgvSectores.CurrentRow.Index).Cells("FABRICA").Value.ToString
        Deshabilitolistado()
        gbModificarSector.Visible = True
        txtEditarSector.Select()
    End Sub

    Private Sub btnCancelarEditarRubro_Click(sender As Object, e As EventArgs) Handles btnCancelarEditarSector.Click
        txtEditarSector.Text = ""
        HabilitoListado()
    End Sub

    Private Sub btnOkEditarRubro_Click(sender As Object, e As EventArgs) Handles btnOkEditarSector.Click
        If Not Validar(txtEditarSector.Text, cmbEditarFabrica.Text, "MODIFICA") Then Exit Sub

        sStr = "UPDATE HilaManteSectores SET Sector ='" + txtEditarSector.Text + "' "
        sStr = sStr + ",Fabrica = '" + cmbEditarFabrica.Text + "' "
        sStr = sStr + "WHERE Id = " + IdSector
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        MensajeInfo("Sector Modificado Correctamente")
        CargarListadoDeSectores()
        HabilitoListado()
    End Sub

    '*****************Eliminar un sector**************************
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dgvSectores.SelectedRows.Count <> 1 Then
            MensajeAtencion("Debe seleccionar un Sector para Eliminarlo")
            Exit Sub
        End If

        If Not Validar(dgvSectores.Rows(dgvSectores.CurrentRow.Index).Cells("ID").Value.ToString, "", "BAJA") Then Exit Sub

        sStr = "UPDATE HilaManteSectores SET Eliminado=1 WHERE Id=" + dgvSectores.Rows(dgvSectores.CurrentRow.Index).Cells("ID").Value.ToString
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        IdSector = ""
        NombreSector = ""

        MensajeInfo("Sector Eliminado Correctamente")
        CargarListadoDeSectores()

    End Sub


End Class