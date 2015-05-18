using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	//card catalog function, loads the card catalog level
	public void CardCatalog ()
	{
		//put whatever level the card catalog is in here
		Application.LoadLevel ("Place Holder Level");
	}

	//quit game function, exits the application
	public void QuitGame()
	{
		//once the game is built, function will work
		Application.Quit ();
	}
}
