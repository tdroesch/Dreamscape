using UnityEngine;
using System.Collections;
using FSM;
using Dreamscape;

class DSActionTurnPlay : FSMAction {
	public void execute (FSMContext context, object data)
	{
		//throw new System.NotImplementedException ();
		//get the current player
		BoardManager bm = context.get ("Game Attribute Manager") as BoardManager;
		Player currentPlayer = (Player)context.get ("Player "+(bm.CurrentPlayer+1));
		Player opposingPlayer = (Player)context.get ("Player "+((bm.CurrentPlayer+1)%2+1));

		//Wait for player to play cards and stuff
		currentPlayer.PlayCard ();
		currentPlayer.Imagination -= 100;
		
		Debug.Log ("Turn Play");
		Debug.Log ("Player plays a 100i card");
		Debug.Log ("Current Player: " + bm.CurrentPlayer);
		Debug.Log ("Player 1 Stats - Will: " + ((Player)context.get ("Player 1")).Will +
		           ", Imagination: " + ((Player)context.get ("Player 1")).Imagination +
		           ", Hand Size: " + ((Player)context.get ("Player 1")).HandSize);
		Debug.Log ("Player 2 Stats - Will: " + ((Player)context.get ("Player 2")).Will +
		           ", Imagination: " + ((Player)context.get ("Player 2")).Imagination +
		           ", Hand Size: " + ((Player)context.get ("Player 2")).HandSize);
		Debug.Log ("Press R to continue turn.");
	}
}

