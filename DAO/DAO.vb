Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports Entidades

Public Class DAO

    Private Con As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
    Private Tr As SqlTransaction

#Region "ACESSO"

    Public Shared Function AutenticaUsuario(ByVal login As String, ByVal senha As String,
        ByRef resposta As String) As Usuario
        Dim ConnStr As String = ConfigurationManager.AppSettings("ConnStr")
        Dim usuario As New Usuario

        Using Connection As New SqlClient.SqlConnection(ConnStr)
            Using Cmd As New SqlCommand()
                Try
                    Dim U As New Usuario()
                    Cmd.Connection = Connection
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

    Public Function InsertUsuario(usuario As Usuario, ByRef response As String) As Boolean

        Con.Open()
        Tr = Con.BeginTransaction
        Try
            If _InsertUsuario(Con, usuario, response) Then
                Tr.Commit()
                Return True
            Else
                RollbackReleaseTransaction()
            End If
        Catch ex As Exception
            RollbackReleaseTransaction()
            response = ex.Message
        Finally
            CloseConAndTr()
        End Try
        Return False
    End Function

    Private Function _InsertUsuario(con As SqlConnection, ByVal usuario As Usuario, ByRef response As String) As Boolean
        Dim succ As Boolean
        Using Cmd As New SqlClient.SqlCommand
            Cmd.Connection = con
            Cmd.Transaction = Tr
            Cmd.CommandText = "SP_INSERE_USUARIO"
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


    Public Function GetUsuarios(ativo As Boolean, ByRef response As String) As List(Of Usuario)
        Dim LstUsuario As New List(Of Usuario)

        Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
        Using Cmd As New SqlClient.SqlCommand
            Cmd.Connection = Connection
            Cmd.CommandText = "SP_GET_ALL_USUARIOS"
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
                If Connection IsNot Nothing Then
                    Connection.Close()
                    Connection.Dispose()
                    Connection = Nothing
                End If
            Catch ex As Exception
                response = "A busca falhou."
#If DEBUG Then
                response = ex.InnerException.Message + ex.Message + ex.StackTrace
#End If
            End Try
            response = Cmd.Parameters("@RESPONSE").Value
        End Using
        Return LstUsuario
    End Function

    Public Function GetUsuario(ByVal codusuario As String, ByRef resposta As String) As Usuario
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
                If Not Adp Is Nothing Then
                    Adp.Dispose()
                End If
            End Try
        End Using
        Return Nothing
    End Function

    Public Function AtualizaUsuario(usuario As Usuario, ByRef resposta As String) As Boolean

        Con.Open()
        Tr = Con.BeginTransaction
        Try
            If _AtualizaUsuario(usuario, resposta) Then
                Tr.Commit()
                Return True
            Else
                RollbackReleaseTransaction()
            End If
        Catch ex As Exception
            RollbackReleaseTransaction()
            resposta = ex.Message
        Finally
            CloseConAndTr()
        End Try
        Return False
    End Function

    Public Function _AtualizaUsuario(usuario As Usuario, ByRef resposta As String) As Boolean
        Dim succ As Boolean
        Using Cmd As New SqlCommand()
            Cmd.Connection = Con
            Cmd.Transaction = Tr
            Cmd.CommandText = "SP_ATUALIZA_USUARIO"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.Add("@CODUSUARIO", SqlDbType.Int).Value = usuario.CodUsuario
            Cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = usuario.Email
            Cmd.Parameters.Add("@ISATIVO", SqlDbType.Bit).Value = usuario.IsAtivo
            Cmd.Parameters.Add("@RESPONSE", SqlDbType.VarChar).Direction = ParameterDirection.Output
            Cmd.Parameters("@RESPONSE").Size = 255

            If Not Cmd.ExecuteNonQuery > 0 Then
                Throw New Exception(resposta)
                succ = False
            Else
                succ = True
            End If
            resposta = Cmd.Parameters("@RESPONSE").Value
        End Using
        Return succ
    End Function

#End Region

