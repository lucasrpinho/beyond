Imports Uteis
Imports Entidades

Public Class Frm_Produto

    Private frmPrincipal As Frm_Principal_MDI
    Private objProduto As Produto
    Private StrImgPath As String = ""

    Public Sub New(ByVal frm As Frm_Principal_MDI)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.frmPrincipal = frm
    End Sub

    Private Sub Frm_Produto_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'RemoveHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
    End Sub

    Private Sub Frm_Produto_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Uteis.ControlsHelper.SetControlsDisabled(Me)
        'AddHandler frmPrincipal.UC_Toolstrip1.itemclick, AddressOf Me.ToolStrip_ItemClicked
    End Sub

    Private Sub LimpaCampos_AtivaControles()
        Uteis.ControlsHelper.SetTextsEmpty(Me.GrpBoxInfo.Controls)
        Uteis.ControlsHelper.SetControlsEnabled(GrpBoxInfo.Controls)
        ClearImg()
    End Sub

    Private Sub Insere()
        Dim prod As New Produto

        prod.Descricao = TxtDesc.Text.ToUpper
        prod.Categoria = TxtCategoria.Text.ToUpper
        prod.Preco = Convert.ToDecimal(TxtPreco.Text)
        prod.Quantidade = Convert.ToInt32(TxtQtd.Text)
        prod.IsAtivo = ChkAtivo.Checked
        prod.LoginCriacao = loginusuario

        Dim resposta As String = ""

        If Not prod.IsValid(resposta) Then
            MsgBoxHelper.Erro(Me, resposta, "Erro de preenchimento")
            Exit Sub
        End If

        If Not DAO.DAO.InsereProduto(prod, resposta) Then
            Uteis.MsgBoxHelper.Erro(Me, resposta, "Erro")
        Else
            frmPrincipal.StateTransaction = Uteis.SYSConsts.PENDENTE
            'Uteis.Controls.SetTextsEmpty(Me)
            Uteis.ControlsHelper.ToolBarTransactionOpen(frmPrincipal.UC_Toolstrip1.ToolStrip1)
            Uteis.ControlsHelper.SetControlsDisabled(Me)
        End If
    End Sub

    Private Sub ToolStrip_ItemClicked()
        If Not Me.Enabled Then
            Exit Sub
        End If

        Dim resposta As String = ""

        If UC_Toolstrip.Modo = "SALVAR" Then
            Insere()


        ElseIf UC_Toolstrip.Modo = "ATUALIZAR" Then
            If Uteis.MsgBoxHelper.MsgTemCerteza(Me, "O produto será alterado. Deseja continuar?", "Atualizar") Then
                If DAO.DAO.AtualizaProduto(objProduto, resposta, loginusuario) Then
                    ParaRemocaoEAlteracao()
                Else
                    MsgBoxHelper.Erro(Me, resposta, "Erro")
                    Exit Sub
                End If
            Else
                Exit Sub
            End If


        ElseIf UC_Toolstrip.Modo = "PROCURAR" Or UC_Toolstrip.Modo = "NOVO" Then
            LimpaCampos_AtivaControles()


        ElseIf UC_Toolstrip.Modo = "CONFIRMAR" Then
            If frmPrincipal.StateTransaction = Uteis.SYSConsts.PENDENTE Then
                DAO.DAO.ConfirmarOuReverter(True)
                LimpaCampos_AtivaControles()
                frmPrincipal.StateTransaction = Uteis.SYSConsts.FINALIZADO
            End If


        ElseIf UC_Toolstrip.Modo = "ROLLBACK" Then
            If frmPrincipal.StateTransaction = Uteis.SYSConsts.PENDENTE Then
                If Uteis.MsgBoxHelper.MsgTemCerteza(frmPrincipal, "Deseja reverter a operação?", "Reverter") Then
                    DAO.DAO.ConfirmarOuReverter(False)
                    Uteis.ControlsHelper.SetControlsDisabled(Me)
                    LimpaCampos_AtivaControles()
                    frmPrincipal.StateTransaction = Uteis.SYSConsts.FINALIZADO
                Else
                    Exit Sub
                End If
            End If


        ElseIf UC_Toolstrip.Modo = "DELETAR" Then
            If Uteis.MsgBoxHelper.MsgTemCerteza(frmPrincipal, "Deseja deletar o item?", "Deletar") Then
                If DAO.DAO.AtualizaProduto(objProduto, resposta, loginusuario, True) Then
                    ParaRemocaoEAlteracao()
                Else
                    MsgBoxHelper.Erro(Me, resposta, "Erro")
                    Exit Sub
                End If
            Else
                Exit Sub
            End If


        ElseIf UC_Toolstrip.Modo = "LIMPAR" Then
            LimpaCampos_AtivaControles()
        End If

        If frmPrincipal.StateTransaction Then
            Uteis.ControlsHelper.EnableAllToolBarItens(frmPrincipal.UC_Toolstrip1.ToolStrip1)
        End If
    End Sub

    Private Sub PreencheCampos(ByVal prod As Produto)
        TxtCategoria.Text = prod.Categoria
        TxtDesc.Text = prod.Descricao
        TxtPreco.Text = Convert.ToString(prod.Preco)
        TxtQtd.Text = prod.Quantidade.ToString
        ChkAtivo.Checked = prod.IsAtivo
        If IO.File.Exists(prod.Imagem) Then
            PicBoxFoto.ImageLocation = prod.Imagem
        Else
            PicBoxFoto.Image = Nothing
        End If
    End Sub

    Private Sub TxtPreco_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPreco.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
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
        Uteis.ControlsHelper.ToolBarTransactionOpen(frmPrincipal.UC_Toolstrip1.ToolStrip1)
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
        If TxtPreco.Text <> String.Empty Then
            TxtPreco.Text = String.Format("{0:#,##0.00}", Decimal.Parse(TxtPreco.Text))
        End If
    End Sub
End Class