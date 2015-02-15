using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Dreamscape {
	public class Hand : ICardContainer
	{
		public List<Card> hand = new List<Card> ();
	
		public void AddCard(Card _card)
		{
			if(_card != null) {
				hand.Add(_card);
			}
		} 
	
		public void AddCard(Card _card, Position _pos) 
		{
			if(_card != null) {
				int pos = (int)_pos;
		//		Debug.Log(_pos);
				
				if((int)_pos == 0) {
					pos = 0;
				}
				
				if((int)_pos == 1) {
					pos = hand.Count / 2;
				}
				
				if((int)_pos == 2) {
					pos = hand.Count;
				}
				hand.Insert(pos, _card);
			}
		}
	
		public void AddCard(Card _card, int _amount)
		{
			for(int i = 1; i <= (int)_amount; i++) {
	//			int pos = (int)_pos;
	
				hand.Add(_card);
			}
		}
		
		public void RemoveCard(Card _card)
		{
			// Removes the selected card from the hand and into the player's field
			if(_card != null) {
				hand.Remove(_card);
			}
		}
	
		public void RemoveCard(Card _card, int _amount) {
			for (int i = 1; i <= _amount; i++) {
				hand.Remove (_card);
			}
		}
	
		public void RemoveCard(Position _pos, int _amount) 
		{ 
			int pos = 0;
			
			for(int i = 1; i < (int)_amount; i++) {
				hand.RemoveAt(pos);
			}
		}
	
		public void RemoveCard(Card _card, Position _position, Target _target)
		{
			if((int)_target == 0) {
				hand.Remove (_card);
			}
			if((int)_target == 2) {
				hand.Remove(_card);
			}
			if((int)_target == 3) {
				hand.Remove(_card);
			}
		}
	
		void Sort()
		{
	
		}
	}
}