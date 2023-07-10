using System.Numerics;
using Chess.Models.Interfaces;

namespace Chess;

/// <summary>
/// Implementasi IMoveSet.
/// </summary>
public class MoveSet : IMoveSet
{
    #region Variable

    /// <summary>
    /// Gerakan yang bisa dilakukan oleh bidak yang dipilih.
    /// </summary>
    List<Position> possibleMove = new List<Position>();

    #endregion //Variable

    #region Main

    /// <summary>
    /// Gerakan yang mungkin dilakukan oleh bidak tipe Pawn.
    /// </summary>
    ///	<param name="player">
    /// Player yang memiliki piece.
    /// <param name="piece">
    /// Bidak yang digerakkan.
    /// </param>
    /// <param name="board">
    /// Papan catur tempat bidak dimainkan.
    /// </param>
    /// <returns>
    /// Mengembalikan nilai berupa List<Position>.
    /// </returns>
    public List<Position> PawnMoves(IPlayer player, Piece piece, Board board)
    {
        possibleMove.Clear();
        var currentIndex = new Vector2(1, 1);
        var possiblePosition = piece.GetPiecePosition();
        var boardHorizontalSize = board.GetBoard().GetLength(0);
        var boardVerticalSize = board.GetBoard().GetLength(1);

        var indexRow = piece.GetPiecePosition().GetRow();
        var indexCol = piece.GetPiecePosition().GetColumn();
        var tmpRow = 0;
        var tmpCol = 0;

        System.Console.WriteLine("(0)" + piece.ID + "[" + indexRow + "," + indexCol + "]");
        System.Console.WriteLine("Search for possible move...");

        switch (player.GetPlayerColours())
        {
            case Colours.White:
                var sideWhite = 1;
                while (sideWhite < 4)
                {
                    System.Console.WriteLine("(" + sideWhite + ")");
                    possiblePosition = piece.GetPiecePosition();
                    switch (sideWhite)
                    {
                        case 1:
                            if (!piece.IsMoved)
                            {
                                tmpRow = indexRow;
                                tmpCol = indexCol + 2;
                                if (board.GetPiece(new Vector2(tmpRow, tmpCol)) == null)
                                {
                                    possiblePosition.SetRow(tmpRow);
                                    possiblePosition.SetColumn(tmpCol);
                                    possibleMove.Add(new Position(possiblePosition.GetRow(), possiblePosition.GetColumn()));
                                    System.Console.WriteLine(piece.ID + "[" + possiblePosition.GetRow() + "," + possiblePosition.GetColumn() + "]");
                                }
                            }
                            break;

                        case 2:
                            tmpRow = indexRow;
                            tmpCol = indexCol + 1;
                            if (board.GetPiece(new Vector2(tmpRow, tmpCol)) == null)
                            {
                                possiblePosition.SetRow(tmpRow);
                                possiblePosition.SetColumn(tmpCol);
                                possibleMove.Add(new Position(possiblePosition.GetRow(), possiblePosition.GetColumn()));
                                System.Console.WriteLine(piece.ID + "[" + possiblePosition.GetRow() + "," + possiblePosition.GetColumn() + "]");
                            }
                            break;

                        case 3:
                            tmpRow = indexRow - 1;
                            tmpCol = indexCol + 1;
                            if (indexRow >= 0 && indexRow < boardHorizontalSize && indexCol >= 0 && indexCol < boardVerticalSize)
                            {
                                if (board.GetPiece(new Vector2(tmpRow, tmpCol)) != null)
                                {
                                    possiblePosition.SetRow(tmpRow);
                                    possiblePosition.SetColumn(tmpCol);
                                    possibleMove.Add(new Position(possiblePosition.GetRow(), possiblePosition.GetColumn()));
                                    System.Console.WriteLine(piece.ID + "[" + possiblePosition.GetRow() + "," + possiblePosition.GetColumn() + "]");
                                }
                            }
                            break;

                        case 4:
                            tmpRow = indexRow + 1;
                            tmpCol = indexCol + 1;
                            if (indexRow >= 0 && indexRow < boardHorizontalSize && indexCol >= 0 && indexCol < boardVerticalSize)
                            {
                                if (board.GetPiece(new Vector2(tmpRow, tmpCol)) != null)
                                {
                                    possiblePosition.SetRow(tmpRow);
                                    possiblePosition.SetColumn(tmpCol);
                                    possibleMove.Add(new Position(possiblePosition.GetRow(), possiblePosition.GetColumn()));
                                    System.Console.WriteLine(piece.ID + "[" + possiblePosition.GetRow() + "," + possiblePosition.GetColumn() + "]");
                                }
                            }
                            break;
                    }

                    sideWhite++;
                }
                System.Console.WriteLine("------------------------------");
                break;

            case Colours.Black:
                var sideBlack = 1;
                while (sideBlack < 4)
                {
                    System.Console.WriteLine("(" + sideBlack + ")");
                    possiblePosition = piece.GetPiecePosition();
                    switch (sideBlack)
                    {
                        case 1:
                            if (!piece.IsMoved)
                            {
                                tmpRow = indexRow;
                                tmpCol = indexCol - 2;
                                if (board.GetPiece(new Vector2(tmpRow, tmpCol)) == null)
                                {
                                    possiblePosition.SetRow(tmpRow);
                                    possiblePosition.SetColumn(tmpCol);
                                    possibleMove.Add(new Position(possiblePosition.GetRow(), possiblePosition.GetColumn()));
                                    System.Console.WriteLine(piece.ID + "[" + possiblePosition.GetRow() + "," + possiblePosition.GetColumn() + "]");
                                }
                            }
                            break;

                        case 2:
                            tmpRow = indexRow;
                            tmpCol = indexCol - 1;
                            if (board.GetPiece(new Vector2(tmpRow, tmpCol)) == null)
                            {
                                possiblePosition.SetRow(tmpRow);
                                possiblePosition.SetColumn(tmpCol);
                                possibleMove.Add(new Position(possiblePosition.GetRow(), possiblePosition.GetColumn()));
                                System.Console.WriteLine(piece.ID + "[" + possiblePosition.GetRow() + "," + possiblePosition.GetColumn() + "]");
                            }
                            break;

                        case 3:
                            tmpRow = indexRow - 1;
                            tmpCol = indexCol - 1;
                            if (indexRow >= 0 && indexRow < boardHorizontalSize && indexCol >= 0 && indexCol < boardVerticalSize)
                            {
                                if (board.GetPiece(new Vector2(tmpRow, tmpCol)) != null)
                                {
                                    possiblePosition.SetRow(tmpRow);
                                    possiblePosition.SetColumn(tmpCol);
                                    possibleMove.Add(new Position(possiblePosition.GetRow(), possiblePosition.GetColumn()));
                                    System.Console.WriteLine(piece.ID + "[" + possiblePosition.GetRow() + "," + possiblePosition.GetColumn() + "]");
                                }
                            }
                            break;

                        case 4:
                            tmpRow = indexRow + 1;
                            tmpCol = indexCol - 1;
                            if (indexRow >= 0 && indexRow < boardHorizontalSize && indexCol >= 0 && indexCol < boardVerticalSize)
                            {
                                if (board.GetPiece(new Vector2(tmpRow, tmpCol)) != null)
                                {
                                    possiblePosition.SetRow(tmpRow);
                                    possiblePosition.SetColumn(tmpCol);
                                    possibleMove.Add(new Position(possiblePosition.GetRow(), possiblePosition.GetColumn()));
                                    System.Console.WriteLine(piece.ID + "[" + possiblePosition.GetRow() + "," + possiblePosition.GetColumn() + "]");
                                }
                            }
                            break;
                    }

                    sideBlack++;
                }
                System.Console.WriteLine("------------------------------");
                break;
        }
        return possibleMove;
    }

