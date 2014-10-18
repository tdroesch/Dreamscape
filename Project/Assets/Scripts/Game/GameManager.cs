using UnityEngine;
using System.Collections;
using FSM;

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

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
