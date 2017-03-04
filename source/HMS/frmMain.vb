Imports System.Configuration
Imports System.Threading.Tasks

Public Class frmMain
    Private _xEnlarge As Integer
    Private _xEnlargeByTwo As Integer
    Private _CheckInBLL As BLL.CheckInBLL = Nothing
    Private _CheckOutBLL As BLL.CheckOutBLL = Nothing
    Private _ExtendBLL As BLL.ExtendBLL = Nothing
    Private _LogBLL As BLL.LogBLL = Nothing
    Private _MaintenanceBLL As BLL.MaintenanceBLL = Nothing
    Private _MaintenanceID As ULong = 0
    Private canReloadAvailability As Boolean = False
    Private Const _buildRoomXStartGap As Integer = 5
    Private Const _buildRoomYStartGap As Integer = 5
    Private Const _buildRoomXGap As Integer = 5
    Private Const _buildRoomYGap As Integer = 15
    Private Const _buildRoomWidth As Integer = 85
    Private Const _buildRoomHeight As Integer = 80

#Region "Form Load"
    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        _CheckInBLL = New BLL.CheckInBLL(ConfigurationManager.ConnectionStrings("DBConnection").ConnectionString)
        _CheckOutBLL = New BLL.CheckOutBLL(ConfigurationManager.ConnectionStrings("DBConnection").ConnectionString)
        _ExtendBLL = New BLL.ExtendBLL(ConfigurationManager.ConnectionStrings("DBConnection").ConnectionString)
        _LogBLL = New BLL.LogBLL(ConfigurationManager.ConnectionStrings("DBConnection").ConnectionString)
        _MaintenanceBLL = New BLL.MaintenanceBLL(ConfigurationManager.ConnectionStrings("DBConnection").ConnectionString)
        _MaintenanceBLL.ExecuteNonQuery_Update_V1()
        PopulateMaintenance()
        PopulateMaintenanceGrid()
        BuildRoomAvailability(False)
        canReloadAvailability = True

    End Sub
#End Region

