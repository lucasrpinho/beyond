﻿Imports System.Windows.Forms

Public Class Controls

    Public Shared Sub SetTextBoxEmpty(frm As System.Windows.Forms.Form)
        Dim txtboxControl = frm.Controls.OfType(Of System.Windows.Forms.TextBox)()
        For Each txtbox As Windows.Forms.TextBox In txtboxControl
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

    Public Shared Sub ToolBarAfterInsert(tools As ToolStrip)
        Dim itens = tools.Items
        For Each item As ToolStripItem In itens
            If Not item.Name = "BtnRollback" Or Not item.Name = "BtnCommit" Then
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
