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

    Public Shared Function NumericOnly(txt As String) As String
        Dim txtvalido As String = ""
        If txt.Length > 0 Then
            For I As Integer = 0 To txt.Length - 1
                If IsNumeric(txt(I)) Then
                    txtvalido += txt(I)
                End If
            Next
        End If
        Return txtvalido
    End Function

    Public Shared Function PrecoFormatted(txt As String) As String
        Dim dinheiroFormato As String = ""
        If txt.Length > 0 Then
            For i As Integer = 0 To txt.Length - 1
                If Char.IsPunctuation(txt(i)) Or Char.IsDigit(txt(i)) Or txt(i) = "," Or txt(i) = "." Then
                    dinheiroFormato += txt(i)
                End If
            Next
        End If
        Return dinheiroFormato
    End Function

    Public Shared Function CurrencyType(txt As String) As String
        Dim txtdinheiro As String = ""
        If txt.Length > 0 Then
            For I As Integer = 0 To txt.Length - 1
                If IsNumeric(txt(I)) Or txt(I) = "." Or txt(I) = "," Then
                    txtdinheiro += txt(I)
                End If
            Next
        End If
        Return txtdinheiro
    End Function

    ' REFERÊNCIA: www.macoratti.net/11/09/c_val1.htm
    Public Shared Function IsCpf(ByVal cpf As String) As Boolean
        Dim multiplicador1 = New Integer() {10, 9, 8, 7, 6, 5, 4, 3, 2}
        Dim multiplicador2 = New Integer() {11, 10, 9, 8, 7, 6, 5, 4, 3, 2}
        Dim tempCpf As String
        Dim digito As String

        Dim soma As Integer
        Dim resto As Integer
        cpf = cpf.Trim()
        cpf = cpf.Replace(".", "").Replace("-", "")
        If (cpf.Length <> 11) Then
            Return False
        End If

        tempCpf = cpf.Substring(0, 9)
        soma = 0

        For i As Integer = 0 To 8
            soma += Convert.ToInt32(tempCpf(i).ToString()) * multiplicador1(i)
        Next

        resto = soma Mod 11
        If (resto < 2) Then
            resto = 0
        Else
            resto = 11 - resto
        End If

        digito = resto.ToString()
        tempCpf = tempCpf + digito
        soma = 0
        For i As Integer = 0 To 9
            soma += Convert.ToInt32(tempCpf(i).ToString()) * multiplicador2(i)
        Next

        resto = soma Mod 11
        If (resto < 2) Then
            resto = 0
        Else
            resto = 11 - resto
        End If

        digito = digito + resto.ToString()
        Return cpf.EndsWith(digito)
    End Function

End Class
