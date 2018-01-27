using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {


	float speedBul;
	// Use this for initialization
	void Start ()

	{
		speedBul = 8f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector2 position = transform.position;
		position = new Vector2 (position.x + speedBul * Time.deltaTime, position.x);
		transform.position = position;
	}
}
