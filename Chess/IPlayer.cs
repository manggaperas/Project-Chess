namespace Chess;

public interface IPlayer
{
	void SetPlayerName(string name);
	string GetPlayerName();
	Colours GetPlayerColours();
	void SetPlayerColours(Colours colour);
}
