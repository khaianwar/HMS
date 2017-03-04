Imports System.Configuration

Public Class frmAdmin
    Private _errMessage As String = String.Empty
    Private maintenanceBLL As BLL.MaintenanceBLL = Nothing

    Private Sub frmAdmin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        SetupForm()
        txtPwd.Focus()
    End Sub

    Private Sub SetupForm()
        Me.Size = New Size(435, 129)
        gpRoom.Visible = False
        gpLogin.Visible = True
        gpLogin.Location = New Point(12, 12)
        gpRoom.Location = New Point(12, 12)
    End Sub

    Private Sub SetupFeatures()
        Me.MinimumSize = New Size(435, 365)
        gpRoom.Visible = True
        gpLogin.Visible = False
    End Sub

    Private Sub txtPwd_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPwd.KeyDown
        If e.KeyCode = Keys.Enter Then
            GetAdminFeature()
        End If
    End Sub

    Private Function ValidatePassword(ByVal pwd As String) As Boolean
        If pwd = "ss2016" Then
            Return True
        End If
        Return False
    End Function

    Private Sub btnLogin_Click(sender As System.Object, e As System.EventArgs) Handles btnLogin.Click
        GetAdminFeature()
    End Sub

    Private Sub GetAdminFeature()
        If ValidatePassword(txtPwd.Text) Then
            SetupFeatures()
            SetupRoom()
        Else
            MessageBox.Show("Invalid password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub SetupRoom()
        Dim dsRoom As DataSet = Nothing
        maintenanceBLL = New BLL.MaintenanceBLL(ConfigurationManager.ConnectionStrings("DBConnection").ConnectionString)
        dgvRoom.DataSource = maintenanceBLL.GetRoomPrices()
        dgvRoom.DataMember = "HMS_Room"
        For Each dgCol As DataGridViewColumn In dgvRoom.Columns
            If dgCol.Name <> "Price" Then
                dgCol.ReadOnly = True
                If dgCol.Name = "ID" Then
                    dgCol.Visible = False
                End If
            End If
        Next
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If MessageBox.Show("Save changes ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            If UpdateToDatabase() Then
                MessageBox.Show("Success !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show(String.Format("Failed !{0}{1}", vbCrLf, _errMessage), "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Function UpdateToDatabase() As Boolean
        Dim updateSuccess As Boolean = True
        Try
            maintenanceBLL.UpdateHMS_RoomPrice(dgvRoom.DataSource)
        Catch ex As Exception
            _errMessage = ex.Message
            updateSuccess = False
        End Try
        Return updateSuccess
    End Function
End Class