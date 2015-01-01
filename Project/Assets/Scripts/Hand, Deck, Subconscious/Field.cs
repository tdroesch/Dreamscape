using UnityEngine;
using System.Collections;

public class Field : MonoBehaviour, ICardContainer
{
	public void AddCard(Card _card)
	{

	}

	public void AddCard(Card _card, Player.Position _pos) { } 

	public void AddCard(Card _card, Player.Position _pos, Player.Amount _amount) 
	{

	}
	
	public void RemoveCard(Card _card)
	{

	}

	public void RemoveCard(Player.Position _pos) { }

	public void RemoveCard(Player.Position _pos, Player.Amount _amount)
	{

	}

	public void RemoveCard(Card _card, Player.Position _pos, Player.Target _target)
	{

	}
}
