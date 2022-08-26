<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Principal_MDI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Principal_MDI))
        Me.MnStrip_Principal = New System.Windows.Forms.MenuStrip()
        Me.AçõesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FecharAbaSelecionadaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FecharSelecionadaMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.FecharTodasMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.SairToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsuáriosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsuarioMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CargosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VendedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CadastrarToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlterarToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CadastrarToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlterarToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProdutosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CadastrarToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlterarToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PedidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IncluirVendaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RelatórioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PedidoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.VendedorToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProdutosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AjudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SobreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarAtualizaçãoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.TSL_Login = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSL_Data = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSL_Hora = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TimerClock = New System.Windows.Forms.Timer(Me.components)
        Me.SplitC1 = New System.Windows.Forms.SplitContainer()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LblOla = New System.Windows.Forms.Label()
        Me.TCPrincipal = New System.Windows.Forms.TabControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.FecharUmaCtxMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.FecharTodasCtxMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.UC_Toolstrip1 = New Beyond.UC_Toolstrip()
        Me.MnStrip_Principal.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitC1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitC1.Panel1.SuspendLayout()
        Me.SplitC1.Panel2.SuspendLayout()
        Me.SplitC1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MnStrip_Principal
        '
        Me.MnStrip_Principal.BackColor = System.Drawing.Color.LightGray
        Me.MnStrip_Principal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AçõesToolStripMenuItem, Me.UsuáriosToolStripMenuItem, Me.PedidoToolStripMenuItem, Me.ConsultasToolStripMenuItem, Me.RelatórioToolStripMenuItem, Me.AjudaToolStripMenuItem})
        Me.MnStrip_Principal.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MnStrip_Principal.Location = New System.Drawing.Point(0, 0)
        Me.MnStrip_Principal.Name = "MnStrip_Principal"
        Me.MnStrip_Principal.Padding = New System.Windows.Forms.Padding(5, 2, 0, 0)
        Me.MnStrip_Principal.Size = New System.Drawing.Size(755, 24)
        Me.MnStrip_Principal.TabIndex = 1
        Me.MnStrip_Principal.Text = "Menu"
        '
        'AçõesToolStripMenuItem
        '
        Me.AçõesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FecharAbaSelecionadaToolStripMenuItem, Me.SairToolStripMenuItem})
        Me.AçõesToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Silver
        Me.AçõesToolStripMenuItem.Name = "AçõesToolStripMenuItem"
        Me.AçõesToolStripMenuItem.Size = New System.Drawing.Size(46, 22)
        Me.AçõesToolStripMenuItem.Text = "Ação"
        '
        'FecharAbaSelecionadaToolStripMenuItem
        '
        Me.FecharAbaSelecionadaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FecharSelecionadaMenu, Me.FecharTodasMenu})
        Me.FecharAbaSelecionadaToolStripMenuItem.Name = "FecharAbaSelecionadaToolStripMenuItem"
        Me.FecharAbaSelecionadaToolStripMenuItem.Size = New System.Drawing.Size(95, 22)
        Me.FecharAbaSelecionadaToolStripMenuItem.Text = "Aba"
        '
        'FecharSelecionadaMenu
        '
        Me.FecharSelecionadaMenu.Name = "FecharSelecionadaMenu"
        Me.FecharSelecionadaMenu.Size = New System.Drawing.Size(174, 22)
        Me.FecharSelecionadaMenu.Text = "Fechar selecionada"
        '
        'FecharTodasMenu
        '
        Me.FecharTodasMenu.Name = "FecharTodasMenu"
        Me.FecharTodasMenu.Size = New System.Drawing.Size(174, 22)
        Me.FecharTodasMenu.Text = "Fechar todas"
        '
        'SairToolStripMenuItem
        '
        Me.SairToolStripMenuItem.Name = "SairToolStripMenuItem"
        Me.SairToolStripMenuItem.Size = New System.Drawing.Size(95, 22)
        Me.SairToolStripMenuItem.Text = "Sair"
        '
        'UsuáriosToolStripMenuItem
        '
        Me.UsuáriosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UsuarioMenuItem, Me.CargosToolStripMenuItem, Me.VendedorToolStripMenuItem, Me.ClientesToolStripMenuItem, Me.ProdutosToolStripMenuItem})
        Me.UsuáriosToolStripMenuItem.Name = "UsuáriosToolStripMenuItem"
        Me.UsuáriosToolStripMenuItem.Size = New System.Drawing.Size(48, 22)
        Me.UsuáriosToolStripMenuItem.Text = "Exibir"
        '
        'UsuarioMenuItem
        '
        Me.UsuarioMenuItem.Name = "UsuarioMenuItem"
        Me.UsuarioMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.UsuarioMenuItem.Text = "Usuário"
        '
        'CargosToolStripMenuItem
        '
        Me.CargosToolStripMenuItem.Name = "CargosToolStripMenuItem"
        Me.CargosToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.CargosToolStripMenuItem.Text = "Cargo"
        '
        'VendedorToolStripMenuItem
        '
        Me.VendedorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CadastrarToolStripMenuItem2, Me.AlterarToolStripMenuItem3})
        Me.VendedorToolStripMenuItem.Name = "VendedorToolStripMenuItem"
        Me.VendedorToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.VendedorToolStripMenuItem.Text = "Vendedor"
        '
        'CadastrarToolStripMenuItem2
        '
        Me.CadastrarToolStripMenuItem2.Name = "CadastrarToolStripMenuItem2"
        Me.CadastrarToolStripMenuItem2.Size = New System.Drawing.Size(124, 22)
        Me.CadastrarToolStripMenuItem2.Text = "Cadastrar"
        '
        'AlterarToolStripMenuItem3
        '
        Me.AlterarToolStripMenuItem3.Name = "AlterarToolStripMenuItem3"
        Me.AlterarToolStripMenuItem3.Size = New System.Drawing.Size(124, 22)
        Me.AlterarToolStripMenuItem3.Text = "Alterar"
        '
        'ClientesToolStripMenuItem
        '
        Me.ClientesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CadastrarToolStripMenuItem3, Me.AlterarToolStripMenuItem4})
        Me.ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem"
        Me.ClientesToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.ClientesToolStripMenuItem.Text = "Cliente"
        '
        'CadastrarToolStripMenuItem3
        '
        Me.CadastrarToolStripMenuItem3.Name = "CadastrarToolStripMenuItem3"
        Me.CadastrarToolStripMenuItem3.Size = New System.Drawing.Size(124, 22)
        Me.CadastrarToolStripMenuItem3.Text = "Cadastrar"
        '
        'AlterarToolStripMenuItem4
        '
        Me.AlterarToolStripMenuItem4.Name = "AlterarToolStripMenuItem4"
        Me.AlterarToolStripMenuItem4.Size = New System.Drawing.Size(124, 22)
        Me.AlterarToolStripMenuItem4.Text = "Alterar"
        '
        'ProdutosToolStripMenuItem
        '
        Me.ProdutosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CadastrarToolStripMenuItem4, Me.AlterarToolStripMenuItem5})
        Me.ProdutosToolStripMenuItem.Name = "ProdutosToolStripMenuItem"
        Me.ProdutosToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.ProdutosToolStripMenuItem.Text = "Produto"
        '
        'CadastrarToolStripMenuItem4
        '
        Me.CadastrarToolStripMenuItem4.Name = "CadastrarToolStripMenuItem4"
        Me.CadastrarToolStripMenuItem4.Size = New System.Drawing.Size(124, 22)
        Me.CadastrarToolStripMenuItem4.Text = "Cadastrar"
        '
        'AlterarToolStripMenuItem5
        '
        Me.AlterarToolStripMenuItem5.Name = "AlterarToolStripMenuItem5"
        Me.AlterarToolStripMenuItem5.Size = New System.Drawing.Size(124, 22)
        Me.AlterarToolStripMenuItem5.Text = "Alterar"
        '
        'PedidoToolStripMenuItem
        '
        Me.PedidoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IncluirVendaToolStripMenuItem})
        Me.PedidoToolStripMenuItem.Name = "PedidoToolStripMenuItem"
        Me.PedidoToolStripMenuItem.Size = New System.Drawing.Size(56, 22)
        Me.PedidoToolStripMenuItem.Text = "Pedido"
        '
        'IncluirVendaToolStripMenuItem
        '
        Me.IncluirVendaToolStripMenuItem.Name = "IncluirVendaToolStripMenuItem"
        Me.IncluirVendaToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.IncluirVendaToolStripMenuItem.Text = "Incluir Venda"
        '
        'ConsultasToolStripMenuItem
        '
        Me.ConsultasToolStripMenuItem.Name = "ConsultasToolStripMenuItem"
        Me.ConsultasToolStripMenuItem.Size = New System.Drawing.Size(71, 22)
        Me.ConsultasToolStripMenuItem.Text = "Consultas"
        '
        'RelatórioToolStripMenuItem
        '
        Me.RelatórioToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PedidoToolStripMenuItem1, Me.VendedorToolStripMenuItem1, Me.ProdutosToolStripMenuItem1})
        Me.RelatórioToolStripMenuItem.Name = "RelatórioToolStripMenuItem"
        Me.RelatórioToolStripMenuItem.Size = New System.Drawing.Size(66, 22)
        Me.RelatórioToolStripMenuItem.Text = "Relatório"
        '
        'PedidoToolStripMenuItem1
        '
        Me.PedidoToolStripMenuItem1.Name = "PedidoToolStripMenuItem1"
        Me.PedidoToolStripMenuItem1.Size = New System.Drawing.Size(135, 22)
        Me.PedidoToolStripMenuItem1.Text = "Pedidos"
        '
        'VendedorToolStripMenuItem1
        '
        Me.VendedorToolStripMenuItem1.Name = "VendedorToolStripMenuItem1"
        Me.VendedorToolStripMenuItem1.Size = New System.Drawing.Size(135, 22)
        Me.VendedorToolStripMenuItem1.Text = "Vendedores"
        '
        'ProdutosToolStripMenuItem1
        '
        Me.ProdutosToolStripMenuItem1.Name = "ProdutosToolStripMenuItem1"
        Me.ProdutosToolStripMenuItem1.Size = New System.Drawing.Size(135, 22)
        Me.ProdutosToolStripMenuItem1.Text = "Produtos"
        '
        'AjudaToolStripMenuItem
        '
        Me.AjudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SobreToolStripMenuItem, Me.BuscarAtualizaçãoToolStripMenuItem})
        Me.AjudaToolStripMenuItem.Name = "AjudaToolStripMenuItem"
        Me.AjudaToolStripMenuItem.Size = New System.Drawing.Size(50, 22)
        Me.AjudaToolStripMenuItem.Text = "Ajuda"
        '
        'SobreToolStripMenuItem
        '
        Me.SobreToolStripMenuItem.Name = "SobreToolStripMenuItem"
        Me.SobreToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.SobreToolStripMenuItem.Text = "Sobre"
        '
        'BuscarAtualizaçãoToolStripMenuItem
        '
        Me.BuscarAtualizaçãoToolStripMenuItem.Name = "BuscarAtualizaçãoToolStripMenuItem"
        Me.BuscarAtualizaçãoToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.BuscarAtualizaçãoToolStripMenuItem.Text = "Buscar Atualização"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSL_Login, Me.TSL_Data, Me.TSL_Hora})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 449)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(755, 22)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'TSL_Login
        '
        Me.TSL_Login.BackColor = System.Drawing.Color.Transparent
        Me.TSL_Login.Name = "TSL_Login"
        Me.TSL_Login.Padding = New System.Windows.Forms.Padding(20, 0, 20, 0)
        Me.TSL_Login.Size = New System.Drawing.Size(40, 17)
        '
        'TSL_Data
        '
        Me.TSL_Data.BackColor = System.Drawing.Color.Transparent
        Me.TSL_Data.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TSL_Data.Name = "TSL_Data"
        Me.TSL_Data.Padding = New System.Windows.Forms.Padding(20, 0, 20, 0)
        Me.TSL_Data.Size = New System.Drawing.Size(40, 17)
        '
        'TSL_Hora
        '
        Me.TSL_Hora.BackColor = System.Drawing.Color.Transparent
        Me.TSL_Hora.Name = "TSL_Hora"
        Me.TSL_Hora.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.TSL_Hora.Size = New System.Drawing.Size(20, 17)
        '
        'TimerClock
        '
        Me.TimerClock.Enabled = True
        Me.TimerClock.Interval = 1000
        '
        'SplitC1
        '
        Me.SplitC1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitC1.BackColor = System.Drawing.Color.Transparent
        Me.SplitC1.IsSplitterFixed = True
        Me.SplitC1.Location = New System.Drawing.Point(0, 45)
        Me.SplitC1.Margin = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.SplitC1.Name = "SplitC1"
        '
        'SplitC1.Panel1
        '
        Me.SplitC1.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitC1.Panel1.Controls.Add(Me.PictureBox1)
        Me.SplitC1.Panel1.Controls.Add(Me.LblOla)
        '
        'SplitC1.Panel2
        '
        Me.SplitC1.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SplitC1.Panel2.Controls.Add(Me.TCPrincipal)
        Me.SplitC1.Size = New System.Drawing.Size(755, 404)
        Me.SplitC1.SplitterDistance = 200
        Me.SplitC1.SplitterWidth = 2
        Me.SplitC1.TabIndex = 10
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox1.Image = Global.Beyond.My.Resources.Resources.BeyondICON
        Me.PictureBox1.Location = New System.Drawing.Point(14, 151)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(163, 149)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'LblOla
        '
        Me.LblOla.AutoEllipsis = True
        Me.LblOla.AutoSize = True
        Me.LblOla.Font = New System.Drawing.Font("Verdana", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOla.ForeColor = System.Drawing.Color.White
        Me.LblOla.Location = New System.Drawing.Point(12, 32)
        Me.LblOla.Name = "LblOla"
        Me.LblOla.Size = New System.Drawing.Size(95, 26)
        Me.LblOla.TabIndex = 1
        Me.LblOla.Text = "Label1"
        '
        'TCPrincipal
        '
        Me.TCPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TCPrincipal.ItemSize = New System.Drawing.Size(30, 30)
        Me.TCPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.TCPrincipal.Name = "TCPrincipal"
        Me.TCPrincipal.SelectedIndex = 0
        Me.TCPrincipal.Size = New System.Drawing.Size(553, 404)
        Me.TCPrincipal.TabIndex = 2
        Me.TCPrincipal.Visible = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FecharUmaCtxMenu, Me.FecharTodasCtxMenu})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(176, 48)
        '
        'FecharUmaCtxMenu
        '
        Me.FecharUmaCtxMenu.Name = "FecharUmaCtxMenu"
        Me.FecharUmaCtxMenu.Size = New System.Drawing.Size(175, 22)
        Me.FecharUmaCtxMenu.Text = "Fechar Selecionada"
        '
        'FecharTodasCtxMenu
        '
        Me.FecharTodasCtxMenu.Name = "FecharTodasCtxMenu"
        Me.FecharTodasCtxMenu.Size = New System.Drawing.Size(175, 22)
        Me.FecharTodasCtxMenu.Text = "Fechar Todas"
        '
        'UC_Toolstrip1
        '
        Me.UC_Toolstrip1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UC_Toolstrip1.Location = New System.Drawing.Point(0, 24)
        Me.UC_Toolstrip1.Margin = New System.Windows.Forms.Padding(4)
        Me.UC_Toolstrip1.Name = "UC_Toolstrip1"
        Me.UC_Toolstrip1.Size = New System.Drawing.Size(755, 24)
        Me.UC_Toolstrip1.TabIndex = 14
        '
        'Frm_Principal_MDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(755, 471)
        Me.Controls.Add(Me.UC_Toolstrip1)
        Me.Controls.Add(Me.SplitC1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MnStrip_Principal)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MnStrip_Principal
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Frm_Principal_MDI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Beyond"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MnStrip_Principal.ResumeLayout(False)
        Me.MnStrip_Principal.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitC1.Panel1.ResumeLayout(False)
        Me.SplitC1.Panel1.PerformLayout()
        Me.SplitC1.Panel2.ResumeLayout(False)
        CType(Me.SplitC1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitC1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MnStrip_Principal As System.Windows.Forms.MenuStrip
    Friend WithEvents AçõesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SairToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsuáriosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsuarioMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CargosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VendedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CadastrarToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlterarToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClientesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CadastrarToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlterarToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProdutosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CadastrarToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlterarToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PedidoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IncluirVendaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RelatórioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AjudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SobreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarAtualizaçãoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents TSL_Login As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSL_Data As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSL_Hora As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TimerClock As System.Windows.Forms.Timer
    Friend WithEvents FecharAbaSelecionadaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FecharSelecionadaMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FecharTodasMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitC1 As System.Windows.Forms.SplitContainer
    Friend WithEvents LblOla As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents FecharUmaCtxMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FecharTodasCtxMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PedidoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VendedorToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProdutosToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TCPrincipal As System.Windows.Forms.TabControl
    Public WithEvents UC_Toolstrip1 As Beyond.UC_Toolstrip
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
