Imports Entidades
Imports System.Net
Imports Newtonsoft.Json


Public Class EnderecoHelper

    Public Shared Function GetEnderecoViaCEP(cep As String) As Endereco.EnderecoJson
        Dim url As String = "https://viacep.com.br/ws/" + Uteis.StringHelper.NumericOnly(cep) + "/json/"
        Try
            Dim wc As New Net.WebClient
            wc.Encoding = System.Text.Encoding.UTF8
            Dim json As String = ""
            json = wc.DownloadString(url)
            If json.Length > 0 Then
                Dim obj = JsonConvert.DeserializeObject(Of Endereco.EnderecoJson)(json)
                Return obj
            Else
                Return Nothing
            End If
        Catch ex As Exception
#If DEBUG Then
            Throw
#End If
            MessageBox.Show("Ocorreu um erro durante a busca. Verifique o formato do CEP digitado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

End Class
