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
        Me.BtnProcurar = New System.Windows.Forms.ToolStripButton()
        Me.BtnDeletar = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BtnVoltar = New System.Windows.Forms.ToolStripButton()
        Me.BtnProximo = New System.Windows.Forms.ToolStripButton()
        Me.BtnConfirmar = New System.Windows.Forms.ToolStripButton()
        Me.BtnRollback = New System.Windows.Forms.ToolStripButton()
        Me.PasteToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.HelpToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.BtnLimpar = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnNovo, Me.BtnSalvar, Me.BtnProcurar, Me.BtnDeletar, Me.toolStripSeparator, Me.BtnVoltar, Me.BtnProximo, Me.BtnConfirmar, Me.BtnRollback, Me.PasteToolStripButton, Me.toolStripSeparator1, Me.HelpToolStripButton, Me.BtnLimpar})
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
        'BtnProcurar
        '
        Me.BtnProcurar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnProcurar.Image = Global.Beyond.My.Resources.Resources.search
        Me.BtnProcurar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnProcurar.Name = "BtnProcurar"
        Me.BtnProcurar.Size = New System.Drawing.Size(23, 22)
        Me.BtnProcurar.Text = "&Procurar"
        '
        'BtnDeletar
        '
        Me.BtnDeletar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnDeletar.Image = Global.Beyond.My.Resources.Resources.delete
        Me.BtnDeletar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnDeletar.Name = "BtnDeletar"
        Me.BtnDeletar.Size = New System.Drawing.Size(23, 22)
        Me.BtnDeletar.Text = "&Deletar"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BtnVoltar
        '
        Me.BtnVoltar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnVoltar.Image = Global.Beyond.My.Resources.Resources.Back
        Me.BtnVoltar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnVoltar.Name = "BtnVoltar"
        Me.BtnVoltar.Size = New System.Drawing.Size(23, 22)
        Me.BtnVoltar.Text = "Anterior"
        '
        'BtnProximo
        '
        Me.BtnProximo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnProximo.Image = Global.Beyond.My.Resources.Resources.forward
        Me.BtnProximo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnProximo.Name = "BtnProximo"
        Me.BtnProximo.Size = New System.Drawing.Size(23, 22)
        Me.BtnProximo.Text = "Seguinte"
        '
        'BtnConfirmar
        '
        Me.BtnConfirmar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnConfirmar.Image = Global.Beyond.My.Resources.Resources.confirm
        Me.BtnConfirmar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnConfirmar.Name = "BtnConfirmar"
        Me.BtnConfirmar.Size = New System.Drawing.Size(23, 22)
        Me.BtnConfirmar.Text = "&Confirmar"
        '
        'BtnRollback
        '
        Me.BtnRollback.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BtnRollback.Image = Global.Beyond.My.Resources.Resources.rollback
        Me.BtnRollback.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnRollback.Name = "BtnRollback"
        Me.BtnRollback.Size = New System.Drawing.Size(23, 22)
        Me.BtnRollback.Text = "&Reverter"
        '
        'PasteToolStripButton
        '
        Me.PasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PasteToolStripButton.Image = CType(resources.GetObject("PasteToolStripButton.Image"), System.Drawing.Image)
        Me.PasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PasteToolStripButton.Name = "PasteToolStripButton"
        Me.PasteToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PasteToolStripButton.Text = "&Paste"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'HelpToolStripButton
        '
        Me.HelpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.HelpToolStripButton.Image = CType(resources.GetObject("HelpToolStripButton.Image"), System.Drawing.Image)
        Me.HelpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.HelpToolStripButton.Name = "HelpToolStripButton"
        Me.HelpToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.HelpToolStripButton.Text = "He&lp"
        '
        'BtnLimpar
        '
        Me.BtnLimpar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.BtnLimpar.Name = "BtnLimpar"
        Me.BtnLimpar.Size = New System.Drawing.Size(100, 25)
        Me.BtnLimpar.Text = "Limpar Campos"
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
    Friend WithEvents BtnProcurar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnSalvar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnDeletar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BtnConfirmar As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnRollback As System.Windows.Forms.ToolStripButton
    Friend WithEvents PasteToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnProximo As System.Windows.Forms.ToolStripButton
    Friend WithEvents BtnVoltar As System.Windows.Forms.ToolStripButton
    Public WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BtnLimpar As System.Windows.Forms.ToolStripTextBox

End Class
