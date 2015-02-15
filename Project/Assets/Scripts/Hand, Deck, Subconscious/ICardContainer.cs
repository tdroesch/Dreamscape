using UnityEngine;
using System.Collections;

namespace Dreamscape
{
	public interface ICardContainer {
		void AddCard (Card _card);
		void AddCard (Card _card, Position _pos);
		void AddCard (Card _card, int _amount);
		
		void RemoveCard (Card _card);
		void RemoveCard (Card _card, int _amount);
		void RemoveCard (Position _pos, int _amount);
		void RemoveCard (Card _card, Position _pos, Target _target);
	}
}