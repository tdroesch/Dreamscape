using UnityEngine;
using System.Collections;
using FSM;
using Dreamscape;
/// <summary>
/// Initialize the Dreamscape Finite State Machine.
/// </summary>
class DSActionInit : FSMAction {
	IClient p1, p2;
	BoardManager bm;

	public void execute (FSMContext context, object data){
		Random.seed = System.DateTime.Today.Millisecond;
		context.put ("Player 1", p1);
		context.put ("Player 2", p2);
		context.put ("Game Attribute Manager", bm);

		p1.TestWarning ("Game Initialized");
		p2.TestWarning ("Game Initialized");
//		Debug.Log ("Current Player: " + (bm.CurrentPlayer+1));
//		Debug.Log ("Player 1 Stats - Will: " + ((Player)context.get ("Player 1")).Will +
//		           ", Imagination: " + ((Player)context.get ("Player 1")).Imagination +
//		           ", Hand Size: " + ((Player)context.get ("Player 1")).HandSize);
//		Debug.Log ("Player 2 Stats - Will: " + ((Player)context.get ("Player 2")).Will +
//		           ", Imagination: " + ((Player)context.get ("Player 2")).Imagination +
//		           ", Hand Size: " + ((Player)context.get ("Player 2")).HandSize);
		p1.TestLog ("Press Q to Add the First Player");
		p2.TestLog ("Press Q to Add the First Player");
	}

	public DSActionInit(IClient p1, IClient p2, BoardManager bm){
		this.p1 = p1;
		this.p2 = p2;
		this.bm = bm;
	}
}
