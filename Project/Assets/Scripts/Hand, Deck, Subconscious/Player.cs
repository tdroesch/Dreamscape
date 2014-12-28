using UnityEngine;
using System.Collections;

public class Player 
{
	Hand hand;
	Deck deck;
	Field field;
	Subconscious discard;
	int will;
	int imagination;
	IController controller;

	//Temporary for testing purposes
	int handsize;
	//******************************

	public int Imagination {
		get{ return imagination; }
		set{ imagination = value; }
	}

	public int Will {
		get{ return will;}
	}

	public int HandSize {
		get{ return handsize; }//deck.deck.Count;}
	}

	public IController Controller {
		get{ return controller;}
	}

	public Player(int will, int imagination, Hand hand, Deck deck, Field field, Subconscious discard, IController controller){
		this.will = will;
		this.imagination = imagination;
		this.hand = hand;
		this.deck = deck;
		this.field = field;
		this.discard = discard;
		this.controller = controller;
	}

	public void DrawCard ()
	{
		//hand.AddCard(deck.deck[0]);
		//deck.RemoveCard(deck.deck[0]);
		handsize++;
	}
	public void PlayCard (){
		//hand.RemoveCard (hand.hand [0]);
		handsize--;
	}
}