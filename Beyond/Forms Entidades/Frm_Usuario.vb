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
    Private toolStrip As UC_Toolstrip

    Public Sub New(frm As Frm_Principal_MDI)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        frmPrincipal = frm
        toolStrip = frmPrincipal.UC_Toolstrip1
    End Sub

    Private Sub Desativa_Campos()
        Uteis.ControlsHelper.SetControlsDisabled(GrpBoxInfo.Controls)
        Uteis.ControlsHelper.SetControlsDisabled(GrpBoxCredenciais.Controls)
    End Sub

    Private Sub Frm_Usuario_Load(sender As System.Object, e As System.EventArgs) Handles Me.Load
        Desativa_Campos()
        AddHandler toolStrip.itemclick, AddressOf Me.ToolStrip_ItemClicked
        MyModo.UniqueModo = "PADRÃO"
    End Sub

    Private Sub Frm_Usuario_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        RemoveHandler toolStrip.itemclick, AddressOf Me.ToolStrip_ItemClicked
    End Sub

    Private Function InsereUsuario() As Boolean
        If Not ValidaPreenchimento() Then
            Return False
        End If

        Dim usuario As New Usuario
        usuario.NomeCompleto = RTrim(ComboNome.Text.ToUpper)
        usuario.Email = TxtEmail.Text.ToUpper
        usuario.Login = TxtLogin.Text.ToUpper
        usuario.Senha = TxtSenhaConfirmar.Text.ToUpper
        usuario.IsAtivo = ChkBoxAtivo.Checked

        Dim strError As String = ""
        If Not usuario.IsValid(strError) Then
            Uteis.MsgBoxHelper.Alerta(Me, strError, "Preenchimento incompleto")
            Return False
        End If

        If Not Uteis.RegexValidation.IsEmailValid(TxtEmail.Text) Then
            Uteis.MsgBoxHelper.Alerta(Me, "E-mail inválido.", "Erro de preenchimento", TxtEmail)
            Return False
        End If

        If Not ValidaSenha() Then
            Return False
        End If

        Dim resposta As String = String.Empty

        If Not DAOUsuario.InsertUsuario(usuario, resposta, codusuario) Then
            Uteis.MsgBoxHelper.Erro(Me, resposta, "Erro")
            Return False
        End If

        Dim dlgSucc As New Uteis.Dlg_Success
        dlgSucc.ShowDialog()

        Return True
    End Function

    Private Sub ToolStrip_ItemClicked()
        If Not Me.Enabled Then
            Exit Sub
        End If

        Dim resposta As String = ""

        MyModo.UniqueModoAnterior = UC_Toolstrip.ModoAnterior
        MyModo.UniqueModo = UC_Toolstrip.Modo

        If MyModo.UniqueModo = "SALVAR" Then
            If ComboNome.DropDownStyle = ComboBoxStyle.Simple AndAlso MyModo.UniqueModoAnterior = "NOVO" Then
                If InsereUsuario() Then
                    LimpaCampos_AtivaControles()
                    Desativa_Campos()
                    toolStrip.AfterSuccessfulInsert()
                Else
                    toolStrip.ToolbarItemsState(MyModo.UniqueModoAnterior, False)
                End If
            Else
                If String.IsNullOrWhiteSpace(TxtEmail.Text) Or Not Uteis.RegexValidation.IsEmailValid(TxtEmail.Text) Then
                    Uteis.MsgBoxHelper.Alerta(Me, "Campo de e-mail não pode ser vazio.", "Preenchimento incompleto", TxtEmail)
                    toolStrip.ToolbarItemsState(MyModo.UniqueModoAnterior, False)
                    Exit Sub
                End If
                If Not DAOUsuario.AtualizaUsuario(GetUsuarioForOperation, resposta) Then
                    toolStrip.ToolbarItemsState(MyModo.UniqueModoAnterior, False)
                    Uteis.MsgBoxHelper.Erro(Me, resposta, "Erro")
                Else
                    LimpaCampos_AtivaControles()
                    Desativa_Campos()
                    toolStrip.AfterSuccessfulUpdate()
                End If
            End If

        ElseIf MyModo.UniqueModo = "NOVO" Then
            LimpaCampos_AtivaControles()
            AlternarControle()
            ComboNome.Focus()


        ElseIf MyModo.UniqueModo = "ALTERAR" Then
            ModoAlterar()


        ElseIf MyModo.UniqueModo = "PESQUISAR" Then
            ModoProcurar()
            If MyModo.UniqueModoAnterior = "REVERTER" Then
                ComboNome.SelectedIndex = LstUsuario.FindIndex(Function(u As Usuario) u.CodUsuario = objUsuario.CodUsuario)
            End If

        ElseIf MyModo.UniqueModo = "ANTERIOR" Then
            If ComboNome.SelectedIndex - 1 >= 0 Then
                ComboNome.SelectedIndex -= 1
            End If

        ElseIf MyModo.UniqueModo = "SEGUINTE" Then
            If ComboNome.SelectedIndex + 1 <> ComboNome.Items.Count Then
                ComboNome.SelectedIndex += 1
            End If


        ElseIf MyModo.UniqueModo = "PADRÃO" Then
            LimpaCampos_AtivaControles()
            toolStrip.PagAberta_HabilitarBotoes()
            Desativa_Campos()
        End If

        toolStrip.ToolStrip1.Items("BtnExcluir").Enabled = False
    End Sub

    Private Sub BuscaUsuarioPorCodigo(ByVal codusuario As String)
        Dim resposta As String = ""
        Dim usuario = DAOUsuario.GetUsuario(codusuario, resposta)

        If IsNothing(usuario) Then
            Uteis.MsgBoxHelper.Erro(Me, resposta, "Erro")
            Exit Sub
        End If

        objUsuario = usuario
        toolStrip.EstadoAlterarExcluir(True)
        toolStrip.ToolStrip1.Items("BtnExcluir").Enabled = False
        PreencheCampos(usuario)
    End Sub

    Private Sub PreencheCampos(ByVal usuario As Usuario)
        ComboNome.Text = usuario.NomeCompleto
        TxtEmail.Text = usuario.Email
        TxtLogin.Text = usuario.Login
        TxtSenha.Text = String.Empty
        TxtSenhaConfirmar.Text = String.Empty
        ChkBoxAtivo.Checked = usuario.IsAtivo

        Uteis.ControlsHelper.SetControlsEnabled(Me.Controls)
    End Sub

    Private Sub AlternarControle()
        If MyModo.UniqueModo = "PESQUISAR" Then
            ComboNome.DropDownStyle = ComboBoxStyle.DropDown
            ComboNome.AutoCompleteMode = AutoCompleteMode.Suggest
            TxtSenha.Enabled = False
            TxtSenhaConfirmar.Enabled = False
        ElseIf MyModo.UniqueModo = "NOVO" Then
            ComboNome.AutoCompleteMode = AutoCompleteMode.None
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
            toolStrip.EstadoAlterarExcluir(False)
        End If
    End Sub

    Private Function ValidaSenha() As Boolean
        If Not Uteis.StringHelper.IsNull(TxtSenha.Text) Then
            If Not Uteis.RegexValidation.IsSenhaValida(TxtSenha.Text) Then
                Uteis.MsgBoxHelper.Alerta(Me, "Senha deve conter de 5 a 16 caracteres." + vbNewLine + vbNewLine +
                    "Uma letra maiuscula, uma letra minúscula e um número.", "Senha inválida")
                Return False
            ElseIf Not Uteis.StringHelper.IsNull(TxtSenhaConfirmar.Text) Then
                If TxtSenha.Text <> TxtSenhaConfirmar.Text Then
                    Uteis.MsgBoxHelper.Erro(Me, "Senhas diferentes.", "Erro")
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
        ChkBoxAtivo.Checked = True
        LstUsuario.Clear()
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
        Uteis.ControlsHelper.SetControlsDisabled(GrpBoxInfo.Controls)
        ComboNome.Enabled = True
        TxtLogin.Enabled = False
        GrpBoxCredenciais.Enabled = False

        Uteis.ControlsHelper.SetTextsEmpty(GrpBoxInfo.Controls)
        Uteis.ControlsHelper.SetTextsEmpty(GrpBoxCredenciais.Controls)
        AlternarControle()
        CarregaUsuarios()
        ComboNome.Focus()
    End Sub

    Private Sub Frm_Usuario_EnabledChanged(sender As System.Object, e As System.EventArgs) Handles MyBase.EnabledChanged
        If Me.Enabled Then
            toolStrip.ToolbarItemsState(MyModo.UniqueModo, Not IsNothing(objUsuario))
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

    Private Sub TxtSobrenome_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
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

    'Private Sub ComboNome_TextUpdate(sender As System.Object, e As System.EventArgs) Handles ComboNome.TextUpdate
    '    If ComboNome.Text <> String.Empty Then
    '        ComboNome.SelectedItem = ComboNome.FindStringExact(ComboNome.Text)
    '    End If
    'End Sub

    Private Function ValidaPreenchimento() As Boolean
        Dim ctrl As Control
        If String.IsNullOrWhiteSpace(ComboNome.Text) Then
            Uteis.MsgBoxHelper.Alerta(Me, "Nome do usuário precisa ser preenchido.", "Preenchimento incompleto", ComboNome)
            ctrl = ComboNome
        ElseIf String.IsNullOrWhiteSpace(TxtEmail.Text) Then
            Uteis.MsgBoxHelper.Alerta(Me, "E-mail precisa ser preenchido.", "Preenchimento incompleto", TxtEmail)
            ctrl = TxtEmail
        ElseIf Not Uteis.RegexValidation.IsEmailValid(TxtEmail.Text) Then
            Uteis.MsgBoxHelper.Alerta(Me, "Formato de e-mail inválido.", "Preenchimento Inválido", TxtEmail)
            ctrl = TxtEmail
        ElseIf String.IsNullOrWhiteSpace(TxtLogin.Text) Then
            Uteis.MsgBoxHelper.Alerta(Me, "Login precisa ser preenchido.", "Preenchimento incompleto", TxtLogin)
            ctrl = TxtLogin
        ElseIf String.IsNullOrWhiteSpace(TxtSenha.Text) Then
            Uteis.MsgBoxHelper.Alerta(Me, "Senha precisa ser preenchida.", "Preenchimento incompleto", TxtSenha)
            ctrl = TxtSenha
        ElseIf String.IsNullOrWhiteSpace(TxtSenhaConfirmar.Text) Then
            Uteis.MsgBoxHelper.Alerta(Me, "É necessário confirmar a senha.", "Preenchimento incompleto", TxtSenhaConfirmar)
            ctrl = TxtSenhaConfirmar
        ElseIf LTrim(RTrim(TxtSenha.Text)) <> LTrim(RTrim(TxtSenhaConfirmar.Text)) Then
            Uteis.MsgBoxHelper.Alerta(Me, "As senhas não podem ser diferentes.", "Preenchimento incompleto", TxtSenhaConfirmar)
            ctrl = TxtSenhaConfirmar
        End If
        Return IsNothing(ctrl)
    End Function
End Class