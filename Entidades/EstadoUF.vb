Imports System.Data
Public Class EstadoUF

    Public UF As String
    Public Nome As String
    Public NuOrd As Byte

    Public Sub Carrega(ByVal row As DataRow)
        Me.UF = row.Field(Of String)("uf_estado")
        Me.Nome = row.Field(Of String)("de_nome")
        Me.NuOrd = row.Field(Of Byte)("nu_ord")
    End Sub

End Class