#Region "Cargo"

    Public Function ChecaCargoCliente(ByVal codcargo As Int16, ByVal resposta As Boolean) As Boolean
        Using Cmd As New SqlCommand
            Con.Open()
            Cmd.Connection = Con
            Cmd.CommandText = "SP_CHECA_CARGO_CLIENTE"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@CODCARGO", codcargo)
            Cmd.Parameters.Add("@RESPONSE", SqlDbType.Bit).Direction = ParameterDirection.Output

            Cmd.ExecuteReader()

            resposta = Cmd.Parameters("@RESPONSE").Value
            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If
            Return resposta
        End Using
    End Function

    Public Function InsereCargo(cargo As Cargo, ByRef resposta As String) As Boolean

        Con.Open()
        Tr = Con.BeginTransaction
        Try
            If _InsereCargo(cargo) Then
                Tr.Commit()
                Return True
            Else
                RollbackReleaseTransaction()
            End If
        Catch ex As Exception
            RollbackReleaseTransaction()
            resposta = ex.Message
        Finally
            CloseConAndTr()
        End Try
        Return False
    End Function


    Public Overloads Function GetCargo(ByVal codcargo As String) As Cargo
        Return _GetCargos(True, codcargo, False).FirstOrDefault
    End Function

    Public Overloads Function GetCargo(ByVal ativos As Boolean, Optional todos As Boolean = False) As List(Of Cargo)
        Return _GetCargos(ativos, String.Empty, todos)
    End Function

    Private Function _GetCargos(ativos As Boolean, codcargo As String, ByVal todos As Boolean) As List(Of Cargo)
        Dim lst As New List(Of Cargo)
        CloseConAndTr()
        Using Cmd As New SqlCommand
            Try
                Cmd.Connection = Con
                If codcargo = String.Empty Then
                    Cmd.CommandText = "SP_GET_ALL_CARGOS"
                    Cmd.CommandType = CommandType.StoredProcedure
                    Cmd.Parameters.AddWithValue("@ATIVO", ativos)
                    Cmd.Parameters.AddWithValue("@TODOS", todos)
                Else
                    Cmd.CommandText = "SP_GET_CARGO"
                    Cmd.CommandType = CommandType.StoredProcedure
                    Cmd.Parameters.AddWithValue("@CODCARGO", Convert.ToInt16(codcargo))
                End If
                Dim Adp As New SqlDataAdapter(Cmd)
                Dim Tbl As New DataTable
                Adp.Fill(Tbl)
                If Tbl.Rows.Count > 0 Then
                    For I As Integer = 0 To Tbl.Rows.Count - 1
                        Dim cargo As New Cargo
                        cargo.Carrega(Tbl.Rows(I))
                        lst.Add(cargo)
                    Next
                End If
                If Not Adp Is Nothing Then
                    Adp.Dispose()
                End If
                If Not Tbl Is Nothing Then
                    Tbl.Dispose()
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Using
        Return lst
    End Function

    Private Function _InsereCargo(cargo As Cargo) As Boolean
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

            If Not Cmd.ExecuteNonQuery > 0 Then
                Return False
            Else
                Return True
            End If
        End Using
    End Function

    Public Function AtualizaCargo(cargo As Cargo, ByRef resposta As String, _
        ByVal isExclusao As Boolean, login As String) As Boolean

        Con.Open()
        Tr = Con.BeginTransaction
        Try
            If Not _AtualizaCargo(cargo, isExclusao, resposta, login) Then
                RollbackReleaseTransaction()
            Else
                Tr.Commit()
                Return True
            End If
        Catch ex As Exception
            RollbackReleaseTransaction()
            resposta = ex.Message
        Finally
            CloseConAndTr()
        End Try
        Return False
    End Function

    Private Function _AtualizaCargo(cargo As Cargo, isExclusao As Boolean, _
        ByRef resposta As String, ByVal loginupdate As String) As Boolean

        ' Deleta se nao usado em outras rotinas e inativa se usado em outras rotinas
        If isExclusao And Not IsCargoUsado(cargo.CodCargo) Then
            Using Cmd As New SqlCommand()
                Cmd.Connection = Con
                Cmd.Transaction = Tr
                Cmd.CommandText = "SP_DELETA_CARGO"
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@CODCARGO", cargo.CodCargo)
                Cmd.Parameters.Add("@RESPONSE", SqlDbType.VarChar).Direction = ParameterDirection.Output
                Cmd.Parameters("@RESPONSE").Size = 255
                Try
                    If Not Cmd.ExecuteNonQuery > 0 Then
                        Return False
                    Else
                        Return True
                    End If
                Catch Ex As Exception
                    Return False
                Finally
                    resposta = Cmd.Parameters("@RESPONSE").Value
                End Try
            End Using
        Else
            Using Cmd As New SqlCommand
                Cmd.Connection = Con
                Cmd.Transaction = Tr
                Cmd.CommandText = "SP_ATUALIZA_CARGO"
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@CODCARGO", cargo.CodCargo)
                Cmd.Parameters.AddWithValue("@DESC", cargo.Descricao)
                If Not isExclusao Then
                    Cmd.Parameters.AddWithValue("@ATIVO", cargo.IsAtivo)
                Else
                    Cmd.Parameters.AddWithValue("@ATIVO", False)
                End If
                Cmd.Parameters.AddWithValue("@VENDEDOR", cargo.IsVendedor)
                Cmd.Parameters.AddWithValue("@LOGINALTERACAO", loginupdate)

                If Not Cmd.ExecuteNonQuery > 0 Then
                    Return False
                Else
                    Return True
                End If
            End Using
        End If
    End Function

    Private Function IsCargoUsado(codcargo As Integer) As Boolean
        Dim Cmd As New SqlCommand
        Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
        Try
            Connection.Open()
            Cmd.Connection = Connection
            Cmd.CommandText = "SP_ISCARGO_USADO_VENDEDOR_OU_CLIENTE"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@CODCARGO", codcargo)
            Cmd.Parameters.Add("@RESPONSE", SqlDbType.Bit).Direction = ParameterDirection.Output

            Cmd.ExecuteReader()

            Return Cmd.Parameters("@RESPONSE").Value

        Catch Ex As Exception
            Throw
            Return True
        Finally
            If Cmd IsNot Nothing Then
                Cmd.Dispose()
                Cmd = Nothing
            End If
        End Try
    End Function

#End Region




