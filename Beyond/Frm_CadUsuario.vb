Imports Entidades
Public Class Frm_CadUsuario


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub Frm_CadUsuario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub Cadastrar()
        Dim usuario As New Usuario
        usuario.Nome = TxtNome.Text
        usuario.Sobrenome = TxtSobrenome.Text
        usuario.NomeCompleto = usuario.Nome + " " + usuario.Sobrenome
        usuario.Email = TxtEmail.Text
        usuario.Login = TxtLogin.Text
        usuario.Senha = TxtSenhaConfirmar.Text
        usuario.LoginCriacao = loginusuario
        usuario.IsAtivo = ChkBoxAtivo.Checked

        Dim strError As String = ""
        If Not usuario.IsValid(usuario, strError) Then
            Uteis.MB.Erro(Me, strError, "Preenchimento incorreto")
        End If

    End Sub
End Class