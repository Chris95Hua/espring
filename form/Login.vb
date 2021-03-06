﻿Public Class Login
    Private loadingOverlay As Loading_Overlay

    ' Clear session
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Session.Clear()
    End Sub

    ' Login button click
    Private Sub LogIn_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        Me.LogInFunction()
    End Sub

    ' Enter keydown login
    Private Sub txt_password_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_username.KeyDown, txt_password.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.LogInFunction()
        End If
    End Sub

    ' Login
    Private Sub LogInFunction()
        Dim credentials As New Dictionary(Of String, String)
        credentials.Add(_USER.USERNAME, txt_username.Text)
        credentials.Add(_USER.PASSWORD, txt_password.Text)

        bgw_login.RunWorkerAsync(credentials)
        ShowLoadingOverlay(True)
    End Sub

    ' Login Async Work
    Private Sub bgw_login_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgw_login.DoWork
        Dim users As List(Of Dictionary(Of String, Object))
        Dim credentials As New Dictionary(Of String, String)

        credentials = e.Argument

        users = Database.SelectRows(_TABLE.USER, {_USER.USERNAME, "=", credentials.Item(_USER.USERNAME)})

        If users IsNot Nothing Then
            For Each user In users
                Dim hashedPassword As String = Security.Hash(credentials.Item(_USER.PASSWORD), user.Item(_USER.SALT).ToString())

                If hashedPassword.CompareTo(user.Item(_USER.PASSWORD).ToString()) = 0 Then
                    Session.user_id = user.Item(_USER.USER_ID)
                    Session.first_name = user.Item(_USER.FIRST_NAME)
                    Session.last_name = user.Item(_USER.LAST_NAME)
                    Session.username = user.Item(_USER.USERNAME)
                    Session.password = user.Item(_USER.PASSWORD)
                    Session.salt = user.Item(_USER.SALT)
                    Session.role = user.Item(_USER.ROLE)
                    Session.department_id = user.Item(_USER.DEPARTMENT_ID)

                    e.Result = 1
                Else
                    e.Result = 0
                End If
            Next
        Else
            e.Result = -1
        End If

    End Sub

    ' Login completed
    Private Sub bgw_login_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw_login.RunWorkerCompleted
        ShowLoadingOverlay(False)

        Select Case e.Result
            Case 1
                Select Case Session.department_id
                    Case _PROCESS.ADMIN
                        Dim admin As New Admin_Form
                        admin.Show()
                    Case _PROCESS.APPROVAL
                        Dim approve As New Approve_Order
                        approve.Show()
                    Case _PROCESS.CUTTING
                        Dim cutting As New Cutting_Department
                        cutting.Show()
                    Case _PROCESS.EMBROIDERY
                        Dim embroidery As New Embroidery_Department
                        embroidery.Show()
                    Case _PROCESS.INVENTORY
                        Dim inventory As New Inventory_Preparation
                        inventory.Show()
                    Case _PROCESS.ORDER
                        Dim order As New Manage_Order
                        order.Show()
                    Case _PROCESS.PRINTING
                        Dim printing As New Printing_Department
                        printing.Show()
                    Case _PROCESS.SEWING
                        Dim sewing As New Sewing_Department
                        sewing.Show()
                End Select

                Me.Close()
            Case 0
                MessageBox.Show("Password does not match the username", "Login Failed")
                txt_password.Focus()
                txt_password.SelectAll()
            Case -1
                MessageBox.Show("Unable to find matching username and password", "Login Failed")
                txt_password.Clear()
                txt_username.Focus()
                txt_username.SelectAll()
        End Select
    End Sub

    ' Loading overlay
    Private Sub ShowLoadingOverlay(ByVal show As Boolean)
        If show Then
            loadingOverlay = New Loading_Overlay
            loadingOverlay.Size = New Size(Me.Width - 16, Me.Height - 38)
            loadingOverlay.ShowDialog()
        Else
            loadingOverlay.Close()
        End If
    End Sub
End Class
