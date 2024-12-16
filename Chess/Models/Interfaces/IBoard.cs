using System.Numerics;

namespace Chess.Models.Interfaces;

/// <summary>
/// Interface untuk Board (struktur dasar papan catur)
/// </summary>
public interface IBoard
{
    /// <summary>
    /// Menyimpan bidak pada sel tertentu di papan.
    /// </summary>
    /// <param name="piece">Bidak yang akan disimpan.</param>
    /// <param name="position">Posisi pada papan.</param>
    void SetBoardCell(Piece piece, Vector2 position);

    /// <summary>
    /// Menghapus bidak dari sel tertentu di papan.
    /// </summary>
    /// <param name="position">Posisi pada papan.</param>
    void SetBoardCellNull(Vector2 position);

    /// <summary>
    /// Mendapatkan seluruh struktur papan.
    /// </summary>
    /// <returns>Array dua dimensi yang merepresentasikan papan.</returns>
    Piece[,] GetBoard();

    /// <summary>
    /// Mengecek apakah sel pada papan kosong.
    /// </summary>
    /// <param name="row">Baris pada papan.</param>
    /// <param name="column">Kolom pada papan.</param>
    /// <returns>True jika sel kosong, false jika tidak.</returns>
    bool IsEmptyCell(int row, int column);

    /// <summary>
    /// Menampilkan papan ke konsol (untuk debugging atau visualisasi sederhana).
    /// </summary>
    void PrintBoard();
}
