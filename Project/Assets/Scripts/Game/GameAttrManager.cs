using UnityEngine;
using System.Collections;
using FSM;

class GameAttrManager
{
	int currentPlayer;
	int phaseTurns;
	int turnsPerPhase;

	public int CurrentPlayer{
		get{return currentPlayer;}
		set{currentPlayer = value;}
	}

	public int PhaseTurns{
		get{return phaseTurns;}
		set{phaseTurns = value;}
	}

	/// <summary>
	/// Initalize the GameAttrManager values.
	/// </summary>
	/// <param name="firstPlayer">The Player who plays first.</param>
	/// <param name="turnsPerPhase">How many turns in each phase of the game.</param>
	public void init (int firstPlayer, int turnsPerPhase)
	{
		currentPlayer = firstPlayer;
		this.turnsPerPhase = turnsPerPhase;
		phaseTurns = 0;
	}

	/// <summary>
	/// Alternates player turns.
	/// Adds one to the currentPlayer then sets the currentPlayer to the remaider of currentPlayer/2
	/// </summary>
	public void nextPlayer ()
	{
		currentPlayer = (currentPlayer + 1) % 2;
	}
}

