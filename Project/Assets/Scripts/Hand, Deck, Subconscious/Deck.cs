using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour, ICardContainer 
{
	private Game game;
	private Card card;
	private int cardCount;
	
	public GameObject cardPrefab; // For demo testing
	public List<Card> deckOne = new List<Card>();

	void Awake()
	{
		game = GameObject.Find ("GameManager").GetComponent<Game>();
		card = GameObject.Find ("GameManager").GetComponent<Card> ();
	}

	void Start()
	{
		cardCount = 0;

		// Get how many decks are on the table 
		GameObject[] numofdecks = GameObject.FindGameObjectsWithTag ("Deck");
		this.gameObject.tag = "Deck";
		this.gameObject.name = "Deck " + numofdecks.Length;
	}

	void Update()
	{
		// Start of game - deal cards to both decks
		if (game.startGame) {

		}
	}

	public void AddCard()
	{
		cardCount += 1;
	}

	public void RemoveCard()
	{

	}
}