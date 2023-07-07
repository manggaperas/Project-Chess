namespace Chess;

public class InputHelper
{
	public static string Input(string message)
	{
		return Message(message);
	}
	
	private static string Message(string message)
	{
		Console.Write(message);
		return Console.ReadLine();
	}
}
