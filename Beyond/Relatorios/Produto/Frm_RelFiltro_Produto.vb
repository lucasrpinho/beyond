Imports System.Data.SqlClient
Imports Uteis
Imports System.Configuration

Public Class Frm_RelFiltro_Produto

    Private RdBtnStatusCfg As Boolean = False
    Private RdBtnSaldoCfg As Boolean = False

    Private Sub BtnVisualizar_MouseEnter(sender As System.Object, e As System.EventArgs) Handles BtnVisualizar.MouseEnter
        BtnVisualizar.BackColor = Color.White
    End Sub

    Private Sub BtnVisualizar_MouseLeave(sender As System.Object, e As System.EventArgs) Handles BtnVisualizar.MouseLeave
        BtnVisualizar.BackColor = Color.Gainsboro
    End Sub

    Private Sub BtnVisualizar_Click(sender As System.Object, e As System.EventArgs) Handles BtnVisualizar.Click
        If Not RdBtnSaldoCfg Or Not RdBtnStatusCfg Then
            MsgBoxHelper.Alerta(Me, "É necessário preencher todos os filtros.", "Preenchimento incompleto")
            Exit Sub
        End If

        Dim todosStatus = RdBtnTodos.Checked
        Dim apenasAtivos = RdBtnAtivo.Checked
        Dim apenasSaldo = RdBtnSaldo.Checked
        Dim todosSaldo = RdBtnTodosSaldo.Checked

        Dim ds As ProdutosDS = GetProdutoDS(todosStatus, apenasAtivos, apenasSaldo, todosSaldo)

        Dim rptViewer As New Frm_Rel_Produtos(ds)

        If ds.DTProduto.Rows.Count > 0 Then
            rptViewer.Show()
            Me.Close()
        Else
            Uteis.MsgBoxHelper.Msg(Me, "A busca não encontrou resultados.", "Informação")
            Exit Sub
        End If
    End Sub

    Private Sub RdBtnAtivo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RdBtnAtivo.CheckedChanged
        RdBtnStatusCfg = True
    End Sub

    Private Sub RdBtnTodos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RdBtnTodos.CheckedChanged
        RdBtnStatusCfg = True
    End Sub

    Private Sub RdBtnSaldo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RdBtnSaldo.CheckedChanged
        RdBtnSaldoCfg = True
    End Sub

    Private Sub RdBtnTodosSaldo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RdBtnTodosSaldo.CheckedChanged
        RdBtnSaldoCfg = True
    End Sub

    Private Function GetProdutoDS(ByVal todosStatus As Boolean, ativosApenas As Boolean, apenasSaldo As Boolean, todosSaldo As Boolean) As DataSet
        Using Con As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
            Using Cmd As New SqlCommand
                Cmd.Connection = Con
                Cmd.CommandText = "SP_REL_PRODUTO"
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@TODOS", todosStatus)
                Cmd.Parameters.AddWithValue("@ATIVOS", ativosApenas)
                Cmd.Parameters.AddWithValue("@APENASSALDO", apenasSaldo)
                Cmd.Parameters.AddWithValue("@TODOSSALDO", todosSaldo)
                Using Adp As New SqlDataAdapter(Cmd)
                    Using dsProduto As New ProdutosDS
                        Adp.Fill(dsProduto, "DTProduto")
                        Return dsProduto
                    End Using
                End Using
            End Using
        End Using
    End Function
End Class