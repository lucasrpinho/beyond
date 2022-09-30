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
    Private objVendedor As Vendedor
    Private toolStrip As UC_Toolstrip

    Public Sub New(frm As Frm_Principal_MDI)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        frmPrincipal = frm
        toolStrip = frmPrincipal.UC_Toolstrip1
    End Sub

    Private Sub Frm_Vendedor_EnabledChanged(sender As Object, e As System.EventArgs) Handles Me.EnabledChanged
        If Me.Enabled Then
            toolStrip.ToolbarItemsState(MyModo.UniqueModo, , ComboNome.Text <> String.Empty)
        End If
    End Sub

    Private Sub Frm_Vendedor_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        toolStrip.ToolStrip1.Items("BtnInsereImagem").Enabled = False
        RemoveHandler toolStrip.itemclick, AddressOf Me.ToolStrip_ItemClicked
    End Sub

    Private Sub Frm_Vendedor_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        DesativaCampos()
        AddHandler toolStrip.itemclick, AddressOf Me.ToolStrip_ItemClicked
        CarregaEstados()
        MyModo.UniqueModo = "PADRÃO"
    End Sub

    Private Sub AlternarControle()
        If MyModo.UniqueModo = "PESQUISAR" Then
            ComboNome.DropDownStyle = ComboBoxStyle.DropDown
            ComboNome.AutoCompleteMode = AutoCompleteMode.Suggest
            ComboNome.Focus()
        ElseIf MyModo.UniqueModo = "NOVO" Then
            ComboNome.DropDownStyle = ComboBoxStyle.Simple
            ComboNome.AutoCompleteMode = AutoCompleteMode.None
        End If
    End Sub

    Private Sub ComboNome_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboNome.SelectedIndexChanged
        If Not Uteis.StringHelper.IsNull(ComboNome.Text) Then
            If objVendedor IsNot Nothing Then
                objVendedor = Nothing
            End If
            BuscaVendedorPorCodigo(LstVendedor(ComboNome.SelectedIndex).CodVendedor)
        Else
            Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxEndereco.Controls)
            Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxInfo.Controls)
            toolStrip.EstadoAlterarExcluir(False)
            PicBoxFoto.Image = Nothing
        End If
    End Sub

    Private Sub LimpaCampos_AtivaControles()
        Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxEndereco.Controls)
        Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxInfo.Controls)
        Uteis.ControlsHelper.SetControlsEnabled(Me.Controls)
        ChkBoxAtivo.Checked = True
        ClearImage()
    End Sub

    Private Sub LimpaCampos_Desativa()
        Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxEndereco.Controls)
        Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxInfo.Controls)
        Uteis.ControlsHelper.SetControlsDisabled(Me.GrpBoxEndereco.Controls)
        Uteis.ControlsHelper.SetControlsDisabled(Me.GrpBoxInfo.Controls)
        ChkBoxAtivo.Checked = True
        GroupBox1.Enabled = True
        toolStrip.ToolStrip1.Items("BtnInsereImagem").Enabled = False
        ClearImage()
    End Sub

    Private Function Insere() As Boolean

        If Not ValidaCampos() Then
            Return False
        End If

        Dim vendedor As New Vendedor

        vendedor.CodCargo = LstCargos(ComboCargo.SelectedIndex).CodCargo
        vendedor.NomeCompleto = RTrim(ComboNome.Text).ToUpper

        vendedor.ObjEndereco = New Endereco()
        vendedor.ObjEndereco.CEP = StringHelper.NumericOnly(TxtCEP.Text)
        vendedor.ObjEndereco.Logradouro = TxtLogradouro.Text.ToUpper
        vendedor.ObjEndereco.Bairro = TxtBairro.Text.ToUpper
        vendedor.ObjEndereco.Cidade = TxtCidade.Text.ToUpper
        vendedor.ObjEndereco.UF = LstEstados.Item(ComboEstado.SelectedIndex).UF
        vendedor.ObjEndereco.Complemento = TxtComplemento.Text.ToUpper
        vendedor.ObjEndereco.NumeroEndereco = TxtNum.Text

        vendedor.Observacao = TxtObs.Text.ToUpper
        vendedor.Foto = StrFotoPath
        vendedor.IsAtivo = ChkBoxAtivo.Checked

        Dim strError As String = ""

        If Not vendedor.IsValid(strError) Then
            MsgBoxHelper.Alerta(Me, strError, "Erro de preenchimento")
            Return False
        End If

        Dim resposta As String = ""

        If Not DAOVendedor.InsereVendedor(vendedor, resposta, codusuario) Then
            Uteis.MsgBoxHelper.Erro(Me, resposta, "Erro")
            Return False
        End If

        Dim dlgSucc As New Dlg_Success
        dlgSucc.ShowDialog()

        Return True
    End Function

    Private Sub CarregaCargos()
        LstCargos.Clear()
        ComboCargo.Items.Clear()

        LstCargos = DAOVendedor.GetCargo(True, True)

        If Not LstCargos.Count > 0 Then
            MsgBoxHelper.Alerta(Me, "O sistema não encontrou cargos.", "Sem resultados")
            Exit Sub
        End If

        LstCargos.RemoveAll(Function(c) c.IsVendedor = False)

        If Not LstCargos.Count > 0 Then
            MsgBoxHelper.Alerta(Me, "O sistema não encontrou cargo de vendedor.", "Sem resultados")
        End If

        For I As Integer = 0 To LstCargos.Count - 1
            If Not LstCargos(I).IsAtivo Then
                LstCargos(I).Nome += " (INATIVO)"
            End If
        Next

        ComboCargo.BeginUpdate()
        ComboCargo.Items.AddRange(LstCargos.ToArray)
        ComboCargo.DisplayMember = "Nome"
        ComboCargo.ValueMember = "CodCargo"
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

    Private Sub BtnFoto_Click(sender As System.Object, e As System.EventArgs)
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

    Private Sub DesativaCampos()
        Uteis.ControlsHelper.SetControlsDisabled(Me.GrpBoxEndereco.Controls)
        Uteis.ControlsHelper.SetControlsDisabled(Me.GrpBoxInfo.Controls)
    End Sub

    Private Sub ToolStrip_ItemClicked()
        If Not Me.Enabled Then
            Exit Sub
        End If

        Dim resposta As String = ""

        MyModo.UniqueModoAnterior = UC_Toolstrip.ModoAnterior
        MyModo.UniqueModo = UC_Toolstrip.Modo

        If MyModo.UniqueModo = "SALVAR" Then
            If ComboNome.DropDownStyle = ComboBoxStyle.Simple AndAlso Not MyModo.UniqueModoAnterior = "ALTERAR" Then
                If Insere() Then
                    LimpaCampos_Desativa()
                    toolStrip.AfterSuccessfulInsert()
                Else
                    toolStrip.ToolbarItemsState("", False)
                    toolStrip.ToolStrip1.Items("BtnInsereImagem").Enabled = True
                End If
            Else
                If ValidaCampos() AndAlso Uteis.MsgBoxHelper.MsgTemCerteza(Me, "Tem certeza que deseja modificar o registro?", "Alteração") Then
                    Dim vendedor = ObjVendedorFromList()
                    If vendedor Is Nothing Then
                        toolStrip.ToolbarItemsState("", False)
                        Exit Sub
                    End If
                    If Not DAOVendedor.AtualizaVendedor(ObjVendedorFromList, resposta, False, codusuario) Then
                        toolStrip.ToolbarItemsState("", False)
                        MsgBoxHelper.Erro(Me, resposta, "Erro")
                    Else
                        LimpaCampos_Desativa()
                        toolStrip.AfterSuccessfulUpdate()
                    End If
                Else
                    toolStrip.ToolbarItemsState("", False)
                End If
            End If

        ElseIf MyModo.UniqueModo = "NOVO" Then
                ModoNovo()

        ElseIf MyModo.UniqueModo = "PESQUISAR" Then
            If MyModo.UniqueModoAnterior = "REVERTER" Then
                ModoPesquisaPreenchido()
                Exit Sub
            End If
            ModoPesquisa()

        ElseIf MyModo.UniqueModo = "ANTERIOR" Then
                If ComboNome.SelectedIndex - 1 >= 0 Then
                    ComboNome.SelectedIndex -= 1
                End If

        ElseIf MyModo.UniqueModo = "SEGUINTE" Then
                If ComboNome.SelectedIndex + 1 <> ComboNome.Items.Count Then
                    ComboNome.SelectedIndex += 1
                End If


        ElseIf MyModo.UniqueModo = "ALTERAR" Then
                CarregaVendedores()
                ModoAlterar()

        ElseIf MyModo.UniqueModo = "REVERTER" Then
                If Uteis.MsgBoxHelper.MsgTemCerteza(frmPrincipal, "Deseja desfazer as mudanças?", "Reverter") Then
                    ToolStrip_ItemClicked()
                Else
                    Exit Sub
                End If

        ElseIf MyModo.UniqueModo = "EXCLUIR" Then
                If Uteis.MsgBoxHelper.MsgTemCerteza(Me, "Deseja excluir o item?", "Exclusão") Then
                    If DAOVendedor.AtualizaVendedor(ObjVendedorFromList, resposta, True, codusuario) Then
                        toolStrip.AfterSuccessfulDelete()
                        LimpaCampos_Desativa()
                    End If
                    MsgBoxHelper.Msg(Me, resposta, "Exclusão")
                Else
                    toolStrip.ToolbarItemsState("", False, True)
                    Exit Sub
                End If

        ElseIf MyModo.UniqueModo = "PADRÃO" Then
                LimpaCampos_AtivaControles()
                toolStrip.PagAberta_HabilitarBotoes()
                DesativaCampos()

        ElseIf MyModo.UniqueModo = "IMAGEM" Then
                CarregaImagem()
        End If
    End Sub

    Private Sub BuscaVendedorPorCodigo(ByVal codvendedor As String)
        Dim resposta As String = ""
        Dim vendedor = DAOVendedor.GetVendedor(codvendedor, resposta)

        If IsNothing(vendedor) Then
            Uteis.MsgBoxHelper.Erro(Me, resposta, "Erro")
            Exit Sub
        End If

        objVendedor = vendedor
        toolStrip.EstadoAlterarExcluir(True)
        PreencheCampos(vendedor)
    End Sub

    Private Sub PreencheCampos(ByVal vendedor As Vendedor)
        Dim cargo = LstCargos.Find(Function(c As Cargo) c.CodCargo = vendedor.CodCargo)
        Dim estado = LstEstados.Find(Function(e As EstadoUF) e.UF = vendedor.ObjEndereco.UF)
        TxtCEP.Text = vendedor.ObjEndereco.CEP
        TxtBairro.Text = vendedor.ObjEndereco.Bairro
        TxtCidade.Text = vendedor.ObjEndereco.Cidade
        TxtComplemento.Text = vendedor.ObjEndereco.Complemento
        TxtLogradouro.Text = vendedor.ObjEndereco.Logradouro
        TxtNum.Text = vendedor.ObjEndereco.NumeroEndereco
        TxtObs.Text = vendedor.Observacao
        ComboEstado.SelectedItem = estado
        ComboEstado.Text = estado.Nome
        ComboCargo.SelectedItem = cargo
        ComboCargo.Text = cargo.Nome
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
        LstVendedor = DAOVendedor.GetVendedor(True, resposta, True)

        If Not LstVendedor.Count > 0 Then
            MsgBoxHelper.Alerta(Me, "A busca por vendedores não retornou resultados.", "Aviso")
        Else
            ComboNome.BeginUpdate()
            ComboNome.Items.AddRange(LstVendedor.ToArray)
            ComboNome.DisplayMember = "NomeCompleto"
            ComboNome.ValueMember = "CodVendedor"
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
        CarregaCargos()
        CarregaVendedores()
    End Sub

    Private Function ObjVendedorFromList() As Vendedor

        If Not ValidaCampos() Then
            Return Nothing
        End If

        Dim vendedor As New Vendedor
        If ComboNome.Text <> String.Empty Then
            vendedor = objVendedor
        End If

        vendedor.CodCargo = LstCargos.Find(Function(c) c Is ComboCargo.SelectedItem).CodCargo
        vendedor.ObjEndereco.CEP = StringHelper.NumericOnly(TxtCEP.Text)
        vendedor.ObjEndereco.Logradouro = TxtLogradouro.Text.ToUpper
        vendedor.ObjEndereco.Bairro = TxtBairro.Text.ToUpper
        vendedor.ObjEndereco.Cidade = TxtCidade.Text.ToUpper
        vendedor.ObjEndereco.UF = LstEstados.Item(ComboEstado.SelectedIndex).UF
        vendedor.ObjEndereco.Complemento = TxtComplemento.Text.ToUpper
        vendedor.ObjEndereco.NumeroEndereco = TxtNum.Text
        vendedor.Observacao = TxtObs.Text
        vendedor.IsAtivo = ChkBoxAtivo.Checked

        Dim resposta As String = ""

        If Not vendedor.ObjEndereco.IsEnderecoValid(resposta) Then
            MsgBoxHelper.Alerta(Me, resposta, "")
            Return Nothing
        End If

        Return vendedor
    End Function

    Private Sub ModoNovo()
        LstVendedor.Clear()
        ClearImage()
        ControlsHelper.SetControlsEnabled(Me.Controls)
        ControlsHelper.SetControlsEnabled(GrpBoxEndereco.Controls)
        ControlsHelper.SetControlsEnabled(GrpBoxInfo.Controls)
        ControlsHelper.SetTextsEmpty(GrpBoxInfo.Controls)
        ControlsHelper.SetTextsEmpty(GrpBoxEndereco.Controls)
        toolStrip.ToolStrip1.Items("BtnInsereImagem").Enabled = True
        BtnInsereImagem.Enabled = True
        CarregaCargos()
        AlternarControle()
        ComboNome.Focus()
    End Sub

    Private Sub TxtNum_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNum.KeyPress
        If Not RegexValidation.NumEnderecoCaracteres(e.KeyChar.ToString) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub ModoAlterar()
        ControlsHelper.SetControlsEnabled(Me.Controls)
        ControlsHelper.SetControlsEnabled(GrpBoxEndereco.Controls)
        ControlsHelper.SetControlsEnabled(GrpBoxInfo.Controls)
        BtnInsereImagem.Enabled = False
        ComboNome.Enabled = False
        CarregaCargos()
        ComboCargo.SelectedItem = LstCargos.FirstOrDefault(Function(c) c.CodCargo = objVendedor.CodCargo)
    End Sub

    Private Sub PicBoxFoto_Click(sender As System.Object, e As System.EventArgs) Handles PicBoxFoto.Click
        CarregaImagem()
    End Sub

    Private Function ValidaCampos() As Boolean
        Dim ctrl As Control

        If ComboNome.Text = String.Empty Then
            MsgBoxHelper.Alerta(Me, "Nome precisa ser preenchido.", "Alerta", ComboNome)
            ctrl = ComboNome

        ElseIf ComboCargo.Text = String.Empty Then
            MsgBoxHelper.Alerta(Me, "Cargo precisa ser preenchido.", "Alerta", ComboCargo)
            ctrl = ComboCargo

        ElseIf ComboCargo.SelectedIndex = -1 Then
            MsgBoxHelper.Alerta(Me, "Cargo precisa ser preenchido.", "Alerta", ComboCargo)
            ctrl = ComboCargo

        ElseIf Not LstCargos(ComboCargo.SelectedIndex).IsAtivo Then
            MsgBoxHelper.Alerta(Me, "Cargos inativos não podem ser usados no cadastro de vendedores.", "Alerta", ComboCargo)
            ctrl = ComboCargo

        ElseIf PicBoxFoto.Image Is Nothing Then
            MsgBoxHelper.Alerta(Me, "É necessário inserir uma foto para o vendedor.", "Alerta")
            ctrl = PicBoxFoto

        ElseIf Not TxtCEP.MaskCompleted Then
            MsgBoxHelper.Alerta(Me, "CEP inválido.", "Alerta", TxtCEP)
            ctrl = TxtCEP

        ElseIf TxtLogradouro.Text = String.Empty Then
            MsgBoxHelper.Alerta(Me, "Logradouro precisa ser preenchido.", "Alerta", TxtLogradouro)
            ctrl = TxtLogradouro

        ElseIf TxtNum.Text = String.Empty Then
            MsgBoxHelper.Alerta(Me, "Número precisa ser preenchido.", "Alerta", TxtNum)
            ctrl = TxtNum

        ElseIf TxtBairro.Text = String.Empty Then
            MsgBoxHelper.Alerta(Me, "Bairro precisa ser preenchido.", "Alerta", TxtBairro)
            ctrl = TxtBairro

        ElseIf TxtCidade.Text = String.Empty Then
            MsgBoxHelper.Alerta(Me, "Cidade precisa ser preenchida.", "Alerta", TxtCidade)
            ctrl = TxtCidade

        ElseIf ComboEstado.SelectedIndex = -1 Then
            MsgBoxHelper.Alerta(Me, "Estado precisa ser preenchido.", "Alerta", ComboEstado)
            ComboEstado.DroppedDown = True
            ctrl = ComboEstado
        End If

        Return IsNothing(ctrl)
    End Function

    Private Sub BtnInsereImagem_Click(sender As System.Object, e As System.EventArgs) Handles BtnInsereImagem.Click
        CarregaImagem()
    End Sub

    Private Sub ComboCargo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ComboCargo.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub ModoPesquisaPreenchido()
        PreencheCampos(objVendedor)
        GrpBoxInfo.Enabled = True
        ControlsHelper.SetControlsDisabled(GrpBoxInfo.Controls)
        ControlsHelper.SetControlsDisabled(GrpBoxEndereco.Controls)
        ComboNome.Enabled = True
        toolStrip.EstadoAlterarExcluir(True)
    End Sub

End Class