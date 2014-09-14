using UnityEditor;
using UnityEngine;
using System.Collections;

public class CardCreatorWindow : EditorWindow {

	[MenuItem("GameObject/Dreamscape/Create Card")]
	static void Init ()
	{
		CardCreatorWindow cardWindow = new CardCreatorWindow();
		cardWindow.position = new Rect (50, 50, 200, 200);
		cardWindow.title = "Card Creator";
		cardWindow.Show ();
	}

	static void OnGUI()
	{

	}
}
