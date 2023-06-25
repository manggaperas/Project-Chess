	namespace Chess;
	// This class is for player in chess
	public class Player : IPlayer
	{
		private string _name;
		private Colours _colour;
		public Player()
		{
			
		}
		public Player(string name, Colours colour)
		{
			this._name = name;
			this._colour = colour;
		}
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
	}
