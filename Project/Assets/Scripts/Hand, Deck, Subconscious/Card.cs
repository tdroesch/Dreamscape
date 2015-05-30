using UnityEngine;
using System.Collections;

namespace Dreamscape {
	public class Card
	{
		static int CardsCreated = 0;
		int gameID;
		public string Name;
		public int iCost;
		public int wCost;

		public int CardID{
			get {return gameID;}
		}
	
		public Card(string name, int iCost, int wCost)
		{
			CardsCreated++;
			this.gameID = CardsCreated;
	        this.Name = name;
	        this.iCost = iCost;
	        this.wCost = wCost;
		}
		public Card(Card _card){
			CardsCreated++;
			this.gameID = CardsCreated;
			this.Name = _card.Name;
			this.iCost = _card.iCost;
			this.wCost = _card.wCost;
		}
	}
}