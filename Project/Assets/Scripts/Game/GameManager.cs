using UnityEngine;
using System.Collections;
using FSM;
using System;

/// <summary>
/// Game Manager to control game flow.
/// </summary>


public class GameManager : MonoBehaviour {
	/// <summary>
	/// The state machine.
	/// </summary>
	DSStateMachine stateMachine;
	/// <summary>
	/// Player who plays first.
	/// </summary>
	Player player1;
	/// <summary>
	/// Player who plays second
	/// </summary>
	Player player2;
	/// <summary>
	/// The field that both players can see.
	/// </summary>
	Field field;
	/// <summary>
	/// Int represents who's turn it is
	/// set to 0 or 1.
	/// </summary>
	int currentPlayer;

	public int PhaseTurns {
		get;
		set;
	}

	public void init ()
	{
		throw new System.NotImplementedException ();
	}
/// <summary>
/// Gets the current player as an Integer.
/// </summary>
/// <returns>0 or 1</returns>
	public int getCurrentPlayer ()
	{
		throw new System.NotImplementedException ();
	}

	public void nextPlayer ()
	{
		throw new NotImplementedException ();
	}

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
