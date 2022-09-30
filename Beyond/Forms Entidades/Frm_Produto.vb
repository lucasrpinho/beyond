Imports Uteis
Imports Entidades

Public Class Frm_Produto

    Private frmPrincipal As Frm_Principal_MDI
    Private StrImgPath As String = ""
    Private DAOProd As New DAO.DAO
    Private MyModo As New UC_Toolstrip.UniqueModo
    Friend objProduto As Produto
    Private LstCategoria As List(Of String)
    Private toolStrip As UC_Toolstrip


    Public Sub New(ByVal frm As Frm_Principal_MDI)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.frmPrincipal = frm
        Me.toolStrip = frmPrincipal.UC_Toolstrip1
    End Sub

    Private Sub Frm_Produto_EnabledChanged(sender As Object, e As System.EventArgs) Handles Me.EnabledChanged
        If Me.Enabled Then
            toolStrip.ToolbarItemsState(MyModo.UniqueModo)
        End If
    End Sub

    Private Sub Frm_Produto_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        toolStrip.ToolStrip1.Items("BtnInsereImagem").Enabled = False
        RemoveHandler toolStrip.itemclick, AddressOf Me.ToolStrip_ItemClicked
    End Sub

    Private Sub Frm_Produto_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Uteis.ControlsHelper.SetControlsDisabled(GrpBoxInfo.Controls)
        AddHandler toolStrip.itemclick, AddressOf Me.ToolStrip_ItemClicked
        MyModo.UniqueModo = "PADRÃO"
        PicBoxFoto.Image = Nothing
        CarregaCategoria()
    End Sub

    Private Sub CarregaCategoria()
        ComboCategoria.Items.Clear()
        If LstCategoria IsNot Nothing Then
            LstCategoria.Clear()
        End If

        Dim resposta As String = ""

        LstCategoria = DAOProd.GetCategoriasProduto(resposta)

        If Not LstCategoria.Count > 0 Then
            Exit Sub
        End If

        For Each Str As String In LstCategoria
            ComboCategoria.Items.Add(Str)
        Next
    End Sub

    Private Sub LimpaCampos_AtivaControles()
        Uteis.ControlsHelper.SetControlsEnabled(Me.Controls)
        Uteis.ControlsHelper.SetControlsEnabled(GrpBoxInfo.Controls)
        Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxInfo.Controls)
        ChkAtivo.Checked = True
        ClearImg()
    End Sub

    Private Sub Desativa_Campos()
        Uteis.ControlsHelper.SetControlsDisabled(GrpBoxInfo.Controls)
    End Sub

    Private Function ChecaPreenchimento() As Control
        If ComboCategoria.Text = String.Empty Then
            Return ComboCategoria
        ElseIf TxtNome.Text = String.Empty Then
            Return TxtNome
        ElseIf TxtDesc.Text = String.Empty Then
            Return TxtDesc
        ElseIf TxtPreco.Text = String.Empty Then
            Return TxtPreco
        ElseIf TxtQtd.Text = String.Empty Then
            Return TxtQtd
        Else
            Return Nothing
        End If
    End Function

    Private Function Insere() As Boolean
        Dim prod As New Produto
        Dim controlNaoPreenchido = ChecaPreenchimento()

        If controlNaoPreenchido IsNot Nothing Then
            MsgBoxHelper.CustomTooltip(controlNaoPreenchido, controlNaoPreenchido, "Campo não pode ser vazio.", "Preenchimento incompleto")
            controlNaoPreenchido.Focus()
            Return False
        End If

        prod.Nome = TxtNome.Text.ToUpper
        prod.Descricao = TxtDesc.Text.ToUpper
        prod.Categoria = ComboCategoria.Text.ToUpper
        prod.Preco = Convert.ToDecimal(StringHelper.CurrencyType(TxtPreco.Text))
        prod.Quantidade = Convert.ToInt32(TxtQtd.Text)
        prod.IsAtivo = ChkAtivo.Checked
        prod.Imagem = StrImgPath

        Dim resposta As String = ""

        If Not prod.IsValid(resposta) Then
            MsgBoxHelper.Alerta(Me, resposta, "Erro de preenchimento")
            Return False
        End If

        If Not DAOProd.InsereProduto(prod, resposta, codusuario) Then
            Uteis.MsgBoxHelper.Alerta(Me, resposta, "Erro")
            Return False
        End If

        Dim dlgSucc As New Dlg_Success
        dlgSucc.ShowDialog()

        objProduto = prod
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
            If MyModo.UniqueModoAnterior = "NOVO" Then
                If Insere() Then
                    LimpaCampos_AtivaControles()
                    If objProduto IsNot Nothing Then
                        objProduto = Nothing
                    End If
                    Uteis.ControlsHelper.SetControlsDisabled(GrpBoxInfo.Controls)
                    toolStrip.AfterSuccessfulInsert()
                Else
                    toolStrip.ToolbarItemsState("", False)
                    toolStrip.ToolStrip1.Items("BtnInsereImagem").Enabled = True
                End If
            Else
                If Uteis.MsgBoxHelper.MsgTemCerteza(Me, "Tem certeza que deseja modificar o registro?", "Alteração") Then
                    If Not DAOProd.AtualizaProduto(GetProdutoForOperation, resposta, codusuario) Then
                        toolStrip.ToolbarItemsState("", False)
                        MsgBoxHelper.Alerta(Me, resposta, "Erro")
                    Else
                        LimpaCampos_AtivaControles()
                        Uteis.ControlsHelper.SetControlsDisabled(GrpBoxInfo.Controls)
                        toolStrip.AfterSuccessfulUpdate()
                    End If
                Else
                    toolStrip.ToolbarItemsState("", False, True)
                    toolStrip.BtnPesquisar.Enabled = True
                End If
            End If


        ElseIf MyModo.UniqueModo = "ALTERAR" Then
                ModoAlterar()


        ElseIf MyModo.UniqueModo = "NOVO" Then
                CarregaCategoria()
                LimpaCampos_AtivaControles()
                toolStrip.ToolStrip1.Items("BtnInsereImagem").Enabled = True
                ClearImg()
                ComboCategoria.Focus()

        ElseIf MyModo.UniqueModo = "PESQUISAR" Then
                toolStrip.BtnPesquisar.Enabled = True
                If MyModo.UniqueModoAnterior = "REVERTER" Then
                    ModoPesquisaPreenchido()
                    Exit Sub
                End If
                ModoPesquisa()


        ElseIf MyModo.UniqueModo = "REVERTER" Then
                If Uteis.MsgBoxHelper.MsgTemCerteza(frmPrincipal, "Deseja desfazer as mudanças?", "Reverter") Then
                    ToolStrip_ItemClicked()
                Else
                    Exit Sub
                End If


        ElseIf MyModo.UniqueModo = "EXCLUIR" Then
                If Uteis.MsgBoxHelper.MsgTemCerteza(frmPrincipal, "Deseja excluir o item?", "Exclusão") Then
                    If DAOProd.AtualizaProduto(GetProdutoForOperation, resposta, codusuario, True) Then
                        LimpaCampos_AtivaControles()
                        Uteis.ControlsHelper.SetControlsDisabled(GrpBoxInfo.Controls)
                        toolStrip.AfterSuccessfulDelete()
                    End If
                    MsgBoxHelper.Msg(Me, resposta, "Informação")
            Else
                toolStrip.ToolbarItemsState("", False, True)
                toolStrip.BtnPesquisar.Enabled = True
                Exit Sub
                End If

        ElseIf MyModo.UniqueModo = "IMAGEM" Then
                CarregaImagem()

        ElseIf MyModo.UniqueModo = "PADRÃO" Then
                LimpaCampos_AtivaControles()
                toolStrip.PagAberta_HabilitarBotoes()
                Uteis.ControlsHelper.SetControlsDisabled(GrpBoxInfo.Controls)
        End If

    End Sub

    Private Sub PreencheCampos(ByVal prod As Produto)
        ComboCategoria.Text = prod.Categoria
        TxtNome.Text = prod.Nome
        TxtDesc.Text = prod.Descricao
        TxtPreco.Text = prod.Preco.ToString("C")
        TxtQtd.Text = prod.Quantidade.ToString
        ChkAtivo.Checked = prod.IsAtivo
        If IO.File.Exists(prod.Imagem) Then
            PicBoxFoto.ImageLocation = prod.Imagem
        Else
            PicBoxFoto.Image = Nothing
        End If
    End Sub

    Private Sub TxtPreco_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPreco.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso Not e.KeyChar = "," Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtQtd_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtQtd.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsSeparator(e.KeyChar) _
            Or e.KeyChar = "," Then
            e.KeyChar = ""
        End If
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
            StrImgPath = OpenFileDialog1.FileName
        Catch ex As Exception
            MsgBoxHelper.Erro(Me, ex.Message, "Erro")
        End Try
    End Sub

    Private Sub ClearImg()
        If Not PicBoxFoto.Image Is Nothing Then
            PicBoxFoto.Image = Nothing
        End If
    End Sub

    Private Sub TxtPreco_Leave(sender As System.Object, e As System.EventArgs) Handles TxtPreco.Leave
        Dim val = StringHelper.PrecoFormatted(TxtPreco.Text)
        If val <> String.Empty Then
            TxtPreco.Text = Decimal.Parse(val).ToString("C")
        End If
    End Sub

    Private Sub TxtPreco_Enter(sender As System.Object, e As System.EventArgs) Handles TxtPreco.Enter
        If TxtPreco.Text.Contains("R$") Then
            TxtPreco.Text = TxtPreco.Text.Replace("R$", "").Trim
        End If
    End Sub

    Private Function GetProdutoForOperation() As Produto
        Dim prod As New Produto

        If ComboCategoria.Text <> String.Empty AndAlso TxtDesc.Text <> String.Empty Then
            prod = objProduto
        End If

        prod.Categoria = ComboCategoria.Text
        prod.Nome = TxtNome.Text
        prod.Preco = Convert.ToDecimal(StringHelper.CurrencyType(TxtPreco.Text))
        prod.Descricao = TxtDesc.Text
        prod.Quantidade = TxtQtd.Text
        prod.IsAtivo = ChkAtivo.Checked

        Return prod
    End Function

    Private Sub ModoAlterar()
        ControlsHelper.SetControlsEnabled(Me.GrpBoxInfo.Controls)
        PicBoxFoto.Enabled = False
        BtnInsereImagem.Enabled = False
    End Sub

    Private Sub ModoPesquisa()
        objProduto = Nothing
        LimpaCampos_AtivaControles()
        Uteis.ControlsHelper.SetControlsDisabled(GrpBoxInfo.Controls)
        Dim frmCons As New Frm_ConsProduto(Me)
        frmCons.ShowDialog()
        If objProduto IsNot Nothing Then
            PreencheCampos(objProduto)
            toolStrip.EstadoAlterarExcluir(True)
            toolStrip.ToolStrip1.Items("BtnAnterior").Enabled = False
            toolStrip.ToolStrip1.Items("BtnSeguinte").Enabled = False
        Else
            toolStrip.PagAberta_HabilitarBotoes()
        End If
    End Sub

    Private Sub ModoPesquisaPreenchido()
        LimpaCampos_AtivaControles()
        Uteis.ControlsHelper.SetControlsDisabled(GrpBoxInfo.Controls)
        PreencheCampos(objProduto)
        toolStrip.EstadoAlterarExcluir(True)
        toolStrip.ToolStrip1.Items("BtnAnterior").Enabled = False
        toolStrip.ToolStrip1.Items("BtnSeguinte").Enabled = False
    End Sub

    Private Sub PicBoxFoto_Click(sender As System.Object, e As System.EventArgs) Handles PicBoxFoto.Click
        CarregaImagem()
    End Sub

    Private Sub BtnInsereImagem_Click(sender As System.Object, e As System.EventArgs) Handles BtnInsereImagem.Click
        CarregaImagem()
    End Sub

    Private Sub ComboCategoria_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ComboCategoria.KeyPress
        If Char.IsPunctuation(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Then
            e.KeyChar = ""
            e.Handled = True
        Else
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub
End Class