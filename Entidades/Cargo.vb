Public Class Cargo

    Private _CodCargo As Integer = 0
    Public Nome As String
    Public Descricao As String
    Public IsAtivo As Boolean
    Public IsVendedor As Boolean
    Public LoginCriacao As String

    Public Property CodCargo()
        Get
            Return _CodCargo
        End Get
        Set(value)
            _CodCargo = value
        End Set
    End Property

    Public Function IsValid(ByRef strError As String) As Boolean
        strError = ""

        If Me.CodCargo <> 0 Then
            strError = "Código do cargo deve ser zero pois será gerado"
        ElseIf Me.Nome = "" Then
            strError = "Cargo precisa ter um nome"
        ElseIf Me.Descricao = "" Then
            strError = "Descrição do cargo precisa ser preenchida"
        End If

        Return String.IsNullOrWhiteSpace(strError)
    End Function

End Class
