using UnityEngine;
using System.Collections;
using System.Xml;

public class CardEditor : MonoBehaviour {

	public Vector2 scrollPosition = Vector2.zero;
	void OnGUI() {
		scrollPosition = GUI.BeginScrollView(new Rect(10, 300, 100, 100), scrollPosition, new Rect(0, 0, 220, 200));
		GUI.Button(new Rect(0, 0, 100, 20), "Top-left");
		GUI.Button(new Rect(120, 0, 100, 20), "Top-right");
		GUI.Button(new Rect(0, 180, 100, 20), "Bottom-left");
		GUI.Button(new Rect(120, 180, 100, 20), "Bottom-right");
		GUI.EndScrollView();
	}
}
