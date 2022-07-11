Public Class Queue(Of T)

    Private First As QueueElement
    Private Last As QueueElement

    Protected Class QueueElement                'Elements that make up the Queue

        Private Data As T                       'The data stored in each element
        Private NextElement As QueueElement     'The element after this one

        Public Sub New(NewData As T)
            Data = NewData
        End Sub

        Public Function GetData() As T
            Return Data
        End Function

        Public Function GetNext() As QueueElement
            Return NextElement
        End Function

        Public Sub SetNext(NewNext As QueueElement)
            NextElement = NewNext
        End Sub

        Public Function CountHelper() As Integer
            If NextElement Is Nothing Then Return 1 Else Return 1 + NextElement.CountHelper()
        End Function
    End Class

    Public Function Count() As Integer
        If First Is Nothing Then Return 0 Else Return First.CountHelper()
    End Function

    Protected Function GetFirst() As QueueElement
        Return First
    End Function

    Protected Sub SetFirst(NewFirst As QueueElement)
        First = NewFirst
    End Sub

    Public Overridable Sub Enqueue(NewItem As T)
        If First Is Nothing Then
            Last = New QueueElement(NewItem)
            First = Last
        Else
            Dim Temp = New QueueElement(NewItem)
            Last.SetNext(Temp)
            Last = Temp
        End If
    End Sub

    Public Function Dequeue() As T
        Dim Temp As T = First.GetData()
        First = First.GetNext()
        Return Temp
    End Function

    Public Function IsEmpty() As Boolean
        Return First Is Nothing
    End Function

End Class