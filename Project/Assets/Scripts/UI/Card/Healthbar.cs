using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Healthbar : MonoBehaviour {

	public float maxHealth;
	private float lastMaxHealth;

	public float currentHealth;

	public Transform healthBar;

	private List<Transform> healthBars;

	// Use this for initialization
	void Start () {
		initHealthBars ();
	}
	
	// Update is called once per frame
	void Update () {
		if (lastMaxHealth != maxHealth) {
			foreach (Transform t in healthBars){
				Destroy(t.gameObject);
			}
			initHealthBars();
		}
		float tempHealth = currentHealth;
		float totalBarWidth = 512 * transform.localScale.x;
		float numBars = maxHealth/100;
		float barWidth = (1 / numBars) * 0.95f;
		foreach (Transform t in healthBars){
			if (tempHealth <= 0){
				t.gameObject.SetActive(false);
			} else if(tempHealth <= 50){
				t.gameObject.SetActive(true);
				Vector3 tempScale = t.localScale;
				tempScale.x = barWidth/2;
				t.localScale = tempScale;
				Vector3 tempPos = t.localPosition;
				tempPos.x = (-(((numBars + 1.5f) * totalBarWidth) / 2) / numBars) + ((healthBars.IndexOf(t)+1) * (totalBarWidth) / numBars);
				t.localPosition = tempPos;
				tempHealth -= 100;
			} else {
				t.gameObject.SetActive(true);
				Vector3 tempScale = t.localScale;
				tempScale.x = barWidth;
				t.localScale = tempScale;
				Vector3 tempPos = t.localPosition;
				tempPos.x = (-(numBars + 1) * totalBarWidth / 2) / numBars + (healthBars.IndexOf(t)+1) * (totalBarWidth) / numBars;
				t.localPosition = tempPos;
				tempHealth -= 100;
			}
		}
	}

	void initHealthBars ()
	{
		healthBars = new List<Transform> ();
		// Max health / 100 = number of bars we need to make rounded up
		// each bar width = 1/number of bars * .98
		// total bar width = 512*scale.x
		// for (i < number of bars)
		// 		position.x = -totalbarwidth/2+i*totalbarwidth/2/number of bars
		float totalBarWidth = 512 * transform.localScale.x;
		float numBars = maxHealth/100;
		float barWidth = (1 / numBars) * 0.95f;
		for (int i=1; i<=Mathf.CeilToInt(numBars); i++) {
			float posX = (-(numBars + 1) * totalBarWidth / 2) / numBars + i * (totalBarWidth) / numBars;
			float scalX = barWidth;
			if (Mathf.FloorToInt (numBars) < i) {
				scalX = barWidth/2;
				posX = (-(((numBars + 1.5f) * totalBarWidth) / 2) / numBars) + (i * (totalBarWidth) / numBars);
			}
			Transform newBar = Instantiate (healthBar) as Transform;
			newBar.parent = transform;
			newBar.localPosition = new Vector3 (posX, 0, 0);
			newBar.localScale = new Vector3 (scalX, 0.75f, 1);
			healthBars.Add (newBar);
		}
		lastMaxHealth = maxHealth;
	}
}
