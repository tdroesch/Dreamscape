using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour
{
	public string Name;
	public string Type;
	public int iCost;
	public int wCost;

	public Card(string name, string type, int iCost, int wCost)
	{
        this.Name = name;
		this.Type = type;
        this.iCost = iCost;
        this.wCost = wCost;
	}
}