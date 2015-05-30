using System.Collections;
using System.Collections.Generic;

namespace Dreamscape
{
	/// <summary>
	/// Card event manager.
	/// Handles events and effects related to cards.
	/// One will be attached to each card.
	/// </summary>
	public class GameEventManager {
		/// <summary>
		/// List of all effects that will be triggered.
		/// </summary>
//		public List<CardEffect> cardEffects;
		/// <summary>
		/// Delegate outline for the card events.
		/// </summary>
		public delegate void GameEvent (int _playerGUID, int _componentGUID);
		/// <summary>
		/// The event types for each card.
		/// </summary>
		public event GameEvent 	TurnStart, TurnEnd,	PhaseChange,
								CardAttack, CardDealDamage, CardRecieveDamage,
								CardPlay, CardDiscard, CardDraw,
								CardChangeField, CardAbilityUse;

		// Use this for initialization
//		void Start ()
//		{
//			foreach (CardEffect cardEffect in cardEffects) {
//				cardEffect.RegisterEffects (this);
//			}
//		}
		/// <summary>
		/// Raises the turn start event.
		/// </summary>
		public void OnTurnStart ()
		{
			TurnStart ();
		}
		/// <summary>
		/// Raises the turn end event.
		/// </summary>
		public void OnTurnEnd ()
		{
			TurnEnd ();
		}
		/// <summary>
		/// Raises the phase change event.
		/// </summary>
		public void OnPhaseChange ()
		{
			PhaseChange ();
		}
		/// <summary>
		/// Raises the attack event.
		/// </summary>
		public void OnCardAttack ()
		{
			CardAttack ();
		}
		/// <summary>
		/// Raises the deal damage event.
		/// </summary>
		public void OnCardDealDamage ()
		{
			CardDealDamage ();
		}
		/// <summary>
		/// Raises the recieve damage event.
		/// </summary>
		public void OnCardRecieveDamage ()
		{
			CardRecieveDamage ();
		}
		/// <summary>
		/// Raises the play event.
		/// </summary>
		public void OnCardPlay ()
		{
			CardPlay ();
		}
		/// <summary>
		/// Raises the death event.
		/// </summary>
		public void OnCardDiscard ()
		{
			CardDiscard ();
		}
		/// <summary>
		/// Raises the draw event.
		/// </summary>
		public void OnCardDraw ()
		{
			CardDraw ();
		}
		/// <summary>
		/// Raises the change field event.
		/// </summary>
		public void OnCardChangeField ()
		{
			CardChangeField ();
		}
		/// <summary>
		/// Raises the ability use event.
		/// </summary>
		public void OnCardAbilityUse ()
		{
			CardAbilityUse ();
		}
	}
}
