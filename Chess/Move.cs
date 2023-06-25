namespace Chess;
// This class Move purpose to save position every piece

public class Move
{
	private Position _currentposition;
	private Position _newposition;
	private Player _player;
	public Move()
	{

	}
	public Move(Position currentposition, Position newposition, Player player)
	{
		this._currentposition = currentposition;
		this._newposition = newposition;
		this._player = player;
	}
	public Player GetPlayer()
	{
		return _player;
	}
	public Position GetCurrentPosition()
	{
		return this._currentposition;
	}
	public void SetCurrentPosition(Position currentposition)
	{
		_currentposition = currentposition;
	}
	public Position GetNewPosition()
	{
		return this._newposition;
	}
	public Piece SetNewPosition(Position position)
	{
		Piece piece = GetPlayerPieces();
		piece.Position = position;
		return piece;
	}
	public bool IsValidMove()
	{
		if (King.IsKingInCheck(board))
		{ // Jika raja (King) dalam kondisi di-check, kembalikan daftar gerakan kosong 
			return new List<Move>();
		}
		return true;
	}
	internal static IEnumerable<Piece> GetPlayerPieces(Player player)
	{
		throw new NotImplementedException();
	}

	internal static List<Move> GetMoves(Board board)
	{
		throw new NotImplementedException();
	}
}
