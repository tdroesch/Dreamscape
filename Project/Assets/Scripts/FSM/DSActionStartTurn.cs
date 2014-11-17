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
		GameAttrManager gam = context.get ("Game Attribute Manager") as GameAttrManager;
		Player currentPlayer = (Player)context.get ("Player "+gam.CurrentPlayer);
		Player opposingPlayer = (Player)context.get ("Player "+(gam.CurrentPlayer+1)%2);
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

