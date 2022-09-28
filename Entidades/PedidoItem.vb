Imports System.Collections.Generic

Public Class PedidoItem

    Public CodPedido As String
    Public CodProduto As Integer
    Public Quantidade As Integer
    Public Preco As Decimal

    Public Function IsValid(ByRef strError As String) As Boolean
        strError = ""

        If Me.CodPedido = String.Empty Then
            strError = "Pedido está vazio."
        ElseIf Me.CodProduto = 0 Then
            strError = "Pedido deve conter um produto."
        ElseIf Quantidade <= 0 Then
            strError = "Quantidade deve ser maior que zero."
        ElseIf Preco <= 0 Then
            strError = "Preço deve ser maior que zero."
        End If
        Return String.IsNullOrWhiteSpace(strError)
    End Function

    Public Sub Carrega(ByVal row As Data.DataRow)
        Me.CodPedido = row.Field(Of String)("cod_pedido")
        Me.CodProduto = row.Field(Of Integer)("cod_produto")
        Me.Quantidade = row.Field(Of Integer)("nu_quantidade")
        Me.Preco = row.Field(Of Decimal)("nu_preco")
    End Sub

End Class
