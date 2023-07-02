namespace Chess
{
    public class King : Piece
    {
        public bool IsChecked { get; set; } = false;

        private int _kingvalue;
        public King(string id, Position position, bool status, int kingvalue) : base(id, position, status, kingvalue)
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