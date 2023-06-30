namespace Chess;

public class Rook : Piece
{
	private int _rookvalue;
	public Rook(Position position, bool status, int rookvalue) : base(position, status, rookvalue)
	{
		this._rookvalue = rookvalue;
	}
	protected override bool IsCorrectPieceType() => this.GetType() == typeof(Rook);
	public List<Position> GetRookMove(Board board)
	{
		MoveSet rookmove = new MoveSet();
		return rookmove.RookMove(board);
	}
}

