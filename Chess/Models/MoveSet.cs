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
        Position post = new Position(piece.GetPiecePosition().GetRow(), piece.GetPiecePosition().GetColumn());
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
                    switch (sideWhite)
                    {
                        case 1:
                            if (!piece.IsMoved)
                            {
                                tmpRow = indexRow;
                                tmpCol = indexCol + 2;
                                if (board.GetPiece(new Vector2(tmpRow, tmpCol)) == null)
                                {
                                    post.SetRow(tmpRow);
                                    post.SetColumn(tmpCol);
                                    possibleMove.Add(new Position(post.GetRow(), post.GetColumn()));
                                    System.Console.WriteLine(piece.ID + "[" + post.GetRow() + "," + post.GetColumn() + "]");
                                }
                            }
                            break;

                        case 2:
                            tmpRow = indexRow;
                            tmpCol = indexCol + 1;
                            if (board.GetPiece(new Vector2(tmpRow, tmpCol)) == null)
                            {
                                post.SetRow(tmpRow);
                                post.SetColumn(tmpCol);
                                possibleMove.Add(new Position(post.GetRow(), post.GetColumn()));
                                System.Console.WriteLine(piece.ID + "[" + post.GetRow() + "," + post.GetColumn() + "]");
                            }
                            break;

                        case 3:
                            tmpRow = indexRow - 1;
                            tmpCol = indexCol + 1;
                            if (indexRow >= 0 && indexRow < boardHorizontalSize && indexCol >= 0 && indexCol < boardVerticalSize)
                            {
                                if (board.GetPiece(new Vector2(tmpRow, tmpCol)) != null)
                                {
                                    post.SetRow(tmpRow);
                                    post.SetColumn(tmpCol);
                                    possibleMove.Add(new Position(post.GetRow(), post.GetColumn()));
                                    System.Console.WriteLine(piece.ID + "[" + post.GetRow() + "," + post.GetColumn() + "]");
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
                                    post.SetRow(tmpRow);
                                    post.SetColumn(tmpCol);
                                    possibleMove.Add(new Position(post.GetRow(), post.GetColumn()));
                                    System.Console.WriteLine(piece.ID + "[" + post.GetRow() + "," + post.GetColumn() + "]");
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
                    switch (sideBlack)
                    {
                        case 1:
                            if (!piece.IsMoved)
                            {
                                tmpRow = indexRow;
                                tmpCol = indexCol - 2;
                                if (board.GetPiece(new Vector2(tmpRow, tmpCol)) == null)
                                {
                                    post.SetRow(tmpRow);
                                    post.SetColumn(tmpCol);
                                    possibleMove.Add(new Position(post.GetRow(), post.GetColumn()));
                                    System.Console.WriteLine(piece.ID + "[" + post.GetRow() + "," + post.GetColumn() + "]");
                                }
                            }
                            break;

                        case 2:
                            tmpRow = indexRow;
                            tmpCol = indexCol - 1;
                            if (board.GetPiece(new Vector2(tmpRow, tmpCol)) == null)
                            {
                                post.SetRow(tmpRow);
                                post.SetColumn(tmpCol);
                                possibleMove.Add(new Position(post.GetRow(), post.GetColumn()));
                                System.Console.WriteLine(piece.ID + "[" + post.GetRow() + "," + post.GetColumn() + "]");
                            }
                            break;

                        case 3:
                            tmpRow = indexRow - 1;
                            tmpCol = indexCol - 1;
                            if (indexRow >= 0 && indexRow < boardHorizontalSize && indexCol >= 0 && indexCol < boardVerticalSize)
                            {
                                if (board.GetPiece(new Vector2(tmpRow, tmpCol)) != null)
                                {
                                    post.SetRow(tmpRow);
                                    post.SetColumn(tmpCol);
                                    possibleMove.Add(new Position(post.GetRow(), post.GetColumn()));
                                    System.Console.WriteLine(piece.ID + "[" + post.GetRow() + "," + post.GetColumn() + "]");
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
                                    post.SetRow(tmpRow);
                                    post.SetColumn(tmpCol);
                                    possibleMove.Add(new Position(post.GetRow(), post.GetColumn()));
                                    System.Console.WriteLine(piece.ID + "[" + post.GetRow() + "," + post.GetColumn() + "]");
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
        Position post = new Position(piece.GetPiecePosition().GetRow(), piece.GetPiecePosition().GetColumn());
        // var possiblePosition = piece.GetPiecePosition();
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
                default:
                    tmpRow = 0;
                    tmpCol = 0;
                    break;
            }

            int tmpIndexRow = indexRow + tmpRow;
            int tmpIndexCol = indexCol + tmpCol;

            if (tmpIndexRow >= 0 && tmpIndexRow < boardHorizontalSize && tmpIndexCol >= 0 && tmpIndexCol < boardVerticalSize)
            {
                if (board.GetPiece(new Vector2(tmpIndexRow, tmpIndexCol)) == null)
                {
                    post.SetRow(tmpIndexRow);
                    post.SetColumn(tmpIndexCol);
                    possibleMove.Add(new Position(post.GetRow(), post.GetColumn()));
                    System.Console.WriteLine(piece.ID + "[" + post.GetRow() + "," + post.GetColumn() + "]");
                }
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
        possibleMove.Clear();
        MoveStraightHorizontalVertical(player, piece, board);
        MoveStraightDiagonal(player, piece, board);
        return possibleMove;
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
        Position post = new Position(piece.GetPiecePosition().GetRow(), piece.GetPiecePosition().GetColumn());
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
                    tmpRow = 0;
                    tmpCol = 1;
                    break;
                case 1:
                    tmpRow = -1;
                    tmpCol = 1;
                    break;
                case 2:
                    tmpRow = 0;
                    tmpCol = -1;
                    break;
                case 3:
                    tmpRow = -1;
                    tmpCol = -1;
                    break;
                case 4:
                    tmpRow = -1;
                    tmpCol = 0;
                    break;
                case 5:
                    tmpRow = -1;
                    tmpCol = 1;
                    break;
                case 6:
                    tmpRow = 0;
                    tmpCol = 1;
                    break;
                case 7:
                    tmpRow = 1;
                    tmpCol = 1;
                    break;
                default:
                    tmpRow = 0;
                    tmpCol = 0;
                    break;
            }


            int tmpIndexRow = indexRow + tmpRow;
            int tmpIndexCol = indexCol + tmpCol;

            if (tmpIndexRow >= 0 && tmpIndexRow < boardHorizontalSize && tmpIndexCol >= 0 && tmpIndexCol < boardVerticalSize)
            {
                if (board.GetPiece(new Vector2(tmpIndexRow, tmpIndexCol)) == null)
                {
                    post.SetRow(tmpIndexRow);
                    post.SetColumn(tmpIndexCol);
                    possibleMove.Add(new Position(post.GetRow(), post.GetColumn()));
                    System.Console.WriteLine(piece.ID + "[" + post.GetRow() + "," + post.GetColumn() + "]");
                }
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
        Position post = new Position(piece.GetPiecePosition().GetRow(), piece.GetPiecePosition().GetColumn());
        var boardHorizontalSize = board.GetBoard().GetLength(0);
        var boardVerticalSize = board.GetBoard().GetLength(1);

        var indexRow = piece.GetPiecePosition().GetRow();
        var indexCol = piece.GetPiecePosition().GetColumn();
        var tmpRow = 0;
        var tmpCol = 0;

        int side = 0;

        System.Console.WriteLine("(0)" + piece.ID + "[" + indexRow + "," + indexCol + "]");
        System.Console.WriteLine("Search for possible move...");

        while (side < 4)
        {
            // index 0 = kanan, 1 = kiri, 2 = atas, 3 = bawah
            switch (side)
            {
                case 0:
                    tmpRow = 0;
                    tmpCol = 1;
                    break;
                case 1:
                    tmpRow = 0;
                    tmpCol = -1;
                    break;
                case 2:
                    tmpRow = 1;
                    tmpCol = 0;
                    break;
                case 3:
                    tmpRow = -1;
                    tmpCol = 0;
                    break;
                default:
                    tmpRow = 0;
                    tmpCol = 0;
                    break;
            }

            int tmpIndexRow = indexRow + tmpRow;
            int tmpIndexCol = indexCol + tmpCol;

            if (tmpIndexRow >= 0 && tmpIndexRow < boardHorizontalSize && tmpIndexCol >= 0 && tmpIndexCol < boardVerticalSize)
            {
                if (board.GetPiece(new Vector2(tmpIndexRow, tmpIndexCol)) == null)
                {
                    post.SetRow(tmpIndexRow);
                    post.SetColumn(tmpIndexCol);
                    possibleMove.Add(new Position(post.GetRow(), post.GetColumn()));
                    System.Console.WriteLine(piece.ID + "[" + post.GetRow() + "," + post.GetColumn() + "]");
                }
            }

            side++;
        }

        return possibleMove;
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
        possibleMove.Clear();
        Position post = new Position(piece.GetPiecePosition().GetRow(), piece.GetPiecePosition().GetColumn());
        var boardHorizontalSize = board.GetBoard().GetLength(0);
        var boardVerticalSize = board.GetBoard().GetLength(1);

        var indexRow = piece.GetPiecePosition().GetRow();
        var indexCol = piece.GetPiecePosition().GetColumn();
        var tmpRow = 0;
        var tmpCol = 0;

        int side = 0;

        System.Console.WriteLine("(0)" + piece.ID + "[" + indexRow + "," + indexCol + "]");
        System.Console.WriteLine("Search for possible move...");

        while (side < 4)
        {
            // index 0 = kanan atas, 1 = kanan bawah, 2 = kiri atas, 3 = kiri bawah
            switch (side)
            {
                case 0:
                    tmpRow = 1;
                    tmpCol = 1;
                    break;
                case 1:
                    tmpRow = 1;
                    tmpCol = -1;
                    break;
                case 2:
                    tmpRow = -1;
                    tmpCol = 1;
                    break;
                case 3:
                    tmpRow = -1;
                    tmpCol = -1;
                    break;
                default:
                    tmpRow = 0;
                    tmpCol = 0;
                    break;
            }

            int tmpIndexRow = indexRow + tmpRow;
            int tmpIndexCol = indexCol + tmpCol;

            if (tmpIndexRow >= 0 && tmpIndexRow < boardHorizontalSize && tmpIndexCol >= 0 && tmpIndexCol < boardVerticalSize)
            {
                if (board.GetPiece(new Vector2(tmpIndexRow, tmpIndexCol)) == null)
                {
                    post.SetRow(tmpIndexRow);
                    post.SetColumn(tmpIndexCol);
                    possibleMove.Add(new Position(post.GetRow(), post.GetColumn()));
                    System.Console.WriteLine(piece.ID + "[" + post.GetRow() + "," + post.GetColumn() + "]");
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
