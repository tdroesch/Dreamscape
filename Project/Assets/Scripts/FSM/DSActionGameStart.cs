using UnityEngine;
using System.Collections;
using FSM;
using Dreamscape;

class DSActionGameStart : FSMAction {
	int startingImagination;
	int startingHandSize;

	public void execute (FSMContext context, object data)
	{
		if (context.get ("Player 1").GetType() == typeof(Player) && context.get ("Player 2").GetType() == typeof(Player)) {
			// Get the who players.
			BoardManager bm = context.get ("Game Attribute Manager") as BoardManager;
			Player currentPlayer = (Player)context.get ("Player 1");
			Player opposingPlayer = (Player)context.get ("Player 2");
			bm.init(Random.Range(0,1), currentPlayer, opposingPlayer);
			currentPlayer = (Player)context.get ("Player " + (bm.CurrentPlayer + 1));
			opposingPlayer = (Player)context.get ("Player " + ((bm.CurrentPlayer + 1) % 2 + 1));

			// Draw cards to each players starting hand
			for (int i=0; i<startingHandSize; i++) {
				currentPlayer.DrawCard ();
				opposingPlayer.DrawCard ();
			}
			currentPlayer.Client.TestWarning ("Game Start");
			currentPlayer.Client.TestLog ("Current Player: " + (bm.CurrentPlayer + 1));
			currentPlayer.Client.TestLog ("Player 1 Stats - Will: " + ((Player)context.get ("Player 1")).Will +
				", Imagination: " + ((Player)context.get ("Player 1")).Imagination +
				", Hand Size: " + ((Player)context.get ("Player 1")).HandSize);
			currentPlayer.Client.TestLog ("Player 2 Stats - Will: " + ((Player)context.get ("Player 2")).Will +
				", Imagination: " + ((Player)context.get ("Player 2")).Imagination +
				", Hand Size: " + ((Player)context.get ("Player 2")).HandSize);
			opposingPlayer.Client.TestWarning ("Game Start");
			opposingPlayer.Client.TestLog ("Current Player: " + (bm.CurrentPlayer + 1));
			opposingPlayer.Client.TestLog ("Player 1 Stats - Will: " + ((Player)context.get ("Player 1")).Will +
			                              ", Imagination: " + ((Player)context.get ("Player 1")).Imagination +
			                              ", Hand Size: " + ((Player)context.get ("Player 1")).HandSize);
			opposingPlayer.Client.TestLog ("Player 2 Stats - Will: " + ((Player)context.get ("Player 2")).Will +
			                              ", Imagination: " + ((Player)context.get ("Player 2")).Imagination +
			                              ", Hand Size: " + ((Player)context.get ("Player 2")).HandSize);
		}
	}

	public DSActionGameStart(int imagination, int hand){
		startingImagination = imagination;
		startingHandSize = hand;
	}
}

