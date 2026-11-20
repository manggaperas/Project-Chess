using Microsoft.EntityFrameworkCore;
using Chess.Models;

namespace Chess.Data;

public class ChessContext : DbContext
{
    // This list represents your table in the database
    public DbSet<MatchHistory> MatchHistories { get; set; }

    // This configures the connection to the SQLite file
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // This creates a file named "chess.db" in your debug folder
        optionsBuilder.UseSqlite("Data Source=chess.db");
    }
}