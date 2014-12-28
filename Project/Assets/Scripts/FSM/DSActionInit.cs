﻿using UnityEngine;
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
		this.gam.init(Random.Range(0,1));
		context.put ("Game Attribute Manager", gam);

		Debug.Log ("Game Initialized");
		Debug.Log ("Current Player: " + gam.CurrentPlayer);
		Debug.Log ("Player 1 Stats - Will: " + ((Player)context.get ("Player 1")).Will +
		           ", Imagination: " + ((Player)context.get ("Player 1")).Imagination +
		           ", Hand Size: " + ((Player)context.get ("Player 1")).HandSize);
		Debug.Log ("Player 2 Stats - Will: " + ((Player)context.get ("Player 2")).Will +
		           ", Imagination: " + ((Player)context.get ("Player 2")).Imagination +
		           ", Hand Size: " + ((Player)context.get ("Player 2")).HandSize);
		Debug.Log ("Press Q to Start the First Turn");
	}

	public DSActionInit(Player p1, Player p2, GameAttrManager gam){
		this.p1 = p1;
		this.p2 = p2;
		this.gam = gam;
	}
}
