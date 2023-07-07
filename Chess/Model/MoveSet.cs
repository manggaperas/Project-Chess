using System.Numerics;

namespace Chess;


public class MoveSet
{

	private Position _position;
	private Player _currentplayer;

	public List<Position> PawnMoves(IPlayer player, Piece piece, Board board)
	{
		List<Position> possibleMove = new List<Position>();
		var currentIndex = new Vector2(1, 1);
		var possiblePosition = piece.GetPiecePosition();
		var boardHorizontalSize = board.GetBoard().GetLength(0);
		var boardVerticalSize = board.GetBoard().GetLength(1);

		var indexRow = piece.GetPiecePosition().GetRow();
		var indexCol = piece.GetPiecePosition().GetColumn();
		var tmpRow = 0;
		var tmpCol = 0;

		System.Console.WriteLine("(0)" + piece.ID + "[" + indexRow + "," + indexCol + "]");
		System.Console.WriteLine("Search for possible move...");

		switch (player.GetPlayerColours())
		{
			case Colours.White:
				var sideWhite = 1;
				while (sideWhite < 4)
				{
					System.Console.WriteLine("(" + sideWhite + ")");
					possiblePosition = piece.GetPiecePosition();
					switch (sideWhite)
					{
						case 1:
							if (!piece.IsMoved)
							{
								tmpRow = indexRow;
								tmpCol = indexCol + 2;
								if (board.GetPiece(new Vector2(tmpRow, tmpCol)) == null)
								{
									possiblePosition.SetRow(tmpRow);
									possiblePosition.SetColumn(tmpCol);					
									possibleMove.Add(new Position(possiblePosition.GetRow(), possiblePosition.GetColumn()));
									System.Console.WriteLine(piece.ID + "[" + possiblePosition.GetRow() + "," + possiblePosition.GetColumn() + "]");
								}
							}
							break;

						case 2:
							tmpRow = indexRow;
							tmpCol = indexCol + 1;
							if (board.GetPiece(new Vector2(tmpRow, tmpCol)) == null)
							{
								possiblePosition.SetRow(tmpRow);
								possiblePosition.SetColumn(tmpCol);
								possibleMove.Add(new Position(possiblePosition.GetRow(), possiblePosition.GetColumn()));
								System.Console.WriteLine(piece.ID + "[" + possiblePosition.GetRow() + "," + possiblePosition.GetColumn() + "]");
							}
							break;

						case 3:
							tmpRow = indexRow - 1;
							tmpCol = indexCol + 1;
							if (indexRow >= 0 && indexRow < boardHorizontalSize && indexCol >= 0 && indexCol < boardVerticalSize)
							{
								if (board.GetPiece(new Vector2(tmpRow, tmpCol)) != null)
								{
								possiblePosition.SetRow(tmpRow);
								possiblePosition.SetColumn(tmpCol);
								possibleMove.Add(new Position(possiblePosition.GetRow(), possiblePosition.GetColumn()));
								System.Console.WriteLine(piece.ID + "[" + possiblePosition.GetRow() + "," + possiblePosition.GetColumn() + "]");
								}
							}
							break;

						case 4:
							tmpRow = indexRow + 1;
							tmpCol = indexCol + 1;
							if (indexRow >= 0 && indexRow < boardHorizontalSize && indexCol >= 0 && indexCol < boardVerticalSize)
							{
								if (board.GetPiece(new Vector2(tmpRow, tmpCol)) != null)
								{
								possiblePosition.SetRow(tmpRow);
								possiblePosition.SetColumn(tmpCol);
								possibleMove.Add(new Position(possiblePosition.GetRow(), possiblePosition.GetColumn()));
								System.Console.WriteLine(piece.ID + "[" + possiblePosition.GetRow() + "," + possiblePosition.GetColumn() + "]");
								}
							}
							break;
					}

					sideWhite++;
				}
				System.Console.WriteLine("------------------------------");
				break;
				
			case Colours.Black:
				var sideBlack = 1;
				while (sideBlack < 4)
				{
					System.Console.WriteLine("(" + sideBlack + ")");
					possiblePosition = piece.GetPiecePosition();
					switch (sideBlack)
					{
						case 1:
							if (!piece.IsMoved)
							{
								tmpRow = indexRow;
								tmpCol = indexCol - 2;
								if (board.GetPiece(new Vector2(tmpRow, tmpCol)) == null)
								{
									possiblePosition.SetRow(tmpRow);
									possiblePosition.SetColumn(tmpCol);
									possibleMove.Add(new Position(possiblePosition.GetRow(), possiblePosition.GetColumn()));
									System.Console.WriteLine(piece.ID + "[" + possiblePosition.GetRow() + "," + possiblePosition.GetColumn() + "]");
								}
							}
							break;

						case 2:
							tmpRow = indexRow;
							tmpCol = indexCol - 1;
							if (board.GetPiece(new Vector2(tmpRow, tmpCol)) == null)
							{
								possiblePosition.SetRow(tmpRow);
								possiblePosition.SetColumn(tmpCol);
								possibleMove.Add(new Position(possiblePosition.GetRow(), possiblePosition.GetColumn()));
								System.Console.WriteLine(piece.ID + "[" + possiblePosition.GetRow() + "," + possiblePosition.GetColumn() + "]");
							}
							break;

						case 3:
							tmpRow = indexRow - 1;
							tmpCol = indexCol - 1;
							if (indexRow >= 0 && indexRow < boardHorizontalSize && indexCol >= 0 && indexCol < boardVerticalSize)
							{
								if (board.GetPiece(new Vector2(tmpRow, tmpCol)) != null)
								{
								possiblePosition.SetRow(tmpRow);
								possiblePosition.SetColumn(tmpCol);
								possibleMove.Add(new Position(possiblePosition.GetRow(), possiblePosition.GetColumn()));
								System.Console.WriteLine(piece.ID + "[" + possiblePosition.GetRow() + "," + possiblePosition.GetColumn() + "]");
								}
							}
							break;

						case 4:
							tmpRow = indexRow + 1;
							tmpCol = indexCol - 1;
							if (indexRow >= 0 && indexRow < boardHorizontalSize && indexCol >= 0 && indexCol < boardVerticalSize)
							{
								if (board.GetPiece(new Vector2(tmpRow, tmpCol)) != null)
								{
								possiblePosition.SetRow(tmpRow);
								possiblePosition.SetColumn(tmpCol);
								possibleMove.Add(new Position(possiblePosition.GetRow(), possiblePosition.GetColumn()));
								System.Console.WriteLine(piece.ID + "[" + possiblePosition.GetRow() + "," + possiblePosition.GetColumn() + "]");
								}
							}
							break;
					}

					sideBlack++;
				}
				System.Console.WriteLine("------------------------------");
				break;
		}
		return possibleMove;
	}

