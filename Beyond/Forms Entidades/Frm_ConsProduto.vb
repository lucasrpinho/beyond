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


    Private Sub Frm_ConsProduto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim resposta As String = ""

        ComboBox1.Items.Clear()
        LstCategoria.Clear()

        LstCategoria = DAOProd.GetCategoriasProduto(resposta)

        If Not LstCategoria.Count > 0 Then
            MsgBoxHelper.Alerta(Me, resposta, "Erro")
            Exit Sub
        End If

        ComboBox1.BeginUpdate()
        For I As Integer = 0 To LstCategoria.Count - 1
            ComboBox1.Items.Add(LstCategoria(I))
        Next
        ComboBox1.EndUpdate()
    End Sub

    Private Sub CarregaProdutos()
        Dim resposta As String = ""

        LstProduto.Clear()

        LstProduto = DAOProd.GetProdutosPorCategoria(ComboBox1.Text, resposta)

        If Not LstProduto.Count > 0 Then
            MsgBoxHelper.Alerta(Me, resposta, "Erro")
            Exit Sub
        End If

        PopulateListView()

    End Sub

    Private Sub PopulateListView()
        ListView1.Items.Clear()

        For Each prod As Produto In LstProduto
            Dim lstViewItem As New ListViewItem(New String() {prod.Descricao, prod.Preco.ToString("C"), prod.Quantidade.ToString})
            lstViewItem.Tag = prod
            ListView1.Items.Add(lstViewItem)
        Next

        ListView1.Sorting = SortOrder.Descending
    End Sub

    Public Sub New(ByVal frm As Frm_Produto)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.frmInstancia = frm
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        CarregaProdutos()
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        If ListView1.SelectedItems.Count > 0 Then
            frmInstancia.objProduto = ListView1.SelectedItems(0).Tag
        End If

        Me.Close()
    End Sub

    Private Sub ListView1_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
        If ListView1.SelectedItems.Count > 0 Then
            frmInstancia.objProduto = ListView1.SelectedItems(0).Tag
            Me.Close()
        End If
    End Sub
End Class