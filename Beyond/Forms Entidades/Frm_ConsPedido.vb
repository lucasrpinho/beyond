Imports Uteis
Imports Entidades
Imports DAO

Public Class Frm_ConsPedido

    Private frm As Frm_Pedido
    Private LstPedidos As List(Of Pedido)
    Private LstCliente As List(Of Cliente)
    Private LstVendedor As List(Of Vendedor)
    Private DAOPed As New DAO.DAO

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal frmInstancia As Form)
        InitializeComponent()

        frm = frmInstancia
    End Sub

    Private Sub Frm_ConsPedido_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub


    Private Sub Frm_ConsPedido_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        CarregaClientes()
        CarregaVendedores()
        CarregaPedidos()
    End Sub

    Private Sub CarregaPedidos()
        LstPedidos.Clear()

        Dim resposta As String = ""
        Dim vendedor = LstVendedor(ComboVendedor.SelectedIndex)
        Dim cliente = LstCliente(ComboCliente.SelectedIndex)

        LstPedidos = DAOPed.GetPedido(True, resposta, vendedor.CodVendedor, cliente.CodCliente)

        If Not LstPedidos.Count > 0 Then
            MsgBoxHelper.Alerta(Me, "A busca por pedidos não encontrou resultados.", "Informação")
            Exit Sub
        End If

        PopulateListView()
    End Sub

    Private Sub CarregaClientes()
        Dim resposta As String = ""

        ComboCliente.Items.Clear()
        ComboVendedor.Items.Clear()

        LstCliente = DAOPed.GetCliente(True, resposta, True)
        LstVendedor = DAOPed.GetVendedor(True, "")

        If Not LstCliente.Count > 0 Then
            MsgBoxHelper.Alerta(Me, "Ocorreu um erro ao buscar os clientes.", "Erro")
            Exit Sub
        End If

        ComboCliente.BeginUpdate()
        For I As Integer = 0 To LstCliente.Count - 1
            ComboCliente.Items.Add(LstCliente(I))
        Next
        ComboCliente.EndUpdate()
    End Sub

    Private Sub CarregaVendedores()
        Dim resposta As String = ""

        ComboVendedor.Items.Clear()

        LstVendedor = DAOPed.GetVendedor(True, "")

        If Not LstVendedor.Count > 0 Then
            MsgBoxHelper.Alerta(Me, "Ocorreu um erro ao buscar os vendedores.", "Erro")
            Exit Sub
        End If

        ComboVendedor.BeginUpdate()
        For I As Integer = 0 To LstVendedor.Count - 1
            ComboVendedor.Items.Add(LstVendedor(I))
        Next
        ComboVendedor.EndUpdate()
    End Sub

    Private Sub PopulateListView()
        LstPedido.Items.Clear()

        For Each ped As Pedido In LstPedidos
            Dim pedItem As New ListViewItem(New String() {ped.CodPedido, _
                LstCliente.Find(Function(c As Cliente) c.CodCliente = ped.CodCliente).Nome, _
                LstVendedor.Find(Function(v As Vendedor) v.CodVendedor = ped.CodVendedor).Nome, _
                ped.DatVenda.ToString("dd/MM/yyyy hh:mm"), _
                ped.Destinatario})

            LstPedido.Tag = pedItem
            LstPedido.Items.Add(pedItem)
        Next

        LstPedido.Sorting = SortOrder.Descending
    End Sub

    Private Sub PicConfirmar_Click(sender As System.Object, e As System.EventArgs) Handles PicConfirmar.Click
        If frm IsNot Nothing Then
            If LstPedido.SelectedItems.Count > 0 Then
                frm.objPedido = LstPedido.SelectedItems(0).Tag
            End If
            Me.Close()
        End If
    End Sub

    Private Sub LstPedido_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles LstPedido.MouseDoubleClick
        If frm IsNot Nothing Then
            If LstPedido.SelectedItems.Count > 0 Then
                frm.objPedido = LstPedido.SelectedItems(0).Tag
                Me.Close()
            End If
        End If
    End Sub
End Class