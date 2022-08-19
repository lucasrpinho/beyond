Public Class Cargo

    Private _CodCargo As Integer = 0
    Public Descricao As String
    Public IsAtivo As Boolean
    Public LoginCriacao As String

    Public Property CodCargo()
        Get
            Return _CodCargo
        End Get
        Set(value)
            _CodCargo = value
        End Set
    End Property

    Public Shared Function IsValid(ByVal c As Cargo, ByRef strError As String) As Boolean
        strError = ""

        If c.CodCargo <> 0 Then
            strError = "Código do cargo deve ser zero pois será gerado"
        ElseIf c.Descricao = "" Then
            strError = "Descrição do cargo precisa ser preenchida"
        End If

        Return String.IsNullOrWhiteSpace(strError)
    End Function

End Class
