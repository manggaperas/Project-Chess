namespace Chess.Models.Pieces;

public class Queen : Piece
{
	public Queen(string id, Position position, Colours colour) : base(id, position, colour, 9)
	{
	}

	public override List<Position> GetValidMoves(Board board)
	{
		List<Position> moves = new List<Position>();
		int[][] dirs =
		{
			new[] { 1, 0 }, new[] { -1, 0 }, new[] { 0, 1 }, new[] { 0, -1 },
			new[] { 1, 1 }, new[] { 1, -1 }, new[] { -1, 1 }, new[] { -1, -1 }
		};

		foreach (var d in dirs)
		{
			AddSlidingMoves(board, moves, d[0], d[1]);
		}

		return moves;
	}
}
