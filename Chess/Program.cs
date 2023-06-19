using Chess;

public class Program
{
    private GameManager _gamemanager;
    public static void Main(string[] args)
    {
        GameManager gamemanager = new GameManager();
        gamemanager.GameController();
        gamemanager.StartGame();

        while (gamemanager.GetGameStatus() != GameManager.GameStatus.Finished)
        {
            Console.WriteLine("Saat ini giliran: " + gamemanager.GetCurrentPlayerName()); //ini harusnya nama

            foreach (Piece piece in gamemanager.GetPlayerPieces((Player)gamemanager.GetCurrentPlayer()))
            {
                Console.WriteLine(piece.Name); // object
            }

            Console.WriteLine("Pilih bidak yang akan dipindahkan: ");
            string selectedPieceName = Console.ReadLine();

            Piece selectedPiece = null;
            foreach (Piece piece in gamemanager.GetPlayerPieces((Player)gamemanager.GetCurrentPlayer()))
            {
                if (piece.Name == selectedPieceName)
                {
                    selectedPiece = piece;
                    break;
                }
            }

            if (selectedPiece != null)
            {
                if (gamemanager.IsGameFinished())
                {
                    gamemanager.EndGame();
                }
                else
                {
                    gamemanager.SwitchPlayer();
                }
            }
            else
            {
                Console.WriteLine("Bidak yang dipilih tidak valid. Silakan coba lagi.");
            }
        }
    }
}