﻿Imports System.Windows.Forms

Public Class MsgBoxHelper
    Public Overloads Shared Function MsgTemCerteza(ByVal Frm As Form) As Boolean
        If MessageBox.Show(Frm, "Tem certeza que deseja fechar a aplicação?", "Beyond",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function MsgTemCertezaAlertaTelasAbertas(ByVal Frm As Form) As Boolean
        If MessageBox.Show(Frm, "Qualquer alteração não salva poderá ser perdida" + vbNewLine +
                vbNewLine + "Tem certeza que deseja sair?", "Beyond",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Sub Alerta(ByVal Msg As String, ByVal Titulo As String)
        MsgBox(Msg, MsgBoxStyle.Exclamation, Titulo)
    End Sub

    Public Shared Sub Erro(Frm As Form, ByVal Msg As String, ByVal Titulo As String)
        MessageBox.Show(Frm, Msg, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public Shared Sub AlertaTransacao(Frm As Form, toolbar As ToolStrip)
        MessageBox.Show(Frm, "Confirme ou cancele a mudança feita", "Operação não confirmada",
                             MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Dim itemCommit = toolbar.Items("BtnCommit")
        Dim tooltip As New ToolTip
        tooltip.IsBalloon = True
        tooltip.ToolTipIcon = ToolTipIcon.Warning
        tooltip.ToolTipTitle = "Confirme"
        tooltip.SetToolTip(toolbar, "Confirme a operação")
        tooltip.Show("Confirme a operação", itemCommit, 2000)
    End Sub

    Public Shared Sub CustomTooltip(frm As Control, window As IWin32Window, msg As String, titulo As String)
        Dim tooltip As New ToolTip
        tooltip.ToolTipTitle = titulo
        tooltip.ToolTipIcon = ToolTipIcon.Error
        tooltip.IsBalloon = True
        tooltip.SetToolTip(frm, msg)
        tooltip.Show(msg, window, 3000)
    End Sub

    Public Overloads Shared Function MsgTemCerteza(ByVal msg As String, ByVal titulo As String) As Boolean
        If MessageBox.Show(Application.OpenForms("Frm_Principal_MDI"), msg, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
