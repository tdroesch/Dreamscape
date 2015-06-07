using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeValue : MonoBehaviour {
	public float value;

	void Start(){
		value = float.Parse (GetComponent<Text> ().text);
	}

	void Update(){
		GetComponent<Text> ().text = value.ToString ();
	}
}
