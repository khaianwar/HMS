<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdmin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdmin))
        Me.lblPwd = New System.Windows.Forms.Label()
        Me.gpLogin = New System.Windows.Forms.GroupBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.txtPwd = New System.Windows.Forms.TextBox()
        Me.gpRoom = New System.Windows.Forms.GroupBox()
        Me.pnlGrid = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.dgvRoom = New System.Windows.Forms.DataGridView()
        Me.gpLogin.SuspendLayout()
        Me.gpRoom.SuspendLayout()
        Me.pnlGrid.SuspendLayout()
        CType(Me.dgvRoom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPwd
        '
        Me.lblPwd.AutoSize = True
        Me.lblPwd.Location = New System.Drawing.Point(22, 29)
        Me.lblPwd.Name = "lblPwd"
        Me.lblPwd.Size = New System.Drawing.Size(53, 13)
        Me.lblPwd.TabIndex = 0
        Me.lblPwd.Text = "Password"
        '
        'gpLogin
        '
        Me.gpLogin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpLogin.Controls.Add(Me.btnLogin)
        Me.gpLogin.Controls.Add(Me.txtPwd)
        Me.gpLogin.Controls.Add(Me.lblPwd)
        Me.gpLogin.Location = New System.Drawing.Point(12, 12)
        Me.gpLogin.Name = "gpLogin"
        Me.gpLogin.Size = New System.Drawing.Size(395, 67)
        Me.gpLogin.TabIndex = 1
        Me.gpLogin.TabStop = False
        '
        'btnLogin
        '
        Me.btnLogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogin.Location = New System.Drawing.Point(328, 22)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(56, 26)
        Me.btnLogin.TabIndex = 2
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'txtPwd
        '
        Me.txtPwd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPwd.Location = New System.Drawing.Point(94, 26)
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwd.Size = New System.Drawing.Size(228, 20)
        Me.txtPwd.TabIndex = 1
        '
        'gpRoom
        '
        Me.gpRoom.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpRoom.Controls.Add(Me.btnSave)
        Me.gpRoom.Controls.Add(Me.pnlGrid)
        Me.gpRoom.Location = New System.Drawing.Point(12, 12)
        Me.gpRoom.Name = "gpRoom"
        Me.gpRoom.Size = New System.Drawing.Size(395, 303)
        Me.gpRoom.TabIndex = 2
        Me.gpRoom.TabStop = False
        Me.gpRoom.Text = "Hotel Rooms"
        '
        'pnlGrid
        '
        Me.pnlGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlGrid.Controls.Add(Me.dgvRoom)
        Me.pnlGrid.Location = New System.Drawing.Point(6, 19)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Size = New System.Drawing.Size(383, 250)
        Me.pnlGrid.TabIndex = 0
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(290, 275)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(99, 22)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'dgvRoom
        '
        Me.dgvRoom.AllowUserToAddRows = False
        Me.dgvRoom.AllowUserToDeleteRows = False
        Me.dgvRoom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRoom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRoom.Location = New System.Drawing.Point(0, 0)
        Me.dgvRoom.Name = "dgvRoom"
        Me.dgvRoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRoom.Size = New System.Drawing.Size(383, 250)
        Me.dgvRoom.TabIndex = 0
        '
        'frmAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(419, 327)
        Me.Controls.Add(Me.gpRoom)
        Me.Controls.Add(Me.gpLogin)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAdmin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administrator Features"
        Me.gpLogin.ResumeLayout(False)
        Me.gpLogin.PerformLayout()
        Me.gpRoom.ResumeLayout(False)
        Me.pnlGrid.ResumeLayout(False)
        CType(Me.dgvRoom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblPwd As System.Windows.Forms.Label
    Friend WithEvents gpLogin As System.Windows.Forms.GroupBox
    Friend WithEvents txtPwd As System.Windows.Forms.TextBox
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents gpRoom As System.Windows.Forms.GroupBox
    Friend WithEvents pnlGrid As System.Windows.Forms.Panel
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents dgvRoom As System.Windows.Forms.DataGridView
End Class
