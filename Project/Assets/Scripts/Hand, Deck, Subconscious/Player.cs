using UnityEngine;
using System.Collections;

namespace Dreamscape
{
	/// <summary>
	/// Player Class.
	/// The Player object that interacts with each other throught the game board.
	/// 
	/// Properties: Imagination, Will, HandSize, DeckSize, GetField, Discard, Controller
	/// Methods: void DrawCard(), void PlayCard()
	/// </summary>
	public class Player {
		Hand hand;
		Deck deck;
		Field field;
		Subconscious discard;
		int will;
		int imagination;
		IController controller;
	
		//Temporary for testing purposes
		int handsize;
		int deckSize;
		//******************************
	
		/// <summary>
		/// Gets or sets the imagination.
		/// </summary>
		/// <value>The imagination.</value>
		public int Imagination {
			get{ return imagination; }
			set{ imagination = value; }
		}
	
		/// <summary>
		/// Gets the will.
		/// </summary>
		/// <value>The will.</value>
		public int Will {
			get{ return will;}
		}
	
		/// <summary>
		/// Gets the size of the hand.
		/// </summary>
		/// <value>The size of the hand.</value>
		public int HandSize {
			get{ return handsize; }//hand.hand.Count;}
		}
	
		/// <summary>
		/// Gets the size of the deck.
		/// </summary>
		/// <value>The size of the deck.</value>
		public int DeckSize {
			get{ return deckSize; }//deck.deck.Count;}
		}
	
		/// <summary>
		/// Gets the get field.
		/// </summary>
		/// <value>The get field.</value>
		public Field GetField {
			get{ return field;}
		}
	
		/// <summary>
		/// Gets the discard.
		/// </summary>
		/// <value>The discard.</value>
		public Subconscious Discard {
			get { return discard;}
		}
	
		/// <summary>
		/// Gets the controller.
		/// </summary>
		/// <value>The controller.</value>
		public IController Controller {
			get{ return controller;}
		}
	
		/// <summary>
		/// Initializes a new instance of the <see cref="Player"/> class.
		/// </summary>
		/// <param name="will">Will.</param>
		/// <param name="imagination">Imagination.</param>
		/// <param name="hand">Hand.</param>
		/// <param name="deck">Deck.</param>
		/// <param name="field">Field.</param>
		/// <param name="discard">Discard.</param>
		/// <param name="controller">Controller.</param>
		public Player (int will, int imagination, Hand hand, Deck deck, Field field, Subconscious discard, IController controller)
		{
			this.will = will;
			this.imagination = imagination;
			this.hand = hand;
			this.deck = deck;
			this.field = field;
			this.discard = discard;
			this.controller = controller;
		}
	
		/// <summary>
		/// Draws a card.
		/// </summary>
		public void DrawCard ()
		{
			//hand.AddCard(deck.deck[0]);
			//deck.RemoveCard(deck.deck[0]);
			handsize++;
		}
	
		/// <summary>
		/// Plays a card.
		/// </summary>
		public void PlayCard ()
		{
			//hand.RemoveCard (hand.hand [0]);
			handsize--;
		}
	}
}