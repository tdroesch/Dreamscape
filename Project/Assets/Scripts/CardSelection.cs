using UnityEngine;
using System.Collections;

public class CardSelection : MonoBehaviour 
{
	public RaycastHit hit;
	public static GameObject selectedCard;

	private Hand hand;
	private Player player;
	
	void Awake()
	{
		hand = GameObject.FindGameObjectWithTag ("Hand").GetComponent<Hand> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void Update()
	{
		if(Input.GetButtonDown("Fire1")) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast (ray, out hit)) {
				OnClick(hit.transform.gameObject);
			}
		}
	}

	void OnClick(GameObject _hit)
	{
		if (_hit.renderer.enabled == true) {
			selectedCard = _hit;
			Debug.Log ("Selected Card: " + selectedCard.GetComponent<Card> ().Name);
			
			if(player._target == Player.Target.field) {
				hand.RemoveCard (selectedCard);
			} else {
				hand.RemoveCard(selectedCard, player._pos, player._target);
			}
		}
	}
}