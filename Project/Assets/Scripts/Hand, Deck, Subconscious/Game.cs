using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour 
{
	public Player player1;
	public Player player2;
	public Board board;
	public bool startGame;
	public bool resetGame;

	public void FSM()
	{

	}

	void OnGUI()
	{
		if (GUI.Button (new Rect (5, 5, 150, 30), "Start Game")) {
			startGame = true;
		}
		if (GUI.Button (new Rect (5, 35, 150, 30), "Reset")) {
			resetGame = true;
		}
	}
}