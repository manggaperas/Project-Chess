namespace Chess.Models.Pieces;

public class PieceSet
{
	private List<Piece> _pieces;
	
	public PieceSet()
	{
		_pieces = new List<Piece>();
	}
	
	public void AddPiece(Piece piece) => _pieces.Add(piece);
	
	public void RemovePiece(Piece piece) => _pieces.Remove(piece);
	
	public List<Piece> GetPieces() => _pieces;
	
	public Piece GetPiece(string id)
	{
		return _pieces.FirstOrDefault(piece => piece.ID.Equals(id, System.StringComparison.OrdinalIgnoreCase));
	}

	public King GetKing()
	{
		return _pieces.OfType<King>().FirstOrDefault();
	}
}


