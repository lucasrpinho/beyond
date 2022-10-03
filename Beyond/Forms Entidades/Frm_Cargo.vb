Imports Entidades
Imports Uteis
Public Class Frm_Cargo

    Private frmPrincipal As Frm_Principal_MDI
    Private LstCargo As New List(Of Cargo)
    Private MyModo As New UC_Toolstrip.UniqueModo
    Private DAOCargo As New DAO.DAO
    Private objCargo As Cargo
    Private toolStrip As UC_Toolstrip

    Public Sub New(frm As Frm_Principal_MDI)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        frmPrincipal = frm
        toolStrip = frmPrincipal.UC_Toolstrip1
    End Sub

    Private Sub Frm_Cargo_EnabledChanged(sender As System.Object, e As System.EventArgs) Handles Me.EnabledChanged
        If Me.Enabled Then
            toolStrip.ToolbarItemsState(MyModo.UniqueModo)
        End If
    End Sub

    Private Sub Frm_Cargo_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        RemoveHandler toolStrip.itemclick, AddressOf Me.ToolStrip_ItemClicked
    End Sub

    Private Sub Frm_Cargo_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Desativa_Campos()
        AddHandler toolStrip.itemclick, AddressOf Me.ToolStrip_ItemClicked
        MyModo.UniqueModo = "PADRÃO"
    End Sub

    Private Function InsereCargo() As Boolean
        If ComboNome.Text = String.Empty Then
            MsgBoxHelper.Alerta(Me, "Nome do cargo precisa ser preenchido", "Alerta", ComboNome)
            Return False
        End If

        Dim cargo As New Cargo
        cargo.Nome = LTrim(RTrim(Me.ComboNome.Text))
        cargo.Descricao = RTrim(Me.TxtDesc.Text.ToUpper)
        cargo.IsAtivo = Me.ChkBoxAtivo.Checked
        cargo.IsVendedor = Me.ChkVendedor.Checked

        Dim str As String = ""

        If Not cargo.IsValid(str) Then
            MsgBoxHelper.Alerta(Me, str, "Erro de preenchimento")
            Return False
        End If

        If Not DAOCargo.InsereCargo(cargo, str, codusuario) Then
            Uteis.MsgBoxHelper.Alerta(Me, str, "Erro")
            Return False
        End If

        Dim dlgSucc As New Dlg_Success
        dlgSucc.ShowDialog()

        Return True
    End Function

    Private Sub CarregaCargos()
        If Not MyModo.UniqueModo = "PESQUISAR" Then
            Exit Sub
        End If
        ComboNome.Items.Clear()
        Dim resposta As String = ""

        LstCargo = DAOCargo.GetCargo(True, True)

        If Not LstCargo.Count > 0 Then
            MsgBoxHelper.Alerta(Me, "O sistema não encontrou cargos.", "Sem resultados")
            Exit Sub
        Else
            ComboNome.BeginUpdate()
            ComboNome.Items.AddRange(LstCargo.ToArray)
            ComboNome.DisplayMember = "Nome"
            ComboNome.ValueMember = "CodCargo"
            ComboNome.EndUpdate()
        End If
    End Sub

    Private Sub LimpaCampos_Ativa()
        ControlsHelper.SetTextsEmpty(GrpBoxCfg.Controls)
        ControlsHelper.SetTextsEmpty(GrpBoxInfo.Controls)
        ControlsHelper.SetControlsEnabled(GrpBoxCfg.Controls)
        ControlsHelper.SetControlsEnabled(GrpBoxInfo.Controls)
        AlternarControle()
        ComboNome.AutoCompleteMode = AutoCompleteMode.None
    End Sub

    Private Sub Desativa_Campos()
        ControlsHelper.SetControlsDisabled(GrpBoxCfg.Controls)
        ControlsHelper.SetControlsDisabled(GrpBoxInfo.Controls)
    End Sub

    Private Sub ToolStrip_ItemClicked()
        If Not Me.Enabled Then
            Exit Sub
        End If

        Dim resposta As String = ""

        MyModo.UniqueModoAnterior = UC_Toolstrip.ModoAnterior
        MyModo.UniqueModo = UC_Toolstrip.Modo

        If MyModo.UniqueModo = "NOVO" Then
            LimpaCampos_Ativa()
            ComboNome.Focus()


        ElseIf MyModo.UniqueModo = "SALVAR" Then
            If ComboNome.DropDownStyle = ComboBoxStyle.Simple AndAlso MyModo.UniqueModoAnterior = "NOVO" Then
                If InsereCargo() Then
                    LimpaCampos()
                    Desativa_Campos()
                    toolStrip.AfterSuccessfulInsert()
                Else
                    toolStrip.ToolbarItemsState("", False)
                End If
            Else
                If Uteis.MsgBoxHelper.MsgTemCerteza(Me, "Tem certeza que deseja modificar o registro?", "Alteração") Then
                    If Not DAOCargo.AtualizaCargo(CargoObjForUpdate, resposta, False, codusuario) Then
                        toolStrip.ToolbarItemsState("", False)
                        MsgBoxHelper.Alerta(Me, resposta, "Erro")
                    Else
                        LimpaCampos()
                        Desativa_Campos()
                        toolStrip.AfterSuccessfulUpdate()
                    End If
                Else
                    toolStrip.ToolbarItemsState("", False)
                End If
            End If


        ElseIf MyModo.UniqueModo = "PESQUISAR" Then
            ModoPesquisar()
            If MyModo.UniqueModoAnterior = "REVERTER" Then
                ComboNome.SelectedIndex = LstCargo.FindIndex(Function(c As Cargo) c.CodCargo = objCargo.CodCargo)
            End If

        ElseIf MyModo.UniqueModo = "ANTERIOR" Then
            If ComboNome.SelectedIndex - 1 >= 0 Then
                ComboNome.SelectedIndex -= 1
            End If

        ElseIf MyModo.UniqueModo = "SEGUINTE" Then
            If ComboNome.SelectedIndex + 1 <> ComboNome.Items.Count Then
                ComboNome.SelectedIndex += 1
            End If

        ElseIf MyModo.UniqueModo = "ALTERAR" Then
            CarregaCargos()
            ModoAlterar()


        ElseIf MyModo.UniqueModo = "REVERTER" Then
            If Uteis.MsgBoxHelper.MsgTemCerteza(frmPrincipal, "Deseja desfazer as mudanças?", "Reverter") Then
                ToolStrip_ItemClicked()
            Else
                Exit Sub
            End If

        ElseIf MyModo.UniqueModo = "EXCLUIR" Then
            If Uteis.MsgBoxHelper.MsgTemCerteza(frmPrincipal, "Deseja excluir o item?", "Exclusão") Then
                If DAOCargo.AtualizaCargo(CargoObjForUpdate, resposta, True, codusuario) Then
                    LimpaCampos()
                    Desativa_Campos()
                    toolStrip.AfterSuccessfulDelete()
                End If
                MsgBoxHelper.Msg(Me, resposta, "Informação")
            Else
                toolStrip.ToolbarItemsState("", False, True)
            End If

        ElseIf MyModo.UniqueModo = "PADRÃO" Then
            LimpaCampos_Ativa()
            toolStrip.PagAberta_HabilitarBotoes()
            Desativa_Campos()
        End If
    End Sub

    Private Sub AlternarControle()
        If MyModo.UniqueModo = "PESQUISAR" Then
            ComboNome.DropDownStyle = ComboBoxStyle.DropDown
        ElseIf MyModo.UniqueModo = "NOVO" Then
            ComboNome.DropDownStyle = ComboBoxStyle.Simple
        End If
    End Sub

    Private Sub LimpaCampos()
        ControlsHelper.SetTextsEmpty(GrpBoxCfg.Controls)
        ControlsHelper.SetTextsEmpty(GrpBoxInfo.Controls)
        ChkVendedor.Checked = False
        ChkBoxAtivo.Checked = True
        LstCargo.Clear()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub ComboNome_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ComboNome.SelectedIndexChanged
        If Not Uteis.StringHelper.IsNull(ComboNome.Text) Then
            If objCargo IsNot Nothing Then
                objCargo = Nothing
            End If
            BuscaCargoPorCodigo(LstCargo(ComboNome.SelectedIndex).CodCargo)
        Else
            toolStrip.EstadoAlterarExcluir(False)
            LimpaCampos()
        End If
    End Sub

    Private Sub BuscaCargoPorCodigo(ByVal codcargo As String)
        Dim resposta As String = ""
        Dim cargo = DAOCargo.GetCargo(codcargo)

        If IsNothing(cargo) Then
            Uteis.MsgBoxHelper.Erro(Me, resposta, "Erro")
            Exit Sub
        End If

        toolStrip.EstadoAlterarExcluir(True)
        objCargo = cargo
        PreencheCampos(cargo)
    End Sub

    Private Sub PreencheCampos(cargo As Cargo)
        ComboNome.Text = cargo.Nome
        TxtDesc.Text = cargo.Descricao
        ChkBoxAtivo.Checked = cargo.IsAtivo
        ChkVendedor.Checked = cargo.IsVendedor
    End Sub

    Private Sub ComboNome_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ComboNome.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        ElseIf e.KeyChar = "´" Or e.KeyChar = "^" Or e.KeyChar = "~" Then
            e.KeyChar = ""
        End If
    End Sub

    Private Function CargoObjForUpdate() As Cargo
        Dim cargo As New Cargo
        If ComboNome.Text <> String.Empty Then
            cargo = objCargo
        End If

        cargo.Descricao = TxtDesc.Text
        cargo.IsAtivo = ChkBoxAtivo.Checked
        Return cargo
    End Function

    Private Sub ModoAlterar()
        ControlsHelper.SetControlsEnabled(Me.Controls)
        ControlsHelper.SetControlsEnabled(GrpBoxInfo.Controls)
        ControlsHelper.SetControlsEnabled(GrpBoxCfg.Controls)

        ComboNome.Enabled = False
        ChkVendedor.Enabled = False
    End Sub

    Private Sub ModoPesquisar()
        ControlsHelper.SetControlsEnabled(Me.Controls)
        ControlsHelper.SetControlsEnabled(GrpBoxInfo.Controls)
        ComboNome.AutoCompleteMode = AutoCompleteMode.Suggest
        TxtDesc.Enabled = False
        ChkVendedor.Enabled = False
        ChkBoxAtivo.Enabled = False
        Uteis.ControlsHelper.SetTextsEmpty(GrpBoxInfo.Controls)
        AlternarControle()
        CarregaCargos()
    End Sub

    Private Sub TxtDesc_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDesc.KeyPress
        If e.KeyChar = "´" Or e.KeyChar = "^" Or e.KeyChar = "~" Then
            e.KeyChar = ""
        End If
    End Sub
End Class