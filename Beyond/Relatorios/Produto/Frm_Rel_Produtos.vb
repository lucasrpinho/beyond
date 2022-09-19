Public Class Frm_Rel_Produtos

    Private dsProdutos As ProdutosDS

    Public Sub New(ds As ProdutosDS)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        dsProdutos = ds
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Frm_Rel_Produtos_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim rpt As New Rpt_Produto
        rpt.Load("Rpt_Produto.rpt")
        rpt.SetDataSource(dsProdutos)
        Me.CrystalReportViewer1.ReportSource = rpt
    End Sub
End Class