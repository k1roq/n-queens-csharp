namespace NQueens;

public partial class Form1 : Form
{
    private NumericUpDown sizeSelector;
    private Button generatebutton;
    private Font queenFont = new Font("Segou UI Symbol", 38);
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        for(int row = 0; row < boardSize; row++)
        {
            for(int col = 0; col < boardSize; col++)
            {
                int x = col * cellSize;
                int y = row * cellSize;
                if((row + col) % 2 == 0)
                {
                    e.Graphics.FillRectangle(Brushes.Brown, x, y, cellSize, cellSize);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.Beige, x, y, cellSize, cellSize);
                }
                if(queens[row, col])
                {
                    
                    using (StringFormat format = new StringFormat())
                    {
                        format.Alignment = StringAlignment.Center;
                        format.LineAlignment = StringAlignment.Center;
                        e.Graphics.DrawString("♛", queenFont, Brushes.Black, new RectangleF(x, y + 8, cellSize, cellSize), format);
                    }
                }
            }
        }
    }
    
    private void GenerateSolution()
    {
        boardSize = Convert.ToInt32(sizeSelector.Value);
        NQueensSolver solver = new NQueensSolver(boardSize);
        
        queens = new bool[boardSize, boardSize];
        ClientSize = new Size(boardSize * cellSize + 180, boardSize * cellSize);
        sizeSelector.Location = new Point(boardSize * cellSize + 15, boardSize * cellSize - sizeSelector.Height - 100);
        generatebutton.Location = new Point(boardSize * cellSize + 15, boardSize * cellSize - generatebutton.Height - 15);
        if (solver.FindSolution())
        {
            int[,] solution = solver.Chessboard;

            for (int row = 0; row < queens.GetLength(0); row++)
                {
                    for (int col = 0; col < queens.GetLength(1); col++)
                    {
                        queens[row, col] = solution[row, col] == 1;
                    }   
                }

            Invalidate();
        }
    }
    private int boardSize = 8;
    private bool[,] queens = new bool[8, 8];
    private int cellSize = 60;
    public Form1()
    {
        InitializeComponent();
        sizeSelector = new NumericUpDown();
        sizeSelector.Minimum = 4;
        sizeSelector.Maximum = 20;
        sizeSelector.Value = 20;
        
        sizeSelector.Width = 40;
        Controls.Add(sizeSelector);
        generatebutton = new Button();
        generatebutton.Text = "Generate N-Queens";
        generatebutton.Size = new Size(150, 40);
        
        Controls.Add(generatebutton);
        generatebutton.Click += (sender, e) => GenerateSolution();
        GenerateSolution();
        Text = "N-Queens Visualizer";
    }
}
