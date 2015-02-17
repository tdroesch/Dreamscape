using UnityEngine;
using System.Collections;

/// <summary>
/// Interface for controllers that interact with the game.
/// </summary>
namespace Dreamscape
{
	public interface IController {
		/// <summary>
		/// Plays the target card.
		/// </summary>
		/// <param name="_card">Card.</param>
		void PlayCard (Card _card);
	
		/// <summary>
		/// Uses the card ability.
		/// </summary>
		/// <param name="_ability">Ability.</param>
		void UseCardAbility (Ability _ability);

		/// <summary>
		/// Rearange cards possitions on the board
		/// </summary>
		/// <param name="_card">Card.</param>
		/// <param name="_field">Field.</param>
		void MoveCardToField (Card _card, Field _field);
	
		/// <summary>
		/// Ends the turn.
		/// </summary>
		void EndTurn ();
	}
}