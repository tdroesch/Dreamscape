using UnityEngine;
using System.Collections;
/// <summary>
/// Draw on death effect.
/// </summary>
public class DrawOnDeath : CardEffect {
	/// <summary>
	/// Registers the DrawCard function to the Death event on the CEM.
	/// </summary>
	/// <param name="CEM">The CardEventManager that will be handling the effects.</param>
	public override void RegisterEffects(CardEventManager CEM){
		CEM.Death += DrawCard;
	}
	/// <summary>
	/// Has the player draw a card.
	/// </summary>
	void DrawCard ()
	{
		Debug.Log("You Drew a Card");
	}
}
