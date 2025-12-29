using System.Numerics;
using Chess.Models.Interfaces;
using Chess.Models.Pieces;

namespace Chess.Models;

/// <summary>
/// Implementasi Iboard
/// </summary>
public class Board : IBoard
{
	private readonly Piece[,] _cells = new Piece[8, 8];

	public Piece[,] GetBoard() => _cells;

	private bool IsValidPosition(Vector2 position)
		=> Vector2.Clamp(position, Vector2.Zero, new Vector2(7, 7)) == position;

	public void SetBoardCell(Piece piece, Vector2 position)
	{
		if (IsValidPosition(position))
			_cells[(int)position.X, (int)position.Y] = piece;
	}

	public void SetBoardCellNull(Vector2 position)
	{
		if (IsValidPosition(position))
			_cells[(int)position.X, (int)position.Y] = null;
	}

	public Piece GetPiece(Vector2 position)
		=> IsValidPosition(position) ? _cells[(int)position.X, (int)position.Y] : null;

	/// <summary>
	/// Checks if row/col is inside 0-7 range.
	/// Used by Pieces (Rook, Knight) to prevent index out of range errors.
	/// </summary>
	public bool IsWithinBounds(int row, int col)
	{
		return row >= 0 && row < 8 && col >= 0 && col < 8;
	}

	/// <summary>
	/// Overload to get a piece using simple integers.
	/// Makes the loops in Piece classes much cleaner.
	/// </summary>
	public Piece GetPiece(int row, int col)
	{
		if (!IsWithinBounds(row, col)) return null;
		return _cells[row, col];
	}
	
	public bool IsEmptyCell(int row, int col)
		=> IsWithinBounds(row, col) && _cells[row, col] == null;
	public Piece ChangePiecePosition(Piece piece, Vector2 position)
	{
		if (!IsValidPosition(position)) return null;

		// Logic to move piece in array
		var currentPos = piece.CurrentPosition;
		_cells[currentPos.GetRow(), currentPos.GetColumn()] = null;
		_cells[(int)position.X, (int)position.Y] = piece;
		return piece;
	}

	// public void PrintBoard()
	// {
	// 	for (int y = 7; y >= 0; y--)
	// 	{
	// 		for (int x = 0; x < 8; x++)
	// 		{
	// 			var piece = _cells[x, y];
	// 			Console.Write("|" + (piece?.ID.PadRight(7) ?? "       "));
	// 		}
	// 		Console.WriteLine("|");
	// 	}
	// }
	
	public void PrintBoard()
	{
		// Simple console print for debugging
		for (int r = 7; r >= 0; r--)
		{
			for (int c = 0; c < 8; c++)
			{
				var p = _cells[r, c];
				if (p == null) Console.Write("[ ]");
				else Console.Write($"[{p.ID}]");
			}
			Console.WriteLine();
		}
	}
	
}

