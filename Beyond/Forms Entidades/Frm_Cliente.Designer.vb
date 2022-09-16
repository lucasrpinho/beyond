<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cliente))
        Me.ComboCargo = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ChkBoxAtivo = New System.Windows.Forms.CheckBox()
        Me.TxtObs = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GrpBoxInfo = New System.Windows.Forms.GroupBox()
        Me.BtnConsCargo = New System.Windows.Forms.PictureBox()
        Me.DtPckNasc = New System.Windows.Forms.DateTimePicker()
        Me.TxtCelular = New System.Windows.Forms.MaskedTextBox()
        Me.TxtEmpresa = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboNome = New System.Windows.Forms.ComboBox()
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LblCep = New System.Windows.Forms.Label()
        Me.GrpBoxInfo.SuspendLayout()
        CType(Me.BtnConsCargo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpBoxEndereco.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboCargo
        '
        Me.ComboCargo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboCargo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ComboCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCargo.FormattingEnabled = True
        Me.ComboCargo.Items.AddRange(New Object() {" "})
        Me.ComboCargo.Location = New System.Drawing.Point(343, 171)
        Me.ComboCargo.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboCargo.Name = "ComboCargo"
        Me.ComboCargo.Size = New System.Drawing.Size(369, 24)
        Me.ComboCargo.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(340, 150)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 17)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "Cargo"
        '
        'ChkBoxAtivo
        '
        Me.ChkBoxAtivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkBoxAtivo.AutoSize = True
        Me.ChkBoxAtivo.Checked = True
        Me.ChkBoxAtivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkBoxAtivo.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkBoxAtivo.Location = New System.Drawing.Point(11, 209)
        Me.ChkBoxAtivo.Name = "ChkBoxAtivo"
        Me.ChkBoxAtivo.Size = New System.Drawing.Size(60, 18)
        Me.ChkBoxAtivo.TabIndex = 8
        Me.ChkBoxAtivo.Text = "Ativo"
        Me.ChkBoxAtivo.UseVisualStyleBackColor = True
        '
        'TxtObs
        '
        Me.TxtObs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtObs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtObs.Location = New System.Drawing.Point(9, 263)
        Me.TxtObs.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtObs.MaxLength = 255
        Me.TxtObs.Multiline = True
        Me.TxtObs.Name = "TxtObs"
        Me.TxtObs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtObs.Size = New System.Drawing.Size(703, 56)
        Me.TxtObs.TabIndex = 7
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 235)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(75, 17)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Descrição"
        '
        'GrpBoxInfo
        '
        Me.GrpBoxInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpBoxInfo.BackColor = System.Drawing.Color.Transparent
        Me.GrpBoxInfo.Controls.Add(Me.BtnConsCargo)
        Me.GrpBoxInfo.Controls.Add(Me.DtPckNasc)
        Me.GrpBoxInfo.Controls.Add(Me.TxtCelular)
        Me.GrpBoxInfo.Controls.Add(Me.Label17)
        Me.GrpBoxInfo.Controls.Add(Me.TxtObs)
        Me.GrpBoxInfo.Controls.Add(Me.TxtEmpresa)
        Me.GrpBoxInfo.Controls.Add(Me.Label3)
        Me.GrpBoxInfo.Controls.Add(Me.ComboCargo)
        Me.GrpBoxInfo.Controls.Add(Me.Label9)
        Me.GrpBoxInfo.Controls.Add(Me.ChkBoxAtivo)
        Me.GrpBoxInfo.Controls.Add(Me.Label11)
        Me.GrpBoxInfo.Controls.Add(Me.TxtEmail)
        Me.GrpBoxInfo.Controls.Add(Me.Label10)
        Me.GrpBoxInfo.Controls.Add(Me.Label2)
        Me.GrpBoxInfo.Controls.Add(Me.ComboNome)
        Me.GrpBoxInfo.Controls.Add(Me.Label1)
        Me.GrpBoxInfo.Location = New System.Drawing.Point(13, 13)
        Me.GrpBoxInfo.Margin = New System.Windows.Forms.Padding(4)
        Me.GrpBoxInfo.Name = "GrpBoxInfo"
        Me.GrpBoxInfo.Padding = New System.Windows.Forms.Padding(4)
        Me.GrpBoxInfo.Size = New System.Drawing.Size(725, 327)
        Me.GrpBoxInfo.TabIndex = 1
        Me.GrpBoxInfo.TabStop = False
        Me.GrpBoxInfo.Text = "Informações"
        '
        'BtnConsCargo
        '
        Me.BtnConsCargo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConsCargo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConsCargo.Image = Global.Beyond.My.Resources.Resources.search
        Me.BtnConsCargo.Location = New System.Drawing.Point(687, 202)
        Me.BtnConsCargo.Name = "BtnConsCargo"
        Me.BtnConsCargo.Size = New System.Drawing.Size(25, 25)
        Me.BtnConsCargo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.BtnConsCargo.TabIndex = 42
        Me.BtnConsCargo.TabStop = False
        Me.BtnConsCargo.Visible = False
        '
        'DtPckNasc
        '
        Me.DtPckNasc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DtPckNasc.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtPckNasc.Location = New System.Drawing.Point(594, 52)
        Me.DtPckNasc.MaxDate = New Date(2200, 12, 31, 0, 0, 0, 0)
        Me.DtPckNasc.MinDate = New Date(1922, 1, 1, 0, 0, 0, 0)
        Me.DtPckNasc.Name = "DtPckNasc"
        Me.DtPckNasc.Size = New System.Drawing.Size(118, 24)
        Me.DtPckNasc.TabIndex = 2
        '
        'TxtCelular
        '
        Me.TxtCelular.Location = New System.Drawing.Point(9, 111)
        Me.TxtCelular.Mask = "(00) 00000-0000"
        Me.TxtCelular.Name = "TxtCelular"
        Me.TxtCelular.Size = New System.Drawing.Size(137, 24)
        Me.TxtCelular.TabIndex = 3
        '
        'TxtEmpresa
        '
        Me.TxtEmpresa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtEmpresa.Location = New System.Drawing.Point(9, 171)
        Me.TxtEmpresa.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtEmpresa.MaxLength = 50
        Me.TxtEmpresa.Name = "TxtEmpresa"
        Me.TxtEmpresa.Size = New System.Drawing.Size(307, 24)
        Me.TxtEmpresa.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 150)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 17)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Empresa"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(591, 32)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(127, 17)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "Data Nascimento"
        '
        'TxtEmail
        '
        Me.TxtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtEmail.Location = New System.Drawing.Point(174, 111)
        Me.TxtEmail.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtEmail.MaxLength = 100
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(538, 24)
        Me.TxtEmail.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(171, 90)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 17)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "E-mail"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 90)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 17)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Celular"
        '
        'ComboNome
        '
        Me.ComboNome.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboNome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.ComboNome.FormattingEnabled = True
        Me.ComboNome.Location = New System.Drawing.Point(9, 52)
        Me.ComboNome.MaxLength = 90
        Me.ComboNome.Name = "ComboNome"
        Me.ComboNome.Size = New System.Drawing.Size(563, 24)
        Me.ComboNome.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 31)
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
        Me.GrpBoxEndereco.BackColor = System.Drawing.Color.Transparent
        Me.GrpBoxEndereco.Controls.Add(Me.TxtCidade)
        Me.GrpBoxEndereco.Controls.Add(Me.TxtNum)
        Me.GrpBoxEndereco.Controls.Add(Me.TxtCEP)
        Me.GrpBoxEndereco.Controls.Add(Me.ComboEstado)
        Me.GrpBoxEndereco.Controls.Add(Me.Label8)
        Me.GrpBoxEndereco.Controls.Add(Me.TxtLogradouro)
        Me.GrpBoxEndereco.Controls.Add(Me.TxtBairro)
        Me.GrpBoxEndereco.Controls.Add(Me.TxtComplemento)
        Me.GrpBoxEndereco.Controls.Add(Me.Label4)
        Me.GrpBoxEndereco.Controls.Add(Me.Label7)
        Me.GrpBoxEndereco.Controls.Add(Me.Label6)
        Me.GrpBoxEndereco.Controls.Add(Me.Label5)
        Me.GrpBoxEndereco.Controls.Add(Me.Label12)
        Me.GrpBoxEndereco.Controls.Add(Me.LblCep)
        Me.GrpBoxEndereco.Location = New System.Drawing.Point(13, 347)
        Me.GrpBoxEndereco.Name = "GrpBoxEndereco"
        Me.GrpBoxEndereco.Size = New System.Drawing.Size(723, 205)
        Me.GrpBoxEndereco.TabIndex = 2
        Me.GrpBoxEndereco.TabStop = False
        Me.GrpBoxEndereco.Text = "Endereço de Entrega"
        '
        'TxtCidade
        '
        Me.TxtCidade.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCidade.Location = New System.Drawing.Point(346, 106)
        Me.TxtCidade.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCidade.MaxLength = 50
        Me.TxtCidade.Name = "TxtCidade"
        Me.TxtCidade.Size = New System.Drawing.Size(366, 24)
        Me.TxtCidade.TabIndex = 13
        '
        'TxtNum
        '
        Me.TxtNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNum.Location = New System.Drawing.Point(13, 106)
        Me.TxtNum.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNum.MaxLength = 5
        Me.TxtNum.Name = "TxtNum"
        Me.TxtNum.Size = New System.Drawing.Size(100, 24)
        Me.TxtNum.TabIndex = 11
        '
        'TxtCEP
        '
        Me.TxtCEP.Location = New System.Drawing.Point(13, 49)
        Me.TxtCEP.Mask = "00000-000"
        Me.TxtCEP.Name = "TxtCEP"
        Me.TxtCEP.Size = New System.Drawing.Size(100, 24)
        Me.TxtCEP.TabIndex = 9
        '
        'ComboEstado
        '
        Me.ComboEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboEstado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ComboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboEstado.FormattingEnabled = True
        Me.ComboEstado.Items.AddRange(New Object() {" "})
        Me.ComboEstado.Location = New System.Drawing.Point(498, 164)
        Me.ComboEstado.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboEstado.MaxLength = 2
        Me.ComboEstado.Name = "ComboEstado"
        Me.ComboEstado.Size = New System.Drawing.Size(214, 24)
        Me.ComboEstado.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(495, 143)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 17)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "Estado"
        '
        'TxtLogradouro
        '
        Me.TxtLogradouro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtLogradouro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLogradouro.Location = New System.Drawing.Point(135, 49)
        Me.TxtLogradouro.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtLogradouro.MaxLength = 100
        Me.TxtLogradouro.Name = "TxtLogradouro"
        Me.TxtLogradouro.Size = New System.Drawing.Size(577, 24)
        Me.TxtLogradouro.TabIndex = 10
        '
        'TxtBairro
        '
        Me.TxtBairro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtBairro.Location = New System.Drawing.Point(13, 164)
        Me.TxtBairro.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtBairro.MaxLength = 30
        Me.TxtBairro.Name = "TxtBairro"
        Me.TxtBairro.Size = New System.Drawing.Size(210, 24)
        Me.TxtBairro.TabIndex = 14
        '
        'TxtComplemento
        '
        Me.TxtComplemento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtComplemento.Location = New System.Drawing.Point(136, 106)
        Me.TxtComplemento.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtComplemento.MaxLength = 30
        Me.TxtComplemento.Name = "TxtComplemento"
        Me.TxtComplemento.Size = New System.Drawing.Size(183, 24)
        Me.TxtComplemento.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(343, 85)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 17)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "Cidade"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 143)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 17)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "Bairro"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(133, 86)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 17)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "Complemento"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 86)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 17)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "Número"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(133, 30)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 17)
        Me.Label12.TabIndex = 49
        Me.Label12.Text = "Logradouro"
        '
        'LblCep
        '
        Me.LblCep.AutoSize = True
        Me.LblCep.Location = New System.Drawing.Point(12, 30)
        Me.LblCep.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblCep.Name = "LblCep"
        Me.LblCep.Size = New System.Drawing.Size(35, 17)
        Me.LblCep.TabIndex = 48
        Me.LblCep.Text = "CEP"
        '
        'Frm_Cliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Menu
        Me.ClientSize = New System.Drawing.Size(748, 564)
        Me.Controls.Add(Me.GrpBoxEndereco)
        Me.Controls.Add(Me.GrpBoxInfo)
        Me.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Cliente"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cliente"
        Me.GrpBoxInfo.ResumeLayout(False)
        Me.GrpBoxInfo.PerformLayout()
        CType(Me.BtnConsCargo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpBoxEndereco.ResumeLayout(False)
        Me.GrpBoxEndereco.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ComboCargo As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ChkBoxAtivo As System.Windows.Forms.CheckBox
    Friend WithEvents TxtObs As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GrpBoxInfo As System.Windows.Forms.GroupBox
    Friend WithEvents ComboNome As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GrpBoxEndereco As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCidade As System.Windows.Forms.TextBox
    Friend WithEvents TxtNum As System.Windows.Forms.TextBox
    Friend WithEvents TxtCEP As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ComboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtLogradouro As System.Windows.Forms.TextBox
    Friend WithEvents TxtBairro As System.Windows.Forms.TextBox
    Friend WithEvents TxtComplemento As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents LblCep As System.Windows.Forms.Label
    Friend WithEvents TxtCelular As System.Windows.Forms.MaskedTextBox
    Friend WithEvents DtPckNasc As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnConsCargo As System.Windows.Forms.PictureBox
End Class
