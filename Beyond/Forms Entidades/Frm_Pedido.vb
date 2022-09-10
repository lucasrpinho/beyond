'Imports Entidades
'Imports DAO
'Imports Uteis

'Public Class Frm_Pedido

'    Private frmPrincipal As Frm_Principal_MDI
'    Private LstEstados As New List(Of EstadoUF)
'    Private LstVendedor As New List(Of Vendedor)
'    Private LstCliente As New List(Of Cliente)
'    Private LstProduto As New List(Of Produto)
'    Private LstCategoria As New List(Of String)
'    Private MyModo As New UC_Toolstrip.UniqueModo
'    Private DAOPedido As New DAO.DAO
'    Private IsOperacaoActive As Boolean

'    Public Sub New(frm As Frm_Principal_MDI)

'        ' This call is required by the designer.
'        InitializeComponent()

'        ' Add any initialization after the InitializeComponent() call.
'        frmPrincipal = frm
'    End Sub

'    Private Sub Frm_Pedido_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
'        DAOPedido.ReverterOuCommitar()
'        RemoveHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
'    End Sub

'    Private Sub Frm_Pedido_Load(sender As Object, e As System.EventArgs) Handles Me.Load
'        Uteis.ControlsHelper.SetControlsDisabled(Me)
'        AddHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
'        CarregaVendedores()
'        CarregaEstados()
'        CarregaClientes()
'        CarregaCategorias()
'        CarregaProdutos()
'        MyModo.UniqueModo = "PADRÃO"
'    End Sub

'    Private Sub CarregaEstados()
'        Dim resposta As String = ""

'        LstEstados.Clear()
'        ComboEstado.Items.Clear()

'        LstEstados = DAOPedido.GetEstados(resposta)

'        If Not LstEstados.Count > 0 Then
'            MsgBoxHelper.Alerta(Me, resposta, "UF vazio")
'        Else
'            ComboEstado.BeginUpdate()
'            ComboEstado.Items.AddRange(LstEstados.ToArray)
'            ComboEstado.DisplayMember = "Nome"
'            ComboEstado.ValueMember = "UF"
'            ComboEstado.EndUpdate()
'        End If
'    End Sub

'    Private Sub CarregaVendedores()
'        If Not MyModo.UniqueModo = "PESQUISAR" Then
'            Exit Sub
'        End If
'        LstVendedor.Clear()
'        ComboVendedor.Items.Clear()

'        Dim resposta As String = ""
'        LstVendedor = DAOPedido.GetVendedor(True, resposta)

'        If Not LstVendedor.Count > 0 Then
'            MsgBoxHelper.Alerta(Me, resposta, "Erro")
'        Else
'            ComboVendedor.BeginUpdate()
'            ComboVendedor.Items.AddRange(LstVendedor.ToArray)
'            ComboVendedor.DisplayMember = "NomeCompleto"
'            ComboVendedor.ValueMember = "CodVendedor"
'            If MyModo.UniqueModo = "PESQUISAR" Then
'                'ComboNome.SelectedIndex = 0
'            End If
'            ComboVendedor.EndUpdate()
'        End If
'    End Sub

'    Private Sub CarregaClientes()
'        If Not MyModo.UniqueModo = "PESQUISAR" Then
'            Exit Sub
'        End If
'        LstCliente.Clear()
'        ComboCliente.Items.Clear()

'        Dim resposta As String = ""

'        LstCliente = DAOPedido.GetCliente(True, resposta)

'        If Not LstCliente.Count > 0 Then
'            MsgBoxHelper.Alerta(Me, resposta, "Erro")
'        Else
'            ComboCliente.BeginUpdate()
'            ComboCliente.Items.AddRange(LstCliente.ToArray)
'            ComboCliente.DisplayMember = "Nome"
'            ComboCliente.ValueMember = "CodCliente"
'            If MyModo.UniqueModo = "PESQUISAR" Then
'                'ComboCliente.SelectedIndex = 0
'            End If
'            ComboCliente.EndUpdate()
'        End If
'    End Sub

'    Private Sub CarregaProdutos()
'        Dim resposta As String = ""

'        LstProduto.Clear()

'        LstProduto = DAOPedido.GetProdutosPorCategoria(ComboCategoria.Text, resposta)

'        If Not LstProduto.Count > 0 Then
'            MsgBoxHelper.Alerta(Me, resposta, "Erro")
'            Exit Sub
'        End If

'    End Sub

'    Private Sub CarregaCategorias()
'        Dim resposta As String = ""

'        ComboCategoria.Items.Clear()
'        LstCategoria.Clear()

'        LstCategoria = DAOPedido.GetCategoriasProduto(resposta)

'        If Not LstCategoria.Count > 0 Then
'            MsgBoxHelper.Alerta(Me, resposta, "Erro")
'            Exit Sub
'        End If

'        ComboCategoria.BeginUpdate()
'        For I As Integer = 0 To LstCategoria.Count - 1
'            ComboCategoria.Items.Add(LstCategoria(I))
'        Next
'        ComboCategoria.EndUpdate()
'    End Sub

'    Private Sub ModoNovo()
'        ControlsHelper.SetControlsEnabled(TCPedido.Controls)
'        ControlsHelper.SetControlsEnabled(GrpBoxEndereco.Controls)
'        ControlsHelper.SetControlsEnabled(GrpBoxInfo.Controls)
'        ControlsHelper.SetTextsEmpty(GrpBoxInfo.Controls)
'        ControlsHelper.SetTextsEmpty(GrpBoxEndereco.Controls)
'        ClearLists()
'        'AlternarControle()
'    End Sub

'    Private Sub ClearLists()
'        LstCarrinho.Items.Clear()
'        LstProd.Items.Clear()
'        ImageList1.Images.Clear()
'    End Sub

'    Private Sub PopulateLstViewProduto()
'        LstProd.Items.Clear()

'        For Each prod As Produto In LstProduto
'            If prod.Categoria = ComboCategoria.Text Then
'                If prod.Imagem IsNot Nothing Then
'                    ImageList1.Images.Add(Image.FromFile(prod.Imagem))
'                End If
'                Dim lstViewItem As New ListViewItem(New String() {prod.Descricao, prod.Preco.ToString("C"), prod.Quantidade.ToString})
'                lstViewItem.ImageKey = System.IO.Path.GetFileName(prod.Imagem)
'                lstViewItem.Tag = prod
'                LstProd.Items.Add(lstViewItem)
'            End If
'        Next

'        LstProd.Sorting = SortOrder.Descending
'    End Sub

'    Private Sub ComboCategoria_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ComboCategoria.SelectedIndexChanged
'        PopulateLstViewProduto()
'    End Sub
'End Class