Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports Entidades

Public Class DAO

    Private Shared Con As SqlConnection
    Private Shared Tr As SqlTransaction

#Region "ACESSO"

    Public Shared Function AutenticaUsuario(ByVal login As String, ByVal senha As String,
        ByRef resposta As String) As Usuario
        Dim ConnStr As String = ConfigurationManager.AppSettings("ConnStr")
        Dim usuario As New Usuario

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
                    Dim Tbl As New DataTable()
                    Adp.Fill(Tbl)

                    resposta = Cmd.Parameters("@RESPONSE").Value
                    If Not Tbl.Rows.Count > 0 Then
                        Return Nothing
                    Else
                        usuario.Carrega(Tbl.Rows(0))
                        Return usuario
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
                For I As Integer = 0 To Tbl.Columns.Count - 1
                    Lst.Add(Tbl.Rows(0).Field(Of Object)(I))
                Next
            End Using
            Con.Close()
        End Using
    End Sub
#End Region

#Region "Usuário"

    Public Shared Function InsertUsuario(usuario As Usuario, ByRef response As String) As Boolean
        Dim ConnStr As String = ConfigurationManager.ConnectionStrings("ConnString").ConnectionString
        Con = New SqlConnection(ConnStr)
        Con.Open()
        Tr = Con.BeginTransaction
        Try
            If _InsertUsuario(Con, usuario, response) Then
                Return True
            Else
                tr.Rollback()
            End If
        Catch ex As Exception
            response = ex.Message
            tr.Rollback()
        End Try
        Return False
    End Function

    Private Shared Function _InsertUsuario(con As SqlConnection, ByVal usuario As Usuario, ByRef response As String) As Boolean
        Dim succ As Boolean
        Using Cmd As New SqlClient.SqlCommand
            Cmd.Connection = con
            Cmd.Transaction = Tr
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
            If Not Cmd.ExecuteNonQuery > 0 Then
                Throw New Exception("A inclusão falhou")
                succ = False
            Else
                succ = True
            End If
            response = Cmd.Parameters("@RESPONSE").Value
        End Using
        Return succ
    End Function


    Public Shared Function GetUsuarios(ativo As Boolean, ByRef response As String) As List(Of Usuario)
        Dim ConnStr As String = ConfigurationManager.ConnectionStrings("ConnString").ConnectionString
        Dim LstUsuario As New List(Of Usuario)

        Using Con As New SqlClient.SqlConnection(ConnStr)
            Using Cmd As New SqlClient.SqlCommand
                Cmd.Connection = Con
                Cmd.CommandText = "SP_GET_ALL_USERS"
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.Add("@ATIVO", SqlDbType.Bit).Value = ativo
                Cmd.Parameters.Add("@RESPONSE", SqlDbType.VarChar).Direction = ParameterDirection.Output
                Cmd.Parameters("@RESPONSE").Size = 255
                Try
                    Dim Adp As New SqlDataAdapter(Cmd)
                    Dim Tbl As New DataTable()
                    Adp.SelectCommand = Cmd
                    Adp.Fill(Tbl)
                    If Tbl.Rows.Count > 0 Then
                        For I As Integer = 0 To Tbl.Rows.Count - 1
                            Dim usuario As New Usuario
                            usuario.Carrega(Tbl.Rows(I))
                            LstUsuario.Add(usuario)
                        Next
                    End If

                    If Not Adp Is Nothing Then
                        Adp.Dispose()
                    End If
                    If Not Tbl Is Nothing Then
                        Tbl.Dispose()
                    End If
                Catch ex As Exception
                    response = "A busca falhou"
#If DEBUG Then
                    response = ex.InnerException.Message + ex.Message + ex.StackTrace
