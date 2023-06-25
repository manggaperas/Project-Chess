namespace Chess;

public abstract class Piece
{
	private Position _position;
	private bool _status;
	private int _value;
	public Piece()
	{
		
	}
	public Piece(Position position, bool status, int value)
	{
		this._position = position;
		this._status = status;
		this._value = value;
	}
	public virtual Position GetPiecePosition()
	{
		return _position;
	}
	protected abstract bool IsCorrectPieceType();
	public void SetPiecePosition(Position newposition)
	{
		_position = newposition;
	}
	public int GetPieceValue()
	{
		return _value;
	}
}
