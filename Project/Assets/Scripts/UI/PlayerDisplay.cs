using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerDisplay : MonoBehaviour {

	// pass in the game manager from which we get the states from
	public UIDebug gameManager;

	// check if this is the user player; uncheck if this is the opposing player
	public bool player1;

	// references to the fonts and sprites for the ui elements
	public Font uiFont;
	public Sprite s7remain;
	public Sprite s6remain;
	public Sprite s5remain;
	public Sprite s4remain;
	public Sprite s3remain;
	public Sprite s2remain;
	public Sprite s1remain;
	public Sprite s0remain;
	public Sprite stheta;
	public Sprite swave;
	public Sprite srem;
	public Sprite slucid;

	// references to the UI elements that the game manager will alter
	public Text name;
	public Image stagesLeft;
	public Text cyclesLeft;
	public Image currStage1;
	public Text currStage2;
	public Text will;
	public Text ima;

	// gets the name of the players
	void Awake () {
		if (player1)
		{
			name.text = gameManager.p1_name;
		}
		else
		{
			name.text = gameManager.p2_name;
		}

		// changes font to the set font
		name.font = uiFont;
		cyclesLeft.font = uiFont;
		currStage2.font = uiFont;
		will.font = uiFont;
		ima.font = uiFont;
	}

	void Update () {
		// updates the states, cycles, will, and imagination
		UpdateCycleStageImages ();
		UpdateCycleText ();
		UpdateWillAndImagination();
	}

	private void UpdateCycleStageImages()
	{
		// updates the stages and cycles images
		if (player1)
		{
				switch (gameManager.p1_stagesLeft) {
				case 0:
						stagesLeft.sprite = s0remain;
						break;
				case 1:
						stagesLeft.sprite = s1remain;
						break;
				case 2:
						stagesLeft.sprite = s2remain;
						break;
				case 3:
						stagesLeft.sprite = s3remain;
						break;
				case 4:
						stagesLeft.sprite = s4remain;
						break;
				case 5:
						stagesLeft.sprite = s5remain;
						break;
				case 6:
						stagesLeft.sprite = s6remain;
						break;
				case 7:
						stagesLeft.sprite = s7remain;
						break;
				}

				switch (gameManager.p1_sleepStage) {
				case 0:
						currStage1.sprite = stheta;
						currStage2.text = "theta";
						break;
				case 1:
						currStage1.sprite = swave;
						currStage2.text = "wave";
						break;
				case 2:
						currStage1.sprite = srem;
						currStage2.text = ".E.M.";
						break;
				case 3:
						currStage1.sprite = slucid;
						currStage2.text = "ucid";
						break;
				}
			}
		else
		{
			switch (gameManager.p2_stagesLeft) {
			case 0:
				stagesLeft.sprite = s0remain;
				break;
			case 1:
				stagesLeft.sprite = s1remain;
				break;
			case 2:
				stagesLeft.sprite = s2remain;
				break;
			case 3:
				stagesLeft.sprite = s3remain;
				break;
			case 4:
				stagesLeft.sprite = s4remain;
				break;
			case 5:
				stagesLeft.sprite = s5remain;
				break;
			case 6:
				stagesLeft.sprite = s6remain;
				break;
			case 7:
				stagesLeft.sprite = s7remain;
				break;
			}
			
			switch (gameManager.p2_sleepStage) {
			case 0:
				currStage1.sprite = stheta;
				currStage2.text = "theta";
				break;
			case 1:
				currStage1.sprite = swave;
				currStage2.text = "wave";
				break;
			case 2:
				currStage1.sprite = srem;
				currStage2.text = ".E.M.";
				break;
			case 3:
				currStage1.sprite = slucid;
				currStage2.text = "ucid";
				break;
			}
		}
	}

	private void UpdateCycleText()
	{
		// updates the text for the cycles
		if (player1)
		{
			cyclesLeft.text = gameManager.p1_cyclesLeft.ToString ();
		}
		else
		{
			cyclesLeft.text = gameManager.p2_cyclesLeft.ToString ();
		}
	}

	private void UpdateWillAndImagination()
	{
		// updates text for will and imagination
		if (player1)
		{
			will.text = gameManager.p1_will.ToString ();
			ima.text = gameManager.p1_ima.ToString ();
		}
		else
		{
			will.text = gameManager.p2_will.ToString ();
			ima.text = gameManager.p2_ima.ToString ();
		}
	}
}
