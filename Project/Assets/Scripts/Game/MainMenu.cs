using UnityEngine;
using System.Collections;



public class MainMenu : MonoBehaviour
{
	//card catalog function, loads the card catalog level
	//not sure what the card catalog's level name is going to be at the time when this was written
	public void CardCatalog ()
	{
		Application.LoadLevel ("Place Holder Level");
	}

	//quit game function, exits the application
	public void QuitGame()
	{
		Application.Quit ();
	}
}
