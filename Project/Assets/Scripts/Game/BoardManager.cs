using UnityEngine;
using System.Collections;
using FSM;

/// <summary>
/// Board manager.
/// Stores information that will be shared between both players
/// and current and next player data.
/// 
/// Properties: CurrentPlayer, NextPlayer
/// Accessors: int PlayerHealth(int), int PlayerResource(int), int PlayerDeckSize(int)
/// 	int PlayerHandSize(int), Field PlayerField(int), Subconscious PlayerDiscard(int)
/// </summary>
class BoardManager {
	//Player Turn data
	int currentPlayer;
	int nextPlayer;

	/// <summary>
	/// Gets the current player.
	/// </summary>
	/// <value>The current player.</value>
	public int CurrentPlayer {
		get{ return currentPlayer;}
	}

	/// <summary>
	/// Gets or sets the next player.
	/// </summary>
	/// <value>The next player.</value>
	public int NextPlayer {
		get{ return nextPlayer;}
		set{ nextPlayer = value;}
	}


	//Board Data
	Player player1;
	Player player2;

	/// <summary>
	/// Gets the Players current health.
	/// </summary>
	/// <returns>The health.</returns>
	/// <param name="player">Player 1 or 2.</param>
	public int GetPlayerHealth(int player) {
		if (player == 1) {
			return player1.Will;
		} else if (player == 2) {
			return player2.Will;
		} else {
			return int.MinValue;
		}
	}

	/// <summary>
	/// Gets the Players current resources.
	/// </summary>
	/// <returns>The resource.</returns>
	/// <param name="player">Player 1 or 2.</param>
	public int GetPlayerResource(int player) {
		if (player == 1) {
			return player1.Imagination;
		} else if (player == 2) {
			return player2.Imagination;
		} else {
			return int.MinValue;
		}
	}

	/// <summary>
	/// Gets the size of the player deck.
	/// </summary>
	/// <returns>The player deck size.</returns>
	/// <param name="player">Player 1 or 2.</param>
	public int GetPlayerDeckSize(int player){
		if (player == 1) {
			return player1.DeckSize;
		} else if (player == 2) {
			return player2.DeckSize;
		} else {
			return int.MinValue;
		}
	}

	/// <summary>
	/// Gets the size of the player hand.
	/// </summary>
	/// <returns>The player hand size.</returns>
	/// <param name="player">Player 1 or 2.</param>
	public int GetPlayerHandSize(int player){
		if (player == 1) {
			return player1.HandSize;
		} else if (player == 2) {
			return player2.HandSize;
		} else {
			return int.MinValue;
		}
	}

	/// <summary>
	/// Gets the player field.
	/// </summary>
	/// <returns>The player field.</returns>
	/// <param name="player">Player 1 or 2.</param>
	public Field GetPlayerField(int player){
		if (player == 1) {
			return player1.GetField;
		} else if (player == 2) {
			return player2.GetField;
		} else {
			return null;
		}
	}

	/// <summary>
	/// Gets the player discard.
	/// </summary>
	/// <returns>The player discard.</returns>
	/// <param name="player">Player 1 or 2.</param>
	public Subconscious GetPlayerDiscard(int player){
		if (player == 1) {
			return player1.Discard;
		} else if (player == 2) {
			return player2.Discard;
		} else {
			return null;
		}
	}

	/// <summary>
	/// Initalize the BoardManager values.
	/// </summary>
	/// <param name="firstPlayer">The Player who plays first.</param>
	public void init (int firstPlayer)
	{
		nextPlayer = firstPlayer;
	}

	/// <summary>
	/// Alternates player turns.
	/// Adds one to the currentPlayer then sets the currentPlayer to the remaider of currentPlayer/2
	/// </summary>
	public void GoNextPlayer ()
	{
		currentPlayer = nextPlayer;
		nextPlayer = (currentPlayer + 1) % 2;
	}
}

