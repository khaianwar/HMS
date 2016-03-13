Imports MySql.Data.MySqlClient

Public Class Repository
    Private _connString As String = String.Empty

#Region "Constructor"
    Public Sub New(ByVal connString As String)
        _connString = connString
    End Sub
#End Region

#Region "User Management"
    Public Function Login(ByVal _user As String, ByVal _pwd As String) As String
        Dim sqlQuery As String = "SELECT Count(*) As Counts FROM HMS_User WHERE username = @uname AND password = @upwd"
        Dim sqlSaltQuery As String = "SELECT salt FROM HMS_User WHERE username = @uname"
        Dim salt As String = String.Empty
        Using sqlConn As New MySqlConnection(_connString)
            Using sqlComm As New MySqlCommand()
                With sqlComm
                    .Connection = sqlConn
                    .CommandText = sqlSaltQuery
                    .CommandType = CommandType.Text
                End With
                Try
                    sqlConn.Open()
                    Dim sqlReader As MySqlDataReader = sqlComm.ExecuteReader()
                    If sqlReader.Read() Then
                        salt = sqlReader("salt").ToString()
                    End If
                    sqlConn.Close()
                Catch ex As MySqlException
                    Return String.Empty
                End Try
                With sqlComm
                    .Connection = sqlConn
                    .CommandText = sqlQuery
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@upwd", Cryptography.Hash(salt, _pwd))
                End With
                Try
                    sqlConn.Open()
                    Dim sqlReader As MySqlDataReader = sqlComm.ExecuteReader()
                    If sqlReader.Read() Then
                        If CInt(sqlReader("Counts").ToString()) > 0 Then
                            Return "1"
                        End If
                    End If
                    sqlConn.Close()
                Catch ex As MySqlException
                    Return String.Empty
                End Try
            End Using
        End Using
        Return String.Empty
    End Function

    Public Function FindUsername(ByVal _user As String) As Integer
        Dim _count As Integer
        Dim sqlQuery As String = "SELECT Count(*) As Counts FROM `HMS_User` WHERE username = @uname"
        Using sqlConn As New MySqlConnection(_connString)
            Using sqlComm As New MySqlCommand()
                With sqlComm
                    .Connection = sqlConn
                    .CommandText = sqlQuery
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@uname", _user)
                End With
                Try
                    sqlConn.Open()
                    Dim sqlReader As MySqlDataReader = sqlComm.ExecuteReader()
                    If sqlReader.Read() Then
                        Integer.TryParse(sqlReader("Counts").ToString(), _count)
                    End If
                    sqlConn.Close()
                Catch ex As MySqlException
                    Return -1
                End Try
            End Using
        End Using
        Return _count
    End Function

    Public Function CreateUser(ByVal _name As String, ByVal _user As String, ByVal _pwd As String, ByVal _salt As String) As Boolean
        Dim sqlQuery As String = "INSERT INTO `HMS_User` (`username`, `password`, `salt`, `name`) VALUES(@uname, @upwd, @usalt, @name)"
        Using sqlConn As New MySqlConnection(_connString)
            Using sqlComm As New MySqlCommand()
                With sqlComm
                    .Connection = sqlConn
                    .CommandText = sqlQuery
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@uname", _user)
                    .Parameters.AddWithValue("@upwd", _pwd)
                    .Parameters.AddWithValue("@usalt", _salt)
                    .Parameters.AddWithValue("@name", _name)
                End With
                Try
                    sqlConn.Open()
                    Dim sqlResult As Integer = sqlComm.ExecuteNonQuery()
                    sqlConn.Close()
                Catch ex As MySqlException
                    Return False
                End Try
            End Using
        End Using
        Return True
    End Function

    Public Function GetUser() As DataSet
        Dim _ds As New DataSet
        Dim sqlQuery As String = "SELECT * from `HMS_User`"
        Using sqlConn As New MySqlConnection(_connString)
            Using sqlComm As New MySqlCommand()
                With sqlComm
                    .Connection = sqlConn
                    .CommandText = sqlQuery
                    .CommandType = CommandType.Text
                End With
                Try
                    Using sqlDA As New MySqlDataAdapter()
                        sqlDA.SelectCommand = sqlComm
                        sqlDA.Fill(_ds, "HMS_User")
                    End Using
                Catch ex As Exception
                    Return _ds
                End Try
            End Using
        End Using
        Return _ds
    End Function

    Public Function DeleteUser(ByRef _ds As DataSet) As DataSet
        Dim sqlQuery As String = "DELETE from `HMS_User` WHERE id=?id"
        Using sqlConn As New MySqlConnection(_connString)
            Using sqlComm As New MySqlCommand()
                With sqlComm
                    .Connection = sqlConn
                    .CommandText = sqlQuery
                    .Parameters.Add("?id", MySqlDbType.Int32, 11, "id")
                End With
                sqlComm.Parameters(0).SourceVersion = DataRowVersion.Original
                Try
                    Using sqlDA As New MySqlDataAdapter()
                        sqlDA.DeleteCommand = sqlComm
                        sqlDA.Update(_ds, "HMS_User")
                    End Using
                Catch ex As Exception
                    Return _ds
                End Try
            End Using
        End Using
        Return _ds
    End Function
