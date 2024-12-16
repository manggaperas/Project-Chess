using System.Numerics;


namespace Chess.Models.Interfaces;


public class Move : IMove
{
	private Position _currentposition;
	private Position _newposition;
	private Player _player;
	private MoveSet _pieceMoveSet;
	private Piece _piece;

	public Move(Piece piece, Position newPosition)
	{
		_newposition = newPosition;
		_piece = piece;
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

	public Piece SetNewPosition(Board board)
	{
		return board.ChangePiecePosition(_piece, new System.Numerics.Vector2(_newposition.GetRow(), _newposition.GetColumn()));
	}

	/// <summary>IMove implementation section</summary>
	/// 
	public bool IsValidPosition(Vector2 position)
	{
		return Vector2.Clamp(position, Vector2.Zero, new Vector2(7, 7)) == position;
	}
	
	public bool CanMove(Piece piece, Vector2 targetPosition, IBoard board)
	
	{
		if (!IsValidPosition(targetPosition))
			return false;
			var targetPiece = board.GetBoard() [(int)targetPosition.X, (int)targetPosition.Y];
			
			// Aturan sederhana: bidak hanya dapat bergerak ke sel kosong atau ke sel dengan bidak lawan.
			return targetPiece == null || piece.IsEnemy(targetPiece);
	}
}
