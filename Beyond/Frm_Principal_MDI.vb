Imports Entidades
Imports Uteis
Public Class Frm_Principal_MDI

    Private usuario As Usuario
    Public Modo As String

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
            Application.Exit()
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
        If e.CloseReason = CloseReason.ApplicationExitCall Then
            e.Cancel = False
            Exit Sub
        End If
        If Not Sair() Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub FecharSelecionadaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FecharSelecionadaToolStripMenuItem.Click
        If Not TCPrincipal.TabPages.Count > 0 Then
            Exit Sub
        Else
            TCPrincipal.TabPages.Remove(TCPrincipal.SelectedTab)
            If TCPrincipal.TabPages.Count = 0 Then
                TCPrincipal.Visible = False
            End If
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
        Dim Frm As Form
        Frm = TCPrincipal.TabPages.OfType(Of Frm_CadUsuario).FirstOrDefault
        If Not Frm Is Nothing Then
            Frm.BringToFront()
        Else
            Frm = New Frm_CadUsuario(Me, UC_Toolstrip1.ToolStrip0)
            Dim TP As New TabPage
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
        End If
    End Sub

End Class