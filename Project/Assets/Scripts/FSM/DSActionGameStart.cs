using UnityEngine;
using System.Collections;
using FSM;

class DSActionGameStart : FSMAction {
	int startingImagination;
	int startingHandSize;

	public void execute (FSMContext context, object data)
	{
		throw new System.NotImplementedException ();
		// Get the who players.
		GameAttrManager gam = context.get ("Game Attribute Manager") as GameAttrManager;
		Player currentPlayer = (Player)context.get ("Player "+gam.CurrentPlayer);
		Player opposingPlayer = (Player)context.get ("Player "+(gam.CurrentPlayer+1)%2);
		// Set each players starting Imagination
		currentPlayer.Imagination+=startingImagination;
		opposingPlayer.Imagination+=startingImagination;
		// Draw cards to each players starting hand
		for (int i=0; i<startingHandSize; i++){
			currentPlayer.DrawCard();
			opposingPlayer.DrawCard();
		}
	}

	public DSActionGameStart(int imagination, int hand){
		startingImagination = imagination;
		startingHandSize = hand;
	}
}

