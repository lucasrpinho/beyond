﻿Imports System.Data

Public Class Vendedor

    Private _CodVendedor As Integer = 0
    Private _CodCargo As Int16
    Private _NomeCompleto As String
    Public ObjEndereco As Endereco
    Public Observacao As String
    Public Foto As String
    Public IsAtivo As Boolean
    Public DatCriacao As DateTime

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
        ElseIf Me.NomeCompleto = "" Then
            strError = "Nome precisa estar preenchido."
        ElseIf Me.Foto = "" Then
            strError = "Vendedor precisa ter uma foto no seu cadastro."
        End If

        Me.ObjEndereco.IsEnderecoValid(strError)
        Return String.IsNullOrWhiteSpace(strError)
    End Function

    Public Sub Carrega(row As DataRow)
        Me.CodVendedor = row.Field(Of Integer)("cod_vendedor")
        Me.CodCargo = row.Field(Of Int16)("cod_cargo")
        Me.NomeCompleto = row.Field(Of String)("de_nome_completo")
        'Me.ObjEndereco.CEP = row.Field(Of String)("nu_cep")
        'Me.ObjEndereco.Logradouro = row.Field(Of String)("de_logradouro")
        'Me.ObjEndereco.NumeroEndereco = row.Field(Of Int16)("nu_numero")
        'Me.ObjEndereco.Complemento = row.Field(Of String)("de_complemento")
        'Me.ObjEndereco.Bairro = row.Field(Of String)("de_bairro")
        'Me.ObjEndereco.Cidade = row.Field(Of String)("de_cidade")
        'Me.ObjEndereco.UF = row.Field(Of String)("uf_estado")
        Me.DatCriacao = row.Field(Of DateTime)("dat_criacao")
        Me.Observacao = row.Field(Of String)("de_observacao")
        Me.IsAtivo = row.Field(Of Boolean)("ct_ativo")
        Me.Foto = System.Text.Encoding.UTF8.GetString(row.Field(Of Byte())("fl_foto"))
        Me.ObjEndereco.Carrega(row)
    End Sub
End Class
