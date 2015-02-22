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
		//**********************************
	}
}

