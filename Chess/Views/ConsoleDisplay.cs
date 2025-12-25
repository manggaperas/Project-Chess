namespace Chess.Views;

public static class ConsoleDisplay
{
	public static void EnterName(Player player)
	{
		string name = InputHelper.GetString("Enter your name: ");
		player.SetPlayerName(name);
	}
	
	public static void EnterColour(Player player)
	{
		Console.WriteLine($"Hi {player.GetPlayerName()}, choose your side:");
		Console.WriteLine("1. White");
		Console.WriteLine("2. Black");
		
		string choice = InputHelper.GetChoice("Enter choice (1 or 2): ", new[] { "1", "2" });
		
		if (choice == "1")
			player.SetPlayerColours(Colours.White);
		else
			player.SetPlayerColours(Colours.Black);
	}
}
