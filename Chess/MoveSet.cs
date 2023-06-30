namespace Chess;
// This is list of Piece Movement include Pawn, Rook, Knight, Bishop
// Queen and King

public class MoveSet
{
	private Position _position;
	private Player _currentplayer;
	public List<Position> PawnMoves(Board board)
	{
		List<Position> positions = new List<Position>();
		int currentrow = _position.GetRow();
		int currentcolumn = _position.GetColumn();
		// Check for forward move
		int forward = currentrow + 1;
		if (forward < 8 && board.IsEmptyCell(forward, currentcolumn))
		{
			AddPosition(positions, currentrow, currentcolumn, forward);
		}
		// Check for double forward move (only valid for starting position)
		if (currentrow == 1)
		{
			int doubleforward = currentrow + 2;
			if (doubleforward < 8 && board.IsEmptyCell(doubleforward, currentcolumn) && board.IsEmptyCell(forward, currentcolumn))
			{
				AddPosition(positions, currentrow, currentcolumn, forward);
			}
		}
		return positions;
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

		while (board.IsValidPosition(currentrow, currentcolumn))
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
}
