Module TableDesign
    Public Function HMS_Detail() As DataTable
        Dim _dt As New DataTable("HMS_Detail")
        _dt.Columns.Add("id", GetType(ULong))
        _dt.Columns.Add("RoomType", GetType(String))
        _dt.Columns.Add("RoomNo", GetType(String))
        _dt.Columns.Add("NoOfDays", GetType(UInteger))
        _dt.Columns.Add("Name", GetType(String))
        _dt.Columns.Add("IC", GetType(String))
        _dt.Columns.Add("ContactNo", GetType(String))
        _dt.Columns.Add("Address", GetType(String))
        _dt.Columns.Add("RoomPrice", GetType(Decimal))
        _dt.Columns.Add("TotalPrice", GetType(Decimal))
        _dt.Columns.Add("PaidAmount", GetType(Decimal))
        _dt.Columns.Add("DepositAmount", GetType(Decimal))
        Return _dt
    End Function

    Public Function HMS_Maintenance() As DataTable
        Dim _dt As New DataTable("HMS_Maintenance")
        _dt.Columns.Add("id", GetType(ULong))
        _dt.Columns.Add("Room", GetType(String))
        _dt.Columns.Add("Reason", GetType(String))
        _dt.Columns.Add("Complete", GetType(Integer))
        Return _dt
    End Function
End Module
