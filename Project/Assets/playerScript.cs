using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Dreamscape;

public class playerScript : MonoBehaviour 
{
	public Player _player;
//	Hand _hand;
//	Deck _deck;
//	Field _field;
//	Subconscious _subc;
//	IClient _iCl;
	public GameObject cardPre;
	int cardsInHand = 0;
	LocalClientGameManager _localCL;
	List<GameObject> ListEnemies = new List<GameObject> ();

	public Transform[] handPlace;
	public Transform[] entPlace;
	public Transform[] machPlace;

	public GameObject attackButt;
	public GameObject defenseButt;

	public GameObject upButt;
	public GameObject downButt;

	GameObject _selectedCard;

	//Test------------------------------------
	bool cardSelected = false;



	//TODO write in moving card from playfield to hand

	// Use this for initialization
	void Start () 
	{
		_localCL = GameObject.FindWithTag ("localClient").GetComponent<LocalClientGameManager> ();
		_player = new Player (100, 100, new Hand (), new Deck (), new Field(), new Subconscious(), _localCL);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void drawFromHand()
	{
		_player.DrawCard ();
		//_localCL.
		Transform finalPoint = this.transform;
		for(int i = 0; i < handPlace.Length; i++)
		{
			if(!handPlace[i].GetComponent<placementScript>().occupied)
			{
				finalPoint = handPlace[i];
				handPlace[i].GetComponent<placementScript>().occupied = true;
				break;
			}
		}
		Vector3 pos = Camera.main.WorldToScreenPoint (finalPoint.position);
		GameObject GO = Instantiate (cardPre, pos, Quaternion.identity) as GameObject;
		GO.GetComponent<cardScript> ().currPos = finalPoint.gameObject;
		GO.transform.SetParent (GameObject.Find ("Canvas_PlayField").transform);
		cardsInHand++;
		if(cardsInHand > 0)
		{
			GO.transform.position += new Vector3(0.5f, 0f, 0f);
		}
	}

	public void selectedCard(GameObject _GO)
	{
		Debug.Log ("Card selected");
		Debug.Log (_GO.name);
		_selectedCard = _GO;
		cardSelected = true;
	}

	public void unselectedCard()
	{
		cardSelected = false;
		_selectedCard = null;
	}


	public void playCardToField(string cardMode)
	{
		//write in some stuff about attack and defense
		//write in some stuff about face up or down
		if (cardSelected)
		{
			//targets are card id
			//int[] _targets = new int[1];
			//_localCL.PlayCard(111 - card ID, _targets, 1 - destination_Field);
			Transform finalPoint = this.transform;
			for(int i = 0; i < entPlace.Length; i++)
			{
				if(!entPlace[i].GetComponent<placementScript>().occupied)
				{
					finalPoint = entPlace[i];
					entPlace[i].GetComponent<placementScript>().occupied = true;
					break;
				}
			}
			_selectedCard.GetComponent<cardScript>().currPos.GetComponent<placementScript>().occupied = false;

			Vector3 pos = Camera.main.WorldToScreenPoint (finalPoint.position);
			_selectedCard.transform.position = pos;
			unselectedCard();
			Debug.Log("Playing card to Field");
		}
		else
		{
			Debug.Log("No card selected");
		}
		attackButt.SetActive (false);
		defenseButt.SetActive (false);
		_selectedCard = null;
		cardSelected = false;
	}

	public void playMachina()
	{
		//write in some stuff about face up or down
		if (cardSelected)
		{
			//int[] _targets = new int[1];
			//_localCL.PlayCard(111 - card ID, _targets, 1 - destination_Field);
			Transform finalPoint = this.transform;
			for(int i = 0; i < entPlace.Length; i++)
			{
				if(!machPlace[i].GetComponent<placementScript>().occupied)
				{
					finalPoint = entPlace[i];
					machPlace[i].GetComponent<placementScript>().occupied = true;
					break;
				}
			}
			_selectedCard.GetComponent<cardScript>().currPos.GetComponent<placementScript>().occupied = false;
			
			Vector3 pos = Camera.main.WorldToScreenPoint (finalPoint.position);
			_selectedCard.transform.position = pos;
			unselectedCard();
			Debug.Log("Playing card to Field");
		}
		else
		{
			Debug.Log("No card selected");
		}
		upButt.SetActive (false);
		downButt.SetActive (false);
	}

	public void faceUpDown()
	{
		upButt.SetActive (true);
		downButt.SetActive (true);
	}

	public void defOrAttak()
	{
		attackButt.SetActive (true);
		defenseButt.SetActive (true);
	}

	public void endTurn()
	{
		Debug.Log ("Ending Turn");
		//_localCL.EndPhase ();
	}

	public void attackEnemy(GameObject enemyCard)
	{
		//int[] _targets = new int[1];
		//_localCL.PlayCard(111/*card ID*/, _targets, 1 /*destination_Field*/);
	}

	public void enemySet(GameObject GO_Enemy)
	{
		if(cardSelected)
		{
			ListEnemies.Add(GO_Enemy);
			ListEnemies.TrimExcess();
			Debug.Log("Enemy set");
		}
		else
		{
			Debug.Log("Card not selected - Enemy");
		}
	}
}
