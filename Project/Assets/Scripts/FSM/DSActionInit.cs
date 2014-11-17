using UnityEngine;
using System.Collections;
using FSM;
/// <summary>
/// Initialize the Dreamscape Finite State Machine.
/// </summary>
class DSActionInit : FSMAction {
	Player p1, p2;
	GameAttrManager gam;

	public void execute (FSMContext context, object data){
		context.put ("Player 1", p1);
		context.put ("Player 2", p2);
		this.gam.init(Random.Range(0,1),2);
		context.put ("Game Attribute Manager", gam);
	}

	public DSActionInit(Player p1, Player p2, GameAttrManager gam){
		this.p1 = p1;
		this.p2 = p2;
		this.gam = gam;
	}
}
