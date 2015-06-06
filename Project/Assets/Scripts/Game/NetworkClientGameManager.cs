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
			if (Input.GetKeyDown (KeyCode.Q)) {
				InitClient(0, new int[40], new int[]{1,2,3}, 2000, 250);
			} else if (Input.GetKeyDown (KeyCode.W)) {
				PlayCard (0, new int[1] , 0);
			} else if (Input.GetKeyDown (KeyCode.E)) {
				EndPhase ();
			} else if (Input.GetKeyDown (KeyCode.R)) {
				Resign ();
			}
		}
		//***********************************************

		[RPC]
		void NetTestLog(string data){
			Debug.Log(data);
		}
		
		[RPC]
		void NetTestWarning(string data){
			Debug.LogWarning(data);
		}
		
		//Receivers

		[RPC]
		void NetCreateCard(string _info){
			string[] args = _info.Split (';');

			int cardID = int.Parse(args[0]);
			int GUID = int.Parse(args[1]);
			int destination = int.Parse(args[2]);

			//CreateCard(cardID, GUID, destination);
		}

		[RPC]
		void NetMoveCard(string _info){
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
		void NetCreatePlayer(string _info){
			string[] args = _info.Split (';');
			
			int charID = int.Parse(args[0]);
			int GUID = int.Parse(args[1]);
			int opponent = int.Parse(args[2]);
			
			//CreatePlayer(charID, GUID, opponent);
			
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
		public override void InitClient (int _charID, int[] _deckList, int[] _sleepPattern, int _initWill, int _initImagination){

			string data = string.Empty;
			data += _charID.ToString() + ";";
			data += Utility.IntArrayToString (_deckList) + ";";
			data += Utility.IntArrayToString (_sleepPattern) + ";";
			data += _initWill.ToString () + ";";
			data += _initImagination.ToString ();

			GetComponent<NetworkView>().RPC("NetInitClient",RPCMode.Server,data);
		}

		/// <summary>
		/// Plays the card.
		/// </summary>
		/// <param name="_cardID">ID of the card being played.</param>
		/// <param name="_targets">The targets of the card.</param>
		/// <param name="_destination">ID of the container it is moved to.</param>
		public override void PlayCard (int _cardID, int[] _targets, int _destination){
		
			string data = string.Empty;
			data+= _cardID.ToString()+";";
			data+= Utility.IntArrayToString(_targets)+";";
			data+= _destination.ToString();
			
			GetComponent<NetworkView>().RPC("NetPlayCard",RPCMode.Server,data);
		
		}
		
		/// <summary>
		/// Uses the card ability.
		/// </summary>
		/// <param name="_cardID">ID of the card being used.</param>
		/// <param name="_abilityID">ID of the ability being used.</param>
		/// <param name="_targets">The targets of the ability.</param>
		public override void UseCardAbility (int _cardID, int _abilityID, int[] _targets){
		
			string data = string.Empty;
			data+= _cardID.ToString()+";";
			data+= _abilityID.ToString()+";";
			data+= Utility.IntArrayToString(_targets);
			
			GetComponent<NetworkView>().RPC("NetUseCardAbility",RPCMode.Server,data);
			
		}
		
		/// <summary>
		/// Rearange cards possitions on the board
		/// </summary>
		/// <param name="_cardID">ID of the card being moved.</param>
		/// <param name="_destination">ID of the container it is moved to.</param>
		public override void MoveCardToField (int _cardID, int _destination){
			
			string data = string.Empty;
			data+= _cardID.ToString()+";";
			data+= _destination.ToString();
			
			GetComponent<NetworkView>().RPC("NetMoveCardToField",RPCMode.Server,data);
			
		}
		
		/// <summary>
		/// Ends the phase.
		/// </summary>
		public override void EndPhase (){
			
			GetComponent<NetworkView>().RPC("NetEndPhase",RPCMode.Server);
			
		}

		/// <summary>
		/// Resign the specified _player.
		/// </summary>
		/// <param name="_player">Player who requested the command.</param>
		public override void Resign (){
		
			GetComponent<NetworkView>().RPC("NetResign",RPCMode.Server);
			
		}
		//**********************************

		//**********************************
		//Junk Network Functions
		[RPC]
		void NetInitClient(string _info){
		}
		
		[RPC]
		void NetPlayCard(string _info){
		}
		
		[RPC]
		void NetUseCardAbility(string _info){
		}
		
		[RPC]
		void NetMoveCardToField(string _info){
		}
		
		[RPC]
		void NetEndPhase(){
		}
		
		[RPC]
		void NetResign(){
		}
	}
}