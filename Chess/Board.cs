using System.Numerics;

namespace Chess;

public class Board
{
	private Piece[,] _cells;
	private Position _position;
	public Board()
	{
		_cells = new Piece[8, 8];
	}
	public void SetBoardCell(Piece piece, Vector2 position)
	{
		_cells[(int)position.X, (int)position.Y] = piece;
	}
	public bool IsEmptyCell(int row, int column)
	{
		if (IsValidPosition(row, column))
		{
			return _cells[row, column] == null;
		}
		return false;
	}
	public bool IsValidPosition(int row, int column)
	{
		return row >= 0 && row < 8 && column >= 0 && column < 8;
	}
	public bool IsWithinBoardBoundaries(int row, int column)
	{
		return row >= 0 && row < 8 && column >= 0 && column < 8;
	}
	public bool IsEnemyPiece(int row, int column)
	{
		return row >= 0 && row < 8 && column >= 0 && column < 8;
	}
}