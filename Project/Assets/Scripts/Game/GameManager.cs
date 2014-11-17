using UnityEngine;
using System.Collections;
using FSM;
using System;

/// <summary>
/// Game Manager to control game initialization.
/// Manages players connecting and input.
/// </summary>


public class GameManager : MonoBehaviour {
	/// <summary>
	/// The state machine.
	/// </summary>
	DSStateMachine stateMachine;
	/// <summary>
	/// Player who plays first.
	/// </summary>
	IController player1;
	/// <summary>
	/// Player who plays second
	/// </summary>
	IController player2;


	void Awake() {
		stateMachine = new DSStateMachine(new Player(2000,0,new Hand(),new Deck(), new Field(),new Subconscious()),
		                                  new Player(2000,0,new Hand(),new Deck(), new Field(),new Subconscious()),
		                                  new GameAttrManager());
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
