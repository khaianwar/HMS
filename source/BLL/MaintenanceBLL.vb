Imports System.Collections.Generic
Public Class MaintenanceBLL
    Private _connString As String = String.Empty
    Private _lstRoom As List(Of String)
    Private _lstReason As List(Of String)
    Private _dicRooms As Dictionary(Of String, String)
    Private _roomAvail As Dictionary(Of String, Boolean)
    Private _roomLevel As Dictionary(Of String, Integer)
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
    Public ReadOnly Property ListRooms As Dictionary(Of String, String)
        Get
            Return _dicRooms
        End Get
    End Property
    Public ReadOnly Property RoomAvailability As Dictionary(Of String, Boolean)
        Get
            Return _roomAvail
        End Get
    End Property
    Public ReadOnly Property RoomLevel As Dictionary(Of String, Integer)
        Get
            Return _roomLevel
        End Get
    End Property

    Public Sub New(ByVal connString As String)
        _connString = connString
        _lstRoom = New List(Of String)
        _lstReason = New List(Of String)
        _dicRooms = New Dictionary(Of String, String)
        _roomAvail = New Dictionary(Of String, Boolean)
        _roomLevel = New Dictionary(Of String, Integer)
    End Sub

    Public Sub GetRooms()
        Dim _DAL As New DAL.Repository(_connString)
        Dim _ds As DataSet = _DAL.GetRooms("RoomNo,RoomType,IsUsed,Level")
        _DAL = Nothing
        _lstRoom.Clear()
        _dicRooms.Clear()
        _roomAvail.Clear()
        _roomLevel.Clear()
        If _ds.Tables.Contains("HMS_Room") Then
            For Each _dr As DataRow In _ds.Tables("HMS_Room").Rows
                _lstRoom.Add(_dr.Item("RoomNo").ToString)
                _dicRooms.Add(_dr.Item("RoomNo").ToString, _dr.Item("RoomType").ToString.ToUpper)
                _roomAvail.Add(_dr.Item("RoomNo").ToString, Converter.ToBool(_dr.Item("IsUsed")))
                _roomLevel.Add(_dr.Item("RoomNo").ToString, Converter.ToInt(_dr.Item("Level")))
            Next
        End If
    End Sub

    Public Function GetRoomPrices() As DataSet
        Dim _DAL As New DAL.Repository(_connString)
        Dim _ds As DataSet = _DAL.GetRooms("ID,RoomNo,RoomType,Level,Price")
        _DAL = Nothing
        Return _ds
    End Function

    Public Function UpdateHMS_RoomPrice(ByRef _ds As DataSet) As DataSet
        Dim _DAL As New DAL.Repository(_connString)
        _ds = _DAL.UpdateHMS_RoomPrice(_ds)
        _DAL = Nothing
        Return _ds
    End Function

    Public Sub ExecuteNonQuery_Update_V1()
        Dim _DAL As New DAL.Repository(_connString)
        _DAL.ExecuteNonQuery("ALTER TABLE `HMS_Room` ADD COLUMN `Level` INT NOT NULL DEFAULT '1';")
        _DAL = Nothing
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
            _DAL.AddHMS_Log(_roomno, LogType.MaintenanceStart, _DateNow, Nothing, DetailID)
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
