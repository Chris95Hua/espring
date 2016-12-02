﻿Public Class Generate_Barcode_Sticker
    ' Sticker settings
    ' ===================================
    Private stickerPadding As Integer = 8                      ' padding used for the components inside sticker
    Private stickerWidth As Integer = 400                      ' sticker width
    Private stickerHeight As Integer = 360                     ' sticker height
    Private stickerOutterMargin As Integer = 40                ' distance between stickers (vertical & horizontal)
    Private fontSizeTitle As Integer = 17                      ' font size for title (customer name, order name, bags)
    Private fontSizeNormal As Integer = 11                     ' normal font size (text below barcode)
    Private fontSizeSmall As Integer = 10                      ' small font size (size & quantity, total pieces)
    Private fontFamily As String = "arial"                     ' font family to be used

    ' ===================================
    Private order As New Dictionary(Of String, Object)
    Private orderID As String
    Private customer As String
    Private orderName As String


    Private totalBagsCount As Integer
    Private horizontalStickerCount As Integer
    Private verticalStickerCount As Integer
    Private stickerCount As Integer = 0

    Sub New(ByVal orderDetails As Dictionary(Of String, Object))
        ' This call is required by the designer.
        InitializeComponent()

        order = orderDetails

        customer = order.Item(_BADGE.CUSTOMER)
        order.Remove(_BADGE.CUSTOMER)

        orderName = order.Item(_BADGE.ORDER_NAME)
        order.Remove(_BADGE.ORDER_NAME)

        orderID = order.Item(_BADGE.ORDER)
        order.Remove(_BADGE.ORDER)

        ' Printer settings
        ' ===================================
        ' paper size
        'pd_barcodeSticker.DefaultPageSettings.PaperSize = New System.Drawing.Printing.PaperSize("Barcode Sticker", 800, 600)
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        ppc_preview.Document = pd_barcodeSticker
        ValidatePageSettings()
    End Sub

    Private Function ValidatePageSettings() As Boolean
        ' get no. of sticker can be fit in a page horizontally and vertically
        ' TODO: take sticker margin into consideration
        horizontalStickerCount = Math.Floor(pd_barcodeSticker.DefaultPageSettings.PrintableArea.Width() / (stickerWidth + stickerOutterMargin))
        verticalStickerCount = Math.Floor(pd_barcodeSticker.DefaultPageSettings.PrintableArea.Height() / (stickerHeight + stickerOutterMargin))

        If horizontalStickerCount = 0 Or verticalStickerCount = 0 Then
            MessageBox.Show("Sticker size is larger than the document size", "Error")
            Return False
        Else
            totalBagsCount = num_bags.Value
            num_preview.Maximum = Math.Ceiling(totalBagsCount / (horizontalStickerCount * verticalStickerCount))
            Return True
        End If
    End Function

    Private Sub btn_print_Click(sender As Object, e As EventArgs) Handles btn_print.Click
        ' max 26 barcode digit for default size
        stickerCount = 0
        pd_barcodeSticker.Print()
    End Sub

    Private Sub PrintBarcodeSticker(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs) Handles pd_barcodeSticker.PrintPage
        Dim xOrigin As Integer = Math.Floor((pd_barcodeSticker.DefaultPageSettings.PaperSize.Width() - pd_barcodeSticker.DefaultPageSettings.PrintableArea.Width()) / 2)
        Dim yOrigin As Integer = Math.Floor((pd_barcodeSticker.DefaultPageSettings.PaperSize.Height() - pd_barcodeSticker.DefaultPageSettings.PrintableArea.Height()) / 2)

        If horizontalStickerCount = 1 And True Then
            xOrigin = Math.Floor((xOrigin + stickerWidth) / 2)
        End If

        If verticalStickerCount = 1 And True Then
            yOrigin = Math.Floor((yOrigin + stickerHeight) / 2)
        End If

        Dim curHoriStickerCount As Integer = 1
        Dim curVertiStickerCount As Integer = 1

        Dim maxStickerPerPage As Integer = horizontalStickerCount * verticalStickerCount
        Dim stickerToPrint As Integer

        If totalBagsCount - stickerCount > maxStickerPerPage Then
            stickerToPrint = maxStickerPerPage
        Else
            stickerToPrint = totalBagsCount - stickerCount
        End If

        ' generate barcode and label
        Dim barcode128 As Zen.Barcode.Code128BarcodeDraw = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum
        Dim barcode As Image = barcode128.Draw(orderID, 60, 2)

        ' center
        Dim formatCenter As New StringFormat()
        formatCenter.Alignment = StringAlignment.Center

        Dim formatLeft As New StringFormat()
        formatLeft.Alignment = StringAlignment.Near

        ' pen for drawing lines and rounded rectangle
        Dim linePen As New Pen(Color.Black, 2)

        e.Graphics.TranslateTransform(xOrigin, yOrigin)

        For currentStickerPrint As Integer = 1 To stickerToPrint
            stickerCount += 1

            ' Y coordinates
            Dim yMarginFromTop As Integer = stickerPadding
            Dim yMarginFromBottom As Integer = stickerHeight - fontSizeNormal - barcode.Height - (2 * stickerPadding)

            ' graphic mode
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            ' draw border
            e.Graphics.DrawPath(linePen, RoundedRectangle(Rectangle.Round(New RectangleF(0, 0, stickerWidth, stickerHeight + fontSizeTitle + 4)), 50))

            ' customer name
            e.Graphics.DrawString(customer, New Font(fontFamily, fontSizeTitle, FontStyle.Bold), New SolidBrush(Color.Black), stickerWidth / 2, yMarginFromTop, formatCenter)
            yMarginFromTop += (1.5 * stickerPadding) + fontSizeTitle

            If order.ContainsKey(_BADGE.ADDRESS_1) Then
                e.Graphics.DrawString(order.Item(_BADGE.ADDRESS_1), New Font(fontFamily, fontSizeNormal), New SolidBrush(Color.Black), stickerWidth / 2, yMarginFromTop, formatCenter)
                yMarginFromTop += stickerPadding + fontSizeNormal
            End If

            If order.ContainsKey(_BADGE.ADDRESS_2) Then
                e.Graphics.DrawString(order.Item(_BADGE.ADDRESS_2), New Font(fontFamily, fontSizeNormal), New SolidBrush(Color.Black), stickerWidth / 2, yMarginFromTop, formatCenter)
                yMarginFromTop += stickerPadding + fontSizeNormal
            End If

            If order.ContainsKey(_BADGE.ADDRESS_3) Then
                e.Graphics.DrawString(order.Item(_BADGE.ADDRESS_3), New Font(fontFamily, fontSizeNormal), New SolidBrush(Color.Black), stickerWidth / 2, yMarginFromTop, formatCenter)
            End If

            ' separator (customer - order name)
            yMarginFromTop = (stickerHeight / 4) + (2 * stickerPadding)
            e.Graphics.DrawLine(linePen, New Point(0, yMarginFromTop), New Point(stickerWidth, yMarginFromTop))

            ' order name
            yMarginFromTop += stickerPadding
            e.Graphics.DrawString(orderName, New Font(fontFamily, fontSizeTitle, FontStyle.Bold), New SolidBrush(Color.Black), stickerWidth / 2, yMarginFromTop, formatCenter)

            ' separator (order name - details)
            yMarginFromTop += (2 * stickerPadding) + fontSizeTitle
            e.Graphics.DrawLine(linePen, New Point(0, yMarginFromTop), New Point(stickerWidth, yMarginFromTop))

            ' barcode
            Dim barcodeX As Integer = (stickerWidth - barcode.Width) / 2
            Dim barcodeY As Integer = stickerHeight - barcode.Height - stickerPadding - (stickerPadding / 2)

            e.Graphics.DrawImage(barcode, barcodeX, barcodeY)

            ' barcode text
            e.Graphics.DrawString(orderID, New Font(fontFamily, fontSizeNormal), New SolidBrush(Color.Black), stickerWidth / 2, stickerHeight - stickerPadding, formatCenter)

            ' details separator
            e.Graphics.DrawLine(linePen, New Point(stickerWidth / 2, yMarginFromTop), New Point(stickerWidth / 2, yMarginFromBottom))

            ' right details (quantity)
            e.Graphics.DrawString("BAGS: " & stickerCount & "/" & totalBagsCount, New Font(fontFamily, fontSizeTitle, FontStyle.Bold), New SolidBrush(Color.Black), stickerWidth / 4 * 3, yMarginFromTop - fontSizeTitle + (Math.Abs(yMarginFromBottom - yMarginFromTop) / 2), formatCenter)

            ' left details (sizes)
            Dim sizeOffset As Integer = 0
            Dim total As Integer
            For Each pair In order
                If sizeOffset > 6 Then
                    e.Graphics.DrawString(String.Format("{0,-3}", pair.Key) & " - " & pair.Value, New Font(fontFamily, fontSizeSmall, FontStyle.Bold), New SolidBrush(Color.Black), stickerWidth / 24 * 6, yMarginFromTop + stickerPadding + ((sizeOffset - 8) * fontSizeSmall), formatLeft)
                Else
                    e.Graphics.DrawString(String.Format("{0,-3}", pair.Key) & " - " & pair.Value, New Font(fontFamily, fontSizeSmall, FontStyle.Bold), New SolidBrush(Color.Black), stickerWidth / 24, yMarginFromTop + stickerPadding + (sizeOffset * fontSizeSmall), formatLeft)
                End If

                total += pair.Value
                sizeOffset += 2
            Next

            e.Graphics.DrawString("TOTAL: " & total, New Font(fontFamily, fontSizeSmall, FontStyle.Bold), New SolidBrush(Color.Black), stickerWidth / 24, yMarginFromBottom - (3 * stickerPadding), formatLeft)

            ' seperator (order detail - barcode)
            e.Graphics.DrawLine(linePen, New Point(0, yMarginFromBottom), New Point(stickerWidth, yMarginFromBottom))

            ' offset starting point
            If curHoriStickerCount < horizontalStickerCount Then
                e.Graphics.TranslateTransform(stickerWidth + stickerOutterMargin, 0)
            End If

            If curVertiStickerCount < verticalStickerCount Then
                e.Graphics.TranslateTransform(0, stickerHeight + stickerOutterMargin)
            End If

            ' create new page
            If currentStickerPrint = stickerToPrint Then
                linePen.Dispose()
                e.HasMorePages = (stickerCount < totalBagsCount)
            End If
        Next
    End Sub

    Private Function RoundedRectangle(ByVal rectangle As Rectangle, ByVal radius As Integer) As Drawing2D.GraphicsPath
        Dim path As New Drawing2D.GraphicsPath()
        Dim diameter As Integer = radius * 2

        path.AddLine(rectangle.Left + diameter, rectangle.Top, rectangle.Right - diameter, rectangle.Top)
        path.AddArc(Rectangle.FromLTRB(rectangle.Right - diameter, rectangle.Top, rectangle.Right, rectangle.Top + diameter), -90, 90)

        path.AddLine(rectangle.Right, rectangle.Top + diameter, rectangle.Right, rectangle.Bottom - diameter)
        path.AddArc(Rectangle.FromLTRB(rectangle.Right - diameter, rectangle.Bottom - diameter, rectangle.Right, rectangle.Bottom), 0, 90)

        path.AddLine(rectangle.Right - diameter, rectangle.Bottom, rectangle.Left + diameter, rectangle.Bottom)
        path.AddArc(Rectangle.FromLTRB(rectangle.Left, rectangle.Bottom - diameter, rectangle.Left + diameter, rectangle.Bottom), 90, 90)

        path.AddLine(rectangle.Left, rectangle.Bottom - diameter, rectangle.Left, rectangle.Top + diameter)
        path.AddArc(Rectangle.FromLTRB(rectangle.Left, rectangle.Top, rectangle.Left + diameter, rectangle.Top + diameter), 180, 90)

        path.CloseFigure()

        Return path
    End Function

    Private Sub num_bags_ValueChanged(sender As Object, e As EventArgs) Handles num_bags.ValueChanged
        stickerCount = 0

        If ValidatePageSettings() Then
            ppc_preview.InvalidatePreview()
        End If
    End Sub

    Private Sub num_preview_ValueChanged(sender As Object, e As EventArgs) Handles num_preview.ValueChanged
        ppc_preview.StartPage = num_preview.Value - 1
    End Sub

    Private Sub btn_printer_Click(sender As Object, e As EventArgs) Handles btn_printer.Click
        pdg_settings.AllowPrintToFile = False

        If pdg_settings.ShowDialog = Windows.Forms.DialogResult.OK Then
            stickerCount = 0
            pd_barcodeSticker.PrinterSettings = pdg_settings.PrinterSettings
            pd_barcodeSticker.Print()
        End If
    End Sub
End Class