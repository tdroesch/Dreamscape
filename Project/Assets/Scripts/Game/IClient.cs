using System;


namespace Dreamscape
{
	/// <summary>
	/// Client interface that recieves changes from the ServerGameManager.
	/// </summary>
	public interface IClient {
		//**********************************
		// Messages from the ServerGameManager
		
		/// <summary>
		/// Moves the card.
		/// </summary>
		/// <param name="_cardID">ID of the card being moved.</param>
		/// <param name="_source">ID of the container it is moved from.</param>
		/// <param name="_destination">ID of the container it is moved to.</param>
		void MoveCard (int _cardID, int _source, int _destination);
		
		/// <summary>
		/// Changes the card attribute.
		/// </summary>
		/// <param name="_cardID">ID of the card being changed.</param>
		/// <param name="_attribute">Name of the attribute being changed.</param>
		/// <param name="_value">Value of the change.</param>
		void ChangeCardAttribute (int _cardID, CardAttribute _attribute, int _value);
		
		/// <summary>
		/// Changes one of the player's attributes.
		/// </summary>
		/// <param name="_playerID">ID of the player.</param>
		/// <param name="_attribute">Name of the attribute being changed.</param>
		/// <param name="_value">Value change to the player's will.</param>
		void ChangePlayerAttribute (int _playerID, PlayerAttribute _attribute, int _value);

		/// <summary>
		/// Ends the game with a winner.
		/// </summary>
		/// <param name="_playerID">ID of the player that wins.</param>
		void EndGame(int _playerID);

		//Need to add function to promp the player for input.

		//**********************************
	}
}

