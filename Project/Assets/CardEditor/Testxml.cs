using UnityEngine;
using System.Collections;

public class Testxml : MonoBehaviour {
	
	public CardStorage card;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if(GUI.Button(new Rect(50,50,400,100),"write")){
			card = new CardStorage(010101,"TestCard",new Texture2D(0,0),CardStorage.types.Stuff,CardStorage.subTypes.SubThing,100,5,8,"ability");
			CardStorage.ToFile(card);
		}
	}
}
