namespace Chess;

public class Rook : Piece
{
	private int _value;
	
	public Rook(string id, Position position, bool status, int value) : base(id, position, status, value)
	{
		this._value = value;
	}
	
	protected override bool IsCorrectPieceType() => this.GetType() == typeof(Rook);
	
	// public List<Position> GetRookMove(Board board)
	// {
	// 	MoveSet rookmove = new MoveSet();
	// 	return rookmove.RookMove(board);
	// }
}

