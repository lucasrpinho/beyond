Imports Entidades
Imports DAO
Imports Uteis
Imports System.Configuration
Imports System.Data.SqlClient

Public Class Frm_RelFiltro_Pedido

    Private LstClientes As List(Of Cliente)
    Private LstVendedores As List(Of Vendedor)
    Private DAOFiltroRelCliente As New DAO.DAO

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

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub Frm_RelFiltro_Pedido_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        LstClientes = DAOFiltroRelCliente.GetCliente(True, "", True)

        If LstClientes.Count = 0 Then
            MsgBoxHelper.Alerta(Me, "A busca por clientes não retornou resultados. Não utilize o filtro de cliente.", "Sem resultados")
        Else
            ComboCliente.BeginUpdate()
            ComboCliente.Items.AddRange(LstClientes.ToArray)
            ComboCliente.DisplayMember = "Nome"
            ComboCliente.SelectedValue = "CodCliente"
            ComboCliente.EndUpdate()
        End If

        LstVendedores = DAOFiltroRelCliente.GetVendedor(True, "", True)

        If LstVendedores.Count = 0 Then
            MsgBoxHelper.Alerta(Me, "A busca por vendedores não retornou resultados. Não utilize o filtro de vendedor.", "Sem resultados")
        Else
            ComboVendedor.BeginUpdate()
            ComboVendedor.Items.AddRange(LstVendedores.ToArray)
            ComboVendedor.DisplayMember = "NomeCompleto"
            ComboVendedor.SelectedValue = "CodVendedor"
            ComboVendedor.EndUpdate()
        End If
    End Sub

    Private Sub BtnVisualizar_MouseEnter(sender As System.Object, e As System.EventArgs) Handles BtnVisualizar.MouseEnter
        BtnVisualizar.BackColor = Color.White
    End Sub

    Private Sub BtnVisualizar_MouseLeave(sender As System.Object, e As System.EventArgs) Handles BtnVisualizar.MouseLeave
        BtnVisualizar.BackColor = Color.Gainsboro
    End Sub

    Private Function ValidaData() As Boolean
            If DtInicial.Value.Date > DtFinal.Value.Date Then
                MsgBoxHelper.Alerta(Me, "A data inicial não pode ser maior que a data final.", "Data inválida")
                DtInicial.Focus()
                Return False
            End If

        Return True
    End Function

    Private Function GetPedidoDS(codcliente As Integer, codvendedor As Integer, dtinicial As DateTime, dtfinal As DateTime) As DataSet
        Using Con As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
            Using Cmd As New SqlCommand
                Cmd.Connection = Con
                Cmd.CommandText = "SP_REL_PEDIDO"
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@CODCLIENTE", codcliente)
                Cmd.Parameters.AddWithValue("@CODVENDEDOR", codvendedor)
                Cmd.Parameters.AddWithValue("@DTINICIAL", dtinicial)
                Cmd.Parameters.AddWithValue("@DTFINAL", dtfinal)
                Using Adp As New SqlDataAdapter(Cmd)
                    Using dsPedidos As New PedidosDS
                        Adp.Fill(dsPedidos, "DTPedido")
                        Cmd.Parameters.Clear()
                        Cmd.CommandText = "SP_REL_PEDIDO_ITENS"
                        Cmd.CommandType = CommandType.StoredProcedure
                        Adp.Fill(dsPedidos, "DTItensVendidos")
                        Return dsPedidos
                    End Using
                End Using
            End Using
        End Using
    End Function

    Private Sub BtnVisualizar_Click(sender As System.Object, e As System.EventArgs) Handles BtnVisualizar.Click
        If Not ValidaData() Then
            Exit Sub
        End If

        Dim codcliente As Integer = 0
        Dim codvendedor As Integer = 0

        If ChkCliente.Checked Then
            Dim c = LstClientes.FirstOrDefault(Function(cc) cc.CodCliente = ComboCliente.SelectedValue)
            If c IsNot Nothing Then
                codcliente = c.CodCliente
            End If
        End If

        If ChkVendedor.Checked Then
            Dim v = LstVendedores.FirstOrDefault(Function(vv) vv.CodVendedor = ComboVendedor.SelectedValue)
            If v IsNot Nothing Then
                codvendedor = v.CodVendedor
            End If
        End If

        Dim ds As PedidosDS = GetPedidoDS(codcliente, codvendedor, DtInicial.Value, DtFinal.Value)

        Dim rptViewer As New Frm_Rel_Pedidos(ds)

        If ds.DTPedido.Rows.Count > 0 Then
            rptViewer.Show()
            Me.Close()
        Else
            Uteis.MsgBoxHelper.Msg(Me, "A busca não encontrou resultados.", "Informação")
            Exit Sub
        End If
    End Sub
End Class