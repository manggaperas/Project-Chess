namespace Chess;

public class PieceSet
    {
        public List<Piece> Pieces { get; private set; }

        public PieceSet()
        {
            Pieces = new List<Piece>();
        }

        public void AddPiece(Piece piece)
        {
            Pieces.Add(piece);
        }

        public void RemovePiece(Piece piece)
        {
            Pieces.Remove(piece);
        }

        public List<Piece> GetPieces()
        {
            return Pieces;
        }
}


