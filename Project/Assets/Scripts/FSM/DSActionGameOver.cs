using UnityEngine;
using System.Collections;
using FSM;
using Dreamscape;

/// <summary>
/// Finite State Machine Action
/// Triggered on entering the Game over State
/// </summary>
class DSActionGameOver : FSMAction {
	public void execute (FSMContext context, object data)
	{
		IClient client1 = ((Player)context.get ("Player 1")).Client;
		IClient client2 = ((Player)context.get ("Player 2")).Client;
		client1.TestWarning ("Game is Over");
		client1.TestWarning ("Stop Scene");
		client2.TestWarning ("Game is Over");
		client2.TestWarning ("Stop Scene");
		//throw new System.NotImplementedException ();
		//Tell winner who won.
		//wait for controllers to quit
	}
}

