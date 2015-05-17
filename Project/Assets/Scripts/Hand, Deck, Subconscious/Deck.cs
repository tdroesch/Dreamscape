using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Dreamscape
{
	public class Deck : CardContainer {
//		public List<Card> deck = new List<Card> ();
//		
//		private Hand hand;
//		private Field field;
//		private Subconscious subconscious;
//	
//		void Awake ()
//		{
//			hand = GameObject.FindGameObjectWithTag ("Hand").GetComponent<Hand> ();
//			field = GameObject.FindGameObjectWithTag ("Field").GetComponent<Field> ();
//			subconscious = GameObject.FindGameObjectWithTag ("Subconscious").GetComponent<Subconscious> ();
//		}
//	
//		// Add a card to the top of the deck 
//		public void AddCard (Card _card)
//		{
//			if (_card != null) {
//				deck.Add (_card);
//				_card.GetComponent<MeshRenderer> ().enabled = false;
//				_card.transform.position = this.gameObject.transform.position;
//				_card.transform.parent = this.gameObject.transform;
//				Debug.Log (_card.GetComponent<Card> ().Name + " has been added. iCost: " 
//					+ _card.GetComponent<Card> ().iCost + " wCost: " + _card.GetComponent<Card> ().wCost);
//			}
//	
//			CardSelection.selectedCard = null;
//		}
//	
//		// Add a selected card to the top, middle, or bottom of the deck
//		public void AddCard (Card _card, Position _pos)
//		{
//			if (_card != null) {
//				int pos = 0;
//				Debug.Log (_pos);
//	
//				if ((int)_pos == 0) {
//					pos = (deck.Count - deck.Count);
//				}
//	
//				if ((int)_pos == 1) {
//					pos = deck.Count / 2;
//				}
//	
//				if ((int)_pos == 2) {
//					pos = deck.Count;
//				}
//		      
//				deck.Insert (pos, _card);
//				_card.GetComponent<MeshRenderer> ().enabled = false;
//				_card.transform.position = this.gameObject.transform.position;
//				_card.transform.parent = this.gameObject.transform;
//				Debug.Log (_card.GetComponent<Card> ().Name + " has been added at the " + pos + " position");
//			}
//	
//			CardSelection.selectedCard = null;
//		}
//	
//		// Add an amount of cards at the top, middle, or bottom of the deck
//		public void AddCard (Card _card, int _amount)
//		{
//			for (int i = 1; i <= _amount; i++) {
//				//			int pos = (int)_pos;
//				//
//				//			if((int)_pos == 0) {
//				//				pos = 0;
//				//			}
//				//			
//				//			if((int)_pos == 1) {
//				//				pos = deck.Count / 2;
//				//			}
//				//			
//				//			if((int)_pos == 2) {
//				//				pos = deck.Count;
//				//			}
//	
//				deck.Add (_card);
//				_card.GetComponent<MeshRenderer> ().enabled = false;
//				_card.transform.position = this.gameObject.transform.position;
//				_card.transform.parent = this.gameObject.transform;
//			}
//		}
//		
//		// Remove the selected card (_data sent from CardSelection script)
//		public void RemoveCard (Card _card)
//		{
//			if (_card != null) {
//				deck.Remove (_card);
//			}
//		}
//	
//		public void RemoveCard (Card _card, int _amount)
//		{
//			for (int i = 1; i <= _amount; i++) {
//				deck.Remove (_card);
//			}
//		}
//	
//		// Remove a card from the top, middle, or bottom of the deck
//		public void RemoveCard (Position _pos)
//		{
//			int pos = (int)_pos;
//			Debug.Log (_pos);
//			
//			if ((int)_pos == 0) {
//				pos = 0;
//			}
//			
//			if ((int)_pos == 1) {
//				pos = deck.Count / 2;
//			}
//			
//			if ((int)_pos == 2) {
//				pos = deck.Count;
//			}
//	
//			Destroy (deck [pos].gameObject);
//			deck.RemoveAt ((int)_pos);
//		}
//	
//		// Remove a number of cards from the top, middle, or bottom of the deck
//		public void RemoveCard (Position _pos, int _amount)
//		{
//			int pos = (int)_pos;
//	
//			for (int i = 1; i < (int)_amount; i++) {
//				if ((int)_pos == 0) {
//					pos = 0;
//				}
//				
//				if ((int)_pos == 1) {
//					pos = deck.Count / 2;
//				}
//				
//				if ((int)_pos == 2) {
//					pos = deck.Count;
//				}
//	
//				Destroy (deck [pos].gameObject);
//				deck.RemoveAt (pos);
//			}
//		}
//	
//		public void RemoveCard (Card _card, Position _position, Target _target)
//		{
//			if ((int)_target == 1) {
//				hand.AddCard (_card);
//				deck.Remove (_card);
//			}
//			if ((int)_target == 2) {
//				field.AddCard (_card);
//				deck.Remove (_card);
//			}
//			if ((int)_target == 3) {
//				subconscious.AddCard (_card);
//				deck.Remove (_card);
//			}
//		}

		/// <summary>
		/// Fills the deck with random card.
		/// This is temporary and will be replaced with paramatized constructor.
		/// </summary>
		public Deck(int[] _cardList){
			NewContainer (this);
			Random.seed = System.DateTime.Now.Millisecond;
			for (int i = 0; i < _cardList.Length; i++){
				container.Add(new Card("Card_"+i, Random.Range(1,10)*100, Random.Range(1,10)*100));
			}
		}

		void Shuffle ()
		{
	
		}
	
		void Sort ()
		{
	
		}
	}
}
