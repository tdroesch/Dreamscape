using System;


namespace Dreamscape
{
	/// <summary>
	/// Client interface that recieves changes from the ServerGameManager.
	/// </summary>
	public interface IClient {
		//**********************************
		// Messages from the ServerGameManager

		// Test functiosn
		void TestLog(string _data);
		void TestWarning(string _data);

		/// <summary>
		/// Creates a card.
		/// </summary>
		/// <param name="_cardID">The card database ID.</param>
		/// <param name="_GUID">Game ID of the card being created.</param>
		/// <param name="_destination">ID of the card container the card is in.</param>
		void CreateCard(int _cardID, int _GUID, int _destination);

		/// <summary>
		/// Moves the card.
		/// </summary>
		/// <param name="_GUID">ID of the card being moved.</param>
		/// <param name="_source">ID of the container it is moved from.</param>
		/// <param name="_destination">ID of the container it is moved to.</param>
		void MoveCard (int _GUID, int _source, int _destination);
		
		/// <summary>
		/// Changes the card attribute.
		/// </summary>
		/// <param name="_GUID">ID of the card being changed.</param>
		/// <param name="_attribute">Name of the attribute being changed.</param>
		/// <param name="_value">Value of the change.</param>
		void ChangeCardAttribute (int _GUID, CardAttribute _attribute, int _value);

		/// <summary>
		/// Creates a new player in the game.
		/// </summary>
		/// <param name="_charID">The Character Database ID.</param>
		/// <param name="_GUID">Game ID of the player.</param>
		/// <param name="_value">O if this character is of the recieving player.  1 if character is for opponent</param>
		void CreatePlayer (int _charID, int _GUID, int _opponent);
		
		/// <summary>
		/// Changes one of the player's attributes.
		/// </summary>
		/// <param name="_GUID">ID of the player.</param>
		/// <param name="_attribute">Name of the attribute being changed.</param>
		/// <param name="_value">Value change to the player's attribute.</param>
		void ChangePlayerAttribute (int _GUID, PlayerAttribute _attribute, int _value);

		/// <summary>
		/// Ends the game with a winner.
		/// </summary>
		/// <param name="_GUID">ID of the player that wins.</param>
		void EndGame(int _GUID);

		//Need to add function to promp the player for input.

		//**********************************
	}
	
	/// <summary>
	/// Player attribute.
	/// </summary>
	public enum PlayerAttribute {
		Will,
		Imagination,
		Actions,
		Stage,
		Cycle
	}
	
	/// <summary>
	/// Card attribute.
	/// </summary>
	public enum CardAttribute {
		NightmareValue,
		DreamValue,
		CardID
	}
}

