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
    Private flagImprimir As Boolean = False

    Public Sub New(frm As Frm_Principal_MDI)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        frmPrincipal = frm
    End Sub

    Private Sub Frm_Pedido_EnabledChanged(sender As Object, e As System.EventArgs) Handles Me.EnabledChanged
        If Me.Enabled Then
            frmPrincipal.UC_Toolstrip1.ToolbarItemsState(MyModo.UniqueModo, , TxtCod.Text <> String.Empty)
        End If
    End Sub

    Private Sub Frm_Pedido_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        RemoveHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
    End Sub

    Private Sub Frm_Pedido_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        DesabilitaPages()
        AddHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
        CarregaVendedoresModoNovo()
        CarregaEstados()
        CarregaClientesNovo()
        CarregaCategorias()
        CarregaProdutos()
        MyModo.UniqueModo = "PADRÃO"
        WidthColumns()
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

    Private Sub CarregaVendedoresModoNovo()

        LstVendedor.Clear()
        ComboVendedor.Items.Clear()

        Dim resposta As String = ""
        LstVendedor = DAOPedido.GetVendedor(True, resposta, True)

        If Not LstVendedor.Count > 0 Then
            ComboVendedor.Text = "NENHUM VENDEDOR ENCONTRADO. CADASTRE UM VENDEDOR PARA PODER REALIZAR UM PEDIDO."
            ComboVendedor.ForeColor = Color.Red
            ComboVendedor.Enabled = False
        Else
            ComboVendedor.ForeColor = Color.Black
            LstVendedor.RemoveAll(Function(v) v.IsAtivo = False)
            ComboVendedor.BeginUpdate()
            ComboVendedor.Items.AddRange(LstVendedor.ToArray)
            ComboVendedor.DisplayMember = "NomeCompleto"
            ComboVendedor.ValueMember = "CodVendedor"
            ComboVendedor.EndUpdate()
        End If
    End Sub

    Private Sub CarregaVendedoresModoPesquisa()

        LstVendedor.Clear()
        ComboVendedor.Items.Clear()

        Dim resposta As String = ""
        LstVendedor = DAOPedido.GetVendedor(True, resposta, True)

        If Not LstVendedor.Count > 0 Then
            ComboVendedor.Text = "NENHUM VENDEDOR ENCONTRADO."
        Else
            For i As Integer = 0 To LstVendedor.Count - 1
                If LstVendedor(i).IsAtivo = False Then
                    LstVendedor(i).NomeCompleto += " (INATIVO)"
                End If
            Next
            ComboVendedor.ForeColor = Color.Black
            ComboVendedor.BeginUpdate()
            ComboVendedor.Items.AddRange(LstVendedor.ToArray)
            ComboVendedor.DisplayMember = "NomeCompleto"
            ComboVendedor.ValueMember = "CodVendedor"
            ComboVendedor.EndUpdate()
        End If
    End Sub

    Private Sub CarregaClientesPesquisa()
        LstCliente.Clear()
        ComboCliente.Items.Clear()

        Dim resposta As String = ""

        LstCliente = DAOPedido.GetCliente(True, resposta)

        If Not LstCliente.Count > 0 Then
            ComboCliente.ForeColor = Color.Red
            ComboCliente.Text = "NENHUM CLIENTE ENCONTRADO."
            ComboCliente.Enabled = False
        Else
            For i As Integer = 0 To LstCliente.Count - 1
                If Not LstCliente(i).IsAtivo Then
                    LstCliente(i).Nome += " (INATIVO)"
                End If
            Next
            ComboCliente.ForeColor = Color.Black
            ComboCliente.BeginUpdate()
            ComboCliente.Items.AddRange(LstCliente.ToArray)
            ComboCliente.DisplayMember = "Nome"
            ComboCliente.ValueMember = "CodCliente"
            ComboCliente.EndUpdate()
        End If
    End Sub

    Private Sub CarregaClientesNovo()
        LstCliente.Clear()
        ComboCliente.Items.Clear()

        Dim resposta As String = ""

        LstCliente = DAOPedido.GetCliente(True, resposta)

        If Not LstCliente.Count > 0 Then
            ComboCliente.ForeColor = Color.Red
            ComboCliente.Text = "NENHUM CLIENTE ENCONTRADO. CADASTRE UM CLIENTE PARA PODER EFETUAR UM PEDIDO."
            ComboCliente.Enabled = False
        Else
            ComboCliente.ForeColor = Color.Black
            LstCliente.RemoveAll(Function(c) c.IsAtivo = False)
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
            ComboProduto.Text = "NENHUM PRODUTO ENCONTRADO."
            ComboProduto.Enabled = False
            ComboProduto.ForeColor = Color.Red
            Exit Sub
        End If

        ComboProduto.Enabled = True
        ComboProduto.ForeColor = Color.Black
        ComboProduto.BeginUpdate()
        ComboProduto.Items.AddRange(LstProduto.ToArray)
        ComboProduto.DisplayMember = "Nome"
        ComboProduto.ValueMember = "CodProduto"
        ComboProduto.EndUpdate()
    End Sub

    Private Sub CarregaProdutosCategoria()
        Dim resposta As String = ""

        LstProduto.Clear()
        ComboProduto.Items.Clear()

        LstProduto = DAOPedido.GetProdutoPorCategoriaOuNome(ComboCategoria.Text, "")

        If Not LstProduto.Count > 0 Then
            MsgBoxHelper.Alerta(Me, "A busca não encontrou resultados.", "Sem Produtos")
            Exit Sub
        End If

        LstProduto.RemoveAll(Function(p) p.IsAtivo = False)

        ComboProduto.BeginUpdate()
        ComboProduto.Items.AddRange(LstProduto.ToArray)
        ComboProduto.DisplayMember = "Nome"
        ComboProduto.ValueMember = "CodProduto"
        ComboProduto.EndUpdate()

        PopulateLstViewProduto(LstProduto)

    End Sub

    Private Sub CarregaCategorias()
        Dim resposta As String = ""

        ComboCategoria.Items.Clear()
        LstCategoria.Clear()

        LstCategoria = DAOPedido.GetCategoriasProduto(resposta)

        If Not LstCategoria.Count > 0 Then
            ComboCategoria.Text = "NENHUMA CATEGORIA DE PRODUTO FOI ENCONTRADA."
            ComboCategoria.Enabled = False
            ComboCategoria.ForeColor = Color.Red
            Exit Sub
        End If

        ComboCategoria.Enabled = True
        ComboCategoria.ForeColor = Color.Black
        ComboCategoria.BeginUpdate()
        For I As Integer = 0 To LstCategoria.Count - 1
            ComboCategoria.Items.Add(LstCategoria(I))
        Next
        ComboCategoria.EndUpdate()
    End Sub

    Private Sub ModoNovo()
        LimpaCampos_Ativa()
        ClearLists()
        ClearImgProd()
        CarregaCategorias()
        CarregaClientesNovo()
        CarregaProdutos()
        CarregaVendedoresModoNovo()
        ComboCliente.Focus()
        TxtCod.Enabled = False
    End Sub

    Private Sub ClearLists()
        LstProd.Items.Clear()
        LstCarrinho.Items.Clear()
    End Sub

    Private Sub PopulateLstViewProduto(ByVal lst As List(Of Produto), Optional produtoCombo As Produto = Nothing)
        LstProd.Items.Clear()

        If produtoCombo IsNot Nothing Then
            If produtoCombo.Imagem <> "" Then
                ImageList1.Images.Add(Image.FromFile(produtoCombo.Imagem))
            End If
            Dim lstViewItem As New ListViewItem(produtoCombo.Categoria)
            Dim item = LstProd.Items.Add(lstViewItem)
            item.Name = produtoCombo.CodProduto.ToString

            Dim subItemNome = item.SubItems.Add(produtoCombo.Nome)
            subItemNome.Name = "NOME"

            Dim subItemPreco = item.SubItems.Add(produtoCombo.Preco.ToString("C"))
            subItemPreco.Name = "PREÇO"

            Dim subItemEstoque = item.SubItems.Add(produtoCombo.Quantidade.ToString)
            subItemEstoque.Name = "ESTOQUE"

            If produtoCombo.Quantidade = 0 Then
                item.ForeColor = Color.Red
            End If

            item.Tag = produtoCombo
            Exit Sub
        End If

        For Each prod As Produto In lst
            If prod.Imagem <> "" Then
                ImageList1.Images.Add(Image.FromFile(prod.Imagem))
            End If

            Dim item = LstProd.Items.Add(New ListViewItem(prod.Categoria))
            item.Name = prod.CodProduto.ToString

            Dim subItemNome = item.SubItems.Add(prod.Nome)
            subItemNome.Name = "NOME"

            Dim subItemPreco = item.SubItems.Add(prod.Preco.ToString("C"))
            subItemPreco.Name = "PREÇO"

            Dim subItemQuantidade = item.SubItems.Add(prod.Quantidade.ToString)
            subItemQuantidade.Name = "QTD"

            If prod.Quantidade = 0 Then
                item.ForeColor = Color.Red
            End If

            item.Tag = prod
        Next

    End Sub

    Private Sub ComboCategoria_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ComboCategoria.SelectedIndexChanged
        If ComboCategoria.Text <> String.Empty Then
            CarregaProdutosCategoria()
        End If
    End Sub

    Private Sub LstProd_Click(sender As System.Object, e As System.EventArgs) Handles LstProd.Click
        TxtNome.Text = ""
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


            BtnComprar.Enabled = objProdSelecionado.Quantidade > 0
            BtnMaisInsere.Enabled = objProdSelecionado.Quantidade > 0
            BtnMenosInsere.Enabled = objProdSelecionado.Quantidade > 0

            LimpaInformacoesProduto()
            If objProdSelecionado.Quantidade <= 0 Then
                MsgBoxHelper.Msg(Me, "O produto escolhido esgotou.", "Esgotado")
                Exit Sub
            End If
            If objProdSelecionado.Imagem <> String.Empty Then
                PicProd.ImageLocation = objProdSelecionado.Imagem
            End If
            TxtNome.Text = objProdSelecionado.Nome
            TxtDesc.Text = objProdSelecionado.Descricao
            LblPreco.Text = "Preço: " + objProdSelecionado.Preco.ToString("C")
        End If
    End Sub

    Private Sub InsereCarrinho(qtd As String)
        objProdSelecionado.Quantidade = Integer.Parse(qtd)
        LstItens.Add(objProdSelecionado)

        Dim lstviewItem As New ListViewItem(objProdSelecionado.Nome)
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

    Private Sub PopulateCarrinho()
        If LstItens.Count > 0 Then
            For i As Integer = 0 To LstItens.Count - 1
                Dim obj = LstItens(i)
                Dim lstViewItem As New ListViewItem

                lstViewItem.Text = If(obj.IsAtivo, obj.Nome, obj.Nome + " (INATIVO)")
                lstViewItem.ForeColor = If(obj.IsAtivo, Color.Black, Color.Red)
                lstViewItem.Name = obj.CodProduto.ToString
                Dim item = LstCarrinho.Items.Add(lstViewItem)

                Dim subItem1 = item.SubItems.Add(obj.Preco.ToString("C"))
                subItem1.Name = "PRECO"

                Dim subItem2 = item.SubItems.Add(obj.Quantidade.ToString)
                subItem2.Name = "QTD"

                Dim subItem3 = item.SubItems.Add((obj.Preco * obj.Quantidade).ToString("C"))
                subItem3.Name = "PRECOTOTAL"

                item.Tag = obj
            Next
            AtualizaValorTotalDoPedido()
        End If
    End Sub

    Private Sub ComboProduto_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboProduto.SelectedIndexChanged
        If ComboProduto.Text <> String.Empty Then
            PopulateLstViewProduto(New List(Of Produto), LstProduto(ComboProduto.SelectedIndex))
        End If
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
        pedido.ValorTotal = Decimal.Parse(TxtValorTotal.Text.Replace("R$", String.Empty))

        Dim resposta As String = ""
        If Not pedido.IsValid(resposta) Then
            MsgBoxHelper.Alerta(Me, resposta, "Preenchimento")
            Return False
        End If

        pedido.CodPedido = DateTime.Now.Month.ToString + DateTime.Now.Day.ToString + "PED" + _
            pedido.CodCliente.ToString + pedido.CodVendedor.ToString + DateTime.Today.Hour.ToString + DateTime.Today.Second.ToString

        If LstPedidoItem Is Nothing Then
            LstPedidoItem = New List(Of PedidoItem)
        Else
            LstPedidoItem.Clear()
        End If

        For I As Integer = 0 To pedido.LstProduto.Count - 1
            LstPedidoItem.Add(New PedidoItem With {.CodPedido = pedido.CodPedido, _
                                                   .CodProduto = pedido.LstProduto(I).CodProduto, _
                                                   .Quantidade = pedido.LstProduto(I).Quantidade})

        Next

        If Not DAOPedido.InserePedido(pedido, LstPedidoItem, codusuario, resposta) Then
            MsgBoxHelper.Erro(Me, resposta, "Erro")
            Return False
        End If

        If MessageBox.Show("Deseja visualizar o pedido em formato de impressão?", "Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            flagImprimir = True
        Else
            flagImprimir = False
        End If

        If flagImprimir Then
            Cursor.Current = Cursors.WaitCursor
            Dim relPedido As New Frm_RelFiltro_Pedido(pedido.CodPedido)
            relPedido.VisualizarRel()
            Cursor.Current = Cursors.Arrow
        End If

        Return True
    End Function

    Private Sub ToolStrip_ItemClicked()
        If Not Me.Enabled Then
            Exit Sub
        End If

        Dim resposta As String = ""

        MyModo.UniqueModo = UC_Toolstrip.Modo

        If MyModo.UniqueModo = "SALVAR" Then
            If UC_Toolstrip.ModoAnterior = "NOVO" Then
                If Insere() Then
                    LimpaCampos_Desativa()
                    ClearLists()
                    ClearImgProd()
                    LimpaInformacoesProduto()
                    frmPrincipal.UC_Toolstrip1.AfterSuccessfulInsert()
                Else
                    frmPrincipal.UC_Toolstrip1.ToolbarItemsState("", False)
                End If
            Else
                Dim ped = GetPedidoForOperation()
                If ped Is Nothing Then
                    frmPrincipal.UC_Toolstrip1.ToolbarItemsState("", False)
                    Exit Sub
                End If
                GetLstItensForOperation(ped.LstProduto)
                If Not DAOPedido.AtualizaPedido(ped, LstPedidoItem, resposta, False) Then
                    frmPrincipal.UC_Toolstrip1.ToolbarItemsState("", False)
                    MsgBoxHelper.Erro(Me, resposta, "Erro")
                Else
                    TCPedido.SelectTab(TabDados)
                    DesabilitaPages()
                    ControlsHelper.SetControlsEnabled(TCPedido.Controls)
                    frmPrincipal.UC_Toolstrip1.AfterSuccessfulUpdate()
                End If
            End If

        ElseIf MyModo.UniqueModo = "ALTERAR" Then
            ModoAlterar()


        ElseIf MyModo.UniqueModo = "NOVO" Then
            ModoNovo()

        ElseIf MyModo.UniqueModo = "PESQUISAR" Then
            frmPrincipal.UC_Toolstrip1.BtnPesquisar.Enabled = True
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
                    MsgBoxHelper.Msg(Me, "O pedido foi excluído com sucesso e os itens foram estornados.", "Sucesso")
                    AposSalvarComSucesso()
                    frmPrincipal.UC_Toolstrip1.AfterSuccessfulDelete()
                Else
                    MsgBoxHelper.Erro(Me, resposta + vbNewLine + vbNewLine + "Contate a equipe responsável e informe o problema.", "Erro")
                End If
            Else
                Exit Sub
            End If

        ElseIf MyModo.UniqueModo = "RELATORIO" Then
            If MsgBoxHelper.MsgTemCerteza(Me, "Deseja visualizar o pedido em formato de impressão?", "Imprimir") Then
                Cursor.Current = Cursors.WaitCursor
                If objPedido IsNot Nothing Then
                    Dim relPed As New Frm_RelFiltro_Pedido(objPedido.CodPedido)
                    relPed.VisualizarRel()
                    Cursor.Current = Cursors.Arrow
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
        ControlsHelper.SetControlsDisabled(TabItens.Controls)
        ControlsHelper.SetControlsDisabled(GrpBoxEndereco.Controls)
        ControlsHelper.SetControlsDisabled(GrpBoxInfo.Controls)
        ControlsHelper.SetControlsDisabled(TabProduto.Controls)
        ControlsHelper.SetTextsEmpty(GrpBoxInfo.Controls)
        ControlsHelper.SetTextsEmpty(GrpBoxEndereco.Controls)
        ControlsHelper.SetTextsEmpty(TabProduto.Controls)
        ControlsHelper.SetTextsEmpty(TabItens.Controls)
        ClearLists()
        ClearImgProd()
        TxtQtd.Text = "0"
        TxtQtdInsere.Text = "0"
        TxtValorTotal.Text = 0.ToString("C")
        TabItens.Text = "Carrinho (0)"
    End Sub

    Private Sub LimpaCampos_Ativa()
        ControlsHelper.SetControlsEnabled(TCPedido.Controls)
        ControlsHelper.SetControlsEnabled(TabItens.Controls)
        ControlsHelper.SetControlsEnabled(GrpBoxEndereco.Controls)
        ControlsHelper.SetControlsEnabled(GrpBoxInfo.Controls)
        ControlsHelper.SetControlsEnabled(TabDados.Controls)
        ControlsHelper.SetControlsEnabled(TabProduto.Controls)
        ControlsHelper.SetTextsEmpty(GrpBoxInfo.Controls)
        ControlsHelper.SetTextsEmpty(GrpBoxEndereco.Controls)
        ControlsHelper.SetTextsEmpty(TabProduto.Controls)
        ControlsHelper.SetTextsEmpty(TabItens.Controls)
        ClearLists()
        ClearImgProd()
        TxtQtd.Text = "0"
        TxtQtdInsere.Text = "0"
        TxtValorTotal.Text = 0.ToString("C")
    End Sub

    Private Sub ModoPesquisa()
        LimpaCampos_Desativa()
        ControlsHelper.SetControlsDisabled(GrpBoxEndereco.Controls)
        ControlsHelper.SetControlsDisabled(GrpBoxInfo.Controls)
        ControlsHelper.SetControlsDisabled(TCPedido.TabPages(1).Controls)
        ControlsHelper.SetControlsDisabled(TCPedido.TabPages(2).Controls)
        objPedido = Nothing
        Dim frmCons As New Frm_ConsPedido(Me)
        frmCons.ShowDialog()
        If objPedido IsNot Nothing Then
            CarregaVendedoresModoPesquisa()
            CarregaClientesPesquisa()
            PreencheCampos(objPedido)
            frmPrincipal.UC_Toolstrip1.EstadoAlterarExcluir(True)
            frmPrincipal.UC_Toolstrip1.ToolStrip1.Items("BtnAnterior").Enabled = False
            frmPrincipal.UC_Toolstrip1.ToolStrip1.Items("BtnSeguinte").Enabled = False
            CarregaProdutos()
            CarregaProdutosDoPedido()
            PopulateCarrinho()
            frmPrincipal.UC_Toolstrip1.BtnVisualizarRel.Enabled = True
            ChkDestinatario.Enabled = False
        Else
            frmPrincipal.UC_Toolstrip1.PagAberta_HabilitarBotoes()
        End If
    End Sub

    Private Sub PreencheCampos(ByVal obj As Pedido)
        TxtCod.Text = obj.CodPedido
        ChkDestinatario.Checked = obj.IsClienteDestinatario
        TxtDestinatario.Text = obj.Destinatario
        DtPckVenda.Value = obj.DatVenda
        ComboCliente.SelectedItem = LstCliente.First(Function(c) c.CodCliente = obj.CodCliente)
        ComboCliente.Text = LstCliente.First(Function(c) c.CodCliente = obj.CodCliente).Nome
        ComboVendedor.SelectedItem = LstVendedor.First(Function(v) v.CodVendedor = obj.CodVendedor)
        ComboVendedor.Text = LstVendedor.First(Function(v) v.CodVendedor = obj.CodVendedor).NomeCompleto
        ChkPresente.Checked = objPedido.IsPresente
        Endereco = obj.ObjEndereco
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
        LimpaInformacoesProduto()
        TxtQtdInsere.Text = "0"
        TxtQtd.Text = "0"
        CarregaCategorias()
        CarregaProdutos()
        ControlsHelper.SetControlsEnabled(TCPedido.TabPages(0).Controls)
        ControlsHelper.SetControlsEnabled(GrpBoxEndereco.Controls)
        ControlsHelper.SetControlsEnabled(TCPedido.TabPages(1).Controls)
        LstProd.Items.Clear()
        ClearImgProd()
        ChkDestinatario.Enabled = False
        ComboCategoria.Text = ""
        ComboProduto.Text = ""
        ControlsHelper.SetControlsEnabled(TCPedido.TabPages(2).Controls)
        ComboCliente.SelectedItem = LstCliente.First(Function(c) c.CodCliente = objPedido.CodCliente)
        ComboVendedor.SelectedItem = LstVendedor.First(Function(v) v.CodVendedor = objPedido.CodVendedor)
    End Sub

    Private Sub ClearImgProd()
        If PicProd.Image IsNot Nothing Then
            PicProd.Image = Nothing
        End If
    End Sub

    Private Sub ModoPesquisaPreenchido()
        CarregaVendedoresModoPesquisa()
        CarregaClientesPesquisa()
        TCPedido.SelectTab(TabDados)
        LimpaCampos_Desativa()
        CarregaProdutosDoPedido()
        PreencheCampos(objPedido)
        frmPrincipal.UC_Toolstrip1.EstadoAlterarExcluir(True)
        frmPrincipal.UC_Toolstrip1.ToolStrip1.Items("BtnAnterior").Enabled = False
        frmPrincipal.UC_Toolstrip1.ToolStrip1.Items("BtnSeguinte").Enabled = False
        PopulateCarrinho()
    End Sub

    Private Sub CarregaProdutosDoPedido()
        LstItens.Clear()

        Dim resposta As String = ""
        If objPedido IsNot Nothing Then
            LstPedidoItem = DAOPedido.GetItemPedido(objPedido.CodPedido, resposta)
        End If

        If Not LstPedidoItem.Count > 0 Then
            MsgBoxHelper.Alerta(Me, "A busca não encontrou os itens do pedido " + objPedido.CodPedido + ".", "Alerta")
            Exit Sub
        End If

        LstProduto.Clear()

        LstProduto = DAOPedido.GetProdutos(resposta, True)

        TabItens.Text = TabItens.Text.Replace("0", LstPedidoItem.Count.ToString)

        For i As Integer = 0 To LstPedidoItem.Count - 1
            Dim index = i
            LstItens.Add(LstProduto.FirstOrDefault(Function(p As Produto) p.CodProduto = LstPedidoItem(index).CodProduto))
            LstItens(i).Quantidade = LstPedidoItem(i).Quantidade
        Next
    End Sub

    Private Function GetPedidoForOperation() As Pedido

        If objPedido Is Nothing Or Not ValidaPreenchimento() Then
            Return Nothing
        End If
        Dim obj = objPedido

        obj.CodCliente = LstCliente.Find(Function(c) c Is ComboCliente.SelectedItem).CodCliente
        obj.CodVendedor = LstVendedor.Find(Function(v) v Is ComboVendedor.SelectedItem).CodVendedor
        obj.DatVenda = DtPckVenda.Value
        obj.Destinatario = TxtDestinatario.Text
        obj.IsClienteDestinatario = ChkDestinatario.Checked
        obj.Observacao = TxtObs.Text
        obj.IsPresente = ChkPresente.Checked
        obj.Destinatario = TxtDestinatario.Text
        obj.ObjEndereco.CEP = StringHelper.NumericOnly(TxtCEP.Text)
        obj.ObjEndereco.Logradouro = TxtLogradouro.Text.ToUpper
        obj.ObjEndereco.Bairro = TxtBairro.Text.ToUpper
        obj.ObjEndereco.Cidade = TxtCidade.Text.ToUpper
        obj.ObjEndereco.UF = LstEstados.Item(ComboEstado.SelectedIndex).UF
        obj.ObjEndereco.Complemento = TxtComplemento.Text.ToUpper
        obj.ObjEndereco.NumeroEndereco = StringHelper.NumericOnly(TxtNum.Text)
        obj.ValorTotal = Decimal.Parse(TxtValorTotal.Text.Replace("R$", ""))
        obj.LstProduto = LstItens
        Dim resposta As String = ""
        If Not obj.ObjEndereco.IsEnderecoValid(resposta) Then
            MsgBoxHelper.Alerta(Me, resposta, "Preenchimento inválido")
            Return Nothing
        End If
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
        If Char.IsPunctuation(e.KeyChar) Or Char.IsLetter(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub BtnMais_Click(sender As System.Object, e As System.EventArgs) Handles BtnMais.Click
        If Not LstCarrinho.Items.Count > 0 Then
            Exit Sub
        End If
        If objProdSelecionado Is Nothing Then
            MsgBoxHelper.Msg(Me, "Selecione um produto da lista.", "Produto indefinido")
            Exit Sub
        End If

        Dim obj As New Produto(LstProduto.First(Function(p As Produto) objProdSelecionado.CodProduto = p.CodProduto))

        Dim qtd = Integer.Parse(TxtQtd.Text)
        qtd = qtd + 1
        TxtQtd.Text = qtd.ToString
        If Integer.Parse(TxtQtd.Text) > obj.Quantidade Then
            MsgBoxHelper.Alerta(Me, "A quantidade desejada é maior do que a disponível em estoque.", "Estoque insuficiente")
            TxtQtd.Text = (Integer.Parse(TxtQtd.Text) - 1).ToString
            Exit Sub
        End If

        LstCarrinho.Items(obj.CodProduto.ToString).SubItems("QTD").Text = TxtQtd.Text
        Dim precoQtd = obj.Preco * Integer.Parse(TxtQtd.Text)
        LstCarrinho.Items(obj.CodProduto.ToString).SubItems("PRECOTOTAL").Text = precoQtd.ToString("C")
        LstItens.First(Function(i) i.CodProduto = obj.CodProduto).Quantidade = qtd
        AtualizaValorTotalDoPedido()
    End Sub

    Private Sub BtnMenosInsere_Click(sender As System.Object, e As System.EventArgs) Handles BtnMenosInsere.Click
        If Not LstProd.Items.Count > 0 Then
            Exit Sub
        End If
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
        TxtNome.Text = ""
        TxtDesc.Text = ""
        If PicProd.Image IsNot Nothing Then
            PicProd.Image = Nothing
        End If
    End Sub

    Private Sub BtnComprar_Click(sender As System.Object, e As System.EventArgs) Handles BtnComprar.Click
        If TxtDesc.Text = "" Then
            MsgBoxHelper.Alerta(Me, "É necessário selecionar um item.", "Item não escolhido")
            '
            '
            '
            '
            '
            '
            '
            '
        ElseIf Integer.Parse(TxtQtdInsere.Text) <= 0 Then
            MsgBoxHelper.Alerta(Me, "Informe a quantidade desejada.", "Quantidade insuficiente")
        ElseIf Integer.Parse(TxtQtdInsere.Text) > objProdSelecionado.Quantidade Then
            MsgBoxHelper.Alerta(Me, "A quantidade informada é maior do que a disponível em estoque.", "Estoque Insuficiente")
        Else
            If LstItens.Any(Function(p As Produto) p.CodProduto = objProdSelecionado.CodProduto) Then
                MsgBoxHelper.Alerta(Me, "Produto já foi adicionado ao carrinho.", "Produto repetido")
                Exit Sub
            End If

            TabItens.Text = TabItens.Text.Replace(LstCarrinho.Items.Count.ToString, (LstCarrinho.Items.Count + 1).ToString)
            InsereCarrinho(TxtQtdInsere.Text)
            If MsgBoxHelper.MsgTemCerteza(Me, "Item adicionado! Deseja ir para o carrinho?", "Continuar") Then
                TCPedido.SelectTab("TabItens")
                LstCarrinho.Focus()
                LstCarrinho.Items(LstItens.Last.CodProduto.ToString).Selected = True
            End If
            LimpaInformacoesProduto()
        End If
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
        If Not LstCarrinho.Items.Count > 0 Then
            Exit Sub
        End If
        If objProdSelecionado Is Nothing Then
            MsgBoxHelper.Msg(Me, "Selecione um produto da lista.", "Produto indefinido.")
            Exit Sub
        End If

        Dim qtd As Int32
        Int32.TryParse(TxtQtd.Text, qtd)
        qtd = qtd - 1
        TxtQtd.Text = qtd.ToString
        If TxtQtd.Text <= 0 Then
            MsgBoxHelper.Alerta(Me, "Quantidade precisa ser maior que zero.", "Quantidade insuficiente")
            TxtQtd.Text = "1"
            Exit Sub
        End If

        LstCarrinho.Items(objProdSelecionado.CodProduto.ToString).SubItems("QTD").Text = qtd.ToString
        Dim precoQtd = objProdSelecionado.Preco * qtd
        LstCarrinho.Items(objProdSelecionado.CodProduto.ToString).SubItems("PRECOTOTAL").Text = precoQtd.ToString("C")

        LstItens.First(Function(i) i.CodProduto = objProdSelecionado.CodProduto).Quantidade = qtd
        AtualizaValorTotalDoPedido()
    End Sub

    Private Function ValidaPreenchimento() As Boolean
        Dim ctrl As Control
        If (ComboCliente.Text = String.Empty) Or (ComboCliente.Text <> "" AndAlso ComboCliente.SelectedIndex = -1) Then
            TCPedido.SelectTab(TabDados)
            MsgBoxHelper.Alerta(Me, "É necessário selecionar um cliente válido.", "Alerta", ComboCliente)
            ctrl = ComboCliente

        ElseIf Not LstCliente(ComboCliente.SelectedIndex).IsAtivo Then
            TCPedido.SelectTab(TabDados)
            MsgBoxHelper.Alerta(Me, "É necessário selecionar um cliente ativo.", "Alerta", ComboCliente)
            ctrl = ComboCliente

        ElseIf (ComboVendedor.Text = String.Empty) Or (ComboVendedor.Text <> "" AndAlso ComboVendedor.SelectedIndex = -1) Then
            TCPedido.SelectTab(TabDados)
            MsgBoxHelper.Alerta(Me, "É necessário selecionar um vendedor.", "Alerta", ComboVendedor)
            ctrl = ComboVendedor

        ElseIf Not LstVendedor(ComboVendedor.SelectedIndex).IsAtivo Then
            TCPedido.SelectTab(TabDados)
            MsgBoxHelper.Alerta(Me, "É necessário selecionar um vendedor ativo.", "Alerta", ComboVendedor)
            ctrl = ComboVendedor

        ElseIf TxtDestinatario.Text = String.Empty Then
            TCPedido.SelectTab(TabDados)
            MsgBoxHelper.Alerta(Me, "Destinatário do pedido precisa ser preenchido.", "Alerta", TxtDestinatario)
            ctrl = TxtDestinatario
            TxtDestinatario.Focus()
            Return False

        ElseIf Not TxtCEP.MaskCompleted Then
            MsgBoxHelper.Alerta(Me, "CEP inválido.", "Alerta", TxtCEP)
            ctrl = TxtCEP

        ElseIf TxtLogradouro.Text = String.Empty Then
            MsgBoxHelper.Alerta(Me, "Logradouro precisa ser preenchido.", "Alerta", TxtLogradouro)
            ctrl = TxtLogradouro

        ElseIf TxtNum.Text = String.Empty Then
            MsgBoxHelper.Alerta(Me, "Número precisa ser preenchido.", "Alerta", TxtNum)
            ctrl = TxtNum

        ElseIf TxtBairro.Text = String.Empty Then
            MsgBoxHelper.Alerta(Me, "Bairro precisa ser preenchido.", "Alerta", TxtBairro)
            ctrl = TxtBairro

        ElseIf TxtCidade.Text = String.Empty Then
            MsgBoxHelper.Alerta(Me, "Cidade precisa ser preenchida.", "Alerta", TxtCidade)
            ctrl = TxtCidade

        ElseIf ComboEstado.SelectedIndex = -1 Then
            MsgBoxHelper.Alerta(Me, "Estado precisa ser preenchido.", "Alerta", ComboEstado)
            ComboEstado.DroppedDown = True
            ctrl = ComboEstado

        ElseIf LstCarrinho.Items.Count = 0 Then
            TCPedido.SelectTab(TabProduto)
            MsgBoxHelper.Alerta(Me, "O pedido está sem itens. Necessário adicionar algum produto ao carrinho.",
                                "Carrinho vazio".ToUpper, ComboProduto)
            ctrl = ComboProduto
        End If

        Return IsNothing(ctrl)
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

        If MessageBox.Show("Deseja remover o item selecionado?", "Remoção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            TabItens.Text = TabItens.Text.Replace(LstCarrinho.Items.Count.ToString, (LstCarrinho.Items.Count - 1).ToString)
            If MyModo.UniqueModo = "ALTERAR" Then
                LstItens.First(Function(o) o.CodProduto = objProdSelecionado.CodProduto).Quantidade = 0
            Else
                LstItens.Remove(LstItens.First(Function(p) p.CodProduto = objProdSelecionado.CodProduto))
            End If
            LstCarrinho.Items.RemoveByKey(objProdSelecionado.CodProduto)
            TxtQtd.Text = "0"
            AtualizaValorTotalDoPedido()
            BtnDeletaItem.Visible = False
        Else
            Exit Sub
        End If
    End Sub

    Private Sub ComboProduto_TextChanged(sender As System.Object, e As System.EventArgs) Handles ComboProduto.TextChanged
        If ComboProduto.Text <> String.Empty Then
            Dim lstProduto As New List(Of Produto)
            lstProduto = DAOPedido.GetProdutoPorCategoriaOuNome(ComboCategoria.Text, ComboProduto.Text)
            If lstProduto.Count > 0 Then
                PopulateLstViewProduto(lstProduto)
            Else
                LstProd.Items.Clear()
            End If
        Else
            LstProd.Items.Clear()
        End If
    End Sub

    Private Sub ComboCliente_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ComboCliente.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub ComboVendedor_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ComboVendedor.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub ComboCategoria_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ComboCategoria.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub ComboProduto_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ComboProduto.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub AposSalvarComSucesso()
        ClearLists()
        TxtQtd.Text = "0"
        TxtQtdInsere.Text = "0"
        TxtValorTotal.Text = 0.ToString("C")
        ClearImgProd()
        TabItens.Text = TabItens.Text = "Carrinho (0)"
        LimpaInformacoesProduto()
        LimpaCampos_Desativa()
        frmPrincipal.UC_Toolstrip1.AfterSuccessfulInsert()
        TCPedido.SelectTab(TabDados)
    End Sub

    Private Sub DesabilitaPages()
        ControlsHelper.SetControlsDisabled(GrpBoxEndereco.Controls)
        ControlsHelper.SetControlsDisabled(GrpBoxInfo.Controls)
        ControlsHelper.SetControlsDisabled(TCPedido.TabPages(1).Controls)
        ControlsHelper.SetControlsDisabled(TCPedido.TabPages(2).Controls)
    End Sub

    Private Sub WidthColumns()
        Dim widthtotal As Integer = 0
        For Each Column As ColumnHeader In LstProd.Columns
            widthtotal = widthtotal + Column.Width
        Next
        If LstProd.Width > widthtotal Then
            LstProd.BeginUpdate()
            Dim newWidthDesc As Integer = 0
            newWidthDesc = (LstProd.Width - widthtotal)
            LstProd.Columns(1).Width = LstProd.Columns(1).Width + newWidthDesc
            LstProd.EndUpdate()
        End If

        widthtotal = 0

        For Each column As ColumnHeader In LstCarrinho.Columns
            widthtotal = widthtotal + column.Width
        Next
        If LstCarrinho.Width > widthtotal Then
            LstCarrinho.BeginUpdate()
            Dim newWidthDesc As Decimal = LstCarrinho.Width - widthtotal
            LstCarrinho.Columns(0).Width += newWidthDesc
            LstCarrinho.EndUpdate()
        End If
    End Sub

    Private Sub TxtDestinatario_ReadOnlyChanged(sender As System.Object, e As System.EventArgs) Handles TxtDestinatario.ReadOnlyChanged
        If ChkDestinatario.Checked Then
            If ComboCliente.SelectedIndex > -1 Then
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
        End If
    End Sub

    Private Sub BtnMaisInsere_Click_1(sender As System.Object, e As System.EventArgs) Handles BtnMaisInsere.Click
        If Not LstProd.Items.Count > 0 Then
            Exit Sub
        End If

        If objProdSelecionado Is Nothing Then
            MsgBoxHelper.Msg(Me, "Selecione um produto da lista.", "Produto indefinido")
            Exit Sub
        End If

        TxtQtdInsere.Text = (Integer.Parse(TxtQtdInsere.Text) + 1).ToString
        If Integer.Parse(TxtQtdInsere.Text) > objProdSelecionado.Quantidade Then
            MsgBoxHelper.Alerta(Me, "A quantidade desejada é maior do que a disponível em estoque.", "Estoque insuficiente")
            TxtQtdInsere.Text = (Integer.Parse(TxtQtdInsere.Text) - 1).ToString
            Exit Sub
        End If
        LblPrecoTotal.Text = "Preço Total: " + (Integer.Parse(TxtQtdInsere.Text) * objProdSelecionado.Preco).ToString("C")
    End Sub

    Private Sub BtnDeletaItem_MouseEnter(sender As System.Object, e As System.EventArgs) Handles BtnDeletaItem.MouseEnter
        Dim tooltip As New ToolTip
        tooltip.SetToolTip(BtnDeletaItem, "Deletar produto")
    End Sub

    Private Sub TxtQtdInsere_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtQtdInsere.KeyPress
        If Char.IsPunctuation(e.KeyChar) Or Char.IsLetter(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub LstCarrinho_Click(sender As System.Object, e As System.EventArgs) Handles LstCarrinho.Click
        If objProdSelecionado IsNot Nothing Then
            objProdSelecionado = Nothing
            BtnDeletaItem.Visible = False
        End If
        If LstCarrinho.SelectedItems.Count > 0 Then
            objProdSelecionado = LstCarrinho.SelectedItems(0).Tag
            TxtQtd.Text = LstCarrinho.SelectedItems(0).SubItems("QTD").Text
            BtnDeletaItem.Visible = True
        Else
            BtnDeletaItem.Visible = False
        End If
    End Sub

    Private Sub ComboVendedor_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboVendedor.SelectedIndexChanged
        If LstVendedor.Count > 0 AndAlso ComboVendedor.SelectedIndex <> -1 AndAlso ComboVendedor.Text <> String.Empty Then
            If Not LstVendedor(ComboVendedor.SelectedIndex).IsAtivo Then
                MsgBoxHelper.CustomTooltip(ComboVendedor, ComboVendedor, "Vendedor selecionado precisa estar ativo.", "Preenchimento inválido")
            End If
        End If
    End Sub

    Private Sub TxtNum_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNum.KeyPress
        If Not RegexValidation.NumEnderecoCaracteres(e.KeyChar.ToString) Or Not Char.IsControl(e.KeyChar) Then
            e.KeyChar = ""
        End If
    End Sub

End Class