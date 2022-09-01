Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports Entidades

Public Class DAO

    ' Deve ser feita uma operação por vez
    ' Não pode haver instâncias diferentes pois isso abre margem para diferentes conexões e transações abertas ao mesmo tempo
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


    Public Shared Function GetUsuarios(ativo As Boolean, ByRef response As String) As List(Of Usuario)
        Dim ConnStr As String = ConfigurationManager.ConnectionStrings("ConnString").ConnectionString
        Dim LstUsuario As New List(Of Usuario)

        Using Con As New SqlClient.SqlConnection(ConnStr)
            Using Cmd As New SqlClient.SqlCommand
                Cmd.Connection = Con
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

    Public Shared Function ChecaCargoCliente(ByVal codcargo As Int16, ByVal resposta As Boolean) As Boolean
        Using Con As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
            Using Cmd As New SqlCommand
                Con.Open()
                Cmd.Connection = Con
                Cmd.CommandText = "SP_CHECA_CARGO_CLIENTE"
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@CODCARGO", codcargo)
                Cmd.Parameters.Add("@RESPONSE", SqlDbType.Bit).Direction = ParameterDirection.Output

                Cmd.ExecuteReader()

                resposta = Cmd.Parameters("@RESPONSE").Value
                Return resposta
            End Using
        End Using
    End Function

    Public Shared Function InsereCargo(cargo As Cargo, ByRef resposta As String) As Boolean
        Con = New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
        Con.Open()
        Tr = Con.BeginTransaction
        Try
            If _InsereCargo(cargo) Then
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


    Public Overloads Shared Function GetCargo(ByVal codcargo As String) As Cargo
        Return _GetCargos(True, codcargo).FirstOrDefault
    End Function

    Public Overloads Shared Function GetCargo(ByVal ativos As Boolean) As List(Of Cargo)
        Return _GetCargos(ativos, String.Empty)
    End Function

    Private Shared Function _GetCargos(ativos As Boolean, codcargo As String) As List(Of Cargo)
        Dim lst As New List(Of Cargo)
        Using Con As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
            Using Cmd As New SqlCommand
                Try
                    Cmd.Connection = Con
                    If codcargo = String.Empty Then
                        Cmd.CommandText = "SP_GET_ALL_CARGOS"
                        Cmd.CommandType = CommandType.StoredProcedure
                        Cmd.Parameters.AddWithValue("@ATIVO", ativos)
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
        End Using
        Return lst
    End Function

    Private Shared Function _InsereCargo(cargo As Cargo) As Boolean
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

    Public Shared Function AtualizaCargo(cargo As Cargo, ByRef resposta As String, _
        ByVal isExclusao As Boolean, login As String) As Boolean

        Con = New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
        Con.Open()
        Tr = Con.BeginTransaction
        Try
            If Not _AtualizaCargo(cargo, isExclusao, resposta, login) Then
                Tr.Rollback()
            Else
                If Not isExclusao Then
                    Tr.Commit()
                End If
                Return True
            End If
        Catch ex As Exception
            resposta = ex.Message
            Tr.Rollback()
        End Try
        Return False
    End Function

    Private Shared Function _AtualizaCargo(cargo As Cargo, isExclusao As Boolean, _
        ByRef resposta As String, ByVal loginupdate As String) As Boolean

        ' Deleta se nao usado em outras rotinas e inativa se usado em outras rotinas
        If isExclusao And Not IsCargoUsado(cargo) Then
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

    Private Shared Function IsCargoUsado(cargo As Cargo) As Boolean
        Using Cmd As New SqlCommand
            Try
                Cmd.Connection = Con
                Cmd.CommandText = "SP_CHECA_CARGO"
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@CODUSUARIO", Convert.ToInt32(cargo.CodCargo))
                Cmd.Parameters.Add("@RESPONSE", SqlDbType.Bit).Direction = ParameterDirection.Output

                Cmd.ExecuteReader()

                Return Cmd.Parameters("@RESPONSE").Value

            Catch Ex As Exception
                Return True
            End Try
        End Using
    End Function

#End Region




