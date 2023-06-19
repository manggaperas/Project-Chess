using System;
using System.Collections.Generic;
using System.Linq;
namespace Chess;

public class GameManager
{
	private Board _board; 
	private IPlayer _currentplayer; //iplayer
	// private List<IPlayer> _players;
	private Dictionary<IPlayer, PieceSet> _playerpieces;
	private GameStatus _gameStatus;

	private void InitializeBoard()
	{
		for (int row = 0; row < 8; row++)
		{
			for (int column = 0; column < 8; column++)
			{
				SetPiece(null, new Position(row, column));
			}
		}
		// _playerpieces = new Dictionary<IPlayer, PieceSet>(); //buat contruct gamemanager
        // _playerpieces.Add(Player.Colour.ToString(), whitePieceSet);
        // // _playerpieces.Add(blackPlayer, blackPieceSet);
		// Player whitePlayer = _playerpieces.Keys.First(player => player.Colour == Colours.White);
		// Player blackPlayer = _playerpieces.Keys.First(player => player.Colour == Colours.Black);
		// PieceSet whitePieceSet = _playerpieces[whitePlayer];
		// PieceSet blackPieceSet = _playerpieces[blackPlayer];
		// AddPiecesToBoard(whitePieceSet.GetPieces(), whitePlayer);
		// AddPiecesToBoard(blackPieceSet.GetPieces(), blackPlayer);
	}
	public void SetPiece(Piece piece, Position position) //bedain namanya antara di board adan gamemanager
	{
		int row = Position.Row;
		int column = Position.Column;

		if (_board.IsValidPosition(Position.Row, Position.Column))
		{
			_board.SetPiece(piece, position);
		}
		else
		{
			throw new ArgumentOutOfRangeException("Invalid position.");
		}
	}
	private void AddPiecesToBoard(List<Piece> pieces)
	{
		foreach (Piece piece in pieces)
		{
			Position position = piece.Position;
			_board.SetPiece(piece, position);
		}
	}
	public List<Piece> GetPlayerPieces(Player currentPlayer)
	{
		if (_playerpieces.ContainsKey(currentPlayer))
		{
			PieceSet pieceSet = _playerpieces[currentPlayer];
			return pieceSet.GetPieces();
		}
		else
		{
			return new List<Piece>();
		}
	}
	public void GameController()
	{
		_players = new List<IPlayer>();
		_players.Add(new Player("Player 1", Colours.White.ToString()));
		_players.Add(new Player("Player 2", Colours.Black.ToString()));
		_currentplayer = (Player)_players[0];
		_playerpieces = new Dictionary<Player, PieceSet>();
		foreach (Player player in _players)
		{
			_playerpieces[player] = new PieceSet();
		}
		_board = new Board();
		StartGame();
	}
	public void StartGame()
	{
		InitializeBoard();
		SwitchPlayer();
	}
	public void SwitchPlayer()
	{
		if (_currentplayer == _players[0])
		{
			_currentplayer = (Player)_players[1];
		}
		else
		{
			_currentplayer = (Player)_players[0];
		}
	}
	public enum GameStatus
	{
		NotStarted,
		InProgress,
		Finished
	}
	public void EndGame()
	{
		Console.WriteLine("Game Over");
		Console.WriteLine("Congratulations! " + _currentplayer.GetName + " is the winner!");
		_gameStatus = GameStatus.Finished;
		Environment.Exit(0);
	}

	internal GameStatus GetGameStatus()
	{
		return _gameStatus;
	}

	internal Player GetCurrentPlayer()
	{
		return _currentplayer;
	}

	internal bool IsGameFinished()
	{
		if (_gameStatus == GameStatus.NotStarted || _gameStatus == GameStatus.Finished)
		{
			return true;
		}
		// else if (_gameStatus == GameStatus.InProgress)
		// {
		// 	Player opponent = (Player)GetCurrentPlayer(_currentplayer);
		// 	PieceSet opponentPieceSet = _playerpieces[opponent];
		// 	if (IsCheckmate())
		// 	{
		// 		return true;
		// 	}
		// }
		return false;
	}

    internal string GetCurrentPlayerName()
    {
        return _currentplayer.GetName();
    }
}
