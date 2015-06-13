using UnityEngine;
using System.Collections;

//currently just a placeholder for the game manager for ui purposes

public class UIController : MonoBehaviour 
{
	// initializes the visible game elements for player1 and player2
	public int will = 2000;
	public int imagination = 2000;
	public int cyclesLeft = 7;
	public int stagesLeft = 7;
	public int sleepStage = 0;

	public string playerName;

	private PlayerDisplay pd;

	void Start()
	{
		playerName = gameObject.name;

		pd = gameObject.GetComponent<PlayerDisplay> ();
	}

	public void AddWill(int _will)
	{
		will += _will;
		pd.UpdateWillAndImagination ();
	}

	public void AddImagination(int _imagination)
	{
		imagination += _imagination;
		pd.UpdateWillAndImagination ();
	}

	public void AddCycle(int _cycle)
	{
		cyclesLeft += _cycle;
		pd.UpdateCycleText ();
	}

	public void AddStage(int _stage)
	{
		stagesLeft += _stage;
		sleepStage += 1;

		if (sleepStage > 3) {
			sleepStage = 0;
		}

		if (sleepStage == -1) {
			AddCycle(-1);
			stagesLeft = 7;
		}

		pd.UpdateCycleStageImages ();
	}
}