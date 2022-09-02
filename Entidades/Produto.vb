Imports System.Data

Public Class Produto

    Private _CodProduto As Integer = 0
    Public Categoria As String
    Public Descricao As String
    Public Preco As Decimal
    Public Quantidade As Integer
    Public Imagem As String
    Public IsAtivo As Boolean
    Public DatCriacao As DateTime
    Public LoginCriacao As String

    Public Property CodProduto()
        Get
            Return _CodProduto
        End Get
        Set(value)
            _CodProduto = value
        End Set
    End Property

    Public Function IsValid(ByRef strError As String) As Boolean
        strError = ""

        If Me.CodProduto <> 0 Then
            strError = "Código do produto deve ser zero pois será gerado automaticamente"
        ElseIf Me.Descricao = "" Then
            strError = "A descrição do produto precisa ser preenchida"
        ElseIf Not IsNumeric(Me.Preco) Or Me.Preco <> 0 Then
            strError = "Preço precisa ser numérico e o valor precisa ser zero durante o registro"
        ElseIf Not IsNumeric(Me.Quantidade) Or Me.Quantidade <> 0 Then
            strError = "Quantidade precisa ser numérico e o valor precisa ser zero durante o registro"
        End If

        Return String.IsNullOrWhiteSpace(strError)
    End Function

    Public Sub Carrega(ByVal row As DataRow)
        Me.CodProduto = row.Field(Of Integer)("cod_produto")
        Me.Categoria = row.Field(Of String)("de_categoria")
        Me.Descricao = row.Field(Of String)("de_descricao")
        Me.Preco = row.Field(Of Decimal)("nu_preco")
        Me.Quantidade = row.Field(Of Integer)("nu_quantidade")
        Me.Imagem = System.Text.Encoding.UTF8.GetString(row.Field(Of Byte())("fl_imagem"))
        Me.IsAtivo = row.Field(Of Boolean)("ct_ativo")
        Me.DatCriacao = row.Field(Of DateTime)("dat_criacao")
        Me.LoginCriacao = row.Field(Of String)("de_login_criacao")
    End Sub
End Class
