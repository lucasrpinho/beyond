Imports Entidades
Imports Uteis
Public Class Frm_Cargo

    Private frmPrincipal As Frm_Principal_MDI
    Private LstCargo As New List(Of Cargo)

    Public Sub New(frm As Frm_Principal_MDI)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        frmPrincipal = frm
    End Sub

    Private Sub Frm_Cargo_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        RemoveHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
        Me.Dispose(True)
    End Sub

    Private Sub Frm_Cargo_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ControlsHelper.SetControlsDisabled(Me)
        AddHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
    End Sub

    Private Sub InsereCargo()
        Dim cargo As New Cargo
        cargo.Nome = Me.ComboNome.Text
        cargo.Descricao = Me.TxtDesc.Text.ToUpper
        cargo.IsAtivo = Me.ChkBoxAtivo.Checked
        cargo.IsVendedor = Me.ChkVendedor.Checked
        cargo.LoginCriacao = loginusuario

        Dim str As String = ""

        If Not cargo.IsValid(str) Then
            MsgBoxHelper.Erro(Me, str, "Erro de preenchimento")
            Exit Sub
        End If

        If Not DAO.DAO.InsereCargo(cargo, str) Then
            Uteis.MsgBoxHelper.Erro(Me, str, "Erro")
        Else
            frmPrincipal.StateTransaction = Uteis.SYSConsts.PENDENTE
            'Uteis.Controls.SetTextsEmpty(Me)
            Uteis.ControlsHelper.ToolBarTransactionOpen(frmPrincipal.UC_Toolstrip1.ToolStrip1)
            Uteis.ControlsHelper.SetControlsDisabled(Me)
        End If
    End Sub

    Private Sub CarregaCargos()
        ComboNome.Items.Clear()
        Dim resposta As String = ""

        LstCargo = DAO.DAO.GetCargo(True)

        If Not LstCargo.Count > 0 Then
            MsgBoxHelper.Erro(Me, "O sistema não conseguiu buscar os cargos", "Erro")
            Exit Sub
        Else
            ComboNome.Items.Add("")
            For Each cargo As Cargo In LstCargo
                ComboNome.BeginUpdate()
                ComboNome.Items.Add(cargo.Nome)
                ComboNome.EndUpdate()
            Next
            ComboNome.SelectedIndex = 0
        End If
    End Sub

    Private Sub LimpaCampos_Ativa()
        ControlsHelper.SetTextsEmpty(GrpBoxCfg.Controls)
        ControlsHelper.SetTextsEmpty(GrpBoxInfo.Controls)
        ControlsHelper.SetControlsEnabled(Me.Controls)
    End Sub

    Private Sub ToolStrip_ItemClicked()
        If Not Me.Enabled Or Me Is Nothing Then
            Exit Sub
        End If
        If UC_Toolstrip.Modo = "NOVO" Then
            LimpaCampos_Ativa()
        ElseIf UC_Toolstrip.Modo = "SALVAR" Then
            If ComboNome.Visible = False Then
                InsereCargo()
            Else
                DAO.DAO.AtualizaCargo(LstCargo(ComboNome.SelectedIndex - 1), "", False, loginusuario)
            End If
        ElseIf UC_Toolstrip.Modo = "PROCURAR" Then
            LimpaCampos_Ativa()
            CarregaCargos()
        ElseIf UC_Toolstrip.Modo = "CONFIRMAR" Then
            If frmPrincipal.StateTransaction = Uteis.SYSConsts.PENDENTE Then
                DAO.DAO.ConfirmarOuReverter(True)
                LimpaCampos_Ativa()
                frmPrincipal.StateTransaction = Uteis.SYSConsts.FINALIZADO
            End If
        ElseIf UC_Toolstrip.Modo = "ROLLBACK" Then
            If frmPrincipal.StateTransaction = Uteis.SYSConsts.PENDENTE Then
                If Uteis.MsgBoxHelper.MsgTemCerteza("Deseja reverter a operação?", "Reverter") Then
                    DAO.DAO.ConfirmarOuReverter(False)
                    LimpaCampos_Ativa()
                    frmPrincipal.StateTransaction = Uteis.SYSConsts.FINALIZADO
                Else
                    Exit Sub
                End If
            End If
        ElseIf UC_Toolstrip.Modo = "DELETAR" Then
            If Uteis.MsgBoxHelper.MsgTemCerteza("Deseja deletar o item?", "Deletar") Then
                If DAO.DAO.DeleteUsuario(LstCargo(ComboNome.SelectedIndex - 1).CodCargo, "") Then
                    frmPrincipal.StateTransaction = Uteis.SYSConsts.PENDENTE
                    Uteis.ControlsHelper.SetControlsDisabled(Me)
                    Uteis.ControlsHelper.ToolBarTransactionOpen(frmPrincipal.UC_Toolstrip1.ToolStrip1)
                End If
            Else
                Exit Sub
            End If
        ElseIf UC_Toolstrip.Modo = "LIMPAR" Then
            LimpaCampos()
        End If

        AlternarControle()
        If frmPrincipal.StateTransaction Then
            Uteis.ControlsHelper.EnableAllToolBarItens(frmPrincipal.UC_Toolstrip1.ToolStrip1)
        End If
    End Sub

    Private Sub AlternarControle()
        If UC_Toolstrip.Modo = "PROCURAR" Then
            ComboNome.DropDownStyle = ComboBoxStyle.DropDown
        ElseIf UC_Toolstrip.Modo = "NOVO" Then
            ComboNome.Visible = True
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
            LimpaCampos()
        End If
    End Sub

    Private Sub BuscaCargoPorCodigo(ByVal codcargo As String)
        Dim resposta As String = ""
        Dim cargo = DAO.DAO.GetCargo(codcargo)

        If IsNothing(cargo) Then
            Uteis.MsgBoxHelper.Erro(Me, resposta, "Erro")
            Exit Sub
        End If

        PreencheCampos(cargo)
    End Sub

    Private Sub PreencheCampos(cargo As Cargo)
        ComboNome.Text = cargo.Nome
        TxtDesc.Text = cargo.Descricao
        ChkBoxAtivo.Checked = cargo.IsAtivo
        ChkVendedor.Checked = cargo.IsVendedor
    End Sub
End Class