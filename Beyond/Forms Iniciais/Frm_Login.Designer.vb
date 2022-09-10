<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class Frm_Login
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
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents TxtSenha As System.Windows.Forms.TextBox
    Friend WithEvents BtnAcessa As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Login))
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.TxtSenha = New System.Windows.Forms.TextBox()
        Me.BtnAcessa = New System.Windows.Forms.Button()
        Me.TxtSenhaInvalida = New System.Windows.Forms.Label()
        Me.TxtLogin = New System.Windows.Forms.TextBox()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), System.Drawing.Image)
        Me.LogoPictureBox.Location = New System.Drawing.Point(2, 13)
        Me.LogoPictureBox.Margin = New System.Windows.Forms.Padding(4)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(121, 125)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'UsernameLabel
        '
        Me.UsernameLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameLabel.Location = New System.Drawing.Point(128, 26)
        Me.UsernameLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(293, 24)
        Me.UsernameLabel.TabIndex = 0
        Me.UsernameLabel.Text = "Login"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordLabel.Location = New System.Drawing.Point(128, 79)
        Me.PasswordLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(293, 24)
        Me.PasswordLabel.TabIndex = 2
        Me.PasswordLabel.Text = "Senha"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtSenha
        '
        Me.TxtSenha.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSenha.Location = New System.Drawing.Point(131, 107)
        Me.TxtSenha.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtSenha.MaxLength = 25
        Me.TxtSenha.Name = "TxtSenha"
        Me.TxtSenha.Size = New System.Drawing.Size(292, 22)
        Me.TxtSenha.TabIndex = 2
        Me.TxtSenha.UseSystemPasswordChar = True
        '
        'BtnAcessa
        '
        Me.BtnAcessa.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnAcessa.Enabled = False
        Me.BtnAcessa.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAcessa.Location = New System.Drawing.Point(209, 136)
        Me.BtnAcessa.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnAcessa.Name = "BtnAcessa"
        Me.BtnAcessa.Size = New System.Drawing.Size(95, 35)
        Me.BtnAcessa.TabIndex = 3
        Me.BtnAcessa.Text = "Entrar"
        Me.BtnAcessa.UseVisualStyleBackColor = False
        '
        'TxtSenhaInvalida
        '
        Me.TxtSenhaInvalida.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSenhaInvalida.Font = New System.Drawing.Font("Verdana", 7.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSenhaInvalida.ForeColor = System.Drawing.Color.Red
        Me.TxtSenhaInvalida.Location = New System.Drawing.Point(16, 186)
        Me.TxtSenhaInvalida.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.TxtSenhaInvalida.Name = "TxtSenhaInvalida"
        Me.TxtSenhaInvalida.Size = New System.Drawing.Size(402, 24)
        Me.TxtSenhaInvalida.TabIndex = 5
        Me.TxtSenhaInvalida.Text = " "
        Me.TxtSenhaInvalida.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.TxtSenhaInvalida.Visible = False
        '
        'TxtLogin
        '
        Me.TxtLogin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLogin.Font = New System.Drawing.Font("Verdana", 9.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLogin.Location = New System.Drawing.Point(131, 54)
        Me.TxtLogin.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtLogin.MaxLength = 16
        Me.TxtLogin.Name = "TxtLogin"
        Me.TxtLogin.Size = New System.Drawing.Size(291, 22)
        Me.TxtLogin.TabIndex = 1
        '
        'Frm_Login
        '
        Me.AcceptButton = Me.BtnAcessa
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(434, 220)
        Me.Controls.Add(Me.TxtLogin)
        Me.Controls.Add(Me.TxtSenhaInvalida)
        Me.Controls.Add(Me.BtnAcessa)
        Me.Controls.Add(Me.TxtSenha)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.Font = New System.Drawing.Font("Verdana", 8.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Login"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtSenhaInvalida As System.Windows.Forms.Label
    Friend WithEvents TxtLogin As System.Windows.Forms.TextBox

End Class
