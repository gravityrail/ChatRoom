Imports System.IO
Imports System.Text

Public Class MainForm


    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Dim gdf As New GenerateDataForm()
        gdf.Show()
    End Sub

    Private Sub btnOpenFile_Click(sender As Object, e As EventArgs) Handles btnOpenFile.Click
        Dim ofd As New OpenFileDialog()
        ofd.Title = "Save an Image File"
        ofd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath)
        ofd.Filter = "Log files (*.log)|*.log|All files (*.*)|*.*"
        ofd.DefaultExt = "log"
        ofd.ShowDialog()
        Me.tbFileLocation.Text = ofd.FileName
        Me.gbMain.Enabled = True
        PopulateTextBox()
    End Sub

    ''' <summary>
    ''' Populates the granularity combo box ba
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim subclasses = GetAllSubclassesOf(GetType(Granularity))
        If subclasses IsNot Nothing AndAlso subclasses.Count > 0 Then
            Me.comboGranualarity.Items.AddRange(subclasses)
            Me.comboGranualarity.DisplayMember = "Name"
            Me.comboGranualarity.ValueMember = "FullName"
        End If
        Me.comboGranualarity.Items.Add("Minute")
        Me.comboGranualarity.SelectedItem = "Minute"

    End Sub

    ''' <summary>
    ''' Fills the main text box with data based on the current selections of the user
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PopulateTextBox()
        If File.Exists(Me.tbFileLocation.Text) Then
            Me.tbOutput.Text = ""   ' reset the box to empty
            Select Case Me.comboGranualarity.Text
                Case "Minute"    ' under the assumption that minute granularity displays all events ungrouped
                    Me.tbOutput.Text = allEventsGranularity(Me.tbFileLocation.Text, GetValidEvents())
                Case Else
                    Me.tbOutput.Text = groupGranularity(Me.tbFileLocation.Text, Me.comboGranualarity.SelectedItem, GetValidEvents())
            End Select
        End If
    End Sub

    

   

    ''' <summary>
    ''' checks status of check boxes and filters events 
    ''' </summary>
    ''' <param name="lines"></param>
    ''' <returns></returns>
    ''' <remarks> checks the 20th character, this is based on the format of the data file. This will be an issue 
    ''' if there are two events with that start with the same character.</remarks>
    Private Function GetValidEvents() As List(Of EventTypes)
        Dim valid As New List(Of EventTypes)
        If Me.cbComment.Checked Then
            valid.Add(EventTypes.COMMENT)
        End If
        If Me.cbEnter.Checked Then
            valid.Add(EventTypes.ENTER)
        End If
        If Me.cbLeave.Checked Then
            valid.Add(EventTypes.LEAVE)
        End If
        If Me.cbHighFive.Checked Then
            valid.Add(EventTypes.HIGHFIVE)
        End If
        Return valid
    End Function

    Private Sub cbEnter_CheckedChanged(sender As Object, e As EventArgs) Handles cbEnter.CheckedChanged
        PopulateTextBox()
    End Sub

    Private Sub cbLeave_CheckedChanged(sender As Object, e As EventArgs) Handles cbLeave.CheckedChanged
        PopulateTextBox()
    End Sub

    Private Sub cbComment_CheckedChanged(sender As Object, e As EventArgs) Handles cbComment.CheckedChanged
        PopulateTextBox()
    End Sub

    Private Sub cbHighFive_CheckedChanged(sender As Object, e As EventArgs) Handles cbHighFive.CheckedChanged
        PopulateTextBox()
    End Sub

    Private Sub comboGranualarity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboGranualarity.SelectedIndexChanged
        PopulateTextBox()
    End Sub

    ''' <summary>
    ''' returns an array of all subclasses of type baseType
    ''' </summary>
    ''' <param name="baseType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetAllSubclassesOf(baseType As Type) As Type()
        Return (From t In System.Reflection.Assembly.GetAssembly(baseType).GetTypes() Where t.IsSubclassOf(baseType) Select t).ToArray
    End Function
End Class
