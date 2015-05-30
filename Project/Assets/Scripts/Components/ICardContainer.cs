using UnityEngine;
using System.Collections;

namespace Dreamscape
{
	public interface ICardContainer {
		void AddCard (Card _card);
		void AddCard (Card _card, Position _pos);
		void AddCard (Card _card, int _amount);
		void AddCard (Card _card, int _amount, Position _pos);
		
		Card RemoveCard (Card _card);
		Card RemoveCard (Position _pos);
		Card[] RemoveCard (Card _card, int _amount);
		Card[] RemoveCard (Position _pos, int _amount);
	}
}