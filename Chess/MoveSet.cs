namespace Chess;
// This is list of Piece Movement include Pawn, Rook, Knight, Bishop
// Queen and King

public class MoveSet
{
	private Position _position;
	private Player _currentplayer;
	public List<Move> PawnMoves(Board board)
	{
		List<Move> possibleMoves = new List<Move>();

		int currentrow = _position.GetRow();
		int currentcolumn = _position.GetColumn();

		// Check for forward move
		int forwardRow = currentrow + 1;
		if (forwardRow < 8 && board.IsEmptyCell(forwardRow, currentcolumn))
		{
			AddPosition(possibleMoves, currentrow, currentcolumn, forwardRow);
		}

		// Check for double forward move (only valid for starting position)
		if (currentrow == 1)
		{
			int doubleForwardRow = currentrow + 2;
			if (doubleForwardRow < 8 && board.IsEmptyCell(doubleForwardRow, currentcolumn) && board.IsEmptyCell(forwardRow, currentcolumn))
			{
				AddPosition(possibleMoves, currentrow, currentcolumn, forwardRow);
			}
		}

		// Check for capture moves
		int captureRowLeft = currentrow + 1;
		int captureColLeft = currentcolumn - 1;
		if (captureRowLeft < 8 && captureColLeft >= 0 && board.IsEnemyPiece(captureRowLeft, captureColLeft))
		{
			AddPosition(possibleMoves, currentrow, currentcolumn, forwardRow);
		}

		int captureRowRight = currentrow + 1;
		int captureColRight = currentcolumn + 1;
		if (captureRowRight < 8 && captureColRight < 8 && board.IsEnemyPiece(captureRowRight, captureColRight))
		{
			AddPosition(possibleMoves, currentrow, currentcolumn, forwardRow);
		}

		return possibleMoves;
	}
	public List<Move> RookMove(Board board)
	{
		List<Move> possiblemoves = new List<Move>();
		possiblemoves.AddRange(GetStraightMove(board, 1, 0));
		possiblemoves.AddRange(GetStraightMove(board, -1, 0));
		possiblemoves.AddRange(GetStraightMove(board, 0, 1));
		possiblemoves.AddRange(GetStraightMove(board, 0, -1));
		return possiblemoves;
	}
	public List<Move> KnightMove(Board board)
	{
		List<Move> possiblemoves = new List<Move>();

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
				possiblemoves.Add(new Move(currentposition, newposition, _currentplayer));
			}
		}

		return possiblemoves;
	}
	public List<Move> BishopMove(Board board)
	{
		List<Move> possiblemoves = new List<Move>();
		possiblemoves.AddRange(GetStraightMove(board, 1, 1));
		possiblemoves.AddRange(GetStraightMove(board, 1, -1));
		possiblemoves.AddRange(GetStraightMove(board, -1, 1));
		possiblemoves.AddRange(GetStraightMove(board, -1, -1));
		return possiblemoves;
	}
	public List<Move> QueenMoves(Board board)
	{
		List<Move> possiblemoves = new List<Move>();
		possiblemoves.AddRange(RookMove(board));
		possiblemoves.AddRange(BishopMove(board));
		return possiblemoves;
	}
	public List<Move> KingMove(Board board)
	{
		List<Move> possibleMoves = new List<Move>();
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
				possibleMoves.Add(new Move(currentPosition, newPosition, _currentplayer));
			}
		}
		return possibleMoves;
	}
	private void AddPosition(List<Move> possibleMoves, int currentRow, int currentcolumn, int forwardRow)
	{
		Position currentPosition = new Position(currentRow, currentcolumn);
		Position newPosition = new Position(forwardRow, currentcolumn);
		possibleMoves.Add(new Move(currentPosition, newPosition, _currentplayer));
	}
	private List<Move> GetStraightMove(Board board, int rowdirection, int coldirection)
	{
		List<Move> straightmove = new List<Move>();
		int currentrow = _position.GetRow() + rowdirection;
		int currentcolumn = _position.GetColumn() + coldirection;

		while (board.IsValidPosition(currentrow, currentcolumn))
		{
			if (board.IsEmptyCell(currentrow, currentcolumn))
			{
				Position currentposition = new Position(currentrow, currentcolumn);
				straightmove.Add(new Move(currentposition, new Position(currentrow, currentcolumn), _currentplayer));
			}
			else if (board.IsEnemyPiece(currentrow, currentcolumn))

			{
				Position currentposition = new Position(currentrow, currentcolumn);
				straightmove.Add(new Move(currentposition, new Position(currentrow, currentcolumn), _currentplayer));
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
	internal static List<Piece> GetOpponentPieces(Player player)
	{
		throw new NotImplementedException();
	}
	public Player GetPieceOwner()
	{
		return this._currentplayer;
	}
}
