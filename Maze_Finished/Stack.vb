Public Class Stack(Of T)

    Private Top As StackElement             'Top element of the stack

    Private Class StackElement              'Elements that make up the stack

        Private Data As T                   'The data stored in each element
        Private Below As StackElement       'The element below this one

        Public Sub New(NewData As T)
            Data = NewData
        End Sub

        Public Sub New(NewData As T, NewBelow As StackElement)
            Data = NewData
            Below = NewBelow
        End Sub

        Public Function GetData() As T
            Return Data
        End Function

        Public Function GetBelow() As StackElement
            Return Below
        End Function
    End Class

    Public Sub Push(NewItem As T)
        If Top Is Nothing Then
            Top = New StackElement(NewItem)
        Else
            Top = New StackElement(NewItem, Top)
        End If
    End Sub

    Public Function Pop() As T
        Dim Temp As T = Top.GetData()
        Top = Top.GetBelow()
        Return Temp
    End Function

    Public Function IsEmpty() As Boolean
        Return (Top Is Nothing)
    End Function

End Class