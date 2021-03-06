﻿using UnityEngine;
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
		int charID;
		int guid;
		Hand hand;
		Deck deck;
		Field field;
		Subconscious discard;
		int will;
		int imagination;
		int sleepCycles;
		int sleepStage;
		int sleepActions;
		IClient client;
	
		//Temporary for testing purposes
		int handsize;
		int deckSize;
		//******************************

		/// <summary>
		/// Gets the character ID.
		/// </summary>
		/// <value>The character database ID value for this instance.</value>
		public int CharID {
			get { return charID;}
		}

		/// <summary>
		/// Gets the GUID.
		/// </summary>
		/// <value>The GUID of this player for the game.</value>
		public int GUID {
			get { return guid;}
		}
	
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
			set{ will = value;}
		}

		/// <summary>
		/// Gets the remaining sleep cycles.
		/// </summary>
		/// <value>The sleep cycles.</value>
		public int SleepCycles {
			get{ return sleepCycles;}
			set{ sleepCycles = value;}
		}

		/// <summary>
		/// Gets the sleep stage.
		/// </summary>
		/// <value>The sleep stage.</value>
		public int SleepStage {
			get{ return sleepStage;}
			set{ sleepStage = value;}
		}

		/// <summary>
		/// Gets the sleep actions.
		/// </summary>
		/// <value>The sleep actions.</value>
		public int SleepActions {
			get{ return sleepActions;}
			set{ sleepActions = value;}
		}

		public int StageImagination {
			get {
				switch (sleepStage) {
				case 1:
					return 100;
				case 2:
					return 250;
				case 3:
					return 450;
				case 4:
					return 500;
				default:
					return 0;
				}
			}
		}
	
		/// <summary>
		/// Gets the size of the hand.
		/// </summary>
		/// <value>The size of the hand.</value>
		public int HandSize {
			get{ return hand.Count;}
		}

		/// <summary>
		/// Gets the hand GUID.
		/// </summary>
		/// <value>The hand GUID.</value>
		public int HandGUID {
			get { return hand.GUID;}
		}
	
		/// <summary>
		/// Gets the size of the deck.
		/// </summary>
		/// <value>The size of the deck.</value>
		public int DeckSize {
			get{ return deck.Count;}
		}

		/// <summary>
		/// Gets the deck GUID.
		/// </summary>
		/// <value>The deck GUID.</value>
		public int DeckGUID {
			get{ return deck.GUID;}
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
		public IClient Client {
			get{ return client;}
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
		/// <param name="client">Client.</param>
		public Player (int charID, int will, int imagination, Hand hand, Deck deck, Field field, Subconscious discard, IClient client)
		{
			this.charID = charID;
			this.will = will;
			this.imagination = imagination;
			this.hand = hand;
			this.deck = deck;
			this.field = field;
			this.discard = discard;
			this.client = client;
			this.sleepCycles = 3;
			this.sleepStage = 1;
			this.sleepActions = 0;
			this.guid = BoardManager.GetGUID (this);
		}
	
		/// <summary>
		/// Draws a card.
		/// </summary>
		public Card DrawCard ()
		{
			Card drawnCard = deck.RemoveCard (Position.top);
			hand.AddCard (drawnCard);
			return drawnCard;
		}
	
		/// <summary>
		/// Plays all cards that can be played.
		/// This is temporary.
		/// Replace with PlayCard(Card _card) that will be called through user interface.
		/// </summary>
		public void PlayCards ()
		{
			Card[] cards = hand.Peak ();
			foreach (Card c in cards) {
				if (c.iCost <= this.imagination) {
					this.field.AddCard (hand.RemoveCard (c));
					imagination -= c.iCost;
					Debug.Log ("Current Player Plays " + c.CardID + " for " + c.iCost + ".");
				}
			}
		}
	}
}