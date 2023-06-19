namespace Chess;

public class Knight : Piece
{
	private Colours _piececolour;

	public Knight(Position position, Colours colour) : base(position, colour)
	{
		this._position = position;
		this._piececolour = colour;
	}

	public override List<Move> Moves(Board board)
	{
		List<Move> possiblemoves = new List<Move>();

		int currentrow = Position.Row;
		int currentcol = Position.Column;
		
		int[] knightrows = { -2, -1, 1, 2, 2, 1, -1, -2 };
		int[] knightcols = { 1, 2, 2, 1, -1, -2, -2, -1 };

		for (int i = 0; i < knightrows.Length; i++)
		{
			int newRow = currentrow + knightrows[i];
			int newCol = currentcol + knightcols[i];

			if (board.IsWithinBoardBoundaries(newRow, newCol) && (board.IsEmptyCell(newRow, newCol) || board.IsEnemyPiece(newRow, newCol)))
			{
				Position currentposition = new Position(currentrow, currentcol);
				Position newPosition = new Position(newRow, newCol);
				possiblemoves.Add(new Move(currentposition, newPosition));
			}
		}

		return possiblemoves;
	}
}
