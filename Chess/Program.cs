using Chess.Controllers;
using System.Diagnostics;
using Chess;

public class Program
{
	public static void Main(string[] args)
	{
		GameManager gamemanager = new GameManager();
		Console.WriteLine("=== WELCOME TO C# CHESS ===");
		
		// setup players
		gamemanager.InitializePlayers();
		
		// setup board and pieces
		gamemanager.InitializeBoard();
		gamemanager.InitializePlayerTurn();

		while (gamemanager.GetGameStatus() == GameStatus.Active)
		{
			try
			{
				// Let the current player take their turn
				gamemanager.PlayTurn();

				// If the player didn't EXIT, swap to the next person
				if (gamemanager.GetGameStatus() == GameStatus.Active)
				{
					gamemanager.SwitchPlayer();
				}
			}
			catch (Exception ex)
			{
				// Catch-all to prevent the app from closing on unexpected errors
				Console.WriteLine($"An error occurred: {ex.Message}");
				Console.WriteLine("Press any key to try the turn again...");
				Console.ReadKey();
			}
		}
		Console.WriteLine("\n==================================");
		Console.WriteLine("Game Over. Thank you for playing!");
		Console.WriteLine("==================================");
		Console.ReadKey();
	}
}