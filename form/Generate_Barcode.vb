﻿Public Class Generate_Barcode
    Private fontSizeNormal As Integer = 6                 ' normal font size (text below barcode)
    Private fontFamily As String = "IDAutomationHC39M Free Version"

    Dim orderID As String

    Sub New(ByVal orderID As String)
        InitializeComponent()

        Me.orderID = orderID

        ' Printer settings (papersize)
        ' ===================================
        pd_barcode.DefaultPageSettings.PaperSize = New Printing.PaperSize("Barcode Sticker", 132, 94)

        ppd_barcode.Document = pd_barcode
    End Sub

    ' Generate document to print
    Private Sub PrintBarcode(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs) Handles pd_barcode.PrintPage
        ' text format
        Dim formatCenter As New StringFormat()
        formatCenter.Alignment = StringAlignment.Center

        ' barcode
        Dim textLocation As Integer = ((pd_barcode.DefaultPageSettings.PaperSize.Height() - fontSizeNormal) / 2) - 14
        e.Graphics.DrawString("*" & orderID & "*", New Font(fontFamily, fontSizeNormal), New SolidBrush(Color.Black), (pd_barcode.DefaultPageSettings.PaperSize.Width() / 2) + 1, textLocation, formatCenter)
    End Sub

    ' Print preview
    Private Sub btn_preview_Click(sender As Object, e As EventArgs) Handles btn_preview.Click
        ppd_barcode.ShowDialog()
    End Sub

    ' Printer settings
    Private Sub btn_printer_Click(sender As Object, e As EventArgs) Handles btn_printer.Click
        pdg_settings.AllowPrintToFile = False

        If pdg_settings.ShowDialog = DialogResult.OK Then
            pd_barcode.PrinterSettings = pdg_settings.PrinterSettings
            pd_barcode.Print()
        End If
    End Sub

    ' Print
    Private Sub btn_print_Click(sender As Object, e As EventArgs) Handles btn_print.Click
        pd_barcode.Print()
    End Sub
End Class