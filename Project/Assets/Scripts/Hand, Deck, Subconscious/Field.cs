using UnityEngine;
using System.Collections;

public class Field : MonoBehaviour, ICardContainer
{
	public void AddCard(GameObject _card)
	{

	}

	public void AddCard(GameObject _card, Player.Position _pos) { } 

	public void AddCard(GameObject _card, Player.Position _pos, Player.Amount _amount) 
	{

	}
	
	public void RemoveCard(GameObject _card)
	{

	}

	public void RemoveCard(Player.Position _pos) { }

	public void RemoveCard(Player.Position _pos, Player.Amount _amount)
	{

	}

	public void RemoveCard(GameObject _card, Player.Position _pos, Player.Target _target)
	{

	}
}
