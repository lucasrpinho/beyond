Public Class Vendedor

    Private _CodVendedor As Integer = 0
    Private _CodCargo As Integer
    Public Nome As String
    Public Sobrenome As String
    Public NomeCompleto As String
    Private _CEP As String
    Private _Logradouro As String
    Private _NumeroEndereco As Integer = 0
    Private _Bairro As String
    Private _Cidade As String
    Private _Complemento As String
    Public Estado As String
    Public Observacao As String
    Public Foto As String
    Public IsAtivo As Boolean
    Public DatCriacao As DateTime
    Public LoginCriacao As String

    Public Property CodVendedor()
        Get
            Return _CodVendedor
        End Get
        Set(value)
            _CodVendedor = value
        End Set
    End Property

    Public Property CodCargo()
        Get
            Return _CodCargo
        End Get
        Set(value)
            _CodCargo = value
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

    Public Shared Function IsValid(ByVal v As Vendedor, ByRef strError As String)
        strError = String.Empty

        If v.CodVendedor <> 0 Then
            strError = "Código do vendedor deve ser vazio pois será gerado"
        ElseIf v.CodCargo <= 0 Then
            strError = "Código do cargo deve ser um valor acima de zero"
        ElseIf v.Nome = "" Then
            strError = "Nome precisa estar preenchido"
        ElseIf v.Sobrenome = "" Then
            strError = "Sobrenome precisa estar preenchido"
        ElseIf v.CEP = "" Or v.CEP.ToString.Length > 8 Then
            strError = "CEP não pode ser vazio e deve conter no máximo 8 caracteres"
        ElseIf v.Bairro = "" Then
            strError = "Bairro precisa ser preenchido"
        ElseIf v.Cidade = "" Then
            strError = "Cidade precisa ser preenchida"
        ElseIf v.Estado = "" Or v.Estado.Length > 2 Then
            strError = "Estado precisa ser preenchido e deve conter no máximo dois caracteres (UF)"
        ElseIf v.Logradouro = "" Then
            strError = "Logradouro precisa ser preenchido"
        ElseIf v.NumeroEndereco = 0 Then
            strError = "Número do endereço precisa ser preenchido"
        ElseIf v.Foto = "" Then
            strError = "Vendedor precisa ter uma foto no seu cadastro"
        End If
        Return String.IsNullOrWhiteSpace(strError)
    End Function
End Class
