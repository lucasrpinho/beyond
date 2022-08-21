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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblNomeSistema
        '
        Me.LblNomeSistema.AutoSize = True
        Me.LblNomeSistema.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNomeSistema.Location = New System.Drawing.Point(325, 38)
        Me.LblNomeSistema.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNomeSistema.Name = "LblNomeSistema"
        Me.LblNomeSistema.Size = New System.Drawing.Size(101, 31)
        Me.LblNomeSistema.TabIndex = 0
        Me.LblNomeSistema.Text = "Label1"
        Me.LblNomeSistema.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LblNomeAutor
        '
        Me.LblNomeAutor.AutoSize = True
        Me.LblNomeAutor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNomeAutor.Location = New System.Drawing.Point(290, 99)
        Me.LblNomeAutor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNomeAutor.Name = "LblNomeAutor"
        Me.LblNomeAutor.Size = New System.Drawing.Size(57, 17)
        Me.LblNomeAutor.TabIndex = 1
        Me.LblNomeAutor.Text = "Label2"
        '
        'LblNumSistema
        '
        Me.LblNumSistema.AutoSize = True
        Me.LblNumSistema.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNumSistema.Location = New System.Drawing.Point(290, 155)
        Me.LblNumSistema.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblNumSistema.Name = "LblNumSistema"
        Me.LblNumSistema.Size = New System.Drawing.Size(57, 17)
        Me.LblNumSistema.TabIndex = 2
        Me.LblNumSistema.Text = "Label3"
        '
        'LblDataVersao
        '
        Me.LblDataVersao.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblDataVersao.AutoSize = True
        Me.LblDataVersao.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDataVersao.Location = New System.Drawing.Point(134, 227)
        Me.LblDataVersao.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDataVersao.Name = "LblDataVersao"
        Me.LblDataVersao.Size = New System.Drawing.Size(57, 17)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(345, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Sistema"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(228, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Autor:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(228, 155)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Número:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 227)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Data da versão:"
        '
        'Frm_Sobre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 261)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LblDataVersao)
        Me.Controls.Add(Me.LblNumSistema)
        Me.Controls.Add(Me.LblNomeAutor)
        Me.Controls.Add(Me.LblNomeSistema)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
