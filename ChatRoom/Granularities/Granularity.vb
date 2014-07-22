''' <summary>
''' Granualarity abstract class used to define new granularities 
''' Allows for custom titles and granularity group output.
''' </summary>
''' <remarks></remarks>
Public MustInherit Class Granularity
    ''' <summary>
    ''' Time that granularity starts
    ''' </summary>
    ''' <remarks></remarks>
    Protected adjustedDate As Date

    ''' <summary>
    ''' Total number of seconds in this granularity group
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected MustOverride ReadOnly Property SecondsInGroup As Integer

    ''' <summary>
    ''' Returns formated string of granularity group title
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected MustOverride Function GetTitle() As String

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected eventToOccurrence As Dictionary(Of EventTypes, Integer) ' dictionary between event types and number of occurrence

    'Protected groupTitle As String ' title of granularity group

    Public Property nextGroupTime As Date   ' time that the next group will begin

    Public Sub New()

    End Sub

    ''' <summary>
    ''' Constructor that creates a granularity group based on time of first event in group
    ''' </summary>
    ''' <param name="initialDate"></param>
    ''' <remarks></remarks>
    Public Sub New(initialDate As Date)
        Me.adjustedDate = New Date(initialDate.Ticks - initialDate.Ticks Mod (Me.SecondsInGroup * 10000000L))
        Me.nextGroupTime = adjustedDate.AddSeconds(Me.SecondsInGroup)
    End Sub

    ''' <summary>
    ''' Returns a formated string for the granularity group
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public MustOverride Function GetGroupString() As String

    ''' <summary>
    ''' Adds an event to the granularity group 
    ''' </summary>
    ''' <param name="cEvent"></param>
    ''' <remarks></remarks>
    Public Sub addEvent(cEvent As ChatEvent)
        If Me.eventToOccurrence Is Nothing Then
            Me.eventToOccurrence = New Dictionary(Of EventTypes, Integer)
            For Each name In System.Enum.GetValues(GetType(EventTypes))
                Me.eventToOccurrence.Add(name, 0)
            Next
        End If
        If Me.eventToOccurrence.ContainsKey(cEvent.EventType) Then
            Me.eventToOccurrence(cEvent.EventType) += 1
        End If
    End Sub
End Class
