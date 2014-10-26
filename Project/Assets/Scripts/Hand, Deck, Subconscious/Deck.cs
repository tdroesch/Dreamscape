using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour, ICardContainer
{
	public Game game;
	public GameObject DeckOne;
	public GameObject cardPrefab;
	public int deckCount;
	public bool isFull;
	
	public List<GameObject> deck = new List<GameObject>();

	private Hand hand;
	private Card card;

	void Awake()
	{
		game = GameObject.Find ("GameManager").GetComponent<Game>();
		hand = GameObject.Find ("Hand").GetComponent<Hand>();
		card = GameObject.Find ("GameManager").GetComponent<Card> ();
	}

	void Start()
	{
		deckCount = 0;
		isFull = false;
		this.gameObject.tag = "Deck";
	}

	public void AddCard()
	{
		for(int i = 1; i <= 50; i++) {
			GameObject c = GameObject.Instantiate(cardPrefab, transform.position, transform.rotation) as GameObject;
			c.name = "Card " + i;
			deck.Add (c);
			deckCount += 1;
		}
	}

	public void RemoveCard()
	{
		int topCard = deckCount;

		Debug.Log ("Removing card off the top of the deck...");
		MoveCardToHand(topCard);

		deck.RemoveAt(deckCount);
	}

	void MoveCardToHand(int _topCard)
	{
		GameObject c = GameObject.Find ("Card " + _topCard);
		c.transform.Translate(Vector3.forward * 150 * Time.deltaTime); // TEST

		hand.SendMessage("AddCard");
		deckCount -= 1;
	}

	void InitialDeal()
	{
		// 5 cards are moved to hand off the top of the deck
		for(int i = 1; i <= 5; i++) {
			RemoveCard();
		}
	}

	void Update()
	{
		if(game.startGame && !isFull) {
			Debug.Log ("Creating Deck...");
			AddCard();
		}

		// Once deck has 50 cards, the deck is full and 5 cards are moved to hand
		if(deckCount >= 50) {
			isFull = true;
			InitialDeal();
		}
	}
}