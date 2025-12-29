namespace Chess.Models.Pieces
	
{
	public class King : Piece
	{
		public King(string id, Position position, Colours colour, int value) : base(id, position, colour, 1000) { }
		
		public override List<Position> GetValidMoves(Board board)
		{
			List<Position> moves = new List<Position>();
			for (int x = -1; x <= 1; x++)
			{
				for (int y = -1; y <= 1; y++)
				{
					if (x == 0 && y == 0) continue;

					int row = CurrentPosition.GetRow() + x;
					int col = CurrentPosition.GetColumn() + y;

					if (board.IsWithinBounds(row, col))
					{
						var target = board.GetPiece(row, col);
						if (target == null || IsEnemy(target))
						{
							moves.Add(new Position(row, col));
						}
					}
				}
			}
			return moves;
		}
	}
}