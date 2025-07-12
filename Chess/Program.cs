using Chess;
using System.Diagnostics;

public class Program
{
	public static void Main(string[] args)
	{
		GameManager gamemanager = new GameManager();
		gamemanager.InitializePlayers();
		gamemanager.InitializeBoard();
		gamemanager.InitializePlayerTurn();

		Console.WriteLine(gamemanager.GetGameStatus());

		while (gamemanager.GetGameStatus() != GameStatus.Finished)
		{
			Console.WriteLine("Saat ini giliran: " + gamemanager.GetCurrentPlayerName());

			gamemanager.PrintBoard();

			Console.WriteLine("Silahkan pilih piece yang ingin digerakkan:");

			var pieceSelected = Console.ReadLine();

			gamemanager.SelectPiece(pieceSelected);
			
			gamemanager.SwitchPlayer();
		}
		gamemanager.EndGame();
	}
}