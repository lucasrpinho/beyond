<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Produto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Produto))
        Me.GrpBoxInfo = New System.Windows.Forms.GroupBox()
        Me.TxtNome = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtCategoria = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PicBoxFoto = New System.Windows.Forms.PictureBox()
        Me.ChkAtivo = New System.Windows.Forms.CheckBox()
        Me.TxtQtd = New System.Windows.Forms.TextBox()
        Me.TxtDesc = New System.Windows.Forms.TextBox()
        Me.TxtPreco = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GrpBoxInfo.SuspendLayout()
        CType(Me.PicBoxFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpBoxInfo
        '
        Me.GrpBoxInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpBoxInfo.BackColor = System.Drawing.Color.Transparent
        Me.GrpBoxInfo.Controls.Add(Me.TxtNome)
        Me.GrpBoxInfo.Controls.Add(Me.Label6)
        Me.GrpBoxInfo.Controls.Add(Me.TxtCategoria)
        Me.GrpBoxInfo.Controls.Add(Me.Label5)
        Me.GrpBoxInfo.Controls.Add(Me.PicBoxFoto)
        Me.GrpBoxInfo.Controls.Add(Me.ChkAtivo)
        Me.GrpBoxInfo.Controls.Add(Me.TxtQtd)
        Me.GrpBoxInfo.Controls.Add(Me.TxtDesc)
        Me.GrpBoxInfo.Controls.Add(Me.TxtPreco)
        Me.GrpBoxInfo.Controls.Add(Me.Label4)
        Me.GrpBoxInfo.Controls.Add(Me.Label3)
        Me.GrpBoxInfo.Controls.Add(Me.Label2)
        Me.GrpBoxInfo.Controls.Add(Me.Label1)
        Me.GrpBoxInfo.Location = New System.Drawing.Point(16, 26)
        Me.GrpBoxInfo.Name = "GrpBoxInfo"
        Me.GrpBoxInfo.Size = New System.Drawing.Size(671, 372)
        Me.GrpBoxInfo.TabIndex = 0
        Me.GrpBoxInfo.TabStop = False
        Me.GrpBoxInfo.Text = "Informações"
        '
        'TxtNome
        '
        Me.TxtNome.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNome.Location = New System.Drawing.Point(204, 155)
        Me.TxtNome.MaxLength = 60
        Me.TxtNome.Name = "TxtNome"
        Me.TxtNome.Size = New System.Drawing.Size(444, 24)
        Me.TxtNome.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(201, 135)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 17)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Nome"
        '
        'TxtCategoria
        '
        Me.TxtCategoria.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCategoria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCategoria.Location = New System.Drawing.Point(204, 108)
        Me.TxtCategoria.MaxLength = 60
        Me.TxtCategoria.Name = "TxtCategoria"
        Me.TxtCategoria.Size = New System.Drawing.Size(444, 24)
        Me.TxtCategoria.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(149, 17)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Imagem do produto"
        '
        'PicBoxFoto
        '
        Me.PicBoxFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicBoxFoto.Location = New System.Drawing.Point(6, 108)
        Me.PicBoxFoto.Name = "PicBoxFoto"
        Me.PicBoxFoto.Size = New System.Drawing.Size(174, 155)
        Me.PicBoxFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicBoxFoto.TabIndex = 9
        Me.PicBoxFoto.TabStop = False
        '
        'ChkAtivo
        '
        Me.ChkAtivo.AutoSize = True
        Me.ChkAtivo.Checked = True
        Me.ChkAtivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkAtivo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChkAtivo.Font = New System.Drawing.Font("Verdana", 8.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkAtivo.Location = New System.Drawing.Point(6, 47)
        Me.ChkAtivo.Name = "ChkAtivo"
        Me.ChkAtivo.Size = New System.Drawing.Size(60, 18)
        Me.ChkAtivo.TabIndex = 8
        Me.ChkAtivo.Text = "Ativo"
        Me.ChkAtivo.UseVisualStyleBackColor = True
        '
        'TxtQtd
        '
        Me.TxtQtd.Location = New System.Drawing.Point(6, 333)
        Me.TxtQtd.Name = "TxtQtd"
        Me.TxtQtd.Size = New System.Drawing.Size(107, 24)
        Me.TxtQtd.TabIndex = 4
        Me.TxtQtd.Text = "0"
        '
        'TxtDesc
        '
        Me.TxtDesc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDesc.Location = New System.Drawing.Point(204, 202)
        Me.TxtDesc.MaxLength = 300
        Me.TxtDesc.Multiline = True
        Me.TxtDesc.Name = "TxtDesc"
        Me.TxtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtDesc.Size = New System.Drawing.Size(444, 61)
        Me.TxtDesc.TabIndex = 2
        '
        'TxtPreco
        '
        Me.TxtPreco.Location = New System.Drawing.Point(6, 286)
        Me.TxtPreco.Name = "TxtPreco"
        Me.TxtPreco.Size = New System.Drawing.Size(162, 24)
        Me.TxtPreco.TabIndex = 3
        Me.TxtPreco.Text = "0,00"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 313)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(177, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Quantidade em Estoque"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 266)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Preço"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(201, 182)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Descrição"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(201, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Categoria"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "PNG|*.png"
        '
        'Frm_Produto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Menu
        Me.ClientSize = New System.Drawing.Size(704, 410)
        Me.Controls.Add(Me.GrpBoxInfo)
        Me.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Produto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Produto"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpBoxInfo.ResumeLayout(False)
        Me.GrpBoxInfo.PerformLayout()
        CType(Me.PicBoxFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents GrpBoxInfo As System.Windows.Forms.GroupBox
    Friend WithEvents ChkAtivo As System.Windows.Forms.CheckBox
    Friend WithEvents TxtQtd As System.Windows.Forms.TextBox
    Friend WithEvents TxtPreco As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PicBoxFoto As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
    Friend WithEvents TxtCategoria As System.Windows.Forms.TextBox
    Friend WithEvents TxtNome As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
