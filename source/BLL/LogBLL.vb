Public Class LogBLL
    Private _connString As String = String.Empty
    Private _ds As DataSet = Nothing
    Private Property ds As DataSet
        Get
            Return _ds
        End Get
        Set(value As DataSet)
            If value IsNot Nothing AndAlso value.Tables.Count > 0 Then
                Dim originalColumnIndex As Integer = value.Tables(0).Columns.IndexOf("LogType")
                Dim columnLogType As DataColumn = value.Tables(0).Columns.Add("Type", GetType(String))
                For Each _dr As DataRow In value.Tables(0).Rows
                    Select Case (Converter.ToInt(_dr.Item(originalColumnIndex)))
                        Case LogType.CheckIn
                            _dr.Item(columnLogType) = "Checked In"
                            Exit Select
                        Case LogType.CheckOut
                            _dr.Item(columnLogType) = "Checked Out"
                            Exit Select
                        Case LogType.MaintenanceStart
                            _dr.Item(columnLogType) = "Maintenance Start"
                            Exit Select
                        Case LogType.MaintenanceEnd
                            _dr.Item(columnLogType) = "Maintenance End"
                            Exit Select
                        Case LogType.Extend
                            _dr.Item(columnLogType) = "Extended"
                            Exit Select
                    End Select
                Next
                value.Tables(0).Columns.RemoveAt(originalColumnIndex)
                columnLogType.SetOrdinal(originalColumnIndex)
                _ds = value
            Else
                _ds = Nothing
            End If
        End Set
    End Property
    Public ReadOnly Property _dsVal As DataSet
        Get
            Return ds
        End Get
    End Property

    Public Sub New(ByVal connString As String)
        _connString = connString
    End Sub

    Public Sub GetAllLogs()
        Dim _DAL As New DAL.Repository(_connString)
        If ds IsNot Nothing Then
            ds.Clear()
            ds = Nothing
        End If
        ds = _DAL.GetAllHMS_Log()
        _DAL = Nothing
    End Sub

    Public Sub GetLogs(ByVal _date As Date)
        Dim _DAL As New DAL.Repository(_connString)
        If ds IsNot Nothing Then
            ds.Clear()
            ds = Nothing
        End If
        ds = _DAL.GetHMS_Log(_date)
        _DAL = Nothing
    End Sub

End Class
