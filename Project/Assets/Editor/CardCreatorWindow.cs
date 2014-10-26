using UnityEditor;
using UnityEngine;
using System.Collections;

public class CardCreatorWindow : EditorWindow {

	[MenuItem("GameObject/Dreamscape/Create Card")]
	static void Init ()
	{
		CardCreatorWindow cardWindow = ScriptableObject.CreateInstance<CardCreatorWindow>();
		cardWindow.position = new Rect (50, 50, 200, 200);
		cardWindow.title = "Card Creator";
		cardWindow.Show ();
		var guids = AssetDatabase.FindAssets("t:Object");
		foreach (var guid in guids){
			Debug.Log(AssetDatabase.GUIDToAssetPath(guid));
		}
	}

	static void OnGUI()
	{

	}
}
