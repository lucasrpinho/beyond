Imports Entidades
Imports Uteis

Public Class Frm_Vendedor

    Private frmPrincipal As Frm_Principal_MDI
    Private LstCargos As New List(Of Cargo)
    Private LstEstados As New List(Of EstadoUF)
    Private LstVendedor As New List(Of Vendedor)
    Private Endereco As Endereco
    Private StrFotoPath As String

    ' Note: os combos possuem um item a mais que as respectivas listas
    ' Determinar o item do combo pelo index do item da lista: index + 1
    ' Determinar o item da lista pelo index do combo: index - 1

    ' Possivelmente será alterado

    Public Sub New(frm As Frm_Principal_MDI)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        frmPrincipal = frm
    End Sub

    Private Sub Frm_Vendedor_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If frmPrincipal.StateTransaction = Uteis.SYSConsts.PENDENTE Then
            Uteis.MsgBoxHelper.AlertaTransacao(Me, frmPrincipal.UC_Toolstrip1.ToolStrip1)
            e.Cancel = True
            Exit Sub
        End If
        RemoveHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
    End Sub

    Private Sub Frm_Vendedor_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Uteis.ControlsHelper.SetControlsDisabled(Me)
        AddHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
        CarregaCargos()
        CarregaEstados()
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
            BuscaVendedorPorCodigo(LstVendedor(ComboNome.SelectedIndex - 1).CodVendedor)
        Else
            Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxAdd.Controls)
            Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxInfo.Controls)
        End If
    End Sub

    Private Sub LimpaCampos_AtivaControles()
        Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxAdd.Controls)
        Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxInfo.Controls)
        Uteis.ControlsHelper.SetControlsEnabled(Me.Controls)
        ClearImage()
    End Sub

    Private Sub Insere()
        Dim vendedor As New Vendedor

        vendedor.CodCargo = LstCargos(ComboCargo.SelectedIndex).CodCargo
        vendedor.Nome = ComboNome.Text.ToUpper
        vendedor.Sobrenome = TxtSobrenome.Text.ToUpper
        vendedor.NomeCompleto = vendedor.Nome + " " + vendedor.Sobrenome

        vendedor.ObjEndereco = New Endereco()
        vendedor.ObjEndereco.CEP = StringHelper.CEPString(TxtCEP.Text)
        vendedor.ObjEndereco.Logradouro = TxtLogradouro.Text.ToUpper
        vendedor.ObjEndereco.Bairro = TxtBairro.Text.ToUpper
        vendedor.ObjEndereco.Cidade = TxtCidade.Text.ToUpper
        vendedor.ObjEndereco.UF = LstEstados.Item(ComboEstado.SelectedIndex - 1).UF
        vendedor.ObjEndereco.Complemento = TxtComplemento.Text.ToUpper
        vendedor.ObjEndereco.NumeroEndereco = Convert.ToInt16(TxtNum.Text)

        vendedor.Observacao = TxtObs.Text.ToUpper
        vendedor.LoginCriacao = loginusuario
        vendedor.Foto = StrFotoPath
        vendedor.IsAtivo = ChkBoxAtivo.Checked

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
        LstCargos.Clear()
        ComboCargo.Items.Clear()

        LstCargos = DAO.DAO.GetCargo(True)

        If Not LstCargos.Count > 0 Then
            MsgBoxHelper.Erro(Me, "O sistema não conseguiu buscar os cargos", "Erro")
            Exit Sub
        End If

        ComboCargo.BeginUpdate()
        For I As Integer = 0 To LstCargos.Count - 1
            ComboCargo.Items.Add(LstCargos(I).Nome)
        Next
        ComboCargo.EndUpdate()
    End Sub

    Private Sub TxtCEP_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCEP.TextChanged
        If TxtCEP.Text.Length >= 9 Then
            Endereco = New Endereco(EnderecoHelper.GetEnderecoViaCEP(TxtCEP.Text))
            PreencheEnderecoAutomaticamente()
        End If
    End Sub

    Private Sub PreencheEnderecoAutomaticamente()
        If Not Endereco Is Nothing Then
            TxtBairro.Text = Endereco.Bairro.ToUpper
            TxtCidade.Text = Endereco.Cidade.ToUpper
            TxtLogradouro.Text = Endereco.Logradouro.ToUpper

            ' Soma com 1 pois o combobox contém um item vazio
            ComboEstado.SelectedIndex = LstEstados.FindIndex(Function(e As EstadoUF) e.UF = Endereco.UF) + 1
        End If
    End Sub

    Private Sub CarregaEstados()
        Dim resposta As String = ""

        LstEstados.Clear()
        ComboEstado.Items.Clear()

        LstEstados = DAO.DAO.GetEstados(resposta)

        If Not LstEstados.Count > 0 Then
            MsgBoxHelper.Erro(Me, resposta, "UF vazio")
        Else
            ComboEstado.BeginUpdate()
            ComboEstado.Items.Add("")
            For Each estado As EstadoUF In LstEstados
                ComboEstado.Items.Add(estado.Nome)
            Next
            ComboEstado.EndUpdate()
        End If
    End Sub

    Private Sub BtnFoto_Click(sender As System.Object, e As System.EventArgs) Handles BtnFoto.Click
        CarregaImagem()
    End Sub

    Private Sub CarregaImagem()
        OpenFileDialog1.Title = "Selecione uma imagem"
        OpenFileDialog1.InitialDirectory = "C:"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Try
            Dim bmp As New Bitmap(OpenFileDialog1.FileName)
            If Not PicBoxFoto.Image Is Nothing Then PicBoxFoto.Image.Dispose()
            PicBoxFoto.SizeMode = PictureBoxSizeMode.StretchImage
            PicBoxFoto.Image = bmp
            StrFotoPath = OpenFileDialog1.FileName
        Catch ex As Exception
            MsgBoxHelper.Erro(Me, ex.Message, "Erro")
        End Try
    End Sub

    Private Sub ToolStrip_ItemClicked()
        If Not Me.Enabled Then
            Exit Sub
        End If
        If UC_Toolstrip.Modo = "SALVAR" Then
            Insere()
        ElseIf UC_Toolstrip.Modo = "PROCURAR" Or UC_Toolstrip.Modo = "NOVO" Then
            AlternarControle()
            LimpaCampos_AtivaControles()
            CarregaVendedores()
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
                If DAO.DAO.AtualizaVendedor(LstVendedor(ComboNome.SelectedIndex - 1).CodVendedor, _
                    "", True, loginusuario) Then
                    frmPrincipal.StateTransaction = Uteis.SYSConsts.PENDENTE
                    Uteis.ControlsHelper.SetControlsDisabled(Me)
                    Uteis.ControlsHelper.ToolBarTransactionOpen(frmPrincipal.UC_Toolstrip1.ToolStrip1)
                End If
            Else
                Exit Sub
            End If
        ElseIf UC_Toolstrip.Modo = "LIMPAR" Then
            LimpaCampos_AtivaControles()
        End If

        AlternarControle()
        If frmPrincipal.StateTransaction Then
            Uteis.ControlsHelper.EnableAllToolBarItens(frmPrincipal.UC_Toolstrip1.ToolStrip1)
        End If
    End Sub

    Private Sub BuscaVendedorPorCodigo(ByVal codvendedor As String)
        Dim resposta As String = ""
        Dim vendedor = DAO.DAO.GetVendedor(codvendedor, resposta)

        If IsNothing(vendedor) Then
            Uteis.MsgBoxHelper.Erro(Me, resposta, "Erro")
            Exit Sub
        End If

        PreencheCampos(vendedor)
    End Sub

    Private Sub PreencheCampos(ByVal vendedor As Vendedor)
        ComboNome.SelectedIndex = LstVendedor.FindIndex(Function(v) v.CodVendedor = vendedor.CodVendedor) + 1
        TxtSobrenome.Text = vendedor.Sobrenome
        TxtCEP.Text = vendedor.ObjEndereco.CEP
        TxtCidade.Text = vendedor.ObjEndereco.Cidade
        TxtComplemento.Text = vendedor.ObjEndereco.Complemento
        TxtLogradouro.Text = vendedor.ObjEndereco.Logradouro
        TxtNum.Text = vendedor.ObjEndereco.NumeroEndereco
        TxtObs.Text = vendedor.Observacao
        ComboEstado.SelectedIndex = LstEstados.FindIndex(Function(e) e.UF = vendedor.ObjEndereco.UF) + 1
        ComboCargo.SelectedIndex = LstCargos.FindIndex(Function(c) c.CodCargo = vendedor.CodCargo)
        PicBoxFoto.ImageLocation = vendedor.Foto
        If PicBoxFoto.Image Is PicBoxFoto.ErrorImage Then
            ClearImage()
        End If
    End Sub

    Private Sub CarregaVendedores()
        If Not UC_Toolstrip.Modo = "PROCURAR" Then
            Exit Sub
        End If
        LstVendedor.Clear()
        ComboNome.Items.Clear()

        Dim resposta As String = ""
        LstVendedor = DAO.DAO.GetVendedor(True, resposta)

        If Not LstVendedor.Count > 0 Then
            MsgBoxHelper.Erro(Me, resposta, "Erro")
        Else
            ComboNome.BeginUpdate()
            ComboNome.Items.Add(String.Empty)
            For Each vendedor As Vendedor In LstVendedor
                ComboNome.Items.Add(vendedor.NomeCompleto)
            Next
            ComboNome.SelectedIndex = 0
            ComboNome.EndUpdate()
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub ComboNome_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ComboNome.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Sub ClearImage()
        If Not PicBoxFoto.Image Is Nothing Then
            PicBoxFoto.Image.Dispose()
        End If
    End Sub
End Class