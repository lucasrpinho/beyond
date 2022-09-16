'Imports System.Net
Public Class Frm_StartUp

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        'ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;

        Dim F As New Frm_Sobre()
        F.ShowDialog()
    End Sub

    Protected Overrides Sub SetVisibleCore(ByVal value As Boolean)
        If Not Me.IsHandleCreated Then
            Me.CreateHandle()
            value = False
        End If
        MyBase.SetVisibleCore(value)
    End Sub

    Private Sub Frm_StartUp_Load(sender As Object, e As System.EventArgs) Handles Me.Load

    End Sub
End Class