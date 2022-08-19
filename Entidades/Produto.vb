Public Class Produto

    Private _CodProduto As Integer = 0
    Public Categoria As String
    Public Descricao As String
    Public Preco As Decimal
    Public Quantidade As Integer
    Public IsAtivo As Boolean

    Public Property CodProduto()
        Get
            Return _CodProduto
        End Get
        Set(value)
            _CodProduto = value
        End Set
    End Property

    Public Shared Function IsValid(ByVal p As Produto, ByRef strError As String) As Boolean
        strError = ""

        If p.CodProduto <> 0 Then
            strError = "Código do produto deve ser zero pois será gerado automaticamente"
        ElseIf p.Descricao = "" Then
            strError = "A descrição do produto precisa ser preenchida"
        ElseIf Not IsNumeric(p.Preco) Or p.Preco <> 0 Then
            strError = "Preço precisa ser numérico e o valor precisa ser zero durante o registro"
        ElseIf Not IsNumeric(p.Quantidade) Or p.Quantidade <> 0 Then
            strError = "Quantidade precisa ser numérico e o valor precisa ser zero durante o registro"
        ElseIf Not p.IsAtivo Then
            strError = "O produto precisa ser marcado como ativo durante o cadastro"
        End If

        Return String.IsNullOrWhiteSpace(strError)
    End Function
End Class
