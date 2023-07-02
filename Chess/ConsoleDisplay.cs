namespace Chess;

public static class ConsoleDisplay
{
	
	public static void EnterName(Player player)
	{
		string name = InputHelper.Input("Enter your name: ");
		player.SetPlayerName(name);
	}
	
	public static void EnterColour(Player player)
	{
		InputHelper.Input($"{player.GetPlayerName()}  Choose your colour: ");
		Console.WriteLine("1. White");
		Console.WriteLine("2. Black");
		Console.Write("Enter your choise (1 or 2): ");
		int choice = int.Parse(Console.ReadLine());
		player.SetPlayerColours(choice == 1 ? Colours.White : Colours.Black);
	}
	
	public static void TurnInfo(Player player)
	{
		
	}

	public static void EnterMove(IPlayer currentPlayer, Board board, out Move? move)
	{
		throw new NotImplementedException();
	}
	
}
