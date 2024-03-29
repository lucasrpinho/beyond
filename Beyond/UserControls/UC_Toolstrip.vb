﻿Public Class UC_Toolstrip

    Private Shared _Modo As String
    Public Shared ModoAnterior As String = ""
    Public Event itemclick()
    'Private IsModoEscuro As Boolean = False


    Public Class UniqueModo
        Private _UniqueModo As String
        Public UniqueModoAnterior As String
        Public PesquisaItemPreenchido As Boolean = False

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
    End Sub

    Public Sub PagAberta_HabilitarBotoes()
        Modo = "PADRÃO"
        Me.ToolStrip1.Enabled = True
        For Each item As ToolStripItem In ToolStrip1.Items
            If (item Is BtnNovo) Or (item Is BtnPesquisar) Then
                item.Enabled = True
            Else
                item.Enabled = False
            End If
        Next

        ' Modo padrão é o modo inicial da toolstrip após uma página ser aberta
    End Sub

    Public Sub ModoSelecionado(ByVal sender As System.Object, ByVal e As ToolStripItemClickedEventArgs)
        If Modo IsNot "IMAGEM" Then
            ModoAnterior = Modo
        End If
        If e.ClickedItem Is BtnNovo Then
            Modo = "NOVO"
        ElseIf e.ClickedItem Is BtnSalvar Then
            If ModoAnterior = "ALTERAR" Then
                If Not Uteis.MsgBoxHelper.MsgTemCerteza(Application.OpenForms.OfType(Of Frm_Principal_MDI).First _
                                                    .TCPrincipal.SelectedTab.Controls.OfType(Of Form).First, "Deseja salvar as alterações?", "Alteração") Then
                    Exit Sub
                End If
            End If
            Modo = "SALVAR"
            ElseIf e.ClickedItem Is BtnAlterar Then
                Modo = "ALTERAR"
            ElseIf e.ClickedItem Is BtnExcluir Then
                If Uteis.MsgBoxHelper.MsgTemCerteza(Application.OpenForms.OfType(Of Frm_Principal_MDI).First _
                                                    .TCPrincipal.SelectedTab.Controls.OfType(Of Form).First, "Deseja excluir o registro?", "Exclusão") Then
                    Modo = "EXCLUIR"
                Else
                    ToolbarItemsState(ModoAnterior)
                    ModoAnterior = "REVERTER"
                    Exit Sub
                End If
            ElseIf e.ClickedItem Is BtnPesquisar Then
                Modo = "PESQUISAR"
            ElseIf e.ClickedItem Is BtnSeguinte Then
                Modo = "SEGUINTE"
            ElseIf e.ClickedItem Is BtnAnterior Then
                Modo = "ANTERIOR"
            ElseIf e.ClickedItem Is BtnReverter Then
                If Uteis.MsgBoxHelper.MsgTemCerteza(Application.OpenForms.OfType(Of Frm_Principal_MDI).First _
                                                    .TCPrincipal.SelectedTab.Controls.OfType(Of Form).First, "Deseja reverter as mudanças?", "Reverter") Then
                    Modo = "REVERTER"
                    ToolbarItemsState(Modo)
                Else
                    Exit Sub
                End If
            ElseIf e.ClickedItem Is BtnInsereImagem Then
                Modo = "IMAGEM"
            ElseIf e.ClickedItem Is BtnVisualizarRel Then
                Modo = "RELATORIO"
                'ElseIf e.ClickedItem Is BtnEscuro Then
                '    AlternaCores()
            End If
            ToolbarItemsState()
    End Sub


    Public Sub ToolStrip1_ItemClicked(sender As Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked
        ModoSelecionado(sender, e)
        RaiseEvent itemclick()
    End Sub

    Public Sub ToolbarItemsState(Optional ByVal modoAtualParaAnterior As String = "", Optional ByVal haviaItemPesquisado As Boolean = False)

        ' Toolstrip captura o MODO em que a página estava quando perdeu o foco, e retoma o estado dos itens de acordo com o respectivo modo
        If Not String.IsNullOrWhiteSpace(modoAtualParaAnterior) Then
            Modo = modoAtualParaAnterior
            If Modo = "ANTERIOR" Or Modo = "SEGUINTE" Then
                Modo = "PESQUISAR"
                haviaItemPesquisado = Modo = "PESQUISAR"
            End If
        End If

        ' Personaliza estado dos botões de acordo com o botão clicado
        If Modo = "NOVO" Then
            For Each item As ToolStripItem In ToolStrip1.Items
                If item IsNot BtnSalvar AndAlso item IsNot BtnReverter Then
                    item.Enabled = False
                Else
                    item.Enabled = True
                End If
            Next
        ElseIf Modo = "PESQUISAR" Then
            For Each item As ToolStripItem In ToolStrip1.Items
                If item IsNot BtnSeguinte AndAlso item IsNot BtnAnterior _
                    AndAlso item IsNot BtnNovo Then
                    item.Enabled = False
                Else
                    item.Enabled = True
                End If
            Next
            BtnAlterar.Enabled = haviaItemPesquisado
            BtnExcluir.Enabled = haviaItemPesquisado
        ElseIf Modo = "SALVAR" Then
            For Each item As ToolStripItem In ToolStrip1.Items
                If item IsNot BtnNovo AndAlso item IsNot BtnPesquisar Then
                    item.Enabled = False
                Else
                    item.Enabled = True
                End If
            Next
        ElseIf Modo = "ALTERAR" Then
            For Each item As ToolStripItem In ToolStrip1.Items
                If item IsNot BtnSalvar AndAlso item IsNot BtnReverter Then
                    item.Enabled = False
                Else
                    item.Enabled = True
                End If
            Next
        ElseIf Modo = "EXCLUIR" Then
            For Each item As ToolStripItem In ToolStrip1.Items
                If item IsNot BtnNovo AndAlso item IsNot BtnPesquisar Then
                    item.Enabled = False
                Else
                    item.Enabled = True
                End If
            Next
        ElseIf Modo = "REVERTER" Then
            If ModoAnterior = "ALTERAR" Or ModoAnterior = "EXCLUIR" Then
                Modo = "PESQUISAR"
                ModoAnterior = "REVERTER"
                For Each item As ToolStripItem In ToolStrip1.Items
                    If item IsNot BtnNovo AndAlso item IsNot BtnSeguinte AndAlso item IsNot BtnAnterior Then
                        item.Enabled = False
                    Else
                        item.Enabled = True
                    End If
                Next
            ElseIf ModoAnterior = "NOVO" Then
                Modo = "PADRÃO"
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
            If item IsNot BtnNovo AndAlso item IsNot BtnPesquisar Then
                item.Enabled = False
            Else
                item.Enabled = True
            End If
        Next
    End Sub

    Public Sub AfterSuccessfulUpdate()
        For Each item As ToolStripItem In ToolStrip1.Items
            If item IsNot BtnNovo AndAlso item IsNot BtnPesquisar Then
                item.Enabled = False
            Else
                item.Enabled = True
            End If
        Next
    End Sub

    Public Sub AfterSuccessfulDelete()
        For Each item As ToolStripItem In ToolStrip1.Items
            If item IsNot BtnNovo _
                AndAlso item IsNot BtnPesquisar Then
                item.Enabled = False
            Else
                item.Enabled = True
            End If
        Next
        Modo = "PADRÃO"
    End Sub

    Public Sub EstadoAlterarExcluir(ByVal estado As Boolean)
        Me.ToolStrip1.Items("BtnAlterar").Enabled = estado
        Me.ToolStrip1.Items("BtnExcluir").Enabled = estado
    End Sub

    'Private Sub AlternaCores()
    '    If Not IsModoEscuro Then
    '        Dim mainForm = Application.OpenForms.OfType(Of Frm_Principal_MDI).First
    '        For Each c As Control In mainForm.Controls
    '            c.ForeColor = Color.White
    '            c.BackColor = Color.Black
    '        Next
    '        For Each page As TabPage In mainForm.TCPrincipal.TabPages
    '            For Each frm As Form In page.Controls
    '                frm.BackColor = Color.Black
    '                frm.ForeColor = Color.White
    '                Dim ctrls = frm.Controls
    '                For Each ctrl As Control In ctrls
    '                    ctrl.ForeColor = Color.White
    '                    If ctrl.HasChildren Then
    '                        For Each c As Control In ctrl.Controls
    '                            c.ForeColor = Color.White
    '                        Next
    '                    End If
    '                Next
    '            Next
    '        Next
    '        IsModoEscuro = True
    '    Else
    '        Dim mainForm = Application.OpenForms.OfType(Of Frm_Principal_MDI).First
    '        For Each c As Control In mainForm.Controls
    '            c.ForeColor = Color.Black
    '            c.BackColor = Color.LightSteelBlue
    '        Next
    '        For Each page As TabPage In mainForm.TCPrincipal.TabPages
    '            For Each frm As Form In page.Controls
    '                frm.BackColor = Color.Lavender
    '                frm.ForeColor = Color.Black
    '                Dim ctrls = frm.Controls
    '                For Each ctrl As Control In ctrls
    '                    ctrl.ForeColor = Color.Black
    '                    If ctrl.HasChildren Then
    '                        For Each c As Control In ctrl.Controls
    '                            c.ForeColor = Color.Black
    '                        Next
    '                    End If
    '                Next
    '            Next
    '        Next
    '        IsModoEscuro = False
    '    End If
    'End Sub

End Class
