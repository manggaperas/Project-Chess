namespace Chess
{
	public class Pawn : Piece
	{
		private int _pawnvalue;
		public Pawn(Position position, bool status, int pawnvalue) : base(position, status, pawnvalue)
		{
			this._pawnvalue = pawnvalue;
		}
		protected override bool IsCorrectPieceType() => this.GetType() == typeof(Pawn);
		public List<Position> GetPawnMove(Board board, Piece piece)
		{
			MoveSet pawnmove = new MoveSet();
			return pawnmove.PawnMoves(board);
		}
	}
}
