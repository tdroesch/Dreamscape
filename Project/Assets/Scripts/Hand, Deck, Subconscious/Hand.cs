using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hand : MonoBehaviour, ICardContainer 
{
<<<<<<< HEAD
	public int handCount;

	public List <GameObject> hand = new List<GameObject>();

	public void AddCard()
	{
		Debug.Log ("Adding card to hand from deck...");
		handCount += 1;
=======
	public List<Card> handOne = new List<Card>();

	public void AddCard()
	{
>>>>>>> origin/Dori
	}
	
	public void RemoveCard()
	{
	}
}