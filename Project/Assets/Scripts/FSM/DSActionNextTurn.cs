using UnityEngine;
using System;
using FSM;
using Dreamscape;

class DSActionNextTurn : FSMAction {

	public void execute (FSMContext context, object data)
	{
		BoardManager bm = context.get("Game Attribute Manager") as BoardManager;
		if (bm != null) {
			bm.GoNextPlayer ();
		}
		
		IClient client1 = ((Player)context.get ("Player 1")).Client;
		IClient client2 = ((Player)context.get ("Player 2")).Client;

		client1.TestWarning ("Next Players Turn");
		client1.TestLog ("Current Player: " + (bm.CurrentPlayer+1));
		client1.TestLog ("Player 1 Stats - Will: " + ((Player)context.get ("Player 1")).Will +
		           ", Imagination: " + ((Player)context.get ("Player 1")).Imagination +
		           ", Hand Size: " + ((Player)context.get ("Player 1")).HandSize);
		client1.TestLog ("Player 2 Stats - Will: " + ((Player)context.get ("Player 2")).Will +
		           ", Imagination: " + ((Player)context.get ("Player 2")).Imagination +
		                 ", Hand Size: " + ((Player)context.get ("Player 2")).HandSize);

		client2.TestWarning ("Next Players Turn");
		client2.TestLog ("Current Player: " + (bm.CurrentPlayer+1));
		client2.TestLog ("Player 1 Stats - Will: " + ((Player)context.get ("Player 1")).Will +
		                ", Imagination: " + ((Player)context.get ("Player 1")).Imagination +
		                 ", Hand Size: " + ((Player)context.get ("Player 1")).HandSize);
		client2.TestLog ("Player 2 Stats - Will: " + ((Player)context.get ("Player 2")).Will +
		                 ", Imagination: " + ((Player)context.get ("Player 2")).Imagination +
		                 ", Hand Size: " + ((Player)context.get ("Player 2")).HandSize);
	}

	public DSActionNextTurn ()
	{

	}
}

