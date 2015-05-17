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
		
		//***********************************************
		//Network messages
		
		[RPC]
		void NetInitClient(){
			gm.InitClient(new int[40], new int[6], 2000, 250, this);
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
		// IClient implementation
		// Messages from the ServerGameManager
		// Send message over the network to the NetworkClientGameManager
		
		/// <summary>
		/// Creates a card.
		/// </summary>
		/// <param name="_cardID">The card database ID.</param>
		/// <param name="_GUID">ID of the card being moved.</param>
		/// <param name="_destination">ID of the card container the card is in.</param>
		public void CreateCard(int _cardID, int _GUID, int _destination){}

		
		/// <summary>
		/// Moves the card.
		/// </summary>
		/// <param name="_GUID">ID of the card being moved.</param>
		/// <param name="_source">ID of the container it is moved from.</param>
		/// <param name="_destination">ID of the container it is moved to.</param>
		public void MoveCard (int _GUID, int _source, int _destination){}
		
		/// <summary>
		/// Changes the card attribute.
		/// </summary>
		/// <param name="_GUID">ID of the card being changed.</param>
		/// <param name="_attribute">Name of the attribute being changed.</param>
		/// <param name="_value">Value of the change.</param>
		public void ChangeCardAttribute (int _GUID, CardAttribute _attribute, int _value){}
		
		/// <summary>
		/// Changes one of the player's attributes.
		/// </summary>
		/// <param name="_GUID">ID of the player.</param>
		/// <param name="_attribute">Name of the attribute being changed.</param>
		/// <param name="_value">Value change to the player's will.</param>
		public void ChangePlayerAttribute (int _GUID, PlayerAttribute _attribute, int _value){}
		
		/// <summary>
		/// Ends the game with a winner.
		/// </summary>
		/// <param name="_GUID">ID of the player that wins.</param>
		public void EndGame(int _GUID){}
		//**********************************
	}
}
