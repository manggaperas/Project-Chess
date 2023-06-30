namespace Chess;

public abstract class Piece
{
	private Position _position;
	private bool _status;
	private int _value;
	public Piece(Position position, bool status, int value)
	{
		_position = new(0, 0);
		this._status = status;
		this._value = value;
	}
	public virtual Position GetPiecePosition()
	{
		return _position;
	}
	public void SetPiecePosition(Position position)
	{
		_position = position;
	}
	public int GetPieceValue()
	{
		return _value;
	}
	protected abstract bool IsCorrectPieceType();
}
