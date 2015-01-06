using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour 
{
	public List<GameObject> playerCreated = new List<GameObject>();
    public Deck deck;
	public Hand hand;
	public Position _pos;
	public Amount _amount;
	public SortBy _sort;
	public Target _target;
	public GameObject cardPrefab;

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
		alphabetically = 0,
		type = 1
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
		_amount = Amount.one;
		_sort = SortBy.type;
		_target = Target.field;
	}

	void OnGUI()
	{
		if(GUI.Button(new Rect(20, 20, 170, 20), "Create Fifty Cards")) {
			for(int i = 0; i <= 50; i++) {
//				Card card = gameObject.AddComponent<Card>();
				GameObject card = Instantiate(cardPrefab, transform.position, transform.rotation) as GameObject;
				card.GetComponent<MeshRenderer>().enabled = false;
				card.GetComponent<Card>().Name = "Card " + playerCreated.Count;
				card.GetComponent<Card>().iCost = Random.Range (0, 5);
				card.GetComponent<Card>().wCost = Random.Range (0, 5);
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

		if(GUI.Button(new Rect(20, 280, 170, 20), "Set target to deck")) {
			_target = Target.deck;
		}
		if(GUI.Button(new Rect(20, 300, 170, 20), "Set target to hand")) {
			_target = Target.hand;
		}
		if(GUI.Button(new Rect(20, 320, 170, 20), "Set target to field")) {
			_target = Target.field;
		}
		if(GUI.Button(new Rect(20, 340, 170, 20), "Set target to subconscious")) {
			_target = Target.subconscious;
		}
	}
}