namespace Chess
{
	public class King : Piece
	{
		public bool IsChecked { get; set; } = false;

		private int _value;
		
		public King(string id, Position position, bool status, int value) : base(id, position, status, value)
		{
			this._value = value;
		}
		
		protected override bool IsCorrectPieceType() => this.GetType() == typeof(King);
		
		public List<Position> GetKingMove(Board board)
		{
			MoveSet kingmove = new MoveSet();
			return kingmove.KingMove(board);
		}
	}
}