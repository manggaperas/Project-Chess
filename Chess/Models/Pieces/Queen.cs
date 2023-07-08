namespace Chess;

public class Queen : Piece
{
	private int _value;
	
	public Queen(string id, Position position, bool status, int value) : base(id, position, status, value)
	{
		this._value = value;
	}
	
	protected override bool IsCorrectPieceType() => this.GetType() == typeof(Queen);
	
	public List<Position> GetQueenMove(Board board)
	{
		MoveSet queenmove = new MoveSet();
		return queenmove.QueenMoves(board);
	}
}
