using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Chess.Models.Interfaces;

namespace Chess;

/// <summary>
/// Implementasi Iboard
/// </summary>
public class Board : IBoard
{
	private readonly Piece[,] _cells = new Piece[8, 8];

	public Piece[,] GetBoard()
	=> _cells;

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

	public bool IsEmptyCell(int row, int column)
		=> IsValidPosition(new Vector2(row, column)) && _cells[row, column] == null;

	public Piece ChangePiecePosition(Piece piece, Vector2 position)
	{
		if (!IsValidPosition(position)) return null;

		var currentPiece = _cells[(int)position.X, (int)position.Y];
		_cells[(int)position.X, (int)position.Y] = piece;
		return currentPiece;
	}

	public void PrintBoard()
	{
		for (int y = 7; y >= 0; y--)
		{
			for (int x = 0; x < 8; x++)
			{
				var piece = _cells[x, y];
				Console.Write("|" + (piece?.ID.PadRight(7) ?? "       "));
			}
			Console.WriteLine("|");
		}
	}
}