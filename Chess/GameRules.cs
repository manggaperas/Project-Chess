// namespace Chess;

// public class GameRules
// {
// 	private Board _board;
// 	private object currentPlayer;

// 	internal bool IsCheckmate(Player currentplayer)
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
// }