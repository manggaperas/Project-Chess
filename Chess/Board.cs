namespace Chess;

public class Board
{
	private int[,] _cells;
	public Board()
	{
		_cells = new int[8, 8];
	}
	public Board(int[,] cells)
	{
		this._cells = cells;
	}
	public void SetBoardCell(int row, int column, int value)
	{
		_cells[row, column] = value;
	}
	public int[,] GetBoardCell()
	{
		return _cells;
	}
	public bool IsEmptyCell(int row, int column)
	{
		if (IsValidPosition(row, column))
		{
			return _cells[row, column] == null;
		}
		return false;
	}
	public bool IsValidPosition(int row, int column)
	{
		return row >= 0 && row < 8 && column >= 0 && column < 8;
	}
	public bool IsWithinBoardBoundaries(int row, int column)
	{
		return row >= 0 && row < 8 && column >= 0 && column < 8;
	}
	public bool IsEnemyPiece(int row, int column)
	{
		return row >= 0 && row < 8 && column >= 0 && column < 8;
	}
}