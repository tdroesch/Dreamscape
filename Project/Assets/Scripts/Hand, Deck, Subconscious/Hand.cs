using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hand : MonoBehaviour, ICardContainer 
{
	public string target;

	public List <GameObject> hand = new List<GameObject>();
	private Deck deck;
	private Field field;
	private Game game;

	void Awake()
	{
		this.gameObject.tag = "Hand";
		this.gameObject.name = "HandOne";
	}

	void Start()
	{
		// For demo purposes, only finds field by tag
		deck = GameObject.FindWithTag("Deck").GetComponent<Deck>();
		field = GameObject.FindWithTag ("Field").GetComponent<Field>();
		game = GameObject.FindWithTag("GameManager").GetComponent<Game>();

		// For now, setting target to field
		target = field.name;
	}

	void Update()
	{
		if(game.resetGame) {
			Debug.Log ("Hand to deck");
			// Return the cards in the hand to the deck
			target = deck.name;
			foreach(GameObject c in hand.ToArray()) {
				if(hand.Count != 0) {
					RemoveCard(c);
				}
			}
		}

		// Reset the target
		target = field.name;
	}

	public void AddCard(GameObject _card)
	{
		// Changing the parent of the card from deck to hand
		_card.transform.parent = this.gameObject.transform;
		// Changing the cards tag from deck to hand
		hand.Add (_card);
		ChangeTag(_card);
	}
		
	public void RemoveCard(GameObject _card)
	{
		// Move the card to the target's position
		_card.transform.position = GameObject.Find(target).transform.position;
		GameObject.Find (target).SendMessage("AddCard", _card);
		hand.Remove(_card);
	}

	void ChangeTag(GameObject _card)
	{
		_card.tag = "Hand";
	}
}