    /// <summary>
    /// Gerakan yang mungkin dilakukan oleh bidak tipe Rook.
    /// </summary>
    ///	<param name="player">
    /// Player yang memiliki piece.
    /// <param name="piece">
    /// Bidak yang digerakkan.
    /// </param>
    /// <param name="board">
    /// Papan catur tempat bidak dimainkan.
    /// </param>
    /// <returns>
    /// Mengembalikan nilai berupa List<Position>.
    /// </returns>
    public List<Position> RookMove(IPlayer player, Piece piece, Board board)
    {
        possibleMove.Clear();

        MoveStraightHorizontalVertical(player, piece, board);

        return possibleMove;
    }

    /// <summary>
    /// Gerakan yang mungkin dilakukan oleh bidak tipe Knight.
    /// </summary>
    ///	<param name="player">
    /// Player yang memiliki piece.
    /// <param name="piece">
    /// Bidak yang digerakkan.
    /// </param>
    /// <param name="board">
    /// Papan catur tempat bidak dimainkan.
    /// </param>
    /// <returns>
    /// Mengembalikan nilai berupa List<Position>.
    /// </returns>
    public List<Position> KnightMove(IPlayer player, Piece piece, Board board)
    {
        possibleMove.Clear();
        var currentIndex = new Vector2(1, 1);
        var possiblePosition = piece.GetPiecePosition();
        var boardHorizontalSize = board.GetBoard().GetLength(0);
        var boardVerticalSize = board.GetBoard().GetLength(1);

        var indexRow = piece.GetPiecePosition().GetRow();
        var indexCol = piece.GetPiecePosition().GetColumn();
        var tmpRow = 0;
        var tmpCol = 0;

        int side = 0;

        System.Console.WriteLine("(0)" + piece.ID + "[" + indexRow + "," + indexCol + "]");
        System.Console.WriteLine("Search for possible move...");

        while (side < 8)
        {
            switch (side)
            {
                case 0:
                    tmpRow = 2;
                    tmpCol = 1;
                    break;
                case 1:
                    tmpRow = 1;
                    tmpCol = 2;
                    break;
                case 2:
                    tmpRow = -1;
                    tmpCol = 2;
                    break;
                case 3:
                    tmpRow = -2;
                    tmpCol = 1;
                    break;
                case 4:
                    tmpRow = -2;
                    tmpCol = -1;
                    break;
                case 5:
                    tmpRow = -1;
                    tmpCol = -2;
                    break;
                case 6:
                    tmpRow = 1;
                    tmpCol = -2;
                    break;
                case 7:
                    tmpRow = 2;
                    tmpCol = -1;
                    break;
            }
			
            int tmpIndexRow = indexRow + tmpRow;
            int tmpIndexCol = indexCol + tmpCol;

            if (tmpIndexRow >= 0 && tmpIndexRow < boardHorizontalSize && tmpIndexCol >= 0 && tmpIndexCol < boardVerticalSize)
            {
                possiblePosition.SetRow(tmpIndexRow);
                possiblePosition.SetColumn(tmpIndexCol);
                possibleMove.Add(new Position(possiblePosition.GetRow(), possiblePosition.GetColumn()));
                System.Console.WriteLine(piece.ID + "[" + possiblePosition.GetRow() + "," + possiblePosition.GetColumn() + "]");
            }

            side++;
        }
        return possibleMove;
    }

