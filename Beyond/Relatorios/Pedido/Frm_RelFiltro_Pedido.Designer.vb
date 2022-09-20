<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_RelFiltro_Pedido
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_RelFiltro_Pedido))
        Me.GrpBoxFiltro = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DtFinal = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DtInicial = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ChkVendedor = New System.Windows.Forms.CheckBox()
        Me.ChkCliente = New System.Windows.Forms.CheckBox()
        Me.ComboVendedor = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboCliente = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BtnVisualizar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GrpBoxFiltro.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpBoxFiltro
        '
        Me.GrpBoxFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpBoxFiltro.BackColor = System.Drawing.SystemColors.Menu
        Me.GrpBoxFiltro.Controls.Add(Me.Label5)
        Me.GrpBoxFiltro.Controls.Add(Me.DtFinal)
        Me.GrpBoxFiltro.Controls.Add(Me.Label4)
        Me.GrpBoxFiltro.Controls.Add(Me.DtInicial)
        Me.GrpBoxFiltro.Controls.Add(Me.Label3)
        Me.GrpBoxFiltro.Controls.Add(Me.ChkVendedor)
        Me.GrpBoxFiltro.Controls.Add(Me.ChkCliente)
        Me.GrpBoxFiltro.Controls.Add(Me.ComboVendedor)
        Me.GrpBoxFiltro.Controls.Add(Me.Label2)
        Me.GrpBoxFiltro.Controls.Add(Me.ComboCliente)
        Me.GrpBoxFiltro.Controls.Add(Me.Label1)
        Me.GrpBoxFiltro.Location = New System.Drawing.Point(12, 42)
        Me.GrpBoxFiltro.Name = "GrpBoxFiltro"
        Me.GrpBoxFiltro.Size = New System.Drawing.Size(678, 196)
        Me.GrpBoxFiltro.TabIndex = 1
        Me.GrpBoxFiltro.TabStop = False
        Me.GrpBoxFiltro.Text = "Filtros"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(135, 157)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 17)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "-"
        '
        'DtFinal
        '
        Me.DtFinal.CustomFormat = ""
        Me.DtFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFinal.Location = New System.Drawing.Point(156, 154)
        Me.DtFinal.Name = "DtFinal"
        Me.DtFinal.Size = New System.Drawing.Size(120, 24)
        Me.DtFinal.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(153, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 17)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Data Final"
        '
        'DtInicial
        '
        Me.DtInicial.CustomFormat = ""
        Me.DtInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtInicial.Location = New System.Drawing.Point(9, 154)
        Me.DtInicial.Name = "DtInicial"
        Me.DtInicial.Size = New System.Drawing.Size(120, 24)
        Me.DtInicial.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 17)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Data Inicial"
        '
        'ChkVendedor
        '
        Me.ChkVendedor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkVendedor.AutoSize = True
        Me.ChkVendedor.Location = New System.Drawing.Point(657, 108)
        Me.ChkVendedor.Name = "ChkVendedor"
        Me.ChkVendedor.Size = New System.Drawing.Size(15, 14)
        Me.ChkVendedor.TabIndex = 4
        Me.ChkVendedor.UseVisualStyleBackColor = True
        '
        'ChkCliente
        '
        Me.ChkCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChkCliente.AutoSize = True
        Me.ChkCliente.Location = New System.Drawing.Point(657, 57)
        Me.ChkCliente.Name = "ChkCliente"
        Me.ChkCliente.Size = New System.Drawing.Size(15, 14)
        Me.ChkCliente.TabIndex = 2
        Me.ChkCliente.UseVisualStyleBackColor = True
        '
        'ComboVendedor
        '
        Me.ComboVendedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboVendedor.Enabled = False
        Me.ComboVendedor.FormattingEnabled = True
        Me.ComboVendedor.Location = New System.Drawing.Point(9, 98)
        Me.ComboVendedor.Name = "ComboVendedor"
        Me.ComboVendedor.Size = New System.Drawing.Size(642, 24)
        Me.ComboVendedor.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Vendedor"
        '
        'ComboCliente
        '
        Me.ComboCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ComboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCliente.Enabled = False
        Me.ComboCliente.FormattingEnabled = True
        Me.ComboCliente.Location = New System.Drawing.Point(9, 52)
        Me.ComboCliente.Name = "ComboCliente"
        Me.ComboCliente.Size = New System.Drawing.Size(642, 24)
        Me.ComboCliente.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cliente"
        '
        'Label6
        '
        Me.Label6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(260, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(198, 23)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Selecione os Filtros"
        '
        'BtnVisualizar
        '
        Me.BtnVisualizar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.BtnVisualizar.BackColor = System.Drawing.Color.Gainsboro
        Me.BtnVisualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnVisualizar.Font = New System.Drawing.Font("Verdana", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVisualizar.ForeColor = System.Drawing.SystemColors.WindowText
        Me.BtnVisualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnVisualizar.ImageKey = "report.png"
        Me.BtnVisualizar.ImageList = Me.ImageList1
        Me.BtnVisualizar.Location = New System.Drawing.Point(264, 254)
        Me.BtnVisualizar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnVisualizar.Name = "BtnVisualizar"
        Me.BtnVisualizar.Size = New System.Drawing.Size(194, 44)
        Me.BtnVisualizar.TabIndex = 52
        Me.BtnVisualizar.Text = "Visualizar Relatório"
        Me.BtnVisualizar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnVisualizar.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "report.png")
        '
        'Frm_RelFiltro_Pedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 302)
        Me.Controls.Add(Me.BtnVisualizar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GrpBoxFiltro)
        Me.Font = New System.Drawing.Font("Verdana", 10.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Frm_RelFiltro_Pedido"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Filtros para relatório de pedidos"
        Me.GrpBoxFiltro.ResumeLayout(False)
        Me.GrpBoxFiltro.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GrpBoxFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DtFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DtInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ChkVendedor As System.Windows.Forms.CheckBox
    Friend WithEvents ChkCliente As System.Windows.Forms.CheckBox
    Friend WithEvents ComboVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnVisualizar As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class
