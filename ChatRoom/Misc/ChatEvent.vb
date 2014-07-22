''' <summary>
''' Class used to hold information about a chat event
''' </summary>
''' <remarks></remarks>
Public Class ChatEvent
    Private _time As Date
    Private _user As String
    Private _eventType As EventTypes
    Private _text As String

    Sub New(line As String)
        Try
            Dim values = line.Split(",")
            Me.Time = values(0)
            Me.EventType = [Enum].Parse(GetType(EventTypes), values(1))
            Me.User = values(2)
            If values.Count > 3 Then
                For i = 3 To values.Count - 1
                    Me.Text += values(i)
                Next
            Else
                Me.Text = ""
            End If
        Catch e As Exception
            MessageBox.Show("invalid input")
        End Try
    End Sub

    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <param name="t">Time of event</param>
    ''' <param name="u">User name</param>
    ''' <param name="e">Event type</param>
    ''' <param name="txt">Additional information</param>
    ''' <remarks></remarks>
    Sub New(t As Date, u As String, e As EventTypes, Optional txt As String = "")
        Me._time = t
        Me._user = u
        Me._eventType = e
        Me._text = txt
    End Sub

    Public Property Time As Date
        Get
            Return Me._time
        End Get
        Set(value As Date)
            Me._time = value
        End Set
    End Property

    Public Property User As String
        Get
            Return Me._user
        End Get
        Set(value As String)
            Me._user = value
        End Set
    End Property

    Public Property EventType As EventTypes
        Get
            Return Me._eventType
        End Get
        Set(value As EventTypes)
            Me._eventType = value
        End Set
    End Property

    Public Property Text As String
        Get
            Return Me._text
        End Get
        Set(value As String)
            Me._text = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Dim ev As String = ""
        Select Case Me.EventType
            Case EventTypes.COMMENT
                ev = "comments:"
            Case EventTypes.ENTER
                ev = "enters"
            Case EventTypes.HIGHFIVE
                ev = "high-fives"
            Case EventTypes.LEAVE
                ev = "leaves"
        End Select
        Return Me.Time.ToString() & ": " & Me.User & " " & ev & " " & Me.Text
    End Function
End Class
