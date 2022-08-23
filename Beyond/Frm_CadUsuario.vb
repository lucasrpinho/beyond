Imports Entidades
Public Class Frm_CadUsuario

    Private frmPrincipal As Frm_Principal_MDI
    Private WithEvents ToolStrip As ToolStrip
    Public Sub New(frm As Form)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        frmPrincipal = frm
    End Sub

    Private Sub Frm_CadUsuario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        SetControlsDisabled()
        Dim _UC As New UC_Toolstrip
        ToolStrip = _UC.ToolStrip1
        ToolStrip.Dock = DockStyle.Bottom
        Me.Controls.Add(ToolStrip)
        ToolStrip.Show()
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
            Uteis.MB.Erro(Me, strError, "Preenchimento incorreto")
            Exit Sub
        End If
        Dim resposta As String = String.Empty
        If Not DAO.DAO.InsertUsuario(usuario, resposta) Then
            Uteis.MB.Erro(Me, resposta, "Erro")
        Else
            SetTextBoxEmpty()
            SetControlsDisabled()
        End If
    End Sub

    Private Sub SetControlsDisabled()
        Dim controls = Me.Controls
        For Each Control As Control In controls
            Control.Enabled = False
        Next
    End Sub

    Private Sub SetTextBoxEmpty()
        Dim txtboxControl = Me.Controls.OfType(Of System.Windows.Forms.TextBox)()
        For Each txtbox As Windows.Forms.TextBox In txtboxControl
            txtbox.Text = ""
        Next
    End Sub

    Private Sub ItemToolClicked(sender As System.Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip.ItemClicked
        If e.ClickedItem Is ToolStrip.Items("BtnNovo") Then
            Dim controls = Me.Controls
            For Each Control As System.Windows.Forms.Control In controls
                Control.Enabled = True
            Next
        ElseIf e.ClickedItem Is ToolStrip.Items("BtnSalvar") Then
            Cadastrar()
        End If
    End Sub

End Class