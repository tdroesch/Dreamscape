using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour, ICardContainer
{
	public string target;

	public Game game;
	public GameObject DeckOne;
	public GameObject cardPrefab;
	public int maxCards;
	public bool isFull;
	
	public List<GameObject> deck = new List<GameObject>();

	private Hand hand;

	void Awake()
	{
		this.gameObject.tag = "Deck";
		this.gameObject.name = "DeckOne";

		// For demo purposes, only finds hand by tag
		game = GameObject.Find ("GameManager").GetComponent<Game>();
		hand = GameObject.Find ("Hand").GetComponent<Hand>();
	}

	void Start()
	{
		maxCards = 50;
		isFull = false;

		// For now, setting target to hand
		target = hand.name;
	}

	void Update()
	{
		if(game.startGame && !isFull) {
			Debug.Log ("Creating Deck...");
			// Create the cards at the start of the game
			for(int i = 1; i <= maxCards; i++) {
				GameObject c = GameObject.Instantiate(cardPrefab, transform.position, transform.rotation) as GameObject;
				c.transform.parent = this.gameObject.transform;
				c.tag = "Deck";
				c.name = "Card " + i;
				// Add the cards to the list
				deck.Add (c); 
			}
		}
		
		// Once deck has 50 cards, the deck is full and 5 cards are moved to hand
		if(deck.Count >= 50) {
			isFull = true;
			game.resetGame = false;
			InitialDeal();
		}
	}

	public void AddCard(GameObject _card)
	{
		// Parent the card under the deck
		_card.transform.parent = this.gameObject.transform;
		deck.Add (_card);
		ChangeTag(_card);
	}

	public void RemoveCard(GameObject _card)
	{
		// Move the card to the deck's position
		_card.transform.position = GameObject.Find(target).transform.position;
		GameObject.Find (target).SendMessage("AddCard", _card);
		deck.Remove(_card);
	}

	void ChangeTag(GameObject _card)
	{
		_card.tag = "Deck";
	}

	void InitialDeal()
	{
		// 5 cards are moved to hand off the top of the deck
		for(int i = 1; i <= 5; i++) {
			RemoveCard(GameObject.Find("Card " + i));
		}
	}
}