    /// <summary>
    /// Gerakan yang mungkin dilakukan oleh bidak tipe Bishop.
    /// </summary>
    ///	<param name="player">
    /// Player yang memiliki piece.
    /// <param name="piece">
    /// Bidak yang digerakkan.
    /// </param>
    /// <param name="board">
    /// Papan catur tempat bidak dimainkan.
    /// </param>
    /// <returns>
    /// Mengembalikan nilai berupa List<Position>.
    /// </returns>
    public List<Position> BishopMove(IPlayer player, Piece piece, Board board)
    {
        possibleMove.Clear();

        MoveStraightDiagonal(player, piece, board);

        return possibleMove;
    }

    /// <summary>
    /// Gerakan yang mungkin dilakukan oleh bidak tipe Queen.
    /// </summary>
    ///	<param name="player">
    /// Player yang memiliki piece.
    /// <param name="piece">
    /// Bidak yang digerakkan.
    /// </param>
    /// <param name="board">
    /// Papan catur tempat bidak dimainkan.
    /// </param>
    /// <returns>
    /// Mengembalikan nilai berupa List<Position>.
    /// </returns>
    public List<Position> QueenMoves(IPlayer player, Piece piece, Board board)
    {
        List<Position> possiblemoves = new List<Position>();
        possiblemoves.AddRange(RookMove(player, piece, board));
        possiblemoves.AddRange(BishopMove(player, piece, board));
        return possiblemoves;
    }

