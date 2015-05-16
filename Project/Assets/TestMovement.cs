using UnityEngine;
using System.Collections;

public class TestMovement : MonoBehaviour 
{
	private float speed;

	void Start()
	{
		speed = 10.0f;
	}

	void Update()
	{
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (-Vector3.forward * speed * Time.deltaTime);
		}
	}
}