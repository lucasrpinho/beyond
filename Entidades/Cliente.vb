Imports System.Data

Public Class Cliente

    Private _CodCliente As Integer = 0
    Public Nome As String
    Public CPF As String
    Public Empresa As String
    Public CodCargo As Int16
    Public ObjEndereco As Endereco
    Public Telefone As String
    Public Email As String
    Public Descricao As String
    Public DatCriacao As DateTime
    Public LoginCriacao As String
    Public IsAtivo As Boolean

    Public Property CodCliente()
        Get
            Return _CodCliente
        End Get
        Set(value)
            _CodCliente = value
        End Set
    End Property

    Public Sub New()
        Me.ObjEndereco = New Endereco
    End Sub

    Public Sub New(ByVal obj As Endereco)
        Me.ObjEndereco = obj
    End Sub

    Public Function IsValid(ByRef strError As String) As Boolean
        strError = ""
        If Me.CodCliente <> 0 Then
            strError = "Código do cliente deve ser zero pois será gerado"
        ElseIf Me.ObjEndereco.CEP = "" Then
            strError = "CEP precisa ser preenchido"
        ElseIf Me.ObjEndereco.Logradouro = "" Or Me.ObjEndereco.Bairro = "" Or Me.ObjEndereco.Cidade = "" _
            Or Me.ObjEndereco.UF = "" Or Me.ObjEndereco.NumeroEndereco = 0 Then
            strError = "Informações incompletas no endereço"
        ElseIf Me.Telefone = "" Then
            strError = "Telefone precisa ser preenchido"
        ElseIf Me.Telefone.Length <> 11 Then
            strError = "Telefone precisa conter DDD e 9 dígitos"
        ElseIf Me.CPF <> String.Empty AndAlso Me.CPF.Length <> 11 Then
            strError = "CPF precisa conter 11 dígitos"
        ElseIf Me.LoginCriacao = String.Empty Then
            strError = "O sistema não encontrou o login de quem está inserindo o cliente"
        End If

        Return String.IsNullOrWhiteSpace(strError)
    End Function

    Public Sub Carrega(ByVal row As DataRow)
        Me.CodCliente = row.Field(Of Integer)("cod_cliente")
        Me.CodCargo = row.Field(Of Int16)("cod_cargo")
        Me.Nome = row.Field(Of String)("de_nome_completo")
        Me.CPF = row.Field(Of String)("nu_cpf")
        Me.Empresa = row.Field(Of String)("de_empresa")
        'Me.ObjEndereco.CEP = row.Field(Of String)("nu_cep")
        'Me.ObjEndereco.Logradouro = row.Field(Of String)("de_logradouro")
        'Me.ObjEndereco.Bairro = row.Field(Of String)("de_bairro")
        'Me.ObjEndereco.NumeroEndereco = row.Field(Of Int16)("nu_numero")
        'Me.ObjEndereco.Complemento = row.Field(Of String)("de_complemento")
        'Me.ObjEndereco.UF = row.Field(Of String)("uf_estado")
        Me.Telefone = row.Field(Of String)("nu_telefone")
        Me.Email = row.Field(Of String)("de_email")
        Me.Descricao = row.Field(Of String)("de_observacao")
        Me.IsAtivo = row.Field(Of Boolean)("ct_ativo")
        Me.DatCriacao = row.Field(Of DateTime)("dat_criacao")
        Me.LoginCriacao = row.Field(Of String)("de_login_criacao")

        Me.ObjEndereco.Carrega(row)
    End Sub

End Class
