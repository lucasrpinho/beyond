﻿Imports DAO
Imports Uteis

Public Class Frm_Sobre

    Private LstSobre As New List(Of Object)
    Private Const APENAS_FORM_PRINCIPAL_E_FORM_SOBRE = 1

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        DAO.DAO.GetSobreSistema(LstSobre)
    End Sub

    Private Sub Frm_Sobre_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LblNomeAutor.Text = LstSobre(1).ToString
        LblNumSistema.Text = LstSobre(2).ToString
        LblDataVersao.Text = FormatDateTime(LstSobre(3), DateFormat.ShortDate)
    End Sub

    Private Sub Frm_Sobre_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        If Application.OpenForms.Count > APENAS_FORM_PRINCIPAL_E_FORM_SOBRE Then
            e.Cancel = False
        Else
            Dim frmPrincipal As New Frm_Principal_MDI
            frmPrincipal.Show()
        End If
    End Sub

    Private Sub BtnOK_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub
End Class
