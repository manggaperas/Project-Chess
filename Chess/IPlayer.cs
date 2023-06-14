namespace Chess;

public interface IPlayer
{
	public void SetName();
	public void GetName();
	public static Colours GetColours()
	{
		Colours colour = new Colours();
		return colour;
	}
}
