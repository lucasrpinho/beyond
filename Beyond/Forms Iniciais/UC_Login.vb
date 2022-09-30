Imports DAO
Imports Entidades
Imports Uteis

Public Class UC_Login

    Private RespostaAutenticacao As String
    Private Retrys As Integer = 0
    Private _ToolTip As New ToolTip()
    Private frmPrincipal As Frm_Principal_MDI

    Private Sub BtnAcessa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAcessa.Click
        If Not ValidaCampos() Then
            Exit Sub
        End If
        AutenticaUserAcessaSistema()
    End Sub

    Private Function ValidaCampos() As Boolean
        If StringHelper.IsNull(TxtLogin.Text) Then
            MsgBoxHelper.CustomTooltip(TxtLogin, TxtLogin, "Campo de login precisa ser preenchido.", "Login", ToolTipIcon.Info)
            TxtLogin.Focus()
        ElseIf StringHelper.IsNull(TxtSenha.Text) Then
            MsgBoxHelper.CustomTooltip(TxtSenha, TxtSenha, "Campo de senha precisa ser preenchido.", "Senha", ToolTipIcon.Info)
            TxtSenha.Focus()
        Else
            Return True
        End If
        Return False
    End Function

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub TxtLogin_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtLogin.TextChanged
        If RegexValidation.IsOnlyLetter(TxtLogin.Text) Then
            TxtSenhaInvalida.Visible = False
            BtnAcessa.Enabled = True
        Else
            BtnAcessa.Enabled = False
            TxtSenhaInvalida.Visible = True
            TxtSenhaInvalida.Text = "Formato de login inválido."
            TxtLogin.Focus()
        End If
    End Sub

    Private Sub TxtSenha_Enter(sender As System.Object, e As System.EventArgs) Handles TxtSenha.Enter
        TxtSenhaInvalida.Visible = False
    End Sub

    Private Sub AutenticaUserAcessaSistema()
        frmPrincipal = Application.OpenForms.OfType(Of Frm_Principal_MDI).First
        Dim User As Usuario
        Try
            Cursor.Current = Cursors.WaitCursor
            Retrys += 1
            User = DAO.DAO.AutenticaUsuario(TxtLogin.Text.ToUpper.Trim, TxtSenha.Text, RespostaAutenticacao)

            If Retrys >= 3 And IsNothing(User) Then
                MsgBoxHelper.Msg(Me.ParentForm, "Tentativas de login esgotadas." + vbNewLine + vbNewLine + "O sistema será fechado.", "Informação")
                frmPrincipal.TentativasLoginEsgotadas = True
                Application.Exit()
            End If

            If User Is Nothing Then
                TxtSenhaInvalida.Text = RespostaAutenticacao
                TxtSenhaInvalida.Visible = True
            Else
                frmPrincipal.SetUsuarioLogado(User)
                frmPrincipal.TSL_Login.Text = User.Login
                frmPrincipal.MnStrip_Principal.Enabled = True
                frmPrincipal.UC_Toolstrip1.Enabled = True
                frmPrincipal.SplitC1.Panel1Collapsed = True
            End If
        Finally
            Cursor.Current = Cursors.Arrow
        End Try
    End Sub

    Private Sub BtnAcessa_MouseEnter(sender As System.Object, e As System.EventArgs) Handles BtnAcessa.MouseEnter
        BtnAcessa.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub BtnAcessa_MouseLeave(sender As System.Object, e As System.EventArgs) Handles BtnAcessa.MouseLeave
        BtnAcessa.BackColor = Color.Transparent
    End Sub

    Private Sub UC_Login_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TxtLogin.Focus()
    End Sub

    Private Sub BtnSair_Click(sender As System.Object, e As System.EventArgs) Handles BtnSair.Click
        Application.Exit()
    End Sub
End Class
