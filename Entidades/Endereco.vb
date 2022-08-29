﻿Public Class Endereco
    Private _CEP As String
    Private _Numero As Int16
    Private _Bairro As String
    Private _Cidade As String
    Private _UF As String
    Private _Logradouro As String
    Private _Complemento As String
    Public ObjEnderecoJson As EnderecoJson

    Public Property CEP()
        Get
            Return _CEP
        End Get
        Set(value)
            _CEP = value
        End Set
    End Property

    Public Property Logradouro()
        Get
            Return _Logradouro
        End Get
        Set(value)
            _Logradouro = value
        End Set
    End Property

    Public Property NumeroEndereco()
        Get
            Return _Numero
        End Get
        Set(value)
            _Numero = value
        End Set
    End Property

    Public Property Bairro()
        Get
            Return _Bairro
        End Get
        Set(value)
            _Bairro = value
        End Set
    End Property

    Public Property Cidade()
        Get
            Return _Cidade
        End Get
        Set(value)
            _Cidade = value
        End Set
    End Property

    Public Property Complemento()
        Get
            Return _Complemento
        End Get
        Set(value)
            _Complemento = value
        End Set
    End Property

    Public Property UF()
        Get
            Return _UF
        End Get
        Set(value)
            _UF = value
        End Set
    End Property

End Class
