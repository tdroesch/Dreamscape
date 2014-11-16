using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	Hand hand;
	Deck deck;
	Field field;
	Subconscious discard;
	int will;
	int imagination;

	public Player(int will, int imagination, Hand hand, Deck deck, Field field, Subconscious discard){
		this.will = will;
		this.imagination = imagination;
		this.hand = hand;
		this.deck = deck;
		this.field = field;
		this.discard = discard;
	}

}