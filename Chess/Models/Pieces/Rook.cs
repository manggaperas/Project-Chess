namespace Chess.Models.Pieces;

public class Rook : Piece
{
	public Rook(string id, Position position, Colours colour) : base(id, position, colour, 5)
	{
	}
	
	public override List<Position> GetValidMoves(Board board)
	{
		List<Position> moves = new List<Position>();
		
		AddSlidingMoves(board, moves, 1, 0);
		AddSlidingMoves(board, moves, -1, 0);
		AddSlidingMoves(board, moves, 0, 1);
		AddSlidingMoves(board, moves, 0, 1);
		return moves;
	}
}

