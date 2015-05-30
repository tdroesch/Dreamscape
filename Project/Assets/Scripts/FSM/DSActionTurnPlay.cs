using UnityEngine;
using System.Collections;
using FSM;
using Dreamscape;

class DSActionTurnPlay : FSMAction {
	public void execute (FSMContext context, object data)
	{
		//get the current player
		BoardManager bm = context.get ("Game Attribute Manager") as BoardManager;
		Player currentPlayer = (Player)context.get ("Player "+(bm.CurrentPlayer+1));
		Player opposingPlayer = (Player)context.get ("Player "+((bm.CurrentPlayer+1)%2+1));


		
		currentPlayer.Client.TestWarning ("Turn Play");
		currentPlayer.Client.TestLog ("Current Player: " + (bm.CurrentPlayer+1));
		
		opposingPlayer.Client.TestWarning ("Turn Play");
		opposingPlayer.Client.TestLog ("Current Player: " + (bm.CurrentPlayer+1));
		//Pop all actions off the action stack
		while (bm.ActionsOnStack()){
			bm.PopStack();
			currentPlayer.PlayCards();
		}
		currentPlayer.Client.TestLog ("Player 1 Stats - Will: " + ((Player)context.get ("Player 1")).Will +
		                              ", Imagination: " + ((Player)context.get ("Player 1")).Imagination +
		                              ", Hand Size: " + ((Player)context.get ("Player 1")).HandSize);
		currentPlayer.Client.TestLog ("Player 2 Stats - Will: " + ((Player)context.get ("Player 2")).Will +
		                              ", Imagination: " + ((Player)context.get ("Player 2")).Imagination +
		                              ", Hand Size: " + ((Player)context.get ("Player 2")).HandSize);
		currentPlayer.Client.TestLog ("Press W to play cards turn.");
		currentPlayer.Client.TestLog ("Press E to end turn.");
		currentPlayer.Client.TestLog ("Press R to end Game.");
		
		opposingPlayer.Client.TestLog ("Player 1 Stats - Will: " + ((Player)context.get ("Player 1")).Will +
		                              ", Imagination: " + ((Player)context.get ("Player 1")).Imagination +
		                              ", Hand Size: " + ((Player)context.get ("Player 1")).HandSize);
		opposingPlayer.Client.TestLog ("Player 2 Stats - Will: " + ((Player)context.get ("Player 2")).Will +
		                              ", Imagination: " + ((Player)context.get ("Player 2")).Imagination +
		                              ", Hand Size: " + ((Player)context.get ("Player 2")).HandSize);
		opposingPlayer.Client.TestLog ("Press W to play cards turn.");
		opposingPlayer.Client.TestLog ("Press E to end turn.");
		opposingPlayer.Client.TestLog ("Press R to end Game.");
	}
}