<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_Toolstrip
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UC_Toolstrip))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnNovo = New System.Windows.Forms.ToolStripButton()
        Me.BtnSalvar = New System.Windows.Forms.ToolStripButton()
        Me.BtnPesquisar = New System.Windows.Forms.ToolStripButton()
        Me.BtnAlterar = New System.Windows.Forms.ToolStripButton()
        Me.BtnExcluir = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnAnterior = New System.Windows.Forms.ToolStripButton()
        Me.BtnSeguinte = New System.Windows.Forms.ToolStripButton()
        Me.BtnReverter = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnInsereImagem = New System.Windows.Forms.ToolStripButton()
        Me.BtnImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnNovo, Me.BtnSalvar, Me.BtnPesquisar, Me.BtnAlterar, Me.BtnExcluir, Me.toolStripSeparator, Me.BtnAnterior, Me.BtnSeguinte, Me.BtnReverter, Me.toolStripSeparator1, Me.BtnInsereImagem, Me.BtnImprimir})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(473, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnNovo
        '
        Me.BtnNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnNovo.Image = CType(resources.GetObject("BtnNovo.Image"), System.Drawing.Image)
        Me.BtnNovo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnNovo.Name = "BtnNovo"
        Me.BtnNovo.Size = New System.Drawing.Size(23, 22)
        Me.BtnNovo.Text = "&Novo cadastro"
        Me.BtnNovo.ToolTipText = "Novo cadastro"
        '
        'BtnSalvar
        '
        Me.BtnSalvar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnSalvar.Image = CType(resources.GetObject("BtnSalvar.Image"), System.Drawing.Image)
        Me.BtnSalvar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSalvar.Name = "BtnSalvar"
        Me.BtnSalvar.Size = New System.Drawing.Size(23, 22)
        Me.BtnSalvar.Text = "&Salvar"
        '
        'BtnPesquisar
        '
        Me.BtnPesquisar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnPesquisar.Image = Global.Beyond.My.Resources.Resources.search
        Me.BtnPesquisar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPesquisar.Name = "BtnPesquisar"
        Me.BtnPesquisar.Size = New System.Drawing.Size(23, 22)
        Me.BtnPesquisar.Text = "&Pesquisar"
        '
        'BtnAlterar
        '
        Me.BtnAlterar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnAlterar.Image = Global.Beyond.My.Resources.Resources.update
        Me.BtnAlterar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnAlterar.Name = "BtnAlterar"
        Me.BtnAlterar.Size = New System.Drawing.Size(23, 22)
        Me.BtnAlterar.Text = "Alterar"
        '
        'BtnExcluir
        '
        Me.BtnExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnExcluir.Image = Global.Beyond.My.Resources.Resources.delete
        Me.BtnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnExcluir.Name = "BtnExcluir"
        Me.BtnExcluir.Size = New System.Drawing.Size(23, 22)
        Me.BtnExcluir.Text = "&Excluir"
        Me.BtnExcluir.ToolTipText = "Excluir"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BtnAnterior
        '
        Me.BtnAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnAnterior.Image = Global.Beyond.My.Resources.Resources.Back
        Me.BtnAnterior.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnAnterior.Name = "BtnAnterior"
        Me.BtnAnterior.Size = New System.Drawing.Size(23, 22)
        Me.BtnAnterior.Text = "Anterior"
        '
        'BtnSeguinte
        '
        Me.BtnSeguinte.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnSeguinte.Image = Global.Beyond.My.Resources.Resources.forward
        Me.BtnSeguinte.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSeguinte.Name = "BtnSeguinte"
        Me.BtnSeguinte.Size = New System.Drawing.Size(23, 22)
        Me.BtnSeguinte.Text = "Seguinte"
        '
        'BtnReverter
        '
        Me.BtnReverter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnReverter.Image = Global.Beyond.My.Resources.Resources.rollback
        Me.BtnReverter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnReverter.Name = "BtnReverter"
        Me.BtnReverter.Size = New System.Drawing.Size(23, 22)
        Me.BtnReverter.Text = "&Reverter"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BtnInsereImagem
        '
        Me.BtnInsereImagem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnInsereImagem.Enabled = False
        Me.BtnInsereImagem.Image = Global.Beyond.My.Resources.Resources.InsertPicture1
        Me.BtnInsereImagem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnInsereImagem.Name = "BtnInsereImagem"
        Me.BtnInsereImagem.Size = New System.Drawing.Size(23, 22)
        Me.BtnInsereImagem.Text = "Inserir Imagem"
        '
        'BtnImprimir
        '
        Me.BtnImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnImprimir.Enabled = False
        Me.BtnImprimir.Image = CType(resources.GetObject("BtnImprimir.Image"), System.Drawing.Image)
        Me.BtnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(23, 22)
        Me.BtnImprimir.Text = "Imprimir"
        '
        'UC_Toolstrip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "UC_Toolstrip"
        Me.Size = New System.Drawing.Size(473, 24)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnNovo As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnPesquisar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnSalvar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnExcluir As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnReverter As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnSeguinte As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnAnterior As System.Windows.Forms.ToolStripButton
    Public WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnAlterar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnInsereImagem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnImprimir As System.Windows.Forms.ToolStripButton

End Class
