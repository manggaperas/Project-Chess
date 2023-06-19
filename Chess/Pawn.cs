namespace Chess
{
    public class Pawn : Piece
    {
        private Colours _pieceColour;

        public Pawn(Position position, Colours colour) : base(position, colour)
        {
            _pieceColour = colour;
        }

        public override List<Move> Moves(Board board)
        {
            List<Move> possibleMoves = new List<Move>();

            int currentRow = Position.Row;
            int currentColumn = Position.Column;

            // Check for forward move
            int forwardRow = currentRow + 1;
            if (forwardRow < 8 && board.IsEmptyCell(forwardRow, currentColumn))
            {
                AddPosition(possibleMoves, currentRow, currentColumn, forwardRow);
            }

            // Check for double forward move (only valid for starting position)
            if (currentRow == 1)
            {
                int doubleForwardRow = currentRow + 2;
                if (doubleForwardRow < 8 && board.IsEmptyCell(doubleForwardRow, currentColumn) && board.IsEmptyCell(forwardRow, currentColumn))
                {
                    AddPosition(possibleMoves, currentRow, currentColumn, forwardRow);
                }
            }

            // Check for capture moves
            int captureRowLeft = currentRow + 1;
            int captureColLeft = currentColumn - 1;
            if (captureRowLeft < 8 && captureColLeft >= 0 && board.IsEnemyPiece(captureRowLeft, captureColLeft))
            {
                AddPosition(possibleMoves, currentRow, currentColumn, forwardRow);
            }

            int captureRowRight = currentRow + 1;
            int captureColRight = currentColumn + 1;
            if (captureRowRight < 8 && captureColRight < 8 && board.IsEnemyPiece(captureRowRight, captureColRight))
            {
                AddPosition(possibleMoves, currentRow, currentColumn, forwardRow);
            }

            return possibleMoves;
        }

        private static void AddPosition(List<Move> possibleMoves, int currentRow, int currentColumn, int forwardRow)
        {
            Position currentPosition = new Position(currentRow, currentColumn);
            Position newPosition = new Position(forwardRow, currentColumn);
            possibleMoves.Add(new Move(currentPosition, newPosition));
        }
    }
}
