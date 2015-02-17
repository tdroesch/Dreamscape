using UnityEngine;
using System.Collections;
using FSM;
using System;

namespace Dreamscape
{
	/// <summary>
	/// Game Manager to control game initialization.
	/// Manages players connecting and input.
	/// </summary>
	
	
	public class ServerGameManager : MonoBehaviour {
		/// <summary>
		/// The state machine.
		/// </summary>
		DSStateMachine stateMachine;
		/// <summary>
		/// The Agent who plays first.
		/// </summary>
//		public IController player1;
		public LocalController player1;//Temporary for testing.  Remove and uncomment above line.
		/// <summary>
		/// The Agent who plays second
		/// </summary>
//		public IController player2;
		public LocalController player2;//Temporary for testing.  Remove and uncommment above line.
	
	
		void Awake ()
		{
			Player p1 = new Player (2000, 0, new Hand (), new Deck (), new Field (), new Subconscious (), player1);
			Player p2 = new Player (2000, 0, new Hand (), new Deck (), new Field (), new Subconscious (), player2);
			stateMachine = new DSStateMachine (p1, p2, new BoardManager ());
		}
	
		// Use this for initialization
		void Start ()
		{
	
		}
		
		// Update is called once per frame
		void Update ()
		{
		
		}
	
		public void stateMessage (string msg, object data)
		{
			stateMachine.message (msg, data);
		}
	}
}
