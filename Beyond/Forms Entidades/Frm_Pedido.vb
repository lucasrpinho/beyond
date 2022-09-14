Imports Entidades
Imports DAO
Imports Uteis

Public Class Frm_Pedido

    Private frmPrincipal As Frm_Principal_MDI
    Private LstEstados As New List(Of EstadoUF)
    Private LstVendedor As New List(Of Vendedor)
    Private LstCliente As New List(Of Cliente)
    Private LstProduto As New List(Of Produto)
    Private LstItens As New List(Of Produto)
    Private LstCategoria As New List(Of String)
    Private Endereco As Endereco
    Private MyModo As New UC_Toolstrip.UniqueModo
    Private DAOPedido As New DAO.DAO
    Private objProdSelecionado As Produto
    Friend objPedido As Pedido
    Private LstPedidoItem As List(Of PedidoItem)

    Public Sub New(frm As Frm_Principal_MDI)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        frmPrincipal = frm
    End Sub

    Private Sub Frm_Pedido_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        RemoveHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
    End Sub

    Private Sub Frm_Pedido_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Uteis.ControlsHelper.SetControlsDisabled(TCPedido.TabPages(0).Controls)
        Uteis.ControlsHelper.SetControlsDisabled(TCPedido.TabPages(1).Controls)
        Uteis.ControlsHelper.SetControlsDisabled(TCPedido.TabPages(2).Controls)
        AddHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
        CarregaVendedores()
        CarregaEstados()
        CarregaClientes()
        CarregaCategorias()
        CarregaProdutos()
        MyModo.UniqueModo = "PADRÃO"
    End Sub

    Private Sub CarregaEstados()
        Dim resposta As String = ""

        LstEstados.Clear()
        ComboEstado.Items.Clear()

        LstEstados = DAOPedido.GetEstados(resposta)

        If Not LstEstados.Count > 0 Then
            MsgBoxHelper.Alerta(Me, resposta, "UF vazio")
        Else
            ComboEstado.BeginUpdate()
            ComboEstado.Items.AddRange(LstEstados.ToArray)
            ComboEstado.DisplayMember = "Nome"
            ComboEstado.ValueMember = "UF"
            ComboEstado.EndUpdate()
        End If
    End Sub

    Private Sub CarregaVendedores()

        LstVendedor.Clear()
        ComboVendedor.Items.Clear()

        Dim resposta As String = ""
        LstVendedor = DAOPedido.GetVendedor(True, resposta)

        If Not LstVendedor.Count > 0 Then
            MsgBoxHelper.Alerta(Me, resposta, "Erro")
        Else
            ComboVendedor.BeginUpdate()
            ComboVendedor.Items.AddRange(LstVendedor.ToArray)
            ComboVendedor.DisplayMember = "NomeCompleto"
            ComboVendedor.ValueMember = "CodVendedor"
            ComboVendedor.EndUpdate()
        End If
    End Sub

    Private Sub CarregaClientes()
        LstCliente.Clear()
        ComboCliente.Items.Clear()

        Dim resposta As String = ""

        LstCliente = DAOPedido.GetCliente(True, resposta)

        If Not LstCliente.Count > 0 Then
            MsgBoxHelper.Alerta(Me, resposta, "Erro")
        Else
            ComboCliente.BeginUpdate()
            ComboCliente.Items.AddRange(LstCliente.ToArray)
            ComboCliente.DisplayMember = "Nome"
            ComboCliente.ValueMember = "CodCliente"
            ComboCliente.EndUpdate()
        End If
    End Sub

    Private Sub CarregaProdutos()
        Dim resposta As String = ""

        LstProduto.Clear()
        ComboProduto.Items.Clear()

        LstProduto = DAOPedido.GetProdutos(resposta)

        If Not LstProduto.Count > 0 Then
            MsgBoxHelper.Alerta(Me, resposta, "Erro")
            Exit Sub
        End If

        ComboProduto.BeginUpdate()
        ComboProduto.Items.AddRange(LstProduto.ToArray)
        ComboProduto.DisplayMember = "Descricao"
        ComboProduto.ValueMember = "CodProduto"
        ComboProduto.EndUpdate()
    End Sub

    Private Sub CarregaProdutosCategoria()
        Dim resposta As String = ""

        LstProduto.Clear()
        ComboProduto.Items.Clear()

        LstProduto = DAOPedido.GetProdutosPorCategoria(ComboCategoria.Text, resposta)

        If Not LstProduto.Count > 0 Then
            MsgBoxHelper.Alerta(Me, resposta, "Erro")
            Exit Sub
        End If

        ComboProduto.BeginUpdate()
        ComboProduto.Items.AddRange(LstProduto.ToArray)
        ComboProduto.DisplayMember = "Descricao"
        ComboProduto.ValueMember = "CodProduto"
        ComboProduto.EndUpdate()

    End Sub

    Private Sub CarregaCategorias()
        Dim resposta As String = ""

        ComboCategoria.Items.Clear()
        LstCategoria.Clear()

        LstCategoria = DAOPedido.GetCategoriasProduto(resposta)

        If Not LstCategoria.Count > 0 Then
            MsgBoxHelper.Alerta(Me, resposta, "Erro")
            Exit Sub
        End If

        ComboCategoria.BeginUpdate()
        For I As Integer = 0 To LstCategoria.Count - 1
            ComboCategoria.Items.Add(LstCategoria(I))
        Next
        ComboCategoria.EndUpdate()
    End Sub

    Private Sub ModoNovo()
        ControlsHelper.SetControlsEnabled(TCPedido.Controls)
        ControlsHelper.SetControlsEnabled(GrpBoxEndereco.Controls)
        ControlsHelper.SetControlsEnabled(GrpBoxInfo.Controls)
        ControlsHelper.SetTextsEmpty(GrpBoxInfo.Controls)
        ControlsHelper.SetTextsEmpty(GrpBoxEndereco.Controls)
        ClearLists()
        'AlternarControle()
    End Sub

    Private Sub ClearLists()
        LstProd.Items.Clear()
        ImageList1.Images.Clear()
    End Sub

    Private Sub PopulateLstViewProduto(Optional produtoCombo As Produto = Nothing)
        LstProd.Items.Clear()

        If produtoCombo IsNot Nothing Then
            If produtoCombo.Imagem IsNot Nothing Then
                ImageList1.Images.Add(Image.FromFile(produtoCombo.Imagem))
            End If
            Dim lstViewItem As New ListViewItem(produtoCombo.Categoria)
            Dim item = LstProd.Items.Add(lstViewItem)
            item.Name = produtoCombo.CodProduto.ToString

            Dim subItemDescricao = item.SubItems.Add(produtoCombo.Descricao)
            subItemDescricao.Name = "DESCRIÇÃO"

            Dim subItemPreco = item.SubItems.Add(produtoCombo.Preco.ToString("C"))
            subItemPreco.Name = "PREÇO"

            Dim subItemEstoque = item.SubItems.Add(produtoCombo.Quantidade.ToString)
            subItemEstoque.Name = "ESTOQUE"

            item.Tag = produtoCombo
            Exit Sub
        End If

        For Each prod As Produto In LstProduto
            If prod.Imagem IsNot Nothing Then
                ImageList1.Images.Add(Image.FromFile(prod.Imagem))
            End If

            Dim item = LstProd.Items.Add(New ListViewItem(prod.Categoria))
            item.Name = prod.CodProduto.ToString

            Dim subItemDescricao = item.SubItems.Add(prod.Descricao)
            subItemDescricao.Name = "DESCRIÇÃO"

            Dim subItemPreco = item.SubItems.Add(prod.Preco.ToString("C"))
            subItemPreco.Name = "PREÇO"

            Dim subItemQuantidade = item.SubItems.Add(prod.Quantidade.ToString)
            subItemQuantidade.Name = "QTD"

            item.Tag = prod
        Next

        LstProd.Sorting = SortOrder.Descending
    End Sub

    Private Sub ComboCategoria_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ComboCategoria.SelectedIndexChanged
        CarregaProdutosCategoria()
        'PopulateLstViewProduto()
    End Sub

    Private Sub LstProd_Click(sender As System.Object, e As System.EventArgs) Handles LstProd.Click
        TxtDesc.Text = ""
        LblPreco.Text = "Preço"
        LblPrecoTotal.Text = "Preço Total"
        TxtQtd.Text = "0"
        If PicProd.Image IsNot Nothing Then
            PicProd.Image = Nothing
        End If

        If objProdSelecionado IsNot Nothing Then
            objProdSelecionado = Nothing
        End If

        If LstProd.SelectedItems.Count > 0 Then
            objProdSelecionado = New Produto(LstProduto.First(Function(p) p.CodProduto = _
                                                LstProd.SelectedItems(0).Name))


            LimpaInformacoesProduto()
            If objProdSelecionado.Imagem <> String.Empty Then
                PicProd.ImageLocation = objProdSelecionado.Imagem
            End If
            TxtDesc.Text = objProdSelecionado.Descricao
            LblPreco.Text = "Preço: " + objProdSelecionado.Preco.ToString("C")
        End If
    End Sub

    Private Sub InsereCarrinho(qtd As String)
        objProdSelecionado.Quantidade = Integer.Parse(qtd)
        LstItens.Add(objProdSelecionado)

        LstCarrinho.SmallImageList = ImageList1

        Dim lstviewItem As New ListViewItem(objProdSelecionado.Descricao)
        lstviewItem.Name = objProdSelecionado.CodProduto.ToString
        Dim item = LstCarrinho.Items.Add(lstviewItem)

        Dim subItem1 = item.SubItems.Add(objProdSelecionado.Preco.ToString("C"))
        subItem1.Name = "PRECO"

        Dim subItem2 = item.SubItems.Add(objProdSelecionado.Quantidade.ToString)
        subItem2.Name = "QTD"

        Dim subItem3 = item.SubItems.Add((objProdSelecionado.Preco * objProdSelecionado.Quantidade).ToString("C"))
        subItem3.Name = "PRECOTOTAL"

        item.Tag = objProdSelecionado

        objProdSelecionado = Nothing

        LimpaInformacoesProduto()
        AtualizaValorTotalDoPedido()
    End Sub

    Private Sub ComboProduto_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboProduto.SelectedIndexChanged
        PopulateLstViewProduto(LstProduto(ComboProduto.SelectedIndex))
    End Sub

    Private Function Insere() As Boolean
        If Not ValidaPreenchimento() Then
            Return False
        End If

        Dim pedido As New Pedido
        Dim cliente = LstCliente(ComboCliente.SelectedIndex)
        pedido.CodCliente = cliente.CodCliente
        pedido.CodVendedor = LstVendedor(ComboVendedor.SelectedIndex).CodVendedor
        pedido.DatVenda = DtPckVenda.Value
        pedido.IsClienteDestinatario = ChkDestinatario.Checked
        If pedido.IsClienteDestinatario Then
            pedido.Destinatario = cliente.Nome
            pedido.ObjEndereco = cliente.ObjEndereco
        Else
            pedido.Destinatario = TxtDestinatario.Text
            pedido.ObjEndereco = New Endereco()
            pedido.ObjEndereco.CEP = StringHelper.NumericOnly(TxtCEP.Text)
            pedido.ObjEndereco.Logradouro = TxtLogradouro.Text.ToUpper
            pedido.ObjEndereco.Bairro = TxtBairro.Text.ToUpper
            pedido.ObjEndereco.Cidade = TxtCidade.Text.ToUpper
            pedido.ObjEndereco.UF = LstEstados.Item(ComboEstado.SelectedIndex).UF
            pedido.ObjEndereco.Complemento = TxtComplemento.Text.ToUpper
            pedido.ObjEndereco.NumeroEndereco = StringHelper.NumericOnly(TxtNum.Text)
        End If


        pedido.IsPresente = ChkPresente.Checked
        pedido.Observacao = TxtObs.Text

        pedido.LstProduto.AddRange(LstItens.ToArray)
        pedido.LoginCriacao = loginusuario
        pedido.ValorTotal = Decimal.Parse(TxtValorTotal.Text.Replace("R$", String.Empty))

        pedido.CodPedido = DateTime.Now.Year.ToString + DateTime.Now.Month.ToString + "PED" + _
            pedido.CodCliente.ToString + pedido.CodVendedor.ToString + pedido.LstProduto.First.CodProduto.ToString

        Dim resposta As String = ""
        If Not pedido.IsValid(resposta) Then
            MsgBoxHelper.Alerta(Me, resposta, "Preenchimento")
            Return False
        End If

        If Not DAOPedido.InserePedido(pedido, LstPedidoItem, resposta) Then
            MsgBoxHelper.Alerta(Me, resposta, "Erro")
            Return False
        End If

        Return True
    End Function

    Private Sub ToolStrip_ItemClicked()
        If Not Me.Enabled Then
            Exit Sub
        End If

        MyModo.UniqueModo = MyModo.UniqueModo

        Dim resposta As String = ""

        MyModo.UniqueModo = UC_Toolstrip.Modo

        If MyModo.UniqueModo = "SALVAR" Then
            If UC_Toolstrip.ModoAnterior = "NOVO" Then
                If Insere() Then
                    LimpaCampos_Desativa()
                    frmPrincipal.UC_Toolstrip1.AfterSuccessfulInsert()
                Else
                    frmPrincipal.UC_Toolstrip1.ToolbarItemsState("", False)
                End If
            Else
                If Not DAOPedido.AtualizaPedido(GetPedidoForOperation, LstPedidoItem _
                                                , resposta, False) Then
                    frmPrincipal.UC_Toolstrip1.ToolbarItemsState("", False)
                    MsgBoxHelper.Alerta(Me, resposta, "Erro")
                Else
                    Uteis.ControlsHelper.SetControlsDisabled(Me.Controls)
                    frmPrincipal.UC_Toolstrip1.AfterSuccessfulUpdate()
                End If
            End If

        ElseIf MyModo.UniqueModo = "ALTERAR" Then
            CarregaClientes()
            ModoAlterar()


        ElseIf MyModo.UniqueModo = "NOVO" Then
            LimpaCampos_Ativa()
            CarregaCategorias()
            CarregaClientes()
            CarregaProdutos()
            CarregaVendedores()


        ElseIf MyModo.UniqueModo = "PESQUISAR" Then
            If UC_Toolstrip.ModoAnterior = "REVERTER" Then
                ModoPesquisaPreenchido()
                Exit Sub
            End If
            ModoPesquisa()


        ElseIf MyModo.UniqueModo = "REVERTER" Then
            If Uteis.MsgBoxHelper.MsgTemCerteza(frmPrincipal, "Deseja desfazer as mudanças?", "Reverter") Then
                ToolStrip_ItemClicked()
            Else
                Exit Sub
            End If


        ElseIf MyModo.UniqueModo = "EXCLUIR" Then
            If Uteis.MsgBoxHelper.MsgTemCerteza(frmPrincipal, "Deseja excluir o item?", "Exclusão") Then
                If DAOPedido.AtualizaPedido(GetPedidoForOperation, LstPedidoItem _
                                            , resposta, True) Then
                    LimpaCampos_Ativa()
                    ControlsHelper.SetControlsDisabled(Me.Controls)
                    frmPrincipal.UC_Toolstrip1.AfterSuccessfulDelete()
                End If
            Else
                Exit Sub
            End If

        ElseIf MyModo.UniqueModo = "PADRÃO" Then
                LimpaCampos_Desativa()
                frmPrincipal.UC_Toolstrip1.PagAberta_HabilitarBotoes()
            End If
    End Sub

    Private Sub LimpaCampos_Desativa()
        ControlsHelper.SetTextsEmpty(TCPedido.TabPages(0).Controls)
        ControlsHelper.SetTextsEmpty(TCPedido.TabPages(1).Controls)
        ControlsHelper.SetTextsEmpty(TCPedido.TabPages(2).Controls)
        ControlsHelper.SetControlsDisabled(Me.Controls)
    End Sub

    Private Sub LimpaCampos_Ativa()
        ControlsHelper.SetControlsEnabled(Me.Controls)
        ControlsHelper.SetControlsEnabled(TabItens.Controls)
        ControlsHelper.SetControlsEnabled(TabDados.Controls)
        ControlsHelper.SetControlsEnabled(TabProduto.Controls)
        ControlsHelper.SetTextsEmpty(GrpBoxInfo.Controls)
        ControlsHelper.SetTextsEmpty(GrpBoxEndereco.Controls)
        ControlsHelper.SetTextsEmpty(TabProduto.Controls)
        ControlsHelper.SetTextsEmpty(TabItens.Controls)
        TxtQtd.Text = "0"
        TxtQtdInsere.Text = "0"
    End Sub

    Private Sub ModoPesquisa()
        LimpaCampos_Desativa()
        ControlsHelper.SetControlsEnabled(Me.Controls)
        ControlsHelper.SetControlsDisabled(TCPedido.TabPages(0).Controls)
        ControlsHelper.SetControlsDisabled(TCPedido.TabPages(1).Controls)
        ControlsHelper.SetControlsDisabled(TCPedido.TabPages(2).Controls)
        objPedido = Nothing
        Dim frmCons As New Frm_ConsPedido(Me)
        frmCons.ShowDialog()
        If objPedido IsNot Nothing Then
            PreencheCampos(objPedido)
            frmPrincipal.UC_Toolstrip1.EstadoAlterarExcluir(True)
            frmPrincipal.UC_Toolstrip1.ToolStrip1.Items("BtnAnterior").Enabled = False
            frmPrincipal.UC_Toolstrip1.ToolStrip1.Items("BtnSeguinte").Enabled = False
        Else
            frmPrincipal.UC_Toolstrip1.PagAberta_HabilitarBotoes()
        End If
    End Sub

    Private Sub PreencheCampos(ByVal obj As Pedido)
        Dim cliente = DAOPedido.GetCliente(obj.CodCliente, True, "")
        Dim vendedor = DAOPedido.GetVendedor(obj.CodVendedor.ToString, "")
        TxtCod.Text = obj.CodPedido
        ChkDestinatario.Checked = obj.IsClienteDestinatario
        TxtDestinatario.Text = obj.Destinatario
        DtPckVenda.Value = obj.DatVenda
        ComboCliente.SelectedItem = cliente
        ComboCliente.Text = cliente.Nome
        ComboVendedor.SelectedItem = vendedor
        ComboVendedor.Text = vendedor.NomeCompleto
        ChkPresente.Checked = objPedido.IsPresente
        TxtCEP.Text = obj.ObjEndereco.CEP
        TxtLogradouro.Text = obj.ObjEndereco.Logradouro
        TxtBairro.Text = obj.ObjEndereco.Bairro
        TxtNum.Text = obj.ObjEndereco.NumeroEndereco
        TxtCidade.Text = obj.ObjEndereco.Cidade
        ComboEstado.SelectedItem = LstEstados.Find(Function(e As EstadoUF) e.UF = obj.ObjEndereco.UF)
        TxtComplemento.Text = obj.ObjEndereco.Complemento

    End Sub

    Private Sub PreencheEnderecoAutomaticamente()
        If Not Endereco Is Nothing Then
            TxtBairro.Text = Endereco.Bairro.ToUpper
            TxtCidade.Text = Endereco.Cidade.ToUpper
            TxtLogradouro.Text = Endereco.Logradouro.ToUpper

            ComboEstado.SelectedIndex = LstEstados.FindIndex(Function(e As EstadoUF) e.UF = Endereco.UF)
        End If
    End Sub

    Private Sub TxtCEP_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCEP.TextChanged
        If TxtCEP.Text.Length >= 9 Then
            Endereco = New Endereco(EnderecoHelper.GetEnderecoViaCEP(TxtCEP.Text))
            If Endereco.ObjEnderecoJson Is Nothing Then
                Endereco = Nothing
                Exit Sub
            End If

            PreencheEnderecoAutomaticamente()
        End If
    End Sub

    Private Sub ModoAlterar()
        LimpaInformacoesProduto
        TxtQtdInsere.Text = "0"
        TxtQtd.Text = "0"
        CarregaCategorias()
        CarregaClientes()
        CarregaVendedores()
        CarregaProdutos()
        ControlsHelper.SetControlsEnabled(TCPedido.TabPages(0).Controls)
        DtPckVenda.Enabled = False
        TxtCod.Enabled = False
        ControlsHelper.SetControlsEnabled(TCPedido.TabPages(1).Controls)
        LstProd.Items.Clear()
        ClearImgProd()
        ComboCategoria.Text = ""
        ComboProduto.Text = ""
        ControlsHelper.SetControlsEnabled(TCPedido.TabPages(2).Controls)
    End Sub

    Private Sub ClearImgProd()
        If PicProd.Image IsNot Nothing Then
            PicProd.Image = Nothing
        End If
    End Sub

    Private Sub ModoPesquisaPreenchido()
        LimpaCampos_Ativa()
        ControlsHelper.SetControlsDisabled(Me.Controls)
        CarregaProdutosDoPedido()
        PreencheCampos(objPedido)
        frmPrincipal.UC_Toolstrip1.EstadoAlterarExcluir(True)
        frmPrincipal.UC_Toolstrip1.ToolStrip1.Items("BtnAnterior").Enabled = False
        frmPrincipal.UC_Toolstrip1.ToolStrip1.Items("BtnSeguinte").Enabled = False
    End Sub

    Private Sub CarregaProdutosDoPedido()
        Dim resposta As String = ""
        If objPedido IsNot Nothing Then
            LstPedidoItem = DAOPedido.GetItemPedido(objPedido.CodPedido, resposta)
        End If

        If Not LstPedidoItem.Count > 0 Then
            MsgBoxHelper.Alerta(Me, "A busca não encontrou os itens do pedido " + objPedido.CodPedido + ".", "Alerta")
            Exit Sub
        End If

        For i As Integer = 0 To LstPedidoItem.Count - 1
            Dim index = i
            LstItens.Add(LstProduto.First(Function(p As Produto) p.CodProduto = LstPedidoItem(index).CodProduto))
        Next
    End Sub

    Private Function GetPedidoForOperation() As Pedido
        If objPedido Is Nothing Then
            Return Nothing
        End If
        Dim obj = objPedido

        obj.CodCliente = LstCliente(ComboCliente.SelectedIndex).CodCliente
        obj.CodVendedor = LstVendedor(ComboVendedor.SelectedIndex).CodVendedor
        obj.DatVenda = DtPckVenda.Value
        obj.Destinatario = TxtDestinatario.Text
        obj.IsClienteDestinatario = ChkDestinatario.Checked
        obj.Observacao = ""
        obj.IsPresente = ChkPresente.Checked
        obj.ObjEndereco = Endereco
        obj.LstProduto = LstItens
        Return obj
    End Function

    Private Sub GetLstItensForOperation(lstProduto As List(Of Produto))
        LstPedidoItem.Clear()

        For i As Integer = 0 To lstProduto.Count - 1
            Dim item As New PedidoItem
            item.CodPedido = objPedido.CodPedido
            item.CodProduto = lstProduto(i).CodProduto
            item.Quantidade = lstProduto(i).Quantidade
            LstPedidoItem.Add(item)
        Next
    End Sub

    Private Sub TextBox1_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtQtd.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or _
            e.KeyChar = "-" Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub BtnMais_Click(sender As System.Object, e As System.EventArgs) Handles BtnMais.Click
        If objProdSelecionado Is Nothing Then
            MsgBoxHelper.Msg(Me, "Selecione um produto da lista.", "Produto indefinido")
            Exit Sub
        End If

        Dim obj As New Produto(LstProduto.First(Function(p As Produto) objProdSelecionado.CodProduto = p.CodProduto))

        Dim qtd = Integer.Parse(TxtQtd.Text)
        qtd = qtd + 1
        TxtQtd.Text = qtd.ToString
        If Integer.Parse(TxtQtd.Text) > obj.Quantidade Then
            MsgBoxHelper.Alerta(Me, "A quantidade desejada é maior do que o disponível em estoque.", "Estoque insuficiente")
            TxtQtd.Text = (Integer.Parse(TxtQtd.Text) - 1).ToString
            Exit Sub
        End If

        LstCarrinho.Items(obj.CodProduto.ToString).SubItems("QTD").Text = TxtQtd.Text
        Dim precoQtd = obj.Preco * Integer.Parse(TxtQtd.Text)
        LstCarrinho.Items(obj.CodProduto.ToString).SubItems("PRECOTOTAL").Text = precoQtd.ToString("C")
        AtualizaValorTotalDoPedido()
    End Sub

    Private Sub LstCarrinho_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles LstCarrinho.MouseClick
        If objProdSelecionado IsNot Nothing Then
            objProdSelecionado = Nothing
        End If
        If LstCarrinho.SelectedItems.Count > 0 Then
            objProdSelecionado = LstCarrinho.SelectedItems(0).Tag
            TxtQtd.Text = LstCarrinho.SelectedItems(0).SubItems("QTD").Text
        End If
    End Sub

    Private Sub BtnPesquisar_Click(sender As System.Object, e As System.EventArgs) Handles BtnPesquisar.Click
        PopulateLstViewProduto()
    End Sub

    Private Sub BtnMenosInsere_Click(sender As System.Object, e As System.EventArgs) Handles BtnMenosInsere.Click
        If objProdSelecionado Is Nothing Then
            MsgBoxHelper.Msg(Me, "Selecione um produto da lista.", "Produto indefinido")
            Exit Sub
        End If

        TxtQtdInsere.Text = (Integer.Parse(TxtQtdInsere.Text) - 1).ToString
        If Integer.Parse(TxtQtdInsere.Text) <= 0 Then
            MsgBoxHelper.Alerta(Me, "A quantidade precisa ser maior que zero.", "Quantidade insuficiente")
            Exit Sub
        End If
        LblPrecoTotal.Text = "Preço Total: " + (Integer.Parse(TxtQtdInsere.Text) * objProdSelecionado.Preco).ToString("C")
    End Sub

    Private Sub LimpaInformacoesProduto()
        LblPreco.Text = "Preço"
        LblPrecoTotal.Text = "Preço total"
        TxtQtdInsere.Text = "0"
        TxtDesc.Text = ""
        If PicProd.Image IsNot Nothing Then
            PicProd.Image = Nothing
        End If
    End Sub

    Private Sub BtnComprar_Click(sender As System.Object, e As System.EventArgs) Handles BtnComprar.Click
        If TxtDesc.Text = "" Then
            MsgBoxHelper.Alerta(Me, "É necessário selecionar um item.", "Item não escolhido")
        ElseIf Integer.Parse(TxtQtdInsere.Text) <= 0 Then
            MsgBoxHelper.Alerta(Me, "Informe a quantidade desejada.", "Quantidade insuficiente")
        Else
            If LstItens.Any(Function(p As Produto) p.CodProduto = objProdSelecionado.CodProduto) Then
                MsgBoxHelper.Alerta(Me, "Produto já foi adicionado ao carrinho.", "Produto repetido")
                Exit Sub
            End If
            LblQtdCarrinho.Text = (Integer.Parse(LblQtdCarrinho.Text) + 1).ToString
            InsereCarrinho(TxtQtdInsere.Text)
            If MsgBoxHelper.MsgTemCerteza(Me, "Item adicionado! Deseja ir para o carrinho?", "Continuar") Then
                TCPedido.SelectTab("TabItens")
            End If
            LimpaInformacoesProduto()
        End If
    End Sub

    Private Sub BtnMaisInsere_Click(sender As System.Object, e As System.EventArgs) Handles BtnMaisInsere.Click
        If objProdSelecionado Is Nothing Then
            MsgBoxHelper.Msg(Me, "Selecione um produto da lista.", "Produto indefinido")
            Exit Sub
        End If

        TxtQtdInsere.Text = (Integer.Parse(TxtQtdInsere.Text) + 1).ToString
        If Integer.Parse(TxtQtdInsere.Text) > objProdSelecionado.Quantidade Then
            MsgBoxHelper.Alerta(Me, "A quantidade desejada é maior do que o disponível em estoque.", "Estoque insuficiente")
            TxtQtdInsere.Text = (Integer.Parse(TxtQtdInsere.Text) - 1).ToString
            Exit Sub
        End If
        LblPrecoTotal.Text = "Preço Total: " + (Integer.Parse(TxtQtdInsere.Text) * objProdSelecionado.Preco).ToString("C")
    End Sub

    Private Sub AtualizaValorTotalDoPedido()
        Dim valortotalPedido As Decimal = 0
        For Each item As ListViewItem In LstCarrinho.Items
            Dim precoTotalProduto = Decimal.Parse(item.SubItems("PRECOTOTAL").Text.Replace("R$", ""))
            valortotalPedido = valortotalPedido + precoTotalProduto
        Next
        TxtValorTotal.Text = valortotalPedido.ToString("C")
    End Sub

    Private Sub BtnMenos_Click(sender As System.Object, e As System.EventArgs) Handles BtnMenos.Click
        If objProdSelecionado Is Nothing Then
            MsgBoxHelper.Msg(Me, "Selecione um produto da lista.", "Produto indefinido.")
            Exit Sub
        End If

        Dim qtd = Integer.Parse(TxtQtd.Text)
        qtd = qtd - 1
        TxtQtd.Text = qtd.ToString
        If TxtQtd.Text <= 0 Then
            MsgBoxHelper.Alerta(Me, "Quantidade precisa ser maior que zero.", "Quantidade insuficiente")
            TxtQtd.Text = "1"
            Exit Sub
        End If

        LstCarrinho.Items(objProdSelecionado.CodProduto.ToString).SubItems("QTD").Text = TxtQtd.Text
        Dim precoQtd = objProdSelecionado.Preco * Integer.Parse(TxtQtd.Text)
        LstCarrinho.Items(objProdSelecionado.CodProduto.ToString).SubItems("PRECOTOTAL").Text = precoQtd.ToString("C")

        AtualizaValorTotalDoPedido()
    End Sub

    Private Function ValidaPreenchimento() As Boolean
        If ComboCliente.Text = String.Empty Then
            MsgBoxHelper.CustomTooltip(GrpBoxInfo, ComboCliente, "Necessário selecionar um cliente.", _
                                       "Preenchimento incompleto")
            Return False
        ElseIf ComboVendedor.Text = String.Empty Then
            MsgBoxHelper.CustomTooltip(GrpBoxInfo, ComboVendedor, "Necessário selecionar um vendedor.", _
                                       "Preenchimento incompleto")
            Return False
        ElseIf TxtDestinatario.Text = String.Empty Then
            MsgBoxHelper.CustomTooltip(GrpBoxInfo, TxtDestinatario, "Necessário informar um destinatário.", _
                                       "Preenchimento incompleto")
            Return False
        ElseIf TxtCEP.Text = String.Empty Then
            MsgBoxHelper.CustomTooltip(GrpBoxEndereco, TxtCEP, "Necessário informar um CEP.", _
                                       "Preenchimento incompleto")
            Return False
        ElseIf TxtCEP.Text <> String.Empty AndAlso TxtNum.Text = String.Empty Then
            MsgBoxHelper.CustomTooltip(GrpBoxEndereco, TxtNum, "Necessário informar o número do endereço.", _
                                       "Preenchimento incompleto")
            Return False
        ElseIf LstCarrinho.Items.Count = 0 Then
            MsgBoxHelper.Alerta(Me, "O pedido está sem itens. Necessário adicionar algum produto ao carrinho.",
                                "Carrinho vazio")
            Return False
        End If

        Return True
    End Function

    Private Sub ChkDestinatario_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkDestinatario.CheckedChanged
        If ChkDestinatario.CheckState = CheckState.Checked Then
            TxtDestinatario.ReadOnly = True
            TxtDestinatario.Text = ComboCliente.Text
        Else
            TxtDestinatario.ReadOnly = False
            TxtDestinatario.Text = ""
        End If
    End Sub

    Private Sub TxtCEP_Enter(sender As System.Object, e As System.EventArgs) Handles TxtCEP.Enter
        If ChkDestinatario.Checked Then
            Dim c = LstCliente(ComboCliente.SelectedIndex)
            TxtCEP.Text = c.ObjEndereco.CEP
            TxtLogradouro.Text = c.ObjEndereco.Logradouro
            TxtBairro.Text = c.ObjEndereco.Bairro
            TxtNum.Text = c.ObjEndereco.NumeroEndereco.ToString
            ComboEstado.SelectedItem = LstEstados.Find(Function(es As EstadoUF) es.UF = c.ObjEndereco.UF)
            ComboEstado.Text = LstEstados.Find(Function(es As EstadoUF) es.UF = c.ObjEndereco.UF).Nome
            TxtCidade.Text = c.ObjEndereco.Cidade
            TxtComplemento.Text = c.ObjEndereco.Complemento
        End If
    End Sub

    Private Sub ComboCliente_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboCliente.SelectedIndexChanged
        If ComboCliente.Text <> String.Empty Then
            ChkDestinatario.Enabled = True
        Else
            ChkDestinatario.Enabled = False
        End If
    End Sub

    Private Sub BtnDeletaItem_Click(sender As System.Object, e As System.EventArgs) Handles BtnDeletaItem.Click
        If objProdSelecionado Is Nothing Then
            MsgBoxHelper.Alerta(Me, "Selecione o item que deseja remover do carrinho.", "Selecionar item")
            Exit Sub
        End If

        If MsgBoxHelper.MsgTemCerteza(Me, "Tem certeza que deseja remover o item do carrinho?", "Remover") Then
            LstItens.Remove(LstItens.First(Function(p) p.CodProduto = objProdSelecionado.CodProduto))
            LstCarrinho.Items.RemoveByKey(objProdSelecionado.CodProduto)
            TxtQtd.Text = "0"
            AtualizaValorTotalDoPedido()
            LblQtdCarrinho.Text = (Integer.Parse(LblQtdCarrinho.Text) - 1).ToString
        Else
            Exit Sub
        End If
    End Sub
End Class