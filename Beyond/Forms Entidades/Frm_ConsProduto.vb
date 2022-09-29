Imports Entidades
Imports DAO
Imports Uteis

Public Class Frm_ConsProduto

    Private LstProduto As New List(Of Produto)
    Private LstCategoria As New List(Of String)
    Private DAOProd As New DAO.DAO
    Private frmInstancia As Frm_Produto

    Private Sub Frm_ConsProduto_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub CarregaFechamento()
        Cursor.Current = Cursors.WaitCursor
        Threading.Thread.Sleep(2000)
        Cursor.Current = Cursors.Default
        Me.Close()
    End Sub


    Private Sub Frm_ConsProduto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CarregaProdutos()
        CarregaCategorias()

        ComboCateg.Focus()
    End Sub

    Private Sub CarregaCategorias()
        Dim resposta As String = ""

        ComboCateg.Items.Clear()
        LstCategoria.Clear()

        LstCategoria = DAOProd.GetCategoriasProduto(resposta)

        If Not LstCategoria.Count > 0 Then
            MsgBoxHelper.Alerta(Me, "A busca não encontrou resultados.", "Sem resultados")
            CarregaFechamento()
            Exit Sub
        End If

        ComboCateg.BeginUpdate()
        For I As Integer = 0 To LstCategoria.Count - 1
            ComboCateg.Items.Add(LstCategoria(I))
        Next
        ComboCateg.EndUpdate()
    End Sub

    Private Sub CarregaProdutos()
        Dim resposta As String = ""

        LstProduto.Clear()
        ComboNome.Items.Clear()

        LstProduto = DAOProd.GetProdutos(resposta, True)

        If Not LstProduto.Count > 0 Then
            MsgBoxHelper.Alerta(Me, "A busca não encontrou resultados.", "Sem resultados")
            Exit Sub
        End If

        ComboNome.BeginUpdate()
        ComboNome.Items.AddRange(LstProduto.ToArray)
        ComboNome.DisplayMember = "Nome"
        ComboNome.ValueMember = "CodProduto"
        ComboNome.EndUpdate()

    End Sub

    Private Sub CarregaProdCateg()
        Dim resposta As String = ""

        LstProduto.Clear()
        ComboNome.Items.Clear()

        LstProduto = DAOProd.GetProdutosPorCategoria(ComboCateg.Text, resposta, True)

        If Not LstProduto.Count > 0 Then
            MsgBoxHelper.Alerta(Me, "A busca não encontrou resultados.", "Sem resultados")
            Exit Sub
        End If

        ComboNome.BeginUpdate()
        ComboNome.Items.AddRange(LstProduto.ToArray)
        ComboNome.DisplayMember = "Nome"
        ComboNome.ValueMember = "CodProduto"
        ComboNome.EndUpdate()

        PopulateListView(LstProduto)
    End Sub

    Private Sub PopulateListView(ByVal lst As List(Of Produto), Optional ByVal prod As Produto = Nothing)
        ListView1.Items.Clear()

        If prod IsNot Nothing Then
            If prod.Imagem IsNot Nothing Then
                ImageList1.Images.Add(Image.FromFile(prod.Imagem))
            End If
            Dim lstViewItem As New ListViewItem(prod.Categoria)
            Dim item = ListView1.Items.Add(lstViewItem)
            item.Name = prod.CodProduto.ToString

            Dim subItemNome = item.SubItems.Add(prod.Nome)
            subItemNome.Name = "NOME"

            Dim subItemPreco = item.SubItems.Add(prod.Preco.ToString("C"))
            subItemPreco.Name = "PREÇO"

            Dim subItemEstoque = item.SubItems.Add(prod.Quantidade.ToString)
            subItemEstoque.Name = "ESTOQUE"

            Dim ativo = If(prod.IsAtivo, "Ativo", "Inativo")
            Dim subItemAtivo = item.SubItems.Add(ativo)
            subItemAtivo.Name = "ATIVO"
            subItemAtivo.ForeColor = If(prod.IsAtivo, Color.Black, Color.Red)

            item.Tag = prod
            Exit Sub
        End If
        ListView1.Items.Clear()

        For Each p As Produto In lst
            Dim lstViewItem As New ListViewItem(p.Categoria)
            Dim item = ListView1.Items.Add(lstViewItem)
            item.Name = p.CodProduto.ToString

            Dim subItemNome = item.SubItems.Add(p.Nome)
            subItemNome.Name = "NOME"

            Dim subItemPreco = item.SubItems.Add(p.Preco.ToString("C"))
            subItemPreco.Name = "PREÇO"

            Dim subItemEstoque = item.SubItems.Add(p.Quantidade.ToString)
            subItemEstoque.Name = "ESTOQUE"

            Dim ativo = If(p.IsAtivo, "Ativo", "Inativo")
            Dim subItemAtivo = item.SubItems.Add(ativo)
            subItemAtivo.Name = "ATIVO"
            lstViewItem.Tag = p
        Next
    End Sub

    Public Sub New(ByVal frm As Frm_Produto)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.frmInstancia = frm
    End Sub

    Private Sub ComboCateg_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ComboCateg.SelectedIndexChanged
        ComboNome.Text = ""
        CarregaProdCateg()
    End Sub

    Private Sub ListView1_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
        If ListView1.SelectedItems.Count > 0 Then
            frmInstancia.objProduto = ListView1.SelectedItems(0).Tag
            Me.Close()
        End If
    End Sub

    Private Sub ComboDesc_TextChanged(sender As System.Object, e As System.EventArgs) Handles ComboNome.TextChanged
        If ComboNome.Text <> String.Empty Then
            Dim lst As List(Of Produto)
            lst = DAOProd.GetProdutoPorCategoriaOuNome(ComboCateg.Text, ComboNome.Text)
            If lst.Count > 0 Then
                PopulateListView(lst)
            Else
                ListView1.Items.Clear()
            End If
        Else
            ListView1.Items.Clear()
        End If
    End Sub

    Private Sub ChkCateg_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkCateg.CheckedChanged
        If ChkCateg.CheckState = CheckState.Checked Then
            ComboCateg.Enabled = True
            ComboCateg.Focus()
        Else
            ComboCateg.Text = ""
            ComboCateg.Enabled = False
            ComboNome.Text = String.Empty
            CarregaProdutos()
        End If
    End Sub

    Private Sub ChkDesc_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkDesc.CheckedChanged
        If ChkDesc.CheckState = CheckState.Checked Then
            ComboNome.Enabled = True
            ComboNome.Focus()
        Else
            ComboNome.Text = ""
            ComboNome.Enabled = False
        End If
    End Sub

    Private Sub ComboCateg_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ComboCateg.KeyPress
        If Char.IsLetter(e.KeyChar)Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub ComboDesc_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ComboNome.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub BtnPesquisar_Click(sender As System.Object, e As System.EventArgs)
        PopulateListView(LstProduto)
    End Sub

    Private Sub BtnConfirmar_Click(sender As System.Object, e As System.EventArgs) Handles BtnConfirmar.Click
        If ListView1.SelectedItems.Count > 0 Then
            frmInstancia.objProduto = ListView1.SelectedItems(0).Tag
        End If

        Me.Close()
    End Sub
End Class