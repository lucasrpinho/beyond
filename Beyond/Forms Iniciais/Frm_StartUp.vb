'Imports System.Net
Public Class Frm_StartUp

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        'ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
    End Sub

    Private Sub Frm_StartUp_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ' Form de start da aplicação, porém não é o primeiro a ser exibido 

        Dim F As New Frm_Sobre()
        ' Modal
        F.ShowDialog()
        Me.Hide()
    End Sub
End Class