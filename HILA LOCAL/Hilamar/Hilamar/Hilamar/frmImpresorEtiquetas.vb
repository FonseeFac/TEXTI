Imports System.IO
Imports System.Text

Public Class frmImpresorEtiquetas

    Private Sub frmImpresorEtiquetas_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        If FormAbierto(frmLogueo) Then frmLogueo.Dispose()
    End Sub

    Private Sub frmImpresorEtiquetas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cargar()
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        'antes de salir guardo la ultima configuracion
        grabarUltimaConfiguraciónUsada()
        End
    End Sub

    Public Sub Cargar()
        If Now.Hour < 14 Then
            lblFechaTurno.Text = Format(Now, "dd/MM/yyyy") + " T.M."
        Else
            lblFechaTurno.Text = Format(Now, "dd/MM/yyyy") + " T.T."
        End If

        If UCase(Environment.MachineName) = "MANTENIMIENTO" Or Strings.Left(UCase(Environment.MachineName), 8) = "COMPUTOS" Then
            lblTextoTamañoFuente.Visible = True
            txtTextoTamañoFuente.Visible = True
            txtTextoTamañoFuente.Text = 12

            'desactivo las opciones de configurar etiqueta
            txtAltoEtiqueta.Enabled = True
            txtAnchoEtiqueta.Enabled = True
            txtMargenIzq.Enabled = False
            txtMargenSup.Enabled = True
        Else
            lblTextoTamañoFuente.Visible = False
            txtTextoTamañoFuente.Visible = False

            'desactivo las opciones de configurar etiqueta
            txtAltoEtiqueta.Enabled = False
            txtAnchoEtiqueta.Enabled = False
            txtMargenIzq.Enabled = False
            txtMargenSup.Enabled = False
        End If

        CargarImpresorasInstaladasEnSistema()
        CargarDimensionesPredeterminadasEtiqueta()
        CargarListaDeHilados()



        'cmbHilados.SelectedIndex = 2
        'txtColor1.Text = "COLOR1"
        'txtColor2.Text = "COLOR2"
        'txtColor3.Text = "COLOR3"
        'txtPar.Text = "part"
        'txtNro1.Text = "9548"
        'txtNro2.Text = "954"

        txtHilado.Select()



    End Sub

    Private WithEvents printDoc As New System.Drawing.Printing.PrintDocument
    Private Sub CargarImpresorasInstaladasEnSistema()
        Dim i As Integer
        Dim pkInstalledPrinters As String

        For i = 0 To System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count - 1
            pkInstalledPrinters = System.Drawing.Printing.PrinterSettings.InstalledPrinters.Item(i)
            cmbImpresora.Items.Add(pkInstalledPrinters)
            'dejo preseleccionada la impresora por defecto
            If (printDoc.PrinterSettings.IsDefaultPrinter()) Then
                cmbImpresora.Text = printDoc.PrinterSettings.PrinterName
            End If
        Next
    End Sub

    Private Function CargarDimensionesPredeterminadasEtiqueta() As String
        Dim retorno As String = ""

        If File.Exists(Application.StartupPath + "\Config_Inicio.txt") Then
            Dim objReader As New StreamReader(Application.StartupPath + "\Config_Inicio.txt", Encoding.Default)
            Dim sLine As String = ""
            sLine = objReader.ReadLine() 'la primer linea tiene si hay o no red
            sLine = objReader.ReadLine()
            txtAnchoEtiqueta.Text = sLine.Split(":")(1)
            sLine = objReader.ReadLine()
            txtAltoEtiqueta.Text = sLine.Split(":")(1)
            sLine = objReader.ReadLine()
            txtMargenIzq.Text = sLine.Split(":")(1)
            sLine = objReader.ReadLine()
            txtMargenSup.Text = sLine.Split(":")(1)
            objReader.Close()
        Else
            retorno = ""
        End If
        Return retorno
    End Function

    Private Sub CargarListaDeHilados()
        cmbHilados.Items.Clear()
        If File.Exists(Application.StartupPath + "\Lista_Hilados.txt") Then
            Dim objReader As New StreamReader(Application.StartupPath + "\Lista_Hilados.txt", Encoding.Default)
            Dim sLine As String = ""

            Do
                sLine = objReader.ReadLine()
                If Not sLine Is Nothing Then
                    cmbHilados.Items.Add(sLine)
                End If
            Loop Until sLine Is Nothing

            objReader.Close()
        End If
    End Sub

    Private Sub RevisoYAgregoNuevoHilado(ByVal NombreHilado As String)
        Dim i As Integer
        Dim Existe As Boolean = False

        For i = 0 To cmbHilados.Items.Count - 1
            If cmbHilados.Items(i).ToString = NombreHilado Then
                Existe = True
                Exit For
            End If
        Next

        If Not Existe Then
            cmbHilados.Items.Add(NombreHilado)
            cmbHilados.Sorted = True
            GrabarListadoDeHiladosAlTxt()
        End If

    End Sub
    Private Sub GrabarListadoDeHiladosAlTxt()
        Dim i As Integer
        Dim sw As New System.IO.StreamWriter(Application.StartupPath + "\Lista_Hilados.txt", False)
        For i = 0 To cmbHilados.Items.Count - 1
            sw.WriteLine(cmbHilados.Items(i).ToString)
        Next
        sw.Close()
    End Sub

    Private Sub txtHilado_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtHilado.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then e.Handled = True
    End Sub
    Private Sub txtColor1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtColor1.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then e.Handled = True
    End Sub
    Private Sub txtColor2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtColor2.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then e.Handled = True
    End Sub
    Private Sub txtColor3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtColor3.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then e.Handled = True
    End Sub
    Private Sub txtPar_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPar.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then e.Handled = True
    End Sub
    Private Sub txtNro1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNro1.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then e.Handled = True
    End Sub
    Private Sub txtNro2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNro2.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then e.Handled = True
    End Sub

    Private Sub txtHilado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHilado.KeyDown
        If txtHilado.Text = "" Then Exit Sub
        If e.KeyCode = Keys.Enter Then txtColor1.Select()
    End Sub
    Private Sub txtColor1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtColor1.KeyDown
        If e.KeyCode = Keys.Enter Then txtColor2.Select()
    End Sub
    Private Sub txtColor2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtColor2.KeyDown
        If e.KeyCode = Keys.Enter Then txtColor3.Select()
    End Sub
    Private Sub txtColor3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtColor3.KeyDown
        If e.KeyCode = Keys.Enter Then txtPar.Select()
    End Sub
    Private Sub txtPar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPar.KeyDown
        If e.KeyCode = Keys.Enter Then txtNro1.Select()
    End Sub
    Private Sub txtnro1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNro1.KeyDown
        If e.KeyCode = Keys.Enter Then txtNro2.Select()
    End Sub
    Private Sub txtnro2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNro2.KeyDown
        If e.KeyCode = Keys.Enter Then cmdAceptar.Select()
    End Sub

    Private Sub txtHilado_LostFocus(sender As Object, e As EventArgs) Handles txtHilado.LostFocus
        txtHilado.Text = UCase(txtHilado.Text)
    End Sub
    Private Sub txtColor1_LostFocus(sender As Object, e As EventArgs) Handles txtColor1.LostFocus
        txtColor1.Text = UCase(txtColor1.Text)
    End Sub
    Private Sub txtColor2_LostFocus(sender As Object, e As EventArgs) Handles txtColor2.LostFocus
        txtColor2.Text = UCase(txtColor2.Text)
    End Sub
    Private Sub txtColor3_LostFocus(sender As Object, e As EventArgs) Handles txtColor3.LostFocus
        txtColor3.Text = UCase(txtColor3.Text)
    End Sub
    Private Sub txtPar_LostFocus(sender As Object, e As EventArgs) Handles txtPar.LostFocus
        txtPar.Text = UCase(txtPar.Text)
    End Sub

    Private Sub txtTextoLibre1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTextoLibre1.KeyDown
        If e.KeyCode = Keys.Enter Then txtTextoLibre2.Select()
    End Sub
    Private Sub txtTextoLibre2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTextoLibre2.KeyDown
        If e.KeyCode = Keys.Enter Then txtTextoLibre3.Select()
    End Sub
    Private Sub txtTextoLibre3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTextoLibre3.KeyDown
        If e.KeyCode = Keys.Enter Then txtTextoLibre4.Select()
    End Sub
    Private Sub txtTextoLibre4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTextoLibre4.KeyDown
        If e.KeyCode = Keys.Enter Then txtTextoLibre5.Select()
    End Sub
    Private Sub txtTextoLibre5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTextoLibre5.KeyDown
        If e.KeyCode = Keys.Enter Then cmdAceptar.Select()
    End Sub

    Private Sub cmdAceptar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmdAceptar.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then Guardar()
    End Sub
    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Guardar()
    End Sub

    Private Sub Guardar()

        If TabControl1.SelectedTab.Name = "TabPageHilado" Then
            If Not ValidarHilado() Then Exit Sub

            If txtHilado.Text <> "" Then
                txtHilado.Text = UCase(txtHilado.Text)
                RevisoYAgregoNuevoHilado(txtHilado.Text)
            End If
        Else
            If Not ValidarTexto() Then Exit Sub

        End If

        Imprimir()

    End Sub

    Private Function ValidarHilado() As Boolean
        On Error GoTo ErrValidar
        ValidarHilado = False

        If txtHilado.Text = "" And cmbHilados.Text = "" Then
            MensajeAtencion("Debe ingresar un Hilado.")
            ValidarHilado = False
            Exit Function
        End If
        If txtColor1.Text = "" And txtColor2.Text = "" And txtColor3.Text = "" Then
            MensajeAtencion("Debe ingresar alguna línea de color.")
            ValidarHilado = False
            Exit Function
        End If

        If txtPar.Text = "" Then
            MensajeAtencion("Debe ingresar el color de partida.")
            ValidarHilado = False
            Exit Function
        End If

        If txtNro1.Text = "" Then
            MensajeAtencion("Debe ingresar el número de partida.")
            ValidarHilado = False
            Exit Function
        End If

        ValidarHilado = True
        Exit Function
