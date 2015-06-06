using UnityEngine;
using System.Collections;

public class enemyButtonFuncs : MonoBehaviour 
{
	playerScript _player;


	// Use this for initialization
	void Start () 
	{
		_player = GameObject.Find ("Player1").GetComponent<playerScript> ();
	}
	
	public void setEnemy()
	{
		_player.SendMessage ("enemySet", this.gameObject);
	}
}
