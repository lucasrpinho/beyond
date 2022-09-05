Imports Entidades
Public Class Frm_Usuario

    Private frmPrincipal As Frm_Principal_MDI
    Private LstUsuario As New List(Of Usuario)
    Private Modo As String = ""
    Private flagOperacao As Boolean = False

    Public Sub New(frm As Frm_Principal_MDI)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        frmPrincipal = frm
    End Sub

    Private Sub Frm_Usuario_Load(sender As System.Object, e As System.EventArgs) Handles Me.Load
        Uteis.ControlsHelper.SetControlsDisabled(Me)
        AddHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
        Modo = UC_Toolstrip.Modo
    End Sub

    Private Sub Frm_Usuario_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'If frmPrincipal.StateTransaction = Uteis.SYSConsts.PENDENTE Then
        '    Uteis.MsgBoxHelper.AlertaTransacao(Me, frmPrincipal.UC_Toolstrip1.ToolStrip1)
        '    e.Cancel = True
        '    Exit Sub
        'End If
        DAO.DAO.ReverterOuCommitar()
        RemoveHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
    End Sub

    Private Function Cadastrar() As Boolean
        Dim usuario As New Usuario
        usuario.Nome = ComboNome.Text.ToUpper
        usuario.Sobrenome = TxtSobrenome.Text.ToUpper
        usuario.NomeCompleto = usuario.Nome.ToUpper + " " + usuario.Sobrenome.ToUpper
        usuario.Email = TxtEmail.Text.ToUpper
        usuario.Login = TxtLogin.Text.ToUpper
        usuario.Senha = TxtSenhaConfirmar.Text.ToUpper
        usuario.LoginCriacao = loginusuario.ToUpper
        usuario.IsAtivo = ChkBoxAtivo.Checked

        Dim strError As String = ""
        If Not usuario.IsValid(strError) Then
            Uteis.MsgBoxHelper.Alerta(Me, strError, "Preenchimento incompleto")
            Return False
        End If

        If Not Uteis.RegexValidation.IsEmailValid(TxtEmail.Text) Then
            Uteis.MsgBoxHelper.CustomTooltip(Me, TxtEmail, "E-mail inválido.", "Erro de preenchimento")
            Return False
        End If

        If Not ValidaSenha() Then
            Return False
        End If

        Dim resposta As String = String.Empty

        If Not DAO.DAO.InsertUsuario(usuario, resposta) Then
            Uteis.MsgBoxHelper.Alerta(Me, resposta, "Erro")
            Return False
        End If

        flagOperacao = True
        Return True
    End Function

    Private Sub ToolStrip_ItemClicked()
        If Not Me.Enabled Then
            Exit Sub
        End If

        Dim resposta As String = ""

        If UC_Toolstrip.Modo = "SALVAR" Then
            If ComboNome.DropDownStyle = ComboBoxStyle.Simple Then
                If Cadastrar() Then
                    Uteis.ControlsHelper.SetControlsDisabled(Me)
                    frmPrincipal.UC_Toolstrip1.AfterSuccessfulInsert()
                    CarregaUsuarios()
                Else
                    frmPrincipal.UC_Toolstrip1.ToolbarItemsState("", False)
                End If
            Else
                If Not DAO.DAO.AtualizaUsuario(LstUsuario(ComboNome.SelectedIndex - 1), resposta) Then
                    frmPrincipal.UC_Toolstrip1.ToolbarItemsState("", False)
                Else
                    LimpaCampos_AtivaControles()
                    Uteis.ControlsHelper.SetControlsDisabled(Me)
                    frmPrincipal.UC_Toolstrip1.PagAberta_HabilitarBotoes()
                End If
            End If

        ElseIf UC_Toolstrip.Modo = "NOVO" Then
            LimpaCampos_AtivaControles()
            AlternarControle()


        ElseIf UC_Toolstrip.Modo = "ALTERAR" Then
            Uteis.ControlsHelper.SetControlsEnabled(Me.Controls)
            ComboNome.Enabled = False
            TxtSobrenome.Enabled = False
            TxtLogin.Enabled = False


        ElseIf UC_Toolstrip.Modo = "PESQUISAR" Then
            ControlsState_ModoProcurar()
            CarregaUsuarios()
            AlternarControle()

        ElseIf UC_Toolstrip.Modo = "REVERTER" Then
            If flagOperacao Then
                If Uteis.MsgBoxHelper.MsgTemCerteza(frmPrincipal, "Deseja reverter a operação?", "Reverter") Then
                    DAO.DAO.ReverterOuCommitar(True)
                End If
            End If
            Uteis.ControlsHelper.SetControlsDisabled(Me)
            LimpaCampos_AtivaControles()
        End If


        frmPrincipal.UC_Toolstrip1.ToolStrip1.Items("BtnExcluir").Enabled = False
        Me.Modo = UC_Toolstrip.Modo
    End Sub

    Private Sub BuscaUsuarioPorCodigo(ByVal codusuario As String)
        Dim resposta As String = ""
        Dim usuario = DAO.DAO.GetUsuario(codusuario, resposta)

        If IsNothing(usuario) Then
            Uteis.MsgBoxHelper.Erro(Me, resposta, "Erro")
            Exit Sub
        End If

        PreencheCampos(usuario)
    End Sub

    Private Sub PreencheCampos(ByVal usuario As Usuario)
        ComboNome.Text = usuario.Nome
        TxtEmail.Text = usuario.Email
        TxtSobrenome.Text = usuario.Sobrenome
        TxtLogin.Text = usuario.Login
        TxtSenha.Text = String.Empty
        TxtSenhaConfirmar.Text = String.Empty
        ChkBoxAtivo.Checked = usuario.IsAtivo

        Uteis.ControlsHelper.SetControlsEnabled(Me.Controls)
    End Sub

    Private Sub AlternarControle()
        If UC_Toolstrip.Modo = "PESQUISAR" Then
            ComboNome.DropDownStyle = ComboBoxStyle.DropDown
            TxtSenha.Enabled = False
            TxtSenhaConfirmar.Enabled = False
        ElseIf UC_Toolstrip.Modo = "NOVO" Then
            ComboNome.DropDownStyle = ComboBoxStyle.Simple
            TxtSenha.Enabled = True
            TxtSenhaConfirmar.Enabled = True
        End If
    End Sub

    Private Sub CarregaUsuarios()
        If UC_Toolstrip.Modo = "NOVO" Then
            Exit Sub
        End If

        LstUsuario.Clear()
        ComboNome.Items.Clear()
        Dim resposta As String = ""

        LstUsuario = DAO.DAO.GetUsuarios(True, resposta)

        If LstUsuario.Count > 0 Then
            ComboNome.Items.Add("")
            For Each usuario As Usuario In LstUsuario
                ComboNome.BeginUpdate()
                ComboNome.Items.Add(usuario.NomeCompleto)
                ComboNome.EndUpdate()
            Next
            ComboNome.SelectedIndex = 0
        End If
    End Sub

    Private Sub ComboNome_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboNome.SelectedIndexChanged
        If Not Uteis.StringHelper.IsNull(ComboNome.Text) Then
            BuscaUsuarioPorCodigo(LstUsuario(ComboNome.SelectedIndex - 1).CodUsuario)
        Else
            Uteis.ControlsHelper.SetTextsEmpty(Me.GroupBox1.Controls)
            Uteis.ControlsHelper.SetTextsEmpty(Me.GroupBox2.Controls)
        End If
    End Sub

    Private Function ValidaSenha() As Boolean
        If Not Uteis.StringHelper.IsNull(TxtSenha.Text) Then
            If Not Uteis.RegexValidation.IsSenhaValida(TxtSenha.Text) Then
                Uteis.MsgBoxHelper.Alerta(Me, "Senha deve conter de 5 a 16 caracteres." + vbNewLine +
                    "Uma letra maiuscula, uma letra minúscula e um número.", "Senha inválida")
                Return False
            ElseIf Not Uteis.StringHelper.IsNull(TxtSenhaConfirmar.Text) Then
                If TxtSenha.Text.ToUpper <> TxtSenhaConfirmar.Text.ToUpper Then
                    Uteis.MsgBoxHelper.Erro(Me, "Senhas diferentes.", "Erro")
                Else
                    Return True
                End If
            End If
        End If
        Return False
    End Function

    Private Sub LimpaCampos_AtivaControles()
        Uteis.ControlsHelper.SetTextsEmpty(Me.GroupBox1.Controls)
        Uteis.ControlsHelper.SetTextsEmpty(Me.GroupBox2.Controls)
        Uteis.ControlsHelper.SetControlsEnabled(Me.Controls)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub ComboNome_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ComboNome.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub ControlsState_ModoProcurar()
        GroupBox1.Enabled = True
        For Each Control As Control In GroupBox1.Controls
            If Control IsNot ComboNome Then
                Control.Enabled = False
            Else
                Control.Enabled = True
            End If
        Next
        GroupBox2.Enabled = False

        Uteis.ControlsHelper.SetTextsEmpty(GroupBox1.Controls)
        Uteis.ControlsHelper.SetTextsEmpty(GroupBox2.Controls)
    End Sub

    Private Sub Frm_Usuario_EnabledChanged(sender As System.Object, e As System.EventArgs) Handles MyBase.EnabledChanged
        If Me.Enabled Then
            frmPrincipal.UC_Toolstrip1.ToolbarItemsState(Me.Modo)
        End If
    End Sub
End Class