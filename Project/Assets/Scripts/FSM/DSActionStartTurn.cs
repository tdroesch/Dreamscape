using UnityEngine;
using System.Collections;
using FSM;

class DSActionStartTurn : FSMAction {
	int imaginationGain;

	public DSActionStartTurn(int ig){
		imaginationGain = ig;
	}

	public void execute (FSMContext context, object data)
	{
		throw new System.NotImplementedException ();
		
		//get the current player
		GameManager gm = context.get ("Game Manager") as GameManager;
		Player currentPlayer = (Player)context.get ("Player "+gm.getCurrentPlayer());
		Player opposingPlayer = (Player)context.get ("Player "+(gm.getCurrentPlayer()+1)%2);
		//opposing player cards do oppstart of turn effects.
		/*foreach (Card card in opposingPlayer.getField())
		{
			card.getEventManager().OnOpponentStart();
		}
		//current player cards do start of turn effects.
		foreach (Card card in currentPlayer.getField())
		{
			card.getEventManager().OnTurnStart();
		}
		//add imagination to the player
		currentPlayer.addImagination(imaginationGain);
		//player draws a card
		currentPlayer.drawCard();*/

	}
}

