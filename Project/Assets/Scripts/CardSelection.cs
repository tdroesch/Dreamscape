using UnityEngine;
using System.Collections;

public class CardSelection : MonoBehaviour 
{
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