ErrValidar:
        ValidarHilado = False
        MensajeCritico("Error al validar hilado.")
    End Function

    Private Function ValidarTexto() As Boolean
        On Error GoTo ErrValidar
        ValidarTexto = False

        If txtTextoLibre1.Text = "" And txtTextoLibre2.Text = "" And txtTextoLibre3.Text = "" And txtTextoLibre4.Text = "" And txtTextoLibre5.Text = "" Then
            MensajeAtencion("Debe ingresar algun texto.")
            ValidarTexto = False
            Exit Function
        End If

        ValidarTexto = True
        Exit Function
ErrValidar:
        ValidarTexto = False
        MensajeCritico("Error al validar texto.")
    End Function


    Private Sub grabarUltimaConfiguraciónUsada()
        'Si no existe el directorio, lo creo
        Dim sw As New System.IO.StreamWriter(Application.StartupPath + "\Config_Inicio.txt", False)
        If UCase(Environment.MachineName) = "MANTENIMIENTO" Or Strings.Left(UCase(Environment.MachineName), 8) = "COMPUTOS" Then
            sw.WriteLine("Con Red")
        Else
            sw.WriteLine("Sin Red")
        End If
        sw.WriteLine("Ancho:" + txtAnchoEtiqueta.Text)
        sw.WriteLine("Alto:" + txtAltoEtiqueta.Text)
        sw.WriteLine("MargenIzq:" + txtMargenIzq.Text)
        sw.WriteLine("MargenSup:" + txtMargenSup.Text)
        sw.Close()

    End Sub

    Private Sub Imprimir()
        If UCase(Environment.MachineName) = "MANTENIMIENTO" Or Strings.Left(UCase(Environment.MachineName), 8) = "COMPUTOS" Then
            pdoImpReporte.DefaultPageSettings.Landscape = False
            pdoImpReporte.DefaultPageSettings.Margins.Left = 2
            pdoImpReporte.DefaultPageSettings.Margins.Right = 2
            pdoImpReporte.DefaultPageSettings.Margins.Top = txtMargenSup.Text
            pdoImpReporte.DefaultPageSettings.Margins.Bottom = 2
            pdoImpReporte.OriginAtMargins = True ' takes margins into account 
            pdoImpReporte.DefaultPageSettings.PaperSize = New Printing.PaperSize("Personalizado", (CInt(txtAnchoEtiqueta.Text) * 39) + 10, CInt(txtAltoEtiqueta.Text) * 39)
            'pdoImpReporte.DefaultPageSettings.PaperSize = New Printing.PaperSize("Personalizado", 100, 35)
            pdoImpReporte.DefaultPageSettings.PrinterSettings.Copies = CInt(txtCantEtiquetas.Text)
        Else
            pdoImpReporte.DefaultPageSettings.Landscape = False
            pdoImpReporte.DefaultPageSettings.Margins.Left = 2
            pdoImpReporte.DefaultPageSettings.Margins.Right = 2
            pdoImpReporte.DefaultPageSettings.Margins.Top = 2
            pdoImpReporte.DefaultPageSettings.Margins.Bottom = 2
            pdoImpReporte.OriginAtMargins = True ' takes margins into account 
            pdoImpReporte.DefaultPageSettings.PaperSize = New Printing.PaperSize("Personalizado", 2 * (CInt(txtAnchoEtiqueta.Text) * 39) + 10, CInt(txtAltoEtiqueta.Text) * 39)
            'pdoImpReporte.DefaultPageSettings.PaperSize = New Printing.PaperSize("Personalizado", 100, 35)
            pdoImpReporte.DefaultPageSettings.PrinterSettings.Copies = CInt(txtCantEtiquetas.Text) / 2
        End If

        pdoImpReporte.DefaultPageSettings.PrinterSettings.PrinterName = cmbImpresora.Text

        Dim dlgPrintPreview As New EnhancedPrintPreviewDialog
        dlgPrintPreview.ClientSize = New System.Drawing.Size(100, 35)
        dlgPrintPreview.Document = pdoImpReporte ' Previews print
        dlgPrintPreview.ShowDialog()

        'pdoImpReporte.Print()

    End Sub

    Private nRowPos As Int16

    Private Sub pdoImpReporte_BeginPrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles pdoImpReporte.BeginPrint
        nRowPos = 0
    End Sub

    Private Sub pdoImpReporte_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdoImpReporte.PrintPage
        Dim Col, ColIzq, MargenIzq, MargenSup As Integer

        Dim titulo As String
        Dim StringFormatCentrado As New StringFormat()
        StringFormatCentrado.Alignment = StringAlignment.Center

        Dim Hilado, Partida, CodPartida As String

        Dim FuenteLineas As Font = New Drawing.Font("Verdana", 10, FontStyle.Bold)
        Dim FuenteLineas9 As Font = New Drawing.Font("Verdana", 9, FontStyle.Bold)
        Dim FuenteLineas11 As Font = New Drawing.Font("Verdana", 11, FontStyle.Bold)
        Dim FuenteLineas12 As Font = New Drawing.Font("Verdana", 12, FontStyle.Bold)
        Dim FuenteLineas16 As Font = New Drawing.Font("Verdana", 16, FontStyle.Bold)
        Dim FuenteLineas18 As Font = New Drawing.Font("Verdana", 19, FontStyle.Bold)

        Dim nTop As Int16

        If txtHilado.Text = "" Then
            Hilado = cmbHilados.Text
        Else
            Hilado = txtHilado.Text
        End If
        Partida = "PAR:" + txtPar.Text + " " + lblFechaTurno.Text
        If txtNro2.Text <> "" Then
            CodPartida = txtNro1.Text + "/" + txtNro2.Text
        Else
            CodPartida = txtNro1.Text
        End If

        MargenIzq = 5
        If txtMargenIzq.Text <> "" Then
            If IsNumeric(txtMargenIzq.Text) Then
                MargenIzq = CInt(txtMargenIzq.Text)
            End If
        End If

        MargenSup = 5
        If txtMargenSup.Text <> "" Then
            If IsNumeric(txtMargenSup.Text) Then
                MargenSup = CInt(txtMargenSup.Text)
            End If
        End If

        If TabControl1.SelectedTab.Name = "TabPageHilado" Then
            nTop = MargenSup

            If Hilado.Length > 18 Then
                Col = MargenIzq + ((CInt(txtAnchoEtiqueta.Text) * 39) - e.Graphics.MeasureString(Hilado, FuenteLineas, e.MarginBounds.Width).Width) / 2
                e.Graphics.DrawString(Hilado, FuenteLineas, Brushes.Black, Col, nTop)
                nTop = nTop + 20
            Else
                Col = MargenIzq + ((CInt(txtAnchoEtiqueta.Text) * 39) - e.Graphics.MeasureString(Hilado, FuenteLineas12, e.MarginBounds.Width).Width) / 2
                e.Graphics.DrawString(Hilado, FuenteLineas12, Brushes.Black, Col, nTop)
                nTop = nTop + 20
            End If

            Col = MargenIzq + ((CInt(txtAnchoEtiqueta.Text) * 39) - e.Graphics.MeasureString(txtColor1.Text, FuenteLineas, e.MarginBounds.Width).Width) / 2
            e.Graphics.DrawString(txtColor1.Text, FuenteLineas, Brushes.Black, Col, nTop)
            nTop = nTop + 16

            Col = MargenIzq + ((CInt(txtAnchoEtiqueta.Text) * 39) - e.Graphics.MeasureString(txtColor2.Text, FuenteLineas, e.MarginBounds.Width).Width) / 2
            e.Graphics.DrawString(txtColor2.Text, FuenteLineas, Brushes.Black, Col, nTop)
            nTop = nTop + 16

            Col = MargenIzq + ((CInt(txtAnchoEtiqueta.Text) * 39) - e.Graphics.MeasureString(txtColor3.Text, FuenteLineas, e.MarginBounds.Width).Width) / 2
            e.Graphics.DrawString(txtColor3.Text, FuenteLineas, Brushes.Black, Col, nTop)
            nTop = nTop + 16

            Col = MargenIzq + ((CInt(txtAnchoEtiqueta.Text) * 39) - e.Graphics.MeasureString(Partida, FuenteLineas9, e.MarginBounds.Width).Width) / 2
            e.Graphics.DrawString(Partida, FuenteLineas9, Brushes.Black, Col, nTop)
            nTop = nTop + 14

            Col = MargenIzq + ((CInt(txtAnchoEtiqueta.Text) * 39) - e.Graphics.MeasureString(CodPartida, FuenteLineas18, e.MarginBounds.Width).Width) / 2
            e.Graphics.DrawString(CodPartida, FuenteLineas18, Brushes.Black, Col, nTop)

            nTop = MargenSup
            ColIzq = CInt(txtAnchoEtiqueta.Text) * 39 + 5

            If Hilado.Length > 18 Then
                Col = ColIzq + MargenIzq + ((CInt(txtAnchoEtiqueta.Text) * 39) - e.Graphics.MeasureString(Hilado, FuenteLineas, e.MarginBounds.Width).Width) / 2
                e.Graphics.DrawString(Hilado, FuenteLineas, Brushes.Black, Col, nTop)
                nTop = nTop + 20
            Else
                Col = ColIzq + MargenIzq + ((CInt(txtAnchoEtiqueta.Text) * 39) - e.Graphics.MeasureString(Hilado, FuenteLineas12, e.MarginBounds.Width).Width) / 2
                e.Graphics.DrawString(Hilado, FuenteLineas12, Brushes.Black, Col, nTop)
                nTop = nTop + 20
            End If
            Col = ColIzq + MargenIzq + ((CInt(txtAnchoEtiqueta.Text) * 39) - e.Graphics.MeasureString(txtColor1.Text, FuenteLineas, e.MarginBounds.Width).Width) / 2
            e.Graphics.DrawString(txtColor1.Text, FuenteLineas, Brushes.Black, Col, nTop)
            nTop = nTop + 16
            Col = ColIzq + MargenIzq + ((CInt(txtAnchoEtiqueta.Text) * 39) - e.Graphics.MeasureString(txtColor2.Text, FuenteLineas, e.MarginBounds.Width).Width) / 2
            e.Graphics.DrawString(txtColor2.Text, FuenteLineas, Brushes.Black, Col, nTop)
            nTop = nTop + 16
            Col = ColIzq + MargenIzq + ((CInt(txtAnchoEtiqueta.Text) * 39) - e.Graphics.MeasureString(txtColor3.Text, FuenteLineas, e.MarginBounds.Width).Width) / 2
            e.Graphics.DrawString(txtColor3.Text, FuenteLineas, Brushes.Black, Col, nTop)
            nTop = nTop + 16
            Col = ColIzq + MargenIzq + ((CInt(txtAnchoEtiqueta.Text) * 39) - e.Graphics.MeasureString(Partida, FuenteLineas9, e.MarginBounds.Width).Width) / 2
            e.Graphics.DrawString(Partida, FuenteLineas9, Brushes.Black, Col, nTop)
            nTop = nTop + 14
            Col = ColIzq + MargenIzq + ((CInt(txtAnchoEtiqueta.Text) * 39) - e.Graphics.MeasureString(CodPartida, FuenteLineas18, e.MarginBounds.Width).Width) / 2
            e.Graphics.DrawString(CodPartida, FuenteLineas18, Brushes.Black, Col, nTop)

        Else
            If UCase(Environment.MachineName) = "MANTENIMIENTO" Or Strings.Left(UCase(Environment.MachineName), 8) = "COMPUTOS" Then

                If txtTextoTamañoFuente.Text <> "" Then
                    If IsNumeric(txtTextoTamañoFuente.Text) Then
                        FuenteLineas = New Drawing.Font("Verdana", CInt(txtTextoTamañoFuente.Text), FontStyle.Regular)
                    End If
                End If
                
                nTop = MargenSup
                Col = MargenIzq

                titulo = txtTextoLibre1.Text + Chr(10) + txtTextoLibre2.Text + Chr(10) + txtTextoLibre3.Text + Chr(10) + txtTextoLibre4.Text + Chr(10) + txtTextoLibre5.Text

                e.Graphics.DrawString(titulo, FuenteLineas, Brushes.Black, New RectangleF(Col, nTop, (CInt(txtAnchoEtiqueta.Text) * 39), CInt(txtAltoEtiqueta.Text) * 39), StringFormatCentrado)


                'e.Graphics.DrawString(txtTextoLibre1.Text, FuenteLineas, Brushes.Black, Col, nTop)
                'If txtTextoTamañoFuente.Text > "16" Then
                '    nTop = nTop + txtTextoTamañoFuente.Text
                'Else
                '    nTop = nTop + 18
                'End If
                'e.Graphics.DrawString(txtTextoLibre2.Text, FuenteLineas, Brushes.Black, Col, nTop)
                'If txtTextoTamañoFuente.Text > "16" Then
                '    nTop = nTop + txtTextoTamañoFuente.Text
                'Else
                '    nTop = nTop + 18
                'End If
                'e.Graphics.DrawString(txtTextoLibre3.Text, FuenteLineas, Brushes.Black, Col, nTop)
                'If txtTextoTamañoFuente.Text > "16" Then
                '    nTop = nTop + txtTextoTamañoFuente.Text
                'Else
                '    nTop = nTop + 18
                'End If
                'e.Graphics.DrawString(txtTextoLibre4.Text, FuenteLineas, Brushes.Black, Col, nTop)
                'If txtTextoTamañoFuente.Text > "16" Then
                '    nTop = nTop + txtTextoTamañoFuente.Text
                'Else
                '    nTop = nTop + 18
                'End If
                'e.Graphics.DrawString(txtTextoLibre5.Text, FuenteLineas, Brushes.Black, Col, nTop)

            Else
                nTop = MargenSup
                Col = MargenIzq

                e.Graphics.DrawString(txtTextoLibre1.Text, FuenteLineas, Brushes.Black, Col, nTop)
                nTop = nTop + 18
                e.Graphics.DrawString(txtTextoLibre2.Text, FuenteLineas, Brushes.Black, Col, nTop)
                nTop = nTop + 18
                e.Graphics.DrawString(txtTextoLibre3.Text, FuenteLineas, Brushes.Black, Col, nTop)
                nTop = nTop + 18
                e.Graphics.DrawString(txtTextoLibre4.Text, FuenteLineas, Brushes.Black, Col, nTop)
                nTop = nTop + 18
                e.Graphics.DrawString(txtTextoLibre5.Text, FuenteLineas, Brushes.Black, Col, nTop)

                ColIzq = CInt(txtAnchoEtiqueta.Text) * 39 + 5
                nTop = MargenSup
                Col = MargenIzq + ColIzq

                e.Graphics.DrawString(txtTextoLibre1.Text, FuenteLineas, Brushes.Black, Col, nTop)
                nTop = nTop + 18
                e.Graphics.DrawString(txtTextoLibre2.Text, FuenteLineas, Brushes.Black, Col, nTop)
                nTop = nTop + 18
                e.Graphics.DrawString(txtTextoLibre3.Text, FuenteLineas, Brushes.Black, Col, nTop)
                nTop = nTop + 18
                e.Graphics.DrawString(txtTextoLibre4.Text, FuenteLineas, Brushes.Black, Col, nTop)
                nTop = nTop + 18
                e.Graphics.DrawString(txtTextoLibre5.Text, FuenteLineas, Brushes.Black, Col, nTop)
            End If
        End If

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab.Name = "TabPageHilado" Then
            txtHilado.Select()
        Else
            txtTextoLibre1.Select()
        End If
    End Sub
End Class