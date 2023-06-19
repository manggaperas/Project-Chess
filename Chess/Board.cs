namespace Chess;

public class Board
{
    private int[,] _boardindex;
    private Dictionary<Player, PieceSet> _playerpieces;

    public Board()
    {
        _boardindex = new int[8, 8];
    }
    // private void DrawBoard() //program.cs
    // {
    //     for (int x = 0; x < 8; x++)
    //     {
    //         for (int y = 0; y < 8; y++)
    //         {
    //             _boardindex[x, y] = 0;
    //         }
    //     }
    // }
    // public void PrintBoard()
    // {
    //     int x = _boardindex.GetLength(0);
    //     int y = _boardindex.GetLength(1);
    //     for (int i = 0; i < x; i++)
    //     {
    //         for (int j = 0; j < y; j++)
    //         {
    //             System.Console.WriteLine("[    ]    ");
    //         }
    //         System.Console.WriteLine();
    //         System.Console.WriteLine();
    //     }
    // }
    public bool IsEmptyCell(int row, int column)
    {
        if (IsValidPosition(row, column))
        {
            return _boardindex[row, column] == null;
        }

        return false;
    }

    public bool IsValidPosition(int row, int column)
    {
        return row >= 0 && row < 8 && column >= 0 && column < 8;
    }

    public bool IsEnemyPiece(int row, int column)
    {
        return row >= 0 && row < 8 && column >= 0 && column < 8;
    }
    public bool IsWithinBoardBoundaries(int row, int column)
    {
        return row >= 0 && row < 8 && column >= 0 && column < 8;
    }
    public void SetPiece(Piece piece, Position position)
    {
        int row = Position.Row;
        int column = Position.Column;

        if (IsValidPosition(row, column))
        {
            _boardindex[row, column] = piece;
        }
        else
        {
            throw new ArgumentOutOfRangeException("Invalid position.");
        }
    }

}