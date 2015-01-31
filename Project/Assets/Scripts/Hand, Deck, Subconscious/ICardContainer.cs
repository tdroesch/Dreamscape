using UnityEngine;
using System.Collections;

public interface ICardContainer
{
	void AddCard(GameObject _card);
	void AddCard(GameObject _card, Demo.Position _pos);
	void AddCard(GameObject _card, int _amount);
	
	void RemoveCard(GameObject _card);
	void RemoveCard(GameObject _card, int _amount);
	void RemoveCard(Demo.Position _pos, int _amount);
	void RemoveCard(GameObject _card, Demo.Position _pos, Demo.Target _target);
}