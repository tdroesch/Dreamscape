using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour, ICardContainer
{
	public Card cardPrefab;
	public List<Card> deck = new List<Card>();

	// Add a card to the top of the deck 
	public void AddCard()
    {
		Card card = Instantiate(cardPrefab, transform.position, transform.rotation) as Card;

        deck.Add(card);
		card.GetComponent<Card>().Name = "Test Card " + deck.Count;
		card.transform.parent = this.gameObject.transform;
    }

	// Add a selected card to the top, middle, or bottom of the deck
	public void AddCard(Card _card, Player.Position _pos)
    {
		Card card = Instantiate(cardPrefab, transform.position, transform.rotation) as Card;
		int pos = 0;
        Debug.Log(_pos);

		if((int)_pos == 0) {
			pos = (deck.Count - deck.Count);
		}

		if((int)_pos == 1) {
			pos = deck.Count / 2;
		}

		if((int)_pos == 2) {
			pos = deck.Count;
		}
      
        deck.Insert(pos, card);
		card.GetComponent<Card>().Name = "Test Card " + deck.Count;
		card.transform.parent = this.gameObject.transform;
        Debug.Log (card.Name + " has been added at the " + pos + " position");
    }

	// Add an amount of cards at the top, middle, or bottom of the deck
	public void AddCard(Card _card, Player.Position _pos, Player.Amount _amount)
    {
		for(int i = 1; i <= (int)_amount; i++) {
			Card card = Instantiate(cardPrefab, transform.position, transform.rotation) as Card;

			int pos = 0;
			Debug.Log(_pos);
			
			if((int)_pos == 0) {
				pos = (deck.Count - deck.Count);
			}
			
			if((int)_pos == 1) {
				pos = deck.Count / 2;
			}
			
			if((int)_pos == 2) {
				pos = deck.Count;
			}

			deck.Insert(pos, card);
			card.GetComponent<Card>().Name = "Test Card " + deck.Count;
			card.transform.parent = this.gameObject.transform;
		}
    }

	// Remove a card from the top of the deck
    public void RemoveCard()
    {
		if((deck.Count) != 0) {
			Destroy(deck[deck.Count - 1].gameObject);
			deck.RemoveAt (deck.Count - 1);
		}
    }

	// Remove a card from the top, middle, or bottom of the deck
	public void RemoveCard(Player.Position _pos) 
	{
		int pos = 0;
		Debug.Log(_pos);
		
		if((int)_pos == 0) {
			pos = (deck.Count - deck.Count);
		}
		
		if((int)_pos == 1) {
			pos = deck.Count / 2;
		}
		
		if((int)_pos == 2) {
			pos = deck.Count;
		}

		Destroy(deck[pos].gameObject);
		deck.RemoveAt ((int)_pos);
	}

	// Remove the selected card (_data sent from CardSelection script)
	public void RemoveCard(Card _data)
	{
		Destroy(_data.gameObject);
		deck.Remove(_data);
	}

	// Remove a number of cards from the top, middle, or bottom of the deck
	public void RemoveCard(Player.Position _pos, Player.Amount _amount)
	{
		int pos = 0;

		for(int i = 1; i < (int)_amount; i++) {
			if((int)_pos == 0) {
				pos = (deck.Count - deck.Count);
			}
			
			if((int)_pos == 1) {
				pos = deck.Count / 2;
			}
			
			if((int)_pos == 2) {
				pos = deck.Count;
			}

			Destroy(deck[pos].gameObject);
			deck.RemoveAt(pos);
		}
	}

    void Shuffle()
    {

    }

    void Sort()
    {

    }
}