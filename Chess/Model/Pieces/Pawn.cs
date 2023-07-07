namespace Chess
{
	public class Pawn : Piece
	{
		private int _value;
		public Pawn(string id, Position position, bool status, int value) : base(id, position, status, value)
		{
			this._value = value;
		}
		
		protected override bool IsCorrectPieceType() => this.GetType() == typeof(Pawn);
		
		//public List<Position> GetPawnMove(Board board, Piece piece)
		
		//{
		//	MoveSet pawnmove = new MoveSet();
		//	return pawnmove.PawnMoves(piece, board);
		//}
	}
}
