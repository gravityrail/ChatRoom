Imports System.IO

''' <summary>
''' Module to generate a test chat log based on values of user input
''' </summary>
''' <remarks></remarks>
Public Module DataGenerator
    ''' <summary>
    ''' Generates random data as comma seperated values and stores into a file
    ''' </summary>
    ''' <param name="filename"></param>
    ''' <param name="sDate"></param>
    ''' <param name="eDate"></param>
    ''' <param name="avg"></param>
    ''' <remarks>Format of data "yyyy/MM/dd HH:mm:ss,[eventType],[user name],[additional text]"</remarks>
    Public Sub GenerateData(filename As String, sDate As Date, eDate As Date, avg As Integer)
        Dim phraseList As List(Of String) = GetPhraseList()
        Randomize()
        Dim numberOfHours = (eDate.Ticks - sDate.Ticks) / 10000000 / 60 / 60
        Dim numberOfEvents As Integer = numberOfHours * avg

        Dim eventList As New List(Of String)
        For i = 0 To numberOfEvents
            Dim eventType As ChatEnums.EventTypes = Int(Rnd() * 4)
            Dim eventTime As Date = sDate.AddSeconds(Int(Rnd() * numberOfHours * 60 * 60))
            Dim user As ChatEnums.UserNames = Int(Rnd() * 20)
            Dim line As String = eventTime.ToString("yyyy/MM/dd HH:mm:ss") & "," & eventType.ToString() & "," & user.ToString()
            Select Case eventType
                Case EventTypes.COMMENT
                    line += "," & phraseList(Rnd() * (phraseList.Count - 1))
                Case EventTypes.HIGHFIVE
                    Dim user2 As ChatEnums.UserNames = Int(Rnd() * 20)
                    line += "," & user2.ToString()
            End Select
            eventList.Add(line)
        Next
        eventList.Sort()
        Using outfile As New StreamWriter(filename)
            For Each line In eventList
                outfile.WriteLine(line)
            Next
        End Using
    End Sub

    ''' <summary>
    ''' random phrases to use as comments
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPhraseList() As List(Of String)
        Dim phraseList As New List(Of String)
        phraseList.Add("""I have two sisters.""")
        phraseList.Add("""I have a headache.""")
        phraseList.Add("""Oh, typical""")
        phraseList.Add("""He broke the window.""")
        phraseList.Add("""I have got a puncture.""")
        phraseList.Add("""Where is the baker's?""")
        phraseList.Add("""There is a bomb alert.""")
        phraseList.Add("""A dog is man's best-friend.""")
        phraseList.Add("""My son is a cold-hearted gangster, and I need a hug.""")
        phraseList.Add("""The train has already gone, would you like to hire a bicycle?""")
        phraseList.Add("""I love your long blonde hair.""")
        phraseList.Add("""What does that mean?""")
        phraseList.Add("""Which counter do I go to to change money?""")
        phraseList.Add("""Fasten your seat belts, please.""")
        phraseList.Add("""Here is the key for room number 5.""")
        phraseList.Add("""I am good at Chemistry.""")
        phraseList.Add("""Where's the nearest railway station?""")
        phraseList.Add("""I would like a table near to the window.""")
        phraseList.Add("""Where is the reception, please?""")
        phraseList.Add("""Please check the water level.""")
        phraseList.Add("""Is there an electric connection for our caravan?""")
        phraseList.Add("""Do you have room for a tent?""")
        phraseList.Add("""I would like to change flights.""")
        phraseList.Add("""I'm very well, thank you.""")
        phraseList.Add("""What is your address?""")
        phraseList.Add("""I need some tissues.""")
        Return phraseList
    End Function
End Module
