Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports Entidades

Public Class DAO

#Region "ACESSO"

    Public Shared Function AutenticaUsuario(ByVal login As String, ByVal senha As String) As Usuario
        Dim ConnStr As String = ConfigurationManager.AppSettings("ConnStr")

        Using Con As New SqlClient.SqlConnection(ConnStr)
            Using Cmd As New SqlCommand()
                Try
                    Dim U As New Usuario()
                    Cmd.Connection = Con
                    Cmd.CommandText = "SP_AUTENTICA_USUARIO"
                    Cmd.CommandType = CommandType.StoredProcedure
                    Cmd.Parameters.AddWithValue("@LOGIN", login)
                    Cmd.Parameters.AddWithValue("@SENHA", senha)
                    Dim DA As New SqlDataAdapter(Cmd)
                    Dim DT As New DataTable()
                    DA.Fill(DT)

                    If DT.Rows.Count > 0 Then
                        Return U.Carrega(DT.Rows(0))
                    Else
                        Return Nothing
                    End If
                Catch Ex As Exception
                    Throw Ex
                End Try
            End Using
        End Using
    End Function

#End Region

#Region "Sobre"
    Public Shared Sub GetSobreSistema(ByVal Lst As List(Of String))
        Dim ConnStr As String = ConfigurationManager.ConnectionStrings("ConnStr").ConnectionString()
        Using Con As New SqlConnection(ConnStr)
            Using Cmd As New SqlCommand()
                Con.Open()
                Cmd.Connection = Con
                Cmd.CommandText = "SP_SOBRE_SISTEMA"
                Cmd.CommandType = CommandType.StoredProcedure
                Dim Reader = Cmd.ExecuteReader
                Dim I As Integer = 0
                While Reader.Read
                    Lst.Add(Reader.GetString(I))
                    I += 1
                End While
                Reader.Close()
            End Using
        End Using
    End Sub
#End Region

End Class
