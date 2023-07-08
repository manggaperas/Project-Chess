// namespace Chess;

// public class GameRules
// {
// 	private Board _board;
// 	private Player currentPlayer;
// 	public bool IsCheckmate(Player currentplayer)
// 	{
// 		List<Piece> playerPieces = _board.GetPlayerPieces((Player)currentPlayer);
// 		foreach (Piece piece in playerPieces)
// 		{
// 			List<Move> possibleMoves = piece.Moves(_board);
// 			foreach (Move move in possibleMoves)
// 			{
// 				if (!_board.MoveCausesCheck(move, currentPlayer))
// 				{
// 					return false;
// 				}
// 			}
// 		}
// 	}
// 	internal bool IsStalemate(Player currentplayer)
// 	{
// 		List<Piece> playerPieces = _board.GetPlayerPieces((Player)currentPlayer);
// 		foreach (Piece piece in playerPieces)
// 		{
// 			List<Move> possibleMoves = piece.Moves(_board);
// 			foreach (Move move in possibleMoves)
// 			{
// 				if (!_board.MoveCausesCheck(move, currentPlayer))
// 				{
// 					return false;
// 				}
// 			}
// 		}
// 		return true;
// 	}
// 	protected static IEnumerable<Piece> GetOpponentPieces(Player player)
// 	{
// 		List<Piece> pieces = new List<Piece>();
// 		Position position = new Position();
// 		var row = position.GetRow();
// 		for (int i = 0; i < row.Length; i++)
// 		{
// 			foreach (var square in row[i])
// 			{
// 				// Check if the square is occupied by an opponent's piece
// 				if (square.Occupied && square.Piece.Owner != player)
// 				{
// 					pieces.Add(square.Piece);
// 				}
// 			}
// 		}
// 		return pieces;
// 	}
// 	public Player GetPieceOwner()
// 	{
// 		return this._currentplayer;
// 	}
// }