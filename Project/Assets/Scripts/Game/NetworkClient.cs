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
			gm.InitClient(this);
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
			
			networkView.RPC("NetMoveCard",RPCMode.Server,data);
			
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
			
			networkView.RPC("NetChangeCardAttribute",RPCMode.Server,data);
		
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
			
			networkView.RPC("NetChangePlayerAttribute",RPCMode.Server,data);
		
		}
		
		/// <summary>
		/// Ends the game with a winner.
		/// </summary>
		/// <param name="_playerID">ID of the player that wins.</param>
		public void EndGame(int _playerID){
			
			networkView.RPC("NetEndGame",RPCMode.Server);
		
		}
		//**********************************
	}
}
