Imports Entidades
Imports Uteis
Public Class Frm_Principal_MDI

    Private usuario As Usuario
    Public Modo As String
    Public StateTransaction As Boolean = True

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal usuario As Usuario)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.usuario = usuario
        loginusuario = usuario.Login
    End Sub

    Private Sub Frm_Principal_MDI_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

    Private Sub Frm_Principal_MDI_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TSL_Login.Text = loginusuario
        TSL_Data.Text = DateTime.Now.ToLongDateString
        LblOla.Text = "Olá, " + usuario.NomeCompleto
    End Sub

    Private Sub TimerClock_Tick(sender As System.Object, e As System.EventArgs) Handles TimerClock.Tick
        TSL_Hora.Text = DateTime.Now.ToString("HH:mm:ss")
    End Sub

    Private Sub SairToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SairToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub SobreToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SobreToolStripMenuItem.Click
        Dim FrmSobre As New Frm_Sobre
        If Not Application.OpenForms.OfType(Of Frm_Sobre).Any Then
            FrmSobre.ShowDialog(Me)
        End If
    End Sub

    Private Sub Frm_Principal_MDI_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Uteis.MsgBoxHelper.MsgTemCerteza(Me) Then
            Cursor.Current = Cursors.WaitCursor
            System.Threading.Thread.Sleep(2000)
            e.Cancel = False
            Else
                e.Cancel = True
                Exit Sub
            End If
            'If e.CloseReason = CloseReason.ApplicationExitCall Then
            '    e.Cancel = False
            'ElseIf e.CloseReason = CloseReason.UserClosing Then
            '    e.Cancel = False
            'End If
    End Sub

    Private Sub FecharSelecionadaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FecharSelecionadaMenu.Click
        If TCPrincipal.TabPages.Count > 0 Then
            Dim page = TCPrincipal.TabPages(TCPrincipal.SelectedIndex)
            Application.OpenForms.Item(page.Controls.OfType(Of Form).LastOrDefault.Name).Close()
            TCPrincipal.TabPages.Remove(TCPrincipal.SelectedTab)
            If TCPrincipal.TabCount > 0 Then
                TCPrincipal.SelectTab(TCPrincipal.TabPages.Count - 1)
            End If
        End If
    End Sub

    Private Sub TCPrincipal_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles TCPrincipal.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If TCPrincipal.TabPages.Count > 0 Then
                ContextMenuStrip1.Show(TCPrincipal, e.Location)
            End If
            For I As Integer = 0 To TCPrincipal.TabPages.Count - 1
                If TCPrincipal.GetTabRect(I).Contains(e.Location) Then
                    TCPrincipal.SelectTab(TCPrincipal.TabPages(I))
                End If
            Next
        End If
    End Sub

    Private Sub UsuarioMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UsuarioMenuItem.Click
        AbreUsuarioPag()
    End Sub

    Private Sub ToolStripMenuFecharUma_Click(sender As System.Object, e As System.EventArgs) Handles FecharUmaCtxMenu.Click
        If TCPrincipal.TabPages.Count > 0 Then
            Dim page = TCPrincipal.TabPages(TCPrincipal.SelectedIndex)
            Application.OpenForms(page.Controls.OfType(Of Form).FirstOrDefault.Name).Close()
            TCPrincipal.TabPages.Remove(TCPrincipal.SelectedTab)
            If TCPrincipal.TabCount > 0 Then
                TCPrincipal.SelectTab(TCPrincipal.TabPages.Count - 1)
            End If
        End If
    End Sub

    Private Sub ToolStripMenuFecharTodas_Click(sender As System.Object, e As System.EventArgs) Handles FecharTodasCtxMenu.Click
        If TCPrincipal.TabPages.Count > 0 Then
            For I As Integer = TCPrincipal.TabPages.Count - 1 To 0 Step -1
                TCPrincipal.TabPages(I).Controls.OfType(Of Form).FirstOrDefault.Dispose()
                TCPrincipal.TabPages.RemoveAt(I)
            Next
        End If
        Me.UC_Toolstrip1.DesabilitarItens()
    End Sub

    Private Sub CargosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CargosToolStripMenuItem.Click
        AbreCargoPag()
    End Sub

    Private Sub FecharTodasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FecharTodasMenu.Click
        If TCPrincipal.TabPages.Count > 0 Then
            For I As Integer = TCPrincipal.TabPages.Count - 1 To 0 Step -1
                TCPrincipal.TabPages(I).Controls.OfType(Of Form).FirstOrDefault.Dispose()
                TCPrincipal.TabPages.RemoveAt(I)
            Next
        End If
        Me.UC_Toolstrip1.DesabilitarItens()
    End Sub

    Private Sub TCPrincipal_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TCPrincipal.SelectedIndexChanged
        'If TCPrincipal.TabPages.Count > 1 Then
        '    Dim frm = TCPrincipal.SelectedTab.Controls.OfType(Of Form).FirstOrDefault
        '    frm.Enabled = True
        '    For I As Integer = 0 To TCPrincipal.TabPages.Count - 1
        '        Dim otherFrms = TCPrincipal.TabPages(I).Controls.OfType(Of Form).LastOrDefault
        '        otherFrms.Enabled = False
        '    Next
        'End If
    End Sub

    Private Sub TCPrincipal_Selected(sender As System.Object, e As System.Windows.Forms.TabControlEventArgs) Handles TCPrincipal.Selected
        If TCPrincipal.TabPages.Count > 0 Then
            If e.Action = TabControlAction.Selecting Or e.Action = TabControlAction.Selected Then
                Dim frm = TCPrincipal.SelectedTab.Controls.OfType(Of Form).FirstOrDefault
                frm.Enabled = True
                For i As Integer = 0 To TCPrincipal.TabPages.Count - 1
                    If Not TCPrincipal.TabPages(i) Is TCPrincipal.SelectedTab Then
                        If TCPrincipal.TabPages(i).Controls.OfType(Of Form).FirstOrDefault IsNot Nothing Then
                            TCPrincipal.TabPages(i).Controls.OfType(Of Form).FirstOrDefault.Enabled = False
                        End If
                    End If
                Next
            End If
        Else
            TCPrincipal.Visible = False
            UC_Toolstrip1.DesabilitarItens()
        End If
    End Sub

    Private Sub VendedorToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VendedorToolStripMenuItem.Click
        AbreVendedorPag()
    End Sub

    Private Sub BtnUsuario_Click(sender As System.Object, e As System.EventArgs)
        AbreUsuarioPag()
    End Sub

    Private Sub AbreUsuarioPag()
        Dim page = TCPrincipal.TabPages("Frm_Usuario")
        If Not page Is Nothing Then
            TCPrincipal.SelectTab(page)
        Else
            Dim Frm As New Frm_Usuario(Me)
            Dim TP As New TabPage
            TP.Name = Frm.Name
            Frm.TopLevel = False
            Frm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Frm.MdiParent = Me
            Frm.Dock = DockStyle.Fill
            TP.Controls.Add(Frm)
            TP.Tag = Frm
            TP.Text = Frm.Text
            TCPrincipal.TabPages.Add(TP)
            TCPrincipal.BringToFront()
            TCPrincipal.Visible = True
            Frm.Show()
            UC_Toolstrip1.PagAberta_HabilitarBotoes()
            Me.Refresh()
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)
        AbreCargoPag()
    End Sub

    Private Sub AbreCargoPag()
        Dim page = TCPrincipal.TabPages("Frm_Cargo")
        If Not page Is Nothing Then
            TCPrincipal.SelectTab(page)
        Else
            Dim Frm As New Frm_Cargo(Me)
            Dim TP As New TabPage
            Frm.TopLevel = False
            Frm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Frm.MdiParent = Me
            Frm.Dock = DockStyle.Fill
            TP.Controls.Add(Frm)
            TP.Tag = Frm
            TP.Text = Frm.Text
            TP.BackColor = Frm.BackColor
            TP.Name = Frm.Name
            TCPrincipal.TabPages.Add(TP)
            TCPrincipal.SelectedTab = TP
            TCPrincipal.BringToFront()
            TCPrincipal.Visible = True
            UC_Toolstrip1.PagAberta_HabilitarBotoes()
            Frm.Show()
            Me.Refresh()
        End If
    End Sub

    Private Sub AbreVendedorPag()
        Dim page = TCPrincipal.TabPages("Frm_Vendedor")
        If Not page Is Nothing Then
            TCPrincipal.SelectTab(page)
        Else
            Dim Frm As New Frm_Vendedor(Me)
            Dim TP As New TabPage
            Frm.TopLevel = False
            Frm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Frm.MdiParent = Me
            Frm.Dock = DockStyle.Fill
            TP.Controls.Add(Frm)
            TP.Tag = Frm
            TP.Text = Frm.Text
            TP.BackColor = Frm.BackColor
            TP.Name = Frm.Name
            TCPrincipal.TabPages.Add(TP)
            TCPrincipal.SelectTab(TP)
            TCPrincipal.BringToFront()
            TCPrincipal.Visible = True
            Me.UC_Toolstrip1.PagAberta_HabilitarBotoes()
            Frm.Show()
            Me.Refresh()
        End If
    End Sub

    Private Sub BtnVendedor_Click(sender As System.Object, e As System.EventArgs)
        AbreVendedorPag()
    End Sub

    Private Sub BtnCliente_Click(sender As System.Object, e As System.EventArgs)
        AbreClientePag()
    End Sub

    Private Sub AbreClientePag()
        Dim page = TCPrincipal.TabPages("Frm_Cliente")
        If Not page Is Nothing Then
            TCPrincipal.SelectTab(page)
        Else
            Dim Frm As New Frm_Cliente(Me)
            Dim TP As New TabPage
            Frm.TopLevel = False
            Frm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Frm.MdiParent = Me
            Frm.Dock = DockStyle.Fill
            TP.Controls.Add(Frm)
            TP.Tag = Frm
            TP.Text = Frm.Text
            TP.BackColor = Frm.BackColor
            TP.Name = Frm.Name
            TCPrincipal.TabPages.Add(TP)
            TCPrincipal.SelectTab(TP)
            TCPrincipal.BringToFront()
            TCPrincipal.Visible = True
            UC_Toolstrip1.PagAberta_HabilitarBotoes()
            Frm.Show()
            Me.Refresh()
        End If
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ClientesToolStripMenuItem.Click
        AbreClientePag()
    End Sub

    Private Sub BtnProduto_Click(sender As System.Object, e As System.EventArgs)
        AbreProdutoPag()
    End Sub

    Private Sub AbreProdutoPag()
        Dim page = TCPrincipal.TabPages("Frm_Produto")
        If Not page Is Nothing Then
            TCPrincipal.SelectTab(page)
        Else
            Dim Frm As New Frm_Produto(Me)
            Dim TP As New TabPage
            Frm.TopLevel = False
            Frm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Frm.MdiParent = Me
            Frm.Dock = DockStyle.Fill
            TP.Controls.Add(Frm)
            TP.Tag = Frm
            TP.Text = Frm.Text
            TP.BackColor = Frm.BackColor
            TP.Name = Frm.Name
            TCPrincipal.TabPages.Add(TP)
            TCPrincipal.SelectTab(TP)
            TCPrincipal.BringToFront()
            TCPrincipal.Visible = True
            UC_Toolstrip1.PagAberta_HabilitarBotoes()
            Frm.Show()
            Me.Refresh()
        End If
    End Sub

    Private Sub ProdutosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ProdutosToolStripMenuItem.Click
        AbreProdutoPag()
    End Sub

    Private Sub AbrePedidoPag()
        Dim page = TCPrincipal.TabPages("Frm_Pedido")
        If Not page Is Nothing Then
            TCPrincipal.SelectTab(page)
        Else
            Dim Frm As New Frm_Pedido(Me)
            Dim TP As New TabPage
            TP.Name = Frm.Name
            Frm.TopLevel = False
            Frm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Frm.MdiParent = Me
            Frm.Dock = DockStyle.Fill
            TP.Controls.Add(Frm)
            TP.Tag = Frm
            TP.Text = Frm.Text
            TCPrincipal.TabPages.Add(TP)
            TCPrincipal.SelectTab(TP)
            TCPrincipal.BringToFront()
            TCPrincipal.Visible = True
            Frm.Show()
            UC_Toolstrip1.PagAberta_HabilitarBotoes()
            Me.Refresh()
        End If
    End Sub

    Private Sub BtnPedido_Click(sender As System.Object, e As System.EventArgs)
        AbrePedidoPag()
    End Sub

    Private Sub PedidoToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles PedidoToolStripMenuItem2.Click
        AbrePedidoPag()
    End Sub

    Private Sub BtnExpandir_Click(sender As System.Object, e As System.EventArgs) Handles BtnExpandir.Click
        SplitC1.Panel1Collapsed = True
        BtnUnPin.ImageKey = "unpinmenu.png"
    End Sub

    Private Sub BtnUnPin_Click(sender As System.Object, e As System.EventArgs) Handles BtnUnPin.Click
        SplitC1.Panel1Collapsed = False
        BtnUnPin.ImageKey = ""
    End Sub

    Private Sub VendedoresToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VendedoresToolStripMenuItem.Click
        Dim frmFiltro As New Frm_RelFiltro_Vendedores
        frmFiltro.ShowDialog()
    End Sub

    Private Sub TCPrincipal_DrawItem(sender As System.Object, e As System.Windows.Forms.DrawItemEventArgs) Handles TCPrincipal.DrawItem
        Dim TabPage = TCPrincipal.TabPages(e.Index)
        Dim tabrect = TCPrincipal.GetTabRect(e.Index)
        tabrect.Inflate(0, -5)
        Dim imgFechar = My.Resources.closetab
        e.Graphics.DrawImage(imgFechar,
                    (tabrect.Right - imgFechar.Width),
                    tabrect.Top + (tabrect.Height - imgFechar.Height) \ 2)

        TextRenderer.DrawText(e.Graphics, tabpage.Text, tabpage.Font,
        tabrect, tabpage.ForeColor, TextFormatFlags.HorizontalCenter)
    End Sub

    Private Sub SetTabEvents()
        Me.TCPrincipal.DrawMode = TabDrawMode.OwnerDrawFixed
    End Sub

    Private Sub TCPrincipal_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles TCPrincipal.MouseDown
        For i As Integer = 0 To TCPrincipal.TabPages.Count - 1
            Dim tabrect = TCPrincipal.GetTabRect(i)
            tabrect.Inflate(0, -5)
            Dim imgFechar = My.Resources.closetab
            Dim imgRect = New Rectangle((tabrect.Right - imgFechar.Width),
                tabrect.Top + (tabrect.Height - imgFechar.Height) / 2,
                imgFechar.Width,
                imgFechar.Height)

            If imgRect.Contains(e.Location) Then
                Dim frm = Me.TCPrincipal.TabPages(i).Controls.OfType(Of Form).FirstOrDefault
                If frm IsNot Nothing Then
                    frm.Close()
                    frm.Dispose()
                End If
                Me.TCPrincipal.TabPages.RemoveAt(i)
                Exit For
            End If
        Next
    End Sub
End Class