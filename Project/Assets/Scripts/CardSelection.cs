﻿using UnityEngine;
using System.Collections;
using Dreamscape;

public class CardSelection : MonoBehaviour 
{
//	public RaycastHit hit;
//	public static Card selectedCard;
//
//	private Hand hand;
//	private Demo player;
//	
//	void Awake()
//	{
////		hand = GameObject.FindGameObjectWithTag ("Hand").GetComponent<Hand> ();
//		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Demo> ();
//	}
//
//	void Update()
//	{
//		if(Input.GetButtonDown("Fire1")) {
//			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//			if(Physics.Raycast (ray, out hit)) {
//				OnClick(hit.transform.GetComponent<Card>());
//			}
//		}
//	}
//
//	void OnClick(Card _hit)
//	{
//		if (_hit.renderer.enabled == true) {
//			selectedCard = _hit;
//			Debug.Log ("Selected Card: " + selectedCard.GetComponent<Card> ().Name);
//			
//			if(player._target == Target.field) {
//				hand.RemoveCard (selectedCard);
//			} else {
//				hand.RemoveCard(selectedCard, player._pos, player._target);
//			}
//		}
//	}
}