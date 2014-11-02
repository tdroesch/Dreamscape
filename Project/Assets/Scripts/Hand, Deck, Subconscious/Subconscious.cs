using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Subconscious : MonoBehaviour, ICardContainer 
{
	public string target;

	public List<GameObject> subconscious = new List<GameObject>();

	private Deck deck;
//	private Hand hand;
//	private Field field;
	private Game game;

	void Awake()
	{
		this.gameObject.tag = "Subconscious";
		this.gameObject.name = "SubconsciousOne";
	}

	void Start()
	{
		// For testing purposes, using tags
		deck = GameObject.FindWithTag("Deck").GetComponent<Deck>();
//		hand = GameObject.FindWithTag("Hand").GetComponent<Hand>();
//		field = GameObject.FindWithTag("Field").GetComponent<Field>();
		game = GameObject.FindWithTag("GameManager").GetComponent<Game>();
	}

	void Update()
	{
		if(game.resetGame) {
			// Return the cards in the subconscious to the deck
			target = deck.name;
			foreach(GameObject c in subconscious.ToArray()) {
				RemoveCard(c);
			}
		}
	}

	public void AddCard(GameObject _card)
	{
		// Parent the card under the subconscious
		_card.transform.parent = this.gameObject.transform;
		subconscious.Add (_card);
		ChangeTag(_card);
	}
	
	public void RemoveCard(GameObject _card)
	{
		// Move the card to the target's position
		_card.transform.position = GameObject.Find(target).transform.position;
		GameObject.Find (target).SendMessage("AddCard", _card);
		subconscious.Remove(_card);
	}

	void ChangeTag(GameObject _card)
	{
		_card.tag = "Subconscious";
	}
}