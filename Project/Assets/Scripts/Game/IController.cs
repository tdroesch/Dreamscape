using System.Collections;


namespace Dreamscape
{
	/// <summary>
	/// DEPRICATED
	/// Functionallity built into BaseClientGameManager
	/// Interface for controllers that send commands to the ServerGameManager.
	/// </summary>
	public interface IController {
		//**********************************
		// Messages to the ServerGameManager
		
		/// <summary>
		/// Plays the card.
		/// </summary>
		/// <param name="_GUID">ID of the card being played.</param>
		/// <param name="_targets">The targets of the card.</param>
		/// <param name="_destination">ID of the container it is moved to.</param>
		void PlayCard (int _GUID, int[] _targets, int _destination);
		
		/// <summary>
		/// Uses the card ability.
		/// </summary>
		/// <param name="_GUID">ID of the card being used.</param>
		/// <param name="_abilityID">ID of the ability being used.</param>
		/// <param name="_targets">The targets of the ability.</param>
		void UseCardAbility (int _GUID, int _abilityID, int[] _targets);
		
		/// <summary>
		/// Rearange cards possitions on the board
		/// </summary>
		/// <param name="_GUID">ID of the card being moved.</param>
		/// <param name="_destination">ID of the container it is moved to.</param>
		void MoveCardToField (int _GUID, int _destination);
		
		/// <summary>
		/// Ends the phase.
		/// </summary>
		void EndPhase ();
		//**********************************
	}
}