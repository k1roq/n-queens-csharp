namespace NQueens;
public class NQueensSolver
{
    private int[,] chessboard;
    private int[] columns;
    private int row;
    private Random random = new Random();

    bool IsSafe(int row, int col)
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
    bool Solve(int row)
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
            if (IsSafe(row, col))
            {
                chessboard[row, col] = 1;
                if (Solve(row + 1))
                    {
                        return true;
                    }
                chessboard[row, col] = 0;              
            }

        }   
        return false;
    }
        public bool FindSolution()
        {
            return Solve(0);
        }
    public int[,] Chessboard
    {
            get { return chessboard; }
    }  

    public NQueensSolver(int size)
        {
            chessboard = new int[size, size];
            columns = new int[size];
            for(int i = 0; i < columns.GetLength(0); i++)
            {
                columns[i] = i;
            }
        }
  
}
