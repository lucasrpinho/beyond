Imports System.Data

Public Class Cargo

    Private _CodCargo As Int16 = 0
    Public Nome As String
    Public Descricao As String
    Public IsAtivo As Boolean
    Public IsVendedor As Boolean
    Public DatCriacao As DateTime
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

    Public Sub Carrega(ByVal row As DataRow)
        Me.CodCargo = row.Field(Of Int16)("cod_cargo")
        Me.Descricao = row.Field(Of String)("de_descricao")
        Me.Nome = row.Field(Of String)("de_nome")
        Me.IsAtivo = row.Field(Of Boolean)("ct_ativo")
        Me.LoginCriacao = row.Field(Of String)("de_login_criacao")
        Me.IsVendedor = row.Field(Of Boolean)("ct_vendedor")
        Me.DatCriacao = row.Field(Of DateTime)("dat_criacao")
    End Sub

End Class
