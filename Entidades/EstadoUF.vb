Imports System.Data
Public Class EstadoUF

    Private _UF As String
    Private _Nome As String
    Public NuOrd As Byte

    Public Property UF As String
        Get
            Return _UF
        End Get
        Set(value As String)
            _UF = value
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

    Public Sub Carrega(ByVal row As DataRow)
        Me.UF = row.Field(Of String)("uf_estado")
        Me.Nome = row.Field(Of String)("de_nome")
        Me.NuOrd = row.Field(Of Byte)("nu_ord")
    End Sub

End Class
