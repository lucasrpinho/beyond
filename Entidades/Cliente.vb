Public Class Cliente

    Private _CodCliente As Integer = 0
    Public Nome As String
    Public Sobrenome As String
    Public NomeCompleto As String
    Public Empresa As String
    Public Cargo As String
    Private _CEP As String
    Private _Logradouro As String
    Private _NumeroEndereco As Integer = 0
    Private _Complemento As String
    Private _Bairro As String
    Private _Cidade As String
    Public Estado As String
    Public Telefone As String
    Public Email As String
    Public IsAtivo As Boolean

    Public Property CodCliente()
        Get
            Return _CodCliente
        End Get
        Set(value)
            _CodCliente = value
        End Set
    End Property

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

    Public Property NumeroEndereco()
        Get
            Return _NumeroEndereco
        End Get
        Set(value)
            _NumeroEndereco = value
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

    Public Shared Function IsValid(ByVal c As Cliente, ByRef strError As String) As Boolean
        strError = ""
        If c.CodCliente <> 0 Then
            strError = "Código do cliente deve ser zero pois será gerado"
        ElseIf c.CEP = "" Then
            strError = "CEP precisa ser preenchido"
        ElseIf c.Logradouro = "" Or c.Bairro = "" Or c.Cidade = "" Or c.Estado = "" Or
            c.NumeroEndereco = 0 Then
            strError = "Informações incompletas no endereço"
        ElseIf c.Telefone = "" Then
            strError = "Telefone precisa ser preenchido"
        ElseIf Not c.IsAtivo Then
            strError = "Precisa ser marcado como ativo para cadastrar o cliente"
        End If

        Return String.IsNullOrWhiteSpace(strError)
    End Function

End Class
