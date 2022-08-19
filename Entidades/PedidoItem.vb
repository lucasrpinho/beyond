Imports System.Collections.Generic

Public Class PedidoItem

    Public ObjPedido As Pedido
    Public LstProduto As List(Of Produto)
    Public Quantidade As Integer

    Public Shared Function IsValid(ByVal pi As PedidoItem, ByRef strError As String) As Boolean
        strError = ""
        Dim hasDuplicates As Boolean
        hasDuplicates = pi.LstProduto.Count <>
            (From p In pi.LstProduto
            Select p.CodProduto
            Distinct).Count
        If pi.ObjPedido Is Nothing Then
            strError = "Pedido não pode ser vazio"
        ElseIf Not pi.LstProduto.Count > 0 Then
            strError = "Pedido deve conter um produto ou mais"
        ElseIf hasDuplicates Then
            strError = "Um pedido não pode conter mais de um mesmo produto"
        End If
        Return String.IsNullOrWhiteSpace(strError)
    End Function

End Class
