using UnityEngine;
using System.Collections;

namespace Dreamscape
{
	/// <summary>
	/// Sends messages to the network controller
	/// </summary>
	public class NetworkClient : MonoBehaviour, IClient {
	
		// Use this for initialization
		void Start ()
		{
		
		}
		
		// Update is called once per frame
		void Update ()
		{
		
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
		public void MoveCard (int _cardID, int _source, int _destination){}
		
		/// <summary>
		/// Changes the card attribute.
		/// </summary>
		/// <param name="_cardID">ID of the card being changed.</param>
		/// <param name="_attribute">Name of the attribute being changed.</param>
		/// <param name="_value">Value of the change.</param>
		public void ChangeCardAttribute (int _cardID, string _attribute, int _value){}
		
		/// <summary>
		/// Changes the player's will.
		/// </summary>
		/// <param name="_playerID">ID of the player.</param>
		/// <param name="_value">Value change to the player's will.</param>
		public void ChangePlayerWill (int _playerID, int _value){}
		
		/// <summary>
		/// Changes the player's imagination.
		/// </summary>
		/// <param name="_playerID">ID of the player.</param>
		/// <param name="_value">Value change to the player's imagination.</param>
		public void ChangePlayerImagination (int _playerID, int _value){}
		
		/// <summary>
		/// Ends the game with a winner.
		/// </summary>
		/// <param name="_playerID">ID of the player that wins.</param>
		public void EndGame(int _playerID){}
		//**********************************
	}
}
