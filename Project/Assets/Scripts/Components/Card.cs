using UnityEngine;
using System.Collections;

namespace Dreamscape {
	public class Card
	{
		int cardID;
		int guid;
		public int iCost;
		public int wCost;

		public int GUID{
			get {return guid;}
		}

		public int CardID{
			get {return cardID;}
		}
	
		public Card(int cardID, int iCost, int wCost)
		{
			this.guid = BoardManager.GetGUID();
	        this.cardID = cardID;
	        this.iCost = iCost;
	        this.wCost = wCost;
		}
		public Card(Card _card){
			this.guid = BoardManager.GetGUID();
			this.cardID = _card.CardID;
			this.iCost = _card.iCost;
			this.wCost = _card.wCost;
		}
	}
}