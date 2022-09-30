<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_Login
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UC_Login))
        Me.TxtLogin = New System.Windows.Forms.TextBox()
        Me.TxtSenhaInvalida = New System.Windows.Forms.Label()
        Me.TxtSenha = New System.Windows.Forms.TextBox()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.BtnSair = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnAcessa = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtLogin
        '
        Me.TxtLogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtLogin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLogin.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLogin.Location = New System.Drawing.Point(7, 152)
        Me.TxtLogin.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtLogin.MaxLength = 0
        Me.TxtLogin.Name = "TxtLogin"
        Me.TxtLogin.Size = New System.Drawing.Size(227, 22)
        Me.TxtLogin.TabIndex = 8
        '
        'TxtSenhaInvalida
        '
        Me.TxtSenhaInvalida.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSenhaInvalida.Font = New System.Drawing.Font("Verdana", 7.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSenhaInvalida.ForeColor = System.Drawing.Color.Red
        Me.TxtSenhaInvalida.Location = New System.Drawing.Point(7, 274)
        Me.TxtSenhaInvalida.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.TxtSenhaInvalida.Name = "TxtSenhaInvalida"
        Me.TxtSenhaInvalida.Size = New System.Drawing.Size(227, 29)
        Me.TxtSenhaInvalida.TabIndex = 12
        Me.TxtSenhaInvalida.Text = " "
        Me.TxtSenhaInvalida.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.TxtSenhaInvalida.Visible = False
        '
        'TxtSenha
        '
        Me.TxtSenha.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSenha.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSenha.Location = New System.Drawing.Point(7, 205)
        Me.TxtSenha.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtSenha.MaxLength = 0
        Me.TxtSenha.Name = "TxtSenha"
        Me.TxtSenha.Size = New System.Drawing.Size(227, 22)
        Me.TxtSenha.TabIndex = 9
        Me.TxtSenha.UseSystemPasswordChar = True
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PasswordLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordLabel.Location = New System.Drawing.Point(6, 178)
        Me.PasswordLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(230, 24)
        Me.PasswordLabel.TabIndex = 10
        Me.PasswordLabel.Text = "Senha"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UsernameLabel
        '
        Me.UsernameLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UsernameLabel.BackColor = System.Drawing.Color.Transparent
        Me.UsernameLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameLabel.Location = New System.Drawing.Point(7, 124)
        Me.UsernameLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(227, 24)
        Me.UsernameLabel.TabIndex = 6
        Me.UsernameLabel.Text = "Login"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnSair
        '
        Me.BtnSair.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.BtnSair.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSair.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSair.ImageKey = "logout.png"
        Me.BtnSair.ImageList = Me.ImageList1
        Me.BtnSair.Location = New System.Drawing.Point(165, 235)
        Me.BtnSair.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSair.Name = "BtnSair"
        Me.BtnSair.Size = New System.Drawing.Size(69, 35)
        Me.BtnSair.TabIndex = 14
        Me.BtnSair.Text = "Sair"
        Me.BtnSair.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSair.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "lockin.png")
        Me.ImageList1.Images.SetKeyName(1, "logout.png")
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(62, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(123, 118)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'BtnAcessa
        '
        Me.BtnAcessa.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.BtnAcessa.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnAcessa.Enabled = False
        Me.BtnAcessa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAcessa.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAcessa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAcessa.ImageKey = "lockin.png"
        Me.BtnAcessa.ImageList = Me.ImageList1
        Me.BtnAcessa.Location = New System.Drawing.Point(7, 235)
        Me.BtnAcessa.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnAcessa.Name = "BtnAcessa"
        Me.BtnAcessa.Size = New System.Drawing.Size(84, 35)
        Me.BtnAcessa.TabIndex = 11
        Me.BtnAcessa.Text = "Entrar"
        Me.BtnAcessa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAcessa.UseVisualStyleBackColor = False
        '
        'UC_Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PowderBlue
        Me.Controls.Add(Me.BtnSair)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TxtLogin)
        Me.Controls.Add(Me.TxtSenhaInvalida)
        Me.Controls.Add(Me.BtnAcessa)
        Me.Controls.Add(Me.TxtSenha)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "UC_Login"
        Me.Size = New System.Drawing.Size(240, 359)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtLogin As System.Windows.Forms.TextBox
    Friend WithEvents TxtSenhaInvalida As System.Windows.Forms.Label
    Friend WithEvents BtnAcessa As System.Windows.Forms.Button
    Friend WithEvents TxtSenha As System.Windows.Forms.TextBox
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnSair As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList

End Class
