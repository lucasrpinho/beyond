Imports System.Data

Public Class Vendedor

    Private _CodVendedor As Integer = 0
    Private _CodCargo As Int16
    Private _Nome As String
    Public Sobrenome As String
    Private _NomeCompleto As String
    Public ObjEndereco As Endereco
    Public Observacao As String
    Public Foto As String
    Public IsAtivo As Boolean
    Public DatCriacao As DateTime
    Public LoginCriacao As String

    Public Property CodVendedor()
        Get
            Return _CodVendedor
        End Get
        Set(value)
            _CodVendedor = value
        End Set
    End Property

    Public Property CodCargo()
        Get
            Return _CodCargo
        End Get
        Set(value)
            _CodCargo = value
        End Set
    End Property

    Public Property Nome As String
        Get
            Return _Nome
        End Get
        Set(value As String)
            _Nome = value
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

    Public Sub New()
        Me.ObjEndereco = New Endereco
    End Sub

    Public Function IsValid(ByRef strError As String)
        strError = String.Empty

        If Me.CodVendedor <> 0 Then
            strError = "Código do vendedor deve ser vazio pois será gerado."
        ElseIf Me.CodCargo <= 0 Then
            strError = "Cargo precisa ser preenchido."
        ElseIf Me.Nome = "" Then
            strError = "Nome precisa estar preenchido."
        ElseIf Me.Sobrenome = "" Then
            strError = "Sobrenome precisa estar preenchido."
        ElseIf Me.ObjEndereco.CEP = "" Or Me.ObjEndereco.CEP.ToString.Length <> 8 Then
            strError = "CEP está inválido."
        ElseIf Me.ObjEndereco.Bairro = "" Then
            strError = "Bairro precisa ser preenchido."
        ElseIf Me.ObjEndereco.Cidade = "" Then
            strError = "Cidade precisa ser preenchida."
        ElseIf Me.ObjEndereco.UF = "" Or Me.ObjEndereco.UF.ToString.Length > 2 Then
            strError = "Estado precisa ser preenchido e deve conter no máximo dois caracteres (UF)."
        ElseIf Me.ObjEndereco.Logradouro = "" Then
            strError = "Logradouro precisa ser preenchido."
        ElseIf Me.ObjEndereco.NumeroEndereco = 0 Then
            strError = "Número do endereço precisa ser preenchido."
        ElseIf Me.Foto = "" Then
            strError = "Vendedor precisa ter uma foto no seu cadastro."
        End If
        Return String.IsNullOrWhiteSpace(strError)
    End Function

    Public Sub Carrega(row As DataRow)
        Me.CodVendedor = row.Field(Of Integer)("cod_vendedor")
        Me.CodCargo = row.Field(Of Int16)("cod_cargo")
        Me.Nome = row.Field(Of String)("de_nome")
        Me.Sobrenome = row.Field(Of String)("de_sobrenome")
        Me.NomeCompleto = row.Field(Of String)("de_nome_completo")
        'Me.ObjEndereco.CEP = row.Field(Of String)("nu_cep")
        'Me.ObjEndereco.Logradouro = row.Field(Of String)("de_logradouro")
        'Me.ObjEndereco.NumeroEndereco = row.Field(Of Int16)("nu_numero")
        'Me.ObjEndereco.Complemento = row.Field(Of String)("de_complemento")
        'Me.ObjEndereco.Bairro = row.Field(Of String)("de_bairro")
        'Me.ObjEndereco.Cidade = row.Field(Of String)("de_cidade")
        'Me.ObjEndereco.UF = row.Field(Of String)("uf_estado")
        Me.DatCriacao = row.Field(Of DateTime)("dat_criacao")
        Me.LoginCriacao = row.Field(Of String)("de_login_criacao")
        Me.Observacao = row.Field(Of String)("de_observacao")
        Me.IsAtivo = row.Field(Of Boolean)("ct_ativo")
        Me.Foto = System.Text.Encoding.UTF8.GetString(row.Field(Of Byte())("fl_foto"))
        Me.ObjEndereco.Carrega(row)
    End Sub
End Class
