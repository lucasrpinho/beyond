Imports Uteis
Imports Entidades

Public Class Frm_Produto

    Private frmPrincipal As Frm_Principal_MDI
    Private LstProduto As List(Of Produto)
    Private StrImgPath As String = ""
    Private DAOProd As New DAO.DAO
    Private MyModo As New UC_Toolstrip.UniqueModo
    Private IsOperacaoActive As Boolean = False
    Friend objProduto As Produto

    Public Sub New(ByVal frm As Frm_Principal_MDI)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.frmPrincipal = frm
    End Sub

    Private Sub Frm_Produto_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        DAOProd.ReverterOuCommitar()
        RemoveHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
    End Sub

    Private Sub Frm_Produto_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Uteis.ControlsHelper.SetControlsDisabled(Me)
        AddHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
        MyModo.UniqueModo = "PADRÃO"
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

        IsOperacaoActive = True
        Return True
    End Function

    Private Sub ToolStrip_ItemClicked()
        If Not Me.Enabled Then
            Exit Sub
        End If

        Dim resposta As String = ""

        MyModo.UniqueModo = UC_Toolstrip.Modo

        If MyModo.UniqueModo = "SALVAR" Then
            If objProduto Is Nothing Then
                If Insere() Then
                    Uteis.ControlsHelper.SetControlsDisabled(Me)
                    frmPrincipal.UC_Toolstrip1.AfterSuccessfulInsert()
                Else
                    frmPrincipal.UC_Toolstrip1.ToolbarItemsState("", False)
                End If
            Else
                If Uteis.MsgBoxHelper.MsgTemCerteza(Me, "O registro será modificado. Deseja continuar?", "Alterar") Then
                    CarregaProdutos()
                    If Not DAOProd.AtualizaProduto(GetProdutoForOperation, resposta, False, loginusuario) Then
                        frmPrincipal.UC_Toolstrip1.ToolbarItemsState("", False)
                    Else
                        Uteis.ControlsHelper.SetControlsDisabled(Me)
                        frmPrincipal.UC_Toolstrip1.AfterSuccessfulUpdate()
                        IsOperacaoActive = True
                        objProduto = Nothing
                    End If
                End If
            End If


        ElseIf MyModo.UniqueModo = "ALTERAR" Then
            ControlsHelper.SetControlsEnabled(Me.Controls)
            TxtCategoria.Enabled = False
            PicBoxFoto.Enabled = False
            TxtDesc.Enabled = False

        ElseIf MyModo.UniqueModo = "NOVO" Then
            LimpaCampos_AtivaControles()
            ClearImg()

        ElseIf MyModo.UniqueModo = "PESQUISAR" Then
            LimpaCampos_AtivaControles()
            ControlsHelper.SetControlsDisabled(Me.Controls)
            Dim frmCons As New Frm_ConsProduto(Me)
            frmCons.ShowDialog()
            If objProduto IsNot Nothing Then
                PreencheCampos(objProduto)
                frmPrincipal.UC_Toolstrip1.EstadoAlterarExcluir(True)
            End If


        ElseIf MyModo.UniqueModo = "REVERTER" Then
            If IsOperacaoActive Then
                If Uteis.MsgBoxHelper.MsgTemCerteza(frmPrincipal, "Deseja reverter a operação?", "Reverter") Then
                    DAOProd.ReverterOuCommitar(True)
                    IsOperacaoActive = False
                End If
            End If
            LimpaCampos_AtivaControles()
            Uteis.ControlsHelper.SetControlsDisabled(Me)


        ElseIf MyModo.UniqueModo = "EXCLUIR" Then
            If Uteis.MsgBoxHelper.MsgTemCerteza(frmPrincipal, "Deseja excluir o item?", "Exclusão") Then
                If DAOProd.AtualizaProduto(objProduto, "", True, loginusuario) Then
                    IsOperacaoActive = True
                    LimpaCampos_AtivaControles()
                    ControlsHelper.SetControlsDisabled(Me)
                    frmPrincipal.UC_Toolstrip1.AfterSuccessfulDelete()
                End If
            Else
                Exit Sub
            End If

        End If

    End Sub

    Private Sub PreencheCampos(ByVal prod As Produto)
        TxtCategoria.Text = prod.Categoria
        TxtDesc.Text = prod.Descricao
        TxtPreco.Text = "R$ " + prod.Preco.ToString("C")
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
        If Char.IsLetter(e.KeyChar) Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub ParaRemocaoEAlteracao()
        frmPrincipal.StateTransaction = Uteis.SYSConsts.PENDENTE
        Uteis.ControlsHelper.SetControlsDisabled(Me)

    End Sub

    Private Sub BtnInsereImg_Click(sender As System.Object, e As System.EventArgs) Handles BtnInsereImg.Click
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

    Private Sub TxtPreco_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtPreco.TextChanged
        'If TxtPreco.Text.Contains("R$") Then
        '    TxtPreco.Text += TxtPreco.Text.Replace("R$", "")
        'End If
        'If TxtPreco.Text = String.Empty Then
        '    Exit Sub
        'End If
        'Dim val = Convert.ToDecimal(TxtPreco.Text)
        'TxtPreco.Text = String.Format("{0:N}", val)
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

    Private Sub CarregaProdutos()
        'If Not MyModo.UniqueModo = "PESQUISAR" Then
        '    Exit Sub
        'End If

        'LstProduto.Clear()
        'ComboCateg.Items.Clear()

        'Dim resposta As String = ""

        'LstProduto = DAOProd.GetProdutos(resposta)

        'If Not LstProduto.Count > 0 Then
        '    MsgBoxHelper.Alerta(Me, resposta, "Erro")
        '    Exit Sub
        'End If

        'ComboCateg.BeginUpdate()
        'ComboCateg.Items.AddRange(LstProduto.ToArray)
        'ComboCateg.DisplayMember = "Categoria"
        'ComboCateg.ValueMember = "CodProduto"
        'If MyModo.UniqueModo = "PESQUISAR" Then
        '    ComboCateg.SelectedIndex = 0
        'End If
        'ComboCateg.EndUpdate()

    End Sub

End Class