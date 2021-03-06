﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerDisplay : MonoBehaviour {

	// pass in the game manager from which we get the states from
	public UIController controller;

	// check if this is the user player; uncheck if this is the opposing player
	public bool isPlayerOne;

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
	private Text playerName;
	public Image stagesLeft;
	public Text cyclesLeft;
	public Image currStage1;
	public Text currStage2;
	public Text will;
	public Text ima;

	void Awake()
	{
		if (controller == null) {
			controller = gameObject.GetComponent<UIController>();
		}
	}

	void Start () 
	{
		/// <summary> Get the names of the players from the game manager. </summary>
		if (isPlayerOne) {
			playerName = GameObject.Find ("P1_Name").GetComponent<Text> ();
			playerName.text = controller.name;
		} else {
			playerName = GameObject.Find ("P2_Name").GetComponent<Text> ();
			playerName.text = controller.name;
		}

		// changes font to the set font
		playerName.font = uiFont;
		cyclesLeft.font = uiFont;
		currStage2.font = uiFont;
		will.font = uiFont;
		ima.font = uiFont;
	}

	public void UpdateCycleStageImages()
	{
			switch (controller.stagesLeft) {
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

			switch (controller.sleepStage) {
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

	public void UpdateCycleText()
	{
		// updates the text for the cycles
		cyclesLeft.text = controller.cyclesLeft.ToString ();
	}

	public void UpdateWillAndImagination()
	{
		// updates text for will and imagination
		will.text = controller.will.ToString ();
		ima.text = controller.imagination.ToString ();
	}
}
