namespace Chess
{
	public class King : Piece
	{
		private int _kingvalue;
		public King(Position position, bool status, int kingvalue) : base(position, status, kingvalue)
		{
			this._kingvalue = kingvalue;
		}
		protected override bool IsCorrectPieceType() => this.GetType() == typeof(King);
		public List<Move> GetKingMove(Board board)
		{
			MoveSet kingmove = new MoveSet();
			return kingmove.KingMove(board);
		}
		public bool IsKingInCheck(Board board)
		{ // Cek setiap bidak di papan untuk setiap pemain
			MoveSet moveset = new MoveSet();
			foreach (Player player in MoveSet.GetOpponentPieces(player))
			{
				List<Piece> opponentPieces = MoveSet.GetOpponentPieces(player); // Periksa setiap bidak musuh
				foreach (Piece piece in opponentPieces)
				{
					if (piece != null)
					{ // Periksa apakah bidak musuh dapat menyerang raja
						List<Move> moves = Move.GetMoves(board);
						foreach (Move move in moves)
						{
							if (move.GetNewPosition() == this.Position.Row && move.To.Col == this.Position.Col)
							{
								return true; // Raja dalam kondisi di-check
							}
						}
					}
				}
			}
			// Jika raja tidak dalam kondisi di-check
			return false;
		}
	}
}
