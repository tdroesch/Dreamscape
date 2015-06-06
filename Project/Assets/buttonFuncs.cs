using UnityEngine;
using System.Collections;
using Dreamscape;

public class buttonFuncs : MonoBehaviour 
{
	playerScript player;

	void Start()
	{
		player = GameObject.Find ("Player1").GetComponent<playerScript> ();
	}


	public void endTurn()
	{
		player.endTurn ();
	}

	public void selectCard()
	{
		player.selectedCard (this.gameObject);
	}

//	public void playCardToField()
//	{
//		player.playCardToField ();
//	}

	public void QuitGame()
	{
		Debug.Log ("Quitting Game");
		//GameObject.Find ("localGame").GetComponent<LocalClientGameManager> ().Resign ();
	}

	public void setAttack()
	{
		player.playCardToField ("Attack");
	}

	public void setDefense()
	{
		player.playCardToField ("Defense");
	}
}
