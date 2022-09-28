Imports Entidades
Public Class Frm_Cliente_Cargo

    Private Cliente As Cliente
    Private CodCargo As String
    Private Cargo As Cargo
    Private DAO As New DAO.DAO

    Private frmPrincipal As Frm_Principal_MDI

    Public Sub New(ByVal frm As Frm_Principal_MDI, ByVal codcargo As Int16)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.CodCargo = codcargo.ToString
        Me.frmPrincipal = frm
    End Sub

    Private Sub Frm_Cliente_Cargo_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub Frm_Cliente_Cargo_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Cargo = DAO.GetCargo(CodCargo)
        TxtCargo.Text = Cargo.Nome

        Cliente = DAO.GetClientePorCargo(Cargo.CodCargo)

        TxtCliente.Text = Cliente.Nome
        ChkAtivo.Checked = Cliente.IsAtivo
    End Sub

    Private Sub BtnDesvincular_Click(sender As System.Object, e As System.EventArgs) Handles BtnDesvincular.Click
        If Uteis.MsgBoxHelper.MsgTemCerteza(Me, "Ao confirmar, o cliente " + Cliente.Nome + _
            " perderá a informação de cargo " + Cargo.Nome, "Confirmar") Then
            Dim resposta As String = ""
            If DAO.RemoveCargoCliente(Cliente.CodCliente, codusuario, resposta) Then
                Uteis.MsgBoxHelper.Msg(Me, "O Cliente " + Cliente.Nome + " não possui mais o cargo " + _
                    Cargo.Nome + ".", "Sucesso")
                Cargo = Nothing
                Cliente = Nothing
                Cursor.Current = Cursors.WaitCursor
                System.Threading.Thread.Sleep(2000)
                Me.Close()
            Else
                Uteis.MsgBoxHelper.Alerta(Me, resposta, "Erro")
            End If
        End If
    End Sub
End Class