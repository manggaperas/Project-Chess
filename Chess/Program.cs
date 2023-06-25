using Chess;

public class Program
{
	private GameManager _gamemanager;
	public static void Main(string[] args)
	{
		GameManager gamemanager = new GameManager();
		Console.WriteLine("Press enter to continue...");
		Console.ReadKey();
		Console.Clear();
		Console.WriteLine("ようこそ、私の");
		Console.Title = "ASCII ART";
		string title = @"
   _____  _    _  ______   _____  _____ 
  / ____|| |  | ||  ____| / ____|/ ____|
 | |     | |__| || |__   | (___ | (___  
 | |     |  __  ||  __|   \___ \ \___ \ 
 | |____ | |  | || |____  ____) |____) |
  \_____||_|  |_||______||_____/|_____/ 
";
		Console.WriteLine(title);
		Console.ReadKey();
		Console.Clear();
		gamemanager.InitializePlayers();
		gamemanager.InitializeBoard();
		gamemanager.PlayerTurn();
		gamemanager.SwitchPlayer();
		gamemanager.EndGame();
		while (gamemanager.GetGameStatus() != GameManager.GameStatus.Finished)
		{
			Console.WriteLine("Saat ini giliran: " + gamemanager.GetCurrentPlayerName());

			foreach (Piece piece in Move.GetPlayerPieces((Player)gamemanager.GetCurrentPlayer()))
			{
				Console.WriteLine(piece.Name); // object
			}

			Console.WriteLine("Pilih bidak yang akan dipindahkan: ");
			string selectedPieceName = Console.ReadLine();

			Piece selectedPiece = null;
			foreach (Piece piece in gamemanager.GetPlayerPieces((Player)gamemanager.GetCurrentPlayer()))
			{
				if (piece.Name == selectedPieceName)
				{
					selectedPiece = piece;
					break;
				}
			}

			if (selectedPiece != null)
			{
				if (gamemanager.IsGameFinished())
				{
					gamemanager.EndGame();
				}
				else
				{
					gamemanager.SwitchPlayer();
				}
			}
			else
			{
				Console.WriteLine("Bidak yang dipilih tidak valid. Silakan coba lagi.");
			}
		}
	}
}