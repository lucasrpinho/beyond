Imports Entidades
Imports Uteis
Public Class Frm_Principal_MDI

    Private usuario As Usuario

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

    Private Sub Sair()
        If Application.OpenForms.Count <= Uteis.FH.FORM_ATUAL_MAIS_FORM_STARTUP Then
            If Uteis.MB.MsgTemCerteza(Me) Then
                Cursor.Current = Cursors.WaitCursor
                System.Threading.Thread.Sleep(2000)
                Application.Exit()
            Else
                Exit Sub
            End If
        Else
            If Uteis.MB.MsgTemCertezaAlertaTelasAbertas(Me) Then
                Application.Exit()
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub CadastrarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CadastrarToolStripMenuItem.Click
        Dim Frm As Form
        Frm = SplitC1.Panel2.Controls.OfType(Of Frm_CadUsuario).FirstOrDefault
        If Not Frm Is Nothing Then
            Frm.BringToFront()
        Else
            Frm = New Frm_CadUsuario
            Frm.TopLevel = False
            Frm.BringToFront()
            Frm.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Frm.WindowState = FormWindowState.Maximized
            SplitC1.Panel2.Controls.Add(Frm)
            SplitC1.Panel2.Tag = Frm
            Frm.Show()
        End If
    End Sub

    Private Sub SobreToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SobreToolStripMenuItem.Click
        Dim FrmSobre As New Frm_Sobre
        If Not Application.OpenForms.OfType(Of Frm_Sobre).Any Then
            FrmSobre.ShowDialog(Me)
        End If
    End Sub

    Private Sub Frm_Principal_MDI_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.ApplicationExitCall Then
            e.Cancel = False
            Return
        End If
        Sair()
    End Sub

    Private Sub FecharSelecionadaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FecharSelecionadaToolStripMenuItem.Click

    End Sub
End Class