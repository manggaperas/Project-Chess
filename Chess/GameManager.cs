using System.Diagnostics;

namespace Chess;

public class GameManager
{
	private Board _board;
	private List<IPlayer> _currentPlayer;
	private Dictionary<IPlayer, PieceSet> _playerPieceSets;
	private GameStatus _gameStatus;
	private List<Piece> _piecespack;
	private Move _move;
	public GameManager()
	{
		_board = new Board();
		_playerPieceSets = new Dictionary<IPlayer, PieceSet>();
		_currentPlayer = new List<IPlayer>();
		_gameStatus = GameStatus.NotStarted;
		_piecespack = new List<Piece>();
	}
	public void InitializePlayers()
	{
		IPlayer Player1 = new Player();
		this.Player1(Player1);
		IPlayer Player2 = new Player();
		this.Player2(Player2);
		_currentPlayer.Add(Player1);
		_currentPlayer.Add(Player2);
	}
	internal void Player1(IPlayer Player1)
	{
		ConsoleDisplay.EnterName((Player)Player1);
		ConsoleDisplay.EnterColour((Player)Player1);
		PieceSet Player1PieceSet = new PieceSet();
		InitializePlayerPieces(Player1PieceSet);
		_playerPieceSets.Add(Player1, Player1PieceSet);
	}
	internal void Player2(IPlayer Player2)
	{
		ConsoleDisplay.EnterName((Player)Player2);
		ConsoleDisplay.EnterColour((Player)Player2);
		PieceSet Player2Pieceset = new PieceSet();
		InitializePlayerPieces(Player2Pieceset);
		_playerPieceSets.Add(Player2, Player2Pieceset);
	}
	private void InitializePlayerPieces(PieceSet pieceSet)
	{
		// Pawn
		for (int i = 0; i < 8; i++)
		{
			Position pawnposition = new Position(i, 1);
			if (ValidatePiecePosition(pawnposition.GetRow(), pawnposition.GetColumn()) != true)
			{
				throw new Exception("Ya Gabisa lah bro, masa 1 kotak buat berdua!");
			}
			Pawn pawn = new Pawn(new Position(i, 1), true, 1);
			pieceSet.AddPiece(pawn);
		}
		// Rook
		Rook rook1 = new Rook(new Position(0, 0), true, 5);
		Rook rook2 = new Rook(new Position(7, 0), true, 5);
		pieceSet.AddPiece(rook1);
		pieceSet.AddPiece(rook2);
		// Knight
		Knight knight1 = new Knight(new Position(1, 0), true, 3);
		Knight knight2 = new Knight(new Position(6, 0), true, 3);
		pieceSet.AddPiece(knight1);
		pieceSet.AddPiece(knight2);
		// Bishop
		Bishop bishop1 = new Bishop(new Position(2, 0), true, 3);
		Bishop bishop2 = new Bishop(new Position(5, 0), true, 3);
		pieceSet.AddPiece(bishop1);
		pieceSet.AddPiece(bishop2);
		// Queen
		Queen queen = new Queen(new Position(3, 0), true, 9);
		pieceSet.AddPiece(queen);
		// King
		King king = new King(new Position(4, 0), true, 10);
		pieceSet.AddPiece(king);
	}
	private void ValidatePiecePosition(int row, int column)
	{

	}
	public void InitializeBoard()
	{
		foreach (var kvp in _playerPieceSets)
		{
			foreach (Piece piece in kvp.Value.GetPieces())
			{
				Position position = piece.GetPiecePosition();
				_board.SetBoardCell(piece, new System.Numerics.Vector2(position.GetRow(), position.GetColumn()));
			}
		}
	}
	public void PlayerTurn()
	{
		while (!IsGameFinished())
		{
			IPlayer currentPlayer = GetCurrentPlayer();
			Debug.Assert(currentPlayer != null, "The current Player was not set!");
			Console.WriteLine($"\n\t{currentPlayer.GetPlayerName()}, it's your turn.");
			var move = new Move();
			while (!move.IsValidMove())
			{
				ConsoleDisplay.EnterMove(currentPlayer, _board, out move);
			}
			int rowbefore = move.From.GetRow();
			int colbefore = move.From.GetColumn();
			int rowafter = move.To.GetRow();
			int colafter = move.To.GetColumn();
			if (_board.GetBoardValue(rowafter, colafter) != 0)
			{
				Piece capturedPiece = _board.GetBoardPosition(rowafter, colafter).GetPiece();
				_playerPieceSets[capturedPiece.GetOwner()].RemovePiece(capturedPiece);
			}
			_board.SetBoardCell(rowafter, colafter, _board.GetBoardValue(rowbefore, colbefore));
			_board.SetBoardCell(rowbefore, colbefore, 0);
			IPlayer nextPlayer = GetNextPlayer(currentPlayer);
			SwitchPlayer(nextPlayer);
		}
		EndGame();
	}
	public void SwitchPlayer()
	{
		if (_currentPlayer.Contains(Player1())) // checking if Player1() is present in the _currentplayer list
		{
			_currentPlayer = new List<IPlayer>() { Player1(new Player()) }; // create a list containing the second player
			Console.Write($"\n\t{Player1(new Player()).GetName()}"); // print the name of the second player
																	 // _currentplayer = new List<IPlayer>() { Player1((Player)_currentplayer) }; // create a list containing the second player
																	 // Console.Write($"\n\t{Player1((Player)_currentplayer).GetName()}"); // print the name of the second player
		}
		else // assuming there are only 2 players in the game
		{
			_currentPlayer = new List<IPlayer>() { Player2((Player)_currentPlayer) }; // create a list containing the first player
			Console.Write($"\n\t{Player2((Player)_currentPlayer).GetName()}"); // print the name of the first player
		}
	}
	public void EndGame()
	{
		Console.WriteLine("Game Over");
		_gameStatus = GameStatus.Finished;
		Environment.Exit(0);
	}
	internal GameStatus GetGameStatus()
	{
		return _gameStatus;
	}
	internal Player GetCurrentPlayer()
	{
		return _currentPlayer;
	}
	internal bool IsGameFinished()
	{
		if (_gameStatus == GameStatus.NotStarted || _gameStatus == GameStatus.Finished)
		{
			return true;
		}
		return false;
	}
	public string GetCurrentPlayerName()
	{
		return _currentPlayer.GetPlayerName();
	}
}
