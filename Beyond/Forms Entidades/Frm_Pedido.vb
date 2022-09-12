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

        'RemoveHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
    End Sub

    Private Sub Frm_Pedido_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Uteis.ControlsHelper.SetControlsDisabled(TCPedido.TabPages(0).Controls)
        Uteis.ControlsHelper.SetControlsDisabled(TCPedido.TabPages(1).Controls)
        Uteis.ControlsHelper.SetControlsDisabled(TCPedido.TabPages(2).Controls)
        'AddHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
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
        If Not MyModo.UniqueModo = "PESQUISAR" Then
            Exit Sub
        End If
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
        If Not MyModo.UniqueModo = "PESQUISAR" Then
            Exit Sub
        End If
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
        DataGridView1.Rows.Clear()
        LstProd.Items.Clear()
        ImageList1.Images.Clear()
    End Sub

    Private Sub PopulateLstViewProduto(Optional produtoCombo As Produto = Nothing)
        LstProd.Items.Clear()

        If produtoCombo IsNot Nothing Then
            If produtoCombo.Imagem IsNot Nothing Then
                ImageList1.Images.Add(Image.FromFile(produtoCombo.Imagem))
            End If
            Dim lstViewItem As New ListViewItem(New String() {produtoCombo.Descricao, produtoCombo.Preco.ToString("C"), produtoCombo.Quantidade.ToString})
            lstViewItem.ImageKey = System.IO.Path.GetFileName(produtoCombo.Imagem)
            lstViewItem.Tag = produtoCombo
            LstProd.Items.Add(lstViewItem)
            Exit Sub
        End If

        For Each prod As Produto In LstProduto
            If prod.Categoria = ComboCategoria.Text Then
                If prod.Imagem IsNot Nothing Then
                    ImageList1.Images.Add(Image.FromFile(prod.Imagem))
                End If
                Dim lstViewItem As New ListViewItem(New String() {prod.Descricao, prod.Preco.ToString("C"), prod.Quantidade.ToString})
                lstViewItem.ImageKey = System.IO.Path.GetFileName(prod.Imagem)
                lstViewItem.Tag = prod
                LstProd.Items.Add(lstViewItem)
            End If
        Next

        LstProd.Sorting = SortOrder.Descending
    End Sub

    Private Sub ComboCategoria_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ComboCategoria.SelectedIndexChanged
        CarregaProdutosCategoria()
        PopulateLstViewProduto()
    End Sub

    Private Sub LstProd_Click(sender As System.Object, e As System.EventArgs) Handles LstProd.Click
        TxtDesc.Text = ""
        TxtPreco.Text = ""
        If PicProd.Image IsNot Nothing Then
            PicProd.Image = Nothing
        End If

        If objProdSelecionado IsNot Nothing Then
            objProdSelecionado = Nothing
        End If

        If LstProd.SelectedItems.Count > 0 Then
            objProdSelecionado = LstProd.SelectedItems(0).Tag
            If objProdSelecionado.Imagem <> String.Empty Then
                PicProd.ImageLocation = objProdSelecionado.Imagem
            End If
            TxtDesc.Text = objProdSelecionado.Descricao
            TxtPreco.Text = objProdSelecionado.Preco.ToString("C")
        End If
    End Sub

    Private Sub PicInsereProd_Click(sender As System.Object, e As System.EventArgs) Handles PicInsereProd.Click
        If TxtDesc.Text = "" And TxtPreco.Text = "" Then
            MsgBoxHelper.Alerta(Me, "É necessário selecionar um item.", "Adicionar")
        Else
            LstItens.Add(objProdSelecionado)
            If MsgBoxHelper.MsgTemCerteza(Me, "Item adicionado! Deseja ir para o carrinho?", "Continuar") Then
                TCPedido.SelectTab("TabCarrinho")
            End If
        End If
    End Sub

    Private Sub InsereCarrinho()
        Dim index = DataGridView1.Rows.Add
        DataGridView1.Rows(index).Cells("ColImagem").Value = Image.FromFile(objProdSelecionado.Imagem)
        DataGridView1.Rows(index).Cells("ColDesc").Value = objProdSelecionado.Descricao
        DataGridView1.Rows(index).Cells("ColPreco1").Value = objProdSelecionado.Preco.ToString("C")
        DataGridView1.Rows(index).Cells("ColPrecoTotal").Value = objProdSelecionado.Preco.ToString("C")
        DataGridView1.Rows(index).Cells("ColQtd1").Value = objProdSelecionado.Quantidade.ToString
        DataGridView1.Rows(index).Cells("ColQtdBtn").Value = frmPrincipal.ImageList1.Images(6)
        DataGridView1.Rows(index).Cells("ColQtdBtn").Value = frmPrincipal.ImageList1.Images(7)
    End Sub

    Private Sub ComboProduto_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboProduto.SelectedIndexChanged
        PopulateLstViewProduto(LstProduto(ComboProduto.SelectedIndex))
    End Sub

    Private Function Insere() As Boolean
        Dim pedido As New Pedido
        Dim cliente = LstCliente(ComboCliente.SelectedIndex)
        pedido.CodCliente = cliente
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

        pedido.CodPedido = DateTime.Now.Year.ToString + DateTime.Now.Month.ToString + "PED" + _
            pedido.CodCliente.ToString + pedido.CodVendedor.ToString + DateTime.Now.Second.ToString + _
            DateTime.Now.Hour.ToString + DateTime.Now.Minute.ToString

        pedido.IsPresente = ChkPresente.Checked
        pedido.Observacao = ""

        pedido.LstProduto.AddRange(LstItens.ToArray)
        pedido.LoginCriacao = loginusuario

        Dim resposta As String = ""
        If Not pedido.IsValid(resposta) Then
            MsgBoxHelper.Alerta(Me, resposta, "Preenchimento")
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
                'If Not DAOCliente.AtualizaCliente(GetClienteForOperation, resposta, False, loginusuario) Then
                '    frmPrincipal.UC_Toolstrip1.ToolbarItemsState("", False)
                '    MsgBoxHelper.Alerta(Me, resposta, "Erro")
                'Else
                '    Uteis.ControlsHelper.SetControlsDisabled(Me.Controls)
                '    frmPrincipal.UC_Toolstrip1.AfterSuccessfulUpdate()
                'End If
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


            'ElseIf MyModo.UniqueModo = "EXCLUIR" Then
            '    If Uteis.MsgBoxHelper.MsgTemCerteza(frmPrincipal, "Deseja excluir o item?", "Exclusão") Then
            '    If DAOPedido.(GetClienteForOperation, "", True, loginusuario) Then
            '        LimpaCampos_Ativa()
            '        ControlsHelper.SetControlsDisabled(Me.Controls)
            '        frmPrincipal.UC_Toolstrip1.AfterSuccessfulDelete()
            '    End If
            'Else
            '    Exit Sub
            'End If

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
        ControlsHelper.SetTextsEmpty(TCPedido.TabPages(0).Controls)
        ControlsHelper.SetTextsEmpty(TCPedido.TabPages(1).Controls)
        ControlsHelper.SetTextsEmpty(TCPedido.TabPages(2).Controls)
        ControlsHelper.SetControlsEnabled(Me.Controls)
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
        Endereco = obj.ObjEndereco
        ChkPresente.Checked = objPedido.IsPresente
        PreencheEnderecoAutomaticamente()

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
        TxtDesc.Text = ""
        TxtPreco.Text = ""
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
            LstItens.Add(LstProduto.Find(Function(p As Produto) p.CodProduto = LstPedidoItem(index).CodProduto))
        Next
    End Sub

End Class