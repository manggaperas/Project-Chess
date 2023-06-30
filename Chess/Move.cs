namespace Chess;


public class Move
{
	private Position _currentposition;
	private Position _newposition;
	private Player _player;
	private MoveSet _pieceMoveSet;
	private Piece _piece;
	public Move(Piece piece)
	{
		_pieceMoveSet = new MoveSet();
		_currentposition = new Position(0, 0);
		_newposition = new Position(0, 0);
		_player = new Player();
		this._piece = piece;
	}
	public MoveSet GetPiecesMovement()
	{
		return _pieceMoveSet;
	}
	public Player GetCurrentPlayer()
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
		Player player = GetCurrentPlayer();
		PieceSet pieceSet = GetPlayerPieces(player);
		piece.Position = position;
		return piece;
	}
	public bool IsValidMove()
	{
		if (IsKingInCheck(board))
		{ // Jika raja (King) dalam kondisi di-check, kembalikan daftar gerakan kosong 
			return false; //
		}
		return true;
	}
	private bool IsKingInCheck(Board board)
	{
		return false;
	}
}
