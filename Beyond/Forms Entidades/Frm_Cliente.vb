Imports Entidades
Imports Uteis

Public Class Frm_Cliente

    Private frmPrincipal As Frm_Principal_MDI
    Private LstCargos As New List(Of Cargo)
    Private LstEstados As New List(Of EstadoUF)
    Private LstCliente As New List(Of Cliente)
    Private Endereco As Endereco
    Private DAOCliente As New DAO.DAO
    Private MyModo As New UC_Toolstrip.UniqueModo
    Private objCliente As Cliente
    Private toolStrip As UC_Toolstrip


    Public Sub New(frm As Frm_Principal_MDI)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        frmPrincipal = frm
        toolStrip = frmPrincipal.UC_Toolstrip1
    End Sub

    Private Sub Frm_Cliente_EnabledChanged(sender As Object, e As System.EventArgs) Handles Me.EnabledChanged
        If Me.Enabled Then
            toolStrip.ToolbarItemsState(MyModo.UniqueModo, Not IsNothing(objCliente))
        End If
    End Sub

    Private Sub Frm_Cliente_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        RemoveHandler toolStrip.itemclick, AddressOf Me.ToolStrip_ItemClicked
    End Sub

    Private Sub Frm_Cliente_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Desativa_Campos()
        AddHandler toolStrip.itemclick, AddressOf Me.ToolStrip_ItemClicked
        CarregaEstados()
        MyModo.UniqueModo = "PADRÃO"
    End Sub

    Private Sub AlternarControle()
        If MyModo.UniqueModo = "PESQUISAR" Then
            ComboNome.DropDownStyle = ComboBoxStyle.DropDown
            ComboNome.AutoCompleteMode = AutoCompleteMode.Suggest
        ElseIf MyModo.UniqueModo = "NOVO" Then
            ComboNome.AutoCompleteMode = AutoCompleteMode.None
            ComboNome.DropDownStyle = ComboBoxStyle.Simple
        End If
    End Sub

    Private Sub ComboNome_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboNome.SelectedIndexChanged
        If Not String.IsNullOrWhiteSpace(ComboNome.Text) Then
            If objCliente IsNot Nothing Then
                objCliente = Nothing
            End If
            BuscaClientePorCodigo(LstCliente(ComboNome.SelectedIndex).CodCliente)
        Else
            toolStrip.EstadoAlterarExcluir(False)
            Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxEndereco.Controls)
            Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxInfo.Controls)
        End If
    End Sub

    Private Sub Desativa_Campos()
        ControlsHelper.SetControlsDisabled(GrpBoxEndereco.Controls)
        ControlsHelper.SetControlsDisabled(GrpBoxInfo.Controls)
    End Sub


    Private Sub LimpaCampos_AtivaControles()
        ControlsHelper.SetControlsEnabled(Me.Controls)
        Uteis.ControlsHelper.SetControlsEnabled(GrpBoxEndereco.Controls)
        ControlsHelper.SetControlsEnabled(GrpBoxInfo.Controls)
        Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxEndereco.Controls)
        Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxInfo.Controls)
        ChkBoxAtivo.Checked = True
        DtPckNasc.Value = Date.Now
    End Sub

    Private Function Insere() As Boolean
        If Not ValidaCampos() Then
            Return False
        End If

        Dim cliente As New Cliente

        If ComboCargo.SelectedIndex > -1 Then
            cliente.CodCargo = LstCargos(ComboCargo.SelectedIndex).CodCargo
        Else
            cliente.CodCargo = Nothing
        End If
        cliente.Nome = ComboNome.Text.ToUpper
        cliente.DatNasc = DtPckNasc.Value
        cliente.Empresa = TxtEmpresa.Text.ToUpper
        cliente.Telefone = StringHelper.NumericOnly(TxtCelular.Text)
        cliente.Email = TxtEmail.Text.ToUpper

        cliente.ObjEndereco = New Endereco()
        cliente.ObjEndereco.CEP = StringHelper.NumericOnly(TxtCEP.Text)
        cliente.ObjEndereco.Logradouro = TxtLogradouro.Text.ToUpper
        cliente.ObjEndereco.Bairro = TxtBairro.Text.ToUpper
        cliente.ObjEndereco.Cidade = TxtCidade.Text.ToUpper
        cliente.ObjEndereco.UF = LstEstados.Item(ComboEstado.SelectedIndex).UF
        cliente.ObjEndereco.Complemento = TxtComplemento.Text.ToUpper
        cliente.ObjEndereco.NumeroEndereco = TxtNum.Text

        cliente.Descricao = TxtObs.Text.ToUpper
        cliente.IsAtivo = ChkBoxAtivo.Checked

        Dim strError As String = ""

        If Not cliente.IsValid(strError) Then
            MsgBoxHelper.Alerta(Me, strError, "Erro de preenchimento")
            Return False
        End If

        Dim resposta As String = ""

        If Not DAOCliente.InsereCliente(cliente, resposta, codusuario) Then
            Uteis.MsgBoxHelper.Alerta(Me, resposta, "Erro")
            Return False
        End If

        Dim frmSucc As New Dlg_Success
        frmSucc.ShowDialog()
        Return True
    End Function

    Private Sub CarregaCargos()
        LstCargos.Clear()
        ComboCargo.Items.Clear()

        LstCargos = DAOCliente.GetCargo(True)

        If Not LstCargos.Count > 0 Then
            MsgBoxHelper.Alerta(Me, "O sistema não conseguiu buscar os cargos.", "Erro")
            Exit Sub
        End If

        LstCargos.RemoveAll(Function(crg) crg.IsVendedor = True)

        ComboCargo.BeginUpdate()
        ComboCargo.Items.AddRange(LstCargos.ToArray)
        ComboCargo.DisplayMember = "Nome"
        ComboCargo.ValueMember = "CodCargo"
        ComboCargo.EndUpdate()
    End Sub

    Private Sub TxtCEP_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCEP.TextChanged
        If TxtCEP.Text.Length >= 9 Then
            Endereco = New Endereco(EnderecoHelper.GetEnderecoViaCEP(TxtCEP.Text))
            If Endereco.ObjEnderecoJson Is Nothing Then
                Endereco = Nothing
                Exit Sub
            End If

            PreencheEnderecoAutomaticamente()
        End If
    End Sub

    Private Sub PreencheEnderecoAutomaticamente()
        If Not Endereco Is Nothing Then
            TxtBairro.Text = Endereco.Bairro.ToUpper
            TxtCidade.Text = Endereco.Cidade.ToUpper
            TxtLogradouro.Text = Endereco.Logradouro.ToUpper

            ComboEstado.SelectedIndex = LstEstados.FindIndex(Function(e As EstadoUF) e.UF = Endereco.UF)
        End If
    End Sub

    Private Sub CarregaEstados()
        Dim resposta As String = ""

        LstEstados.Clear()
        ComboEstado.Items.Clear()

        LstEstados = DAOCliente.GetEstados(resposta)

        If Not LstEstados.Count > 0 Then
            MsgBoxHelper.Erro(Me, resposta, "UF vazio")
        Else
            ComboEstado.BeginUpdate()
            ComboEstado.Items.AddRange(LstEstados.ToArray)
            ComboEstado.DisplayMember = "Nome"
            ComboEstado.ValueMember = "UF"
            ComboEstado.EndUpdate()
        End If
    End Sub

    Private Sub ToolStrip_ItemClicked()
        If Not Me.Enabled Then
            Exit Sub
        End If

        Dim resposta As String = ""

        MyModo.UniqueModoAnterior = UC_Toolstrip.ModoAnterior
        MyModo.UniqueModo = UC_Toolstrip.Modo

        If MyModo.UniqueModo = "SALVAR" Then
            If ComboNome.DropDownStyle = ComboBoxStyle.Simple AndAlso Not MyModo.UniqueModoAnterior = "ALTERAR" Then
                If Insere() Then
                    LimpaCampos_AtivaControles()
                    Desativa_Campos()
                    toolStrip.AfterSuccessfulInsert()
                Else
                    toolStrip.ToolbarItemsState(MyModo.UniqueModoAnterior, False)
                End If
            Else
                If ValidaCampos() Then
                    Dim cli = GetClienteForOperation()
                    If cli Is Nothing Then
                        toolStrip.ToolbarItemsState(MyModo.UniqueModoAnterior, False)
                        Exit Sub
                    End If
                    If Not DAOCliente.AtualizaCliente(GetClienteForOperation, resposta, False, codusuario) Then
                        toolStrip.ToolbarItemsState(MyModo.UniqueModoAnterior, False)
                        MsgBoxHelper.Alerta(Me, resposta, "Erro")
                    Else
                        MsgBoxHelper.Msg(Me, "Cliente atualizado com sucesso.", "Informação")
                        LimpaCampos_AtivaControles()
                        Desativa_Campos()
                        toolStrip.AfterSuccessfulUpdate()
                    End If
                Else
                    MyModo.UniqueModo = MyModo.UniqueModoAnterior
                    toolStrip.ToolbarItemsState(MyModo.UniqueModoAnterior, True)
                End If
            End If

        ElseIf MyModo.UniqueModo = "ALTERAR" Then
            ModoAlterar()


        ElseIf MyModo.UniqueModo = "NOVO" Then
            LimpaCampos_AtivaControles()
            CarregaCargos()
            AlternarControle()
            If objCliente IsNot Nothing Then
                objCliente = Nothing
            End If
            ComboNome.Focus()

        ElseIf MyModo.UniqueModo = "PESQUISAR" Then
            If MyModo.UniqueModoAnterior = "REVERTER" Then
                ModoPesquisaPreenchido()
                Exit Sub
            End If
            ModoPesquisa()

        ElseIf MyModo.UniqueModo = "ANTERIOR" Then
            If ComboNome.SelectedIndex - 1 >= 0 Then
                ComboNome.SelectedIndex -= 1
            End If

        ElseIf MyModo.UniqueModo = "SEGUINTE" Then
            If ComboNome.SelectedIndex + 1 <> ComboNome.Items.Count Then
                ComboNome.SelectedIndex += 1
            End If


            'ElseIf MyModo.UniqueModo = "REVERTER" Then
            '    If Uteis.MsgBoxHelper.MsgTemCerteza(frmPrincipal, "Deseja desfazer as mudanças?", "Reverter") Then
            '        ToolStrip_ItemClicked()
            '    Else
            '        Exit Sub
            '    End If


        ElseIf MyModo.UniqueModo = "EXCLUIR" Then
            If DAOCliente.AtualizaCliente(GetClienteForOperation, resposta, True, codusuario) Then
                LimpaCampos_AtivaControles()
                Desativa_Campos()
                toolStrip.AfterSuccessfulDelete()
                objCliente = Nothing
            End If
            MsgBoxHelper.Msg(Me, resposta, "Exclusão")

        ElseIf MyModo.UniqueModo = "PADRÃO" Then
                LimpaCampos_AtivaControles()
                toolStrip.PagAberta_HabilitarBotoes()
                Desativa_Campos()
            End If

    End Sub

    Private Sub BuscaClientePorCodigo(ByVal codcliente As String)
        Dim resposta As String = ""
        Dim cliente = DAOCliente.GetCliente(Convert.ToInt32(codcliente), True, resposta)

        If IsNothing(cliente) Then
            Uteis.MsgBoxHelper.Alerta(Me, "Não foi possível buscar as informações do cliente.", "Erro")
            Exit Sub
        End If

        objCliente = cliente
        toolStrip.EstadoAlterarExcluir(True)
        PreencheCampos(cliente)
    End Sub

    Private Sub PreencheCampos(ByVal cliente As Cliente)
        Dim estado = LstEstados.Find(Function(e As EstadoUF) e.UF = cliente.ObjEndereco.UF)
        ComboNome.SelectedIndex = LstCliente.FindIndex(Function(v) v.CodCliente = cliente.CodCliente)
        TxtCEP.Text = cliente.ObjEndereco.CEP
        TxtCidade.Text = cliente.ObjEndereco.Cidade
        TxtComplemento.Text = cliente.ObjEndereco.Complemento
        TxtLogradouro.Text = cliente.ObjEndereco.Logradouro
        TxtNum.Text = cliente.ObjEndereco.NumeroEndereco
        TxtObs.Text = cliente.Descricao
        TxtBairro.Text = cliente.ObjEndereco.Bairro
        ComboEstado.SelectedItem = estado
        ComboEstado.Text = estado.Nome
        Dim cargo = LstCargos.Find(Function(c) c.CodCargo = cliente.CodCargo)
        If cargo IsNot Nothing Then
            ComboCargo.SelectedItem = cargo
            ComboCargo.Text = cargo.Nome
        Else
            ComboCargo.Text = String.Empty
            ComboCargo.SelectedIndex = -1
        End If
        TxtEmail.Text = cliente.Email
        TxtEmpresa.Text = cliente.Empresa
        TxtCelular.Text = cliente.Telefone
        DtPckNasc.Value = cliente.DatNasc
        ChkBoxAtivo.Checked = cliente.IsAtivo
    End Sub

    Private Sub ModoAlterar()
        GrpBoxEndereco.Enabled = True
        GrpBoxInfo.Enabled = True
        ControlsHelper.SetControlsEnabled(GrpBoxEndereco.Controls)
        ControlsHelper.SetControlsEnabled(GrpBoxInfo.Controls)
        ComboNome.Enabled = False
        DtPckNasc.Enabled = False
        CarregaCargos()
        If objCliente.CodCargo > 0 Then
            Dim cargo = LstCargos.First(Function(c) c.CodCargo = objCliente.CodCargo)
            ComboCargo.SelectedItem = cargo
            ComboCargo.Text = cargo.Nome
        End If
    End Sub

    Private Sub CarregaClientes()
        If Not MyModo.UniqueModo = "PESQUISAR" Then
            Exit Sub
        End If
        LstCliente.Clear()
        ComboNome.Items.Clear()

        Dim resposta As String = ""

        LstCliente = DAOCliente.GetCliente(True, resposta, True)

        If Not LstCliente.Count > 0 Then
            MsgBoxHelper.Alerta(Me, resposta, "Erro")
        Else
            ComboNome.BeginUpdate()
            ComboNome.Items.AddRange(LstCliente.ToArray)
            ComboNome.DisplayMember = "Nome"
            ComboNome.ValueMember = "CodCliente"
            ComboNome.EndUpdate()
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub ComboNome_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ComboNome.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub TxtNum_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNum.KeyPress
        If Not RegexValidation.NumEnderecoCaracteres(e.KeyChar.ToString) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.KeyChar = ""
        End If
    End Sub


    Private Sub ComboCargo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboCargo.SelectedIndexChanged
        If objCliente IsNot Nothing Then
            If ComboCargo.SelectedIndex > -1 Then
                If objCliente.CodCargo = LstCargos(ComboCargo.SelectedIndex).CodCargo Then
                    BtnConsCargo.Visible = False
                    Exit Sub
                End If
            End If
        End If
        Dim existe As Boolean
        If ComboCargo.Enabled Then
            If ComboCargo.Text <> String.Empty Then
                If DAOCliente.ChecaCargoCliente(LstCargos(ComboCargo.SelectedIndex).CodCargo, existe) Then
                    BtnConsCargo.Visible = True
                Else
                    BtnConsCargo.Visible = False
                End If
            End If
        End If
    End Sub

    Private Function GetClienteForOperation() As Cliente
        If Not ValidaCampos() Then
            Return Nothing
        End If

        Dim cliente As New Cliente
        If ComboNome.Text <> String.Empty Then
            cliente = objCliente
        End If

        cliente.Empresa = TxtEmpresa.Text
        If ComboCargo.Text <> String.Empty Then
            cliente.CodCargo = LstCargos.Find(Function(c) c Is ComboCargo.SelectedItem).CodCargo
        Else
            cliente.CodCargo = 0
        End If
        cliente.Telefone = Uteis.StringHelper.NumericOnly(TxtCelular.Text)
        cliente.Email = TxtEmail.Text
        cliente.Descricao = TxtObs.Text
        cliente.ObjEndereco.CEP = StringHelper.NumericOnly(TxtCEP.Text)
        cliente.ObjEndereco.Logradouro = TxtLogradouro.Text.ToUpper
        cliente.ObjEndereco.Bairro = TxtBairro.Text.ToUpper
        cliente.ObjEndereco.Cidade = TxtCidade.Text.ToUpper
        cliente.ObjEndereco.UF = LstEstados.Item(ComboEstado.SelectedIndex).UF
        cliente.ObjEndereco.Complemento = TxtComplemento.Text.ToUpper
        cliente.ObjEndereco.NumeroEndereco = TxtNum.Text
        cliente.IsAtivo = ChkBoxAtivo.Checked
        Return cliente
    End Function

    Private Sub ModoPesquisa()
        AlternarControle()
        LimpaCampos_AtivaControles()
        GrpBoxInfo.Enabled = True
        ControlsHelper.SetControlsDisabled(GrpBoxInfo.Controls)
        ControlsHelper.SetControlsDisabled(GrpBoxEndereco.Controls)
        ComboNome.Enabled = True
        CarregaClientes()
        CarregaCargos()
    End Sub

    Private Sub BtnConsCargo_Click(sender As System.Object, e As System.EventArgs) Handles BtnConsCargo.Click
        Dim frm As New Frm_Cliente_Cargo(frmPrincipal, LstCargos(ComboCargo.SelectedIndex).CodCargo)
        frm.ShowDialog()
    End Sub

    Private Function ValidaCampos() As Boolean

        If String.IsNullOrWhiteSpace(ComboNome.Text) Then
            MsgBoxHelper.Alerta(Me, "Nome precisa ser preenchido.", "Alerta", ComboNome)
            Return False
        ElseIf DtPckNasc.Value >= DateTime.Today Then
            MsgBoxHelper.Alerta(Me, "Data de Nascimento inválida.", "Alerta", DtPckNasc)
            Return False

        ElseIf Not Uteis.RegexValidation.IsTelefoneValid(StringHelper.NumericOnly(TxtCelular.Text)) Then
            MsgBoxHelper.Alerta(Me, "Telefone inválido.", "Alerta", TxtCelular)
            Return False

        ElseIf Not Uteis.RegexValidation.IsEmailValid(TxtEmail.Text) Then
            MsgBoxHelper.Alerta(Me, "E-mail inválido.", "Alerta", TxtEmail)
            Return False

        ElseIf Not String.IsNullOrWhiteSpace(ComboCargo.Text) AndAlso ComboCargo.SelectedItem Is Nothing Then
            MsgBoxHelper.Alerta(Me, "O cargo selecionado é inválido. É necessário selecionar um cargo da lista.", "Alerta", ComboCargo)
            ComboCargo.DroppedDown = True
            Return False

        ElseIf Not TxtCEP.MaskCompleted Then
            MsgBoxHelper.Alerta(Me, "CEP inválido.", "Alerta", TxtCEP)
            Return False

        ElseIf String.IsNullOrWhiteSpace(TxtLogradouro.Text) Then
            MsgBoxHelper.Alerta(Me, "Logradouro precisa ser preenchido.", "Alerta", TxtLogradouro)
            Return False

        ElseIf String.IsNullOrWhiteSpace(TxtNum.Text) Then
            MsgBoxHelper.Alerta(Me, "Número precisa ser preenchido.", "Alerta", TxtNum)
            Return False

        ElseIf String.IsNullOrWhiteSpace(TxtBairro.Text) Then
            MsgBoxHelper.Alerta(Me, "Bairro precisa ser preenchido.", "Alerta", TxtBairro)
            Return False

        ElseIf String.IsNullOrWhiteSpace(TxtCidade.Text) Then
            MsgBoxHelper.Alerta(Me, "Cidade precisa ser preenchida.", "Alerta", TxtCidade)
            Return False

        ElseIf ComboEstado.SelectedIndex = -1 Then
            MsgBoxHelper.Alerta(Me, "Estado precisa ser preenchido.", "Alerta", ComboEstado)
            ComboEstado.DroppedDown = True
            Return False

        End If
        Return True
    End Function

    Private Sub ComboCargo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ComboCargo.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub ComboCargo_TextUpdate(sender As System.Object, e As System.EventArgs) Handles ComboCargo.TextUpdate
        If ComboCargo.Text = String.Empty Then
            BtnConsCargo.Visible = False
        End If
    End Sub

    Private Sub ModoPesquisaPreenchido()
        PreencheCampos(objCliente)
        ControlsHelper.SetControlsDisabled(GrpBoxInfo.Controls)
        ControlsHelper.SetControlsDisabled(GrpBoxEndereco.Controls)
        ComboNome.Enabled = True
        toolStrip.EstadoAlterarExcluir(True)
    End Sub

End Class