    /// <summary>
    /// Gerakan yang mungkin dilakukan oleh bidak tipe King.
    /// </summary>
    ///	<param name="player">
    /// Player yang memiliki piece.
    /// <param name="piece">
    /// Bidak yang digerakkan.
    /// </param>
    /// <param name="board">
    /// Papan catur tempat bidak dimainkan.
    /// </param>
    /// <returns>
    /// Mengembalikan nilai berupa List<Position>.
    /// </returns>
    public List<Position> KingMove(IPlayer player, Piece piece, Board board)
    {
        possibleMove.Clear();
        var currentIndex = new Vector2(1, 1);
        var possiblePosition = piece.GetPiecePosition();
        var boardHorizontalSize = board.GetBoard().GetLength(0);
        var boardVerticalSize = board.GetBoard().GetLength(1);

        var indexRow = piece.GetPiecePosition().GetRow();
        var indexCol = piece.GetPiecePosition().GetColumn();
        var tmpRow = (int)currentIndex.X;
        var tmpCol = (int)currentIndex.Y;

        int side = 0;

        while (side < 8)
        {
            currentIndex = side == 0 ? new Vector2(0, 1) :
                side == 1 ? new Vector2(-1, 1) :
                side == 2 ? new Vector2(0, -1) :
                side == 3 ? new Vector2(-1, -1) :
                side == 4 ? new Vector2(-1, 0) :
                side == 5 ? new Vector2(-1, 1) :
                side == 6 ? new Vector2(0, 1) :
                side == 7 ? new Vector2(1, 1) :
                Vector2.Zero;

            possiblePosition = piece.GetPiecePosition();
            indexRow += tmpRow;
            indexCol += tmpCol;

            if (indexRow >= 0 && indexRow < boardHorizontalSize && indexCol >= 0 && indexCol < boardVerticalSize)
            {
                possibleMove.Add(possiblePosition);
            }

            side++;
        }
        return possibleMove;
    }

    /// <summary>
    /// Mendapatkan rangkaian gerakan yang bisa dilakukan
    ///	bidak yang bergerak lurus secara horizontal dan
    ///	vertikal.
    /// </summary>
    ///	<param name="player">
    ///	Player yang memiliki piece
    ///	</param>
    /// <param name="piece">
    /// Bidak yang digerakkan.
    /// </param>
    /// <param name="board">
    /// Papan tempat bidak dimainkan.
    /// </param>
    /// <returns>
    /// Mengembalikan nilai berupa List<Vector2>.
    /// </returns>
    public List<Position> MoveStraightHorizontalVertical(IPlayer player, Piece piece, Board board)
    {
        possibleMove.Clear();
        var possibleToMove = true;
        var possiblePosition = piece.GetPiecePosition();
        var boardHorizontalSize = board.GetBoard().GetLength(0);
        var boardVerticalSize = board.GetBoard().GetLength(1);

        var indexRow = piece.GetPiecePosition().GetRow();
        var indexCol = piece.GetPiecePosition().GetColumn();
        var tmpRow = 0;
        var tmpCol = 0;

        int side = 0;

        while (side < 4)
        {
            possibleToMove = true;

            // index 0 = kanan, 1 = kiri, 2 = atas, 3 = bawah
            if (side == 0)
            {
                tmpRow = 1;
            }
            else if (side == 1)
            {
                tmpRow = -1;
            }
            else if (side == 2)
            {
                tmpCol = 1;
            }
            else if (side == 3)
            {
                tmpCol = -1;
            }

            while (possibleToMove)
            {
                possiblePosition = piece.GetPiecePosition();
                tmpRow += indexRow;
                tmpCol += indexCol;

                if (indexRow >= 0 && indexRow < boardHorizontalSize && indexCol >= 0 && indexCol < boardVerticalSize)
                {
                    possibleMove.Add(possiblePosition);

                    switch (side)
                    {
                        case 0:

                            tmpRow++;

                            break;
                        case 1:

                            tmpRow--;

                            break;
                        case 2:

                            tmpCol++;

                            break;
                        case 3:

                            tmpCol--;

                            break;
                    }
                }
                else
                {
                    possibleToMove = false;
                }
            }

            side++;
        }

        return null;
    }

