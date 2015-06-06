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
//		public IClient player1;
		public LocalClientGameManager player1;//Temporary for testing.  Remove and uncomment above line.
		/// <summary>
		/// The Agent who plays second
		/// </summary>
//		public IClient player2;
		public LocalClientGameManager player2;//Temporary for testing.  Remove and uncommment above line.
	
	
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
		
		//**********************************
		// Messages to the ServerGameManager


		/// <summary>
		/// Initialize a client in the state machine.
		/// </summary>
		/// <param name="_player">The player being initialized.</param>
		public void InitClient (IClient _player/*There will be more paramaters in here*/)
		{
			stateMessage ("Start Game", _player);
		}
		
		/// <summary>
		/// Plays the card.
		/// </summary>
		/// <param name="_cardID">ID of the card being played.</param>
		/// <param name="_targets">The targets of the card.</param>
		/// <param name="_destination">ID of the container it is moved to.</param>
		/// <param name="_player">Player who requested the command.</param>
		public void PlayCard (int _cardID, int[] _targets, int _destination, IClient _player)
		{
			stateMessage ("Turn Action", new TurnActionData (TurnActionType.PlayCard, _cardID, -1, _targets, _destination, _player, WaitForResponse));
		}
		
		/// <summary>
		/// Uses the card ability.
		/// </summary>
		/// <param name="_cardID">ID of the card being used.</param>
		/// <param name="_abilityID">ID of the ability being used.</param>
		/// <param name="_targets">The targets of the ability.</param>
		/// <param name="_player">Player who requested the command.</param>
		public void UseCardAbility (int _cardID, int _abilityID, int[] _targets, IClient _player)
		{
			stateMessage ("Turn Action", new TurnActionData (TurnActionType.UseAbility, _cardID, _abilityID, _targets, -1, _player, WaitForResponse));
		}
		
		/// <summary>
		/// Rearange cards possitions on the board
		/// </summary>
		/// <param name="_cardID">ID of the card being moved.</param>
		/// <param name="_destination">ID of the container it is moved to.</param>
		/// <param name="_player">Player who requested the command.</param>
		public void MoveCardToField (int _cardID, int _destination, IClient _player)
		{
			stateMessage ("Turn Action", new TurnActionData (TurnActionType.MoveCard, _cardID, -1, null, _destination, _player, WaitForResponse));
		}
		
		/// <summary>
		/// Ends the phase.
		/// </summary>
		/// <param name="_player">Player who requested the command.</param>
		public void EndPhase (IClient _player)
		{
			stateMessage ("Start End", _player);
		}

		/// <summary>
		/// Resign the specified _player.
		/// </summary>
		/// <param name="_player">Player who requested the command.</param>
		public void Resign (IClient _player)
		{
			stateMessage ("End Game", _player);
		}
		//**********************************

		// Will be replace by the above functions	
		public void stateMessage (string msg, object data)
		{
			stateMachine.message (msg, data);
		}

		/// <summary>
		/// Waits for response.
		/// </summary>
		/// <param name="_time">Time.</param>
		void WaitForResponse(float _time, IClient _player){
			StartCoroutine(ResponseRoutine(_time, _player));
		}

		/// <summary>
		/// Response coroutine.
		/// </summary>
		/// <returns>The routine.</returns>
		/// <param name="_time">Ttime.</param>
		IEnumerator ResponseRoutine(float _time, IClient _player){
			Debug.LogWarning ("Response Time Started.  Wait " + _time + " seconds.");
			yield return new WaitForSeconds(_time);
			Debug.LogWarning ("Response Time Ended.");
			stateMachine.message("End Response", _player);
		}
	}

	/// <summary>
	/// Turn action data.
	/// Class used to pass actions into the state machine.
	/// </summary>
	class TurnActionData {
		public TurnActionType turnActionType;
		public int cardID;
		public int abilityID;
		public int[] targets;
		public int destination;
		public IClient player;
		public ResponseTimeCallback responseTimeCallback;

		public TurnActionData (TurnActionType _turnActionType, int _cardID, int _abilityID, int[] _targets, int _destination, IClient _player, ResponseTimeCallback _responseTimeCallback)
		{
			turnActionType = _turnActionType;
			cardID = _cardID;
			abilityID = _abilityID;
			targets = _targets;
			destination = _destination;
			player = _player;
			responseTimeCallback = _responseTimeCallback;
		}
	}

	/// <summary>
	/// Turn action type.
	/// </summary>
	enum TurnActionType {
		PlayCard,
		UseAbility,
		MoveCard
	}

	/// <summary>
	/// Response time callback.
	/// </summary>
	delegate void ResponseTimeCallback(float _time, IClient _player);
}
