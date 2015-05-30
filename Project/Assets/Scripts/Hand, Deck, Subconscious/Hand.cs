using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Dreamscape {
	public class Hand : CardContainer
	{
//		public List<Card> hand = new List<Card> ();
//	
//		public void AddCard(Card _card)
//		{
//			if(_card != null) {
//				hand.Add(_card);
//			}
//		} 
//	
//		public void AddCard(Card _card, Position _pos) 
//		{
//			if(_card != null) {	
//				int pos;
//
//				if((int)_pos == 0) {
//					pos = 0;
//				}
//				
//				if((int)_pos == 1) {
//					pos = hand.Count / 2;
//				}
//				
//				if((int)_pos == 2) {
//					pos = hand.Count;
//				}
//				hand.Insert(pos, _card);
//			}
//		}
//	
//		public void AddCard(Card _card, int _amount)
//		{
//			if (_card != null) {
//				for (int i = 0; i < _amount; i++) {
//					//			int pos = (int)_pos;
//					hand.Add (new Card (_card));
//				}
//			}
//		}
//
//		
//		public void AddCard (Card _card, int _amount, Position _pos){
//			if(_card != null) {
//				int pos;
//				//		Debug.Log(_pos);
//				
//				if((int)_pos == 0) {
//					pos = 0;
//				}
//				
//				if((int)_pos == 1) {
//					pos = hand.Count / 2;
//				}
//				
//				if((int)_pos == 2) {
//					pos = hand.Count;
//				}
//				for (int i = 0; i < _amount; i++) {
//					//			int pos = (int)_pos;
//					hand.Insert (pos, new Card (_card));
//				}
//			}
//		}
//		
//		public Card RemoveCard(Card _card)
//		{
//			// Removes the selected card from the hand and into the player's field
//			if(_card != null) {
//				hand.Remove(_card);
//				return _card;
//			}
//			else return null;
//		}
//
//		
//		public Card RemoveCard (Position _pos){
//			int pos = 0;
//			if((int)_pos == 0) {
//				pos = 0;
//			}
//			
//			if((int)_pos == 1) {
//				pos = hand.Count / 2;
//			}
//			
//			if((int)_pos == 2) {
//				pos = hand.Count;
//			}
//			Card c = hand[pos];
//			hand.RemoveAt(pos);
//			return c;
//		}
//	
//		public Card[] RemoveCard(Card _card, int _amount) {
//			List<Card> removedcards = new List<Card>();
//			Card temp = null;
//			for (int i = 0; i < _amount; i++) {
//				if(hand.RemoveCard (_card.Name, out temp)){
//					removedcards.Add(temp);
//				}
//			}
//			return removedcards.ToArray();
//		}
//	
//		public Card[] RemoveCard(Position _pos, int _amount) 
//		{ 
//			List<Card> removedcards = new List<Card>();
//			int pos = 0;
//			if((int)_pos == 0) {
//				pos = 0;
//			}
//			
//			if((int)_pos == 1) {
//				pos = (hand.Count-_amount) / 2;
//			}
//			
//			if((int)_pos == 2) {
//				pos = hand.Count-_amount;
//			}
//			for(int i = 0; i < _amount; i++) {
//				removedcards.Add(hand[pos]);
//				hand.RemoveAt(pos);
//			}
//		}


		/// <summary>
		/// Temporary function for testing purposes
		/// Reaveals the contents of the Hand
		/// </summary>
		public Card[] Peak(){
			return container.ToArray();
		}
		void Sort()
		{
	
		}
	}
}