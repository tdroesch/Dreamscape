using UnityEngine;
using System.Collections;
using FSM;
using Dreamscape;

class DSActionTurnStart : FSMAction {

	public void execute (FSMContext context, object data)
	{
		//throw new System.NotImplementedException ();
		
		//get the current player
		BoardManager bm = context.get ("Game Attribute Manager") as BoardManager;
		Player currentPlayer = (Player)context.get ("Player "+(bm.CurrentPlayer+1));
		Player opposingPlayer = (Player)context.get ("Player "+((bm.CurrentPlayer+1)%2+1));
		//opposing player cards do oppstart of turn effects.
		/*foreach (Card card in opposingPlayer.getField())
		{
			card.getEventManager().OnOpponentStart();
		}
		//current player cards do start of turn effects.
		foreach (Card card in currentPlayer.getField())
		{
			card.getEventManager().OnTurnStart();
		}*/

		Debug.LogWarning ("Turn Start");
		Debug.Log ("Start of Turn Card Effects");
		Debug.Log ("Current Player: " + (bm.CurrentPlayer+1));
		Debug.Log ("Player 1 Stats - Will: " + ((Player)context.get ("Player 1")).Will +
			", Imagination: " + ((Player)context.get ("Player 1")).Imagination +
		           ", Hand Size: " + ((Player)context.get ("Player 1")).HandSize);
		Debug.Log ("Player 2 Stats - Will: " + ((Player)context.get ("Player 2")).Will +
		           ", Imagination: " + ((Player)context.get ("Player 2")).Imagination +
		           ", Hand Size: " + ((Player)context.get ("Player 2")).HandSize);
		Debug.Log ("Press W to continue with the turn");

	}
}

