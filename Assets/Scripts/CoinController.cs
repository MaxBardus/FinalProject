/*Roman Kovalchyk Student ID: 101041366
 * Maksym Bardus Student ID: 100953577
*/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

	[SerializeField]
	private float speed;
	[SerializeField]
	private float startY;
	[SerializeField]
	private float endY;
	[SerializeField]
	private float startX;
	[SerializeField]
	private float endX;



	//private AudioSource enAudio;
	private Transform _transform;
	private Vector2 _currentPos;

	public bool x;
	// Use this for initialization
	void Start () {
		//enAudio = gameObject.GetComponent<AudioSource> ();
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;


	}

	// Update is called once per frame
	void Update () {

		_currentPos = transform.position;
		_currentPos -= new Vector2 (0, speed);

		if (_currentPos.y < endY) {

			Reset ();
		}

		_transform.position = _currentPos;
	}

	// this method will reset coin position when it reaches the end of the scene or if a coin is colliding with copter
	public void Reset(){

		//float y = Random.Range (startY, endY);
		float x = Random.Range (startX, endX);
		_currentPos = new Vector2 (x, 11);
		_transform.position = _currentPos;
	}

	//this method will invoke a sound when the copter is colliding with a coin

}
