<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ConsPedido
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ConsPedido))
        Me.GrpBoxFiltro = New System.Windows.Forms.GroupBox()
        Me.ChkData = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DtFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DtInicial = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BtnPesquisar = New System.Windows.Forms.Button()
        Me.ChkVendedor = New System.Windows.Forms.CheckBox()
        Me.ChkCliente = New System.Windows.Forms.CheckBox()
        Me.ComboVendedor = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboCliente = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GrpBoxPedidos = New System.Windows.Forms.GroupBox()
        Me.BtnConfirmar = New System.Windows.Forms.Button()
        Me.LstPedido = New System.Windows.Forms.ListView()
        Me.ColCod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColVendedor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColDatVenda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColDestinatario = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GrpBoxFiltro.SuspendLayout()
        Me.GrpBoxPedidos.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpBoxFiltro
        '
        Me.GrpBoxFiltro.BackColor = System.Drawing.SystemColors.Menu
        Me.GrpBoxFiltro.Controls.Add(Me.ChkData)
        Me.GrpBoxFiltro.Controls.Add(Me.Label5)
        Me.GrpBoxFiltro.Controls.Add(Me.DtFinal)
        Me.GrpBoxFiltro.Controls.Add(Me.Label4)
        Me.GrpBoxFiltro.Controls.Add(Me.DtInicial)
        Me.GrpBoxFiltro.Controls.Add(Me.Label3)
        Me.GrpBoxFiltro.Controls.Add(Me.BtnPesquisar)
        Me.GrpBoxFiltro.Controls.Add(Me.ChkVendedor)
        Me.GrpBoxFiltro.Controls.Add(Me.ChkCliente)
        Me.GrpBoxFiltro.Controls.Add(Me.ComboVendedor)
        Me.GrpBoxFiltro.Controls.Add(Me.Label2)
        Me.GrpBoxFiltro.Controls.Add(Me.ComboCliente)
        Me.GrpBoxFiltro.Controls.Add(Me.Label1)
        Me.GrpBoxFiltro.Location = New System.Drawing.Point(12, 12)
        Me.GrpBoxFiltro.Name = "GrpBoxFiltro"
        Me.GrpBoxFiltro.Size = New System.Drawing.Size(1140, 196)
        Me.GrpBoxFiltro.TabIndex = 0
        Me.GrpBoxFiltro.TabStop = False
        Me.GrpBoxFiltro.Text = "Filtros"
        '
        'ChkData
        '
        Me.ChkData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkData.AutoSize = True
        Me.ChkData.Location = New System.Drawing.Point(282, 159)
        Me.ChkData.Name = "ChkData"
        Me.ChkData.Size = New System.Drawing.Size(15, 14)
        Me.ChkData.TabIndex = 7
        Me.ChkData.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(135, 157)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 16)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "-"
        '
        'DtFinal
        '
        Me.DtFinal.CustomFormat = ""
        Me.DtFinal.Enabled = False
        Me.DtFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFinal.Location = New System.Drawing.Point(156, 154)
        Me.DtFinal.Name = "DtFinal"
        Me.DtFinal.Size = New System.Drawing.Size(120, 23)
        Me.DtFinal.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(153, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 16)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Data Final"
        '
        'DtInicial
        '
        Me.DtInicial.CustomFormat = ""
        Me.DtInicial.Enabled = False
        Me.DtInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtInicial.Location = New System.Drawing.Point(9, 154)
        Me.DtInicial.Name = "DtInicial"
        Me.DtInicial.Size = New System.Drawing.Size(120, 23)
        Me.DtInicial.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 16)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Data Inicial"
        '
        'BtnPesquisar
        '
        Me.BtnPesquisar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPesquisar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPesquisar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.BtnPesquisar.Image = CType(resources.GetObject("BtnPesquisar.Image"), System.Drawing.Image)
        Me.BtnPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnPesquisar.Location = New System.Drawing.Point(1023, 154)
        Me.BtnPesquisar.Name = "BtnPesquisar"
        Me.BtnPesquisar.Size = New System.Drawing.Size(99, 32)
        Me.BtnPesquisar.TabIndex = 45
        Me.BtnPesquisar.Text = "Pesquisar"
        Me.BtnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPesquisar.UseVisualStyleBackColor = True
        '
        'ChkVendedor
        '
        Me.ChkVendedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkVendedor.AutoSize = True
        Me.ChkVendedor.Location = New System.Drawing.Point(741, 103)
        Me.ChkVendedor.Name = "ChkVendedor"
        Me.ChkVendedor.Size = New System.Drawing.Size(15, 14)
        Me.ChkVendedor.TabIndex = 4
        Me.ChkVendedor.UseVisualStyleBackColor = True
        '
        'ChkCliente
        '
        Me.ChkCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkCliente.AutoSize = True
        Me.ChkCliente.Location = New System.Drawing.Point(741, 57)
        Me.ChkCliente.Name = "ChkCliente"
        Me.ChkCliente.Size = New System.Drawing.Size(15, 14)
        Me.ChkCliente.TabIndex = 2
        Me.ChkCliente.UseVisualStyleBackColor = True
        '
        'ComboVendedor
        '
        Me.ComboVendedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboVendedor.Enabled = False
        Me.ComboVendedor.FormattingEnabled = True
        Me.ComboVendedor.Location = New System.Drawing.Point(9, 98)
        Me.ComboVendedor.Name = "ComboVendedor"
        Me.ComboVendedor.Size = New System.Drawing.Size(726, 24)
        Me.ComboVendedor.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Vendedor"
        '
        'ComboCliente
        '
        Me.ComboCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ComboCliente.Enabled = False
        Me.ComboCliente.FormattingEnabled = True
        Me.ComboCliente.Location = New System.Drawing.Point(9, 52)
        Me.ComboCliente.Name = "ComboCliente"
        Me.ComboCliente.Size = New System.Drawing.Size(726, 24)
        Me.ComboCliente.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cliente"
        '
        'GrpBoxPedidos
        '
        Me.GrpBoxPedidos.BackColor = System.Drawing.SystemColors.Menu
        Me.GrpBoxPedidos.Controls.Add(Me.BtnConfirmar)
        Me.GrpBoxPedidos.Controls.Add(Me.LstPedido)
        Me.GrpBoxPedidos.Location = New System.Drawing.Point(12, 214)
        Me.GrpBoxPedidos.Name = "GrpBoxPedidos"
        Me.GrpBoxPedidos.Size = New System.Drawing.Size(1140, 292)
        Me.GrpBoxPedidos.TabIndex = 1
        Me.GrpBoxPedidos.TabStop = False
        Me.GrpBoxPedidos.Text = "Pedidos"
        '
        'BtnConfirmar
        '
        Me.BtnConfirmar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConfirmar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.BtnConfirmar.Image = Global.Beyond.My.Resources.Resources.confirm
        Me.BtnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnConfirmar.Location = New System.Drawing.Point(1023, 254)
        Me.BtnConfirmar.Name = "BtnConfirmar"
        Me.BtnConfirmar.Size = New System.Drawing.Size(99, 32)
        Me.BtnConfirmar.TabIndex = 46
        Me.BtnConfirmar.Text = "Confirmar"
        Me.BtnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConfirmar.UseVisualStyleBackColor = True
        '
        'LstPedido
        '
        Me.LstPedido.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LstPedido.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColCod, Me.ColCliente, Me.ColVendedor, Me.ColDatVenda, Me.ColDestinatario})
        Me.LstPedido.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LstPedido.FullRowSelect = True
        Me.LstPedido.GridLines = True
        Me.LstPedido.Location = New System.Drawing.Point(12, 40)
        Me.LstPedido.MultiSelect = False
        Me.LstPedido.Name = "LstPedido"
        Me.LstPedido.Size = New System.Drawing.Size(1110, 208)
        Me.LstPedido.TabIndex = 0
        Me.LstPedido.UseCompatibleStateImageBehavior = False
        Me.LstPedido.View = System.Windows.Forms.View.Details
        '
        'ColCod
        '
        Me.ColCod.Text = "Código do Pedido"
        Me.ColCod.Width = 171
        '
        'ColCliente
        '
        Me.ColCliente.Text = "Cliente"
        Me.ColCliente.Width = 273
        '
        'ColVendedor
        '
        Me.ColVendedor.Text = "Vendedor"
        Me.ColVendedor.Width = 273
        '
        'ColDatVenda
        '
        Me.ColDatVenda.Text = "Data da Venda"
        Me.ColDatVenda.Width = 157
        '
        'ColDestinatario
        '
        Me.ColDestinatario.Text = "Destinatário"
        Me.ColDestinatario.Width = 283
        '
        'Frm_ConsPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Menu
        Me.ClientSize = New System.Drawing.Size(1164, 518)
        Me.Controls.Add(Me.GrpBoxPedidos)
        Me.Controls.Add(Me.GrpBoxFiltro)
        Me.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1180, 600)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(800, 520)
        Me.Name = "Frm_ConsPedido"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Consultar Pedidos"
        Me.GrpBoxFiltro.ResumeLayout(False)
        Me.GrpBoxFiltro.PerformLayout()
        Me.GrpBoxPedidos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpBoxFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents ComboVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpBoxPedidos As System.Windows.Forms.GroupBox
    Friend WithEvents LstPedido As System.Windows.Forms.ListView
    Friend WithEvents ColCod As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColVendedor As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColDatVenda As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColDestinatario As System.Windows.Forms.ColumnHeader
    Friend WithEvents ChkVendedor As System.Windows.Forms.CheckBox
    Friend WithEvents ChkCliente As System.Windows.Forms.CheckBox
    Friend WithEvents BtnPesquisar As System.Windows.Forms.Button
    Friend WithEvents BtnConfirmar As System.Windows.Forms.Button
    Friend WithEvents ChkData As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DtFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DtInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
