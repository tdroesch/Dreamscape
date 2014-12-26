using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Card event manager.
/// Handles events and effects related to cards.
/// One will be attached to each card.
/// </summary>
public class CardEventManager : MonoBehaviour {
	/// <summary>
	/// List of all effects that will be triggered.
	/// </summary>
	public List<CardEffect> cardEffects;
	/// <summary>
	/// Delegate outline for the card events.
	/// </summary>
	public delegate void CardEvent();
	/// <summary>
	/// The event types for each card.
	/// </summary>
	public event CardEvent 	TurnStart, TurnEnd, OpponentStart, OpponentEnd,
							Attack, DealDamage, RecieveDamage,
							Play, Discard, Draw,
							AllyCardPlay, OpponentCardPlay, ChangeField,
							AbilityUse;
	// Use this for initialization
	void Start () {
		foreach (CardEffect cardEffect in cardEffects) {
			cardEffect.RegisterEffects(this);
		}
	}
	/// <summary>
	/// Raises the turn start event.
	/// </summary>
	public void OnTurnStart(){
		TurnStart();
	}
	/// <summary>
	/// Raises the turn end event.
	/// </summary>
	public void OnTurnEnd(){
		TurnEnd();
	}
	/// <summary>
	/// Raises the opponent start event.
	/// </summary>
	public void OnOpponentStart(){
		OpponentStart();
	}
	/// <summary>
	/// Raises the opponent end event.
	/// </summary>
	public void OnOpponentEnd(){
		OpponentEnd();
	}
	/// <summary>
	/// Raises the attack event.
	/// </summary>
	public void OnAttack(){
		Attack();
	}
	/// <summary>
	/// Raises the deal damage event.
	/// </summary>
	public void OnDealDamage(){
		DealDamage();
	}
	/// <summary>
	/// Raises the recieve damage event.
	/// </summary>
	public void OnRecieveDamage(){
		RecieveDamage();
	}
	/// <summary>
	/// Raises the play event.
	/// </summary>
	public void OnPlay(){
		Play();
	}
	/// <summary>
	/// Raises the death event.
	/// </summary>
	public void OnDiscard(){
		Discard();
	}
	/// <summary>
	/// Raises the draw event.
	/// </summary>
	public void OnDraw(){
		Draw();
	}
	/// <summary>
	/// Raises the ally card play event.
	/// </summary>
	public void OnAllyCardPlay(){
		AllyCardPlay();
	}
	/// <summary>
	/// Raises the opponent card play event.
	/// </summary>
	public void OnOpponentCardPlay(){
		OpponentCardPlay();
	}
	/// <summary>
	/// Raises the change field event.
	/// </summary>
	public void OnChangeField(){
		ChangeField();
	}
	/// <summary>
	/// Raises the ability use event.
	/// </summary>
	public void OnAbilityUse(){
		AbilityUse();
	}
}
