<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Usuario
    Inherits Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Usuario))
        Me.GrpBoxInfo = New System.Windows.Forms.GroupBox()
        Me.ComboNome = New System.Windows.Forms.ComboBox()
        Me.ChkBoxAtivo = New System.Windows.Forms.CheckBox()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtSobrenome = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtLogin = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtSenha = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtSenhaConfirmar = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GrpBoxCredenciais = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GrpBoxInfo.SuspendLayout()
        Me.GrpBoxCredenciais.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpBoxInfo
        '
        Me.GrpBoxInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpBoxInfo.BackColor = System.Drawing.Color.Transparent
        Me.GrpBoxInfo.Controls.Add(Me.ComboNome)
        Me.GrpBoxInfo.Controls.Add(Me.ChkBoxAtivo)
        Me.GrpBoxInfo.Controls.Add(Me.TxtEmail)
        Me.GrpBoxInfo.Controls.Add(Me.Label6)
        Me.GrpBoxInfo.Controls.Add(Me.TxtSobrenome)
        Me.GrpBoxInfo.Controls.Add(Me.Label2)
        Me.GrpBoxInfo.Controls.Add(Me.Label1)
        Me.GrpBoxInfo.Location = New System.Drawing.Point(16, 15)
        Me.GrpBoxInfo.Margin = New System.Windows.Forms.Padding(4)
        Me.GrpBoxInfo.Name = "GrpBoxInfo"
        Me.GrpBoxInfo.Padding = New System.Windows.Forms.Padding(4)
        Me.GrpBoxInfo.Size = New System.Drawing.Size(539, 214)
        Me.GrpBoxInfo.TabIndex = 0
        Me.GrpBoxInfo.TabStop = False
        Me.GrpBoxInfo.Text = "Informações"
        '
        'ComboNome
        '
        Me.ComboNome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.ComboNome.FormattingEnabled = True
        Me.ComboNome.Items.AddRange(New Object() {" "})
        Me.ComboNome.Location = New System.Drawing.Point(11, 59)
        Me.ComboNome.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboNome.MaxLength = 30
        Me.ComboNome.Name = "ComboNome"
        Me.ComboNome.Size = New System.Drawing.Size(338, 24)
        Me.ComboNome.TabIndex = 1
        '
        'ChkBoxAtivo
        '
        Me.ChkBoxAtivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkBoxAtivo.AutoSize = True
        Me.ChkBoxAtivo.Checked = True
        Me.ChkBoxAtivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkBoxAtivo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ChkBoxAtivo.Font = New System.Drawing.Font("Verdana", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkBoxAtivo.Location = New System.Drawing.Point(461, 181)
        Me.ChkBoxAtivo.Name = "ChkBoxAtivo"
        Me.ChkBoxAtivo.Size = New System.Drawing.Size(60, 18)
        Me.ChkBoxAtivo.TabIndex = 10
        Me.ChkBoxAtivo.Text = "Ativo"
        Me.ChkBoxAtivo.UseVisualStyleBackColor = True
        '
        'TxtEmail
        '
        Me.TxtEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtEmail.BackColor = System.Drawing.SystemColors.Window
        Me.TxtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtEmail.Location = New System.Drawing.Point(11, 175)
        Me.TxtEmail.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtEmail.MaxLength = 254
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(338, 24)
        Me.TxtEmail.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 154)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 17)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "E-mail"
        '
        'TxtSobrenome
        '
        Me.TxtSobrenome.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSobrenome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSobrenome.Location = New System.Drawing.Point(11, 117)
        Me.TxtSobrenome.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtSobrenome.MaxLength = 50
        Me.TxtSobrenome.Name = "TxtSobrenome"
        Me.TxtSobrenome.Size = New System.Drawing.Size(338, 24)
        Me.TxtSobrenome.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 96)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Sobrenome"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 38)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nome"
        '
        'TxtLogin
        '
        Me.TxtLogin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLogin.Location = New System.Drawing.Point(8, 57)
        Me.TxtLogin.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtLogin.MaxLength = 16
        Me.TxtLogin.Name = "TxtLogin"
        Me.TxtLogin.Size = New System.Drawing.Size(205, 24)
        Me.TxtLogin.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 36)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 17)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Login"
        '
        'TxtSenha
        '
        Me.TxtSenha.Location = New System.Drawing.Point(8, 119)
        Me.TxtSenha.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtSenha.MaxLength = 20
        Me.TxtSenha.Name = "TxtSenha"
        Me.TxtSenha.Size = New System.Drawing.Size(205, 24)
        Me.TxtSenha.TabIndex = 5
        Me.TxtSenha.UseSystemPasswordChar = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 98)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 17)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Senha"
        '
        'TxtSenhaConfirmar
        '
        Me.TxtSenhaConfirmar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TxtSenhaConfirmar.Location = New System.Drawing.Point(8, 175)
        Me.TxtSenhaConfirmar.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtSenhaConfirmar.MaxLength = 20
        Me.TxtSenhaConfirmar.Name = "TxtSenhaConfirmar"
        Me.TxtSenhaConfirmar.Size = New System.Drawing.Size(205, 24)
        Me.TxtSenhaConfirmar.TabIndex = 6
        Me.TxtSenhaConfirmar.UseSystemPasswordChar = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 152)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(131, 17)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Confirme a senha"
        '
        'GrpBoxCredenciais
        '
        Me.GrpBoxCredenciais.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpBoxCredenciais.BackColor = System.Drawing.Color.Transparent
        Me.GrpBoxCredenciais.Controls.Add(Me.PictureBox1)
        Me.GrpBoxCredenciais.Controls.Add(Me.TxtLogin)
        Me.GrpBoxCredenciais.Controls.Add(Me.Label4)
        Me.GrpBoxCredenciais.Controls.Add(Me.Label5)
        Me.GrpBoxCredenciais.Controls.Add(Me.TxtSenhaConfirmar)
        Me.GrpBoxCredenciais.Controls.Add(Me.Label3)
        Me.GrpBoxCredenciais.Controls.Add(Me.TxtSenha)
        Me.GrpBoxCredenciais.Location = New System.Drawing.Point(13, 237)
        Me.GrpBoxCredenciais.Margin = New System.Windows.Forms.Padding(4)
        Me.GrpBoxCredenciais.Name = "GrpBoxCredenciais"
        Me.GrpBoxCredenciais.Padding = New System.Windows.Forms.Padding(4)
        Me.GrpBoxCredenciais.Size = New System.Drawing.Size(539, 225)
        Me.GrpBoxCredenciais.TabIndex = 11
        Me.GrpBoxCredenciais.TabStop = False
        Me.GrpBoxCredenciais.Text = "Credenciais"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Beyond.My.Resources.Resources.password
        Me.PictureBox1.Location = New System.Drawing.Point(220, 120)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(25, 23)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'Frm_Usuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Menu
        Me.ClientSize = New System.Drawing.Size(571, 490)
        Me.Controls.Add(Me.GrpBoxCredenciais)
        Me.Controls.Add(Me.GrpBoxInfo)
        Me.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Usuario"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Usuário"
        Me.GrpBoxInfo.ResumeLayout(False)
        Me.GrpBoxInfo.PerformLayout()
        Me.GrpBoxCredenciais.ResumeLayout(False)
        Me.GrpBoxCredenciais.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpBoxInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtSobrenome As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ChkBoxAtivo As System.Windows.Forms.CheckBox
    Friend WithEvents TxtSenhaConfirmar As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtSenha As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtLogin As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GrpBoxCredenciais As System.Windows.Forms.GroupBox
    Friend WithEvents TxtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboNome As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
