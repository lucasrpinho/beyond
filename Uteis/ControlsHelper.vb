Imports System.Windows.Forms

Public Class ControlsHelper

    Public Shared Sub LimpaEAtiva(frm As Form)
        SetControlsEnabled(frm)
        SetTextBoxEmpty(frm.Controls)
    End Sub

    Public Shared Sub SetTextBoxEmpty(controls As Control.ControlCollection)
        For Each txtbox As TextBox In controls.OfType(Of TextBox)()
            txtbox.Text = ""
        Next
    End Sub

    Public Shared Sub SetControlsDisabled(frm As System.Windows.Forms.Form)
        Dim controls = frm.Controls
        For Each Control As Control In controls
            Control.Enabled = False
        Next
    End Sub

    Public Shared Sub SetControlsEnabled(frm As Form)
        Dim controls = frm.Controls
        For Each Control As Control In controls
            Control.Enabled = True
        Next
    End Sub

    Public Shared Sub ToolBarTransactionOpen(tools As ToolStrip)
        For Each item As ToolStripItem In tools.Items
            If Not item.Name = "BtnRollback" And Not item.Name = "BtnConfirmar" Then
                item.Enabled = False
            End If
        Next
    End Sub

    Public Shared Sub EnableAllToolBarItens(tools As ToolStrip)
        For Each item As ToolStripItem In tools.Items
            If Not item.Enabled Then
                item.Enabled = True
            End If
        Next
    End Sub

    Public Shared Function WasTransactionFinalized(tool As ToolStrip) As Boolean
        For Each item As ToolStripItem In tool.Items
            If Not item.Enabled Then
                Return False
            End If
        Next
        Return True
    End Function

End Class
