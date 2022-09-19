Imports System.Data.SqlClient
Imports System.Configuration
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class Frm_RelFiltro_Vendedores

    Private Sub BtnVisualizar_MouseEnter(sender As System.Object, e As System.EventArgs) Handles BtnVisualizar.MouseEnter
        BtnVisualizar.BackColor = Color.White
    End Sub

    Private Sub BtnVisualizar_MouseLeave(sender As System.Object, e As System.EventArgs) Handles BtnVisualizar.MouseLeave
        BtnVisualizar.BackColor = Color.Gainsboro
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub RdBtnAtivo_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RdBtnAtivo.CheckedChanged
        BtnVisualizar.Enabled = RdBtnAtivo.Checked
    End Sub

    Private Sub RdBtnTodos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RdBtnTodos.CheckedChanged
        BtnVisualizar.Enabled = RdBtnTodos.Checked
    End Sub

    Private Sub BtnVisualizar_Click(sender As System.Object, e As System.EventArgs) Handles BtnVisualizar.Click
        Dim mostrarTodos = RdBtnTodos.Checked
        Dim ativos = RdBtnAtivo.Checked

        Dim ds As VendedoresDS = GetVendedorDS(mostrarTodos, ativos)

        Dim rptViewer As New Frm_Rel_Vendedores(ds)

        If ds.DTVendedor.Rows.Count > 0 Then
            rptViewer.Show()
            Me.Close()
        Else
            Uteis.MsgBoxHelper.Msg(Me, "A busca não encontrou resultados.", "Informação")
            Exit Sub
        End If
    End Sub

    Private Function GetVendedorDS(ByVal todos As Boolean, ativos As Boolean) As DataSet
        Using Con As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
            Using Cmd As New SqlCommand
                Cmd.Connection = Con
                Cmd.CommandText = "SP_REL_VENDEDOR"
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@TODOS", todos)
                Cmd.Parameters.AddWithValue("@ATIVOS", ativos)
                Using Adp As New SqlDataAdapter(Cmd)
                    Using dsVendedores As New VendedoresDS
                        Adp.Fill(dsVendedores, "DTVendedor")
                        Return dsVendedores
                    End Using
                End Using
            End Using
        End Using
    End Function
End Class