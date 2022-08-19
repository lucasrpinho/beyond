<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Sobre
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Sobre))
        Me.LblNomeSistema = New System.Windows.Forms.Label()
        Me.LblNomeAutor = New System.Windows.Forms.Label()
        Me.LblNumSistema = New System.Windows.Forms.Label()
        Me.LblDataVersao = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnEntrar = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblNomeSistema
        '
        Me.LblNomeSistema.AutoSize = True
        Me.LblNomeSistema.Location = New System.Drawing.Point(269, 29)
        Me.LblNomeSistema.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNomeSistema.Name = "LblNomeSistema"
        Me.LblNomeSistema.Size = New System.Drawing.Size(51, 17)
        Me.LblNomeSistema.TabIndex = 0
        Me.LblNomeSistema.Text = "Label1"
        '
        'LblNomeAutor
        '
        Me.LblNomeAutor.AutoSize = True
        Me.LblNomeAutor.Location = New System.Drawing.Point(269, 83)
        Me.LblNomeAutor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNomeAutor.Name = "LblNomeAutor"
        Me.LblNomeAutor.Size = New System.Drawing.Size(51, 17)
        Me.LblNomeAutor.TabIndex = 1
        Me.LblNomeAutor.Text = "Label2"
        '
        'LblNumSistema
        '
        Me.LblNumSistema.AutoSize = True
        Me.LblNumSistema.Location = New System.Drawing.Point(269, 141)
        Me.LblNumSistema.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNumSistema.Name = "LblNumSistema"
        Me.LblNumSistema.Size = New System.Drawing.Size(51, 17)
        Me.LblNumSistema.TabIndex = 2
        Me.LblNumSistema.Text = "Label3"
        '
        'LblDataVersao
        '
        Me.LblDataVersao.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblDataVersao.AutoSize = True
        Me.LblDataVersao.Location = New System.Drawing.Point(422, 141)
        Me.LblDataVersao.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDataVersao.Name = "LblDataVersao"
        Me.LblDataVersao.Size = New System.Drawing.Size(51, 17)
        Me.LblDataVersao.TabIndex = 3
        Me.LblDataVersao.Text = "Label4"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(201, 187)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'BtnEntrar
        '
        Me.BtnEntrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnEntrar.Location = New System.Drawing.Point(425, 196)
        Me.BtnEntrar.Name = "BtnEntrar"
        Me.BtnEntrar.Size = New System.Drawing.Size(97, 28)
        Me.BtnEntrar.TabIndex = 5
        Me.BtnEntrar.Text = "Entrar"
        Me.BtnEntrar.UseVisualStyleBackColor = True
        '
        'Frm_Sobre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 236)
        Me.Controls.Add(Me.BtnEntrar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LblDataVersao)
        Me.Controls.Add(Me.LblNumSistema)
        Me.Controls.Add(Me.LblNomeAutor)
        Me.Controls.Add(Me.LblNomeSistema)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Frm_Sobre"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sobre - Beyond"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblNomeSistema As System.Windows.Forms.Label
    Friend WithEvents LblNomeAutor As System.Windows.Forms.Label
    Friend WithEvents LblNumSistema As System.Windows.Forms.Label
    Friend WithEvents LblDataVersao As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnEntrar As System.Windows.Forms.Button

End Class
