Imports System.Text.RegularExpressions

Public Class RegexValidation
    Public Shared Function IsAlfaNumerico(ByVal Texto As String) As Boolean
        Dim reg As New Regex("^[A-Z0-9]*$")
        Return reg.IsMatch(Texto)
    End Function
End Class
