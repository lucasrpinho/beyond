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
        Me.ColNome = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColPreco = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColQtd = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ComboCateg = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboNome = New System.Windows.Forms.ComboBox()
        Me.ChkCateg = New System.Windows.Forms.CheckBox()
        Me.ChkDesc = New System.Windows.Forms.CheckBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.BtnConfirmar = New System.Windows.Forms.Button()
        Me.ColAtivo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColCategoria = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColCategoria, Me.ColNome, Me.ColPreco, Me.ColQtd, Me.ColAtivo})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.HotTracking = True
        Me.ListView1.HoverSelection = True
        Me.ListView1.Location = New System.Drawing.Point(18, 130)
        Me.ListView1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ListView1.MultiSelect = False
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(860, 202)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColNome
        '
        Me.ColNome.Text = "Nome do Produto"
        Me.ColNome.Width = 459
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
        Me.ColQtd.Width = 132
        '
        'ComboCateg
        '
        Me.ComboCateg.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboCateg.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboCateg.Enabled = False
        Me.ComboCateg.FormattingEnabled = True
        Me.ComboCateg.Location = New System.Drawing.Point(18, 38)
        Me.ComboCateg.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboCateg.MaxLength = 60
        Me.ComboCateg.Name = "ComboCateg"
        Me.ComboCateg.Size = New System.Drawing.Size(839, 22)
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
        Me.Label2.Size = New System.Drawing.Size(117, 14)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Nome do Produto"
        '
        'ComboNome
        '
        Me.ComboNome.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboNome.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboNome.Enabled = False
        Me.ComboNome.FormattingEnabled = True
        Me.ComboNome.Location = New System.Drawing.Point(18, 89)
        Me.ComboNome.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboNome.MaxLength = 60
        Me.ComboNome.Name = "ComboNome"
        Me.ComboNome.Size = New System.Drawing.Size(839, 22)
        Me.ComboNome.TabIndex = 5
        '
        'ChkCateg
        '
        Me.ChkCateg.AutoSize = True
        Me.ChkCateg.Location = New System.Drawing.Point(863, 42)
        Me.ChkCateg.Name = "ChkCateg"
        Me.ChkCateg.Size = New System.Drawing.Size(15, 14)
        Me.ChkCateg.TabIndex = 7
        Me.ChkCateg.UseVisualStyleBackColor = True
        '
        'ChkDesc
        '
        Me.ChkDesc.AutoSize = True
        Me.ChkDesc.Location = New System.Drawing.Point(863, 93)
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
        'BtnConfirmar
        '
        Me.BtnConfirmar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConfirmar.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window
        Me.BtnConfirmar.Image = Global.Beyond.My.Resources.Resources.confirm
        Me.BtnConfirmar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnConfirmar.Location = New System.Drawing.Point(779, 337)
        Me.BtnConfirmar.Name = "BtnConfirmar"
        Me.BtnConfirmar.Size = New System.Drawing.Size(99, 32)
        Me.BtnConfirmar.TabIndex = 45
        Me.BtnConfirmar.Text = "Confirmar"
        Me.BtnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConfirmar.UseVisualStyleBackColor = True
        '
        'ColAtivo
        '
        Me.ColAtivo.Text = "Ativo"
        Me.ColAtivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColAtivo.Width = 124
        '
        'ColCategoria
        '
        Me.ColCategoria.Text = "Categoria"
        Me.ColCategoria.Width = 160
        '
        'Frm_ConsProduto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Menu
        Me.ClientSize = New System.Drawing.Size(894, 373)
        Me.Controls.Add(Me.BtnConfirmar)
        Me.Controls.Add(Me.ChkDesc)
        Me.Controls.Add(Me.ChkCateg)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboNome)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboCateg)
        Me.Controls.Add(Me.ListView1)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ConsProduto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Consultar Produtos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ComboCateg As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ColNome As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColPreco As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColQtd As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboNome As System.Windows.Forms.ComboBox
    Friend WithEvents ChkCateg As System.Windows.Forms.CheckBox
    Friend WithEvents ChkDesc As System.Windows.Forms.CheckBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents BtnConfirmar As System.Windows.Forms.Button
    Friend WithEvents ColAtivo As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColCategoria As System.Windows.Forms.ColumnHeader
End Class
