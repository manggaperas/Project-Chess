namespace Chess.Models.Pieces;

public abstract class Piece
{
	// private variable
	private string _id;
	private Position _position;
	private Colours _colour;
	private bool _isMoved;
	private int _value;
	
	// construct
	public Piece(string id, Position position, Colours colour, int value)
	{
		_id = id;
		_position = position;
		_isMoved = false;
		_colour = colour;
		_value = value;
	}
	
	// public variable
	public string ID => _id;
	public Position CurrentPosition => _position;
	public Colours Colour => _colour;
	public bool IsMoved => _isMoved;
	public int Value => _value;
	
	// save position
	public void MoveTo(Position newPosition)
	{
		_position = newPosition;
		_isMoved = true;
	}
	
	// abstract
	public abstract List<Position> GetValidMoves(Board board);
	
	// helper for identify enemy
	public bool IsEnemy(Piece other)
	{
		return other != null && this.Colour != other.Colour;
	} 
	
	// helper Raycasting (The Sliding Logic)
	// make it protected for Rook/Bishop/Queen
	protected void AddSlidingMoves(Board board, List<Position> moves, int dRow, int dCol)
	{
		int row = _position.GetRow() + dRow;
		int col = _position.GetColumn() + dCol;

		while (board.IsWithinBounds(row, col))
		{
			var target = board.GetPiece(row, col);
			if (target == null)
			{
				moves.Add(new Position(row, col));
			}
			else
			{
				if (IsEnemy(target)) moves.Add(new Position(row, col));
				break; // if the piece was blocked
			}
			row += dRow;
			col += dCol;
		}
	}
	
}