#Region "Vendedor"

    Public Function InsereVendedor(vendedor As Vendedor, ByRef resposta As String) As Boolean

        Con.Open()
        Tr = Con.BeginTransaction
        Try
            If _InsereVendedor(vendedor) Then
                Tr.Commit()
                Return True
            Else
                RollbackReleaseTransaction()
            End If
        Catch ex As Exception
            RollbackReleaseTransaction()
            resposta = ex.Message
        Finally
            CloseConAndTr()
        End Try
        Return False
    End Function

    Private Function _InsereVendedor(vendedor As Vendedor) As Boolean
        Using Cmd As New SqlCommand()
            Dim fotoByte = System.Text.Encoding.UTF8.GetBytes(vendedor.Foto)

            Cmd.Connection = Con
            Cmd.Transaction = Tr
            Cmd.CommandText = "SP_INSERE_VENDEDOR"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.Add("@CODCARGO", SqlDbType.SmallInt).Value = vendedor.CodCargo
            Cmd.Parameters.Add("@NOME", SqlDbType.VarChar).Value = vendedor.Nome
            Cmd.Parameters.AddWithValue("@SOBRENOME", vendedor.Sobrenome)
            Cmd.Parameters.AddWithValue("@NOMECOMPLETO", vendedor.NomeCompleto)
            Cmd.Parameters.AddWithValue("@CEP", vendedor.ObjEndereco.CEP)
            Cmd.Parameters.AddWithValue("@LOGRADOURO", vendedor.ObjEndereco.Logradouro)
            Cmd.Parameters.Add("@NUM", SqlDbType.SmallInt).Value = vendedor.ObjEndereco.NumeroEndereco
            Cmd.Parameters.AddWithValue("@COMPLEMENTO", vendedor.ObjEndereco.Complemento)
            Cmd.Parameters.AddWithValue("@BAIRRO", vendedor.ObjEndereco.Bairro)
            Cmd.Parameters.AddWithValue("@CIDADE", vendedor.ObjEndereco.Cidade)
            Cmd.Parameters.AddWithValue("@UF", vendedor.ObjEndereco.UF)
            Cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = vendedor.Observacao
            Cmd.Parameters.Add("@FOTO", SqlDbType.VarBinary).Value = fotoByte
            Cmd.Parameters.Add("@ATIVO", SqlDbType.Bit).Value = vendedor.IsAtivo
            Cmd.Parameters.Add("@LOGINCRIACAO", SqlDbType.VarChar).Value = vendedor.LoginCriacao

            If Not Cmd.ExecuteNonQuery > 0 Then
                Return False
            Else
                Return True
            End If
        End Using
    End Function

    Public Overloads Function GetVendedor(ByVal codvendedor As String, ByRef resposta As String) As Vendedor
        Return _GetVendedor(True, codvendedor, resposta, False).FirstOrDefault
    End Function

    Public Overloads Function GetVendedor(ByVal ativos As Boolean, ByRef resposta As String, Optional todos As Boolean = False) As List(Of Vendedor)
        Return _GetVendedor(ativos, String.Empty, resposta, todos)
    End Function

    Private Function _GetVendedor(ativos As Boolean, codvendedor As String, ByRef resposta As String, todos As Boolean) As List(Of Vendedor)

        Dim lst As New List(Of Vendedor)
        Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
        Using Cmd As New SqlCommand
            Try
                Cmd.Connection = Connection
                If codvendedor = String.Empty Then
                    Cmd.CommandText = "SP_GET_ALL_VENDEDORES"
                    Cmd.CommandType = CommandType.StoredProcedure
                    Cmd.Parameters.AddWithValue("@ATIVOS", ativos)
                    Cmd.Parameters.AddWithValue("@TODOS", todos)
                Else
                    Cmd.CommandText = "SP_GET_VENDEDOR"
                    Cmd.CommandType = CommandType.StoredProcedure
                    Cmd.Parameters.AddWithValue("@CODVENDEDOR", Convert.ToInt32(codvendedor))
                End If
                Dim Adp As New SqlDataAdapter(Cmd)
                Dim Tbl As New DataTable
                Adp.Fill(Tbl)
                If Tbl.Rows.Count > 0 Then
                    For I As Integer = 0 To Tbl.Rows.Count - 1
                        Dim vendedor As New Vendedor
                        vendedor.Carrega(Tbl.Rows(I))
                        lst.Add(vendedor)
                    Next
                End If
                If Not Adp Is Nothing Then
                    Adp.Dispose()
                End If
                If Not Tbl Is Nothing Then
                    Tbl.Dispose()
                End If
            Catch ex As Exception
                resposta = ex.Message
            Finally
                If Connection IsNot Nothing Then
                    Connection.Close()
                    Connection.Dispose()
                    Connection = Nothing
                End If
            End Try
        End Using
        Return lst
    End Function

    Public Function AtualizaVendedor(vendedor As Vendedor, ByRef resposta As String, _
        ByVal isExclusao As Boolean, login As String) As Boolean

        Con.Open()
        Tr = Con.BeginTransaction
        Try
            If Not _AtualizaVendedor(vendedor, isExclusao, resposta, login) Then
                RollbackReleaseTransaction()
            Else
                Tr.Commit()
                Return True
            End If
        Catch ex As Exception
            RollbackReleaseTransaction()
            resposta = ex.Message
        Finally
            CloseConAndTr()
        End Try
        Return False
    End Function

    Private Function _AtualizaVendedor(vendedor As Vendedor, isExclusao As Boolean, _
        ByRef resposta As String, ByVal loginupdate As String) As Boolean
        Using Cmd As New SqlCommand
            Cmd.Connection = Con
            Cmd.Transaction = Tr
            Cmd.CommandText = "SP_ATUALIZA_VENDEDOR"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@CODVENDEDOR", vendedor.CodVendedor)
            Cmd.Parameters.Add("@CODCARGO", SqlDbType.SmallInt).Value = vendedor.CodCargo
            Cmd.Parameters.AddWithValue("@CEP", vendedor.ObjEndereco.CEP)
            Cmd.Parameters.AddWithValue("@LOGRADOURO", vendedor.ObjEndereco.Logradouro)
            Cmd.Parameters.Add("@NUM", SqlDbType.SmallInt).Value = vendedor.ObjEndereco.NumeroEndereco
            Cmd.Parameters.AddWithValue("@COMPLEMENTO", vendedor.ObjEndereco.Complemento)
            Cmd.Parameters.AddWithValue("@BAIRRO", vendedor.ObjEndereco.Bairro)
            Cmd.Parameters.AddWithValue("@CIDADE", vendedor.ObjEndereco.Cidade)
            Cmd.Parameters.AddWithValue("@UF", vendedor.ObjEndereco.UF)
            Cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = vendedor.Observacao
            Cmd.Parameters.Add("@ATIVO", SqlDbType.Bit).Value = vendedor.IsAtivo
            Cmd.Parameters.AddWithValue("@LOGINALTERACAO", loginupdate)
            Cmd.Parameters.AddWithValue("@ISDELETE", isExclusao)

            If Not Cmd.ExecuteNonQuery > 0 Then
                Return False
            Else
                Return True
            End If
        End Using
    End Function

#End Region