#Region "Vendedor"

    Public Shared Function InsereVendedor(vendedor As Vendedor, ByRef resposta As String) As Boolean
        Con = New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
        Con.Open()
        Tr = Con.BeginTransaction
        Try
            If _InsereVendedor(vendedor) Then
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

    Private Shared Function _InsereVendedor(vendedor As Vendedor) As Boolean
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

    Public Overloads Shared Function GetVendedor(ByVal codvendedor As String, ByRef resposta As String) As Vendedor
        Return _GetVendedor(True, codvendedor, resposta).FirstOrDefault
    End Function

    Public Overloads Shared Function GetVendedor(ByVal ativos As Boolean, ByRef resposta As String) As List(Of Vendedor)
        Return _GetVendedor(ativos, String.Empty, resposta)
    End Function

    Private Shared Function _GetVendedor(ativos As Boolean, codvendedor As String, ByRef resposta As String) As List(Of Vendedor)
        Dim lst As New List(Of Vendedor)
        Using Con As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
            Using Cmd As New SqlCommand
                Try
                    Cmd.Connection = Con
                    If codvendedor = String.Empty Then
                        Cmd.CommandText = "SP_GET_ALL_VENDEDORES"
                        Cmd.CommandType = CommandType.StoredProcedure
                        Cmd.Parameters.AddWithValue("@ATIVO", ativos)
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
                End Try
            End Using
        End Using
        Return lst
    End Function

    Public Shared Function AtualizaVendedor(vendedor As Vendedor, ByRef resposta As String, _
        ByVal isExclusao As Boolean, login As String) As Boolean

        Con = New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
        Con.Open()
        Tr = Con.BeginTransaction
        Try
            If Not _AtualizaVendedor(vendedor, isExclusao, resposta, login) Then
                Tr.Rollback()
            Else
                If Not isExclusao Then
                    Tr.Commit()
                End If
                Return True
            End If
        Catch ex As Exception
            resposta = ex.Message
            Tr.Rollback()
        End Try
        Return False
    End Function

    Private Shared Function _AtualizaVendedor(vendedor As Vendedor, isExclusao As Boolean, _
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

    Public Overloads Shared Function GetCliente(ByVal ativos As Boolean, ByRef resposta As String) As List(Of Cliente)
        Return _GetCliente(0, ativos, resposta)
    End Function

    Public Overloads Shared Function GetCliente(ByVal codcliente As Integer, ByVal ativos As Boolean, _
        ByRef resposta As String) As Cliente

        Return _GetCliente(codcliente, ativos, resposta).FirstOrDefault
    End Function

    Private Shared Function _GetCliente(ByVal codcliente As Integer, ByVal ativos As Boolean, _
        ByRef resposta As String) As List(Of Cliente)
        Dim Lst As New List(Of Cliente)

        Using Con As New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
            Using Cmd As New SqlCommand()
                Try
                    Cmd.Connection = Con
                    Cmd.CommandText = "SP_GET_CLIENTES"
                    Cmd.CommandType = CommandType.StoredProcedure
                    Cmd.Parameters.AddWithValue("@CODCLIENTE", codcliente)
                    Cmd.Parameters.AddWithValue("@ATIVOS", ativos)
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
                End Try
            End Using
        End Using
        Return Lst
    End Function

    Public Shared Function GetClientePorCargo(ByVal codcargo As Int16) As Cliente
        Dim cliente As New Cliente
        Using Con = New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
            Using Cmd As New SqlCommand
                Cmd.Connection = Con
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
        End Using
        Return cliente
    End Function

    Public Shared Function RemoveCargoCliente(ByVal codcliente As Int32, ByRef resposta As String) As Boolean
        Con = New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
        Con.Open()
        Tr = Con.BeginTransaction
        Try
            If Not _RemoveCargoCliente(codcliente) Then
                Tr.Rollback()
            Else
                Tr.Commit()
                Return True
            End If
        Catch ex As Exception
            resposta = ex.Message
            Tr.Rollback()
        Finally
            If Not Con Is Nothing Then
                Con.Dispose()
            End If
            If Not Tr Is Nothing Then
                Tr.Dispose()
            End If
        End Try
        Return False
    End Function


    Private Shared Function _RemoveCargoCliente(ByVal codcliente As Int32) As Boolean
        Using Cmd As New SqlCommand
            Cmd.Connection = Con
            Cmd.Transaction = Tr
            Cmd.CommandText = "SP_REMOVE_CARGO_CLIENTE"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@CODCLIENTE", codcliente)
            Return Cmd.ExecuteNonQuery > 0
        End Using
    End Function

    Public Shared Function InsereCliente(ByVal cliente As Cliente, ByRef resposta As String) As Boolean
        Con = New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
        Con.Open()
        Tr = Con.BeginTransaction
        Try
            If _InsereCliente(cliente, resposta) Then
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

    Private Shared Function _InsereCliente(cliente As Cliente, ByRef resposta As String) As Boolean
        Using Cmd As New SqlCommand()
            Cmd.Connection = Con
            Cmd.Transaction = Tr
            Cmd.CommandText = "SP_INSERE_CLIENTE"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.Add("@CODCARGO", SqlDbType.SmallInt).Value = cliente.CodCargo
            Cmd.Parameters.Add("@NOME", SqlDbType.VarChar).Value = cliente.Nome
            Cmd.Parameters.Add("@CPF", SqlDbType.Char).Value = cliente.CPF
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

    Public Shared Function AtualizaCliente(cliente As Cliente, ByRef resposta As String, _
        ByVal isExclusao As Boolean, login As String) As Boolean

        Con = New SqlConnection(ConfigurationManager.ConnectionStrings("ConnString").ConnectionString)
        Con.Open()
        Tr = Con.BeginTransaction
        Try
            If Not _AtualizaCliente(cliente, isExclusao, resposta, login) Then
                Tr.Rollback()
            Else
                If Not isExclusao Then
                    Tr.Commit()
                End If
                Return True
            End If
        Catch ex As Exception
            resposta = ex.Message
            Tr.Rollback()
        End Try
        Return False
    End Function

    Private Shared Function _AtualizaCliente(cliente As Cliente, isExclusao As Boolean, _
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

#Region "Estados"
    Public Shared Function GetEstados(ByRef resposta As String) As List(Of EstadoUF)
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
