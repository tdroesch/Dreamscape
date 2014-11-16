using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Field : MonoBehaviour, ICardContainer
{
	public string target;

	private Subconscious subconscious;
	private Deck deck;
	private Game game;

	public List <GameObject> field = new List<GameObject>();

	void Awake()
	{
		this.gameObject.tag = "Field";
		this.gameObject.name = "FieldOne"; 
	}
	
	void Start()
	{
		// For demo purposes, only finds subconscious by tag
		subconscious = GameObject.FindWithTag ("Subconscious").GetComponent<Subconscious>();
		deck = GameObject.FindWithTag("Deck").GetComponent<Deck>();
		game = GameObject.FindWithTag("GameManager").GetComponent<Game>();

		// For now, setting target to subconscious
		target = subconscious.name;
	}

	void Update()
	{
		if(game.resetGame) {
			// Return the cards in the field to the deck
			target = deck.name;
			foreach(GameObject c in field.ToArray()) {
				if(field.Count != 0) {
					RemoveCard(c);
				}
			}
		}

		// Reset the target
		target = subconscious.name;
	}
	
	public void AddCard(GameObject _card)
	{
		_card.transform.parent = this.gameObject.transform;
		field.Add (_card);
		ChangeTag(_card);
	}
	
	public void RemoveCard(GameObject _card)
	{
		// Move the card to the target's position
		_card.transform.position = GameObject.Find(target).transform.position;
		GameObject.Find (target).SendMessage("AddCard", _card);
		field.Remove(_card);
	}

	void ChangeTag(GameObject _card)
	{
		_card.tag = "Field";
	}
}
