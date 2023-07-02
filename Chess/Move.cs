namespace Chess;


public class Move
{
	private Position _currentposition;
	private Position _newposition;
	private Player _player;
	private MoveSet _pieceMoveSet;
	private Piece _piece;

	public Move(Piece piece, Position newPosition)
	{
		_newposition = newPosition;
		_piece = piece;
	}

	public MoveSet GetPiecesMovement()
	{
		return _pieceMoveSet;
	}

	public Player GetCurrentPlayer()
	{
		return _player;
	}

	public Position GetCurrentPosition()
	{
		return this._currentposition;
	}

	public void SetCurrentPosition(Position currentposition)
	{
		_currentposition = currentposition;
	}

	public Position GetNewPosition()
	{
		return this._newposition;
	}

	public Piece SetNewPosition(Board board)
	{
		return board.ChangePiecePosition(_piece, new System.Numerics.Vector2(_newposition.GetRow(), _newposition.GetColumn()));
	}
}
