Imports Entidades
Public Class Endereco
    Private _CEP As String
    Private _Numero As String
    Private _Bairro As String
    Private _Cidade As String
    Private _UF As String
    Private _Logradouro As String
    Private _Complemento As String
    Public ObjEnderecoJson As EnderecoJson

    Public Class EnderecoJson
        Public logradouro As String
        Public bairro As String
        Public localidade As String
        Public uf As String
    End Class

    Public Property CEP()
        Get
            Return _CEP
        End Get
        Set(value)
            _CEP = value
        End Set
    End Property

    Public Property Logradouro()
        Get
            Return _Logradouro
        End Get
        Set(value)
            _Logradouro = value
        End Set
    End Property

    Public Property NumeroEndereco() As String
        Get
            Return _Numero
        End Get
        Set(value As String)
            _Numero = value
        End Set
    End Property

    Public Property Bairro()
        Get
            Return _Bairro
        End Get
        Set(value)
            _Bairro = value
        End Set
    End Property

    Public Property Cidade()
        Get
            Return _Cidade
        End Get
        Set(value)
            _Cidade = value
        End Set
    End Property

    Public Property Complemento()
        Get
            Return _Complemento
        End Get
        Set(value)
            _Complemento = value
        End Set
    End Property

    Public Property UF()
        Get
            Return _UF
        End Get
        Set(value)
            _UF = value
        End Set
    End Property

    Public Sub New(ByVal objFromJson As EnderecoJson)
        If objFromJson IsNot Nothing Then
            If Not String.IsNullOrWhiteSpace(objFromJson.logradouro) Then
                Me.ObjEnderecoJson = objFromJson
                Me.Cidade = ObjEnderecoJson.localidade
                Me.Bairro = ObjEnderecoJson.bairro
                Me.UF = ObjEnderecoJson.uf
                Me.Logradouro = ObjEnderecoJson.logradouro
            End If
        End If
    End Sub

    Public Sub New()

    End Sub

    Public Function IsEnderecoValid(ByRef str As String) As Boolean
        If CEP.ToString.Length <> 8 Then
            str = "CEP inválido."
        ElseIf Logradouro.ToString = String.Empty Then
            str = "Logradouro não pode ser vazio."
        ElseIf Bairro.ToString = String.Empty Then
            str = "Bairro não pode ser vazio."
        ElseIf UF.ToString.Length <> 2 Then
            str = "Estado não pode ser vazio."
        ElseIf NumeroEndereco = String.Empty Then
            str = "Número não pode ser vazio."
        ElseIf Cidade.ToString = String.Empty Then
            str = "Cidade não pode ser vazia."
        End If

        Return String.IsNullOrWhiteSpace(str)
    End Function

    Public Sub Carrega(row As Data.DataRow)
        Me.UF = row.Field(Of String)("uf_estado")
        Me.Bairro = row.Field(Of String)("de_bairro")
        Me.Cidade = row.Field(Of String)("de_cidade")
        Me.NumeroEndereco = row.Field(Of String)("nu_numero")
        Me.CEP = row.Field(Of String)("nu_cep")
        Me.Complemento = row.Field(Of String)("de_complemento")
        Me.Logradouro = row.Field(Of String)("de_logradouro")
    End Sub
End Class
