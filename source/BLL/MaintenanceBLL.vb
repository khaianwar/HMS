Public Class MaintenanceBLL
    Private _connString As String = String.Empty
    Private _lstRoom As List(Of String)
    Private _lstReason As List(Of String)
    Public ReadOnly Property ListRoom As List(Of String)
        Get
            Return _lstRoom
        End Get
    End Property
    Public ReadOnly Property ListReason As List(Of String)
        Get
            Return _lstReason
        End Get
    End Property

    Public Sub New(ByVal connString As String)
        _connString = connString
        _lstRoom = New List(Of String)
        _lstReason = New List(Of String)
    End Sub

    Public Sub GetRooms()
        Dim _DAL As New DAL.Repository(_connString)
        Dim _ds As DataSet = _DAL.GetRooms("RoomNo")
        _DAL = Nothing
        _lstRoom.Clear()
        If _ds.Tables.Contains("HMS_Room") Then
            For Each _dr As DataRow In _ds.Tables("HMS_Room").Rows
                _lstRoom.Add(_dr.Item("RoomNo").ToString)
            Next
        End If
    End Sub

    Public Sub GetReasons()
        Dim _DAL As New DAL.Repository(_connString)
        Dim _ds As DataSet = _DAL.GetReasons("Distinct Reason")
        _DAL = Nothing
        _lstReason.Clear()
        If _ds.Tables.Contains("HMS_Maintenance") Then
            For Each _dr As DataRow In _ds.Tables("HMS_Maintenance").Rows
                _lstReason.Add(_dr.Item("Reason").ToString)
            Next
        End If
    End Sub

    Public Function AddMaintenance(ByVal _roomno As String, ByVal _reason As String) As Boolean
        Dim _result As Boolean
        Dim _DateNow As Date = DateTime.Now
        Dim _ds As New DataSet
        Dim _DAL As New DAL.Repository(_connString)
        _ds.Tables.Add(TableDesign.HMS_Maintenance())
        Dim _dr As DataRow = _ds.Tables(0).NewRow
        _dr.Item("Room") = _roomno
        _dr.Item("Reason") = _reason
        _ds.Tables(0).Rows.Add(_dr)
        _ds = _DAL.AddHMS_Maintenance(_ds)
        Dim DetailID As ULong = Converter.ToULong(_ds.Tables(0).Rows(0).Item("id").ToString)
        If DetailID > 0 Then
            _result = True
            _DAL.AddHMS_Log(_roomno, LogType.MaintenanceStart, _DateNow, Nothing, Nothing)
        Else
            _result = False
        End If
        _DAL = Nothing
        Return _result
    End Function

    Public Function UpdateMaintenance(ByVal _id As ULong, ByVal _roomno As String) As Boolean
        Dim _DateNow As Date = DateTime.Now
        Dim _result As Boolean
        Dim _DAL As New DAL.Repository(_connString)
        _result = _DAL.UpdateHMS_Maintenance(_id)
        If _result Then
            _DAL.AddHMS_Log(_roomno, LogType.MaintenanceEnd, _DateNow, Nothing, _id)
        End If
        _DAL = Nothing
        Return _result
    End Function

    Public Function GetMaintenance(ByVal _id As ULong) As DataSet
        Dim _DAL As New DAL.Repository(_connString)
        Dim _ds As DataSet = _DAL.GetHMS_Maintenance(_id)
        _DAL = Nothing
        Return _ds
    End Function

End Class
