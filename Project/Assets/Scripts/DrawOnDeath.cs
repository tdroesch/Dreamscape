using UnityEngine;
using System.Collections;

public class DrawOnDeath : CardEffect {

	public override void RegisterEffects(CardEventManager CEM){
		CEM.Death += DrawCard;
	}

	void DrawCard ()
	{
		Debug.Log("You Drew a Card");
	}
}
