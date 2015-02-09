using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hand : MonoBehaviour, ICardContainer
{
	public List<Card> hand = new List<Card> ();

	private Deck deck;
	private Field field;
	private Subconscious subconscious;

	void Awake()
	{
		deck = GameObject.FindGameObjectWithTag ("Deck").GetComponent<Deck> ();
		field = GameObject.FindGameObjectWithTag ("Field").GetComponent<Field> ();
		subconscious = GameObject.FindGameObjectWithTag ("Subconscious").GetComponent<Subconscious> ();
	}

	public void AddCard(Card _card)
	{
		if(_card != null) {
			_card.transform.position = this.gameObject.transform.position;
			_card.GetComponent<MeshRenderer>().enabled = true;
			
			hand.Add(_card);
			_card.transform.parent = this.gameObject.transform;
		}
		
		CardSelection.selectedCard = null;
	}

	public void AddCard(Card _card, Demo.Position _pos) 
	{ 
		int pos = (int)_pos;
		Debug.Log(_pos);
		
		if((int)_pos == 0) {
			pos = 0;
		}
		
		if((int)_pos == 1) {
			pos = hand.Count / 2;
		}
		
		if((int)_pos == 2) {
			pos = hand.Count;
		}

		if(_card != null) {
			field.AddCard(_card);
			hand.RemoveAt(pos);
		}
	}

	public void AddCard(Card _card, int _amount)
	{
		for(int i = 1; i <= (int)_amount; i++) {
//			int pos = (int)_pos;

			hand.Add(_card);
			_card.transform.position = this.gameObject.transform.position;
			_card.GetComponent<MeshRenderer>().enabled = true;
			_card.transform.parent = this.gameObject.transform;
		}
	}
	
	public void RemoveCard(Card _card)
	{
		// Removes the selected card from the hand and into the player's field
		if(_card != null) {
			field.AddCard(_card);
			hand.Remove(_card);
		}
	}

	public void RemoveCard(Card _card, int _amount) {
		for (int i = 1; i <= _amount; i++) {
			hand.Remove (_card);
		}
	}

	public void RemoveCard(Demo.Position _pos, int _amount) 
	{ 
		int pos = 0;
		
		for(int i = 1; i < (int)_amount; i++) {
			Destroy(hand[pos].gameObject);
			hand.RemoveAt(pos);
		}
	}

	public void RemoveCard(Card _card, Demo.Position _position, Demo.Target _target)
	{
		if((int)_target == 0) {
			deck.AddCard(_card);
			hand.Remove (_card);
		}
		if((int)_target == 2) {
			field.AddCard(_card);
			hand.Remove(_card);
		}
		if((int)_target == 3) {
			subconscious.AddCard(_card);
			hand.Remove(_card);
		}
	}

	void Sort()
	{

	}
}