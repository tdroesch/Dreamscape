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
	public HumanController player1;
	/// <summary>
	/// Player who plays second
	/// </summary>
	public HumanController player2;


	void Awake() {
		Player p1 = new Player (2000, 0, new Hand (), new Deck (), new Field (), new Subconscious (), player1);
		Player p2 = new Player (2000, 0, new Hand (), new Deck (), new Field (), new Subconscious (), player2);
		stateMachine = new DSStateMachine(p1, p2, new GameAttrManager());
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void stateMessage (string msg, object data)
	{
		stateMachine.message(msg, data);
	}
}
