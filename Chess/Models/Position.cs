namespace Chess;

public class Position
{
	private int _column;
	private int _row;
	
	public Position(int row, int column)
	{
		this._column = column;
		this._row = row;
	}
	
	public int GetRow() => _row;
	public int GetColumn() => _column;
	
	public void SetRow(int row) => _row = row;
	public void SetColumn(int column) => _column = column;
	
}
