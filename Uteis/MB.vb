Imports System.Windows.Forms

Public Class MB
    Public Shared Function MsgTemCerteza(ByVal Frm As Form) As Boolean
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
End Class
