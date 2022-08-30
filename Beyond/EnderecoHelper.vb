Imports Entidades
Imports System.Net
Imports Newtonsoft.Json
Imports System.IO


Public Class EnderecoHelper

    Public Shared Function GetEnderecoViaCEP(cep As String) As Endereco.EnderecoJson
        Dim url As String = "https://viacep.com.br/ws/" + Uteis.StringHelper.CEPString(cep) + "/json/"
        Try
            Dim wc As New Net.WebClient
            Dim json As String = ""
            json = wc.DownloadString(url)
            If json.Length > 0 Then
                Return JsonConvert.DeserializeObject(Of Endereco.EnderecoJson)(json)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
