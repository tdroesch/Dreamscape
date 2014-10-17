using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour, ICardContainer 
{
	private Game game;
	private Card cards;
	private int deckCount;

	public GameObject DeckOne;
	public GameObject cardPrefab;

	// create a "deck" of cards
	public List<Card> deck = new List<Card>();

	void Awake()
	{
		game = GameObject.Find ("GameManager").GetComponent<Game>();
	}

	void Start()
	{
		deckCount = 0;
		DeckOne = this.gameObject;
	}

	public void AddCard()
	{
		// add some demo cards to the "table"
		GameObject indCard = Instantiate(cardPrefab, DeckOne.transform.position, Quaternion.identity) as GameObject;
		indCard.name = gameObject.name + "_" + deckCount;
		deckCount += 1;
	}

	public void RemoveCard()
	{

		deckCount -= 1;
	}

	void Update()
	{
		if (game.startGame && deckCount < 30) {
			AddCard();
		}

		// demo
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			RemoveCard();
		}
	}
}