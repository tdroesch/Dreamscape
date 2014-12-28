using UnityEngine;
using System.Collections;
using FSM;

class GameAttrManager
{
	int currentPlayer;
	int nextPlayer;

	/// <summary>
	/// Gets or sets the current player.
	/// </summary>
	/// <value>The current player.</value>
	public int CurrentPlayer {
		get{ return currentPlayer;}
		set{ currentPlayer = value;}
	}

	/// <summary>
	/// Gets or sets the next player.
	/// </summary>
	/// <value>The next player.</value>
	public int NextPlayer {
		get{ return nextPlayer;}
		set{ nextPlayer = value;}
	}


	/// <summary>
	/// Initalize the GameAttrManager values.
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

