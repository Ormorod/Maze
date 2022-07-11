Public Class MazeForm

    Private Maze As New Maze
    Private SizeOfWalls As Integer                      'How many pixels long is each wall
    Private GeneratingPrims As Boolean = False          'Lets the display know if it needs to do the prim's dot
    Private Solving As Boolean = False                  'Stores if the solving algorithm is currently running
    Private Generated As Boolean = False                'Has a maze been generated?
    Private Playing As Boolean = False                  'Is the game in progress?
    Private Gameposition As Coordinate                  'What position is the player in?
    Private StartCoordinate As Coordinate               'Where did they start?
    Private GoalCoordinate As Coordinate                'Where is their goal?
    Private OuterWallPen As Pen                         'Current outer wall colour
    Private InnerWallPen As Pen                         'Current inner wall colour
    Private PlayerBrush As New SolidBrush(Color.Orange) 'Current player colour
    Private SolvingBrush As New SolidBrush(Color.LightBlue) 'Current solving trail colour
    Private BackgroundColour As Color                   'Current Background colour

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load        'This runs on startup
        Me.KeyPreview = True            'Allows keys to be used for game
        Maze.SetSize(NumericUpDownSize.Value - 1)
        SizeOfWalls = 20                'Default pixel size
        GoalCoordinate.X = 29           'Default goal is bottom right
        GoalCoordinate.Y = 29
        OuterWallPen = Pens.Blue        'Default wall colour is blue
        InnerWallPen = Pens.Blue
    End Sub

    Private Sub BtnGenerate_Click(sender As Object, e As EventArgs) Handles BtnGenerate.Click
        ResetBackground()                                           'Resets the error message for maze not generated  
        SizeOfCells()                                               'Makes sure wall size is appropriate
        ResetStartAndGoal()                                         'Sets start to top left and goal to bottom right
        Playing = False
        If RadioButtonPrims.Checked Then

            Maze.SetSize(NumericUpDownSize.Value - 1)                   'Sets size of maze
            GeneratingPrims = True                                      'Lets display know it needs to do the prim's dot

            Maze.GeneratePrims(CheckBoxDisplayGeneration.Checked)       'Generate the maze!

            GeneratingPrims = False
            PictureBoxMaze.Refresh()
            Generated = True                                            'The maze is now ready to be solved and played

        Else
            Maze.SetSize(NumericUpDownSize.Value - 1)                   'Sets maze to new size

            Maze.GenerateRecursiveDivision(CheckBoxDisplayGeneration.Checked)    'Generate the maze!

            Generated = True                                            'The maze is ready to be solved and played
            PictureBoxMaze.Refresh()
        End If
    End Sub

    Private Sub ResetStartAndGoal()
        StartCoordinate.X = 0                                           'Sets start to top left
        StartCoordinate.Y = 0
        GoalCoordinate.X = NumericUpDownSize.Value - 1                  'Sets goal to new bottom right
        GoalCoordinate.Y = NumericUpDownSize.Value - 1
        Maze.SetStartCoordinate(StartCoordinate)                        'Changes start coordinate to the selected one
    End Sub

    Private Sub ResetBackground()                   'Resets the error message for maze not generated 
        If BackColor = Color.Red Then
            BackColor = BackgroundColour
        End If
    End Sub

    Private Sub ButtonSolve_Click(sender As Object, e As EventArgs) Handles ButtonSolve.Click

        If Not Generated Then                               'There's no maze to solve!
            BackColor = Color.Red
            MessageBox.Show("You haven't generated a maze yet!")
        Else

            Solving = True                                      'Display knows to do the trail

            If RadioButtonDepth.Checked Then             'Deciding generation method
                If Playing Then
                    Maze.DepthFirst(StartCoordinate, GoalCoordinate, False)     'If game is in progress then don't bother with display
                Else
                    Maze.DepthFirst(StartCoordinate, GoalCoordinate, CheckBoxDisplaySolving.Checked)     'Solve the maze!
                End If
            Else
                If Playing Then
                    Maze.BreadthFirst(StartCoordinate, GoalCoordinate, False)   'If game is in progress then don't bother with display
                Else
                    Maze.BreadthFirst(StartCoordinate, GoalCoordinate, CheckBoxDisplaySolving.Checked)   'Solve the maze!
                End If
            End If

            PictureBoxMaze.Refresh()
            Solving = False                                     'Solving has finished
        End If
    End Sub

    Private Sub PictureBoxMaze_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBoxMaze.Paint
        Dim g As Graphics = e.Graphics
        'Entire maze is offset 5 right and 5 down
        PictureBoxMaze.Size = New Size(SizeOfWalls * (Maze.GetSize + 2) + 5, SizeOfWalls * (Maze.GetSize + 2) + 5)      'Dynamically sets PictureBox Size, based on the size of the wall
        g.DrawRectangle(OuterWallPen, 5, 5, SizeOfWalls * (Maze.GetSize + 1), SizeOfWalls * (Maze.GetSize + 1))           'Outside border of maze

        'Horizontal edges, which appear as vertical walls
        For Y = 0 To Maze.GetSize
            For X = 0 To Maze.GetSize - 1                    'One fewer in horizontal axis
                If Not Maze.GetEdgeUsed(Orientation.Horizontal, X, Y) Then
                    g.DrawLine(InnerWallPen, X * SizeOfWalls + SizeOfWalls + 5, Y * SizeOfWalls + 5, X * SizeOfWalls + SizeOfWalls + 5, Y * SizeOfWalls + SizeOfWalls - 1 + 5)
                End If
            Next X
        Next Y

        'Vertical edges, which appear as horizontal walls
        For Y = 0 To Maze.GetSize - 1                        'One fewer in vertical axis
            For X = 0 To Maze.GetSize
                If Not Maze.GetEdgeUsed(Orientation.Vertical, X, Y) Then
                    g.DrawLine(InnerWallPen, X * SizeOfWalls + 5, Y * SizeOfWalls + SizeOfWalls + 5, X * SizeOfWalls + SizeOfWalls + 5, Y * SizeOfWalls + SizeOfWalls + 5)
                End If
            Next X
        Next Y

        'Solving trail
        If Solving Then
            For Y = 0 To Maze.GetSize
                For X = 0 To Maze.GetSize
                    If Maze.GetNodePartOfRoute(X, Y) Then
                        g.FillRectangle(SolvingBrush, X * SizeOfWalls + 6, Y * SizeOfWalls + 6, SizeOfWalls - 1, SizeOfWalls - 1)      'Trail
                    End If
                Next X
            Next Y
        End If

        'Moving blob
        If GeneratingPrims Or Solving Then
            g.FillRectangle(Brushes.Goldenrod, Maze.GetSelected.X * SizeOfWalls + 6, Maze.GetSelected.Y * SizeOfWalls + 6, SizeOfWalls - 1, SizeOfWalls - 1)
        End If

        'Start and end coordinates
        g.FillRectangle(Brushes.Red, StartCoordinate.X * SizeOfWalls + 6, StartCoordinate.Y * SizeOfWalls + 6, SizeOfWalls - 1, SizeOfWalls - 1)
        g.FillRectangle(Brushes.LimeGreen, GoalCoordinate.X * SizeOfWalls + 6, GoalCoordinate.Y * SizeOfWalls + 6, SizeOfWalls - 1, SizeOfWalls - 1)

        'Draw the player
        If Playing Then
            g.FillRectangle(PlayerBrush, Gameposition.X * SizeOfWalls + 6, Gameposition.Y * SizeOfWalls + 6, SizeOfWalls - 1, SizeOfWalls - 1)
        End If
    End Sub

    Private Sub ButtonPlay_Click(sender As Object, e As EventArgs) Handles ButtonPlay.Click
        If Generated Then
            If BackColor = Color.Red Then BackColor = Color.Empty   'Resets the error message for maze not generated 
            Playing = True                                          'Game now in progress
            Gameposition.X = StartCoordinate.X                      'Sets player's start position
            Gameposition.Y = StartCoordinate.Y
            PictureBoxMaze.Refresh()
        Else
            BackColor = Color.Red                                   'There's no maze to play!
            MessageBox.Show("You haven't generated a maze yet!")
        End If
    End Sub

    Private Sub GameWon()                                           'Lets player know they have won
        If Gameposition.X = GoalCoordinate.X And Gameposition.Y = GoalCoordinate.Y Then
            MessageBox.Show("You have completed the maze!")
            Playing = False                                         'Lets display know player has won
            PictureBoxMaze.Refresh()
        End If
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        'Uses WASD because arrow keys navigate buttons

        If Playing Then                                      'Only works if game is in progress
            Select Case e.KeyCode
                Case Keys.W             'Up
                    If Gameposition.Y <> 0 Then
                        If Maze.GetEdgeUsed(Orientation.Vertical, Gameposition.X, Gameposition.Y - 1) Then
                            Gameposition.Y -= 1
                            PictureBoxMaze.Refresh()
                            GameWon()                               'Checks to see if player has won
                        End If
                    End If
                    e.Handled = True
                Case Keys.A             'Left
                    If Gameposition.X <> 0 Then
                        If Maze.GetEdgeUsed(Orientation.Horizontal, Gameposition.X - 1, Gameposition.Y) Then
                            Gameposition.X -= 1
                            PictureBoxMaze.Refresh()
                            GameWon()
                        End If
                    End If
                    e.Handled = True
                Case Keys.S             'Down
                    If Gameposition.Y <> Maze.GetSize Then
                        If Maze.GetEdgeUsed(Orientation.Vertical, Gameposition.X, Gameposition.Y) Then
                            Gameposition.Y += 1
                            PictureBoxMaze.Refresh()
                            GameWon()
                        End If
                    End If
                    e.Handled = True
                Case Keys.D             'Right
                    If Gameposition.X <> Maze.GetSize Then
                        If Maze.GetEdgeUsed(Orientation.Horizontal, Gameposition.X, Gameposition.Y) Then
                            Gameposition.X += 1
                            PictureBoxMaze.Refresh()
                            GameWon()
                        End If
                    End If
                    e.Handled = True
            End Select
        End If
    End Sub

    Private Sub SizeOfCells()                                   'Selects most appropriate size of walls for current maze size

        If NumericUpDownSize.Value - Int(NumericUpDownSize.Value) < 0.5 Then    'Rounding the size
            NumericUpDownSize.Value = Int(NumericUpDownSize.Value)
        Else
            NumericUpDownSize.Value = Int(NumericUpDownSize.Value) + 1
        End If
        SizeOfWalls = 600 \ NumericUpDownSize.Value
    End Sub

    Private Sub PictureBoxMaze_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBoxMaze.MouseDown
        If Playing = False Then                                 'If game is in progress then start and goal are fixed
            ChangeCoordinates(e.Button, PictureBoxMaze.PointToClient(Cursor.Position))       ' Sends the Mouse button and Cursor Position as Parameters
        End If
    End Sub

    Private Sub ChangeCoordinates(ByVal MouseArgs As System.Windows.Forms.MouseButtons, ByVal CurrentObjectMousePos As Point)

        If (CurrentObjectMousePos.X > 5 And CurrentObjectMousePos.Y > 5) And (CurrentObjectMousePos.X <= SizeOfWalls * (Maze.GetSize + 1) + 4 And CurrentObjectMousePos.Y <= SizeOfWalls * (Maze.GetSize + 1) + 4) Then     ' Prevents Array Boundary Errors 

            Select Case MouseArgs
                Case MouseButtons.Left        'For selecting start coordinate
                    If GoalCoordinate.X <> (CurrentObjectMousePos.X - 5) \ SizeOfWalls Or GoalCoordinate.Y <> (CurrentObjectMousePos.Y - 5) \ SizeOfWalls Then      'Makes sure start doesn't overlap goal
                        StartCoordinate.X = (CurrentObjectMousePos.X - 5) \ SizeOfWalls         'Converts mouse coordinate to maze position
                        StartCoordinate.Y = (CurrentObjectMousePos.Y - 5) \ SizeOfWalls
                        Maze.SetStartCoordinate(StartCoordinate)
                    End If

                Case MouseButtons.Right       'For selecting goal coordinate
                    If StartCoordinate.X <> (CurrentObjectMousePos.X - 5) \ SizeOfWalls Or StartCoordinate.Y <> (CurrentObjectMousePos.Y - 5) \ SizeOfWalls Then    'Makes sure goal doesn't overlap start
                        GoalCoordinate.X = (CurrentObjectMousePos.X - 5) \ SizeOfWalls          'Converts mouse position to maze position
                        GoalCoordinate.Y = (CurrentObjectMousePos.Y - 5) \ SizeOfWalls
                    End If
            End Select
            PictureBoxMaze.Refresh()
        End If
    End Sub

    'Instructions

    Private Sub SelectingStartAndGoalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectingStartAndGoalToolStripMenuItem.Click
        MessageBox.Show("Selecting start coordinate:" & vbNewLine & "Hover the mouse over the desired coordinate and left click." & vbNewLine & vbNewLine & "Selecting goal coordinate:" & vbNewLine & "Hover the mouse over the desired coordinate and right click.")
    End Sub

    Private Sub CreatingTheMazeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreatingTheMazeToolStripMenuItem.Click
        MessageBox.Show("Generating the maze:" & vbNewLine & "First select the size of the maze using the text box." & vbNewLine & "Select the Prims's button to use Prim's algorithm, or select the recursive division button to use recursive division." & vbNewLine & "Select the tickbox if you wish to watch the maze generate." & vbNewLine & "Finally click the generate button to start generation.")
    End Sub

    Private Sub SolvingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SolvingToolStripMenuItem.Click
        MessageBox.Show("Getting the maze to solve itself:" & vbNewLine & "Select depth first to use the depth first method, or select breadth first to use the breadth first method." & vbNewLine & "Click the solve button to see the solution to the maze." & vbNewLine & "Select the tickbox to watch the maze solve.")
    End Sub

    Private Sub PlayingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlayingToolStripMenuItem.Click
        MessageBox.Show("Playing the maze:" & vbNewLine & "To play the maze, press the play button, then use WASD to move the box around to solve the maze.")
    End Sub

    'Changing colours

    Private Sub OuterWallToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OuterWallToolStripMenuItem.Click
        ColorDialog1.ShowDialog()                           'Shows colour dialog
        OuterWallPen = New Pen(ColorDialog1.Color, 1)       'Sets outer wall pen colour
        PictureBoxMaze.Refresh()
    End Sub

    Private Sub InnerWallToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InnerWallToolStripMenuItem.Click
        ColorDialog1.ShowDialog()                           'Shows colour dialog
        InnerWallPen = New Pen(ColorDialog1.Color, 1)       'Sets inner wall pen colour
        PictureBoxMaze.Refresh()
    End Sub

    Private Sub ChangeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeToolStripMenuItem.Click
        ColorDialog1.ShowDialog()                           'Shows colour dialog
        BackgroundColour = ColorDialog1.Color               'Stores new colour
        BackColor = BackgroundColour                        'Changes colour
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        BackgroundColour = Color.Empty                      'Changes colour
        BackColor = Color.Empty                             'Clears Background
    End Sub

    Private Sub PlayerColourToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlayerColourToolStripMenuItem.Click
        ColorDialog1.ShowDialog()
        PlayerBrush = New SolidBrush(ColorDialog1.Color)
        PictureBoxMaze.Refresh()
    End Sub

    Private Sub SolverColourToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SolverColourToolStripMenuItem.Click
        ColorDialog1.ShowDialog()
        SolvingBrush = New SolidBrush(ColorDialog1.Color)
        PictureBoxMaze.Refresh()
    End Sub

    Private Sub ResetToDefaultToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetToDefaultToolStripMenuItem.Click
        OuterWallPen = New Pen(Color.Blue, 1)
        InnerWallPen = New Pen(Color.Blue, 1)
        BackColor = Color.Empty                             'Clears Background
        PlayerBrush = New SolidBrush(Color.Orange)
        BackgroundColour = Color.Empty
        PictureBoxMaze.Refresh()
    End Sub

End Class