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
		public delegate void GameEvent (TurnActionData _data);
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
		public void OnTurnStart (TurnActionData _data)
		{
			TurnStart (_data);
		}
		/// <summary>
		/// Raises the turn end event.
		/// </summary>
		public void OnTurnEnd (TurnActionData _data)
		{
			TurnEnd (_data);
		}
		/// <summary>
		/// Raises the phase change event.
		/// </summary>
		public void OnPhaseChange (TurnActionData _data)
		{
			PhaseChange (_data);
		}
		/// <summary>
		/// Raises the attack event.
		/// </summary>
		public void OnCardAttack (TurnActionData _data)
		{
			CardAttack (_data);
		}
		/// <summary>
		/// Raises the deal damage event.
		/// </summary>
		public void OnCardDealDamage (TurnActionData _data)
		{
			CardDealDamage (_data);
		}
		/// <summary>
		/// Raises the recieve damage event.
		/// </summary>
		public void OnCardRecieveDamage (TurnActionData _data)
		{
			CardRecieveDamage (_data);
		}
		/// <summary>
		/// Raises the play event.
		/// </summary>
		public void OnCardPlay (TurnActionData _data)
		{
			CardPlay (_data);
		}
		/// <summary>
		/// Raises the death event.
		/// </summary>
		public void OnCardDiscard (TurnActionData _data)
		{
			CardDiscard (_data);
		}
		/// <summary>
		/// Raises the draw event.
		/// </summary>
		public void OnCardDraw (TurnActionData _data)
		{
			CardDraw (_data);
		}
		/// <summary>
		/// Raises the change field event.
		/// </summary>
		public void OnCardChangeField (TurnActionData _data)
		{
			CardChangeField (_data);
		}
		/// <summary>
		/// Raises the ability use event.
		/// </summary>
		public void OnCardAbilityUse (TurnActionData _data)
		{
			CardAbilityUse (_data);
		}
	}
}
