<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_ConsPedido
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
        Me.GrpBoxFiltro = New System.Windows.Forms.GroupBox()
        Me.ComboVendedor = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboCliente = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GrpBoxPedidos = New System.Windows.Forms.GroupBox()
        Me.PicConfirmar = New System.Windows.Forms.PictureBox()
        Me.LstPedido = New System.Windows.Forms.ListView()
        Me.ColCod = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColVendedor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColDatVenda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColDestinatario = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GrpBoxFiltro.SuspendLayout()
        Me.GrpBoxPedidos.SuspendLayout()
        CType(Me.PicConfirmar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpBoxFiltro
        '
        Me.GrpBoxFiltro.Controls.Add(Me.ComboVendedor)
        Me.GrpBoxFiltro.Controls.Add(Me.Label2)
        Me.GrpBoxFiltro.Controls.Add(Me.ComboCliente)
        Me.GrpBoxFiltro.Controls.Add(Me.Label1)
        Me.GrpBoxFiltro.Dock = System.Windows.Forms.DockStyle.Top
        Me.GrpBoxFiltro.Location = New System.Drawing.Point(0, 0)
        Me.GrpBoxFiltro.Name = "GrpBoxFiltro"
        Me.GrpBoxFiltro.Size = New System.Drawing.Size(797, 151)
        Me.GrpBoxFiltro.TabIndex = 0
        Me.GrpBoxFiltro.TabStop = False
        Me.GrpBoxFiltro.Text = "Filtros"
        '
        'ComboVendedor
        '
        Me.ComboVendedor.FormattingEnabled = True
        Me.ComboVendedor.Location = New System.Drawing.Point(9, 98)
        Me.ComboVendedor.Name = "ComboVendedor"
        Me.ComboVendedor.Size = New System.Drawing.Size(383, 24)
        Me.ComboVendedor.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Vendedor"
        '
        'ComboCliente
        '
        Me.ComboCliente.FormattingEnabled = True
        Me.ComboCliente.Location = New System.Drawing.Point(9, 52)
        Me.ComboCliente.Name = "ComboCliente"
        Me.ComboCliente.Size = New System.Drawing.Size(383, 24)
        Me.ComboCliente.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cliente"
        '
        'GrpBoxPedidos
        '
        Me.GrpBoxPedidos.Controls.Add(Me.PicConfirmar)
        Me.GrpBoxPedidos.Controls.Add(Me.LstPedido)
        Me.GrpBoxPedidos.Dock = System.Windows.Forms.DockStyle.Top
        Me.GrpBoxPedidos.Location = New System.Drawing.Point(0, 151)
        Me.GrpBoxPedidos.Name = "GrpBoxPedidos"
        Me.GrpBoxPedidos.Size = New System.Drawing.Size(797, 276)
        Me.GrpBoxPedidos.TabIndex = 1
        Me.GrpBoxPedidos.TabStop = False
        Me.GrpBoxPedidos.Text = "Pedidos"
        '
        'PicConfirmar
        '
        Me.PicConfirmar.Image = Global.Beyond.My.Resources.Resources.confirm
        Me.PicConfirmar.Location = New System.Drawing.Point(766, 245)
        Me.PicConfirmar.Name = "PicConfirmar"
        Me.PicConfirmar.Size = New System.Drawing.Size(25, 25)
        Me.PicConfirmar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicConfirmar.TabIndex = 11
        Me.PicConfirmar.TabStop = False
        '
        'LstPedido
        '
        Me.LstPedido.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColCod, Me.ColCliente, Me.ColVendedor, Me.ColDatVenda, Me.ColDestinatario})
        Me.LstPedido.Location = New System.Drawing.Point(6, 40)
        Me.LstPedido.Name = "LstPedido"
        Me.LstPedido.Size = New System.Drawing.Size(791, 193)
        Me.LstPedido.TabIndex = 0
        Me.LstPedido.UseCompatibleStateImageBehavior = False
        Me.LstPedido.View = System.Windows.Forms.View.Details
        '
        'ColCod
        '
        Me.ColCod.Text = "Código do Pedido"
        Me.ColCod.Width = 171
        '
        'ColCliente
        '
        Me.ColCliente.Text = "Cliente"
        Me.ColCliente.Width = 273
        '
        'ColVendedor
        '
        Me.ColVendedor.Text = "Vendedor"
        Me.ColVendedor.Width = 273
        '
        'ColDatVenda
        '
        Me.ColDatVenda.Text = "Data da Venda"
        Me.ColDatVenda.Width = 157
        '
        'ColDestinatario
        '
        Me.ColDestinatario.Text = "Destinatário"
        Me.ColDestinatario.Width = 283
        '
        'Frm_ConsPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 423)
        Me.Controls.Add(Me.GrpBoxPedidos)
        Me.Controls.Add(Me.GrpBoxFiltro)
        Me.Font = New System.Drawing.Font("Verdana", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_ConsPedido"
        Me.Text = "Consultar Pedidos"
        Me.GrpBoxFiltro.ResumeLayout(False)
        Me.GrpBoxFiltro.PerformLayout()
        Me.GrpBoxPedidos.ResumeLayout(False)
        CType(Me.PicConfirmar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpBoxFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents ComboVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpBoxPedidos As System.Windows.Forms.GroupBox
    Friend WithEvents LstPedido As System.Windows.Forms.ListView
    Friend WithEvents ColCod As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColCliente As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColVendedor As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColDatVenda As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColDestinatario As System.Windows.Forms.ColumnHeader
    Friend WithEvents PicConfirmar As System.Windows.Forms.PictureBox
End Class
