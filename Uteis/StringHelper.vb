Public Class StringHelper
    ' Classe helper de string contendo métodos que serão utilizados repetidas vezes 
    ' ao longo do desenvolvimento

    Public Shared Function IsNull(ByVal str As String) As Boolean
        Return String.IsNullOrWhiteSpace(str)
    End Function

    Public Shared Function MaxLength(ByVal Txt As String, ByVal Max As Integer) As Boolean
        If Txt.Length > Max Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Shared Function MinLength(ByVal Txt As String, ByVal Min As Integer) As Boolean
        If Txt.Length < Min Then
            Return False
        Else
            Return True
        End If
    End Function
End Class
