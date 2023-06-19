namespace Chess;

public class Rook : Piece
{
	private Colours _piececolour;

	public Rook(Position position, Colours colour) : base(position, colour)
	{
		this._position = position;
		this._piececolour = colour;
	}

	public override List<Move> Moves(Board board)
	{
		List<Move> possiblemoves = new List<Move>();
		possiblemoves.AddRange(GetStraightMove(board, 1, 0));
		possiblemoves.AddRange(GetStraightMove(board, -1, 0));
		possiblemoves.AddRange(GetStraightMove(board, 0, 1));
		possiblemoves.AddRange(GetStraightMove(board, 0, -1));
		return possiblemoves;
	}
	private List<Move> GetStraightMove(Board board, int rowdirection, int coldirection)
	{
		List<Move> straightmove = new List<Move>();
		int currentrow = Position.Row + rowdirection;
		int currentcolumn = Position.Column + coldirection;
		
		while (board.IsValidPosition(currentrow, currentcolumn))
		{
			if (board.IsEmptyCell(currentrow, currentcolumn))
			{
				Position currentposition = new Position(currentrow, currentcolumn);
				straightmove.Add(new Move(currentposition, new Position(currentrow, currentcolumn)));
			}
			else if (board.IsEnemyPiece(currentrow, currentcolumn))
			
			{
				Position currentposition = new Position(currentrow, currentcolumn);
				straightmove.Add(new Move(currentposition, new Position(currentrow, currentcolumn)));
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

