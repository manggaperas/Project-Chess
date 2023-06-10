namespace Chess;

public abstract class Piece
{
	private bool status;
	private Position Position;
	
	public Piece(Position position)
	{
		this.Position = position;
	}
}
