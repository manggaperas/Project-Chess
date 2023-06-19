namespace Chess;

public class Player : IPlayer
{
	private string _name;
	private string _colour;
    public Colours Colour { get; internal set; }

    public Player(string name, string colour)
	{
		this._colour = colour;
		this._name = name;
	}
	public string GetName()
	{
		return _name;
	}
	public void SetName()
	{
		
	}
	public void GetColours()
	{
		
	}
}
