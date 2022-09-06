Imports Entidades
Imports Uteis
Public Class Frm_Cargo

    Private frmPrincipal As Frm_Principal_MDI
    Private LstCargo As New List(Of Cargo)
    Private cargoCombo As Cargo
    Private MyModo As New UC_Toolstrip.UniqueModo
    Private DAOCargo As New DAO.DAO
    Private IsOperacaoPendente As Boolean

    Public Sub New(frm As Frm_Principal_MDI)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        frmPrincipal = frm
    End Sub

    Private Sub Frm_Cargo_EnabledChanged(sender As System.Object, e As System.EventArgs) Handles Me.EnabledChanged
        If Me.Enabled Then
            frmPrincipal.UC_Toolstrip1.ToolbarItemsState(MyModo.UniqueModo)
        End If
    End Sub

    Private Sub Frm_Cargo_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        DAOCargo.ReverterOuCommitar()
        RemoveHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
    End Sub

    Private Sub Frm_Cargo_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ControlsHelper.SetControlsDisabled(Me.Controls)
        AddHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
        MyModo.UniqueModo = "PADRÃO"
    End Sub

    Private Function InsereCargo() As Boolean
        Dim cargo As New Cargo
        cargo.Nome = Me.ComboNome.Text
        cargo.Descricao = Me.TxtDesc.Text.ToUpper
        cargo.IsAtivo = Me.ChkBoxAtivo.Checked
        cargo.IsVendedor = Me.ChkVendedor.Checked
        cargo.LoginCriacao = loginusuario

        Dim str As String = ""

        If Not cargo.IsValid(str) Then
            MsgBoxHelper.Erro(Me, str, "Erro de preenchimento")
            Return False
        End If

        If Not DAOCargo.InsereCargo(cargo, str) Then
            Uteis.MsgBoxHelper.Erro(Me, str, "Erro")
            Return False
        End If

        IsOperacaoPendente = True
        Return True

    End Function

    Private Sub CarregaCargos()
        ComboNome.Items.Clear()
        Dim resposta As String = ""

        LstCargo = DAOCargo.GetCargo(True)

        If Not LstCargo.Count > 0 Then
            MsgBoxHelper.Erro(Me, "O sistema não conseguiu buscar os cargos.", "Erro")
            Exit Sub
        Else
            ComboNome.Items.Add("")
            For Each cargo As Cargo In LstCargo
                ComboNome.BeginUpdate()
                ComboNome.Items.Add(cargo.Nome)
                ComboNome.EndUpdate()
            Next
            If MyModo.UniqueModo = "PESQUISAR" Then
                ComboNome.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub LimpaCampos_Ativa()
        ControlsHelper.SetTextsEmpty(GrpBoxCfg.Controls)
        ControlsHelper.SetTextsEmpty(GrpBoxInfo.Controls)
        ControlsHelper.SetControlsEnabled(Me.Controls)
    End Sub

    Private Sub ToolStrip_ItemClicked()
        If Not Me.Enabled Then
            Exit Sub
        End If

        Dim resposta As String = ""

        MyModo.UniqueModo = UC_Toolstrip.Modo

        If MyModo.UniqueModo = "NOVO" Then
            LimpaCampos_Ativa()


        ElseIf MyModo.UniqueModo = "SALVAR" Then
            If ComboNome.DropDownStyle = ComboBoxStyle.Simple AndAlso Not IsOperacaoPendente Then
                If InsereCargo() Then
                    Uteis.ControlsHelper.SetControlsDisabled(Me)
                    frmPrincipal.UC_Toolstrip1.AfterSuccessfulInsert()
                Else
                    frmPrincipal.UC_Toolstrip1.ToolbarItemsState("", False)
                End If
            Else
                CarregaCargos()
                If Not DAOCargo.AtualizaCargo(CargoObjForUpdate, resposta, False, loginusuario) Then
                    frmPrincipal.UC_Toolstrip1.ToolbarItemsState("", False)
                Else
                    Uteis.ControlsHelper.SetControlsDisabled(Me)
                    frmPrincipal.UC_Toolstrip1.AfterSuccessfulUpdate()
                    IsOperacaoPendente = True
                End If
            End If


        ElseIf MyModo.UniqueModo = "PESQUISAR" Then
            ModoPesquisar()
            CarregaCargos()
            AlternarControle()

        ElseIf MyModo.UniqueModo = "ALTERAR" Then
            Uteis.ControlsHelper.SetControlsEnabled(Me.Controls)
            ModoAlterar()


        ElseIf MyModo.UniqueModo = "REVERTER" Then
            If IsOperacaoPendente Then
                If Uteis.MsgBoxHelper.MsgTemCerteza(frmPrincipal, "Deseja reverter a operação?", "Reverter") Then
                    DAOCargo.ReverterOuCommitar(True)
                    IsOperacaoPendente = False
                End If
            End If
            LimpaCampos_Ativa()
            Uteis.ControlsHelper.SetControlsDisabled(Me)

        ElseIf MyModo.UniqueModo = "EXCLUIR" Then
            If Uteis.MsgBoxHelper.MsgTemCerteza(frmPrincipal, "Deseja excluir o item?", "Exclusão") Then
                If DAOCargo.AtualizaCargo(LstCargo(ComboNome.SelectedIndex - 1), "", True, loginusuario) Then
                    IsOperacaoPendente = True
                    LimpaCampos()
                    Uteis.ControlsHelper.SetControlsDisabled(Me)
                    frmPrincipal.UC_Toolstrip1.AfterSuccessfulDelete()
                End If
            Else
                Exit Sub
            End If
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
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub ComboNome_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ComboNome.SelectedIndexChanged
        If Not Uteis.StringHelper.IsNull(ComboNome.Text) Then
            BuscaCargoPorCodigo(LstCargo(ComboNome.SelectedIndex - 1).CodCargo)
        Else
            frmPrincipal.UC_Toolstrip1.EstadoAlterarExcluir(False)
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

        frmPrincipal.UC_Toolstrip1.EstadoAlterarExcluir(True)
        cargoCombo = cargo
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
        End If
    End Sub

    Private Function CargoObjForUpdate() As Cargo
        Dim cargo As New Cargo
        If ComboNome.Text <> String.Empty Then
            cargo = cargoCombo
        End If

        cargo.Descricao = TxtDesc.Text
        cargo.IsAtivo = ChkBoxAtivo.Checked
        Return cargo
    End Function

    Private Sub ModoAlterar()
        ControlsHelper.SetControlsEnabled(GrpBoxInfo.Controls)
        ControlsHelper.SetControlsEnabled(GrpBoxCfg.Controls)

        ComboNome.Enabled = False
        ChkVendedor.Enabled = False
    End Sub

    Private Sub ModoPesquisar()
        ControlsHelper.SetControlsEnabled(Me.Controls)

        TxtDesc.Enabled = False
        ChkVendedor.Enabled = False
        ChkBoxAtivo.Enabled = False
        Uteis.ControlsHelper.SetTextsEmpty(GrpBoxInfo.Controls)
    End Sub

End Class