using System;
using System.ComponentModel.DataAnnotations;

namespace Chess.Models;

public class MatchHistory
{
    [Key]
    public int Id { get; set; } // Unique ID for the database
    
    public string WhitePlayerName { get; set; }
    public string BlackPlayerName { get; set; }
    public string WinnerName { get; set; } // "Draw" or Player Name
    public DateTime DatePlayed { get; set; }
    
    // Optional: You could save the moves as a long string later
    // public string MoveLog { get; set; } 
}