Public Class Hourly
    Inherits Granularity

    Public Sub New(initialDate As Date)
        Me.adjustedDate = New Date(initialDate.Ticks - initialDate.Ticks Mod (Me.SecondsInGroup * 10000000L))
        Me.nextGroupTime = adjustedDate.AddSeconds(SecondsInGroup)
    End Sub

    Public Overrides Function GetGroupString() As String
        Dim result As String = GetTitle()

        For Each item In MyBase.eventToOccurrence
            Dim line As String = vbTab
            Dim noun As String
            If item.Value > 1 Then
                noun = "people"
            Else
                noun = "person"
            End If
            Select Case item.Key
                Case EventTypes.COMMENT
                    If item.Value > 1 Then
                        line += item.Value & " comments"
                    Else
                        line += item.Value & " comment"
                    End If
                Case EventTypes.ENTER
                    line += item.Value & " " & noun & " entered"
                Case EventTypes.HIGHFIVE
                    line += "1 person high-fived " & item.Value & " other " & noun
                Case EventTypes.LEAVE
                    line += item.Value & " left"
            End Select
            If item.Value <> 0 Then
                result += line & vbCrLf
            End If
        Next
        Return result
    End Function

    Protected Overrides Function GetTitle() As String
        Return Me.adjustedDate.ToString("MM/dd htt") & ":" & vbCrLf
    End Function

    Protected Overrides ReadOnly Property SecondsInGroup As Integer
        Get
            Return 60 * 60
        End Get
    End Property
End Class
