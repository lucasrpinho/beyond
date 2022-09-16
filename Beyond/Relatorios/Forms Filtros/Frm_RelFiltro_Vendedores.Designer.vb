<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_RelFiltro_Vendedores
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.RdBtnAtivo = New System.Windows.Forms.RadioButton()
        Me.RdBtnTodos = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnVisualizar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'RdBtnAtivo
        '
        Me.RdBtnAtivo.AutoSize = True
        Me.RdBtnAtivo.Location = New System.Drawing.Point(12, 64)
        Me.RdBtnAtivo.Name = "RdBtnAtivo"
        Me.RdBtnAtivo.Size = New System.Drawing.Size(138, 21)
        Me.RdBtnAtivo.TabIndex = 0
        Me.RdBtnAtivo.Text = "Somente Ativos"
        Me.RdBtnAtivo.UseVisualStyleBackColor = True
        '
        'RdBtnTodos
        '
        Me.RdBtnTodos.AutoSize = True
        Me.RdBtnTodos.Location = New System.Drawing.Point(12, 91)
        Me.RdBtnTodos.Name = "RdBtnTodos"
        Me.RdBtnTodos.Size = New System.Drawing.Size(156, 21)
        Me.RdBtnTodos.TabIndex = 1
        Me.RdBtnTodos.TabStop = True
        Me.RdBtnTodos.Text = "Todos Vendedores"
        Me.RdBtnTodos.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(55, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(196, 26)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Escolha um filtro"
        '
        'BtnVisualizar
        '
        Me.BtnVisualizar.BackColor = System.Drawing.Color.Gainsboro
        Me.BtnVisualizar.Enabled = False
        Me.BtnVisualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnVisualizar.Font = New System.Drawing.Font("Verdana", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVisualizar.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BtnVisualizar.Location = New System.Drawing.Point(60, 148)
        Me.BtnVisualizar.Name = "BtnVisualizar"
        Me.BtnVisualizar.Size = New System.Drawing.Size(191, 36)
        Me.BtnVisualizar.TabIndex = 3
        Me.BtnVisualizar.Text = "Visualizar Relatório"
        Me.BtnVisualizar.UseVisualStyleBackColor = False
        '
        'Frm_RelFiltro_Vendedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(311, 196)
        Me.Controls.Add(Me.BtnVisualizar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RdBtnTodos)
        Me.Controls.Add(Me.RdBtnAtivo)
        Me.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_RelFiltro_Vendedores"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Filtros para Relatório de Vendedores"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RdBtnAtivo As System.Windows.Forms.RadioButton
    Friend WithEvents RdBtnTodos As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnVisualizar As System.Windows.Forms.Button
End Class
