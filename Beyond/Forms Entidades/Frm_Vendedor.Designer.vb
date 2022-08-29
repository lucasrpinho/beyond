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
        Me.GrpBoxInfo = New System.Windows.Forms.GroupBox()
        Me.ComboNome = New System.Windows.Forms.ComboBox()
        Me.BtnFoto = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtNum = New System.Windows.Forms.TextBox()
        Me.PicBoxFoto = New System.Windows.Forms.PictureBox()
        Me.TxtCEP = New System.Windows.Forms.MaskedTextBox()
        Me.ComboEstado = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtLogradouro = New System.Windows.Forms.TextBox()
        Me.TxtBairro = New System.Windows.Forms.TextBox()
        Me.TxtCidade = New System.Windows.Forms.TextBox()
        Me.TxtComplemento = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblCep = New System.Windows.Forms.Label()
        Me.TxtSobrenome = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GrpBoxAdd = New System.Windows.Forms.GroupBox()
        Me.ComboCargo = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ChkBoxAtivo = New System.Windows.Forms.CheckBox()
        Me.TxtObs = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GrpBoxInfo.SuspendLayout()
        CType(Me.PicBoxFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpBoxAdd.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpBoxInfo
        '
        Me.GrpBoxInfo.Controls.Add(Me.ComboNome)
        Me.GrpBoxInfo.Controls.Add(Me.BtnFoto)
        Me.GrpBoxInfo.Controls.Add(Me.Label10)
        Me.GrpBoxInfo.Controls.Add(Me.TxtNum)
        Me.GrpBoxInfo.Controls.Add(Me.PicBoxFoto)
        Me.GrpBoxInfo.Controls.Add(Me.TxtCEP)
        Me.GrpBoxInfo.Controls.Add(Me.ComboEstado)
        Me.GrpBoxInfo.Controls.Add(Me.Label8)
        Me.GrpBoxInfo.Controls.Add(Me.TxtLogradouro)
        Me.GrpBoxInfo.Controls.Add(Me.TxtBairro)
        Me.GrpBoxInfo.Controls.Add(Me.TxtCidade)
        Me.GrpBoxInfo.Controls.Add(Me.TxtComplemento)
        Me.GrpBoxInfo.Controls.Add(Me.Label3)
        Me.GrpBoxInfo.Controls.Add(Me.Label7)
        Me.GrpBoxInfo.Controls.Add(Me.Label6)
        Me.GrpBoxInfo.Controls.Add(Me.Label5)
        Me.GrpBoxInfo.Controls.Add(Me.Label4)
        Me.GrpBoxInfo.Controls.Add(Me.LblCep)
        Me.GrpBoxInfo.Controls.Add(Me.TxtSobrenome)
        Me.GrpBoxInfo.Controls.Add(Me.Label2)
        Me.GrpBoxInfo.Controls.Add(Me.Label1)
        Me.GrpBoxInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.GrpBoxInfo.Location = New System.Drawing.Point(0, 0)
        Me.GrpBoxInfo.Margin = New System.Windows.Forms.Padding(4)
        Me.GrpBoxInfo.Name = "GrpBoxInfo"
        Me.GrpBoxInfo.Padding = New System.Windows.Forms.Padding(4)
        Me.GrpBoxInfo.Size = New System.Drawing.Size(739, 325)
        Me.GrpBoxInfo.TabIndex = 0
        Me.GrpBoxInfo.TabStop = False
        Me.GrpBoxInfo.Text = "Informações"
        '
        'ComboNome
        '
        Me.ComboNome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.ComboNome.FormattingEnabled = True
        Me.ComboNome.Location = New System.Drawing.Point(13, 60)
        Me.ComboNome.Name = "ComboNome"
        Me.ComboNome.Size = New System.Drawing.Size(201, 24)
        Me.ComboNome.TabIndex = 39
        '
        'BtnFoto
        '
        Me.BtnFoto.Location = New System.Drawing.Point(629, 218)
        Me.BtnFoto.Name = "BtnFoto"
        Me.BtnFoto.Size = New System.Drawing.Size(103, 31)
        Me.BtnFoto.TabIndex = 37
        Me.BtnFoto.Text = "Inserir Foto"
        Me.BtnFoto.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(504, 19)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(122, 17)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "Foto do Vendedor"
        '
        'TxtNum
        '
        Me.TxtNum.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNum.Location = New System.Drawing.Point(88, 182)
        Me.TxtNum.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNum.Name = "TxtNum"
        Me.TxtNum.Size = New System.Drawing.Size(100, 23)
        Me.TxtNum.TabIndex = 35
        '
        'PicBoxFoto
        '
        Me.PicBoxFoto.Location = New System.Drawing.Point(507, 39)
        Me.PicBoxFoto.Name = "PicBoxFoto"
        Me.PicBoxFoto.Size = New System.Drawing.Size(225, 166)
        Me.PicBoxFoto.TabIndex = 36
        Me.PicBoxFoto.TabStop = False
        '
        'TxtCEP
        '
        Me.TxtCEP.Location = New System.Drawing.Point(9, 182)
        Me.TxtCEP.Mask = "00000-000"
        Me.TxtCEP.Name = "TxtCEP"
        Me.TxtCEP.Size = New System.Drawing.Size(72, 23)
        Me.TxtCEP.TabIndex = 34
        '
        'ComboEstado
        '
        Me.ComboEstado.FormattingEnabled = True
        Me.ComboEstado.Items.AddRange(New Object() {" "})
        Me.ComboEstado.Location = New System.Drawing.Point(8, 287)
        Me.ComboEstado.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboEstado.Name = "ComboEstado"
        Me.ComboEstado.Size = New System.Drawing.Size(212, 24)
        Me.ComboEstado.TabIndex = 33
        Me.ComboEstado.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 266)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 17)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Estado"
        '
        'TxtLogradouro
        '
        Me.TxtLogradouro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtLogradouro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLogradouro.Location = New System.Drawing.Point(9, 122)
        Me.TxtLogradouro.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtLogradouro.Name = "TxtLogradouro"
        Me.TxtLogradouro.Size = New System.Drawing.Size(486, 23)
        Me.TxtLogradouro.TabIndex = 31
        '
        'TxtBairro
        '
        Me.TxtBairro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBairro.Location = New System.Drawing.Point(8, 239)
        Me.TxtBairro.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtBairro.Name = "TxtBairro"
        Me.TxtBairro.Size = New System.Drawing.Size(218, 23)
        Me.TxtBairro.TabIndex = 30
        '
        'TxtCidade
        '
        Me.TxtCidade.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCidade.Location = New System.Drawing.Point(234, 239)
        Me.TxtCidade.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCidade.Name = "TxtCidade"
        Me.TxtCidade.Size = New System.Drawing.Size(261, 23)
        Me.TxtCidade.TabIndex = 29
        '
        'TxtComplemento
        '
        Me.TxtComplemento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtComplemento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtComplemento.Location = New System.Drawing.Point(196, 182)
        Me.TxtComplemento.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtComplemento.Name = "TxtComplemento"
        Me.TxtComplemento.Size = New System.Drawing.Size(299, 23)
        Me.TxtComplemento.TabIndex = 28
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(231, 218)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 17)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Cidade"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 218)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 17)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Bairro"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(193, 161)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 17)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Complemento"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(85, 161)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 17)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Número"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 102)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 17)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Logradouro"
        '
        'LblCep
        '
        Me.LblCep.AutoSize = True
        Me.LblCep.Location = New System.Drawing.Point(10, 161)
        Me.LblCep.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCep.Name = "LblCep"
        Me.LblCep.Size = New System.Drawing.Size(35, 17)
        Me.LblCep.TabIndex = 14
        Me.LblCep.Text = "CEP"
        '
        'TxtSobrenome
        '
        Me.TxtSobrenome.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSobrenome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSobrenome.Location = New System.Drawing.Point(222, 60)
        Me.TxtSobrenome.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtSobrenome.Name = "TxtSobrenome"
        Me.TxtSobrenome.Size = New System.Drawing.Size(273, 23)
        Me.TxtSobrenome.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(219, 39)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 17)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Sobrenome"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 39)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Nome"
        '
        'GrpBoxAdd
        '
        Me.GrpBoxAdd.Controls.Add(Me.ComboCargo)
        Me.GrpBoxAdd.Controls.Add(Me.Label9)
        Me.GrpBoxAdd.Controls.Add(Me.ChkBoxAtivo)
        Me.GrpBoxAdd.Controls.Add(Me.TxtObs)
        Me.GrpBoxAdd.Controls.Add(Me.Label17)
        Me.GrpBoxAdd.Dock = System.Windows.Forms.DockStyle.Top
        Me.GrpBoxAdd.Location = New System.Drawing.Point(0, 325)
        Me.GrpBoxAdd.Margin = New System.Windows.Forms.Padding(4)
        Me.GrpBoxAdd.Name = "GrpBoxAdd"
        Me.GrpBoxAdd.Padding = New System.Windows.Forms.Padding(4)
        Me.GrpBoxAdd.Size = New System.Drawing.Size(739, 151)
        Me.GrpBoxAdd.TabIndex = 1
        Me.GrpBoxAdd.TabStop = False
        Me.GrpBoxAdd.Text = "Adicional"
        '
        'ComboCargo
        '
        Me.ComboCargo.FormattingEnabled = True
        Me.ComboCargo.Items.AddRange(New Object() {" "})
        Me.ComboCargo.Location = New System.Drawing.Point(526, 56)
        Me.ComboCargo.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboCargo.Name = "ComboCargo"
        Me.ComboCargo.Size = New System.Drawing.Size(205, 24)
        Me.ComboCargo.TabIndex = 35
        Me.ComboCargo.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(523, 35)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 17)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "Cargo"
        '
        'ChkBoxAtivo
        '
        Me.ChkBoxAtivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkBoxAtivo.AutoSize = True
        Me.ChkBoxAtivo.Checked = True
        Me.ChkBoxAtivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkBoxAtivo.Location = New System.Drawing.Point(526, 97)
        Me.ChkBoxAtivo.Name = "ChkBoxAtivo"
        Me.ChkBoxAtivo.Size = New System.Drawing.Size(58, 21)
        Me.ChkBoxAtivo.TabIndex = 31
        Me.ChkBoxAtivo.Text = "Ativo"
        Me.ChkBoxAtivo.UseVisualStyleBackColor = True
        '
        'TxtObs
        '
        Me.TxtObs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtObs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtObs.Location = New System.Drawing.Point(6, 56)
        Me.TxtObs.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtObs.Multiline = True
        Me.TxtObs.Name = "TxtObs"
        Me.TxtObs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtObs.Size = New System.Drawing.Size(507, 86)
        Me.TxtObs.TabIndex = 30
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(8, 35)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(85, 17)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Observação"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "PNG|*.png"
        '
        'Frm_Vendedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(739, 488)
        Me.Controls.Add(Me.GrpBoxAdd)
        Me.Controls.Add(Me.GrpBoxInfo)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Frm_Vendedor"
        Me.Text = "Frm_Vendedor"
        Me.GrpBoxInfo.ResumeLayout(False)
        Me.GrpBoxInfo.PerformLayout()
        CType(Me.PicBoxFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpBoxAdd.ResumeLayout(False)
        Me.GrpBoxAdd.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpBoxInfo As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNum As System.Windows.Forms.TextBox
    Friend WithEvents TxtCEP As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ComboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtLogradouro As System.Windows.Forms.TextBox
    Friend WithEvents TxtBairro As System.Windows.Forms.TextBox
    Friend WithEvents TxtCidade As System.Windows.Forms.TextBox
    Friend WithEvents TxtComplemento As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LblCep As System.Windows.Forms.Label
    Friend WithEvents TxtSobrenome As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpBoxAdd As System.Windows.Forms.GroupBox
    Friend WithEvents TxtObs As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents BtnFoto As System.Windows.Forms.Button
    Friend WithEvents PicBoxFoto As System.Windows.Forms.PictureBox
    Friend WithEvents ComboCargo As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ChkBoxAtivo As System.Windows.Forms.CheckBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ComboNome As System.Windows.Forms.ComboBox
End Class
