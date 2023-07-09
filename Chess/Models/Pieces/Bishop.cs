namespace Chess;

public class Bishop : Piece
{
	private int _value;
	
	public Bishop(string id, Position position, bool status, int value) : base(id, position, status, value)
	{
		this._value = value;
	}
	
	protected override bool IsCorrectPieceType() => this.GetType() == typeof(Bishop);
	
	// public List<Position> GetBishopMove(Board board)
	// {
	// 	MoveSet bishopmove = new MoveSet();
	// 	return bishopmove.BishopMove(board);
	// }
}

