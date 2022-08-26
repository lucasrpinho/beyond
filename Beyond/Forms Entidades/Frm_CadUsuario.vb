Imports Entidades
Public Class Frm_CadUsuario

    Private frmPrincipal As Frm_Principal_MDI
    Private LstUsuario As New List(Of Usuario)
    Private WithEvents ToolStrip As ToolStrip

    Public Sub New(frm As Frm_Principal_MDI)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        frmPrincipal = frm
        ToolStrip = frmPrincipal.UC_Toolstrip1.ToolStrip0
    End Sub

    Private Sub Frm_CadUsuario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Uteis.ControlsHelper.SetControlsDisabled(Me)
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

        If Not Uteis.RegexValidation.IsEmailValid(TxtEmail.Text) Then
            Uteis.MsgBoxHelper.CustomTooltip(Me, TxtEmail, "E-mail inválido", "Erro de preenchimento")
            Exit Sub
        End If

        If Not ValidaSenha() Then
            Exit Sub
        End If
        Dim resposta As String = String.Empty

        If Not DAO.DAO.InsertUsuario(usuario, resposta) Then
            Uteis.MsgBoxHelper.Erro(Me, resposta, "Erro")
        Else
            frmPrincipal.StateTransaction = Uteis.SYSConsts.PENDENTE
            'Uteis.Controls.SetTextBoxEmpty(Me)
            Uteis.ControlsHelper.ToolBarTransactionOpen(frmPrincipal.UC_Toolstrip1.ToolStrip0)
            Uteis.ControlsHelper.SetControlsDisabled(Me)
        End If
    End Sub

    Private Sub ToolStrip_ItemClicked() Handles ToolStrip.ItemClicked
        If Not Me.Enabled Then
            Exit Sub
        End If
        If UC_Toolstrip.Modo = "NOVO" Then
            LimpaCampos_AtivaControles()
        ElseIf UC_Toolstrip.Modo = "SALVAR" Then
            Cadastrar()
        ElseIf UC_Toolstrip.Modo = "PROCURAR" Then
            AlternarControle()
            LimpaCampos_AtivaControles()
            CarregaUsuarios()
        ElseIf UC_Toolstrip.Modo = "CONFIRMAR" Then
            If frmPrincipal.StateTransaction = Uteis.SYSConsts.PENDENTE Then
                DAO.DAO.ConfirmarOuReverter(True)
                LimpaCampos_AtivaControles()
                frmPrincipal.StateTransaction = Uteis.SYSConsts.FINALIZADO
            End If
        ElseIf UC_Toolstrip.Modo = "ROLLBACK" Then
            If frmPrincipal.StateTransaction = Uteis.SYSConsts.PENDENTE Then
                If Uteis.MsgBoxHelper.MsgTemCerteza("Deseja reverter a operação?", "Reverter") Then
                    DAO.DAO.ConfirmarOuReverter(False)
                    Uteis.ControlsHelper.SetControlsDisabled(Me)
                    LimpaCampos_AtivaControles()
                    frmPrincipal.StateTransaction = Uteis.SYSConsts.FINALIZADO
                Else
                    Exit Sub
                End If
            End If
        ElseIf UC_Toolstrip.Modo = "DELETAR" Then
            If Uteis.MsgBoxHelper.MsgTemCerteza("Deseja deletar o item?", "Deletar") Then
                If DAO.DAO.DeleteUsuario(LstUsuario(ComboNome.SelectedIndex - 1).CodUsuario, "") Then
                    frmPrincipal.StateTransaction = Uteis.SYSConsts.PENDENTE
                    Uteis.ControlsHelper.SetControlsDisabled(Me)
                    Uteis.ControlsHelper.ToolBarTransactionOpen(frmPrincipal.UC_Toolstrip1.ToolStrip0)
                End If
            Else
                Exit Sub
            End If
        ElseIf UC_Toolstrip.Modo = "LIMPAR" Then
            LimpaCampos_AtivaControles()
        End If

        If frmPrincipal.StateTransaction Then
            Uteis.ControlsHelper.EnableAllToolBarItens(frmPrincipal.UC_Toolstrip1.ToolStrip0)
        End If
    End Sub

    Private Sub Frm_CadUsuario_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If frmPrincipal.StateTransaction = Uteis.SYSConsts.PENDENTE Then
            Uteis.MsgBoxHelper.AlertaTransacao(Me, frmPrincipal.UC_Toolstrip1.ToolStrip0)
            e.Cancel = True
            Exit Sub
        End If

        Me.Dispose()
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
        TxtNome.Text = usuario.Nome
        TxtEmail.Text = usuario.Email
        TxtSobrenome.Text = usuario.Sobrenome
        TxtLogin.Text = usuario.Login
        TxtSenha.Text = String.Empty
        TxtSenhaConfirmar.Text = String.Empty
        ChkBoxAtivo.Checked = usuario.IsAtivo

        Uteis.ControlsHelper.SetControlsEnabled(Me.Controls)
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
            Uteis.ControlsHelper.SetTextBoxEmpty(Me.GroupBox1.Controls)
            Uteis.ControlsHelper.SetTextBoxEmpty(Me.GroupBox2.Controls)
        End If
    End Sub

    Private Function ValidaSenha() As Boolean
        If Not Uteis.StringHelper.IsNull(TxtSenha.Text) Then
            If Not Uteis.RegexValidation.IsSenhaValida(TxtSenha.Text) Then
                Uteis.MsgBoxHelper.Erro(Me, "Senha deve conter de 5 a 16 caracteres" + vbNewLine +
                    "Uma letra maiuscula e um número", "Senha inválida")
                Return False
            ElseIf Not Uteis.StringHelper.IsNull(TxtSenhaConfirmar.Text) Then
                If TxtSenha.Text.ToUpper <> TxtSenhaConfirmar.Text.ToUpper Then
                    Uteis.MsgBoxHelper.Erro(Me, "Senhas diferentes", "Erro")
                Else
                    Return True
                End If
            End If
        End If
        Return False
    End Function

    Private Sub LimpaCampos_AtivaControles()
        Uteis.ControlsHelper.SetTextBoxEmpty(Me.GroupBox1.Controls)
        Uteis.ControlsHelper.SetTextBoxEmpty(Me.GroupBox2.Controls)
        Uteis.ControlsHelper.SetControlsEnabled(Me.Controls)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class