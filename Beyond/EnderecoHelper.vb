Imports Entidades
Imports System.Net
Imports System.Runtime.Serialization
Imports System.IO


Public Class EnderecoHelper

    Public Shared Function GetEnderecoViaCEP(cep As String) As EnderecoJson
        Dim req As WebRequest
        Dim response As WebResponse = Nothing
        Dim endereco As EnderecoJson
        Try
            req = HttpWebRequest.Create("https://viacep.com.br/ws/" + Uteis.StringHelper.CEPString(cep) + "/json/")
            response = req.GetResponse
            Dim stream = response.GetResponseStream
            Dim reader As New StreamReader(stream)
            Dim json = reader.ReadToEnd

            endereco = Desserializar(json)

        Catch ex As Exception
            Throw ex
        End Try
        Return endereco
    End Function

    Private Shared Function Desserializar(json As String) As EnderecoJson
        Using Stream = New MemoryStream(System.Text.Encoding.UTF8.GetBytes(json))
            Dim endereco As New EnderecoJson
            Dim ser As New DataContractSerializer(endereco.GetType)
            endereco = ser.ReadObject(Stream)
            Return endereco
        End Using
    End Function

End Class
