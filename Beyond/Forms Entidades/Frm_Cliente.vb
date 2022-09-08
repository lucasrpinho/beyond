﻿Imports Entidades
Imports Uteis

Public Class Frm_Cliente

    Private frmPrincipal As Frm_Principal_MDI
    Private LstCargos As New List(Of Cargo)
    Private LstEstados As New List(Of EstadoUF)
    Private LstCliente As New List(Of Cliente)
    Private Endereco As Endereco
    Private DAOCliente As New DAO.DAO
    Private MyModo As New UC_Toolstrip.UniqueModo
    Private IsOperacaoActive As Boolean = False


    Public Sub New(frm As Frm_Principal_MDI)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        frmPrincipal = frm
    End Sub

    Private Sub Frm_Cliente_EnabledChanged(sender As Object, e As System.EventArgs) Handles Me.EnabledChanged
        If Me.Enabled Then
            frmPrincipal.UC_Toolstrip1.ToolbarItemsState(MyModo.UniqueModo)
        End If
    End Sub

    Private Sub Frm_Cliente_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        DAOCliente.ReverterOuCommitar()
        RemoveHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
    End Sub

    Private Sub Frm_Cliente_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Uteis.ControlsHelper.SetControlsDisabled(Me)
        AddHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
        CarregaCargos()
        CarregaEstados()
        MyModo.UniqueModo = "PADRÃO"
    End Sub

    Private Sub AlternarControle()
        If MyModo.UniqueModo = "PESQUISAR" Then
            ComboNome.DropDownStyle = ComboBoxStyle.DropDown
        ElseIf MyModo.UniqueModo = "NOVO" Then
            ComboNome.DropDownStyle = ComboBoxStyle.Simple
        End If
    End Sub

    Private Sub ComboNome_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboNome.SelectedIndexChanged
        If Not Uteis.StringHelper.IsNull(ComboNome.Text) Then
            BuscaClientePorCodigo(LstCliente(ComboNome.SelectedIndex).CodCliente)
        Else
            Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxEndereco.Controls)
            Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxInfo.Controls)
        End If
    End Sub

    Private Sub LimpaCampos_AtivaControles()
        ControlsHelper.SetControlsEnabled(Me.Controls)
        Uteis.ControlsHelper.SetControlsEnabled(GrpBoxEndereco.Controls)
        ControlsHelper.SetControlsEnabled(GrpBoxInfo.Controls)
        Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxEndereco.Controls)
        Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxInfo.Controls)
        DtPckNasc.Value = Date.Now
    End Sub

    Private Function Insere() As Boolean

        If Not Uteis.RegexValidation.IsEmailValid(TxtEmail.Text) Then
            Uteis.MsgBoxHelper.CustomTooltip(Me, TxtEmail, "E-mail inválido.", "Alerta de preenchimento")
            Return False
        End If

        If Not Uteis.RegexValidation.IsTelefoneValid(StringHelper.NumericOnly(TxtCelular.Text)) Then
            Uteis.MsgBoxHelper.CustomTooltip(Me, TxtCelular, "Telefone inválido.", "Alerta de preenchimento")
            Return False
        End If

        If TxtNum.Text = String.Empty Then
            Uteis.MsgBoxHelper.CustomTooltip(Me, TxtNum, "Número vazio.", "Alerta de preenchimento")
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
        cliente.ObjEndereco.NumeroEndereco = StringHelper.NumericOnly(TxtNum.Text)

        cliente.Descricao = TxtObs.Text.ToUpper
        cliente.LoginCriacao = loginusuario
        cliente.IsAtivo = ChkBoxAtivo.Checked

        Dim strError As String = ""

        If Not cliente.IsValid(strError) Then
            MsgBoxHelper.Alerta(Me, strError, "Erro de preenchimento")
            Return False
        End If

        Dim resposta As String = ""

        If Not DAOCliente.InsereCliente(cliente, resposta) Then
            Uteis.MsgBoxHelper.Alerta(Me, resposta, "Erro")
            Return False
        End If

        IsOperacaoActive = True
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

            ' Soma com 1 pois o combobox contém um item vazio
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

        MyModo.UniqueModo = MyModo.UniqueModo

        Dim resposta As String = ""

        MyModo.UniqueModo = UC_Toolstrip.Modo

        If MyModo.UniqueModo = "SALVAR" Then
            If ComboNome.DropDownStyle = ComboBoxStyle.Simple Then
                If Insere() Then
                    Uteis.ControlsHelper.SetControlsDisabled(Me)
                    frmPrincipal.UC_Toolstrip1.AfterSuccessfulInsert()
                Else
                    frmPrincipal.UC_Toolstrip1.ToolbarItemsState("", False)
                End If
            Else
                If Uteis.MsgBoxHelper.MsgTemCerteza(Me, "O registro será modificado. Deseja continuar?", "Alterar") Then
                    CarregaClientes()
                    If Not DAOCliente.AtualizaCliente(GetClienteForOperation, resposta, False, loginusuario) Then
                        frmPrincipal.UC_Toolstrip1.ToolbarItemsState("", False)
                    Else
                        Uteis.ControlsHelper.SetControlsDisabled(Me)
                        frmPrincipal.UC_Toolstrip1.AfterSuccessfulUpdate()
                        IsOperacaoActive = True
                    End If
                End If
            End If

        ElseIf MyModo.UniqueModo = "ALTERAR" Then
            GrpBoxEndereco.Enabled = True
            ControlsHelper.SetControlsEnabled(GrpBoxEndereco.Controls)
            ControlsHelper.SetControlsEnabled(GrpBoxInfo.Controls)
            ComboNome.Enabled = False
            DtPckNasc.Enabled = False


        ElseIf MyModo.UniqueModo = "NOVO" Then
            LimpaCampos_AtivaControles()
            AlternarControle()

        ElseIf MyModo.UniqueModo = "PESQUISAR" Then
            ModoPesquisa()


        ElseIf MyModo.UniqueModo = "REVERTER" Then
            If IsOperacaoActive Then
                If Uteis.MsgBoxHelper.MsgTemCerteza(frmPrincipal, "Deseja reverter a operação?", "Reverter") Then
                    DAOCliente.ReverterOuCommitar(True)
                    IsOperacaoActive = False
                End If
            End If
            LimpaCampos_AtivaControles()
            Uteis.ControlsHelper.SetControlsDisabled(Me)


        ElseIf MyModo.UniqueModo = "EXCLUIR" Then
            If Uteis.MsgBoxHelper.MsgTemCerteza(frmPrincipal, "Deseja excluir o item?", "Exclusão") Then
                If DAOCliente.AtualizaCliente(GetClienteForOperation, "", True, loginusuario) Then
                    IsOperacaoActive = True
                    LimpaCampos_AtivaControles()
                    ControlsHelper.SetControlsDisabled(Me)
                    frmPrincipal.UC_Toolstrip1.AfterSuccessfulDelete()
                End If
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub BuscaClientePorCodigo(ByVal codcliente As String)
        Dim resposta As String = ""
        Dim cliente = DAOCliente.GetCliente(codcliente, True, resposta)

        If IsNothing(cliente) Then
            Uteis.MsgBoxHelper.Alerta(Me, resposta, "Erro")
            Exit Sub
        End If

        frmPrincipal.UC_Toolstrip1.EstadoAlterarExcluir(True)
        PreencheCampos(cliente)
    End Sub

    Private Sub PreencheCampos(ByVal cliente As Cliente)
        ComboNome.SelectedIndex = LstCliente.FindIndex(Function(v) v.CodCliente = cliente.CodCliente)
        TxtCEP.Text = cliente.ObjEndereco.CEP
        TxtCidade.Text = cliente.ObjEndereco.Cidade
        TxtComplemento.Text = cliente.ObjEndereco.Complemento
        TxtLogradouro.Text = cliente.ObjEndereco.Logradouro
        TxtNum.Text = cliente.ObjEndereco.NumeroEndereco
        TxtObs.Text = cliente.Descricao
        ComboEstado.SelectedIndex = LstEstados.FindIndex(Function(e) e.UF = cliente.ObjEndereco.UF)
        ComboCargo.SelectedIndex = LstCargos.FindIndex(Function(c) c.CodCargo = cliente.CodCargo)
        TxtEmail.Text = cliente.Email
        TxtEmpresa.Text = cliente.Empresa
        TxtCelular.Text = cliente.Telefone
        DtPckNasc.Value = cliente.DatNasc
    End Sub

    Private Sub CarregaClientes()
        If Not MyModo.UniqueModo = "PESQUISAR" Then
            Exit Sub
        End If
        LstCliente.Clear()
        ComboNome.Items.Clear()

        Dim resposta As String = ""

        LstCliente = DAOCliente.GetCliente(True, resposta)

        If Not LstCliente.Count > 0 Then
            MsgBoxHelper.Alerta(Me, resposta, "Erro")
        Else
            ComboNome.BeginUpdate()
            ComboNome.Items.AddRange(LstCliente.ToArray)
            ComboNome.DisplayMember = "Nome"
            ComboNome.ValueMember = "CodCliente"
            If MyModo.UniqueModo = "PESQUISAR" Then
                ComboNome.SelectedIndex = 0
            End If
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
        If Char.IsPunctuation(e.KeyChar) Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub BtnConsCargo_Click(sender As System.Object, e As System.EventArgs) Handles BtnConsCargo.Click
        Dim frm As New Frm_Cliente_Cargo(frmPrincipal, LstCargos(ComboCargo.SelectedIndex).CodCargo)
        frm.ShowDialog()
    End Sub

    Private Sub ComboCargo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboCargo.SelectedIndexChanged
        Dim existe As Boolean
        If ComboCargo.Enabled Then
            If ComboCargo.Text <> String.Empty Then
                If DAOCliente.ChecaCargoCliente(LstCargos(ComboCargo.SelectedIndex).CodCargo, existe) Then
                    MsgBoxHelper.CustomTooltip(GrpBoxInfo, ComboCargo, "Outro cliente já possui esse cargo.", "Alerta")
                    BtnConsCargo.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Function GetClienteForOperation() As Cliente
        Dim cliente As New Cliente
        If ComboNome.Text <> String.Empty Then
            cliente = LstCliente(ComboNome.SelectedIndex)
        End If
        cliente.Empresa = TxtEmpresa.Text
        cliente.CodCargo = LstCargos(ComboCargo.SelectedIndex).CodCargo
        cliente.Telefone = Uteis.StringHelper.NumericOnly(TxtCelular.Text)
        cliente.Email = TxtEmail.Text
        cliente.Descricao = TxtObs.Text
        cliente.ObjEndereco.CEP = StringHelper.NumericOnly(TxtCEP.Text)
        cliente.ObjEndereco.Logradouro = TxtLogradouro.Text.ToUpper
        cliente.ObjEndereco.Bairro = TxtBairro.Text.ToUpper
        cliente.ObjEndereco.Cidade = TxtCidade.Text.ToUpper
        cliente.ObjEndereco.UF = LstEstados.Item(ComboEstado.SelectedIndex).UF
        cliente.ObjEndereco.Complemento = TxtComplemento.Text.ToUpper
        cliente.ObjEndereco.NumeroEndereco = Convert.ToInt16(TxtNum.Text)
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
    End Sub
End Class