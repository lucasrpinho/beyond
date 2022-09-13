<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Pedido
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Pedido))
        Me.TCPedido = New System.Windows.Forms.TabControl()
        Me.TabDados = New System.Windows.Forms.TabPage()
        Me.GrpBoxEndereco = New System.Windows.Forms.GroupBox()
        Me.TxtCidade = New System.Windows.Forms.TextBox()
        Me.TxtNum = New System.Windows.Forms.TextBox()
        Me.TxtCEP = New System.Windows.Forms.MaskedTextBox()
        Me.ComboEstado = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtLogradouro = New System.Windows.Forms.TextBox()
        Me.TxtBairro = New System.Windows.Forms.TextBox()
        Me.TxtComplemento = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LblCep = New System.Windows.Forms.Label()
        Me.GrpBoxInfo = New System.Windows.Forms.GroupBox()
        Me.ChkDestinatario = New System.Windows.Forms.CheckBox()
        Me.TxtCod = New System.Windows.Forms.TextBox()
        Me.DtPckVenda = New System.Windows.Forms.DateTimePicker()
        Me.TxtDestinatario = New System.Windows.Forms.TextBox()
        Me.ComboVendedor = New System.Windows.Forms.ComboBox()
        Me.ComboCliente = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabProduto = New System.Windows.Forms.TabPage()
        Me.BtnMaisInsere = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnComprar = New System.Windows.Forms.Button()
        Me.LblQtdCarrinho = New System.Windows.Forms.Label()
        Me.LblPrecoTotal = New System.Windows.Forms.Label()
        Me.BtnPesquisar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.BtnMenosInsere = New System.Windows.Forms.Button()
        Me.TxtQtdInsere = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TxtDesc = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.LblPreco = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ComboProduto = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ComboCategoria = New System.Windows.Forms.ComboBox()
        Me.PicProd = New System.Windows.Forms.PictureBox()
        Me.LstProd = New System.Windows.Forms.ListView()
        Me.ColCategoria = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColDescricao = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColPreco = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColQtd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabItens = New System.Windows.Forms.TabPage()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TxtValorTotal = New System.Windows.Forms.TextBox()
        Me.TxtObs = New System.Windows.Forms.TextBox()
        Me.LblValorTotal = New System.Windows.Forms.Label()
        Me.BtnMenos = New System.Windows.Forms.Button()
        Me.BtnMais = New System.Windows.Forms.Button()
        Me.TxtQtd = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ChkPresente = New System.Windows.Forms.CheckBox()
        Me.LstCarrinho = New System.Windows.Forms.ListView()
        Me.ColDesc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColPrecoUnit = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColQtd1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColPrecoTotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TCPedido.SuspendLayout()
        Me.TabDados.SuspendLayout()
        Me.GrpBoxEndereco.SuspendLayout()
        Me.GrpBoxInfo.SuspendLayout()
        Me.TabProduto.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabItens.SuspendLayout()
        Me.SuspendLayout()
        '
        'TCPedido
        '
        Me.TCPedido.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TCPedido.Controls.Add(Me.TabDados)
        Me.TCPedido.Controls.Add(Me.TabProduto)
        Me.TCPedido.Controls.Add(Me.TabItens)
        Me.TCPedido.Location = New System.Drawing.Point(0, 0)
        Me.TCPedido.Name = "TCPedido"
        Me.TCPedido.SelectedIndex = 0
        Me.TCPedido.Size = New System.Drawing.Size(794, 472)
        Me.TCPedido.TabIndex = 0
        '
        'TabDados
        '
        Me.TabDados.Controls.Add(Me.GrpBoxEndereco)
        Me.TabDados.Controls.Add(Me.GrpBoxInfo)
        Me.TabDados.Location = New System.Drawing.Point(4, 26)
        Me.TabDados.Name = "TabDados"
        Me.TabDados.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDados.Size = New System.Drawing.Size(786, 442)
        Me.TabDados.TabIndex = 0
        Me.TabDados.Text = "Dados"
        Me.TabDados.UseVisualStyleBackColor = True
        '
        'GrpBoxEndereco
        '
        Me.GrpBoxEndereco.Controls.Add(Me.TxtCidade)
        Me.GrpBoxEndereco.Controls.Add(Me.TxtNum)
        Me.GrpBoxEndereco.Controls.Add(Me.TxtCEP)
        Me.GrpBoxEndereco.Controls.Add(Me.ComboEstado)
        Me.GrpBoxEndereco.Controls.Add(Me.Label8)
        Me.GrpBoxEndereco.Controls.Add(Me.TxtLogradouro)
        Me.GrpBoxEndereco.Controls.Add(Me.TxtBairro)
        Me.GrpBoxEndereco.Controls.Add(Me.TxtComplemento)
        Me.GrpBoxEndereco.Controls.Add(Me.Label3)
        Me.GrpBoxEndereco.Controls.Add(Me.Label7)
        Me.GrpBoxEndereco.Controls.Add(Me.Label9)
        Me.GrpBoxEndereco.Controls.Add(Me.Label10)
        Me.GrpBoxEndereco.Controls.Add(Me.Label12)
        Me.GrpBoxEndereco.Controls.Add(Me.LblCep)
        Me.GrpBoxEndereco.Dock = System.Windows.Forms.DockStyle.Top
        Me.GrpBoxEndereco.Location = New System.Drawing.Point(3, 225)
        Me.GrpBoxEndereco.Name = "GrpBoxEndereco"
        Me.GrpBoxEndereco.Size = New System.Drawing.Size(780, 238)
        Me.GrpBoxEndereco.TabIndex = 5
        Me.GrpBoxEndereco.TabStop = False
        Me.GrpBoxEndereco.Text = "Endereço de Entrega"
        '
        'TxtCidade
        '
        Me.TxtCidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCidade.Location = New System.Drawing.Point(346, 106)
        Me.TxtCidade.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCidade.MaxLength = 50
        Me.TxtCidade.Name = "TxtCidade"
        Me.TxtCidade.Size = New System.Drawing.Size(423, 25)
        Me.TxtCidade.TabIndex = 13
        '
        'TxtNum
        '
        Me.TxtNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNum.Location = New System.Drawing.Point(13, 106)
        Me.TxtNum.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNum.MaxLength = 5
        Me.TxtNum.Name = "TxtNum"
        Me.TxtNum.Size = New System.Drawing.Size(100, 25)
        Me.TxtNum.TabIndex = 11
        '
        'TxtCEP
        '
        Me.TxtCEP.Location = New System.Drawing.Point(13, 49)
        Me.TxtCEP.Mask = "00000-000"
        Me.TxtCEP.Name = "TxtCEP"
        Me.TxtCEP.Size = New System.Drawing.Size(75, 25)
        Me.TxtCEP.TabIndex = 9
        '
        'ComboEstado
        '
        Me.ComboEstado.FormattingEnabled = True
        Me.ComboEstado.Items.AddRange(New Object() {" "})
        Me.ComboEstado.Location = New System.Drawing.Point(555, 164)
        Me.ComboEstado.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboEstado.MaxLength = 2
        Me.ComboEstado.Name = "ComboEstado"
        Me.ComboEstado.Size = New System.Drawing.Size(214, 25)
        Me.ComboEstado.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(551, 143)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 19)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "Estado"
        '
        'TxtLogradouro
        '
        Me.TxtLogradouro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLogradouro.Location = New System.Drawing.Point(121, 49)
        Me.TxtLogradouro.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtLogradouro.MaxLength = 100
        Me.TxtLogradouro.Name = "TxtLogradouro"
        Me.TxtLogradouro.Size = New System.Drawing.Size(648, 25)
        Me.TxtLogradouro.TabIndex = 10
        '
        'TxtBairro
        '
        Me.TxtBairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBairro.Location = New System.Drawing.Point(13, 164)
        Me.TxtBairro.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtBairro.MaxLength = 30
        Me.TxtBairro.Name = "TxtBairro"
        Me.TxtBairro.Size = New System.Drawing.Size(533, 25)
        Me.TxtBairro.TabIndex = 14
        '
        'TxtComplemento
        '
        Me.TxtComplemento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtComplemento.Location = New System.Drawing.Point(121, 106)
        Me.TxtComplemento.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtComplemento.MaxLength = 30
        Me.TxtComplemento.Name = "TxtComplemento"
        Me.TxtComplemento.Size = New System.Drawing.Size(217, 25)
        Me.TxtComplemento.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(343, 85)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 19)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Cidade"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 143)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 19)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "Bairro"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(118, 86)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 19)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "Complemento"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 86)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 19)
        Me.Label10.TabIndex = 50
        Me.Label10.Text = "Número"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(120, 30)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 19)
        Me.Label12.TabIndex = 49
        Me.Label12.Text = "Logradouro"
        '
        'LblCep
        '
        Me.LblCep.AutoSize = True
        Me.LblCep.Location = New System.Drawing.Point(12, 30)
        Me.LblCep.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCep.Name = "LblCep"
        Me.LblCep.Size = New System.Drawing.Size(33, 19)
        Me.LblCep.TabIndex = 48
        Me.LblCep.Text = "CEP"
        '
        'GrpBoxInfo
        '
        Me.GrpBoxInfo.Controls.Add(Me.ChkDestinatario)
        Me.GrpBoxInfo.Controls.Add(Me.TxtCod)
        Me.GrpBoxInfo.Controls.Add(Me.DtPckVenda)
        Me.GrpBoxInfo.Controls.Add(Me.TxtDestinatario)
        Me.GrpBoxInfo.Controls.Add(Me.ComboVendedor)
        Me.GrpBoxInfo.Controls.Add(Me.ComboCliente)
        Me.GrpBoxInfo.Controls.Add(Me.Label6)
        Me.GrpBoxInfo.Controls.Add(Me.Label5)
        Me.GrpBoxInfo.Controls.Add(Me.Label4)
        Me.GrpBoxInfo.Controls.Add(Me.Label2)
        Me.GrpBoxInfo.Controls.Add(Me.Label1)
        Me.GrpBoxInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.GrpBoxInfo.Location = New System.Drawing.Point(3, 3)
        Me.GrpBoxInfo.Name = "GrpBoxInfo"
        Me.GrpBoxInfo.Size = New System.Drawing.Size(780, 222)
        Me.GrpBoxInfo.TabIndex = 2
        Me.GrpBoxInfo.TabStop = False
        Me.GrpBoxInfo.Text = "Informações"
        '
        'ChkDestinatario
        '
        Me.ChkDestinatario.AutoSize = True
        Me.ChkDestinatario.Enabled = False
        Me.ChkDestinatario.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkDestinatario.Location = New System.Drawing.Point(281, 86)
        Me.ChkDestinatario.Name = "ChkDestinatario"
        Me.ChkDestinatario.Size = New System.Drawing.Size(97, 21)
        Me.ChkDestinatario.TabIndex = 12
        Me.ChkDestinatario.Text = "Destinatário"
        Me.ChkDestinatario.UseVisualStyleBackColor = True
        '
        'TxtCod
        '
        Me.TxtCod.Enabled = False
        Me.TxtCod.Location = New System.Drawing.Point(16, 52)
        Me.TxtCod.Name = "TxtCod"
        Me.TxtCod.ReadOnly = True
        Me.TxtCod.Size = New System.Drawing.Size(185, 25)
        Me.TxtCod.TabIndex = 11
        Me.TxtCod.TabStop = False
        '
        'DtPckVenda
        '
        Me.DtPckVenda.CustomFormat = "dd/MM/yyyy hh:mm"
        Me.DtPckVenda.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPckVenda.Location = New System.Drawing.Point(408, 157)
        Me.DtPckVenda.Name = "DtPckVenda"
        Me.DtPckVenda.Size = New System.Drawing.Size(138, 25)
        Me.DtPckVenda.TabIndex = 9
        '
        'TxtDestinatario
        '
        Me.TxtDestinatario.Location = New System.Drawing.Point(408, 107)
        Me.TxtDestinatario.Name = "TxtDestinatario"
        Me.TxtDestinatario.Size = New System.Drawing.Size(361, 25)
        Me.TxtDestinatario.TabIndex = 8
        '
        'ComboVendedor
        '
        Me.ComboVendedor.FormattingEnabled = True
        Me.ComboVendedor.Location = New System.Drawing.Point(16, 157)
        Me.ComboVendedor.Name = "ComboVendedor"
        Me.ComboVendedor.Size = New System.Drawing.Size(359, 25)
        Me.ComboVendedor.TabIndex = 7
        '
        'ComboCliente
        '
        Me.ComboCliente.FormattingEnabled = True
        Me.ComboCliente.Location = New System.Drawing.Point(16, 107)
        Me.ComboCliente.Name = "ComboCliente"
        Me.ComboCliente.Size = New System.Drawing.Size(359, 25)
        Me.ComboCliente.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 19)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Código do Pedido"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(404, 135)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 19)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Data da Venda"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(404, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 19)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Destinatário"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Vendedor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cliente"
        '
        'TabProduto
        '
        Me.TabProduto.Controls.Add(Me.BtnMaisInsere)
        Me.TabProduto.Controls.Add(Me.PictureBox1)
        Me.TabProduto.Controls.Add(Me.BtnComprar)
        Me.TabProduto.Controls.Add(Me.LblQtdCarrinho)
        Me.TabProduto.Controls.Add(Me.LblPrecoTotal)
        Me.TabProduto.Controls.Add(Me.BtnPesquisar)
        Me.TabProduto.Controls.Add(Me.BtnMenosInsere)
        Me.TabProduto.Controls.Add(Me.TxtQtdInsere)
        Me.TabProduto.Controls.Add(Me.Label18)
        Me.TabProduto.Controls.Add(Me.TxtDesc)
        Me.TabProduto.Controls.Add(Me.Label16)
        Me.TabProduto.Controls.Add(Me.LblPreco)
        Me.TabProduto.Controls.Add(Me.Label13)
        Me.TabProduto.Controls.Add(Me.ComboProduto)
        Me.TabProduto.Controls.Add(Me.Label11)
        Me.TabProduto.Controls.Add(Me.ComboCategoria)
        Me.TabProduto.Controls.Add(Me.PicProd)
        Me.TabProduto.Controls.Add(Me.LstProd)
        Me.TabProduto.Location = New System.Drawing.Point(4, 26)
        Me.TabProduto.Name = "TabProduto"
        Me.TabProduto.Padding = New System.Windows.Forms.Padding(3)
        Me.TabProduto.Size = New System.Drawing.Size(786, 442)
        Me.TabProduto.TabIndex = 1
        Me.TabProduto.Text = "Produtos"
        Me.TabProduto.UseVisualStyleBackColor = True
        '
        'BtnMaisInsere
        '
        Me.BtnMaisInsere.FlatAppearance.BorderSize = 0
        Me.BtnMaisInsere.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.BtnMaisInsere.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnMaisInsere.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMaisInsere.Image = Global.Beyond.My.Resources.Resources.mais
        Me.BtnMaisInsere.Location = New System.Drawing.Point(311, 336)
        Me.BtnMaisInsere.Name = "BtnMaisInsere"
        Me.BtnMaisInsere.Size = New System.Drawing.Size(23, 23)
        Me.BtnMaisInsere.TabIndex = 32
        Me.BtnMaisInsere.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Beyond.My.Resources.Resources.shopcar1
        Me.PictureBox1.Location = New System.Drawing.Point(644, 360)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(37, 34)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 31
        Me.PictureBox1.TabStop = False
        '
        'BtnComprar
        '
        Me.BtnComprar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnComprar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.BtnComprar.FlatAppearance.BorderSize = 0
        Me.BtnComprar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnComprar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnComprar.ForeColor = System.Drawing.SystemColors.Window
        Me.BtnComprar.Location = New System.Drawing.Point(644, 400)
        Me.BtnComprar.Name = "BtnComprar"
        Me.BtnComprar.Size = New System.Drawing.Size(134, 34)
        Me.BtnComprar.TabIndex = 30
        Me.BtnComprar.Text = "Adicionar"
        Me.BtnComprar.UseVisualStyleBackColor = False
        '
        'LblQtdCarrinho
        '
        Me.LblQtdCarrinho.AutoSize = True
        Me.LblQtdCarrinho.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblQtdCarrinho.Location = New System.Drawing.Point(687, 384)
        Me.LblQtdCarrinho.Name = "LblQtdCarrinho"
        Me.LblQtdCarrinho.Size = New System.Drawing.Size(13, 13)
        Me.LblQtdCarrinho.TabIndex = 29
        Me.LblQtdCarrinho.Text = "0"
        '
        'LblPrecoTotal
        '
        Me.LblPrecoTotal.AutoSize = True
        Me.LblPrecoTotal.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrecoTotal.Location = New System.Drawing.Point(224, 406)
        Me.LblPrecoTotal.Name = "LblPrecoTotal"
        Me.LblPrecoTotal.Size = New System.Drawing.Size(77, 17)
        Me.LblPrecoTotal.TabIndex = 28
        Me.LblPrecoTotal.Text = "Preço Total"
        '
        'BtnPesquisar
        '
        Me.BtnPesquisar.FlatAppearance.BorderSize = 0
        Me.BtnPesquisar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.BtnPesquisar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPesquisar.ImageKey = "search.png"
        Me.BtnPesquisar.ImageList = Me.ImageList1
        Me.BtnPesquisar.Location = New System.Drawing.Point(748, 76)
        Me.BtnPesquisar.Name = "BtnPesquisar"
        Me.BtnPesquisar.Size = New System.Drawing.Size(30, 26)
        Me.BtnPesquisar.TabIndex = 27
        Me.BtnPesquisar.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "mais")
        Me.ImageList1.Images.SetKeyName(1, "menos")
        Me.ImageList1.Images.SetKeyName(2, "confirm.png")
        Me.ImageList1.Images.SetKeyName(3, "search.png")
        Me.ImageList1.Images.SetKeyName(4, "shopcar1.png")
        '
        'BtnMenosInsere
        '
        Me.BtnMenosInsere.FlatAppearance.BorderSize = 0
        Me.BtnMenosInsere.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.BtnMenosInsere.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnMenosInsere.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMenosInsere.Image = Global.Beyond.My.Resources.Resources.menos
        Me.BtnMenosInsere.Location = New System.Drawing.Point(225, 336)
        Me.BtnMenosInsere.Name = "BtnMenosInsere"
        Me.BtnMenosInsere.Size = New System.Drawing.Size(22, 23)
        Me.BtnMenosInsere.TabIndex = 24
        Me.BtnMenosInsere.UseVisualStyleBackColor = True
        '
        'TxtQtdInsere
        '
        Me.TxtQtdInsere.Location = New System.Drawing.Point(257, 336)
        Me.TxtQtdInsere.Name = "TxtQtdInsere"
        Me.TxtQtdInsere.ReadOnly = True
        Me.TxtQtdInsere.Size = New System.Drawing.Size(48, 25)
        Me.TxtQtdInsere.TabIndex = 22
        Me.TxtQtdInsere.Text = "0"
        Me.TxtQtdInsere.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(224, 314)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(81, 19)
        Me.Label18.TabIndex = 21
        Me.Label18.Text = "Quantidade"
        '
        'TxtDesc
        '
        Me.TxtDesc.Location = New System.Drawing.Point(228, 286)
        Me.TxtDesc.Name = "TxtDesc"
        Me.TxtDesc.ReadOnly = True
        Me.TxtDesc.Size = New System.Drawing.Size(550, 25)
        Me.TxtDesc.TabIndex = 8
        Me.TxtDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(224, 264)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(67, 19)
        Me.Label16.TabIndex = 7
        Me.Label16.Text = "Descrição"
        '
        'LblPreco
        '
        Me.LblPreco.AutoSize = True
        Me.LblPreco.Location = New System.Drawing.Point(224, 371)
        Me.LblPreco.Name = "LblPreco"
        Me.LblPreco.Size = New System.Drawing.Size(43, 19)
        Me.LblPreco.TabIndex = 6
        Me.LblPreco.Text = "Preço"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(5, 54)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 19)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Produto"
        '
        'ComboProduto
        '
        Me.ComboProduto.FormattingEnabled = True
        Me.ComboProduto.Location = New System.Drawing.Point(9, 76)
        Me.ComboProduto.Name = "ComboProduto"
        Me.ComboProduto.Size = New System.Drawing.Size(485, 25)
        Me.ComboProduto.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 19)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Categoria"
        '
        'ComboCategoria
        '
        Me.ComboCategoria.FormattingEnabled = True
        Me.ComboCategoria.Location = New System.Drawing.Point(9, 25)
        Me.ComboCategoria.Name = "ComboCategoria"
        Me.ComboCategoria.Size = New System.Drawing.Size(483, 25)
        Me.ComboCategoria.TabIndex = 1
        '
        'PicProd
        '
        Me.PicProd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicProd.Location = New System.Drawing.Point(9, 264)
        Me.PicProd.Name = "PicProd"
        Me.PicProd.Size = New System.Drawing.Size(194, 170)
        Me.PicProd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicProd.TabIndex = 5
        Me.PicProd.TabStop = False
        '
        'LstProd
        '
        Me.LstProd.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColCategoria, Me.ColDescricao, Me.ColPreco, Me.ColQtd})
        Me.LstProd.FullRowSelect = True
        Me.LstProd.GridLines = True
        Me.LstProd.LargeImageList = Me.ImageList1
        Me.LstProd.Location = New System.Drawing.Point(9, 107)
        Me.LstProd.MultiSelect = False
        Me.LstProd.Name = "LstProd"
        Me.LstProd.Size = New System.Drawing.Size(769, 151)
        Me.LstProd.TabIndex = 0
        Me.LstProd.UseCompatibleStateImageBehavior = False
        Me.LstProd.View = System.Windows.Forms.View.Details
        '
        'ColCategoria
        '
        Me.ColCategoria.Text = "Categoria"
        Me.ColCategoria.Width = 303
        '
        'ColDescricao
        '
        Me.ColDescricao.Text = "Descrição"
        Me.ColDescricao.Width = 366
        '
        'ColPreco
        '
        Me.ColPreco.Text = "Preço"
        Me.ColPreco.Width = 160
        '
        'ColQtd
        '
        Me.ColQtd.Text = "Estoque"
        Me.ColQtd.Width = 100
        '
        'TabItens
        '
        Me.TabItens.Controls.Add(Me.Label15)
        Me.TabItens.Controls.Add(Me.TxtValorTotal)
        Me.TabItens.Controls.Add(Me.TxtObs)
        Me.TabItens.Controls.Add(Me.LblValorTotal)
        Me.TabItens.Controls.Add(Me.BtnMenos)
        Me.TabItens.Controls.Add(Me.BtnMais)
        Me.TabItens.Controls.Add(Me.TxtQtd)
        Me.TabItens.Controls.Add(Me.Label17)
        Me.TabItens.Controls.Add(Me.ChkPresente)
        Me.TabItens.Controls.Add(Me.LstCarrinho)
        Me.TabItens.Controls.Add(Me.Label14)
        Me.TabItens.Location = New System.Drawing.Point(4, 26)
        Me.TabItens.Name = "TabItens"
        Me.TabItens.Padding = New System.Windows.Forms.Padding(3)
        Me.TabItens.Size = New System.Drawing.Size(786, 442)
        Me.TabItens.TabIndex = 2
        Me.TabItens.Text = "Itens"
        Me.TabItens.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(8, 357)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(81, 19)
        Me.Label15.TabIndex = 24
        Me.Label15.Text = "Observação"
        '
        'TxtValorTotal
        '
        Me.TxtValorTotal.Location = New System.Drawing.Point(159, 271)
        Me.TxtValorTotal.Name = "TxtValorTotal"
        Me.TxtValorTotal.ReadOnly = True
        Me.TxtValorTotal.Size = New System.Drawing.Size(192, 25)
        Me.TxtValorTotal.TabIndex = 23
        Me.TxtValorTotal.Text = "0"
        Me.TxtValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtObs
        '
        Me.TxtObs.Location = New System.Drawing.Point(10, 379)
        Me.TxtObs.Multiline = True
        Me.TxtObs.Name = "TxtObs"
        Me.TxtObs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtObs.Size = New System.Drawing.Size(770, 57)
        Me.TxtObs.TabIndex = 22
        '
        'LblValorTotal
        '
        Me.LblValorTotal.AutoSize = True
        Me.LblValorTotal.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValorTotal.Location = New System.Drawing.Point(155, 249)
        Me.LblValorTotal.Name = "LblValorTotal"
        Me.LblValorTotal.Size = New System.Drawing.Size(73, 19)
        Me.LblValorTotal.TabIndex = 21
        Me.LblValorTotal.Text = "Valor Total"
        '
        'BtnMenos
        '
        Me.BtnMenos.FlatAppearance.BorderSize = 0
        Me.BtnMenos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.BtnMenos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnMenos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMenos.Image = Global.Beyond.My.Resources.Resources.menos
        Me.BtnMenos.Location = New System.Drawing.Point(10, 275)
        Me.BtnMenos.Name = "BtnMenos"
        Me.BtnMenos.Size = New System.Drawing.Size(19, 23)
        Me.BtnMenos.TabIndex = 20
        Me.BtnMenos.UseVisualStyleBackColor = True
        '
        'BtnMais
        '
        Me.BtnMais.FlatAppearance.BorderSize = 0
        Me.BtnMais.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.BtnMais.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnMais.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMais.Image = Global.Beyond.My.Resources.Resources.mais
        Me.BtnMais.Location = New System.Drawing.Point(98, 275)
        Me.BtnMais.Name = "BtnMais"
        Me.BtnMais.Size = New System.Drawing.Size(23, 23)
        Me.BtnMais.TabIndex = 19
        Me.BtnMais.UseVisualStyleBackColor = True
        '
        'TxtQtd
        '
        Me.TxtQtd.Location = New System.Drawing.Point(35, 273)
        Me.TxtQtd.Name = "TxtQtd"
        Me.TxtQtd.ReadOnly = True
        Me.TxtQtd.Size = New System.Drawing.Size(57, 25)
        Me.TxtQtd.TabIndex = 18
        Me.TxtQtd.Text = "0"
        Me.TxtQtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(22, 249)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(81, 19)
        Me.Label17.TabIndex = 17
        Me.Label17.Text = "Quantidade"
        '
        'ChkPresente
        '
        Me.ChkPresente.AutoSize = True
        Me.ChkPresente.Font = New System.Drawing.Font("Segoe UI", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkPresente.Location = New System.Drawing.Point(709, 357)
        Me.ChkPresente.Name = "ChkPresente"
        Me.ChkPresente.Size = New System.Drawing.Size(77, 21)
        Me.ChkPresente.TabIndex = 16
        Me.ChkPresente.Text = "Presente"
        Me.ChkPresente.UseVisualStyleBackColor = True
        '
        'LstCarrinho
        '
        Me.LstCarrinho.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColDesc, Me.ColPrecoUnit, Me.ColQtd1, Me.ColPrecoTotal})
        Me.LstCarrinho.FullRowSelect = True
        Me.LstCarrinho.GridLines = True
        Me.LstCarrinho.Location = New System.Drawing.Point(8, 25)
        Me.LstCarrinho.MultiSelect = False
        Me.LstCarrinho.Name = "LstCarrinho"
        Me.LstCarrinho.Size = New System.Drawing.Size(772, 221)
        Me.LstCarrinho.StateImageList = Me.ImageList1
        Me.LstCarrinho.TabIndex = 14
        Me.LstCarrinho.TileSize = New System.Drawing.Size(260, 30)
        Me.LstCarrinho.UseCompatibleStateImageBehavior = False
        Me.LstCarrinho.View = System.Windows.Forms.View.Details
        '
        'ColDesc
        '
        Me.ColDesc.Text = "Descrição"
        Me.ColDesc.Width = 366
        '
        'ColPrecoUnit
        '
        Me.ColPrecoUnit.Text = "Preço Unitário"
        Me.ColPrecoUnit.Width = 151
        '
        'ColQtd1
        '
        Me.ColQtd1.Text = "Quantidade"
        Me.ColQtd1.Width = 81
        '
        'ColPrecoTotal
        '
        Me.ColPrecoTotal.Text = "Preço Total"
        Me.ColPrecoTotal.Width = 162
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 3)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 19)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "Carrinho"
        '
        'Frm_Pedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 472)
        Me.Controls.Add(Me.TCPedido)
        Me.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Pedido"
        Me.ShowInTaskbar = False
        Me.Text = "Pedido"
        Me.TCPedido.ResumeLayout(False)
        Me.TabDados.ResumeLayout(False)
        Me.GrpBoxEndereco.ResumeLayout(False)
        Me.GrpBoxEndereco.PerformLayout()
        Me.GrpBoxInfo.ResumeLayout(False)
        Me.GrpBoxInfo.PerformLayout()
        Me.TabProduto.ResumeLayout(False)
        Me.TabProduto.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabItens.ResumeLayout(False)
        Me.TabItens.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TCPedido As System.Windows.Forms.TabControl
    Friend WithEvents TabDados As System.Windows.Forms.TabPage
    Friend WithEvents TabProduto As System.Windows.Forms.TabPage
    Friend WithEvents GrpBoxInfo As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCod As System.Windows.Forms.TextBox
    Friend WithEvents DtPckVenda As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtDestinatario As System.Windows.Forms.TextBox
    Friend WithEvents ComboVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents ComboCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpBoxEndereco As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCidade As System.Windows.Forms.TextBox
    Friend WithEvents TxtNum As System.Windows.Forms.TextBox
    Friend WithEvents TxtCEP As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ComboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtLogradouro As System.Windows.Forms.TextBox
    Friend WithEvents TxtBairro As System.Windows.Forms.TextBox
    Friend WithEvents TxtComplemento As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents LblCep As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ComboCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents LstProd As System.Windows.Forms.ListView
    Friend WithEvents ColCategoria As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColDescricao As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColPreco As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColQtd As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ChkDestinatario As System.Windows.Forms.CheckBox
    Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents LblPreco As System.Windows.Forms.Label
    Friend WithEvents PicProd As System.Windows.Forms.PictureBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ComboProduto As System.Windows.Forms.ComboBox
    Friend WithEvents TabItens As System.Windows.Forms.TabPage
    Friend WithEvents LstCarrinho As System.Windows.Forms.ListView
    Friend WithEvents ColDesc As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ChkPresente As System.Windows.Forms.CheckBox
    Friend WithEvents TxtQtd As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents BtnMenos As System.Windows.Forms.Button
    Friend WithEvents BtnMais As System.Windows.Forms.Button
    Friend WithEvents ColPrecoUnit As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColQtd1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColPrecoTotal As System.Windows.Forms.ColumnHeader
    Friend WithEvents LblPrecoTotal As System.Windows.Forms.Label
    Friend WithEvents BtnPesquisar As System.Windows.Forms.Button
    Friend WithEvents BtnMenosInsere As System.Windows.Forms.Button
    Friend WithEvents TxtQtdInsere As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents LblQtdCarrinho As System.Windows.Forms.Label
    Friend WithEvents BtnComprar As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtValorTotal As System.Windows.Forms.TextBox
    Friend WithEvents TxtObs As System.Windows.Forms.TextBox
    Friend WithEvents LblValorTotal As System.Windows.Forms.Label
    Friend WithEvents BtnMaisInsere As System.Windows.Forms.Button

End Class
