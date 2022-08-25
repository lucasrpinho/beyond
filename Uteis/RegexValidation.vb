Imports System.Text.RegularExpressions

Public Class RegexValidation
    Public Shared Function IsOnlyLetter(ByVal Texto As String) As Boolean
        Dim reg As New Regex("^[A-Z]*$")
        Return reg.IsMatch(Texto)
    End Function

    Public Shared Function IsSenhaValida(ByVal senha As String) As Boolean
        Dim reg As New Regex("^(?=.*[A-Z])(?=.*[0-9])(?=.*[a-z]).{5,16}$")
        Return reg.IsMatch(senha)
    End Function
End Class
