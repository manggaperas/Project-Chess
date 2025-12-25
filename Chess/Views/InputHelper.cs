namespace Chess.Views;

public class InputHelper
{
	public static string GetString(string prompt)
	{
		Console.Write(prompt);
		string input = Console.ReadLine();

		while (string.IsNullOrEmpty(input))
		{
			Console.Write("Invalid input, try again: ");
			input = Console.ReadLine();
		}
		return input;
	}

	public static string GetChoice(string prompt, string[] validOptions)
	{
		Console.Write(prompt);
		string input = Console.ReadLine();

		while (Array.IndexOf(validOptions, input) < 0)
		{
			Console.Write($"Invalid choice. Please enter ({string.Join("/", validOptions)}): ");
			input = Console.ReadLine();
		}
		return input;
	}
}
