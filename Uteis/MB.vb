Public Class MB
    Public Shared Function MsgTemCerteza() As Boolean
        Return MsgBox("Tem certeza que deseja fechar?", MsgBoxStyle.YesNo, "BEYOND")
    End Function

    Public Shared Sub Alerta(ByVal Msg As String, ByVal Titulo As String)
        MsgBox(Msg, MsgBoxStyle.Exclamation, Titulo)
    End Sub
End Class
