namespace Chess;

/// <summary>
/// Menangani pemain yang bermain dalam permainan.
/// </summary>

public interface IPlayer
{
	/// <summary>
	/// Indikasi apakah pemain ini sedang bermain atau tidak.
	/// </summary>
	/// <returns>
	/// Mengembalikan nilai berupa true or false.
	/// </returns>
	bool IsPlaying { get; set; }
	
	/// <summary>
	/// ID pemain yang memainkan game.
	/// </summary>
	string ID { get; }
	
	/// <summary>
	/// Untuk mendapatkan player name.
	/// </summary>
	/// <returns>
	/// Mengembalikan nilai berupa string.
	/// </returns>
	string GetPlayerName();
	
	/// <summary>
	/// Untuk set nama player.
	/// </summary>
	/// <param name="name">
	/// Bidak yang diset posisinya.
	/// </param>
	void SetPlayerName(string name);
	
	Colours GetPlayerColours();
	
	void SetPlayerColours(Colours colour);
}
