namespace Chess.Models.Interfaces;

/// <summary>
/// Menangani pergerakan yang mungkin dilakukan oleh bidak catur.
/// </summary>
internal interface IMoveSet
{
		/// <summary>
		/// Mendapatkan pergerakan yang dapat dilakukan oleh bidak.
		/// </summary>
		/// <param name="player">
		/// Player yang memiliki bidak.
		/// </param>		
		/// <param name="piece">
		/// Bidak yang dicari arah pergerakannya.
		/// </param>
		/// <param name="board">
		/// Papan catur yang digunakan didalam permainan ini.
		/// </param>
		/// <returns>
		/// Mengembalikan nilai berupa List<Position>.
		/// </returns>
		List<Position> GetPieceMoveSet(Player player, Piece piece, Board board);
}
