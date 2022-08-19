Public Class Pedido

    Private _CodPedido As Integer = 0
    Public ObjCliente As Cliente
    Public ObjProduto As Produto
    Public Destinatario As String
    Public DatVenda As Date
    Private _CEP As String
    Private _Logradouro As String
    Private _NumeroEndereco As Integer = 0
    Private _Bairro As String
    Private _Cidade As String
    Private _Complemento As String
    Public Estado As String
    Public Observacao As String
    Public IsPresente As Boolean

    Public Property CodPedido()
        Get
            Return _CodPedido
        End Get
        Set(value)
            _CodPedido = value
        End Set
    End Property

    'Public Property CodCliente()
    '    Get
    '        Return _CodCliente
    '    End Get
    '    Set(value)
    '        _CodCliente = value
    '    End Set
    'End Property

    'Public Property CodProduto()
    '    Get
    '        Return _CodProduto
    '    End Get
    '    Set(value)
    '        _CodProduto = value
    '    End Set
    'End Property

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

    Public Shared Function IsValid(ByVal p As Pedido, ByRef strError As String) As Boolean
        strError = ""

        If Not p.ObjCliente.IsAtivo Then
            strError = "O cliente selecionado está inativo"
        ElseIf Not p.ObjProduto.IsAtivo Then
            strError = "O produto selecionado está inativo"
        ElseIf p.Logradouro = "" Then
            strError = "Logradouro precisa ser preenchido"
        ElseIf p.Bairro = "" Then
            strError = "Bairro precisa ser preenchido"
        ElseIf p.Cidade = "" Then
            strError = "Cidade precisa ser preenchida"
        ElseIf p.Estado = "" Then
            strError = "Estado precisa ser selecionado"
        ElseIf p.NumeroEndereco = 0 Then
            strError = "Número do endereço não pode ser zero"
        ElseIf p.ObjProduto Is Nothing Then
            strError = "Pedidos sem produtos não podem ser gravados"
        ElseIf p.ObjCliente Is Nothing Then
            strError = "Pedidos sem cliente não podem ser gravados"
        ElseIf p.CEP = "" Then
            strError = "CEP precisa ser preenchido"
        ElseIf p.Destinatario = "" Then
            strError = "Destinatário precisa ser preenchido"
        End If

        Return String.IsNullOrWhiteSpace(strError)

    End Function

End Class
