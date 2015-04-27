using UnityEngine;
using System.Collections;



public class MainMenu : MonoBehaviour
{
	//new game function, loads a new level
	public void NewGame()
	{
		Application.LoadLevel (1);
	}

	//card catalog function, loads the card catalog level
	public void CardCatalog ()
	{
		Application.LoadLevel (2);
	}

	//quit game function, exits the application
	public void QuitGame()
	{
		Application.Quit ();
	}
}