#Region "Cliente"

    Public Overloads Function GetCliente(ByVal ativos As Boolean, ByRef resposta As String, Optional todos As Boolean = True) As List(Of Cliente)
        Return _GetCliente(0, ativos, resposta, todos)
    End Function

    Public Overloads Function GetCliente(ByVal codcliente As Integer, ByVal ativos As Boolean, _
        ByRef resposta As String) As Cliente

        Return _GetCliente(codcliente, ativos, resposta).FirstOrDefault
    End Function

    Private Function _GetCliente(ByVal codcliente As Integer, ByVal ativos As Boolean, _
        ByRef resposta As String, Optional todos As Boolean = True) As List(Of Cliente)
        Dim Lst As New List(Of Cliente)

        Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
        Using Cmd As New SqlCommand()
            Try
                Cmd.Connection = Connection
                Cmd.CommandText = "SP_GET_CLIENTES"
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@CODCLIENTE", codcliente)
                Cmd.Parameters.AddWithValue("@ATIVOS", ativos)
                Cmd.Parameters.AddWithValue("@TODOS", todos)
                Dim Adp As New SqlDataAdapter(Cmd)
                Dim Tbl As New DataTable
                Adp.Fill(Tbl)

                If Tbl.Rows.Count > 0 Then
                    For I As Integer = 0 To Tbl.Rows.Count - 1
                        Dim cliente As New Cliente()
                        cliente.Carrega(Tbl.Rows(I))
                        Lst.Add(cliente)
                    Next
                End If
                If Not Adp Is Nothing Then
                    Adp.Dispose()
                End If
                If Not Tbl Is Nothing Then
                    Tbl.Dispose()
                End If
            Catch ex As Exception
                resposta = ex.Message
            Finally
                If Connection.State = ConnectionState.Open Then
                    Connection.Close()
                    Connection.Dispose()
                    Connection = Nothing
                End If
            End Try
        End Using
        Return Lst
    End Function

    Public Function GetClientePorCargo(ByVal codcargo As Int16) As Cliente
        Dim cliente As New Cliente
        Dim Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
        Using Cmd As New SqlCommand
            Cmd.Connection = Connection
            Cmd.CommandText = "SP_BUSCA_CLIENTE_PELO_CARGO"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@CODCARGO", codcargo)
            Dim Tbl As New DataTable
            Dim Adp As New SqlDataAdapter(Cmd)

            Adp.Fill(Tbl)
            If Tbl.Rows.Count > 0 Then
                cliente.Carrega(Tbl.Rows(0))
            End If

            If Not Adp Is Nothing Then
                Adp.Dispose()
            End If
            If Not Tbl Is Nothing Then
                Tbl.Dispose()
            End If
        End Using

        If Connection.State = ConnectionState.Open Then
            Connection.Close()
            Connection.Dispose()
            Connection = Nothing
        End If
        Return cliente
    End Function

    Public Function RemoveCargoCliente(ByVal codcliente As Int32, ByVal login As String, ByRef resposta As String) As Boolean

        Con.Open()
        Tr = Con.BeginTransaction
        Try
            If Not _RemoveCargoCliente(codcliente, login) Then
                RollbackReleaseTransaction
            Else
                Tr.Commit()
                Return True
            End If
        Catch ex As Exception
            RollbackReleaseTransaction()
            resposta = ex.Message
        Finally
            CloseConAndTr()
        End Try
        Return False
    End Function


    Private Function _RemoveCargoCliente(ByVal codcliente As Int32, ByVal login As String) As Boolean
        Using Cmd As New SqlCommand
            Cmd.Connection = Con
            Cmd.Transaction = Tr
            Cmd.CommandText = "SP_REMOVE_CARGO_CLIENTE"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@CODCLIENTE", codcliente)
            Cmd.Parameters.AddWithValue("@LOGINALTERACAO", login)
            Return Cmd.ExecuteNonQuery > 0
        End Using
    End Function

    Public Function InsereCliente(ByVal cliente As Cliente, ByRef resposta As String) As Boolean

        Con.Open()
        Tr = Con.BeginTransaction
        Try
            If _InsereCliente(cliente, resposta) Then
                Tr.Commit()
                Return True
            Else
                RollbackReleaseTransaction()
            End If
        Catch ex As Exception
            RollbackReleaseTransaction()
            resposta = ex.Message
        Finally
            CloseConAndTr()
        End Try
        Return False
    End Function

    Private Function _InsereCliente(cliente As Cliente, ByRef resposta As String) As Boolean
        Using Cmd As New SqlCommand()
            Cmd.Connection = Con
            Cmd.Transaction = Tr
            Cmd.CommandText = "SP_INSERE_CLIENTE"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.Add("@CODCARGO", SqlDbType.SmallInt).Value = cliente.CodCargo
            Cmd.Parameters.Add("@NOME", SqlDbType.VarChar).Value = cliente.Nome
            Cmd.Parameters.Add("@DATNASC", SqlDbType.Date).Value = cliente.DatNasc
            Cmd.Parameters.Add("@EMPRESA", SqlDbType.VarChar).Value = cliente.Empresa
            Cmd.Parameters.AddWithValue("@CEP", cliente.ObjEndereco.CEP)
            Cmd.Parameters.AddWithValue("@LOGRADOURO", cliente.ObjEndereco.Logradouro)
            Cmd.Parameters.Add("@NUMCASA", SqlDbType.SmallInt).Value = cliente.ObjEndereco.NumeroEndereco
            Cmd.Parameters.AddWithValue("@COMPLEMENTO", cliente.ObjEndereco.Complemento)
            Cmd.Parameters.AddWithValue("@BAIRRO", cliente.ObjEndereco.Bairro)
            Cmd.Parameters.AddWithValue("@CIDADE", cliente.ObjEndereco.Cidade)
            Cmd.Parameters.AddWithValue("@UF", cliente.ObjEndereco.UF)
            Cmd.Parameters.AddWithValue("@TEL", cliente.Telefone)
            Cmd.Parameters.AddWithValue("@EMAIL", cliente.Email)
            Cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = cliente.Descricao
            Cmd.Parameters.Add("@ATIVO", SqlDbType.Bit).Value = cliente.IsAtivo
            Cmd.Parameters.Add("@LOGINCRIACAO", SqlDbType.VarChar).Value = cliente.LoginCriacao
            Cmd.Parameters.Add("@RESPONSE", SqlDbType.VarChar).Direction = ParameterDirection.Output
            Cmd.Parameters("@RESPONSE").Size = 255

            If Not Cmd.ExecuteNonQuery > 0 Then
                resposta = Cmd.Parameters("@RESPONSE").Value
                Return False
            Else
                Return True
            End If
        End Using
    End Function

    Public Function AtualizaCliente(cliente As Cliente, ByRef resposta As String, _
        ByVal isExclusao As Boolean, login As String) As Boolean

        Con.Open()
        Tr = Con.BeginTransaction
        Try
            If Not _AtualizaCliente(cliente, isExclusao, resposta, login) Then
                RollbackReleaseTransaction()
            Else
                Tr.Commit()
                Return True
            End If
        Catch ex As Exception
            RollbackReleaseTransaction()
            resposta = ex.Message
        Finally
            CloseConAndTr()
        End Try
        Return False
    End Function

    Private Function _AtualizaCliente(cliente As Cliente, isExclusao As Boolean, _
        ByRef resposta As String, ByVal loginupdate As String) As Boolean
        Using Cmd As New SqlCommand
            Cmd.Connection = Con
            Cmd.Transaction = Tr
            Cmd.CommandText = "SP_ATUALIZA_CLIENTE"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@CODCLIENTE", cliente.CodCliente)
            Cmd.Parameters.Add("@CODCARGO", SqlDbType.SmallInt).Value = cliente.CodCargo
            Cmd.Parameters.AddWithValue("@EMPRESA", cliente.Empresa)
            Cmd.Parameters.AddWithValue("@CEP", cliente.ObjEndereco.CEP)
            Cmd.Parameters.AddWithValue("@LOGRADOURO", cliente.ObjEndereco.Logradouro)
            Cmd.Parameters.AddWithValue("@NUMCASA", cliente.ObjEndereco.NumeroEndereco)
            Cmd.Parameters.AddWithValue("@BAIRRO", cliente.ObjEndereco.Bairro)
            Cmd.Parameters.AddWithValue("@CIDADE", cliente.ObjEndereco.Cidade)
            Cmd.Parameters.AddWithValue("@COMPLEMENTO", cliente.ObjEndereco.Complemento)
            Cmd.Parameters.AddWithValue("@UF", cliente.ObjEndereco.UF)
            Cmd.Parameters.AddWithValue("@TEL", cliente.Telefone)
            Cmd.Parameters.AddWithValue("@EMAIL", cliente.Email)
            Cmd.Parameters.Add("@OBS", SqlDbType.VarChar).Value = cliente.Descricao
            Cmd.Parameters.Add("@ATIVO", SqlDbType.Bit).Value = cliente.IsAtivo
            Cmd.Parameters.AddWithValue("@LOGINALTERACAO", loginupdate)
            Cmd.Parameters.AddWithValue("@ISEXCLUSAO", isExclusao)
            Cmd.Parameters.AddWithValue("@RESPONSE", resposta).Direction = ParameterDirection.Output
            Cmd.Parameters("@RESPONSE").Size = 255

            If Not Cmd.ExecuteNonQuery > 0 Then
                Return False
            Else
                Return True
            End If
        End Using
    End Function

