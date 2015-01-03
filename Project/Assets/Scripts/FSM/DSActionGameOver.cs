using UnityEngine;
using System.Collections;
using FSM;

/// <summary>
/// Finite State Machine Action
/// Triggered on entering the Game over State
/// </summary>
class DSActionGameOver : FSMAction {
	public void execute (FSMContext context, object data)
	{
		Debug.Log ("Game is Over");
		Debug.Log ("Stop Scene");
		//throw new System.NotImplementedException ();
		//Tell winner who won.
		//wait for controllers to quit
	}
}

