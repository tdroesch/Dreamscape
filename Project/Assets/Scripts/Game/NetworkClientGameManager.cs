using UnityEngine;
using System.Collections;

namespace Dreamscape
{
	/// <summary>
	/// Client Game Manager for a networked player
	/// </summary>
	public class NetworkClientGameManager : BaseClientGameManager {
		// Functions to recieve net messages from the NetworkClient and execute BaseClientGameManager functions


		//***********************************************
		//This is almost entirely for testing purposes.
		ServerGameManager gm;
		
		// Use this for initialization
		void Start ()
		{
			gm = GetComponent<ServerGameManager> ();
		}
		
		// Update is called once per frame
		void Update ()
		{
		}
		//***********************************************

		
		//Receivers
		[RPC]
		void NetPlayerCard(string _info){
			string[] args = _info.Split (';');
			
			int cardID = int.Parse(args[0]);
			int source = int.Parse(args[1]);
			int destination = int.Parse(args[2]);
			
			//MoveCard(cardID, source, destination);
			
		}
		
		[RPC]
		void NetChangeCardAttribute(string _info){
			string[] args = _info.Split (';');
			
			int cardID = int.Parse(args[0]);
			CardAttribute cardAttribute = (CardAttribute)System.Enum.Parse(typeof(CardAttribute),args[1]);
			int destination = int.Parse(args[2]);
			
			//ChangeCardAttribute(cardID, cardAttribute, destination);
			
		}
		
		[RPC]
		void NetChangePlayerAttribute(string _info){
			string[] args = _info.Split (';');
			
			int cardID = int.Parse(args[0]);
			PlayerAttribute playerAttribute = (PlayerAttribute)System.Enum.Parse(typeof(PlayerAttribute),args[1]);
			int value = int.Parse(args[2]);
			
			//ChangePlayerAttribute(cardID, playerAttribute, value);
			
		}
		
		[RPC]
		void NetEndGame(int _playerID){
			//EndGame(_playerID);
		}
		
		

		//**********************************
		// Messages to the ServerGameManager
		// These messages will be sent through the network.

		/// <summary>
		/// Initialize a client in the state machine.
		/// </summary>
		/// <param name="_player">The player being initialized.</param>
		public override void InitClient (int[] _deckList, int[] _sleepPattern)
		{
			
		}

		/// <summary>
		/// Plays the card.
		/// </summary>
		/// <param name="_GUID">ID of the card being played.</param>
		/// <param name="_targets">The targets of the card.</param>
		/// <param name="_destination">ID of the container it is moved to.</param>
		public override void PlayCard (int _GUID, int[] _targets, int _destination){}
		
		/// <summary>
		/// Uses the card ability.
		/// </summary>
		/// <param name="_GUID">ID of the card being used.</param>
		/// <param name="_abilityID">ID of the ability being used.</param>
		/// <param name="_targets">The targets of the ability.</param>
		public override void UseCardAbility (int _GUID, int _abilityID, int[] _targets){}
		
		/// <summary>
		/// Rearange cards possitions on the board
		/// </summary>
		/// <param name="_GUID">ID of the card being moved.</param>
		/// <param name="_destination">ID of the container it is moved to.</param>
		public override void MoveCardToField (int _GUID, int _destination){}
		
		/// <summary>
		/// Ends the phase.
		/// </summary>
		public override void EndPhase (){}

		/// <summary>
		/// Resign the specified _player.
		/// </summary>
		/// <param name="_player">Player who requested the command.</param>
		public override void Resign ()
		{

		}
		//**********************************
	}
}