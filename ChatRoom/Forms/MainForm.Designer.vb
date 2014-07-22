<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.gbMain = New System.Windows.Forms.GroupBox()
        Me.tbOutput = New System.Windows.Forms.TextBox()
        Me.comboGranualarity = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbHighFive = New System.Windows.Forms.CheckBox()
        Me.cbComment = New System.Windows.Forms.CheckBox()
        Me.cbLeave = New System.Windows.Forms.CheckBox()
        Me.cbEnter = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbFileLocation = New System.Windows.Forms.TextBox()
        Me.btnOpenFile = New System.Windows.Forms.Button()
        Me.gbMain.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(13, 13)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(133, 23)
        Me.btnGenerate.TabIndex = 0
        Me.btnGenerate.Text = "Generate Test Data"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'gbMain
        '
        Me.gbMain.Controls.Add(Me.tbOutput)
        Me.gbMain.Controls.Add(Me.comboGranualarity)
        Me.gbMain.Controls.Add(Me.Label2)
        Me.gbMain.Controls.Add(Me.GroupBox2)
        Me.gbMain.Enabled = False
        Me.gbMain.Location = New System.Drawing.Point(13, 84)
        Me.gbMain.Name = "gbMain"
        Me.gbMain.Size = New System.Drawing.Size(573, 385)
        Me.gbMain.TabIndex = 1
        Me.gbMain.TabStop = False
        Me.gbMain.Text = "Chat History"
        '
        'tbOutput
        '
        Me.tbOutput.Location = New System.Drawing.Point(9, 71)
        Me.tbOutput.Multiline = True
        Me.tbOutput.Name = "tbOutput"
        Me.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbOutput.Size = New System.Drawing.Size(543, 308)
        Me.tbOutput.TabIndex = 3
        '
        'comboGranualarity
        '
        Me.comboGranualarity.FormattingEnabled = True
        Me.comboGranualarity.Location = New System.Drawing.Point(67, 36)
        Me.comboGranualarity.Name = "comboGranualarity"
        Me.comboGranualarity.Size = New System.Drawing.Size(121, 21)
        Me.comboGranualarity.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Granularity"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbHighFive)
        Me.GroupBox2.Controls.Add(Me.cbComment)
        Me.GroupBox2.Controls.Add(Me.cbLeave)
        Me.GroupBox2.Controls.Add(Me.cbEnter)
        Me.GroupBox2.Location = New System.Drawing.Point(194, 20)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(365, 45)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filter"
        '
        'cbHighFive
        '
        Me.cbHighFive.AutoSize = True
        Me.cbHighFive.Checked = True
        Me.cbHighFive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbHighFive.Location = New System.Drawing.Point(292, 20)
        Me.cbHighFive.Name = "cbHighFive"
        Me.cbHighFive.Size = New System.Drawing.Size(66, 17)
        Me.cbHighFive.TabIndex = 3
        Me.cbHighFive.Text = "high-five"
        Me.cbHighFive.UseVisualStyleBackColor = True
        '
        'cbComment
        '
        Me.cbComment.AutoSize = True
        Me.cbComment.Checked = True
        Me.cbComment.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbComment.Location = New System.Drawing.Point(217, 20)
        Me.cbComment.Name = "cbComment"
        Me.cbComment.Size = New System.Drawing.Size(69, 17)
        Me.cbComment.TabIndex = 2
        Me.cbComment.Text = "comment"
        Me.cbComment.UseVisualStyleBackColor = True
        '
        'cbLeave
        '
        Me.cbLeave.AutoSize = True
        Me.cbLeave.Checked = True
        Me.cbLeave.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbLeave.Location = New System.Drawing.Point(115, 19)
        Me.cbLeave.Name = "cbLeave"
        Me.cbLeave.Size = New System.Drawing.Size(96, 17)
        Me.cbLeave.TabIndex = 1
        Me.cbLeave.Text = "leave-the-room"
        Me.cbLeave.UseVisualStyleBackColor = True
        '
        'cbEnter
        '
        Me.cbEnter.AutoSize = True
        Me.cbEnter.Checked = True
        Me.cbEnter.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbEnter.Location = New System.Drawing.Point(15, 19)
        Me.cbEnter.Name = "cbEnter"
        Me.cbEnter.Size = New System.Drawing.Size(94, 17)
        Me.cbEnter.TabIndex = 0
        Me.cbEnter.Text = "enter-the-room"
        Me.cbEnter.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Log File Location"
        '
        'tbFileLocation
        '
        Me.tbFileLocation.Location = New System.Drawing.Point(108, 43)
        Me.tbFileLocation.Name = "tbFileLocation"
        Me.tbFileLocation.ReadOnly = True
        Me.tbFileLocation.Size = New System.Drawing.Size(278, 20)
        Me.tbFileLocation.TabIndex = 3
        '
        'btnOpenFile
        '
        Me.btnOpenFile.Location = New System.Drawing.Point(393, 43)
        Me.btnOpenFile.Name = "btnOpenFile"
        Me.btnOpenFile.Size = New System.Drawing.Size(75, 23)
        Me.btnOpenFile.TabIndex = 4
        Me.btnOpenFile.Text = "Select File"
        Me.btnOpenFile.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(855, 720)
        Me.Controls.Add(Me.btnOpenFile)
        Me.Controls.Add(Me.tbFileLocation)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gbMain)
        Me.Controls.Add(Me.btnGenerate)
        Me.Name = "MainForm"
        Me.Text = "Chat Room"
        Me.gbMain.ResumeLayout(False)
        Me.gbMain.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents gbMain As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbFileLocation As System.Windows.Forms.TextBox
    Friend WithEvents btnOpenFile As System.Windows.Forms.Button
    Friend WithEvents comboGranualarity As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbHighFive As System.Windows.Forms.CheckBox
    Friend WithEvents cbComment As System.Windows.Forms.CheckBox
    Friend WithEvents cbLeave As System.Windows.Forms.CheckBox
    Friend WithEvents cbEnter As System.Windows.Forms.CheckBox
    Friend WithEvents tbOutput As System.Windows.Forms.TextBox

End Class
