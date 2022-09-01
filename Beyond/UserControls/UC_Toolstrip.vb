Public Class UC_Toolstrip
    ' Public BtnClick As New EventHandler(Sub() ToolStrip1_ItemClicked(Nothing, Nothing))

    Private Shared _Modo As String
    Public Event itemclick()

    Public Shared Property Modo() As String
        Get
            Return _Modo
        End Get
        Set(ByVal value As String)
            _Modo = value
        End Set
    End Property


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        'Toolstrip de runtime recebe toolstrip de design
    End Sub


    Private Sub UC_Toolstrip_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        For Each item As ToolStripItem In ToolStrip1.Items
            If Not item.Enabled Then
                item.Enabled = True
            End If
        Next
    End Sub

    Public Sub ModoSelecionado(ByVal sender As System.Object, ByVal e As ToolStripItemClickedEventArgs)
        If e.ClickedItem Is BtnNovo Then
            Modo = "NOVO"
        ElseIf e.ClickedItem Is BtnSalvar Then
            Modo = "SALVAR"
        ElseIf e.ClickedItem Is BtnAtualizar Then
            Modo = "ATUALIZAR"
        ElseIf e.ClickedItem Is BtnDeletar Then
            Modo = "DELETAR"
        ElseIf e.ClickedItem Is BtnProcurar Then
            Modo = "PROCURAR"
        ElseIf e.ClickedItem Is BtnProximo Then
            Modo = "PROXIMO"
        ElseIf e.ClickedItem Is BtnVoltar Then
            Modo = "VOLTAR"
        ElseIf e.ClickedItem Is BtnConfirmar Then
            Modo = "CONFIRMAR"
        ElseIf e.ClickedItem Is BtnRollback Then
            Modo = "ROLLBACK"
        ElseIf e.ClickedItem Is BtnLimpar Then
            Modo = "LIMPAR"
        End If
    End Sub


    Public Sub ToolStrip1_ItemClicked(sender As Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked
        ModoSelecionado(sender, e)
        RaiseEvent itemclick()
        ' BtnClick(sender, e)
    End Sub
End Class
