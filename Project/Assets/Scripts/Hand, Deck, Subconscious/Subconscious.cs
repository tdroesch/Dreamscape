using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Subconscious : MonoBehaviour, ICardContainer 
{
	public List<GameObject> subconscious = new List<GameObject> ();

	private Deck deck;
	private Hand hand;
	private Field field;

	void Awake()
	{
		deck = GameObject.FindGameObjectWithTag ("Deck").GetComponent<Deck> ();
		hand = GameObject.FindGameObjectWithTag ("Hand").GetComponent<Hand> ();
		field = GameObject.FindGameObjectWithTag ("Field").GetComponent<Field> ();
	}

	public void AddCard(GameObject _card)
	{
		if(_card != null) {
			_card.transform.position = this.gameObject.transform.position;
			_card.GetComponent<MeshRenderer>().enabled = true;
			
			subconscious.Add(_card);
			_card.transform.parent = this.gameObject.transform;
		}
		
		CardSelection.selectedCard = null;
	}
	
	public void AddCard(GameObject _card, Demo.Position _pos) 
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
	
	public void AddCard(GameObject _card, int _amount) 
	{
		for(int i = 1; i <= (int)_amount; i++) {
//			int pos = 0;
			
			subconscious.Add(_card);
			_card.transform.parent = this.gameObject.transform;
		}
	}
	
	public void RemoveCard(GameObject _card)
	{
		if(_card != null) {
			deck.AddCard(_card);
			subconscious.Remove(_card);
		}
	}

	public void RemoveCard(GameObject _card, int _amount) {
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
	
	public void RemoveCard(GameObject _card, Demo.Position _position, Demo.Target _target)
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
}
