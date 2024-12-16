using System.Numerics;

namespace Chess.Models.Interfaces;

/// <summary>
/// Interface untuk logika pergerakan bidak pada papan catur.
/// </summary>
public interface IMove
{
    /// <summary>
    /// Memvalidasi apakah posisi target valid pada papan catur.
    /// </summary>
    /// <param name="position">Posisi yang akan divalidasi.</param>
    /// <returns>True jika posisi valid, false jika tidak.</returns>
    bool IsValidPosition(Vector2 position);

    /// <summary>
    /// Mengecek apakah bidak dapat bergerak ke posisi target pada papan.
    /// </summary>
    /// <param name="piece">Bidak yang akan bergerak.</param>
    /// <param name="targetPosition">Posisi target untuk pergerakan.</param>
    /// <param name="board">Papan catur yang sedang digunakan.</param>
    /// <returns>True jika pergerakan valid, false jika tidak.</returns>
    bool CanMove(Piece piece, Vector2 targetPosition, IBoard board);
}