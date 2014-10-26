using UnityEngine;
using System.Collections;

public class CardSelection : MonoBehaviour 
{
<<<<<<< HEAD
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
=======
	void Update()
	{
		if(Input.GetMouseButtonDown(0)) {

			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			Transform select = GameObject.FindWithTag ("Card").transform;

			if(Physics.Raycast (ray, out hit, 100.0f)) {
				select.tag = "Selected";
				hit.collider.transform.tag = "Selected";
			}
		}
	}
}
>>>>>>> origin/Dori
