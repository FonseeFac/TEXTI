Imports System.Data.SqlClient

Public Class frmABMOPs
    Public Alta As Boolean
    Public Id As String

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        'Guardar()
    End Sub

    Private Sub Guardar()
        On Error GoTo ErrGuardar
        Dim Reader As SqlDataReader
        Dim Command As New SqlCommand
        Dim sStr, Item As String

        Dim XXS, XS, S, M, L, XL, XXL As String

        Dim Auditoria As String

        If txtXXS.Text = "" Then
            XXS = "0"
        Else
            XXS = txtXXS.Text
        End If

        If txtXS.Text = "" Then
            XS = "0"
        Else
            XS = txtXS.Text
        End If

        If txtS.Text = "" Then
            S = "0"
        Else
            S = txtS.Text
        End If

        If txtM.Text = "" Then
            M = "0"
        Else
            M = txtM.Text
        End If

        If txtL.Text = "" Then
            L = "0"
        Else
            L = txtL.Text
        End If

        If txtXL.Text = "" Then
            XL = "0"
        Else
            XL = txtXL.Text
        End If

        If txtXXL.Text = "" Then
            XXL = "0"
        Else
            XXL = txtXXL.Text
        End If

        If txtTotal.Text = "" Then
            txtTotal.Text = CalculoTotalTalles()
        End If

        If Not Validar() Then Exit Sub

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = ""
        If Alta Then
            Auditoria = "Alta | " + Now.ToString
            sStr = "INSERT INTO ProdArticulosOP (OP, CodArticulo, Auditoria, Eliminado, XXS, XS, S, M, L, XL, XXL, Total, Fecha)"
            sStr = sStr + " VALUES (" + txtOP.Text + ", '" + txtCodArticulo.Text + "','" + Auditoria + "',0," + XXS + "," + XS + "," + S + "," + M
            sStr = sStr + "," + L + "," + XL + "," + XXL + "," + txtTotal.Text + ",'" + Format(dtpFecha.Value, "yyyyMMdd") + "')"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()
            'luego de agregarla agarro el id para que me quede listo para modificar esa misma OP en la misma ventana
            'por ahora trabaja de esta forma, luego vemos si al grabar directamente cierra la ventana y si quieren modificar la tendran 
            'que seleccionar y pedir su modificacion desde el listado
            sStr = "SELECT Id FROM ProdArticulosOP WHERE OP = " + txtOP.Text + ""
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read() Then
                    Id = Reader.Item("Id").ToString
                End If
            End If

            MensajeInfo("Orden de Producción " + txtOP.Text + " agregada correctamente.")
            Alta = False
        Else
            Auditoria = "Modif | " + Now.ToString
            sStr = "UPDATE ProdArticulosOP SET CodArticulo = '" + txtCodArticulo.Text + "' "
            sStr = sStr + " ,Auditoria = '" + Auditoria + "' "
            sStr = sStr + " ,XXS = " + XXS
            sStr = sStr + " ,XS = " + XS
            sStr = sStr + " ,S = " + S
            sStr = sStr + " ,M = " + M
            sStr = sStr + " ,L = " + L
            sStr = sStr + " ,XL = " + XL
            sStr = sStr + " ,XXL = " + XXL
            sStr = sStr + " ,Total = " + txtTotal.Text + ""
            sStr = sStr + " ,Fecha = '" + Format(dtpFecha.Value, "yyyyMMdd") + "'"
            sStr = sStr + " WHERE Id = " + Id + ""
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()

            MensajeInfo("Orden de Producción " + txtOP.Text + " modificada correctamente.")
        End If

        Exit Sub
