<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pnlLogo = New System.Windows.Forms.Panel()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.pnlExtend = New System.Windows.Forms.Panel()
        Me.lblEBalanceRM = New System.Windows.Forms.Label()
        Me.txtEBalance = New System.Windows.Forms.TextBox()
        Me.lblEBalance = New System.Windows.Forms.Label()
        Me.lblEPaidRM = New System.Windows.Forms.Label()
        Me.txtEPaid = New System.Windows.Forms.TextBox()
        Me.lblEPaid = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtEPrice = New System.Windows.Forms.TextBox()
        Me.txtEDays = New System.Windows.Forms.TextBox()
        Me.lblETotalPrice = New System.Windows.Forms.Label()
        Me.lblEExtendDay = New System.Windows.Forms.Label()
        Me.gpEDetail = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtEDeposit = New System.Windows.Forms.TextBox()
        Me.lblEDepositAmt = New System.Windows.Forms.Label()
        Me.txtEContact = New System.Windows.Forms.TextBox()
        Me.txtEIC = New System.Windows.Forms.TextBox()
        Me.txtEName = New System.Windows.Forms.TextBox()
        Me.lblEContact = New System.Windows.Forms.Label()
        Me.lblEIC = New System.Windows.Forms.Label()
        Me.lblEName = New System.Windows.Forms.Label()
        Me.btnEPrint = New System.Windows.Forms.Button()
        Me.btnEExtend = New System.Windows.Forms.Button()
        Me.cbERoom = New System.Windows.Forms.ComboBox()
        Me.lblERoomNo = New System.Windows.Forms.Label()
        Me.pnlLogBook = New System.Windows.Forms.Panel()
        Me.gpLogBookDisplay = New System.Windows.Forms.GroupBox()
        Me.chkLogM = New System.Windows.Forms.CheckBox()
        Me.chkLogCO = New System.Windows.Forms.CheckBox()
        Me.chkLogCI = New System.Windows.Forms.CheckBox()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.dtPicker = New System.Windows.Forms.DateTimePicker()
        Me.dgvLogBook = New System.Windows.Forms.DataGridView()
        Me.pnlCheckOut = New System.Windows.Forms.Panel()
        Me.gpDetail = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtDeposit = New System.Windows.Forms.TextBox()
        Me.lblDepositAmt = New System.Windows.Forms.Label()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.txtIC = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.lblContact = New System.Windows.Forms.Label()
        Me.lblIC = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnCOut = New System.Windows.Forms.Button()
        Me.cbRoom = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlCheckIn = New System.Windows.Forms.Panel()
        Me.gpCheckIn = New System.Windows.Forms.GroupBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnCPrint = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCDeposit = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCBal = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCPaid = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCTotPrice = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCDays = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbCRoomNo = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbCRoomType = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCCheckIn = New System.Windows.Forms.Button()
        Me.txtCAddr = New System.Windows.Forms.TextBox()
        Me.lblCAddr = New System.Windows.Forms.Label()
        Me.txtCContact = New System.Windows.Forms.TextBox()
        Me.txtCIC = New System.Windows.Forms.TextBox()
        Me.txtCName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCClear = New System.Windows.Forms.Button()
        Me.pnlMainMenu = New System.Windows.Forms.Panel()
        Me.btnExtend = New System.Windows.Forms.Button()
        Me.btnCheckIn = New System.Windows.Forms.Button()
        Me.btnCheckOut = New System.Windows.Forms.Button()
        Me.btnLog = New System.Windows.Forms.Button()
        Me.pnlSecond = New System.Windows.Forms.Panel()
        Me.dgvMaintenance = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Room = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Reason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Complete = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pnlHideAvailability = New System.Windows.Forms.Panel()
        Me.chkHideAvailability = New System.Windows.Forms.CheckBox()
        Me.gpMaintenance = New System.Windows.Forms.GroupBox()
        Me.btnMAdd = New System.Windows.Forms.Button()
        Me.cbMReason = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbMRoom = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Splitter = New System.Windows.Forms.Splitter()
        Me.pnlRoomAvailability = New System.Windows.Forms.Panel()
        Me.pnlMain.SuspendLayout()
        Me.pnlLogo.SuspendLayout()
        Me.pnlExtend.SuspendLayout()
        Me.gpEDetail.SuspendLayout()
        Me.pnlLogBook.SuspendLayout()
        Me.gpLogBookDisplay.SuspendLayout()
        CType(Me.dgvLogBook, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCheckOut.SuspendLayout()
        Me.gpDetail.SuspendLayout()
        Me.pnlCheckIn.SuspendLayout()
        Me.gpCheckIn.SuspendLayout()
        Me.pnlMainMenu.SuspendLayout()
        Me.pnlSecond.SuspendLayout()
        CType(Me.dgvMaintenance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHideAvailability.SuspendLayout()
        Me.gpMaintenance.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.Controls.Add(Me.pnlLogo)
        Me.pnlMain.Controls.Add(Me.pnlExtend)
        Me.pnlMain.Controls.Add(Me.pnlLogBook)
        Me.pnlMain.Controls.Add(Me.pnlCheckOut)
        Me.pnlMain.Controls.Add(Me.pnlCheckIn)
        Me.pnlMain.Controls.Add(Me.pnlMainMenu)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(608, 750)
        Me.pnlMain.TabIndex = 0
        '
        'pnlLogo
        '
        Me.pnlLogo.Controls.Add(Me.pnlRoomAvailability)
        Me.pnlLogo.Controls.Add(Me.btnBack)
        Me.pnlLogo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLogo.Location = New System.Drawing.Point(0, 558)
        Me.pnlLogo.Name = "pnlLogo"
        Me.pnlLogo.Size = New System.Drawing.Size(608, 192)
        Me.pnlLogo.TabIndex = 11
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.White
        Me.btnBack.Image = CType(resources.GetObject("btnBack.Image"), System.Drawing.Image)
        Me.btnBack.Location = New System.Drawing.Point(2, 6)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(142, 48)
        Me.btnBack.TabIndex = 7
        Me.btnBack.UseVisualStyleBackColor = False
        Me.btnBack.Visible = False
        '
        'pnlExtend
        '
        Me.pnlExtend.Controls.Add(Me.lblEBalanceRM)
        Me.pnlExtend.Controls.Add(Me.txtEBalance)
        Me.pnlExtend.Controls.Add(Me.lblEBalance)
        Me.pnlExtend.Controls.Add(Me.lblEPaidRM)
        Me.pnlExtend.Controls.Add(Me.txtEPaid)
        Me.pnlExtend.Controls.Add(Me.lblEPaid)
        Me.pnlExtend.Controls.Add(Me.Label22)
        Me.pnlExtend.Controls.Add(Me.txtEPrice)
        Me.pnlExtend.Controls.Add(Me.txtEDays)
        Me.pnlExtend.Controls.Add(Me.lblETotalPrice)
        Me.pnlExtend.Controls.Add(Me.lblEExtendDay)
        Me.pnlExtend.Controls.Add(Me.gpEDetail)
        Me.pnlExtend.Controls.Add(Me.btnEPrint)
        Me.pnlExtend.Controls.Add(Me.btnEExtend)
        Me.pnlExtend.Controls.Add(Me.cbERoom)
        Me.pnlExtend.Controls.Add(Me.lblERoomNo)
        Me.pnlExtend.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlExtend.Location = New System.Drawing.Point(0, 509)
        Me.pnlExtend.Name = "pnlExtend"
        Me.pnlExtend.Size = New System.Drawing.Size(608, 49)
        Me.pnlExtend.TabIndex = 12
        Me.pnlExtend.Visible = False
        '
        'lblEBalanceRM
        '
        Me.lblEBalanceRM.AutoSize = True
        Me.lblEBalanceRM.BackColor = System.Drawing.Color.Violet
        Me.lblEBalanceRM.Location = New System.Drawing.Point(107, 138)
        Me.lblEBalanceRM.Name = "lblEBalanceRM"
        Me.lblEBalanceRM.Size = New System.Drawing.Size(24, 13)
        Me.lblEBalanceRM.TabIndex = 33
        Me.lblEBalanceRM.Text = "RM"
        '
        'txtEBalance
        '
        Me.txtEBalance.Location = New System.Drawing.Point(137, 135)
        Me.txtEBalance.Name = "txtEBalance"
        Me.txtEBalance.ReadOnly = True
        Me.txtEBalance.Size = New System.Drawing.Size(137, 20)
        Me.txtEBalance.TabIndex = 29
        Me.txtEBalance.Text = "0.00"
        Me.txtEBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblEBalance
        '
        Me.lblEBalance.AutoSize = True
        Me.lblEBalance.Location = New System.Drawing.Point(24, 138)
        Me.lblEBalance.Name = "lblEBalance"
        Me.lblEBalance.Size = New System.Drawing.Size(52, 13)
        Me.lblEBalance.TabIndex = 32
        Me.lblEBalance.Text = "Balance :"
        '
        'lblEPaidRM
        '
        Me.lblEPaidRM.AutoSize = True
        Me.lblEPaidRM.BackColor = System.Drawing.Color.Lime
        Me.lblEPaidRM.Location = New System.Drawing.Point(107, 112)
        Me.lblEPaidRM.Name = "lblEPaidRM"
        Me.lblEPaidRM.Size = New System.Drawing.Size(24, 13)
        Me.lblEPaidRM.TabIndex = 31
        Me.lblEPaidRM.Text = "RM"
        '
        'txtEPaid
        '
        Me.txtEPaid.Location = New System.Drawing.Point(137, 109)
        Me.txtEPaid.Name = "txtEPaid"
        Me.txtEPaid.Size = New System.Drawing.Size(137, 20)
        Me.txtEPaid.TabIndex = 28
        Me.txtEPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblEPaid
        '
        Me.lblEPaid.AutoSize = True
        Me.lblEPaid.Location = New System.Drawing.Point(24, 112)
        Me.lblEPaid.Name = "lblEPaid"
        Me.lblEPaid.Size = New System.Drawing.Size(34, 13)
        Me.lblEPaid.TabIndex = 30
        Me.lblEPaid.Text = "Paid :"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Wheat
        Me.Label22.Location = New System.Drawing.Point(107, 86)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(24, 13)
        Me.Label22.TabIndex = 23
        Me.Label22.Text = "RM"
        '
        'txtEPrice
        '
        Me.txtEPrice.Location = New System.Drawing.Point(137, 83)
        Me.txtEPrice.Name = "txtEPrice"
        Me.txtEPrice.ReadOnly = True
        Me.txtEPrice.Size = New System.Drawing.Size(137, 20)
        Me.txtEPrice.TabIndex = 22
        Me.txtEPrice.Text = "0.00"
        Me.txtEPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEDays
        '
        Me.txtEDays.Location = New System.Drawing.Point(110, 52)
        Me.txtEDays.Name = "txtEDays"
        Me.txtEDays.Size = New System.Drawing.Size(47, 20)
        Me.txtEDays.TabIndex = 7
        Me.txtEDays.Text = "1"
        Me.txtEDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblETotalPrice
        '
        Me.lblETotalPrice.AutoSize = True
        Me.lblETotalPrice.Location = New System.Drawing.Point(24, 86)
        Me.lblETotalPrice.Name = "lblETotalPrice"
        Me.lblETotalPrice.Size = New System.Drawing.Size(64, 13)
        Me.lblETotalPrice.TabIndex = 6
        Me.lblETotalPrice.Text = "Total Price :"
        '
        'lblEExtendDay
        '
        Me.lblEExtendDay.AutoSize = True
        Me.lblEExtendDay.Location = New System.Drawing.Point(24, 55)
        Me.lblEExtendDay.Name = "lblEExtendDay"
        Me.lblEExtendDay.Size = New System.Drawing.Size(79, 13)
        Me.lblEExtendDay.TabIndex = 5
        Me.lblEExtendDay.Text = "Extend Day(s) :"
        '
        'gpEDetail
        '
        Me.gpEDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpEDetail.Controls.Add(Me.Label20)
        Me.gpEDetail.Controls.Add(Me.txtEDeposit)
        Me.gpEDetail.Controls.Add(Me.lblEDepositAmt)
        Me.gpEDetail.Controls.Add(Me.txtEContact)
        Me.gpEDetail.Controls.Add(Me.txtEIC)
        Me.gpEDetail.Controls.Add(Me.txtEName)
        Me.gpEDetail.Controls.Add(Me.lblEContact)
        Me.gpEDetail.Controls.Add(Me.lblEIC)
        Me.gpEDetail.Controls.Add(Me.lblEName)
        Me.gpEDetail.Location = New System.Drawing.Point(295, 10)
        Me.gpEDetail.Name = "gpEDetail"
        Me.gpEDetail.Size = New System.Drawing.Size(300, 36)
        Me.gpEDetail.TabIndex = 4
        Me.gpEDetail.TabStop = False
        Me.gpEDetail.Text = "Booking Details"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Red
        Me.Label20.Location = New System.Drawing.Point(107, 102)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(26, 13)
        Me.Label20.TabIndex = 8
        Me.Label20.Text = "RM"
        '
        'txtEDeposit
        '
        Me.txtEDeposit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEDeposit.Location = New System.Drawing.Point(134, 99)
        Me.txtEDeposit.Name = "txtEDeposit"
        Me.txtEDeposit.ReadOnly = True
        Me.txtEDeposit.Size = New System.Drawing.Size(160, 20)
        Me.txtEDeposit.TabIndex = 7
        '
        'lblEDepositAmt
        '
        Me.lblEDepositAmt.AutoSize = True
        Me.lblEDepositAmt.Location = New System.Drawing.Point(13, 102)
        Me.lblEDepositAmt.Name = "lblEDepositAmt"
        Me.lblEDepositAmt.Size = New System.Drawing.Size(88, 13)
        Me.lblEDepositAmt.TabIndex = 6
        Me.lblEDepositAmt.Text = "Deposit Amount :"
        '
        'txtEContact
        '
        Me.txtEContact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEContact.Location = New System.Drawing.Point(109, 73)
        Me.txtEContact.Name = "txtEContact"
        Me.txtEContact.ReadOnly = True
        Me.txtEContact.Size = New System.Drawing.Size(185, 20)
        Me.txtEContact.TabIndex = 5
        '
        'txtEIC
        '
        Me.txtEIC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEIC.Location = New System.Drawing.Point(109, 48)
        Me.txtEIC.Name = "txtEIC"
        Me.txtEIC.ReadOnly = True
        Me.txtEIC.Size = New System.Drawing.Size(185, 20)
        Me.txtEIC.TabIndex = 4
        '
        'txtEName
        '
        Me.txtEName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEName.Location = New System.Drawing.Point(109, 24)
        Me.txtEName.Name = "txtEName"
        Me.txtEName.ReadOnly = True
        Me.txtEName.Size = New System.Drawing.Size(185, 20)
        Me.txtEName.TabIndex = 3
        '
        'lblEContact
        '
        Me.lblEContact.AutoSize = True
        Me.lblEContact.Location = New System.Drawing.Point(13, 76)
        Me.lblEContact.Name = "lblEContact"
        Me.lblEContact.Size = New System.Drawing.Size(67, 13)
        Me.lblEContact.TabIndex = 2
        Me.lblEContact.Text = "Contact No :"
        '
        'lblEIC
        '
        Me.lblEIC.AutoSize = True
        Me.lblEIC.Location = New System.Drawing.Point(13, 51)
        Me.lblEIC.Name = "lblEIC"
        Me.lblEIC.Size = New System.Drawing.Size(84, 13)
        Me.lblEIC.TabIndex = 1
        Me.lblEIC.Text = "I/C or Passport :"
        '
        'lblEName
        '
        Me.lblEName.AutoSize = True
        Me.lblEName.Location = New System.Drawing.Point(13, 27)
        Me.lblEName.Name = "lblEName"
        Me.lblEName.Size = New System.Drawing.Size(41, 13)
        Me.lblEName.TabIndex = 0
        Me.lblEName.Text = "Name :"
        '
        'btnEPrint
        '
        Me.btnEPrint.Enabled = False
        Me.btnEPrint.Location = New System.Drawing.Point(166, 172)
        Me.btnEPrint.Name = "btnEPrint"
        Me.btnEPrint.Size = New System.Drawing.Size(108, 32)
        Me.btnEPrint.TabIndex = 3
        Me.btnEPrint.Text = "Print Receipt"
        Me.btnEPrint.UseVisualStyleBackColor = True
        Me.btnEPrint.Visible = False
        '
        'btnEExtend
        '
        Me.btnEExtend.Enabled = False
        Me.btnEExtend.Location = New System.Drawing.Point(27, 172)
        Me.btnEExtend.Name = "btnEExtend"
        Me.btnEExtend.Size = New System.Drawing.Size(108, 32)
        Me.btnEExtend.TabIndex = 2
        Me.btnEExtend.Text = "Extend"
        Me.btnEExtend.UseVisualStyleBackColor = True
        '
        'cbERoom
        '
        Me.cbERoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbERoom.FormattingEnabled = True
        Me.cbERoom.Location = New System.Drawing.Point(110, 20)
        Me.cbERoom.Name = "cbERoom"
        Me.cbERoom.Size = New System.Drawing.Size(164, 21)
        Me.cbERoom.TabIndex = 1
        '
        'lblERoomNo
        '
        Me.lblERoomNo.AutoSize = True
        Me.lblERoomNo.Location = New System.Drawing.Point(24, 23)
        Me.lblERoomNo.Name = "lblERoomNo"
        Me.lblERoomNo.Size = New System.Drawing.Size(58, 13)
        Me.lblERoomNo.TabIndex = 0
        Me.lblERoomNo.Text = "Room No :"
        '
        'pnlLogBook
        '
        Me.pnlLogBook.Controls.Add(Me.gpLogBookDisplay)
        Me.pnlLogBook.Controls.Add(Me.chkAll)
        Me.pnlLogBook.Controls.Add(Me.dtPicker)
        Me.pnlLogBook.Controls.Add(Me.dgvLogBook)
        Me.pnlLogBook.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlLogBook.Location = New System.Drawing.Point(0, 438)
        Me.pnlLogBook.Name = "pnlLogBook"
        Me.pnlLogBook.Size = New System.Drawing.Size(608, 71)
        Me.pnlLogBook.TabIndex = 10
        Me.pnlLogBook.Visible = False
        '
        'gpLogBookDisplay
        '
        Me.gpLogBookDisplay.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpLogBookDisplay.Controls.Add(Me.chkLogM)
        Me.gpLogBookDisplay.Controls.Add(Me.chkLogCO)
        Me.gpLogBookDisplay.Controls.Add(Me.chkLogCI)
        Me.gpLogBookDisplay.Location = New System.Drawing.Point(352, 4)
        Me.gpLogBookDisplay.Name = "gpLogBookDisplay"
        Me.gpLogBookDisplay.Size = New System.Drawing.Size(253, 38)
        Me.gpLogBookDisplay.TabIndex = 3
        Me.gpLogBookDisplay.TabStop = False
        Me.gpLogBookDisplay.Text = "Display Options"
        '
        'chkLogM
        '
        Me.chkLogM.AutoSize = True
        Me.chkLogM.Location = New System.Drawing.Point(221, 19)
        Me.chkLogM.Name = "chkLogM"
        Me.chkLogM.Size = New System.Drawing.Size(88, 17)
        Me.chkLogM.TabIndex = 2
        Me.chkLogM.Text = "Maintenance"
        Me.chkLogM.UseVisualStyleBackColor = True
        '
        'chkLogCO
        '
        Me.chkLogCO.AutoSize = True
        Me.chkLogCO.Location = New System.Drawing.Point(113, 19)
        Me.chkLogCO.Name = "chkLogCO"
        Me.chkLogCO.Size = New System.Drawing.Size(77, 17)
        Me.chkLogCO.TabIndex = 1
        Me.chkLogCO.Text = "Check Out"
        Me.chkLogCO.UseVisualStyleBackColor = True
        '
        'chkLogCI
        '
        Me.chkLogCI.AutoSize = True
        Me.chkLogCI.Checked = True
        Me.chkLogCI.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLogCI.Location = New System.Drawing.Point(18, 19)
        Me.chkLogCI.Name = "chkLogCI"
        Me.chkLogCI.Size = New System.Drawing.Size(69, 17)
        Me.chkLogCI.TabIndex = 0
        Me.chkLogCI.Text = "Check In"
        Me.chkLogCI.UseVisualStyleBackColor = True
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Location = New System.Drawing.Point(256, 14)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(91, 17)
        Me.chkAll.TabIndex = 2
        Me.chkAll.Text = "View all dates"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'dtPicker
        '
        Me.dtPicker.Location = New System.Drawing.Point(3, 11)
        Me.dtPicker.Name = "dtPicker"
        Me.dtPicker.Size = New System.Drawing.Size(238, 20)
        Me.dtPicker.TabIndex = 1
        '
        'dgvLogBook
        '
        Me.dgvLogBook.AllowUserToAddRows = False
        Me.dgvLogBook.AllowUserToDeleteRows = False
        Me.dgvLogBook.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLogBook.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvLogBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLogBook.Location = New System.Drawing.Point(2, 49)
        Me.dgvLogBook.Name = "dgvLogBook"
        Me.dgvLogBook.ReadOnly = True
        Me.dgvLogBook.Size = New System.Drawing.Size(604, 16)
        Me.dgvLogBook.TabIndex = 4
        '
        'pnlCheckOut
        '
        Me.pnlCheckOut.Controls.Add(Me.gpDetail)
        Me.pnlCheckOut.Controls.Add(Me.btnPrint)
        Me.pnlCheckOut.Controls.Add(Me.btnCOut)
        Me.pnlCheckOut.Controls.Add(Me.cbRoom)
        Me.pnlCheckOut.Controls.Add(Me.Label1)
        Me.pnlCheckOut.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCheckOut.Location = New System.Drawing.Point(0, 382)
        Me.pnlCheckOut.Name = "pnlCheckOut"
        Me.pnlCheckOut.Size = New System.Drawing.Size(608, 56)
        Me.pnlCheckOut.TabIndex = 9
        Me.pnlCheckOut.Visible = False
        '
        'gpDetail
        '
        Me.gpDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpDetail.Controls.Add(Me.Label17)
        Me.gpDetail.Controls.Add(Me.txtDeposit)
        Me.gpDetail.Controls.Add(Me.lblDepositAmt)
        Me.gpDetail.Controls.Add(Me.txtContact)
        Me.gpDetail.Controls.Add(Me.txtIC)
        Me.gpDetail.Controls.Add(Me.txtName)
        Me.gpDetail.Controls.Add(Me.lblContact)
        Me.gpDetail.Controls.Add(Me.lblIC)
        Me.gpDetail.Controls.Add(Me.lblName)
        Me.gpDetail.Location = New System.Drawing.Point(295, 10)
        Me.gpDetail.Name = "gpDetail"
        Me.gpDetail.Size = New System.Drawing.Size(300, 43)
        Me.gpDetail.TabIndex = 4
        Me.gpDetail.TabStop = False
        Me.gpDetail.Text = "Booking Details"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Red
        Me.Label17.Location = New System.Drawing.Point(107, 102)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(26, 13)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "RM"
        '
        'txtDeposit
        '
        Me.txtDeposit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDeposit.Location = New System.Drawing.Point(134, 99)
        Me.txtDeposit.Name = "txtDeposit"
        Me.txtDeposit.ReadOnly = True
        Me.txtDeposit.Size = New System.Drawing.Size(160, 20)
        Me.txtDeposit.TabIndex = 7
        '
        'lblDepositAmt
        '
        Me.lblDepositAmt.AutoSize = True
        Me.lblDepositAmt.Location = New System.Drawing.Point(13, 102)
        Me.lblDepositAmt.Name = "lblDepositAmt"
        Me.lblDepositAmt.Size = New System.Drawing.Size(88, 13)
        Me.lblDepositAmt.TabIndex = 6
        Me.lblDepositAmt.Text = "Deposit Amount :"
        '
        'txtContact
        '
        Me.txtContact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContact.Location = New System.Drawing.Point(109, 73)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.ReadOnly = True
        Me.txtContact.Size = New System.Drawing.Size(185, 20)
        Me.txtContact.TabIndex = 5
        '
        'txtIC
        '
        Me.txtIC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIC.Location = New System.Drawing.Point(109, 48)
        Me.txtIC.Name = "txtIC"
        Me.txtIC.ReadOnly = True
        Me.txtIC.Size = New System.Drawing.Size(185, 20)
        Me.txtIC.TabIndex = 4
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(109, 24)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(185, 20)
        Me.txtName.TabIndex = 3
        '
        'lblContact
        '
        Me.lblContact.AutoSize = True
        Me.lblContact.Location = New System.Drawing.Point(13, 76)
        Me.lblContact.Name = "lblContact"
        Me.lblContact.Size = New System.Drawing.Size(67, 13)
        Me.lblContact.TabIndex = 2
        Me.lblContact.Text = "Contact No :"
        '
        'lblIC
        '
        Me.lblIC.AutoSize = True
        Me.lblIC.Location = New System.Drawing.Point(13, 51)
        Me.lblIC.Name = "lblIC"
        Me.lblIC.Size = New System.Drawing.Size(84, 13)
        Me.lblIC.TabIndex = 1
        Me.lblIC.Text = "I/C or Passport :"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(13, 27)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(41, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Name :"
        '
        'btnPrint
        '
        Me.btnPrint.Enabled = False
        Me.btnPrint.Location = New System.Drawing.Point(166, 59)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(108, 32)
        Me.btnPrint.TabIndex = 3
        Me.btnPrint.Text = "Print Receipt"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnCOut
        '
        Me.btnCOut.Enabled = False
        Me.btnCOut.Location = New System.Drawing.Point(27, 59)
        Me.btnCOut.Name = "btnCOut"
        Me.btnCOut.Size = New System.Drawing.Size(108, 32)
        Me.btnCOut.TabIndex = 2
        Me.btnCOut.Text = "Check Out"
        Me.btnCOut.UseVisualStyleBackColor = True
        '
        'cbRoom
        '
        Me.cbRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRoom.FormattingEnabled = True
        Me.cbRoom.Location = New System.Drawing.Point(88, 20)
        Me.cbRoom.Name = "cbRoom"
        Me.cbRoom.Size = New System.Drawing.Size(186, 21)
        Me.cbRoom.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Room No :"
        '
        'pnlCheckIn
        '
        Me.pnlCheckIn.Controls.Add(Me.gpCheckIn)
        Me.pnlCheckIn.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCheckIn.Location = New System.Drawing.Point(0, 350)
        Me.pnlCheckIn.Name = "pnlCheckIn"
        Me.pnlCheckIn.Size = New System.Drawing.Size(608, 32)
        Me.pnlCheckIn.TabIndex = 8
        Me.pnlCheckIn.Visible = False
        '
        'gpCheckIn
        '
        Me.gpCheckIn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpCheckIn.Controls.Add(Me.btnRefresh)
        Me.gpCheckIn.Controls.Add(Me.btnCPrint)
        Me.gpCheckIn.Controls.Add(Me.Label18)
        Me.gpCheckIn.Controls.Add(Me.txtCDeposit)
        Me.gpCheckIn.Controls.Add(Me.Label19)
        Me.gpCheckIn.Controls.Add(Me.Label12)
        Me.gpCheckIn.Controls.Add(Me.txtCBal)
        Me.gpCheckIn.Controls.Add(Me.Label13)
        Me.gpCheckIn.Controls.Add(Me.Label10)
        Me.gpCheckIn.Controls.Add(Me.txtCPaid)
        Me.gpCheckIn.Controls.Add(Me.Label11)
        Me.gpCheckIn.Controls.Add(Me.Label9)
        Me.gpCheckIn.Controls.Add(Me.txtCTotPrice)
        Me.gpCheckIn.Controls.Add(Me.Label8)
        Me.gpCheckIn.Controls.Add(Me.txtCDays)
        Me.gpCheckIn.Controls.Add(Me.Label7)
        Me.gpCheckIn.Controls.Add(Me.cbCRoomNo)
        Me.gpCheckIn.Controls.Add(Me.Label6)
        Me.gpCheckIn.Controls.Add(Me.cbCRoomType)
        Me.gpCheckIn.Controls.Add(Me.Label5)
        Me.gpCheckIn.Controls.Add(Me.btnCCheckIn)
        Me.gpCheckIn.Controls.Add(Me.txtCAddr)
        Me.gpCheckIn.Controls.Add(Me.lblCAddr)
        Me.gpCheckIn.Controls.Add(Me.txtCContact)
        Me.gpCheckIn.Controls.Add(Me.txtCIC)
        Me.gpCheckIn.Controls.Add(Me.txtCName)
        Me.gpCheckIn.Controls.Add(Me.Label2)
        Me.gpCheckIn.Controls.Add(Me.Label3)
        Me.gpCheckIn.Controls.Add(Me.Label4)
        Me.gpCheckIn.Controls.Add(Me.btnCClear)
        Me.gpCheckIn.Location = New System.Drawing.Point(25, 12)
        Me.gpCheckIn.Name = "gpCheckIn"
        Me.gpCheckIn.Size = New System.Drawing.Size(562, 16)
        Me.gpCheckIn.TabIndex = 0
        Me.gpCheckIn.TabStop = False
        Me.gpCheckIn.Text = "Check-In Details"
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.Location = New System.Drawing.Point(525, 16)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(25, 25)
        Me.btnRefresh.TabIndex = 2
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnCPrint
        '
        Me.btnCPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCPrint.Enabled = False
        Me.btnCPrint.Location = New System.Drawing.Point(404, 286)
        Me.btnCPrint.Name = "btnCPrint"
        Me.btnCPrint.Size = New System.Drawing.Size(117, 40)
        Me.btnCPrint.TabIndex = 22
        Me.btnCPrint.Text = "Print Details"
        Me.btnCPrint.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Gold
        Me.Label18.Location = New System.Drawing.Point(123, 75)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(24, 13)
        Me.Label18.TabIndex = 30
        Me.Label18.Text = "RM"
        '
        'txtCDeposit
        '
        Me.txtCDeposit.Location = New System.Drawing.Point(149, 72)
        Me.txtCDeposit.Name = "txtCDeposit"
        Me.txtCDeposit.Size = New System.Drawing.Size(127, 20)
        Me.txtCDeposit.TabIndex = 4
        Me.txtCDeposit.Text = "0"
        Me.txtCDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(28, 75)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(88, 13)
        Me.Label19.TabIndex = 29
        Me.Label19.Text = "Deposit Amount :"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Violet
        Me.Label12.Location = New System.Drawing.Point(119, 311)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 13)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "RM"
        '
        'txtCBal
        '
        Me.txtCBal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCBal.Location = New System.Drawing.Point(145, 308)
        Me.txtCBal.Name = "txtCBal"
        Me.txtCBal.ReadOnly = True
        Me.txtCBal.Size = New System.Drawing.Size(127, 20)
        Me.txtCBal.TabIndex = 10
        Me.txtCBal.Text = "0.00"
        Me.txtCBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(61, 311)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 13)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Balance :"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Lime
        Me.Label10.Location = New System.Drawing.Point(119, 286)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 13)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "RM"
        '
        'txtCPaid
        '
        Me.txtCPaid.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCPaid.Location = New System.Drawing.Point(145, 283)
        Me.txtCPaid.Name = "txtCPaid"
        Me.txtCPaid.Size = New System.Drawing.Size(127, 20)
        Me.txtCPaid.TabIndex = 9
        Me.txtCPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(79, 286)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Paid :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Wheat
        Me.Label9.Location = New System.Drawing.Point(123, 98)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "RM"
        '
        'txtCTotPrice
        '
        Me.txtCTotPrice.Location = New System.Drawing.Point(149, 95)
        Me.txtCTotPrice.Name = "txtCTotPrice"
        Me.txtCTotPrice.ReadOnly = True
        Me.txtCTotPrice.Size = New System.Drawing.Size(127, 20)
        Me.txtCTotPrice.TabIndex = 4
        Me.txtCTotPrice.Text = "0.00"
        Me.txtCTotPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(28, 98)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Total Price :"
        '
        'txtCDays
        '
        Me.txtCDays.Location = New System.Drawing.Point(124, 47)
        Me.txtCDays.Name = "txtCDays"
        Me.txtCDays.Size = New System.Drawing.Size(47, 20)
        Me.txtCDays.TabIndex = 3
        Me.txtCDays.Text = "1"
        Me.txtCDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(28, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "No of Day(s) :"
        '
        'cbCRoomNo
        '
        Me.cbCRoomNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbCRoomNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCRoomNo.FormattingEnabled = True
        Me.cbCRoomNo.Location = New System.Drawing.Point(379, 18)
        Me.cbCRoomNo.Name = "cbCRoomNo"
        Me.cbCRoomNo.Size = New System.Drawing.Size(142, 21)
        Me.cbCRoomNo.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(311, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Room No :"
        '
        'cbCRoomType
        '
        Me.cbCRoomType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbCRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCRoomType.FormattingEnabled = True
        Me.cbCRoomType.Location = New System.Drawing.Point(124, 18)
        Me.cbCRoomType.Name = "cbCRoomType"
        Me.cbCRoomType.Size = New System.Drawing.Size(176, 21)
        Me.cbCRoomType.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Room Type :"
        '
        'btnCCheckIn
        '
        Me.btnCCheckIn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCCheckIn.Enabled = False
        Me.btnCCheckIn.Location = New System.Drawing.Point(278, 286)
        Me.btnCCheckIn.Name = "btnCCheckIn"
        Me.btnCCheckIn.Size = New System.Drawing.Size(125, 40)
        Me.btnCCheckIn.TabIndex = 20
        Me.btnCCheckIn.Text = "Check In"
        Me.btnCCheckIn.UseVisualStyleBackColor = True
        '
        'txtCAddr
        '
        Me.txtCAddr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCAddr.Location = New System.Drawing.Point(124, 196)
        Me.txtCAddr.Multiline = True
        Me.txtCAddr.Name = "txtCAddr"
        Me.txtCAddr.Size = New System.Drawing.Size(397, 81)
        Me.txtCAddr.TabIndex = 8
        '
        'lblCAddr
        '
        Me.lblCAddr.AutoSize = True
        Me.lblCAddr.Location = New System.Drawing.Point(28, 199)
        Me.lblCAddr.Name = "lblCAddr"
        Me.lblCAddr.Size = New System.Drawing.Size(51, 13)
        Me.lblCAddr.TabIndex = 12
        Me.lblCAddr.Text = "Address :"
        '
        'txtCContact
        '
        Me.txtCContact.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCContact.Location = New System.Drawing.Point(124, 169)
        Me.txtCContact.Name = "txtCContact"
        Me.txtCContact.Size = New System.Drawing.Size(397, 20)
        Me.txtCContact.TabIndex = 7
        '
        'txtCIC
        '
        Me.txtCIC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCIC.Location = New System.Drawing.Point(124, 144)
        Me.txtCIC.Name = "txtCIC"
        Me.txtCIC.Size = New System.Drawing.Size(397, 20)
        Me.txtCIC.TabIndex = 6
        '
        'txtCName
        '
        Me.txtCName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCName.Location = New System.Drawing.Point(124, 120)
        Me.txtCName.Name = "txtCName"
        Me.txtCName.Size = New System.Drawing.Size(397, 20)
        Me.txtCName.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 172)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Contact No :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "I/C or Passport :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Name :"
        '
        'btnCClear
        '
        Me.btnCClear.Location = New System.Drawing.Point(31, 286)
        Me.btnCClear.Name = "btnCClear"
        Me.btnCClear.Size = New System.Drawing.Size(125, 40)
        Me.btnCClear.TabIndex = 31
        Me.btnCClear.Text = "Clear All"
        Me.btnCClear.UseVisualStyleBackColor = True
        '
        'pnlMainMenu
        '
        Me.pnlMainMenu.Controls.Add(Me.btnExtend)
        Me.pnlMainMenu.Controls.Add(Me.btnCheckIn)
        Me.pnlMainMenu.Controls.Add(Me.btnCheckOut)
        Me.pnlMainMenu.Controls.Add(Me.btnLog)
        Me.pnlMainMenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMainMenu.Location = New System.Drawing.Point(0, 0)
        Me.pnlMainMenu.Name = "pnlMainMenu"
        Me.pnlMainMenu.Size = New System.Drawing.Size(608, 350)
        Me.pnlMainMenu.TabIndex = 7
        '
        'btnExtend
        '
        Me.btnExtend.BackColor = System.Drawing.Color.White
        Me.btnExtend.Image = CType(resources.GetObject("btnExtend.Image"), System.Drawing.Image)
        Me.btnExtend.Location = New System.Drawing.Point(2, 158)
        Me.btnExtend.Name = "btnExtend"
        Me.btnExtend.Size = New System.Drawing.Size(311, 134)
        Me.btnExtend.TabIndex = 6
        Me.btnExtend.UseVisualStyleBackColor = False
        '
        'btnCheckIn
        '
        Me.btnCheckIn.BackColor = System.Drawing.Color.White
        Me.btnCheckIn.Image = CType(resources.GetObject("btnCheckIn.Image"), System.Drawing.Image)
        Me.btnCheckIn.Location = New System.Drawing.Point(2, 18)
        Me.btnCheckIn.Name = "btnCheckIn"
        Me.btnCheckIn.Size = New System.Drawing.Size(311, 134)
        Me.btnCheckIn.TabIndex = 3
        Me.btnCheckIn.UseVisualStyleBackColor = False
        '
        'btnCheckOut
        '
        Me.btnCheckOut.BackColor = System.Drawing.Color.White
        Me.btnCheckOut.Image = CType(resources.GetObject("btnCheckOut.Image"), System.Drawing.Image)
        Me.btnCheckOut.Location = New System.Drawing.Point(295, 18)
        Me.btnCheckOut.Name = "btnCheckOut"
        Me.btnCheckOut.Size = New System.Drawing.Size(311, 134)
        Me.btnCheckOut.TabIndex = 4
        Me.btnCheckOut.UseVisualStyleBackColor = False
        '
        'btnLog
        '
        Me.btnLog.BackColor = System.Drawing.Color.White
        Me.btnLog.Image = CType(resources.GetObject("btnLog.Image"), System.Drawing.Image)
        Me.btnLog.Location = New System.Drawing.Point(295, 157)
        Me.btnLog.Name = "btnLog"
        Me.btnLog.Size = New System.Drawing.Size(311, 134)
        Me.btnLog.TabIndex = 5
        Me.btnLog.UseVisualStyleBackColor = False
        '
        'pnlSecond
        '
        Me.pnlSecond.Controls.Add(Me.dgvMaintenance)
        Me.pnlSecond.Controls.Add(Me.pnlHideAvailability)
        Me.pnlSecond.Controls.Add(Me.gpMaintenance)
        Me.pnlSecond.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlSecond.Location = New System.Drawing.Point(618, 0)
        Me.pnlSecond.Name = "pnlSecond"
        Me.pnlSecond.Size = New System.Drawing.Size(250, 750)
        Me.pnlSecond.TabIndex = 1
        '
        'dgvMaintenance
        '
        Me.dgvMaintenance.AllowUserToAddRows = False
        Me.dgvMaintenance.AllowUserToDeleteRows = False
        Me.dgvMaintenance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMaintenance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMaintenance.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Room, Me.Reason, Me.Complete})
        Me.dgvMaintenance.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMaintenance.Location = New System.Drawing.Point(0, 0)
        Me.dgvMaintenance.Name = "dgvMaintenance"
        Me.dgvMaintenance.RowHeadersVisible = False
        Me.dgvMaintenance.Size = New System.Drawing.Size(250, 590)
        Me.dgvMaintenance.TabIndex = 0
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'Room
        '
        Me.Room.HeaderText = "Room"
        Me.Room.Name = "Room"
        Me.Room.ReadOnly = True
        '
        'Reason
        '
        Me.Reason.HeaderText = "Reason"
        Me.Reason.Name = "Reason"
        Me.Reason.ReadOnly = True
        '
        'Complete
        '
        Me.Complete.HeaderText = "Complete"
        Me.Complete.Name = "Complete"
        '
        'pnlHideAvailability
        '
        Me.pnlHideAvailability.Controls.Add(Me.chkHideAvailability)
        Me.pnlHideAvailability.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlHideAvailability.Location = New System.Drawing.Point(0, 590)
        Me.pnlHideAvailability.Name = "pnlHideAvailability"
        Me.pnlHideAvailability.Size = New System.Drawing.Size(250, 31)
        Me.pnlHideAvailability.TabIndex = 0
        '
        'chkHideAvailability
        '
        Me.chkHideAvailability.AutoSize = True
        Me.chkHideAvailability.Checked = True
        Me.chkHideAvailability.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkHideAvailability.Location = New System.Drawing.Point(6, 8)
        Me.chkHideAvailability.Name = "chkHideAvailability"
        Me.chkHideAvailability.Size = New System.Drawing.Size(131, 17)
        Me.chkHideAvailability.TabIndex = 0
        Me.chkHideAvailability.Text = "Hide Room Availability"
        Me.chkHideAvailability.UseVisualStyleBackColor = True
        '
        'gpMaintenance
        '
        Me.gpMaintenance.Controls.Add(Me.btnMAdd)
        Me.gpMaintenance.Controls.Add(Me.cbMReason)
        Me.gpMaintenance.Controls.Add(Me.Label15)
        Me.gpMaintenance.Controls.Add(Me.cbMRoom)
        Me.gpMaintenance.Controls.Add(Me.Label14)
        Me.gpMaintenance.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gpMaintenance.Location = New System.Drawing.Point(0, 621)
        Me.gpMaintenance.Name = "gpMaintenance"
        Me.gpMaintenance.Size = New System.Drawing.Size(250, 129)
        Me.gpMaintenance.TabIndex = 1
        Me.gpMaintenance.TabStop = False
        Me.gpMaintenance.Text = "Room Maintenance"
        '
        'btnMAdd
        '
        Me.btnMAdd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMAdd.Location = New System.Drawing.Point(14, 82)
        Me.btnMAdd.Name = "btnMAdd"
        Me.btnMAdd.Size = New System.Drawing.Size(213, 37)
        Me.btnMAdd.TabIndex = 6
        Me.btnMAdd.Text = "Add to List"
        Me.btnMAdd.UseVisualStyleBackColor = True
        '
        'cbMReason
        '
        Me.cbMReason.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbMReason.FormattingEnabled = True
        Me.cbMReason.Location = New System.Drawing.Point(80, 52)
        Me.cbMReason.Name = "cbMReason"
        Me.cbMReason.Size = New System.Drawing.Size(147, 21)
        Me.cbMReason.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(11, 55)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(50, 13)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Reason :"
        '
        'cbMRoom
        '
        Me.cbMRoom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbMRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMRoom.FormattingEnabled = True
        Me.cbMRoom.Location = New System.Drawing.Point(80, 23)
        Me.cbMRoom.Name = "cbMRoom"
        Me.cbMRoom.Size = New System.Drawing.Size(147, 21)
        Me.cbMRoom.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(11, 26)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Room No :"
        '
        'Splitter
        '
        Me.Splitter.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Splitter.Dock = System.Windows.Forms.DockStyle.Right
        Me.Splitter.Location = New System.Drawing.Point(608, 0)
        Me.Splitter.Name = "Splitter"
        Me.Splitter.Size = New System.Drawing.Size(10, 750)
        Me.Splitter.TabIndex = 2
        Me.Splitter.TabStop = False
        '
        'pnlRoomAvailability
        '
        Me.pnlRoomAvailability.Location = New System.Drawing.Point(187, 63)
        Me.pnlRoomAvailability.Name = "pnlRoomAvailability"
        Me.pnlRoomAvailability.Size = New System.Drawing.Size(301, 56)
        Me.pnlRoomAvailability.TabIndex = 8
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 750)
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.Splitter)
        Me.Controls.Add(Me.pnlSecond)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "SRI SENA - Hotel Management System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlMain.ResumeLayout(False)
        Me.pnlLogo.ResumeLayout(False)
        Me.pnlExtend.ResumeLayout(False)
        Me.pnlExtend.PerformLayout()
        Me.gpEDetail.ResumeLayout(False)
        Me.gpEDetail.PerformLayout()
        Me.pnlLogBook.ResumeLayout(False)
        Me.pnlLogBook.PerformLayout()
        Me.gpLogBookDisplay.ResumeLayout(False)
        Me.gpLogBookDisplay.PerformLayout()
        CType(Me.dgvLogBook, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCheckOut.ResumeLayout(False)
        Me.pnlCheckOut.PerformLayout()
        Me.gpDetail.ResumeLayout(False)
        Me.gpDetail.PerformLayout()
        Me.pnlCheckIn.ResumeLayout(False)
        Me.gpCheckIn.ResumeLayout(False)
        Me.gpCheckIn.PerformLayout()
        Me.pnlMainMenu.ResumeLayout(False)
        Me.pnlSecond.ResumeLayout(False)
        CType(Me.dgvMaintenance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHideAvailability.ResumeLayout(False)
        Me.pnlHideAvailability.PerformLayout()
        Me.gpMaintenance.ResumeLayout(False)
        Me.gpMaintenance.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Friend WithEvents btnLog As System.Windows.Forms.Button
    Friend WithEvents btnCheckOut As System.Windows.Forms.Button
    Friend WithEvents btnCheckIn As System.Windows.Forms.Button
    Friend WithEvents pnlSecond As System.Windows.Forms.Panel
    Friend WithEvents Splitter As System.Windows.Forms.Splitter
    Friend WithEvents dgvMaintenance As System.Windows.Forms.DataGridView
    Friend WithEvents gpMaintenance As System.Windows.Forms.GroupBox
    Friend WithEvents pnlMainMenu As System.Windows.Forms.Panel
    Friend WithEvents pnlLogBook As System.Windows.Forms.Panel
    Friend WithEvents pnlCheckOut As System.Windows.Forms.Panel
    Friend WithEvents pnlCheckIn As System.Windows.Forms.Panel
    Friend WithEvents pnlLogo As System.Windows.Forms.Panel
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents dgvLogBook As System.Windows.Forms.DataGridView
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents dtPicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnCOut As System.Windows.Forms.Button
    Friend WithEvents cbRoom As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gpDetail As System.Windows.Forms.GroupBox
    Friend WithEvents txtContact As System.Windows.Forms.TextBox
    Friend WithEvents txtIC As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblContact As System.Windows.Forms.Label
    Friend WithEvents lblIC As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents gpCheckIn As System.Windows.Forms.GroupBox
    Friend WithEvents txtCAddr As System.Windows.Forms.TextBox
    Friend WithEvents lblCAddr As System.Windows.Forms.Label
    Friend WithEvents txtCContact As System.Windows.Forms.TextBox
    Friend WithEvents txtCIC As System.Windows.Forms.TextBox
    Friend WithEvents txtCName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbCRoomNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbCRoomType As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnCCheckIn As System.Windows.Forms.Button
    Friend WithEvents txtCDays As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCTotPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCBal As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCPaid As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnMAdd As System.Windows.Forms.Button
    Friend WithEvents cbMReason As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbMRoom As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Room As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Complete As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtDeposit As System.Windows.Forms.TextBox
    Friend WithEvents lblDepositAmt As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtCDeposit As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnCPrint As System.Windows.Forms.Button
    Friend WithEvents btnCClear As System.Windows.Forms.Button
    Friend WithEvents pnlHideAvailability As System.Windows.Forms.Panel
    Friend WithEvents chkHideAvailability As System.Windows.Forms.CheckBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents gpLogBookDisplay As System.Windows.Forms.GroupBox
    Friend WithEvents chkLogCO As System.Windows.Forms.CheckBox
    Friend WithEvents chkLogCI As System.Windows.Forms.CheckBox
    Friend WithEvents chkLogM As System.Windows.Forms.CheckBox
    Friend WithEvents btnExtend As System.Windows.Forms.Button
    Friend WithEvents pnlExtend As System.Windows.Forms.Panel
    Friend WithEvents gpEDetail As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtEDeposit As System.Windows.Forms.TextBox
    Friend WithEvents lblEDepositAmt As System.Windows.Forms.Label
    Friend WithEvents txtEContact As System.Windows.Forms.TextBox
    Friend WithEvents txtEIC As System.Windows.Forms.TextBox
    Friend WithEvents txtEName As System.Windows.Forms.TextBox
    Friend WithEvents lblEContact As System.Windows.Forms.Label
    Friend WithEvents lblEIC As System.Windows.Forms.Label
    Friend WithEvents lblEName As System.Windows.Forms.Label
    Friend WithEvents btnEPrint As System.Windows.Forms.Button
    Friend WithEvents btnEExtend As System.Windows.Forms.Button
    Friend WithEvents cbERoom As System.Windows.Forms.ComboBox
    Friend WithEvents lblERoomNo As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtEPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtEDays As System.Windows.Forms.TextBox
    Friend WithEvents lblETotalPrice As System.Windows.Forms.Label
    Friend WithEvents lblEExtendDay As System.Windows.Forms.Label
    Friend WithEvents lblEBalanceRM As System.Windows.Forms.Label
    Friend WithEvents txtEBalance As System.Windows.Forms.TextBox
    Friend WithEvents lblEBalance As System.Windows.Forms.Label
    Friend WithEvents lblEPaidRM As System.Windows.Forms.Label
    Friend WithEvents txtEPaid As System.Windows.Forms.TextBox
    Friend WithEvents lblEPaid As System.Windows.Forms.Label
    Friend WithEvents pnlRoomAvailability As System.Windows.Forms.Panel

End Class
