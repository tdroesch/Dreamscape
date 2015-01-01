using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour 
{
	public List<Card> playerCreated = new List<Card>();
    public Deck deck;
	public Hand hand;
	public Position _pos;
	public Amount _amount;
	public SortBy _sort;
	public Card cardPrefab;

	public enum Position
	{
		top = 0,
		middle = 1,
		bottom = 2
	};
	
	public enum Amount 
	{
		one = 1,
		two = 2,
		three = 3,
		four = 4,
		five = 5
	};

	public enum SortBy
	{
		Alphabetically,
		Type
	};

	public enum Target
	{
		Deck,
		Hand,
		Field,
		Subconscious
	};

	void Awake()
	{
		deck = this.gameObject.transform.FindChild("Deck").GetComponent<Deck> ();
		hand = this.gameObject.transform.FindChild ("Hand").GetComponent<Hand> ();
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(20, 20, 170, 20), "Create Fifty Cards")) {
			for(int i = 0; i <= 50; i++) {
				Card card = gameObject.AddComponent<Card>();
				card.Name = "Card " + playerCreated.Count;
				card.iCost = Random.Range (0, 5);
				card.wCost = Random.Range (0, 5);
				playerCreated.Add (card);
			}
		}

		if(GUI.Button(new Rect(20, 40, 170, 20), "Move a Card to the Deck")) {
			deck.AddCard(playerCreated[0]);
			playerCreated.Remove(playerCreated[0]);
		}

		if(GUI.Button(new Rect(20, 60, 170, 20), "Deck to Hand")) {
			// Remove a card off the top of the deck (no special rules applied)
			hand.AddCard(deck.deck[0]);
			deck.RemoveCard(deck.deck[0]);
		}

		if(GUI.Button(new Rect(20, 120, 170, 20), "Set Pos to 'Top'")) {
			_pos = Position.top;
		}
		if(GUI.Button(new Rect(20, 140, 170, 20), "Set Pos to 'Middle'")) {
			_pos = Position.middle;
		}
		if(GUI.Button(new Rect(20, 160, 170, 20), "Set Pos to 'Bottom'")) {
			_pos = Position.bottom;
		}
		if(GUI.Button(new Rect(20, 100, 220, 20), "Hand to Deck w/Position & Amount")) {
			deck.AddCard(CardSelection.selectedCard, _pos, _amount);
			hand.RemoveCard(_pos, _amount);
		}

		if(GUI.Button(new Rect(20, 200, 170, 20), "Set Amount to 1")) {
			_amount = Amount.one;
		}
		if(GUI.Button(new Rect(20, 220, 170, 20), "Set Amount to 2")) {
			_amount = Amount.two;
		}
		if(GUI.Button(new Rect(20, 240, 170, 20), "Set Amount to 5")) {
			_amount = Amount.five;
		}
	}
}