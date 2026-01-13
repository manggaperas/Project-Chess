using System.Numerics;
using Chess.Models;
using Chess.Models.Pieces;
using Chess.Views;

namespace Chess.Controllers;

public class GameManager
{
	#region Variable
	
	private Board _board;
	private List<IPlayer> _players;
	private Dictionary<IPlayer, PieceSet> _playerPieceSets;
	private GameStatus _gameStatus;
	private IPlayer _currentPlayer;
	
	#endregion

	#region Constructor
	
	public GameManager()
	{
		_board = new Board();
		_playerPieceSets = new Dictionary<IPlayer, PieceSet>();
		_players = new List<IPlayer>();
		_gameStatus = GameStatus.NotStarted;
	}
	
	#endregion
	
	#region Public Interface
	
	public GameStatus GetGameStatus() => _gameStatus;
	public void PrintBoard() => _board.PrintBoard();
	
	#endregion
	
	#region Main Logic
	public void InitializePlayers()
	{
		// create player 1
		Player player1 = new Player();
		ConsoleDisplay.EnterName(player1);
		ConsoleDisplay.EnterColour(player1);
		_players.Add(player1);
		
		// create player 2
		Player player2 = new Player();
		ConsoleDisplay.EnterName(player2);
		player2.SetPlayerColours(player1.GetPlayerColours() == Colours.White ? Colours.Black : Colours.White);
		Console.WriteLine($"{player2.GetPlayerName()} will play as {player2.GetPlayerColours()}");
		_players.Add(player2);
		
		// setup piece sets for players
		foreach (IPlayer player in _players)
		{
			PieceSet playerPieceSet = new PieceSet();
			InitializePlayerPieces(playerPieceSet, player);
			_playerPieceSets.Add(player, playerPieceSet);
		}
	}
	
	public void InitializeBoard()
	{
		foreach (var kvp in _playerPieceSets)
		{
			foreach (Piece piece in kvp.Value.GetPieces())
			{
				Vector2 position = new Vector2(piece.CurrentPosition.GetRow(), piece.CurrentPosition.GetColumn());
				_board.SetBoardCell(piece, position);
			}
		}
	}
	
	public void InitializePlayerTurn()
	{
		_currentPlayer = _players.FirstOrDefault(player => player.GetPlayerColours() == Colours.White);
		_gameStatus = GameStatus.Active;
	}
	
	public void SwitchPlayer()
	{
		_currentPlayer = (_currentPlayer == _players[0]) ? _players[1] : _players[0];
	}
	
	public void PlayTurn()
	{
		bool turnComplete = false;
		while (!turnComplete)
		{
			Console.WriteLine($"\n=== {_currentPlayer.GetPlayerName()}'s Turn ({_currentPlayer.GetPlayerColours()}) ===");
			PrintBoard();
			
			// select piece
			string input = InputHelper.GetString("Enter Piece ID (e.g. P1) or 'EXIT': ");
			if (input.ToUpper() == "EXIT")
			{
				_gameStatus = GameStatus.Finished;
				return;
			}
			Piece selectedPiece = FindPieceById(input);
			
			// validation condition : must exist and belong to current player
			if (selectedPiece == null)
			{
				Console.WriteLine("Piece not found!");
				continue;
			}
			if (selectedPiece.Colour != _currentPlayer.GetPlayerColours())
			{
				Console.WriteLine("That is not your piece!");
				continue;
			}
			
			// get legal moves
			List<Position> legalMoves = selectedPiece.GetValidMoves(_board);

			if (legalMoves.Count == 0)
			{
				Console.WriteLine("This piece has no legal moves. Pick another.");
				continue;
			}
			
			// show option moves
			Console.WriteLine($"Selected {selectedPiece.ID}. Possible moves:");
			foreach (var move in legalMoves)
			{
				Console.WriteLine($"-> Row: {move.GetRow()}, Col: {move.GetColumn()}");
			}
			
			// selecet destination
			Console.Write("Enter target Row and Column (e.g. 3,4) or '0' to cancel: ");
			string targetInput = Console.ReadLine();
			if (targetInput == "0") continue; // back start looping again4

			if (TryParsePosition(targetInput, out int tRow, out int tCol))
			{
				// Check if this target is in the legalMoves list
				// We match by value (Row/Col), not object reference
				bool isValid = legalMoves.Any(m => m.GetRow() == tRow && m.GetColumn() == tCol);

				if (isValid)
				{
					ExecuteMove(selectedPiece, tRow, tCol);
					turnComplete = true; // Turn is done!
				}
				else
				{
					Console.WriteLine("Invalid move! That destination is not in the list.");
				}
			}
			else
			{
				Console.WriteLine("Invalid format. Use 'row,col' (e.g. 4,5)");
			}
			
		}
	}

