Public Class UC_Toolstrip

    Private Shared _Modo As String
    Public Shared ModoAnterior As String = ""
    Public Event itemclick()


    Public Class UniqueModo
        Private _UniqueModo As String

        Property UniqueModo As String
            Get
                Return _UniqueModo
            End Get
            Set(value As String)
                _UniqueModo = value
            End Set
        End Property
    End Class


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
        Modo = "PADRÃO"
    End Sub

    Public Sub PagAberta_HabilitarBotoes()
        Me.ToolStrip1.Enabled = True
        For Each item As ToolStripItem In ToolStrip1.Items
            If (item Is BtnNovo) Or (item Is BtnPesquisar) Or (item Is BtnFecharPag) Then
                item.Enabled = True
            Else
                item.Enabled = False
            End If
        Next

        ' Modo padrão é o modo inicial da toolstrip após uma página ser aberta
    End Sub

    Public Sub ModoSelecionado(ByVal sender As System.Object, ByVal e As ToolStripItemClickedEventArgs)
        ModoAnterior = Modo
        If e.ClickedItem Is BtnNovo Then
            Modo = "NOVO"
        ElseIf e.ClickedItem Is BtnSalvar Then
            Modo = "SALVAR"
        ElseIf e.ClickedItem Is BtnAlterar Then
            Modo = "ALTERAR"
        ElseIf e.ClickedItem Is BtnExcluir Then
            Modo = "EXCLUIR"
        ElseIf e.ClickedItem Is BtnPesquisar Then
            Modo = "PESQUISAR"
        ElseIf e.ClickedItem Is BtnSeguinte Then
            Modo = "SEGUINTE"
        ElseIf e.ClickedItem Is BtnAnterior Then
            Modo = "ANTERIOR"
        ElseIf e.ClickedItem Is BtnReverter Then
            Modo = "REVERTER"
        ElseIf e.ClickedItem Is BtnFecharPag Then
            Modo = "FECHAR"
        End If
        ToolbarItemsState()
    End Sub


    Public Sub ToolStrip1_ItemClicked(sender As Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked
        ModoSelecionado(sender, e)
        RaiseEvent itemclick()
    End Sub

    Public Sub ToolbarItemsState(Optional ByVal modoAposAtivarPagina As String = "", Optional succ As Boolean = True)

        ' Toolstrip captura o MODO em que a página estava quando perdeu o foco, e retoma o estado dos itens de acordo com o respectivo modo
        If Not String.IsNullOrWhiteSpace(modoAposAtivarPagina) Then
            Modo = modoAposAtivarPagina
        End If

        ' Serve para quando uma operação falha e o toolstrip precisa retornar ao estado anterior em que estava antes de executar a operação
        If Not succ Then
            Modo = ModoAnterior
        End If

        ' Personaliza estado dos botões de acordo com o botão clicado
        If Modo = "NOVO" Then
            For Each item As ToolStripItem In ToolStrip1.Items
                If item IsNot BtnSalvar AndAlso item IsNot BtnReverter AndAlso item IsNot BtnFecharPag Then
                    item.Enabled = False
                Else
                    item.Enabled = True
                End If
            Next
        ElseIf Modo = "PESQUISAR" Then
            For Each item As ToolStripItem In ToolStrip1.Items
                If item IsNot BtnSeguinte AndAlso item IsNot BtnAnterior AndAlso item IsNot BtnFecharPag _
                    AndAlso item IsNot BtnReverter Then
                    item.Enabled = False
                Else
                    item.Enabled = True
                End If
            Next
        ElseIf Modo = "SALVAR" Then
            For Each item As ToolStripItem In ToolStrip1.Items
                If item IsNot BtnReverter AndAlso item IsNot BtnNovo AndAlso item IsNot BtnPesquisar AndAlso item IsNot BtnFecharPag Then
                    item.Enabled = False
                Else
                    item.Enabled = True
                End If
            Next
        ElseIf Modo = "ALTERAR" Then
            For Each item As ToolStripItem In ToolStrip1.Items
                If item IsNot BtnSalvar AndAlso item IsNot BtnReverter AndAlso item IsNot BtnFecharPag Then
                    item.Enabled = False
                Else
                    item.Enabled = True
                End If
            Next
        ElseIf Modo = "EXCLUIR" Then
            For Each item As ToolStripItem In ToolStrip1.Items
                If item IsNot BtnNovo AndAlso item IsNot BtnPesquisar AndAlso item IsNot BtnFecharPag AndAlso item IsNot BtnReverter Then
                    item.Enabled = False
                Else
                    item.Enabled = True
                End If
            Next
        ElseIf Modo = "REVERTER" Then
            PagAberta_HabilitarBotoes()
        ElseIf Modo = "FECHAR" Then
            Dim mainForm = Application.OpenForms.OfType(Of Frm_Principal_MDI).FirstOrDefault
            If mainForm.TCPrincipal.TabPages.Count > 0 Then
                mainForm.TCPrincipal.TabPages(mainForm.TCPrincipal.SelectedTab.Name).Controls.OfType _
                    (Of Form).FirstOrDefault.Close()
                mainForm.TCPrincipal.TabPages.Remove(mainForm.TCPrincipal.SelectedTab)
                If mainForm.TCPrincipal.TabCount > 0 Then
                    mainForm.TCPrincipal.SelectTab(mainForm.TCPrincipal.TabPages.Count - 1)
                End If
                If Not mainForm.TCPrincipal.TabPages.Count > 0 Then
                    Me.OnLoad(Nothing)
                End If
            End If
        ElseIf Modo = "PADRÃO" Then
            Me.PagAberta_HabilitarBotoes()
        End If
    End Sub

    Private Sub UC_Toolstrip_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        DesabilitarItens()
    End Sub

    Public Sub DesabilitarItens()
        Me.ToolStrip1.Focus()
        Me.ToolStrip1.Enabled = False
    End Sub

    Public Sub AfterSuccessfulInsert()
        For Each item As ToolStripItem In ToolStrip1.Items
            If item IsNot BtnAlterar AndAlso item IsNot BtnFecharPag AndAlso item IsNot BtnReverter _
                AndAlso item IsNot BtnNovo Then
                item.Enabled = False
            Else
                item.Enabled = True
            End If
        Next
    End Sub

    Public Sub AfterSuccessfulUpdate()
        For Each item As ToolStripItem In ToolStrip1.Items
            If item IsNot BtnNovo AndAlso item IsNot BtnExcluir AndAlso _
                item IsNot BtnAlterar AndAlso item IsNot BtnReverter AndAlso item IsNot BtnFecharPag Then
                item.Enabled = False
            Else
                item.Enabled = True
            End If
        Next
    End Sub

    Public Sub AfterSuccessfulDelete()
        For Each item As ToolStripItem In ToolStrip1.Items
            If item IsNot BtnNovo AndAlso item IsNot BtnReverter AndAlso item IsNot BtnFecharPag _
                AndAlso item IsNot BtnPesquisar Then
                item.Enabled = False
            Else
                item.Enabled = True
            End If
        Next
    End Sub

    Public Sub EstadoAlterarExcluir(ByVal estado As Boolean)
        Me.ToolStrip1.Items("BtnAlterar").Enabled = estado
        Me.ToolStrip1.Items("BtnExcluir").Enabled = estado
    End Sub

End Class
