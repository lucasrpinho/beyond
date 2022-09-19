Public Class Frm_Rel_Vendedores

    Private dsVendedores As VendedoresDS

    Public Sub New(ByVal ds As VendedoresDS)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        dsVendedores = ds
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Frm_Rel_Vendedores_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim rpt As New Rpt_Vendedor
        rpt.Load("Rpt_Vendedor.rpt")
        rpt.SetDataSource(dsVendedores)
        Me.CrystalReportViewer1.ReportSource = rpt
    End Sub

End Class