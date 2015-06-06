using UnityEngine;
using System.Collections;

public class TestClass : MonoBehaviour {
	public CardEventManager CEM;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump") && CEM != null){
			CEM.OnDiscard();
		}
	}
}
