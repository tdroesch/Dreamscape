using UnityEngine;
using System.Collections;
using FSM;
using Dreamscape;

class DSActionTurnDraw : FSMAction {
	public void execute (FSMContext context, object data)
	{
		//throw new System.NotImplementedException ();
		//get the current player
		BoardManager bm = context.get ("Game Attribute Manager") as BoardManager;
		Player currentPlayer = (Player)context.get ("Player "+(bm.CurrentPlayer+1));
		Player opposingPlayer = (Player)context.get ("Player "+((bm.CurrentPlayer+1)%2+1));
		//Gain Imagination
		currentPlayer.Imagination += 200;
		//Draw Cards
		currentPlayer.DrawCard ();
		
		currentPlayer.Client.TestWarning ("Turn Draw");
		currentPlayer.Client.TestLog ("Current Player: " + (bm.CurrentPlayer+1));
		currentPlayer.Client.TestLog ("Player 1 Stats - Will: " + ((Player)context.get ("Player 1")).Will +
		           ", Imagination: " + ((Player)context.get ("Player 1")).Imagination +
		           ", Hand Size: " + ((Player)context.get ("Player 1")).HandSize);
		currentPlayer.Client.TestLog ("Player 2 Stats - Will: " + ((Player)context.get ("Player 2")).Will +
		           ", Imagination: " + ((Player)context.get ("Player 2")).Imagination +
		           ", Hand Size: " + ((Player)context.get ("Player 2")).HandSize);
		currentPlayer.Client.TestLog ("Next phase starts automatically.");
		
		opposingPlayer.Client.TestWarning ("Turn Draw");
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

