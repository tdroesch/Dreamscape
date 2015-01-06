using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Field : MonoBehaviour, ICardContainer
{
	public List<GameObject> field = new List<GameObject> ();

	public void AddCard(GameObject _card)
	{
		if(_card != null) {
			_card.transform.position = this.gameObject.transform.position;
			_card.GetComponent<MeshRenderer>().enabled = true;
			
			field.Add(_card);
			_card.transform.parent = this.gameObject.transform;
		}
		
		CardSelection.selectedCard = null;
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
