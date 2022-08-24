Imports Entidades
Public Class Frm_CadUsuario

    Private frmPrincipal As Frm_Principal_MDI
    Private StateTransaction As Boolean = True

    Public Sub New(frm As Form, toolstrip As ToolStrip)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        frmPrincipal = frm
        Dim uc As New UC_Toolstrip
        UC_Toolstrip.BtnClick = New EventHandler(Sub() ItemToolClicked())
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
        If Not usuario.IsValid(usuario, strError) Then
            Uteis.MsgBoxHelper.Erro(Me, strError, "Preenchimento incorreto")
            Exit Sub
        End If
        Dim resposta As String = String.Empty
        If Not DAO.DAO.InsertUsuario(usuario, resposta) Then
            Uteis.MsgBoxHelper.Erro(Me, resposta, "Erro")
        Else
            StateTransaction = Uteis.Consts.PENDENTE
            Uteis.Controls.SetTextBoxEmpty(Me)
            Uteis.Controls.SetControlsDisabled(Me)
        End If
    End Sub

    Private Sub ItemToolClicked()
        If UC_Toolstrip.Modo = "NOVO" Then
            Uteis.Controls.SetControlsEnabled(Me)
        ElseIf UC_Toolstrip.Modo = "SALVAR" Then
            Cadastrar()
        ElseIf UC_Toolstrip.Modo = "PROCURAR" Then
            Dim consUsuarios As New Frm_ConsUsuario
            consUsuarios.TopLevel = False
            Me.Controls.Add(consUsuarios)
            consUsuarios.BringToFront()
            consUsuarios.Focus()
            consUsuarios.Show()
        ElseIf UC_Toolstrip.Modo = "CONFIRMAR" Then
            If StateTransaction = Uteis.Consts.PENDENTE Then
                DAO.DAO.ConfirmarOuReverter(True)
                StateTransaction = Uteis.Consts.FINALIZADO
            End If
        ElseIf UC_Toolstrip.Modo = "ROLLBACK" Then
            If StateTransaction = Uteis.Consts.PENDENTE Then
                DAO.DAO.ConfirmarOuReverter(True)
                StateTransaction = Uteis.Consts.FINALIZADO
            End If
        End If
    End Sub

    Private Sub Frm_CadUsuario_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If StateTransaction = Uteis.Consts.PENDENTE Then
            Uteis.MsgBoxHelper.AlertaTransacao(Me, frmPrincipal.UC_Toolstrip1.ToolStrip0)
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

        UC_Toolstrip.BtnClick = New EventHandler(Sub() ItemToolClicked(Nothing, Nothing))
        Application.OpenForms.OfType(Of Frm_ConsUsuario).FirstOrDefault.Close()
    End Sub
End Class