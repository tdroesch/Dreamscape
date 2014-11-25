using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck : MonoBehaviour, ICardContainer
{
    public List<Card> deck = new List<Card>();
    public CardSelection.Position _pos;
    public int amount;

    public enum SortBy
    {
        Alpha,
        Type,
        Cost
    };

    void Update()
    {
        // INPUT FOR TESTING PURPOSES
        if (Input.GetKeyDown(KeyCode.A))
        {
            // Add the selected card
            AddCard();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            // Add card with a selection and position to pull from
            AddCard(CardSelection.selectedCard, _pos);
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            // Add card with a selection, position, and amount of cards to pull
            AddCard(CardSelection.selectedCard, _pos, amount);
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            // Remove cards with only a selected card as the parameter
        }

        // TESTING POSITION SELECTION
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            _pos = CardSelection.Position.top;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _pos = CardSelection.Position.middle;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _pos = CardSelection.Position.bottom;
        }
    }

	public void AddCard()
    {
        Card card = new Card(name, Random.Range(0, 5), Random.Range(0, 10));
        deck.Add(card);
        card.Name = "Test Card " + deck.Count;

        Debug.Log(card.Name + " has been added as the " + deck.Count + " item.");
    }

    public void AddCard(Card _card, CardSelection.Position _pos)
    {
        Card card = new Card(name, Random.Range(0, 5), Random.Range(0, 10));
        Debug.Log(_pos);
        int pos = deck.Count / (int)_pos;
        deck.Insert(pos, card);
        card.Name = "Test Card " + deck.Count;

        Debug.Log (card.Name + " has been added at the " + pos + " position");
    }

    public void AddCard(Card _card, CardSelection.Position _pos, int _amount)
    {

    }

    public void RemoveCard(Card _card)
    {

    }

    void Shuffle()
    {

    }

    void Sort()
    {

    }
}