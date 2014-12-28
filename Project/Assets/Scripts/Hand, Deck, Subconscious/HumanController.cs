﻿using UnityEngine;
using System.Collections;

//[System.Serializable]
public class HumanController : MonoBehaviour, IController {

	GameManager gm;

	// Use this for initialization
	void Start () {
		gm = GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown( KeyCode.Q)){
			gm.stateMessage("Start Game", this);
		}
		else if(Input.GetKeyDown( KeyCode.W)){
			gm.stateMessage("Start Draw", this);
		}
		else if(Input.GetKeyDown(KeyCode.E)){
			gm.stateMessage("Start Play", this);
		}
		else if(Input.GetKeyDown(KeyCode.R)){
			gm.stateMessage("Start End", this);
		}
		else if(Input.GetKeyDown(KeyCode.T)){
			gm.stateMessage("Next Turn", this);
		}
		else if(Input.GetKeyDown(KeyCode.Y)){
			gm.stateMessage("End Game", this);
		}
	}
}