using UnityEngine;
using System.Collections;

namespace Dreamscape {
	public class Card
	{
		int cardID;
		int guid;
		CardEventManager eventManager;
		public int iCost;
		public int wCost;

		/// <summary>
		/// Gets the GUID.
		/// </summary>
		/// <value>The GUID.</value>
		public int GUID{
			get {return guid;}
		}

		/// <summary>
		/// Gets the card ID.
		/// </summary>
		/// <value>The card ID.</value>
		public int CardID{
			get {return cardID;}
		}

		/// <summary>
		/// Gets the event manager.
		/// </summary>
		/// <value>The event manager.</value>
		public CardEventManager EventManager {
			get { return eventManager;}
		}
	
		public Card(int cardID, int iCost, int wCost)
		{
			this.guid = BoardManager.GetGUID(this);
	        this.cardID = cardID;
	        this.iCost = iCost;
	        this.wCost = wCost;
		}
		public Card(Card _card){
			this.guid = BoardManager.GetGUID(this);
			this.cardID = _card.CardID;
			this.iCost = _card.iCost;
			this.wCost = _card.wCost;
		}
	}
}