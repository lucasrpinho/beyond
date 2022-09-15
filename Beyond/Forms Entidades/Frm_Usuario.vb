Imports Entidades
Imports DAO

Public Class Frm_Usuario

    Private frmPrincipal As Frm_Principal_MDI
    Private LstUsuario As New List(Of Usuario)
    Private MyModo As New UC_Toolstrip.UniqueModo
    Private IsOperacaoActive As Boolean = False
    Private DAOUsuario As New DAO.DAO
    Private MostrarSenha As Boolean = True
    Private objUsuario As Usuario

    Public Sub New(frm As Frm_Principal_MDI)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        frmPrincipal = frm
    End Sub

    Private Sub Frm_Usuario_Load(sender As System.Object, e As System.EventArgs) Handles Me.Load
        Uteis.ControlsHelper.SetControlsDisabled(Me)
        AddHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
        MyModo.UniqueModo = "PADRÃO"
    End Sub

    Private Sub Frm_Usuario_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        RemoveHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
    End Sub

    Private Function InsereUsuario() As Boolean
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

        If Not DAOUsuario.InsertUsuario(usuario, resposta) Then
            Uteis.MsgBoxHelper.Alerta(Me, resposta, "Erro")
            Return False
        End If

        Return True
    End Function

    Private Sub ToolStrip_ItemClicked()
        If Not Me.Enabled Then
            Exit Sub
        End If

        Dim resposta As String = ""

        MyModo.UniqueModo = UC_Toolstrip.Modo

        If MyModo.UniqueModo = "SALVAR" Then
            If ComboNome.DropDownStyle = ComboBoxStyle.Simple AndAlso UC_Toolstrip.ModoAnterior = "NOVO" Then
                If InsereUsuario() Then
                    LimpaCampos_AtivaControles()
                    Uteis.ControlsHelper.SetControlsDisabled(Me.Controls)
                    frmPrincipal.UC_Toolstrip1.AfterSuccessfulInsert()
                Else
                    frmPrincipal.UC_Toolstrip1.ToolbarItemsState("", False)
                End If
            Else
                If Uteis.MsgBoxHelper.MsgTemCerteza(Me, "Tem certeza que deseja modificar o registro?", "Alteração") Then
                    If Not DAOUsuario.AtualizaUsuario(GetUsuarioForOperation, resposta) Then
                        frmPrincipal.UC_Toolstrip1.ToolbarItemsState("", False)
                    Else
                        Uteis.ControlsHelper.SetControlsDisabled(Me.Controls)
                        frmPrincipal.UC_Toolstrip1.AfterSuccessfulUpdate()
                    End If
                End If
            End If

        ElseIf MyModo.UniqueModo = "NOVO" Then
            LimpaCampos_AtivaControles()
            AlternarControle()
            ComboNome.Focus()


        ElseIf MyModo.UniqueModo = "ALTERAR" Then
            CarregaUsuarios()
            ModoAlterar()


        ElseIf MyModo.UniqueModo = "PESQUISAR" Then
            ModoProcurar()
            If UC_Toolstrip.ModoAnterior = "REVERTER" Then
                ComboNome.SelectedIndex = LstUsuario.FindIndex(Function(u As Usuario) u.CodUsuario = objUsuario.CodUsuario)
            End If


        ElseIf MyModo.UniqueModo = "REVERTER" Then
            If Uteis.MsgBoxHelper.MsgTemCerteza(frmPrincipal, "Deseja desfazer as mudanças?", "Reverter") Then
                ToolStrip_ItemClicked()
            Else
                Exit Sub
            End If

        ElseIf MyModo.UniqueModo = "PADRÃO" Then
            LimpaCampos_AtivaControles()
            frmPrincipal.UC_Toolstrip1.PagAberta_HabilitarBotoes()
            Uteis.ControlsHelper.SetControlsDisabled(Me.Controls)
        End If

        frmPrincipal.UC_Toolstrip1.ToolStrip1.Items("BtnExcluir").Enabled = False
    End Sub

    Private Sub BuscaUsuarioPorCodigo(ByVal codusuario As String)
        Dim resposta As String = ""
        Dim usuario = DAOUsuario.GetUsuario(codusuario, resposta)

        If IsNothing(usuario) Then
            Uteis.MsgBoxHelper.Erro(Me, resposta, "Erro")
            Exit Sub
        End If

        objUsuario = usuario
        frmPrincipal.UC_Toolstrip1.EstadoAlterarExcluir(True)
        frmPrincipal.UC_Toolstrip1.ToolStrip1.Items("BtnExcluir").Enabled = False
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
        If MyModo.UniqueModo = "PESQUISAR" Then
            ComboNome.DropDownStyle = ComboBoxStyle.DropDown
            TxtSenha.Enabled = False
            TxtSenhaConfirmar.Enabled = False
        ElseIf MyModo.UniqueModo = "NOVO" Then
            ComboNome.DropDownStyle = ComboBoxStyle.Simple
            TxtSenha.Enabled = True
            TxtSenhaConfirmar.Enabled = True
        End If
    End Sub

    Private Sub CarregaUsuarios()
        If MyModo.UniqueModo = "NOVO" Then
            Exit Sub
        End If

        LstUsuario.Clear()
        ComboNome.Items.Clear()
        Dim resposta As String = ""

        LstUsuario = DAOUsuario.GetUsuarios(True, resposta)

        If LstUsuario.Count > 0 Then
            ComboNome.BeginUpdate()
            ComboNome.Items.AddRange(LstUsuario.ToArray)
            ComboNome.DisplayMember = "NomeCompleto"
            ComboNome.ValueMember = "CodUsuario"
            ComboNome.EndUpdate()
            If MyModo.UniqueModo = "PESQUISAR" Then
                'ComboNome.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub ComboNome_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboNome.SelectedIndexChanged
        If Not Uteis.StringHelper.IsNull(ComboNome.Text) Then
            If objUsuario IsNot Nothing Then
                objUsuario = Nothing
            End If
            BuscaUsuarioPorCodigo(LstUsuario(ComboNome.SelectedIndex).CodUsuario)
        Else
            Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxInfo.Controls)
            Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxCredenciais.Controls)
            frmPrincipal.UC_Toolstrip1.EstadoAlterarExcluir(False)
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
                    Uteis.MsgBoxHelper.Alerta(Me, "Senhas diferentes.", "Erro")
                Else
                    Return True
                End If
            End If
        End If
        Return False
    End Function

    Private Sub LimpaCampos_AtivaControles()
        Uteis.ControlsHelper.SetControlsEnabled(Me.Controls)
        Uteis.ControlsHelper.SetControlsEnabled(GrpBoxInfo.Controls)
        Uteis.ControlsHelper.SetControlsEnabled(GrpBoxCredenciais.Controls)
        Uteis.ControlsHelper.SetTextsEmpty(GrpBoxInfo.Controls)
        Uteis.ControlsHelper.SetTextsEmpty(GrpBoxCredenciais.Controls)
    End Sub

    Private Sub AtivaControles()
        Uteis.ControlsHelper.SetControlsEnabled(Me.Controls)
        Uteis.ControlsHelper.SetControlsEnabled(GrpBoxInfo.Controls)
        Uteis.ControlsHelper.SetControlsEnabled(GrpBoxCredenciais.Controls)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub ComboNome_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ComboNome.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If

        If Char.IsNumber(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub ModoProcurar()
        GrpBoxInfo.Enabled = True
        For Each Control As Control In GrpBoxInfo.Controls
            If Control IsNot ComboNome Then
                Control.Enabled = False
            Else
                Control.Enabled = True
            End If
        Next
        TxtLogin.Enabled = False
        GrpBoxCredenciais.Enabled = False

        Uteis.ControlsHelper.SetTextsEmpty(GrpBoxInfo.Controls)
        Uteis.ControlsHelper.SetTextsEmpty(GrpBoxCredenciais.Controls)
        AlternarControle()
        CarregaUsuarios()
    End Sub

    Private Sub Frm_Usuario_EnabledChanged(sender As System.Object, e As System.EventArgs) Handles MyBase.EnabledChanged
        If Me.Enabled Then
            frmPrincipal.UC_Toolstrip1.ToolbarItemsState(MyModo.UniqueModo)
        End If
    End Sub

    Private Function GetUsuarioForOperation() As Usuario
        Dim usuario As New Usuario
        If ComboNome.SelectedIndex > 0 Then
            usuario = LstUsuario(ComboNome.SelectedIndex)
        Else
            usuario = LstUsuario.Find(Function(u) u.Login = TxtLogin.Text)
        End If
        usuario.Email = TxtEmail.Text
        usuario.Senha = TxtSenha.Text
        usuario.IsAtivo = ChkBoxAtivo.Checked
        Return usuario
    End Function

    Private Sub TxtSobrenome_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSobrenome.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If

        If Char.IsNumber(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TxtLogin_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLogin.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If

        If Char.IsNumber(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsSeparator(e.KeyChar) Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        If MostrarSenha Then
            TxtSenha.UseSystemPasswordChar = False
            TxtSenhaConfirmar.UseSystemPasswordChar = False
            MostrarSenha = False
        Else
            TxtSenha.UseSystemPasswordChar = True
            TxtSenhaConfirmar.UseSystemPasswordChar = True
            MostrarSenha = True
        End If
    End Sub

    Private Sub ModoAlterar()
        Uteis.ControlsHelper.SetControlsEnabled(Me.Controls)
        ComboNome.Enabled = False
        TxtSobrenome.Enabled = False
        TxtLogin.Enabled = False
        TxtEmail.Enabled = True
        ChkBoxAtivo.Enabled = True
        TxtSenha.Enabled = False
        TxtSenhaConfirmar.Enabled = False
    End Sub

    Private Sub TxtEmail_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEmail.KeyPress
        If Char.IsSeparator(e.KeyChar) Or e.KeyChar = "," Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TxtSenha_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSenha.KeyPress
        If Char.IsSeparator(e.KeyChar) Or e.KeyChar = "," Or e.KeyChar = "." Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub TxtSenhaConfirmar_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSenhaConfirmar.KeyPress
        If Char.IsSeparator(e.KeyChar) Or e.KeyChar = "," Or e.KeyChar = "." Then
            e.KeyChar = ""
        End If
    End Sub
End Class