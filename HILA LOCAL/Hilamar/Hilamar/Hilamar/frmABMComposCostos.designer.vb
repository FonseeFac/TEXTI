<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmABMComposCostos
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmABMComposCostos))
        Me.cmdVolver = New System.Windows.Forms.Button()
        Me.cmbTipos = New System.Windows.Forms.ComboBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.cmbElementos = New System.Windows.Forms.ComboBox()
        Me.lblElemento = New System.Windows.Forms.Label()
        Me.dgvCompoCostos = New System.Windows.Forms.DataGridView()
        Me.lblCostoTotalTit = New System.Windows.Forms.Label()
        Me.lblCostoTotal = New System.Windows.Forms.Label()
        Me.cmdAgregar = New System.Windows.Forms.Button()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.gbAgregarItem = New System.Windows.Forms.GroupBox()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.txtFactorMulti = New System.Windows.Forms.TextBox()
        Me.lblFactorMultiplicador = New System.Windows.Forms.Label()
        Me.txtDescAdic = New System.Windows.Forms.TextBox()
        Me.lblDescAdic = New System.Windows.Forms.Label()
        Me.cmbItems = New System.Windows.Forms.ComboBox()
        Me.lblItem = New System.Windows.Forms.Label()
        Me.cmbTipoItem = New System.Windows.Forms.ComboBox()
        Me.lblTipoItem = New System.Windows.Forms.Label()
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.lblCostoTotalPorKiloLinea = New System.Windows.Forms.Label()
        CType(Me.dgvCompoCostos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbAgregarItem.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdVolver
        '
        Me.cmdVolver.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdVolver.Location = New System.Drawing.Point(760, 58)
        Me.cmdVolver.Name = "cmdVolver"
        Me.cmdVolver.Size = New System.Drawing.Size(70, 29)
        Me.cmdVolver.TabIndex = 9
        Me.cmdVolver.Text = "Volver"
        Me.cmdVolver.UseVisualStyleBackColor = True
        '
        'cmbTipos
        '
        Me.cmbTipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipos.FormattingEnabled = True
        Me.cmbTipos.Location = New System.Drawing.Point(65, 12)
        Me.cmbTipos.Name = "cmbTipos"
        Me.cmbTipos.Size = New System.Drawing.Size(143, 24)
        Me.cmbTipos.TabIndex = 21
        '
        'lblTipo
        '
        Me.lblTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.Location = New System.Drawing.Point(14, 13)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(46, 23)
        Me.lblTipo.TabIndex = 20
        Me.lblTipo.Text = "Tipo:"
        Me.lblTipo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbElementos
        '
        Me.cmbElementos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbElementos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbElementos.FormattingEnabled = True
        Me.cmbElementos.Location = New System.Drawing.Point(299, 13)
        Me.cmbElementos.Name = "cmbElementos"
        Me.cmbElementos.Size = New System.Drawing.Size(297, 24)
        Me.cmbElementos.TabIndex = 23
        '
        'lblElemento
        '
        Me.lblElemento.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblElemento.Location = New System.Drawing.Point(214, 14)
        Me.lblElemento.Name = "lblElemento"
        Me.lblElemento.Size = New System.Drawing.Size(79, 23)
        Me.lblElemento.TabIndex = 22
        Me.lblElemento.Text = "Elemento:"
        Me.lblElemento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvCompoCostos
        '
        Me.dgvCompoCostos.AllowUserToAddRows = False
        Me.dgvCompoCostos.AllowUserToDeleteRows = False
        Me.dgvCompoCostos.AllowUserToResizeColumns = False
        Me.dgvCompoCostos.AllowUserToResizeRows = False
        Me.dgvCompoCostos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.dgvCompoCostos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCompoCostos.Location = New System.Drawing.Point(17, 58)
        Me.dgvCompoCostos.MultiSelect = False
        Me.dgvCompoCostos.Name = "dgvCompoCostos"
        Me.dgvCompoCostos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCompoCostos.Size = New System.Drawing.Size(579, 277)
        Me.dgvCompoCostos.TabIndex = 24
        '
        'lblCostoTotalTit
        '
        Me.lblCostoTotalTit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoTotalTit.Location = New System.Drawing.Point(342, 338)
        Me.lblCostoTotalTit.Name = "lblCostoTotalTit"
        Me.lblCostoTotalTit.Size = New System.Drawing.Size(143, 23)
        Me.lblCostoTotalTit.TabIndex = 25
        Me.lblCostoTotalTit.Text = "Costo Total por Kilo:"
        Me.lblCostoTotalTit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCostoTotal
        '
        Me.lblCostoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoTotal.Location = New System.Drawing.Point(486, 338)
        Me.lblCostoTotal.Name = "lblCostoTotal"
        Me.lblCostoTotal.Size = New System.Drawing.Size(96, 23)
        Me.lblCostoTotal.TabIndex = 26
        Me.lblCostoTotal.Text = "0.00"
        Me.lblCostoTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdAgregar
        '
        Me.cmdAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAgregar.Location = New System.Drawing.Point(610, 58)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(69, 29)
        Me.cmdAgregar.TabIndex = 27
        Me.cmdAgregar.Text = "Agregar"
        Me.cmdAgregar.UseVisualStyleBackColor = True
        '
        'cmdEliminar
        '
        Me.cmdEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEliminar.Location = New System.Drawing.Point(685, 58)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(69, 29)
        Me.cmdEliminar.TabIndex = 28
        Me.cmdEliminar.Text = "Eliminar"
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'gbAgregarItem
        '
        Me.gbAgregarItem.Controls.Add(Me.cmdCancelar)
        Me.gbAgregarItem.Controls.Add(Me.txtFactorMulti)
        Me.gbAgregarItem.Controls.Add(Me.lblFactorMultiplicador)
        Me.gbAgregarItem.Controls.Add(Me.txtDescAdic)
        Me.gbAgregarItem.Controls.Add(Me.lblDescAdic)
        Me.gbAgregarItem.Controls.Add(Me.cmbItems)
        Me.gbAgregarItem.Controls.Add(Me.lblItem)
        Me.gbAgregarItem.Controls.Add(Me.cmbTipoItem)
        Me.gbAgregarItem.Controls.Add(Me.lblTipoItem)
        Me.gbAgregarItem.Controls.Add(Me.cmdGuardar)
        Me.gbAgregarItem.Location = New System.Drawing.Point(610, 93)
        Me.gbAgregarItem.Name = "gbAgregarItem"
        Me.gbAgregarItem.Size = New System.Drawing.Size(265, 242)
        Me.gbAgregarItem.TabIndex = 29
        Me.gbAgregarItem.TabStop = False
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.Location = New System.Drawing.Point(135, 206)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(78, 26)
        Me.cmdCancelar.TabIndex = 30
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'txtFactorMulti
        '
        Me.txtFactorMulti.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFactorMulti.Location = New System.Drawing.Point(165, 162)
        Me.txtFactorMulti.MaxLength = 9
        Me.txtFactorMulti.Name = "txtFactorMulti"
        Me.txtFactorMulti.Size = New System.Drawing.Size(94, 23)
        Me.txtFactorMulti.TabIndex = 29
        '
        'lblFactorMultiplicador
        '
        Me.lblFactorMultiplicador.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFactorMultiplicador.Location = New System.Drawing.Point(6, 162)
        Me.lblFactorMultiplicador.Name = "lblFactorMultiplicador"
        Me.lblFactorMultiplicador.Size = New System.Drawing.Size(157, 23)
        Me.lblFactorMultiplicador.TabIndex = 28
        Me.lblFactorMultiplicador.Text = "Factor Multiplicador:"
        Me.lblFactorMultiplicador.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDescAdic
        '
        Me.txtDescAdic.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescAdic.Location = New System.Drawing.Point(34, 126)
        Me.txtDescAdic.MaxLength = 150
        Me.txtDescAdic.Name = "txtDescAdic"
        Me.txtDescAdic.Size = New System.Drawing.Size(225, 23)
        Me.txtDescAdic.TabIndex = 27
        '
        'lblDescAdic
        '
        Me.lblDescAdic.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescAdic.Location = New System.Drawing.Point(6, 104)
        Me.lblDescAdic.Name = "lblDescAdic"
        Me.lblDescAdic.Size = New System.Drawing.Size(157, 23)
        Me.lblDescAdic.TabIndex = 26
        Me.lblDescAdic.Text = "Descripción Adicional:"
        Me.lblDescAdic.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbItems
        '
        Me.cmbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbItems.FormattingEnabled = True
        Me.cmbItems.Location = New System.Drawing.Point(57, 54)
        Me.cmbItems.Name = "cmbItems"
        Me.cmbItems.Size = New System.Drawing.Size(202, 24)
        Me.cmbItems.TabIndex = 25
        '
        'lblItem
        '
        Me.lblItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItem.Location = New System.Drawing.Point(5, 55)
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Size = New System.Drawing.Size(47, 23)
        Me.lblItem.TabIndex = 24
        Me.lblItem.Text = "Item:"
        Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbTipoItem
        '
        Me.cmbTipoItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoItem.FormattingEnabled = True
        Me.cmbTipoItem.Location = New System.Drawing.Point(57, 15)
        Me.cmbTipoItem.Name = "cmbTipoItem"
        Me.cmbTipoItem.Size = New System.Drawing.Size(202, 24)
        Me.cmbTipoItem.TabIndex = 23
        '
        'lblTipoItem
        '
        Me.lblTipoItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoItem.Location = New System.Drawing.Point(6, 16)
        Me.lblTipoItem.Name = "lblTipoItem"
        Me.lblTipoItem.Size = New System.Drawing.Size(46, 23)
        Me.lblTipoItem.TabIndex = 22
        Me.lblTipoItem.Text = "Tipo:"
        Me.lblTipoItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGuardar.Location = New System.Drawing.Point(56, 206)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(73, 26)
        Me.cmdGuardar.TabIndex = 9
        Me.cmdGuardar.Text = "Guardar"
        Me.cmdGuardar.UseVisualStyleBackColor = True
        '
        'lblCostoTotalPorKiloLinea
        '
        Me.lblCostoTotalPorKiloLinea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCostoTotalPorKiloLinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoTotalPorKiloLinea.Location = New System.Drawing.Point(337, 329)
        Me.lblCostoTotalPorKiloLinea.Name = "lblCostoTotalPorKiloLinea"
        Me.lblCostoTotalPorKiloLinea.Size = New System.Drawing.Size(259, 33)
        Me.lblCostoTotalPorKiloLinea.TabIndex = 30
        Me.lblCostoTotalPorKiloLinea.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmABMComposCostos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(887, 371)
        Me.Controls.Add(Me.gbAgregarItem)
        Me.Controls.Add(Me.cmdEliminar)
        Me.Controls.Add(Me.cmdAgregar)
        Me.Controls.Add(Me.lblCostoTotal)
        Me.Controls.Add(Me.lblCostoTotalTit)
        Me.Controls.Add(Me.dgvCompoCostos)
        Me.Controls.Add(Me.cmbElementos)
        Me.Controls.Add(Me.lblElemento)
        Me.Controls.Add(Me.cmbTipos)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.cmdVolver)
        Me.Controls.Add(Me.lblCostoTotalPorKiloLinea)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmABMComposCostos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM - Composición de Costos"
        CType(Me.dgvCompoCostos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbAgregarItem.ResumeLayout(False)
        Me.gbAgregarItem.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdVolver As System.Windows.Forms.Button
    Friend WithEvents cmbTipos As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents cmbElementos As System.Windows.Forms.ComboBox
    Friend WithEvents lblElemento As System.Windows.Forms.Label
    Friend WithEvents dgvCompoCostos As System.Windows.Forms.DataGridView
    Friend WithEvents lblCostoTotalTit As System.Windows.Forms.Label
    Friend WithEvents lblCostoTotal As System.Windows.Forms.Label
    Friend WithEvents cmdAgregar As System.Windows.Forms.Button
    Friend WithEvents cmdEliminar As System.Windows.Forms.Button
    Friend WithEvents gbAgregarItem As System.Windows.Forms.GroupBox
    Friend WithEvents cmdGuardar As System.Windows.Forms.Button
    Friend WithEvents cmbTipoItem As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoItem As System.Windows.Forms.Label
    Friend WithEvents lblDescAdic As System.Windows.Forms.Label
    Friend WithEvents cmbItems As System.Windows.Forms.ComboBox
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents txtDescAdic As System.Windows.Forms.TextBox
    Friend WithEvents txtFactorMulti As System.Windows.Forms.TextBox
    Friend WithEvents lblFactorMultiplicador As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCostoTotalPorKiloLinea As System.Windows.Forms.Label
End Class
