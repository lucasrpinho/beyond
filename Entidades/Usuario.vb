Imports System.Data

Public Class Usuario
    Private _CodUsuario As Integer = 0
    Public Nome As String
    Public Sobrenome As String
    Private _NomeCompleto As String
    Public Email As String
    Private _Login As String
    Private _Senha As String
    Public IsAtivo As Boolean
    Public DatCriacao As DateTime
    Public LoginCriacao As String


    Public Sub New()
        Me.DatCriacao = DateTime.Now
    End Sub

    Public Property CodUsuario()
        Get
            Return _CodUsuario
        End Get
        Set(value)
            _CodUsuario = value
        End Set
    End Property

    Public Property Login()
        Get
            Return _Login
        End Get
        Set(value)
            _Login = value
        End Set
    End Property

    Public Property Senha()
        Get
            Return _Senha
        End Get
        Set(value)
            _Senha = value
        End Set
    End Property

    Public Property NomeCompleto As String
        Get
            Return _NomeCompleto
        End Get
        Set(value As String)
            _NomeCompleto = value
        End Set
    End Property

    Public Function IsValid(ByRef strError As String) As Boolean
        strError = String.Empty
        If Me.CodUsuario <> 0 Then
            strError = "O código de usuário deve ser 0 pois será gerado automaticamente."
        ElseIf Me.Nome = "" Then
            strError = "Nome precisa ser preenchido."
        ElseIf Me.Sobrenome = "" Then
            strError = "Sobrenome precisa ser preenchido."
        ElseIf Me.Senha = "" Then
            strError = "Senha não pode ser vazia."
        End If
        Return String.IsNullOrWhiteSpace(strError)
    End Function

    Public Sub Carrega(ByVal row As DataRow)
        Me.CodUsuario = row.Field(Of Integer)("cod_usuario")
        Me.Nome = row.Field(Of String)("de_nome")
        Me.Sobrenome = row.Field(Of String)("de_sobrenome")
        Me.NomeCompleto = row.Field(Of String)("de_nome_completo")
        Me.Email = row.Field(Of String)("de_email")
        Me.Login = row.Field(Of String)("de_login")
        ' U.Senha = row.Field(Of String)("de_senha")
        Me.IsAtivo = row.Field(Of Boolean)("ct_ativo")
        Me.DatCriacao = row.Field(Of DateTime)("dat_criacao")
        Me.LoginCriacao = row.Field(Of String)("de_login_criacao")

    End Sub
End Class
