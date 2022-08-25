Imports Entidades
Public Class Frm_CadUsuario

    Private frmPrincipal As Frm_Principal_MDI
    Private StateTransaction As Boolean = True
    Private LstUsuario As New List(Of Usuario)
    Private WithEvents ToolStrip As ToolStrip

    Public Sub New(frm As Form, _toolstrip As ToolStrip)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        frmPrincipal = frm
        ToolStrip = _toolstrip
    End Sub

    Private Sub Frm_CadUsuario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Uteis.Controls.SetControlsDisabled(Me)
    End Sub

    Public Sub Cadastrar()
        Dim usuario As New Usuario
        usuario.Nome = TxtNome.Text.ToUpper
        usuario.Sobrenome = TxtSobrenome.Text.ToUpper
        usuario.NomeCompleto = usuario.Nome.ToUpper + " " + usuario.Sobrenome.ToUpper
        usuario.Email = TxtEmail.Text.ToUpper
        usuario.Login = TxtLogin.Text.ToUpper
        usuario.Senha = TxtSenhaConfirmar.Text.ToUpper
        usuario.LoginCriacao = loginusuario.ToUpper
        usuario.IsAtivo = ChkBoxAtivo.Checked

        Dim strError As String = ""
        If Not usuario.IsValid(strError) Then
            Uteis.MsgBoxHelper.Erro(Me, strError, "Preenchimento incorreto")
            Exit Sub
        End If
        TxtSenha_Leave(Nothing, Nothing)
        Dim resposta As String = String.Empty
        If Not DAO.DAO.InsertUsuario(usuario, resposta) Then
            Uteis.MsgBoxHelper.Erro(Me, resposta, "Erro")
        Else
            StateTransaction = Uteis.Consts.PENDENTE
            'Uteis.Controls.SetTextBoxEmpty(Me)
            Uteis.Controls.ToolBarAfterInsert(frmPrincipal.UC_Toolstrip1.ToolStrip0)
            Uteis.Controls.SetControlsDisabled(Me)
        End If
    End Sub

    Private Sub ToolStrip_ItemClicked() Handles ToolStrip.ItemClicked
        If UC_Toolstrip.Modo = "NOVO" Then
            Uteis.Controls.SetControlsEnabled(Me)
        ElseIf UC_Toolstrip.Modo = "SALVAR" Then
            Cadastrar()
        ElseIf UC_Toolstrip.Modo = "PROCURAR" Then
            Uteis.Controls.SetTextBoxEmpty(Me)
            AlternarControle()
            Uteis.Controls.SetControlsEnabled(Me)
            CarregaUsuarios()
        ElseIf UC_Toolstrip.Modo = "CONFIRMAR" Then
            If StateTransaction = Uteis.Consts.PENDENTE Then
                DAO.DAO.ConfirmarOuReverter(True)
                Uteis.Controls.SetTextBoxEmpty(Me)
                StateTransaction = Uteis.Consts.FINALIZADO
            End If
        ElseIf UC_Toolstrip.Modo = "ROLLBACK" Then
            If StateTransaction = Uteis.Consts.PENDENTE Then
                DAO.DAO.ConfirmarOuReverter(False)
                Uteis.Controls.SetTextBoxEmpty(Me)
                Uteis.Controls.SetControlsEnabled(Me)
                StateTransaction = Uteis.Consts.FINALIZADO
            End If
        ElseIf UC_Toolstrip.Modo = "LIMPAR" Then
            Uteis.Controls.SetTextBoxEmpty(Me)
            Uteis.Controls.SetControlsEnabled(Me)
        End If

        If StateTransaction Then
            Uteis.Controls.EnableAllToolBarItens(frmPrincipal.UC_Toolstrip1.ToolStrip1)
        End If
    End Sub

    Private Sub Frm_CadUsuario_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If StateTransaction = Uteis.Consts.PENDENTE Then
            Uteis.MsgBoxHelper.AlertaTransacao(Me, frmPrincipal.UC_Toolstrip1.ToolStrip0)
            e.Cancel = True
        End If
    End Sub

    Public Sub BuscaUsuarioPorCodigo(ByVal codusuario As String)
        Dim resposta As String = ""
        Dim usuario = DAO.DAO.GetUsuario(codusuario, resposta)

        If IsNothing(usuario) Then
            Uteis.MsgBoxHelper.Erro(Me, resposta, "Erro")
            Exit Sub
        End If

        PreencheCampos(usuario)

    End Sub

    Private Sub PreencheCampos(ByVal usuario As Usuario)
        TxtNome.Text = usuario.Nome
        TxtEmail.Text = usuario.Email
        TxtSobrenome.Text = usuario.Sobrenome
        TxtLogin.Text = usuario.Login
        TxtSenha.Text = String.Empty
        TxtSenhaConfirmar.Text = String.Empty
        ChkBoxAtivo.Checked = usuario.IsAtivo

        Uteis.Controls.SetControlsEnabled(Me)
    End Sub

    Private Sub AlternarControle()
        If UC_Toolstrip.Modo = "PROCURAR" Then
            Dim pos = TxtNome.Location
            ComboNome.Location = pos
            ComboNome.Width = TxtNome.Width
            ComboNome.Visible = True
            TxtNome.Visible = False

            TxtSenha.Enabled = Not ComboNome.Visible
            TxtSenhaConfirmar.Enabled = Not ComboNome.Visible
        ElseIf UC_Toolstrip.Modo = "NOVO" Then
            ComboNome.Visible = False
            TxtNome.Visible = Not ComboNome.Visible
            TxtSenha.Enabled = Not ComboNome.Visible
            TxtSenhaConfirmar.Enabled = Not ComboNome.Visible
        End If
    End Sub

    Private Sub CarregaUsuarios()
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
            Uteis.Controls.SetTextBoxEmpty(Me)
        End If
    End Sub

    Private Sub TxtSenha_Leave(sender As System.Object, e As System.EventArgs) Handles TxtSenha.Leave
        If Not Uteis.StringHelper.IsNull(TxtSenha.Text) Then
            If Not Uteis.RegexValidation.IsSenhaValida(TxtSenha.Text) Then
                Uteis.MsgBoxHelper.Erro(Me, "Senha deve conter de 5 a 16 caracteres" + vbNewLine +
                    "Uma letra maiuscula e um número", "Senha inválida")
                TxtSenha.Focus()
            End If
        End If
    End Sub

    Private Sub TxtSenhaConfirmar_Leave(sender As System.Object, e As System.EventArgs) Handles TxtSenhaConfirmar.Leave
        If Not Uteis.StringHelper.IsNull(TxtSenhaConfirmar.Text) And Not Uteis.StringHelper.IsNull(TxtSenha.Text) Then
            If TxtSenha.Text.ToUpper <> TxtSenhaConfirmar.Text.ToUpper Then
                Dim tooltip As New ToolTip
                tooltip.IsBalloon = True
                tooltip.ToolTipIcon = ToolTipIcon.Warning
                tooltip.ToolTipTitle = "Aviso"
                tooltip.SetToolTip(TxtSenhaConfirmar, "As senhas estão diferentes")
                tooltip.Show("As senhas estão diferentes", TxtSenhaConfirmar, 5000)
            End If
        End If
    End Sub
End Class