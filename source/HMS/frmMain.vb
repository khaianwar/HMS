Imports System.Configuration
Imports System.Threading.Tasks

Public Class frmMain
    Private _xEnlarge As Integer
    Private _xEnlargeByTwo As Integer
    Private _CheckInBLL As BLL.CheckInBLL = Nothing
    Private _CheckOutBLL As BLL.CheckOutBLL = Nothing
    Private _LogBLL As BLL.LogBLL = Nothing
    Private _MaintenanceBLL As BLL.MaintenanceBLL = Nothing
    Private _MaintenanceID As ULong = 0

#Region "Form Load"
    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        picLogo.Dock = DockStyle.Fill
        _CheckInBLL = New BLL.CheckInBLL(ConfigurationManager.ConnectionStrings("DBConnection").ConnectionString)
        _CheckOutBLL = New BLL.CheckOutBLL(ConfigurationManager.ConnectionStrings("DBConnection").ConnectionString)
        _LogBLL = New BLL.LogBLL(ConfigurationManager.ConnectionStrings("DBConnection").ConnectionString)
        _MaintenanceBLL = New BLL.MaintenanceBLL(ConfigurationManager.ConnectionStrings("DBConnection").ConnectionString)
        PopulateMaintenance()
        PopulateMaintenanceGrid()
    End Sub
#End Region

#Region "Main Menu"
    Private Sub btnLog_Resize(sender As System.Object, e As System.EventArgs) Handles btnLog.Resize
        _xEnlarge = (btnLog.Width - 10)
        _xEnlargeByTwo = _xEnlarge / 2
        btnCheckIn.Width = _xEnlargeByTwo
        btnCheckOut.Width = _xEnlarge - _xEnlargeByTwo
        btnCheckOut.Left = btnCheckIn.Right + 10
    End Sub

    Private Sub btnCheckIn_Click(sender As System.Object, e As System.EventArgs) Handles btnCheckIn.Click
        pnlMainMenu.Visible = False
        pnlCheckIn.Visible = True
        pnlCheckIn.Height = pnlMainMenu.Height
        btnBack.Visible = True
    End Sub

    Private Sub btnCheckOut_Click(sender As System.Object, e As System.EventArgs) Handles btnCheckOut.Click
        pnlMainMenu.Visible = False
        pnlCheckOut.Visible = True
        pnlCheckOut.Height = pnlMainMenu.Height
        btnBack.Visible = True
    End Sub

    Private Sub btnLog_Click(sender As System.Object, e As System.EventArgs) Handles btnLog.Click
        pnlMainMenu.Visible = False
        pnlLogBook.Visible = True
        pnlLogBook.Height = pnlMainMenu.Height
        btnBack.Visible = True
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
        pnlMainMenu.Visible = True
        btnBack.Visible = False
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
        _CheckInBLL.GetRooms()
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
        dgvLogBook.Columns("DetailID").Visible = False
        dgvLogBook.Columns("MaintenanceID").Visible = False
        dgvLogBook.Columns("DateTime").DefaultCellStyle.Format = "dd-MMM-yyyy   hh:mm tt"
        ColorLog()
    End Sub

    Private Sub dtPicker_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtPicker.ValueChanged
        PopulateLog()
    End Sub

    Private Sub chkAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAll.CheckedChanged
        PopulateLog()
    End Sub

    Private Sub ColorLog()
        For Each _dr As DataGridViewRow In dgvLogBook.Rows
            If _dr.Cells("LogType").Value.ToString = "Checked In" Then
                _dr.Cells("LogType").Style.BackColor = Color.Green
                _dr.Cells("LogType").Style.ForeColor = Color.White
            ElseIf _dr.Cells("LogType").Value.ToString = "Checked Out" Then
                _dr.Cells("LogType").Style.BackColor = Color.Red
                _dr.Cells("LogType").Style.ForeColor = Color.White
            ElseIf _dr.Cells("LogType").Value.ToString = "Maintenance Start" Then
                _dr.Cells("LogType").Style.BackColor = Color.LightBlue
                _dr.Cells("LogType").Style.ForeColor = Color.Black
            ElseIf _dr.Cells("LogType").Value.ToString = "Maintenance End" Then
                _dr.Cells("LogType").Style.BackColor = Color.LightSteelBlue
                _dr.Cells("LogType").Style.ForeColor = Color.Black
            End If
        Next
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
                                                      End Sub)
            End If
        End If
    End Sub
#End Region
End Class
