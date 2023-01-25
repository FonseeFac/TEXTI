Imports System.Data.SqlClient

Public Class frmObtieneObservacion
    Public SeConfirmoOK As Boolean = False
    Public DescripcionDeLegajo As String = ""
    Public NrolegajoIngresado As String = ""
    Public DescripcionLegajoIngresado As String = ""

    '*****************************
    Dim SePideLegajo As Boolean = True

    Sub New(ByVal ParaLegajo As Boolean, ByVal TextoCartel As String, ByVal TextoTitulo As String, ByVal TextoLabel As String)

        InitializeComponent()
        Me.Text = TextoTitulo
        lblNroLegajo.Text = TextoLabel
        lblCartel.Text = TextoCartel
        If ParaLegajo Then
            SePideLegajo = True
        Else
            SePideLegajo = False
        End If

    End Sub

    Private Sub frmObtieneLegajo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtNroLegajo.Text = ""
        txtNroLegajo.Select()
    End Sub

    Private Sub cmdCancelar_Click(sender As System.Object, e As System.EventArgs) Handles cmdCancelar.Click
        SeConfirmoOK = False
        Close()
    End Sub

    Private Sub cmdOK_Click(sender As System.Object, e As System.EventArgs) Handles cmdOK.Click
        ProcedimientoSeConfirmoOK()
    End Sub

    Private Sub txtNroLegajo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNroLegajo.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNroLegajo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNroLegajo.KeyDown
        If e.KeyCode = Keys.Return Then
            ProcedimientoSeConfirmoOK()
        End If
    End Sub


    Private Sub ProcedimientoSeConfirmoOK()

        If SePideLegajo Then
            If IsNumeric(txtNroLegajo.Text) Then
                txtNroLegajo.Text = "A" + CompletarCaracteresIzquierda(txtNroLegajo.Text, 5, "0").ToString
                DescripcionDeLegajo = DescripcionLegajo(txtNroLegajo.Text)
            Else
                txtNroLegajo.Text = UCase(txtNroLegajo.Text)
                DescripcionDeLegajo = DescripcionLegajo(txtNroLegajo.Text)
            End If

            If DescripcionDeLegajo <> "" Then
                SeConfirmoOK = True
                NrolegajoIngresado = txtNroLegajo.Text
                DescripcionLegajoIngresado = DescripcionDeLegajo
                Close()
            Else
                SeConfirmoOK = False
                MensajeAtencion("LEGAJO MAL INGRESADO")
                NrolegajoIngresado = ""
                txtNroLegajo.Select()
            End If
        Else
            SeConfirmoOK = True
            If txtNroLegajo.Text <> "" Then
                NrolegajoIngresado = txtNroLegajo.Text
                DescripcionLegajoIngresado = ""
            Else
                NrolegajoIngresado = ""
                DescripcionLegajoIngresado = ""
            End If

            Close()
            
        End If



    End Sub

End Class