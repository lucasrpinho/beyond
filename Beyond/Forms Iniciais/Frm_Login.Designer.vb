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
        Me.LogoPictureBox.Location = New System.Drawing.Point(1, 15)
        Me.LogoPictureBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(196, 190)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'UsernameLabel
        '
        Me.UsernameLabel.Location = New System.Drawing.Point(205, 30)
        Me.UsernameLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(330, 28)
        Me.UsernameLabel.TabIndex = 0
        Me.UsernameLabel.Text = "Login"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Location = New System.Drawing.Point(202, 92)
        Me.PasswordLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(330, 28)
        Me.PasswordLabel.TabIndex = 2
        Me.PasswordLabel.Text = "Senha"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtSenha
        '
        Me.TxtSenha.Location = New System.Drawing.Point(205, 124)
        Me.TxtSenha.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtSenha.MaxLength = 25
        Me.TxtSenha.Name = "TxtSenha"
        Me.TxtSenha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtSenha.Size = New System.Drawing.Size(328, 24)
        Me.TxtSenha.TabIndex = 2
        '
        'BtnAcessa
        '
        Me.BtnAcessa.Enabled = False
        Me.BtnAcessa.Location = New System.Drawing.Point(297, 156)
        Me.BtnAcessa.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnAcessa.Name = "BtnAcessa"
        Me.BtnAcessa.Size = New System.Drawing.Size(141, 28)
        Me.BtnAcessa.TabIndex = 3
        Me.BtnAcessa.Text = "Acessar"
        '
        'TxtSenhaInvalida
        '
        Me.TxtSenhaInvalida.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSenhaInvalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSenhaInvalida.ForeColor = System.Drawing.Color.Red
        Me.TxtSenhaInvalida.Location = New System.Drawing.Point(18, 213)
        Me.TxtSenhaInvalida.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.TxtSenhaInvalida.Name = "TxtSenhaInvalida"
        Me.TxtSenhaInvalida.Size = New System.Drawing.Size(566, 28)
        Me.TxtSenhaInvalida.TabIndex = 5
        Me.TxtSenhaInvalida.Text = " "
        Me.TxtSenhaInvalida.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.TxtSenhaInvalida.Visible = False
        '
        'TxtLogin
        '
        Me.TxtLogin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtLogin.Location = New System.Drawing.Point(206, 62)
        Me.TxtLogin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtLogin.MaxLength = 16
        Me.TxtLogin.Name = "TxtLogin"
        Me.TxtLogin.Size = New System.Drawing.Size(327, 24)
        Me.TxtLogin.TabIndex = 1
        '
        'Frm_Login
        '
        Me.AcceptButton = Me.BtnAcessa
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(602, 252)
        Me.Controls.Add(Me.TxtLogin)
        Me.Controls.Add(Me.TxtSenhaInvalida)
        Me.Controls.Add(Me.BtnAcessa)
        Me.Controls.Add(Me.TxtSenha)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Login"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login - Beyond"
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtSenhaInvalida As System.Windows.Forms.Label
    Friend WithEvents TxtLogin As System.Windows.Forms.TextBox

End Class
