<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_RelFiltro_Produto
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_RelFiltro_Produto))
        Me.BtnVisualizar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RdBtnTodos = New System.Windows.Forms.RadioButton()
        Me.RdBtnAtivo = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GrpBoxSaldo = New System.Windows.Forms.GroupBox()
        Me.RdBtnSaldo = New System.Windows.Forms.RadioButton()
        Me.RdBtnTodosSaldo = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.GrpBoxSaldo.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnVisualizar
        '
        Me.BtnVisualizar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnVisualizar.BackColor = System.Drawing.Color.Gainsboro
        Me.BtnVisualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnVisualizar.Font = New System.Drawing.Font("Verdana", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVisualizar.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BtnVisualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnVisualizar.ImageKey = "report.png"
        Me.BtnVisualizar.ImageList = Me.ImageList1
        Me.BtnVisualizar.Location = New System.Drawing.Point(175, 236)
        Me.BtnVisualizar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnVisualizar.Name = "BtnVisualizar"
        Me.BtnVisualizar.Size = New System.Drawing.Size(194, 44)
        Me.BtnVisualizar.TabIndex = 7
        Me.BtnVisualizar.Text = "Visualizar Relatório"
        Me.BtnVisualizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnVisualizar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "report.png")
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(171, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(198, 23)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Selecione os Filtros"
        '
        'RdBtnTodos
        '
        Me.RdBtnTodos.AutoSize = True
        Me.RdBtnTodos.Location = New System.Drawing.Point(6, 84)
        Me.RdBtnTodos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RdBtnTodos.Name = "RdBtnTodos"
        Me.RdBtnTodos.Size = New System.Drawing.Size(73, 21)
        Me.RdBtnTodos.TabIndex = 5
        Me.RdBtnTodos.TabStop = True
        Me.RdBtnTodos.Text = "Todos "
        Me.RdBtnTodos.UseVisualStyleBackColor = True
        '
        'RdBtnAtivo
        '
        Me.RdBtnAtivo.AutoSize = True
        Me.RdBtnAtivo.Location = New System.Drawing.Point(6, 51)
        Me.RdBtnAtivo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RdBtnAtivo.Name = "RdBtnAtivo"
        Me.RdBtnAtivo.Size = New System.Drawing.Size(138, 21)
        Me.RdBtnAtivo.TabIndex = 4
        Me.RdBtnAtivo.Text = "Somente Ativos"
        Me.RdBtnAtivo.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RdBtnAtivo)
        Me.GroupBox1.Controls.Add(Me.RdBtnTodos)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(211, 135)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Status do Produto"
        '
        'GrpBoxSaldo
        '
        Me.GrpBoxSaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpBoxSaldo.Controls.Add(Me.RdBtnSaldo)
        Me.GrpBoxSaldo.Controls.Add(Me.RdBtnTodosSaldo)
        Me.GrpBoxSaldo.Location = New System.Drawing.Point(323, 77)
        Me.GrpBoxSaldo.Name = "GrpBoxSaldo"
        Me.GrpBoxSaldo.Size = New System.Drawing.Size(211, 135)
        Me.GrpBoxSaldo.TabIndex = 9
        Me.GrpBoxSaldo.TabStop = False
        Me.GrpBoxSaldo.Text = "Disponibilidade de estoque"
        '
        'RdBtnSaldo
        '
        Me.RdBtnSaldo.AutoSize = True
        Me.RdBtnSaldo.Location = New System.Drawing.Point(6, 51)
        Me.RdBtnSaldo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RdBtnSaldo.Name = "RdBtnSaldo"
        Me.RdBtnSaldo.Size = New System.Drawing.Size(154, 21)
        Me.RdBtnSaldo.TabIndex = 4
        Me.RdBtnSaldo.Text = "Apenas com saldo"
        Me.RdBtnSaldo.UseVisualStyleBackColor = True
        '
        'RdBtnTodosSaldo
        '
        Me.RdBtnTodosSaldo.AutoSize = True
        Me.RdBtnTodosSaldo.Location = New System.Drawing.Point(6, 84)
        Me.RdBtnTodosSaldo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RdBtnTodosSaldo.Name = "RdBtnTodosSaldo"
        Me.RdBtnTodosSaldo.Size = New System.Drawing.Size(68, 21)
        Me.RdBtnTodosSaldo.TabIndex = 5
        Me.RdBtnTodosSaldo.TabStop = True
        Me.RdBtnTodosSaldo.Text = "Todos"
        Me.RdBtnTodosSaldo.UseVisualStyleBackColor = True
        '
        'Frm_RelFiltro_Produto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 293)
        Me.Controls.Add(Me.GrpBoxSaldo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnVisualizar)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_RelFiltro_Produto"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Filtros para relatório de produtos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GrpBoxSaldo.ResumeLayout(False)
        Me.GrpBoxSaldo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnVisualizar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RdBtnTodos As System.Windows.Forms.RadioButton
    Friend WithEvents RdBtnAtivo As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GrpBoxSaldo As System.Windows.Forms.GroupBox
    Friend WithEvents RdBtnSaldo As System.Windows.Forms.RadioButton
    Friend WithEvents RdBtnTodosSaldo As System.Windows.Forms.RadioButton
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class