#End Region

#Region "Customer Management"

    Public Function GetHMS_Detail(ByVal _DetailID As ULong) As DataSet
        Dim _ds As New DataSet
        Dim sqlQuery As String = "SELECT * from `HMS_Detail` WHERE `id` = @pid"
        Using sqlConn As New MySqlConnection(_connString)
            Using sqlComm As New MySqlCommand()
                With sqlComm
                    .Connection = sqlConn
                    .CommandText = sqlQuery
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@pid", _DetailID)
                End With
                Try
                    Using sqlDA As New MySqlDataAdapter()
                        sqlDA.SelectCommand = sqlComm
                        sqlDA.Fill(_ds, "HMS_Detail")
                    End Using
                Catch ex As Exception
                    Return _ds
                End Try
            End Using
        End Using
        Return _ds
    End Function

    Public Function AddHMS_Detail(ByVal _ds As DataSet) As DataSet
        Dim sqlQuery As String = "INSERT INTO `HMS_Detail` (`RoomType`, `RoomNo`, `NoOfDays`, `Name`, `IC`, `ContactNo`, `Address`, `RoomPrice`, `TotalPrice`, `PaidAmount`, `DepositAmount`) VALUES(@roomtype, @roomno, @days, @name, @ic, @contactno, @addr, @rprice, @totprice, @paidamt, @depositamt); SELECT `id` from `HMS_Detail` where `id`=@@Identity"
        Using sqlConn As New MySqlConnection(_connString)
            Using sqlComm As New MySqlCommand()
                With sqlComm
                    .Connection = sqlConn
                    .CommandText = sqlQuery
                    .Parameters.Add("@roomtype", MySqlDbType.VarChar, 50, "RoomType")
                    .Parameters.Add("@roomno", MySqlDbType.VarChar, 10, "RoomNo")
                    .Parameters.Add("@days", MySqlDbType.UInt32, 1, "NoOfDays")
                    .Parameters.Add("@name", MySqlDbType.VarChar, 100, "Name")
                    .Parameters.Add("@ic", MySqlDbType.VarChar, 50, "IC")
                    .Parameters.Add("@contactno", MySqlDbType.VarChar, 50, "ContactNo")
                    .Parameters.Add("@addr", MySqlDbType.VarChar, 150, "Address")
                    .Parameters.Add("@rprice", MySqlDbType.Decimal, 8, "RoomPrice")
                    .Parameters.Add("@totprice", MySqlDbType.Decimal, 10, "TotalPrice")
                    .Parameters.Add("@paidamt", MySqlDbType.Decimal, 10, "PaidAmount")
                    .Parameters.Add("@depositamt", MySqlDbType.Decimal, 8, "DepositAmount")
                End With
                Try
                    Using sqlDA As New MySqlDataAdapter()
                        sqlDA.InsertCommand = sqlComm
                        sqlDA.Update(_ds, "HMS_Detail")
                    End Using
                Catch ex As Exception
                    Return _ds
                End Try
            End Using
        End Using
        Return _ds
    End Function

    Public Function AddHMS_ReceiptNo(ByVal _DetailID As ULong) As ULong
        Dim recptNo As ULong = 0
        Dim sqlQuery As String = "INSERT INTO `HMS_ReceiptNo` (`DetailID`) VALUES(@DetailID); SELECT `id` from `HMS_ReceiptNo` where `id`=@@Identity"
        Using sqlConn As New MySqlConnection(_connString)
            Using sqlComm As New MySqlCommand()
                With sqlComm
                    .Connection = sqlConn
                    .CommandText = sqlQuery
                    .Parameters.AddWithValue("@DetailID", _DetailID)
                End With
                Try
                    sqlConn.Open()
                    Using sqlReader As MySqlDataReader = sqlComm.ExecuteReader()
                        If sqlReader.Read() Then
                            recptNo = CULng(sqlReader(0))
                        End If
                    End Using
                    sqlConn.Close()
                Catch ex As Exception
                    Return recptNo
                End Try
            End Using
        End Using
        Return recptNo
    End Function

    Public Function AddHMS_Maintenance(ByVal _ds As DataSet) As DataSet
        Dim sqlQuery As String = "INSERT INTO `HMS_Maintenance` (`Room`, `Reason`) VALUES(@roomno, @reason); SELECT * from `HMS_Maintenance` where `id`=@@Identity"
        Using sqlConn As New MySqlConnection(_connString)
            Using sqlComm As New MySqlCommand()
                With sqlComm
                    .Connection = sqlConn
                    .CommandText = sqlQuery
                    .Parameters.Add("@roomno", MySqlDbType.VarChar, 10, "Room")
                    .Parameters.Add("@reason", MySqlDbType.VarChar, 200, "Reason")
                End With
                Try
                    Using sqlDA As New MySqlDataAdapter()
                        sqlDA.InsertCommand = sqlComm
                        sqlDA.Update(_ds, "HMS_Maintenance")
                    End Using
                Catch ex As Exception
                    Return _ds
                End Try
            End Using
        End Using
        Return _ds
    End Function

    Public Function AddHMS_Log(ByVal _RoomNo As String, ByVal _LogType As Integer, ByVal _DateTime As Date, ByVal _DetailID As ULong?, ByVal _MaintenanceID As ULong?) As Boolean
        Dim sqlQuery As String = "INSERT INTO `HMS_Log` (`RoomNo`, `LogType`, `DateTime`, `DetailID`, `MaintenanceID`) VALUES(@RoomNo, @LogType, @DateTime, @DetailID, @MaintenanceID)"
        Using sqlConn As New MySqlConnection(_connString)
            Using sqlComm As New MySqlCommand()
                With sqlComm
                    .Connection = sqlConn
                    .CommandText = sqlQuery
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@RoomNo", _RoomNo)
                    .Parameters.AddWithValue("@LogType", _LogType)
                    .Parameters.AddWithValue("@DateTime", _DateTime.ToString("yyyy-MM-dd HH:mm:ss"))
                    .Parameters.AddWithValue("@DetailID", If(_DetailID.HasValue, _DetailID, DBNull.Value))
                    .Parameters.AddWithValue("@MaintenanceID", If(_MaintenanceID.HasValue, _MaintenanceID, DBNull.Value))
                End With
                Try
                    sqlConn.Open()
                    Dim sqlResult As Integer = sqlComm.ExecuteNonQuery()
                    sqlConn.Close()
                Catch ex As MySqlException
                    Return False
                End Try
            End Using
        End Using
        Return True
    End Function

    Public Function AddHMS_RoomOccupant(ByVal _RoomNo As String, ByVal _DetailID As ULong, ByVal _DateTime As Date) As Boolean
        Dim sqlQuery As String = "INSERT INTO `HMS_RoomOccupant` (`RoomNo`, `DetailID`, `CheckInDate`) VALUES(@RoomNo, @DetailID, @CheckInDate)"
        Using sqlConn As New MySqlConnection(_connString)
            Using sqlComm As New MySqlCommand()
                With sqlComm
                    .Connection = sqlConn
                    .CommandText = sqlQuery
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@RoomNo", _RoomNo)
                    .Parameters.AddWithValue("@DetailID", _DetailID)
                    .Parameters.AddWithValue("@CheckInDate", _DateTime.ToString("yyyy-MM-dd HH:mm:ss"))
                End With
                Try
                    sqlConn.Open()
                    Dim sqlResult As Integer = sqlComm.ExecuteNonQuery()
                    sqlConn.Close()
                Catch ex As MySqlException
                    Return False
                End Try
            End Using
        End Using
        Return True
    End Function

    Public Function GetHMS_RoomOccupantDetailID(ByVal _RoomNo As String) As ULong
        Dim sqlQuery As String = "SELECT `DetailID` from `HMS_RoomOccupant` WHERE `RoomNo` = @RoomNo AND `CheckOutDate` IS NULL"
        Using sqlConn As New MySqlConnection(_connString)
            Using sqlComm As New MySqlCommand()
                With sqlComm
                    .Connection = sqlConn
                    .CommandText = sqlQuery
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@RoomNo", _RoomNo)
                End With
                Try
                    sqlConn.Open()
                    Dim sqlResult As Object = sqlComm.ExecuteScalar()
                    sqlConn.Close()
                    If sqlResult IsNot Nothing Then
                        Return CULng(sqlResult)
                    End If
                Catch ex As MySqlException
                    Return 0
                End Try
            End Using
        End Using
        Return 0
    End Function

    Public Function UpdateHMS_RoomOccupant(ByVal _RoomNo As String, ByVal _DateTime As Date) As Boolean
        Dim sqlQuery As String = "UPDATE `HMS_RoomOccupant` SET `CheckOutDate`=@CheckOutDate WHERE `RoomNo` = @RoomNo AND `CheckOutDate` IS NULL"
        Using sqlConn As New MySqlConnection(_connString)
            Using sqlComm As New MySqlCommand()
                With sqlComm
                    .Connection = sqlConn
                    .CommandText = sqlQuery
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@RoomNo", _RoomNo)
                    .Parameters.AddWithValue("@CheckOutDate", _DateTime.ToString("yyyy-MM-dd HH:mm:ss"))
                End With
                Try
                    sqlConn.Open()
                    Dim sqlResult As Integer = sqlComm.ExecuteNonQuery()
                    sqlConn.Close()
                Catch ex As MySqlException
                    Return False
                End Try
            End Using
        End Using
        Return True
    End Function

    Public Function GetAllHMS_Log() As DataSet
        Dim _ds As New DataSet
        Dim sqlQuery As String = "SELECT `id`,`RoomNo`,CASE (`LogType`) when 1 then 'Checked In' when 2 then 'Checked Out' when 3 then 'Maintenance Start' when 4 then 'Maintenance End' end `LogType`,`DateTime`,`DetailID`,`MaintenanceID` from `HMS_Log`"
        Using sqlConn As New MySqlConnection(_connString)
            Using sqlComm As New MySqlCommand()
                With sqlComm
                    .Connection = sqlConn
                    .CommandText = sqlQuery
                    .CommandType = CommandType.Text
                End With
                Try
                    Using sqlDA As New MySqlDataAdapter()
                        sqlDA.SelectCommand = sqlComm
                        sqlDA.Fill(_ds, "HMS_Log")
                    End Using
                Catch ex As Exception
                    Return _ds
                End Try
            End Using
        End Using
        Return _ds
    End Function

    Public Function GetHMS_Log(ByVal _date As Date) As DataSet
        Dim _ds As New DataSet
        Dim sqlQuery As String = "SELECT `id`,`RoomNo`,CASE (`LogType`) when 1 then 'Checked In' when 2 then 'Checked Out' when 3 then 'Maintenance Start' when 4 then 'Maintenance End' end `LogType`,`DateTime`,`DetailID`,`MaintenanceID` from `HMS_Log` WHERE convert(`DateTime`, date) = @dtime"
        Using sqlConn As New MySqlConnection(_connString)
            Using sqlComm As New MySqlCommand()
                With sqlComm
                    .Connection = sqlConn
                    .CommandText = sqlQuery
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@dtime", _date.ToString("yyyy-MM-dd"))
                End With
                Try
                    Using sqlDA As New MySqlDataAdapter()
                        sqlDA.SelectCommand = sqlComm
                        sqlDA.Fill(_ds, "HMS_Log")
                    End Using
                Catch ex As Exception
                    Return _ds
                End Try
            End Using
        End Using
        Return _ds
    End Function
