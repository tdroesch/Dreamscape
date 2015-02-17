using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Dreamscape
{
	public class Field : CardContainer{
//		public List<Card> field = new List<Card> ();
//	
//		private Deck deck;
//		private Hand hand;
//		private Subconscious subconscious;
//		 
//		void Awake ()
//		{
//			deck = GameObject.FindGameObjectWithTag ("Deck").GetComponent<Deck> ();
//			hand = GameObject.FindGameObjectWithTag ("Hand").GetComponent<Hand> ();
//			subconscious = GameObject.FindGameObjectWithTag ("Subconscious").GetComponent<Subconscious> ();
//		}
//	
//		public void AddCard (Card _card)
//		{
//			if (_card != null) {
//				_card.transform.position = this.gameObject.transform.position;
//				_card.GetComponent<MeshRenderer> ().enabled = true;
//				
//				field.Add (_card);
//				_card.transform.parent = this.gameObject.transform;
//			}
//			
//			CardSelection.selectedCard = null;
//		}
//	
//		public void AddCard (Card _card, Position _pos)
//		{ 
//			int pos = 0;
//			Debug.Log (_pos);
//			
//			if ((int)_pos == 0) {
//				pos = 0;
//			}
//			
//			if ((int)_pos == 1) {
//				pos = field.Count / 2;
//			}
//			
//			if ((int)_pos == 2) {
//				pos = field.Count;
//			}
//			
//			if (_card != null) {
//				subconscious.AddCard (_card);
//				field.RemoveAt (pos);
//			}
//		} 
//	
//		public void AddCard (Card _card, int _amount)
//		{
//			for (int i = 1; i <= (int)_amount; i++) {
//				//			int pos = 0;
//				
//				field.Add (_card);
//				_card.transform.parent = this.gameObject.transform;
//			}
//		}
//		
//		public void RemoveCard (Card _card)
//		{
//			if (_card != null) {
//				subconscious.AddCard (_card);
//				field.Remove (_card);
//			}
//		}
//	
//		public void RemoveCard (Card _card, int _amount)
//		{
//			for (int i = 0; i <= _amount; i++) {
//				field.Remove (_card);
//			}
//		}
//		
//		public void RemoveCard (Position _pos, int _amount)
//		{
//			int pos = 0;
//			
//			for (int i = 1; i < (int)_amount; i++) {
//				Destroy (field [pos].gameObject);
//				field.RemoveAt (pos);
//			}
//		}
//	
//		public void RemoveCard (Card _card, Position _position, Target _target)
//		{
//			if ((int)_target == 0) {
//				deck.AddCard (_card);
//				field.Remove (_card);
//			}
//			if ((int)_target == 1) {
//				hand.AddCard (_card);
//				field.Remove (_card);
//			}
//			if ((int)_target == 3) {
//				subconscious.AddCard (_card);
//				field.Remove (_card);
//			}
//		}
	}
}
