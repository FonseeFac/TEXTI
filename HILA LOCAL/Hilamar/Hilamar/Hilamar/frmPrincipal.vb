Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class frmPrincipal
    Dim FechaUltimaActualizaciondeTareasMant As String

    Dim LegajoLogueado As String 'legajo de quien va a trabajar
    Dim TipoUsuario As String ' Tipo de usuario que va a trabajar, lo voy a usar para saber que le habilito a usar y que no
    Dim formLogueo As frmLogueo

    Sub New(ByVal parametro1 As String, ByVal parametro2 As String, ByRef parametro3 As Form)
        InitializeComponent() 'es necesario que lleve esta linea

        LegajoLogueado = parametro1
        TipoUsuario = parametro2
        formLogueo = parametro3
    End Sub


    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        End
    End Sub

    Private Sub ABMHiladosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ABMHiladosToolStripMenuItem.Click
        If FormAbierto(frmListado) Then Exit Sub

        Dim FormHilado As New frmListado
        FormHilado.Pantalla = "Hilado"
        FormHilado.Cargar()
        FormHilado.Show()
    End Sub

    Private Sub Cargar()
        ExistenciaDeMateriaPrimaToolStripMenuItem.Enabled = False

        If TipoUsuario = "Administrador" Then
            'menu materia prima
            tsmiHilamarArticulos.Visible = True
            'menu procesos
            tsmiProcesos.Visible = True
            'menu de Hilados Hilamar
            tsmiHilamarHilados.Visible = True
            'menu de Hilados Textilana
            TextiHiladosToolStripMenuItem.Visible = True
            TextiHiladosToolStripMenuItem.Enabled = False
            'menu de costos
            CostosToolStripMenuItem.Visible = True
            CostosParametrosGralesToolStripMenuItem.Enabled = True
            CompCostosToolStripMenuItem.Enabled = True
            'menu administracion
            AdministraciónToolStripMenuItem.Visible = True
            'menu art en prduccion - planilla de programacion
            ArtEnProducciónToolStripMenuItem.Visible = True
            'menu de administracion de MANTENIMIENTO
            MantAdministracionToolStripMenuItem.Visible = True
            MantAdministracionToolStripMenuItem.Enabled = True


        ElseIf TipoUsuario = "Jefe-Mant" Then
            'menu materia prima
            tsmiHilamarArticulos.Visible = False
            'menu procesos
            tsmiProcesos.Visible = False
            'menu de Hilados Hilamar
            tsmiHilamarHilados.Visible = True
            HilaABMHiladosToolStripMenuItem.Enabled = True
            ABMPartidasToolStripMenuItem.Enabled = True
            HilamarHiladosIngresosToolStripMenuItem.Enabled = True
            HilamarHiladosEgresosToolStripMenuItem.Enabled = True
            HilamarHiladosConsumosToolStripMenuItem.Enabled = True
            ExistenciaDeMateriaPrimaToolStripMenuItem.Enabled = True
            'menu de Hilados Textilana
            TextiHiladosToolStripMenuItem.Visible = False
            TextiHiladosToolStripMenuItem.Enabled = False

            'menu de costos
            CostosToolStripMenuItem.Visible = False
            'menu administracion
            AdministraciónToolStripMenuItem.Visible = False
            'menu art en produccion - planilla de programacion
            ArtEnProducciónToolStripMenuItem.Visible = False
            'menu de administracion de MANTENIMIENTO
            MantAdministracionToolStripMenuItem.Visible = True
            MantAdministracionToolStripMenuItem.Enabled = True
            If LegajoLogueado = "S00994" Then
                HilaABMHiladosToolStripMenuItem.Enabled = False
                ABMPartidasToolStripMenuItem.Enabled = False
                HilamarHiladosIngresosToolStripMenuItem.Enabled = False
                HilamarHiladosEgresosToolStripMenuItem.Enabled = False
                HilamarHiladosConsumosToolStripMenuItem.Enabled = False
                ExistenciaDeMateriaPrimaToolStripMenuItem.Enabled = False
                'martin pidio poder ver las planillas de programacion de los programadores
                ArtEnProducciónToolStripMenuItem.Visible = True
            End If

        ElseIf TipoUsuario = "Enc-Mant" Then
            'menu materia prima
            tsmiHilamarArticulos.Visible = False
            'menu procesos
            tsmiProcesos.Visible = False
            'menu de Hilados Hilamar
            tsmiHilamarHilados.Visible = False
            'menu de Hilados Textilana
            TextiHiladosToolStripMenuItem.Visible = False
            TextiHiladosToolStripMenuItem.Enabled = False
            'menu de costos
            CostosToolStripMenuItem.Visible = False
            'menu administracion
            AdministraciónToolStripMenuItem.Visible = False
            'menu art en produccion - planilla de programacion
            ArtEnProducciónToolStripMenuItem.Visible = False
            'menu de administracion de MANTENIMIENTO
            MantAdministracionToolStripMenuItem.Visible = True
            MantAdministracionToolStripMenuItem.Enabled = True

        ElseIf TipoUsuario = "Jefe-Hilam" Then
            'menu materia prima
            tsmiHilamarArticulos.Visible = True
            tsmiHilamarArticulos.Enabled = False
            'menu procesos
            tsmiProcesos.Visible = True
            tsmiProcesos.Enabled = False
            'menu de Hilados Hilamar
            tsmiHilamarHilados.Visible = True
            'menu de Hilados Textilana
            TextiHiladosToolStripMenuItem.Visible = True
            TextiHiladosToolStripMenuItem.Enabled = False
            'menu de costos
            CostosToolStripMenuItem.Visible = True
            CostosParametrosGralesToolStripMenuItem.Enabled = True
            CompCostosToolStripMenuItem.Enabled = True
            'menu administracion
            AdministraciónToolStripMenuItem.Visible = True
            'menu art en produccion - planilla de programacion
            ArtEnProducciónToolStripMenuItem.Visible = False
            'menu de administracion de MANTENIMIENTO
            MantAdministracionToolStripMenuItem.Visible = False

        ElseIf TipoUsuario = "HilaAdmin" Then
            'menu materia prima
            tsmiHilamarArticulos.Visible = True
            tsmiHilamarArticulos.Enabled = False
            'menu procesos
            tsmiProcesos.Visible = True
            tsmiProcesos.Enabled = False
            'menu de Hilados Hilamar
            tsmiHilamarHilados.Visible = True
            'menu de Hilados Textilana
            TextiHiladosToolStripMenuItem.Visible = True
            TextiHiladosToolStripMenuItem.Enabled = False
            'menu de costos
            CostosToolStripMenuItem.Visible = True
            CostosParametrosGralesToolStripMenuItem.Enabled = True
            CompCostosToolStripMenuItem.Enabled = True
            'menu administracion
            AdministraciónToolStripMenuItem.Visible = True
            'menu art en produccion - planilla de programacion
            ArtEnProducciónToolStripMenuItem.Visible = False
            'menu de administracion de MANTENIMIENTO
            MantAdministracionToolStripMenuItem.Visible = False

        ElseIf TipoUsuario = "TextiAdmin" Then
            'menu materia prima
            tsmiHilamarArticulos.Visible = False
            'menu procesos
            tsmiProcesos.Visible = False
            'menu de Hilados Hilamar
            tsmiHilamarHilados.Visible = True
            tsmiHilamarHilados.Enabled = False
            'menu de Hilados Textilana
            TextiHiladosToolStripMenuItem.Visible = True
            TextiHiladosToolStripMenuItem.Enabled = False
            'menu de costos
            CostosToolStripMenuItem.Visible = True
            CostosParametrosGralesToolStripMenuItem.Enabled = False
            CompCostosToolStripMenuItem.Enabled = False
            'menu administracion
            AdministraciónToolStripMenuItem.Visible = False
            'menu art en produccion - planilla de programacion
            ArtEnProducciónToolStripMenuItem.Visible = False
            'menu de administracion de MANTENIMIENTO
            MantAdministracionToolStripMenuItem.Visible = False

        ElseIf TipoUsuario = "TextiEmpleado" Then
            'menu materia prima
            tsmiHilamarArticulos.Visible = False
            'menu procesos
            tsmiProcesos.Visible = False
            'menu de Hilados Hilamar
            tsmiHilamarHilados.Visible = False
            'menu de Hilados Textilana
            TextiHiladosToolStripMenuItem.Visible = True
            TextiHiladosToolStripMenuItem.Enabled = False
            'menu de costos
            CostosToolStripMenuItem.Visible = False
            'menu administracion
            AdministraciónToolStripMenuItem.Visible = False
            'menu art en produccion - planilla de programacion
            ArtEnProducciónToolStripMenuItem.Visible = False
            'menu de administracion de MANTENIMIENTO
            MantAdministracionToolStripMenuItem.Visible = False

        ElseIf TipoUsuario = "Jefe-Tejeduria" Then
            'menu materia prima
            tsmiHilamarArticulos.Visible = False
            'menu procesos
            tsmiProcesos.Visible = False
            'menu de Hilados Hilamar
            tsmiHilamarHilados.Visible = True
            HilaABMHiladosToolStripMenuItem.Enabled = False
            ABMPartidasToolStripMenuItem.Enabled = False
            HilamarHiladosIngresosToolStripMenuItem.Enabled = False
            HilamarHiladosEgresosToolStripMenuItem.Enabled = False
            HilamarHiladosConsumosToolStripMenuItem.Enabled = False
            ExistenciaDeMateriaPrimaToolStripMenuItem.Enabled = False
            'menu de Hilados Textilana
            TextiHiladosToolStripMenuItem.Visible = True
            TextiHiladosToolStripMenuItem.Enabled = False

            'menu de costos
            CostosToolStripMenuItem.Visible = False
            CostosParametrosGralesToolStripMenuItem.Enabled = False
            CompCostosToolStripMenuItem.Enabled = False
            'menu administracion
            AdministraciónToolStripMenuItem.Visible = False
            'menu art en produccion - planilla de programacion
            ArtEnProducciónToolStripMenuItem.Visible = True
            'menu de administracion de MANTENIMIENTO
            MantAdministracionToolStripMenuItem.Visible = False

        ElseIf TipoUsuario = "Tejeduria" Then
            'menu materia prima
            tsmiHilamarArticulos.Visible = False
            'menu procesos
            tsmiProcesos.Visible = False
            'menu de Hilados Hilamar
            tsmiHilamarHilados.Visible = False
            'menu de Hilados Textilana
            TextiHiladosToolStripMenuItem.Visible = False
            'menu de costos
            CostosToolStripMenuItem.Visible = False
            'menu administracion
            AdministraciónToolStripMenuItem.Visible = False
            'menu art en produccion - planilla de programacion
            ArtEnProducciónToolStripMenuItem.Visible = True
            'menu de administracion de MANTENIMIENTO
            MantAdministracionToolStripMenuItem.Visible = False

        ElseIf TipoUsuario = "Programacion" Then
            'menu materia prima
            tsmiHilamarArticulos.Visible = False
            'menu procesos
            tsmiProcesos.Visible = False
            'menu de Hilados Hilamar
            tsmiHilamarHilados.Visible = False
            'menu de Hilados Textilana
            TextiHiladosToolStripMenuItem.Visible = False
            'menu de costos
            CostosToolStripMenuItem.Visible = False
            'menu administracion
            AdministraciónToolStripMenuItem.Visible = False
            'menu art en produccion - planilla de programacion
            ArtEnProducciónToolStripMenuItem.Visible = True
            'menu de administracion de MANTENIMIENTO
            MantAdministracionToolStripMenuItem.Visible = False

        ElseIf TipoUsuario = "JefeCompras" Then
            'menu materia prima
            tsmiHilamarArticulos.Visible = False
            'menu procesos
            tsmiProcesos.Visible = False
            'menu de Hilados Hilamar
            tsmiHilamarHilados.Visible = True
            'menu de Hilados Textilana
            TextiHiladosToolStripMenuItem.Visible = False
            'menu de costos
            CostosToolStripMenuItem.Visible = True
            'menu administracion
            AdministraciónToolStripMenuItem.Visible = True
            'menu art en produccion - planilla de programacion
            ArtEnProducciónToolStripMenuItem.Visible = False
            'menu de administracion de MANTENIMIENTO
            MantAdministracionToolStripMenuItem.Visible = False

        ElseIf TipoUsuario = "Compras" Then
            'menu materia prima
            tsmiHilamarArticulos.Visible = False
            'menu procesos
            tsmiProcesos.Visible = False
            'menu de Hilados Hilamar
            tsmiHilamarHilados.Visible = True
            'menu de Hilados Textilana
            TextiHiladosToolStripMenuItem.Visible = False
            'menu de costos
            CostosToolStripMenuItem.Visible = False
            'menu administracion
            AdministraciónToolStripMenuItem.Visible = False
            'menu art en produccion - planilla de programacion
            ArtEnProducciónToolStripMenuItem.Visible = False
            'menu de administracion de MANTENIMIENTO
            MantAdministracionToolStripMenuItem.Visible = False

        ElseIf TipoUsuario = "DUEÑOS" Then
            'menu materia prima
            tsmiHilamarArticulos.Visible = False
            'menu procesos
            tsmiProcesos.Visible = False
            'menu de Hilados Hilamar
            tsmiHilamarHilados.Visible = True
            'menu de Hilados Textilana
            TextiHiladosToolStripMenuItem.Visible = False
            'menu de costos
            CostosToolStripMenuItem.Visible = False
            'menu administracion
            AdministraciónToolStripMenuItem.Visible = False
            'menu art en produccion - planilla de programacion
            ArtEnProducciónToolStripMenuItem.Visible = False
            'menu de administracion de MANTENIMIENTO
            MantAdministracionToolStripMenuItem.Visible = False

        End If

        If TipoUsuario = "Jefe-Mant" Then
            Me.Text = "Mantenimiento Textilana e Hilamar - Ventana Principal / Usuario Activo: " + DescripcionLegajo(LegajoLogueado)
        Else
            Me.Text = "Hilamar - Ventana Principal / Usuario Activo: " + DescripcionLegajo(LegajoLogueado)
        End If


        'por ahora suspendo la revision de plan de mant ahsta que retomemos
        'If TipoUsuario = "Administrador" Or TipoUsuario = "HilaAdmin" Or TipoUsuario = "Jefe-Mant" Then
        '    RevisarVencimientosTareasPlanMantenimiento()
        'End If


        'por ahora deshabilito las opciones que no pueden usar porque no estan terminadas
        'IngresodeHiladosToolStripMenuItem.Enabled = False
        'ListadodeMovimientosToolStripMenuItem.Enabled = False
        'ExistenciasdeHiladosTextilanaToolStripMenuItem.Enabled = False
    End Sub

    Private Sub frmPrincipal_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        ' al cerrar doy de baja el formulario de logueo si es que sigue abierto, si lo hacia directamente en el mismo formulario, me cerraba el proyecto,
        'asique se lo pase como parametro y cuando cierro el principal controlo y entonces puedo dar de baja el formulario que llamó
        If FormAbierto(formLogueo) Then formLogueo.Dispose()
    End Sub

    Private Sub ABMProcesosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ABMProcesosToolStripMenuItem.Click
        If FormAbierto(frmListado) Then Exit Sub

        Dim FormHilado As New frmListado
        FormHilado.Pantalla = "Procesos"
        FormHilado.Cargar()
        FormHilado.Show()
    End Sub

    Private Sub ABMMateriaPrimaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ABMMateriaPrimaToolStripMenuItem.Click
        If FormAbierto(frmListado) Then Exit Sub

        Dim FormHilado As New frmListado
        FormHilado.Pantalla = "MateriasPrimas"
        FormHilado.Cargar()
        FormHilado.Show()
    End Sub

    Private Sub MovimentosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsmiABMMovimientosStock.Click
        'If FormAbierto(frmAltaEntrMatPrim) Then Exit Sub

        'Dim FormABM As New frmAltaEntrMatPrim
        'FormABM.Show()

        'If FormAbierto(frmABMMovimientos) Then Exit Sub

        'Dim FormABM As New frmABMMovimientos
        'FormABM.TipoMov = "INGRESO"
        'FormABM.Cargar()
        'FormABM.Show()
    End Sub

    Private Sub ProcesosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsmiABMCategorias.Click
        If FormAbierto(frmABMArticulosCategorias) Then Exit Sub

        Dim ABMArtCateg As New frmABMArticulosCategorias
        ABMArtCateg.Show()

        'If FormAbierto(frmABMMovimientos) Then Exit Sub

        'Dim FormABM As New frmABMMovimientos
        'FormABM.TipoMov = "EGRESO"
        'FormABM.Cargar()
        'FormABM.Show()
    End Sub

    Private Sub ABMTipoMovimientosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ABMTipoMovimientosToolStripMenuItem.Click
        If FormAbierto(frmListado) Then Exit Sub

        Dim FormHilado As New frmListado
        FormHilado.Pantalla = "TipoMovimientos"
        FormHilado.Cargar()
        FormHilado.Show()
    End Sub

    Private Sub ConsultasToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If FormAbierto(frmRepoMovimientos) Then Exit Sub

        Dim FormRepo As New frmRepoMovimientos
        FormRepo.Cargar()
        FormRepo.Show()
    End Sub

    'Private Sub IngresodeHiladosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresodeHiladosToolStripMenuItem.Click
    '    Dim formIngresodeHilados As New frmBorrarABMIngresodeHilados()
    '    If FormAbierto(formIngresodeHilados) Then Exit Sub
    '    formIngresodeHilados.Alta = True
    '    formIngresodeHilados.Cargar()
    '    formIngresodeHilados.Show()
    'End Sub

    'Private Sub ActualizarExistenciasHilamarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarExistenciasHilamarToolStripMenuItem.Click
    '    Dim Command3 As New SqlCommand
    '    Dim Reader3 As SqlDataReader
    '    Dim sStr3 As String
    '    Dim UltFechaUnixHilStock, UltFechaUnixTipoHila As Date
    '    Dim UltFechaUnixHilStockServer, UltFechaUnixTipoHilaServer As Date

    '    Dim sstr As String
    '    Dim Command2 As New SqlCommand
    '    Dim Kilos, CodColor, Color, PCardado As String

    '    'antes que nada verifico las ultima fecha de modif de los archivos de base de datos del unix, si son las mismas que en la base de datos no hago nada, 
    '    'porque no hubo modificaciones
    '    sStr3 = "SELECT * FROM HilamarConfigSistema "
    '    Command3 = New SqlCommand(sStr3, cConexionApp.SQLConn)
    '    Reader3 = Command3.ExecuteReader()
    '    If Reader3.HasRows Then
    '        If Reader3.Read Then
    '            UltFechaUnixHilStock = Reader3.Item("UltFechaUnixHilStock")
    '            UltFechaUnixTipoHila = Reader3.Item("UltFechaUnixTipoHila")
    '            'luegode leer voy a traer la fecha de modif de los archivos del unix
    '            UltFechaUnixHilStockServer = My.Computer.FileSystem.GetFileInfo("\\192.168.0.12\u\hilamar\sto\hilstock.dbf").LastWriteTime
    '            UltFechaUnixTipoHilaServer = My.Computer.FileSystem.GetFileInfo("\\192.168.0.12\u\hilamar\sto\tipohila.dbf").LastWriteTime

    '            If UltFechaUnixHilStock >= UltFechaUnixHilStockServer And UltFechaUnixHilStockServer >= UltFechaUnixTipoHilaServer Then
    '                MensajeAtencion("La base de datos está actualizada con la última información de UNIX (Partidas)." + _
    '                                Chr(10) + "No es necesario realizar la copia de datos.")
    '                Exit Sub
    '            End If

    '        End If
    '    End If

    '    ' si algo no anduvo o no pude leer o cualquier cosa trato de copiar siempre

    '    'COPIO LAS PARTIDAS

    '    Dim FormProgre As New frmProgreso
    '    FormProgre.CantMax = 3
    '    FormProgre.lblTarea.Text = "Actualizando Existencias de Hilados"
    '    FormProgre.lblEstado.Text = "Copiando partidas ..."
    '    FormProgre.Cargar()
    '    FormProgre.Show()
    '    FormProgre.CantProg = 1
    '    FormProgre.Actualizar()

    '    If Not CopiarPartidasUnix() Then
    '        MensajeAtencion("No se pudo recuperar la información de UNIX (Partidas).")
    '        FormProgre.Close()
    '        Exit Sub
    '    End If

    '    FormProgre.lblEstado.Text = "Actualizando Stock de Hilados ..."
    '    FormProgre.CantProg = FormProgre.CantProg + 1
    '    FormProgre.Actualizar()

    '    'reviso conexion textilana
    '    If cConexionApp.SQLConn.State <> ConnectionState.Open Then ReConectar("AppTextilana")
    '    'creo conexion para leer dbf
    '    Dim ConnStringH As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\bases" + " ;Extended Properties=dBASE IV;User ID=Admin;Password="
    '    Dim DBFConnH As New OleDbConnection(ConnStringH)
    '    DBFConnH.Open()

    '    sstr = "DELETE HilamarHiladoStock"
    '    Command2 = New SqlCommand(sstr, cConexionApp.SQLConn)
    '    Command2.ExecuteNonQuery()

    '    sstr = "SELECT * FROM HILSTOCK ORDER BY PARTIS"
    '    Dim DBFCommandH As OleDbCommand = New OleDbCommand(sstr, DBFConnH)
    '    Dim DBFDataReaderH As OleDbDataReader = DBFCommandH.ExecuteReader(CommandBehavior.Default)
    '    Do While DBFDataReaderH.Read
    '        'CodParti = CompletarCaracteresIzquierda(DBFDataReaderH("PARTIS").ToString, 8, "0").ToString
    '        Kilos = DBFDataReaderH("KILOS").ToString
    '        Kilos = Replace(Kilos, ",", ".").ToString
    '        Color = DBFDataReaderH("COLORS").ToString
    '        If Color <> "" Then Color = Replace(Color, "'", " ").ToString
    '        CodColor = DBFDataReaderH("NUMCOS").ToString
    '        If CodColor <> "" Then CodColor = Replace(CodColor, "'", " ").ToString
    '        PCardado = DBFDataReaderH("KILPRO").ToString
    '        If PCardado <> "" Then PCardado = Replace(PCardado, "'", " ").ToString
    '        sstr = "INSERT INTO HilamarHiladoStock (Partida, CodTipoHilado, Kilos, Color, Eliminado, Auditoria, CodColor, PCardado) VALUES ('"
    '        sstr = sstr + DBFDataReaderH("PARTIS").ToString.ToString + "', '" + DBFDataReaderH("CODIS").ToString + "', " + Kilos.ToString + ", '" + Color.ToString
    '        sstr = sstr + "', 0, 'ALTA | " + Now.ToString + "','" + CodColor + "','" + PCardado + "')"
    '        Command2 = New SqlCommand(sstr, cConexionApp.SQLConn)
    '        Command2.ExecuteNonQuery()
    '    Loop

    '    FormProgre.lblEstado.Text = "Actualizando Tipos de Hilados ..."
    '    FormProgre.CantProg = FormProgre.CantProg + 1
    '    FormProgre.Actualizar()

    '    sstr = "DELETE HilamarTipoHiladoPartidas"
    '    Command2 = New SqlCommand(sstr, cConexionApp.SQLConn)
    '    Command2.ExecuteNonQuery()

    '    sstr = "SELECT * FROM TIPOHILA ORDER BY CODI"
    '    DBFCommandH = New OleDbCommand(sstr, DBFConnH)
    '    DBFDataReaderH = DBFCommandH.ExecuteReader(CommandBehavior.Default)
    '    Do While DBFDataReaderH.Read
    '        sstr = "INSERT INTO HilamarTipoHiladoPartidas (Codigo, Descripcion, Eliminado, Auditoria, Proveedor) VALUES ('"
    '        sstr = sstr + DBFDataReaderH("CODI").ToString.ToString + "', '" + DBFDataReaderH("TIPO").ToString + "'"
    '        sstr = sstr + ", 0, 'ALTA | " + Now.ToString + "','" + DBFDataReaderH("PROVE").ToString + "')"
    '        Command2 = New SqlCommand(sstr, cConexionApp.SQLConn)
    '        Command2.ExecuteNonQuery()
    '    Loop

    '    DBFConnH.Close()

    '    'cuando termino todo actualizo las fechas de ultima modificacion de los archivos del unix en la base de datos
    '    UltFechaUnixHilStockServer = My.Computer.FileSystem.GetFileInfo("\\192.168.0.12\u\hilamar\sto\hilstock.dbf").LastWriteTime
    '    UltFechaUnixTipoHilaServer = My.Computer.FileSystem.GetFileInfo("\\192.168.0.12\u\hilamar\sto\tipohila.dbf").LastWriteTime
    '    sstr = "UPDATE HilamarConfigSistema set UltFechaUnixHilStock = '" + Format(UltFechaUnixHilStockServer, "yyyyMMdd HH:mm:ss.fff") + "'"
    '    Command2 = New SqlCommand(sstr, cConexionApp.SQLConn)
    '    Command2.ExecuteNonQuery()
    '    sstr = "UPDATE HilamarConfigSistema set UltFechaUnixTipoHila = '" + Format(UltFechaUnixTipoHilaServer, "yyyyMMdd HH:mm:ss.fff") + "'"
    '    Command2 = New SqlCommand(sstr, cConexionApp.SQLConn)
    '    Command2.ExecuteNonQuery()

    '    FormProgre.Close()

    '    MensajeInfo("Actualización correcta.")

    'End Sub

    'Private Sub ListadodeMovimientosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadodeMovimientosToolStripMenuItem.Click
    '    If FormAbierto(frmListado) Then Exit Sub

    '    Dim FormListadoHilado As New frmBorrarRepoHiladoIngMovimientos
    '    FormListadoHilado.CargarListado()
    '    FormListadoHilado.Show()

    'End Sub

    Private Sub ExistenciasdeHiladosTextilanaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExistenciasdeHiladosTextilanaToolStripMenuItem.Click
        Dim FormRepoHiladoTextiStock As New frmRepoHiladoTextiStock(LegajoLogueado, TipoUsuario)
        If FormAbierto(FormRepoHiladoTextiStock) Then Exit Sub
        FormRepoHiladoTextiStock.Show()
    End Sub

    Private Sub SobrantesDeHiladosTextiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SobrantesDeHiladosTextiToolStripMenuItem.Click
        Dim FormRepoHiladoTextiSobra As New frmRepoHiladoTextiSobra(LegajoLogueado, TipoUsuario)
        If FormAbierto(FormRepoHiladoTextiSobra) Then Exit Sub
        FormRepoHiladoTextiSobra.Show()
    End Sub

    Private Sub ABMIngresoSobranteHiladoTextiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ABMIngresoSobranteHiladoTextiToolStripMenuItem.Click
        Dim formABMTextiSobranteHilado As New frmABMTextiSobranteHilado(LegajoLogueado, TipoUsuario)
        If FormAbierto(formABMTextiSobranteHilado) Then Exit Sub
        formABMTextiSobranteHilado.Alta = True
        formABMTextiSobranteHilado.Cargar()
        formABMTextiSobranteHilado.ShowDialog()
    End Sub

    Private Sub CambiarDeUsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambiarDeUsuarioToolStripMenuItem.Click
        Dim FormCambioUsuario As New frmCambioUsuario()
        FormCambioUsuario.ShowDialog(Me)
        If FormCambioUsuario.UsuarioOK Then
            LegajoLogueado = FormCambioUsuario.LegajoLogueado
            TipoUsuario = FormCambioUsuario.TipoUsuario
            FormCambioUsuario.Dispose()

            For Each frm As Form In Me.OwnedForms
                frm.Close()
            Next
            Cargar()
        Else
            FormCambioUsuario.Dispose()
        End If

    End Sub

    'Private Sub ReporteTotalesIngresadosaPlantaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteTotalesIngresadosaPlantaToolStripMenuItem.Click
    '    If FormAbierto(frmListado) Then Exit Sub
    '    Dim formRepoHiladoIngRepoTotales As New frmBorrarRepoHiladoIngRepoTotales
    '    formRepoHiladoIngRepoTotales.Cargar()
    '    formRepoHiladoIngRepoTotales.Show()
    'End Sub

    Private Sub ConfiguraciónSistemaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfiguraciónSistemaToolStripMenuItem.Click
        Dim formConfigHilamar As New frmConfigHilamar
        formConfigHilamar.Show()
    End Sub

    Private Sub ABMHiladosInternosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ABMHiladosInternosToolStripMenuItem.Click
        If FormAbierto(frmListado) Then Exit Sub

        Dim FormHilado As New frmListado
        FormHilado.Pantalla = "HiladoInterno"
        FormHilado.Cargar()
        FormHilado.Show()

    End Sub

    Private Sub CostosParametrosGralesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CostosParametrosGralesToolStripMenuItem.Click
        Dim formCostosConfigParametros As New frmCostosConfigParametros
        formCostosConfigParametros.Show()
    End Sub

    Private Sub CompCostosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompCostosToolStripMenuItem.Click
        If FormAbierto(frmABMComposCostos) Then Exit Sub
        Dim formABMComposCostos As New frmABMComposCostos
        formABMComposCostos.Cargar()
        formABMComposCostos.Show()
    End Sub

    Private Sub ReportedeCostosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportedeCostosToolStripMenuItem.Click
        If FormAbierto(frmCostosReporte) Then Exit Sub
        Dim formCostosReporte As New frmCostosReporte
        formCostosReporte.Show()
    End Sub

    Private Sub ArtProdABMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArtProdABMToolStripMenuItem.Click
        Dim formArtProdABM As New frmArtProdABM(LegajoLogueado, TipoUsuario)
        If FormAbierto(formArtProdABM) Then Exit Sub

        formArtProdABM.Alta = True
        formArtProdABM.Cargar()
        formArtProdABM.Show()
    End Sub

    Private Sub ListadoDeArtEnProdToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDeArtEnProdToolStripMenuItem.Click
        Dim formArtProdListado As New frmArtProdListado(LegajoLogueado, TipoUsuario)
        If FormAbierto(formArtProdListado) Then Exit Sub
        formArtProdListado.Show()
    End Sub

    Private Sub CambiarMiContraseñaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambiarMiContraseñaToolStripMenuItem.Click
        Dim formCambioContraseña As New frmCambioContraseña(LegajoLogueado)
        formCambioContraseña.Cargar()
        formCambioContraseña.ShowDialog(Me)

    End Sub

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If UCase(Environment.MachineName) = "MANTENIMIENTO" Or Strings.Left(UCase(Environment.MachineName), 8) = "COMPUTOS" Then
            btnImpresorEtiquetas.Visible = True
        Else
            btnImpresorEtiquetas.Visible = False
        End If

        revisoDatoUltimaFechaActualizacionTareas()
        'FechaInicioPrograma = "20190829"

        tmrRevisoHilaManteActividades.Enabled = True

        'ActualizarPartidasUNIX()

        CargarVariables(False)
        Cargar()
        If TipoUsuario = "Jefe-Mant" Or TipoUsuario = "HilaAdmin" Or TipoUsuario = "TextiEmpleado" Or TipoUsuario = "Jefe-Hilam" Then
            tmrAlertas.Enabled = False
            lblAlertasCC.Visible = False
            lblTituloAlertas.Visible = False
        Else
            tmrAlertas.Enabled = True
            lblAlertasCC.Text = ComprobarAlertasCC().ToString
        End If
    End Sub

    Private Sub revisoDatoUltimaFechaActualizacionTareas()
        If Not My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Hilamar", "FechaUltimaActTareasMant", Nothing) Is Nothing Then
            FechaUltimaActualizaciondeTareasMant = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Hilamar", "FechaUltimaActTareasMant", Nothing).ToString
        End If
    End Sub

    Private Sub guardarDatoUltimaFechaActualizacionTareas()
        'Si no esta, lo creo
        If Not My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Hilamar", "FechaUltimaActTareasMant", Nothing) Is Nothing Then
            My.Computer.Registry.CurrentUser.CreateSubKey("HKEY_CURRENT_USER\Software\Hilamar")
        End If
        ' guardo el nuevo valor
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Hilamar", "FechaUltimaActTareasMant", FechaUltimaActualizaciondeTareasMant)

    End Sub

    Private Sub ExistenciasDeHiladosHilamarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExistenciasDeHiladosHilamarToolStripMenuItem.Click
        Dim FormRepoHiladosStock As New frmHilaRepoHiladosStock(LegajoLogueado, TipoUsuario)
        If FormAbierto(FormRepoHiladosStock) Then Exit Sub
        FormRepoHiladosStock.Show()
    End Sub

    Private Sub ExistenciaDeMateriaPrimaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExistenciaDeMateriaPrimaToolStripMenuItem.Click
        Dim formRepoMatPrimaStock As New frmRepoMatPrimaStock(LegajoLogueado, TipoUsuario)
        If FormAbierto(formRepoMatPrimaStock) Then Exit Sub
        formRepoMatPrimaStock.Show()
    End Sub

    Private Sub MantABMMaquinasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantABMMaquinasToolStripMenuItem.Click
        Dim formABMMaquinas As New frmABMMaquinas()
        If FormAbierto(formABMMaquinas) Then Exit Sub
        formABMMaquinas.Show()
    End Sub

    Private Sub ABMSectoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ABMSectoresToolStripMenuItem.Click
        Dim formABMSectores As New frmABMSectores()
        If FormAbierto(formABMSectores) Then Exit Sub
        formABMSectores.Show()
    End Sub

    Private Sub ABMTareasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ABMTareasToolStripMenuItem.Click
        Dim formABMTareas As New frmABMTareas()
        If FormAbierto(formABMTareas) Then Exit Sub
        formABMTareas.Show()
    End Sub

    Private Sub ABMRecursosParaTareasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ABMRecursosParaTareasToolStripMenuItem.Click
        Dim formABMRecursosTareas As New frmABMRecursosTareas()
        If FormAbierto(formABMRecursosTareas) Then Exit Sub
        formABMRecursosTareas.Show()
    End Sub

    Private Sub tmrAlertas_Tick(sender As Object, e As EventArgs) Handles tmrAlertas.Tick
        lblAlertasCC.Text = ComprobarAlertasCC().ToString
    End Sub

    Private Sub lblAlertasCC_Click(sender As Object, e As EventArgs) Handles lblAlertasCC.Click
        If lblAlertasCC.Text <> "" Then
            Dim FormRepo As New frmRepoCC
            FormRepo.Alerta = True
            FormRepo.Cargar()
            FormRepo.ShowDialog()
        End If
    End Sub

    Private Sub ABMPlanesDeMantenimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ABMPlanesDeMantenimientoToolStripMenuItem.Click
        Dim formABMPlanMantenimiento As New frmABMPlanMantenimiento(LegajoLogueado, TipoUsuario)
        If FormAbierto(formABMPlanMantenimiento) Then Exit Sub
        formABMPlanMantenimiento.Show()
    End Sub

    Private Sub RevisarVencimientosTareasPlanMantenimiento()
        Dim sStr As String
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        'Dim row As String()

        'primero que nada busco la ultima fecha que hizo el control de vencimientos de tareas
        Dim UltimaFechaVerif As Date
        sStr = "select UltimaFechaVerifTareasPlanMant from HilamarConfigSistema"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        If Reader.HasRows Then
            If Reader.Read() Then
                UltimaFechaVerif = Reader.Item("UltimaFechaVerifTareasPlanMant")
            End If
        End If
        'AGARRO LA FECHA DE HOY
        Dim FechaHoy As Date = Format(ObtenerFechaServer(), "dd/MM/yyyy")

        Dim FormProgre As New frmProgreso
        FormProgre.CantMax = DateDiff(DateInterval.Day, UltimaFechaVerif, FechaHoy) + 1
        FormProgre.lblTarea.Text = "Actualizando Listado de Tareas de Mantenimiento"
        FormProgre.lblEstado.Text = "Iniciando proceso ..."
        FormProgre.Cargar()
        FormProgre.Show()
        FormProgre.CantProg = 0
        FormProgre.Actualizar()

        'y mientras que la ultima fecha sea menor a hoy corro el proceso para ir armando los vencimientos que no se corrieron
        Do While UltimaFechaVerif <= FechaHoy
            FormProgre.lblEstado.Text = "Revisando la fecha " + Format(UltimaFechaVerif, "dd/MM/yyyy") + " ..."
            FormProgre.CantProg = FormProgre.CantProg + 1
            FormProgre.Actualizar()

            ControlarVencimientosTareasPlanMant(Format(UltimaFechaVerif, "dd/MM/yyyy"))

            'updateo la fecha con el dia ejecutado
            sStr = "UPDATE HilamarConfigSistema SET UltimaFechaVerifTareasPlanMant='" + Format(UltimaFechaVerif, "yyyyMMdd") + "' "
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()

            UltimaFechaVerif = UltimaFechaVerif.AddDays(1)
        Loop

        FormProgre.Close()
    End Sub

    Private Sub ControlarVencimientosTareasPlanMant(ByVal FechaHoy As Date)
        Dim sStr, sStrAux, sStr1 As String
        Dim Command, CommandAux, Command1 As New SqlCommand
        Dim Reader, ReaderAux, Reader1 As SqlDataReader
        Dim DioDeAltaUna As Boolean = False

        Dim ListaDeDiasPermitidos As String = ""

        Dim FechaDesdeFrecuencia As Date
        Dim Frecuencia As String

        Dim IntervalType As DateInterval
        Dim cantIntervalType As Integer
        Dim FechaAux As Date

        'sStr = "select * from HilaMantePlanMaquinasTareas where IdMaquina=56 "
        'sStr = " SELECT * FROM HilaMantePlanMaquinasTareas WHERE IdMaquina IN (SELECT ID FROM HilaManteMaquinas WHERE IDSECTOR IN (SELECT ID FROM HilaManteSectores WHERE Fabrica='textilana'))"
        sStr = "select * from HilaMantePlanMaquinasTareas "
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Do While Reader.HasRows
            Do While Reader.Read()
                ListaDeDiasPermitidos = ""
                'If Reader.Item("Lunes") = "1" Then ListaDeDiasPermitidos = ListaDeDiasPermitidos + ",MONDAY"
                'If Reader.Item("Martes") = "1" Then ListaDeDiasPermitidos = ListaDeDiasPermitidos + ",TUESDAY"
                'If Reader.Item("Miercoles") = "1" Then ListaDeDiasPermitidos = ListaDeDiasPermitidos + ",WEDNESDAY"
                'If Reader.Item("Jueves") = "1" Then ListaDeDiasPermitidos = ListaDeDiasPermitidos + ",THURSDAY"
                'If Reader.Item("Viernes") = "1" Then ListaDeDiasPermitidos = ListaDeDiasPermitidos + ",FRIDAY"
                'If Reader.Item("Sabado") = "1" Then ListaDeDiasPermitidos = ListaDeDiasPermitidos + ",SATURDAY"
                'If Reader.Item("Domingo") = "1" Then ListaDeDiasPermitidos = ListaDeDiasPermitidos + ",SUNDAY"
                If Reader.Item("Lunes") = "1" Then ListaDeDiasPermitidos = ListaDeDiasPermitidos + ",LUNES"
                If Reader.Item("Martes") = "1" Then ListaDeDiasPermitidos = ListaDeDiasPermitidos + ",MARTES"
                If Reader.Item("Miercoles") = "1" Then ListaDeDiasPermitidos = ListaDeDiasPermitidos + ",MIÉRCOLES"
                If Reader.Item("Jueves") = "1" Then ListaDeDiasPermitidos = ListaDeDiasPermitidos + ",JUEVES"
                If Reader.Item("Viernes") = "1" Then ListaDeDiasPermitidos = ListaDeDiasPermitidos + ",VIERNES"
                If Reader.Item("Sabado") = "1" Then ListaDeDiasPermitidos = ListaDeDiasPermitidos + ",SÁBADO"
                If Reader.Item("Domingo") = "1" Then ListaDeDiasPermitidos = ListaDeDiasPermitidos + ",DOMINGO"

                FechaDesdeFrecuencia = Format(Reader.Item("APartirDe"), "dd/MM/yyyy")
                Frecuencia = Reader.Item("FrecuenciaTarea")

                If Frecuencia = "Semanal" Then
                    IntervalType = DateInterval.Day
                    cantIntervalType = 7
                ElseIf Frecuencia = "Diaria" Then
                    IntervalType = DateInterval.Day
                    cantIntervalType = 1
                ElseIf Frecuencia = "Mensual" Then
                    IntervalType = DateInterval.Month
                    cantIntervalType = 1
                ElseIf Frecuencia = "Bimestral" Then
                    IntervalType = DateInterval.Month
                    cantIntervalType = 2
                ElseIf Frecuencia = "Trimestral" Then
                    IntervalType = DateInterval.Month
                    cantIntervalType = 3
                ElseIf Frecuencia = "Cuatrimestral" Then
                    IntervalType = DateInterval.Month
                    cantIntervalType = 4
                ElseIf Frecuencia = "Semestral" Then
                    IntervalType = DateInterval.Month
                    cantIntervalType = 6
                ElseIf Frecuencia = "Anual" Then
                    IntervalType = DateInterval.Year
                    cantIntervalType = 1
                ElseIf Frecuencia = "Cada 2 años" Then
                    IntervalType = DateInterval.Year
                    cantIntervalType = 2
                ElseIf Frecuencia = "Cada 3 años" Then
                    IntervalType = DateInterval.Year
                    cantIntervalType = 3
                ElseIf Frecuencia = "Cada 4 años" Then
                    IntervalType = DateInterval.Year
                    cantIntervalType = 4
                ElseIf Frecuencia = "Cada 5 años" Then
                    IntervalType = DateInterval.Year
                    cantIntervalType = 5
                End If

                'primero controlo que la tarea tenga algun dia permitido, porque si no es de gusto tratar de generar actividades
                If ListaDeDiasPermitidos.Length > 0 Then

                    'primero que nada controlo que la tarea no tenga aun pendiente por realizar alguna , porque entonces no hago nada hasta que no este terminada la tarea pendiente
                    sStr1 = "select count(*) as cant from HilaManteListadoActividades where IdMaqTarea = " + Reader.Item("Id").ToString + " and Eliminado = 0 and estado<>'CUMPLIDA' "
                    Command1 = New SqlCommand(sStr1, cConexionApp.SQLConn)
                    Reader1 = Command1.ExecuteReader()
                    Reader1.Read()
                    If Reader1.Item("CANT") <= 0 Then

                        'agarro la ultima fecha de actividad que tiene cargada la tarea
                        'sStrAux = "select isnull(max(Fecha),'19000101') as Fecha from HilaManteListadoActividades where IdMaqTarea = " + Reader.Item("Id").ToString + " and Eliminado = 0 "
                        sStrAux = "select isnull( CONVERT(VARCHAR(10), max(hist.Fecha), 103),'19000101') as Fecha "
                        sStrAux = sStrAux + " from HilaManteListadoActividades ACT INNER JOIN HilaManteActiHistorial HIST ON ACT.Id = HIST.IdActividad  "
                        sStrAux = sStrAux + " where IdMaqTarea = " + Reader.Item("Id").ToString + " and ACT.Eliminado = 0 and HIST.Estado ='CUMPLIDA'"
                        CommandAux = New SqlCommand(sStrAux, cConexionApp.SQLConn)
                        ReaderAux = CommandAux.ExecuteReader()
                        ReaderAux.Read()
                        If ReaderAux.Item("Fecha").ToString = "19000101" Then
                            FechaAux = FechaDesdeFrecuencia
                        Else
                            FechaAux = ReaderAux.Item("Fecha")
                        End If

                        'primero saco cual es vencimiento que corresponde
                        'FechaAux = FechaDesdeFrecuencia
                        DioDeAltaUna = False
                        Do While FechaAux <= FechaHoy And Not DioDeAltaUna
                            'controlo que el dia de la fecha este permitido por los tildes
                            Do While InStr(ListaDeDiasPermitidos, UCase(Format(FechaAux, "dddd"))) <= 0
                                FechaAux = DateAdd(DateInterval.Day, 1, FechaAux)
                            Loop
                            'A PARTIR DE LA FECHAAUX BUSCO LA PROXIMA
                            FechaAux = DateAdd(IntervalType, cantIntervalType, FechaAux)
                            If FechaAux <= FechaHoy Then If RevisarAvisosVencimientos(Reader.Item("Id").ToString, FechaAux) = 1 Then DioDeAltaUna = True
                        Loop

                    End If

                    'FechaVencimiento = FechaAux
                    'If DateDiff(DateInterval.Day, FechaHoy, FechaVencimiento) <= 0 Then
                    '    RevisarAvisosVencimientos(Reader.Item("IdMaquina"), Reader.Item("IdTarea"), FechaVencimiento)
                    'End If
                End If

            Loop
            Reader.NextResult()
        Loop

    End Sub

    Public Function RevisarAvisosVencimientos(ByVal IdMaquinaTarea As String, ByVal Fecha As Date) As Integer
        Dim sStr As String
        Dim Command As New SqlCommand
        Dim Reader As SqlDataReader
        Dim IdActividadParaGrabar As String = ""
        Dim retorno As Integer = 0

        'primero que nada si ya ESTA CARGADO
        sStr = "SELECT COUNT(*) AS canti FROM HilaManteListadoActividades " + _
               "WHERE IdMaqTarea = " + IdMaquinaTarea + " AND Eliminado = 0 AND FECHA = '" + Format(Fecha, "yyyyMMdd") + "'"
        Command = New SqlCommand(sStr, cConexionApp.SQLConn)
        Reader = Command.ExecuteReader()
        Reader.Read()
        If CInt(Reader.Item("canti").ToString) <= 0 Then
            ' si no existe, lo creo 
            sStr = "INSERT INTO HilaManteListadoActividades "
            sStr = sStr + "(IdMaqTarea,Fecha,Estado,Eliminado,Observaciones) "
            sStr = sStr + "VALUES "
            sStr = sStr + "(" + IdMaquinaTarea + ",'" + Fecha + "','ALTA',0,'')"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()
            'agarro el id para insertarlo en el historial
            sStr = "SELECT max(Id) as Id FROM HilaManteListadoActividades WHERE Eliminado = 0 AND IdMaqTarea = " + IdMaquinaTarea + " "
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Reader = Command.ExecuteReader()
            If Reader.HasRows Then
                If Reader.Read() Then
                    IdActividadParaGrabar = Reader.Item("Id").ToString
                End If
            End If
            ' ademas agrego el inicio del historial
            sStr = "INSERT INTO HilaManteActiHistorial "
            sStr = sStr + "(IdActividad, Fecha, Estado, Legajo, Observaciones, Eliminado) "
            sStr = sStr + "VALUES "
            sStr = sStr + "(" + IdActividadParaGrabar + ", GETDATE(), 'ALTA', '" + LegajoLogueado + "', '', 0)"
            Command = New SqlCommand(sStr, cConexionApp.SQLConn)
            Command.ExecuteNonQuery()
            retorno = 1
        End If

        Return retorno
    End Function

    Private Sub RevisarTareasDePlanesDeMantenimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RevisarTareasDePlanesDeMantenimientoToolStripMenuItem.Click
        RevisarVencimientosTareasPlanMantenimiento()
    End Sub

    Private Sub ListadoDeTareasDeMantenimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDeTareasDeMantenimientoToolStripMenuItem.Click
        Dim formRepoPlanMantenimiento As New frmRepoPlanMantenimiento(LegajoLogueado)
        If FormAbierto(formRepoPlanMantenimiento) Then Exit Sub
        formRepoPlanMantenimiento.Show()
    End Sub

    Private Sub ABMUsuariosTabletToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ABMUsuariosTabletToolStripMenuItem.Click
        Dim formABMUsuariosTablet As New frmABMUsuariosTablet()
        If FormAbierto(formABMUsuariosTablet) Then Exit Sub
        formABMUsuariosTablet.Show()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles HilaABMHiladosToolStripMenuItem.Click
        Dim formHilaABMHilados As New frmHilaABMHilados()
        If FormAbierto(formHilaABMHilados) Then Exit Sub
        formHilaABMHilados.Show()
    End Sub

    Private Sub ABMPartidasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ABMPartidasToolStripMenuItem.Click
        Dim formHilaABMPartidas As New frmHilaABMPartidas()
        If FormAbierto(formHilaABMPartidas) Then Exit Sub
        formHilaABMPartidas.Show()
    End Sub

    Private Sub HilamarHiladosEgresosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HilamarHiladosEgresosToolStripMenuItem.Click
        Dim formHilaRemitoEgreso As New frmHilaRemitoEgreso(LegajoLogueado, TipoUsuario)
        If FormAbierto(formHilaRemitoEgreso) Then Exit Sub
        formHilaRemitoEgreso.Show()
    End Sub

    Private Sub HilamarHiladosIngresosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HilamarHiladosIngresosToolStripMenuItem.Click
        Dim formHilaRemitoIngreso As New frmHilaRemitoIngreso(LegajoLogueado, TipoUsuario)
        If FormAbierto(formHilaRemitoIngreso) Then Exit Sub
        formHilaRemitoIngreso.Show()
    End Sub

    Private Sub HilamarHiladosListadoDeMovimientosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HilamarHiladosListadoDeMovimientosToolStripMenuItem.Click
        Dim formHilaRepoMovimHilados As New frmHilaRepoMovimHilados()
        If FormAbierto(formHilaRepoMovimHilados) Then Exit Sub
        formHilaRepoMovimHilados.Show()
    End Sub

    Private Sub HilamarHiladosConsumosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HilamarHiladosConsumosToolStripMenuItem.Click
        Dim formHilaRemitoConsumo As New frmHilaRemitoConsumo(LegajoLogueado, TipoUsuario)
        If FormAbierto(formHilaRemitoConsumo) Then Exit Sub
        formHilaRemitoConsumo.Show()
    End Sub

    Private Sub HilaReporteDeIngresosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HilaReporteDeIngresosToolStripMenuItem.Click
        Dim formHilaRepoIngyConsu As New frmHilaRepoIngyConsu("ingresos")
        If FormAbierto(formHilaRepoIngyConsu) Then Exit Sub
        formHilaRepoIngyConsu.Show()
    End Sub

    Private Sub ReporteDeConsumosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeConsumosToolStripMenuItem.Click
        Dim formHilaRepoIngyConsu As New frmHilaRepoIngyConsu("consumos")
        If FormAbierto(formHilaRepoIngyConsu) Then Exit Sub
        formHilaRepoIngyConsu.Show()
    End Sub

    Private Sub ReporteDeHiladosDiscontinuosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeHiladosDiscontinuosToolStripMenuItem.Click
        Dim formHilaRepoDiscontinuos As New frmHilaRepoDiscontinuos()
        If FormAbierto(formHilaRepoDiscontinuos) Then Exit Sub
        formHilaRepoDiscontinuos.Show()
    End Sub

    Private Sub RevisarActividaddeMantenimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RevisarActividaddeMantenimientoToolStripMenuItem.Click
        Dim formRepoRevisarActividadMant As New frmRepoRevisarActividadMant()
        If FormAbierto(formRepoRevisarActividadMant) Then Exit Sub
        formRepoRevisarActividadMant.Show()
    End Sub

    Dim TipoPlanillaImpVacia As String = ""
    Private Sub ImprimirPlanillaVacíaSHIMAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirPlanillaVacíaSHIMAToolStripMenuItem.Click
        TipoPlanillaImpVacia = "SHIMA"
        ImprimirPlanillaVacia()
    End Sub

    Private Sub ImprimirPlanillaVacíaSTOLLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirPlanillaVacíaSTOLLToolStripMenuItem.Click
        TipoPlanillaImpVacia = "STOLL"
        ImprimirPlanillaVacia()
    End Sub

    Private Sub ImprimirPlanillaVacia()
        pdoImpPlanillaVacia.DefaultPageSettings.Landscape = False
        pdoImpPlanillaVacia.DefaultPageSettings.Margins.Left = 20
        pdoImpPlanillaVacia.DefaultPageSettings.Margins.Right = 20
        pdoImpPlanillaVacia.DefaultPageSettings.Margins.Top = 20
        pdoImpPlanillaVacia.DefaultPageSettings.Margins.Bottom = 20
        pdoImpPlanillaVacia.OriginAtMargins = True ' takes margins into account 

        'Dim dlgPrintPreview As New EnhancedPrintPreviewDialog
        'dlgPrintPreview.ClientSize = New System.Drawing.Size(600, 600)
        'dlgPrintPreview.Document = pdoImpPlanillaVacia ' Previews print
        'dlgPrintPreview.ShowDialog()

        pdoImpPlanillaVacia.Print()

    End Sub

    Private Sub pdoImpPlanillaVacia_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles pdoImpPlanillaVacia.PrintPage
        On Error Resume Next

        Dim LapizMarcador As New Pen(Brushes.Black)

        Dim FuenteLineas As Font = New Drawing.Font("Arial", 10, FontStyle.Regular)
        Dim FuenteLineasN As Font = New Drawing.Font("Arial", 10, FontStyle.Bold)
        Dim FuenteLineas9 As Font = New Drawing.Font("Arial", 9, FontStyle.Regular)
        Dim FuenteLineas9N As Font = New Drawing.Font("Arial", 9, FontStyle.Bold)
        Dim FuenteLineas8 As Font = New Drawing.Font("Arial", 8, FontStyle.Regular)
        Dim FuenteLineas8N As Font = New Drawing.Font("Arial", 8, FontStyle.Bold)
        Dim FuenteLineas7 As Font = New Drawing.Font("Arial", 7, FontStyle.Regular)
        Dim FuenteLineas7N As Font = New Drawing.Font("Arial", 7, FontStyle.Bold)

        Dim LineasdeCorreciones, nTopPicos, nTopMallas, nTopCorr, nRowPos, UltimaFiladeCorreccionConDato As Integer
        Dim nTop As Int16 = e.MarginBounds.Top
        Dim AltoRenglon As Integer = 16

        ' Draw Header
        e.Graphics.DrawString("PLANILLA DE MEDIDAS Y MUESTRAS MAQUINA", FuenteLineas, Brushes.Black, 150, nTop)
        e.Graphics.DrawString(TipoPlanillaImpVacia, FuenteLineas, Brushes.Black, 550, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 750, AltoRenglon)
        nTop = nTop + AltoRenglon

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(20, nTop, 80, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 80, AltoRenglon)
        e.Graphics.DrawString("FECHA", FuenteLineas, Brushes.Black, 35, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(100, nTop, 70, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 70, AltoRenglon)
        e.Graphics.DrawString("DISEÑO", FuenteLineas, Brushes.Black, 105, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(170, nTop, 150, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 170, nTop, 150, AltoRenglon)
        e.Graphics.DrawString("COLOR", FuenteLineas, Brushes.Black, 210, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(320, nTop, 70, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 320, nTop, 70, AltoRenglon)
        e.Graphics.DrawString("PARTIDA", FuenteLineas, Brushes.Black, 325, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(390, nTop, 50, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 390, nTop, 50, AltoRenglon)
        e.Graphics.DrawString("V DEL", FuenteLineas, Brushes.Black, 395, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(440, nTop, 50, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 440, nTop, 50, AltoRenglon)
        e.Graphics.DrawString("V ESP", FuenteLineas, Brushes.Black, 445, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(490, nTop, 50, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 490, nTop, 50, AltoRenglon)
        e.Graphics.DrawString("V MAN", FuenteLineas, Brushes.Black, 492, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(540, nTop, 60, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 540, nTop, 60, AltoRenglon)
        e.Graphics.DrawString("V CAP", FuenteLineas, Brushes.Black, 545, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(600, nTop, 70, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 600, nTop, 70, AltoRenglon)
        e.Graphics.DrawString("OP", FuenteLineas, Brushes.Black, 615, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(670, nTop, 100, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 670, nTop, 100, AltoRenglon)
        e.Graphics.DrawString("ARTÍCULO", FuenteLineas, Brushes.Black, 680, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 80, AltoRenglon)
        'e.Graphics.DrawString(Format(dtpFecha.Value, "dd/MM/yyyy"), FuenteLineas, Brushes.Black, 25, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 70, AltoRenglon)
        'e.Graphics.DrawString(txtDiseño.Text, FuenteLineas, Brushes.Black, 105, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 170, nTop, 150, AltoRenglon)
        'e.Graphics.DrawString(txtColor.Text, FuenteLineas, Brushes.Black, 173, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 320, nTop, 70, AltoRenglon)
        'e.Graphics.DrawString(txtPartida.Text, FuenteLineas, Brushes.Black, 325, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 390, nTop, 50, AltoRenglon)
        'e.Graphics.DrawString(txtVentDel.Text, FuenteLineas, Brushes.Black, 395, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 440, nTop, 50, AltoRenglon)
        'e.Graphics.DrawString(txtVentEsp.Text, FuenteLineas, Brushes.Black, 445, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 490, nTop, 50, AltoRenglon)
        'e.Graphics.DrawString(txtVentMan.Text, FuenteLineas, Brushes.Black, 495, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 540, nTop, 60, AltoRenglon)
        'e.Graphics.DrawString(txtVentCap.Text, FuenteLineas, Brushes.Black, 545, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 600, nTop, 70, AltoRenglon)
        'e.Graphics.DrawString(txtOp.Text, FuenteLineas, Brushes.Black, 600, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 670, nTop, 100, AltoRenglon)
        'e.Graphics.DrawString(txtArticulo.Text, FuenteLineasN, Brushes.Black, 680, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 80, 144)
        e.Graphics.DrawString("Talle XXL", FuenteLineas9, Brushes.Black, 25, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 80, 144)
        e.Graphics.DrawString("Talle XL", FuenteLineas9, Brushes.Black, 105, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 180, nTop, 80, 144)
        e.Graphics.DrawString("Talle L", FuenteLineas9, Brushes.Black, 185, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 260, nTop, 80, 144)
        e.Graphics.DrawString("Talle M", FuenteLineas9, Brushes.Black, 265, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 340, nTop, 80, 144)
        e.Graphics.DrawString("Talle S", FuenteLineas9, Brushes.Black, 345, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 420, nTop, 80, 144)
        e.Graphics.DrawString("Talle XS", FuenteLineas9, Brushes.Black, 425, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 25, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(40, nTop, 30, AltoRenglon))
        'e.Graphics.DrawString(txtTalleXXL_D.Text, FuenteLineas9N, Brushes.Black, 45, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 70, nTop)

        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 105, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(120, nTop, 30, AltoRenglon))
        'e.Graphics.DrawString(txtTalleXL_D.Text, FuenteLineas9N, Brushes.Black, 125, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 150, nTop)

        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 185, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(200, nTop, 30, AltoRenglon))
        'e.Graphics.DrawString(txtTalleL_D.Text, FuenteLineas9N, Brushes.Black, 205, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 230, nTop)

        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 265, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(280, nTop, 30, AltoRenglon))
        'e.Graphics.DrawString(txtTalleM_D.Text, FuenteLineas9N, Brushes.Black, 285, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 310, nTop)

        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 345, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(360, nTop, 30, AltoRenglon))
        'e.Graphics.DrawString(txtTalleS_D.Text, FuenteLineas9N, Brushes.Black, 365, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 390, nTop)

        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 425, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(440, nTop, 30, AltoRenglon))
        'e.Graphics.DrawString(txtTalleXS_D.Text, FuenteLineas9N, Brushes.Black, 445, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 470, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 25, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(40, nTop, 30, AltoRenglon))
        'e.Graphics.DrawString(txtTalleXXL_E.Text, FuenteLineas9N, Brushes.Black, 45, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 70, nTop)

        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 105, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(120, nTop, 30, AltoRenglon))
        'e.Graphics.DrawString(txtTalleXL_E.Text, FuenteLineas9N, Brushes.Black, 125, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 150, nTop)

        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 185, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(200, nTop, 30, AltoRenglon))
        'e.Graphics.DrawString(txtTalleL_E.Text, FuenteLineas9N, Brushes.Black, 205, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 230, nTop)

        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 265, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(280, nTop, 30, AltoRenglon))
        'e.Graphics.DrawString(txtTalleM_E.Text, FuenteLineas9N, Brushes.Black, 285, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 310, nTop)

        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 345, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(360, nTop, 30, AltoRenglon))
        'e.Graphics.DrawString(txtTalleS_E.Text, FuenteLineas9N, Brushes.Black, 365, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 390, nTop)

        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 425, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(440, nTop, 30, AltoRenglon))
        'e.Graphics.DrawString(txtTalleXS_E.Text, FuenteLineas9N, Brushes.Black, 445, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 470, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawString("Capuch=", FuenteLineas8, Brushes.Black, 25, nTop)
        'e.Graphics.DrawString(txtTalleXXLBretel.Text, FuenteLineas9, Brushes.Black, 75, nTop)

        e.Graphics.DrawString("Capuch=", FuenteLineas8, Brushes.Black, 105, nTop)
        'e.Graphics.DrawString(txtTalleXLBretel.Text, FuenteLineas9, Brushes.Black, 155, nTop)

        e.Graphics.DrawString("Capuch=", FuenteLineas8, Brushes.Black, 185, nTop)
        'e.Graphics.DrawString(txtTalleLBretel.Text, FuenteLineas9, Brushes.Black, 235, nTop)

        e.Graphics.DrawString("Capuch=", FuenteLineas8, Brushes.Black, 265, nTop)
        'e.Graphics.DrawString(txtTalleMBretel.Text, FuenteLineas9, Brushes.Black, 315, nTop)

        e.Graphics.DrawString("Capuch=", FuenteLineas8, Brushes.Black, 345, nTop)
        'e.Graphics.DrawString(txtTalleSBretel.Text, FuenteLineas9, Brushes.Black, 395, nTop)

        e.Graphics.DrawString("Capuch=", FuenteLineas8, Brushes.Black, 425, nTop)
        'e.Graphics.DrawString(txtTalleXSBretel.Text, FuenteLineas9, Brushes.Black, 475, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawString("Esc=", FuenteLineas9, Brushes.Black, 25, nTop)
        'e.Graphics.DrawString(txtTalleXXLEsc.Text, FuenteLineas9, Brushes.Black, 75, nTop)

        e.Graphics.DrawString("Esc=", FuenteLineas9, Brushes.Black, 105, nTop)
        'e.Graphics.DrawString(txtTalleXLEsc.Text, FuenteLineas9, Brushes.Black, 155, nTop)

        e.Graphics.DrawString("Esc=", FuenteLineas9, Brushes.Black, 185, nTop)
        'e.Graphics.DrawString(txtTalleLEsc.Text, FuenteLineas9, Brushes.Black, 235, nTop)

        e.Graphics.DrawString("Esc=", FuenteLineas9, Brushes.Black, 265, nTop)
        'e.Graphics.DrawString(txtTalleMEsc.Text, FuenteLineas9, Brushes.Black, 315, nTop)

        e.Graphics.DrawString("Esc=", FuenteLineas9, Brushes.Black, 345, nTop)
        'e.Graphics.DrawString(txtTalleSEsc.Text, FuenteLineas9, Brushes.Black, 395, nTop)

        e.Graphics.DrawString("Esc=", FuenteLineas9, Brushes.Black, 425, nTop)
        'e.Graphics.DrawString(txtTalleXSEsc.Text, FuenteLineas9, Brushes.Black, 475, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawString("Bolsillo=", FuenteLineas9, Brushes.Black, 25, nTop)
        'e.Graphics.DrawString(txtTalleXXLBolsillo.Text, FuenteLineas9, Brushes.Black, 75, nTop)

        e.Graphics.DrawString("Bolsillo=", FuenteLineas9, Brushes.Black, 105, nTop)
        'e.Graphics.DrawString(txtTalleXLBolsillo.Text, FuenteLineas9, Brushes.Black, 155, nTop)

        e.Graphics.DrawString("Bolsillo=", FuenteLineas9, Brushes.Black, 185, nTop)
        'e.Graphics.DrawString(txtTalleLBolsillo.Text, FuenteLineas9, Brushes.Black, 235, nTop)

        e.Graphics.DrawString("Bolsillo=", FuenteLineas9, Brushes.Black, 265, nTop)
        'e.Graphics.DrawString(txtTalleMBolsillo.Text, FuenteLineas9, Brushes.Black, 315, nTop)

        e.Graphics.DrawString("Bolsillo=", FuenteLineas9, Brushes.Black, 345, nTop)
        'e.Graphics.DrawString(txtTalleSBolsillo.Text, FuenteLineas9, Brushes.Black, 395, nTop)

        e.Graphics.DrawString("Bolsillo=", FuenteLineas9, Brushes.Black, 425, nTop)
        'e.Graphics.DrawString(txtTalleXSBolsillo.Text, FuenteLineas9, Brushes.Black, 475, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawString("Ancho=", FuenteLineas9, Brushes.Black, 25, nTop)
        'e.Graphics.DrawString(txtTalleXXLAncho.Text, FuenteLineas9, Brushes.Black, 75, nTop)

        e.Graphics.DrawString("Ancho=", FuenteLineas9, Brushes.Black, 105, nTop)
        'e.Graphics.DrawString(txtTalleXLAncho.Text, FuenteLineas9, Brushes.Black, 155, nTop)

        e.Graphics.DrawString("Ancho=", FuenteLineas9, Brushes.Black, 185, nTop)
        'e.Graphics.DrawString(txtTalleLAncho.Text, FuenteLineas9, Brushes.Black, 235, nTop)

        e.Graphics.DrawString("Ancho=", FuenteLineas9, Brushes.Black, 265, nTop)
        'e.Graphics.DrawString(txtTalleMAncho.Text, FuenteLineas9, Brushes.Black, 315, nTop)

        e.Graphics.DrawString("Ancho=", FuenteLineas9, Brushes.Black, 345, nTop)
        'e.Graphics.DrawString(txtTalleSAncho.Text, FuenteLineas9, Brushes.Black, 395, nTop)

        e.Graphics.DrawString("Ancho=", FuenteLineas9, Brushes.Black, 425, nTop)
        'e.Graphics.DrawString(txtTalleXSAncho.Text, FuenteLineas9, Brushes.Black, 475, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawString("Largo=", FuenteLineas9, Brushes.Black, 25, nTop)
        'e.Graphics.DrawString(txtTalleXXLLargo.Text, FuenteLineas9, Brushes.Black, 75, nTop)

        e.Graphics.DrawString("Largo=", FuenteLineas9, Brushes.Black, 105, nTop)
        'e.Graphics.DrawString(txtTalleXLLargo.Text, FuenteLineas9, Brushes.Black, 155, nTop)

        e.Graphics.DrawString("Largo=", FuenteLineas9, Brushes.Black, 185, nTop)
        'e.Graphics.DrawString(txtTalleLLargo.Text, FuenteLineas9, Brushes.Black, 235, nTop)

        e.Graphics.DrawString("Largo=", FuenteLineas9, Brushes.Black, 265, nTop)
        'e.Graphics.DrawString(txtTalleMLargo.Text, FuenteLineas9, Brushes.Black, 315, nTop)

        e.Graphics.DrawString("Largo=", FuenteLineas9, Brushes.Black, 345, nTop)
        'e.Graphics.DrawString(txtTalleSLargo.Text, FuenteLineas9, Brushes.Black, 395, nTop)

        e.Graphics.DrawString("Largo=", FuenteLineas9, Brushes.Black, 425, nTop)
        'e.Graphics.DrawString(txtTalleXSLargo.Text, FuenteLineas9, Brushes.Black, 475, nTop)

        nTop = nTop + AltoRenglon

        'e.Graphics.DrawString(txtTalleXXL_CuerParamInicio.Text, FuenteLineasN, Brushes.Black, 25, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 50, nTop, 2, AltoRenglon)
        'e.Graphics.DrawString(txtTalleXXL_CuerCantAgujas.Text, FuenteLineasN, Brushes.Black, 60, nTop)

        'e.Graphics.DrawString(txtTalleXL_CuerParamInicio.Text, FuenteLineasN, Brushes.Black, 105, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 130, nTop, 2, AltoRenglon)
        'e.Graphics.DrawString(txtTalleXL_CuerCantAgujas.Text, FuenteLineasN, Brushes.Black, 140, nTop)

        'e.Graphics.DrawString(txtTalleL_CuerParamInicio.Text, FuenteLineasN, Brushes.Black, 185, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 210, nTop, 2, AltoRenglon)
        'e.Graphics.DrawString(txtTalleL_CuerCantAgujas.Text, FuenteLineasN, Brushes.Black, 220, nTop)

        'e.Graphics.DrawString(txtTalleM_CuerParamInicio.Text, FuenteLineasN, Brushes.Black, 265, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 290, nTop, 2, AltoRenglon)
        'e.Graphics.DrawString(txtTalleM_CuerCantAgujas.Text, FuenteLineasN, Brushes.Black, 300, nTop)

        'e.Graphics.DrawString(txtTalleS_CuerParamInicio.Text, FuenteLineasN, Brushes.Black, 345, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 370, nTop, 2, AltoRenglon)
        'e.Graphics.DrawString(txtTalleS_CuerCantAgujas.Text, FuenteLineasN, Brushes.Black, 380, nTop)

        'e.Graphics.DrawString(txtTalleXS_CuerParamInicio.Text, FuenteLineasN, Brushes.Black, 425, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 450, nTop, 2, AltoRenglon)
        'e.Graphics.DrawString(txtTalleXS_CuerCantAgujas.Text, FuenteLineasN, Brushes.Black, 460, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 480, AltoRenglon)
        e.Graphics.DrawString("MEDIDA ELÁSTICO=", FuenteLineas9, Brushes.Black, 25, nTop)
        'e.Graphics.DrawString(txtMedidaElastico.Text, FuenteLineas9, Brushes.Black, 160, nTop)
        e.Graphics.DrawString("CONDICIÓN CUERPOS=", FuenteLineas9, Brushes.Black, 250, nTop)
        'e.Graphics.DrawString(txtCondicionCuerpos.Text, FuenteLineas9, Brushes.Black, 400, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 480, AltoRenglon)
        e.Graphics.DrawString("VELOCIDAD CUERPOS=", FuenteLineas9, Brushes.Black, 25, nTop)
        'e.Graphics.DrawString(txtVelocidadCuerpos.Text, FuenteLineas9, Brushes.Black, 180, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 80, 48)
        e.Graphics.DrawString("MANGA", FuenteLineas9, Brushes.Black, 35, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 80, 48)
        e.Graphics.DrawString("MANGA", FuenteLineas9, Brushes.Black, 115, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 180, nTop, 80, 48)
        e.Graphics.DrawString("MANGA", FuenteLineas9, Brushes.Black, 195, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 260, nTop, 80, 48)
        e.Graphics.DrawString("MANGA", FuenteLineas9, Brushes.Black, 275, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 340, nTop, 80, 48)
        e.Graphics.DrawString("MANGA", FuenteLineas9, Brushes.Black, 355, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 420, nTop, 80, 48)
        e.Graphics.DrawString("MANGA", FuenteLineas9, Brushes.Black, 435, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(25, nTop, 45, AltoRenglon))
        'e.Graphics.DrawString(txtTalleXXL_Manga.Text, FuenteLineas9N, Brushes.Black, 40, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 70, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(105, nTop, 45, AltoRenglon))
        'e.Graphics.DrawString(txtTalleXL_Manga.Text, FuenteLineas9N, Brushes.Black, 120, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 150, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(185, nTop, 45, AltoRenglon))
        'e.Graphics.DrawString(txtTalleL_Manga.Text, FuenteLineas9N, Brushes.Black, 200, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 230, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(265, nTop, 45, AltoRenglon))
        'e.Graphics.DrawString(txtTalleM_Manga.Text, FuenteLineas9N, Brushes.Black, 280, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 310, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(345, nTop, 45, AltoRenglon))
        'e.Graphics.DrawString(txtTalleS_Manga.Text, FuenteLineas9N, Brushes.Black, 360, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 390, nTop)

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(425, nTop, 45, AltoRenglon))
        'e.Graphics.DrawString(txtTalleXS_Manga.Text, FuenteLineas9N, Brushes.Black, 440, nTop)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 470, nTop)

        nTop = nTop + AltoRenglon

        'e.Graphics.DrawString(txtTalleXXL_MangaParamInicio.Text, FuenteLineasN, Brushes.Black, 25, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 50, nTop, 2, AltoRenglon)
        'e.Graphics.DrawString(txtTalleXXL_MangaCantAgujas.Text, FuenteLineasN, Brushes.Black, 60, nTop)

        'e.Graphics.DrawString(txtTalleXL_MangaParamInicio.Text, FuenteLineasN, Brushes.Black, 105, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 130, nTop, 2, AltoRenglon)
        'e.Graphics.DrawString(txtTalleXL_MangaCantAgujas.Text, FuenteLineasN, Brushes.Black, 140, nTop)

        'e.Graphics.DrawString(txtTalleL_MangaParamInicio.Text, FuenteLineasN, Brushes.Black, 185, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 210, nTop, 2, AltoRenglon)
        'e.Graphics.DrawString(txtTalleL_MangaCantAgujas.Text, FuenteLineasN, Brushes.Black, 220, nTop)

        'e.Graphics.DrawString(txtTalleM_MangaParamInicio.Text, FuenteLineasN, Brushes.Black, 265, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 290, nTop, 2, AltoRenglon)
        'e.Graphics.DrawString(txtTalleM_MangaCantAgujas.Text, FuenteLineasN, Brushes.Black, 300, nTop)

        'e.Graphics.DrawString(txtTalleS_MangaParamInicio.Text, FuenteLineasN, Brushes.Black, 345, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 370, nTop, 2, AltoRenglon)
        'e.Graphics.DrawString(txtTalleS_MangaCantAgujas.Text, FuenteLineasN, Brushes.Black, 380, nTop)

        'e.Graphics.DrawString(txtTalleXS_MangaParamInicio.Text, FuenteLineasN, Brushes.Black, 425, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 450, nTop, 2, AltoRenglon)
        'e.Graphics.DrawString(txtTalleXS_MangaCantAgujas.Text, FuenteLineasN, Brushes.Black, 460, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 480, AltoRenglon)
        e.Graphics.DrawString("MEDIDA PUÑO=", FuenteLineas9, Brushes.Black, 25, nTop)
        'e.Graphics.DrawString(txtMedidaPuño.Text, FuenteLineas9, Brushes.Black, 150, nTop)
        e.Graphics.DrawString("CONDICIÓN MANGAS=", FuenteLineas9, Brushes.Black, 250, nTop)
        'e.Graphics.DrawString(txtCondicionMangas.Text, FuenteLineas9, Brushes.Black, 400, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 480, AltoRenglon)
        e.Graphics.DrawString("VELOCIDAD MANGAS=", FuenteLineas9, Brushes.Black, 25, nTop)
        'e.Graphics.DrawString(txtVelocidadMangas.Text, FuenteLineas9, Brushes.Black, 180, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 480, AltoRenglon)
        e.Graphics.DrawString("MEDIDAS INICIALES", FuenteLineas9, Brushes.Black, 200, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 23, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 40, nTop, 30, AltoRenglon)
        e.Graphics.DrawRectangle(Pens.Black, 70, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 72, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 103, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 120, nTop, 30, AltoRenglon)
        e.Graphics.DrawRectangle(Pens.Black, 150, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 152, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 180, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 183, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 200, nTop, 30, AltoRenglon)
        e.Graphics.DrawRectangle(Pens.Black, 230, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 232, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 260, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 263, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 280, nTop, 30, AltoRenglon)
        e.Graphics.DrawRectangle(Pens.Black, 310, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 312, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 340, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 343, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 360, nTop, 30, AltoRenglon)
        e.Graphics.DrawRectangle(Pens.Black, 390, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 392, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 420, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 423, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 440, nTop, 30, AltoRenglon)
        e.Graphics.DrawRectangle(Pens.Black, 470, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 472, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 23, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 40, nTop, 30, AltoRenglon)
        e.Graphics.DrawRectangle(Pens.Black, 70, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 72, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 103, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 120, nTop, 30, AltoRenglon)
        e.Graphics.DrawRectangle(Pens.Black, 150, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 152, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 180, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 183, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 200, nTop, 30, AltoRenglon)
        e.Graphics.DrawRectangle(Pens.Black, 230, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 232, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 260, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 263, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 280, nTop, 30, AltoRenglon)
        e.Graphics.DrawRectangle(Pens.Black, 310, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 312, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 340, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 343, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 360, nTop, 30, AltoRenglon)
        e.Graphics.DrawRectangle(Pens.Black, 390, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 392, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 420, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("E", FuenteLineas9, Brushes.Black, 423, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 440, nTop, 30, AltoRenglon)
        e.Graphics.DrawRectangle(Pens.Black, 470, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 472, nTop)

        nTop = nTop + AltoRenglon

        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("M", FuenteLineas9, Brushes.Black, 23, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 40, nTop, 30, AltoRenglon)
        e.Graphics.DrawRectangle(Pens.Black, 70, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 72, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("M", FuenteLineas9, Brushes.Black, 103, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 120, nTop, 30, AltoRenglon)
        e.Graphics.DrawRectangle(Pens.Black, 150, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 152, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 180, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("M", FuenteLineas9, Brushes.Black, 183, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 200, nTop, 30, AltoRenglon)
        e.Graphics.DrawRectangle(Pens.Black, 230, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 232, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 260, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("M", FuenteLineas9, Brushes.Black, 263, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 280, nTop, 30, AltoRenglon)
        e.Graphics.DrawRectangle(Pens.Black, 310, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 312, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 340, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("M", FuenteLineas9, Brushes.Black, 343, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 360, nTop, 30, AltoRenglon)
        e.Graphics.DrawRectangle(Pens.Black, 390, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 392, nTop)

        e.Graphics.DrawRectangle(Pens.Black, 420, nTop, 20, AltoRenglon)
        e.Graphics.DrawString("M", FuenteLineas9, Brushes.Black, 423, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 440, nTop, 30, AltoRenglon)
        e.Graphics.DrawRectangle(Pens.Black, 470, nTop, 30, AltoRenglon)
        e.Graphics.DrawString("CM", FuenteLineas9, Brushes.Black, 472, nTop)


        If TipoPlanillaImpVacia = "STOLL" Then
            nTopPicos = 12 * AltoRenglon + e.MarginBounds.Top

            e.Graphics.DrawRectangle(Pens.Black, 500, nTopPicos, 90, AltoRenglon)
            e.Graphics.DrawString("PICOS", FuenteLineas9, Brushes.Black, 510, nTopPicos)
            e.Graphics.DrawRectangle(Pens.Black, 590, nTopPicos, 90, AltoRenglon)
            e.Graphics.DrawString("CUERPO", FuenteLineas9, Brushes.Black, 600, nTopPicos)
            e.Graphics.DrawRectangle(Pens.Black, 680, nTopPicos, 90, AltoRenglon)
            e.Graphics.DrawString("MANGA", FuenteLineas9, Brushes.Black, 690, nTopPicos)

            For nRowPos = 0 To 7
                nTopPicos = nTopPicos + AltoRenglon
                e.Graphics.DrawRectangle(Pens.Black, 500, nTopPicos, 90, AltoRenglon)
                'e.Graphics.DrawString(dgvPicos.Rows(nRowPos).Cells("PICO").Value, FuenteLineas9, Brushes.Black, 510, nTopPicos)
                e.Graphics.DrawRectangle(Pens.Black, 590, nTopPicos, 30, AltoRenglon)
                'e.Graphics.DrawString(dgvPicos.Rows(nRowPos).Cells("CUERPO_C1").Value, FuenteLineas9, Brushes.Black, 595, nTopPicos)
                e.Graphics.DrawRectangle(Pens.Black, 620, nTopPicos, 30, AltoRenglon)
                'e.Graphics.DrawString(dgvPicos.Rows(nRowPos).Cells("CUERPO_C2").Value, FuenteLineas9, Brushes.Black, 625, nTopPicos)
                e.Graphics.DrawRectangle(Pens.Black, 650, nTopPicos, 30, AltoRenglon)
                'e.Graphics.DrawString(dgvPicos.Rows(nRowPos).Cells("CUERPO_C3").Value, FuenteLineas9, Brushes.Black, 655, nTopPicos)
                e.Graphics.DrawRectangle(Pens.Black, 680, nTopPicos, 30, AltoRenglon)
                'e.Graphics.DrawString(dgvPicos.Rows(nRowPos).Cells("MANGA_C1").Value, FuenteLineas9, Brushes.Black, 685, nTopPicos)
                e.Graphics.DrawRectangle(Pens.Black, 710, nTopPicos, 30, AltoRenglon)
                'e.Graphics.DrawString(dgvPicos.Rows(nRowPos).Cells("MANGA_C2").Value, FuenteLineas9, Brushes.Black, 715, nTopPicos)
                e.Graphics.DrawRectangle(Pens.Black, 740, nTopPicos, 30, AltoRenglon)
                'e.Graphics.DrawString(dgvPicos.Rows(nRowPos).Cells("MANGA_C3").Value, FuenteLineas9, Brushes.Black, 745, nTopPicos)

            Next
        Else
            nTopMallas = 7 * AltoRenglon + e.MarginBounds.Top

            e.Graphics.DrawRectangle(Pens.Black, 500, nTopMallas, 270, AltoRenglon)
            e.Graphics.DrawString("MALLA VARIABLE", FuenteLineas9, Brushes.Black, 580, nTopMallas)

            nTopMallas = nTopMallas + AltoRenglon

            e.Graphics.DrawRectangle(Pens.Black, 500, nTopMallas, 80, AltoRenglon)
            e.Graphics.DrawRectangle(Pens.Black, 580, nTopMallas, 35, AltoRenglon)
            e.Graphics.DrawString("D", FuenteLineas9, Brushes.Black, 585, nTopMallas)
            e.Graphics.DrawRectangle(Pens.Black, 615, nTopMallas, 35, AltoRenglon)
            e.Graphics.DrawString("T", FuenteLineas9, Brushes.Black, 620, nTopMallas)
            e.Graphics.DrawRectangle(Pens.Black, 650, nTopMallas, 120, AltoRenglon)

            For nRowPos = 0 To 13
                nTopMallas = nTopMallas + AltoRenglon
                e.Graphics.DrawRectangle(Pens.Black, 500, nTopMallas, 80, AltoRenglon)
                'e.Graphics.DrawString(dgvMallaVariable.Rows(nRowPos).Cells("MALLA").Value, FuenteLineas9, Brushes.Black, 510, nTopMallas)
                e.Graphics.DrawRectangle(Pens.Black, 580, nTopMallas, 35, AltoRenglon)
                'e.Graphics.DrawString(dgvMallaVariable.Rows(nRowPos).Cells("MALLA_D").Value, FuenteLineas9, Brushes.Black, 590, nTopMallas)
                e.Graphics.DrawRectangle(Pens.Black, 615, nTopMallas, 35, AltoRenglon)
                'e.Graphics.DrawString(dgvMallaVariable.Rows(nRowPos).Cells("MALLA_T").Value, FuenteLineas9, Brushes.Black, 625, nTopMallas)
                e.Graphics.DrawRectangle(Pens.Black, 650, nTopMallas, 120, AltoRenglon)
                'e.Graphics.DrawString(dgvMallaVariable.Rows(nRowPos).Cells("MALLA_DESC").Value, FuenteLineas9, Brushes.Black, 655, nTopMallas)
            Next

        End If

        If TipoPlanillaImpVacia = "STOLL" Then
            nTopCorr = 3 * AltoRenglon + e.MarginBounds.Top

            e.Graphics.DrawRectangle(Pens.Black, 500, nTopCorr, 90, AltoRenglon)
            e.Graphics.DrawString("FECHA", FuenteLineas9, Brushes.Black, 510, nTopCorr)
            e.Graphics.DrawRectangle(Pens.Black, 590, nTopCorr, 180, AltoRenglon)
            e.Graphics.DrawString("CORRECCION", FuenteLineas9, Brushes.Black, 600, nTopCorr)

            e.Graphics.DrawRectangle(Pens.Black, 500, nTopCorr, 90, 9 * AltoRenglon)
            e.Graphics.DrawRectangle(Pens.Black, 590, nTopCorr, 180, 9 * AltoRenglon)

            'busco la ultima fila que tiene datos y desde ahi imprimo las ultimas 10
            'UltimaFiladeCorreccionConDato = 0
            'For nRowPos = 0 To dgvCorrecciones.RowCount - 1
            '    If dgvCorrecciones.Rows(nRowPos).Cells("FECHA").Value.ToString <> "" Or dgvCorrecciones.Rows(nRowPos).Cells("CORRECCION").Value.ToString <> "" Then
            '        UltimaFiladeCorreccionConDato = UltimaFiladeCorreccionConDato + 1
            '    End If
            '    If dgvCorrecciones.Rows(nRowPos).Cells("FECHA").Value.ToString = "" And dgvCorrecciones.Rows(nRowPos).Cells("CORRECCION").Value.ToString = "" Then
            '        Exit For
            '    End If
            'Next

            'If UltimaFiladeCorreccionConDato > 7 Then
            '    For nRowPos = UltimaFiladeCorreccionConDato - 8 To UltimaFiladeCorreccionConDato
            '        nTopCorr = nTopCorr + AltoRenglon
            '        e.Graphics.DrawString(dgvCorrecciones.Rows(nRowPos).Cells("FECHA").Value, FuenteLineas9, Brushes.Black, 510, nTopCorr)
            '        e.Graphics.DrawString(dgvCorrecciones.Rows(nRowPos).Cells("CORRECCION").Value, FuenteLineas9, Brushes.Black, 595, nTopCorr)
            '    Next
            'Else
            '    For nRowPos = 0 To 8
            '        nTopCorr = nTopCorr + AltoRenglon
            '        e.Graphics.DrawString(dgvCorrecciones.Rows(nRowPos).Cells("FECHA").Value, FuenteLineas9, Brushes.Black, 510, nTopCorr)
            '        e.Graphics.DrawString(dgvCorrecciones.Rows(nRowPos).Cells("CORRECCION").Value, FuenteLineas9, Brushes.Black, 595, nTopCorr)
            '    Next
            'End If
        Else

            nTopCorr = 3 * AltoRenglon + e.MarginBounds.Top

            e.Graphics.DrawRectangle(Pens.Black, 500, nTopCorr, 90, AltoRenglon)
            e.Graphics.DrawString("FECHA", FuenteLineas9, Brushes.Black, 510, nTopCorr)
            e.Graphics.DrawRectangle(Pens.Black, 590, nTopCorr, 180, AltoRenglon)
            e.Graphics.DrawString("CORRECCION", FuenteLineas9, Brushes.Black, 600, nTopCorr)

            e.Graphics.DrawRectangle(Pens.Black, 500, nTopCorr, 90, 4 * AltoRenglon)
            e.Graphics.DrawRectangle(Pens.Black, 590, nTopCorr, 180, 4 * AltoRenglon)

            'busco la ultima fila que tiene datos y desde ahi imprimo las ultimas 10
            'UltimaFiladeCorreccionConDato = 0
            'For nRowPos = 0 To dgvCorrecciones.RowCount - 1
            '    If dgvCorrecciones.Rows(nRowPos).Cells("FECHA").Value.ToString <> "" Or dgvCorrecciones.Rows(nRowPos).Cells("CORRECCION").Value.ToString <> "" Then
            '        UltimaFiladeCorreccionConDato = UltimaFiladeCorreccionConDato + 1
            '    End If
            '    If dgvCorrecciones.Rows(nRowPos).Cells("FECHA").Value.ToString = "" And dgvCorrecciones.Rows(nRowPos).Cells("CORRECCION").Value.ToString = "" Then
            '        Exit For
            '    End If
            'Next

            'If UltimaFiladeCorreccionConDato > 2 Then
            '    For nRowPos = UltimaFiladeCorreccionConDato - 3 To UltimaFiladeCorreccionConDato
            '        nTopCorr = nTopCorr + AltoRenglon
            '        e.Graphics.DrawString(dgvCorrecciones.Rows(nRowPos).Cells("FECHA").Value, FuenteLineas9, Brushes.Black, 510, nTopCorr)
            '        e.Graphics.DrawString(dgvCorrecciones.Rows(nRowPos).Cells("CORRECCION").Value, FuenteLineas9, Brushes.Black, 595, nTopCorr)
            '    Next
            'Else
            '    For nRowPos = 0 To 3
            '        nTopCorr = nTopCorr + AltoRenglon
            '        e.Graphics.DrawString(dgvCorrecciones.Rows(nRowPos).Cells("FECHA").Value, FuenteLineas9, Brushes.Black, 510, nTopCorr)
            '        e.Graphics.DrawString(dgvCorrecciones.Rows(nRowPos).Cells("CORRECCION").Value, FuenteLineas9, Brushes.Black, 595, nTopCorr)
            '    Next
            'End If

        End If

        nTop = nTop + AltoRenglon

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(20, nTop, 480, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 480, AltoRenglon)
        e.Graphics.DrawString("GRADUACIÓN CUERPOS", FuenteLineas9, Brushes.Black, 200, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(500, nTop, 270, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 500, nTop, 270, AltoRenglon)
        e.Graphics.DrawString("GRADUACIÓN MANGAS", FuenteLineas9, Brushes.Black, 550, nTop)

        LapizMarcador.Width = 2.0F

        If TipoPlanillaImpVacia = "STOLL" Then
            For nRowPos = 0 To 19
                nTop = nTop + AltoRenglon
                'If dgvGC_STOLL.Rows(nRowPos).Cells("chk_1").Value = True Then
                '    e.Graphics.DrawArc(LapizMarcador, New Rectangle(20, nTop, 30, AltoRenglon), 0, 360)
                'End If
                e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 30, AltoRenglon)
                'e.Graphics.DrawString(dgvGC_STOLL.Rows(nRowPos).Cells("LETRA_1").Value, FuenteLineas8N, Brushes.Black, 25, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 50, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvGC_STOLL.Rows(nRowPos).Cells("C1_1").Value, FuenteLineas8N, Brushes.Black, 55, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 75, nTop, 30, AltoRenglon)
                'e.Graphics.DrawString(dgvGC_STOLL.Rows(nRowPos).Cells("C2_1").Value, FuenteLineas8N, Brushes.Black, 77, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 105, nTop, 155, AltoRenglon)
                'e.Graphics.DrawString(dgvGC_STOLL.Rows(nRowPos).Cells("DESC_1").Value, FuenteLineas7N, Brushes.Black, 107, nTop + 1)
                'If dgvGC_STOLL.Rows(nRowPos).Cells("chk_2").Value = True Then
                '    e.Graphics.DrawArc(LapizMarcador, New Rectangle(260, nTop, 30, AltoRenglon), 0, 360)
                'End If
                e.Graphics.DrawRectangle(Pens.Black, 260, nTop, 30, AltoRenglon)
                'e.Graphics.DrawString(dgvGC_STOLL.Rows(nRowPos).Cells("LETRA_2").Value, FuenteLineas8N, Brushes.Black, 265, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 290, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvGC_STOLL.Rows(nRowPos).Cells("C1_2").Value, FuenteLineas8N, Brushes.Black, 295, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 315, nTop, 30, AltoRenglon)
                'e.Graphics.DrawString(dgvGC_STOLL.Rows(nRowPos).Cells("C2_2").Value, FuenteLineas8N, Brushes.Black, 317, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 345, nTop, 155, AltoRenglon)
                'e.Graphics.DrawString(dgvGC_STOLL.Rows(nRowPos).Cells("DESC_2").Value, FuenteLineas7N, Brushes.Black, 347, nTop + 1)

                'If dgvGM_STOLL.Rows(nRowPos).Cells("chk").Value = True Then
                '    e.Graphics.DrawArc(LapizMarcador, New Rectangle(500, nTop, 30, AltoRenglon), 0, 360)
                'End If
                e.Graphics.DrawRectangle(Pens.Black, 500, nTop, 30, AltoRenglon)
                'e.Graphics.DrawString(dgvGM_STOLL.Rows(nRowPos).Cells("LETRA").Value, FuenteLineas8N, Brushes.Black, 505, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 530, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvGM_STOLL.Rows(nRowPos).Cells("C1").Value, FuenteLineas8N, Brushes.Black, 535, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 555, nTop, 30, AltoRenglon)
                'e.Graphics.DrawString(dgvGM_STOLL.Rows(nRowPos).Cells("C2").Value, FuenteLineas8N, Brushes.Black, 557, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 585, nTop, 185, AltoRenglon)
                'e.Graphics.DrawString(dgvGM_STOLL.Rows(nRowPos).Cells("DESC").Value, FuenteLineas7N, Brushes.Black, 587, nTop + 1)
            Next

        Else

            For nRowPos = 0 To 19
                nTop = nTop + AltoRenglon
                'If dgvGC_SHIMA.Rows(nRowPos).Cells("chk_1").Value = True Then
                '    e.Graphics.DrawArc(LapizMarcador, New Rectangle(20, nTop, 30, AltoRenglon), 0, 360)
                'End If
                e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 30, AltoRenglon)
                'e.Graphics.DrawString(dgvGC_SHIMA.Rows(nRowPos).Cells("LETRA_1").Value, FuenteLineas8N, Brushes.Black, 25, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 50, nTop, 30, AltoRenglon)
                'e.Graphics.DrawString(dgvGC_SHIMA.Rows(nRowPos).Cells("C1_1").Value, FuenteLineas8N, Brushes.Black, 55, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 80, nTop, 30, AltoRenglon)
                'e.Graphics.DrawString(dgvGC_SHIMA.Rows(nRowPos).Cells("C2_1").Value, FuenteLineas8N, Brushes.Black, 85, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 110, nTop, 150, AltoRenglon)
                'e.Graphics.DrawString(dgvGC_SHIMA.Rows(nRowPos).Cells("DESC_1").Value, FuenteLineas8N, Brushes.Black, 115, nTop)
                'If dgvGC_SHIMA.Rows(nRowPos).Cells("chk_2").Value = True Then
                '    e.Graphics.DrawArc(LapizMarcador, New Rectangle(260, nTop, 30, AltoRenglon), 0, 360)
                'End If
                e.Graphics.DrawRectangle(Pens.Black, 260, nTop, 30, AltoRenglon)
                'e.Graphics.DrawString(dgvGC_SHIMA.Rows(nRowPos).Cells("LETRA_2").Value, FuenteLineas8N, Brushes.Black, 265, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 290, nTop, 30, AltoRenglon)
                'e.Graphics.DrawString(dgvGC_SHIMA.Rows(nRowPos).Cells("C1_2").Value, FuenteLineas8N, Brushes.Black, 295, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 320, nTop, 30, AltoRenglon)
                'e.Graphics.DrawString(dgvGC_SHIMA.Rows(nRowPos).Cells("C2_2").Value, FuenteLineas8N, Brushes.Black, 325, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 350, nTop, 150, AltoRenglon)
                'e.Graphics.DrawString(dgvGC_SHIMA.Rows(nRowPos).Cells("DESC_2").Value, FuenteLineas8N, Brushes.Black, 355, nTop)

                'If dgvGM_SHIMA.Rows(nRowPos).Cells("chk").Value = True Then
                '    e.Graphics.DrawArc(LapizMarcador, New Rectangle(500, nTop, 30, AltoRenglon), 0, 360)
                'End If
                e.Graphics.DrawRectangle(Pens.Black, 500, nTop, 30, AltoRenglon)
                'e.Graphics.DrawString(dgvGM_SHIMA.Rows(nRowPos).Cells("LETRA").Value, FuenteLineas8N, Brushes.Black, 505, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 530, nTop, 30, AltoRenglon)
                'e.Graphics.DrawString(dgvGM_SHIMA.Rows(nRowPos).Cells("C1").Value, FuenteLineas8N, Brushes.Black, 535, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 560, nTop, 30, AltoRenglon)
                'e.Graphics.DrawString(dgvGM_SHIMA.Rows(nRowPos).Cells("C2").Value, FuenteLineas8N, Brushes.Black, 565, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 590, nTop, 180, AltoRenglon)
                'e.Graphics.DrawString(dgvGM_SHIMA.Rows(nRowPos).Cells("DESC").Value, FuenteLineas8N, Brushes.Black, 595, nTop)
            Next

        End If

        nTop = nTop + AltoRenglon

        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(20, nTop, 490, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 490, AltoRenglon)
        e.Graphics.DrawString("TIRAJE CUERPOS", FuenteLineas9, Brushes.Black, 200, nTop)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(510, nTop, 260, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 510, nTop, 260, AltoRenglon)
        e.Graphics.DrawString("TIRAJE MANGAS", FuenteLineas9, Brushes.Black, 570, nTop)

        If TipoPlanillaImpVacia = "STOLL" Then
            For nRowPos = 0 To 9
                nTop = nTop + AltoRenglon
                e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 35, AltoRenglon)
                'e.Graphics.DrawString(dgvTC_STOLL.Rows(nRowPos).Cells("LETRA_1").Value, FuenteLineas8N, Brushes.Black, 21, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 55, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvTC_STOLL.Rows(nRowPos).Cells("C1_1").Value, FuenteLineas8N, Brushes.Black, 57, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 80, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvTC_STOLL.Rows(nRowPos).Cells("C2_1").Value, FuenteLineas8N, Brushes.Black, 82, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 105, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvTC_STOLL.Rows(nRowPos).Cells("C3_1").Value, FuenteLineas8N, Brushes.Black, 107, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 130, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvTC_STOLL.Rows(nRowPos).Cells("C4_1").Value, FuenteLineas8N, Brushes.Black, 132, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 155, nTop, 110, AltoRenglon)
                'e.Graphics.DrawString(dgvTC_STOLL.Rows(nRowPos).Cells("DESC_1").Value, FuenteLineas7N, Brushes.Black, 156, nTop + 1)
                e.Graphics.DrawRectangle(Pens.Black, 265, nTop, 35, AltoRenglon)
                'e.Graphics.DrawString(dgvTC_STOLL.Rows(nRowPos).Cells("LETRA_2").Value, FuenteLineas8N, Brushes.Black, 266, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 300, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvTC_STOLL.Rows(nRowPos).Cells("C1_2").Value, FuenteLineas8N, Brushes.Black, 302, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 325, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvTC_STOLL.Rows(nRowPos).Cells("C2_2").Value, FuenteLineas8N, Brushes.Black, 327, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 350, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvTC_STOLL.Rows(nRowPos).Cells("C3_2").Value, FuenteLineas8N, Brushes.Black, 352, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 375, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvTC_STOLL.Rows(nRowPos).Cells("C4_2").Value, FuenteLineas8N, Brushes.Black, 377, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 400, nTop, 110, AltoRenglon)
                'e.Graphics.DrawString(dgvTC_STOLL.Rows(nRowPos).Cells("DESC_2").Value, FuenteLineas7N, Brushes.Black, 402, nTop + 1)

                e.Graphics.DrawRectangle(Pens.Black, 510, nTop, 35, AltoRenglon)
                'e.Graphics.DrawString(dgvTM_STOLL.Rows(nRowPos).Cells("LETRA").Value, FuenteLineas8N, Brushes.Black, 511, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 545, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvTM_STOLL.Rows(nRowPos).Cells("C1").Value, FuenteLineas8N, Brushes.Black, 550, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 570, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvTM_STOLL.Rows(nRowPos).Cells("C2").Value, FuenteLineas8N, Brushes.Black, 572, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 595, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvTM_STOLL.Rows(nRowPos).Cells("C3").Value, FuenteLineas8N, Brushes.Black, 597, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 620, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvTM_STOLL.Rows(nRowPos).Cells("C4").Value, FuenteLineas8N, Brushes.Black, 622, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 645, nTop, 125, AltoRenglon)
                'e.Graphics.DrawString(dgvTM_STOLL.Rows(nRowPos).Cells("DESC").Value, FuenteLineas7N, Brushes.Black, 647, nTop + 1)
            Next

        Else

            For nRowPos = 0 To 9
                nTop = nTop + AltoRenglon
                e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 120, AltoRenglon)
                'e.Graphics.DrawString(dgvTC_SHIMA.Rows(nRowPos).Cells("DESC_1").Value, FuenteLineas8N, Brushes.Black, 25, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 140, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvTC_SHIMA.Rows(nRowPos).Cells("LETRA_1").Value, FuenteLineas8N, Brushes.Black, 145, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 165, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvTC_SHIMA.Rows(nRowPos).Cells("C1_1").Value, FuenteLineas8N, Brushes.Black, 170, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 190, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvTC_SHIMA.Rows(nRowPos).Cells("C2_1").Value, FuenteLineas8N, Brushes.Black, 195, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 215, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvTC_SHIMA.Rows(nRowPos).Cells("C3_1").Value, FuenteLineas8N, Brushes.Black, 220, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 240, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvTC_SHIMA.Rows(nRowPos).Cells("C4_1").Value, FuenteLineas8N, Brushes.Black, 245, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 265, nTop, 120, AltoRenglon)
                'e.Graphics.DrawString(dgvTC_SHIMA.Rows(nRowPos).Cells("DESC_2").Value, FuenteLineas8N, Brushes.Black, 270, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 385, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvTC_SHIMA.Rows(nRowPos).Cells("LETRA_2").Value, FuenteLineas8N, Brushes.Black, 390, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 410, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvTC_SHIMA.Rows(nRowPos).Cells("C1_2").Value, FuenteLineas8N, Brushes.Black, 415, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 435, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvTC_SHIMA.Rows(nRowPos).Cells("C2_2").Value, FuenteLineas8N, Brushes.Black, 440, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 460, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvTC_SHIMA.Rows(nRowPos).Cells("C3_2").Value, FuenteLineas8N, Brushes.Black, 465, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 485, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvTC_SHIMA.Rows(nRowPos).Cells("C4_2").Value, FuenteLineas8N, Brushes.Black, 490, nTop)

                e.Graphics.DrawRectangle(Pens.Black, 510, nTop, 130, AltoRenglon)
                'e.Graphics.DrawString(dgvTM_SHIMA.Rows(nRowPos).Cells("DESC").Value, FuenteLineas8N, Brushes.Black, 515, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 640, nTop, 30, AltoRenglon)
                'e.Graphics.DrawString(dgvTM_SHIMA.Rows(nRowPos).Cells("LETRA").Value, FuenteLineas8N, Brushes.Black, 645, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 670, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvTM_SHIMA.Rows(nRowPos).Cells("C1").Value, FuenteLineas8N, Brushes.Black, 675, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 695, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvTM_SHIMA.Rows(nRowPos).Cells("C2").Value, FuenteLineas8N, Brushes.Black, 700, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 720, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvTM_SHIMA.Rows(nRowPos).Cells("C3").Value, FuenteLineas8N, Brushes.Black, 725, nTop)
                e.Graphics.DrawRectangle(Pens.Black, 745, nTop, 25, AltoRenglon)
                'e.Graphics.DrawString(dgvTM_SHIMA.Rows(nRowPos).Cells("C4").Value, FuenteLineas8N, Brushes.Black, 750, nTop)
            Next

        End If

        'el lugar para las observaciones
        nTop = nTop + AltoRenglon
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 80, AltoRenglon)
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(100, nTop, 590, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 100, nTop, 590, AltoRenglon)
        e.Graphics.DrawString("OBSERVACIONES M.C.C.", FuenteLineas, Brushes.Black, 300, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 690, nTop, 80, AltoRenglon)

        nTop = nTop + AltoRenglon
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 750, AltoRenglon)
        nTop = nTop + AltoRenglon
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 750, AltoRenglon)
        nTop = nTop + AltoRenglon
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 750, AltoRenglon)
        nTop = nTop + AltoRenglon
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 750, AltoRenglon)
        nTop = nTop + AltoRenglon
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 750, AltoRenglon)
        nTop = nTop + AltoRenglon
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 750, AltoRenglon)
        nTop = nTop + AltoRenglon
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 750, AltoRenglon)
        nTop = nTop + AltoRenglon
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 750, AltoRenglon)

        'AHORA LOS PESOS Y TIEMPOS
        nTop = nTop + AltoRenglon
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(20, nTop, 750, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 750, AltoRenglon)
        e.Graphics.DrawString("PESOS Y TIEMPOS", FuenteLineas, Brushes.Black, 330, nTop)
        nTop = nTop + AltoRenglon
        e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightCyan), New Rectangle(20, nTop, 750, AltoRenglon))
        e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 100, AltoRenglon)
        e.Graphics.DrawString("DATO", FuenteLineas, Brushes.Black, 30, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 120, nTop, 80, AltoRenglon)
        e.Graphics.DrawString("XXS", FuenteLineas, Brushes.Black, 130, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 200, nTop, 80, AltoRenglon)
        e.Graphics.DrawString("XS", FuenteLineas, Brushes.Black, 210, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 280, nTop, 80, AltoRenglon)
        e.Graphics.DrawString("S", FuenteLineas, Brushes.Black, 290, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 360, nTop, 80, AltoRenglon)
        e.Graphics.DrawString("M", FuenteLineas, Brushes.Black, 370, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 440, nTop, 80, AltoRenglon)
        e.Graphics.DrawString("L", FuenteLineas, Brushes.Black, 450, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 520, nTop, 80, AltoRenglon)
        e.Graphics.DrawString("XL", FuenteLineas, Brushes.Black, 530, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 600, nTop, 80, AltoRenglon)
        e.Graphics.DrawString("XXL", FuenteLineas, Brushes.Black, 610, nTop)
        e.Graphics.DrawRectangle(Pens.Black, 680, nTop, 90, AltoRenglon)
        e.Graphics.DrawString("U", FuenteLineas, Brushes.Black, 690, nTop)

        For nRowPos = 0 To 1
            nTop = nTop + AltoRenglon
            e.Graphics.DrawRectangle(Pens.Black, 20, nTop, 100, AltoRenglon)
            'e.Graphics.DrawString(dgvTiempoyPeso.Rows(nRowPos).Cells("DATO").Value, FuenteLineas8N, Brushes.Black, 30, nTop)
            e.Graphics.DrawRectangle(Pens.Black, 120, nTop, 80, AltoRenglon)
            'e.Graphics.DrawString(dgvTiempoyPeso.Rows(nRowPos).Cells("XXS").Value, FuenteLineas8N, Brushes.Black, 130, nTop)
            e.Graphics.DrawRectangle(Pens.Black, 200, nTop, 80, AltoRenglon)
            'e.Graphics.DrawString(dgvTiempoyPeso.Rows(nRowPos).Cells("XS").Value, FuenteLineas8N, Brushes.Black, 210, nTop)
            e.Graphics.DrawRectangle(Pens.Black, 280, nTop, 80, AltoRenglon)
            'e.Graphics.DrawString(dgvTiempoyPeso.Rows(nRowPos).Cells("S").Value, FuenteLineas8N, Brushes.Black, 290, nTop)
            e.Graphics.DrawRectangle(Pens.Black, 360, nTop, 80, AltoRenglon)
            'e.Graphics.DrawString(dgvTiempoyPeso.Rows(nRowPos).Cells("M").Value, FuenteLineas8N, Brushes.Black, 370, nTop)
            e.Graphics.DrawRectangle(Pens.Black, 440, nTop, 80, AltoRenglon)
            'e.Graphics.DrawString(dgvTiempoyPeso.Rows(nRowPos).Cells("L").Value, FuenteLineas8N, Brushes.Black, 450, nTop)
            e.Graphics.DrawRectangle(Pens.Black, 520, nTop, 80, AltoRenglon)
            'e.Graphics.DrawString(dgvTiempoyPeso.Rows(nRowPos).Cells("XL").Value, FuenteLineas8N, Brushes.Black, 530, nTop)
            e.Graphics.DrawRectangle(Pens.Black, 600, nTop, 80, AltoRenglon)
            'e.Graphics.DrawString(dgvTiempoyPeso.Rows(nRowPos).Cells("XXL").Value, FuenteLineas8N, Brushes.Black, 610, nTop)
            e.Graphics.DrawRectangle(Pens.Black, 680, nTop, 90, AltoRenglon)
            'e.Graphics.DrawString(dgvTiempoyPeso.Rows(nRowPos).Cells("U").Value, FuenteLineas8N, Brushes.Black, 690, nTop)
        Next

        'LUEGO EL PIE DE PAGINA
        DrawFooter(e)

    End Sub

    Public Sub DrawFooter(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim FuenteLineas8 As Font = New Drawing.Font("Arial", 8, FontStyle.Regular)

        e.Graphics.DrawLine(Pens.Black, 20, e.MarginBounds.Height - 17, 790, e.MarginBounds.Height - 17)

        ' Right Align - User Name
        e.Graphics.DrawString("Impreso Por: " + DescripcionLegajo(LegajoLogueado), FuenteLineas8, Brushes.Black, 790 - e.Graphics.MeasureString("Impreso Por: " + DescripcionLegajo(LegajoLogueado), FuenteLineas8, e.MarginBounds.Width).Width, e.MarginBounds.Height - 15)

        ' Center - Page No. Info
        e.Graphics.DrawString(Format(Now, "dd/MM/yyyy HH:mm:ss"), FuenteLineas8, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(Format(Now, "dd/MM/yyyy HH:mm:ss"), FuenteLineas8, e.MarginBounds.Width).Width) / 2, e.MarginBounds.Height - 15)

        e.Graphics.DrawLine(Pens.Black, 20, e.MarginBounds.Height, 790, e.MarginBounds.Height)

    End Sub

    Private Sub tmrRevisoHilaManteActividades_Tick(sender As Object, e As EventArgs) Handles tmrRevisoHilaManteActividades.Tick

        If FechaUltimaActualizaciondeTareasMant <> Format(Now, "yyyyMMdd") Then
            FechaUltimaActualizaciondeTareasMant = Format(Now, "yyyyMMdd")
            guardarDatoUltimaFechaActualizacionTareas()
            If TipoUsuario = "Administrador" Or TipoUsuario = "HilaAdmin" Then
                RevisarVencimientosTareasPlanMantenimiento()
                tmrRevisoHilaManteActividades.Enabled = False
            End If
        Else
            tmrRevisoHilaManteActividades.Enabled = False
        End If
    End Sub

    Private Sub ReporteDeActividadDiariaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeActividadDiariaToolStripMenuItem.Click
        Dim formRepoMantActivDiaria As New frmRepoMantActivDiaria()
        If FormAbierto(formRepoMantActivDiaria) Then Exit Sub
        formRepoMantActivDiaria.Show()
    End Sub

    Private Sub btnImpresorEtiquetas_Click(sender As Object, e As EventArgs) Handles btnImpresorEtiquetas.Click
        Dim formImpresorEtiquetas As New frmImpresorEtiquetas()
        If FormAbierto(formImpresorEtiquetas) Then Exit Sub
        formImpresorEtiquetas.Show()
    End Sub

    Private Sub tsmiUnidadesMedida_Click(sender As Object, e As EventArgs) Handles tsmiUnidadesMedida.Click
        Dim fmrUnidadesMed As New frmABMUnidadesMedidas

        If FormAbierto(fmrUnidadesMed) Then Exit Sub

        fmrUnidadesMed.Show()
    End Sub

    'Private Sub CierreDeStockToolStripMenuItem_Click(sender As Object, e As EventArgs)

    '    Dim sStr As String
    '    Dim cmd As New SqlCommand
    '    Dim rd As SqlDataReader
    '    Dim ultimaFecha
    '    Dim fechaCierre = CDate(DateAdd("d", -14, Date.Now().ToString).ToShortDateString)

    '    Dim row() As String

    '    sStr = "SELECT TOP 1 fecha from HilamarArticulosStock where numeroDeposito = 1 order by fecha desc "

    '    cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
    '    rd = cmd.ExecuteReader()

    '    Do While rd.HasRows
    '        Do While rd.Read()
    '            ultimaFecha = rd.Item("fecha")
    '        Loop
    '        rd.NextResult()
    '    Loop

    '    If fechaCierre < ultimaFecha Then
    '        MsgBox("No se puede realizar un cierre al día " + fechaCierre + " ya que existe un cierre al día: " + ultimaFecha.ToShortDateString)
    '        Exit Sub
    '    End If

    '    Dim result = MsgBox("¿Esta seguro que desea realizar el procedimiento de cierre de stock? Este proceso podría tardar y no podrán realizarse movimientos de stock previos al día " + fechaCierre, vbYesNoCancel, "Confirme")

    '    If result.ToString = "Yes" Then

    '        sStr = " INSERT INTO HilamarArticulosStock "
    '        sStr += "VALUES ('" + fechaCierre + "',1) "

    '        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
    '        cmd.ExecuteNonQuery()

    '        sStr = ""
    '        sStr = " INSERT INTO HilamarArticulosStockDetalle"
    '        sStr += " SELECT A.id, (SELECT TOP 1 id from HilamarArticulosStock where numeroDeposito = 1 order by fecha desc) , cantArticulo + SUM(cantidadArticulo * (CASE tipoMovimiento WHEN 'EG' THEN -1 WHEN 'IN' THEN 1 WHEN 'DI' THEN 1 END )) AS TOTAL "
    '        sStr += " FROM HilamarArticulos AS A"
    '        sStr += " INNER JOIN HilamarArticulosStockDetalle AS SD ON SD.idArticulo = A.id "
    '        sStr += " INNER JOIN HilamarArticulosCategorias as Cat ON A.categoria = cat.id "
    '        sStr += " INNER JOIN HilamarArticulosUnidadesMedidas as Umed ON A.unidadMedida = Umed.id "
    '        sStr += " INNER JOIN dbo.HilamarArticulosStock as SE ON SD.idEnc = SE.id "
    '        sStr += " LEFT JOIN HilamarArticulosMovimientosDetalle as MD ON A.id = MD.idArticulo "
    '        sStr += " LEFT JOIN HilamarArticulosMovimientos as M ON MD.idMovimiento = M.id "
    '        sStr += " WHERE M.fecha > SE.Fecha"
    '        sStr += " AND M.fecha <= '" + fechaCierre + "'"
    '        sStr += " AND SE.fecha = ("
    '        sStr += " SELECT MAX(fecha) FROM HilamarArticulosStock"
    '        sStr += " WHERE numeroDeposito = 1 AND fecha < '" + fechaCierre + "' "
    '        sStr += " ) AND SE.numeroDeposito = 1 AND M.numeroDeposito = 1 AND A.eliminado = 0 "
    '        sStr += " GROUP BY A.id, cantArticulo "
    '        sStr += " union"
    '        sStr += " SELECT A.id, (SELECT TOP 1 id from HilamarArticulosStock order by fecha desc) , cantArticulo AS TOTAL"
    '        sStr += " FROM HilamarArticulos AS A"
    '        sStr += " INNER JOIN HilamarArticulosStockDetalle AS SD ON SD.idArticulo = A.id "
    '        sStr += " INNER JOIN HilamarArticulosCategorias as Cat ON A.categoria = cat.id "
    '        sStr += " INNER JOIN HilamarArticulosUnidadesMedidas as Umed ON A.unidadMedida = Umed.id "
    '        sStr += " INNER JOIN dbo.HilamarArticulosStock as SE ON SD.idEnc = SE.id "
    '        sStr += " LEFT JOIN HilamarArticulosMovimientosDetalle as MD ON A.id = MD.idArticulo "
    '        sStr += " LEFT JOIN HilamarArticulosMovimientos as M ON MD.idMovimiento = M.id "
    '        sStr += " WHERE SE.fecha = ("
    '        sStr += " SELECT MAX(fecha) FROM HilamarArticulosStock"
    '        sStr += " WHERE numeroDeposito = 1 AND fecha < '" + fechaCierre + "'"
    '        sStr += " ) AND SE.numeroDeposito = 1 AND A.eliminado = 0 "
    '        sStr += " GROUP BY A.id, cantArticulo "
    '        sStr += " HAVING COUNT(MD.id) = 0"
    '        sStr += " ORDER BY A.id ASC"

    '        cmd = New SqlCommand(sStr, cConexionApp.SQLConn)
    '        cmd.ExecuteNonQuery()

    '        MsgBox("¡Cierre de stock realizado con éxito!", MsgBoxStyle.Exclamation)

    '    End If

    '    If result.ToString = "No" Then

    '        Exit Sub

    '    End If

    '    If result.ToString = "Cancel" Then

    '        Exit Sub

    '    End If

    'End Sub

    Private Sub tsmiListadoMovimientos_Click(sender As Object, e As EventArgs) Handles tsmiListadoMovimientos.Click
        Dim frmListadoMovimientos As New frmListadoMovimientos(LegajoLogueado, 1)

        If FormAbierto(frmListadoMovimientos) Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        frmListadoMovimientos.Show()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub tsmiAltaIngresoArticulos_Click(sender As Object, e As EventArgs) Handles tsmiAltaIngresoArticulos.Click, tsmiAltaEgresoArticulos.Click, tsmiAltaDiferenciaInventario.Click
        Dim frmAltaMovimiento As frmAltaMovimiento
        Select Case sender.Name
            Case "tsmiAltaIngresoArticulos"
                frmAltaMovimiento = New frmAltaMovimiento(LegajoLogueado, 1, "IN")
            Case "tsmiAltaEgresoArticulos"
                frmAltaMovimiento = New frmAltaMovimiento(LegajoLogueado, 1, "EG")
            Case "tsmiAltaDiferenciaInventario"
                frmAltaMovimiento = New frmAltaMovimiento(LegajoLogueado, 1, "DI")
            Case Else
                Exit Sub
        End Select

        If FormAbierto(frmAltaMovimiento) Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        frmAltaMovimiento.Show()
        Me.Cursor = Cursors.Arrow
    End Sub

 
    Private Sub PRUEBAToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim frm As New frmHilaPartidasYCommodities
        frm.Show()
    End Sub

    Private Sub ABMIndexColoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ABMIndexColoresToolStripMenuItem.Click
        Dim frmColores As New frmListadoColoresIndex

        If FormAbierto(frmColores) Then Exit Sub

        frmColores.Show()

    End Sub

    Private Sub NuevaReservaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevaReservaToolStripMenuItem.Click
        Dim frmAltaReserva As New frmAltaReserva(LegajoLogueado, 1, 3, "RE")

        If FormAbierto(frmAltaReserva) Then Exit Sub

        frmAltaReserva.Show()

    End Sub

    Private Sub ReingresoDeReservaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReingresoDeReservaToolStripMenuItem.Click
        Dim frmAltaReserva As New frmAltaReserva(LegajoLogueado, 3, 1, "RI")

        If FormAbierto(frmAltaReserva) Then Exit Sub

        frmAltaReserva.Show()
    End Sub

    Private Sub tsmiABMArticulos_Click(sender As Object, e As EventArgs) Handles tsmiABMArticulos.Click
        Dim fmrABMArticulos As New frmABMArticulos(LegajoLogueado, 1)

        If FormAbierto(fmrABMArticulos) Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        fmrABMArticulos.Show()
        Me.Cursor = Cursors.Arrow
    End Sub
End Class
