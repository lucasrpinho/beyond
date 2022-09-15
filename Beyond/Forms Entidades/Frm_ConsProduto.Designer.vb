<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ConsProduto
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_ConsProduto))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColDesc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColPreco = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColQtd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ComboCateg = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboDesc = New System.Windows.Forms.ComboBox()
        Me.ChkCateg = New System.Windows.Forms.CheckBox()
        Me.ChkDesc = New System.Windows.Forms.CheckBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.BtnPesquisar = New System.Windows.Forms.Button()
        Me.BtnConfirmar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColDesc, Me.ColPreco, Me.ColQtd})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HotTracking = True
        Me.ListView1.HoverSelection = True
        Me.ListView1.Location = New System.Drawing.Point(18, 130)
        Me.ListView1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(700, 202)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColDesc
        '
        Me.ColDesc.Text = "Descrição"
        Me.ColDesc.Width = 459
        '
        'ColPreco
        '
        Me.ColPreco.Text = "Preço"
        Me.ColPreco.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColPreco.Width = 140
        '
        'ColQtd
        '
        Me.ColQtd.Text = "Quantidade"
        Me.ColQtd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColQtd.Width = 96
        '
        'ComboCateg
        '
        Me.ComboCateg.Enabled = False
        Me.ComboCateg.FormattingEnabled = True
        Me.ComboCateg.Location = New System.Drawing.Point(18, 38)
        Me.ComboCateg.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboCateg.Name = "ComboCateg"
        Me.ComboCateg.Size = New System.Drawing.Size(491, 22)
        Me.ComboCateg.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Categoria"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(141, 14)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Descrição do Produto"
        '
        'ComboDesc
        '
        Me.ComboDesc.Enabled = False
        Me.ComboDesc.FormattingEnabled = True
        Me.ComboDesc.Location = New System.Drawing.Point(18, 89)
        Me.ComboDesc.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboDesc.Name = "ComboDesc"
        Me.ComboDesc.Size = New System.Drawing.Size(491, 22)
        Me.ComboDesc.TabIndex = 5
        '
        'ChkCateg
        '
        Me.ChkCateg.AutoSize = True
        Me.ChkCateg.Location = New System.Drawing.Point(515, 42)
        Me.ChkCateg.Name = "ChkCateg"
        Me.ChkCateg.Size = New System.Drawing.Size(15, 14)
        Me.ChkCateg.TabIndex = 7
        Me.ChkCateg.UseVisualStyleBackColor = True
        '
        'ChkDesc
        '
        Me.ChkDesc.AutoSize = True
        Me.ChkDesc.Location = New System.Drawing.Point(515, 97)
        Me.ChkDesc.Name = "ChkDesc"
        Me.ChkDesc.Size = New System.Drawing.Size(15, 14)
        Me.ChkDesc.TabIndex = 8
        Me.ChkDesc.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "search.png")
        Me.ImageList1.Images.SetKeyName(1, "confirm.png")
        '
        'BtnPesquisar
        '
        Me.BtnPesquisar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnPesquisar.FlatAppearance.BorderSize = 0
        Me.BtnPesquisar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.BtnPesquisar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPesquisar.ImageKey = "search.png"
        Me.BtnPesquisar.ImageList = Me.ImageList1
        Me.BtnPesquisar.Location = New System.Drawing.Point(684, 101)
        Me.BtnPesquisar.Name = "BtnPesquisar"
        Me.BtnPesquisar.Size = New System.Drawing.Size(34, 24)
        Me.BtnPesquisar.TabIndex = 28
        Me.BtnPesquisar.UseVisualStyleBackColor = True
        '
        'BtnConfirmar
        '
        Me.BtnConfirmar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConfirmar.FlatAppearance.BorderSize = 0
        Me.BtnConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
        Me.BtnConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnConfirmar.ImageKey = "confirm.png"
        Me.BtnConfirmar.ImageList = Me.ImageList1
        Me.BtnConfirmar.Location = New System.Drawing.Point(684, 337)
        Me.BtnConfirmar.Name = "BtnConfirmar"
        Me.BtnConfirmar.Size = New System.Drawing.Size(34, 24)
        Me.BtnConfirmar.TabIndex = 29
        Me.BtnConfirmar.UseVisualStyleBackColor = True
        '
        'Frm_ConsProduto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(730, 373)
        Me.Controls.Add(Me.BtnConfirmar)
        Me.Controls.Add(Me.BtnPesquisar)
        Me.Controls.Add(Me.ChkDesc)
        Me.Controls.Add(Me.ChkCateg)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboDesc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboCateg)
        Me.Controls.Add(Me.ListView1)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ConsProduto"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Consultar Produtos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ComboCateg As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ColDesc As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColPreco As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColQtd As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboDesc As System.Windows.Forms.ComboBox
    Friend WithEvents ChkCateg As System.Windows.Forms.CheckBox
    Friend WithEvents ChkDesc As System.Windows.Forms.CheckBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents BtnPesquisar As System.Windows.Forms.Button
    Friend WithEvents BtnConfirmar As System.Windows.Forms.Button
End Class
