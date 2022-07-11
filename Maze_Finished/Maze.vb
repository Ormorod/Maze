Public Class Maze

    Private Nodes(,) As Boolean                 'Records if nodes have been visited in prim's generation
    Private NodesVisited(,,) As Boolean         'NodesVisited(X,Y,Visited/backtracked over), this is for the solving
    Private HorizontalEdges(,) As Edge          'Stores details of horizontal edges
    Private VerticalEdges(,) As Edge            'Stores details of vertical edges
    Private Selected As Coordinate              'Records the currently selected node
    Private Size As Integer                     'Size numbered from 0

    Public Sub New()
        Selected.X = 0
        Selected.Y = 0
    End Sub

    Public Sub SetSize(NewSize As Integer)          'Changes the size of the maze
        Size = NewSize
        ReDim Nodes(Size, Size)
        ReDim HorizontalEdges(Size - 1, Size)
        ReDim VerticalEdges(Size, Size - 1)
    End Sub

    Public Sub SetStartCoordinate(Start As Coordinate)
        Selected = Start
    End Sub

    Public Function GetSize() As Integer
        Return Size
    End Function

    Public Function GetSelected() As Coordinate     'Currently selected node
        Return Selected
    End Function

    Public Function GetNodePartOfRoute(X As Integer, Y As Integer) As Boolean 'Returns if a node is part of the solution in progress
        Return NodesVisited(X, Y, 0)
    End Function

    Public Function GetEdgeUsed(Orientation As Orientation, X As Integer, Y As Integer)       'Returns if an edge is part of the generated maze
        If Orientation = Orientation.Horizontal Then
            Return HorizontalEdges(X, Y).Used
        Else
            Return VerticalEdges(X, Y).Used
        End If
    End Function

    Public Sub GeneratePrims(DisplayConstruction As Boolean)
        Randomize()
        'Nodes are numbered from (0,0) to (Size,Size)
        '(0,0) is top left
        'Generating the edges and their random weights
        GenerateHorizontalEdges(True)
        GenerateVerticalEdges(True)

        Nodes(Selected.X, Selected.Y) = True                    'Visiting start node

        Dim EdgesQueue As New PriorityQueue(Of Edge)            'Stores edges that are connected to the tree
        Dim AddedEdge As Edge                                   'Next edge to be added to the tree
        Dim NumberOfSelectedEdges As Integer = 0                'Counts edges until required number have been selected

        Do While Not Connected(NumberOfSelectedEdges)
            'Adding adjacent edges to edge list
            'Edge to left
            If Selected.X > 0 Then                  'Makes sure edge wouldn't go over the edge
                If Not HorizontalEdges(Selected.X - 1, Selected.Y).Selected Then                        'Makes sure edge hasn't already been selected
                    HorizontalEdges(Selected.X - 1, Selected.Y).Selected = True                             'Selects the edge
                    'This records which node the edge will connect to if selected, in this case the one to the left
                    HorizontalEdges(Selected.X - 1, Selected.Y).NodeItWillConnectTo.X = Selected.X - 1
                    HorizontalEdges(Selected.X - 1, Selected.Y).NodeItWillConnectTo.Y = Selected.Y
                    'Putting the edge into a Queue of all the edges to be sorted
                    EdgesQueue.Enqueue(HorizontalEdges(Selected.X - 1, Selected.Y))
                End If
            End If

            'Edge above
            If Selected.Y > 0 Then                  'Makes sure edge wouldn't go over the edge
                If Not VerticalEdges(Selected.X, Selected.Y - 1).Selected Then                          'Makes sure edge hasn't already been selected
                    VerticalEdges(Selected.X, Selected.Y - 1).Selected = True                               'Selects the edge
                    'This records which node the edge will connect to if selected, in this case the one to the left
                    VerticalEdges(Selected.X, Selected.Y - 1).NodeItWillConnectTo.X = Selected.X
                    VerticalEdges(Selected.X, Selected.Y - 1).NodeItWillConnectTo.Y = Selected.Y - 1
                    'Putting the edge into a Queue of all the edges to be sorted
                    EdgesQueue.Enqueue(VerticalEdges(Selected.X, Selected.Y - 1))
                End If
            End If

            'Edge to the right
            If Selected.X < Size Then               'Makes sure edge wouldn't go over the edge
                If Not HorizontalEdges(Selected.X, Selected.Y).Selected Then                            'Makes sure edge hasn't already been selected
                    HorizontalEdges(Selected.X, Selected.Y).Selected = True                                 'Selects the edge
                    'This records which node the edge will connect to if selected, in this case the one to the left
                    HorizontalEdges(Selected.X, Selected.Y).NodeItWillConnectTo.X = Selected.X + 1
                    HorizontalEdges(Selected.X, Selected.Y).NodeItWillConnectTo.Y = Selected.Y
                    'Putting the edge into a Edge of all the edges to be sorted
                    EdgesQueue.Enqueue(HorizontalEdges(Selected.X, Selected.Y))
                End If
            End If

            'Edge below
            If Selected.Y < Size Then               'Makes sure edge wouldn't go over the edge
                If Not VerticalEdges(Selected.X, Selected.Y).Selected Then                              'Makes sure edge hasn't already been selected
                    VerticalEdges(Selected.X, Selected.Y).Selected = True                                   'Selects the edge
                    'This records which node the edge will connect to if selected, in this case the one to the left
                    VerticalEdges(Selected.X, Selected.Y).NodeItWillConnectTo.X = Selected.X
                    VerticalEdges(Selected.X, Selected.Y).NodeItWillConnectTo.Y = Selected.Y + 1
                    'Putting the edge into a EdgeQueue of all the edges to be sorted
                    EdgesQueue.Enqueue(VerticalEdges(Selected.X, Selected.Y))
                End If
            End If

            AddedEdge = EdgesQueue.Dequeue          'The shortest weight edge is selected

            If Not Nodes(AddedEdge.NodeItWillConnectTo.X, AddedEdge.NodeItWillConnectTo.Y) Then         'Ensures the node isn't already in the tree
                Nodes(AddedEdge.NodeItWillConnectTo.X, AddedEdge.NodeItWillConnectTo.Y) = True              'Selects that node

                If AddedEdge.Orientation = Orientation.Horizontal Then                                      'Is the selected edge horizontal?
                    HorizontalEdges(AddedEdge.EdgeCoordinate.X, AddedEdge.EdgeCoordinate.Y).Used = True     'Use that edge
                Else                                                                                        'The edge must be vertical
                    VerticalEdges(AddedEdge.EdgeCoordinate.X, AddedEdge.EdgeCoordinate.Y).Used = True       'Use that edge
                End If

                Selected = AddedEdge.NodeItWillConnectTo            'Sets the current node to the newest node in the tree

                NumberOfSelectedEdges += 1                              'One closer to completing the tree
            End If
            If DisplayConstruction Then MazeForm.PictureBoxMaze.Refresh()

        Loop
    End Sub

    Private Sub GenerateHorizontalEdges(Prims As Boolean)

        Randomize()
        For Y = 0 To Size
            For X = 0 To Size - 1
                '0 <= Rnd() < 1 
                If Prims Then
                    HorizontalEdges(X, Y).Weight = Rnd()                    'Randomizing the weights of horizontal edges for prim's
                Else
                    HorizontalEdges(X, Y).Used = True                       'All edges start off as used for recursive division
                End If

                HorizontalEdges(X, Y).Orientation = Orientation.Horizontal  'Need to record that they are horizontal for when they get put in the EdgeQueue
                HorizontalEdges(X, Y).EdgeCoordinate.X = X                  'Need to record their coordinates for when they are in the EdgeQueue
                HorizontalEdges(X, Y).EdgeCoordinate.Y = Y
            Next X
        Next Y
    End Sub

    Private Sub GenerateVerticalEdges(Prims As Boolean)

        Randomize()
        For Y = 0 To Size - 1
            For X = 0 To Size
                If Prims Then
                    VerticalEdges(X, Y).Weight = Rnd()                      'Randomizing the weights of vertical edges for prim's
                Else
                    VerticalEdges(X, Y).Used = True                         'All edges start off as used for recursive division
                End If
                VerticalEdges(X, Y).Orientation = Orientation.Vertical      'Need to record that they are horizontal for when they get put in the EdgeQueue
                VerticalEdges(X, Y).EdgeCoordinate.X = X                    'Need to record their coordinates for when they are in the EdgeQueue
                VerticalEdges(X, Y).EdgeCoordinate.Y = Y
            Next X
        Next Y
    End Sub

    Private Function Connected(NumberOfSelectedEdges) As Boolean         'Have enough edges been selected for the tree to be connected?
        If NumberOfSelectedEdges = (Size + 1) ^ 2 - 1 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub GenerateRecursiveDivision(DisplayGeneration As Boolean)      'This readies the maze for the algorithm
        GenerateHorizontalEdges(False)                                      'Readying edges for recursive division
        GenerateVerticalEdges(False)

        Dim TopCorner, BottomCorner As Coordinate               'These store the current top and bottom corner of each section of the maze
        TopCorner.X = 0                                         'Start values for corners are the top left and bottom right
        TopCorner.Y = 0
        BottomCorner.X = Size
        BottomCorner.Y = Size

        GenerateRecursiveDivision(TopCorner, BottomCorner, DisplayGeneration)    'Calling the actual algorithm

    End Sub

    Private Sub GenerateRecursiveDivision(TopCorner As Coordinate, BottomCorner As Coordinate, DisplayGeneration As Boolean)      'The corners correspond to the NODES
        Randomize()

        If TopCorner.X <> BottomCorner.X And TopCorner.Y <> BottomCorner.Y Then     'Checking the size of a quadrant isnt 1x1
            If DisplayGeneration Then MazeForm.PictureBoxMaze.Refresh()

            Dim DividePosition As Integer                           'How far along is the divide?
            Dim DivideDirection As Orientation                      'Which direction is the divide
            Dim NewBottomCorner, NewTopCorner As Coordinate         'These are the new corners of the two areas

            If BottomCorner.X - TopCorner.X > BottomCorner.Y - TopCorner.Y Then      'Wider than tall
                DivideDirection = Orientation.Vertical
            ElseIf BottomCorner.X - TopCorner.X < BottomCorner.Y - TopCorner.Y Then  'Taller than wide
                DivideDirection = Orientation.Horizontal
            Else                                                                     'Square so pick randomly
                If Rnd() < 0.5 Then
                    DivideDirection = Orientation.Horizontal
                Else
                    DivideDirection = Orientation.Vertical
                End If
            End If


            If DivideDirection = Orientation.Horizontal Then        'This is for a horizontal divide
                DividePosition = Int(Rnd() * (BottomCorner.Y - TopCorner.Y)) + TopCorner.Y      'Selects a random division within that section

                For X = TopCorner.X To BottomCorner.X               'Draws the line
                    VerticalEdges(X, DividePosition).Used = False
                Next X

                VerticalEdges(Int(Rnd() * (BottomCorner.X - TopCorner.X + 1)) + TopCorner.X, DividePosition).Used = True    'Makes a gap

                NewBottomCorner.X = BottomCorner.X
                NewBottomCorner.Y = DividePosition
                GenerateRecursiveDivision(TopCorner, NewBottomCorner, DisplayGeneration)    'Recursion for top area

                NewTopCorner.X = TopCorner.X
                NewTopCorner.Y = DividePosition + 1
                GenerateRecursiveDivision(NewTopCorner, BottomCorner, DisplayGeneration)    'Recursion for bottom area

            Else                                                    'This is for vertial divide
                DividePosition = Int(Rnd() * (BottomCorner.X - TopCorner.X)) + TopCorner.X      'Selects a random division within that section

                For Y = TopCorner.Y To BottomCorner.Y               'Draws the line
                    HorizontalEdges(DividePosition, Y).Used = False
                Next Y

                HorizontalEdges(DividePosition, Int(Rnd() * (BottomCorner.Y - TopCorner.Y + 1)) + TopCorner.Y).Used = True  'Makes a gap

                NewBottomCorner.X = DividePosition
                NewBottomCorner.Y = BottomCorner.Y
                GenerateRecursiveDivision(TopCorner, NewBottomCorner, DisplayGeneration)    'Recursion for left area

                NewTopCorner.X = DividePosition + 1
                NewTopCorner.Y = TopCorner.Y
                GenerateRecursiveDivision(NewTopCorner, BottomCorner, DisplayGeneration)    'Recursion for right area
            End If
        End If

    End Sub

    Public Sub DepthFirst(Start As Coordinate, Goal As Coordinate, DisplaySolving As Boolean)
        Dim NodeStack As New Stack(Of Coordinate)           'Stack of current trail
        ReDim NodesVisited(Size, Size, 1)                   'Array of current trail
        Dim NotDeadEnd As Boolean                           'Keeps track if possible to move forward
        NodesVisited(Start.X, Start.Y, 0) = True            'Sets start to true         
        Selected = Start                                    'Selects start node

        Do While Selected.X <> Goal.X Or Selected.Y <> Goal.Y     'Keep going until goal is reached
            NotDeadEnd = False

            If Selected.X < Size Then                       'Checking to the right
                If GetEdgeUsed(Orientation.Horizontal, Selected.X, Selected.Y) And Not NodesVisited(Selected.X + 1, Selected.Y, 0) And Not NodesVisited(Selected.X + 1, Selected.Y, 1) Then     'Is edge to right available?
                    NodeStack.Push(Selected)                'Add to stack
                    Selected.X += 1                         'Move current coordinate to right
                    NodesVisited(Selected.X, Selected.Y, 0) = True 'Visit that node
                    NotDeadEnd = True                             'It was possible to move
                End If
            End If

            If Selected.Y < Size And Not NotDeadEnd Then   'Checks below if hasn't gone right
                If GetEdgeUsed(Orientation.Vertical, Selected.X, Selected.Y) And Not NodesVisited(Selected.X, Selected.Y + 1, 0) And Not NodesVisited(Selected.X, Selected.Y + 1, 1) Then   'Is edge below available?
                    NodeStack.Push(Selected)                'Add to stack
                    Selected.Y += 1                         'Move current coordinate down
                    NodesVisited(Selected.X, Selected.Y, 0) = True 'Visit that node
                    NotDeadEnd = True                             'It was possible to move
                End If
            End If

            If Selected.X > 0 And Not NotDeadEnd Then         'Checks left if hasn't gone right or down
                If GetEdgeUsed(Orientation.Horizontal, Selected.X - 1, Selected.Y) And Not NodesVisited(Selected.X - 1, Selected.Y, 0) And Not NodesVisited(Selected.X - 1, Selected.Y, 1) Then     'Is edge to left available?
                    NodeStack.Push(Selected)                'Add to stack
                    Selected.X -= 1                         'Move current coordinate left
                    NodesVisited(Selected.X, Selected.Y, 0) = True 'Visit that node
                    NotDeadEnd = True                             'It was possible to move
                End If
            End If

            If Selected.Y > 0 And Not NotDeadEnd Then         'Checks up if hasn't gone any other direction
                If GetEdgeUsed(Orientation.Vertical, Selected.X, Selected.Y - 1) And Not NodesVisited(Selected.X, Selected.Y - 1, 0) And Not NodesVisited(Selected.X, Selected.Y - 1, 1) Then     'Is edge above available?
                    NodeStack.Push(Selected)                'Add to stack
                    Selected.Y -= 1                         'Move current coordinate up
                    NodesVisited(Selected.X, Selected.Y, 0) = True 'Visit that node
                    NotDeadEnd = True                             'It was possible to move
                End If
            End If

            If Not NotDeadEnd Then                            'Mustn't have been able to move
                NodesVisited(Selected.X, Selected.Y, 0) = False   'Unvisit current node
                NodesVisited(Selected.X, Selected.Y, 1) = True    'Records that that node was the wrong way
                Selected = NodeStack.Pop                    'Pops the stack to unwind the trail
            End If

            If DisplaySolving Then
                MazeForm.PictureBoxMaze.Refresh() 'herherbdfghkjvehduhsjbfhsjf
            End If
        Loop
    End Sub

    Public Sub BreadthFirst(Start As Coordinate, Goal As Coordinate, DisplaySolving As Boolean)

        Selected.X = Start.X          'Selected is not used in this algorithm, so is same as start to hide the golden square
        Selected.Y = Start.Y

        Dim NoDequeue As New Queue(Of CoordinateAndRoute)           'Queue of nodes at head of trails
        Dim NumberOfSteps As Integer = 0                            'How many steps back have been taken when backtracking
        ReDim NodesVisited(Size, Size, 1)                           'Array of current trail
        Dim NumBranches(Size, Size) As Integer                      'Stores how ay banches a node has
        Dim NotDeadEnd As Boolean                                   'Records if the current node isn't a dead end
        Dim GoalReached As Boolean                                  'Records if goal has been reached

        NodesVisited(Start.X, Start.Y, 0) = True                    'Sets start to true         
        Dim TempCoordinate As CoordinateAndRoute                    'Holds a coordinate before it is queued
        TempCoordinate.Route = ""
        Dim CurrentNode As CoordinateAndRoute                       'Holds the coordinate of the trail head currently being considered
        CurrentNode.Coordinate = Start
        CurrentNode.Route = ""
        NoDequeue.Enqueue(CurrentNode)                              'Adds the starting position

        Do While Not (NoDequeue.IsEmpty() Or GoalReached)

            NotDeadEnd = False
            CurrentNode = NoDequeue.Dequeue()

            If CurrentNode.Coordinate.X < Size Then                  'Checks to the right
                If GetEdgeUsed(Orientation.Horizontal, CurrentNode.Coordinate.X, CurrentNode.Coordinate.Y) And Not NodesVisited(CurrentNode.Coordinate.X + 1, CurrentNode.Coordinate.Y, 0) And Not NodesVisited(CurrentNode.Coordinate.X + 1, CurrentNode.Coordinate.Y, 1) Then     'Is edge to right available?
                    TempCoordinate.Coordinate.X = CurrentNode.Coordinate.X + 1       'Stores edge before it is queued
                    TempCoordinate.Coordinate.Y = CurrentNode.Coordinate.Y
                    TempCoordinate.Route = CurrentNode.Route + "R"
                    NoDequeue.Enqueue(TempCoordinate)          'Queue the new node
                    NodesVisited(TempCoordinate.Coordinate.X, TempCoordinate.Coordinate.Y, 0) = True 'Visit that node
                    NotDeadEnd = True                                'Isn't dead end
                    NumBranches(CurrentNode.Coordinate.X, CurrentNode.Coordinate.Y) += 1
                    If TempCoordinate.Coordinate.X = Goal.X And TempCoordinate.Coordinate.Y = Goal.Y Then GoalReached = True  'Goal has been found
                End If
            End If

            If CurrentNode.Coordinate.Y < Size Then                  'Checks below
                If GetEdgeUsed(Orientation.Vertical, CurrentNode.Coordinate.X, CurrentNode.Coordinate.Y) And Not NodesVisited(CurrentNode.Coordinate.X, CurrentNode.Coordinate.Y + 1, 0) And Not NodesVisited(CurrentNode.Coordinate.X, CurrentNode.Coordinate.Y + 1, 1) Then   'Is edge below available?
                    TempCoordinate.Coordinate.X = CurrentNode.Coordinate.X           'Stores edge before it is queued
                    TempCoordinate.Coordinate.Y = CurrentNode.Coordinate.Y + 1
                    TempCoordinate.Route = CurrentNode.Route + "D"
                    NoDequeue.Enqueue(TempCoordinate)          'Queue the new node
                    NodesVisited(TempCoordinate.Coordinate.X, TempCoordinate.Coordinate.Y, 0) = True 'Visit that node
                    NotDeadEnd = True                                'Isn't dead end
                    NumBranches(CurrentNode.Coordinate.X, CurrentNode.Coordinate.Y) += 1
                    If TempCoordinate.Coordinate.X = Goal.X And TempCoordinate.Coordinate.Y = Goal.Y Then GoalReached = True  'Goal has been found
                End If
            End If

            If CurrentNode.Coordinate.X > 0 Then                          'Checks left
                If GetEdgeUsed(Orientation.Horizontal, CurrentNode.Coordinate.X - 1, CurrentNode.Coordinate.Y) And Not NodesVisited(CurrentNode.Coordinate.X - 1, CurrentNode.Coordinate.Y, 0) And Not NodesVisited(CurrentNode.Coordinate.X - 1, CurrentNode.Coordinate.Y, 1) Then     'Is edge to left available?
                    TempCoordinate.Coordinate.X = CurrentNode.Coordinate.X - 1       'Stores edge before it is queued
                    TempCoordinate.Coordinate.Y = CurrentNode.Coordinate.Y
                    TempCoordinate.Route = CurrentNode.Route + "L"
                    NoDequeue.Enqueue(TempCoordinate)          'Queue the new node
                    NodesVisited(TempCoordinate.Coordinate.X, TempCoordinate.Coordinate.Y, 0) = True 'Visit that node
                    NotDeadEnd = True                                'Isn't dead end
                    NumBranches(CurrentNode.Coordinate.X, CurrentNode.Coordinate.Y) += 1
                    If TempCoordinate.Coordinate.X = Goal.X And TempCoordinate.Coordinate.Y = Goal.Y Then GoalReached = True  'Goal has been found
                End If
            End If

            If CurrentNode.Coordinate.Y > 0 Then                           'Checks up
                If GetEdgeUsed(Orientation.Vertical, CurrentNode.Coordinate.X, CurrentNode.Coordinate.Y - 1) And Not NodesVisited(CurrentNode.Coordinate.X, CurrentNode.Coordinate.Y - 1, 0) And Not NodesVisited(CurrentNode.Coordinate.X, CurrentNode.Coordinate.Y - 1, 1) Then     'Is edge above available?
                    TempCoordinate.Coordinate.X = CurrentNode.Coordinate.X            'Stores edge before it is queued
                    TempCoordinate.Coordinate.Y = CurrentNode.Coordinate.Y - 1
                    TempCoordinate.Route = CurrentNode.Route + "U"
                    NoDequeue.Enqueue(TempCoordinate)           'Queue the new node
                    NodesVisited(TempCoordinate.Coordinate.X, TempCoordinate.Coordinate.Y, 0) = True 'Visit that node
                    NotDeadEnd = True                                 'Isn't dead end
                    NumBranches(CurrentNode.Coordinate.X, CurrentNode.Coordinate.Y) += 1
                    If TempCoordinate.Coordinate.X = Goal.X And TempCoordinate.Coordinate.Y = Goal.Y Then GoalReached = True  'Goal has been found
                End If
            End If


            If Not NotDeadEnd And (CurrentNode.Coordinate.X <> Goal.X Or CurrentNode.Coordinate.Y <> Goal.Y) Then    'Dead end
                NumberOfSteps = 0
                Do          'Route in reverse to clear cells
                    NodesVisited(CurrentNode.Coordinate.X, CurrentNode.Coordinate.Y, 0) = False
                    If CurrentNode.Route(CurrentNode.Route.Length - 1 - NumberOfSteps) = "R" Then   'All movements are in the opposite direction as retracing
                        CurrentNode.Coordinate.X -= 1
                    ElseIf CurrentNode.Route(CurrentNode.Route.Length - 1 - NumberOfSteps) = "D" Then
                        CurrentNode.Coordinate.Y -= 1
                    ElseIf CurrentNode.Route(CurrentNode.Route.Length - 1 - NumberOfSteps) = "L" Then
                        CurrentNode.Coordinate.X += 1
                    ElseIf CurrentNode.Route(CurrentNode.Route.Length - 1 - NumberOfSteps) = "U" Then
                        CurrentNode.Coordinate.Y += 1
                    End If
                    NumberOfSteps += 1
                Loop Until NumBranches(CurrentNode.Coordinate.X, CurrentNode.Coordinate.Y) >= 2 Or (CurrentNode.Coordinate.X = Start.X And CurrentNode.Coordinate.Y = Start.Y)  'If a node has branches STOP!
                NumBranches(CurrentNode.Coordinate.X, CurrentNode.Coordinate.Y) -= 1
            End If

            If DisplaySolving Then
                MazeForm.PictureBoxMaze.Refresh()
            End If
        Loop

        If GoalReached Then
            Do
                CurrentNode = NoDequeue.Dequeue
                If CurrentNode.Coordinate.X <> Goal.X Or CurrentNode.Coordinate.Y <> Goal.Y Then      'Don't remove path to goal
                    NumberOfSteps = 0
                    Do          'Route in reverse to clear cells
                        NodesVisited(CurrentNode.Coordinate.X, CurrentNode.Coordinate.Y, 0) = False
                        If CurrentNode.Route(CurrentNode.Route.Length - 1 - NumberOfSteps) = "R" Then   'All movements are in the opposite direction as retracing
                            CurrentNode.Coordinate.X -= 1
                        ElseIf CurrentNode.Route(CurrentNode.Route.Length - 1 - NumberOfSteps) = "D" Then
                            CurrentNode.Coordinate.Y -= 1
                        ElseIf CurrentNode.Route(CurrentNode.Route.Length - 1 - NumberOfSteps) = "L" Then
                            CurrentNode.Coordinate.X += 1
                        ElseIf CurrentNode.Route(CurrentNode.Route.Length - 1 - NumberOfSteps) = "U" Then
                            CurrentNode.Coordinate.Y += 1
                        End If
                        NumberOfSteps += 1
                    Loop Until NumBranches(CurrentNode.Coordinate.X, CurrentNode.Coordinate.Y) >= 2 Or (CurrentNode.Coordinate.X = Start.X And CurrentNode.Coordinate.Y = Start.Y)  'If a node has branches STOP!
                    NumBranches(CurrentNode.Coordinate.X, CurrentNode.Coordinate.Y) -= 1      'The node now has one less possible correct branch
                End If
            Loop Until NoDequeue.IsEmpty()
        End If
    End Sub

End Class