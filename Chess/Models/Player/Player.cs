namespace Chess;

	/// <summary>
	/// Implemetnasi IPlayer.
	/// </summary>
public class Player : IPlayer
{
	#region Variable

	private string _name;
	private Colours _colour;
	public bool IsPlaying { get; set; } = false;
	public string ID { get; private set; } = string.Empty;
	
	#endregion //Variable

	#region Constructor
	public Player()
	{

	}
	
	public Player(string name, Colours colour)
	{
		this._name = name;
		this._colour = colour;
	}
	
	#endregion //Constructor

	#region IPlayer
	
	public string GetPlayerName()
	{
		return _name;
	}
	
	public void SetPlayerName(string name)
	{
		_name = name;
	}
	
	public Colours GetPlayerColours()
	{
		// return (Colours)Enum.Parse(typeof(Colours), _colour.ToString());
		return _colour;
	}
	
	public void SetPlayerColours(Colours colour)
	{
		_colour = colour;
	}
	
	#endregion //IPlayer
}
