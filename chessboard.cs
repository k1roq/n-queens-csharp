int[,] chessboard = new int[20, 20];
int [] columns = new int[chessboard.GetLength(1)];

for (int i = 0; i < columns.Length; i++)
{
    columns[i] = i;
}
static bool IsSafe(int[,] chessboard, int row, int col)
{
    
    for (int oldrow = 0; oldrow < row; oldrow++)
        {
            for (int oldcol = 0; oldcol < chessboard.GetLength(1); oldcol++)
            {
                if (chessboard[oldrow, oldcol] == 1)
                {
                    if (Math.Abs(row - oldrow) == Math.Abs(col - oldcol) || col == oldcol)
                    {
                    return false;
                    }
                }

            }
        }
return true;

}
Random random = new Random();
static bool Solve(int[,] chessboard, int row, int[] columns, Random random)
{    
    if (row == chessboard.GetLength(0))
    {
        return true;
    }
    int[] shuffledColumns = (int[])columns.Clone();
    for (int i = shuffledColumns.Length - 1; i > 0; i--)
    {
        int j = random.Next(i + 1);
        int temp = shuffledColumns[i];
        shuffledColumns[i] = shuffledColumns[j];
        shuffledColumns[j] = temp;

    }
    for (int i = 0; i < chessboard.GetLength(1); i++)
    {
        int col = shuffledColumns[i];
        if (IsSafe(chessboard, row, col))
        {
            chessboard[row, col] = 1;
            if (Solve(chessboard, row + 1, shuffledColumns, random))
                {
                    return true;
                }
            chessboard[row, col] = 0;              
        }

    }   
    return false;
}

while (true)
{
    for (int row = 0; row < chessboard.GetLength(0); row++)
    {
        for (int col = 0; col < chessboard.GetLength(1); col++)
        {
            chessboard[row, col] = 0;
        }
    }
    if (Solve(chessboard, 0, columns, random))
    {
        for (int row = 0; row < chessboard.GetLength(0); row++)
        {
            for (int col = 0; col < chessboard.GetLength(1); col++)
            {
                if (chessboard[row, col] == 1)
                {
                Console.Write("Q ");
                }
                else
                {
                Console.Write("X ");
                }
            }

            Console.WriteLine();
        }
    }
    else
    {
        Console.WriteLine("Solution not found");
    }
    Console.WriteLine("Enter — next solution | Esc — exit");
    ConsoleKey key = Console.ReadKey(true).Key;

    if (key == ConsoleKey.Escape)
    {
        break;
    }
}
