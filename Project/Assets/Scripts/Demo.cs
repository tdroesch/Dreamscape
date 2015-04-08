using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Demo : MonoBehaviour 
{
	public List<Card> playerCreated = new List<Card>();
    public Deck deck;
	public Hand hand;
	public Position _pos;
	public int _amount;
	public SortBy _sort;
	public Target _target;
	public Card cardPrefab;

	public enum Position
	{
		top = 0,
		middle = 1,
		bottom = 2
	};
	
	public enum SortBy
	{
		type = 0,
		iCost = 1,
		wCost = 2
	};

	public enum Target
	{
		deck = 0,
		hand = 1,
		field = 2,
		subconscious = 3
	};

	void Awake()
	{
		deck = this.gameObject.transform.FindChild("Deck").GetComponent<Deck> ();
		hand = this.gameObject.transform.FindChild ("Hand").GetComponent<Hand> ();
	}

	void Start()
	{
		// Setting default values
		_pos = Position.top;
		_amount = 1;
		_sort = SortBy.type;
		_target = Target.field;
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(20, 20, 170, 20), "Create Fifty Cards in Deck")) {
			for(int i = 1; i <= 50; i++) {
				Card card = Instantiate(cardPrefab, transform.position, transform.rotation) as Card;
				card.GetComponent<Card>().Name = "Card " + deck.deck.Count;
				card.name = card.GetComponent<Card>().Name;
				card.GetComponent<Card>().iCost = Random.Range (0, 30);
				card.GetComponent<Card>().wCost = Random.Range (0, 50);
				deck.AddCard (card);

				if (i <= 25) {
					card.GetComponent<Card>().Type = "FIRE";
				} else if (i > 25) {
					card.GetComponent<Card>().Type = "WATER";
				}
			}
		}

		if(GUI.Button (new Rect(20, 40, 170, 20), "Shuffle Cards")) {
			deck.Shuffle();
		}

		if(GUI.Button (new Rect(20, 60, 170, 20), "Sort Cards (type)")) {
			_sort = SortBy.type;
			deck.doSort(_sort);
		}

		if(GUI.Button (new Rect(20, 80, 170, 20), "Sort Cards (iCost)")) {
			_sort = SortBy.iCost;
			deck.doSort(_sort);
		}

		if(GUI.Button (new Rect(20, 100, 170, 20), "Sort Cards (wCost)")) {
			_sort = SortBy.wCost;
			deck.doSort(_sort);
		}

//		if(GUI.Button(new Rect(20, 40, 170, 20), "Card to Deck")) {
//			deck.AddCard(playerCreated[(int)_pos]);
//			playerCreated.Remove(playerCreated[(int)_pos]);
//		}
//
//		if(GUI.Button(new Rect(20, 60, 170, 20), "Deck to Hand")) {
//			// Remove a card off the top of the deck (no special rules applied)
//			if(_amount == 1) {
//				hand.AddCard(deck.deck[(int)_pos]);
//				deck.RemoveCard(deck.deck[(int)_pos]);
//			}
//
//			// Remove a number of cards from
//			if(_amount > 1) {
//				hand.AddCard (deck.deck[(int)_pos], _amount);
//				deck.RemoveCard (deck.deck[(int)_pos], _amount);
//			}
//		}
//	
//		if(GUI.Button(new Rect(20, 120, 170, 20), "Set Pos to 'Top'")) {
//			_pos = Position.top;
//		}
//		if(GUI.Button(new Rect(20, 140, 170, 20), "Set Pos to 'Middle'")) {
//			_pos = Position.middle;
//		}
//		if(GUI.Button(new Rect(20, 160, 170, 20), "Set Pos to 'Bottom'")) {
//			_pos = Position.bottom;
//		}
//
//		if(GUI.Button(new Rect(20, 200, 170, 20), "Set Amount to 1")) {
//			_amount = 1;
//		}
//		if(GUI.Button(new Rect(20, 220, 170, 20), "Set Amount to 2")) {
//			_amount = 2;
//		}
//		if(GUI.Button(new Rect(20, 240, 170, 20), "Set Amount to 3")) {
//			_amount = 3;
//		}
//
//		if(GUI.Button(new Rect(20, 280, 170, 20), "Set target to deck")) {
//			_target = Target.deck;
//		}
//		if(GUI.Button(new Rect(20, 300, 170, 20), "Set target to hand")) {
//			_target = Target.hand;
//		}
//		if(GUI.Button(new Rect(20, 320, 170, 20), "Set target to field")) {
//			_target = Target.field;
//		}
//		if(GUI.Button(new Rect(20, 340, 170, 20), "Set target to subconscious")) {
//			_target = Target.subconscious;
//		}
	}
}