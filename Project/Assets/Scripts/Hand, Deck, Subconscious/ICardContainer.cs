using UnityEngine;
using System.Collections;

public interface ICardContainer
{
	void AddCard(GameObject _card);
	void AddCard(GameObject _card, Player.Position _pos);
	void AddCard(GameObject _card, Player.Position _pos, Player.Amount _amount);
	
	void RemoveCard(GameObject _card);
	void RemoveCard(Player.Position _pos, Player.Amount _amount);
	void RemoveCard(GameObject _card, Player.Position _pos, Player.Target _target);
}