#End Region

#Region "Room Management"
    Public Function UpdateAvailableRoom(ByVal _RoomNo As String, ByVal _IsUsed As Integer) As Integer
        Dim sqlQuery As String = "UPDATE `HMS_Room` SET IsUsed=@IsUsed WHERE `RoomNo` = @RoomNo AND IsUsed=@NotIsUsed"
        Using sqlConn As New MySqlConnection(_connString)
            Using sqlComm As New MySqlCommand()
                With sqlComm
                    .Connection = sqlConn
                    .CommandText = sqlQuery
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@RoomNo", _RoomNo)
                    .Parameters.AddWithValue("@IsUsed", _IsUsed)
                    .Parameters.AddWithValue("@NotIsUsed", If(_IsUsed = 0, 1, 0))
                End With
                Try
                    sqlConn.Open()
                    Dim sqlResult As Integer = sqlComm.ExecuteNonQuery()
                    sqlConn.Close()
                    If sqlResult = 1 Then
                        Return 0
                    End If
                Catch ex As MySqlException
                    Return 1
                End Try
            End Using
        End Using
        Return 2
    End Function

    Public Function GetAvailableRoom() As DataSet
        Dim _ds As New DataSet
        Dim sqlQuery As String = "SELECT * from `HMS_Room` WHERE `IsUsed` = 0"
        Using sqlConn As New MySqlConnection(_connString)
            Using sqlComm As New MySqlCommand()
                With sqlComm
                    .Connection = sqlConn
                    .CommandText = sqlQuery
                    .CommandType = CommandType.Text
                End With
                Try
                    Using sqlDA As New MySqlDataAdapter()
                        sqlDA.SelectCommand = sqlComm
                        sqlDA.Fill(_ds, "HMS_Room")
                    End Using
                Catch ex As Exception
                    Return _ds
                End Try
            End Using
        End Using
        Return _ds
    End Function

    Public Function GetNonAvailableRoom(Optional ByVal _Columns As String = "*") As DataSet
        Dim _ds As New DataSet
        Dim sqlQuery As String = "SELECT " & _Columns & " from `HMS_Room` WHERE `IsUsed` = 1"
        Using sqlConn As New MySqlConnection(_connString)
            Using sqlComm As New MySqlCommand()
                With sqlComm
                    .Connection = sqlConn
                    .CommandText = sqlQuery
                    .CommandType = CommandType.Text
                End With
                Try
                    Using sqlDA As New MySqlDataAdapter()
                        sqlDA.SelectCommand = sqlComm
                        sqlDA.Fill(_ds, "HMS_Room")
                    End Using
                Catch ex As Exception
                    Return _ds
                End Try
            End Using
        End Using
        Return _ds
    End Function

    Public Function GetRooms(Optional ByVal _Columns As String = "*") As DataSet
        Dim _ds As New DataSet
        Dim sqlQuery As String = "SELECT " & _Columns & " from `HMS_Room`"
        Using sqlConn As New MySqlConnection(_connString)
            Using sqlComm As New MySqlCommand()
                With sqlComm
                    .Connection = sqlConn
                    .CommandText = sqlQuery
                    .CommandType = CommandType.Text
                End With
                Try
                    Using sqlDA As New MySqlDataAdapter()
                        sqlDA.SelectCommand = sqlComm
                        sqlDA.Fill(_ds, "HMS_Room")
                    End Using
                Catch ex As Exception
                    Return _ds
                End Try
            End Using
        End Using
        Return _ds
    End Function

    Public Function GetReasons(Optional ByVal _Columns As String = "*") As DataSet
        Dim _ds As New DataSet
        Dim sqlQuery As String = "SELECT " & _Columns & " from `HMS_Maintenance`"
        Using sqlConn As New MySqlConnection(_connString)
            Using sqlComm As New MySqlCommand()
                With sqlComm
                    .Connection = sqlConn
                    .CommandText = sqlQuery
                    .CommandType = CommandType.Text
                End With
                Try
                    Using sqlDA As New MySqlDataAdapter()
                        sqlDA.SelectCommand = sqlComm
                        sqlDA.Fill(_ds, "HMS_Maintenance")
                    End Using
                Catch ex As Exception
                    Return _ds
                End Try
            End Using
        End Using
        Return _ds
    End Function

    Public Function GetHMS_Maintenance(ByVal _id As ULong) As DataSet
        Dim _ds As New DataSet
        Dim sqlQuery As String = "SELECT `id`,`Room`,`Reason` from `HMS_Maintenance` where `Complete`=0 and `id`>@pid"
        Using sqlConn As New MySqlConnection(_connString)
            Using sqlComm As New MySqlCommand()
                With sqlComm
                    .Connection = sqlConn
                    .CommandText = sqlQuery
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@pid", _id)
                End With
                Try
                    Using sqlDA As New MySqlDataAdapter()
                        sqlDA.SelectCommand = sqlComm
                        sqlDA.Fill(_ds, "HMS_Maintenance")
                    End Using
                Catch ex As Exception
                    Return _ds
                End Try
            End Using
        End Using
        Return _ds
    End Function

    Public Function InsertHMS_Maintenance(ByVal _RoomNo As String, ByVal _Reason As String) As Boolean
        Dim sqlQuery As String = "INSERT INTO `HMS_Maintenance` (`Room`, `Reason`) VALUES(@RoomNo, @Reason)"
        Using sqlConn As New MySqlConnection(_connString)
            Using sqlComm As New MySqlCommand()
                With sqlComm
                    .Connection = sqlConn
                    .CommandText = sqlQuery
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@RoomNo", _RoomNo)
                    .Parameters.AddWithValue("@Reason", _Reason)
                End With
                Try
                    sqlConn.Open()
                    Dim sqlResult As Integer = sqlComm.ExecuteNonQuery()
                    sqlConn.Close()
                Catch ex As MySqlException
                    Return False
                End Try
            End Using
        End Using
        Return True
    End Function

    Public Function UpdateHMS_Maintenance(ByVal _ID As ULong) As Boolean
        Dim sqlQuery As String = "UPDATE `HMS_Maintenance` SET Complete=1 WHERE `id` = @pid"
        Using sqlConn As New MySqlConnection(_connString)
            Using sqlComm As New MySqlCommand()
                With sqlComm
                    .Connection = sqlConn
                    .CommandText = sqlQuery
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@pid", _ID)
                End With
                Try
                    sqlConn.Open()
                    Dim sqlResult As Integer = sqlComm.ExecuteNonQuery()
                    sqlConn.Close()
                Catch ex As MySqlException
                    Return False
                End Try
            End Using
        End Using
        Return True
    End Function

    Public Sub UpdatePictureHMS_Room(ByVal _ID As String, ByRef _blob() As Byte)
        Dim sqlQuery As String = "UPDATE `HMS_Room` SET Picture=@picture WHERE `id` = @pid"
        Using sqlConn As New MySqlConnection(_connString)
            Using sqlComm As New MySqlCommand()
                With sqlComm
                    .Connection = sqlConn
                    .CommandText = sqlQuery
                    .CommandType = CommandType.Text
                    .Parameters.AddWithValue("@picture", _blob)
                    .Parameters.AddWithValue("@pid", _ID)
                End With
                Try
                    sqlConn.Open()
                    Dim sqlResult As Integer = sqlComm.ExecuteNonQuery()
                    sqlConn.Close()
                Catch ex As MySqlException

                End Try
            End Using
        End Using
    End Sub

    Public Function UpdateHMS_Room(ByRef _ds As DataSet) As DataSet
        Dim sqlInsertQuery As String = "INSERT into `HMS_Room` (`RoomType`, `RoomNo`, `Price`, `Picture`) VALUES(?RoomType, ?RoomNo, ?Price, ?Picture)"
        Dim sqlUpdateQuery As String = "UPDATE `HMS_Room` SET RoomType=?RoomType,RoomNo=?RoomNo,Price=?Price,Picture=?Picture WHERE id=?id"
        Dim sqlDeleteQuery As String = "DELETE from `HMS_Room` WHERE id=?id"
        Using sqlConn As New MySqlConnection(_connString)
            Using sqlCommDelete As New MySqlCommand()
                With sqlCommDelete
                    .Connection = sqlConn
                    .CommandText = sqlDeleteQuery
                    .Parameters.Add("?id", MySqlDbType.Int32, 11, "id")
                End With
                sqlCommDelete.Parameters(0).SourceVersion = DataRowVersion.Original
                Using sqlCommUpdate As New MySqlCommand()
                    With sqlCommUpdate
                        .Connection = sqlConn
                        .CommandText = sqlUpdateQuery
                        .Parameters.Add("?id", MySqlDbType.UInt32, 10, "id")
                        .Parameters.Add("?RoomType", MySqlDbType.String, 50, "RoomType")
                        .Parameters.Add("?RoomNo", MySqlDbType.String, 10, "RoomNo")
                        .Parameters.Add("?Price", MySqlDbType.Decimal, 5, "Price")
                        .Parameters.Add("?Picture", MySqlDbType.Blob)
                    End With
                    For i As Integer = 0 To sqlCommUpdate.Parameters.Count - 1
                        sqlCommUpdate.Parameters(i).SourceVersion = DataRowVersion.Current
                    Next
                    Using sqlCommInsert As New MySqlCommand()
                        With sqlCommInsert
                            .Connection = sqlConn
                            .CommandText = sqlInsertQuery
                            .Parameters.Add("?RoomType", MySqlDbType.String, 50, "RoomType")
                            .Parameters.Add("?RoomNo", MySqlDbType.String, 10, "RoomNo")
                            .Parameters.Add("?Price", MySqlDbType.Decimal, 5, "Price")
                            .Parameters.Add("?Picture", MySqlDbType.Blob)
                        End With
                        For i As Integer = 0 To sqlCommUpdate.Parameters.Count - 1
                            sqlCommUpdate.Parameters(i).SourceVersion = DataRowVersion.Current
                        Next
                        Try
                            Using sqlDA As New MySqlDataAdapter()
                                sqlDA.InsertCommand = sqlCommInsert
                                sqlDA.UpdateCommand = sqlCommUpdate
                                sqlDA.DeleteCommand = sqlCommDelete
                                sqlDA.Update(_ds, "HMS_Room")
                            End Using
                        Catch ex As Exception
                            Return _ds
                        End Try
                    End Using
                End Using
            End Using
        End Using
        Return _ds
    End Function

#End Region
End Class

Public Class Cryptography
    Public Shared Function Hash(ByVal _salt As String, ByVal _pwd As String) As String
        Dim mySHA256 As New Security.Cryptography.SHA256Managed()
        Dim hashValue() As Byte = System.Text.Encoding.UTF8.GetBytes(_pwd & _salt)
        Return BytesToString(mySHA256.ComputeHash(hashValue))
    End Function

    Private Shared Function BytesToString(ByVal Input As Byte()) As String
        Dim Result As New System.Text.StringBuilder(Input.Length * 2)
        Dim Part As String
        For Each b As Byte In Input
            Part = Conversion.Hex(b)
            If Part.Length = 1 Then Part = "0" & Part
            Result.Append(Part)
        Next
        Return Result.ToString()
    End Function
End Class