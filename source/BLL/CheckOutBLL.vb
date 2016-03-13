Imports System.IO

Public Class CheckOutBLL
    Private _connString As String = String.Empty
    Private _lstRoom As List(Of String)
    Private _DetailID As ULong = 0
    Private _dsCheckout As DataSet = Nothing
    Public ReadOnly Property ListRoom As List(Of String)
        Get
            Return _lstRoom
        End Get
    End Property
    Public ReadOnly Property dsCheckout As DataSet
        Get
            Return _dsCheckout
        End Get
    End Property

    Public Sub New(ByVal connString As String)
        _connString = connString
        _lstRoom = New List(Of String)
    End Sub

    Public Sub GetRooms()
        Dim _DAL As New DAL.Repository(_connString)
        Dim _ds As DataSet = _DAL.GetNonAvailableRoom("RoomNo")
        _DAL = Nothing
        _lstRoom.Clear()
        If _ds.Tables.Contains("HMS_Room") Then
            For Each _dr As DataRow In _ds.Tables("HMS_Room").Rows
                _lstRoom.Add(_dr.Item("RoomNo").ToString)
            Next
        End If
    End Sub

    Public Function GetOccupantDetail(ByVal _roomno As String) As DataSet
        Dim _DAL As New DAL.Repository(_connString)
        Dim DetailID As ULong = _DAL.GetHMS_RoomOccupantDetailID(_roomno)
        If DetailID > 0 Then
            _DetailID = DetailID
            _dsCheckout = _DAL.GetHMS_Detail(DetailID)
        Else
            If _dsCheckout IsNot Nothing Then
                _dsCheckout.Clear()
                _dsCheckout = Nothing
            End If
            _dsCheckout = New DataSet
        End If
        _DAL = Nothing
        Return dsCheckout
    End Function

    Public Function CheckOut(ByVal _roomno As String, ByRef _errMsg As String) As Integer
        Dim _DateNow As Date = DateTime.Now
        Dim _DAL As New DAL.Repository(_connString)
        Select Case (_DAL.UpdateAvailableRoom(_roomno, 0))
            Case 0
                Exit Select
            Case 1
                _errMsg = "Unable to connect to the database."
                _DAL = Nothing
                Return 2
                Exit Select
            Case 2
                _errMsg = "Room is not available."
                _DAL = Nothing
                Return 1
                Exit Select
        End Select
        _DAL.UpdateHMS_RoomOccupant(_roomno, _DateNow)
        _DAL.AddHMS_Log(_roomno, LogType.CheckOut, _DateNow, _DetailID, Nothing)
        Dim MaintenanceBLL As New MaintenanceBLL(_connString)
        MaintenanceBLL.AddMaintenance(_roomno, "Cleaning in progress")
        MaintenanceBLL = Nothing
        _DAL = Nothing
        Return 0
    End Function

    Private Function GetDepositAmt(ByVal _deposit As String, ByVal _paid As String, ByVal _total As String,
                                   ByVal _room As String, ByVal _days As String) As Decimal
        Dim _depoAmt As Decimal = Converter.ToDecimal(_deposit)
        Dim _paidAmt As Decimal = Converter.ToDecimal(_paid)
        Dim _totalAmt As Decimal = Converter.ToDecimal(_total)
        Dim _roomAmt As Decimal = Converter.ToDecimal(_room)
        Dim _dayCount As Integer = Converter.ToInt(_days)
        If _paidAmt < _totalAmt Then
            _depoAmt = _paidAmt - (_roomAmt * _dayCount)
            If _depoAmt < 0 Then
                _depoAmt = 0
            End If
        End If
        Return _depoAmt
    End Function

    Private Function GetPaidAmt(ByVal _paid As String, ByVal _total As String) As Decimal
        Dim _paidAmt As Decimal = Converter.ToDecimal(_paid)
        Dim _totalAmt As Decimal = Converter.ToDecimal(_total)
        If _paidAmt < _totalAmt Then
            Return _paidAmt
        Else
            Return _totalAmt
        End If
    End Function

    Private Function GetReceiptNo(ByVal _DetailID As Integer) As ULong
        Dim receiptNo As ULong
        Dim _DAL As New DAL.Repository(_connString)
        receiptNo = _DAL.AddHMS_ReceiptNo(_DetailID)
        _DAL = Nothing
        Return receiptNo
    End Function

    Public Sub PrintReceipt()
        Dim _errMsg As String = String.Empty
        If _dsCheckout.Tables.Count > 0 AndAlso _dsCheckout.Tables("HMS_Detail").Rows.Count > 0 Then
            Dim _zero As Char = "0"c
            Dim _dr As DataRow = _dsCheckout.Tables("HMS_Detail").Rows(0)
            Dim _currReceiptNo As ULong = GetReceiptNo(Converter.ToInt(_dr.Item("id")))
            Dim _receiptNo As String = _currReceiptNo.ToString.PadLeft(10, _zero)
            Dim _filename As String = String.Format(".\Receipt\{0}.pdf", _receiptNo)
            Dim _rcptPrint As New PdfPlotUtil("Receipt.pdf", _filename)
            If Not Directory.Exists(".\Receipt") Then
                Directory.CreateDirectory(".\Receipt")
            End If
            If _currReceiptNo = 0 Then
                MsgBox("Unable to retrieve receipt number from database", MsgBoxStyle.OkOnly, "Error")
            ElseIf _rcptPrint.GetPdfData(_errMsg) Then
                _rcptPrint.ReceiptNo(_receiptNo)
                _rcptPrint.ReceiptDate(DateTime.Now.Date.ToString("dd/MM/yyyy"))
                _rcptPrint.RoomNo(_dr.Item("RoomNo").ToString)
                _rcptPrint.Balance(GetDepositAmt(_dr.Item("DepositAmount").ToString,
                                                 _dr.Item("PaidAmount").ToString,
                                                 _dr.Item("TotalPrice").ToString,
                                                 _dr.Item("RoomPrice").ToString,
                                                 _dr.Item("NoOfDays").ToString).ToString("N"))
                _rcptPrint.Paid(GetPaidAmt(_dr.Item("PaidAmount").ToString, _dr.Item("TotalPrice").ToString).ToString("N"))
                _rcptPrint.RoomType(_dr.Item("RoomType").ToString)
                _rcptPrint.UnitPrice(Converter.ToDecimal(_dr.Item("RoomPrice")).ToString("N"))
                _rcptPrint.Price(CalcTotalRoomPrice(_dr.Item("RoomPrice").ToString, _dr.Item("NoOfDays").ToString).ToString("N"))
                _rcptPrint.Name(_dr.Item("Name").ToString)
                _rcptPrint.Days(_dr.Item("NoOfDays").ToString)
                _rcptPrint.Output()
                Process.Start(_filename)
            Else
                MsgBox(_errMsg, MsgBoxStyle.OkOnly, "Error")
            End If
        End If
    End Sub

    Private Function CalcTotalRoomPrice(ByVal _price As String, ByVal _days As String) As Decimal
        Dim _dayAmt As Integer = Converter.ToInt(_days)
        Dim _priceAmt As Decimal = Converter.ToDecimal(_price)
        Return _dayAmt * _priceAmt
    End Function
End Class