	private void ExecuteMove(Piece piece, int newRow, int newCol)
	{
		// clear old spot on board
		Vector2 oldPosition = new Vector2(piece.CurrentPosition.GetRow(), piece.CurrentPosition.GetColumn());
		_board.SetBoardCell(piece, oldPosition);
		
		// handle capture
		Piece targetPiece = _board.GetPiece(newRow, newCol);
		if (targetPiece != null)
		{
			Console.WriteLine($"Captured {targetPiece.ID}!");
		}
		
		// update piece
		piece.MoveTo(new Position(newRow, newCol));
		
		// place on new spot on board
		Vector2 newPosition = new Vector2(newRow, newCol);
		_board.SetBoardCell(piece, newPosition);
		
		Console.WriteLine($"Moved {piece.ID} to {newPosition}.");
	}

	private Piece FindPieceById(string id)
	{
		// look current player pieces
		if (_playerPieceSets.TryGetValue(_currentPlayer, out PieceSet pieceset))
		{
			return pieceset.GetPiece(id);
		}
		return null;
	}

	private bool TryParsePosition(string input, out int row, out int col)
	{
		row = -1;
		col = -1;
		try
		{
			var parts = input.Split(',');
			if (parts.Length != 2) return false;
			row = int.Parse(parts[0].Trim());
			col = int.Parse(parts[1].Trim());
			return true;
		}
		catch
		{
			return false;
		}
	}
	
	private void InitializePlayerPieces(PieceSet playerPieceSet, IPlayer player)
	{
		int rowPawn;
		int rowRoyal;
		Colours col = player.GetPlayerColours();
    
		if (col == Colours.White)
		{
			rowPawn = 1;
			rowRoyal = 0;
		}
		else
		{
			rowPawn = 6;
			rowRoyal = 7;
		}
    
		// 1. Add Pawns (Value = 1)
		for (int i = 0; i < 8; i++)
		{
			playerPieceSet.AddPiece(new Pawn($"P{i+1}", new Position(rowPawn, i), col, 1));
		}

		// 2. Add Royals with their traditional point values
		playerPieceSet.AddPiece(new Knight("K1", new Position(rowRoyal, 1), col, 3));
		playerPieceSet.AddPiece(new Bishop("B1", new Position(rowRoyal, 2), col, 3));
		playerPieceSet.AddPiece(new King("KG", new Position(rowRoyal, 4), col, 0)); 
		playerPieceSet.AddPiece(new Bishop("B2", new Position(rowRoyal, 5), col, 3));
		playerPieceSet.AddPiece(new Knight("K2", new Position(rowRoyal, 6), col, 3));

		// --- 2. Pieces requiring 3 parameters (ID, Position, Colour) ---
		// Note: Removed the 'Value' at the end to satisfy the error
		playerPieceSet.AddPiece(new Rook("R1", new Position(rowRoyal, 0), col));
		playerPieceSet.AddPiece(new Queen("Q1", new Position(rowRoyal, 3), col));
		playerPieceSet.AddPiece(new Rook("R2", new Position(rowRoyal, 7), col));
	}

	private IPlayer GetCurrentPlayer() => _players.FirstOrDefault(x => x.IsPlaying);

	private bool IsGameFinished()
	{
		return _gameStatus == GameStatus.Finished;
	}
	
	public void EndGame()
	{
		Console.WriteLine("Game Over");
	}
	
	#endregion
}
