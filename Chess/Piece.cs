namespace Chess;

public abstract class Piece
{
	protected bool p_status { get; set;}
	protected List<Position> p_position { get; set; }
	
	public Piece()
	{
		p_position = new List<Position>();
	}
	public void LegalMove(Board board)
	{
		
	}
}
