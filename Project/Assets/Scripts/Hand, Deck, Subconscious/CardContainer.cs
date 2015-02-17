using System;
using System.Collections.Generic;

namespace Dreamscape
{
	public abstract class CardContainer : ICardContainer{
		protected List<Card> container = new List<Card> ();

		public int Count{
			get { return container.Count; }
		}
		
		public void AddCard(Card _card)
		{
			if(_card != null) {
				container.Add(_card);
			}
		} 
		
		public void AddCard(Card _card, Position _pos) 
		{
			if(_card != null) {	
				int pos = 0;
				
				if((int)_pos == 0) {
					pos = 0;
				}
				
				if((int)_pos == 1) {
					pos = container.Count / 2;
				}
				
				if((int)_pos == 2) {
					pos = container.Count;
				}
				container.Insert(pos, _card);
			}
		}
		
		public void AddCard(Card _card, int _amount)
		{
			if (_card != null) {
				for (int i = 0; i < _amount; i++) {
					//			int pos = (int)_pos;
					container.Add (new Card (_card));
				}
			}
		}

		public void AddCard (Card _card, int _amount, Position _pos){
			if(_card != null) {
				int pos=0;
				//		Debug.Log(_pos);
				
				if((int)_pos == 0) {
					pos = 0;
				}
				
				if((int)_pos == 1) {
					pos = container.Count / 2;
				}
				
				if((int)_pos == 2) {
					pos = container.Count;
				}
				for (int i = 0; i < _amount; i++) {
					//			int pos = (int)_pos;
					container.Insert (pos, new Card (_card));
				}
			}
		}
		

		public Card RemoveCard(Card _card)
		{
			// Removes the selected card from the hand and into the player's field
			if(_card != null) {
				container.Remove(_card);
				return _card;
			}
			else return null;
		}

		public Card RemoveCard (Position _pos){
			int pos = 0;
			if((int)_pos == 0) {
				pos = 0;
			}
			
			if((int)_pos == 1) {
				pos = container.Count / 2;
			}
			
			if((int)_pos == 2) {
				pos = container.Count;
			}
			Card c = container[pos];
			container.RemoveAt(pos);
			return c;
		}
		
		public Card[] RemoveCard(Card _card, int _amount) {
			List<Card> removedcards = new List<Card>();
			Card temp = null;
			for (int i = 0; i < _amount; i++) {
				if(container.RemoveCard (_card.Name, out temp)){
					removedcards.Add(temp);
				}
			}
			return removedcards.ToArray();
		}
		
		public Card[] RemoveCard(Position _pos, int _amount) 
		{ 
			List<Card> removedcards = new List<Card>();
			int pos = 0;
			if((int)_pos == 0) {
				pos = 0;
			}
			
			if((int)_pos == 1) {
				pos = (container.Count-_amount) / 2;
			}
			
			if((int)_pos == 2) {
				pos = container.Count-_amount;
			}
			for(int i = 0; i < _amount; i++) {
				removedcards.Add(container[pos]);
				container.RemoveAt(pos);
			}
			return removedcards.ToArray();
		}
	}
}

