Imports Entidades
Imports System.Net
Imports Newtonsoft.Json


Public Class EnderecoHelper

    Public Shared Function GetEnderecoViaCEP(cep As String) As Endereco.EnderecoJson
        Dim url As String = "https://viacep.com.br/ws/" + Uteis.StringHelper.NumericOnly(cep) + "/json/"
        Try
            Dim wc As New Net.WebClient
            Dim json As String = ""
            json = wc.DownloadString(url)
            If json.Length > 0 Then
                Dim obj = JsonConvert.DeserializeObject(Of Endereco.EnderecoJson)(json)
                Return obj
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
