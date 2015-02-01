using UnityEngine;
using System.Collections;

public interface ICardContainer
{
	void AddCard(Card _card);
	void AddCard(Card _card, Demo.Position _pos);
	void AddCard(Card _card, int _amount);
	
	void RemoveCard(Card _card);
	void RemoveCard(Card _card, int _amount);
	void RemoveCard(Demo.Position _pos, int _amount);
	void RemoveCard(Card _card, Demo.Position _pos, Demo.Target _target);
}