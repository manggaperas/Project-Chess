namespace Chess.Models.Pieces
{
	public class Pawn : Piece
	{
		private int _value;
		public Pawn(string id, Position position, Colours colour, int value) : base(id, position, colour, 1) { }

		public override List<Position> GetValidMoves(Board board)
		{
			List<Position> moves = new List<Position>();
            
			// assume white moves UP (Row increases?) or DOWN?
			// based on your board print loop (7 down to 0), usually row 0 is bottom.
			// If white is at 1, white moves UP (+1). black moves DOWN (-1).
			int direction = (Colour == Colours.White) ? 1 : -1; 
			int currentRow = CurrentPosition.GetRow();
			int currentCol = CurrentPosition.GetColumn();
			int nextRow = currentRow + direction;

			// move forward
			if (board.IsWithinBounds(nextRow, currentCol) && board.GetPiece(nextRow, currentCol) == null)
			{
				moves.Add(new Position(nextRow, currentCol));

				// 2. Move Forward 2 steps (Only if not moved AND path is clear)
				int doubleRow = currentRow + (direction * 2);
				if (!IsMoved && board.IsWithinBounds(doubleRow, currentCol) && board.GetPiece(doubleRow, currentCol) == null)
				{
					moves.Add(new Position(doubleRow, currentCol));
				}
			}

			// captures piece
			int[] captureCols = { currentCol - 1, currentCol + 1 };
			foreach (int col in captureCols)
			{
				if (board.IsWithinBounds(nextRow, col))
				{
					var target = board.GetPiece(nextRow, col);
					// MUST be an enemy to move diagonally
					if (target != null && IsEnemy(target))
					{
						moves.Add(new Position(nextRow, col));
					}
				}
			}

			return moves;
		}
	}
}
