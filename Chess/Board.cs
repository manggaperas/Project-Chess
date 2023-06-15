namespace Chess;

public class Board
{
	private int[,] _boardindex;

	public Board()
	{
		_boardindex = new int[8, 8];
		DrawBoard();
	}
	private void DrawBoard()
	{
		for (int row = 0; row < 8; row++)
		{
			for (int col = 0; col < 8; col++)
			{
				_boardindex[row, col] = 0;
			}
		}
	}
	public void PrintBoard()
	{
		int x = _boardindex.GetLength(0);
		int y = _boardindex.GetLength(1);
		for (int i = 0; i < x; i++)
		{
			for (int j = 0; j < y; j++)
			{
				System.Console.WriteLine("[  ]");
			}
		System.Console.WriteLine("");
		}
	}
}