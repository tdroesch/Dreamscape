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


		
		Debug.LogWarning ("Turn Play");
		Debug.Log ("Current Player: " + (bm.CurrentPlayer+1));
		//Pop all actions off the action stack
		while (bm.ActionsOnStack()){
			bm.PopStack();
			currentPlayer.PlayCards();
		}
		Debug.Log ("Player 1 Stats - Will: " + ((Player)context.get ("Player 1")).Will +
		           ", Imagination: " + ((Player)context.get ("Player 1")).Imagination +
		           ", Hand Size: " + ((Player)context.get ("Player 1")).HandSize);
		Debug.Log ("Player 2 Stats - Will: " + ((Player)context.get ("Player 2")).Will +
		           ", Imagination: " + ((Player)context.get ("Player 2")).Imagination +
		           ", Hand Size: " + ((Player)context.get ("Player 2")).HandSize);
		Debug.Log ("Press W to play cards turn.");
		Debug.Log ("Press E to end turn.");
		Debug.Log ("Press R to end Game.");
	}
}