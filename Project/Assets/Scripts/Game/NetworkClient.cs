using UnityEngine;
using System.Collections;

namespace Dreamscape
{
	/// <summary>
	/// Sends messages to the network controller
	/// </summary>
	public class NetworkClient : MonoBehaviour, IClient {
		
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

		void OnPlayerConnected(NetworkPlayer __player){
			gm.AddClient (this);
		}
		
		//***********************************************
		//Network messages
		
		[RPC]
		void NetInitClient(string _info){
			string[] args = _info.Split (';');

			int[] deckList = Utility.StringToIntArray (args[0]);
			int[] sleepPattern = Utility.StringToIntArray (args[1]);
			int initWill = int.Parse (args [2]);
			int initImagination = int.Parse (args [3]);

			gm.InitClient(deckList, sleepPattern, initWill, initImagination, this);
		}
		
		[RPC]
		void NetPlayCard(string _info){
			string[] args = _info.Split (';');
			
			int cardID = int.Parse(args[0]);
			int[] targets = Utility.StringToIntArray(args[1]);
			int destination = int.Parse(args[2]);
			
			gm.PlayCard(cardID, targets, destination,this);
		}
		
		[RPC]
		void NetUseCardAbility(string _info){
			string[] args = _info.Split (';');
			
			int cardID = int.Parse(args[0]);
			int abilityID = int.Parse(args[1]);
			int[] targets = Utility.StringToIntArray(args[2]);
			
			gm.UseCardAbility(cardID, abilityID, targets,this);
		}
		
		[RPC]
		void NetMoveCardToField(string _info){
			string[] args = _info.Split (';');
			
			int cardID = int.Parse(args[0]);
			int destination = int.Parse(args[1]);
			
			gm.MoveCardToField(cardID, destination,this);
		}
		
		[RPC]
		void NetEndPhase(){
			gm.EndPhase(this);
		}
		
		[RPC]
		void NetResign(){
			gm.Resign(this);
		}
		
		//**********************************
		// Messages from the ServerGameManager
		// Send message over the network to the NetworkClientGameManager
		
		// Test functions
		public void TestLog(string _data){
			networkView.RPC ("NetTestLog", NetworkManager.Client, _data);
		}
		public void TestWarning(string _data){
			networkView.RPC ("NetTestWarning", NetworkManager.Client, _data);
		}

		/// <summary>
		/// Creates a card.
		/// </summary>
		/// <param name="_cardID">The card database ID.</param>
		/// <param name="_GUID">ID of the card being moved.</param>
		/// <param name="_destination">ID of the card container the card is in.</param>
		public void CreateCard(int _cardID, int _GUID, int _destination){
			string data = string.Empty;
			data += _cardID.ToString () + ";";
			data += _GUID.ToString () + ";";
			data+= _destination.ToString();

			networkView.RPC ("NetCreateCard", NetworkManager.Client, data);
		}

		/// <summary>
		/// Moves the card.
		/// </summary>
		/// <param name="_cardID">ID of the card being moved.</param>
		/// <param name="_source">ID of the container it is moved from.</param>
		/// <param name="_destination">ID of the container it is moved to.</param>
		public void MoveCard (int _cardID, int _source, int _destination){
			string data = string.Empty;
			data+= _cardID.ToString()+";";
			data+= _source.ToString()+";";
			data+= _destination.ToString();
			
			networkView.RPC("NetMoveCard",NetworkManager.Client,data);
			
		}
		
		/// <summary>
		/// Changes the card attribute.
		/// </summary>
		/// <param name="_cardID">ID of the card being changed.</param>
		/// <param name="_attribute">Name of the attribute being changed.</param>
		/// <param name="_value">Value of the change.</param>
		public void ChangeCardAttribute (int _cardID, CardAttribute _attribute, int _value){
			
			string data = string.Empty;
			data+= _cardID.ToString()+";";
			data+= _attribute.ToString()+";";
			data+= _value.ToString();
			
			networkView.RPC("NetChangeCardAttribute",NetworkManager.Client,data);
		
		}
		
		/// <summary>
		/// Changes one of the player's attributes.
		/// </summary>
		/// <param name="_playerID">ID of the player.</param>
		/// <param name="_attribute">Name of the attribute being changed.</param>
		/// <param name="_value">Value change to the player's will.</param>
		public void ChangePlayerAttribute (int _playerID, PlayerAttribute _attribute, int _value){
			
			string data = string.Empty;
			data+= _playerID.ToString()+";";
			data+= _attribute.ToString()+";";
			data+= _value.ToString();
			
			networkView.RPC("NetChangePlayerAttribute",NetworkManager.Client,data);
		
		}
		
		/// <summary>
		/// Ends the game with a winner.
		/// </summary>
		/// <param name="_playerID">ID of the player that wins.</param>
		public void EndGame(int _playerID){
			
			networkView.RPC("NetEndGame",NetworkManager.Client);
		
		}
		//**********************************
		
		//**********************************
		//Junk Network Functions
		[RPC]
		void NetTestLog(string data){
		}
		
		[RPC]
		void NetTestWarning(string data){
		}
		
		//Receivers
		
		[RPC]
		void NetCreateCard(string _info){
		}
		
		[RPC]
		void NetMoveCard(string _info){
		}
		
		[RPC]
		void NetChangeCardAttribute(string _info){
		}
		
		[RPC]
		void NetChangePlayerAttribute(string _info){
		}
		
		[RPC]
		void NetEndGame(int _playerID){
		}
	}
}
