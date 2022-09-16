<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cargo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cargo))
        Me.GrpBoxCfg = New System.Windows.Forms.GroupBox()
        Me.ChkVendedor = New System.Windows.Forms.CheckBox()
        Me.ChkBoxAtivo = New System.Windows.Forms.CheckBox()
        Me.GrpBoxInfo = New System.Windows.Forms.GroupBox()
        Me.ComboNome = New System.Windows.Forms.ComboBox()
        Me.TxtDesc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GrpBoxCfg.SuspendLayout()
        Me.GrpBoxInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpBoxCfg
        '
        Me.GrpBoxCfg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpBoxCfg.BackColor = System.Drawing.Color.Transparent
        Me.GrpBoxCfg.Controls.Add(Me.ChkVendedor)
        Me.GrpBoxCfg.Controls.Add(Me.ChkBoxAtivo)
        Me.GrpBoxCfg.Location = New System.Drawing.Point(12, 256)
        Me.GrpBoxCfg.Name = "GrpBoxCfg"
        Me.GrpBoxCfg.Size = New System.Drawing.Size(561, 105)
        Me.GrpBoxCfg.TabIndex = 0
        Me.GrpBoxCfg.TabStop = False
        Me.GrpBoxCfg.Text = "Configuração"
        '
        'ChkVendedor
        '
        Me.ChkVendedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkVendedor.AutoSize = True
        Me.ChkVendedor.Location = New System.Drawing.Point(6, 63)
        Me.ChkVendedor.Name = "ChkVendedor"
        Me.ChkVendedor.Size = New System.Drawing.Size(94, 21)
        Me.ChkVendedor.TabIndex = 4
        Me.ChkVendedor.Text = "Vendedor"
        Me.ChkVendedor.UseVisualStyleBackColor = True
        '
        'ChkBoxAtivo
        '
        Me.ChkBoxAtivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkBoxAtivo.AutoSize = True
        Me.ChkBoxAtivo.Checked = True
        Me.ChkBoxAtivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkBoxAtivo.Location = New System.Drawing.Point(6, 27)
        Me.ChkBoxAtivo.Name = "ChkBoxAtivo"
        Me.ChkBoxAtivo.Size = New System.Drawing.Size(63, 21)
        Me.ChkBoxAtivo.TabIndex = 3
        Me.ChkBoxAtivo.Text = "Ativo"
        Me.ChkBoxAtivo.UseVisualStyleBackColor = True
        '
        'GrpBoxInfo
        '
        Me.GrpBoxInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpBoxInfo.BackColor = System.Drawing.Color.Transparent
        Me.GrpBoxInfo.Controls.Add(Me.ComboNome)
        Me.GrpBoxInfo.Controls.Add(Me.TxtDesc)
        Me.GrpBoxInfo.Controls.Add(Me.Label2)
        Me.GrpBoxInfo.Controls.Add(Me.Label1)
        Me.GrpBoxInfo.Location = New System.Drawing.Point(12, 23)
        Me.GrpBoxInfo.Name = "GrpBoxInfo"
        Me.GrpBoxInfo.Size = New System.Drawing.Size(561, 227)
        Me.GrpBoxInfo.TabIndex = 1
        Me.GrpBoxInfo.TabStop = False
        Me.GrpBoxInfo.Text = "Informações de Cargo"
        '
        'ComboNome
        '
        Me.ComboNome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.ComboNome.FormattingEnabled = True
        Me.ComboNome.Items.AddRange(New Object() {" "})
        Me.ComboNome.Location = New System.Drawing.Point(7, 59)
        Me.ComboNome.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboNome.Name = "ComboNome"
        Me.ComboNome.Size = New System.Drawing.Size(547, 24)
        Me.ComboNome.TabIndex = 1
        '
        'TxtDesc
        '
        Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDesc.Location = New System.Drawing.Point(6, 115)
        Me.TxtDesc.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtDesc.MaxLength = 1000
        Me.TxtDesc.Multiline = True
        Me.TxtDesc.Name = "TxtDesc"
        Me.TxtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtDesc.Size = New System.Drawing.Size(547, 93)
        Me.TxtDesc.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 96)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Descrição"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 38)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 17)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Nome do cargo"
        '
        'Frm_Cargo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Menu
        Me.ClientSize = New System.Drawing.Size(585, 373)
        Me.Controls.Add(Me.GrpBoxInfo)
        Me.Controls.Add(Me.GrpBoxCfg)
        Me.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Cargo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cargo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpBoxCfg.ResumeLayout(False)
        Me.GrpBoxCfg.PerformLayout()
        Me.GrpBoxInfo.ResumeLayout(False)
        Me.GrpBoxInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpBoxCfg As System.Windows.Forms.GroupBox
    Friend WithEvents ChkVendedor As System.Windows.Forms.CheckBox
    Friend WithEvents ChkBoxAtivo As System.Windows.Forms.CheckBox
    Friend WithEvents GrpBoxInfo As System.Windows.Forms.GroupBox
    Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboNome As System.Windows.Forms.ComboBox
End Class
