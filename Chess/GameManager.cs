namespace Chess;

public class GameManager
{
	private Board _board;
	private Player _currentplayer;
	private List<IPlayer> _players;
	private GameRules _gameRules;
	private Dictionary<Player, PieceSet> _playerpiece;
}
