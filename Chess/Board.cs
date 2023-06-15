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
		for (int x = 0; x < 8; x++)
		{
			for (int y = 0; y < 8; y++)
			{
				_boardindex[x, y] = 0;
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
				System.Console.WriteLine("[    ]    ");
			}
		System.Console.WriteLine();
		System.Console.WriteLine();
		}
	}
}