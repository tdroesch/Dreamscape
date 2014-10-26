using UnityEngine;
using System.Collections;

public class CardSelection : MonoBehaviour 
{
	private Deck deck;

	void Awake()
	{
		deck = GameObject.FindWithTag ("Deck").GetComponent<Deck>();
	}

	void OnClick()
	{
		RaycastHit hit;

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(ray.origin, ray.direction * 10, Color.blue);

		if(Physics.Raycast(ray, out hit)) {
			if(hit.collider.tag == "Card") {
				Debug.Log (hit.transform.gameObject.name + " selected");
				deck.SendMessage("RemoveCard");
			}
		}
	}

	void Update()
	{
		if(Input.GetMouseButtonDown(0)) {
			OnClick ();
		}
	}
}