<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Cliente_Cargo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Cliente_Cargo))
        Me.GrpInfo = New System.Windows.Forms.GroupBox()
        Me.BtnDesvincular = New System.Windows.Forms.Button()
        Me.TxtCargo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtCliente = New System.Windows.Forms.TextBox()
        Me.Label999 = New System.Windows.Forms.Label()
        Me.ChkAtivo = New System.Windows.Forms.CheckBox()
        Me.GrpInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpInfo
        '
        Me.GrpInfo.Controls.Add(Me.ChkAtivo)
        Me.GrpInfo.Controls.Add(Me.BtnDesvincular)
        Me.GrpInfo.Controls.Add(Me.TxtCargo)
        Me.GrpInfo.Controls.Add(Me.Label1)
        Me.GrpInfo.Controls.Add(Me.TxtCliente)
        Me.GrpInfo.Controls.Add(Me.Label999)
        Me.GrpInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.GrpInfo.Location = New System.Drawing.Point(0, 0)
        Me.GrpInfo.Margin = New System.Windows.Forms.Padding(4)
        Me.GrpInfo.Name = "GrpInfo"
        Me.GrpInfo.Padding = New System.Windows.Forms.Padding(4)
        Me.GrpInfo.Size = New System.Drawing.Size(564, 180)
        Me.GrpInfo.TabIndex = 0
        Me.GrpInfo.TabStop = False
        Me.GrpInfo.Text = "Cliente e Cargo"
        '
        'BtnDesvincular
        '
        Me.BtnDesvincular.Location = New System.Drawing.Point(434, 115)
        Me.BtnDesvincular.Name = "BtnDesvincular"
        Me.BtnDesvincular.Size = New System.Drawing.Size(116, 32)
        Me.BtnDesvincular.TabIndex = 6
        Me.BtnDesvincular.Text = "Desvincular"
        Me.BtnDesvincular.UseVisualStyleBackColor = True
        '
        'TxtCargo
        '
        Me.TxtCargo.Location = New System.Drawing.Point(16, 115)
        Me.TxtCargo.Name = "TxtCargo"
        Me.TxtCargo.ReadOnly = True
        Me.TxtCargo.Size = New System.Drawing.Size(403, 23)
        Me.TxtCargo.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Cargo"
        '
        'TxtCliente
        '
        Me.TxtCliente.Location = New System.Drawing.Point(16, 53)
        Me.TxtCliente.Name = "TxtCliente"
        Me.TxtCliente.ReadOnly = True
        Me.TxtCliente.Size = New System.Drawing.Size(403, 23)
        Me.TxtCliente.TabIndex = 1
        '
        'Label999
        '
        Me.Label999.AutoSize = True
        Me.Label999.Location = New System.Drawing.Point(13, 34)
        Me.Label999.Name = "Label999"
        Me.Label999.Size = New System.Drawing.Size(53, 16)
        Me.Label999.TabIndex = 0
        Me.Label999.Text = "Cliente"
        '
        'ChkAtivo
        '
        Me.ChkAtivo.AutoSize = True
        Me.ChkAtivo.Enabled = False
        Me.ChkAtivo.Location = New System.Drawing.Point(434, 56)
        Me.ChkAtivo.Name = "ChkAtivo"
        Me.ChkAtivo.Size = New System.Drawing.Size(61, 20)
        Me.ChkAtivo.TabIndex = 7
        Me.ChkAtivo.Text = "Ativo"
        Me.ChkAtivo.UseVisualStyleBackColor = True
        '
        'Frm_Cliente_Cargo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(564, 181)
        Me.Controls.Add(Me.GrpInfo)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_Cliente_Cargo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cliente vinculado ao cargo"
        Me.GrpInfo.ResumeLayout(False)
        Me.GrpInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpInfo As System.Windows.Forms.GroupBox
    Friend WithEvents BtnDesvincular As System.Windows.Forms.Button
    Friend WithEvents TxtCargo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label999 As System.Windows.Forms.Label
    Friend WithEvents ChkAtivo As System.Windows.Forms.CheckBox
End Class
