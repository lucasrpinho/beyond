﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.FecharSelecionadaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FecharTodasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SairToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UsuáriosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlterarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CadastrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlterarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CargosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CadastrarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlterarToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.VendedorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CadastrarToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlterarToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CadastrarToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlterarToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProdutosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CadastrarToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlterarToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PedidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IncluirVendaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarPedidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RelatórioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AjudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SobreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarAtualizaçãoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.TSL_Login = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSL_Data = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSL_Hora = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TimerClock = New System.Windows.Forms.Timer(Me.components)
        Me.SplitC1 = New System.Windows.Forms.SplitContainer()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TCPrincipal = New System.Windows.Forms.TabControl()
        Me.LblOla = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuFecharUma = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuFecharTodas = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnStrip_Principal.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.SplitC1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitC1.Panel1.SuspendLayout()
        Me.SplitC1.Panel2.SuspendLayout()
        Me.SplitC1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MnStrip_Principal
        '
        Me.MnStrip_Principal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AçõesToolStripMenuItem, Me.UsuáriosToolStripMenuItem, Me.PedidoToolStripMenuItem, Me.RelatórioToolStripMenuItem, Me.AjudaToolStripMenuItem})
        Me.MnStrip_Principal.Location = New System.Drawing.Point(0, 0)
        Me.MnStrip_Principal.Name = "MnStrip_Principal"
        Me.MnStrip_Principal.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MnStrip_Principal.Size = New System.Drawing.Size(755, 24)
        Me.MnStrip_Principal.TabIndex = 1
        Me.MnStrip_Principal.Text = "Menu"
        '
        'AçõesToolStripMenuItem
        '
        Me.AçõesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FecharAbaSelecionadaToolStripMenuItem, Me.SairToolStripMenuItem})
        Me.AçõesToolStripMenuItem.Name = "AçõesToolStripMenuItem"
        Me.AçõesToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.AçõesToolStripMenuItem.Text = "Ação"
        '
        'FecharAbaSelecionadaToolStripMenuItem
        '
        Me.FecharAbaSelecionadaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FecharSelecionadaToolStripMenuItem, Me.FecharTodasToolStripMenuItem})
        Me.FecharAbaSelecionadaToolStripMenuItem.Name = "FecharAbaSelecionadaToolStripMenuItem"
        Me.FecharAbaSelecionadaToolStripMenuItem.Size = New System.Drawing.Size(95, 22)
        Me.FecharAbaSelecionadaToolStripMenuItem.Text = "Aba"
        '
        'FecharSelecionadaToolStripMenuItem
        '
        Me.FecharSelecionadaToolStripMenuItem.Name = "FecharSelecionadaToolStripMenuItem"
        Me.FecharSelecionadaToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.FecharSelecionadaToolStripMenuItem.Text = "Fechar selecionada"
        '
        'FecharTodasToolStripMenuItem
        '
        Me.FecharTodasToolStripMenuItem.Name = "FecharTodasToolStripMenuItem"
        Me.FecharTodasToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.FecharTodasToolStripMenuItem.Text = "Fechar todas"
        '
        'SairToolStripMenuItem
        '
        Me.SairToolStripMenuItem.Name = "SairToolStripMenuItem"
        Me.SairToolStripMenuItem.Size = New System.Drawing.Size(95, 22)
        Me.SairToolStripMenuItem.Text = "Sair"
        '
        'UsuáriosToolStripMenuItem
        '
        Me.UsuáriosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AlterarToolStripMenuItem, Me.CargosToolStripMenuItem, Me.VendedorToolStripMenuItem, Me.ClientesToolStripMenuItem, Me.ProdutosToolStripMenuItem})
        Me.UsuáriosToolStripMenuItem.Name = "UsuáriosToolStripMenuItem"
        Me.UsuáriosToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.UsuáriosToolStripMenuItem.Text = "Exibir"
        '
        'AlterarToolStripMenuItem
        '
        Me.AlterarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CadastrarToolStripMenuItem, Me.AlterarToolStripMenuItem1, Me.ConsultarToolStripMenuItem})
        Me.AlterarToolStripMenuItem.Name = "AlterarToolStripMenuItem"
        Me.AlterarToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.AlterarToolStripMenuItem.Text = "Usuário"
        '
        'CadastrarToolStripMenuItem
        '
        Me.CadastrarToolStripMenuItem.Name = "CadastrarToolStripMenuItem"
        Me.CadastrarToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.CadastrarToolStripMenuItem.Text = "Cadastrar"
        '
        'AlterarToolStripMenuItem1
        '
        Me.AlterarToolStripMenuItem1.Name = "AlterarToolStripMenuItem1"
        Me.AlterarToolStripMenuItem1.Size = New System.Drawing.Size(125, 22)
        Me.AlterarToolStripMenuItem1.Text = "Alterar"
        '
        'ConsultarToolStripMenuItem
        '
        Me.ConsultarToolStripMenuItem.Name = "ConsultarToolStripMenuItem"
        Me.ConsultarToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.ConsultarToolStripMenuItem.Text = "Consultar"
        '
        'CargosToolStripMenuItem
        '
        Me.CargosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CadastrarToolStripMenuItem1, Me.AlterarToolStripMenuItem2, Me.ConsultarToolStripMenuItem1})
        Me.CargosToolStripMenuItem.Name = "CargosToolStripMenuItem"
        Me.CargosToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.CargosToolStripMenuItem.Text = "Cargo"
        '
        'CadastrarToolStripMenuItem1
        '
        Me.CadastrarToolStripMenuItem1.Name = "CadastrarToolStripMenuItem1"
        Me.CadastrarToolStripMenuItem1.Size = New System.Drawing.Size(125, 22)
        Me.CadastrarToolStripMenuItem1.Text = "Cadastrar"
        '
        'AlterarToolStripMenuItem2
        '
        Me.AlterarToolStripMenuItem2.Name = "AlterarToolStripMenuItem2"
        Me.AlterarToolStripMenuItem2.Size = New System.Drawing.Size(125, 22)
        Me.AlterarToolStripMenuItem2.Text = "Alterar"
        '
        'ConsultarToolStripMenuItem1
        '
        Me.ConsultarToolStripMenuItem1.Name = "ConsultarToolStripMenuItem1"
        Me.ConsultarToolStripMenuItem1.Size = New System.Drawing.Size(125, 22)
        Me.ConsultarToolStripMenuItem1.Text = "Consultar"
        '
        'VendedorToolStripMenuItem
        '
        Me.VendedorToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CadastrarToolStripMenuItem2, Me.AlterarToolStripMenuItem3, Me.ConsultarToolStripMenuItem2})
        Me.VendedorToolStripMenuItem.Name = "VendedorToolStripMenuItem"
        Me.VendedorToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.VendedorToolStripMenuItem.Text = "Vendedor"
        '
        'CadastrarToolStripMenuItem2
        '
        Me.CadastrarToolStripMenuItem2.Name = "CadastrarToolStripMenuItem2"
        Me.CadastrarToolStripMenuItem2.Size = New System.Drawing.Size(125, 22)
        Me.CadastrarToolStripMenuItem2.Text = "Cadastrar"
        '
        'AlterarToolStripMenuItem3
        '
        Me.AlterarToolStripMenuItem3.Name = "AlterarToolStripMenuItem3"
        Me.AlterarToolStripMenuItem3.Size = New System.Drawing.Size(125, 22)
        Me.AlterarToolStripMenuItem3.Text = "Alterar"
        '
        'ConsultarToolStripMenuItem2
        '
        Me.ConsultarToolStripMenuItem2.Name = "ConsultarToolStripMenuItem2"
        Me.ConsultarToolStripMenuItem2.Size = New System.Drawing.Size(125, 22)
        Me.ConsultarToolStripMenuItem2.Text = "Consultar"
        '
        'ClientesToolStripMenuItem
        '
        Me.ClientesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CadastrarToolStripMenuItem3, Me.AlterarToolStripMenuItem4, Me.ConsultarToolStripMenuItem3})
        Me.ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem"
        Me.ClientesToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.ClientesToolStripMenuItem.Text = "Cliente"
        '
        'CadastrarToolStripMenuItem3
        '
        Me.CadastrarToolStripMenuItem3.Name = "CadastrarToolStripMenuItem3"
        Me.CadastrarToolStripMenuItem3.Size = New System.Drawing.Size(125, 22)
        Me.CadastrarToolStripMenuItem3.Text = "Cadastrar"
        '
        'AlterarToolStripMenuItem4
        '
        Me.AlterarToolStripMenuItem4.Name = "AlterarToolStripMenuItem4"
        Me.AlterarToolStripMenuItem4.Size = New System.Drawing.Size(125, 22)
        Me.AlterarToolStripMenuItem4.Text = "Alterar"
        '
        'ConsultarToolStripMenuItem3
        '
        Me.ConsultarToolStripMenuItem3.Name = "ConsultarToolStripMenuItem3"
        Me.ConsultarToolStripMenuItem3.Size = New System.Drawing.Size(125, 22)
        Me.ConsultarToolStripMenuItem3.Text = "Consultar"
        '
        'ProdutosToolStripMenuItem
        '
        Me.ProdutosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CadastrarToolStripMenuItem4, Me.AlterarToolStripMenuItem5, Me.ConsultarToolStripMenuItem4})
        Me.ProdutosToolStripMenuItem.Name = "ProdutosToolStripMenuItem"
        Me.ProdutosToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.ProdutosToolStripMenuItem.Text = "Produto"
        '
        'CadastrarToolStripMenuItem4
        '
        Me.CadastrarToolStripMenuItem4.Name = "CadastrarToolStripMenuItem4"
        Me.CadastrarToolStripMenuItem4.Size = New System.Drawing.Size(125, 22)
        Me.CadastrarToolStripMenuItem4.Text = "Cadastrar"
        '
        'AlterarToolStripMenuItem5
        '
        Me.AlterarToolStripMenuItem5.Name = "AlterarToolStripMenuItem5"
        Me.AlterarToolStripMenuItem5.Size = New System.Drawing.Size(125, 22)
        Me.AlterarToolStripMenuItem5.Text = "Alterar"
        '
        'ConsultarToolStripMenuItem4
        '
        Me.ConsultarToolStripMenuItem4.Name = "ConsultarToolStripMenuItem4"
        Me.ConsultarToolStripMenuItem4.Size = New System.Drawing.Size(125, 22)
        Me.ConsultarToolStripMenuItem4.Text = "Consultar"
        '
        'PedidoToolStripMenuItem
        '
        Me.PedidoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IncluirVendaToolStripMenuItem, Me.ConsultarPedidoToolStripMenuItem})
        Me.PedidoToolStripMenuItem.Name = "PedidoToolStripMenuItem"
        Me.PedidoToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.PedidoToolStripMenuItem.Text = "Pedido"
        '
        'IncluirVendaToolStripMenuItem
        '
        Me.IncluirVendaToolStripMenuItem.Name = "IncluirVendaToolStripMenuItem"
        Me.IncluirVendaToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.IncluirVendaToolStripMenuItem.Text = "Incluir Venda"
        '
        'ConsultarPedidoToolStripMenuItem
        '
        Me.ConsultarPedidoToolStripMenuItem.Name = "ConsultarPedidoToolStripMenuItem"
        Me.ConsultarPedidoToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.ConsultarPedidoToolStripMenuItem.Text = "Consultar"
        '
        'RelatórioToolStripMenuItem
        '
        Me.RelatórioToolStripMenuItem.Name = "RelatórioToolStripMenuItem"
        Me.RelatórioToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.RelatórioToolStripMenuItem.Text = "Relatório"
        '
        'AjudaToolStripMenuItem
        '
        Me.AjudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SobreToolStripMenuItem, Me.BuscarAtualizaçãoToolStripMenuItem})
        Me.AjudaToolStripMenuItem.Name = "AjudaToolStripMenuItem"
        Me.AjudaToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
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
        Me.SplitC1.BackColor = System.Drawing.Color.Transparent
        Me.SplitC1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitC1.IsSplitterFixed = True
        Me.SplitC1.Location = New System.Drawing.Point(0, 24)
        Me.SplitC1.Name = "SplitC1"
        '
        'SplitC1.Panel1
        '
        Me.SplitC1.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SplitC1.Panel1.Controls.Add(Me.PictureBox2)
        '
        'SplitC1.Panel2
        '
        Me.SplitC1.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SplitC1.Panel2.Controls.Add(Me.TCPrincipal)
        Me.SplitC1.Panel2.Controls.Add(Me.LblOla)
        Me.SplitC1.Panel2.Controls.Add(Me.PictureBox1)
        Me.SplitC1.Size = New System.Drawing.Size(755, 425)
        Me.SplitC1.SplitterDistance = 251
        Me.SplitC1.SplitterWidth = 10
        Me.SplitC1.TabIndex = 10
        '
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(251, 425)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'TCPrincipal
        '
        Me.TCPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TCPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.TCPrincipal.Name = "TCPrincipal"
        Me.TCPrincipal.SelectedIndex = 0
        Me.TCPrincipal.Size = New System.Drawing.Size(494, 425)
        Me.TCPrincipal.TabIndex = 2
        Me.TCPrincipal.Visible = False
        '
        'LblOla
        '
        Me.LblOla.AutoSize = True
        Me.LblOla.Font = New System.Drawing.Font("Verdana", 32.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOla.ForeColor = System.Drawing.Color.White
        Me.LblOla.Location = New System.Drawing.Point(16, 32)
        Me.LblOla.Name = "LblOla"
        Me.LblOla.Size = New System.Drawing.Size(184, 52)
        Me.LblOla.TabIndex = 1
        Me.LblOla.Text = "Label1"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(156, 129)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(181, 165)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuFecharUma, Me.ToolStripMenuFecharTodas})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(176, 48)
        '
        'ToolStripMenuFecharUma
        '
        Me.ToolStripMenuFecharUma.Name = "ToolStripMenuFecharUma"
        Me.ToolStripMenuFecharUma.Size = New System.Drawing.Size(175, 22)
        Me.ToolStripMenuFecharUma.Text = "Fechar Selecionada"
        '
        'ToolStripMenuFecharTodas
        '
        Me.ToolStripMenuFecharTodas.Name = "ToolStripMenuFecharTodas"
        Me.ToolStripMenuFecharTodas.Size = New System.Drawing.Size(175, 22)
        Me.ToolStripMenuFecharTodas.Text = "Fechar Todas"
        '
        'Frm_Principal_MDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(755, 471)
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
        Me.SplitC1.Panel2.ResumeLayout(False)
        Me.SplitC1.Panel2.PerformLayout()
        CType(Me.SplitC1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitC1.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MnStrip_Principal As System.Windows.Forms.MenuStrip
    Friend WithEvents AçõesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SairToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsuáriosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlterarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CadastrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlterarToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CargosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CadastrarToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlterarToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VendedorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CadastrarToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlterarToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClientesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CadastrarToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlterarToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProdutosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CadastrarToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlterarToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PedidoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IncluirVendaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConsultarPedidoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents FecharSelecionadaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FecharTodasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitC1 As System.Windows.Forms.SplitContainer
    Friend WithEvents LblOla As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TCPrincipal As System.Windows.Forms.TabControl
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuFecharUma As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuFecharTodas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
End Class