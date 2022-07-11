Public Class PriorityQueue(Of T) : Inherits Queue(Of IComparable)

    Public Overrides Sub Enqueue(NewItem As IComparable)
        Dim Moved As Boolean = False
        Dim NextElement As QueueElement = GetFirst()
        Dim PreviousElement As QueueElement = Nothing
        While NextElement IsNot Nothing
            If NewItem.CompareTo(NextElement.GetData()) <= 0 Then
                Dim Temp As QueueElement = New QueueElement(NewItem)
                Temp.SetNext(NextElement)
                If Not Moved Then
                    SetFirst(Temp)
                Else
                    PreviousElement.SetNext(Temp)
                End If
                Return
            Else
                Moved = True
                PreviousElement = NextElement
                NextElement = NextElement.GetNext()

            End If
        End While
        MyBase.Enqueue(NewItem)
    End Sub

End Class