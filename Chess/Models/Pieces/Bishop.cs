namespace Chess.Models.Pieces;

public class Bishop : Piece
{
	public Bishop(string id, Position position, Colours colour, int value) : base(id, position, colour, 3) { }

	public override List<Position> GetValidMoves(Board board)
	{
		List<Position> moves = new List<Position>();
		AddSlidingMoves(board, moves, 1, 1);
		AddSlidingMoves(board, moves, 1, -1);
		AddSlidingMoves(board, moves, -1, 1);
		AddSlidingMoves(board, moves, -1, -1);
		return moves;
	}
}

