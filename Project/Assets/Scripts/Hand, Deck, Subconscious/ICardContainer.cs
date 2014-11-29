using UnityEngine;
using System.Collections;

public interface ICardContainer
{
	void AddCard();
    void AddCard(Card _data, Player.Position _pos);
	void AddCard(Card _data, Player.Position _pos, Player.Amount _amount);

	void RemoveCard();
	void RemoveCard(Player.Position _pos);
	void RemoveCard(Card _data);
	void RemoveCard(Player.Position _pos, Player.Amount _amount);
}