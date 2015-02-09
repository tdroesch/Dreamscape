using UnityEngine;
using System.Collections;

//[System.Serializable]
public class HumanController : MonoBehaviour, IController {
	//***********************************************
	//This is almost entirely for testing purposes.
	ServerGameManager gm;

	// Use this for initialization
	void Start () {
		gm = GetComponent<ServerGameManager> ();
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
			PlayCard(null);
		}
		else if(Input.GetKeyDown(KeyCode.R)){
			EndTurn();
		}
		else if(Input.GetKeyDown(KeyCode.T)){
			gm.stateMessage("Next Turn", this);
		}
		else if(Input.GetKeyDown(KeyCode.Y)){
			gm.stateMessage("End Game", this);
		}
	}
	//***********************************************

	public void PlayCard(Card card){
		gm.stateMessage("Start Play", this);
	}

	public void UseCardAbility(Ability ability){
	}

	public void EndTurn(){
		gm.stateMessage("Start End", this);
	}
}