using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardEventManager : MonoBehaviour {
	public List<CardEffect> cardEffects;
	public delegate void CardEvent();
	public event CardEvent 	TurnStart, TurnEnd,
							Attack, DealDamage, RecieveDamage,
							Play, Death,
							AbilityUse;
	// Use this for initialization
	void Start () {
		foreach (CardEffect cardEffect in cardEffects) {
			cardEffect.RegisterEffects(this);
		}
	}
	
	public void OnTurnStart(){
		TurnStart();
	}
	public void OnTurnEnd(){
		TurnEnd();
	}
	public void OnAttack(){
		Attack();
	}
	public void OnDealDamage(){
		DealDamage();
	}
	public void OnRecieveDamage(){
		RecieveDamage();
	}
	public void OnPlay(){
		Play();
	}
	public void OnDeath(){
		Death();
	}
	public void OnAbilityUse(){
		AbilityUse();
	}
}
