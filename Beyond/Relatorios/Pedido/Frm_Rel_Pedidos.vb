Public Class Frm_Rel_Pedidos

    Private dsPedidos As PedidosDS

    Public Sub New(ByVal ds As PedidosDS)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        dsPedidos = ds
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Frm_Rel_Pedidos_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim rpt As New Rpt_Pedido
        rpt.Load("Rpt_Pedido.rpt")
        rpt.SetDataSource(dsPedidos)
        Me.CrystalReportViewer1.ReportSource = rpt
    End Sub

End Class