	public List<Position> RookMove(Board board)
	{
		List<Position> possiblemoves = new List<Position>();
		possiblemoves.AddRange(GetStraightMove(board, 1, 0));
		possiblemoves.AddRange(GetStraightMove(board, -1, 0));
		possiblemoves.AddRange(GetStraightMove(board, 0, 1));
		possiblemoves.AddRange(GetStraightMove(board, 0, -1));
		return possiblemoves;
	}

	public List<Position> KnightMove(Board board)
	{
		List<Position> possiblemoves = new List<Position>();

		int currentrow = _position.GetRow();
		int currentcol = _position.GetColumn();

		int[] knightrows = { -2, -1, 1, 2, 2, 1, -1, -2 };
		int[] knightcols = { 1, 2, 2, 1, -1, -2, -2, -1 };

		for (int i = 0; i < knightrows.Length; i++)
		{
			int newRow = currentrow + knightrows[i];
			int newCol = currentcol + knightcols[i];

			if (board.IsWithinBoardBoundaries(newRow, newCol) && (board.IsEmptyCell(newRow, newCol) || board.IsEnemyPiece(newRow, newCol)))
			{
				Position currentposition = new Position(currentrow, currentcol);
				Position newposition = new Position(newRow, newCol);
				possiblemoves.AddRange(new List<Position> { currentposition, newposition });
			}
		}

		return possiblemoves;
	}

	public List<Position> BishopMove(Board board)
	{
		List<Position> possiblemoves = new List<Position>();
		possiblemoves.AddRange(GetStraightMove(board, 1, 1));
		possiblemoves.AddRange(GetStraightMove(board, 1, -1));
		possiblemoves.AddRange(GetStraightMove(board, -1, 1));
		possiblemoves.AddRange(GetStraightMove(board, -1, -1));
		return possiblemoves;
	}

	public List<Position> QueenMoves(Board board)
	{
		List<Position> possiblemoves = new List<Position>();
		possiblemoves.AddRange(RookMove(board));
		possiblemoves.AddRange(BishopMove(board));
		return possiblemoves;
	}

	public List<Position> KingMove(Board board)
	{
		List<Position> possibleMoves = new List<Position>();
		int currentRow = _position.GetRow();
		int currentcolumn = _position.GetColumn();
		int[] kingRows = { -1, -1, -1, 0, 0, 1, 1, 1 };
		int[] kingCols = { -1, 0, 1, -1, 1, -1, 0, 1 };
		for (int i = 0; i < kingRows.Length; i++)
		{
			int newRow = currentRow + kingRows[i];
			int newCol = currentcolumn + kingCols[i];
			if (board.IsWithinBoardBoundaries(newRow, newCol) && (board.IsEmptyCell(newRow, newCol) || board.IsEnemyPiece(newRow, newCol)))
			{
				Position currentPosition = new Position(currentRow, currentcolumn);
				Position newPosition = new Position(newRow, newCol);
				possibleMoves.AddRange(new List<Position> { currentPosition, newPosition });
			}
		}
		return possibleMoves;
	}

	private void AddPosition(List<Position> positions, int currentRow, int currentcolumn, int forwardRow)
	{
		Position currentPosition = new Position(currentRow, currentcolumn);
		Position newPosition = new Position(forwardRow, currentcolumn);
		positions.AddRange(new List<Position> { currentPosition, newPosition });
	}

	private List<Position> GetStraightMove(Board board, int rowdirection, int coldirection)
	{
		List<Position> straightmove = new List<Position>();
		int currentrow = _position.GetRow() + rowdirection;
		int currentcolumn = _position.GetColumn() + coldirection;

		while (board.IsWithinBoardBoundaries(currentrow, currentcolumn))
		{
			if (board.IsEmptyCell(currentrow, currentcolumn))
			{
				Position currentposition = new Position(currentrow, currentcolumn);
				straightmove.AddRange(new List<Position> { currentposition });
			}
			else if (board.IsEnemyPiece(currentrow, currentcolumn))

			{
				Position currentposition = new Position(currentrow, currentcolumn);
				straightmove.AddRange(new List<Position> { currentposition });
				break;
			}
			else
			{
				break;
			}
			currentrow += rowdirection;
			currentcolumn += coldirection;
		}
		return straightmove;
	}

	public List<Position> GetPieceMoveSet(Player player, Piece piece, Board board)
	{
		switch (piece)
		{
			case Pawn:

				return PawnMoves(player, piece, board);

			case Knight:

				return KnightMove(board);

			case Bishop:

				return BishopMove(board);

			case Rook:

				return RookMove(board);

			case Queen:

				return QueenMoves(board);

			case King:

				return KingMove(board);
		}

		return null;
	}
}