Imports DAO
Imports Entidades
Imports Uteis

Public Class Frm_Login

    Private RespostaAutenticacao As String
    Private Retrys As Integer = 0
    Private _ToolTip As New ToolTip()

    Private Sub BtnAcessa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAcessa.Click
        If Not ValidaCampos() Then
            Exit Sub
        End If
        AutenticaUserAcessaSistema()
    End Sub

    Private Function ValidaCampos() As Boolean
        If StringHelper.IsNull(TxtLogin.Text) Then
            MsgBoxHelper.Alerta("Campo de login precisa ser preenchido", "")
        ElseIf StringHelper.IsNull(TxtSenha.Text) Then
            MsgBoxHelper.Alerta("Campo de senha precisa ser preenchido", "")
        ElseIf Not StringHelper.MinLength(TxtLogin.Text, 5) Then
            _ToolTip.IsBalloon = True
            _ToolTip.ToolTipTitle = "Login inválido"
            _ToolTip.ToolTipIcon = ToolTipIcon.Error
            _ToolTip.SetToolTip(TxtLogin, "Login muito curto")
            _ToolTip.Show("Login muito curto", TxtLogin, 3000)
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
            TxtSenhaInvalida.Text = "Login deve conter apenas letras"
        End If
    End Sub

    Private Sub TxtSenha_Enter(sender As System.Object, e As System.EventArgs) Handles TxtSenha.Enter
        TxtSenhaInvalida.Visible = False
    End Sub

    Private Sub AutenticaUserAcessaSistema()
        Dim User As Usuario
        Try
            Cursor.Current = Cursors.WaitCursor
            Retrys += 1
            User = DAO.DAO.AutenticaUsuario(TxtLogin.Text.ToUpper.Trim, TxtSenha.Text, RespostaAutenticacao)

            If Retrys >= 3 And IsNothing(User) Then
                MsgBoxHelper.Alerta("O sistema será fechado", "Tentativas de logon esgotadas")
                System.Threading.Thread.Sleep(1500)
                Application.Exit()
            End If

            If User Is Nothing Then
                TxtSenhaInvalida.Text = RespostaAutenticacao
                TxtSenhaInvalida.Visible = True
            Else
                Dim FPrincipal As New Frm_Principal_MDI(User)
                FPrincipal.Show()
                Me.Close()
            End If
        Finally
            Cursor.Current = Cursors.Arrow
        End Try
    End Sub

    Private Sub Frm_Login_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Application.OpenForms.OfType(Of Frm_Principal_MDI).Count > 0 Then
            e.Cancel = False
        Else
            Application.Exit()
        End If
    End Sub
End Class
