namespace Chess;

public class Queen : Piece
{
	private int _queenvalue;
	
	public Queen(string id, Position position, bool status, int queenvalue) : base(id, position, status, queenvalue)
	{
		this._queenvalue = queenvalue;
	}
	
	protected override bool IsCorrectPieceType() => this.GetType() == typeof(Queen);
	
	public List<Position> GetQueenMove(Board board)
	{
		MoveSet queenmove = new MoveSet();
		return queenmove.QueenMoves(board);
	}
}
