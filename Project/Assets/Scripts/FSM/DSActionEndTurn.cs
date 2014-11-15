using UnityEngine;
using System.Collections;
using FSM;

class DSActionEndTurn : FSMAction {
	public void execute (FSMContext context, object data)
	{
		throw new System.NotImplementedException ();
		//get the current player
		GameManager gm = context.get ("Game Manager") as GameManager;
		Player currentPlayer = context.get ("Player "+gm.getCurrentPlayer());
		Player opposingPlayer = context.get ("Player "+(gm.getCurrentPlayer()+1)%2);
		//opposing player cards do oppend of turn effects.
		foreach (Card card in opposingPlayer.getField())
		{
			card.getEventManager().OnOpponentEnd();
		}
		//current player cards do end of turn effects.
		foreach (Card card in currentPlayer.getField())
		{
			card.getEventManager().OnTurnEnd();
		}
	}
}

