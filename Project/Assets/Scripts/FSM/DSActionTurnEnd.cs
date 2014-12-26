using UnityEngine;
using System.Collections;
using FSM;

class DSActionTurnEnd : FSMAction {
	public void execute (FSMContext context, object data)
	{
		throw new System.NotImplementedException ();
		//get the current player
		GameAttrManager gam = context.get ("Game Attribute Manager") as GameAttrManager;
		Player currentPlayer = (Player)context.get ("Player "+gam.CurrentPlayer);
		Player opposingPlayer = (Player)context.get ("Player "+(gam.CurrentPlayer+1)%2);
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
	}
}

