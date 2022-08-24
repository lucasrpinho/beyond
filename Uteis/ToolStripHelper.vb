Imports System.Windows.Forms

Public Class ToolStripHelper

    Public Shared Sub Novo(ByVal frm As Form, ByVal Obj As ToolStrip, ByVal UCTool As ToolStrip)
        Obj = UCTool
        Obj.Dock = DockStyle.Bottom
        frm.Controls.Add(Obj)
        Obj.Items("BtnCommit").Enabled = False
        Obj.Items("BtnReverter").Enabled = False
        Obj.Show()
    End Sub
End Class
