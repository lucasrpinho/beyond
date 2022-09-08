Imports Entidades
Imports Uteis

Public Class Frm_Vendedor

    Private frmPrincipal As Frm_Principal_MDI
    Private LstCargos As New List(Of Cargo)
    Private LstEstados As New List(Of EstadoUF)
    Private LstVendedor As New List(Of Vendedor)
    Private MyModo As New UC_Toolstrip.UniqueModo
    Private Endereco As Endereco
    Private StrFotoPath As String
    Private DAOVendedor As New DAO.DAO
    Private IsOperacaoActive As Boolean

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

    Private Sub Frm_Vendedor_EnabledChanged(sender As Object, e As System.EventArgs) Handles Me.EnabledChanged
        If Me.Enabled Then
            frmPrincipal.UC_Toolstrip1.ToolbarItemsState(MyModo.UniqueModo)
        End If
    End Sub

    Private Sub Frm_Vendedor_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        DAOVendedor.ReverterOuCommitar()
        RemoveHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
    End Sub

    Private Sub Frm_Vendedor_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Uteis.ControlsHelper.SetControlsDisabled(Me)
        AddHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
        CarregaCargos()
        CarregaEstados()
        MyModo.UniqueModo = "PADRÃO"
    End Sub

    Private Sub AlternarControle()
        If MyModo.UniqueModo = "PESQUISAR" Then
            ComboNome.DropDownStyle = ComboBoxStyle.DropDown
        ElseIf MyModo.UniqueModo = "NOVO" Then
            ComboNome.DropDownStyle = ComboBoxStyle.Simple
        End If
    End Sub

    Private Sub ComboNome_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboNome.SelectedIndexChanged
        If Not Uteis.StringHelper.IsNull(ComboNome.Text) Then
            BuscaVendedorPorCodigo(LstVendedor(ComboNome.SelectedIndex).CodVendedor)
        Else
            Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxEndereco.Controls)
            Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxInfo.Controls)
            frmPrincipal.UC_Toolstrip1.EstadoAlterarExcluir(False)
            PicBoxFoto.Image = Nothing
        End If
    End Sub

    Private Sub LimpaCampos_AtivaControles()
        Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxEndereco.Controls)
        Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxInfo.Controls)
        Uteis.ControlsHelper.SetControlsEnabled(Me.Controls)
        ClearImage()
    End Sub

    Private Sub LimpaCampos_Desativa()
        Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxEndereco.Controls)
        Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxInfo.Controls)
        Uteis.ControlsHelper.SetControlsDisabled(Me)
        ClearImage()
    End Sub

    Private Function Insere() As Boolean
        Dim vendedor As New Vendedor

        vendedor.CodCargo = LstCargos(ComboCargo.SelectedIndex).CodCargo
        vendedor.Nome = ComboNome.Text.ToUpper
        vendedor.Sobrenome = TxtSobrenome.Text.ToUpper
        vendedor.NomeCompleto = vendedor.Nome + " " + vendedor.Sobrenome

        vendedor.ObjEndereco = New Endereco()
        vendedor.ObjEndereco.CEP = StringHelper.NumericOnly(TxtCEP.Text)
        vendedor.ObjEndereco.Logradouro = TxtLogradouro.Text.ToUpper
        vendedor.ObjEndereco.Bairro = TxtBairro.Text.ToUpper
        vendedor.ObjEndereco.Cidade = TxtCidade.Text.ToUpper
        vendedor.ObjEndereco.UF = LstEstados.Item(ComboEstado.SelectedIndex).UF
        vendedor.ObjEndereco.Complemento = TxtComplemento.Text.ToUpper
        vendedor.ObjEndereco.NumeroEndereco = Convert.ToInt16(TxtNum.Text)

        vendedor.Observacao = TxtObs.Text.ToUpper
        vendedor.LoginCriacao = loginusuario
        vendedor.Foto = StrFotoPath
        vendedor.IsAtivo = ChkBoxAtivo.Checked

        Dim strError As String = ""

        If Not vendedor.IsValid(strError) Then
            MsgBoxHelper.Alerta(Me, strError, "Erro de preenchimento")
            Return False
        End If

        Dim resposta As String = ""

        If Not DAOVendedor.InsereVendedor(vendedor, resposta) Then
            Uteis.MsgBoxHelper.Alerta(Me, resposta, "Erro")
            Return False
        End If

        IsOperacaoActive = True
        Return True
    End Function

    Private Sub CarregaCargos()
        LstCargos.Clear()
        ComboCargo.Items.Clear()

        LstCargos = DAOVendedor.GetCargo(True)

        If Not LstCargos.Count > 0 Then
            MsgBoxHelper.Alerta(Me, "O sistema não conseguiu buscar os cargos.", "Erro")
            Exit Sub
        End If

        ComboCargo.BeginUpdate()
        ComboCargo.Items.AddRange(LstCargos.ToArray)
        ComboCargo.DisplayMember = "Nome"
        ComboCargo.ValueMember = "CodCargo"
        If MyModo.UniqueModo = "PESQUISAR" Then
            ComboCargo.SelectedIndex = 0
        End If
        ComboCargo.EndUpdate()
    End Sub

    Private Sub TxtCEP_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCEP.TextChanged
        If TxtCEP.Text.Length >= 9 Then
            Endereco = New Endereco(EnderecoHelper.GetEnderecoViaCEP(TxtCEP.Text))
            If Endereco.ObjEnderecoJson Is Nothing Then
                Endereco = Nothing
                Exit Sub
            End If

            PreencheEnderecoAutomaticamente()
        End If
    End Sub

    Private Sub PreencheEnderecoAutomaticamente()
        If Not Endereco Is Nothing Then
            TxtBairro.Text = Endereco.Bairro.ToUpper
            TxtCidade.Text = Endereco.Cidade.ToUpper
            TxtLogradouro.Text = Endereco.Logradouro.ToUpper

            ' Soma com 1 pois o combobox contém um item vazio
            ComboEstado.SelectedIndex = LstEstados.FindIndex(Function(e As EstadoUF) e.UF = Endereco.UF)
        End If
    End Sub

    Private Sub CarregaEstados()
        Dim resposta As String = ""

        LstEstados.Clear()
        ComboEstado.Items.Clear()

        LstEstados = DAOVendedor.GetEstados(resposta)

        If Not LstEstados.Count > 0 Then
            MsgBoxHelper.Alerta(Me, resposta, "UF vazio")
        Else
            ComboEstado.BeginUpdate()
            ComboEstado.Items.AddRange(LstEstados.ToArray)
            ComboEstado.DisplayMember = "Nome"
            ComboEstado.ValueMember = "UF"
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
#If DEBUG Then
            MsgBoxHelper.Erro(Me, ex.Message, "Erro")
