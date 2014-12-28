using UnityEngine;
using System;
using FSM;

class DSActionNextTurn : FSMAction {

	public void execute (FSMContext context, object data)
	{
		GameAttrManager gam = context.get("Game Attribute Manager") as GameAttrManager;
		if (gam != null) {
			gam.GoNextPlayer ();
		}

		Debug.Log ("Next Players Turn");
		Debug.Log ("Current Player: " + gam.CurrentPlayer);
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

