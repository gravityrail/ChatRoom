Imports System.IO
Imports System.Text

Public Class GenerateDataForm

    Private phraseList As List(Of String)

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Dim sfd As New SaveFileDialog()

        If ValidateInput() Then
            sfd.Title = "Save an Image File"
            sfd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath)
            sfd.Filter = "Log files (*.log)|*.log|All files (*.*)|*.*"
            sfd.DefaultExt = "log"
            sfd.ShowDialog()
            If sfd.FileName <> "" Then
                GenerateData(sfd.FileName, Me.dtpStart.Value, Me.dtpEnd.Value, Me.tbEvents.Text)
                Me.Close()
            End If
        End If
    End Sub

   

    Private Sub GenereateDataForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.dtpStart.Value = Today
        Me.dtpEnd.Value = Today.AddDays(1)
    End Sub

    Private Function ValidateInput() As Boolean
        Dim avg As Integer
        Dim valid As Boolean = Integer.TryParse(Me.tbEvents.Text, avg)

        If (Not valid) OrElse avg <= 0 Then
            MessageBox.Show("Average must be a positive integer")
            Return False
        Else
            If Me.dtpEnd.Value <= Me.dtpStart.Value Then
                MessageBox.Show("Start date must be before end date")
                Return False
            End If
        End If
        Return True
    End Function

    

End Class