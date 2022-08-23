Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports Entidades

Public Class DAO

#Region "ACESSO"

    Public Shared Function AutenticaUsuario(ByVal login As String, ByVal senha As String,
        ByRef resposta As String) As Usuario
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
                    Cmd.Parameters.Add("@RESPONSE", SqlDbType.VarChar).Direction = ParameterDirection.Output
                    Cmd.Parameters("@RESPONSE").Size = 255

                    Dim Adp As New SqlDataAdapter(Cmd)
                    Dim Tbl As New DataTable("Usuario")
                    Adp.Fill(Tbl)

                    resposta = Cmd.Parameters("@RESPONSE").Value
                    If Not Tbl.Rows.Count > 0 Then
                        Return Nothing
                    Else
                        Return U.Carrega(Tbl.Rows(0))
                    End If
                Catch Ex As Exception
                    Throw Ex
                End Try
            End Using
        End Using
    End Function

#End Region

#Region "Sobre"
    Public Shared Sub GetSobreSistema(ByVal Lst As List(Of Object))
        Dim ConnStr = ConfigurationManager.ConnectionStrings("ConnString").ConnectionString
        Using Con As New SqlConnection(ConnStr)
            Using Cmd As New SqlCommand()
                Cmd.Connection = Con
                Cmd.CommandText = "SP_SOBRE_SISTEMA"
                Cmd.CommandType = CommandType.StoredProcedure
                Dim Adp As New SqlDataAdapter(Cmd.CommandText, Con)
                Dim Tbl As New DataTable
                Adp.Fill(Tbl)
                For I As Integer = 0 To 3
                    Lst.Add(Tbl.Rows(0).Field(Of Object)(I))
                Next
            End Using
            Con.Close()
        End Using
    End Sub
#End Region

#Region "Usuário"
    Public Shared Function InsertUsuario(ByVal usuario As Usuario, ByRef response As String) As Boolean
        Dim ConnStr As String = ConfigurationManager.ConnectionStrings("ConnString").ConnectionString
        Using Con As New SqlClient.SqlConnection(ConnStr)
            Using Cmd As New SqlClient.SqlCommand
                Con.Open()
                Cmd.Connection = Con
                Cmd.CommandText = "SP_INSERT_USER"
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.Add("@NOME", SqlDbType.VarChar).Value = usuario.Nome
                Cmd.Parameters.Add("@SOBRENOME", SqlDbType.VarChar).Value = usuario.Sobrenome
                Cmd.Parameters.Add("@NOMECOMPLETO", SqlDbType.VarChar).Value = usuario.NomeCompleto
                Cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = usuario.Email
                Cmd.Parameters.Add("@LOGIN", SqlDbType.VarChar).Value = usuario.Login
                Cmd.Parameters.Add("@SENHA", SqlDbType.VarChar).Value = usuario.Senha
                Cmd.Parameters.Add("@LOGINCRIACAO", SqlDbType.VarChar).Value = usuario.LoginCriacao
                Cmd.Parameters.Add("@RESPONSE", SqlDbType.VarChar).Direction = ParameterDirection.Output
                Cmd.Parameters("@RESPONSE").Size = 255
                Dim tr = Con.BeginTransaction
                Try
                    Cmd.Transaction = tr
                    If Not Cmd.ExecuteNonQuery > 0 Then
                        tr.Rollback()
                    Else
                        tr.Commit()
                        Return True
                    End If
                Catch ex As Exception
                    response = "O cadastro de usuário falhou"
                    tr.Rollback()
#If DEBUG Then
                    response = ex.InnerException.Message + ex.Message + ex.StackTrace
#End If
                End Try
                response = Cmd.Parameters("@RESPONSE").Value
            End Using
            Con.Close()
        End Using
        Return False
    End Function
#End Region

End Class