#End Region

#Region "Produto"
    Public Overloads Function GetProdutos(ByVal cod As Int32, ByRef resposta As String) As Produto
        Return _GetProdutos(cod, resposta, True, True).FirstOrDefault
    End Function

    Public Overloads Function GetProdutos(ByRef resposta As String, Optional todos As Boolean = False, _
                                          Optional ativos As Boolean = True) As List(Of Produto)
        Return _GetProdutos(0, resposta, todos, ativos)
    End Function

    Public Function _GetProdutos(ByVal cod As Int32, ByRef resposta As String, ByVal todos As Boolean, _
                                 ByVal ativos As Boolean) As List(Of Produto)
        Dim Lst As New List(Of Produto)
        Using Cmd As New SqlCommand
            Try
                Cmd.Connection = Con
                Cmd.CommandText = "SP_GET_PRODUTOS"
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@CODPRODUTO", cod)
                Cmd.Parameters.AddWithValue("@TODOS", todos)
                Cmd.Parameters.AddWithValue("@ATIVOS", ativos)

                Dim Adp As New SqlDataAdapter(Cmd)
                Dim Tbl As New DataTable

                Adp.Fill(Tbl)

                If Tbl.Rows.Count > 0 Then
                    For I As Integer = 0 To Tbl.Rows.Count - 1
                        Dim prod As New Produto
                        prod.Carrega(Tbl.Rows(I))
                        Lst.Add(prod)
                    Next
                End If

                If Not Adp Is Nothing Then
                    Adp.Dispose()
                End If
                If Not Tbl Is Nothing Then
                    Tbl.Dispose()
                End If
            Catch ex As Exception
                resposta = ex.Message
            End Try
        End Using
        Return Lst
    End Function

    Public Function GetProdutoPorCategoriaOuNome(ByVal categ As String, ByVal nome As String) As List(Of Produto)
        Dim Lst As New List(Of Produto)
        Using Cmd As New SqlCommand
            Try
                Cmd.Connection = Con
                Cmd.CommandText = "SP_GET_PRODUTO_POR_CATEGORIA_OU_NOME"
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@CATEGORIA", categ)
                Cmd.Parameters.AddWithValue("@NOME", nome)

                Dim Adp As New SqlDataAdapter(Cmd)
                Dim Tbl As New DataTable

                Adp.Fill(Tbl)

                If Tbl.Rows.Count > 0 Then
                    For I As Integer = 0 To Tbl.Rows.Count - 1
                        Dim prod As New Produto
                        prod.Carrega(Tbl.Rows(I))
                        Lst.Add(prod)
                    Next
                End If

                If Not Adp Is Nothing Then
                    Adp.Dispose()
                End If
                If Not Tbl Is Nothing Then
                    Tbl.Dispose()
                End If
            Catch ex As Exception
                Throw New Exception("A busca encontrou um erro.")
            End Try
        End Using
        Return Lst
    End Function

    Public Function InsereProduto(ByVal obj As Produto, ByRef resposta As String) As Boolean

        Con.Open()
        Tr = Con.BeginTransaction
        Try
            If _InsereProduto(obj, resposta) Then
                Tr.Commit()
                Return True
            Else
                RollbackReleaseTransaction()
            End If
        Catch ex As Exception
            RollbackReleaseTransaction
            resposta = ex.Message
        Finally
            CloseConAndTr()
        End Try
        Return False
    End Function

    Private Function _InsereProduto(produto As Produto, ByRef resposta As String) As Boolean
        Using Cmd As New SqlCommand
            Dim imgByte As Byte()
            If produto.Imagem <> String.Empty Then
                imgByte = System.Text.Encoding.UTF8.GetBytes(produto.Imagem)
            Else
                imgByte = Nothing
            End If
            Cmd.Connection = Con
            Cmd.Transaction = Tr
            Cmd.CommandText = "SP_INSERE_PRODUTO"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@CATEG", produto.Categoria)
            Cmd.Parameters.AddWithValue("@NOME", produto.Nome)
            Cmd.Parameters.AddWithValue("@DESC", produto.Descricao)
            Cmd.Parameters.Add("@PRECO", SqlDbType.Decimal).Value = produto.Preco
            Cmd.Parameters.AddWithValue("@QTD", produto.Quantidade)
            Cmd.Parameters.Add("@IMAGEM", SqlDbType.VarBinary).Value = imgByte
            Cmd.Parameters.AddWithValue("@ATIVO", produto.IsAtivo)
            Cmd.Parameters.AddWithValue("@LOGINCRIACAO", produto.LoginCriacao)
            Cmd.Parameters.Add("@RESPONSE", SqlDbType.VarChar).Direction = ParameterDirection.Output
            Cmd.Parameters("@RESPONSE").Size = 255

            If Cmd.ExecuteNonQuery > 0 Then
                Return True
            Else
                Return False
            End If
            resposta = Cmd.Parameters("@RESPONSE").Value
        End Using
    End Function

    Public Function AtualizaProduto(ByVal obj As Produto, ByRef resposta As String, _
                                    ByVal login As String, Optional isDelete As Boolean = False)
        Con.Open()
        Tr = Con.BeginTransaction
        Try
            If _AtualizaProduto(obj, isDelete, login) Then
                Tr.Commit()
                Return True
            Else
                RollbackReleaseTransaction()
            End If
        Catch ex As Exception
            RollbackReleaseTransaction()
            resposta = ex.Message
        Finally
            CloseConAndTr()
        End Try
        Return False
    End Function

    Private Function _AtualizaProduto(produto As Produto, isDelete As Boolean, _
                                             login As String) As Boolean

        Dim succ As Boolean = False
        Using Cmd As New SqlCommand
            Cmd.Connection = Con
            Cmd.Transaction = Tr
            Cmd.CommandText = "SP_ATUALIZA_PRODUTO"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@CODPRODUTO", produto.CodProduto)
            Cmd.Parameters.AddWithValue("@PRECO", produto.Preco)
            Cmd.Parameters.AddWithValue("@QTD", produto.Quantidade)
            Cmd.Parameters.AddWithValue("@ATIVO", produto.IsAtivo)
            Cmd.Parameters.AddWithValue("@LOGINALTERACAO", login)
            Cmd.Parameters.AddWithValue("@ISEXCLUSAO", isDelete)

            If Cmd.ExecuteNonQuery > 0 Then
                succ = True
            Else
                succ = False
            End If
        End Using
        Return succ
    End Function

    Public Function GetCategoriasProduto(ByRef resposta As String) As List(Of String)
        Dim lst As New List(Of String)
        Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
        Using Cmd As New SqlCommand()
            Connection.Open()
            Cmd.Connection = Connection
            Cmd.CommandText = "SP_GET_CATEGORIAS_PRODUTOS"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.Add("@RESPONSE", SqlDbType.VarChar).Direction = ParameterDirection.Output
            Cmd.Parameters("@RESPONSE").Size = 255

            Dim reader = Cmd.ExecuteReader

            If reader.HasRows Then
                While reader.Read
                    lst.Add(reader.GetValue(0))
                End While
            End If

            resposta = Cmd.Parameters("@RESPONSE").Value

            If Connection.State = ConnectionState.Open Then
                Connection.Close()
                Connection.Dispose()
                Connection = Nothing
            End If
        End Using

        Return lst
    End Function

    Public Function GetProdutosPorCategoria(ByVal categ As String, ByRef resposta As String, _
                    Optional todos As Boolean = False) As List(Of Produto)
        Dim lst As New List(Of Produto)
        Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
        Using Cmd As New SqlCommand
            Cmd.Connection = Connection
            Cmd.CommandText = "SP_GET_PRODUTOS_POR_CATEGORIA"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@CATEGORIA", categ)
            Cmd.Parameters.AddWithValue("@TODOS", todos)
            Cmd.Parameters.Add("@RESPONSE", SqlDbType.VarChar).Direction = ParameterDirection.Output
            Cmd.Parameters("@RESPONSE").Size = 255

            Dim Adp As New SqlDataAdapter(Cmd)
            Dim Tbl As New DataTable

            Adp.Fill(Tbl)

            If Tbl.Rows.Count > 0 Then
                For I As Integer = 0 To Tbl.Rows.Count - 1
                    Dim prod As New Produto
                    prod.Carrega(Tbl.Rows(I))
                    lst.Add(prod)
                Next
            End If

            resposta = Cmd.Parameters("@RESPONSE").Value

            If Adp IsNot Nothing Then
                Adp.Dispose()
                Adp = Nothing
            End If

            If Tbl IsNot Nothing Then
                Tbl.Dispose()
                Tbl = Nothing
            End If
        End Using
        If Connection.State = ConnectionState.Open Then
            Connection.Close()
            Connection.Dispose()
            Connection = Nothing
        End If

        Return lst

    End Function

