using UnityEngine;
using System.Collections;
using FSM;
using Dreamscape;

class DSActionGameStart : FSMAction {
	int startingImagination;
	int startingHandSize;

	public void execute (FSMContext context, object data)
	{
		//throw new System.NotImplementedException ();
		// Get the who players.
		BoardManager bm = context.get ("Game Attribute Manager") as BoardManager;
		Player currentPlayer = (Player)context.get ("Player "+(bm.CurrentPlayer+1));
		Player opposingPlayer = (Player)context.get ("Player "+((bm.CurrentPlayer+1)%2+1));
		// Set each players starting Imagination
		currentPlayer.Imagination+=startingImagination;
		opposingPlayer.Imagination+=startingImagination;
		// Draw cards to each players starting hand
		for (int i=0; i<startingHandSize; i++){
			currentPlayer.DrawCard();
			opposingPlayer.DrawCard();
		}
		Debug.LogWarning ("Game Start");
		Debug.Log ("Current Player: " + (bm.CurrentPlayer+1));
		Debug.Log ("Player 1 Stats - Will: " + ((Player)context.get ("Player 1")).Will +
			", Imagination: " + ((Player)context.get ("Player 1")).Imagination +
		           ", Hand Size: " + ((Player)context.get ("Player 1")).HandSize);
		Debug.Log ("Player 2 Stats - Will: " + ((Player)context.get ("Player 2")).Will +
		           ", Imagination: " + ((Player)context.get ("Player 2")).Imagination +
		           ", Hand Size: " + ((Player)context.get ("Player 2")).HandSize);
	}

	public DSActionGameStart(int imagination, int hand){
		startingImagination = imagination;
		startingHandSize = hand;
	}
}

