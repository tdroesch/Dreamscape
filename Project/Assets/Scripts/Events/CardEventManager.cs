using System.Collections;
using System.Collections.Generic;

namespace Dreamscape
{
	/// <summary>
	/// Card event manager.
	/// Handles events and effects related to cards.
	/// One will be attached to each card.
	/// </summary>
	public class CardEventManager {
		/// <summary>
		/// List of all effects that will be triggered.
		/// </summary>
		public List<CardEffect> cardEffects;
		/// <summary>
		/// Delegate outline for the card events.
		/// </summary>
		public delegate void CardEvent (TurnActionData _data);
		/// <summary>
		/// The event types for each card.
		/// </summary>
		public event CardEvent 	Play, Discard, Draw,
								Attack, DealDamage, RecieveDamage,
								ChangeField, AbilityUse;
		// Use this for initialization
		void Start ()
		{
			foreach (CardEffect cardEffect in cardEffects) {
				cardEffect.Effect (this);
			}
		}

		/// <summary>
		/// Raises the attack event.
		/// </summary>
		public void OnAttack (TurnActionData _data)
		{
			Attack (_data);
		}
		/// <summary>
		/// Raises the deal damage event.
		/// </summary>
		public void OnDealDamage (TurnActionData _data)
		{
			DealDamage (_data);
		}
		/// <summary>
		/// Raises the recieve damage event.
		/// </summary>
		public void OnRecieveDamage (TurnActionData _data)
		{
			RecieveDamage (_data);
		}
		/// <summary>
		/// Raises the play event.
		/// </summary>
		public void OnPlay (TurnActionData _data)
		{
			Play (_data);
		}
		/// <summary>
		/// Raises the death event.
		/// </summary>
		public void OnDiscard (TurnActionData _data)
		{
			Discard (_data);
		}
		/// <summary>
		/// Raises the draw event.
		/// </summary>
		public void OnDraw (TurnActionData _data)
		{
			Draw (_data);
		}
		/// <summary>
		/// Raises the change field event.
		/// </summary>
		public void OnChangeField (TurnActionData _data)
		{
			ChangeField (_data);
		}
		/// <summary>
		/// Raises the ability use event.
		/// </summary>
		public void OnAbilityUse (TurnActionData _data)
		{
			AbilityUse (_data);
		}
	}
}