ErrGuardar:
        MensajeCritico("Error al guardar la OP.")
    End Sub

    Private Function CalculoTotalTalles() As Integer
        Dim total As Integer = 0
        If txtXXS.Text <> "" Then total = total + CInt(txtXXS.Text)
        If txtXS.Text <> "" Then total = total + CInt(txtXS.Text)
        If txtS.Text <> "" Then total = total + CInt(txtS.Text)
        If txtM.Text <> "" Then total = total + CInt(txtM.Text)
        If txtL.Text <> "" Then total = total + CInt(txtL.Text)
        If txtXL.Text <> "" Then total = total + CInt(txtXL.Text)
        If txtXXL.Text <> "" Then total = total + CInt(txtXXL.Text)
        CalculoTotalTalles = total
    End Function

    Private Function Validar() As Boolean
        On Error GoTo ErrValidar
        Dim Reader As SqlDataReader
        Dim Command As New SqlCommand
        Dim sStr As String

        If txtOP.Text = "" Then
            Validar = False
            MensajeAtencion("Debe ingresar un número de orden de producción.")
            Exit Function
        End If

        If Not IsNumeric(txtOP.Text) Then
            Validar = False
            MensajeAtencion("El número de orden de producción debe ser numérico.")
            Exit Function
        End If

        If txtCodArticulo.Text = "" Then
            Validar = False
            MensajeAtencion("Debe ingresar un código de artículo.")
            Exit Function
        End If

        If Not IsNumeric(txtCodArticulo.Text) Then
            Validar = False
            MensajeAtencion("El código de artículo debe ser numérico.")
            Exit Function
        End If

        If txtXXS.Text <> "" Then
            If Not IsNumeric(txtXXS.Text) Then
                Validar = False
                MensajeAtencion("La cantidad del talle XXS debe ser numérico.")
                Exit Function
            End If
        End If

        If txtXS.Text <> "" Then
            If Not IsNumeric(txtXS.Text) Then
                Validar = False
                MensajeAtencion("La cantidad del talle XS debe ser numérico.")
                Exit Function
            End If
        End If

        If txtS.Text <> "" Then
            If Not IsNumeric(txtS.Text) Then
                Validar = False
                MensajeAtencion("La cantidad del talle S debe ser numérico.")
                Exit Function
            End If
        End If

        If txtM.Text <> "" Then
            If Not IsNumeric(txtM.Text) Then
                Validar = False
                MensajeAtencion("La cantidad del talle M debe ser numérico.")
                Exit Function
            End If
        End If

        If txtL.Text <> "" Then
            If Not IsNumeric(txtL.Text) Then
                Validar = False
                MensajeAtencion("La cantidad del talle L debe ser numérico.")
                Exit Function
            End If
        End If

        If txtXL.Text <> "" Then
            If Not IsNumeric(txtXL.Text) Then
                Validar = False
                MensajeAtencion("La cantidad del talle XL debe ser numérico.")
                Exit Function
            End If
        End If

        If txtXXL.Text <> "" Then
            If Not IsNumeric(txtXXL.Text) Then
                Validar = False
                MensajeAtencion("La cantidad del talle XXL debe ser numérico.")
                Exit Function
            End If
        End If

        If Alta Then
            If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
            sStr = "SELECT * FROM ProdArticulosOP WHERE OP = " + CInt(txtOP.Text).ToString + " AND Eliminado = 0"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read Then
                    If MsgBox("La última OP " + txtOP.Text + " tiene fecha '" + FechaWin10(Reader.Item("Fecha")).ToString + ". ¿Desea agregar la nueva OP?", vbYesNo, "Textilana S. A.") = vbNo Then
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


    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Close()
    End Sub

    Public Sub Cargar()
        On Error GoTo ErrCargar
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String

        If Alta Then
            cmdObtenerNroOP.Visible = True
            cmdBorrarOPsAntiguas.Visible = True
            txtCodArticulo.Select()
        Else
            cmdObtenerNroOP.Visible = False
            cmdBorrarOPsAntiguas.Visible = False
            If Id <> "" Then

                If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
                sStr = "SELECT * FROM ProdArticulosOP WHERE Eliminado=0 and Id = " + Id
                Command = New SqlCommand(sStr, cConexionApp.SQLConn)
                Reader = Command.ExecuteReader()
                If Reader.HasRows Then
                    If Reader.Read() Then
                        txtOP.Text = Reader.Item("OP")
                        txtCodArticulo.Text = Reader.Item("CodArticulo").ToString
                        txtXXS.Text = Reader.Item("XXS")
                        txtXS.Text = Reader.Item("XS")
                        txtS.Text = Reader.Item("S")
                        txtM.Text = Reader.Item("M")
                        txtL.Text = Reader.Item("L")
                        txtXL.Text = Reader.Item("XL")
                        txtXXL.Text = Reader.Item("XXL")
                        txtTotal.Text = Format(Reader.Item("TOTAL"), "0")
                        dtpFecha.Value = Reader.Item("FECHA")
                    End If
                End If

            End If

        End If
        Exit Sub

