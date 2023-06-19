namespace Chess;

public class Bishop : Piece
{
	private Colours _piececolour;

	public Bishop(Position position, Colours colour) : base(position, colour)
	{
		this._position = position;
		this._piececolour = colour;
	}

	public override List<Move> Moves(Board board)
	{
		List<Move> possiblemoves = new List<Move>();
		possiblemoves.AddRange(GetStraightMove(board, 1, 1));
		possiblemoves.AddRange(GetStraightMove(board, 1, -1));
		possiblemoves.AddRange(GetStraightMove(board, -1, 1));
		possiblemoves.AddRange(GetStraightMove(board, -1, -1));
		return possiblemoves;
	}

	private List<Move> GetStraightMove(Board board, int rowDirection, int columnDirection)
	{
		List<Move> straightmoves = new List<Move>();

		int currentrow = Position.Row + rowDirection;
		int currentcol = Position.Column + columnDirection;

		while (board.IsValidPosition(currentrow, currentcol))
		{
			if (board.IsEmptyCell(currentrow, currentcol))
			{
				Position currentposition = new Position(currentrow, currentcol);
				straightmoves.Add(new Move(currentposition, new Position(currentrow, currentcol)));
			}
			else if (board.IsEnemyPiece(currentrow, currentcol))
			{
				Position currentposition = new Position(currentrow, currentcol);
				straightmoves.Add(new Move(currentposition, new Position(currentrow, currentcol)));
				break;
			}
			else
			{
				break;
			}

			currentrow += rowDirection;
			currentcol += columnDirection;
		}

		return straightmoves;
	}
}

