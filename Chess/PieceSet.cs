namespace Chess;

public class PieceSet
{
    private List<Piece> _pieces;
    public PieceSet()
    {
        _pieces = new List<Piece>();
    }
    public void AddPiece(Piece piece)
    {
        _pieces.Add(piece);
    }
    public void RemovePiece(Piece piece)
    {
        _pieces.Remove(piece);
    }
    public List<Piece> GetPieces()
    {
        return _pieces;
    }
    public void SetPiece(Piece piece, Move move)
    {
        Piece existingPiece = _pieces.Find(p => p.GetPiecePosition() == piece.GetPiecePosition());
        if (existingPiece != null)
        {
            existingPiece.SetPiecePosition(move.GetNewPosition());
        }
    }
}


