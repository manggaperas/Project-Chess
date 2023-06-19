namespace Chess;

public abstract class Piece
{
	protected Position _position { get; set; }
	protected Colours _piececolours { get; }
    public Position Position { get; internal set; } //cek mana yang dieliminasi
    public string? Name { get; internal set; }

    public Piece(Position position, Colours colour)
	{
		this._position = position;
		this._piececolours = colour;
	}
	public abstract List<Move> Moves(Board board);

    public static implicit operator int(Piece v)
    {
        return 0;
    }
}
