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
	
	public void SetBoardCellNull(Vector2 position)
	{
		_cells[(int)position.X, (int)position.Y] = null;
	}

	public Piece[,] GetBoard()
	{
		return _cells;
	}

	public bool IsEmptyCell(int row, int column)
	{
		if (IsWithinBoardBoundaries(row, column))
		{
			return _cells[row, column] == null;
		}
		return false;
	}

	public bool IsWithinBoardBoundaries(int row, int column)
	{
		return row >= 0 && row < 8 && column >= 0 && column < 8;
	}

	public bool IsEnemyPiece(int row, int column)
	{
		return row >= 0 && row < 8 && column >= 0 && column < 8;
	}

	public Piece ChangePiecePosition(Piece piece, Vector2 position)
	{
		for (var row = 0; row < _cells.GetLength(0); row++)
		{
			for (var column = 0; column < _cells.GetLength(1); column++)
			{
				if (row == position.X && column == position.Y)
				{
					if (_cells[row, column] != null)
					{
						var changedPiece = _cells[row, column];
						_cells[row, column] = piece;
						return changedPiece;
					}
				}
			}
		}
		return null;
	}

	public void PrintBoard()
	{
		for (var column = _cells.GetLength(1) - 1; column >= 0; column--)
		{
			for (var row = 0; row < _cells.GetLength(0); row++)
			{
				var piece = GetPiece(new Vector2(row, column));

				Console.Write("|");

				if (piece != null)
				{
					var count = piece.ID.Length;

					var spaceLeft = 7 - count;

					var id = piece.ID;

					for (var i = 0; i < spaceLeft; i++)
					{
						id += " ";
					}

					Console.Write(id);
				}
				else
				{
					Console.Write("       ");
				}

				if (row == _cells.GetLength(0) - 1)
				{
					Console.Write("|");
				}
			}

			Console.WriteLine();
		}
	}

	public Piece GetPiece(Vector2 position)
	{
		for (var column = 0; column < _cells.GetLength(0); column++)
		{
			for (var row = 0; row < _cells.GetLength(1); row++)
			{
				if (position.X == column && position.Y == row)
				{
					return _cells[column, row];
				}
			}
		}

		return null;
	}
}