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
End Class