#Region "Main Menu"
    Protected Overrides Function ProcessKeyPreview(ByRef m As System.Windows.Forms.Message) As Boolean
        If m.Msg = &H100 Then
            Dim key As Keys = m.WParam
            If key = Keys.A And My.Computer.Keyboard.CtrlKeyDown Then
                Dim frmAdmin As New frmAdmin
                frmAdmin.ShowDialog()
                Return True
            End If
        End If
        Return MyBase.ProcessKeyPreview(m)
    End Function

    Private Sub pnlMainMenu_Resize(sender As System.Object, e As System.EventArgs) Handles pnlMainMenu.Resize
        _xEnlarge = (pnlMainMenu.Width - 12)
        _xEnlargeByTwo = _xEnlarge / 2
        btnCheckIn.Width = _xEnlargeByTwo
        btnExtend.Width = btnCheckIn.Width
        btnCheckOut.Width = _xEnlarge - _xEnlargeByTwo
        btnCheckOut.Left = btnCheckIn.Right + 2
        btnLog.Width = btnCheckOut.Width
        btnLog.Left = btnCheckOut.Left
        If canReloadAvailability AndAlso pnlMainMenu.Visible Then
            BuildRoomAvailability()
        End If
    End Sub

    Private Sub btnCheckIn_Click(sender As System.Object, e As System.EventArgs) Handles btnCheckIn.Click
        pnlRoomAvailability.Visible = False
        pnlMainMenu.Visible = False
        pnlCheckIn.Visible = True
        pnlCheckIn.Height = pnlMainMenu.Height
        btnBack.Visible = True
    End Sub

    Private Sub btnCheckOut_Click(sender As System.Object, e As System.EventArgs) Handles btnCheckOut.Click
        pnlRoomAvailability.Visible = False
        pnlMainMenu.Visible = False
        pnlCheckOut.Visible = True
        pnlCheckOut.Height = pnlMainMenu.Height
        btnBack.Visible = True
    End Sub

    Private Sub btnExtend_Click(sender As System.Object, e As System.EventArgs) Handles btnExtend.Click
        pnlRoomAvailability.Visible = False
        pnlMainMenu.Visible = False
        pnlExtend.Visible = True
        pnlExtend.Height = pnlMainMenu.Height
        btnBack.Visible = True
    End Sub

    Private Sub btnLog_Click(sender As System.Object, e As System.EventArgs) Handles btnLog.Click
        pnlRoomAvailability.Visible = False
        pnlMainMenu.Visible = False
        pnlLogBook.Visible = True
        pnlLogBook.Height = pnlMainMenu.Height
        btnBack.Visible = True
    End Sub

    Private Delegate Sub ReBuildRoomAvailability(ByVal canUpdateRoom As Boolean)
    Private Sub BuildRoomAvailability(Optional ByVal canUpdateRoom As Boolean = True)
        If Me.InvokeRequired Then
            Dim rebuildRoomAvail As New ReBuildRoomAvailability(AddressOf BuildRoomAvailability)
            Me.Invoke(rebuildRoomAvail, New Object() {canUpdateRoom})
            Exit Sub
        End If
        If canUpdateRoom Then
            _MaintenanceBLL.GetRooms()
        End If
        pnlRoomAvailability.Visible = True
        pnlRoomAvailability.Dock = DockStyle.Fill
        ClearBuildRoom()
        Dim roomLevel As Integer = 0
        For Each roomPair As KeyValuePair(Of String, Integer) In _MaintenanceBLL.RoomLevel.OrderBy(Function(x) x.Value)
            Dim objRoom As New uiRoomControl
            Dim xPos As Integer = 0
            Dim yPos As Integer = 0
            objRoom.Width = _buildRoomWidth
            objRoom.Height = _buildRoomHeight
            pnlRoomAvailability.Controls.Add(objRoom)
            objRoom.lblRoomNo.Text = roomPair.Key
            objRoom.lblRoomType.Text = _MaintenanceBLL.ListRooms(roomPair.Key)
            If _MaintenanceBLL.RoomAvailability.Item(roomPair.Key) Then
                objRoom.roomType.FillColor = Color.Red
            ElseIf HasMaintenance(roomPair.Key) Then
                objRoom.roomType.FillColor = Color.DarkGray
            End If
            If roomLevel > 0 AndAlso roomLevel < roomPair.Value Then
                GetBuildRoomNextPosition(xPos, yPos, True)
            Else
                GetBuildRoomNextPosition(xPos, yPos)
            End If
            roomLevel = roomPair.Value
            objRoom.Left = xPos
            objRoom.Top = yPos
        Next
    End Sub

    Private Function HasMaintenance(ByVal roomNo As String) As Boolean
        HasMaintenance = False
        For Each _row As DataGridViewRow In dgvMaintenance.Rows
            If _row.Cells("Room").Value.ToString = roomNo Then
                HasMaintenance = True
                Exit For
            End If
        Next
    End Function

    Private Sub GetBuildRoomNextPosition(ByRef xPos As Integer, ByRef yPos As Integer, Optional ByVal newLevel As Boolean = False)
        Dim currXPos As Integer = 0
        Dim currYPos As Integer = 0
        For Each roomControl As Control In pnlRoomAvailability.Controls
            If roomControl.Top > currYPos Then
                currYPos = roomControl.Top
                currXPos = roomControl.Left
            ElseIf roomControl.Top = currYPos AndAlso currXPos < roomControl.Left Then
                currXPos = roomControl.Left
            End If
        Next
        xPos = currXPos
        yPos = currYPos
        If xPos > 0 Then
            xPos += _buildRoomXGap + _buildRoomWidth
        Else
            xPos = _buildRoomXStartGap
        End If
        If xPos + _buildRoomWidth > pnlRoomAvailability.Right OrElse newLevel Then
            xPos = _buildRoomXStartGap
            yPos += _buildRoomYGap + _buildRoomHeight
        End If
        If yPos = 0 Then
            yPos = _buildRoomYStartGap
        End If
    End Sub

    Private Sub ClearBuildRoom()
        Dim collectionDispose As New List(Of Control)
        For Each roomControl As Control In pnlRoomAvailability.Controls
            collectionDispose.Add(roomControl)
        Next
        pnlRoomAvailability.Controls.Clear()
        For Each roomControl As Control In collectionDispose
            roomControl.Dispose()
            roomControl = Nothing
        Next
    End Sub
#End Region

