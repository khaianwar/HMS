Module Converter
    Const _constInt As Integer = 0

    Public Function ToInt(ByVal _value As Object, Optional ByRef _default As Integer = _constInt) As Integer
        Dim _cvalue As Integer
        Try
            _cvalue = CInt(_value)
        Catch ex As Exception
            Return _default
        End Try
        Return _cvalue
    End Function

    Public Function ToShort(ByVal _value As Object, Optional ByRef _default As Short = _constInt) As Short
        Dim _cvalue As Short
        Try
            _cvalue = CShort(_value)
        Catch ex As Exception
            Return _default
        End Try
        Return _cvalue
    End Function

    Public Function ToBool(ByVal _value As Object, Optional ByRef _default As Boolean = False) As Boolean
        Dim _cvalue As Boolean
        Try
            _cvalue = CBool(_value)
        Catch ex As Exception
            Return _default
        End Try
        Return _cvalue
    End Function

    Public Function ToDecimal(ByVal _value As Object, Optional ByRef _default As Decimal = _constInt) As Decimal
        Dim _cvalue As Decimal
        Try
            _cvalue = CDec(_value)
        Catch ex As Exception
            Return _default
        End Try
        Return _cvalue
    End Function

    Public Function ToULong(ByVal _value As Object, Optional ByRef _default As ULong = _constInt) As ULong
        Dim _cvalue As ULong
        Try
            _cvalue = CULng(_value)
        Catch ex As Exception
            Return _default
        End Try
        Return _cvalue
    End Function
End Module
