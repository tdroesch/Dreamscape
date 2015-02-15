using UnityEngine;
using System;
using FSM;
using Dreamscape;

class DSActionNextTurn : FSMAction {

	public void execute (FSMContext context, object data)
	{
		BoardManager bm = context.get("Game Attribute Manager") as BoardManager;
		if (bm != null) {
			bm.GoNextPlayer ();
		}

		Debug.Log ("Next Players Turn");
		Debug.Log ("Current Player: " + bm.CurrentPlayer);
		Debug.Log ("Player 1 Stats - Will: " + ((Player)context.get ("Player 1")).Will +
		           ", Imagination: " + ((Player)context.get ("Player 1")).Imagination +
		           ", Hand Size: " + ((Player)context.get ("Player 1")).HandSize);
		Debug.Log ("Player 2 Stats - Will: " + ((Player)context.get ("Player 2")).Will +
		           ", Imagination: " + ((Player)context.get ("Player 2")).Imagination +
		           ", Hand Size: " + ((Player)context.get ("Player 2")).HandSize);
	}

	public DSActionNextTurn ()
	{

	}
}

