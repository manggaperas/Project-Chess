namespace Chess;

public class Position
{
	private int _column { get; set; }
	private int _row { get; set; }
	
	public Position(int column, int row)
	{
		this._column = column;
		this._row = row;
	}
}
