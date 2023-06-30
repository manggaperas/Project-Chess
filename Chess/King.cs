namespace Chess
{
    public class King : Piece
    {
        private int _kingvalue;
        public King(Position position, bool status, int kingvalue) : base(position, status, kingvalue)
        {
            this._kingvalue = kingvalue;
        }
        protected override bool IsCorrectPieceType() => this.GetType() == typeof(King);
        public List<Position> GetKingMove(Board board)
        {
            MoveSet kingmove = new MoveSet();
            return kingmove.KingMove(board);
        }
    }
}