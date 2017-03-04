<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uiRoomControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblRoomNo = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.roomType = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.lblRoomType = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblRoomNo
        '
        Me.lblRoomNo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblRoomNo.Location = New System.Drawing.Point(0, 64)
        Me.lblRoomNo.Name = "lblRoomNo"
        Me.lblRoomNo.Size = New System.Drawing.Size(85, 16)
        Me.lblRoomNo.TabIndex = 0
        Me.lblRoomNo.Text = "-"
        Me.lblRoomNo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.roomType})
        Me.ShapeContainer1.Size = New System.Drawing.Size(85, 80)
        Me.ShapeContainer1.TabIndex = 1
        Me.ShapeContainer1.TabStop = False
        '
        'roomType
        '
        Me.roomType.FillColor = System.Drawing.Color.LawnGreen
        Me.roomType.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.roomType.Location = New System.Drawing.Point(25, 30)
        Me.roomType.Name = "roomType"
        Me.roomType.Size = New System.Drawing.Size(33, 31)
        '
        'lblRoomType
        '
        Me.lblRoomType.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblRoomType.Location = New System.Drawing.Point(0, 0)
        Me.lblRoomType.Name = "lblRoomType"
        Me.lblRoomType.Size = New System.Drawing.Size(85, 29)
        Me.lblRoomType.TabIndex = 2
        Me.lblRoomType.Text = "-"
        Me.lblRoomType.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'uiRoomControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblRoomType)
        Me.Controls.Add(Me.lblRoomNo)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "uiRoomControl"
        Me.Size = New System.Drawing.Size(85, 80)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblRoomNo As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents roomType As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents lblRoomType As System.Windows.Forms.Label

End Class
