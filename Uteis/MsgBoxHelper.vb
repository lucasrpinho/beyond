Imports System.Windows.Forms

Public Class MsgBoxHelper

    'Tem certeza Fechar Aplicação Msg
    Public Overloads Shared Function MsgTemCerteza(ByVal Frm As Form) As Boolean
        If MessageBox.Show(Frm, "Tem certeza que deseja fechar a aplicação?", "Beyond",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Return True
        Else
            Return False
        End If
    End Function


    'Ainda existe telas abertas Alerta
    Public Shared Function MsgTemCertezaAlertaTelasAbertas(ByVal Frm As Form) As Boolean
        If MessageBox.Show(Frm, "Qualquer alteração não salva será perdida." + vbNewLine +
                vbNewLine + "Tem certeza que deseja sair?", "Beyond",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Return True
        Else
            Return False
        End If
    End Function


    ' Alerta Msg
    Public Shared Sub Alerta(ByVal frm As Form, ByVal Msg As String, ByVal Titulo As String)
        MessageBox.Show(frm, Msg, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub


    ' Error Msg
    Public Shared Sub Erro(Frm As Form, ByVal Msg As String, ByVal Titulo As String)
        MessageBox.Show(Frm, Msg, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub


    ' Transação ainda aberta
    Public Shared Sub AlertaTransacao(Frm As Form, toolbar As ToolStrip)
        MessageBox.Show(Frm, "Confirme ou cancele a mudança feita.", "Operação não confirmada",
                             MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Dim itemCommit = toolbar.Items("BtnCommit")
        Dim tooltip As New ToolTip
        tooltip.IsBalloon = True
        tooltip.ToolTipIcon = ToolTipIcon.Warning
        tooltip.ToolTipTitle = "Confirme"
        tooltip.SetToolTip(toolbar, "Confirme a operação.")
        tooltip.Show("Confirme a operação", itemCommit, 2000)
    End Sub


    ' Msg de erro em balão (Tooltip)
    Public Shared Sub CustomTooltip(control As Control, window As IWin32Window, msg As String, titulo As String)
        Dim tooltip As New ToolTip
        tooltip.ToolTipTitle = titulo
        tooltip.ToolTipIcon = ToolTipIcon.Warning
        tooltip.IsBalloon = True
        tooltip.SetToolTip(window, msg)
        tooltip.Show(msg, window, 3000)
    End Sub


    ' Tem certeza Deseja prosseguir Msg
    Public Overloads Shared Function MsgTemCerteza(ByVal frm As Form, ByVal msg As String, ByVal titulo As String) As Boolean
        If MessageBox.Show(frm, msg, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Return True
        Else
            Return False
        End If
    End Function

    ' Sucesso
    Public Shared Sub Msg(ByVal frm As Form, msg As String, titulo As String)
        MessageBox.Show(frm, msg, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
