Imports Uteis
Imports Entidades

Public Class Frm_Produto

    Private frmPrincipal As Frm_Principal_MDI
    Private StrImgPath As String = ""
    Private DAOProd As New DAO.DAO
    Private MyModo As New UC_Toolstrip.UniqueModo
    Friend objProduto As Produto


    Public Sub New(ByVal frm As Frm_Principal_MDI)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.frmPrincipal = frm
    End Sub

    Private Sub Frm_Produto_EnabledChanged(sender As Object, e As System.EventArgs) Handles Me.EnabledChanged
        If Me.Enabled Then
            frmPrincipal.UC_Toolstrip1.ToolbarItemsState(MyModo.UniqueModo)
        End If
    End Sub

    Private Sub Frm_Produto_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        frmPrincipal.UC_Toolstrip1.ToolStrip1.Items("BtnInsereImagem").Enabled = False
        RemoveHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
    End Sub

    Private Sub Frm_Produto_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Uteis.ControlsHelper.SetControlsDisabled(Me)
        AddHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
        MyModo.UniqueModo = "PADRÃO"
        PicBoxFoto.Image = Nothing
    End Sub

    Private Sub LimpaCampos_AtivaControles()
        Uteis.ControlsHelper.SetControlsEnabled(Me.Controls)
        Uteis.ControlsHelper.SetControlsEnabled(GrpBoxInfo.Controls)
        Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxInfo.Controls)
        ClearImg()
    End Sub

    Private Function ChecaPreenchimento() As Control
        If TxtCategoria.Text = String.Empty Then
            Return TxtCategoria
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
            MsgBoxHelper.CustomTooltip(Me, controlNaoPreenchido, "Campo não pode ser vazio.", "Campo não foi preenchido")
            Return False
        End If

        prod.Descricao = TxtDesc.Text.ToUpper
        prod.Categoria = TxtCategoria.Text.ToUpper
        prod.Preco = Convert.ToDecimal(StringHelper.CurrencyType(TxtPreco.Text))
        prod.Quantidade = Convert.ToInt32(TxtQtd.Text)
        prod.IsAtivo = ChkAtivo.Checked
        prod.Imagem = StrImgPath
        prod.LoginCriacao = loginusuario

        Dim resposta As String = ""

        If Not prod.IsValid(resposta) Then
            MsgBoxHelper.Alerta(Me, resposta, "Erro de preenchimento")
            Return False
        End If

        If Not DAOProd.InsereProduto(prod, resposta) Then
            Uteis.MsgBoxHelper.Alerta(Me, resposta, "Erro")
            Return False
        End If

        objProduto = prod
        Return True
    End Function

    Private Sub ToolStrip_ItemClicked()
        If Not Me.Enabled Then
            Exit Sub
        End If

        Dim resposta As String = ""

        MyModo.UniqueModo = UC_Toolstrip.Modo

        If MyModo.UniqueModo = "SALVAR" Then
            If UC_Toolstrip.ModoAnterior = "NOVO" Then
                If Insere() Then
                    LimpaCampos_AtivaControles()
                    Uteis.ControlsHelper.SetControlsDisabled(Me.Controls)
                    frmPrincipal.UC_Toolstrip1.AfterSuccessfulInsert()
                Else
                    frmPrincipal.UC_Toolstrip1.ToolbarItemsState("", False)
                    frmPrincipal.UC_Toolstrip1.ToolStrip1.Items("BtnInsereImagem").Enabled = True
                End If
            Else
                If Not DAOProd.AtualizaProduto(GetProdutoForOperation, resposta, loginusuario) Then
                    frmPrincipal.UC_Toolstrip1.ToolbarItemsState("", False)
                    MsgBoxHelper.Alerta(Me, resposta, "Erro")
                Else
                    Uteis.ControlsHelper.SetControlsDisabled(Me.Controls)
                    frmPrincipal.UC_Toolstrip1.AfterSuccessfulUpdate()
                End If
            End If


        ElseIf MyModo.UniqueModo = "ALTERAR" Then
            ModoAlterar()


        ElseIf MyModo.UniqueModo = "NOVO" Then
            LimpaCampos_AtivaControles()
            frmPrincipal.UC_Toolstrip1.ToolStrip1.Items("BtnInsereImagem").Enabled = True
            ClearImg()

        ElseIf MyModo.UniqueModo = "PESQUISAR" Then
            If UC_Toolstrip.ModoAnterior = "REVERTER" Then
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
                If DAOProd.AtualizaProduto(GetProdutoForOperation, "", loginusuario, True) Then
                    LimpaCampos_AtivaControles()
                    ControlsHelper.SetControlsDisabled(Me.Controls)
                    frmPrincipal.UC_Toolstrip1.AfterSuccessfulDelete()
                End If
            Else
                Exit Sub
            End If

        ElseIf MyModo.UniqueModo = "IMAGEM" Then
            CarregaImagem()

        ElseIf MyModo.UniqueModo = "PADRÃO" Then
        LimpaCampos_AtivaControles()
        frmPrincipal.UC_Toolstrip1.PagAberta_HabilitarBotoes()
        Uteis.ControlsHelper.SetControlsDisabled(Me.Controls)
        End If

    End Sub

    Private Sub PreencheCampos(ByVal prod As Produto)
        TxtCategoria.Text = prod.Categoria
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
        Dim val = TxtPreco.Text
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

        If TxtCategoria.Text <> String.Empty AndAlso TxtDesc.Text <> String.Empty Then
            prod = objProduto
        End If

        prod.Preco = Convert.ToDecimal(StringHelper.CurrencyType(TxtPreco.Text))
        prod.Quantidade = TxtQtd.Text
        prod.IsAtivo = ChkAtivo.Checked

        Return prod
    End Function

    Private Sub ModoAlterar()
        ControlsHelper.SetControlsEnabled(Me.Controls)
        TxtCategoria.Enabled = False
        PicBoxFoto.Enabled = False
        TxtDesc.Enabled = False
    End Sub

    Private Sub ModoPesquisa()
        objProduto = Nothing
        LimpaCampos_AtivaControles()
        ControlsHelper.SetControlsDisabled(Me.Controls)
        Dim frmCons As New Frm_ConsProduto(Me)
        frmCons.ShowDialog()
        If objProduto IsNot Nothing Then
            PreencheCampos(objProduto)
            frmPrincipal.UC_Toolstrip1.EstadoAlterarExcluir(True)
            frmPrincipal.UC_Toolstrip1.ToolStrip1.Items("BtnAnterior").Enabled = False
            frmPrincipal.UC_Toolstrip1.ToolStrip1.Items("BtnSeguinte").Enabled = False
        Else
            frmPrincipal.UC_Toolstrip1.PagAberta_HabilitarBotoes()
        End If
    End Sub

    Private Sub ModoPesquisaPreenchido()
        LimpaCampos_AtivaControles()
        ControlsHelper.SetControlsDisabled(Me.Controls)
        PreencheCampos(objProduto)
        frmPrincipal.UC_Toolstrip1.EstadoAlterarExcluir(True)
        frmPrincipal.UC_Toolstrip1.ToolStrip1.Items("BtnAnterior").Enabled = False
        frmPrincipal.UC_Toolstrip1.ToolStrip1.Items("BtnSeguinte").Enabled = False
    End Sub

End Class