#End Region

#Region "Pedido"
    Public Overloads Function GetPedido(ByVal codpedido As String, ByRef resposta As String) As Pedido
        Return _GetPedido(codpedido, resposta, 0, 0, "", Nothing, Nothing).FirstOrDefault
    End Function

    Public Overloads Function GetPedido(ByRef resposta As String, Optional codvendedor As Integer = 0, _
                                        Optional codcliente As Integer = 0, Optional nomecliente As String = "", _
                                        Optional dtinicial As DateTime = Nothing, Optional dtfinal As DateTime = Nothing) As List(Of Pedido)

        If dtinicial = DateTime.MinValue AndAlso dtfinal = DateTime.MinValue Then
            dtinicial = Data.SqlTypes.SqlDateTime.MinValue
            dtfinal = Data.SqlTypes.SqlDateTime.MaxValue
        End If

        Return _GetPedido("", resposta, codcliente, codvendedor, nomecliente, dtinicial, dtfinal)
    End Function

    Private Function _GetPedido(ByVal codpedido As String, ByRef resposta As String, _
                                ByVal codcliente As Integer, ByVal codvendedor As Integer, ByVal nomecliente As String, _
                                ByVal dtinicial As DateTime, ByVal dtfinal As DateTime) As List(Of Pedido)
        Dim lst As New List(Of Pedido)
        Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
        Using Cmd As New SqlCommand
            Cmd.Connection = Connection
            Cmd.CommandText = "SP_GET_PEDIDO"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@CODPEDIDO", codpedido)
            Cmd.Parameters.AddWithValue("@CODCLIENTE", codcliente)
            Cmd.Parameters.AddWithValue("@CODVENDEDOR", codvendedor)
            Cmd.Parameters.AddWithValue("@NOMECLIENTE", nomecliente)
            Cmd.Parameters.AddWithValue("@DATINICIAL", dtinicial)
            Cmd.Parameters.AddWithValue("@DATFINAL", dtfinal)
            Cmd.Parameters.Add("@RESPONSE", SqlDbType.VarChar).Direction = ParameterDirection.Output
            Cmd.Parameters("@RESPONSE").Size = 255

            Dim Adp As New SqlDataAdapter(Cmd)
            Dim Tbl As New DataTable

            Adp.Fill(Tbl)

            If Tbl.Rows.Count > 0 Then
                For i As Integer = 0 To Tbl.Rows.Count - 1
                    Dim ped As New Pedido
                    ped.Carrega(Tbl.Rows(i))
                    lst.Add(ped)
                Next
            End If
            If Adp IsNot Nothing Then
                Adp.Dispose()
                Adp = Nothing
            End If
            If Tbl IsNot Nothing Then
                Tbl.Dispose()
                Tbl = Nothing
            End If
            resposta = Cmd.Parameters("@RESPONSE").Value
        End Using
        Return lst
    End Function

    Public Function InserePedido(ByVal obj As Pedido, ByVal lstItens As List(Of PedidoItem), ByRef resposta As String) As Boolean
        Con.Open()
        Tr = Con.BeginTransaction
        Try
            If _InserePedido(obj) AndAlso lstItens.All(Function(pi As PedidoItem) _
                                                _InserePedidoItem(pi)) Then
                Tr.Commit()
                Return True
            Else
                RollbackReleaseTransaction()
            End If
        Catch ex As Exception
            RollbackReleaseTransaction()
            resposta = ex.Message
        Finally
            CloseConAndTr()
        End Try
        Return False
    End Function

    Private Function _InserePedido(obj As Pedido) As Boolean
        Using Cmd As New SqlCommand
            Cmd.Connection = Con
            Cmd.Transaction = Tr
            Cmd.CommandText = "SP_INSERE_PEDIDO"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@CODPEDIDO", obj.CodPedido)
            Cmd.Parameters.AddWithValue("@CODCLIENTE", obj.CodCliente)
            Cmd.Parameters.AddWithValue("@CODVENDEDOR", obj.CodVendedor)
            Cmd.Parameters.AddWithValue("@DESTINATARIO", obj.Destinatario)
            Cmd.Parameters.AddWithValue("@CEP", obj.ObjEndereco.CEP)
            Cmd.Parameters.AddWithValue("@LOGRADOURO", obj.ObjEndereco.Logradouro)
            Cmd.Parameters.Add("@NUM", SqlDbType.SmallInt).Value = Convert.ToInt16(obj.ObjEndereco.NumeroEndereco)
            Cmd.Parameters.AddWithValue("@BAIRRO", obj.ObjEndereco.Bairro)
            Cmd.Parameters.AddWithValue("@CIDADE", obj.ObjEndereco.Cidade)
            Cmd.Parameters.AddWithValue("@COMPLEMENTO", obj.ObjEndereco.Complemento)
            Cmd.Parameters.AddWithValue("@UF", obj.ObjEndereco.UF)
            Cmd.Parameters.AddWithValue("@DATVENDA", obj.DatVenda)
            Cmd.Parameters.AddWithValue("@OBS", obj.Observacao)
            Cmd.Parameters.AddWithValue("@VALORTOTAL", obj.ValorTotal)
            Cmd.Parameters.AddWithValue("@ISPRESENTE", obj.IsPresente)
            Cmd.Parameters.AddWithValue("@LOGINCRIACAO", obj.LoginCriacao)

            If Cmd.ExecuteNonQuery > 0 Then
                Return True
            Else
                Return False
            End If
        End Using
    End Function

    Private Function _InserePedidoItem(obj As PedidoItem) As Boolean
        'Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
        'Connection.Open()
        'Dim tr = Connection.BeginTransaction
        Try
            Using Cmd As New SqlCommand
                Cmd.Connection = Con
                Cmd.Transaction = Tr
                Cmd.CommandText = "SP_INSERE_PEDIDO_ITEM"
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@CODPEDIDO", obj.CodPedido)
                Cmd.Parameters.AddWithValue("@CODPRODUTO", obj.CodProduto)
                Cmd.Parameters.AddWithValue("@QTD", obj.Quantidade)

                If Cmd.ExecuteNonQuery > 0 Then
                    'tr.Commit()
                    Return True
                End If
            End Using
        Catch ex As Exception
            'tr.Rollback()
            'tr.Dispose()
            'tr = Nothing
            Throw
        Finally
            'If Connection.State = ConnectionState.Open Then
            '    Connection.Close()
            '    Connection.Dispose()
            '    Connection = Nothing
            'End If
            'If tr IsNot Nothing Then
            '    tr.Dispose()
            '    tr = Nothing
            'End If
        End Try
        Return False
    End Function

    Public Function AtualizaPedido(obj As Pedido, lstItens As List(Of PedidoItem), ByRef resposta As String, _
                                   Optional isExclusao As Boolean = False) As Boolean
        Con.Open()
        Tr = Con.BeginTransaction

        Try
            If _AtualizaPedido(obj, isExclusao) AndAlso lstItens.All(Function(pi As PedidoItem) _AtualizaItensPedido(pi, isExclusao) = True) Then
                Tr.Commit()
                Return True
            End If
        Catch ex As Exception
            resposta = ex.Message
            RollbackReleaseTransaction()
        Finally
            CloseConAndTr()
        End Try
        Return False
    End Function

    Private Function _AtualizaPedido(obj As Pedido, isExclusao As Boolean) As Boolean
        Using Cmd As New SqlCommand()
            Cmd.Connection = Con
            Cmd.Transaction = Tr
            Cmd.CommandText = "SP_ATUALIZA_PEDIDO"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@CODPEDIDO", obj.CodPedido)
            Cmd.Parameters.AddWithValue("@CODCLIENTE", obj.CodCliente)
            Cmd.Parameters.AddWithValue("@CODVENDEDOR", obj.CodVendedor)
            Cmd.Parameters.AddWithValue("@DESTINATARIO", obj.Destinatario)
            Cmd.Parameters.AddWithValue("@DATVENDA", obj.DatVenda)
            Cmd.Parameters.AddWithValue("@CEP", obj.ObjEndereco.CEP)
            Cmd.Parameters.AddWithValue("@LOGRADOURO", obj.ObjEndereco.Logradouro)
            Cmd.Parameters.Add("@NUM", SqlDbType.SmallInt).Value = obj.ObjEndereco.NumeroEndereco
            Cmd.Parameters.AddWithValue("@COMPLEMENTO", obj.ObjEndereco.Complemento)
            Cmd.Parameters.AddWithValue("@BAIRRO", obj.ObjEndereco.Bairro)
            Cmd.Parameters.AddWithValue("@CIDADE", obj.ObjEndereco.Cidade)
            Cmd.Parameters.AddWithValue("@UF", obj.ObjEndereco.UF)
            Cmd.Parameters.AddWithValue("@OBS", obj.Observacao)
            Cmd.Parameters.AddWithValue("@ISPRESENTE", obj.IsPresente)
            Cmd.Parameters.AddWithValue("@VALORTOTAL", obj.ValorTotal)
            Cmd.Parameters.AddWithValue("@ISEXCLUSAO", isExclusao)

            If Cmd.ExecuteNonQuery > 0 Then
                Return True
            Else
                Return False
            End If
        End Using
    End Function

    Private Function _AtualizaItensPedido(obj As PedidoItem, ByVal isExclusao As Boolean) As Boolean
        Using Cmd As New SqlCommand()
                Cmd.Connection = Con
                Cmd.Transaction = Tr
                Cmd.CommandText = "SP_ATUALIZA_ITENS_PEDIDO"
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@CODPEDIDO", obj.CodPedido)
                Cmd.Parameters.AddWithValue("@CODPRODUTO", obj.CodProduto)
                Cmd.Parameters.AddWithValue("@QTD", obj.Quantidade)
                Cmd.Parameters.AddWithValue("@ISEXCLUSAO", isExclusao)

            If Cmd.ExecuteNonQuery > 0 Then
                Return True
            Else
                Return False
            End If
        End Using
    End Function

    Public Function GetItemPedido(ByVal codpedido As String, ByRef resposta As String) As List(Of PedidoItem)
        Dim lst As New List(Of PedidoItem)
        Using Cmd As New SqlCommand
            Cmd.Connection = Con
            Cmd.CommandText = "SP_GET_ITEM_PEDIDO"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@CODPEDIDO", codpedido)
            Dim Adp As New SqlDataAdapter(Cmd)
            Dim Tbl As New DataTable

            Adp.Fill(Tbl)

            If Tbl.Rows.Count > 0 Then
                For I As Integer = 0 To Tbl.Rows.Count - 1
                    Dim pedItem As New PedidoItem
                    pedItem.Carrega(Tbl.Rows(I))
                    lst.Add(pedItem)
                Next
            End If

            If Adp IsNot Nothing Then
                Adp.Dispose()
                Adp = Nothing
            End If
            If Tbl IsNot Nothing Then
                Tbl.Dispose()
                Tbl = Nothing
            End If
        End Using

        Return lst
    End Function

