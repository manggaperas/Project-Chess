namespace Chess;

public class Knight : Piece
{
	private int _value;
	
	public Knight(string id, Position position, bool status, int value) : base(id, position, status, value)
	{
		this._value = value;
	}
	
	protected override bool IsCorrectPieceType() => this.GetType() == typeof(Knight);
	
	public List<Position> GetKnightMove(Board board)
	{
		MoveSet rookmove = new MoveSet();
		return rookmove.RookMove(board);
	}
}

