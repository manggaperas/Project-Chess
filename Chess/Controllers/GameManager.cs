using System.Numerics;

namespace Chess;

public class GameManager
{
	private Board _board;
	private List<IPlayer> _currentPlayer;
	private Dictionary<IPlayer, PieceSet> _playerPieceSets;
	private GameStatus _gameStatus;
	private List<Piece> _piecespack;
	private Move _move;
	private MoveSet _moveSet = new MoveSet();

	#region Variable

	#endregion

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
		this.Player(Player1);
		IPlayer Player2 = new Player();
		this.Player(Player2);
		_currentPlayer.Add(Player1);
		_currentPlayer.Add(Player2);
	}
	
	internal void Player(IPlayer player)
	{
		ConsoleDisplay.EnterName((Player)player);
		ConsoleDisplay.EnterColour((Player)player);
		PieceSet PlayerPieceSet = new PieceSet();
		InitializePlayerPieces(PlayerPieceSet, player);
		_playerPieceSets.Add(player, PlayerPieceSet);
	}

	private void InitializePlayerPieces(PieceSet pieceSet, IPlayer player)
	{
		var pawnSide = player.GetPlayerColours() == Colours.White ? 1 : 6;
		// Pawn
		for (int i = 0; i < 8; i++)
		{
			Position pawnposition = new Position(i, 1);

			Pawn pawn = new Pawn($"Pawn{i}", new Position(i, pawnSide), true, 1);
			pieceSet.AddPiece(pawn);
		}

		var side = player.GetPlayerColours() == Colours.White ? 0 : 7;
		// Rook
		Rook rook1 = new Rook($"Rook{1}", new Position(0, side), true, 5);
		Rook rook2 = new Rook($"Rook{2}", new Position(7, side), true, 5);
		pieceSet.AddPiece(rook1);
		pieceSet.AddPiece(rook2);
		// Knight
		Knight knight1 = new Knight($"Knight{1}", new Position(1, side), true, 3);
		Knight knight2 = new Knight($"Knight{2}", new Position(6, side), true, 3);
		pieceSet.AddPiece(knight1);
		pieceSet.AddPiece(knight2);
		// Bishop
		Bishop bishop1 = new Bishop($"Bishop{1}", new Position(2, side), true, 3);
		Bishop bishop2 = new Bishop($"Bishop{2}", new Position(5, side), true, 3);
		pieceSet.AddPiece(bishop1);
		pieceSet.AddPiece(bishop2);
		// Queen
		Queen queen = new Queen("Queen", new Position(3, side), true, 9);
		pieceSet.AddPiece(queen);
		// King
		King king = new King("King", new Position(4, side), true, 10);
		pieceSet.AddPiece(king);
	}

	public void InitializeBoard()
	{
		foreach (var kvp in _playerPieceSets)
		{
			foreach (Piece piece in kvp.Value.GetPieces())
			{
				Position position = piece.GetPiecePosition();
				_board.SetBoardCell(piece, new Vector2(position.GetRow(), position.GetColumn()));
			}
		}
	}
	
	public void InitializePlayerTurn()
	{
		var player = _currentPlayer.FirstOrDefault(x => x.GetPlayerColours() == Colours.White);
		player.IsPlaying = true;
	}
	
	public void SwitchPlayer()
	{
		foreach (var player in _currentPlayer)
		{
			if (player.IsPlaying)
			{
				player.IsPlaying = false;
			}
			else
			{
				player.IsPlaying = true;
			}
		}
	}
	
	public void EndGame()
	{
		Console.WriteLine("Game Over");
		_gameStatus = GameStatus.Finished;
		Environment.Exit(0);
	}
	
	public GameStatus GetGameStatus()
	{
		return _gameStatus;
	}

	private IPlayer GetCurrentPlayer() => _currentPlayer.FirstOrDefault(x => x.IsPlaying);

	private bool IsGameFinished()
	{
		if (_gameStatus == GameStatus.NotStarted || _gameStatus == GameStatus.Finished)
		{
			return true;
		}
		return false;
	}

	public string GetCurrentPlayerName() => _currentPlayer.FirstOrDefault(x => x.IsPlaying).GetPlayerName();

	public void PrintBoard()
	{
		_board.PrintBoard();
	}

	public void SelectPiece(string idPiece)
	{
		var pieceSet = _playerPieceSets.FirstOrDefault(x => x.Key == GetCurrentPlayer()).Value;

		Console.WriteLine(pieceSet.GetPiece(idPiece).ID + " dipilih");
		
		var piecebefore = pieceSet.GetPiece(idPiece);
		var _positionbefore = new Vector2(piecebefore.GetPiecePosition().GetRow(), piecebefore.GetPiecePosition().GetColumn());

		List<Position> moveSet = _moveSet.GetPieceMoveSet((Player)GetCurrentPlayer(), pieceSet.GetPiece(idPiece), _board);
		for (int i=0; i < moveSet.Count(); i++)
		{
			Console.WriteLine($"can move row {moveSet[i].GetRow()} column {moveSet[i].GetColumn()}");
		}
		
		if (moveSet.Count() == 0)
		{
			PrintBoard();
			System.Console.WriteLine("Silahkan pilih piece yang ingin digerakkan: ");
			var pieceSelected = Console.ReadLine();
			SelectPiece(pieceSelected);
		}
		
		System.Console.WriteLine("Masukkan posisi [row, column] yang ingin dituju (ketik 0 untuk membatalkan): ");
		var pos = new Vector2();
		var postionSelected = Convert.ToString(Console.ReadLine());
		string[] input = postionSelected.Split(",");
		if (postionSelected.Contains(","))
		{
			int row = int.Parse(input[0]);
			int column = int.Parse(input[1]);
			pos = new Vector2(row, column);
		}
		if (postionSelected == "0")
		{
			PrintBoard();
			System.Console.WriteLine("Silahkan Pilih piece yang ingin digerakkan: ");
			var pieceSelected = Console.ReadLine();
			SelectPiece(pieceSelected);
		}
		else
		{
			System.Console.WriteLine("Position Before: " + _positionbefore);
			System.Console.WriteLine("Position After: " + pos);
			_board.SetBoardCellNull(_positionbefore);
			_board.SetBoardCell(pieceSet.GetPiece(idPiece), pos);
		}
	}
}
