using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Subconscious : MonoBehaviour, ICardContainer 
{
	public List<GameObject> subconscious = new List<GameObject> ();

	public void AddCard(GameObject _card)
	{

	}
	
	public void AddCard(GameObject _card, Player.Position _pos) 
	{ 
	
	} 
	
	public void AddCard(GameObject _card, Player.Position _pos, Player.Amount _amount) 
	{
		
	}
	
	public void RemoveCard(GameObject _card)
	{
		
	}

	public void RemoveCard(Player.Position _pos, Player.Amount _amount)
	{
		
	}
	
	public void RemoveCard(GameObject _card, Player.Position _position, Player.Target _target)
	{
		
	}
}
