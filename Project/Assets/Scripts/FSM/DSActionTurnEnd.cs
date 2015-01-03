using UnityEngine;
using System.Collections;
using FSM;

class DSActionTurnEnd : FSMAction {
	public void execute (FSMContext context, object data)
	{
		//throw new System.NotImplementedException ();
		//get the current player
		BoardManager bm = context.get ("Game Attribute Manager") as BoardManager;
		Player currentPlayer = (Player)context.get ("Player "+(bm.CurrentPlayer+1));
		Player opposingPlayer = (Player)context.get ("Player "+((bm.CurrentPlayer+1)%2+1));
		//opposing player cards do oppend of turn effects.
		/*foreach (Card card in opposingPlayer.field.field)
		{
			card.getEventManager().OnOpponentEnd();
		}
		//current player cards do end of turn effects.
		foreach (Card card in currentPlayer.field.field)
		{
			card.getEventManager().OnTurnEnd();
		}*/

		
		Debug.Log ("Turn End");
		Debug.Log ("End of Turn Card Effects");
		Debug.Log ("Current Player: " + bm.CurrentPlayer);
		Debug.Log ("Player 1 Stats - Will: " + ((Player)context.get ("Player 1")).Will +
		           ", Imagination: " + ((Player)context.get ("Player 1")).Imagination +
		           ", Hand Size: " + ((Player)context.get ("Player 1")).HandSize);
		Debug.Log ("Player 2 Stats - Will: " + ((Player)context.get ("Player 2")).Will +
		           ", Imagination: " + ((Player)context.get ("Player 2")).Imagination +
		           ", Hand Size: " + ((Player)context.get ("Player 2")).HandSize);
		Debug.Log ("Press T to end turn.");
		Debug.Log ("Press Y to end Game.");
	}
}

