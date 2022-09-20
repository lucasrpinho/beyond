Imports Uteis
Imports Entidades
Imports DAO

Public Class Frm_ConsPedido

    Private frm As Frm_Pedido
    Private LstPedidos As New List(Of Pedido)
    Private LstCliente As New List(Of Cliente)
    Private LstVendedor As New List(Of Vendedor)
    Private DAOPed As New DAO.DAO

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal frmInstancia As Frm_Pedido)
        InitializeComponent()

        frm = frmInstancia
    End Sub

    Private Sub Frm_ConsPedido_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub


    Private Sub Frm_ConsPedido_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        CarregaClientes()
        CarregaVendedores()
        CarregaPedidos()
        ComboCliente.Focus()
        DtInicial.Value = DateTime.Now.Date
        DtFinal.Value = DateTime.Now.Date
    End Sub

    Private Sub CarregaPedidos()
        'LstPedidos.Clear()

        'Dim resposta As String = ""

        'LstPedidos = DAOPed.GetPedido(resposta, 0, 0)

        'If Not LstPedidos.Count > 0 Then
        '    MsgBoxHelper.Alerta(Me, "A busca por pedidos não encontrou resultados.", "Informação")
        '    CarregaFechamento()
        '    Exit Sub
        'End If
    End Sub

    Private Sub CarregaClientes()
        Dim resposta As String = ""

        ComboCliente.Items.Clear()
        ComboVendedor.Items.Clear()

        LstCliente = DAOPed.GetCliente(True, resposta, True)
        LstVendedor = DAOPed.GetVendedor(True, "")

        If Not LstCliente.Count > 0 Then
            MsgBoxHelper.Alerta(Me, "Ocorreu um erro ao buscar os clientes.", "Erro")
            CarregaFechamento()
            Exit Sub
        End If

        ComboCliente.BeginUpdate()
        ComboCliente.Items.AddRange(LstCliente.ToArray)
        ComboCliente.DisplayMember = "Nome"
        ComboCliente.ValueMember = "CodCliente"
        ComboCliente.EndUpdate()
    End Sub

    Private Sub CarregaVendedores()
        Dim resposta As String = ""

        ComboVendedor.Items.Clear()

        LstVendedor = DAOPed.GetVendedor(True, resposta, True)

        If Not LstVendedor.Count > 0 Then
            MsgBoxHelper.Alerta(Me, resposta, "Erro")
            CarregaFechamento()
            Exit Sub
        End If

        ComboVendedor.BeginUpdate()
        ComboVendedor.Items.AddRange(LstVendedor.ToArray)
        ComboVendedor.DisplayMember = "NomeCompleto"
        ComboVendedor.ValueMember = "CodVendedor"
        ComboVendedor.EndUpdate()
    End Sub

    Private Sub PopulateListView()
        LstPedido.Items.Clear()

        For Each ped As Pedido In LstPedidos
            Dim p = ped
            Dim pedItem As New ListViewItem(New String() {p.CodPedido, _
                LstCliente.Find(Function(c As Cliente) c.CodCliente = p.CodCliente).Nome, _
                LstVendedor.Find(Function(v As Vendedor) v.CodVendedor = p.CodVendedor).NomeCompleto, _
                ped.DatVenda.ToString("dd/MM/yyyy HH:mm"), _
                ped.Destinatario})

            pedItem.Tag = ped
            LstPedido.Items.Add(pedItem)
        Next

        LstPedido.Sorting = SortOrder.Descending
    End Sub

    Private Sub LstPedido_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles LstPedido.MouseDoubleClick
        If frm IsNot Nothing Then
            If LstPedido.SelectedItems.Count > 0 Then
                frm.objPedido = LstPedido.SelectedItems(0).Tag
                Me.Close()
            End If
        End If
    End Sub

    Private Sub CarregaFechamento()
        Cursor.Current = Cursors.WaitCursor
        Threading.Thread.Sleep(2000)
        Cursor.Current = Cursors.Default
        Me.Close()
    End Sub

    Private Sub ChkCliente_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkCliente.CheckedChanged
        If ChkCliente.CheckState = CheckState.Checked Then
            ComboCliente.Enabled = True
        Else
            ComboCliente.Text = ""
            ComboCliente.Enabled = False
            ComboCliente.SelectedIndex = -1
        End If
    End Sub

    Private Sub ChkVendedor_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkVendedor.CheckedChanged
        If ChkVendedor.CheckState = CheckState.Checked Then
            ComboVendedor.Enabled = True
        Else
            ComboVendedor.Text = ""
            ComboVendedor.Enabled = False
            ComboVendedor.SelectedIndex = -1
        End If
    End Sub

    Private Sub ComboCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles ComboCliente.TextChanged
        If Not ValidaData() Then
            Exit Sub
        End If

        If ComboCliente.Text = String.Empty Then
            LstPedido.Items.Clear()
        End If

        Dim datinicial As Date = Nothing
        Dim datfinal As Date = Nothing
        If ChkData.Checked Then
            datinicial = DtInicial.Value
            datfinal = DtFinal.Value
        End If

        If ComboCliente.Text <> String.Empty AndAlso ComboCliente.SelectedIndex < 0 Then
            LstPedidos = DAOPed.GetPedido("", 0, 0, ComboCliente.Text, datinicial, datfinal)
            If LstPedidos.Count > 0 Then
                PopulateListView()
            Else
                LstPedido.Items.Clear()
            End If
        ElseIf ComboCliente.Text <> String.Empty AndAlso ComboCliente.SelectedIndex < 0 AndAlso ComboVendedor.Text <> String.Empty Then
            LstPedidos = DAOPed.GetPedido("", LstVendedor(ComboVendedor.SelectedIndex).CodVendedor, 0, ComboCliente.Text, datinicial, datfinal)
            If LstPedidos.Count > 0 Then
                PopulateListView()
            Else
                LstPedido.Items.Clear()
            End If
        End If
    End Sub

    Private Sub BtnConfirmar_Click(sender As System.Object, e As System.EventArgs) Handles BtnConfirmar.Click
        If frm IsNot Nothing Then
            If LstPedido.SelectedItems.Count > 0 Then
                frm.objPedido = LstPedido.SelectedItems(0).Tag
            End If
            Me.Close()
        End If
    End Sub

    Private Sub BtnPesquisar_Click(sender As System.Object, e As System.EventArgs) Handles BtnPesquisar.Click

        If Not ValidaData() Then
            Exit Sub
        End If

        LstPedido.Items.Clear()
        LstPedidos.Clear()

        Dim codvendedor As Integer = 0
        Dim codcliente As Integer = 0
        Dim nomecliente As String = ""
        Dim datIni As DateTime = DateTime.MinValue
        Dim datFinal As DateTime = DateTime.MinValue

        If ComboVendedor.SelectedIndex > -1 Then
            codvendedor = LstVendedor(ComboVendedor.SelectedIndex).CodVendedor
        End If

        If ComboCliente.SelectedIndex > -1 Then
            codcliente = LstCliente(ComboCliente.SelectedIndex).CodCliente
        End If

        If ComboCliente.Text <> String.Empty AndAlso LstCliente.FirstOrDefault(Function(c) c.Nome.Trim = ComboCliente.Text.Trim) Is Nothing Then
            nomecliente = ComboCliente.Text
        End If

        If ChkData.Checked Then
            datIni = DtInicial.Value
            datFinal = DtFinal.Value
        End If

        Dim resposta As String = ""

        If ChkCliente.Checked AndAlso Not ChkVendedor.Checked Then
            If ComboCliente.Text = String.Empty Then
                MsgBoxHelper.CustomTooltip(GrpBoxFiltro, ComboCliente, "O filtro de clientes foi ativado, porém nenhum cliente foi selecionado.", "Preenchimento")
                Exit Sub
            End If

        ElseIf ChkCliente.Checked AndAlso ChkVendedor.Checked Then
            If ComboCliente.Text = String.Empty Then
                MsgBoxHelper.CustomTooltip(GrpBoxFiltro, ComboCliente, "O filtro de clientes foi ativado, porém nenhum cliente foi selecionado.", "Preenchimento")
                Exit Sub
            ElseIf ComboVendedor.Text = String.Empty Then
                MsgBoxHelper.CustomTooltip(GrpBoxFiltro, ComboVendedor, "O filtro de vendedores foi ativado, porém nenhum vendedor foi selecionado.", "Preenchimento")
                Exit Sub
            End If

        ElseIf Not ChkCliente.Checked AndAlso ChkVendedor.Checked Then
            If ComboVendedor.Text = String.Empty Then
                MsgBoxHelper.CustomTooltip(GrpBoxFiltro, ComboVendedor, "O filtro de vendedores foi ativado, porém nenhum vendedor foi selecionado.", "Preenchimento")
                Exit Sub
            End If
        End If

        LstPedidos = DAOPed.GetPedido(resposta, codvendedor, codcliente, nomecliente, datIni, datFinal)

        If Not LstPedidos.Count > 0 Then
            MsgBoxHelper.Alerta(Me, "A busca não encontrou resultados.", "Sem resultados")
            Exit Sub
        End If

        PopulateListView()
    End Sub

    Private Sub ChkData_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkData.CheckedChanged
        If ChkData.CheckState = CheckState.Checked Then
            DtInicial.Enabled = True
            DtFinal.Enabled = True
        Else
            DtInicial.Enabled = False
            DtFinal.Enabled = False
        End If
    End Sub

    Private Function ValidaData() As Boolean
        If ChkData.Checked Then
            If DtInicial.Value.Date > DtFinal.Value.Date Then
                MsgBoxHelper.Alerta(Me, "A data inicial não pode ser maior que a data final.", "Data inválida")
                DtInicial.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub ComboCliente_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ComboCliente.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub
End Class