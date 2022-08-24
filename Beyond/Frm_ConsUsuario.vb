Imports Entidades
Imports System.Windows.Forms
Public Class Frm_ConsUsuario

    Private LstUsuarios As List(Of Usuario)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub Frm_ConsUsuario_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub Frm_ConsUsuario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CarregaUsuarios()

        UC_Toolstrip.BtnClick = New EventHandler(Sub() ItemToolClicked())
    End Sub

    Private Sub CarregaUsuarios()
        ComboUsuario.Items.Clear()
        Dim resposta As String = ""

        LstUsuarios = DAO.DAO.GetUsuarios(True, resposta)

        If LstUsuarios.Count > 0 Then
            ComboUsuario.Items.Add(String.Empty)
            For Each usuario As Usuario In LstUsuarios
                ComboUsuario.BeginUpdate()
                ComboUsuario.Items.Add(usuario.NomeCompleto)
                ComboUsuario.EndUpdate()
            Next
            ComboUsuario.SelectedIndex = 0
        End If
    End Sub

    Private Sub ItemToolClicked()

        If UC_Toolstrip.Modo = "CONFIRMAR" Then
            Dim cadusuario = Application.OpenForms.OfType(Of Frm_CadUsuario).FirstOrDefault
            If Not Uteis.StringHelper.IsNull(ComboUsuario.Text) Then
                cadusuario.BuscaUsuarioPorCodigo(LstUsuarios(ComboUsuario.SelectedIndex - 1).CodUsuario)
            Else
                Uteis.MsgBoxHelper.Erro(Me, "Escolha um usuário", "Erro")
            End If
        ElseIf UC_Toolstrip.Modo = "ROLLBACK" Then
            Me.Close()
        ElseIf UC_Toolstrip.Modo = "PROXIMO" Then
            If ComboUsuario.SelectedIndex = ComboUsuario.Items.Count Then
                ComboUsuario.SelectedIndex = 1
            Else
                ComboUsuario.SelectedIndex += 1
            End If
        ElseIf UC_Toolstrip.Modo = "VOLTAR" Then
            If ComboUsuario.SelectedIndex > 0 Then
                ComboUsuario.SelectedIndex -= 1
            End If
        End If
    End Sub
End Class