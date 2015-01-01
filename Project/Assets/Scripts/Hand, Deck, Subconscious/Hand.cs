using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hand : MonoBehaviour, ICardContainer
{
	public List<Card> hand = new List<Card> ();

	public void AddCard(Card _card)
	{
		if(_card != null) {
			_card.transform.position = this.gameObject.transform.position;
			
			hand.Add(_card);
			_card.transform.parent = this.gameObject.transform;
		}
		
		CardSelection.selectedCard = null;
	}

	public void AddCard(Card _card, Player.Position _pos) { }

	public void AddCard(Card _card, Player.Position _pos, Player.Amount _amount)
	{
		for(int i = 1; i <= (int)_amount; i++) {
			int pos = 0;

			hand.Insert(pos, _card);
			_card.transform.parent = this.gameObject.transform;
		}
	}
	
	public void RemoveCard(Card _card)
	{
		// Remove the selected card from the hand to the field
	}

	public void RemoveCard(Player.Position _pos) { }

	public void RemoveCard(Player.Position _pos, Player.Amount _amount) 
	{ 
		int pos = 0;
		
		for(int i = 1; i < (int)_amount; i++) {
			Destroy(hand[pos].gameObject);
			hand.RemoveAt(pos);
		}
	}

	public void RemoveCard(Card _card, Player.Position _pos, Player.Target _target)
	{
		// Remove the selected card and send the card to a different destination than the field, like the subconscious or back into the deck
	}

	void Sort()
	{

	}
}