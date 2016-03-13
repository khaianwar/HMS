Imports System.IO
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class PdfPlotUtil
    Private Property filename As String
    Private Property newFilename As String
    Private pdfReader As PdfReader = Nothing
    Private pdfStamper As PdfStamper = Nothing
    Private pdfFormFields As AcroFields = Nothing

    'object's variable name to search
    Private searchParam As String() = {"rcpNo", "rcpDate",
                                       "roomNo", "guestName",
                                       "receiveAmount", "balanceReturn",
                                       "roomType", "unitPrice",
                                       "noOfDays", "totalPrice",
                                       "chkInDate", "guestIC",
                                       "guestAddr", "paidAmt"}

#Region "Instantiate"
    'instantiate report object
    Sub New(ByVal _filename As String, ByVal _newFilename As String)
        filename = _filename
        newFilename = _newFilename
    End Sub

    'store pdf data in bytes array
    Public Function GetPdfData(ByRef _errMsg As String) As Boolean
        If File.Exists(filename) Then
            Try
                pdfReader = New PdfReader(filename)
                pdfStamper = New PdfStamper(pdfReader, New FileStream( _
                    newFilename, FileMode.Create))

                pdfFormFields = pdfStamper.AcroFields
                Return True
            Catch ex As Exception
                _errMsg = "Unable to create PDF file " & newFilename
                Return False
            End Try
        Else
            _errMsg = "PDF template is missing."
            Return False
        End If
    End Function
#End Region

#Region "Get Variable Value"
    Public Sub AdhocUpdate(ByVal _param As String, ByVal value As String)
        pdfFormFields.SetField(_param, value)
    End Sub
    'update pdf's object Username
    Public Sub ReceiptNo(ByVal value As String)
        pdfFormFields.SetField(searchParam(0), value)
    End Sub
    'update pdf's object user account
    Public Sub ReceiptDate(ByVal value As String)
        pdfFormFields.SetField(searchParam(1), value)
    End Sub
    'update pdf's object user account
    Public Sub RoomNo(ByVal value As String)
        pdfFormFields.SetField(searchParam(2), value)
    End Sub
    'update pdf's object user account
    Public Sub Name(ByVal value As String)
        pdfFormFields.SetField(searchParam(3), value)
    End Sub
    'update pdf's object user account
    Public Sub Paid(ByVal value As String)
        pdfFormFields.SetField(searchParam(4), value)
    End Sub
    'update pdf's object user account
    Public Sub Balance(ByVal value As String)
        pdfFormFields.SetField(searchParam(5), value)
    End Sub
    'update pdf's object user account
    Public Sub RoomType(ByVal value As String)
        pdfFormFields.SetField(searchParam(6), value)
    End Sub
    Public Sub UnitPrice(ByVal value As String)
        pdfFormFields.SetField(searchParam(7), value)
    End Sub
    Public Sub Days(ByVal value As String)
        pdfFormFields.SetField(searchParam(8), value)
    End Sub
    Public Sub Price(ByVal value As String)
        pdfFormFields.SetField(searchParam(9), value)
    End Sub
    Public Sub CheckInDate(ByVal value As String)
        pdfFormFields.SetField(searchParam(10), value)
    End Sub
    Public Sub GuestIC(ByVal value As String)
        pdfFormFields.SetField(searchParam(11), value)
    End Sub
    Public Sub GuestAddress(ByVal value As String)
        pdfFormFields.SetField(searchParam(12), value)
    End Sub
    Public Sub PaidAmount(ByVal value As String)
        pdfFormFields.SetField(searchParam(13), value)
    End Sub
#End Region

#Region "Return PDF"
    'return the modified pdf (bytes array) data
    Public Sub Output()
        pdfStamper.FormFlattening = True
        pdfStamper.Close()
        pdfStamper.Dispose()
        pdfReader.Dispose()
        pdfFormFields = Nothing
        pdfStamper = Nothing
        pdfReader = Nothing
    End Sub
#End Region

End Class
