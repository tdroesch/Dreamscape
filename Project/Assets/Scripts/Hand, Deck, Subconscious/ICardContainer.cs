using UnityEngine;
using System.Collections;

public interface ICardContainer
{
	void AddCard(Card _card);
	void AddCard(Card _card, Player.Position _pos);
	void AddCard(Card _card, Player.Position _pos, Player.Amount _amount);
	
	void RemoveCard(Card _card);
	void RemoveCard(Player.Position _pos);
	void RemoveCard(Player.Position _pos, Player.Amount _amount);
	void RemoveCard(Card _card, Player.Position _pos, Player.Target _target);
}