using UnityEngine;
using System;

namespace Dreamscape
{
	/// <summary>
	/// Abstarct Base Class for managing clientside gameobjects.
	/// </summary>
	public abstract class BaseClientGameManager : MonoBehaviour {
		// Write functions to move, create, destroy, and modify game objects in the scene.


		//**********************************
		// Messages to the ServerGameManager
		
		
		/// <summary>
		/// Initialize a client in the state machine.
		/// </summary>
		/// <param name="_player">The player being initialized.</param>
		public abstract void InitClient ();

		/// <summary>
		/// Plays the card.
		/// </summary>
		/// <param name="_cardID">ID of the card being played.</param>
		/// <param name="_targets">The targets of the card.</param>
		/// <param name="_destination">ID of the container it is moved to.</param>
		public abstract void PlayCard (int _cardID, int[] _targets, int _destination);
		
		/// <summary>
		/// Uses the card ability.
		/// </summary>
		/// <param name="_cardID">ID of the card being used.</param>
		/// <param name="_abilityID">ID of the ability being used.</param>
		/// <param name="_targets">The targets of the ability.</param>
		public abstract void UseCardAbility (int _cardID, int _abilityID, int[] _targets);
		
		/// <summary>
		/// Rearange cards possitions on the board
		/// </summary>
		/// <param name="_cardID">ID of the card being moved.</param>
		/// <param name="_destination">ID of the container it is moved to.</param>
		public abstract void MoveCardToField (int _cardID, int _destination);
		
		/// <summary>
		/// Ends the phase.
		/// </summary>
		public abstract void EndPhase ();
		
		/// <summary>
		/// Resign the specified _player.
		/// </summary>
		/// <param name="_player">Player who requested the command.</param>
		public abstract void Resign ();
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
		DreamValue
	}
}

