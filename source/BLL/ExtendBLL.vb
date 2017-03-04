Imports System.IO

Public Class ExtendBLL
    Private _connString As String = String.Empty
    Private _lstRoom As List(Of String)
    Private _DetailID As ULong = 0
    Private _dsExtend As DataSet = Nothing
    Public ReadOnly Property ListRoom As List(Of String)
        Get
            Return _lstRoom
        End Get
    End Property
    Public ReadOnly Property dsExtend As DataSet
        Get
            Return _dsExtend
        End Get
    End Property

    Public Sub New(ByVal connString As String)
        _connString = connString
        _lstRoom = New List(Of String)
    End Sub

    Public Function Extend(ByVal _roomno As String, ByVal _days As String,
                           ByVal _totPrice As String, ByVal _paidPrice As String, ByRef _errMsg As String) As Integer
        Dim _DateNow As Date = DateTime.Now
        Dim _DAL As New DAL.Repository(_connString)
        Dim _totalPrice As Decimal = 0
        Dim _paidAmt As Decimal = 0
        Dim _noDays As UInteger = 0
        Try
            _paidAmt = Convert.ToDecimal(_paidPrice)
            _totalPrice = Convert.ToDecimal(_totPrice)
        Catch ex As Exception

        End Try
        If _roomno = "" Then
            _errMsg = "Room No cannot be empty."
            Return 1
        End If
        If Converter.ToInt(_days) <= 0 Then
            _errMsg = "No of Day(s) must be larger than zero."
            Return 1
        Else
            _noDays = Converter.ToInt(_days)
        End If
        If _paidAmt <= 0 Then
            _errMsg = "Paid amount cannot be empty."
            Return 1
        End If
        If _dsExtend IsNot Nothing AndAlso _dsExtend.Tables.Count > 0 AndAlso _dsExtend.Tables(0).Rows.Count > 0 Then
            With _dsExtend.Tables(0).Rows(0)
                _noDays += Converter.ToInt(.Item("NoOfDays"))
                _totalPrice += Converter.ToDecimal(.Item("TotalPrice"))
                _paidAmt += Converter.ToDecimal(.Item("PaidAmount"))
            End With
        End If
        If Not _DAL.UpdateHMS_Detail(_DetailID, _noDays, _totalPrice, _paidAmt) Then
            _errMsg = "Unable to connect to the database."
            _DAL = Nothing
            Return 2
        End If
        _DAL.AddHMS_Log(_roomno, LogType.Extend, _DateNow, _DetailID, Nothing)
        _DAL = Nothing
        Return 0
    End Function

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
            _dsExtend = _DAL.GetHMS_Detail(DetailID)
        Else
            If _dsExtend IsNot Nothing Then
                _dsExtend.Clear()
                _dsExtend = Nothing
            End If
            _dsExtend = New DataSet
        End If
        _DAL = Nothing
        Return dsExtend
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
        If _dsExtend.Tables.Count > 0 AndAlso _dsExtend.Tables("HMS_Detail").Rows.Count > 0 Then
            Dim _zero As Char = "0"c
            Dim _dr As DataRow = _dsExtend.Tables("HMS_Detail").Rows(0)
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
