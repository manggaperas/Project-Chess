namespace Chess;

public abstract class Piece
{
	private Position _position;
	private bool _status;
	private int _value;
	private Position position;
	private bool status;

	public string ID { get; private set; }
	
	public bool IsMoved { get; set; } = false;

	public Piece(string id, Position position, bool status, int value)
	{
		ID = id;
		_position = position;
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
