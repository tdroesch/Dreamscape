using UnityEngine;
using System.Collections;

public class CardSelection : MonoBehaviour 
{
	public int click; // For later use when using double-click
	public float clickTimer; // So that the double-click doesn't register if the second click is too late
	public bool startTimer;
	public GameObject selectedCard;

	private Deck deck;
	private Hand hand;
	private Field field;

	void Awake()
	{
		deck = GameObject.FindWithTag ("Deck").GetComponent<Deck> ();
		hand = GameObject.FindWithTag ("Hand").GetComponent<Hand> ();
		field = GameObject.FindWithTag ("Field").GetComponent<Field> ();
	}

	void Start()
	{
		selectedCard = null;
	}

	void OnClick()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(ray.origin, ray.direction * 10, Color.blue);

		if(Physics.Raycast(ray, out hit)) {
			if(hit.collider.tag == "Deck" && deck.deck.Count != 0) {
				// Send a message to the deck to remove the selected card
				deck.SendMessage("RemoveCard", hit.transform.gameObject);
				clickTimer = 0.0f;
				selectedCard = null;
				startTimer = false;
			}
			else if(hit.collider.tag == "Hand" && hand.hand.Count != 0) {
				// Send a message to the hand to remove the selected card
				hand.SendMessage("RemoveCard", hit.transform.gameObject);
				clickTimer = 0.0f;
				selectedCard = null;
				startTimer = false;
			}
			else if(hit.collider.tag == "Field" && field.field.Count != 0) {
				field.SendMessage("RemoveCard", hit.transform.gameObject);
				clickTimer = 0.0f;
				selectedCard = null;
				startTimer = false;
			}
		}
	}

	void Update()
	{
		// Get the card that the player is currently selecting
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit)) {
			if(Input.GetMouseButtonDown(0)) {
				selectedCard = hit.transform.gameObject;
				click += 1;
				startTimer = true;

				// If the card is selected twice, call OnClick() to move it
				if(click == 2 && selectedCard == hit.transform.gameObject) {
					OnClick ();
					click = 0;
				}
			}
		}

		// No action if the player doesn't click a card a second time within one second
		if(startTimer) {
			clickTimer += 1.0f * Time.deltaTime;

			if(clickTimer >= 1.0f) {
				click = 0;
				clickTimer = 0.0f;
				startTimer = false;
				selectedCard = null;
			}
		}
	}
}