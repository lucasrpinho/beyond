Imports System.Text.RegularExpressions

Public Class RegexValidation
    Public Shared Function IsOnlyLetter(ByVal Texto As String) As Boolean
        Dim reg As New Regex("^[A-Z]*$")
        Return reg.IsMatch(Texto)
    End Function
End Class
