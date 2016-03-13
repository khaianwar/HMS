Imports System.IO

Public Class CheckInBLL
    Private _connString As String = String.Empty
    Private _dicRoom As Dictionary(Of String, List(Of String))
    Private _dsCheckedIn As DataSet = Nothing
    Public ReadOnly Property DicRoom As Dictionary(Of String, List(Of String))
        Get
            Return _dicRoom
        End Get
    End Property

    Public Sub New(ByVal connString As String)
        _connString = connString
        _dicRoom = New Dictionary(Of String, List(Of String))
    End Sub

    Public Function CheckIn(ByVal _roomtype As String, ByVal _roomno As String, ByVal _days As String,
                            ByVal _name As String, ByVal _ic As String, ByVal _contactno As String,
                            ByVal _addr As String, ByVal _roomPrice As Decimal, ByVal _totPrice As String,
                            ByVal _paidPrice As String, ByVal _paidDeposit As String, ByRef _errMsg As String) As Integer
        Dim _totalPrice As Decimal = 0
        Dim _paidAmt As Decimal = 0
        Try
            _paidAmt = Convert.ToDecimal(_paidPrice)
            _totalPrice = Convert.ToDecimal(_totPrice)
        Catch ex As Exception

        End Try
        If _roomtype = "" Then
            _errMsg = "Room Type cannot be empty."
            Return 1
        End If
        If _roomno = "" Then
            _errMsg = "Room No cannot be empty."
            Return 1
        End If
        If Converter.ToInt(_days) <= 0 Then
            _errMsg = "No of Day(s) must be larger than zero."
            Return 1
        End If
        If _name = "" Then
            _errMsg = "Name cannot be empty."
            Return 1
        End If
        If _ic = "" Then
            _errMsg = "I/C or Passport cannot be empty."
            Return 1
        End If
        If _paidAmt <= 0 Then
            _errMsg = "Paid amount cannot be empty."
            Return 1
        End If

        Dim _DateNow As Date = DateTime.Now
        Dim _DAL As New DAL.Repository(_connString)
        Select Case (_DAL.UpdateAvailableRoom(_roomno, 1))
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

        Dim _ds As New DataSet
        _ds.Tables.Add(TableDesign.HMS_Detail())
        Dim _dr As DataRow = _ds.Tables(0).NewRow
        _dr.Item("RoomType") = FilterRoomType(_roomtype)
        _dr.Item("RoomNo") = _roomno
        _dr.Item("NoOfDays") = _days
        _dr.Item("Name") = _name
        _dr.Item("IC") = _ic
        _dr.Item("ContactNo") = If(_contactno <> "", _contactno, DBNull.Value)
        _dr.Item("Address") = If(_addr <> "", _addr, DBNull.Value)
        _dr.Item("RoomPrice") = _roomPrice
        _dr.Item("TotalPrice") = _totalPrice
        _dr.Item("PaidAmount") = _paidAmt
        _dr.Item("DepositAmount") = _paidDeposit
        _ds.Tables(0).Rows.Add(_dr)
        _ds = _DAL.AddHMS_Detail(_ds)

        Dim DetailID As ULong = Converter.ToULong(_ds.Tables(0).Rows(0).Item("id").ToString)
        If DetailID <= 0 Then
            _errMsg = "Unable to connect to the database."
            _DAL = Nothing
            Return 2
        End If
        _dsCheckedIn = _ds
        _DAL.AddHMS_RoomOccupant(_roomno, DetailID, _DateNow)
        _DAL.AddHMS_Log(_roomno, LogType.CheckIn, _DateNow, DetailID, Nothing)
        _DAL = Nothing
        Return 0
    End Function

    Private Function FilterRoomType(ByVal _roomType As String) As String
        Dim index As Integer = InStrRev(_roomType, "("c)
        Return _roomType.Substring(0, index - 2)
    End Function

    Public Sub GetRooms()
        Dim _DAL As New DAL.Repository(_connString)
        Dim _ds As DataSet = _DAL.GetAvailableRoom()
        Dim _roomType As String = String.Empty
        _DAL = Nothing
        _dicRoom.Clear()
        If _ds.Tables.Contains("HMS_Room") Then
            For Each _dr As DataRow In _ds.Tables("HMS_Room").Rows
                _roomType = String.Format("{0} (RM {1})", _dr.Item("RoomType").ToString, _dr.Item("Price").ToString).ToUpper
                If Not _dicRoom.ContainsKey(_roomType) Then
                    _dicRoom.Add(_roomType, New List(Of String))
                End If
                _dicRoom.Item(_roomType).Add(_dr.Item("RoomNo").ToString)
            Next
        End If
    End Sub

    Public Sub PrintDetails()
        If _dsCheckedIn IsNot Nothing AndAlso _dsCheckedIn.Tables("HMS_Detail").Rows.Count > 0 AndAlso _
            Converter.ToULong(_dsCheckedIn.Tables("HMS_Detail").Rows(0).Item("id")) > 0 Then
            With _dsCheckedIn.Tables("HMS_Detail").Rows(0)
                Dim _zero As Char = "0"c
                Dim _errMsg As String = String.Empty
                Dim _receiptNo As String = .Item("id").ToString.PadLeft(10, _zero)
                Dim _filename As String = String.Format(".\Details\{0}.pdf", _receiptNo)
                Dim _chkInDetailPrint As New PdfPlotUtil("Details.pdf", _filename)
                If Not Directory.Exists(".\Details") Then
                    Directory.CreateDirectory(".\Details")
                End If
                If _chkInDetailPrint.GetPdfData(_errMsg) Then
                    _chkInDetailPrint.CheckInDate(DateTime.Now.Date.ToString("dd/MM/yyyy"))
                    _chkInDetailPrint.Name(.Item("Name").ToString)
                    _chkInDetailPrint.GuestIC(.Item("IC").ToString)
                    _chkInDetailPrint.GuestAddress(.Item("Address").ToString)
                    _chkInDetailPrint.RoomNo(.Item("RoomNo").ToString)
                    _chkInDetailPrint.RoomType(.Item("RoomType").ToString)
                    _chkInDetailPrint.UnitPrice(Converter.ToDecimal(.Item("RoomPrice")).ToString("N"))
                    _chkInDetailPrint.Days(.Item("NoOfDays").ToString)
                    _chkInDetailPrint.PaidAmount(GetPaidAmt(.Item("PaidAmount").ToString, .Item("TotalPrice").ToString).ToString("N"))
                    _chkInDetailPrint.Output()
                    Process.Start(_filename)
                Else
                    MsgBox(_errMsg, MsgBoxStyle.OkOnly, "Error")
                End If
            End With
        End If
    End Sub

    Private Function GetPaidAmt(ByVal _paid As String, ByVal _total As String) As Decimal
        Dim _paidAmt As Decimal = Converter.ToDecimal(_paid)
        Dim _totalAmt As Decimal = Converter.ToDecimal(_total)
        If _paidAmt < _totalAmt Then
            Return _paidAmt
        Else
            Return _totalAmt
        End If
    End Function
End Class
