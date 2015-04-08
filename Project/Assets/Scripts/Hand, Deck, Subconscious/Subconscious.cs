using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Subconscious : MonoBehaviour, ICardContainer 
{
	public List<Card> subconscious = new List<Card> ();

	private Deck deck;
	private Hand hand;
	private Field field;

	void Awake()
	{
		deck = GameObject.FindGameObjectWithTag ("Deck").GetComponent<Deck> ();
		hand = GameObject.FindGameObjectWithTag ("Hand").GetComponent<Hand> ();
		field = GameObject.FindGameObjectWithTag ("Field").GetComponent<Field> ();
	}

	public void AddCard(Card _card)
	{
		if(_card != null) {
			_card.transform.position = this.gameObject.transform.position;
			_card.GetComponent<MeshRenderer>().enabled = true;
			
			subconscious.Add(_card);
			_card.transform.parent = this.gameObject.transform;
		}
		
		CardSelection.selectedCard = null;
	}
	
	public void AddCard(Card _card, Demo.Position _pos) 
	{ 
		int pos = 0;
		Debug.Log(_pos);
		
		if((int)_pos == 0) {
			pos = 0;
		}
		
		if((int)_pos == 1) {
			pos = subconscious.Count / 2;
		}
		
		if((int)_pos == 2) {
			pos = subconscious.Count;
		}
		
		if(_card != null) {
			deck.AddCard(_card);
			subconscious.RemoveAt(pos);
		}
	} 
	
	public void AddCard(Card _card, int _amount) 
	{
		for(int i = 1; i <= (int)_amount; i++) {
//			int pos = 0;
			
			subconscious.Add(_card);
			_card.transform.parent = this.gameObject.transform;
		}
	}
	
	public void RemoveCard(Card _card)
	{
		if(_card != null) {
			deck.AddCard(_card);
			subconscious.Remove(_card);
		}
	}

	public void RemoveCard(Card _card, int _amount) {
		for (int i = 0; i <= _amount; i++) {
			subconscious.Remove (_card);
		}
	}

	public void RemoveCard(Demo.Position _pos, int _amount)
	{
		int pos = 0;
		
		for(int i = 1; i < (int)_amount; i++) {
			Destroy(subconscious[pos].gameObject);
			subconscious.RemoveAt(pos);
		}
	}
	
	public void RemoveCard(Card _card, Demo.Position _position, Demo.Target _target)
	{
		if((int)_target == 0) {
			deck.AddCard(_card);
			subconscious.Remove (_card);
		}
		if((int)_target == 1) {
			hand.AddCard(_card);
			subconscious.Remove(_card);
		}
		if((int)_target == 2) {
			field.AddCard(_card);
			subconscious.Remove(_card);
		}
	}

	public void Shuffle()
	{
		for (int i = 0; i < subconscious.Count; i++) {
			int rand = i + (int)(Random.value * (subconscious.Count - i));
			
			Card temp = null;
			temp = subconscious[rand];
			subconscious[rand] = subconscious[i];
			subconscious[i] = temp;
		}
	}

	public void Sort(Demo.SortBy _category)
	{
		switch (_category) {
			case (Demo.SortBy.type):
				SortByType ();
				break;
			case (Demo.SortBy.iCost):
				SortByICost ();	
				break;
			case (Demo.SortBy.wCost):
				SortByWCost();
				break;
		}
	}
	
	private void SortByType()
	{
		for (int i = 1; i < subconscious.Count; i++) {
			Card currentCard = subconscious[i];
			string cardType = currentCard.GetComponent<Card>().Type;
			int index = i - 1;
			
			while((index > -1) && (subconscious[index].GetComponent<Card>().Type != cardType)) {
				subconscious[index+1] = subconscious[index];
				index = index - 1;
			}
			
			subconscious[index+1] = currentCard;
		}
	}
	
	private void SortByICost()
	{
		for (int i = 1; i < subconscious.Count; i++) {
			Card currentCard = subconscious[i];
			int cardValue = currentCard.GetComponent<Card>().iCost;
			int index = i - 1;
			
			while ((index > -1) && (subconscious[index].GetComponent<Card>().iCost > cardValue)) {
				subconscious[index+1] = subconscious[index];
				index = index - 1;
			}
			
			subconscious[index+1] = currentCard;
		}
	}
	
	private void SortByWCost()
	{
		for (int i = 1; i < subconscious.Count; i++) {
			Card currentCard = subconscious[i];
			int cardValue = currentCard.GetComponent<Card>().wCost;
			int index = i - 1;
			
			while ((index > -1) && (subconscious[index].GetComponent<Card>().wCost > cardValue)) {
				subconscious[index+1] = subconscious[index];
				index = index - 1;
			}
			
			subconscious[index+1] = currentCard;
		}
	}
}
