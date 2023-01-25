Imports System.Data.SqlClient

Public Class frmABMUsuariosTablet
    Dim IdUsuario As String

    Dim ColSectoresAgregar, ColSectoresEditar As New Collection

    Private Sub frmABMUsuariosTablet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gbAgregarUsuario.Top = 43
        gbAgregarUsuario.Left = 661
        gbEditarUsuario.Top = 43
        gbEditarUsuario.Left = 661
        CargarListadoDeUsuarios()
        HabilitoListado()
    End Sub

    Private Sub CargarListadeSectoresDelUsuario(ByVal NroLegajo As String)
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        lsbAgregarSectores.Items.Clear()
        ColSectoresAgregar.Clear()
        lsbEditarSectores.Items.Clear()
        ColSectoresEditar.Clear()

        sStr = " select Id as IdSector,Sector,Fabrica,dato from "
        sStr = sStr + " ( "
        sStr = sStr + " select * from HilaManteSectores as A "
        sStr = sStr + " left outer join "
        sStr = sStr + " ( "
        sStr = sStr + " select ID as dato,idSector from HilaManteUsuariosTabletSectores"
        sStr = sStr + " where NroLegajo = '" + NroLegajo + "' ) as B "
        sStr = sStr + " on A.id=B.idSector "
        sStr = sStr + " ) as C  "

        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                If IsDBNull(Reader.Item("dato")) Then
                    lsbAgregarSectores.Items.Add(Reader.Item("Sector").ToString + "-" + Strings.Left(Reader.Item("Fabrica").ToString, 3), False)
                    ColSectoresAgregar.Add(Reader.Item("IdSector").ToString, Reader.Item("Sector").ToString + "-" + Strings.Left(Reader.Item("Fabrica").ToString, 3))
                    lsbEditarSectores.Items.Add(Reader.Item("Sector").ToString + "-" + Strings.Left(Reader.Item("Fabrica").ToString, 3), False)
                    ColSectoresEditar.Add(Reader.Item("IdSector").ToString, Reader.Item("Sector").ToString + "-" + Strings.Left(Reader.Item("Fabrica").ToString, 3))
                Else
                    lsbAgregarSectores.Items.Add(Reader.Item("Sector").ToString + "-" + Strings.Left(Reader.Item("Fabrica").ToString, 3), True)
                    ColSectoresAgregar.Add(Reader.Item("IdSector").ToString, Reader.Item("Sector").ToString + "-" + Strings.Left(Reader.Item("Fabrica").ToString, 3))
                    lsbEditarSectores.Items.Add(Reader.Item("Sector").ToString + "-" + Strings.Left(Reader.Item("Fabrica").ToString, 3), True)
                    ColSectoresEditar.Add(Reader.Item("IdSector").ToString, Reader.Item("Sector").ToString + "-" + Strings.Left(Reader.Item("Fabrica").ToString, 3))
                End If
            Loop
            Reader.NextResult()
        Loop
    End Sub

    Private Sub CargarListadoDeUsuarios()
        Dim Command, CommandSec As New SqlCommand
        Dim Reader, ReaderSec As SqlDataReader
        Dim sStr, sStrSec As String
        Dim row() As String
        Dim ListaDeSectores As String

        LimpiarDGV()
        ArmarDGV()

        sStr = "SELECT U.Id,NroLegajo,U.Password,Right(LegNombre,LEN(LegNombre)-9) as NOMBRE "
        sStr = sStr + " FROM HilaManteUsuariosTablet U INNER JOIN Principal.dbo.T_Legajos PL ON U.NroLEgajo =PL.legLegajo collate Modern_Spanish_CI_AS "
        sStr = sStr + " WHERE isnull(U.Eliminado,0)=0 AND LegNombre like '%" + txtBuscar.Text + "%' "
        sStr = sStr + " ORDER BY Nombre"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                ListaDeSectores = ""
                sStrSec = "SELECT * "
                sStrSec = sStrSec + " FROM HilaManteUsuariosTabletSectores U INNER JOIN HilaManteSectores S ON U.IdSector =S.Id "
                sStrSec = sStrSec + " WHERE U.NroLegajo='" + Reader.Item("NroLegajo").ToString + "' "
                CommandSec = New SqlCommand(sStrSec, cConexionApp.SQLConn)
                ReaderSec = CommandSec.ExecuteReader()
                Do While ReaderSec.HasRows
                    Do While ReaderSec.Read()
                        ListaDeSectores = ListaDeSectores + ReaderSec.Item("Sector") + "-" + Strings.Left(ReaderSec.Item("Fabrica"), 3) + Chr(10)
                    Loop
                    ReaderSec.NextResult()
                Loop
                If ListaDeSectores.Length > 0 Then ListaDeSectores = Strings.Left(ListaDeSectores, ListaDeSectores.Length - 1)

                row = {Reader.Item("Id"), Reader.Item("NroLegajo"), Reader.Item("Nombre"), Reader.Item("Password"), ListaDeSectores}
                dgvUsuarios.Rows.Add(row)
            Loop
            Reader.NextResult()
        Loop

        'cuando cargo o recargo el listado limpio el IdUsuario para que no quede con valores viejos
        IdUsuario = ""
    End Sub

    Private Sub LimpiarDGV()
        dgvUsuarios.Rows.Clear()
        dgvUsuarios.Columns.Clear()
    End Sub

    Private Sub ArmarDGV()
        dgvUsuarios.Columns.Add("ID", "ID")
        dgvUsuarios.Columns("ID").Visible = False
        dgvUsuarios.Columns.Add("NROLEGAJO", "LEGAJO")
        dgvUsuarios.Columns("NROLEGAJO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvUsuarios.Columns("NROLEGAJO").Width = 75
        dgvUsuarios.Columns.Add("NOMBRE", "NOMBRE")
        dgvUsuarios.Columns("NOMBRE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvUsuarios.Columns("NOMBRE").Width = 230
        dgvUsuarios.Columns.Add("PASSWORD", "PASSWORD")
        dgvUsuarios.Columns("PASSWORD").Visible = False
        dgvUsuarios.Columns.Add("SECTOR", "SECTORES")
        dgvUsuarios.Columns("SECTOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgvUsuarios.Columns("SECTOR").Width = 160
        dgvUsuarios.Columns("SECTOR").DefaultCellStyle.WrapMode = DataGridViewTriState.True

        dgvUsuarios.Font = New Font("Arial", 10)
        dgvUsuarios.RowTemplate.Height = 45
    End Sub

    Private Sub Deshabilitolistado()
        txtBuscar.Enabled = False
        dgvUsuarios.Enabled = False
        btnAgregar.Enabled = False
        btnEditar.Enabled = False
        btnEliminar.Enabled = False
        Me.Width = 1036
        Me.CenterToScreen()
    End Sub
    Private Sub HabilitoListado()
        Me.Width = 677
        Me.CenterToScreen()
        txtBuscar.Enabled = True
        dgvUsuarios.Enabled = True
        btnAgregar.Enabled = True
        btnEditar.Enabled = True
        btnEliminar.Enabled = True
        gbAgregarUsuario.Visible = False
        gbEditarUsuario.Visible = False
    End Sub

    Private Sub txtBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBuscar.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            CargarListadoDeUsuarios()
        End If
    End Sub

    '*************agregar un usuario****************************************
    Private Sub txtAgregarLegajo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAgregarLegajo.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            txtAgregarContraseña.Select()
        End If
    End Sub

    Private Sub txtAgregarLegajo_LostFocus(sender As Object, e As EventArgs) Handles txtAgregarLegajo.LostFocus
        txtAgregarLegajo.Text = AcomodarLegajo(txtAgregarLegajo.Text, "A")
        txtAgregarNombre.Text = DescripcionLegajo(txtAgregarLegajo.Text)
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        DeshabilitoListado()
        CargarListadeSectoresDelUsuario("")
        gbAgregarUsuario.Visible = True
        txtAgregarLegajo.Select()
    End Sub

    Private Sub btnOkAgregarUsuario_Click(sender As Object, e As EventArgs) Handles btnOkAgregarUsuario.Click
        Dim Command As New SqlCommand
        Dim sStr As String
        Dim i As Integer

        If Not Validar(txtAgregarLegajo.Text, txtAgregarNombre.Text, "ALTA") Then Exit Sub

        sStr = "INSERT INTO HilaManteUsuariosTablet (NroLegajo,Password,Eliminado,Tipo) VALUES ('" + txtAgregarLegajo.Text + "','" + txtAgregarContraseña.Text + "',0,'MantEmp')"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        For i = 0 To lsbAgregarSectores.Items.Count - 1
            If lsbAgregarSectores.GetItemChecked(i) Then
                sStr = "INSERT INTO HilaManteUsuariosTabletSectores (NroLegajo,IdSector) VALUES ('" + _
                     txtAgregarLegajo.Text + "'," + ColSectoresAgregar.Item(lsbAgregarSectores.Items(i).ToString) + ")"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
            End If
        Next i

        MensajeInfo("Usuario Agregado Correctamente.")
        txtAgregarLegajo.Text = ""
        txtAgregarNombre.Text = ""
        txtAgregarContraseña.Text = ""
        HabilitoListado()
        CargarListadoDeUsuarios()
    End Sub

    Private Sub btnCancelarAgregarUsuario_Click(sender As Object, e As EventArgs) Handles btnCancelarAgregarUsuario.Click
        txtAgregarLegajo.Text = ""
        txtAgregarNombre.Text = ""
        txtAgregarContraseña.Text = ""
        HabilitoListado()
    End Sub

    '*****************editar un usuario**************************
    Private Sub txtEditarLegajo_LostFocus(sender As Object, e As EventArgs) Handles txtEditarLegajo.LostFocus
        txtEditarLegajo.Text = AcomodarLegajo(txtEditarLegajo.Text, "A")
        txtEditarNombre.Text = DescripcionLegajo(txtEditarLegajo.Text)
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If dgvUsuarios.SelectedRows.Count <> 1 Then
            MensajeAtencion("Debe seleccionar un Usuario para modificarlo")
            Exit Sub
        End If
        IdUsuario = dgvUsuarios.Rows(dgvUsuarios.CurrentRow.Index).Cells("ID").Value.ToString
        txtEditarLegajo.Text = dgvUsuarios.Rows(dgvUsuarios.CurrentRow.Index).Cells("NROLEGAJO").Value.ToString
        txtEditarNombre.Text = dgvUsuarios.Rows(dgvUsuarios.CurrentRow.Index).Cells("NOMBRE").Value.ToString
        CargarListadeSectoresDelUsuario(dgvUsuarios.Rows(dgvUsuarios.CurrentRow.Index).Cells("NROLEGAJO").Value.ToString)
        txtEditarContraseña.Text = dgvUsuarios.Rows(dgvUsuarios.CurrentRow.Index).Cells("PASSWORD").Value.ToString
        Deshabilitolistado()
        gbEditarUsuario.Visible = True
        txtEditarContraseña.Select()
    End Sub

    Private Sub btnCancelarEditarUsuario_Click(sender As Object, e As EventArgs) Handles btnCancelarEditarUsuario.Click
        txtEditarLegajo.Text = ""
        txtEditarNombre.Text = ""
        txtEditarContraseña.Text = ""
        HabilitoListado()
    End Sub

    Private Sub btnOkEditarUsuario_Click(sender As Object, e As EventArgs) Handles btnOkEditarUsuario.Click
        Dim Command As New SqlCommand
        Dim sStr As String

        If Not Validar(txtEditarLegajo.Text, txtEditarNombre.Text, "MODIFICA") Then Exit Sub

        sStr = "UPDATE HilaManteUsuariosTablet SET Password ='" + txtEditarContraseña.Text + "' WHERE Id = " + IdUsuario
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        sStr = "DELETE FROM HilaManteUsuariosTabletSectores WHERE NroLegajo='" + txtEditarLegajo.Text + "'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()
        For i = 0 To lsbEditarSectores.Items.Count - 1
            If lsbEditarSectores.GetItemChecked(i) Then
                sStr = "INSERT INTO HilaManteUsuariosTabletSectores (NroLegajo,IdSector) VALUES ('" + _
                     txtEditarLegajo.Text + "'," + ColSectoresEditar.Item(lsbEditarSectores.Items(i).ToString) + ")"
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Command.ExecuteNonQuery()
            End If
        Next i

        MensajeInfo("Usuario Modificado Correctamente.")
        txtEditarLegajo.Text = ""
        txtEditarNombre.Text = ""
        txtEditarContraseña.Text = ""
        HabilitoListado()
        CargarListadoDeUsuarios()
    End Sub

    '*****************Eliminar un usuario**************************
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim Command As New SqlCommand
        Dim sStr As String

        If dgvUsuarios.SelectedRows.Count <> 1 Then
            MensajeAtencion("Debe seleccionar un usuario para Eliminarlo")
            Exit Sub
        End If
        Dim respuesta As Integer
        respuesta = MsgBox("Confirma la eliminación del usuario:" + dgvUsuarios.Rows(dgvUsuarios.CurrentRow.Index).Cells("NOMBRE").Value.ToString + " ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Confirmar borrado.")
        If respuesta = vbNo Then Exit Sub

        'sStr = "UPDATE MantOrdenCompraEnc SET CodRubro=NULL WHERE CodRubro=" + dgvMaquinas.Rows(dgvMaquinas.CurrentRow.Index).Cells("ID").Value.ToString
        'Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        'Command.ExecuteNonQuery()

        sStr = "UPDATE HilaManteUsuariosTablet SET Eliminado=1 WHERE Id=" + dgvUsuarios.Rows(dgvUsuarios.CurrentRow.Index).Cells("ID").Value.ToString
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        IdUsuario = ""

        MensajeInfo("Usuario Eliminado Correctamente")
        CargarListadoDeUsuarios()

    End Sub

    Private Function Validar(ByVal NroLegajo As String, ByVal NombreLegajo As String, ByVal TipoMov As String) As Boolean
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String
        Dim i As Integer
        Dim HayAlgunoTildado As Boolean

        On Error GoTo ErrValidar

        If NroLegajo = "" Then
            MensajeCritico("El Nro de Legajo no puede estar vacío")
            Validar = False
            Exit Function
        End If

        If NombreLegajo = "" Then
            MensajeCritico("Debe ingresar un Legajo válido.")
            Validar = False
            Exit Function
        End If

        If TipoMov = "ALTA" Then
            HayAlgunoTildado = False
            For i = 0 To lsbAgregarSectores.Items.Count - 1
                If lsbAgregarSectores.GetItemChecked(i) Then
                    HayAlgunoTildado = True
                    Exit For
                End If
            Next i
            If Not HayAlgunoTildado Then
                MensajeCritico("El usuario debe tener al menos un sector asignado.")
                Validar = False
                Exit Function
            End If
            sStr = "SELECT count(*) as Cantidad FROM HilaManteUsuariosTablet WHERE NroLegajo = '" + NroLegajo + "' and Eliminado=0 "
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read() Then
                    If Reader.Item("Cantidad") > 0 Then
                        MensajeCritico("El Usuario ya existe, verifique.")
                        Validar = False
                        Exit Function
                    End If
                End If
            End If
        ElseIf TipoMov = "MODIFICA" Then
            HayAlgunoTildado = False
            For i = 0 To lsbEditarSectores.Items.Count - 1
                If lsbEditarSectores.GetItemChecked(i) Then
                    HayAlgunoTildado = True
                    Exit For
                End If
            Next i
            If Not HayAlgunoTildado Then
                MensajeCritico("El usuario debe tener al menos un sector asignado.")
                Validar = False
                Exit Function
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
End Class