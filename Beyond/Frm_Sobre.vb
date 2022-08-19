Imports DAO

Public Class Frm_Sobre

    Private LstSobre As List(Of String)

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DAO.DAO.GetSobreSistema(LstSobre)
    End Sub

    Private Sub LblDataVersao_Click(sender As System.Object, e As System.EventArgs) Handles LblDataVersao.Click

    End Sub

    Private Sub Frm_Sobre_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LblNomeSistema.Text = LstSobre(0)
        LblNomeAutor.Text = LstSobre(1)
        LblNumSistema.Text = LstSobre(2)
        LblDataVersao.Text = LstSobre(3)
    End Sub
End Class
