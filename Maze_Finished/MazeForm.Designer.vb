<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MazeForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MazeForm))
        Me.PictureBoxMaze = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InstructionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GeneratingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectingStartAndGoalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreatingTheMazeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SolvingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlayingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChamgeColoursToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WallColourToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OuterWallToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InnerWallToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackgroundColourToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlayerColourToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetToDefaultToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NumericUpDownSize = New System.Windows.Forms.NumericUpDown()
        Me.CheckBoxDisplaySolving = New System.Windows.Forms.CheckBox()
        Me.ButtonPlay = New System.Windows.Forms.Button()
        Me.ButtonSolve = New System.Windows.Forms.Button()
        Me.CheckBoxDisplayGeneration = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.BtnGenerate = New System.Windows.Forms.Button()
        Me.RadioButtonPrims = New System.Windows.Forms.RadioButton()
        Me.RadioButtonRecursive = New System.Windows.Forms.RadioButton()
        Me.GroupBoxGeneration = New System.Windows.Forms.GroupBox()
        Me.GroupBoxSolve = New System.Windows.Forms.GroupBox()
        Me.RadioButtonBreadth = New System.Windows.Forms.RadioButton()
        Me.RadioButtonDepth = New System.Windows.Forms.RadioButton()
        Me.SolverColourToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.PictureBoxMaze, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.NumericUpDownSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxGeneration.SuspendLayout()
        Me.GroupBoxSolve.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBoxMaze
        '
        Me.PictureBoxMaze.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.PictureBoxMaze.Location = New System.Drawing.Point(44, 33)
        Me.PictureBoxMaze.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBoxMaze.Name = "PictureBoxMaze"
        Me.PictureBoxMaze.Size = New System.Drawing.Size(696, 581)
        Me.PictureBoxMaze.TabIndex = 7
        Me.PictureBoxMaze.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1260, 28)
        Me.MenuStrip1.TabIndex = 27
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InstructionsToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(46, 24)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'InstructionsToolStripMenuItem
        '
        Me.InstructionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GeneratingToolStripMenuItem, Me.SolvingToolStripMenuItem, Me.PlayingToolStripMenuItem})
        Me.InstructionsToolStripMenuItem.Name = "InstructionsToolStripMenuItem"
        Me.InstructionsToolStripMenuItem.Size = New System.Drawing.Size(167, 26)
        Me.InstructionsToolStripMenuItem.Text = "Instructions"
        '
        'GeneratingToolStripMenuItem
        '
        Me.GeneratingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectingStartAndGoalToolStripMenuItem, Me.CreatingTheMazeToolStripMenuItem})
        Me.GeneratingToolStripMenuItem.Name = "GeneratingToolStripMenuItem"
        Me.GeneratingToolStripMenuItem.Size = New System.Drawing.Size(165, 26)
        Me.GeneratingToolStripMenuItem.Text = "Generating"
        '
        'SelectingStartAndGoalToolStripMenuItem
        '
        Me.SelectingStartAndGoalToolStripMenuItem.Name = "SelectingStartAndGoalToolStripMenuItem"
        Me.SelectingStartAndGoalToolStripMenuItem.Size = New System.Drawing.Size(249, 26)
        Me.SelectingStartAndGoalToolStripMenuItem.Text = "Selecting start and goal"
        '
        'CreatingTheMazeToolStripMenuItem
        '
        Me.CreatingTheMazeToolStripMenuItem.Name = "CreatingTheMazeToolStripMenuItem"
        Me.CreatingTheMazeToolStripMenuItem.Size = New System.Drawing.Size(249, 26)
        Me.CreatingTheMazeToolStripMenuItem.Text = "Creating the maze"
        '
        'SolvingToolStripMenuItem
        '
        Me.SolvingToolStripMenuItem.Name = "SolvingToolStripMenuItem"
        Me.SolvingToolStripMenuItem.Size = New System.Drawing.Size(165, 26)
        Me.SolvingToolStripMenuItem.Text = "Solving"
        '
        'PlayingToolStripMenuItem
        '
        Me.PlayingToolStripMenuItem.Name = "PlayingToolStripMenuItem"
        Me.PlayingToolStripMenuItem.Size = New System.Drawing.Size(165, 26)
        Me.PlayingToolStripMenuItem.Text = "Playing"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChamgeColoursToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(49, 24)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ChamgeColoursToolStripMenuItem
        '
        Me.ChamgeColoursToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WallColourToolStripMenuItem1, Me.BackgroundColourToolStripMenuItem1, Me.PlayerColourToolStripMenuItem, Me.SolverColourToolStripMenuItem, Me.ResetToDefaultToolStripMenuItem})
        Me.ChamgeColoursToolStripMenuItem.Name = "ChamgeColoursToolStripMenuItem"
        Me.ChamgeColoursToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.ChamgeColoursToolStripMenuItem.Text = "Change colours"
        '
        'WallColourToolStripMenuItem1
        '
        Me.WallColourToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OuterWallToolStripMenuItem, Me.InnerWallToolStripMenuItem})
        Me.WallColourToolStripMenuItem1.Name = "WallColourToolStripMenuItem1"
        Me.WallColourToolStripMenuItem1.Size = New System.Drawing.Size(224, 26)
        Me.WallColourToolStripMenuItem1.Text = "Wall colour"
        '
        'OuterWallToolStripMenuItem
        '
        Me.OuterWallToolStripMenuItem.Name = "OuterWallToolStripMenuItem"
        Me.OuterWallToolStripMenuItem.Size = New System.Drawing.Size(160, 26)
        Me.OuterWallToolStripMenuItem.Text = "Outer wall"
        '
        'InnerWallToolStripMenuItem
        '
        Me.InnerWallToolStripMenuItem.Name = "InnerWallToolStripMenuItem"
        Me.InnerWallToolStripMenuItem.Size = New System.Drawing.Size(160, 26)
        Me.InnerWallToolStripMenuItem.Text = "Inner wall"
        '
        'BackgroundColourToolStripMenuItem1
        '
        Me.BackgroundColourToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangeToolStripMenuItem, Me.ClearToolStripMenuItem})
        Me.BackgroundColourToolStripMenuItem1.Name = "BackgroundColourToolStripMenuItem1"
        Me.BackgroundColourToolStripMenuItem1.Size = New System.Drawing.Size(224, 26)
        Me.BackgroundColourToolStripMenuItem1.Text = "Background colour"
        '
        'ChangeToolStripMenuItem
        '
        Me.ChangeToolStripMenuItem.Name = "ChangeToolStripMenuItem"
        Me.ChangeToolStripMenuItem.Size = New System.Drawing.Size(142, 26)
        Me.ChangeToolStripMenuItem.Text = "Change"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(142, 26)
        Me.ClearToolStripMenuItem.Text = "Clear"
        '
        'PlayerColourToolStripMenuItem
        '
        Me.PlayerColourToolStripMenuItem.Name = "PlayerColourToolStripMenuItem"
        Me.PlayerColourToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.PlayerColourToolStripMenuItem.Text = "Player colour"
        '
        'ResetToDefaultToolStripMenuItem
        '
        Me.ResetToDefaultToolStripMenuItem.Name = "ResetToDefaultToolStripMenuItem"
        Me.ResetToDefaultToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.ResetToDefaultToolStripMenuItem.Text = "Reset to default"
        '
        'NumericUpDownSize
        '
        Me.NumericUpDownSize.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NumericUpDownSize.Location = New System.Drawing.Point(1092, 258)
        Me.NumericUpDownSize.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NumericUpDownSize.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumericUpDownSize.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.NumericUpDownSize.Name = "NumericUpDownSize"
        Me.NumericUpDownSize.Size = New System.Drawing.Size(133, 22)
        Me.NumericUpDownSize.TabIndex = 34
        Me.NumericUpDownSize.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'CheckBoxDisplaySolving
        '
        Me.CheckBoxDisplaySolving.AutoSize = True
        Me.CheckBoxDisplaySolving.Location = New System.Drawing.Point(1092, 574)
        Me.CheckBoxDisplaySolving.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBoxDisplaySolving.Name = "CheckBoxDisplaySolving"
        Me.CheckBoxDisplaySolving.Size = New System.Drawing.Size(132, 21)
        Me.CheckBoxDisplaySolving.TabIndex = 33
        Me.CheckBoxDisplaySolving.Text = "Display solving?"
        Me.CheckBoxDisplaySolving.UseVisualStyleBackColor = True
        '
        'ButtonPlay
        '
        Me.ButtonPlay.Location = New System.Drawing.Point(1092, 692)
        Me.ButtonPlay.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonPlay.Name = "ButtonPlay"
        Me.ButtonPlay.Size = New System.Drawing.Size(133, 34)
        Me.ButtonPlay.TabIndex = 32
        Me.ButtonPlay.Text = "Play!"
        Me.ButtonPlay.UseVisualStyleBackColor = True
        '
        'ButtonSolve
        '
        Me.ButtonSolve.Location = New System.Drawing.Point(1092, 401)
        Me.ButtonSolve.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ButtonSolve.Name = "ButtonSolve"
        Me.ButtonSolve.Size = New System.Drawing.Size(133, 34)
        Me.ButtonSolve.TabIndex = 31
        Me.ButtonSolve.Text = "Solve!"
        Me.ButtonSolve.UseVisualStyleBackColor = True
        '
        'CheckBoxDisplayGeneration
        '
        Me.CheckBoxDisplayGeneration.AutoSize = True
        Me.CheckBoxDisplayGeneration.Location = New System.Drawing.Point(1092, 310)
        Me.CheckBoxDisplayGeneration.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBoxDisplayGeneration.Name = "CheckBoxDisplayGeneration"
        Me.CheckBoxDisplayGeneration.Size = New System.Drawing.Size(156, 21)
        Me.CheckBoxDisplayGeneration.TabIndex = 30
        Me.CheckBoxDisplayGeneration.Text = "Display generation?"
        Me.CheckBoxDisplayGeneration.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1112, 239)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 17)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Size of maze"
        '
        'BtnGenerate
        '
        Me.BtnGenerate.Location = New System.Drawing.Point(1092, 49)
        Me.BtnGenerate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.BtnGenerate.Name = "BtnGenerate"
        Me.BtnGenerate.Size = New System.Drawing.Size(133, 34)
        Me.BtnGenerate.TabIndex = 36
        Me.BtnGenerate.Text = "Generate!"
        Me.BtnGenerate.UseVisualStyleBackColor = True
        '
        'RadioButtonPrims
        '
        Me.RadioButtonPrims.AutoSize = True
        Me.RadioButtonPrims.Checked = True
        Me.RadioButtonPrims.Location = New System.Drawing.Point(52, 39)
        Me.RadioButtonPrims.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RadioButtonPrims.Name = "RadioButtonPrims"
        Me.RadioButtonPrims.Size = New System.Drawing.Size(67, 21)
        Me.RadioButtonPrims.TabIndex = 37
        Me.RadioButtonPrims.TabStop = True
        Me.RadioButtonPrims.Text = "Prim's"
        Me.RadioButtonPrims.UseVisualStyleBackColor = True
        '
        'RadioButtonRecursive
        '
        Me.RadioButtonRecursive.AutoSize = True
        Me.RadioButtonRecursive.Location = New System.Drawing.Point(52, 68)
        Me.RadioButtonRecursive.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RadioButtonRecursive.Name = "RadioButtonRecursive"
        Me.RadioButtonRecursive.Size = New System.Drawing.Size(143, 21)
        Me.RadioButtonRecursive.TabIndex = 38
        Me.RadioButtonRecursive.Text = "Recursive division"
        Me.RadioButtonRecursive.UseVisualStyleBackColor = True
        '
        'GroupBoxGeneration
        '
        Me.GroupBoxGeneration.Controls.Add(Me.RadioButtonPrims)
        Me.GroupBoxGeneration.Controls.Add(Me.RadioButtonRecursive)
        Me.GroupBoxGeneration.Location = New System.Drawing.Point(1029, 91)
        Me.GroupBoxGeneration.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBoxGeneration.Name = "GroupBoxGeneration"
        Me.GroupBoxGeneration.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBoxGeneration.Size = New System.Drawing.Size(267, 123)
        Me.GroupBoxGeneration.TabIndex = 39
        Me.GroupBoxGeneration.TabStop = False
        '
        'GroupBoxSolve
        '
        Me.GroupBoxSolve.Controls.Add(Me.RadioButtonBreadth)
        Me.GroupBoxSolve.Controls.Add(Me.RadioButtonDepth)
        Me.GroupBoxSolve.Location = New System.Drawing.Point(1029, 443)
        Me.GroupBoxSolve.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBoxSolve.Name = "GroupBoxSolve"
        Me.GroupBoxSolve.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBoxSolve.Size = New System.Drawing.Size(267, 123)
        Me.GroupBoxSolve.TabIndex = 39
        Me.GroupBoxSolve.TabStop = False
        '
        'RadioButtonBreadth
        '
        Me.RadioButtonBreadth.AutoSize = True
        Me.RadioButtonBreadth.Location = New System.Drawing.Point(52, 66)
        Me.RadioButtonBreadth.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RadioButtonBreadth.Name = "RadioButtonBreadth"
        Me.RadioButtonBreadth.Size = New System.Drawing.Size(106, 21)
        Me.RadioButtonBreadth.TabIndex = 1
        Me.RadioButtonBreadth.Text = "Breadth first"
        Me.RadioButtonBreadth.UseVisualStyleBackColor = True
        '
        'RadioButtonDepth
        '
        Me.RadioButtonDepth.AutoSize = True
        Me.RadioButtonDepth.Checked = True
        Me.RadioButtonDepth.Location = New System.Drawing.Point(52, 38)
        Me.RadioButtonDepth.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RadioButtonDepth.Name = "RadioButtonDepth"
        Me.RadioButtonDepth.Size = New System.Drawing.Size(94, 21)
        Me.RadioButtonDepth.TabIndex = 0
        Me.RadioButtonDepth.TabStop = True
        Me.RadioButtonDepth.Text = "Depth first"
        Me.RadioButtonDepth.UseVisualStyleBackColor = True
        '
        'SolverColourToolStripMenuItem
        '
        Me.SolverColourToolStripMenuItem.Name = "SolverColourToolStripMenuItem"
        Me.SolverColourToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.SolverColourToolStripMenuItem.Text = "Solver colour"
        '
        'MazeForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1260, 777)
        Me.Controls.Add(Me.GroupBoxSolve)
        Me.Controls.Add(Me.GroupBoxGeneration)
        Me.Controls.Add(Me.BtnGenerate)
        Me.Controls.Add(Me.NumericUpDownSize)
        Me.Controls.Add(Me.CheckBoxDisplaySolving)
        Me.Controls.Add(Me.ButtonPlay)
        Me.Controls.Add(Me.ButtonSolve)
        Me.Controls.Add(Me.CheckBoxDisplayGeneration)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.PictureBoxMaze)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximumSize = New System.Drawing.Size(1278, 824)
        Me.MinimumSize = New System.Drawing.Size(1278, 824)
        Me.Name = "MazeForm"
        Me.Text = "Maze"
        CType(Me.PictureBoxMaze, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.NumericUpDownSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxGeneration.ResumeLayout(False)
        Me.GroupBoxGeneration.PerformLayout()
        Me.GroupBoxSolve.ResumeLayout(False)
        Me.GroupBoxSolve.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBoxMaze As PictureBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InstructionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GeneratingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectingStartAndGoalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreatingTheMazeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SolvingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlayingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NumericUpDownSize As NumericUpDown
    Friend WithEvents CheckBoxDisplaySolving As CheckBox
    Friend WithEvents ButtonPlay As Button
    Friend WithEvents ButtonSolve As Button
    Friend WithEvents CheckBoxDisplayGeneration As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChamgeColoursToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WallColourToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents BackgroundColourToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ChangeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClearToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BtnGenerate As Button
    Friend WithEvents RadioButtonPrims As RadioButton
    Friend WithEvents RadioButtonRecursive As RadioButton
    Friend WithEvents GroupBoxGeneration As GroupBox
    Friend WithEvents GroupBoxSolve As GroupBox
    Friend WithEvents RadioButtonDepth As RadioButton
    Friend WithEvents RadioButtonBreadth As RadioButton
    Friend WithEvents OuterWallToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InnerWallToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PlayerColourToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetToDefaultToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SolverColourToolStripMenuItem As ToolStripMenuItem
End Class