#Region "Cross Modules"
    Private Sub btnBack_Click(sender As System.Object, e As System.EventArgs) Handles btnBack.Click
        If pnlCheckIn.Visible Then
            pnlCheckIn.Visible = False
        End If
        If pnlCheckOut.Visible Then
            pnlCheckOut.Visible = False
        End If
        If pnlLogBook.Visible Then
            pnlLogBook.Visible = False
        End If
        If pnlExtend.Visible Then
            pnlExtend.Visible = False
        End If
        pnlMainMenu.Visible = True
        btnBack.Visible = False
        BuildRoomAvailability()
    End Sub

    Private Function ToDecimal(ByVal _value As Object) As Decimal
        Dim _cvalue As Decimal
        Try
            _cvalue = CDec(_value)
        Catch ex As Exception
            Return 0D
        End Try
        Return _cvalue
    End Function

    Private Function ToInt(ByVal _value As Object) As Integer
        Dim _cvalue As Integer
        Try
            _cvalue = CInt(_value)
        Catch ex As Exception
            Return 0
        End Try
        Return _cvalue
    End Function
#End Region

#Region "Check In"
    Private Sub pnlCheckIn_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles pnlCheckIn.VisibleChanged
        If pnlCheckIn.Visible Then
            ClearAllCheckIn()
        End If
    End Sub

    Private Sub cbCRoomNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbCRoomNo.SelectedIndexChanged
        If cbCRoomNo.SelectedIndex > -1 Then
            btnCCheckIn.Enabled = True
        Else
            btnCCheckIn.Enabled = False
            btnCPrint.Enabled = False
        End If
    End Sub

    Private Sub cbCRoomType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbCRoomType.SelectedIndexChanged
        cbCRoomNo.Items.Clear()
        btnCCheckIn.Enabled = False
        btnCPrint.Enabled = False
        If cbCRoomType.SelectedIndex > -1 Then
            For Each _item As String In _CheckInBLL.DicRoom.Item(cbCRoomType.Text)
                cbCRoomNo.Items.Add(_item)
            Next
        End If
        CalculateTotalPrice()
    End Sub

    Private Sub txtCDays_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCDays.TextChanged
        CalculateTotalPrice()
    End Sub

    Private Sub txtCDeposit_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCDeposit.TextChanged
        CalculateTotalPrice()
    End Sub

    Private Sub txtCPaid_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCPaid.TextChanged
        CalculateBalance()
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        Dim roomType As String = cbCRoomType.SelectedItem
        Dim selectedRoomType As Integer = -1
        cbCRoomNo.Items.Clear()
        cbCRoomType.Items.Clear()
        _CheckInBLL.GetRooms(chkHideAvailability.Checked)
        For Each _item As String In _CheckInBLL.DicRoom.Keys
            If roomType = _item Then
                selectedRoomType = cbCRoomType.Items.Add(_item)
            Else
                cbCRoomType.Items.Add(_item)
            End If
        Next
        If selectedRoomType >= 0 Then
            cbCRoomType.SelectedIndex = selectedRoomType
        End If
    End Sub

    Private Sub CalculateBalance()
        Dim _totPrice As Decimal = Convert.ToDecimal(txtCTotPrice.Text)
        Dim _paid As Decimal = 0
        Try
            _paid = Convert.ToDecimal(txtCPaid.Text)
        Catch ex As Exception

        End Try
        If _paid > _totPrice AndAlso _totPrice > 0 Then
            txtCBal.Text = (_paid - _totPrice).ToString("N")
        Else
            txtCBal.Text = "0.00"
        End If
    End Sub

    Private Sub CalculateTotalPrice()
        Dim _days As Integer = 0
        Dim _roomPrice As Decimal = 0
        Dim _roomDeposit As Decimal = 0
        Try
            _days = Convert.ToInt32(txtCDays.Text)
        Catch ex As Exception
            txtCTotPrice.Text = "0.00"
            Exit Sub
        End Try
        If _days <= 0 Then
            txtCTotPrice.Text = "0.00"
            Exit Sub
        End If
        _roomPrice = GetRoomPrice()
        Try
            _roomDeposit = Convert.ToDecimal(txtCDeposit.Text)
            If _roomDeposit < 0 Then
                _roomDeposit = 0
            End If
        Catch ex As Exception

        End Try
        If _roomPrice <= 0 Then
            txtCTotPrice.Text = "0.00"
            Exit Sub
        End If
        txtCTotPrice.Text = ((_roomPrice * _days) + _roomDeposit).ToString("N")
    End Sub

    Private Function GetRoomPrice() As Decimal
        GetRoomPrice = 0
        If cbCRoomType.Text <> "" Then
            Dim sIndex As Integer = InStrRev(cbCRoomType.Text, "RM")
            Dim eIndex As Integer = InStrRev(cbCRoomType.Text, ")"c)
            Try
                GetRoomPrice = Convert.ToDecimal(cbCRoomType.Text.Substring(sIndex + 2, eIndex - sIndex - 3))
            Catch ex As Exception
            End Try
        End If
    End Function

    Private Function IsRoomMaintenance(ByVal _roomNo As String, ByRef _roomReason As String) As Boolean
        Dim blnResult As Boolean = False

        For Each _dr As DataGridViewRow In dgvMaintenance.Rows
            If _dr.Cells("Room").Value.ToString = _roomNo Then
                blnResult = True
                _roomReason = _dr.Cells("Reason").Value.ToString
                Exit For
            End If
        Next

        Return blnResult
    End Function

    Private Sub btnCPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnCPrint.Click
        _CheckInBLL.PrintDetails()
    End Sub

    Private Sub btnCClear_Click(sender As System.Object, e As System.EventArgs) Handles btnCClear.Click
        ClearAllCheckIn()
    End Sub

    Private Sub btnCCheckIn_Click(sender As System.Object, e As System.EventArgs) Handles btnCCheckIn.Click
        Dim _errMsg As String = String.Empty
        Dim _roomReason As String = String.Empty

        If IsRoomMaintenance(cbCRoomNo.Text, _roomReason) Then
            If MessageBox.Show("Selected room is under maintenance." & vbCrLf & vbCrLf & "Room No : " & cbCRoomNo.Text & vbCrLf & "Reason : " & _roomReason & vbCrLf & vbCrLf & "Proceed to use the room for check-in ?", "Room under maintenance", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If

        Select Case (_CheckInBLL.CheckIn(cbCRoomType.Text, cbCRoomNo.Text, txtCDays.Text.Trim, txtCName.Text.Trim,
                                         txtCIC.Text.Trim, txtCContact.Text.Trim, txtCAddr.Text.Trim,
                                         GetRoomPrice(), txtCTotPrice.Text, txtCPaid.Text, txtCDeposit.Text, _errMsg))
            Case 0
                MessageBox.Show(String.Format("Successfully checked-in for Room No: {0}" & vbCrLf & vbCrLf & "Customer Name: {1}" & vbCrLf & "Paid: RM {2}" & vbCrLf & "Balance: RM {3}", cbCRoomNo.Text, txtCName.Text, txtCPaid.Text, txtCBal.Text),
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnCPrint.Enabled = True
                Exit Select
            Case 1
                MessageBox.Show(_errMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Select
            Case 2
                MessageBox.Show(_errMsg, "Database Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Select
        End Select
    End Sub

    Private Sub ClearAllCheckIn()
        btnCCheckIn.Enabled = False
        btnCPrint.Enabled = False
        cbCRoomType.Items.Clear()
        cbCRoomNo.Items.Clear()
        cbCRoomType.SelectedIndex = -1
        cbCRoomNo.SelectedIndex = -1
        txtCDays.Text = "1"
        txtCName.Text = ""
        txtCIC.Text = ""
        txtCContact.Text = ""
        txtCAddr.Text = ""
        txtCTotPrice.Text = "0.00"
        txtCPaid.Text = ""
        txtCBal.Text = "0.00"
        _CheckInBLL.GetRooms(chkHideAvailability.Checked)
        For Each _item As String In _CheckInBLL.DicRoom.Keys
            cbCRoomType.Items.Add(_item)
        Next
    End Sub
#End Region

#Region "Check Out"
    Private Sub pnlCheckOut_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles pnlCheckOut.VisibleChanged
        If pnlCheckOut.Visible Then
            ClearAllCheckOut()
            _CheckOutBLL.GetRooms()
            For Each _item As String In _CheckOutBLL.ListRoom
                cbRoom.Items.Add(_item)
            Next
        End If
    End Sub

    Private Sub ClearAllCheckOut()
        cbRoom.Items.Clear()
        cbRoom.SelectedIndex = -1
        btnCOut.Enabled = False
        btnPrint.Enabled = False
        ClearInfo()
    End Sub

    Private Sub ClearInfo()
        txtName.Text = ""
        txtIC.Text = ""
        txtContact.Text = ""
        txtDeposit.Text = ""
    End Sub

    Private Sub PopulateInfo()
        Dim _ds As DataSet = _CheckOutBLL.GetOccupantDetail(cbRoom.Text)
        If _ds.Tables.Count > 0 AndAlso _ds.Tables(0).Rows.Count > 0 Then
            With _ds.Tables(0).Rows(0)
                txtName.Text = .Item("Name").ToString
                txtIC.Text = .Item("IC").ToString
                txtContact.Text = .Item("ContactNo").ToString
                txtDeposit.Text = GetDepositAmt(.Item("DepositAmount").ToString,
                                                .Item("PaidAmount").ToString,
                                                .Item("TotalPrice").ToString,
                                                .Item("RoomPrice").ToString,
                                                .Item("NoOfDays").ToString).ToString("N")
            End With
        End If
    End Sub

    Private Function GetDepositAmt(ByVal _deposit As String, ByVal _paid As String, ByVal _total As String,
                                   ByVal _room As String, ByVal _days As String) As Decimal
        Dim _depoAmt As Decimal = ToDecimal(_deposit)
        Dim _paidAmt As Decimal = ToDecimal(_paid)
        Dim _totalAmt As Decimal = ToDecimal(_total)
        Dim _roomAmt As Decimal = ToDecimal(_room)
        Dim _dayCount As Integer = ToInt(_days)
        If _paidAmt < _totalAmt Then
            _depoAmt = _paidAmt - (_roomAmt * _dayCount)
            If _depoAmt < 0 Then
                _depoAmt = 0
            End If
        End If
        Return _depoAmt
    End Function

    Private Sub cbRoom_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbRoom.SelectedIndexChanged
        If cbRoom.SelectedIndex > -1 Then
            PopulateInfo()
            btnCOut.Enabled = True
            btnPrint.Enabled = False
        Else
            ClearInfo()
            btnCOut.Enabled = False
            btnPrint.Enabled = False
        End If
    End Sub

    Private Sub btnCOut_Click(sender As System.Object, e As System.EventArgs) Handles btnCOut.Click
        If cbRoom.Text <> "" Then
            Dim _errMsg As String = String.Empty

            Select Case (_CheckOutBLL.CheckOut(cbRoom.Text, _errMsg))
                Case 0
                    MessageBox.Show(String.Format("Successfully checked-out for Room No: {0}" & vbCrLf & vbCrLf & "Customer Name: {1}" & vbCrLf & "Customer I/C or Passport: {2}", cbRoom.Text, txtName.Text, txtIC.Text),
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PopulateMaintenanceGrid()
                    Exit Select
                Case 1
                    MessageBox.Show(_errMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                Case 2
                    MessageBox.Show(_errMsg, "Database Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
            End Select
            btnCOut.Enabled = False
            btnPrint.Enabled = True
            btnPrint.Focus()
        End If
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        _CheckOutBLL.PrintReceipt()
    End Sub
#End Region

#Region "Log Book"
    Private Sub pnlLogBook_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles pnlLogBook.VisibleChanged
        If pnlLogBook.Visible Then
            If chkAll.Checked Then
                chkAll.Checked = False
            ElseIf dgvLogBook.DataSource Is Nothing Then
                PopulateLog()
            End If
        End If
    End Sub

    Private Sub PopulateLog()
        If chkAll.Checked Then
            _LogBLL.GetAllLogs()
        Else
            _LogBLL.GetLogs(dtPicker.Value.Date)
        End If
        dgvLogBook.DataSource = _LogBLL._dsVal
        dgvLogBook.DataMember = "HMS_Log"
        dgvLogBook.Columns("DateTime").DefaultCellStyle.Format = "dd-MMM-yyyy   hh:mm tt"
        ColorLog()
        HideLog()
    End Sub

    Private Sub dtPicker_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtPicker.ValueChanged
        PopulateLog()
    End Sub

    Private Sub chkAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAll.CheckedChanged
        PopulateLog()
    End Sub

    Private Sub chkLogCI_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkLogCI.CheckedChanged, chkLogCO.CheckedChanged, chkLogM.CheckedChanged
        HideLog()
    End Sub

    Private Sub ColorLog()
        For Each _dr As DataGridViewRow In dgvLogBook.Rows
            If _dr.Cells("Type").Value.ToString = "Checked In" Then
                _dr.Cells("Type").Style.BackColor = Color.Green
                _dr.Cells("Type").Style.ForeColor = Color.White
            ElseIf _dr.Cells("Type").Value.ToString = "Checked Out" Then
                _dr.Cells("Type").Style.BackColor = Color.Red
                _dr.Cells("Type").Style.ForeColor = Color.White
            ElseIf _dr.Cells("Type").Value.ToString = "Maintenance Start" Then
                If _MaintenanceBLL.ListRooms.ContainsKey(_dr.Cells("RoomNo").Value.ToString) Then
                    _dr.Cells("RoomType").Value = _MaintenanceBLL.ListRooms(_dr.Cells("RoomNo").Value.ToString)
                End If
                _dr.Cells("Type").Style.BackColor = Color.LightBlue
                _dr.Cells("Type").Style.ForeColor = Color.Black
            ElseIf _dr.Cells("Type").Value.ToString = "Maintenance End" Then
                If _MaintenanceBLL.ListRooms.ContainsKey(_dr.Cells("RoomNo").Value.ToString) Then
                    _dr.Cells("RoomType").Value = _MaintenanceBLL.ListRooms(_dr.Cells("RoomNo").Value.ToString)
                End If
                _dr.Cells("Type").Style.BackColor = Color.LightSteelBlue
                _dr.Cells("Type").Style.ForeColor = Color.Black
            ElseIf _dr.Cells("Type").Value.ToString = "Extended" Then
                _dr.Cells("Type").Style.BackColor = Color.GreenYellow
                _dr.Cells("Type").Style.ForeColor = Color.Black
            End If
        Next
    End Sub

    Private Sub HideLog()
        Dim countCheckIn As Integer = 0
        Dim countCheckOut As Integer = 0
        Dim countMaintenanceStart As Integer = 0
        Dim countMaintenanceEnd As Integer = 0
        Dim showCheckIn As Boolean = chkLogCI.Checked
        Dim showCheckOut As Boolean = chkLogCO.Checked
        Dim showMaintenance As Boolean = chkLogM.Checked
        dgvLogBook.CurrentCell = Nothing
        For Each _dr As DataGridViewRow In dgvLogBook.Rows
            If _dr.Cells("Type").Value.ToString = "Checked In" Then
                If showCheckIn Then
                    countCheckIn += 1
                    _dr.Visible = True
                Else
                    _dr.Visible = False
                End If
            ElseIf _dr.Cells("Type").Value.ToString = "Checked Out" Then
                If showCheckOut Then
                    countCheckOut += 1
                    _dr.Visible = True
                Else
                    _dr.Visible = False
                End If
            ElseIf _dr.Cells("Type").Value.ToString = "Maintenance Start" Then
                If showMaintenance Then
                    countMaintenanceStart += 1
                    _dr.Visible = True
                Else
                    _dr.Visible = False
                End If
            ElseIf _dr.Cells("Type").Value.ToString = "Maintenance End" Then
                If showMaintenance Then
                    countMaintenanceEnd += 1
                    _dr.Visible = True
                Else
                    _dr.Visible = False
                End If
            ElseIf _dr.Cells("Type").Value.ToString = "Extended" Then
                If showCheckIn Then
                    countCheckIn += 1
                    _dr.Visible = True
                Else
                    _dr.Visible = False
                End If
            End If
        Next
        If dgvLogBook.Rows.Count > 0 Then
            If countCheckIn + countCheckOut = 0 Then
                dgvLogBook.Columns("Name").Visible = False
                dgvLogBook.Columns("IC").Visible = False
                dgvLogBook.Columns("ContactNo").Visible = False
            Else
                dgvLogBook.Columns("Name").Visible = True
                dgvLogBook.Columns("IC").Visible = True
                dgvLogBook.Columns("ContactNo").Visible = True
            End If
            If countMaintenanceStart + countMaintenanceEnd = 0 Then
                dgvLogBook.Columns("Reason").Visible = False
            Else
                dgvLogBook.Columns("Reason").Visible = True
            End If
        End If
    End Sub
#End Region

#Region "Room Maintenance"
    Private Sub MaintenanceAddReason()
        Dim blnFound As Boolean = False
        Dim currVal As String = cbMReason.Text.Trim.ToUpper
        For Each _item As String In cbMReason.Items
            If _item.ToUpper = currVal Then
                blnFound = True
                Exit For
            End If
        Next
        If Not blnFound Then
            cbMReason.Items.Add(cbMReason.Text.Trim)
        End If
    End Sub

    Private Sub btnMAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnMAdd.Click
        If cbMRoom.Text <> "" AndAlso cbMRoom.SelectedIndex > -1 AndAlso cbMReason.Text.Trim <> "" Then
            If _MaintenanceBLL.AddMaintenance(cbMRoom.Text, cbMReason.Text.Trim) Then
                MessageBox.Show("Maintenance has been added." & vbCrLf & vbCrLf & "Room No : " & cbMRoom.Text & vbCrLf & "Reason : " & cbMReason.Text,
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                PopulateMaintenanceGrid()
                MaintenanceAddReason()
                If pnlMainMenu.Visible Then
                    BuildRoomAvailability(False)
                End If
            Else
                MessageBox.Show("Unable to connect to the database.", "Database Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub PopulateMaintenance()
        _MaintenanceBLL.GetRooms()
        For Each _item As String In _MaintenanceBLL.ListRoom
            cbMRoom.Items.Add(_item)
        Next
        _MaintenanceBLL.GetReasons()
        For Each _item As String In _MaintenanceBLL.ListReason
            cbMReason.Items.Add(_item)
        Next
    End Sub

    Private Sub PopulateMaintenanceGrid()
        Dim _ds As DataSet = _MaintenanceBLL.GetMaintenance(_MaintenanceID)
        Dim _rowIndex As Integer
        Dim _rowID As ULong
        For Each _dr As DataRow In _ds.Tables("HMS_Maintenance").Rows
            _rowID = CULng(_dr.Item("id"))
            _rowIndex = dgvMaintenance.Rows.Add()
            With dgvMaintenance.Rows(_rowIndex)
                .Cells("ID").Value = _rowID
                .Cells("Room").Value = _dr.Item("Room").ToString
                .Cells("Reason").Value = _dr.Item("Reason").ToString
            End With
            If _rowID > _MaintenanceID Then
                _MaintenanceID = _rowID
            End If
        Next
    End Sub

    Private Sub dgvMaintenance_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dgvMaintenance.CellContentClick
        If dgvMaintenance.Columns(e.ColumnIndex).Name = "Complete" AndAlso Not dgvMaintenance.Rows(e.RowIndex).ReadOnly Then
            Dim pid As ULong = CLng(dgvMaintenance.Rows(e.RowIndex).Cells("id").Value)
            Dim _roomno As String = dgvMaintenance.Rows(e.RowIndex).Cells("Room").Value.ToString
            dgvMaintenance.Rows(e.RowIndex).ReadOnly = True
            dgvMaintenance.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Gray
            dgvMaintenance.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.White
            dgvMaintenance.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.Gray
            dgvMaintenance.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.White
            If Not _MaintenanceBLL.UpdateMaintenance(pid, _roomno) Then
                MessageBox.Show("Unable to connect to the database.", "Database Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                dgvMaintenance.Rows(e.RowIndex).ReadOnly = False
            Else
                Dim _drRem As DataGridViewRow = dgvMaintenance.Rows(e.RowIndex)
                Dim t As Task = Task.Factory.StartNew(Sub()
                                                          System.Threading.Thread.Sleep(1500)
                                                          dgvMaintenance.Invoke(New Action(Sub()
                                                                                               dgvMaintenance.Rows.Remove(_drRem)
                                                                                           End Sub))
                                                          If pnlMainMenu.Visible Then
                                                              BuildRoomAvailability(False)
                                                          End If
                                                      End Sub)
            End If
        End If
    End Sub
#End Region

#Region "Room Extend"
    Private Sub pnlExtend_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles pnlExtend.VisibleChanged
        If pnlExtend.Visible Then
            ClearAllExtend()
            _ExtendBLL.GetRooms()
            For Each _item As String In _ExtendBLL.ListRoom
                cbERoom.Items.Add(_item)
            Next
        End If
    End Sub

    Private Sub ClearAllExtend()
        cbERoom.Items.Clear()
        cbERoom.SelectedIndex = -1
        btnEExtend.Enabled = False
        btnEPrint.Enabled = False
        ClearEInfo()
    End Sub

    Private Sub ClearEInfo()
        txtEName.Text = ""
        txtEIC.Text = ""
        txtEContact.Text = ""
        txtEDeposit.Text = ""
        txtEPaid.Text = ""
        txtEBalance.Text = "0.00"
        txtEPrice.Text = "0.00"
    End Sub

    Private Sub cbERoom_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbERoom.SelectedIndexChanged
        If cbERoom.SelectedIndex > -1 Then
            PopulateEInfo()
            btnEExtend.Enabled = True
            btnEPrint.Enabled = False
            CalculateExtendTotalPrice()
        Else
            ClearEInfo()
            btnEExtend.Enabled = False
            btnEPrint.Enabled = False
        End If
    End Sub

    Private Sub PopulateEInfo()
        Dim _ds As DataSet = _ExtendBLL.GetOccupantDetail(cbERoom.Text)
        If _ds.Tables.Count > 0 AndAlso _ds.Tables(0).Rows.Count > 0 Then
            With _ds.Tables(0).Rows(0)
                txtEName.Text = .Item("Name").ToString
                txtEIC.Text = .Item("IC").ToString
                txtEContact.Text = .Item("ContactNo").ToString
                txtEDeposit.Text = GetDepositAmt(.Item("DepositAmount").ToString,
                                                .Item("PaidAmount").ToString,
                                                .Item("TotalPrice").ToString,
                                                .Item("RoomPrice").ToString,
                                                .Item("NoOfDays").ToString).ToString("N")
            End With
        End If
    End Sub

    Private Sub txtEDays_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtEDays.TextChanged
        CalculateExtendTotalPrice()
    End Sub

    Private Sub txtEPaid_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtEPaid.TextChanged
        CalculateExtendBalance()
    End Sub

    Private Sub btnEExtend_Click(sender As System.Object, e As System.EventArgs) Handles btnEExtend.Click
        Dim _errMsg As String = String.Empty
        Select Case (_ExtendBLL.Extend(cbERoom.Text, txtEDays.Text.Trim, txtEPrice.Text, txtEPaid.Text, _errMsg))
            Case 0
                MessageBox.Show(String.Format("Successfully Extends Room No: {0}" & vbCrLf & vbCrLf & "Customer Name: {1}" & vbCrLf & "Paid: RM {2}" & vbCrLf & "Balance: RM {3}" & vbCrLf & "Extend No of Day(s): {4}", cbERoom.Text, txtEName.Text, txtEPaid.Text, txtEBalance.Text, txtEDays.Text),
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnEPrint.Enabled = True
                Exit Select
            Case 1
                MessageBox.Show(_errMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Select
            Case 2
                MessageBox.Show(_errMsg, "Database Failure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Select
        End Select
    End Sub

    Private Sub btnEPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnEPrint.Click

    End Sub

    Private Sub CalculateExtendTotalPrice()
        Dim _days As Integer = 0
        Dim _roomPrice As Decimal = 0
        Try
            _days = Convert.ToInt32(txtEDays.Text)
        Catch ex As Exception
            txtEPrice.Text = "0.00"
            Exit Sub
        End Try
        If _days <= 0 Then
            txtEPrice.Text = "0.00"
            Exit Sub
        End If
        _roomPrice = GetExtendRoomPrice()

        If _roomPrice <= 0 Then
            txtEPrice.Text = "0.00"
            Exit Sub
        End If
        txtEPrice.Text = (_roomPrice * _days).ToString("N")
        If txtEPaid.Text.Trim <> "" Then
            CalculateExtendBalance()
        End If
    End Sub

    Private Function GetExtendRoomPrice() As Decimal
        GetExtendRoomPrice = 0
        If _ExtendBLL IsNot Nothing AndAlso _ExtendBLL.dsExtend IsNot Nothing AndAlso
            _ExtendBLL.dsExtend.Tables.Count > 0 AndAlso
            _ExtendBLL.dsExtend.Tables(0).Rows.Count > 0 Then
            With _ExtendBLL.dsExtend.Tables(0).Rows(0)
                GetExtendRoomPrice = Convert.ToDecimal(.Item("RoomPrice").ToString)
            End With
        End If
    End Function

    Private Sub CalculateExtendBalance()
        Dim _totPrice As Decimal = Convert.ToDecimal(txtEPrice.Text)
        Dim _paid As Decimal = 0
        Try
            _paid = Convert.ToDecimal(txtEPaid.Text)
        Catch ex As Exception

        End Try
        If _paid > _totPrice AndAlso _totPrice > 0 Then
            txtEBalance.Text = (_paid - _totPrice).ToString("N")
        Else
            txtEBalance.Text = "0.00"
        End If
    End Sub
#End Region

End Class
