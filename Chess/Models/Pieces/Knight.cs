namespace Chess.Models.Pieces;

public class Knight : Piece
{
	public Knight(string id, Position position, Colours colour, int value) : base(id, position, colour, 3) { }

	public override List<Position> GetValidMoves(Board board)
	{
		List<Position> moves = new List<Position>();
		// All 8 'L' shapes
		int[][] offsets = {
			new[]{2,1}, new[]{2,-1}, new[]{-2,1}, new[]{-2,-1},
			new[]{1,2}, new[]{1,-2}, new[]{-1,2}, new[]{-1,-2}
		};

		foreach (var o in offsets)
		{
			int row = CurrentPosition.GetRow() + o[0];
			int col = CurrentPosition.GetColumn() + o[1];

			if (board.IsWithinBounds(row, col))
			{
				var target = board.GetPiece(row, col);
				// Knight can move to empty OR capture enemy
				if (target == null || IsEnemy(target))
				{
					moves.Add(new Position(row, col));
				}
			}
		}
		return moves;
	}
}