    /// <summary>
    /// Mendapatkan rangkaian gerakan yang bisa dilakukan
    ///	bidak yang bergerak lurus secara diagonal.
    /// </summary>
    ///	<param name="player">
    ///	Player yang memiliki piece
    ///	</param>
    /// <param name="piece">
    /// Bidak yang digerakkan.
    /// </param>
    /// <param name="board">
    /// Papan tempat bidak dimainkan.
    /// </param>
    /// <returns>
    /// Mengembalikan nilai berupa List<Vector2>.
    /// </returns>
    public List<Position> MoveStraightDiagonal(IPlayer player, Piece piece, Board board)
    {
        var possibleToMove = true;
        var currentIndex = new Vector2(1, 1);
        var possiblePosition = piece.GetPiecePosition();
        var boardHorizontalSize = board.GetBoard().GetLength(0);
        var boardVerticalSize = board.GetBoard().GetLength(1);

        var indexRow = piece.GetPiecePosition().GetRow();
        var indexCol = piece.GetPiecePosition().GetColumn();
        var tmpRow = 0;
        var tmpCol = 0;

        int side = 0;

        while (side < 4)
        {
            possibleToMove = true;

            // index 0 = kanan atas, 1 = kanan bawah, 2 = kiri atas, 3 = kiri bawah
            if (side == 0)
            {
                tmpRow = 1;
                tmpCol = 1;
            }
            else if (side == 1)
            {
                tmpRow = 1;
                tmpCol = -1;
            }
            else if (side == 2)
            {
                tmpRow = -1;
                tmpCol = 1;
            }
            else if (side == 3)
            {
                tmpRow = -1;
                tmpCol = -1;
            }
            else
            {
                tmpRow = 0;
                tmpCol = 0;
            }

            while (possibleToMove)
            {

                if (indexRow >= 0 && indexRow < boardHorizontalSize && indexCol >= 0 && indexCol < boardVerticalSize)
                {
                    if (board.GetPiece(new Vector2(tmpRow, tmpCol)) != null)
                    {
                        possiblePosition.SetRow(tmpRow);
                        possiblePosition.SetColumn(tmpCol);
                        System.Console.WriteLine(piece.ID + "[" + possiblePosition.GetRow() + "," + possiblePosition.GetColumn() + "]");
                    }
                }
                else
                {
                    possibleToMove = false;
                }
            }

            side++;
        }

        return possibleMove;
    }

    #endregion

    #region IMoveSet

    public List<Position> GetPieceMoveSet(Player player, Piece piece, Board board)
    {
        switch (piece)
        {
            case Pawn:

                return PawnMoves(player, piece, board);

            case Knight:

                return KnightMove(player, piece, board);

            case Bishop:

                return BishopMove(player, piece, board);

            case Rook:

                return RookMove(player, piece, board);

            case Queen:

                return QueenMoves(player, piece, board);

            case King:

                return KingMove(player, piece, board);
        }

        return null;
    }

    #endregion //IMoveSet
}
