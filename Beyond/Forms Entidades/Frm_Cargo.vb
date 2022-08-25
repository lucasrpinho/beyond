Imports Entidades
Imports Uteis
Public Class Frm_Cargo

    Private frmPrincipal As Frm_Principal_MDI
    Private LstCargo As New List(Of Cargo)
    Private WithEvents ToolStrip As ToolStrip

    Public Sub New(frm As Form, _toolstrip As ToolStrip)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        frmPrincipal = frm
        ToolStrip = _toolstrip
    End Sub

    Private Sub Frm_Cargo_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ControlsHelper.SetControlsDisabled(Me)
    End Sub

    Private Sub InsereCargo()
        Dim cargo As Cargo
        cargo.Nome = TxtNome.Text
        cargo.Descricao = TxtDesc.Text.ToUpper
        cargo.IsAtivo = ChkBoxAtivo.Checked
        cargo.IsVendedor = ChkVendedor.Checked
        cargo.LoginCriacao = loginusuario

        Dim strError As String = ""

        If Not cargo.IsValid(strError) Then
            MsgBoxHelper.Erro(Me, strError, "Erro de preenchimento")
            Exit Sub
        End If


    End Sub

    Private Sub LimpaCampos_AtivaControles()
        ControlsHelper.LimpaEAtiva(Me)
    End Sub
End Class