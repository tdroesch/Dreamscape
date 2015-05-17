using UnityEngine;
using System.Collections;
using FSM;
using Dreamscape;

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

		
		currentPlayer.Client.TestWarning ("Turn End");
		currentPlayer.Client.TestLog ("End of Turn Card Effects");
		currentPlayer.Client.TestLog ("Current Player: " + (bm.CurrentPlayer+1));
		currentPlayer.Client.TestLog ("Player 1 Stats - Will: " + ((Player)context.get ("Player 1")).Will +
		                              ", Imagination: " + ((Player)context.get ("Player 1")).Imagination +
		                              ", Hand Size: " + ((Player)context.get ("Player 1")).HandSize);
		currentPlayer.Client.TestLog ("Player 2 Stats - Will: " + ((Player)context.get ("Player 2")).Will +
		                              ", Imagination: " + ((Player)context.get ("Player 2")).Imagination +
		                              ", Hand Size: " + ((Player)context.get ("Player 2")).HandSize);
		currentPlayer.Client.TestLog ("Next phase starts automatically.");

		opposingPlayer.Client.TestWarning ("Turn End");
		opposingPlayer.Client.TestLog ("End of Turn Card Effects");
		opposingPlayer.Client.TestLog ("Current Player: " + (bm.CurrentPlayer+1));
		opposingPlayer.Client.TestLog ("Player 1 Stats - Will: " + ((Player)context.get ("Player 1")).Will +
		                              ", Imagination: " + ((Player)context.get ("Player 1")).Imagination +
		                              ", Hand Size: " + ((Player)context.get ("Player 1")).HandSize);
		opposingPlayer.Client.TestLog ("Player 2 Stats - Will: " + ((Player)context.get ("Player 2")).Will +
		                              ", Imagination: " + ((Player)context.get ("Player 2")).Imagination +
		                              ", Hand Size: " + ((Player)context.get ("Player 2")).HandSize);
		opposingPlayer.Client.TestLog ("Next phase starts automatically.");
	}
}

