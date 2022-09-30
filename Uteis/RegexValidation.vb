Imports System.Text.RegularExpressions
Imports System.Net.Mail

Public Class RegexValidation
    Public Shared Function IsOnlyLetter(ByVal Texto As String) As Boolean
        Dim reg As New Regex("^[A-Z]*$")
        Return reg.IsMatch(Texto)
    End Function

    Public Shared Function NumEnderecoCaracteres(ByVal txt As String) As Boolean
        Dim reg As New Regex("^[a-zA-Z0-9////]*$")
        Return reg.IsMatch(txt)
    End Function

    Public Shared Function IsSenhaValida(ByVal senha As String) As Boolean
        Dim reg As New Regex("^(?=.*[A-Z])(?=.*[0-9])(?=.*[a-z]).{5,16}$")
        Return reg.IsMatch(senha)
    End Function

    Public Shared Function IsEmailValid(ByVal email As String) As Boolean
        Try
            Dim emailValido = New MailAddress(email)
            Return Not IsNothing(emailValido)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function IsTelefoneValid(ByVal telefone As String) As Boolean
        Dim Reg As New Regex("^([0-9]{2})([9])([0-9]{4})([0-9]{4})$")
        Return Reg.IsMatch(telefone)
    End Function
End Class
