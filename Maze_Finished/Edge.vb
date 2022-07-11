''' <summary>
''' All the info you need about an edge
''' </summary>
Public Structure Edge : Implements IComparable
    Dim Weight As Integer
    Dim Selected As Boolean                 'Has the edge been put in the Queue?
    Dim Used As Boolean                     'Has the edge been used to create the minimum spanning tree?
    Dim EdgeCoordinate As Coordinate        'Where does it lie in its edge array
    Dim NodeItWillConnectTo As Coordinate   'Which node the edge will connect to when selected in Prim's
    Dim Orientation As Orientation          'Which way it points

    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        Return Weight - (CType(obj, Edge)).Weight
    End Function
End Structure