#End If
            MsgBoxHelper.Alerta(Me, "Falha ao inserir foto.", "Erro")
        End Try
    End Sub

    Private Sub ToolStrip_ItemClicked()
        If Not Me.Enabled Then
            Exit Sub
        End If

        Dim resposta As String = ""

        MyModo.UniqueModo = UC_Toolstrip.Modo

        If MyModo.UniqueModo = "SALVAR" Then
            If ComboNome.DropDownStyle = ComboBoxStyle.Simple Then
                If Insere() Then
                    Uteis.ControlsHelper.SetControlsDisabled(Me.Controls)
                    frmPrincipal.UC_Toolstrip1.AfterSuccessfulInsert()
                Else
                    frmPrincipal.UC_Toolstrip1.ToolbarItemsState("", False)
                End If
            Else
                CarregaVendedores()
                If Not DAOVendedor.AtualizaVendedor(ObjVendedorFromList, resposta, False, loginusuario) Then
                    frmPrincipal.UC_Toolstrip1.ToolbarItemsState("", False)
                Else
                    Uteis.ControlsHelper.SetControlsDisabled(Me.Controls)
                    frmPrincipal.UC_Toolstrip1.AfterSuccessfulUpdate()
                    IsOperacaoActive = True
                End If
            End If

        ElseIf MyModo.UniqueModo = "NOVO" Then
            ModoNovo()

        ElseIf MyModo.UniqueModo = "PESQUISAR" Then
            ModoPesquisa()

        ElseIf MyModo.UniqueModo = "ALTERAR" Then
            GrpBoxEndereco.Enabled = True
            ControlsHelper.SetControlsEnabled(GrpBoxEndereco.Controls)
            ControlsHelper.SetControlsEnabled(GrpBoxInfo.Controls)
            ComboNome.Enabled = False
            TxtSobrenome.Enabled = False
            BtnFoto.Enabled = False

        ElseIf MyModo.UniqueModo = "REVERTER" Then
            If IsOperacaoActive Then
                If Uteis.MsgBoxHelper.MsgTemCerteza(frmPrincipal, "Deseja reverter a operação?", "Reverter") Then
                    DAOVendedor.ReverterOuCommitar(True)
                    IsOperacaoActive = False
                End If
            End If
            LimpaCampos_AtivaControles()
            Uteis.ControlsHelper.SetControlsDisabled(Me.Controls)

        ElseIf MyModo.UniqueModo = "EXCLUIR" Then
            If Uteis.MsgBoxHelper.MsgTemCerteza(frmPrincipal, "Deseja excluir o item?", "Exclusão") Then
                If DAOVendedor.AtualizaVendedor(ObjVendedorFromList, "", True, loginusuario) Then
                    IsOperacaoActive = True
                    LimpaCampos_Desativa()
                    frmPrincipal.UC_Toolstrip1.AfterSuccessfulDelete()
                End If
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub BuscaVendedorPorCodigo(ByVal codvendedor As String)
        Dim resposta As String = ""
        Dim vendedor = DAOVendedor.GetVendedor(codvendedor, resposta)

        If IsNothing(vendedor) Then
            Uteis.MsgBoxHelper.Erro(Me, resposta, "Erro")
            Exit Sub
        End If

        frmPrincipal.UC_Toolstrip1.EstadoAlterarExcluir(True)
        PreencheCampos(vendedor)
    End Sub

    Private Sub PreencheCampos(ByVal vendedor As Vendedor)
        ComboNome.SelectedIndex = LstVendedor.FindIndex(Function(v) v.CodVendedor = vendedor.CodVendedor)
        TxtSobrenome.Text = vendedor.Sobrenome
        TxtCEP.Text = vendedor.ObjEndereco.CEP
        TxtBairro.Text = vendedor.ObjEndereco.Bairro
        TxtCidade.Text = vendedor.ObjEndereco.Cidade
        TxtComplemento.Text = vendedor.ObjEndereco.Complemento
        TxtLogradouro.Text = vendedor.ObjEndereco.Logradouro
        TxtNum.Text = vendedor.ObjEndereco.NumeroEndereco
        TxtObs.Text = vendedor.Observacao
        ComboEstado.SelectedIndex = LstEstados.FindIndex(Function(e) e.UF = vendedor.ObjEndereco.UF)
        ComboCargo.SelectedIndex = LstCargos.FindIndex(Function(c) c.CodCargo = vendedor.CodCargo)
        ChkBoxAtivo.Checked = vendedor.IsAtivo
        If IO.File.Exists(vendedor.Foto) Then
            PicBoxFoto.ImageLocation = vendedor.Foto
        Else
            PicBoxFoto.Image = Nothing
        End If
    End Sub

    Private Sub CarregaVendedores()
        If Not MyModo.UniqueModo = "PESQUISAR" Then
            Exit Sub
        End If
        LstVendedor.Clear()
        ComboNome.Items.Clear()

        Dim resposta As String = ""
        LstVendedor = DAOVendedor.GetVendedor(True, resposta)

        If Not LstVendedor.Count > 0 Then
            MsgBoxHelper.Alerta(Me, resposta, "Erro")
        Else
            ComboNome.BeginUpdate()
            ComboNome.Items.AddRange(LstVendedor.ToArray)
            ComboNome.DisplayMember = "Nome"
            ComboNome.ValueMember = "CodVendedor"
            If MyModo.UniqueModo = "PESQUISAR" Then
                ComboNome.SelectedIndex = 0
            End If
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
            PicBoxFoto.Image = Nothing
        End If
    End Sub

    Private Sub ModoPesquisa()
        AlternarControle()
        ClearImage()
        LimpaCampos_Desativa()
        GrpBoxInfo.Enabled = True
        ControlsHelper.SetControlsDisabled(GrpBoxInfo.Controls)
        ComboNome.Enabled = True
        CarregaVendedores()
    End Sub

    Private Function ObjVendedorFromList() As Vendedor
        Dim vendedor As New Vendedor
        If ComboNome.Text <> String.Empty Then
            vendedor = LstVendedor(ComboNome.SelectedIndex)
        End If

        vendedor.CodCargo = LstCargos(ComboCargo.SelectedIndex).CodCargo
        vendedor.ObjEndereco.CEP = StringHelper.NumericOnly(TxtCEP.Text)
        vendedor.ObjEndereco.Logradouro = TxtLogradouro.Text.ToUpper
        vendedor.ObjEndereco.Bairro = TxtBairro.Text.ToUpper
        vendedor.ObjEndereco.Cidade = TxtCidade.Text.ToUpper
        vendedor.ObjEndereco.UF = LstEstados.Item(ComboEstado.SelectedIndex).UF
        vendedor.ObjEndereco.Complemento = TxtComplemento.Text.ToUpper
        vendedor.ObjEndereco.NumeroEndereco = Convert.ToInt16(TxtNum.Text)
        vendedor.Observacao = TxtObs.Text
        vendedor.IsAtivo = ChkBoxAtivo.Checked
        Return vendedor
    End Function

    Private Sub ModoNovo()
        ClearImage()
        ControlsHelper.SetControlsEnabled(Me.Controls)
        ControlsHelper.SetControlsEnabled(GrpBoxEndereco.Controls)
        ControlsHelper.SetControlsEnabled(GrpBoxInfo.Controls)
        ControlsHelper.SetTextsEmpty(GrpBoxInfo.Controls)
        ControlsHelper.SetTextsEmpty(GrpBoxEndereco.Controls)
        AlternarControle()
    End Sub

    Private Sub TxtNum_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNum.KeyPress
        If Char.IsPunctuation(e.KeyChar) Then
            e.KeyChar = ""
        End If
    End Sub
End Class