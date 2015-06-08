using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CardManager : MonoBehaviour {

	public float nightmareValue;
	public float dreamValue;
	public float maxHealth;
	public float currentHealth;

	public bool inHand;
	public bool revealed;
	public bool facingUp;
	public bool invading;

	public List<Healthbar> healthBar;
	public List<Text> nightmareText;
	public List<Text> dreamText;

	public SpriteRenderer cardback;
	public List<GameObject> inHandObjects;
	public List<GameObject> onBoardObjects;
	public List<GameObject> facingUpObjects;
	public List<GameObject> facingDownObjects;
	public List<GameObject> invadingObjects;
	public List<GameObject> defendingObjects;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (revealed) {
			if (inHand) {
				foreach (GameObject go in inHandObjects) {
					go.SetActive (true);
				}
				foreach (GameObject go in onBoardObjects) {
					go.SetActive (false);
				}
			} else {
				foreach (GameObject go in inHandObjects) {
					go.SetActive (false);
				}
				foreach (GameObject go in onBoardObjects) {
					go.SetActive (true);
				}
				if (facingUp) {
					foreach (GameObject go in facingUpObjects) {
						go.SetActive (true);
					}
					foreach (GameObject go in facingDownObjects) {
						go.SetActive (false);
					}
				} else {
					foreach (GameObject go in facingUpObjects) {
						go.SetActive (false);
					}
					foreach (GameObject go in facingDownObjects) {
						go.SetActive (true);
					}
				}
				if (invading){
					foreach (GameObject go in invadingObjects){
						go.SetActive(true);
					}
					foreach (GameObject go in defendingObjects){
						go.SetActive(false);
					} 
				} else {
					foreach (GameObject go in invadingObjects){
						go.SetActive(false);
					}
					foreach (GameObject go in defendingObjects){
						go.SetActive(true);
					} 
				}
			}
		} else {
			foreach (GameObject go in inHandObjects) {
				go.SetActive (true);
			}
			foreach (GameObject go in onBoardObjects) {
				go.SetActive (false);
			}
			cardback.enabled = true;
		}
	}
}
