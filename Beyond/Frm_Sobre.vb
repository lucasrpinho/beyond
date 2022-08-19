Imports DAO
Imports System.Configuration

Public Class Frm_Sobre

    Private LstSobre As New List(Of Object)

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        DAO.DAO.GetSobreSistema(LstSobre)
    End Sub

    Private Sub Frm_Sobre_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LblNomeSistema.Text = LstSobre(0).ToString
        LblNomeAutor.Text = LstSobre(1).ToString
        LblNumSistema.Text = LstSobre(2).ToString
        LblDataVersao.Text = FormatDateTime(LstSobre(3), DateFormat.ShortDate)
    End Sub

    Private Sub BtnEntrar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEntrar.Click
        Me.Close()
        Dim FLogin As New Frm_Login()
        FLogin.Show()
    End Sub
End Class
