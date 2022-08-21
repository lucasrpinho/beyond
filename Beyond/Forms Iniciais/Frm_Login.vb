Imports DAO
Imports Entidades
Imports Uteis

Public Class Frm_Login

    Private RespostaAutenticacao As String
    Private Retrys As Integer = 0
    Private _ToolTip As New ToolTip()

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub BtnAcessa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAcessa.Click
        If Not ValidaCampos() Then
            Exit Sub
        End If
        Dim User As Usuario
        Retrys += 1
        User = DAO.DAO.AutenticaUsuario(TxtLogin.Text.ToUpper.Trim, TxtSenha.Text, RespostaAutenticacao)

        If Retrys >= 3 And IsNothing(User) Then
            MB.Alerta("O sistema será fechado", "Tentativas de logon esgotadas")
            System.Threading.Thread.Sleep(1500)
            Application.Exit()
        End If

        If User Is Nothing Then
            TxtSenhaInvalida.Text = RespostaAutenticacao
            TxtSenhaInvalida.Visible = True
        End If
    End Sub

    Private Sub Frm_Login_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

    Private Function ValidaCampos() As Boolean
        If SH.IsNull(TxtLogin.Text) Then
            MB.Alerta("Campo de login precisa ser preenchido", "")
        ElseIf SH.IsNull(TxtSenha.Text) Then
            MB.Alerta("Campo de senha precisa ser preenchido", "")
        ElseIf Not SH.MinLength(TxtLogin.Text, 5) Then
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
            TxtSenhaInvalida.Text = "Login precisa ser maiúsculo e conter apenas letras"
        End If
    End Sub
End Class
