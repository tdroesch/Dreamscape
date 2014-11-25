using UnityEngine;
using System.Collections;

public interface ICardContainer
{
	void AddCard();
    void AddCard(Card _data, CardSelection.Position _pos);
    void AddCard(Card _data, CardSelection.Position _pos, int _amount);

	void RemoveCard(Card _data);
}