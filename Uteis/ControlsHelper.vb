Imports System.Windows.Forms

Public Class ControlsHelper

    Public Shared Sub LimpaEAtiva(controls As Control.ControlCollection)
        SetControlsEnabled(controls)
        SetTextsEmpty(controls)
    End Sub

    Public Shared Sub SetTextsEmpty(controls As Control.ControlCollection)
        If controls.OfType(Of TextBox).Count > 0 Then
            For Each txtbox As TextBox In controls.OfType(Of TextBox)()
                txtbox.Text = ""
            Next
        End If
        If controls.OfType(Of ComboBox).Count > 0 Then
            For Each combotext As ComboBox In controls.OfType(Of ComboBox)()
                combotext.Text = ""
                combotext.SelectedIndex = -1
            Next
        End If
        If controls.OfType(Of MaskedTextBox).Count > 0 Then
            For Each mask As MaskedTextBox In controls.OfType(Of MaskedTextBox)()
                mask.Text = ""
            Next
        End If
    End Sub

    Public Shared Sub SetControlsDisabled(controls As Control.ControlCollection)
        For Each c As Control In controls
            If Not TypeOf (c) Is Label Then
                c.Enabled = False
            End If
        Next
    End Sub

    Public Shared Sub SetControlsEnabled(controls As Control.ControlCollection)
        For Each Control As Control In controls
            Control.Enabled = True
        Next
    End Sub

    Public Shared Sub EnableAllToolBarItens(tools As ToolStrip)
        For Each item As ToolStripItem In tools.Items
            If Not item.Enabled Then
                item.Enabled = True
            End If
        Next
    End Sub

    'Public Shared Function WasTransactionFinalized(tool As ToolStrip) As Boolean
    '    For Each item As ToolStripItem In tool.Items
    '        If Not item.Enabled Then
    '            Return False
    '        End If
    '    Next
    '    Return True
    'End Function

End Class
