using UnityEngine;
using System.Collections;

public class CloudsMovement : MonoBehaviour 
{
	public float speed;

	void Start()
	{
		speed = 2.5f;
	}

	void Update()
	{
		gameObject.transform.Rotate (Vector3.up * speed * Time.deltaTime);
	}
}