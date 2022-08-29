Imports Entidades
Imports Uteis

Public Class Frm_Vendedor

    Private frmPrincipal As Frm_Principal_MDI
    Private LstCargos As New List(Of Cargo)
    Private LstEstados As New List(Of Object)
    Private StrFotoPath As String

    Public Sub New(frm As Frm_Principal_MDI)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        frmPrincipal = frm
    End Sub

    Private Sub Frm_Vendedor_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'RemoveHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
    End Sub

    Private Sub Frm_Vendedor_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If frmPrincipal.StateTransaction = Uteis.SYSConsts.PENDENTE Then
            Uteis.MsgBoxHelper.AlertaTransacao(Me, frmPrincipal.UC_Toolstrip1.ToolStrip1)
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub Frm_Vendedor_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Uteis.ControlsHelper.SetControlsEnabled(GrpBoxAdd.Controls)
        Uteis.ControlsHelper.SetControlsEnabled(GrpBoxInfo.Controls)
        'AddHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
        CarregaCargos()
    End Sub

    Private Sub AlternarControle()
        If UC_Toolstrip.Modo = "PROCURAR" Then
            ComboNome.DropDownStyle = ComboBoxStyle.DropDown
        ElseIf UC_Toolstrip.Modo = "NOVO" Then
            ComboNome.DropDownStyle = ComboBoxStyle.Simple
        End If
    End Sub

    Private Sub ComboNome_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboNome.SelectedIndexChanged
        If Not Uteis.StringHelper.IsNull(ComboNome.Text) Then
            'BuscaUsuarioPorCodigo(LstUsuario(ComboNome.SelectedIndex - 1).CodUsuario)
        Else
            Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxAdd.Controls)
            Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxInfo.Controls)
        End If
    End Sub

    Private Sub LimpaCampos_AtivaControles()
        Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxAdd.Controls)
        Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxAdd.Controls)
        Uteis.ControlsHelper.SetControlsEnabled(Me.Controls)
    End Sub

    Private Sub Insere()
        Dim vendedor As New Vendedor
        vendedor.CodCargo = LstCargos(ComboCargo.SelectedIndex).CodCargo
        vendedor.Nome = ComboNome.Text.ToUpper
        vendedor.Sobrenome = TxtSobrenome.Text.ToUpper
        vendedor.NomeCompleto = vendedor.Nome + " " + vendedor.Sobrenome
        'vendedorCEP = TxtCEP.Text
        'vendedor.Logradouro = TxtLogradouro.Text.ToUpper
        'vendedor.Complemento = TxtComplemento.Text.ToUpper
        'vendedor.Observacao = TxtObs.Text.ToUpper
        'vendedor.NumeroEndereco = Convert.ToInt16(TxtNum.Text)
        'vendedor.LoginCriacao = loginusuario
        'vendedor.Bairro = TxtBairro.Text.ToUpper
        vendedor.Foto = StrFotoPath
        vendedor.IsAtivo = ChkBoxAtivo.Checked
        vendedor.Estado = ""

        Dim strError As String = ""

        If Not vendedor.IsValid(strError) Then
            MsgBoxHelper.Erro(Me, strError, "Erro de preenchimento")
            Exit Sub
        End If

        Dim resposta As String = ""

        If Not DAO.DAO.InsereVendedor(vendedor, resposta) Then
            Uteis.MsgBoxHelper.Erro(Me, resposta, "Erro")
        Else
            frmPrincipal.StateTransaction = Uteis.SYSConsts.PENDENTE
            'Uteis.Controls.SetTextsEmpty(Me)
            Uteis.ControlsHelper.ToolBarTransactionOpen(frmPrincipal.UC_Toolstrip1.ToolStrip1)
            Uteis.ControlsHelper.SetControlsDisabled(Me)
        End If
    End Sub

    Private Sub CarregaCargos()
        LstCargos = DAO.DAO.GetCargo(True)

        If Not LstCargos.Count > 0 Then
            MsgBoxHelper.Erro(Me, "O sistema não conseguiu buscar os cargos", "Erro")
            Exit Sub
        End If

        For I As Integer = 0 To LstCargos.Count - 1
            ComboCargo.BeginUpdate()
            ComboCargo.Items.Add(LstCargos(I).Nome)
            ComboCargo.EndUpdate()
        Next
    End Sub

    Private Sub TxtCEP_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCEP.TextChanged
        If TxtCEP.Text.Length >= 9 Then
            Dim enderecoteste = EnderecoHelper.GetEnderecoViaCEP(TxtCEP.Text)
        End If
    End Sub
End Class