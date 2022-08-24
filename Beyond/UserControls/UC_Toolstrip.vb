Public Class UC_Toolstrip

    ' Possível que seja removido no futuro
    Public WithEvents ToolStrip0 As ToolStrip

    Public Shared BtnClick As EventHandler

    ' Shared pois o componente só será instanciado uma vez no form principal MDI e todas as telas
    ' devem ter acesso ao MESMO valor
    Private Shared _Modo As String

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
        ToolStrip0 = Me.ToolStrip1
    End Sub


    Private Sub UC_Toolstrip_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        For Each item As ToolStripItem In ToolStrip0.Items
            If Not item.Enabled Then
                item.Enabled = True
            End If
        Next
    End Sub

    'Public Sub AfterInsert()
    '    Dim itens = ToolStrip0.Items
    '    For Each item As ToolStripItem In itens
    '        If Not item.Name = "BtnRollback" Or Not item.Name = "BtnCommit" Then
    '            item.Enabled = False
    '        End If
    '    Next
    'End Sub

    Public Sub ModoSelecionado(ByVal sender As System.Object, ByVal e As ToolStripItemClickedEventArgs)
        If e.ClickedItem Is BtnNovo Then
            Modo = "NOVO"
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
        End If
    End Sub


    Public Sub ToolStrip1_ItemClicked(sender As Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked
        ModoSelecionado(sender, e)

        BtnClick(sender, e)
    End Sub
End Class
