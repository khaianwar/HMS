Public Class LogBLL
    Private _connString As String = String.Empty
    Private _ds As DataSet = Nothing
    Public ReadOnly Property _dsVal As DataSet
        Get
            Return _ds
        End Get
    End Property

    Public Sub New(ByVal connString As String)
        _connString = connString
    End Sub

    Public Sub GetAllLogs()
        Dim _DAL As New DAL.Repository(_connString)
        If _ds IsNot Nothing Then
            _ds.Clear()
            _ds = Nothing
        End If
        _ds = _DAL.GetAllHMS_Log()
        _DAL = Nothing
    End Sub

    Public Sub GetLogs(ByVal _date As Date)
        Dim _DAL As New DAL.Repository(_connString)
        If _ds IsNot Nothing Then
            _ds.Clear()
            _ds = Nothing
        End If
        _ds = _DAL.GetHMS_Log(_date)
        _DAL = Nothing
    End Sub

End Class
