namespace Chess;

public class Bishop : Piece
{
	private int _bishopvalue;
	public Bishop(Position position, bool status, int bishopvalue) : base(position, status, bishopvalue)
	{
		this._bishopvalue = bishopvalue;
	}
	protected override bool IsCorrectPieceType() => this.GetType() == typeof(Bishop);
	public List<Position> GetBishopMove(Board board)
	{
		MoveSet bishopmove = new MoveSet();
		return bishopmove.BishopMove(board);
	}
}

