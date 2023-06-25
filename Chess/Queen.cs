namespace Chess;

public class Queen : Piece
{
	private int _queenvalue;
	public Queen(Position position, bool status, int queenvalue) : base(position, status, queenvalue)
	{
		this._queenvalue = queenvalue;
	}
	protected override bool IsCorrectPieceType() => this.GetType() == typeof(Queen);
	public List<Move> GetQueenMove(Board board)
	{
		MoveSet queenmove = new MoveSet();
		return queenmove.QueenMoves(board);
	}
}
