namespace Chess
{
    public class King : Piece
    {
        private Colours _pieceColour;

        public King(Position position, Colours colour) : base(position, colour)
        {
            _pieceColour = colour;
        }

        public override List<Move> Moves(Board board)
        {
            List<Move> possibleMoves = new List<Move>();

            int currentRow = Position.Row;
            int currentColumn = Position.Column;

            int[] kingRows = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] kingCols = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int i = 0; i < kingRows.Length; i++)
            {
                int newRow = currentRow + kingRows[i];
                int newCol = currentColumn + kingCols[i];

                if (board.IsWithinBoardBoundaries(newRow, newCol) && (board.IsEmptyCell(newRow, newCol) || board.IsEnemyPiece(newRow, newCol)))
                {
                    Position currentPosition = new Position(currentRow, currentColumn);
                    Position newPosition = new Position(newRow, newCol);
                    possibleMoves.Add(new Move(currentPosition, newPosition));
                }
            }

            return possibleMoves;
        }
    }
}
