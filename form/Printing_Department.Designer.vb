﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Printing_Department
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Printing_Department))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.btn_logout = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_passUpdate = New System.Windows.Forms.ToolStripMenuItem()
        Me.txt_welcome = New System.Windows.Forms.ToolStripMenuItem()
        Me.txt_search = New System.Windows.Forms.TextBox()
        Me.bgw_PrintLoader = New System.ComponentModel.BackgroundWorker()
        Me.dgv_details = New System.Windows.Forms.DataGridView()
        Me.order_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.customer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.order_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.delivery_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.datetime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.printing_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_refresh = New System.Windows.Forms.Button()
        Me.lbl_page = New System.Windows.Forms.Label()
        Me.btn_next = New System.Windows.Forms.Button()
        Me.btn_previous = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgv_details, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_logout, Me.btn_passUpdate, Me.txt_welcome})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 1, 0, 1)
        Me.MenuStrip1.Size = New System.Drawing.Size(672, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'btn_logout
        '
        Me.btn_logout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btn_logout.BackColor = System.Drawing.Color.DarkOrange
        Me.btn_logout.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_logout.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btn_logout.Margin = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.btn_logout.Name = "btn_logout"
        Me.btn_logout.Size = New System.Drawing.Size(58, 22)
        Me.btn_logout.Text = "Logout"
        Me.btn_logout.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'btn_passUpdate
        '
        Me.btn_passUpdate.Name = "btn_passUpdate"
        Me.btn_passUpdate.Size = New System.Drawing.Size(110, 22)
        Me.btn_passUpdate.Text = "Password Update"
        '
        'txt_welcome
        '
        Me.txt_welcome.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.txt_welcome.Enabled = False
        Me.txt_welcome.Name = "txt_welcome"
        Me.txt_welcome.Size = New System.Drawing.Size(112, 22)
        Me.txt_welcome.Text = "Welcome: Nelson"
        '
        'txt_search
        '
        Me.txt_search.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.txt_search.Location = New System.Drawing.Point(8, 27)
        Me.txt_search.Margin = New System.Windows.Forms.Padding(2)
        Me.txt_search.MaxLength = 10
        Me.txt_search.Name = "txt_search"
        Me.txt_search.Size = New System.Drawing.Size(203, 20)
        Me.txt_search.TabIndex = 6
        Me.txt_search.Text = "Search"
        '
        'bgw_PrintLoader
        '
        '
        'dgv_details
        '
        Me.dgv_details.AllowUserToAddRows = False
        Me.dgv_details.AllowUserToDeleteRows = False
        Me.dgv_details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv_details.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_details.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv_details.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_details.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.order_id, Me.customer, Me.order_name, Me.delivery_date, Me.Column5, Me.datetime, Me.printing_status})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv_details.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv_details.Enabled = False
        Me.dgv_details.Location = New System.Drawing.Point(8, 53)
        Me.dgv_details.Margin = New System.Windows.Forms.Padding(2)
        Me.dgv_details.MultiSelect = False
        Me.dgv_details.Name = "dgv_details"
        Me.dgv_details.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv_details.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgv_details.RowTemplate.Height = 28
        Me.dgv_details.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv_details.Size = New System.Drawing.Size(660, 378)
        Me.dgv_details.TabIndex = 3
        '
        'order_id
        '
        Me.order_id.DataPropertyName = "order_id"
        Me.order_id.HeaderText = "Job Sheet No."
        Me.order_id.Name = "order_id"
        Me.order_id.ReadOnly = True
        '
        'customer
        '
        Me.customer.DataPropertyName = "customer"
        Me.customer.HeaderText = "Customer Name"
        Me.customer.Name = "customer"
        Me.customer.ReadOnly = True
        '
        'order_name
        '
        Me.order_name.DataPropertyName = "order_name"
        Me.order_name.HeaderText = "Order Name"
        Me.order_name.Name = "order_name"
        Me.order_name.ReadOnly = True
        '
        'delivery_date
        '
        Me.delivery_date.DataPropertyName = "delivery_date"
        Me.delivery_date.HeaderText = "Delivery Date"
        Me.delivery_date.Name = "delivery_date"
        Me.delivery_date.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "status"
        Me.Column5.HeaderText = "Status"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'datetime
        '
        Me.datetime.DataPropertyName = "datetime"
        Me.datetime.HeaderText = "Respond Date"
        Me.datetime.Name = "datetime"
        Me.datetime.ReadOnly = True
        '
        'printing_status
        '
        Me.printing_status.DataPropertyName = "printing"
        Me.printing_status.HeaderText = "Printing Status"
        Me.printing_status.Name = "printing_status"
        Me.printing_status.ReadOnly = True
        Me.printing_status.Visible = False
        '
        'btn_refresh
        '
        Me.btn_refresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_refresh.Location = New System.Drawing.Point(585, 25)
        Me.btn_refresh.Name = "btn_refresh"
        Me.btn_refresh.Size = New System.Drawing.Size(75, 23)
        Me.btn_refresh.TabIndex = 2
        Me.btn_refresh.Text = "Refresh"
        Me.btn_refresh.UseVisualStyleBackColor = True
        '
        'lbl_page
        '
        Me.lbl_page.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_page.AutoSize = True
        Me.lbl_page.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_page.Location = New System.Drawing.Point(116, 439)
        Me.lbl_page.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbl_page.MinimumSize = New System.Drawing.Size(67, 0)
        Me.lbl_page.Name = "lbl_page"
        Me.lbl_page.Size = New System.Drawing.Size(67, 17)
        Me.lbl_page.TabIndex = 12
        Me.lbl_page.Text = "Label1"
        Me.lbl_page.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_next
        '
        Me.btn_next.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_next.Enabled = False
        Me.btn_next.Location = New System.Drawing.Point(195, 435)
        Me.btn_next.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_next.Name = "btn_next"
        Me.btn_next.Size = New System.Drawing.Size(91, 20)
        Me.btn_next.TabIndex = 5
        Me.btn_next.Text = "Next"
        Me.btn_next.UseVisualStyleBackColor = True
        '
        'btn_previous
        '
        Me.btn_previous.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_previous.Enabled = False
        Me.btn_previous.Location = New System.Drawing.Point(8, 435)
        Me.btn_previous.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_previous.Name = "btn_previous"
        Me.btn_previous.Size = New System.Drawing.Size(91, 20)
        Me.btn_previous.TabIndex = 4
        Me.btn_previous.Text = "Previous"
        Me.btn_previous.UseVisualStyleBackColor = True
        '
        'Printing_Department
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(672, 474)
        Me.Controls.Add(Me.lbl_page)
        Me.Controls.Add(Me.btn_next)
        Me.Controls.Add(Me.btn_previous)
        Me.Controls.Add(Me.btn_refresh)
        Me.Controls.Add(Me.dgv_details)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.txt_search)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MinimumSize = New System.Drawing.Size(688, 513)
        Me.Name = "Printing_Department"
        Me.Text = "Printing Department"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgv_details, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents btn_logout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_passUpdate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txt_welcome As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txt_search As System.Windows.Forms.TextBox
    Friend WithEvents bgw_PrintLoader As System.ComponentModel.BackgroundWorker
    Friend WithEvents dgv_details As System.Windows.Forms.DataGridView
    Friend WithEvents btn_refresh As Button
    Friend WithEvents order_id As DataGridViewTextBoxColumn
    Friend WithEvents customer As DataGridViewTextBoxColumn
    Friend WithEvents order_name As DataGridViewTextBoxColumn
    Friend WithEvents delivery_date As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents datetime As DataGridViewTextBoxColumn
    Friend WithEvents printing_status As DataGridViewTextBoxColumn
    Friend WithEvents lbl_page As System.Windows.Forms.Label
    Friend WithEvents btn_next As System.Windows.Forms.Button
    Friend WithEvents btn_previous As System.Windows.Forms.Button
End Class
