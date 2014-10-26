using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour, ICardContainer
{
<<<<<<< HEAD
	public Game game;
	public GameObject DeckOne;
	public GameObject cardPrefab;
	public int deckCount;
	public bool isFull;
	
	public List<GameObject> deck = new List<GameObject>();

	private Hand hand;
=======
	private Game game;
	private Card card;
	private int cardCount;
	
	public GameObject cardPrefab; // For demo testing
	public List<Card> deckOne = new List<Card>();
>>>>>>> origin/Dori

	void Awake()
	{
		game = GameObject.Find ("GameManager").GetComponent<Game>();
<<<<<<< HEAD
		hand = GameObject.Find ("Hand").GetComponent<Hand>();
=======
		card = GameObject.Find ("GameManager").GetComponent<Card> ();
>>>>>>> origin/Dori
	}

	void Start()
	{
<<<<<<< HEAD
		deckCount = 0;
		isFull = false;
=======
		cardCount = 0;

		// Get how many decks are on the table 
		GameObject[] numofdecks = GameObject.FindGameObjectsWithTag ("Deck");
		this.gameObject.tag = "Deck";
		this.gameObject.name = "Deck " + numofdecks.Length;
>>>>>>> origin/Dori
	}

	void Update()
	{
<<<<<<< HEAD
		for(int i = 1; i <= 50; i++) {
			GameObject c = GameObject.Instantiate(cardPrefab, transform.position, transform.rotation) as GameObject;
			c.name = "Card " + i;
			deck.Add (c);
			deckCount += 1;
=======
		// Start of game - deal cards to both decks
		if (game.startGame) {

>>>>>>> origin/Dori
		}
	}

	public void AddCard()
	{
<<<<<<< HEAD
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
=======
		cardCount += 1;
	}

	public void RemoveCard()
	{

>>>>>>> origin/Dori
	}
}