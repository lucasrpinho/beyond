Public Class Pedido

    Private _CodPedido As String
    Private _CodCliente As Integer
    Private _CodVendedor As Integer
    Public LstProduto As List(Of Produto)
    Public Destinatario As String
    Public ValorTotal As Decimal
    Public DatVenda As Date
    Public ObjEndereco As Endereco
    Public Observacao As String
    Public IsPresente As Boolean
    Public IsClienteDestinatario As Boolean
    Public DatCriacao As DateTime
    Public LoginCriacao As String

    Public Property CodPedido()
        Get
            Return _CodPedido
        End Get
        Set(value)
            _CodPedido = value
        End Set
    End Property

    Public Property CodCliente()
        Get
            Return _CodCliente
        End Get
        Set(value)
            _CodCliente = value
        End Set
    End Property

    Public Property CodVendedor()
        Get
            Return _CodVendedor
        End Get
        Set(value)
            _CodVendedor = value
        End Set
    End Property

    'Public ProPerty CodProduto()
    '    Get
    '        Return _CodProduto
    '    End Get
    '    Set(value)
    '        _CodProduto = value
    '    End Set
    'End ProPerty


    Public Function IsValid(ByRef strError As String) As Boolean
        strError = ""

        If Me.LstProduto.Count = 0 Then
            strError = "O pedido está sem produtos no carrinho."
        ElseIf Not Me.LstProduto.Any(Function(p As Produto) p.IsAtivo = False) Then
            strError = "Produtos inativos não podem ser inseridos no pedido."
        ElseIf Me.CodCliente = 0 Then
            strError = "O pedido está sem um cliente vinculado."
        ElseIf Me.Destinatario = "" Then
            strError = "O pedido está sem um destinatário."
        ElseIf Me.CodVendedor = 0 Then
            strError = "O pedido está sem um vendedor vinculado."
        ElseIf Me.ObjEndereco Is Nothing Then
            strError = "O pedido precisa ter um endereço um preenchido."
        End If

        Return String.IsNullOrWhiteSpace(strError)

    End Function

    Public Sub Carrega(ByVal row As Data.DataRow)
        Me.CodPedido = row.Field(Of String)("cod_pedido")
        Me.CodCliente = row.Field(Of Integer)("cod_cliente")
        Me.CodVendedor = row.Field(Of Integer)("cod_vendedor")
        Me.DatCriacao = row.Field(Of DateTime)("dat_criacao")
        Me.LoginCriacao = row.Field(Of String)("de_login_criacao")
        Me.DatVenda = row.Field(Of DateTime)("dat_venda")
        Me.Destinatario = row.Field(Of String)("de_destinatario")
        Me.IsPresente = row.Field(Of Boolean)("ct_presente")
        Me.ValorTotal = row.Field(Of Decimal)("nu_valor_total")
    End Sub

End Class
