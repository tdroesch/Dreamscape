using UnityEngine;
using System.Collections;
using FSM;

class GameAttrManager
{
	int currentPlayer;
	int phaseTurns;

	public int CurrentPlayer{
		get{return currentPlayer;}
		set{currentPlayer = value;}
	}

	public int PhaseTurns{
		get{return phaseTurns;}
		set{phaseTurns = value;}
	}

	public void init ()
	{
		throw new System.NotImplementedException ();
	}

	public void nextPlayer ()
	{
		throw new System.NotImplementedException ();
	}
}

