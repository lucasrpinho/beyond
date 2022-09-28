<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Vendedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Vendedor))
        Me.GrpBoxInfo = New System.Windows.Forms.GroupBox()
        Me.BtnInsereImagem = New System.Windows.Forms.Button()
        Me.ChkBoxAtivo = New System.Windows.Forms.CheckBox()
        Me.ComboCargo = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PicBoxFoto = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ComboNome = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TxtObs = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GrpBoxEndereco = New System.Windows.Forms.GroupBox()
        Me.TxtCidade = New System.Windows.Forms.TextBox()
        Me.TxtNum = New System.Windows.Forms.TextBox()
        Me.TxtCEP = New System.Windows.Forms.MaskedTextBox()
        Me.ComboEstado = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtLogradouro = New System.Windows.Forms.TextBox()
        Me.TxtBairro = New System.Windows.Forms.TextBox()
        Me.TxtComplemento = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblCep = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GrpBoxInfo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PicBoxFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpBoxEndereco.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpBoxInfo
        '
        Me.GrpBoxInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpBoxInfo.Controls.Add(Me.BtnInsereImagem)
        Me.GrpBoxInfo.Controls.Add(Me.ChkBoxAtivo)
        Me.GrpBoxInfo.Controls.Add(Me.ComboCargo)
        Me.GrpBoxInfo.Controls.Add(Me.GroupBox1)
        Me.GrpBoxInfo.Controls.Add(Me.Label9)
        Me.GrpBoxInfo.Controls.Add(Me.ComboNome)
        Me.GrpBoxInfo.Controls.Add(Me.Label17)
        Me.GrpBoxInfo.Controls.Add(Me.TxtObs)
        Me.GrpBoxInfo.Controls.Add(Me.Label1)
        Me.GrpBoxInfo.Location = New System.Drawing.Point(13, 23)
        Me.GrpBoxInfo.Margin = New System.Windows.Forms.Padding(4)
        Me.GrpBoxInfo.Name = "GrpBoxInfo"
        Me.GrpBoxInfo.Padding = New System.Windows.Forms.Padding(4)
        Me.GrpBoxInfo.Size = New System.Drawing.Size(861, 327)
        Me.GrpBoxInfo.TabIndex = 0
        Me.GrpBoxInfo.TabStop = False
        Me.GrpBoxInfo.Text = "Informações"
        '
        'BtnInsereImagem
        '
        Me.BtnInsereImagem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnInsereImagem.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnInsereImagem.Location = New System.Drawing.Point(651, 215)
        Me.BtnInsereImagem.Name = "BtnInsereImagem"
        Me.BtnInsereImagem.Size = New System.Drawing.Size(200, 27)
        Me.BtnInsereImagem.TabIndex = 41
        Me.BtnInsereImagem.Text = "Inserir Imagem"
        Me.BtnInsereImagem.UseVisualStyleBackColor = True
        '
        'ChkBoxAtivo
        '
        Me.ChkBoxAtivo.AutoSize = True
        Me.ChkBoxAtivo.Checked = True
        Me.ChkBoxAtivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkBoxAtivo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkBoxAtivo.Location = New System.Drawing.Point(11, 48)
        Me.ChkBoxAtivo.Name = "ChkBoxAtivo"
        Me.ChkBoxAtivo.Size = New System.Drawing.Size(60, 18)
        Me.ChkBoxAtivo.TabIndex = 1
        Me.ChkBoxAtivo.Text = "Ativo"
        Me.ChkBoxAtivo.UseVisualStyleBackColor = True
        '
        'ComboCargo
        '
        Me.ComboCargo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboCargo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboCargo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboCargo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ComboCargo.FormattingEnabled = True
        Me.ComboCargo.Items.AddRange(New Object() {" "})
        Me.ComboCargo.Location = New System.Drawing.Point(11, 159)
        Me.ComboCargo.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboCargo.MaxLength = 60
        Me.ComboCargo.Name = "ComboCargo"
        Me.ComboCargo.Size = New System.Drawing.Size(608, 24)
        Me.ComboCargo.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.PicBoxFoto)
        Me.GroupBox1.Location = New System.Drawing.Point(648, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(206, 200)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Foto do Vendedor"
        '
        'PicBoxFoto
        '
        Me.PicBoxFoto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicBoxFoto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PicBoxFoto.Location = New System.Drawing.Point(3, 20)
        Me.PicBoxFoto.Name = "PicBoxFoto"
        Me.PicBoxFoto.Size = New System.Drawing.Size(200, 177)
        Me.PicBoxFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicBoxFoto.TabIndex = 36
        Me.PicBoxFoto.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 138)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 17)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "Cargo"
        '
        'ComboNome
        '
        Me.ComboNome.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboNome.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboNome.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboNome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.ComboNome.FormattingEnabled = True
        Me.ComboNome.Location = New System.Drawing.Point(11, 103)
        Me.ComboNome.MaxLength = 150
        Me.ComboNome.Name = "ComboNome"
        Me.ComboNome.Size = New System.Drawing.Size(608, 24)
        Me.ComboNome.TabIndex = 2
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(8, 228)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(90, 17)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Observação"
        '
        'TxtObs
        '
        Me.TxtObs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtObs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtObs.Location = New System.Drawing.Point(11, 249)
        Me.TxtObs.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtObs.MaxLength = 3000
        Me.TxtObs.Multiline = True
        Me.TxtObs.Name = "TxtObs"
        Me.TxtObs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtObs.Size = New System.Drawing.Size(840, 67)
        Me.TxtObs.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 83)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Nome Completo"
        '
        'GrpBoxEndereco
        '
        Me.GrpBoxEndereco.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpBoxEndereco.Controls.Add(Me.TxtCidade)
        Me.GrpBoxEndereco.Controls.Add(Me.TxtNum)
        Me.GrpBoxEndereco.Controls.Add(Me.TxtCEP)
        Me.GrpBoxEndereco.Controls.Add(Me.ComboEstado)
        Me.GrpBoxEndereco.Controls.Add(Me.Label8)
        Me.GrpBoxEndereco.Controls.Add(Me.TxtLogradouro)
        Me.GrpBoxEndereco.Controls.Add(Me.TxtBairro)
        Me.GrpBoxEndereco.Controls.Add(Me.TxtComplemento)
        Me.GrpBoxEndereco.Controls.Add(Me.Label3)
        Me.GrpBoxEndereco.Controls.Add(Me.Label7)
        Me.GrpBoxEndereco.Controls.Add(Me.Label6)
        Me.GrpBoxEndereco.Controls.Add(Me.Label5)
        Me.GrpBoxEndereco.Controls.Add(Me.Label4)
        Me.GrpBoxEndereco.Controls.Add(Me.LblCep)
        Me.GrpBoxEndereco.Location = New System.Drawing.Point(13, 358)
        Me.GrpBoxEndereco.Margin = New System.Windows.Forms.Padding(4)
        Me.GrpBoxEndereco.Name = "GrpBoxEndereco"
        Me.GrpBoxEndereco.Padding = New System.Windows.Forms.Padding(4)
        Me.GrpBoxEndereco.Size = New System.Drawing.Size(861, 200)
        Me.GrpBoxEndereco.TabIndex = 1
        Me.GrpBoxEndereco.TabStop = False
        Me.GrpBoxEndereco.Text = "Endereço"
        '
        'TxtCidade
        '
        Me.TxtCidade.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCidade.Location = New System.Drawing.Point(11, 162)
        Me.TxtCidade.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCidade.MaxLength = 300
        Me.TxtCidade.Name = "TxtCidade"
        Me.TxtCidade.Size = New System.Drawing.Size(608, 24)
        Me.TxtCidade.TabIndex = 11
        '
        'TxtNum
        '
        Me.TxtNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNum.Location = New System.Drawing.Point(643, 61)
        Me.TxtNum.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNum.MaxLength = 20
        Me.TxtNum.Name = "TxtNum"
        Me.TxtNum.Size = New System.Drawing.Size(212, 24)
        Me.TxtNum.TabIndex = 8
        '
        'TxtCEP
        '
        Me.TxtCEP.Location = New System.Drawing.Point(11, 60)
        Me.TxtCEP.Mask = "00000-000"
        Me.TxtCEP.Name = "TxtCEP"
        Me.TxtCEP.Size = New System.Drawing.Size(98, 24)
        Me.TxtCEP.TabIndex = 6
        '
        'ComboEstado
        '
        Me.ComboEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboEstado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ComboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboEstado.FormattingEnabled = True
        Me.ComboEstado.Items.AddRange(New Object() {" "})
        Me.ComboEstado.Location = New System.Drawing.Point(643, 161)
        Me.ComboEstado.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboEstado.MaxLength = 2
        Me.ComboEstado.Name = "ComboEstado"
        Me.ComboEstado.Size = New System.Drawing.Size(212, 24)
        Me.ComboEstado.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(640, 140)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 17)
        Me.Label8.TabIndex = 68
        Me.Label8.Text = "Estado"
        '
        'TxtLogradouro
        '
        Me.TxtLogradouro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtLogradouro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLogradouro.Location = New System.Drawing.Point(131, 60)
        Me.TxtLogradouro.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtLogradouro.MaxLength = 300
        Me.TxtLogradouro.Name = "TxtLogradouro"
        Me.TxtLogradouro.Size = New System.Drawing.Size(488, 24)
        Me.TxtLogradouro.TabIndex = 7
        '
        'TxtBairro
        '
        Me.TxtBairro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBairro.Location = New System.Drawing.Point(11, 107)
        Me.TxtBairro.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtBairro.MaxLength = 300
        Me.TxtBairro.Name = "TxtBairro"
        Me.TxtBairro.Size = New System.Drawing.Size(608, 24)
        Me.TxtBairro.TabIndex = 9
        '
        'TxtComplemento
        '
        Me.TxtComplemento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtComplemento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtComplemento.Location = New System.Drawing.Point(643, 107)
        Me.TxtComplemento.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtComplemento.MaxLength = 30
        Me.TxtComplemento.Name = "TxtComplemento"
        Me.TxtComplemento.Size = New System.Drawing.Size(212, 24)
        Me.TxtComplemento.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 139)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 17)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "Cidade"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 87)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 17)
        Me.Label7.TabIndex = 66
        Me.Label7.Text = "Bairro"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(640, 89)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 17)
        Me.Label6.TabIndex = 65
        Me.Label6.Text = "Complemento"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(640, 40)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 17)
        Me.Label5.TabIndex = 64
        Me.Label5.Text = "Número"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(128, 40)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 17)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "Logradouro"
        '
        'LblCep
        '
        Me.LblCep.AutoSize = True
        Me.LblCep.Location = New System.Drawing.Point(9, 40)
        Me.LblCep.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCep.Name = "LblCep"
        Me.LblCep.Size = New System.Drawing.Size(35, 17)
        Me.LblCep.TabIndex = 62
        Me.LblCep.Text = "CEP"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "PNG|*.png"
        '
        'Frm_Vendedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Menu
        Me.ClientSize = New System.Drawing.Size(887, 571)
        Me.Controls.Add(Me.GrpBoxEndereco)
        Me.Controls.Add(Me.GrpBoxInfo)
        Me.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Vendedor"
        Me.ShowInTaskbar = False
        Me.Text = "Vendedor"
        Me.GrpBoxInfo.ResumeLayout(False)
        Me.GrpBoxInfo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PicBoxFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpBoxEndereco.ResumeLayout(False)
        Me.GrpBoxEndereco.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpBoxInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpBoxEndereco As System.Windows.Forms.GroupBox
    Friend WithEvents TxtObs As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents PicBoxFoto As System.Windows.Forms.PictureBox
    Friend WithEvents ComboCargo As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ChkBoxAtivo As System.Windows.Forms.CheckBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ComboNome As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCidade As System.Windows.Forms.TextBox
    Friend WithEvents TxtNum As System.Windows.Forms.TextBox
    Friend WithEvents TxtCEP As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ComboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtLogradouro As System.Windows.Forms.TextBox
    Friend WithEvents TxtBairro As System.Windows.Forms.TextBox
    Friend WithEvents TxtComplemento As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblCep As System.Windows.Forms.Label
    Friend WithEvents BtnInsereImagem As System.Windows.Forms.Button
End Class
