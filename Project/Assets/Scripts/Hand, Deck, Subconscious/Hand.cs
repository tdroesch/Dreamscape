using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hand : MonoBehaviour, ICardContainer
{
	public List<GameObject> hand = new List<GameObject> ();

	private Deck deck;
	private Field field;
	private Subconscious subconscious;

	void Awake()
	{
		deck = GameObject.FindGameObjectWithTag ("Deck").GetComponent<Deck> ();
		field = GameObject.FindGameObjectWithTag ("Field").GetComponent<Field> ();
		subconscious = GameObject.FindGameObjectWithTag ("Subconscious").GetComponent<Subconscious> ();
	}

	public void AddCard(GameObject _card)
	{
		if(_card != null) {
			_card.transform.position = this.gameObject.transform.position;
			_card.GetComponent<MeshRenderer>().enabled = true;
			
			hand.Add(_card);
			_card.transform.parent = this.gameObject.transform;
		}
		
		CardSelection.selectedCard = null;
	}

	public void AddCard(GameObject _card, Player.Position _pos) 
	{ 
	
	}

	public void AddCard(GameObject _card, Player.Position _pos, Player.Amount _amount)
	{
		for(int i = 1; i <= (int)_amount; i++) {
			int pos = 0;

			hand.Insert(pos, _card);
			_card.transform.parent = this.gameObject.transform;
		}
	}
	
	public void RemoveCard(GameObject _card)
	{
		// Removes the selected card from the hand and into the player's field
		if(_card != null) {
			field.AddCard(_card);
			hand.Remove(_card);
		}
	}

	public void RemoveCard(Player.Position _pos, Player.Amount _amount) 
	{ 
		int pos = 0;
		
		for(int i = 1; i < (int)_amount; i++) {
			Destroy(hand[pos].gameObject);
			hand.RemoveAt(pos);
		}
	}

	public void RemoveCard(GameObject _card, Player.Position _position, Player.Target _target)
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