Imports ChatRoom

Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.IO

<TestClass()> Public Class ChatRoomUnitTest

    <TestMethod()> Public Sub groupGranularityTest()

        Dim testdata As New StringBuilder()
        testdata.AppendLine("2014/07/16 01:12:44,ENTER,Laura")
        testdata.AppendLine("2014/07/16 01:44:23,ENTER,Oliva")
        testdata.AppendLine("2014/07/16 02:05:21,COMMENT,Ryan,""What does that mean?""")
        testdata.AppendLine("2014/07/16 02:16:36,ENTER,Ryan")
        testdata.AppendLine("2014/07/16 06:50:47,HIGHFIVE,Jill,Maria")
        testdata.AppendLine("2014/07/16 08:03:34,HIGHFIVE,Maria,Laura")
        testdata.AppendLine("2014/07/16 10:06:30,HIGHFIVE,George,Ryan")
        testdata.AppendLine("2014/07/16 10:18:07,ENTER,Travis")
        testdata.AppendLine("2014/07/16 10:32:09,COMMENT,George,""I would like a table near to the window.""")
        testdata.AppendLine("2014/07/16 10:37:20,ENTER,Kevin")
        testdata.AppendLine("2014/07/16 10:45:13,ENTER,Laura")
        testdata.AppendLine("2014/07/16 11:40:40,COMMENT,Oliva,""I would like to change flights.""")
        testdata.AppendLine("2014/07/16 12:28:22,ENTER,David")
        testdata.AppendLine("2014/07/16 12:43:07,HIGHFIVE,Laura,Kevin")
        testdata.AppendLine("2014/07/16 14:11:35,HIGHFIVE,George,Frank")
        testdata.AppendLine("2014/07/16 15:42:56,COMMENT,Frank,""A dog is man's best-friend.""")
        testdata.AppendLine("2014/07/16 18:37:05,COMMENT,Jill,""Where's the nearest railway station?""")
        testdata.AppendLine("2014/07/16 18:38:33,COMMENT,Sarah,""I have two sisters.""")
        testdata.AppendLine("2014/07/16 19:19:40,LEAVE,Bob")
        testdata.AppendLine("2014/07/16 20:10:21,HIGHFIVE,Oliva,Travis")
        testdata.AppendLine("2014/07/16 20:35:52,LEAVE,Frank")
        testdata.AppendLine("2014/07/16 22:02:28,LEAVE,Bob")
        testdata.AppendLine("2014/07/16 22:34:35,ENTER,Laura")
        testdata.AppendLine("2014/07/16 22:38:08,ENTER,George")
        testdata.AppendLine("2014/07/16 23:51:46,ENTER,Erin")


        Using outfile As New StreamWriter("groupGranularityTest.log")
            outfile.Write(testdata)
        End Using

        Dim validEvents As New List(Of ChatRoom.EventTypes)
        validEvents.Add(EventTypes.COMMENT)
        validEvents.Add(EventTypes.LEAVE)
        validEvents.Add(EventTypes.ENTER)
        validEvents.Add(EventTypes.HIGHFIVE)
        Dim result As String = ChatRoom.groupGranularity("groupGranularityTest.log", GetType(Hourly), validEvents)

        Dim sbExpected As New StringBuilder()
        sbExpected.AppendLine("07/16 1AM:")
        sbExpected.AppendLine(vbTab & "2 people entered")
        sbExpected.AppendLine("")
        sbExpected.AppendLine("07/16 2AM:")
        sbExpected.AppendLine(vbTab & "1 person entered")
        sbExpected.AppendLine("")
        sbExpected.AppendLine("07/16 8AM:")
        sbExpected.AppendLine(vbTab & "1 person high-fived 1 other person")
        sbExpected.AppendLine("")
        sbExpected.AppendLine("07/16 10AM:")
        sbExpected.AppendLine(vbTab & "3 people entered")
        sbExpected.AppendLine(vbTab & "1 comment")
        sbExpected.AppendLine("")
        sbExpected.AppendLine("07/16 12PM:")
        sbExpected.AppendLine(vbTab & "1 person entered")
        sbExpected.AppendLine(vbTab & "1 person high-fived 1 other person")
        sbExpected.AppendLine("")
        sbExpected.AppendLine("07/16 3PM:")
        sbExpected.AppendLine(vbTab & "1 comment")
        sbExpected.AppendLine("")
        sbExpected.AppendLine("07/16 6PM:")
        sbExpected.AppendLine(vbTab & "1 comment")
        sbExpected.AppendLine("")
        sbExpected.AppendLine("07/16 8PM:")
        sbExpected.AppendLine(vbTab & "1 left")
        sbExpected.AppendLine(vbTab & "1 person high-fived 1 other person")
        sbExpected.AppendLine("")
        sbExpected.AppendLine("07/16 10PM:")
        sbExpected.AppendLine(vbTab & "2 people entered")
        sbExpected.AppendLine("")
        sbExpected.AppendLine("07/16 10PM:")
        sbExpected.AppendLine(vbTab & "2 people entered")
        sbExpected.AppendLine("")

        Dim expected As String = sbExpected.ToString()

        Assert.AreEqual(expected, result, "GroupGranularity is not equal")
    End Sub

End Class