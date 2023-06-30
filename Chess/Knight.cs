namespace Chess;

public class Knight : Piece
{
	private int _knightvalue;
	public Knight(Position position, bool status, int knightvalue) : base(position, status, knightvalue)
	{
		this._knightvalue = knightvalue;
	}
	protected override bool IsCorrectPieceType() => this.GetType() == typeof(Knight);
	public List<Position> GetKnightMove(Board board)
	{
		MoveSet rookmove = new MoveSet();
		return rookmove.RookMove(board);
	}
}

