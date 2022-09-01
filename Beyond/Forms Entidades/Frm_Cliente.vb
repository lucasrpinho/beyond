Imports Entidades
Imports Uteis

Public Class Frm_Cliente

    Private frmPrincipal As Frm_Principal_MDI
    Private LstCargos As New List(Of Cargo)
    Private LstEstados As New List(Of EstadoUF)
    Private LstCliente As New List(Of Cliente)
    Private Endereco As Endereco


    Public Sub New(frm As Frm_Principal_MDI)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        frmPrincipal = frm
    End Sub

    Private Sub Frm_Cliente_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If frmPrincipal.StateTransaction = Uteis.SYSConsts.PENDENTE Then
            Uteis.MsgBoxHelper.AlertaTransacao(Me, frmPrincipal.UC_Toolstrip1.ToolStrip1)
            e.Cancel = True
            Exit Sub
        End If
        RemoveHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
    End Sub

    Private Sub Frm_Cliente_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Uteis.ControlsHelper.SetControlsDisabled(Me)
        AddHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
        CarregaCargos()
        CarregaEstados()
    End Sub

    Private Sub AlternarControle()
        If UC_Toolstrip.Modo = "PROCURAR" Then
            ComboNome.DropDownStyle = ComboBoxStyle.DropDown
        ElseIf UC_Toolstrip.Modo = "NOVO" Then
            ComboNome.DropDownStyle = ComboBoxStyle.Simple
        End If
    End Sub

    Private Sub ComboNome_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboNome.SelectedIndexChanged
        If Not Uteis.StringHelper.IsNull(ComboNome.Text) Then
            BuscaClientePorCodigo(LstCliente(ComboNome.SelectedIndex - 1).CodCliente)
        Else
            Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxEndereco.Controls)
            Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxInfo.Controls)
        End If
    End Sub

    Private Sub LimpaCampos_AtivaControles()
        Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxEndereco.Controls)
        Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxInfo.Controls)
        Uteis.ControlsHelper.SetControlsEnabled(Me.Controls)
    End Sub

    Private Sub Insere()
        Dim cliente As New Cliente

        cliente.CodCargo = LstCargos(ComboCargo.SelectedIndex).CodCargo
        cliente.Nome = ComboNome.Text.ToUpper
        cliente.CPF = StringHelper.NumericOnly(TxtCPF.Text)
        cliente.Empresa = TxtEmpresa.Text.ToUpper
        cliente.Telefone = StringHelper.NumericOnly(TxtCelular.Text)
        cliente.Email = TxtEmail.Text.ToUpper

        cliente.ObjEndereco = New Endereco()
        cliente.ObjEndereco.CEP = StringHelper.NumericOnly(TxtCEP.Text)
        cliente.ObjEndereco.Logradouro = TxtLogradouro.Text.ToUpper
        cliente.ObjEndereco.Bairro = TxtBairro.Text.ToUpper
        cliente.ObjEndereco.Cidade = TxtCidade.Text.ToUpper
        cliente.ObjEndereco.UF = LstEstados.Item(ComboEstado.SelectedIndex - 1).UF
        cliente.ObjEndereco.Complemento = TxtComplemento.Text.ToUpper
        cliente.ObjEndereco.NumeroEndereco = Convert.ToInt16(TxtNum.Text)

        cliente.Descricao = TxtObs.Text.ToUpper
        cliente.LoginCriacao = loginusuario
        cliente.IsAtivo = ChkBoxAtivo.Checked

        Dim strError As String = ""

        If Not cliente.IsValid(strError) Then
            MsgBoxHelper.Erro(Me, strError, "Erro de preenchimento")
            Exit Sub
        End If

        If Not StringHelper.IsCpf(cliente.CPF) Then
            MsgBoxHelper.Erro(Me, "CPF inválido", "Erro de preenchimento")
            Exit Sub
        End If

        If Not Uteis.RegexValidation.IsEmailValid(cliente.Email) Then
            Uteis.MsgBoxHelper.CustomTooltip(Me, TxtEmail, "E-mail inválido", "Erro de preenchimento")
            Exit Sub
        End If

        If Not Uteis.RegexValidation.IsTelefoneValid(cliente.Telefone) Then
            Uteis.MsgBoxHelper.CustomTooltip(Me, TxtCelular, "Telefone inválido", "Erro de preenchimento")
            Exit Sub
        End If

        Dim resposta As String = ""

        If Not DAO.DAO.InsereCliente(cliente, resposta) Then
            Uteis.MsgBoxHelper.Erro(Me, resposta, "Erro")
        Else
            frmPrincipal.StateTransaction = Uteis.SYSConsts.PENDENTE
            'Uteis.Controls.SetTextsEmpty(Me)
            Uteis.ControlsHelper.ToolBarTransactionOpen(frmPrincipal.UC_Toolstrip1.ToolStrip1)
            Uteis.ControlsHelper.SetControlsDisabled(Me)
        End If
    End Sub

    Private Sub CarregaCargos()
        LstCargos.Clear()
        ComboCargo.Items.Clear()

        LstCargos = DAO.DAO.GetCargo(True)

        If Not LstCargos.Count > 0 Then
            MsgBoxHelper.Erro(Me, "O sistema não conseguiu buscar os cargos", "Erro")
            Exit Sub
        End If

        ComboCargo.BeginUpdate()
        For I As Integer = 0 To LstCargos.Count - 1
            ComboCargo.Items.Add(LstCargos(I).Nome)
        Next
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

            ' Soma com 1 pois o combobox contém um item vazio
            ComboEstado.SelectedIndex = LstEstados.FindIndex(Function(e As EstadoUF) e.UF = Endereco.UF) + 1
        End If
    End Sub

    Private Sub CarregaEstados()
        Dim resposta As String = ""

        LstEstados.Clear()
        ComboEstado.Items.Clear()

        LstEstados = DAO.DAO.GetEstados(resposta)

        If Not LstEstados.Count > 0 Then
            MsgBoxHelper.Erro(Me, resposta, "UF vazio")
        Else
            ComboEstado.BeginUpdate()
            ComboEstado.Items.Add("")
            For Each estado As EstadoUF In LstEstados
                ComboEstado.Items.Add(estado.Nome)
            Next
            ComboEstado.EndUpdate()
        End If
    End Sub

    Private Sub ToolStrip_ItemClicked()
        If Not Me.Enabled Then
            Exit Sub
        End If


        If UC_Toolstrip.Modo = "SALVAR" Then
            Insere()


        ElseIf UC_Toolstrip.Modo = "ATUALIZAR" Then
            If Uteis.MsgBoxHelper.MsgTemCerteza(Me, "O registro será modificado. Deseja continuar?", "Atualizar") Then
                If DAO.DAO.AtualizaCliente(LstCliente(ComboNome.SelectedIndex - 1), "", False, loginusuario) Then
                    ParaRemocaoEAlteracao()
                End If
            Else
                Exit Sub
            End If


        ElseIf UC_Toolstrip.Modo = "PROCURAR" Or UC_Toolstrip.Modo = "NOVO" Then
            ParaPesquisaEConfirmacao()


        ElseIf UC_Toolstrip.Modo = "CONFIRMAR" Then
            If frmPrincipal.StateTransaction = Uteis.SYSConsts.PENDENTE Then
                DAO.DAO.ConfirmarOuReverter(True)
                ParaPesquisaEConfirmacao()
                frmPrincipal.StateTransaction = Uteis.SYSConsts.FINALIZADO
            End If


        ElseIf UC_Toolstrip.Modo = "ROLLBACK" Then
            If frmPrincipal.StateTransaction = Uteis.SYSConsts.PENDENTE Then
                If Uteis.MsgBoxHelper.MsgTemCerteza(frmPrincipal, "Deseja reverter a operação?", "Reverter") Then
                    DAO.DAO.ConfirmarOuReverter(False)
                    Uteis.ControlsHelper.SetControlsDisabled(Me)
                    LimpaCampos_AtivaControles()
                    frmPrincipal.StateTransaction = Uteis.SYSConsts.FINALIZADO
                Else
                    Exit Sub
                End If
            End If


        ElseIf UC_Toolstrip.Modo = "DELETAR" Then
            If ComboNome.DropDownStyle = ComboBoxStyle.Simple Then
                Exit Sub
            End If
            If Uteis.MsgBoxHelper.MsgTemCerteza(frmPrincipal, "Deseja deletar o item?", "Deletar") Then
                If DAO.DAO.AtualizaCliente(LstCliente(ComboNome.SelectedIndex - 1), _
                        "", True, loginusuario) Then
                    ParaRemocaoEAlteracao()
                End If
            Else
                Exit Sub
            End If


        ElseIf UC_Toolstrip.Modo = "LIMPAR" Then
            LimpaCampos_AtivaControles()
        End If

        AlternarControle()
        If frmPrincipal.StateTransaction Then
            Uteis.ControlsHelper.EnableAllToolBarItens(frmPrincipal.UC_Toolstrip1.ToolStrip1)
        End If
    End Sub

    Private Sub BuscaClientePorCodigo(ByVal codcliente As String)
        Dim resposta As String = ""
        Dim cliente = DAO.DAO.GetCliente(codcliente, True, resposta)

        If IsNothing(cliente) Then
            Uteis.MsgBoxHelper.Erro(Me, resposta, "Erro")
            Exit Sub
        End If

        PreencheCampos(cliente)
    End Sub

    Private Sub PreencheCampos(ByVal cliente As Cliente)
        ComboNome.SelectedIndex = LstCliente.FindIndex(Function(v) v.CodCliente = cliente.CodCliente) + 1
        TxtCEP.Text = cliente.ObjEndereco.CEP
        TxtCidade.Text = cliente.ObjEndereco.Cidade
        TxtComplemento.Text = cliente.ObjEndereco.Complemento
        TxtLogradouro.Text = cliente.ObjEndereco.Logradouro
        TxtNum.Text = cliente.ObjEndereco.NumeroEndereco
        TxtObs.Text = cliente.Descricao
        ComboEstado.SelectedIndex = LstEstados.FindIndex(Function(e) e.UF = cliente.ObjEndereco.UF) + 1
        ComboCargo.SelectedIndex = LstCargos.FindIndex(Function(c) c.CodCargo = cliente.CodCargo)
        TxtEmail.Text = cliente.Email
        TxtEmpresa.Text = cliente.Empresa
        TxtCelular.Text = cliente.Telefone
        TxtCPF.Text = cliente.CPF
    End Sub

    Private Sub CarregaClientes()
        If Not UC_Toolstrip.Modo = "PROCURAR" Then
            Exit Sub
        End If
        LstCliente.Clear()
        ComboNome.Items.Clear()

        Dim resposta As String = ""

        LstCliente = DAO.DAO.GetCliente(True, resposta)

        If Not LstCliente.Count > 0 Then
            MsgBoxHelper.Erro(Me, resposta, "Erro")
        Else
            ComboNome.BeginUpdate()
            ComboNome.Items.Add(String.Empty)
            For Each cliente As Cliente In LstCliente
                ComboNome.Items.Add(cliente.Nome)
            Next
            ComboNome.SelectedIndex = 0
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
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub ParaPesquisaEConfirmacao()
        AlternarControle()
        LimpaCampos_AtivaControles()
        CarregaClientes()
    End Sub

    Private Sub ParaRemocaoEAlteracao()
        frmPrincipal.StateTransaction = Uteis.SYSConsts.PENDENTE
        Uteis.ControlsHelper.SetControlsDisabled(Me)
        Uteis.ControlsHelper.ToolBarTransactionOpen(frmPrincipal.UC_Toolstrip1.ToolStrip1)
    End Sub

    Private Sub BtnConsCargo_Click(sender As System.Object, e As System.EventArgs) Handles BtnConsCargo.Click
        Dim frm As New Frm_Cliente_Cargo(frmPrincipal, LstCargos(ComboCargo.SelectedIndex).CodCargo)
        frm.ShowDialog()
    End Sub

    Private Sub ComboCargo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboCargo.SelectedIndexChanged
        Dim existe As Boolean
        If ComboCargo.Text <> String.Empty Then
            If DAO.DAO.ChecaCargoCliente(LstCargos(ComboCargo.SelectedIndex).CodCargo, existe) Then
                MsgBoxHelper.CustomTooltip(GrpBoxInfo, ComboCargo, "Outro cliente já possui esse cargo", "Alerta")
                BtnConsCargo.Enabled = True
            End If
        End If
    End Sub
End Class