ErrCargar:
        MensajeCritico("Error al recuperar la OP.")

    End Sub

    Private Sub cmdObtenerNroOP_Click(sender As Object, e As EventArgs) Handles cmdObtenerNroOP.Click
        txtOP.Text = GenerarProximoNroOP()
    End Sub

    Private Function GenerarProximoNroOP() As String
        On Error GoTo FalloGenerandoProximo
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String
        Dim NroOP As String = ""

        If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")

        sStr = "SELECT Top 1 * FROM ProdArticulosOP where Eliminado=0 ORDER BY FECHA desc, OP desc"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                NroOP = Reader.Item("OP").ToString
            End If
        End If

        NroOP = CStr(CInt(NroOP) + 1)

        sStr = "SELECT count(*) as CANTI FROM ProdArticulosOP where Eliminado=0 and OP=" + NroOP
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Reader.Read()
        If Reader.Item("CANTI") > 0 Then
            'Si ya figura ese numero de op paso al siguiente
            NroOP = CStr(CInt(NroOP) + 1)
            'y vuelvo a controlar que no figure
            sStr = "SELECT count(*) as CANTI FROM ProdArticulosOP where Eliminado=0 and OP=" + NroOP
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            Reader.Read()
            If Reader.Item("CANTI") > 0 Then
                'Si otra vez figura ese numero de op le tiro error y le pido que haga lugar en los numeros de op
                'porque entonces es que ya nos quedamos sin espacio para nuevas ops
                MensajeAtencion("No se pueden generar más OPs. No quedan números libres para nuevas OPs." + Chr(10) + _
                    "Por favor borre las OPs más antiguas.")
                NroOP = ""
            End If
        End If

        GenerarProximoNroOP = NroOP

        Exit Function
FalloGenerandoProximo:
        MensajeAtencion("Error al intentar generar el número de OP. Informe a Sistemas.")
        GenerarProximoNroOP = ""
    End Function

    Private Sub cmdBorrarOPsAntiguas_Click(sender As Object, e As EventArgs) Handles cmdBorrarOPsAntiguas.Click
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim sStr As String
        Dim MinOP, MaxOP As String

        MinOP = ""
        MaxOP = ""

        If MsgBox("Se dispone a eliminar las 100 OPs más antiguas." + Chr(10) + "Confirma el Borrado?", vbYesNo, "Textilana S. A.") = vbNo Then
            Exit Sub
        End If

        'primero que nada verifico que realmente no tenga espacio, si hay menos de 500 OPs es de gusto que borre, porque hay un monton de lugar
        'asi que aunque dijo que si, le tiro cartel de que no lo permito
        sStr = "SELECT count(*) as CANTI FROM ProdArticulosOP where Eliminado=0 "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Reader.Read()
        If Reader.Item("CANTI") <= 500 Then
            MensajeAtencion("Sólo hay 500 o menos OPs activas. No es necesario hacer lugar para nuevas OPs." + Chr(10) + _
                "Se cancela la operación.")
            Exit Sub
        End If

        'busco el id de las ultimas 100 para luego borrar
        sStr = "SELECT MIN(OP) as MINOP from (select top 100 * FROM ProdArticulosOP where Eliminado = 0 ORDER BY FECHA,OP) a"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                MinOP = Reader.Item("MINOP").ToString
            End If
        End If
        sStr = "SELECT MAX(OP) as MAXOP from (select top 100 * FROM ProdArticulosOP where Eliminado = 0 ORDER BY FECHA,OP) a"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                MaxOP = Reader.Item("MAXOP").ToString
            End If
        End If

        'borro las OPs
        sStr = "DELETE FROM ProdArticulosOP WHERE OP BETWEEN " + MinOP + " AND " + MaxOP
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Command.ExecuteNonQuery()

        MensajeInfo("Se eliminaron con éxito las 100 OPs más antiguas.")

    End Sub
End Class