#End If
                End Try
                response = Cmd.Parameters("@RESPONSE").Value
            End Using
            Con.Close()
        End Using
        Return LstUsuario
    End Function

    Public Shared Function GetUsuario(ByVal codusuario As String, ByRef resposta As String) As Usuario
        Con = New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
        Using Cmd As New SqlCommand()
            Cmd.Connection = Con
            Cmd.Parameters.Add("@CODUSUARIO", SqlDbType.Int).Value = Convert.ToInt32(codusuario)
            Cmd.Parameters.Add("@RESPONSE", SqlDbType.VarChar).Direction = ParameterDirection.Output
            Cmd.CommandText = "SP_GET_USUARIO"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters("@RESPONSE").Size = 255
            Dim Adp As New SqlDataAdapter(Cmd)
            Try
                Dim Tbl As New DataTable()

                Adp.Fill(Tbl)
                resposta = Cmd.Parameters("@RESPONSE").Value
                If Tbl.Rows.Count > 0 Then
                    Dim usuario As New Usuario
                    usuario.Carrega(Tbl.Rows(0))
                    Return usuario
                Else
                    Return Nothing
                End If
            Catch Ex As Exception
                resposta = Ex.Message
            Finally
                Con.Close()
                Con.Dispose()
                If Not Adp Is Nothing Then
                    Adp.Dispose()
                End If
            End Try
        End Using
        ' Nunca alcançado
        Return Nothing
    End Function

    Public Shared Function DeleteUsuario(codusuario As String, ByRef response As String) As Boolean
        Dim ConnStr As String = ConfigurationManager.ConnectionStrings("ConnString").ConnectionString
        Con = New SqlConnection(ConnStr)
        Con.Open()
        Tr = Con.BeginTransaction
        Try
            If _DeleteUsuario(codusuario, response) Then
                Return True
            Else
                Tr.Rollback()
            End If
        Catch ex As Exception
            response = ex.Message
            Tr.Rollback()
        End Try
        Return False
    End Function

    Public Shared Function _DeleteUsuario(codusuario As String, ByRef resposta As String) As Boolean
        Dim succ As Boolean
        Using Cmd As New SqlCommand()
            Cmd.Connection = Con
            Cmd.Transaction = Tr
            Cmd.CommandText = "SP_INATIVA_USUARIO"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.Add("@CODUSUARIO", SqlDbType.Int).Value = Convert.ToInt32(codusuario)
            Cmd.Parameters.Add("@RESPONSE", SqlDbType.VarChar).Direction = ParameterDirection.Output
            Cmd.Parameters("@RESPONSE").Size = 255

            If Not Cmd.ExecuteNonQuery > 0 Then
                resposta = Cmd.Parameters("@RESPONSE").Value
                Throw New Exception(resposta)
                succ = False
            Else
                resposta = Cmd.Parameters("@RESPONSE").Value
                succ = True
            End If
            resposta = Cmd.Parameters("@RESPONSE").Value
        End Using
        Return succ
    End Function

#End Region

#Region "Cargo"

    Public Shared Function InsereCargo(cargo As Cargo, ByRef resposta As String) As Boolean
        Con = New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
        Con.Open()
        Tr = Con.BeginTransaction
        Try
            If _InsereCargo(cargo, resposta) Then
                Return True
            Else
                Tr.Rollback()
            End If
        Catch ex As Exception
            resposta = ex.Message
            Tr.Rollback()
        End Try
        Return False
    End Function

    Private Shared Function _InsereCargo(cargo As Cargo, ByRef resposta As String) As Boolean
        Dim succ As Boolean
        Using Cmd As New SqlCommand()
            Cmd.Connection = Con
            Cmd.Transaction = Tr
            Cmd.CommandText = "SP_INSERE_CARGO"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.Add("@NOME", SqlDbType.VarChar).Value = cargo.Nome
            Cmd.Parameters.Add("@DESC", SqlDbType.VarChar).Value = cargo.Descricao
            Cmd.Parameters.Add("@ATIVO", SqlDbType.Bit).Value = cargo.IsAtivo
            Cmd.Parameters.Add("@VENDEDOR", SqlDbType.Bit).Value = cargo.IsVendedor
            Cmd.Parameters.Add("@LOGINCRIACAO", SqlDbType.VarChar).Value = cargo.LoginCriacao
            Cmd.Parameters.Add("@RESPONSE", SqlDbType.VarChar).Direction = ParameterDirection.Output
            Cmd.Parameters("@RESPONSE").Size = 255

            If Not Cmd.ExecuteNonQuery > 0 Then
                succ = False
            Else
                succ = True
            End If
            resposta = Cmd.Parameters("@RESPONSE").Value
        End Using
        Return succ
    End Function

    Public Shared Function AtualizaCargo(cargo As Cargo, ByRef resposta As String) As Boolean
        Con = New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
        Con.Open()
        Tr = Con.BeginTransaction
        Try
            If Not _AtualizaCargo(cargo) Then
                Tr.Rollback()
            Else
                Return True
            End If
        Catch ex As Exception
            resposta = ex.Message
            Tr.Rollback()
        End Try
        Return False
    End Function

    Private Shared Function _AtualizaCargo(cargo As Cargo) As Boolean
        Using Cmd As New SqlCommand
            Cmd.Connection = Con
            Cmd.Transaction = Tr
            Cmd.CommandText = "SP_UPDATE_CARGO"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@CODCARGO", cargo.CodCargo)
            Cmd.Parameters.AddWithValue("@DESC", cargo.Descricao)
            Cmd.Parameters.AddWithValue("@ATIVO", cargo.IsAtivo)
            Cmd.Parameters.AddWithValue("@VENDEDOR", cargo.IsVendedor)

            If Not Cmd.ExecuteNonQuery > 0 Then
                Return False
            Else
                Return True
            End If
        End Using
    End Function

#End Region

#Region "Transaction"
    Public Shared Sub ConfirmarOuReverter(ByVal cmdTransaction As Boolean)
        If cmdTransaction Then
            Tr.Commit()
        Else
            Tr.Rollback()
        End If
        If Not Con Is Nothing Then
            Con.Close()
            Con.Dispose()
        End If
        If Not Tr Is Nothing Then
            Tr.Dispose()
        End If
    End Sub
#End Region

End Class
