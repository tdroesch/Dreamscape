using UnityEngine;
using System.Collections;

public class Card 
{
	public string Name;
	public int iCost;
	public int wCost;

	public Card(string name, int iCost, int wCost)
	{
        this.Name = name;
        this.iCost = iCost;
        this.wCost = wCost;
	}
}