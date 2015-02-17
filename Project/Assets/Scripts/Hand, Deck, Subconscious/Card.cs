using UnityEngine;
using System.Collections;

namespace Dreamscape {
	public class Card
	{
		public string Name;
		public int iCost;
		public int wCost;
	
		public Card(string name, int iCost, int wCost)
		{
	        this.Name = name;
	        this.iCost = iCost;
	        this.wCost = wCost;
		}
		public Card(Card _card){
			this.Name = _card.Name;
			this.iCost = _card.iCost;
			this.wCost = _card.wCost;
		}
	}
}