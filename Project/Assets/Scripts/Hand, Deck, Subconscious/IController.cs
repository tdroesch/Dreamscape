using UnityEngine;
using System.Collections;

/// <summary>
/// Interface for controllers that interact with the game.
/// </summary>
public interface IController 
{
	/// <summary>
	/// Plays the target card.
	/// </summary>
	/// <param name="card">Card.</param>
	void PlayCard(Card card);

	/// <summary>
	/// Uses the card ability.
	/// </summary>
	/// <param name="ability">Ability.</param>
	void UseCardAbility(Ability ability);

	/// <summary>
	/// Ends the turn.
	/// </summary>
	void EndTurn();
}