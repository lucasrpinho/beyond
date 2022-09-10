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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
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
        Me.LstCarrinho = New System.Windows.Forms.ListView()
        Me.ColDescricao1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColUniPreco = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColQtd1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColPrecoTotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ChkPresente = New System.Windows.Forms.CheckBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ComboCategoria = New System.Windows.Forms.ComboBox()
        Me.LstProd = New System.Windows.Forms.ListView()
        Me.ColCategoria = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColDescricao = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColPreco = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColQtd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TCPedido.SuspendLayout()
        Me.TabDados.SuspendLayout()
        Me.GrpBoxEndereco.SuspendLayout()
        Me.GrpBoxInfo.SuspendLayout()
        Me.TabProduto.SuspendLayout()
        Me.SuspendLayout()
        '
        'TCPedido
        '
        Me.TCPedido.Controls.Add(Me.TabDados)
        Me.TCPedido.Controls.Add(Me.TabProduto)
        Me.TCPedido.Dock = System.Windows.Forms.DockStyle.Fill
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
        Me.GrpBoxInfo.Controls.Add(Me.TextBox1)
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
        Me.ChkDestinatario.Font = New System.Drawing.Font("Segoe UI", 8.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkDestinatario.Location = New System.Drawing.Point(281, 86)
        Me.ChkDestinatario.Name = "ChkDestinatario"
        Me.ChkDestinatario.Size = New System.Drawing.Size(89, 19)
        Me.ChkDestinatario.TabIndex = 12
        Me.ChkDestinatario.Text = "Destinatário"
        Me.ChkDestinatario.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(16, 52)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(185, 25)
        Me.TextBox1.TabIndex = 11
        Me.TextBox1.TabStop = False
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
        Me.TabProduto.Controls.Add(Me.LstCarrinho)
        Me.TabProduto.Controls.Add(Me.ChkPresente)
        Me.TabProduto.Controls.Add(Me.Label13)
        Me.TabProduto.Controls.Add(Me.Label11)
        Me.TabProduto.Controls.Add(Me.ComboCategoria)
        Me.TabProduto.Controls.Add(Me.LstProd)
        Me.TabProduto.Location = New System.Drawing.Point(4, 26)
        Me.TabProduto.Name = "TabProduto"
        Me.TabProduto.Padding = New System.Windows.Forms.Padding(3)
        Me.TabProduto.Size = New System.Drawing.Size(786, 442)
        Me.TabProduto.TabIndex = 1
        Me.TabProduto.Text = "Produtos"
        Me.TabProduto.UseVisualStyleBackColor = True
        '
        'LstCarrinho
        '
        Me.LstCarrinho.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColDescricao1, Me.ColUniPreco, Me.ColQtd1, Me.ColPrecoTotal})
        Me.LstCarrinho.FullRowSelect = True
        Me.LstCarrinho.GridLines = True
        Me.LstCarrinho.LargeImageList = Me.ImageList1
        Me.LstCarrinho.Location = New System.Drawing.Point(6, 268)
        Me.LstCarrinho.Name = "LstCarrinho"
        Me.LstCarrinho.Size = New System.Drawing.Size(711, 151)
        Me.LstCarrinho.TabIndex = 12
        Me.LstCarrinho.UseCompatibleStateImageBehavior = False
        Me.LstCarrinho.View = System.Windows.Forms.View.Details
        '
        'ColDescricao1
        '
        Me.ColDescricao1.Text = "Descrição"
        Me.ColDescricao1.Width = 366
        '
        'ColUniPreco
        '
        Me.ColUniPreco.Text = "Preço Unitário"
        Me.ColUniPreco.Width = 120
        '
        'ColQtd1
        '
        Me.ColQtd1.Text = "Quantidade"
        Me.ColQtd1.Width = 80
        '
        'ColPrecoTotal
        '
        Me.ColPrecoTotal.Text = "Preço Total"
        Me.ColPrecoTotal.Width = 140
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(32, 32)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'ChkPresente
        '
        Me.ChkPresente.AutoSize = True
        Me.ChkPresente.Font = New System.Drawing.Font("Segoe UI", 8.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkPresente.Location = New System.Drawing.Point(641, 247)
        Me.ChkPresente.Name = "ChkPresente"
        Me.ChkPresente.Size = New System.Drawing.Size(71, 19)
        Me.ChkPresente.TabIndex = 11
        Me.ChkPresente.Text = "Presente"
        Me.ChkPresente.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 246)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 19)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Carrinho"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 13)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 19)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Categoria"
        '
        'ComboCategoria
        '
        Me.ComboCategoria.FormattingEnabled = True
        Me.ComboCategoria.Location = New System.Drawing.Point(6, 35)
        Me.ComboCategoria.Name = "ComboCategoria"
        Me.ComboCategoria.Size = New System.Drawing.Size(486, 25)
        Me.ComboCategoria.TabIndex = 1
        '
        'LstProd
        '
        Me.LstProd.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColCategoria, Me.ColDescricao, Me.ColPreco, Me.ColQtd})
        Me.LstProd.FullRowSelect = True
        Me.LstProd.GridLines = True
        Me.LstProd.LargeImageList = Me.ImageList1
        Me.LstProd.Location = New System.Drawing.Point(6, 66)
        Me.LstProd.Name = "LstProd"
        Me.LstProd.Size = New System.Drawing.Size(777, 151)
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
        Me.ColQtd.Text = "Quantidade"
        Me.ColQtd.Width = 100
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
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TCPedido As System.Windows.Forms.TabControl
    Friend WithEvents TabDados As System.Windows.Forms.TabPage
    Friend WithEvents TabProduto As System.Windows.Forms.TabPage
    Friend WithEvents GrpBoxInfo As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
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
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ColCategoria As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColDescricao As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColPreco As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColQtd As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ChkPresente As System.Windows.Forms.CheckBox
    Friend WithEvents ChkDestinatario As System.Windows.Forms.CheckBox
    Friend WithEvents LstCarrinho As System.Windows.Forms.ListView
    Friend WithEvents ColDescricao1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColUniPreco As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColQtd1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColPrecoTotal As System.Windows.Forms.ColumnHeader

End Class
