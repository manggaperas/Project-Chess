using Chess;
using System.Diagnostics;

public class Program
{
	private GameManager _gamemanager;
	
	public static void Main(string[] args)
	{
		GameManager gamemanager = new GameManager();
		Console.WriteLine("Press enter to continue...");
		Console.ReadKey();
		Console.Clear();
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
		gamemanager.InitializePlayers();
		gamemanager.InitializeBoard();
		gamemanager.InitializePlayerTurn();

		Console.WriteLine(gamemanager.GetGameStatus());

		while (gamemanager.GetGameStatus() != GameStatus.Finished)
		{
			Console.WriteLine("Saat ini giliran: " + gamemanager.GetCurrentPlayerName());

			gamemanager.UpdateBoard();

			Console.WriteLine("Silahkan pilih piece yang ingin digerakkan :");

			var pieceSelected = Console.ReadLine();

			gamemanager.SelectPiece(pieceSelected);

			// gamemanager.EndGame();
		}
	}
}