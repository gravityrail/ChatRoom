Imports System.Text

Public Module ChatLogParser
    ''' <summary>
    ''' returns event data seperated by the granularity selected in the combo box
    ''' </summary>
    ''' <remarks></remarks>
    Public Function groupGranularity(filename As String, granularityType As Type, validEvents As List(Of ChatEnums.EventTypes)) As String
        Dim result As New StringBuilder
        Dim inputLine As String
        Dim startNewGroup As Boolean = True
        Dim group As Granularity = Nothing
        Using objReader As New System.IO.StreamReader(filename)
            Do While objReader.Peek() <> -1
                inputLine = objReader.ReadLine()
                Dim cEvent As New ChatEvent(inputLine)  ' populate a ChatEvent object using the input line
                If IsValidEvent(cEvent.EventType, validEvents) Then ' checks if the event is valid based on filter options selected by user
                    If startNewGroup Then   'if a new group is needed create group based on selected granularity 
                        Dim parameters(0) As Object
                        parameters(0) = cEvent.Time
                        group = System.Activator.CreateInstance(granularityType, New Object() {cEvent.Time})
                        startNewGroup = False
                    End If
                    If group IsNot Nothing Then
                        If cEvent.Time < group.nextGroupTime Then ' if the event takes place within the current group add it to the group
                            group.addEvent(cEvent)
                        Else
                            result.AppendLine(group.GetGroupString()) ' otherwise output the group and start a new one
                            startNewGroup = True
                        End If
                    End If
                End If
            Loop
        End Using
        If group IsNot Nothing Then ' display last group data
            result.AppendLine(group.GetGroupString())
        End If
        Return result.ToString
    End Function

    ''' <summary>
    ''' displays all events that are valid based on filter options selected by user
    ''' </summary>
    ''' <remarks> uses the assumption that minute granularity displays all events</remarks>
    Public Function allEventsGranularity(filename As String, validEvents As List(Of ChatEnums.EventTypes)) As String
        Dim result As New StringBuilder
        Dim inputLine As String
        Using objReader As New System.IO.StreamReader(filename)
            Do While objReader.Peek() <> -1
                inputLine = objReader.ReadLine()
                Dim cEvent As New ChatEvent(inputLine)
                If IsValidEvent(cEvent.EventType, validEvents) Then ' checks if the event is valid based on filter options selected by user
                    result.AppendLine(cEvent.ToString)
                End If
            Loop
        End Using
        Return result.ToString()
    End Function

    Private Function IsValidEvent(theEvent As ChatEnums.EventTypes, validEvents As List(Of ChatEnums.EventTypes)) As Boolean
        Return validEvents.Contains(theEvent)
    End Function
End Module
