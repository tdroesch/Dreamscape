using UnityEngine;
using System.Collections;
using FSM;

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

