using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
    public Deck deck;
	public Position _pos;
	public Amount _amount;
	public SortBy _sort;

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
		Alpha,
		Type,
		Cost
	};

	void Awake()
	{
		deck = this.gameObject.transform.FindChild("Deck").GetComponent<Deck>();
	}
  
	void Update()
	{
		// INPUT FOR TESTING PURPOSES
		if (Input.GetKeyDown(KeyCode.A))
		{
			// Add the selected card
			deck.AddCard();
		}
		
		if (Input.GetKeyDown(KeyCode.S))
		{
			// Add card with a selection and position to pull from
			deck.AddCard(CardSelection.selectedCard, _pos);
		}
		
		if(Input.GetKeyDown(KeyCode.D))
		{
			// Add card with a selection, position, and amount of cards to pull
			deck.AddCard(CardSelection.selectedCard, _pos, _amount);
		}
		
		if(Input.GetKeyDown(KeyCode.F))
		{
			// Remove a card off the top of the deck
			deck.RemoveCard();
		}
		
		if(Input.GetKeyDown(KeyCode.G))
		{
			// Remove a card off the top of the deck
			deck.RemoveCard(_pos);
		}
		
		if(Input.GetKeyDown(KeyCode.H))
		{
			// Remove a card off the top of the deck
			deck.RemoveCard(CardSelection.selectedCard);
		}
		
		if(Input.GetKeyDown(KeyCode.J))
		{
			// Remove a card off the top of the deck
			deck.RemoveCard(_pos, _amount);
		}
		
		// TESTING POSITION SELECTION
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			_pos = Position.top;
		}
		
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			_pos = Position.middle;
		}
		
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			_pos = Position.bottom;
		}
	}
}