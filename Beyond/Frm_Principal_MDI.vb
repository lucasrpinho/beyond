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
        Sair()
    End Sub

    Private Function Sair() As Boolean
        If Uteis.MsgBoxHelper.MsgTemCerteza(Me) Then
            Cursor.Current = Cursors.WaitCursor
            System.Threading.Thread.Sleep(2000)
            Return True
        Else
            Return False
        End If
        Return False
    End Function

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
        End If
    End Sub

    Private Sub TCPrincipal_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles TCPrincipal.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If TCPrincipal.TabPages.Count > 0 Then
                ContextMenuStrip1.Show(TCPrincipal, e.Location)
            End If
        End If
    End Sub

    Private Sub UsuarioMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UsuarioMenuItem.Click
        Dim page = TCPrincipal.TabPages("Frm_CadUsuario")
        If Not page Is Nothing Then
            TCPrincipal.SelectTab(page)
        Else
            Dim Frm As New Frm_CadUsuario(Me)
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
            Me.Refresh()
        End If
    End Sub

    Private Sub ToolStripMenuFecharUma_Click(sender As System.Object, e As System.EventArgs) Handles FecharUmaCtxMenu.Click
        If TCPrincipal.TabPages.Count > 0 Then
            Dim page = TCPrincipal.TabPages(TCPrincipal.SelectedIndex)
            Application.OpenForms(page.Controls.OfType(Of Form).LastOrDefault.Name).Close()
            TCPrincipal.TabPages.Remove(TCPrincipal.SelectedTab)
        End If
    End Sub

    Private Sub ToolStripMenuFecharTodas_Click(sender As System.Object, e As System.EventArgs) Handles FecharTodasCtxMenu.Click
        If TCPrincipal.TabPages.Count > 0 Then
            For I As Integer = TCPrincipal.TabPages.Count - 1 To 0 Step -1
                TCPrincipal.TabPages(I).Controls.OfType(Of Form).FirstOrDefault.Dispose()
                TCPrincipal.TabPages.RemoveAt(I)
            Next
        End If
    End Sub

    Private Sub CargosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CargosToolStripMenuItem.Click
        Dim page = TCPrincipal.TabPages("Frm_Cargo")
        If Not page Is Nothing Then
            TCPrincipal.SelectTab(page)
        Else
            Dim teste = Application.OpenForms.OfType(Of Frm_Cargo).Count
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
            TCPrincipal.BringToFront()
            TCPrincipal.Visible = True
            Frm.Show()
            Me.Refresh()
        End If
    End Sub

    Private Sub FecharTodasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FecharTodasMenu.Click
        If TCPrincipal.TabPages.Count > 0 Then
            For I As Integer = TCPrincipal.TabPages.Count - 1 To 0 Step -1
                TCPrincipal.TabPages(I).Controls.OfType(Of Form).FirstOrDefault.Dispose()
                TCPrincipal.TabPages.RemoveAt(I)
            Next
        End If
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
                        TCPrincipal.TabPages(i).Controls.OfType(Of Form).FirstOrDefault.Enabled = False
                    End If
                Next
            End If
        Else
            TCPrincipal.Visible = False
        End If
    End Sub
End Class