#End Region

#Region "Estados"
    Public Function GetEstados(ByRef resposta As String) As List(Of EstadoUF)
        Dim Lst As New List(Of EstadoUF)
        Using Con = New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
            Using Cmd As New SqlCommand
                Dim Adp As New SqlDataAdapter
                Dim Tbl As New DataTable
                Try
                    Cmd.Connection = Con
                    Cmd.CommandText = "SP_GET_ESTADOS"
                    Cmd.CommandType = CommandType.StoredProcedure
                    Adp.SelectCommand = Cmd
                    Adp.Fill(Tbl)

                    If Tbl.Rows.Count > 0 Then
                        For I As Integer = 0 To Tbl.Rows.Count - 1
                            Dim estado As New EstadoUF
                            estado.Carrega(Tbl.Rows(I))
                            Lst.Add(estado)
                        Next
                    End If

                Catch ex As Exception
                    resposta = ex.Message
                Finally
                    If Not Adp Is Nothing Then
                        Adp.Dispose()
                    End If
                    If Not Tbl Is Nothing Then
                        Tbl.Dispose()
                    End If
                End Try
            End Using
        End Using
        Return Lst
    End Function

#End Region

#Region "Transaction"
    Public Sub CloseConAndTr()
        Try

            If Tr IsNot Nothing Then
                Tr.Dispose()
                Tr = Nothing
            End If

            If Con.State = ConnectionState.Open Then
                Con.Close()
            End If

        Catch ex As Exception
            Throw New Exception("Ocorreu um erro ao fechar a conexão.")
        End Try
    End Sub

    Private Sub RollbackReleaseTransaction()

        If Tr IsNot Nothing Then
            Tr.Rollback()
            Tr.Dispose()
            Tr = Nothing
        End If

        If Con.State = ConnectionState.Open Then
            Con.Close()
        End If
    End Sub

#End Region

End Class
