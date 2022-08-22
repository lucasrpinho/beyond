Imports Entidades
Public Class Frm_Principal_MDI

    Private usuario As Usuario
    Public loginusuario As String


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
    End Sub

    Private Sub TimerClock_Tick(sender As System.Object, e As System.EventArgs) Handles TimerClock.Tick
        TSL_Hora.Text = DateTime.Now.ToString("HH:mm:ss")
    End Sub
End Class